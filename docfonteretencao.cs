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
   public class docfonteretencao : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A63FonteRetencaoId = (int)(NumberUtil.Val( GetPar( "FonteRetencaoId"), "."));
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A63FonteRetencaoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A75DocumentoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docfonteretencao.aspx")), "docfonteretencao.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docfonteretencao.aspx")))) ;
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
                  AV8DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri("", false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Doc Fonte Retencao", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public docfonteretencao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docfonteretencao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FonteRetencaoId ,
                           int aP2_DocumentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FonteRetencaoId = aP1_FonteRetencaoId;
         this.AV8DocumentoId = aP2_DocumentoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            return "docfonteretencao_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedfonteretencaoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockfonteretencaoid_Internalname, "Fonte Retencao", "", "", lblTextblockfonteretencaoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_fonteretencaoid.SetProperty("Caption", Combo_fonteretencaoid_Caption);
         ucCombo_fonteretencaoid.SetProperty("Cls", Combo_fonteretencaoid_Cls);
         ucCombo_fonteretencaoid.SetProperty("DataListProc", Combo_fonteretencaoid_Datalistproc);
         ucCombo_fonteretencaoid.SetProperty("DataListProcParametersPrefix", Combo_fonteretencaoid_Datalistprocparametersprefix);
         ucCombo_fonteretencaoid.SetProperty("EmptyItem", Combo_fonteretencaoid_Emptyitem);
         ucCombo_fonteretencaoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_fonteretencaoid.SetProperty("DropDownOptionsData", AV14FonteRetencaoId_Data);
         ucCombo_fonteretencaoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_fonteretencaoid_Internalname, "COMBO_FONTERETENCAOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFonteRetencaoId_Internalname, "Id da Fonte Retenção", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFonteRetencaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63FonteRetencaoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A63FonteRetencaoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFonteRetencaoId_Jsonclick, 0, "Attribute", "", "", "", "", edtFonteRetencaoId_Visible, edtFonteRetencaoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplitteddocumentoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdocumentoid_Internalname, "Documento", "", "", lblTextblockdocumentoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_documentoid.SetProperty("Caption", Combo_documentoid_Caption);
         ucCombo_documentoid.SetProperty("Cls", Combo_documentoid_Cls);
         ucCombo_documentoid.SetProperty("DataListProc", Combo_documentoid_Datalistproc);
         ucCombo_documentoid.SetProperty("DataListProcParametersPrefix", Combo_documentoid_Datalistprocparametersprefix);
         ucCombo_documentoid.SetProperty("EmptyItem", Combo_documentoid_Emptyitem);
         ucCombo_documentoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_documentoid.SetProperty("DropDownOptionsData", AV22DocumentoId_Data);
         ucCombo_documentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_documentoid_Internalname, "COMBO_DOCUMENTOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentoId_Internalname, "Id do Documento", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, edtDocumentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocFonteRetencao.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_fonteretencaoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombofonteretencaoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboFonteRetencaoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombofonteretencaoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboFonteRetencaoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboFonteRetencaoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombofonteretencaoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombofonteretencaoid_Visible, edtavCombofonteretencaoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_documentoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombodocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ComboDocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombodocumentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23ComboDocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23ComboDocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodocumentoid_Visible, edtavCombodocumentoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocFonteRetencao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11182 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vFONTERETENCAOID_DATA"), AV14FonteRetencaoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDOCUMENTOID_DATA"), AV22DocumentoId_Data);
               /* Read saved values. */
               Z63FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( "Z63FonteRetencaoId"), ",", "."));
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( "Z75DocumentoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( "vFONTERETENCAOID"), ",", "."));
               AV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( "vDOCUMENTOID"), ",", "."));
               Combo_fonteretencaoid_Objectcall = cgiGet( "COMBO_FONTERETENCAOID_Objectcall");
               Combo_fonteretencaoid_Class = cgiGet( "COMBO_FONTERETENCAOID_Class");
               Combo_fonteretencaoid_Icontype = cgiGet( "COMBO_FONTERETENCAOID_Icontype");
               Combo_fonteretencaoid_Icon = cgiGet( "COMBO_FONTERETENCAOID_Icon");
               Combo_fonteretencaoid_Caption = cgiGet( "COMBO_FONTERETENCAOID_Caption");
               Combo_fonteretencaoid_Tooltip = cgiGet( "COMBO_FONTERETENCAOID_Tooltip");
               Combo_fonteretencaoid_Cls = cgiGet( "COMBO_FONTERETENCAOID_Cls");
               Combo_fonteretencaoid_Selectedvalue_set = cgiGet( "COMBO_FONTERETENCAOID_Selectedvalue_set");
               Combo_fonteretencaoid_Selectedvalue_get = cgiGet( "COMBO_FONTERETENCAOID_Selectedvalue_get");
               Combo_fonteretencaoid_Selectedtext_set = cgiGet( "COMBO_FONTERETENCAOID_Selectedtext_set");
               Combo_fonteretencaoid_Selectedtext_get = cgiGet( "COMBO_FONTERETENCAOID_Selectedtext_get");
               Combo_fonteretencaoid_Gamoauthtoken = cgiGet( "COMBO_FONTERETENCAOID_Gamoauthtoken");
               Combo_fonteretencaoid_Ddointernalname = cgiGet( "COMBO_FONTERETENCAOID_Ddointernalname");
               Combo_fonteretencaoid_Titlecontrolalign = cgiGet( "COMBO_FONTERETENCAOID_Titlecontrolalign");
               Combo_fonteretencaoid_Dropdownoptionstype = cgiGet( "COMBO_FONTERETENCAOID_Dropdownoptionstype");
               Combo_fonteretencaoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Enabled"));
               Combo_fonteretencaoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Visible"));
               Combo_fonteretencaoid_Titlecontrolidtoreplace = cgiGet( "COMBO_FONTERETENCAOID_Titlecontrolidtoreplace");
               Combo_fonteretencaoid_Datalisttype = cgiGet( "COMBO_FONTERETENCAOID_Datalisttype");
               Combo_fonteretencaoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Allowmultipleselection"));
               Combo_fonteretencaoid_Datalistfixedvalues = cgiGet( "COMBO_FONTERETENCAOID_Datalistfixedvalues");
               Combo_fonteretencaoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Isgriditem"));
               Combo_fonteretencaoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Hasdescription"));
               Combo_fonteretencaoid_Datalistproc = cgiGet( "COMBO_FONTERETENCAOID_Datalistproc");
               Combo_fonteretencaoid_Datalistprocparametersprefix = cgiGet( "COMBO_FONTERETENCAOID_Datalistprocparametersprefix");
               Combo_fonteretencaoid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_FONTERETENCAOID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_fonteretencaoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Includeonlyselectedoption"));
               Combo_fonteretencaoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Includeselectalloption"));
               Combo_fonteretencaoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Emptyitem"));
               Combo_fonteretencaoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_FONTERETENCAOID_Includeaddnewoption"));
               Combo_fonteretencaoid_Htmltemplate = cgiGet( "COMBO_FONTERETENCAOID_Htmltemplate");
               Combo_fonteretencaoid_Multiplevaluestype = cgiGet( "COMBO_FONTERETENCAOID_Multiplevaluestype");
               Combo_fonteretencaoid_Loadingdata = cgiGet( "COMBO_FONTERETENCAOID_Loadingdata");
               Combo_fonteretencaoid_Noresultsfound = cgiGet( "COMBO_FONTERETENCAOID_Noresultsfound");
               Combo_fonteretencaoid_Emptyitemtext = cgiGet( "COMBO_FONTERETENCAOID_Emptyitemtext");
               Combo_fonteretencaoid_Onlyselectedvalues = cgiGet( "COMBO_FONTERETENCAOID_Onlyselectedvalues");
               Combo_fonteretencaoid_Selectalltext = cgiGet( "COMBO_FONTERETENCAOID_Selectalltext");
               Combo_fonteretencaoid_Multiplevaluesseparator = cgiGet( "COMBO_FONTERETENCAOID_Multiplevaluesseparator");
               Combo_fonteretencaoid_Addnewoptiontext = cgiGet( "COMBO_FONTERETENCAOID_Addnewoptiontext");
               Combo_fonteretencaoid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_FONTERETENCAOID_Gxcontroltype"), ",", "."));
               Combo_documentoid_Objectcall = cgiGet( "COMBO_DOCUMENTOID_Objectcall");
               Combo_documentoid_Class = cgiGet( "COMBO_DOCUMENTOID_Class");
               Combo_documentoid_Icontype = cgiGet( "COMBO_DOCUMENTOID_Icontype");
               Combo_documentoid_Icon = cgiGet( "COMBO_DOCUMENTOID_Icon");
               Combo_documentoid_Caption = cgiGet( "COMBO_DOCUMENTOID_Caption");
               Combo_documentoid_Tooltip = cgiGet( "COMBO_DOCUMENTOID_Tooltip");
               Combo_documentoid_Cls = cgiGet( "COMBO_DOCUMENTOID_Cls");
               Combo_documentoid_Selectedvalue_set = cgiGet( "COMBO_DOCUMENTOID_Selectedvalue_set");
               Combo_documentoid_Selectedvalue_get = cgiGet( "COMBO_DOCUMENTOID_Selectedvalue_get");
               Combo_documentoid_Selectedtext_set = cgiGet( "COMBO_DOCUMENTOID_Selectedtext_set");
               Combo_documentoid_Selectedtext_get = cgiGet( "COMBO_DOCUMENTOID_Selectedtext_get");
               Combo_documentoid_Gamoauthtoken = cgiGet( "COMBO_DOCUMENTOID_Gamoauthtoken");
               Combo_documentoid_Ddointernalname = cgiGet( "COMBO_DOCUMENTOID_Ddointernalname");
               Combo_documentoid_Titlecontrolalign = cgiGet( "COMBO_DOCUMENTOID_Titlecontrolalign");
               Combo_documentoid_Dropdownoptionstype = cgiGet( "COMBO_DOCUMENTOID_Dropdownoptionstype");
               Combo_documentoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Enabled"));
               Combo_documentoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Visible"));
               Combo_documentoid_Titlecontrolidtoreplace = cgiGet( "COMBO_DOCUMENTOID_Titlecontrolidtoreplace");
               Combo_documentoid_Datalisttype = cgiGet( "COMBO_DOCUMENTOID_Datalisttype");
               Combo_documentoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Allowmultipleselection"));
               Combo_documentoid_Datalistfixedvalues = cgiGet( "COMBO_DOCUMENTOID_Datalistfixedvalues");
               Combo_documentoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Isgriditem"));
               Combo_documentoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Hasdescription"));
               Combo_documentoid_Datalistproc = cgiGet( "COMBO_DOCUMENTOID_Datalistproc");
               Combo_documentoid_Datalistprocparametersprefix = cgiGet( "COMBO_DOCUMENTOID_Datalistprocparametersprefix");
               Combo_documentoid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_DOCUMENTOID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_documentoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Includeonlyselectedoption"));
               Combo_documentoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Includeselectalloption"));
               Combo_documentoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Emptyitem"));
               Combo_documentoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOID_Includeaddnewoption"));
               Combo_documentoid_Htmltemplate = cgiGet( "COMBO_DOCUMENTOID_Htmltemplate");
               Combo_documentoid_Multiplevaluestype = cgiGet( "COMBO_DOCUMENTOID_Multiplevaluestype");
               Combo_documentoid_Loadingdata = cgiGet( "COMBO_DOCUMENTOID_Loadingdata");
               Combo_documentoid_Noresultsfound = cgiGet( "COMBO_DOCUMENTOID_Noresultsfound");
               Combo_documentoid_Emptyitemtext = cgiGet( "COMBO_DOCUMENTOID_Emptyitemtext");
               Combo_documentoid_Onlyselectedvalues = cgiGet( "COMBO_DOCUMENTOID_Onlyselectedvalues");
               Combo_documentoid_Selectalltext = cgiGet( "COMBO_DOCUMENTOID_Selectalltext");
               Combo_documentoid_Multiplevaluesseparator = cgiGet( "COMBO_DOCUMENTOID_Multiplevaluesseparator");
               Combo_documentoid_Addnewoptiontext = cgiGet( "COMBO_DOCUMENTOID_Addnewoptiontext");
               Combo_documentoid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_DOCUMENTOID_Gxcontroltype"), ",", "."));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtFonteRetencaoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFonteRetencaoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FONTERETENCAOID");
                  AnyError = 1;
                  GX_FocusControl = edtFonteRetencaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A63FonteRetencaoId = 0;
                  AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               }
               else
               {
                  A63FonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( edtFonteRetencaoId_Internalname), ",", "."));
                  AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCUMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A75DocumentoId = 0;
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               }
               else
               {
                  A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               }
               AV19ComboFonteRetencaoId = (int)(context.localUtil.CToN( cgiGet( edtavCombofonteretencaoid_Internalname), ",", "."));
               AssignAttri("", false, "AV19ComboFonteRetencaoId", StringUtil.LTrimStr( (decimal)(AV19ComboFonteRetencaoId), 8, 0));
               AV23ComboDocumentoId = (int)(context.localUtil.CToN( cgiGet( edtavCombodocumentoid_Internalname), ",", "."));
               AssignAttri("", false, "AV23ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV23ComboDocumentoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"DocFonteRetencao");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("docfonteretencao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
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
                     sMode51 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode51;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound51 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_180( ) ;
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
                           E11182 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12182 ();
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
            E12182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1851( ) ;
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
            DisableAttributes1851( ) ;
         }
         AssignProp("", false, edtavCombofonteretencaoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombofonteretencaoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1851( ) ;
            }
            else
            {
               CheckExtendedTable1851( ) ;
               CloseExtendedTableCursors1851( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption180( )
      {
      }

      protected void E11182( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV21GAMErrors);
         Combo_documentoid_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_documentoid.SendProperty(context, "", false, Combo_documentoid_Internalname, "GAMOAuthToken", Combo_documentoid_Gamoauthtoken);
         edtDocumentoId_Visible = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), true);
         AV23ComboDocumentoId = 0;
         AssignAttri("", false, "AV23ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV23ComboDocumentoId), 8, 0));
         edtavCombodocumentoid_Visible = 0;
         AssignProp("", false, edtavCombodocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Visible), 5, 0), true);
         Combo_fonteretencaoid_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_fonteretencaoid.SendProperty(context, "", false, Combo_fonteretencaoid_Internalname, "GAMOAuthToken", Combo_fonteretencaoid_Gamoauthtoken);
         edtFonteRetencaoId_Visible = 0;
         AssignProp("", false, edtFonteRetencaoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Visible), 5, 0), true);
         AV19ComboFonteRetencaoId = 0;
         AssignAttri("", false, "AV19ComboFonteRetencaoId", StringUtil.LTrimStr( (decimal)(AV19ComboFonteRetencaoId), 8, 0));
         edtavCombofonteretencaoid_Visible = 0;
         AssignProp("", false, edtavCombofonteretencaoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombofonteretencaoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOFONTERETENCAOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBODOCUMENTOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12182( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("docfonteretencaoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBODOCUMENTOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new docfonteretencaoloaddvcombo(context ).execute(  "DocumentoId",  Gx_mode,  false,  AV7FonteRetencaoId,  AV8DocumentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AV18Combo_DataJson = GXt_char2;
         Combo_documentoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_documentoid.SendProperty(context, "", false, Combo_documentoid_Internalname, "SelectedValue_set", Combo_documentoid_Selectedvalue_set);
         Combo_documentoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_documentoid.SendProperty(context, "", false, Combo_documentoid_Internalname, "SelectedText_set", Combo_documentoid_Selectedtext_set);
         AV23ComboDocumentoId = (int)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV23ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV23ComboDocumentoId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV8DocumentoId) )
         {
            Combo_documentoid_Enabled = false;
            ucCombo_documentoid.SendProperty(context, "", false, Combo_documentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOFONTERETENCAOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new docfonteretencaoloaddvcombo(context ).execute(  "FonteRetencaoId",  Gx_mode,  false,  AV7FonteRetencaoId,  AV8DocumentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AV18Combo_DataJson = GXt_char2;
         Combo_fonteretencaoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_fonteretencaoid.SendProperty(context, "", false, Combo_fonteretencaoid_Internalname, "SelectedValue_set", Combo_fonteretencaoid_Selectedvalue_set);
         Combo_fonteretencaoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_fonteretencaoid.SendProperty(context, "", false, Combo_fonteretencaoid_Internalname, "SelectedText_set", Combo_fonteretencaoid_Selectedtext_set);
         AV19ComboFonteRetencaoId = (int)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV19ComboFonteRetencaoId", StringUtil.LTrimStr( (decimal)(AV19ComboFonteRetencaoId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7FonteRetencaoId) )
         {
            Combo_fonteretencaoid_Enabled = false;
            ucCombo_fonteretencaoid.SendProperty(context, "", false, Combo_fonteretencaoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_fonteretencaoid_Enabled));
         }
      }

      protected void ZM1851( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -7 )
         {
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FonteRetencaoId) )
         {
            edtFonteRetencaoId_Enabled = 0;
            AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
         }
         else
         {
            edtFonteRetencaoId_Enabled = 1;
            AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7FonteRetencaoId) )
         {
            edtFonteRetencaoId_Enabled = 0;
            AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8DocumentoId) )
         {
            edtDocumentoId_Enabled = 0;
            AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocumentoId_Enabled = 1;
            AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8DocumentoId) )
         {
            edtDocumentoId_Enabled = 0;
            AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8DocumentoId) )
         {
            A75DocumentoId = AV8DocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         else
         {
            A75DocumentoId = AV23ComboDocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         if ( ! (0==AV7FonteRetencaoId) )
         {
            A63FonteRetencaoId = AV7FonteRetencaoId;
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
         }
         else
         {
            A63FonteRetencaoId = AV19ComboFonteRetencaoId;
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
      }

      protected void Load1851( )
      {
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound51 = 1;
            ZM1851( -7) ;
         }
         pr_default.close(4);
         OnLoadActions1851( ) ;
      }

      protected void OnLoadActions1851( )
      {
      }

      protected void CheckExtendedTable1851( )
      {
         nIsDirty_51 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Fonte Retencao'.", "ForeignKeyNotFound", 1, "FONTERETENCAOID");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1851( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( int A63FonteRetencaoId )
      {
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Fonte Retencao'.", "ForeignKeyNotFound", 1, "FONTERETENCAOID");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_9( int A75DocumentoId )
      {
         /* Using cursor T00188 */
         pr_default.execute(6, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1851( )
      {
         /* Using cursor T00189 */
         pr_default.execute(7, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1851( 7) ;
            RcdFound51 = 1;
            A63FonteRetencaoId = T00183_A63FonteRetencaoId[0];
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            A75DocumentoId = T00183_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z75DocumentoId = A75DocumentoId;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1851( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey1851( ) ;
            }
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey1851( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1851( ) ;
         if ( RcdFound51 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound51 = 0;
         /* Using cursor T001810 */
         pr_default.execute(8, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001810_A63FonteRetencaoId[0] < A63FonteRetencaoId ) || ( T001810_A63FonteRetencaoId[0] == A63FonteRetencaoId ) && ( T001810_A75DocumentoId[0] < A75DocumentoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001810_A63FonteRetencaoId[0] > A63FonteRetencaoId ) || ( T001810_A63FonteRetencaoId[0] == A63FonteRetencaoId ) && ( T001810_A75DocumentoId[0] > A75DocumentoId ) ) )
            {
               A63FonteRetencaoId = T001810_A63FonteRetencaoId[0];
               AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               A75DocumentoId = T001810_A75DocumentoId[0];
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               RcdFound51 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound51 = 0;
         /* Using cursor T001811 */
         pr_default.execute(9, new Object[] {A63FonteRetencaoId, A75DocumentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001811_A63FonteRetencaoId[0] > A63FonteRetencaoId ) || ( T001811_A63FonteRetencaoId[0] == A63FonteRetencaoId ) && ( T001811_A75DocumentoId[0] > A75DocumentoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001811_A63FonteRetencaoId[0] < A63FonteRetencaoId ) || ( T001811_A63FonteRetencaoId[0] == A63FonteRetencaoId ) && ( T001811_A75DocumentoId[0] < A75DocumentoId ) ) )
            {
               A63FonteRetencaoId = T001811_A63FonteRetencaoId[0];
               AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
               A75DocumentoId = T001811_A75DocumentoId[0];
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               RcdFound51 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1851( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1851( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A63FonteRetencaoId = Z63FonteRetencaoId;
                  AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
                  A75DocumentoId = Z75DocumentoId;
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FONTERETENCAOID");
                  AnyError = 1;
                  GX_FocusControl = edtFonteRetencaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFonteRetencaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1851( ) ;
                  GX_FocusControl = edtFonteRetencaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtFonteRetencaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1851( ) ;
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
                     GX_FocusControl = edtFonteRetencaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1851( ) ;
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
         if ( ( A63FonteRetencaoId != Z63FonteRetencaoId ) || ( A75DocumentoId != Z75DocumentoId ) )
         {
            A63FonteRetencaoId = Z63FonteRetencaoId;
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            A75DocumentoId = Z75DocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FONTERETENCAOID");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFonteRetencaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1851( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A63FonteRetencaoId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocFonteRetencao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocFonteRetencao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1851( )
      {
         if ( ! IsAuthorized("docfonteretencao_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1851( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1851( 0) ;
            CheckOptimisticConcurrency1851( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1851( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1851( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001812 */
                     pr_default.execute(10, new Object[] {A63FonteRetencaoId, A75DocumentoId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("DocFonteRetencao");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption180( ) ;
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
               Load1851( ) ;
            }
            EndLevel1851( ) ;
         }
         CloseExtendedTableCursors1851( ) ;
      }

      protected void Update1851( )
      {
         if ( ! IsAuthorized("docfonteretencao_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1851( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1851( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1851( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1851( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocFonteRetencao] */
                     DeferredUpdate1851( ) ;
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
            EndLevel1851( ) ;
         }
         CloseExtendedTableCursors1851( ) ;
      }

      protected void DeferredUpdate1851( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("docfonteretencao_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1851( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1851( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1851( ) ;
            AfterConfirm1851( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1851( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001813 */
                  pr_default.execute(11, new Object[] {A63FonteRetencaoId, A75DocumentoId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("DocFonteRetencao");
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
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1851( ) ;
         Gx_mode = sMode51;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1851( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1851( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1851( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("docfonteretencao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("docfonteretencao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1851( )
      {
         /* Scan By routine */
         /* Using cursor T001814 */
         pr_default.execute(12);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound51 = 1;
            A63FonteRetencaoId = T001814_A63FonteRetencaoId[0];
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            A75DocumentoId = T001814_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1851( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound51 = 1;
            A63FonteRetencaoId = T001814_A63FonteRetencaoId[0];
            AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
            A75DocumentoId = T001814_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
      }

      protected void ScanEnd1851( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1851( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1851( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1851( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1851( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1851( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1851( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1851( )
      {
         edtFonteRetencaoId_Enabled = 0;
         AssignProp("", false, edtFonteRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFonteRetencaoId_Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtavCombofonteretencaoid_Enabled = 0;
         AssignProp("", false, edtavCombofonteretencaoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombofonteretencaoid_Enabled), 5, 0), true);
         edtavCombodocumentoid_Enabled = 0;
         AssignProp("", false, edtavCombodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1851( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "docfonteretencao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FonteRetencaoId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docfonteretencao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"DocFonteRetencao");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("docfonteretencao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z63FonteRetencaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63FonteRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFONTERETENCAOID_DATA", AV14FonteRetencaoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFONTERETENCAOID_DATA", AV14FonteRetencaoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCUMENTOID_DATA", AV22DocumentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCUMENTOID_DATA", AV22DocumentoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vFONTERETENCAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FonteRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFONTERETENCAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FonteRetencaoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Objectcall", StringUtil.RTrim( Combo_fonteretencaoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Cls", StringUtil.RTrim( Combo_fonteretencaoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Selectedvalue_set", StringUtil.RTrim( Combo_fonteretencaoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Selectedtext_set", StringUtil.RTrim( Combo_fonteretencaoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Gamoauthtoken", StringUtil.RTrim( Combo_fonteretencaoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Enabled", StringUtil.BoolToStr( Combo_fonteretencaoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Datalistproc", StringUtil.RTrim( Combo_fonteretencaoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_fonteretencaoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_FONTERETENCAOID_Emptyitem", StringUtil.BoolToStr( Combo_fonteretencaoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Objectcall", StringUtil.RTrim( Combo_documentoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Cls", StringUtil.RTrim( Combo_documentoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_documentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Selectedtext_set", StringUtil.RTrim( Combo_documentoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Gamoauthtoken", StringUtil.RTrim( Combo_documentoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Datalistproc", StringUtil.RTrim( Combo_documentoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_documentoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOID_Emptyitem", StringUtil.BoolToStr( Combo_documentoid_Emptyitem));
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
         GXEncryptionTmp = "docfonteretencao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FonteRetencaoId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0));
         return formatLink("docfonteretencao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "DocFonteRetencao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Fonte Retencao" ;
      }

      protected void InitializeNonKey1851( )
      {
      }

      protected void InitAll1851( )
      {
         A63FonteRetencaoId = 0;
         AssignAttri("", false, "A63FonteRetencaoId", StringUtil.LTrimStr( (decimal)(A63FonteRetencaoId), 8, 0));
         A75DocumentoId = 0;
         AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         InitializeNonKey1851( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417265311", true, true);
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
         context.AddJavascriptSource("docfonteretencao.js", "?202312417265311", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblockfonteretencaoid_Internalname = "TEXTBLOCKFONTERETENCAOID";
         Combo_fonteretencaoid_Internalname = "COMBO_FONTERETENCAOID";
         edtFonteRetencaoId_Internalname = "FONTERETENCAOID";
         divTablesplittedfonteretencaoid_Internalname = "TABLESPLITTEDFONTERETENCAOID";
         lblTextblockdocumentoid_Internalname = "TEXTBLOCKDOCUMENTOID";
         Combo_documentoid_Internalname = "COMBO_DOCUMENTOID";
         edtDocumentoId_Internalname = "DOCUMENTOID";
         divTablesplitteddocumentoid_Internalname = "TABLESPLITTEDDOCUMENTOID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombofonteretencaoid_Internalname = "vCOMBOFONTERETENCAOID";
         divSectionattribute_fonteretencaoid_Internalname = "SECTIONATTRIBUTE_FONTERETENCAOID";
         edtavCombodocumentoid_Internalname = "vCOMBODOCUMENTOID";
         divSectionattribute_documentoid_Internalname = "SECTIONATTRIBUTE_DOCUMENTOID";
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
         Form.Caption = "Doc Fonte Retencao";
         edtavCombodocumentoid_Jsonclick = "";
         edtavCombodocumentoid_Enabled = 0;
         edtavCombodocumentoid_Visible = 1;
         edtavCombofonteretencaoid_Jsonclick = "";
         edtavCombofonteretencaoid_Enabled = 0;
         edtavCombofonteretencaoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 1;
         edtDocumentoId_Visible = 1;
         Combo_documentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_documentoid_Datalistprocparametersprefix = " \"ComboName\": \"DocumentoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"FonteRetencaoId\": 0, \"DocumentoId\": 0";
         Combo_documentoid_Datalistproc = "DocFonteRetencaoLoadDVCombo";
         Combo_documentoid_Cls = "ExtendedCombo AttributeFL";
         Combo_documentoid_Caption = "";
         Combo_documentoid_Enabled = Convert.ToBoolean( -1);
         edtFonteRetencaoId_Jsonclick = "";
         edtFonteRetencaoId_Enabled = 1;
         edtFonteRetencaoId_Visible = 1;
         Combo_fonteretencaoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_fonteretencaoid_Datalistprocparametersprefix = " \"ComboName\": \"FonteRetencaoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"FonteRetencaoId\": 0, \"DocumentoId\": 0";
         Combo_fonteretencaoid_Datalistproc = "DocFonteRetencaoLoadDVCombo";
         Combo_fonteretencaoid_Cls = "ExtendedCombo AttributeFL";
         Combo_fonteretencaoid_Caption = "";
         Combo_fonteretencaoid_Enabled = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
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

      public void Valid_Fonteretencaoid( )
      {
         /* Using cursor T001815 */
         pr_default.execute(13, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Fonte Retencao'.", "ForeignKeyNotFound", 1, "FONTERETENCAOID");
            AnyError = 1;
            GX_FocusControl = edtFonteRetencaoId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Documentoid( )
      {
         /* Using cursor T001816 */
         pr_default.execute(14, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FonteRetencaoId',fld:'vFONTERETENCAOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FonteRetencaoId',fld:'vFONTERETENCAOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12182',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FONTERETENCAOID","{handler:'Valid_Fonteretencaoid',iparms:[{av:'A63FonteRetencaoId',fld:'FONTERETENCAOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_FONTERETENCAOID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOFONTERETENCAOID","{handler:'Validv_Combofonteretencaoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOFONTERETENCAOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBODOCUMENTOID","{handler:'Validv_Combodocumentoid',iparms:[]");
         setEventMetadata("VALIDV_COMBODOCUMENTOID",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Combo_documentoid_Selectedvalue_get = "";
         Combo_fonteretencaoid_Selectedvalue_get = "";
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
         lblTextblockfonteretencaoid_Jsonclick = "";
         ucCombo_fonteretencaoid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14FonteRetencaoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockdocumentoid_Jsonclick = "";
         ucCombo_documentoid = new GXUserControl();
         AV22DocumentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Combo_fonteretencaoid_Objectcall = "";
         Combo_fonteretencaoid_Class = "";
         Combo_fonteretencaoid_Icontype = "";
         Combo_fonteretencaoid_Icon = "";
         Combo_fonteretencaoid_Tooltip = "";
         Combo_fonteretencaoid_Selectedvalue_set = "";
         Combo_fonteretencaoid_Selectedtext_set = "";
         Combo_fonteretencaoid_Selectedtext_get = "";
         Combo_fonteretencaoid_Gamoauthtoken = "";
         Combo_fonteretencaoid_Ddointernalname = "";
         Combo_fonteretencaoid_Titlecontrolalign = "";
         Combo_fonteretencaoid_Dropdownoptionstype = "";
         Combo_fonteretencaoid_Titlecontrolidtoreplace = "";
         Combo_fonteretencaoid_Datalisttype = "";
         Combo_fonteretencaoid_Datalistfixedvalues = "";
         Combo_fonteretencaoid_Htmltemplate = "";
         Combo_fonteretencaoid_Multiplevaluestype = "";
         Combo_fonteretencaoid_Loadingdata = "";
         Combo_fonteretencaoid_Noresultsfound = "";
         Combo_fonteretencaoid_Emptyitemtext = "";
         Combo_fonteretencaoid_Onlyselectedvalues = "";
         Combo_fonteretencaoid_Selectalltext = "";
         Combo_fonteretencaoid_Multiplevaluesseparator = "";
         Combo_fonteretencaoid_Addnewoptiontext = "";
         Combo_documentoid_Objectcall = "";
         Combo_documentoid_Class = "";
         Combo_documentoid_Icontype = "";
         Combo_documentoid_Icon = "";
         Combo_documentoid_Tooltip = "";
         Combo_documentoid_Selectedvalue_set = "";
         Combo_documentoid_Selectedtext_set = "";
         Combo_documentoid_Selectedtext_get = "";
         Combo_documentoid_Gamoauthtoken = "";
         Combo_documentoid_Ddointernalname = "";
         Combo_documentoid_Titlecontrolalign = "";
         Combo_documentoid_Dropdownoptionstype = "";
         Combo_documentoid_Titlecontrolidtoreplace = "";
         Combo_documentoid_Datalisttype = "";
         Combo_documentoid_Datalistfixedvalues = "";
         Combo_documentoid_Htmltemplate = "";
         Combo_documentoid_Multiplevaluestype = "";
         Combo_documentoid_Loadingdata = "";
         Combo_documentoid_Noresultsfound = "";
         Combo_documentoid_Emptyitemtext = "";
         Combo_documentoid_Onlyselectedvalues = "";
         Combo_documentoid_Selectalltext = "";
         Combo_documentoid_Multiplevaluesseparator = "";
         Combo_documentoid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode51 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV21GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         T00186_A63FonteRetencaoId = new int[1] ;
         T00186_A75DocumentoId = new int[1] ;
         T00184_A63FonteRetencaoId = new int[1] ;
         T00185_A75DocumentoId = new int[1] ;
         T00187_A63FonteRetencaoId = new int[1] ;
         T00188_A75DocumentoId = new int[1] ;
         T00189_A63FonteRetencaoId = new int[1] ;
         T00189_A75DocumentoId = new int[1] ;
         T00183_A63FonteRetencaoId = new int[1] ;
         T00183_A75DocumentoId = new int[1] ;
         T001810_A63FonteRetencaoId = new int[1] ;
         T001810_A75DocumentoId = new int[1] ;
         T001811_A63FonteRetencaoId = new int[1] ;
         T001811_A75DocumentoId = new int[1] ;
         T00182_A63FonteRetencaoId = new int[1] ;
         T00182_A75DocumentoId = new int[1] ;
         T001814_A63FonteRetencaoId = new int[1] ;
         T001814_A75DocumentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001815_A63FonteRetencaoId = new int[1] ;
         T001816_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docfonteretencao__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docfonteretencao__default(),
            new Object[][] {
                new Object[] {
               T00182_A63FonteRetencaoId, T00182_A75DocumentoId
               }
               , new Object[] {
               T00183_A63FonteRetencaoId, T00183_A75DocumentoId
               }
               , new Object[] {
               T00184_A63FonteRetencaoId
               }
               , new Object[] {
               T00185_A75DocumentoId
               }
               , new Object[] {
               T00186_A63FonteRetencaoId, T00186_A75DocumentoId
               }
               , new Object[] {
               T00187_A63FonteRetencaoId
               }
               , new Object[] {
               T00188_A75DocumentoId
               }
               , new Object[] {
               T00189_A63FonteRetencaoId, T00189_A75DocumentoId
               }
               , new Object[] {
               T001810_A63FonteRetencaoId, T001810_A75DocumentoId
               }
               , new Object[] {
               T001811_A63FonteRetencaoId, T001811_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001814_A63FonteRetencaoId, T001814_A75DocumentoId
               }
               , new Object[] {
               T001815_A63FonteRetencaoId
               }
               , new Object[] {
               T001816_A75DocumentoId
               }
            }
         );
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound51 ;
      private short GX_JID ;
      private short nIsDirty_51 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7FonteRetencaoId ;
      private int wcpOAV8DocumentoId ;
      private int Z63FonteRetencaoId ;
      private int Z75DocumentoId ;
      private int A63FonteRetencaoId ;
      private int A75DocumentoId ;
      private int AV7FonteRetencaoId ;
      private int AV8DocumentoId ;
      private int trnEnded ;
      private int edtFonteRetencaoId_Visible ;
      private int edtFonteRetencaoId_Enabled ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboFonteRetencaoId ;
      private int edtavCombofonteretencaoid_Enabled ;
      private int edtavCombofonteretencaoid_Visible ;
      private int AV23ComboDocumentoId ;
      private int edtavCombodocumentoid_Enabled ;
      private int edtavCombodocumentoid_Visible ;
      private int Combo_fonteretencaoid_Datalistupdateminimumcharacters ;
      private int Combo_fonteretencaoid_Gxcontroltype ;
      private int Combo_documentoid_Datalistupdateminimumcharacters ;
      private int Combo_documentoid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_documentoid_Selectedvalue_get ;
      private string Combo_fonteretencaoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFonteRetencaoId_Internalname ;
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
      private string divTablesplittedfonteretencaoid_Internalname ;
      private string lblTextblockfonteretencaoid_Internalname ;
      private string lblTextblockfonteretencaoid_Jsonclick ;
      private string Combo_fonteretencaoid_Caption ;
      private string Combo_fonteretencaoid_Cls ;
      private string Combo_fonteretencaoid_Datalistproc ;
      private string Combo_fonteretencaoid_Datalistprocparametersprefix ;
      private string Combo_fonteretencaoid_Internalname ;
      private string TempTags ;
      private string edtFonteRetencaoId_Jsonclick ;
      private string divTablesplitteddocumentoid_Internalname ;
      private string lblTextblockdocumentoid_Internalname ;
      private string lblTextblockdocumentoid_Jsonclick ;
      private string Combo_documentoid_Caption ;
      private string Combo_documentoid_Cls ;
      private string Combo_documentoid_Datalistproc ;
      private string Combo_documentoid_Datalistprocparametersprefix ;
      private string Combo_documentoid_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_fonteretencaoid_Internalname ;
      private string edtavCombofonteretencaoid_Internalname ;
      private string edtavCombofonteretencaoid_Jsonclick ;
      private string divSectionattribute_documentoid_Internalname ;
      private string edtavCombodocumentoid_Internalname ;
      private string edtavCombodocumentoid_Jsonclick ;
      private string Combo_fonteretencaoid_Objectcall ;
      private string Combo_fonteretencaoid_Class ;
      private string Combo_fonteretencaoid_Icontype ;
      private string Combo_fonteretencaoid_Icon ;
      private string Combo_fonteretencaoid_Tooltip ;
      private string Combo_fonteretencaoid_Selectedvalue_set ;
      private string Combo_fonteretencaoid_Selectedtext_set ;
      private string Combo_fonteretencaoid_Selectedtext_get ;
      private string Combo_fonteretencaoid_Gamoauthtoken ;
      private string Combo_fonteretencaoid_Ddointernalname ;
      private string Combo_fonteretencaoid_Titlecontrolalign ;
      private string Combo_fonteretencaoid_Dropdownoptionstype ;
      private string Combo_fonteretencaoid_Titlecontrolidtoreplace ;
      private string Combo_fonteretencaoid_Datalisttype ;
      private string Combo_fonteretencaoid_Datalistfixedvalues ;
      private string Combo_fonteretencaoid_Htmltemplate ;
      private string Combo_fonteretencaoid_Multiplevaluestype ;
      private string Combo_fonteretencaoid_Loadingdata ;
      private string Combo_fonteretencaoid_Noresultsfound ;
      private string Combo_fonteretencaoid_Emptyitemtext ;
      private string Combo_fonteretencaoid_Onlyselectedvalues ;
      private string Combo_fonteretencaoid_Selectalltext ;
      private string Combo_fonteretencaoid_Multiplevaluesseparator ;
      private string Combo_fonteretencaoid_Addnewoptiontext ;
      private string Combo_documentoid_Objectcall ;
      private string Combo_documentoid_Class ;
      private string Combo_documentoid_Icontype ;
      private string Combo_documentoid_Icon ;
      private string Combo_documentoid_Tooltip ;
      private string Combo_documentoid_Selectedvalue_set ;
      private string Combo_documentoid_Selectedtext_set ;
      private string Combo_documentoid_Selectedtext_get ;
      private string Combo_documentoid_Gamoauthtoken ;
      private string Combo_documentoid_Ddointernalname ;
      private string Combo_documentoid_Titlecontrolalign ;
      private string Combo_documentoid_Dropdownoptionstype ;
      private string Combo_documentoid_Titlecontrolidtoreplace ;
      private string Combo_documentoid_Datalisttype ;
      private string Combo_documentoid_Datalistfixedvalues ;
      private string Combo_documentoid_Htmltemplate ;
      private string Combo_documentoid_Multiplevaluestype ;
      private string Combo_documentoid_Loadingdata ;
      private string Combo_documentoid_Noresultsfound ;
      private string Combo_documentoid_Emptyitemtext ;
      private string Combo_documentoid_Onlyselectedvalues ;
      private string Combo_documentoid_Selectalltext ;
      private string Combo_documentoid_Multiplevaluesseparator ;
      private string Combo_documentoid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode51 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_fonteretencaoid_Emptyitem ;
      private bool Combo_documentoid_Emptyitem ;
      private bool Combo_fonteretencaoid_Enabled ;
      private bool Combo_fonteretencaoid_Visible ;
      private bool Combo_fonteretencaoid_Allowmultipleselection ;
      private bool Combo_fonteretencaoid_Isgriditem ;
      private bool Combo_fonteretencaoid_Hasdescription ;
      private bool Combo_fonteretencaoid_Includeonlyselectedoption ;
      private bool Combo_fonteretencaoid_Includeselectalloption ;
      private bool Combo_fonteretencaoid_Includeaddnewoption ;
      private bool Combo_documentoid_Enabled ;
      private bool Combo_documentoid_Visible ;
      private bool Combo_documentoid_Allowmultipleselection ;
      private bool Combo_documentoid_Isgriditem ;
      private bool Combo_documentoid_Hasdescription ;
      private bool Combo_documentoid_Includeonlyselectedoption ;
      private bool Combo_documentoid_Includeselectalloption ;
      private bool Combo_documentoid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_fonteretencaoid ;
      private GXUserControl ucCombo_documentoid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00186_A63FonteRetencaoId ;
      private int[] T00186_A75DocumentoId ;
      private int[] T00184_A63FonteRetencaoId ;
      private int[] T00185_A75DocumentoId ;
      private int[] T00187_A63FonteRetencaoId ;
      private int[] T00188_A75DocumentoId ;
      private int[] T00189_A63FonteRetencaoId ;
      private int[] T00189_A75DocumentoId ;
      private int[] T00183_A63FonteRetencaoId ;
      private int[] T00183_A75DocumentoId ;
      private int[] T001810_A63FonteRetencaoId ;
      private int[] T001810_A75DocumentoId ;
      private int[] T001811_A63FonteRetencaoId ;
      private int[] T001811_A75DocumentoId ;
      private int[] T00182_A63FonteRetencaoId ;
      private int[] T00182_A75DocumentoId ;
      private int[] T001814_A63FonteRetencaoId ;
      private int[] T001814_A75DocumentoId ;
      private int[] T001815_A63FonteRetencaoId ;
      private int[] T001816_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14FonteRetencaoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22DocumentoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV21GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV20GAMSession ;
   }

   public class docfonteretencao__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docfonteretencao__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
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
        Object[] prmT00186;
        prmT00186 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00184;
        prmT00184 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT00185;
        prmT00185 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00187;
        prmT00187 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT00188;
        prmT00188 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00189;
        prmT00189 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00183;
        prmT00183 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001810;
        prmT001810 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001811;
        prmT001811 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00182;
        prmT00182 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001812;
        prmT001812 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001813;
        prmT001813 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001814;
        prmT001814 = new Object[] {
        };
        Object[] prmT001815;
        prmT001815 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmT001816;
        prmT001816 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00182", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WITH (UPDLOCK) WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00183", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00184", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00185", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00186", "SELECT TM1.[FonteRetencaoId], TM1.[DocumentoId] FROM [DocFonteRetencao] TM1 WHERE TM1.[FonteRetencaoId] = @FonteRetencaoId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[FonteRetencaoId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00187", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00188", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00188,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00189", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00189,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001810", "SELECT TOP 1 [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE ( [FonteRetencaoId] > @FonteRetencaoId or [FonteRetencaoId] = @FonteRetencaoId and [DocumentoId] > @DocumentoId) ORDER BY [FonteRetencaoId], [DocumentoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001811", "SELECT TOP 1 [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE ( [FonteRetencaoId] < @FonteRetencaoId or [FonteRetencaoId] = @FonteRetencaoId and [DocumentoId] < @DocumentoId) ORDER BY [FonteRetencaoId] DESC, [DocumentoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001812", "INSERT INTO [DocFonteRetencao]([FonteRetencaoId], [DocumentoId]) VALUES(@FonteRetencaoId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmT001812)
           ,new CursorDef("T001813", "DELETE FROM [DocFonteRetencao]  WHERE [FonteRetencaoId] = @FonteRetencaoId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmT001813)
           ,new CursorDef("T001814", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] ORDER BY [FonteRetencaoId], [DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001814,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001815", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001816", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001816,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
