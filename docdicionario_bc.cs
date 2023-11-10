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
   public class docdicionario_bc : GXHttpHandler, IGxSilentTrn
   {
      public docdicionario_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docdicionario_bc( IGxContext context )
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
         ReadRow0W43( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0W43( ) ;
         standaloneModal( ) ;
         AddRow0W43( ) ;
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
            E110W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W43( ) ;
            }
            else
            {
               CheckExtendedTable0W43( ) ;
               if ( AnyError == 0 )
               {
                  ZM0W43( 8) ;
                  ZM0W43( 9) ;
                  ZM0W43( 10) ;
               }
               CloseExtendedTableCursors0W43( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            while ( AV34GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "InformacaoId") == 0 )
               {
                  AV14Insert_InformacaoId = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "HipoteseTratamentoId") == 0 )
               {
                  AV15Insert_HipoteseTratamentoId = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV34GXV1 = (int)(AV34GXV1+1);
            }
         }
      }

      protected void E110W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0W43( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z99DocDicionarioSensivel = A99DocDicionarioSensivel;
            Z100DocDicionarioPodeEliminar = A100DocDicionarioPodeEliminar;
            Z101DocDicionarioTransfInter = A101DocDicionarioTransfInter;
            Z103DocDicionarioDataInclusao = A103DocDicionarioDataInclusao;
            Z69InformacaoId = A69InformacaoId;
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
            Z75DocumentoId = A75DocumentoId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z70InformacaoNome = A70InformacaoNome;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z73HipoteseTratamentoNome = A73HipoteseTratamentoNome;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z76DocumentoNome = A76DocumentoNome;
         }
         if ( GX_JID == -7 )
         {
            Z98DocDicionarioId = A98DocDicionarioId;
            Z102DocDicionarioFinalidade = A102DocDicionarioFinalidade;
            Z119DocDicionarioTipoTransfInterGa = A119DocDicionarioTipoTransfInterGa;
            Z99DocDicionarioSensivel = A99DocDicionarioSensivel;
            Z100DocDicionarioPodeEliminar = A100DocDicionarioPodeEliminar;
            Z101DocDicionarioTransfInter = A101DocDicionarioTransfInter;
            Z103DocDicionarioDataInclusao = A103DocDicionarioDataInclusao;
            Z69InformacaoId = A69InformacaoId;
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
            Z75DocumentoId = A75DocumentoId;
            Z70InformacaoNome = A70InformacaoNome;
            Z73HipoteseTratamentoNome = A73HipoteseTratamentoNome;
            Z76DocumentoNome = A76DocumentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV33Pgmname = "DocDicionario_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A103DocDicionarioDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W43( )
      {
         /* Using cursor BC000W7 */
         pr_default.execute(5, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound43 = 1;
            A102DocDicionarioFinalidade = BC000W7_A102DocDicionarioFinalidade[0];
            A119DocDicionarioTipoTransfInterGa = BC000W7_A119DocDicionarioTipoTransfInterGa[0];
            A99DocDicionarioSensivel = BC000W7_A99DocDicionarioSensivel[0];
            A100DocDicionarioPodeEliminar = BC000W7_A100DocDicionarioPodeEliminar[0];
            A101DocDicionarioTransfInter = BC000W7_A101DocDicionarioTransfInter[0];
            A103DocDicionarioDataInclusao = BC000W7_A103DocDicionarioDataInclusao[0];
            A70InformacaoNome = BC000W7_A70InformacaoNome[0];
            A73HipoteseTratamentoNome = BC000W7_A73HipoteseTratamentoNome[0];
            A76DocumentoNome = BC000W7_A76DocumentoNome[0];
            n76DocumentoNome = BC000W7_n76DocumentoNome[0];
            A69InformacaoId = BC000W7_A69InformacaoId[0];
            A72HipoteseTratamentoId = BC000W7_A72HipoteseTratamentoId[0];
            A75DocumentoId = BC000W7_A75DocumentoId[0];
            ZM0W43( -7) ;
         }
         pr_default.close(5);
         OnLoadActions0W43( ) ;
      }

      protected void OnLoadActions0W43( )
      {
         A102DocDicionarioFinalidade = StringUtil.Upper( A102DocDicionarioFinalidade);
         A119DocDicionarioTipoTransfInterGa = StringUtil.Upper( A119DocDicionarioTipoTransfInterGa);
      }

      protected void CheckExtendedTable0W43( )
      {
         nIsDirty_43 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000W4 */
         pr_default.execute(2, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Informacao'.", "ForeignKeyNotFound", 1, "INFORMACAOID");
            AnyError = 1;
         }
         A70InformacaoNome = BC000W4_A70InformacaoNome[0];
         pr_default.close(2);
         /* Using cursor BC000W5 */
         pr_default.execute(3, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Hipotese Tratamento'.", "ForeignKeyNotFound", 1, "HIPOTESETRATAMENTOID");
            AnyError = 1;
         }
         A73HipoteseTratamentoNome = BC000W5_A73HipoteseTratamentoNome[0];
         pr_default.close(3);
         nIsDirty_43 = 1;
         A102DocDicionarioFinalidade = StringUtil.Upper( A102DocDicionarioFinalidade);
         if ( ! ( (DateTime.MinValue==A103DocDicionarioDataInclusao) || ( DateTimeUtil.ResetTime ( A103DocDicionarioDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Data de Inclusão fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000W6 */
         pr_default.execute(4, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         A76DocumentoNome = BC000W6_A76DocumentoNome[0];
         n76DocumentoNome = BC000W6_n76DocumentoNome[0];
         pr_default.close(4);
         nIsDirty_43 = 1;
         A119DocDicionarioTipoTransfInterGa = StringUtil.Upper( A119DocDicionarioTipoTransfInterGa);
      }

      protected void CloseExtendedTableCursors0W43( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0W43( )
      {
         /* Using cursor BC000W8 */
         pr_default.execute(6, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000W3 */
         pr_default.execute(1, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W43( 7) ;
            RcdFound43 = 1;
            A98DocDicionarioId = BC000W3_A98DocDicionarioId[0];
            A102DocDicionarioFinalidade = BC000W3_A102DocDicionarioFinalidade[0];
            A119DocDicionarioTipoTransfInterGa = BC000W3_A119DocDicionarioTipoTransfInterGa[0];
            A99DocDicionarioSensivel = BC000W3_A99DocDicionarioSensivel[0];
            A100DocDicionarioPodeEliminar = BC000W3_A100DocDicionarioPodeEliminar[0];
            A101DocDicionarioTransfInter = BC000W3_A101DocDicionarioTransfInter[0];
            A103DocDicionarioDataInclusao = BC000W3_A103DocDicionarioDataInclusao[0];
            A69InformacaoId = BC000W3_A69InformacaoId[0];
            A72HipoteseTratamentoId = BC000W3_A72HipoteseTratamentoId[0];
            A75DocumentoId = BC000W3_A75DocumentoId[0];
            Z98DocDicionarioId = A98DocDicionarioId;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0W43( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey0W43( ) ;
            }
            Gx_mode = sMode43;
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey0W43( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode43;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W43( ) ;
         if ( RcdFound43 == 0 )
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
         CONFIRM_0W0( ) ;
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

      protected void CheckOptimisticConcurrency0W43( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W2 */
            pr_default.execute(0, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocDicionario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z99DocDicionarioSensivel != BC000W2_A99DocDicionarioSensivel[0] ) || ( Z100DocDicionarioPodeEliminar != BC000W2_A100DocDicionarioPodeEliminar[0] ) || ( Z101DocDicionarioTransfInter != BC000W2_A101DocDicionarioTransfInter[0] ) || ( DateTimeUtil.ResetTime ( Z103DocDicionarioDataInclusao ) != DateTimeUtil.ResetTime ( BC000W2_A103DocDicionarioDataInclusao[0] ) ) || ( Z69InformacaoId != BC000W2_A69InformacaoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z72HipoteseTratamentoId != BC000W2_A72HipoteseTratamentoId[0] ) || ( Z75DocumentoId != BC000W2_A75DocumentoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocDicionario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W43( )
      {
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W43( 0) ;
            CheckOptimisticConcurrency0W43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W9 */
                     pr_default.execute(7, new Object[] {A102DocDicionarioFinalidade, A119DocDicionarioTipoTransfInterGa, A99DocDicionarioSensivel, A100DocDicionarioPodeEliminar, A101DocDicionarioTransfInter, A103DocDicionarioDataInclusao, A69InformacaoId, A72HipoteseTratamentoId, A75DocumentoId});
                     A98DocDicionarioId = BC000W9_A98DocDicionarioId[0];
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("DocDicionario");
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
               Load0W43( ) ;
            }
            EndLevel0W43( ) ;
         }
         CloseExtendedTableCursors0W43( ) ;
      }

      protected void Update0W43( )
      {
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W10 */
                     pr_default.execute(8, new Object[] {A102DocDicionarioFinalidade, A119DocDicionarioTipoTransfInterGa, A99DocDicionarioSensivel, A100DocDicionarioPodeEliminar, A101DocDicionarioTransfInter, A103DocDicionarioDataInclusao, A69InformacaoId, A72HipoteseTratamentoId, A75DocumentoId, A98DocDicionarioId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("DocDicionario");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocDicionario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W43( ) ;
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
            EndLevel0W43( ) ;
         }
         CloseExtendedTableCursors0W43( ) ;
      }

      protected void DeferredUpdate0W43( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W43( ) ;
            AfterConfirm0W43( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W43( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W11 */
                  pr_default.execute(9, new Object[] {A98DocDicionarioId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("DocDicionario");
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W43( ) ;
         Gx_mode = sMode43;
      }

      protected void OnDeleteControls0W43( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000W12 */
            pr_default.execute(10, new Object[] {A69InformacaoId});
            A70InformacaoNome = BC000W12_A70InformacaoNome[0];
            pr_default.close(10);
            /* Using cursor BC000W13 */
            pr_default.execute(11, new Object[] {A72HipoteseTratamentoId});
            A73HipoteseTratamentoNome = BC000W13_A73HipoteseTratamentoNome[0];
            pr_default.close(11);
            /* Using cursor BC000W14 */
            pr_default.execute(12, new Object[] {A75DocumentoId});
            A76DocumentoNome = BC000W14_A76DocumentoNome[0];
            n76DocumentoNome = BC000W14_n76DocumentoNome[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000W15 */
            pr_default.execute(13, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DicionarioPais"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000W16 */
            pr_default.execute(14, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DicionarioCompartTercExt"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0W43( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W43( ) ;
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

      public void ScanKeyStart0W43( )
      {
         /* Scan By routine */
         /* Using cursor BC000W17 */
         pr_default.execute(15, new Object[] {A98DocDicionarioId});
         RcdFound43 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound43 = 1;
            A98DocDicionarioId = BC000W17_A98DocDicionarioId[0];
            A102DocDicionarioFinalidade = BC000W17_A102DocDicionarioFinalidade[0];
            A119DocDicionarioTipoTransfInterGa = BC000W17_A119DocDicionarioTipoTransfInterGa[0];
            A99DocDicionarioSensivel = BC000W17_A99DocDicionarioSensivel[0];
            A100DocDicionarioPodeEliminar = BC000W17_A100DocDicionarioPodeEliminar[0];
            A101DocDicionarioTransfInter = BC000W17_A101DocDicionarioTransfInter[0];
            A103DocDicionarioDataInclusao = BC000W17_A103DocDicionarioDataInclusao[0];
            A70InformacaoNome = BC000W17_A70InformacaoNome[0];
            A73HipoteseTratamentoNome = BC000W17_A73HipoteseTratamentoNome[0];
            A76DocumentoNome = BC000W17_A76DocumentoNome[0];
            n76DocumentoNome = BC000W17_n76DocumentoNome[0];
            A69InformacaoId = BC000W17_A69InformacaoId[0];
            A72HipoteseTratamentoId = BC000W17_A72HipoteseTratamentoId[0];
            A75DocumentoId = BC000W17_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W43( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound43 = 0;
         ScanKeyLoad0W43( ) ;
      }

      protected void ScanKeyLoad0W43( )
      {
         sMode43 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound43 = 1;
            A98DocDicionarioId = BC000W17_A98DocDicionarioId[0];
            A102DocDicionarioFinalidade = BC000W17_A102DocDicionarioFinalidade[0];
            A119DocDicionarioTipoTransfInterGa = BC000W17_A119DocDicionarioTipoTransfInterGa[0];
            A99DocDicionarioSensivel = BC000W17_A99DocDicionarioSensivel[0];
            A100DocDicionarioPodeEliminar = BC000W17_A100DocDicionarioPodeEliminar[0];
            A101DocDicionarioTransfInter = BC000W17_A101DocDicionarioTransfInter[0];
            A103DocDicionarioDataInclusao = BC000W17_A103DocDicionarioDataInclusao[0];
            A70InformacaoNome = BC000W17_A70InformacaoNome[0];
            A73HipoteseTratamentoNome = BC000W17_A73HipoteseTratamentoNome[0];
            A76DocumentoNome = BC000W17_A76DocumentoNome[0];
            n76DocumentoNome = BC000W17_n76DocumentoNome[0];
            A69InformacaoId = BC000W17_A69InformacaoId[0];
            A72HipoteseTratamentoId = BC000W17_A72HipoteseTratamentoId[0];
            A75DocumentoId = BC000W17_A75DocumentoId[0];
         }
         Gx_mode = sMode43;
      }

      protected void ScanKeyEnd0W43( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0W43( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W43( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W43( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W43( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W43( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W43( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W43( )
      {
      }

      protected void send_integrity_lvl_hashes0W43( )
      {
      }

      protected void AddRow0W43( )
      {
         VarsToRow43( bcDocDicionario) ;
      }

      protected void ReadRow0W43( )
      {
         RowToVars43( bcDocDicionario, 1) ;
      }

      protected void InitializeNonKey0W43( )
      {
         A102DocDicionarioFinalidade = "";
         A119DocDicionarioTipoTransfInterGa = "";
         A69InformacaoId = 0;
         A72HipoteseTratamentoId = 0;
         A99DocDicionarioSensivel = false;
         A100DocDicionarioPodeEliminar = false;
         A101DocDicionarioTransfInter = false;
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A75DocumentoId = 0;
         A76DocumentoNome = "";
         n76DocumentoNome = false;
         A103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         Z99DocDicionarioSensivel = false;
         Z100DocDicionarioPodeEliminar = false;
         Z101DocDicionarioTransfInter = false;
         Z103DocDicionarioDataInclusao = DateTime.MinValue;
         Z69InformacaoId = 0;
         Z72HipoteseTratamentoId = 0;
         Z75DocumentoId = 0;
      }

      protected void InitAll0W43( )
      {
         A98DocDicionarioId = 0;
         InitializeNonKey0W43( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A103DocDicionarioDataInclusao = i103DocDicionarioDataInclusao;
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

      public void VarsToRow43( SdtDocDicionario obj43 )
      {
         obj43.gxTpr_Mode = Gx_mode;
         obj43.gxTpr_Docdicionariofinalidade = A102DocDicionarioFinalidade;
         obj43.gxTpr_Docdicionariotipotransfintergarantia = A119DocDicionarioTipoTransfInterGa;
         obj43.gxTpr_Informacaoid = A69InformacaoId;
         obj43.gxTpr_Hipotesetratamentoid = A72HipoteseTratamentoId;
         obj43.gxTpr_Docdicionariosensivel = A99DocDicionarioSensivel;
         obj43.gxTpr_Docdicionariopodeeliminar = A100DocDicionarioPodeEliminar;
         obj43.gxTpr_Docdicionariotransfinter = A101DocDicionarioTransfInter;
         obj43.gxTpr_Informacaonome = A70InformacaoNome;
         obj43.gxTpr_Hipotesetratamentonome = A73HipoteseTratamentoNome;
         obj43.gxTpr_Documentoid = A75DocumentoId;
         obj43.gxTpr_Documentonome = A76DocumentoNome;
         obj43.gxTpr_Docdicionariodatainclusao = A103DocDicionarioDataInclusao;
         obj43.gxTpr_Docdicionarioid = A98DocDicionarioId;
         obj43.gxTpr_Docdicionarioid_Z = Z98DocDicionarioId;
         obj43.gxTpr_Informacaoid_Z = Z69InformacaoId;
         obj43.gxTpr_Hipotesetratamentoid_Z = Z72HipoteseTratamentoId;
         obj43.gxTpr_Docdicionariosensivel_Z = Z99DocDicionarioSensivel;
         obj43.gxTpr_Docdicionariopodeeliminar_Z = Z100DocDicionarioPodeEliminar;
         obj43.gxTpr_Docdicionariotransfinter_Z = Z101DocDicionarioTransfInter;
         obj43.gxTpr_Docdicionariodatainclusao_Z = Z103DocDicionarioDataInclusao;
         obj43.gxTpr_Informacaonome_Z = Z70InformacaoNome;
         obj43.gxTpr_Hipotesetratamentonome_Z = Z73HipoteseTratamentoNome;
         obj43.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj43.gxTpr_Documentonome_Z = Z76DocumentoNome;
         obj43.gxTpr_Documentonome_N = (short)(Convert.ToInt16(n76DocumentoNome));
         obj43.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow43( SdtDocDicionario obj43 )
      {
         obj43.gxTpr_Docdicionarioid = A98DocDicionarioId;
         return  ;
      }

      public void RowToVars43( SdtDocDicionario obj43 ,
                               int forceLoad )
      {
         Gx_mode = obj43.gxTpr_Mode;
         A102DocDicionarioFinalidade = obj43.gxTpr_Docdicionariofinalidade;
         A119DocDicionarioTipoTransfInterGa = obj43.gxTpr_Docdicionariotipotransfintergarantia;
         A69InformacaoId = obj43.gxTpr_Informacaoid;
         A72HipoteseTratamentoId = obj43.gxTpr_Hipotesetratamentoid;
         A99DocDicionarioSensivel = obj43.gxTpr_Docdicionariosensivel;
         A100DocDicionarioPodeEliminar = obj43.gxTpr_Docdicionariopodeeliminar;
         A101DocDicionarioTransfInter = obj43.gxTpr_Docdicionariotransfinter;
         A70InformacaoNome = obj43.gxTpr_Informacaonome;
         A73HipoteseTratamentoNome = obj43.gxTpr_Hipotesetratamentonome;
         A75DocumentoId = obj43.gxTpr_Documentoid;
         A76DocumentoNome = obj43.gxTpr_Documentonome;
         n76DocumentoNome = false;
         A103DocDicionarioDataInclusao = obj43.gxTpr_Docdicionariodatainclusao;
         A98DocDicionarioId = obj43.gxTpr_Docdicionarioid;
         Z98DocDicionarioId = obj43.gxTpr_Docdicionarioid_Z;
         Z69InformacaoId = obj43.gxTpr_Informacaoid_Z;
         Z72HipoteseTratamentoId = obj43.gxTpr_Hipotesetratamentoid_Z;
         Z99DocDicionarioSensivel = obj43.gxTpr_Docdicionariosensivel_Z;
         Z100DocDicionarioPodeEliminar = obj43.gxTpr_Docdicionariopodeeliminar_Z;
         Z101DocDicionarioTransfInter = obj43.gxTpr_Docdicionariotransfinter_Z;
         Z103DocDicionarioDataInclusao = obj43.gxTpr_Docdicionariodatainclusao_Z;
         Z70InformacaoNome = obj43.gxTpr_Informacaonome_Z;
         Z73HipoteseTratamentoNome = obj43.gxTpr_Hipotesetratamentonome_Z;
         Z75DocumentoId = obj43.gxTpr_Documentoid_Z;
         Z76DocumentoNome = obj43.gxTpr_Documentonome_Z;
         n76DocumentoNome = (bool)(Convert.ToBoolean(obj43.gxTpr_Documentonome_N));
         Gx_mode = obj43.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A98DocDicionarioId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0W43( ) ;
         ScanKeyStart0W43( ) ;
         if ( RcdFound43 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98DocDicionarioId = A98DocDicionarioId;
         }
         ZM0W43( -7) ;
         OnLoadActions0W43( ) ;
         AddRow0W43( ) ;
         ScanKeyEnd0W43( ) ;
         if ( RcdFound43 == 0 )
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
         RowToVars43( bcDocDicionario, 0) ;
         ScanKeyStart0W43( ) ;
         if ( RcdFound43 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98DocDicionarioId = A98DocDicionarioId;
         }
         ZM0W43( -7) ;
         OnLoadActions0W43( ) ;
         AddRow0W43( ) ;
         ScanKeyEnd0W43( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0W43( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0W43( ) ;
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( A98DocDicionarioId != Z98DocDicionarioId )
               {
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
                  Update0W43( ) ;
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
                  if ( A98DocDicionarioId != Z98DocDicionarioId )
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
                        Insert0W43( ) ;
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
                        Insert0W43( ) ;
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
         RowToVars43( bcDocDicionario, 1) ;
         SaveImpl( ) ;
         VarsToRow43( bcDocDicionario) ;
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
         RowToVars43( bcDocDicionario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W43( ) ;
         AfterTrn( ) ;
         VarsToRow43( bcDocDicionario) ;
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
            SdtDocDicionario auxBC = new SdtDocDicionario(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A98DocDicionarioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocDicionario);
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
         RowToVars43( bcDocDicionario, 1) ;
         UpdateImpl( ) ;
         VarsToRow43( bcDocDicionario) ;
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
         RowToVars43( bcDocDicionario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W43( ) ;
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
         VarsToRow43( bcDocDicionario) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars43( bcDocDicionario, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0W43( ) ;
         if ( RcdFound43 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A98DocDicionarioId != Z98DocDicionarioId )
            {
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
            if ( A98DocDicionarioId != Z98DocDicionarioId )
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
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
         context.RollbackDataStores("docdicionario_bc",pr_default);
         VarsToRow43( bcDocDicionario) ;
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
         Gx_mode = bcDocDicionario.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocDicionario.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocDicionario )
         {
            bcDocDicionario = (SdtDocDicionario)(sdt);
            if ( StringUtil.StrCmp(bcDocDicionario.gxTpr_Mode, "") == 0 )
            {
               bcDocDicionario.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow43( bcDocDicionario) ;
            }
            else
            {
               RowToVars43( bcDocDicionario, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocDicionario.gxTpr_Mode, "") == 0 )
            {
               bcDocDicionario.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars43( bcDocDicionario, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocDicionario DocDicionario_BC
      {
         get {
            return bcDocDicionario ;
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
            return "docdicionario_Execute" ;
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
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
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
         AV33Pgmname = "";
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z103DocDicionarioDataInclusao = DateTime.MinValue;
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         Z70InformacaoNome = "";
         A70InformacaoNome = "";
         Z73HipoteseTratamentoNome = "";
         A73HipoteseTratamentoNome = "";
         Z76DocumentoNome = "";
         A76DocumentoNome = "";
         Z102DocDicionarioFinalidade = "";
         A102DocDicionarioFinalidade = "";
         Z119DocDicionarioTipoTransfInterGa = "";
         A119DocDicionarioTipoTransfInterGa = "";
         BC000W7_A98DocDicionarioId = new int[1] ;
         BC000W7_A102DocDicionarioFinalidade = new string[] {""} ;
         BC000W7_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         BC000W7_A99DocDicionarioSensivel = new bool[] {false} ;
         BC000W7_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         BC000W7_A101DocDicionarioTransfInter = new bool[] {false} ;
         BC000W7_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC000W7_A70InformacaoNome = new string[] {""} ;
         BC000W7_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000W7_A76DocumentoNome = new string[] {""} ;
         BC000W7_n76DocumentoNome = new bool[] {false} ;
         BC000W7_A69InformacaoId = new int[1] ;
         BC000W7_A72HipoteseTratamentoId = new int[1] ;
         BC000W7_A75DocumentoId = new int[1] ;
         BC000W4_A70InformacaoNome = new string[] {""} ;
         BC000W5_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000W6_A76DocumentoNome = new string[] {""} ;
         BC000W6_n76DocumentoNome = new bool[] {false} ;
         BC000W8_A98DocDicionarioId = new int[1] ;
         BC000W3_A98DocDicionarioId = new int[1] ;
         BC000W3_A102DocDicionarioFinalidade = new string[] {""} ;
         BC000W3_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         BC000W3_A99DocDicionarioSensivel = new bool[] {false} ;
         BC000W3_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         BC000W3_A101DocDicionarioTransfInter = new bool[] {false} ;
         BC000W3_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC000W3_A69InformacaoId = new int[1] ;
         BC000W3_A72HipoteseTratamentoId = new int[1] ;
         BC000W3_A75DocumentoId = new int[1] ;
         sMode43 = "";
         BC000W2_A98DocDicionarioId = new int[1] ;
         BC000W2_A102DocDicionarioFinalidade = new string[] {""} ;
         BC000W2_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         BC000W2_A99DocDicionarioSensivel = new bool[] {false} ;
         BC000W2_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         BC000W2_A101DocDicionarioTransfInter = new bool[] {false} ;
         BC000W2_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC000W2_A69InformacaoId = new int[1] ;
         BC000W2_A72HipoteseTratamentoId = new int[1] ;
         BC000W2_A75DocumentoId = new int[1] ;
         BC000W9_A98DocDicionarioId = new int[1] ;
         BC000W12_A70InformacaoNome = new string[] {""} ;
         BC000W13_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000W14_A76DocumentoNome = new string[] {""} ;
         BC000W14_n76DocumentoNome = new bool[] {false} ;
         BC000W15_A4PaisId = new int[1] ;
         BC000W15_A98DocDicionarioId = new int[1] ;
         BC000W16_A66CompartTercExternoId = new int[1] ;
         BC000W16_A98DocDicionarioId = new int[1] ;
         BC000W17_A98DocDicionarioId = new int[1] ;
         BC000W17_A102DocDicionarioFinalidade = new string[] {""} ;
         BC000W17_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         BC000W17_A99DocDicionarioSensivel = new bool[] {false} ;
         BC000W17_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         BC000W17_A101DocDicionarioTransfInter = new bool[] {false} ;
         BC000W17_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC000W17_A70InformacaoNome = new string[] {""} ;
         BC000W17_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000W17_A76DocumentoNome = new string[] {""} ;
         BC000W17_n76DocumentoNome = new bool[] {false} ;
         BC000W17_A69InformacaoId = new int[1] ;
         BC000W17_A72HipoteseTratamentoId = new int[1] ;
         BC000W17_A75DocumentoId = new int[1] ;
         i103DocDicionarioDataInclusao = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docdicionario_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionario_bc__default(),
            new Object[][] {
                new Object[] {
               BC000W2_A98DocDicionarioId, BC000W2_A102DocDicionarioFinalidade, BC000W2_A119DocDicionarioTipoTransfInterGa, BC000W2_A99DocDicionarioSensivel, BC000W2_A100DocDicionarioPodeEliminar, BC000W2_A101DocDicionarioTransfInter, BC000W2_A103DocDicionarioDataInclusao, BC000W2_A69InformacaoId, BC000W2_A72HipoteseTratamentoId, BC000W2_A75DocumentoId
               }
               , new Object[] {
               BC000W3_A98DocDicionarioId, BC000W3_A102DocDicionarioFinalidade, BC000W3_A119DocDicionarioTipoTransfInterGa, BC000W3_A99DocDicionarioSensivel, BC000W3_A100DocDicionarioPodeEliminar, BC000W3_A101DocDicionarioTransfInter, BC000W3_A103DocDicionarioDataInclusao, BC000W3_A69InformacaoId, BC000W3_A72HipoteseTratamentoId, BC000W3_A75DocumentoId
               }
               , new Object[] {
               BC000W4_A70InformacaoNome
               }
               , new Object[] {
               BC000W5_A73HipoteseTratamentoNome
               }
               , new Object[] {
               BC000W6_A76DocumentoNome, BC000W6_n76DocumentoNome
               }
               , new Object[] {
               BC000W7_A98DocDicionarioId, BC000W7_A102DocDicionarioFinalidade, BC000W7_A119DocDicionarioTipoTransfInterGa, BC000W7_A99DocDicionarioSensivel, BC000W7_A100DocDicionarioPodeEliminar, BC000W7_A101DocDicionarioTransfInter, BC000W7_A103DocDicionarioDataInclusao, BC000W7_A70InformacaoNome, BC000W7_A73HipoteseTratamentoNome, BC000W7_A76DocumentoNome,
               BC000W7_n76DocumentoNome, BC000W7_A69InformacaoId, BC000W7_A72HipoteseTratamentoId, BC000W7_A75DocumentoId
               }
               , new Object[] {
               BC000W8_A98DocDicionarioId
               }
               , new Object[] {
               BC000W9_A98DocDicionarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W12_A70InformacaoNome
               }
               , new Object[] {
               BC000W13_A73HipoteseTratamentoNome
               }
               , new Object[] {
               BC000W14_A76DocumentoNome, BC000W14_n76DocumentoNome
               }
               , new Object[] {
               BC000W15_A4PaisId, BC000W15_A98DocDicionarioId
               }
               , new Object[] {
               BC000W16_A66CompartTercExternoId, BC000W16_A98DocDicionarioId
               }
               , new Object[] {
               BC000W17_A98DocDicionarioId, BC000W17_A102DocDicionarioFinalidade, BC000W17_A119DocDicionarioTipoTransfInterGa, BC000W17_A99DocDicionarioSensivel, BC000W17_A100DocDicionarioPodeEliminar, BC000W17_A101DocDicionarioTransfInter, BC000W17_A103DocDicionarioDataInclusao, BC000W17_A70InformacaoNome, BC000W17_A73HipoteseTratamentoNome, BC000W17_A76DocumentoNome,
               BC000W17_n76DocumentoNome, BC000W17_A69InformacaoId, BC000W17_A72HipoteseTratamentoId, BC000W17_A75DocumentoId
               }
            }
         );
         AV33Pgmname = "DocDicionario_BC";
         Z103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         A103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         i103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120W2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound43 ;
      private short nIsDirty_43 ;
      private int trnEnded ;
      private int Z98DocDicionarioId ;
      private int A98DocDicionarioId ;
      private int AV34GXV1 ;
      private int AV14Insert_InformacaoId ;
      private int AV15Insert_HipoteseTratamentoId ;
      private int AV13Insert_DocumentoId ;
      private int Z69InformacaoId ;
      private int A69InformacaoId ;
      private int Z72HipoteseTratamentoId ;
      private int A72HipoteseTratamentoId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV33Pgmname ;
      private string sMode43 ;
      private DateTime Z103DocDicionarioDataInclusao ;
      private DateTime A103DocDicionarioDataInclusao ;
      private DateTime i103DocDicionarioDataInclusao ;
      private bool returnInSub ;
      private bool Z99DocDicionarioSensivel ;
      private bool A99DocDicionarioSensivel ;
      private bool Z100DocDicionarioPodeEliminar ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool Z101DocDicionarioTransfInter ;
      private bool A101DocDicionarioTransfInter ;
      private bool n76DocumentoNome ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z102DocDicionarioFinalidade ;
      private string A102DocDicionarioFinalidade ;
      private string Z119DocDicionarioTipoTransfInterGa ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string Z70InformacaoNome ;
      private string A70InformacaoNome ;
      private string Z73HipoteseTratamentoNome ;
      private string A73HipoteseTratamentoNome ;
      private string Z76DocumentoNome ;
      private string A76DocumentoNome ;
      private IGxSession AV12WebSession ;
      private SdtDocDicionario bcDocDicionario ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000W7_A98DocDicionarioId ;
      private string[] BC000W7_A102DocDicionarioFinalidade ;
      private string[] BC000W7_A119DocDicionarioTipoTransfInterGa ;
      private bool[] BC000W7_A99DocDicionarioSensivel ;
      private bool[] BC000W7_A100DocDicionarioPodeEliminar ;
      private bool[] BC000W7_A101DocDicionarioTransfInter ;
      private DateTime[] BC000W7_A103DocDicionarioDataInclusao ;
      private string[] BC000W7_A70InformacaoNome ;
      private string[] BC000W7_A73HipoteseTratamentoNome ;
      private string[] BC000W7_A76DocumentoNome ;
      private bool[] BC000W7_n76DocumentoNome ;
      private int[] BC000W7_A69InformacaoId ;
      private int[] BC000W7_A72HipoteseTratamentoId ;
      private int[] BC000W7_A75DocumentoId ;
      private string[] BC000W4_A70InformacaoNome ;
      private string[] BC000W5_A73HipoteseTratamentoNome ;
      private string[] BC000W6_A76DocumentoNome ;
      private bool[] BC000W6_n76DocumentoNome ;
      private int[] BC000W8_A98DocDicionarioId ;
      private int[] BC000W3_A98DocDicionarioId ;
      private string[] BC000W3_A102DocDicionarioFinalidade ;
      private string[] BC000W3_A119DocDicionarioTipoTransfInterGa ;
      private bool[] BC000W3_A99DocDicionarioSensivel ;
      private bool[] BC000W3_A100DocDicionarioPodeEliminar ;
      private bool[] BC000W3_A101DocDicionarioTransfInter ;
      private DateTime[] BC000W3_A103DocDicionarioDataInclusao ;
      private int[] BC000W3_A69InformacaoId ;
      private int[] BC000W3_A72HipoteseTratamentoId ;
      private int[] BC000W3_A75DocumentoId ;
      private int[] BC000W2_A98DocDicionarioId ;
      private string[] BC000W2_A102DocDicionarioFinalidade ;
      private string[] BC000W2_A119DocDicionarioTipoTransfInterGa ;
      private bool[] BC000W2_A99DocDicionarioSensivel ;
      private bool[] BC000W2_A100DocDicionarioPodeEliminar ;
      private bool[] BC000W2_A101DocDicionarioTransfInter ;
      private DateTime[] BC000W2_A103DocDicionarioDataInclusao ;
      private int[] BC000W2_A69InformacaoId ;
      private int[] BC000W2_A72HipoteseTratamentoId ;
      private int[] BC000W2_A75DocumentoId ;
      private int[] BC000W9_A98DocDicionarioId ;
      private string[] BC000W12_A70InformacaoNome ;
      private string[] BC000W13_A73HipoteseTratamentoNome ;
      private string[] BC000W14_A76DocumentoNome ;
      private bool[] BC000W14_n76DocumentoNome ;
      private int[] BC000W15_A4PaisId ;
      private int[] BC000W15_A98DocDicionarioId ;
      private int[] BC000W16_A66CompartTercExternoId ;
      private int[] BC000W16_A98DocDicionarioId ;
      private int[] BC000W17_A98DocDicionarioId ;
      private string[] BC000W17_A102DocDicionarioFinalidade ;
      private string[] BC000W17_A119DocDicionarioTipoTransfInterGa ;
      private bool[] BC000W17_A99DocDicionarioSensivel ;
      private bool[] BC000W17_A100DocDicionarioPodeEliminar ;
      private bool[] BC000W17_A101DocDicionarioTransfInter ;
      private DateTime[] BC000W17_A103DocDicionarioDataInclusao ;
      private string[] BC000W17_A70InformacaoNome ;
      private string[] BC000W17_A73HipoteseTratamentoNome ;
      private string[] BC000W17_A76DocumentoNome ;
      private bool[] BC000W17_n76DocumentoNome ;
      private int[] BC000W17_A69InformacaoId ;
      private int[] BC000W17_A72HipoteseTratamentoId ;
      private int[] BC000W17_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class docdicionario_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docdicionario_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000W7;
        prmBC000W7 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W4;
        prmBC000W4 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W5;
        prmBC000W5 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W6;
        prmBC000W6 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W8;
        prmBC000W8 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W3;
        prmBC000W3 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W2;
        prmBC000W2 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W9;
        prmBC000W9 = new Object[] {
        new ParDef("@DocDicionarioFinalidade",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioTipoTransfInterGa",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioSensivel",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioPodeEliminar",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioTransfInter",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioDataInclusao",GXType.Date,8,0) ,
        new ParDef("@InformacaoId",GXType.Int32,8,0) ,
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W10;
        prmBC000W10 = new Object[] {
        new ParDef("@DocDicionarioFinalidade",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioTipoTransfInterGa",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioSensivel",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioPodeEliminar",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioTransfInter",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioDataInclusao",GXType.Date,8,0) ,
        new ParDef("@InformacaoId",GXType.Int32,8,0) ,
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W11;
        prmBC000W11 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W12;
        prmBC000W12 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W13;
        prmBC000W13 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W14;
        prmBC000W14 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000W15;
        prmBC000W15 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W16;
        prmBC000W16 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmBC000W17;
        prmBC000W17 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000W2", "SELECT [DocDicionarioId], [DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioSensivel], [DocDicionarioPodeEliminar], [DocDicionarioTransfInter], [DocDicionarioDataInclusao], [InformacaoId], [HipoteseTratamentoId], [DocumentoId] FROM [DocDicionario] WITH (UPDLOCK) WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W3", "SELECT [DocDicionarioId], [DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioSensivel], [DocDicionarioPodeEliminar], [DocDicionarioTransfInter], [DocDicionarioDataInclusao], [InformacaoId], [HipoteseTratamentoId], [DocumentoId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W4", "SELECT [InformacaoNome] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W5", "SELECT [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W6", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W7", "SELECT TM1.[DocDicionarioId], TM1.[DocDicionarioFinalidade], TM1.[DocDicionarioTipoTransfInterGa], TM1.[DocDicionarioSensivel], TM1.[DocDicionarioPodeEliminar], TM1.[DocDicionarioTransfInter], TM1.[DocDicionarioDataInclusao], T2.[InformacaoNome], T3.[HipoteseTratamentoNome], T4.[DocumentoNome], TM1.[InformacaoId], TM1.[HipoteseTratamentoId], TM1.[DocumentoId] FROM ((([DocDicionario] TM1 INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = TM1.[InformacaoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = TM1.[HipoteseTratamentoId]) INNER JOIN [Documento] T4 ON T4.[DocumentoId] = TM1.[DocumentoId]) WHERE TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W8", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W9", "INSERT INTO [DocDicionario]([DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioSensivel], [DocDicionarioPodeEliminar], [DocDicionarioTransfInter], [DocDicionarioDataInclusao], [InformacaoId], [HipoteseTratamentoId], [DocumentoId]) VALUES(@DocDicionarioFinalidade, @DocDicionarioTipoTransfInterGa, @DocDicionarioSensivel, @DocDicionarioPodeEliminar, @DocDicionarioTransfInter, @DocDicionarioDataInclusao, @InformacaoId, @HipoteseTratamentoId, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000W10", "UPDATE [DocDicionario] SET [DocDicionarioFinalidade]=@DocDicionarioFinalidade, [DocDicionarioTipoTransfInterGa]=@DocDicionarioTipoTransfInterGa, [DocDicionarioSensivel]=@DocDicionarioSensivel, [DocDicionarioPodeEliminar]=@DocDicionarioPodeEliminar, [DocDicionarioTransfInter]=@DocDicionarioTransfInter, [DocDicionarioDataInclusao]=@DocDicionarioDataInclusao, [InformacaoId]=@InformacaoId, [HipoteseTratamentoId]=@HipoteseTratamentoId, [DocumentoId]=@DocumentoId  WHERE [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmBC000W10)
           ,new CursorDef("BC000W11", "DELETE FROM [DocDicionario]  WHERE [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmBC000W11)
           ,new CursorDef("BC000W12", "SELECT [InformacaoNome] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W13", "SELECT [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W14", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W15", "SELECT TOP 1 [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000W16", "SELECT TOP 1 [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000W17", "SELECT TM1.[DocDicionarioId], TM1.[DocDicionarioFinalidade], TM1.[DocDicionarioTipoTransfInterGa], TM1.[DocDicionarioSensivel], TM1.[DocDicionarioPodeEliminar], TM1.[DocDicionarioTransfInter], TM1.[DocDicionarioDataInclusao], T2.[InformacaoNome], T3.[HipoteseTratamentoNome], T4.[DocumentoNome], TM1.[InformacaoId], TM1.[HipoteseTratamentoId], TM1.[DocumentoId] FROM ((([DocDicionario] TM1 INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = TM1.[InformacaoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = TM1.[HipoteseTratamentoId]) INNER JOIN [Documento] T4 ON T4.[DocumentoId] = TM1.[DocumentoId]) WHERE TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W17,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              return;
     }
  }

}

}
