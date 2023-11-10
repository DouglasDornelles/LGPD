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
   public class campowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public campowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public campowwexportreport( IGxContext context )
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
         campowwexportreport objcampowwexportreport;
         objcampowwexportreport = new campowwexportreport();
         objcampowwexportreport.context.SetSubmitInitialConfig(context);
         objcampowwexportreport.initialize();
         Submit( executePrivateCatch,objcampowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((campowwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "campoww_Execute", out  GXt_boolean1) ;
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
               AV37Title = "Lista de Campo";
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
            H6T0( true, 0) ;
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
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFCampoNome_Sel)) )
         {
            AV26TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFCampoNome_Sel, "<#Empty#>")==0)));
            AV21TFCampoNome_Sel = (AV26TempBoolean ? "(Vazio)" : AV21TFCampoNome_Sel);
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFCampoNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFCampoNome_Sel = (AV26TempBoolean ? "<#Empty#>" : AV21TFCampoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFCampoNome)) )
            {
               H6T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFCampoNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV40TFCampoAtivo_Sel) )
         {
            if ( AV40TFCampoAtivo_Sel == 1 )
            {
               AV41FilterTFCampoAtivo_SelValueDescription = "Marcado";
            }
            else if ( AV40TFCampoAtivo_Sel == 2 )
            {
               AV41FilterTFCampoAtivo_SelValueDescription = "Desmarcado";
            }
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ativo", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41FilterTFCampoAtivo_SelValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTelaNome_Sel)) )
         {
            AV26TempBoolean = (bool)(((StringUtil.StrCmp(AV43TFTelaNome_Sel, "<#Empty#>")==0)));
            AV43TFTelaNome_Sel = (AV26TempBoolean ? "(Vazio)" : AV43TFTelaNome_Sel);
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tela", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFTelaNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFTelaNome_Sel = (AV26TempBoolean ? "<#Empty#>" : AV43TFTelaNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTelaNome)) )
            {
               H6T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tela", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFTelaNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6T0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6T0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 279, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ativo", 283, Gx_line+10, 533, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tela", 537, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV49Campowwds_1_filterfulltext = AV13FilterFullText;
         AV50Campowwds_2_tfcamponome = AV20TFCampoNome;
         AV51Campowwds_3_tfcamponome_sel = AV21TFCampoNome_Sel;
         AV52Campowwds_4_tfcampoativo_sel = AV40TFCampoAtivo_Sel;
         AV53Campowwds_5_tftelanome = AV42TFTelaNome;
         AV54Campowwds_6_tftelanome_sel = AV43TFTelaNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Campowwds_1_filterfulltext ,
                                              AV51Campowwds_3_tfcamponome_sel ,
                                              AV50Campowwds_2_tfcamponome ,
                                              AV52Campowwds_4_tfcampoativo_sel ,
                                              AV54Campowwds_6_tftelanome_sel ,
                                              AV53Campowwds_5_tftelanome ,
                                              A136CampoNome ,
                                              A138CampoAtivo ,
                                              A134TelaNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV49Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Campowwds_1_filterfulltext), "%", "");
         lV49Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Campowwds_1_filterfulltext), "%", "");
         lV49Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Campowwds_1_filterfulltext), "%", "");
         lV49Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Campowwds_1_filterfulltext), "%", "");
         lV50Campowwds_2_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV50Campowwds_2_tfcamponome), "%", "");
         lV53Campowwds_5_tftelanome = StringUtil.Concat( StringUtil.RTrim( AV53Campowwds_5_tftelanome), "%", "");
         /* Using cursor P006T2 */
         pr_default.execute(0, new Object[] {lV49Campowwds_1_filterfulltext, lV49Campowwds_1_filterfulltext, lV49Campowwds_1_filterfulltext, lV49Campowwds_1_filterfulltext, lV50Campowwds_2_tfcamponome, AV51Campowwds_3_tfcamponome_sel, lV53Campowwds_5_tftelanome, AV54Campowwds_6_tftelanome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133TelaId = P006T2_A133TelaId[0];
            A134TelaNome = P006T2_A134TelaNome[0];
            A138CampoAtivo = P006T2_A138CampoAtivo[0];
            A136CampoNome = P006T2_A136CampoNome[0];
            A135CampoId = P006T2_A135CampoId[0];
            A134TelaNome = P006T2_A134TelaNome[0];
            AV39CampoAtivoDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A138CampoAtivo)), "true") == 0 )
            {
               AV39CampoAtivoDescription = "SIM";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A138CampoAtivo)), "false") == 0 )
            {
               AV39CampoAtivoDescription = "NÃO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6T0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136CampoNome, "")), 30, Gx_line+10, 279, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39CampoAtivoDescription, "")), 283, Gx_line+10, 533, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A134TelaNome, "")), 537, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("CampoWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CampoWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("CampoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFCAMPONOME") == 0 )
            {
               AV20TFCampoNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFCAMPONOME_SEL") == 0 )
            {
               AV21TFCampoNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFCAMPOATIVO_SEL") == 0 )
            {
               AV40TFCampoAtivo_Sel = (short)(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFTELANOME") == 0 )
            {
               AV42TFTelaNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFTELANOME_SEL") == 0 )
            {
               AV43TFTelaNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV55GXV1 = (int)(AV55GXV1+1);
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

      protected void H6T0( bool bFoot ,
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
         AV21TFCampoNome_Sel = "";
         AV20TFCampoNome = "";
         AV41FilterTFCampoAtivo_SelValueDescription = "";
         AV43TFTelaNome_Sel = "";
         AV42TFTelaNome = "";
         AV49Campowwds_1_filterfulltext = "";
         AV50Campowwds_2_tfcamponome = "";
         AV51Campowwds_3_tfcamponome_sel = "";
         AV53Campowwds_5_tftelanome = "";
         AV54Campowwds_6_tftelanome_sel = "";
         scmdbuf = "";
         lV49Campowwds_1_filterfulltext = "";
         lV50Campowwds_2_tfcamponome = "";
         lV53Campowwds_5_tftelanome = "";
         A136CampoNome = "";
         A134TelaNome = "";
         P006T2_A133TelaId = new int[1] ;
         P006T2_A134TelaNome = new string[] {""} ;
         P006T2_A138CampoAtivo = new bool[] {false} ;
         P006T2_A136CampoNome = new string[] {""} ;
         P006T2_A135CampoId = new int[1] ;
         AV39CampoAtivoDescription = "";
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.campowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006T2_A133TelaId, P006T2_A134TelaNome, P006T2_A138CampoAtivo, P006T2_A136CampoNome, P006T2_A135CampoId
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
      private short AV40TFCampoAtivo_Sel ;
      private short AV52Campowwds_4_tfcampoativo_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A133TelaId ;
      private int A135CampoId ;
      private int AV55GXV1 ;
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
      private bool A138CampoAtivo ;
      private bool AV12OrderedDsc ;
      private string AV37Title ;
      private string AV13FilterFullText ;
      private string AV21TFCampoNome_Sel ;
      private string AV20TFCampoNome ;
      private string AV41FilterTFCampoAtivo_SelValueDescription ;
      private string AV43TFTelaNome_Sel ;
      private string AV42TFTelaNome ;
      private string AV49Campowwds_1_filterfulltext ;
      private string AV50Campowwds_2_tfcamponome ;
      private string AV51Campowwds_3_tfcamponome_sel ;
      private string AV53Campowwds_5_tftelanome ;
      private string AV54Campowwds_6_tftelanome_sel ;
      private string lV49Campowwds_1_filterfulltext ;
      private string lV50Campowwds_2_tfcamponome ;
      private string lV53Campowwds_5_tftelanome ;
      private string A136CampoNome ;
      private string A134TelaNome ;
      private string AV39CampoAtivoDescription ;
      private string AV35PageInfo ;
      private string AV32DateInfo ;
      private string AV30AppName ;
      private string AV36Phone ;
      private string AV34Mail ;
      private string AV38Website ;
      private string AV27AddressLine1 ;
      private string AV28AddressLine2 ;
      private string AV29AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006T2_A133TelaId ;
      private string[] P006T2_A134TelaNome ;
      private bool[] P006T2_A138CampoAtivo ;
      private string[] P006T2_A136CampoNome ;
      private int[] P006T2_A135CampoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class campowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006T2( IGxContext context ,
                                             string AV49Campowwds_1_filterfulltext ,
                                             string AV51Campowwds_3_tfcamponome_sel ,
                                             string AV50Campowwds_2_tfcamponome ,
                                             short AV52Campowwds_4_tfcampoativo_sel ,
                                             string AV54Campowwds_6_tftelanome_sel ,
                                             string AV53Campowwds_5_tftelanome ,
                                             string A136CampoNome ,
                                             bool A138CampoAtivo ,
                                             string A134TelaNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TelaId], T2.[TelaNome], T1.[CampoAtivo], T1.[CampoNome], T1.[CampoId] FROM ([Campo] T1 INNER JOIN [Tela] T2 ON T2.[TelaId] = T1.[TelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Campowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.[CampoNome] like '%' + @lV49Campowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV49Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV49Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 0) or ( T2.[TelaNome] like '%' + @lV49Campowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Campowwds_3_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Campowwds_2_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] like @lV50Campowwds_2_tfcamponome)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Campowwds_3_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV51Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] = @AV51Campowwds_3_tfcamponome_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV51Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CampoNome] = ''))");
         }
         if ( AV52Campowwds_4_tfcampoativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 1)");
         }
         if ( AV52Campowwds_4_tfcampoativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Campowwds_6_tftelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Campowwds_5_tftelanome)) ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] like @lV53Campowwds_5_tftelanome)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Campowwds_6_tftelanome_sel)) && ! ( StringUtil.StrCmp(AV54Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] = @AV54Campowwds_6_tftelanome_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV54Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TelaNome] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CampoNome]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CampoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CampoAtivo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CampoAtivo] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TelaNome]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TelaNome] DESC";
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
                     return conditional_P006T2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] );
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
          Object[] prmP006T2;
          prmP006T2 = new Object[] {
          new ParDef("@lV49Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV49Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Campowwds_2_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV51Campowwds_3_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Campowwds_5_tftelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Campowwds_6_tftelanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
