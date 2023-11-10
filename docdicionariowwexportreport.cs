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
   public class docdicionariowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public docdicionariowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docdicionariowwexportreport( IGxContext context )
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
         docdicionariowwexportreport objdocdicionariowwexportreport;
         objdocdicionariowwexportreport = new docdicionariowwexportreport();
         objdocdicionariowwexportreport.context.SetSubmitInitialConfig(context);
         objdocdicionariowwexportreport.initialize();
         Submit( executePrivateCatch,objdocdicionariowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docdicionariowwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docdicionarioww_Execute", out  GXt_boolean1) ;
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
               AV55Title = "Lista de Doc Dicionario";
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
            H300( true, 0) ;
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
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV18TFDocDicionarioId) && (0==AV19TFDocDicionarioId_To) ) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dicionario Id", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18TFDocDicionarioId), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFDocDicionarioId_To_Description = StringUtil.Format( "%1 (%2)", "Dicionario Id", "Até", "", "", "", "", "", "", "");
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFDocDicionarioId_To_Description, "")), 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19TFDocDicionarioId_To), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV22TFInformacaoId) && (0==AV23TFInformacaoId_To) ) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("da Informação", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22TFInformacaoId), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFInformacaoId_To_Description = StringUtil.Format( "%1 (%2)", "da Informação", "Até", "", "", "", "", "", "", "");
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFInformacaoId_To_Description, "")), 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23TFInformacaoId_To), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV57TFHipoteseTratamentoId) && (0==AV58TFHipoteseTratamentoId_To) ) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("de Tratamento", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV57TFHipoteseTratamentoId), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV59TFHipoteseTratamentoId_To_Description = StringUtil.Format( "%1 (%2)", "de Tratamento", "Até", "", "", "", "", "", "", "");
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFHipoteseTratamentoId_To_Description, "")), 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV58TFHipoteseTratamentoId_To), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV27TFDocDicionarioSensivel_Sel) )
         {
            if ( AV27TFDocDicionarioSensivel_Sel == 1 )
            {
               AV40FilterTFDocDicionarioSensivel_SelValueDescription = "Marcado";
            }
            else if ( AV27TFDocDicionarioSensivel_Sel == 2 )
            {
               AV40FilterTFDocDicionarioSensivel_SelValueDescription = "Desmarcado";
            }
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sensível?", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40FilterTFDocDicionarioSensivel_SelValueDescription, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV28TFDocDicionarioPodeEliminar_Sel) )
         {
            if ( AV28TFDocDicionarioPodeEliminar_Sel == 1 )
            {
               AV41FilterTFDocDicionarioPodeEliminar_SelValueDescription = "Marcado";
            }
            else if ( AV28TFDocDicionarioPodeEliminar_Sel == 2 )
            {
               AV41FilterTFDocDicionarioPodeEliminar_SelValueDescription = "Desmarcado";
            }
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Eliminar?", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41FilterTFDocDicionarioPodeEliminar_SelValueDescription, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV74TFDocDicionarioTransfInter_Sel) )
         {
            if ( AV74TFDocDicionarioTransfInter_Sel == 1 )
            {
               AV75FilterTFDocDicionarioTransfInter_SelValueDescription = "Marcado";
            }
            else if ( AV74TFDocDicionarioTransfInter_Sel == 2 )
            {
               AV75FilterTFDocDicionarioTransfInter_SelValueDescription = "Desmarcado";
            }
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Internacional", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75FilterTFDocDicionarioTransfInter_SelValueDescription, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFDocDicionarioFinalidade_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV32TFDocDicionarioFinalidade_Sel, "<#Empty#>")==0)));
            AV32TFDocDicionarioFinalidade_Sel = (AV44TempBoolean ? "(Vazio)" : AV32TFDocDicionarioFinalidade_Sel);
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Finalidade", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFDocDicionarioFinalidade_Sel, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV32TFDocDicionarioFinalidade_Sel = (AV44TempBoolean ? "<#Empty#>" : AV32TFDocDicionarioFinalidade_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFDocDicionarioFinalidade)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Finalidade", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFDocDicionarioFinalidade, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV33TFDocDicionarioDataInclusao) && (DateTime.MinValue==AV34TFDocDicionarioDataInclusao_To) ) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("de Inclusão", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV33TFDocDicionarioDataInclusao, "99/99/99"), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFDocDicionarioDataInclusao_To_Description = StringUtil.Format( "%1 (%2)", "de Inclusão", "Até", "", "", "", "", "", "", "");
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFDocDicionarioDataInclusao_To_Description, "")), 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV34TFDocDicionarioDataInclusao_To, "99/99/99"), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFInformacaoNome_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV63TFInformacaoNome_Sel, "<#Empty#>")==0)));
            AV63TFInformacaoNome_Sel = (AV44TempBoolean ? "(Vazio)" : AV63TFInformacaoNome_Sel);
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TFInformacaoNome_Sel, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV63TFInformacaoNome_Sel = (AV44TempBoolean ? "<#Empty#>" : AV63TFInformacaoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFInformacaoNome)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFInformacaoNome, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFHipoteseTratamentoNome_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV65TFHipoteseTratamentoNome_Sel, "<#Empty#>")==0)));
            AV65TFHipoteseTratamentoNome_Sel = (AV44TempBoolean ? "(Vazio)" : AV65TFHipoteseTratamentoNome_Sel);
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFHipoteseTratamentoNome_Sel, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV65TFHipoteseTratamentoNome_Sel = (AV44TempBoolean ? "<#Empty#>" : AV65TFHipoteseTratamentoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFHipoteseTratamentoNome)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFHipoteseTratamentoNome, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV68TFDocumentoId) && (0==AV69TFDocumentoId_To) ) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Id do Documento", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV68TFDocumentoId), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFDocumentoId_To_Description = StringUtil.Format( "%1 (%2)", "Id do Documento", "Até", "", "", "", "", "", "", "");
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFDocumentoId_To_Description, "")), 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV69TFDocumentoId_To), "ZZZZZZZ9")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFDocumentoNome_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV71TFDocumentoNome_Sel, "<#Empty#>")==0)));
            AV71TFDocumentoNome_Sel = (AV44TempBoolean ? "(Vazio)" : AV71TFDocumentoNome_Sel);
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFDocumentoNome_Sel, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV71TFDocumentoNome_Sel = (AV44TempBoolean ? "<#Empty#>" : AV71TFDocumentoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFDocumentoNome)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFDocumentoNome, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFDocDicionarioTipoTransfInterGarantia_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV73TFDocDicionarioTipoTransfInterGarantia_Sel, "<#Empty#>")==0)));
            AV73TFDocDicionarioTipoTransfInterGarantia_Sel = (AV44TempBoolean ? "(Vazio)" : AV73TFDocDicionarioTipoTransfInterGarantia_Sel);
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Transferência internacional", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TFDocDicionarioTipoTransfInterGarantia_Sel, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV73TFDocDicionarioTipoTransfInterGarantia_Sel = (AV44TempBoolean ? "<#Empty#>" : AV73TFDocDicionarioTipoTransfInterGarantia_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFDocDicionarioTipoTransfInterGarantia)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Transferência internacional", 25, Gx_line+0, 165, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TFDocDicionarioTipoTransfInterGarantia, "")), 165, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H300( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H300( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Dicionario Id", 30, Gx_line+10, 84, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("da Informação", 88, Gx_line+10, 142, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("de Tratamento", 146, Gx_line+10, 200, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Sensível?", 204, Gx_line+10, 258, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Eliminar?", 262, Gx_line+10, 316, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Internacional", 320, Gx_line+10, 374, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Finalidade", 378, Gx_line+10, 432, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("de Inclusão", 436, Gx_line+10, 490, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome", 494, Gx_line+10, 548, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome", 552, Gx_line+10, 608, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Id do Documento", 612, Gx_line+10, 667, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome", 671, Gx_line+10, 727, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Transferência internacional", 731, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV81Docdicionariowwds_1_filterfulltext = AV13FilterFullText;
         AV82Docdicionariowwds_2_tfdocdicionarioid = AV18TFDocDicionarioId;
         AV83Docdicionariowwds_3_tfdocdicionarioid_to = AV19TFDocDicionarioId_To;
         AV84Docdicionariowwds_4_tfinformacaoid = AV22TFInformacaoId;
         AV85Docdicionariowwds_5_tfinformacaoid_to = AV23TFInformacaoId_To;
         AV86Docdicionariowwds_6_tfhipotesetratamentoid = AV57TFHipoteseTratamentoId;
         AV87Docdicionariowwds_7_tfhipotesetratamentoid_to = AV58TFHipoteseTratamentoId_To;
         AV88Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV27TFDocDicionarioSensivel_Sel;
         AV89Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV28TFDocDicionarioPodeEliminar_Sel;
         AV90Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV74TFDocDicionarioTransfInter_Sel;
         AV91Docdicionariowwds_11_tfdocdicionariofinalidade = AV31TFDocDicionarioFinalidade;
         AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV32TFDocDicionarioFinalidade_Sel;
         AV93Docdicionariowwds_13_tfdocdicionariodatainclusao = AV33TFDocDicionarioDataInclusao;
         AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV34TFDocDicionarioDataInclusao_To;
         AV95Docdicionariowwds_15_tfinformacaonome = AV62TFInformacaoNome;
         AV96Docdicionariowwds_16_tfinformacaonome_sel = AV63TFInformacaoNome_Sel;
         AV97Docdicionariowwds_17_tfhipotesetratamentonome = AV64TFHipoteseTratamentoNome;
         AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV65TFHipoteseTratamentoNome_Sel;
         AV99Docdicionariowwds_19_tfdocumentoid = AV68TFDocumentoId;
         AV100Docdicionariowwds_20_tfdocumentoid_to = AV69TFDocumentoId_To;
         AV101Docdicionariowwds_21_tfdocumentonome = AV70TFDocumentoNome;
         AV102Docdicionariowwds_22_tfdocumentonome_sel = AV71TFDocumentoNome_Sel;
         AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV72TFDocDicionarioTipoTransfInterGarantia;
         AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV73TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV81Docdicionariowwds_1_filterfulltext ,
                                              AV82Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV83Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV84Docdicionariowwds_4_tfinformacaoid ,
                                              AV85Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV86Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV87Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV88Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV89Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV90Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV91Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV93Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV96Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV95Docdicionariowwds_15_tfinformacaonome ,
                                              AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV97Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV99Docdicionariowwds_19_tfdocumentoid ,
                                              AV100Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV102Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV101Docdicionariowwds_21_tfdocumentonome ,
                                              AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV81Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext), "%", "");
         lV91Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV91Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV95Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV95Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV97Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV97Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV101Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV101Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P00302 */
         pr_default.execute(0, new Object[] {lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, lV81Docdicionariowwds_1_filterfulltext, AV82Docdicionariowwds_2_tfdocdicionarioid, AV83Docdicionariowwds_3_tfdocdicionarioid_to, AV84Docdicionariowwds_4_tfinformacaoid, AV85Docdicionariowwds_5_tfinformacaoid_to, AV86Docdicionariowwds_6_tfhipotesetratamentoid, AV87Docdicionariowwds_7_tfhipotesetratamentoid_to, lV91Docdicionariowwds_11_tfdocdicionariofinalidade, AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV93Docdicionariowwds_13_tfdocdicionariodatainclusao, AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV95Docdicionariowwds_15_tfinformacaonome, AV96Docdicionariowwds_16_tfinformacaonome_sel, lV97Docdicionariowwds_17_tfhipotesetratamentonome, AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV99Docdicionariowwds_19_tfdocumentoid, AV100Docdicionariowwds_20_tfdocumentoid_to, lV101Docdicionariowwds_21_tfdocumentonome, AV102Docdicionariowwds_22_tfdocumentonome_sel, lV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P00302_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P00302_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P00302_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P00302_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P00302_A99DocDicionarioSensivel[0];
            A72HipoteseTratamentoId = P00302_A72HipoteseTratamentoId[0];
            A69InformacaoId = P00302_A69InformacaoId[0];
            A98DocDicionarioId = P00302_A98DocDicionarioId[0];
            A119DocDicionarioTipoTransfInterGa = P00302_A119DocDicionarioTipoTransfInterGa[0];
            A76DocumentoNome = P00302_A76DocumentoNome[0];
            n76DocumentoNome = P00302_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P00302_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P00302_A70InformacaoNome[0];
            A102DocDicionarioFinalidade = P00302_A102DocDicionarioFinalidade[0];
            A76DocumentoNome = P00302_A76DocumentoNome[0];
            n76DocumentoNome = P00302_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P00302_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P00302_A70InformacaoNome[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H300( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9")), 30, Gx_line+10, 84, Gx_line+55, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A69InformacaoId), "ZZZZZZZ9")), 88, Gx_line+10, 142, Gx_line+55, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A72HipoteseTratamentoId), "ZZZZZZZ9")), 146, Gx_line+10, 200, Gx_line+55, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A99DocDicionarioSensivel), 204, Gx_line+10, 258, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A100DocDicionarioPodeEliminar), 262, Gx_line+10, 316, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A101DocDicionarioTransfInter), 320, Gx_line+10, 374, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(A102DocDicionarioFinalidade, 378, Gx_line+10, 432, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A103DocDicionarioDataInclusao, "99/99/99"), 436, Gx_line+10, 490, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A70InformacaoNome, "")), 494, Gx_line+10, 548, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A73HipoteseTratamentoNome, "")), 552, Gx_line+10, 608, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), 612, Gx_line+10, 667, Gx_line+55, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A76DocumentoNome, "")), 671, Gx_line+10, 727, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(A119DocDicionarioTipoTransfInterGa, 731, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("DocDicionarioWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocDicionarioWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("DocDicionarioWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV105GXV1 = 1;
         while ( AV105GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV105GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOID") == 0 )
            {
               AV18TFDocDicionarioId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV19TFDocDicionarioId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFINFORMACAOID") == 0 )
            {
               AV22TFInformacaoId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV23TFInformacaoId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTOID") == 0 )
            {
               AV57TFHipoteseTratamentoId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV58TFHipoteseTratamentoId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOSENSIVEL_SEL") == 0 )
            {
               AV27TFDocDicionarioSensivel_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOPODEELIMINAR_SEL") == 0 )
            {
               AV28TFDocDicionarioPodeEliminar_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTRANSFINTER_SEL") == 0 )
            {
               AV74TFDocDicionarioTransfInter_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE") == 0 )
            {
               AV31TFDocDicionarioFinalidade = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE_SEL") == 0 )
            {
               AV32TFDocDicionarioFinalidade_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIODATAINCLUSAO") == 0 )
            {
               AV33TFDocDicionarioDataInclusao = context.localUtil.CToD( AV17GridStateFilterValue.gxTpr_Value, 2);
               AV34TFDocDicionarioDataInclusao_To = context.localUtil.CToD( AV17GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME") == 0 )
            {
               AV62TFInformacaoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME_SEL") == 0 )
            {
               AV63TFInformacaoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME") == 0 )
            {
               AV64TFHipoteseTratamentoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME_SEL") == 0 )
            {
               AV65TFHipoteseTratamentoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV68TFDocumentoId = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
               AV69TFDocumentoId_To = (int)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV70TFDocumentoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV71TFDocumentoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA") == 0 )
            {
               AV72TFDocDicionarioTipoTransfInterGarantia = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL") == 0 )
            {
               AV73TFDocDicionarioTipoTransfInterGarantia_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV105GXV1 = (int)(AV105GXV1+1);
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

      protected void H300( bool bFoot ,
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
                  AV53PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV50DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV48AppName = "DVelop Software Solutions";
               AV54Phone = "+1 550 8923";
               AV52Mail = "info@mail.com";
               AV56Website = "http://www.web.com";
               AV45AddressLine1 = "French Boulevard 2859";
               AV46AddressLine2 = "Downtown";
               AV47AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV55Title = "";
         AV13FilterFullText = "";
         AV35TFDocDicionarioId_To_Description = "";
         AV37TFInformacaoId_To_Description = "";
         AV59TFHipoteseTratamentoId_To_Description = "";
         AV40FilterTFDocDicionarioSensivel_SelValueDescription = "";
         AV41FilterTFDocDicionarioPodeEliminar_SelValueDescription = "";
         AV75FilterTFDocDicionarioTransfInter_SelValueDescription = "";
         AV32TFDocDicionarioFinalidade_Sel = "";
         AV31TFDocDicionarioFinalidade = "";
         AV33TFDocDicionarioDataInclusao = DateTime.MinValue;
         AV34TFDocDicionarioDataInclusao_To = DateTime.MinValue;
         AV43TFDocDicionarioDataInclusao_To_Description = "";
         AV63TFInformacaoNome_Sel = "";
         AV62TFInformacaoNome = "";
         AV65TFHipoteseTratamentoNome_Sel = "";
         AV64TFHipoteseTratamentoNome = "";
         AV36TFDocumentoId_To_Description = "";
         AV71TFDocumentoNome_Sel = "";
         AV70TFDocumentoNome = "";
         AV73TFDocDicionarioTipoTransfInterGarantia_Sel = "";
         AV72TFDocDicionarioTipoTransfInterGarantia = "";
         AV81Docdicionariowwds_1_filterfulltext = "";
         AV91Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel = "";
         AV93Docdicionariowwds_13_tfdocdicionariodatainclusao = DateTime.MinValue;
         AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to = DateTime.MinValue;
         AV95Docdicionariowwds_15_tfinformacaonome = "";
         AV96Docdicionariowwds_16_tfinformacaonome_sel = "";
         AV97Docdicionariowwds_17_tfhipotesetratamentonome = "";
         AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel = "";
         AV101Docdicionariowwds_21_tfdocumentonome = "";
         AV102Docdicionariowwds_22_tfdocumentonome_sel = "";
         AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = "";
         scmdbuf = "";
         lV81Docdicionariowwds_1_filterfulltext = "";
         lV91Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         lV95Docdicionariowwds_15_tfinformacaonome = "";
         lV97Docdicionariowwds_17_tfhipotesetratamentonome = "";
         lV101Docdicionariowwds_21_tfdocumentonome = "";
         lV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         A102DocDicionarioFinalidade = "";
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A76DocumentoNome = "";
         A119DocDicionarioTipoTransfInterGa = "";
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         P00302_A75DocumentoId = new int[1] ;
         P00302_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P00302_A101DocDicionarioTransfInter = new bool[] {false} ;
         P00302_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P00302_A99DocDicionarioSensivel = new bool[] {false} ;
         P00302_A72HipoteseTratamentoId = new int[1] ;
         P00302_A69InformacaoId = new int[1] ;
         P00302_A98DocDicionarioId = new int[1] ;
         P00302_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P00302_A76DocumentoNome = new string[] {""} ;
         P00302_n76DocumentoNome = new bool[] {false} ;
         P00302_A73HipoteseTratamentoNome = new string[] {""} ;
         P00302_A70InformacaoNome = new string[] {""} ;
         P00302_A102DocDicionarioFinalidade = new string[] {""} ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53PageInfo = "";
         AV50DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV48AppName = "";
         AV54Phone = "";
         AV52Mail = "";
         AV56Website = "";
         AV45AddressLine1 = "";
         AV46AddressLine2 = "";
         AV47AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionariowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00302_A75DocumentoId, P00302_A103DocDicionarioDataInclusao, P00302_A101DocDicionarioTransfInter, P00302_A100DocDicionarioPodeEliminar, P00302_A99DocDicionarioSensivel, P00302_A72HipoteseTratamentoId, P00302_A69InformacaoId, P00302_A98DocDicionarioId, P00302_A119DocDicionarioTipoTransfInterGa, P00302_A76DocumentoNome,
               P00302_n76DocumentoNome, P00302_A73HipoteseTratamentoNome, P00302_A70InformacaoNome, P00302_A102DocDicionarioFinalidade
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
      private short AV27TFDocDicionarioSensivel_Sel ;
      private short AV28TFDocDicionarioPodeEliminar_Sel ;
      private short AV74TFDocDicionarioTransfInter_Sel ;
      private short AV88Docdicionariowwds_8_tfdocdicionariosensivel_sel ;
      private short AV89Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ;
      private short AV90Docdicionariowwds_10_tfdocdicionariotransfinter_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV18TFDocDicionarioId ;
      private int AV19TFDocDicionarioId_To ;
      private int AV22TFInformacaoId ;
      private int AV23TFInformacaoId_To ;
      private int AV57TFHipoteseTratamentoId ;
      private int AV58TFHipoteseTratamentoId_To ;
      private int AV68TFDocumentoId ;
      private int AV69TFDocumentoId_To ;
      private int AV82Docdicionariowwds_2_tfdocdicionarioid ;
      private int AV83Docdicionariowwds_3_tfdocdicionarioid_to ;
      private int AV84Docdicionariowwds_4_tfinformacaoid ;
      private int AV85Docdicionariowwds_5_tfinformacaoid_to ;
      private int AV86Docdicionariowwds_6_tfhipotesetratamentoid ;
      private int AV87Docdicionariowwds_7_tfhipotesetratamentoid_to ;
      private int AV99Docdicionariowwds_19_tfdocumentoid ;
      private int AV100Docdicionariowwds_20_tfdocumentoid_to ;
      private int A98DocDicionarioId ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A75DocumentoId ;
      private int AV105GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV33TFDocDicionarioDataInclusao ;
      private DateTime AV34TFDocDicionarioDataInclusao_To ;
      private DateTime AV93Docdicionariowwds_13_tfdocdicionariodatainclusao ;
      private DateTime AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to ;
      private DateTime A103DocDicionarioDataInclusao ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV44TempBoolean ;
      private bool A99DocDicionarioSensivel ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A101DocDicionarioTransfInter ;
      private bool AV12OrderedDsc ;
      private bool n76DocumentoNome ;
      private string AV91Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel ;
      private string lV91Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string AV55Title ;
      private string AV13FilterFullText ;
      private string AV35TFDocDicionarioId_To_Description ;
      private string AV37TFInformacaoId_To_Description ;
      private string AV59TFHipoteseTratamentoId_To_Description ;
      private string AV40FilterTFDocDicionarioSensivel_SelValueDescription ;
      private string AV41FilterTFDocDicionarioPodeEliminar_SelValueDescription ;
      private string AV75FilterTFDocDicionarioTransfInter_SelValueDescription ;
      private string AV32TFDocDicionarioFinalidade_Sel ;
      private string AV31TFDocDicionarioFinalidade ;
      private string AV43TFDocDicionarioDataInclusao_To_Description ;
      private string AV63TFInformacaoNome_Sel ;
      private string AV62TFInformacaoNome ;
      private string AV65TFHipoteseTratamentoNome_Sel ;
      private string AV64TFHipoteseTratamentoNome ;
      private string AV36TFDocumentoId_To_Description ;
      private string AV71TFDocumentoNome_Sel ;
      private string AV70TFDocumentoNome ;
      private string AV73TFDocDicionarioTipoTransfInterGarantia_Sel ;
      private string AV72TFDocDicionarioTipoTransfInterGarantia ;
      private string AV81Docdicionariowwds_1_filterfulltext ;
      private string AV95Docdicionariowwds_15_tfinformacaonome ;
      private string AV96Docdicionariowwds_16_tfinformacaonome_sel ;
      private string AV97Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel ;
      private string AV101Docdicionariowwds_21_tfdocumentonome ;
      private string AV102Docdicionariowwds_22_tfdocumentonome_sel ;
      private string AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ;
      private string lV81Docdicionariowwds_1_filterfulltext ;
      private string lV95Docdicionariowwds_15_tfinformacaonome ;
      private string lV97Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string lV101Docdicionariowwds_21_tfdocumentonome ;
      private string lV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string A76DocumentoNome ;
      private string AV53PageInfo ;
      private string AV50DateInfo ;
      private string AV48AppName ;
      private string AV54Phone ;
      private string AV52Mail ;
      private string AV56Website ;
      private string AV45AddressLine1 ;
      private string AV46AddressLine2 ;
      private string AV47AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00302_A75DocumentoId ;
      private DateTime[] P00302_A103DocDicionarioDataInclusao ;
      private bool[] P00302_A101DocDicionarioTransfInter ;
      private bool[] P00302_A100DocDicionarioPodeEliminar ;
      private bool[] P00302_A99DocDicionarioSensivel ;
      private int[] P00302_A72HipoteseTratamentoId ;
      private int[] P00302_A69InformacaoId ;
      private int[] P00302_A98DocDicionarioId ;
      private string[] P00302_A119DocDicionarioTipoTransfInterGa ;
      private string[] P00302_A76DocumentoNome ;
      private bool[] P00302_n76DocumentoNome ;
      private string[] P00302_A73HipoteseTratamentoNome ;
      private string[] P00302_A70InformacaoNome ;
      private string[] P00302_A102DocDicionarioFinalidade ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class docdicionariowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00302( IGxContext context ,
                                             string AV81Docdicionariowwds_1_filterfulltext ,
                                             int AV82Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV83Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV84Docdicionariowwds_4_tfinformacaoid ,
                                             int AV85Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV86Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV87Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV88Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV89Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV90Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV91Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV93Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV96Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV95Docdicionariowwds_15_tfinformacaonome ,
                                             string AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV97Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV99Docdicionariowwds_19_tfdocumentoid ,
                                             int AV100Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV102Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV101Docdicionariowwds_21_tfdocumentonome ,
                                             string AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[29];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[InformacaoId], T1.[DocDicionarioId], T1.[DocDicionarioTipoTransfInterGa], T2.[DocumentoNome], T3.[HipoteseTratamentoNome], T4.[InformacaoNome], T1.[DocDicionarioFinalidade] FROM ((([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( T2.[DocumentoNome] like '%' + @lV81Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV81Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV82Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV82Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV83Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV83Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (0==AV84Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV84Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV85Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV85Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV86Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV86Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV87Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV87Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV88Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV88Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV89Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV89Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV90Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV90Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV91Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV93Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV93Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV95Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV96Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV96Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV96Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV97Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV99Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV99Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (0==AV100Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV100Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV101Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV102Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV102Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( StringUtil.StrCmp(AV102Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( StringUtil.StrCmp(AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioSensivel]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioSensivel] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InformacaoId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InformacaoId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HipoteseTratamentoId]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HipoteseTratamentoId] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioPodeEliminar]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioPodeEliminar] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTransfInter]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTransfInter] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioFinalidade]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioFinalidade] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioDataInclusao]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioDataInclusao] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[InformacaoNome]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[InformacaoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[HipoteseTratamentoNome]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[HipoteseTratamentoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocumentoId]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocumentoId] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTipoTransfInterGa]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTipoTransfInterGa] DESC";
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
                     return conditional_P00302(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
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
          Object[] prmP00302;
          prmP00302 = new Object[] {
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV81Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV83Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV84Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV85Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV86Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV87Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV91Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV92Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV93Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV94Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV95Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV96Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV97Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV98Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV99Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV100Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV101Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV102Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV103Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV104Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00302", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00302,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                return;
       }
    }

 }

}
