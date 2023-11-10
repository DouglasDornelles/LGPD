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
   public class documentocadastrowp : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public documentocadastrowp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentocadastrowp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocumentoId ,
                           bool aP2_IsInserido )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8DocumentoId = aP1_DocumentoId;
         this.AV9IsInserido = aP2_IsInserido;
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
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
            return "documentocadastrowp_Execute" ;
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
         PA7A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7A2( ) ;
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
         GXEncryptionTmp = "documentocadastrowp.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV9IsInserido));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISINSERIDO", GetSecureSignedToken( "", AV9IsInserido, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISINSERIDO", AV9IsInserido);
         GxWebStd.gx_hidden_field( context, "gxhash_vISINSERIDO", GetSecureSignedToken( "", AV9IsInserido, context));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Width", StringUtil.RTrim( Dvpanel_panelcadastro_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Autowidth", StringUtil.BoolToStr( Dvpanel_panelcadastro_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Autoheight", StringUtil.BoolToStr( Dvpanel_panelcadastro_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Cls", StringUtil.RTrim( Dvpanel_panelcadastro_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Title", StringUtil.RTrim( Dvpanel_panelcadastro_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Collapsible", StringUtil.BoolToStr( Dvpanel_panelcadastro_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Collapsed", StringUtil.BoolToStr( Dvpanel_panelcadastro_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panelcadastro_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Iconposition", StringUtil.RTrim( Dvpanel_panelcadastro_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCADASTRO_Autoscroll", StringUtil.BoolToStr( Dvpanel_panelcadastro_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Activepage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Activepage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Activepage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Activepage), 9, 0, ".", "")));
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
         if ( ! ( WebComp_Wcdocumentowc == null ) )
         {
            WebComp_Wcdocumentowc.componentjscripts();
         }
         if ( ! ( WebComp_Wctratamentowc == null ) )
         {
            WebComp_Wctratamentowc.componentjscripts();
         }
         if ( ! ( WebComp_Wcanexowc == null ) )
         {
            WebComp_Wcanexowc.componentjscripts();
         }
         if ( ! ( WebComp_Wcdicionariowc == null ) )
         {
            WebComp_Wcdicionariowc.componentjscripts();
         }
         if ( ! ( WebComp_Wcoperadorwc == null ) )
         {
            WebComp_Wcoperadorwc.componentjscripts();
         }
         if ( ! ( WebComp_Wcrevisaowc == null ) )
         {
            WebComp_Wcrevisaowc.componentjscripts();
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
            WE7A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7A2( ) ;
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
         GXEncryptionTmp = "documentocadastrowp.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV9IsInserido));
         return formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "DocumentoCadastroWP" ;
      }

      public override string GetPgmdesc( )
      {
         return "" ;
      }

      protected void WB7A0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panelcadastro.SetProperty("Width", Dvpanel_panelcadastro_Width);
            ucDvpanel_panelcadastro.SetProperty("AutoWidth", Dvpanel_panelcadastro_Autowidth);
            ucDvpanel_panelcadastro.SetProperty("AutoHeight", Dvpanel_panelcadastro_Autoheight);
            ucDvpanel_panelcadastro.SetProperty("Cls", Dvpanel_panelcadastro_Cls);
            ucDvpanel_panelcadastro.SetProperty("Title", Dvpanel_panelcadastro_Title);
            ucDvpanel_panelcadastro.SetProperty("Collapsible", Dvpanel_panelcadastro_Collapsible);
            ucDvpanel_panelcadastro.SetProperty("Collapsed", Dvpanel_panelcadastro_Collapsed);
            ucDvpanel_panelcadastro.SetProperty("ShowCollapseIcon", Dvpanel_panelcadastro_Showcollapseicon);
            ucDvpanel_panelcadastro.SetProperty("IconPosition", Dvpanel_panelcadastro_Iconposition);
            ucDvpanel_panelcadastro.SetProperty("AutoScroll", Dvpanel_panelcadastro_Autoscroll);
            ucDvpanel_panelcadastro.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panelcadastro_Internalname, "DVPANEL_PANELCADASTROContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANELCADASTROContainer"+"PanelCadastro"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanelcadastro_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabdocumento_title_Internalname, "DOCUMENTO", "", "", lblTabdocumento_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoCadastroWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabDocumento") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0028"+"", StringUtil.RTrim( WebComp_Wcdocumentowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0028"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcdocumentowc), StringUtil.Lower( WebComp_Wcdocumentowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0028"+"");
                  }
                  WebComp_Wcdocumentowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcdocumentowc), StringUtil.Lower( WebComp_Wcdocumentowc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabtratamento_title_Internalname, "TRATAMENTO", "", "", lblTabtratamento_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoCadastroWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabTratamento") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0036"+"", StringUtil.RTrim( WebComp_Wctratamentowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0036"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wctratamentowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWctratamentowc), StringUtil.Lower( WebComp_Wctratamentowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0036"+"");
                  }
                  WebComp_Wctratamentowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWctratamentowc), StringUtil.Lower( WebComp_Wctratamentowc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabanexos_title_Internalname, "ANEXOS", "", "", lblTabanexos_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoCadastroWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabAnexos") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0044"+"", StringUtil.RTrim( WebComp_Wcanexowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0044"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcanexowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcanexowc), StringUtil.Lower( WebComp_Wcanexowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0044"+"");
                  }
                  WebComp_Wcanexowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcanexowc), StringUtil.Lower( WebComp_Wcanexowc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabdicionario_title_Internalname, "DICIONÁRIO", "", "", lblTabdicionario_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoCadastroWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabDicionario") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0052"+"", StringUtil.RTrim( WebComp_Wcdicionariowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0052"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcdicionariowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcdicionariowc), StringUtil.Lower( WebComp_Wcdicionariowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
                  }
                  WebComp_Wcdicionariowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcdicionariowc), StringUtil.Lower( WebComp_Wcdicionariowc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTaboperador_title_Internalname, "OPERADOR(ES)", "", "", lblTaboperador_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoCadastroWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabOperador") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Wcoperadorwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcoperadorwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcoperadorwc), StringUtil.Lower( WebComp_Wcoperadorwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                  }
                  WebComp_Wcoperadorwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcoperadorwc), StringUtil.Lower( WebComp_Wcoperadorwc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabrevisao_title_Internalname, "REVISÕES", "", "", lblTabrevisao_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoCadastroWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabRevisao") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0068"+"", StringUtil.RTrim( WebComp_Wcrevisaowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0068"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcrevisaowc), StringUtil.Lower( WebComp_Wcrevisaowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
                  }
                  WebComp_Wcrevisaowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcrevisaowc), StringUtil.Lower( WebComp_Wcrevisaowc_Component)) != 0 )
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

      protected void START7A2( )
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
            Form.Meta.addItem("description", "", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7A0( ) ;
      }

      protected void WS7A2( )
      {
         START7A2( ) ;
         EVT7A2( ) ;
      }

      protected void EVT7A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GXUITABSPANEL_TABS1.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E117A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E127A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E137A2 ();
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
                        if ( nCmpId == 28 )
                        {
                           OldWcdocumentowc = cgiGet( "W0028");
                           if ( ( StringUtil.Len( OldWcdocumentowc) == 0 ) || ( StringUtil.StrCmp(OldWcdocumentowc, WebComp_Wcdocumentowc_Component) != 0 ) )
                           {
                              WebComp_Wcdocumentowc = getWebComponent(GetType(), "GeneXus.Programs", OldWcdocumentowc, new Object[] {context} );
                              WebComp_Wcdocumentowc.ComponentInit();
                              WebComp_Wcdocumentowc.Name = "OldWcdocumentowc";
                              WebComp_Wcdocumentowc_Component = OldWcdocumentowc;
                           }
                           if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
                           {
                              WebComp_Wcdocumentowc.componentprocess("W0028", "", sEvt);
                           }
                           WebComp_Wcdocumentowc_Component = OldWcdocumentowc;
                        }
                        else if ( nCmpId == 36 )
                        {
                           OldWctratamentowc = cgiGet( "W0036");
                           if ( ( StringUtil.Len( OldWctratamentowc) == 0 ) || ( StringUtil.StrCmp(OldWctratamentowc, WebComp_Wctratamentowc_Component) != 0 ) )
                           {
                              WebComp_Wctratamentowc = getWebComponent(GetType(), "GeneXus.Programs", OldWctratamentowc, new Object[] {context} );
                              WebComp_Wctratamentowc.ComponentInit();
                              WebComp_Wctratamentowc.Name = "OldWctratamentowc";
                              WebComp_Wctratamentowc_Component = OldWctratamentowc;
                           }
                           if ( StringUtil.Len( WebComp_Wctratamentowc_Component) != 0 )
                           {
                              WebComp_Wctratamentowc.componentprocess("W0036", "", sEvt);
                           }
                           WebComp_Wctratamentowc_Component = OldWctratamentowc;
                        }
                        else if ( nCmpId == 44 )
                        {
                           OldWcanexowc = cgiGet( "W0044");
                           if ( ( StringUtil.Len( OldWcanexowc) == 0 ) || ( StringUtil.StrCmp(OldWcanexowc, WebComp_Wcanexowc_Component) != 0 ) )
                           {
                              WebComp_Wcanexowc = getWebComponent(GetType(), "GeneXus.Programs", OldWcanexowc, new Object[] {context} );
                              WebComp_Wcanexowc.ComponentInit();
                              WebComp_Wcanexowc.Name = "OldWcanexowc";
                              WebComp_Wcanexowc_Component = OldWcanexowc;
                           }
                           if ( StringUtil.Len( WebComp_Wcanexowc_Component) != 0 )
                           {
                              WebComp_Wcanexowc.componentprocess("W0044", "", sEvt);
                           }
                           WebComp_Wcanexowc_Component = OldWcanexowc;
                        }
                        else if ( nCmpId == 52 )
                        {
                           OldWcdicionariowc = cgiGet( "W0052");
                           if ( ( StringUtil.Len( OldWcdicionariowc) == 0 ) || ( StringUtil.StrCmp(OldWcdicionariowc, WebComp_Wcdicionariowc_Component) != 0 ) )
                           {
                              WebComp_Wcdicionariowc = getWebComponent(GetType(), "GeneXus.Programs", OldWcdicionariowc, new Object[] {context} );
                              WebComp_Wcdicionariowc.ComponentInit();
                              WebComp_Wcdicionariowc.Name = "OldWcdicionariowc";
                              WebComp_Wcdicionariowc_Component = OldWcdicionariowc;
                           }
                           if ( StringUtil.Len( WebComp_Wcdicionariowc_Component) != 0 )
                           {
                              WebComp_Wcdicionariowc.componentprocess("W0052", "", sEvt);
                           }
                           WebComp_Wcdicionariowc_Component = OldWcdicionariowc;
                        }
                        else if ( nCmpId == 60 )
                        {
                           OldWcoperadorwc = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldWcoperadorwc) == 0 ) || ( StringUtil.StrCmp(OldWcoperadorwc, WebComp_Wcoperadorwc_Component) != 0 ) )
                           {
                              WebComp_Wcoperadorwc = getWebComponent(GetType(), "GeneXus.Programs", OldWcoperadorwc, new Object[] {context} );
                              WebComp_Wcoperadorwc.ComponentInit();
                              WebComp_Wcoperadorwc.Name = "OldWcoperadorwc";
                              WebComp_Wcoperadorwc_Component = OldWcoperadorwc;
                           }
                           if ( StringUtil.Len( WebComp_Wcoperadorwc_Component) != 0 )
                           {
                              WebComp_Wcoperadorwc.componentprocess("W0060", "", sEvt);
                           }
                           WebComp_Wcoperadorwc_Component = OldWcoperadorwc;
                        }
                        else if ( nCmpId == 68 )
                        {
                           OldWcrevisaowc = cgiGet( "W0068");
                           if ( ( StringUtil.Len( OldWcrevisaowc) == 0 ) || ( StringUtil.StrCmp(OldWcrevisaowc, WebComp_Wcrevisaowc_Component) != 0 ) )
                           {
                              WebComp_Wcrevisaowc = getWebComponent(GetType(), "GeneXus.Programs", OldWcrevisaowc, new Object[] {context} );
                              WebComp_Wcrevisaowc.ComponentInit();
                              WebComp_Wcrevisaowc.Name = "OldWcrevisaowc";
                              WebComp_Wcrevisaowc_Component = OldWcrevisaowc;
                           }
                           if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
                           {
                              WebComp_Wcrevisaowc.componentprocess("W0068", "", sEvt);
                           }
                           WebComp_Wcrevisaowc_Component = OldWcrevisaowc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7A2( )
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

      protected void PA7A2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documentocadastrowp.aspx")), "documentocadastrowp.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documentocadastrowp.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Mode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     Gx_mode = gxfirstwebparm;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV8DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                        AssignAttri("", false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
                        AV9IsInserido = StringUtil.StrToBool( GetPar( "IsInserido"));
                        AssignAttri("", false, "AV9IsInserido", AV9IsInserido);
                        GxWebStd.gx_hidden_field( context, "gxhash_vISINSERIDO", GetSecureSignedToken( "", AV9IsInserido, context));
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
         RF7A2( ) ;
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

      protected void RF7A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
               {
                  WebComp_Wcdocumentowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctratamentowc_Component) != 0 )
               {
                  WebComp_Wctratamentowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcanexowc_Component) != 0 )
               {
                  WebComp_Wcanexowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcdicionariowc_Component) != 0 )
               {
                  WebComp_Wcdicionariowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcoperadorwc_Component) != 0 )
               {
                  WebComp_Wcoperadorwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
               {
                  WebComp_Wcrevisaowc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E137A2 ();
            WB7A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7A2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gxuitabspanel_tabs1_Pagecount = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Dvpanel_panelcadastro_Width = cgiGet( "DVPANEL_PANELCADASTRO_Width");
            Dvpanel_panelcadastro_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCADASTRO_Autowidth"));
            Dvpanel_panelcadastro_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCADASTRO_Autoheight"));
            Dvpanel_panelcadastro_Cls = cgiGet( "DVPANEL_PANELCADASTRO_Cls");
            Dvpanel_panelcadastro_Title = cgiGet( "DVPANEL_PANELCADASTRO_Title");
            Dvpanel_panelcadastro_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCADASTRO_Collapsible"));
            Dvpanel_panelcadastro_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCADASTRO_Collapsed"));
            Dvpanel_panelcadastro_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCADASTRO_Showcollapseicon"));
            Dvpanel_panelcadastro_Iconposition = cgiGet( "DVPANEL_PANELCADASTRO_Iconposition");
            Dvpanel_panelcadastro_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCADASTRO_Autoscroll"));
            Gxuitabspanel_tabs1_Activepage = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Activepage"), ",", "."));
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
         E127A2 ();
         if (returnInSub) return;
      }

      protected void E127A2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            if ( ! AV9IsInserido )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcdocumentowc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcdocumentowc_Component), StringUtil.Lower( "DocumentoWC")) != 0 )
               {
                  WebComp_Wcdocumentowc = getWebComponent(GetType(), "GeneXus.Programs", "documentowc", new Object[] {context} );
                  WebComp_Wcdocumentowc.ComponentInit();
                  WebComp_Wcdocumentowc.Name = "DocumentoWC";
                  WebComp_Wcdocumentowc_Component = "DocumentoWC";
               }
               if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
               {
                  WebComp_Wcdocumentowc.setjustcreated();
                  WebComp_Wcdocumentowc.componentprepare(new Object[] {(string)"W0028",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
                  WebComp_Wcdocumentowc.componentbind(new Object[] {(string)"",(string)""});
               }
               this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)2});
               this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)3});
               this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)4});
               this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)5});
               this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)6});
            }
            else
            {
               GXt_char1 = AV11DocumentoNome;
               new recuperadocumentonome(context ).execute(  AV8DocumentoId, out  GXt_char1) ;
               AV11DocumentoNome = GXt_char1;
               if ( StringUtil.Len( AV11DocumentoNome) > 50 )
               {
                  AV11DocumentoNome = StringUtil.Substring( AV11DocumentoNome, 1, 50);
                  AV11DocumentoNome += "...";
               }
               else
               {
                  AV11DocumentoNome = StringUtil.Substring( AV11DocumentoNome, 1, 50);
               }
               Dvpanel_panelcadastro_Title = "CADASTRO DE DOCUMENTO | "+StringUtil.Trim( StringUtil.Str( (decimal)(AV8DocumentoId), 8, 0))+" - "+AV11DocumentoNome;
               ucDvpanel_panelcadastro.SendProperty(context, "", false, Dvpanel_panelcadastro_Internalname, "Title", Dvpanel_panelcadastro_Title);
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcdocumentowc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcdocumentowc_Component), StringUtil.Lower( "DocumentoWC")) != 0 )
               {
                  WebComp_Wcdocumentowc = getWebComponent(GetType(), "GeneXus.Programs", "documentowc", new Object[] {context} );
                  WebComp_Wcdocumentowc.ComponentInit();
                  WebComp_Wcdocumentowc.Name = "DocumentoWC";
                  WebComp_Wcdocumentowc_Component = "DocumentoWC";
               }
               if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
               {
                  WebComp_Wcdocumentowc.setjustcreated();
                  WebComp_Wcdocumentowc.componentprepare(new Object[] {(string)"W0028",(string)"",(string)"UPD",(int)AV8DocumentoId});
                  WebComp_Wcdocumentowc.componentbind(new Object[] {(string)"",(string)""});
               }
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wctratamentowc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wctratamentowc_Component), StringUtil.Lower( "TratamentoWC")) != 0 )
               {
                  WebComp_Wctratamentowc = getWebComponent(GetType(), "GeneXus.Programs", "tratamentowc", new Object[] {context} );
                  WebComp_Wctratamentowc.ComponentInit();
                  WebComp_Wctratamentowc.Name = "TratamentoWC";
                  WebComp_Wctratamentowc_Component = "TratamentoWC";
               }
               if ( StringUtil.Len( WebComp_Wctratamentowc_Component) != 0 )
               {
                  WebComp_Wctratamentowc.setjustcreated();
                  WebComp_Wctratamentowc.componentprepare(new Object[] {(string)"W0036",(string)"",(string)"UPD",(int)AV8DocumentoId});
                  WebComp_Wctratamentowc.componentbind(new Object[] {(string)"",(string)""});
               }
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcanexowc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcanexowc_Component), StringUtil.Lower( "AnexoWC")) != 0 )
               {
                  WebComp_Wcanexowc = getWebComponent(GetType(), "GeneXus.Programs", "anexowc", new Object[] {context} );
                  WebComp_Wcanexowc.ComponentInit();
                  WebComp_Wcanexowc.Name = "AnexoWC";
                  WebComp_Wcanexowc_Component = "AnexoWC";
               }
               if ( StringUtil.Len( WebComp_Wcanexowc_Component) != 0 )
               {
                  WebComp_Wcanexowc.setjustcreated();
                  WebComp_Wcanexowc.componentprepare(new Object[] {(string)"W0044",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
                  WebComp_Wcanexowc.componentbind(new Object[] {(string)"",(string)""});
               }
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcoperadorwc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcoperadorwc_Component), StringUtil.Lower( "OperadorWC")) != 0 )
               {
                  WebComp_Wcoperadorwc = getWebComponent(GetType(), "GeneXus.Programs", "operadorwc", new Object[] {context} );
                  WebComp_Wcoperadorwc.ComponentInit();
                  WebComp_Wcoperadorwc.Name = "OperadorWC";
                  WebComp_Wcoperadorwc_Component = "OperadorWC";
               }
               if ( StringUtil.Len( WebComp_Wcoperadorwc_Component) != 0 )
               {
                  WebComp_Wcoperadorwc.setjustcreated();
                  WebComp_Wcoperadorwc.componentprepare(new Object[] {(string)"W0060",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
                  WebComp_Wcoperadorwc.componentbind(new Object[] {(string)"",(string)""});
               }
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcdicionariowc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcdicionariowc_Component), StringUtil.Lower( "DicionarioWC")) != 0 )
               {
                  WebComp_Wcdicionariowc = getWebComponent(GetType(), "GeneXus.Programs", "dicionariowc", new Object[] {context} );
                  WebComp_Wcdicionariowc.ComponentInit();
                  WebComp_Wcdicionariowc.Name = "DicionarioWC";
                  WebComp_Wcdicionariowc_Component = "DicionarioWC";
               }
               if ( StringUtil.Len( WebComp_Wcdicionariowc_Component) != 0 )
               {
                  WebComp_Wcdicionariowc.setjustcreated();
                  WebComp_Wcdicionariowc.componentprepare(new Object[] {(string)"W0052",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
                  WebComp_Wcdicionariowc.componentbind(new Object[] {(string)"",(string)""});
               }
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcrevisaowc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcrevisaowc_Component), StringUtil.Lower( "RevisaoWC")) != 0 )
               {
                  WebComp_Wcrevisaowc = getWebComponent(GetType(), "GeneXus.Programs", "revisaowc", new Object[] {context} );
                  WebComp_Wcrevisaowc.ComponentInit();
                  WebComp_Wcrevisaowc.Name = "RevisaoWC";
                  WebComp_Wcrevisaowc_Component = "RevisaoWC";
               }
               if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
               {
                  WebComp_Wcrevisaowc.setjustcreated();
                  WebComp_Wcrevisaowc.componentprepare(new Object[] {(string)"W0068",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
                  WebComp_Wcrevisaowc.componentbind(new Object[] {(string)"",(string)""});
               }
            }
         }
         else
         {
            GXt_char1 = AV11DocumentoNome;
            new recuperadocumentonome(context ).execute(  AV8DocumentoId, out  GXt_char1) ;
            AV11DocumentoNome = GXt_char1;
            if ( StringUtil.Len( AV11DocumentoNome) > 50 )
            {
               AV11DocumentoNome = StringUtil.Substring( AV11DocumentoNome, 1, 50);
               AV11DocumentoNome += "...";
            }
            else
            {
               AV11DocumentoNome = StringUtil.Substring( AV11DocumentoNome, 1, 50);
            }
            Dvpanel_panelcadastro_Title = "CADASTRO DE DOCUMENTO | "+StringUtil.Trim( StringUtil.Str( (decimal)(AV8DocumentoId), 8, 0))+" - "+AV11DocumentoNome;
            ucDvpanel_panelcadastro.SendProperty(context, "", false, Dvpanel_panelcadastro_Internalname, "Title", Dvpanel_panelcadastro_Title);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcdocumentowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcdocumentowc_Component), StringUtil.Lower( "DocumentoWC")) != 0 )
            {
               WebComp_Wcdocumentowc = getWebComponent(GetType(), "GeneXus.Programs", "documentowc", new Object[] {context} );
               WebComp_Wcdocumentowc.ComponentInit();
               WebComp_Wcdocumentowc.Name = "DocumentoWC";
               WebComp_Wcdocumentowc_Component = "DocumentoWC";
            }
            if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
            {
               WebComp_Wcdocumentowc.setjustcreated();
               WebComp_Wcdocumentowc.componentprepare(new Object[] {(string)"W0028",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wcdocumentowc.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wctratamentowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wctratamentowc_Component), StringUtil.Lower( "TratamentoWC")) != 0 )
            {
               WebComp_Wctratamentowc = getWebComponent(GetType(), "GeneXus.Programs", "tratamentowc", new Object[] {context} );
               WebComp_Wctratamentowc.ComponentInit();
               WebComp_Wctratamentowc.Name = "TratamentoWC";
               WebComp_Wctratamentowc_Component = "TratamentoWC";
            }
            if ( StringUtil.Len( WebComp_Wctratamentowc_Component) != 0 )
            {
               WebComp_Wctratamentowc.setjustcreated();
               WebComp_Wctratamentowc.componentprepare(new Object[] {(string)"W0036",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wctratamentowc.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcanexowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcanexowc_Component), StringUtil.Lower( "AnexoWC")) != 0 )
            {
               WebComp_Wcanexowc = getWebComponent(GetType(), "GeneXus.Programs", "anexowc", new Object[] {context} );
               WebComp_Wcanexowc.ComponentInit();
               WebComp_Wcanexowc.Name = "AnexoWC";
               WebComp_Wcanexowc_Component = "AnexoWC";
            }
            if ( StringUtil.Len( WebComp_Wcanexowc_Component) != 0 )
            {
               WebComp_Wcanexowc.setjustcreated();
               WebComp_Wcanexowc.componentprepare(new Object[] {(string)"W0044",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wcanexowc.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcoperadorwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcoperadorwc_Component), StringUtil.Lower( "OperadorWC")) != 0 )
            {
               WebComp_Wcoperadorwc = getWebComponent(GetType(), "GeneXus.Programs", "operadorwc", new Object[] {context} );
               WebComp_Wcoperadorwc.ComponentInit();
               WebComp_Wcoperadorwc.Name = "OperadorWC";
               WebComp_Wcoperadorwc_Component = "OperadorWC";
            }
            if ( StringUtil.Len( WebComp_Wcoperadorwc_Component) != 0 )
            {
               WebComp_Wcoperadorwc.setjustcreated();
               WebComp_Wcoperadorwc.componentprepare(new Object[] {(string)"W0060",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wcoperadorwc.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcdicionariowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcdicionariowc_Component), StringUtil.Lower( "DicionarioWC")) != 0 )
            {
               WebComp_Wcdicionariowc = getWebComponent(GetType(), "GeneXus.Programs", "dicionariowc", new Object[] {context} );
               WebComp_Wcdicionariowc.ComponentInit();
               WebComp_Wcdicionariowc.Name = "DicionarioWC";
               WebComp_Wcdicionariowc_Component = "DicionarioWC";
            }
            if ( StringUtil.Len( WebComp_Wcdicionariowc_Component) != 0 )
            {
               WebComp_Wcdicionariowc.setjustcreated();
               WebComp_Wcdicionariowc.componentprepare(new Object[] {(string)"W0052",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wcdicionariowc.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcrevisaowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcrevisaowc_Component), StringUtil.Lower( "RevisaoWC")) != 0 )
            {
               WebComp_Wcrevisaowc = getWebComponent(GetType(), "GeneXus.Programs", "revisaowc", new Object[] {context} );
               WebComp_Wcrevisaowc.ComponentInit();
               WebComp_Wcrevisaowc.Name = "RevisaoWC";
               WebComp_Wcrevisaowc_Component = "RevisaoWC";
            }
            if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
            {
               WebComp_Wcrevisaowc.setjustcreated();
               WebComp_Wcrevisaowc.componentprepare(new Object[] {(string)"W0068",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wcrevisaowc.componentbind(new Object[] {(string)"",(string)""});
            }
         }
      }

      protected void E117A2( )
      {
         /* Gxuitabspanel_tabs1_Tabchanged Routine */
         returnInSub = false;
         if ( Gxuitabspanel_tabs1_Activepage == 6 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcrevisaowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcrevisaowc_Component), StringUtil.Lower( "RevisaoWC")) != 0 )
            {
               WebComp_Wcrevisaowc = getWebComponent(GetType(), "GeneXus.Programs", "revisaowc", new Object[] {context} );
               WebComp_Wcrevisaowc.ComponentInit();
               WebComp_Wcrevisaowc.Name = "RevisaoWC";
               WebComp_Wcrevisaowc_Component = "RevisaoWC";
            }
            if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
            {
               WebComp_Wcrevisaowc.setjustcreated();
               WebComp_Wcrevisaowc.componentprepare(new Object[] {(string)"W0068",(string)"",(string)Gx_mode,(int)AV8DocumentoId});
               WebComp_Wcrevisaowc.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcrevisaowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
               WebComp_Wcrevisaowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E137A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV8DocumentoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
         AV9IsInserido = (bool)getParm(obj,2);
         AssignAttri("", false, "AV9IsInserido", AV9IsInserido);
         GxWebStd.gx_hidden_field( context, "gxhash_vISINSERIDO", GetSecureSignedToken( "", AV9IsInserido, context));
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
         PA7A2( ) ;
         WS7A2( ) ;
         WE7A2( ) ;
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
         if ( ! ( WebComp_Wcdocumentowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcdocumentowc_Component) != 0 )
            {
               WebComp_Wcdocumentowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wctratamentowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wctratamentowc_Component) != 0 )
            {
               WebComp_Wctratamentowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcanexowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcanexowc_Component) != 0 )
            {
               WebComp_Wcanexowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcdicionariowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcdicionariowc_Component) != 0 )
            {
               WebComp_Wcdicionariowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcoperadorwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcoperadorwc_Component) != 0 )
            {
               WebComp_Wcoperadorwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcrevisaowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcrevisaowc_Component) != 0 )
            {
               WebComp_Wcrevisaowc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231191641877", true, true);
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
         context.AddJavascriptSource("documentocadastrowp.js", "?20231191641877", false, true);
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
         lblTabdocumento_title_Internalname = "TABDOCUMENTO_TITLE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         lblTabtratamento_title_Internalname = "TABTRATAMENTO_TITLE";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         lblTabanexos_title_Internalname = "TABANEXOS_TITLE";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         lblTabdicionario_title_Internalname = "TABDICIONARIO_TITLE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblTaboperador_title_Internalname = "TABOPERADOR_TITLE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTabrevisao_title_Internalname = "TABREVISAO_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divPanelcadastro_Internalname = "PANELCADASTRO";
         Dvpanel_panelcadastro_Internalname = "DVPANEL_PANELCADASTRO";
         divTablecontent_Internalname = "TABLECONTENT";
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
         Dvpanel_panelcadastro_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panelcadastro_Iconposition = "Right";
         Dvpanel_panelcadastro_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panelcadastro_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panelcadastro_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_panelcadastro_Title = "CADASTRO DE DOCUMENTO";
         Dvpanel_panelcadastro_Cls = "PanelCard Panel_BaseColor";
         Dvpanel_panelcadastro_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panelcadastro_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panelcadastro_Width = "100%";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "";
         Gxuitabspanel_tabs1_Pagecount = 6;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV9IsInserido',fld:'vISINSERIDO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GXUITABSPANEL_TABS1.TABCHANGED","{handler:'E117A2',iparms:[{av:'Gxuitabspanel_tabs1_Activepage',ctrl:'GXUITABSPANEL_TABS1',prop:'ActivePage'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("GXUITABSPANEL_TABS1.TABCHANGED",",oparms:[{ctrl:'WCREVISAOWC'}]}");
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
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panelcadastro = new GXUserControl();
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTabdocumento_title_Jsonclick = "";
         WebComp_Wcdocumentowc_Component = "";
         OldWcdocumentowc = "";
         lblTabtratamento_title_Jsonclick = "";
         WebComp_Wctratamentowc_Component = "";
         OldWctratamentowc = "";
         lblTabanexos_title_Jsonclick = "";
         WebComp_Wcanexowc_Component = "";
         OldWcanexowc = "";
         lblTabdicionario_title_Jsonclick = "";
         WebComp_Wcdicionariowc_Component = "";
         OldWcdicionariowc = "";
         lblTaboperador_title_Jsonclick = "";
         WebComp_Wcoperadorwc_Component = "";
         OldWcoperadorwc = "";
         lblTabrevisao_title_Jsonclick = "";
         WebComp_Wcrevisaowc_Component = "";
         OldWcrevisaowc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11DocumentoNome = "";
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wcdocumentowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wctratamentowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcanexowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcdicionariowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcoperadorwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcrevisaowc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV8DocumentoId ;
      private int wcpOAV8DocumentoId ;
      private int Gxuitabspanel_tabs1_Activepage ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Dvpanel_panelcadastro_Width ;
      private string Dvpanel_panelcadastro_Cls ;
      private string Dvpanel_panelcadastro_Title ;
      private string Dvpanel_panelcadastro_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panelcadastro_Internalname ;
      private string divPanelcadastro_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTabdocumento_title_Internalname ;
      private string lblTabdocumento_title_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string WebComp_Wcdocumentowc_Component ;
      private string OldWcdocumentowc ;
      private string lblTabtratamento_title_Internalname ;
      private string lblTabtratamento_title_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string WebComp_Wctratamentowc_Component ;
      private string OldWctratamentowc ;
      private string lblTabanexos_title_Internalname ;
      private string lblTabanexos_title_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string WebComp_Wcanexowc_Component ;
      private string OldWcanexowc ;
      private string lblTabdicionario_title_Internalname ;
      private string lblTabdicionario_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string WebComp_Wcdicionariowc_Component ;
      private string OldWcdicionariowc ;
      private string lblTaboperador_title_Internalname ;
      private string lblTaboperador_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string WebComp_Wcoperadorwc_Component ;
      private string OldWcoperadorwc ;
      private string lblTabrevisao_title_Internalname ;
      private string lblTabrevisao_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcrevisaowc_Component ;
      private string OldWcrevisaowc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private bool AV9IsInserido ;
      private bool wcpOAV9IsInserido ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool Dvpanel_panelcadastro_Autowidth ;
      private bool Dvpanel_panelcadastro_Autoheight ;
      private bool Dvpanel_panelcadastro_Collapsible ;
      private bool Dvpanel_panelcadastro_Collapsed ;
      private bool Dvpanel_panelcadastro_Showcollapseicon ;
      private bool Dvpanel_panelcadastro_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcdocumentowc ;
      private bool bDynCreated_Wctratamentowc ;
      private bool bDynCreated_Wcanexowc ;
      private bool bDynCreated_Wcoperadorwc ;
      private bool bDynCreated_Wcdicionariowc ;
      private bool bDynCreated_Wcrevisaowc ;
      private string AV11DocumentoNome ;
      private GXWebComponent WebComp_Wcdocumentowc ;
      private GXWebComponent WebComp_Wctratamentowc ;
      private GXWebComponent WebComp_Wcanexowc ;
      private GXWebComponent WebComp_Wcdicionariowc ;
      private GXWebComponent WebComp_Wcoperadorwc ;
      private GXWebComponent WebComp_Wcrevisaowc ;
      private GXUserControl ucDvpanel_panelcadastro ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
