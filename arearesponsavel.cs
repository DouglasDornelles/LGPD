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
   public class arearesponsavel : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A24AreaResponsavelId = (int)(NumberUtil.Val( GetPar( "AreaResponsavelId"), "."));
            n24AreaResponsavelId = false;
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
            A25AreaResponsavelNome = GetPar( "AreaResponsavelNome");
            AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK1C8( A24AreaResponsavelId, A25AreaResponsavelNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "arearesponsavel.aspx")), "arearesponsavel.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "arearesponsavel.aspx")))) ;
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
                  AV7AreaResponsavelId = (int)(NumberUtil.Val( GetPar( "AreaResponsavelId"), "."));
                  AssignAttri("", false, "AV7AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV7AreaResponsavelId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAREARESPONSAVELID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AreaResponsavelId), "ZZZZZZZ9"), context));
                  AV14IsAreaResponsavel = StringUtil.StrToBool( GetPar( "IsAreaResponsavel"));
                  AssignAttri("", false, "AV14IsAreaResponsavel", AV14IsAreaResponsavel);
                  AV15AreaResponsavelId_Out = (int)(NumberUtil.Val( GetPar( "AreaResponsavelId_Out"), "."));
                  AssignAttri("", false, "AV15AreaResponsavelId_Out", StringUtil.LTrimStr( (decimal)(AV15AreaResponsavelId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Area Responsavel", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAreaResponsavelNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public arearesponsavel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public arearesponsavel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_AreaResponsavelId ,
                           out bool aP2_IsAreaResponsavel ,
                           out int aP3_AreaResponsavelId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AreaResponsavelId = aP1_AreaResponsavelId;
         this.AV14IsAreaResponsavel = false ;
         this.AV15AreaResponsavelId_Out = 0 ;
         executePrivate();
         aP2_IsAreaResponsavel=this.AV14IsAreaResponsavel;
         aP3_AreaResponsavelId_Out=this.AV15AreaResponsavelId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbAreaResponsavelAtivo = new GXCombobox();
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
            return "arearesponsavel_Execute" ;
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
         if ( cmbAreaResponsavelAtivo.ItemCount > 0 )
         {
            A26AreaResponsavelAtivo = StringUtil.StrToBool( cmbAreaResponsavelAtivo.getValidValue(StringUtil.BoolToStr( A26AreaResponsavelAtivo)));
            AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAreaResponsavelAtivo.CurrentValue = StringUtil.BoolToStr( A26AreaResponsavelAtivo);
            AssignProp("", false, cmbAreaResponsavelAtivo_Internalname, "Values", cmbAreaResponsavelAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAreaResponsavelNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreaResponsavelNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreaResponsavelNome_Internalname, A25AreaResponsavelNome, StringUtil.RTrim( context.localUtil.Format( A25AreaResponsavelNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaResponsavelNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAreaResponsavelNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_AreaResponsavel.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbAreaResponsavelAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbAreaResponsavelAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAreaResponsavelAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAreaResponsavelAtivo, cmbAreaResponsavelAtivo_Internalname, StringUtil.BoolToStr( A26AreaResponsavelAtivo), 1, cmbAreaResponsavelAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbAreaResponsavelAtivo.Visible, cmbAreaResponsavelAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_AreaResponsavel.htm");
         cmbAreaResponsavelAtivo.CurrentValue = StringUtil.BoolToStr( A26AreaResponsavelAtivo);
         AssignProp("", false, cmbAreaResponsavelAtivo_Internalname, "Values", (string)(cmbAreaResponsavelAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaResponsavel.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaResponsavel.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaResponsavel.htm");
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
         GxWebStd.gx_single_line_edit( context, edtAreaResponsavelId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AreaResponsavelId), 8, 0, ",", "")), StringUtil.LTrim( ((edtAreaResponsavelId_Enabled!=0) ? context.localUtil.Format( (decimal)(A24AreaResponsavelId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A24AreaResponsavelId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaResponsavelId_Jsonclick, 0, "Attribute", "", "", "", "", edtAreaResponsavelId_Visible, edtAreaResponsavelId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_AreaResponsavel.htm");
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
         E111C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "Z24AreaResponsavelId"), ",", "."));
               Z25AreaResponsavelNome = cgiGet( "Z25AreaResponsavelNome");
               Z26AreaResponsavelAtivo = StringUtil.StrToBool( cgiGet( "Z26AreaResponsavelAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "vAREARESPONSAVELID"), ",", "."));
               AV13IsOk = StringUtil.StrToBool( cgiGet( "vISOK"));
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
               A25AreaResponsavelNome = cgiGet( edtAreaResponsavelNome_Internalname);
               AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
               cmbAreaResponsavelAtivo.CurrentValue = cgiGet( cmbAreaResponsavelAtivo_Internalname);
               A26AreaResponsavelAtivo = StringUtil.StrToBool( cgiGet( cmbAreaResponsavelAtivo_Internalname));
               AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
               A24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( edtAreaResponsavelId_Internalname), ",", "."));
               n24AreaResponsavelId = false;
               AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"AreaResponsavel");
               A24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( edtAreaResponsavelId_Internalname), ",", "."));
               n24AreaResponsavelId = false;
               AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
               forbiddenHiddens.Add("AreaResponsavelId", context.localUtil.Format( (decimal)(A24AreaResponsavelId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A24AreaResponsavelId != Z24AreaResponsavelId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("arearesponsavel:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A24AreaResponsavelId = (int)(NumberUtil.Val( GetPar( "AreaResponsavelId"), "."));
                  n24AreaResponsavelId = false;
                  AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
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
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AREARESPONSAVELID");
                        AnyError = 1;
                        GX_FocusControl = edtAreaResponsavelId_Internalname;
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
                           E111C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121C2 ();
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
            E121C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1C8( ) ;
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
            DisableAttributes1C8( ) ;
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C8( ) ;
            }
            else
            {
               CheckExtendedTable1C8( ) ;
               CloseExtendedTableCursors1C8( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1C0( )
      {
      }

      protected void E111C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtAreaResponsavelId_Visible = 0;
         AssignProp("", false, edtAreaResponsavelId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAreaResponsavelId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbAreaResponsavelAtivo.Visible = 0;
            AssignProp("", false, cmbAreaResponsavelAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbAreaResponsavelAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbAreaResponsavelAtivo.Visible = 1;
            AssignProp("", false, cmbAreaResponsavelAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbAreaResponsavelAtivo.Visible), 5, 0), true);
         }
      }

      protected void E121C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsAreaResponsavel = true;
         AssignAttri("", false, "AV14IsAreaResponsavel", AV14IsAreaResponsavel);
         AV15AreaResponsavelId_Out = A24AreaResponsavelId;
         AssignAttri("", false, "AV15AreaResponsavelId_Out", StringUtil.LTrimStr( (decimal)(AV15AreaResponsavelId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("arearesponsavelww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV14IsAreaResponsavel,(int)AV15AreaResponsavelId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV14IsAreaResponsavel","AV15AreaResponsavelId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM1C8( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z25AreaResponsavelNome = T001C3_A25AreaResponsavelNome[0];
               Z26AreaResponsavelAtivo = T001C3_A26AreaResponsavelAtivo[0];
            }
            else
            {
               Z25AreaResponsavelNome = A25AreaResponsavelNome;
               Z26AreaResponsavelAtivo = A26AreaResponsavelAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z24AreaResponsavelId = A24AreaResponsavelId;
            Z25AreaResponsavelNome = A25AreaResponsavelNome;
            Z26AreaResponsavelAtivo = A26AreaResponsavelAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAreaResponsavelId_Enabled = 0;
         AssignProp("", false, edtAreaResponsavelId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaResponsavelId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtAreaResponsavelId_Enabled = 0;
         AssignProp("", false, edtAreaResponsavelId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaResponsavelId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AreaResponsavelId) )
         {
            A24AreaResponsavelId = AV7AreaResponsavelId;
            n24AreaResponsavelId = false;
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
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
         if ( IsIns( )  && (false==A26AreaResponsavelAtivo) && ( Gx_BScreen == 0 ) )
         {
            A26AreaResponsavelAtivo = true;
            AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
         }
      }

      protected void Load1C8( )
      {
         /* Using cursor T001C4 */
         pr_default.execute(2, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A25AreaResponsavelNome = T001C4_A25AreaResponsavelNome[0];
            AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
            A26AreaResponsavelAtivo = T001C4_A26AreaResponsavelAtivo[0];
            AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
            ZM1C8( -8) ;
         }
         pr_default.close(2);
         OnLoadActions1C8( ) ;
      }

      protected void OnLoadActions1C8( )
      {
         A25AreaResponsavelNome = StringUtil.Upper( A25AreaResponsavelNome);
         AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
         GXt_boolean1 = AV13IsOk;
         new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
         AV13IsOk = GXt_boolean1;
         AssignAttri("", false, "AV13IsOk", AV13IsOk);
      }

      protected void CheckExtendedTable1C8( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_8 = 1;
         A25AreaResponsavelNome = StringUtil.Upper( A25AreaResponsavelNome);
         AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
         GXt_boolean1 = AV13IsOk;
         new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
         AV13IsOk = GXt_boolean1;
         AssignAttri("", false, "AV13IsOk", AV13IsOk);
         if ( ! AV13IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A25AreaResponsavelNome)) )
         {
            GX_msglist.addItem("Informe o nome da área responsável.", 1, "AREARESPONSAVELNOME");
            AnyError = 1;
            GX_FocusControl = edtAreaResponsavelNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1C8( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C8( )
      {
         /* Using cursor T001C5 */
         pr_default.execute(3, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001C3 */
         pr_default.execute(1, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C8( 8) ;
            RcdFound8 = 1;
            A24AreaResponsavelId = T001C3_A24AreaResponsavelId[0];
            n24AreaResponsavelId = T001C3_n24AreaResponsavelId[0];
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
            A25AreaResponsavelNome = T001C3_A25AreaResponsavelNome[0];
            AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
            A26AreaResponsavelAtivo = T001C3_A26AreaResponsavelAtivo[0];
            AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
            Z24AreaResponsavelId = A24AreaResponsavelId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1C8( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey1C8( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey1C8( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C8( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T001C6 */
         pr_default.execute(4, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001C6_A24AreaResponsavelId[0] < A24AreaResponsavelId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001C6_A24AreaResponsavelId[0] > A24AreaResponsavelId ) ) )
            {
               A24AreaResponsavelId = T001C6_A24AreaResponsavelId[0];
               n24AreaResponsavelId = T001C6_n24AreaResponsavelId[0];
               AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T001C7 */
         pr_default.execute(5, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001C7_A24AreaResponsavelId[0] > A24AreaResponsavelId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001C7_A24AreaResponsavelId[0] < A24AreaResponsavelId ) ) )
            {
               A24AreaResponsavelId = T001C7_A24AreaResponsavelId[0];
               n24AreaResponsavelId = T001C7_n24AreaResponsavelId[0];
               AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1C8( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAreaResponsavelNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1C8( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A24AreaResponsavelId != Z24AreaResponsavelId )
               {
                  A24AreaResponsavelId = Z24AreaResponsavelId;
                  n24AreaResponsavelId = false;
                  AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AREARESPONSAVELID");
                  AnyError = 1;
                  GX_FocusControl = edtAreaResponsavelId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAreaResponsavelNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1C8( ) ;
                  GX_FocusControl = edtAreaResponsavelNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A24AreaResponsavelId != Z24AreaResponsavelId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAreaResponsavelNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1C8( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AREARESPONSAVELID");
                     AnyError = 1;
                     GX_FocusControl = edtAreaResponsavelId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAreaResponsavelNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1C8( ) ;
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
         if ( A24AreaResponsavelId != Z24AreaResponsavelId )
         {
            A24AreaResponsavelId = Z24AreaResponsavelId;
            n24AreaResponsavelId = false;
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AREARESPONSAVELID");
            AnyError = 1;
            GX_FocusControl = edtAreaResponsavelId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAreaResponsavelNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1C8( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C2 */
            pr_default.execute(0, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaResponsavel"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z25AreaResponsavelNome, T001C2_A25AreaResponsavelNome[0]) != 0 ) || ( Z26AreaResponsavelAtivo != T001C2_A26AreaResponsavelAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z25AreaResponsavelNome, T001C2_A25AreaResponsavelNome[0]) != 0 )
               {
                  GXUtil.WriteLog("arearesponsavel:[seudo value changed for attri]"+"AreaResponsavelNome");
                  GXUtil.WriteLogRaw("Old: ",Z25AreaResponsavelNome);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A25AreaResponsavelNome[0]);
               }
               if ( Z26AreaResponsavelAtivo != T001C2_A26AreaResponsavelAtivo[0] )
               {
                  GXUtil.WriteLog("arearesponsavel:[seudo value changed for attri]"+"AreaResponsavelAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z26AreaResponsavelAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A26AreaResponsavelAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AreaResponsavel"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C8( )
      {
         if ( ! IsAuthorized("arearesponsavel_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C8( 0) ;
            CheckOptimisticConcurrency1C8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C8 */
                     pr_default.execute(6, new Object[] {A25AreaResponsavelNome, A26AreaResponsavelAtivo});
                     A24AreaResponsavelId = T001C8_A24AreaResponsavelId[0];
                     n24AreaResponsavelId = T001C8_n24AreaResponsavelId[0];
                     AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("AreaResponsavel");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1C0( ) ;
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
               Load1C8( ) ;
            }
            EndLevel1C8( ) ;
         }
         CloseExtendedTableCursors1C8( ) ;
      }

      protected void Update1C8( )
      {
         if ( ! IsAuthorized("arearesponsavel_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C9 */
                     pr_default.execute(7, new Object[] {A25AreaResponsavelNome, A26AreaResponsavelAtivo, n24AreaResponsavelId, A24AreaResponsavelId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("AreaResponsavel");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaResponsavel"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C8( ) ;
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
            EndLevel1C8( ) ;
         }
         CloseExtendedTableCursors1C8( ) ;
      }

      protected void DeferredUpdate1C8( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("arearesponsavel_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C8( ) ;
            AfterConfirm1C8( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C8( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001C10 */
                  pr_default.execute(8, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("AreaResponsavel");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C8( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C8( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV13IsOk;
            new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
            AV13IsOk = GXt_boolean1;
            AssignAttri("", false, "AV13IsOk", AV13IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001C11 */
            pr_default.execute(9, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1C8( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("arearesponsavel",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("arearesponsavel",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1C8( )
      {
         /* Scan By routine */
         /* Using cursor T001C12 */
         pr_default.execute(10);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A24AreaResponsavelId = T001C12_A24AreaResponsavelId[0];
            n24AreaResponsavelId = T001C12_n24AreaResponsavelId[0];
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C8( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A24AreaResponsavelId = T001C12_A24AreaResponsavelId[0];
            n24AreaResponsavelId = T001C12_n24AreaResponsavelId[0];
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
         }
      }

      protected void ScanEnd1C8( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1C8( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C8( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C8( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C8( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C8( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C8( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C8( )
      {
         edtAreaResponsavelNome_Enabled = 0;
         AssignProp("", false, edtAreaResponsavelNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaResponsavelNome_Enabled), 5, 0), true);
         cmbAreaResponsavelAtivo.Enabled = 0;
         AssignProp("", false, cmbAreaResponsavelAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAreaResponsavelAtivo.Enabled), 5, 0), true);
         edtAreaResponsavelId_Enabled = 0;
         AssignProp("", false, edtAreaResponsavelId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaResponsavelId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1C8( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1C0( )
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
         GXEncryptionTmp = "arearesponsavel.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AreaResponsavelId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsAreaResponsavel)) + "," + UrlEncode(StringUtil.LTrimStr(AV15AreaResponsavelId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("arearesponsavel.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"AreaResponsavel");
         forbiddenHiddens.Add("AreaResponsavelId", context.localUtil.Format( (decimal)(A24AreaResponsavelId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("arearesponsavel:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z24AreaResponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24AreaResponsavelId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z25AreaResponsavelNome", Z25AreaResponsavelNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z26AreaResponsavelAtivo", Z26AreaResponsavelAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAREARESPONSAVEL", AV14IsAreaResponsavel);
         GxWebStd.gx_hidden_field( context, "vAREARESPONSAVELID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15AreaResponsavelId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vAREARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AreaResponsavelId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAREARESPONSAVELID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AreaResponsavelId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV13IsOk);
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
         GXEncryptionTmp = "arearesponsavel.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AreaResponsavelId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsAreaResponsavel)) + "," + UrlEncode(StringUtil.LTrimStr(AV15AreaResponsavelId_Out,8,0));
         return formatLink("arearesponsavel.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AreaResponsavel" ;
      }

      public override string GetPgmdesc( )
      {
         return "Area Responsavel" ;
      }

      protected void InitializeNonKey1C8( )
      {
         A25AreaResponsavelNome = "";
         AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
         AV13IsOk = false;
         AssignAttri("", false, "AV13IsOk", AV13IsOk);
         A26AreaResponsavelAtivo = true;
         AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
         Z25AreaResponsavelNome = "";
         Z26AreaResponsavelAtivo = false;
      }

      protected void InitAll1C8( )
      {
         A24AreaResponsavelId = 0;
         n24AreaResponsavelId = false;
         AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
         InitializeNonKey1C8( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A26AreaResponsavelAtivo = i26AreaResponsavelAtivo;
         AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417265187", true, true);
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
         context.AddJavascriptSource("arearesponsavel.js", "?202312417265187", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtAreaResponsavelNome_Internalname = "AREARESPONSAVELNOME";
         cmbAreaResponsavelAtivo_Internalname = "AREARESPONSAVELATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtAreaResponsavelId_Internalname = "AREARESPONSAVELID";
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
         Form.Caption = "Area Responsavel";
         edtAreaResponsavelId_Jsonclick = "";
         edtAreaResponsavelId_Enabled = 0;
         edtAreaResponsavelId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbAreaResponsavelAtivo_Jsonclick = "";
         cmbAreaResponsavelAtivo.Enabled = 1;
         cmbAreaResponsavelAtivo.Visible = 1;
         edtAreaResponsavelNome_Jsonclick = "";
         edtAreaResponsavelNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "ÁREA RESPONSÁVEL";
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

      protected void GX4ASAISOK1C8( int A24AreaResponsavelId ,
                                    string A25AreaResponsavelNome )
      {
         GXt_boolean1 = AV13IsOk;
         new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
         AV13IsOk = GXt_boolean1;
         AssignAttri("", false, "AV13IsOk", AV13IsOk);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV13IsOk))+"\"") ;
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
         cmbAreaResponsavelAtivo.Name = "AREARESPONSAVELATIVO";
         cmbAreaResponsavelAtivo.WebTags = "";
         cmbAreaResponsavelAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbAreaResponsavelAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbAreaResponsavelAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A26AreaResponsavelAtivo) )
            {
               A26AreaResponsavelAtivo = true;
               AssignAttri("", false, "A26AreaResponsavelAtivo", A26AreaResponsavelAtivo);
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

      public void Valid_Arearesponsavelnome( )
      {
         n24AreaResponsavelId = false;
         A25AreaResponsavelNome = StringUtil.Upper( A25AreaResponsavelNome);
         GXt_boolean1 = AV13IsOk;
         new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
         AV13IsOk = GXt_boolean1;
         if ( ! AV13IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "AREARESPONSAVELNOME");
            AnyError = 1;
            GX_FocusControl = edtAreaResponsavelNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A25AreaResponsavelNome)) )
         {
            GX_msglist.addItem("Informe o nome da área responsável.", 1, "AREARESPONSAVELNOME");
            AnyError = 1;
            GX_FocusControl = edtAreaResponsavelNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25AreaResponsavelNome", A25AreaResponsavelNome);
         AssignAttri("", false, "AV13IsOk", AV13IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9',hsh:true},{av:'AV14IsAreaResponsavel',fld:'vISAREARESPONSAVEL',pic:''},{av:'AV15AreaResponsavelId_Out',fld:'vAREARESPONSAVELID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9',hsh:true},{av:'A24AreaResponsavelId',fld:'AREARESPONSAVELID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121C2',iparms:[{av:'A24AreaResponsavelId',fld:'AREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV14IsAreaResponsavel',fld:'vISAREARESPONSAVEL',pic:''},{av:'AV15AreaResponsavelId_Out',fld:'vAREARESPONSAVELID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_AREARESPONSAVELNOME","{handler:'Valid_Arearesponsavelnome',iparms:[{av:'A25AreaResponsavelNome',fld:'AREARESPONSAVELNOME',pic:''},{av:'A24AreaResponsavelId',fld:'AREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'AV13IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_AREARESPONSAVELNOME",",oparms:[{av:'A25AreaResponsavelNome',fld:'AREARESPONSAVELNOME',pic:''},{av:'AV13IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_AREARESPONSAVELID","{handler:'Valid_Arearesponsavelid',iparms:[]");
         setEventMetadata("VALID_AREARESPONSAVELID",",oparms:[]}");
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
         Z25AreaResponsavelNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A25AreaResponsavelNome = "";
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
         sMode8 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T001C4_A24AreaResponsavelId = new int[1] ;
         T001C4_n24AreaResponsavelId = new bool[] {false} ;
         T001C4_A25AreaResponsavelNome = new string[] {""} ;
         T001C4_A26AreaResponsavelAtivo = new bool[] {false} ;
         T001C5_A24AreaResponsavelId = new int[1] ;
         T001C5_n24AreaResponsavelId = new bool[] {false} ;
         T001C3_A24AreaResponsavelId = new int[1] ;
         T001C3_n24AreaResponsavelId = new bool[] {false} ;
         T001C3_A25AreaResponsavelNome = new string[] {""} ;
         T001C3_A26AreaResponsavelAtivo = new bool[] {false} ;
         T001C6_A24AreaResponsavelId = new int[1] ;
         T001C6_n24AreaResponsavelId = new bool[] {false} ;
         T001C7_A24AreaResponsavelId = new int[1] ;
         T001C7_n24AreaResponsavelId = new bool[] {false} ;
         T001C2_A24AreaResponsavelId = new int[1] ;
         T001C2_n24AreaResponsavelId = new bool[] {false} ;
         T001C2_A25AreaResponsavelNome = new string[] {""} ;
         T001C2_A26AreaResponsavelAtivo = new bool[] {false} ;
         T001C8_A24AreaResponsavelId = new int[1] ;
         T001C8_n24AreaResponsavelId = new bool[] {false} ;
         T001C11_A75DocumentoId = new int[1] ;
         T001C12_A24AreaResponsavelId = new int[1] ;
         T001C12_n24AreaResponsavelId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.arearesponsavel__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arearesponsavel__default(),
            new Object[][] {
                new Object[] {
               T001C2_A24AreaResponsavelId, T001C2_A25AreaResponsavelNome, T001C2_A26AreaResponsavelAtivo
               }
               , new Object[] {
               T001C3_A24AreaResponsavelId, T001C3_A25AreaResponsavelNome, T001C3_A26AreaResponsavelAtivo
               }
               , new Object[] {
               T001C4_A24AreaResponsavelId, T001C4_A25AreaResponsavelNome, T001C4_A26AreaResponsavelAtivo
               }
               , new Object[] {
               T001C5_A24AreaResponsavelId
               }
               , new Object[] {
               T001C6_A24AreaResponsavelId
               }
               , new Object[] {
               T001C7_A24AreaResponsavelId
               }
               , new Object[] {
               T001C8_A24AreaResponsavelId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001C11_A75DocumentoId
               }
               , new Object[] {
               T001C12_A24AreaResponsavelId
               }
            }
         );
         Z26AreaResponsavelAtivo = true;
         A26AreaResponsavelAtivo = true;
         i26AreaResponsavelAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short GX_JID ;
      private short nIsDirty_8 ;
      private short gxajaxcallmode ;
      private int wcpOAV7AreaResponsavelId ;
      private int Z24AreaResponsavelId ;
      private int A24AreaResponsavelId ;
      private int AV7AreaResponsavelId ;
      private int AV15AreaResponsavelId_Out ;
      private int trnEnded ;
      private int edtAreaResponsavelNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtAreaResponsavelId_Enabled ;
      private int edtAreaResponsavelId_Visible ;
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
      private string edtAreaResponsavelNome_Internalname ;
      private string cmbAreaResponsavelAtivo_Internalname ;
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
      private string edtAreaResponsavelNome_Jsonclick ;
      private string cmbAreaResponsavelAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtAreaResponsavelId_Internalname ;
      private string edtAreaResponsavelId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode8 ;
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
      private bool Z26AreaResponsavelAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n24AreaResponsavelId ;
      private bool AV14IsAreaResponsavel ;
      private bool wbErr ;
      private bool A26AreaResponsavelAtivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV13IsOk ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i26AreaResponsavelAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV13IsOk ;
      private string Z25AreaResponsavelNome ;
      private string A25AreaResponsavelNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAreaResponsavelAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T001C4_A24AreaResponsavelId ;
      private bool[] T001C4_n24AreaResponsavelId ;
      private string[] T001C4_A25AreaResponsavelNome ;
      private bool[] T001C4_A26AreaResponsavelAtivo ;
      private int[] T001C5_A24AreaResponsavelId ;
      private bool[] T001C5_n24AreaResponsavelId ;
      private int[] T001C3_A24AreaResponsavelId ;
      private bool[] T001C3_n24AreaResponsavelId ;
      private string[] T001C3_A25AreaResponsavelNome ;
      private bool[] T001C3_A26AreaResponsavelAtivo ;
      private int[] T001C6_A24AreaResponsavelId ;
      private bool[] T001C6_n24AreaResponsavelId ;
      private int[] T001C7_A24AreaResponsavelId ;
      private bool[] T001C7_n24AreaResponsavelId ;
      private int[] T001C2_A24AreaResponsavelId ;
      private bool[] T001C2_n24AreaResponsavelId ;
      private string[] T001C2_A25AreaResponsavelNome ;
      private bool[] T001C2_A26AreaResponsavelAtivo ;
      private int[] T001C8_A24AreaResponsavelId ;
      private bool[] T001C8_n24AreaResponsavelId ;
      private int[] T001C11_A75DocumentoId ;
      private int[] T001C12_A24AreaResponsavelId ;
      private bool[] T001C12_n24AreaResponsavelId ;
      private bool aP2_IsAreaResponsavel ;
      private int aP3_AreaResponsavelId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class arearesponsavel__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class arearesponsavel__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001C4;
        prmT001C4 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C5;
        prmT001C5 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C3;
        prmT001C3 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C6;
        prmT001C6 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C7;
        prmT001C7 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C2;
        prmT001C2 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C8;
        prmT001C8 = new Object[] {
        new ParDef("@AreaResponsavelNome",GXType.NVarChar,100,0) ,
        new ParDef("@AreaResponsavelAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT001C9;
        prmT001C9 = new Object[] {
        new ParDef("@AreaResponsavelNome",GXType.NVarChar,100,0) ,
        new ParDef("@AreaResponsavelAtivo",GXType.Boolean,4,0) ,
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C10;
        prmT001C10 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C11;
        prmT001C11 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001C12;
        prmT001C12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001C2", "SELECT [AreaResponsavelId], [AreaResponsavelNome], [AreaResponsavelAtivo] FROM [AreaResponsavel] WITH (UPDLOCK) WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C3", "SELECT [AreaResponsavelId], [AreaResponsavelNome], [AreaResponsavelAtivo] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C4", "SELECT TM1.[AreaResponsavelId], TM1.[AreaResponsavelNome], TM1.[AreaResponsavelAtivo] FROM [AreaResponsavel] TM1 WHERE TM1.[AreaResponsavelId] = @AreaResponsavelId ORDER BY TM1.[AreaResponsavelId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C5", "SELECT [AreaResponsavelId] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C6", "SELECT TOP 1 [AreaResponsavelId] FROM [AreaResponsavel] WHERE ( [AreaResponsavelId] > @AreaResponsavelId) ORDER BY [AreaResponsavelId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C7", "SELECT TOP 1 [AreaResponsavelId] FROM [AreaResponsavel] WHERE ( [AreaResponsavelId] < @AreaResponsavelId) ORDER BY [AreaResponsavelId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C8", "INSERT INTO [AreaResponsavel]([AreaResponsavelNome], [AreaResponsavelAtivo]) VALUES(@AreaResponsavelNome, @AreaResponsavelAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001C8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C9", "UPDATE [AreaResponsavel] SET [AreaResponsavelNome]=@AreaResponsavelNome, [AreaResponsavelAtivo]=@AreaResponsavelAtivo  WHERE [AreaResponsavelId] = @AreaResponsavelId", GxErrorMask.GX_NOMASK,prmT001C9)
           ,new CursorDef("T001C10", "DELETE FROM [AreaResponsavel]  WHERE [AreaResponsavelId] = @AreaResponsavelId", GxErrorMask.GX_NOMASK,prmT001C10)
           ,new CursorDef("T001C11", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C12", "SELECT [AreaResponsavelId] FROM [AreaResponsavel] ORDER BY [AreaResponsavelId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C12,100, GxCacheFrequency.OFF ,true,false )
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
