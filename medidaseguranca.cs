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
   public class medidaseguranca : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A51MedidaSegurancaId = (int)(NumberUtil.Val( GetPar( "MedidaSegurancaId"), "."));
            AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
            A52MedidaSegurancaNome = GetPar( "MedidaSegurancaNome");
            AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK0H17( A51MedidaSegurancaId, A52MedidaSegurancaNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "medidaseguranca.aspx")), "medidaseguranca.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "medidaseguranca.aspx")))) ;
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
                  AV7MedidaSegurancaId = (int)(NumberUtil.Val( GetPar( "MedidaSegurancaId"), "."));
                  AssignAttri("", false, "AV7MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(AV7MedidaSegurancaId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMEDIDASEGURANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MedidaSegurancaId), "ZZZZZZZ9"), context));
                  AV13IsMedidaSeguranca = StringUtil.StrToBool( GetPar( "IsMedidaSeguranca"));
                  AssignAttri("", false, "AV13IsMedidaSeguranca", AV13IsMedidaSeguranca);
                  AV14MedidaSegurancaId_Out = (int)(NumberUtil.Val( GetPar( "MedidaSegurancaId_Out"), "."));
                  AssignAttri("", false, "AV14MedidaSegurancaId_Out", StringUtil.LTrimStr( (decimal)(AV14MedidaSegurancaId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Medida Seguranca", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMedidaSegurancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public medidaseguranca( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public medidaseguranca( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MedidaSegurancaId ,
                           out bool aP2_IsMedidaSeguranca ,
                           out int aP3_MedidaSegurancaId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MedidaSegurancaId = aP1_MedidaSegurancaId;
         this.AV13IsMedidaSeguranca = false ;
         this.AV14MedidaSegurancaId_Out = 0 ;
         executePrivate();
         aP2_IsMedidaSeguranca=this.AV13IsMedidaSeguranca;
         aP3_MedidaSegurancaId_Out=this.AV14MedidaSegurancaId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMedidaSegurancaAtivo = new GXCombobox();
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
            return "medidaseguranca_Execute" ;
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
         if ( cmbMedidaSegurancaAtivo.ItemCount > 0 )
         {
            A53MedidaSegurancaAtivo = StringUtil.StrToBool( cmbMedidaSegurancaAtivo.getValidValue(StringUtil.BoolToStr( A53MedidaSegurancaAtivo)));
            AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMedidaSegurancaAtivo.CurrentValue = StringUtil.BoolToStr( A53MedidaSegurancaAtivo);
            AssignProp("", false, cmbMedidaSegurancaAtivo_Internalname, "Values", cmbMedidaSegurancaAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMedidaSegurancaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaSegurancaNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaSegurancaNome_Internalname, A52MedidaSegurancaNome, StringUtil.RTrim( context.localUtil.Format( A52MedidaSegurancaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaSegurancaNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMedidaSegurancaNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_MedidaSeguranca.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbMedidaSegurancaAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMedidaSegurancaAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMedidaSegurancaAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMedidaSegurancaAtivo, cmbMedidaSegurancaAtivo_Internalname, StringUtil.BoolToStr( A53MedidaSegurancaAtivo), 1, cmbMedidaSegurancaAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbMedidaSegurancaAtivo.Visible, cmbMedidaSegurancaAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_MedidaSeguranca.htm");
         cmbMedidaSegurancaAtivo.CurrentValue = StringUtil.BoolToStr( A53MedidaSegurancaAtivo);
         AssignProp("", false, cmbMedidaSegurancaAtivo_Internalname, "Values", (string)(cmbMedidaSegurancaAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MedidaSeguranca.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MedidaSeguranca.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MedidaSeguranca.htm");
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
         GxWebStd.gx_single_line_edit( context, edtMedidaSegurancaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51MedidaSegurancaId), 8, 0, ",", "")), StringUtil.LTrim( ((edtMedidaSegurancaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A51MedidaSegurancaId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A51MedidaSegurancaId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaSegurancaId_Jsonclick, 0, "Attribute", "", "", "", "", edtMedidaSegurancaId_Visible, edtMedidaSegurancaId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_MedidaSeguranca.htm");
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
         E110H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z51MedidaSegurancaId = (int)(context.localUtil.CToN( cgiGet( "Z51MedidaSegurancaId"), ",", "."));
               Z52MedidaSegurancaNome = cgiGet( "Z52MedidaSegurancaNome");
               Z53MedidaSegurancaAtivo = StringUtil.StrToBool( cgiGet( "Z53MedidaSegurancaAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7MedidaSegurancaId = (int)(context.localUtil.CToN( cgiGet( "vMEDIDASEGURANCAID"), ",", "."));
               AV15IsOk = StringUtil.StrToBool( cgiGet( "vISOK"));
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
               A52MedidaSegurancaNome = cgiGet( edtMedidaSegurancaNome_Internalname);
               AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
               cmbMedidaSegurancaAtivo.CurrentValue = cgiGet( cmbMedidaSegurancaAtivo_Internalname);
               A53MedidaSegurancaAtivo = StringUtil.StrToBool( cgiGet( cmbMedidaSegurancaAtivo_Internalname));
               AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
               A51MedidaSegurancaId = (int)(context.localUtil.CToN( cgiGet( edtMedidaSegurancaId_Internalname), ",", "."));
               AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MedidaSeguranca");
               A51MedidaSegurancaId = (int)(context.localUtil.CToN( cgiGet( edtMedidaSegurancaId_Internalname), ",", "."));
               AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
               forbiddenHiddens.Add("MedidaSegurancaId", context.localUtil.Format( (decimal)(A51MedidaSegurancaId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A51MedidaSegurancaId != Z51MedidaSegurancaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("medidaseguranca:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A51MedidaSegurancaId = (int)(NumberUtil.Val( GetPar( "MedidaSegurancaId"), "."));
                  AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
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
                     sMode17 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode17;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound17 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MEDIDASEGURANCAID");
                        AnyError = 1;
                        GX_FocusControl = edtMedidaSegurancaId_Internalname;
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
                           E110H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120H2 ();
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
            E120H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0H17( ) ;
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
            DisableAttributes0H17( ) ;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H17( ) ;
            }
            else
            {
               CheckExtendedTable0H17( ) ;
               CloseExtendedTableCursors0H17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0H0( )
      {
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtMedidaSegurancaId_Visible = 0;
         AssignProp("", false, edtMedidaSegurancaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMedidaSegurancaId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbMedidaSegurancaAtivo.Visible = 0;
            AssignProp("", false, cmbMedidaSegurancaAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMedidaSegurancaAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbMedidaSegurancaAtivo.Visible = 1;
            AssignProp("", false, cmbMedidaSegurancaAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMedidaSegurancaAtivo.Visible), 5, 0), true);
         }
      }

      protected void E120H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsMedidaSeguranca = true;
         AssignAttri("", false, "AV13IsMedidaSeguranca", AV13IsMedidaSeguranca);
         AV14MedidaSegurancaId_Out = A51MedidaSegurancaId;
         AssignAttri("", false, "AV14MedidaSegurancaId_Out", StringUtil.LTrimStr( (decimal)(AV14MedidaSegurancaId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("medidasegurancaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV13IsMedidaSeguranca,(int)AV14MedidaSegurancaId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV13IsMedidaSeguranca","AV14MedidaSegurancaId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0H17( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z52MedidaSegurancaNome = T000H3_A52MedidaSegurancaNome[0];
               Z53MedidaSegurancaAtivo = T000H3_A53MedidaSegurancaAtivo[0];
            }
            else
            {
               Z52MedidaSegurancaNome = A52MedidaSegurancaNome;
               Z53MedidaSegurancaAtivo = A53MedidaSegurancaAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            Z52MedidaSegurancaNome = A52MedidaSegurancaNome;
            Z53MedidaSegurancaAtivo = A53MedidaSegurancaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMedidaSegurancaId_Enabled = 0;
         AssignProp("", false, edtMedidaSegurancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaSegurancaId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtMedidaSegurancaId_Enabled = 0;
         AssignProp("", false, edtMedidaSegurancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaSegurancaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MedidaSegurancaId) )
         {
            A51MedidaSegurancaId = AV7MedidaSegurancaId;
            AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
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
         if ( IsIns( )  && (false==A53MedidaSegurancaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A53MedidaSegurancaAtivo = true;
            AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
         }
      }

      protected void Load0H17( )
      {
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A52MedidaSegurancaNome = T000H4_A52MedidaSegurancaNome[0];
            AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
            A53MedidaSegurancaAtivo = T000H4_A53MedidaSegurancaAtivo[0];
            AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
            ZM0H17( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0H17( ) ;
      }

      protected void OnLoadActions0H17( )
      {
         A52MedidaSegurancaNome = StringUtil.Upper( A52MedidaSegurancaNome);
         AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
      }

      protected void CheckExtendedTable0H17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_17 = 1;
         A52MedidaSegurancaNome = StringUtil.Upper( A52MedidaSegurancaNome);
         AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A52MedidaSegurancaNome)) )
         {
            GX_msglist.addItem("Informe o Nome da Medida de Segurança.", 1, "MEDIDASEGURANCANOME");
            AnyError = 1;
            GX_FocusControl = edtMedidaSegurancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0H17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H17( )
      {
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H17( 8) ;
            RcdFound17 = 1;
            A51MedidaSegurancaId = T000H3_A51MedidaSegurancaId[0];
            AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
            A52MedidaSegurancaNome = T000H3_A52MedidaSegurancaNome[0];
            AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
            A53MedidaSegurancaAtivo = T000H3_A53MedidaSegurancaAtivo[0];
            AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0H17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0H17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H17( ) ;
         if ( RcdFound17 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound17 = 0;
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000H6_A51MedidaSegurancaId[0] < A51MedidaSegurancaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000H6_A51MedidaSegurancaId[0] > A51MedidaSegurancaId ) ) )
            {
               A51MedidaSegurancaId = T000H6_A51MedidaSegurancaId[0];
               AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000H7_A51MedidaSegurancaId[0] > A51MedidaSegurancaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000H7_A51MedidaSegurancaId[0] < A51MedidaSegurancaId ) ) )
            {
               A51MedidaSegurancaId = T000H7_A51MedidaSegurancaId[0];
               AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMedidaSegurancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
               {
                  A51MedidaSegurancaId = Z51MedidaSegurancaId;
                  AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MEDIDASEGURANCAID");
                  AnyError = 1;
                  GX_FocusControl = edtMedidaSegurancaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMedidaSegurancaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0H17( ) ;
                  GX_FocusControl = edtMedidaSegurancaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMedidaSegurancaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MEDIDASEGURANCAID");
                     AnyError = 1;
                     GX_FocusControl = edtMedidaSegurancaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMedidaSegurancaNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H17( ) ;
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
         if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
         {
            A51MedidaSegurancaId = Z51MedidaSegurancaId;
            AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MEDIDASEGURANCAID");
            AnyError = 1;
            GX_FocusControl = edtMedidaSegurancaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMedidaSegurancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0H17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A51MedidaSegurancaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MedidaSeguranca"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z52MedidaSegurancaNome, T000H2_A52MedidaSegurancaNome[0]) != 0 ) || ( Z53MedidaSegurancaAtivo != T000H2_A53MedidaSegurancaAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z52MedidaSegurancaNome, T000H2_A52MedidaSegurancaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("medidaseguranca:[seudo value changed for attri]"+"MedidaSegurancaNome");
                  GXUtil.WriteLogRaw("Old: ",Z52MedidaSegurancaNome);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A52MedidaSegurancaNome[0]);
               }
               if ( Z53MedidaSegurancaAtivo != T000H2_A53MedidaSegurancaAtivo[0] )
               {
                  GXUtil.WriteLog("medidaseguranca:[seudo value changed for attri]"+"MedidaSegurancaAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z53MedidaSegurancaAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A53MedidaSegurancaAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MedidaSeguranca"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H17( )
      {
         if ( ! IsAuthorized("medidaseguranca_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H17( 0) ;
            CheckOptimisticConcurrency0H17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H8 */
                     pr_default.execute(6, new Object[] {A52MedidaSegurancaNome, A53MedidaSegurancaAtivo});
                     A51MedidaSegurancaId = T000H8_A51MedidaSegurancaId[0];
                     AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("MedidaSeguranca");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0H0( ) ;
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
               Load0H17( ) ;
            }
            EndLevel0H17( ) ;
         }
         CloseExtendedTableCursors0H17( ) ;
      }

      protected void Update0H17( )
      {
         if ( ! IsAuthorized("medidaseguranca_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H9 */
                     pr_default.execute(7, new Object[] {A52MedidaSegurancaNome, A53MedidaSegurancaAtivo, A51MedidaSegurancaId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("MedidaSeguranca");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MedidaSeguranca"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H17( ) ;
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
            EndLevel0H17( ) ;
         }
         CloseExtendedTableCursors0H17( ) ;
      }

      protected void DeferredUpdate0H17( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("medidaseguranca_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H17( ) ;
            AfterConfirm0H17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H10 */
                  pr_default.execute(8, new Object[] {A51MedidaSegurancaId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("MedidaSeguranca");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
            AssignAttri("", false, "AV15IsOk", AV15IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000H11 */
            pr_default.execute(9, new Object[] {A51MedidaSegurancaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DocMedidaSeguranca"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0H17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("medidaseguranca",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("medidaseguranca",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H17( )
      {
         /* Scan By routine */
         /* Using cursor T000H12 */
         pr_default.execute(10);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound17 = 1;
            A51MedidaSegurancaId = T000H12_A51MedidaSegurancaId[0];
            AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H17( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound17 = 1;
            A51MedidaSegurancaId = T000H12_A51MedidaSegurancaId[0];
            AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
         }
      }

      protected void ScanEnd0H17( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0H17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H17( )
      {
         edtMedidaSegurancaNome_Enabled = 0;
         AssignProp("", false, edtMedidaSegurancaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaSegurancaNome_Enabled), 5, 0), true);
         cmbMedidaSegurancaAtivo.Enabled = 0;
         AssignProp("", false, cmbMedidaSegurancaAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMedidaSegurancaAtivo.Enabled), 5, 0), true);
         edtMedidaSegurancaId_Enabled = 0;
         AssignProp("", false, edtMedidaSegurancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaSegurancaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
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
         GXEncryptionTmp = "medidaseguranca.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MedidaSegurancaId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV13IsMedidaSeguranca)) + "," + UrlEncode(StringUtil.LTrimStr(AV14MedidaSegurancaId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("medidaseguranca.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MedidaSeguranca");
         forbiddenHiddens.Add("MedidaSegurancaId", context.localUtil.Format( (decimal)(A51MedidaSegurancaId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("medidaseguranca:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z51MedidaSegurancaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51MedidaSegurancaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z52MedidaSegurancaNome", Z52MedidaSegurancaNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z53MedidaSegurancaAtivo", Z53MedidaSegurancaAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISMEDIDASEGURANCA", AV13IsMedidaSeguranca);
         GxWebStd.gx_hidden_field( context, "vMEDIDASEGURANCAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14MedidaSegurancaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMEDIDASEGURANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MedidaSegurancaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMEDIDASEGURANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MedidaSegurancaId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV15IsOk);
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
         GXEncryptionTmp = "medidaseguranca.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MedidaSegurancaId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV13IsMedidaSeguranca)) + "," + UrlEncode(StringUtil.LTrimStr(AV14MedidaSegurancaId_Out,8,0));
         return formatLink("medidaseguranca.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "MedidaSeguranca" ;
      }

      public override string GetPgmdesc( )
      {
         return "Medida Seguranca" ;
      }

      protected void InitializeNonKey0H17( )
      {
         A52MedidaSegurancaNome = "";
         AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
         AV15IsOk = false;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         A53MedidaSegurancaAtivo = true;
         AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
         Z52MedidaSegurancaNome = "";
         Z53MedidaSegurancaAtivo = false;
      }

      protected void InitAll0H17( )
      {
         A51MedidaSegurancaId = 0;
         AssignAttri("", false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
         InitializeNonKey0H17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A53MedidaSegurancaAtivo = i53MedidaSegurancaAtivo;
         AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910454647", true, true);
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
         context.AddJavascriptSource("medidaseguranca.js", "?202311910454647", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMedidaSegurancaNome_Internalname = "MEDIDASEGURANCANOME";
         cmbMedidaSegurancaAtivo_Internalname = "MEDIDASEGURANCAATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtMedidaSegurancaId_Internalname = "MEDIDASEGURANCAID";
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
         Form.Caption = "Medida Seguranca";
         edtMedidaSegurancaId_Jsonclick = "";
         edtMedidaSegurancaId_Enabled = 0;
         edtMedidaSegurancaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbMedidaSegurancaAtivo_Jsonclick = "";
         cmbMedidaSegurancaAtivo.Enabled = 1;
         cmbMedidaSegurancaAtivo.Visible = 1;
         edtMedidaSegurancaNome_Jsonclick = "";
         edtMedidaSegurancaNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "MEDIDAS DE SEGURANÇA";
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

      protected void GX4ASAISOK0H17( int A51MedidaSegurancaId ,
                                     string A52MedidaSegurancaNome )
      {
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV15IsOk))+"\"") ;
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
         cmbMedidaSegurancaAtivo.Name = "MEDIDASEGURANCAATIVO";
         cmbMedidaSegurancaAtivo.WebTags = "";
         cmbMedidaSegurancaAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbMedidaSegurancaAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbMedidaSegurancaAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A53MedidaSegurancaAtivo) )
            {
               A53MedidaSegurancaAtivo = true;
               AssignAttri("", false, "A53MedidaSegurancaAtivo", A53MedidaSegurancaAtivo);
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

      public void Valid_Medidasegurancanome( )
      {
         A52MedidaSegurancaNome = StringUtil.Upper( A52MedidaSegurancaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "MEDIDASEGURANCANOME");
            AnyError = 1;
            GX_FocusControl = edtMedidaSegurancaNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A52MedidaSegurancaNome)) )
         {
            GX_msglist.addItem("Informe o Nome da Medida de Segurança.", 1, "MEDIDASEGURANCANOME");
            AnyError = 1;
            GX_FocusControl = edtMedidaSegurancaNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A52MedidaSegurancaNome", A52MedidaSegurancaNome);
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MedidaSegurancaId',fld:'vMEDIDASEGURANCAID',pic:'ZZZZZZZ9',hsh:true},{av:'AV13IsMedidaSeguranca',fld:'vISMEDIDASEGURANCA',pic:''},{av:'AV14MedidaSegurancaId_Out',fld:'vMEDIDASEGURANCAID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MedidaSegurancaId',fld:'vMEDIDASEGURANCAID',pic:'ZZZZZZZ9',hsh:true},{av:'A51MedidaSegurancaId',fld:'MEDIDASEGURANCAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120H2',iparms:[{av:'A51MedidaSegurancaId',fld:'MEDIDASEGURANCAID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV13IsMedidaSeguranca',fld:'vISMEDIDASEGURANCA',pic:''},{av:'AV14MedidaSegurancaId_Out',fld:'vMEDIDASEGURANCAID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_MEDIDASEGURANCANOME","{handler:'Valid_Medidasegurancanome',iparms:[{av:'A52MedidaSegurancaNome',fld:'MEDIDASEGURANCANOME',pic:''},{av:'A51MedidaSegurancaId',fld:'MEDIDASEGURANCAID',pic:'ZZZZZZZ9'},{av:'AV15IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_MEDIDASEGURANCANOME",",oparms:[{av:'A52MedidaSegurancaNome',fld:'MEDIDASEGURANCANOME',pic:''},{av:'AV15IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_MEDIDASEGURANCAID","{handler:'Valid_Medidasegurancaid',iparms:[]");
         setEventMetadata("VALID_MEDIDASEGURANCAID",",oparms:[]}");
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
         Z52MedidaSegurancaNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A52MedidaSegurancaNome = "";
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
         sMode17 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000H4_A51MedidaSegurancaId = new int[1] ;
         T000H4_A52MedidaSegurancaNome = new string[] {""} ;
         T000H4_A53MedidaSegurancaAtivo = new bool[] {false} ;
         T000H5_A51MedidaSegurancaId = new int[1] ;
         T000H3_A51MedidaSegurancaId = new int[1] ;
         T000H3_A52MedidaSegurancaNome = new string[] {""} ;
         T000H3_A53MedidaSegurancaAtivo = new bool[] {false} ;
         T000H6_A51MedidaSegurancaId = new int[1] ;
         T000H7_A51MedidaSegurancaId = new int[1] ;
         T000H2_A51MedidaSegurancaId = new int[1] ;
         T000H2_A52MedidaSegurancaNome = new string[] {""} ;
         T000H2_A53MedidaSegurancaAtivo = new bool[] {false} ;
         T000H8_A51MedidaSegurancaId = new int[1] ;
         T000H11_A51MedidaSegurancaId = new int[1] ;
         T000H11_A75DocumentoId = new int[1] ;
         T000H12_A51MedidaSegurancaId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.medidaseguranca__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.medidaseguranca__default(),
            new Object[][] {
                new Object[] {
               T000H2_A51MedidaSegurancaId, T000H2_A52MedidaSegurancaNome, T000H2_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               T000H3_A51MedidaSegurancaId, T000H3_A52MedidaSegurancaNome, T000H3_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               T000H4_A51MedidaSegurancaId, T000H4_A52MedidaSegurancaNome, T000H4_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               T000H5_A51MedidaSegurancaId
               }
               , new Object[] {
               T000H6_A51MedidaSegurancaId
               }
               , new Object[] {
               T000H7_A51MedidaSegurancaId
               }
               , new Object[] {
               T000H8_A51MedidaSegurancaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H11_A51MedidaSegurancaId, T000H11_A75DocumentoId
               }
               , new Object[] {
               T000H12_A51MedidaSegurancaId
               }
            }
         );
         Z53MedidaSegurancaAtivo = true;
         A53MedidaSegurancaAtivo = true;
         i53MedidaSegurancaAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short GX_JID ;
      private short nIsDirty_17 ;
      private short gxajaxcallmode ;
      private int wcpOAV7MedidaSegurancaId ;
      private int Z51MedidaSegurancaId ;
      private int A51MedidaSegurancaId ;
      private int AV7MedidaSegurancaId ;
      private int AV14MedidaSegurancaId_Out ;
      private int trnEnded ;
      private int edtMedidaSegurancaNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtMedidaSegurancaId_Enabled ;
      private int edtMedidaSegurancaId_Visible ;
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
      private string edtMedidaSegurancaNome_Internalname ;
      private string cmbMedidaSegurancaAtivo_Internalname ;
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
      private string edtMedidaSegurancaNome_Jsonclick ;
      private string cmbMedidaSegurancaAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMedidaSegurancaId_Internalname ;
      private string edtMedidaSegurancaId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode17 ;
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
      private bool Z53MedidaSegurancaAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13IsMedidaSeguranca ;
      private bool wbErr ;
      private bool A53MedidaSegurancaAtivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV15IsOk ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i53MedidaSegurancaAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV15IsOk ;
      private string Z52MedidaSegurancaNome ;
      private string A52MedidaSegurancaNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMedidaSegurancaAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T000H4_A51MedidaSegurancaId ;
      private string[] T000H4_A52MedidaSegurancaNome ;
      private bool[] T000H4_A53MedidaSegurancaAtivo ;
      private int[] T000H5_A51MedidaSegurancaId ;
      private int[] T000H3_A51MedidaSegurancaId ;
      private string[] T000H3_A52MedidaSegurancaNome ;
      private bool[] T000H3_A53MedidaSegurancaAtivo ;
      private int[] T000H6_A51MedidaSegurancaId ;
      private int[] T000H7_A51MedidaSegurancaId ;
      private int[] T000H2_A51MedidaSegurancaId ;
      private string[] T000H2_A52MedidaSegurancaNome ;
      private bool[] T000H2_A53MedidaSegurancaAtivo ;
      private int[] T000H8_A51MedidaSegurancaId ;
      private int[] T000H11_A51MedidaSegurancaId ;
      private int[] T000H11_A75DocumentoId ;
      private int[] T000H12_A51MedidaSegurancaId ;
      private bool aP2_IsMedidaSeguranca ;
      private int aP3_MedidaSegurancaId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class medidaseguranca__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class medidaseguranca__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000H4;
        prmT000H4 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H5;
        prmT000H5 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H3;
        prmT000H3 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H6;
        prmT000H6 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H7;
        prmT000H7 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H2;
        prmT000H2 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H8;
        prmT000H8 = new Object[] {
        new ParDef("@MedidaSegurancaNome",GXType.NVarChar,100,0) ,
        new ParDef("@MedidaSegurancaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT000H9;
        prmT000H9 = new Object[] {
        new ParDef("@MedidaSegurancaNome",GXType.NVarChar,100,0) ,
        new ParDef("@MedidaSegurancaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H10;
        prmT000H10 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H11;
        prmT000H11 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmT000H12;
        prmT000H12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000H2", "SELECT [MedidaSegurancaId], [MedidaSegurancaNome], [MedidaSegurancaAtivo] FROM [MedidaSeguranca] WITH (UPDLOCK) WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H3", "SELECT [MedidaSegurancaId], [MedidaSegurancaNome], [MedidaSegurancaAtivo] FROM [MedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H4", "SELECT TM1.[MedidaSegurancaId], TM1.[MedidaSegurancaNome], TM1.[MedidaSegurancaAtivo] FROM [MedidaSeguranca] TM1 WHERE TM1.[MedidaSegurancaId] = @MedidaSegurancaId ORDER BY TM1.[MedidaSegurancaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H5", "SELECT [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H6", "SELECT TOP 1 [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE ( [MedidaSegurancaId] > @MedidaSegurancaId) ORDER BY [MedidaSegurancaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H7", "SELECT TOP 1 [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE ( [MedidaSegurancaId] < @MedidaSegurancaId) ORDER BY [MedidaSegurancaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H8", "INSERT INTO [MedidaSeguranca]([MedidaSegurancaNome], [MedidaSegurancaAtivo]) VALUES(@MedidaSegurancaNome, @MedidaSegurancaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H9", "UPDATE [MedidaSeguranca] SET [MedidaSegurancaNome]=@MedidaSegurancaNome, [MedidaSegurancaAtivo]=@MedidaSegurancaAtivo  WHERE [MedidaSegurancaId] = @MedidaSegurancaId", GxErrorMask.GX_NOMASK,prmT000H9)
           ,new CursorDef("T000H10", "DELETE FROM [MedidaSeguranca]  WHERE [MedidaSegurancaId] = @MedidaSegurancaId", GxErrorMask.GX_NOMASK,prmT000H10)
           ,new CursorDef("T000H11", "SELECT TOP 1 [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H12", "SELECT [MedidaSegurancaId] FROM [MedidaSeguranca] ORDER BY [MedidaSegurancaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H12,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
