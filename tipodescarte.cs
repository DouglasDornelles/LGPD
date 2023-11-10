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
   public class tipodescarte : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vISOK") == 0 )
         {
            A45TipoDescarteId = (int)(NumberUtil.Val( GetPar( "TipoDescarteId"), "."));
            n45TipoDescarteId = false;
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            A46TipoDescarteNome = GetPar( "TipoDescarteNome");
            AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK0F15( A45TipoDescarteId, A46TipoDescarteNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "tipodescarte.aspx")), "tipodescarte.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "tipodescarte.aspx")))) ;
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
                  AV7TipoDescarteId = (int)(NumberUtil.Val( GetPar( "TipoDescarteId"), "."));
                  AssignAttri("", false, "AV7TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV7TipoDescarteId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPODESCARTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipoDescarteId), "ZZZZZZZ9"), context));
                  AV14IsTipoDescarte = StringUtil.StrToBool( GetPar( "IsTipoDescarte"));
                  AssignAttri("", false, "AV14IsTipoDescarte", AV14IsTipoDescarte);
                  AV15TipoDescarteId_Out = (int)(NumberUtil.Val( GetPar( "TipoDescarteId_Out"), "."));
                  AssignAttri("", false, "AV15TipoDescarteId_Out", StringUtil.LTrimStr( (decimal)(AV15TipoDescarteId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Tipo Descarte", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipoDescarteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipodescarte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tipodescarte( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TipoDescarteId ,
                           out bool aP2_IsTipoDescarte ,
                           out int aP3_TipoDescarteId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipoDescarteId = aP1_TipoDescarteId;
         this.AV14IsTipoDescarte = false ;
         this.AV15TipoDescarteId_Out = 0 ;
         executePrivate();
         aP2_IsTipoDescarte=this.AV14IsTipoDescarte;
         aP3_TipoDescarteId_Out=this.AV15TipoDescarteId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTipoDescarteAtivo = new GXCombobox();
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
            return "tipodescarte_Execute" ;
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
         if ( cmbTipoDescarteAtivo.ItemCount > 0 )
         {
            A47TipoDescarteAtivo = StringUtil.StrToBool( cmbTipoDescarteAtivo.getValidValue(StringUtil.BoolToStr( A47TipoDescarteAtivo)));
            AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoDescarteAtivo.CurrentValue = StringUtil.BoolToStr( A47TipoDescarteAtivo);
            AssignProp("", false, cmbTipoDescarteAtivo_Internalname, "Values", cmbTipoDescarteAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoDescarteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoDescarteNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoDescarteNome_Internalname, A46TipoDescarteNome, StringUtil.RTrim( context.localUtil.Format( A46TipoDescarteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoDescarteNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoDescarteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_TipoDescarte.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbTipoDescarteAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTipoDescarteAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTipoDescarteAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipoDescarteAtivo, cmbTipoDescarteAtivo_Internalname, StringUtil.BoolToStr( A47TipoDescarteAtivo), 1, cmbTipoDescarteAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbTipoDescarteAtivo.Visible, cmbTipoDescarteAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_TipoDescarte.htm");
         cmbTipoDescarteAtivo.CurrentValue = StringUtil.BoolToStr( A47TipoDescarteAtivo);
         AssignProp("", false, cmbTipoDescarteAtivo_Internalname, "Values", (string)(cmbTipoDescarteAtivo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoDescarte.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoDescarte.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoDescarte.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTipoDescarteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TipoDescarteId), 8, 0, ",", "")), StringUtil.LTrim( ((edtTipoDescarteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A45TipoDescarteId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A45TipoDescarteId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoDescarteId_Jsonclick, 0, "Attribute", "", "", "", "", edtTipoDescarteId_Visible, edtTipoDescarteId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_TipoDescarte.htm");
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
         E110F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z45TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( "Z45TipoDescarteId"), ",", "."));
               Z46TipoDescarteNome = cgiGet( "Z46TipoDescarteNome");
               Z47TipoDescarteAtivo = StringUtil.StrToBool( cgiGet( "Z47TipoDescarteAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( "vTIPODESCARTEID"), ",", "."));
               AV16IsOk = StringUtil.StrToBool( cgiGet( "vISOK"));
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
               A46TipoDescarteNome = cgiGet( edtTipoDescarteNome_Internalname);
               AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
               cmbTipoDescarteAtivo.CurrentValue = cgiGet( cmbTipoDescarteAtivo_Internalname);
               A47TipoDescarteAtivo = StringUtil.StrToBool( cgiGet( cmbTipoDescarteAtivo_Internalname));
               AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
               A45TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( edtTipoDescarteId_Internalname), ",", "."));
               n45TipoDescarteId = false;
               AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoDescarte");
               A45TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( edtTipoDescarteId_Internalname), ",", "."));
               n45TipoDescarteId = false;
               AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
               forbiddenHiddens.Add("TipoDescarteId", context.localUtil.Format( (decimal)(A45TipoDescarteId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A45TipoDescarteId != Z45TipoDescarteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tipodescarte:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A45TipoDescarteId = (int)(NumberUtil.Val( GetPar( "TipoDescarteId"), "."));
                  n45TipoDescarteId = false;
                  AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPODESCARTEID");
                        AnyError = 1;
                        GX_FocusControl = edtTipoDescarteId_Internalname;
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
                           E110F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120F2 ();
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
            E120F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F15( ) ;
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
            DisableAttributes0F15( ) ;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F15( ) ;
            }
            else
            {
               CheckExtendedTable0F15( ) ;
               CloseExtendedTableCursors0F15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E110F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtTipoDescarteId_Visible = 0;
         AssignProp("", false, edtTipoDescarteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoDescarteId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbTipoDescarteAtivo.Visible = 0;
            AssignProp("", false, cmbTipoDescarteAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbTipoDescarteAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbTipoDescarteAtivo.Visible = 1;
            AssignProp("", false, cmbTipoDescarteAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbTipoDescarteAtivo.Visible), 5, 0), true);
         }
      }

      protected void E120F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsTipoDescarte = true;
         AssignAttri("", false, "AV14IsTipoDescarte", AV14IsTipoDescarte);
         AV15TipoDescarteId_Out = A45TipoDescarteId;
         AssignAttri("", false, "AV15TipoDescarteId_Out", StringUtil.LTrimStr( (decimal)(AV15TipoDescarteId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("tipodescarteww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV14IsTipoDescarte,(int)AV15TipoDescarteId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV14IsTipoDescarte","AV15TipoDescarteId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0F15( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z46TipoDescarteNome = T000F3_A46TipoDescarteNome[0];
               Z47TipoDescarteAtivo = T000F3_A47TipoDescarteAtivo[0];
            }
            else
            {
               Z46TipoDescarteNome = A46TipoDescarteNome;
               Z47TipoDescarteAtivo = A47TipoDescarteAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z45TipoDescarteId = A45TipoDescarteId;
            Z46TipoDescarteNome = A46TipoDescarteNome;
            Z47TipoDescarteAtivo = A47TipoDescarteAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTipoDescarteId_Enabled = 0;
         AssignProp("", false, edtTipoDescarteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoDescarteId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTipoDescarteId_Enabled = 0;
         AssignProp("", false, edtTipoDescarteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoDescarteId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipoDescarteId) )
         {
            A45TipoDescarteId = AV7TipoDescarteId;
            n45TipoDescarteId = false;
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
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
         if ( IsIns( )  && (false==A47TipoDescarteAtivo) && ( Gx_BScreen == 0 ) )
         {
            A47TipoDescarteAtivo = true;
            AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
         }
      }

      protected void Load0F15( )
      {
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound15 = 1;
            A46TipoDescarteNome = T000F4_A46TipoDescarteNome[0];
            AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
            A47TipoDescarteAtivo = T000F4_A47TipoDescarteAtivo[0];
            AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
            ZM0F15( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0F15( ) ;
      }

      protected void OnLoadActions0F15( )
      {
         A46TipoDescarteNome = StringUtil.Upper( A46TipoDescarteNome);
         AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
      }

      protected void CheckExtendedTable0F15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_15 = 1;
         A46TipoDescarteNome = StringUtil.Upper( A46TipoDescarteNome);
         AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A46TipoDescarteNome)) )
         {
            GX_msglist.addItem("Informe o nome do tipo de descarte.", 1, "TIPODESCARTENOME");
            AnyError = 1;
            GX_FocusControl = edtTipoDescarteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0F15( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F15( )
      {
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F15( 8) ;
            RcdFound15 = 1;
            A45TipoDescarteId = T000F3_A45TipoDescarteId[0];
            n45TipoDescarteId = T000F3_n45TipoDescarteId[0];
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            A46TipoDescarteNome = T000F3_A46TipoDescarteNome[0];
            AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
            A47TipoDescarteAtivo = T000F3_A47TipoDescarteAtivo[0];
            AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
            Z45TipoDescarteId = A45TipoDescarteId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0F15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0F15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000F6_A45TipoDescarteId[0] < A45TipoDescarteId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000F6_A45TipoDescarteId[0] > A45TipoDescarteId ) ) )
            {
               A45TipoDescarteId = T000F6_A45TipoDescarteId[0];
               n45TipoDescarteId = T000F6_n45TipoDescarteId[0];
               AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A45TipoDescarteId[0] > A45TipoDescarteId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A45TipoDescarteId[0] < A45TipoDescarteId ) ) )
            {
               A45TipoDescarteId = T000F7_A45TipoDescarteId[0];
               n45TipoDescarteId = T000F7_n45TipoDescarteId[0];
               AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipoDescarteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A45TipoDescarteId != Z45TipoDescarteId )
               {
                  A45TipoDescarteId = Z45TipoDescarteId;
                  n45TipoDescarteId = false;
                  AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPODESCARTEID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoDescarteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipoDescarteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F15( ) ;
                  GX_FocusControl = edtTipoDescarteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A45TipoDescarteId != Z45TipoDescarteId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipoDescarteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPODESCARTEID");
                     AnyError = 1;
                     GX_FocusControl = edtTipoDescarteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipoDescarteNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F15( ) ;
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
         if ( A45TipoDescarteId != Z45TipoDescarteId )
         {
            A45TipoDescarteId = Z45TipoDescarteId;
            n45TipoDescarteId = false;
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPODESCARTEID");
            AnyError = 1;
            GX_FocusControl = edtTipoDescarteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipoDescarteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0F15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoDescarte"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z46TipoDescarteNome, T000F2_A46TipoDescarteNome[0]) != 0 ) || ( Z47TipoDescarteAtivo != T000F2_A47TipoDescarteAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z46TipoDescarteNome, T000F2_A46TipoDescarteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("tipodescarte:[seudo value changed for attri]"+"TipoDescarteNome");
                  GXUtil.WriteLogRaw("Old: ",Z46TipoDescarteNome);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A46TipoDescarteNome[0]);
               }
               if ( Z47TipoDescarteAtivo != T000F2_A47TipoDescarteAtivo[0] )
               {
                  GXUtil.WriteLog("tipodescarte:[seudo value changed for attri]"+"TipoDescarteAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z47TipoDescarteAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A47TipoDescarteAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoDescarte"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F15( )
      {
         if ( ! IsAuthorized("tipodescarte_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F15( 0) ;
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F8 */
                     pr_default.execute(6, new Object[] {A46TipoDescarteNome, A47TipoDescarteAtivo});
                     A45TipoDescarteId = T000F8_A45TipoDescarteId[0];
                     n45TipoDescarteId = T000F8_n45TipoDescarteId[0];
                     AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TipoDescarte");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
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
               Load0F15( ) ;
            }
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void Update0F15( )
      {
         if ( ! IsAuthorized("tipodescarte_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F9 */
                     pr_default.execute(7, new Object[] {A46TipoDescarteNome, A47TipoDescarteAtivo, n45TipoDescarteId, A45TipoDescarteId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TipoDescarte");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoDescarte"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F15( ) ;
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
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void DeferredUpdate0F15( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tipodescarte_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F15( ) ;
            AfterConfirm0F15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F10 */
                  pr_default.execute(8, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TipoDescarte");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
            AssignAttri("", false, "AV16IsOk", AV16IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F11 */
            pr_default.execute(9, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0F15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tipodescarte",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tipodescarte",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F15( )
      {
         /* Scan By routine */
         /* Using cursor T000F12 */
         pr_default.execute(10);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound15 = 1;
            A45TipoDescarteId = T000F12_A45TipoDescarteId[0];
            n45TipoDescarteId = T000F12_n45TipoDescarteId[0];
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F15( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound15 = 1;
            A45TipoDescarteId = T000F12_A45TipoDescarteId[0];
            n45TipoDescarteId = T000F12_n45TipoDescarteId[0];
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         }
      }

      protected void ScanEnd0F15( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0F15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F15( )
      {
         edtTipoDescarteNome_Enabled = 0;
         AssignProp("", false, edtTipoDescarteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoDescarteNome_Enabled), 5, 0), true);
         cmbTipoDescarteAtivo.Enabled = 0;
         AssignProp("", false, cmbTipoDescarteAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipoDescarteAtivo.Enabled), 5, 0), true);
         edtTipoDescarteId_Enabled = 0;
         AssignProp("", false, edtTipoDescarteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoDescarteId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
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
         GXEncryptionTmp = "tipodescarte.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipoDescarteId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsTipoDescarte)) + "," + UrlEncode(StringUtil.LTrimStr(AV15TipoDescarteId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tipodescarte.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoDescarte");
         forbiddenHiddens.Add("TipoDescarteId", context.localUtil.Format( (decimal)(A45TipoDescarteId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tipodescarte:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z45TipoDescarteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45TipoDescarteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z46TipoDescarteNome", Z46TipoDescarteNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z47TipoDescarteAtivo", Z47TipoDescarteAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISTIPODESCARTE", AV14IsTipoDescarte);
         GxWebStd.gx_hidden_field( context, "vTIPODESCARTEID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15TipoDescarteId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTIPODESCARTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipoDescarteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPODESCARTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipoDescarteId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV16IsOk);
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
         GXEncryptionTmp = "tipodescarte.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipoDescarteId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsTipoDescarte)) + "," + UrlEncode(StringUtil.LTrimStr(AV15TipoDescarteId_Out,8,0));
         return formatLink("tipodescarte.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "TipoDescarte" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo Descarte" ;
      }

      protected void InitializeNonKey0F15( )
      {
         A46TipoDescarteNome = "";
         AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
         AV16IsOk = false;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         A47TipoDescarteAtivo = true;
         AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
         Z46TipoDescarteNome = "";
         Z47TipoDescarteAtivo = false;
      }

      protected void InitAll0F15( )
      {
         A45TipoDescarteId = 0;
         n45TipoDescarteId = false;
         AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         InitializeNonKey0F15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A47TipoDescarteAtivo = i47TipoDescarteAtivo;
         AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417263321", true, true);
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
         context.AddJavascriptSource("tipodescarte.js", "?202312417263321", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTipoDescarteNome_Internalname = "TIPODESCARTENOME";
         cmbTipoDescarteAtivo_Internalname = "TIPODESCARTEATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTipoDescarteId_Internalname = "TIPODESCARTEID";
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
         Form.Caption = "Tipo Descarte";
         edtTipoDescarteId_Jsonclick = "";
         edtTipoDescarteId_Enabled = 0;
         edtTipoDescarteId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTipoDescarteAtivo_Jsonclick = "";
         cmbTipoDescarteAtivo.Enabled = 1;
         cmbTipoDescarteAtivo.Visible = 1;
         edtTipoDescarteNome_Jsonclick = "";
         edtTipoDescarteNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "TIPO DE DESCARTE";
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

      protected void GX4ASAISOK0F15( int A45TipoDescarteId ,
                                     string A46TipoDescarteNome )
      {
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV16IsOk))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbTipoDescarteAtivo.Name = "TIPODESCARTEATIVO";
         cmbTipoDescarteAtivo.WebTags = "";
         cmbTipoDescarteAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbTipoDescarteAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbTipoDescarteAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A47TipoDescarteAtivo) )
            {
               A47TipoDescarteAtivo = true;
               AssignAttri("", false, "A47TipoDescarteAtivo", A47TipoDescarteAtivo);
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

      public void Valid_Tipodescartenome( )
      {
         n45TipoDescarteId = false;
         A46TipoDescarteNome = StringUtil.Upper( A46TipoDescarteNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "TIPODESCARTENOME");
            AnyError = 1;
            GX_FocusControl = edtTipoDescarteNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A46TipoDescarteNome)) )
         {
            GX_msglist.addItem("Informe o nome do tipo de descarte.", 1, "TIPODESCARTENOME");
            AnyError = 1;
            GX_FocusControl = edtTipoDescarteNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A46TipoDescarteNome", A46TipoDescarteNome);
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9',hsh:true},{av:'AV14IsTipoDescarte',fld:'vISTIPODESCARTE',pic:''},{av:'AV15TipoDescarteId_Out',fld:'vTIPODESCARTEID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9',hsh:true},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120F2',iparms:[{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV14IsTipoDescarte',fld:'vISTIPODESCARTE',pic:''},{av:'AV15TipoDescarteId_Out',fld:'vTIPODESCARTEID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_TIPODESCARTENOME","{handler:'Valid_Tipodescartenome',iparms:[{av:'A46TipoDescarteNome',fld:'TIPODESCARTENOME',pic:''},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'AV16IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_TIPODESCARTENOME",",oparms:[{av:'A46TipoDescarteNome',fld:'TIPODESCARTENOME',pic:''},{av:'AV16IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_TIPODESCARTEID","{handler:'Valid_Tipodescarteid',iparms:[]");
         setEventMetadata("VALID_TIPODESCARTEID",",oparms:[]}");
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
         Z46TipoDescarteNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A46TipoDescarteNome = "";
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
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000F4_A45TipoDescarteId = new int[1] ;
         T000F4_n45TipoDescarteId = new bool[] {false} ;
         T000F4_A46TipoDescarteNome = new string[] {""} ;
         T000F4_A47TipoDescarteAtivo = new bool[] {false} ;
         T000F5_A45TipoDescarteId = new int[1] ;
         T000F5_n45TipoDescarteId = new bool[] {false} ;
         T000F3_A45TipoDescarteId = new int[1] ;
         T000F3_n45TipoDescarteId = new bool[] {false} ;
         T000F3_A46TipoDescarteNome = new string[] {""} ;
         T000F3_A47TipoDescarteAtivo = new bool[] {false} ;
         T000F6_A45TipoDescarteId = new int[1] ;
         T000F6_n45TipoDescarteId = new bool[] {false} ;
         T000F7_A45TipoDescarteId = new int[1] ;
         T000F7_n45TipoDescarteId = new bool[] {false} ;
         T000F2_A45TipoDescarteId = new int[1] ;
         T000F2_n45TipoDescarteId = new bool[] {false} ;
         T000F2_A46TipoDescarteNome = new string[] {""} ;
         T000F2_A47TipoDescarteAtivo = new bool[] {false} ;
         T000F8_A45TipoDescarteId = new int[1] ;
         T000F8_n45TipoDescarteId = new bool[] {false} ;
         T000F11_A75DocumentoId = new int[1] ;
         T000F12_A45TipoDescarteId = new int[1] ;
         T000F12_n45TipoDescarteId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tipodescarte__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipodescarte__default(),
            new Object[][] {
                new Object[] {
               T000F2_A45TipoDescarteId, T000F2_A46TipoDescarteNome, T000F2_A47TipoDescarteAtivo
               }
               , new Object[] {
               T000F3_A45TipoDescarteId, T000F3_A46TipoDescarteNome, T000F3_A47TipoDescarteAtivo
               }
               , new Object[] {
               T000F4_A45TipoDescarteId, T000F4_A46TipoDescarteNome, T000F4_A47TipoDescarteAtivo
               }
               , new Object[] {
               T000F5_A45TipoDescarteId
               }
               , new Object[] {
               T000F6_A45TipoDescarteId
               }
               , new Object[] {
               T000F7_A45TipoDescarteId
               }
               , new Object[] {
               T000F8_A45TipoDescarteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F11_A75DocumentoId
               }
               , new Object[] {
               T000F12_A45TipoDescarteId
               }
            }
         );
         Z47TipoDescarteAtivo = true;
         A47TipoDescarteAtivo = true;
         i47TipoDescarteAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short GX_JID ;
      private short nIsDirty_15 ;
      private short gxajaxcallmode ;
      private int wcpOAV7TipoDescarteId ;
      private int Z45TipoDescarteId ;
      private int A45TipoDescarteId ;
      private int AV7TipoDescarteId ;
      private int AV15TipoDescarteId_Out ;
      private int trnEnded ;
      private int edtTipoDescarteNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtTipoDescarteId_Enabled ;
      private int edtTipoDescarteId_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
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
      private string edtTipoDescarteNome_Internalname ;
      private string cmbTipoDescarteAtivo_Internalname ;
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
      private string edtTipoDescarteNome_Jsonclick ;
      private string cmbTipoDescarteAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTipoDescarteId_Internalname ;
      private string edtTipoDescarteId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode15 ;
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
      private bool Z47TipoDescarteAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n45TipoDescarteId ;
      private bool AV14IsTipoDescarte ;
      private bool wbErr ;
      private bool A47TipoDescarteAtivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV16IsOk ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i47TipoDescarteAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV16IsOk ;
      private string Z46TipoDescarteNome ;
      private string A46TipoDescarteNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTipoDescarteAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T000F4_A45TipoDescarteId ;
      private bool[] T000F4_n45TipoDescarteId ;
      private string[] T000F4_A46TipoDescarteNome ;
      private bool[] T000F4_A47TipoDescarteAtivo ;
      private int[] T000F5_A45TipoDescarteId ;
      private bool[] T000F5_n45TipoDescarteId ;
      private int[] T000F3_A45TipoDescarteId ;
      private bool[] T000F3_n45TipoDescarteId ;
      private string[] T000F3_A46TipoDescarteNome ;
      private bool[] T000F3_A47TipoDescarteAtivo ;
      private int[] T000F6_A45TipoDescarteId ;
      private bool[] T000F6_n45TipoDescarteId ;
      private int[] T000F7_A45TipoDescarteId ;
      private bool[] T000F7_n45TipoDescarteId ;
      private int[] T000F2_A45TipoDescarteId ;
      private bool[] T000F2_n45TipoDescarteId ;
      private string[] T000F2_A46TipoDescarteNome ;
      private bool[] T000F2_A47TipoDescarteAtivo ;
      private int[] T000F8_A45TipoDescarteId ;
      private bool[] T000F8_n45TipoDescarteId ;
      private int[] T000F11_A75DocumentoId ;
      private int[] T000F12_A45TipoDescarteId ;
      private bool[] T000F12_n45TipoDescarteId ;
      private bool aP2_IsTipoDescarte ;
      private int aP3_TipoDescarteId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class tipodescarte__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tipodescarte__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000F4;
        prmT000F4 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F5;
        prmT000F5 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F3;
        prmT000F3 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F6;
        prmT000F6 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F7;
        prmT000F7 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F2;
        prmT000F2 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F8;
        prmT000F8 = new Object[] {
        new ParDef("@TipoDescarteNome",GXType.NVarChar,100,0) ,
        new ParDef("@TipoDescarteAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT000F9;
        prmT000F9 = new Object[] {
        new ParDef("@TipoDescarteNome",GXType.NVarChar,100,0) ,
        new ParDef("@TipoDescarteAtivo",GXType.Boolean,4,0) ,
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F10;
        prmT000F10 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F11;
        prmT000F11 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000F12;
        prmT000F12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000F2", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WITH (UPDLOCK) WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F3", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F4", "SELECT TM1.[TipoDescarteId], TM1.[TipoDescarteNome], TM1.[TipoDescarteAtivo] FROM [TipoDescarte] TM1 WHERE TM1.[TipoDescarteId] = @TipoDescarteId ORDER BY TM1.[TipoDescarteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F5", "SELECT [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F6", "SELECT TOP 1 [TipoDescarteId] FROM [TipoDescarte] WHERE ( [TipoDescarteId] > @TipoDescarteId) ORDER BY [TipoDescarteId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F7", "SELECT TOP 1 [TipoDescarteId] FROM [TipoDescarte] WHERE ( [TipoDescarteId] < @TipoDescarteId) ORDER BY [TipoDescarteId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F8", "INSERT INTO [TipoDescarte]([TipoDescarteNome], [TipoDescarteAtivo]) VALUES(@TipoDescarteNome, @TipoDescarteAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F9", "UPDATE [TipoDescarte] SET [TipoDescarteNome]=@TipoDescarteNome, [TipoDescarteAtivo]=@TipoDescarteAtivo  WHERE [TipoDescarteId] = @TipoDescarteId", GxErrorMask.GX_NOMASK,prmT000F9)
           ,new CursorDef("T000F10", "DELETE FROM [TipoDescarte]  WHERE [TipoDescarteId] = @TipoDescarteId", GxErrorMask.GX_NOMASK,prmT000F10)
           ,new CursorDef("T000F11", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F12", "SELECT [TipoDescarteId] FROM [TipoDescarte] ORDER BY [TipoDescarteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F12,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
