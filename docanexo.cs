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
   public class docanexo : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               nDynComponent = 1;
               sCompPrefix = GetPar( "sCompPrefix");
               sSFPrefix = GetPar( "sSFPrefix");
               Gx_mode = GetPar( "Mode");
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               AV7DocAnexoId = (int)(NumberUtil.Val( GetPar( "DocAnexoId"), "."));
               AssignAttri(sPrefix, false, "AV7DocAnexoId", StringUtil.LTrimStr( (decimal)(AV7DocAnexoId), 8, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV7DocAnexoId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
            {
               A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
               AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_13( A75DocumentoId) ;
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
         }
         GXKey = Crypto.GetSiteKey( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docanexo.aspx")), "docanexo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docanexo.aspx")))) ;
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
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
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
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                  {
                     AV7DocAnexoId = (int)(NumberUtil.Val( GetPar( "DocAnexoId"), "."));
                     AssignAttri(sPrefix, false, "AV7DocAnexoId", StringUtil.LTrimStr( (decimal)(AV7DocAnexoId), 8, 0));
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
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_web_controls( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
               }
               Form.Meta.addItem("description", "Doc Anexo", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public docanexo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS");
         }
      }

      public docanexo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocAnexoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocAnexoId = aP1_DocAnexoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
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
            return "docanexo_Execute" ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
            RenderHtmlCloseForm1952( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "docanexo.aspx");
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         }
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocAnexoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocAnexoId_Internalname, "Documento Anexo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
         GxWebStd.gx_single_line_edit( context, edtDocAnexoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A93DocAnexoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtDocAnexoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A93DocAnexoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A93DocAnexoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocAnexoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocAnexoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocAnexo.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockdocumentoid_Internalname, "Documento", "", "", lblTextblockdocumentoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocAnexo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_documentoid.SetProperty("Caption", Combo_documentoid_Caption);
         ucCombo_documentoid.SetProperty("Cls", Combo_documentoid_Cls);
         ucCombo_documentoid.SetProperty("DataListProc", Combo_documentoid_Datalistproc);
         ucCombo_documentoid.SetProperty("DataListProcParametersPrefix", Combo_documentoid_Datalistprocparametersprefix);
         ucCombo_documentoid.SetProperty("EmptyItem", Combo_documentoid_Emptyitem);
         ucCombo_documentoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_documentoid.SetProperty("DropDownOptionsData", AV15DocumentoId_Data);
         ucCombo_documentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_documentoid_Internalname, sPrefix+"COMBO_DOCUMENTOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentoId_Internalname, "Id do Documento", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, edtDocumentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocAnexo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocAnexoDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocAnexoDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocAnexoDescricao_Internalname, A94DocAnexoDescricao, StringUtil.RTrim( context.localUtil.Format( A94DocAnexoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocAnexoDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocAnexoDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocAnexo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocAnexoArquivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocAnexoArquivo_Internalname, "Arquivo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocAnexoArquivo_Internalname, A95DocAnexoArquivo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtDocAnexoArquivo_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DocAnexo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocAnexoDataInclusao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocAnexoDataInclusao_Internalname, "de Inclusão", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocAnexoDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocAnexoDataInclusao_Internalname, context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"), context.localUtil.Format( A96DocAnexoDataInclusao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocAnexoDataInclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocAnexoDataInclusao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocAnexo.htm");
         GxWebStd.gx_bitmap( context, edtDocAnexoDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocAnexoDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocAnexo.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocAnexo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocAnexo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocAnexo.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_documentoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV20ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV20ComboDocumentoId), 8, 0));
         GxWebStd.gx_single_line_edit( context, edtavCombodocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboDocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombodocumentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboDocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20ComboDocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodocumentoid_Visible, edtavCombodocumentoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocAnexo.htm");
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
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11192 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDOCUMENTOID_DATA"), AV15DocumentoId_Data);
               /* Read saved values. */
               Z93DocAnexoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z93DocAnexoId"), ",", "."));
               Z94DocAnexoDescricao = cgiGet( sPrefix+"Z94DocAnexoDescricao");
               Z95DocAnexoArquivo = cgiGet( sPrefix+"Z95DocAnexoArquivo");
               Z96DocAnexoDataInclusao = context.localUtil.CToD( cgiGet( sPrefix+"Z96DocAnexoDataInclusao"), 0);
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z75DocumentoId"), ",", "."));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7DocAnexoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DocAnexoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N75DocumentoId"), ",", "."));
               AV7DocAnexoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vDOCANEXOID"), ",", "."));
               AV13Insert_DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_DOCUMENTOID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."));
               A76DocumentoNome = cgiGet( sPrefix+"DOCUMENTONOME");
               n76DocumentoNome = false;
               AV24Pgmname = cgiGet( sPrefix+"vPGMNAME");
               Combo_documentoid_Objectcall = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Objectcall");
               Combo_documentoid_Class = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Class");
               Combo_documentoid_Icontype = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Icontype");
               Combo_documentoid_Icon = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Icon");
               Combo_documentoid_Caption = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Caption");
               Combo_documentoid_Tooltip = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Tooltip");
               Combo_documentoid_Cls = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Cls");
               Combo_documentoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Selectedvalue_set");
               Combo_documentoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Selectedvalue_get");
               Combo_documentoid_Selectedtext_set = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Selectedtext_set");
               Combo_documentoid_Selectedtext_get = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Selectedtext_get");
               Combo_documentoid_Gamoauthtoken = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Gamoauthtoken");
               Combo_documentoid_Ddointernalname = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Ddointernalname");
               Combo_documentoid_Titlecontrolalign = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Titlecontrolalign");
               Combo_documentoid_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Dropdownoptionstype");
               Combo_documentoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Enabled"));
               Combo_documentoid_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Visible"));
               Combo_documentoid_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Titlecontrolidtoreplace");
               Combo_documentoid_Datalisttype = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Datalisttype");
               Combo_documentoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Allowmultipleselection"));
               Combo_documentoid_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Datalistfixedvalues");
               Combo_documentoid_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Isgriditem"));
               Combo_documentoid_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Hasdescription"));
               Combo_documentoid_Datalistproc = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Datalistproc");
               Combo_documentoid_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Datalistprocparametersprefix");
               Combo_documentoid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_documentoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Includeonlyselectedoption"));
               Combo_documentoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Includeselectalloption"));
               Combo_documentoid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Emptyitem"));
               Combo_documentoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Includeaddnewoption"));
               Combo_documentoid_Htmltemplate = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Htmltemplate");
               Combo_documentoid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Multiplevaluestype");
               Combo_documentoid_Loadingdata = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Loadingdata");
               Combo_documentoid_Noresultsfound = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Noresultsfound");
               Combo_documentoid_Emptyitemtext = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Emptyitemtext");
               Combo_documentoid_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Onlyselectedvalues");
               Combo_documentoid_Selectalltext = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Selectalltext");
               Combo_documentoid_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Multiplevaluesseparator");
               Combo_documentoid_Addnewoptiontext = cgiGet( sPrefix+"COMBO_DOCUMENTOID_Addnewoptiontext");
               Combo_documentoid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_DOCUMENTOID_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A93DocAnexoId = (int)(context.localUtil.CToN( cgiGet( edtDocAnexoId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCUMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A75DocumentoId = 0;
                  AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               }
               else
               {
                  A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               }
               A94DocAnexoDescricao = cgiGet( edtDocAnexoDescricao_Internalname);
               AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
               A95DocAnexoArquivo = cgiGet( edtDocAnexoArquivo_Internalname);
               AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
               if ( context.localUtil.VCDate( cgiGet( edtDocAnexoDataInclusao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de Inclusão"}), 1, "DOCANEXODATAINCLUSAO");
                  AnyError = 1;
                  GX_FocusControl = edtDocAnexoDataInclusao_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A96DocAnexoDataInclusao = DateTime.MinValue;
                  AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
               }
               else
               {
                  A96DocAnexoDataInclusao = context.localUtil.CToD( cgiGet( edtDocAnexoDataInclusao_Internalname), 2);
                  AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
               }
               AV20ComboDocumentoId = (int)(context.localUtil.CToN( cgiGet( edtavCombodocumentoid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV20ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV20ComboDocumentoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"DocAnexo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A93DocAnexoId != Z93DocAnexoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("docanexo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A93DocAnexoId = (int)(NumberUtil.Val( GetPar( "DocAnexoId"), "."));
                  AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode52 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode52;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound52 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_190( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCANEXOID");
                        AnyError = 1;
                        GX_FocusControl = edtDocAnexoId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
            if ( context.wbHandled == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  sEvt = cgiGet( "_EventName");
                  EvtGridId = cgiGet( "_EventGridId");
                  EvtRowId = cgiGet( "_EventRowId");
               }
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E11192 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E12192 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
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
            E12192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1952( ) ;
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
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1952( ) ;
         }
         AssignProp(sPrefix, false, edtDocAnexoDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoDescricao_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDocAnexoArquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoArquivo_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDocAnexoDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoDataInclusao_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtavCombodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1952( ) ;
            }
            else
            {
               CheckExtendedTable1952( ) ;
               CloseExtendedTableCursors1952( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption190( )
      {
      }

      protected void E11192( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_documentoid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "GAMOAuthToken", Combo_documentoid_Gamoauthtoken);
         edtDocumentoId_Visible = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), true);
         AV20ComboDocumentoId = 0;
         AssignAttri(sPrefix, false, "AV20ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV20ComboDocumentoId), 8, 0));
         edtavCombodocumentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavCombodocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBODOCUMENTOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri(sPrefix, false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV13Insert_DocumentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DocumentoId), 8, 0));
                  if ( ! (0==AV13Insert_DocumentoId) )
                  {
                     AV20ComboDocumentoId = AV13Insert_DocumentoId;
                     AssignAttri(sPrefix, false, "AV20ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV20ComboDocumentoId), 8, 0));
                     Combo_documentoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboDocumentoId), 8, 0));
                     ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedValue_set", Combo_documentoid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new docanexoloaddvcombo(context ).execute(  "DocumentoId",  "GET",  false,  AV7DocAnexoId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri(sPrefix, false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri(sPrefix, false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri(sPrefix, false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_documentoid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedText_set", Combo_documentoid_Selectedtext_set);
                     Combo_documentoid_Enabled = false;
                     ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
                  }
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri(sPrefix, false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
      }

      protected void E12192( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("docanexoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBODOCUMENTOID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new docanexoloaddvcombo(context ).execute(  "DocumentoId",  Gx_mode,  false,  AV7DocAnexoId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_documentoid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedValue_set", Combo_documentoid_Selectedvalue_set);
         Combo_documentoid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedText_set", Combo_documentoid_Selectedtext_set);
         AV20ComboDocumentoId = (int)(NumberUtil.Val( AV17ComboSelectedValue, "."));
         AssignAttri(sPrefix, false, "AV20ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV20ComboDocumentoId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_documentoid_Enabled = false;
            ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
         }
      }

      protected void ZM1952( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z94DocAnexoDescricao = T00193_A94DocAnexoDescricao[0];
               Z95DocAnexoArquivo = T00193_A95DocAnexoArquivo[0];
               Z96DocAnexoDataInclusao = T00193_A96DocAnexoDataInclusao[0];
               Z75DocumentoId = T00193_A75DocumentoId[0];
            }
            else
            {
               Z94DocAnexoDescricao = A94DocAnexoDescricao;
               Z95DocAnexoArquivo = A95DocAnexoArquivo;
               Z96DocAnexoDataInclusao = A96DocAnexoDataInclusao;
               Z75DocumentoId = A75DocumentoId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z93DocAnexoId = A93DocAnexoId;
            Z94DocAnexoDescricao = A94DocAnexoDescricao;
            Z95DocAnexoArquivo = A95DocAnexoArquivo;
            Z96DocAnexoDataInclusao = A96DocAnexoDataInclusao;
            Z75DocumentoId = A75DocumentoId;
            Z76DocumentoNome = A76DocumentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDocAnexoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocAnexoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoId_Enabled), 5, 0), true);
         AV24Pgmname = "DocAnexo";
         AssignAttri(sPrefix, false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtDocAnexoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocAnexoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7DocAnexoId) )
         {
            A93DocAnexoId = AV7DocAnexoId;
            AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            edtDocumentoId_Enabled = 0;
            AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocumentoId_Enabled = 1;
            AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            A75DocumentoId = AV13Insert_DocumentoId;
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         else
         {
            A75DocumentoId = AV20ComboDocumentoId;
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A96DocAnexoDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A96DocAnexoDataInclusao = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00194 */
            pr_default.execute(2, new Object[] {A75DocumentoId});
            A76DocumentoNome = T00194_A76DocumentoNome[0];
            n76DocumentoNome = T00194_n76DocumentoNome[0];
            pr_default.close(2);
         }
      }

      protected void Load1952( )
      {
         /* Using cursor T00195 */
         pr_default.execute(3, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound52 = 1;
            A94DocAnexoDescricao = T00195_A94DocAnexoDescricao[0];
            AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
            A95DocAnexoArquivo = T00195_A95DocAnexoArquivo[0];
            AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
            A96DocAnexoDataInclusao = T00195_A96DocAnexoDataInclusao[0];
            AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
            A76DocumentoNome = T00195_A76DocumentoNome[0];
            n76DocumentoNome = T00195_n76DocumentoNome[0];
            A75DocumentoId = T00195_A75DocumentoId[0];
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            ZM1952( -12) ;
         }
         pr_default.close(3);
         OnLoadActions1952( ) ;
      }

      protected void OnLoadActions1952( )
      {
         A94DocAnexoDescricao = StringUtil.Upper( A94DocAnexoDescricao);
         AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
         A95DocAnexoArquivo = StringUtil.Upper( A95DocAnexoArquivo);
         AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
      }

      protected void CheckExtendedTable1952( )
      {
         nIsDirty_52 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00194 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A76DocumentoNome = T00194_A76DocumentoNome[0];
         n76DocumentoNome = T00194_n76DocumentoNome[0];
         pr_default.close(2);
         nIsDirty_52 = 1;
         A94DocAnexoDescricao = StringUtil.Upper( A94DocAnexoDescricao);
         AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
         nIsDirty_52 = 1;
         A95DocAnexoArquivo = StringUtil.Upper( A95DocAnexoArquivo);
         AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
         if ( ! ( (DateTime.MinValue==A96DocAnexoDataInclusao) || ( DateTimeUtil.ResetTime ( A96DocAnexoDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Data de Inclusão fora do intervalo", "OutOfRange", 1, "DOCANEXODATAINCLUSAO");
            AnyError = 1;
            GX_FocusControl = edtDocAnexoDataInclusao_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1952( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A75DocumentoId )
      {
         /* Using cursor T00196 */
         pr_default.execute(4, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A76DocumentoNome = T00196_A76DocumentoNome[0];
         n76DocumentoNome = T00196_n76DocumentoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A76DocumentoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1952( )
      {
         /* Using cursor T00197 */
         pr_default.execute(5, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00193 */
         pr_default.execute(1, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1952( 12) ;
            RcdFound52 = 1;
            A93DocAnexoId = T00193_A93DocAnexoId[0];
            AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
            A94DocAnexoDescricao = T00193_A94DocAnexoDescricao[0];
            AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
            A95DocAnexoArquivo = T00193_A95DocAnexoArquivo[0];
            AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
            A96DocAnexoDataInclusao = T00193_A96DocAnexoDataInclusao[0];
            AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
            A75DocumentoId = T00193_A75DocumentoId[0];
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            Z93DocAnexoId = A93DocAnexoId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load1952( ) ;
            if ( AnyError == 1 )
            {
               RcdFound52 = 0;
               InitializeNonKey1952( ) ;
            }
            Gx_mode = sMode52;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1952( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode52;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1952( ) ;
         if ( RcdFound52 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound52 = 0;
         /* Using cursor T00198 */
         pr_default.execute(6, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00198_A93DocAnexoId[0] < A93DocAnexoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00198_A93DocAnexoId[0] > A93DocAnexoId ) ) )
            {
               A93DocAnexoId = T00198_A93DocAnexoId[0];
               AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
               RcdFound52 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound52 = 0;
         /* Using cursor T00199 */
         pr_default.execute(7, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00199_A93DocAnexoId[0] > A93DocAnexoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00199_A93DocAnexoId[0] < A93DocAnexoId ) ) )
            {
               A93DocAnexoId = T00199_A93DocAnexoId[0];
               AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
               RcdFound52 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1952( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert1952( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound52 == 1 )
            {
               if ( A93DocAnexoId != Z93DocAnexoId )
               {
                  A93DocAnexoId = Z93DocAnexoId;
                  AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCANEXOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocAnexoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1952( ) ;
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A93DocAnexoId != Z93DocAnexoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert1952( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCANEXOID");
                     AnyError = 1;
                     GX_FocusControl = edtDocAnexoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocumentoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert1952( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A93DocAnexoId != Z93DocAnexoId )
         {
            A93DocAnexoId = Z93DocAnexoId;
            AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCANEXOID");
            AnyError = 1;
            GX_FocusControl = edtDocAnexoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1952( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00192 */
            pr_default.execute(0, new Object[] {A93DocAnexoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocAnexo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z94DocAnexoDescricao, T00192_A94DocAnexoDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z95DocAnexoArquivo, T00192_A95DocAnexoArquivo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z96DocAnexoDataInclusao ) != DateTimeUtil.ResetTime ( T00192_A96DocAnexoDataInclusao[0] ) ) || ( Z75DocumentoId != T00192_A75DocumentoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z94DocAnexoDescricao, T00192_A94DocAnexoDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("docanexo:[seudo value changed for attri]"+"DocAnexoDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z94DocAnexoDescricao);
                  GXUtil.WriteLogRaw("Current: ",T00192_A94DocAnexoDescricao[0]);
               }
               if ( StringUtil.StrCmp(Z95DocAnexoArquivo, T00192_A95DocAnexoArquivo[0]) != 0 )
               {
                  GXUtil.WriteLog("docanexo:[seudo value changed for attri]"+"DocAnexoArquivo");
                  GXUtil.WriteLogRaw("Old: ",Z95DocAnexoArquivo);
                  GXUtil.WriteLogRaw("Current: ",T00192_A95DocAnexoArquivo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z96DocAnexoDataInclusao ) != DateTimeUtil.ResetTime ( T00192_A96DocAnexoDataInclusao[0] ) )
               {
                  GXUtil.WriteLog("docanexo:[seudo value changed for attri]"+"DocAnexoDataInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z96DocAnexoDataInclusao);
                  GXUtil.WriteLogRaw("Current: ",T00192_A96DocAnexoDataInclusao[0]);
               }
               if ( Z75DocumentoId != T00192_A75DocumentoId[0] )
               {
                  GXUtil.WriteLog("docanexo:[seudo value changed for attri]"+"DocumentoId");
                  GXUtil.WriteLogRaw("Old: ",Z75DocumentoId);
                  GXUtil.WriteLogRaw("Current: ",T00192_A75DocumentoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocAnexo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1952( )
      {
         if ( ! IsAuthorized("docanexo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1952( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1952( 0) ;
            CheckOptimisticConcurrency1952( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1952( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1952( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001910 */
                     pr_default.execute(8, new Object[] {A94DocAnexoDescricao, A95DocAnexoArquivo, A96DocAnexoDataInclusao, A75DocumentoId});
                     A93DocAnexoId = T001910_A93DocAnexoId[0];
                     AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("DocAnexo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption190( ) ;
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
               Load1952( ) ;
            }
            EndLevel1952( ) ;
         }
         CloseExtendedTableCursors1952( ) ;
      }

      protected void Update1952( )
      {
         if ( ! IsAuthorized("docanexo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1952( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1952( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1952( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1952( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001911 */
                     pr_default.execute(9, new Object[] {A94DocAnexoDescricao, A95DocAnexoArquivo, A96DocAnexoDataInclusao, A75DocumentoId, A93DocAnexoId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("DocAnexo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocAnexo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1952( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
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
            EndLevel1952( ) ;
         }
         CloseExtendedTableCursors1952( ) ;
      }

      protected void DeferredUpdate1952( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("docanexo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1952( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1952( ) ;
            AfterConfirm1952( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1952( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001912 */
                  pr_default.execute(10, new Object[] {A93DocAnexoId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("DocAnexo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
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
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel1952( ) ;
         Gx_mode = sMode52;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1952( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001913 */
            pr_default.execute(11, new Object[] {A75DocumentoId});
            A76DocumentoNome = T001913_A76DocumentoNome[0];
            n76DocumentoNome = T001913_n76DocumentoNome[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel1952( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1952( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("docanexo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues190( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("docanexo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1952( )
      {
         /* Scan By routine */
         /* Using cursor T001914 */
         pr_default.execute(12);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound52 = 1;
            A93DocAnexoId = T001914_A93DocAnexoId[0];
            AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1952( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound52 = 1;
            A93DocAnexoId = T001914_A93DocAnexoId[0];
            AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
         }
      }

      protected void ScanEnd1952( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1952( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1952( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1952( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1952( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1952( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1952( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1952( )
      {
         edtDocAnexoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocAnexoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoId_Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtDocAnexoDescricao_Enabled = 0;
         AssignProp(sPrefix, false, edtDocAnexoDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoDescricao_Enabled), 5, 0), true);
         edtDocAnexoArquivo_Enabled = 0;
         AssignProp(sPrefix, false, edtDocAnexoArquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoArquivo_Enabled), 5, 0), true);
         edtDocAnexoDataInclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtDocAnexoDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnexoDataInclusao_Enabled), 5, 0), true);
         edtavCombodocumentoid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1952( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues190( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Doc Anexo") ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docanexo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocAnexoId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docanexo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"DocAnexo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("docanexo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z93DocAnexoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z93DocAnexoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z94DocAnexoDescricao", Z94DocAnexoDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z95DocAnexoArquivo", Z95DocAnexoArquivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z96DocAnexoDataInclusao", context.localUtil.DToC( Z96DocAnexoDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7DocAnexoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7DocAnexoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCUMENTOID_DATA", AV15DocumentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCUMENTOID_DATA", AV15DocumentoId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCANEXOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocAnexoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTONOME", A76DocumentoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV24Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Objectcall", StringUtil.RTrim( Combo_documentoid_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Cls", StringUtil.RTrim( Combo_documentoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_documentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Selectedtext_set", StringUtil.RTrim( Combo_documentoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Gamoauthtoken", StringUtil.RTrim( Combo_documentoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Datalistproc", StringUtil.RTrim( Combo_documentoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_documentoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Emptyitem", StringUtil.BoolToStr( Combo_documentoid_Emptyitem));
      }

      protected void RenderHtmlCloseForm1952( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "DocAnexo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Anexo" ;
      }

      protected void InitializeNonKey1952( )
      {
         A75DocumentoId = 0;
         AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         A94DocAnexoDescricao = "";
         AssignAttri(sPrefix, false, "A94DocAnexoDescricao", A94DocAnexoDescricao);
         A95DocAnexoArquivo = "";
         AssignAttri(sPrefix, false, "A95DocAnexoArquivo", A95DocAnexoArquivo);
         A76DocumentoNome = "";
         n76DocumentoNome = false;
         AssignAttri(sPrefix, false, "A76DocumentoNome", A76DocumentoNome);
         A96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
         Z94DocAnexoDescricao = "";
         Z95DocAnexoArquivo = "";
         Z96DocAnexoDataInclusao = DateTime.MinValue;
         Z75DocumentoId = 0;
      }

      protected void InitAll1952( )
      {
         A93DocAnexoId = 0;
         AssignAttri(sPrefix, false, "A93DocAnexoId", StringUtil.LTrimStr( (decimal)(A93DocAnexoId), 8, 0));
         InitializeNonKey1952( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A96DocAnexoDataInclusao = i96DocAnexoDataInclusao;
         AssignAttri(sPrefix, false, "A96DocAnexoDataInclusao", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7DocAnexoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "docanexo", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV7DocAnexoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7DocAnexoId", StringUtil.LTrimStr( (decimal)(AV7DocAnexoId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7DocAnexoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DocAnexoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7DocAnexoId != wcpOAV7DocAnexoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7DocAnexoId = AV7DocAnexoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV7DocAnexoId = cgiGet( sPrefix+"AV7DocAnexoId_CTRL");
         if ( StringUtil.Len( sCtrlAV7DocAnexoId) > 0 )
         {
            AV7DocAnexoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV7DocAnexoId), ",", "."));
            AssignAttri(sPrefix, false, "AV7DocAnexoId", StringUtil.LTrimStr( (decimal)(AV7DocAnexoId), 8, 0));
         }
         else
         {
            AV7DocAnexoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV7DocAnexoId_PARM"), ",", "."));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7DocAnexoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocAnexoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7DocAnexoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7DocAnexoId_CTRL", StringUtil.RTrim( sCtrlAV7DocAnexoId));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            Draw( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417262782", true, true);
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
         context.AddJavascriptSource("docanexo.js", "?202312417262783", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDocAnexoId_Internalname = sPrefix+"DOCANEXOID";
         lblTextblockdocumentoid_Internalname = sPrefix+"TEXTBLOCKDOCUMENTOID";
         Combo_documentoid_Internalname = sPrefix+"COMBO_DOCUMENTOID";
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID";
         divTablesplitteddocumentoid_Internalname = sPrefix+"TABLESPLITTEDDOCUMENTOID";
         edtDocAnexoDescricao_Internalname = sPrefix+"DOCANEXODESCRICAO";
         edtDocAnexoArquivo_Internalname = sPrefix+"DOCANEXOARQUIVO";
         edtDocAnexoDataInclusao_Internalname = sPrefix+"DOCANEXODATAINCLUSAO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCombodocumentoid_Internalname = sPrefix+"vCOMBODOCUMENTOID";
         divSectionattribute_documentoid_Internalname = sPrefix+"SECTIONATTRIBUTE_DOCUMENTOID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtavCombodocumentoid_Jsonclick = "";
         edtavCombodocumentoid_Enabled = 0;
         edtavCombodocumentoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocAnexoDataInclusao_Jsonclick = "";
         edtDocAnexoDataInclusao_Enabled = 1;
         edtDocAnexoArquivo_Enabled = 1;
         edtDocAnexoDescricao_Jsonclick = "";
         edtDocAnexoDescricao_Enabled = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 1;
         edtDocumentoId_Visible = 1;
         Combo_documentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_documentoid_Datalistprocparametersprefix = " \"ComboName\": \"DocumentoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"DocAnexoId\": 0";
         Combo_documentoid_Datalistproc = "DocAnexoLoadDVCombo";
         Combo_documentoid_Cls = "ExtendedCombo AttributeFL";
         Combo_documentoid_Caption = "";
         Combo_documentoid_Enabled = Convert.ToBoolean( -1);
         edtDocAnexoId_Jsonclick = "";
         edtDocAnexoId_Enabled = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
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
         n76DocumentoNome = false;
         /* Using cursor T001913 */
         pr_default.execute(11, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
         }
         A76DocumentoNome = T001913_A76DocumentoNome[0];
         n76DocumentoNome = T001913_n76DocumentoNome[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A76DocumentoNome", A76DocumentoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7DocAnexoId',fld:'vDOCANEXOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12192',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_DOCANEXOID","{handler:'Valid_Docanexoid',iparms:[]");
         setEventMetadata("VALID_DOCANEXOID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A76DocumentoNome',fld:'DOCUMENTONOME',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[{av:'A76DocumentoNome',fld:'DOCUMENTONOME',pic:''}]}");
         setEventMetadata("VALID_DOCANEXODESCRICAO","{handler:'Valid_Docanexodescricao',iparms:[]");
         setEventMetadata("VALID_DOCANEXODESCRICAO",",oparms:[]}");
         setEventMetadata("VALID_DOCANEXOARQUIVO","{handler:'Valid_Docanexoarquivo',iparms:[]");
         setEventMetadata("VALID_DOCANEXOARQUIVO",",oparms:[]}");
         setEventMetadata("VALID_DOCANEXODATAINCLUSAO","{handler:'Valid_Docanexodatainclusao',iparms:[]");
         setEventMetadata("VALID_DOCANEXODATAINCLUSAO",",oparms:[]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z94DocAnexoDescricao = "";
         Z95DocAnexoArquivo = "";
         Z96DocAnexoDataInclusao = DateTime.MinValue;
         Combo_documentoid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTextblockdocumentoid_Jsonclick = "";
         ucCombo_documentoid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15DocumentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A94DocAnexoDescricao = "";
         A95DocAnexoArquivo = "";
         A96DocAnexoDataInclusao = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A76DocumentoNome = "";
         AV24Pgmname = "";
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
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode52 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z76DocumentoNome = "";
         T00194_A76DocumentoNome = new string[] {""} ;
         T00194_n76DocumentoNome = new bool[] {false} ;
         T00195_A93DocAnexoId = new int[1] ;
         T00195_A94DocAnexoDescricao = new string[] {""} ;
         T00195_A95DocAnexoArquivo = new string[] {""} ;
         T00195_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00195_A76DocumentoNome = new string[] {""} ;
         T00195_n76DocumentoNome = new bool[] {false} ;
         T00195_A75DocumentoId = new int[1] ;
         T00196_A76DocumentoNome = new string[] {""} ;
         T00196_n76DocumentoNome = new bool[] {false} ;
         T00197_A93DocAnexoId = new int[1] ;
         T00193_A93DocAnexoId = new int[1] ;
         T00193_A94DocAnexoDescricao = new string[] {""} ;
         T00193_A95DocAnexoArquivo = new string[] {""} ;
         T00193_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00193_A75DocumentoId = new int[1] ;
         T00198_A93DocAnexoId = new int[1] ;
         T00199_A93DocAnexoId = new int[1] ;
         T00192_A93DocAnexoId = new int[1] ;
         T00192_A94DocAnexoDescricao = new string[] {""} ;
         T00192_A95DocAnexoArquivo = new string[] {""} ;
         T00192_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00192_A75DocumentoId = new int[1] ;
         T001910_A93DocAnexoId = new int[1] ;
         T001913_A76DocumentoNome = new string[] {""} ;
         T001913_n76DocumentoNome = new bool[] {false} ;
         T001914_A93DocAnexoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i96DocAnexoDataInclusao = DateTime.MinValue;
         sCtrlGx_mode = "";
         sCtrlAV7DocAnexoId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docanexo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docanexo__default(),
            new Object[][] {
                new Object[] {
               T00192_A93DocAnexoId, T00192_A94DocAnexoDescricao, T00192_A95DocAnexoArquivo, T00192_A96DocAnexoDataInclusao, T00192_A75DocumentoId
               }
               , new Object[] {
               T00193_A93DocAnexoId, T00193_A94DocAnexoDescricao, T00193_A95DocAnexoArquivo, T00193_A96DocAnexoDataInclusao, T00193_A75DocumentoId
               }
               , new Object[] {
               T00194_A76DocumentoNome, T00194_n76DocumentoNome
               }
               , new Object[] {
               T00195_A93DocAnexoId, T00195_A94DocAnexoDescricao, T00195_A95DocAnexoArquivo, T00195_A96DocAnexoDataInclusao, T00195_A76DocumentoNome, T00195_n76DocumentoNome, T00195_A75DocumentoId
               }
               , new Object[] {
               T00196_A76DocumentoNome, T00196_n76DocumentoNome
               }
               , new Object[] {
               T00197_A93DocAnexoId
               }
               , new Object[] {
               T00198_A93DocAnexoId
               }
               , new Object[] {
               T00199_A93DocAnexoId
               }
               , new Object[] {
               T001910_A93DocAnexoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001913_A76DocumentoNome, T001913_n76DocumentoNome
               }
               , new Object[] {
               T001914_A93DocAnexoId
               }
            }
         );
         AV24Pgmname = "DocAnexo";
         Z96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         A96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         i96DocAnexoDataInclusao = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short nDynComponent ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short Gx_BScreen ;
      private short RcdFound52 ;
      private short GX_JID ;
      private short nIsDirty_52 ;
      private int wcpOAV7DocAnexoId ;
      private int Z93DocAnexoId ;
      private int Z75DocumentoId ;
      private int N75DocumentoId ;
      private int AV7DocAnexoId ;
      private int A75DocumentoId ;
      private int trnEnded ;
      private int A93DocAnexoId ;
      private int edtDocAnexoId_Enabled ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoId_Enabled ;
      private int edtDocAnexoDescricao_Enabled ;
      private int edtDocAnexoArquivo_Enabled ;
      private int edtDocAnexoDataInclusao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV20ComboDocumentoId ;
      private int edtavCombodocumentoid_Enabled ;
      private int edtavCombodocumentoid_Visible ;
      private int AV13Insert_DocumentoId ;
      private int Combo_documentoid_Datalistupdateminimumcharacters ;
      private int Combo_documentoid_Gxcontroltype ;
      private int AV25GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_documentoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtDocumentoId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string edtDocAnexoId_Internalname ;
      private string edtDocAnexoId_Jsonclick ;
      private string divTablesplitteddocumentoid_Internalname ;
      private string lblTextblockdocumentoid_Internalname ;
      private string lblTextblockdocumentoid_Jsonclick ;
      private string Combo_documentoid_Caption ;
      private string Combo_documentoid_Cls ;
      private string Combo_documentoid_Datalistproc ;
      private string Combo_documentoid_Datalistprocparametersprefix ;
      private string Combo_documentoid_Internalname ;
      private string TempTags ;
      private string edtDocumentoId_Jsonclick ;
      private string edtDocAnexoDescricao_Internalname ;
      private string edtDocAnexoDescricao_Jsonclick ;
      private string edtDocAnexoArquivo_Internalname ;
      private string edtDocAnexoDataInclusao_Internalname ;
      private string edtDocAnexoDataInclusao_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_documentoid_Internalname ;
      private string edtavCombodocumentoid_Internalname ;
      private string edtavCombodocumentoid_Jsonclick ;
      private string AV24Pgmname ;
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
      private string hsh ;
      private string sMode52 ;
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
      private string sCtrlGx_mode ;
      private string sCtrlAV7DocAnexoId ;
      private DateTime Z96DocAnexoDataInclusao ;
      private DateTime A96DocAnexoDataInclusao ;
      private DateTime i96DocAnexoDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_documentoid_Emptyitem ;
      private bool n76DocumentoNome ;
      private bool Combo_documentoid_Enabled ;
      private bool Combo_documentoid_Visible ;
      private bool Combo_documentoid_Allowmultipleselection ;
      private bool Combo_documentoid_Isgriditem ;
      private bool Combo_documentoid_Hasdescription ;
      private bool Combo_documentoid_Includeonlyselectedoption ;
      private bool Combo_documentoid_Includeselectalloption ;
      private bool Combo_documentoid_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z94DocAnexoDescricao ;
      private string Z95DocAnexoArquivo ;
      private string A94DocAnexoDescricao ;
      private string A95DocAnexoArquivo ;
      private string A76DocumentoNome ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z76DocumentoNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_documentoid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00194_A76DocumentoNome ;
      private bool[] T00194_n76DocumentoNome ;
      private int[] T00195_A93DocAnexoId ;
      private string[] T00195_A94DocAnexoDescricao ;
      private string[] T00195_A95DocAnexoArquivo ;
      private DateTime[] T00195_A96DocAnexoDataInclusao ;
      private string[] T00195_A76DocumentoNome ;
      private bool[] T00195_n76DocumentoNome ;
      private int[] T00195_A75DocumentoId ;
      private string[] T00196_A76DocumentoNome ;
      private bool[] T00196_n76DocumentoNome ;
      private int[] T00197_A93DocAnexoId ;
      private int[] T00193_A93DocAnexoId ;
      private string[] T00193_A94DocAnexoDescricao ;
      private string[] T00193_A95DocAnexoArquivo ;
      private DateTime[] T00193_A96DocAnexoDataInclusao ;
      private int[] T00193_A75DocumentoId ;
      private int[] T00198_A93DocAnexoId ;
      private int[] T00199_A93DocAnexoId ;
      private int[] T00192_A93DocAnexoId ;
      private string[] T00192_A94DocAnexoDescricao ;
      private string[] T00192_A95DocAnexoArquivo ;
      private DateTime[] T00192_A96DocAnexoDataInclusao ;
      private int[] T00192_A75DocumentoId ;
      private int[] T001910_A93DocAnexoId ;
      private string[] T001913_A76DocumentoNome ;
      private bool[] T001913_n76DocumentoNome ;
      private int[] T001914_A93DocAnexoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15DocumentoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
   }

   public class docanexo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docanexo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00195;
        prmT00195 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT00194;
        prmT00194 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00196;
        prmT00196 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00197;
        prmT00197 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT00193;
        prmT00193 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT00198;
        prmT00198 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT00199;
        prmT00199 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT00192;
        prmT00192 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT001910;
        prmT001910 = new Object[] {
        new ParDef("@DocAnexoDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@DocAnexoArquivo",GXType.NVarChar,200,0) ,
        new ParDef("@DocAnexoDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001911;
        prmT001911 = new Object[] {
        new ParDef("@DocAnexoDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@DocAnexoArquivo",GXType.NVarChar,200,0) ,
        new ParDef("@DocAnexoDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT001912;
        prmT001912 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmT001914;
        prmT001914 = new Object[] {
        };
        Object[] prmT001913;
        prmT001913 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00192", "SELECT [DocAnexoId], [DocAnexoDescricao], [DocAnexoArquivo], [DocAnexoDataInclusao], [DocumentoId] FROM [DocAnexo] WITH (UPDLOCK) WHERE [DocAnexoId] = @DocAnexoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00193", "SELECT [DocAnexoId], [DocAnexoDescricao], [DocAnexoArquivo], [DocAnexoDataInclusao], [DocumentoId] FROM [DocAnexo] WHERE [DocAnexoId] = @DocAnexoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00194", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00195", "SELECT TM1.[DocAnexoId], TM1.[DocAnexoDescricao], TM1.[DocAnexoArquivo], TM1.[DocAnexoDataInclusao], T2.[DocumentoNome], TM1.[DocumentoId] FROM ([DocAnexo] TM1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = TM1.[DocumentoId]) WHERE TM1.[DocAnexoId] = @DocAnexoId ORDER BY TM1.[DocAnexoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00195,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00196", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00196,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00197", "SELECT [DocAnexoId] FROM [DocAnexo] WHERE [DocAnexoId] = @DocAnexoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00197,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00198", "SELECT TOP 1 [DocAnexoId] FROM [DocAnexo] WHERE ( [DocAnexoId] > @DocAnexoId) ORDER BY [DocAnexoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00198,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00199", "SELECT TOP 1 [DocAnexoId] FROM [DocAnexo] WHERE ( [DocAnexoId] < @DocAnexoId) ORDER BY [DocAnexoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00199,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001910", "INSERT INTO [DocAnexo]([DocAnexoDescricao], [DocAnexoArquivo], [DocAnexoDataInclusao], [DocumentoId]) VALUES(@DocAnexoDescricao, @DocAnexoArquivo, @DocAnexoDataInclusao, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001910,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001911", "UPDATE [DocAnexo] SET [DocAnexoDescricao]=@DocAnexoDescricao, [DocAnexoArquivo]=@DocAnexoArquivo, [DocAnexoDataInclusao]=@DocAnexoDataInclusao, [DocumentoId]=@DocumentoId  WHERE [DocAnexoId] = @DocAnexoId", GxErrorMask.GX_NOMASK,prmT001911)
           ,new CursorDef("T001912", "DELETE FROM [DocAnexo]  WHERE [DocAnexoId] = @DocAnexoId", GxErrorMask.GX_NOMASK,prmT001912)
           ,new CursorDef("T001913", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001913,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001914", "SELECT [DocAnexoId] FROM [DocAnexo] ORDER BY [DocAnexoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001914,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
