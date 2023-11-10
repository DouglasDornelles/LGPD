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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class docoperadorww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public docoperadorww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docoperadorww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkDocOperadorColeta = new GXCheckbox();
         chkDocOperadorRetencao = new GXCheckbox();
         chkDocOperadorCompartilhamento = new GXCheckbox();
         chkDocOperadorEliminacao = new GXCheckbox();
         chkDocOperadorProcessamento = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."));
         nGXsfl_43_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV26ManageFiltersExecutionStep = (short)(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV58Pgmname = GetPar( "Pgmname");
         AV27TFDocOperadorId = (int)(NumberUtil.Val( GetPar( "TFDocOperadorId"), "."));
         AV28TFDocOperadorId_To = (int)(NumberUtil.Val( GetPar( "TFDocOperadorId_To"), "."));
         AV29TFDocumentoId = (int)(NumberUtil.Val( GetPar( "TFDocumentoId"), "."));
         AV30TFDocumentoId_To = (int)(NumberUtil.Val( GetPar( "TFDocumentoId_To"), "."));
         AV31TFOperadorId = (int)(NumberUtil.Val( GetPar( "TFOperadorId"), "."));
         AV32TFOperadorId_To = (int)(NumberUtil.Val( GetPar( "TFOperadorId_To"), "."));
         AV33TFDocOperadorColeta_Sel = (short)(NumberUtil.Val( GetPar( "TFDocOperadorColeta_Sel"), "."));
         AV34TFDocOperadorRetencao_Sel = (short)(NumberUtil.Val( GetPar( "TFDocOperadorRetencao_Sel"), "."));
         AV35TFDocOperadorCompartilhamento_Sel = (short)(NumberUtil.Val( GetPar( "TFDocOperadorCompartilhamento_Sel"), "."));
         AV36TFDocOperadorEliminacao_Sel = (short)(NumberUtil.Val( GetPar( "TFDocOperadorEliminacao_Sel"), "."));
         AV37TFDocOperadorProcessamento_Sel = (short)(NumberUtil.Val( GetPar( "TFDocOperadorProcessamento_Sel"), "."));
         AV38TFDocOperadorDataInclusao = context.localUtil.ParseDateParm( GetPar( "TFDocOperadorDataInclusao"));
         AV39TFDocOperadorDataInclusao_To = context.localUtil.ParseDateParm( GetPar( "TFDocOperadorDataInclusao_To"));
         AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV49IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV51IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV55IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV58Pgmname, AV27TFDocOperadorId, AV28TFDocOperadorId_To, AV29TFDocumentoId, AV30TFDocumentoId_To, AV31TFOperadorId, AV32TFOperadorId_To, AV33TFDocOperadorColeta_Sel, AV34TFDocOperadorRetencao_Sel, AV35TFDocOperadorCompartilhamento_Sel, AV36TFDocOperadorEliminacao_Sel, AV37TFDocOperadorProcessamento_Sel, AV38TFDocOperadorDataInclusao, AV39TFDocOperadorDataInclusao_To, AV13OrderedBy, AV14OrderedDsc, AV49IsAuthorized_Update, AV51IsAuthorized_Delete, AV55IsAuthorized_Insert) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "docoperadorww_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA5S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5S2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 21481420), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docoperadorww.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV47GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV53AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV53AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_DOCOPERADORDATAINCLUSAOAUXDATETO", context.localUtil.DToC( AV41DDO_DocOperadorDataInclusaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFDocOperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFDocOperadorId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFDocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFDocumentoId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFOperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFOPERADORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFOperadorId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORCOLETA_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFDocOperadorColeta_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORRETENCAO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFDocOperadorRetencao_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORCOMPARTILHAMENTO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35TFDocOperadorCompartilhamento_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORELIMINACAO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFDocOperadorEliminacao_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORPROCESSAMENTO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFDocOperadorProcessamento_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORDATAINCLUSAO", context.localUtil.DToC( AV38TFDocOperadorDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFDOCOPERADORDATAINCLUSAO_TO", context.localUtil.DToC( AV39TFDocOperadorDataInclusao_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCOPERADORDATAINCLUSAOAUXDATE", context.localUtil.DToC( AV40DDO_DocOperadorDataInclusaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("docoperadorww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "DocOperadorWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tela de consulta dos registros de Operador por Documento" ;
      }

      protected void WB5S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocOperadorWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_DocOperadorWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_DocOperadorWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table1_25_5S2( true) ;
         }
         else
         {
            wb_table1_25_5S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_5S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV45GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV46GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV47GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV53AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_docoperadordatainclusaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_docoperadordatainclusaoauxdatetext_Internalname, AV42DDO_DocOperadorDataInclusaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV42DDO_DocOperadorDataInclusaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_docoperadordatainclusaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocOperadorWW.htm");
            /* User Defined Control */
            ucTfdocoperadordatainclusao_rangepicker.SetProperty("Start Date", AV40DDO_DocOperadorDataInclusaoAuxDate);
            ucTfdocoperadordatainclusao_rangepicker.SetProperty("End Date", AV41DDO_DocOperadorDataInclusaoAuxDateTo);
            ucTfdocoperadordatainclusao_rangepicker.Render(context, "wwp.daterangepicker", Tfdocoperadordatainclusao_rangepicker_Internalname, "TFDOCOPERADORDATAINCLUSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Tela de consulta dos registros de Operador por Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5S0( ) ;
      }

      protected void WS5S2( )
      {
         START5S2( ) ;
         EVT5S2( ) ;
      }

      protected void EVT5S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E145S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E155S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E165S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E175S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              AV48Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV48Update);
                              AV50Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV50Delete);
                              A86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( edtDocOperadorId_Internalname), ",", "."));
                              A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                              A42OperadorId = (int)(context.localUtil.CToN( cgiGet( edtOperadorId_Internalname), ",", "."));
                              A87DocOperadorColeta = StringUtil.StrToBool( cgiGet( chkDocOperadorColeta_Internalname));
                              A88DocOperadorRetencao = StringUtil.StrToBool( cgiGet( chkDocOperadorRetencao_Internalname));
                              A89DocOperadorCompartilhamento = StringUtil.StrToBool( cgiGet( chkDocOperadorCompartilhamento_Internalname));
                              A90DocOperadorEliminacao = StringUtil.StrToBool( cgiGet( chkDocOperadorEliminacao_Internalname));
                              A91DocOperadorProcessamento = StringUtil.StrToBool( cgiGet( chkDocOperadorProcessamento_Internalname));
                              A92DocOperadorDataInclusao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDocOperadorDataInclusao_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E185S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E195S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E205S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA5S2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV58Pgmname ,
                                       int AV27TFDocOperadorId ,
                                       int AV28TFDocOperadorId_To ,
                                       int AV29TFDocumentoId ,
                                       int AV30TFDocumentoId_To ,
                                       int AV31TFOperadorId ,
                                       int AV32TFOperadorId_To ,
                                       short AV33TFDocOperadorColeta_Sel ,
                                       short AV34TFDocOperadorRetencao_Sel ,
                                       short AV35TFDocOperadorCompartilhamento_Sel ,
                                       short AV36TFDocOperadorEliminacao_Sel ,
                                       short AV37TFDocOperadorProcessamento_Sel ,
                                       DateTime AV38TFDocOperadorDataInclusao ,
                                       DateTime AV39TFDocOperadorDataInclusao_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV49IsAuthorized_Update ,
                                       bool AV51IsAuthorized_Delete ,
                                       bool AV55IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E195S2 ();
         GRID_nCurrentRecord = 0;
         RF5S2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DOCOPERADORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCOPERADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV58Pgmname = "DocOperadorWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void RF5S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E195S2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV59Docoperadorwwds_1_filterfulltext ,
                                                 AV60Docoperadorwwds_2_tfdocoperadorid ,
                                                 AV61Docoperadorwwds_3_tfdocoperadorid_to ,
                                                 AV62Docoperadorwwds_4_tfdocumentoid ,
                                                 AV63Docoperadorwwds_5_tfdocumentoid_to ,
                                                 AV64Docoperadorwwds_6_tfoperadorid ,
                                                 AV65Docoperadorwwds_7_tfoperadorid_to ,
                                                 AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                                 AV67Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                                 AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                                 AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                                 AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                                 AV71Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                                 AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                                 A86DocOperadorId ,
                                                 A75DocumentoId ,
                                                 A42OperadorId ,
                                                 A87DocOperadorColeta ,
                                                 A88DocOperadorRetencao ,
                                                 A89DocOperadorCompartilhamento ,
                                                 A90DocOperadorEliminacao ,
                                                 A91DocOperadorProcessamento ,
                                                 A92DocOperadorDataInclusao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV59Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext), "%", "");
            lV59Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext), "%", "");
            lV59Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext), "%", "");
            /* Using cursor H005S2 */
            pr_default.execute(0, new Object[] {lV59Docoperadorwwds_1_filterfulltext, lV59Docoperadorwwds_1_filterfulltext, lV59Docoperadorwwds_1_filterfulltext, AV60Docoperadorwwds_2_tfdocoperadorid, AV61Docoperadorwwds_3_tfdocoperadorid_to, AV62Docoperadorwwds_4_tfdocumentoid, AV63Docoperadorwwds_5_tfdocumentoid_to, AV64Docoperadorwwds_6_tfoperadorid, AV65Docoperadorwwds_7_tfoperadorid_to, AV71Docoperadorwwds_13_tfdocoperadordatainclusao, AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A92DocOperadorDataInclusao = H005S2_A92DocOperadorDataInclusao[0];
               A91DocOperadorProcessamento = H005S2_A91DocOperadorProcessamento[0];
               A90DocOperadorEliminacao = H005S2_A90DocOperadorEliminacao[0];
               A89DocOperadorCompartilhamento = H005S2_A89DocOperadorCompartilhamento[0];
               A88DocOperadorRetencao = H005S2_A88DocOperadorRetencao[0];
               A87DocOperadorColeta = H005S2_A87DocOperadorColeta[0];
               A42OperadorId = H005S2_A42OperadorId[0];
               A75DocumentoId = H005S2_A75DocumentoId[0];
               A86DocOperadorId = H005S2_A86DocOperadorId[0];
               E205S2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 43;
            WB5S0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCOPERADORID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV59Docoperadorwwds_1_filterfulltext ,
                                              AV60Docoperadorwwds_2_tfdocoperadorid ,
                                              AV61Docoperadorwwds_3_tfdocoperadorid_to ,
                                              AV62Docoperadorwwds_4_tfdocumentoid ,
                                              AV63Docoperadorwwds_5_tfdocumentoid_to ,
                                              AV64Docoperadorwwds_6_tfoperadorid ,
                                              AV65Docoperadorwwds_7_tfoperadorid_to ,
                                              AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                              AV67Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                              AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                              AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                              AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                              AV71Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                              AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                              A86DocOperadorId ,
                                              A75DocumentoId ,
                                              A42OperadorId ,
                                              A87DocOperadorColeta ,
                                              A88DocOperadorRetencao ,
                                              A89DocOperadorCompartilhamento ,
                                              A90DocOperadorEliminacao ,
                                              A91DocOperadorProcessamento ,
                                              A92DocOperadorDataInclusao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext), "%", "");
         lV59Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext), "%", "");
         lV59Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext), "%", "");
         /* Using cursor H005S3 */
         pr_default.execute(1, new Object[] {lV59Docoperadorwwds_1_filterfulltext, lV59Docoperadorwwds_1_filterfulltext, lV59Docoperadorwwds_1_filterfulltext, AV60Docoperadorwwds_2_tfdocoperadorid, AV61Docoperadorwwds_3_tfdocoperadorid_to, AV62Docoperadorwwds_4_tfdocumentoid, AV63Docoperadorwwds_5_tfdocumentoid_to, AV64Docoperadorwwds_6_tfoperadorid, AV65Docoperadorwwds_7_tfoperadorid_to, AV71Docoperadorwwds_13_tfdocoperadordatainclusao, AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to});
         GRID_nRecordCount = H005S3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV58Pgmname, AV27TFDocOperadorId, AV28TFDocOperadorId_To, AV29TFDocumentoId, AV30TFDocumentoId_To, AV31TFOperadorId, AV32TFOperadorId_To, AV33TFDocOperadorColeta_Sel, AV34TFDocOperadorRetencao_Sel, AV35TFDocOperadorCompartilhamento_Sel, AV36TFDocOperadorEliminacao_Sel, AV37TFDocOperadorProcessamento_Sel, AV38TFDocOperadorDataInclusao, AV39TFDocOperadorDataInclusao_To, AV13OrderedBy, AV14OrderedDsc, AV49IsAuthorized_Update, AV51IsAuthorized_Delete, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV58Pgmname, AV27TFDocOperadorId, AV28TFDocOperadorId_To, AV29TFDocumentoId, AV30TFDocumentoId_To, AV31TFOperadorId, AV32TFOperadorId_To, AV33TFDocOperadorColeta_Sel, AV34TFDocOperadorRetencao_Sel, AV35TFDocOperadorCompartilhamento_Sel, AV36TFDocOperadorEliminacao_Sel, AV37TFDocOperadorProcessamento_Sel, AV38TFDocOperadorDataInclusao, AV39TFDocOperadorDataInclusao_To, AV13OrderedBy, AV14OrderedDsc, AV49IsAuthorized_Update, AV51IsAuthorized_Delete, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV58Pgmname, AV27TFDocOperadorId, AV28TFDocOperadorId_To, AV29TFDocumentoId, AV30TFDocumentoId_To, AV31TFOperadorId, AV32TFOperadorId_To, AV33TFDocOperadorColeta_Sel, AV34TFDocOperadorRetencao_Sel, AV35TFDocOperadorCompartilhamento_Sel, AV36TFDocOperadorEliminacao_Sel, AV37TFDocOperadorProcessamento_Sel, AV38TFDocOperadorDataInclusao, AV39TFDocOperadorDataInclusao_To, AV13OrderedBy, AV14OrderedDsc, AV49IsAuthorized_Update, AV51IsAuthorized_Delete, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV58Pgmname, AV27TFDocOperadorId, AV28TFDocOperadorId_To, AV29TFDocumentoId, AV30TFDocumentoId_To, AV31TFOperadorId, AV32TFOperadorId_To, AV33TFDocOperadorColeta_Sel, AV34TFDocOperadorRetencao_Sel, AV35TFDocOperadorCompartilhamento_Sel, AV36TFDocOperadorEliminacao_Sel, AV37TFDocOperadorProcessamento_Sel, AV38TFDocOperadorDataInclusao, AV39TFDocOperadorDataInclusao_To, AV13OrderedBy, AV14OrderedDsc, AV49IsAuthorized_Update, AV51IsAuthorized_Delete, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV58Pgmname, AV27TFDocOperadorId, AV28TFDocOperadorId_To, AV29TFDocumentoId, AV30TFDocumentoId_To, AV31TFOperadorId, AV32TFOperadorId_To, AV33TFDocOperadorColeta_Sel, AV34TFDocOperadorRetencao_Sel, AV35TFDocOperadorCompartilhamento_Sel, AV36TFDocOperadorEliminacao_Sel, AV37TFDocOperadorProcessamento_Sel, AV38TFDocOperadorDataInclusao, AV39TFDocOperadorDataInclusao_To, AV13OrderedBy, AV14OrderedDsc, AV49IsAuthorized_Update, AV51IsAuthorized_Delete, AV55IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV58Pgmname = "DocOperadorWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E185S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV53AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV43DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ",", "."));
            AV45GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV46GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV47GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV40DDO_DocOperadorDataInclusaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_DOCOPERADORDATAINCLUSAOAUXDATE"), 0);
            AV41DDO_DocOperadorDataInclusaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_DOCOPERADORDATAINCLUSAOAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            AV42DDO_DocOperadorDataInclusaoAuxDateText = cgiGet( edtavDdo_docoperadordatainclusaoauxdatetext_Internalname);
            AssignAttri("", false, "AV42DDO_DocOperadorDataInclusaoAuxDateText", AV42DDO_DocOperadorDataInclusaoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E185S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E185S2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFDOCOPERADORDATAINCLUSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_docoperadordatainclusaoauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV53AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV54AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV54AGExportDataItem.gxTpr_Title = "Excel";
         AV54AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV54AGExportDataItem.gxTpr_Eventkey = "Export";
         AV54AGExportDataItem.gxTpr_Isdivider = false;
         AV53AGExportData.Add(AV54AGExportDataItem, 0);
         AV54AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV54AGExportDataItem.gxTpr_Title = "PDF";
         AV54AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV54AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV54AGExportDataItem.gxTpr_Isdivider = false;
         AV53AGExportData.Add(AV54AGExportDataItem, 0);
         GXt_boolean1 = AV52IsAuthorized_DocOperadorColeta;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperadorview_Execute", out  GXt_boolean1) ;
         AV52IsAuthorized_DocOperadorColeta = GXt_boolean1;
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Doc Operador";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV43DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV43DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E195S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV23Session.Get("DocOperadorWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("DocOperadorWWColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtDocOperadorId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocOperadorId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocOperadorId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtDocumentoId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtOperadorId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperadorId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperadorId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkDocOperadorColeta.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocOperadorColeta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocOperadorColeta.Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkDocOperadorRetencao.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocOperadorRetencao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocOperadorRetencao.Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkDocOperadorCompartilhamento.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocOperadorCompartilhamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocOperadorCompartilhamento.Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkDocOperadorEliminacao.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocOperadorEliminacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocOperadorEliminacao.Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkDocOperadorProcessamento.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocOperadorProcessamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocOperadorProcessamento.Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtDocOperadorDataInclusao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocOperadorDataInclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocOperadorDataInclusao_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV45GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         AV46GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
         GXt_char3 = AV47GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV58Pgmname, out  GXt_char3) ;
         AV47GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV47GridAppliedFilters", AV47GridAppliedFilters);
         AV59Docoperadorwwds_1_filterfulltext = AV16FilterFullText;
         AV60Docoperadorwwds_2_tfdocoperadorid = AV27TFDocOperadorId;
         AV61Docoperadorwwds_3_tfdocoperadorid_to = AV28TFDocOperadorId_To;
         AV62Docoperadorwwds_4_tfdocumentoid = AV29TFDocumentoId;
         AV63Docoperadorwwds_5_tfdocumentoid_to = AV30TFDocumentoId_To;
         AV64Docoperadorwwds_6_tfoperadorid = AV31TFOperadorId;
         AV65Docoperadorwwds_7_tfoperadorid_to = AV32TFOperadorId_To;
         AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV33TFDocOperadorColeta_Sel;
         AV67Docoperadorwwds_9_tfdocoperadorretencao_sel = AV34TFDocOperadorRetencao_Sel;
         AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV35TFDocOperadorCompartilhamento_Sel;
         AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV36TFDocOperadorEliminacao_Sel;
         AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV37TFDocOperadorProcessamento_Sel;
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = AV38TFDocOperadorDataInclusao;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV39TFDocOperadorDataInclusao_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E125S2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV44PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV44PageToGo) ;
         }
      }

      protected void E135S2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E155S2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorId") == 0 )
            {
               AV27TFDocOperadorId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV27TFDocOperadorId", StringUtil.LTrimStr( (decimal)(AV27TFDocOperadorId), 8, 0));
               AV28TFDocOperadorId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV28TFDocOperadorId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocOperadorId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoId") == 0 )
            {
               AV29TFDocumentoId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV29TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV29TFDocumentoId), 8, 0));
               AV30TFDocumentoId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV30TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFDocumentoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperadorId") == 0 )
            {
               AV31TFOperadorId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFOperadorId", StringUtil.LTrimStr( (decimal)(AV31TFOperadorId), 8, 0));
               AV32TFOperadorId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFOperadorId_To", StringUtil.LTrimStr( (decimal)(AV32TFOperadorId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorColeta") == 0 )
            {
               AV33TFDocOperadorColeta_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV33TFDocOperadorColeta_Sel", StringUtil.Str( (decimal)(AV33TFDocOperadorColeta_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorRetencao") == 0 )
            {
               AV34TFDocOperadorRetencao_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV34TFDocOperadorRetencao_Sel", StringUtil.Str( (decimal)(AV34TFDocOperadorRetencao_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorCompartilhamento") == 0 )
            {
               AV35TFDocOperadorCompartilhamento_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV35TFDocOperadorCompartilhamento_Sel", StringUtil.Str( (decimal)(AV35TFDocOperadorCompartilhamento_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorEliminacao") == 0 )
            {
               AV36TFDocOperadorEliminacao_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV36TFDocOperadorEliminacao_Sel", StringUtil.Str( (decimal)(AV36TFDocOperadorEliminacao_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorProcessamento") == 0 )
            {
               AV37TFDocOperadorProcessamento_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV37TFDocOperadorProcessamento_Sel", StringUtil.Str( (decimal)(AV37TFDocOperadorProcessamento_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocOperadorDataInclusao") == 0 )
            {
               AV38TFDocOperadorDataInclusao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV38TFDocOperadorDataInclusao", context.localUtil.Format(AV38TFDocOperadorDataInclusao, "99/99/99"));
               AV39TFDocOperadorDataInclusao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV39TFDocOperadorDataInclusao_To", context.localUtil.Format(AV39TFDocOperadorDataInclusao_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E205S2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV48Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV48Update);
         if ( AV49IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docoperador.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A86DocOperadorId,8,0));
            edtavUpdate_Link = formatLink("docoperador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV50Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV50Delete);
         if ( AV51IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docoperador.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A86DocOperadorId,8,0));
            edtavDelete_Link = formatLink("docoperador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 43;
         }
         sendrow_432( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
         {
            context.DoAjaxLoad(43, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E165S2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "DocOperadorWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E115S2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("DocOperadorWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV58Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("DocOperadorWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "DocOperadorWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV25ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV11GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
               context.DoAjaxRefresh();
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E175S2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV55IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docoperador.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            CallWebObject(formatLink("docoperador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E145S2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorId",  "",  "Operador Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocumentoId",  "",  "do Documento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "OperadorId",  "",  "do Operador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorColeta",  "",  "Coleta?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorRetencao",  "",  "Retenção?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorCompartilhamento",  "",  "Compartilhamento?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorEliminacao",  "",  "Eliminição?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorProcessamento",  "",  "Processamento?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocOperadorDataInclusao",  "",  "Data Inclusao",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocOperadorWWColumnsSelector", out  GXt_char3) ;
         AV20UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV49IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperador_Update", out  GXt_boolean1) ;
         AV49IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Update", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         if ( ! ( AV49IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean1 = AV51IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperador_Delete", out  GXt_boolean1) ;
         AV51IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV51IsAuthorized_Delete", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         if ( ! ( AV51IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean1 = AV55IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperador_Insert", out  GXt_boolean1) ;
         AV55IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV55IsAuthorized_Insert", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         if ( ! ( AV55IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "DocOperadorWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFDocOperadorId = 0;
         AssignAttri("", false, "AV27TFDocOperadorId", StringUtil.LTrimStr( (decimal)(AV27TFDocOperadorId), 8, 0));
         AV28TFDocOperadorId_To = 0;
         AssignAttri("", false, "AV28TFDocOperadorId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocOperadorId_To), 8, 0));
         AV29TFDocumentoId = 0;
         AssignAttri("", false, "AV29TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV29TFDocumentoId), 8, 0));
         AV30TFDocumentoId_To = 0;
         AssignAttri("", false, "AV30TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFDocumentoId_To), 8, 0));
         AV31TFOperadorId = 0;
         AssignAttri("", false, "AV31TFOperadorId", StringUtil.LTrimStr( (decimal)(AV31TFOperadorId), 8, 0));
         AV32TFOperadorId_To = 0;
         AssignAttri("", false, "AV32TFOperadorId_To", StringUtil.LTrimStr( (decimal)(AV32TFOperadorId_To), 8, 0));
         AV33TFDocOperadorColeta_Sel = 0;
         AssignAttri("", false, "AV33TFDocOperadorColeta_Sel", StringUtil.Str( (decimal)(AV33TFDocOperadorColeta_Sel), 1, 0));
         AV34TFDocOperadorRetencao_Sel = 0;
         AssignAttri("", false, "AV34TFDocOperadorRetencao_Sel", StringUtil.Str( (decimal)(AV34TFDocOperadorRetencao_Sel), 1, 0));
         AV35TFDocOperadorCompartilhamento_Sel = 0;
         AssignAttri("", false, "AV35TFDocOperadorCompartilhamento_Sel", StringUtil.Str( (decimal)(AV35TFDocOperadorCompartilhamento_Sel), 1, 0));
         AV36TFDocOperadorEliminacao_Sel = 0;
         AssignAttri("", false, "AV36TFDocOperadorEliminacao_Sel", StringUtil.Str( (decimal)(AV36TFDocOperadorEliminacao_Sel), 1, 0));
         AV37TFDocOperadorProcessamento_Sel = 0;
         AssignAttri("", false, "AV37TFDocOperadorProcessamento_Sel", StringUtil.Str( (decimal)(AV37TFDocOperadorProcessamento_Sel), 1, 0));
         AV38TFDocOperadorDataInclusao = DateTime.MinValue;
         AssignAttri("", false, "AV38TFDocOperadorDataInclusao", context.localUtil.Format(AV38TFDocOperadorDataInclusao, "99/99/99"));
         AV39TFDocOperadorDataInclusao_To = DateTime.MinValue;
         AssignAttri("", false, "AV39TFDocOperadorDataInclusao_To", context.localUtil.Format(AV39TFDocOperadorDataInclusao_To, "99/99/99"));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV58Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV58Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV58Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORID") == 0 )
            {
               AV27TFDocOperadorId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV27TFDocOperadorId", StringUtil.LTrimStr( (decimal)(AV27TFDocOperadorId), 8, 0));
               AV28TFDocOperadorId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV28TFDocOperadorId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocOperadorId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV29TFDocumentoId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV29TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV29TFDocumentoId), 8, 0));
               AV30TFDocumentoId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV30TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFDocumentoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERADORID") == 0 )
            {
               AV31TFOperadorId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFOperadorId", StringUtil.LTrimStr( (decimal)(AV31TFOperadorId), 8, 0));
               AV32TFOperadorId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFOperadorId_To", StringUtil.LTrimStr( (decimal)(AV32TFOperadorId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORCOLETA_SEL") == 0 )
            {
               AV33TFDocOperadorColeta_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV33TFDocOperadorColeta_Sel", StringUtil.Str( (decimal)(AV33TFDocOperadorColeta_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORRETENCAO_SEL") == 0 )
            {
               AV34TFDocOperadorRetencao_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV34TFDocOperadorRetencao_Sel", StringUtil.Str( (decimal)(AV34TFDocOperadorRetencao_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORCOMPARTILHAMENTO_SEL") == 0 )
            {
               AV35TFDocOperadorCompartilhamento_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV35TFDocOperadorCompartilhamento_Sel", StringUtil.Str( (decimal)(AV35TFDocOperadorCompartilhamento_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORELIMINACAO_SEL") == 0 )
            {
               AV36TFDocOperadorEliminacao_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV36TFDocOperadorEliminacao_Sel", StringUtil.Str( (decimal)(AV36TFDocOperadorEliminacao_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORPROCESSAMENTO_SEL") == 0 )
            {
               AV37TFDocOperadorProcessamento_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV37TFDocOperadorProcessamento_Sel", StringUtil.Str( (decimal)(AV37TFDocOperadorProcessamento_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORDATAINCLUSAO") == 0 )
            {
               AV38TFDocOperadorDataInclusao = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV38TFDocOperadorDataInclusao", context.localUtil.Format(AV38TFDocOperadorDataInclusao, "99/99/99"));
               AV39TFDocOperadorDataInclusao_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV39TFDocOperadorDataInclusao_To", context.localUtil.Format(AV39TFDocOperadorDataInclusao_To, "99/99/99"));
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         Ddo_grid_Selectedvalue_set = "|||"+((0==AV33TFDocOperadorColeta_Sel) ? "" : StringUtil.Str( (decimal)(AV33TFDocOperadorColeta_Sel), 1, 0))+"|"+((0==AV34TFDocOperadorRetencao_Sel) ? "" : StringUtil.Str( (decimal)(AV34TFDocOperadorRetencao_Sel), 1, 0))+"|"+((0==AV35TFDocOperadorCompartilhamento_Sel) ? "" : StringUtil.Str( (decimal)(AV35TFDocOperadorCompartilhamento_Sel), 1, 0))+"|"+((0==AV36TFDocOperadorEliminacao_Sel) ? "" : StringUtil.Str( (decimal)(AV36TFDocOperadorEliminacao_Sel), 1, 0))+"|"+((0==AV37TFDocOperadorProcessamento_Sel) ? "" : StringUtil.Str( (decimal)(AV37TFDocOperadorProcessamento_Sel), 1, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = ((0==AV27TFDocOperadorId) ? "" : StringUtil.Str( (decimal)(AV27TFDocOperadorId), 8, 0))+"|"+((0==AV29TFDocumentoId) ? "" : StringUtil.Str( (decimal)(AV29TFDocumentoId), 8, 0))+"|"+((0==AV31TFOperadorId) ? "" : StringUtil.Str( (decimal)(AV31TFOperadorId), 8, 0))+"||||||"+((DateTime.MinValue==AV38TFDocOperadorDataInclusao) ? "" : context.localUtil.DToC( AV38TFDocOperadorDataInclusao, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV28TFDocOperadorId_To) ? "" : StringUtil.Str( (decimal)(AV28TFDocOperadorId_To), 8, 0))+"|"+((0==AV30TFDocumentoId_To) ? "" : StringUtil.Str( (decimal)(AV30TFDocumentoId_To), 8, 0))+"|"+((0==AV32TFOperadorId_To) ? "" : StringUtil.Str( (decimal)(AV32TFOperadorId_To), 8, 0))+"||||||"+((DateTime.MinValue==AV39TFDocOperadorDataInclusao_To) ? "" : context.localUtil.DToC( AV39TFDocOperadorDataInclusao_To, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV58Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORID",  "Operador Id",  !((0==AV27TFDocOperadorId)&&(0==AV28TFDocOperadorId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFDocOperadorId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFDocOperadorId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTOID",  "do Documento",  !((0==AV29TFDocumentoId)&&(0==AV30TFDocumentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFDocumentoId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFDocumentoId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERADORID",  "do Operador",  !((0==AV31TFOperadorId)&&(0==AV32TFOperadorId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFOperadorId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFOperadorId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORCOLETA_SEL",  "Coleta?",  !(0==AV33TFDocOperadorColeta_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFDocOperadorColeta_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORRETENCAO_SEL",  "Retenção?",  !(0==AV34TFDocOperadorRetencao_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFDocOperadorRetencao_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORCOMPARTILHAMENTO_SEL",  "Compartilhamento?",  !(0==AV35TFDocOperadorCompartilhamento_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV35TFDocOperadorCompartilhamento_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORELIMINACAO_SEL",  "Eliminição?",  !(0==AV36TFDocOperadorEliminacao_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFDocOperadorEliminacao_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORPROCESSAMENTO_SEL",  "Processamento?",  !(0==AV37TFDocOperadorProcessamento_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFDocOperadorProcessamento_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCOPERADORDATAINCLUSAO",  "Data Inclusao",  !((DateTime.MinValue==AV38TFDocOperadorDataInclusao)&&(DateTime.MinValue==AV39TFDocOperadorDataInclusao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV38TFDocOperadorDataInclusao, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV39TFDocOperadorDataInclusao_To, 2, "/"))) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV58Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "DocOperador";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new docoperadorwwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV18ErrorMessage);
         }
      }

      protected void S212( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("docoperadorwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_5S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_30_5S2( true) ;
         }
         else
         {
            wb_table2_30_5S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_5S2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_5S2e( true) ;
         }
         else
         {
            wb_table1_25_5S2e( false) ;
         }
      }

      protected void wb_table2_30_5S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_DocOperadorWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_5S2e( true) ;
         }
         else
         {
            wb_table2_30_5S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA5S2( ) ;
         WS5S2( ) ;
         WE5S2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910512047", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("docoperadorww.js", "?202311910512048", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_idx;
         edtDocOperadorId_Internalname = "DOCOPERADORID_"+sGXsfl_43_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_43_idx;
         edtOperadorId_Internalname = "OPERADORID_"+sGXsfl_43_idx;
         chkDocOperadorColeta_Internalname = "DOCOPERADORCOLETA_"+sGXsfl_43_idx;
         chkDocOperadorRetencao_Internalname = "DOCOPERADORRETENCAO_"+sGXsfl_43_idx;
         chkDocOperadorCompartilhamento_Internalname = "DOCOPERADORCOMPARTILHAMENTO_"+sGXsfl_43_idx;
         chkDocOperadorEliminacao_Internalname = "DOCOPERADORELIMINACAO_"+sGXsfl_43_idx;
         chkDocOperadorProcessamento_Internalname = "DOCOPERADORPROCESSAMENTO_"+sGXsfl_43_idx;
         edtDocOperadorDataInclusao_Internalname = "DOCOPERADORDATAINCLUSAO_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_fel_idx;
         edtDocOperadorId_Internalname = "DOCOPERADORID_"+sGXsfl_43_fel_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_43_fel_idx;
         edtOperadorId_Internalname = "OPERADORID_"+sGXsfl_43_fel_idx;
         chkDocOperadorColeta_Internalname = "DOCOPERADORCOLETA_"+sGXsfl_43_fel_idx;
         chkDocOperadorRetencao_Internalname = "DOCOPERADORRETENCAO_"+sGXsfl_43_fel_idx;
         chkDocOperadorCompartilhamento_Internalname = "DOCOPERADORCOMPARTILHAMENTO_"+sGXsfl_43_fel_idx;
         chkDocOperadorEliminacao_Internalname = "DOCOPERADORELIMINACAO_"+sGXsfl_43_fel_idx;
         chkDocOperadorProcessamento_Internalname = "DOCOPERADORPROCESSAMENTO_"+sGXsfl_43_fel_idx;
         edtDocOperadorDataInclusao_Internalname = "DOCOPERADORDATAINCLUSAO_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         SubsflControlProps_432( ) ;
         WB5S0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV48Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV50Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocOperadorId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocOperadorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocOperadorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocOperadorId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocumentoId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocumentoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtOperadorId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperadorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A42OperadorId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A42OperadorId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperadorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtOperadorId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocOperadorColeta.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORCOLETA_" + sGXsfl_43_idx;
            chkDocOperadorColeta.Name = GXCCtl;
            chkDocOperadorColeta.WebTags = "";
            chkDocOperadorColeta.Caption = "";
            AssignProp("", false, chkDocOperadorColeta_Internalname, "TitleCaption", chkDocOperadorColeta.Caption, !bGXsfl_43_Refreshing);
            chkDocOperadorColeta.CheckedValue = "false";
            A87DocOperadorColeta = StringUtil.StrToBool( StringUtil.BoolToStr( A87DocOperadorColeta));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorColeta_Internalname,StringUtil.BoolToStr( A87DocOperadorColeta),(string)"",(string)"",chkDocOperadorColeta.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocOperadorRetencao.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORRETENCAO_" + sGXsfl_43_idx;
            chkDocOperadorRetencao.Name = GXCCtl;
            chkDocOperadorRetencao.WebTags = "";
            chkDocOperadorRetencao.Caption = "";
            AssignProp("", false, chkDocOperadorRetencao_Internalname, "TitleCaption", chkDocOperadorRetencao.Caption, !bGXsfl_43_Refreshing);
            chkDocOperadorRetencao.CheckedValue = "false";
            A88DocOperadorRetencao = StringUtil.StrToBool( StringUtil.BoolToStr( A88DocOperadorRetencao));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorRetencao_Internalname,StringUtil.BoolToStr( A88DocOperadorRetencao),(string)"",(string)"",chkDocOperadorRetencao.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocOperadorCompartilhamento.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORCOMPARTILHAMENTO_" + sGXsfl_43_idx;
            chkDocOperadorCompartilhamento.Name = GXCCtl;
            chkDocOperadorCompartilhamento.WebTags = "";
            chkDocOperadorCompartilhamento.Caption = "";
            AssignProp("", false, chkDocOperadorCompartilhamento_Internalname, "TitleCaption", chkDocOperadorCompartilhamento.Caption, !bGXsfl_43_Refreshing);
            chkDocOperadorCompartilhamento.CheckedValue = "false";
            A89DocOperadorCompartilhamento = StringUtil.StrToBool( StringUtil.BoolToStr( A89DocOperadorCompartilhamento));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorCompartilhamento_Internalname,StringUtil.BoolToStr( A89DocOperadorCompartilhamento),(string)"",(string)"",chkDocOperadorCompartilhamento.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocOperadorEliminacao.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORELIMINACAO_" + sGXsfl_43_idx;
            chkDocOperadorEliminacao.Name = GXCCtl;
            chkDocOperadorEliminacao.WebTags = "";
            chkDocOperadorEliminacao.Caption = "";
            AssignProp("", false, chkDocOperadorEliminacao_Internalname, "TitleCaption", chkDocOperadorEliminacao.Caption, !bGXsfl_43_Refreshing);
            chkDocOperadorEliminacao.CheckedValue = "false";
            A90DocOperadorEliminacao = StringUtil.StrToBool( StringUtil.BoolToStr( A90DocOperadorEliminacao));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorEliminacao_Internalname,StringUtil.BoolToStr( A90DocOperadorEliminacao),(string)"",(string)"",chkDocOperadorEliminacao.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocOperadorProcessamento.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORPROCESSAMENTO_" + sGXsfl_43_idx;
            chkDocOperadorProcessamento.Name = GXCCtl;
            chkDocOperadorProcessamento.WebTags = "";
            chkDocOperadorProcessamento.Caption = "";
            AssignProp("", false, chkDocOperadorProcessamento_Internalname, "TitleCaption", chkDocOperadorProcessamento.Caption, !bGXsfl_43_Refreshing);
            chkDocOperadorProcessamento.CheckedValue = "false";
            A91DocOperadorProcessamento = StringUtil.StrToBool( StringUtil.BoolToStr( A91DocOperadorProcessamento));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorProcessamento_Internalname,StringUtil.BoolToStr( A91DocOperadorProcessamento),(string)"",(string)"",chkDocOperadorProcessamento.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocOperadorDataInclusao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocOperadorDataInclusao_Internalname,context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"),context.localUtil.Format( A92DocOperadorDataInclusao, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocOperadorDataInclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocOperadorDataInclusao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes5S2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "DOCOPERADORCOLETA_" + sGXsfl_43_idx;
         chkDocOperadorColeta.Name = GXCCtl;
         chkDocOperadorColeta.WebTags = "";
         chkDocOperadorColeta.Caption = "";
         AssignProp("", false, chkDocOperadorColeta_Internalname, "TitleCaption", chkDocOperadorColeta.Caption, !bGXsfl_43_Refreshing);
         chkDocOperadorColeta.CheckedValue = "false";
         A87DocOperadorColeta = StringUtil.StrToBool( StringUtil.BoolToStr( A87DocOperadorColeta));
         GXCCtl = "DOCOPERADORRETENCAO_" + sGXsfl_43_idx;
         chkDocOperadorRetencao.Name = GXCCtl;
         chkDocOperadorRetencao.WebTags = "";
         chkDocOperadorRetencao.Caption = "";
         AssignProp("", false, chkDocOperadorRetencao_Internalname, "TitleCaption", chkDocOperadorRetencao.Caption, !bGXsfl_43_Refreshing);
         chkDocOperadorRetencao.CheckedValue = "false";
         A88DocOperadorRetencao = StringUtil.StrToBool( StringUtil.BoolToStr( A88DocOperadorRetencao));
         GXCCtl = "DOCOPERADORCOMPARTILHAMENTO_" + sGXsfl_43_idx;
         chkDocOperadorCompartilhamento.Name = GXCCtl;
         chkDocOperadorCompartilhamento.WebTags = "";
         chkDocOperadorCompartilhamento.Caption = "";
         AssignProp("", false, chkDocOperadorCompartilhamento_Internalname, "TitleCaption", chkDocOperadorCompartilhamento.Caption, !bGXsfl_43_Refreshing);
         chkDocOperadorCompartilhamento.CheckedValue = "false";
         A89DocOperadorCompartilhamento = StringUtil.StrToBool( StringUtil.BoolToStr( A89DocOperadorCompartilhamento));
         GXCCtl = "DOCOPERADORELIMINACAO_" + sGXsfl_43_idx;
         chkDocOperadorEliminacao.Name = GXCCtl;
         chkDocOperadorEliminacao.WebTags = "";
         chkDocOperadorEliminacao.Caption = "";
         AssignProp("", false, chkDocOperadorEliminacao_Internalname, "TitleCaption", chkDocOperadorEliminacao.Caption, !bGXsfl_43_Refreshing);
         chkDocOperadorEliminacao.CheckedValue = "false";
         A90DocOperadorEliminacao = StringUtil.StrToBool( StringUtil.BoolToStr( A90DocOperadorEliminacao));
         GXCCtl = "DOCOPERADORPROCESSAMENTO_" + sGXsfl_43_idx;
         chkDocOperadorProcessamento.Name = GXCCtl;
         chkDocOperadorProcessamento.WebTags = "";
         chkDocOperadorProcessamento.Caption = "";
         AssignProp("", false, chkDocOperadorProcessamento_Internalname, "TitleCaption", chkDocOperadorProcessamento.Caption, !bGXsfl_43_Refreshing);
         chkDocOperadorProcessamento.CheckedValue = "false";
         A91DocOperadorProcessamento = StringUtil.StrToBool( StringUtil.BoolToStr( A91DocOperadorProcessamento));
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocOperadorId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Operador Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocumentoId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "do Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperadorId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "do Operador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocOperadorColeta.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Coleta?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocOperadorRetencao.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Retenção?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocOperadorCompartilhamento.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Compartilhamento?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocOperadorEliminacao.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Eliminição?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocOperadorProcessamento.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Processamento?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocOperadorDataInclusao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data Inclusao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV48Update));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV50Delete));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocOperadorId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocumentoId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A42OperadorId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperadorId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A87DocOperadorColeta));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocOperadorColeta.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A88DocOperadorRetencao));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocOperadorRetencao.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A89DocOperadorCompartilhamento));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocOperadorCompartilhamento.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A90DocOperadorEliminacao));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocOperadorEliminacao.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A91DocOperadorProcessamento));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocOperadorProcessamento.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocOperadorDataInclusao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtDocOperadorId_Internalname = "DOCOPERADORID";
         edtDocumentoId_Internalname = "DOCUMENTOID";
         edtOperadorId_Internalname = "OPERADORID";
         chkDocOperadorColeta_Internalname = "DOCOPERADORCOLETA";
         chkDocOperadorRetencao_Internalname = "DOCOPERADORRETENCAO";
         chkDocOperadorCompartilhamento_Internalname = "DOCOPERADORCOMPARTILHAMENTO";
         chkDocOperadorEliminacao_Internalname = "DOCOPERADORELIMINACAO";
         chkDocOperadorProcessamento_Internalname = "DOCOPERADORPROCESSAMENTO";
         edtDocOperadorDataInclusao_Internalname = "DOCOPERADORDATAINCLUSAO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_docoperadordatainclusaoauxdatetext_Internalname = "vDDO_DOCOPERADORDATAINCLUSAOAUXDATETEXT";
         Tfdocoperadordatainclusao_rangepicker_Internalname = "TFDOCOPERADORDATAINCLUSAO_RANGEPICKER";
         divDdo_docoperadordatainclusaoauxdates_Internalname = "DDO_DOCOPERADORDATAINCLUSAOAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtDocOperadorDataInclusao_Jsonclick = "";
         chkDocOperadorProcessamento.Caption = "";
         chkDocOperadorEliminacao.Caption = "";
         chkDocOperadorCompartilhamento.Caption = "";
         chkDocOperadorRetencao.Caption = "";
         chkDocOperadorColeta.Caption = "";
         edtOperadorId_Jsonclick = "";
         edtDocumentoId_Jsonclick = "";
         edtDocOperadorId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtDocOperadorDataInclusao_Visible = -1;
         chkDocOperadorProcessamento.Visible = -1;
         chkDocOperadorEliminacao.Visible = -1;
         chkDocOperadorCompartilhamento.Visible = -1;
         chkDocOperadorRetencao.Visible = -1;
         chkDocOperadorColeta.Visible = -1;
         edtOperadorId_Visible = -1;
         edtDocumentoId_Visible = -1;
         edtDocOperadorId_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_docoperadordatainclusaoauxdatetext_Jsonclick = "";
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "8.0|8.0|8.0||||||";
         Ddo_grid_Datalistfixedvalues = "|||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|";
         Ddo_grid_Datalisttype = "|||FixedValues|FixedValues|FixedValues|FixedValues|FixedValues|";
         Ddo_grid_Includedatalist = "|||T|T|T|T|T|";
         Ddo_grid_Filterisrange = "T|T|T||||||P";
         Ddo_grid_Filtertype = "Numeric|Numeric|Numeric||||||Date";
         Ddo_grid_Includefilter = "T|T|T||||||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5|6|7|8|9";
         Ddo_grid_Columnids = "2:DocOperadorId|3:DocumentoId|4:OperadorId|5:DocOperadorColeta|6:DocOperadorRetencao|7:DocOperadorCompartilhamento|8:DocOperadorEliminacao|9:DocOperadorProcessamento|10:DocOperadorDataInclusao";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opções";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tela de consulta dos registros de Operador por Documento";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocOperadorId_Visible',ctrl:'DOCOPERADORID',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtOperadorId_Visible',ctrl:'OPERADORID',prop:'Visible'},{av:'chkDocOperadorColeta.Visible',ctrl:'DOCOPERADORCOLETA',prop:'Visible'},{av:'chkDocOperadorRetencao.Visible',ctrl:'DOCOPERADORRETENCAO',prop:'Visible'},{av:'chkDocOperadorCompartilhamento.Visible',ctrl:'DOCOPERADORCOMPARTILHAMENTO',prop:'Visible'},{av:'chkDocOperadorEliminacao.Visible',ctrl:'DOCOPERADORELIMINACAO',prop:'Visible'},{av:'chkDocOperadorProcessamento.Visible',ctrl:'DOCOPERADORPROCESSAMENTO',prop:'Visible'},{av:'edtDocOperadorDataInclusao_Visible',ctrl:'DOCOPERADORDATAINCLUSAO',prop:'Visible'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E125S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E135S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E155S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E205S2',iparms:[{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV48Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV50Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E165S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtDocOperadorId_Visible',ctrl:'DOCOPERADORID',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtOperadorId_Visible',ctrl:'OPERADORID',prop:'Visible'},{av:'chkDocOperadorColeta.Visible',ctrl:'DOCOPERADORCOLETA',prop:'Visible'},{av:'chkDocOperadorRetencao.Visible',ctrl:'DOCOPERADORRETENCAO',prop:'Visible'},{av:'chkDocOperadorCompartilhamento.Visible',ctrl:'DOCOPERADORCOMPARTILHAMENTO',prop:'Visible'},{av:'chkDocOperadorEliminacao.Visible',ctrl:'DOCOPERADORELIMINACAO',prop:'Visible'},{av:'chkDocOperadorProcessamento.Visible',ctrl:'DOCOPERADORPROCESSAMENTO',prop:'Visible'},{av:'edtDocOperadorDataInclusao_Visible',ctrl:'DOCOPERADORDATAINCLUSAO',prop:'Visible'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E115S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocOperadorId_Visible',ctrl:'DOCOPERADORID',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtOperadorId_Visible',ctrl:'OPERADORID',prop:'Visible'},{av:'chkDocOperadorColeta.Visible',ctrl:'DOCOPERADORCOLETA',prop:'Visible'},{av:'chkDocOperadorRetencao.Visible',ctrl:'DOCOPERADORRETENCAO',prop:'Visible'},{av:'chkDocOperadorCompartilhamento.Visible',ctrl:'DOCOPERADORCOMPARTILHAMENTO',prop:'Visible'},{av:'chkDocOperadorEliminacao.Visible',ctrl:'DOCOPERADORELIMINACAO',prop:'Visible'},{av:'chkDocOperadorProcessamento.Visible',ctrl:'DOCOPERADORPROCESSAMENTO',prop:'Visible'},{av:'edtDocOperadorDataInclusao_Visible',ctrl:'DOCOPERADORDATAINCLUSAO',prop:'Visible'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E175S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocOperadorId_Visible',ctrl:'DOCOPERADORID',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtOperadorId_Visible',ctrl:'OPERADORID',prop:'Visible'},{av:'chkDocOperadorColeta.Visible',ctrl:'DOCOPERADORCOLETA',prop:'Visible'},{av:'chkDocOperadorRetencao.Visible',ctrl:'DOCOPERADORRETENCAO',prop:'Visible'},{av:'chkDocOperadorCompartilhamento.Visible',ctrl:'DOCOPERADORCOMPARTILHAMENTO',prop:'Visible'},{av:'chkDocOperadorEliminacao.Visible',ctrl:'DOCOPERADORELIMINACAO',prop:'Visible'},{av:'chkDocOperadorProcessamento.Visible',ctrl:'DOCOPERADORPROCESSAMENTO',prop:'Visible'},{av:'edtDocOperadorDataInclusao_Visible',ctrl:'DOCOPERADORDATAINCLUSAO',prop:'Visible'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E145S2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFDocOperadorId',fld:'vTFDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV28TFDocOperadorId_To',fld:'vTFDOCOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV30TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFOperadorId',fld:'vTFOPERADORID',pic:'ZZZZZZZ9'},{av:'AV32TFOperadorId_To',fld:'vTFOPERADORID_TO',pic:'ZZZZZZZ9'},{av:'AV33TFDocOperadorColeta_Sel',fld:'vTFDOCOPERADORCOLETA_SEL',pic:'9'},{av:'AV34TFDocOperadorRetencao_Sel',fld:'vTFDOCOPERADORRETENCAO_SEL',pic:'9'},{av:'AV35TFDocOperadorCompartilhamento_Sel',fld:'vTFDOCOPERADORCOMPARTILHAMENTO_SEL',pic:'9'},{av:'AV36TFDocOperadorEliminacao_Sel',fld:'vTFDOCOPERADORELIMINACAO_SEL',pic:'9'},{av:'AV37TFDocOperadorProcessamento_Sel',fld:'vTFDOCOPERADORPROCESSAMENTO_SEL',pic:'9'},{av:'AV38TFDocOperadorDataInclusao',fld:'vTFDOCOPERADORDATAINCLUSAO',pic:''},{av:'AV39TFDocOperadorDataInclusao_To',fld:'vTFDOCOPERADORDATAINCLUSAO_TO',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV55IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("NULL","{handler:'Valid_Docoperadordatainclusao',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV58Pgmname = "";
         AV38TFDocOperadorDataInclusao = DateTime.MinValue;
         AV39TFDocOperadorDataInclusao_To = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47GridAppliedFilters = "";
         AV53AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV43DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41DDO_DocOperadorDataInclusaoAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40DDO_DocOperadorDataInclusaoAuxDate = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV42DDO_DocOperadorDataInclusaoAuxDateText = "";
         ucTfdocoperadordatainclusao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV48Update = "";
         AV50Delete = "";
         A92DocOperadorDataInclusao = DateTime.MinValue;
         scmdbuf = "";
         lV59Docoperadorwwds_1_filterfulltext = "";
         AV59Docoperadorwwds_1_filterfulltext = "";
         AV71Docoperadorwwds_13_tfdocoperadordatainclusao = DateTime.MinValue;
         AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to = DateTime.MinValue;
         H005S2_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H005S2_A91DocOperadorProcessamento = new bool[] {false} ;
         H005S2_A90DocOperadorEliminacao = new bool[] {false} ;
         H005S2_A89DocOperadorCompartilhamento = new bool[] {false} ;
         H005S2_A88DocOperadorRetencao = new bool[] {false} ;
         H005S2_A87DocOperadorColeta = new bool[] {false} ;
         H005S2_A42OperadorId = new int[1] ;
         H005S2_A75DocumentoId = new int[1] ;
         H005S2_A86DocOperadorId = new int[1] ;
         H005S3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV54AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         GXt_char3 = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperadorww__default(),
            new Object[][] {
                new Object[] {
               H005S2_A92DocOperadorDataInclusao, H005S2_A91DocOperadorProcessamento, H005S2_A90DocOperadorEliminacao, H005S2_A89DocOperadorCompartilhamento, H005S2_A88DocOperadorRetencao, H005S2_A87DocOperadorColeta, H005S2_A42OperadorId, H005S2_A75DocumentoId, H005S2_A86DocOperadorId
               }
               , new Object[] {
               H005S3_AGRID_nRecordCount
               }
            }
         );
         AV58Pgmname = "DocOperadorWW";
         /* GeneXus formulas. */
         AV58Pgmname = "DocOperadorWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV33TFDocOperadorColeta_Sel ;
      private short AV34TFDocOperadorRetencao_Sel ;
      private short AV35TFDocOperadorCompartilhamento_Sel ;
      private short AV36TFDocOperadorEliminacao_Sel ;
      private short AV37TFDocOperadorProcessamento_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel ;
      private short AV67Docoperadorwwds_9_tfdocoperadorretencao_sel ;
      private short AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ;
      private short AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel ;
      private short AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int AV27TFDocOperadorId ;
      private int AV28TFDocOperadorId_To ;
      private int AV29TFDocumentoId ;
      private int AV30TFDocumentoId_To ;
      private int AV31TFOperadorId ;
      private int AV32TFOperadorId_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int A86DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV60Docoperadorwwds_2_tfdocoperadorid ;
      private int AV61Docoperadorwwds_3_tfdocoperadorid_to ;
      private int AV62Docoperadorwwds_4_tfdocumentoid ;
      private int AV63Docoperadorwwds_5_tfdocumentoid_to ;
      private int AV64Docoperadorwwds_6_tfoperadorid ;
      private int AV65Docoperadorwwds_7_tfoperadorid_to ;
      private int edtDocOperadorId_Visible ;
      private int edtDocumentoId_Visible ;
      private int edtOperadorId_Visible ;
      private int edtDocOperadorDataInclusao_Visible ;
      private int AV44PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV73GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV45GridCurrentPage ;
      private long AV46GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV58Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_docoperadordatainclusaoauxdates_Internalname ;
      private string edtavDdo_docoperadordatainclusaoauxdatetext_Internalname ;
      private string edtavDdo_docoperadordatainclusaoauxdatetext_Jsonclick ;
      private string Tfdocoperadordatainclusao_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV48Update ;
      private string edtavUpdate_Internalname ;
      private string AV50Delete ;
      private string edtavDelete_Internalname ;
      private string edtDocOperadorId_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtOperadorId_Internalname ;
      private string chkDocOperadorColeta_Internalname ;
      private string chkDocOperadorRetencao_Internalname ;
      private string chkDocOperadorCompartilhamento_Internalname ;
      private string chkDocOperadorEliminacao_Internalname ;
      private string chkDocOperadorProcessamento_Internalname ;
      private string edtDocOperadorDataInclusao_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtavDelete_Link ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtDocOperadorId_Jsonclick ;
      private string edtDocumentoId_Jsonclick ;
      private string edtOperadorId_Jsonclick ;
      private string GXCCtl ;
      private string edtDocOperadorDataInclusao_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV38TFDocOperadorDataInclusao ;
      private DateTime AV39TFDocOperadorDataInclusao_To ;
      private DateTime AV41DDO_DocOperadorDataInclusaoAuxDateTo ;
      private DateTime AV40DDO_DocOperadorDataInclusaoAuxDate ;
      private DateTime A92DocOperadorDataInclusao ;
      private DateTime AV71Docoperadorwwds_13_tfdocoperadordatainclusao ;
      private DateTime AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV49IsAuthorized_Update ;
      private bool AV51IsAuthorized_Delete ;
      private bool AV55IsAuthorized_Insert ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV52IsAuthorized_DocOperadorColeta ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV47GridAppliedFilters ;
      private string AV42DDO_DocOperadorDataInclusaoAuxDateText ;
      private string lV59Docoperadorwwds_1_filterfulltext ;
      private string AV59Docoperadorwwds_1_filterfulltext ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfdocoperadordatainclusao_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkDocOperadorColeta ;
      private GXCheckbox chkDocOperadorRetencao ;
      private GXCheckbox chkDocOperadorCompartilhamento ;
      private GXCheckbox chkDocOperadorEliminacao ;
      private GXCheckbox chkDocOperadorProcessamento ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H005S2_A92DocOperadorDataInclusao ;
      private bool[] H005S2_A91DocOperadorProcessamento ;
      private bool[] H005S2_A90DocOperadorEliminacao ;
      private bool[] H005S2_A89DocOperadorCompartilhamento ;
      private bool[] H005S2_A88DocOperadorRetencao ;
      private bool[] H005S2_A87DocOperadorColeta ;
      private int[] H005S2_A42OperadorId ;
      private int[] H005S2_A75DocumentoId ;
      private int[] H005S2_A86DocOperadorId ;
      private long[] H005S3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV53AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV54AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV43DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
   }

   public class docoperadorww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005S2( IGxContext context ,
                                             string AV59Docoperadorwwds_1_filterfulltext ,
                                             int AV60Docoperadorwwds_2_tfdocoperadorid ,
                                             int AV61Docoperadorwwds_3_tfdocoperadorid_to ,
                                             int AV62Docoperadorwwds_4_tfdocumentoid ,
                                             int AV63Docoperadorwwds_5_tfdocumentoid_to ,
                                             int AV64Docoperadorwwds_6_tfoperadorid ,
                                             int AV65Docoperadorwwds_7_tfoperadorid_to ,
                                             short AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                             short AV67Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                             short AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                             short AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                             short AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                             DateTime AV71Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                             DateTime AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                             int A86DocOperadorId ,
                                             int A75DocumentoId ,
                                             int A42OperadorId ,
                                             bool A87DocOperadorColeta ,
                                             bool A88DocOperadorRetencao ,
                                             bool A89DocOperadorCompartilhamento ,
                                             bool A90DocOperadorEliminacao ,
                                             bool A91DocOperadorProcessamento ,
                                             DateTime A92DocOperadorDataInclusao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DocOperadorDataInclusao], [DocOperadorProcessamento], [DocOperadorEliminacao], [DocOperadorCompartilhamento], [DocOperadorRetencao], [DocOperadorColeta], [OperadorId], [DocumentoId], [DocOperadorId]";
         sFromString = " FROM [DocOperador]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([DocOperadorId] AS decimal(8,0))) like '%' + @lV59Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV59Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([OperadorId] AS decimal(8,0))) like '%' + @lV59Docoperadorwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV60Docoperadorwwds_2_tfdocoperadorid) )
         {
            AddWhere(sWhereString, "([DocOperadorId] >= @AV60Docoperadorwwds_2_tfdocoperadorid)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV61Docoperadorwwds_3_tfdocoperadorid_to) )
         {
            AddWhere(sWhereString, "([DocOperadorId] <= @AV61Docoperadorwwds_3_tfdocoperadorid_to)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV62Docoperadorwwds_4_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV62Docoperadorwwds_4_tfdocumentoid)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV63Docoperadorwwds_5_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV63Docoperadorwwds_5_tfdocumentoid_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV64Docoperadorwwds_6_tfoperadorid) )
         {
            AddWhere(sWhereString, "([OperadorId] >= @AV64Docoperadorwwds_6_tfoperadorid)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV65Docoperadorwwds_7_tfoperadorid_to) )
         {
            AddWhere(sWhereString, "([OperadorId] <= @AV65Docoperadorwwds_7_tfoperadorid_to)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 1)");
         }
         if ( AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 0)");
         }
         if ( AV67Docoperadorwwds_9_tfdocoperadorretencao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 1)");
         }
         if ( AV67Docoperadorwwds_9_tfdocoperadorretencao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 0)");
         }
         if ( AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 1)");
         }
         if ( AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 0)");
         }
         if ( AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 1)");
         }
         if ( AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 0)");
         }
         if ( AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 1)");
         }
         if ( AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 0)");
         }
         if ( ! (DateTime.MinValue==AV71Docoperadorwwds_13_tfdocoperadordatainclusao) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] >= @AV71Docoperadorwwds_13_tfdocoperadordatainclusao)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] <= @AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorColeta]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorColeta] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorId]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorId] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocumentoId]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocumentoId] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [OperadorId]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [OperadorId] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorRetencao]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorRetencao] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorCompartilhamento]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorCompartilhamento] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorEliminacao]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorEliminacao] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorProcessamento]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorProcessamento] DESC";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocOperadorDataInclusao]";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocOperadorDataInclusao] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [DocOperadorId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H005S3( IGxContext context ,
                                             string AV59Docoperadorwwds_1_filterfulltext ,
                                             int AV60Docoperadorwwds_2_tfdocoperadorid ,
                                             int AV61Docoperadorwwds_3_tfdocoperadorid_to ,
                                             int AV62Docoperadorwwds_4_tfdocumentoid ,
                                             int AV63Docoperadorwwds_5_tfdocumentoid_to ,
                                             int AV64Docoperadorwwds_6_tfoperadorid ,
                                             int AV65Docoperadorwwds_7_tfoperadorid_to ,
                                             short AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                             short AV67Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                             short AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                             short AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                             short AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                             DateTime AV71Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                             DateTime AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                             int A86DocOperadorId ,
                                             int A75DocumentoId ,
                                             int A42OperadorId ,
                                             bool A87DocOperadorColeta ,
                                             bool A88DocOperadorRetencao ,
                                             bool A89DocOperadorCompartilhamento ,
                                             bool A90DocOperadorEliminacao ,
                                             bool A91DocOperadorProcessamento ,
                                             DateTime A92DocOperadorDataInclusao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[11];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [DocOperador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Docoperadorwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([DocOperadorId] AS decimal(8,0))) like '%' + @lV59Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV59Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([OperadorId] AS decimal(8,0))) like '%' + @lV59Docoperadorwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV60Docoperadorwwds_2_tfdocoperadorid) )
         {
            AddWhere(sWhereString, "([DocOperadorId] >= @AV60Docoperadorwwds_2_tfdocoperadorid)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV61Docoperadorwwds_3_tfdocoperadorid_to) )
         {
            AddWhere(sWhereString, "([DocOperadorId] <= @AV61Docoperadorwwds_3_tfdocoperadorid_to)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV62Docoperadorwwds_4_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV62Docoperadorwwds_4_tfdocumentoid)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV63Docoperadorwwds_5_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV63Docoperadorwwds_5_tfdocumentoid_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV64Docoperadorwwds_6_tfoperadorid) )
         {
            AddWhere(sWhereString, "([OperadorId] >= @AV64Docoperadorwwds_6_tfoperadorid)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV65Docoperadorwwds_7_tfoperadorid_to) )
         {
            AddWhere(sWhereString, "([OperadorId] <= @AV65Docoperadorwwds_7_tfoperadorid_to)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 1)");
         }
         if ( AV66Docoperadorwwds_8_tfdocoperadorcoleta_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 0)");
         }
         if ( AV67Docoperadorwwds_9_tfdocoperadorretencao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 1)");
         }
         if ( AV67Docoperadorwwds_9_tfdocoperadorretencao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 0)");
         }
         if ( AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 1)");
         }
         if ( AV68Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 0)");
         }
         if ( AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 1)");
         }
         if ( AV69Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 0)");
         }
         if ( AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 1)");
         }
         if ( AV70Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 0)");
         }
         if ( ! (DateTime.MinValue==AV71Docoperadorwwds_13_tfdocoperadordatainclusao) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] >= @AV71Docoperadorwwds_13_tfdocoperadordatainclusao)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] <= @AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005S2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_H005S3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005S2;
          prmH005S2 = new Object[] {
          new ParDef("@lV59Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV60Docoperadorwwds_2_tfdocoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV61Docoperadorwwds_3_tfdocoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV62Docoperadorwwds_4_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV63Docoperadorwwds_5_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV64Docoperadorwwds_6_tfoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV65Docoperadorwwds_7_tfoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV71Docoperadorwwds_13_tfdocoperadordatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005S3;
          prmH005S3 = new Object[] {
          new ParDef("@lV59Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV60Docoperadorwwds_2_tfdocoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV61Docoperadorwwds_3_tfdocoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV62Docoperadorwwds_4_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV63Docoperadorwwds_5_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV64Docoperadorwwds_6_tfoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV65Docoperadorwwds_7_tfoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV71Docoperadorwwds_13_tfdocoperadordatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV72Docoperadorwwds_14_tfdocoperadordatainclusao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
