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
   public class gamrecoverpasswordstep2 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamrecoverpasswordstep2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public gamrecoverpasswordstep2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State ,
                           ref string aP1_KeyToChangePassword )
      {
         this.AV18IDP_State = aP0_IDP_State;
         this.AV9KeyToChangePassword = aP1_KeyToChangePassword;
         executePrivate();
         aP0_IDP_State=this.AV18IDP_State;
         aP1_KeyToChangePassword=this.AV9KeyToChangePassword;
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
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
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
         GXEncryptionTmp = "gamrecoverpasswordstep2.aspx"+UrlEncode(StringUtil.RTrim(AV18IDP_State)) + "," + UrlEncode(StringUtil.RTrim(AV9KeyToChangePassword));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamrecoverpasswordstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vKEYTOCHANGEPASSWORD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9KeyToChangePassword, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UserRememberMe), "Z9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV13UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vKEYTOCHANGEPASSWORD", StringUtil.RTrim( AV9KeyToChangePassword));
         GxWebStd.gx_hidden_field( context, "gxhash_vKEYTOCHANGEPASSWORD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9KeyToChangePassword, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV18IDP_State));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Width", StringUtil.RTrim( Dvpanel_tablelogin_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Autowidth", StringUtil.BoolToStr( Dvpanel_tablelogin_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Autoheight", StringUtil.BoolToStr( Dvpanel_tablelogin_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Cls", StringUtil.RTrim( Dvpanel_tablelogin_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Title", StringUtil.RTrim( Dvpanel_tablelogin_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Collapsible", StringUtil.BoolToStr( Dvpanel_tablelogin_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Collapsed", StringUtil.BoolToStr( Dvpanel_tablelogin_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablelogin_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Iconposition", StringUtil.RTrim( Dvpanel_tablelogin_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablelogin_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Width", StringUtil.RTrim( Dvpanel_tableerrorcontent_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Autowidth", StringUtil.BoolToStr( Dvpanel_tableerrorcontent_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Autoheight", StringUtil.BoolToStr( Dvpanel_tableerrorcontent_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Cls", StringUtil.RTrim( Dvpanel_tableerrorcontent_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Title", StringUtil.RTrim( Dvpanel_tableerrorcontent_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Collapsible", StringUtil.BoolToStr( Dvpanel_tableerrorcontent_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Collapsed", StringUtil.BoolToStr( Dvpanel_tableerrorcontent_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableerrorcontent_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Iconposition", StringUtil.RTrim( Dvpanel_tableerrorcontent_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEERRORCONTENT_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableerrorcontent_Autoscroll));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Enablefloatinglabels", StringUtil.BoolToStr( Wwputilites_Enablefloatinglabels));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilites_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilites_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilites_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Comboloadtype", StringUtil.RTrim( Wwputilites_Comboloadtype));
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
            WE0G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
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
         GXEncryptionTmp = "gamrecoverpasswordstep2.aspx"+UrlEncode(StringUtil.RTrim(AV18IDP_State)) + "," + UrlEncode(StringUtil.RTrim(AV9KeyToChangePassword));
         return formatLink("gamrecoverpasswordstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMRecoverPasswordStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return "Recover Password" ;
      }

      protected void WB0G0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLogin", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgHeaderoriginal_gximage, "")==0) ? "GX_Image_LogoLogin_Class" : "GX_Image_"+imgHeaderoriginal_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeaderoriginal_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablelogin.SetProperty("Width", Dvpanel_tablelogin_Width);
            ucDvpanel_tablelogin.SetProperty("AutoWidth", Dvpanel_tablelogin_Autowidth);
            ucDvpanel_tablelogin.SetProperty("AutoHeight", Dvpanel_tablelogin_Autoheight);
            ucDvpanel_tablelogin.SetProperty("Cls", Dvpanel_tablelogin_Cls);
            ucDvpanel_tablelogin.SetProperty("Title", Dvpanel_tablelogin_Title);
            ucDvpanel_tablelogin.SetProperty("Collapsible", Dvpanel_tablelogin_Collapsible);
            ucDvpanel_tablelogin.SetProperty("Collapsed", Dvpanel_tablelogin_Collapsed);
            ucDvpanel_tablelogin.SetProperty("ShowCollapseIcon", Dvpanel_tablelogin_Showcollapseicon);
            ucDvpanel_tablelogin.SetProperty("IconPosition", Dvpanel_tablelogin_Iconposition);
            ucDvpanel_tablelogin.SetProperty("AutoScroll", Dvpanel_tablelogin_Autoscroll);
            ucDvpanel_tablelogin.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablelogin_Internalname, "DVPANEL_TABLELOGINContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLELOGINContainer"+"TableLogin"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "WWP_GAM_Recover", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            wb_table1_23_0G2( true) ;
         }
         else
         {
            wb_table1_23_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_0G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableerror_Internalname, divTableerror_Visible, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableerrorcontent.SetProperty("Width", Dvpanel_tableerrorcontent_Width);
            ucDvpanel_tableerrorcontent.SetProperty("AutoWidth", Dvpanel_tableerrorcontent_Autowidth);
            ucDvpanel_tableerrorcontent.SetProperty("AutoHeight", Dvpanel_tableerrorcontent_Autoheight);
            ucDvpanel_tableerrorcontent.SetProperty("Cls", Dvpanel_tableerrorcontent_Cls);
            ucDvpanel_tableerrorcontent.SetProperty("Title", Dvpanel_tableerrorcontent_Title);
            ucDvpanel_tableerrorcontent.SetProperty("Collapsible", Dvpanel_tableerrorcontent_Collapsible);
            ucDvpanel_tableerrorcontent.SetProperty("Collapsed", Dvpanel_tableerrorcontent_Collapsed);
            ucDvpanel_tableerrorcontent.SetProperty("ShowCollapseIcon", Dvpanel_tableerrorcontent_Showcollapseicon);
            ucDvpanel_tableerrorcontent.SetProperty("IconPosition", Dvpanel_tableerrorcontent_Iconposition);
            ucDvpanel_tableerrorcontent.SetProperty("AutoScroll", Dvpanel_tableerrorcontent_Autoscroll);
            ucDvpanel_tableerrorcontent.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableerrorcontent_Internalname, "DVPANEL_TABLEERRORCONTENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEERRORCONTENTContainer"+"TableErrorContent"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableerrorcontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilites.SetProperty("EnableFloatingLabels", Wwputilites_Enablefloatinglabels);
            ucWwputilites.SetProperty("AllowColumnResizing", Wwputilites_Allowcolumnresizing);
            ucWwputilites.SetProperty("AllowColumnReordering", Wwputilites_Allowcolumnreordering);
            ucWwputilites.SetProperty("AllowColumnsRestore", Wwputilites_Allowcolumnsrestore);
            ucWwputilites.SetProperty("ComboLoadType", Wwputilites_Comboloadtype);
            ucWwputilites.Render(context, "wwp.workwithplusutilities_fal", Wwputilites_Internalname, "WWPUTILITESContainer");
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

      protected void START0G2( )
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
            Form.Meta.addItem("description", "Recover Password", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
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
                              E110G2 ();
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
                                    E120G2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "BACKTOLOGIN.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E140G2 ();
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

      protected void WE0G2( )
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

      protected void PA0G2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamrecoverpasswordstep2.aspx")), "gamrecoverpasswordstep2.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamrecoverpasswordstep2.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "IDP_State");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV18IDP_State = gxfirstwebparm;
                     AssignAttri("", false, "AV18IDP_State", AV18IDP_State);
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV9KeyToChangePassword = GetPar( "KeyToChangePassword");
                        AssignAttri("", false, "AV9KeyToChangePassword", AV9KeyToChangePassword);
                        GxWebStd.gx_hidden_field( context, "gxhash_vKEYTOCHANGEPASSWORD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9KeyToChangePassword, "")), context));
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
               GX_FocusControl = edtavUsername_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
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

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140G2 ();
            WB0G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV13UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vKEYTOCHANGEPASSWORD", StringUtil.RTrim( AV9KeyToChangePassword));
         GxWebStd.gx_hidden_field( context, "gxhash_vKEYTOCHANGEPASSWORD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9KeyToChangePassword, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17UserRememberMe), "Z9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tablelogin_Width = cgiGet( "DVPANEL_TABLELOGIN_Width");
            Dvpanel_tablelogin_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Autowidth"));
            Dvpanel_tablelogin_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Autoheight"));
            Dvpanel_tablelogin_Cls = cgiGet( "DVPANEL_TABLELOGIN_Cls");
            Dvpanel_tablelogin_Title = cgiGet( "DVPANEL_TABLELOGIN_Title");
            Dvpanel_tablelogin_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Collapsible"));
            Dvpanel_tablelogin_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Collapsed"));
            Dvpanel_tablelogin_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Showcollapseicon"));
            Dvpanel_tablelogin_Iconposition = cgiGet( "DVPANEL_TABLELOGIN_Iconposition");
            Dvpanel_tablelogin_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Autoscroll"));
            Dvpanel_tableerrorcontent_Width = cgiGet( "DVPANEL_TABLEERRORCONTENT_Width");
            Dvpanel_tableerrorcontent_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEERRORCONTENT_Autowidth"));
            Dvpanel_tableerrorcontent_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEERRORCONTENT_Autoheight"));
            Dvpanel_tableerrorcontent_Cls = cgiGet( "DVPANEL_TABLEERRORCONTENT_Cls");
            Dvpanel_tableerrorcontent_Title = cgiGet( "DVPANEL_TABLEERRORCONTENT_Title");
            Dvpanel_tableerrorcontent_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEERRORCONTENT_Collapsible"));
            Dvpanel_tableerrorcontent_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEERRORCONTENT_Collapsed"));
            Dvpanel_tableerrorcontent_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEERRORCONTENT_Showcollapseicon"));
            Dvpanel_tableerrorcontent_Iconposition = cgiGet( "DVPANEL_TABLEERRORCONTENT_Iconposition");
            Dvpanel_tableerrorcontent_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEERRORCONTENT_Autoscroll"));
            Wwputilites_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Enablefloatinglabels"));
            Wwputilites_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Allowcolumnresizing"));
            Wwputilites_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Allowcolumnreordering"));
            Wwputilites_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Allowcolumnsrestore"));
            Wwputilites_Comboloadtype = cgiGet( "WWPUTILITES_Comboloadtype");
            /* Read variables values. */
            AV14UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV14UserName", AV14UserName);
            AV15UserPasswordNew = cgiGet( edtavUserpasswordnew_Internalname);
            AssignAttri("", false, "AV15UserPasswordNew", AV15UserPasswordNew);
            AV16UserPasswordNewConf = cgiGet( edtavUserpasswordnewconf_Internalname);
            AssignAttri("", false, "AV16UserPasswordNewConf", AV16UserPasswordNewConf);
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
         E110G2 ();
         if (returnInSub) return;
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Backcolor = GXUtil.RGB( 238, 238, 238);
         AssignProp("", false, "FORM", "Backcolor", StringUtil.LTrimStr( (decimal)(Form.Backcolor), 9, 0), true);
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         divTableerror_Visible = 0;
         AssignProp("", false, divTableerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableerror_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120G2 ();
         if (returnInSub) return;
      }

      protected void E120G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15UserPasswordNew, AV16UserPasswordNewConf) == 0 )
         {
            AV12User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV13UserAuthTypeName, AV14UserName, out  AV8Errors);
            if ( AV8Errors.Count == 0 )
            {
               AV6ChangePwdOK = AV12User.changepasswordbykey(AV9KeyToChangePassword, AV15UserPasswordNew, out  AV8Errors);
               if ( AV6ChangePwdOK )
               {
                  context.CommitDataStores("gamrecoverpasswordstep2",pr_default);
                  AV5AdditionalParameter.gxTpr_Rememberusertype = AV17UserRememberMe;
                  AV5AdditionalParameter.gxTpr_Idpstate = AV18IDP_State;
                  AV10LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV14UserName, AV15UserPasswordNew, AV5AdditionalParameter, out  AV8Errors);
                  if ( AV10LoginOK )
                  {
                     if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV18IDP_State) )
                     {
                        new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV18IDP_State) ;
                     }
                     else
                     {
                        AV11URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11URL)) )
                        {
                           CallWebObject(formatLink("gamhome.aspx") );
                           context.wjLocDisableFrm = 1;
                        }
                        else
                        {
                           CallWebObject(formatLink(AV11URL) );
                           context.wjLocDisableFrm = 0;
                        }
                     }
                  }
                  else
                  {
                     /* Execute user subroutine: 'DISPLAYMESSAGES' */
                     S112 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         else
         {
            divTableerror_Visible = 1;
            AssignProp("", false, divTableerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableerror_Visible), 5, 0), true);
            GX_msglist.addItem("A nova senha não coincide com a confirmação");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void E130G2( )
      {
         /* Backtologin_Click Routine */
         returnInSub = false;
         if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV18IDP_State) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "gamremotelogin.aspx"+UrlEncode(StringUtil.RTrim(AV18IDP_State));
            CallWebObject(formatLink("gamremotelogin.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            CallWebObject(formatLink("login.aspx") );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         divTableerror_Visible = 1;
         AssignProp("", false, divTableerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableerror_Visible), 5, 0), true);
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV8Errors.Count )
         {
            AV7Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV8Errors.Item(AV24GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1", AV7Error.gxTpr_Message, "", "", "", "", "", "", "", ""));
            AV24GXV1 = (int)(AV24GXV1+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_23_0G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL DataContentCellLogin'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User Name", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV14UserName, StringUtil.RTrim( context.localUtil.Format( AV14UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL DataContentCellLogin'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpasswordnew_Internalname, "User Password New", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpasswordnew_Internalname, StringUtil.RTrim( AV15UserPasswordNew), StringUtil.RTrim( context.localUtil.Format( AV15UserPasswordNew, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpasswordnew_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUserpasswordnew_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL DataContentCellLogin'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpasswordnewconf_Internalname, "User Password New Conf", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpasswordnewconf_Internalname, StringUtil.RTrim( AV16UserPasswordNewConf), StringUtil.RTrim( context.localUtil.Format( AV16UserPasswordNewConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpasswordnewconf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUserpasswordnewconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellPaddingLogin'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "align-self:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBacktologin_Internalname, "Voltar para o Login", "", "", lblBacktologin_Jsonclick, "'"+""+"'"+",false,"+"'"+"EBACKTOLOGIN.CLICK."+"'", "", "DataDescriptionLogin", 5, "", 1, 1, 0, 0, "HLP_GAMRecoverPasswordStep2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_0G2e( true) ;
         }
         else
         {
            wb_table1_23_0G2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV18IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV18IDP_State", AV18IDP_State);
         AV9KeyToChangePassword = (string)getParm(obj,1);
         AssignAttri("", false, "AV9KeyToChangePassword", AV9KeyToChangePassword);
         GxWebStd.gx_hidden_field( context, "gxhash_vKEYTOCHANGEPASSWORD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9KeyToChangePassword, "")), context));
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
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910472732", true, true);
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
         context.AddJavascriptSource("gamrecoverpasswordstep2.js", "?202311910472735", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeaderoriginal_Internalname = "HEADERORIGINAL";
         lblSignin_Internalname = "SIGNIN";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpasswordnew_Internalname = "vUSERPASSWORDNEW";
         edtavUserpasswordnewconf_Internalname = "vUSERPASSWORDNEWCONF";
         bttBtnenter_Internalname = "BTNENTER";
         lblBacktologin_Internalname = "BACKTOLOGIN";
         divActions_Internalname = "ACTIONS";
         tblUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablelogin_Internalname = "TABLELOGIN";
         Dvpanel_tablelogin_Internalname = "DVPANEL_TABLELOGIN";
         divTableerrorcontent_Internalname = "TABLEERRORCONTENT";
         Dvpanel_tableerrorcontent_Internalname = "DVPANEL_TABLEERRORCONTENT";
         divTableerror_Internalname = "TABLEERROR";
         divTablecontent_Internalname = "TABLECONTENT";
         Wwputilites_Internalname = "WWPUTILITES";
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
         edtavUserpasswordnewconf_Jsonclick = "";
         edtavUserpasswordnewconf_Enabled = 1;
         edtavUserpasswordnew_Jsonclick = "";
         edtavUserpasswordnew_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         divTableerror_Visible = 1;
         divLayoutmaintable_Class = "Table";
         Wwputilites_Comboloadtype = "InfiniteScrolling";
         Wwputilites_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilites_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilites_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilites_Enablefloatinglabels = Convert.ToBoolean( -1);
         Dvpanel_tableerrorcontent_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableerrorcontent_Iconposition = "Right";
         Dvpanel_tableerrorcontent_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableerrorcontent_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableerrorcontent_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableerrorcontent_Title = "";
         Dvpanel_tableerrorcontent_Cls = "PanelNoHeader CellMax400";
         Dvpanel_tableerrorcontent_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableerrorcontent_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableerrorcontent_Width = "100%";
         Dvpanel_tablelogin_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Iconposition = "Right";
         Dvpanel_tablelogin_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Title = "";
         Dvpanel_tablelogin_Cls = "PanelNoHeader CellMax400";
         Dvpanel_tablelogin_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablelogin_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Recover Password";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true},{av:'AV17UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV9KeyToChangePassword',fld:'vKEYTOCHANGEPASSWORD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E120G2',iparms:[{av:'AV15UserPasswordNew',fld:'vUSERPASSWORDNEW',pic:''},{av:'AV16UserPasswordNewConf',fld:'vUSERPASSWORDNEWCONF',pic:''},{av:'AV13UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true},{av:'AV14UserName',fld:'vUSERNAME',pic:''},{av:'AV9KeyToChangePassword',fld:'vKEYTOCHANGEPASSWORD',pic:'',hsh:true},{av:'AV17UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV18IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'divTableerror_Visible',ctrl:'TABLEERROR',prop:'Visible'}]}");
         setEventMetadata("BACKTOLOGIN.CLICK","{handler:'E130G2',iparms:[{av:'AV18IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("BACKTOLOGIN.CLICK",",oparms:[{av:'AV18IDP_State',fld:'vIDP_STATE',pic:''}]}");
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
         wcpOAV18IDP_State = "";
         wcpOAV9KeyToChangePassword = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV13UserAuthTypeName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         imgHeaderoriginal_gximage = "";
         StyleString = "";
         sImgUrl = "";
         ucDvpanel_tablelogin = new GXUserControl();
         lblSignin_Jsonclick = "";
         ucDvpanel_tableerrorcontent = new GXUserControl();
         ucWwputilites = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV14UserName = "";
         AV15UserPasswordNew = "";
         AV16UserPasswordNewConf = "";
         AV12User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV11URL = "";
         AV7Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         lblBacktologin_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamrecoverpasswordstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamrecoverpasswordstep2__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV17UserRememberMe ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divTableerror_Visible ;
      private int AV24GXV1 ;
      private int edtavUsername_Enabled ;
      private int edtavUserpasswordnew_Enabled ;
      private int edtavUserpasswordnewconf_Enabled ;
      private int idxLst ;
      private string AV18IDP_State ;
      private string AV9KeyToChangePassword ;
      private string wcpOAV18IDP_State ;
      private string wcpOAV9KeyToChangePassword ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV13UserAuthTypeName ;
      private string Dvpanel_tablelogin_Width ;
      private string Dvpanel_tablelogin_Cls ;
      private string Dvpanel_tablelogin_Title ;
      private string Dvpanel_tablelogin_Iconposition ;
      private string Dvpanel_tableerrorcontent_Width ;
      private string Dvpanel_tableerrorcontent_Cls ;
      private string Dvpanel_tableerrorcontent_Title ;
      private string Dvpanel_tableerrorcontent_Iconposition ;
      private string Wwputilites_Comboloadtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string imgHeaderoriginal_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeaderoriginal_Internalname ;
      private string Dvpanel_tablelogin_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divTableerror_Internalname ;
      private string Dvpanel_tableerrorcontent_Internalname ;
      private string divTableerrorcontent_Internalname ;
      private string Wwputilites_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavUsername_Internalname ;
      private string AV15UserPasswordNew ;
      private string edtavUserpasswordnew_Internalname ;
      private string AV16UserPasswordNewConf ;
      private string edtavUserpasswordnewconf_Internalname ;
      private string sStyleString ;
      private string tblUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpasswordnew_Jsonclick ;
      private string edtavUserpasswordnewconf_Jsonclick ;
      private string divActions_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string lblBacktologin_Internalname ;
      private string lblBacktologin_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablelogin_Autowidth ;
      private bool Dvpanel_tablelogin_Autoheight ;
      private bool Dvpanel_tablelogin_Collapsible ;
      private bool Dvpanel_tablelogin_Collapsed ;
      private bool Dvpanel_tablelogin_Showcollapseicon ;
      private bool Dvpanel_tablelogin_Autoscroll ;
      private bool Dvpanel_tableerrorcontent_Autowidth ;
      private bool Dvpanel_tableerrorcontent_Autoheight ;
      private bool Dvpanel_tableerrorcontent_Collapsible ;
      private bool Dvpanel_tableerrorcontent_Collapsed ;
      private bool Dvpanel_tableerrorcontent_Showcollapseicon ;
      private bool Dvpanel_tableerrorcontent_Autoscroll ;
      private bool Wwputilites_Enablefloatinglabels ;
      private bool Wwputilites_Allowcolumnresizing ;
      private bool Wwputilites_Allowcolumnreordering ;
      private bool Wwputilites_Allowcolumnsrestore ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV6ChangePwdOK ;
      private bool AV10LoginOK ;
      private string AV14UserName ;
      private string AV11URL ;
      private GXUserControl ucDvpanel_tablelogin ;
      private GXUserControl ucDvpanel_tableerrorcontent ;
      private GXUserControl ucWwputilites ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private string aP1_KeyToChangePassword ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV7Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12User ;
   }

   public class gamrecoverpasswordstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamrecoverpasswordstep2__default : DataStoreHelperBase, IDataStoreHelper
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
