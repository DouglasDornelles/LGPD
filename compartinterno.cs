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
   public class compartinterno : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A57CompartInternoId = (int)(NumberUtil.Val( GetPar( "CompartInternoId"), "."));
            AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
            A58CompartInternoNome = GetPar( "CompartInternoNome");
            AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAISOK0J19( A57CompartInternoId, A58CompartInternoNome) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compartinterno.aspx")), "compartinterno.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compartinterno.aspx")))) ;
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
                  AV7CompartInternoId = (int)(NumberUtil.Val( GetPar( "CompartInternoId"), "."));
                  AssignAttri("", false, "AV7CompartInternoId", StringUtil.LTrimStr( (decimal)(AV7CompartInternoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCOMPARTINTERNOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CompartInternoId), "ZZZZZZZ9"), context));
                  AV14IsCompartInterno = StringUtil.StrToBool( GetPar( "IsCompartInterno"));
                  AssignAttri("", false, "AV14IsCompartInterno", AV14IsCompartInterno);
                  AV15CompartInternoId_Out = (int)(NumberUtil.Val( GetPar( "CompartInternoId_Out"), "."));
                  AssignAttri("", false, "AV15CompartInternoId_Out", StringUtil.LTrimStr( (decimal)(AV15CompartInternoId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Compart Interno", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCompartInternoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public compartinterno( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public compartinterno( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CompartInternoId ,
                           out bool aP2_IsCompartInterno ,
                           out int aP3_CompartInternoId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CompartInternoId = aP1_CompartInternoId;
         this.AV14IsCompartInterno = false ;
         this.AV15CompartInternoId_Out = 0 ;
         executePrivate();
         aP2_IsCompartInterno=this.AV14IsCompartInterno;
         aP3_CompartInternoId_Out=this.AV15CompartInternoId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCompartInternoAtivo = new GXCombobox();
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
            return "compartinterno_Execute" ;
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
         if ( cmbCompartInternoAtivo.ItemCount > 0 )
         {
            A59CompartInternoAtivo = StringUtil.StrToBool( cmbCompartInternoAtivo.getValidValue(StringUtil.BoolToStr( A59CompartInternoAtivo)));
            AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCompartInternoAtivo.CurrentValue = StringUtil.BoolToStr( A59CompartInternoAtivo);
            AssignProp("", false, cmbCompartInternoAtivo_Internalname, "Values", cmbCompartInternoAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCompartInternoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCompartInternoNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompartInternoNome_Internalname, A58CompartInternoNome, StringUtil.RTrim( context.localUtil.Format( A58CompartInternoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompartInternoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCompartInternoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CompartInterno.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbCompartInternoAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCompartInternoAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCompartInternoAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCompartInternoAtivo, cmbCompartInternoAtivo_Internalname, StringUtil.BoolToStr( A59CompartInternoAtivo), 1, cmbCompartInternoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbCompartInternoAtivo.Visible, cmbCompartInternoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_CompartInterno.htm");
         cmbCompartInternoAtivo.CurrentValue = StringUtil.BoolToStr( A59CompartInternoAtivo);
         AssignProp("", false, cmbCompartInternoAtivo_Internalname, "Values", (string)(cmbCompartInternoAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CompartInterno.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CompartInterno.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CompartInterno.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCompartInternoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57CompartInternoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtCompartInternoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A57CompartInternoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A57CompartInternoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompartInternoId_Jsonclick, 0, "Attribute", "", "", "", "", edtCompartInternoId_Visible, edtCompartInternoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CompartInterno.htm");
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
         E110J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z57CompartInternoId = (int)(context.localUtil.CToN( cgiGet( "Z57CompartInternoId"), ",", "."));
               Z58CompartInternoNome = cgiGet( "Z58CompartInternoNome");
               Z59CompartInternoAtivo = StringUtil.StrToBool( cgiGet( "Z59CompartInternoAtivo"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7CompartInternoId = (int)(context.localUtil.CToN( cgiGet( "vCOMPARTINTERNOID"), ",", "."));
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
               A58CompartInternoNome = cgiGet( edtCompartInternoNome_Internalname);
               AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
               cmbCompartInternoAtivo.CurrentValue = cgiGet( cmbCompartInternoAtivo_Internalname);
               A59CompartInternoAtivo = StringUtil.StrToBool( cgiGet( cmbCompartInternoAtivo_Internalname));
               AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
               A57CompartInternoId = (int)(context.localUtil.CToN( cgiGet( edtCompartInternoId_Internalname), ",", "."));
               AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CompartInterno");
               A57CompartInternoId = (int)(context.localUtil.CToN( cgiGet( edtCompartInternoId_Internalname), ",", "."));
               AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
               forbiddenHiddens.Add("CompartInternoId", context.localUtil.Format( (decimal)(A57CompartInternoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A57CompartInternoId != Z57CompartInternoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("compartinterno:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A57CompartInternoId = (int)(NumberUtil.Val( GetPar( "CompartInternoId"), "."));
                  AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
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
                     sMode19 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode19;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound19 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMPARTINTERNOID");
                        AnyError = 1;
                        GX_FocusControl = edtCompartInternoId_Internalname;
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
                           E110J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120J2 ();
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
            E120J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0J19( ) ;
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
            DisableAttributes0J19( ) ;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J19( ) ;
            }
            else
            {
               CheckExtendedTable0J19( ) ;
               CloseExtendedTableCursors0J19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0J0( )
      {
      }

      protected void E110J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtCompartInternoId_Visible = 0;
         AssignProp("", false, edtCompartInternoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCompartInternoId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbCompartInternoAtivo.Visible = 0;
            AssignProp("", false, cmbCompartInternoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCompartInternoAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbCompartInternoAtivo.Visible = 1;
            AssignProp("", false, cmbCompartInternoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCompartInternoAtivo.Visible), 5, 0), true);
         }
      }

      protected void E120J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsCompartInterno = true;
         AssignAttri("", false, "AV14IsCompartInterno", AV14IsCompartInterno);
         AV15CompartInternoId_Out = A57CompartInternoId;
         AssignAttri("", false, "AV15CompartInternoId_Out", StringUtil.LTrimStr( (decimal)(AV15CompartInternoId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("compartinternoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV14IsCompartInterno,(int)AV15CompartInternoId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV14IsCompartInterno","AV15CompartInternoId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0J19( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z58CompartInternoNome = T000J3_A58CompartInternoNome[0];
               Z59CompartInternoAtivo = T000J3_A59CompartInternoAtivo[0];
            }
            else
            {
               Z58CompartInternoNome = A58CompartInternoNome;
               Z59CompartInternoAtivo = A59CompartInternoAtivo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z57CompartInternoId = A57CompartInternoId;
            Z58CompartInternoNome = A58CompartInternoNome;
            Z59CompartInternoAtivo = A59CompartInternoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCompartInternoId_Enabled = 0;
         AssignProp("", false, edtCompartInternoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompartInternoId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCompartInternoId_Enabled = 0;
         AssignProp("", false, edtCompartInternoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompartInternoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CompartInternoId) )
         {
            A57CompartInternoId = AV7CompartInternoId;
            AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
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
         if ( IsIns( )  && (false==A59CompartInternoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A59CompartInternoAtivo = true;
            AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
         }
      }

      protected void Load0J19( )
      {
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A58CompartInternoNome = T000J4_A58CompartInternoNome[0];
            AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
            A59CompartInternoAtivo = T000J4_A59CompartInternoAtivo[0];
            AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
            ZM0J19( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0J19( ) ;
      }

      protected void OnLoadActions0J19( )
      {
         A58CompartInternoNome = StringUtil.Upper( A58CompartInternoNome);
         AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
      }

      protected void CheckExtendedTable0J19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_19 = 1;
         A58CompartInternoNome = StringUtil.Upper( A58CompartInternoNome);
         AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A58CompartInternoNome)) )
         {
            GX_msglist.addItem("Informe o Nome do Compartilhamento Interno.", 1, "COMPARTINTERNONOME");
            AnyError = 1;
            GX_FocusControl = edtCompartInternoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0J19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J19( )
      {
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J19( 8) ;
            RcdFound19 = 1;
            A57CompartInternoId = T000J3_A57CompartInternoId[0];
            AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
            A58CompartInternoNome = T000J3_A58CompartInternoNome[0];
            AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
            A59CompartInternoAtivo = T000J3_A59CompartInternoAtivo[0];
            AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
            Z57CompartInternoId = A57CompartInternoId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0J19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0J19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J19( ) ;
         if ( RcdFound19 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound19 = 0;
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000J6_A57CompartInternoId[0] < A57CompartInternoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000J6_A57CompartInternoId[0] > A57CompartInternoId ) ) )
            {
               A57CompartInternoId = T000J6_A57CompartInternoId[0];
               AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000J7_A57CompartInternoId[0] > A57CompartInternoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000J7_A57CompartInternoId[0] < A57CompartInternoId ) ) )
            {
               A57CompartInternoId = T000J7_A57CompartInternoId[0];
               AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCompartInternoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A57CompartInternoId != Z57CompartInternoId )
               {
                  A57CompartInternoId = Z57CompartInternoId;
                  AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMPARTINTERNOID");
                  AnyError = 1;
                  GX_FocusControl = edtCompartInternoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCompartInternoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0J19( ) ;
                  GX_FocusControl = edtCompartInternoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A57CompartInternoId != Z57CompartInternoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCompartInternoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMPARTINTERNOID");
                     AnyError = 1;
                     GX_FocusControl = edtCompartInternoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCompartInternoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J19( ) ;
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
         if ( A57CompartInternoId != Z57CompartInternoId )
         {
            A57CompartInternoId = Z57CompartInternoId;
            AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMPARTINTERNOID");
            AnyError = 1;
            GX_FocusControl = edtCompartInternoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCompartInternoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0J19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A57CompartInternoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompartInterno"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z58CompartInternoNome, T000J2_A58CompartInternoNome[0]) != 0 ) || ( Z59CompartInternoAtivo != T000J2_A59CompartInternoAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z58CompartInternoNome, T000J2_A58CompartInternoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("compartinterno:[seudo value changed for attri]"+"CompartInternoNome");
                  GXUtil.WriteLogRaw("Old: ",Z58CompartInternoNome);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A58CompartInternoNome[0]);
               }
               if ( Z59CompartInternoAtivo != T000J2_A59CompartInternoAtivo[0] )
               {
                  GXUtil.WriteLog("compartinterno:[seudo value changed for attri]"+"CompartInternoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z59CompartInternoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A59CompartInternoAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CompartInterno"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J19( )
      {
         if ( ! IsAuthorized("compartinterno_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J19( 0) ;
            CheckOptimisticConcurrency0J19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J8 */
                     pr_default.execute(6, new Object[] {A58CompartInternoNome, A59CompartInternoAtivo});
                     A57CompartInternoId = T000J8_A57CompartInternoId[0];
                     AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CompartInterno");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0J0( ) ;
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
               Load0J19( ) ;
            }
            EndLevel0J19( ) ;
         }
         CloseExtendedTableCursors0J19( ) ;
      }

      protected void Update0J19( )
      {
         if ( ! IsAuthorized("compartinterno_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J9 */
                     pr_default.execute(7, new Object[] {A58CompartInternoNome, A59CompartInternoAtivo, A57CompartInternoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CompartInterno");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompartInterno"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J19( ) ;
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
            EndLevel0J19( ) ;
         }
         CloseExtendedTableCursors0J19( ) ;
      }

      protected void DeferredUpdate0J19( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("compartinterno_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J19( ) ;
            AfterConfirm0J19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J10 */
                  pr_default.execute(8, new Object[] {A57CompartInternoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CompartInterno");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
            AssignAttri("", false, "AV16IsOk", AV16IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000J11 */
            pr_default.execute(9, new Object[] {A57CompartInternoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Compart Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0J19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("compartinterno",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("compartinterno",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J19( )
      {
         /* Scan By routine */
         /* Using cursor T000J12 */
         pr_default.execute(10);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound19 = 1;
            A57CompartInternoId = T000J12_A57CompartInternoId[0];
            AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J19( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound19 = 1;
            A57CompartInternoId = T000J12_A57CompartInternoId[0];
            AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
         }
      }

      protected void ScanEnd0J19( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0J19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J19( )
      {
         edtCompartInternoNome_Enabled = 0;
         AssignProp("", false, edtCompartInternoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompartInternoNome_Enabled), 5, 0), true);
         cmbCompartInternoAtivo.Enabled = 0;
         AssignProp("", false, cmbCompartInternoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCompartInternoAtivo.Enabled), 5, 0), true);
         edtCompartInternoId_Enabled = 0;
         AssignProp("", false, edtCompartInternoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompartInternoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         GXEncryptionTmp = "compartinterno.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CompartInternoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsCompartInterno)) + "," + UrlEncode(StringUtil.LTrimStr(AV15CompartInternoId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("compartinterno.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CompartInterno");
         forbiddenHiddens.Add("CompartInternoId", context.localUtil.Format( (decimal)(A57CompartInternoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("compartinterno:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z57CompartInternoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z57CompartInternoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z58CompartInternoNome", Z58CompartInternoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z59CompartInternoAtivo", Z59CompartInternoAtivo);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISCOMPARTINTERNO", AV14IsCompartInterno);
         GxWebStd.gx_hidden_field( context, "vCOMPARTINTERNOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CompartInternoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCOMPARTINTERNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CompartInternoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMPARTINTERNOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CompartInternoId), "ZZZZZZZ9"), context));
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
         GXEncryptionTmp = "compartinterno.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CompartInternoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV14IsCompartInterno)) + "," + UrlEncode(StringUtil.LTrimStr(AV15CompartInternoId_Out,8,0));
         return formatLink("compartinterno.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "CompartInterno" ;
      }

      public override string GetPgmdesc( )
      {
         return "Compart Interno" ;
      }

      protected void InitializeNonKey0J19( )
      {
         A58CompartInternoNome = "";
         AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
         AV16IsOk = false;
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
         A59CompartInternoAtivo = true;
         AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
         Z58CompartInternoNome = "";
         Z59CompartInternoAtivo = false;
      }

      protected void InitAll0J19( )
      {
         A57CompartInternoId = 0;
         AssignAttri("", false, "A57CompartInternoId", StringUtil.LTrimStr( (decimal)(A57CompartInternoId), 8, 0));
         InitializeNonKey0J19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A59CompartInternoAtivo = i59CompartInternoAtivo;
         AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910454865", true, true);
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
         context.AddJavascriptSource("compartinterno.js", "?202311910454865", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCompartInternoNome_Internalname = "COMPARTINTERNONOME";
         cmbCompartInternoAtivo_Internalname = "COMPARTINTERNOATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCompartInternoId_Internalname = "COMPARTINTERNOID";
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
         Form.Caption = "Compart Interno";
         edtCompartInternoId_Jsonclick = "";
         edtCompartInternoId_Enabled = 0;
         edtCompartInternoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCompartInternoAtivo_Jsonclick = "";
         cmbCompartInternoAtivo.Enabled = 1;
         cmbCompartInternoAtivo.Visible = 1;
         edtCompartInternoNome_Jsonclick = "";
         edtCompartInternoNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "COMPARTILHAMENTO INTERNO";
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

      protected void GX4ASAISOK0J19( int A57CompartInternoId ,
                                     string A58CompartInternoNome )
      {
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
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
         cmbCompartInternoAtivo.Name = "COMPARTINTERNOATIVO";
         cmbCompartInternoAtivo.WebTags = "";
         cmbCompartInternoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbCompartInternoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbCompartInternoAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A59CompartInternoAtivo) )
            {
               A59CompartInternoAtivo = true;
               AssignAttri("", false, "A59CompartInternoAtivo", A59CompartInternoAtivo);
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

      public void Valid_Compartinternonome( )
      {
         A58CompartInternoNome = StringUtil.Upper( A58CompartInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "COMPARTINTERNONOME");
            AnyError = 1;
            GX_FocusControl = edtCompartInternoNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A58CompartInternoNome)) )
         {
            GX_msglist.addItem("Informe o Nome do Compartilhamento Interno.", 1, "COMPARTINTERNONOME");
            AnyError = 1;
            GX_FocusControl = edtCompartInternoNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A58CompartInternoNome", A58CompartInternoNome);
         AssignAttri("", false, "AV16IsOk", AV16IsOk);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CompartInternoId',fld:'vCOMPARTINTERNOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV14IsCompartInterno',fld:'vISCOMPARTINTERNO',pic:''},{av:'AV15CompartInternoId_Out',fld:'vCOMPARTINTERNOID_OUT',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CompartInternoId',fld:'vCOMPARTINTERNOID',pic:'ZZZZZZZ9',hsh:true},{av:'A57CompartInternoId',fld:'COMPARTINTERNOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120J2',iparms:[{av:'A57CompartInternoId',fld:'COMPARTINTERNOID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV14IsCompartInterno',fld:'vISCOMPARTINTERNO',pic:''},{av:'AV15CompartInternoId_Out',fld:'vCOMPARTINTERNOID_OUT',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_COMPARTINTERNONOME","{handler:'Valid_Compartinternonome',iparms:[{av:'A58CompartInternoNome',fld:'COMPARTINTERNONOME',pic:''},{av:'A57CompartInternoId',fld:'COMPARTINTERNOID',pic:'ZZZZZZZ9'},{av:'AV16IsOk',fld:'vISOK',pic:''}]");
         setEventMetadata("VALID_COMPARTINTERNONOME",",oparms:[{av:'A58CompartInternoNome',fld:'COMPARTINTERNONOME',pic:''},{av:'AV16IsOk',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALID_COMPARTINTERNOID","{handler:'Valid_Compartinternoid',iparms:[]");
         setEventMetadata("VALID_COMPARTINTERNOID",",oparms:[]}");
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
         Z58CompartInternoNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A58CompartInternoNome = "";
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
         sMode19 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000J4_A57CompartInternoId = new int[1] ;
         T000J4_A58CompartInternoNome = new string[] {""} ;
         T000J4_A59CompartInternoAtivo = new bool[] {false} ;
         T000J5_A57CompartInternoId = new int[1] ;
         T000J3_A57CompartInternoId = new int[1] ;
         T000J3_A58CompartInternoNome = new string[] {""} ;
         T000J3_A59CompartInternoAtivo = new bool[] {false} ;
         T000J6_A57CompartInternoId = new int[1] ;
         T000J7_A57CompartInternoId = new int[1] ;
         T000J2_A57CompartInternoId = new int[1] ;
         T000J2_A58CompartInternoNome = new string[] {""} ;
         T000J2_A59CompartInternoAtivo = new bool[] {false} ;
         T000J8_A57CompartInternoId = new int[1] ;
         T000J11_A57CompartInternoId = new int[1] ;
         T000J11_A75DocumentoId = new int[1] ;
         T000J12_A57CompartInternoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.compartinterno__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compartinterno__default(),
            new Object[][] {
                new Object[] {
               T000J2_A57CompartInternoId, T000J2_A58CompartInternoNome, T000J2_A59CompartInternoAtivo
               }
               , new Object[] {
               T000J3_A57CompartInternoId, T000J3_A58CompartInternoNome, T000J3_A59CompartInternoAtivo
               }
               , new Object[] {
               T000J4_A57CompartInternoId, T000J4_A58CompartInternoNome, T000J4_A59CompartInternoAtivo
               }
               , new Object[] {
               T000J5_A57CompartInternoId
               }
               , new Object[] {
               T000J6_A57CompartInternoId
               }
               , new Object[] {
               T000J7_A57CompartInternoId
               }
               , new Object[] {
               T000J8_A57CompartInternoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J11_A57CompartInternoId, T000J11_A75DocumentoId
               }
               , new Object[] {
               T000J12_A57CompartInternoId
               }
            }
         );
         Z59CompartInternoAtivo = true;
         A59CompartInternoAtivo = true;
         i59CompartInternoAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound19 ;
      private short GX_JID ;
      private short nIsDirty_19 ;
      private short gxajaxcallmode ;
      private int wcpOAV7CompartInternoId ;
      private int Z57CompartInternoId ;
      private int A57CompartInternoId ;
      private int AV7CompartInternoId ;
      private int AV15CompartInternoId_Out ;
      private int trnEnded ;
      private int edtCompartInternoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCompartInternoId_Enabled ;
      private int edtCompartInternoId_Visible ;
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
      private string edtCompartInternoNome_Internalname ;
      private string cmbCompartInternoAtivo_Internalname ;
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
      private string edtCompartInternoNome_Jsonclick ;
      private string cmbCompartInternoAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCompartInternoId_Internalname ;
      private string edtCompartInternoId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode19 ;
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
      private bool Z59CompartInternoAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14IsCompartInterno ;
      private bool wbErr ;
      private bool A59CompartInternoAtivo ;
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
      private bool i59CompartInternoAtivo ;
      private bool GXt_boolean1 ;
      private bool ZV16IsOk ;
      private string Z58CompartInternoNome ;
      private string A58CompartInternoNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCompartInternoAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T000J4_A57CompartInternoId ;
      private string[] T000J4_A58CompartInternoNome ;
      private bool[] T000J4_A59CompartInternoAtivo ;
      private int[] T000J5_A57CompartInternoId ;
      private int[] T000J3_A57CompartInternoId ;
      private string[] T000J3_A58CompartInternoNome ;
      private bool[] T000J3_A59CompartInternoAtivo ;
      private int[] T000J6_A57CompartInternoId ;
      private int[] T000J7_A57CompartInternoId ;
      private int[] T000J2_A57CompartInternoId ;
      private string[] T000J2_A58CompartInternoNome ;
      private bool[] T000J2_A59CompartInternoAtivo ;
      private int[] T000J8_A57CompartInternoId ;
      private int[] T000J11_A57CompartInternoId ;
      private int[] T000J11_A75DocumentoId ;
      private int[] T000J12_A57CompartInternoId ;
      private bool aP2_IsCompartInterno ;
      private int aP3_CompartInternoId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class compartinterno__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class compartinterno__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000J4;
        prmT000J4 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J5;
        prmT000J5 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J3;
        prmT000J3 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J6;
        prmT000J6 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J7;
        prmT000J7 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J2;
        prmT000J2 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J8;
        prmT000J8 = new Object[] {
        new ParDef("@CompartInternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CompartInternoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmT000J9;
        prmT000J9 = new Object[] {
        new ParDef("@CompartInternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CompartInternoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J10;
        prmT000J10 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J11;
        prmT000J11 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmT000J12;
        prmT000J12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000J2", "SELECT [CompartInternoId], [CompartInternoNome], [CompartInternoAtivo] FROM [CompartInterno] WITH (UPDLOCK) WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J3", "SELECT [CompartInternoId], [CompartInternoNome], [CompartInternoAtivo] FROM [CompartInterno] WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J4", "SELECT TM1.[CompartInternoId], TM1.[CompartInternoNome], TM1.[CompartInternoAtivo] FROM [CompartInterno] TM1 WHERE TM1.[CompartInternoId] = @CompartInternoId ORDER BY TM1.[CompartInternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J5", "SELECT [CompartInternoId] FROM [CompartInterno] WHERE [CompartInternoId] = @CompartInternoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J6", "SELECT TOP 1 [CompartInternoId] FROM [CompartInterno] WHERE ( [CompartInternoId] > @CompartInternoId) ORDER BY [CompartInternoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J7", "SELECT TOP 1 [CompartInternoId] FROM [CompartInterno] WHERE ( [CompartInternoId] < @CompartInternoId) ORDER BY [CompartInternoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J8", "INSERT INTO [CompartInterno]([CompartInternoNome], [CompartInternoAtivo]) VALUES(@CompartInternoNome, @CompartInternoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J9", "UPDATE [CompartInterno] SET [CompartInternoNome]=@CompartInternoNome, [CompartInternoAtivo]=@CompartInternoAtivo  WHERE [CompartInternoId] = @CompartInternoId", GxErrorMask.GX_NOMASK,prmT000J9)
           ,new CursorDef("T000J10", "DELETE FROM [CompartInterno]  WHERE [CompartInternoId] = @CompartInternoId", GxErrorMask.GX_NOMASK,prmT000J10)
           ,new CursorDef("T000J11", "SELECT TOP 1 [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J12", "SELECT [CompartInternoId] FROM [CompartInterno] ORDER BY [CompartInternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J12,100, GxCacheFrequency.OFF ,true,false )
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
