using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class categoria_bc : GXHttpHandler, IGxSilentTrn
   {
      public categoria_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public categoria_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z27CategoriaId = A27CategoriaId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12092( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11092( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z28CategoriaNome = A28CategoriaNome;
            Z29CategoriaAtivo = A29CategoriaAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z27CategoriaId = A27CategoriaId;
            Z28CategoriaNome = A28CategoriaNome;
            Z29CategoriaAtivo = A29CategoriaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A29CategoriaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A29CategoriaAtivo = true;
         }
      }

      protected void Load099( )
      {
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound9 = 1;
            A28CategoriaNome = BC00094_A28CategoriaNome[0];
            A29CategoriaAtivo = BC00094_A29CategoriaAtivo[0];
            ZM099( -6) ;
         }
         pr_default.close(2);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         A28CategoriaNome = StringUtil.Upper( A28CategoriaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "Categoria",  A27CategoriaId,  A28CategoriaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         nIsDirty_9 = 1;
         A28CategoriaNome = StringUtil.Upper( A28CategoriaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "Categoria",  A27CategoriaId,  A28CategoriaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A28CategoriaNome)) )
         {
            GX_msglist.addItem("Informe o nome da Categoria.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors099( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 6) ;
            RcdFound9 = 1;
            A27CategoriaId = BC00093_A27CategoriaId[0];
            n27CategoriaId = BC00093_n27CategoriaId[0];
            A28CategoriaNome = BC00093_A28CategoriaNome[0];
            A29CategoriaAtivo = BC00093_A29CategoriaAtivo[0];
            Z27CategoriaId = A27CategoriaId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_090( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {n27CategoriaId, A27CategoriaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Categoria"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z28CategoriaNome, BC00092_A28CategoriaNome[0]) != 0 ) || ( Z29CategoriaAtivo != BC00092_A29CategoriaAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Categoria"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00096 */
                     pr_default.execute(4, new Object[] {A28CategoriaNome, A29CategoriaAtivo});
                     A27CategoriaId = BC00096_A27CategoriaId[0];
                     n27CategoriaId = BC00096_n27CategoriaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Categoria");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00097 */
                     pr_default.execute(5, new Object[] {A28CategoriaNome, A29CategoriaAtivo, n27CategoriaId, A27CategoriaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Categoria");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Categoria"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00098 */
                  pr_default.execute(6, new Object[] {n27CategoriaId, A27CategoriaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Categoria");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "Categoria",  A27CategoriaId,  A28CategoriaNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC00099 */
            pr_default.execute(7, new Object[] {n27CategoriaId, A27CategoriaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart099( )
      {
         /* Scan By routine */
         /* Using cursor BC000910 */
         pr_default.execute(8, new Object[] {n27CategoriaId, A27CategoriaId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound9 = 1;
            A27CategoriaId = BC000910_A27CategoriaId[0];
            n27CategoriaId = BC000910_n27CategoriaId[0];
            A28CategoriaNome = BC000910_A28CategoriaNome[0];
            A29CategoriaAtivo = BC000910_A29CategoriaAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound9 = 1;
            A27CategoriaId = BC000910_A27CategoriaId[0];
            n27CategoriaId = BC000910_n27CategoriaId[0];
            A28CategoriaNome = BC000910_A28CategoriaNome[0];
            A29CategoriaAtivo = BC000910_A29CategoriaAtivo[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcCategoria) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcCategoria, 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A28CategoriaNome = "";
         AV16IsOk = false;
         A29CategoriaAtivo = true;
         Z28CategoriaNome = "";
         Z29CategoriaAtivo = false;
      }

      protected void InitAll099( )
      {
         A27CategoriaId = 0;
         n27CategoriaId = false;
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29CategoriaAtivo = i29CategoriaAtivo;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow9( SdtCategoria obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Categorianome = A28CategoriaNome;
         obj9.gxTpr_Categoriaativo = A29CategoriaAtivo;
         obj9.gxTpr_Categoriaid = A27CategoriaId;
         obj9.gxTpr_Categoriaid_Z = Z27CategoriaId;
         obj9.gxTpr_Categorianome_Z = Z28CategoriaNome;
         obj9.gxTpr_Categoriaativo_Z = Z29CategoriaAtivo;
         obj9.gxTpr_Categoriaid_N = (short)(Convert.ToInt16(n27CategoriaId));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtCategoria obj9 )
      {
         obj9.gxTpr_Categoriaid = A27CategoriaId;
         return  ;
      }

      public void RowToVars9( SdtCategoria obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A28CategoriaNome = obj9.gxTpr_Categorianome;
         A29CategoriaAtivo = obj9.gxTpr_Categoriaativo;
         A27CategoriaId = obj9.gxTpr_Categoriaid;
         n27CategoriaId = false;
         Z27CategoriaId = obj9.gxTpr_Categoriaid_Z;
         Z28CategoriaNome = obj9.gxTpr_Categorianome_Z;
         Z29CategoriaAtivo = obj9.gxTpr_Categoriaativo_Z;
         n27CategoriaId = (bool)(Convert.ToBoolean(obj9.gxTpr_Categoriaid_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A27CategoriaId = (int)getParm(obj,0);
         n27CategoriaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z27CategoriaId = A27CategoriaId;
         }
         ZM099( -6) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars9( bcCategoria, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z27CategoriaId = A27CategoriaId;
         }
         ZM099( -6) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A27CategoriaId != Z27CategoriaId )
               {
                  A27CategoriaId = Z27CategoriaId;
                  n27CategoriaId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update099( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A27CategoriaId != Z27CategoriaId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert099( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert099( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcCategoria, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcCategoria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtCategoria auxBC = new SdtCategoria(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A27CategoriaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCategoria);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcCategoria, 1) ;
         UpdateImpl( ) ;
         VarsToRow9( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcCategoria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow9( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcCategoria, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A27CategoriaId != Z27CategoriaId )
            {
               A27CategoriaId = Z27CategoriaId;
               n27CategoriaId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A27CategoriaId != Z27CategoriaId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("categoria_bc",pr_default);
         VarsToRow9( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcCategoria.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCategoria.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCategoria )
         {
            bcCategoria = (SdtCategoria)(sdt);
            if ( StringUtil.StrCmp(bcCategoria.gxTpr_Mode, "") == 0 )
            {
               bcCategoria.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcCategoria) ;
            }
            else
            {
               RowToVars9( bcCategoria, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCategoria.gxTpr_Mode, "") == 0 )
            {
               bcCategoria.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcCategoria, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCategoria Categoria_BC
      {
         get {
            return bcCategoria ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "categoria_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z28CategoriaNome = "";
         A28CategoriaNome = "";
         BC00094_A27CategoriaId = new int[1] ;
         BC00094_n27CategoriaId = new bool[] {false} ;
         BC00094_A28CategoriaNome = new string[] {""} ;
         BC00094_A29CategoriaAtivo = new bool[] {false} ;
         BC00095_A27CategoriaId = new int[1] ;
         BC00095_n27CategoriaId = new bool[] {false} ;
         BC00093_A27CategoriaId = new int[1] ;
         BC00093_n27CategoriaId = new bool[] {false} ;
         BC00093_A28CategoriaNome = new string[] {""} ;
         BC00093_A29CategoriaAtivo = new bool[] {false} ;
         sMode9 = "";
         BC00092_A27CategoriaId = new int[1] ;
         BC00092_n27CategoriaId = new bool[] {false} ;
         BC00092_A28CategoriaNome = new string[] {""} ;
         BC00092_A29CategoriaAtivo = new bool[] {false} ;
         BC00096_A27CategoriaId = new int[1] ;
         BC00096_n27CategoriaId = new bool[] {false} ;
         BC00099_A75DocumentoId = new int[1] ;
         BC000910_A27CategoriaId = new int[1] ;
         BC000910_n27CategoriaId = new bool[] {false} ;
         BC000910_A28CategoriaNome = new string[] {""} ;
         BC000910_A29CategoriaAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.categoria_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoria_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A27CategoriaId, BC00092_A28CategoriaNome, BC00092_A29CategoriaAtivo
               }
               , new Object[] {
               BC00093_A27CategoriaId, BC00093_A28CategoriaNome, BC00093_A29CategoriaAtivo
               }
               , new Object[] {
               BC00094_A27CategoriaId, BC00094_A28CategoriaNome, BC00094_A29CategoriaAtivo
               }
               , new Object[] {
               BC00095_A27CategoriaId
               }
               , new Object[] {
               BC00096_A27CategoriaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00099_A75DocumentoId
               }
               , new Object[] {
               BC000910_A27CategoriaId, BC000910_A28CategoriaNome, BC000910_A29CategoriaAtivo
               }
            }
         );
         Z29CategoriaAtivo = true;
         A29CategoriaAtivo = true;
         i29CategoriaAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12092 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private int trnEnded ;
      private int Z27CategoriaId ;
      private int A27CategoriaId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private bool returnInSub ;
      private bool Z29CategoriaAtivo ;
      private bool A29CategoriaAtivo ;
      private bool n27CategoriaId ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i29CategoriaAtivo ;
      private bool mustCommit ;
      private string Z28CategoriaNome ;
      private string A28CategoriaNome ;
      private IGxSession AV12WebSession ;
      private SdtCategoria bcCategoria ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00094_A27CategoriaId ;
      private bool[] BC00094_n27CategoriaId ;
      private string[] BC00094_A28CategoriaNome ;
      private bool[] BC00094_A29CategoriaAtivo ;
      private int[] BC00095_A27CategoriaId ;
      private bool[] BC00095_n27CategoriaId ;
      private int[] BC00093_A27CategoriaId ;
      private bool[] BC00093_n27CategoriaId ;
      private string[] BC00093_A28CategoriaNome ;
      private bool[] BC00093_A29CategoriaAtivo ;
      private int[] BC00092_A27CategoriaId ;
      private bool[] BC00092_n27CategoriaId ;
      private string[] BC00092_A28CategoriaNome ;
      private bool[] BC00092_A29CategoriaAtivo ;
      private int[] BC00096_A27CategoriaId ;
      private bool[] BC00096_n27CategoriaId ;
      private int[] BC00099_A75DocumentoId ;
      private int[] BC000910_A27CategoriaId ;
      private bool[] BC000910_n27CategoriaId ;
      private string[] BC000910_A28CategoriaNome ;
      private bool[] BC000910_A29CategoriaAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class categoria_bc__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class categoria_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00094;
        prmBC00094 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00095;
        prmBC00095 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00093;
        prmBC00093 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00092;
        prmBC00092 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00096;
        prmBC00096 = new Object[] {
        new ParDef("@CategoriaNome",GXType.NVarChar,100,0) ,
        new ParDef("@CategoriaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC00097;
        prmBC00097 = new Object[] {
        new ParDef("@CategoriaNome",GXType.NVarChar,100,0) ,
        new ParDef("@CategoriaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00098;
        prmBC00098 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00099;
        prmBC00099 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000910;
        prmBC000910 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00092", "SELECT [CategoriaId], [CategoriaNome], [CategoriaAtivo] FROM [Categoria] WITH (UPDLOCK) WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00093", "SELECT [CategoriaId], [CategoriaNome], [CategoriaAtivo] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00094", "SELECT TM1.[CategoriaId], TM1.[CategoriaNome], TM1.[CategoriaAtivo] FROM [Categoria] TM1 WHERE TM1.[CategoriaId] = @CategoriaId ORDER BY TM1.[CategoriaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00095", "SELECT [CategoriaId] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00096", "INSERT INTO [Categoria]([CategoriaNome], [CategoriaAtivo]) VALUES(@CategoriaNome, @CategoriaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00097", "UPDATE [Categoria] SET [CategoriaNome]=@CategoriaNome, [CategoriaAtivo]=@CategoriaAtivo  WHERE [CategoriaId] = @CategoriaId", GxErrorMask.GX_NOMASK,prmBC00097)
           ,new CursorDef("BC00098", "DELETE FROM [Categoria]  WHERE [CategoriaId] = @CategoriaId", GxErrorMask.GX_NOMASK,prmBC00098)
           ,new CursorDef("BC00099", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000910", "SELECT TM1.[CategoriaId], TM1.[CategoriaNome], TM1.[CategoriaAtivo] FROM [Categoria] TM1 WHERE TM1.[CategoriaId] = @CategoriaId ORDER BY TM1.[CategoriaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000910,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
     }
  }

}

}
