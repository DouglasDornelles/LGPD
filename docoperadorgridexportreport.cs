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
   public class docoperadorgridexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public docoperadorgridexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docoperadorgridexportreport( IGxContext context )
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
         docoperadorgridexportreport objdocoperadorgridexportreport;
         objdocoperadorgridexportreport = new docoperadorgridexportreport();
         objdocoperadorgridexportreport.context.SetSubmitInitialConfig(context);
         objdocoperadorgridexportreport.initialize();
         Submit( executePrivateCatch,objdocoperadorgridexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docoperadorgridexportreport)stateInfo).executePrivate();
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
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV37Title = "Lista de Doc Operador";
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
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H5G0( true, 0) ;
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
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV18TFDocOperadorId) && (0==AV19TFDocOperadorId_To) ) )
         {
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Operador Id", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18TFDocOperadorId), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV24TFDocOperadorId_To_Description = StringUtil.Format( "%1 (%2)", "Operador Id", "Até", "", "", "", "", "", "", "");
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFDocOperadorId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19TFDocOperadorId_To), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV20TFDocumentoId) && (0==AV21TFDocumentoId_To) ) )
         {
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("do Documento", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20TFDocumentoId), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV25TFDocumentoId_To_Description = StringUtil.Format( "%1 (%2)", "do Documento", "Até", "", "", "", "", "", "", "");
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TFDocumentoId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21TFDocumentoId_To), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV22TFOperadorId) && (0==AV23TFOperadorId_To) ) )
         {
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("do Operador", 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22TFOperadorId), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV26TFOperadorId_To_Description = StringUtil.Format( "%1 (%2)", "do Operador", "Até", "", "", "", "", "", "", "");
            H5G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TFOperadorId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23TFOperadorId_To), "ZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5G0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 57, 103, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5G0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 57, 103, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Operador Id", 30, Gx_line+10, 279, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("do Documento", 283, Gx_line+10, 533, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("do Operador", 537, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV44Docoperadorgridds_1_filterfulltext = AV13FilterFullText;
         AV45Docoperadorgridds_2_tfdocoperadorid = AV18TFDocOperadorId;
         AV46Docoperadorgridds_3_tfdocoperadorid_to = AV19TFDocOperadorId_To;
         AV47Docoperadorgridds_4_tfdocumentoid = AV20TFDocumentoId;
         AV48Docoperadorgridds_5_tfdocumentoid_to = AV21TFDocumentoId_To;
         AV49Docoperadorgridds_6_tfoperadorid = AV22TFOperadorId;
         AV50Docoperadorgridds_7_tfoperadorid_to = AV23TFOperadorId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Docoperadorgridds_1_filterfulltext ,
                                              AV45Docoperadorgridds_2_tfdocoperadorid ,
                                              AV46Docoperadorgridds_3_tfdocoperadorid_to ,
                                              AV47Docoperadorgridds_4_tfdocumentoid ,
                                              AV48Docoperadorgridds_5_tfdocumentoid_to ,
                                              AV49Docoperadorgridds_6_tfoperadorid ,
                                              AV50Docoperadorgridds_7_tfoperadorid_to ,
                                              A86DocOperadorId ,
                                              A75DocumentoId ,
                                              A42OperadorId ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV44Docoperadorgridds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Docoperadorgridds_1_filterfulltext), "%", "");
         lV44Docoperadorgridds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Docoperadorgridds_1_filterfulltext), "%", "");
         lV44Docoperadorgridds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Docoperadorgridds_1_filterfulltext), "%", "");
         /* Using cursor P005G2 */
         pr_default.execute(0, new Object[] {lV44Docoperadorgridds_1_filterfulltext, lV44Docoperadorgridds_1_filterfulltext, lV44Docoperadorgridds_1_filterfulltext, AV45Docoperadorgridds_2_tfdocoperadorid, AV46Docoperadorgridds_3_tfdocoperadorid_to, AV47Docoperadorgridds_4_tfdocumentoid, AV48Docoperadorgridds_5_tfdocumentoid_to, AV49Docoperadorgridds_6_tfoperadorid, AV50Docoperadorgridds_7_tfoperadorid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A42OperadorId = P005G2_A42OperadorId[0];
            A75DocumentoId = P005G2_A75DocumentoId[0];
            A86DocOperadorId = P005G2_A86DocOperadorId[0];
            A87DocOperadorColeta = P005G2_A87DocOperadorColeta[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5G0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9")), 30, Gx_line+10, 279, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), 283, Gx_line+10, 533, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A42OperadorId), "ZZZZZZZ9")), 537, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("DocOperadorGridGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocOperadorGridGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("DocOperadorGridGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV51GXV1));
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
            AV51GXV1 = (int)(AV51GXV1+1);
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

      protected void H5G0( bool bFoot ,
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
         AV24TFDocOperadorId_To_Description = "";
         AV25TFDocumentoId_To_Description = "";
         AV26TFOperadorId_To_Description = "";
         AV44Docoperadorgridds_1_filterfulltext = "";
         scmdbuf = "";
         lV44Docoperadorgridds_1_filterfulltext = "";
         P005G2_A42OperadorId = new int[1] ;
         P005G2_A75DocumentoId = new int[1] ;
         P005G2_A86DocOperadorId = new int[1] ;
         P005G2_A87DocOperadorColeta = new bool[] {false} ;
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperadorgridexportreport__default(),
            new Object[][] {
                new Object[] {
               P005G2_A42OperadorId, P005G2_A75DocumentoId, P005G2_A86DocOperadorId, P005G2_A87DocOperadorColeta
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
      private int AV18TFDocOperadorId ;
      private int AV19TFDocOperadorId_To ;
      private int AV20TFDocumentoId ;
      private int AV21TFDocumentoId_To ;
      private int AV22TFOperadorId ;
      private int AV23TFOperadorId_To ;
      private int AV45Docoperadorgridds_2_tfdocoperadorid ;
      private int AV46Docoperadorgridds_3_tfdocoperadorid_to ;
      private int AV47Docoperadorgridds_4_tfdocumentoid ;
      private int AV48Docoperadorgridds_5_tfdocumentoid_to ;
      private int AV49Docoperadorgridds_6_tfoperadorid ;
      private int AV50Docoperadorgridds_7_tfoperadorid_to ;
      private int A86DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int AV51GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV12OrderedDsc ;
      private bool A87DocOperadorColeta ;
      private string AV37Title ;
      private string AV13FilterFullText ;
      private string AV24TFDocOperadorId_To_Description ;
      private string AV25TFDocumentoId_To_Description ;
      private string AV26TFOperadorId_To_Description ;
      private string AV44Docoperadorgridds_1_filterfulltext ;
      private string lV44Docoperadorgridds_1_filterfulltext ;
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
      private int[] P005G2_A42OperadorId ;
      private int[] P005G2_A75DocumentoId ;
      private int[] P005G2_A86DocOperadorId ;
      private bool[] P005G2_A87DocOperadorColeta ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class docoperadorgridexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005G2( IGxContext context ,
                                             string AV44Docoperadorgridds_1_filterfulltext ,
                                             int AV45Docoperadorgridds_2_tfdocoperadorid ,
                                             int AV46Docoperadorgridds_3_tfdocoperadorid_to ,
                                             int AV47Docoperadorgridds_4_tfdocumentoid ,
                                             int AV48Docoperadorgridds_5_tfdocumentoid_to ,
                                             int AV49Docoperadorgridds_6_tfoperadorid ,
                                             int AV50Docoperadorgridds_7_tfoperadorid_to ,
                                             int A86DocOperadorId ,
                                             int A75DocumentoId ,
                                             int A42OperadorId ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [OperadorId], [DocumentoId], [DocOperadorId], [DocOperadorColeta] FROM [DocOperador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Docoperadorgridds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([DocOperadorId] AS decimal(8,0))) like '%' + @lV44Docoperadorgridds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV44Docoperadorgridds_1_filterfulltext) or ( CONVERT( char(8), CAST([OperadorId] AS decimal(8,0))) like '%' + @lV44Docoperadorgridds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV45Docoperadorgridds_2_tfdocoperadorid) )
         {
            AddWhere(sWhereString, "([DocOperadorId] >= @AV45Docoperadorgridds_2_tfdocoperadorid)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV46Docoperadorgridds_3_tfdocoperadorid_to) )
         {
            AddWhere(sWhereString, "([DocOperadorId] <= @AV46Docoperadorgridds_3_tfdocoperadorid_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV47Docoperadorgridds_4_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV47Docoperadorgridds_4_tfdocumentoid)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV48Docoperadorgridds_5_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV48Docoperadorgridds_5_tfdocumentoid_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV49Docoperadorgridds_6_tfoperadorid) )
         {
            AddWhere(sWhereString, "([OperadorId] >= @AV49Docoperadorgridds_6_tfoperadorid)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV50Docoperadorgridds_7_tfoperadorid_to) )
         {
            AddWhere(sWhereString, "([OperadorId] <= @AV50Docoperadorgridds_7_tfoperadorid_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [DocOperadorColeta]";
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
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005G2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] );
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
          Object[] prmP005G2;
          prmP005G2 = new Object[] {
          new ParDef("@lV44Docoperadorgridds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Docoperadorgridds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Docoperadorgridds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV45Docoperadorgridds_2_tfdocoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV46Docoperadorgridds_3_tfdocoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV47Docoperadorgridds_4_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV48Docoperadorgridds_5_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV49Docoperadorgridds_6_tfoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV50Docoperadorgridds_7_tfoperadorid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                return;
       }
    }

 }

}
