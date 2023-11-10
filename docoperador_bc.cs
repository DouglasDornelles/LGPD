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
   public class docoperador_bc : GXHttpHandler, IGxSilentTrn
   {
      public docoperador_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docoperador_bc( IGxContext context )
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
         ReadRow1447( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1447( ) ;
         standaloneModal( ) ;
         AddRow1447( ) ;
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
            E11142 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z86DocOperadorId = A86DocOperadorId;
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1447( ) ;
            }
            else
            {
               CheckExtendedTable1447( ) ;
               if ( AnyError == 0 )
               {
                  ZM1447( 6) ;
                  ZM1447( 7) ;
               }
               CloseExtendedTableCursors1447( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12142( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV37Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV38GXV1 = 1;
            while ( AV38GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV38GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OperadorId") == 0 )
               {
                  AV14Insert_OperadorId = (int)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV38GXV1 = (int)(AV38GXV1+1);
            }
         }
      }

      protected void E11142( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1447( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z87DocOperadorColeta = A87DocOperadorColeta;
            Z88DocOperadorRetencao = A88DocOperadorRetencao;
            Z89DocOperadorCompartilhamento = A89DocOperadorCompartilhamento;
            Z90DocOperadorEliminacao = A90DocOperadorEliminacao;
            Z91DocOperadorProcessamento = A91DocOperadorProcessamento;
            Z92DocOperadorDataInclusao = A92DocOperadorDataInclusao;
            Z75DocumentoId = A75DocumentoId;
            Z42OperadorId = A42OperadorId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z86DocOperadorId = A86DocOperadorId;
            Z87DocOperadorColeta = A87DocOperadorColeta;
            Z88DocOperadorRetencao = A88DocOperadorRetencao;
            Z89DocOperadorCompartilhamento = A89DocOperadorCompartilhamento;
            Z90DocOperadorEliminacao = A90DocOperadorEliminacao;
            Z91DocOperadorProcessamento = A91DocOperadorProcessamento;
            Z92DocOperadorDataInclusao = A92DocOperadorDataInclusao;
            Z75DocumentoId = A75DocumentoId;
            Z42OperadorId = A42OperadorId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV37Pgmname = "DocOperador_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A92DocOperadorDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1447( )
      {
         /* Using cursor BC00146 */
         pr_default.execute(4, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound47 = 1;
            A87DocOperadorColeta = BC00146_A87DocOperadorColeta[0];
            A88DocOperadorRetencao = BC00146_A88DocOperadorRetencao[0];
            A89DocOperadorCompartilhamento = BC00146_A89DocOperadorCompartilhamento[0];
            A90DocOperadorEliminacao = BC00146_A90DocOperadorEliminacao[0];
            A91DocOperadorProcessamento = BC00146_A91DocOperadorProcessamento[0];
            A92DocOperadorDataInclusao = BC00146_A92DocOperadorDataInclusao[0];
            A75DocumentoId = BC00146_A75DocumentoId[0];
            A42OperadorId = BC00146_A42OperadorId[0];
            ZM1447( -5) ;
         }
         pr_default.close(4);
         OnLoadActions1447( ) ;
      }

      protected void OnLoadActions1447( )
      {
      }

      protected void CheckExtendedTable1447( )
      {
         nIsDirty_47 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00144 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00145 */
         pr_default.execute(3, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Operador'.", "ForeignKeyNotFound", 1, "OPERADORID");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A92DocOperadorDataInclusao) || ( DateTimeUtil.ResetTime ( A92DocOperadorDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Doc Operador Data Inclusao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1447( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1447( )
      {
         /* Using cursor BC00147 */
         pr_default.execute(5, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00143 */
         pr_default.execute(1, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1447( 5) ;
            RcdFound47 = 1;
            A86DocOperadorId = BC00143_A86DocOperadorId[0];
            A87DocOperadorColeta = BC00143_A87DocOperadorColeta[0];
            A88DocOperadorRetencao = BC00143_A88DocOperadorRetencao[0];
            A89DocOperadorCompartilhamento = BC00143_A89DocOperadorCompartilhamento[0];
            A90DocOperadorEliminacao = BC00143_A90DocOperadorEliminacao[0];
            A91DocOperadorProcessamento = BC00143_A91DocOperadorProcessamento[0];
            A92DocOperadorDataInclusao = BC00143_A92DocOperadorDataInclusao[0];
            A75DocumentoId = BC00143_A75DocumentoId[0];
            A42OperadorId = BC00143_A42OperadorId[0];
            Z86DocOperadorId = A86DocOperadorId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1447( ) ;
            if ( AnyError == 1 )
            {
               RcdFound47 = 0;
               InitializeNonKey1447( ) ;
            }
            Gx_mode = sMode47;
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey1447( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode47;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1447( ) ;
         if ( RcdFound47 == 0 )
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
         CONFIRM_140( ) ;
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

      protected void CheckOptimisticConcurrency1447( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00142 */
            pr_default.execute(0, new Object[] {A86DocOperadorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocOperador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z87DocOperadorColeta != BC00142_A87DocOperadorColeta[0] ) || ( Z88DocOperadorRetencao != BC00142_A88DocOperadorRetencao[0] ) || ( Z89DocOperadorCompartilhamento != BC00142_A89DocOperadorCompartilhamento[0] ) || ( Z90DocOperadorEliminacao != BC00142_A90DocOperadorEliminacao[0] ) || ( Z91DocOperadorProcessamento != BC00142_A91DocOperadorProcessamento[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z92DocOperadorDataInclusao ) != DateTimeUtil.ResetTime ( BC00142_A92DocOperadorDataInclusao[0] ) ) || ( Z75DocumentoId != BC00142_A75DocumentoId[0] ) || ( Z42OperadorId != BC00142_A42OperadorId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocOperador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1447( )
      {
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1447( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1447( 0) ;
            CheckOptimisticConcurrency1447( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1447( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1447( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00148 */
                     pr_default.execute(6, new Object[] {A87DocOperadorColeta, A88DocOperadorRetencao, A89DocOperadorCompartilhamento, A90DocOperadorEliminacao, A91DocOperadorProcessamento, A92DocOperadorDataInclusao, A75DocumentoId, A42OperadorId});
                     A86DocOperadorId = BC00148_A86DocOperadorId[0];
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocOperador");
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
               Load1447( ) ;
            }
            EndLevel1447( ) ;
         }
         CloseExtendedTableCursors1447( ) ;
      }

      protected void Update1447( )
      {
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1447( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1447( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1447( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1447( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00149 */
                     pr_default.execute(7, new Object[] {A87DocOperadorColeta, A88DocOperadorRetencao, A89DocOperadorCompartilhamento, A90DocOperadorEliminacao, A91DocOperadorProcessamento, A92DocOperadorDataInclusao, A75DocumentoId, A42OperadorId, A86DocOperadorId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("DocOperador");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocOperador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1447( ) ;
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
            EndLevel1447( ) ;
         }
         CloseExtendedTableCursors1447( ) ;
      }

      protected void DeferredUpdate1447( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1447( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1447( ) ;
            AfterConfirm1447( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1447( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001410 */
                  pr_default.execute(8, new Object[] {A86DocOperadorId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("DocOperador");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1447( ) ;
         Gx_mode = sMode47;
      }

      protected void OnDeleteControls1447( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1447( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1447( ) ;
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

      public void ScanKeyStart1447( )
      {
         /* Scan By routine */
         /* Using cursor BC001411 */
         pr_default.execute(9, new Object[] {A86DocOperadorId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound47 = 1;
            A86DocOperadorId = BC001411_A86DocOperadorId[0];
            A87DocOperadorColeta = BC001411_A87DocOperadorColeta[0];
            A88DocOperadorRetencao = BC001411_A88DocOperadorRetencao[0];
            A89DocOperadorCompartilhamento = BC001411_A89DocOperadorCompartilhamento[0];
            A90DocOperadorEliminacao = BC001411_A90DocOperadorEliminacao[0];
            A91DocOperadorProcessamento = BC001411_A91DocOperadorProcessamento[0];
            A92DocOperadorDataInclusao = BC001411_A92DocOperadorDataInclusao[0];
            A75DocumentoId = BC001411_A75DocumentoId[0];
            A42OperadorId = BC001411_A42OperadorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1447( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound47 = 0;
         ScanKeyLoad1447( ) ;
      }

      protected void ScanKeyLoad1447( )
      {
         sMode47 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound47 = 1;
            A86DocOperadorId = BC001411_A86DocOperadorId[0];
            A87DocOperadorColeta = BC001411_A87DocOperadorColeta[0];
            A88DocOperadorRetencao = BC001411_A88DocOperadorRetencao[0];
            A89DocOperadorCompartilhamento = BC001411_A89DocOperadorCompartilhamento[0];
            A90DocOperadorEliminacao = BC001411_A90DocOperadorEliminacao[0];
            A91DocOperadorProcessamento = BC001411_A91DocOperadorProcessamento[0];
            A92DocOperadorDataInclusao = BC001411_A92DocOperadorDataInclusao[0];
            A75DocumentoId = BC001411_A75DocumentoId[0];
            A42OperadorId = BC001411_A42OperadorId[0];
         }
         Gx_mode = sMode47;
      }

      protected void ScanKeyEnd1447( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1447( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1447( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1447( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1447( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1447( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1447( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1447( )
      {
      }

      protected void send_integrity_lvl_hashes1447( )
      {
      }

      protected void AddRow1447( )
      {
         VarsToRow47( bcDocOperador) ;
      }

      protected void ReadRow1447( )
      {
         RowToVars47( bcDocOperador, 1) ;
      }

      protected void InitializeNonKey1447( )
      {
         A75DocumentoId = 0;
         A42OperadorId = 0;
         A87DocOperadorColeta = false;
         A88DocOperadorRetencao = false;
         A89DocOperadorCompartilhamento = false;
         A90DocOperadorEliminacao = false;
         A91DocOperadorProcessamento = false;
         A92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         Z87DocOperadorColeta = false;
         Z88DocOperadorRetencao = false;
         Z89DocOperadorCompartilhamento = false;
         Z90DocOperadorEliminacao = false;
         Z91DocOperadorProcessamento = false;
         Z92DocOperadorDataInclusao = DateTime.MinValue;
         Z75DocumentoId = 0;
         Z42OperadorId = 0;
      }

      protected void InitAll1447( )
      {
         A86DocOperadorId = 0;
         InitializeNonKey1447( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A92DocOperadorDataInclusao = i92DocOperadorDataInclusao;
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

      public void VarsToRow47( SdtDocOperador obj47 )
      {
         obj47.gxTpr_Mode = Gx_mode;
         obj47.gxTpr_Documentoid = A75DocumentoId;
         obj47.gxTpr_Operadorid = A42OperadorId;
         obj47.gxTpr_Docoperadorcoleta = A87DocOperadorColeta;
         obj47.gxTpr_Docoperadorretencao = A88DocOperadorRetencao;
         obj47.gxTpr_Docoperadorcompartilhamento = A89DocOperadorCompartilhamento;
         obj47.gxTpr_Docoperadoreliminacao = A90DocOperadorEliminacao;
         obj47.gxTpr_Docoperadorprocessamento = A91DocOperadorProcessamento;
         obj47.gxTpr_Docoperadordatainclusao = A92DocOperadorDataInclusao;
         obj47.gxTpr_Docoperadorid = A86DocOperadorId;
         obj47.gxTpr_Docoperadorid_Z = Z86DocOperadorId;
         obj47.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj47.gxTpr_Operadorid_Z = Z42OperadorId;
         obj47.gxTpr_Docoperadorcoleta_Z = Z87DocOperadorColeta;
         obj47.gxTpr_Docoperadorretencao_Z = Z88DocOperadorRetencao;
         obj47.gxTpr_Docoperadorcompartilhamento_Z = Z89DocOperadorCompartilhamento;
         obj47.gxTpr_Docoperadoreliminacao_Z = Z90DocOperadorEliminacao;
         obj47.gxTpr_Docoperadorprocessamento_Z = Z91DocOperadorProcessamento;
         obj47.gxTpr_Docoperadordatainclusao_Z = Z92DocOperadorDataInclusao;
         obj47.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow47( SdtDocOperador obj47 )
      {
         obj47.gxTpr_Docoperadorid = A86DocOperadorId;
         return  ;
      }

      public void RowToVars47( SdtDocOperador obj47 ,
                               int forceLoad )
      {
         Gx_mode = obj47.gxTpr_Mode;
         A75DocumentoId = obj47.gxTpr_Documentoid;
         A42OperadorId = obj47.gxTpr_Operadorid;
         A87DocOperadorColeta = obj47.gxTpr_Docoperadorcoleta;
         A88DocOperadorRetencao = obj47.gxTpr_Docoperadorretencao;
         A89DocOperadorCompartilhamento = obj47.gxTpr_Docoperadorcompartilhamento;
         A90DocOperadorEliminacao = obj47.gxTpr_Docoperadoreliminacao;
         A91DocOperadorProcessamento = obj47.gxTpr_Docoperadorprocessamento;
         A92DocOperadorDataInclusao = obj47.gxTpr_Docoperadordatainclusao;
         A86DocOperadorId = obj47.gxTpr_Docoperadorid;
         Z86DocOperadorId = obj47.gxTpr_Docoperadorid_Z;
         Z75DocumentoId = obj47.gxTpr_Documentoid_Z;
         Z42OperadorId = obj47.gxTpr_Operadorid_Z;
         Z87DocOperadorColeta = obj47.gxTpr_Docoperadorcoleta_Z;
         Z88DocOperadorRetencao = obj47.gxTpr_Docoperadorretencao_Z;
         Z89DocOperadorCompartilhamento = obj47.gxTpr_Docoperadorcompartilhamento_Z;
         Z90DocOperadorEliminacao = obj47.gxTpr_Docoperadoreliminacao_Z;
         Z91DocOperadorProcessamento = obj47.gxTpr_Docoperadorprocessamento_Z;
         Z92DocOperadorDataInclusao = obj47.gxTpr_Docoperadordatainclusao_Z;
         Gx_mode = obj47.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A86DocOperadorId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1447( ) ;
         ScanKeyStart1447( ) ;
         if ( RcdFound47 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z86DocOperadorId = A86DocOperadorId;
         }
         ZM1447( -5) ;
         OnLoadActions1447( ) ;
         AddRow1447( ) ;
         ScanKeyEnd1447( ) ;
         if ( RcdFound47 == 0 )
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
         RowToVars47( bcDocOperador, 0) ;
         ScanKeyStart1447( ) ;
         if ( RcdFound47 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z86DocOperadorId = A86DocOperadorId;
         }
         ZM1447( -5) ;
         OnLoadActions1447( ) ;
         AddRow1447( ) ;
         ScanKeyEnd1447( ) ;
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1447( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1447( ) ;
         }
         else
         {
            if ( RcdFound47 == 1 )
            {
               if ( A86DocOperadorId != Z86DocOperadorId )
               {
                  A86DocOperadorId = Z86DocOperadorId;
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
                  Update1447( ) ;
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
                  if ( A86DocOperadorId != Z86DocOperadorId )
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
                        Insert1447( ) ;
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
                        Insert1447( ) ;
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
         RowToVars47( bcDocOperador, 1) ;
         SaveImpl( ) ;
         VarsToRow47( bcDocOperador) ;
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
         RowToVars47( bcDocOperador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1447( ) ;
         AfterTrn( ) ;
         VarsToRow47( bcDocOperador) ;
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
            SdtDocOperador auxBC = new SdtDocOperador(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A86DocOperadorId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocOperador);
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
         RowToVars47( bcDocOperador, 1) ;
         UpdateImpl( ) ;
         VarsToRow47( bcDocOperador) ;
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
         RowToVars47( bcDocOperador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1447( ) ;
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
         VarsToRow47( bcDocOperador) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars47( bcDocOperador, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1447( ) ;
         if ( RcdFound47 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A86DocOperadorId != Z86DocOperadorId )
            {
               A86DocOperadorId = Z86DocOperadorId;
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
            if ( A86DocOperadorId != Z86DocOperadorId )
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
         context.RollbackDataStores("docoperador_bc",pr_default);
         VarsToRow47( bcDocOperador) ;
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
         Gx_mode = bcDocOperador.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocOperador.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocOperador )
         {
            bcDocOperador = (SdtDocOperador)(sdt);
            if ( StringUtil.StrCmp(bcDocOperador.gxTpr_Mode, "") == 0 )
            {
               bcDocOperador.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow47( bcDocOperador) ;
            }
            else
            {
               RowToVars47( bcDocOperador, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocOperador.gxTpr_Mode, "") == 0 )
            {
               bcDocOperador.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars47( bcDocOperador, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocOperador DocOperador_BC
      {
         get {
            return bcDocOperador ;
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
            return "docoperador_Execute" ;
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
         AV37Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z92DocOperadorDataInclusao = DateTime.MinValue;
         A92DocOperadorDataInclusao = DateTime.MinValue;
         BC00146_A86DocOperadorId = new int[1] ;
         BC00146_A87DocOperadorColeta = new bool[] {false} ;
         BC00146_A88DocOperadorRetencao = new bool[] {false} ;
         BC00146_A89DocOperadorCompartilhamento = new bool[] {false} ;
         BC00146_A90DocOperadorEliminacao = new bool[] {false} ;
         BC00146_A91DocOperadorProcessamento = new bool[] {false} ;
         BC00146_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00146_A75DocumentoId = new int[1] ;
         BC00146_A42OperadorId = new int[1] ;
         BC00144_A75DocumentoId = new int[1] ;
         BC00145_A42OperadorId = new int[1] ;
         BC00147_A86DocOperadorId = new int[1] ;
         BC00143_A86DocOperadorId = new int[1] ;
         BC00143_A87DocOperadorColeta = new bool[] {false} ;
         BC00143_A88DocOperadorRetencao = new bool[] {false} ;
         BC00143_A89DocOperadorCompartilhamento = new bool[] {false} ;
         BC00143_A90DocOperadorEliminacao = new bool[] {false} ;
         BC00143_A91DocOperadorProcessamento = new bool[] {false} ;
         BC00143_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00143_A75DocumentoId = new int[1] ;
         BC00143_A42OperadorId = new int[1] ;
         sMode47 = "";
         BC00142_A86DocOperadorId = new int[1] ;
         BC00142_A87DocOperadorColeta = new bool[] {false} ;
         BC00142_A88DocOperadorRetencao = new bool[] {false} ;
         BC00142_A89DocOperadorCompartilhamento = new bool[] {false} ;
         BC00142_A90DocOperadorEliminacao = new bool[] {false} ;
         BC00142_A91DocOperadorProcessamento = new bool[] {false} ;
         BC00142_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00142_A75DocumentoId = new int[1] ;
         BC00142_A42OperadorId = new int[1] ;
         BC00148_A86DocOperadorId = new int[1] ;
         BC001411_A86DocOperadorId = new int[1] ;
         BC001411_A87DocOperadorColeta = new bool[] {false} ;
         BC001411_A88DocOperadorRetencao = new bool[] {false} ;
         BC001411_A89DocOperadorCompartilhamento = new bool[] {false} ;
         BC001411_A90DocOperadorEliminacao = new bool[] {false} ;
         BC001411_A91DocOperadorProcessamento = new bool[] {false} ;
         BC001411_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001411_A75DocumentoId = new int[1] ;
         BC001411_A42OperadorId = new int[1] ;
         i92DocOperadorDataInclusao = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docoperador_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperador_bc__default(),
            new Object[][] {
                new Object[] {
               BC00142_A86DocOperadorId, BC00142_A87DocOperadorColeta, BC00142_A88DocOperadorRetencao, BC00142_A89DocOperadorCompartilhamento, BC00142_A90DocOperadorEliminacao, BC00142_A91DocOperadorProcessamento, BC00142_A92DocOperadorDataInclusao, BC00142_A75DocumentoId, BC00142_A42OperadorId
               }
               , new Object[] {
               BC00143_A86DocOperadorId, BC00143_A87DocOperadorColeta, BC00143_A88DocOperadorRetencao, BC00143_A89DocOperadorCompartilhamento, BC00143_A90DocOperadorEliminacao, BC00143_A91DocOperadorProcessamento, BC00143_A92DocOperadorDataInclusao, BC00143_A75DocumentoId, BC00143_A42OperadorId
               }
               , new Object[] {
               BC00144_A75DocumentoId
               }
               , new Object[] {
               BC00145_A42OperadorId
               }
               , new Object[] {
               BC00146_A86DocOperadorId, BC00146_A87DocOperadorColeta, BC00146_A88DocOperadorRetencao, BC00146_A89DocOperadorCompartilhamento, BC00146_A90DocOperadorEliminacao, BC00146_A91DocOperadorProcessamento, BC00146_A92DocOperadorDataInclusao, BC00146_A75DocumentoId, BC00146_A42OperadorId
               }
               , new Object[] {
               BC00147_A86DocOperadorId
               }
               , new Object[] {
               BC00148_A86DocOperadorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001411_A86DocOperadorId, BC001411_A87DocOperadorColeta, BC001411_A88DocOperadorRetencao, BC001411_A89DocOperadorCompartilhamento, BC001411_A90DocOperadorEliminacao, BC001411_A91DocOperadorProcessamento, BC001411_A92DocOperadorDataInclusao, BC001411_A75DocumentoId, BC001411_A42OperadorId
               }
            }
         );
         AV37Pgmname = "DocOperador_BC";
         Z92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         A92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         i92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12142 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound47 ;
      private short nIsDirty_47 ;
      private int trnEnded ;
      private int Z86DocOperadorId ;
      private int A86DocOperadorId ;
      private int AV38GXV1 ;
      private int AV13Insert_DocumentoId ;
      private int AV14Insert_OperadorId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private int Z42OperadorId ;
      private int A42OperadorId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV37Pgmname ;
      private string sMode47 ;
      private DateTime Z92DocOperadorDataInclusao ;
      private DateTime A92DocOperadorDataInclusao ;
      private DateTime i92DocOperadorDataInclusao ;
      private bool returnInSub ;
      private bool Z87DocOperadorColeta ;
      private bool A87DocOperadorColeta ;
      private bool Z88DocOperadorRetencao ;
      private bool A88DocOperadorRetencao ;
      private bool Z89DocOperadorCompartilhamento ;
      private bool A89DocOperadorCompartilhamento ;
      private bool Z90DocOperadorEliminacao ;
      private bool A90DocOperadorEliminacao ;
      private bool Z91DocOperadorProcessamento ;
      private bool A91DocOperadorProcessamento ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private IGxSession AV12WebSession ;
      private SdtDocOperador bcDocOperador ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00146_A86DocOperadorId ;
      private bool[] BC00146_A87DocOperadorColeta ;
      private bool[] BC00146_A88DocOperadorRetencao ;
      private bool[] BC00146_A89DocOperadorCompartilhamento ;
      private bool[] BC00146_A90DocOperadorEliminacao ;
      private bool[] BC00146_A91DocOperadorProcessamento ;
      private DateTime[] BC00146_A92DocOperadorDataInclusao ;
      private int[] BC00146_A75DocumentoId ;
      private int[] BC00146_A42OperadorId ;
      private int[] BC00144_A75DocumentoId ;
      private int[] BC00145_A42OperadorId ;
      private int[] BC00147_A86DocOperadorId ;
      private int[] BC00143_A86DocOperadorId ;
      private bool[] BC00143_A87DocOperadorColeta ;
      private bool[] BC00143_A88DocOperadorRetencao ;
      private bool[] BC00143_A89DocOperadorCompartilhamento ;
      private bool[] BC00143_A90DocOperadorEliminacao ;
      private bool[] BC00143_A91DocOperadorProcessamento ;
      private DateTime[] BC00143_A92DocOperadorDataInclusao ;
      private int[] BC00143_A75DocumentoId ;
      private int[] BC00143_A42OperadorId ;
      private int[] BC00142_A86DocOperadorId ;
      private bool[] BC00142_A87DocOperadorColeta ;
      private bool[] BC00142_A88DocOperadorRetencao ;
      private bool[] BC00142_A89DocOperadorCompartilhamento ;
      private bool[] BC00142_A90DocOperadorEliminacao ;
      private bool[] BC00142_A91DocOperadorProcessamento ;
      private DateTime[] BC00142_A92DocOperadorDataInclusao ;
      private int[] BC00142_A75DocumentoId ;
      private int[] BC00142_A42OperadorId ;
      private int[] BC00148_A86DocOperadorId ;
      private int[] BC001411_A86DocOperadorId ;
      private bool[] BC001411_A87DocOperadorColeta ;
      private bool[] BC001411_A88DocOperadorRetencao ;
      private bool[] BC001411_A89DocOperadorCompartilhamento ;
      private bool[] BC001411_A90DocOperadorEliminacao ;
      private bool[] BC001411_A91DocOperadorProcessamento ;
      private DateTime[] BC001411_A92DocOperadorDataInclusao ;
      private int[] BC001411_A75DocumentoId ;
      private int[] BC001411_A42OperadorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
   }

   public class docoperador_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docoperador_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00146;
        prmBC00146 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC00144;
        prmBC00144 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00145;
        prmBC00145 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC00147;
        prmBC00147 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC00143;
        prmBC00143 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC00142;
        prmBC00142 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC00148;
        prmBC00148 = new Object[] {
        new ParDef("@DocOperadorColeta",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorRetencao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorCompartilhamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorEliminacao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorProcessamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC00149;
        prmBC00149 = new Object[] {
        new ParDef("@DocOperadorColeta",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorRetencao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorCompartilhamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorEliminacao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorProcessamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@OperadorId",GXType.Int32,8,0) ,
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC001410;
        prmBC001410 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC001411;
        prmBC001411 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00142", "SELECT [DocOperadorId], [DocOperadorColeta], [DocOperadorRetencao], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorDataInclusao], [DocumentoId], [OperadorId] FROM [DocOperador] WITH (UPDLOCK) WHERE [DocOperadorId] = @DocOperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00143", "SELECT [DocOperadorId], [DocOperadorColeta], [DocOperadorRetencao], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorDataInclusao], [DocumentoId], [OperadorId] FROM [DocOperador] WHERE [DocOperadorId] = @DocOperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00144", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00145", "SELECT [OperadorId] FROM [Operador] WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00146", "SELECT TM1.[DocOperadorId], TM1.[DocOperadorColeta], TM1.[DocOperadorRetencao], TM1.[DocOperadorCompartilhamento], TM1.[DocOperadorEliminacao], TM1.[DocOperadorProcessamento], TM1.[DocOperadorDataInclusao], TM1.[DocumentoId], TM1.[OperadorId] FROM [DocOperador] TM1 WHERE TM1.[DocOperadorId] = @DocOperadorId ORDER BY TM1.[DocOperadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00146,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00147", "SELECT [DocOperadorId] FROM [DocOperador] WHERE [DocOperadorId] = @DocOperadorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00147,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00148", "INSERT INTO [DocOperador]([DocOperadorColeta], [DocOperadorRetencao], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorDataInclusao], [DocumentoId], [OperadorId]) VALUES(@DocOperadorColeta, @DocOperadorRetencao, @DocOperadorCompartilhamento, @DocOperadorEliminacao, @DocOperadorProcessamento, @DocOperadorDataInclusao, @DocumentoId, @OperadorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00148,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00149", "UPDATE [DocOperador] SET [DocOperadorColeta]=@DocOperadorColeta, [DocOperadorRetencao]=@DocOperadorRetencao, [DocOperadorCompartilhamento]=@DocOperadorCompartilhamento, [DocOperadorEliminacao]=@DocOperadorEliminacao, [DocOperadorProcessamento]=@DocOperadorProcessamento, [DocOperadorDataInclusao]=@DocOperadorDataInclusao, [DocumentoId]=@DocumentoId, [OperadorId]=@OperadorId  WHERE [DocOperadorId] = @DocOperadorId", GxErrorMask.GX_NOMASK,prmBC00149)
           ,new CursorDef("BC001410", "DELETE FROM [DocOperador]  WHERE [DocOperadorId] = @DocOperadorId", GxErrorMask.GX_NOMASK,prmBC001410)
           ,new CursorDef("BC001411", "SELECT TM1.[DocOperadorId], TM1.[DocOperadorColeta], TM1.[DocOperadorRetencao], TM1.[DocOperadorCompartilhamento], TM1.[DocOperadorEliminacao], TM1.[DocOperadorProcessamento], TM1.[DocOperadorDataInclusao], TM1.[DocumentoId], TM1.[OperadorId] FROM [DocOperador] TM1 WHERE TM1.[DocOperadorId] = @DocOperadorId ORDER BY TM1.[DocOperadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001411,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
     }
  }

}

}
