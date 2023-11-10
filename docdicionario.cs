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
   public class docdicionario : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
               AssignAttri(sPrefix, false, "AV7DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV7DocDicionarioId), 8, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV7DocDicionarioId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
            {
               A69InformacaoId = (int)(NumberUtil.Val( GetPar( "InformacaoId"), "."));
               AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_19( A69InformacaoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
            {
               A72HipoteseTratamentoId = (int)(NumberUtil.Val( GetPar( "HipoteseTratamentoId"), "."));
               AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_20( A72HipoteseTratamentoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
            {
               A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
               AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_21( A75DocumentoId) ;
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docdicionario.aspx")), "docdicionario.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docdicionario.aspx")))) ;
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
                     AV7DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
                     AssignAttri(sPrefix, false, "AV7DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV7DocDicionarioId), 8, 0));
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
               Form.Meta.addItem("description", "Doc Dicionario", 0) ;
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
            GX_FocusControl = dynInformacaoId_Internalname;
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

      public docdicionario( )
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

      public docdicionario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocDicionarioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocDicionarioId = aP1_DocDicionarioId;
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
         dynInformacaoId = new GXCombobox();
         chkDocDicionarioPodeEliminar = new GXCheckbox();
         chkDocDicionarioSensivel = new GXCheckbox();
         chkDocDicionarioTransfInter = new GXCheckbox();
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
            return "docdicionario_Execute" ;
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
         if ( dynInformacaoId.ItemCount > 0 )
         {
            A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInformacaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0));
            AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Values", dynInformacaoId.ToJavascriptSource(), true);
         }
         A100DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( A100DocDicionarioPodeEliminar));
         AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
         A99DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( A99DocDicionarioSensivel));
         AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
         A101DocDicionarioTransfInter = StringUtil.StrToBool( StringUtil.BoolToStr( A101DocDicionarioTransfInter));
         AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
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
            RenderHtmlCloseForm0W43( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "docdicionario.aspx");
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, sPrefix+"DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynInformacaoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynInformacaoId_Internalname, "Informacao", "col-sm-2 AttributeStepBulletLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
         AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynInformacaoId, dynInformacaoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0)), 1, dynInformacaoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynInformacaoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeStepBullet", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_DocDicionario.htm");
         dynInformacaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0));
         AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Values", (string)(dynInformacaoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocDicionarioPodeEliminar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkDocDicionarioPodeEliminar_Internalname, "Eliminar?", "col-sm-2 AttributeStepBulletLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeStepBullet";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocDicionarioPodeEliminar_Internalname, StringUtil.BoolToStr( A100DocDicionarioPodeEliminar), "", "Eliminar?", 1, chkDocDicionarioPodeEliminar.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocDicionarioSensivel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkDocDicionarioSensivel_Internalname, "Sensível?", "col-sm-2 AttributeStepBulletLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeStepBullet";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocDicionarioSensivel_Internalname, StringUtil.BoolToStr( A99DocDicionarioSensivel), "", "Sensível?", 1, chkDocDicionarioSensivel.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(32, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,32);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocDicionarioTransfInter_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkDocDicionarioTransfInter_Internalname, "Internacional", "col-sm-3 AttributeStepBulletLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeStepBullet";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocDicionarioTransfInter_Internalname, StringUtil.BoolToStr( A101DocDicionarioTransfInter), "", "Internacional", 1, chkDocDicionarioTransfInter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocDicionarioFinalidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocDicionarioFinalidade_Internalname, "Finalidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocDicionarioFinalidade_Internalname, A102DocDicionarioFinalidade, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtDocDicionarioFinalidade_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocDicionarioDataInclusao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocDicionarioDataInclusao_Internalname, "de Inclusão", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocDicionarioDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocDicionarioDataInclusao_Internalname, context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"), context.localUtil.Format( A103DocDicionarioDataInclusao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDicionarioDataInclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocDicionarioDataInclusao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocDicionario.htm");
         GxWebStd.gx_bitmap( context, edtDocDicionarioDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocDicionarioDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocDicionario.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedhipotesetratamentoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhipotesetratamentoid_Internalname, "Hipotese Tratamento", "", "", lblTextblockhipotesetratamentoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_hipotesetratamentoid.SetProperty("Caption", Combo_hipotesetratamentoid_Caption);
         ucCombo_hipotesetratamentoid.SetProperty("Cls", Combo_hipotesetratamentoid_Cls);
         ucCombo_hipotesetratamentoid.SetProperty("DataListProc", Combo_hipotesetratamentoid_Datalistproc);
         ucCombo_hipotesetratamentoid.SetProperty("DataListProcParametersPrefix", Combo_hipotesetratamentoid_Datalistprocparametersprefix);
         ucCombo_hipotesetratamentoid.SetProperty("EmptyItem", Combo_hipotesetratamentoid_Emptyitem);
         ucCombo_hipotesetratamentoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_hipotesetratamentoid.SetProperty("DropDownOptionsData", AV28HipoteseTratamentoId_Data);
         ucCombo_hipotesetratamentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_hipotesetratamentoid_Internalname, sPrefix+"COMBO_HIPOTESETRATAMENTOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHipoteseTratamentoId_Internalname, "Id da Hipótese de Tratamento", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHipoteseTratamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A72HipoteseTratamentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A72HipoteseTratamentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHipoteseTratamentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtHipoteseTratamentoId_Visible, edtHipoteseTratamentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocDicionario.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockdocumentoid_Internalname, "Documento", "", "", lblTextblockdocumentoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_documentoid.SetProperty("Caption", Combo_documentoid_Caption);
         ucCombo_documentoid.SetProperty("Cls", Combo_documentoid_Cls);
         ucCombo_documentoid.SetProperty("DataListProc", Combo_documentoid_Datalistproc);
         ucCombo_documentoid.SetProperty("DataListProcParametersPrefix", Combo_documentoid_Datalistprocparametersprefix);
         ucCombo_documentoid.SetProperty("EmptyItem", Combo_documentoid_Emptyitem);
         ucCombo_documentoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_documentoid.SetProperty("DropDownOptionsData", AV30DocumentoId_Data);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, edtDocumentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocDicionario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocDicionarioTipoTransfInterGa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocDicionarioTipoTransfInterGa_Internalname, "Transferência internacional", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocDicionarioTipoTransfInterGa_Internalname, A119DocDicionarioTipoTransfInterGa, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtDocDicionarioTipoTransfInterGa_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DocDicionario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionario.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_hipotesetratamentoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV29ComboHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0));
         GxWebStd.gx_single_line_edit( context, edtavCombohipotesetratamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombohipotesetratamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV29ComboHipoteseTratamentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV29ComboHipoteseTratamentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombohipotesetratamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombohipotesetratamentoid_Visible, edtavCombohipotesetratamentoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_documentoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV31ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV31ComboDocumentoId), 8, 0));
         GxWebStd.gx_single_line_edit( context, edtavCombodocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ComboDocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCombodocumentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31ComboDocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV31ComboDocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodocumentoid_Visible, edtavCombodocumentoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocDicionario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         GxWebStd.gx_single_line_edit( context, edtDocDicionarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ",", "")), StringUtil.LTrim( ((edtDocDicionarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDicionarioId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocDicionarioId_Visible, edtDocDicionarioId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocDicionario.htm");
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
         E110W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vHIPOTESETRATAMENTOID_DATA"), AV28HipoteseTratamentoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDOCUMENTOID_DATA"), AV30DocumentoId_Data);
               /* Read saved values. */
               Z98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z98DocDicionarioId"), ",", "."));
               Z99DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( sPrefix+"Z99DocDicionarioSensivel"));
               Z100DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( sPrefix+"Z100DocDicionarioPodeEliminar"));
               Z101DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( sPrefix+"Z101DocDicionarioTransfInter"));
               Z103DocDicionarioDataInclusao = context.localUtil.CToD( cgiGet( sPrefix+"Z103DocDicionarioDataInclusao"), 0);
               Z69InformacaoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z69InformacaoId"), ",", "."));
               Z72HipoteseTratamentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z72HipoteseTratamentoId"), ",", "."));
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z75DocumentoId"), ",", "."));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DocDicionarioId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N69InformacaoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N69InformacaoId"), ",", "."));
               N72HipoteseTratamentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N72HipoteseTratamentoId"), ",", "."));
               N75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N75DocumentoId"), ",", "."));
               AV7DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vDOCDICIONARIOID"), ",", "."));
               AV14Insert_InformacaoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_INFORMACAOID"), ",", "."));
               AV15Insert_HipoteseTratamentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_HIPOTESETRATAMENTOID"), ",", "."));
               AV13Insert_DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_DOCUMENTOID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."));
               A70InformacaoNome = cgiGet( sPrefix+"INFORMACAONOME");
               A73HipoteseTratamentoNome = cgiGet( sPrefix+"HIPOTESETRATAMENTONOME");
               A76DocumentoNome = cgiGet( sPrefix+"DOCUMENTONOME");
               n76DocumentoNome = false;
               AV33Pgmname = cgiGet( sPrefix+"vPGMNAME");
               Combo_hipotesetratamentoid_Objectcall = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Objectcall");
               Combo_hipotesetratamentoid_Class = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Class");
               Combo_hipotesetratamentoid_Icontype = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Icontype");
               Combo_hipotesetratamentoid_Icon = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Icon");
               Combo_hipotesetratamentoid_Caption = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Caption");
               Combo_hipotesetratamentoid_Tooltip = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Tooltip");
               Combo_hipotesetratamentoid_Cls = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Cls");
               Combo_hipotesetratamentoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectedvalue_set");
               Combo_hipotesetratamentoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectedvalue_get");
               Combo_hipotesetratamentoid_Selectedtext_set = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectedtext_set");
               Combo_hipotesetratamentoid_Selectedtext_get = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectedtext_get");
               Combo_hipotesetratamentoid_Gamoauthtoken = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Gamoauthtoken");
               Combo_hipotesetratamentoid_Ddointernalname = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Ddointernalname");
               Combo_hipotesetratamentoid_Titlecontrolalign = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Titlecontrolalign");
               Combo_hipotesetratamentoid_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Dropdownoptionstype");
               Combo_hipotesetratamentoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Enabled"));
               Combo_hipotesetratamentoid_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Visible"));
               Combo_hipotesetratamentoid_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Titlecontrolidtoreplace");
               Combo_hipotesetratamentoid_Datalisttype = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalisttype");
               Combo_hipotesetratamentoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Allowmultipleselection"));
               Combo_hipotesetratamentoid_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalistfixedvalues");
               Combo_hipotesetratamentoid_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Isgriditem"));
               Combo_hipotesetratamentoid_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Hasdescription"));
               Combo_hipotesetratamentoid_Datalistproc = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalistproc");
               Combo_hipotesetratamentoid_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalistprocparametersprefix");
               Combo_hipotesetratamentoid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_hipotesetratamentoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Includeonlyselectedoption"));
               Combo_hipotesetratamentoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Includeselectalloption"));
               Combo_hipotesetratamentoid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Emptyitem"));
               Combo_hipotesetratamentoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Includeaddnewoption"));
               Combo_hipotesetratamentoid_Htmltemplate = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Htmltemplate");
               Combo_hipotesetratamentoid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Multiplevaluestype");
               Combo_hipotesetratamentoid_Loadingdata = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Loadingdata");
               Combo_hipotesetratamentoid_Noresultsfound = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Noresultsfound");
               Combo_hipotesetratamentoid_Emptyitemtext = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Emptyitemtext");
               Combo_hipotesetratamentoid_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Onlyselectedvalues");
               Combo_hipotesetratamentoid_Selectalltext = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectalltext");
               Combo_hipotesetratamentoid_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Multiplevaluesseparator");
               Combo_hipotesetratamentoid_Addnewoptiontext = cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Addnewoptiontext");
               Combo_hipotesetratamentoid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_HIPOTESETRATAMENTOID_Gxcontroltype"), ",", "."));
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
               Dvpanel_tableattributes_Objectcall = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               dynInformacaoId.CurrentValue = cgiGet( dynInformacaoId_Internalname);
               A69InformacaoId = (int)(NumberUtil.Val( cgiGet( dynInformacaoId_Internalname), "."));
               AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
               A100DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkDocDicionarioPodeEliminar_Internalname));
               AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
               A99DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkDocDicionarioSensivel_Internalname));
               AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
               A101DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( chkDocDicionarioTransfInter_Internalname));
               AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
               A102DocDicionarioFinalidade = cgiGet( edtDocDicionarioFinalidade_Internalname);
               AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
               if ( context.localUtil.VCDate( cgiGet( edtDocDicionarioDataInclusao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de Inclusão"}), 1, "DOCDICIONARIODATAINCLUSAO");
                  AnyError = 1;
                  GX_FocusControl = edtDocDicionarioDataInclusao_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A103DocDicionarioDataInclusao = DateTime.MinValue;
                  AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
               }
               else
               {
                  A103DocDicionarioDataInclusao = context.localUtil.CToD( cgiGet( edtDocDicionarioDataInclusao_Internalname), 2);
                  AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtHipoteseTratamentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHipoteseTratamentoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HIPOTESETRATAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtHipoteseTratamentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A72HipoteseTratamentoId = 0;
                  AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
               }
               else
               {
                  A72HipoteseTratamentoId = (int)(context.localUtil.CToN( cgiGet( edtHipoteseTratamentoId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
               }
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
               A119DocDicionarioTipoTransfInterGa = cgiGet( edtDocDicionarioTipoTransfInterGa_Internalname);
               AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
               AV29ComboHipoteseTratamentoId = (int)(context.localUtil.CToN( cgiGet( edtavCombohipotesetratamentoid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV29ComboHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0));
               AV31ComboDocumentoId = (int)(context.localUtil.CToN( cgiGet( edtavCombodocumentoid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV31ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV31ComboDocumentoId), 8, 0));
               A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"DocDicionario");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A98DocDicionarioId != Z98DocDicionarioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("docdicionario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A98DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
                  AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
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
                     sMode43 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode43;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound43 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCDICIONARIOID");
                        AnyError = 1;
                        GX_FocusControl = edtDocDicionarioId_Internalname;
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
                                 E110W2 ();
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
                                 E120W2 ();
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
            E120W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0W43( ) ;
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
            DisableAttributes0W43( ) ;
         }
         AssignProp(sPrefix, false, chkDocDicionarioPodeEliminar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocDicionarioPodeEliminar.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocDicionarioSensivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocDicionarioSensivel.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocDicionarioTransfInter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocDicionarioTransfInter.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDocDicionarioFinalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioFinalidade_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDocDicionarioDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioDataInclusao_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDocDicionarioTipoTransfInterGa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioTipoTransfInterGa_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtavCombohipotesetratamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombohipotesetratamentoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W43( ) ;
            }
            else
            {
               CheckExtendedTable0W43( ) ;
               CloseExtendedTableCursors0W43( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0W0( )
      {
      }

      protected void E110W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV24GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV25GAMErrors);
         Combo_documentoid_Gamoauthtoken = AV24GAMSession.gxTpr_Token;
         ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "GAMOAuthToken", Combo_documentoid_Gamoauthtoken);
         edtDocumentoId_Visible = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), true);
         AV31ComboDocumentoId = 0;
         AssignAttri(sPrefix, false, "AV31ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV31ComboDocumentoId), 8, 0));
         edtavCombodocumentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavCombodocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Visible), 5, 0), true);
         Combo_hipotesetratamentoid_Gamoauthtoken = AV24GAMSession.gxTpr_Token;
         ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "GAMOAuthToken", Combo_hipotesetratamentoid_Gamoauthtoken);
         edtHipoteseTratamentoId_Visible = 0;
         AssignProp(sPrefix, false, edtHipoteseTratamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHipoteseTratamentoId_Visible), 5, 0), true);
         AV29ComboHipoteseTratamentoId = 0;
         AssignAttri(sPrefix, false, "AV29ComboHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0));
         edtavCombohipotesetratamentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavCombohipotesetratamentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombohipotesetratamentoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOHIPOTESETRATAMENTOID' */
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
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            AssignAttri(sPrefix, false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            while ( AV34GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "InformacaoId") == 0 )
               {
                  AV14Insert_InformacaoId = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV14Insert_InformacaoId", StringUtil.LTrimStr( (decimal)(AV14Insert_InformacaoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "HipoteseTratamentoId") == 0 )
               {
                  AV15Insert_HipoteseTratamentoId = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV15Insert_HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV15Insert_HipoteseTratamentoId), 8, 0));
                  if ( ! (0==AV15Insert_HipoteseTratamentoId) )
                  {
                     AV29ComboHipoteseTratamentoId = AV15Insert_HipoteseTratamentoId;
                     AssignAttri(sPrefix, false, "AV29ComboHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0));
                     Combo_hipotesetratamentoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0));
                     ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "SelectedValue_set", Combo_hipotesetratamentoid_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new docdicionarioloaddvcombo(context ).execute(  "HipoteseTratamentoId",  "GET",  false,  AV7DocDicionarioId,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri(sPrefix, false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri(sPrefix, false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri(sPrefix, false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_hipotesetratamentoid_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "SelectedText_set", Combo_hipotesetratamentoid_Selectedtext_set);
                     Combo_hipotesetratamentoid_Enabled = false;
                     ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_hipotesetratamentoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV13Insert_DocumentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DocumentoId), 8, 0));
                  if ( ! (0==AV13Insert_DocumentoId) )
                  {
                     AV31ComboDocumentoId = AV13Insert_DocumentoId;
                     AssignAttri(sPrefix, false, "AV31ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV31ComboDocumentoId), 8, 0));
                     Combo_documentoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV31ComboDocumentoId), 8, 0));
                     ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedValue_set", Combo_documentoid_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new docdicionarioloaddvcombo(context ).execute(  "DocumentoId",  "GET",  false,  AV7DocDicionarioId,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri(sPrefix, false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri(sPrefix, false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri(sPrefix, false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_documentoid_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedText_set", Combo_documentoid_Selectedtext_set);
                     Combo_documentoid_Enabled = false;
                     ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
                  }
               }
               AV34GXV1 = (int)(AV34GXV1+1);
               AssignAttri(sPrefix, false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            }
         }
         edtDocDicionarioId_Visible = 0;
         AssignProp(sPrefix, false, edtDocDicionarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Visible), 5, 0), true);
      }

      protected void E120W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("docdicionarioww.aspx") );
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
         GXt_char2 = AV22Combo_DataJson;
         new docdicionarioloaddvcombo(context ).execute(  "DocumentoId",  Gx_mode,  false,  AV7DocDicionarioId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_documentoid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedValue_set", Combo_documentoid_Selectedvalue_set);
         Combo_documentoid_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "SelectedText_set", Combo_documentoid_Selectedtext_set);
         AV31ComboDocumentoId = (int)(NumberUtil.Val( AV20ComboSelectedValue, "."));
         AssignAttri(sPrefix, false, "AV31ComboDocumentoId", StringUtil.LTrimStr( (decimal)(AV31ComboDocumentoId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_documentoid_Enabled = false;
            ucCombo_documentoid.SendProperty(context, sPrefix, false, Combo_documentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOHIPOTESETRATAMENTOID' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new docdicionarioloaddvcombo(context ).execute(  "HipoteseTratamentoId",  Gx_mode,  false,  AV7DocDicionarioId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_hipotesetratamentoid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "SelectedValue_set", Combo_hipotesetratamentoid_Selectedvalue_set);
         Combo_hipotesetratamentoid_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "SelectedText_set", Combo_hipotesetratamentoid_Selectedtext_set);
         AV29ComboHipoteseTratamentoId = (int)(NumberUtil.Val( AV20ComboSelectedValue, "."));
         AssignAttri(sPrefix, false, "AV29ComboHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV29ComboHipoteseTratamentoId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_hipotesetratamentoid_Enabled = false;
            ucCombo_hipotesetratamentoid.SendProperty(context, sPrefix, false, Combo_hipotesetratamentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_hipotesetratamentoid_Enabled));
         }
      }

      protected void ZM0W43( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z99DocDicionarioSensivel = T000W3_A99DocDicionarioSensivel[0];
               Z100DocDicionarioPodeEliminar = T000W3_A100DocDicionarioPodeEliminar[0];
               Z101DocDicionarioTransfInter = T000W3_A101DocDicionarioTransfInter[0];
               Z103DocDicionarioDataInclusao = T000W3_A103DocDicionarioDataInclusao[0];
               Z69InformacaoId = T000W3_A69InformacaoId[0];
               Z72HipoteseTratamentoId = T000W3_A72HipoteseTratamentoId[0];
               Z75DocumentoId = T000W3_A75DocumentoId[0];
            }
            else
            {
               Z99DocDicionarioSensivel = A99DocDicionarioSensivel;
               Z100DocDicionarioPodeEliminar = A100DocDicionarioPodeEliminar;
               Z101DocDicionarioTransfInter = A101DocDicionarioTransfInter;
               Z103DocDicionarioDataInclusao = A103DocDicionarioDataInclusao;
               Z69InformacaoId = A69InformacaoId;
               Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
               Z75DocumentoId = A75DocumentoId;
            }
         }
         if ( GX_JID == -18 )
         {
            Z98DocDicionarioId = A98DocDicionarioId;
            Z102DocDicionarioFinalidade = A102DocDicionarioFinalidade;
            Z119DocDicionarioTipoTransfInterGa = A119DocDicionarioTipoTransfInterGa;
            Z99DocDicionarioSensivel = A99DocDicionarioSensivel;
            Z100DocDicionarioPodeEliminar = A100DocDicionarioPodeEliminar;
            Z101DocDicionarioTransfInter = A101DocDicionarioTransfInter;
            Z103DocDicionarioDataInclusao = A103DocDicionarioDataInclusao;
            Z69InformacaoId = A69InformacaoId;
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
            Z75DocumentoId = A75DocumentoId;
            Z70InformacaoNome = A70InformacaoNome;
            Z73HipoteseTratamentoNome = A73HipoteseTratamentoNome;
            Z76DocumentoNome = A76DocumentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDocDicionarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
         AV33Pgmname = "DocDicionario";
         AssignAttri(sPrefix, false, "AV33Pgmname", AV33Pgmname);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtDocDicionarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7DocDicionarioId) )
         {
            A98DocDicionarioId = AV7DocDicionarioId;
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_InformacaoId) )
         {
            dynInformacaoId.Enabled = 0;
            AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInformacaoId.Enabled), 5, 0), true);
         }
         else
         {
            dynInformacaoId.Enabled = 1;
            AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInformacaoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_HipoteseTratamentoId) )
         {
            edtHipoteseTratamentoId_Enabled = 0;
            AssignProp(sPrefix, false, edtHipoteseTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHipoteseTratamentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtHipoteseTratamentoId_Enabled = 1;
            AssignProp(sPrefix, false, edtHipoteseTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHipoteseTratamentoId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_InformacaoId) )
         {
            A69InformacaoId = AV14Insert_InformacaoId;
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_HipoteseTratamentoId) )
         {
            A72HipoteseTratamentoId = AV15Insert_HipoteseTratamentoId;
            AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
         }
         else
         {
            A72HipoteseTratamentoId = AV29ComboHipoteseTratamentoId;
            AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            A75DocumentoId = AV13Insert_DocumentoId;
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         else
         {
            A75DocumentoId = AV31ComboDocumentoId;
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
         if ( IsIns( )  && (DateTime.MinValue==A103DocDicionarioDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000W4 */
            pr_default.execute(2, new Object[] {A69InformacaoId});
            A70InformacaoNome = T000W4_A70InformacaoNome[0];
            pr_default.close(2);
            /* Using cursor T000W5 */
            pr_default.execute(3, new Object[] {A72HipoteseTratamentoId});
            A73HipoteseTratamentoNome = T000W5_A73HipoteseTratamentoNome[0];
            pr_default.close(3);
            /* Using cursor T000W6 */
            pr_default.execute(4, new Object[] {A75DocumentoId});
            A76DocumentoNome = T000W6_A76DocumentoNome[0];
            n76DocumentoNome = T000W6_n76DocumentoNome[0];
            pr_default.close(4);
         }
      }

      protected void Load0W43( )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound43 = 1;
            A102DocDicionarioFinalidade = T000W7_A102DocDicionarioFinalidade[0];
            AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
            A119DocDicionarioTipoTransfInterGa = T000W7_A119DocDicionarioTipoTransfInterGa[0];
            AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
            A99DocDicionarioSensivel = T000W7_A99DocDicionarioSensivel[0];
            AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
            A100DocDicionarioPodeEliminar = T000W7_A100DocDicionarioPodeEliminar[0];
            AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
            A101DocDicionarioTransfInter = T000W7_A101DocDicionarioTransfInter[0];
            AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
            A103DocDicionarioDataInclusao = T000W7_A103DocDicionarioDataInclusao[0];
            AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
            A70InformacaoNome = T000W7_A70InformacaoNome[0];
            A73HipoteseTratamentoNome = T000W7_A73HipoteseTratamentoNome[0];
            A76DocumentoNome = T000W7_A76DocumentoNome[0];
            n76DocumentoNome = T000W7_n76DocumentoNome[0];
            A69InformacaoId = T000W7_A69InformacaoId[0];
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
            A72HipoteseTratamentoId = T000W7_A72HipoteseTratamentoId[0];
            AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
            A75DocumentoId = T000W7_A75DocumentoId[0];
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            ZM0W43( -18) ;
         }
         pr_default.close(5);
         OnLoadActions0W43( ) ;
      }

      protected void OnLoadActions0W43( )
      {
         A102DocDicionarioFinalidade = StringUtil.Upper( A102DocDicionarioFinalidade);
         AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
         A119DocDicionarioTipoTransfInterGa = StringUtil.Upper( A119DocDicionarioTipoTransfInterGa);
         AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
      }

      protected void CheckExtendedTable0W43( )
      {
         nIsDirty_43 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000W4 */
         pr_default.execute(2, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Informacao'.", "ForeignKeyNotFound", 1, "INFORMACAOID");
            AnyError = 1;
            GX_FocusControl = dynInformacaoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A70InformacaoNome = T000W4_A70InformacaoNome[0];
         pr_default.close(2);
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Hipotese Tratamento'.", "ForeignKeyNotFound", 1, "HIPOTESETRATAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtHipoteseTratamentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A73HipoteseTratamentoNome = T000W5_A73HipoteseTratamentoNome[0];
         pr_default.close(3);
         nIsDirty_43 = 1;
         A102DocDicionarioFinalidade = StringUtil.Upper( A102DocDicionarioFinalidade);
         AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
         if ( ! ( (DateTime.MinValue==A103DocDicionarioDataInclusao) || ( DateTimeUtil.ResetTime ( A103DocDicionarioDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Data de Inclusão fora do intervalo", "OutOfRange", 1, "DOCDICIONARIODATAINCLUSAO");
            AnyError = 1;
            GX_FocusControl = edtDocDicionarioDataInclusao_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000W6 */
         pr_default.execute(4, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A76DocumentoNome = T000W6_A76DocumentoNome[0];
         n76DocumentoNome = T000W6_n76DocumentoNome[0];
         pr_default.close(4);
         nIsDirty_43 = 1;
         A119DocDicionarioTipoTransfInterGa = StringUtil.Upper( A119DocDicionarioTipoTransfInterGa);
         AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
      }

      protected void CloseExtendedTableCursors0W43( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( int A69InformacaoId )
      {
         /* Using cursor T000W8 */
         pr_default.execute(6, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Informacao'.", "ForeignKeyNotFound", 1, "INFORMACAOID");
            AnyError = 1;
            GX_FocusControl = dynInformacaoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A70InformacaoNome = T000W8_A70InformacaoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A70InformacaoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_20( int A72HipoteseTratamentoId )
      {
         /* Using cursor T000W9 */
         pr_default.execute(7, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Hipotese Tratamento'.", "ForeignKeyNotFound", 1, "HIPOTESETRATAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtHipoteseTratamentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A73HipoteseTratamentoNome = T000W9_A73HipoteseTratamentoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A73HipoteseTratamentoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_21( int A75DocumentoId )
      {
         /* Using cursor T000W10 */
         pr_default.execute(8, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A76DocumentoNome = T000W10_A76DocumentoNome[0];
         n76DocumentoNome = T000W10_n76DocumentoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A76DocumentoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0W43( )
      {
         /* Using cursor T000W11 */
         pr_default.execute(9, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W43( 18) ;
            RcdFound43 = 1;
            A98DocDicionarioId = T000W3_A98DocDicionarioId[0];
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
            A102DocDicionarioFinalidade = T000W3_A102DocDicionarioFinalidade[0];
            AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
            A119DocDicionarioTipoTransfInterGa = T000W3_A119DocDicionarioTipoTransfInterGa[0];
            AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
            A99DocDicionarioSensivel = T000W3_A99DocDicionarioSensivel[0];
            AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
            A100DocDicionarioPodeEliminar = T000W3_A100DocDicionarioPodeEliminar[0];
            AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
            A101DocDicionarioTransfInter = T000W3_A101DocDicionarioTransfInter[0];
            AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
            A103DocDicionarioDataInclusao = T000W3_A103DocDicionarioDataInclusao[0];
            AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
            A69InformacaoId = T000W3_A69InformacaoId[0];
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
            A72HipoteseTratamentoId = T000W3_A72HipoteseTratamentoId[0];
            AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
            A75DocumentoId = T000W3_A75DocumentoId[0];
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            Z98DocDicionarioId = A98DocDicionarioId;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0W43( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey0W43( ) ;
            }
            Gx_mode = sMode43;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey0W43( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode43;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W43( ) ;
         if ( RcdFound43 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound43 = 0;
         /* Using cursor T000W12 */
         pr_default.execute(10, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000W12_A98DocDicionarioId[0] < A98DocDicionarioId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000W12_A98DocDicionarioId[0] > A98DocDicionarioId ) ) )
            {
               A98DocDicionarioId = T000W12_A98DocDicionarioId[0];
               AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               RcdFound43 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound43 = 0;
         /* Using cursor T000W13 */
         pr_default.execute(11, new Object[] {A98DocDicionarioId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000W13_A98DocDicionarioId[0] > A98DocDicionarioId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000W13_A98DocDicionarioId[0] < A98DocDicionarioId ) ) )
            {
               A98DocDicionarioId = T000W13_A98DocDicionarioId[0];
               AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
               RcdFound43 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W43( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynInformacaoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0W43( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( A98DocDicionarioId != Z98DocDicionarioId )
               {
                  A98DocDicionarioId = Z98DocDicionarioId;
                  AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCDICIONARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocDicionarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynInformacaoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0W43( ) ;
                  GX_FocusControl = dynInformacaoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A98DocDicionarioId != Z98DocDicionarioId )
               {
                  /* Insert record */
                  GX_FocusControl = dynInformacaoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0W43( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCDICIONARIOID");
                     AnyError = 1;
                     GX_FocusControl = edtDocDicionarioId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynInformacaoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0W43( ) ;
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
         if ( A98DocDicionarioId != Z98DocDicionarioId )
         {
            A98DocDicionarioId = Z98DocDicionarioId;
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCDICIONARIOID");
            AnyError = 1;
            GX_FocusControl = edtDocDicionarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynInformacaoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0W43( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocDicionario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z99DocDicionarioSensivel != T000W2_A99DocDicionarioSensivel[0] ) || ( Z100DocDicionarioPodeEliminar != T000W2_A100DocDicionarioPodeEliminar[0] ) || ( Z101DocDicionarioTransfInter != T000W2_A101DocDicionarioTransfInter[0] ) || ( DateTimeUtil.ResetTime ( Z103DocDicionarioDataInclusao ) != DateTimeUtil.ResetTime ( T000W2_A103DocDicionarioDataInclusao[0] ) ) || ( Z69InformacaoId != T000W2_A69InformacaoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z72HipoteseTratamentoId != T000W2_A72HipoteseTratamentoId[0] ) || ( Z75DocumentoId != T000W2_A75DocumentoId[0] ) )
            {
               if ( Z99DocDicionarioSensivel != T000W2_A99DocDicionarioSensivel[0] )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"DocDicionarioSensivel");
                  GXUtil.WriteLogRaw("Old: ",Z99DocDicionarioSensivel);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A99DocDicionarioSensivel[0]);
               }
               if ( Z100DocDicionarioPodeEliminar != T000W2_A100DocDicionarioPodeEliminar[0] )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"DocDicionarioPodeEliminar");
                  GXUtil.WriteLogRaw("Old: ",Z100DocDicionarioPodeEliminar);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A100DocDicionarioPodeEliminar[0]);
               }
               if ( Z101DocDicionarioTransfInter != T000W2_A101DocDicionarioTransfInter[0] )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"DocDicionarioTransfInter");
                  GXUtil.WriteLogRaw("Old: ",Z101DocDicionarioTransfInter);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A101DocDicionarioTransfInter[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z103DocDicionarioDataInclusao ) != DateTimeUtil.ResetTime ( T000W2_A103DocDicionarioDataInclusao[0] ) )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"DocDicionarioDataInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z103DocDicionarioDataInclusao);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A103DocDicionarioDataInclusao[0]);
               }
               if ( Z69InformacaoId != T000W2_A69InformacaoId[0] )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"InformacaoId");
                  GXUtil.WriteLogRaw("Old: ",Z69InformacaoId);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A69InformacaoId[0]);
               }
               if ( Z72HipoteseTratamentoId != T000W2_A72HipoteseTratamentoId[0] )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"HipoteseTratamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z72HipoteseTratamentoId);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A72HipoteseTratamentoId[0]);
               }
               if ( Z75DocumentoId != T000W2_A75DocumentoId[0] )
               {
                  GXUtil.WriteLog("docdicionario:[seudo value changed for attri]"+"DocumentoId");
                  GXUtil.WriteLogRaw("Old: ",Z75DocumentoId);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A75DocumentoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocDicionario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W43( )
      {
         if ( ! IsAuthorized("docdicionario_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W43( 0) ;
            CheckOptimisticConcurrency0W43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W14 */
                     pr_default.execute(12, new Object[] {A102DocDicionarioFinalidade, A119DocDicionarioTipoTransfInterGa, A99DocDicionarioSensivel, A100DocDicionarioPodeEliminar, A101DocDicionarioTransfInter, A103DocDicionarioDataInclusao, A69InformacaoId, A72HipoteseTratamentoId, A75DocumentoId});
                     A98DocDicionarioId = T000W14_A98DocDicionarioId[0];
                     AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("DocDicionario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0W0( ) ;
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
               Load0W43( ) ;
            }
            EndLevel0W43( ) ;
         }
         CloseExtendedTableCursors0W43( ) ;
      }

      protected void Update0W43( )
      {
         if ( ! IsAuthorized("docdicionario_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W15 */
                     pr_default.execute(13, new Object[] {A102DocDicionarioFinalidade, A119DocDicionarioTipoTransfInterGa, A99DocDicionarioSensivel, A100DocDicionarioPodeEliminar, A101DocDicionarioTransfInter, A103DocDicionarioDataInclusao, A69InformacaoId, A72HipoteseTratamentoId, A75DocumentoId, A98DocDicionarioId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("DocDicionario");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocDicionario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W43( ) ;
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
            EndLevel0W43( ) ;
         }
         CloseExtendedTableCursors0W43( ) ;
      }

      protected void DeferredUpdate0W43( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("docdicionario_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W43( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W43( ) ;
            AfterConfirm0W43( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W43( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W16 */
                  pr_default.execute(14, new Object[] {A98DocDicionarioId});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("DocDicionario");
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0W43( ) ;
         Gx_mode = sMode43;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W43( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000W17 */
            pr_default.execute(15, new Object[] {A69InformacaoId});
            A70InformacaoNome = T000W17_A70InformacaoNome[0];
            pr_default.close(15);
            /* Using cursor T000W18 */
            pr_default.execute(16, new Object[] {A72HipoteseTratamentoId});
            A73HipoteseTratamentoNome = T000W18_A73HipoteseTratamentoNome[0];
            pr_default.close(16);
            /* Using cursor T000W19 */
            pr_default.execute(17, new Object[] {A75DocumentoId});
            A76DocumentoNome = T000W19_A76DocumentoNome[0];
            n76DocumentoNome = T000W19_n76DocumentoNome[0];
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000W20 */
            pr_default.execute(18, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DicionarioPais"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000W21 */
            pr_default.execute(19, new Object[] {A98DocDicionarioId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DicionarioCompartTercExt"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel0W43( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W43( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("docdicionario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.RollbackDataStores("docdicionario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W43( )
      {
         /* Scan By routine */
         /* Using cursor T000W22 */
         pr_default.execute(20);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound43 = 1;
            A98DocDicionarioId = T000W22_A98DocDicionarioId[0];
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W43( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound43 = 1;
            A98DocDicionarioId = T000W22_A98DocDicionarioId[0];
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
      }

      protected void ScanEnd0W43( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0W43( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W43( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W43( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W43( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W43( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W43( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W43( )
      {
         dynInformacaoId.Enabled = 0;
         AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInformacaoId.Enabled), 5, 0), true);
         chkDocDicionarioPodeEliminar.Enabled = 0;
         AssignProp(sPrefix, false, chkDocDicionarioPodeEliminar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocDicionarioPodeEliminar.Enabled), 5, 0), true);
         chkDocDicionarioSensivel.Enabled = 0;
         AssignProp(sPrefix, false, chkDocDicionarioSensivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocDicionarioSensivel.Enabled), 5, 0), true);
         chkDocDicionarioTransfInter.Enabled = 0;
         AssignProp(sPrefix, false, chkDocDicionarioTransfInter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocDicionarioTransfInter.Enabled), 5, 0), true);
         edtDocDicionarioFinalidade_Enabled = 0;
         AssignProp(sPrefix, false, edtDocDicionarioFinalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioFinalidade_Enabled), 5, 0), true);
         edtDocDicionarioDataInclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtDocDicionarioDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioDataInclusao_Enabled), 5, 0), true);
         edtHipoteseTratamentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtHipoteseTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHipoteseTratamentoId_Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtDocDicionarioTipoTransfInterGa_Enabled = 0;
         AssignProp(sPrefix, false, edtDocDicionarioTipoTransfInterGa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioTipoTransfInterGa_Enabled), 5, 0), true);
         edtavCombohipotesetratamentoid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombohipotesetratamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombohipotesetratamentoid_Enabled), 5, 0), true);
         edtavCombodocumentoid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentoid_Enabled), 5, 0), true);
         edtDocDicionarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocDicionarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0W43( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0W0( )
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
            context.SendWebValue( "Doc Dicionario") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GXEncryptionTmp = "docdicionario.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocDicionarioId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docdicionario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"DocDicionario");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("docdicionario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z98DocDicionarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98DocDicionarioId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z99DocDicionarioSensivel", Z99DocDicionarioSensivel);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z100DocDicionarioPodeEliminar", Z100DocDicionarioPodeEliminar);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z101DocDicionarioTransfInter", Z101DocDicionarioTransfInter);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z103DocDicionarioDataInclusao", context.localUtil.DToC( Z103DocDicionarioDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z69InformacaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69InformacaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z72HipoteseTratamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72HipoteseTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7DocDicionarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7DocDicionarioId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N69InformacaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69InformacaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N72HipoteseTratamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72HipoteseTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vHIPOTESETRATAMENTOID_DATA", AV28HipoteseTratamentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vHIPOTESETRATAMENTOID_DATA", AV28HipoteseTratamentoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCUMENTOID_DATA", AV30DocumentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCUMENTOID_DATA", AV30DocumentoId_Data);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCDICIONARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocDicionarioId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_INFORMACAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_InformacaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_HIPOTESETRATAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_HipoteseTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"INFORMACAONOME", A70InformacaoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"HIPOTESETRATAMENTONOME", A73HipoteseTratamentoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTONOME", A76DocumentoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Objectcall", StringUtil.RTrim( Combo_hipotesetratamentoid_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Cls", StringUtil.RTrim( Combo_hipotesetratamentoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_hipotesetratamentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Selectedtext_set", StringUtil.RTrim( Combo_hipotesetratamentoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Gamoauthtoken", StringUtil.RTrim( Combo_hipotesetratamentoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Enabled", StringUtil.BoolToStr( Combo_hipotesetratamentoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalistproc", StringUtil.RTrim( Combo_hipotesetratamentoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_hipotesetratamentoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_HIPOTESETRATAMENTOID_Emptyitem", StringUtil.BoolToStr( Combo_hipotesetratamentoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Objectcall", StringUtil.RTrim( Combo_documentoid_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Cls", StringUtil.RTrim( Combo_documentoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_documentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Selectedtext_set", StringUtil.RTrim( Combo_documentoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Gamoauthtoken", StringUtil.RTrim( Combo_documentoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Enabled", StringUtil.BoolToStr( Combo_documentoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Datalistproc", StringUtil.RTrim( Combo_documentoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_documentoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DOCUMENTOID_Emptyitem", StringUtil.BoolToStr( Combo_documentoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      protected void RenderHtmlCloseForm0W43( )
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
         return "DocDicionario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Dicionario" ;
      }

      protected void InitializeNonKey0W43( )
      {
         A69InformacaoId = 0;
         AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
         A72HipoteseTratamentoId = 0;
         AssignAttri(sPrefix, false, "A72HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(A72HipoteseTratamentoId), 8, 0));
         A75DocumentoId = 0;
         AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         A102DocDicionarioFinalidade = "";
         AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
         A119DocDicionarioTipoTransfInterGa = "";
         AssignAttri(sPrefix, false, "A119DocDicionarioTipoTransfInterGa", A119DocDicionarioTipoTransfInterGa);
         A99DocDicionarioSensivel = false;
         AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
         A100DocDicionarioPodeEliminar = false;
         AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
         A101DocDicionarioTransfInter = false;
         AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
         A70InformacaoNome = "";
         AssignAttri(sPrefix, false, "A70InformacaoNome", A70InformacaoNome);
         A73HipoteseTratamentoNome = "";
         AssignAttri(sPrefix, false, "A73HipoteseTratamentoNome", A73HipoteseTratamentoNome);
         A76DocumentoNome = "";
         n76DocumentoNome = false;
         AssignAttri(sPrefix, false, "A76DocumentoNome", A76DocumentoNome);
         A103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
         Z99DocDicionarioSensivel = false;
         Z100DocDicionarioPodeEliminar = false;
         Z101DocDicionarioTransfInter = false;
         Z103DocDicionarioDataInclusao = DateTime.MinValue;
         Z69InformacaoId = 0;
         Z72HipoteseTratamentoId = 0;
         Z75DocumentoId = 0;
      }

      protected void InitAll0W43( )
      {
         A98DocDicionarioId = 0;
         AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         InitializeNonKey0W43( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A103DocDicionarioDataInclusao = i103DocDicionarioDataInclusao;
         AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7DocDicionarioId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "docdicionario", GetJustCreated( ));
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
            AV7DocDicionarioId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV7DocDicionarioId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DocDicionarioId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7DocDicionarioId != wcpOAV7DocDicionarioId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7DocDicionarioId = AV7DocDicionarioId;
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
         sCtrlAV7DocDicionarioId = cgiGet( sPrefix+"AV7DocDicionarioId_CTRL");
         if ( StringUtil.Len( sCtrlAV7DocDicionarioId) > 0 )
         {
            AV7DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV7DocDicionarioId), ",", "."));
            AssignAttri(sPrefix, false, "AV7DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV7DocDicionarioId), 8, 0));
         }
         else
         {
            AV7DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV7DocDicionarioId_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7DocDicionarioId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocDicionarioId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7DocDicionarioId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7DocDicionarioId_CTRL", StringUtil.RTrim( sCtrlAV7DocDicionarioId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417263074", true, true);
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
         context.AddJavascriptSource("docdicionario.js", "?202312417263075", false, true);
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
         dynInformacaoId_Internalname = sPrefix+"INFORMACAOID";
         chkDocDicionarioPodeEliminar_Internalname = sPrefix+"DOCDICIONARIOPODEELIMINAR";
         chkDocDicionarioSensivel_Internalname = sPrefix+"DOCDICIONARIOSENSIVEL";
         chkDocDicionarioTransfInter_Internalname = sPrefix+"DOCDICIONARIOTRANSFINTER";
         edtDocDicionarioFinalidade_Internalname = sPrefix+"DOCDICIONARIOFINALIDADE";
         edtDocDicionarioDataInclusao_Internalname = sPrefix+"DOCDICIONARIODATAINCLUSAO";
         lblTextblockhipotesetratamentoid_Internalname = sPrefix+"TEXTBLOCKHIPOTESETRATAMENTOID";
         Combo_hipotesetratamentoid_Internalname = sPrefix+"COMBO_HIPOTESETRATAMENTOID";
         edtHipoteseTratamentoId_Internalname = sPrefix+"HIPOTESETRATAMENTOID";
         divTablesplittedhipotesetratamentoid_Internalname = sPrefix+"TABLESPLITTEDHIPOTESETRATAMENTOID";
         lblTextblockdocumentoid_Internalname = sPrefix+"TEXTBLOCKDOCUMENTOID";
         Combo_documentoid_Internalname = sPrefix+"COMBO_DOCUMENTOID";
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID";
         divTablesplitteddocumentoid_Internalname = sPrefix+"TABLESPLITTEDDOCUMENTOID";
         edtDocDicionarioTipoTransfInterGa_Internalname = sPrefix+"DOCDICIONARIOTIPOTRANSFINTERGA";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCombohipotesetratamentoid_Internalname = sPrefix+"vCOMBOHIPOTESETRATAMENTOID";
         divSectionattribute_hipotesetratamentoid_Internalname = sPrefix+"SECTIONATTRIBUTE_HIPOTESETRATAMENTOID";
         edtavCombodocumentoid_Internalname = sPrefix+"vCOMBODOCUMENTOID";
         divSectionattribute_documentoid_Internalname = sPrefix+"SECTIONATTRIBUTE_DOCUMENTOID";
         edtDocDicionarioId_Internalname = sPrefix+"DOCDICIONARIOID";
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
         edtDocDicionarioId_Jsonclick = "";
         edtDocDicionarioId_Enabled = 0;
         edtDocDicionarioId_Visible = 1;
         edtavCombodocumentoid_Jsonclick = "";
         edtavCombodocumentoid_Enabled = 0;
         edtavCombodocumentoid_Visible = 1;
         edtavCombohipotesetratamentoid_Jsonclick = "";
         edtavCombohipotesetratamentoid_Enabled = 0;
         edtavCombohipotesetratamentoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocDicionarioTipoTransfInterGa_Enabled = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 1;
         edtDocumentoId_Visible = 1;
         Combo_documentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_documentoid_Datalistprocparametersprefix = " \"ComboName\": \"DocumentoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"DocDicionarioId\": 0";
         Combo_documentoid_Datalistproc = "DocDicionarioLoadDVCombo";
         Combo_documentoid_Cls = "ExtendedCombo AttributeFL";
         Combo_documentoid_Caption = "";
         Combo_documentoid_Enabled = Convert.ToBoolean( -1);
         edtHipoteseTratamentoId_Jsonclick = "";
         edtHipoteseTratamentoId_Enabled = 1;
         edtHipoteseTratamentoId_Visible = 1;
         Combo_hipotesetratamentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_hipotesetratamentoid_Datalistprocparametersprefix = " \"ComboName\": \"HipoteseTratamentoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"DocDicionarioId\": 0";
         Combo_hipotesetratamentoid_Datalistproc = "DocDicionarioLoadDVCombo";
         Combo_hipotesetratamentoid_Cls = "ExtendedCombo AttributeFL";
         Combo_hipotesetratamentoid_Caption = "";
         Combo_hipotesetratamentoid_Enabled = Convert.ToBoolean( -1);
         edtDocDicionarioDataInclusao_Jsonclick = "";
         edtDocDicionarioDataInclusao_Enabled = 1;
         edtDocDicionarioFinalidade_Enabled = 1;
         chkDocDicionarioTransfInter.Enabled = 1;
         chkDocDicionarioSensivel.Enabled = 1;
         chkDocDicionarioPodeEliminar.Enabled = 1;
         dynInformacaoId_Jsonclick = "";
         dynInformacaoId.Enabled = 1;
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

      protected void GXDLAINFORMACAOID0W1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINFORMACAOID_data0W1( ) ;
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

      protected void GXAINFORMACAOID_html0W1( )
      {
         int gxdynajaxvalue;
         GXDLAINFORMACAOID_data0W1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynInformacaoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynInformacaoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAINFORMACAOID_data0W1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000W23 */
         pr_default.execute(21);
         while ( (pr_default.getStatus(21) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000W23_A24AreaResponsavelId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000W23_A25AreaResponsavelNome[0]);
            pr_default.readNext(21);
         }
         pr_default.close(21);
      }

      protected void init_web_controls( )
      {
         dynInformacaoId.Name = "INFORMACAOID";
         dynInformacaoId.WebTags = "";
         dynInformacaoId.removeAllItems();
         /* Using cursor T000W24 */
         pr_default.execute(22);
         while ( (pr_default.getStatus(22) != 101) )
         {
            dynInformacaoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000W24_A24AreaResponsavelId[0]), 8, 0)), T000W24_A25AreaResponsavelNome[0], 0);
            pr_default.readNext(22);
         }
         pr_default.close(22);
         if ( dynInformacaoId.ItemCount > 0 )
         {
         }
         chkDocDicionarioPodeEliminar.Name = "DOCDICIONARIOPODEELIMINAR";
         chkDocDicionarioPodeEliminar.WebTags = "";
         chkDocDicionarioPodeEliminar.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioPodeEliminar_Internalname, "TitleCaption", chkDocDicionarioPodeEliminar.Caption, true);
         chkDocDicionarioPodeEliminar.CheckedValue = "false";
         chkDocDicionarioSensivel.Name = "DOCDICIONARIOSENSIVEL";
         chkDocDicionarioSensivel.WebTags = "";
         chkDocDicionarioSensivel.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioSensivel_Internalname, "TitleCaption", chkDocDicionarioSensivel.Caption, true);
         chkDocDicionarioSensivel.CheckedValue = "false";
         chkDocDicionarioTransfInter.Name = "DOCDICIONARIOTRANSFINTER";
         chkDocDicionarioTransfInter.WebTags = "";
         chkDocDicionarioTransfInter.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioTransfInter_Internalname, "TitleCaption", chkDocDicionarioTransfInter.Caption, true);
         chkDocDicionarioTransfInter.CheckedValue = "false";
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

      public void Valid_Informacaoid( )
      {
         A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.CurrentValue, "."));
         /* Using cursor T000W17 */
         pr_default.execute(15, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'Informacao'.", "ForeignKeyNotFound", 1, "INFORMACAOID");
            AnyError = 1;
            GX_FocusControl = dynInformacaoId_Internalname;
         }
         A70InformacaoNome = T000W17_A70InformacaoNome[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A70InformacaoNome", A70InformacaoNome);
      }

      public void Valid_Hipotesetratamentoid( )
      {
         A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.CurrentValue, "."));
         /* Using cursor T000W18 */
         pr_default.execute(16, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'Hipotese Tratamento'.", "ForeignKeyNotFound", 1, "HIPOTESETRATAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtHipoteseTratamentoId_Internalname;
         }
         A73HipoteseTratamentoNome = T000W18_A73HipoteseTratamentoNome[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A73HipoteseTratamentoNome", A73HipoteseTratamentoNome);
      }

      public void Valid_Documentoid( )
      {
         A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.CurrentValue, "."));
         n76DocumentoNome = false;
         /* Using cursor T000W19 */
         pr_default.execute(17, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
         }
         A76DocumentoNome = T000W19_A76DocumentoNome[0];
         n76DocumentoNome = T000W19_n76DocumentoNome[0];
         pr_default.close(17);
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120W2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_INFORMACAOID","{handler:'Valid_Informacaoid',iparms:[{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_INFORMACAOID",",oparms:[{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_DOCDICIONARIOFINALIDADE","{handler:'Valid_Docdicionariofinalidade',iparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_DOCDICIONARIOFINALIDADE",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_DOCDICIONARIODATAINCLUSAO","{handler:'Valid_Docdicionariodatainclusao',iparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_DOCDICIONARIODATAINCLUSAO",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_HIPOTESETRATAMENTOID","{handler:'Valid_Hipotesetratamentoid',iparms:[{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_HIPOTESETRATAMENTOID",",oparms:[{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A76DocumentoNome',fld:'DOCUMENTONOME',pic:''},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[{av:'A76DocumentoNome',fld:'DOCUMENTONOME',pic:''},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_DOCDICIONARIOTIPOTRANSFINTERGA","{handler:'Valid_Docdicionariotipotransfinterga',iparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_DOCDICIONARIOTIPOTRANSFINTERGA",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALIDV_COMBOHIPOTESETRATAMENTOID","{handler:'Validv_Combohipotesetratamentoid',iparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALIDV_COMBOHIPOTESETRATAMENTOID",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALIDV_COMBODOCUMENTOID","{handler:'Validv_Combodocumentoid',iparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALIDV_COMBODOCUMENTOID",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
         setEventMetadata("VALID_DOCDICIONARIOID","{handler:'Valid_Docdicionarioid',iparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VALID_DOCDICIONARIOID",",oparms:[{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''}]}");
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
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z103DocDicionarioDataInclusao = DateTime.MinValue;
         Combo_documentoid_Selectedvalue_get = "";
         Combo_hipotesetratamentoid_Selectedvalue_get = "";
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
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A102DocDicionarioFinalidade = "";
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         lblTextblockhipotesetratamentoid_Jsonclick = "";
         ucCombo_hipotesetratamentoid = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV28HipoteseTratamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockdocumentoid_Jsonclick = "";
         ucCombo_documentoid = new GXUserControl();
         AV30DocumentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A119DocDicionarioTipoTransfInterGa = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A76DocumentoNome = "";
         AV33Pgmname = "";
         Combo_hipotesetratamentoid_Objectcall = "";
         Combo_hipotesetratamentoid_Class = "";
         Combo_hipotesetratamentoid_Icontype = "";
         Combo_hipotesetratamentoid_Icon = "";
         Combo_hipotesetratamentoid_Tooltip = "";
         Combo_hipotesetratamentoid_Selectedvalue_set = "";
         Combo_hipotesetratamentoid_Selectedtext_set = "";
         Combo_hipotesetratamentoid_Selectedtext_get = "";
         Combo_hipotesetratamentoid_Gamoauthtoken = "";
         Combo_hipotesetratamentoid_Ddointernalname = "";
         Combo_hipotesetratamentoid_Titlecontrolalign = "";
         Combo_hipotesetratamentoid_Dropdownoptionstype = "";
         Combo_hipotesetratamentoid_Titlecontrolidtoreplace = "";
         Combo_hipotesetratamentoid_Datalisttype = "";
         Combo_hipotesetratamentoid_Datalistfixedvalues = "";
         Combo_hipotesetratamentoid_Htmltemplate = "";
         Combo_hipotesetratamentoid_Multiplevaluestype = "";
         Combo_hipotesetratamentoid_Loadingdata = "";
         Combo_hipotesetratamentoid_Noresultsfound = "";
         Combo_hipotesetratamentoid_Emptyitemtext = "";
         Combo_hipotesetratamentoid_Onlyselectedvalues = "";
         Combo_hipotesetratamentoid_Selectalltext = "";
         Combo_hipotesetratamentoid_Multiplevaluesseparator = "";
         Combo_hipotesetratamentoid_Addnewoptiontext = "";
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
         sMode43 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV24GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV25GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV22Combo_DataJson = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         GXt_char2 = "";
         Z102DocDicionarioFinalidade = "";
         Z119DocDicionarioTipoTransfInterGa = "";
         Z70InformacaoNome = "";
         Z73HipoteseTratamentoNome = "";
         Z76DocumentoNome = "";
         T000W4_A70InformacaoNome = new string[] {""} ;
         T000W5_A73HipoteseTratamentoNome = new string[] {""} ;
         T000W6_A76DocumentoNome = new string[] {""} ;
         T000W6_n76DocumentoNome = new bool[] {false} ;
         T000W7_A98DocDicionarioId = new int[1] ;
         T000W7_A102DocDicionarioFinalidade = new string[] {""} ;
         T000W7_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         T000W7_A99DocDicionarioSensivel = new bool[] {false} ;
         T000W7_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         T000W7_A101DocDicionarioTransfInter = new bool[] {false} ;
         T000W7_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T000W7_A70InformacaoNome = new string[] {""} ;
         T000W7_A73HipoteseTratamentoNome = new string[] {""} ;
         T000W7_A76DocumentoNome = new string[] {""} ;
         T000W7_n76DocumentoNome = new bool[] {false} ;
         T000W7_A69InformacaoId = new int[1] ;
         T000W7_A72HipoteseTratamentoId = new int[1] ;
         T000W7_A75DocumentoId = new int[1] ;
         T000W8_A70InformacaoNome = new string[] {""} ;
         T000W9_A73HipoteseTratamentoNome = new string[] {""} ;
         T000W10_A76DocumentoNome = new string[] {""} ;
         T000W10_n76DocumentoNome = new bool[] {false} ;
         T000W11_A98DocDicionarioId = new int[1] ;
         T000W3_A98DocDicionarioId = new int[1] ;
         T000W3_A102DocDicionarioFinalidade = new string[] {""} ;
         T000W3_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         T000W3_A99DocDicionarioSensivel = new bool[] {false} ;
         T000W3_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         T000W3_A101DocDicionarioTransfInter = new bool[] {false} ;
         T000W3_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T000W3_A69InformacaoId = new int[1] ;
         T000W3_A72HipoteseTratamentoId = new int[1] ;
         T000W3_A75DocumentoId = new int[1] ;
         T000W12_A98DocDicionarioId = new int[1] ;
         T000W13_A98DocDicionarioId = new int[1] ;
         T000W2_A98DocDicionarioId = new int[1] ;
         T000W2_A102DocDicionarioFinalidade = new string[] {""} ;
         T000W2_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         T000W2_A99DocDicionarioSensivel = new bool[] {false} ;
         T000W2_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         T000W2_A101DocDicionarioTransfInter = new bool[] {false} ;
         T000W2_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T000W2_A69InformacaoId = new int[1] ;
         T000W2_A72HipoteseTratamentoId = new int[1] ;
         T000W2_A75DocumentoId = new int[1] ;
         T000W14_A98DocDicionarioId = new int[1] ;
         T000W17_A70InformacaoNome = new string[] {""} ;
         T000W18_A73HipoteseTratamentoNome = new string[] {""} ;
         T000W19_A76DocumentoNome = new string[] {""} ;
         T000W19_n76DocumentoNome = new bool[] {false} ;
         T000W20_A4PaisId = new int[1] ;
         T000W20_A98DocDicionarioId = new int[1] ;
         T000W21_A66CompartTercExternoId = new int[1] ;
         T000W21_A98DocDicionarioId = new int[1] ;
         T000W22_A98DocDicionarioId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i103DocDicionarioDataInclusao = DateTime.MinValue;
         sCtrlGx_mode = "";
         sCtrlAV7DocDicionarioId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000W23_A24AreaResponsavelId = new int[1] ;
         T000W23_A25AreaResponsavelNome = new string[] {""} ;
         T000W24_A24AreaResponsavelId = new int[1] ;
         T000W24_A25AreaResponsavelNome = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docdicionario__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionario__default(),
            new Object[][] {
                new Object[] {
               T000W2_A98DocDicionarioId, T000W2_A102DocDicionarioFinalidade, T000W2_A119DocDicionarioTipoTransfInterGa, T000W2_A99DocDicionarioSensivel, T000W2_A100DocDicionarioPodeEliminar, T000W2_A101DocDicionarioTransfInter, T000W2_A103DocDicionarioDataInclusao, T000W2_A69InformacaoId, T000W2_A72HipoteseTratamentoId, T000W2_A75DocumentoId
               }
               , new Object[] {
               T000W3_A98DocDicionarioId, T000W3_A102DocDicionarioFinalidade, T000W3_A119DocDicionarioTipoTransfInterGa, T000W3_A99DocDicionarioSensivel, T000W3_A100DocDicionarioPodeEliminar, T000W3_A101DocDicionarioTransfInter, T000W3_A103DocDicionarioDataInclusao, T000W3_A69InformacaoId, T000W3_A72HipoteseTratamentoId, T000W3_A75DocumentoId
               }
               , new Object[] {
               T000W4_A70InformacaoNome
               }
               , new Object[] {
               T000W5_A73HipoteseTratamentoNome
               }
               , new Object[] {
               T000W6_A76DocumentoNome, T000W6_n76DocumentoNome
               }
               , new Object[] {
               T000W7_A98DocDicionarioId, T000W7_A102DocDicionarioFinalidade, T000W7_A119DocDicionarioTipoTransfInterGa, T000W7_A99DocDicionarioSensivel, T000W7_A100DocDicionarioPodeEliminar, T000W7_A101DocDicionarioTransfInter, T000W7_A103DocDicionarioDataInclusao, T000W7_A70InformacaoNome, T000W7_A73HipoteseTratamentoNome, T000W7_A76DocumentoNome,
               T000W7_n76DocumentoNome, T000W7_A69InformacaoId, T000W7_A72HipoteseTratamentoId, T000W7_A75DocumentoId
               }
               , new Object[] {
               T000W8_A70InformacaoNome
               }
               , new Object[] {
               T000W9_A73HipoteseTratamentoNome
               }
               , new Object[] {
               T000W10_A76DocumentoNome, T000W10_n76DocumentoNome
               }
               , new Object[] {
               T000W11_A98DocDicionarioId
               }
               , new Object[] {
               T000W12_A98DocDicionarioId
               }
               , new Object[] {
               T000W13_A98DocDicionarioId
               }
               , new Object[] {
               T000W14_A98DocDicionarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W17_A70InformacaoNome
               }
               , new Object[] {
               T000W18_A73HipoteseTratamentoNome
               }
               , new Object[] {
               T000W19_A76DocumentoNome, T000W19_n76DocumentoNome
               }
               , new Object[] {
               T000W20_A4PaisId, T000W20_A98DocDicionarioId
               }
               , new Object[] {
               T000W21_A66CompartTercExternoId, T000W21_A98DocDicionarioId
               }
               , new Object[] {
               T000W22_A98DocDicionarioId
               }
               , new Object[] {
               T000W23_A24AreaResponsavelId, T000W23_A25AreaResponsavelNome
               }
               , new Object[] {
               T000W24_A24AreaResponsavelId, T000W24_A25AreaResponsavelNome
               }
            }
         );
         AV33Pgmname = "DocDicionario";
         Z103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         A103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
         i103DocDicionarioDataInclusao = DateTimeUtil.Today( context);
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
      private short RcdFound43 ;
      private short GX_JID ;
      private short nIsDirty_43 ;
      private int wcpOAV7DocDicionarioId ;
      private int Z98DocDicionarioId ;
      private int Z69InformacaoId ;
      private int Z72HipoteseTratamentoId ;
      private int Z75DocumentoId ;
      private int N69InformacaoId ;
      private int N72HipoteseTratamentoId ;
      private int N75DocumentoId ;
      private int AV7DocDicionarioId ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A75DocumentoId ;
      private int trnEnded ;
      private int edtDocDicionarioFinalidade_Enabled ;
      private int edtDocDicionarioDataInclusao_Enabled ;
      private int edtHipoteseTratamentoId_Visible ;
      private int edtHipoteseTratamentoId_Enabled ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoId_Enabled ;
      private int edtDocDicionarioTipoTransfInterGa_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV29ComboHipoteseTratamentoId ;
      private int edtavCombohipotesetratamentoid_Enabled ;
      private int edtavCombohipotesetratamentoid_Visible ;
      private int AV31ComboDocumentoId ;
      private int edtavCombodocumentoid_Enabled ;
      private int edtavCombodocumentoid_Visible ;
      private int A98DocDicionarioId ;
      private int edtDocDicionarioId_Enabled ;
      private int edtDocDicionarioId_Visible ;
      private int AV14Insert_InformacaoId ;
      private int AV15Insert_HipoteseTratamentoId ;
      private int AV13Insert_DocumentoId ;
      private int Combo_hipotesetratamentoid_Datalistupdateminimumcharacters ;
      private int Combo_hipotesetratamentoid_Gxcontroltype ;
      private int Combo_documentoid_Datalistupdateminimumcharacters ;
      private int Combo_documentoid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV34GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_documentoid_Selectedvalue_get ;
      private string Combo_hipotesetratamentoid_Selectedvalue_get ;
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
      private string dynInformacaoId_Internalname ;
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
      private string dynInformacaoId_Jsonclick ;
      private string chkDocDicionarioPodeEliminar_Internalname ;
      private string chkDocDicionarioSensivel_Internalname ;
      private string chkDocDicionarioTransfInter_Internalname ;
      private string edtDocDicionarioFinalidade_Internalname ;
      private string edtDocDicionarioDataInclusao_Internalname ;
      private string edtDocDicionarioDataInclusao_Jsonclick ;
      private string divTablesplittedhipotesetratamentoid_Internalname ;
      private string lblTextblockhipotesetratamentoid_Internalname ;
      private string lblTextblockhipotesetratamentoid_Jsonclick ;
      private string Combo_hipotesetratamentoid_Caption ;
      private string Combo_hipotesetratamentoid_Cls ;
      private string Combo_hipotesetratamentoid_Datalistproc ;
      private string Combo_hipotesetratamentoid_Datalistprocparametersprefix ;
      private string Combo_hipotesetratamentoid_Internalname ;
      private string edtHipoteseTratamentoId_Internalname ;
      private string edtHipoteseTratamentoId_Jsonclick ;
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
      private string edtDocDicionarioTipoTransfInterGa_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_hipotesetratamentoid_Internalname ;
      private string edtavCombohipotesetratamentoid_Internalname ;
      private string edtavCombohipotesetratamentoid_Jsonclick ;
      private string divSectionattribute_documentoid_Internalname ;
      private string edtavCombodocumentoid_Internalname ;
      private string edtavCombodocumentoid_Jsonclick ;
      private string edtDocDicionarioId_Internalname ;
      private string edtDocDicionarioId_Jsonclick ;
      private string AV33Pgmname ;
      private string Combo_hipotesetratamentoid_Objectcall ;
      private string Combo_hipotesetratamentoid_Class ;
      private string Combo_hipotesetratamentoid_Icontype ;
      private string Combo_hipotesetratamentoid_Icon ;
      private string Combo_hipotesetratamentoid_Tooltip ;
      private string Combo_hipotesetratamentoid_Selectedvalue_set ;
      private string Combo_hipotesetratamentoid_Selectedtext_set ;
      private string Combo_hipotesetratamentoid_Selectedtext_get ;
      private string Combo_hipotesetratamentoid_Gamoauthtoken ;
      private string Combo_hipotesetratamentoid_Ddointernalname ;
      private string Combo_hipotesetratamentoid_Titlecontrolalign ;
      private string Combo_hipotesetratamentoid_Dropdownoptionstype ;
      private string Combo_hipotesetratamentoid_Titlecontrolidtoreplace ;
      private string Combo_hipotesetratamentoid_Datalisttype ;
      private string Combo_hipotesetratamentoid_Datalistfixedvalues ;
      private string Combo_hipotesetratamentoid_Htmltemplate ;
      private string Combo_hipotesetratamentoid_Multiplevaluestype ;
      private string Combo_hipotesetratamentoid_Loadingdata ;
      private string Combo_hipotesetratamentoid_Noresultsfound ;
      private string Combo_hipotesetratamentoid_Emptyitemtext ;
      private string Combo_hipotesetratamentoid_Onlyselectedvalues ;
      private string Combo_hipotesetratamentoid_Selectalltext ;
      private string Combo_hipotesetratamentoid_Multiplevaluesseparator ;
      private string Combo_hipotesetratamentoid_Addnewoptiontext ;
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
      private string sMode43 ;
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
      private string sCtrlAV7DocDicionarioId ;
      private string gxwrpcisep ;
      private DateTime Z103DocDicionarioDataInclusao ;
      private DateTime A103DocDicionarioDataInclusao ;
      private DateTime i103DocDicionarioDataInclusao ;
      private bool Z99DocDicionarioSensivel ;
      private bool Z100DocDicionarioPodeEliminar ;
      private bool Z101DocDicionarioTransfInter ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A99DocDicionarioSensivel ;
      private bool A101DocDicionarioTransfInter ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_hipotesetratamentoid_Emptyitem ;
      private bool Combo_documentoid_Emptyitem ;
      private bool n76DocumentoNome ;
      private bool Combo_hipotesetratamentoid_Enabled ;
      private bool Combo_hipotesetratamentoid_Visible ;
      private bool Combo_hipotesetratamentoid_Allowmultipleselection ;
      private bool Combo_hipotesetratamentoid_Isgriditem ;
      private bool Combo_hipotesetratamentoid_Hasdescription ;
      private bool Combo_hipotesetratamentoid_Includeonlyselectedoption ;
      private bool Combo_hipotesetratamentoid_Includeselectalloption ;
      private bool Combo_hipotesetratamentoid_Includeaddnewoption ;
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
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string AV22Combo_DataJson ;
      private string Z102DocDicionarioFinalidade ;
      private string Z119DocDicionarioTipoTransfInterGa ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string A76DocumentoNome ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string Z70InformacaoNome ;
      private string Z73HipoteseTratamentoNome ;
      private string Z76DocumentoNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_hipotesetratamentoid ;
      private GXUserControl ucCombo_documentoid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynInformacaoId ;
      private GXCheckbox chkDocDicionarioPodeEliminar ;
      private GXCheckbox chkDocDicionarioSensivel ;
      private GXCheckbox chkDocDicionarioTransfInter ;
      private IDataStoreProvider pr_default ;
      private string[] T000W4_A70InformacaoNome ;
      private string[] T000W5_A73HipoteseTratamentoNome ;
      private string[] T000W6_A76DocumentoNome ;
      private bool[] T000W6_n76DocumentoNome ;
      private int[] T000W7_A98DocDicionarioId ;
      private string[] T000W7_A102DocDicionarioFinalidade ;
      private string[] T000W7_A119DocDicionarioTipoTransfInterGa ;
      private bool[] T000W7_A99DocDicionarioSensivel ;
      private bool[] T000W7_A100DocDicionarioPodeEliminar ;
      private bool[] T000W7_A101DocDicionarioTransfInter ;
      private DateTime[] T000W7_A103DocDicionarioDataInclusao ;
      private string[] T000W7_A70InformacaoNome ;
      private string[] T000W7_A73HipoteseTratamentoNome ;
      private string[] T000W7_A76DocumentoNome ;
      private bool[] T000W7_n76DocumentoNome ;
      private int[] T000W7_A69InformacaoId ;
      private int[] T000W7_A72HipoteseTratamentoId ;
      private int[] T000W7_A75DocumentoId ;
      private string[] T000W8_A70InformacaoNome ;
      private string[] T000W9_A73HipoteseTratamentoNome ;
      private string[] T000W10_A76DocumentoNome ;
      private bool[] T000W10_n76DocumentoNome ;
      private int[] T000W11_A98DocDicionarioId ;
      private int[] T000W3_A98DocDicionarioId ;
      private string[] T000W3_A102DocDicionarioFinalidade ;
      private string[] T000W3_A119DocDicionarioTipoTransfInterGa ;
      private bool[] T000W3_A99DocDicionarioSensivel ;
      private bool[] T000W3_A100DocDicionarioPodeEliminar ;
      private bool[] T000W3_A101DocDicionarioTransfInter ;
      private DateTime[] T000W3_A103DocDicionarioDataInclusao ;
      private int[] T000W3_A69InformacaoId ;
      private int[] T000W3_A72HipoteseTratamentoId ;
      private int[] T000W3_A75DocumentoId ;
      private int[] T000W12_A98DocDicionarioId ;
      private int[] T000W13_A98DocDicionarioId ;
      private int[] T000W2_A98DocDicionarioId ;
      private string[] T000W2_A102DocDicionarioFinalidade ;
      private string[] T000W2_A119DocDicionarioTipoTransfInterGa ;
      private bool[] T000W2_A99DocDicionarioSensivel ;
      private bool[] T000W2_A100DocDicionarioPodeEliminar ;
      private bool[] T000W2_A101DocDicionarioTransfInter ;
      private DateTime[] T000W2_A103DocDicionarioDataInclusao ;
      private int[] T000W2_A69InformacaoId ;
      private int[] T000W2_A72HipoteseTratamentoId ;
      private int[] T000W2_A75DocumentoId ;
      private int[] T000W14_A98DocDicionarioId ;
      private string[] T000W17_A70InformacaoNome ;
      private string[] T000W18_A73HipoteseTratamentoNome ;
      private string[] T000W19_A76DocumentoNome ;
      private bool[] T000W19_n76DocumentoNome ;
      private int[] T000W20_A4PaisId ;
      private int[] T000W20_A98DocDicionarioId ;
      private int[] T000W21_A66CompartTercExternoId ;
      private int[] T000W21_A98DocDicionarioId ;
      private int[] T000W22_A98DocDicionarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] T000W23_A24AreaResponsavelId ;
      private string[] T000W23_A25AreaResponsavelNome ;
      private int[] T000W24_A24AreaResponsavelId ;
      private string[] T000W24_A25AreaResponsavelNome ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV25GAMErrors ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV28HipoteseTratamentoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30DocumentoId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV24GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class docdicionario__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docdicionario__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000W7;
        prmT000W7 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W4;
        prmT000W4 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmT000W5;
        prmT000W5 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmT000W6;
        prmT000W6 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT000W8;
        prmT000W8 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmT000W9;
        prmT000W9 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmT000W10;
        prmT000W10 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT000W11;
        prmT000W11 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W3;
        prmT000W3 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W12;
        prmT000W12 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W13;
        prmT000W13 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W2;
        prmT000W2 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W14;
        prmT000W14 = new Object[] {
        new ParDef("@DocDicionarioFinalidade",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioTipoTransfInterGa",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioSensivel",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioPodeEliminar",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioTransfInter",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioDataInclusao",GXType.Date,8,0) ,
        new ParDef("@InformacaoId",GXType.Int32,8,0) ,
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT000W15;
        prmT000W15 = new Object[] {
        new ParDef("@DocDicionarioFinalidade",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioTipoTransfInterGa",GXType.NVarChar,10000,0) ,
        new ParDef("@DocDicionarioSensivel",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioPodeEliminar",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioTransfInter",GXType.Boolean,4,0) ,
        new ParDef("@DocDicionarioDataInclusao",GXType.Date,8,0) ,
        new ParDef("@InformacaoId",GXType.Int32,8,0) ,
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W16;
        prmT000W16 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W20;
        prmT000W20 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W21;
        prmT000W21 = new Object[] {
        new ParDef("@DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmT000W22;
        prmT000W22 = new Object[] {
        };
        Object[] prmT000W23;
        prmT000W23 = new Object[] {
        };
        Object[] prmT000W24;
        prmT000W24 = new Object[] {
        };
        Object[] prmT000W17;
        prmT000W17 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmT000W18;
        prmT000W18 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmT000W19;
        prmT000W19 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000W2", "SELECT [DocDicionarioId], [DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioSensivel], [DocDicionarioPodeEliminar], [DocDicionarioTransfInter], [DocDicionarioDataInclusao], [InformacaoId], [HipoteseTratamentoId], [DocumentoId] FROM [DocDicionario] WITH (UPDLOCK) WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W3", "SELECT [DocDicionarioId], [DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioSensivel], [DocDicionarioPodeEliminar], [DocDicionarioTransfInter], [DocDicionarioDataInclusao], [InformacaoId], [HipoteseTratamentoId], [DocumentoId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W4", "SELECT [InformacaoNome] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W5", "SELECT [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W6", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W7", "SELECT TM1.[DocDicionarioId], TM1.[DocDicionarioFinalidade], TM1.[DocDicionarioTipoTransfInterGa], TM1.[DocDicionarioSensivel], TM1.[DocDicionarioPodeEliminar], TM1.[DocDicionarioTransfInter], TM1.[DocDicionarioDataInclusao], T2.[InformacaoNome], T3.[HipoteseTratamentoNome], T4.[DocumentoNome], TM1.[InformacaoId], TM1.[HipoteseTratamentoId], TM1.[DocumentoId] FROM ((([DocDicionario] TM1 INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = TM1.[InformacaoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = TM1.[HipoteseTratamentoId]) INNER JOIN [Documento] T4 ON T4.[DocumentoId] = TM1.[DocumentoId]) WHERE TM1.[DocDicionarioId] = @DocDicionarioId ORDER BY TM1.[DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W8", "SELECT [InformacaoNome] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W9", "SELECT [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W10", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W11", "SELECT [DocDicionarioId] FROM [DocDicionario] WHERE [DocDicionarioId] = @DocDicionarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W12", "SELECT TOP 1 [DocDicionarioId] FROM [DocDicionario] WHERE ( [DocDicionarioId] > @DocDicionarioId) ORDER BY [DocDicionarioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W13", "SELECT TOP 1 [DocDicionarioId] FROM [DocDicionario] WHERE ( [DocDicionarioId] < @DocDicionarioId) ORDER BY [DocDicionarioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W14", "INSERT INTO [DocDicionario]([DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioSensivel], [DocDicionarioPodeEliminar], [DocDicionarioTransfInter], [DocDicionarioDataInclusao], [InformacaoId], [HipoteseTratamentoId], [DocumentoId]) VALUES(@DocDicionarioFinalidade, @DocDicionarioTipoTransfInterGa, @DocDicionarioSensivel, @DocDicionarioPodeEliminar, @DocDicionarioTransfInter, @DocDicionarioDataInclusao, @InformacaoId, @HipoteseTratamentoId, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000W14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W15", "UPDATE [DocDicionario] SET [DocDicionarioFinalidade]=@DocDicionarioFinalidade, [DocDicionarioTipoTransfInterGa]=@DocDicionarioTipoTransfInterGa, [DocDicionarioSensivel]=@DocDicionarioSensivel, [DocDicionarioPodeEliminar]=@DocDicionarioPodeEliminar, [DocDicionarioTransfInter]=@DocDicionarioTransfInter, [DocDicionarioDataInclusao]=@DocDicionarioDataInclusao, [InformacaoId]=@InformacaoId, [HipoteseTratamentoId]=@HipoteseTratamentoId, [DocumentoId]=@DocumentoId  WHERE [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmT000W15)
           ,new CursorDef("T000W16", "DELETE FROM [DocDicionario]  WHERE [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK,prmT000W16)
           ,new CursorDef("T000W17", "SELECT [InformacaoNome] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W18", "SELECT [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W19", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W20", "SELECT TOP 1 [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W21", "SELECT TOP 1 [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @DocDicionarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W22", "SELECT [DocDicionarioId] FROM [DocDicionario] ORDER BY [DocDicionarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W23", "SELECT [AreaResponsavelId], [AreaResponsavelNome] FROM [AreaResponsavel] ORDER BY [AreaResponsavelNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W23,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W24", "SELECT [AreaResponsavelId], [AreaResponsavelNome] FROM [AreaResponsavel] ORDER BY [AreaResponsavelNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W24,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
