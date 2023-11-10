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
   public class docmedidaseguranca_bc : GXHttpHandler, IGxSilentTrn
   {
      public docmedidaseguranca_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docmedidaseguranca_bc( IGxContext context )
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
         ReadRow1G59( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1G59( ) ;
         standaloneModal( ) ;
         AddRow1G59( ) ;
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
            E111G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z51MedidaSegurancaId = A51MedidaSegurancaId;
               Z75DocumentoId = A75DocumentoId;
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G59( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G59( ) ;
            }
            else
            {
               CheckExtendedTable1G59( ) ;
               if ( AnyError == 0 )
               {
                  ZM1G59( 2) ;
                  ZM1G59( 3) ;
               }
               CloseExtendedTableCursors1G59( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E121G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1G59( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1G59( )
      {
         /* Using cursor BC001G6 */
         pr_default.execute(4, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound59 = 1;
            ZM1G59( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1G59( ) ;
      }

      protected void OnLoadActions1G59( )
      {
      }

      protected void CheckExtendedTable1G59( )
      {
         nIsDirty_59 = 0;
         standaloneModal( ) ;
         /* Using cursor BC001G4 */
         pr_default.execute(2, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Medida Seguranca'.", "ForeignKeyNotFound", 1, "MEDIDASEGURANCAID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001G5 */
         pr_default.execute(3, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1G59( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1G59( )
      {
         /* Using cursor BC001G7 */
         pr_default.execute(5, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound59 = 1;
         }
         else
         {
            RcdFound59 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001G3 */
         pr_default.execute(1, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G59( 1) ;
            RcdFound59 = 1;
            A51MedidaSegurancaId = BC001G3_A51MedidaSegurancaId[0];
            A75DocumentoId = BC001G3_A75DocumentoId[0];
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            Z75DocumentoId = A75DocumentoId;
            sMode59 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1G59( ) ;
            if ( AnyError == 1 )
            {
               RcdFound59 = 0;
               InitializeNonKey1G59( ) ;
            }
            Gx_mode = sMode59;
         }
         else
         {
            RcdFound59 = 0;
            InitializeNonKey1G59( ) ;
            sMode59 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode59;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G59( ) ;
         if ( RcdFound59 == 0 )
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
         CONFIRM_1G0( ) ;
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

      protected void CheckOptimisticConcurrency1G59( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G2 */
            pr_default.execute(0, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocMedidaSeguranca"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocMedidaSeguranca"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G59( )
      {
         BeforeValidate1G59( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G59( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G59( 0) ;
            CheckOptimisticConcurrency1G59( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G59( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G59( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G8 */
                     pr_default.execute(6, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocMedidaSeguranca");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load1G59( ) ;
            }
            EndLevel1G59( ) ;
         }
         CloseExtendedTableCursors1G59( ) ;
      }

      protected void Update1G59( )
      {
         BeforeValidate1G59( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G59( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G59( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G59( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G59( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocMedidaSeguranca] */
                     DeferredUpdate1G59( ) ;
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
            EndLevel1G59( ) ;
         }
         CloseExtendedTableCursors1G59( ) ;
      }

      protected void DeferredUpdate1G59( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G59( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G59( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G59( ) ;
            AfterConfirm1G59( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G59( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001G9 */
                  pr_default.execute(7, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocMedidaSeguranca");
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
         sMode59 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G59( ) ;
         Gx_mode = sMode59;
      }

      protected void OnDeleteControls1G59( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1G59( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G59( ) ;
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

      public void ScanKeyStart1G59( )
      {
         /* Scan By routine */
         /* Using cursor BC001G10 */
         pr_default.execute(8, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
         RcdFound59 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound59 = 1;
            A51MedidaSegurancaId = BC001G10_A51MedidaSegurancaId[0];
            A75DocumentoId = BC001G10_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G59( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound59 = 0;
         ScanKeyLoad1G59( ) ;
      }

      protected void ScanKeyLoad1G59( )
      {
         sMode59 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound59 = 1;
            A51MedidaSegurancaId = BC001G10_A51MedidaSegurancaId[0];
            A75DocumentoId = BC001G10_A75DocumentoId[0];
         }
         Gx_mode = sMode59;
      }

      protected void ScanKeyEnd1G59( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1G59( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G59( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G59( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G59( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G59( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G59( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G59( )
      {
      }

      protected void send_integrity_lvl_hashes1G59( )
      {
      }

      protected void AddRow1G59( )
      {
         VarsToRow59( bcDocMedidaSeguranca) ;
      }

      protected void ReadRow1G59( )
      {
         RowToVars59( bcDocMedidaSeguranca, 1) ;
      }

      protected void InitializeNonKey1G59( )
      {
      }

      protected void InitAll1G59( )
      {
         A51MedidaSegurancaId = 0;
         A75DocumentoId = 0;
         InitializeNonKey1G59( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow59( SdtDocMedidaSeguranca obj59 )
      {
         obj59.gxTpr_Mode = Gx_mode;
         obj59.gxTpr_Medidasegurancaid = A51MedidaSegurancaId;
         obj59.gxTpr_Documentoid = A75DocumentoId;
         obj59.gxTpr_Medidasegurancaid_Z = Z51MedidaSegurancaId;
         obj59.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj59.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow59( SdtDocMedidaSeguranca obj59 )
      {
         obj59.gxTpr_Medidasegurancaid = A51MedidaSegurancaId;
         obj59.gxTpr_Documentoid = A75DocumentoId;
         return  ;
      }

      public void RowToVars59( SdtDocMedidaSeguranca obj59 ,
                               int forceLoad )
      {
         Gx_mode = obj59.gxTpr_Mode;
         A51MedidaSegurancaId = obj59.gxTpr_Medidasegurancaid;
         A75DocumentoId = obj59.gxTpr_Documentoid;
         Z51MedidaSegurancaId = obj59.gxTpr_Medidasegurancaid_Z;
         Z75DocumentoId = obj59.gxTpr_Documentoid_Z;
         Gx_mode = obj59.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A51MedidaSegurancaId = (int)getParm(obj,0);
         A75DocumentoId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1G59( ) ;
         ScanKeyStart1G59( ) ;
         if ( RcdFound59 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001G11 */
            pr_default.execute(9, new Object[] {A51MedidaSegurancaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Medida Seguranca'.", "ForeignKeyNotFound", 1, "MEDIDASEGURANCAID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001G12 */
            pr_default.execute(10, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1G59( -1) ;
         OnLoadActions1G59( ) ;
         AddRow1G59( ) ;
         ScanKeyEnd1G59( ) ;
         if ( RcdFound59 == 0 )
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
         RowToVars59( bcDocMedidaSeguranca, 0) ;
         ScanKeyStart1G59( ) ;
         if ( RcdFound59 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001G11 */
            pr_default.execute(9, new Object[] {A51MedidaSegurancaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Medida Seguranca'.", "ForeignKeyNotFound", 1, "MEDIDASEGURANCAID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001G12 */
            pr_default.execute(10, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1G59( -1) ;
         OnLoadActions1G59( ) ;
         AddRow1G59( ) ;
         ScanKeyEnd1G59( ) ;
         if ( RcdFound59 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1G59( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1G59( ) ;
         }
         else
         {
            if ( RcdFound59 == 1 )
            {
               if ( ( A51MedidaSegurancaId != Z51MedidaSegurancaId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A51MedidaSegurancaId = Z51MedidaSegurancaId;
                  A75DocumentoId = Z75DocumentoId;
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
                  Update1G59( ) ;
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
                  if ( ( A51MedidaSegurancaId != Z51MedidaSegurancaId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
                        Insert1G59( ) ;
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
                        Insert1G59( ) ;
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
         RowToVars59( bcDocMedidaSeguranca, 1) ;
         SaveImpl( ) ;
         VarsToRow59( bcDocMedidaSeguranca) ;
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
         RowToVars59( bcDocMedidaSeguranca, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G59( ) ;
         AfterTrn( ) ;
         VarsToRow59( bcDocMedidaSeguranca) ;
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
            SdtDocMedidaSeguranca auxBC = new SdtDocMedidaSeguranca(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A51MedidaSegurancaId, A75DocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocMedidaSeguranca);
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
         RowToVars59( bcDocMedidaSeguranca, 1) ;
         UpdateImpl( ) ;
         VarsToRow59( bcDocMedidaSeguranca) ;
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
         RowToVars59( bcDocMedidaSeguranca, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G59( ) ;
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
         VarsToRow59( bcDocMedidaSeguranca) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars59( bcDocMedidaSeguranca, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1G59( ) ;
         if ( RcdFound59 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A51MedidaSegurancaId != Z51MedidaSegurancaId ) || ( A75DocumentoId != Z75DocumentoId ) )
            {
               A51MedidaSegurancaId = Z51MedidaSegurancaId;
               A75DocumentoId = Z75DocumentoId;
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
            if ( ( A51MedidaSegurancaId != Z51MedidaSegurancaId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
         pr_default.close(9);
         pr_default.close(10);
         context.RollbackDataStores("docmedidaseguranca_bc",pr_default);
         VarsToRow59( bcDocMedidaSeguranca) ;
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
         Gx_mode = bcDocMedidaSeguranca.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocMedidaSeguranca.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocMedidaSeguranca )
         {
            bcDocMedidaSeguranca = (SdtDocMedidaSeguranca)(sdt);
            if ( StringUtil.StrCmp(bcDocMedidaSeguranca.gxTpr_Mode, "") == 0 )
            {
               bcDocMedidaSeguranca.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow59( bcDocMedidaSeguranca) ;
            }
            else
            {
               RowToVars59( bcDocMedidaSeguranca, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocMedidaSeguranca.gxTpr_Mode, "") == 0 )
            {
               bcDocMedidaSeguranca.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars59( bcDocMedidaSeguranca, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocMedidaSeguranca DocMedidaSeguranca_BC
      {
         get {
            return bcDocMedidaSeguranca ;
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
            return "docmedidaseguranca_Execute" ;
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
         pr_default.close(9);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         BC001G6_A51MedidaSegurancaId = new int[1] ;
         BC001G6_A75DocumentoId = new int[1] ;
         BC001G4_A51MedidaSegurancaId = new int[1] ;
         BC001G5_A75DocumentoId = new int[1] ;
         BC001G7_A51MedidaSegurancaId = new int[1] ;
         BC001G7_A75DocumentoId = new int[1] ;
         BC001G3_A51MedidaSegurancaId = new int[1] ;
         BC001G3_A75DocumentoId = new int[1] ;
         sMode59 = "";
         BC001G2_A51MedidaSegurancaId = new int[1] ;
         BC001G2_A75DocumentoId = new int[1] ;
         BC001G10_A51MedidaSegurancaId = new int[1] ;
         BC001G10_A75DocumentoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001G11_A51MedidaSegurancaId = new int[1] ;
         BC001G12_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docmedidaseguranca_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docmedidaseguranca_bc__default(),
            new Object[][] {
                new Object[] {
               BC001G2_A51MedidaSegurancaId, BC001G2_A75DocumentoId
               }
               , new Object[] {
               BC001G3_A51MedidaSegurancaId, BC001G3_A75DocumentoId
               }
               , new Object[] {
               BC001G4_A51MedidaSegurancaId
               }
               , new Object[] {
               BC001G5_A75DocumentoId
               }
               , new Object[] {
               BC001G6_A51MedidaSegurancaId, BC001G6_A75DocumentoId
               }
               , new Object[] {
               BC001G7_A51MedidaSegurancaId, BC001G7_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G10_A51MedidaSegurancaId, BC001G10_A75DocumentoId
               }
               , new Object[] {
               BC001G11_A51MedidaSegurancaId
               }
               , new Object[] {
               BC001G12_A75DocumentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121G2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound59 ;
      private short nIsDirty_59 ;
      private int trnEnded ;
      private int Z51MedidaSegurancaId ;
      private int A51MedidaSegurancaId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode59 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV13WebSession ;
      private SdtDocMedidaSeguranca bcDocMedidaSeguranca ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001G6_A51MedidaSegurancaId ;
      private int[] BC001G6_A75DocumentoId ;
      private int[] BC001G4_A51MedidaSegurancaId ;
      private int[] BC001G5_A75DocumentoId ;
      private int[] BC001G7_A51MedidaSegurancaId ;
      private int[] BC001G7_A75DocumentoId ;
      private int[] BC001G3_A51MedidaSegurancaId ;
      private int[] BC001G3_A75DocumentoId ;
      private int[] BC001G2_A51MedidaSegurancaId ;
      private int[] BC001G2_A75DocumentoId ;
      private int[] BC001G10_A51MedidaSegurancaId ;
      private int[] BC001G10_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC001G11_A51MedidaSegurancaId ;
      private int[] BC001G12_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class docmedidaseguranca_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docmedidaseguranca_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001G6;
        prmBC001G6 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G4;
        prmBC001G4 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC001G5;
        prmBC001G5 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G7;
        prmBC001G7 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G3;
        prmBC001G3 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G2;
        prmBC001G2 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G8;
        prmBC001G8 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G9;
        prmBC001G9 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G10;
        prmBC001G10 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001G11;
        prmBC001G11 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC001G12;
        prmBC001G12 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001G2", "SELECT [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WITH (UPDLOCK) WHERE [MedidaSegurancaId] = @MedidaSegurancaId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G3", "SELECT [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G4", "SELECT [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G5", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G6", "SELECT TM1.[MedidaSegurancaId], TM1.[DocumentoId] FROM [DocMedidaSeguranca] TM1 WHERE TM1.[MedidaSegurancaId] = @MedidaSegurancaId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[MedidaSegurancaId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G7", "SELECT [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G8", "INSERT INTO [DocMedidaSeguranca]([MedidaSegurancaId], [DocumentoId]) VALUES(@MedidaSegurancaId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmBC001G8)
           ,new CursorDef("BC001G9", "DELETE FROM [DocMedidaSeguranca]  WHERE [MedidaSegurancaId] = @MedidaSegurancaId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC001G9)
           ,new CursorDef("BC001G10", "SELECT TM1.[MedidaSegurancaId], TM1.[DocumentoId] FROM [DocMedidaSeguranca] TM1 WHERE TM1.[MedidaSegurancaId] = @MedidaSegurancaId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[MedidaSegurancaId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G11", "SELECT [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G12", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G12,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
