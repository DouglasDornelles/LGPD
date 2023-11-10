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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class revisaologwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public revisaologwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaologwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         revisaologwwexportreport objrevisaologwwexportreport;
         objrevisaologwwexportreport = new revisaologwwexportreport();
         objrevisaologwwexportreport.context.SetSubmitInitialConfig(context);
         objrevisaologwwexportreport.initialize();
         Submit( executePrivateCatch,objrevisaologwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((revisaologwwexportreport)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "revisaologww_Execute", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV42Title = "Lista de Revisao Log";
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H720( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV18TFRevisaoLogId) && (0==AV19TFRevisaoLogId_To) ) )
         {
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Log Id", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18TFRevisaoLogId), "ZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV28TFRevisaoLogId_To_Description = StringUtil.Format( "%1 (%2)", "Log Id", "Até", "", "", "", "", "", "", "");
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TFRevisaoLogId_To_Description, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19TFRevisaoLogId_To), "ZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFRevisaoLogUsuarioAlteracao_Sel)) )
         {
            AV31TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFRevisaoLogUsuarioAlteracao_Sel, "<#Empty#>")==0)));
            AV21TFRevisaoLogUsuarioAlteracao_Sel = (AV31TempBoolean ? "(Vazio)" : AV21TFRevisaoLogUsuarioAlteracao_Sel);
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario Alteracao", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFRevisaoLogUsuarioAlteracao_Sel, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFRevisaoLogUsuarioAlteracao_Sel = (AV31TempBoolean ? "<#Empty#>" : AV21TFRevisaoLogUsuarioAlteracao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFRevisaoLogUsuarioAlteracao)) )
            {
               H720( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario Alteracao", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFRevisaoLogUsuarioAlteracao, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFRevisaoLogObservacao_Sel)) )
         {
            AV31TempBoolean = (bool)(((StringUtil.StrCmp(AV23TFRevisaoLogObservacao_Sel, "<#Empty#>")==0)));
            AV23TFRevisaoLogObservacao_Sel = (AV31TempBoolean ? "(Vazio)" : AV23TFRevisaoLogObservacao_Sel);
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Log Observacao", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFRevisaoLogObservacao_Sel, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV23TFRevisaoLogObservacao_Sel = (AV31TempBoolean ? "<#Empty#>" : AV23TFRevisaoLogObservacao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFRevisaoLogObservacao)) )
            {
               H720( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Log Observacao", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFRevisaoLogObservacao, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV24TFRevisaoLogDataAlteracao) && (DateTime.MinValue==AV25TFRevisaoLogDataAlteracao_To) ) )
         {
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data Alteracao", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV24TFRevisaoLogDataAlteracao, "99/99/99 99:99"), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV29TFRevisaoLogDataAlteracao_To_Description = StringUtil.Format( "%1 (%2)", "Data Alteracao", "Até", "", "", "", "", "", "", "");
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29TFRevisaoLogDataAlteracao_To_Description, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25TFRevisaoLogDataAlteracao_To, "99/99/99 99:99"), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV26TFDocumentoId) && (0==AV27TFDocumentoId_To) ) )
         {
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("do Documento", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV26TFDocumentoId), "ZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV30TFDocumentoId_To_Description = StringUtil.Format( "%1 (%2)", "do Documento", "Até", "", "", "", "", "", "", "");
            H720( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30TFDocumentoId_To_Description, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27TFDocumentoId_To), "ZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H720( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H720( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Log Id", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuario Alteracao", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Log Observacao", 355, Gx_line+10, 567, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data Alteracao", 571, Gx_line+10, 677, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("do Documento", 681, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV49Revisaologwwds_1_filterfulltext = AV13FilterFullText;
         AV50Revisaologwwds_2_tfrevisaologid = AV18TFRevisaoLogId;
         AV51Revisaologwwds_3_tfrevisaologid_to = AV19TFRevisaoLogId_To;
         AV52Revisaologwwds_4_tfrevisaologusuarioalteracao = AV20TFRevisaoLogUsuarioAlteracao;
         AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV21TFRevisaoLogUsuarioAlteracao_Sel;
         AV54Revisaologwwds_6_tfrevisaologobservacao = AV22TFRevisaoLogObservacao;
         AV55Revisaologwwds_7_tfrevisaologobservacao_sel = AV23TFRevisaoLogObservacao_Sel;
         AV56Revisaologwwds_8_tfrevisaologdataalteracao = AV24TFRevisaoLogDataAlteracao;
         AV57Revisaologwwds_9_tfrevisaologdataalteracao_to = AV25TFRevisaoLogDataAlteracao_To;
         AV58Revisaologwwds_10_tfdocumentoid = AV26TFDocumentoId;
         AV59Revisaologwwds_11_tfdocumentoid_to = AV27TFDocumentoId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Revisaologwwds_1_filterfulltext ,
                                              AV50Revisaologwwds_2_tfrevisaologid ,
                                              AV51Revisaologwwds_3_tfrevisaologid_to ,
                                              AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                              AV52Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                              AV55Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                              AV54Revisaologwwds_6_tfrevisaologobservacao ,
                                              AV56Revisaologwwds_8_tfrevisaologdataalteracao ,
                                              AV57Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                              AV58Revisaologwwds_10_tfdocumentoid ,
                                              AV59Revisaologwwds_11_tfdocumentoid_to ,
                                              A120RevisaoLogId ,
                                              A121RevisaoLogUsuarioAlteracao ,
                                              A122RevisaoLogObservacao ,
                                              A75DocumentoId ,
                                              A123RevisaoLogDataAlteracao ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV49Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Revisaologwwds_1_filterfulltext), "%", "");
         lV49Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Revisaologwwds_1_filterfulltext), "%", "");
         lV49Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Revisaologwwds_1_filterfulltext), "%", "");
         lV49Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Revisaologwwds_1_filterfulltext), "%", "");
         lV52Revisaologwwds_4_tfrevisaologusuarioalteracao = StringUtil.Concat( StringUtil.RTrim( AV52Revisaologwwds_4_tfrevisaologusuarioalteracao), "%", "");
         lV54Revisaologwwds_6_tfrevisaologobservacao = StringUtil.Concat( StringUtil.RTrim( AV54Revisaologwwds_6_tfrevisaologobservacao), "%", "");
         /* Using cursor P00722 */
         pr_default.execute(0, new Object[] {lV49Revisaologwwds_1_filterfulltext, lV49Revisaologwwds_1_filterfulltext, lV49Revisaologwwds_1_filterfulltext, lV49Revisaologwwds_1_filterfulltext, AV50Revisaologwwds_2_tfrevisaologid, AV51Revisaologwwds_3_tfrevisaologid_to, lV52Revisaologwwds_4_tfrevisaologusuarioalteracao, AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, lV54Revisaologwwds_6_tfrevisaologobservacao, AV55Revisaologwwds_7_tfrevisaologobservacao_sel, AV56Revisaologwwds_8_tfrevisaologdataalteracao, AV57Revisaologwwds_9_tfrevisaologdataalteracao_to, AV58Revisaologwwds_10_tfdocumentoid, AV59Revisaologwwds_11_tfdocumentoid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P00722_A75DocumentoId[0];
            A123RevisaoLogDataAlteracao = P00722_A123RevisaoLogDataAlteracao[0];
            A120RevisaoLogId = P00722_A120RevisaoLogId[0];
            A122RevisaoLogObservacao = P00722_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = P00722_A121RevisaoLogUsuarioAlteracao[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H720( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9")), 30, Gx_line+10, 135, Gx_line+55, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A121RevisaoLogUsuarioAlteracao, "")), 139, Gx_line+10, 351, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(A122RevisaoLogObservacao, 355, Gx_line+10, 567, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A123RevisaoLogDataAlteracao, "99/99/99 99:99"), 571, Gx_line+10, 677, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), 681, Gx_line+10, 787, Gx_line+55, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+66);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get("RevisaoLogWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RevisaoLogWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("RevisaoLogWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGID") == 0 )
            {
               AV18TFRevisaoLogId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV19TFRevisaoLogId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO") == 0 )
            {
               AV20TFRevisaoLogUsuarioAlteracao = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO_SEL") == 0 )
            {
               AV21TFRevisaoLogUsuarioAlteracao_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO") == 0 )
            {
               AV22TFRevisaoLogObservacao = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO_SEL") == 0 )
            {
               AV23TFRevisaoLogObservacao_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGDATAALTERACAO") == 0 )
            {
               AV24TFRevisaoLogDataAlteracao = context.localUtil.CToT( AV17GridStateFilterValue.gxTpr_Value, 2);
               AV25TFRevisaoLogDataAlteracao_To = context.localUtil.CToT( AV17GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV26TFDocumentoId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV27TFDocumentoId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H720( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV40PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV37DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV35AppName = "DVelop Software Solutions";
               AV41Phone = "+1 550 8923";
               AV39Mail = "info@mail.com";
               AV43Website = "http://www.web.com";
               AV32AddressLine1 = "French Boulevard 2859";
               AV33AddressLine2 = "Downtown";
               AV34AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Title = "";
         AV13FilterFullText = "";
         AV28TFRevisaoLogId_To_Description = "";
         AV21TFRevisaoLogUsuarioAlteracao_Sel = "";
         AV20TFRevisaoLogUsuarioAlteracao = "";
         AV23TFRevisaoLogObservacao_Sel = "";
         AV22TFRevisaoLogObservacao = "";
         AV24TFRevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         AV25TFRevisaoLogDataAlteracao_To = (DateTime)(DateTime.MinValue);
         AV29TFRevisaoLogDataAlteracao_To_Description = "";
         AV30TFDocumentoId_To_Description = "";
         AV49Revisaologwwds_1_filterfulltext = "";
         AV52Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = "";
         AV54Revisaologwwds_6_tfrevisaologobservacao = "";
         AV55Revisaologwwds_7_tfrevisaologobservacao_sel = "";
         AV56Revisaologwwds_8_tfrevisaologdataalteracao = (DateTime)(DateTime.MinValue);
         AV57Revisaologwwds_9_tfrevisaologdataalteracao_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV49Revisaologwwds_1_filterfulltext = "";
         lV52Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         lV54Revisaologwwds_6_tfrevisaologobservacao = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A122RevisaoLogObservacao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         P00722_A75DocumentoId = new int[1] ;
         P00722_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P00722_A120RevisaoLogId = new int[1] ;
         P00722_A122RevisaoLogObservacao = new string[] {""} ;
         P00722_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40PageInfo = "";
         AV37DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV35AppName = "";
         AV41Phone = "";
         AV39Mail = "";
         AV43Website = "";
         AV32AddressLine1 = "";
         AV33AddressLine2 = "";
         AV34AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaologwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00722_A75DocumentoId, P00722_A123RevisaoLogDataAlteracao, P00722_A120RevisaoLogId, P00722_A122RevisaoLogObservacao, P00722_A121RevisaoLogUsuarioAlteracao
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV18TFRevisaoLogId ;
      private int AV19TFRevisaoLogId_To ;
      private int AV26TFDocumentoId ;
      private int AV27TFDocumentoId_To ;
      private int AV50Revisaologwwds_2_tfrevisaologid ;
      private int AV51Revisaologwwds_3_tfrevisaologid_to ;
      private int AV58Revisaologwwds_10_tfdocumentoid ;
      private int AV59Revisaologwwds_11_tfdocumentoid_to ;
      private int A120RevisaoLogId ;
      private int A75DocumentoId ;
      private int AV60GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV24TFRevisaoLogDataAlteracao ;
      private DateTime AV25TFRevisaoLogDataAlteracao_To ;
      private DateTime AV56Revisaologwwds_8_tfrevisaologdataalteracao ;
      private DateTime AV57Revisaologwwds_9_tfrevisaologdataalteracao_to ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV31TempBoolean ;
      private bool AV12OrderedDsc ;
      private string A122RevisaoLogObservacao ;
      private string AV42Title ;
      private string AV13FilterFullText ;
      private string AV28TFRevisaoLogId_To_Description ;
      private string AV21TFRevisaoLogUsuarioAlteracao_Sel ;
      private string AV20TFRevisaoLogUsuarioAlteracao ;
      private string AV23TFRevisaoLogObservacao_Sel ;
      private string AV22TFRevisaoLogObservacao ;
      private string AV29TFRevisaoLogDataAlteracao_To_Description ;
      private string AV30TFDocumentoId_To_Description ;
      private string AV49Revisaologwwds_1_filterfulltext ;
      private string AV52Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ;
      private string AV54Revisaologwwds_6_tfrevisaologobservacao ;
      private string AV55Revisaologwwds_7_tfrevisaologobservacao_sel ;
      private string lV49Revisaologwwds_1_filterfulltext ;
      private string lV52Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string lV54Revisaologwwds_6_tfrevisaologobservacao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string AV40PageInfo ;
      private string AV37DateInfo ;
      private string AV35AppName ;
      private string AV41Phone ;
      private string AV39Mail ;
      private string AV43Website ;
      private string AV32AddressLine1 ;
      private string AV33AddressLine2 ;
      private string AV34AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00722_A75DocumentoId ;
      private DateTime[] P00722_A123RevisaoLogDataAlteracao ;
      private int[] P00722_A120RevisaoLogId ;
      private string[] P00722_A122RevisaoLogObservacao ;
      private string[] P00722_A121RevisaoLogUsuarioAlteracao ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class revisaologwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00722( IGxContext context ,
                                             string AV49Revisaologwwds_1_filterfulltext ,
                                             int AV50Revisaologwwds_2_tfrevisaologid ,
                                             int AV51Revisaologwwds_3_tfrevisaologid_to ,
                                             string AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                             string AV52Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                             string AV55Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                             string AV54Revisaologwwds_6_tfrevisaologobservacao ,
                                             DateTime AV56Revisaologwwds_8_tfrevisaologdataalteracao ,
                                             DateTime AV57Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                             int AV58Revisaologwwds_10_tfdocumentoid ,
                                             int AV59Revisaologwwds_11_tfdocumentoid_to ,
                                             int A120RevisaoLogId ,
                                             string A121RevisaoLogUsuarioAlteracao ,
                                             string A122RevisaoLogObservacao ,
                                             int A75DocumentoId ,
                                             DateTime A123RevisaoLogDataAlteracao ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DocumentoId], [RevisaoLogDataAlteracao], [RevisaoLogId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao] FROM [RevisaoLog]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Revisaologwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([RevisaoLogId] AS decimal(8,0))) like '%' + @lV49Revisaologwwds_1_filterfulltext) or ( [RevisaoLogUsuarioAlteracao] like '%' + @lV49Revisaologwwds_1_filterfulltext) or ( [RevisaoLogObservacao] like '%' + @lV49Revisaologwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV49Revisaologwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV50Revisaologwwds_2_tfrevisaologid) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] >= @AV50Revisaologwwds_2_tfrevisaologid)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV51Revisaologwwds_3_tfrevisaologid_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] <= @AV51Revisaologwwds_3_tfrevisaologid_to)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Revisaologwwds_4_tfrevisaologusuarioalteracao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] like @lV52Revisaologwwds_4_tfrevisaologusuarioalteracao)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ! ( StringUtil.StrCmp(AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] = @AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RevisaoLogUsuarioAlteracao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Revisaologwwds_7_tfrevisaologobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_6_tfrevisaologobservacao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] like @lV54Revisaologwwds_6_tfrevisaologobservacao)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Revisaologwwds_7_tfrevisaologobservacao_sel)) && ! ( StringUtil.StrCmp(AV55Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] = @AV55Revisaologwwds_7_tfrevisaologobservacao_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV55Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH([RevisaoLogObservacao])=0))");
         }
         if ( ! (DateTime.MinValue==AV56Revisaologwwds_8_tfrevisaologdataalteracao) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] >= @AV56Revisaologwwds_8_tfrevisaologdataalteracao)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Revisaologwwds_9_tfrevisaologdataalteracao_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] <= @AV57Revisaologwwds_9_tfrevisaologdataalteracao_to)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV58Revisaologwwds_10_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV58Revisaologwwds_10_tfdocumentoid)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV59Revisaologwwds_11_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV59Revisaologwwds_11_tfdocumentoid_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogUsuarioAlteracao]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogUsuarioAlteracao] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogObservacao]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogObservacao] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogDataAlteracao]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogDataAlteracao] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentoId]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocumentoId] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00722(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00722;
          prmP00722 = new Object[] {
          new ParDef("@lV49Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV49Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV49Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV50Revisaologwwds_2_tfrevisaologid",GXType.Int32,8,0) ,
          new ParDef("@AV51Revisaologwwds_3_tfrevisaologid_to",GXType.Int32,8,0) ,
          new ParDef("@lV52Revisaologwwds_4_tfrevisaologusuarioalteracao",GXType.NVarChar,100,0) ,
          new ParDef("@AV53Revisaologwwds_5_tfrevisaologusuarioalteracao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Revisaologwwds_6_tfrevisaologobservacao",GXType.NVarChar,200,0) ,
          new ParDef("@AV55Revisaologwwds_7_tfrevisaologobservacao_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV56Revisaologwwds_8_tfrevisaologdataalteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV57Revisaologwwds_9_tfrevisaologdataalteracao_to",GXType.DateTime,8,5) ,
          new ParDef("@AV58Revisaologwwds_10_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV59Revisaologwwds_11_tfdocumentoid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00722", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00722,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
