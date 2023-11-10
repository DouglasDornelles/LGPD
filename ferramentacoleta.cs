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
   public class ferramentacoleta : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A33FerramentaColetaId = (int)(NumberUtil.Val( GetPar( "FerramentaColetaId"), "."));
            n33FerramentaColetaId = false;
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            A34FerramentaColetaNome = GetPar( "FerramentaColetaNome");
            AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK0B11( A33FerramentaColetaId, A34FerramentaColetaNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "ferramentacoleta.aspx")), "ferramentacoleta.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "ferramentacoleta.aspx")))) ;
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
                  AV7FerramentaColetaId = (int)(NumberUtil.Val( GetPar( "FerramentaColetaId"), "."));
                  AssignAttri("", false, "AV7FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV7FerramentaColetaId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFERRAMENTACOLETAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FerramentaColetaId), "ZZZZZZZ9"), context));
                  AV14IsFerramentaColeta = StringUtil.StrToBool( GetPar( "IsFerramentaColeta"));
                  AssignAttri("", false, "AV14IsFerramentaColeta", AV14IsFerramentaColeta);
                  AV15FerramentaColetaId_Out = (int)(NumberUtil.Val( GetPar( "FerramentaColetaId_Out"), "."));
                  AssignAttri("", false, "AV15FerramentaColetaId_Out", StringUtil.LTrimStr( (decimal)(AV15FerramentaColetaId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Ferramenta Coleta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFerramentaColetaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ferramentacoleta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public ferramentacoleta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FerramentaColetaId ,
                           out bool aP2_IsFerramentaColeta ,
                           out int aP3_FerramentaColetaId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FerramentaColetaId = aP1_FerramentaColetaId;
         this.AV14IsFerramentaColeta = false ;
         this.AV15FerramentaColetaId_Out = 0 ;
         executePrivate();
         aP2_IsFerramentaColeta=this.AV14IsFerramentaColeta;
         aP3_FerramentaColetaId_Out=this.AV15FerramentaColetaId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbFerramentaColetaAtivo = new GXCombobox();
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
            return "ferramentacoleta_Execute" ;
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
         if ( cmbFerramentaColetaAtivo.ItemCount > 0 )
         {
            A35FerramentaColetaAtivo = StringUtil.StrToBool( cmbFerramentaColetaAtivo.getValidValue(StringUtil.BoolToStr( A35FerramentaColetaAtivo)));
            AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFerramentaColetaAtivo.CurrentValue = StringUtil.BoolToStr( A35FerramentaColetaAtivo);
            AssignProp("", false, cmbFerramentaColetaAtivo_Internalname, "Values", cmbFerramentaColetaAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFerramentaColetaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFerramentaColetaNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFerramentaColetaNome_Internalname, A34FerramentaColetaNome, StringUtil.RTrim( context.localUtil.Format( A34FerramentaColetaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFerramentaColetaNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFerramentaColetaNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_FerramentaColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbFerramentaColetaAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbFerramentaColetaAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFerramentaColetaAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFerramentaColetaAtivo, cmbFerramentaColetaAtivo_Internalname, StringUtil.BoolToStr( A35FerramentaColetaAtivo), 1, cmbFerramentaColetaAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbFerramentaColetaAtivo.Visible, cmbFerramentaColetaAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_FerramentaColeta.htm");
         cmbFerramentaColetaAtivo.CurrentValue = StringUtil.BoolToStr( A35FerramentaColetaAtivo);
         AssignProp("", false, cmbFerramentaColetaAtivo_Internalname, "Values", (string)(cmbFerramentaColetaAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FerramentaColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FerramentaColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FerramentaColeta.htm");
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
         GxWebStd.gx_single_line_edit( context, edtFerramentaColetaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FerramentaColetaId), 8, 0, ",", "")), StringUtil.LTrim( ((edtFerramentaColetaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A33FerramentaColetaId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A33FerramentaColetaId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFerramentaColetaId_Jsonclick, 0, "Attribute", "", "", "", "", edtFerramentaColetaId_Visible, edtFerramentaColetaId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_FerramentaColeta.htm");
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
         E110B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z33FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( "Z33FerramentaColetaId"), ",", "."));
               Z34FerramentaColetaNome = cgiGet( "Z34FerramentaColetaNome");
               Z35FerramentaColetaAtivo = StringUtil.StrToBool( cgiGet( "Z35FerramentaColetaAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( "vFERRAMENTACOLETAID"), ",", "."));
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
               A34FerramentaColetaNome = cgiGet( edtFerramentaColetaNome_Internalname);
               AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
               cmbFerramentaColetaAtivo.CurrentValue = cgiGet( cmbFerramentaColetaAtivo_Internalname);
               A35FerramentaColetaAtivo = StringUtil.StrToBool( cgiGet( cmbFerramentaColetaAtivo_Internalname));
               AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
               A33FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( edtFerramentaColetaId_Internalname), ",", "."));
               n33FerramentaColetaId = false;
               AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"FerramentaColeta");
               A33FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( edtFerramentaColetaId_Internalname), ",", "."));
               n33FerramentaColetaId = false;
               AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
               forbiddenHiddens.Add("FerramentaColetaId", context.localUtil.Format( (decimal)(A33FerramentaColetaId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A33FerramentaColetaId != Z33FerramentaColetaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("ferramentacoleta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A33FerramentaColetaId = (int)(NumberUtil.Val( GetPar( "FerramentaColetaId"), "."));
                  n33FerramentaColetaId = false;
                  AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
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
                     sMode11 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode11;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound11 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FERRAMENTACOLETAID");
                        AnyError = 1;
                        GX_FocusControl = edtFerramentaColetaId_Internalname;
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
                           E110B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120B2 ();
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
            E120B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0B11( ) ;
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
            DisableAttributes0B11( ) ;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B11( ) ;
            }
            else
            {
               CheckExtendedTable0B11( ) ;
               CloseExtendedTableCursors0B11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void E110B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtFerramentaColetaId_Visible = 0;
         AssignProp("", false, edtFerramentaColetaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFerramentaColetaId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbFerramentaColetaAtivo.Visible = 0;
            AssignProp("", false, cmbFerramentaColetaAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFerramentaColetaAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbFerramentaColetaAtivo.Visible = 1;
            AssignProp("", false, cmbFerramentaColetaAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFerramentaColetaAtivo.Visible), 5, 0), true);
         }
      }

      protected void E120B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsFerramentaColeta = true;
         AssignAttri("", false, "AV14IsFerramentaColeta", AV14IsFerramentaColeta);
         AV15FerramentaColetaId_Out = A33FerramentaColetaId;
         AssignAttri("", false, "AV15FerramentaColetaId_Out", StringUtil.LTrimStr( (decimal)(AV15FerramentaColetaId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("ferramentacoletaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV14IsFerramentaColeta,(int)AV15FerramentaColetaId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV14IsFerramentaColeta","AV15FerramentaColetaId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34FerramentaColetaNome = T000B3_A34FerramentaColetaNome[0];
               Z35FerramentaColetaAtivo = T000B3_A35FerramentaColetaAtivo[0];
            }
            else
            {
               Z34FerramentaColetaNome = A34FerramentaColetaNome;
               Z35FerramentaColetaAtivo = A35FerramentaColetaAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z33FerramentaColetaId = A33FerramentaColetaId;
            Z34FerramentaColetaNome = A34FerramentaColetaNome;
            Z35FerramentaColetaAtivo = A35FerramentaColetaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFerramentaColetaId_Enabled = 0;
         AssignProp("", false, edtFerramentaColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFerramentaColetaId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtFerramentaColetaId_Enabled = 0;
         AssignProp("", false, edtFerramentaColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFerramentaColetaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FerramentaColetaId) )
         {
            A33FerramentaColetaId = AV7FerramentaColetaId;
            n33FerramentaColetaId = false;
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
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
         if ( IsIns( )  && (false==A35FerramentaColetaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A35FerramentaColetaAtivo = true;
            AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
         }
      }

      protected void Load0B11( )
      {
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound11 = 1;
            A34FerramentaColetaNome = T000B4_A34FerramentaColetaNome[0];
            AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
            A35FerramentaColetaAtivo = T000B4_A35FerramentaColetaAtivo[0];
            AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
            ZM0B11( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
         A34FerramentaColetaNome = StringUtil.Upper( A34FerramentaColetaNome);
         AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
      }

      protected void CheckExtendedTable0B11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_11 = 1;
         A34FerramentaColetaNome = StringUtil.Upper( A34FerramentaColetaNome);
         AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A34FerramentaColetaNome)) )
         {
            GX_msglist.addItem("Informe o nome da Ferramenta de Coleta.", 1, "FERRAMENTACOLETANOME");
            AnyError = 1;
            GX_FocusControl = edtFerramentaColetaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B11( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B11( )
      {
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B11( 8) ;
            RcdFound11 = 1;
            A33FerramentaColetaId = T000B3_A33FerramentaColetaId[0];
            n33FerramentaColetaId = T000B3_n33FerramentaColetaId[0];
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            A34FerramentaColetaNome = T000B3_A34FerramentaColetaNome[0];
            AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
            A35FerramentaColetaAtivo = T000B3_A35FerramentaColetaAtivo[0];
            AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
            Z33FerramentaColetaId = A33FerramentaColetaId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000B6_A33FerramentaColetaId[0] < A33FerramentaColetaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000B6_A33FerramentaColetaId[0] > A33FerramentaColetaId ) ) )
            {
               A33FerramentaColetaId = T000B6_A33FerramentaColetaId[0];
               n33FerramentaColetaId = T000B6_n33FerramentaColetaId[0];
               AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000B7_A33FerramentaColetaId[0] > A33FerramentaColetaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000B7_A33FerramentaColetaId[0] < A33FerramentaColetaId ) ) )
            {
               A33FerramentaColetaId = T000B7_A33FerramentaColetaId[0];
               n33FerramentaColetaId = T000B7_n33FerramentaColetaId[0];
               AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFerramentaColetaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A33FerramentaColetaId != Z33FerramentaColetaId )
               {
                  A33FerramentaColetaId = Z33FerramentaColetaId;
                  n33FerramentaColetaId = false;
                  AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FERRAMENTACOLETAID");
                  AnyError = 1;
                  GX_FocusControl = edtFerramentaColetaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFerramentaColetaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0B11( ) ;
                  GX_FocusControl = edtFerramentaColetaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A33FerramentaColetaId != Z33FerramentaColetaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFerramentaColetaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FERRAMENTACOLETAID");
                     AnyError = 1;
                     GX_FocusControl = edtFerramentaColetaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFerramentaColetaNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B11( ) ;
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
         if ( A33FerramentaColetaId != Z33FerramentaColetaId )
         {
            A33FerramentaColetaId = Z33FerramentaColetaId;
            n33FerramentaColetaId = false;
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FERRAMENTACOLETAID");
            AnyError = 1;
            GX_FocusControl = edtFerramentaColetaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFerramentaColetaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FerramentaColeta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z34FerramentaColetaNome, T000B2_A34FerramentaColetaNome[0]) != 0 ) || ( Z35FerramentaColetaAtivo != T000B2_A35FerramentaColetaAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z34FerramentaColetaNome, T000B2_A34FerramentaColetaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("ferramentacoleta:[seudo value changed for attri]"+"FerramentaColetaNome");
                  GXUtil.WriteLogRaw("Old: ",Z34FerramentaColetaNome);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A34FerramentaColetaNome[0]);
               }
               if ( Z35FerramentaColetaAtivo != T000B2_A35FerramentaColetaAtivo[0] )
               {
                  GXUtil.WriteLog("ferramentacoleta:[seudo value changed for attri]"+"FerramentaColetaAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z35FerramentaColetaAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A35FerramentaColetaAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FerramentaColeta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         if ( ! IsAuthorized("ferramentacoleta_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B8 */
                     pr_default.execute(6, new Object[] {A34FerramentaColetaNome, A35FerramentaColetaAtivo});
                     A33FerramentaColetaId = T000B8_A33FerramentaColetaId[0];
                     n33FerramentaColetaId = T000B8_n33FerramentaColetaId[0];
                     AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("FerramentaColeta");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0B0( ) ;
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         if ( ! IsAuthorized("ferramentacoleta_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B9 */
                     pr_default.execute(7, new Object[] {A34FerramentaColetaNome, A35FerramentaColetaAtivo, n33FerramentaColetaId, A33FerramentaColetaId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("FerramentaColeta");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FerramentaColeta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
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
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("ferramentacoleta_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B10 */
                  pr_default.execute(8, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("FerramentaColeta");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
            AssignAttri("", false, "AV16IsOk", AV16IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000B11 */
            pr_default.execute(9, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ferramentacoleta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ferramentacoleta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B11( )
      {
         /* Scan By routine */
         /* Using cursor T000B12 */
         pr_default.execute(10);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound11 = 1;
            A33FerramentaColetaId = T000B12_A33FerramentaColetaId[0];
            n33FerramentaColetaId = T000B12_n33FerramentaColetaId[0];
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound11 = 1;
            A33FerramentaColetaId = T000B12_A33FerramentaColetaId[0];
            n33FerramentaColetaId = T000B12_n33FerramentaColetaId[0];
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         }
      }

      protected void ScanEnd0B11( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
         edtFerramentaColetaNome_Enabled = 0;
         AssignProp("", false, edtFerramentaColetaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFerramentaColetaNome_Enabled), 5, 0), true);
         cmbFerramentaColetaAtivo.Enabled = 0;
         AssignProp("", false, cmbFerramentaColetaAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFerramentaColetaAtivo.Enabled), 5, 0), true);
         edtFerramentaColetaId_Enabled = 0;
         AssignProp("", false, edtFerramentaColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFerramentaColetaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         GXEncryptionTmp = "ferramentacoleta.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FerramentaColetaId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsFerramentaColeta)) + "," + UrlEncode(StringUtil.LTrimStr(AV15FerramentaColetaId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ferramentacoleta.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"FerramentaColeta");
         forbiddenHiddens.Add("FerramentaColetaId", context.localUtil.Format( (decimal)(A33FerramentaColetaId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ferramentacoleta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z33FerramentaColetaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33FerramentaColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z34FerramentaColetaNome", Z34FerramentaColetaNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z35FerramentaColetaAtivo", Z35FerramentaColetaAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISFERRAMENTACOLETA", AV14IsFerramentaColeta);
         GxWebStd.gx_hidden_field( context, "vFERRAMENTACOLETAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15FerramentaColetaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vFERRAMENTACOLETAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FerramentaColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFERRAMENTACOLETAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FerramentaColetaId), "ZZZZZZZ9"), context));
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
         GXEncryptionTmp = "ferramentacoleta.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FerramentaColetaId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsFerramentaColeta)) + "," + UrlEncode(StringUtil.LTrimStr(AV15FerramentaColetaId_Out,8,0));
         return formatLink("ferramentacoleta.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "FerramentaColeta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ferramenta Coleta" ;
      }

      protected void InitializeNonKey0B11( )
      {
         A34FerramentaColetaNome = "";
         AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
         AV16IsOk = false;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         A35FerramentaColetaAtivo = true;
         AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
         Z34FerramentaColetaNome = "";
         Z35FerramentaColetaAtivo = false;
      }

      protected void InitAll0B11( )
      {
         A33FerramentaColetaId = 0;
         n33FerramentaColetaId = false;
         AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         InitializeNonKey0B11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A35FerramentaColetaAtivo = i35FerramentaColetaAtivo;
         AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231241726300", true, true);
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
         context.AddJavascriptSource("ferramentacoleta.js", "?20231241726300", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFerramentaColetaNome_Internalname = "FERRAMENTACOLETANOME";
         cmbFerramentaColetaAtivo_Internalname = "FERRAMENTACOLETAATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtFerramentaColetaId_Internalname = "FERRAMENTACOLETAID";
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
         Form.Caption = "Ferramenta Coleta";
         edtFerramentaColetaId_Jsonclick = "";
         edtFerramentaColetaId_Enabled = 0;
         edtFerramentaColetaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbFerramentaColetaAtivo_Jsonclick = "";
         cmbFerramentaColetaAtivo.Enabled = 1;
         cmbFerramentaColetaAtivo.Visible = 1;
         edtFerramentaColetaNome_Jsonclick = "";
         edtFerramentaColetaNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "FERRAMENTA DE COLETA";
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

      protected void GX4ASAISOK0B11( int A33FerramentaColetaId ,
                                     string A34FerramentaColetaNome )
      {
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
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
         cmbFerramentaColetaAtivo.Name = "FERRAMENTACOLETAATIVO";
         cmbFerramentaColetaAtivo.WebTags = "";
         cmbFerramentaColetaAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbFerramentaColetaAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbFerramentaColetaAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A35FerramentaColetaAtivo) )
            {
               A35FerramentaColetaAtivo = true;
               AssignAttri("", false, "A35FerramentaColetaAtivo", A35FerramentaColetaAtivo);
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

      public void Valid_Ferramentacoletanome( )
      {
         n33FerramentaColetaId = false;
         A34FerramentaColetaNome = StringUtil.Upper( A34FerramentaColetaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "FERRAMENTACOLETANOME");
            AnyError = 1;
            GX_FocusControl = edtFerramentaColetaNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A34FerramentaColetaNome)) )
         {
            GX_msglist.addItem("Informe o nome da Ferramenta de Coleta.", 1, "FERRAMENTACOLETANOME");
            AnyError = 1;
            GX_FocusControl = edtFerramentaColetaNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A34FerramentaColetaNome", A34FerramentaColetaNome);
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9',hsh:true},{av:'AV14IsFerramentaColeta',fld:'vISFERRAMENTACOLETA',pic:''},{av:'AV15FerramentaColetaId_Out',fld:'vFERRAMENTACOLETAID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9',hsh:true},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120B2',iparms:[{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV14IsFerramentaColeta',fld:'vISFERRAMENTACOLETA',pic:''},{av:'AV15FerramentaColetaId_Out',fld:'vFERRAMENTACOLETAID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_FERRAMENTACOLETANOME","{handler:'Valid_Ferramentacoletanome',iparms:[{av:'A34FerramentaColetaNome',fld:'FERRAMENTACOLETANOME',pic:''},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'AV16IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_FERRAMENTACOLETANOME",",oparms:[{av:'A34FerramentaColetaNome',fld:'FERRAMENTACOLETANOME',pic:''},{av:'AV16IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_FERRAMENTACOLETAID","{handler:'Valid_Ferramentacoletaid',iparms:[]");
         setEventMetadata("VALID_FERRAMENTACOLETAID",",oparms:[]}");
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
         Z34FerramentaColetaNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A34FerramentaColetaNome = "";
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
         sMode11 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000B4_A33FerramentaColetaId = new int[1] ;
         T000B4_n33FerramentaColetaId = new bool[] {false} ;
         T000B4_A34FerramentaColetaNome = new string[] {""} ;
         T000B4_A35FerramentaColetaAtivo = new bool[] {false} ;
         T000B5_A33FerramentaColetaId = new int[1] ;
         T000B5_n33FerramentaColetaId = new bool[] {false} ;
         T000B3_A33FerramentaColetaId = new int[1] ;
         T000B3_n33FerramentaColetaId = new bool[] {false} ;
         T000B3_A34FerramentaColetaNome = new string[] {""} ;
         T000B3_A35FerramentaColetaAtivo = new bool[] {false} ;
         T000B6_A33FerramentaColetaId = new int[1] ;
         T000B6_n33FerramentaColetaId = new bool[] {false} ;
         T000B7_A33FerramentaColetaId = new int[1] ;
         T000B7_n33FerramentaColetaId = new bool[] {false} ;
         T000B2_A33FerramentaColetaId = new int[1] ;
         T000B2_n33FerramentaColetaId = new bool[] {false} ;
         T000B2_A34FerramentaColetaNome = new string[] {""} ;
         T000B2_A35FerramentaColetaAtivo = new bool[] {false} ;
         T000B8_A33FerramentaColetaId = new int[1] ;
         T000B8_n33FerramentaColetaId = new bool[] {false} ;
         T000B11_A75DocumentoId = new int[1] ;
         T000B12_A33FerramentaColetaId = new int[1] ;
         T000B12_n33FerramentaColetaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ferramentacoleta__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ferramentacoleta__default(),
            new Object[][] {
                new Object[] {
               T000B2_A33FerramentaColetaId, T000B2_A34FerramentaColetaNome, T000B2_A35FerramentaColetaAtivo
               }
               , new Object[] {
               T000B3_A33FerramentaColetaId, T000B3_A34FerramentaColetaNome, T000B3_A35FerramentaColetaAtivo
               }
               , new Object[] {
               T000B4_A33FerramentaColetaId, T000B4_A34FerramentaColetaNome, T000B4_A35FerramentaColetaAtivo
               }
               , new Object[] {
               T000B5_A33FerramentaColetaId
               }
               , new Object[] {
               T000B6_A33FerramentaColetaId
               }
               , new Object[] {
               T000B7_A33FerramentaColetaId
               }
               , new Object[] {
               T000B8_A33FerramentaColetaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B11_A75DocumentoId
               }
               , new Object[] {
               T000B12_A33FerramentaColetaId
               }
            }
         );
         Z35FerramentaColetaAtivo = true;
         A35FerramentaColetaAtivo = true;
         i35FerramentaColetaAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short GX_JID ;
      private short nIsDirty_11 ;
      private short gxajaxcallmode ;
      private int wcpOAV7FerramentaColetaId ;
      private int Z33FerramentaColetaId ;
      private int A33FerramentaColetaId ;
      private int AV7FerramentaColetaId ;
      private int AV15FerramentaColetaId_Out ;
      private int trnEnded ;
      private int edtFerramentaColetaNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtFerramentaColetaId_Enabled ;
      private int edtFerramentaColetaId_Visible ;
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
      private string edtFerramentaColetaNome_Internalname ;
      private string cmbFerramentaColetaAtivo_Internalname ;
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
      private string edtFerramentaColetaNome_Jsonclick ;
      private string cmbFerramentaColetaAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtFerramentaColetaId_Internalname ;
      private string edtFerramentaColetaId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode11 ;
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
      private bool Z35FerramentaColetaAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n33FerramentaColetaId ;
      private bool AV14IsFerramentaColeta ;
      private bool wbErr ;
      private bool A35FerramentaColetaAtivo ;
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
      private bool i35FerramentaColetaAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV16IsOk ;
      private string Z34FerramentaColetaNome ;
      private string A34FerramentaColetaNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFerramentaColetaAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T000B4_A33FerramentaColetaId ;
      private bool[] T000B4_n33FerramentaColetaId ;
      private string[] T000B4_A34FerramentaColetaNome ;
      private bool[] T000B4_A35FerramentaColetaAtivo ;
      private int[] T000B5_A33FerramentaColetaId ;
      private bool[] T000B5_n33FerramentaColetaId ;
      private int[] T000B3_A33FerramentaColetaId ;
      private bool[] T000B3_n33FerramentaColetaId ;
      private string[] T000B3_A34FerramentaColetaNome ;
      private bool[] T000B3_A35FerramentaColetaAtivo ;
      private int[] T000B6_A33FerramentaColetaId ;
      private bool[] T000B6_n33FerramentaColetaId ;
      private int[] T000B7_A33FerramentaColetaId ;
      private bool[] T000B7_n33FerramentaColetaId ;
      private int[] T000B2_A33FerramentaColetaId ;
      private bool[] T000B2_n33FerramentaColetaId ;
      private string[] T000B2_A34FerramentaColetaNome ;
      private bool[] T000B2_A35FerramentaColetaAtivo ;
      private int[] T000B8_A33FerramentaColetaId ;
      private bool[] T000B8_n33FerramentaColetaId ;
      private int[] T000B11_A75DocumentoId ;
      private int[] T000B12_A33FerramentaColetaId ;
      private bool[] T000B12_n33FerramentaColetaId ;
      private bool aP2_IsFerramentaColeta ;
      private int aP3_FerramentaColetaId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class ferramentacoleta__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class ferramentacoleta__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000B4;
        prmT000B4 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B5;
        prmT000B5 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B3;
        prmT000B3 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B6;
        prmT000B6 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B7;
        prmT000B7 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B2;
        prmT000B2 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B8;
        prmT000B8 = new Object[] {
        new ParDef("@FerramentaColetaNome",GXType.NVarChar,100,0) ,
        new ParDef("@FerramentaColetaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT000B9;
        prmT000B9 = new Object[] {
        new ParDef("@FerramentaColetaNome",GXType.NVarChar,100,0) ,
        new ParDef("@FerramentaColetaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B10;
        prmT000B10 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B11;
        prmT000B11 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000B12;
        prmT000B12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000B2", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WITH (UPDLOCK) WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B3", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B4", "SELECT TM1.[FerramentaColetaId], TM1.[FerramentaColetaNome], TM1.[FerramentaColetaAtivo] FROM [FerramentaColeta] TM1 WHERE TM1.[FerramentaColetaId] = @FerramentaColetaId ORDER BY TM1.[FerramentaColetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B5", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B6", "SELECT TOP 1 [FerramentaColetaId] FROM [FerramentaColeta] WHERE ( [FerramentaColetaId] > @FerramentaColetaId) ORDER BY [FerramentaColetaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B7", "SELECT TOP 1 [FerramentaColetaId] FROM [FerramentaColeta] WHERE ( [FerramentaColetaId] < @FerramentaColetaId) ORDER BY [FerramentaColetaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B8", "INSERT INTO [FerramentaColeta]([FerramentaColetaNome], [FerramentaColetaAtivo]) VALUES(@FerramentaColetaNome, @FerramentaColetaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B9", "UPDATE [FerramentaColeta] SET [FerramentaColetaNome]=@FerramentaColetaNome, [FerramentaColetaAtivo]=@FerramentaColetaAtivo  WHERE [FerramentaColetaId] = @FerramentaColetaId", GxErrorMask.GX_NOMASK,prmT000B9)
           ,new CursorDef("T000B10", "DELETE FROM [FerramentaColeta]  WHERE [FerramentaColetaId] = @FerramentaColetaId", GxErrorMask.GX_NOMASK,prmT000B10)
           ,new CursorDef("T000B11", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B12", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] ORDER BY [FerramentaColetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B12,100, GxCacheFrequency.OFF ,true,false )
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
