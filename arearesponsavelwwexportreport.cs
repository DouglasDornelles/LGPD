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
   public class arearesponsavelwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public arearesponsavelwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public arearesponsavelwwexportreport( IGxContext context )
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
         arearesponsavelwwexportreport objarearesponsavelwwexportreport;
         objarearesponsavelwwexportreport = new arearesponsavelwwexportreport();
         objarearesponsavelwwexportreport.context.SetSubmitInitialConfig(context);
         objarearesponsavelwwexportreport.initialize();
         Submit( executePrivateCatch,objarearesponsavelwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((arearesponsavelwwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "arearesponsavelww_Execute", out  GXt_boolean1) ;
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
               AV36Title = "Lista de Area Responsavel";
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
            H650( true, 0) ;
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
            H650( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFAreaResponsavelNome_Sel)) )
         {
            AV25TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFAreaResponsavelNome_Sel, "<#Empty#>")==0)));
            AV21TFAreaResponsavelNome_Sel = (AV25TempBoolean ? "(Vazio)" : AV21TFAreaResponsavelNome_Sel);
            H650( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFAreaResponsavelNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFAreaResponsavelNome_Sel = (AV25TempBoolean ? "<#Empty#>" : AV21TFAreaResponsavelNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFAreaResponsavelNome)) )
            {
               H650( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFAreaResponsavelNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV22TFAreaResponsavelAtivo_Sel) )
         {
            if ( AV22TFAreaResponsavelAtivo_Sel == 1 )
            {
               AV24FilterTFAreaResponsavelAtivo_SelValueDescription = "Marcado";
            }
            else if ( AV22TFAreaResponsavelAtivo_Sel == 2 )
            {
               AV24FilterTFAreaResponsavelAtivo_SelValueDescription = "Desmarcado";
            }
            H650( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ativo?", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24FilterTFAreaResponsavelAtivo_SelValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H650( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H650( false, 37) ;
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
         AV44Arearesponsavelwwds_1_filterfulltext = AV13FilterFullText;
         AV45Arearesponsavelwwds_2_tfarearesponsavelnome = AV20TFAreaResponsavelNome;
         AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel = AV21TFAreaResponsavelNome_Sel;
         AV47Arearesponsavelwwds_4_tfarearesponsavelativo_sel = AV22TFAreaResponsavelAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Arearesponsavelwwds_1_filterfulltext ,
                                              AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel ,
                                              AV45Arearesponsavelwwds_2_tfarearesponsavelnome ,
                                              AV47Arearesponsavelwwds_4_tfarearesponsavelativo_sel ,
                                              A25AreaResponsavelNome ,
                                              A26AreaResponsavelAtivo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV44Arearesponsavelwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Arearesponsavelwwds_1_filterfulltext), "%", "");
         lV44Arearesponsavelwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Arearesponsavelwwds_1_filterfulltext), "%", "");
         lV44Arearesponsavelwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Arearesponsavelwwds_1_filterfulltext), "%", "");
         lV45Arearesponsavelwwds_2_tfarearesponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV45Arearesponsavelwwds_2_tfarearesponsavelnome), "%", "");
         /* Using cursor P00652 */
         pr_default.execute(0, new Object[] {lV44Arearesponsavelwwds_1_filterfulltext, lV44Arearesponsavelwwds_1_filterfulltext, lV44Arearesponsavelwwds_1_filterfulltext, lV45Arearesponsavelwwds_2_tfarearesponsavelnome, AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A26AreaResponsavelAtivo = P00652_A26AreaResponsavelAtivo[0];
            A25AreaResponsavelNome = P00652_A25AreaResponsavelNome[0];
            A24AreaResponsavelId = P00652_A24AreaResponsavelId[0];
            AV38AreaResponsavelAtivoDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A26AreaResponsavelAtivo)), "true") == 0 )
            {
               AV38AreaResponsavelAtivoDescription = "SIM";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A26AreaResponsavelAtivo)), "false") == 0 )
            {
               AV38AreaResponsavelAtivoDescription = "N�O";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A26AreaResponsavelAtivo )
            {
               H650( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 223, 240, 216, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 166, 90, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A25AreaResponsavelNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AreaResponsavelAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else if ( ! A26AreaResponsavelAtivo )
            {
               H650( false, 36) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A25AreaResponsavelNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AreaResponsavelAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            else
            {
               H650( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A25AreaResponsavelNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AreaResponsavelAtivoDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("AreaResponsavelWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AreaResponsavelWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("AreaResponsavelWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFAREARESPONSAVELNOME") == 0 )
            {
               AV20TFAreaResponsavelNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFAREARESPONSAVELNOME_SEL") == 0 )
            {
               AV21TFAreaResponsavelNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFAREARESPONSAVELATIVO_SEL") == 0 )
            {
               AV22TFAreaResponsavelAtivo_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
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

      protected void H650( bool bFoot ,
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
                  AV34PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV31DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV29AppName = "DVelop Software Solutions";
               AV35Phone = "+1 550 8923";
               AV33Mail = "info@mail.com";
               AV37Website = "http://www.web.com";
               AV26AddressLine1 = "French Boulevard 2859";
               AV27AddressLine2 = "Downtown";
               AV28AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV36Title = "";
         AV13FilterFullText = "";
         AV21TFAreaResponsavelNome_Sel = "";
         AV20TFAreaResponsavelNome = "";
         AV24FilterTFAreaResponsavelAtivo_SelValueDescription = "";
         AV44Arearesponsavelwwds_1_filterfulltext = "";
         AV45Arearesponsavelwwds_2_tfarearesponsavelnome = "";
         AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel = "";
         scmdbuf = "";
         lV44Arearesponsavelwwds_1_filterfulltext = "";
         lV45Arearesponsavelwwds_2_tfarearesponsavelnome = "";
         A25AreaResponsavelNome = "";
         P00652_A26AreaResponsavelAtivo = new bool[] {false} ;
         P00652_A25AreaResponsavelNome = new string[] {""} ;
         P00652_A24AreaResponsavelId = new int[1] ;
         AV38AreaResponsavelAtivoDescription = "";
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34PageInfo = "";
         AV31DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV29AppName = "";
         AV35Phone = "";
         AV33Mail = "";
         AV37Website = "";
         AV26AddressLine1 = "";
         AV27AddressLine2 = "";
         AV28AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arearesponsavelwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00652_A26AreaResponsavelAtivo, P00652_A25AreaResponsavelNome, P00652_A24AreaResponsavelId
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
      private short AV22TFAreaResponsavelAtivo_Sel ;
      private short AV47Arearesponsavelwwds_4_tfarearesponsavelativo_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A24AreaResponsavelId ;
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
      private bool AV25TempBoolean ;
      private bool A26AreaResponsavelAtivo ;
      private bool AV12OrderedDsc ;
      private string AV36Title ;
      private string AV13FilterFullText ;
      private string AV21TFAreaResponsavelNome_Sel ;
      private string AV20TFAreaResponsavelNome ;
      private string AV24FilterTFAreaResponsavelAtivo_SelValueDescription ;
      private string AV44Arearesponsavelwwds_1_filterfulltext ;
      private string AV45Arearesponsavelwwds_2_tfarearesponsavelnome ;
      private string AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel ;
      private string lV44Arearesponsavelwwds_1_filterfulltext ;
      private string lV45Arearesponsavelwwds_2_tfarearesponsavelnome ;
      private string A25AreaResponsavelNome ;
      private string AV38AreaResponsavelAtivoDescription ;
      private string AV34PageInfo ;
      private string AV31DateInfo ;
      private string AV29AppName ;
      private string AV35Phone ;
      private string AV33Mail ;
      private string AV37Website ;
      private string AV26AddressLine1 ;
      private string AV27AddressLine2 ;
      private string AV28AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P00652_A26AreaResponsavelAtivo ;
      private string[] P00652_A25AreaResponsavelNome ;
      private int[] P00652_A24AreaResponsavelId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class arearesponsavelwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00652( IGxContext context ,
                                             string AV44Arearesponsavelwwds_1_filterfulltext ,
                                             string AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel ,
                                             string AV45Arearesponsavelwwds_2_tfarearesponsavelnome ,
                                             short AV47Arearesponsavelwwds_4_tfarearesponsavelativo_sel ,
                                             string A25AreaResponsavelNome ,
                                             bool A26AreaResponsavelAtivo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [AreaResponsavelAtivo], [AreaResponsavelNome], [AreaResponsavelId] FROM [AreaResponsavel]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Arearesponsavelwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [AreaResponsavelNome] like '%' + @lV44Arearesponsavelwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV44Arearesponsavelwwds_1_filterfulltext) and [AreaResponsavelAtivo] = 1) or ( 'n�o' like '%' + LOWER(@lV44Arearesponsavelwwds_1_filterfulltext) and [AreaResponsavelAtivo] = 0))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Arearesponsavelwwds_2_tfarearesponsavelnome)) ) )
         {
            AddWhere(sWhereString, "([AreaResponsavelNome] like @lV45Arearesponsavelwwds_2_tfarearesponsavelnome)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([AreaResponsavelNome] = @AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([AreaResponsavelNome] = ''))");
         }
         if ( AV47Arearesponsavelwwds_4_tfarearesponsavelativo_sel == 1 )
         {
            AddWhere(sWhereString, "([AreaResponsavelAtivo] = 1)");
         }
         if ( AV47Arearesponsavelwwds_4_tfarearesponsavelativo_sel == 2 )
         {
            AddWhere(sWhereString, "([AreaResponsavelAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreaResponsavelNome]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreaResponsavelNome] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreaResponsavelAtivo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreaResponsavelAtivo] DESC";
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
                     return conditional_P00652(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP00652;
          prmP00652 = new Object[] {
          new ParDef("@lV44Arearesponsavelwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV44Arearesponsavelwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Arearesponsavelwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Arearesponsavelwwds_2_tfarearesponsavelnome",GXType.NVarChar,100,0) ,
          new ParDef("@AV46Arearesponsavelwwds_3_tfarearesponsavelnome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00652", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00652,100, GxCacheFrequency.OFF ,true,false )
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
