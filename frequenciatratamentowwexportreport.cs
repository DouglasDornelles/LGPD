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
   public class frequenciatratamentowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public frequenciatratamentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public frequenciatratamentowwexportreport( IGxContext context )
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
         frequenciatratamentowwexportreport objfrequenciatratamentowwexportreport;
         objfrequenciatratamentowwexportreport = new frequenciatratamentowwexportreport();
         objfrequenciatratamentowwexportreport.context.SetSubmitInitialConfig(context);
         objfrequenciatratamentowwexportreport.initialize();
         Submit( executePrivateCatch,objfrequenciatratamentowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((frequenciatratamentowwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "frequenciatratamentoww_Execute", out  GXt_boolean1) ;
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
               AV33Title = "Lista de Frequencia Tratamento";
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
            H3Y0( true, 0) ;
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
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFFrequenciaTratamentoNome_Sel)) )
         {
            AV22TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFFrequenciaTratamentoNome_Sel, "<#Empty#>")==0)));
            AV19TFFrequenciaTratamentoNome_Sel = (AV22TempBoolean ? "(Vazio)" : AV19TFFrequenciaTratamentoNome_Sel);
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFFrequenciaTratamentoNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFFrequenciaTratamentoNome_Sel = (AV22TempBoolean ? "<#Empty#>" : AV19TFFrequenciaTratamentoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFFrequenciaTratamentoNome)) )
            {
               H3Y0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFFrequenciaTratamentoNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV20TFFrequenciaTratamentoAtivo_Sel) )
         {
            if ( AV20TFFrequenciaTratamentoAtivo_Sel == 1 )
            {
               AV21FilterTFFrequenciaTratamentoAtivo_SelValueDescription = "Marcado";
            }
            else if ( AV20TFFrequenciaTratamentoAtivo_Sel == 2 )
            {
               AV21FilterTFFrequenciaTratamentoAtivo_SelValueDescription = "Desmarcado";
            }
            H3Y0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ativo?", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterTFFrequenciaTratamentoAtivo_SelValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3Y0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3Y0( false, 37) ;
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
         AV41Frequenciatratamentowwds_1_filterfulltext = AV13FilterFullText;
         AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome = AV18TFFrequenciaTratamentoNome;
         AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel = AV19TFFrequenciaTratamentoNome_Sel;
         AV44Frequenciatratamentowwds_4_tffrequenciatratamentoativo_sel = AV20TFFrequenciaTratamentoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Frequenciatratamentowwds_1_filterfulltext ,
                                              AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel ,
                                              AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome ,
                                              AV44Frequenciatratamentowwds_4_tffrequenciatratamentoativo_sel ,
                                              A40FrequenciaTratamentoNome ,
                                              A41FrequenciaTratamentoAtivo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Frequenciatratamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Frequenciatratamentowwds_1_filterfulltext), "%", "");
         lV41Frequenciatratamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Frequenciatratamentowwds_1_filterfulltext), "%", "");
         lV41Frequenciatratamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Frequenciatratamentowwds_1_filterfulltext), "%", "");
         lV42Frequenciatratamentowwds_2_tffrequenciatratamentonome = StringUtil.Concat( StringUtil.RTrim( AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome), "%", "");
         /* Using cursor P003Y2 */
         pr_default.execute(0, new Object[] {lV41Frequenciatratamentowwds_1_filterfulltext, lV41Frequenciatratamentowwds_1_filterfulltext, lV41Frequenciatratamentowwds_1_filterfulltext, lV42Frequenciatratamentowwds_2_tffrequenciatratamentonome, AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41FrequenciaTratamentoAtivo = P003Y2_A41FrequenciaTratamentoAtivo[0];
            A40FrequenciaTratamentoNome = P003Y2_A40FrequenciaTratamentoNome[0];
            A39FrequenciaTratamentoId = P003Y2_A39FrequenciaTratamentoId[0];
            AV35FrequenciaTratamentoAtivoDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A41FrequenciaTratamentoAtivo)), "true") == 0 )
            {
               AV35FrequenciaTratamentoAtivoDescription = "SIM";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A41FrequenciaTratamentoAtivo)), "false") == 0 )
            {
               AV35FrequenciaTratamentoAtivoDescription = "N�O";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A41FrequenciaTratamentoAtivo )
            {
               H3Y0( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 223, 240, 216, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 166, 90, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A40FrequenciaTratamentoNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35FrequenciaTratamentoAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else if ( ! A41FrequenciaTratamentoAtivo )
            {
               H3Y0( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A40FrequenciaTratamentoNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35FrequenciaTratamentoAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else
            {
               H3Y0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A40FrequenciaTratamentoNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35FrequenciaTratamentoAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("FrequenciaTratamentoWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "FrequenciaTratamentoWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("FrequenciaTratamentoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFFREQUENCIATRATAMENTONOME") == 0 )
            {
               AV18TFFrequenciaTratamentoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFFREQUENCIATRATAMENTONOME_SEL") == 0 )
            {
               AV19TFFrequenciaTratamentoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFFREQUENCIATRATAMENTOATIVO_SEL") == 0 )
            {
               AV20TFFrequenciaTratamentoAtivo_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            AV45GXV1 = (int)(AV45GXV1+1);
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

      protected void H3Y0( bool bFoot ,
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
                  AV31PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV28DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV26AppName = "DVelop Software Solutions";
               AV32Phone = "+1 550 8923";
               AV30Mail = "info@mail.com";
               AV34Website = "http://www.web.com";
               AV23AddressLine1 = "French Boulevard 2859";
               AV24AddressLine2 = "Downtown";
               AV25AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV33Title = "";
         AV13FilterFullText = "";
         AV19TFFrequenciaTratamentoNome_Sel = "";
         AV18TFFrequenciaTratamentoNome = "";
         AV21FilterTFFrequenciaTratamentoAtivo_SelValueDescription = "";
         AV41Frequenciatratamentowwds_1_filterfulltext = "";
         AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome = "";
         AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel = "";
         scmdbuf = "";
         lV41Frequenciatratamentowwds_1_filterfulltext = "";
         lV42Frequenciatratamentowwds_2_tffrequenciatratamentonome = "";
         A40FrequenciaTratamentoNome = "";
         P003Y2_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         P003Y2_A40FrequenciaTratamentoNome = new string[] {""} ;
         P003Y2_A39FrequenciaTratamentoId = new int[1] ;
         AV35FrequenciaTratamentoAtivoDescription = "";
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV31PageInfo = "";
         AV28DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV26AppName = "";
         AV32Phone = "";
         AV30Mail = "";
         AV34Website = "";
         AV23AddressLine1 = "";
         AV24AddressLine2 = "";
         AV25AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frequenciatratamentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003Y2_A41FrequenciaTratamentoAtivo, P003Y2_A40FrequenciaTratamentoNome, P003Y2_A39FrequenciaTratamentoId
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
      private short AV20TFFrequenciaTratamentoAtivo_Sel ;
      private short AV44Frequenciatratamentowwds_4_tffrequenciatratamentoativo_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A39FrequenciaTratamentoId ;
      private int AV45GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22TempBoolean ;
      private bool A41FrequenciaTratamentoAtivo ;
      private bool AV12OrderedDsc ;
      private string AV33Title ;
      private string AV13FilterFullText ;
      private string AV19TFFrequenciaTratamentoNome_Sel ;
      private string AV18TFFrequenciaTratamentoNome ;
      private string AV21FilterTFFrequenciaTratamentoAtivo_SelValueDescription ;
      private string AV41Frequenciatratamentowwds_1_filterfulltext ;
      private string AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome ;
      private string AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel ;
      private string lV41Frequenciatratamentowwds_1_filterfulltext ;
      private string lV42Frequenciatratamentowwds_2_tffrequenciatratamentonome ;
      private string A40FrequenciaTratamentoNome ;
      private string AV35FrequenciaTratamentoAtivoDescription ;
      private string AV31PageInfo ;
      private string AV28DateInfo ;
      private string AV26AppName ;
      private string AV32Phone ;
      private string AV30Mail ;
      private string AV34Website ;
      private string AV23AddressLine1 ;
      private string AV24AddressLine2 ;
      private string AV25AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P003Y2_A41FrequenciaTratamentoAtivo ;
      private string[] P003Y2_A40FrequenciaTratamentoNome ;
      private int[] P003Y2_A39FrequenciaTratamentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class frequenciatratamentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Y2( IGxContext context ,
                                             string AV41Frequenciatratamentowwds_1_filterfulltext ,
                                             string AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel ,
                                             string AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome ,
                                             short AV44Frequenciatratamentowwds_4_tffrequenciatratamentoativo_sel ,
                                             string A40FrequenciaTratamentoNome ,
                                             bool A41FrequenciaTratamentoAtivo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [FrequenciaTratamentoAtivo], [FrequenciaTratamentoNome], [FrequenciaTratamentoId] FROM [FrequenciaTratamento]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Frequenciatratamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [FrequenciaTratamentoNome] like '%' + @lV41Frequenciatratamentowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV41Frequenciatratamentowwds_1_filterfulltext) and [FrequenciaTratamentoAtivo] = 1) or ( 'n�o' like '%' + LOWER(@lV41Frequenciatratamentowwds_1_filterfulltext) and [FrequenciaTratamentoAtivo] = 0))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Frequenciatratamentowwds_2_tffrequenciatratamentonome)) ) )
         {
            AddWhere(sWhereString, "([FrequenciaTratamentoNome] like @lV42Frequenciatratamentowwds_2_tffrequenciatratamentonome)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel)) && ! ( StringUtil.StrCmp(AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([FrequenciaTratamentoNome] = @AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([FrequenciaTratamentoNome] = ''))");
         }
         if ( AV44Frequenciatratamentowwds_4_tffrequenciatratamentoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([FrequenciaTratamentoAtivo] = 1)");
         }
         if ( AV44Frequenciatratamentowwds_4_tffrequenciatratamentoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([FrequenciaTratamentoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [FrequenciaTratamentoNome]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FrequenciaTratamentoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [FrequenciaTratamentoAtivo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FrequenciaTratamentoAtivo] DESC";
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
                     return conditional_P003Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP003Y2;
          prmP003Y2 = new Object[] {
          new ParDef("@lV41Frequenciatratamentowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV41Frequenciatratamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV41Frequenciatratamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV42Frequenciatratamentowwds_2_tffrequenciatratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV43Frequenciatratamentowwds_3_tffrequenciatratamentonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y2,100, GxCacheFrequency.OFF ,true,false )
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
