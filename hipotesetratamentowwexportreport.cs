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
   public class hipotesetratamentowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public hipotesetratamentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public hipotesetratamentowwexportreport( IGxContext context )
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
         hipotesetratamentowwexportreport objhipotesetratamentowwexportreport;
         objhipotesetratamentowwexportreport = new hipotesetratamentowwexportreport();
         objhipotesetratamentowwexportreport.context.SetSubmitInitialConfig(context);
         objhipotesetratamentowwexportreport.initialize();
         Submit( executePrivateCatch,objhipotesetratamentowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((hipotesetratamentowwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "hipotesetratamentoww_Execute", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S161 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV35Title = "Lista de Hipotese Tratamento";
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
            H2E0( true, 0) ;
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
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFHipoteseTratamentoNome_Sel)) )
         {
            AV24TempBoolean = (bool)(((StringUtil.StrCmp(AV20TFHipoteseTratamentoNome_Sel, "<#Empty#>")==0)));
            AV20TFHipoteseTratamentoNome_Sel = (AV24TempBoolean ? "(Vazio)" : AV20TFHipoteseTratamentoNome_Sel);
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFHipoteseTratamentoNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV20TFHipoteseTratamentoNome_Sel = (AV24TempBoolean ? "<#Empty#>" : AV20TFHipoteseTratamentoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFHipoteseTratamentoNome)) )
            {
               H2E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFHipoteseTratamentoNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV21TFHipoteseTratamentoAtivo_Sel) )
         {
            if ( AV21TFHipoteseTratamentoAtivo_Sel == 1 )
            {
               AV23FilterTFHipoteseTratamentoAtivo_SelValueDescription = "Marcado";
            }
            else if ( AV21TFHipoteseTratamentoAtivo_Sel == 2 )
            {
               AV23FilterTFHipoteseTratamentoAtivo_SelValueDescription = "Desmarcado";
            }
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ativo?", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterTFHipoteseTratamentoAtivo_SelValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2E0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2E0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ativo?", 410, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV43Hipotesetratamentowwds_1_filterfulltext = AV13FilterFullText;
         AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome = AV19TFHipoteseTratamentoNome;
         AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel = AV20TFHipoteseTratamentoNome_Sel;
         AV46Hipotesetratamentowwds_4_tfhipotesetratamentoativo_sel = AV21TFHipoteseTratamentoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Hipotesetratamentowwds_1_filterfulltext ,
                                              AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel ,
                                              AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome ,
                                              AV46Hipotesetratamentowwds_4_tfhipotesetratamentoativo_sel ,
                                              A73HipoteseTratamentoNome ,
                                              A74HipoteseTratamentoAtivo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Hipotesetratamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Hipotesetratamentowwds_1_filterfulltext), "%", "");
         lV43Hipotesetratamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Hipotesetratamentowwds_1_filterfulltext), "%", "");
         lV43Hipotesetratamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Hipotesetratamentowwds_1_filterfulltext), "%", "");
         lV44Hipotesetratamentowwds_2_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome), "%", "");
         /* Using cursor P002E2 */
         pr_default.execute(0, new Object[] {lV43Hipotesetratamentowwds_1_filterfulltext, lV43Hipotesetratamentowwds_1_filterfulltext, lV43Hipotesetratamentowwds_1_filterfulltext, lV44Hipotesetratamentowwds_2_tfhipotesetratamentonome, AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A74HipoteseTratamentoAtivo = P002E2_A74HipoteseTratamentoAtivo[0];
            A73HipoteseTratamentoNome = P002E2_A73HipoteseTratamentoNome[0];
            A72HipoteseTratamentoId = P002E2_A72HipoteseTratamentoId[0];
            AV37HipoteseTratamentoAtivoDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A74HipoteseTratamentoAtivo)), "true") == 0 )
            {
               AV37HipoteseTratamentoAtivoDescription = "SIM";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A74HipoteseTratamentoAtivo)), "false") == 0 )
            {
               AV37HipoteseTratamentoAtivoDescription = "NÃO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A74HipoteseTratamentoAtivo )
            {
               H2E0( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 223, 240, 216, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 166, 90, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A73HipoteseTratamentoNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37HipoteseTratamentoAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else if ( ! A74HipoteseTratamentoAtivo )
            {
               H2E0( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A73HipoteseTratamentoNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37HipoteseTratamentoAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else
            {
               H2E0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A73HipoteseTratamentoNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37HipoteseTratamentoAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S154 ();
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

      protected void S161( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get("HipoteseTratamentoWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HipoteseTratamentoWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("HipoteseTratamentoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME") == 0 )
            {
               AV19TFHipoteseTratamentoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME_SEL") == 0 )
            {
               AV20TFHipoteseTratamentoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTOATIVO_SEL") == 0 )
            {
               AV21TFHipoteseTratamentoAtivo_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S154( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H2E0( bool bFoot ,
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
                  AV33PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV30DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV28AppName = "DVelop Software Solutions";
               AV34Phone = "+1 550 8923";
               AV32Mail = "info@mail.com";
               AV36Website = "http://www.web.com";
               AV25AddressLine1 = "French Boulevard 2859";
               AV26AddressLine2 = "Downtown";
               AV27AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV35Title = "";
         AV13FilterFullText = "";
         AV20TFHipoteseTratamentoNome_Sel = "";
         AV19TFHipoteseTratamentoNome = "";
         AV23FilterTFHipoteseTratamentoAtivo_SelValueDescription = "";
         AV43Hipotesetratamentowwds_1_filterfulltext = "";
         AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome = "";
         AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel = "";
         scmdbuf = "";
         lV43Hipotesetratamentowwds_1_filterfulltext = "";
         lV44Hipotesetratamentowwds_2_tfhipotesetratamentonome = "";
         A73HipoteseTratamentoNome = "";
         P002E2_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         P002E2_A73HipoteseTratamentoNome = new string[] {""} ;
         P002E2_A72HipoteseTratamentoId = new int[1] ;
         AV37HipoteseTratamentoAtivoDescription = "";
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV33PageInfo = "";
         AV30DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV28AppName = "";
         AV34Phone = "";
         AV32Mail = "";
         AV36Website = "";
         AV25AddressLine1 = "";
         AV26AddressLine2 = "";
         AV27AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.hipotesetratamentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002E2_A74HipoteseTratamentoAtivo, P002E2_A73HipoteseTratamentoNome, P002E2_A72HipoteseTratamentoId
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
      private short AV21TFHipoteseTratamentoAtivo_Sel ;
      private short AV46Hipotesetratamentowwds_4_tfhipotesetratamentoativo_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A72HipoteseTratamentoId ;
      private int AV47GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24TempBoolean ;
      private bool A74HipoteseTratamentoAtivo ;
      private bool AV12OrderedDsc ;
      private string AV35Title ;
      private string AV13FilterFullText ;
      private string AV20TFHipoteseTratamentoNome_Sel ;
      private string AV19TFHipoteseTratamentoNome ;
      private string AV23FilterTFHipoteseTratamentoAtivo_SelValueDescription ;
      private string AV43Hipotesetratamentowwds_1_filterfulltext ;
      private string AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome ;
      private string AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel ;
      private string lV43Hipotesetratamentowwds_1_filterfulltext ;
      private string lV44Hipotesetratamentowwds_2_tfhipotesetratamentonome ;
      private string A73HipoteseTratamentoNome ;
      private string AV37HipoteseTratamentoAtivoDescription ;
      private string AV33PageInfo ;
      private string AV30DateInfo ;
      private string AV28AppName ;
      private string AV34Phone ;
      private string AV32Mail ;
      private string AV36Website ;
      private string AV25AddressLine1 ;
      private string AV26AddressLine2 ;
      private string AV27AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P002E2_A74HipoteseTratamentoAtivo ;
      private string[] P002E2_A73HipoteseTratamentoNome ;
      private int[] P002E2_A72HipoteseTratamentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class hipotesetratamentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002E2( IGxContext context ,
                                             string AV43Hipotesetratamentowwds_1_filterfulltext ,
                                             string AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel ,
                                             string AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome ,
                                             short AV46Hipotesetratamentowwds_4_tfhipotesetratamentoativo_sel ,
                                             string A73HipoteseTratamentoNome ,
                                             bool A74HipoteseTratamentoAtivo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [HipoteseTratamentoAtivo], [HipoteseTratamentoNome], [HipoteseTratamentoId] FROM [HipoteseTratamento]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Hipotesetratamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [HipoteseTratamentoNome] like '%' + @lV43Hipotesetratamentowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV43Hipotesetratamentowwds_1_filterfulltext) and [HipoteseTratamentoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV43Hipotesetratamentowwds_1_filterfulltext) and [HipoteseTratamentoAtivo] = 0))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Hipotesetratamentowwds_2_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "([HipoteseTratamentoNome] like @lV44Hipotesetratamentowwds_2_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HipoteseTratamentoNome] = @AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HipoteseTratamentoNome] = ''))");
         }
         if ( AV46Hipotesetratamentowwds_4_tfhipotesetratamentoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([HipoteseTratamentoAtivo] = 1)");
         }
         if ( AV46Hipotesetratamentowwds_4_tfhipotesetratamentoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([HipoteseTratamentoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [HipoteseTratamentoNome]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HipoteseTratamentoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [HipoteseTratamentoAtivo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [HipoteseTratamentoAtivo] DESC";
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
                     return conditional_P002E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP002E2;
          prmP002E2 = new Object[] {
          new ParDef("@lV43Hipotesetratamentowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV43Hipotesetratamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV43Hipotesetratamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Hipotesetratamentowwds_2_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV45Hipotesetratamentowwds_3_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
