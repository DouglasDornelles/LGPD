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
   public class revisaolog : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A75DocumentoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "revisaolog.aspx")), "revisaolog.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "revisaolog.aspx")))) ;
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
                  AV7RevisaoLogId = (int)(NumberUtil.Val( GetPar( "RevisaoLogId"), "."));
                  AssignAttri("", false, "AV7RevisaoLogId", StringUtil.LTrimStr( (decimal)(AV7RevisaoLogId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vREVISAOLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RevisaoLogId), "ZZZZZZZ9"), context));
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( GetPar( "Insert_DocumentoId"), "."));
                  AssignAttri("", false, "AV13Insert_DocumentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DocumentoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13Insert_DocumentoId), "ZZZZZZZ9"), context));
                  AV15IsInserido = StringUtil.StrToBool( GetPar( "IsInserido"));
                  AssignAttri("", false, "AV15IsInserido", AV15IsInserido);
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
            Form.Meta.addItem("description", "Revisao Log", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRevisaoLogObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public revisaolog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaolog( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_RevisaoLogId ,
                           int aP2_Insert_DocumentoId ,
                           out bool aP3_IsInserido )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RevisaoLogId = aP1_RevisaoLogId;
         this.AV13Insert_DocumentoId = aP2_Insert_DocumentoId;
         this.AV15IsInserido = false ;
         executePrivate();
         aP3_IsInserido=this.AV15IsInserido;
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
            return "revisaolog_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRevisaoLogObservacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRevisaoLogObservacao_Internalname, "OBSERVAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRevisaoLogObservacao_Internalname, A122RevisaoLogObservacao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", 0, 1, edtRevisaoLogObservacao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RevisaoLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoLog.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnDefault hidden-xs hidden-sm hidden-md hidden-lg";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoLog.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoLog.htm");
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
         GxWebStd.gx_single_line_edit( context, edtRevisaoLogId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A120RevisaoLogId), 8, 0, ",", "")), StringUtil.LTrim( ((edtRevisaoLogId_Enabled!=0) ? context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRevisaoLogId_Jsonclick, 0, "Attribute", "", "", "", "", edtRevisaoLogId_Visible, edtRevisaoLogId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_RevisaoLog.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRevisaoLogUsuarioAlteracao_Internalname, A121RevisaoLogUsuarioAlteracao, StringUtil.RTrim( context.localUtil.Format( A121RevisaoLogUsuarioAlteracao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRevisaoLogUsuarioAlteracao_Jsonclick, 0, "Attribute", "", "", "", "", edtRevisaoLogUsuarioAlteracao_Visible, edtRevisaoLogUsuarioAlteracao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RevisaoLog.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtRevisaoLogDataAlteracao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRevisaoLogDataAlteracao_Internalname, context.localUtil.TToC( A123RevisaoLogDataAlteracao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A123RevisaoLogDataAlteracao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRevisaoLogDataAlteracao_Jsonclick, 0, "Attribute", "", "", "", "", edtRevisaoLogDataAlteracao_Visible, edtRevisaoLogDataAlteracao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RevisaoLog.htm");
         GxWebStd.gx_bitmap( context, edtRevisaoLogDataAlteracao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtRevisaoLogDataAlteracao_Visible==0)||(edtRevisaoLogDataAlteracao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RevisaoLog.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, edtDocumentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_RevisaoLog.htm");
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
         E111B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z120RevisaoLogId = (int)(context.localUtil.CToN( cgiGet( "Z120RevisaoLogId"), ",", "."));
               Z121RevisaoLogUsuarioAlteracao = cgiGet( "Z121RevisaoLogUsuarioAlteracao");
               Z123RevisaoLogDataAlteracao = context.localUtil.CToT( cgiGet( "Z123RevisaoLogDataAlteracao"), 0);
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( "Z75DocumentoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7RevisaoLogId = (int)(context.localUtil.CToN( cgiGet( "vREVISAOLOGID"), ",", "."));
               AV13Insert_DocumentoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_DOCUMENTOID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV17Pgmname = cgiGet( "vPGMNAME");
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
               A122RevisaoLogObservacao = cgiGet( edtRevisaoLogObservacao_Internalname);
               AssignAttri("", false, "A122RevisaoLogObservacao", A122RevisaoLogObservacao);
               A120RevisaoLogId = (int)(context.localUtil.CToN( cgiGet( edtRevisaoLogId_Internalname), ",", "."));
               AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
               A121RevisaoLogUsuarioAlteracao = cgiGet( edtRevisaoLogUsuarioAlteracao_Internalname);
               AssignAttri("", false, "A121RevisaoLogUsuarioAlteracao", A121RevisaoLogUsuarioAlteracao);
               if ( context.localUtil.VCDateTime( cgiGet( edtRevisaoLogDataAlteracao_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Revisao Log Data Alteracao"}), 1, "REVISAOLOGDATAALTERACAO");
                  AnyError = 1;
                  GX_FocusControl = edtRevisaoLogDataAlteracao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A123RevisaoLogDataAlteracao = context.localUtil.CToT( cgiGet( edtRevisaoLogDataAlteracao_Internalname));
                  AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"RevisaoLog");
               A120RevisaoLogId = (int)(context.localUtil.CToN( cgiGet( edtRevisaoLogId_Internalname), ",", "."));
               AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
               forbiddenHiddens.Add("RevisaoLogId", context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A120RevisaoLogId != Z120RevisaoLogId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("revisaolog:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A120RevisaoLogId = (int)(NumberUtil.Val( GetPar( "RevisaoLogId"), "."));
                  AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
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
                     sMode55 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode55;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound55 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "REVISAOLOGID");
                        AnyError = 1;
                        GX_FocusControl = edtRevisaoLogId_Internalname;
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
                           E111B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121B2 ();
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
            E121B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1B55( ) ;
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
            DisableAttributes1B55( ) ;
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B55( ) ;
            }
            else
            {
               CheckExtendedTable1B55( ) ;
               CloseExtendedTableCursors1B55( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1B0( )
      {
      }

      protected void E111B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_DocumentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DocumentoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13Insert_DocumentoId), "ZZZZZZZ9"), context));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
         edtRevisaoLogId_Visible = 0;
         AssignProp("", false, edtRevisaoLogId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogId_Visible), 5, 0), true);
         edtRevisaoLogUsuarioAlteracao_Visible = 0;
         AssignProp("", false, edtRevisaoLogUsuarioAlteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogUsuarioAlteracao_Visible), 5, 0), true);
         edtRevisaoLogDataAlteracao_Visible = 0;
         AssignProp("", false, edtRevisaoLogDataAlteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRevisaoLogDataAlteracao_Visible), 5, 0), true);
         edtDocumentoId_Visible = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), true);
         AV15IsInserido = false;
         AssignAttri("", false, "AV15IsInserido", AV15IsInserido);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E121B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV15IsInserido = true;
         AssignAttri("", false, "AV15IsInserido", AV15IsInserido);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("revisaologww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV15IsInserido});
         context.setWebReturnParmsMetadata(new Object[] {"AV15IsInserido"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM1B55( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z121RevisaoLogUsuarioAlteracao = T001B3_A121RevisaoLogUsuarioAlteracao[0];
               Z123RevisaoLogDataAlteracao = T001B3_A123RevisaoLogDataAlteracao[0];
               Z75DocumentoId = T001B3_A75DocumentoId[0];
            }
            else
            {
               Z121RevisaoLogUsuarioAlteracao = A121RevisaoLogUsuarioAlteracao;
               Z123RevisaoLogDataAlteracao = A123RevisaoLogDataAlteracao;
               Z75DocumentoId = A75DocumentoId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z120RevisaoLogId = A120RevisaoLogId;
            Z122RevisaoLogObservacao = A122RevisaoLogObservacao;
            Z121RevisaoLogUsuarioAlteracao = A121RevisaoLogUsuarioAlteracao;
            Z123RevisaoLogDataAlteracao = A123RevisaoLogDataAlteracao;
            Z75DocumentoId = A75DocumentoId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtRevisaoLogId_Enabled = 0;
         AssignProp("", false, edtRevisaoLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRevisaoLogId_Enabled), 5, 0), true);
         AV17Pgmname = "RevisaoLog";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtRevisaoLogId_Enabled = 0;
         AssignProp("", false, edtRevisaoLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRevisaoLogId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RevisaoLogId) )
         {
            A120RevisaoLogId = AV7RevisaoLogId;
            AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            edtDocumentoId_Enabled = 0;
            AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocumentoId_Enabled = 1;
            AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            A75DocumentoId = AV13Insert_DocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            edtDocumentoId_Enabled = 0;
            AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A121RevisaoLogUsuarioAlteracao)) && ( Gx_BScreen == 0 ) )
         {
            A121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            AssignAttri("", false, "A121RevisaoLogUsuarioAlteracao", A121RevisaoLogUsuarioAlteracao);
         }
         if ( IsIns( )  && (DateTime.MinValue==A123RevisaoLogDataAlteracao) && ( Gx_BScreen == 0 ) )
         {
            A123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1B55( )
      {
         /* Using cursor T001B5 */
         pr_default.execute(3, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound55 = 1;
            A122RevisaoLogObservacao = T001B5_A122RevisaoLogObservacao[0];
            AssignAttri("", false, "A122RevisaoLogObservacao", A122RevisaoLogObservacao);
            A121RevisaoLogUsuarioAlteracao = T001B5_A121RevisaoLogUsuarioAlteracao[0];
            AssignAttri("", false, "A121RevisaoLogUsuarioAlteracao", A121RevisaoLogUsuarioAlteracao);
            A123RevisaoLogDataAlteracao = T001B5_A123RevisaoLogDataAlteracao[0];
            AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            A75DocumentoId = T001B5_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            ZM1B55( -13) ;
         }
         pr_default.close(3);
         OnLoadActions1B55( ) ;
      }

      protected void OnLoadActions1B55( )
      {
         A122RevisaoLogObservacao = StringUtil.Upper( A122RevisaoLogObservacao);
         AssignAttri("", false, "A122RevisaoLogObservacao", A122RevisaoLogObservacao);
      }

      protected void CheckExtendedTable1B55( )
      {
         nIsDirty_55 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_55 = 1;
         A122RevisaoLogObservacao = StringUtil.Upper( A122RevisaoLogObservacao);
         AssignAttri("", false, "A122RevisaoLogObservacao", A122RevisaoLogObservacao);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A122RevisaoLogObservacao)) )
         {
            GX_msglist.addItem("Observação é obrigatória.", 1, "REVISAOLOGOBSERVACAO");
            AnyError = 1;
            GX_FocusControl = edtRevisaoLogObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A123RevisaoLogDataAlteracao) || ( A123RevisaoLogDataAlteracao >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Revisao Log Data Alteracao fora do intervalo", "OutOfRange", 1, "REVISAOLOGDATAALTERACAO");
            AnyError = 1;
            GX_FocusControl = edtRevisaoLogDataAlteracao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001B4 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1B55( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( int A75DocumentoId )
      {
         /* Using cursor T001B6 */
         pr_default.execute(4, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1B55( )
      {
         /* Using cursor T001B7 */
         pr_default.execute(5, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound55 = 1;
         }
         else
         {
            RcdFound55 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001B3 */
         pr_default.execute(1, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B55( 13) ;
            RcdFound55 = 1;
            A120RevisaoLogId = T001B3_A120RevisaoLogId[0];
            AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
            A122RevisaoLogObservacao = T001B3_A122RevisaoLogObservacao[0];
            AssignAttri("", false, "A122RevisaoLogObservacao", A122RevisaoLogObservacao);
            A121RevisaoLogUsuarioAlteracao = T001B3_A121RevisaoLogUsuarioAlteracao[0];
            AssignAttri("", false, "A121RevisaoLogUsuarioAlteracao", A121RevisaoLogUsuarioAlteracao);
            A123RevisaoLogDataAlteracao = T001B3_A123RevisaoLogDataAlteracao[0];
            AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            A75DocumentoId = T001B3_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            Z120RevisaoLogId = A120RevisaoLogId;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1B55( ) ;
            if ( AnyError == 1 )
            {
               RcdFound55 = 0;
               InitializeNonKey1B55( ) ;
            }
            Gx_mode = sMode55;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound55 = 0;
            InitializeNonKey1B55( ) ;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode55;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B55( ) ;
         if ( RcdFound55 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound55 = 0;
         /* Using cursor T001B8 */
         pr_default.execute(6, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001B8_A120RevisaoLogId[0] < A120RevisaoLogId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001B8_A120RevisaoLogId[0] > A120RevisaoLogId ) ) )
            {
               A120RevisaoLogId = T001B8_A120RevisaoLogId[0];
               AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
               RcdFound55 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound55 = 0;
         /* Using cursor T001B9 */
         pr_default.execute(7, new Object[] {A120RevisaoLogId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001B9_A120RevisaoLogId[0] > A120RevisaoLogId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001B9_A120RevisaoLogId[0] < A120RevisaoLogId ) ) )
            {
               A120RevisaoLogId = T001B9_A120RevisaoLogId[0];
               AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
               RcdFound55 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1B55( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRevisaoLogObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1B55( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound55 == 1 )
            {
               if ( A120RevisaoLogId != Z120RevisaoLogId )
               {
                  A120RevisaoLogId = Z120RevisaoLogId;
                  AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REVISAOLOGID");
                  AnyError = 1;
                  GX_FocusControl = edtRevisaoLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRevisaoLogObservacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1B55( ) ;
                  GX_FocusControl = edtRevisaoLogObservacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A120RevisaoLogId != Z120RevisaoLogId )
               {
                  /* Insert record */
                  GX_FocusControl = edtRevisaoLogObservacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1B55( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REVISAOLOGID");
                     AnyError = 1;
                     GX_FocusControl = edtRevisaoLogId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRevisaoLogObservacao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1B55( ) ;
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
         if ( A120RevisaoLogId != Z120RevisaoLogId )
         {
            A120RevisaoLogId = Z120RevisaoLogId;
            AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REVISAOLOGID");
            AnyError = 1;
            GX_FocusControl = edtRevisaoLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRevisaoLogObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1B55( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001B2 */
            pr_default.execute(0, new Object[] {A120RevisaoLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RevisaoLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z121RevisaoLogUsuarioAlteracao, T001B2_A121RevisaoLogUsuarioAlteracao[0]) != 0 ) || ( Z123RevisaoLogDataAlteracao != T001B2_A123RevisaoLogDataAlteracao[0] ) || ( Z75DocumentoId != T001B2_A75DocumentoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z121RevisaoLogUsuarioAlteracao, T001B2_A121RevisaoLogUsuarioAlteracao[0]) != 0 )
               {
                  GXUtil.WriteLog("revisaolog:[seudo value changed for attri]"+"RevisaoLogUsuarioAlteracao");
                  GXUtil.WriteLogRaw("Old: ",Z121RevisaoLogUsuarioAlteracao);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A121RevisaoLogUsuarioAlteracao[0]);
               }
               if ( Z123RevisaoLogDataAlteracao != T001B2_A123RevisaoLogDataAlteracao[0] )
               {
                  GXUtil.WriteLog("revisaolog:[seudo value changed for attri]"+"RevisaoLogDataAlteracao");
                  GXUtil.WriteLogRaw("Old: ",Z123RevisaoLogDataAlteracao);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A123RevisaoLogDataAlteracao[0]);
               }
               if ( Z75DocumentoId != T001B2_A75DocumentoId[0] )
               {
                  GXUtil.WriteLog("revisaolog:[seudo value changed for attri]"+"DocumentoId");
                  GXUtil.WriteLogRaw("Old: ",Z75DocumentoId);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A75DocumentoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RevisaoLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B55( )
      {
         if ( ! IsAuthorized("revisaolog_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B55( 0) ;
            CheckOptimisticConcurrency1B55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B10 */
                     pr_default.execute(8, new Object[] {A122RevisaoLogObservacao, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A75DocumentoId});
                     A120RevisaoLogId = T001B10_A120RevisaoLogId[0];
                     AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("RevisaoLog");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1B0( ) ;
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
               Load1B55( ) ;
            }
            EndLevel1B55( ) ;
         }
         CloseExtendedTableCursors1B55( ) ;
      }

      protected void Update1B55( )
      {
         if ( ! IsAuthorized("revisaolog_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B11 */
                     pr_default.execute(9, new Object[] {A122RevisaoLogObservacao, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A75DocumentoId, A120RevisaoLogId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("RevisaoLog");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RevisaoLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B55( ) ;
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
            EndLevel1B55( ) ;
         }
         CloseExtendedTableCursors1B55( ) ;
      }

      protected void DeferredUpdate1B55( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("revisaolog_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1B55( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B55( ) ;
            AfterConfirm1B55( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B55( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001B12 */
                  pr_default.execute(10, new Object[] {A120RevisaoLogId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("RevisaoLog");
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
         sMode55 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1B55( ) ;
         Gx_mode = sMode55;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1B55( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1B55( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B55( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("revisaolog",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("revisaolog",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1B55( )
      {
         /* Scan By routine */
         /* Using cursor T001B13 */
         pr_default.execute(11);
         RcdFound55 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound55 = 1;
            A120RevisaoLogId = T001B13_A120RevisaoLogId[0];
            AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1B55( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound55 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound55 = 1;
            A120RevisaoLogId = T001B13_A120RevisaoLogId[0];
            AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
         }
      }

      protected void ScanEnd1B55( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1B55( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B55( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B55( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B55( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B55( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B55( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B55( )
      {
         edtRevisaoLogObservacao_Enabled = 0;
         AssignProp("", false, edtRevisaoLogObservacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRevisaoLogObservacao_Enabled), 5, 0), true);
         edtRevisaoLogId_Enabled = 0;
         AssignProp("", false, edtRevisaoLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRevisaoLogId_Enabled), 5, 0), true);
         edtRevisaoLogUsuarioAlteracao_Enabled = 0;
         AssignProp("", false, edtRevisaoLogUsuarioAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRevisaoLogUsuarioAlteracao_Enabled), 5, 0), true);
         edtRevisaoLogDataAlteracao_Enabled = 0;
         AssignProp("", false, edtRevisaoLogDataAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRevisaoLogDataAlteracao_Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1B55( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1B0( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 21481420), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 21481420), false, true);
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
         GXEncryptionTmp = "revisaolog.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RevisaoLogId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13Insert_DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV15IsInserido));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("revisaolog.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"RevisaoLog");
         forbiddenHiddens.Add("RevisaoLogId", context.localUtil.Format( (decimal)(A120RevisaoLogId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("revisaolog:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z120RevisaoLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120RevisaoLogId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z121RevisaoLogUsuarioAlteracao", Z121RevisaoLogUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "Z123RevisaoLogDataAlteracao", context.localUtil.TToC( Z123RevisaoLogDataAlteracao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75DocumentoId), 8, 0, ",", "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vISINSERIDO", AV15IsInserido);
         GxWebStd.gx_hidden_field( context, "vREVISAOLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RevisaoLogId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREVISAOLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RevisaoLogId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13Insert_DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
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
         GXEncryptionTmp = "revisaolog.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RevisaoLogId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13Insert_DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV15IsInserido));
         return formatLink("revisaolog.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "RevisaoLog" ;
      }

      public override string GetPgmdesc( )
      {
         return "Revisao Log" ;
      }

      protected void InitializeNonKey1B55( )
      {
         A75DocumentoId = 0;
         AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         A122RevisaoLogObservacao = "";
         AssignAttri("", false, "A122RevisaoLogObservacao", A122RevisaoLogObservacao);
         A121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AssignAttri("", false, "A121RevisaoLogUsuarioAlteracao", A121RevisaoLogUsuarioAlteracao);
         A123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
         Z121RevisaoLogUsuarioAlteracao = "";
         Z123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         Z75DocumentoId = 0;
      }

      protected void InitAll1B55( )
      {
         A120RevisaoLogId = 0;
         AssignAttri("", false, "A120RevisaoLogId", StringUtil.LTrimStr( (decimal)(A120RevisaoLogId), 8, 0));
         InitializeNonKey1B55( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A121RevisaoLogUsuarioAlteracao = i121RevisaoLogUsuarioAlteracao;
         AssignAttri("", false, "A121RevisaoLogUsuarioAlteracao", A121RevisaoLogUsuarioAlteracao);
         A123RevisaoLogDataAlteracao = i123RevisaoLogDataAlteracao;
         AssignAttri("", false, "A123RevisaoLogDataAlteracao", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417265043", true, true);
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
         context.AddJavascriptSource("revisaolog.js", "?202312417265044", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtRevisaoLogObservacao_Internalname = "REVISAOLOGOBSERVACAO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtRevisaoLogId_Internalname = "REVISAOLOGID";
         edtRevisaoLogUsuarioAlteracao_Internalname = "REVISAOLOGUSUARIOALTERACAO";
         edtRevisaoLogDataAlteracao_Internalname = "REVISAOLOGDATAALTERACAO";
         edtDocumentoId_Internalname = "DOCUMENTOID";
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
         Form.Caption = "Revisao Log";
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 1;
         edtDocumentoId_Visible = 1;
         edtRevisaoLogDataAlteracao_Jsonclick = "";
         edtRevisaoLogDataAlteracao_Enabled = 1;
         edtRevisaoLogDataAlteracao_Visible = 1;
         edtRevisaoLogUsuarioAlteracao_Jsonclick = "";
         edtRevisaoLogUsuarioAlteracao_Enabled = 1;
         edtRevisaoLogUsuarioAlteracao_Visible = 1;
         edtRevisaoLogId_Jsonclick = "";
         edtRevisaoLogId_Enabled = 0;
         edtRevisaoLogId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtRevisaoLogObservacao_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "REVISÃO";
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

      public void Valid_Documentoid( )
      {
         /* Using cursor T001B14 */
         pr_default.execute(12, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7RevisaoLogId',fld:'vREVISAOLOGID',pic:'ZZZZZZZ9',hsh:true},{av:'AV13Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV15IsInserido',fld:'vISINSERIDO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RevisaoLogId',fld:'vREVISAOLOGID',pic:'ZZZZZZZ9',hsh:true},{av:'AV13Insert_DocumentoId',fld:'vINSERT_DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121B2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV15IsInserido',fld:'vISINSERIDO',pic:''}]}");
         setEventMetadata("VALID_REVISAOLOGOBSERVACAO","{handler:'Valid_Revisaologobservacao',iparms:[]");
         setEventMetadata("VALID_REVISAOLOGOBSERVACAO",",oparms:[]}");
         setEventMetadata("VALID_REVISAOLOGID","{handler:'Valid_Revisaologid',iparms:[]");
         setEventMetadata("VALID_REVISAOLOGID",",oparms:[]}");
         setEventMetadata("VALID_REVISAOLOGDATAALTERACAO","{handler:'Valid_Revisaologdataalteracao',iparms:[]");
         setEventMetadata("VALID_REVISAOLOGDATAALTERACAO",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z121RevisaoLogUsuarioAlteracao = "";
         Z123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
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
         A122RevisaoLogObservacao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         AV17Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode55 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z122RevisaoLogObservacao = "";
         T001B5_A120RevisaoLogId = new int[1] ;
         T001B5_A122RevisaoLogObservacao = new string[] {""} ;
         T001B5_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         T001B5_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001B5_A75DocumentoId = new int[1] ;
         T001B4_A75DocumentoId = new int[1] ;
         T001B6_A75DocumentoId = new int[1] ;
         T001B7_A120RevisaoLogId = new int[1] ;
         T001B3_A120RevisaoLogId = new int[1] ;
         T001B3_A122RevisaoLogObservacao = new string[] {""} ;
         T001B3_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         T001B3_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001B3_A75DocumentoId = new int[1] ;
         T001B8_A120RevisaoLogId = new int[1] ;
         T001B9_A120RevisaoLogId = new int[1] ;
         T001B2_A120RevisaoLogId = new int[1] ;
         T001B2_A122RevisaoLogObservacao = new string[] {""} ;
         T001B2_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         T001B2_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001B2_A75DocumentoId = new int[1] ;
         T001B10_A120RevisaoLogId = new int[1] ;
         T001B13_A120RevisaoLogId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i121RevisaoLogUsuarioAlteracao = "";
         i123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         T001B14_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.revisaolog__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaolog__default(),
            new Object[][] {
                new Object[] {
               T001B2_A120RevisaoLogId, T001B2_A122RevisaoLogObservacao, T001B2_A121RevisaoLogUsuarioAlteracao, T001B2_A123RevisaoLogDataAlteracao, T001B2_A75DocumentoId
               }
               , new Object[] {
               T001B3_A120RevisaoLogId, T001B3_A122RevisaoLogObservacao, T001B3_A121RevisaoLogUsuarioAlteracao, T001B3_A123RevisaoLogDataAlteracao, T001B3_A75DocumentoId
               }
               , new Object[] {
               T001B4_A75DocumentoId
               }
               , new Object[] {
               T001B5_A120RevisaoLogId, T001B5_A122RevisaoLogObservacao, T001B5_A121RevisaoLogUsuarioAlteracao, T001B5_A123RevisaoLogDataAlteracao, T001B5_A75DocumentoId
               }
               , new Object[] {
               T001B6_A75DocumentoId
               }
               , new Object[] {
               T001B7_A120RevisaoLogId
               }
               , new Object[] {
               T001B8_A120RevisaoLogId
               }
               , new Object[] {
               T001B9_A120RevisaoLogId
               }
               , new Object[] {
               T001B10_A120RevisaoLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001B13_A120RevisaoLogId
               }
               , new Object[] {
               T001B14_A75DocumentoId
               }
            }
         );
         AV17Pgmname = "RevisaoLog";
         Z123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         A123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         i123RevisaoLogDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         Z121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         i121RevisaoLogUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound55 ;
      private short GX_JID ;
      private short nIsDirty_55 ;
      private short gxajaxcallmode ;
      private int wcpOAV7RevisaoLogId ;
      private int wcpOAV13Insert_DocumentoId ;
      private int Z120RevisaoLogId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private int AV7RevisaoLogId ;
      private int AV13Insert_DocumentoId ;
      private int trnEnded ;
      private int edtRevisaoLogObservacao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A120RevisaoLogId ;
      private int edtRevisaoLogId_Enabled ;
      private int edtRevisaoLogId_Visible ;
      private int edtRevisaoLogUsuarioAlteracao_Visible ;
      private int edtRevisaoLogUsuarioAlteracao_Enabled ;
      private int edtRevisaoLogDataAlteracao_Visible ;
      private int edtRevisaoLogDataAlteracao_Enabled ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoId_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV18GXV1 ;
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
      private string edtRevisaoLogObservacao_Internalname ;
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
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtRevisaoLogId_Internalname ;
      private string edtRevisaoLogId_Jsonclick ;
      private string edtRevisaoLogUsuarioAlteracao_Internalname ;
      private string edtRevisaoLogUsuarioAlteracao_Jsonclick ;
      private string edtRevisaoLogDataAlteracao_Internalname ;
      private string edtRevisaoLogDataAlteracao_Jsonclick ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoId_Jsonclick ;
      private string AV17Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode55 ;
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
      private DateTime Z123RevisaoLogDataAlteracao ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private DateTime i123RevisaoLogDataAlteracao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15IsInserido ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string A122RevisaoLogObservacao ;
      private string Z122RevisaoLogObservacao ;
      private string Z121RevisaoLogUsuarioAlteracao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string i121RevisaoLogUsuarioAlteracao ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001B5_A120RevisaoLogId ;
      private string[] T001B5_A122RevisaoLogObservacao ;
      private string[] T001B5_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] T001B5_A123RevisaoLogDataAlteracao ;
      private int[] T001B5_A75DocumentoId ;
      private int[] T001B4_A75DocumentoId ;
      private int[] T001B6_A75DocumentoId ;
      private int[] T001B7_A120RevisaoLogId ;
      private int[] T001B3_A120RevisaoLogId ;
      private string[] T001B3_A122RevisaoLogObservacao ;
      private string[] T001B3_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] T001B3_A123RevisaoLogDataAlteracao ;
      private int[] T001B3_A75DocumentoId ;
      private int[] T001B8_A120RevisaoLogId ;
      private int[] T001B9_A120RevisaoLogId ;
      private int[] T001B2_A120RevisaoLogId ;
      private string[] T001B2_A122RevisaoLogObservacao ;
      private string[] T001B2_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] T001B2_A123RevisaoLogDataAlteracao ;
      private int[] T001B2_A75DocumentoId ;
      private int[] T001B10_A120RevisaoLogId ;
      private int[] T001B13_A120RevisaoLogId ;
      private int[] T001B14_A75DocumentoId ;
      private bool aP3_IsInserido ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class revisaolog__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class revisaolog__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001B5;
        prmT001B5 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B4;
        prmT001B4 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001B6;
        prmT001B6 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001B7;
        prmT001B7 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B3;
        prmT001B3 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B8;
        prmT001B8 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B9;
        prmT001B9 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B2;
        prmT001B2 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B10;
        prmT001B10 = new Object[] {
        new ParDef("@RevisaoLogObservacao",GXType.NVarChar,10000,0) ,
        new ParDef("@RevisaoLogUsuarioAlteracao",GXType.NVarChar,100,0) ,
        new ParDef("@RevisaoLogDataAlteracao",GXType.DateTime,8,5) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001B11;
        prmT001B11 = new Object[] {
        new ParDef("@RevisaoLogObservacao",GXType.NVarChar,10000,0) ,
        new ParDef("@RevisaoLogUsuarioAlteracao",GXType.NVarChar,100,0) ,
        new ParDef("@RevisaoLogDataAlteracao",GXType.DateTime,8,5) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B12;
        prmT001B12 = new Object[] {
        new ParDef("@RevisaoLogId",GXType.Int32,8,0)
        };
        Object[] prmT001B13;
        prmT001B13 = new Object[] {
        };
        Object[] prmT001B14;
        prmT001B14 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001B2", "SELECT [RevisaoLogId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [DocumentoId] FROM [RevisaoLog] WITH (UPDLOCK) WHERE [RevisaoLogId] = @RevisaoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B3", "SELECT [RevisaoLogId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [DocumentoId] FROM [RevisaoLog] WHERE [RevisaoLogId] = @RevisaoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B4", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B5", "SELECT TM1.[RevisaoLogId], TM1.[RevisaoLogObservacao], TM1.[RevisaoLogUsuarioAlteracao], TM1.[RevisaoLogDataAlteracao], TM1.[DocumentoId] FROM [RevisaoLog] TM1 WHERE TM1.[RevisaoLogId] = @RevisaoLogId ORDER BY TM1.[RevisaoLogId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B6", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B7", "SELECT [RevisaoLogId] FROM [RevisaoLog] WHERE [RevisaoLogId] = @RevisaoLogId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B8", "SELECT TOP 1 [RevisaoLogId] FROM [RevisaoLog] WHERE ( [RevisaoLogId] > @RevisaoLogId) ORDER BY [RevisaoLogId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B9", "SELECT TOP 1 [RevisaoLogId] FROM [RevisaoLog] WHERE ( [RevisaoLogId] < @RevisaoLogId) ORDER BY [RevisaoLogId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B10", "INSERT INTO [RevisaoLog]([RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [DocumentoId]) VALUES(@RevisaoLogObservacao, @RevisaoLogUsuarioAlteracao, @RevisaoLogDataAlteracao, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B11", "UPDATE [RevisaoLog] SET [RevisaoLogObservacao]=@RevisaoLogObservacao, [RevisaoLogUsuarioAlteracao]=@RevisaoLogUsuarioAlteracao, [RevisaoLogDataAlteracao]=@RevisaoLogDataAlteracao, [DocumentoId]=@DocumentoId  WHERE [RevisaoLogId] = @RevisaoLogId", GxErrorMask.GX_NOMASK,prmT001B11)
           ,new CursorDef("T001B12", "DELETE FROM [RevisaoLog]  WHERE [RevisaoLogId] = @RevisaoLogId", GxErrorMask.GX_NOMASK,prmT001B12)
           ,new CursorDef("T001B13", "SELECT [RevisaoLogId] FROM [RevisaoLog] ORDER BY [RevisaoLogId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001B13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B14", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
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
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
