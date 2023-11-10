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
   public class docsetorinterno_bc : GXHttpHandler, IGxSilentTrn
   {
      public docsetorinterno_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docsetorinterno_bc( IGxContext context )
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
         ReadRow1750( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1750( ) ;
         standaloneModal( ) ;
         AddRow1750( ) ;
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
            E11172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z60SetorInternoId = A60SetorInternoId;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1750( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1750( ) ;
            }
            else
            {
               CheckExtendedTable1750( ) ;
               if ( AnyError == 0 )
               {
                  ZM1750( 2) ;
                  ZM1750( 3) ;
               }
               CloseExtendedTableCursors1750( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12172( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11172( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1750( short GX_JID )
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
            Z60SetorInternoId = A60SetorInternoId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1750( )
      {
         /* Using cursor BC00176 */
         pr_default.execute(4, new Object[] {A60SetorInternoId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound50 = 1;
            ZM1750( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1750( ) ;
      }

      protected void OnLoadActions1750( )
      {
      }

      protected void CheckExtendedTable1750( )
      {
         nIsDirty_50 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00174 */
         pr_default.execute(2, new Object[] {A60SetorInternoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Setor Interno'.", "ForeignKeyNotFound", 1, "SETORINTERNOID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00175 */
         pr_default.execute(3, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1750( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1750( )
      {
         /* Using cursor BC00177 */
         pr_default.execute(5, new Object[] {A60SetorInternoId, A75DocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound50 = 1;
         }
         else
         {
            RcdFound50 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00173 */
         pr_default.execute(1, new Object[] {A60SetorInternoId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1750( 1) ;
            RcdFound50 = 1;
            A60SetorInternoId = BC00173_A60SetorInternoId[0];
            A75DocumentoId = BC00173_A75DocumentoId[0];
            Z60SetorInternoId = A60SetorInternoId;
            Z75DocumentoId = A75DocumentoId;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1750( ) ;
            if ( AnyError == 1 )
            {
               RcdFound50 = 0;
               InitializeNonKey1750( ) ;
            }
            Gx_mode = sMode50;
         }
         else
         {
            RcdFound50 = 0;
            InitializeNonKey1750( ) ;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode50;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1750( ) ;
         if ( RcdFound50 == 0 )
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
         CONFIRM_170( ) ;
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

      protected void CheckOptimisticConcurrency1750( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00172 */
            pr_default.execute(0, new Object[] {A60SetorInternoId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocSetorInterno"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocSetorInterno"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1750( )
      {
         BeforeValidate1750( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1750( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1750( 0) ;
            CheckOptimisticConcurrency1750( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1750( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1750( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00178 */
                     pr_default.execute(6, new Object[] {A60SetorInternoId, A75DocumentoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocSetorInterno");
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
               Load1750( ) ;
            }
            EndLevel1750( ) ;
         }
         CloseExtendedTableCursors1750( ) ;
      }

      protected void Update1750( )
      {
         BeforeValidate1750( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1750( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1750( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1750( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1750( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocSetorInterno] */
                     DeferredUpdate1750( ) ;
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
            EndLevel1750( ) ;
         }
         CloseExtendedTableCursors1750( ) ;
      }

      protected void DeferredUpdate1750( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1750( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1750( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1750( ) ;
            AfterConfirm1750( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1750( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00179 */
                  pr_default.execute(7, new Object[] {A60SetorInternoId, A75DocumentoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocSetorInterno");
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
         sMode50 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1750( ) ;
         Gx_mode = sMode50;
      }

      protected void OnDeleteControls1750( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1750( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1750( ) ;
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

      public void ScanKeyStart1750( )
      {
         /* Scan By routine */
         /* Using cursor BC001710 */
         pr_default.execute(8, new Object[] {A60SetorInternoId, A75DocumentoId});
         RcdFound50 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound50 = 1;
            A60SetorInternoId = BC001710_A60SetorInternoId[0];
            A75DocumentoId = BC001710_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1750( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound50 = 0;
         ScanKeyLoad1750( ) ;
      }

      protected void ScanKeyLoad1750( )
      {
         sMode50 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound50 = 1;
            A60SetorInternoId = BC001710_A60SetorInternoId[0];
            A75DocumentoId = BC001710_A75DocumentoId[0];
         }
         Gx_mode = sMode50;
      }

      protected void ScanKeyEnd1750( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1750( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1750( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1750( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1750( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1750( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1750( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1750( )
      {
      }

      protected void send_integrity_lvl_hashes1750( )
      {
      }

      protected void AddRow1750( )
      {
         VarsToRow50( bcDocSetorInterno) ;
      }

      protected void ReadRow1750( )
      {
         RowToVars50( bcDocSetorInterno, 1) ;
      }

      protected void InitializeNonKey1750( )
      {
      }

      protected void InitAll1750( )
      {
         A60SetorInternoId = 0;
         A75DocumentoId = 0;
         InitializeNonKey1750( ) ;
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

      public void VarsToRow50( SdtDocSetorInterno obj50 )
      {
         obj50.gxTpr_Mode = Gx_mode;
         obj50.gxTpr_Setorinternoid = A60SetorInternoId;
         obj50.gxTpr_Documentoid = A75DocumentoId;
         obj50.gxTpr_Setorinternoid_Z = Z60SetorInternoId;
         obj50.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj50.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow50( SdtDocSetorInterno obj50 )
      {
         obj50.gxTpr_Setorinternoid = A60SetorInternoId;
         obj50.gxTpr_Documentoid = A75DocumentoId;
         return  ;
      }

      public void RowToVars50( SdtDocSetorInterno obj50 ,
                               int forceLoad )
      {
         Gx_mode = obj50.gxTpr_Mode;
         A60SetorInternoId = obj50.gxTpr_Setorinternoid;
         A75DocumentoId = obj50.gxTpr_Documentoid;
         Z60SetorInternoId = obj50.gxTpr_Setorinternoid_Z;
         Z75DocumentoId = obj50.gxTpr_Documentoid_Z;
         Gx_mode = obj50.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A60SetorInternoId = (int)getParm(obj,0);
         A75DocumentoId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1750( ) ;
         ScanKeyStart1750( ) ;
         if ( RcdFound50 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001711 */
            pr_default.execute(9, new Object[] {A60SetorInternoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Setor Interno'.", "ForeignKeyNotFound", 1, "SETORINTERNOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001712 */
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
            Z60SetorInternoId = A60SetorInternoId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1750( -1) ;
         OnLoadActions1750( ) ;
         AddRow1750( ) ;
         ScanKeyEnd1750( ) ;
         if ( RcdFound50 == 0 )
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
         RowToVars50( bcDocSetorInterno, 0) ;
         ScanKeyStart1750( ) ;
         if ( RcdFound50 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001711 */
            pr_default.execute(9, new Object[] {A60SetorInternoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Setor Interno'.", "ForeignKeyNotFound", 1, "SETORINTERNOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001712 */
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
            Z60SetorInternoId = A60SetorInternoId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1750( -1) ;
         OnLoadActions1750( ) ;
         AddRow1750( ) ;
         ScanKeyEnd1750( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1750( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1750( ) ;
         }
         else
         {
            if ( RcdFound50 == 1 )
            {
               if ( ( A60SetorInternoId != Z60SetorInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A60SetorInternoId = Z60SetorInternoId;
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
                  Update1750( ) ;
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
                  if ( ( A60SetorInternoId != Z60SetorInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
                        Insert1750( ) ;
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
                        Insert1750( ) ;
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
         RowToVars50( bcDocSetorInterno, 1) ;
         SaveImpl( ) ;
         VarsToRow50( bcDocSetorInterno) ;
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
         RowToVars50( bcDocSetorInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1750( ) ;
         AfterTrn( ) ;
         VarsToRow50( bcDocSetorInterno) ;
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
            SdtDocSetorInterno auxBC = new SdtDocSetorInterno(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A60SetorInternoId, A75DocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocSetorInterno);
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
         RowToVars50( bcDocSetorInterno, 1) ;
         UpdateImpl( ) ;
         VarsToRow50( bcDocSetorInterno) ;
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
         RowToVars50( bcDocSetorInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1750( ) ;
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
         VarsToRow50( bcDocSetorInterno) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars50( bcDocSetorInterno, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1750( ) ;
         if ( RcdFound50 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A60SetorInternoId != Z60SetorInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
            {
               A60SetorInternoId = Z60SetorInternoId;
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
            if ( ( A60SetorInternoId != Z60SetorInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
         context.RollbackDataStores("docsetorinterno_bc",pr_default);
         VarsToRow50( bcDocSetorInterno) ;
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
         Gx_mode = bcDocSetorInterno.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocSetorInterno.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocSetorInterno )
         {
            bcDocSetorInterno = (SdtDocSetorInterno)(sdt);
            if ( StringUtil.StrCmp(bcDocSetorInterno.gxTpr_Mode, "") == 0 )
            {
               bcDocSetorInterno.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow50( bcDocSetorInterno) ;
            }
            else
            {
               RowToVars50( bcDocSetorInterno, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocSetorInterno.gxTpr_Mode, "") == 0 )
            {
               bcDocSetorInterno.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars50( bcDocSetorInterno, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocSetorInterno DocSetorInterno_BC
      {
         get {
            return bcDocSetorInterno ;
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
            return "docsetorinterno_Execute" ;
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
         BC00176_A60SetorInternoId = new int[1] ;
         BC00176_A75DocumentoId = new int[1] ;
         BC00174_A60SetorInternoId = new int[1] ;
         BC00175_A75DocumentoId = new int[1] ;
         BC00177_A60SetorInternoId = new int[1] ;
         BC00177_A75DocumentoId = new int[1] ;
         BC00173_A60SetorInternoId = new int[1] ;
         BC00173_A75DocumentoId = new int[1] ;
         sMode50 = "";
         BC00172_A60SetorInternoId = new int[1] ;
         BC00172_A75DocumentoId = new int[1] ;
         BC001710_A60SetorInternoId = new int[1] ;
         BC001710_A75DocumentoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001711_A60SetorInternoId = new int[1] ;
         BC001712_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docsetorinterno_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docsetorinterno_bc__default(),
            new Object[][] {
                new Object[] {
               BC00172_A60SetorInternoId, BC00172_A75DocumentoId
               }
               , new Object[] {
               BC00173_A60SetorInternoId, BC00173_A75DocumentoId
               }
               , new Object[] {
               BC00174_A60SetorInternoId
               }
               , new Object[] {
               BC00175_A75DocumentoId
               }
               , new Object[] {
               BC00176_A60SetorInternoId, BC00176_A75DocumentoId
               }
               , new Object[] {
               BC00177_A60SetorInternoId, BC00177_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001710_A60SetorInternoId, BC001710_A75DocumentoId
               }
               , new Object[] {
               BC001711_A60SetorInternoId
               }
               , new Object[] {
               BC001712_A75DocumentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12172 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound50 ;
      private short nIsDirty_50 ;
      private int trnEnded ;
      private int Z60SetorInternoId ;
      private int A60SetorInternoId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode50 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV13WebSession ;
      private SdtDocSetorInterno bcDocSetorInterno ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00176_A60SetorInternoId ;
      private int[] BC00176_A75DocumentoId ;
      private int[] BC00174_A60SetorInternoId ;
      private int[] BC00175_A75DocumentoId ;
      private int[] BC00177_A60SetorInternoId ;
      private int[] BC00177_A75DocumentoId ;
      private int[] BC00173_A60SetorInternoId ;
      private int[] BC00173_A75DocumentoId ;
      private int[] BC00172_A60SetorInternoId ;
      private int[] BC00172_A75DocumentoId ;
      private int[] BC001710_A60SetorInternoId ;
      private int[] BC001710_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC001711_A60SetorInternoId ;
      private int[] BC001712_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class docsetorinterno_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docsetorinterno_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00176;
        prmBC00176 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00174;
        prmBC00174 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC00175;
        prmBC00175 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00177;
        prmBC00177 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00173;
        prmBC00173 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00172;
        prmBC00172 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00178;
        prmBC00178 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00179;
        prmBC00179 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001710;
        prmBC001710 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001711;
        prmBC001711 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC001712;
        prmBC001712 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00172", "SELECT [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WITH (UPDLOCK) WHERE [SetorInternoId] = @SetorInternoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00173", "SELECT [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WHERE [SetorInternoId] = @SetorInternoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00174", "SELECT [SetorInternoId] FROM [SetorInterno] WHERE [SetorInternoId] = @SetorInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00174,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00175", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00175,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00176", "SELECT TM1.[SetorInternoId], TM1.[DocumentoId] FROM [DocSetorInterno] TM1 WHERE TM1.[SetorInternoId] = @SetorInternoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[SetorInternoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00176,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00177", "SELECT [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WHERE [SetorInternoId] = @SetorInternoId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00177,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00178", "INSERT INTO [DocSetorInterno]([SetorInternoId], [DocumentoId]) VALUES(@SetorInternoId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmBC00178)
           ,new CursorDef("BC00179", "DELETE FROM [DocSetorInterno]  WHERE [SetorInternoId] = @SetorInternoId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC00179)
           ,new CursorDef("BC001710", "SELECT TM1.[SetorInternoId], TM1.[DocumentoId] FROM [DocSetorInterno] TM1 WHERE TM1.[SetorInternoId] = @SetorInternoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[SetorInternoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001710,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001711", "SELECT [SetorInternoId] FROM [SetorInterno] WHERE [SetorInternoId] = @SetorInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001711,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001712", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001712,1, GxCacheFrequency.OFF ,true,false )
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
