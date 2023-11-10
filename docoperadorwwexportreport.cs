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
   public class docoperadorwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public docoperadorwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docoperadorwwexportreport( IGxContext context )
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
         docoperadorwwexportreport objdocoperadorwwexportreport;
         objdocoperadorwwexportreport = new docoperadorwwexportreport();
         objdocoperadorwwexportreport.context.SetSubmitInitialConfig(context);
         objdocoperadorwwexportreport.initialize();
         Submit( executePrivateCatch,objdocoperadorwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docoperadorwwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperadorww_Execute", out  GXt_boolean1) ;
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
               AV51Title = "Lista de Doc Operador";
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
            H570( true, 0) ;
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
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV18TFDocOperadorId) && (0==AV19TFDocOperadorId_To) ) )
         {
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Operador Id", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18TFDocOperadorId), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV31TFDocOperadorId_To_Description = StringUtil.Format( "%1 (%2)", "Operador Id", "Até", "", "", "", "", "", "", "");
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFDocOperadorId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19TFDocOperadorId_To), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV20TFDocumentoId) && (0==AV21TFDocumentoId_To) ) )
         {
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("do Documento", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20TFDocumentoId), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV32TFDocumentoId_To_Description = StringUtil.Format( "%1 (%2)", "do Documento", "Até", "", "", "", "", "", "", "");
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFDocumentoId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21TFDocumentoId_To), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV22TFOperadorId) && (0==AV23TFOperadorId_To) ) )
         {
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("do Operador", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22TFOperadorId), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFOperadorId_To_Description = StringUtil.Format( "%1 (%2)", "do Operador", "Até", "", "", "", "", "", "", "");
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFOperadorId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23TFOperadorId_To), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV24TFDocOperadorColeta_Sel) )
         {
            if ( AV24TFDocOperadorColeta_Sel == 1 )
            {
               AV34FilterTFDocOperadorColeta_SelValueDescription = "Marcado";
            }
            else if ( AV24TFDocOperadorColeta_Sel == 2 )
            {
               AV34FilterTFDocOperadorColeta_SelValueDescription = "Desmarcado";
            }
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Coleta?", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34FilterTFDocOperadorColeta_SelValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV25TFDocOperadorRetencao_Sel) )
         {
            if ( AV25TFDocOperadorRetencao_Sel == 1 )
            {
               AV35FilterTFDocOperadorRetencao_SelValueDescription = "Marcado";
            }
            else if ( AV25TFDocOperadorRetencao_Sel == 2 )
            {
               AV35FilterTFDocOperadorRetencao_SelValueDescription = "Desmarcado";
            }
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Retenção?", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35FilterTFDocOperadorRetencao_SelValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV26TFDocOperadorCompartilhamento_Sel) )
         {
            if ( AV26TFDocOperadorCompartilhamento_Sel == 1 )
            {
               AV36FilterTFDocOperadorCompartilhamento_SelValueDescription = "Marcado";
            }
            else if ( AV26TFDocOperadorCompartilhamento_Sel == 2 )
            {
               AV36FilterTFDocOperadorCompartilhamento_SelValueDescription = "Desmarcado";
            }
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Compartilhamento?", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36FilterTFDocOperadorCompartilhamento_SelValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV27TFDocOperadorEliminacao_Sel) )
         {
            if ( AV27TFDocOperadorEliminacao_Sel == 1 )
            {
               AV37FilterTFDocOperadorEliminacao_SelValueDescription = "Marcado";
            }
            else if ( AV27TFDocOperadorEliminacao_Sel == 2 )
            {
               AV37FilterTFDocOperadorEliminacao_SelValueDescription = "Desmarcado";
            }
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Eliminição?", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterTFDocOperadorEliminacao_SelValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV28TFDocOperadorProcessamento_Sel) )
         {
            if ( AV28TFDocOperadorProcessamento_Sel == 1 )
            {
               AV38FilterTFDocOperadorProcessamento_SelValueDescription = "Marcado";
            }
            else if ( AV28TFDocOperadorProcessamento_Sel == 2 )
            {
               AV38FilterTFDocOperadorProcessamento_SelValueDescription = "Desmarcado";
            }
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Processamento?", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38FilterTFDocOperadorProcessamento_SelValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV29TFDocOperadorDataInclusao) && (DateTime.MinValue==AV30TFDocOperadorDataInclusao_To) ) )
         {
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data Inclusao", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV29TFDocOperadorDataInclusao, "99/99/99"), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV39TFDocOperadorDataInclusao_To_Description = StringUtil.Format( "%1 (%2)", "Data Inclusao", "Até", "", "", "", "", "", "", "");
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFDocOperadorDataInclusao_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV30TFDocOperadorDataInclusao_To, "99/99/99"), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H570( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H570( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Operador Id", 30, Gx_line+10, 110, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("do Documento", 114, Gx_line+10, 194, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("do Operador", 198, Gx_line+10, 278, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Coleta?", 282, Gx_line+10, 362, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Retenção?", 366, Gx_line+10, 447, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Compartilhamento?", 451, Gx_line+10, 532, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Eliminição?", 536, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Processamento?", 621, Gx_line+10, 702, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data Inclusao", 706, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV58Docoperadorwwds_1_filterfulltext = AV13FilterFullText;
         AV59Docoperadorwwds_2_tfdocoperadorid = AV18TFDocOperadorId;
         AV60Docoperadorwwds_3_tfdocoperadorid_to = AV19TFDocOperadorId_To;
         AV61Docoperadorwwds_4_tfdocumentoid = AV20TFDocumentoId;
         AV62Docoperadorwwds_5_tfdocumentoid_to = AV21TFDocumentoId_To;
         AV63Docoperadorwwds_6_tfoperadorid = AV22TFOperadorId;
         AV64Docoperadorwwds_7_tfoperadorid_to = AV23TFOperadorId_To;
         AV65Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV24TFDocOperadorColeta_Sel;
         AV66Docoperadorwwds_9_tfdocoperadorretencao_sel = AV25TFDocOperadorRetencao_Sel;
         AV67Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV26TFDocOperadorCompartilhamento_Sel;
         AV68Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV27TFDocOperadorEliminacao_Sel;
         AV69Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV28TFDocOperadorProcessamento_Sel;
         AV70Docoperadorwwds_13_tfdocoperadordatainclusao = AV29TFDocOperadorDataInclusao;
         AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV30TFDocOperadorDataInclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Docoperadorwwds_1_filterfulltext ,
                                              AV59Docoperadorwwds_2_tfdocoperadorid ,
                                              AV60Docoperadorwwds_3_tfdocoperadorid_to ,
                                              AV61Docoperadorwwds_4_tfdocumentoid ,
                                              AV62Docoperadorwwds_5_tfdocumentoid_to ,
                                              AV63Docoperadorwwds_6_tfoperadorid ,
                                              AV64Docoperadorwwds_7_tfoperadorid_to ,
                                              AV65Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                              AV66Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                              AV67Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                              AV68Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                              AV69Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                              AV70Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                              AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                              A86DocOperadorId ,
                                              A75DocumentoId ,
                                              A42OperadorId ,
                                              A87DocOperadorColeta ,
                                              A88DocOperadorRetencao ,
                                              A89DocOperadorCompartilhamento ,
                                              A90DocOperadorEliminacao ,
                                              A91DocOperadorProcessamento ,
                                              A92DocOperadorDataInclusao ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Docoperadorwwds_1_filterfulltext), "%", "");
         lV58Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Docoperadorwwds_1_filterfulltext), "%", "");
         lV58Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Docoperadorwwds_1_filterfulltext), "%", "");
         /* Using cursor P00572 */
         pr_default.execute(0, new Object[] {lV58Docoperadorwwds_1_filterfulltext, lV58Docoperadorwwds_1_filterfulltext, lV58Docoperadorwwds_1_filterfulltext, AV59Docoperadorwwds_2_tfdocoperadorid, AV60Docoperadorwwds_3_tfdocoperadorid_to, AV61Docoperadorwwds_4_tfdocumentoid, AV62Docoperadorwwds_5_tfdocumentoid_to, AV63Docoperadorwwds_6_tfoperadorid, AV64Docoperadorwwds_7_tfoperadorid_to, AV70Docoperadorwwds_13_tfdocoperadordatainclusao, AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A92DocOperadorDataInclusao = P00572_A92DocOperadorDataInclusao[0];
            A91DocOperadorProcessamento = P00572_A91DocOperadorProcessamento[0];
            A90DocOperadorEliminacao = P00572_A90DocOperadorEliminacao[0];
            A89DocOperadorCompartilhamento = P00572_A89DocOperadorCompartilhamento[0];
            A88DocOperadorRetencao = P00572_A88DocOperadorRetencao[0];
            A87DocOperadorColeta = P00572_A87DocOperadorColeta[0];
            A42OperadorId = P00572_A42OperadorId[0];
            A75DocumentoId = P00572_A75DocumentoId[0];
            A86DocOperadorId = P00572_A86DocOperadorId[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H570( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9")), 30, Gx_line+10, 110, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), 114, Gx_line+10, 194, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A42OperadorId), "ZZZZZZZ9")), 198, Gx_line+10, 278, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A87DocOperadorColeta), 282, Gx_line+10, 362, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A88DocOperadorRetencao), 366, Gx_line+10, 447, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A89DocOperadorCompartilhamento), 451, Gx_line+10, 532, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A90DocOperadorEliminacao), 536, Gx_line+10, 617, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A91DocOperadorProcessamento), 621, Gx_line+10, 702, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A92DocOperadorDataInclusao, "99/99/99"), 706, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
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
         if ( StringUtil.StrCmp(AV14Session.Get("DocOperadorWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocOperadorWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("DocOperadorWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORID") == 0 )
            {
               AV18TFDocOperadorId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV19TFDocOperadorId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV20TFDocumentoId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV21TFDocumentoId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFOPERADORID") == 0 )
            {
               AV22TFOperadorId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV23TFOperadorId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORCOLETA_SEL") == 0 )
            {
               AV24TFDocOperadorColeta_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORRETENCAO_SEL") == 0 )
            {
               AV25TFDocOperadorRetencao_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORCOMPARTILHAMENTO_SEL") == 0 )
            {
               AV26TFDocOperadorCompartilhamento_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORELIMINACAO_SEL") == 0 )
            {
               AV27TFDocOperadorEliminacao_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORPROCESSAMENTO_SEL") == 0 )
            {
               AV28TFDocOperadorProcessamento_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORDATAINCLUSAO") == 0 )
            {
               AV29TFDocOperadorDataInclusao = context.localUtil.CToD( AV17GridStateFilterValue.gxTpr_Value, 2);
               AV30TFDocOperadorDataInclusao_To = context.localUtil.CToD( AV17GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV72GXV1 = (int)(AV72GXV1+1);
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

      protected void H570( bool bFoot ,
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
                  AV49PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV46DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV44AppName = "DVelop Software Solutions";
               AV50Phone = "+1 550 8923";
               AV48Mail = "info@mail.com";
               AV52Website = "http://www.web.com";
               AV41AddressLine1 = "French Boulevard 2859";
               AV42AddressLine2 = "Downtown";
               AV43AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV51Title = "";
         AV13FilterFullText = "";
         AV31TFDocOperadorId_To_Description = "";
         AV32TFDocumentoId_To_Description = "";
         AV33TFOperadorId_To_Description = "";
         AV34FilterTFDocOperadorColeta_SelValueDescription = "";
         AV35FilterTFDocOperadorRetencao_SelValueDescription = "";
         AV36FilterTFDocOperadorCompartilhamento_SelValueDescription = "";
         AV37FilterTFDocOperadorEliminacao_SelValueDescription = "";
         AV38FilterTFDocOperadorProcessamento_SelValueDescription = "";
         AV29TFDocOperadorDataInclusao = DateTime.MinValue;
         AV30TFDocOperadorDataInclusao_To = DateTime.MinValue;
         AV39TFDocOperadorDataInclusao_To_Description = "";
         AV58Docoperadorwwds_1_filterfulltext = "";
         AV70Docoperadorwwds_13_tfdocoperadordatainclusao = DateTime.MinValue;
         AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to = DateTime.MinValue;
         scmdbuf = "";
         lV58Docoperadorwwds_1_filterfulltext = "";
         A92DocOperadorDataInclusao = DateTime.MinValue;
         P00572_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P00572_A91DocOperadorProcessamento = new bool[] {false} ;
         P00572_A90DocOperadorEliminacao = new bool[] {false} ;
         P00572_A89DocOperadorCompartilhamento = new bool[] {false} ;
         P00572_A88DocOperadorRetencao = new bool[] {false} ;
         P00572_A87DocOperadorColeta = new bool[] {false} ;
         P00572_A42OperadorId = new int[1] ;
         P00572_A75DocumentoId = new int[1] ;
         P00572_A86DocOperadorId = new int[1] ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49PageInfo = "";
         AV46DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV44AppName = "";
         AV50Phone = "";
         AV48Mail = "";
         AV52Website = "";
         AV41AddressLine1 = "";
         AV42AddressLine2 = "";
         AV43AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperadorwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00572_A92DocOperadorDataInclusao, P00572_A91DocOperadorProcessamento, P00572_A90DocOperadorEliminacao, P00572_A89DocOperadorCompartilhamento, P00572_A88DocOperadorRetencao, P00572_A87DocOperadorColeta, P00572_A42OperadorId, P00572_A75DocumentoId, P00572_A86DocOperadorId
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
      private short AV24TFDocOperadorColeta_Sel ;
      private short AV25TFDocOperadorRetencao_Sel ;
      private short AV26TFDocOperadorCompartilhamento_Sel ;
      private short AV27TFDocOperadorEliminacao_Sel ;
      private short AV28TFDocOperadorProcessamento_Sel ;
      private short AV65Docoperadorwwds_8_tfdocoperadorcoleta_sel ;
      private short AV66Docoperadorwwds_9_tfdocoperadorretencao_sel ;
      private short AV67Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ;
      private short AV68Docoperadorwwds_11_tfdocoperadoreliminacao_sel ;
      private short AV69Docoperadorwwds_12_tfdocoperadorprocessamento_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV18TFDocOperadorId ;
      private int AV19TFDocOperadorId_To ;
      private int AV20TFDocumentoId ;
      private int AV21TFDocumentoId_To ;
      private int AV22TFOperadorId ;
      private int AV23TFOperadorId_To ;
      private int AV59Docoperadorwwds_2_tfdocoperadorid ;
      private int AV60Docoperadorwwds_3_tfdocoperadorid_to ;
      private int AV61Docoperadorwwds_4_tfdocumentoid ;
      private int AV62Docoperadorwwds_5_tfdocumentoid_to ;
      private int AV63Docoperadorwwds_6_tfoperadorid ;
      private int AV64Docoperadorwwds_7_tfoperadorid_to ;
      private int A86DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int AV72GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV29TFDocOperadorDataInclusao ;
      private DateTime AV30TFDocOperadorDataInclusao_To ;
      private DateTime AV70Docoperadorwwds_13_tfdocoperadordatainclusao ;
      private DateTime AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to ;
      private DateTime A92DocOperadorDataInclusao ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool AV12OrderedDsc ;
      private string AV51Title ;
      private string AV13FilterFullText ;
      private string AV31TFDocOperadorId_To_Description ;
      private string AV32TFDocumentoId_To_Description ;
      private string AV33TFOperadorId_To_Description ;
      private string AV34FilterTFDocOperadorColeta_SelValueDescription ;
      private string AV35FilterTFDocOperadorRetencao_SelValueDescription ;
      private string AV36FilterTFDocOperadorCompartilhamento_SelValueDescription ;
      private string AV37FilterTFDocOperadorEliminacao_SelValueDescription ;
      private string AV38FilterTFDocOperadorProcessamento_SelValueDescription ;
      private string AV39TFDocOperadorDataInclusao_To_Description ;
      private string AV58Docoperadorwwds_1_filterfulltext ;
      private string lV58Docoperadorwwds_1_filterfulltext ;
      private string AV49PageInfo ;
      private string AV46DateInfo ;
      private string AV44AppName ;
      private string AV50Phone ;
      private string AV48Mail ;
      private string AV52Website ;
      private string AV41AddressLine1 ;
      private string AV42AddressLine2 ;
      private string AV43AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00572_A92DocOperadorDataInclusao ;
      private bool[] P00572_A91DocOperadorProcessamento ;
      private bool[] P00572_A90DocOperadorEliminacao ;
      private bool[] P00572_A89DocOperadorCompartilhamento ;
      private bool[] P00572_A88DocOperadorRetencao ;
      private bool[] P00572_A87DocOperadorColeta ;
      private int[] P00572_A42OperadorId ;
      private int[] P00572_A75DocumentoId ;
      private int[] P00572_A86DocOperadorId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class docoperadorwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00572( IGxContext context ,
                                             string AV58Docoperadorwwds_1_filterfulltext ,
                                             int AV59Docoperadorwwds_2_tfdocoperadorid ,
                                             int AV60Docoperadorwwds_3_tfdocoperadorid_to ,
                                             int AV61Docoperadorwwds_4_tfdocumentoid ,
                                             int AV62Docoperadorwwds_5_tfdocumentoid_to ,
                                             int AV63Docoperadorwwds_6_tfoperadorid ,
                                             int AV64Docoperadorwwds_7_tfoperadorid_to ,
                                             short AV65Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                             short AV66Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                             short AV67Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                             short AV68Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                             short AV69Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                             DateTime AV70Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                             DateTime AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                             int A86DocOperadorId ,
                                             int A75DocumentoId ,
                                             int A42OperadorId ,
                                             bool A87DocOperadorColeta ,
                                             bool A88DocOperadorRetencao ,
                                             bool A89DocOperadorCompartilhamento ,
                                             bool A90DocOperadorEliminacao ,
                                             bool A91DocOperadorProcessamento ,
                                             DateTime A92DocOperadorDataInclusao ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DocOperadorDataInclusao], [DocOperadorProcessamento], [DocOperadorEliminacao], [DocOperadorCompartilhamento], [DocOperadorRetencao], [DocOperadorColeta], [OperadorId], [DocumentoId], [DocOperadorId] FROM [DocOperador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Docoperadorwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([DocOperadorId] AS decimal(8,0))) like '%' + @lV58Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV58Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([OperadorId] AS decimal(8,0))) like '%' + @lV58Docoperadorwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV59Docoperadorwwds_2_tfdocoperadorid) )
         {
            AddWhere(sWhereString, "([DocOperadorId] >= @AV59Docoperadorwwds_2_tfdocoperadorid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV60Docoperadorwwds_3_tfdocoperadorid_to) )
         {
            AddWhere(sWhereString, "([DocOperadorId] <= @AV60Docoperadorwwds_3_tfdocoperadorid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV61Docoperadorwwds_4_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV61Docoperadorwwds_4_tfdocumentoid)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV62Docoperadorwwds_5_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV62Docoperadorwwds_5_tfdocumentoid_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV63Docoperadorwwds_6_tfoperadorid) )
         {
            AddWhere(sWhereString, "([OperadorId] >= @AV63Docoperadorwwds_6_tfoperadorid)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV64Docoperadorwwds_7_tfoperadorid_to) )
         {
            AddWhere(sWhereString, "([OperadorId] <= @AV64Docoperadorwwds_7_tfoperadorid_to)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV65Docoperadorwwds_8_tfdocoperadorcoleta_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 1)");
         }
         if ( AV65Docoperadorwwds_8_tfdocoperadorcoleta_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 0)");
         }
         if ( AV66Docoperadorwwds_9_tfdocoperadorretencao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 1)");
         }
         if ( AV66Docoperadorwwds_9_tfdocoperadorretencao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 0)");
         }
         if ( AV67Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 1)");
         }
         if ( AV67Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 0)");
         }
         if ( AV68Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 1)");
         }
         if ( AV68Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 0)");
         }
         if ( AV69Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 1)");
         }
         if ( AV69Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 0)");
         }
         if ( ! (DateTime.MinValue==AV70Docoperadorwwds_13_tfdocoperadordatainclusao) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] >= @AV70Docoperadorwwds_13_tfdocoperadordatainclusao)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] <= @AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorColeta]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorColeta] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentoId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocumentoId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperadorId]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperadorId] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorRetencao]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorRetencao] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorCompartilhamento]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorCompartilhamento] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorEliminacao]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorEliminacao] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorProcessamento]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorProcessamento] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorDataInclusao]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorDataInclusao] DESC";
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
                     return conditional_P00572(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00572;
          prmP00572 = new Object[] {
          new ParDef("@lV58Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV59Docoperadorwwds_2_tfdocoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV60Docoperadorwwds_3_tfdocoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV61Docoperadorwwds_4_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV62Docoperadorwwds_5_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV63Docoperadorwwds_6_tfoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV64Docoperadorwwds_7_tfoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV70Docoperadorwwds_13_tfdocoperadordatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV71Docoperadorwwds_14_tfdocoperadordatainclusao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00572", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00572,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
