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
   public class subprocesso : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"PROCESSOID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAPROCESSOID077( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vISOK") == 0 )
         {
            A20SubprocessoId = (int)(NumberUtil.Val( GetPar( "SubprocessoId"), "."));
            n20SubprocessoId = false;
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            A21SubprocessoNome = GetPar( "SubprocessoNome");
            AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASAISOK077( A20SubprocessoId, A21SubprocessoNome) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A16ProcessoId = (int)(NumberUtil.Val( GetPar( "ProcessoId"), "."));
            n16ProcessoId = false;
            AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A16ProcessoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "subprocesso.aspx")), "subprocesso.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "subprocesso.aspx")))) ;
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
                  AV7SubprocessoId = (int)(NumberUtil.Val( GetPar( "SubprocessoId"), "."));
                  AssignAttri("", false, "AV7SubprocessoId", StringUtil.LTrimStr( (decimal)(AV7SubprocessoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUBPROCESSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SubprocessoId), "ZZZZZZZ9"), context));
                  AV27IsSubProcesso = StringUtil.StrToBool( GetPar( "IsSubProcesso"));
                  AssignAttri("", false, "AV27IsSubProcesso", AV27IsSubProcesso);
                  AV28SubProcessoId_Out = (int)(NumberUtil.Val( GetPar( "SubProcessoId_Out"), "."));
                  AssignAttri("", false, "AV28SubProcessoId_Out", StringUtil.LTrimStr( (decimal)(AV28SubProcessoId_Out), 8, 0));
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
            Form.Meta.addItem("description", "Sub Processo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSubprocessoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public subprocesso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public subprocesso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SubprocessoId ,
                           out bool aP2_IsSubProcesso ,
                           out int aP3_SubProcessoId_Out )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SubprocessoId = aP1_SubprocessoId;
         this.AV27IsSubProcesso = false ;
         this.AV28SubProcessoId_Out = 0 ;
         executePrivate();
         aP2_IsSubProcesso=this.AV27IsSubProcesso;
         aP3_SubProcessoId_Out=this.AV28SubProcessoId_Out;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynProcessoId = new GXCombobox();
         cmbSubprocessoAtivo = new GXCombobox();
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
            return "subprocesso_Execute" ;
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
         if ( dynProcessoId.ItemCount > 0 )
         {
            A16ProcessoId = (int)(NumberUtil.Val( dynProcessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0))), "."));
            n16ProcessoId = false;
            AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProcessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0));
            AssignProp("", false, dynProcessoId_Internalname, "Values", dynProcessoId.ToJavascriptSource(), true);
         }
         if ( cmbSubprocessoAtivo.ItemCount > 0 )
         {
            A23SubprocessoAtivo = StringUtil.StrToBool( cmbSubprocessoAtivo.getValidValue(StringUtil.BoolToStr( A23SubprocessoAtivo)));
            AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSubprocessoAtivo.CurrentValue = StringUtil.BoolToStr( A23SubprocessoAtivo);
            AssignProp("", false, cmbSubprocessoAtivo_Internalname, "Values", cmbSubprocessoAtivo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSubprocessoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSubprocessoNome_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSubprocessoNome_Internalname, A21SubprocessoNome, StringUtil.RTrim( context.localUtil.Format( A21SubprocessoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSubprocessoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSubprocessoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_SubProcesso.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynProcessoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynProcessoId_Internalname, "PROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynProcessoId, dynProcessoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0)), 1, dynProcessoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProcessoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_SubProcesso.htm");
         dynProcessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0));
         AssignProp("", false, dynProcessoId_Internalname, "Values", (string)(dynProcessoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbSubprocessoAtivo.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbSubprocessoAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSubprocessoAtivo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSubprocessoAtivo, cmbSubprocessoAtivo_Internalname, StringUtil.BoolToStr( A23SubprocessoAtivo), 1, cmbSubprocessoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbSubprocessoAtivo.Visible, cmbSubprocessoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_SubProcesso.htm");
         cmbSubprocessoAtivo.CurrentValue = StringUtil.BoolToStr( A23SubprocessoAtivo);
         AssignProp("", false, cmbSubprocessoAtivo_Internalname, "Values", (string)(cmbSubprocessoAtivo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "CONFIRMAR", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SubProcesso.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "FECHAR", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SubProcesso.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "ELIMINAR", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SubProcesso.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSubprocessoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtSubprocessoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20SubprocessoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A20SubprocessoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSubprocessoId_Jsonclick, 0, "Attribute", "", "", "", "", edtSubprocessoId_Visible, edtSubprocessoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_SubProcesso.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z20SubprocessoId = (int)(context.localUtil.CToN( cgiGet( "Z20SubprocessoId"), ",", "."));
               Z21SubprocessoNome = cgiGet( "Z21SubprocessoNome");
               Z23SubprocessoAtivo = StringUtil.StrToBool( cgiGet( "Z23SubprocessoAtivo"));
               Z16ProcessoId = (int)(context.localUtil.CToN( cgiGet( "Z16ProcessoId"), ",", "."));
               n16ProcessoId = ((0==A16ProcessoId) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N16ProcessoId = (int)(context.localUtil.CToN( cgiGet( "N16ProcessoId"), ",", "."));
               n16ProcessoId = ((0==A16ProcessoId) ? true : false);
               AV7SubprocessoId = (int)(context.localUtil.CToN( cgiGet( "vSUBPROCESSOID"), ",", "."));
               AV13Insert_ProcessoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_PROCESSOID"), ",", "."));
               AV31IsOk = StringUtil.StrToBool( cgiGet( "vISOK"));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               A17ProcessoNome = cgiGet( "PROCESSONOME");
               AV33Pgmname = cgiGet( "vPGMNAME");
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
               A21SubprocessoNome = cgiGet( edtSubprocessoNome_Internalname);
               AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
               dynProcessoId.CurrentValue = cgiGet( dynProcessoId_Internalname);
               A16ProcessoId = (int)(NumberUtil.Val( cgiGet( dynProcessoId_Internalname), "."));
               n16ProcessoId = false;
               AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
               n16ProcessoId = ((0==A16ProcessoId) ? true : false);
               cmbSubprocessoAtivo.CurrentValue = cgiGet( cmbSubprocessoAtivo_Internalname);
               A23SubprocessoAtivo = StringUtil.StrToBool( cgiGet( cmbSubprocessoAtivo_Internalname));
               AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
               A20SubprocessoId = (int)(context.localUtil.CToN( cgiGet( edtSubprocessoId_Internalname), ",", "."));
               n20SubprocessoId = false;
               AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SubProcesso");
               A20SubprocessoId = (int)(context.localUtil.CToN( cgiGet( edtSubprocessoId_Internalname), ",", "."));
               n20SubprocessoId = false;
               AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
               forbiddenHiddens.Add("SubprocessoId", context.localUtil.Format( (decimal)(A20SubprocessoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A20SubprocessoId != Z20SubprocessoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("subprocesso:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A20SubprocessoId = (int)(NumberUtil.Val( GetPar( "SubprocessoId"), "."));
                  n20SubprocessoId = false;
                  AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUBPROCESSOID");
                        AnyError = 1;
                        GX_FocusControl = edtSubprocessoId_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
            DisableAttributes077( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            AssignAttri("", false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            while ( AV34GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProcessoId") == 0 )
               {
                  AV13Insert_ProcessoId = (int)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_ProcessoId", StringUtil.LTrimStr( (decimal)(AV13Insert_ProcessoId), 8, 0));
               }
               AV34GXV1 = (int)(AV34GXV1+1);
               AssignAttri("", false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            }
         }
         edtSubprocessoId_Visible = 0;
         AssignProp("", false, edtSubprocessoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSubprocessoId_Visible), 5, 0), true);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbSubprocessoAtivo.Visible = 0;
            AssignProp("", false, cmbSubprocessoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSubprocessoAtivo.Visible), 5, 0), true);
         }
         else
         {
            cmbSubprocessoAtivo.Visible = 1;
            AssignProp("", false, cmbSubprocessoAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSubprocessoAtivo.Visible), 5, 0), true);
         }
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV27IsSubProcesso = true;
         AssignAttri("", false, "AV27IsSubProcesso", AV27IsSubProcesso);
         AV28SubProcessoId_Out = A20SubprocessoId;
         AssignAttri("", false, "AV28SubProcessoId_Out", StringUtil.LTrimStr( (decimal)(AV28SubProcessoId_Out), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("subprocessoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {(bool)AV27IsSubProcesso,(int)AV28SubProcessoId_Out});
         context.setWebReturnParmsMetadata(new Object[] {"AV27IsSubProcesso","AV28SubProcessoId_Out"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z21SubprocessoNome = T00073_A21SubprocessoNome[0];
               Z23SubprocessoAtivo = T00073_A23SubprocessoAtivo[0];
               Z16ProcessoId = T00073_A16ProcessoId[0];
            }
            else
            {
               Z21SubprocessoNome = A21SubprocessoNome;
               Z23SubprocessoAtivo = A23SubprocessoAtivo;
               Z16ProcessoId = A16ProcessoId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z20SubprocessoId = A20SubprocessoId;
            Z21SubprocessoNome = A21SubprocessoNome;
            Z23SubprocessoAtivo = A23SubprocessoAtivo;
            Z16ProcessoId = A16ProcessoId;
            Z17ProcessoNome = A17ProcessoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         GXAPROCESSOID_html077( ) ;
         edtSubprocessoId_Enabled = 0;
         AssignProp("", false, edtSubprocessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSubprocessoId_Enabled), 5, 0), true);
         AV33Pgmname = "SubProcesso";
         AssignAttri("", false, "AV33Pgmname", AV33Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtSubprocessoId_Enabled = 0;
         AssignProp("", false, edtSubprocessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSubprocessoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SubprocessoId) )
         {
            A20SubprocessoId = AV7SubprocessoId;
            n20SubprocessoId = false;
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProcessoId) )
         {
            dynProcessoId.Enabled = 0;
            AssignProp("", false, dynProcessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProcessoId.Enabled), 5, 0), true);
         }
         else
         {
            dynProcessoId.Enabled = 1;
            AssignProp("", false, dynProcessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProcessoId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProcessoId) )
         {
            A16ProcessoId = AV13Insert_ProcessoId;
            n16ProcessoId = false;
            AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
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
         if ( IsIns( )  && (false==A23SubprocessoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A23SubprocessoAtivo = true;
            AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00074 */
            pr_default.execute(2, new Object[] {n16ProcessoId, A16ProcessoId});
            A17ProcessoNome = T00074_A17ProcessoNome[0];
            pr_default.close(2);
         }
      }

      protected void Load077( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A21SubprocessoNome = T00075_A21SubprocessoNome[0];
            AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
            A17ProcessoNome = T00075_A17ProcessoNome[0];
            A23SubprocessoAtivo = T00075_A23SubprocessoAtivo[0];
            AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
            A16ProcessoId = T00075_A16ProcessoId[0];
            n16ProcessoId = T00075_n16ProcessoId[0];
            AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
            ZM077( -14) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
         A21SubprocessoNome = StringUtil.Upper( A21SubprocessoNome);
         AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
         GXt_boolean1 = AV31IsOk;
         new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
         AV31IsOk = GXt_boolean1;
         AssignAttri("", false, "AV31IsOk", AV31IsOk);
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A16ProcessoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "PROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynProcessoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A17ProcessoNome = T00074_A17ProcessoNome[0];
         pr_default.close(2);
         nIsDirty_7 = 1;
         A21SubprocessoNome = StringUtil.Upper( A21SubprocessoNome);
         AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
         GXt_boolean1 = AV31IsOk;
         new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
         AV31IsOk = GXt_boolean1;
         AssignAttri("", false, "AV31IsOk", AV31IsOk);
         if ( ! AV31IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A21SubprocessoNome)) )
         {
            GX_msglist.addItem("Informe o nome do subprocesso.", 1, "SUBPROCESSONOME");
            AnyError = 1;
            GX_FocusControl = edtSubprocessoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A16ProcessoId )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A16ProcessoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "PROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynProcessoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A17ProcessoNome = T00076_A17ProcessoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A17ProcessoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 14) ;
            RcdFound7 = 1;
            A20SubprocessoId = T00073_A20SubprocessoId[0];
            n20SubprocessoId = T00073_n20SubprocessoId[0];
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            A21SubprocessoNome = T00073_A21SubprocessoNome[0];
            AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
            A23SubprocessoAtivo = T00073_A23SubprocessoAtivo[0];
            AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
            A16ProcessoId = T00073_A16ProcessoId[0];
            n16ProcessoId = T00073_n16ProcessoId[0];
            AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
            Z20SubprocessoId = A20SubprocessoId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00078_A20SubprocessoId[0] < A20SubprocessoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00078_A20SubprocessoId[0] > A20SubprocessoId ) ) )
            {
               A20SubprocessoId = T00078_A20SubprocessoId[0];
               n20SubprocessoId = T00078_n20SubprocessoId[0];
               AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A20SubprocessoId[0] > A20SubprocessoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A20SubprocessoId[0] < A20SubprocessoId ) ) )
            {
               A20SubprocessoId = T00079_A20SubprocessoId[0];
               n20SubprocessoId = T00079_n20SubprocessoId[0];
               AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSubprocessoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A20SubprocessoId != Z20SubprocessoId )
               {
                  A20SubprocessoId = Z20SubprocessoId;
                  n20SubprocessoId = false;
                  AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUBPROCESSOID");
                  AnyError = 1;
                  GX_FocusControl = edtSubprocessoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSubprocessoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtSubprocessoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A20SubprocessoId != Z20SubprocessoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSubprocessoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUBPROCESSOID");
                     AnyError = 1;
                     GX_FocusControl = edtSubprocessoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSubprocessoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( A20SubprocessoId != Z20SubprocessoId )
         {
            A20SubprocessoId = Z20SubprocessoId;
            n20SubprocessoId = false;
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUBPROCESSOID");
            AnyError = 1;
            GX_FocusControl = edtSubprocessoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSubprocessoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {n20SubprocessoId, A20SubprocessoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SubProcesso"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z21SubprocessoNome, T00072_A21SubprocessoNome[0]) != 0 ) || ( Z23SubprocessoAtivo != T00072_A23SubprocessoAtivo[0] ) || ( Z16ProcessoId != T00072_A16ProcessoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z21SubprocessoNome, T00072_A21SubprocessoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("subprocesso:[seudo value changed for attri]"+"SubprocessoNome");
                  GXUtil.WriteLogRaw("Old: ",Z21SubprocessoNome);
                  GXUtil.WriteLogRaw("Current: ",T00072_A21SubprocessoNome[0]);
               }
               if ( Z23SubprocessoAtivo != T00072_A23SubprocessoAtivo[0] )
               {
                  GXUtil.WriteLog("subprocesso:[seudo value changed for attri]"+"SubprocessoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z23SubprocessoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T00072_A23SubprocessoAtivo[0]);
               }
               if ( Z16ProcessoId != T00072_A16ProcessoId[0] )
               {
                  GXUtil.WriteLog("subprocesso:[seudo value changed for attri]"+"ProcessoId");
                  GXUtil.WriteLogRaw("Old: ",Z16ProcessoId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A16ProcessoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SubProcesso"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         if ( ! IsAuthorized("subprocesso_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {A21SubprocessoNome, A23SubprocessoAtivo, n16ProcessoId, A16ProcessoId});
                     A20SubprocessoId = T000710_A20SubprocessoId[0];
                     n20SubprocessoId = T000710_n20SubprocessoId[0];
                     AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("SubProcesso");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         if ( ! IsAuthorized("subprocesso_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A21SubprocessoNome, A23SubprocessoAtivo, n16ProcessoId, A16ProcessoId, n20SubprocessoId, A20SubprocessoId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SubProcesso");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SubProcesso"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("subprocesso_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000712 */
                  pr_default.execute(10, new Object[] {n20SubprocessoId, A20SubprocessoId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("SubProcesso");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {n16ProcessoId, A16ProcessoId});
            A17ProcessoNome = T000713_A17ProcessoNome[0];
            pr_default.close(11);
            GXt_boolean1 = AV31IsOk;
            new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
            AV31IsOk = GXt_boolean1;
            AssignAttri("", false, "AV31IsOk", AV31IsOk);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000714 */
            pr_default.execute(12, new Object[] {n20SubprocessoId, A20SubprocessoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("subprocesso",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("subprocesso",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000715 */
         pr_default.execute(13);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A20SubprocessoId = T000715_A20SubprocessoId[0];
            n20SubprocessoId = T000715_n20SubprocessoId[0];
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A20SubprocessoId = T000715_A20SubprocessoId[0];
            n20SubprocessoId = T000715_n20SubprocessoId[0];
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtSubprocessoNome_Enabled = 0;
         AssignProp("", false, edtSubprocessoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSubprocessoNome_Enabled), 5, 0), true);
         dynProcessoId.Enabled = 0;
         AssignProp("", false, dynProcessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProcessoId.Enabled), 5, 0), true);
         cmbSubprocessoAtivo.Enabled = 0;
         AssignProp("", false, cmbSubprocessoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSubprocessoAtivo.Enabled), 5, 0), true);
         edtSubprocessoId_Enabled = 0;
         AssignProp("", false, edtSubprocessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSubprocessoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         GXEncryptionTmp = "subprocesso.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SubprocessoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV27IsSubProcesso)) + "," + UrlEncode(StringUtil.LTrimStr(AV28SubProcessoId_Out,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("subprocesso.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SubProcesso");
         forbiddenHiddens.Add("SubprocessoId", context.localUtil.Format( (decimal)(A20SubprocessoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("subprocesso:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z20SubprocessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20SubprocessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z21SubprocessoNome", Z21SubprocessoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z23SubprocessoAtivo", Z23SubprocessoAtivo);
         GxWebStd.gx_hidden_field( context, "Z16ProcessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16ProcessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N16ProcessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ProcessoId), 8, 0, ",", "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vISSUBPROCESSO", AV27IsSubProcesso);
         GxWebStd.gx_hidden_field( context, "vSUBPROCESSOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SubProcessoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vSUBPROCESSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SubprocessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUBPROCESSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SubprocessoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROCESSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ProcessoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV31IsOk);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROCESSONOME", A17ProcessoNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV33Pgmname));
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
         GXEncryptionTmp = "subprocesso.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SubprocessoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV27IsSubProcesso)) + "," + UrlEncode(StringUtil.LTrimStr(AV28SubProcessoId_Out,8,0));
         return formatLink("subprocesso.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SubProcesso" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sub Processo" ;
      }

      protected void InitializeNonKey077( )
      {
         A16ProcessoId = 0;
         n16ProcessoId = false;
         AssignAttri("", false, "A16ProcessoId", StringUtil.LTrimStr( (decimal)(A16ProcessoId), 8, 0));
         n16ProcessoId = ((0==A16ProcessoId) ? true : false);
         A21SubprocessoNome = "";
         AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
         AV31IsOk = false;
         AssignAttri("", false, "AV31IsOk", AV31IsOk);
         A17ProcessoNome = "";
         AssignAttri("", false, "A17ProcessoNome", A17ProcessoNome);
         A23SubprocessoAtivo = true;
         AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
         Z21SubprocessoNome = "";
         Z23SubprocessoAtivo = false;
         Z16ProcessoId = 0;
      }

      protected void InitAll077( )
      {
         A20SubprocessoId = 0;
         n20SubprocessoId = false;
         AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A23SubprocessoAtivo = i23SubprocessoAtivo;
         AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417262793", true, true);
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
         context.AddJavascriptSource("subprocesso.js", "?202312417262795", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSubprocessoNome_Internalname = "SUBPROCESSONOME";
         dynProcessoId_Internalname = "PROCESSOID";
         cmbSubprocessoAtivo_Internalname = "SUBPROCESSOATIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSubprocessoId_Internalname = "SUBPROCESSOID";
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
         Form.Caption = "Sub Processo";
         edtSubprocessoId_Jsonclick = "";
         edtSubprocessoId_Enabled = 0;
         edtSubprocessoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbSubprocessoAtivo_Jsonclick = "";
         cmbSubprocessoAtivo.Enabled = 1;
         cmbSubprocessoAtivo.Visible = 1;
         dynProcessoId_Jsonclick = "";
         dynProcessoId.Enabled = 1;
         edtSubprocessoNome_Jsonclick = "";
         edtSubprocessoNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "SUBPROCESSO";
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

      protected void GXDLAPROCESSOID077( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROCESSOID_data077( ) ;
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

      protected void GXAPROCESSOID_html077( )
      {
         int gxdynajaxvalue;
         GXDLAPROCESSOID_data077( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProcessoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynProcessoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAPROCESSOID_data077( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor T000716 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000716_A16ProcessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000716_A17ProcessoNome[0]);
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void GX8ASAISOK077( int A20SubprocessoId ,
                                    string A21SubprocessoNome )
      {
         GXt_boolean1 = AV31IsOk;
         new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
         AV31IsOk = GXt_boolean1;
         AssignAttri("", false, "AV31IsOk", AV31IsOk);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV31IsOk))+"\"") ;
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
         dynProcessoId.Name = "PROCESSOID";
         dynProcessoId.WebTags = "";
         cmbSubprocessoAtivo.Name = "SUBPROCESSOATIVO";
         cmbSubprocessoAtivo.WebTags = "";
         cmbSubprocessoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbSubprocessoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbSubprocessoAtivo.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A23SubprocessoAtivo) )
            {
               A23SubprocessoAtivo = true;
               AssignAttri("", false, "A23SubprocessoAtivo", A23SubprocessoAtivo);
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

      public void Valid_Subprocessonome( )
      {
         n20SubprocessoId = false;
         n16ProcessoId = false;
         A16ProcessoId = (int)(NumberUtil.Val( dynProcessoId.CurrentValue, "."));
         n16ProcessoId = false;
         A21SubprocessoNome = StringUtil.Upper( A21SubprocessoNome);
         GXt_boolean1 = AV31IsOk;
         new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
         AV31IsOk = GXt_boolean1;
         if ( ! AV31IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "SUBPROCESSONOME");
            AnyError = 1;
            GX_FocusControl = edtSubprocessoNome_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A21SubprocessoNome)) )
         {
            GX_msglist.addItem("Informe o nome do subprocesso.", 1, "SUBPROCESSONOME");
            AnyError = 1;
            GX_FocusControl = edtSubprocessoNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21SubprocessoNome", A21SubprocessoNome);
         AssignAttri("", false, "AV31IsOk", AV31IsOk);
      }

      public void Valid_Processoid( )
      {
         n16ProcessoId = false;
         A16ProcessoId = (int)(NumberUtil.Val( dynProcessoId.CurrentValue, "."));
         n16ProcessoId = false;
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A16ProcessoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "PROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynProcessoId_Internalname;
            }
         }
         A17ProcessoNome = T000717_A17ProcessoNome[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A17ProcessoNome", A17ProcessoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV27IsSubProcesso',fld:'vISSUBPROCESSO',pic:''},{av:'AV28SubProcessoId_Out',fld:'vSUBPROCESSOID_OUT',pic:'ZZZZZZZ9'},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9',hsh:true},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV27IsSubProcesso',fld:'vISSUBPROCESSO',pic:''},{av:'AV28SubProcessoId_Out',fld:'vSUBPROCESSOID_OUT',pic:'ZZZZZZZ9'},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_SUBPROCESSONOME","{handler:'Valid_Subprocessonome',iparms:[{av:'A21SubprocessoNome',fld:'SUBPROCESSONOME',pic:''},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'AV31IsOk',fld:'vISOK',pic:''},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_SUBPROCESSONOME",",oparms:[{av:'A21SubprocessoNome',fld:'SUBPROCESSONOME',pic:''},{av:'AV31IsOk',fld:'vISOK',pic:''},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_PROCESSOID","{handler:'Valid_Processoid',iparms:[{av:'A17ProcessoNome',fld:'PROCESSONOME',pic:''},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_PROCESSOID",",oparms:[{av:'A17ProcessoNome',fld:'PROCESSONOME',pic:''},{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_SUBPROCESSOID","{handler:'Valid_Subprocessoid',iparms:[{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_SUBPROCESSOID",",oparms:[{av:'dynProcessoId'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'}]}");
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
         pr_default.close(15);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z21SubprocessoNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A21SubprocessoNome = "";
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
         A17ProcessoNome = "";
         AV33Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z17ProcessoNome = "";
         T00074_A17ProcessoNome = new string[] {""} ;
         T00075_A20SubprocessoId = new int[1] ;
         T00075_n20SubprocessoId = new bool[] {false} ;
         T00075_A21SubprocessoNome = new string[] {""} ;
         T00075_A17ProcessoNome = new string[] {""} ;
         T00075_A23SubprocessoAtivo = new bool[] {false} ;
         T00075_A16ProcessoId = new int[1] ;
         T00075_n16ProcessoId = new bool[] {false} ;
         T00076_A17ProcessoNome = new string[] {""} ;
         T00077_A20SubprocessoId = new int[1] ;
         T00077_n20SubprocessoId = new bool[] {false} ;
         T00073_A20SubprocessoId = new int[1] ;
         T00073_n20SubprocessoId = new bool[] {false} ;
         T00073_A21SubprocessoNome = new string[] {""} ;
         T00073_A23SubprocessoAtivo = new bool[] {false} ;
         T00073_A16ProcessoId = new int[1] ;
         T00073_n16ProcessoId = new bool[] {false} ;
         T00078_A20SubprocessoId = new int[1] ;
         T00078_n20SubprocessoId = new bool[] {false} ;
         T00079_A20SubprocessoId = new int[1] ;
         T00079_n20SubprocessoId = new bool[] {false} ;
         T00072_A20SubprocessoId = new int[1] ;
         T00072_n20SubprocessoId = new bool[] {false} ;
         T00072_A21SubprocessoNome = new string[] {""} ;
         T00072_A23SubprocessoAtivo = new bool[] {false} ;
         T00072_A16ProcessoId = new int[1] ;
         T00072_n16ProcessoId = new bool[] {false} ;
         T000710_A20SubprocessoId = new int[1] ;
         T000710_n20SubprocessoId = new bool[] {false} ;
         T000713_A17ProcessoNome = new string[] {""} ;
         T000714_A75DocumentoId = new int[1] ;
         T000715_A20SubprocessoId = new int[1] ;
         T000715_n20SubprocessoId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000716_A16ProcessoId = new int[1] ;
         T000716_n16ProcessoId = new bool[] {false} ;
         T000716_A17ProcessoNome = new string[] {""} ;
         T000717_A17ProcessoNome = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.subprocesso__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.subprocesso__default(),
            new Object[][] {
                new Object[] {
               T00072_A20SubprocessoId, T00072_A21SubprocessoNome, T00072_A23SubprocessoAtivo, T00072_A16ProcessoId, T00072_n16ProcessoId
               }
               , new Object[] {
               T00073_A20SubprocessoId, T00073_A21SubprocessoNome, T00073_A23SubprocessoAtivo, T00073_A16ProcessoId, T00073_n16ProcessoId
               }
               , new Object[] {
               T00074_A17ProcessoNome
               }
               , new Object[] {
               T00075_A20SubprocessoId, T00075_A21SubprocessoNome, T00075_A17ProcessoNome, T00075_A23SubprocessoAtivo, T00075_A16ProcessoId, T00075_n16ProcessoId
               }
               , new Object[] {
               T00076_A17ProcessoNome
               }
               , new Object[] {
               T00077_A20SubprocessoId
               }
               , new Object[] {
               T00078_A20SubprocessoId
               }
               , new Object[] {
               T00079_A20SubprocessoId
               }
               , new Object[] {
               T000710_A20SubprocessoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000713_A17ProcessoNome
               }
               , new Object[] {
               T000714_A75DocumentoId
               }
               , new Object[] {
               T000715_A20SubprocessoId
               }
               , new Object[] {
               T000716_A16ProcessoId, T000716_A17ProcessoNome
               }
               , new Object[] {
               T000717_A17ProcessoNome
               }
            }
         );
         AV33Pgmname = "SubProcesso";
         Z23SubprocessoAtivo = true;
         A23SubprocessoAtivo = true;
         i23SubprocessoAtivo = true;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short nIsDirty_7 ;
      private short gxajaxcallmode ;
      private int wcpOAV7SubprocessoId ;
      private int Z20SubprocessoId ;
      private int Z16ProcessoId ;
      private int N16ProcessoId ;
      private int A20SubprocessoId ;
      private int A16ProcessoId ;
      private int AV7SubprocessoId ;
      private int AV28SubProcessoId_Out ;
      private int trnEnded ;
      private int edtSubprocessoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSubprocessoId_Enabled ;
      private int edtSubprocessoId_Visible ;
      private int AV13Insert_ProcessoId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV34GXV1 ;
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
      private string edtSubprocessoNome_Internalname ;
      private string dynProcessoId_Internalname ;
      private string cmbSubprocessoAtivo_Internalname ;
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
      private string edtSubprocessoNome_Jsonclick ;
      private string dynProcessoId_Jsonclick ;
      private string cmbSubprocessoAtivo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSubprocessoId_Internalname ;
      private string edtSubprocessoId_Jsonclick ;
      private string AV33Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode7 ;
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
      private bool Z23SubprocessoAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n20SubprocessoId ;
      private bool n16ProcessoId ;
      private bool AV27IsSubProcesso ;
      private bool wbErr ;
      private bool A23SubprocessoAtivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV31IsOk ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i23SubprocessoAtivo ;
      private bool gxdyncontrolsrefreshing ;
      private bool GXt_boolean1 ;
      private bool ZV31IsOk ;
      private string Z21SubprocessoNome ;
      private string A21SubprocessoNome ;
      private string A17ProcessoNome ;
      private string Z17ProcessoNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynProcessoId ;
      private GXCombobox cmbSubprocessoAtivo ;
      private IDataStoreProvider pr_default ;
      private string[] T00074_A17ProcessoNome ;
      private int[] T00075_A20SubprocessoId ;
      private bool[] T00075_n20SubprocessoId ;
      private string[] T00075_A21SubprocessoNome ;
      private string[] T00075_A17ProcessoNome ;
      private bool[] T00075_A23SubprocessoAtivo ;
      private int[] T00075_A16ProcessoId ;
      private bool[] T00075_n16ProcessoId ;
      private string[] T00076_A17ProcessoNome ;
      private int[] T00077_A20SubprocessoId ;
      private bool[] T00077_n20SubprocessoId ;
      private int[] T00073_A20SubprocessoId ;
      private bool[] T00073_n20SubprocessoId ;
      private string[] T00073_A21SubprocessoNome ;
      private bool[] T00073_A23SubprocessoAtivo ;
      private int[] T00073_A16ProcessoId ;
      private bool[] T00073_n16ProcessoId ;
      private int[] T00078_A20SubprocessoId ;
      private bool[] T00078_n20SubprocessoId ;
      private int[] T00079_A20SubprocessoId ;
      private bool[] T00079_n20SubprocessoId ;
      private int[] T00072_A20SubprocessoId ;
      private bool[] T00072_n20SubprocessoId ;
      private string[] T00072_A21SubprocessoNome ;
      private bool[] T00072_A23SubprocessoAtivo ;
      private int[] T00072_A16ProcessoId ;
      private bool[] T00072_n16ProcessoId ;
      private int[] T000710_A20SubprocessoId ;
      private bool[] T000710_n20SubprocessoId ;
      private string[] T000713_A17ProcessoNome ;
      private int[] T000714_A75DocumentoId ;
      private int[] T000715_A20SubprocessoId ;
      private bool[] T000715_n20SubprocessoId ;
      private int[] T000716_A16ProcessoId ;
      private bool[] T000716_n16ProcessoId ;
      private string[] T000716_A17ProcessoNome ;
      private string[] T000717_A17ProcessoNome ;
      private bool aP2_IsSubProcesso ;
      private int aP3_SubProcessoId_Out ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
   }

   public class subprocesso__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class subprocesso__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new ParDef("@SubprocessoNome",GXType.NVarChar,100,0) ,
        new ParDef("@SubprocessoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        new ParDef("@SubprocessoNome",GXType.NVarChar,100,0) ,
        new ParDef("@SubprocessoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000712;
        prmT000712 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000713;
        prmT000713 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000714;
        prmT000714 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT000715;
        prmT000715 = new Object[] {
        };
        Object[] prmT000716;
        prmT000716 = new Object[] {
        };
        Object[] prmT000717;
        prmT000717 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT [SubprocessoId], [SubprocessoNome], [SubprocessoAtivo], [ProcessoId] FROM [SubProcesso] WITH (UPDLOCK) WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT [SubprocessoId], [SubprocessoNome], [SubprocessoAtivo], [ProcessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT [ProcessoNome] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT TM1.[SubprocessoId], TM1.[SubprocessoNome], T2.[ProcessoNome], TM1.[SubprocessoAtivo], TM1.[ProcessoId] FROM ([SubProcesso] TM1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = TM1.[ProcessoId]) WHERE TM1.[SubprocessoId] = @SubprocessoId ORDER BY TM1.[SubprocessoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT [ProcessoNome] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00077", "SELECT [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00078", "SELECT TOP 1 [SubprocessoId] FROM [SubProcesso] WHERE ( [SubprocessoId] > @SubprocessoId) ORDER BY [SubprocessoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00079", "SELECT TOP 1 [SubprocessoId] FROM [SubProcesso] WHERE ( [SubprocessoId] < @SubprocessoId) ORDER BY [SubprocessoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000710", "INSERT INTO [SubProcesso]([SubprocessoNome], [SubprocessoAtivo], [ProcessoId]) VALUES(@SubprocessoNome, @SubprocessoAtivo, @ProcessoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000711", "UPDATE [SubProcesso] SET [SubprocessoNome]=@SubprocessoNome, [SubprocessoAtivo]=@SubprocessoAtivo, [ProcessoId]=@ProcessoId  WHERE [SubprocessoId] = @SubprocessoId", GxErrorMask.GX_NOMASK,prmT000711)
           ,new CursorDef("T000712", "DELETE FROM [SubProcesso]  WHERE [SubprocessoId] = @SubprocessoId", GxErrorMask.GX_NOMASK,prmT000712)
           ,new CursorDef("T000713", "SELECT [ProcessoNome] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000714", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000715", "SELECT [SubprocessoId] FROM [SubProcesso] ORDER BY [SubprocessoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000716", "SELECT [ProcessoId], [ProcessoNome] FROM [Processo] ORDER BY [ProcessoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000717", "SELECT [ProcessoNome] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
