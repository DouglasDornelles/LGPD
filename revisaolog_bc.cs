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
   public class revisaolog_bc : GXHttpHandler, IGxSilentTrn
   {
      public revisaolog_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaolog_bc( IGxContext context )
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
         ReadRow1B55( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1B55( ) ;
         standaloneModal( ) ;
         AddRow1B55( ) ;
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
            E111B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z120RevisaoLogId = A120RevisaoLogId;
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B55( ) ;
            }
            else
            {
               CheckExtendedTable1B55( ) ;
               if ( AnyError == 0 )
               {
                  ZM1B55( 9) ;
               }
               CloseExtendedTableCursors1B55( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E121B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
         }
      }

      protected void E111B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV15IsInserido = true;
      }

      protected void ZM1B55( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z121RevisaoLogUsuarioAlteracao = A121RevisaoLogUsuarioAlteracao;
            Z123RevisaoLogDataAlteracao = A123RevisaoLogDataAlteracao;
            Z75DocumentoId = A75DocumentoId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z120RevisaoLogId = A120RevisaoLogId;
            Z122RevisaoLogObservacao = A122RevisaoLogObservacao;
            Z121RevisaoLogUsuarioAlteracao = A121RevisaoLogUsuarioAlteracao;
            Z123RevisaoLogDataAlteracao = A123RevisaoLogDataAlteracao;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV17Pgmname = "RevisaoLog_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A121RevisaoLogUsuarioAlteracao)) && ( Gx_BScreen == 0 ) )
         {
            A121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         }
         if ( IsIns( )  && (DateTime.MinValue==A123RevisaoLogDataAlteracao) && ( Gx_BScreen == 0 ) )
         {
            A123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1B55( )
      {
         /* Using cursor BC001B5 */
         pr_default.execute(3, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound55 = 1;
            A122RevisaoLogObservacao = BC001B5_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = BC001B5_A121RevisaoLogUsuarioAlteracao[0];
            A123RevisaoLogDataAlteracao = BC001B5_A123RevisaoLogDataAlteracao[0];
            A75DocumentoId = BC001B5_A75DocumentoId[0];
            ZM1B55( -8) ;
         }
         pr_default.close(3);
         OnLoadActions1B55( ) ;
      }

      protected void OnLoadActions1B55( )
      {
         A122RevisaoLogObservacao = StringUtil.Upper( A122RevisaoLogObservacao);
      }

      protected void CheckExtendedTable1B55( )
      {
         nIsDirty_55 = 0;
         standaloneModal( ) ;
         nIsDirty_55 = 1;
         A122RevisaoLogObservacao = StringUtil.Upper( A122RevisaoLogObservacao);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A122RevisaoLogObservacao)) )
         {
            GX_msglist.addItem("Observação é obrigatória.", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A123RevisaoLogDataAlteracao) || ( A123RevisaoLogDataAlteracao >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Revisao Log Data Alteracao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001B4 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1B55( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1B55( )
      {
         /* Using cursor BC001B6 */
         pr_default.execute(4, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound55 = 1;
         }
         else
         {
            RcdFound55 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001B3 */
         pr_default.execute(1, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B55( 8) ;
            RcdFound55 = 1;
            A120RevisaoLogId = BC001B3_A120RevisaoLogId[0];
            A122RevisaoLogObservacao = BC001B3_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = BC001B3_A121RevisaoLogUsuarioAlteracao[0];
            A123RevisaoLogDataAlteracao = BC001B3_A123RevisaoLogDataAlteracao[0];
            A75DocumentoId = BC001B3_A75DocumentoId[0];
            Z120RevisaoLogId = A120RevisaoLogId;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1B55( ) ;
            if ( AnyError == 1 )
            {
               RcdFound55 = 0;
               InitializeNonKey1B55( ) ;
            }
            Gx_mode = sMode55;
         }
         else
         {
            RcdFound55 = 0;
            InitializeNonKey1B55( ) ;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode55;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B55( ) ;
         if ( RcdFound55 == 0 )
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
         CONFIRM_1B0( ) ;
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

      protected void CheckOptimisticConcurrency1B55( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001B2 */
            pr_default.execute(0, new Object[] {A120RevisaoLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RevisaoLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z121RevisaoLogUsuarioAlteracao, BC001B2_A121RevisaoLogUsuarioAlteracao[0]) != 0 ) || ( Z123RevisaoLogDataAlteracao != BC001B2_A123RevisaoLogDataAlteracao[0] ) || ( Z75DocumentoId != BC001B2_A75DocumentoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RevisaoLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B55( )
      {
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B55( 0) ;
            CheckOptimisticConcurrency1B55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B7 */
                     pr_default.execute(5, new Object[] {A122RevisaoLogObservacao, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A75DocumentoId});
                     A120RevisaoLogId = BC001B7_A120RevisaoLogId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("RevisaoLog");
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
               Load1B55( ) ;
            }
            EndLevel1B55( ) ;
         }
         CloseExtendedTableCursors1B55( ) ;
      }

      protected void Update1B55( )
      {
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B8 */
                     pr_default.execute(6, new Object[] {A122RevisaoLogObservacao, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A75DocumentoId, A120RevisaoLogId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("RevisaoLog");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RevisaoLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B55( ) ;
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
            EndLevel1B55( ) ;
         }
         CloseExtendedTableCursors1B55( ) ;
      }

      protected void DeferredUpdate1B55( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B55( ) ;
            AfterConfirm1B55( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B55( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001B9 */
                  pr_default.execute(7, new Object[] {A120RevisaoLogId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("RevisaoLog");
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
         sMode55 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1B55( ) ;
         Gx_mode = sMode55;
      }

      protected void OnDeleteControls1B55( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1B55( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B55( ) ;
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

      public void ScanKeyStart1B55( )
      {
         /* Scan By routine */
         /* Using cursor BC001B10 */
         pr_default.execute(8, new Object[] {A120RevisaoLogId});
         RcdFound55 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound55 = 1;
            A120RevisaoLogId = BC001B10_A120RevisaoLogId[0];
            A122RevisaoLogObservacao = BC001B10_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = BC001B10_A121RevisaoLogUsuarioAlteracao[0];
            A123RevisaoLogDataAlteracao = BC001B10_A123RevisaoLogDataAlteracao[0];
            A75DocumentoId = BC001B10_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1B55( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound55 = 0;
         ScanKeyLoad1B55( ) ;
      }

      protected void ScanKeyLoad1B55( )
      {
         sMode55 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound55 = 1;
            A120RevisaoLogId = BC001B10_A120RevisaoLogId[0];
            A122RevisaoLogObservacao = BC001B10_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = BC001B10_A121RevisaoLogUsuarioAlteracao[0];
            A123RevisaoLogDataAlteracao = BC001B10_A123RevisaoLogDataAlteracao[0];
            A75DocumentoId = BC001B10_A75DocumentoId[0];
         }
         Gx_mode = sMode55;
      }

      protected void ScanKeyEnd1B55( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1B55( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B55( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B55( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B55( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B55( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B55( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B55( )
      {
      }

      protected void send_integrity_lvl_hashes1B55( )
      {
      }

      protected void AddRow1B55( )
      {
         VarsToRow55( bcRevisaoLog) ;
      }

      protected void ReadRow1B55( )
      {
         RowToVars55( bcRevisaoLog, 1) ;
      }

      protected void InitializeNonKey1B55( )
      {
         A122RevisaoLogObservacao = "";
         A75DocumentoId = 0;
         A121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         Z121RevisaoLogUsuarioAlteracao = "";
         Z123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         Z75DocumentoId = 0;
      }

      protected void InitAll1B55( )
      {
         A120RevisaoLogId = 0;
         InitializeNonKey1B55( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A121RevisaoLogUsuarioAlteracao = i121RevisaoLogUsuarioAlteracao;
         A123RevisaoLogDataAlteracao = i123RevisaoLogDataAlteracao;
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

      public void VarsToRow55( SdtRevisaoLog obj55 )
      {
         obj55.gxTpr_Mode = Gx_mode;
         obj55.gxTpr_Revisaologobservacao = A122RevisaoLogObservacao;
         obj55.gxTpr_Documentoid = A75DocumentoId;
         obj55.gxTpr_Revisaologusuarioalteracao = A121RevisaoLogUsuarioAlteracao;
         obj55.gxTpr_Revisaologdataalteracao = A123RevisaoLogDataAlteracao;
         obj55.gxTpr_Revisaologid = A120RevisaoLogId;
         obj55.gxTpr_Revisaologid_Z = Z120RevisaoLogId;
         obj55.gxTpr_Revisaologusuarioalteracao_Z = Z121RevisaoLogUsuarioAlteracao;
         obj55.gxTpr_Revisaologdataalteracao_Z = Z123RevisaoLogDataAlteracao;
         obj55.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj55.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow55( SdtRevisaoLog obj55 )
      {
         obj55.gxTpr_Revisaologid = A120RevisaoLogId;
         return  ;
      }

      public void RowToVars55( SdtRevisaoLog obj55 ,
                               int forceLoad )
      {
         Gx_mode = obj55.gxTpr_Mode;
         A122RevisaoLogObservacao = obj55.gxTpr_Revisaologobservacao;
         A75DocumentoId = obj55.gxTpr_Documentoid;
         A121RevisaoLogUsuarioAlteracao = obj55.gxTpr_Revisaologusuarioalteracao;
         A123RevisaoLogDataAlteracao = obj55.gxTpr_Revisaologdataalteracao;
         A120RevisaoLogId = obj55.gxTpr_Revisaologid;
         Z120RevisaoLogId = obj55.gxTpr_Revisaologid_Z;
         Z121RevisaoLogUsuarioAlteracao = obj55.gxTpr_Revisaologusuarioalteracao_Z;
         Z123RevisaoLogDataAlteracao = obj55.gxTpr_Revisaologdataalteracao_Z;
         Z75DocumentoId = obj55.gxTpr_Documentoid_Z;
         Gx_mode = obj55.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A120RevisaoLogId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1B55( ) ;
         ScanKeyStart1B55( ) ;
         if ( RcdFound55 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z120RevisaoLogId = A120RevisaoLogId;
         }
         ZM1B55( -8) ;
         OnLoadActions1B55( ) ;
         AddRow1B55( ) ;
         ScanKeyEnd1B55( ) ;
         if ( RcdFound55 == 0 )
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
         RowToVars55( bcRevisaoLog, 0) ;
         ScanKeyStart1B55( ) ;
         if ( RcdFound55 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z120RevisaoLogId = A120RevisaoLogId;
         }
         ZM1B55( -8) ;
         OnLoadActions1B55( ) ;
         AddRow1B55( ) ;
         ScanKeyEnd1B55( ) ;
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1B55( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1B55( ) ;
         }
         else
         {
            if ( RcdFound55 == 1 )
            {
               if ( A120RevisaoLogId != Z120RevisaoLogId )
               {
                  A120RevisaoLogId = Z120RevisaoLogId;
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
                  Update1B55( ) ;
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
                  if ( A120RevisaoLogId != Z120RevisaoLogId )
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
                        Insert1B55( ) ;
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
                        Insert1B55( ) ;
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
         RowToVars55( bcRevisaoLog, 1) ;
         SaveImpl( ) ;
         VarsToRow55( bcRevisaoLog) ;
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
         RowToVars55( bcRevisaoLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B55( ) ;
         AfterTrn( ) ;
         VarsToRow55( bcRevisaoLog) ;
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
            SdtRevisaoLog auxBC = new SdtRevisaoLog(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A120RevisaoLogId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRevisaoLog);
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
         RowToVars55( bcRevisaoLog, 1) ;
         UpdateImpl( ) ;
         VarsToRow55( bcRevisaoLog) ;
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
         RowToVars55( bcRevisaoLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B55( ) ;
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
         VarsToRow55( bcRevisaoLog) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars55( bcRevisaoLog, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1B55( ) ;
         if ( RcdFound55 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A120RevisaoLogId != Z120RevisaoLogId )
            {
               A120RevisaoLogId = Z120RevisaoLogId;
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
            if ( A120RevisaoLogId != Z120RevisaoLogId )
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
         context.RollbackDataStores("revisaolog_bc",pr_default);
         VarsToRow55( bcRevisaoLog) ;
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
         Gx_mode = bcRevisaoLog.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRevisaoLog.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRevisaoLog )
         {
            bcRevisaoLog = (SdtRevisaoLog)(sdt);
            if ( StringUtil.StrCmp(bcRevisaoLog.gxTpr_Mode, "") == 0 )
            {
               bcRevisaoLog.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow55( bcRevisaoLog) ;
            }
            else
            {
               RowToVars55( bcRevisaoLog, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRevisaoLog.gxTpr_Mode, "") == 0 )
            {
               bcRevisaoLog.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars55( bcRevisaoLog, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtRevisaoLog RevisaoLog_BC
      {
         get {
            return bcRevisaoLog ;
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
            return "revisaolog_Execute" ;
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
         AV17Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z121RevisaoLogUsuarioAlteracao = "";
         A121RevisaoLogUsuarioAlteracao = "";
         Z123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         Z122RevisaoLogObservacao = "";
         A122RevisaoLogObservacao = "";
         BC001B5_A120RevisaoLogId = new int[1] ;
         BC001B5_A122RevisaoLogObservacao = new string[] {""} ;
         BC001B5_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         BC001B5_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001B5_A75DocumentoId = new int[1] ;
         BC001B4_A75DocumentoId = new int[1] ;
         BC001B6_A120RevisaoLogId = new int[1] ;
         BC001B3_A120RevisaoLogId = new int[1] ;
         BC001B3_A122RevisaoLogObservacao = new string[] {""} ;
         BC001B3_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         BC001B3_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001B3_A75DocumentoId = new int[1] ;
         sMode55 = "";
         BC001B2_A120RevisaoLogId = new int[1] ;
         BC001B2_A122RevisaoLogObservacao = new string[] {""} ;
         BC001B2_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         BC001B2_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001B2_A75DocumentoId = new int[1] ;
         BC001B7_A120RevisaoLogId = new int[1] ;
         BC001B10_A120RevisaoLogId = new int[1] ;
         BC001B10_A122RevisaoLogObservacao = new string[] {""} ;
         BC001B10_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         BC001B10_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001B10_A75DocumentoId = new int[1] ;
         i121RevisaoLogUsuarioAlteracao = "";
         i123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.revisaolog_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaolog_bc__default(),
            new Object[][] {
                new Object[] {
               BC001B2_A120RevisaoLogId, BC001B2_A122RevisaoLogObservacao, BC001B2_A121RevisaoLogUsuarioAlteracao, BC001B2_A123RevisaoLogDataAlteracao, BC001B2_A75DocumentoId
               }
               , new Object[] {
               BC001B3_A120RevisaoLogId, BC001B3_A122RevisaoLogObservacao, BC001B3_A121RevisaoLogUsuarioAlteracao, BC001B3_A123RevisaoLogDataAlteracao, BC001B3_A75DocumentoId
               }
               , new Object[] {
               BC001B4_A75DocumentoId
               }
               , new Object[] {
               BC001B5_A120RevisaoLogId, BC001B5_A122RevisaoLogObservacao, BC001B5_A121RevisaoLogUsuarioAlteracao, BC001B5_A123RevisaoLogDataAlteracao, BC001B5_A75DocumentoId
               }
               , new Object[] {
               BC001B6_A120RevisaoLogId
               }
               , new Object[] {
               BC001B7_A120RevisaoLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001B10_A120RevisaoLogId, BC001B10_A122RevisaoLogObservacao, BC001B10_A121RevisaoLogUsuarioAlteracao, BC001B10_A123RevisaoLogDataAlteracao, BC001B10_A75DocumentoId
               }
            }
         );
         AV17Pgmname = "RevisaoLog_BC";
         Z123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         A123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         i123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         Z121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         i121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121B2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound55 ;
      private short nIsDirty_55 ;
      private int trnEnded ;
      private int Z120RevisaoLogId ;
      private int A120RevisaoLogId ;
      private int AV18GXV1 ;
      private int AV13Insert_DocumentoId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV17Pgmname ;
      private string sMode55 ;
      private DateTime Z123RevisaoLogDataAlteracao ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private DateTime i123RevisaoLogDataAlteracao ;
      private bool returnInSub ;
      private bool AV15IsInserido ;
      private bool mustCommit ;
      private string Z122RevisaoLogObservacao ;
      private string A122RevisaoLogObservacao ;
      private string Z121RevisaoLogUsuarioAlteracao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string i121RevisaoLogUsuarioAlteracao ;
      private IGxSession AV12WebSession ;
      private SdtRevisaoLog bcRevisaoLog ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001B5_A120RevisaoLogId ;
      private string[] BC001B5_A122RevisaoLogObservacao ;
      private string[] BC001B5_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] BC001B5_A123RevisaoLogDataAlteracao ;
      private int[] BC001B5_A75DocumentoId ;
      private int[] BC001B4_A75DocumentoId ;
      private int[] BC001B6_A120RevisaoLogId ;
      private int[] BC001B3_A120RevisaoLogId ;
      private string[] BC001B3_A122RevisaoLogObservacao ;
      private string[] BC001B3_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] BC001B3_A123RevisaoLogDataAlteracao ;
      private int[] BC001B3_A75DocumentoId ;
      private int[] BC001B2_A120RevisaoLogId ;
      private string[] BC001B2_A122RevisaoLogObservacao ;
      private string[] BC001B2_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] BC001B2_A123RevisaoLogDataAlteracao ;
      private int[] BC001B2_A75DocumentoId ;
      private int[] BC001B7_A120RevisaoLogId ;
      private int[] BC001B10_A120RevisaoLogId ;
      private string[] BC001B10_A122RevisaoLogObservacao ;
      private string[] BC001B10_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] BC001B10_A123RevisaoLogDataAlteracao ;
      private int[] BC001B10_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class revisaolog_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class revisaolog_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC001B5;
        prmBC001B5 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmBC001B4;
        prmBC001B4 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001B6;
        prmBC001B6 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmBC001B3;
        prmBC001B3 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmBC001B2;
        prmBC001B2 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmBC001B7;
        prmBC001B7 = new Object[] {
        new ParDef("@RevisaoLogObservacao",GXType.NVarChar,10000,0) ,
        new ParDef("@RevisaoLogUsuarioAlteracao",GXType.NVarChar,100,0) ,
        new ParDef("@RevisaoLogDataAlteracao",GXType.DateTime,8,5) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001B8;
        prmBC001B8 = new Object[] {
        new ParDef("@RevisaoLogObservacao",GXType.NVarChar,10000,0) ,
        new ParDef("@RevisaoLogUsuarioAlteracao",GXType.NVarChar,100,0) ,
        new ParDef("@RevisaoLogDataAlteracao",GXType.DateTime,8,5) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmBC001B9;
        prmBC001B9 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmBC001B10;
        prmBC001B10 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001B2", "SELECT [RevisaoLogId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [DocumentoId] FROM [RevisaoLog] WITH (UPDLOCK) WHERE [RevisaoLogId] = @RevisaoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B3", "SELECT [RevisaoLogId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [DocumentoId] FROM [RevisaoLog] WHERE [RevisaoLogId] = @RevisaoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B4", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B5", "SELECT TM1.[RevisaoLogId], TM1.[RevisaoLogObservacao], TM1.[RevisaoLogUsuarioAlteracao], TM1.[RevisaoLogDataAlteracao], TM1.[DocumentoId] FROM [RevisaoLog] TM1 WHERE TM1.[RevisaoLogId] = @RevisaoLogId ORDER BY TM1.[RevisaoLogId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B6", "SELECT [RevisaoLogId] FROM [RevisaoLog] WHERE [RevisaoLogId] = @RevisaoLogId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B7", "INSERT INTO [RevisaoLog]([RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [DocumentoId]) VALUES(@RevisaoLogObservacao, @RevisaoLogUsuarioAlteracao, @RevisaoLogDataAlteracao, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B8", "UPDATE [RevisaoLog] SET [RevisaoLogObservacao]=@RevisaoLogObservacao, [RevisaoLogUsuarioAlteracao]=@RevisaoLogUsuarioAlteracao, [RevisaoLogDataAlteracao]=@RevisaoLogDataAlteracao, [DocumentoId]=@DocumentoId  WHERE [RevisaoLogId] = @RevisaoLogId", GxErrorMask.GX_NOMASK,prmBC001B8)
           ,new CursorDef("BC001B9", "DELETE FROM [RevisaoLog]  WHERE [RevisaoLogId] = @RevisaoLogId", GxErrorMask.GX_NOMASK,prmBC001B9)
           ,new CursorDef("BC001B10", "SELECT TM1.[RevisaoLogId], TM1.[RevisaoLogObservacao], TM1.[RevisaoLogUsuarioAlteracao], TM1.[RevisaoLogDataAlteracao], TM1.[DocumentoId] FROM [RevisaoLog] TM1 WHERE TM1.[RevisaoLogId] = @RevisaoLogId ORDER BY TM1.[RevisaoLogId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
     }
  }

}

}
