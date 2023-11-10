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
   public class docimagem_bc : GXHttpHandler, IGxSilentTrn
   {
      public docimagem_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docimagem_bc( IGxContext context )
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
         ReadRow1I61( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1I61( ) ;
         standaloneModal( ) ;
         AddRow1I61( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z144DocImagemId = A144DocImagemId;
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

      protected void CONFIRM_1I0( )
      {
         BeforeValidate1I61( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1I61( ) ;
            }
            else
            {
               CheckExtendedTable1I61( ) ;
               if ( AnyError == 0 )
               {
                  ZM1I61( 2) ;
               }
               CloseExtendedTableCursors1I61( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM1I61( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z75DocumentoId = A75DocumentoId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z144DocImagemId = A144DocImagemId;
            Z145DocImagemArquivo = A145DocImagemArquivo;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1I61( )
      {
         /* Using cursor BC001I5 */
         pr_default.execute(3, new Object[] {A144DocImagemId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound61 = 1;
            A145DocImagemArquivo = BC001I5_A145DocImagemArquivo[0];
            A75DocumentoId = BC001I5_A75DocumentoId[0];
            ZM1I61( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1I61( ) ;
      }

      protected void OnLoadActions1I61( )
      {
      }

      protected void CheckExtendedTable1I61( )
      {
         nIsDirty_61 = 0;
         standaloneModal( ) ;
         /* Using cursor BC001I4 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1I61( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1I61( )
      {
         /* Using cursor BC001I6 */
         pr_default.execute(4, new Object[] {A144DocImagemId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound61 = 1;
         }
         else
         {
            RcdFound61 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001I3 */
         pr_default.execute(1, new Object[] {A144DocImagemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1I61( 1) ;
            RcdFound61 = 1;
            A144DocImagemId = BC001I3_A144DocImagemId[0];
            A145DocImagemArquivo = BC001I3_A145DocImagemArquivo[0];
            A75DocumentoId = BC001I3_A75DocumentoId[0];
            Z144DocImagemId = A144DocImagemId;
            sMode61 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1I61( ) ;
            if ( AnyError == 1 )
            {
               RcdFound61 = 0;
               InitializeNonKey1I61( ) ;
            }
            Gx_mode = sMode61;
         }
         else
         {
            RcdFound61 = 0;
            InitializeNonKey1I61( ) ;
            sMode61 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode61;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1I61( ) ;
         if ( RcdFound61 == 0 )
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
         CONFIRM_1I0( ) ;
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

      protected void CheckOptimisticConcurrency1I61( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001I2 */
            pr_default.execute(0, new Object[] {A144DocImagemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocImagem"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z75DocumentoId != BC001I2_A75DocumentoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocImagem"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1I61( )
      {
         BeforeValidate1I61( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I61( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1I61( 0) ;
            CheckOptimisticConcurrency1I61( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I61( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1I61( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001I7 */
                     pr_default.execute(5, new Object[] {A145DocImagemArquivo, A75DocumentoId});
                     A144DocImagemId = BC001I7_A144DocImagemId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("DocImagem");
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
               Load1I61( ) ;
            }
            EndLevel1I61( ) ;
         }
         CloseExtendedTableCursors1I61( ) ;
      }

      protected void Update1I61( )
      {
         BeforeValidate1I61( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I61( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I61( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I61( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1I61( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001I8 */
                     pr_default.execute(6, new Object[] {A145DocImagemArquivo, A75DocumentoId, A144DocImagemId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocImagem");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocImagem"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1I61( ) ;
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
            EndLevel1I61( ) ;
         }
         CloseExtendedTableCursors1I61( ) ;
      }

      protected void DeferredUpdate1I61( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1I61( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I61( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1I61( ) ;
            AfterConfirm1I61( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1I61( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001I9 */
                  pr_default.execute(7, new Object[] {A144DocImagemId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocImagem");
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
         sMode61 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1I61( ) ;
         Gx_mode = sMode61;
      }

      protected void OnDeleteControls1I61( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1I61( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1I61( ) ;
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

      public void ScanKeyStart1I61( )
      {
         /* Using cursor BC001I10 */
         pr_default.execute(8, new Object[] {A144DocImagemId});
         RcdFound61 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound61 = 1;
            A144DocImagemId = BC001I10_A144DocImagemId[0];
            A145DocImagemArquivo = BC001I10_A145DocImagemArquivo[0];
            A75DocumentoId = BC001I10_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1I61( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound61 = 0;
         ScanKeyLoad1I61( ) ;
      }

      protected void ScanKeyLoad1I61( )
      {
         sMode61 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound61 = 1;
            A144DocImagemId = BC001I10_A144DocImagemId[0];
            A145DocImagemArquivo = BC001I10_A145DocImagemArquivo[0];
            A75DocumentoId = BC001I10_A75DocumentoId[0];
         }
         Gx_mode = sMode61;
      }

      protected void ScanKeyEnd1I61( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1I61( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1I61( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1I61( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1I61( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1I61( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1I61( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1I61( )
      {
      }

      protected void send_integrity_lvl_hashes1I61( )
      {
      }

      protected void AddRow1I61( )
      {
         VarsToRow61( bcDocImagem) ;
      }

      protected void ReadRow1I61( )
      {
         RowToVars61( bcDocImagem, 1) ;
      }

      protected void InitializeNonKey1I61( )
      {
         A75DocumentoId = 0;
         A145DocImagemArquivo = "";
         Z75DocumentoId = 0;
      }

      protected void InitAll1I61( )
      {
         A144DocImagemId = 0;
         InitializeNonKey1I61( ) ;
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

      public void VarsToRow61( SdtDocImagem obj61 )
      {
         obj61.gxTpr_Mode = Gx_mode;
         obj61.gxTpr_Documentoid = A75DocumentoId;
         obj61.gxTpr_Docimagemarquivo = A145DocImagemArquivo;
         obj61.gxTpr_Docimagemid = A144DocImagemId;
         obj61.gxTpr_Docimagemid_Z = Z144DocImagemId;
         obj61.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj61.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow61( SdtDocImagem obj61 )
      {
         obj61.gxTpr_Docimagemid = A144DocImagemId;
         return  ;
      }

      public void RowToVars61( SdtDocImagem obj61 ,
                               int forceLoad )
      {
         Gx_mode = obj61.gxTpr_Mode;
         A75DocumentoId = obj61.gxTpr_Documentoid;
         A145DocImagemArquivo = obj61.gxTpr_Docimagemarquivo;
         A144DocImagemId = obj61.gxTpr_Docimagemid;
         Z144DocImagemId = obj61.gxTpr_Docimagemid_Z;
         Z75DocumentoId = obj61.gxTpr_Documentoid_Z;
         Gx_mode = obj61.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A144DocImagemId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1I61( ) ;
         ScanKeyStart1I61( ) ;
         if ( RcdFound61 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z144DocImagemId = A144DocImagemId;
         }
         ZM1I61( -1) ;
         OnLoadActions1I61( ) ;
         AddRow1I61( ) ;
         ScanKeyEnd1I61( ) ;
         if ( RcdFound61 == 0 )
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
         RowToVars61( bcDocImagem, 0) ;
         ScanKeyStart1I61( ) ;
         if ( RcdFound61 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z144DocImagemId = A144DocImagemId;
         }
         ZM1I61( -1) ;
         OnLoadActions1I61( ) ;
         AddRow1I61( ) ;
         ScanKeyEnd1I61( ) ;
         if ( RcdFound61 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1I61( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1I61( ) ;
         }
         else
         {
            if ( RcdFound61 == 1 )
            {
               if ( A144DocImagemId != Z144DocImagemId )
               {
                  A144DocImagemId = Z144DocImagemId;
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
                  Update1I61( ) ;
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
                  if ( A144DocImagemId != Z144DocImagemId )
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
                        Insert1I61( ) ;
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
                        Insert1I61( ) ;
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
         RowToVars61( bcDocImagem, 1) ;
         SaveImpl( ) ;
         VarsToRow61( bcDocImagem) ;
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
         RowToVars61( bcDocImagem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1I61( ) ;
         AfterTrn( ) ;
         VarsToRow61( bcDocImagem) ;
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
            SdtDocImagem auxBC = new SdtDocImagem(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A144DocImagemId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocImagem);
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
         RowToVars61( bcDocImagem, 1) ;
         UpdateImpl( ) ;
         VarsToRow61( bcDocImagem) ;
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
         RowToVars61( bcDocImagem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1I61( ) ;
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
         VarsToRow61( bcDocImagem) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars61( bcDocImagem, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1I61( ) ;
         if ( RcdFound61 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A144DocImagemId != Z144DocImagemId )
            {
               A144DocImagemId = Z144DocImagemId;
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
            if ( A144DocImagemId != Z144DocImagemId )
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
         context.RollbackDataStores("docimagem_bc",pr_default);
         VarsToRow61( bcDocImagem) ;
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
         Gx_mode = bcDocImagem.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocImagem.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocImagem )
         {
            bcDocImagem = (SdtDocImagem)(sdt);
            if ( StringUtil.StrCmp(bcDocImagem.gxTpr_Mode, "") == 0 )
            {
               bcDocImagem.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow61( bcDocImagem) ;
            }
            else
            {
               RowToVars61( bcDocImagem, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocImagem.gxTpr_Mode, "") == 0 )
            {
               bcDocImagem.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars61( bcDocImagem, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocImagem DocImagem_BC
      {
         get {
            return bcDocImagem ;
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
            return "docimagem_Execute" ;
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
         Z145DocImagemArquivo = "";
         A145DocImagemArquivo = "";
         BC001I5_A144DocImagemId = new int[1] ;
         BC001I5_A145DocImagemArquivo = new string[] {""} ;
         BC001I5_A75DocumentoId = new int[1] ;
         BC001I4_A75DocumentoId = new int[1] ;
         BC001I6_A144DocImagemId = new int[1] ;
         BC001I3_A144DocImagemId = new int[1] ;
         BC001I3_A145DocImagemArquivo = new string[] {""} ;
         BC001I3_A75DocumentoId = new int[1] ;
         sMode61 = "";
         BC001I2_A144DocImagemId = new int[1] ;
         BC001I2_A145DocImagemArquivo = new string[] {""} ;
         BC001I2_A75DocumentoId = new int[1] ;
         BC001I7_A144DocImagemId = new int[1] ;
         BC001I10_A144DocImagemId = new int[1] ;
         BC001I10_A145DocImagemArquivo = new string[] {""} ;
         BC001I10_A75DocumentoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docimagem_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docimagem_bc__default(),
            new Object[][] {
                new Object[] {
               BC001I2_A144DocImagemId, BC001I2_A145DocImagemArquivo, BC001I2_A75DocumentoId
               }
               , new Object[] {
               BC001I3_A144DocImagemId, BC001I3_A145DocImagemArquivo, BC001I3_A75DocumentoId
               }
               , new Object[] {
               BC001I4_A75DocumentoId
               }
               , new Object[] {
               BC001I5_A144DocImagemId, BC001I5_A145DocImagemArquivo, BC001I5_A75DocumentoId
               }
               , new Object[] {
               BC001I6_A144DocImagemId
               }
               , new Object[] {
               BC001I7_A144DocImagemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001I10_A144DocImagemId, BC001I10_A145DocImagemArquivo, BC001I10_A75DocumentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound61 ;
      private short nIsDirty_61 ;
      private int trnEnded ;
      private int Z144DocImagemId ;
      private int A144DocImagemId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode61 ;
      private bool mustCommit ;
      private string Z145DocImagemArquivo ;
      private string A145DocImagemArquivo ;
      private SdtDocImagem bcDocImagem ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001I5_A144DocImagemId ;
      private string[] BC001I5_A145DocImagemArquivo ;
      private int[] BC001I5_A75DocumentoId ;
      private int[] BC001I4_A75DocumentoId ;
      private int[] BC001I6_A144DocImagemId ;
      private int[] BC001I3_A144DocImagemId ;
      private string[] BC001I3_A145DocImagemArquivo ;
      private int[] BC001I3_A75DocumentoId ;
      private int[] BC001I2_A144DocImagemId ;
      private string[] BC001I2_A145DocImagemArquivo ;
      private int[] BC001I2_A75DocumentoId ;
      private int[] BC001I7_A144DocImagemId ;
      private int[] BC001I10_A144DocImagemId ;
      private string[] BC001I10_A145DocImagemArquivo ;
      private int[] BC001I10_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class docimagem_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docimagem_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001I5;
        prmBC001I5 = new Object[] {
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        Object[] prmBC001I4;
        prmBC001I4 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001I6;
        prmBC001I6 = new Object[] {
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        Object[] prmBC001I3;
        prmBC001I3 = new Object[] {
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        Object[] prmBC001I2;
        prmBC001I2 = new Object[] {
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        Object[] prmBC001I7;
        prmBC001I7 = new Object[] {
        new ParDef("@DocImagemArquivo",GXType.NVarChar,2097152,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001I8;
        prmBC001I8 = new Object[] {
        new ParDef("@DocImagemArquivo",GXType.NVarChar,2097152,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        Object[] prmBC001I9;
        prmBC001I9 = new Object[] {
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        Object[] prmBC001I10;
        prmBC001I10 = new Object[] {
        new ParDef("@DocImagemId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001I2", "SELECT [DocImagemId], [DocImagemArquivo], [DocumentoId] FROM [DocImagem] WITH (UPDLOCK) WHERE [DocImagemId] = @DocImagemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001I3", "SELECT [DocImagemId], [DocImagemArquivo], [DocumentoId] FROM [DocImagem] WHERE [DocImagemId] = @DocImagemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001I4", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001I5", "SELECT TM1.[DocImagemId], TM1.[DocImagemArquivo], TM1.[DocumentoId] FROM [DocImagem] TM1 WHERE TM1.[DocImagemId] = @DocImagemId ORDER BY TM1.[DocImagemId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001I6", "SELECT [DocImagemId] FROM [DocImagem] WHERE [DocImagemId] = @DocImagemId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001I7", "INSERT INTO [DocImagem]([DocImagemArquivo], [DocumentoId]) VALUES(@DocImagemArquivo, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001I8", "UPDATE [DocImagem] SET [DocImagemArquivo]=@DocImagemArquivo, [DocumentoId]=@DocumentoId  WHERE [DocImagemId] = @DocImagemId", GxErrorMask.GX_NOMASK,prmBC001I8)
           ,new CursorDef("BC001I9", "DELETE FROM [DocImagem]  WHERE [DocImagemId] = @DocImagemId", GxErrorMask.GX_NOMASK,prmBC001I9)
           ,new CursorDef("BC001I10", "SELECT TM1.[DocImagemId], TM1.[DocImagemArquivo], TM1.[DocumentoId] FROM [DocImagem] TM1 WHERE TM1.[DocImagemId] = @DocImagemId ORDER BY TM1.[DocImagemId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
     }
  }

}

}
