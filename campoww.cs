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
   public class campoww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public campoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public campoww( IGxContext context )
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
         cmbCampoAtivo = new GXCombobox();
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
         nRC_GXsfl_40 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_40"), "."));
         nGXsfl_40_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_40_idx"), "."));
         sGXsfl_40_idx = GetPar( "sGXsfl_40_idx");
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
         AV29TFCampoNome = GetPar( "TFCampoNome");
         AV30TFCampoNome_Sel = GetPar( "TFCampoNome_Sel");
         AV48TFCampoAtivo_Sel = (short)(NumberUtil.Val( GetPar( "TFCampoAtivo_Sel"), "."));
         AV49TFTelaNome = GetPar( "TFTelaNome");
         AV50TFTelaNome_Sel = GetPar( "TFTelaNome_Sel");
         AV60Pgmname = GetPar( "Pgmname");
         AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV41IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV43IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV44IsAuthorized_CampoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_CampoNome"));
         AV51IsAuthorized_TelaNome = StringUtil.StrToBool( GetPar( "IsAuthorized_TelaNome"));
         AV47IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV29TFCampoNome, AV30TFCampoNome_Sel, AV48TFCampoAtivo_Sel, AV49TFTelaNome, AV50TFTelaNome_Sel, AV60Pgmname, AV13OrderedBy, AV14OrderedDsc, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_CampoNome, AV51IsAuthorized_TelaNome, AV47IsAuthorized_Insert) ;
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
            return "campoww_Execute" ;
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
         PA892( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START892( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("campoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CAMPONOME", GetSecureSignedToken( "", AV44IsAuthorized_CampoNome, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TELANOME", GetSecureSignedToken( "", AV51IsAuthorized_TelaNome, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV45AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV45AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCAMPONOME", AV29TFCampoNome);
         GxWebStd.gx_hidden_field( context, "vTFCAMPONOME_SEL", AV30TFCampoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCAMPOATIVO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFCampoAtivo_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTELANOME", AV49TFTelaNome);
         GxWebStd.gx_hidden_field( context, "vTFTELANOME_SEL", AV50TFTelaNome_Sel);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CAMPONOME", AV44IsAuthorized_CampoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CAMPONOME", GetSecureSignedToken( "", AV44IsAuthorized_CampoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TELANOME", AV51IsAuthorized_TelaNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TELANOME", GetSecureSignedToken( "", AV51IsAuthorized_TelaNome, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Grid_empowerer_Infinitescrolling));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
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
            WE892( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT892( ) ;
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
         return formatLink("campoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CampoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tela de consulta dos registros de Campo para Tooltip" ;
      }

      protected void WB890( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CampoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CampoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CampoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table1_25_892( true) ;
         }
         else
         {
            wb_table1_25_892( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_892e( bool wbgen )
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
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl40( ) ;
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            nRC_GXsfl_40 = (int)(nGXsfl_40_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV45AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("InfiniteScrolling", Grid_empowerer_Infinitescrolling);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 40 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
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

      protected void START892( )
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
            Form.Meta.addItem("description", "Tela de consulta dos registros de Campo para Tooltip", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP890( ) ;
      }

      protected void WS892( )
      {
         START892( ) ;
         EVT892( ) ;
      }

      protected void EVT892( )
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
                              E11892 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12892 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13892 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14892 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E15892 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              AV54Campowwds_1_filterfulltext = AV16FilterFullText;
                              AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
                              AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
                              AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
                              AV58Campowwds_5_tftelanome = AV49TFTelaNome;
                              AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_40_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              AV40Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV40Update);
                              AV42Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV42Delete);
                              A135CampoId = (int)(context.localUtil.CToN( cgiGet( edtCampoId_Internalname), ",", "."));
                              A136CampoNome = cgiGet( edtCampoNome_Internalname);
                              cmbCampoAtivo.Name = cmbCampoAtivo_Internalname;
                              cmbCampoAtivo.CurrentValue = cgiGet( cmbCampoAtivo_Internalname);
                              A138CampoAtivo = StringUtil.StrToBool( cgiGet( cmbCampoAtivo_Internalname));
                              A133TelaId = (int)(context.localUtil.CToN( cgiGet( edtTelaId_Internalname), ",", "."));
                              A134TelaNome = cgiGet( edtTelaNome_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16892 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E17892 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E18892 ();
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

      protected void WE892( )
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

      protected void PA892( )
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
         SubsflControlProps_402( ) ;
         while ( nGXsfl_40_idx <= nRC_GXsfl_40 )
         {
            sendrow_402( ) ;
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV29TFCampoNome ,
                                       string AV30TFCampoNome_Sel ,
                                       short AV48TFCampoAtivo_Sel ,
                                       string AV49TFTelaNome ,
                                       string AV50TFTelaNome_Sel ,
                                       string AV60Pgmname ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV41IsAuthorized_Update ,
                                       bool AV43IsAuthorized_Delete ,
                                       bool AV44IsAuthorized_CampoNome ,
                                       bool AV51IsAuthorized_TelaNome ,
                                       bool AV47IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E17892 ();
         GRID_nCurrentRecord = 0;
         RF892( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CAMPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CAMPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135CampoId), 8, 0, ".", "")));
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
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_40_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF892( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "CampoWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_40_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_40_Refreshing);
      }

      protected void RF892( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 40;
         /* Execute user event: Refresh */
         E17892 ();
         nGXsfl_40_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         bGXsfl_40_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
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
            SubsflControlProps_402( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV54Campowwds_1_filterfulltext ,
                                                 AV56Campowwds_3_tfcamponome_sel ,
                                                 AV55Campowwds_2_tfcamponome ,
                                                 AV57Campowwds_4_tfcampoativo_sel ,
                                                 AV59Campowwds_6_tftelanome_sel ,
                                                 AV58Campowwds_5_tftelanome ,
                                                 A136CampoNome ,
                                                 A138CampoAtivo ,
                                                 A134TelaNome ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
            lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
            lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
            lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
            lV55Campowwds_2_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV55Campowwds_2_tfcamponome), "%", "");
            lV58Campowwds_5_tftelanome = StringUtil.Concat( StringUtil.RTrim( AV58Campowwds_5_tftelanome), "%", "");
            /* Using cursor H00892 */
            pr_default.execute(0, new Object[] {lV54Campowwds_1_filterfulltext, lV54Campowwds_1_filterfulltext, lV54Campowwds_1_filterfulltext, lV54Campowwds_1_filterfulltext, lV55Campowwds_2_tfcamponome, AV56Campowwds_3_tfcamponome_sel, lV58Campowwds_5_tftelanome, AV59Campowwds_6_tftelanome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_40_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A134TelaNome = H00892_A134TelaNome[0];
               A133TelaId = H00892_A133TelaId[0];
               A138CampoAtivo = H00892_A138CampoAtivo[0];
               A136CampoNome = H00892_A136CampoNome[0];
               A135CampoId = H00892_A135CampoId[0];
               A134TelaNome = H00892_A134TelaNome[0];
               E18892 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 40;
            WB890( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes892( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CAMPONOME", AV44IsAuthorized_CampoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CAMPONOME", GetSecureSignedToken( "", AV44IsAuthorized_CampoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TELANOME", AV51IsAuthorized_TelaNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TELANOME", GetSecureSignedToken( "", AV51IsAuthorized_TelaNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CAMPOID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9"), context));
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
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Campowwds_1_filterfulltext ,
                                              AV56Campowwds_3_tfcamponome_sel ,
                                              AV55Campowwds_2_tfcamponome ,
                                              AV57Campowwds_4_tfcampoativo_sel ,
                                              AV59Campowwds_6_tftelanome_sel ,
                                              AV58Campowwds_5_tftelanome ,
                                              A136CampoNome ,
                                              A138CampoAtivo ,
                                              A134TelaNome ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
         lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
         lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
         lV54Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Campowwds_1_filterfulltext), "%", "");
         lV55Campowwds_2_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV55Campowwds_2_tfcamponome), "%", "");
         lV58Campowwds_5_tftelanome = StringUtil.Concat( StringUtil.RTrim( AV58Campowwds_5_tftelanome), "%", "");
         /* Using cursor H00893 */
         pr_default.execute(1, new Object[] {lV54Campowwds_1_filterfulltext, lV54Campowwds_1_filterfulltext, lV54Campowwds_1_filterfulltext, lV54Campowwds_1_filterfulltext, lV55Campowwds_2_tfcamponome, AV56Campowwds_3_tfcamponome_sel, lV58Campowwds_5_tftelanome, AV59Campowwds_6_tftelanome_sel});
         GRID_nRecordCount = H00893_AGRID_nRecordCount[0];
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
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV29TFCampoNome, AV30TFCampoNome_Sel, AV48TFCampoAtivo_Sel, AV49TFTelaNome, AV50TFTelaNome_Sel, AV60Pgmname, AV13OrderedBy, AV14OrderedDsc, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_CampoNome, AV51IsAuthorized_TelaNome, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV29TFCampoNome, AV30TFCampoNome_Sel, AV48TFCampoAtivo_Sel, AV49TFTelaNome, AV50TFTelaNome_Sel, AV60Pgmname, AV13OrderedBy, AV14OrderedDsc, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_CampoNome, AV51IsAuthorized_TelaNome, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV29TFCampoNome, AV30TFCampoNome_Sel, AV48TFCampoAtivo_Sel, AV49TFTelaNome, AV50TFTelaNome_Sel, AV60Pgmname, AV13OrderedBy, AV14OrderedDsc, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_CampoNome, AV51IsAuthorized_TelaNome, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV29TFCampoNome, AV30TFCampoNome_Sel, AV48TFCampoAtivo_Sel, AV49TFTelaNome, AV50TFTelaNome_Sel, AV60Pgmname, AV13OrderedBy, AV14OrderedDsc, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_CampoNome, AV51IsAuthorized_TelaNome, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV29TFCampoNome, AV30TFCampoNome_Sel, AV48TFCampoAtivo_Sel, AV49TFTelaNome, AV50TFTelaNome_Sel, AV60Pgmname, AV13OrderedBy, AV14OrderedDsc, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV44IsAuthorized_CampoNome, AV51IsAuthorized_TelaNome, AV47IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "CampoWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_40_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_40_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP890( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16892 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV45AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV33DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_40"), ",", "."));
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
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
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
            Grid_empowerer_Infinitescrolling = cgiGet( "GRID_EMPOWERER_Infinitescrolling");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
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
         E16892 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16892( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 0;
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
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46AGExportDataItem.gxTpr_Title = "Excel";
         AV46AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV46AGExportDataItem.gxTpr_Eventkey = "Export";
         AV46AGExportDataItem.gxTpr_Isdivider = false;
         AV45AGExportData.Add(AV46AGExportDataItem, 0);
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46AGExportDataItem.gxTpr_Title = "PDF";
         AV46AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV46AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV46AGExportDataItem.gxTpr_Isdivider = false;
         AV45AGExportData.Add(AV46AGExportDataItem, 0);
         GXt_boolean1 = AV44IsAuthorized_CampoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "campoview_Execute", out  GXt_boolean1) ;
         AV44IsAuthorized_CampoNome = GXt_boolean1;
         AssignAttri("", false, "AV44IsAuthorized_CampoNome", AV44IsAuthorized_CampoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CAMPONOME", GetSecureSignedToken( "", AV44IsAuthorized_CampoNome, context));
         GXt_boolean1 = AV51IsAuthorized_TelaNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "telaview_Execute", out  GXt_boolean1) ;
         AV51IsAuthorized_TelaNome = GXt_boolean1;
         AssignAttri("", false, "AV51IsAuthorized_TelaNome", AV51IsAuthorized_TelaNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TELANOME", GetSecureSignedToken( "", AV51IsAuthorized_TelaNome, context));
         AV34GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV35GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV34GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Campo";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV33DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV33DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
      }

      protected void E17892( )
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
         if ( StringUtil.StrCmp(AV23Session.Get("CampoWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("CampoWWColumnsSelector");
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
         edtCampoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCampoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCampoNome_Visible), 5, 0), !bGXsfl_40_Refreshing);
         cmbCampoAtivo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbCampoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCampoAtivo.Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtTelaNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTelaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTelaNome_Visible), 5, 0), !bGXsfl_40_Refreshing);
         AV54Campowwds_1_filterfulltext = AV16FilterFullText;
         AV55Campowwds_2_tfcamponome = AV29TFCampoNome;
         AV56Campowwds_3_tfcamponome_sel = AV30TFCampoNome_Sel;
         AV57Campowwds_4_tfcampoativo_sel = AV48TFCampoAtivo_Sel;
         AV58Campowwds_5_tftelanome = AV49TFTelaNome;
         AV59Campowwds_6_tftelanome_sel = AV50TFTelaNome_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13892( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CampoNome") == 0 )
            {
               AV29TFCampoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFCampoNome", AV29TFCampoNome);
               AV30TFCampoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFCampoNome_Sel", AV30TFCampoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CampoAtivo") == 0 )
            {
               AV48TFCampoAtivo_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV48TFCampoAtivo_Sel", StringUtil.Str( (decimal)(AV48TFCampoAtivo_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TelaNome") == 0 )
            {
               AV49TFTelaNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFTelaNome", AV49TFTelaNome);
               AV50TFTelaNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFTelaNome_Sel", AV50TFTelaNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18892( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV40Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV40Update);
         if ( AV41IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "campo.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A135CampoId,8,0));
            edtavUpdate_Link = formatLink("campo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV42Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV42Delete);
         if ( AV43IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "campo.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A135CampoId,8,0));
            edtavDelete_Link = formatLink("campo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV44IsAuthorized_CampoNome )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "campoview.aspx"+UrlEncode(StringUtil.LTrimStr(A135CampoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtCampoNome_Link = formatLink("campoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV51IsAuthorized_TelaNome )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "telaview.aspx"+UrlEncode(StringUtil.LTrimStr(A133TelaId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtTelaNome_Link = formatLink("telaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 40;
         }
         sendrow_402( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
         {
            context.DoAjaxLoad(40, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E14892( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "CampoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11892( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("CampoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV60Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("CampoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CampoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV25ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado n�o existe mais.");
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV25ManageFiltersXml) ;
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
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E15892( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV47IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "campo.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            CallWebObject(formatLink("campo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A a��o n�o encontra-se dispon�vel");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12892( )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "CampoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "CampoAtivo",  "",  "Ativo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "TelaNome",  "",  "Tela",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CampoWWColumnsSelector", out  GXt_char3) ;
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
         GXt_boolean1 = AV41IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "campo_Update", out  GXt_boolean1) ;
         AV41IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV41IsAuthorized_Update", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         if ( ! ( AV41IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
         GXt_boolean1 = AV43IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "campo_Delete", out  GXt_boolean1) ;
         AV43IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV43IsAuthorized_Delete", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         if ( ! ( AV43IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
         GXt_boolean1 = AV47IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "campo_Insert", out  GXt_boolean1) ;
         AV47IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_Insert", AV47IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV47IsAuthorized_Insert, context));
         if ( ! ( AV47IsAuthorized_Insert ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CampoWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV29TFCampoNome = "";
         AssignAttri("", false, "AV29TFCampoNome", AV29TFCampoNome);
         AV30TFCampoNome_Sel = "";
         AssignAttri("", false, "AV30TFCampoNome_Sel", AV30TFCampoNome_Sel);
         AV48TFCampoAtivo_Sel = 0;
         AssignAttri("", false, "AV48TFCampoAtivo_Sel", StringUtil.Str( (decimal)(AV48TFCampoAtivo_Sel), 1, 0));
         AV49TFTelaNome = "";
         AssignAttri("", false, "AV49TFTelaNome", AV49TFTelaNome);
         AV50TFTelaNome_Sel = "";
         AssignAttri("", false, "AV50TFTelaNome_Sel", AV50TFTelaNome_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV60Pgmname+"GridState"), null, "", "");
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
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCAMPONOME") == 0 )
            {
               AV29TFCampoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFCampoNome", AV29TFCampoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCAMPONOME_SEL") == 0 )
            {
               AV30TFCampoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFCampoNome_Sel", AV30TFCampoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCAMPOATIVO_SEL") == 0 )
            {
               AV48TFCampoAtivo_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV48TFCampoAtivo_Sel", StringUtil.Str( (decimal)(AV48TFCampoAtivo_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTELANOME") == 0 )
            {
               AV49TFTelaNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFTelaNome", AV49TFTelaNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTELANOME_SEL") == 0 )
            {
               AV50TFTelaNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFTelaNome_Sel", AV50TFTelaNome_Sel);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCampoNome_Sel)),  AV30TFCampoNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTelaNome_Sel)),  AV50TFTelaNome_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+((0==AV48TFCampoAtivo_Sel) ? "" : StringUtil.Str( (decimal)(AV48TFCampoAtivo_Sel), 1, 0))+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCampoNome)),  AV29TFCampoNome, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTelaNome)),  AV49TFTelaNome, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"||"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCAMPONOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCampoNome)),  0,  AV29TFCampoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCampoNome_Sel)),  AV30TFCampoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCAMPOATIVO_SEL",  "",  !(0==AV48TFCampoAtivo_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFCampoAtivo_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTELANOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTelaNome)),  0,  AV49TFTelaNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTelaNome_Sel)),  AV50TFTelaNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV60Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Campo";
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
         new campowwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("campowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_892( bool wbgen )
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
            wb_table2_30_892( true) ;
         }
         else
         {
            wb_table2_30_892( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_892e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_892e( true) ;
         }
         else
         {
            wb_table1_25_892e( false) ;
         }
      }

      protected void wb_table2_30_892( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_40_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_CampoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_892e( true) ;
         }
         else
         {
            wb_table2_30_892e( false) ;
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
         PA892( ) ;
         WS892( ) ;
         WE892( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910514834", true, true);
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
         context.AddJavascriptSource("campoww.js", "?202311910514836", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_40_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_40_idx;
         edtCampoId_Internalname = "CAMPOID_"+sGXsfl_40_idx;
         edtCampoNome_Internalname = "CAMPONOME_"+sGXsfl_40_idx;
         cmbCampoAtivo_Internalname = "CAMPOATIVO_"+sGXsfl_40_idx;
         edtTelaId_Internalname = "TELAID_"+sGXsfl_40_idx;
         edtTelaNome_Internalname = "TELANOME_"+sGXsfl_40_idx;
      }

      protected void SubsflControlProps_fel_402( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_40_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_40_fel_idx;
         edtCampoId_Internalname = "CAMPOID_"+sGXsfl_40_fel_idx;
         edtCampoNome_Internalname = "CAMPONOME_"+sGXsfl_40_fel_idx;
         cmbCampoAtivo_Internalname = "CAMPOATIVO_"+sGXsfl_40_fel_idx;
         edtTelaId_Internalname = "TELAID_"+sGXsfl_40_fel_idx;
         edtTelaNome_Internalname = "TELANOME_"+sGXsfl_40_fel_idx;
      }

      protected void sendrow_402( )
      {
         SubsflControlProps_402( ) ;
         WB890( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_40_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_40_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_40_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV40Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV42Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCampoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A135CampoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCampoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtCampoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCampoNome_Internalname,(string)A136CampoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCampoNome_Link,(string)"",(string)"",(string)"",(string)edtCampoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCampoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((cmbCampoAtivo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbCampoAtivo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CAMPOATIVO_" + sGXsfl_40_idx;
               cmbCampoAtivo.Name = GXCCtl;
               cmbCampoAtivo.WebTags = "";
               cmbCampoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
               cmbCampoAtivo.addItem(StringUtil.BoolToStr( false), "N�O", 0);
               if ( cmbCampoAtivo.ItemCount > 0 )
               {
                  A138CampoAtivo = StringUtil.StrToBool( cmbCampoAtivo.getValidValue(StringUtil.BoolToStr( A138CampoAtivo)));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCampoAtivo,(string)cmbCampoAtivo_Internalname,StringUtil.BoolToStr( A138CampoAtivo),(short)1,(string)cmbCampoAtivo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",cmbCampoAtivo.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCampoAtivo.CurrentValue = StringUtil.BoolToStr( A138CampoAtivo);
            AssignProp("", false, cmbCampoAtivo_Internalname, "Values", (string)(cmbCampoAtivo.ToJavascriptSource()), !bGXsfl_40_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTelaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133TelaId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133TelaId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTelaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTelaNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTelaNome_Internalname,(string)A134TelaNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTelaNome_Link,(string)"",(string)"",(string)"",(string)edtTelaNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTelaNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes892( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "CAMPOATIVO_" + sGXsfl_40_idx;
         cmbCampoAtivo.Name = GXCCtl;
         cmbCampoAtivo.WebTags = "";
         cmbCampoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbCampoAtivo.addItem(StringUtil.BoolToStr( false), "N�O", 0);
         if ( cmbCampoAtivo.ItemCount > 0 )
         {
            A138CampoAtivo = StringUtil.StrToBool( cmbCampoAtivo.getValidValue(StringUtil.BoolToStr( A138CampoAtivo)));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl40( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"40\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCampoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbCampoAtivo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Ativo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTelaNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tela") ;
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
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV40Update));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV42Delete));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135CampoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A136CampoNome);
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCampoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCampoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A138CampoAtivo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCampoAtivo.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133TelaId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A134TelaNome);
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTelaNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTelaNome_Visible), 5, 0, ".", "")));
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
         edtCampoId_Internalname = "CAMPOID";
         edtCampoNome_Internalname = "CAMPONOME";
         cmbCampoAtivo_Internalname = "CAMPOATIVO";
         edtTelaId_Internalname = "TELAID";
         edtTelaNome_Internalname = "TELANOME";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtTelaNome_Jsonclick = "";
         edtTelaNome_Link = "";
         edtTelaId_Jsonclick = "";
         cmbCampoAtivo_Jsonclick = "";
         edtCampoNome_Jsonclick = "";
         edtCampoNome_Link = "";
         edtCampoId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtTelaNome_Visible = -1;
         cmbCampoAtivo.Visible = -1;
         edtCampoNome_Visible = -1;
         subGrid_Sortable = 0;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Infinitescrolling = "Grid";
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
         Ddo_grid_Datalistproc = "CampoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|1:WWP_TSChecked,2:WWP_TSUnChecked|";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character||Character";
         Ddo_grid_Includefilter = "T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "3:CampoNome|4:CampoAtivo|6:TelaNome";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Op��es";
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
         Form.Caption = "Tela de consulta dos registros de Campo para Tooltip";
         subGrid_Rows = 50;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13892',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E18892',iparms:[{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV42Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtCampoNome_Link',ctrl:'CAMPONOME',prop:'Link'},{av:'edtTelaNome_Link',ctrl:'TELANOME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E14892',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11892',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E15892',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E12892',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV44IsAuthorized_CampoNome',fld:'vISAUTHORIZED_CAMPONOME',pic:'',hsh:true},{av:'AV51IsAuthorized_TelaNome',fld:'vISAUTHORIZED_TELANOME',pic:'',hsh:true},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV29TFCampoNome',fld:'vTFCAMPONOME',pic:''},{av:'AV30TFCampoNome_Sel',fld:'vTFCAMPONOME_SEL',pic:''},{av:'AV48TFCampoAtivo_Sel',fld:'vTFCAMPOATIVO_SEL',pic:'9'},{av:'AV49TFTelaNome',fld:'vTFTELANOME',pic:''},{av:'AV50TFTelaNome_Sel',fld:'vTFTELANOME_SEL',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCampoNome_Visible',ctrl:'CAMPONOME',prop:'Visible'},{av:'cmbCampoAtivo'},{av:'edtTelaNome_Visible',ctrl:'TELANOME',prop:'Visible'},{av:'AV41IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV43IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV47IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALID_TELAID","{handler:'Valid_Telaid',iparms:[]");
         setEventMetadata("VALID_TELAID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Telanome',iparms:[]");
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV29TFCampoNome = "";
         AV30TFCampoNome_Sel = "";
         AV49TFTelaNome = "";
         AV50TFTelaNome_Sel = "";
         AV60Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV33DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV54Campowwds_1_filterfulltext = "";
         AV55Campowwds_2_tfcamponome = "";
         AV56Campowwds_3_tfcamponome_sel = "";
         AV58Campowwds_5_tftelanome = "";
         AV59Campowwds_6_tftelanome_sel = "";
         AV40Update = "";
         AV42Delete = "";
         A136CampoNome = "";
         A134TelaNome = "";
         GXCCtl = "";
         scmdbuf = "";
         lV54Campowwds_1_filterfulltext = "";
         lV55Campowwds_2_tfcamponome = "";
         lV58Campowwds_5_tftelanome = "";
         H00892_A134TelaNome = new string[] {""} ;
         H00892_A133TelaId = new int[1] ;
         H00892_A138CampoAtivo = new bool[] {false} ;
         H00892_A136CampoNome = new string[] {""} ;
         H00892_A135CampoId = new int[1] ;
         H00893_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV34GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV35GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.campoww__default(),
            new Object[][] {
                new Object[] {
               H00892_A134TelaNome, H00892_A133TelaId, H00892_A138CampoAtivo, H00892_A136CampoNome, H00892_A135CampoId
               }
               , new Object[] {
               H00893_AGRID_nRecordCount
               }
            }
         );
         AV60Pgmname = "CampoWW";
         /* GeneXus formulas. */
         AV60Pgmname = "CampoWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV48TFCampoAtivo_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV57Campowwds_4_tfcampoativo_sel ;
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
      private int nRC_GXsfl_40 ;
      private int subGrid_Rows ;
      private int nGXsfl_40_idx=1 ;
      private int bttBtninsert_Visible ;
      private int A135CampoId ;
      private int A133TelaId ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCampoNome_Visible ;
      private int edtTelaNome_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV61GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_40_idx="0001" ;
      private string AV60Pgmname ;
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
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
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
      private string Grid_empowerer_Infinitescrolling ;
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
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV40Update ;
      private string edtavUpdate_Internalname ;
      private string AV42Delete ;
      private string edtavDelete_Internalname ;
      private string edtCampoId_Internalname ;
      private string edtCampoNome_Internalname ;
      private string cmbCampoAtivo_Internalname ;
      private string edtTelaId_Internalname ;
      private string edtTelaNome_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string GXCCtl ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtavDelete_Link ;
      private string edtCampoNome_Link ;
      private string edtTelaNome_Link ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_40_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtCampoId_Jsonclick ;
      private string edtCampoNome_Jsonclick ;
      private string cmbCampoAtivo_Jsonclick ;
      private string edtTelaId_Jsonclick ;
      private string edtTelaNome_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV41IsAuthorized_Update ;
      private bool AV43IsAuthorized_Delete ;
      private bool AV44IsAuthorized_CampoNome ;
      private bool AV51IsAuthorized_TelaNome ;
      private bool AV47IsAuthorized_Insert ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A138CampoAtivo ;
      private bool bGXsfl_40_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV29TFCampoNome ;
      private string AV30TFCampoNome_Sel ;
      private string AV49TFTelaNome ;
      private string AV50TFTelaNome_Sel ;
      private string AV54Campowwds_1_filterfulltext ;
      private string AV55Campowwds_2_tfcamponome ;
      private string AV56Campowwds_3_tfcamponome_sel ;
      private string AV58Campowwds_5_tftelanome ;
      private string AV59Campowwds_6_tftelanome_sel ;
      private string A136CampoNome ;
      private string A134TelaNome ;
      private string lV54Campowwds_1_filterfulltext ;
      private string lV55Campowwds_2_tfcamponome ;
      private string lV58Campowwds_5_tftelanome ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCampoAtivo ;
      private IDataStoreProvider pr_default ;
      private string[] H00892_A134TelaNome ;
      private int[] H00892_A133TelaId ;
      private bool[] H00892_A138CampoAtivo ;
      private string[] H00892_A136CampoNome ;
      private int[] H00892_A135CampoId ;
      private long[] H00893_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV45AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV35GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV46AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV33DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV34GAMSession ;
   }

   public class campoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00892( IGxContext context ,
                                             string AV54Campowwds_1_filterfulltext ,
                                             string AV56Campowwds_3_tfcamponome_sel ,
                                             string AV55Campowwds_2_tfcamponome ,
                                             short AV57Campowwds_4_tfcampoativo_sel ,
                                             string AV59Campowwds_6_tftelanome_sel ,
                                             string AV58Campowwds_5_tftelanome ,
                                             string A136CampoNome ,
                                             bool A138CampoAtivo ,
                                             string A134TelaNome ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[11];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[TelaNome], T1.[TelaId], T1.[CampoAtivo], T1.[CampoNome], T1.[CampoId]";
         sFromString = " FROM ([Campo] T1 INNER JOIN [Tela] T2 ON T2.[TelaId] = T1.[TelaId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Campowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.[CampoNome] like '%' + @lV54Campowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV54Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 1) or ( 'n�o' like '%' + LOWER(@lV54Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 0) or ( T2.[TelaNome] like '%' + @lV54Campowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Campowwds_3_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Campowwds_2_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] like @lV55Campowwds_2_tfcamponome)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Campowwds_3_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV56Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] = @AV56Campowwds_3_tfcamponome_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CampoNome] = ''))");
         }
         if ( AV57Campowwds_4_tfcampoativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 1)");
         }
         if ( AV57Campowwds_4_tfcampoativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Campowwds_6_tftelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Campowwds_5_tftelanome)) ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] like @lV58Campowwds_5_tftelanome)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Campowwds_6_tftelanome_sel)) && ! ( StringUtil.StrCmp(AV59Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] = @AV59Campowwds_6_tftelanome_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TelaNome] = ''))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CampoNome]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CampoNome] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CampoAtivo]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CampoAtivo] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[TelaNome]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[TelaNome] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[CampoId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00893( IGxContext context ,
                                             string AV54Campowwds_1_filterfulltext ,
                                             string AV56Campowwds_3_tfcamponome_sel ,
                                             string AV55Campowwds_2_tfcamponome ,
                                             short AV57Campowwds_4_tfcampoativo_sel ,
                                             string AV59Campowwds_6_tftelanome_sel ,
                                             string AV58Campowwds_5_tftelanome ,
                                             string A136CampoNome ,
                                             bool A138CampoAtivo ,
                                             string A134TelaNome ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[8];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Campo] T1 INNER JOIN [Tela] T2 ON T2.[TelaId] = T1.[TelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Campowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.[CampoNome] like '%' + @lV54Campowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV54Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 1) or ( 'n�o' like '%' + LOWER(@lV54Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 0) or ( T2.[TelaNome] like '%' + @lV54Campowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Campowwds_3_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Campowwds_2_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] like @lV55Campowwds_2_tfcamponome)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Campowwds_3_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV56Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] = @AV56Campowwds_3_tfcamponome_sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CampoNome] = ''))");
         }
         if ( AV57Campowwds_4_tfcampoativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 1)");
         }
         if ( AV57Campowwds_4_tfcampoativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Campowwds_6_tftelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Campowwds_5_tftelanome)) ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] like @lV58Campowwds_5_tftelanome)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Campowwds_6_tftelanome_sel)) && ! ( StringUtil.StrCmp(AV59Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] = @AV59Campowwds_6_tftelanome_sel)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TelaNome] = ''))");
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
                     return conditional_H00892(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] );
               case 1 :
                     return conditional_H00893(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] );
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
          Object[] prmH00892;
          prmH00892 = new Object[] {
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Campowwds_2_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV56Campowwds_3_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Campowwds_5_tftelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Campowwds_6_tftelanome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00893;
          prmH00893 = new Object[] {
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Campowwds_2_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV56Campowwds_3_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Campowwds_5_tftelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Campowwds_6_tftelanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00892", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00892,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00893", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00893,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
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
