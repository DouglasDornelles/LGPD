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
   public class gamwwusers : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamwwusers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public gamwwusers( IGxContext context )
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
         cmbavFilusergender = new GXCombobox();
         cmbavFilauttype = new GXCombobox();
         cmbavFilrol = new GXCombobox();
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
         nRC_GXsfl_57 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_57"), "."));
         nGXsfl_57_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_57_idx"), "."));
         sGXsfl_57_idx = GetPar( "sGXsfl_57_idx");
         edtavBtnrole_Title = GetNextPar( );
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_57_Refreshing);
         edtavBtnsetpwd_Title = GetNextPar( );
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Title", edtavBtnsetpwd_Title, !bGXsfl_57_Refreshing);
         edtavBtnpermissions_Title = GetNextPar( );
         AssignProp("", false, edtavBtnpermissions_Internalname, "Title", edtavBtnpermissions_Title, !bGXsfl_57_Refreshing);
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
         AV76ManageFiltersExecutionStep = (short)(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV67ColumnsSelector);
         AV100Pgmname = GetPar( "Pgmname");
         cmbavFilusergender.FromJSonString( GetNextPar( ));
         AV21FilUserGender = GetPar( "FilUserGender");
         cmbavFilauttype.FromJSonString( GetNextPar( ));
         AV18FilAutType = GetPar( "FilAutType");
         AV40Search = GetPar( "Search");
         cmbavFilrol.FromJSonString( GetNextPar( ));
         AV41FilRol = (long)(NumberUtil.Val( GetPar( "FilRol"), "."));
         edtavBtnrole_Title = GetNextPar( );
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_57_Refreshing);
         edtavBtnsetpwd_Title = GetNextPar( );
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Title", edtavBtnsetpwd_Title, !bGXsfl_57_Refreshing);
         edtavBtnpermissions_Title = GetNextPar( );
         AssignProp("", false, edtavBtnpermissions_Internalname, "Title", edtavBtnpermissions_Title, !bGXsfl_57_Refreshing);
         AV83FirstIndex = (short)(NumberUtil.Val( GetPar( "FirstIndex"), "."));
         AV88IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV89IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV90IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV24GAMUserIsDeleted = StringUtil.StrToBool( GetPar( "GAMUserIsDeleted"));
         AV30IsAuthorized_BtnRole = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnRole"));
         AV91IsAuthorized_BtnPermissions = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnPermissions"));
         AV31IsAuthorized_BtnSetPwd = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnSetPwd"));
         AV23GAMUserIsAutoRegisteredUser = StringUtil.StrToBool( GetPar( "GAMUserIsAutoRegisteredUser"));
         AV44IsAuthorized_Name = StringUtil.StrToBool( GetPar( "IsAuthorized_Name"));
         AV92IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV100Pgmname, AV21FilUserGender, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV88IsAuthorized_Display, AV89IsAuthorized_Update, AV90IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV91IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV92IsAuthorized_Insert) ;
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
            return "gamwwusers_Execute" ;
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
         PA1U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1U2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwwusers.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV88IsAuthorized_Display, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV89IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV90IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISDELETED", GetSecureSignedToken( "", AV24GAMUserIsDeleted, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV91IsAuthorized_BtnPermissions, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISAUTOREGISTEREDUSER", GetSecureSignedToken( "", AV23GAMUserIsAutoRegisteredUser, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_57), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV80ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV80ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV85GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV73DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV73DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV67ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV67ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFIRSTINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83FirstIndex), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV88IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV88IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV89IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV89IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV90IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV90IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISDELETED", AV24GAMUserIsDeleted);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISDELETED", GetSecureSignedToken( "", AV24GAMUserIsDeleted, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV30IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPERMISSIONS", AV91IsAuthorized_BtnPermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV91IsAuthorized_BtnPermissions, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNSETPWD", AV31IsAuthorized_BtnSetPwd);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISAUTOREGISTEREDUSER", AV23GAMUserIsAutoRegisteredUser);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISAUTOREGISTEREDUSER", GetSecureSignedToken( "", AV23GAMUserIsAutoRegisteredUser, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV44IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV53GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV53GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "vBTNROLE_Title", StringUtil.RTrim( edtavBtnrole_Title));
         GxWebStd.gx_hidden_field( context, "vBTNSETPWD_Title", StringUtil.RTrim( edtavBtnsetpwd_Title));
         GxWebStd.gx_hidden_field( context, "vBTNPERMISSIONS_Title", StringUtil.RTrim( edtavBtnpermissions_Title));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE1U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1U2( ) ;
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
         return formatLink("gamwwusers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "GAMWWUsers" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuários" ;
      }

      protected void WB1U0( )
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "TableCellsWidthAuto", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUsers.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUsers.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-8", "Right", "top", "", "", "div");
            wb_table1_26_1U2( true) ;
         }
         else
         {
            wb_table1_26_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_26_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            StartGridControl57( ) ;
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            nRC_GXsfl_57 = (int)(nGXsfl_57_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV26GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV27GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV85GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV73DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV73DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV67ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamuserscount_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GAMUsersCount), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39GAMUsersCount), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamuserscount_Jsonclick, 0, "Attribute", "", "", "", "", edtavGamuserscount_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_GAMWWUsers.htm");
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
         if ( wbEnd == 57 )
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

      protected void START1U2( )
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
            Form.Meta.addItem("description", "Usuários", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1U0( ) ;
      }

      protected void WS1U2( )
      {
         START1U2( ) ;
         EVT1U2( ) ;
      }

      protected void EVT1U2( )
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
                              E111U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E151U2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VBTNUNBLOCKOTPCODES.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VBTNUNBLOCKOTPCODES.CLICK") == 0 ) )
                           {
                              nGXsfl_57_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
                              SubsflControlProps_572( ) ;
                              AV86Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV86Display);
                              AV87Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV87Update);
                              AV5Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV5Delete);
                              AV12BtnRole = cgiGet( edtavBtnrole_Internalname);
                              AssignAttri("", false, edtavBtnrole_Internalname, AV12BtnRole);
                              AV14BtnPermissions = cgiGet( edtavBtnpermissions_Internalname);
                              AssignAttri("", false, edtavBtnpermissions_Internalname, AV14BtnPermissions);
                              AV13BtnSetPwd = cgiGet( edtavBtnsetpwd_Internalname);
                              AssignAttri("", false, edtavBtnsetpwd_Internalname, AV13BtnSetPwd);
                              AV94BtnUnblockOTPCodes = cgiGet( edtavBtnunblockotpcodes_Internalname);
                              AssignAttri("", false, edtavBtnunblockotpcodes_Internalname, AV94BtnUnblockOTPCodes);
                              AV34Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV34Name);
                              AV22FirstName = cgiGet( edtavFirstname_Internalname);
                              AssignAttri("", false, edtavFirstname_Internalname, AV22FirstName);
                              AV33LastName = cgiGet( edtavLastname_Internalname);
                              AssignAttri("", false, edtavLastname_Internalname, AV33LastName);
                              AV9AuthenticationTypeName = cgiGet( edtavAuthenticationtypename_Internalname);
                              AssignAttri("", false, edtavAuthenticationtypename_Internalname, AV9AuthenticationTypeName);
                              AV28GUID = cgiGet( edtavGuid_Internalname);
                              AssignAttri("", false, edtavGuid_Internalname, AV28GUID);
                              GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV28GUID, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E161U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E171U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E181U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNUNBLOCKOTPCODES.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191U2 ();
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

      protected void WE1U2( )
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

      protected void PA1U2( )
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
               GX_FocusControl = edtavSearch_Internalname;
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
         SubsflControlProps_572( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            sendrow_572( ) ;
            nGXsfl_57_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV76ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV67ColumnsSelector ,
                                       string AV100Pgmname ,
                                       string AV21FilUserGender ,
                                       string AV18FilAutType ,
                                       string AV40Search ,
                                       long AV41FilRol ,
                                       short AV83FirstIndex ,
                                       bool AV88IsAuthorized_Display ,
                                       bool AV89IsAuthorized_Update ,
                                       bool AV90IsAuthorized_Delete ,
                                       bool AV24GAMUserIsDeleted ,
                                       bool AV30IsAuthorized_BtnRole ,
                                       bool AV91IsAuthorized_BtnPermissions ,
                                       bool AV31IsAuthorized_BtnSetPwd ,
                                       bool AV23GAMUserIsAutoRegisteredUser ,
                                       bool AV44IsAuthorized_Name ,
                                       bool AV92IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E171U2 ();
         GRID_nCurrentRecord = 0;
         RF1U2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28GUID, "")), context));
         GxWebStd.gx_hidden_field( context, "vGUID", StringUtil.RTrim( AV28GUID));
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
         if ( cmbavFilusergender.ItemCount > 0 )
         {
            AV21FilUserGender = cmbavFilusergender.getValidValue(AV21FilUserGender);
            AssignAttri("", false, "AV21FilUserGender", AV21FilUserGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilusergender.CurrentValue = StringUtil.RTrim( AV21FilUserGender);
            AssignProp("", false, cmbavFilusergender_Internalname, "Values", cmbavFilusergender.ToJavascriptSource(), true);
         }
         if ( cmbavFilauttype.ItemCount > 0 )
         {
            AV18FilAutType = cmbavFilauttype.getValidValue(AV18FilAutType);
            AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV18FilAutType);
            AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         }
         if ( cmbavFilrol.ItemCount > 0 )
         {
            AV41FilRol = (long)(NumberUtil.Val( cmbavFilrol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0))), "."));
            AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilrol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0));
            AssignProp("", false, cmbavFilrol_Internalname, "Values", cmbavFilrol.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV100Pgmname = "GAMWWUsers";
         context.Gx_err = 0;
         edtavDisplay_Enabled = 0;
         AssignProp("", false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnrole_Enabled = 0;
         AssignProp("", false, edtavBtnrole_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnpermissions_Enabled = 0;
         AssignProp("", false, edtavBtnpermissions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnpermissions_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnsetpwd_Enabled = 0;
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnsetpwd_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnunblockotpcodes_Enabled = 0;
         AssignProp("", false, edtavBtnunblockotpcodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnunblockotpcodes_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_57_Refreshing);
      }

      protected void RF1U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 57;
         /* Execute user event: Refresh */
         E171U2 ();
         nGXsfl_57_idx = 1;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         bGXsfl_57_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_572( ) ;
            E181U2 ();
            if ( ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_57_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E181U2 ();
            }
            wbEnd = 57;
            WB1U0( ) ;
         }
         bGXsfl_57_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1U2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFIRSTINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83FirstIndex), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV88IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV88IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV89IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV89IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV90IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV90IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISDELETED", AV24GAMUserIsDeleted);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISDELETED", GetSecureSignedToken( "", AV24GAMUserIsDeleted, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV30IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPERMISSIONS", AV91IsAuthorized_BtnPermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV91IsAuthorized_BtnPermissions, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNSETPWD", AV31IsAuthorized_BtnSetPwd);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISAUTOREGISTEREDUSER", AV23GAMUserIsAutoRegisteredUser);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISAUTOREGISTEREDUSER", GetSecureSignedToken( "", AV23GAMUserIsAutoRegisteredUser, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV44IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV28GUID, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( ))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : (decimal)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1))) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV100Pgmname, AV21FilUserGender, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV88IsAuthorized_Display, AV89IsAuthorized_Update, AV90IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV91IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV100Pgmname, AV21FilUserGender, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV88IsAuthorized_Display, AV89IsAuthorized_Update, AV90IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV91IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV100Pgmname, AV21FilUserGender, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV88IsAuthorized_Display, AV89IsAuthorized_Update, AV90IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV91IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV100Pgmname, AV21FilUserGender, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV88IsAuthorized_Display, AV89IsAuthorized_Update, AV90IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV91IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV100Pgmname, AV21FilUserGender, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV88IsAuthorized_Display, AV89IsAuthorized_Update, AV90IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV91IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV100Pgmname = "GAMWWUsers";
         context.Gx_err = 0;
         edtavDisplay_Enabled = 0;
         AssignProp("", false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnrole_Enabled = 0;
         AssignProp("", false, edtavBtnrole_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnpermissions_Enabled = 0;
         AssignProp("", false, edtavBtnpermissions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnpermissions_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnsetpwd_Enabled = 0;
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnsetpwd_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavBtnunblockotpcodes_Enabled = 0;
         AssignProp("", false, edtavBtnunblockotpcodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnunblockotpcodes_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E161U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV80ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV73DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV67ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_57 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), ",", "."));
            AV26GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV27GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV85GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
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
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV40Search = cgiGet( edtavSearch_Internalname);
            AssignAttri("", false, "AV40Search", AV40Search);
            cmbavFilusergender.Name = cmbavFilusergender_Internalname;
            cmbavFilusergender.CurrentValue = cgiGet( cmbavFilusergender_Internalname);
            AV21FilUserGender = cgiGet( cmbavFilusergender_Internalname);
            AssignAttri("", false, "AV21FilUserGender", AV21FilUserGender);
            cmbavFilauttype.Name = cmbavFilauttype_Internalname;
            cmbavFilauttype.CurrentValue = cgiGet( cmbavFilauttype_Internalname);
            AV18FilAutType = cgiGet( cmbavFilauttype_Internalname);
            AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
            cmbavFilrol.Name = cmbavFilrol_Internalname;
            cmbavFilrol.CurrentValue = cgiGet( cmbavFilrol_Internalname);
            AV41FilRol = (long)(NumberUtil.Val( cgiGet( cmbavFilrol_Internalname), "."));
            AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGamuserscount_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGamuserscount_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGAMUSERSCOUNT");
               GX_FocusControl = edtavGamuserscount_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39GAMUsersCount = 0;
               AssignAttri("", false, "AV39GAMUsersCount", StringUtil.LTrimStr( (decimal)(AV39GAMUsersCount), 4, 0));
            }
            else
            {
               AV39GAMUsersCount = (short)(context.localUtil.CToN( cgiGet( edtavGamuserscount_Internalname), ",", "."));
               AssignAttri("", false, "AV39GAMUsersCount", StringUtil.LTrimStr( (decimal)(AV39GAMUsersCount), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E161U2 ();
         if (returnInSub) return;
      }

      protected void E161U2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE>";
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "Caption", Gridpaginationbar_Caption);
         Gridpaginationbar_Pagestoshow = 0;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0));
         Gridpaginationbar_Showlast = false;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         edtavGamuserscount_Visible = 0;
         AssignProp("", false, edtavGamuserscount_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamuserscount_Visible), 5, 0), true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV49HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         GXt_boolean1 = AV44IsAuthorized_Name;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV44IsAuthorized_Name = GXt_boolean1;
         AssignAttri("", false, "AV44IsAuthorized_Name", AV44IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Usuários";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV73DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV73DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         cmbavFilauttype.removeAllItems();
         cmbavFilauttype.addItem("", "Todos", 0);
         AV10AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV20FilterAutType, out  AV17Errors);
         AV98GXV1 = 1;
         while ( AV98GXV1 <= AV10AuthenticationTypes.Count )
         {
            AV8AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV10AuthenticationTypes.Item(AV98GXV1));
            cmbavFilauttype.addItem(AV8AuthenticationType.gxTpr_Name, AV8AuthenticationType.gxTpr_Description, 0);
            AV98GXV1 = (int)(AV98GXV1+1);
         }
         cmbavFilrol.removeAllItems();
         cmbavFilrol.addItem("0", "Todos", 0);
         cmbavFilrol.addItem("-1", "Sem perfil", 0);
         AV45Roles = AV36Repository.getroles(AV43FilterRoles, out  AV17Errors);
         AV99GXV2 = 1;
         while ( AV99GXV2 <= AV45Roles.Count )
         {
            AV42Role = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV45Roles.Item(AV99GXV2));
            cmbavFilrol.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV42Role.gxTpr_Id), 12, 0)), AV42Role.gxTpr_Name, 0);
            AV99GXV2 = (int)(AV99GXV2+1);
         }
         edtavBtnrole_Title = "Perfis";
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_57_Refreshing);
         edtavBtnsetpwd_Title = "Senha";
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Title", edtavBtnsetpwd_Title, !bGXsfl_57_Refreshing);
         edtavBtnpermissions_Title = "Permissões";
         AssignProp("", false, edtavBtnpermissions_Internalname, "Title", edtavBtnpermissions_Title, !bGXsfl_57_Refreshing);
         AV36Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
      }

      protected void E171U2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV50WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV76ManageFiltersExecutionStep == 1 )
         {
            AV76ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV76ManageFiltersExecutionStep == 2 )
         {
            AV76ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV72Session.Get("GAMWWUsersColumnsSelector"), "") != 0 )
         {
            AV55ColumnsSelectorXML = AV72Session.Get("GAMWWUsersColumnsSelector");
            AV67ColumnsSelector.FromXml(AV55ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S152 ();
            if (returnInSub) return;
         }
         edtavName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), !bGXsfl_57_Refreshing);
         edtavFirstname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavFirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFirstname_Visible), 5, 0), !bGXsfl_57_Refreshing);
         edtavLastname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLastname_Visible), 5, 0), !bGXsfl_57_Refreshing);
         edtavAuthenticationtypename_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Visible), 5, 0), !bGXsfl_57_Refreshing);
         AV26GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV26GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV26GridCurrentPage), 10, 0));
         GXt_char3 = AV85GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV100Pgmname, out  GXt_char3) ;
         AV85GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV85GridAppliedFilters", AV85GridAppliedFilters);
         AV26GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV26GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV26GridCurrentPage), 10, 0));
         AV6GridPageSize = subGrid_Rows;
         AV19Filter.gxTpr_Gender = AV21FilUserGender;
         AV19Filter.gxTpr_Authenticationtypename = AV18FilAutType;
         AV19Filter.gxTpr_Loadcustomattributes = false;
         AV19Filter.gxTpr_Returnanonymoususer = false;
         AV19Filter.gxTpr_Limit = (int)(AV6GridPageSize+1);
         AV83FirstIndex = (short)((AV26GridCurrentPage-1)*AV6GridPageSize+1);
         AssignAttri("", false, "AV83FirstIndex", StringUtil.LTrimStr( (decimal)(AV83FirstIndex), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         AV19Filter.gxTpr_Start = AV83FirstIndex-1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Search)) )
         {
            AV19Filter.gxTpr_Searchable = "%"+AV40Search;
         }
         if ( AV41FilRol == -1 )
         {
            AV19Filter.gxTpr_Withoutroles = true;
         }
         else
         {
            AV19Filter.gxTpr_Roleid = AV41FilRol;
         }
         AV25GAMUsers = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusersorderby(AV19Filter, 0, out  AV17Errors);
         if ( cmbavFilauttype.ItemCount == 2 )
         {
            edtavAuthenticationtypename_Visible = 0;
            AssignProp("", false, edtavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         if ( AV25GAMUsers.Count == AV19Filter.gxTpr_Limit )
         {
            AV7GridRecordCount = (long)(AV26GridCurrentPage*AV6GridPageSize+1);
            AV27GridPageCount = (long)(AV26GridCurrentPage+1);
            AssignAttri("", false, "AV27GridPageCount", StringUtil.LTrimStr( (decimal)(AV27GridPageCount), 10, 0));
         }
         else
         {
            AV7GridRecordCount = (long)((AV26GridCurrentPage-1)*AV6GridPageSize+AV25GAMUsers.Count);
            AV27GridPageCount = AV26GridCurrentPage;
            AssignAttri("", false, "AV27GridPageCount", StringUtil.LTrimStr( (decimal)(AV27GridPageCount), 10, 0));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void E121U2( )
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
            AV35PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV35PageToGo) ;
         }
      }

      protected void E131U2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E181U2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV64i = 1;
         while ( AV64i <= AV83FirstIndex - 1 )
         {
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 57;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_572( ) ;
               GRID_nEOF = 1;
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
               {
                  GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
               }
            }
            if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
            {
               GRID_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            }
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
            {
               context.DoAjaxLoad(57, GridRow);
            }
            AV64i = (long)(AV64i+1);
         }
         AV101GXV3 = 1;
         while ( AV101GXV3 <= AV25GAMUsers.Count )
         {
            AV38User = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV25GAMUsers.Item(AV101GXV3));
            AV9AuthenticationTypeName = AV38User.gxTpr_Authenticationtypename;
            AssignAttri("", false, edtavAuthenticationtypename_Internalname, AV9AuthenticationTypeName);
            AV28GUID = AV38User.gxTpr_Guid;
            AssignAttri("", false, edtavGuid_Internalname, AV28GUID);
            GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV28GUID, "")), context));
            AV34Name = AV38User.gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV34Name);
            AV22FirstName = AV38User.gxTpr_Firstname;
            AssignAttri("", false, edtavFirstname_Internalname, AV22FirstName);
            AV33LastName = AV38User.gxTpr_Lastname;
            AssignAttri("", false, edtavLastname_Internalname, AV33LastName);
            if ( AV38User.gxTpr_Isenabledinrepository )
            {
               edtavName_Class = "ReadonlyAttribute";
               edtavFirstname_Class = "ReadonlyAttribute";
               edtavLastname_Class = "ReadonlyAttribute";
               edtavAuthenticationtypename_Class = "ReadonlyAttribute";
            }
            else
            {
               edtavName_Class = "AttributeInactive";
               edtavFirstname_Class = "AttributeInactive";
               edtavLastname_Class = "AttributeInactive";
               edtavAuthenticationtypename_Class = "AttributeInactive";
            }
            AV86Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavDisplay_Internalname, AV86Display);
            if ( AV88IsAuthorized_Display )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)));
               edtavDisplay_Link = formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV87Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri("", false, edtavUpdate_Internalname, AV87Update);
            if ( AV89IsAuthorized_Update )
            {
               if ( ! ( ( StringUtil.StrCmp(StringUtil.Trim( AV28GUID), StringUtil.Trim( AV36Repository.gxTpr_Anonymoususerguid)) == 0 ) || AV38User.gxTpr_Isautoregistereduser ) )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)));
                  edtavUpdate_Link = formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  edtavUpdate_Class = "Attribute";
               }
               else
               {
                  edtavUpdate_Link = "";
                  edtavUpdate_Class = "Invisible";
               }
            }
            AV5Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV5Delete);
            if ( AV90IsAuthorized_Delete )
            {
               if ( ! ( ( StringUtil.StrCmp(StringUtil.Trim( AV28GUID), StringUtil.Trim( AV36Repository.gxTpr_Anonymoususerguid)) == 0 ) || AV24GAMUserIsDeleted ) )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)));
                  edtavDelete_Link = formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  edtavDelete_Class = "Attribute";
               }
               else
               {
                  edtavDelete_Link = "";
                  edtavDelete_Class = "Invisible";
               }
            }
            AV12BtnRole = "<i class=\"fa fa-cog\"></i>";
            AssignAttri("", false, edtavBtnrole_Internalname, AV12BtnRole);
            if ( AV30IsAuthorized_BtnRole )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "gamwwuserroles.aspx"+UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)));
               edtavBtnrole_Link = formatLink("gamwwuserroles.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV14BtnPermissions = "<i class=\"fa fa-lock\"></i>";
            AssignAttri("", false, edtavBtnpermissions_Internalname, AV14BtnPermissions);
            if ( AV91IsAuthorized_BtnPermissions )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "gamwwuserpermissions.aspx"+UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID))) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
               edtavBtnpermissions_Link = formatLink("gamwwuserpermissions.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV13BtnSetPwd = "<i class=\"fa fa-key\"></i>";
            AssignAttri("", false, edtavBtnsetpwd_Internalname, AV13BtnSetPwd);
            if ( AV31IsAuthorized_BtnSetPwd )
            {
               if ( ! ( ( StringUtil.StrCmp(StringUtil.Trim( AV28GUID), StringUtil.Trim( AV36Repository.gxTpr_Anonymoususerguid)) == 0 ) || AV23GAMUserIsAutoRegisteredUser ) )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "gamsetpassword.aspx"+UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)));
                  edtavBtnsetpwd_Link = formatLink("gamsetpassword.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  edtavBtnsetpwd_Class = "Attribute";
               }
               else
               {
                  edtavBtnsetpwd_Link = "";
                  edtavBtnsetpwd_Class = "Invisible";
               }
            }
            AV94BtnUnblockOTPCodes = "<i class=\"fas fa-unlock\"></i>";
            AssignAttri("", false, edtavBtnunblockotpcodes_Internalname, AV94BtnUnblockOTPCodes);
            if ( AV36Repository.isonetimepasswordenabled() )
            {
               edtavBtnunblockotpcodes_Class = "Attribute";
            }
            else
            {
               edtavBtnunblockotpcodes_Class = "Invisible";
            }
            if ( AV44IsAuthorized_Name )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)));
               edtavName_Link = formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 57;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_572( ) ;
               GRID_nEOF = 1;
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
               {
                  GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
               }
            }
            if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
            {
               GRID_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            }
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
            {
               context.DoAjaxLoad(57, GridRow);
            }
            AV101GXV3 = (int)(AV101GXV3+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E141U2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV55ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV67ColumnsSelector.FromJSonString(AV55ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "GAMWWUsersColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV55ColumnsSelectorXML)) ? "" : AV67ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void E111U2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("GAMWWUsersFilters")) + "," + UrlEncode(StringUtil.RTrim(AV100Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV76ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("GAMWWUsersFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV76ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV77ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "GAMWWUsersFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV77ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV77ManageFiltersXml) ;
               AV53GridState.FromXml(AV77ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
               context.DoAjaxRefresh();
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
         cmbavFilusergender.CurrentValue = StringUtil.RTrim( AV21FilUserGender);
         AssignProp("", false, cmbavFilusergender_Internalname, "Values", cmbavFilusergender.ToJavascriptSource(), true);
         cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV18FilAutType);
         AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         cmbavFilrol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0));
         AssignProp("", false, cmbavFilrol_Internalname, "Values", cmbavFilrol.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
      }

      protected void E151U2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV92IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "gamuserentry.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("gamuserentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void S152( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV67ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&Name",  "",  "WWP_GAM_Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&FirstName",  "",  "WWP_GAM_FirstName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&LastName",  "",  "WWP_GAM_LastName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&AuthenticationTypeName",  "",  "WWP_GAM_Authentication",  true,  "") ;
         GXt_char3 = AV62UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "GAMWWUsersColumnsSelector", out  GXt_char3) ;
         AV62UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62UserCustomValue)) ) )
         {
            AV84ColumnsSelectorAux.FromXml(AV62UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV84ColumnsSelectorAux, ref  AV67ColumnsSelector) ;
         }
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV88IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV88IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV88IsAuthorized_Display", AV88IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV88IsAuthorized_Display, context));
         if ( ! ( AV88IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         GXt_boolean1 = AV89IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV89IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV89IsAuthorized_Update", AV89IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV89IsAuthorized_Update, context));
         if ( ! ( AV89IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         GXt_boolean1 = AV90IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV90IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV90IsAuthorized_Delete", AV90IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV90IsAuthorized_Delete, context));
         if ( ! ( AV90IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         GXt_boolean1 = AV30IsAuthorized_BtnRole;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwuserroles_Execute", out  GXt_boolean1) ;
         AV30IsAuthorized_BtnRole = GXt_boolean1;
         AssignAttri("", false, "AV30IsAuthorized_BtnRole", AV30IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         if ( ! ( AV30IsAuthorized_BtnRole ) )
         {
            edtavBtnrole_Visible = 0;
            AssignProp("", false, edtavBtnrole_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         GXt_boolean1 = AV91IsAuthorized_BtnPermissions;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwuserpermissions_Execute", out  GXt_boolean1) ;
         AV91IsAuthorized_BtnPermissions = GXt_boolean1;
         AssignAttri("", false, "AV91IsAuthorized_BtnPermissions", AV91IsAuthorized_BtnPermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV91IsAuthorized_BtnPermissions, context));
         if ( ! ( AV91IsAuthorized_BtnPermissions ) )
         {
            edtavBtnpermissions_Visible = 0;
            AssignProp("", false, edtavBtnpermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnpermissions_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         GXt_boolean1 = AV31IsAuthorized_BtnSetPwd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamsetpassword_Execute", out  GXt_boolean1) ;
         AV31IsAuthorized_BtnSetPwd = GXt_boolean1;
         AssignAttri("", false, "AV31IsAuthorized_BtnSetPwd", AV31IsAuthorized_BtnSetPwd);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         if ( ! ( AV31IsAuthorized_BtnSetPwd ) )
         {
            edtavBtnsetpwd_Visible = 0;
            AssignProp("", false, edtavBtnsetpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnsetpwd_Visible), 5, 0), !bGXsfl_57_Refreshing);
         }
         GXt_boolean1 = AV92IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV92IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV92IsAuthorized_Insert", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
         if ( ! ( AV92IsAuthorized_Insert && ( (0==AV36Repository.gxTpr_Authenticationmasterrepositoryid) ) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV80ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "GAMWWUsersFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV80ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV40Search = "";
         AssignAttri("", false, "AV40Search", AV40Search);
         AV21FilUserGender = "";
         AssignAttri("", false, "AV21FilUserGender", AV21FilUserGender);
         AV18FilAutType = "";
         AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
         AV41FilRol = 0;
         AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV72Session.Get(AV100Pgmname+"GridState"), "") == 0 )
         {
            AV53GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV100Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV53GridState.FromXml(AV72Session.Get(AV100Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV53GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV53GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV53GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV102GXV4 = 1;
         while ( AV102GXV4 <= AV53GridState.gxTpr_Filtervalues.Count )
         {
            AV54GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV53GridState.gxTpr_Filtervalues.Item(AV102GXV4));
            if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "SEARCH") == 0 )
            {
               AV40Search = AV54GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40Search", AV40Search);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILUSERGENDER") == 0 )
            {
               AV21FilUserGender = AV54GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21FilUserGender", AV21FilUserGender);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILAUTTYPE") == 0 )
            {
               AV18FilAutType = AV54GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILROL") == 0 )
            {
               AV41FilRol = (long)(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
            }
            AV102GXV4 = (int)(AV102GXV4+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV53GridState.FromXml(AV72Session.Get(AV100Pgmname+"GridState"), null, "", "");
         AV53GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "SEARCH",  "Procurar",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40Search)),  0,  AV40Search,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "FILUSERGENDER",  "Sexo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21FilUserGender)),  0,  AV21FilUserGender,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "FILAUTTYPE",  "Autenticação",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18FilAutType)),  0,  AV18FilAutType,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "FILROL",  "Perfil",  !(0==AV41FilRol),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0)),  "") ;
         AV53GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV53GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV53GridState.ToXml(false, true, "", "")) ;
      }

      protected void E191U2( )
      {
         /* Btnunblockotpcodes_Click Routine */
         returnInSub = false;
         AV38User.load( AV28GUID);
         if ( AV38User.unblockotpcodes(out  AV17Errors) )
         {
            context.CommitDataStores("gamwwusers",pr_default);
            GX_msglist.addItem("O usuário foi desbloqueado com sucesso para obter códigos OTP!");
         }
         else
         {
            AV103GXV5 = 1;
            while ( AV103GXV5 <= AV17Errors.Count )
            {
               AV95Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV17Errors.Item(AV103GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV95Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV95Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV103GXV5 = (int)(AV103GXV5+1);
            }
         }
      }

      protected void wb_table1_26_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table100x100", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTopPaddingTop2'>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV80ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSearch_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSearch_Internalname, "Procurar", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSearch_Internalname, AV40Search, StringUtil.RTrim( context.localUtil.Format( AV40Search, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Login/Name/Email", edtavSearch_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSearch_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMWWUsers.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilusergender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilusergender_Internalname, "Sexo", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilusergender, cmbavFilusergender_Internalname, StringUtil.RTrim( AV21FilUserGender), 1, cmbavFilusergender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFilusergender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_GAMWWUsers.htm");
            cmbavFilusergender.CurrentValue = StringUtil.RTrim( AV21FilUserGender);
            AssignProp("", false, cmbavFilusergender_Internalname, "Values", (string)(cmbavFilusergender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilauttype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilauttype_Internalname, "Autenticação", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilauttype, cmbavFilauttype_Internalname, StringUtil.RTrim( AV18FilAutType), 1, cmbavFilauttype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFilauttype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_GAMWWUsers.htm");
            cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV18FilAutType);
            AssignProp("", false, cmbavFilauttype_Internalname, "Values", (string)(cmbavFilauttype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilrol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilrol_Internalname, "Perfil", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilrol, cmbavFilrol_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0)), 1, cmbavFilrol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFilrol.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_GAMWWUsers.htm");
            cmbavFilrol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0));
            AssignProp("", false, cmbavFilrol_Internalname, "Values", (string)(cmbavFilrol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_26_1U2e( true) ;
         }
         else
         {
            wb_table1_26_1U2e( false) ;
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
         PA1U2( ) ;
         WS1U2( ) ;
         WE1U2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910494492", true, true);
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
         context.AddJavascriptSource("gamwwusers.js", "?202311910494496", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_572( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_57_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_57_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_57_idx;
         edtavBtnrole_Internalname = "vBTNROLE_"+sGXsfl_57_idx;
         edtavBtnpermissions_Internalname = "vBTNPERMISSIONS_"+sGXsfl_57_idx;
         edtavBtnsetpwd_Internalname = "vBTNSETPWD_"+sGXsfl_57_idx;
         edtavBtnunblockotpcodes_Internalname = "vBTNUNBLOCKOTPCODES_"+sGXsfl_57_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_57_idx;
         edtavFirstname_Internalname = "vFIRSTNAME_"+sGXsfl_57_idx;
         edtavLastname_Internalname = "vLASTNAME_"+sGXsfl_57_idx;
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME_"+sGXsfl_57_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_572( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_57_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_57_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_57_fel_idx;
         edtavBtnrole_Internalname = "vBTNROLE_"+sGXsfl_57_fel_idx;
         edtavBtnpermissions_Internalname = "vBTNPERMISSIONS_"+sGXsfl_57_fel_idx;
         edtavBtnsetpwd_Internalname = "vBTNSETPWD_"+sGXsfl_57_fel_idx;
         edtavBtnunblockotpcodes_Internalname = "vBTNUNBLOCKOTPCODES_"+sGXsfl_57_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_57_fel_idx;
         edtavFirstname_Internalname = "vFIRSTNAME_"+sGXsfl_57_fel_idx;
         edtavLastname_Internalname = "vLASTNAME_"+sGXsfl_57_fel_idx;
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME_"+sGXsfl_57_fel_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_57_fel_idx;
      }

      protected void sendrow_572( )
      {
         SubsflControlProps_572( ) ;
         WB1U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_57_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_57_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDisplay_Enabled!=0)&&(edtavDisplay_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 58,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV86Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDisplay_Enabled!=0)&&(edtavDisplay_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,58);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 59,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavUpdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV87Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,59);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)edtavUpdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavDelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV5Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,60);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)edtavDelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnrole_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnrole_Enabled!=0)&&(edtavBtnrole_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 61,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnrole_Internalname,StringUtil.RTrim( AV12BtnRole),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnrole_Enabled!=0)&&(edtavBtnrole_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,61);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnrole_Link,(string)"",(string)"Perfis",(string)"",(string)edtavBtnrole_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnrole_Visible,(int)edtavBtnrole_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnpermissions_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnpermissions_Enabled!=0)&&(edtavBtnpermissions_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 62,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnpermissions_Internalname,StringUtil.RTrim( AV14BtnPermissions),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnpermissions_Enabled!=0)&&(edtavBtnpermissions_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,62);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnpermissions_Link,(string)"",(string)"Permissões",(string)"",(string)edtavBtnpermissions_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnpermissions_Visible,(int)edtavBtnpermissions_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnsetpwd_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnsetpwd_Enabled!=0)&&(edtavBtnsetpwd_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 63,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavBtnsetpwd_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnsetpwd_Internalname,StringUtil.RTrim( AV13BtnSetPwd),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnsetpwd_Enabled!=0)&&(edtavBtnsetpwd_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,63);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnsetpwd_Link,(string)"",(string)"Atribuir nova senha",(string)"",(string)edtavBtnsetpwd_Jsonclick,(short)0,(string)edtavBtnsetpwd_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnsetpwd_Visible,(int)edtavBtnsetpwd_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnunblockotpcodes_Enabled!=0)&&(edtavBtnunblockotpcodes_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 64,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavBtnunblockotpcodes_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnunblockotpcodes_Internalname,StringUtil.RTrim( AV94BtnUnblockOTPCodes),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnunblockotpcodes_Enabled!=0)&&(edtavBtnunblockotpcodes_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,64);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVBTNUNBLOCKOTPCODES.CLICK."+sGXsfl_57_idx+"'",(string)"",(string)"","Desbloquear códigos OTP.",(string)"",(string)edtavBtnunblockotpcodes_Jsonclick,(short)5,(string)edtavBtnunblockotpcodes_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(short)-1,(int)edtavBtnunblockotpcodes_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 65,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavName_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,(string)AV34Name,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,65);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavName_Link,(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)edtavName_Class,(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavName_Visible,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)57,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavFirstname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavFirstname_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFirstname_Internalname,StringUtil.RTrim( AV22FirstName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,66);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFirstname_Jsonclick,(short)0,(string)edtavFirstname_Class,(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtavFirstname_Visible,(int)edtavFirstname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavLastname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 67,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavLastname_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLastname_Internalname,StringUtil.RTrim( AV33LastName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,67);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLastname_Jsonclick,(short)0,(string)edtavLastname_Class,(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtavLastname_Visible,(int)edtavLastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavAuthenticationtypename_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = edtavAuthenticationtypename_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAuthenticationtypename_Internalname,StringUtil.RTrim( AV9AuthenticationTypeName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,68);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAuthenticationtypename_Jsonclick,(short)0,(string)edtavAuthenticationtypename_Class,(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtavAuthenticationtypename_Visible,(int)edtavAuthenticationtypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGuid_Internalname,StringUtil.RTrim( AV28GUID),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,69);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGuid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGuid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes1U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_57_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         /* End function sendrow_572 */
      }

      protected void init_web_controls( )
      {
         cmbavFilusergender.Name = "vFILUSERGENDER";
         cmbavFilusergender.WebTags = "";
         cmbavFilusergender.addItem("", "All", 0);
         cmbavFilusergender.addItem("N", "Não especificado", 0);
         cmbavFilusergender.addItem("F", "Feminino", 0);
         cmbavFilusergender.addItem("M", "Masculino", 0);
         if ( cmbavFilusergender.ItemCount > 0 )
         {
            AV21FilUserGender = cmbavFilusergender.getValidValue(AV21FilUserGender);
            AssignAttri("", false, "AV21FilUserGender", AV21FilUserGender);
         }
         cmbavFilauttype.Name = "vFILAUTTYPE";
         cmbavFilauttype.WebTags = "";
         if ( cmbavFilauttype.ItemCount > 0 )
         {
            AV18FilAutType = cmbavFilauttype.getValidValue(AV18FilAutType);
            AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
         }
         cmbavFilrol.Name = "vFILROL";
         cmbavFilrol.WebTags = "";
         if ( cmbavFilrol.ItemCount > 0 )
         {
            AV41FilRol = (long)(NumberUtil.Val( cmbavFilrol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0))), "."));
            AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl57( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"57\">") ;
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUpdate_Class+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDelete_Class+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnrole_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavBtnrole_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnpermissions_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavBtnpermissions_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavBtnsetpwd_Class+"\" "+" style=\""+((edtavBtnsetpwd_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavBtnsetpwd_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavBtnunblockotpcodes_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavName_Class+"\" "+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavFirstname_Class+"\" "+" style=\""+((edtavFirstname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavLastname_Class+"\" "+" style=\""+((edtavLastname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Sobrenome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAuthenticationtypename_Class+"\" "+" style=\""+((edtavAuthenticationtypename_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Autenticação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
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
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV86Display));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV87Update));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUpdate_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV5Delete));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDelete_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12BtnRole));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnrole_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnrole_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnrole_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnrole_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV14BtnPermissions));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnpermissions_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnpermissions_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnpermissions_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnpermissions_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13BtnSetPwd));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnsetpwd_Title));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavBtnsetpwd_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnsetpwd_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnsetpwd_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnsetpwd_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV94BtnUnblockOTPCodes));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavBtnunblockotpcodes_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnunblockotpcodes_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", AV34Name);
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavName_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV22FirstName));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavFirstname_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV33LastName));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavLastname_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV9AuthenticationTypeName));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAuthenticationtypename_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV28GUID));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGuid_Enabled), 5, 0, ".", "")));
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
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavSearch_Internalname = "vSEARCH";
         cmbavFilusergender_Internalname = "vFILUSERGENDER";
         cmbavFilauttype_Internalname = "vFILAUTTYPE";
         cmbavFilrol_Internalname = "vFILROL";
         divTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtavBtnrole_Internalname = "vBTNROLE";
         edtavBtnpermissions_Internalname = "vBTNPERMISSIONS";
         edtavBtnsetpwd_Internalname = "vBTNSETPWD";
         edtavBtnunblockotpcodes_Internalname = "vBTNUNBLOCKOTPCODES";
         edtavName_Internalname = "vNAME";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME";
         edtavGuid_Internalname = "vGUID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         edtavGamuserscount_Internalname = "vGAMUSERSCOUNT";
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
         edtavGuid_Jsonclick = "";
         edtavGuid_Visible = 0;
         edtavGuid_Enabled = 1;
         edtavAuthenticationtypename_Jsonclick = "";
         edtavAuthenticationtypename_Class = "Attribute";
         edtavAuthenticationtypename_Enabled = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Class = "Attribute";
         edtavLastname_Enabled = 1;
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Class = "Attribute";
         edtavFirstname_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Class = "Attribute";
         edtavName_Link = "";
         edtavName_Enabled = 1;
         edtavBtnunblockotpcodes_Jsonclick = "";
         edtavBtnunblockotpcodes_Class = "Attribute";
         edtavBtnunblockotpcodes_Visible = -1;
         edtavBtnunblockotpcodes_Enabled = 1;
         edtavBtnsetpwd_Jsonclick = "";
         edtavBtnsetpwd_Class = "Attribute";
         edtavBtnsetpwd_Link = "";
         edtavBtnsetpwd_Enabled = 1;
         edtavBtnpermissions_Jsonclick = "";
         edtavBtnpermissions_Link = "";
         edtavBtnpermissions_Enabled = 1;
         edtavBtnrole_Jsonclick = "";
         edtavBtnrole_Link = "";
         edtavBtnrole_Enabled = 1;
         edtavDelete_Jsonclick = "";
         edtavDelete_Class = "Attribute";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Class = "Attribute";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbavFilrol_Jsonclick = "";
         cmbavFilrol.Enabled = 1;
         cmbavFilauttype_Jsonclick = "";
         cmbavFilauttype.Enabled = 1;
         cmbavFilusergender_Jsonclick = "";
         cmbavFilusergender.Enabled = 1;
         edtavSearch_Jsonclick = "";
         edtavSearch_Enabled = 1;
         edtavBtnsetpwd_Visible = -1;
         edtavBtnpermissions_Visible = -1;
         edtavBtnrole_Visible = -1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavDisplay_Visible = -1;
         edtavAuthenticationtypename_Visible = -1;
         edtavLastname_Visible = -1;
         edtavFirstname_Visible = -1;
         edtavName_Visible = -1;
         subGrid_Sortable = 0;
         edtavGamuserscount_Jsonclick = "";
         edtavGamuserscount_Visible = 1;
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
         Ddo_grid_Fixable = "T";
         Ddo_grid_Columnssortvalues = "|||";
         Ddo_grid_Columnids = "7:Name|8:FirstName|9:LastName|10:AuthenticationTypeName";
         Ddo_grid_Gridinternalname = "";
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
         Form.Caption = "Usuários";
         edtavBtnpermissions_Title = "";
         edtavBtnsetpwd_Title = "";
         edtavBtnrole_Title = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'edtavDisplay_Visible',ctrl:'vDISPLAY',prop:'Visible'},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E121U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E131U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E181U2',iparms:[{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV9AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV28GUID',fld:'vGUID',pic:'',hsh:true},{av:'AV34Name',fld:'vNAME',pic:''},{av:'AV22FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV33LastName',fld:'vLASTNAME',pic:''},{av:'edtavName_Class',ctrl:'vNAME',prop:'Class'},{av:'edtavFirstname_Class',ctrl:'vFIRSTNAME',prop:'Class'},{av:'edtavLastname_Class',ctrl:'vLASTNAME',prop:'Class'},{av:'edtavAuthenticationtypename_Class',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Class'},{av:'AV86Display',fld:'vDISPLAY',pic:''},{av:'edtavDisplay_Link',ctrl:'vDISPLAY',prop:'Link'},{av:'AV87Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Class',ctrl:'vUPDATE',prop:'Class'},{av:'AV5Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Class',ctrl:'vDELETE',prop:'Class'},{av:'AV12BtnRole',fld:'vBTNROLE',pic:''},{av:'edtavBtnrole_Link',ctrl:'vBTNROLE',prop:'Link'},{av:'AV14BtnPermissions',fld:'vBTNPERMISSIONS',pic:''},{av:'edtavBtnpermissions_Link',ctrl:'vBTNPERMISSIONS',prop:'Link'},{av:'AV13BtnSetPwd',fld:'vBTNSETPWD',pic:''},{av:'edtavBtnsetpwd_Link',ctrl:'vBTNSETPWD',prop:'Link'},{av:'edtavBtnsetpwd_Class',ctrl:'vBTNSETPWD',prop:'Class'},{av:'AV94BtnUnblockOTPCodes',fld:'vBTNUNBLOCKOTPCODES',pic:''},{av:'edtavBtnunblockotpcodes_Class',ctrl:'vBTNUNBLOCKOTPCODES',prop:'Class'},{av:'edtavName_Link',ctrl:'vNAME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E141U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'edtavDisplay_Visible',ctrl:'vDISPLAY',prop:'Visible'},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E111U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'edtavDisplay_Visible',ctrl:'vDISPLAY',prop:'Visible'},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E151U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilusergender'},{av:'AV21FilUserGender',fld:'vFILUSERGENDER',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'edtavDisplay_Visible',ctrl:'vDISPLAY',prop:'Visible'},{av:'AV89IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV90IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV91IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VBTNUNBLOCKOTPCODES.CLICK","{handler:'E191U2',iparms:[{av:'AV28GUID',fld:'vGUID',pic:'',hsh:true}]");
         setEventMetadata("VBTNUNBLOCKOTPCODES.CLICK",",oparms:[]}");
         setEventMetadata("VALIDV_FILUSERGENDER","{handler:'Validv_Filusergender',iparms:[]");
         setEventMetadata("VALIDV_FILUSERGENDER",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Guid',iparms:[]");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV67ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV100Pgmname = "";
         AV21FilUserGender = "";
         AV18FilAutType = "";
         AV40Search = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV80ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV85GridAppliedFilters = "";
         AV73DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV53GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV86Display = "";
         AV87Update = "";
         AV5Delete = "";
         AV12BtnRole = "";
         AV14BtnPermissions = "";
         AV13BtnSetPwd = "";
         AV94BtnUnblockOTPCodes = "";
         AV34Name = "";
         AV22FirstName = "";
         AV33LastName = "";
         AV9AuthenticationTypeName = "";
         AV28GUID = "";
         AV49HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV20FilterAutType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV17Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV45Roles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV43FilterRoles = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV36Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV42Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV50WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV72Session = context.GetSession();
         AV55ColumnsSelectorXML = "";
         AV19Filter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
         AV25GAMUsers = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         GridRow = new GXWebRow();
         AV38User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXEncryptionTmp = "";
         AV77ManageFiltersXml = "";
         AV62UserCustomValue = "";
         GXt_char3 = "";
         AV84ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV54GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV95Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwwusers__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwwusers__default(),
            new Object[][] {
            }
         );
         AV100Pgmname = "GAMWWUsers";
         /* GeneXus formulas. */
         AV100Pgmname = "GAMWWUsers";
         context.Gx_err = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavBtnrole_Enabled = 0;
         edtavBtnpermissions_Enabled = 0;
         edtavBtnsetpwd_Enabled = 0;
         edtavBtnunblockotpcodes_Enabled = 0;
         edtavName_Enabled = 0;
         edtavFirstname_Enabled = 0;
         edtavLastname_Enabled = 0;
         edtavAuthenticationtypename_Enabled = 0;
         edtavGuid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV76ManageFiltersExecutionStep ;
      private short AV83FirstIndex ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV39GAMUsersCount ;
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
      private int nRC_GXsfl_57 ;
      private int nGXsfl_57_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavGamuserscount_Visible ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int edtavBtnrole_Enabled ;
      private int edtavBtnpermissions_Enabled ;
      private int edtavBtnsetpwd_Enabled ;
      private int edtavBtnunblockotpcodes_Enabled ;
      private int edtavName_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavAuthenticationtypename_Enabled ;
      private int edtavGuid_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int subGrid_Recordcount ;
      private int AV98GXV1 ;
      private int AV99GXV2 ;
      private int edtavName_Visible ;
      private int edtavFirstname_Visible ;
      private int edtavLastname_Visible ;
      private int edtavAuthenticationtypename_Visible ;
      private int AV35PageToGo ;
      private int AV101GXV3 ;
      private int edtavDisplay_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int edtavBtnrole_Visible ;
      private int edtavBtnpermissions_Visible ;
      private int edtavBtnsetpwd_Visible ;
      private int AV102GXV4 ;
      private int AV103GXV5 ;
      private int edtavSearch_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavBtnunblockotpcodes_Visible ;
      private int edtavGuid_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41FilRol ;
      private long AV26GridCurrentPage ;
      private long AV27GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long AV6GridPageSize ;
      private long AV7GridRecordCount ;
      private long AV64i ;
      private string edtavBtnrole_Title ;
      private string edtavBtnsetpwd_Title ;
      private string edtavBtnpermissions_Title ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_57_idx="0001" ;
      private string edtavBtnrole_Internalname ;
      private string edtavBtnsetpwd_Internalname ;
      private string edtavBtnpermissions_Internalname ;
      private string AV100Pgmname ;
      private string AV21FilUserGender ;
      private string AV18FilAutType ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Fixable ;
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
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string edtavGamuserscount_Internalname ;
      private string edtavGamuserscount_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV86Display ;
      private string edtavDisplay_Internalname ;
      private string AV87Update ;
      private string edtavUpdate_Internalname ;
      private string AV5Delete ;
      private string edtavDelete_Internalname ;
      private string AV12BtnRole ;
      private string AV14BtnPermissions ;
      private string AV13BtnSetPwd ;
      private string AV94BtnUnblockOTPCodes ;
      private string edtavBtnunblockotpcodes_Internalname ;
      private string edtavName_Internalname ;
      private string AV22FirstName ;
      private string edtavFirstname_Internalname ;
      private string AV33LastName ;
      private string edtavLastname_Internalname ;
      private string AV9AuthenticationTypeName ;
      private string edtavAuthenticationtypename_Internalname ;
      private string AV28GUID ;
      private string edtavGuid_Internalname ;
      private string edtavSearch_Internalname ;
      private string cmbavFilusergender_Internalname ;
      private string cmbavFilauttype_Internalname ;
      private string cmbavFilrol_Internalname ;
      private string edtavName_Class ;
      private string edtavFirstname_Class ;
      private string edtavLastname_Class ;
      private string edtavAuthenticationtypename_Class ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavUpdate_Class ;
      private string edtavDelete_Link ;
      private string edtavDelete_Class ;
      private string edtavBtnrole_Link ;
      private string edtavBtnpermissions_Link ;
      private string edtavBtnsetpwd_Link ;
      private string edtavBtnsetpwd_Class ;
      private string edtavBtnunblockotpcodes_Class ;
      private string edtavName_Link ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavSearch_Jsonclick ;
      private string cmbavFilusergender_Jsonclick ;
      private string cmbavFilauttype_Jsonclick ;
      private string cmbavFilrol_Jsonclick ;
      private string sGXsfl_57_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtavBtnrole_Jsonclick ;
      private string edtavBtnpermissions_Jsonclick ;
      private string edtavBtnsetpwd_Jsonclick ;
      private string edtavBtnunblockotpcodes_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Jsonclick ;
      private string edtavAuthenticationtypename_Jsonclick ;
      private string edtavGuid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_57_Refreshing=false ;
      private bool AV88IsAuthorized_Display ;
      private bool AV89IsAuthorized_Update ;
      private bool AV90IsAuthorized_Delete ;
      private bool AV24GAMUserIsDeleted ;
      private bool AV30IsAuthorized_BtnRole ;
      private bool AV91IsAuthorized_BtnPermissions ;
      private bool AV31IsAuthorized_BtnSetPwd ;
      private bool AV23GAMUserIsAutoRegisteredUser ;
      private bool AV44IsAuthorized_Name ;
      private bool AV92IsAuthorized_Insert ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV55ColumnsSelectorXML ;
      private string AV77ManageFiltersXml ;
      private string AV62UserCustomValue ;
      private string AV40Search ;
      private string AV85GridAppliedFilters ;
      private string AV34Name ;
      private IGxSession AV72Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV36Repository ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFilusergender ;
      private GXCombobox cmbavFilauttype ;
      private GXCombobox cmbavFilrol ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV49HTTPRequest ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV10AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV17Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV25GAMUsers ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV45Roles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV80ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV8AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV95Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserFilter AV19Filter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV20FilterAutType ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV38User ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV42Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV43FilterRoles ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV50WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV53GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV54GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV67ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV84ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV73DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
   }

   public class gamwwusers__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwwusers__default : DataStoreHelperBase, IDataStoreHelper
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
