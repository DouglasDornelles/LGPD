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
   public class docenvolvidoscoleta : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A54EnvolvidosColetaId = (int)(NumberUtil.Val( GetPar( "EnvolvidosColetaId"), "."));
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A54EnvolvidosColetaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docenvolvidoscoleta.aspx")), "docenvolvidoscoleta.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docenvolvidoscoleta.aspx")))) ;
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
                  AV7EnvolvidosColetaId = (int)(NumberUtil.Val( GetPar( "EnvolvidosColetaId"), "."));
                  AssignAttri("", false, "AV7EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(AV7EnvolvidosColetaId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vENVOLVIDOSCOLETAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EnvolvidosColetaId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Doc Envolvidos Coleta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public docenvolvidoscoleta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docenvolvidoscoleta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_EnvolvidosColetaId ,
                           int aP2_DocumentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EnvolvidosColetaId = aP1_EnvolvidosColetaId;
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
            return "docenvolvidoscoleta_Execute" ;
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
         GxWebStd.gx_div_start( context, divTablesplittedenvolvidoscoletaid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockenvolvidoscoletaid_Internalname, "Envolvidos Coleta", "", "", lblTextblockenvolvidoscoletaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocEnvolvidosColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_envolvidoscoletaid.SetProperty("Caption", Combo_envolvidoscoletaid_Caption);
         ucCombo_envolvidoscoletaid.SetProperty("Cls", Combo_envolvidoscoletaid_Cls);
         ucCombo_envolvidoscoletaid.SetProperty("DataListProc", Combo_envolvidoscoletaid_Datalistproc);
         ucCombo_envolvidoscoletaid.SetProperty("DataListProcParametersPrefix", Combo_envolvidoscoletaid_Datalistprocparametersprefix);
         ucCombo_envolvidoscoletaid.SetProperty("EmptyItem", Combo_envolvidoscoletaid_Emptyitem);
         ucCombo_envolvidoscoletaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_envolvidoscoletaid.SetProperty("DropDownOptionsData", AV14EnvolvidosColetaId_Data);
         ucCombo_envolvidoscoletaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_envolvidoscoletaid_Internalname, "COMBO_ENVOLVIDOSCOLETAIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnvolvidosColetaId_Internalname, "Id da Envolvidos Coleta", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnvolvidosColetaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A54EnvolvidosColetaId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A54EnvolvidosColetaId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnvolvidosColetaId_Jsonclick, 0, "Attribute", "", "", "", "", edtEnvolvidosColetaId_Visible, edtEnvolvidosColetaId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocEnvolvidosColeta.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockdocumentoid_Internalname, "Documento", "", "", lblTextblockdocumentoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocEnvolvidosColeta.htm");
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
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, edtDocumentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocEnvolvidosColeta.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocEnvolvidosColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocEnvolvidosColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocEnvolvidosColeta.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_envolvidoscoletaid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboenvolvidoscoletaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboEnvolvidosColetaId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavComboenvolvidoscoletaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboEnvolvidosColetaId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboEnvolvidosColetaId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboenvolvidoscoletaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboenvolvidoscoletaid_Visible, edtavComboenvolvidoscoletaid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocEnvolvidosColeta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_documentoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombodocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ComboDocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombodocumentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23ComboDocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23ComboDocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodocumentoid_Visible, edtavCombodocumentoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocEnvolvidosColeta.htm");
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
         E11152 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vENVOLVIDOSCOLETAID_DATA"), AV14EnvolvidosColetaId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDOCUMENTOID_DATA"), AV22DocumentoId_Data);
               /* Read saved values. */
               Z54EnvolvidosColetaId = (int)(context.localUtil.CToN( cgiGet( "Z54EnvolvidosColetaId"), ",", "."));
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( "Z75DocumentoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7EnvolvidosColetaId = (int)(context.localUtil.CToN( cgiGet( "vENVOLVIDOSCOLETAID"), ",", "."));
               AV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( "vDOCUMENTOID"), ",", "."));
               Combo_envolvidoscoletaid_Objectcall = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Objectcall");
               Combo_envolvidoscoletaid_Class = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Class");
               Combo_envolvidoscoletaid_Icontype = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Icontype");
               Combo_envolvidoscoletaid_Icon = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Icon");
               Combo_envolvidoscoletaid_Caption = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Caption");
               Combo_envolvidoscoletaid_Tooltip = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Tooltip");
               Combo_envolvidoscoletaid_Cls = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Cls");
               Combo_envolvidoscoletaid_Selectedvalue_set = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_set");
               Combo_envolvidoscoletaid_Selectedvalue_get = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_get");
               Combo_envolvidoscoletaid_Selectedtext_set = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Selectedtext_set");
               Combo_envolvidoscoletaid_Selectedtext_get = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Selectedtext_get");
               Combo_envolvidoscoletaid_Gamoauthtoken = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Gamoauthtoken");
               Combo_envolvidoscoletaid_Ddointernalname = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Ddointernalname");
               Combo_envolvidoscoletaid_Titlecontrolalign = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Titlecontrolalign");
               Combo_envolvidoscoletaid_Dropdownoptionstype = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Dropdownoptionstype");
               Combo_envolvidoscoletaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Enabled"));
               Combo_envolvidoscoletaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Visible"));
               Combo_envolvidoscoletaid_Titlecontrolidtoreplace = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Titlecontrolidtoreplace");
               Combo_envolvidoscoletaid_Datalisttype = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Datalisttype");
               Combo_envolvidoscoletaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Allowmultipleselection"));
               Combo_envolvidoscoletaid_Datalistfixedvalues = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Datalistfixedvalues");
               Combo_envolvidoscoletaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Isgriditem"));
               Combo_envolvidoscoletaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Hasdescription"));
               Combo_envolvidoscoletaid_Datalistproc = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Datalistproc");
               Combo_envolvidoscoletaid_Datalistprocparametersprefix = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Datalistprocparametersprefix");
               Combo_envolvidoscoletaid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_envolvidoscoletaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Includeonlyselectedoption"));
               Combo_envolvidoscoletaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Includeselectalloption"));
               Combo_envolvidoscoletaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Emptyitem"));
               Combo_envolvidoscoletaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Includeaddnewoption"));
               Combo_envolvidoscoletaid_Htmltemplate = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Htmltemplate");
               Combo_envolvidoscoletaid_Multiplevaluestype = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Multiplevaluestype");
               Combo_envolvidoscoletaid_Loadingdata = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Loadingdata");
               Combo_envolvidoscoletaid_Noresultsfound = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Noresultsfound");
               Combo_envolvidoscoletaid_Emptyitemtext = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Emptyitemtext");
               Combo_envolvidoscoletaid_Onlyselectedvalues = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Onlyselectedvalues");
               Combo_envolvidoscoletaid_Selectalltext = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Selectalltext");
               Combo_envolvidoscoletaid_Multiplevaluesseparator = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Multiplevaluesseparator");
               Combo_envolvidoscoletaid_Addnewoptiontext = cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Addnewoptiontext");
               Combo_envolvidoscoletaid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_ENVOLVIDOSCOLETAID_Gxcontroltype"), ",", "."));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtEnvolvidosColetaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEnvolvidosColetaId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ENVOLVIDOSCOLETAID");
                  AnyError = 1;
                  GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A54EnvolvidosColetaId = 0;
                  AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
               }
               else
               {
                  A54EnvolvidosColetaId = (int)(context.localUtil.CToN( cgiGet( edtEnvolvidosColetaId_Internalname), ",", "."));
                  AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
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
               AV19ComboEnvolvidosColetaId = (int)(context.localUtil.CToN( cgiGet( edtavComboenvolvidoscoletaid_Internalname), ",", "."));
               AssignAttri("", false, "AV19ComboEnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(AV19ComboEnvolvidosColetaId), 8, 0));
               AV23ComboDocumentoId = (int)(context.localUtil.CToN( cgiGet( edtavCombodocumentoid_Internalname), ",", "."));
               AssignAttri("", false, "AV23ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV23ComboDocumentoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"DocEnvolvidosColeta");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("docenvolvidoscoleta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A54EnvolvidosColetaId = (int)(NumberUtil.Val( GetPar( "EnvolvidosColetaId"), "."));
                  AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
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
                     sMode48 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode48;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound48 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_150( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ENVOLVIDOSCOLETAID");
                        AnyError = 1;
                        GX_FocusControl = edtEnvolvidosColetaId_Internalname;
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
                           E11152 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12152 ();
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
            E12152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1548( ) ;
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
            DisableAttributes1548( ) ;
         }
         AssignProp("", false, edtavComboenvolvidoscoletaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboenvolvidoscoletaid_Enabled), 5, 0), true);
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1548( ) ;
            }
            else
            {
               CheckExtendedTable1548( ) ;
               CloseExtendedTableCursors1548( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption150( )
      {
      }

      protected void E11152( )
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
         Combo_envolvidoscoletaid_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_envolvidoscoletaid.SendProperty(context, "", false, Combo_envolvidoscoletaid_Internalname, "GAMOAuthToken", Combo_envolvidoscoletaid_Gamoauthtoken);
         edtEnvolvidosColetaId_Visible = 0;
         AssignProp("", false, edtEnvolvidosColetaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEnvolvidosColetaId_Visible), 5, 0), true);
         AV19ComboEnvolvidosColetaId = 0;
         AssignAttri("", false, "AV19ComboEnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(AV19ComboEnvolvidosColetaId), 8, 0));
         edtavComboenvolvidoscoletaid_Visible = 0;
         AssignProp("", false, edtavComboenvolvidoscoletaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboenvolvidoscoletaid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOENVOLVIDOSCOLETAID' */
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

      protected void E12152( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("docenvolvidoscoletaww.aspx") );
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
         new docenvolvidoscoletaloaddvcombo(context ).execute(  "DocumentoId",  Gx_mode,  false,  AV7EnvolvidosColetaId,  AV8DocumentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
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
         /* 'LOADCOMBOENVOLVIDOSCOLETAID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new docenvolvidoscoletaloaddvcombo(context ).execute(  "EnvolvidosColetaId",  Gx_mode,  false,  AV7EnvolvidosColetaId,  AV8DocumentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AV18Combo_DataJson = GXt_char2;
         Combo_envolvidoscoletaid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_envolvidoscoletaid.SendProperty(context, "", false, Combo_envolvidoscoletaid_Internalname, "SelectedValue_set", Combo_envolvidoscoletaid_Selectedvalue_set);
         Combo_envolvidoscoletaid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_envolvidoscoletaid.SendProperty(context, "", false, Combo_envolvidoscoletaid_Internalname, "SelectedText_set", Combo_envolvidoscoletaid_Selectedtext_set);
         AV19ComboEnvolvidosColetaId = (int)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV19ComboEnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(AV19ComboEnvolvidosColetaId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7EnvolvidosColetaId) )
         {
            Combo_envolvidoscoletaid_Enabled = false;
            ucCombo_envolvidoscoletaid.SendProperty(context, "", false, Combo_envolvidoscoletaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Enabled));
         }
      }

      protected void ZM1548( short GX_JID )
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
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EnvolvidosColetaId) )
         {
            edtEnvolvidosColetaId_Enabled = 0;
            AssignProp("", false, edtEnvolvidosColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvolvidosColetaId_Enabled), 5, 0), true);
         }
         else
         {
            edtEnvolvidosColetaId_Enabled = 1;
            AssignProp("", false, edtEnvolvidosColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvolvidosColetaId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7EnvolvidosColetaId) )
         {
            edtEnvolvidosColetaId_Enabled = 0;
            AssignProp("", false, edtEnvolvidosColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvolvidosColetaId_Enabled), 5, 0), true);
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
         if ( ! (0==AV7EnvolvidosColetaId) )
         {
            A54EnvolvidosColetaId = AV7EnvolvidosColetaId;
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
         }
         else
         {
            A54EnvolvidosColetaId = AV19ComboEnvolvidosColetaId;
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
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

      protected void Load1548( )
      {
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound48 = 1;
            ZM1548( -7) ;
         }
         pr_default.close(4);
         OnLoadActions1548( ) ;
      }

      protected void OnLoadActions1548( )
      {
      }

      protected void CheckExtendedTable1548( )
      {
         nIsDirty_48 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Envolvidos Coleta'.", "ForeignKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
            AnyError = 1;
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00155 */
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

      protected void CloseExtendedTableCursors1548( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( int A54EnvolvidosColetaId )
      {
         /* Using cursor T00157 */
         pr_default.execute(5, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Envolvidos Coleta'.", "ForeignKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
            AnyError = 1;
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
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
         /* Using cursor T00158 */
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

      protected void GetKey1548( )
      {
         /* Using cursor T00159 */
         pr_default.execute(7, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1548( 7) ;
            RcdFound48 = 1;
            A54EnvolvidosColetaId = T00153_A54EnvolvidosColetaId[0];
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
            A75DocumentoId = T00153_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z75DocumentoId = A75DocumentoId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1548( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey1548( ) ;
            }
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey1548( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1548( ) ;
         if ( RcdFound48 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound48 = 0;
         /* Using cursor T001510 */
         pr_default.execute(8, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001510_A54EnvolvidosColetaId[0] < A54EnvolvidosColetaId ) || ( T001510_A54EnvolvidosColetaId[0] == A54EnvolvidosColetaId ) && ( T001510_A75DocumentoId[0] < A75DocumentoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001510_A54EnvolvidosColetaId[0] > A54EnvolvidosColetaId ) || ( T001510_A54EnvolvidosColetaId[0] == A54EnvolvidosColetaId ) && ( T001510_A75DocumentoId[0] > A75DocumentoId ) ) )
            {
               A54EnvolvidosColetaId = T001510_A54EnvolvidosColetaId[0];
               AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
               A75DocumentoId = T001510_A75DocumentoId[0];
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               RcdFound48 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound48 = 0;
         /* Using cursor T001511 */
         pr_default.execute(9, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001511_A54EnvolvidosColetaId[0] > A54EnvolvidosColetaId ) || ( T001511_A54EnvolvidosColetaId[0] == A54EnvolvidosColetaId ) && ( T001511_A75DocumentoId[0] > A75DocumentoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001511_A54EnvolvidosColetaId[0] < A54EnvolvidosColetaId ) || ( T001511_A54EnvolvidosColetaId[0] == A54EnvolvidosColetaId ) && ( T001511_A75DocumentoId[0] < A75DocumentoId ) ) )
            {
               A54EnvolvidosColetaId = T001511_A54EnvolvidosColetaId[0];
               AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
               A75DocumentoId = T001511_A75DocumentoId[0];
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               RcdFound48 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1548( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1548( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  A54EnvolvidosColetaId = Z54EnvolvidosColetaId;
                  AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
                  A75DocumentoId = Z75DocumentoId;
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
                  AnyError = 1;
                  GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1548( ) ;
                  GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1548( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENVOLVIDOSCOLETAID");
                     AnyError = 1;
                     GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEnvolvidosColetaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1548( ) ;
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
         if ( ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId ) || ( A75DocumentoId != Z75DocumentoId ) )
         {
            A54EnvolvidosColetaId = Z54EnvolvidosColetaId;
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
            A75DocumentoId = Z75DocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENVOLVIDOSCOLETAID");
            AnyError = 1;
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1548( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocEnvolvidosColeta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocEnvolvidosColeta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1548( )
      {
         if ( ! IsAuthorized("docenvolvidoscoleta_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1548( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1548( 0) ;
            CheckOptimisticConcurrency1548( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1548( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1548( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001512 */
                     pr_default.execute(10, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("DocEnvolvidosColeta");
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
                           ResetCaption150( ) ;
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
               Load1548( ) ;
            }
            EndLevel1548( ) ;
         }
         CloseExtendedTableCursors1548( ) ;
      }

      protected void Update1548( )
      {
         if ( ! IsAuthorized("docenvolvidoscoleta_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1548( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1548( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1548( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1548( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DocEnvolvidosColeta] */
                     DeferredUpdate1548( ) ;
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
            EndLevel1548( ) ;
         }
         CloseExtendedTableCursors1548( ) ;
      }

      protected void DeferredUpdate1548( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("docenvolvidoscoleta_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1548( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1548( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1548( ) ;
            AfterConfirm1548( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1548( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001513 */
                  pr_default.execute(11, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("DocEnvolvidosColeta");
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1548( ) ;
         Gx_mode = sMode48;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1548( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1548( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1548( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("docenvolvidoscoleta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("docenvolvidoscoleta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1548( )
      {
         /* Scan By routine */
         /* Using cursor T001514 */
         pr_default.execute(12);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound48 = 1;
            A54EnvolvidosColetaId = T001514_A54EnvolvidosColetaId[0];
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
            A75DocumentoId = T001514_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1548( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound48 = 1;
            A54EnvolvidosColetaId = T001514_A54EnvolvidosColetaId[0];
            AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
            A75DocumentoId = T001514_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
      }

      protected void ScanEnd1548( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1548( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1548( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1548( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1548( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1548( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1548( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1548( )
      {
         edtEnvolvidosColetaId_Enabled = 0;
         AssignProp("", false, edtEnvolvidosColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvolvidosColetaId_Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtavComboenvolvidoscoletaid_Enabled = 0;
         AssignProp("", false, edtavComboenvolvidoscoletaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboenvolvidoscoletaid_Enabled), 5, 0), true);
         edtavCombodocumentoid_Enabled = 0;
         AssignProp("", false, edtavCombodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1548( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         GXEncryptionTmp = "docenvolvidoscoleta.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EnvolvidosColetaId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docenvolvidoscoleta.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"DocEnvolvidosColeta");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("docenvolvidoscoleta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z54EnvolvidosColetaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54EnvolvidosColetaId), 8, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENVOLVIDOSCOLETAID_DATA", AV14EnvolvidosColetaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENVOLVIDOSCOLETAID_DATA", AV14EnvolvidosColetaId_Data);
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
         GxWebStd.gx_hidden_field( context, "vENVOLVIDOSCOLETAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EnvolvidosColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENVOLVIDOSCOLETAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EnvolvidosColetaId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Objectcall", StringUtil.RTrim( Combo_envolvidoscoletaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Cls", StringUtil.RTrim( Combo_envolvidoscoletaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_set", StringUtil.RTrim( Combo_envolvidoscoletaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Selectedtext_set", StringUtil.RTrim( Combo_envolvidoscoletaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Gamoauthtoken", StringUtil.RTrim( Combo_envolvidoscoletaid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Enabled", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Datalistproc", StringUtil.RTrim( Combo_envolvidoscoletaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_envolvidoscoletaid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ENVOLVIDOSCOLETAID_Emptyitem", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Emptyitem));
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
         GXEncryptionTmp = "docenvolvidoscoleta.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EnvolvidosColetaId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0));
         return formatLink("docenvolvidoscoleta.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "DocEnvolvidosColeta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Envolvidos Coleta" ;
      }

      protected void InitializeNonKey1548( )
      {
      }

      protected void InitAll1548( )
      {
         A54EnvolvidosColetaId = 0;
         AssignAttri("", false, "A54EnvolvidosColetaId", StringUtil.LTrimStr( (decimal)(A54EnvolvidosColetaId), 8, 0));
         A75DocumentoId = 0;
         AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         InitializeNonKey1548( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417263925", true, true);
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
         context.AddJavascriptSource("docenvolvidoscoleta.js", "?202312417263926", false, true);
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
         lblTextblockenvolvidoscoletaid_Internalname = "TEXTBLOCKENVOLVIDOSCOLETAID";
         Combo_envolvidoscoletaid_Internalname = "COMBO_ENVOLVIDOSCOLETAID";
         edtEnvolvidosColetaId_Internalname = "ENVOLVIDOSCOLETAID";
         divTablesplittedenvolvidoscoletaid_Internalname = "TABLESPLITTEDENVOLVIDOSCOLETAID";
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
         edtavComboenvolvidoscoletaid_Internalname = "vCOMBOENVOLVIDOSCOLETAID";
         divSectionattribute_envolvidoscoletaid_Internalname = "SECTIONATTRIBUTE_ENVOLVIDOSCOLETAID";
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
         Form.Caption = "Doc Envolvidos Coleta";
         edtavCombodocumentoid_Jsonclick = "";
         edtavCombodocumentoid_Enabled = 0;
         edtavCombodocumentoid_Visible = 1;
         edtavComboenvolvidoscoletaid_Jsonclick = "";
         edtavComboenvolvidoscoletaid_Enabled = 0;
         edtavComboenvolvidoscoletaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 1;
         edtDocumentoId_Visible = 1;
         Combo_documentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_documentoid_Datalistprocparametersprefix = " \"ComboName\": \"DocumentoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"EnvolvidosColetaId\": 0, \"DocumentoId\": 0";
         Combo_documentoid_Datalistproc = "DocEnvolvidosColetaLoadDVCombo";
         Combo_documentoid_Cls = "ExtendedCombo AttributeFL";
         Combo_documentoid_Caption = "";
         Combo_documentoid_Enabled = Convert.ToBoolean( -1);
         edtEnvolvidosColetaId_Jsonclick = "";
         edtEnvolvidosColetaId_Enabled = 1;
         edtEnvolvidosColetaId_Visible = 1;
         Combo_envolvidoscoletaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_envolvidoscoletaid_Datalistprocparametersprefix = " \"ComboName\": \"EnvolvidosColetaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"EnvolvidosColetaId\": 0, \"DocumentoId\": 0";
         Combo_envolvidoscoletaid_Datalistproc = "DocEnvolvidosColetaLoadDVCombo";
         Combo_envolvidoscoletaid_Cls = "ExtendedCombo AttributeFL";
         Combo_envolvidoscoletaid_Caption = "";
         Combo_envolvidoscoletaid_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Envolvidoscoletaid( )
      {
         /* Using cursor T001515 */
         pr_default.execute(13, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Envolvidos Coleta'.", "ForeignKeyNotFound", 1, "ENVOLVIDOSCOLETAID");
            AnyError = 1;
            GX_FocusControl = edtEnvolvidosColetaId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Documentoid( )
      {
         /* Using cursor T001516 */
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EnvolvidosColetaId',fld:'vENVOLVIDOSCOLETAID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EnvolvidosColetaId',fld:'vENVOLVIDOSCOLETAID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12152',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ENVOLVIDOSCOLETAID","{handler:'Valid_Envolvidoscoletaid',iparms:[{av:'A54EnvolvidosColetaId',fld:'ENVOLVIDOSCOLETAID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_ENVOLVIDOSCOLETAID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOENVOLVIDOSCOLETAID","{handler:'Validv_Comboenvolvidoscoletaid',iparms:[]");
         setEventMetadata("VALIDV_COMBOENVOLVIDOSCOLETAID",",oparms:[]}");
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
         Combo_envolvidoscoletaid_Selectedvalue_get = "";
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
         lblTextblockenvolvidoscoletaid_Jsonclick = "";
         ucCombo_envolvidoscoletaid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14EnvolvidosColetaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockdocumentoid_Jsonclick = "";
         ucCombo_documentoid = new GXUserControl();
         AV22DocumentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Combo_envolvidoscoletaid_Objectcall = "";
         Combo_envolvidoscoletaid_Class = "";
         Combo_envolvidoscoletaid_Icontype = "";
         Combo_envolvidoscoletaid_Icon = "";
         Combo_envolvidoscoletaid_Tooltip = "";
         Combo_envolvidoscoletaid_Selectedvalue_set = "";
         Combo_envolvidoscoletaid_Selectedtext_set = "";
         Combo_envolvidoscoletaid_Selectedtext_get = "";
         Combo_envolvidoscoletaid_Gamoauthtoken = "";
         Combo_envolvidoscoletaid_Ddointernalname = "";
         Combo_envolvidoscoletaid_Titlecontrolalign = "";
         Combo_envolvidoscoletaid_Dropdownoptionstype = "";
         Combo_envolvidoscoletaid_Titlecontrolidtoreplace = "";
         Combo_envolvidoscoletaid_Datalisttype = "";
         Combo_envolvidoscoletaid_Datalistfixedvalues = "";
         Combo_envolvidoscoletaid_Htmltemplate = "";
         Combo_envolvidoscoletaid_Multiplevaluestype = "";
         Combo_envolvidoscoletaid_Loadingdata = "";
         Combo_envolvidoscoletaid_Noresultsfound = "";
         Combo_envolvidoscoletaid_Emptyitemtext = "";
         Combo_envolvidoscoletaid_Onlyselectedvalues = "";
         Combo_envolvidoscoletaid_Selectalltext = "";
         Combo_envolvidoscoletaid_Multiplevaluesseparator = "";
         Combo_envolvidoscoletaid_Addnewoptiontext = "";
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
         sMode48 = "";
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
         T00156_A54EnvolvidosColetaId = new int[1] ;
         T00156_A75DocumentoId = new int[1] ;
         T00154_A54EnvolvidosColetaId = new int[1] ;
         T00155_A75DocumentoId = new int[1] ;
         T00157_A54EnvolvidosColetaId = new int[1] ;
         T00158_A75DocumentoId = new int[1] ;
         T00159_A54EnvolvidosColetaId = new int[1] ;
         T00159_A75DocumentoId = new int[1] ;
         T00153_A54EnvolvidosColetaId = new int[1] ;
         T00153_A75DocumentoId = new int[1] ;
         T001510_A54EnvolvidosColetaId = new int[1] ;
         T001510_A75DocumentoId = new int[1] ;
         T001511_A54EnvolvidosColetaId = new int[1] ;
         T001511_A75DocumentoId = new int[1] ;
         T00152_A54EnvolvidosColetaId = new int[1] ;
         T00152_A75DocumentoId = new int[1] ;
         T001514_A54EnvolvidosColetaId = new int[1] ;
         T001514_A75DocumentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001515_A54EnvolvidosColetaId = new int[1] ;
         T001516_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docenvolvidoscoleta__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docenvolvidoscoleta__default(),
            new Object[][] {
                new Object[] {
               T00152_A54EnvolvidosColetaId, T00152_A75DocumentoId
               }
               , new Object[] {
               T00153_A54EnvolvidosColetaId, T00153_A75DocumentoId
               }
               , new Object[] {
               T00154_A54EnvolvidosColetaId
               }
               , new Object[] {
               T00155_A75DocumentoId
               }
               , new Object[] {
               T00156_A54EnvolvidosColetaId, T00156_A75DocumentoId
               }
               , new Object[] {
               T00157_A54EnvolvidosColetaId
               }
               , new Object[] {
               T00158_A75DocumentoId
               }
               , new Object[] {
               T00159_A54EnvolvidosColetaId, T00159_A75DocumentoId
               }
               , new Object[] {
               T001510_A54EnvolvidosColetaId, T001510_A75DocumentoId
               }
               , new Object[] {
               T001511_A54EnvolvidosColetaId, T001511_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001514_A54EnvolvidosColetaId, T001514_A75DocumentoId
               }
               , new Object[] {
               T001515_A54EnvolvidosColetaId
               }
               , new Object[] {
               T001516_A75DocumentoId
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
      private short RcdFound48 ;
      private short GX_JID ;
      private short nIsDirty_48 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7EnvolvidosColetaId ;
      private int wcpOAV8DocumentoId ;
      private int Z54EnvolvidosColetaId ;
      private int Z75DocumentoId ;
      private int A54EnvolvidosColetaId ;
      private int A75DocumentoId ;
      private int AV7EnvolvidosColetaId ;
      private int AV8DocumentoId ;
      private int trnEnded ;
      private int edtEnvolvidosColetaId_Visible ;
      private int edtEnvolvidosColetaId_Enabled ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboEnvolvidosColetaId ;
      private int edtavComboenvolvidoscoletaid_Enabled ;
      private int edtavComboenvolvidoscoletaid_Visible ;
      private int AV23ComboDocumentoId ;
      private int edtavCombodocumentoid_Enabled ;
      private int edtavCombodocumentoid_Visible ;
      private int Combo_envolvidoscoletaid_Datalistupdateminimumcharacters ;
      private int Combo_envolvidoscoletaid_Gxcontroltype ;
      private int Combo_documentoid_Datalistupdateminimumcharacters ;
      private int Combo_documentoid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_documentoid_Selectedvalue_get ;
      private string Combo_envolvidoscoletaid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEnvolvidosColetaId_Internalname ;
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
      private string divTablesplittedenvolvidoscoletaid_Internalname ;
      private string lblTextblockenvolvidoscoletaid_Internalname ;
      private string lblTextblockenvolvidoscoletaid_Jsonclick ;
      private string Combo_envolvidoscoletaid_Caption ;
      private string Combo_envolvidoscoletaid_Cls ;
      private string Combo_envolvidoscoletaid_Datalistproc ;
      private string Combo_envolvidoscoletaid_Datalistprocparametersprefix ;
      private string Combo_envolvidoscoletaid_Internalname ;
      private string TempTags ;
      private string edtEnvolvidosColetaId_Jsonclick ;
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
      private string divSectionattribute_envolvidoscoletaid_Internalname ;
      private string edtavComboenvolvidoscoletaid_Internalname ;
      private string edtavComboenvolvidoscoletaid_Jsonclick ;
      private string divSectionattribute_documentoid_Internalname ;
      private string edtavCombodocumentoid_Internalname ;
      private string edtavCombodocumentoid_Jsonclick ;
      private string Combo_envolvidoscoletaid_Objectcall ;
      private string Combo_envolvidoscoletaid_Class ;
      private string Combo_envolvidoscoletaid_Icontype ;
      private string Combo_envolvidoscoletaid_Icon ;
      private string Combo_envolvidoscoletaid_Tooltip ;
      private string Combo_envolvidoscoletaid_Selectedvalue_set ;
      private string Combo_envolvidoscoletaid_Selectedtext_set ;
      private string Combo_envolvidoscoletaid_Selectedtext_get ;
      private string Combo_envolvidoscoletaid_Gamoauthtoken ;
      private string Combo_envolvidoscoletaid_Ddointernalname ;
      private string Combo_envolvidoscoletaid_Titlecontrolalign ;
      private string Combo_envolvidoscoletaid_Dropdownoptionstype ;
      private string Combo_envolvidoscoletaid_Titlecontrolidtoreplace ;
      private string Combo_envolvidoscoletaid_Datalisttype ;
      private string Combo_envolvidoscoletaid_Datalistfixedvalues ;
      private string Combo_envolvidoscoletaid_Htmltemplate ;
      private string Combo_envolvidoscoletaid_Multiplevaluestype ;
      private string Combo_envolvidoscoletaid_Loadingdata ;
      private string Combo_envolvidoscoletaid_Noresultsfound ;
      private string Combo_envolvidoscoletaid_Emptyitemtext ;
      private string Combo_envolvidoscoletaid_Onlyselectedvalues ;
      private string Combo_envolvidoscoletaid_Selectalltext ;
      private string Combo_envolvidoscoletaid_Multiplevaluesseparator ;
      private string Combo_envolvidoscoletaid_Addnewoptiontext ;
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
      private string sMode48 ;
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
      private bool Combo_envolvidoscoletaid_Emptyitem ;
      private bool Combo_documentoid_Emptyitem ;
      private bool Combo_envolvidoscoletaid_Enabled ;
      private bool Combo_envolvidoscoletaid_Visible ;
      private bool Combo_envolvidoscoletaid_Allowmultipleselection ;
      private bool Combo_envolvidoscoletaid_Isgriditem ;
      private bool Combo_envolvidoscoletaid_Hasdescription ;
      private bool Combo_envolvidoscoletaid_Includeonlyselectedoption ;
      private bool Combo_envolvidoscoletaid_Includeselectalloption ;
      private bool Combo_envolvidoscoletaid_Includeaddnewoption ;
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
      private GXUserControl ucCombo_envolvidoscoletaid ;
      private GXUserControl ucCombo_documentoid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00156_A54EnvolvidosColetaId ;
      private int[] T00156_A75DocumentoId ;
      private int[] T00154_A54EnvolvidosColetaId ;
      private int[] T00155_A75DocumentoId ;
      private int[] T00157_A54EnvolvidosColetaId ;
      private int[] T00158_A75DocumentoId ;
      private int[] T00159_A54EnvolvidosColetaId ;
      private int[] T00159_A75DocumentoId ;
      private int[] T00153_A54EnvolvidosColetaId ;
      private int[] T00153_A75DocumentoId ;
      private int[] T001510_A54EnvolvidosColetaId ;
      private int[] T001510_A75DocumentoId ;
      private int[] T001511_A54EnvolvidosColetaId ;
      private int[] T001511_A75DocumentoId ;
      private int[] T00152_A54EnvolvidosColetaId ;
      private int[] T00152_A75DocumentoId ;
      private int[] T001514_A54EnvolvidosColetaId ;
      private int[] T001514_A75DocumentoId ;
      private int[] T001515_A54EnvolvidosColetaId ;
      private int[] T001516_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14EnvolvidosColetaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22DocumentoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV21GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV20GAMSession ;
   }

   public class docenvolvidoscoleta__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docenvolvidoscoleta__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00156;
        prmT00156 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00154;
        prmT00154 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmT00155;
        prmT00155 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00157;
        prmT00157 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmT00158;
        prmT00158 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00159;
        prmT00159 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00153;
        prmT00153 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001510;
        prmT001510 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001511;
        prmT001511 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00152;
        prmT00152 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001512;
        prmT001512 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001513;
        prmT001513 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001514;
        prmT001514 = new Object[] {
        };
        Object[] prmT001515;
        prmT001515 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmT001516;
        prmT001516 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00152", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WITH (UPDLOCK) WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00153", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00154", "SELECT [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00155", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00156", "SELECT TM1.[EnvolvidosColetaId], TM1.[DocumentoId] FROM [DocEnvolvidosColeta] TM1 WHERE TM1.[EnvolvidosColetaId] = @EnvolvidosColetaId and TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[EnvolvidosColetaId], TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00157", "SELECT [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00158", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00159", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00159,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001510", "SELECT TOP 1 [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE ( [EnvolvidosColetaId] > @EnvolvidosColetaId or [EnvolvidosColetaId] = @EnvolvidosColetaId and [DocumentoId] > @DocumentoId) ORDER BY [EnvolvidosColetaId], [DocumentoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001510,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001511", "SELECT TOP 1 [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE ( [EnvolvidosColetaId] < @EnvolvidosColetaId or [EnvolvidosColetaId] = @EnvolvidosColetaId and [DocumentoId] < @DocumentoId) ORDER BY [EnvolvidosColetaId] DESC, [DocumentoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001512", "INSERT INTO [DocEnvolvidosColeta]([EnvolvidosColetaId], [DocumentoId]) VALUES(@EnvolvidosColetaId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmT001512)
           ,new CursorDef("T001513", "DELETE FROM [DocEnvolvidosColeta]  WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId AND [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmT001513)
           ,new CursorDef("T001514", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] ORDER BY [EnvolvidosColetaId], [DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001514,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001515", "SELECT [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001515,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001516", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001516,1, GxCacheFrequency.OFF ,true,false )
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
