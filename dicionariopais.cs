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
   public class dicionariopais : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A4PaisId = (int)(NumberUtil.Val( GetPar( "PaisId"), "."));
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A4PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A98DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A98DocDicionarioId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "dicionariopais.aspx")), "dicionariopais.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "dicionariopais.aspx")))) ;
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
                  AV7PaisId = (int)(NumberUtil.Val( GetPar( "PaisId"), "."));
                  AssignAttri("", false, "AV7PaisId", StringUtil.LTrimStr( (decimal)(AV7PaisId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PaisId), "ZZZZZZZ9"), context));
                  AV8DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
                  AssignAttri("", false, "AV8DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV8DocDicionarioId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCDICIONARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocDicionarioId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Dicionario Pais", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public dicionariopais( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariopais( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PaisId ,
                           int aP2_DocDicionarioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PaisId = aP1_PaisId;
         this.AV8DocDicionarioId = aP2_DocDicionarioId;
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
            return "dicionariopais_Execute" ;
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
         GxWebStd.gx_div_start( context, divTablesplittedpaisid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpaisid_Internalname, "Pais", "", "", lblTextblockpaisid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DicionarioPais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paisid.SetProperty("Caption", Combo_paisid_Caption);
         ucCombo_paisid.SetProperty("Cls", Combo_paisid_Cls);
         ucCombo_paisid.SetProperty("DataListProc", Combo_paisid_Datalistproc);
         ucCombo_paisid.SetProperty("DataListProcParametersPrefix", Combo_paisid_Datalistprocparametersprefix);
         ucCombo_paisid.SetProperty("EmptyItem", Combo_paisid_Emptyitem);
         ucCombo_paisid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_paisid.SetProperty("DropDownOptionsData", AV14PaisId_Data);
         ucCombo_paisid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paisid_Internalname, "COMBO_PAISIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisId_Internalname, "Id do Pa�s", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4PaisId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4PaisId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", edtPaisId_Visible, edtPaisId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DicionarioPais.htm");
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
         GxWebStd.gx_div_start( context, divTablesplitteddocdicionarioid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdocdicionarioid_Internalname, "Doc Dicionario", "", "", lblTextblockdocdicionarioid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DicionarioPais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_docdicionarioid.SetProperty("Caption", Combo_docdicionarioid_Caption);
         ucCombo_docdicionarioid.SetProperty("Cls", Combo_docdicionarioid_Cls);
         ucCombo_docdicionarioid.SetProperty("DataListProc", Combo_docdicionarioid_Datalistproc);
         ucCombo_docdicionarioid.SetProperty("DataListProcParametersPrefix", Combo_docdicionarioid_Datalistprocparametersprefix);
         ucCombo_docdicionarioid.SetProperty("EmptyItem", Combo_docdicionarioid_Emptyitem);
         ucCombo_docdicionarioid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_docdicionarioid.SetProperty("DropDownOptionsData", AV22DocDicionarioId_Data);
         ucCombo_docdicionarioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_docdicionarioid_Internalname, "COMBO_DOCDICIONARIOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocDicionarioId_Internalname, "Doc Dicionario Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDicionarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDicionarioId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocDicionarioId_Visible, edtDocDicionarioId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DicionarioPais.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DicionarioPais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DicionarioPais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DicionarioPais.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_paisid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombopaisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboPaisId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombopaisid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboPaisId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboPaisId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaisid_Visible, edtavCombopaisid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DicionarioPais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_docdicionarioid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombodocdicionarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ComboDocDicionarioId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombodocdicionarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23ComboDocDicionarioId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23ComboDocDicionarioId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodocdicionarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodocdicionarioid_Visible, edtavCombodocdicionarioid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DicionarioPais.htm");
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
         E111H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPAISID_DATA"), AV14PaisId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDOCDICIONARIOID_DATA"), AV22DocDicionarioId_Data);
               /* Read saved values. */
               Z4PaisId = (int)(context.localUtil.CToN( cgiGet( "Z4PaisId"), ",", "."));
               Z98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( "Z98DocDicionarioId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7PaisId = (int)(context.localUtil.CToN( cgiGet( "vPAISID"), ",", "."));
               AV8DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( "vDOCDICIONARIOID"), ",", "."));
               Combo_paisid_Objectcall = cgiGet( "COMBO_PAISID_Objectcall");
               Combo_paisid_Class = cgiGet( "COMBO_PAISID_Class");
               Combo_paisid_Icontype = cgiGet( "COMBO_PAISID_Icontype");
               Combo_paisid_Icon = cgiGet( "COMBO_PAISID_Icon");
               Combo_paisid_Caption = cgiGet( "COMBO_PAISID_Caption");
               Combo_paisid_Tooltip = cgiGet( "COMBO_PAISID_Tooltip");
               Combo_paisid_Cls = cgiGet( "COMBO_PAISID_Cls");
               Combo_paisid_Selectedvalue_set = cgiGet( "COMBO_PAISID_Selectedvalue_set");
               Combo_paisid_Selectedvalue_get = cgiGet( "COMBO_PAISID_Selectedvalue_get");
               Combo_paisid_Selectedtext_set = cgiGet( "COMBO_PAISID_Selectedtext_set");
               Combo_paisid_Selectedtext_get = cgiGet( "COMBO_PAISID_Selectedtext_get");
               Combo_paisid_Gamoauthtoken = cgiGet( "COMBO_PAISID_Gamoauthtoken");
               Combo_paisid_Ddointernalname = cgiGet( "COMBO_PAISID_Ddointernalname");
               Combo_paisid_Titlecontrolalign = cgiGet( "COMBO_PAISID_Titlecontrolalign");
               Combo_paisid_Dropdownoptionstype = cgiGet( "COMBO_PAISID_Dropdownoptionstype");
               Combo_paisid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Enabled"));
               Combo_paisid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Visible"));
               Combo_paisid_Titlecontrolidtoreplace = cgiGet( "COMBO_PAISID_Titlecontrolidtoreplace");
               Combo_paisid_Datalisttype = cgiGet( "COMBO_PAISID_Datalisttype");
               Combo_paisid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Allowmultipleselection"));
               Combo_paisid_Datalistfixedvalues = cgiGet( "COMBO_PAISID_Datalistfixedvalues");
               Combo_paisid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Isgriditem"));
               Combo_paisid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Hasdescription"));
               Combo_paisid_Datalistproc = cgiGet( "COMBO_PAISID_Datalistproc");
               Combo_paisid_Datalistprocparametersprefix = cgiGet( "COMBO_PAISID_Datalistprocparametersprefix");
               Combo_paisid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAISID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_paisid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Includeonlyselectedoption"));
               Combo_paisid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Includeselectalloption"));
               Combo_paisid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Emptyitem"));
               Combo_paisid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Includeaddnewoption"));
               Combo_paisid_Htmltemplate = cgiGet( "COMBO_PAISID_Htmltemplate");
               Combo_paisid_Multiplevaluestype = cgiGet( "COMBO_PAISID_Multiplevaluestype");
               Combo_paisid_Loadingdata = cgiGet( "COMBO_PAISID_Loadingdata");
               Combo_paisid_Noresultsfound = cgiGet( "COMBO_PAISID_Noresultsfound");
               Combo_paisid_Emptyitemtext = cgiGet( "COMBO_PAISID_Emptyitemtext");
               Combo_paisid_Onlyselectedvalues = cgiGet( "COMBO_PAISID_Onlyselectedvalues");
               Combo_paisid_Selectalltext = cgiGet( "COMBO_PAISID_Selectalltext");
               Combo_paisid_Multiplevaluesseparator = cgiGet( "COMBO_PAISID_Multiplevaluesseparator");
               Combo_paisid_Addnewoptiontext = cgiGet( "COMBO_PAISID_Addnewoptiontext");
               Combo_paisid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAISID_Gxcontroltype"), ",", "."));
               Combo_docdicionarioid_Objectcall = cgiGet( "COMBO_DOCDICIONARIOID_Objectcall");
               Combo_docdicionarioid_Class = cgiGet( "COMBO_DOCDICIONARIOID_Class");
               Combo_docdicionarioid_Icontype = cgiGet( "COMBO_DOCDICIONARIOID_Icontype");
               Combo_docdicionarioid_Icon = cgiGet( "COMBO_DOCDICIONARIOID_Icon");
               Combo_docdicionarioid_Caption = cgiGet( "COMBO_DOCDICIONARIOID_Caption");
               Combo_docdicionarioid_Tooltip = cgiGet( "COMBO_DOCDICIONARIOID_Tooltip");
               Combo_docdicionarioid_Cls = cgiGet( "COMBO_DOCDICIONARIOID_Cls");
               Combo_docdicionarioid_Selectedvalue_set = cgiGet( "COMBO_DOCDICIONARIOID_Selectedvalue_set");
               Combo_docdicionarioid_Selectedvalue_get = cgiGet( "COMBO_DOCDICIONARIOID_Selectedvalue_get");
               Combo_docdicionarioid_Selectedtext_set = cgiGet( "COMBO_DOCDICIONARIOID_Selectedtext_set");
               Combo_docdicionarioid_Selectedtext_get = cgiGet( "COMBO_DOCDICIONARIOID_Selectedtext_get");
               Combo_docdicionarioid_Gamoauthtoken = cgiGet( "COMBO_DOCDICIONARIOID_Gamoauthtoken");
               Combo_docdicionarioid_Ddointernalname = cgiGet( "COMBO_DOCDICIONARIOID_Ddointernalname");
               Combo_docdicionarioid_Titlecontrolalign = cgiGet( "COMBO_DOCDICIONARIOID_Titlecontrolalign");
               Combo_docdicionarioid_Dropdownoptionstype = cgiGet( "COMBO_DOCDICIONARIOID_Dropdownoptionstype");
               Combo_docdicionarioid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Enabled"));
               Combo_docdicionarioid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Visible"));
               Combo_docdicionarioid_Titlecontrolidtoreplace = cgiGet( "COMBO_DOCDICIONARIOID_Titlecontrolidtoreplace");
               Combo_docdicionarioid_Datalisttype = cgiGet( "COMBO_DOCDICIONARIOID_Datalisttype");
               Combo_docdicionarioid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Allowmultipleselection"));
               Combo_docdicionarioid_Datalistfixedvalues = cgiGet( "COMBO_DOCDICIONARIOID_Datalistfixedvalues");
               Combo_docdicionarioid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Isgriditem"));
               Combo_docdicionarioid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Hasdescription"));
               Combo_docdicionarioid_Datalistproc = cgiGet( "COMBO_DOCDICIONARIOID_Datalistproc");
               Combo_docdicionarioid_Datalistprocparametersprefix = cgiGet( "COMBO_DOCDICIONARIOID_Datalistprocparametersprefix");
               Combo_docdicionarioid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_DOCDICIONARIOID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_docdicionarioid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Includeonlyselectedoption"));
               Combo_docdicionarioid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Includeselectalloption"));
               Combo_docdicionarioid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Emptyitem"));
               Combo_docdicionarioid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCDICIONARIOID_Includeaddnewoption"));
               Combo_docdicionarioid_Htmltemplate = cgiGet( "COMBO_DOCDICIONARIOID_Htmltemplate");
               Combo_docdicionarioid_Multiplevaluestype = cgiGet( "COMBO_DOCDICIONARIOID_Multiplevaluestype");
               Combo_docdicionarioid_Loadingdata = cgiGet( "COMBO_DOCDICIONARIOID_Loadingdata");
               Combo_docdicionarioid_Noresultsfound = cgiGet( "COMBO_DOCDICIONARIOID_Noresultsfound");
               Combo_docdicionarioid_Emptyitemtext = cgiGet( "COMBO_DOCDICIONARIOID_Emptyitemtext");
               Combo_docdicionarioid_Onlyselectedvalues = cgiGet( "COMBO_DOCDICIONARIOID_Onlyselectedvalues");
               Combo_docdicionarioid_Selectalltext = cgiGet( "COMBO_DOCDICIONARIOID_Selectalltext");
               Combo_docdicionarioid_Multiplevaluesseparator = cgiGet( "COMBO_DOCDICIONARIOID_Multiplevaluesseparator");
               Combo_docdicionarioid_Addnewoptiontext = cgiGet( "COMBO_DOCDICIONARIOID_Addnewoptiontext");
               Combo_docdicionarioid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_DOCDICIONARIOID_Gxcontroltype"), ",", "."));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4PaisId = 0;
                  AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
               }
               else
               {
                  A4PaisId = (int)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
                  AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDICIONARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocDicionarioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A98DocDicionarioId = 0;
                  AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               }
               else
               {
                  A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", "."));
                  AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               }
               AV19ComboPaisId = (int)(context.localUtil.CToN( cgiGet( edtavCombopaisid_Internalname), ",", "."));
               AssignAttri("", false, "AV19ComboPaisId", StringUtil.LTrimStr( (decimal)(AV19ComboPaisId), 8, 0));
               AV23ComboDocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtavCombodocdicionarioid_Internalname), ",", "."));
               AssignAttri("", false, "AV23ComboDocDicionarioId", StringUtil.LTrimStr( (decimal)(AV23ComboDocDicionarioId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"DicionarioPais");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("dicionariopais:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A4PaisId = (int)(NumberUtil.Val( GetPar( "PaisId"), "."));
                  AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
                  A98DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
                  AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
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
                     sMode60 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode60;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound60 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAISID");
                        AnyError = 1;
                        GX_FocusControl = edtPaisId_Internalname;
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
                           E111H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121H2 ();
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
            E121H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1H60( ) ;
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
            DisableAttributes1H60( ) ;
         }
         AssignProp("", false, edtavCombopaisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaisid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombodocdicionarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocdicionarioid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1H0( )
      {
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1H60( ) ;
            }
            else
            {
               CheckExtendedTable1H60( ) ;
               CloseExtendedTableCursors1H60( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1H0( )
      {
      }

      protected void E111H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV21GAMErrors);
         Combo_docdicionarioid_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_docdicionarioid.SendProperty(context, "", false, Combo_docdicionarioid_Internalname, "GAMOAuthToken", Combo_docdicionarioid_Gamoauthtoken);
         edtDocDicionarioId_Visible = 0;
         AssignProp("", false, edtDocDicionarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Visible), 5, 0), true);
         AV23ComboDocDicionarioId = 0;
         AssignAttri("", false, "AV23ComboDocDicionarioId", StringUtil.LTrimStr( (decimal)(AV23ComboDocDicionarioId), 8, 0));
         edtavCombodocdicionarioid_Visible = 0;
         AssignProp("", false, edtavCombodocdicionarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodocdicionarioid_Visible), 5, 0), true);
         Combo_paisid_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "GAMOAuthToken", Combo_paisid_Gamoauthtoken);
         edtPaisId_Visible = 0;
         AssignProp("", false, edtPaisId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisId_Visible), 5, 0), true);
         AV19ComboPaisId = 0;
         AssignAttri("", false, "AV19ComboPaisId", StringUtil.LTrimStr( (decimal)(AV19ComboPaisId), 8, 0));
         edtavCombopaisid_Visible = 0;
         AssignProp("", false, edtavCombopaisid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopaisid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPAISID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBODOCDICIONARIOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E121H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("dicionariopaisww.aspx") );
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
         /* 'LOADCOMBODOCDICIONARIOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new dicionariopaisloaddvcombo(context ).execute(  "DocDicionarioId",  Gx_mode,  false,  AV7PaisId,  AV8DocDicionarioId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AV18Combo_DataJson = GXt_char2;
         Combo_docdicionarioid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_docdicionarioid.SendProperty(context, "", false, Combo_docdicionarioid_Internalname, "SelectedValue_set", Combo_docdicionarioid_Selectedvalue_set);
         Combo_docdicionarioid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_docdicionarioid.SendProperty(context, "", false, Combo_docdicionarioid_Internalname, "SelectedText_set", Combo_docdicionarioid_Selectedtext_set);
         AV23ComboDocDicionarioId = (int)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV23ComboDocDicionarioId", StringUtil.LTrimStr( (decimal)(AV23ComboDocDicionarioId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV8DocDicionarioId) )
         {
            Combo_docdicionarioid_Enabled = false;
            ucCombo_docdicionarioid.SendProperty(context, "", false, Combo_docdicionarioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_docdicionarioid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPAISID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new dicionariopaisloaddvcombo(context ).execute(  "PaisId",  Gx_mode,  false,  AV7PaisId,  AV8DocDicionarioId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AV18Combo_DataJson = GXt_char2;
         Combo_paisid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
         Combo_paisid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedText_set", Combo_paisid_Selectedtext_set);
         AV19ComboPaisId = (int)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV19ComboPaisId", StringUtil.LTrimStr( (decimal)(AV19ComboPaisId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7PaisId) )
         {
            Combo_paisid_Enabled = false;
            ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
         }
      }

      protected void ZM1H60( short GX_JID )
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
            Z4PaisId = A4PaisId;
            Z98DocDicionarioId = A98DocDicionarioId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PaisId) )
         {
            edtPaisId_Enabled = 0;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisId_Enabled = 1;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7PaisId) )
         {
            edtPaisId_Enabled = 0;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8DocDicionarioId) )
         {
            edtDocDicionarioId_Enabled = 0;
            AssignProp("", false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocDicionarioId_Enabled = 1;
            AssignProp("", false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8DocDicionarioId) )
         {
            edtDocDicionarioId_Enabled = 0;
            AssignProp("", false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8DocDicionarioId) )
         {
            A98DocDicionarioId = AV8DocDicionarioId;
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         else
         {
            A98DocDicionarioId = AV23ComboDocDicionarioId;
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         if ( ! (0==AV7PaisId) )
         {
            A4PaisId = AV7PaisId;
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
         }
         else
         {
            A4PaisId = AV19ComboPaisId;
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
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

      protected void Load1H60( )
      {
         /* Using cursor T001H6 */
         pr_default.execute(4, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound60 = 1;
            ZM1H60( -7) ;
         }
         pr_default.close(4);
         OnLoadActions1H60( ) ;
      }

      protected void OnLoadActions1H60( )
      {
      }

      protected void CheckExtendedTable1H60( )
      {
         nIsDirty_60 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001H4 */
         pr_default.execute(2, new Object[] {A4PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001H5 */
         pr_default.execute(3, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("N�o existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
            AnyError = 1;
            GX_FocusControl = edtDocDicionarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1H60( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( int A4PaisId )
      {
         /* Using cursor T001H7 */
         pr_default.execute(5, new Object[] {A4PaisId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
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

      protected void gxLoad_9( int A98DocDicionarioId )
      {
         /* Using cursor T001H8 */
         pr_default.execute(6, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("N�o existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
            AnyError = 1;
            GX_FocusControl = edtDocDicionarioId_Internalname;
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

      protected void GetKey1H60( )
      {
         /* Using cursor T001H9 */
         pr_default.execute(7, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound60 = 1;
         }
         else
         {
            RcdFound60 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001H3 */
         pr_default.execute(1, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1H60( 7) ;
            RcdFound60 = 1;
            A4PaisId = T001H3_A4PaisId[0];
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
            A98DocDicionarioId = T001H3_A98DocDicionarioId[0];
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
            Z4PaisId = A4PaisId;
            Z98DocDicionarioId = A98DocDicionarioId;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1H60( ) ;
            if ( AnyError == 1 )
            {
               RcdFound60 = 0;
               InitializeNonKey1H60( ) ;
            }
            Gx_mode = sMode60;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound60 = 0;
            InitializeNonKey1H60( ) ;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode60;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H60( ) ;
         if ( RcdFound60 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound60 = 0;
         /* Using cursor T001H10 */
         pr_default.execute(8, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001H10_A4PaisId[0] < A4PaisId ) || ( T001H10_A4PaisId[0] == A4PaisId ) && ( T001H10_A98DocDicionarioId[0] < A98DocDicionarioId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001H10_A4PaisId[0] > A4PaisId ) || ( T001H10_A4PaisId[0] == A4PaisId ) && ( T001H10_A98DocDicionarioId[0] > A98DocDicionarioId ) ) )
            {
               A4PaisId = T001H10_A4PaisId[0];
               AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
               A98DocDicionarioId = T001H10_A98DocDicionarioId[0];
               AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               RcdFound60 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound60 = 0;
         /* Using cursor T001H11 */
         pr_default.execute(9, new Object[] {A4PaisId, A98DocDicionarioId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001H11_A4PaisId[0] > A4PaisId ) || ( T001H11_A4PaisId[0] == A4PaisId ) && ( T001H11_A98DocDicionarioId[0] > A98DocDicionarioId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001H11_A4PaisId[0] < A4PaisId ) || ( T001H11_A4PaisId[0] == A4PaisId ) && ( T001H11_A98DocDicionarioId[0] < A98DocDicionarioId ) ) )
            {
               A4PaisId = T001H11_A4PaisId[0];
               AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
               A98DocDicionarioId = T001H11_A98DocDicionarioId[0];
               AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               RcdFound60 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1H60( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1H60( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound60 == 1 )
            {
               if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
               {
                  A4PaisId = Z4PaisId;
                  AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
                  A98DocDicionarioId = Z98DocDicionarioId;
                  AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1H60( ) ;
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1H60( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAISID");
                     AnyError = 1;
                     GX_FocusControl = edtPaisId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaisId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1H60( ) ;
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
         if ( ( A4PaisId != Z4PaisId ) || ( A98DocDicionarioId != Z98DocDicionarioId ) )
         {
            A4PaisId = Z4PaisId;
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
            A98DocDicionarioId = Z98DocDicionarioId;
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1H60( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001H2 */
            pr_default.execute(0, new Object[] {A4PaisId, A98DocDicionarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DicionarioPais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DicionarioPais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H60( )
      {
         if ( ! IsAuthorized("dicionariopais_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H60( 0) ;
            CheckOptimisticConcurrency1H60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H12 */
                     pr_default.execute(10, new Object[] {A4PaisId, A98DocDicionarioId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("DicionarioPais");
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
                           ResetCaption1H0( ) ;
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
               Load1H60( ) ;
            }
            EndLevel1H60( ) ;
         }
         CloseExtendedTableCursors1H60( ) ;
      }

      protected void Update1H60( )
      {
         if ( ! IsAuthorized("dicionariopais_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [DicionarioPais] */
                     DeferredUpdate1H60( ) ;
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
            EndLevel1H60( ) ;
         }
         CloseExtendedTableCursors1H60( ) ;
      }

      protected void DeferredUpdate1H60( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("dicionariopais_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1H60( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H60( ) ;
            AfterConfirm1H60( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H60( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001H13 */
                  pr_default.execute(11, new Object[] {A4PaisId, A98DocDicionarioId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("DicionarioPais");
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
         sMode60 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1H60( ) ;
         Gx_mode = sMode60;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1H60( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1H60( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H60( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("dicionariopais",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("dicionariopais",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1H60( )
      {
         /* Scan By routine */
         /* Using cursor T001H14 */
         pr_default.execute(12);
         RcdFound60 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound60 = 1;
            A4PaisId = T001H14_A4PaisId[0];
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
            A98DocDicionarioId = T001H14_A98DocDicionarioId[0];
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1H60( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound60 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound60 = 1;
            A4PaisId = T001H14_A4PaisId[0];
            AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
            A98DocDicionarioId = T001H14_A98DocDicionarioId[0];
            AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
      }

      protected void ScanEnd1H60( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1H60( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H60( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H60( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H60( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H60( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H60( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H60( )
      {
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtDocDicionarioId_Enabled = 0;
         AssignProp("", false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
         edtavCombopaisid_Enabled = 0;
         AssignProp("", false, edtavCombopaisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaisid_Enabled), 5, 0), true);
         edtavCombodocdicionarioid_Enabled = 0;
         AssignProp("", false, edtavCombodocdicionarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocdicionarioid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1H60( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1H0( )
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
         GXEncryptionTmp = "dicionariopais.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PaisId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocDicionarioId,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("dicionariopais.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"DicionarioPais");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("dicionariopais:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z4PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4PaisId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z98DocDicionarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98DocDicionarioId), 8, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAISID_DATA", AV14PaisId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAISID_DATA", AV14PaisId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCDICIONARIOID_DATA", AV22DocDicionarioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCDICIONARIOID_DATA", AV22DocDicionarioId_Data);
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
         GxWebStd.gx_hidden_field( context, "vPAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PaisId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PaisId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDOCDICIONARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocDicionarioId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCDICIONARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8DocDicionarioId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Objectcall", StringUtil.RTrim( Combo_paisid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Cls", StringUtil.RTrim( Combo_paisid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_set", StringUtil.RTrim( Combo_paisid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedtext_set", StringUtil.RTrim( Combo_paisid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Gamoauthtoken", StringUtil.RTrim( Combo_paisid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Datalistproc", StringUtil.RTrim( Combo_paisid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_paisid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Emptyitem", StringUtil.BoolToStr( Combo_paisid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Objectcall", StringUtil.RTrim( Combo_docdicionarioid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Cls", StringUtil.RTrim( Combo_docdicionarioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Selectedvalue_set", StringUtil.RTrim( Combo_docdicionarioid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Selectedtext_set", StringUtil.RTrim( Combo_docdicionarioid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Gamoauthtoken", StringUtil.RTrim( Combo_docdicionarioid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Enabled", StringUtil.BoolToStr( Combo_docdicionarioid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Datalistproc", StringUtil.RTrim( Combo_docdicionarioid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_docdicionarioid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCDICIONARIOID_Emptyitem", StringUtil.BoolToStr( Combo_docdicionarioid_Emptyitem));
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
         GXEncryptionTmp = "dicionariopais.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PaisId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocDicionarioId,8,0));
         return formatLink("dicionariopais.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "DicionarioPais" ;
      }

      public override string GetPgmdesc( )
      {
         return "Dicionario Pais" ;
      }

      protected void InitializeNonKey1H60( )
      {
      }

      protected void InitAll1H60( )
      {
         A4PaisId = 0;
         AssignAttri("", false, "A4PaisId", StringUtil.LTrimStr( (decimal)(A4PaisId), 8, 0));
         A98DocDicionarioId = 0;
         AssignAttri("", false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         InitializeNonKey1H60( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023119104785", true, true);
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
         context.AddJavascriptSource("dicionariopais.js", "?2023119104786", false, true);
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
         lblTextblockpaisid_Internalname = "TEXTBLOCKPAISID";
         Combo_paisid_Internalname = "COMBO_PAISID";
         edtPaisId_Internalname = "PAISID";
         divTablesplittedpaisid_Internalname = "TABLESPLITTEDPAISID";
         lblTextblockdocdicionarioid_Internalname = "TEXTBLOCKDOCDICIONARIOID";
         Combo_docdicionarioid_Internalname = "COMBO_DOCDICIONARIOID";
         edtDocDicionarioId_Internalname = "DOCDICIONARIOID";
         divTablesplitteddocdicionarioid_Internalname = "TABLESPLITTEDDOCDICIONARIOID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopaisid_Internalname = "vCOMBOPAISID";
         divSectionattribute_paisid_Internalname = "SECTIONATTRIBUTE_PAISID";
         edtavCombodocdicionarioid_Internalname = "vCOMBODOCDICIONARIOID";
         divSectionattribute_docdicionarioid_Internalname = "SECTIONATTRIBUTE_DOCDICIONARIOID";
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
         Form.Caption = "Dicionario Pais";
         edtavCombodocdicionarioid_Jsonclick = "";
         edtavCombodocdicionarioid_Enabled = 0;
         edtavCombodocdicionarioid_Visible = 1;
         edtavCombopaisid_Jsonclick = "";
         edtavCombopaisid_Enabled = 0;
         edtavCombopaisid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocDicionarioId_Jsonclick = "";
         edtDocDicionarioId_Enabled = 1;
         edtDocDicionarioId_Visible = 1;
         Combo_docdicionarioid_Emptyitem = Convert.ToBoolean( 0);
         Combo_docdicionarioid_Datalistprocparametersprefix = " \"ComboName\": \"DocDicionarioId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaisId\": 0, \"DocDicionarioId\": 0";
         Combo_docdicionarioid_Datalistproc = "DicionarioPaisLoadDVCombo";
         Combo_docdicionarioid_Cls = "ExtendedCombo AttributeFL";
         Combo_docdicionarioid_Caption = "";
         Combo_docdicionarioid_Enabled = Convert.ToBoolean( -1);
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 1;
         edtPaisId_Visible = 1;
         Combo_paisid_Emptyitem = Convert.ToBoolean( 0);
         Combo_paisid_Datalistprocparametersprefix = " \"ComboName\": \"PaisId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaisId\": 0, \"DocDicionarioId\": 0";
         Combo_paisid_Datalistproc = "DicionarioPaisLoadDVCombo";
         Combo_paisid_Cls = "ExtendedCombo AttributeFL";
         Combo_paisid_Caption = "";
         Combo_paisid_Enabled = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informa��es Gerais";
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

      public void Valid_Paisid( )
      {
         /* Using cursor T001H15 */
         pr_default.execute(13, new Object[] {A4PaisId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Docdicionarioid( )
      {
         /* Using cursor T001H16 */
         pr_default.execute(14, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("N�o existe ''.", "ForeignKeyNotFound", 1, "DOCDICIONARIOID");
            AnyError = 1;
            GX_FocusControl = edtDocDicionarioId_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PaisId',fld:'vPAISID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PaisId',fld:'vPAISID',pic:'ZZZZZZZ9',hsh:true},{av:'AV8DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121H2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_DOCDICIONARIOID","{handler:'Valid_Docdicionarioid',iparms:[{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_DOCDICIONARIOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPAISID","{handler:'Validv_Combopaisid',iparms:[]");
         setEventMetadata("VALIDV_COMBOPAISID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBODOCDICIONARIOID","{handler:'Validv_Combodocdicionarioid',iparms:[]");
         setEventMetadata("VALIDV_COMBODOCDICIONARIOID",",oparms:[]}");
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
         Combo_docdicionarioid_Selectedvalue_get = "";
         Combo_paisid_Selectedvalue_get = "";
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
         lblTextblockpaisid_Jsonclick = "";
         ucCombo_paisid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14PaisId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockdocdicionarioid_Jsonclick = "";
         ucCombo_docdicionarioid = new GXUserControl();
         AV22DocDicionarioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Combo_paisid_Objectcall = "";
         Combo_paisid_Class = "";
         Combo_paisid_Icontype = "";
         Combo_paisid_Icon = "";
         Combo_paisid_Tooltip = "";
         Combo_paisid_Selectedvalue_set = "";
         Combo_paisid_Selectedtext_set = "";
         Combo_paisid_Selectedtext_get = "";
         Combo_paisid_Gamoauthtoken = "";
         Combo_paisid_Ddointernalname = "";
         Combo_paisid_Titlecontrolalign = "";
         Combo_paisid_Dropdownoptionstype = "";
         Combo_paisid_Titlecontrolidtoreplace = "";
         Combo_paisid_Datalisttype = "";
         Combo_paisid_Datalistfixedvalues = "";
         Combo_paisid_Htmltemplate = "";
         Combo_paisid_Multiplevaluestype = "";
         Combo_paisid_Loadingdata = "";
         Combo_paisid_Noresultsfound = "";
         Combo_paisid_Emptyitemtext = "";
         Combo_paisid_Onlyselectedvalues = "";
         Combo_paisid_Selectalltext = "";
         Combo_paisid_Multiplevaluesseparator = "";
         Combo_paisid_Addnewoptiontext = "";
         Combo_docdicionarioid_Objectcall = "";
         Combo_docdicionarioid_Class = "";
         Combo_docdicionarioid_Icontype = "";
         Combo_docdicionarioid_Icon = "";
         Combo_docdicionarioid_Tooltip = "";
         Combo_docdicionarioid_Selectedvalue_set = "";
         Combo_docdicionarioid_Selectedtext_set = "";
         Combo_docdicionarioid_Selectedtext_get = "";
         Combo_docdicionarioid_Gamoauthtoken = "";
         Combo_docdicionarioid_Ddointernalname = "";
         Combo_docdicionarioid_Titlecontrolalign = "";
         Combo_docdicionarioid_Dropdownoptionstype = "";
         Combo_docdicionarioid_Titlecontrolidtoreplace = "";
         Combo_docdicionarioid_Datalisttype = "";
         Combo_docdicionarioid_Datalistfixedvalues = "";
         Combo_docdicionarioid_Htmltemplate = "";
         Combo_docdicionarioid_Multiplevaluestype = "";
         Combo_docdicionarioid_Loadingdata = "";
         Combo_docdicionarioid_Noresultsfound = "";
         Combo_docdicionarioid_Emptyitemtext = "";
         Combo_docdicionarioid_Onlyselectedvalues = "";
         Combo_docdicionarioid_Selectalltext = "";
         Combo_docdicionarioid_Multiplevaluesseparator = "";
         Combo_docdicionarioid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode60 = "";
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
         T001H6_A4PaisId = new int[1] ;
         T001H6_A98DocDicionarioId = new int[1] ;
         T001H4_A4PaisId = new int[1] ;
         T001H5_A98DocDicionarioId = new int[1] ;
         T001H7_A4PaisId = new int[1] ;
         T001H8_A98DocDicionarioId = new int[1] ;
         T001H9_A4PaisId = new int[1] ;
         T001H9_A98DocDicionarioId = new int[1] ;
         T001H3_A4PaisId = new int[1] ;
         T001H3_A98DocDicionarioId = new int[1] ;
         T001H10_A4PaisId = new int[1] ;
         T001H10_A98DocDicionarioId = new int[1] ;
         T001H11_A4PaisId = new int[1] ;
         T001H11_A98DocDicionarioId = new int[1] ;
         T001H2_A4PaisId = new int[1] ;
         T001H2_A98DocDicionarioId = new int[1] ;
         T001H14_A4PaisId = new int[1] ;
         T001H14_A98DocDicionarioId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001H15_A4PaisId = new int[1] ;
         T001H16_A98DocDicionarioId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.dicionariopais__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariopais__default(),
            new Object[][] {
                new Object[] {
               T001H2_A4PaisId, T001H2_A98DocDicionarioId
               }
               , new Object[] {
               T001H3_A4PaisId, T001H3_A98DocDicionarioId
               }
               , new Object[] {
               T001H4_A4PaisId
               }
               , new Object[] {
               T001H5_A98DocDicionarioId
               }
               , new Object[] {
               T001H6_A4PaisId, T001H6_A98DocDicionarioId
               }
               , new Object[] {
               T001H7_A4PaisId
               }
               , new Object[] {
               T001H8_A98DocDicionarioId
               }
               , new Object[] {
               T001H9_A4PaisId, T001H9_A98DocDicionarioId
               }
               , new Object[] {
               T001H10_A4PaisId, T001H10_A98DocDicionarioId
               }
               , new Object[] {
               T001H11_A4PaisId, T001H11_A98DocDicionarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001H14_A4PaisId, T001H14_A98DocDicionarioId
               }
               , new Object[] {
               T001H15_A4PaisId
               }
               , new Object[] {
               T001H16_A98DocDicionarioId
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
      private short RcdFound60 ;
      private short GX_JID ;
      private short nIsDirty_60 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7PaisId ;
      private int wcpOAV8DocDicionarioId ;
      private int Z4PaisId ;
      private int Z98DocDicionarioId ;
      private int A4PaisId ;
      private int A98DocDicionarioId ;
      private int AV7PaisId ;
      private int AV8DocDicionarioId ;
      private int trnEnded ;
      private int edtPaisId_Visible ;
      private int edtPaisId_Enabled ;
      private int edtDocDicionarioId_Visible ;
      private int edtDocDicionarioId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboPaisId ;
      private int edtavCombopaisid_Enabled ;
      private int edtavCombopaisid_Visible ;
      private int AV23ComboDocDicionarioId ;
      private int edtavCombodocdicionarioid_Enabled ;
      private int edtavCombodocdicionarioid_Visible ;
      private int Combo_paisid_Datalistupdateminimumcharacters ;
      private int Combo_paisid_Gxcontroltype ;
      private int Combo_docdicionarioid_Datalistupdateminimumcharacters ;
      private int Combo_docdicionarioid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_docdicionarioid_Selectedvalue_get ;
      private string Combo_paisid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaisId_Internalname ;
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
      private string divTablesplittedpaisid_Internalname ;
      private string lblTextblockpaisid_Internalname ;
      private string lblTextblockpaisid_Jsonclick ;
      private string Combo_paisid_Caption ;
      private string Combo_paisid_Cls ;
      private string Combo_paisid_Datalistproc ;
      private string Combo_paisid_Datalistprocparametersprefix ;
      private string Combo_paisid_Internalname ;
      private string TempTags ;
      private string edtPaisId_Jsonclick ;
      private string divTablesplitteddocdicionarioid_Internalname ;
      private string lblTextblockdocdicionarioid_Internalname ;
      private string lblTextblockdocdicionarioid_Jsonclick ;
      private string Combo_docdicionarioid_Caption ;
      private string Combo_docdicionarioid_Cls ;
      private string Combo_docdicionarioid_Datalistproc ;
      private string Combo_docdicionarioid_Datalistprocparametersprefix ;
      private string Combo_docdicionarioid_Internalname ;
      private string edtDocDicionarioId_Internalname ;
      private string edtDocDicionarioId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_paisid_Internalname ;
      private string edtavCombopaisid_Internalname ;
      private string edtavCombopaisid_Jsonclick ;
      private string divSectionattribute_docdicionarioid_Internalname ;
      private string edtavCombodocdicionarioid_Internalname ;
      private string edtavCombodocdicionarioid_Jsonclick ;
      private string Combo_paisid_Objectcall ;
      private string Combo_paisid_Class ;
      private string Combo_paisid_Icontype ;
      private string Combo_paisid_Icon ;
      private string Combo_paisid_Tooltip ;
      private string Combo_paisid_Selectedvalue_set ;
      private string Combo_paisid_Selectedtext_set ;
      private string Combo_paisid_Selectedtext_get ;
      private string Combo_paisid_Gamoauthtoken ;
      private string Combo_paisid_Ddointernalname ;
      private string Combo_paisid_Titlecontrolalign ;
      private string Combo_paisid_Dropdownoptionstype ;
      private string Combo_paisid_Titlecontrolidtoreplace ;
      private string Combo_paisid_Datalisttype ;
      private string Combo_paisid_Datalistfixedvalues ;
      private string Combo_paisid_Htmltemplate ;
      private string Combo_paisid_Multiplevaluestype ;
      private string Combo_paisid_Loadingdata ;
      private string Combo_paisid_Noresultsfound ;
      private string Combo_paisid_Emptyitemtext ;
      private string Combo_paisid_Onlyselectedvalues ;
      private string Combo_paisid_Selectalltext ;
      private string Combo_paisid_Multiplevaluesseparator ;
      private string Combo_paisid_Addnewoptiontext ;
      private string Combo_docdicionarioid_Objectcall ;
      private string Combo_docdicionarioid_Class ;
      private string Combo_docdicionarioid_Icontype ;
      private string Combo_docdicionarioid_Icon ;
      private string Combo_docdicionarioid_Tooltip ;
      private string Combo_docdicionarioid_Selectedvalue_set ;
      private string Combo_docdicionarioid_Selectedtext_set ;
      private string Combo_docdicionarioid_Selectedtext_get ;
      private string Combo_docdicionarioid_Gamoauthtoken ;
      private string Combo_docdicionarioid_Ddointernalname ;
      private string Combo_docdicionarioid_Titlecontrolalign ;
      private string Combo_docdicionarioid_Dropdownoptionstype ;
      private string Combo_docdicionarioid_Titlecontrolidtoreplace ;
      private string Combo_docdicionarioid_Datalisttype ;
      private string Combo_docdicionarioid_Datalistfixedvalues ;
      private string Combo_docdicionarioid_Htmltemplate ;
      private string Combo_docdicionarioid_Multiplevaluestype ;
      private string Combo_docdicionarioid_Loadingdata ;
      private string Combo_docdicionarioid_Noresultsfound ;
      private string Combo_docdicionarioid_Emptyitemtext ;
      private string Combo_docdicionarioid_Onlyselectedvalues ;
      private string Combo_docdicionarioid_Selectalltext ;
      private string Combo_docdicionarioid_Multiplevaluesseparator ;
      private string Combo_docdicionarioid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode60 ;
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
      private bool Combo_paisid_Emptyitem ;
      private bool Combo_docdicionarioid_Emptyitem ;
      private bool Combo_paisid_Enabled ;
      private bool Combo_paisid_Visible ;
      private bool Combo_paisid_Allowmultipleselection ;
      private bool Combo_paisid_Isgriditem ;
      private bool Combo_paisid_Hasdescription ;
      private bool Combo_paisid_Includeonlyselectedoption ;
      private bool Combo_paisid_Includeselectalloption ;
      private bool Combo_paisid_Includeaddnewoption ;
      private bool Combo_docdicionarioid_Enabled ;
      private bool Combo_docdicionarioid_Visible ;
      private bool Combo_docdicionarioid_Allowmultipleselection ;
      private bool Combo_docdicionarioid_Isgriditem ;
      private bool Combo_docdicionarioid_Hasdescription ;
      private bool Combo_docdicionarioid_Includeonlyselectedoption ;
      private bool Combo_docdicionarioid_Includeselectalloption ;
      private bool Combo_docdicionarioid_Includeaddnewoption ;
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
      private GXUserControl ucCombo_paisid ;
      private GXUserControl ucCombo_docdicionarioid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001H6_A4PaisId ;
      private int[] T001H6_A98DocDicionarioId ;
      private int[] T001H4_A4PaisId ;
      private int[] T001H5_A98DocDicionarioId ;
      private int[] T001H7_A4PaisId ;
      private int[] T001H8_A98DocDicionarioId ;
      private int[] T001H9_A4PaisId ;
      private int[] T001H9_A98DocDicionarioId ;
      private int[] T001H3_A4PaisId ;
      private int[] T001H3_A98DocDicionarioId ;
      private int[] T001H10_A4PaisId ;
      private int[] T001H10_A98DocDicionarioId ;
      private int[] T001H11_A4PaisId ;
      private int[] T001H11_A98DocDicionarioId ;
      private int[] T001H2_A4PaisId ;
      private int[] T001H2_A98DocDicionarioId ;
      private int[] T001H14_A4PaisId ;
      private int[] T001H14_A98DocDicionarioId ;
      private int[] T001H15_A4PaisId ;
      private int[] T001H16_A98DocDicionarioId ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14PaisId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22DocDicionarioId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV21GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV20GAMSession ;
   }

   public class dicionariopais__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class dicionariopais__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001H6;
        prmT001H6 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H4;
        prmT001H4 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0)
        };
        Object[] prmT001H5;
        prmT001H5 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H7;
        prmT001H7 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0)
        };
        Object[] prmT001H8;
        prmT001H8 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H9;
        prmT001H9 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H3;
        prmT001H3 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H10;
        prmT001H10 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H11;
        prmT001H11 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H2;
        prmT001H2 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H12;
        prmT001H12 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H13;
        prmT001H13 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT001H14;
        prmT001H14 = new Object[] {
        };
        Object[] prmT001H15;
        prmT001H15 = new Object[] {
        new ParDef("@PaisId",GXType.Int32,8,0)
        };
        Object[] prmT001H16;
        prmT001H16 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001H2", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WITH (UPDLOCK) WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H3", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H4", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H5", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H6", "SELECT TM1.[PaisId], TM1.[DocDicionarioId] FROM [DicionarioPais] TM1 WHERE TM1.[PaisId] = @PaisId and TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[PaisId], TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H7", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H8", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H9", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H10", "SELECT TOP 1 [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE ( [PaisId] > @PaisId or [PaisId] = @PaisId and [DocDicionarioId] > @DocDicionarioId) ORDER BY [PaisId], [DocDicionarioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001H11", "SELECT TOP 1 [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE ( [PaisId] < @PaisId or [PaisId] = @PaisId and [DocDicionarioId] < @DocDicionarioId) ORDER BY [PaisId] DESC, [DocDicionarioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001H12", "INSERT INTO [DicionarioPais]([PaisId], [DocDicionarioId]) VALUES(@PaisId, @DocDicionarioId)", GxErrorMask.GX_NOMASK,prmT001H12)
           ,new CursorDef("T001H13", "DELETE FROM [DicionarioPais]  WHERE [PaisId] = @PaisId AND [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmT001H13)
           ,new CursorDef("T001H14", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] ORDER BY [PaisId], [DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H15", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H16", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H16,1, GxCacheFrequency.OFF ,true,false )
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
