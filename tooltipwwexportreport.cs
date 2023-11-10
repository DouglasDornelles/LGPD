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
   public class tooltipwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public tooltipwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tooltipwwexportreport( IGxContext context )
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
         tooltipwwexportreport objtooltipwwexportreport;
         objtooltipwwexportreport = new tooltipwwexportreport();
         objtooltipwwexportreport.context.SetSubmitInitialConfig(context);
         objtooltipwwexportreport.initialize();
         Submit( executePrivateCatch,objtooltipwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tooltipwwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tooltipww_Execute", out  GXt_boolean1) ;
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
               AV52Title = "Lista de Tooltip";
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
            H6V0( true, 0) ;
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
            H6V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFTooltipTelaNome_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV55TFTooltipTelaNome_Sel, "<#Empty#>")==0)));
            AV55TFTooltipTelaNome_Sel = (AV40TempBoolean ? "(Vazio)" : AV55TFTooltipTelaNome_Sel);
            H6V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TELA", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFTooltipTelaNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV55TFTooltipTelaNome_Sel = (AV40TempBoolean ? "<#Empty#>" : AV55TFTooltipTelaNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TFTooltipTelaNome)) )
            {
               H6V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("TELA", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFTooltipTelaNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCampoNome_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFCampoNome_Sel, "<#Empty#>")==0)));
            AV33TFCampoNome_Sel = (AV40TempBoolean ? "(Vazio)" : AV33TFCampoNome_Sel);
            H6V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("CAMPO", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFCampoNome_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFCampoNome_Sel = (AV40TempBoolean ? "<#Empty#>" : AV33TFCampoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCampoNome)) )
            {
               H6V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CAMPO", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFCampoNome, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFTooltipDescricao_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV28TFTooltipDescricao_Sel, "<#Empty#>")==0)));
            AV28TFTooltipDescricao_Sel = (AV40TempBoolean ? "(Vazio)" : AV28TFTooltipDescricao_Sel);
            H6V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("DESCRIÇÃO", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TFTooltipDescricao_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV28TFTooltipDescricao_Sel = (AV40TempBoolean ? "<#Empty#>" : AV28TFTooltipDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFTooltipDescricao)) )
            {
               H6V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DESCRIÇÃO", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TFTooltipDescricao, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV29TFTooltipAtivo_Sel) )
         {
            if ( AV29TFTooltipAtivo_Sel == 1 )
            {
               AV37FilterTFTooltipAtivo_SelValueDescription = "Marcado";
            }
            else if ( AV29TFTooltipAtivo_Sel == 2 )
            {
               AV37FilterTFTooltipAtivo_SelValueDescription = "Desmarcado";
            }
            H6V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ATIVO", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterTFTooltipAtivo_SelValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6V0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6V0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("TELA", 30, Gx_line+10, 216, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("CAMPO", 220, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("DESCRIÇÃO", 410, Gx_line+10, 596, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("ATIVO", 600, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV61Tooltipwwds_1_filterfulltext = AV13FilterFullText;
         AV62Tooltipwwds_2_tftooltiptelanome = AV54TFTooltipTelaNome;
         AV63Tooltipwwds_3_tftooltiptelanome_sel = AV55TFTooltipTelaNome_Sel;
         AV64Tooltipwwds_4_tfcamponome = AV32TFCampoNome;
         AV65Tooltipwwds_5_tfcamponome_sel = AV33TFCampoNome_Sel;
         AV66Tooltipwwds_6_tftooltipdescricao = AV27TFTooltipDescricao;
         AV67Tooltipwwds_7_tftooltipdescricao_sel = AV28TFTooltipDescricao_Sel;
         AV68Tooltipwwds_8_tftooltipativo_sel = AV29TFTooltipAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Tooltipwwds_1_filterfulltext ,
                                              AV63Tooltipwwds_3_tftooltiptelanome_sel ,
                                              AV62Tooltipwwds_2_tftooltiptelanome ,
                                              AV65Tooltipwwds_5_tfcamponome_sel ,
                                              AV64Tooltipwwds_4_tfcamponome ,
                                              AV67Tooltipwwds_7_tftooltipdescricao_sel ,
                                              AV66Tooltipwwds_6_tftooltipdescricao ,
                                              AV68Tooltipwwds_8_tftooltipativo_sel ,
                                              A140TooltipTelaNome ,
                                              A136CampoNome ,
                                              A115TooltipDescricao ,
                                              A118TooltipAtivo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tooltipwwds_1_filterfulltext), "%", "");
         lV61Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tooltipwwds_1_filterfulltext), "%", "");
         lV61Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tooltipwwds_1_filterfulltext), "%", "");
         lV61Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tooltipwwds_1_filterfulltext), "%", "");
         lV61Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tooltipwwds_1_filterfulltext), "%", "");
         lV62Tooltipwwds_2_tftooltiptelanome = StringUtil.Concat( StringUtil.RTrim( AV62Tooltipwwds_2_tftooltiptelanome), "%", "");
         lV64Tooltipwwds_4_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV64Tooltipwwds_4_tfcamponome), "%", "");
         lV66Tooltipwwds_6_tftooltipdescricao = StringUtil.Concat( StringUtil.RTrim( AV66Tooltipwwds_6_tftooltipdescricao), "%", "");
         /* Using cursor P006V2 */
         pr_default.execute(0, new Object[] {lV61Tooltipwwds_1_filterfulltext, lV61Tooltipwwds_1_filterfulltext, lV61Tooltipwwds_1_filterfulltext, lV61Tooltipwwds_1_filterfulltext, lV61Tooltipwwds_1_filterfulltext, lV62Tooltipwwds_2_tftooltiptelanome, AV63Tooltipwwds_3_tftooltiptelanome_sel, lV64Tooltipwwds_4_tfcamponome, AV65Tooltipwwds_5_tfcamponome_sel, lV66Tooltipwwds_6_tftooltipdescricao, AV67Tooltipwwds_7_tftooltipdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135CampoId = P006V2_A135CampoId[0];
            A139TooltipTelaId = P006V2_A139TooltipTelaId[0];
            A118TooltipAtivo = P006V2_A118TooltipAtivo[0];
            A115TooltipDescricao = P006V2_A115TooltipDescricao[0];
            A136CampoNome = P006V2_A136CampoNome[0];
            A140TooltipTelaNome = P006V2_A140TooltipTelaNome[0];
            A112TooltipId = P006V2_A112TooltipId[0];
            A136CampoNome = P006V2_A136CampoNome[0];
            A140TooltipTelaNome = P006V2_A140TooltipTelaNome[0];
            AV16TooltipAtivoDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A118TooltipAtivo)), "true") == 0 )
            {
               AV16TooltipAtivoDescription = "SIM";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A118TooltipAtivo)), "false") == 0 )
            {
               AV16TooltipAtivoDescription = "NÃO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A118TooltipAtivo )
            {
               H6V0( false, 66) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+65, 1, 0, 0, 0, 1, 223, 240, 216, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 166, 90, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A140TooltipTelaNome, "")), 30, Gx_line+10, 216, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136CampoNome, "")), 220, Gx_line+10, 406, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(A115TooltipDescricao, 410, Gx_line+10, 596, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TooltipAtivoDescription, "")), 600, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            else if ( ! A118TooltipAtivo )
            {
               H6V0( false, 66) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+65, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A140TooltipTelaNome, "")), 30, Gx_line+10, 216, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136CampoNome, "")), 220, Gx_line+10, 406, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(A115TooltipDescricao, 410, Gx_line+10, 596, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TooltipAtivoDescription, "")), 600, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            else
            {
               H6V0( false, 66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A140TooltipTelaNome, "")), 30, Gx_line+10, 216, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136CampoNome, "")), 220, Gx_line+10, 406, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(A115TooltipDescricao, 410, Gx_line+10, 596, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TooltipAtivoDescription, "")), 600, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
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
         if ( StringUtil.StrCmp(AV17Session.Get("TooltipWWGridState"), "") == 0 )
         {
            AV19GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TooltipWWGridState"), null, "", "");
         }
         else
         {
            AV19GridState.FromXml(AV17Session.Get("TooltipWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV19GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV19GridState.gxTpr_Ordereddsc;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV19GridState.gxTpr_Filtervalues.Count )
         {
            AV20GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV19GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFTOOLTIPTELANOME") == 0 )
            {
               AV54TFTooltipTelaNome = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFTOOLTIPTELANOME_SEL") == 0 )
            {
               AV55TFTooltipTelaNome_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFCAMPONOME") == 0 )
            {
               AV32TFCampoNome = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFCAMPONOME_SEL") == 0 )
            {
               AV33TFCampoNome_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFTOOLTIPDESCRICAO") == 0 )
            {
               AV27TFTooltipDescricao = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFTOOLTIPDESCRICAO_SEL") == 0 )
            {
               AV28TFTooltipDescricao_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFTOOLTIPATIVO_SEL") == 0 )
            {
               AV29TFTooltipAtivo_Sel = (short)(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Value, "."));
            }
            AV69GXV1 = (int)(AV69GXV1+1);
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

      protected void H6V0( bool bFoot ,
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
                  AV50PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV47DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV45AppName = "DVelop Software Solutions";
               AV51Phone = "+1 550 8923";
               AV49Mail = "info@mail.com";
               AV53Website = "http://www.web.com";
               AV42AddressLine1 = "French Boulevard 2859";
               AV43AddressLine2 = "Downtown";
               AV44AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Title, "")), 30, Gx_line+45, 791, Gx_line+78, 0, 0, 0, 0) ;
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
         AV52Title = "";
         AV13FilterFullText = "";
         AV55TFTooltipTelaNome_Sel = "";
         AV54TFTooltipTelaNome = "";
         AV33TFCampoNome_Sel = "";
         AV32TFCampoNome = "";
         AV28TFTooltipDescricao_Sel = "";
         AV27TFTooltipDescricao = "";
         AV37FilterTFTooltipAtivo_SelValueDescription = "";
         AV61Tooltipwwds_1_filterfulltext = "";
         AV62Tooltipwwds_2_tftooltiptelanome = "";
         AV63Tooltipwwds_3_tftooltiptelanome_sel = "";
         AV64Tooltipwwds_4_tfcamponome = "";
         AV65Tooltipwwds_5_tfcamponome_sel = "";
         AV66Tooltipwwds_6_tftooltipdescricao = "";
         AV67Tooltipwwds_7_tftooltipdescricao_sel = "";
         scmdbuf = "";
         lV61Tooltipwwds_1_filterfulltext = "";
         lV62Tooltipwwds_2_tftooltiptelanome = "";
         lV64Tooltipwwds_4_tfcamponome = "";
         lV66Tooltipwwds_6_tftooltipdescricao = "";
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         P006V2_A135CampoId = new int[1] ;
         P006V2_A139TooltipTelaId = new int[1] ;
         P006V2_A118TooltipAtivo = new bool[] {false} ;
         P006V2_A115TooltipDescricao = new string[] {""} ;
         P006V2_A136CampoNome = new string[] {""} ;
         P006V2_A140TooltipTelaNome = new string[] {""} ;
         P006V2_A112TooltipId = new int[1] ;
         AV16TooltipAtivoDescription = "";
         AV17Session = context.GetSession();
         AV19GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV20GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50PageInfo = "";
         AV47DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV45AppName = "";
         AV51Phone = "";
         AV49Mail = "";
         AV53Website = "";
         AV42AddressLine1 = "";
         AV43AddressLine2 = "";
         AV44AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tooltipwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006V2_A135CampoId, P006V2_A139TooltipTelaId, P006V2_A118TooltipAtivo, P006V2_A115TooltipDescricao, P006V2_A136CampoNome, P006V2_A140TooltipTelaNome, P006V2_A112TooltipId
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
      private short AV29TFTooltipAtivo_Sel ;
      private short AV68Tooltipwwds_8_tftooltipativo_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int A112TooltipId ;
      private int AV69GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV40TempBoolean ;
      private bool A118TooltipAtivo ;
      private bool AV12OrderedDsc ;
      private string A115TooltipDescricao ;
      private string AV52Title ;
      private string AV13FilterFullText ;
      private string AV55TFTooltipTelaNome_Sel ;
      private string AV54TFTooltipTelaNome ;
      private string AV33TFCampoNome_Sel ;
      private string AV32TFCampoNome ;
      private string AV28TFTooltipDescricao_Sel ;
      private string AV27TFTooltipDescricao ;
      private string AV37FilterTFTooltipAtivo_SelValueDescription ;
      private string AV61Tooltipwwds_1_filterfulltext ;
      private string AV62Tooltipwwds_2_tftooltiptelanome ;
      private string AV63Tooltipwwds_3_tftooltiptelanome_sel ;
      private string AV64Tooltipwwds_4_tfcamponome ;
      private string AV65Tooltipwwds_5_tfcamponome_sel ;
      private string AV66Tooltipwwds_6_tftooltipdescricao ;
      private string AV67Tooltipwwds_7_tftooltipdescricao_sel ;
      private string lV61Tooltipwwds_1_filterfulltext ;
      private string lV62Tooltipwwds_2_tftooltiptelanome ;
      private string lV64Tooltipwwds_4_tfcamponome ;
      private string lV66Tooltipwwds_6_tftooltipdescricao ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private string AV16TooltipAtivoDescription ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private IGxSession AV17Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006V2_A135CampoId ;
      private int[] P006V2_A139TooltipTelaId ;
      private bool[] P006V2_A118TooltipAtivo ;
      private string[] P006V2_A115TooltipDescricao ;
      private string[] P006V2_A136CampoNome ;
      private string[] P006V2_A140TooltipTelaNome ;
      private int[] P006V2_A112TooltipId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV19GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV20GridStateFilterValue ;
   }

   public class tooltipwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006V2( IGxContext context ,
                                             string AV61Tooltipwwds_1_filterfulltext ,
                                             string AV63Tooltipwwds_3_tftooltiptelanome_sel ,
                                             string AV62Tooltipwwds_2_tftooltiptelanome ,
                                             string AV65Tooltipwwds_5_tfcamponome_sel ,
                                             string AV64Tooltipwwds_4_tfcamponome ,
                                             string AV67Tooltipwwds_7_tftooltipdescricao_sel ,
                                             string AV66Tooltipwwds_6_tftooltipdescricao ,
                                             short AV68Tooltipwwds_8_tftooltipativo_sel ,
                                             string A140TooltipTelaNome ,
                                             string A136CampoNome ,
                                             string A115TooltipDescricao ,
                                             bool A118TooltipAtivo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T1.[TooltipAtivo], T1.[TooltipDescricao], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipId] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tooltipwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.[TelaNome] like '%' + @lV61Tooltipwwds_1_filterfulltext) or ( T2.[CampoNome] like '%' + @lV61Tooltipwwds_1_filterfulltext) or ( T1.[TooltipDescricao] like '%' + @lV61Tooltipwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV61Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 1) or ( 'não' like '%' + LOWER(@lV61Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 0))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Tooltipwwds_3_tftooltiptelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Tooltipwwds_2_tftooltiptelanome)) ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] like @lV62Tooltipwwds_2_tftooltiptelanome)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Tooltipwwds_3_tftooltiptelanome_sel)) && ! ( StringUtil.StrCmp(AV63Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] = @AV63Tooltipwwds_3_tftooltiptelanome_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV63Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[TelaNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Tooltipwwds_5_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tooltipwwds_4_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] like @lV64Tooltipwwds_4_tfcamponome)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Tooltipwwds_5_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV65Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] = @AV65Tooltipwwds_5_tfcamponome_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV65Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CampoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Tooltipwwds_7_tftooltipdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Tooltipwwds_6_tftooltipdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] like @lV66Tooltipwwds_6_tftooltipdescricao)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Tooltipwwds_7_tftooltipdescricao_sel)) && ! ( StringUtil.StrCmp(AV67Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] = @AV67Tooltipwwds_7_tftooltipdescricao_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[TooltipDescricao])=0))");
         }
         if ( AV68Tooltipwwds_8_tftooltipativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 1)");
         }
         if ( AV68Tooltipwwds_8_tftooltipativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TooltipAtivo]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TooltipAtivo] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[TelaNome]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[TelaNome] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[CampoNome]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[CampoNome] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TooltipDescricao]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TooltipDescricao] DESC";
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
                     return conditional_P006V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] );
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
          Object[] prmP006V2;
          prmP006V2 = new Object[] {
          new ParDef("@lV61Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Tooltipwwds_2_tftooltiptelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV63Tooltipwwds_3_tftooltiptelanome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV64Tooltipwwds_4_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV65Tooltipwwds_5_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV66Tooltipwwds_6_tftooltipdescricao",GXType.NVarChar,200,0) ,
          new ParDef("@AV67Tooltipwwds_7_tftooltipdescricao_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
