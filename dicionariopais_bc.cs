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
   public class dicionariopais_bc : GXHttpHandler, IGxSilentTrn
   {
      public dicionariopais_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariopais_bc( IGxContext context )
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
         ReadRow1H60( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1H60( ) ;
         standaloneModal( ) ;
         AddRow1H60( ) ;
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
            E111H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z4PaisId = A4PaisId;
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

      protected void CONFIRM_1H0( )
      {
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1H60( ) ;
            }
            else
            {
               CheckExtendedTable1H60( ) ;
               if ( AnyError == 0 )
               {
                  ZM1H60( 2) ;
                  ZM1H60( 3) ;
               }
               CloseExtendedTableCursors1H60( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E121H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1H60( short GX_JID )
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
            Z4PaisId = A4PaisId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1H60( )
      {
         /* Using cursor BC001H6 */
         pr_default.execute(4, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound60 = 1;
            ZM1H60( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1H60( ) ;
      }

      protected void OnLoadActions1H60( )
      {
      }

      protected void CheckExtendedTable1H60( )
      {
         nIsDirty_60 = 0;
         standaloneModal( ) ;
         /* Using cursor BC001H4 */
         pr_default.execute(2, new Object[] {A4PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001H5 */
         pr_default.execute(3, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1H60( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1H60( )
      {
         /* Using cursor BC001H7 */
         pr_default.execute(5, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound60 = 1;
         }
         else
         {
            RcdFound60 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001H3 */
         pr_default.execute(1, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1H60( 1) ;
            RcdFound60 = 1;
            A4PaisId = BC001H3_A4PaisId[0];
            A98DocDicionarioId = BC001H3_A98DocDicionarioId[0];
            Z4PaisId = A4PaisId;
            Z98DocDicionarioId = A98DocDicionarioId;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1H60( ) ;
            if ( AnyError == 1 )
            {
               RcdFound60 = 0;
               InitializeNonKey1H60( ) ;
            }
            Gx_mode = sMode60;
         }
         else
         {
            RcdFound60 = 0;
            InitializeNonKey1H60( ) ;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode60;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H60( ) ;
         if ( RcdFound60 == 0 )
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
         CONFIRM_1H0( ) ;
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

      protected void CheckOptimisticConcurrency1H60( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001H2 */
            pr_default.execute(0, new Object[] {A4PaisId, A98DocDicionarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DicionarioPais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DicionarioPais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H60( )
      {
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H60( 0) ;
            CheckOptimisticConcurrency1H60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001H8 */
                     pr_default.execute(6, new Object[] {A4PaisId, A98DocDicionarioId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DicionarioPais");
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
               Load1H60( ) ;
            }
            EndLevel1H60( ) ;
         }
         CloseExtendedTableCursors1H60( ) ;
      }

      protected void Update1H60( )
      {
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DicionarioPais] */
                     DeferredUpdate1H60( ) ;
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
            EndLevel1H60( ) ;
         }
         CloseExtendedTableCursors1H60( ) ;
      }

      protected void DeferredUpdate1H60( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H60( ) ;
            AfterConfirm1H60( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H60( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001H9 */
                  pr_default.execute(7, new Object[] {A4PaisId, A98DocDicionarioId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DicionarioPais");
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
         sMode60 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1H60( ) ;
         Gx_mode = sMode60;
      }

      protected void OnDeleteControls1H60( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1H60( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H60( ) ;
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

      public void ScanKeyStart1H60( )
      {
         /* Scan By routine */
         /* Using cursor BC001H10 */
         pr_default.execute(8, new Object[] {A4PaisId, A98DocDicionarioId});
         RcdFound60 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound60 = 1;
            A4PaisId = BC001H10_A4PaisId[0];
            A98DocDicionarioId = BC001H10_A98DocDicionarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1H60( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound60 = 0;
         ScanKeyLoad1H60( ) ;
      }

      protected void ScanKeyLoad1H60( )
      {
         sMode60 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound60 = 1;
            A4PaisId = BC001H10_A4PaisId[0];
            A98DocDicionarioId = BC001H10_A98DocDicionarioId[0];
         }
         Gx_mode = sMode60;
      }

      protected void ScanKeyEnd1H60( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1H60( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H60( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H60( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H60( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H60( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H60( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H60( )
      {
      }

      protected void send_integrity_lvl_hashes1H60( )
      {
      }

      protected void AddRow1H60( )
      {
         VarsToRow60( bcDicionarioPais) ;
      }

      protected void ReadRow1H60( )
      {
         RowToVars60( bcDicionarioPais, 1) ;
      }

      protected void InitializeNonKey1H60( )
      {
      }

      protected void InitAll1H60( )
      {
         A4PaisId = 0;
         A98DocDicionarioId = 0;
         InitializeNonKey1H60( ) ;
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

      public void VarsToRow60( SdtDicionarioPais obj60 )
      {
         obj60.gxTpr_Mode = Gx_mode;
         obj60.gxTpr_Paisid = A4PaisId;
         obj60.gxTpr_Docdicionarioid = A98DocDicionarioId;
         obj60.gxTpr_Paisid_Z = Z4PaisId;
         obj60.gxTpr_Docdicionarioid_Z = Z98DocDicionarioId;
         obj60.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow60( SdtDicionarioPais obj60 )
      {
         obj60.gxTpr_Paisid = A4PaisId;
         obj60.gxTpr_Docdicionarioid = A98DocDicionarioId;
         return  ;
      }

      public void RowToVars60( SdtDicionarioPais obj60 ,
                               int forceLoad )
      {
         Gx_mode = obj60.gxTpr_Mode;
         A4PaisId = obj60.gxTpr_Paisid;
         A98DocDicionarioId = obj60.gxTpr_Docdicionarioid;
         Z4PaisId = obj60.gxTpr_Paisid_Z;
         Z98DocDicionarioId = obj60.gxTpr_Docdicionarioid_Z;
         Gx_mode = obj60.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4PaisId = (int)getParm(obj,0);
         A98DocDicionarioId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1H60( ) ;
         ScanKeyStart1H60( ) ;
         if ( RcdFound60 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001H11 */
            pr_default.execute(9, new Object[] {A4PaisId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001H12 */
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
            Z4PaisId = A4PaisId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
         ZM1H60( -1) ;
         OnLoadActions1H60( ) ;
         AddRow1H60( ) ;
         ScanKeyEnd1H60( ) ;
         if ( RcdFound60 == 0 )
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
         RowToVars60( bcDicionarioPais, 0) ;
         ScanKeyStart1H60( ) ;
         if ( RcdFound60 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001H11 */
            pr_default.execute(9, new Object[] {A4PaisId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001H12 */
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
            Z4PaisId = A4PaisId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
         ZM1H60( -1) ;
         OnLoadActions1H60( ) ;
         AddRow1H60( ) ;
         ScanKeyEnd1H60( ) ;
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1H60( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1H60( ) ;
         }
         else
         {
            if ( RcdFound60 == 1 )
            {
               if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
               {
                  A4PaisId = Z4PaisId;
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
                  Update1H60( ) ;
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
                  if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
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
                        Insert1H60( ) ;
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
                        Insert1H60( ) ;
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
         RowToVars60( bcDicionarioPais, 1) ;
         SaveImpl( ) ;
         VarsToRow60( bcDicionarioPais) ;
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
         RowToVars60( bcDicionarioPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1H60( ) ;
         AfterTrn( ) ;
         VarsToRow60( bcDicionarioPais) ;
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
            SdtDicionarioPais auxBC = new SdtDicionarioPais(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4PaisId, A98DocDicionarioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDicionarioPais);
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
         RowToVars60( bcDicionarioPais, 1) ;
         UpdateImpl( ) ;
         VarsToRow60( bcDicionarioPais) ;
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
         RowToVars60( bcDicionarioPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1H60( ) ;
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
         VarsToRow60( bcDicionarioPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars60( bcDicionarioPais, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1H60( ) ;
         if ( RcdFound60 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
            {
               A4PaisId = Z4PaisId;
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
            if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
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
         context.RollbackDataStores("dicionariopais_bc",pr_default);
         VarsToRow60( bcDicionarioPais) ;
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
         Gx_mode = bcDicionarioPais.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDicionarioPais.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDicionarioPais )
         {
            bcDicionarioPais = (SdtDicionarioPais)(sdt);
            if ( StringUtil.StrCmp(bcDicionarioPais.gxTpr_Mode, "") == 0 )
            {
               bcDicionarioPais.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow60( bcDicionarioPais) ;
            }
            else
            {
               RowToVars60( bcDicionarioPais, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDicionarioPais.gxTpr_Mode, "") == 0 )
            {
               bcDicionarioPais.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars60( bcDicionarioPais, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDicionarioPais DicionarioPais_BC
      {
         get {
            return bcDicionarioPais ;
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
            return "dicionariopais_Execute" ;
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
         BC001H6_A4PaisId = new int[1] ;
         BC001H6_A98DocDicionarioId = new int[1] ;
         BC001H4_A4PaisId = new int[1] ;
         BC001H5_A98DocDicionarioId = new int[1] ;
         BC001H7_A4PaisId = new int[1] ;
         BC001H7_A98DocDicionarioId = new int[1] ;
         BC001H3_A4PaisId = new int[1] ;
         BC001H3_A98DocDicionarioId = new int[1] ;
         sMode60 = "";
         BC001H2_A4PaisId = new int[1] ;
         BC001H2_A98DocDicionarioId = new int[1] ;
         BC001H10_A4PaisId = new int[1] ;
         BC001H10_A98DocDicionarioId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001H11_A4PaisId = new int[1] ;
         BC001H12_A98DocDicionarioId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.dicionariopais_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariopais_bc__default(),
            new Object[][] {
                new Object[] {
               BC001H2_A4PaisId, BC001H2_A98DocDicionarioId
               }
               , new Object[] {
               BC001H3_A4PaisId, BC001H3_A98DocDicionarioId
               }
               , new Object[] {
               BC001H4_A4PaisId
               }
               , new Object[] {
               BC001H5_A98DocDicionarioId
               }
               , new Object[] {
               BC001H6_A4PaisId, BC001H6_A98DocDicionarioId
               }
               , new Object[] {
               BC001H7_A4PaisId, BC001H7_A98DocDicionarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001H10_A4PaisId, BC001H10_A98DocDicionarioId
               }
               , new Object[] {
               BC001H11_A4PaisId
               }
               , new Object[] {
               BC001H12_A98DocDicionarioId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121H2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound60 ;
      private short nIsDirty_60 ;
      private int trnEnded ;
      private int Z4PaisId ;
      private int A4PaisId ;
      private int Z98DocDicionarioId ;
      private int A98DocDicionarioId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode60 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV13WebSession ;
      private SdtDicionarioPais bcDicionarioPais ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001H6_A4PaisId ;
      private int[] BC001H6_A98DocDicionarioId ;
      private int[] BC001H4_A4PaisId ;
      private int[] BC001H5_A98DocDicionarioId ;
      private int[] BC001H7_A4PaisId ;
      private int[] BC001H7_A98DocDicionarioId ;
      private int[] BC001H3_A4PaisId ;
      private int[] BC001H3_A98DocDicionarioId ;
      private int[] BC001H2_A4PaisId ;
      private int[] BC001H2_A98DocDicionarioId ;
      private int[] BC001H10_A4PaisId ;
      private int[] BC001H10_A98DocDicionarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC001H11_A4PaisId ;
      private int[] BC001H12_A98DocDicionarioId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class dicionariopais_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class dicionariopais_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC001H6;
        prmBC001H6 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H4;
        prmBC001H4 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0)
        };
        Object[] prmBC001H5;
        prmBC001H5 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H7;
        prmBC001H7 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H3;
        prmBC001H3 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H2;
        prmBC001H2 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H8;
        prmBC001H8 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H9;
        prmBC001H9 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H10;
        prmBC001H10 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC001H11;
        prmBC001H11 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0)
        };
        Object[] prmBC001H12;
        prmBC001H12 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001H2", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WITH (UPDLOCK) WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H3", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H4", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H5", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H6", "SELECT TM1.[PaisId], TM1.[DocDicionarioId] FROM [DicionarioPais] TM1 WHERE TM1.[PaisId] = @PaisId and TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[PaisId], TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H7", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H8", "INSERT INTO [DicionarioPais]([PaisId], [DocDicionarioId]) VALUES(@PaisId, @DocDicionarioId)", GxErrorMask.GX_NOMASK,prmBC001H8)
           ,new CursorDef("BC001H9", "DELETE FROM [DicionarioPais]  WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmBC001H9)
           ,new CursorDef("BC001H10", "SELECT TM1.[PaisId], TM1.[DocDicionarioId] FROM [DicionarioPais] TM1 WHERE TM1.[PaisId] = @PaisId and TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[PaisId], TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H11", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001H12", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H12,1, GxCacheFrequency.OFF ,true,false )
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
