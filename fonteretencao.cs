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
   public class fonteretencao : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A63FonteRetencaoId = (int)(NumberUtil.Val( GetPar( "FonteRetencaoId"), "."));
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            A64FonteRetencaoNome = GetPar( "FonteRetencaoNome");
            AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK0L21( A63FonteRetencaoId, A64FonteRetencaoNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "fonteretencao.aspx")), "fonteretencao.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "fonteretencao.aspx")))) ;
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
                  AV7FonteRetencaoId = (int)(NumberUtil.Val( GetPar( "FonteRetencaoId"), "."));
                  AssignAttri("", false, "AV7FonteRetencaoId", StringUtil.LTrimStr( (decimal)(AV7FonteRetencaoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFONTERETENCAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FonteRetencaoId), "ZZZZZZZ9"), context));
                  AV13IsFonteRetencao = StringUtil.StrToBool( GetPar( "IsFonteRetencao"));
                  AssignAttri("", false, "AV13IsFonteRetencao", AV13IsFonteRetencao);
                  AV14FonteRetencaoId_Out = (int)(NumberUtil.Val( GetPar( "FonteRetencaoId_Out"), "."));
                  AssignAttri("", false, "AV14FonteRetencaoId_Out", StringUtil.LTrimStr( (decimal)(AV14FonteRetencaoId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Fonte Retencao", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFonteRetencaoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public fonteretencao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public fonteretencao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FonteRetencaoId ,
                           out bool aP2_IsFonteRetencao ,
                           out int aP3_FonteRetencaoId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FonteRetencaoId = aP1_FonteRetencaoId;
         this.AV13IsFonteRetencao = false ;
         this.AV14FonteRetencaoId_Out = 0 ;
         executePrivate();
         aP2_IsFonteRetencao=this.AV13IsFonteRetencao;
         aP3_FonteRetencaoId_Out=this.AV14FonteRetencaoId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbFonteRetencaoAtivo = new GXCombobox();
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
            return "fonteretencao_Execute" ;
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
         if ( cmbFonteRetencaoAtivo.ItemCount > 0 )
         {
            A65FonteRetencaoAtivo = StringUtil.StrToBool( cmbFonteRetencaoAtivo.getValidValue(StringUtil.BoolToStr( A65FonteRetencaoAtivo)));
            AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFonteRetencaoAtivo.CurrentValue = StringUtil.BoolToStr( A65FonteRetencaoAtivo);
            AssignProp("", false, cmbFonteRetencaoAtivo_Internalname, "Values", cmbFonteRetencaoAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFonteRetencaoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFonteRetencaoNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFonteRetencaoNome_Internalname, A64FonteRetencaoNome, StringUtil.RTrim( context.localUtil.Format( A64FonteRetencaoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFonteRetencaoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFonteRetencaoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_FonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbFonteRetencaoAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbFonteRetencaoAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFonteRetencaoAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFonteRetencaoAtivo, cmbFonteRetencaoAtivo_Internalname, StringUtil.BoolToStr( A65FonteRetencaoAtivo), 1, cmbFonteRetencaoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbFonteRetencaoAtivo.Visible, cmbFonteRetencaoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_FonteRetencao.htm");
         cmbFonteRetencaoAtivo.CurrentValue = StringUtil.BoolToStr( A65FonteRetencaoAtivo);
         AssignProp("", false, cmbFonteRetencaoAtivo_Internalname, "Values", (string)(cmbFonteRetencaoAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FonteRetencao.htm");
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
         GxWebStd.gx_single_line_edit( context, edtFonteRetencaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63FonteRetencaoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtFonteRetencaoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A63FonteRetencaoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A63FonteRetencaoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFonteRetencaoId_Jsonclick, 0, "Attribute", "", "", "", "", edtFonteRetencaoId_Visible, edtFonteRetencaoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_FonteRetencao.htm");
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
         E110L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z63FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( "Z63FonteRetencaoId"), ",", "."));
               Z64FonteRetencaoNome = cgiGet( "Z64FonteRetencaoNome");
               Z65FonteRetencaoAtivo = StringUtil.StrToBool( cgiGet( "Z65FonteRetencaoAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( "vFONTERETENCAOID"), ",", "."));
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
               A64FonteRetencaoNome = cgiGet( edtFonteRetencaoNome_Internalname);
               AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
               cmbFonteRetencaoAtivo.CurrentValue = cgiGet( cmbFonteRetencaoAtivo_Internalname);
               A65FonteRetencaoAtivo = StringUtil.StrToBool( cgiGet( cmbFonteRetencaoAtivo_Internalname));
               AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
               A63FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( edtFonteRetencaoId_Internalname), ",", "."));
               AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"FonteRetencao");
               A63FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( edtFonteRetencaoId_Internalname), ",", "."));
               AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               forbiddenHiddens.Add("FonteRetencaoId", context.localUtil.Format( (decimal)(A63FonteRetencaoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("fonteretencao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A63FonteRetencaoId = (int)(NumberUtil.Val( GetPar( "FonteRetencaoId"), "."));
                  AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
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
                     sMode21 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode21;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound21 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FONTERETENCAOID");
                        AnyError = 1;
                        GX_FocusControl = edtFonteRetencaoId_Internalname;
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
                           E110L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120L2 ();
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
            E120L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0L21( ) ;
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
            DisableAttributes0L21( ) ;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L21( ) ;
            }
            else
            {
               CheckExtendedTable0L21( ) ;
               CloseExtendedTableCursors0L21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0L0( )
      {
      }

      protected void E110L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtFonteRetencaoId_Visible = 0;
         AssignProp("", false, edtFonteRetencaoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbFonteRetencaoAtivo.Visible = 0;
            AssignProp("", false, cmbFonteRetencaoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFonteRetencaoAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbFonteRetencaoAtivo.Visible = 1;
            AssignProp("", false, cmbFonteRetencaoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFonteRetencaoAtivo.Visible), 5, 0), true);
         }
      }

      protected void E120L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsFonteRetencao = true;
         AssignAttri("", false, "AV13IsFonteRetencao", AV13IsFonteRetencao);
         AV14FonteRetencaoId_Out = A63FonteRetencaoId;
         AssignAttri("", false, "AV14FonteRetencaoId_Out", StringUtil.LTrimStr( (decimal)(AV14FonteRetencaoId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("fonteretencaoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV13IsFonteRetencao,(int)AV14FonteRetencaoId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV13IsFonteRetencao","AV14FonteRetencaoId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0L21( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z64FonteRetencaoNome = T000L3_A64FonteRetencaoNome[0];
               Z65FonteRetencaoAtivo = T000L3_A65FonteRetencaoAtivo[0];
            }
            else
            {
               Z64FonteRetencaoNome = A64FonteRetencaoNome;
               Z65FonteRetencaoAtivo = A65FonteRetencaoAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z64FonteRetencaoNome = A64FonteRetencaoNome;
            Z65FonteRetencaoAtivo = A65FonteRetencaoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFonteRetencaoId_Enabled = 0;
         AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtFonteRetencaoId_Enabled = 0;
         AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FonteRetencaoId) )
         {
            A63FonteRetencaoId = AV7FonteRetencaoId;
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
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
         if ( IsIns( )  && (false==A65FonteRetencaoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A65FonteRetencaoAtivo = true;
            AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
         }
      }

      protected void Load0L21( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            A64FonteRetencaoNome = T000L4_A64FonteRetencaoNome[0];
            AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
            A65FonteRetencaoAtivo = T000L4_A65FonteRetencaoAtivo[0];
            AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
            ZM0L21( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0L21( ) ;
      }

      protected void OnLoadActions0L21( )
      {
         A64FonteRetencaoNome = StringUtil.Upper( A64FonteRetencaoNome);
         AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
      }

      protected void CheckExtendedTable0L21( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_21 = 1;
         A64FonteRetencaoNome = StringUtil.Upper( A64FonteRetencaoNome);
         AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A64FonteRetencaoNome)) )
         {
            GX_msglist.addItem("Informe o Nome da Fonte de Retenção.", 1, "FONTERETENCAONOME");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L21( )
      {
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L21( 8) ;
            RcdFound21 = 1;
            A63FonteRetencaoId = T000L3_A63FonteRetencaoId[0];
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            A64FonteRetencaoNome = T000L3_A64FonteRetencaoNome[0];
            AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
            A65FonteRetencaoAtivo = T000L3_A65FonteRetencaoAtivo[0];
            AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
            Z63FonteRetencaoId = A63FonteRetencaoId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0L21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0L21( ) ;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0L21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L21( ) ;
         if ( RcdFound21 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound21 = 0;
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A63FonteRetencaoId[0] < A63FonteRetencaoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A63FonteRetencaoId[0] > A63FonteRetencaoId ) ) )
            {
               A63FonteRetencaoId = T000L6_A63FonteRetencaoId[0];
               AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound21 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A63FonteRetencaoId[0] > A63FonteRetencaoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A63FonteRetencaoId[0] < A63FonteRetencaoId ) ) )
            {
               A63FonteRetencaoId = T000L7_A63FonteRetencaoId[0];
               AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFonteRetencaoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L21( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A63FonteRetencaoId != Z63FonteRetencaoId )
               {
                  A63FonteRetencaoId = Z63FonteRetencaoId;
                  AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FONTERETENCAOID");
                  AnyError = 1;
                  GX_FocusControl = edtFonteRetencaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFonteRetencaoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0L21( ) ;
                  GX_FocusControl = edtFonteRetencaoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A63FonteRetencaoId != Z63FonteRetencaoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFonteRetencaoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L21( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FONTERETENCAOID");
                     AnyError = 1;
                     GX_FocusControl = edtFonteRetencaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFonteRetencaoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L21( ) ;
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
         if ( A63FonteRetencaoId != Z63FonteRetencaoId )
         {
            A63FonteRetencaoId = Z63FonteRetencaoId;
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FONTERETENCAOID");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFonteRetencaoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0L21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A63FonteRetencaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FonteRetencao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z64FonteRetencaoNome, T000L2_A64FonteRetencaoNome[0]) != 0 ) || ( Z65FonteRetencaoAtivo != T000L2_A65FonteRetencaoAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z64FonteRetencaoNome, T000L2_A64FonteRetencaoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("fonteretencao:[seudo value changed for attri]"+"FonteRetencaoNome");
                  GXUtil.WriteLogRaw("Old: ",Z64FonteRetencaoNome);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A64FonteRetencaoNome[0]);
               }
               if ( Z65FonteRetencaoAtivo != T000L2_A65FonteRetencaoAtivo[0] )
               {
                  GXUtil.WriteLog("fonteretencao:[seudo value changed for attri]"+"FonteRetencaoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z65FonteRetencaoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A65FonteRetencaoAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FonteRetencao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L21( )
      {
         if ( ! IsAuthorized("fonteretencao_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L21( 0) ;
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L8 */
                     pr_default.execute(6, new Object[] {A64FonteRetencaoNome, A65FonteRetencaoAtivo});
                     A63FonteRetencaoId = T000L8_A63FonteRetencaoId[0];
                     AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("FonteRetencao");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L21( ) ;
            }
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void Update0L21( )
      {
         if ( ! IsAuthorized("fonteretencao_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L9 */
                     pr_default.execute(7, new Object[] {A64FonteRetencaoNome, A65FonteRetencaoAtivo, A63FonteRetencaoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("FonteRetencao");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FonteRetencao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L21( ) ;
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
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void DeferredUpdate0L21( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("fonteretencao_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L21( ) ;
            AfterConfirm0L21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L10 */
                  pr_default.execute(8, new Object[] {A63FonteRetencaoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("FonteRetencao");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L21( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
            AssignAttri("", false, "AV15IsOk", AV15IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000L11 */
            pr_default.execute(9, new Object[] {A63FonteRetencaoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Fonte Retencao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0L21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("fonteretencao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("fonteretencao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L21( )
      {
         /* Scan By routine */
         /* Using cursor T000L12 */
         pr_default.execute(10);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound21 = 1;
            A63FonteRetencaoId = T000L12_A63FonteRetencaoId[0];
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L21( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound21 = 1;
            A63FonteRetencaoId = T000L12_A63FonteRetencaoId[0];
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
         }
      }

      protected void ScanEnd0L21( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0L21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L21( )
      {
         edtFonteRetencaoNome_Enabled = 0;
         AssignProp("", false, edtFonteRetencaoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoNome_Enabled), 5, 0), true);
         cmbFonteRetencaoAtivo.Enabled = 0;
         AssignProp("", false, cmbFonteRetencaoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFonteRetencaoAtivo.Enabled), 5, 0), true);
         edtFonteRetencaoId_Enabled = 0;
         AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L21( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         GXEncryptionTmp = "fonteretencao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FonteRetencaoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV13IsFonteRetencao)) + "," + UrlEncode(StringUtil.LTrimStr(AV14FonteRetencaoId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("fonteretencao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"FonteRetencao");
         forbiddenHiddens.Add("FonteRetencaoId", context.localUtil.Format( (decimal)(A63FonteRetencaoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("fonteretencao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z63FonteRetencaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63FonteRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z64FonteRetencaoNome", Z64FonteRetencaoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z65FonteRetencaoAtivo", Z65FonteRetencaoAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISFONTERETENCAO", AV13IsFonteRetencao);
         GxWebStd.gx_hidden_field( context, "vFONTERETENCAOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14FonteRetencaoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vFONTERETENCAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FonteRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFONTERETENCAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FonteRetencaoId), "ZZZZZZZ9"), context));
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
         GXEncryptionTmp = "fonteretencao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FonteRetencaoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV13IsFonteRetencao)) + "," + UrlEncode(StringUtil.LTrimStr(AV14FonteRetencaoId_Out,8,0));
         return formatLink("fonteretencao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "FonteRetencao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Fonte Retencao" ;
      }

      protected void InitializeNonKey0L21( )
      {
         A64FonteRetencaoNome = "";
         AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
         AV15IsOk = false;
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
         A65FonteRetencaoAtivo = true;
         AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
         Z64FonteRetencaoNome = "";
         Z65FonteRetencaoAtivo = false;
      }

      protected void InitAll0L21( )
      {
         A63FonteRetencaoId = 0;
         AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
         InitializeNonKey0L21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A65FonteRetencaoAtivo = i65FonteRetencaoAtivo;
         AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910454983", true, true);
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
         context.AddJavascriptSource("fonteretencao.js", "?202311910454984", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFonteRetencaoNome_Internalname = "FONTERETENCAONOME";
         cmbFonteRetencaoAtivo_Internalname = "FONTERETENCAOATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtFonteRetencaoId_Internalname = "FONTERETENCAOID";
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
         Form.Caption = "Fonte Retencao";
         edtFonteRetencaoId_Jsonclick = "";
         edtFonteRetencaoId_Enabled = 0;
         edtFonteRetencaoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbFonteRetencaoAtivo_Jsonclick = "";
         cmbFonteRetencaoAtivo.Enabled = 1;
         cmbFonteRetencaoAtivo.Visible = 1;
         edtFonteRetencaoNome_Jsonclick = "";
         edtFonteRetencaoNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "FONTE DE RETENÇÃO";
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

      protected void GX4ASAISOK0L21( int A63FonteRetencaoId ,
                                     string A64FonteRetencaoNome )
      {
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
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
         cmbFonteRetencaoAtivo.Name = "FONTERETENCAOATIVO";
         cmbFonteRetencaoAtivo.WebTags = "";
         cmbFonteRetencaoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbFonteRetencaoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbFonteRetencaoAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A65FonteRetencaoAtivo) )
            {
               A65FonteRetencaoAtivo = true;
               AssignAttri("", false, "A65FonteRetencaoAtivo", A65FonteRetencaoAtivo);
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

      public void Valid_Fonteretencaonome( )
      {
         A64FonteRetencaoNome = StringUtil.Upper( A64FonteRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "FONTERETENCAONOME");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A64FonteRetencaoNome)) )
         {
            GX_msglist.addItem("Informe o Nome da Fonte de Retenção.", 1, "FONTERETENCAONOME");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A64FonteRetencaoNome", A64FonteRetencaoNome);
         AssignAttri("", false, "AV15IsOk", AV15IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FonteRetencaoId',fld:'vFONTERETENCAOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV13IsFonteRetencao',fld:'vISFONTERETENCAO',pic:''},{av:'AV14FonteRetencaoId_Out',fld:'vFONTERETENCAOID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FonteRetencaoId',fld:'vFONTERETENCAOID',pic:'ZZZZZZZ9',hsh:true},{av:'A63FonteRetencaoId',fld:'FONTERETENCAOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120L2',iparms:[{av:'A63FonteRetencaoId',fld:'FONTERETENCAOID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV13IsFonteRetencao',fld:'vISFONTERETENCAO',pic:''},{av:'AV14FonteRetencaoId_Out',fld:'vFONTERETENCAOID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_FONTERETENCAONOME","{handler:'Valid_Fonteretencaonome',iparms:[{av:'A64FonteRetencaoNome',fld:'FONTERETENCAONOME',pic:''},{av:'A63FonteRetencaoId',fld:'FONTERETENCAOID',pic:'ZZZZZZZ9'},{av:'AV15IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_FONTERETENCAONOME",",oparms:[{av:'A64FonteRetencaoNome',fld:'FONTERETENCAONOME',pic:''},{av:'AV15IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_FONTERETENCAOID","{handler:'Valid_Fonteretencaoid',iparms:[]");
         setEventMetadata("VALID_FONTERETENCAOID",",oparms:[]}");
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
         Z64FonteRetencaoNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A64FonteRetencaoNome = "";
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
         sMode21 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000L4_A63FonteRetencaoId = new int[1] ;
         T000L4_A64FonteRetencaoNome = new string[] {""} ;
         T000L4_A65FonteRetencaoAtivo = new bool[] {false} ;
         T000L5_A63FonteRetencaoId = new int[1] ;
         T000L3_A63FonteRetencaoId = new int[1] ;
         T000L3_A64FonteRetencaoNome = new string[] {""} ;
         T000L3_A65FonteRetencaoAtivo = new bool[] {false} ;
         T000L6_A63FonteRetencaoId = new int[1] ;
         T000L7_A63FonteRetencaoId = new int[1] ;
         T000L2_A63FonteRetencaoId = new int[1] ;
         T000L2_A64FonteRetencaoNome = new string[] {""} ;
         T000L2_A65FonteRetencaoAtivo = new bool[] {false} ;
         T000L8_A63FonteRetencaoId = new int[1] ;
         T000L11_A63FonteRetencaoId = new int[1] ;
         T000L11_A75DocumentoId = new int[1] ;
         T000L12_A63FonteRetencaoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.fonteretencao__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.fonteretencao__default(),
            new Object[][] {
                new Object[] {
               T000L2_A63FonteRetencaoId, T000L2_A64FonteRetencaoNome, T000L2_A65FonteRetencaoAtivo
               }
               , new Object[] {
               T000L3_A63FonteRetencaoId, T000L3_A64FonteRetencaoNome, T000L3_A65FonteRetencaoAtivo
               }
               , new Object[] {
               T000L4_A63FonteRetencaoId, T000L4_A64FonteRetencaoNome, T000L4_A65FonteRetencaoAtivo
               }
               , new Object[] {
               T000L5_A63FonteRetencaoId
               }
               , new Object[] {
               T000L6_A63FonteRetencaoId
               }
               , new Object[] {
               T000L7_A63FonteRetencaoId
               }
               , new Object[] {
               T000L8_A63FonteRetencaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L11_A63FonteRetencaoId, T000L11_A75DocumentoId
               }
               , new Object[] {
               T000L12_A63FonteRetencaoId
               }
            }
         );
         Z65FonteRetencaoAtivo = true;
         A65FonteRetencaoAtivo = true;
         i65FonteRetencaoAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound21 ;
      private short GX_JID ;
      private short nIsDirty_21 ;
      private short gxajaxcallmode ;
      private int wcpOAV7FonteRetencaoId ;
      private int Z63FonteRetencaoId ;
      private int A63FonteRetencaoId ;
      private int AV7FonteRetencaoId ;
      private int AV14FonteRetencaoId_Out ;
      private int trnEnded ;
      private int edtFonteRetencaoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtFonteRetencaoId_Enabled ;
      private int edtFonteRetencaoId_Visible ;
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
      private string edtFonteRetencaoNome_Internalname ;
      private string cmbFonteRetencaoAtivo_Internalname ;
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
      private string edtFonteRetencaoNome_Jsonclick ;
      private string cmbFonteRetencaoAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtFonteRetencaoId_Internalname ;
      private string edtFonteRetencaoId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode21 ;
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
      private bool Z65FonteRetencaoAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13IsFonteRetencao ;
      private bool wbErr ;
      private bool A65FonteRetencaoAtivo ;
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
      private bool i65FonteRetencaoAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV15IsOk ;
      private string Z64FonteRetencaoNome ;
      private string A64FonteRetencaoNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFonteRetencaoAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T000L4_A63FonteRetencaoId ;
      private string[] T000L4_A64FonteRetencaoNome ;
      private bool[] T000L4_A65FonteRetencaoAtivo ;
      private int[] T000L5_A63FonteRetencaoId ;
      private int[] T000L3_A63FonteRetencaoId ;
      private string[] T000L3_A64FonteRetencaoNome ;
      private bool[] T000L3_A65FonteRetencaoAtivo ;
      private int[] T000L6_A63FonteRetencaoId ;
      private int[] T000L7_A63FonteRetencaoId ;
      private int[] T000L2_A63FonteRetencaoId ;
      private string[] T000L2_A64FonteRetencaoNome ;
      private bool[] T000L2_A65FonteRetencaoAtivo ;
      private int[] T000L8_A63FonteRetencaoId ;
      private int[] T000L11_A63FonteRetencaoId ;
      private int[] T000L11_A75DocumentoId ;
      private int[] T000L12_A63FonteRetencaoId ;
      private bool aP2_IsFonteRetencao ;
      private int aP3_FonteRetencaoId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class fonteretencao__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class fonteretencao__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000L4;
        prmT000L4 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L5;
        prmT000L5 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L3;
        prmT000L3 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L6;
        prmT000L6 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L7;
        prmT000L7 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L2;
        prmT000L2 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L8;
        prmT000L8 = new Object[] {
        new ParDef("@FonteRetencaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FonteRetencaoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT000L9;
        prmT000L9 = new Object[] {
        new ParDef("@FonteRetencaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FonteRetencaoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L10;
        prmT000L10 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L11;
        prmT000L11 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT000L12;
        prmT000L12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000L2", "SELECT [FonteRetencaoId], [FonteRetencaoNome], [FonteRetencaoAtivo] FROM [FonteRetencao] WITH (UPDLOCK) WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L3", "SELECT [FonteRetencaoId], [FonteRetencaoNome], [FonteRetencaoAtivo] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L4", "SELECT TM1.[FonteRetencaoId], TM1.[FonteRetencaoNome], TM1.[FonteRetencaoAtivo] FROM [FonteRetencao] TM1 WHERE TM1.[FonteRetencaoId] = @FonteRetencaoId ORDER BY TM1.[FonteRetencaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L5", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L6", "SELECT TOP 1 [FonteRetencaoId] FROM [FonteRetencao] WHERE ( [FonteRetencaoId] > @FonteRetencaoId) ORDER BY [FonteRetencaoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L7", "SELECT TOP 1 [FonteRetencaoId] FROM [FonteRetencao] WHERE ( [FonteRetencaoId] < @FonteRetencaoId) ORDER BY [FonteRetencaoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L8", "INSERT INTO [FonteRetencao]([FonteRetencaoNome], [FonteRetencaoAtivo]) VALUES(@FonteRetencaoNome, @FonteRetencaoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000L8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L9", "UPDATE [FonteRetencao] SET [FonteRetencaoNome]=@FonteRetencaoNome, [FonteRetencaoAtivo]=@FonteRetencaoAtivo  WHERE [FonteRetencaoId] = @FonteRetencaoId", GxErrorMask.GX_NOMASK,prmT000L9)
           ,new CursorDef("T000L10", "DELETE FROM [FonteRetencao]  WHERE [FonteRetencaoId] = @FonteRetencaoId", GxErrorMask.GX_NOMASK,prmT000L10)
           ,new CursorDef("T000L11", "SELECT TOP 1 [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L12", "SELECT [FonteRetencaoId] FROM [FonteRetencao] ORDER BY [FonteRetencaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L12,100, GxCacheFrequency.OFF ,true,false )
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
