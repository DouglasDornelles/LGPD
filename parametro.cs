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
   public class parametro : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "parametro.aspx")), "parametro.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "parametro.aspx")))) ;
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
                  AV7ParametroCod = GetPar( "ParametroCod");
                  AssignAttri("", false, "AV7ParametroCod", AV7ParametroCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ParametroCod, "")), context));
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
            Form.Meta.addItem("description", "Parametro", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParametroCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parametro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public parametro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_ParametroCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ParametroCod = aP1_ParametroCod;
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
            return "parametro_Execute" ;
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
         if ( cmbParametroAtivo.ItemCount > 0 )
         {
            A132ParametroAtivo = StringUtil.StrToBool( cmbParametroAtivo.getValidValue(StringUtil.BoolToStr( A132ParametroAtivo)));
            AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametroAtivo.CurrentValue = StringUtil.BoolToStr( A132ParametroAtivo);
            AssignProp("", false, cmbParametroAtivo_Internalname, "Values", cmbParametroAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroCod_Internalname, "Cod", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroCod_Internalname, StringUtil.RTrim( A124ParametroCod), StringUtil.RTrim( context.localUtil.Format( A124ParametroCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroCod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroCod_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Parametro.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroDescricao_Internalname, "DESCRIÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroDescricao_Internalname, A125ParametroDescricao, StringUtil.RTrim( context.localUtil.Format( A125ParametroDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Parametro.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroValor_Internalname, A126ParametroValor, StringUtil.RTrim( context.localUtil.Format( A126ParametroValor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroValor_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Parametro.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametroComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroComentario_Internalname, "COMENTÁRIO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametroComentario_Internalname, A127ParametroComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", 0, 1, edtParametroComentario_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Parametro.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbParametroAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbParametroAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbParametroAtivo_Internalname, "Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbParametroAtivo, cmbParametroAtivo_Internalname, StringUtil.BoolToStr( A132ParametroAtivo), 1, cmbParametroAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbParametroAtivo.Visible, cmbParametroAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_Parametro.htm");
         cmbParametroAtivo.CurrentValue = StringUtil.BoolToStr( A132ParametroAtivo);
         AssignProp("", false, cmbParametroAtivo_Internalname, "Values", (string)(cmbParametroAtivo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametro.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametro.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametro.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtParametroDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtParametroDataInclusao_Internalname, context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"), context.localUtil.Format( A128ParametroDataInclusao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroDataInclusao_Jsonclick, 0, "Attribute", "", "", "", "", edtParametroDataInclusao_Visible, edtParametroDataInclusao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Parametro.htm");
         GxWebStd.gx_bitmap( context, edtParametroDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtParametroDataInclusao_Visible==0)||(edtParametroDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Parametro.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtParametroDataAlteracao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtParametroDataAlteracao_Internalname, context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"), context.localUtil.Format( A129ParametroDataAlteracao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroDataAlteracao_Jsonclick, 0, "Attribute", "", "", "", "", edtParametroDataAlteracao_Visible, edtParametroDataAlteracao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Parametro.htm");
         GxWebStd.gx_bitmap( context, edtParametroDataAlteracao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtParametroDataAlteracao_Visible==0)||(edtParametroDataAlteracao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Parametro.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroUsuarioInclusao_Internalname, StringUtil.RTrim( A130ParametroUsuarioInclusao), StringUtil.RTrim( context.localUtil.Format( A130ParametroUsuarioInclusao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroUsuarioInclusao_Jsonclick, 0, "Attribute", "", "", "", "", edtParametroUsuarioInclusao_Visible, edtParametroUsuarioInclusao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Parametro.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroUsuarioAlteracao_Internalname, StringUtil.RTrim( A131ParametroUsuarioAlteracao), StringUtil.RTrim( context.localUtil.Format( A131ParametroUsuarioAlteracao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroUsuarioAlteracao_Jsonclick, 0, "Attribute", "", "", "", "", edtParametroUsuarioAlteracao_Visible, edtParametroUsuarioAlteracao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Parametro.htm");
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
         E111D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z124ParametroCod = cgiGet( "Z124ParametroCod");
               Z129ParametroDataAlteracao = context.localUtil.CToD( cgiGet( "Z129ParametroDataAlteracao"), 0);
               Z131ParametroUsuarioAlteracao = cgiGet( "Z131ParametroUsuarioAlteracao");
               Z125ParametroDescricao = cgiGet( "Z125ParametroDescricao");
               Z126ParametroValor = cgiGet( "Z126ParametroValor");
               Z127ParametroComentario = cgiGet( "Z127ParametroComentario");
               Z128ParametroDataInclusao = context.localUtil.CToD( cgiGet( "Z128ParametroDataInclusao"), 0);
               Z130ParametroUsuarioInclusao = cgiGet( "Z130ParametroUsuarioInclusao");
               Z132ParametroAtivo = StringUtil.StrToBool( cgiGet( "Z132ParametroAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7ParametroCod = cgiGet( "vPARAMETROCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
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
               A124ParametroCod = cgiGet( edtParametroCod_Internalname);
               AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
               A125ParametroDescricao = cgiGet( edtParametroDescricao_Internalname);
               AssignAttri("", false, "A125ParametroDescricao", A125ParametroDescricao);
               A126ParametroValor = cgiGet( edtParametroValor_Internalname);
               AssignAttri("", false, "A126ParametroValor", A126ParametroValor);
               A127ParametroComentario = cgiGet( edtParametroComentario_Internalname);
               AssignAttri("", false, "A127ParametroComentario", A127ParametroComentario);
               cmbParametroAtivo.CurrentValue = cgiGet( cmbParametroAtivo_Internalname);
               A132ParametroAtivo = StringUtil.StrToBool( cgiGet( cmbParametroAtivo_Internalname));
               AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
               if ( context.localUtil.VCDate( cgiGet( edtParametroDataInclusao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Parametro Data Inclusao"}), 1, "PARAMETRODATAINCLUSAO");
                  AnyError = 1;
                  GX_FocusControl = edtParametroDataInclusao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A128ParametroDataInclusao = DateTime.MinValue;
                  AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
               }
               else
               {
                  A128ParametroDataInclusao = context.localUtil.CToD( cgiGet( edtParametroDataInclusao_Internalname), 2);
                  AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtParametroDataAlteracao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Parametro Data Alteracao"}), 1, "PARAMETRODATAALTERACAO");
                  AnyError = 1;
                  GX_FocusControl = edtParametroDataAlteracao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A129ParametroDataAlteracao = DateTime.MinValue;
                  AssignAttri("", false, "A129ParametroDataAlteracao", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
               }
               else
               {
                  A129ParametroDataAlteracao = context.localUtil.CToD( cgiGet( edtParametroDataAlteracao_Internalname), 2);
                  AssignAttri("", false, "A129ParametroDataAlteracao", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
               }
               A130ParametroUsuarioInclusao = cgiGet( edtParametroUsuarioInclusao_Internalname);
               AssignAttri("", false, "A130ParametroUsuarioInclusao", A130ParametroUsuarioInclusao);
               A131ParametroUsuarioAlteracao = cgiGet( edtParametroUsuarioAlteracao_Internalname);
               AssignAttri("", false, "A131ParametroUsuarioAlteracao", A131ParametroUsuarioAlteracao);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Parametro");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("parametro:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A124ParametroCod = GetPar( "ParametroCod");
                  AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
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
                     sMode56 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode56;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound56 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARAMETROCOD");
                        AnyError = 1;
                        GX_FocusControl = edtParametroCod_Internalname;
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
                           E111D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121D2 ();
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
            E121D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1D56( ) ;
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
            DisableAttributes1D56( ) ;
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

      protected void CONFIRM_1D0( )
      {
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1D56( ) ;
            }
            else
            {
               CheckExtendedTable1D56( ) ;
               CloseExtendedTableCursors1D56( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1D0( )
      {
      }

      protected void E111D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtParametroDataInclusao_Visible = 0;
         AssignProp("", false, edtParametroDataInclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroDataInclusao_Visible), 5, 0), true);
         edtParametroDataAlteracao_Visible = 0;
         AssignProp("", false, edtParametroDataAlteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroDataAlteracao_Visible), 5, 0), true);
         edtParametroUsuarioInclusao_Visible = 0;
         AssignProp("", false, edtParametroUsuarioInclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroUsuarioInclusao_Visible), 5, 0), true);
         edtParametroUsuarioAlteracao_Visible = 0;
         AssignProp("", false, edtParametroUsuarioAlteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroUsuarioAlteracao_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbParametroAtivo.Visible = 0;
            AssignProp("", false, cmbParametroAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbParametroAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbParametroAtivo.Visible = 1;
            AssignProp("", false, cmbParametroAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbParametroAtivo.Visible), 5, 0), true);
         }
      }

      protected void E121D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("parametroww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1D56( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z129ParametroDataAlteracao = T001D3_A129ParametroDataAlteracao[0];
               Z131ParametroUsuarioAlteracao = T001D3_A131ParametroUsuarioAlteracao[0];
               Z125ParametroDescricao = T001D3_A125ParametroDescricao[0];
               Z126ParametroValor = T001D3_A126ParametroValor[0];
               Z127ParametroComentario = T001D3_A127ParametroComentario[0];
               Z128ParametroDataInclusao = T001D3_A128ParametroDataInclusao[0];
               Z130ParametroUsuarioInclusao = T001D3_A130ParametroUsuarioInclusao[0];
               Z132ParametroAtivo = T001D3_A132ParametroAtivo[0];
            }
            else
            {
               Z129ParametroDataAlteracao = A129ParametroDataAlteracao;
               Z131ParametroUsuarioAlteracao = A131ParametroUsuarioAlteracao;
               Z125ParametroDescricao = A125ParametroDescricao;
               Z126ParametroValor = A126ParametroValor;
               Z127ParametroComentario = A127ParametroComentario;
               Z128ParametroDataInclusao = A128ParametroDataInclusao;
               Z130ParametroUsuarioInclusao = A130ParametroUsuarioInclusao;
               Z132ParametroAtivo = A132ParametroAtivo;
            }
         }
         if ( GX_JID == -14 )
         {
            Z124ParametroCod = A124ParametroCod;
            Z129ParametroDataAlteracao = A129ParametroDataAlteracao;
            Z131ParametroUsuarioAlteracao = A131ParametroUsuarioAlteracao;
            Z125ParametroDescricao = A125ParametroDescricao;
            Z126ParametroValor = A126ParametroValor;
            Z127ParametroComentario = A127ParametroComentario;
            Z128ParametroDataInclusao = A128ParametroDataInclusao;
            Z130ParametroUsuarioInclusao = A130ParametroUsuarioInclusao;
            Z132ParametroAtivo = A132ParametroAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ParametroCod)) )
         {
            A124ParametroCod = AV7ParametroCod;
            AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ParametroCod)) )
         {
            edtParametroCod_Enabled = 0;
            AssignProp("", false, edtParametroCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroCod_Enabled), 5, 0), true);
         }
         else
         {
            edtParametroCod_Enabled = 1;
            AssignProp("", false, edtParametroCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ParametroCod)) )
         {
            edtParametroCod_Enabled = 0;
            AssignProp("", false, edtParametroCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( IsIns( )  && (false==A132ParametroAtivo) && ( Gx_BScreen == 0 ) )
         {
            A132ParametroAtivo = true;
            AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
         }
         if ( IsIns( )  && (DateTime.MinValue==A128ParametroDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A128ParametroDataInclusao = DateTimeUtil.Today( context);
            AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A130ParametroUsuarioInclusao)) && ( Gx_BScreen == 0 ) )
         {
            A130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            AssignAttri("", false, "A130ParametroUsuarioInclusao", A130ParametroUsuarioInclusao);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1D56( )
      {
         /* Using cursor T001D4 */
         pr_default.execute(2, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound56 = 1;
            A129ParametroDataAlteracao = T001D4_A129ParametroDataAlteracao[0];
            AssignAttri("", false, "A129ParametroDataAlteracao", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
            A131ParametroUsuarioAlteracao = T001D4_A131ParametroUsuarioAlteracao[0];
            AssignAttri("", false, "A131ParametroUsuarioAlteracao", A131ParametroUsuarioAlteracao);
            A125ParametroDescricao = T001D4_A125ParametroDescricao[0];
            AssignAttri("", false, "A125ParametroDescricao", A125ParametroDescricao);
            A126ParametroValor = T001D4_A126ParametroValor[0];
            AssignAttri("", false, "A126ParametroValor", A126ParametroValor);
            A127ParametroComentario = T001D4_A127ParametroComentario[0];
            AssignAttri("", false, "A127ParametroComentario", A127ParametroComentario);
            A128ParametroDataInclusao = T001D4_A128ParametroDataInclusao[0];
            AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
            A130ParametroUsuarioInclusao = T001D4_A130ParametroUsuarioInclusao[0];
            AssignAttri("", false, "A130ParametroUsuarioInclusao", A130ParametroUsuarioInclusao);
            A132ParametroAtivo = T001D4_A132ParametroAtivo[0];
            AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
            ZM1D56( -14) ;
         }
         pr_default.close(2);
         OnLoadActions1D56( ) ;
      }

      protected void OnLoadActions1D56( )
      {
      }

      protected void CheckExtendedTable1D56( )
      {
         nIsDirty_56 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A124ParametroCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parametro Cod", "", "", "", "", "", "", "", ""), 1, "PARAMETROCOD");
            AnyError = 1;
            GX_FocusControl = edtParametroCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A125ParametroDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parametro Descricao", "", "", "", "", "", "", "", ""), 1, "PARAMETRODESCRICAO");
            AnyError = 1;
            GX_FocusControl = edtParametroDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A126ParametroValor)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parametro Valor", "", "", "", "", "", "", "", ""), 1, "PARAMETROVALOR");
            AnyError = 1;
            GX_FocusControl = edtParametroValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A128ParametroDataInclusao) || ( DateTimeUtil.ResetTime ( A128ParametroDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Parametro Data Inclusao fora do intervalo", "OutOfRange", 1, "PARAMETRODATAINCLUSAO");
            AnyError = 1;
            GX_FocusControl = edtParametroDataInclusao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A129ParametroDataAlteracao) || ( DateTimeUtil.ResetTime ( A129ParametroDataAlteracao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Parametro Data Alteracao fora do intervalo", "OutOfRange", 1, "PARAMETRODATAALTERACAO");
            AnyError = 1;
            GX_FocusControl = edtParametroDataAlteracao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1D56( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D56( )
      {
         /* Using cursor T001D5 */
         pr_default.execute(3, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001D3 */
         pr_default.execute(1, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1D56( 14) ;
            RcdFound56 = 1;
            A124ParametroCod = T001D3_A124ParametroCod[0];
            AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
            A129ParametroDataAlteracao = T001D3_A129ParametroDataAlteracao[0];
            AssignAttri("", false, "A129ParametroDataAlteracao", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
            A131ParametroUsuarioAlteracao = T001D3_A131ParametroUsuarioAlteracao[0];
            AssignAttri("", false, "A131ParametroUsuarioAlteracao", A131ParametroUsuarioAlteracao);
            A125ParametroDescricao = T001D3_A125ParametroDescricao[0];
            AssignAttri("", false, "A125ParametroDescricao", A125ParametroDescricao);
            A126ParametroValor = T001D3_A126ParametroValor[0];
            AssignAttri("", false, "A126ParametroValor", A126ParametroValor);
            A127ParametroComentario = T001D3_A127ParametroComentario[0];
            AssignAttri("", false, "A127ParametroComentario", A127ParametroComentario);
            A128ParametroDataInclusao = T001D3_A128ParametroDataInclusao[0];
            AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
            A130ParametroUsuarioInclusao = T001D3_A130ParametroUsuarioInclusao[0];
            AssignAttri("", false, "A130ParametroUsuarioInclusao", A130ParametroUsuarioInclusao);
            A132ParametroAtivo = T001D3_A132ParametroAtivo[0];
            AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
            Z124ParametroCod = A124ParametroCod;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1D56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1D56( ) ;
            }
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1D56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D56( ) ;
         if ( RcdFound56 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound56 = 0;
         /* Using cursor T001D6 */
         pr_default.execute(4, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T001D6_A124ParametroCod[0], A124ParametroCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T001D6_A124ParametroCod[0], A124ParametroCod) > 0 ) ) )
            {
               A124ParametroCod = T001D6_A124ParametroCod[0];
               AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
               RcdFound56 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound56 = 0;
         /* Using cursor T001D7 */
         pr_default.execute(5, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001D7_A124ParametroCod[0], A124ParametroCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001D7_A124ParametroCod[0], A124ParametroCod) < 0 ) ) )
            {
               A124ParametroCod = T001D7_A124ParametroCod[0];
               AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
               RcdFound56 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1D56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParametroCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1D56( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
               {
                  A124ParametroCod = Z124ParametroCod;
                  AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARAMETROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtParametroCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParametroCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1D56( ) ;
                  GX_FocusControl = edtParametroCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtParametroCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1D56( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARAMETROCOD");
                     AnyError = 1;
                     GX_FocusControl = edtParametroCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtParametroCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1D56( ) ;
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
         if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
         {
            A124ParametroCod = Z124ParametroCod;
            AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARAMETROCOD");
            AnyError = 1;
            GX_FocusControl = edtParametroCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParametroCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1D56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001D2 */
            pr_default.execute(0, new Object[] {A124ParametroCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametro"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z129ParametroDataAlteracao ) != DateTimeUtil.ResetTime ( T001D2_A129ParametroDataAlteracao[0] ) ) || ( StringUtil.StrCmp(Z131ParametroUsuarioAlteracao, T001D2_A131ParametroUsuarioAlteracao[0]) != 0 ) || ( StringUtil.StrCmp(Z125ParametroDescricao, T001D2_A125ParametroDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z126ParametroValor, T001D2_A126ParametroValor[0]) != 0 ) || ( StringUtil.StrCmp(Z127ParametroComentario, T001D2_A127ParametroComentario[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z128ParametroDataInclusao ) != DateTimeUtil.ResetTime ( T001D2_A128ParametroDataInclusao[0] ) ) || ( StringUtil.StrCmp(Z130ParametroUsuarioInclusao, T001D2_A130ParametroUsuarioInclusao[0]) != 0 ) || ( Z132ParametroAtivo != T001D2_A132ParametroAtivo[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z129ParametroDataAlteracao ) != DateTimeUtil.ResetTime ( T001D2_A129ParametroDataAlteracao[0] ) )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroDataAlteracao");
                  GXUtil.WriteLogRaw("Old: ",Z129ParametroDataAlteracao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A129ParametroDataAlteracao[0]);
               }
               if ( StringUtil.StrCmp(Z131ParametroUsuarioAlteracao, T001D2_A131ParametroUsuarioAlteracao[0]) != 0 )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroUsuarioAlteracao");
                  GXUtil.WriteLogRaw("Old: ",Z131ParametroUsuarioAlteracao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A131ParametroUsuarioAlteracao[0]);
               }
               if ( StringUtil.StrCmp(Z125ParametroDescricao, T001D2_A125ParametroDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z125ParametroDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A125ParametroDescricao[0]);
               }
               if ( StringUtil.StrCmp(Z126ParametroValor, T001D2_A126ParametroValor[0]) != 0 )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroValor");
                  GXUtil.WriteLogRaw("Old: ",Z126ParametroValor);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A126ParametroValor[0]);
               }
               if ( StringUtil.StrCmp(Z127ParametroComentario, T001D2_A127ParametroComentario[0]) != 0 )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroComentario");
                  GXUtil.WriteLogRaw("Old: ",Z127ParametroComentario);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A127ParametroComentario[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z128ParametroDataInclusao ) != DateTimeUtil.ResetTime ( T001D2_A128ParametroDataInclusao[0] ) )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroDataInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z128ParametroDataInclusao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A128ParametroDataInclusao[0]);
               }
               if ( StringUtil.StrCmp(Z130ParametroUsuarioInclusao, T001D2_A130ParametroUsuarioInclusao[0]) != 0 )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroUsuarioInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z130ParametroUsuarioInclusao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A130ParametroUsuarioInclusao[0]);
               }
               if ( Z132ParametroAtivo != T001D2_A132ParametroAtivo[0] )
               {
                  GXUtil.WriteLog("parametro:[seudo value changed for attri]"+"ParametroAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z132ParametroAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A132ParametroAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Parametro"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D56( )
      {
         if ( ! IsAuthorized("parametro_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D56( 0) ;
            CheckOptimisticConcurrency1D56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D8 */
                     pr_default.execute(6, new Object[] {A124ParametroCod, A129ParametroDataAlteracao, A131ParametroUsuarioAlteracao, A125ParametroDescricao, A126ParametroValor, A127ParametroComentario, A128ParametroDataInclusao, A130ParametroUsuarioInclusao, A132ParametroAtivo});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Parametro");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1D0( ) ;
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
               Load1D56( ) ;
            }
            EndLevel1D56( ) ;
         }
         CloseExtendedTableCursors1D56( ) ;
      }

      protected void Update1D56( )
      {
         if ( ! IsAuthorized("parametro_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D9 */
                     pr_default.execute(7, new Object[] {A129ParametroDataAlteracao, A131ParametroUsuarioAlteracao, A125ParametroDescricao, A126ParametroValor, A127ParametroComentario, A128ParametroDataInclusao, A130ParametroUsuarioInclusao, A132ParametroAtivo, A124ParametroCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Parametro");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametro"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D56( ) ;
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
            EndLevel1D56( ) ;
         }
         CloseExtendedTableCursors1D56( ) ;
      }

      protected void DeferredUpdate1D56( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("parametro_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D56( ) ;
            AfterConfirm1D56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001D10 */
                  pr_default.execute(8, new Object[] {A124ParametroCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Parametro");
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1D56( ) ;
         Gx_mode = sMode56;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1D56( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1D56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("parametro",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("parametro",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1D56( )
      {
         /* Scan By routine */
         /* Using cursor T001D11 */
         pr_default.execute(9);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound56 = 1;
            A124ParametroCod = T001D11_A124ParametroCod[0];
            AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1D56( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound56 = 1;
            A124ParametroCod = T001D11_A124ParametroCod[0];
            AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
         }
      }

      protected void ScanEnd1D56( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1D56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D56( )
      {
         /* Before Update Rules */
         A129ParametroDataAlteracao = DateTimeUtil.Today( context);
         AssignAttri("", false, "A129ParametroDataAlteracao", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
         A131ParametroUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AssignAttri("", false, "A131ParametroUsuarioAlteracao", A131ParametroUsuarioAlteracao);
      }

      protected void BeforeDelete1D56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D56( )
      {
         edtParametroCod_Enabled = 0;
         AssignProp("", false, edtParametroCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroCod_Enabled), 5, 0), true);
         edtParametroDescricao_Enabled = 0;
         AssignProp("", false, edtParametroDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroDescricao_Enabled), 5, 0), true);
         edtParametroValor_Enabled = 0;
         AssignProp("", false, edtParametroValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroValor_Enabled), 5, 0), true);
         edtParametroComentario_Enabled = 0;
         AssignProp("", false, edtParametroComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroComentario_Enabled), 5, 0), true);
         cmbParametroAtivo.Enabled = 0;
         AssignProp("", false, cmbParametroAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametroAtivo.Enabled), 5, 0), true);
         edtParametroDataInclusao_Enabled = 0;
         AssignProp("", false, edtParametroDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroDataInclusao_Enabled), 5, 0), true);
         edtParametroDataAlteracao_Enabled = 0;
         AssignProp("", false, edtParametroDataAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroDataAlteracao_Enabled), 5, 0), true);
         edtParametroUsuarioInclusao_Enabled = 0;
         AssignProp("", false, edtParametroUsuarioInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroUsuarioInclusao_Enabled), 5, 0), true);
         edtParametroUsuarioAlteracao_Enabled = 0;
         AssignProp("", false, edtParametroUsuarioAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroUsuarioAlteracao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1D56( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1D0( )
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametro.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ParametroCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametro.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Parametro");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("parametro:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z124ParametroCod", StringUtil.RTrim( Z124ParametroCod));
         GxWebStd.gx_hidden_field( context, "Z129ParametroDataAlteracao", context.localUtil.DToC( Z129ParametroDataAlteracao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z131ParametroUsuarioAlteracao", StringUtil.RTrim( Z131ParametroUsuarioAlteracao));
         GxWebStd.gx_hidden_field( context, "Z125ParametroDescricao", Z125ParametroDescricao);
         GxWebStd.gx_hidden_field( context, "Z126ParametroValor", Z126ParametroValor);
         GxWebStd.gx_hidden_field( context, "Z127ParametroComentario", Z127ParametroComentario);
         GxWebStd.gx_hidden_field( context, "Z128ParametroDataInclusao", context.localUtil.DToC( Z128ParametroDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z130ParametroUsuarioInclusao", StringUtil.RTrim( Z130ParametroUsuarioInclusao));
         GxWebStd.gx_boolean_hidden_field( context, "Z132ParametroAtivo", Z132ParametroAtivo);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vPARAMETROCOD", StringUtil.RTrim( AV7ParametroCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ParametroCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         GXEncryptionTmp = "parametro.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ParametroCod));
         return formatLink("parametro.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Parametro" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parametro" ;
      }

      protected void InitializeNonKey1D56( )
      {
         A129ParametroDataAlteracao = DateTime.MinValue;
         AssignAttri("", false, "A129ParametroDataAlteracao", context.localUtil.Format(A129ParametroDataAlteracao, "99/99/99"));
         A131ParametroUsuarioAlteracao = "";
         AssignAttri("", false, "A131ParametroUsuarioAlteracao", A131ParametroUsuarioAlteracao);
         A125ParametroDescricao = "";
         AssignAttri("", false, "A125ParametroDescricao", A125ParametroDescricao);
         A126ParametroValor = "";
         AssignAttri("", false, "A126ParametroValor", A126ParametroValor);
         A127ParametroComentario = "";
         AssignAttri("", false, "A127ParametroComentario", A127ParametroComentario);
         A128ParametroDataInclusao = DateTimeUtil.Today( context);
         AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
         A130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AssignAttri("", false, "A130ParametroUsuarioInclusao", A130ParametroUsuarioInclusao);
         A132ParametroAtivo = true;
         AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
         Z129ParametroDataAlteracao = DateTime.MinValue;
         Z131ParametroUsuarioAlteracao = "";
         Z125ParametroDescricao = "";
         Z126ParametroValor = "";
         Z127ParametroComentario = "";
         Z128ParametroDataInclusao = DateTime.MinValue;
         Z130ParametroUsuarioInclusao = "";
         Z132ParametroAtivo = false;
      }

      protected void InitAll1D56( )
      {
         A124ParametroCod = "";
         AssignAttri("", false, "A124ParametroCod", A124ParametroCod);
         InitializeNonKey1D56( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A132ParametroAtivo = i132ParametroAtivo;
         AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
         A128ParametroDataInclusao = i128ParametroDataInclusao;
         AssignAttri("", false, "A128ParametroDataInclusao", context.localUtil.Format(A128ParametroDataInclusao, "99/99/99"));
         A130ParametroUsuarioInclusao = i130ParametroUsuarioInclusao;
         AssignAttri("", false, "A130ParametroUsuarioInclusao", A130ParametroUsuarioInclusao);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910464713", true, true);
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
         context.AddJavascriptSource("parametro.js", "?202311910464714", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtParametroCod_Internalname = "PARAMETROCOD";
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO";
         edtParametroValor_Internalname = "PARAMETROVALOR";
         edtParametroComentario_Internalname = "PARAMETROCOMENTARIO";
         cmbParametroAtivo_Internalname = "PARAMETROATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtParametroDataInclusao_Internalname = "PARAMETRODATAINCLUSAO";
         edtParametroDataAlteracao_Internalname = "PARAMETRODATAALTERACAO";
         edtParametroUsuarioInclusao_Internalname = "PARAMETROUSUARIOINCLUSAO";
         edtParametroUsuarioAlteracao_Internalname = "PARAMETROUSUARIOALTERACAO";
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
         Form.Caption = "Parametro";
         edtParametroUsuarioAlteracao_Jsonclick = "";
         edtParametroUsuarioAlteracao_Enabled = 1;
         edtParametroUsuarioAlteracao_Visible = 1;
         edtParametroUsuarioInclusao_Jsonclick = "";
         edtParametroUsuarioInclusao_Enabled = 1;
         edtParametroUsuarioInclusao_Visible = 1;
         edtParametroDataAlteracao_Jsonclick = "";
         edtParametroDataAlteracao_Enabled = 1;
         edtParametroDataAlteracao_Visible = 1;
         edtParametroDataInclusao_Jsonclick = "";
         edtParametroDataInclusao_Enabled = 1;
         edtParametroDataInclusao_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbParametroAtivo_Jsonclick = "";
         cmbParametroAtivo.Enabled = 1;
         cmbParametroAtivo.Visible = 1;
         edtParametroComentario_Enabled = 1;
         edtParametroValor_Jsonclick = "";
         edtParametroValor_Enabled = 1;
         edtParametroDescricao_Jsonclick = "";
         edtParametroDescricao_Enabled = 1;
         edtParametroCod_Jsonclick = "";
         edtParametroCod_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "PARÂMETRO";
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

      protected void init_web_controls( )
      {
         cmbParametroAtivo.Name = "PARAMETROATIVO";
         cmbParametroAtivo.WebTags = "";
         cmbParametroAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbParametroAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbParametroAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A132ParametroAtivo) )
            {
               A132ParametroAtivo = true;
               AssignAttri("", false, "A132ParametroAtivo", A132ParametroAtivo);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ParametroCod',fld:'vPARAMETROCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ParametroCod',fld:'vPARAMETROCOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121D2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROCOD","{handler:'Valid_Parametrocod',iparms:[]");
         setEventMetadata("VALID_PARAMETROCOD",",oparms:[]}");
         setEventMetadata("VALID_PARAMETRODESCRICAO","{handler:'Valid_Parametrodescricao',iparms:[]");
         setEventMetadata("VALID_PARAMETRODESCRICAO",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROVALOR","{handler:'Valid_Parametrovalor',iparms:[]");
         setEventMetadata("VALID_PARAMETROVALOR",",oparms:[]}");
         setEventMetadata("VALID_PARAMETRODATAINCLUSAO","{handler:'Valid_Parametrodatainclusao',iparms:[]");
         setEventMetadata("VALID_PARAMETRODATAINCLUSAO",",oparms:[]}");
         setEventMetadata("VALID_PARAMETRODATAALTERACAO","{handler:'Valid_Parametrodataalteracao',iparms:[]");
         setEventMetadata("VALID_PARAMETRODATAALTERACAO",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7ParametroCod = "";
         Z124ParametroCod = "";
         Z129ParametroDataAlteracao = DateTime.MinValue;
         Z131ParametroUsuarioAlteracao = "";
         Z125ParametroDescricao = "";
         Z126ParametroValor = "";
         Z127ParametroComentario = "";
         Z128ParametroDataInclusao = DateTime.MinValue;
         Z130ParametroUsuarioInclusao = "";
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
         A124ParametroCod = "";
         A125ParametroDescricao = "";
         A126ParametroValor = "";
         A127ParametroComentario = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A128ParametroDataInclusao = DateTime.MinValue;
         A129ParametroDataAlteracao = DateTime.MinValue;
         A130ParametroUsuarioInclusao = "";
         A131ParametroUsuarioAlteracao = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode56 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T001D4_A124ParametroCod = new string[] {""} ;
         T001D4_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001D4_A131ParametroUsuarioAlteracao = new string[] {""} ;
         T001D4_A125ParametroDescricao = new string[] {""} ;
         T001D4_A126ParametroValor = new string[] {""} ;
         T001D4_A127ParametroComentario = new string[] {""} ;
         T001D4_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T001D4_A130ParametroUsuarioInclusao = new string[] {""} ;
         T001D4_A132ParametroAtivo = new bool[] {false} ;
         T001D5_A124ParametroCod = new string[] {""} ;
         T001D3_A124ParametroCod = new string[] {""} ;
         T001D3_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001D3_A131ParametroUsuarioAlteracao = new string[] {""} ;
         T001D3_A125ParametroDescricao = new string[] {""} ;
         T001D3_A126ParametroValor = new string[] {""} ;
         T001D3_A127ParametroComentario = new string[] {""} ;
         T001D3_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T001D3_A130ParametroUsuarioInclusao = new string[] {""} ;
         T001D3_A132ParametroAtivo = new bool[] {false} ;
         T001D6_A124ParametroCod = new string[] {""} ;
         T001D7_A124ParametroCod = new string[] {""} ;
         T001D2_A124ParametroCod = new string[] {""} ;
         T001D2_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001D2_A131ParametroUsuarioAlteracao = new string[] {""} ;
         T001D2_A125ParametroDescricao = new string[] {""} ;
         T001D2_A126ParametroValor = new string[] {""} ;
         T001D2_A127ParametroComentario = new string[] {""} ;
         T001D2_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T001D2_A130ParametroUsuarioInclusao = new string[] {""} ;
         T001D2_A132ParametroAtivo = new bool[] {false} ;
         T001D11_A124ParametroCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i128ParametroDataInclusao = DateTime.MinValue;
         i130ParametroUsuarioInclusao = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.parametro__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametro__default(),
            new Object[][] {
                new Object[] {
               T001D2_A124ParametroCod, T001D2_A129ParametroDataAlteracao, T001D2_A131ParametroUsuarioAlteracao, T001D2_A125ParametroDescricao, T001D2_A126ParametroValor, T001D2_A127ParametroComentario, T001D2_A128ParametroDataInclusao, T001D2_A130ParametroUsuarioInclusao, T001D2_A132ParametroAtivo
               }
               , new Object[] {
               T001D3_A124ParametroCod, T001D3_A129ParametroDataAlteracao, T001D3_A131ParametroUsuarioAlteracao, T001D3_A125ParametroDescricao, T001D3_A126ParametroValor, T001D3_A127ParametroComentario, T001D3_A128ParametroDataInclusao, T001D3_A130ParametroUsuarioInclusao, T001D3_A132ParametroAtivo
               }
               , new Object[] {
               T001D4_A124ParametroCod, T001D4_A129ParametroDataAlteracao, T001D4_A131ParametroUsuarioAlteracao, T001D4_A125ParametroDescricao, T001D4_A126ParametroValor, T001D4_A127ParametroComentario, T001D4_A128ParametroDataInclusao, T001D4_A130ParametroUsuarioInclusao, T001D4_A132ParametroAtivo
               }
               , new Object[] {
               T001D5_A124ParametroCod
               }
               , new Object[] {
               T001D6_A124ParametroCod
               }
               , new Object[] {
               T001D7_A124ParametroCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001D11_A124ParametroCod
               }
            }
         );
         Z130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         i130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         Z128ParametroDataInclusao = DateTimeUtil.Today( context);
         A128ParametroDataInclusao = DateTimeUtil.Today( context);
         i128ParametroDataInclusao = DateTimeUtil.Today( context);
         Z132ParametroAtivo = true;
         A132ParametroAtivo = true;
         i132ParametroAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound56 ;
      private short GX_JID ;
      private short nIsDirty_56 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtParametroCod_Enabled ;
      private int edtParametroDescricao_Enabled ;
      private int edtParametroValor_Enabled ;
      private int edtParametroComentario_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtParametroDataInclusao_Visible ;
      private int edtParametroDataInclusao_Enabled ;
      private int edtParametroDataAlteracao_Visible ;
      private int edtParametroDataAlteracao_Enabled ;
      private int edtParametroUsuarioInclusao_Visible ;
      private int edtParametroUsuarioInclusao_Enabled ;
      private int edtParametroUsuarioAlteracao_Visible ;
      private int edtParametroUsuarioAlteracao_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7ParametroCod ;
      private string Z124ParametroCod ;
      private string Z131ParametroUsuarioAlteracao ;
      private string Z130ParametroUsuarioInclusao ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7ParametroCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtParametroCod_Internalname ;
      private string cmbParametroAtivo_Internalname ;
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
      private string A124ParametroCod ;
      private string edtParametroCod_Jsonclick ;
      private string edtParametroDescricao_Internalname ;
      private string edtParametroDescricao_Jsonclick ;
      private string edtParametroValor_Internalname ;
      private string edtParametroValor_Jsonclick ;
      private string edtParametroComentario_Internalname ;
      private string cmbParametroAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtParametroDataInclusao_Internalname ;
      private string edtParametroDataInclusao_Jsonclick ;
      private string edtParametroDataAlteracao_Internalname ;
      private string edtParametroDataAlteracao_Jsonclick ;
      private string edtParametroUsuarioInclusao_Internalname ;
      private string A130ParametroUsuarioInclusao ;
      private string edtParametroUsuarioInclusao_Jsonclick ;
      private string edtParametroUsuarioAlteracao_Internalname ;
      private string A131ParametroUsuarioAlteracao ;
      private string edtParametroUsuarioAlteracao_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode56 ;
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
      private string i130ParametroUsuarioInclusao ;
      private DateTime Z129ParametroDataAlteracao ;
      private DateTime Z128ParametroDataInclusao ;
      private DateTime A128ParametroDataInclusao ;
      private DateTime A129ParametroDataAlteracao ;
      private DateTime i128ParametroDataInclusao ;
      private bool Z132ParametroAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A132ParametroAtivo ;
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
      private bool Gx_longc ;
      private bool i132ParametroAtivo ;
      private string Z125ParametroDescricao ;
      private string Z126ParametroValor ;
      private string Z127ParametroComentario ;
      private string A125ParametroDescricao ;
      private string A126ParametroValor ;
      private string A127ParametroComentario ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbParametroAtivo ;
      private IDataStoreProvider pr_default ;
      private string[] T001D4_A124ParametroCod ;
      private DateTime[] T001D4_A129ParametroDataAlteracao ;
      private string[] T001D4_A131ParametroUsuarioAlteracao ;
      private string[] T001D4_A125ParametroDescricao ;
      private string[] T001D4_A126ParametroValor ;
      private string[] T001D4_A127ParametroComentario ;
      private DateTime[] T001D4_A128ParametroDataInclusao ;
      private string[] T001D4_A130ParametroUsuarioInclusao ;
      private bool[] T001D4_A132ParametroAtivo ;
      private string[] T001D5_A124ParametroCod ;
      private string[] T001D3_A124ParametroCod ;
      private DateTime[] T001D3_A129ParametroDataAlteracao ;
      private string[] T001D3_A131ParametroUsuarioAlteracao ;
      private string[] T001D3_A125ParametroDescricao ;
      private string[] T001D3_A126ParametroValor ;
      private string[] T001D3_A127ParametroComentario ;
      private DateTime[] T001D3_A128ParametroDataInclusao ;
      private string[] T001D3_A130ParametroUsuarioInclusao ;
      private bool[] T001D3_A132ParametroAtivo ;
      private string[] T001D6_A124ParametroCod ;
      private string[] T001D7_A124ParametroCod ;
      private string[] T001D2_A124ParametroCod ;
      private DateTime[] T001D2_A129ParametroDataAlteracao ;
      private string[] T001D2_A131ParametroUsuarioAlteracao ;
      private string[] T001D2_A125ParametroDescricao ;
      private string[] T001D2_A126ParametroValor ;
      private string[] T001D2_A127ParametroComentario ;
      private DateTime[] T001D2_A128ParametroDataInclusao ;
      private string[] T001D2_A130ParametroUsuarioInclusao ;
      private bool[] T001D2_A132ParametroAtivo ;
      private string[] T001D11_A124ParametroCod ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class parametro__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class parametro__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001D4;
        prmT001D4 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D5;
        prmT001D5 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D3;
        prmT001D3 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D6;
        prmT001D6 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D7;
        prmT001D7 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D2;
        prmT001D2 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D8;
        prmT001D8 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0) ,
        new ParDef("@ParametroDataAlteracao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioAlteracao",GXType.NChar,20,0) ,
        new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroValor",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroComentario",GXType.NVarChar,500,0) ,
        new ParDef("@ParametroDataInclusao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioInclusao",GXType.NChar,20,0) ,
        new ParDef("@ParametroAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT001D9;
        prmT001D9 = new Object[] {
        new ParDef("@ParametroDataAlteracao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioAlteracao",GXType.NChar,20,0) ,
        new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroValor",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroComentario",GXType.NVarChar,500,0) ,
        new ParDef("@ParametroDataInclusao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioInclusao",GXType.NChar,20,0) ,
        new ParDef("@ParametroAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D10;
        prmT001D10 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmT001D11;
        prmT001D11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001D2", "SELECT [ParametroCod], [ParametroDataAlteracao], [ParametroUsuarioAlteracao], [ParametroDescricao], [ParametroValor], [ParametroComentario], [ParametroDataInclusao], [ParametroUsuarioInclusao], [ParametroAtivo] FROM [Parametro] WITH (UPDLOCK) WHERE [ParametroCod] = @ParametroCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D3", "SELECT [ParametroCod], [ParametroDataAlteracao], [ParametroUsuarioAlteracao], [ParametroDescricao], [ParametroValor], [ParametroComentario], [ParametroDataInclusao], [ParametroUsuarioInclusao], [ParametroAtivo] FROM [Parametro] WHERE [ParametroCod] = @ParametroCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D4", "SELECT TM1.[ParametroCod], TM1.[ParametroDataAlteracao], TM1.[ParametroUsuarioAlteracao], TM1.[ParametroDescricao], TM1.[ParametroValor], TM1.[ParametroComentario], TM1.[ParametroDataInclusao], TM1.[ParametroUsuarioInclusao], TM1.[ParametroAtivo] FROM [Parametro] TM1 WHERE TM1.[ParametroCod] = @ParametroCod ORDER BY TM1.[ParametroCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D5", "SELECT [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = @ParametroCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D6", "SELECT TOP 1 [ParametroCod] FROM [Parametro] WHERE ( [ParametroCod] > @ParametroCod) ORDER BY [ParametroCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D7", "SELECT TOP 1 [ParametroCod] FROM [Parametro] WHERE ( [ParametroCod] < @ParametroCod) ORDER BY [ParametroCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D8", "INSERT INTO [Parametro]([ParametroCod], [ParametroDataAlteracao], [ParametroUsuarioAlteracao], [ParametroDescricao], [ParametroValor], [ParametroComentario], [ParametroDataInclusao], [ParametroUsuarioInclusao], [ParametroAtivo]) VALUES(@ParametroCod, @ParametroDataAlteracao, @ParametroUsuarioAlteracao, @ParametroDescricao, @ParametroValor, @ParametroComentario, @ParametroDataInclusao, @ParametroUsuarioInclusao, @ParametroAtivo)", GxErrorMask.GX_NOMASK,prmT001D8)
           ,new CursorDef("T001D9", "UPDATE [Parametro] SET [ParametroDataAlteracao]=@ParametroDataAlteracao, [ParametroUsuarioAlteracao]=@ParametroUsuarioAlteracao, [ParametroDescricao]=@ParametroDescricao, [ParametroValor]=@ParametroValor, [ParametroComentario]=@ParametroComentario, [ParametroDataInclusao]=@ParametroDataInclusao, [ParametroUsuarioInclusao]=@ParametroUsuarioInclusao, [ParametroAtivo]=@ParametroAtivo  WHERE [ParametroCod] = @ParametroCod", GxErrorMask.GX_NOMASK,prmT001D9)
           ,new CursorDef("T001D10", "DELETE FROM [Parametro]  WHERE [ParametroCod] = @ParametroCod", GxErrorMask.GX_NOMASK,prmT001D10)
           ,new CursorDef("T001D11", "SELECT [ParametroCod] FROM [Parametro] ORDER BY [ParametroCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
