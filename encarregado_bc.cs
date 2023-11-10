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
   public class encarregado_bc : GXHttpHandler, IGxSilentTrn
   {
      public encarregado_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public encarregado_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z7EncarregadoId = A7EncarregadoId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsEncarregado = true;
         AV14EncarregadoId_Out = A7EncarregadoId;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z8EncarregadoNome = A8EncarregadoNome;
            Z9EncarregadoAtivo = A9EncarregadoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z7EncarregadoId = A7EncarregadoId;
            Z8EncarregadoNome = A8EncarregadoNome;
            Z9EncarregadoAtivo = A9EncarregadoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A9EncarregadoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A9EncarregadoAtivo = true;
         }
      }

      protected void Load033( )
      {
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A8EncarregadoNome = BC00034_A8EncarregadoNome[0];
            A9EncarregadoAtivo = BC00034_A9EncarregadoAtivo[0];
            ZM033( -6) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         A8EncarregadoNome = StringUtil.Upper( A8EncarregadoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "Encarregado",  A7EncarregadoId,  A8EncarregadoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         standaloneModal( ) ;
         nIsDirty_3 = 1;
         A8EncarregadoNome = StringUtil.Upper( A8EncarregadoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "Encarregado",  A7EncarregadoId,  A8EncarregadoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8EncarregadoNome)) )
         {
            GX_msglist.addItem("Informe o nome do Encarregado.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 6) ;
            RcdFound3 = 1;
            A7EncarregadoId = BC00033_A7EncarregadoId[0];
            n7EncarregadoId = BC00033_n7EncarregadoId[0];
            A8EncarregadoNome = BC00033_A8EncarregadoNome[0];
            A9EncarregadoAtivo = BC00033_A9EncarregadoAtivo[0];
            Z7EncarregadoId = A7EncarregadoId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {n7EncarregadoId, A7EncarregadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Encarregado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8EncarregadoNome, BC00032_A8EncarregadoNome[0]) != 0 ) || ( Z9EncarregadoAtivo != BC00032_A9EncarregadoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Encarregado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00036 */
                     pr_default.execute(4, new Object[] {A8EncarregadoNome, A9EncarregadoAtivo});
                     A7EncarregadoId = BC00036_A7EncarregadoId[0];
                     n7EncarregadoId = BC00036_n7EncarregadoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Encarregado");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A8EncarregadoNome, A9EncarregadoAtivo, n7EncarregadoId, A7EncarregadoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Encarregado");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Encarregado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00038 */
                  pr_default.execute(6, new Object[] {n7EncarregadoId, A7EncarregadoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Encarregado");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "Encarregado",  A7EncarregadoId,  A8EncarregadoNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC00039 */
            pr_default.execute(7, new Object[] {n7EncarregadoId, A7EncarregadoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Scan By routine */
         /* Using cursor BC000310 */
         pr_default.execute(8, new Object[] {n7EncarregadoId, A7EncarregadoId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound3 = 1;
            A7EncarregadoId = BC000310_A7EncarregadoId[0];
            n7EncarregadoId = BC000310_n7EncarregadoId[0];
            A8EncarregadoNome = BC000310_A8EncarregadoNome[0];
            A9EncarregadoAtivo = BC000310_A9EncarregadoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound3 = 1;
            A7EncarregadoId = BC000310_A7EncarregadoId[0];
            n7EncarregadoId = BC000310_n7EncarregadoId[0];
            A8EncarregadoNome = BC000310_A8EncarregadoNome[0];
            A9EncarregadoAtivo = BC000310_A9EncarregadoAtivo[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcEncarregado) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcEncarregado, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A8EncarregadoNome = "";
         AV16IsOk = false;
         A9EncarregadoAtivo = true;
         Z8EncarregadoNome = "";
         Z9EncarregadoAtivo = false;
      }

      protected void InitAll033( )
      {
         A7EncarregadoId = 0;
         n7EncarregadoId = false;
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A9EncarregadoAtivo = i9EncarregadoAtivo;
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

      public void VarsToRow3( SdtEncarregado obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Encarregadonome = A8EncarregadoNome;
         obj3.gxTpr_Encarregadoativo = A9EncarregadoAtivo;
         obj3.gxTpr_Encarregadoid = A7EncarregadoId;
         obj3.gxTpr_Encarregadoid_Z = Z7EncarregadoId;
         obj3.gxTpr_Encarregadonome_Z = Z8EncarregadoNome;
         obj3.gxTpr_Encarregadoativo_Z = Z9EncarregadoAtivo;
         obj3.gxTpr_Encarregadoid_N = (short)(Convert.ToInt16(n7EncarregadoId));
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtEncarregado obj3 )
      {
         obj3.gxTpr_Encarregadoid = A7EncarregadoId;
         return  ;
      }

      public void RowToVars3( SdtEncarregado obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A8EncarregadoNome = obj3.gxTpr_Encarregadonome;
         A9EncarregadoAtivo = obj3.gxTpr_Encarregadoativo;
         A7EncarregadoId = obj3.gxTpr_Encarregadoid;
         n7EncarregadoId = false;
         Z7EncarregadoId = obj3.gxTpr_Encarregadoid_Z;
         Z8EncarregadoNome = obj3.gxTpr_Encarregadonome_Z;
         Z9EncarregadoAtivo = obj3.gxTpr_Encarregadoativo_Z;
         n7EncarregadoId = (bool)(Convert.ToBoolean(obj3.gxTpr_Encarregadoid_N));
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A7EncarregadoId = (int)getParm(obj,0);
         n7EncarregadoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7EncarregadoId = A7EncarregadoId;
         }
         ZM033( -6) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcEncarregado, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7EncarregadoId = A7EncarregadoId;
         }
         ZM033( -6) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A7EncarregadoId != Z7EncarregadoId )
               {
                  A7EncarregadoId = Z7EncarregadoId;
                  n7EncarregadoId = false;
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
                  Update033( ) ;
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
                  if ( A7EncarregadoId != Z7EncarregadoId )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcEncarregado, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcEncarregado) ;
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
         RowToVars3( bcEncarregado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcEncarregado) ;
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
            SdtEncarregado auxBC = new SdtEncarregado(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A7EncarregadoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEncarregado);
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
         RowToVars3( bcEncarregado, 1) ;
         UpdateImpl( ) ;
         VarsToRow3( bcEncarregado) ;
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
         RowToVars3( bcEncarregado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
         VarsToRow3( bcEncarregado) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcEncarregado, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A7EncarregadoId != Z7EncarregadoId )
            {
               A7EncarregadoId = Z7EncarregadoId;
               n7EncarregadoId = false;
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
            if ( A7EncarregadoId != Z7EncarregadoId )
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
         context.RollbackDataStores("encarregado_bc",pr_default);
         VarsToRow3( bcEncarregado) ;
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
         Gx_mode = bcEncarregado.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEncarregado.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEncarregado )
         {
            bcEncarregado = (SdtEncarregado)(sdt);
            if ( StringUtil.StrCmp(bcEncarregado.gxTpr_Mode, "") == 0 )
            {
               bcEncarregado.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcEncarregado) ;
            }
            else
            {
               RowToVars3( bcEncarregado, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEncarregado.gxTpr_Mode, "") == 0 )
            {
               bcEncarregado.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcEncarregado, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEncarregado Encarregado_BC
      {
         get {
            return bcEncarregado ;
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
            return "encarregado_Execute" ;
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
         Z8EncarregadoNome = "";
         A8EncarregadoNome = "";
         BC00034_A7EncarregadoId = new int[1] ;
         BC00034_n7EncarregadoId = new bool[] {false} ;
         BC00034_A8EncarregadoNome = new string[] {""} ;
         BC00034_A9EncarregadoAtivo = new bool[] {false} ;
         BC00035_A7EncarregadoId = new int[1] ;
         BC00035_n7EncarregadoId = new bool[] {false} ;
         BC00033_A7EncarregadoId = new int[1] ;
         BC00033_n7EncarregadoId = new bool[] {false} ;
         BC00033_A8EncarregadoNome = new string[] {""} ;
         BC00033_A9EncarregadoAtivo = new bool[] {false} ;
         sMode3 = "";
         BC00032_A7EncarregadoId = new int[1] ;
         BC00032_n7EncarregadoId = new bool[] {false} ;
         BC00032_A8EncarregadoNome = new string[] {""} ;
         BC00032_A9EncarregadoAtivo = new bool[] {false} ;
         BC00036_A7EncarregadoId = new int[1] ;
         BC00036_n7EncarregadoId = new bool[] {false} ;
         BC00039_A75DocumentoId = new int[1] ;
         BC000310_A7EncarregadoId = new int[1] ;
         BC000310_n7EncarregadoId = new bool[] {false} ;
         BC000310_A8EncarregadoNome = new string[] {""} ;
         BC000310_A9EncarregadoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.encarregado_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.encarregado_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A7EncarregadoId, BC00032_A8EncarregadoNome, BC00032_A9EncarregadoAtivo
               }
               , new Object[] {
               BC00033_A7EncarregadoId, BC00033_A8EncarregadoNome, BC00033_A9EncarregadoAtivo
               }
               , new Object[] {
               BC00034_A7EncarregadoId, BC00034_A8EncarregadoNome, BC00034_A9EncarregadoAtivo
               }
               , new Object[] {
               BC00035_A7EncarregadoId
               }
               , new Object[] {
               BC00036_A7EncarregadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00039_A75DocumentoId
               }
               , new Object[] {
               BC000310_A7EncarregadoId, BC000310_A8EncarregadoNome, BC000310_A9EncarregadoAtivo
               }
            }
         );
         Z9EncarregadoAtivo = true;
         A9EncarregadoAtivo = true;
         i9EncarregadoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private int trnEnded ;
      private int Z7EncarregadoId ;
      private int A7EncarregadoId ;
      private int AV14EncarregadoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode3 ;
      private bool returnInSub ;
      private bool AV13IsEncarregado ;
      private bool Z9EncarregadoAtivo ;
      private bool A9EncarregadoAtivo ;
      private bool n7EncarregadoId ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i9EncarregadoAtivo ;
      private bool mustCommit ;
      private string Z8EncarregadoNome ;
      private string A8EncarregadoNome ;
      private IGxSession AV12WebSession ;
      private SdtEncarregado bcEncarregado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00034_A7EncarregadoId ;
      private bool[] BC00034_n7EncarregadoId ;
      private string[] BC00034_A8EncarregadoNome ;
      private bool[] BC00034_A9EncarregadoAtivo ;
      private int[] BC00035_A7EncarregadoId ;
      private bool[] BC00035_n7EncarregadoId ;
      private int[] BC00033_A7EncarregadoId ;
      private bool[] BC00033_n7EncarregadoId ;
      private string[] BC00033_A8EncarregadoNome ;
      private bool[] BC00033_A9EncarregadoAtivo ;
      private int[] BC00032_A7EncarregadoId ;
      private bool[] BC00032_n7EncarregadoId ;
      private string[] BC00032_A8EncarregadoNome ;
      private bool[] BC00032_A9EncarregadoAtivo ;
      private int[] BC00036_A7EncarregadoId ;
      private bool[] BC00036_n7EncarregadoId ;
      private int[] BC00039_A75DocumentoId ;
      private int[] BC000310_A7EncarregadoId ;
      private bool[] BC000310_n7EncarregadoId ;
      private string[] BC000310_A8EncarregadoNome ;
      private bool[] BC000310_A9EncarregadoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class encarregado_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class encarregado_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00034;
        prmBC00034 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00035;
        prmBC00035 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00033;
        prmBC00033 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00032;
        prmBC00032 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00036;
        prmBC00036 = new Object[] {
        new ParDef("@EncarregadoNome",GXType.NVarChar,100,0) ,
        new ParDef("@EncarregadoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC00037;
        prmBC00037 = new Object[] {
        new ParDef("@EncarregadoNome",GXType.NVarChar,100,0) ,
        new ParDef("@EncarregadoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00038;
        prmBC00038 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00039;
        prmBC00039 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000310;
        prmBC000310 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00032", "SELECT [EncarregadoId], [EncarregadoNome], [EncarregadoAtivo] FROM [Encarregado] WITH (UPDLOCK) WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00033", "SELECT [EncarregadoId], [EncarregadoNome], [EncarregadoAtivo] FROM [Encarregado] WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00034", "SELECT TM1.[EncarregadoId], TM1.[EncarregadoNome], TM1.[EncarregadoAtivo] FROM [Encarregado] TM1 WHERE TM1.[EncarregadoId] = @EncarregadoId ORDER BY TM1.[EncarregadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00035", "SELECT [EncarregadoId] FROM [Encarregado] WHERE [EncarregadoId] = @EncarregadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00036", "INSERT INTO [Encarregado]([EncarregadoNome], [EncarregadoAtivo]) VALUES(@EncarregadoNome, @EncarregadoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00037", "UPDATE [Encarregado] SET [EncarregadoNome]=@EncarregadoNome, [EncarregadoAtivo]=@EncarregadoAtivo  WHERE [EncarregadoId] = @EncarregadoId", GxErrorMask.GX_NOMASK,prmBC00037)
           ,new CursorDef("BC00038", "DELETE FROM [Encarregado]  WHERE [EncarregadoId] = @EncarregadoId", GxErrorMask.GX_NOMASK,prmBC00038)
           ,new CursorDef("BC00039", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00039,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000310", "SELECT TM1.[EncarregadoId], TM1.[EncarregadoNome], TM1.[EncarregadoAtivo] FROM [Encarregado] TM1 WHERE TM1.[EncarregadoId] = @EncarregadoId ORDER BY TM1.[EncarregadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,100, GxCacheFrequency.OFF ,true,false )
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
