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
   public class abrangenciageograficawwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public abrangenciageograficawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public abrangenciageograficawwexportreport( IGxContext context )
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
         abrangenciageograficawwexportreport objabrangenciageograficawwexportreport;
         objabrangenciageograficawwexportreport = new abrangenciageograficawwexportreport();
         objabrangenciageograficawwexportreport.context.SetSubmitInitialConfig(context);
         objabrangenciageograficawwexportreport.initialize();
         Submit( executePrivateCatch,objabrangenciageograficawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((abrangenciageograficawwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "abrangenciageograficaww_Execute", out  GXt_boolean1) ;
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
               AV37Title = "Lista de Abrangencia Geografica";
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
            H6Y0( true, 0) ;
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
            H6Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFAbrangenciaGeograficaNome_Sel)) )
         {
            AV26TempBoolean = (bool)(((StringUtil.StrCmp(AV22TFAbrangenciaGeograficaNome_Sel, "<#Empty#>")==0)));
            AV22TFAbrangenciaGeograficaNome_Sel = (AV26TempBoolean ? "(Vazio)" : AV22TFAbrangenciaGeograficaNome_Sel);
            H6Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFAbrangenciaGeograficaNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV22TFAbrangenciaGeograficaNome_Sel = (AV26TempBoolean ? "<#Empty#>" : AV22TFAbrangenciaGeograficaNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFAbrangenciaGeograficaNome)) )
            {
               H6Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFAbrangenciaGeograficaNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV23TFAbrangenciaGeograficaAtivo_Sel) )
         {
            if ( AV23TFAbrangenciaGeograficaAtivo_Sel == 1 )
            {
               AV25FilterTFAbrangenciaGeograficaAtivo_SelValueDescription = "Marcado";
            }
            else if ( AV23TFAbrangenciaGeograficaAtivo_Sel == 2 )
            {
               AV25FilterTFAbrangenciaGeograficaAtivo_SelValueDescription = "Desmarcado";
            }
            H6Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ativo?", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25FilterTFAbrangenciaGeograficaAtivo_SelValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6Y0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6Y0( false, 37) ;
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
         AV44Abrangenciageograficawwds_1_filterfulltext = AV13FilterFullText;
         AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome = AV21TFAbrangenciaGeograficaNome;
         AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel = AV22TFAbrangenciaGeograficaNome_Sel;
         AV47Abrangenciageograficawwds_4_tfabrangenciageograficaativo_sel = AV23TFAbrangenciaGeograficaAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Abrangenciageograficawwds_1_filterfulltext ,
                                              AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel ,
                                              AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome ,
                                              AV47Abrangenciageograficawwds_4_tfabrangenciageograficaativo_sel ,
                                              A37AbrangenciaGeograficaNome ,
                                              A38AbrangenciaGeograficaAtivo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV44Abrangenciageograficawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Abrangenciageograficawwds_1_filterfulltext), "%", "");
         lV44Abrangenciageograficawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Abrangenciageograficawwds_1_filterfulltext), "%", "");
         lV44Abrangenciageograficawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Abrangenciageograficawwds_1_filterfulltext), "%", "");
         lV45Abrangenciageograficawwds_2_tfabrangenciageograficanome = StringUtil.Concat( StringUtil.RTrim( AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome), "%", "");
         /* Using cursor P006Y2 */
         pr_default.execute(0, new Object[] {lV44Abrangenciageograficawwds_1_filterfulltext, lV44Abrangenciageograficawwds_1_filterfulltext, lV44Abrangenciageograficawwds_1_filterfulltext, lV45Abrangenciageograficawwds_2_tfabrangenciageograficanome, AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A38AbrangenciaGeograficaAtivo = P006Y2_A38AbrangenciaGeograficaAtivo[0];
            A37AbrangenciaGeograficaNome = P006Y2_A37AbrangenciaGeograficaNome[0];
            A36AbrangenciaGeograficaId = P006Y2_A36AbrangenciaGeograficaId[0];
            AV14AbrangenciaGeograficaAtivoDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A38AbrangenciaGeograficaAtivo)), "true") == 0 )
            {
               AV14AbrangenciaGeograficaAtivoDescription = "SIM";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A38AbrangenciaGeograficaAtivo)), "false") == 0 )
            {
               AV14AbrangenciaGeograficaAtivoDescription = "NÃO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A38AbrangenciaGeograficaAtivo )
            {
               H6Y0( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 223, 240, 216, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 166, 90, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A37AbrangenciaGeograficaNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AbrangenciaGeograficaAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else if ( ! A38AbrangenciaGeograficaAtivo )
            {
               H6Y0( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A37AbrangenciaGeograficaNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AbrangenciaGeograficaAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else
            {
               H6Y0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A37AbrangenciaGeograficaNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AbrangenciaGeograficaAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV15Session.Get("AbrangenciaGeograficaWWGridState"), "") == 0 )
         {
            AV17GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AbrangenciaGeograficaWWGridState"), null, "", "");
         }
         else
         {
            AV17GridState.FromXml(AV15Session.Get("AbrangenciaGeograficaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV17GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV17GridState.gxTpr_Ordereddsc;
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV17GridState.gxTpr_Filtervalues.Count )
         {
            AV18GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV17GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV18GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFABRANGENCIAGEOGRAFICANOME") == 0 )
            {
               AV21TFAbrangenciaGeograficaNome = AV18GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFABRANGENCIAGEOGRAFICANOME_SEL") == 0 )
            {
               AV22TFAbrangenciaGeograficaNome_Sel = AV18GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFABRANGENCIAGEOGRAFICAATIVO_SEL") == 0 )
            {
               AV23TFAbrangenciaGeograficaAtivo_Sel = (short)(NumberUtil.Val( AV18GridStateFilterValue.gxTpr_Value, "."));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
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

      protected void H6Y0( bool bFoot ,
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
                  AV35PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV32DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV30AppName = "DVelop Software Solutions";
               AV36Phone = "+1 550 8923";
               AV34Mail = "info@mail.com";
               AV38Website = "http://www.web.com";
               AV27AddressLine1 = "French Boulevard 2859";
               AV28AddressLine2 = "Downtown";
               AV29AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV37Title = "";
         AV13FilterFullText = "";
         AV22TFAbrangenciaGeograficaNome_Sel = "";
         AV21TFAbrangenciaGeograficaNome = "";
         AV25FilterTFAbrangenciaGeograficaAtivo_SelValueDescription = "";
         AV44Abrangenciageograficawwds_1_filterfulltext = "";
         AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome = "";
         AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel = "";
         scmdbuf = "";
         lV44Abrangenciageograficawwds_1_filterfulltext = "";
         lV45Abrangenciageograficawwds_2_tfabrangenciageograficanome = "";
         A37AbrangenciaGeograficaNome = "";
         P006Y2_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         P006Y2_A37AbrangenciaGeograficaNome = new string[] {""} ;
         P006Y2_A36AbrangenciaGeograficaId = new int[1] ;
         AV14AbrangenciaGeograficaAtivoDescription = "";
         AV15Session = context.GetSession();
         AV17GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV18GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV35PageInfo = "";
         AV32DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV30AppName = "";
         AV36Phone = "";
         AV34Mail = "";
         AV38Website = "";
         AV27AddressLine1 = "";
         AV28AddressLine2 = "";
         AV29AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.abrangenciageograficawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006Y2_A38AbrangenciaGeograficaAtivo, P006Y2_A37AbrangenciaGeograficaNome, P006Y2_A36AbrangenciaGeograficaId
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
      private short AV23TFAbrangenciaGeograficaAtivo_Sel ;
      private short AV47Abrangenciageograficawwds_4_tfabrangenciageograficaativo_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A36AbrangenciaGeograficaId ;
      private int AV48GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV26TempBoolean ;
      private bool A38AbrangenciaGeograficaAtivo ;
      private bool AV12OrderedDsc ;
      private string AV37Title ;
      private string AV13FilterFullText ;
      private string AV22TFAbrangenciaGeograficaNome_Sel ;
      private string AV21TFAbrangenciaGeograficaNome ;
      private string AV25FilterTFAbrangenciaGeograficaAtivo_SelValueDescription ;
      private string AV44Abrangenciageograficawwds_1_filterfulltext ;
      private string AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome ;
      private string AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel ;
      private string lV44Abrangenciageograficawwds_1_filterfulltext ;
      private string lV45Abrangenciageograficawwds_2_tfabrangenciageograficanome ;
      private string A37AbrangenciaGeograficaNome ;
      private string AV14AbrangenciaGeograficaAtivoDescription ;
      private string AV35PageInfo ;
      private string AV32DateInfo ;
      private string AV30AppName ;
      private string AV36Phone ;
      private string AV34Mail ;
      private string AV38Website ;
      private string AV27AddressLine1 ;
      private string AV28AddressLine2 ;
      private string AV29AddressLine3 ;
      private IGxSession AV15Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P006Y2_A38AbrangenciaGeograficaAtivo ;
      private string[] P006Y2_A37AbrangenciaGeograficaNome ;
      private int[] P006Y2_A36AbrangenciaGeograficaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV17GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV18GridStateFilterValue ;
   }

   public class abrangenciageograficawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Y2( IGxContext context ,
                                             string AV44Abrangenciageograficawwds_1_filterfulltext ,
                                             string AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel ,
                                             string AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome ,
                                             short AV47Abrangenciageograficawwds_4_tfabrangenciageograficaativo_sel ,
                                             string A37AbrangenciaGeograficaNome ,
                                             bool A38AbrangenciaGeograficaAtivo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [AbrangenciaGeograficaAtivo], [AbrangenciaGeograficaNome], [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Abrangenciageograficawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [AbrangenciaGeograficaNome] like '%' + @lV44Abrangenciageograficawwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV44Abrangenciageograficawwds_1_filterfulltext) and [AbrangenciaGeograficaAtivo] = 1) or ( 'não' like '%' + LOWER(@lV44Abrangenciageograficawwds_1_filterfulltext) and [AbrangenciaGeograficaAtivo] = 0))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Abrangenciageograficawwds_2_tfabrangenciageograficanome)) ) )
         {
            AddWhere(sWhereString, "([AbrangenciaGeograficaNome] like @lV45Abrangenciageograficawwds_2_tfabrangenciageograficanome)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel)) && ! ( StringUtil.StrCmp(AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([AbrangenciaGeograficaNome] = @AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([AbrangenciaGeograficaNome] = ''))");
         }
         if ( AV47Abrangenciageograficawwds_4_tfabrangenciageograficaativo_sel == 1 )
         {
            AddWhere(sWhereString, "([AbrangenciaGeograficaAtivo] = 1)");
         }
         if ( AV47Abrangenciageograficawwds_4_tfabrangenciageograficaativo_sel == 2 )
         {
            AddWhere(sWhereString, "([AbrangenciaGeograficaAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [AbrangenciaGeograficaNome]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AbrangenciaGeograficaNome] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [AbrangenciaGeograficaAtivo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AbrangenciaGeograficaAtivo] DESC";
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
                     return conditional_P006Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP006Y2;
          prmP006Y2 = new Object[] {
          new ParDef("@lV44Abrangenciageograficawwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV44Abrangenciageograficawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Abrangenciageograficawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Abrangenciageograficawwds_2_tfabrangenciageograficanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV46Abrangenciageograficawwds_3_tfabrangenciageograficanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y2,100, GxCacheFrequency.OFF ,true,false )
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
