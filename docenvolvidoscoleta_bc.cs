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
   public class docenvolvidoscoleta_bc : GXHttpHandler, IGxSilentTrn
   {
      public docenvolvidoscoleta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docenvolvidoscoleta_bc( IGxContext context )
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
         ReadRow1548( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1548( ) ;
         standaloneModal( ) ;
         AddRow1548( ) ;
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
            E11152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1548( ) ;
            }
            else
            {
               CheckExtendedTable1548( ) ;
               if ( AnyError == 0 )
               {
                  ZM1548( 2) ;
                  ZM1548( 3) ;
               }
               CloseExtendedTableCursors1548( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12152( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11152( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1548( short GX_JID )
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
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1548( )
      {
         /* Using cursor BC00156 */
         pr_default.execute(4, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound48 = 1;
            ZM1548( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1548( ) ;
      }

      protected void OnLoadActions1548( )
      {
      }

      protected void CheckExtendedTable1548( )
      {
         nIsDirty_48 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00154 */
         pr_default.execute(2, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Envolvidos Coleta'.", "ForeignKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00155 */
         pr_default.execute(3, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1548( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1548( )
      {
         /* Using cursor BC00157 */
         pr_default.execute(5, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00153 */
         pr_default.execute(1, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1548( 1) ;
            RcdFound48 = 1;
            A54EnvolvidosColetaId = BC00153_A54EnvolvidosColetaId[0];
            A75DocumentoId = BC00153_A75DocumentoId[0];
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z75DocumentoId = A75DocumentoId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1548( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey1548( ) ;
            }
            Gx_mode = sMode48;
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey1548( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode48;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1548( ) ;
         if ( RcdFound48 == 0 )
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
         CONFIRM_150( ) ;
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

      protected void CheckOptimisticConcurrency1548( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00152 */
            pr_default.execute(0, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocEnvolvidosColeta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocEnvolvidosColeta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1548( )
      {
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1548( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1548( 0) ;
            CheckOptimisticConcurrency1548( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1548( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1548( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00158 */
                     pr_default.execute(6, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocEnvolvidosColeta");
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
               Load1548( ) ;
            }
            EndLevel1548( ) ;
         }
         CloseExtendedTableCursors1548( ) ;
      }

      protected void Update1548( )
      {
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1548( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1548( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1548( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1548( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocEnvolvidosColeta] */
                     DeferredUpdate1548( ) ;
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
            EndLevel1548( ) ;
         }
         CloseExtendedTableCursors1548( ) ;
      }

      protected void DeferredUpdate1548( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1548( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1548( ) ;
            AfterConfirm1548( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1548( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00159 */
                  pr_default.execute(7, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocEnvolvidosColeta");
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1548( ) ;
         Gx_mode = sMode48;
      }

      protected void OnDeleteControls1548( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1548( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1548( ) ;
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

      public void ScanKeyStart1548( )
      {
         /* Scan By routine */
         /* Using cursor BC001510 */
         pr_default.execute(8, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         RcdFound48 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound48 = 1;
            A54EnvolvidosColetaId = BC001510_A54EnvolvidosColetaId[0];
            A75DocumentoId = BC001510_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1548( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound48 = 0;
         ScanKeyLoad1548( ) ;
      }

      protected void ScanKeyLoad1548( )
      {
         sMode48 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound48 = 1;
            A54EnvolvidosColetaId = BC001510_A54EnvolvidosColetaId[0];
            A75DocumentoId = BC001510_A75DocumentoId[0];
         }
         Gx_mode = sMode48;
      }

      protected void ScanKeyEnd1548( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1548( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1548( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1548( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1548( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1548( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1548( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1548( )
      {
      }

      protected void send_integrity_lvl_hashes1548( )
      {
      }

      protected void AddRow1548( )
      {
         VarsToRow48( bcDocEnvolvidosColeta) ;
      }

      protected void ReadRow1548( )
      {
         RowToVars48( bcDocEnvolvidosColeta, 1) ;
      }

      protected void InitializeNonKey1548( )
      {
      }

      protected void InitAll1548( )
      {
         A54EnvolvidosColetaId = 0;
         A75DocumentoId = 0;
         InitializeNonKey1548( ) ;
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

      public void VarsToRow48( SdtDocEnvolvidosColeta obj48 )
      {
         obj48.gxTpr_Mode = Gx_mode;
         obj48.gxTpr_Envolvidoscoletaid = A54EnvolvidosColetaId;
         obj48.gxTpr_Documentoid = A75DocumentoId;
         obj48.gxTpr_Envolvidoscoletaid_Z = Z54EnvolvidosColetaId;
         obj48.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj48.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow48( SdtDocEnvolvidosColeta obj48 )
      {
         obj48.gxTpr_Envolvidoscoletaid = A54EnvolvidosColetaId;
         obj48.gxTpr_Documentoid = A75DocumentoId;
         return  ;
      }

      public void RowToVars48( SdtDocEnvolvidosColeta obj48 ,
                               int forceLoad )
      {
         Gx_mode = obj48.gxTpr_Mode;
         A54EnvolvidosColetaId = obj48.gxTpr_Envolvidoscoletaid;
         A75DocumentoId = obj48.gxTpr_Documentoid;
         Z54EnvolvidosColetaId = obj48.gxTpr_Envolvidoscoletaid_Z;
         Z75DocumentoId = obj48.gxTpr_Documentoid_Z;
         Gx_mode = obj48.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A54EnvolvidosColetaId = (int)getParm(obj,0);
         A75DocumentoId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1548( ) ;
         ScanKeyStart1548( ) ;
         if ( RcdFound48 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001511 */
            pr_default.execute(9, new Object[] {A54EnvolvidosColetaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Envolvidos Coleta'.", "ForeignKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001512 */
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
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1548( -1) ;
         OnLoadActions1548( ) ;
         AddRow1548( ) ;
         ScanKeyEnd1548( ) ;
         if ( RcdFound48 == 0 )
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
         RowToVars48( bcDocEnvolvidosColeta, 0) ;
         ScanKeyStart1548( ) ;
         if ( RcdFound48 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001511 */
            pr_default.execute(9, new Object[] {A54EnvolvidosColetaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Envolvidos Coleta'.", "ForeignKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001512 */
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
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1548( -1) ;
         OnLoadActions1548( ) ;
         AddRow1548( ) ;
         ScanKeyEnd1548( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1548( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1548( ) ;
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A54EnvolvidosColetaId = Z54EnvolvidosColetaId;
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
                  Update1548( ) ;
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
                  if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
                        Insert1548( ) ;
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
                        Insert1548( ) ;
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
         RowToVars48( bcDocEnvolvidosColeta, 1) ;
         SaveImpl( ) ;
         VarsToRow48( bcDocEnvolvidosColeta) ;
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
         RowToVars48( bcDocEnvolvidosColeta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1548( ) ;
         AfterTrn( ) ;
         VarsToRow48( bcDocEnvolvidosColeta) ;
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
            SdtDocEnvolvidosColeta auxBC = new SdtDocEnvolvidosColeta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A54EnvolvidosColetaId, A75DocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocEnvolvidosColeta);
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
         RowToVars48( bcDocEnvolvidosColeta, 1) ;
         UpdateImpl( ) ;
         VarsToRow48( bcDocEnvolvidosColeta) ;
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
         RowToVars48( bcDocEnvolvidosColeta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1548( ) ;
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
         VarsToRow48( bcDocEnvolvidosColeta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars48( bcDocEnvolvidosColeta, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1548( ) ;
         if ( RcdFound48 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
            {
               A54EnvolvidosColetaId = Z54EnvolvidosColetaId;
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
            if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
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
         context.RollbackDataStores("docenvolvidoscoleta_bc",pr_default);
         VarsToRow48( bcDocEnvolvidosColeta) ;
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
         Gx_mode = bcDocEnvolvidosColeta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocEnvolvidosColeta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocEnvolvidosColeta )
         {
            bcDocEnvolvidosColeta = (SdtDocEnvolvidosColeta)(sdt);
            if ( StringUtil.StrCmp(bcDocEnvolvidosColeta.gxTpr_Mode, "") == 0 )
            {
               bcDocEnvolvidosColeta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow48( bcDocEnvolvidosColeta) ;
            }
            else
            {
               RowToVars48( bcDocEnvolvidosColeta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocEnvolvidosColeta.gxTpr_Mode, "") == 0 )
            {
               bcDocEnvolvidosColeta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars48( bcDocEnvolvidosColeta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocEnvolvidosColeta DocEnvolvidosColeta_BC
      {
         get {
            return bcDocEnvolvidosColeta ;
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
            return "docenvolvidoscoleta_Execute" ;
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
         BC00156_A54EnvolvidosColetaId = new int[1] ;
         BC00156_A75DocumentoId = new int[1] ;
         BC00154_A54EnvolvidosColetaId = new int[1] ;
         BC00155_A75DocumentoId = new int[1] ;
         BC00157_A54EnvolvidosColetaId = new int[1] ;
         BC00157_A75DocumentoId = new int[1] ;
         BC00153_A54EnvolvidosColetaId = new int[1] ;
         BC00153_A75DocumentoId = new int[1] ;
         sMode48 = "";
         BC00152_A54EnvolvidosColetaId = new int[1] ;
         BC00152_A75DocumentoId = new int[1] ;
         BC001510_A54EnvolvidosColetaId = new int[1] ;
         BC001510_A75DocumentoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001511_A54EnvolvidosColetaId = new int[1] ;
         BC001512_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docenvolvidoscoleta_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docenvolvidoscoleta_bc__default(),
            new Object[][] {
                new Object[] {
               BC00152_A54EnvolvidosColetaId, BC00152_A75DocumentoId
               }
               , new Object[] {
               BC00153_A54EnvolvidosColetaId, BC00153_A75DocumentoId
               }
               , new Object[] {
               BC00154_A54EnvolvidosColetaId
               }
               , new Object[] {
               BC00155_A75DocumentoId
               }
               , new Object[] {
               BC00156_A54EnvolvidosColetaId, BC00156_A75DocumentoId
               }
               , new Object[] {
               BC00157_A54EnvolvidosColetaId, BC00157_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001510_A54EnvolvidosColetaId, BC001510_A75DocumentoId
               }
               , new Object[] {
               BC001511_A54EnvolvidosColetaId
               }
               , new Object[] {
               BC001512_A75DocumentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12152 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound48 ;
      private short nIsDirty_48 ;
      private int trnEnded ;
      private int Z54EnvolvidosColetaId ;
      private int A54EnvolvidosColetaId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode48 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private IGxSession AV13WebSession ;
      private SdtDocEnvolvidosColeta bcDocEnvolvidosColeta ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00156_A54EnvolvidosColetaId ;
      private int[] BC00156_A75DocumentoId ;
      private int[] BC00154_A54EnvolvidosColetaId ;
      private int[] BC00155_A75DocumentoId ;
      private int[] BC00157_A54EnvolvidosColetaId ;
      private int[] BC00157_A75DocumentoId ;
      private int[] BC00153_A54EnvolvidosColetaId ;
      private int[] BC00153_A75DocumentoId ;
      private int[] BC00152_A54EnvolvidosColetaId ;
      private int[] BC00152_A75DocumentoId ;
      private int[] BC001510_A54EnvolvidosColetaId ;
      private int[] BC001510_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC001511_A54EnvolvidosColetaId ;
      private int[] BC001512_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class docenvolvidoscoleta_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docenvolvidoscoleta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00156;
        prmBC00156 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00154;
        prmBC00154 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC00155;
        prmBC00155 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00157;
        prmBC00157 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00153;
        prmBC00153 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00152;
        prmBC00152 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00158;
        prmBC00158 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00159;
        prmBC00159 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001510;
        prmBC001510 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001511;
        prmBC001511 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC001512;
        prmBC001512 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00152", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WITH (UPDLOCK) WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00153", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00153,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00154", "SELECT [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00154,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00155", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00155,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00156", "SELECT TM1.[EnvolvidosColetaId], TM1.[DocumentoId] FROM [DocEnvolvidosColeta] TM1 WHERE TM1.[EnvolvidosColetaId] = @EnvolvidosColetaId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[EnvolvidosColetaId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00156,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00157", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00157,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00158", "INSERT INTO [DocEnvolvidosColeta]([EnvolvidosColetaId], [DocumentoId]) VALUES(@EnvolvidosColetaId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmBC00158)
           ,new CursorDef("BC00159", "DELETE FROM [DocEnvolvidosColeta]  WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC00159)
           ,new CursorDef("BC001510", "SELECT TM1.[EnvolvidosColetaId], TM1.[DocumentoId] FROM [DocEnvolvidosColeta] TM1 WHERE TM1.[EnvolvidosColetaId] = @EnvolvidosColetaId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[EnvolvidosColetaId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001510,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001511", "SELECT [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001511,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001512", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001512,1, GxCacheFrequency.OFF ,true,false )
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
