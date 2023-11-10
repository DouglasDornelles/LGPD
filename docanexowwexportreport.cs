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
   public class docanexowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public docanexowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docanexowwexportreport( IGxContext context )
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
         docanexowwexportreport objdocanexowwexportreport;
         objdocanexowwexportreport = new docanexowwexportreport();
         objdocanexowwexportreport.context.SetSubmitInitialConfig(context);
         objdocanexowwexportreport.initialize();
         Submit( executePrivateCatch,objdocanexowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docanexowwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docanexoww_Execute", out  GXt_boolean1) ;
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
               AV40Title = "Lista de Doc Anexo";
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
            H4Z0( true, 0) ;
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
            H4Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFDocumentoNome_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV43TFDocumentoNome_Sel, "<#Empty#>")==0)));
            AV43TFDocumentoNome_Sel = (AV29TempBoolean ? "(Vazio)" : AV43TFDocumentoNome_Sel);
            H4Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Documento", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFDocumentoNome_Sel, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFDocumentoNome_Sel = (AV29TempBoolean ? "<#Empty#>" : AV43TFDocumentoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFDocumentoNome)) )
            {
               H4Z0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Documento", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFDocumentoNome, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFDocAnexoDescricao_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV23TFDocAnexoDescricao_Sel, "<#Empty#>")==0)));
            AV23TFDocAnexoDescricao_Sel = (AV29TempBoolean ? "(Vazio)" : AV23TFDocAnexoDescricao_Sel);
            H4Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFDocAnexoDescricao_Sel, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV23TFDocAnexoDescricao_Sel = (AV29TempBoolean ? "<#Empty#>" : AV23TFDocAnexoDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFDocAnexoDescricao)) )
            {
               H4Z0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFDocAnexoDescricao, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocAnexoArquivo_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV45TFDocAnexoArquivo_Sel, "<#Empty#>")==0)));
            AV45TFDocAnexoArquivo_Sel = (AV29TempBoolean ? "(Vazio)" : AV45TFDocAnexoArquivo_Sel);
            H4Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Arquivo", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFDocAnexoArquivo_Sel, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFDocAnexoArquivo_Sel = (AV29TempBoolean ? "<#Empty#>" : AV45TFDocAnexoArquivo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocAnexoArquivo)) )
            {
               H4Z0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Arquivo", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFDocAnexoArquivo, "")), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV24TFDocAnexoDataInclusao) && (DateTime.MinValue==AV25TFDocAnexoDataInclusao_To) ) )
         {
            H4Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data de Inclusão", 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV24TFDocAnexoDataInclusao, "99/99/99"), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV28TFDocAnexoDataInclusao_To_Description = StringUtil.Format( "%1 (%2)", "Data de Inclusão", "Até", "", "", "", "", "", "", "");
            H4Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TFDocAnexoDataInclusao_To_Description, "")), 25, Gx_line+0, 142, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25TFDocAnexoDataInclusao_To, "99/99/99"), 142, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4Z0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4Z0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Documento", 30, Gx_line+10, 242, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 246, Gx_line+10, 458, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Arquivo", 462, Gx_line+10, 676, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data de Inclusão", 680, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV51Docanexowwds_1_filterfulltext = AV13FilterFullText;
         AV52Docanexowwds_2_tfdocumentonome = AV42TFDocumentoNome;
         AV53Docanexowwds_3_tfdocumentonome_sel = AV43TFDocumentoNome_Sel;
         AV54Docanexowwds_4_tfdocanexodescricao = AV22TFDocAnexoDescricao;
         AV55Docanexowwds_5_tfdocanexodescricao_sel = AV23TFDocAnexoDescricao_Sel;
         AV56Docanexowwds_6_tfdocanexoarquivo = AV44TFDocAnexoArquivo;
         AV57Docanexowwds_7_tfdocanexoarquivo_sel = AV45TFDocAnexoArquivo_Sel;
         AV58Docanexowwds_8_tfdocanexodatainclusao = AV24TFDocAnexoDataInclusao;
         AV59Docanexowwds_9_tfdocanexodatainclusao_to = AV25TFDocAnexoDataInclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Docanexowwds_1_filterfulltext ,
                                              AV53Docanexowwds_3_tfdocumentonome_sel ,
                                              AV52Docanexowwds_2_tfdocumentonome ,
                                              AV55Docanexowwds_5_tfdocanexodescricao_sel ,
                                              AV54Docanexowwds_4_tfdocanexodescricao ,
                                              AV57Docanexowwds_7_tfdocanexoarquivo_sel ,
                                              AV56Docanexowwds_6_tfdocanexoarquivo ,
                                              AV58Docanexowwds_8_tfdocanexodatainclusao ,
                                              AV59Docanexowwds_9_tfdocanexodatainclusao_to ,
                                              A76DocumentoNome ,
                                              A94DocAnexoDescricao ,
                                              A95DocAnexoArquivo ,
                                              A96DocAnexoDataInclusao ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Docanexowwds_1_filterfulltext), "%", "");
         lV51Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Docanexowwds_1_filterfulltext), "%", "");
         lV51Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Docanexowwds_1_filterfulltext), "%", "");
         lV52Docanexowwds_2_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV52Docanexowwds_2_tfdocumentonome), "%", "");
         lV54Docanexowwds_4_tfdocanexodescricao = StringUtil.Concat( StringUtil.RTrim( AV54Docanexowwds_4_tfdocanexodescricao), "%", "");
         lV56Docanexowwds_6_tfdocanexoarquivo = StringUtil.Concat( StringUtil.RTrim( AV56Docanexowwds_6_tfdocanexoarquivo), "%", "");
         /* Using cursor P004Z2 */
         pr_default.execute(0, new Object[] {lV51Docanexowwds_1_filterfulltext, lV51Docanexowwds_1_filterfulltext, lV51Docanexowwds_1_filterfulltext, lV52Docanexowwds_2_tfdocumentonome, AV53Docanexowwds_3_tfdocumentonome_sel, lV54Docanexowwds_4_tfdocanexodescricao, AV55Docanexowwds_5_tfdocanexodescricao_sel, lV56Docanexowwds_6_tfdocanexoarquivo, AV57Docanexowwds_7_tfdocanexoarquivo_sel, AV58Docanexowwds_8_tfdocanexodatainclusao, AV59Docanexowwds_9_tfdocanexodatainclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P004Z2_A75DocumentoId[0];
            A96DocAnexoDataInclusao = P004Z2_A96DocAnexoDataInclusao[0];
            A95DocAnexoArquivo = P004Z2_A95DocAnexoArquivo[0];
            A94DocAnexoDescricao = P004Z2_A94DocAnexoDescricao[0];
            A76DocumentoNome = P004Z2_A76DocumentoNome[0];
            n76DocumentoNome = P004Z2_n76DocumentoNome[0];
            A93DocAnexoId = P004Z2_A93DocAnexoId[0];
            A76DocumentoNome = P004Z2_A76DocumentoNome[0];
            n76DocumentoNome = P004Z2_n76DocumentoNome[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4Z0( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A76DocumentoNome, "")), 30, Gx_line+10, 242, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A94DocAnexoDescricao, "")), 246, Gx_line+10, 458, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A95DocAnexoArquivo, "")), 462, Gx_line+10, 676, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A96DocAnexoDataInclusao, "99/99/99"), 680, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("DocAnexoWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocAnexoWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("DocAnexoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV42TFDocumentoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV43TFDocumentoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCANEXODESCRICAO") == 0 )
            {
               AV22TFDocAnexoDescricao = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCANEXODESCRICAO_SEL") == 0 )
            {
               AV23TFDocAnexoDescricao_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCANEXOARQUIVO") == 0 )
            {
               AV44TFDocAnexoArquivo = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCANEXOARQUIVO_SEL") == 0 )
            {
               AV45TFDocAnexoArquivo_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFDOCANEXODATAINCLUSAO") == 0 )
            {
               AV24TFDocAnexoDataInclusao = context.localUtil.CToD( AV17GridStateFilterValue.gxTpr_Value, 2);
               AV25TFDocAnexoDataInclusao_To = context.localUtil.CToD( AV17GridStateFilterValue.gxTpr_Valueto, 2);
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

      protected void H4Z0( bool bFoot ,
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
                  AV38PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV35DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV33AppName = "DVelop Software Solutions";
               AV39Phone = "+1 550 8923";
               AV37Mail = "info@mail.com";
               AV41Website = "http://www.web.com";
               AV30AddressLine1 = "French Boulevard 2859";
               AV31AddressLine2 = "Downtown";
               AV32AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV40Title = "";
         AV13FilterFullText = "";
         AV43TFDocumentoNome_Sel = "";
         AV42TFDocumentoNome = "";
         AV23TFDocAnexoDescricao_Sel = "";
         AV22TFDocAnexoDescricao = "";
         AV45TFDocAnexoArquivo_Sel = "";
         AV44TFDocAnexoArquivo = "";
         AV24TFDocAnexoDataInclusao = DateTime.MinValue;
         AV25TFDocAnexoDataInclusao_To = DateTime.MinValue;
         AV28TFDocAnexoDataInclusao_To_Description = "";
         AV51Docanexowwds_1_filterfulltext = "";
         AV52Docanexowwds_2_tfdocumentonome = "";
         AV53Docanexowwds_3_tfdocumentonome_sel = "";
         AV54Docanexowwds_4_tfdocanexodescricao = "";
         AV55Docanexowwds_5_tfdocanexodescricao_sel = "";
         AV56Docanexowwds_6_tfdocanexoarquivo = "";
         AV57Docanexowwds_7_tfdocanexoarquivo_sel = "";
         AV58Docanexowwds_8_tfdocanexodatainclusao = DateTime.MinValue;
         AV59Docanexowwds_9_tfdocanexodatainclusao_to = DateTime.MinValue;
         scmdbuf = "";
         lV51Docanexowwds_1_filterfulltext = "";
         lV52Docanexowwds_2_tfdocumentonome = "";
         lV54Docanexowwds_4_tfdocanexodescricao = "";
         lV56Docanexowwds_6_tfdocanexoarquivo = "";
         A76DocumentoNome = "";
         A94DocAnexoDescricao = "";
         A95DocAnexoArquivo = "";
         A96DocAnexoDataInclusao = DateTime.MinValue;
         P004Z2_A75DocumentoId = new int[1] ;
         P004Z2_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004Z2_A95DocAnexoArquivo = new string[] {""} ;
         P004Z2_A94DocAnexoDescricao = new string[] {""} ;
         P004Z2_A76DocumentoNome = new string[] {""} ;
         P004Z2_n76DocumentoNome = new bool[] {false} ;
         P004Z2_A93DocAnexoId = new int[1] ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38PageInfo = "";
         AV35DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV33AppName = "";
         AV39Phone = "";
         AV37Mail = "";
         AV41Website = "";
         AV30AddressLine1 = "";
         AV31AddressLine2 = "";
         AV32AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docanexowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004Z2_A75DocumentoId, P004Z2_A96DocAnexoDataInclusao, P004Z2_A95DocAnexoArquivo, P004Z2_A94DocAnexoDescricao, P004Z2_A76DocumentoNome, P004Z2_n76DocumentoNome, P004Z2_A93DocAnexoId
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
      private int A75DocumentoId ;
      private int A93DocAnexoId ;
      private int AV60GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV24TFDocAnexoDataInclusao ;
      private DateTime AV25TFDocAnexoDataInclusao_To ;
      private DateTime AV58Docanexowwds_8_tfdocanexodatainclusao ;
      private DateTime AV59Docanexowwds_9_tfdocanexodatainclusao_to ;
      private DateTime A96DocAnexoDataInclusao ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV29TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n76DocumentoNome ;
      private string AV40Title ;
      private string AV13FilterFullText ;
      private string AV43TFDocumentoNome_Sel ;
      private string AV42TFDocumentoNome ;
      private string AV23TFDocAnexoDescricao_Sel ;
      private string AV22TFDocAnexoDescricao ;
      private string AV45TFDocAnexoArquivo_Sel ;
      private string AV44TFDocAnexoArquivo ;
      private string AV28TFDocAnexoDataInclusao_To_Description ;
      private string AV51Docanexowwds_1_filterfulltext ;
      private string AV52Docanexowwds_2_tfdocumentonome ;
      private string AV53Docanexowwds_3_tfdocumentonome_sel ;
      private string AV54Docanexowwds_4_tfdocanexodescricao ;
      private string AV55Docanexowwds_5_tfdocanexodescricao_sel ;
      private string AV56Docanexowwds_6_tfdocanexoarquivo ;
      private string AV57Docanexowwds_7_tfdocanexoarquivo_sel ;
      private string lV51Docanexowwds_1_filterfulltext ;
      private string lV52Docanexowwds_2_tfdocumentonome ;
      private string lV54Docanexowwds_4_tfdocanexodescricao ;
      private string lV56Docanexowwds_6_tfdocanexoarquivo ;
      private string A76DocumentoNome ;
      private string A94DocAnexoDescricao ;
      private string A95DocAnexoArquivo ;
      private string AV38PageInfo ;
      private string AV35DateInfo ;
      private string AV33AppName ;
      private string AV39Phone ;
      private string AV37Mail ;
      private string AV41Website ;
      private string AV30AddressLine1 ;
      private string AV31AddressLine2 ;
      private string AV32AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004Z2_A75DocumentoId ;
      private DateTime[] P004Z2_A96DocAnexoDataInclusao ;
      private string[] P004Z2_A95DocAnexoArquivo ;
      private string[] P004Z2_A94DocAnexoDescricao ;
      private string[] P004Z2_A76DocumentoNome ;
      private bool[] P004Z2_n76DocumentoNome ;
      private int[] P004Z2_A93DocAnexoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class docanexowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Z2( IGxContext context ,
                                             string AV51Docanexowwds_1_filterfulltext ,
                                             string AV53Docanexowwds_3_tfdocumentonome_sel ,
                                             string AV52Docanexowwds_2_tfdocumentonome ,
                                             string AV55Docanexowwds_5_tfdocanexodescricao_sel ,
                                             string AV54Docanexowwds_4_tfdocanexodescricao ,
                                             string AV57Docanexowwds_7_tfdocanexoarquivo_sel ,
                                             string AV56Docanexowwds_6_tfdocanexoarquivo ,
                                             DateTime AV58Docanexowwds_8_tfdocanexodatainclusao ,
                                             DateTime AV59Docanexowwds_9_tfdocanexodatainclusao_to ,
                                             string A76DocumentoNome ,
                                             string A94DocAnexoDescricao ,
                                             string A95DocAnexoArquivo ,
                                             DateTime A96DocAnexoDataInclusao ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocAnexoDataInclusao], T1.[DocAnexoArquivo], T1.[DocAnexoDescricao], T2.[DocumentoNome], T1.[DocAnexoId] FROM ([DocAnexo] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Docanexowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.[DocumentoNome] like '%' + @lV51Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoDescricao] like '%' + @lV51Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoArquivo] like '%' + @lV51Docanexowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Docanexowwds_3_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_2_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV52Docanexowwds_2_tfdocumentonome)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Docanexowwds_3_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV53Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV53Docanexowwds_3_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV53Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Docanexowwds_5_tfdocanexodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_4_tfdocanexodescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] like @lV54Docanexowwds_4_tfdocanexodescricao)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Docanexowwds_5_tfdocanexodescricao_sel)) && ! ( StringUtil.StrCmp(AV55Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] = @AV55Docanexowwds_5_tfdocanexodescricao_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Docanexowwds_7_tfdocanexoarquivo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_6_tfdocanexoarquivo)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] like @lV56Docanexowwds_6_tfdocanexoarquivo)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Docanexowwds_7_tfdocanexoarquivo_sel)) && ! ( StringUtil.StrCmp(AV57Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] = @AV57Docanexowwds_7_tfdocanexoarquivo_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV57Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoArquivo] = ''))");
         }
         if ( ! (DateTime.MinValue==AV58Docanexowwds_8_tfdocanexodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] >= @AV58Docanexowwds_8_tfdocanexodatainclusao)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Docanexowwds_9_tfdocanexodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] <= @AV59Docanexowwds_9_tfdocanexodatainclusao_to)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDescricao]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDescricao] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoArquivo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoArquivo] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDataInclusao]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDataInclusao] DESC";
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
                     return conditional_P004Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP004Z2;
          prmP004Z2 = new Object[] {
          new ParDef("@lV51Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV52Docanexowwds_2_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV53Docanexowwds_3_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Docanexowwds_4_tfdocanexodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV55Docanexowwds_5_tfdocanexodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Docanexowwds_6_tfdocanexoarquivo",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Docanexowwds_7_tfdocanexoarquivo_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV58Docanexowwds_8_tfdocanexodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV59Docanexowwds_9_tfdocanexodatainclusao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
