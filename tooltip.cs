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
   public class tooltip : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TOOLTIPTELAID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLATOOLTIPTELAID1A53( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"CAMPOID") == 0 )
         {
            A139TooltipTelaId = (int)(NumberUtil.Val( GetPar( "TooltipTelaId"), "."));
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLACAMPOID1A53( A139TooltipTelaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"vTOOLTIPEXISTE") == 0 )
         {
            A112TooltipId = (int)(NumberUtil.Val( GetPar( "TooltipId"), "."));
            AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
            A139TooltipTelaId = (int)(NumberUtil.Val( GetPar( "TooltipTelaId"), "."));
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
            A135CampoId = (int)(NumberUtil.Val( GetPar( "CampoId"), "."));
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASATOOLTIPEXISTE1A53( A112TooltipId, A139TooltipTelaId, A135CampoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A135CampoId = (int)(NumberUtil.Val( GetPar( "CampoId"), "."));
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A135CampoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A139TooltipTelaId = (int)(NumberUtil.Val( GetPar( "TooltipTelaId"), "."));
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A139TooltipTelaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "tooltip.aspx")), "tooltip.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "tooltip.aspx")))) ;
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
                  AV7TooltipId = (int)(NumberUtil.Val( GetPar( "TooltipId"), "."));
                  AssignAttri("", false, "AV7TooltipId", StringUtil.LTrimStr( (decimal)(AV7TooltipId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTOOLTIPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TooltipId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tooltip", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynTooltipTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tooltip( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tooltip( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TooltipId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TooltipId = aP1_TooltipId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynTooltipTelaId = new GXCombobox();
         dynCampoId = new GXCombobox();
         cmbTooltipAtivo = new GXCombobox();
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
            return "tooltip_Execute" ;
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
         if ( dynTooltipTelaId.ItemCount > 0 )
         {
            A139TooltipTelaId = (int)(NumberUtil.Val( dynTooltipTelaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A139TooltipTelaId), 8, 0))), "."));
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTooltipTelaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A139TooltipTelaId), 8, 0));
            AssignProp("", false, dynTooltipTelaId_Internalname, "Values", dynTooltipTelaId.ToJavascriptSource(), true);
         }
         if ( dynCampoId.ItemCount > 0 )
         {
            A135CampoId = (int)(NumberUtil.Val( dynCampoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0))), "."));
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCampoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0));
            AssignProp("", false, dynCampoId_Internalname, "Values", dynCampoId.ToJavascriptSource(), true);
         }
         if ( cmbTooltipAtivo.ItemCount > 0 )
         {
            A118TooltipAtivo = StringUtil.StrToBool( cmbTooltipAtivo.getValidValue(StringUtil.BoolToStr( A118TooltipAtivo)));
            AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTooltipAtivo.CurrentValue = StringUtil.BoolToStr( A118TooltipAtivo);
            AssignProp("", false, cmbTooltipAtivo_Internalname, "Values", cmbTooltipAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynTooltipTelaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynTooltipTelaId_Internalname, "Tela", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTooltipTelaId, dynTooltipTelaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A139TooltipTelaId), 8, 0)), 1, dynTooltipTelaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTooltipTelaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_Tooltip.htm");
         dynTooltipTelaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A139TooltipTelaId), 8, 0));
         AssignProp("", false, dynTooltipTelaId_Internalname, "Values", (string)(dynTooltipTelaId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynCampoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynCampoId_Internalname, "Campo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynCampoId, dynCampoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0)), 1, dynCampoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCampoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Tooltip.htm");
         dynCampoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0));
         AssignProp("", false, dynCampoId_Internalname, "Values", (string)(dynCampoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTooltipDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTooltipDescricao_Internalname, "Descricao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTooltipDescricao_Internalname, A115TooltipDescricao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, 1, edtTooltipDescricao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Tooltip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbTooltipAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTooltipAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTooltipAtivo_Internalname, "Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTooltipAtivo, cmbTooltipAtivo_Internalname, StringUtil.BoolToStr( A118TooltipAtivo), 1, cmbTooltipAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbTooltipAtivo.Visible, cmbTooltipAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_Tooltip.htm");
         cmbTooltipAtivo.CurrentValue = StringUtil.BoolToStr( A118TooltipAtivo);
         AssignProp("", false, cmbTooltipAtivo_Internalname, "Values", (string)(cmbTooltipAtivo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tooltip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tooltip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tooltip.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTooltipId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112TooltipId), 8, 0, ",", "")), StringUtil.LTrim( ((edtTooltipId_Enabled!=0) ? context.localUtil.Format( (decimal)(A112TooltipId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A112TooltipId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTooltipId_Jsonclick, 0, "Attribute", "", "", "", "", edtTooltipId_Visible, edtTooltipId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Tooltip.htm");
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
         E111A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z112TooltipId = (int)(context.localUtil.CToN( cgiGet( "Z112TooltipId"), ",", "."));
               Z118TooltipAtivo = StringUtil.StrToBool( cgiGet( "Z118TooltipAtivo"));
               Z135CampoId = (int)(context.localUtil.CToN( cgiGet( "Z135CampoId"), ",", "."));
               Z139TooltipTelaId = (int)(context.localUtil.CToN( cgiGet( "Z139TooltipTelaId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N135CampoId = (int)(context.localUtil.CToN( cgiGet( "N135CampoId"), ",", "."));
               N139TooltipTelaId = (int)(context.localUtil.CToN( cgiGet( "N139TooltipTelaId"), ",", "."));
               AV7TooltipId = (int)(context.localUtil.CToN( cgiGet( "vTOOLTIPID"), ",", "."));
               AV26Insert_CampoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CAMPOID"), ",", "."));
               AV28Insert_TooltipTelaId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TOOLTIPTELAID"), ",", "."));
               AV17tooltipexiste = StringUtil.StrToBool( cgiGet( "vTOOLTIPEXISTE"));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               A136CampoNome = cgiGet( "CAMPONOME");
               A140TooltipTelaNome = cgiGet( "TOOLTIPTELANOME");
               AV30Pgmname = cgiGet( "vPGMNAME");
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
               dynTooltipTelaId.CurrentValue = cgiGet( dynTooltipTelaId_Internalname);
               A139TooltipTelaId = (int)(NumberUtil.Val( cgiGet( dynTooltipTelaId_Internalname), "."));
               AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
               dynCampoId.CurrentValue = cgiGet( dynCampoId_Internalname);
               A135CampoId = (int)(NumberUtil.Val( cgiGet( dynCampoId_Internalname), "."));
               AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
               A115TooltipDescricao = cgiGet( edtTooltipDescricao_Internalname);
               AssignAttri("", false, "A115TooltipDescricao", A115TooltipDescricao);
               cmbTooltipAtivo.CurrentValue = cgiGet( cmbTooltipAtivo_Internalname);
               A118TooltipAtivo = StringUtil.StrToBool( cgiGet( cmbTooltipAtivo_Internalname));
               AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
               A112TooltipId = (int)(context.localUtil.CToN( cgiGet( edtTooltipId_Internalname), ",", "."));
               AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Tooltip");
               A112TooltipId = (int)(context.localUtil.CToN( cgiGet( edtTooltipId_Internalname), ",", "."));
               AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
               forbiddenHiddens.Add("TooltipId", context.localUtil.Format( (decimal)(A112TooltipId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A112TooltipId != Z112TooltipId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tooltip:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A112TooltipId = (int)(NumberUtil.Val( GetPar( "TooltipId"), "."));
                  AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
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
                     sMode53 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode53;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound53 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TOOLTIPID");
                        AnyError = 1;
                        GX_FocusControl = edtTooltipId_Internalname;
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
                           E111A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121A2 ();
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
            E121A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1A53( ) ;
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
            DisableAttributes1A53( ) ;
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

      protected void CONFIRM_1A0( )
      {
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1A53( ) ;
            }
            else
            {
               CheckExtendedTable1A53( ) ;
               CloseExtendedTableCursors1A53( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1A0( )
      {
      }

      protected void E111A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            AssignAttri("", false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            while ( AV31GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV27TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV27TrnContextAtt.gxTpr_Attributename, "CampoId") == 0 )
               {
                  AV26Insert_CampoId = (int)(NumberUtil.Val( AV27TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV26Insert_CampoId", StringUtil.LTrimStr( (decimal)(AV26Insert_CampoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV27TrnContextAtt.gxTpr_Attributename, "TooltipTelaId") == 0 )
               {
                  AV28Insert_TooltipTelaId = (int)(NumberUtil.Val( AV27TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV28Insert_TooltipTelaId", StringUtil.LTrimStr( (decimal)(AV28Insert_TooltipTelaId), 8, 0));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
               AssignAttri("", false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            }
         }
         edtTooltipId_Visible = 0;
         AssignProp("", false, edtTooltipId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTooltipId_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbTooltipAtivo.Visible = 0;
            AssignProp("", false, cmbTooltipAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbTooltipAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbTooltipAtivo.Visible = 1;
            AssignProp("", false, cmbTooltipAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbTooltipAtivo.Visible), 5, 0), true);
         }
      }

      protected void E121A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("tooltipww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1A53( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z118TooltipAtivo = T001A3_A118TooltipAtivo[0];
               Z135CampoId = T001A3_A135CampoId[0];
               Z139TooltipTelaId = T001A3_A139TooltipTelaId[0];
            }
            else
            {
               Z118TooltipAtivo = A118TooltipAtivo;
               Z135CampoId = A135CampoId;
               Z139TooltipTelaId = A139TooltipTelaId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z112TooltipId = A112TooltipId;
            Z115TooltipDescricao = A115TooltipDescricao;
            Z118TooltipAtivo = A118TooltipAtivo;
            Z135CampoId = A135CampoId;
            Z139TooltipTelaId = A139TooltipTelaId;
            Z136CampoNome = A136CampoNome;
            Z140TooltipTelaNome = A140TooltipTelaNome;
         }
      }

      protected void standaloneNotModal( )
      {
         GXATOOLTIPTELAID_html1A53( ) ;
         edtTooltipId_Enabled = 0;
         AssignProp("", false, edtTooltipId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTooltipId_Enabled), 5, 0), true);
         AV30Pgmname = "Tooltip";
         AssignAttri("", false, "AV30Pgmname", AV30Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTooltipId_Enabled = 0;
         AssignProp("", false, edtTooltipId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTooltipId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TooltipId) )
         {
            A112TooltipId = AV7TooltipId;
            AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_CampoId) )
         {
            dynCampoId.Enabled = 0;
            AssignProp("", false, dynCampoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCampoId.Enabled), 5, 0), true);
         }
         else
         {
            dynCampoId.Enabled = 1;
            AssignProp("", false, dynCampoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCampoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV28Insert_TooltipTelaId) )
         {
            dynTooltipTelaId.Enabled = 0;
            AssignProp("", false, dynTooltipTelaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTooltipTelaId.Enabled), 5, 0), true);
         }
         else
         {
            dynTooltipTelaId.Enabled = 1;
            AssignProp("", false, dynTooltipTelaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTooltipTelaId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV28Insert_TooltipTelaId) )
         {
            A139TooltipTelaId = AV28Insert_TooltipTelaId;
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_CampoId) )
         {
            A135CampoId = AV26Insert_CampoId;
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         }
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
         if ( IsIns( )  && (false==A118TooltipAtivo) && ( Gx_BScreen == 0 ) )
         {
            A118TooltipAtivo = true;
            AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001A5 */
            pr_default.execute(3, new Object[] {A139TooltipTelaId});
            A140TooltipTelaNome = T001A5_A140TooltipTelaNome[0];
            pr_default.close(3);
            GXACAMPOID_html1A53( A139TooltipTelaId) ;
            /* Using cursor T001A4 */
            pr_default.execute(2, new Object[] {A135CampoId});
            A136CampoNome = T001A4_A136CampoNome[0];
            pr_default.close(2);
            GXt_int1 = 0;
            new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
            AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
            AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
         }
      }

      protected void Load1A53( )
      {
         /* Using cursor T001A6 */
         pr_default.execute(4, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound53 = 1;
            A115TooltipDescricao = T001A6_A115TooltipDescricao[0];
            AssignAttri("", false, "A115TooltipDescricao", A115TooltipDescricao);
            A118TooltipAtivo = T001A6_A118TooltipAtivo[0];
            AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
            A136CampoNome = T001A6_A136CampoNome[0];
            A140TooltipTelaNome = T001A6_A140TooltipTelaNome[0];
            A135CampoId = T001A6_A135CampoId[0];
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
            A139TooltipTelaId = T001A6_A139TooltipTelaId[0];
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
            ZM1A53( -17) ;
         }
         pr_default.close(4);
         OnLoadActions1A53( ) ;
      }

      protected void OnLoadActions1A53( )
      {
         GXt_int1 = 0;
         new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
         AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
         A115TooltipDescricao = StringUtil.Upper( A115TooltipDescricao);
         AssignAttri("", false, "A115TooltipDescricao", A115TooltipDescricao);
         GXACAMPOID_html1A53( A139TooltipTelaId) ;
      }

      protected void CheckExtendedTable1A53( )
      {
         nIsDirty_53 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXt_int1 = 0;
         new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
         AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
         if ( AV17tooltipexiste )
         {
            GX_msglist.addItem("Nome da tela e nome do campo já cadastrados, revise o cadastro.", 1, "");
            AnyError = 1;
         }
         nIsDirty_53 = 1;
         A115TooltipDescricao = StringUtil.Upper( A115TooltipDescricao);
         AssignAttri("", false, "A115TooltipDescricao", A115TooltipDescricao);
         /* Using cursor T001A4 */
         pr_default.execute(2, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Campo'.", "ForeignKeyNotFound", 1, "CAMPOID");
            AnyError = 1;
            GX_FocusControl = dynCampoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A136CampoNome = T001A4_A136CampoNome[0];
         pr_default.close(2);
         /* Using cursor T001A5 */
         pr_default.execute(3, new Object[] {A139TooltipTelaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tooltip Tela'.", "ForeignKeyNotFound", 1, "TOOLTIPTELAID");
            AnyError = 1;
            GX_FocusControl = dynTooltipTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A140TooltipTelaNome = T001A5_A140TooltipTelaNome[0];
         pr_default.close(3);
         GXACAMPOID_html1A53( A139TooltipTelaId) ;
      }

      protected void CloseExtendedTableCursors1A53( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( int A135CampoId )
      {
         /* Using cursor T001A7 */
         pr_default.execute(5, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Campo'.", "ForeignKeyNotFound", 1, "CAMPOID");
            AnyError = 1;
            GX_FocusControl = dynCampoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A136CampoNome = T001A7_A136CampoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A136CampoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_19( int A139TooltipTelaId )
      {
         /* Using cursor T001A8 */
         pr_default.execute(6, new Object[] {A139TooltipTelaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tooltip Tela'.", "ForeignKeyNotFound", 1, "TOOLTIPTELAID");
            AnyError = 1;
            GX_FocusControl = dynTooltipTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A140TooltipTelaNome = T001A8_A140TooltipTelaNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A140TooltipTelaNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1A53( )
      {
         /* Using cursor T001A9 */
         pr_default.execute(7, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001A3 */
         pr_default.execute(1, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1A53( 17) ;
            RcdFound53 = 1;
            A112TooltipId = T001A3_A112TooltipId[0];
            AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
            A115TooltipDescricao = T001A3_A115TooltipDescricao[0];
            AssignAttri("", false, "A115TooltipDescricao", A115TooltipDescricao);
            A118TooltipAtivo = T001A3_A118TooltipAtivo[0];
            AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
            A135CampoId = T001A3_A135CampoId[0];
            AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
            A139TooltipTelaId = T001A3_A139TooltipTelaId[0];
            AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
            Z112TooltipId = A112TooltipId;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1A53( ) ;
            if ( AnyError == 1 )
            {
               RcdFound53 = 0;
               InitializeNonKey1A53( ) ;
            }
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey1A53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1A53( ) ;
         if ( RcdFound53 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound53 = 0;
         /* Using cursor T001A10 */
         pr_default.execute(8, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001A10_A112TooltipId[0] < A112TooltipId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001A10_A112TooltipId[0] > A112TooltipId ) ) )
            {
               A112TooltipId = T001A10_A112TooltipId[0];
               AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
               RcdFound53 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound53 = 0;
         /* Using cursor T001A11 */
         pr_default.execute(9, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001A11_A112TooltipId[0] > A112TooltipId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001A11_A112TooltipId[0] < A112TooltipId ) ) )
            {
               A112TooltipId = T001A11_A112TooltipId[0];
               AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
               RcdFound53 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1A53( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynTooltipTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1A53( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound53 == 1 )
            {
               if ( A112TooltipId != Z112TooltipId )
               {
                  A112TooltipId = Z112TooltipId;
                  AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOOLTIPID");
                  AnyError = 1;
                  GX_FocusControl = edtTooltipId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynTooltipTelaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1A53( ) ;
                  GX_FocusControl = dynTooltipTelaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A112TooltipId != Z112TooltipId )
               {
                  /* Insert record */
                  GX_FocusControl = dynTooltipTelaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1A53( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOOLTIPID");
                     AnyError = 1;
                     GX_FocusControl = edtTooltipId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynTooltipTelaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1A53( ) ;
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
         if ( A112TooltipId != Z112TooltipId )
         {
            A112TooltipId = Z112TooltipId;
            AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOOLTIPID");
            AnyError = 1;
            GX_FocusControl = edtTooltipId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynTooltipTelaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1A53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001A2 */
            pr_default.execute(0, new Object[] {A112TooltipId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tooltip"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z118TooltipAtivo != T001A2_A118TooltipAtivo[0] ) || ( Z135CampoId != T001A2_A135CampoId[0] ) || ( Z139TooltipTelaId != T001A2_A139TooltipTelaId[0] ) )
            {
               if ( Z118TooltipAtivo != T001A2_A118TooltipAtivo[0] )
               {
                  GXUtil.WriteLog("tooltip:[seudo value changed for attri]"+"TooltipAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z118TooltipAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A118TooltipAtivo[0]);
               }
               if ( Z135CampoId != T001A2_A135CampoId[0] )
               {
                  GXUtil.WriteLog("tooltip:[seudo value changed for attri]"+"CampoId");
                  GXUtil.WriteLogRaw("Old: ",Z135CampoId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A135CampoId[0]);
               }
               if ( Z139TooltipTelaId != T001A2_A139TooltipTelaId[0] )
               {
                  GXUtil.WriteLog("tooltip:[seudo value changed for attri]"+"TooltipTelaId");
                  GXUtil.WriteLogRaw("Old: ",Z139TooltipTelaId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A139TooltipTelaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tooltip"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1A53( )
      {
         if ( ! IsAuthorized("tooltip_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1A53( 0) ;
            CheckOptimisticConcurrency1A53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1A53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001A12 */
                     pr_default.execute(10, new Object[] {A115TooltipDescricao, A118TooltipAtivo, A135CampoId, A139TooltipTelaId});
                     A112TooltipId = T001A12_A112TooltipId[0];
                     AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Tooltip");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1A0( ) ;
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
               Load1A53( ) ;
            }
            EndLevel1A53( ) ;
         }
         CloseExtendedTableCursors1A53( ) ;
      }

      protected void Update1A53( )
      {
         if ( ! IsAuthorized("tooltip_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1A53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001A13 */
                     pr_default.execute(11, new Object[] {A115TooltipDescricao, A118TooltipAtivo, A135CampoId, A139TooltipTelaId, A112TooltipId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Tooltip");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tooltip"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1A53( ) ;
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
            EndLevel1A53( ) ;
         }
         CloseExtendedTableCursors1A53( ) ;
      }

      protected void DeferredUpdate1A53( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tooltip_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1A53( ) ;
            AfterConfirm1A53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1A53( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001A14 */
                  pr_default.execute(12, new Object[] {A112TooltipId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("Tooltip");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1A53( ) ;
         Gx_mode = sMode53;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1A53( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001A15 */
            pr_default.execute(13, new Object[] {A135CampoId});
            A136CampoNome = T001A15_A136CampoNome[0];
            pr_default.close(13);
            /* Using cursor T001A16 */
            pr_default.execute(14, new Object[] {A139TooltipTelaId});
            A140TooltipTelaNome = T001A16_A140TooltipTelaNome[0];
            pr_default.close(14);
            GXACAMPOID_html1A53( A139TooltipTelaId) ;
            GXt_int1 = 0;
            new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
            AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
            AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
         }
      }

      protected void EndLevel1A53( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("tooltip",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("tooltip",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1A53( )
      {
         /* Scan By routine */
         /* Using cursor T001A17 */
         pr_default.execute(15);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound53 = 1;
            A112TooltipId = T001A17_A112TooltipId[0];
            AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1A53( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound53 = 1;
            A112TooltipId = T001A17_A112TooltipId[0];
            AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
         }
      }

      protected void ScanEnd1A53( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1A53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1A53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1A53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1A53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1A53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1A53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1A53( )
      {
         dynTooltipTelaId.Enabled = 0;
         AssignProp("", false, dynTooltipTelaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTooltipTelaId.Enabled), 5, 0), true);
         dynCampoId.Enabled = 0;
         AssignProp("", false, dynCampoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCampoId.Enabled), 5, 0), true);
         edtTooltipDescricao_Enabled = 0;
         AssignProp("", false, edtTooltipDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTooltipDescricao_Enabled), 5, 0), true);
         cmbTooltipAtivo.Enabled = 0;
         AssignProp("", false, cmbTooltipAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTooltipAtivo.Enabled), 5, 0), true);
         edtTooltipId_Enabled = 0;
         AssignProp("", false, edtTooltipId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTooltipId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1A53( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1A0( )
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
         GXEncryptionTmp = "tooltip.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TooltipId,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tooltip.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Tooltip");
         forbiddenHiddens.Add("TooltipId", context.localUtil.Format( (decimal)(A112TooltipId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tooltip:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z112TooltipId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112TooltipId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z118TooltipAtivo", Z118TooltipAtivo);
         GxWebStd.gx_hidden_field( context, "Z135CampoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135CampoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z139TooltipTelaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139TooltipTelaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N135CampoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135CampoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N139TooltipTelaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A139TooltipTelaId), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vTOOLTIPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TooltipId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOOLTIPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TooltipId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CAMPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Insert_CampoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TOOLTIPTELAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28Insert_TooltipTelaId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vTOOLTIPEXISTE", AV17tooltipexiste);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CAMPONOME", A136CampoNome);
         GxWebStd.gx_hidden_field( context, "TOOLTIPTELANOME", A140TooltipTelaNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV30Pgmname));
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
         GXEncryptionTmp = "tooltip.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TooltipId,8,0));
         return formatLink("tooltip.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Tooltip" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tooltip" ;
      }

      protected void InitializeNonKey1A53( )
      {
         A135CampoId = 0;
         AssignAttri("", false, "A135CampoId", StringUtil.LTrimStr( (decimal)(A135CampoId), 8, 0));
         A139TooltipTelaId = 0;
         AssignAttri("", false, "A139TooltipTelaId", StringUtil.LTrimStr( (decimal)(A139TooltipTelaId), 8, 0));
         A115TooltipDescricao = "";
         AssignAttri("", false, "A115TooltipDescricao", A115TooltipDescricao);
         AV17tooltipexiste = false;
         AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
         A136CampoNome = "";
         AssignAttri("", false, "A136CampoNome", A136CampoNome);
         A140TooltipTelaNome = "";
         AssignAttri("", false, "A140TooltipTelaNome", A140TooltipTelaNome);
         A118TooltipAtivo = true;
         AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
         Z118TooltipAtivo = false;
         Z135CampoId = 0;
         Z139TooltipTelaId = 0;
      }

      protected void InitAll1A53( )
      {
         A112TooltipId = 0;
         AssignAttri("", false, "A112TooltipId", StringUtil.LTrimStr( (decimal)(A112TooltipId), 8, 0));
         InitializeNonKey1A53( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A118TooltipAtivo = i118TooltipAtivo;
         AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910463411", true, true);
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
         context.AddJavascriptSource("tooltip.js", "?202311910463413", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         dynTooltipTelaId_Internalname = "TOOLTIPTELAID";
         dynCampoId_Internalname = "CAMPOID";
         edtTooltipDescricao_Internalname = "TOOLTIPDESCRICAO";
         cmbTooltipAtivo_Internalname = "TOOLTIPATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTooltipId_Internalname = "TOOLTIPID";
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
         Form.Caption = "Tooltip";
         edtTooltipId_Jsonclick = "";
         edtTooltipId_Enabled = 0;
         edtTooltipId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTooltipAtivo_Jsonclick = "";
         cmbTooltipAtivo.Enabled = 1;
         cmbTooltipAtivo.Visible = 1;
         edtTooltipDescricao_Enabled = 1;
         dynCampoId_Jsonclick = "";
         dynCampoId.Enabled = 1;
         dynTooltipTelaId_Jsonclick = "";
         dynTooltipTelaId.Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "TOOLTIP";
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
         GXACAMPOID_html1A53( A139TooltipTelaId) ;
         /* End function dynload_actions */
      }

      protected void GXDLATOOLTIPTELAID1A53( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATOOLTIPTELAID_data1A53( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXATOOLTIPTELAID_html1A53( )
      {
         int gxdynajaxvalue;
         GXDLATOOLTIPTELAID_data1A53( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTooltipTelaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTooltipTelaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATOOLTIPTELAID_data1A53( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor T001A18 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001A18_A139TooltipTelaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001A18_A140TooltipTelaNome[0]);
            pr_default.readNext(16);
         }
         pr_default.close(16);
      }

      protected void GXDLACAMPOID1A53( int A139TooltipTelaId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACAMPOID_data1A53( A139TooltipTelaId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXACAMPOID_html1A53( int A139TooltipTelaId )
      {
         int gxdynajaxvalue;
         GXDLACAMPOID_data1A53( A139TooltipTelaId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynCampoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynCampoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLACAMPOID_data1A53( int A139TooltipTelaId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor T001A19 */
         pr_default.execute(17, new Object[] {A139TooltipTelaId});
         while ( (pr_default.getStatus(17) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001A19_A135CampoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001A19_A136CampoNome[0]);
            pr_default.readNext(17);
         }
         pr_default.close(17);
      }

      protected void GX10ASATOOLTIPEXISTE1A53( int A112TooltipId ,
                                               int A139TooltipTelaId ,
                                               int A135CampoId )
      {
         GXt_int1 = 0;
         new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
         AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV17tooltipexiste))+"\"") ;
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
         dynTooltipTelaId.Name = "TOOLTIPTELAID";
         dynTooltipTelaId.WebTags = "";
         dynCampoId.Name = "CAMPOID";
         dynCampoId.WebTags = "";
         cmbTooltipAtivo.Name = "TOOLTIPATIVO";
         cmbTooltipAtivo.WebTags = "";
         cmbTooltipAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbTooltipAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbTooltipAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A118TooltipAtivo) )
            {
               A118TooltipAtivo = true;
               AssignAttri("", false, "A118TooltipAtivo", A118TooltipAtivo);
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

      public void Valid_Tooltiptelaid( )
      {
         A139TooltipTelaId = (int)(NumberUtil.Val( dynTooltipTelaId.CurrentValue, "."));
         A135CampoId = (int)(NumberUtil.Val( dynCampoId.CurrentValue, "."));
         /* Using cursor T001A20 */
         pr_default.execute(18, new Object[] {A139TooltipTelaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tooltip Tela'.", "ForeignKeyNotFound", 1, "TOOLTIPTELAID");
            AnyError = 1;
            GX_FocusControl = dynTooltipTelaId_Internalname;
         }
         A140TooltipTelaNome = T001A20_A140TooltipTelaNome[0];
         pr_default.close(18);
         GXACAMPOID_html1A53( A139TooltipTelaId) ;
         dynload_actions( ) ;
         if ( dynCampoId.ItemCount > 0 )
         {
            A135CampoId = (int)(NumberUtil.Val( dynCampoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCampoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A140TooltipTelaNome", A140TooltipTelaNome);
         AssignAttri("", false, "A135CampoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135CampoId), 8, 0, ".", "")));
         dynCampoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135CampoId), 8, 0));
         AssignProp("", false, dynCampoId_Internalname, "Values", dynCampoId.ToJavascriptSource(), true);
      }

      public void Valid_Campoid( )
      {
         A139TooltipTelaId = (int)(NumberUtil.Val( dynTooltipTelaId.CurrentValue, "."));
         A135CampoId = (int)(NumberUtil.Val( dynCampoId.CurrentValue, "."));
         /* Using cursor T001A21 */
         pr_default.execute(19, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("Não existe 'Campo'.", "ForeignKeyNotFound", 1, "CAMPOID");
            AnyError = 1;
            GX_FocusControl = dynCampoId_Internalname;
         }
         A136CampoNome = T001A21_A136CampoNome[0];
         pr_default.close(19);
         GXt_int1 = 0;
         new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
         AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         if ( AV17tooltipexiste )
         {
            GX_msglist.addItem("Nome da tela e nome do campo já cadastrados, revise o cadastro.", 1, "CAMPOID");
            AnyError = 1;
            GX_FocusControl = dynCampoId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A136CampoNome", A136CampoNome);
         AssignAttri("", false, "AV17tooltipexiste", AV17tooltipexiste);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TooltipId',fld:'vTOOLTIPID',pic:'ZZZZZZZ9',hsh:true},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TooltipId',fld:'vTOOLTIPID',pic:'ZZZZZZZ9',hsh:true},{av:'A112TooltipId',fld:'TOOLTIPID',pic:'ZZZZZZZ9'},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E121A2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_TOOLTIPTELAID","{handler:'Valid_Tooltiptelaid',iparms:[{av:'A140TooltipTelaNome',fld:'TOOLTIPTELANOME',pic:''},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_TOOLTIPTELAID",",oparms:[{av:'A140TooltipTelaNome',fld:'TOOLTIPTELANOME',pic:''},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_CAMPOID","{handler:'Valid_Campoid',iparms:[{av:'A112TooltipId',fld:'TOOLTIPID',pic:'ZZZZZZZ9'},{av:'AV17tooltipexiste',fld:'vTOOLTIPEXISTE',pic:''},{av:'A136CampoNome',fld:'CAMPONOME',pic:''},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_CAMPOID",",oparms:[{av:'A136CampoNome',fld:'CAMPONOME',pic:''},{av:'AV17tooltipexiste',fld:'vTOOLTIPEXISTE',pic:''},{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_TOOLTIPDESCRICAO","{handler:'Valid_Tooltipdescricao',iparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_TOOLTIPDESCRICAO",",oparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_TOOLTIPID","{handler:'Valid_Tooltipid',iparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_TOOLTIPID",",oparms:[{av:'dynTooltipTelaId'},{av:'A139TooltipTelaId',fld:'TOOLTIPTELAID',pic:'ZZZZZZZ9'},{av:'dynCampoId'},{av:'A135CampoId',fld:'CAMPOID',pic:'ZZZZZZZ9'}]}");
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
         pr_default.close(19);
         pr_default.close(13);
         pr_default.close(18);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         A115TooltipDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A136CampoNome = "";
         A140TooltipTelaNome = "";
         AV30Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode53 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV27TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z115TooltipDescricao = "";
         Z136CampoNome = "";
         Z140TooltipTelaNome = "";
         T001A5_A140TooltipTelaNome = new string[] {""} ;
         T001A4_A136CampoNome = new string[] {""} ;
         T001A6_A112TooltipId = new int[1] ;
         T001A6_A115TooltipDescricao = new string[] {""} ;
         T001A6_A118TooltipAtivo = new bool[] {false} ;
         T001A6_A136CampoNome = new string[] {""} ;
         T001A6_A140TooltipTelaNome = new string[] {""} ;
         T001A6_A135CampoId = new int[1] ;
         T001A6_A139TooltipTelaId = new int[1] ;
         T001A7_A136CampoNome = new string[] {""} ;
         T001A8_A140TooltipTelaNome = new string[] {""} ;
         T001A9_A112TooltipId = new int[1] ;
         T001A3_A112TooltipId = new int[1] ;
         T001A3_A115TooltipDescricao = new string[] {""} ;
         T001A3_A118TooltipAtivo = new bool[] {false} ;
         T001A3_A135CampoId = new int[1] ;
         T001A3_A139TooltipTelaId = new int[1] ;
         T001A10_A112TooltipId = new int[1] ;
         T001A11_A112TooltipId = new int[1] ;
         T001A2_A112TooltipId = new int[1] ;
         T001A2_A115TooltipDescricao = new string[] {""} ;
         T001A2_A118TooltipAtivo = new bool[] {false} ;
         T001A2_A135CampoId = new int[1] ;
         T001A2_A139TooltipTelaId = new int[1] ;
         T001A12_A112TooltipId = new int[1] ;
         T001A15_A136CampoNome = new string[] {""} ;
         T001A16_A140TooltipTelaNome = new string[] {""} ;
         T001A17_A112TooltipId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001A18_A139TooltipTelaId = new int[1] ;
         T001A18_A140TooltipTelaNome = new string[] {""} ;
         T001A18_A137TelaAtivo = new bool[] {false} ;
         T001A18_n137TelaAtivo = new bool[] {false} ;
         T001A19_A135CampoId = new int[1] ;
         T001A19_A136CampoNome = new string[] {""} ;
         T001A19_A138CampoAtivo = new bool[] {false} ;
         T001A19_A133TelaId = new int[1] ;
         T001A20_A140TooltipTelaNome = new string[] {""} ;
         T001A21_A136CampoNome = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tooltip__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tooltip__default(),
            new Object[][] {
                new Object[] {
               T001A2_A112TooltipId, T001A2_A115TooltipDescricao, T001A2_A118TooltipAtivo, T001A2_A135CampoId, T001A2_A139TooltipTelaId
               }
               , new Object[] {
               T001A3_A112TooltipId, T001A3_A115TooltipDescricao, T001A3_A118TooltipAtivo, T001A3_A135CampoId, T001A3_A139TooltipTelaId
               }
               , new Object[] {
               T001A4_A136CampoNome
               }
               , new Object[] {
               T001A5_A140TooltipTelaNome
               }
               , new Object[] {
               T001A6_A112TooltipId, T001A6_A115TooltipDescricao, T001A6_A118TooltipAtivo, T001A6_A136CampoNome, T001A6_A140TooltipTelaNome, T001A6_A135CampoId, T001A6_A139TooltipTelaId
               }
               , new Object[] {
               T001A7_A136CampoNome
               }
               , new Object[] {
               T001A8_A140TooltipTelaNome
               }
               , new Object[] {
               T001A9_A112TooltipId
               }
               , new Object[] {
               T001A10_A112TooltipId
               }
               , new Object[] {
               T001A11_A112TooltipId
               }
               , new Object[] {
               T001A12_A112TooltipId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001A15_A136CampoNome
               }
               , new Object[] {
               T001A16_A140TooltipTelaNome
               }
               , new Object[] {
               T001A17_A112TooltipId
               }
               , new Object[] {
               T001A18_A139TooltipTelaId, T001A18_A140TooltipTelaNome, T001A18_A137TelaAtivo, T001A18_n137TelaAtivo
               }
               , new Object[] {
               T001A19_A135CampoId, T001A19_A136CampoNome, T001A19_A138CampoAtivo, T001A19_A133TelaId
               }
               , new Object[] {
               T001A20_A140TooltipTelaNome
               }
               , new Object[] {
               T001A21_A136CampoNome
               }
            }
         );
         AV30Pgmname = "Tooltip";
         Z118TooltipAtivo = true;
         A118TooltipAtivo = true;
         i118TooltipAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound53 ;
      private short GX_JID ;
      private short nIsDirty_53 ;
      private short gxajaxcallmode ;
      private short GXt_int1 ;
      private int wcpOAV7TooltipId ;
      private int Z112TooltipId ;
      private int Z135CampoId ;
      private int Z139TooltipTelaId ;
      private int N135CampoId ;
      private int N139TooltipTelaId ;
      private int A139TooltipTelaId ;
      private int A112TooltipId ;
      private int A135CampoId ;
      private int AV7TooltipId ;
      private int trnEnded ;
      private int edtTooltipDescricao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtTooltipId_Enabled ;
      private int edtTooltipId_Visible ;
      private int AV26Insert_CampoId ;
      private int AV28Insert_TooltipTelaId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV31GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
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
      private string dynTooltipTelaId_Internalname ;
      private string dynCampoId_Internalname ;
      private string cmbTooltipAtivo_Internalname ;
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
      private string dynTooltipTelaId_Jsonclick ;
      private string dynCampoId_Jsonclick ;
      private string edtTooltipDescricao_Internalname ;
      private string cmbTooltipAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTooltipId_Internalname ;
      private string edtTooltipId_Jsonclick ;
      private string AV30Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode53 ;
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
      private string gxwrpcisep ;
      private bool Z118TooltipAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A118TooltipAtivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV17tooltipexiste ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i118TooltipAtivo ;
      private bool gxdyncontrolsrefreshing ;
      private bool ZV17tooltipexiste ;
      private string A115TooltipDescricao ;
      private string Z115TooltipDescricao ;
      private string A136CampoNome ;
      private string A140TooltipTelaNome ;
      private string Z136CampoNome ;
      private string Z140TooltipTelaNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTooltipTelaId ;
      private GXCombobox dynCampoId ;
      private GXCombobox cmbTooltipAtivo ;
      private IDataStoreProvider pr_default ;
      private string[] T001A5_A140TooltipTelaNome ;
      private string[] T001A4_A136CampoNome ;
      private int[] T001A6_A112TooltipId ;
      private string[] T001A6_A115TooltipDescricao ;
      private bool[] T001A6_A118TooltipAtivo ;
      private string[] T001A6_A136CampoNome ;
      private string[] T001A6_A140TooltipTelaNome ;
      private int[] T001A6_A135CampoId ;
      private int[] T001A6_A139TooltipTelaId ;
      private string[] T001A7_A136CampoNome ;
      private string[] T001A8_A140TooltipTelaNome ;
      private int[] T001A9_A112TooltipId ;
      private int[] T001A3_A112TooltipId ;
      private string[] T001A3_A115TooltipDescricao ;
      private bool[] T001A3_A118TooltipAtivo ;
      private int[] T001A3_A135CampoId ;
      private int[] T001A3_A139TooltipTelaId ;
      private int[] T001A10_A112TooltipId ;
      private int[] T001A11_A112TooltipId ;
      private int[] T001A2_A112TooltipId ;
      private string[] T001A2_A115TooltipDescricao ;
      private bool[] T001A2_A118TooltipAtivo ;
      private int[] T001A2_A135CampoId ;
      private int[] T001A2_A139TooltipTelaId ;
      private int[] T001A12_A112TooltipId ;
      private string[] T001A15_A136CampoNome ;
      private string[] T001A16_A140TooltipTelaNome ;
      private int[] T001A17_A112TooltipId ;
      private int[] T001A18_A139TooltipTelaId ;
      private string[] T001A18_A140TooltipTelaNome ;
      private bool[] T001A18_A137TelaAtivo ;
      private bool[] T001A18_n137TelaAtivo ;
      private int[] T001A19_A135CampoId ;
      private string[] T001A19_A136CampoNome ;
      private bool[] T001A19_A138CampoAtivo ;
      private int[] T001A19_A133TelaId ;
      private string[] T001A20_A140TooltipTelaNome ;
      private string[] T001A21_A136CampoNome ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV27TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class tooltip__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tooltip__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001A6;
        prmT001A6 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A4;
        prmT001A4 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001A5;
        prmT001A5 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmT001A7;
        prmT001A7 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001A8;
        prmT001A8 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmT001A9;
        prmT001A9 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A3;
        prmT001A3 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A10;
        prmT001A10 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A11;
        prmT001A11 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A2;
        prmT001A2 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A12;
        prmT001A12 = new Object[] {
        new ParDef("@TooltipDescricao",GXType.NVarChar,2097152,0) ,
        new ParDef("@TooltipAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CampoId",GXType.Int32,8,0) ,
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmT001A13;
        prmT001A13 = new Object[] {
        new ParDef("@TooltipDescricao",GXType.NVarChar,2097152,0) ,
        new ParDef("@TooltipAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CampoId",GXType.Int32,8,0) ,
        new ParDef("@TooltipTelaId",GXType.Int32,8,0) ,
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A14;
        prmT001A14 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmT001A15;
        prmT001A15 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmT001A16;
        prmT001A16 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmT001A17;
        prmT001A17 = new Object[] {
        };
        Object[] prmT001A18;
        prmT001A18 = new Object[] {
        };
        Object[] prmT001A19;
        prmT001A19 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmT001A20;
        prmT001A20 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmT001A21;
        prmT001A21 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001A2", "SELECT [TooltipId], [TooltipDescricao], [TooltipAtivo], [CampoId], [TooltipTelaId] AS TooltipTelaId FROM [Tooltip] WITH (UPDLOCK) WHERE [TooltipId] = @TooltipId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A3", "SELECT [TooltipId], [TooltipDescricao], [TooltipAtivo], [CampoId], [TooltipTelaId] AS TooltipTelaId FROM [Tooltip] WHERE [TooltipId] = @TooltipId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A4", "SELECT [CampoNome] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A5", "SELECT [TelaNome] AS TooltipTelaNome FROM [Tela] WHERE [TelaId] = @TooltipTelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A6", "SELECT TM1.[TooltipId], TM1.[TooltipDescricao], TM1.[TooltipAtivo], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, TM1.[CampoId], TM1.[TooltipTelaId] AS TooltipTelaId FROM (([Tooltip] TM1 INNER JOIN [Campo] T2 ON T2.[CampoId] = TM1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = TM1.[TooltipTelaId]) WHERE TM1.[TooltipId] = @TooltipId ORDER BY TM1.[TooltipId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001A6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A7", "SELECT [CampoNome] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A8", "SELECT [TelaNome] AS TooltipTelaNome FROM [Tela] WHERE [TelaId] = @TooltipTelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A9", "SELECT [TooltipId] FROM [Tooltip] WHERE [TooltipId] = @TooltipId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A10", "SELECT TOP 1 [TooltipId] FROM [Tooltip] WHERE ( [TooltipId] > @TooltipId) ORDER BY [TooltipId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001A10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001A11", "SELECT TOP 1 [TooltipId] FROM [Tooltip] WHERE ( [TooltipId] < @TooltipId) ORDER BY [TooltipId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001A12", "INSERT INTO [Tooltip]([TooltipDescricao], [TooltipAtivo], [CampoId], [TooltipTelaId]) VALUES(@TooltipDescricao, @TooltipAtivo, @CampoId, @TooltipTelaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001A12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001A13", "UPDATE [Tooltip] SET [TooltipDescricao]=@TooltipDescricao, [TooltipAtivo]=@TooltipAtivo, [CampoId]=@CampoId, [TooltipTelaId]=@TooltipTelaId  WHERE [TooltipId] = @TooltipId", GxErrorMask.GX_NOMASK,prmT001A13)
           ,new CursorDef("T001A14", "DELETE FROM [Tooltip]  WHERE [TooltipId] = @TooltipId", GxErrorMask.GX_NOMASK,prmT001A14)
           ,new CursorDef("T001A15", "SELECT [CampoNome] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A16", "SELECT [TelaNome] AS TooltipTelaNome FROM [Tela] WHERE [TelaId] = @TooltipTelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A17", "SELECT [TooltipId] FROM [Tooltip] ORDER BY [TooltipId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001A17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A18", "SELECT [TelaId] AS TooltipTelaId, [TelaNome] AS TooltipTelaNome, [TelaAtivo] FROM [Tela] WHERE [TelaAtivo] = 1 ORDER BY [TelaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A18,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A19", "SELECT [CampoId], [CampoNome], [CampoAtivo], [TelaId] FROM [Campo] WHERE ([CampoAtivo] = 1) AND ([TelaId] = @TooltipTelaId) ORDER BY [CampoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A19,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A20", "SELECT [TelaNome] AS TooltipTelaNome FROM [Tela] WHERE [TelaId] = @TooltipTelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001A21", "SELECT [CampoNome] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A21,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
