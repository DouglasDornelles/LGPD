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
   public class parametroww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public parametroww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public parametroww( IGxContext context )
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
         cmbParametroAtivo = new GXCombobox();
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
         AV71Pgmname = GetPar( "Pgmname");
         AV27TFParametroCod = GetPar( "TFParametroCod");
         AV28TFParametroCod_Sel = GetPar( "TFParametroCod_Sel");
         AV29TFParametroDescricao = GetPar( "TFParametroDescricao");
         AV30TFParametroDescricao_Sel = GetPar( "TFParametroDescricao_Sel");
         AV31TFParametroValor = GetPar( "TFParametroValor");
         AV32TFParametroValor_Sel = GetPar( "TFParametroValor_Sel");
         AV33TFParametroComentario = GetPar( "TFParametroComentario");
         AV34TFParametroComentario_Sel = GetPar( "TFParametroComentario_Sel");
         AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV58IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV61IsAuthorized_ParametroDescricao = StringUtil.StrToBool( GetPar( "IsAuthorized_ParametroDescricao"));
         AV64IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
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
            return "parametroww_Execute" ;
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
         PA822( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START822( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametroww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PARAMETRODESCRICAO", GetSecureSignedToken( "", AV61IsAuthorized_ParametroDescricao, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV64IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV62AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV62AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV50DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV50DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROCOD", StringUtil.RTrim( AV27TFParametroCod));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROCOD_SEL", StringUtil.RTrim( AV28TFParametroCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETRODESCRICAO", AV29TFParametroDescricao);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETRODESCRICAO_SEL", AV30TFParametroDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROVALOR", AV31TFParametroValor);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROVALOR_SEL", AV32TFParametroValor_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROCOMENTARIO", AV33TFParametroComentario);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROCOMENTARIO_SEL", AV34TFParametroComentario_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PARAMETRODESCRICAO", AV61IsAuthorized_ParametroDescricao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PARAMETRODESCRICAO", GetSecureSignedToken( "", AV61IsAuthorized_ParametroDescricao, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV64IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV64IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROCOD_SELECTED", StringUtil.RTrim( AV66ParametroCod_Selected));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Confirmtype));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Result));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Result));
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
            WE822( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT822( ) ;
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
         return formatLink("parametroww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ParametroWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Parametro" ;
      }

      protected void WB820( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table1_25_822( true) ;
         }
         else
         {
            wb_table1_25_822( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_822e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV62AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV50DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV50DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table2_65_822( true) ;
         }
         else
         {
            wb_table2_65_822( false) ;
         }
         return  ;
      }

      protected void wb_table2_65_822e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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

      protected void START822( )
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
            Form.Meta.addItem("description", " Parametro", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP820( ) ;
      }

      protected void WS822( )
      {
         START822( ) ;
         EVT822( ) ;
      }

      protected void EVT822( )
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
                              E11822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E15822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNEXCLUIR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17822 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18822 ();
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
                              AV57Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
                              AV65BtnExcluir = cgiGet( edtavBtnexcluir_Internalname);
                              AssignAttri("", false, edtavBtnexcluir_Internalname, AV65BtnExcluir);
                              A124ParametroCod = cgiGet( edtParametroCod_Internalname);
                              A125ParametroDescricao = cgiGet( edtParametroDescricao_Internalname);
                              A126ParametroValor = cgiGet( edtParametroValor_Internalname);
                              A127ParametroComentario = cgiGet( edtParametroComentario_Internalname);
                              A128ParametroDataInclusao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtParametroDataInclusao_Internalname), 0));
                              A129ParametroDataAlteracao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtParametroDataAlteracao_Internalname), 0));
                              A130ParametroUsuarioInclusao = cgiGet( edtParametroUsuarioInclusao_Internalname);
                              A131ParametroUsuarioAlteracao = cgiGet( edtParametroUsuarioAlteracao_Internalname);
                              cmbParametroAtivo.Name = cmbParametroAtivo_Internalname;
                              cmbParametroAtivo.CurrentValue = cgiGet( cmbParametroAtivo_Internalname);
                              A132ParametroAtivo = StringUtil.StrToBool( cgiGet( cmbParametroAtivo_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19822 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E20822 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21822 ();
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

      protected void WE822( )
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

      protected void PA822( )
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
                                       string AV71Pgmname ,
                                       string AV27TFParametroCod ,
                                       string AV28TFParametroCod_Sel ,
                                       string AV29TFParametroDescricao ,
                                       string AV30TFParametroDescricao_Sel ,
                                       string AV31TFParametroValor ,
                                       string AV32TFParametroValor_Sel ,
                                       string AV33TFParametroComentario ,
                                       string AV34TFParametroComentario_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV58IsAuthorized_Update ,
                                       bool AV61IsAuthorized_ParametroDescricao ,
                                       bool AV64IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E20822 ();
         GRID_nCurrentRecord = 0;
         RF822( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A124ParametroCod, "")), context));
         GxWebStd.gx_hidden_field( context, "PARAMETROCOD", StringUtil.RTrim( A124ParametroCod));
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
         RF822( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "ParametroWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavBtnexcluir_Enabled = 0;
         AssignProp("", false, edtavBtnexcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnexcluir_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void RF822( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E20822 ();
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
                                                 AV72Parametrowwds_1_filterfulltext ,
                                                 AV74Parametrowwds_3_tfparametrocod_sel ,
                                                 AV73Parametrowwds_2_tfparametrocod ,
                                                 AV76Parametrowwds_5_tfparametrodescricao_sel ,
                                                 AV75Parametrowwds_4_tfparametrodescricao ,
                                                 AV78Parametrowwds_7_tfparametrovalor_sel ,
                                                 AV77Parametrowwds_6_tfparametrovalor ,
                                                 AV80Parametrowwds_9_tfparametrocomentario_sel ,
                                                 AV79Parametrowwds_8_tfparametrocomentario ,
                                                 A124ParametroCod ,
                                                 A125ParametroDescricao ,
                                                 A126ParametroValor ,
                                                 A127ParametroComentario ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
            lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
            lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
            lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
            lV73Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV73Parametrowwds_2_tfparametrocod), 10, "%");
            lV75Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV75Parametrowwds_4_tfparametrodescricao), "%", "");
            lV77Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV77Parametrowwds_6_tfparametrovalor), "%", "");
            lV79Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV79Parametrowwds_8_tfparametrocomentario), "%", "");
            /* Using cursor H00822 */
            pr_default.execute(0, new Object[] {lV72Parametrowwds_1_filterfulltext, lV72Parametrowwds_1_filterfulltext, lV72Parametrowwds_1_filterfulltext, lV72Parametrowwds_1_filterfulltext, lV73Parametrowwds_2_tfparametrocod, AV74Parametrowwds_3_tfparametrocod_sel, lV75Parametrowwds_4_tfparametrodescricao, AV76Parametrowwds_5_tfparametrodescricao_sel, lV77Parametrowwds_6_tfparametrovalor, AV78Parametrowwds_7_tfparametrovalor_sel, lV79Parametrowwds_8_tfparametrocomentario, AV80Parametrowwds_9_tfparametrocomentario_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A132ParametroAtivo = H00822_A132ParametroAtivo[0];
               A131ParametroUsuarioAlteracao = H00822_A131ParametroUsuarioAlteracao[0];
               A130ParametroUsuarioInclusao = H00822_A130ParametroUsuarioInclusao[0];
               A129ParametroDataAlteracao = H00822_A129ParametroDataAlteracao[0];
               A128ParametroDataInclusao = H00822_A128ParametroDataInclusao[0];
               A127ParametroComentario = H00822_A127ParametroComentario[0];
               A126ParametroValor = H00822_A126ParametroValor[0];
               A125ParametroDescricao = H00822_A125ParametroDescricao[0];
               A124ParametroCod = H00822_A124ParametroCod[0];
               E21822 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 43;
            WB820( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes822( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PARAMETRODESCRICAO", AV61IsAuthorized_ParametroDescricao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PARAMETRODESCRICAO", GetSecureSignedToken( "", AV61IsAuthorized_ParametroDescricao, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROCOD"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, StringUtil.RTrim( context.localUtil.Format( A124ParametroCod, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV64IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV64IsAuthorized_Insert, context));
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
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV72Parametrowwds_1_filterfulltext ,
                                              AV74Parametrowwds_3_tfparametrocod_sel ,
                                              AV73Parametrowwds_2_tfparametrocod ,
                                              AV76Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV75Parametrowwds_4_tfparametrodescricao ,
                                              AV78Parametrowwds_7_tfparametrovalor_sel ,
                                              AV77Parametrowwds_6_tfparametrovalor ,
                                              AV80Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV79Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
         lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
         lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
         lV72Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext), "%", "");
         lV73Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV73Parametrowwds_2_tfparametrocod), 10, "%");
         lV75Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV75Parametrowwds_4_tfparametrodescricao), "%", "");
         lV77Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV77Parametrowwds_6_tfparametrovalor), "%", "");
         lV79Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV79Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor H00823 */
         pr_default.execute(1, new Object[] {lV72Parametrowwds_1_filterfulltext, lV72Parametrowwds_1_filterfulltext, lV72Parametrowwds_1_filterfulltext, lV72Parametrowwds_1_filterfulltext, lV73Parametrowwds_2_tfparametrocod, AV74Parametrowwds_3_tfparametrocod_sel, lV75Parametrowwds_4_tfparametrodescricao, AV76Parametrowwds_5_tfparametrodescricao_sel, lV77Parametrowwds_6_tfparametrovalor, AV78Parametrowwds_7_tfparametrovalor_sel, lV79Parametrowwds_8_tfparametrocomentario, AV80Parametrowwds_9_tfparametrocomentario_sel});
         GRID_nRecordCount = H00823_AGRID_nRecordCount[0];
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
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "ParametroWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavBtnexcluir_Enabled = 0;
         AssignProp("", false, edtavBtnexcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnexcluir_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP820( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19822 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV62AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV50DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ",", "."));
            AV54GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV55GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV66ParametroCod_Selected = cgiGet( "vPARAMETROCOD_SELECTED");
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
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
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
            Dvelop_confirmpanel_btnexcluir_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Title");
            Dvelop_confirmpanel_btnexcluir_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmationtext");
            Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnexcluir_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Nobuttoncaption");
            Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnexcluir_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttonposition");
            Dvelop_confirmpanel_btnexcluir_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmtype");
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
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_btnexcluir_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Result");
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
         E19822 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19822( )
      {
         /* Start Routine */
         returnInSub = false;
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
         AV62AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV63AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV63AGExportDataItem.gxTpr_Title = "Excel";
         AV63AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV63AGExportDataItem.gxTpr_Eventkey = "Export";
         AV63AGExportDataItem.gxTpr_Isdivider = false;
         AV62AGExportData.Add(AV63AGExportDataItem, 0);
         AV63AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV63AGExportDataItem.gxTpr_Title = "PDF";
         AV63AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV63AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV63AGExportDataItem.gxTpr_Isdivider = false;
         AV62AGExportData.Add(AV63AGExportDataItem, 0);
         GXt_boolean1 = AV61IsAuthorized_ParametroDescricao;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametroview_Execute", out  GXt_boolean1) ;
         AV61IsAuthorized_ParametroDescricao = GXt_boolean1;
         AssignAttri("", false, "AV61IsAuthorized_ParametroDescricao", AV61IsAuthorized_ParametroDescricao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PARAMETRODESCRICAO", GetSecureSignedToken( "", AV61IsAuthorized_ParametroDescricao, context));
         AV51GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV52GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV51GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Parametro";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV50DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV50DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E20822( )
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
         if ( StringUtil.StrCmp(AV23Session.Get("ParametroWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("ParametroWWColumnsSelector");
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
         edtParametroCod_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroCod_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtParametroDescricao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroDescricao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroDescricao_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtParametroValor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroValor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroValor_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtParametroComentario_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroComentario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroComentario_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char3 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char3) ;
         AV56GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         edtavUpdate_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavUpdate_Internalname, "Columnheaderclass", edtavUpdate_Columnheaderclass, !bGXsfl_43_Refreshing);
         edtavBtnexcluir_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavBtnexcluir_Internalname, "Columnheaderclass", edtavBtnexcluir_Columnheaderclass, !bGXsfl_43_Refreshing);
         edtParametroCod_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtParametroCod_Internalname, "Columnheaderclass", edtParametroCod_Columnheaderclass, !bGXsfl_43_Refreshing);
         edtParametroDescricao_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtParametroDescricao_Internalname, "Columnheaderclass", edtParametroDescricao_Columnheaderclass, !bGXsfl_43_Refreshing);
         edtParametroValor_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtParametroValor_Internalname, "Columnheaderclass", edtParametroValor_Columnheaderclass, !bGXsfl_43_Refreshing);
         edtParametroComentario_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtParametroComentario_Internalname, "Columnheaderclass", edtParametroComentario_Columnheaderclass, !bGXsfl_43_Refreshing);
         AV72Parametrowwds_1_filterfulltext = AV16FilterFullText;
         AV73Parametrowwds_2_tfparametrocod = AV27TFParametroCod;
         AV74Parametrowwds_3_tfparametrocod_sel = AV28TFParametroCod_Sel;
         AV75Parametrowwds_4_tfparametrodescricao = AV29TFParametroDescricao;
         AV76Parametrowwds_5_tfparametrodescricao_sel = AV30TFParametroDescricao_Sel;
         AV77Parametrowwds_6_tfparametrovalor = AV31TFParametroValor;
         AV78Parametrowwds_7_tfparametrovalor_sel = AV32TFParametroValor_Sel;
         AV79Parametrowwds_8_tfparametrocomentario = AV33TFParametroComentario;
         AV80Parametrowwds_9_tfparametrocomentario_sel = AV34TFParametroComentario_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12822( )
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
            AV53PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E13822( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15822( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroCod") == 0 )
            {
               AV27TFParametroCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFParametroCod", AV27TFParametroCod);
               AV28TFParametroCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFParametroCod_Sel", AV28TFParametroCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroDescricao") == 0 )
            {
               AV29TFParametroDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFParametroDescricao", AV29TFParametroDescricao);
               AV30TFParametroDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFParametroDescricao_Sel", AV30TFParametroDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroValor") == 0 )
            {
               AV31TFParametroValor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFParametroValor", AV31TFParametroValor);
               AV32TFParametroValor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFParametroValor_Sel", AV32TFParametroValor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroComentario") == 0 )
            {
               AV33TFParametroComentario = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFParametroComentario", AV33TFParametroComentario);
               AV34TFParametroComentario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFParametroComentario_Sel", AV34TFParametroComentario_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E21822( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV57Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
         if ( AV58IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "parametro.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A124ParametroCod));
            edtavUpdate_Link = formatLink("parametro.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV65BtnExcluir = "<i class=\"fas fa-xmark\"></i>";
         AssignAttri("", false, edtavBtnexcluir_Internalname, AV65BtnExcluir);
         if ( AV61IsAuthorized_ParametroDescricao )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "parametroview.aspx"+UrlEncode(StringUtil.RTrim(A124ParametroCod)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtParametroDescricao_Link = formatLink("parametroview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( A132ParametroAtivo )
         {
            edtavUpdate_Columnclass = "WWIconActionColumn WWColumnSuccess WWColumnSuccessFirstColumn";
            edtavBtnexcluir_Columnclass = "WWIconActionColumn WWColumnSuccess";
            edtParametroCod_Columnclass = "WWColumn WWColumnSuccess";
            edtParametroDescricao_Columnclass = "WWColumn WWColumnSuccess";
            edtParametroValor_Columnclass = "WWColumn WWColumnSuccess";
            edtParametroComentario_Columnclass = "WWColumn WWColumnSuccess";
         }
         else if ( ! A132ParametroAtivo )
         {
            edtavUpdate_Columnclass = "WWIconActionColumn WWColumnDanger WWColumnDangerFirstColumn";
            edtavBtnexcluir_Columnclass = "WWIconActionColumn WWColumnDanger";
            edtParametroCod_Columnclass = "WWColumn WWColumnDanger";
            edtParametroDescricao_Columnclass = "WWColumn WWColumnDanger";
            edtParametroValor_Columnclass = "WWColumn WWColumnDanger";
            edtParametroComentario_Columnclass = "WWColumn WWColumnDanger";
         }
         else
         {
            edtavUpdate_Columnclass = "WWIconActionColumn";
            edtavBtnexcluir_Columnclass = "WWIconActionColumn";
            edtParametroCod_Columnclass = "WWColumn";
            edtParametroDescricao_Columnclass = "WWColumn";
            edtParametroValor_Columnclass = "WWColumn";
            edtParametroComentario_Columnclass = "WWColumn";
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

      protected void E16822( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ParametroWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11822( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ParametroWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV71Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ParametroWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ParametroWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV25ManageFiltersXml) ;
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

      protected void E17822( )
      {
         /* Dvelop_confirmpanel_btnexcluir_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnexcluir_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO BTNEXCLUIR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E18822( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV64IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "parametro.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("parametro.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E14822( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S222 ();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ParametroCod",  "",  "Código",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ParametroDescricao",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ParametroValor",  "",  "Valor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ParametroComentario",  "",  "Comentário",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ParametroWWColumnsSelector", out  GXt_char3) ;
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
         GXt_boolean1 = AV58IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametro_Update", out  GXt_boolean1) ;
         AV58IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV58IsAuthorized_Update", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         if ( ! ( AV58IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean1 = AV64IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametro_Insert", out  GXt_boolean1) ;
         AV64IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV64IsAuthorized_Insert", AV64IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV64IsAuthorized_Insert, context));
         if ( ! ( AV64IsAuthorized_Insert ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ParametroWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFParametroCod = "";
         AssignAttri("", false, "AV27TFParametroCod", AV27TFParametroCod);
         AV28TFParametroCod_Sel = "";
         AssignAttri("", false, "AV28TFParametroCod_Sel", AV28TFParametroCod_Sel);
         AV29TFParametroDescricao = "";
         AssignAttri("", false, "AV29TFParametroDescricao", AV29TFParametroDescricao);
         AV30TFParametroDescricao_Sel = "";
         AssignAttri("", false, "AV30TFParametroDescricao_Sel", AV30TFParametroDescricao_Sel);
         AV31TFParametroValor = "";
         AssignAttri("", false, "AV31TFParametroValor", AV31TFParametroValor);
         AV32TFParametroValor_Sel = "";
         AssignAttri("", false, "AV32TFParametroValor_Sel", AV32TFParametroValor_Sel);
         AV33TFParametroComentario = "";
         AssignAttri("", false, "AV33TFParametroComentario", AV33TFParametroComentario);
         AV34TFParametroComentario_Sel = "";
         AssignAttri("", false, "AV34TFParametroComentario_Sel", AV34TFParametroComentario_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO BTNEXCLUIR' Routine */
         returnInSub = false;
         AV67Parametro.Load(A124ParametroCod);
         AV67Parametro.Delete();
         if ( AV67Parametro.Success() )
         {
            context.CommitDataStores("parametroww",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV71Pgmname, AV27TFParametroCod, AV28TFParametroCod_Sel, AV29TFParametroDescricao, AV30TFParametroDescricao_Sel, AV31TFParametroValor, AV32TFParametroValor_Sel, AV33TFParametroComentario, AV34TFParametroComentario_Sel, AV13OrderedBy, AV14OrderedDsc, AV58IsAuthorized_Update, AV61IsAuthorized_ParametroDescricao, AV64IsAuthorized_Insert) ;
         }
         else
         {
            AV82GXV2 = 1;
            AV81GXV1 = AV67Parametro.GetMessages();
            while ( AV82GXV2 <= AV81GXV1.Count )
            {
               AV68Message = ((GeneXus.Utils.SdtMessages_Message)AV81GXV1.Item(AV82GXV2));
               GX_msglist.addItem(AV68Message.gxTpr_Description);
               AV82GXV2 = (int)(AV82GXV2+1);
            }
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV71Pgmname+"GridState"), null, "", "");
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
         AV83GXV3 = 1;
         while ( AV83GXV3 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV83GXV3));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD") == 0 )
            {
               AV27TFParametroCod = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFParametroCod", AV27TFParametroCod);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD_SEL") == 0 )
            {
               AV28TFParametroCod_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFParametroCod_Sel", AV28TFParametroCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV29TFParametroDescricao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFParametroDescricao", AV29TFParametroDescricao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV30TFParametroDescricao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFParametroDescricao_Sel", AV30TFParametroDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV31TFParametroValor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFParametroValor", AV31TFParametroValor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV32TFParametroValor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFParametroValor_Sel", AV32TFParametroValor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO") == 0 )
            {
               AV33TFParametroComentario = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFParametroComentario", AV33TFParametroComentario);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO_SEL") == 0 )
            {
               AV34TFParametroComentario_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFParametroComentario_Sel", AV34TFParametroComentario_Sel);
            }
            AV83GXV3 = (int)(AV83GXV3+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFParametroCod_Sel)),  AV28TFParametroCod_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFParametroDescricao_Sel)),  AV30TFParametroDescricao_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFParametroValor_Sel)),  AV32TFParametroValor_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFParametroComentario_Sel)),  AV34TFParametroComentario_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFParametroCod)),  AV27TFParametroCod, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFParametroDescricao)),  AV29TFParametroDescricao, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFParametroValor)),  AV31TFParametroValor, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFParametroComentario)),  AV33TFParametroComentario, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROCOD",  "Código",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFParametroCod)),  0,  AV27TFParametroCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFParametroCod_Sel)),  AV28TFParametroCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETRODESCRICAO",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFParametroDescricao)),  0,  AV29TFParametroDescricao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFParametroDescricao_Sel)),  AV30TFParametroDescricao_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROVALOR",  "Valor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFParametroValor)),  0,  AV31TFParametroValor,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFParametroValor_Sel)),  AV32TFParametroValor_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROCOMENTARIO",  "Comentário",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFParametroComentario)),  0,  AV33TFParametroComentario,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFParametroComentario_Sel)),  AV34TFParametroComentario_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Parametro";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S212( )
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
         new parametrowwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
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

      protected void S222( )
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
         Innewwindow1_Target = formatLink("parametrowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table2_65_822( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnexcluir_Internalname, tblTabledvelop_confirmpanel_btnexcluir_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnexcluir.SetProperty("Title", Dvelop_confirmpanel_btnexcluir_Title);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnexcluir_Confirmationtext);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnexcluir_Nobuttoncaption);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnexcluir_Yesbuttonposition);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("ConfirmType", Dvelop_confirmpanel_btnexcluir_Confirmtype);
            ucDvelop_confirmpanel_btnexcluir.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnexcluir_Internalname, "DVELOP_CONFIRMPANEL_BTNEXCLUIRContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNEXCLUIRContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_65_822e( true) ;
         }
         else
         {
            wb_table2_65_822e( false) ;
         }
      }

      protected void wb_table1_25_822( bool wbgen )
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
            wb_table3_30_822( true) ;
         }
         else
         {
            wb_table3_30_822( false) ;
         }
         return  ;
      }

      protected void wb_table3_30_822e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_822e( true) ;
         }
         else
         {
            wb_table1_25_822e( false) ;
         }
      }

      protected void wb_table3_30_822( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_ParametroWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_30_822e( true) ;
         }
         else
         {
            wb_table3_30_822e( false) ;
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
         PA822( ) ;
         WS822( ) ;
         WE822( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910514357", true, true);
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
         context.AddJavascriptSource("parametroww.js", "?202311910514358", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_idx;
         edtavBtnexcluir_Internalname = "vBTNEXCLUIR_"+sGXsfl_43_idx;
         edtParametroCod_Internalname = "PARAMETROCOD_"+sGXsfl_43_idx;
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO_"+sGXsfl_43_idx;
         edtParametroValor_Internalname = "PARAMETROVALOR_"+sGXsfl_43_idx;
         edtParametroComentario_Internalname = "PARAMETROCOMENTARIO_"+sGXsfl_43_idx;
         edtParametroDataInclusao_Internalname = "PARAMETRODATAINCLUSAO_"+sGXsfl_43_idx;
         edtParametroDataAlteracao_Internalname = "PARAMETRODATAALTERACAO_"+sGXsfl_43_idx;
         edtParametroUsuarioInclusao_Internalname = "PARAMETROUSUARIOINCLUSAO_"+sGXsfl_43_idx;
         edtParametroUsuarioAlteracao_Internalname = "PARAMETROUSUARIOALTERACAO_"+sGXsfl_43_idx;
         cmbParametroAtivo_Internalname = "PARAMETROATIVO_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_fel_idx;
         edtavBtnexcluir_Internalname = "vBTNEXCLUIR_"+sGXsfl_43_fel_idx;
         edtParametroCod_Internalname = "PARAMETROCOD_"+sGXsfl_43_fel_idx;
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO_"+sGXsfl_43_fel_idx;
         edtParametroValor_Internalname = "PARAMETROVALOR_"+sGXsfl_43_fel_idx;
         edtParametroComentario_Internalname = "PARAMETROCOMENTARIO_"+sGXsfl_43_fel_idx;
         edtParametroDataInclusao_Internalname = "PARAMETRODATAINCLUSAO_"+sGXsfl_43_fel_idx;
         edtParametroDataAlteracao_Internalname = "PARAMETRODATAALTERACAO_"+sGXsfl_43_fel_idx;
         edtParametroUsuarioInclusao_Internalname = "PARAMETROUSUARIOINCLUSAO_"+sGXsfl_43_fel_idx;
         edtParametroUsuarioAlteracao_Internalname = "PARAMETROUSUARIOALTERACAO_"+sGXsfl_43_fel_idx;
         cmbParametroAtivo_Internalname = "PARAMETROATIVO_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         SubsflControlProps_432( ) ;
         WB820( ) ;
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
            TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 44,'',false,'"+sGXsfl_43_idx+"',43)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV57Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,44);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavUpdate_Columnclass,(string)edtavUpdate_Columnheaderclass,(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnexcluir_Enabled!=0)&&(edtavBtnexcluir_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 45,'',false,'"+sGXsfl_43_idx+"',43)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnexcluir_Internalname,StringUtil.RTrim( AV65BtnExcluir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnexcluir_Enabled!=0)&&(edtavBtnexcluir_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,45);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e22822_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBtnexcluir_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavBtnexcluir_Columnclass,(string)edtavBtnexcluir_Columnheaderclass,(short)-1,(int)edtavBtnexcluir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtParametroCod_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroCod_Internalname,StringUtil.RTrim( A124ParametroCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtParametroCod_Columnclass,(string)edtParametroCod_Columnheaderclass,(int)edtParametroCod_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtParametroDescricao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroDescricao_Internalname,(string)A125ParametroDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtParametroDescricao_Link,(string)"",(string)"",(string)"",(string)edtParametroDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtParametroDescricao_Columnclass,(string)edtParametroDescricao_Columnheaderclass,(int)edtParametroDescricao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtParametroValor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroValor_Internalname,(string)A126ParametroValor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtParametroValor_Columnclass,(string)edtParametroValor_Columnheaderclass,(int)edtParametroValor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtParametroComentario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroComentario_Internalname,(string)A127ParametroComentario,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroComentario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtParametroComentario_Columnclass,(string)edtParametroComentario_Columnheaderclass,(int)edtParametroComentario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroDataInclusao_Internalname,context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"),context.localUtil.Format( A128ParametroDataInclusao, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroDataInclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroDataAlteracao_Internalname,context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"),context.localUtil.Format( A129ParametroDataAlteracao, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroDataAlteracao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroUsuarioInclusao_Internalname,StringUtil.RTrim( A130ParametroUsuarioInclusao),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroUsuarioInclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroUsuarioAlteracao_Internalname,StringUtil.RTrim( A131ParametroUsuarioAlteracao),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroUsuarioAlteracao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbParametroAtivo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PARAMETROATIVO_" + sGXsfl_43_idx;
               cmbParametroAtivo.Name = GXCCtl;
               cmbParametroAtivo.WebTags = "";
               cmbParametroAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
               cmbParametroAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
               if ( cmbParametroAtivo.ItemCount > 0 )
               {
                  A132ParametroAtivo = StringUtil.StrToBool( cmbParametroAtivo.getValidValue(StringUtil.BoolToStr( A132ParametroAtivo)));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbParametroAtivo,(string)cmbParametroAtivo_Internalname,StringUtil.BoolToStr( A132ParametroAtivo),(short)1,(string)cmbParametroAtivo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbParametroAtivo.CurrentValue = StringUtil.BoolToStr( A132ParametroAtivo);
            AssignProp("", false, cmbParametroAtivo_Internalname, "Values", (string)(cmbParametroAtivo.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            send_integrity_lvl_hashes822( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PARAMETROATIVO_" + sGXsfl_43_idx;
         cmbParametroAtivo.Name = GXCCtl;
         cmbParametroAtivo.WebTags = "";
         cmbParametroAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbParametroAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbParametroAtivo.ItemCount > 0 )
         {
            A132ParametroAtivo = StringUtil.StrToBool( cmbParametroAtivo.getValidValue(StringUtil.BoolToStr( A132ParametroAtivo)));
         }
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroCod_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Código") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroDescricao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroValor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroComentario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Comentário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV57Update));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavUpdate_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavUpdate_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV65BtnExcluir));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavBtnexcluir_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavBtnexcluir_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnexcluir_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A124ParametroCod));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtParametroCod_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtParametroCod_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroCod_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A125ParametroDescricao);
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtParametroDescricao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtParametroDescricao_Columnheaderclass));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtParametroDescricao_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroDescricao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A126ParametroValor);
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtParametroValor_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtParametroValor_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroValor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A127ParametroComentario);
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtParametroComentario_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtParametroComentario_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroComentario_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A130ParametroUsuarioInclusao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A131ParametroUsuarioAlteracao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A132ParametroAtivo));
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
         edtavBtnexcluir_Internalname = "vBTNEXCLUIR";
         edtParametroCod_Internalname = "PARAMETROCOD";
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO";
         edtParametroValor_Internalname = "PARAMETROVALOR";
         edtParametroComentario_Internalname = "PARAMETROCOMENTARIO";
         edtParametroDataInclusao_Internalname = "PARAMETRODATAINCLUSAO";
         edtParametroDataAlteracao_Internalname = "PARAMETRODATAALTERACAO";
         edtParametroUsuarioInclusao_Internalname = "PARAMETROUSUARIOINCLUSAO";
         edtParametroUsuarioAlteracao_Internalname = "PARAMETROUSUARIOALTERACAO";
         cmbParametroAtivo_Internalname = "PARAMETROATIVO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_btnexcluir_Internalname = "DVELOP_CONFIRMPANEL_BTNEXCLUIR";
         tblTabledvelop_confirmpanel_btnexcluir_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNEXCLUIR";
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
         cmbParametroAtivo_Jsonclick = "";
         edtParametroUsuarioAlteracao_Jsonclick = "";
         edtParametroUsuarioInclusao_Jsonclick = "";
         edtParametroDataAlteracao_Jsonclick = "";
         edtParametroDataInclusao_Jsonclick = "";
         edtParametroComentario_Jsonclick = "";
         edtParametroComentario_Columnclass = "WWColumn";
         edtParametroValor_Jsonclick = "";
         edtParametroValor_Columnclass = "WWColumn";
         edtParametroDescricao_Jsonclick = "";
         edtParametroDescricao_Columnclass = "WWColumn";
         edtParametroDescricao_Link = "";
         edtParametroCod_Jsonclick = "";
         edtParametroCod_Columnclass = "WWColumn";
         edtavBtnexcluir_Jsonclick = "";
         edtavBtnexcluir_Columnclass = "WWIconActionColumn";
         edtavBtnexcluir_Visible = -1;
         edtavBtnexcluir_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Columnclass = "WWIconActionColumn";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavUpdate_Visible = -1;
         edtParametroComentario_Columnheaderclass = "";
         edtParametroValor_Columnheaderclass = "";
         edtParametroDescricao_Columnheaderclass = "";
         edtParametroCod_Columnheaderclass = "";
         edtavBtnexcluir_Columnheaderclass = "";
         edtavUpdate_Columnheaderclass = "";
         edtParametroComentario_Visible = -1;
         edtParametroValor_Visible = -1;
         edtParametroDescricao_Visible = -1;
         edtParametroCod_Visible = -1;
         subGrid_Sortable = 0;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_btnexcluir_Confirmtype = "1";
         Dvelop_confirmpanel_btnexcluir_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnexcluir_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnexcluir_Confirmationtext = "Confirma a exclusão do Parâmetro?";
         Dvelop_confirmpanel_btnexcluir_Title = "Atenção!";
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
         Ddo_grid_Datalistproc = "ParametroWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "2:ParametroCod|3:ParametroDescricao|4:ParametroValor|5:ParametroComentario";
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
         Form.Caption = " Parametro";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroCod_Visible',ctrl:'PARAMETROCOD',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'edtParametroComentario_Visible',ctrl:'PARAMETROCOMENTARIO',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtavUpdate_Columnheaderclass',ctrl:'vUPDATE',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtParametroCod_Columnheaderclass',ctrl:'PARAMETROCOD',prop:'Columnheaderclass'},{av:'edtParametroDescricao_Columnheaderclass',ctrl:'PARAMETRODESCRICAO',prop:'Columnheaderclass'},{av:'edtParametroValor_Columnheaderclass',ctrl:'PARAMETROVALOR',prop:'Columnheaderclass'},{av:'edtParametroComentario_Columnheaderclass',ctrl:'PARAMETROCOMENTARIO',prop:'Columnheaderclass'},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12822',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13822',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E15822',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E21822',iparms:[{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A124ParametroCod',fld:'PARAMETROCOD',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'cmbParametroAtivo'},{av:'A132ParametroAtivo',fld:'PARAMETROATIVO',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV57Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV65BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'edtParametroDescricao_Link',ctrl:'PARAMETRODESCRICAO',prop:'Link'},{av:'edtavUpdate_Columnclass',ctrl:'vUPDATE',prop:'Columnclass'},{av:'edtavBtnexcluir_Columnclass',ctrl:'vBTNEXCLUIR',prop:'Columnclass'},{av:'edtParametroCod_Columnclass',ctrl:'PARAMETROCOD',prop:'Columnclass'},{av:'edtParametroDescricao_Columnclass',ctrl:'PARAMETRODESCRICAO',prop:'Columnclass'},{av:'edtParametroValor_Columnclass',ctrl:'PARAMETROVALOR',prop:'Columnclass'},{av:'edtParametroComentario_Columnclass',ctrl:'PARAMETROCOMENTARIO',prop:'Columnclass'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E16822',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtParametroCod_Visible',ctrl:'PARAMETROCOD',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'edtParametroComentario_Visible',ctrl:'PARAMETROCOMENTARIO',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtavUpdate_Columnheaderclass',ctrl:'vUPDATE',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtParametroCod_Columnheaderclass',ctrl:'PARAMETROCOD',prop:'Columnheaderclass'},{av:'edtParametroDescricao_Columnheaderclass',ctrl:'PARAMETRODESCRICAO',prop:'Columnheaderclass'},{av:'edtParametroValor_Columnheaderclass',ctrl:'PARAMETROVALOR',prop:'Columnheaderclass'},{av:'edtParametroComentario_Columnheaderclass',ctrl:'PARAMETROCOMENTARIO',prop:'Columnheaderclass'},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11822',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroCod_Visible',ctrl:'PARAMETROCOD',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'edtParametroComentario_Visible',ctrl:'PARAMETROCOMENTARIO',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtavUpdate_Columnheaderclass',ctrl:'vUPDATE',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtParametroCod_Columnheaderclass',ctrl:'PARAMETROCOD',prop:'Columnheaderclass'},{av:'edtParametroDescricao_Columnheaderclass',ctrl:'PARAMETRODESCRICAO',prop:'Columnheaderclass'},{av:'edtParametroValor_Columnheaderclass',ctrl:'PARAMETROVALOR',prop:'Columnheaderclass'},{av:'edtParametroComentario_Columnheaderclass',ctrl:'PARAMETROCOMENTARIO',prop:'Columnheaderclass'},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VBTNEXCLUIR.CLICK","{handler:'E22822',iparms:[{av:'A124ParametroCod',fld:'PARAMETROCOD',pic:'',hsh:true}]");
         setEventMetadata("VBTNEXCLUIR.CLICK",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNEXCLUIR.CLOSE","{handler:'E17822',iparms:[{av:'Dvelop_confirmpanel_btnexcluir_Result',ctrl:'DVELOP_CONFIRMPANEL_BTNEXCLUIR',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A124ParametroCod',fld:'PARAMETROCOD',pic:'',hsh:true}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNEXCLUIR.CLOSE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroCod_Visible',ctrl:'PARAMETROCOD',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'edtParametroComentario_Visible',ctrl:'PARAMETROCOMENTARIO',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtavUpdate_Columnheaderclass',ctrl:'vUPDATE',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtParametroCod_Columnheaderclass',ctrl:'PARAMETROCOD',prop:'Columnheaderclass'},{av:'edtParametroDescricao_Columnheaderclass',ctrl:'PARAMETRODESCRICAO',prop:'Columnheaderclass'},{av:'edtParametroValor_Columnheaderclass',ctrl:'PARAMETROVALOR',prop:'Columnheaderclass'},{av:'edtParametroComentario_Columnheaderclass',ctrl:'PARAMETROCOMENTARIO',prop:'Columnheaderclass'},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18822',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A124ParametroCod',fld:'PARAMETROCOD',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroCod_Visible',ctrl:'PARAMETROCOD',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'edtParametroComentario_Visible',ctrl:'PARAMETROCOMENTARIO',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtavUpdate_Columnheaderclass',ctrl:'vUPDATE',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtParametroCod_Columnheaderclass',ctrl:'PARAMETROCOD',prop:'Columnheaderclass'},{av:'edtParametroDescricao_Columnheaderclass',ctrl:'PARAMETRODESCRICAO',prop:'Columnheaderclass'},{av:'edtParametroValor_Columnheaderclass',ctrl:'PARAMETROVALOR',prop:'Columnheaderclass'},{av:'edtParametroComentario_Columnheaderclass',ctrl:'PARAMETROCOMENTARIO',prop:'Columnheaderclass'},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14822',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFParametroCod',fld:'vTFPARAMETROCOD',pic:''},{av:'AV28TFParametroCod_Sel',fld:'vTFPARAMETROCOD_SEL',pic:''},{av:'AV29TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV30TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV31TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV32TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV33TFParametroComentario',fld:'vTFPARAMETROCOMENTARIO',pic:''},{av:'AV34TFParametroComentario_Sel',fld:'vTFPARAMETROCOMENTARIO_SEL',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV61IsAuthorized_ParametroDescricao',fld:'vISAUTHORIZED_PARAMETRODESCRICAO',pic:'',hsh:true},{av:'AV64IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'}]}");
         setEventMetadata("NULL","{handler:'Valid_Parametroativo',iparms:[]");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_btnexcluir_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV71Pgmname = "";
         AV27TFParametroCod = "";
         AV28TFParametroCod_Sel = "";
         AV29TFParametroDescricao = "";
         AV30TFParametroDescricao_Sel = "";
         AV31TFParametroValor = "";
         AV32TFParametroValor_Sel = "";
         AV33TFParametroComentario = "";
         AV34TFParametroComentario_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56GridAppliedFilters = "";
         AV62AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV50DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV66ParametroCod_Selected = "";
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
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV57Update = "";
         AV65BtnExcluir = "";
         A124ParametroCod = "";
         A125ParametroDescricao = "";
         A126ParametroValor = "";
         A127ParametroComentario = "";
         A128ParametroDataInclusao = DateTime.MinValue;
         A129ParametroDataAlteracao = DateTime.MinValue;
         A130ParametroUsuarioInclusao = "";
         A131ParametroUsuarioAlteracao = "";
         scmdbuf = "";
         lV72Parametrowwds_1_filterfulltext = "";
         lV73Parametrowwds_2_tfparametrocod = "";
         lV75Parametrowwds_4_tfparametrodescricao = "";
         lV77Parametrowwds_6_tfparametrovalor = "";
         lV79Parametrowwds_8_tfparametrocomentario = "";
         AV72Parametrowwds_1_filterfulltext = "";
         AV74Parametrowwds_3_tfparametrocod_sel = "";
         AV73Parametrowwds_2_tfparametrocod = "";
         AV76Parametrowwds_5_tfparametrodescricao_sel = "";
         AV75Parametrowwds_4_tfparametrodescricao = "";
         AV78Parametrowwds_7_tfparametrovalor_sel = "";
         AV77Parametrowwds_6_tfparametrovalor = "";
         AV80Parametrowwds_9_tfparametrocomentario_sel = "";
         AV79Parametrowwds_8_tfparametrocomentario = "";
         H00822_A132ParametroAtivo = new bool[] {false} ;
         H00822_A131ParametroUsuarioAlteracao = new string[] {""} ;
         H00822_A130ParametroUsuarioInclusao = new string[] {""} ;
         H00822_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H00822_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H00822_A127ParametroComentario = new string[] {""} ;
         H00822_A126ParametroValor = new string[] {""} ;
         H00822_A125ParametroDescricao = new string[] {""} ;
         H00822_A124ParametroCod = new string[] {""} ;
         H00823_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV63AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV51GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV52GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
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
         AV67Parametro = new SdtParametro(context);
         AV81GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV68Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDvelop_confirmpanel_btnexcluir = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.parametroww__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametroww__default(),
            new Object[][] {
                new Object[] {
               H00822_A132ParametroAtivo, H00822_A131ParametroUsuarioAlteracao, H00822_A130ParametroUsuarioInclusao, H00822_A129ParametroDataAlteracao, H00822_A128ParametroDataInclusao, H00822_A127ParametroComentario, H00822_A126ParametroValor, H00822_A125ParametroDescricao, H00822_A124ParametroCod
               }
               , new Object[] {
               H00823_AGRID_nRecordCount
               }
            }
         );
         AV71Pgmname = "ParametroWW";
         /* GeneXus formulas. */
         AV71Pgmname = "ParametroWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavBtnexcluir_Enabled = 0;
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
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavBtnexcluir_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtParametroCod_Visible ;
      private int edtParametroDescricao_Visible ;
      private int edtParametroValor_Visible ;
      private int edtParametroComentario_Visible ;
      private int AV53PageToGo ;
      private int edtavUpdate_Visible ;
      private int AV82GXV2 ;
      private int AV83GXV3 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavBtnexcluir_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_btnexcluir_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV71Pgmname ;
      private string AV27TFParametroCod ;
      private string AV28TFParametroCod_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV66ParametroCod_Selected ;
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
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
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
      private string Dvelop_confirmpanel_btnexcluir_Title ;
      private string Dvelop_confirmpanel_btnexcluir_Confirmationtext ;
      private string Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnexcluir_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnexcluir_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnexcluir_Confirmtype ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV57Update ;
      private string edtavUpdate_Internalname ;
      private string AV65BtnExcluir ;
      private string edtavBtnexcluir_Internalname ;
      private string A124ParametroCod ;
      private string edtParametroCod_Internalname ;
      private string edtParametroDescricao_Internalname ;
      private string edtParametroValor_Internalname ;
      private string edtParametroComentario_Internalname ;
      private string edtParametroDataInclusao_Internalname ;
      private string edtParametroDataAlteracao_Internalname ;
      private string A130ParametroUsuarioInclusao ;
      private string edtParametroUsuarioInclusao_Internalname ;
      private string A131ParametroUsuarioAlteracao ;
      private string edtParametroUsuarioAlteracao_Internalname ;
      private string cmbParametroAtivo_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string lV73Parametrowwds_2_tfparametrocod ;
      private string AV74Parametrowwds_3_tfparametrocod_sel ;
      private string AV73Parametrowwds_2_tfparametrocod ;
      private string edtavUpdate_Columnheaderclass ;
      private string edtavBtnexcluir_Columnheaderclass ;
      private string edtParametroCod_Columnheaderclass ;
      private string edtParametroDescricao_Columnheaderclass ;
      private string edtParametroValor_Columnheaderclass ;
      private string edtParametroComentario_Columnheaderclass ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtParametroDescricao_Link ;
      private string edtavUpdate_Columnclass ;
      private string edtavBtnexcluir_Columnclass ;
      private string edtParametroCod_Columnclass ;
      private string edtParametroDescricao_Columnclass ;
      private string edtParametroValor_Columnclass ;
      private string edtParametroComentario_Columnclass ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTabledvelop_confirmpanel_btnexcluir_Internalname ;
      private string Dvelop_confirmpanel_btnexcluir_Internalname ;
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
      private string edtavBtnexcluir_Jsonclick ;
      private string edtParametroCod_Jsonclick ;
      private string edtParametroDescricao_Jsonclick ;
      private string edtParametroValor_Jsonclick ;
      private string edtParametroComentario_Jsonclick ;
      private string edtParametroDataInclusao_Jsonclick ;
      private string edtParametroDataAlteracao_Jsonclick ;
      private string edtParametroUsuarioInclusao_Jsonclick ;
      private string edtParametroUsuarioAlteracao_Jsonclick ;
      private string GXCCtl ;
      private string cmbParametroAtivo_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A128ParametroDataInclusao ;
      private DateTime A129ParametroDataAlteracao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV58IsAuthorized_Update ;
      private bool AV61IsAuthorized_ParametroDescricao ;
      private bool AV64IsAuthorized_Insert ;
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
      private bool A132ParametroAtivo ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV29TFParametroDescricao ;
      private string AV30TFParametroDescricao_Sel ;
      private string AV31TFParametroValor ;
      private string AV32TFParametroValor_Sel ;
      private string AV33TFParametroComentario ;
      private string AV34TFParametroComentario_Sel ;
      private string AV56GridAppliedFilters ;
      private string A125ParametroDescricao ;
      private string A126ParametroValor ;
      private string A127ParametroComentario ;
      private string lV72Parametrowwds_1_filterfulltext ;
      private string lV75Parametrowwds_4_tfparametrodescricao ;
      private string lV77Parametrowwds_6_tfparametrovalor ;
      private string lV79Parametrowwds_8_tfparametrocomentario ;
      private string AV72Parametrowwds_1_filterfulltext ;
      private string AV76Parametrowwds_5_tfparametrodescricao_sel ;
      private string AV75Parametrowwds_4_tfparametrodescricao ;
      private string AV78Parametrowwds_7_tfparametrovalor_sel ;
      private string AV77Parametrowwds_6_tfparametrovalor ;
      private string AV80Parametrowwds_9_tfparametrocomentario_sel ;
      private string AV79Parametrowwds_8_tfparametrocomentario ;
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
      private GXUserControl ucDvelop_confirmpanel_btnexcluir ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbParametroAtivo ;
      private IDataStoreProvider pr_default ;
      private bool[] H00822_A132ParametroAtivo ;
      private string[] H00822_A131ParametroUsuarioAlteracao ;
      private string[] H00822_A130ParametroUsuarioInclusao ;
      private DateTime[] H00822_A129ParametroDataAlteracao ;
      private DateTime[] H00822_A128ParametroDataInclusao ;
      private string[] H00822_A127ParametroComentario ;
      private string[] H00822_A126ParametroValor ;
      private string[] H00822_A125ParametroDescricao ;
      private string[] H00822_A124ParametroCod ;
      private long[] H00823_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV62AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV52GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV81GXV1 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV63AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV50DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV51GAMSession ;
      private SdtParametro AV67Parametro ;
      private GeneXus.Utils.SdtMessages_Message AV68Message ;
   }

   public class parametroww__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class parametroww__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H00822( IGxContext context ,
                                           string AV72Parametrowwds_1_filterfulltext ,
                                           string AV74Parametrowwds_3_tfparametrocod_sel ,
                                           string AV73Parametrowwds_2_tfparametrocod ,
                                           string AV76Parametrowwds_5_tfparametrodescricao_sel ,
                                           string AV75Parametrowwds_4_tfparametrodescricao ,
                                           string AV78Parametrowwds_7_tfparametrovalor_sel ,
                                           string AV77Parametrowwds_6_tfparametrovalor ,
                                           string AV80Parametrowwds_9_tfparametrocomentario_sel ,
                                           string AV79Parametrowwds_8_tfparametrocomentario ,
                                           string A124ParametroCod ,
                                           string A125ParametroDescricao ,
                                           string A126ParametroValor ,
                                           string A127ParametroComentario ,
                                           short AV13OrderedBy ,
                                           bool AV14OrderedDsc )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int8 = new short[15];
       Object[] GXv_Object9 = new Object[2];
       string sSelectString;
       string sFromString;
       string sOrderString;
       sSelectString = " [ParametroAtivo], [ParametroUsuarioAlteracao], [ParametroUsuarioInclusao], [ParametroDataAlteracao], [ParametroDataInclusao], [ParametroComentario], [ParametroValor], [ParametroDescricao], [ParametroCod]";
       sFromString = " FROM [Parametro]";
       sOrderString = "";
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext)) )
       {
          AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV72Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV72Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV72Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV72Parametrowwds_1_filterfulltext))");
       }
       else
       {
          GXv_int8[0] = 1;
          GXv_int8[1] = 1;
          GXv_int8[2] = 1;
          GXv_int8[3] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Parametrowwds_2_tfparametrocod)) ) )
       {
          AddWhere(sWhereString, "([ParametroCod] like @lV73Parametrowwds_2_tfparametrocod)");
       }
       else
       {
          GXv_int8[4] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV74Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroCod] = @AV74Parametrowwds_3_tfparametrocod_sel)");
       }
       else
       {
          GXv_int8[5] = 1;
       }
       if ( StringUtil.StrCmp(AV74Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroCod] = ''))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Parametrowwds_4_tfparametrodescricao)) ) )
       {
          AddWhere(sWhereString, "([ParametroDescricao] like @lV75Parametrowwds_4_tfparametrodescricao)");
       }
       else
       {
          GXv_int8[6] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV76Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroDescricao] = @AV76Parametrowwds_5_tfparametrodescricao_sel)");
       }
       else
       {
          GXv_int8[7] = 1;
       }
       if ( StringUtil.StrCmp(AV76Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Parametrowwds_6_tfparametrovalor)) ) )
       {
          AddWhere(sWhereString, "([ParametroValor] like @lV77Parametrowwds_6_tfparametrovalor)");
       }
       else
       {
          GXv_int8[8] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV78Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroValor] = @AV78Parametrowwds_7_tfparametrovalor_sel)");
       }
       else
       {
          GXv_int8[9] = 1;
       }
       if ( StringUtil.StrCmp(AV78Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroValor] = ''))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Parametrowwds_8_tfparametrocomentario)) ) )
       {
          AddWhere(sWhereString, "([ParametroComentario] like @lV79Parametrowwds_8_tfparametrocomentario)");
       }
       else
       {
          GXv_int8[10] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV80Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroComentario] = @AV80Parametrowwds_9_tfparametrocomentario_sel)");
       }
       else
       {
          GXv_int8[11] = 1;
       }
       if ( StringUtil.StrCmp(AV80Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroComentario] = ''))");
       }
       if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
       {
          sOrderString += " ORDER BY [ParametroDescricao]";
       }
       else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
       {
          sOrderString += " ORDER BY [ParametroDescricao] DESC";
       }
       else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
       {
          sOrderString += " ORDER BY [ParametroCod]";
       }
       else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
       {
          sOrderString += " ORDER BY [ParametroCod] DESC";
       }
       else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
       {
          sOrderString += " ORDER BY [ParametroValor]";
       }
       else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
       {
          sOrderString += " ORDER BY [ParametroValor] DESC";
       }
       else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
       {
          sOrderString += " ORDER BY [ParametroComentario]";
       }
       else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
       {
          sOrderString += " ORDER BY [ParametroComentario] DESC";
       }
       else if ( true )
       {
          sOrderString += " ORDER BY [ParametroCod]";
       }
       scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
       GXv_Object9[0] = scmdbuf;
       GXv_Object9[1] = GXv_int8;
       return GXv_Object9 ;
    }

    protected Object[] conditional_H00823( IGxContext context ,
                                           string AV72Parametrowwds_1_filterfulltext ,
                                           string AV74Parametrowwds_3_tfparametrocod_sel ,
                                           string AV73Parametrowwds_2_tfparametrocod ,
                                           string AV76Parametrowwds_5_tfparametrodescricao_sel ,
                                           string AV75Parametrowwds_4_tfparametrodescricao ,
                                           string AV78Parametrowwds_7_tfparametrovalor_sel ,
                                           string AV77Parametrowwds_6_tfparametrovalor ,
                                           string AV80Parametrowwds_9_tfparametrocomentario_sel ,
                                           string AV79Parametrowwds_8_tfparametrocomentario ,
                                           string A124ParametroCod ,
                                           string A125ParametroDescricao ,
                                           string A126ParametroValor ,
                                           string A127ParametroComentario ,
                                           short AV13OrderedBy ,
                                           bool AV14OrderedDsc )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int10 = new short[12];
       Object[] GXv_Object11 = new Object[2];
       scmdbuf = "SELECT COUNT(*) FROM [Parametro]";
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Parametrowwds_1_filterfulltext)) )
       {
          AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV72Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV72Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV72Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV72Parametrowwds_1_filterfulltext))");
       }
       else
       {
          GXv_int10[0] = 1;
          GXv_int10[1] = 1;
          GXv_int10[2] = 1;
          GXv_int10[3] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Parametrowwds_2_tfparametrocod)) ) )
       {
          AddWhere(sWhereString, "([ParametroCod] like @lV73Parametrowwds_2_tfparametrocod)");
       }
       else
       {
          GXv_int10[4] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV74Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroCod] = @AV74Parametrowwds_3_tfparametrocod_sel)");
       }
       else
       {
          GXv_int10[5] = 1;
       }
       if ( StringUtil.StrCmp(AV74Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroCod] = ''))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Parametrowwds_4_tfparametrodescricao)) ) )
       {
          AddWhere(sWhereString, "([ParametroDescricao] like @lV75Parametrowwds_4_tfparametrodescricao)");
       }
       else
       {
          GXv_int10[6] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV76Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroDescricao] = @AV76Parametrowwds_5_tfparametrodescricao_sel)");
       }
       else
       {
          GXv_int10[7] = 1;
       }
       if ( StringUtil.StrCmp(AV76Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Parametrowwds_6_tfparametrovalor)) ) )
       {
          AddWhere(sWhereString, "([ParametroValor] like @lV77Parametrowwds_6_tfparametrovalor)");
       }
       else
       {
          GXv_int10[8] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV78Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroValor] = @AV78Parametrowwds_7_tfparametrovalor_sel)");
       }
       else
       {
          GXv_int10[9] = 1;
       }
       if ( StringUtil.StrCmp(AV78Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroValor] = ''))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Parametrowwds_8_tfparametrocomentario)) ) )
       {
          AddWhere(sWhereString, "([ParametroComentario] like @lV79Parametrowwds_8_tfparametrocomentario)");
       }
       else
       {
          GXv_int10[10] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV80Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "([ParametroComentario] = @AV80Parametrowwds_9_tfparametrocomentario_sel)");
       }
       else
       {
          GXv_int10[11] = 1;
       }
       if ( StringUtil.StrCmp(AV80Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(([ParametroComentario] = ''))");
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
       else if ( true )
       {
          scmdbuf += "";
       }
       GXv_Object11[0] = scmdbuf;
       GXv_Object11[1] = GXv_int10;
       return GXv_Object11 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H00822(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
             case 1 :
                   return conditional_H00823(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
        Object[] prmH00822;
        prmH00822 = new Object[] {
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV73Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
        new ParDef("@AV74Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
        new ParDef("@lV75Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
        new ParDef("@AV76Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
        new ParDef("@lV77Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
        new ParDef("@AV78Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
        new ParDef("@lV79Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
        new ParDef("@AV80Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0) ,
        new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH00823;
        prmH00823 = new Object[] {
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV72Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
        new ParDef("@lV73Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
        new ParDef("@AV74Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
        new ParDef("@lV75Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
        new ParDef("@AV76Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
        new ParDef("@lV77Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
        new ParDef("@AV78Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
        new ParDef("@lV79Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
        new ParDef("@AV80Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0)
        };
        def= new CursorDef[] {
            new CursorDef("H00822", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00822,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00823", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00823,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
