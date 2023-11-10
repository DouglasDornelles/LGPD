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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class documentoview : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public documentoview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentoview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           string aP1_TabCode )
      {
         this.AV10DocumentoId = aP0_DocumentoId;
         this.AV8TabCode = aP1_TabCode;
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
            gxfirstwebparm = GetFirstPar( "DocumentoId");
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
               gxfirstwebparm = GetFirstPar( "DocumentoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "DocumentoId");
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
            return "documentoview_Execute" ;
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
         PA632( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START632( ) ;
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
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "documentoview.aspx"+UrlEncode(StringUtil.LTrimStr(AV10DocumentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documentoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV12SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Width", StringUtil.RTrim( Panel_general_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autowidth", StringUtil.BoolToStr( Panel_general_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoheight", StringUtil.BoolToStr( Panel_general_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Cls", StringUtil.RTrim( Panel_general_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Title", StringUtil.RTrim( Panel_general_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsible", StringUtil.BoolToStr( Panel_general_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsed", StringUtil.BoolToStr( Panel_general_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Showcollapseicon", StringUtil.BoolToStr( Panel_general_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Iconposition", StringUtil.RTrim( Panel_general_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoscroll", StringUtil.BoolToStr( Panel_general_Autoscroll));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
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
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            WebComp_Webcomponent_general.componentjscripts();
         }
         if ( ! ( WebComp_Docenvolvidoscoletawc == null ) )
         {
            WebComp_Docenvolvidoscoletawc.componentjscripts();
         }
         if ( ! ( WebComp_Doccompartinternowc == null ) )
         {
            WebComp_Doccompartinternowc.componentjscripts();
         }
         if ( ! ( WebComp_Docsetorinternowc == null ) )
         {
            WebComp_Docsetorinternowc.componentjscripts();
         }
         if ( ! ( WebComp_Docfonteretencaowc == null ) )
         {
            WebComp_Docfonteretencaowc.componentjscripts();
         }
         if ( ! ( WebComp_Docdicionariowc == null ) )
         {
            WebComp_Docdicionariowc.componentjscripts();
         }
         if ( ! ( WebComp_Docoperadorwc == null ) )
         {
            WebComp_Docoperadorwc.componentjscripts();
         }
         if ( ! ( WebComp_Docanexowc == null ) )
         {
            WebComp_Docanexowc.componentjscripts();
         }
         if ( ! ( WebComp_Revisaologwc == null ) )
         {
            WebComp_Revisaologwc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE632( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT632( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "documentoview.aspx"+UrlEncode(StringUtil.LTrimStr(AV10DocumentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("documentoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "DocumentoView" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documento View" ;
      }

      protected void WB630( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLinkPanel", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWorkwithlink_Internalname, "Ir a Documento", lblWorkwithlink_Link, "", lblWorkwithlink_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockLink", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDocumentogeneral_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_general.SetProperty("Width", Panel_general_Width);
            ucPanel_general.SetProperty("AutoWidth", Panel_general_Autowidth);
            ucPanel_general.SetProperty("AutoHeight", Panel_general_Autoheight);
            ucPanel_general.SetProperty("Cls", Panel_general_Cls);
            ucPanel_general.SetProperty("Title", Panel_general_Title);
            ucPanel_general.SetProperty("Collapsible", Panel_general_Collapsible);
            ucPanel_general.SetProperty("Collapsed", Panel_general_Collapsed);
            ucPanel_general.SetProperty("ShowCollapseIcon", Panel_general_Showcollapseicon);
            ucPanel_general.SetProperty("IconPosition", Panel_general_Iconposition);
            ucPanel_general.SetProperty("AutoScroll", Panel_general_Autoscroll);
            ucPanel_general.Render(context, "dvelop.gxbootstrap.panel_al", Panel_general_Internalname, "PANEL_GENERALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_GENERALContainer"+"TablePanel_General"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_general_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0019"+"", StringUtil.RTrim( WebComp_Webcomponent_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0019"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
                  }
                  WebComp_Webcomponent_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition CellMarginTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableviewcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTab", "left", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocenvolvidoscoleta_title_Internalname, "Doc Envolvidos Coleta", "", "", lblDocenvolvidoscoleta_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocEnvolvidosColeta") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledocenvolvidoscoleta_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0033"+"", StringUtil.RTrim( WebComp_Docenvolvidoscoletawc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0033"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Docenvolvidoscoletawc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocenvolvidoscoletawc), StringUtil.Lower( WebComp_Docenvolvidoscoletawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
                  }
                  WebComp_Docenvolvidoscoletawc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocenvolvidoscoletawc), StringUtil.Lower( WebComp_Docenvolvidoscoletawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDoccompartinterno_title_Internalname, "Doc Compart Interno", "", "", lblDoccompartinterno_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocCompartInterno") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledoccompartinterno_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0041"+"", StringUtil.RTrim( WebComp_Doccompartinternowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0041"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Doccompartinternowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDoccompartinternowc), StringUtil.Lower( WebComp_Doccompartinternowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0041"+"");
                  }
                  WebComp_Doccompartinternowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDoccompartinternowc), StringUtil.Lower( WebComp_Doccompartinternowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocsetorinterno_title_Internalname, "Doc Setor Interno", "", "", lblDocsetorinterno_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocSetorInterno") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledocsetorinterno_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0049"+"", StringUtil.RTrim( WebComp_Docsetorinternowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0049"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Docsetorinternowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocsetorinternowc), StringUtil.Lower( WebComp_Docsetorinternowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
                  }
                  WebComp_Docsetorinternowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocsetorinternowc), StringUtil.Lower( WebComp_Docsetorinternowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocfonteretencao_title_Internalname, "Doc Fonte Retencao", "", "", lblDocfonteretencao_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocFonteRetencao") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledocfonteretencao_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0057"+"", StringUtil.RTrim( WebComp_Docfonteretencaowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0057"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Docfonteretencaowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocfonteretencaowc), StringUtil.Lower( WebComp_Docfonteretencaowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0057"+"");
                  }
                  WebComp_Docfonteretencaowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocfonteretencaowc), StringUtil.Lower( WebComp_Docfonteretencaowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocdicionario_title_Internalname, "Doc Dicionario", "", "", lblDocdicionario_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocDicionario") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledocdicionario_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0065"+"", StringUtil.RTrim( WebComp_Docdicionariowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0065"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Docdicionariowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocdicionariowc), StringUtil.Lower( WebComp_Docdicionariowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0065"+"");
                  }
                  WebComp_Docdicionariowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocdicionariowc), StringUtil.Lower( WebComp_Docdicionariowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperador_title_Internalname, "Doc Operador", "", "", lblDocoperador_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocOperador") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledocoperador_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0073"+"", StringUtil.RTrim( WebComp_Docoperadorwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0073"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Docoperadorwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocoperadorwc), StringUtil.Lower( WebComp_Docoperadorwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0073"+"");
                  }
                  WebComp_Docoperadorwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocoperadorwc), StringUtil.Lower( WebComp_Docoperadorwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title7"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocanexo_title_Internalname, "Doc Anexo", "", "", lblDocanexo_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DocAnexo") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledocanexo_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0081"+"", StringUtil.RTrim( WebComp_Docanexowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0081"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Docanexowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocanexowc), StringUtil.Lower( WebComp_Docanexowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0081"+"");
                  }
                  WebComp_Docanexowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDocanexowc), StringUtil.Lower( WebComp_Docanexowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title8"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRevisaolog_title_Internalname, "Revisao Log", "", "", lblRevisaolog_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "RevisaoLog") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel8"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablerevisaolog_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0089"+"", StringUtil.RTrim( WebComp_Revisaologwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0089"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Revisaologwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRevisaologwc), StringUtil.Lower( WebComp_Revisaologwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0089"+"");
                  }
                  WebComp_Revisaologwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRevisaologwc), StringUtil.Lower( WebComp_Revisaologwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START632( )
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
            Form.Meta.addItem("description", "Documento View", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP630( ) ;
      }

      protected void WS632( )
      {
         START632( ) ;
         EVT632( ) ;
      }

      protected void EVT632( )
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
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11632 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12632 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13632 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 19 )
                        {
                           OldWebcomponent_general = cgiGet( "W0019");
                           if ( ( StringUtil.Len( OldWebcomponent_general) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_general, WebComp_Webcomponent_general_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_general, new Object[] {context} );
                              WebComp_Webcomponent_general.ComponentInit();
                              WebComp_Webcomponent_general.Name = "OldWebcomponent_general";
                              WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
                           {
                              WebComp_Webcomponent_general.componentprocess("W0019", "", sEvt);
                           }
                           WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                        }
                        else if ( nCmpId == 33 )
                        {
                           OldDocenvolvidoscoletawc = cgiGet( "W0033");
                           if ( ( StringUtil.Len( OldDocenvolvidoscoletawc) == 0 ) || ( StringUtil.StrCmp(OldDocenvolvidoscoletawc, WebComp_Docenvolvidoscoletawc_Component) != 0 ) )
                           {
                              WebComp_Docenvolvidoscoletawc = getWebComponent(GetType(), "GeneXus.Programs", OldDocenvolvidoscoletawc, new Object[] {context} );
                              WebComp_Docenvolvidoscoletawc.ComponentInit();
                              WebComp_Docenvolvidoscoletawc.Name = "OldDocenvolvidoscoletawc";
                              WebComp_Docenvolvidoscoletawc_Component = OldDocenvolvidoscoletawc;
                           }
                           if ( StringUtil.Len( WebComp_Docenvolvidoscoletawc_Component) != 0 )
                           {
                              WebComp_Docenvolvidoscoletawc.componentprocess("W0033", "", sEvt);
                           }
                           WebComp_Docenvolvidoscoletawc_Component = OldDocenvolvidoscoletawc;
                        }
                        else if ( nCmpId == 41 )
                        {
                           OldDoccompartinternowc = cgiGet( "W0041");
                           if ( ( StringUtil.Len( OldDoccompartinternowc) == 0 ) || ( StringUtil.StrCmp(OldDoccompartinternowc, WebComp_Doccompartinternowc_Component) != 0 ) )
                           {
                              WebComp_Doccompartinternowc = getWebComponent(GetType(), "GeneXus.Programs", OldDoccompartinternowc, new Object[] {context} );
                              WebComp_Doccompartinternowc.ComponentInit();
                              WebComp_Doccompartinternowc.Name = "OldDoccompartinternowc";
                              WebComp_Doccompartinternowc_Component = OldDoccompartinternowc;
                           }
                           if ( StringUtil.Len( WebComp_Doccompartinternowc_Component) != 0 )
                           {
                              WebComp_Doccompartinternowc.componentprocess("W0041", "", sEvt);
                           }
                           WebComp_Doccompartinternowc_Component = OldDoccompartinternowc;
                        }
                        else if ( nCmpId == 49 )
                        {
                           OldDocsetorinternowc = cgiGet( "W0049");
                           if ( ( StringUtil.Len( OldDocsetorinternowc) == 0 ) || ( StringUtil.StrCmp(OldDocsetorinternowc, WebComp_Docsetorinternowc_Component) != 0 ) )
                           {
                              WebComp_Docsetorinternowc = getWebComponent(GetType(), "GeneXus.Programs", OldDocsetorinternowc, new Object[] {context} );
                              WebComp_Docsetorinternowc.ComponentInit();
                              WebComp_Docsetorinternowc.Name = "OldDocsetorinternowc";
                              WebComp_Docsetorinternowc_Component = OldDocsetorinternowc;
                           }
                           if ( StringUtil.Len( WebComp_Docsetorinternowc_Component) != 0 )
                           {
                              WebComp_Docsetorinternowc.componentprocess("W0049", "", sEvt);
                           }
                           WebComp_Docsetorinternowc_Component = OldDocsetorinternowc;
                        }
                        else if ( nCmpId == 57 )
                        {
                           OldDocfonteretencaowc = cgiGet( "W0057");
                           if ( ( StringUtil.Len( OldDocfonteretencaowc) == 0 ) || ( StringUtil.StrCmp(OldDocfonteretencaowc, WebComp_Docfonteretencaowc_Component) != 0 ) )
                           {
                              WebComp_Docfonteretencaowc = getWebComponent(GetType(), "GeneXus.Programs", OldDocfonteretencaowc, new Object[] {context} );
                              WebComp_Docfonteretencaowc.ComponentInit();
                              WebComp_Docfonteretencaowc.Name = "OldDocfonteretencaowc";
                              WebComp_Docfonteretencaowc_Component = OldDocfonteretencaowc;
                           }
                           if ( StringUtil.Len( WebComp_Docfonteretencaowc_Component) != 0 )
                           {
                              WebComp_Docfonteretencaowc.componentprocess("W0057", "", sEvt);
                           }
                           WebComp_Docfonteretencaowc_Component = OldDocfonteretencaowc;
                        }
                        else if ( nCmpId == 65 )
                        {
                           OldDocdicionariowc = cgiGet( "W0065");
                           if ( ( StringUtil.Len( OldDocdicionariowc) == 0 ) || ( StringUtil.StrCmp(OldDocdicionariowc, WebComp_Docdicionariowc_Component) != 0 ) )
                           {
                              WebComp_Docdicionariowc = getWebComponent(GetType(), "GeneXus.Programs", OldDocdicionariowc, new Object[] {context} );
                              WebComp_Docdicionariowc.ComponentInit();
                              WebComp_Docdicionariowc.Name = "OldDocdicionariowc";
                              WebComp_Docdicionariowc_Component = OldDocdicionariowc;
                           }
                           if ( StringUtil.Len( WebComp_Docdicionariowc_Component) != 0 )
                           {
                              WebComp_Docdicionariowc.componentprocess("W0065", "", sEvt);
                           }
                           WebComp_Docdicionariowc_Component = OldDocdicionariowc;
                        }
                        else if ( nCmpId == 73 )
                        {
                           OldDocoperadorwc = cgiGet( "W0073");
                           if ( ( StringUtil.Len( OldDocoperadorwc) == 0 ) || ( StringUtil.StrCmp(OldDocoperadorwc, WebComp_Docoperadorwc_Component) != 0 ) )
                           {
                              WebComp_Docoperadorwc = getWebComponent(GetType(), "GeneXus.Programs", OldDocoperadorwc, new Object[] {context} );
                              WebComp_Docoperadorwc.ComponentInit();
                              WebComp_Docoperadorwc.Name = "OldDocoperadorwc";
                              WebComp_Docoperadorwc_Component = OldDocoperadorwc;
                           }
                           if ( StringUtil.Len( WebComp_Docoperadorwc_Component) != 0 )
                           {
                              WebComp_Docoperadorwc.componentprocess("W0073", "", sEvt);
                           }
                           WebComp_Docoperadorwc_Component = OldDocoperadorwc;
                        }
                        else if ( nCmpId == 81 )
                        {
                           OldDocanexowc = cgiGet( "W0081");
                           if ( ( StringUtil.Len( OldDocanexowc) == 0 ) || ( StringUtil.StrCmp(OldDocanexowc, WebComp_Docanexowc_Component) != 0 ) )
                           {
                              WebComp_Docanexowc = getWebComponent(GetType(), "GeneXus.Programs", OldDocanexowc, new Object[] {context} );
                              WebComp_Docanexowc.ComponentInit();
                              WebComp_Docanexowc.Name = "OldDocanexowc";
                              WebComp_Docanexowc_Component = OldDocanexowc;
                           }
                           if ( StringUtil.Len( WebComp_Docanexowc_Component) != 0 )
                           {
                              WebComp_Docanexowc.componentprocess("W0081", "", sEvt);
                           }
                           WebComp_Docanexowc_Component = OldDocanexowc;
                        }
                        else if ( nCmpId == 89 )
                        {
                           OldRevisaologwc = cgiGet( "W0089");
                           if ( ( StringUtil.Len( OldRevisaologwc) == 0 ) || ( StringUtil.StrCmp(OldRevisaologwc, WebComp_Revisaologwc_Component) != 0 ) )
                           {
                              WebComp_Revisaologwc = getWebComponent(GetType(), "GeneXus.Programs", OldRevisaologwc, new Object[] {context} );
                              WebComp_Revisaologwc.ComponentInit();
                              WebComp_Revisaologwc.Name = "OldRevisaologwc";
                              WebComp_Revisaologwc_Component = OldRevisaologwc;
                           }
                           if ( StringUtil.Len( WebComp_Revisaologwc_Component) != 0 )
                           {
                              WebComp_Revisaologwc.componentprocess("W0089", "", sEvt);
                           }
                           WebComp_Revisaologwc_Component = OldRevisaologwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE632( )
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

      protected void PA632( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documentoview.aspx")), "documentoview.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documentoview.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "DocumentoId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10DocumentoId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
                     AssignAttri("", false, "AV10DocumentoId", StringUtil.LTrimStr( (decimal)(AV10DocumentoId), 8, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10DocumentoId), "ZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV8TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV8TabCode", AV8TabCode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
                     }
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF632( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF632( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  WebComp_Webcomponent_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Docenvolvidoscoletawc_Component) != 0 )
               {
                  WebComp_Docenvolvidoscoletawc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Doccompartinternowc_Component) != 0 )
               {
                  WebComp_Doccompartinternowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Docsetorinternowc_Component) != 0 )
               {
                  WebComp_Docsetorinternowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Docfonteretencaowc_Component) != 0 )
               {
                  WebComp_Docfonteretencaowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Docdicionariowc_Component) != 0 )
               {
                  WebComp_Docdicionariowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Docoperadorwc_Component) != 0 )
               {
                  WebComp_Docoperadorwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Docanexowc_Component) != 0 )
               {
                  WebComp_Docanexowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Revisaologwc_Component) != 0 )
               {
                  WebComp_Revisaologwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13632 ();
            WB630( ) ;
         }
      }

      protected void send_integrity_lvl_hashes632( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP630( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12632 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Panel_general_Width = cgiGet( "PANEL_GENERAL_Width");
            Panel_general_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autowidth"));
            Panel_general_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoheight"));
            Panel_general_Cls = cgiGet( "PANEL_GENERAL_Cls");
            Panel_general_Title = cgiGet( "PANEL_GENERAL_Title");
            Panel_general_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsible"));
            Panel_general_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsed"));
            Panel_general_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Showcollapseicon"));
            Panel_general_Iconposition = cgiGet( "PANEL_GENERAL_Iconposition");
            Panel_general_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoscroll"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), ",", "."));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12632 ();
         if (returnInSub) return;
      }

      protected void E12632( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         lblWorkwithlink_Link = formatLink("documentoww.aspx") ;
         AssignProp("", false, lblWorkwithlink_Internalname, "Link", lblWorkwithlink_Link, true);
         AV16GXLvl9 = 0;
         /* Using cursor H00632 */
         pr_default.execute(0, new Object[] {AV10DocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = H00632_A75DocumentoId[0];
            A76DocumentoNome = H00632_A76DocumentoNome[0];
            n76DocumentoNome = H00632_n76DocumentoNome[0];
            AV16GXLvl9 = 1;
            Form.Caption = A76DocumentoNome;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV16GXLvl9 == 0 )
         {
            Form.Caption = "Registro não encontrado";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV12SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
            Tabs_Activepagecontrolname = AV12SelectedTabCode;
            ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
            /* Execute user subroutine: 'LOADFIXEDTABS' */
            S112 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'LOADTABS' */
            S122 ();
            if (returnInSub) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13632( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E11632( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV12SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
         AV11LoadAllTabs = false;
         AssignAttri("", false, "AV11LoadAllTabs", AV11LoadAllTabs);
         /* Execute user subroutine: 'LOADTABS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADFIXEDTABS' Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_general = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_general_Component), StringUtil.Lower( "DocumentoGeneral")) != 0 )
         {
            WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", "documentogeneral", new Object[] {context} );
            WebComp_Webcomponent_general.ComponentInit();
            WebComp_Webcomponent_general.Name = "DocumentoGeneral";
            WebComp_Webcomponent_general_Component = "DocumentoGeneral";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
         {
            WebComp_Webcomponent_general.setjustcreated();
            WebComp_Webcomponent_general.componentprepare(new Object[] {(string)"W0019",(string)"",(int)AV10DocumentoId});
            WebComp_Webcomponent_general.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_general )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
            WebComp_Webcomponent_general.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      protected void S122( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocEnvolvidosColeta") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Docenvolvidoscoletawc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Docenvolvidoscoletawc_Component), StringUtil.Lower( "DocumentoDocEnvolvidosColetaWC")) != 0 )
            {
               WebComp_Docenvolvidoscoletawc = getWebComponent(GetType(), "GeneXus.Programs", "documentodocenvolvidoscoletawc", new Object[] {context} );
               WebComp_Docenvolvidoscoletawc.ComponentInit();
               WebComp_Docenvolvidoscoletawc.Name = "DocumentoDocEnvolvidosColetaWC";
               WebComp_Docenvolvidoscoletawc_Component = "DocumentoDocEnvolvidosColetaWC";
            }
            if ( StringUtil.Len( WebComp_Docenvolvidoscoletawc_Component) != 0 )
            {
               WebComp_Docenvolvidoscoletawc.setjustcreated();
               WebComp_Docenvolvidoscoletawc.componentprepare(new Object[] {(string)"W0033",(string)"",(int)AV10DocumentoId});
               WebComp_Docenvolvidoscoletawc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Docenvolvidoscoletawc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
               WebComp_Docenvolvidoscoletawc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocCompartInterno") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Doccompartinternowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Doccompartinternowc_Component), StringUtil.Lower( "DocumentoDocCompartInternoWC")) != 0 )
            {
               WebComp_Doccompartinternowc = getWebComponent(GetType(), "GeneXus.Programs", "documentodoccompartinternowc", new Object[] {context} );
               WebComp_Doccompartinternowc.ComponentInit();
               WebComp_Doccompartinternowc.Name = "DocumentoDocCompartInternoWC";
               WebComp_Doccompartinternowc_Component = "DocumentoDocCompartInternoWC";
            }
            if ( StringUtil.Len( WebComp_Doccompartinternowc_Component) != 0 )
            {
               WebComp_Doccompartinternowc.setjustcreated();
               WebComp_Doccompartinternowc.componentprepare(new Object[] {(string)"W0041",(string)"",(int)AV10DocumentoId});
               WebComp_Doccompartinternowc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Doccompartinternowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0041"+"");
               WebComp_Doccompartinternowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocSetorInterno") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Docsetorinternowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Docsetorinternowc_Component), StringUtil.Lower( "DocumentoDocSetorInternoWC")) != 0 )
            {
               WebComp_Docsetorinternowc = getWebComponent(GetType(), "GeneXus.Programs", "documentodocsetorinternowc", new Object[] {context} );
               WebComp_Docsetorinternowc.ComponentInit();
               WebComp_Docsetorinternowc.Name = "DocumentoDocSetorInternoWC";
               WebComp_Docsetorinternowc_Component = "DocumentoDocSetorInternoWC";
            }
            if ( StringUtil.Len( WebComp_Docsetorinternowc_Component) != 0 )
            {
               WebComp_Docsetorinternowc.setjustcreated();
               WebComp_Docsetorinternowc.componentprepare(new Object[] {(string)"W0049",(string)"",(int)AV10DocumentoId});
               WebComp_Docsetorinternowc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Docsetorinternowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
               WebComp_Docsetorinternowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocFonteRetencao") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Docfonteretencaowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Docfonteretencaowc_Component), StringUtil.Lower( "DocumentoDocFonteRetencaoWC")) != 0 )
            {
               WebComp_Docfonteretencaowc = getWebComponent(GetType(), "GeneXus.Programs", "documentodocfonteretencaowc", new Object[] {context} );
               WebComp_Docfonteretencaowc.ComponentInit();
               WebComp_Docfonteretencaowc.Name = "DocumentoDocFonteRetencaoWC";
               WebComp_Docfonteretencaowc_Component = "DocumentoDocFonteRetencaoWC";
            }
            if ( StringUtil.Len( WebComp_Docfonteretencaowc_Component) != 0 )
            {
               WebComp_Docfonteretencaowc.setjustcreated();
               WebComp_Docfonteretencaowc.componentprepare(new Object[] {(string)"W0057",(string)"",(int)AV10DocumentoId});
               WebComp_Docfonteretencaowc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Docfonteretencaowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0057"+"");
               WebComp_Docfonteretencaowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocDicionario") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Docdicionariowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Docdicionariowc_Component), StringUtil.Lower( "DocumentoDocDicionarioWC")) != 0 )
            {
               WebComp_Docdicionariowc = getWebComponent(GetType(), "GeneXus.Programs", "documentodocdicionariowc", new Object[] {context} );
               WebComp_Docdicionariowc.ComponentInit();
               WebComp_Docdicionariowc.Name = "DocumentoDocDicionarioWC";
               WebComp_Docdicionariowc_Component = "DocumentoDocDicionarioWC";
            }
            if ( StringUtil.Len( WebComp_Docdicionariowc_Component) != 0 )
            {
               WebComp_Docdicionariowc.setjustcreated();
               WebComp_Docdicionariowc.componentprepare(new Object[] {(string)"W0065",(string)"",(int)AV10DocumentoId});
               WebComp_Docdicionariowc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Docdicionariowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0065"+"");
               WebComp_Docdicionariowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocOperador") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Docoperadorwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Docoperadorwc_Component), StringUtil.Lower( "DocumentoDocOperadorWC")) != 0 )
            {
               WebComp_Docoperadorwc = getWebComponent(GetType(), "GeneXus.Programs", "documentodocoperadorwc", new Object[] {context} );
               WebComp_Docoperadorwc.ComponentInit();
               WebComp_Docoperadorwc.Name = "DocumentoDocOperadorWC";
               WebComp_Docoperadorwc_Component = "DocumentoDocOperadorWC";
            }
            if ( StringUtil.Len( WebComp_Docoperadorwc_Component) != 0 )
            {
               WebComp_Docoperadorwc.setjustcreated();
               WebComp_Docoperadorwc.componentprepare(new Object[] {(string)"W0073",(string)"",(int)AV10DocumentoId});
               WebComp_Docoperadorwc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Docoperadorwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0073"+"");
               WebComp_Docoperadorwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "DocAnexo") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Docanexowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Docanexowc_Component), StringUtil.Lower( "DocumentoDocAnexoWC")) != 0 )
            {
               WebComp_Docanexowc = getWebComponent(GetType(), "GeneXus.Programs", "documentodocanexowc", new Object[] {context} );
               WebComp_Docanexowc.ComponentInit();
               WebComp_Docanexowc.Name = "DocumentoDocAnexoWC";
               WebComp_Docanexowc_Component = "DocumentoDocAnexoWC";
            }
            if ( StringUtil.Len( WebComp_Docanexowc_Component) != 0 )
            {
               WebComp_Docanexowc.setjustcreated();
               WebComp_Docanexowc.componentprepare(new Object[] {(string)"W0081",(string)"",(int)AV10DocumentoId});
               WebComp_Docanexowc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Docanexowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0081"+"");
               WebComp_Docanexowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "RevisaoLog") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Revisaologwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Revisaologwc_Component), StringUtil.Lower( "DocumentoRevisaoLogWC")) != 0 )
            {
               WebComp_Revisaologwc = getWebComponent(GetType(), "GeneXus.Programs", "documentorevisaologwc", new Object[] {context} );
               WebComp_Revisaologwc.ComponentInit();
               WebComp_Revisaologwc.Name = "DocumentoRevisaoLogWC";
               WebComp_Revisaologwc_Component = "DocumentoRevisaoLogWC";
            }
            if ( StringUtil.Len( WebComp_Revisaologwc_Component) != 0 )
            {
               WebComp_Revisaologwc.setjustcreated();
               WebComp_Revisaologwc.componentprepare(new Object[] {(string)"W0089",(string)"",(int)AV10DocumentoId});
               WebComp_Revisaologwc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Revisaologwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0089"+"");
               WebComp_Revisaologwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10DocumentoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV10DocumentoId", StringUtil.LTrimStr( (decimal)(AV10DocumentoId), 8, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10DocumentoId), "ZZZZZZZ9"), context));
         AV8TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA632( ) ;
         WS632( ) ;
         WE632( ) ;
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
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
            {
               WebComp_Webcomponent_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Docenvolvidoscoletawc == null ) )
         {
            if ( StringUtil.Len( WebComp_Docenvolvidoscoletawc_Component) != 0 )
            {
               WebComp_Docenvolvidoscoletawc.componentthemes();
            }
         }
         if ( ! ( WebComp_Doccompartinternowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Doccompartinternowc_Component) != 0 )
            {
               WebComp_Doccompartinternowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Docsetorinternowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Docsetorinternowc_Component) != 0 )
            {
               WebComp_Docsetorinternowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Docfonteretencaowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Docfonteretencaowc_Component) != 0 )
            {
               WebComp_Docfonteretencaowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Docdicionariowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Docdicionariowc_Component) != 0 )
            {
               WebComp_Docdicionariowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Docoperadorwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Docoperadorwc_Component) != 0 )
            {
               WebComp_Docoperadorwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Docanexowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Docanexowc_Component) != 0 )
            {
               WebComp_Docanexowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Revisaologwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Revisaologwc_Component) != 0 )
            {
               WebComp_Revisaologwc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417265767", true, true);
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
         context.AddJavascriptSource("documentoview.js", "?202312417265768", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWorkwithlink_Internalname = "WORKWITHLINK";
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         divTablepanel_general_Internalname = "TABLEPANEL_GENERAL";
         Panel_general_Internalname = "PANEL_GENERAL";
         divDocumentogeneral_cell_Internalname = "DOCUMENTOGENERAL_CELL";
         lblDocenvolvidoscoleta_title_Internalname = "DOCENVOLVIDOSCOLETA_TITLE";
         divUnnamedtabledocenvolvidoscoleta_Internalname = "UNNAMEDTABLEDOCENVOLVIDOSCOLETA";
         lblDoccompartinterno_title_Internalname = "DOCCOMPARTINTERNO_TITLE";
         divUnnamedtabledoccompartinterno_Internalname = "UNNAMEDTABLEDOCCOMPARTINTERNO";
         lblDocsetorinterno_title_Internalname = "DOCSETORINTERNO_TITLE";
         divUnnamedtabledocsetorinterno_Internalname = "UNNAMEDTABLEDOCSETORINTERNO";
         lblDocfonteretencao_title_Internalname = "DOCFONTERETENCAO_TITLE";
         divUnnamedtabledocfonteretencao_Internalname = "UNNAMEDTABLEDOCFONTERETENCAO";
         lblDocdicionario_title_Internalname = "DOCDICIONARIO_TITLE";
         divUnnamedtabledocdicionario_Internalname = "UNNAMEDTABLEDOCDICIONARIO";
         lblDocoperador_title_Internalname = "DOCOPERADOR_TITLE";
         divUnnamedtabledocoperador_Internalname = "UNNAMEDTABLEDOCOPERADOR";
         lblDocanexo_title_Internalname = "DOCANEXO_TITLE";
         divUnnamedtabledocanexo_Internalname = "UNNAMEDTABLEDOCANEXO";
         lblRevisaolog_title_Internalname = "REVISAOLOG_TITLE";
         divUnnamedtablerevisaolog_Internalname = "UNNAMEDTABLEREVISAOLOG";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblWorkwithlink_Link = "";
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 8;
         Panel_general_Autoscroll = Convert.ToBoolean( 0);
         Panel_general_Iconposition = "Right";
         Panel_general_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_general_Collapsed = Convert.ToBoolean( 0);
         Panel_general_Collapsible = Convert.ToBoolean( -1);
         Panel_general_Title = "Informações Gerais";
         Panel_general_Cls = "PanelCard Panel_BaseColor";
         Panel_general_Autoheight = Convert.ToBoolean( -1);
         Panel_general_Autowidth = Convert.ToBoolean( 0);
         Panel_general_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Documento View";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("TABS.TABCHANGED","{handler:'E11632',iparms:[{av:'Tabs_Activepagecontrolname',ctrl:'TABS',prop:'ActivePageControlName'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{av:'AV12SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV10DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("TABS.TABCHANGED",",oparms:[{av:'AV12SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{ctrl:'DOCENVOLVIDOSCOLETAWC'},{ctrl:'DOCCOMPARTINTERNOWC'},{ctrl:'DOCSETORINTERNOWC'},{ctrl:'DOCFONTERETENCAOWC'},{ctrl:'DOCDICIONARIOWC'},{ctrl:'DOCOPERADORWC'},{ctrl:'DOCANEXOWC'},{ctrl:'REVISAOLOGWC'}]}");
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
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV12SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblWorkwithlink_Jsonclick = "";
         ucPanel_general = new GXUserControl();
         WebComp_Webcomponent_general_Component = "";
         OldWebcomponent_general = "";
         ucTabs = new GXUserControl();
         lblDocenvolvidoscoleta_title_Jsonclick = "";
         WebComp_Docenvolvidoscoletawc_Component = "";
         OldDocenvolvidoscoletawc = "";
         lblDoccompartinterno_title_Jsonclick = "";
         WebComp_Doccompartinternowc_Component = "";
         OldDoccompartinternowc = "";
         lblDocsetorinterno_title_Jsonclick = "";
         WebComp_Docsetorinternowc_Component = "";
         OldDocsetorinternowc = "";
         lblDocfonteretencao_title_Jsonclick = "";
         WebComp_Docfonteretencaowc_Component = "";
         OldDocfonteretencaowc = "";
         lblDocdicionario_title_Jsonclick = "";
         WebComp_Docdicionariowc_Component = "";
         OldDocdicionariowc = "";
         lblDocoperador_title_Jsonclick = "";
         WebComp_Docoperadorwc_Component = "";
         OldDocoperadorwc = "";
         lblDocanexo_title_Jsonclick = "";
         WebComp_Docanexowc_Component = "";
         OldDocanexowc = "";
         lblRevisaolog_title_Jsonclick = "";
         WebComp_Revisaologwc_Component = "";
         OldRevisaologwc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         H00632_A75DocumentoId = new int[1] ;
         H00632_A76DocumentoNome = new string[] {""} ;
         H00632_n76DocumentoNome = new bool[] {false} ;
         A76DocumentoNome = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoview__default(),
            new Object[][] {
                new Object[] {
               H00632_A75DocumentoId, H00632_A76DocumentoNome, H00632_n76DocumentoNome
               }
            }
         );
         WebComp_Webcomponent_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Docenvolvidoscoletawc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Doccompartinternowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Docsetorinternowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Docfonteretencaowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Docdicionariowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Docoperadorwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Docanexowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Revisaologwc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV16GXLvl9 ;
      private short nGXWrapped ;
      private int AV10DocumentoId ;
      private int wcpOAV10DocumentoId ;
      private int Tabs_Pagecount ;
      private int A75DocumentoId ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV12SelectedTabCode ;
      private string Panel_general_Width ;
      private string Panel_general_Cls ;
      private string Panel_general_Title ;
      private string Panel_general_Iconposition ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string lblWorkwithlink_Internalname ;
      private string lblWorkwithlink_Link ;
      private string lblWorkwithlink_Jsonclick ;
      private string divDocumentogeneral_cell_Internalname ;
      private string Panel_general_Internalname ;
      private string divTablepanel_general_Internalname ;
      private string WebComp_Webcomponent_general_Component ;
      private string OldWebcomponent_general ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblDocenvolvidoscoleta_title_Internalname ;
      private string lblDocenvolvidoscoleta_title_Jsonclick ;
      private string divUnnamedtabledocenvolvidoscoleta_Internalname ;
      private string WebComp_Docenvolvidoscoletawc_Component ;
      private string OldDocenvolvidoscoletawc ;
      private string lblDoccompartinterno_title_Internalname ;
      private string lblDoccompartinterno_title_Jsonclick ;
      private string divUnnamedtabledoccompartinterno_Internalname ;
      private string WebComp_Doccompartinternowc_Component ;
      private string OldDoccompartinternowc ;
      private string lblDocsetorinterno_title_Internalname ;
      private string lblDocsetorinterno_title_Jsonclick ;
      private string divUnnamedtabledocsetorinterno_Internalname ;
      private string WebComp_Docsetorinternowc_Component ;
      private string OldDocsetorinternowc ;
      private string lblDocfonteretencao_title_Internalname ;
      private string lblDocfonteretencao_title_Jsonclick ;
      private string divUnnamedtabledocfonteretencao_Internalname ;
      private string WebComp_Docfonteretencaowc_Component ;
      private string OldDocfonteretencaowc ;
      private string lblDocdicionario_title_Internalname ;
      private string lblDocdicionario_title_Jsonclick ;
      private string divUnnamedtabledocdicionario_Internalname ;
      private string WebComp_Docdicionariowc_Component ;
      private string OldDocdicionariowc ;
      private string lblDocoperador_title_Internalname ;
      private string lblDocoperador_title_Jsonclick ;
      private string divUnnamedtabledocoperador_Internalname ;
      private string WebComp_Docoperadorwc_Component ;
      private string OldDocoperadorwc ;
      private string lblDocanexo_title_Internalname ;
      private string lblDocanexo_title_Jsonclick ;
      private string divUnnamedtabledocanexo_Internalname ;
      private string WebComp_Docanexowc_Component ;
      private string OldDocanexowc ;
      private string lblRevisaolog_title_Internalname ;
      private string lblRevisaolog_title_Jsonclick ;
      private string divUnnamedtablerevisaolog_Internalname ;
      private string WebComp_Revisaologwc_Component ;
      private string OldRevisaologwc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Panel_general_Autowidth ;
      private bool Panel_general_Autoheight ;
      private bool Panel_general_Collapsible ;
      private bool Panel_general_Collapsed ;
      private bool Panel_general_Showcollapseicon ;
      private bool Panel_general_Autoscroll ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n76DocumentoNome ;
      private bool AV9Exists ;
      private bool bDynCreated_Webcomponent_general ;
      private bool bDynCreated_Docenvolvidoscoletawc ;
      private bool bDynCreated_Doccompartinternowc ;
      private bool bDynCreated_Docsetorinternowc ;
      private bool bDynCreated_Docfonteretencaowc ;
      private bool bDynCreated_Docdicionariowc ;
      private bool bDynCreated_Docoperadorwc ;
      private bool bDynCreated_Docanexowc ;
      private bool bDynCreated_Revisaologwc ;
      private string A76DocumentoNome ;
      private GXWebComponent WebComp_Webcomponent_general ;
      private GXWebComponent WebComp_Docenvolvidoscoletawc ;
      private GXWebComponent WebComp_Doccompartinternowc ;
      private GXWebComponent WebComp_Docsetorinternowc ;
      private GXWebComponent WebComp_Docfonteretencaowc ;
      private GXWebComponent WebComp_Docdicionariowc ;
      private GXWebComponent WebComp_Docoperadorwc ;
      private GXWebComponent WebComp_Docanexowc ;
      private GXWebComponent WebComp_Revisaologwc ;
      private GXUserControl ucPanel_general ;
      private GXUserControl ucTabs ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H00632_A75DocumentoId ;
      private string[] H00632_A76DocumentoNome ;
      private bool[] H00632_n76DocumentoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class documentoview__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00632;
          prmH00632 = new Object[] {
          new ParDef("@AV10DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00632", "SELECT [DocumentoId], [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @AV10DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00632,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
