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
   public class docfonteretencao_bc : GXHttpHandler, IGxSilentTrn
   {
      public docfonteretencao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docfonteretencao_bc( IGxContext context )
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
         ReadRow1851( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1851( ) ;
         standaloneModal( ) ;
         AddRow1851( ) ;
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
            E11182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z63FonteRetencaoId = A63FonteRetencaoId;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1851( ) ;
            }
            else
            {
               CheckExtendedTable1851( ) ;
               if ( AnyError == 0 )
               {
                  ZM1851( 2) ;
                  ZM1851( 3) ;
               }
               CloseExtendedTableCursors1851( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12182( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11182( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1851( short GX_JID )
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
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1851( )
      {
         /* Using cursor BC00186 */
         pr_default.execute(4, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound51 = 1;
            ZM1851( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1851( ) ;
      }

      protected void OnLoadActions1851( )
      {
      }

      protected void CheckExtendedTable1851( )
      {
         nIsDirty_51 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00184 */
         pr_default.execute(2, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Fonte Retencao'.", "ForeignKeyNotFound", 1, "FONTERETENCAOID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00185 */
         pr_default.execute(3, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1851( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1851( )
      {
         /* Using cursor BC00187 */
         pr_default.execute(5, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00183 */
         pr_default.execute(1, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1851( 1) ;
            RcdFound51 = 1;
            A63FonteRetencaoId = BC00183_A63FonteRetencaoId[0];
            A75DocumentoId = BC00183_A75DocumentoId[0];
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z75DocumentoId = A75DocumentoId;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1851( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey1851( ) ;
            }
            Gx_mode = sMode51;
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey1851( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode51;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1851( ) ;
         if ( RcdFound51 == 0 )
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
         CONFIRM_180( ) ;
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

      protected void CheckOptimisticConcurrency1851( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00182 */
            pr_default.execute(0, new Object[] {A63FonteRetencaoId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocFonteRetencao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocFonteRetencao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1851( )
      {
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1851( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1851( 0) ;
            CheckOptimisticConcurrency1851( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1851( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1851( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00188 */
                     pr_default.execute(6, new Object[] {A63FonteRetencaoId, A75DocumentoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocFonteRetencao");
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
               Load1851( ) ;
            }
            EndLevel1851( ) ;
         }
         CloseExtendedTableCursors1851( ) ;
      }

      protected void Update1851( )
      {
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1851( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1851( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1851( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1851( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocFonteRetencao] */
                     DeferredUpdate1851( ) ;
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
            EndLevel1851( ) ;
         }
         CloseExtendedTableCursors1851( ) ;
      }

      protected void DeferredUpdate1851( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1851( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1851( ) ;
            AfterConfirm1851( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1851( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00189 */
                  pr_default.execute(7, new Object[] {A63FonteRetencaoId, A75DocumentoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocFonteRetencao");
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
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1851( ) ;
         Gx_mode = sMode51;
      }

      protected void OnDeleteControls1851( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1851( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1851( ) ;
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

      public void ScanKeyStart1851( )
      {
         /* Scan By routine */
         /* Using cursor BC001810 */
         pr_default.execute(8, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         RcdFound51 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound51 = 1;
            A63FonteRetencaoId = BC001810_A63FonteRetencaoId[0];
            A75DocumentoId = BC001810_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1851( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound51 = 0;
         ScanKeyLoad1851( ) ;
      }

      protected void ScanKeyLoad1851( )
      {
         sMode51 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound51 = 1;
            A63FonteRetencaoId = BC001810_A63FonteRetencaoId[0];
            A75DocumentoId = BC001810_A75DocumentoId[0];
         }
         Gx_mode = sMode51;
      }

      protected void ScanKeyEnd1851( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1851( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1851( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1851( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1851( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1851( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1851( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1851( )
      {
      }

      protected void send_integrity_lvl_hashes1851( )
      {
      }

      protected void AddRow1851( )
      {
         VarsToRow51( bcDocFonteRetencao) ;
      }

      protected void ReadRow1851( )
      {
         RowToVars51( bcDocFonteRetencao, 1) ;
      }

      protected void InitializeNonKey1851( )
      {
      }

      protected void InitAll1851( )
      {
         A63FonteRetencaoId = 0;
         A75DocumentoId = 0;
         InitializeNonKey1851( ) ;
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

      public void VarsToRow51( SdtDocFonteRetencao obj51 )
      {
         obj51.gxTpr_Mode = Gx_mode;
         obj51.gxTpr_Fonteretencaoid = A63FonteRetencaoId;
         obj51.gxTpr_Documentoid = A75DocumentoId;
         obj51.gxTpr_Fonteretencaoid_Z = Z63FonteRetencaoId;
         obj51.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj51.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow51( SdtDocFonteRetencao obj51 )
      {
         obj51.gxTpr_Fonteretencaoid = A63FonteRetencaoId;
         obj51.gxTpr_Documentoid = A75DocumentoId;
         return  ;
      }

      public void RowToVars51( SdtDocFonteRetencao obj51 ,
                               int forceLoad )
      {
         Gx_mode = obj51.gxTpr_Mode;
         A63FonteRetencaoId = obj51.gxTpr_Fonteretencaoid;
         A75DocumentoId = obj51.gxTpr_Documentoid;
         Z63FonteRetencaoId = obj51.gxTpr_Fonteretencaoid_Z;
         Z75DocumentoId = obj51.gxTpr_Documentoid_Z;
         Gx_mode = obj51.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A63FonteRetencaoId = (int)getParm(obj,0);
         A75DocumentoId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1851( ) ;
         ScanKeyStart1851( ) ;
         if ( RcdFound51 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001811 */
            pr_default.execute(9, new Object[] {A63FonteRetencaoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Fonte Retencao'.", "ForeignKeyNotFound", 1, "FONTERETENCAOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001812 */
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
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1851( -1) ;
         OnLoadActions1851( ) ;
         AddRow1851( ) ;
         ScanKeyEnd1851( ) ;
         if ( RcdFound51 == 0 )
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
         RowToVars51( bcDocFonteRetencao, 0) ;
         ScanKeyStart1851( ) ;
         if ( RcdFound51 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001811 */
            pr_default.execute(9, new Object[] {A63FonteRetencaoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Fonte Retencao'.", "ForeignKeyNotFound", 1, "FONTERETENCAOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001812 */
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
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1851( -1) ;
         OnLoadActions1851( ) ;
         AddRow1851( ) ;
         ScanKeyEnd1851( ) ;
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1851( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1851( ) ;
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A63FonteRetencaoId = Z63FonteRetencaoId;
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
                  Update1851( ) ;
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
                  if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
                        Insert1851( ) ;
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
                        Insert1851( ) ;
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
         RowToVars51( bcDocFonteRetencao, 1) ;
         SaveImpl( ) ;
         VarsToRow51( bcDocFonteRetencao) ;
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
         RowToVars51( bcDocFonteRetencao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1851( ) ;
         AfterTrn( ) ;
         VarsToRow51( bcDocFonteRetencao) ;
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
            SdtDocFonteRetencao auxBC = new SdtDocFonteRetencao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A63FonteRetencaoId, A75DocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocFonteRetencao);
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
         RowToVars51( bcDocFonteRetencao, 1) ;
         UpdateImpl( ) ;
         VarsToRow51( bcDocFonteRetencao) ;
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
         RowToVars51( bcDocFonteRetencao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1851( ) ;
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
         VarsToRow51( bcDocFonteRetencao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars51( bcDocFonteRetencao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1851( ) ;
         if ( RcdFound51 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
            {
               A63FonteRetencaoId = Z63FonteRetencaoId;
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
            if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
         context.RollbackDataStores("docfonteretencao_bc",pr_default);
         VarsToRow51( bcDocFonteRetencao) ;
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
         Gx_mode = bcDocFonteRetencao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocFonteRetencao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocFonteRetencao )
         {
            bcDocFonteRetencao = (SdtDocFonteRetencao)(sdt);
            if ( StringUtil.StrCmp(bcDocFonteRetencao.gxTpr_Mode, "") == 0 )
            {
               bcDocFonteRetencao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow51( bcDocFonteRetencao) ;
            }
            else
            {
               RowToVars51( bcDocFonteRetencao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocFonteRetencao.gxTpr_Mode, "") == 0 )
            {
               bcDocFonteRetencao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars51( bcDocFonteRetencao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocFonteRetencao DocFonteRetencao_BC
      {
         get {
            return bcDocFonteRetencao ;
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
            return "docfonteretencao_Execute" ;
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
         BC00186_A63FonteRetencaoId = new int[1] ;
         BC00186_A75DocumentoId = new int[1] ;
         BC00184_A63FonteRetencaoId = new int[1] ;
         BC00185_A75DocumentoId = new int[1] ;
         BC00187_A63FonteRetencaoId = new int[1] ;
         BC00187_A75DocumentoId = new int[1] ;
         BC00183_A63FonteRetencaoId = new int[1] ;
         BC00183_A75DocumentoId = new int[1] ;
         sMode51 = "";
         BC00182_A63FonteRetencaoId = new int[1] ;
         BC00182_A75DocumentoId = new int[1] ;
         BC001810_A63FonteRetencaoId = new int[1] ;
         BC001810_A75DocumentoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001811_A63FonteRetencaoId = new int[1] ;
         BC001812_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docfonteretencao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docfonteretencao_bc__default(),
            new Object[][] {
                new Object[] {
               BC00182_A63FonteRetencaoId, BC00182_A75DocumentoId
               }
               , new Object[] {
               BC00183_A63FonteRetencaoId, BC00183_A75DocumentoId
               }
               , new Object[] {
               BC00184_A63FonteRetencaoId
               }
               , new Object[] {
               BC00185_A75DocumentoId
               }
               , new Object[] {
               BC00186_A63FonteRetencaoId, BC00186_A75DocumentoId
               }
               , new Object[] {
               BC00187_A63FonteRetencaoId, BC00187_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001810_A63FonteRetencaoId, BC001810_A75DocumentoId
               }
               , new Object[] {
               BC001811_A63FonteRetencaoId
               }
               , new Object[] {
               BC001812_A75DocumentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12182 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound51 ;
      private short nIsDirty_51 ;
      private int trnEnded ;
      private int Z63FonteRetencaoId ;
      private int A63FonteRetencaoId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode51 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV13WebSession ;
      private SdtDocFonteRetencao bcDocFonteRetencao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00186_A63FonteRetencaoId ;
      private int[] BC00186_A75DocumentoId ;
      private int[] BC00184_A63FonteRetencaoId ;
      private int[] BC00185_A75DocumentoId ;
      private int[] BC00187_A63FonteRetencaoId ;
      private int[] BC00187_A75DocumentoId ;
      private int[] BC00183_A63FonteRetencaoId ;
      private int[] BC00183_A75DocumentoId ;
      private int[] BC00182_A63FonteRetencaoId ;
      private int[] BC00182_A75DocumentoId ;
      private int[] BC001810_A63FonteRetencaoId ;
      private int[] BC001810_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC001811_A63FonteRetencaoId ;
      private int[] BC001812_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class docfonteretencao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docfonteretencao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00186;
        prmBC00186 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00184;
        prmBC00184 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC00185;
        prmBC00185 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00187;
        prmBC00187 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00183;
        prmBC00183 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00182;
        prmBC00182 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00188;
        prmBC00188 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00189;
        prmBC00189 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001810;
        prmBC001810 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001811;
        prmBC001811 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC001812;
        prmBC001812 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00182", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WITH (UPDLOCK) WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00183", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00184", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00184,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00185", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00185,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00186", "SELECT TM1.[FonteRetencaoId], TM1.[DocumentoId] FROM [DocFonteRetencao] TM1 WHERE TM1.[FonteRetencaoId] = @FonteRetencaoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[FonteRetencaoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00186,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00187", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00187,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00188", "INSERT INTO [DocFonteRetencao]([FonteRetencaoId], [DocumentoId]) VALUES(@FonteRetencaoId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmBC00188)
           ,new CursorDef("BC00189", "DELETE FROM [DocFonteRetencao]  WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC00189)
           ,new CursorDef("BC001810", "SELECT TM1.[FonteRetencaoId], TM1.[DocumentoId] FROM [DocFonteRetencao] TM1 WHERE TM1.[FonteRetencaoId] = @FonteRetencaoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[FonteRetencaoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001810,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001811", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001811,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001812", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001812,1, GxCacheFrequency.OFF ,true,false )
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
