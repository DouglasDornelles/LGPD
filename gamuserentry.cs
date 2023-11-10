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
   public class gamuserentry : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamuserentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public gamuserentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_UserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV55UserId = aP1_UserId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_UserId=this.AV55UserId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAuthenticationtypename = new GXCombobox();
         cmbavGender = new GXCombobox();
         chkavIsactive = new GXCheckbox();
         chkavDontreceiveinformation = new GXCheckbox();
         chkavCannotchangepassword = new GXCheckbox();
         chkavMustchangepassword = new GXCheckbox();
         chkavPasswordneverexpires = new GXCheckbox();
         chkavIsblocked = new GXCheckbox();
         cmbavSecuritypolicyid = new GXCombobox();
         chkavIsenabledinrepository = new GXCheckbox();
         chkavEnabletwofactorauthentication = new GXCheckbox();
         chkavUser_isenabledinrepository = new GXCheckbox();
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
            return "gamuserentry_Execute" ;
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
         PA1T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1T2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV55UserId));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV59CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vPHOTO", AV46Photo);
         GxWebStd.gx_hidden_field( context, "vAUTHTYPEID", StringUtil.RTrim( AV10AuthTypeId));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
            WE1T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1T2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV55UserId));
         return formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMUserEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "User " ;
      }

      protected void WB1T0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
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
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserid_Internalname, "Guid", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavUserid_Internalname, StringUtil.RTrim( AV55UserId), StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUserid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsernamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsernamespace_Internalname, "Namespace", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsernamespace_Internalname, StringUtil.RTrim( AV56UserNameSpace), StringUtil.RTrim( context.localUtil.Format( AV56UserNameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsernamespace_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsernamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAuthenticationtypename_cell_Internalname, 1, 0, "px", 0, "px", divAuthenticationtypename_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavAuthenticationtypename.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavAuthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAuthenticationtypename_Internalname, "Tipo de autoriza��o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAuthenticationtypename, cmbavAuthenticationtypename_Internalname, StringUtil.RTrim( AV7AuthenticationTypeName), 1, cmbavAuthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavAuthenticationtypename.Visible, cmbavAuthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_GAMUserEntry.htm");
            cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV7AuthenticationTypeName);
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", (string)(cmbavAuthenticationtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Login", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV36Name, StringUtil.RTrim( context.localUtil.Format( AV36Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmail_cell_Internalname, 1, 0, "px", 0, "px", divEmail_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV16Email, StringUtil.RTrim( context.localUtil.Format( AV16Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPassword_cell_Internalname, 1, 0, "px", 0, "px", divPassword_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, "Senha", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV41Password), StringUtil.RTrim( context.localUtil.Format( AV41Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavPassword_Visible, edtavPassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPasswordconf_cell_Internalname, 1, 0, "px", 0, "px", divPasswordconf_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPasswordconf_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, "Conf. senha", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV42PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV42PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavPasswordconf_Visible, edtavPasswordconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFirstname_cell_Internalname, 1, 0, "px", 0, "px", divFirstname_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV22FirstName), StringUtil.RTrim( context.localUtil.Format( AV22FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLastname_cell_Internalname, 1, 0, "px", 0, "px", divLastname_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, "Sobrenome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV31LastName), StringUtil.RTrim( context.localUtil.Format( AV31LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavExternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavExternalid_Internalname, "Id externo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavExternalid_Internalname, AV20ExternalId, StringUtil.RTrim( context.localUtil.Format( AV20ExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavExternalid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavExternalid_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBirthday_cell_Internalname, 1, 0, "px", 0, "px", divBirthday_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, "Data de nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV11Birthday, "99/99/9999"), context.localUtil.Format( AV11Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavBirthday_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGender_cell_Internalname, 1, 0, "px", 0, "px", divGender_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, "Sexo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV24Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_GAMUserEntry.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV24Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPhone_cell_Internalname, 1, 0, "px", 0, "px", divPhone_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, StringUtil.RTrim( AV45Phone), StringUtil.RTrim( context.localUtil.Format( AV45Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhone_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPhone_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUrlprofile_cell_Internalname, 1, 0, "px", 0, "px", divUrlprofile_cell_Class, "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUrlprofile_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavUrlprofile_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlprofile_Internalname, "Url do perfil", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlprofile_Internalname, AV52URLProfile, StringUtil.RTrim( context.localUtil.Format( AV52URLProfile, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlprofile_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavUrlprofile_Visible, edtavUrlprofile_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnurlprofilego_Internalname, "", "WWP_GAM_Go", bttBtnurlprofilego_Jsonclick, 7, "WWP_GAM_Go", "", StyleString, ClassString, bttBtnurlprofilego_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e111t1_client"+"'", TempTags, "", 2, "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImage_cell_Internalname, 1, 0, "px", 0, "px", divImage_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", imgavImage_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgavImage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Imagem externa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL" + " " + ((StringUtil.StrCmp(imgavImage_gximage, "")==0) ? "" : "GX_Image_"+imgavImage_gximage+"_Class");
            StyleString = "";
            AV25Image_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25Image))&&String.IsNullOrEmpty(StringUtil.RTrim( AV66Image_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)) ? AV66Image_GXI : context.PathToRelativeUrl( AV25Image));
            GxWebStd.gx_bitmap( context, imgavImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavImage_Visible, imgavImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV25Image_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIsactive_cell_Internalname, 1, 0, "px", 0, "px", divIsactive_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavIsactive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsactive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsactive_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsactive_Internalname, StringUtil.BoolToStr( AV26IsActive), "", " ", chkavIsactive.Visible, chkavIsactive.Enabled, "true", "Ativo?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActivationdate_cell_Internalname, 1, 0, "px", 0, "px", divActivationdate_cell_Class, "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavActivationdate_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavActivationdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavActivationdate_Internalname, "Data de ativa��o", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavActivationdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavActivationdate_Internalname, context.localUtil.TToC( AV5ActivationDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV5ActivationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavActivationdate_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavActivationdate_Visible, edtavActivationdate_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavActivationdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavActivationdate_Visible==0)||(edtavActivationdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsendactivationemail_Internalname, "", "Envie e-mail de ativa��o", bttBtnsendactivationemail_Jsonclick, 5, "Envie e-mail de ativa��o", "", StyleString, ClassString, bttBtnsendactivationemail_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSENDACTIVATIONEMAIL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDontreceiveinformation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDontreceiveinformation_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDontreceiveinformation_Internalname, StringUtil.BoolToStr( AV15DontReceiveInformation), "", " ", 1, chkavDontreceiveinformation.Enabled, "true", "Eu n�o desejo receber informa��o", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(107, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,107);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavCannotchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCannotchangepassword_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCannotchangepassword_Internalname, StringUtil.BoolToStr( AV13CannotChangePassword), "", " ", 1, chkavCannotchangepassword.Enabled, "true", "Voc� n�o pode alterar a senha", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavMustchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMustchangepassword_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMustchangepassword_Internalname, StringUtil.BoolToStr( AV35MustChangePassword), "", " ", 1, chkavMustchangepassword.Enabled, "true", "Voc� deve alterar a senha", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,116);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavPasswordneverexpires_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavPasswordneverexpires_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavPasswordneverexpires_Internalname, StringUtil.BoolToStr( AV44PasswordNeverExpires), "", " ", 1, chkavPasswordneverexpires.Enabled, "true", "A senha nunca expira", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsblocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsblocked_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsblocked_Internalname, StringUtil.BoolToStr( AV27IsBlocked), "", " ", 1, chkavIsblocked.Enabled, "true", "Est� bloqueado?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(125, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,125);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavSecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecuritypolicyid_Internalname, "Pol�tica de seguran�a", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecuritypolicyid, cmbavSecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0)), 1, cmbavSecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecuritypolicyid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "", true, 0, "HLP_GAMUserEntry.htm");
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", (string)(cmbavSecuritypolicyid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIsenabledinrepository_cell_Internalname, 1, 0, "px", 0, "px", divIsenabledinrepository_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavIsenabledinrepository.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsenabledinrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenabledinrepository_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenabledinrepository_Internalname, StringUtil.BoolToStr( AV28IsEnabledInRepository), "", " ", chkavIsenabledinrepository.Visible, chkavIsenabledinrepository.Enabled, "true", "Voc� est� habilitado no reposit�rio?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatelastauthentication_cell_Internalname, 1, 0, "px", 0, "px", divDatelastauthentication_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavDatelastauthentication_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDatelastauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatelastauthentication_Internalname, "Data da �ltima autentica��o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatelastauthentication_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatelastauthentication_Internalname, context.localUtil.TToC( AV14DateLastAuthentication, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV14DateLastAuthentication, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatelastauthentication_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavDatelastauthentication_Visible, edtavDatelastauthentication_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavDatelastauthentication_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavDatelastauthentication_Visible==0)||(edtavDatelastauthentication_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEnabletwofactorauthentication_cell_Internalname, 1, 0, "px", 0, "px", divEnabletwofactorauthentication_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavEnabletwofactorauthentication.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavEnabletwofactorauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnabletwofactorauthentication_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnabletwofactorauthentication_Internalname, StringUtil.BoolToStr( AV17EnableTwoFactorAuthentication), "", " ", chkavEnabletwofactorauthentication.Visible, chkavEnabletwofactorauthentication.Enabled, "true", "Ativar a autentica��o de dois fatores?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(143, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,143);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtpnumberlocked_cell_Internalname, 1, 0, "px", 0, "px", divOtpnumberlocked_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtpnumberlocked_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOtpnumberlocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpnumberlocked_Internalname, "N�mero de c�digos OTP bloqueados", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpnumberlocked_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40OTPNumberLocked), 3, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40OTPNumberLocked), "ZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpnumberlocked_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavOtpnumberlocked_Visible, edtavOtpnumberlocked_Enabled, 1, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtplastlockeddate_cell_Internalname, 1, 0, "px", 0, "px", divOtplastlockeddate_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtplastlockeddate_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOtplastlockeddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtplastlockeddate_Internalname, "A �ltima vez que o c�digo OTP foi bloqueado", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOtplastlockeddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOtplastlockeddate_Internalname, context.localUtil.TToC( AV39OTPLastLockedDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV39OTPLastLockedDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtplastlockeddate_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavOtplastlockeddate_Visible, edtavOtplastlockeddate_Enabled, 1, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavOtplastlockeddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavOtplastlockeddate_Visible==0)||(edtavOtplastlockeddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtpdailynumbercodes_cell_Internalname, 1, 0, "px", 0, "px", divOtpdailynumbercodes_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtpdailynumbercodes_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOtpdailynumbercodes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpdailynumbercodes_Internalname, "N�mero de c�digos OTP di�rios solicitados", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpdailynumbercodes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37OTPDailyNumberCodes), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37OTPDailyNumberCodes), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpdailynumbercodes_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavOtpdailynumbercodes_Visible, edtavOtpdailynumbercodes_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtplastdaterequestcode_cell_Internalname, 1, 0, "px", 0, "px", divOtplastdaterequestcode_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtplastdaterequestcode_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOtplastdaterequestcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtplastdaterequestcode_Internalname, "�ltima data solicitada um c�digo OTP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOtplastdaterequestcode_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOtplastdaterequestcode_Internalname, context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"), context.localUtil.Format( AV38OTPLastDateRequestCode, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtplastdaterequestcode_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavOtplastdaterequestcode_Visible, edtavOtplastdaterequestcode_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavOtplastdaterequestcode_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavOtplastdaterequestcode_Visible==0)||(edtavOtplastdaterequestcode_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
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
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUser_isenabledinrepository_Internalname, StringUtil.BoolToStr( AV53User.gxTpr_Isenabledinrepository), "", "", chkavUser_isenabledinrepository.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(172, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,172);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1T2( )
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
            Form.Meta.addItem("description", "User ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1T0( ) ;
      }

      protected void WS1T2( )
      {
         START1T2( ) ;
         EVT1T2( ) ;
      }

      protected void EVT1T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E121T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E131T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSENDACTIVATIONEMAIL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSendActivationEmail' */
                              E141T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E151T2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VAUTHENTICATIONTYPENAME.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E161T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E171T2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1T2( )
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

      protected void PA1T2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamuserentry.aspx")), "gamuserentry.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamuserentry.aspx")))) ;
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
                        AV55UserId = GetPar( "UserId");
                        AssignAttri("", false, "AV55UserId", AV55UserId);
                        GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
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
               GX_FocusControl = edtavUsernamespace_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavAuthenticationtypename.ItemCount > 0 )
         {
            AV7AuthenticationTypeName = cmbavAuthenticationtypename.getValidValue(AV7AuthenticationTypeName);
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV7AuthenticationTypeName);
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", cmbavAuthenticationtypename.ToJavascriptSource(), true);
         }
         if ( cmbavGender.ItemCount > 0 )
         {
            AV24Gender = cmbavGender.getValidValue(AV24Gender);
            AssignAttri("", false, "AV24Gender", AV24Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV24Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
         AV26IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV26IsActive));
         AssignAttri("", false, "AV26IsActive", AV26IsActive);
         AV15DontReceiveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV15DontReceiveInformation));
         AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
         AV13CannotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV13CannotChangePassword));
         AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
         AV35MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV35MustChangePassword));
         AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
         AV44PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV44PasswordNeverExpires));
         AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
         AV27IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV27IsBlocked));
         AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV50SecurityPolicyId = (int)(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", cmbavSecuritypolicyid.ToJavascriptSource(), true);
         }
         AV28IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsEnabledInRepository));
         AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
         AV17EnableTwoFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV17EnableTwoFactorAuthentication));
         AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUserid_Enabled = 0;
         AssignProp("", false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), true);
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         edtavDatelastauthentication_Enabled = 0;
         AssignProp("", false, edtavDatelastauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Enabled), 5, 0), true);
         edtavOtpnumberlocked_Enabled = 0;
         AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
         edtavOtplastlockeddate_Enabled = 0;
         AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
         edtavOtpdailynumbercodes_Enabled = 0;
         AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
         edtavOtplastdaterequestcode_Enabled = 0;
         AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
      }

      protected void RF1T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E131T2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E171T2 ();
            WB1T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1T2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavUserid_Enabled = 0;
         AssignProp("", false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), true);
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         edtavDatelastauthentication_Enabled = 0;
         AssignProp("", false, edtavDatelastauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Enabled), 5, 0), true);
         edtavOtpnumberlocked_Enabled = 0;
         AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
         edtavOtplastlockeddate_Enabled = 0;
         AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
         edtavOtpdailynumbercodes_Enabled = 0;
         AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
         edtavOtplastdaterequestcode_Enabled = 0;
         AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            /* Read variables values. */
            AV55UserId = cgiGet( edtavUserid_Internalname);
            AssignAttri("", false, "AV55UserId", AV55UserId);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
            AV56UserNameSpace = cgiGet( edtavUsernamespace_Internalname);
            AssignAttri("", false, "AV56UserNameSpace", AV56UserNameSpace);
            cmbavAuthenticationtypename.CurrentValue = cgiGet( cmbavAuthenticationtypename_Internalname);
            AV7AuthenticationTypeName = cgiGet( cmbavAuthenticationtypename_Internalname);
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
            AV36Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV36Name", AV36Name);
            AV16Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV16Email", AV16Email);
            AV41Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV41Password", AV41Password);
            AV42PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV42PasswordConf", AV42PasswordConf);
            AV22FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV22FirstName", AV22FirstName);
            AV31LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV31LastName", AV31LastName);
            AV20ExternalId = cgiGet( edtavExternalid_Internalname);
            AssignAttri("", false, "AV20ExternalId", AV20ExternalId);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Birthday"}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV11Birthday", context.localUtil.Format(AV11Birthday, "99/99/9999"));
            }
            else
            {
               AV11Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), 2);
               AssignAttri("", false, "AV11Birthday", context.localUtil.Format(AV11Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV24Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV24Gender", AV24Gender);
            AV45Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV45Phone", AV45Phone);
            AV52URLProfile = cgiGet( edtavUrlprofile_Internalname);
            AssignAttri("", false, "AV52URLProfile", AV52URLProfile);
            AV25Image = cgiGet( imgavImage_Internalname);
            AV26IsActive = StringUtil.StrToBool( cgiGet( chkavIsactive_Internalname));
            AssignAttri("", false, "AV26IsActive", AV26IsActive);
            if ( context.localUtil.VCDateTime( cgiGet( edtavActivationdate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Activation Date"}), 1, "vACTIVATIONDATE");
               GX_FocusControl = edtavActivationdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5ActivationDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV5ActivationDate", context.localUtil.TToC( AV5ActivationDate, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV5ActivationDate = context.localUtil.CToT( cgiGet( edtavActivationdate_Internalname));
               AssignAttri("", false, "AV5ActivationDate", context.localUtil.TToC( AV5ActivationDate, 10, 5, 0, 3, "/", ":", " "));
            }
            AV15DontReceiveInformation = StringUtil.StrToBool( cgiGet( chkavDontreceiveinformation_Internalname));
            AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
            AV13CannotChangePassword = StringUtil.StrToBool( cgiGet( chkavCannotchangepassword_Internalname));
            AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
            AV35MustChangePassword = StringUtil.StrToBool( cgiGet( chkavMustchangepassword_Internalname));
            AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
            AV44PasswordNeverExpires = StringUtil.StrToBool( cgiGet( chkavPasswordneverexpires_Internalname));
            AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
            AV27IsBlocked = StringUtil.StrToBool( cgiGet( chkavIsblocked_Internalname));
            AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
            cmbavSecuritypolicyid.CurrentValue = cgiGet( cmbavSecuritypolicyid_Internalname);
            AV50SecurityPolicyId = (int)(NumberUtil.Val( cgiGet( cmbavSecuritypolicyid_Internalname), "."));
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
            AV28IsEnabledInRepository = StringUtil.StrToBool( cgiGet( chkavIsenabledinrepository_Internalname));
            AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatelastauthentication_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Date Last Authentication"}), 1, "vDATELASTAUTHENTICATION");
               GX_FocusControl = edtavDatelastauthentication_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14DateLastAuthentication = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV14DateLastAuthentication", context.localUtil.TToC( AV14DateLastAuthentication, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV14DateLastAuthentication = context.localUtil.CToT( cgiGet( edtavDatelastauthentication_Internalname));
               AssignAttri("", false, "AV14DateLastAuthentication", context.localUtil.TToC( AV14DateLastAuthentication, 10, 5, 0, 3, "/", ":", " "));
            }
            AV17EnableTwoFactorAuthentication = StringUtil.StrToBool( cgiGet( chkavEnabletwofactorauthentication_Internalname));
            AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPNUMBERLOCKED");
               GX_FocusControl = edtavOtpnumberlocked_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40OTPNumberLocked = 0;
               AssignAttri("", false, "AV40OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV40OTPNumberLocked), 3, 0));
            }
            else
            {
               AV40OTPNumberLocked = (short)(context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), ",", "."));
               AssignAttri("", false, "AV40OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV40OTPNumberLocked), 3, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavOtplastlockeddate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Last time OTP code is locked"}), 1, "vOTPLASTLOCKEDDATE");
               GX_FocusControl = edtavOtplastlockeddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39OTPLastLockedDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV39OTPLastLockedDate", context.localUtil.TToC( AV39OTPLastLockedDate, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV39OTPLastLockedDate = context.localUtil.CToT( cgiGet( edtavOtplastlockeddate_Internalname));
               AssignAttri("", false, "AV39OTPLastLockedDate", context.localUtil.TToC( AV39OTPLastLockedDate, 10, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPDAILYNUMBERCODES");
               GX_FocusControl = edtavOtpdailynumbercodes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37OTPDailyNumberCodes = 0;
               AssignAttri("", false, "AV37OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV37OTPDailyNumberCodes), 4, 0));
            }
            else
            {
               AV37OTPDailyNumberCodes = (short)(context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), ",", "."));
               AssignAttri("", false, "AV37OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV37OTPDailyNumberCodes), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavOtplastdaterequestcode_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Last date requested a OTP code"}), 1, "vOTPLASTDATEREQUESTCODE");
               GX_FocusControl = edtavOtplastdaterequestcode_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38OTPLastDateRequestCode = DateTime.MinValue;
               AssignAttri("", false, "AV38OTPLastDateRequestCode", context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"));
            }
            else
            {
               AV38OTPLastDateRequestCode = context.localUtil.CToD( cgiGet( edtavOtplastdaterequestcode_Internalname), 2);
               AssignAttri("", false, "AV38OTPLastDateRequestCode", context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"));
            }
            AV53User.gxTpr_Isenabledinrepository = StringUtil.StrToBool( cgiGet( chkavUser_isenabledinrepository_Internalname));
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
         E121T2 ();
         if (returnInSub) return;
      }

      protected void E121T2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV23GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( (0==AV23GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            cmbavAuthenticationtypename.removeAllItems();
            AV8AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV30Language, out  AV19Errors);
            AV64GXV2 = 1;
            while ( AV64GXV2 <= AV8AuthenticationTypes.Count )
            {
               AV9AuthenticationTypesIns = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV8AuthenticationTypes.Item(AV64GXV2));
               cmbavAuthenticationtypename.addItem(AV9AuthenticationTypesIns.gxTpr_Name, AV9AuthenticationTypesIns.gxTpr_Description, 0);
               AV64GXV2 = (int)(AV64GXV2+1);
            }
         }
         else
         {
            cmbavAuthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
         }
         AV48SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV21FilterSecPol, out  AV19Errors);
         cmbavSecuritypolicyid.addItem("0", "(None)", 0);
         AV65GXV3 = 1;
         while ( AV65GXV3 <= AV48SecurityPolicies.Count )
         {
            AV49SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV48SecurityPolicies.Item(AV65GXV3));
            cmbavSecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV49SecurityPolicy.gxTpr_Id), 9, 0)), AV49SecurityPolicy.gxTpr_Name, 0);
            AV65GXV3 = (int)(AV65GXV3+1);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            chkavIsenabledinrepository.Enabled = 0;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Enabled), 5, 0), true);
            cmbavAuthenticationtypename.Enabled = 1;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Enabled), 5, 0), true);
            AV7AuthenticationTypeName = "local";
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
            AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
            AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
            AV47Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            AV56UserNameSpace = AV47Repository.gxTpr_Namespace;
            AssignAttri("", false, "AV56UserNameSpace", AV56UserNameSpace);
            AV17EnableTwoFactorAuthentication = false;
            AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
         }
         else
         {
            AV53User.load( AV55UserId);
            cmbavAuthenticationtypename.Enabled = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Enabled), 5, 0), true);
            AV7AuthenticationTypeName = AV53User.gxTpr_Authenticationtypename;
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
            AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
            AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
            if ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               imgavImage_Enabled = 1;
               AssignProp("", false, imgavImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgavImage_Enabled), 5, 0), true);
               edtavUrlprofile_Enabled = 0;
               AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               imgavImage_Enabled = 0;
               AssignProp("", false, imgavImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgavImage_Enabled), 5, 0), true);
               edtavUrlprofile_Enabled = 1;
               AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            }
            AV55UserId = AV53User.gxTpr_Guid;
            AssignAttri("", false, "AV55UserId", AV55UserId);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
            AV56UserNameSpace = AV53User.gxTpr_Namespace;
            AssignAttri("", false, "AV56UserNameSpace", AV56UserNameSpace);
            AV36Name = AV53User.gxTpr_Name;
            AssignAttri("", false, "AV36Name", AV36Name);
            AV16Email = AV53User.gxTpr_Email;
            AssignAttri("", false, "AV16Email", AV16Email);
            AV22FirstName = AV53User.gxTpr_Firstname;
            AssignAttri("", false, "AV22FirstName", AV22FirstName);
            AV31LastName = AV53User.gxTpr_Lastname;
            AssignAttri("", false, "AV31LastName", AV31LastName);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53User.gxTpr_Urlimage)) )
            {
               AV25Image = AV53User.gxTpr_Urlimage;
               AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)) ? AV66Image_GXI : context.convertURL( context.PathToRelativeUrl( AV25Image))), true);
               AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV25Image), true);
               AV66Image_GXI = GXDbFile.PathToUrl( AV53User.gxTpr_Urlimage);
               AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)) ? AV66Image_GXI : context.convertURL( context.PathToRelativeUrl( AV25Image))), true);
               AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV25Image), true);
            }
            AV20ExternalId = AV53User.gxTpr_Externalid;
            AssignAttri("", false, "AV20ExternalId", AV20ExternalId);
            AV11Birthday = AV53User.gxTpr_Birthday;
            AssignAttri("", false, "AV11Birthday", context.localUtil.Format(AV11Birthday, "99/99/9999"));
            AV24Gender = AV53User.gxTpr_Gender;
            AssignAttri("", false, "AV24Gender", AV24Gender);
            AV45Phone = AV53User.gxTpr_Phone;
            AssignAttri("", false, "AV45Phone", AV45Phone);
            AV26IsActive = AV53User.gxTpr_Isactive;
            AssignAttri("", false, "AV26IsActive", AV26IsActive);
            AV5ActivationDate = AV53User.gxTpr_Activationdate;
            AssignAttri("", false, "AV5ActivationDate", context.localUtil.TToC( AV5ActivationDate, 10, 5, 0, 3, "/", ":", " "));
            AV15DontReceiveInformation = AV53User.gxTpr_Dontreceiveinformation;
            AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
            AV13CannotChangePassword = AV53User.gxTpr_Cannotchangepassword;
            AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
            AV35MustChangePassword = AV53User.gxTpr_Mustchangepassword;
            AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
            AV44PasswordNeverExpires = AV53User.gxTpr_Passwordneverexpires;
            AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
            AV27IsBlocked = AV53User.gxTpr_Isblocked;
            AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
            AV50SecurityPolicyId = AV53User.gxTpr_Securitypolicyid;
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
            AV28IsEnabledInRepository = AV53User.gxTpr_Isenabledinrepository;
            AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
            AV14DateLastAuthentication = AV53User.gxTpr_Datelastauthentication;
            AssignAttri("", false, "AV14DateLastAuthentication", context.localUtil.TToC( AV14DateLastAuthentication, 10, 5, 0, 3, "/", ":", " "));
            AV17EnableTwoFactorAuthentication = AV53User.gxTpr_Enabletwofactorauthentication;
            AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
            AV37OTPDailyNumberCodes = AV53User.gxTpr_Otpdailynumbercodes;
            AssignAttri("", false, "AV37OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV37OTPDailyNumberCodes), 4, 0));
            AV38OTPLastDateRequestCode = AV53User.gxTpr_Otplastdaterequestcode;
            AssignAttri("", false, "AV38OTPLastDateRequestCode", context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"));
            AV39OTPLastLockedDate = DateTimeUtil.ResetTime( AV53User.gxTpr_Otplastlockeddate ) ;
            AssignAttri("", false, "AV39OTPLastLockedDate", context.localUtil.TToC( AV39OTPLastLockedDate, 10, 5, 0, 3, "/", ":", " "));
            AV40OTPNumberLocked = AV53User.gxTpr_Otpnumberlocked;
            AssignAttri("", false, "AV40OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV40OTPNumberLocked), 3, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavEmail_Enabled = 0;
            AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
            edtavFirstname_Enabled = 0;
            AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
            edtavLastname_Enabled = 0;
            AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
            edtavUrlprofile_Enabled = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            edtavExternalid_Enabled = 0;
            AssignProp("", false, edtavExternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExternalid_Enabled), 5, 0), true);
            edtavBirthday_Enabled = 0;
            AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
            cmbavGender.Enabled = 0;
            AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
            edtavPhone_Enabled = 0;
            AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
            chkavDontreceiveinformation.Enabled = 0;
            AssignProp("", false, chkavDontreceiveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDontreceiveinformation.Enabled), 5, 0), true);
            chkavCannotchangepassword.Enabled = 0;
            AssignProp("", false, chkavCannotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCannotchangepassword.Enabled), 5, 0), true);
            chkavMustchangepassword.Enabled = 0;
            AssignProp("", false, chkavMustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMustchangepassword.Enabled), 5, 0), true);
            chkavIsblocked.Enabled = 0;
            AssignProp("", false, chkavIsblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsblocked.Enabled), 5, 0), true);
            chkavPasswordneverexpires.Enabled = 0;
            AssignProp("", false, chkavPasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavPasswordneverexpires.Enabled), 5, 0), true);
            cmbavSecuritypolicyid.Enabled = 0;
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyid.Enabled), 5, 0), true);
            chkavIsenabledinrepository.Enabled = 0;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Enabled), 5, 0), true);
            if ( AV17EnableTwoFactorAuthentication )
            {
               chkavEnabletwofactorauthentication.Enabled = 0;
               AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Enabled), 5, 0), true);
               edtavOtpdailynumbercodes_Enabled = 0;
               AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
               edtavOtplastdaterequestcode_Enabled = 0;
               AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
               edtavOtplastlockeddate_Enabled = 0;
               AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
               edtavOtpnumberlocked_Enabled = 0;
               AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
            }
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               bttBtnenter_Caption = "Eliminar";
               AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
            }
            else
            {
               bttBtnenter_Visible = 0;
               AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            }
         }
         if ( AV26IsActive )
         {
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         chkavUser_isenabledinrepository.Visible = 0;
         AssignProp("", false, chkavUser_isenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUser_isenabledinrepository.Visible), 5, 0), true);
      }

      protected void E131T2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E141T2( )
      {
         /* 'DoSendActivationEmail' Routine */
         returnInSub = false;
         AV53User.load( AV55UserId);
         if ( ! AV53User.gxTpr_Isactive )
         {
            AV54UserActivationKey = AV53User.getnewactivationkey(out  AV19Errors);
            context.CommitDataStores("gamuserentry",pr_default);
            AV32LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
            new gamcheckuseractivationmethod(context ).execute(  AV55UserId,  AV32LinkURL, out  AV34Messages) ;
            AV67GXV4 = 1;
            while ( AV67GXV4 <= AV34Messages.Count )
            {
               AV33Message = ((GeneXus.Utils.SdtMessages_Message)AV34Messages.Item(AV67GXV4));
               GX_msglist.addItem(AV33Message.gxTpr_Description);
               AV67GXV4 = (int)(AV67GXV4+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53User", AV53User);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV26IsActive && AV23GAMRepository.gxTpr_Email.gxTpr_Sendemailwhenuseractivateaccount ) )
         {
            bttBtnsendactivationemail_Visible = 0;
            AssignProp("", false, bttBtnsendactivationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsendactivationemail_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53User.gxTpr_Urlprofile)) && ( StringUtil.StrCmp(AV53User.gxTpr_Authenticationtypename, "GAMLocal") != 0 ) ) ) )
         {
            bttBtnurlprofilego_Visible = 0;
            AssignProp("", false, bttBtnurlprofilego_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnurlprofilego_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV59CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36Name)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Login", "", "", "", "", "", "", "", ""),  "error",  edtavName_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredemail ) && String.IsNullOrEmpty(StringUtil.RTrim( AV16Email)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV41Password)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Senha", "", "", "", "", "", "", "", ""),  "error",  edtavPassword_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV42PasswordConf)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Conf. senha", "", "", "", "", "", "", "", ""),  "error",  edtavPasswordconf_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredfirstname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV22FirstName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavFirstname_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredlastname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV31LastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Sobrenome", "", "", "", "", "", "", "", ""),  "error",  edtavLastname_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredbirthday ) && (DateTime.MinValue==AV11Birthday) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Data de nascimento", "", "", "", "", "", "", "", ""),  "error",  edtavBirthday_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredgender ) && String.IsNullOrEmpty(StringUtil.RTrim( AV24Gender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Sexo", "", "", "", "", "", "", "", ""),  "error",  cmbavGender_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredphone ) && String.IsNullOrEmpty(StringUtil.RTrim( AV45Phone)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Telefone", "", "", "", "", "", "", "", ""),  "error",  edtavPhone_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( cmbavAuthenticationtypename.ItemCount > 1 ) ) )
         {
            cmbavAuthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
            divAuthenticationtypename_cell_Class = "Invisible";
            AssignProp("", false, divAuthenticationtypename_cell_Internalname, "Class", divAuthenticationtypename_cell_Class, true);
         }
         else
         {
            cmbavAuthenticationtypename.Visible = 1;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
            divAuthenticationtypename_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divAuthenticationtypename_cell_Internalname, "Class", divAuthenticationtypename_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredemail )
         {
            divEmail_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         else
         {
            divEmail_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) )
         {
            edtavPassword_Visible = 0;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            divPassword_cell_Class = "Invisible";
            AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
         }
         else
         {
            edtavPassword_Visible = 1;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            if ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) )
            {
               divPassword_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
               AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
            }
            else
            {
               divPassword_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
               AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
            }
         }
         if ( ! ( ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) )
         {
            edtavPasswordconf_Visible = 0;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            divPasswordconf_cell_Class = "Invisible";
            AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
         }
         else
         {
            edtavPasswordconf_Visible = 1;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            if ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) )
            {
               divPasswordconf_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
               AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
            }
            else
            {
               divPasswordconf_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
               AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
            }
         }
         if ( AV23GAMRepository.gxTpr_Requiredfirstname )
         {
            divFirstname_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         else
         {
            divFirstname_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredlastname )
         {
            divLastname_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         else
         {
            divLastname_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredbirthday )
         {
            divBirthday_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divBirthday_cell_Internalname, "Class", divBirthday_cell_Class, true);
         }
         else
         {
            divBirthday_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divBirthday_cell_Internalname, "Class", divBirthday_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredgender )
         {
            divGender_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divGender_cell_Internalname, "Class", divGender_cell_Class, true);
         }
         else
         {
            divGender_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divGender_cell_Internalname, "Class", divGender_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredphone )
         {
            divPhone_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divPhone_cell_Internalname, "Class", divPhone_cell_Class, true);
         }
         else
         {
            divPhone_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divPhone_cell_Internalname, "Class", divPhone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV53User.gxTpr_Urlimage)) ) )
         {
            imgavImage_Visible = 0;
            AssignProp("", false, imgavImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImage_Visible), 5, 0), true);
            divImage_cell_Class = "Invisible";
            AssignProp("", false, divImage_cell_Internalname, "Class", divImage_cell_Class, true);
         }
         else
         {
            imgavImage_Visible = 1;
            AssignProp("", false, imgavImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImage_Visible), 5, 0), true);
            divImage_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divImage_cell_Internalname, "Class", divImage_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            chkavIsactive.Visible = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            divIsactive_cell_Class = "Invisible";
            AssignProp("", false, divIsactive_cell_Internalname, "Class", divIsactive_cell_Class, true);
         }
         else
         {
            chkavIsactive.Visible = 1;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            divIsactive_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divIsactive_cell_Internalname, "Class", divIsactive_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            chkavIsenabledinrepository.Visible = 0;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
            divIsenabledinrepository_cell_Class = "Invisible";
            AssignProp("", false, divIsenabledinrepository_cell_Internalname, "Class", divIsenabledinrepository_cell_Class, true);
         }
         else
         {
            chkavIsenabledinrepository.Visible = 1;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
            divIsenabledinrepository_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divIsenabledinrepository_cell_Internalname, "Class", divIsenabledinrepository_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavDatelastauthentication_Visible = 0;
            AssignProp("", false, edtavDatelastauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Visible), 5, 0), true);
            divDatelastauthentication_cell_Class = "Invisible";
            AssignProp("", false, divDatelastauthentication_cell_Internalname, "Class", divDatelastauthentication_cell_Class, true);
         }
         else
         {
            edtavDatelastauthentication_Visible = 1;
            AssignProp("", false, edtavDatelastauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Visible), 5, 0), true);
            divDatelastauthentication_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divDatelastauthentication_cell_Internalname, "Class", divDatelastauthentication_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.istwofactorauthenticationenabled() ) )
         {
            chkavEnabletwofactorauthentication.Visible = 0;
            AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Visible), 5, 0), true);
            divEnabletwofactorauthentication_cell_Class = "Invisible";
            AssignProp("", false, divEnabletwofactorauthentication_cell_Internalname, "Class", divEnabletwofactorauthentication_cell_Class, true);
         }
         else
         {
            chkavEnabletwofactorauthentication.Visible = 1;
            AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Visible), 5, 0), true);
            divEnabletwofactorauthentication_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divEnabletwofactorauthentication_cell_Internalname, "Class", divEnabletwofactorauthentication_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtpnumberlocked_Visible = 0;
            AssignProp("", false, edtavOtpnumberlocked_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Visible), 5, 0), true);
            divOtpnumberlocked_cell_Class = "Invisible";
            AssignProp("", false, divOtpnumberlocked_cell_Internalname, "Class", divOtpnumberlocked_cell_Class, true);
         }
         else
         {
            edtavOtpnumberlocked_Visible = 1;
            AssignProp("", false, edtavOtpnumberlocked_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Visible), 5, 0), true);
            divOtpnumberlocked_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divOtpnumberlocked_cell_Internalname, "Class", divOtpnumberlocked_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtplastlockeddate_Visible = 0;
            AssignProp("", false, edtavOtplastlockeddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Visible), 5, 0), true);
            divOtplastlockeddate_cell_Class = "Invisible";
            AssignProp("", false, divOtplastlockeddate_cell_Internalname, "Class", divOtplastlockeddate_cell_Class, true);
         }
         else
         {
            edtavOtplastlockeddate_Visible = 1;
            AssignProp("", false, edtavOtplastlockeddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Visible), 5, 0), true);
            divOtplastlockeddate_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divOtplastlockeddate_cell_Internalname, "Class", divOtplastlockeddate_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtpdailynumbercodes_Visible = 0;
            AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Visible), 5, 0), true);
            divOtpdailynumbercodes_cell_Class = "Invisible";
            AssignProp("", false, divOtpdailynumbercodes_cell_Internalname, "Class", divOtpdailynumbercodes_cell_Class, true);
         }
         else
         {
            edtavOtpdailynumbercodes_Visible = 1;
            AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Visible), 5, 0), true);
            divOtpdailynumbercodes_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divOtpdailynumbercodes_cell_Internalname, "Class", divOtpdailynumbercodes_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtplastdaterequestcode_Visible = 0;
            AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Visible), 5, 0), true);
            divOtplastdaterequestcode_cell_Class = "Invisible";
            AssignProp("", false, divOtplastdaterequestcode_cell_Internalname, "Class", divOtplastdaterequestcode_cell_Class, true);
         }
         else
         {
            edtavOtplastdaterequestcode_Visible = 1;
            AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Visible), 5, 0), true);
            divOtplastdaterequestcode_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divOtplastdaterequestcode_cell_Internalname, "Class", divOtplastdaterequestcode_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavActivationdate_Visible = 0;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            divActivationdate_cell_Class = "Invisible";
            AssignProp("", false, divActivationdate_cell_Internalname, "Class", divActivationdate_cell_Class, true);
         }
         else
         {
            edtavActivationdate_Visible = 1;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            divActivationdate_cell_Class = "DataContentCellFL";
            AssignProp("", false, divActivationdate_cell_Internalname, "Class", divActivationdate_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") != 0 ) ) )
         {
            edtavUrlprofile_Visible = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            divUrlprofile_cell_Class = "Invisible";
            AssignProp("", false, divUrlprofile_cell_Internalname, "Class", divUrlprofile_cell_Class, true);
         }
         else
         {
            edtavUrlprofile_Visible = 1;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            divUrlprofile_cell_Class = "DataContentCellFL";
            AssignProp("", false, divUrlprofile_cell_Internalname, "Class", divUrlprofile_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E151T2 ();
         if (returnInSub) return;
      }

      protected void E151T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV59CheckRequiredFieldsResult )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               AV53User.load( AV55UserId);
            }
            AV43PasswordIsOK = true;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
                  AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
                  AV28IsEnabledInRepository = true;
                  AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
                  if ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 )
                  {
                     if ( StringUtil.StrCmp(AV41Password, AV42PasswordConf) != 0 )
                     {
                        AV43PasswordIsOK = false;
                        GX_msglist.addItem("A senha n�o coincide com a confirma��o");
                     }
                  }
                  else
                  {
                     AV41Password = "";
                     AssignAttri("", false, "AV41Password", AV41Password);
                  }
               }
               if ( AV43PasswordIsOK )
               {
                  AV53User.gxTpr_Authenticationtypename = AV7AuthenticationTypeName;
                  AV53User.gxTpr_Name = AV36Name;
                  AV53User.gxTpr_Email = AV16Email;
                  AV53User.gxTpr_Firstname = AV22FirstName;
                  AV53User.gxTpr_Lastname = AV31LastName;
                  AV53User.gxTpr_Password = AV41Password;
                  AV53User.gxTpr_Externalid = AV20ExternalId;
                  AV53User.gxTpr_Birthday = AV11Birthday;
                  AV53User.gxTpr_Phone = AV45Phone;
                  AV53User.gxTpr_Gender = AV24Gender;
                  AV53User.gxTpr_Isactive = AV26IsActive;
                  AV12BlobPhoto = AV46Photo;
                  AV53User.gxTpr_Urlprofile = AV52URLProfile;
                  AV53User.gxTpr_Dontreceiveinformation = AV15DontReceiveInformation;
                  AV53User.gxTpr_Cannotchangepassword = AV13CannotChangePassword;
                  AV53User.gxTpr_Mustchangepassword = AV35MustChangePassword;
                  AV53User.gxTpr_Isblocked = AV27IsBlocked;
                  AV53User.gxTpr_Passwordneverexpires = AV44PasswordNeverExpires;
                  AV53User.gxTpr_Securitypolicyid = AV50SecurityPolicyId;
                  AV53User.gxTpr_Enabletwofactorauthentication = AV17EnableTwoFactorAuthentication;
                  AV53User.save();
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV53User.delete();
            }
            if ( AV43PasswordIsOK )
            {
               if ( AV53User.success() )
               {
                  context.CommitDataStores("gamuserentry",pr_default);
                  AV29isOK = true;
                  if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
                  {
                     if ( AV28IsEnabledInRepository != AV53User.gxTpr_Isenabledinrepository )
                     {
                        if ( AV28IsEnabledInRepository )
                        {
                           AV29isOK = AV53User.repositoryenable(out  AV19Errors);
                        }
                        else
                        {
                           AV29isOK = AV53User.repositorydisable(out  AV19Errors);
                        }
                     }
                  }
                  if ( AV29isOK )
                  {
                     context.CommitDataStores("gamuserentry",pr_default);
                     if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                     {
                        CallWebObject(formatLink("gamwwusers.aspx") );
                        context.wjLocDisableFrm = 1;
                     }
                     else
                     {
                        context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV55UserId});
                        context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV55UserId"});
                        context.wjLocDisableFrm = 1;
                        context.nUserReturn = 1;
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  else
                  {
                     AV68GXV5 = 1;
                     while ( AV68GXV5 <= AV19Errors.Count )
                     {
                        AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV68GXV5));
                        GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                        AV68GXV5 = (int)(AV68GXV5+1);
                     }
                  }
               }
               else
               {
                  AV19Errors = AV53User.geterrors();
                  AV69GXV6 = 1;
                  while ( AV69GXV6 <= AV19Errors.Count )
                  {
                     AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV69GXV6));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV69GXV6 = (int)(AV69GXV6+1);
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53User", AV53User);
      }

      protected void E161T2( )
      {
         /* Authenticationtypename_Isvalid Routine */
         returnInSub = false;
         AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
         AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E171T2( )
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
         AV55UserId = (string)getParm(obj,1);
         AssignAttri("", false, "AV55UserId", AV55UserId);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
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
         PA1T2( ) ;
         WS1T2( ) ;
         WE1T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910491577", true, true);
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
         context.AddJavascriptSource("gamuserentry.js", "?202311910491579", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAuthenticationtypename.Name = "vAUTHENTICATIONTYPENAME";
         cmbavAuthenticationtypename.WebTags = "";
         if ( cmbavAuthenticationtypename.ItemCount > 0 )
         {
            AV7AuthenticationTypeName = cmbavAuthenticationtypename.getValidValue(AV7AuthenticationTypeName);
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
         }
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", "N�o especificado", 0);
         cmbavGender.addItem("F", "Feminino", 0);
         cmbavGender.addItem("M", "Masculino", 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV24Gender = cmbavGender.getValidValue(AV24Gender);
            AssignAttri("", false, "AV24Gender", AV24Gender);
         }
         chkavIsactive.Name = "vISACTIVE";
         chkavIsactive.WebTags = "";
         chkavIsactive.Caption = "Ativo?";
         AssignProp("", false, chkavIsactive_Internalname, "TitleCaption", chkavIsactive.Caption, true);
         chkavIsactive.CheckedValue = "false";
         AV26IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV26IsActive));
         AssignAttri("", false, "AV26IsActive", AV26IsActive);
         chkavDontreceiveinformation.Name = "vDONTRECEIVEINFORMATION";
         chkavDontreceiveinformation.WebTags = "";
         chkavDontreceiveinformation.Caption = "Eu n�o desejo receber informa��o";
         AssignProp("", false, chkavDontreceiveinformation_Internalname, "TitleCaption", chkavDontreceiveinformation.Caption, true);
         chkavDontreceiveinformation.CheckedValue = "false";
         AV15DontReceiveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV15DontReceiveInformation));
         AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
         chkavCannotchangepassword.Name = "vCANNOTCHANGEPASSWORD";
         chkavCannotchangepassword.WebTags = "";
         chkavCannotchangepassword.Caption = "Voc� n�o pode alterar a senha";
         AssignProp("", false, chkavCannotchangepassword_Internalname, "TitleCaption", chkavCannotchangepassword.Caption, true);
         chkavCannotchangepassword.CheckedValue = "false";
         AV13CannotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV13CannotChangePassword));
         AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
         chkavMustchangepassword.Name = "vMUSTCHANGEPASSWORD";
         chkavMustchangepassword.WebTags = "";
         chkavMustchangepassword.Caption = "Voc� deve alterar a senha";
         AssignProp("", false, chkavMustchangepassword_Internalname, "TitleCaption", chkavMustchangepassword.Caption, true);
         chkavMustchangepassword.CheckedValue = "false";
         AV35MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV35MustChangePassword));
         AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
         chkavPasswordneverexpires.Name = "vPASSWORDNEVEREXPIRES";
         chkavPasswordneverexpires.WebTags = "";
         chkavPasswordneverexpires.Caption = "A senha nunca expira";
         AssignProp("", false, chkavPasswordneverexpires_Internalname, "TitleCaption", chkavPasswordneverexpires.Caption, true);
         chkavPasswordneverexpires.CheckedValue = "false";
         AV44PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV44PasswordNeverExpires));
         AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
         chkavIsblocked.Name = "vISBLOCKED";
         chkavIsblocked.WebTags = "";
         chkavIsblocked.Caption = "Est� bloqueado?";
         AssignProp("", false, chkavIsblocked_Internalname, "TitleCaption", chkavIsblocked.Caption, true);
         chkavIsblocked.CheckedValue = "false";
         AV27IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV27IsBlocked));
         AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
         cmbavSecuritypolicyid.Name = "vSECURITYPOLICYID";
         cmbavSecuritypolicyid.WebTags = "";
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV50SecurityPolicyId = (int)(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
         }
         chkavIsenabledinrepository.Name = "vISENABLEDINREPOSITORY";
         chkavIsenabledinrepository.WebTags = "";
         chkavIsenabledinrepository.Caption = "Voc� est� habilitado no reposit�rio?";
         AssignProp("", false, chkavIsenabledinrepository_Internalname, "TitleCaption", chkavIsenabledinrepository.Caption, true);
         chkavIsenabledinrepository.CheckedValue = "false";
         AV28IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsEnabledInRepository));
         AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
         chkavEnabletwofactorauthentication.Name = "vENABLETWOFACTORAUTHENTICATION";
         chkavEnabletwofactorauthentication.WebTags = "";
         chkavEnabletwofactorauthentication.Caption = "Ativar a autentica��o de dois fatores?";
         AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "TitleCaption", chkavEnabletwofactorauthentication.Caption, true);
         chkavEnabletwofactorauthentication.CheckedValue = "false";
         AV17EnableTwoFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV17EnableTwoFactorAuthentication));
         AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
         chkavUser_isenabledinrepository.Name = "USER_ISENABLEDINREPOSITORY";
         chkavUser_isenabledinrepository.WebTags = "";
         chkavUser_isenabledinrepository.Caption = "";
         AssignProp("", false, chkavUser_isenabledinrepository_Internalname, "TitleCaption", chkavUser_isenabledinrepository.Caption, true);
         chkavUser_isenabledinrepository.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavUserid_Internalname = "vUSERID";
         edtavUsernamespace_Internalname = "vUSERNAMESPACE";
         cmbavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME";
         divAuthenticationtypename_cell_Internalname = "AUTHENTICATIONTYPENAME_CELL";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         divEmail_cell_Internalname = "EMAIL_CELL";
         edtavPassword_Internalname = "vPASSWORD";
         divPassword_cell_Internalname = "PASSWORD_CELL";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         divPasswordconf_cell_Internalname = "PASSWORDCONF_CELL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divFirstname_cell_Internalname = "FIRSTNAME_CELL";
         edtavLastname_Internalname = "vLASTNAME";
         divLastname_cell_Internalname = "LASTNAME_CELL";
         edtavExternalid_Internalname = "vEXTERNALID";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divBirthday_cell_Internalname = "BIRTHDAY_CELL";
         cmbavGender_Internalname = "vGENDER";
         divGender_cell_Internalname = "GENDER_CELL";
         edtavPhone_Internalname = "vPHONE";
         divPhone_cell_Internalname = "PHONE_CELL";
         edtavUrlprofile_Internalname = "vURLPROFILE";
         divUrlprofile_cell_Internalname = "URLPROFILE_CELL";
         bttBtnurlprofilego_Internalname = "BTNURLPROFILEGO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         imgavImage_Internalname = "vIMAGE";
         divImage_cell_Internalname = "IMAGE_CELL";
         chkavIsactive_Internalname = "vISACTIVE";
         divIsactive_cell_Internalname = "ISACTIVE_CELL";
         edtavActivationdate_Internalname = "vACTIVATIONDATE";
         divActivationdate_cell_Internalname = "ACTIVATIONDATE_CELL";
         bttBtnsendactivationemail_Internalname = "BTNSENDACTIVATIONEMAIL";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         chkavDontreceiveinformation_Internalname = "vDONTRECEIVEINFORMATION";
         chkavCannotchangepassword_Internalname = "vCANNOTCHANGEPASSWORD";
         chkavMustchangepassword_Internalname = "vMUSTCHANGEPASSWORD";
         chkavPasswordneverexpires_Internalname = "vPASSWORDNEVEREXPIRES";
         chkavIsblocked_Internalname = "vISBLOCKED";
         cmbavSecuritypolicyid_Internalname = "vSECURITYPOLICYID";
         chkavIsenabledinrepository_Internalname = "vISENABLEDINREPOSITORY";
         divIsenabledinrepository_cell_Internalname = "ISENABLEDINREPOSITORY_CELL";
         edtavDatelastauthentication_Internalname = "vDATELASTAUTHENTICATION";
         divDatelastauthentication_cell_Internalname = "DATELASTAUTHENTICATION_CELL";
         chkavEnabletwofactorauthentication_Internalname = "vENABLETWOFACTORAUTHENTICATION";
         divEnabletwofactorauthentication_cell_Internalname = "ENABLETWOFACTORAUTHENTICATION_CELL";
         edtavOtpnumberlocked_Internalname = "vOTPNUMBERLOCKED";
         divOtpnumberlocked_cell_Internalname = "OTPNUMBERLOCKED_CELL";
         edtavOtplastlockeddate_Internalname = "vOTPLASTLOCKEDDATE";
         divOtplastlockeddate_cell_Internalname = "OTPLASTLOCKEDDATE_CELL";
         edtavOtpdailynumbercodes_Internalname = "vOTPDAILYNUMBERCODES";
         divOtpdailynumbercodes_cell_Internalname = "OTPDAILYNUMBERCODES_CELL";
         edtavOtplastdaterequestcode_Internalname = "vOTPLASTDATEREQUESTCODE";
         divOtplastdaterequestcode_cell_Internalname = "OTPLASTDATEREQUESTCODE_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavUser_isenabledinrepository_Internalname = "USER_ISENABLEDINREPOSITORY";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         chkavUser_isenabledinrepository.Caption = "";
         chkavEnabletwofactorauthentication.Caption = " ";
         chkavIsenabledinrepository.Caption = " ";
         chkavIsblocked.Caption = " ";
         chkavPasswordneverexpires.Caption = " ";
         chkavMustchangepassword.Caption = " ";
         chkavCannotchangepassword.Caption = " ";
         chkavDontreceiveinformation.Caption = " ";
         chkavIsactive.Caption = " ";
         chkavUser_isenabledinrepository.Visible = 1;
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         edtavOtplastdaterequestcode_Jsonclick = "";
         edtavOtplastdaterequestcode_Enabled = 1;
         edtavOtplastdaterequestcode_Visible = 1;
         divOtplastdaterequestcode_cell_Class = "col-xs-12 col-sm-6";
         edtavOtpdailynumbercodes_Jsonclick = "";
         edtavOtpdailynumbercodes_Enabled = 1;
         edtavOtpdailynumbercodes_Visible = 1;
         divOtpdailynumbercodes_cell_Class = "col-xs-12 col-sm-6";
         edtavOtplastlockeddate_Jsonclick = "";
         edtavOtplastlockeddate_Enabled = 1;
         edtavOtplastlockeddate_Visible = 1;
         divOtplastlockeddate_cell_Class = "col-xs-12 col-sm-6";
         edtavOtpnumberlocked_Jsonclick = "";
         edtavOtpnumberlocked_Enabled = 1;
         edtavOtpnumberlocked_Visible = 1;
         divOtpnumberlocked_cell_Class = "col-xs-12 col-sm-6";
         chkavEnabletwofactorauthentication.Enabled = 1;
         chkavEnabletwofactorauthentication.Visible = 1;
         divEnabletwofactorauthentication_cell_Class = "col-xs-12 col-sm-6";
         edtavDatelastauthentication_Jsonclick = "";
         edtavDatelastauthentication_Enabled = 1;
         edtavDatelastauthentication_Visible = 1;
         divDatelastauthentication_cell_Class = "col-xs-12 col-sm-6";
         chkavIsenabledinrepository.Enabled = 1;
         chkavIsenabledinrepository.Visible = 1;
         divIsenabledinrepository_cell_Class = "col-xs-12 col-sm-6";
         cmbavSecuritypolicyid_Jsonclick = "";
         cmbavSecuritypolicyid.Enabled = 1;
         chkavIsblocked.Enabled = 1;
         chkavPasswordneverexpires.Enabled = 1;
         chkavMustchangepassword.Enabled = 1;
         chkavCannotchangepassword.Enabled = 1;
         chkavDontreceiveinformation.Enabled = 1;
         bttBtnsendactivationemail_Visible = 1;
         edtavActivationdate_Jsonclick = "";
         edtavActivationdate_Enabled = 1;
         edtavActivationdate_Visible = 1;
         divActivationdate_cell_Class = "";
         chkavIsactive.Enabled = 1;
         chkavIsactive.Visible = 1;
         divIsactive_cell_Class = "col-xs-12 col-sm-6";
         imgavImage_gximage = "";
         imgavImage_Enabled = 0;
         imgavImage_Visible = 1;
         divImage_cell_Class = "col-xs-12 col-sm-6";
         bttBtnurlprofilego_Visible = 1;
         edtavUrlprofile_Jsonclick = "";
         edtavUrlprofile_Enabled = 1;
         edtavUrlprofile_Visible = 1;
         divUrlprofile_cell_Class = "";
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         divPhone_cell_Class = "col-xs-12 col-sm-6";
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         divGender_cell_Class = "col-xs-12 col-sm-6";
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         divBirthday_cell_Class = "col-xs-12 col-sm-6";
         edtavExternalid_Jsonclick = "";
         edtavExternalid_Enabled = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         divLastname_cell_Class = "col-xs-12 col-sm-6";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         divFirstname_cell_Class = "col-xs-12 col-sm-6";
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Visible = 1;
         divPasswordconf_cell_Class = "col-xs-12 col-sm-6";
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavPassword_Visible = 1;
         divPassword_cell_Class = "col-xs-12 col-sm-6";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         divEmail_cell_Class = "col-xs-12 col-sm-6";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         cmbavAuthenticationtypename_Jsonclick = "";
         cmbavAuthenticationtypename.Enabled = 1;
         cmbavAuthenticationtypename.Visible = 1;
         divAuthenticationtypename_cell_Class = "col-xs-12 col-sm-6";
         edtavUsernamespace_Jsonclick = "";
         edtavUsernamespace_Enabled = 1;
         edtavUserid_Jsonclick = "";
         edtavUserid_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Usu�rio";
         Dvpanel_tableattributes_Cls = "PanelCard Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "User ";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV26IsActive',fld:'vISACTIVE',pic:''},{av:'AV15DontReceiveInformation',fld:'vDONTRECEIVEINFORMATION',pic:''},{av:'AV13CannotChangePassword',fld:'vCANNOTCHANGEPASSWORD',pic:''},{av:'AV35MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV44PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV27IsBlocked',fld:'vISBLOCKED',pic:''},{av:'AV28IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV17EnableTwoFactorAuthentication',fld:'vENABLETWOFACTORAUTHENTICATION',pic:''},{av:'GXV1',fld:'USER_ISENABLEDINREPOSITORY',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV55UserId',fld:'vUSERID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'BTNSENDACTIVATIONEMAIL',prop:'Visible'},{ctrl:'BTNURLPROFILEGO',prop:'Visible'}]}");
         setEventMetadata("'DOSENDACTIVATIONEMAIL'","{handler:'E141T2',iparms:[{av:'AV55UserId',fld:'vUSERID',pic:'',hsh:true}]");
         setEventMetadata("'DOSENDACTIVATIONEMAIL'",",oparms:[]}");
         setEventMetadata("'DOURLPROFILEGO'","{handler:'E111T1',iparms:[{av:'AV52URLProfile',fld:'vURLPROFILE',pic:''}]");
         setEventMetadata("'DOURLPROFILEGO'",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E151T2',iparms:[{av:'AV59CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV55UserId',fld:'vUSERID',pic:'',hsh:true},{av:'cmbavAuthenticationtypename'},{av:'AV7AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV41Password',fld:'vPASSWORD',pic:''},{av:'AV42PasswordConf',fld:'vPASSWORDCONF',pic:''},{av:'AV36Name',fld:'vNAME',pic:''},{av:'AV16Email',fld:'vEMAIL',pic:''},{av:'AV22FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV31LastName',fld:'vLASTNAME',pic:''},{av:'AV20ExternalId',fld:'vEXTERNALID',pic:''},{av:'AV11Birthday',fld:'vBIRTHDAY',pic:''},{av:'AV45Phone',fld:'vPHONE',pic:''},{av:'cmbavGender'},{av:'AV24Gender',fld:'vGENDER',pic:''},{av:'AV26IsActive',fld:'vISACTIVE',pic:''},{av:'AV46Photo',fld:'vPHOTO',pic:''},{av:'AV52URLProfile',fld:'vURLPROFILE',pic:''},{av:'AV15DontReceiveInformation',fld:'vDONTRECEIVEINFORMATION',pic:''},{av:'AV13CannotChangePassword',fld:'vCANNOTCHANGEPASSWORD',pic:''},{av:'AV35MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV27IsBlocked',fld:'vISBLOCKED',pic:''},{av:'AV44PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'cmbavSecuritypolicyid'},{av:'AV50SecurityPolicyId',fld:'vSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'AV17EnableTwoFactorAuthentication',fld:'vENABLETWOFACTORAUTHENTICATION',pic:''},{av:'AV28IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV10AuthTypeId',fld:'vAUTHTYPEID',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV10AuthTypeId',fld:'vAUTHTYPEID',pic:''},{av:'AV28IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV41Password',fld:'vPASSWORD',pic:''},{av:'AV59CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
         setEventMetadata("VAUTHENTICATIONTYPENAME.ISVALID","{handler:'E161T2',iparms:[{av:'cmbavAuthenticationtypename'},{av:'AV7AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV10AuthTypeId',fld:'vAUTHTYPEID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("VAUTHENTICATIONTYPENAME.ISVALID",",oparms:[{av:'AV10AuthTypeId',fld:'vAUTHTYPEID',pic:''},{av:'cmbavAuthenticationtypename'},{av:'divAuthenticationtypename_cell_Class',ctrl:'AUTHENTICATIONTYPENAME_CELL',prop:'Class'},{av:'divEmail_cell_Class',ctrl:'EMAIL_CELL',prop:'Class'},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'divPassword_cell_Class',ctrl:'PASSWORD_CELL',prop:'Class'},{av:'edtavPasswordconf_Visible',ctrl:'vPASSWORDCONF',prop:'Visible'},{av:'divPasswordconf_cell_Class',ctrl:'PASSWORDCONF_CELL',prop:'Class'},{av:'divFirstname_cell_Class',ctrl:'FIRSTNAME_CELL',prop:'Class'},{av:'divLastname_cell_Class',ctrl:'LASTNAME_CELL',prop:'Class'},{av:'divBirthday_cell_Class',ctrl:'BIRTHDAY_CELL',prop:'Class'},{av:'divGender_cell_Class',ctrl:'GENDER_CELL',prop:'Class'},{av:'divPhone_cell_Class',ctrl:'PHONE_CELL',prop:'Class'},{av:'imgavImage_Visible',ctrl:'vIMAGE',prop:'Visible'},{av:'divImage_cell_Class',ctrl:'IMAGE_CELL',prop:'Class'},{av:'chkavIsactive.Visible',ctrl:'vISACTIVE',prop:'Visible'},{av:'divIsactive_cell_Class',ctrl:'ISACTIVE_CELL',prop:'Class'},{av:'chkavIsenabledinrepository.Visible',ctrl:'vISENABLEDINREPOSITORY',prop:'Visible'},{av:'divIsenabledinrepository_cell_Class',ctrl:'ISENABLEDINREPOSITORY_CELL',prop:'Class'},{av:'edtavDatelastauthentication_Visible',ctrl:'vDATELASTAUTHENTICATION',prop:'Visible'},{av:'divDatelastauthentication_cell_Class',ctrl:'DATELASTAUTHENTICATION_CELL',prop:'Class'},{av:'chkavEnabletwofactorauthentication.Visible',ctrl:'vENABLETWOFACTORAUTHENTICATION',prop:'Visible'},{av:'divEnabletwofactorauthentication_cell_Class',ctrl:'ENABLETWOFACTORAUTHENTICATION_CELL',prop:'Class'},{av:'edtavOtpnumberlocked_Visible',ctrl:'vOTPNUMBERLOCKED',prop:'Visible'},{av:'divOtpnumberlocked_cell_Class',ctrl:'OTPNUMBERLOCKED_CELL',prop:'Class'},{av:'edtavOtplastlockeddate_Visible',ctrl:'vOTPLASTLOCKEDDATE',prop:'Visible'},{av:'divOtplastlockeddate_cell_Class',ctrl:'OTPLASTLOCKEDDATE_CELL',prop:'Class'},{av:'edtavOtpdailynumbercodes_Visible',ctrl:'vOTPDAILYNUMBERCODES',prop:'Visible'},{av:'divOtpdailynumbercodes_cell_Class',ctrl:'OTPDAILYNUMBERCODES_CELL',prop:'Class'},{av:'edtavOtplastdaterequestcode_Visible',ctrl:'vOTPLASTDATEREQUESTCODE',prop:'Visible'},{av:'divOtplastdaterequestcode_cell_Class',ctrl:'OTPLASTDATEREQUESTCODE_CELL',prop:'Class'},{av:'edtavActivationdate_Visible',ctrl:'vACTIVATIONDATE',prop:'Visible'},{av:'divActivationdate_cell_Class',ctrl:'ACTIVATIONDATE_CELL',prop:'Class'},{av:'edtavUrlprofile_Visible',ctrl:'vURLPROFILE',prop:'Visible'},{av:'divUrlprofile_cell_Class',ctrl:'URLPROFILE_CELL',prop:'Class'}]}");
         setEventMetadata("VALIDV_BIRTHDAY","{handler:'Validv_Birthday',iparms:[]");
         setEventMetadata("VALIDV_BIRTHDAY",",oparms:[]}");
         setEventMetadata("VALIDV_GENDER","{handler:'Validv_Gender',iparms:[]");
         setEventMetadata("VALIDV_GENDER",",oparms:[]}");
         setEventMetadata("VALIDV_ACTIVATIONDATE","{handler:'Validv_Activationdate',iparms:[]");
         setEventMetadata("VALIDV_ACTIVATIONDATE",",oparms:[]}");
         setEventMetadata("VALIDV_DATELASTAUTHENTICATION","{handler:'Validv_Datelastauthentication',iparms:[]");
         setEventMetadata("VALIDV_DATELASTAUTHENTICATION",",oparms:[]}");
         setEventMetadata("VALIDV_OTPLASTLOCKEDDATE","{handler:'Validv_Otplastlockeddate',iparms:[]");
         setEventMetadata("VALIDV_OTPLASTLOCKEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_OTPLASTDATEREQUESTCODE","{handler:'Validv_Otplastdaterequestcode',iparms:[]");
         setEventMetadata("VALIDV_OTPLASTDATEREQUESTCODE",",oparms:[]}");
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
         wcpOAV55UserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV46Photo = "";
         AV10AuthTypeId = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV56UserNameSpace = "";
         AV7AuthenticationTypeName = "";
         AV36Name = "";
         AV16Email = "";
         AV41Password = "";
         AV42PasswordConf = "";
         AV22FirstName = "";
         AV31LastName = "";
         AV20ExternalId = "";
         AV11Birthday = DateTime.MinValue;
         AV24Gender = "";
         AV45Phone = "";
         AV52URLProfile = "";
         bttBtnurlprofilego_Jsonclick = "";
         AV25Image = "";
         AV66Image_GXI = "";
         sImgUrl = "";
         AV5ActivationDate = (DateTime)(DateTime.MinValue);
         bttBtnsendactivationemail_Jsonclick = "";
         AV14DateLastAuthentication = (DateTime)(DateTime.MinValue);
         AV39OTPLastLockedDate = (DateTime)(DateTime.MinValue);
         AV38OTPLastDateRequestCode = DateTime.MinValue;
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV53User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV23GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV8AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV30Language = "";
         AV19Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9AuthenticationTypesIns = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV48SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV21FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV49SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV47Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV54UserActivationKey = "";
         AV32LinkURL = "";
         AV34Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV33Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12BlobPhoto = "";
         AV18Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamuserentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamuserentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUserid_Enabled = 0;
         edtavUsernamespace_Enabled = 0;
         edtavActivationdate_Enabled = 0;
         edtavDatelastauthentication_Enabled = 0;
         edtavOtpnumberlocked_Enabled = 0;
         edtavOtplastlockeddate_Enabled = 0;
         edtavOtpdailynumbercodes_Enabled = 0;
         edtavOtplastdaterequestcode_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV40OTPNumberLocked ;
      private short AV37OTPDailyNumberCodes ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavUserid_Enabled ;
      private int edtavUsernamespace_Enabled ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPassword_Visible ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Visible ;
      private int edtavPasswordconf_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavExternalid_Enabled ;
      private int edtavBirthday_Enabled ;
      private int edtavPhone_Enabled ;
      private int edtavUrlprofile_Visible ;
      private int edtavUrlprofile_Enabled ;
      private int bttBtnurlprofilego_Visible ;
      private int imgavImage_Visible ;
      private int imgavImage_Enabled ;
      private int edtavActivationdate_Visible ;
      private int edtavActivationdate_Enabled ;
      private int bttBtnsendactivationemail_Visible ;
      private int AV50SecurityPolicyId ;
      private int edtavDatelastauthentication_Visible ;
      private int edtavDatelastauthentication_Enabled ;
      private int edtavOtpnumberlocked_Visible ;
      private int edtavOtpnumberlocked_Enabled ;
      private int edtavOtplastlockeddate_Visible ;
      private int edtavOtplastlockeddate_Enabled ;
      private int edtavOtpdailynumbercodes_Visible ;
      private int edtavOtpdailynumbercodes_Enabled ;
      private int edtavOtplastdaterequestcode_Visible ;
      private int edtavOtplastdaterequestcode_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV64GXV2 ;
      private int AV65GXV3 ;
      private int AV67GXV4 ;
      private int AV68GXV5 ;
      private int AV69GXV6 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV55UserId ;
      private string wcpOGx_mode ;
      private string wcpOAV55UserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV10AuthTypeId ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavUserid_Internalname ;
      private string edtavUserid_Jsonclick ;
      private string edtavUsernamespace_Internalname ;
      private string TempTags ;
      private string AV56UserNameSpace ;
      private string edtavUsernamespace_Jsonclick ;
      private string divAuthenticationtypename_cell_Internalname ;
      private string divAuthenticationtypename_cell_Class ;
      private string cmbavAuthenticationtypename_Internalname ;
      private string AV7AuthenticationTypeName ;
      private string cmbavAuthenticationtypename_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string divEmail_cell_Internalname ;
      private string divEmail_cell_Class ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divPassword_cell_Internalname ;
      private string divPassword_cell_Class ;
      private string edtavPassword_Internalname ;
      private string AV41Password ;
      private string edtavPassword_Jsonclick ;
      private string divPasswordconf_cell_Internalname ;
      private string divPasswordconf_cell_Class ;
      private string edtavPasswordconf_Internalname ;
      private string AV42PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string divFirstname_cell_Internalname ;
      private string divFirstname_cell_Class ;
      private string edtavFirstname_Internalname ;
      private string AV22FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divLastname_cell_Internalname ;
      private string divLastname_cell_Class ;
      private string edtavLastname_Internalname ;
      private string AV31LastName ;
      private string edtavLastname_Jsonclick ;
      private string edtavExternalid_Internalname ;
      private string edtavExternalid_Jsonclick ;
      private string divBirthday_cell_Internalname ;
      private string divBirthday_cell_Class ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Jsonclick ;
      private string divGender_cell_Internalname ;
      private string divGender_cell_Class ;
      private string cmbavGender_Internalname ;
      private string AV24Gender ;
      private string cmbavGender_Jsonclick ;
      private string divPhone_cell_Internalname ;
      private string divPhone_cell_Class ;
      private string edtavPhone_Internalname ;
      private string AV45Phone ;
      private string edtavPhone_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divUrlprofile_cell_Internalname ;
      private string divUrlprofile_cell_Class ;
      private string edtavUrlprofile_Internalname ;
      private string edtavUrlprofile_Jsonclick ;
      private string bttBtnurlprofilego_Internalname ;
      private string bttBtnurlprofilego_Jsonclick ;
      private string divImage_cell_Internalname ;
      private string divImage_cell_Class ;
      private string imgavImage_Internalname ;
      private string imgavImage_gximage ;
      private string sImgUrl ;
      private string divIsactive_cell_Internalname ;
      private string divIsactive_cell_Class ;
      private string chkavIsactive_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divActivationdate_cell_Internalname ;
      private string divActivationdate_cell_Class ;
      private string edtavActivationdate_Internalname ;
      private string edtavActivationdate_Jsonclick ;
      private string bttBtnsendactivationemail_Internalname ;
      private string bttBtnsendactivationemail_Jsonclick ;
      private string chkavDontreceiveinformation_Internalname ;
      private string chkavCannotchangepassword_Internalname ;
      private string chkavMustchangepassword_Internalname ;
      private string chkavPasswordneverexpires_Internalname ;
      private string chkavIsblocked_Internalname ;
      private string cmbavSecuritypolicyid_Internalname ;
      private string cmbavSecuritypolicyid_Jsonclick ;
      private string divIsenabledinrepository_cell_Internalname ;
      private string divIsenabledinrepository_cell_Class ;
      private string chkavIsenabledinrepository_Internalname ;
      private string divDatelastauthentication_cell_Internalname ;
      private string divDatelastauthentication_cell_Class ;
      private string edtavDatelastauthentication_Internalname ;
      private string edtavDatelastauthentication_Jsonclick ;
      private string divEnabletwofactorauthentication_cell_Internalname ;
      private string divEnabletwofactorauthentication_cell_Class ;
      private string chkavEnabletwofactorauthentication_Internalname ;
      private string divOtpnumberlocked_cell_Internalname ;
      private string divOtpnumberlocked_cell_Class ;
      private string edtavOtpnumberlocked_Internalname ;
      private string edtavOtpnumberlocked_Jsonclick ;
      private string divOtplastlockeddate_cell_Internalname ;
      private string divOtplastlockeddate_cell_Class ;
      private string edtavOtplastlockeddate_Internalname ;
      private string edtavOtplastlockeddate_Jsonclick ;
      private string divOtpdailynumbercodes_cell_Internalname ;
      private string divOtpdailynumbercodes_cell_Class ;
      private string edtavOtpdailynumbercodes_Internalname ;
      private string edtavOtpdailynumbercodes_Jsonclick ;
      private string divOtplastdaterequestcode_cell_Internalname ;
      private string divOtplastdaterequestcode_cell_Class ;
      private string edtavOtplastdaterequestcode_Internalname ;
      private string edtavOtplastdaterequestcode_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavUser_isenabledinrepository_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV30Language ;
      private string AV54UserActivationKey ;
      private DateTime AV5ActivationDate ;
      private DateTime AV14DateLastAuthentication ;
      private DateTime AV39OTPLastLockedDate ;
      private DateTime AV11Birthday ;
      private DateTime AV38OTPLastDateRequestCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV59CheckRequiredFieldsResult ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool AV25Image_IsBlob ;
      private bool AV26IsActive ;
      private bool AV15DontReceiveInformation ;
      private bool AV13CannotChangePassword ;
      private bool AV35MustChangePassword ;
      private bool AV44PasswordNeverExpires ;
      private bool AV27IsBlocked ;
      private bool AV28IsEnabledInRepository ;
      private bool AV17EnableTwoFactorAuthentication ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV43PasswordIsOK ;
      private bool AV29isOK ;
      private string AV36Name ;
      private string AV16Email ;
      private string AV20ExternalId ;
      private string AV52URLProfile ;
      private string AV66Image_GXI ;
      private string AV32LinkURL ;
      private string AV46Photo ;
      private string AV25Image ;
      private string AV12BlobPhoto ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV6AuthenticationType ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_UserId ;
      private GXCombobox cmbavAuthenticationtypename ;
      private GXCombobox cmbavGender ;
      private GXCheckbox chkavIsactive ;
      private GXCheckbox chkavDontreceiveinformation ;
      private GXCheckbox chkavCannotchangepassword ;
      private GXCheckbox chkavMustchangepassword ;
      private GXCheckbox chkavPasswordneverexpires ;
      private GXCheckbox chkavIsblocked ;
      private GXCombobox cmbavSecuritypolicyid ;
      private GXCheckbox chkavIsenabledinrepository ;
      private GXCheckbox chkavEnabletwofactorauthentication ;
      private GXCheckbox chkavUser_isenabledinrepository ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV8AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV48SecurityPolicies ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV34Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV18Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV9AuthenticationTypesIns ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV21FilterSecPol ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV23GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV47Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV53User ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV49SecurityPolicy ;
      private GeneXus.Utils.SdtMessages_Message AV33Message ;
   }

   public class gamuserentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamuserentry__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
