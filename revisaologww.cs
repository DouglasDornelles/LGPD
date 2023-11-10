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
   public class revisaologww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public revisaologww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaologww( IGxContext context )
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
         AV59Pgmname = GetPar( "Pgmname");
         AV27TFRevisaoLogId = (int)(NumberUtil.Val( GetPar( "TFRevisaoLogId"), "."));
         AV28TFRevisaoLogId_To = (int)(NumberUtil.Val( GetPar( "TFRevisaoLogId_To"), "."));
         AV29TFRevisaoLogUsuarioAlteracao = GetPar( "TFRevisaoLogUsuarioAlteracao");
         AV30TFRevisaoLogUsuarioAlteracao_Sel = GetPar( "TFRevisaoLogUsuarioAlteracao_Sel");
         AV31TFRevisaoLogObservacao = GetPar( "TFRevisaoLogObservacao");
         AV32TFRevisaoLogObservacao_Sel = GetPar( "TFRevisaoLogObservacao_Sel");
         AV33TFRevisaoLogDataAlteracao = context.localUtil.ParseDTimeParm( GetPar( "TFRevisaoLogDataAlteracao"));
         AV34TFRevisaoLogDataAlteracao_To = context.localUtil.ParseDTimeParm( GetPar( "TFRevisaoLogDataAlteracao_To"));
         AV38TFDocumentoId = (int)(NumberUtil.Val( GetPar( "TFDocumentoId"), "."));
         AV39TFDocumentoId_To = (int)(NumberUtil.Val( GetPar( "TFDocumentoId_To"), "."));
         AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV48IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV55Insert_DocumentoId = (int)(NumberUtil.Val( GetPar( "Insert_DocumentoId"), "."));
         AV56IsInserido = StringUtil.StrToBool( GetPar( "IsInserido"));
         AV50IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV51IsAuthorized_RevisaoLogUsuarioAlteracao = StringUtil.StrToBool( GetPar( "IsAuthorized_RevisaoLogUsuarioAlteracao"));
         AV54IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV59Pgmname, AV27TFRevisaoLogId, AV28TFRevisaoLogId_To, AV29TFRevisaoLogUsuarioAlteracao, AV30TFRevisaoLogUsuarioAlteracao_Sel, AV31TFRevisaoLogObservacao, AV32TFRevisaoLogObservacao_Sel, AV33TFRevisaoLogDataAlteracao, AV34TFRevisaoLogDataAlteracao_To, AV38TFDocumentoId, AV39TFDocumentoId_To, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_Update, AV55Insert_DocumentoId, AV56IsInserido, AV50IsAuthorized_Delete, AV51IsAuthorized_RevisaoLogUsuarioAlteracao, AV54IsAuthorized_Insert) ;
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
            return "revisaologww_Execute" ;
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
         PA8P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8P2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("revisaologww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV55Insert_DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO", GetSecureSignedToken( "", AV51IsAuthorized_RevisaoLogUsuarioAlteracao, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV54IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV46GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV52AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV52AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_REVISAOLOGDATAALTERACAOAUXDATETO", context.localUtil.DToC( AV36DDO_RevisaoLogDataAlteracaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFRevisaoLogId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFRevisaoLogId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGUSUARIOALTERACAO", AV29TFRevisaoLogUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGUSUARIOALTERACAO_SEL", AV30TFRevisaoLogUsuarioAlteracao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGOBSERVACAO", AV31TFRevisaoLogObservacao);
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGOBSERVACAO_SEL", AV32TFRevisaoLogObservacao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGDATAALTERACAO", context.localUtil.TToC( AV33TFRevisaoLogDataAlteracao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFREVISAOLOGDATAALTERACAO_TO", context.localUtil.TToC( AV34TFRevisaoLogDataAlteracao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TFDocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TFDocumentoId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55Insert_DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV55Insert_DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISINSERIDO", AV56IsInserido);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO", AV51IsAuthorized_RevisaoLogUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO", GetSecureSignedToken( "", AV51IsAuthorized_RevisaoLogUsuarioAlteracao, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV54IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV54IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_REVISAOLOGDATAALTERACAOAUXDATE", context.localUtil.DToC( AV35DDO_RevisaoLogDataAlteracaoAuxDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE8P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8P2( ) ;
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
         return formatLink("revisaologww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "RevisaoLogWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Revisao Log" ;
      }

      protected void WB8P0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoLogWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoLogWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoLogWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table1_25_8P2( true) ;
         }
         else
         {
            wb_table1_25_8P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_8P2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV44GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV45GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV46GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV52AGExportData);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_revisaologdataalteracaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_revisaologdataalteracaoauxdatetext_Internalname, AV37DDO_RevisaoLogDataAlteracaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV37DDO_RevisaoLogDataAlteracaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_revisaologdataalteracaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RevisaoLogWW.htm");
            /* User Defined Control */
            ucTfrevisaologdataalteracao_rangepicker.SetProperty("Start Date", AV35DDO_RevisaoLogDataAlteracaoAuxDate);
            ucTfrevisaologdataalteracao_rangepicker.SetProperty("End Date", AV36DDO_RevisaoLogDataAlteracaoAuxDateTo);
            ucTfrevisaologdataalteracao_rangepicker.Render(context, "wwp.daterangepicker", Tfrevisaologdataalteracao_rangepicker_Internalname, "TFREVISAOLOGDATAALTERACAO_RANGEPICKERContainer");
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

      protected void START8P2( )
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
            Form.Meta.addItem("description", " Revisao Log", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8P0( ) ;
      }

      protected void WS8P2( )
      {
         START8P2( ) ;
         EVT8P2( ) ;
      }

      protected void EVT8P2( )
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
                              E118P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E128P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E138P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E148P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E158P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E168P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E178P2 ();
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
                              AV47Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV47Update);
                              AV49Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV49Delete);
                              A120RevisaoLogId = (int)(context.localUtil.CToN( cgiGet( edtRevisaoLogId_Internalname), ",", "."));
                              A121RevisaoLogUsuarioAlteracao = cgiGet( edtRevisaoLogUsuarioAlteracao_Internalname);
                              A122RevisaoLogObservacao = cgiGet( edtRevisaoLogObservacao_Internalname);
                              A123RevisaoLogDataAlteracao = context.localUtil.CToT( cgiGet( edtRevisaoLogDataAlteracao_Internalname), 0);
                              A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E188P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E198P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E208P2 ();
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

      protected void WE8P2( )
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

      protected void PA8P2( )
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
                                       string AV59Pgmname ,
                                       int AV27TFRevisaoLogId ,
                                       int AV28TFRevisaoLogId_To ,
                                       string AV29TFRevisaoLogUsuarioAlteracao ,
                                       string AV30TFRevisaoLogUsuarioAlteracao_Sel ,
                                       string AV31TFRevisaoLogObservacao ,
                                       string AV32TFRevisaoLogObservacao_Sel ,
                                       DateTime AV33TFRevisaoLogDataAlteracao ,
                                       DateTime AV34TFRevisaoLogDataAlteracao_To ,
                                       int AV38TFDocumentoId ,
                                       int AV39TFDocumentoId_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV48IsAuthorized_Update ,
                                       int AV55Insert_DocumentoId ,
                                       bool AV56IsInserido ,
                                       bool AV50IsAuthorized_Delete ,
                                       bool AV51IsAuthorized_RevisaoLogUsuarioAlteracao ,
                                       bool AV54IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E198P2 ();
         GRID_nCurrentRecord = 0;
         RF8P2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_REVISAOLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "REVISAOLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A120RevisaoLogId), 8, 0, ".", "")));
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
         RF8P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV59Pgmname = "RevisaoLogWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void RF8P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E198P2 ();
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
                                                 AV60Revisaologwwds_1_filterfulltext ,
                                                 AV61Revisaologwwds_2_tfrevisaologid ,
                                                 AV62Revisaologwwds_3_tfrevisaologid_to ,
                                                 AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                                 AV63Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                                 AV66Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                                 AV65Revisaologwwds_6_tfrevisaologobservacao ,
                                                 AV67Revisaologwwds_8_tfrevisaologdataalteracao ,
                                                 AV68Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                                 AV69Revisaologwwds_10_tfdocumentoid ,
                                                 AV70Revisaologwwds_11_tfdocumentoid_to ,
                                                 A120RevisaoLogId ,
                                                 A121RevisaoLogUsuarioAlteracao ,
                                                 A122RevisaoLogObservacao ,
                                                 A75DocumentoId ,
                                                 A123RevisaoLogDataAlteracao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
            lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
            lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
            lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
            lV63Revisaologwwds_4_tfrevisaologusuarioalteracao = StringUtil.Concat( StringUtil.RTrim( AV63Revisaologwwds_4_tfrevisaologusuarioalteracao), "%", "");
            lV65Revisaologwwds_6_tfrevisaologobservacao = StringUtil.Concat( StringUtil.RTrim( AV65Revisaologwwds_6_tfrevisaologobservacao), "%", "");
            /* Using cursor H008P2 */
            pr_default.execute(0, new Object[] {lV60Revisaologwwds_1_filterfulltext, lV60Revisaologwwds_1_filterfulltext, lV60Revisaologwwds_1_filterfulltext, lV60Revisaologwwds_1_filterfulltext, AV61Revisaologwwds_2_tfrevisaologid, AV62Revisaologwwds_3_tfrevisaologid_to, lV63Revisaologwwds_4_tfrevisaologusuarioalteracao, AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, lV65Revisaologwwds_6_tfrevisaologobservacao, AV66Revisaologwwds_7_tfrevisaologobservacao_sel, AV67Revisaologwwds_8_tfrevisaologdataalteracao, AV68Revisaologwwds_9_tfrevisaologdataalteracao_to, AV69Revisaologwwds_10_tfdocumentoid, AV70Revisaologwwds_11_tfdocumentoid_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A75DocumentoId = H008P2_A75DocumentoId[0];
               A123RevisaoLogDataAlteracao = H008P2_A123RevisaoLogDataAlteracao[0];
               A122RevisaoLogObservacao = H008P2_A122RevisaoLogObservacao[0];
               A121RevisaoLogUsuarioAlteracao = H008P2_A121RevisaoLogUsuarioAlteracao[0];
               A120RevisaoLogId = H008P2_A120RevisaoLogId[0];
               E208P2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 43;
            WB8P0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8P2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55Insert_DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV55Insert_DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO", AV51IsAuthorized_RevisaoLogUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO", GetSecureSignedToken( "", AV51IsAuthorized_RevisaoLogUsuarioAlteracao, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV54IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV54IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_REVISAOLOGID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9"), context));
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
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60Revisaologwwds_1_filterfulltext ,
                                              AV61Revisaologwwds_2_tfrevisaologid ,
                                              AV62Revisaologwwds_3_tfrevisaologid_to ,
                                              AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                              AV63Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                              AV66Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                              AV65Revisaologwwds_6_tfrevisaologobservacao ,
                                              AV67Revisaologwwds_8_tfrevisaologdataalteracao ,
                                              AV68Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                              AV69Revisaologwwds_10_tfdocumentoid ,
                                              AV70Revisaologwwds_11_tfdocumentoid_to ,
                                              A120RevisaoLogId ,
                                              A121RevisaoLogUsuarioAlteracao ,
                                              A122RevisaoLogObservacao ,
                                              A75DocumentoId ,
                                              A123RevisaoLogDataAlteracao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
         lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
         lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
         lV60Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext), "%", "");
         lV63Revisaologwwds_4_tfrevisaologusuarioalteracao = StringUtil.Concat( StringUtil.RTrim( AV63Revisaologwwds_4_tfrevisaologusuarioalteracao), "%", "");
         lV65Revisaologwwds_6_tfrevisaologobservacao = StringUtil.Concat( StringUtil.RTrim( AV65Revisaologwwds_6_tfrevisaologobservacao), "%", "");
         /* Using cursor H008P3 */
         pr_default.execute(1, new Object[] {lV60Revisaologwwds_1_filterfulltext, lV60Revisaologwwds_1_filterfulltext, lV60Revisaologwwds_1_filterfulltext, lV60Revisaologwwds_1_filterfulltext, AV61Revisaologwwds_2_tfrevisaologid, AV62Revisaologwwds_3_tfrevisaologid_to, lV63Revisaologwwds_4_tfrevisaologusuarioalteracao, AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, lV65Revisaologwwds_6_tfrevisaologobservacao, AV66Revisaologwwds_7_tfrevisaologobservacao_sel, AV67Revisaologwwds_8_tfrevisaologdataalteracao, AV68Revisaologwwds_9_tfrevisaologdataalteracao_to, AV69Revisaologwwds_10_tfdocumentoid, AV70Revisaologwwds_11_tfdocumentoid_to});
         GRID_nRecordCount = H008P3_AGRID_nRecordCount[0];
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
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV59Pgmname, AV27TFRevisaoLogId, AV28TFRevisaoLogId_To, AV29TFRevisaoLogUsuarioAlteracao, AV30TFRevisaoLogUsuarioAlteracao_Sel, AV31TFRevisaoLogObservacao, AV32TFRevisaoLogObservacao_Sel, AV33TFRevisaoLogDataAlteracao, AV34TFRevisaoLogDataAlteracao_To, AV38TFDocumentoId, AV39TFDocumentoId_To, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_Update, AV55Insert_DocumentoId, AV56IsInserido, AV50IsAuthorized_Delete, AV51IsAuthorized_RevisaoLogUsuarioAlteracao, AV54IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV59Pgmname, AV27TFRevisaoLogId, AV28TFRevisaoLogId_To, AV29TFRevisaoLogUsuarioAlteracao, AV30TFRevisaoLogUsuarioAlteracao_Sel, AV31TFRevisaoLogObservacao, AV32TFRevisaoLogObservacao_Sel, AV33TFRevisaoLogDataAlteracao, AV34TFRevisaoLogDataAlteracao_To, AV38TFDocumentoId, AV39TFDocumentoId_To, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_Update, AV55Insert_DocumentoId, AV56IsInserido, AV50IsAuthorized_Delete, AV51IsAuthorized_RevisaoLogUsuarioAlteracao, AV54IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV59Pgmname, AV27TFRevisaoLogId, AV28TFRevisaoLogId_To, AV29TFRevisaoLogUsuarioAlteracao, AV30TFRevisaoLogUsuarioAlteracao_Sel, AV31TFRevisaoLogObservacao, AV32TFRevisaoLogObservacao_Sel, AV33TFRevisaoLogDataAlteracao, AV34TFRevisaoLogDataAlteracao_To, AV38TFDocumentoId, AV39TFDocumentoId_To, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_Update, AV55Insert_DocumentoId, AV56IsInserido, AV50IsAuthorized_Delete, AV51IsAuthorized_RevisaoLogUsuarioAlteracao, AV54IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV59Pgmname, AV27TFRevisaoLogId, AV28TFRevisaoLogId_To, AV29TFRevisaoLogUsuarioAlteracao, AV30TFRevisaoLogUsuarioAlteracao_Sel, AV31TFRevisaoLogObservacao, AV32TFRevisaoLogObservacao_Sel, AV33TFRevisaoLogDataAlteracao, AV34TFRevisaoLogDataAlteracao_To, AV38TFDocumentoId, AV39TFDocumentoId_To, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_Update, AV55Insert_DocumentoId, AV56IsInserido, AV50IsAuthorized_Delete, AV51IsAuthorized_RevisaoLogUsuarioAlteracao, AV54IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV59Pgmname, AV27TFRevisaoLogId, AV28TFRevisaoLogId_To, AV29TFRevisaoLogUsuarioAlteracao, AV30TFRevisaoLogUsuarioAlteracao_Sel, AV31TFRevisaoLogObservacao, AV32TFRevisaoLogObservacao_Sel, AV33TFRevisaoLogDataAlteracao, AV34TFRevisaoLogDataAlteracao_To, AV38TFDocumentoId, AV39TFDocumentoId_To, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_Update, AV55Insert_DocumentoId, AV56IsInserido, AV50IsAuthorized_Delete, AV51IsAuthorized_RevisaoLogUsuarioAlteracao, AV54IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV59Pgmname = "RevisaoLogWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E188P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV52AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV40DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ",", "."));
            AV44GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV45GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV46GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV35DDO_RevisaoLogDataAlteracaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_REVISAOLOGDATAALTERACAOAUXDATE"), 0);
            AV36DDO_RevisaoLogDataAlteracaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_REVISAOLOGDATAALTERACAOAUXDATETO"), 0);
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
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
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
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
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
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            AV37DDO_RevisaoLogDataAlteracaoAuxDateText = cgiGet( edtavDdo_revisaologdataalteracaoauxdatetext_Internalname);
            AssignAttri("", false, "AV37DDO_RevisaoLogDataAlteracaoAuxDateText", AV37DDO_RevisaoLogDataAlteracaoAuxDateText);
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
         E188P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E188P2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFREVISAOLOGDATAALTERACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_revisaologdataalteracaoauxdatetext_Internalname});
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
         AV52AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV53AGExportDataItem.gxTpr_Title = "Excel";
         AV53AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV53AGExportDataItem.gxTpr_Eventkey = "Export";
         AV53AGExportDataItem.gxTpr_Isdivider = false;
         AV52AGExportData.Add(AV53AGExportDataItem, 0);
         AV53AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV53AGExportDataItem.gxTpr_Title = "PDF";
         AV53AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV53AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV53AGExportDataItem.gxTpr_Isdivider = false;
         AV52AGExportData.Add(AV53AGExportDataItem, 0);
         GXt_boolean1 = AV51IsAuthorized_RevisaoLogUsuarioAlteracao;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "revisaologview_Execute", out  GXt_boolean1) ;
         AV51IsAuthorized_RevisaoLogUsuarioAlteracao = GXt_boolean1;
         AssignAttri("", false, "AV51IsAuthorized_RevisaoLogUsuarioAlteracao", AV51IsAuthorized_RevisaoLogUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO", GetSecureSignedToken( "", AV51IsAuthorized_RevisaoLogUsuarioAlteracao, context));
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV42GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV41GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Revisao Log";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV40DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV40DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E198P2( )
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
         if ( StringUtil.StrCmp(AV23Session.Get("RevisaoLogWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("RevisaoLogWWColumnsSelector");
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
         edtRevisaoLogId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRevisaoLogId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtRevisaoLogUsuarioAlteracao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRevisaoLogUsuarioAlteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogUsuarioAlteracao_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtRevisaoLogObservacao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRevisaoLogObservacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogObservacao_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtRevisaoLogDataAlteracao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRevisaoLogDataAlteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogDataAlteracao_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtDocumentoId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV44GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV44GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV44GridCurrentPage), 10, 0));
         AV45GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV45GridPageCount", StringUtil.LTrimStr( (decimal)(AV45GridPageCount), 10, 0));
         GXt_char3 = AV46GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV59Pgmname, out  GXt_char3) ;
         AV46GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         AV60Revisaologwwds_1_filterfulltext = AV16FilterFullText;
         AV61Revisaologwwds_2_tfrevisaologid = AV27TFRevisaoLogId;
         AV62Revisaologwwds_3_tfrevisaologid_to = AV28TFRevisaoLogId_To;
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = AV29TFRevisaoLogUsuarioAlteracao;
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV30TFRevisaoLogUsuarioAlteracao_Sel;
         AV65Revisaologwwds_6_tfrevisaologobservacao = AV31TFRevisaoLogObservacao;
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = AV32TFRevisaoLogObservacao_Sel;
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = AV33TFRevisaoLogDataAlteracao;
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = AV34TFRevisaoLogDataAlteracao_To;
         AV69Revisaologwwds_10_tfdocumentoid = AV38TFDocumentoId;
         AV70Revisaologwwds_11_tfdocumentoid_to = AV39TFDocumentoId_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E128P2( )
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
            AV43PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV43PageToGo) ;
         }
      }

      protected void E138P2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E158P2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RevisaoLogId") == 0 )
            {
               AV27TFRevisaoLogId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV27TFRevisaoLogId", StringUtil.LTrimStr( (decimal)(AV27TFRevisaoLogId), 8, 0));
               AV28TFRevisaoLogId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV28TFRevisaoLogId_To", StringUtil.LTrimStr( (decimal)(AV28TFRevisaoLogId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RevisaoLogUsuarioAlteracao") == 0 )
            {
               AV29TFRevisaoLogUsuarioAlteracao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFRevisaoLogUsuarioAlteracao", AV29TFRevisaoLogUsuarioAlteracao);
               AV30TFRevisaoLogUsuarioAlteracao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFRevisaoLogUsuarioAlteracao_Sel", AV30TFRevisaoLogUsuarioAlteracao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RevisaoLogObservacao") == 0 )
            {
               AV31TFRevisaoLogObservacao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFRevisaoLogObservacao", AV31TFRevisaoLogObservacao);
               AV32TFRevisaoLogObservacao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFRevisaoLogObservacao_Sel", AV32TFRevisaoLogObservacao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RevisaoLogDataAlteracao") == 0 )
            {
               AV33TFRevisaoLogDataAlteracao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV33TFRevisaoLogDataAlteracao", context.localUtil.TToC( AV33TFRevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
               AV34TFRevisaoLogDataAlteracao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV34TFRevisaoLogDataAlteracao_To", context.localUtil.TToC( AV34TFRevisaoLogDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV34TFRevisaoLogDataAlteracao_To) )
               {
                  AV34TFRevisaoLogDataAlteracao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV34TFRevisaoLogDataAlteracao_To)), (short)(DateTimeUtil.Month( AV34TFRevisaoLogDataAlteracao_To)), (short)(DateTimeUtil.Day( AV34TFRevisaoLogDataAlteracao_To)), 23, 59, 59);
                  AssignAttri("", false, "AV34TFRevisaoLogDataAlteracao_To", context.localUtil.TToC( AV34TFRevisaoLogDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoId") == 0 )
            {
               AV38TFDocumentoId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV38TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV38TFDocumentoId), 8, 0));
               AV39TFDocumentoId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV39TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV39TFDocumentoId_To), 8, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E208P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV47Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV47Update);
         if ( AV48IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "revisaolog.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A120RevisaoLogId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV55Insert_DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV56IsInserido));
            edtavUpdate_Link = formatLink("revisaolog.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV49Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV49Delete);
         if ( AV50IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "revisaolog.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A120RevisaoLogId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV55Insert_DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV56IsInserido));
            edtavDelete_Link = formatLink("revisaolog.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV51IsAuthorized_RevisaoLogUsuarioAlteracao )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "revisaologview.aspx"+UrlEncode(StringUtil.LTrimStr(A120RevisaoLogId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtRevisaoLogUsuarioAlteracao_Link = formatLink("revisaologview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E168P2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "RevisaoLogWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E118P2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("RevisaoLogWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV59Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("RevisaoLogWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "RevisaoLogWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV59Pgmname+"GridState",  AV25ManageFiltersXml) ;
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

      protected void E178P2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV54IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "revisaolog.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV55Insert_DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV56IsInserido));
            CallWebObject(formatLink("revisaolog.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E148P2( )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "RevisaoLogId",  "",  "Log Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "RevisaoLogUsuarioAlteracao",  "",  "Usuario Alteracao",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "RevisaoLogObservacao",  "",  "Log Observacao",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "RevisaoLogDataAlteracao",  "",  "Data Alteracao",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocumentoId",  "",  "do Documento",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "RevisaoLogWWColumnsSelector", out  GXt_char3) ;
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
         GXt_boolean1 = AV48IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "revisaolog_Update", out  GXt_boolean1) ;
         AV48IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV48IsAuthorized_Update", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         if ( ! ( AV48IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean1 = AV50IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "revisaolog_Delete", out  GXt_boolean1) ;
         AV50IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_Delete", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         if ( ! ( AV50IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean1 = AV54IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "revisaolog_Insert", out  GXt_boolean1) ;
         AV54IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV54IsAuthorized_Insert", AV54IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV54IsAuthorized_Insert, context));
         if ( ! ( AV54IsAuthorized_Insert ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "RevisaoLogWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFRevisaoLogId = 0;
         AssignAttri("", false, "AV27TFRevisaoLogId", StringUtil.LTrimStr( (decimal)(AV27TFRevisaoLogId), 8, 0));
         AV28TFRevisaoLogId_To = 0;
         AssignAttri("", false, "AV28TFRevisaoLogId_To", StringUtil.LTrimStr( (decimal)(AV28TFRevisaoLogId_To), 8, 0));
         AV29TFRevisaoLogUsuarioAlteracao = "";
         AssignAttri("", false, "AV29TFRevisaoLogUsuarioAlteracao", AV29TFRevisaoLogUsuarioAlteracao);
         AV30TFRevisaoLogUsuarioAlteracao_Sel = "";
         AssignAttri("", false, "AV30TFRevisaoLogUsuarioAlteracao_Sel", AV30TFRevisaoLogUsuarioAlteracao_Sel);
         AV31TFRevisaoLogObservacao = "";
         AssignAttri("", false, "AV31TFRevisaoLogObservacao", AV31TFRevisaoLogObservacao);
         AV32TFRevisaoLogObservacao_Sel = "";
         AssignAttri("", false, "AV32TFRevisaoLogObservacao_Sel", AV32TFRevisaoLogObservacao_Sel);
         AV33TFRevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV33TFRevisaoLogDataAlteracao", context.localUtil.TToC( AV33TFRevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
         AV34TFRevisaoLogDataAlteracao_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV34TFRevisaoLogDataAlteracao_To", context.localUtil.TToC( AV34TFRevisaoLogDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
         AV38TFDocumentoId = 0;
         AssignAttri("", false, "AV38TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV38TFDocumentoId), 8, 0));
         AV39TFDocumentoId_To = 0;
         AssignAttri("", false, "AV39TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV39TFDocumentoId_To), 8, 0));
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
         if ( StringUtil.StrCmp(AV23Session.Get(AV59Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV59Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV59Pgmname+"GridState"), null, "", "");
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
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGID") == 0 )
            {
               AV27TFRevisaoLogId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV27TFRevisaoLogId", StringUtil.LTrimStr( (decimal)(AV27TFRevisaoLogId), 8, 0));
               AV28TFRevisaoLogId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV28TFRevisaoLogId_To", StringUtil.LTrimStr( (decimal)(AV28TFRevisaoLogId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO") == 0 )
            {
               AV29TFRevisaoLogUsuarioAlteracao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFRevisaoLogUsuarioAlteracao", AV29TFRevisaoLogUsuarioAlteracao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO_SEL") == 0 )
            {
               AV30TFRevisaoLogUsuarioAlteracao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFRevisaoLogUsuarioAlteracao_Sel", AV30TFRevisaoLogUsuarioAlteracao_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO") == 0 )
            {
               AV31TFRevisaoLogObservacao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFRevisaoLogObservacao", AV31TFRevisaoLogObservacao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO_SEL") == 0 )
            {
               AV32TFRevisaoLogObservacao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFRevisaoLogObservacao_Sel", AV32TFRevisaoLogObservacao_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGDATAALTERACAO") == 0 )
            {
               AV33TFRevisaoLogDataAlteracao = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV33TFRevisaoLogDataAlteracao", context.localUtil.TToC( AV33TFRevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
               AV34TFRevisaoLogDataAlteracao_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV34TFRevisaoLogDataAlteracao_To", context.localUtil.TToC( AV34TFRevisaoLogDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
               AV35DDO_RevisaoLogDataAlteracaoAuxDate = DateTimeUtil.ResetTime(AV33TFRevisaoLogDataAlteracao);
               AssignAttri("", false, "AV35DDO_RevisaoLogDataAlteracaoAuxDate", context.localUtil.Format(AV35DDO_RevisaoLogDataAlteracaoAuxDate, "99/99/99"));
               AV36DDO_RevisaoLogDataAlteracaoAuxDateTo = DateTimeUtil.ResetTime(AV34TFRevisaoLogDataAlteracao_To);
               AssignAttri("", false, "AV36DDO_RevisaoLogDataAlteracaoAuxDateTo", context.localUtil.Format(AV36DDO_RevisaoLogDataAlteracaoAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV38TFDocumentoId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV38TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV38TFDocumentoId), 8, 0));
               AV39TFDocumentoId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV39TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV39TFDocumentoId_To), 8, 0));
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFRevisaoLogUsuarioAlteracao_Sel)),  AV30TFRevisaoLogUsuarioAlteracao_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFRevisaoLogObservacao_Sel)),  AV32TFRevisaoLogObservacao_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFRevisaoLogUsuarioAlteracao)),  AV29TFRevisaoLogUsuarioAlteracao, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFRevisaoLogObservacao)),  AV31TFRevisaoLogObservacao, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV27TFRevisaoLogId) ? "" : StringUtil.Str( (decimal)(AV27TFRevisaoLogId), 8, 0))+"|"+GXt_char5+"|"+GXt_char3+"|"+((DateTime.MinValue==AV33TFRevisaoLogDataAlteracao) ? "" : context.localUtil.DToC( AV35DDO_RevisaoLogDataAlteracaoAuxDate, 2, "/"))+"|"+((0==AV38TFDocumentoId) ? "" : StringUtil.Str( (decimal)(AV38TFDocumentoId), 8, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV28TFRevisaoLogId_To) ? "" : StringUtil.Str( (decimal)(AV28TFRevisaoLogId_To), 8, 0))+"|||"+((DateTime.MinValue==AV34TFRevisaoLogDataAlteracao_To) ? "" : context.localUtil.DToC( AV36DDO_RevisaoLogDataAlteracaoAuxDateTo, 2, "/"))+"|"+((0==AV39TFDocumentoId_To) ? "" : StringUtil.Str( (decimal)(AV39TFDocumentoId_To), 8, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV59Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFREVISAOLOGID",  "Log Id",  !((0==AV27TFRevisaoLogId)&&(0==AV28TFRevisaoLogId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFRevisaoLogId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFRevisaoLogId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFREVISAOLOGUSUARIOALTERACAO",  "Usuario Alteracao",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFRevisaoLogUsuarioAlteracao)),  0,  AV29TFRevisaoLogUsuarioAlteracao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFRevisaoLogUsuarioAlteracao_Sel)),  AV30TFRevisaoLogUsuarioAlteracao_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFREVISAOLOGOBSERVACAO",  "Log Observacao",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFRevisaoLogObservacao)),  0,  AV31TFRevisaoLogObservacao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFRevisaoLogObservacao_Sel)),  AV32TFRevisaoLogObservacao_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFREVISAOLOGDATAALTERACAO",  "Data Alteracao",  !((DateTime.MinValue==AV33TFRevisaoLogDataAlteracao)&&(DateTime.MinValue==AV34TFRevisaoLogDataAlteracao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV33TFRevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV34TFRevisaoLogDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTOID",  "do Documento",  !((0==AV38TFDocumentoId)&&(0==AV39TFDocumentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFDocumentoId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV39TFDocumentoId_To), 8, 0))) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV59Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV59Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "RevisaoLog";
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
         new revisaologwwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("revisaologwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_8P2( bool wbgen )
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
            wb_table2_30_8P2( true) ;
         }
         else
         {
            wb_table2_30_8P2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_8P2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_8P2e( true) ;
         }
         else
         {
            wb_table1_25_8P2e( false) ;
         }
      }

      protected void wb_table2_30_8P2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_RevisaoLogWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_8P2e( true) ;
         }
         else
         {
            wb_table2_30_8P2e( false) ;
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
         PA8P2( ) ;
         WS8P2( ) ;
         WE8P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910515714", true, true);
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
         context.AddJavascriptSource("revisaologww.js", "?202311910515715", false, true);
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
         edtRevisaoLogId_Internalname = "REVISAOLOGID_"+sGXsfl_43_idx;
         edtRevisaoLogUsuarioAlteracao_Internalname = "REVISAOLOGUSUARIOALTERACAO_"+sGXsfl_43_idx;
         edtRevisaoLogObservacao_Internalname = "REVISAOLOGOBSERVACAO_"+sGXsfl_43_idx;
         edtRevisaoLogDataAlteracao_Internalname = "REVISAOLOGDATAALTERACAO_"+sGXsfl_43_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_fel_idx;
         edtRevisaoLogId_Internalname = "REVISAOLOGID_"+sGXsfl_43_fel_idx;
         edtRevisaoLogUsuarioAlteracao_Internalname = "REVISAOLOGUSUARIOALTERACAO_"+sGXsfl_43_fel_idx;
         edtRevisaoLogObservacao_Internalname = "REVISAOLOGOBSERVACAO_"+sGXsfl_43_fel_idx;
         edtRevisaoLogDataAlteracao_Internalname = "REVISAOLOGDATAALTERACAO_"+sGXsfl_43_fel_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         SubsflControlProps_432( ) ;
         WB8P0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV47Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV49Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtRevisaoLogId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRevisaoLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A120RevisaoLogId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRevisaoLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRevisaoLogId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtRevisaoLogUsuarioAlteracao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRevisaoLogUsuarioAlteracao_Internalname,(string)A121RevisaoLogUsuarioAlteracao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRevisaoLogUsuarioAlteracao_Link,(string)"",(string)"",(string)"",(string)edtRevisaoLogUsuarioAlteracao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRevisaoLogUsuarioAlteracao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtRevisaoLogObservacao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRevisaoLogObservacao_Internalname,(string)A122RevisaoLogObservacao,(string)A122RevisaoLogObservacao,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRevisaoLogObservacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRevisaoLogObservacao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)10000,(short)0,(short)0,(short)43,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtRevisaoLogDataAlteracao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRevisaoLogDataAlteracao_Internalname,context.localUtil.TToC( A123RevisaoLogDataAlteracao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A123RevisaoLogDataAlteracao, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRevisaoLogDataAlteracao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRevisaoLogDataAlteracao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocumentoId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocumentoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes8P2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRevisaoLogId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRevisaoLogUsuarioAlteracao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Usuario Alteracao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRevisaoLogObservacao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Observacao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRevisaoLogDataAlteracao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data Alteracao") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocumentoId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "do Documento") ;
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
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV47Update));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV49Delete));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A120RevisaoLogId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRevisaoLogId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A121RevisaoLogUsuarioAlteracao);
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtRevisaoLogUsuarioAlteracao_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRevisaoLogUsuarioAlteracao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A122RevisaoLogObservacao);
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRevisaoLogObservacao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 10, 8, 0, 3, "/", ":", " "));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRevisaoLogDataAlteracao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocumentoId_Visible), 5, 0, ".", "")));
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
         edtRevisaoLogId_Internalname = "REVISAOLOGID";
         edtRevisaoLogUsuarioAlteracao_Internalname = "REVISAOLOGUSUARIOALTERACAO";
         edtRevisaoLogObservacao_Internalname = "REVISAOLOGOBSERVACAO";
         edtRevisaoLogDataAlteracao_Internalname = "REVISAOLOGDATAALTERACAO";
         edtDocumentoId_Internalname = "DOCUMENTOID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_revisaologdataalteracaoauxdatetext_Internalname = "vDDO_REVISAOLOGDATAALTERACAOAUXDATETEXT";
         Tfrevisaologdataalteracao_rangepicker_Internalname = "TFREVISAOLOGDATAALTERACAO_RANGEPICKER";
         divDdo_revisaologdataalteracaoauxdates_Internalname = "DDO_REVISAOLOGDATAALTERACAOAUXDATES";
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
         edtDocumentoId_Jsonclick = "";
         edtRevisaoLogDataAlteracao_Jsonclick = "";
         edtRevisaoLogObservacao_Jsonclick = "";
         edtRevisaoLogUsuarioAlteracao_Jsonclick = "";
         edtRevisaoLogUsuarioAlteracao_Link = "";
         edtRevisaoLogId_Jsonclick = "";
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
         edtDocumentoId_Visible = -1;
         edtRevisaoLogDataAlteracao_Visible = -1;
         edtRevisaoLogObservacao_Visible = -1;
         edtRevisaoLogUsuarioAlteracao_Visible = -1;
         edtRevisaoLogId_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_revisaologdataalteracaoauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "8.0||||8.0";
         Ddo_grid_Datalistproc = "RevisaoLogWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "|T|T||";
         Ddo_grid_Filterisrange = "T|||P|T";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Date|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5";
         Ddo_grid_Columnids = "2:RevisaoLogId|3:RevisaoLogUsuarioAlteracao|4:RevisaoLogObservacao|5:RevisaoLogDataAlteracao|6:DocumentoId";
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
         Form.Caption = " Revisao Log";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRevisaoLogId_Visible',ctrl:'REVISAOLOGID',prop:'Visible'},{av:'edtRevisaoLogUsuarioAlteracao_Visible',ctrl:'REVISAOLOGUSUARIOALTERACAO',prop:'Visible'},{av:'edtRevisaoLogObservacao_Visible',ctrl:'REVISAOLOGOBSERVACAO',prop:'Visible'},{av:'edtRevisaoLogDataAlteracao_Visible',ctrl:'REVISAOLOGDATAALTERACAO',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E128P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E138P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E158P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E208P2',iparms:[{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV49Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtRevisaoLogUsuarioAlteracao_Link',ctrl:'REVISAOLOGUSUARIOALTERACAO',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E168P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtRevisaoLogId_Visible',ctrl:'REVISAOLOGID',prop:'Visible'},{av:'edtRevisaoLogUsuarioAlteracao_Visible',ctrl:'REVISAOLOGUSUARIOALTERACAO',prop:'Visible'},{av:'edtRevisaoLogObservacao_Visible',ctrl:'REVISAOLOGOBSERVACAO',prop:'Visible'},{av:'edtRevisaoLogDataAlteracao_Visible',ctrl:'REVISAOLOGDATAALTERACAO',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E118P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV35DDO_RevisaoLogDataAlteracaoAuxDate',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATE',pic:''},{av:'AV36DDO_RevisaoLogDataAlteracaoAuxDateTo',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATETO',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV35DDO_RevisaoLogDataAlteracaoAuxDate',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATE',pic:''},{av:'AV36DDO_RevisaoLogDataAlteracaoAuxDateTo',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATETO',pic:''},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRevisaoLogId_Visible',ctrl:'REVISAOLOGID',prop:'Visible'},{av:'edtRevisaoLogUsuarioAlteracao_Visible',ctrl:'REVISAOLOGUSUARIOALTERACAO',prop:'Visible'},{av:'edtRevisaoLogObservacao_Visible',ctrl:'REVISAOLOGOBSERVACAO',prop:'Visible'},{av:'edtRevisaoLogDataAlteracao_Visible',ctrl:'REVISAOLOGDATAALTERACAO',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E178P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRevisaoLogId_Visible',ctrl:'REVISAOLOGID',prop:'Visible'},{av:'edtRevisaoLogUsuarioAlteracao_Visible',ctrl:'REVISAOLOGUSUARIOALTERACAO',prop:'Visible'},{av:'edtRevisaoLogObservacao_Visible',ctrl:'REVISAOLOGOBSERVACAO',prop:'Visible'},{av:'edtRevisaoLogDataAlteracao_Visible',ctrl:'REVISAOLOGDATAALTERACAO',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E148P2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV35DDO_RevisaoLogDataAlteracaoAuxDate',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATE',pic:''},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV36DDO_RevisaoLogDataAlteracaoAuxDateTo',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATETO',pic:''},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFRevisaoLogId',fld:'vTFREVISAOLOGID',pic:'ZZZZZZZ9'},{av:'AV28TFRevisaoLogId_To',fld:'vTFREVISAOLOGID_TO',pic:'ZZZZZZZ9'},{av:'AV29TFRevisaoLogUsuarioAlteracao',fld:'vTFREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV30TFRevisaoLogUsuarioAlteracao_Sel',fld:'vTFREVISAOLOGUSUARIOALTERACAO_SEL',pic:''},{av:'AV31TFRevisaoLogObservacao',fld:'vTFREVISAOLOGOBSERVACAO',pic:''},{av:'AV32TFRevisaoLogObservacao_Sel',fld:'vTFREVISAOLOGOBSERVACAO_SEL',pic:''},{av:'AV33TFRevisaoLogDataAlteracao',fld:'vTFREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV34TFRevisaoLogDataAlteracao_To',fld:'vTFREVISAOLOGDATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'AV38TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV39TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV48IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV55Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56IsInserido',fld:'vISINSERIDO',pic:''},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV51IsAuthorized_RevisaoLogUsuarioAlteracao',fld:'vISAUTHORIZED_REVISAOLOGUSUARIOALTERACAO',pic:'',hsh:true},{av:'AV54IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV35DDO_RevisaoLogDataAlteracaoAuxDate',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATE',pic:''},{av:'AV36DDO_RevisaoLogDataAlteracaoAuxDateTo',fld:'vDDO_REVISAOLOGDATAALTERACAOAUXDATETO',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("NULL","{handler:'Valid_Documentoid',iparms:[]");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV59Pgmname = "";
         AV29TFRevisaoLogUsuarioAlteracao = "";
         AV30TFRevisaoLogUsuarioAlteracao_Sel = "";
         AV31TFRevisaoLogObservacao = "";
         AV32TFRevisaoLogObservacao_Sel = "";
         AV33TFRevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         AV34TFRevisaoLogDataAlteracao_To = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV52AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36DDO_RevisaoLogDataAlteracaoAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35DDO_RevisaoLogDataAlteracaoAuxDate = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
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
         AV37DDO_RevisaoLogDataAlteracaoAuxDateText = "";
         ucTfrevisaologdataalteracao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV47Update = "";
         AV49Delete = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A122RevisaoLogObservacao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV60Revisaologwwds_1_filterfulltext = "";
         lV63Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         lV65Revisaologwwds_6_tfrevisaologobservacao = "";
         AV60Revisaologwwds_1_filterfulltext = "";
         AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = "";
         AV63Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         AV66Revisaologwwds_7_tfrevisaologobservacao_sel = "";
         AV65Revisaologwwds_6_tfrevisaologobservacao = "";
         AV67Revisaologwwds_8_tfrevisaologdataalteracao = (DateTime)(DateTime.MinValue);
         AV68Revisaologwwds_9_tfrevisaologdataalteracao_to = (DateTime)(DateTime.MinValue);
         H008P2_A75DocumentoId = new int[1] ;
         H008P2_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H008P2_A122RevisaoLogObservacao = new string[] {""} ;
         H008P2_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         H008P2_A120RevisaoLogId = new int[1] ;
         H008P3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV53AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV42GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaologww__default(),
            new Object[][] {
                new Object[] {
               H008P2_A75DocumentoId, H008P2_A123RevisaoLogDataAlteracao, H008P2_A122RevisaoLogObservacao, H008P2_A121RevisaoLogUsuarioAlteracao, H008P2_A120RevisaoLogId
               }
               , new Object[] {
               H008P3_AGRID_nRecordCount
               }
            }
         );
         AV59Pgmname = "RevisaoLogWW";
         /* GeneXus formulas. */
         AV59Pgmname = "RevisaoLogWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
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
      private int AV27TFRevisaoLogId ;
      private int AV28TFRevisaoLogId_To ;
      private int AV38TFDocumentoId ;
      private int AV39TFDocumentoId_To ;
      private int AV55Insert_DocumentoId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int A120RevisaoLogId ;
      private int A75DocumentoId ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV61Revisaologwwds_2_tfrevisaologid ;
      private int AV62Revisaologwwds_3_tfrevisaologid_to ;
      private int AV69Revisaologwwds_10_tfdocumentoid ;
      private int AV70Revisaologwwds_11_tfdocumentoid_to ;
      private int edtRevisaoLogId_Visible ;
      private int edtRevisaoLogUsuarioAlteracao_Visible ;
      private int edtRevisaoLogObservacao_Visible ;
      private int edtRevisaoLogDataAlteracao_Visible ;
      private int edtDocumentoId_Visible ;
      private int AV43PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV71GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44GridCurrentPage ;
      private long AV45GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV59Pgmname ;
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
      private string Ddo_grid_Gamoauthtoken ;
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
      private string Ddo_grid_Datalistproc ;
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
      private string divDdo_revisaologdataalteracaoauxdates_Internalname ;
      private string edtavDdo_revisaologdataalteracaoauxdatetext_Internalname ;
      private string edtavDdo_revisaologdataalteracaoauxdatetext_Jsonclick ;
      private string Tfrevisaologdataalteracao_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV47Update ;
      private string edtavUpdate_Internalname ;
      private string AV49Delete ;
      private string edtavDelete_Internalname ;
      private string edtRevisaoLogId_Internalname ;
      private string edtRevisaoLogUsuarioAlteracao_Internalname ;
      private string edtRevisaoLogObservacao_Internalname ;
      private string edtRevisaoLogDataAlteracao_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtavDelete_Link ;
      private string edtRevisaoLogUsuarioAlteracao_Link ;
      private string GXt_char5 ;
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
      private string edtRevisaoLogId_Jsonclick ;
      private string edtRevisaoLogUsuarioAlteracao_Jsonclick ;
      private string edtRevisaoLogObservacao_Jsonclick ;
      private string edtRevisaoLogDataAlteracao_Jsonclick ;
      private string edtDocumentoId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV33TFRevisaoLogDataAlteracao ;
      private DateTime AV34TFRevisaoLogDataAlteracao_To ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private DateTime AV67Revisaologwwds_8_tfrevisaologdataalteracao ;
      private DateTime AV68Revisaologwwds_9_tfrevisaologdataalteracao_to ;
      private DateTime AV36DDO_RevisaoLogDataAlteracaoAuxDateTo ;
      private DateTime AV35DDO_RevisaoLogDataAlteracaoAuxDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV48IsAuthorized_Update ;
      private bool AV56IsInserido ;
      private bool AV50IsAuthorized_Delete ;
      private bool AV51IsAuthorized_RevisaoLogUsuarioAlteracao ;
      private bool AV54IsAuthorized_Insert ;
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
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string A122RevisaoLogObservacao ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV29TFRevisaoLogUsuarioAlteracao ;
      private string AV30TFRevisaoLogUsuarioAlteracao_Sel ;
      private string AV31TFRevisaoLogObservacao ;
      private string AV32TFRevisaoLogObservacao_Sel ;
      private string AV46GridAppliedFilters ;
      private string AV37DDO_RevisaoLogDataAlteracaoAuxDateText ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string lV60Revisaologwwds_1_filterfulltext ;
      private string lV63Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string lV65Revisaologwwds_6_tfrevisaologobservacao ;
      private string AV60Revisaologwwds_1_filterfulltext ;
      private string AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ;
      private string AV63Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string AV66Revisaologwwds_7_tfrevisaologobservacao_sel ;
      private string AV65Revisaologwwds_6_tfrevisaologobservacao ;
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
      private GXUserControl ucTfrevisaologdataalteracao_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H008P2_A75DocumentoId ;
      private DateTime[] H008P2_A123RevisaoLogDataAlteracao ;
      private string[] H008P2_A122RevisaoLogObservacao ;
      private string[] H008P2_A121RevisaoLogUsuarioAlteracao ;
      private int[] H008P2_A120RevisaoLogId ;
      private long[] H008P3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV52AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV42GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV53AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV40DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV41GAMSession ;
   }

   public class revisaologww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008P2( IGxContext context ,
                                             string AV60Revisaologwwds_1_filterfulltext ,
                                             int AV61Revisaologwwds_2_tfrevisaologid ,
                                             int AV62Revisaologwwds_3_tfrevisaologid_to ,
                                             string AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                             string AV63Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                             string AV66Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                             string AV65Revisaologwwds_6_tfrevisaologobservacao ,
                                             DateTime AV67Revisaologwwds_8_tfrevisaologdataalteracao ,
                                             DateTime AV68Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                             int AV69Revisaologwwds_10_tfdocumentoid ,
                                             int AV70Revisaologwwds_11_tfdocumentoid_to ,
                                             int A120RevisaoLogId ,
                                             string A121RevisaoLogUsuarioAlteracao ,
                                             string A122RevisaoLogObservacao ,
                                             int A75DocumentoId ,
                                             DateTime A123RevisaoLogDataAlteracao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[17];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DocumentoId], [RevisaoLogDataAlteracao], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogId]";
         sFromString = " FROM [RevisaoLog]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([RevisaoLogId] AS decimal(8,0))) like '%' + @lV60Revisaologwwds_1_filterfulltext) or ( [RevisaoLogUsuarioAlteracao] like '%' + @lV60Revisaologwwds_1_filterfulltext) or ( [RevisaoLogObservacao] like '%' + @lV60Revisaologwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV60Revisaologwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV61Revisaologwwds_2_tfrevisaologid) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] >= @AV61Revisaologwwds_2_tfrevisaologid)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV62Revisaologwwds_3_tfrevisaologid_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] <= @AV62Revisaologwwds_3_tfrevisaologid_to)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Revisaologwwds_4_tfrevisaologusuarioalteracao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] like @lV63Revisaologwwds_4_tfrevisaologusuarioalteracao)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ! ( StringUtil.StrCmp(AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] = @AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RevisaoLogUsuarioAlteracao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Revisaologwwds_7_tfrevisaologobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Revisaologwwds_6_tfrevisaologobservacao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] like @lV65Revisaologwwds_6_tfrevisaologobservacao)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Revisaologwwds_7_tfrevisaologobservacao_sel)) && ! ( StringUtil.StrCmp(AV66Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] = @AV66Revisaologwwds_7_tfrevisaologobservacao_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV66Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH([RevisaoLogObservacao])=0))");
         }
         if ( ! (DateTime.MinValue==AV67Revisaologwwds_8_tfrevisaologdataalteracao) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] >= @AV67Revisaologwwds_8_tfrevisaologdataalteracao)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Revisaologwwds_9_tfrevisaologdataalteracao_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] <= @AV68Revisaologwwds_9_tfrevisaologdataalteracao_to)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (0==AV69Revisaologwwds_10_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV69Revisaologwwds_10_tfdocumentoid)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (0==AV70Revisaologwwds_11_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV70Revisaologwwds_11_tfdocumentoid_to)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RevisaoLogUsuarioAlteracao]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RevisaoLogUsuarioAlteracao] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RevisaoLogId]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RevisaoLogId] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RevisaoLogObservacao]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RevisaoLogObservacao] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RevisaoLogDataAlteracao]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RevisaoLogDataAlteracao] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [DocumentoId]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [DocumentoId] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [RevisaoLogId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H008P3( IGxContext context ,
                                             string AV60Revisaologwwds_1_filterfulltext ,
                                             int AV61Revisaologwwds_2_tfrevisaologid ,
                                             int AV62Revisaologwwds_3_tfrevisaologid_to ,
                                             string AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                             string AV63Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                             string AV66Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                             string AV65Revisaologwwds_6_tfrevisaologobservacao ,
                                             DateTime AV67Revisaologwwds_8_tfrevisaologdataalteracao ,
                                             DateTime AV68Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                             int AV69Revisaologwwds_10_tfdocumentoid ,
                                             int AV70Revisaologwwds_11_tfdocumentoid_to ,
                                             int A120RevisaoLogId ,
                                             string A121RevisaoLogUsuarioAlteracao ,
                                             string A122RevisaoLogObservacao ,
                                             int A75DocumentoId ,
                                             DateTime A123RevisaoLogDataAlteracao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[14];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [RevisaoLog]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Revisaologwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([RevisaoLogId] AS decimal(8,0))) like '%' + @lV60Revisaologwwds_1_filterfulltext) or ( [RevisaoLogUsuarioAlteracao] like '%' + @lV60Revisaologwwds_1_filterfulltext) or ( [RevisaoLogObservacao] like '%' + @lV60Revisaologwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV60Revisaologwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV61Revisaologwwds_2_tfrevisaologid) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] >= @AV61Revisaologwwds_2_tfrevisaologid)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV62Revisaologwwds_3_tfrevisaologid_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] <= @AV62Revisaologwwds_3_tfrevisaologid_to)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Revisaologwwds_4_tfrevisaologusuarioalteracao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] like @lV63Revisaologwwds_4_tfrevisaologusuarioalteracao)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ! ( StringUtil.StrCmp(AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] = @AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RevisaoLogUsuarioAlteracao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Revisaologwwds_7_tfrevisaologobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Revisaologwwds_6_tfrevisaologobservacao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] like @lV65Revisaologwwds_6_tfrevisaologobservacao)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Revisaologwwds_7_tfrevisaologobservacao_sel)) && ! ( StringUtil.StrCmp(AV66Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] = @AV66Revisaologwwds_7_tfrevisaologobservacao_sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV66Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH([RevisaoLogObservacao])=0))");
         }
         if ( ! (DateTime.MinValue==AV67Revisaologwwds_8_tfrevisaologdataalteracao) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] >= @AV67Revisaologwwds_8_tfrevisaologdataalteracao)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Revisaologwwds_9_tfrevisaologdataalteracao_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] <= @AV68Revisaologwwds_9_tfrevisaologdataalteracao_to)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (0==AV69Revisaologwwds_10_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV69Revisaologwwds_10_tfdocumentoid)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (0==AV70Revisaologwwds_11_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV70Revisaologwwds_11_tfdocumentoid_to)");
         }
         else
         {
            GXv_int8[13] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H008P2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H008P3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH008P2;
          prmH008P2 = new Object[] {
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV61Revisaologwwds_2_tfrevisaologid",GXType.Int32,8,0) ,
          new ParDef("@AV62Revisaologwwds_3_tfrevisaologid_to",GXType.Int32,8,0) ,
          new ParDef("@lV63Revisaologwwds_4_tfrevisaologusuarioalteracao",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Revisaologwwds_6_tfrevisaologobservacao",GXType.NVarChar,200,0) ,
          new ParDef("@AV66Revisaologwwds_7_tfrevisaologobservacao_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV67Revisaologwwds_8_tfrevisaologdataalteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV68Revisaologwwds_9_tfrevisaologdataalteracao_to",GXType.DateTime,8,5) ,
          new ParDef("@AV69Revisaologwwds_10_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV70Revisaologwwds_11_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008P3;
          prmH008P3 = new Object[] {
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV61Revisaologwwds_2_tfrevisaologid",GXType.Int32,8,0) ,
          new ParDef("@AV62Revisaologwwds_3_tfrevisaologid_to",GXType.Int32,8,0) ,
          new ParDef("@lV63Revisaologwwds_4_tfrevisaologusuarioalteracao",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Revisaologwwds_5_tfrevisaologusuarioalteracao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Revisaologwwds_6_tfrevisaologobservacao",GXType.NVarChar,200,0) ,
          new ParDef("@AV66Revisaologwwds_7_tfrevisaologobservacao_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV67Revisaologwwds_8_tfrevisaologdataalteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV68Revisaologwwds_9_tfrevisaologdataalteracao_to",GXType.DateTime,8,5) ,
          new ParDef("@AV69Revisaologwwds_10_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV70Revisaologwwds_11_tfdocumentoid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008P2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008P3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
