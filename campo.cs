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
   public class campo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TELAID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLATELAID1F58( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A133TelaId = (int)(NumberUtil.Val( GetPar( "TelaId"), "."));
            AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A133TelaId) ;
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "campo.aspx")), "campo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "campo.aspx")))) ;
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
                  AV7CampoId = (int)(NumberUtil.Val( GetPar( "CampoId"), "."));
                  AssignAttri("", false, "AV7CampoId", StringUtil.LTrimStr( (decimal)(AV7CampoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCAMPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CampoId), "ZZZZZZZ9"), context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Campo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCampoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public campo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public campo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CampoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CampoId = aP1_CampoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynTelaId = new GXCombobox();
         cmbCampoAtivo = new GXCombobox();
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
            return "campo_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( dynTelaId.ItemCount > 0 )
         {
            A133TelaId = (int)(NumberUtil.Val( dynTelaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A133TelaId), 8, 0))), "."));
            AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTelaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A133TelaId), 8, 0));
            AssignProp("", false, dynTelaId_Internalname, "Values", dynTelaId.ToJavascriptSource(), true);
         }
         if ( cmbCampoAtivo.ItemCount > 0 )
         {
            A138CampoAtivo = StringUtil.StrToBool( cmbCampoAtivo.getValidValue(StringUtil.BoolToStr( A138CampoAtivo)));
            AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCampoAtivo.CurrentValue = StringUtil.BoolToStr( A138CampoAtivo);
            AssignProp("", false, cmbCampoAtivo_Internalname, "Values", cmbCampoAtivo.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCampoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCampoNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCampoNome_Internalname, A136CampoNome, StringUtil.RTrim( context.localUtil.Format( A136CampoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCampoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCampoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Campo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynTelaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynTelaId_Internalname, "Tela", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTelaId, dynTelaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A133TelaId), 8, 0)), 1, dynTelaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTelaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Campo.htm");
         dynTelaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A133TelaId), 8, 0));
         AssignProp("", false, dynTelaId_Internalname, "Values", (string)(dynTelaId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbCampoAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCampoAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCampoAtivo_Internalname, "Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCampoAtivo, cmbCampoAtivo_Internalname, StringUtil.BoolToStr( A138CampoAtivo), 1, cmbCampoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbCampoAtivo.Visible, cmbCampoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_Campo.htm");
         cmbCampoAtivo.CurrentValue = StringUtil.BoolToStr( A138CampoAtivo);
         AssignProp("", false, cmbCampoAtivo_Internalname, "Values", (string)(cmbCampoAtivo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Campo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Campo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Campo.htm");
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
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCampoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135CampoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtCampoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCampoId_Jsonclick, 0, "Attribute", "", "", "", "", edtCampoId_Visible, edtCampoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Campo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z135CampoId = (int)(context.localUtil.CToN( cgiGet( "Z135CampoId"), ",", "."));
               Z136CampoNome = cgiGet( "Z136CampoNome");
               Z138CampoAtivo = StringUtil.StrToBool( cgiGet( "Z138CampoAtivo"));
               Z133TelaId = (int)(context.localUtil.CToN( cgiGet( "Z133TelaId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N133TelaId = (int)(context.localUtil.CToN( cgiGet( "N133TelaId"), ",", "."));
               AV7CampoId = (int)(context.localUtil.CToN( cgiGet( "vCAMPOID"), ",", "."));
               AV13Insert_TelaId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TELAID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV16Pgmname = cgiGet( "vPGMNAME");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A136CampoNome = cgiGet( edtCampoNome_Internalname);
               AssignAttri("", false, "A136CampoNome", A136CampoNome);
               dynTelaId.CurrentValue = cgiGet( dynTelaId_Internalname);
               A133TelaId = (int)(NumberUtil.Val( cgiGet( dynTelaId_Internalname), "."));
               AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
               cmbCampoAtivo.CurrentValue = cgiGet( cmbCampoAtivo_Internalname);
               A138CampoAtivo = StringUtil.StrToBool( cgiGet( cmbCampoAtivo_Internalname));
               AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
               A135CampoId = (int)(context.localUtil.CToN( cgiGet( edtCampoId_Internalname), ",", "."));
               AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Campo");
               A135CampoId = (int)(context.localUtil.CToN( cgiGet( edtCampoId_Internalname), ",", "."));
               AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
               forbiddenHiddens.Add("CampoId", context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A135CampoId != Z135CampoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("campo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A135CampoId = (int)(NumberUtil.Val( GetPar( "CampoId"), "."));
                  AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode58 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode58;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound58 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CAMPOID");
                        AnyError = 1;
                        GX_FocusControl = edtCampoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E121F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1F58( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1F58( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_1F0( )
      {
         BeforeValidate1F58( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1F58( ) ;
            }
            else
            {
               CheckExtendedTable1F58( ) ;
               CloseExtendedTableCursors1F58( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1F0( )
      {
      }

      protected void E111F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "TelaId") == 0 )
               {
                  AV13Insert_TelaId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_TelaId", StringUtil.LTrimStr( (decimal)(AV13Insert_TelaId), 8, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
         edtCampoId_Visible = 0;
         AssignProp("", false, edtCampoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCampoId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbCampoAtivo.Visible = 0;
            AssignProp("", false, cmbCampoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCampoAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbCampoAtivo.Visible = 1;
            AssignProp("", false, cmbCampoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCampoAtivo.Visible), 5, 0), true);
         }
      }

      protected void E121F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("campoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1F58( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z136CampoNome = T001F3_A136CampoNome[0];
               Z138CampoAtivo = T001F3_A138CampoAtivo[0];
               Z133TelaId = T001F3_A133TelaId[0];
            }
            else
            {
               Z136CampoNome = A136CampoNome;
               Z138CampoAtivo = A138CampoAtivo;
               Z133TelaId = A133TelaId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z135CampoId = A135CampoId;
            Z136CampoNome = A136CampoNome;
            Z138CampoAtivo = A138CampoAtivo;
            Z133TelaId = A133TelaId;
         }
      }

      protected void standaloneNotModal( )
      {
         GXATELAID_html1F58( ) ;
         edtCampoId_Enabled = 0;
         AssignProp("", false, edtCampoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCampoId_Enabled), 5, 0), true);
         AV16Pgmname = "Campo";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCampoId_Enabled = 0;
         AssignProp("", false, edtCampoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCampoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CampoId) )
         {
            A135CampoId = AV7CampoId;
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TelaId) )
         {
            dynTelaId.Enabled = 0;
            AssignProp("", false, dynTelaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTelaId.Enabled), 5, 0), true);
         }
         else
         {
            dynTelaId.Enabled = 1;
            AssignProp("", false, dynTelaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTelaId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TelaId) )
         {
            A133TelaId = AV13Insert_TelaId;
            AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (false==A138CampoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A138CampoAtivo = true;
            AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
         }
      }

      protected void Load1F58( )
      {
         /* Using cursor T001F5 */
         pr_default.execute(3, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
            A136CampoNome = T001F5_A136CampoNome[0];
            AssignAttri("", false, "A136CampoNome", A136CampoNome);
            A138CampoAtivo = T001F5_A138CampoAtivo[0];
            AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
            A133TelaId = T001F5_A133TelaId[0];
            AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
            ZM1F58( -11) ;
         }
         pr_default.close(3);
         OnLoadActions1F58( ) ;
      }

      protected void OnLoadActions1F58( )
      {
         A136CampoNome = StringUtil.Upper( A136CampoNome);
         AssignAttri("", false, "A136CampoNome", A136CampoNome);
      }

      protected void CheckExtendedTable1F58( )
      {
         nIsDirty_58 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_58 = 1;
         A136CampoNome = StringUtil.Upper( A136CampoNome);
         AssignAttri("", false, "A136CampoNome", A136CampoNome);
         /* Using cursor T001F4 */
         pr_default.execute(2, new Object[] {A133TelaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tela'.", "ForeignKeyNotFound", 1, "TELAID");
            AnyError = 1;
            GX_FocusControl = dynTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1F58( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A133TelaId )
      {
         /* Using cursor T001F6 */
         pr_default.execute(4, new Object[] {A133TelaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tela'.", "ForeignKeyNotFound", 1, "TELAID");
            AnyError = 1;
            GX_FocusControl = dynTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1F58( )
      {
         /* Using cursor T001F7 */
         pr_default.execute(5, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001F3 */
         pr_default.execute(1, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F58( 11) ;
            RcdFound58 = 1;
            A135CampoId = T001F3_A135CampoId[0];
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
            A136CampoNome = T001F3_A136CampoNome[0];
            AssignAttri("", false, "A136CampoNome", A136CampoNome);
            A138CampoAtivo = T001F3_A138CampoAtivo[0];
            AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
            A133TelaId = T001F3_A133TelaId[0];
            AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
            Z135CampoId = A135CampoId;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1F58( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1F58( ) ;
            }
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1F58( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F58( ) ;
         if ( RcdFound58 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound58 = 0;
         /* Using cursor T001F8 */
         pr_default.execute(6, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001F8_A135CampoId[0] < A135CampoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001F8_A135CampoId[0] > A135CampoId ) ) )
            {
               A135CampoId = T001F8_A135CampoId[0];
               AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
               RcdFound58 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound58 = 0;
         /* Using cursor T001F9 */
         pr_default.execute(7, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001F9_A135CampoId[0] > A135CampoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001F9_A135CampoId[0] < A135CampoId ) ) )
            {
               A135CampoId = T001F9_A135CampoId[0];
               AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
               RcdFound58 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1F58( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCampoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1F58( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( A135CampoId != Z135CampoId )
               {
                  A135CampoId = Z135CampoId;
                  AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAMPOID");
                  AnyError = 1;
                  GX_FocusControl = edtCampoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCampoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1F58( ) ;
                  GX_FocusControl = edtCampoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A135CampoId != Z135CampoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCampoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1F58( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAMPOID");
                     AnyError = 1;
                     GX_FocusControl = edtCampoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCampoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1F58( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A135CampoId != Z135CampoId )
         {
            A135CampoId = Z135CampoId;
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAMPOID");
            AnyError = 1;
            GX_FocusControl = edtCampoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCampoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1F58( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001F2 */
            pr_default.execute(0, new Object[] {A135CampoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Campo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z136CampoNome, T001F2_A136CampoNome[0]) != 0 ) || ( Z138CampoAtivo != T001F2_A138CampoAtivo[0] ) || ( Z133TelaId != T001F2_A133TelaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z136CampoNome, T001F2_A136CampoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("campo:[seudo value changed for attri]"+"CampoNome");
                  GXUtil.WriteLogRaw("Old: ",Z136CampoNome);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A136CampoNome[0]);
               }
               if ( Z138CampoAtivo != T001F2_A138CampoAtivo[0] )
               {
                  GXUtil.WriteLog("campo:[seudo value changed for attri]"+"CampoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z138CampoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A138CampoAtivo[0]);
               }
               if ( Z133TelaId != T001F2_A133TelaId[0] )
               {
                  GXUtil.WriteLog("campo:[seudo value changed for attri]"+"TelaId");
                  GXUtil.WriteLogRaw("Old: ",Z133TelaId);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A133TelaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Campo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F58( )
      {
         if ( ! IsAuthorized("campo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1F58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F58( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F58( 0) ;
            CheckOptimisticConcurrency1F58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F10 */
                     pr_default.execute(8, new Object[] {A136CampoNome, A138CampoAtivo, A133TelaId});
                     A135CampoId = T001F10_A135CampoId[0];
                     AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Campo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1F0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1F58( ) ;
            }
            EndLevel1F58( ) ;
         }
         CloseExtendedTableCursors1F58( ) ;
      }

      protected void Update1F58( )
      {
         if ( ! IsAuthorized("campo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1F58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F58( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F11 */
                     pr_default.execute(9, new Object[] {A136CampoNome, A138CampoAtivo, A133TelaId, A135CampoId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Campo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Campo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F58( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1F58( ) ;
         }
         CloseExtendedTableCursors1F58( ) ;
      }

      protected void DeferredUpdate1F58( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("campo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1F58( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F58( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F58( ) ;
            AfterConfirm1F58( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F58( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001F12 */
                  pr_default.execute(10, new Object[] {A135CampoId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Campo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1F58( ) ;
         Gx_mode = sMode58;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1F58( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001F13 */
            pr_default.execute(11, new Object[] {A135CampoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tooltip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1F58( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F58( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("campo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("campo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1F58( )
      {
         /* Scan By routine */
         /* Using cursor T001F14 */
         pr_default.execute(12);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound58 = 1;
            A135CampoId = T001F14_A135CampoId[0];
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1F58( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound58 = 1;
            A135CampoId = T001F14_A135CampoId[0];
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         }
      }

      protected void ScanEnd1F58( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1F58( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F58( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F58( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F58( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F58( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F58( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F58( )
      {
         edtCampoNome_Enabled = 0;
         AssignProp("", false, edtCampoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCampoNome_Enabled), 5, 0), true);
         dynTelaId.Enabled = 0;
         AssignProp("", false, dynTelaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTelaId.Enabled), 5, 0), true);
         cmbCampoAtivo.Enabled = 0;
         AssignProp("", false, cmbCampoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCampoAtivo.Enabled), 5, 0), true);
         edtCampoId_Enabled = 0;
         AssignProp("", false, edtCampoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCampoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1F58( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1F0( )
      {
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
         MasterPageObj.master_styles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "campo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CampoId,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("campo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Campo");
         forbiddenHiddens.Add("CampoId", context.localUtil.Format( (decimal)(A135CampoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("campo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z135CampoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135CampoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z136CampoNome", Z136CampoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z138CampoAtivo", Z138CampoAtivo);
         GxWebStd.gx_hidden_field( context, "Z133TelaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133TelaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N133TelaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133TelaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCAMPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CampoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCAMPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CampoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TELAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_TelaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
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
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXEncryptionTmp = "campo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CampoId,8,0));
         return formatLink("campo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Campo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Campo" ;
      }

      protected void InitializeNonKey1F58( )
      {
         A133TelaId = 0;
         AssignAttri("", false, "A133TelaId", StringUtil.LTrimStr( (decimal)(A133TelaId), 8, 0));
         A136CampoNome = "";
         AssignAttri("", false, "A136CampoNome", A136CampoNome);
         A138CampoAtivo = true;
         AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
         Z136CampoNome = "";
         Z138CampoAtivo = false;
         Z133TelaId = 0;
      }

      protected void InitAll1F58( )
      {
         A135CampoId = 0;
         AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         InitializeNonKey1F58( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A138CampoAtivo = i138CampoAtivo;
         AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910465372", true, true);
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
         context.AddJavascriptSource("campo.js", "?202311910465373", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCampoNome_Internalname = "CAMPONOME";
         dynTelaId_Internalname = "TELAID";
         cmbCampoAtivo_Internalname = "CAMPOATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCampoId_Internalname = "CAMPOID";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Campo";
         edtCampoId_Jsonclick = "";
         edtCampoId_Enabled = 0;
         edtCampoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCampoAtivo_Jsonclick = "";
         cmbCampoAtivo.Enabled = 1;
         cmbCampoAtivo.Visible = 1;
         dynTelaId_Jsonclick = "";
         dynTelaId.Enabled = 1;
         edtCampoNome_Jsonclick = "";
         edtCampoNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "CAMPO";
         Dvpanel_tableattributes_Cls = "PanelCard Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLATELAID1F58( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATELAID_data1F58( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXATELAID_html1F58( )
      {
         int gxdynajaxvalue;
         GXDLATELAID_data1F58( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTelaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTelaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATELAID_data1F58( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor T001F15 */
         pr_default.execute(13);
         while ( (pr_default.getStatus(13) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001F15_A133TelaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001F15_A134TelaNome[0]);
            pr_default.readNext(13);
         }
         pr_default.close(13);
      }

      protected void init_web_controls( )
      {
         dynTelaId.Name = "TELAID";
         dynTelaId.WebTags = "";
         cmbCampoAtivo.Name = "CAMPOATIVO";
         cmbCampoAtivo.WebTags = "";
         cmbCampoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbCampoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbCampoAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A138CampoAtivo) )
            {
               A138CampoAtivo = true;
               AssignAttri("", false, "A138CampoAtivo", A138CampoAtivo);
            }
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Telaid( )
      {
         A133TelaId = (int)(NumberUtil.Val( dynTelaId.CurrentValue, "."));
         /* Using cursor T001F16 */
         pr_default.execute(14, new Object[] {A133TelaId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tela'.", "ForeignKeyNotFound", 1, "TELAID");
            AnyError = 1;
            GX_FocusControl = dynTelaId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CampoId',fld:'vCAMPOID',pic:'ZZZZZZZ9',hsh:true},{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CampoId',fld:'vCAMPOID',pic:'ZZZZZZZ9',hsh:true},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'},{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E121F2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_CAMPONOME","{handler:'Valid_Camponome',iparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_CAMPONOME",",oparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_TELAID","{handler:'Valid_Telaid',iparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_TELAID",",oparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_CAMPOID","{handler:'Valid_Campoid',iparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_CAMPOID",",oparms:[{av:'dynTelaId'},{av:'A133TelaId',fld:'TELAID',pic:'ZZZZZZZ9'}]}");
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
         pr_default.close(1);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z136CampoNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A136CampoNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV16Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode58 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         T001F5_A135CampoId = new int[1] ;
         T001F5_A136CampoNome = new string[] {""} ;
         T001F5_A138CampoAtivo = new bool[] {false} ;
         T001F5_A133TelaId = new int[1] ;
         T001F4_A133TelaId = new int[1] ;
         T001F6_A133TelaId = new int[1] ;
         T001F7_A135CampoId = new int[1] ;
         T001F3_A135CampoId = new int[1] ;
         T001F3_A136CampoNome = new string[] {""} ;
         T001F3_A138CampoAtivo = new bool[] {false} ;
         T001F3_A133TelaId = new int[1] ;
         T001F8_A135CampoId = new int[1] ;
         T001F9_A135CampoId = new int[1] ;
         T001F2_A135CampoId = new int[1] ;
         T001F2_A136CampoNome = new string[] {""} ;
         T001F2_A138CampoAtivo = new bool[] {false} ;
         T001F2_A133TelaId = new int[1] ;
         T001F10_A135CampoId = new int[1] ;
         T001F13_A112TooltipId = new int[1] ;
         T001F14_A135CampoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001F15_A133TelaId = new int[1] ;
         T001F15_A134TelaNome = new string[] {""} ;
         T001F15_A137TelaAtivo = new bool[] {false} ;
         T001F16_A133TelaId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.campo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.campo__default(),
            new Object[][] {
                new Object[] {
               T001F2_A135CampoId, T001F2_A136CampoNome, T001F2_A138CampoAtivo, T001F2_A133TelaId
               }
               , new Object[] {
               T001F3_A135CampoId, T001F3_A136CampoNome, T001F3_A138CampoAtivo, T001F3_A133TelaId
               }
               , new Object[] {
               T001F4_A133TelaId
               }
               , new Object[] {
               T001F5_A135CampoId, T001F5_A136CampoNome, T001F5_A138CampoAtivo, T001F5_A133TelaId
               }
               , new Object[] {
               T001F6_A133TelaId
               }
               , new Object[] {
               T001F7_A135CampoId
               }
               , new Object[] {
               T001F8_A135CampoId
               }
               , new Object[] {
               T001F9_A135CampoId
               }
               , new Object[] {
               T001F10_A135CampoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001F13_A112TooltipId
               }
               , new Object[] {
               T001F14_A135CampoId
               }
               , new Object[] {
               T001F15_A133TelaId, T001F15_A134TelaNome, T001F15_A137TelaAtivo
               }
               , new Object[] {
               T001F16_A133TelaId
               }
            }
         );
         AV16Pgmname = "Campo";
         Z138CampoAtivo = true;
         A138CampoAtivo = true;
         i138CampoAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound58 ;
      private short GX_JID ;
      private short nIsDirty_58 ;
      private short gxajaxcallmode ;
      private int wcpOAV7CampoId ;
      private int Z135CampoId ;
      private int Z133TelaId ;
      private int N133TelaId ;
      private int A133TelaId ;
      private int AV7CampoId ;
      private int trnEnded ;
      private int edtCampoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A135CampoId ;
      private int edtCampoId_Enabled ;
      private int edtCampoId_Visible ;
      private int AV13Insert_TelaId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV17GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCampoNome_Internalname ;
      private string dynTelaId_Internalname ;
      private string cmbCampoAtivo_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtCampoNome_Jsonclick ;
      private string dynTelaId_Jsonclick ;
      private string cmbCampoAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCampoId_Internalname ;
      private string edtCampoId_Jsonclick ;
      private string AV16Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode58 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string gxwrpcisep ;
      private bool Z138CampoAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A138CampoAtivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i138CampoAtivo ;
      private bool gxdyncontrolsrefreshing ;
      private string Z136CampoNome ;
      private string A136CampoNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTelaId ;
      private GXCombobox cmbCampoAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T001F5_A135CampoId ;
      private string[] T001F5_A136CampoNome ;
      private bool[] T001F5_A138CampoAtivo ;
      private int[] T001F5_A133TelaId ;
      private int[] T001F4_A133TelaId ;
      private int[] T001F6_A133TelaId ;
      private int[] T001F7_A135CampoId ;
      private int[] T001F3_A135CampoId ;
      private string[] T001F3_A136CampoNome ;
      private bool[] T001F3_A138CampoAtivo ;
      private int[] T001F3_A133TelaId ;
      private int[] T001F8_A135CampoId ;
      private int[] T001F9_A135CampoId ;
      private int[] T001F2_A135CampoId ;
      private string[] T001F2_A136CampoNome ;
      private bool[] T001F2_A138CampoAtivo ;
      private int[] T001F2_A133TelaId ;
      private int[] T001F10_A135CampoId ;
      private int[] T001F13_A112TooltipId ;
      private int[] T001F14_A135CampoId ;
      private int[] T001F15_A133TelaId ;
      private string[] T001F15_A134TelaNome ;
      private bool[] T001F15_A137TelaAtivo ;
      private int[] T001F16_A133TelaId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class campo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class campo__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001F5;
        prmT001F5 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F4;
        prmT001F4 = new Object[] {
        new ParDef("@TelaId",GXType.Int32,8,0)
        };
        Object[] prmT001F6;
        prmT001F6 = new Object[] {
        new ParDef("@TelaId",GXType.Int32,8,0)
        };
        Object[] prmT001F7;
        prmT001F7 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F3;
        prmT001F3 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F8;
        prmT001F8 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F9;
        prmT001F9 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F2;
        prmT001F2 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F10;
        prmT001F10 = new Object[] {
        new ParDef("@CampoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CampoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@TelaId",GXType.Int32,8,0)
        };
        Object[] prmT001F11;
        prmT001F11 = new Object[] {
        new ParDef("@CampoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CampoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@TelaId",GXType.Int32,8,0) ,
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F12;
        prmT001F12 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F13;
        prmT001F13 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001F14;
        prmT001F14 = new Object[] {
        };
        Object[] prmT001F15;
        prmT001F15 = new Object[] {
        };
        Object[] prmT001F16;
        prmT001F16 = new Object[] {
        new ParDef("@TelaId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001F2", "SELECT [CampoId], [CampoNome], [CampoAtivo], [TelaId] FROM [Campo] WITH (UPDLOCK) WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F3", "SELECT [CampoId], [CampoNome], [CampoAtivo], [TelaId] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F4", "SELECT [TelaId] FROM [Tela] WHERE [TelaId] = @TelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F5", "SELECT TM1.[CampoId], TM1.[CampoNome], TM1.[CampoAtivo], TM1.[TelaId] FROM [Campo] TM1 WHERE TM1.[CampoId] = @CampoId ORDER BY TM1.[CampoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F6", "SELECT [TelaId] FROM [Tela] WHERE [TelaId] = @TelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F7", "SELECT [CampoId] FROM [Campo] WHERE [CampoId] = @CampoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F8", "SELECT TOP 1 [CampoId] FROM [Campo] WHERE ( [CampoId] > @CampoId) ORDER BY [CampoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F9", "SELECT TOP 1 [CampoId] FROM [Campo] WHERE ( [CampoId] < @CampoId) ORDER BY [CampoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F10", "INSERT INTO [Campo]([CampoNome], [CampoAtivo], [TelaId]) VALUES(@CampoNome, @CampoAtivo, @TelaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F11", "UPDATE [Campo] SET [CampoNome]=@CampoNome, [CampoAtivo]=@CampoAtivo, [TelaId]=@TelaId  WHERE [CampoId] = @CampoId", GxErrorMask.GX_NOMASK,prmT001F11)
           ,new CursorDef("T001F12", "DELETE FROM [Campo]  WHERE [CampoId] = @CampoId", GxErrorMask.GX_NOMASK,prmT001F12)
           ,new CursorDef("T001F13", "SELECT TOP 1 [TooltipId] FROM [Tooltip] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F14", "SELECT [CampoId] FROM [Campo] ORDER BY [CampoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F15", "SELECT [TelaId], [TelaNome], [TelaAtivo] FROM [Tela] WHERE [TelaAtivo] = 1 ORDER BY [TelaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F15,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F16", "SELECT [TelaId] FROM [Tela] WHERE [TelaId] = @TelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F16,1, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
