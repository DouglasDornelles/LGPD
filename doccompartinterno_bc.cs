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
   public class doccompartinterno_bc : GXHttpHandler, IGxSilentTrn
   {
      public doccompartinterno_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public doccompartinterno_bc( IGxContext context )
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
         ReadRow1649( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1649( ) ;
         standaloneModal( ) ;
         AddRow1649( ) ;
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
            E11162 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z57CompartInternoId = A57CompartInternoId;
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1649( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1649( ) ;
            }
            else
            {
               CheckExtendedTable1649( ) ;
               if ( AnyError == 0 )
               {
                  ZM1649( 2) ;
                  ZM1649( 3) ;
               }
               CloseExtendedTableCursors1649( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12162( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11162( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1649( short GX_JID )
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
            Z57CompartInternoId = A57CompartInternoId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1649( )
      {
         /* Using cursor BC00166 */
         pr_default.execute(4, new Object[] {A57CompartInternoId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound49 = 1;
            ZM1649( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1649( ) ;
      }

      protected void OnLoadActions1649( )
      {
      }

      protected void CheckExtendedTable1649( )
      {
         nIsDirty_49 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00164 */
         pr_default.execute(2, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Compart Interno'.", "ForeignKeyNotFound", 1, "COMPARTINTERNOID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00165 */
         pr_default.execute(3, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1649( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1649( )
      {
         /* Using cursor BC00167 */
         pr_default.execute(5, new Object[] {A57CompartInternoId, A75DocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00163 */
         pr_default.execute(1, new Object[] {A57CompartInternoId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1649( 1) ;
            RcdFound49 = 1;
            A57CompartInternoId = BC00163_A57CompartInternoId[0];
            A75DocumentoId = BC00163_A75DocumentoId[0];
            Z57CompartInternoId = A57CompartInternoId;
            Z75DocumentoId = A75DocumentoId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1649( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1649( ) ;
            }
            Gx_mode = sMode49;
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1649( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode49;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1649( ) ;
         if ( RcdFound49 == 0 )
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
         CONFIRM_160( ) ;
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

      protected void CheckOptimisticConcurrency1649( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00162 */
            pr_default.execute(0, new Object[] {A57CompartInternoId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocCompartInterno"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocCompartInterno"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1649( )
      {
         BeforeValidate1649( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1649( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1649( 0) ;
            CheckOptimisticConcurrency1649( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1649( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1649( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00168 */
                     pr_default.execute(6, new Object[] {A57CompartInternoId, A75DocumentoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocCompartInterno");
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
               Load1649( ) ;
            }
            EndLevel1649( ) ;
         }
         CloseExtendedTableCursors1649( ) ;
      }

      protected void Update1649( )
      {
         BeforeValidate1649( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1649( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1649( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1649( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1649( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocCompartInterno] */
                     DeferredUpdate1649( ) ;
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
            EndLevel1649( ) ;
         }
         CloseExtendedTableCursors1649( ) ;
      }

      protected void DeferredUpdate1649( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1649( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1649( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1649( ) ;
            AfterConfirm1649( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1649( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00169 */
                  pr_default.execute(7, new Object[] {A57CompartInternoId, A75DocumentoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocCompartInterno");
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
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1649( ) ;
         Gx_mode = sMode49;
      }

      protected void OnDeleteControls1649( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1649( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1649( ) ;
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

      public void ScanKeyStart1649( )
      {
         /* Scan By routine */
         /* Using cursor BC001610 */
         pr_default.execute(8, new Object[] {A57CompartInternoId, A75DocumentoId});
         RcdFound49 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound49 = 1;
            A57CompartInternoId = BC001610_A57CompartInternoId[0];
            A75DocumentoId = BC001610_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1649( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound49 = 0;
         ScanKeyLoad1649( ) ;
      }

      protected void ScanKeyLoad1649( )
      {
         sMode49 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound49 = 1;
            A57CompartInternoId = BC001610_A57CompartInternoId[0];
            A75DocumentoId = BC001610_A75DocumentoId[0];
         }
         Gx_mode = sMode49;
      }

      protected void ScanKeyEnd1649( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1649( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1649( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1649( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1649( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1649( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1649( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1649( )
      {
      }

      protected void send_integrity_lvl_hashes1649( )
      {
      }

      protected void AddRow1649( )
      {
         VarsToRow49( bcDocCompartInterno) ;
      }

      protected void ReadRow1649( )
      {
         RowToVars49( bcDocCompartInterno, 1) ;
      }

      protected void InitializeNonKey1649( )
      {
      }

      protected void InitAll1649( )
      {
         A57CompartInternoId = 0;
         A75DocumentoId = 0;
         InitializeNonKey1649( ) ;
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

      public void VarsToRow49( SdtDocCompartInterno obj49 )
      {
         obj49.gxTpr_Mode = Gx_mode;
         obj49.gxTpr_Compartinternoid = A57CompartInternoId;
         obj49.gxTpr_Documentoid = A75DocumentoId;
         obj49.gxTpr_Compartinternoid_Z = Z57CompartInternoId;
         obj49.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj49.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow49( SdtDocCompartInterno obj49 )
      {
         obj49.gxTpr_Compartinternoid = A57CompartInternoId;
         obj49.gxTpr_Documentoid = A75DocumentoId;
         return  ;
      }

      public void RowToVars49( SdtDocCompartInterno obj49 ,
                               int forceLoad )
      {
         Gx_mode = obj49.gxTpr_Mode;
         A57CompartInternoId = obj49.gxTpr_Compartinternoid;
         A75DocumentoId = obj49.gxTpr_Documentoid;
         Z57CompartInternoId = obj49.gxTpr_Compartinternoid_Z;
         Z75DocumentoId = obj49.gxTpr_Documentoid_Z;
         Gx_mode = obj49.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A57CompartInternoId = (int)getParm(obj,0);
         A75DocumentoId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1649( ) ;
         ScanKeyStart1649( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001611 */
            pr_default.execute(9, new Object[] {A57CompartInternoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Compart Interno'.", "ForeignKeyNotFound", 1, "COMPARTINTERNOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001612 */
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
            Z57CompartInternoId = A57CompartInternoId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1649( -1) ;
         OnLoadActions1649( ) ;
         AddRow1649( ) ;
         ScanKeyEnd1649( ) ;
         if ( RcdFound49 == 0 )
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
         RowToVars49( bcDocCompartInterno, 0) ;
         ScanKeyStart1649( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001611 */
            pr_default.execute(9, new Object[] {A57CompartInternoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Compart Interno'.", "ForeignKeyNotFound", 1, "COMPARTINTERNOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001612 */
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
            Z57CompartInternoId = A57CompartInternoId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1649( -1) ;
         OnLoadActions1649( ) ;
         AddRow1649( ) ;
         ScanKeyEnd1649( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1649( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1649( ) ;
         }
         else
         {
            if ( RcdFound49 == 1 )
            {
               if ( ( A57CompartInternoId != Z57CompartInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A57CompartInternoId = Z57CompartInternoId;
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
                  Update1649( ) ;
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
                  if ( ( A57CompartInternoId != Z57CompartInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
                        Insert1649( ) ;
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
                        Insert1649( ) ;
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
         RowToVars49( bcDocCompartInterno, 1) ;
         SaveImpl( ) ;
         VarsToRow49( bcDocCompartInterno) ;
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
         RowToVars49( bcDocCompartInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1649( ) ;
         AfterTrn( ) ;
         VarsToRow49( bcDocCompartInterno) ;
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
            SdtDocCompartInterno auxBC = new SdtDocCompartInterno(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A57CompartInternoId, A75DocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocCompartInterno);
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
         RowToVars49( bcDocCompartInterno, 1) ;
         UpdateImpl( ) ;
         VarsToRow49( bcDocCompartInterno) ;
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
         RowToVars49( bcDocCompartInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1649( ) ;
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
         VarsToRow49( bcDocCompartInterno) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars49( bcDocCompartInterno, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1649( ) ;
         if ( RcdFound49 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A57CompartInternoId != Z57CompartInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
            {
               A57CompartInternoId = Z57CompartInternoId;
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
            if ( ( A57CompartInternoId != Z57CompartInternoId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
         context.RollbackDataStores("doccompartinterno_bc",pr_default);
         VarsToRow49( bcDocCompartInterno) ;
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
         Gx_mode = bcDocCompartInterno.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocCompartInterno.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocCompartInterno )
         {
            bcDocCompartInterno = (SdtDocCompartInterno)(sdt);
            if ( StringUtil.StrCmp(bcDocCompartInterno.gxTpr_Mode, "") == 0 )
            {
               bcDocCompartInterno.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow49( bcDocCompartInterno) ;
            }
            else
            {
               RowToVars49( bcDocCompartInterno, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocCompartInterno.gxTpr_Mode, "") == 0 )
            {
               bcDocCompartInterno.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars49( bcDocCompartInterno, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocCompartInterno DocCompartInterno_BC
      {
         get {
            return bcDocCompartInterno ;
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
            return "doccompartinterno_Execute" ;
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
         BC00166_A57CompartInternoId = new int[1] ;
         BC00166_A75DocumentoId = new int[1] ;
         BC00164_A57CompartInternoId = new int[1] ;
         BC00165_A75DocumentoId = new int[1] ;
         BC00167_A57CompartInternoId = new int[1] ;
         BC00167_A75DocumentoId = new int[1] ;
         BC00163_A57CompartInternoId = new int[1] ;
         BC00163_A75DocumentoId = new int[1] ;
         sMode49 = "";
         BC00162_A57CompartInternoId = new int[1] ;
         BC00162_A75DocumentoId = new int[1] ;
         BC001610_A57CompartInternoId = new int[1] ;
         BC001610_A75DocumentoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001611_A57CompartInternoId = new int[1] ;
         BC001612_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.doccompartinterno_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.doccompartinterno_bc__default(),
            new Object[][] {
                new Object[] {
               BC00162_A57CompartInternoId, BC00162_A75DocumentoId
               }
               , new Object[] {
               BC00163_A57CompartInternoId, BC00163_A75DocumentoId
               }
               , new Object[] {
               BC00164_A57CompartInternoId
               }
               , new Object[] {
               BC00165_A75DocumentoId
               }
               , new Object[] {
               BC00166_A57CompartInternoId, BC00166_A75DocumentoId
               }
               , new Object[] {
               BC00167_A57CompartInternoId, BC00167_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001610_A57CompartInternoId, BC001610_A75DocumentoId
               }
               , new Object[] {
               BC001611_A57CompartInternoId
               }
               , new Object[] {
               BC001612_A75DocumentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12162 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound49 ;
      private short nIsDirty_49 ;
      private int trnEnded ;
      private int Z57CompartInternoId ;
      private int A57CompartInternoId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode49 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV13WebSession ;
      private SdtDocCompartInterno bcDocCompartInterno ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00166_A57CompartInternoId ;
      private int[] BC00166_A75DocumentoId ;
      private int[] BC00164_A57CompartInternoId ;
      private int[] BC00165_A75DocumentoId ;
      private int[] BC00167_A57CompartInternoId ;
      private int[] BC00167_A75DocumentoId ;
      private int[] BC00163_A57CompartInternoId ;
      private int[] BC00163_A75DocumentoId ;
      private int[] BC00162_A57CompartInternoId ;
      private int[] BC00162_A75DocumentoId ;
      private int[] BC001610_A57CompartInternoId ;
      private int[] BC001610_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC001611_A57CompartInternoId ;
      private int[] BC001612_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class doccompartinterno_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class doccompartinterno_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00166;
        prmBC00166 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00164;
        prmBC00164 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC00165;
        prmBC00165 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00167;
        prmBC00167 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00163;
        prmBC00163 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00162;
        prmBC00162 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00168;
        prmBC00168 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00169;
        prmBC00169 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001610;
        prmBC001610 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001611;
        prmBC001611 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC001612;
        prmBC001612 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00162", "SELECT [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WITH (UPDLOCK) WHERE [CompartInternoId] = @CompartInternoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00162,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00163", "SELECT [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [CompartInternoId] = @CompartInternoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00163,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00164", "SELECT [CompartInternoId] FROM [CompartInterno] WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00164,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00165", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00165,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00166", "SELECT TM1.[CompartInternoId], TM1.[DocumentoId] FROM [DocCompartInterno] TM1 WHERE TM1.[CompartInternoId] = @CompartInternoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[CompartInternoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00166,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00167", "SELECT [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [CompartInternoId] = @CompartInternoId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00167,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00168", "INSERT INTO [DocCompartInterno]([CompartInternoId], [DocumentoId]) VALUES(@CompartInternoId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmBC00168)
           ,new CursorDef("BC00169", "DELETE FROM [DocCompartInterno]  WHERE [CompartInternoId] = @CompartInternoId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC00169)
           ,new CursorDef("BC001610", "SELECT TM1.[CompartInternoId], TM1.[DocumentoId] FROM [DocCompartInterno] TM1 WHERE TM1.[CompartInternoId] = @CompartInternoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[CompartInternoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001610,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001611", "SELECT [CompartInternoId] FROM [CompartInterno] WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001611,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001612", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001612,1, GxCacheFrequency.OFF ,true,false )
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
