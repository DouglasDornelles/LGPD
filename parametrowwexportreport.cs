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
   public class parametrowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public parametrowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public parametrowwexportreport( IGxContext context )
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
         parametrowwexportreport objparametrowwexportreport;
         objparametrowwexportreport = new parametrowwexportreport();
         objparametrowwexportreport.context.SetSubmitInitialConfig(context);
         objparametrowwexportreport.initialize();
         Submit( executePrivateCatch,objparametrowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parametrowwexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametroww_Execute", out  GXt_boolean1) ;
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
               AV49Title = "Lista de Parametro";
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
            H6I0( true, 0) ;
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
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFParametroCod_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFParametroCod_Sel, "<#Empty#>")==0)));
            AV19TFParametroCod_Sel = (AV38TempBoolean ? "(Vazio)" : AV19TFParametroCod_Sel);
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Código", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFParametroCod_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFParametroCod_Sel = (AV38TempBoolean ? "<#Empty#>" : AV19TFParametroCod_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFParametroCod)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Código", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFParametroCod, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFParametroDescricao_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFParametroDescricao_Sel, "<#Empty#>")==0)));
            AV21TFParametroDescricao_Sel = (AV38TempBoolean ? "(Vazio)" : AV21TFParametroDescricao_Sel);
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFParametroDescricao_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFParametroDescricao_Sel = (AV38TempBoolean ? "<#Empty#>" : AV21TFParametroDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFParametroDescricao)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFParametroDescricao, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFParametroValor_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV23TFParametroValor_Sel, "<#Empty#>")==0)));
            AV23TFParametroValor_Sel = (AV38TempBoolean ? "(Vazio)" : AV23TFParametroValor_Sel);
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Valor", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFParametroValor_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV23TFParametroValor_Sel = (AV38TempBoolean ? "<#Empty#>" : AV23TFParametroValor_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFParametroValor)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Valor", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFParametroValor, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFParametroComentario_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV25TFParametroComentario_Sel, "<#Empty#>")==0)));
            AV25TFParametroComentario_Sel = (AV38TempBoolean ? "(Vazio)" : AV25TFParametroComentario_Sel);
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Comentário", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TFParametroComentario_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV25TFParametroComentario_Sel = (AV38TempBoolean ? "<#Empty#>" : AV25TFParametroComentario_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFParametroComentario)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Comentário", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFParametroComentario, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6I0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6I0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Código", 30, Gx_line+10, 136, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Valor", 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Comentário", 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV57Parametrowwds_1_filterfulltext = AV13FilterFullText;
         AV58Parametrowwds_2_tfparametrocod = AV18TFParametroCod;
         AV59Parametrowwds_3_tfparametrocod_sel = AV19TFParametroCod_Sel;
         AV60Parametrowwds_4_tfparametrodescricao = AV20TFParametroDescricao;
         AV61Parametrowwds_5_tfparametrodescricao_sel = AV21TFParametroDescricao_Sel;
         AV62Parametrowwds_6_tfparametrovalor = AV22TFParametroValor;
         AV63Parametrowwds_7_tfparametrovalor_sel = AV23TFParametroValor_Sel;
         AV64Parametrowwds_8_tfparametrocomentario = AV24TFParametroComentario;
         AV65Parametrowwds_9_tfparametrocomentario_sel = AV25TFParametroComentario_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Parametrowwds_1_filterfulltext ,
                                              AV59Parametrowwds_3_tfparametrocod_sel ,
                                              AV58Parametrowwds_2_tfparametrocod ,
                                              AV61Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV60Parametrowwds_4_tfparametrodescricao ,
                                              AV63Parametrowwds_7_tfparametrovalor_sel ,
                                              AV62Parametrowwds_6_tfparametrovalor ,
                                              AV65Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV64Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV58Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV58Parametrowwds_2_tfparametrocod), 10, "%");
         lV60Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV60Parametrowwds_4_tfparametrodescricao), "%", "");
         lV62Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Parametrowwds_6_tfparametrovalor), "%", "");
         lV64Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV64Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor P006I2 */
         pr_default.execute(0, new Object[] {lV57Parametrowwds_1_filterfulltext, lV57Parametrowwds_1_filterfulltext, lV57Parametrowwds_1_filterfulltext, lV57Parametrowwds_1_filterfulltext, lV58Parametrowwds_2_tfparametrocod, AV59Parametrowwds_3_tfparametrocod_sel, lV60Parametrowwds_4_tfparametrodescricao, AV61Parametrowwds_5_tfparametrodescricao_sel, lV62Parametrowwds_6_tfparametrovalor, AV63Parametrowwds_7_tfparametrovalor_sel, lV64Parametrowwds_8_tfparametrocomentario, AV65Parametrowwds_9_tfparametrocomentario_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127ParametroComentario = P006I2_A127ParametroComentario[0];
            A126ParametroValor = P006I2_A126ParametroValor[0];
            A125ParametroDescricao = P006I2_A125ParametroDescricao[0];
            A124ParametroCod = P006I2_A124ParametroCod[0];
            A132ParametroAtivo = P006I2_A132ParametroAtivo[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A132ParametroAtivo )
            {
               H6I0( false, 66) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+65, 1, 0, 0, 0, 1, 223, 240, 216, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 166, 90, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A124ParametroCod, "")), 30, Gx_line+10, 136, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A125ParametroDescricao, "")), 140, Gx_line+10, 352, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A126ParametroValor, "")), 356, Gx_line+10, 569, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A127ParametroComentario, "")), 573, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            else if ( ! A132ParametroAtivo )
            {
               H6I0( false, 66) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+65, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A124ParametroCod, "")), 30, Gx_line+10, 136, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A125ParametroDescricao, "")), 140, Gx_line+10, 352, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A126ParametroValor, "")), 356, Gx_line+10, 569, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A127ParametroComentario, "")), 573, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            else
            {
               H6I0( false, 66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A124ParametroCod, "")), 30, Gx_line+10, 136, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A125ParametroDescricao, "")), 140, Gx_line+10, 352, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A126ParametroValor, "")), 356, Gx_line+10, 569, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A127ParametroComentario, "")), 573, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("ParametroWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametroWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("ParametroWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD") == 0 )
            {
               AV18TFParametroCod = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD_SEL") == 0 )
            {
               AV19TFParametroCod_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV20TFParametroDescricao = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV21TFParametroDescricao_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV22TFParametroValor = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV23TFParametroValor_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO") == 0 )
            {
               AV24TFParametroComentario = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO_SEL") == 0 )
            {
               AV25TFParametroComentario_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV66GXV1 = (int)(AV66GXV1+1);
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

      protected void H6I0( bool bFoot ,
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
                  AV47PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV44DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV42AppName = "DVelop Software Solutions";
               AV48Phone = "+1 550 8923";
               AV46Mail = "info@mail.com";
               AV50Website = "http://www.web.com";
               AV39AddressLine1 = "French Boulevard 2859";
               AV40AddressLine2 = "Downtown";
               AV41AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 57, 103, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV49Title = "";
         AV13FilterFullText = "";
         AV19TFParametroCod_Sel = "";
         AV18TFParametroCod = "";
         AV21TFParametroDescricao_Sel = "";
         AV20TFParametroDescricao = "";
         AV23TFParametroValor_Sel = "";
         AV22TFParametroValor = "";
         AV25TFParametroComentario_Sel = "";
         AV24TFParametroComentario = "";
         AV57Parametrowwds_1_filterfulltext = "";
         AV58Parametrowwds_2_tfparametrocod = "";
         AV59Parametrowwds_3_tfparametrocod_sel = "";
         AV60Parametrowwds_4_tfparametrodescricao = "";
         AV61Parametrowwds_5_tfparametrodescricao_sel = "";
         AV62Parametrowwds_6_tfparametrovalor = "";
         AV63Parametrowwds_7_tfparametrovalor_sel = "";
         AV64Parametrowwds_8_tfparametrocomentario = "";
         AV65Parametrowwds_9_tfparametrocomentario_sel = "";
         scmdbuf = "";
         lV57Parametrowwds_1_filterfulltext = "";
         lV58Parametrowwds_2_tfparametrocod = "";
         lV60Parametrowwds_4_tfparametrodescricao = "";
         lV62Parametrowwds_6_tfparametrovalor = "";
         lV64Parametrowwds_8_tfparametrocomentario = "";
         A124ParametroCod = "";
         A125ParametroDescricao = "";
         A126ParametroValor = "";
         A127ParametroComentario = "";
         P006I2_A127ParametroComentario = new string[] {""} ;
         P006I2_A126ParametroValor = new string[] {""} ;
         P006I2_A125ParametroDescricao = new string[] {""} ;
         P006I2_A124ParametroCod = new string[] {""} ;
         P006I2_A132ParametroAtivo = new bool[] {false} ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47PageInfo = "";
         AV44DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV42AppName = "";
         AV48Phone = "";
         AV46Mail = "";
         AV50Website = "";
         AV39AddressLine1 = "";
         AV40AddressLine2 = "";
         AV41AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametrowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006I2_A127ParametroComentario, P006I2_A126ParametroValor, P006I2_A125ParametroDescricao, P006I2_A124ParametroCod, P006I2_A132ParametroAtivo
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
      private int AV66GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV19TFParametroCod_Sel ;
      private string AV18TFParametroCod ;
      private string AV58Parametrowwds_2_tfparametrocod ;
      private string AV59Parametrowwds_3_tfparametrocod_sel ;
      private string scmdbuf ;
      private string lV58Parametrowwds_2_tfparametrocod ;
      private string A124ParametroCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV38TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool A132ParametroAtivo ;
      private string AV49Title ;
      private string AV13FilterFullText ;
      private string AV21TFParametroDescricao_Sel ;
      private string AV20TFParametroDescricao ;
      private string AV23TFParametroValor_Sel ;
      private string AV22TFParametroValor ;
      private string AV25TFParametroComentario_Sel ;
      private string AV24TFParametroComentario ;
      private string AV57Parametrowwds_1_filterfulltext ;
      private string AV60Parametrowwds_4_tfparametrodescricao ;
      private string AV61Parametrowwds_5_tfparametrodescricao_sel ;
      private string AV62Parametrowwds_6_tfparametrovalor ;
      private string AV63Parametrowwds_7_tfparametrovalor_sel ;
      private string AV64Parametrowwds_8_tfparametrocomentario ;
      private string AV65Parametrowwds_9_tfparametrocomentario_sel ;
      private string lV57Parametrowwds_1_filterfulltext ;
      private string lV60Parametrowwds_4_tfparametrodescricao ;
      private string lV62Parametrowwds_6_tfparametrovalor ;
      private string lV64Parametrowwds_8_tfparametrocomentario ;
      private string A125ParametroDescricao ;
      private string A126ParametroValor ;
      private string A127ParametroComentario ;
      private string AV47PageInfo ;
      private string AV44DateInfo ;
      private string AV42AppName ;
      private string AV48Phone ;
      private string AV46Mail ;
      private string AV50Website ;
      private string AV39AddressLine1 ;
      private string AV40AddressLine2 ;
      private string AV41AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006I2_A127ParametroComentario ;
      private string[] P006I2_A126ParametroValor ;
      private string[] P006I2_A125ParametroDescricao ;
      private string[] P006I2_A124ParametroCod ;
      private bool[] P006I2_A132ParametroAtivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class parametrowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006I2( IGxContext context ,
                                             string AV57Parametrowwds_1_filterfulltext ,
                                             string AV59Parametrowwds_3_tfparametrocod_sel ,
                                             string AV58Parametrowwds_2_tfparametrocod ,
                                             string AV61Parametrowwds_5_tfparametrodescricao_sel ,
                                             string AV60Parametrowwds_4_tfparametrodescricao ,
                                             string AV63Parametrowwds_7_tfparametrovalor_sel ,
                                             string AV62Parametrowwds_6_tfparametrovalor ,
                                             string AV65Parametrowwds_9_tfparametrocomentario_sel ,
                                             string AV64Parametrowwds_8_tfparametrocomentario ,
                                             string A124ParametroCod ,
                                             string A125ParametroDescricao ,
                                             string A126ParametroValor ,
                                             string A127ParametroComentario ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ParametroComentario], [ParametroValor], [ParametroDescricao], [ParametroCod], [ParametroAtivo] FROM [Parametro]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV57Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV57Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV57Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV57Parametrowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Parametrowwds_2_tfparametrocod)) ) )
         {
            AddWhere(sWhereString, "([ParametroCod] like @lV58Parametrowwds_2_tfparametrocod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV59Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroCod] = @AV59Parametrowwds_3_tfparametrocod_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroCod] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Parametrowwds_4_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] like @lV60Parametrowwds_4_tfparametrodescricao)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV61Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] = @AV61Parametrowwds_5_tfparametrodescricao_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Parametrowwds_6_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "([ParametroValor] like @lV62Parametrowwds_6_tfparametrovalor)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV63Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroValor] = @AV63Parametrowwds_7_tfparametrovalor_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroValor] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Parametrowwds_8_tfparametrocomentario)) ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] like @lV64Parametrowwds_8_tfparametrocomentario)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV65Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] = @AV65Parametrowwds_9_tfparametrocomentario_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroComentario] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroDescricao]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroDescricao] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroCod]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroCod] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroValor]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroValor] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroComentario]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroComentario] DESC";
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
                     return conditional_P006I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP006I2;
          prmP006I2 = new Object[] {
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
          new ParDef("@AV59Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV60Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
          new ParDef("@AV63Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV64Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
          new ParDef("@AV65Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
       }
    }

 }

}
