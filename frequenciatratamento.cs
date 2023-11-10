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
   public class frequenciatratamento : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A39FrequenciaTratamentoId = (int)(NumberUtil.Val( GetPar( "FrequenciaTratamentoId"), "."));
            n39FrequenciaTratamentoId = false;
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            A40FrequenciaTratamentoNome = GetPar( "FrequenciaTratamentoNome");
            AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK0D13( A39FrequenciaTratamentoId, A40FrequenciaTratamentoNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "frequenciatratamento.aspx")), "frequenciatratamento.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "frequenciatratamento.aspx")))) ;
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
                  AV7FrequenciaTratamentoId = (int)(NumberUtil.Val( GetPar( "FrequenciaTratamentoId"), "."));
                  AssignAttri("", false, "AV7FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV7FrequenciaTratamentoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFREQUENCIATRATAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FrequenciaTratamentoId), "ZZZZZZZ9"), context));
                  AV13IsFrequenciaTratamento = StringUtil.StrToBool( GetPar( "IsFrequenciaTratamento"));
                  AssignAttri("", false, "AV13IsFrequenciaTratamento", AV13IsFrequenciaTratamento);
                  AV14FrequenciaTratamentoId_Out = (int)(NumberUtil.Val( GetPar( "FrequenciaTratamentoId_Out"), "."));
                  AssignAttri("", false, "AV14FrequenciaTratamentoId_Out", StringUtil.LTrimStr( (decimal)(AV14FrequenciaTratamentoId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Frequencia Tratamento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public frequenciatratamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public frequenciatratamento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FrequenciaTratamentoId ,
                           out bool aP2_IsFrequenciaTratamento ,
                           out int aP3_FrequenciaTratamentoId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FrequenciaTratamentoId = aP1_FrequenciaTratamentoId;
         this.AV13IsFrequenciaTratamento = false ;
         this.AV14FrequenciaTratamentoId_Out = 0 ;
         executePrivate();
         aP2_IsFrequenciaTratamento=this.AV13IsFrequenciaTratamento;
         aP3_FrequenciaTratamentoId_Out=this.AV14FrequenciaTratamentoId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbFrequenciaTratamentoAtivo = new GXCombobox();
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
            return "frequenciatratamento_Execute" ;
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
         if ( cmbFrequenciaTratamentoAtivo.ItemCount > 0 )
         {
            A41FrequenciaTratamentoAtivo = StringUtil.StrToBool( cmbFrequenciaTratamentoAtivo.getValidValue(StringUtil.BoolToStr( A41FrequenciaTratamentoAtivo)));
            AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFrequenciaTratamentoAtivo.CurrentValue = StringUtil.BoolToStr( A41FrequenciaTratamentoAtivo);
            AssignProp("", false, cmbFrequenciaTratamentoAtivo_Internalname, "Values", cmbFrequenciaTratamentoAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFrequenciaTratamentoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFrequenciaTratamentoNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFrequenciaTratamentoNome_Internalname, A40FrequenciaTratamentoNome, StringUtil.RTrim( context.localUtil.Format( A40FrequenciaTratamentoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFrequenciaTratamentoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFrequenciaTratamentoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_FrequenciaTratamento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbFrequenciaTratamentoAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbFrequenciaTratamentoAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFrequenciaTratamentoAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFrequenciaTratamentoAtivo, cmbFrequenciaTratamentoAtivo_Internalname, StringUtil.BoolToStr( A41FrequenciaTratamentoAtivo), 1, cmbFrequenciaTratamentoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbFrequenciaTratamentoAtivo.Visible, cmbFrequenciaTratamentoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_FrequenciaTratamento.htm");
         cmbFrequenciaTratamentoAtivo.CurrentValue = StringUtil.BoolToStr( A41FrequenciaTratamentoAtivo);
         AssignProp("", false, cmbFrequenciaTratamentoAtivo_Internalname, "Values", (string)(cmbFrequenciaTratamentoAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FrequenciaTratamento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FrequenciaTratamento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FrequenciaTratamento.htm");
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
         GxWebStd.gx_single_line_edit( context, edtFrequenciaTratamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39FrequenciaTratamentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtFrequenciaTratamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A39FrequenciaTratamentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A39FrequenciaTratamentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFrequenciaTratamentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtFrequenciaTratamentoId_Visible, edtFrequenciaTratamentoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_FrequenciaTratamento.htm");
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
         E110D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z39FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( "Z39FrequenciaTratamentoId"), ",", "."));
               Z40FrequenciaTratamentoNome = cgiGet( "Z40FrequenciaTratamentoNome");
               Z41FrequenciaTratamentoAtivo = StringUtil.StrToBool( cgiGet( "Z41FrequenciaTratamentoAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( "vFREQUENCIATRATAMENTOID"), ",", "."));
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
               A40FrequenciaTratamentoNome = cgiGet( edtFrequenciaTratamentoNome_Internalname);
               AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
               cmbFrequenciaTratamentoAtivo.CurrentValue = cgiGet( cmbFrequenciaTratamentoAtivo_Internalname);
               A41FrequenciaTratamentoAtivo = StringUtil.StrToBool( cgiGet( cmbFrequenciaTratamentoAtivo_Internalname));
               AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
               A39FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( edtFrequenciaTratamentoId_Internalname), ",", "."));
               n39FrequenciaTratamentoId = false;
               AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"FrequenciaTratamento");
               A39FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( edtFrequenciaTratamentoId_Internalname), ",", "."));
               n39FrequenciaTratamentoId = false;
               AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
               forbiddenHiddens.Add("FrequenciaTratamentoId", context.localUtil.Format( (decimal)(A39FrequenciaTratamentoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("frequenciatratamento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A39FrequenciaTratamentoId = (int)(NumberUtil.Val( GetPar( "FrequenciaTratamentoId"), "."));
                  n39FrequenciaTratamentoId = false;
                  AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
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
                     sMode13 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode13;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound13 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FREQUENCIATRATAMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtFrequenciaTratamentoId_Internalname;
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
                           E110D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120D2 ();
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
            E120D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0D13( ) ;
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
            DisableAttributes0D13( ) ;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D13( ) ;
            }
            else
            {
               CheckExtendedTable0D13( ) ;
               CloseExtendedTableCursors0D13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0D0( )
      {
      }

      protected void E110D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtFrequenciaTratamentoId_Visible = 0;
         AssignProp("", false, edtFrequenciaTratamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFrequenciaTratamentoId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbFrequenciaTratamentoAtivo.Visible = 0;
            AssignProp("", false, cmbFrequenciaTratamentoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFrequenciaTratamentoAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbFrequenciaTratamentoAtivo.Visible = 1;
            AssignProp("", false, cmbFrequenciaTratamentoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFrequenciaTratamentoAtivo.Visible), 5, 0), true);
         }
      }

      protected void E120D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsFrequenciaTratamento = true;
         AssignAttri("", false, "AV13IsFrequenciaTratamento", AV13IsFrequenciaTratamento);
         AV14FrequenciaTratamentoId_Out = A39FrequenciaTratamentoId;
         AssignAttri("", false, "AV14FrequenciaTratamentoId_Out", StringUtil.LTrimStr( (decimal)(AV14FrequenciaTratamentoId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("frequenciatratamentoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV13IsFrequenciaTratamento,(int)AV14FrequenciaTratamentoId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV13IsFrequenciaTratamento","AV14FrequenciaTratamentoId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z40FrequenciaTratamentoNome = T000D3_A40FrequenciaTratamentoNome[0];
               Z41FrequenciaTratamentoAtivo = T000D3_A41FrequenciaTratamentoAtivo[0];
            }
            else
            {
               Z40FrequenciaTratamentoNome = A40FrequenciaTratamentoNome;
               Z41FrequenciaTratamentoAtivo = A41FrequenciaTratamentoAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            Z40FrequenciaTratamentoNome = A40FrequenciaTratamentoNome;
            Z41FrequenciaTratamentoAtivo = A41FrequenciaTratamentoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFrequenciaTratamentoId_Enabled = 0;
         AssignProp("", false, edtFrequenciaTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrequenciaTratamentoId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtFrequenciaTratamentoId_Enabled = 0;
         AssignProp("", false, edtFrequenciaTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrequenciaTratamentoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FrequenciaTratamentoId) )
         {
            A39FrequenciaTratamentoId = AV7FrequenciaTratamentoId;
            n39FrequenciaTratamentoId = false;
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
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
         if ( IsIns( )  && (false==A41FrequenciaTratamentoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A41FrequenciaTratamentoAtivo = true;
            AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
         }
      }

      protected void Load0D13( )
      {
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A40FrequenciaTratamentoNome = T000D4_A40FrequenciaTratamentoNome[0];
            AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
            A41FrequenciaTratamentoAtivo = T000D4_A41FrequenciaTratamentoAtivo[0];
            AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
            ZM0D13( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
         A40FrequenciaTratamentoNome = StringUtil.Upper( A40FrequenciaTratamentoNome);
         AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
      }

      protected void CheckExtendedTable0D13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_13 = 1;
         A40FrequenciaTratamentoNome = StringUtil.Upper( A40FrequenciaTratamentoNome);
         AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A40FrequenciaTratamentoNome)) )
         {
            GX_msglist.addItem("Informe o nome da Frequência de Tratamento.", 1, "FREQUENCIATRATAMENTONOME");
            AnyError = 1;
            GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0D13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D13( )
      {
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 8) ;
            RcdFound13 = 1;
            A39FrequenciaTratamentoId = T000D3_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = T000D3_n39FrequenciaTratamentoId[0];
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            A40FrequenciaTratamentoNome = T000D3_A40FrequenciaTratamentoNome[0];
            AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
            A41FrequenciaTratamentoAtivo = T000D3_A41FrequenciaTratamentoAtivo[0];
            AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0D13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0D13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D13( ) ;
         if ( RcdFound13 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000D6_A39FrequenciaTratamentoId[0] < A39FrequenciaTratamentoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000D6_A39FrequenciaTratamentoId[0] > A39FrequenciaTratamentoId ) ) )
            {
               A39FrequenciaTratamentoId = T000D6_A39FrequenciaTratamentoId[0];
               n39FrequenciaTratamentoId = T000D6_n39FrequenciaTratamentoId[0];
               AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000D7_A39FrequenciaTratamentoId[0] > A39FrequenciaTratamentoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000D7_A39FrequenciaTratamentoId[0] < A39FrequenciaTratamentoId ) ) )
            {
               A39FrequenciaTratamentoId = T000D7_A39FrequenciaTratamentoId[0];
               n39FrequenciaTratamentoId = T000D7_n39FrequenciaTratamentoId[0];
               AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
               {
                  A39FrequenciaTratamentoId = Z39FrequenciaTratamentoId;
                  n39FrequenciaTratamentoId = false;
                  AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FREQUENCIATRATAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtFrequenciaTratamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0D13( ) ;
                  GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D13( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FREQUENCIATRATAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtFrequenciaTratamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D13( ) ;
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
         if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
         {
            A39FrequenciaTratamentoId = Z39FrequenciaTratamentoId;
            n39FrequenciaTratamentoId = false;
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FREQUENCIATRATAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtFrequenciaTratamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FrequenciaTratamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z40FrequenciaTratamentoNome, T000D2_A40FrequenciaTratamentoNome[0]) != 0 ) || ( Z41FrequenciaTratamentoAtivo != T000D2_A41FrequenciaTratamentoAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z40FrequenciaTratamentoNome, T000D2_A40FrequenciaTratamentoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("frequenciatratamento:[seudo value changed for attri]"+"FrequenciaTratamentoNome");
                  GXUtil.WriteLogRaw("Old: ",Z40FrequenciaTratamentoNome);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A40FrequenciaTratamentoNome[0]);
               }
               if ( Z41FrequenciaTratamentoAtivo != T000D2_A41FrequenciaTratamentoAtivo[0] )
               {
                  GXUtil.WriteLog("frequenciatratamento:[seudo value changed for attri]"+"FrequenciaTratamentoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z41FrequenciaTratamentoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A41FrequenciaTratamentoAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FrequenciaTratamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         if ( ! IsAuthorized("frequenciatratamento_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D8 */
                     pr_default.execute(6, new Object[] {A40FrequenciaTratamentoNome, A41FrequenciaTratamentoAtivo});
                     A39FrequenciaTratamentoId = T000D8_A39FrequenciaTratamentoId[0];
                     n39FrequenciaTratamentoId = T000D8_n39FrequenciaTratamentoId[0];
                     AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("FrequenciaTratamento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         if ( ! IsAuthorized("frequenciatratamento_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D9 */
                     pr_default.execute(7, new Object[] {A40FrequenciaTratamentoNome, A41FrequenciaTratamentoAtivo, n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("FrequenciaTratamento");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FrequenciaTratamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("frequenciatratamento_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D10 */
                  pr_default.execute(8, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("FrequenciaTratamento");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
            AssignAttri("", false, "AV15IsOk", AV15IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000D11 */
            pr_default.execute(9, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("frequenciatratamento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("frequenciatratamento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D13( )
      {
         /* Scan By routine */
         /* Using cursor T000D12 */
         pr_default.execute(10);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound13 = 1;
            A39FrequenciaTratamentoId = T000D12_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = T000D12_n39FrequenciaTratamentoId[0];
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound13 = 1;
            A39FrequenciaTratamentoId = T000D12_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = T000D12_n39FrequenciaTratamentoId[0];
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         }
      }

      protected void ScanEnd0D13( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
         edtFrequenciaTratamentoNome_Enabled = 0;
         AssignProp("", false, edtFrequenciaTratamentoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrequenciaTratamentoNome_Enabled), 5, 0), true);
         cmbFrequenciaTratamentoAtivo.Enabled = 0;
         AssignProp("", false, cmbFrequenciaTratamentoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFrequenciaTratamentoAtivo.Enabled), 5, 0), true);
         edtFrequenciaTratamentoId_Enabled = 0;
         AssignProp("", false, edtFrequenciaTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrequenciaTratamentoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         GXEncryptionTmp = "frequenciatratamento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FrequenciaTratamentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV13IsFrequenciaTratamento)) + "," + UrlEncode(StringUtil.LTrimStr(AV14FrequenciaTratamentoId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("frequenciatratamento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"FrequenciaTratamento");
         forbiddenHiddens.Add("FrequenciaTratamentoId", context.localUtil.Format( (decimal)(A39FrequenciaTratamentoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("frequenciatratamento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z39FrequenciaTratamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39FrequenciaTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z40FrequenciaTratamentoNome", Z40FrequenciaTratamentoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z41FrequenciaTratamentoAtivo", Z41FrequenciaTratamentoAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISFREQUENCIATRATAMENTO", AV13IsFrequenciaTratamento);
         GxWebStd.gx_hidden_field( context, "vFREQUENCIATRATAMENTOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14FrequenciaTratamentoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vFREQUENCIATRATAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FrequenciaTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFREQUENCIATRATAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FrequenciaTratamentoId), "ZZZZZZZ9"), context));
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
         GXEncryptionTmp = "frequenciatratamento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FrequenciaTratamentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV13IsFrequenciaTratamento)) + "," + UrlEncode(StringUtil.LTrimStr(AV14FrequenciaTratamentoId_Out,8,0));
         return formatLink("frequenciatratamento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "FrequenciaTratamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Frequencia Tratamento" ;
      }

      protected void InitializeNonKey0D13( )
      {
         A40FrequenciaTratamentoNome = "";
         AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
         AV15IsOk = false;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         A41FrequenciaTratamentoAtivo = true;
         AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
         Z40FrequenciaTratamentoNome = "";
         Z41FrequenciaTratamentoAtivo = false;
      }

      protected void InitAll0D13( )
      {
         A39FrequenciaTratamentoId = 0;
         n39FrequenciaTratamentoId = false;
         AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         InitializeNonKey0D13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A41FrequenciaTratamentoAtivo = i41FrequenciaTratamentoAtivo;
         AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417263180", true, true);
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
         context.AddJavascriptSource("frequenciatratamento.js", "?202312417263180", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFrequenciaTratamentoNome_Internalname = "FREQUENCIATRATAMENTONOME";
         cmbFrequenciaTratamentoAtivo_Internalname = "FREQUENCIATRATAMENTOATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtFrequenciaTratamentoId_Internalname = "FREQUENCIATRATAMENTOID";
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
         Form.Caption = "Frequencia Tratamento";
         edtFrequenciaTratamentoId_Jsonclick = "";
         edtFrequenciaTratamentoId_Enabled = 0;
         edtFrequenciaTratamentoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbFrequenciaTratamentoAtivo_Jsonclick = "";
         cmbFrequenciaTratamentoAtivo.Enabled = 1;
         cmbFrequenciaTratamentoAtivo.Visible = 1;
         edtFrequenciaTratamentoNome_Jsonclick = "";
         edtFrequenciaTratamentoNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "FREQUÊNCIA DO TRATAMENTO";
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

      protected void GX4ASAISOK0D13( int A39FrequenciaTratamentoId ,
                                     string A40FrequenciaTratamentoNome )
      {
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
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
         cmbFrequenciaTratamentoAtivo.Name = "FREQUENCIATRATAMENTOATIVO";
         cmbFrequenciaTratamentoAtivo.WebTags = "";
         cmbFrequenciaTratamentoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbFrequenciaTratamentoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbFrequenciaTratamentoAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A41FrequenciaTratamentoAtivo) )
            {
               A41FrequenciaTratamentoAtivo = true;
               AssignAttri("", false, "A41FrequenciaTratamentoAtivo", A41FrequenciaTratamentoAtivo);
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

      public void Valid_Frequenciatratamentonome( )
      {
         n39FrequenciaTratamentoId = false;
         A40FrequenciaTratamentoNome = StringUtil.Upper( A40FrequenciaTratamentoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "FREQUENCIATRATAMENTONOME");
            AnyError = 1;
            GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A40FrequenciaTratamentoNome)) )
         {
            GX_msglist.addItem("Informe o nome da Frequência de Tratamento.", 1, "FREQUENCIATRATAMENTONOME");
            AnyError = 1;
            GX_FocusControl = edtFrequenciaTratamentoNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A40FrequenciaTratamentoNome", A40FrequenciaTratamentoNome);
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV13IsFrequenciaTratamento',fld:'vISFREQUENCIATRATAMENTO',pic:''},{av:'AV14FrequenciaTratamentoId_Out',fld:'vFREQUENCIATRATAMENTOID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120D2',iparms:[{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV13IsFrequenciaTratamento',fld:'vISFREQUENCIATRATAMENTO',pic:''},{av:'AV14FrequenciaTratamentoId_Out',fld:'vFREQUENCIATRATAMENTOID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_FREQUENCIATRATAMENTONOME","{handler:'Valid_Frequenciatratamentonome',iparms:[{av:'A40FrequenciaTratamentoNome',fld:'FREQUENCIATRATAMENTONOME',pic:''},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV15IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_FREQUENCIATRATAMENTONOME",",oparms:[{av:'A40FrequenciaTratamentoNome',fld:'FREQUENCIATRATAMENTONOME',pic:''},{av:'AV15IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_FREQUENCIATRATAMENTOID","{handler:'Valid_Frequenciatratamentoid',iparms:[]");
         setEventMetadata("VALID_FREQUENCIATRATAMENTOID",",oparms:[]}");
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
         Z40FrequenciaTratamentoNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A40FrequenciaTratamentoNome = "";
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
         sMode13 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000D4_A39FrequenciaTratamentoId = new int[1] ;
         T000D4_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D4_A40FrequenciaTratamentoNome = new string[] {""} ;
         T000D4_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         T000D5_A39FrequenciaTratamentoId = new int[1] ;
         T000D5_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D3_A39FrequenciaTratamentoId = new int[1] ;
         T000D3_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D3_A40FrequenciaTratamentoNome = new string[] {""} ;
         T000D3_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         T000D6_A39FrequenciaTratamentoId = new int[1] ;
         T000D6_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D7_A39FrequenciaTratamentoId = new int[1] ;
         T000D7_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D2_A39FrequenciaTratamentoId = new int[1] ;
         T000D2_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D2_A40FrequenciaTratamentoNome = new string[] {""} ;
         T000D2_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         T000D8_A39FrequenciaTratamentoId = new int[1] ;
         T000D8_n39FrequenciaTratamentoId = new bool[] {false} ;
         T000D11_A75DocumentoId = new int[1] ;
         T000D12_A39FrequenciaTratamentoId = new int[1] ;
         T000D12_n39FrequenciaTratamentoId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.frequenciatratamento__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frequenciatratamento__default(),
            new Object[][] {
                new Object[] {
               T000D2_A39FrequenciaTratamentoId, T000D2_A40FrequenciaTratamentoNome, T000D2_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               T000D3_A39FrequenciaTratamentoId, T000D3_A40FrequenciaTratamentoNome, T000D3_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               T000D4_A39FrequenciaTratamentoId, T000D4_A40FrequenciaTratamentoNome, T000D4_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               T000D5_A39FrequenciaTratamentoId
               }
               , new Object[] {
               T000D6_A39FrequenciaTratamentoId
               }
               , new Object[] {
               T000D7_A39FrequenciaTratamentoId
               }
               , new Object[] {
               T000D8_A39FrequenciaTratamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D11_A75DocumentoId
               }
               , new Object[] {
               T000D12_A39FrequenciaTratamentoId
               }
            }
         );
         Z41FrequenciaTratamentoAtivo = true;
         A41FrequenciaTratamentoAtivo = true;
         i41FrequenciaTratamentoAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound13 ;
      private short GX_JID ;
      private short nIsDirty_13 ;
      private short gxajaxcallmode ;
      private int wcpOAV7FrequenciaTratamentoId ;
      private int Z39FrequenciaTratamentoId ;
      private int A39FrequenciaTratamentoId ;
      private int AV7FrequenciaTratamentoId ;
      private int AV14FrequenciaTratamentoId_Out ;
      private int trnEnded ;
      private int edtFrequenciaTratamentoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtFrequenciaTratamentoId_Enabled ;
      private int edtFrequenciaTratamentoId_Visible ;
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
      private string edtFrequenciaTratamentoNome_Internalname ;
      private string cmbFrequenciaTratamentoAtivo_Internalname ;
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
      private string edtFrequenciaTratamentoNome_Jsonclick ;
      private string cmbFrequenciaTratamentoAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtFrequenciaTratamentoId_Internalname ;
      private string edtFrequenciaTratamentoId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode13 ;
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
      private bool Z41FrequenciaTratamentoAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n39FrequenciaTratamentoId ;
      private bool AV13IsFrequenciaTratamento ;
      private bool wbErr ;
      private bool A41FrequenciaTratamentoAtivo ;
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
      private bool i41FrequenciaTratamentoAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV15IsOk ;
      private string Z40FrequenciaTratamentoNome ;
      private string A40FrequenciaTratamentoNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFrequenciaTratamentoAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T000D4_A39FrequenciaTratamentoId ;
      private bool[] T000D4_n39FrequenciaTratamentoId ;
      private string[] T000D4_A40FrequenciaTratamentoNome ;
      private bool[] T000D4_A41FrequenciaTratamentoAtivo ;
      private int[] T000D5_A39FrequenciaTratamentoId ;
      private bool[] T000D5_n39FrequenciaTratamentoId ;
      private int[] T000D3_A39FrequenciaTratamentoId ;
      private bool[] T000D3_n39FrequenciaTratamentoId ;
      private string[] T000D3_A40FrequenciaTratamentoNome ;
      private bool[] T000D3_A41FrequenciaTratamentoAtivo ;
      private int[] T000D6_A39FrequenciaTratamentoId ;
      private bool[] T000D6_n39FrequenciaTratamentoId ;
      private int[] T000D7_A39FrequenciaTratamentoId ;
      private bool[] T000D7_n39FrequenciaTratamentoId ;
      private int[] T000D2_A39FrequenciaTratamentoId ;
      private bool[] T000D2_n39FrequenciaTratamentoId ;
      private string[] T000D2_A40FrequenciaTratamentoNome ;
      private bool[] T000D2_A41FrequenciaTratamentoAtivo ;
      private int[] T000D8_A39FrequenciaTratamentoId ;
      private bool[] T000D8_n39FrequenciaTratamentoId ;
      private int[] T000D11_A75DocumentoId ;
      private int[] T000D12_A39FrequenciaTratamentoId ;
      private bool[] T000D12_n39FrequenciaTratamentoId ;
      private bool aP2_IsFrequenciaTratamento ;
      private int aP3_FrequenciaTratamentoId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class frequenciatratamento__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class frequenciatratamento__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new ParDef("@FrequenciaTratamentoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FrequenciaTratamentoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new ParDef("@FrequenciaTratamentoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FrequenciaTratamentoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D11;
        prmT000D11 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000D12;
        prmT000D12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WITH (UPDLOCK) WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT TM1.[FrequenciaTratamentoId], TM1.[FrequenciaTratamentoNome], TM1.[FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] TM1 WHERE TM1.[FrequenciaTratamentoId] = @FrequenciaTratamentoId ORDER BY TM1.[FrequenciaTratamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT TOP 1 [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE ( [FrequenciaTratamentoId] > @FrequenciaTratamentoId) ORDER BY [FrequenciaTratamentoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D7", "SELECT TOP 1 [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE ( [FrequenciaTratamentoId] < @FrequenciaTratamentoId) ORDER BY [FrequenciaTratamentoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D8", "INSERT INTO [FrequenciaTratamento]([FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo]) VALUES(@FrequenciaTratamentoNome, @FrequenciaTratamentoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D9", "UPDATE [FrequenciaTratamento] SET [FrequenciaTratamentoNome]=@FrequenciaTratamentoNome, [FrequenciaTratamentoAtivo]=@FrequenciaTratamentoAtivo  WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId", GxErrorMask.GX_NOMASK,prmT000D9)
           ,new CursorDef("T000D10", "DELETE FROM [FrequenciaTratamento]  WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId", GxErrorMask.GX_NOMASK,prmT000D10)
           ,new CursorDef("T000D11", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D12", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] ORDER BY [FrequenciaTratamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D12,100, GxCacheFrequency.OFF ,true,false )
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
