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
   public class dicionariocomparttercext_bc : GXHttpHandler, IGxSilentTrn
   {
      public dicionariocomparttercext_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariocomparttercext_bc( IGxContext context )
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
         ReadRow0X54( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0X54( ) ;
         standaloneModal( ) ;
         AddRow0X54( ) ;
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
            E110X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z66CompartTercExternoId = A66CompartTercExternoId;
               Z98DocDicionarioId = A98DocDicionarioId;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X54( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X54( ) ;
            }
            else
            {
               CheckExtendedTable0X54( ) ;
               if ( AnyError == 0 )
               {
                  ZM0X54( 2) ;
                  ZM0X54( 3) ;
               }
               CloseExtendedTableCursors0X54( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0X54( short GX_JID )
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
            Z66CompartTercExternoId = A66CompartTercExternoId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0X54( )
      {
         /* Using cursor BC000X6 */
         pr_default.execute(4, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound54 = 1;
            ZM0X54( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0X54( ) ;
      }

      protected void OnLoadActions0X54( )
      {
      }

      protected void CheckExtendedTable0X54( )
      {
         nIsDirty_54 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000X4 */
         pr_default.execute(2, new Object[] {A66CompartTercExternoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Compart Terc Externo'.", "ForeignKeyNotFound", 1, "COMPARTTERCEXTERNOID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC000X5 */
         pr_default.execute(3, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0X54( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X54( )
      {
         /* Using cursor BC000X7 */
         pr_default.execute(5, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound54 = 1;
         }
         else
         {
            RcdFound54 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000X3 */
         pr_default.execute(1, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X54( 1) ;
            RcdFound54 = 1;
            A66CompartTercExternoId = BC000X3_A66CompartTercExternoId[0];
            A98DocDicionarioId = BC000X3_A98DocDicionarioId[0];
            Z66CompartTercExternoId = A66CompartTercExternoId;
            Z98DocDicionarioId = A98DocDicionarioId;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0X54( ) ;
            if ( AnyError == 1 )
            {
               RcdFound54 = 0;
               InitializeNonKey0X54( ) ;
            }
            Gx_mode = sMode54;
         }
         else
         {
            RcdFound54 = 0;
            InitializeNonKey0X54( ) ;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode54;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X54( ) ;
         if ( RcdFound54 == 0 )
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
         CONFIRM_0X0( ) ;
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

      protected void CheckOptimisticConcurrency0X54( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000X2 */
            pr_default.execute(0, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DicionarioCompartTercExt"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DicionarioCompartTercExt"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X54( )
      {
         BeforeValidate0X54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X54( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X54( 0) ;
            CheckOptimisticConcurrency0X54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X8 */
                     pr_default.execute(6, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DicionarioCompartTercExt");
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
               Load0X54( ) ;
            }
            EndLevel0X54( ) ;
         }
         CloseExtendedTableCursors0X54( ) ;
      }

      protected void Update0X54( )
      {
         BeforeValidate0X54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X54( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DicionarioCompartTercExt] */
                     DeferredUpdate0X54( ) ;
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
            EndLevel0X54( ) ;
         }
         CloseExtendedTableCursors0X54( ) ;
      }

      protected void DeferredUpdate0X54( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0X54( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X54( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X54( ) ;
            AfterConfirm0X54( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X54( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000X9 */
                  pr_default.execute(7, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DicionarioCompartTercExt");
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
         sMode54 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0X54( ) ;
         Gx_mode = sMode54;
      }

      protected void OnDeleteControls0X54( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0X54( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X54( ) ;
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

      public void ScanKeyStart0X54( )
      {
         /* Scan By routine */
         /* Using cursor BC000X10 */
         pr_default.execute(8, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
         RcdFound54 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound54 = 1;
            A66CompartTercExternoId = BC000X10_A66CompartTercExternoId[0];
            A98DocDicionarioId = BC000X10_A98DocDicionarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0X54( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound54 = 0;
         ScanKeyLoad0X54( ) ;
      }

      protected void ScanKeyLoad0X54( )
      {
         sMode54 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound54 = 1;
            A66CompartTercExternoId = BC000X10_A66CompartTercExternoId[0];
            A98DocDicionarioId = BC000X10_A98DocDicionarioId[0];
         }
         Gx_mode = sMode54;
      }

      protected void ScanKeyEnd0X54( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0X54( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X54( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X54( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X54( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X54( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X54( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X54( )
      {
      }

      protected void send_integrity_lvl_hashes0X54( )
      {
      }

      protected void AddRow0X54( )
      {
         VarsToRow54( bcDicionarioCompartTercExt) ;
      }

      protected void ReadRow0X54( )
      {
         RowToVars54( bcDicionarioCompartTercExt, 1) ;
      }

      protected void InitializeNonKey0X54( )
      {
      }

      protected void InitAll0X54( )
      {
         A66CompartTercExternoId = 0;
         A98DocDicionarioId = 0;
         InitializeNonKey0X54( ) ;
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

      public void VarsToRow54( SdtDicionarioCompartTercExt obj54 )
      {
         obj54.gxTpr_Mode = Gx_mode;
         obj54.gxTpr_Comparttercexternoid = A66CompartTercExternoId;
         obj54.gxTpr_Docdicionarioid = A98DocDicionarioId;
         obj54.gxTpr_Comparttercexternoid_Z = Z66CompartTercExternoId;
         obj54.gxTpr_Docdicionarioid_Z = Z98DocDicionarioId;
         obj54.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow54( SdtDicionarioCompartTercExt obj54 )
      {
         obj54.gxTpr_Comparttercexternoid = A66CompartTercExternoId;
         obj54.gxTpr_Docdicionarioid = A98DocDicionarioId;
         return  ;
      }

      public void RowToVars54( SdtDicionarioCompartTercExt obj54 ,
                               int forceLoad )
      {
         Gx_mode = obj54.gxTpr_Mode;
         A66CompartTercExternoId = obj54.gxTpr_Comparttercexternoid;
         A98DocDicionarioId = obj54.gxTpr_Docdicionarioid;
         Z66CompartTercExternoId = obj54.gxTpr_Comparttercexternoid_Z;
         Z98DocDicionarioId = obj54.gxTpr_Docdicionarioid_Z;
         Gx_mode = obj54.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A66CompartTercExternoId = (int)getParm(obj,0);
         A98DocDicionarioId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0X54( ) ;
         ScanKeyStart0X54( ) ;
         if ( RcdFound54 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000X11 */
            pr_default.execute(9, new Object[] {A66CompartTercExternoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Compart Terc Externo'.", "ForeignKeyNotFound", 1, "COMPARTTERCEXTERNOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000X12 */
            pr_default.execute(10, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z66CompartTercExternoId = A66CompartTercExternoId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
         ZM0X54( -1) ;
         OnLoadActions0X54( ) ;
         AddRow0X54( ) ;
         ScanKeyEnd0X54( ) ;
         if ( RcdFound54 == 0 )
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
         RowToVars54( bcDicionarioCompartTercExt, 0) ;
         ScanKeyStart0X54( ) ;
         if ( RcdFound54 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000X11 */
            pr_default.execute(9, new Object[] {A66CompartTercExternoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Compart Terc Externo'.", "ForeignKeyNotFound", 1, "COMPARTTERCEXTERNOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000X12 */
            pr_default.execute(10, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z66CompartTercExternoId = A66CompartTercExternoId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
         ZM0X54( -1) ;
         OnLoadActions0X54( ) ;
         AddRow0X54( ) ;
         ScanKeyEnd0X54( ) ;
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0X54( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0X54( ) ;
         }
         else
         {
            if ( RcdFound54 == 1 )
            {
               if ( ( A66CompartTercExternoId != Z66CompartTercExternoId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
               {
                  A66CompartTercExternoId = Z66CompartTercExternoId;
                  A98DocDicionarioId = Z98DocDicionarioId;
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
                  Update0X54( ) ;
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
                  if ( ( A66CompartTercExternoId != Z66CompartTercExternoId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
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
                        Insert0X54( ) ;
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
                        Insert0X54( ) ;
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
         RowToVars54( bcDicionarioCompartTercExt, 1) ;
         SaveImpl( ) ;
         VarsToRow54( bcDicionarioCompartTercExt) ;
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
         RowToVars54( bcDicionarioCompartTercExt, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X54( ) ;
         AfterTrn( ) ;
         VarsToRow54( bcDicionarioCompartTercExt) ;
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
            SdtDicionarioCompartTercExt auxBC = new SdtDicionarioCompartTercExt(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A66CompartTercExternoId, A98DocDicionarioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDicionarioCompartTercExt);
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
         RowToVars54( bcDicionarioCompartTercExt, 1) ;
         UpdateImpl( ) ;
         VarsToRow54( bcDicionarioCompartTercExt) ;
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
         RowToVars54( bcDicionarioCompartTercExt, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X54( ) ;
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
         VarsToRow54( bcDicionarioCompartTercExt) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars54( bcDicionarioCompartTercExt, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0X54( ) ;
         if ( RcdFound54 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A66CompartTercExternoId != Z66CompartTercExternoId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
            {
               A66CompartTercExternoId = Z66CompartTercExternoId;
               A98DocDicionarioId = Z98DocDicionarioId;
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
            if ( ( A66CompartTercExternoId != Z66CompartTercExternoId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
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
         context.RollbackDataStores("dicionariocomparttercext_bc",pr_default);
         VarsToRow54( bcDicionarioCompartTercExt) ;
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
         Gx_mode = bcDicionarioCompartTercExt.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDicionarioCompartTercExt.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDicionarioCompartTercExt )
         {
            bcDicionarioCompartTercExt = (SdtDicionarioCompartTercExt)(sdt);
            if ( StringUtil.StrCmp(bcDicionarioCompartTercExt.gxTpr_Mode, "") == 0 )
            {
               bcDicionarioCompartTercExt.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow54( bcDicionarioCompartTercExt) ;
            }
            else
            {
               RowToVars54( bcDicionarioCompartTercExt, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDicionarioCompartTercExt.gxTpr_Mode, "") == 0 )
            {
               bcDicionarioCompartTercExt.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars54( bcDicionarioCompartTercExt, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDicionarioCompartTercExt DicionarioCompartTercExt_BC
      {
         get {
            return bcDicionarioCompartTercExt ;
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
            return "dicionariocomparttercext_Execute" ;
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
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         BC000X6_A66CompartTercExternoId = new int[1] ;
         BC000X6_A98DocDicionarioId = new int[1] ;
         BC000X4_A66CompartTercExternoId = new int[1] ;
         BC000X5_A98DocDicionarioId = new int[1] ;
         BC000X7_A66CompartTercExternoId = new int[1] ;
         BC000X7_A98DocDicionarioId = new int[1] ;
         BC000X3_A66CompartTercExternoId = new int[1] ;
         BC000X3_A98DocDicionarioId = new int[1] ;
         sMode54 = "";
         BC000X2_A66CompartTercExternoId = new int[1] ;
         BC000X2_A98DocDicionarioId = new int[1] ;
         BC000X10_A66CompartTercExternoId = new int[1] ;
         BC000X10_A98DocDicionarioId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000X11_A66CompartTercExternoId = new int[1] ;
         BC000X12_A98DocDicionarioId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.dicionariocomparttercext_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariocomparttercext_bc__default(),
            new Object[][] {
                new Object[] {
               BC000X2_A66CompartTercExternoId, BC000X2_A98DocDicionarioId
               }
               , new Object[] {
               BC000X3_A66CompartTercExternoId, BC000X3_A98DocDicionarioId
               }
               , new Object[] {
               BC000X4_A66CompartTercExternoId
               }
               , new Object[] {
               BC000X5_A98DocDicionarioId
               }
               , new Object[] {
               BC000X6_A66CompartTercExternoId, BC000X6_A98DocDicionarioId
               }
               , new Object[] {
               BC000X7_A66CompartTercExternoId, BC000X7_A98DocDicionarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000X10_A66CompartTercExternoId, BC000X10_A98DocDicionarioId
               }
               , new Object[] {
               BC000X11_A66CompartTercExternoId
               }
               , new Object[] {
               BC000X12_A98DocDicionarioId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120X2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound54 ;
      private short nIsDirty_54 ;
      private int trnEnded ;
      private int Z66CompartTercExternoId ;
      private int A66CompartTercExternoId ;
      private int Z98DocDicionarioId ;
      private int A98DocDicionarioId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode54 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV14WebSession ;
      private SdtDicionarioCompartTercExt bcDicionarioCompartTercExt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000X6_A66CompartTercExternoId ;
      private int[] BC000X6_A98DocDicionarioId ;
      private int[] BC000X4_A66CompartTercExternoId ;
      private int[] BC000X5_A98DocDicionarioId ;
      private int[] BC000X7_A66CompartTercExternoId ;
      private int[] BC000X7_A98DocDicionarioId ;
      private int[] BC000X3_A66CompartTercExternoId ;
      private int[] BC000X3_A98DocDicionarioId ;
      private int[] BC000X2_A66CompartTercExternoId ;
      private int[] BC000X2_A98DocDicionarioId ;
      private int[] BC000X10_A66CompartTercExternoId ;
      private int[] BC000X10_A98DocDicionarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC000X11_A66CompartTercExternoId ;
      private int[] BC000X12_A98DocDicionarioId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
   }

   public class dicionariocomparttercext_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class dicionariocomparttercext_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000X6;
        prmBC000X6 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X4;
        prmBC000X4 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000X5;
        prmBC000X5 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X7;
        prmBC000X7 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X3;
        prmBC000X3 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X2;
        prmBC000X2 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X8;
        prmBC000X8 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X9;
        prmBC000X9 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X10;
        prmBC000X10 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000X11;
        prmBC000X11 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000X12;
        prmBC000X12 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000X2", "SELECT [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WITH (UPDLOCK) WHERE [CompartTercExternoId] = @CompartTercExternoId AND [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X3", "SELECT [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [CompartTercExternoId] = @CompartTercExternoId AND [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X4", "SELECT [CompartTercExternoId] FROM [CompartTercExterno] WHERE [CompartTercExternoId] = @CompartTercExternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X5", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X6", "SELECT TM1.[CompartTercExternoId], TM1.[DocDicionarioId] FROM [DicionarioCompartTercExt] TM1 WHERE TM1.[CompartTercExternoId] = @CompartTercExternoId and TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[CompartTercExternoId], TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X7", "SELECT [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [CompartTercExternoId] = @CompartTercExternoId AND [DocDicionarioId] = @DocDicionarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X8", "INSERT INTO [DicionarioCompartTercExt]([CompartTercExternoId], [DocDicionarioId]) VALUES(@CompartTercExternoId, @DocDicionarioId)", GxErrorMask.GX_NOMASK,prmBC000X8)
           ,new CursorDef("BC000X9", "DELETE FROM [DicionarioCompartTercExt]  WHERE [CompartTercExternoId] = @CompartTercExternoId AND [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmBC000X9)
           ,new CursorDef("BC000X10", "SELECT TM1.[CompartTercExternoId], TM1.[DocDicionarioId] FROM [DicionarioCompartTercExt] TM1 WHERE TM1.[CompartTercExternoId] = @CompartTercExternoId and TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[CompartTercExternoId], TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X11", "SELECT [CompartTercExternoId] FROM [CompartTercExterno] WHERE [CompartTercExternoId] = @CompartTercExternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X12", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X12,1, GxCacheFrequency.OFF ,true,false )
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
