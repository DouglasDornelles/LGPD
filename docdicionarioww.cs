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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class docdicionarioww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public docdicionarioww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docdicionarioww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkDocDicionarioSensivel = new GXCheckbox();
         chkDocDicionarioPodeEliminar = new GXCheckbox();
         chkDocDicionarioTransfInter = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_40 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_40"), "."));
         nGXsfl_40_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_40_idx"), "."));
         sGXsfl_40_idx = GetPar( "sGXsfl_40_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV26ManageFiltersExecutionStep = (short)(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV27TFDocDicionarioId = (int)(NumberUtil.Val( GetPar( "TFDocDicionarioId"), "."));
         AV28TFDocDicionarioId_To = (int)(NumberUtil.Val( GetPar( "TFDocDicionarioId_To"), "."));
         AV31TFInformacaoId = (int)(NumberUtil.Val( GetPar( "TFInformacaoId"), "."));
         AV32TFInformacaoId_To = (int)(NumberUtil.Val( GetPar( "TFInformacaoId_To"), "."));
         AV62TFHipoteseTratamentoId = (int)(NumberUtil.Val( GetPar( "TFHipoteseTratamentoId"), "."));
         AV63TFHipoteseTratamentoId_To = (int)(NumberUtil.Val( GetPar( "TFHipoteseTratamentoId_To"), "."));
         AV36TFDocDicionarioSensivel_Sel = (short)(NumberUtil.Val( GetPar( "TFDocDicionarioSensivel_Sel"), "."));
         AV37TFDocDicionarioPodeEliminar_Sel = (short)(NumberUtil.Val( GetPar( "TFDocDicionarioPodeEliminar_Sel"), "."));
         AV82TFDocDicionarioTransfInter_Sel = (short)(NumberUtil.Val( GetPar( "TFDocDicionarioTransfInter_Sel"), "."));
         AV40TFDocDicionarioFinalidade = GetPar( "TFDocDicionarioFinalidade");
         AV41TFDocDicionarioFinalidade_Sel = GetPar( "TFDocDicionarioFinalidade_Sel");
         AV42TFDocDicionarioDataInclusao = context.localUtil.ParseDateParm( GetPar( "TFDocDicionarioDataInclusao"));
         AV43TFDocDicionarioDataInclusao_To = context.localUtil.ParseDateParm( GetPar( "TFDocDicionarioDataInclusao_To"));
         AV66TFInformacaoNome = GetPar( "TFInformacaoNome");
         AV67TFInformacaoNome_Sel = GetPar( "TFInformacaoNome_Sel");
         AV68TFHipoteseTratamentoNome = GetPar( "TFHipoteseTratamentoNome");
         AV69TFHipoteseTratamentoNome_Sel = GetPar( "TFHipoteseTratamentoNome_Sel");
         AV75TFDocumentoId = (int)(NumberUtil.Val( GetPar( "TFDocumentoId"), "."));
         AV76TFDocumentoId_To = (int)(NumberUtil.Val( GetPar( "TFDocumentoId_To"), "."));
         AV77TFDocumentoNome = GetPar( "TFDocumentoNome");
         AV78TFDocumentoNome_Sel = GetPar( "TFDocumentoNome_Sel");
         AV79TFDocDicionarioTipoTransfInterGarantia = GetPar( "TFDocDicionarioTipoTransfInterGarantia");
         AV80TFDocDicionarioTipoTransfInterGarantia_Sel = GetPar( "TFDocDicionarioTipoTransfInterGarantia_Sel");
         AV109Pgmname = GetPar( "Pgmname");
         AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV55IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV57IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV72IsAuthorized_InformacaoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_InformacaoNome"));
         AV73IsAuthorized_HipoteseTratamentoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_HipoteseTratamentoNome"));
         AV61IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV27TFDocDicionarioId, AV28TFDocDicionarioId_To, AV31TFInformacaoId, AV32TFInformacaoId_To, AV62TFHipoteseTratamentoId, AV63TFHipoteseTratamentoId_To, AV36TFDocDicionarioSensivel_Sel, AV37TFDocDicionarioPodeEliminar_Sel, AV82TFDocDicionarioTransfInter_Sel, AV40TFDocDicionarioFinalidade, AV41TFDocDicionarioFinalidade_Sel, AV42TFDocDicionarioDataInclusao, AV43TFDocDicionarioDataInclusao_To, AV66TFInformacaoNome, AV67TFInformacaoNome_Sel, AV68TFHipoteseTratamentoNome, AV69TFHipoteseTratamentoNome_Sel, AV75TFDocumentoId, AV76TFDocumentoId_To, AV77TFDocumentoNome, AV78TFDocumentoNome_Sel, AV79TFDocDicionarioTipoTransfInterGarantia, AV80TFDocDicionarioTipoTransfInterGarantia_Sel, AV109Pgmname, AV13OrderedBy, AV14OrderedDsc, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV72IsAuthorized_InformacaoNome, AV73IsAuthorized_HipoteseTratamentoNome, AV61IsAuthorized_Insert) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "docdicionarioww_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA332( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START332( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docdicionarioww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV109Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INFORMACAONOME", GetSecureSignedToken( "", AV72IsAuthorized_InformacaoNome, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HIPOTESETRATAMENTONOME", GetSecureSignedToken( "", AV73IsAuthorized_HipoteseTratamentoNome, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV61IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV59AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV59AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_DOCDICIONARIODATAINCLUSAOAUXDATETO", context.localUtil.DToC( AV45DDO_DocDicionarioDataInclusaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFDocDicionarioId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFDocDicionarioId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFINFORMACAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFInformacaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFINFORMACAOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFInformacaoId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFHIPOTESETRATAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62TFHipoteseTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFHIPOTESETRATAMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63TFHipoteseTratamentoId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOSENSIVEL_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFDocDicionarioSensivel_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOPODEELIMINAR_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFDocDicionarioPodeEliminar_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOTRANSFINTER_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82TFDocDicionarioTransfInter_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOFINALIDADE", AV40TFDocDicionarioFinalidade);
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOFINALIDADE_SEL", AV41TFDocDicionarioFinalidade_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIODATAINCLUSAO", context.localUtil.DToC( AV42TFDocDicionarioDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIODATAINCLUSAO_TO", context.localUtil.DToC( AV43TFDocDicionarioDataInclusao_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFINFORMACAONOME", AV66TFInformacaoNome);
         GxWebStd.gx_hidden_field( context, "vTFINFORMACAONOME_SEL", AV67TFInformacaoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFHIPOTESETRATAMENTONOME", AV68TFHipoteseTratamentoNome);
         GxWebStd.gx_hidden_field( context, "vTFHIPOTESETRATAMENTONOME_SEL", AV69TFHipoteseTratamentoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75TFDocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76TFDocumentoId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTONOME", AV77TFDocumentoNome);
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTONOME_SEL", AV78TFDocumentoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA", AV79TFDocDicionarioTipoTransfInterGarantia);
         GxWebStd.gx_hidden_field( context, "vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL", AV80TFDocDicionarioTipoTransfInterGarantia_Sel);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV109Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV109Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INFORMACAONOME", AV72IsAuthorized_InformacaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INFORMACAONOME", GetSecureSignedToken( "", AV72IsAuthorized_InformacaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_HIPOTESETRATAMENTONOME", AV73IsAuthorized_HipoteseTratamentoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HIPOTESETRATAMENTONOME", GetSecureSignedToken( "", AV73IsAuthorized_HipoteseTratamentoNome, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV61IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV61IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCDICIONARIODATAINCLUSAOAUXDATE", context.localUtil.DToC( AV44DDO_DocDicionarioDataInclusaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Grid_empowerer_Infinitescrolling));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE332( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT332( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("docdicionarioww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "DocDicionarioWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Doc Dicionario" ;
      }

      protected void WB330( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionarioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionarioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionarioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table1_25_332( true) ;
         }
         else
         {
            wb_table1_25_332( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_332e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl40( ) ;
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            nRC_GXsfl_40 = (int)(nGXsfl_40_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV59AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("InfiniteScrolling", Grid_empowerer_Infinitescrolling);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_docdicionariodatainclusaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_40_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_docdicionariodatainclusaoauxdatetext_Internalname, AV46DDO_DocDicionarioDataInclusaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV46DDO_DocDicionarioDataInclusaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_docdicionariodatainclusaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocDicionarioWW.htm");
            /* User Defined Control */
            ucTfdocdicionariodatainclusao_rangepicker.SetProperty("Start Date", AV44DDO_DocDicionarioDataInclusaoAuxDate);
            ucTfdocdicionariodatainclusao_rangepicker.SetProperty("End Date", AV45DDO_DocDicionarioDataInclusaoAuxDateTo);
            ucTfdocdicionariodatainclusao_rangepicker.Render(context, "wwp.daterangepicker", Tfdocdicionariodatainclusao_rangepicker_Internalname, "TFDOCDICIONARIODATAINCLUSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START332( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", " Doc Dicionario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP330( ) ;
      }

      protected void WS332( )
      {
         START332( ) ;
         EVT332( ) ;
      }

      protected void EVT332( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E15332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
                              AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
                              AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
                              AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
                              AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
                              AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
                              AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
                              AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
                              AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
                              AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
                              AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
                              AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
                              AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
                              AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
                              AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
                              AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
                              AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
                              AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
                              AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
                              AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
                              AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
                              AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
                              AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
                              AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_40_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              AV54Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV54Update);
                              AV56Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV56Delete);
                              A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", "."));
                              A69InformacaoId = (int)(context.localUtil.CToN( cgiGet( edtInformacaoId_Internalname), ",", "."));
                              A72HipoteseTratamentoId = (int)(context.localUtil.CToN( cgiGet( edtHipoteseTratamentoId_Internalname), ",", "."));
                              A99DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkDocDicionarioSensivel_Internalname));
                              A100DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkDocDicionarioPodeEliminar_Internalname));
                              A101DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( chkDocDicionarioTransfInter_Internalname));
                              A102DocDicionarioFinalidade = cgiGet( edtDocDicionarioFinalidade_Internalname);
                              A103DocDicionarioDataInclusao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDocDicionarioDataInclusao_Internalname), 0));
                              A70InformacaoNome = cgiGet( edtInformacaoNome_Internalname);
                              A73HipoteseTratamentoNome = cgiGet( edtHipoteseTratamentoNome_Internalname);
                              A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                              A76DocumentoNome = cgiGet( edtDocumentoNome_Internalname);
                              n76DocumentoNome = false;
                              A119DocDicionarioTipoTransfInterGa = cgiGet( edtDocDicionarioTipoTransfInterGa_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16332 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E17332 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E18332 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE332( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA332( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_402( ) ;
         while ( nGXsfl_40_idx <= nRC_GXsfl_40 )
         {
            sendrow_402( ) ;
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       int AV27TFDocDicionarioId ,
                                       int AV28TFDocDicionarioId_To ,
                                       int AV31TFInformacaoId ,
                                       int AV32TFInformacaoId_To ,
                                       int AV62TFHipoteseTratamentoId ,
                                       int AV63TFHipoteseTratamentoId_To ,
                                       short AV36TFDocDicionarioSensivel_Sel ,
                                       short AV37TFDocDicionarioPodeEliminar_Sel ,
                                       short AV82TFDocDicionarioTransfInter_Sel ,
                                       string AV40TFDocDicionarioFinalidade ,
                                       string AV41TFDocDicionarioFinalidade_Sel ,
                                       DateTime AV42TFDocDicionarioDataInclusao ,
                                       DateTime AV43TFDocDicionarioDataInclusao_To ,
                                       string AV66TFInformacaoNome ,
                                       string AV67TFInformacaoNome_Sel ,
                                       string AV68TFHipoteseTratamentoNome ,
                                       string AV69TFHipoteseTratamentoNome_Sel ,
                                       int AV75TFDocumentoId ,
                                       int AV76TFDocumentoId_To ,
                                       string AV77TFDocumentoNome ,
                                       string AV78TFDocumentoNome_Sel ,
                                       string AV79TFDocDicionarioTipoTransfInterGarantia ,
                                       string AV80TFDocDicionarioTipoTransfInterGarantia_Sel ,
                                       string AV109Pgmname ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV55IsAuthorized_Update ,
                                       bool AV57IsAuthorized_Delete ,
                                       bool AV72IsAuthorized_InformacaoNome ,
                                       bool AV73IsAuthorized_HipoteseTratamentoNome ,
                                       bool AV61IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E17332 ();
         GRID_nCurrentRecord = 0;
         RF332( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DOCDICIONARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCDICIONARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_40_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF332( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV109Pgmname = "DocDicionarioWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_40_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_40_Refreshing);
      }

      protected void RF332( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 40;
         /* Execute user event: Refresh */
         E17332 ();
         nGXsfl_40_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         bGXsfl_40_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_402( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV85Docdicionariowwds_1_filterfulltext ,
                                                 AV86Docdicionariowwds_2_tfdocdicionarioid ,
                                                 AV87Docdicionariowwds_3_tfdocdicionarioid_to ,
                                                 AV88Docdicionariowwds_4_tfinformacaoid ,
                                                 AV89Docdicionariowwds_5_tfinformacaoid_to ,
                                                 AV90Docdicionariowwds_6_tfhipotesetratamentoid ,
                                                 AV91Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                                 AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                                 AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                                 AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                                 AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                                 AV95Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                                 AV97Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                                 AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                                 AV100Docdicionariowwds_16_tfinformacaonome_sel ,
                                                 AV99Docdicionariowwds_15_tfinformacaonome ,
                                                 AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                                 AV101Docdicionariowwds_17_tfhipotesetratamentonome ,
                                                 AV103Docdicionariowwds_19_tfdocumentoid ,
                                                 AV104Docdicionariowwds_20_tfdocumentoid_to ,
                                                 AV106Docdicionariowwds_22_tfdocumentonome_sel ,
                                                 AV105Docdicionariowwds_21_tfdocumentonome ,
                                                 AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                                 AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                                 A98DocDicionarioId ,
                                                 A69InformacaoId ,
                                                 A72HipoteseTratamentoId ,
                                                 A102DocDicionarioFinalidade ,
                                                 A70InformacaoNome ,
                                                 A73HipoteseTratamentoNome ,
                                                 A75DocumentoId ,
                                                 A76DocumentoNome ,
                                                 A119DocDicionarioTipoTransfInterGa ,
                                                 A99DocDicionarioSensivel ,
                                                 A100DocDicionarioPodeEliminar ,
                                                 A101DocDicionarioTransfInter ,
                                                 A103DocDicionarioDataInclusao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
            lV95Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV95Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
            lV99Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV99Docdicionariowwds_15_tfinformacaonome), "%", "");
            lV101Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV101Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
            lV105Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV105Docdicionariowwds_21_tfdocumentonome), "%", "");
            lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
            /* Using cursor H00332 */
            pr_default.execute(0, new Object[] {lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, AV86Docdicionariowwds_2_tfdocdicionarioid, AV87Docdicionariowwds_3_tfdocdicionarioid_to, AV88Docdicionariowwds_4_tfinformacaoid, AV89Docdicionariowwds_5_tfinformacaoid_to, AV90Docdicionariowwds_6_tfhipotesetratamentoid, AV91Docdicionariowwds_7_tfhipotesetratamentoid_to, lV95Docdicionariowwds_11_tfdocdicionariofinalidade, AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV97Docdicionariowwds_13_tfdocdicionariodatainclusao, AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV99Docdicionariowwds_15_tfinformacaonome, AV100Docdicionariowwds_16_tfinformacaonome_sel, lV101Docdicionariowwds_17_tfhipotesetratamentonome, AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV103Docdicionariowwds_19_tfdocumentoid, AV104Docdicionariowwds_20_tfdocumentoid_to, lV105Docdicionariowwds_21_tfdocumentonome, AV106Docdicionariowwds_22_tfdocumentonome_sel, lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_40_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A119DocDicionarioTipoTransfInterGa = H00332_A119DocDicionarioTipoTransfInterGa[0];
               A76DocumentoNome = H00332_A76DocumentoNome[0];
               n76DocumentoNome = H00332_n76DocumentoNome[0];
               A75DocumentoId = H00332_A75DocumentoId[0];
               A73HipoteseTratamentoNome = H00332_A73HipoteseTratamentoNome[0];
               A70InformacaoNome = H00332_A70InformacaoNome[0];
               A103DocDicionarioDataInclusao = H00332_A103DocDicionarioDataInclusao[0];
               A102DocDicionarioFinalidade = H00332_A102DocDicionarioFinalidade[0];
               A101DocDicionarioTransfInter = H00332_A101DocDicionarioTransfInter[0];
               A100DocDicionarioPodeEliminar = H00332_A100DocDicionarioPodeEliminar[0];
               A99DocDicionarioSensivel = H00332_A99DocDicionarioSensivel[0];
               A72HipoteseTratamentoId = H00332_A72HipoteseTratamentoId[0];
               A69InformacaoId = H00332_A69InformacaoId[0];
               A98DocDicionarioId = H00332_A98DocDicionarioId[0];
               A76DocumentoNome = H00332_A76DocumentoNome[0];
               n76DocumentoNome = H00332_n76DocumentoNome[0];
               A73HipoteseTratamentoNome = H00332_A73HipoteseTratamentoNome[0];
               A70InformacaoNome = H00332_A70InformacaoNome[0];
               E18332 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 40;
            WB330( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes332( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV109Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV109Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INFORMACAONOME", AV72IsAuthorized_InformacaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INFORMACAONOME", GetSecureSignedToken( "", AV72IsAuthorized_InformacaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_HIPOTESETRATAMENTONOME", AV73IsAuthorized_HipoteseTratamentoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HIPOTESETRATAMENTONOME", GetSecureSignedToken( "", AV73IsAuthorized_HipoteseTratamentoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV61IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV61IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCDICIONARIOID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV85Docdicionariowwds_1_filterfulltext ,
                                              AV86Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV87Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV88Docdicionariowwds_4_tfinformacaoid ,
                                              AV89Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV90Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV91Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV95Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV97Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV100Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV99Docdicionariowwds_15_tfinformacaonome ,
                                              AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV101Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV103Docdicionariowwds_19_tfdocumentoid ,
                                              AV104Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV106Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV105Docdicionariowwds_21_tfdocumentonome ,
                                              AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV85Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext), "%", "");
         lV95Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV95Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV99Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV99Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV101Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV101Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV105Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV105Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor H00333 */
         pr_default.execute(1, new Object[] {lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, lV85Docdicionariowwds_1_filterfulltext, AV86Docdicionariowwds_2_tfdocdicionarioid, AV87Docdicionariowwds_3_tfdocdicionarioid_to, AV88Docdicionariowwds_4_tfinformacaoid, AV89Docdicionariowwds_5_tfinformacaoid_to, AV90Docdicionariowwds_6_tfhipotesetratamentoid, AV91Docdicionariowwds_7_tfhipotesetratamentoid_to, lV95Docdicionariowwds_11_tfdocdicionariofinalidade, AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV97Docdicionariowwds_13_tfdocdicionariodatainclusao, AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV99Docdicionariowwds_15_tfinformacaonome, AV100Docdicionariowwds_16_tfinformacaonome_sel, lV101Docdicionariowwds_17_tfhipotesetratamentonome, AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV103Docdicionariowwds_19_tfdocumentoid, AV104Docdicionariowwds_20_tfdocumentoid_to, lV105Docdicionariowwds_21_tfdocumentonome, AV106Docdicionariowwds_22_tfdocumentonome_sel, lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         GRID_nRecordCount = H00333_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV27TFDocDicionarioId, AV28TFDocDicionarioId_To, AV31TFInformacaoId, AV32TFInformacaoId_To, AV62TFHipoteseTratamentoId, AV63TFHipoteseTratamentoId_To, AV36TFDocDicionarioSensivel_Sel, AV37TFDocDicionarioPodeEliminar_Sel, AV82TFDocDicionarioTransfInter_Sel, AV40TFDocDicionarioFinalidade, AV41TFDocDicionarioFinalidade_Sel, AV42TFDocDicionarioDataInclusao, AV43TFDocDicionarioDataInclusao_To, AV66TFInformacaoNome, AV67TFInformacaoNome_Sel, AV68TFHipoteseTratamentoNome, AV69TFHipoteseTratamentoNome_Sel, AV75TFDocumentoId, AV76TFDocumentoId_To, AV77TFDocumentoNome, AV78TFDocumentoNome_Sel, AV79TFDocDicionarioTipoTransfInterGarantia, AV80TFDocDicionarioTipoTransfInterGarantia_Sel, AV109Pgmname, AV13OrderedBy, AV14OrderedDsc, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV72IsAuthorized_InformacaoNome, AV73IsAuthorized_HipoteseTratamentoNome, AV61IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV27TFDocDicionarioId, AV28TFDocDicionarioId_To, AV31TFInformacaoId, AV32TFInformacaoId_To, AV62TFHipoteseTratamentoId, AV63TFHipoteseTratamentoId_To, AV36TFDocDicionarioSensivel_Sel, AV37TFDocDicionarioPodeEliminar_Sel, AV82TFDocDicionarioTransfInter_Sel, AV40TFDocDicionarioFinalidade, AV41TFDocDicionarioFinalidade_Sel, AV42TFDocDicionarioDataInclusao, AV43TFDocDicionarioDataInclusao_To, AV66TFInformacaoNome, AV67TFInformacaoNome_Sel, AV68TFHipoteseTratamentoNome, AV69TFHipoteseTratamentoNome_Sel, AV75TFDocumentoId, AV76TFDocumentoId_To, AV77TFDocumentoNome, AV78TFDocumentoNome_Sel, AV79TFDocDicionarioTipoTransfInterGarantia, AV80TFDocDicionarioTipoTransfInterGarantia_Sel, AV109Pgmname, AV13OrderedBy, AV14OrderedDsc, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV72IsAuthorized_InformacaoNome, AV73IsAuthorized_HipoteseTratamentoNome, AV61IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV27TFDocDicionarioId, AV28TFDocDicionarioId_To, AV31TFInformacaoId, AV32TFInformacaoId_To, AV62TFHipoteseTratamentoId, AV63TFHipoteseTratamentoId_To, AV36TFDocDicionarioSensivel_Sel, AV37TFDocDicionarioPodeEliminar_Sel, AV82TFDocDicionarioTransfInter_Sel, AV40TFDocDicionarioFinalidade, AV41TFDocDicionarioFinalidade_Sel, AV42TFDocDicionarioDataInclusao, AV43TFDocDicionarioDataInclusao_To, AV66TFInformacaoNome, AV67TFInformacaoNome_Sel, AV68TFHipoteseTratamentoNome, AV69TFHipoteseTratamentoNome_Sel, AV75TFDocumentoId, AV76TFDocumentoId_To, AV77TFDocumentoNome, AV78TFDocumentoNome_Sel, AV79TFDocDicionarioTipoTransfInterGarantia, AV80TFDocDicionarioTipoTransfInterGarantia_Sel, AV109Pgmname, AV13OrderedBy, AV14OrderedDsc, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV72IsAuthorized_InformacaoNome, AV73IsAuthorized_HipoteseTratamentoNome, AV61IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV27TFDocDicionarioId, AV28TFDocDicionarioId_To, AV31TFInformacaoId, AV32TFInformacaoId_To, AV62TFHipoteseTratamentoId, AV63TFHipoteseTratamentoId_To, AV36TFDocDicionarioSensivel_Sel, AV37TFDocDicionarioPodeEliminar_Sel, AV82TFDocDicionarioTransfInter_Sel, AV40TFDocDicionarioFinalidade, AV41TFDocDicionarioFinalidade_Sel, AV42TFDocDicionarioDataInclusao, AV43TFDocDicionarioDataInclusao_To, AV66TFInformacaoNome, AV67TFInformacaoNome_Sel, AV68TFHipoteseTratamentoNome, AV69TFHipoteseTratamentoNome_Sel, AV75TFDocumentoId, AV76TFDocumentoId_To, AV77TFDocumentoNome, AV78TFDocumentoNome_Sel, AV79TFDocDicionarioTipoTransfInterGarantia, AV80TFDocDicionarioTipoTransfInterGarantia_Sel, AV109Pgmname, AV13OrderedBy, AV14OrderedDsc, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV72IsAuthorized_InformacaoNome, AV73IsAuthorized_HipoteseTratamentoNome, AV61IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV27TFDocDicionarioId, AV28TFDocDicionarioId_To, AV31TFInformacaoId, AV32TFInformacaoId_To, AV62TFHipoteseTratamentoId, AV63TFHipoteseTratamentoId_To, AV36TFDocDicionarioSensivel_Sel, AV37TFDocDicionarioPodeEliminar_Sel, AV82TFDocDicionarioTransfInter_Sel, AV40TFDocDicionarioFinalidade, AV41TFDocDicionarioFinalidade_Sel, AV42TFDocDicionarioDataInclusao, AV43TFDocDicionarioDataInclusao_To, AV66TFInformacaoNome, AV67TFInformacaoNome_Sel, AV68TFHipoteseTratamentoNome, AV69TFHipoteseTratamentoNome_Sel, AV75TFDocumentoId, AV76TFDocumentoId_To, AV77TFDocumentoNome, AV78TFDocumentoNome_Sel, AV79TFDocDicionarioTipoTransfInterGarantia, AV80TFDocDicionarioTipoTransfInterGarantia_Sel, AV109Pgmname, AV13OrderedBy, AV14OrderedDsc, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV72IsAuthorized_InformacaoNome, AV73IsAuthorized_HipoteseTratamentoNome, AV61IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV109Pgmname = "DocDicionarioWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_40_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_40_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP330( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16332 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV59AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV47DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_40"), ",", "."));
            AV44DDO_DocDicionarioDataInclusaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_DOCDICIONARIODATAINCLUSAOAUXDATE"), 0);
            AV45DDO_DocDicionarioDataInclusaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_DOCDICIONARIODATAINCLUSAOAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Infinitescrolling = cgiGet( "GRID_EMPOWERER_Infinitescrolling");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            AV46DDO_DocDicionarioDataInclusaoAuxDateText = cgiGet( edtavDdo_docdicionariodatainclusaoauxdatetext_Internalname);
            AssignAttri("", false, "AV46DDO_DocDicionarioDataInclusaoAuxDateText", AV46DDO_DocDicionarioDataInclusaoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E16332 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16332( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFDOCDICIONARIODATAINCLUSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_docdicionariodatainclusaoauxdatetext_Internalname});
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV59AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV60AGExportDataItem.gxTpr_Title = "Excel";
         AV60AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV60AGExportDataItem.gxTpr_Eventkey = "Export";
         AV60AGExportDataItem.gxTpr_Isdivider = false;
         AV59AGExportData.Add(AV60AGExportDataItem, 0);
         AV60AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV60AGExportDataItem.gxTpr_Title = "PDF";
         AV60AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV60AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV60AGExportDataItem.gxTpr_Isdivider = false;
         AV59AGExportData.Add(AV60AGExportDataItem, 0);
         GXt_boolean1 = AV72IsAuthorized_InformacaoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "informacaoview_Execute", out  GXt_boolean1) ;
         AV72IsAuthorized_InformacaoNome = GXt_boolean1;
         AssignAttri("", false, "AV72IsAuthorized_InformacaoNome", AV72IsAuthorized_InformacaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INFORMACAONOME", GetSecureSignedToken( "", AV72IsAuthorized_InformacaoNome, context));
         GXt_boolean1 = AV73IsAuthorized_HipoteseTratamentoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "hipotesetratamentoview_Execute", out  GXt_boolean1) ;
         AV73IsAuthorized_HipoteseTratamentoNome = GXt_boolean1;
         AssignAttri("", false, "AV73IsAuthorized_HipoteseTratamentoNome", AV73IsAuthorized_HipoteseTratamentoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HIPOTESETRATAMENTONOME", GetSecureSignedToken( "", AV73IsAuthorized_HipoteseTratamentoNome, context));
         AV48GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV49GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV48GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Doc Dicionario";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV47DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV47DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
      }

      protected void E17332( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV23Session.Get("DocDicionarioWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("DocDicionarioWWColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtDocDicionarioId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocDicionarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtInformacaoId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtInformacaoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtInformacaoId_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtHipoteseTratamentoId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHipoteseTratamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHipoteseTratamentoId_Visible), 5, 0), !bGXsfl_40_Refreshing);
         chkDocDicionarioSensivel.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocDicionarioSensivel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocDicionarioSensivel.Visible), 5, 0), !bGXsfl_40_Refreshing);
         chkDocDicionarioPodeEliminar.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocDicionarioPodeEliminar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocDicionarioPodeEliminar.Visible), 5, 0), !bGXsfl_40_Refreshing);
         chkDocDicionarioTransfInter.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocDicionarioTransfInter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocDicionarioTransfInter.Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtDocDicionarioFinalidade_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocDicionarioFinalidade_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioFinalidade_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtDocDicionarioDataInclusao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocDicionarioDataInclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioDataInclusao_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtInformacaoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtInformacaoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtInformacaoNome_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtHipoteseTratamentoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHipoteseTratamentoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHipoteseTratamentoNome_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtDocumentoId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtDocumentoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocumentoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoNome_Visible), 5, 0), !bGXsfl_40_Refreshing);
         edtDocDicionarioTipoTransfInterGa_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocDicionarioTipoTransfInterGa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioTipoTransfInterGa_Visible), 5, 0), !bGXsfl_40_Refreshing);
         AV85Docdicionariowwds_1_filterfulltext = AV16FilterFullText;
         AV86Docdicionariowwds_2_tfdocdicionarioid = AV27TFDocDicionarioId;
         AV87Docdicionariowwds_3_tfdocdicionarioid_to = AV28TFDocDicionarioId_To;
         AV88Docdicionariowwds_4_tfinformacaoid = AV31TFInformacaoId;
         AV89Docdicionariowwds_5_tfinformacaoid_to = AV32TFInformacaoId_To;
         AV90Docdicionariowwds_6_tfhipotesetratamentoid = AV62TFHipoteseTratamentoId;
         AV91Docdicionariowwds_7_tfhipotesetratamentoid_to = AV63TFHipoteseTratamentoId_To;
         AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV36TFDocDicionarioSensivel_Sel;
         AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV37TFDocDicionarioPodeEliminar_Sel;
         AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV82TFDocDicionarioTransfInter_Sel;
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = AV40TFDocDicionarioFinalidade;
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV41TFDocDicionarioFinalidade_Sel;
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = AV42TFDocDicionarioDataInclusao;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV43TFDocDicionarioDataInclusao_To;
         AV99Docdicionariowwds_15_tfinformacaonome = AV66TFInformacaoNome;
         AV100Docdicionariowwds_16_tfinformacaonome_sel = AV67TFInformacaoNome_Sel;
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = AV68TFHipoteseTratamentoNome;
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV69TFHipoteseTratamentoNome_Sel;
         AV103Docdicionariowwds_19_tfdocumentoid = AV75TFDocumentoId;
         AV104Docdicionariowwds_20_tfdocumentoid_to = AV76TFDocumentoId_To;
         AV105Docdicionariowwds_21_tfdocumentonome = AV77TFDocumentoNome;
         AV106Docdicionariowwds_22_tfdocumentonome_sel = AV78TFDocumentoNome_Sel;
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV79TFDocDicionarioTipoTransfInterGarantia;
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV80TFDocDicionarioTipoTransfInterGarantia_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13332( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioId") == 0 )
            {
               AV27TFDocDicionarioId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV27TFDocDicionarioId", StringUtil.LTrimStr( (decimal)(AV27TFDocDicionarioId), 8, 0));
               AV28TFDocDicionarioId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV28TFDocDicionarioId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocDicionarioId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "InformacaoId") == 0 )
            {
               AV31TFInformacaoId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFInformacaoId", StringUtil.LTrimStr( (decimal)(AV31TFInformacaoId), 8, 0));
               AV32TFInformacaoId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFInformacaoId_To", StringUtil.LTrimStr( (decimal)(AV32TFInformacaoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HipoteseTratamentoId") == 0 )
            {
               AV62TFHipoteseTratamentoId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV62TFHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV62TFHipoteseTratamentoId), 8, 0));
               AV63TFHipoteseTratamentoId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV63TFHipoteseTratamentoId_To", StringUtil.LTrimStr( (decimal)(AV63TFHipoteseTratamentoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioSensivel") == 0 )
            {
               AV36TFDocDicionarioSensivel_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV36TFDocDicionarioSensivel_Sel", StringUtil.Str( (decimal)(AV36TFDocDicionarioSensivel_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioPodeEliminar") == 0 )
            {
               AV37TFDocDicionarioPodeEliminar_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV37TFDocDicionarioPodeEliminar_Sel", StringUtil.Str( (decimal)(AV37TFDocDicionarioPodeEliminar_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioTransfInter") == 0 )
            {
               AV82TFDocDicionarioTransfInter_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV82TFDocDicionarioTransfInter_Sel", StringUtil.Str( (decimal)(AV82TFDocDicionarioTransfInter_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioFinalidade") == 0 )
            {
               AV40TFDocDicionarioFinalidade = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFDocDicionarioFinalidade", AV40TFDocDicionarioFinalidade);
               AV41TFDocDicionarioFinalidade_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFDocDicionarioFinalidade_Sel", AV41TFDocDicionarioFinalidade_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioDataInclusao") == 0 )
            {
               AV42TFDocDicionarioDataInclusao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV42TFDocDicionarioDataInclusao", context.localUtil.Format(AV42TFDocDicionarioDataInclusao, "99/99/99"));
               AV43TFDocDicionarioDataInclusao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV43TFDocDicionarioDataInclusao_To", context.localUtil.Format(AV43TFDocDicionarioDataInclusao_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "InformacaoNome") == 0 )
            {
               AV66TFInformacaoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFInformacaoNome", AV66TFInformacaoNome);
               AV67TFInformacaoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFInformacaoNome_Sel", AV67TFInformacaoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HipoteseTratamentoNome") == 0 )
            {
               AV68TFHipoteseTratamentoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV68TFHipoteseTratamentoNome", AV68TFHipoteseTratamentoNome);
               AV69TFHipoteseTratamentoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFHipoteseTratamentoNome_Sel", AV69TFHipoteseTratamentoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoId") == 0 )
            {
               AV75TFDocumentoId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV75TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV75TFDocumentoId), 8, 0));
               AV76TFDocumentoId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV76TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV76TFDocumentoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoNome") == 0 )
            {
               AV77TFDocumentoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV77TFDocumentoNome", AV77TFDocumentoNome);
               AV78TFDocumentoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV78TFDocumentoNome_Sel", AV78TFDocumentoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocDicionarioTipoTransfInterGarantia") == 0 )
            {
               AV79TFDocDicionarioTipoTransfInterGarantia = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV79TFDocDicionarioTipoTransfInterGarantia", AV79TFDocDicionarioTipoTransfInterGarantia);
               AV80TFDocDicionarioTipoTransfInterGarantia_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV80TFDocDicionarioTipoTransfInterGarantia_Sel", AV80TFDocDicionarioTipoTransfInterGarantia_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18332( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV54Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV54Update);
         if ( AV55IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docdicionario.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A98DocDicionarioId,8,0));
            edtavUpdate_Link = formatLink("docdicionario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV56Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV56Delete);
         if ( AV57IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docdicionario.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A98DocDicionarioId,8,0));
            edtavDelete_Link = formatLink("docdicionario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV72IsAuthorized_InformacaoNome )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "informacaoview.aspx"+UrlEncode(StringUtil.LTrimStr(A69InformacaoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtInformacaoNome_Link = formatLink("informacaoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV73IsAuthorized_HipoteseTratamentoNome )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "hipotesetratamentoview.aspx"+UrlEncode(StringUtil.LTrimStr(A72HipoteseTratamentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtHipoteseTratamentoNome_Link = formatLink("hipotesetratamentoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 40;
         }
         sendrow_402( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
         {
            context.DoAjaxLoad(40, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E14332( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "DocDicionarioWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11332( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("DocDicionarioWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV109Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("DocDicionarioWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "DocDicionarioWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV25ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV109Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV11GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E15332( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV61IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docdicionario.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            CallWebObject(formatLink("docdicionario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12332( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioId",  "",  "Dicionario Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "InformacaoId",  "",  "da Informação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "HipoteseTratamentoId",  "",  "de Tratamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioSensivel",  "",  "Sensível?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioPodeEliminar",  "",  "Eliminar?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioTransfInter",  "",  "Internacional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioFinalidade",  "",  "Finalidade",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioDataInclusao",  "",  "de Inclusão",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "InformacaoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "HipoteseTratamentoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocumentoId",  "",  "Id do Documento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocumentoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "DocDicionarioTipoTransfInterGarantia",  "",  "Transferência internacional",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocDicionarioWWColumnsSelector", out  GXt_char3) ;
         AV20UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV55IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docdicionario_Update", out  GXt_boolean1) ;
         AV55IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV55IsAuthorized_Update", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         if ( ! ( AV55IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
         GXt_boolean1 = AV57IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docdicionario_Delete", out  GXt_boolean1) ;
         AV57IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV57IsAuthorized_Delete", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         if ( ! ( AV57IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
         GXt_boolean1 = AV61IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docdicionario_Insert", out  GXt_boolean1) ;
         AV61IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV61IsAuthorized_Insert", AV61IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV61IsAuthorized_Insert, context));
         if ( ! ( AV61IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "DocDicionarioWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFDocDicionarioId = 0;
         AssignAttri("", false, "AV27TFDocDicionarioId", StringUtil.LTrimStr( (decimal)(AV27TFDocDicionarioId), 8, 0));
         AV28TFDocDicionarioId_To = 0;
         AssignAttri("", false, "AV28TFDocDicionarioId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocDicionarioId_To), 8, 0));
         AV31TFInformacaoId = 0;
         AssignAttri("", false, "AV31TFInformacaoId", StringUtil.LTrimStr( (decimal)(AV31TFInformacaoId), 8, 0));
         AV32TFInformacaoId_To = 0;
         AssignAttri("", false, "AV32TFInformacaoId_To", StringUtil.LTrimStr( (decimal)(AV32TFInformacaoId_To), 8, 0));
         AV62TFHipoteseTratamentoId = 0;
         AssignAttri("", false, "AV62TFHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV62TFHipoteseTratamentoId), 8, 0));
         AV63TFHipoteseTratamentoId_To = 0;
         AssignAttri("", false, "AV63TFHipoteseTratamentoId_To", StringUtil.LTrimStr( (decimal)(AV63TFHipoteseTratamentoId_To), 8, 0));
         AV36TFDocDicionarioSensivel_Sel = 0;
         AssignAttri("", false, "AV36TFDocDicionarioSensivel_Sel", StringUtil.Str( (decimal)(AV36TFDocDicionarioSensivel_Sel), 1, 0));
         AV37TFDocDicionarioPodeEliminar_Sel = 0;
         AssignAttri("", false, "AV37TFDocDicionarioPodeEliminar_Sel", StringUtil.Str( (decimal)(AV37TFDocDicionarioPodeEliminar_Sel), 1, 0));
         AV82TFDocDicionarioTransfInter_Sel = 0;
         AssignAttri("", false, "AV82TFDocDicionarioTransfInter_Sel", StringUtil.Str( (decimal)(AV82TFDocDicionarioTransfInter_Sel), 1, 0));
         AV40TFDocDicionarioFinalidade = "";
         AssignAttri("", false, "AV40TFDocDicionarioFinalidade", AV40TFDocDicionarioFinalidade);
         AV41TFDocDicionarioFinalidade_Sel = "";
         AssignAttri("", false, "AV41TFDocDicionarioFinalidade_Sel", AV41TFDocDicionarioFinalidade_Sel);
         AV42TFDocDicionarioDataInclusao = DateTime.MinValue;
         AssignAttri("", false, "AV42TFDocDicionarioDataInclusao", context.localUtil.Format(AV42TFDocDicionarioDataInclusao, "99/99/99"));
         AV43TFDocDicionarioDataInclusao_To = DateTime.MinValue;
         AssignAttri("", false, "AV43TFDocDicionarioDataInclusao_To", context.localUtil.Format(AV43TFDocDicionarioDataInclusao_To, "99/99/99"));
         AV66TFInformacaoNome = "";
         AssignAttri("", false, "AV66TFInformacaoNome", AV66TFInformacaoNome);
         AV67TFInformacaoNome_Sel = "";
         AssignAttri("", false, "AV67TFInformacaoNome_Sel", AV67TFInformacaoNome_Sel);
         AV68TFHipoteseTratamentoNome = "";
         AssignAttri("", false, "AV68TFHipoteseTratamentoNome", AV68TFHipoteseTratamentoNome);
         AV69TFHipoteseTratamentoNome_Sel = "";
         AssignAttri("", false, "AV69TFHipoteseTratamentoNome_Sel", AV69TFHipoteseTratamentoNome_Sel);
         AV75TFDocumentoId = 0;
         AssignAttri("", false, "AV75TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV75TFDocumentoId), 8, 0));
         AV76TFDocumentoId_To = 0;
         AssignAttri("", false, "AV76TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV76TFDocumentoId_To), 8, 0));
         AV77TFDocumentoNome = "";
         AssignAttri("", false, "AV77TFDocumentoNome", AV77TFDocumentoNome);
         AV78TFDocumentoNome_Sel = "";
         AssignAttri("", false, "AV78TFDocumentoNome_Sel", AV78TFDocumentoNome_Sel);
         AV79TFDocDicionarioTipoTransfInterGarantia = "";
         AssignAttri("", false, "AV79TFDocDicionarioTipoTransfInterGarantia", AV79TFDocDicionarioTipoTransfInterGarantia);
         AV80TFDocDicionarioTipoTransfInterGarantia_Sel = "";
         AssignAttri("", false, "AV80TFDocDicionarioTipoTransfInterGarantia_Sel", AV80TFDocDicionarioTipoTransfInterGarantia_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV109Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV109Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV109Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV110GXV1 = 1;
         while ( AV110GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV110GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOID") == 0 )
            {
               AV27TFDocDicionarioId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV27TFDocDicionarioId", StringUtil.LTrimStr( (decimal)(AV27TFDocDicionarioId), 8, 0));
               AV28TFDocDicionarioId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV28TFDocDicionarioId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocDicionarioId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINFORMACAOID") == 0 )
            {
               AV31TFInformacaoId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFInformacaoId", StringUtil.LTrimStr( (decimal)(AV31TFInformacaoId), 8, 0));
               AV32TFInformacaoId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFInformacaoId_To", StringUtil.LTrimStr( (decimal)(AV32TFInformacaoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTOID") == 0 )
            {
               AV62TFHipoteseTratamentoId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV62TFHipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV62TFHipoteseTratamentoId), 8, 0));
               AV63TFHipoteseTratamentoId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV63TFHipoteseTratamentoId_To", StringUtil.LTrimStr( (decimal)(AV63TFHipoteseTratamentoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOSENSIVEL_SEL") == 0 )
            {
               AV36TFDocDicionarioSensivel_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV36TFDocDicionarioSensivel_Sel", StringUtil.Str( (decimal)(AV36TFDocDicionarioSensivel_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOPODEELIMINAR_SEL") == 0 )
            {
               AV37TFDocDicionarioPodeEliminar_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV37TFDocDicionarioPodeEliminar_Sel", StringUtil.Str( (decimal)(AV37TFDocDicionarioPodeEliminar_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTRANSFINTER_SEL") == 0 )
            {
               AV82TFDocDicionarioTransfInter_Sel = (short)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV82TFDocDicionarioTransfInter_Sel", StringUtil.Str( (decimal)(AV82TFDocDicionarioTransfInter_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE") == 0 )
            {
               AV40TFDocDicionarioFinalidade = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFDocDicionarioFinalidade", AV40TFDocDicionarioFinalidade);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE_SEL") == 0 )
            {
               AV41TFDocDicionarioFinalidade_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFDocDicionarioFinalidade_Sel", AV41TFDocDicionarioFinalidade_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIODATAINCLUSAO") == 0 )
            {
               AV42TFDocDicionarioDataInclusao = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV42TFDocDicionarioDataInclusao", context.localUtil.Format(AV42TFDocDicionarioDataInclusao, "99/99/99"));
               AV43TFDocDicionarioDataInclusao_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV43TFDocDicionarioDataInclusao_To", context.localUtil.Format(AV43TFDocDicionarioDataInclusao_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME") == 0 )
            {
               AV66TFInformacaoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFInformacaoNome", AV66TFInformacaoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME_SEL") == 0 )
            {
               AV67TFInformacaoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFInformacaoNome_Sel", AV67TFInformacaoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME") == 0 )
            {
               AV68TFHipoteseTratamentoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFHipoteseTratamentoNome", AV68TFHipoteseTratamentoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME_SEL") == 0 )
            {
               AV69TFHipoteseTratamentoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFHipoteseTratamentoNome_Sel", AV69TFHipoteseTratamentoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV75TFDocumentoId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV75TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV75TFDocumentoId), 8, 0));
               AV76TFDocumentoId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV76TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV76TFDocumentoId_To), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV77TFDocumentoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFDocumentoNome", AV77TFDocumentoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV78TFDocumentoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFDocumentoNome_Sel", AV78TFDocumentoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA") == 0 )
            {
               AV79TFDocDicionarioTipoTransfInterGarantia = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFDocDicionarioTipoTransfInterGarantia", AV79TFDocDicionarioTipoTransfInterGarantia);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL") == 0 )
            {
               AV80TFDocDicionarioTipoTransfInterGarantia_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFDocDicionarioTipoTransfInterGarantia_Sel", AV80TFDocDicionarioTipoTransfInterGarantia_Sel);
            }
            AV110GXV1 = (int)(AV110GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFDocDicionarioFinalidade_Sel)),  AV41TFDocDicionarioFinalidade_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFInformacaoNome_Sel)),  AV67TFInformacaoNome_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFHipoteseTratamentoNome_Sel)),  AV69TFHipoteseTratamentoNome_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFDocumentoNome_Sel)),  AV78TFDocumentoNome_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFDocDicionarioTipoTransfInterGarantia_Sel)),  AV80TFDocDicionarioTipoTransfInterGarantia_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|||"+((0==AV36TFDocDicionarioSensivel_Sel) ? "" : StringUtil.Str( (decimal)(AV36TFDocDicionarioSensivel_Sel), 1, 0))+"|"+((0==AV37TFDocDicionarioPodeEliminar_Sel) ? "" : StringUtil.Str( (decimal)(AV37TFDocDicionarioPodeEliminar_Sel), 1, 0))+"|"+((0==AV82TFDocDicionarioTransfInter_Sel) ? "" : StringUtil.Str( (decimal)(AV82TFDocDicionarioTransfInter_Sel), 1, 0))+"|"+GXt_char3+"||"+GXt_char5+"|"+GXt_char6+"||"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFDocDicionarioFinalidade)),  AV40TFDocDicionarioFinalidade, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFInformacaoNome)),  AV66TFInformacaoNome, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFHipoteseTratamentoNome)),  AV68TFHipoteseTratamentoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFDocumentoNome)),  AV77TFDocumentoNome, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFDocDicionarioTipoTransfInterGarantia)),  AV79TFDocDicionarioTipoTransfInterGarantia, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV27TFDocDicionarioId) ? "" : StringUtil.Str( (decimal)(AV27TFDocDicionarioId), 8, 0))+"|"+((0==AV31TFInformacaoId) ? "" : StringUtil.Str( (decimal)(AV31TFInformacaoId), 8, 0))+"|"+((0==AV62TFHipoteseTratamentoId) ? "" : StringUtil.Str( (decimal)(AV62TFHipoteseTratamentoId), 8, 0))+"||||"+GXt_char8+"|"+((DateTime.MinValue==AV42TFDocDicionarioDataInclusao) ? "" : context.localUtil.DToC( AV42TFDocDicionarioDataInclusao, 2, "/"))+"|"+GXt_char7+"|"+GXt_char6+"|"+((0==AV75TFDocumentoId) ? "" : StringUtil.Str( (decimal)(AV75TFDocumentoId), 8, 0))+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV28TFDocDicionarioId_To) ? "" : StringUtil.Str( (decimal)(AV28TFDocDicionarioId_To), 8, 0))+"|"+((0==AV32TFInformacaoId_To) ? "" : StringUtil.Str( (decimal)(AV32TFInformacaoId_To), 8, 0))+"|"+((0==AV63TFHipoteseTratamentoId_To) ? "" : StringUtil.Str( (decimal)(AV63TFHipoteseTratamentoId_To), 8, 0))+"|||||"+((DateTime.MinValue==AV43TFDocDicionarioDataInclusao_To) ? "" : context.localUtil.DToC( AV43TFDocDicionarioDataInclusao_To, 2, "/"))+"|||"+((0==AV76TFDocumentoId_To) ? "" : StringUtil.Str( (decimal)(AV76TFDocumentoId_To), 8, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV109Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIOID",  "",  !((0==AV27TFDocDicionarioId)&&(0==AV28TFDocDicionarioId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFDocDicionarioId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFDocDicionarioId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFINFORMACAOID",  "",  !((0==AV31TFInformacaoId)&&(0==AV32TFInformacaoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFInformacaoId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFInformacaoId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFHIPOTESETRATAMENTOID",  "",  !((0==AV62TFHipoteseTratamentoId)&&(0==AV63TFHipoteseTratamentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV62TFHipoteseTratamentoId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV63TFHipoteseTratamentoId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIOSENSIVEL_SEL",  "",  !(0==AV36TFDocDicionarioSensivel_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFDocDicionarioSensivel_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIOPODEELIMINAR_SEL",  "",  !(0==AV37TFDocDicionarioPodeEliminar_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFDocDicionarioPodeEliminar_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIOTRANSFINTER_SEL",  "",  !(0==AV82TFDocDicionarioTransfInter_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV82TFDocDicionarioTransfInter_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIOFINALIDADE",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFDocDicionarioFinalidade)),  0,  AV40TFDocDicionarioFinalidade,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFDocDicionarioFinalidade_Sel)),  AV41TFDocDicionarioFinalidade_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIODATAINCLUSAO",  "",  !((DateTime.MinValue==AV42TFDocDicionarioDataInclusao)&&(DateTime.MinValue==AV43TFDocDicionarioDataInclusao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV42TFDocDicionarioDataInclusao, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV43TFDocDicionarioDataInclusao_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFINFORMACAONOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFInformacaoNome)),  0,  AV66TFInformacaoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFInformacaoNome_Sel)),  AV67TFInformacaoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFHIPOTESETRATAMENTONOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFHipoteseTratamentoNome)),  0,  AV68TFHipoteseTratamentoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFHipoteseTratamentoNome_Sel)),  AV69TFHipoteseTratamentoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTOID",  "",  !((0==AV75TFDocumentoId)&&(0==AV76TFDocumentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV75TFDocumentoId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV76TFDocumentoId_To), 8, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCUMENTONOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFDocumentoNome)),  0,  AV77TFDocumentoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFDocumentoNome_Sel)),  AV78TFDocumentoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFDocDicionarioTipoTransfInterGarantia)),  0,  AV79TFDocDicionarioTipoTransfInterGarantia,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFDocDicionarioTipoTransfInterGarantia_Sel)),  AV80TFDocDicionarioTipoTransfInterGarantia_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV109Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV109Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "DocDicionario";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new docdicionariowwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV18ErrorMessage);
         }
      }

      protected void S212( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("docdicionariowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_332( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_30_332( true) ;
         }
         else
         {
            wb_table2_30_332( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_332e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_332e( true) ;
         }
         else
         {
            wb_table1_25_332e( false) ;
         }
      }

      protected void wb_table2_30_332( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_40_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_DocDicionarioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_332e( true) ;
         }
         else
         {
            wb_table2_30_332e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA332( ) ;
         WS332( ) ;
         WE332( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231241727652", true, true);
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
         context.AddJavascriptSource("docdicionarioww.js", "?20231241727653", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_40_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_40_idx;
         edtDocDicionarioId_Internalname = "DOCDICIONARIOID_"+sGXsfl_40_idx;
         edtInformacaoId_Internalname = "INFORMACAOID_"+sGXsfl_40_idx;
         edtHipoteseTratamentoId_Internalname = "HIPOTESETRATAMENTOID_"+sGXsfl_40_idx;
         chkDocDicionarioSensivel_Internalname = "DOCDICIONARIOSENSIVEL_"+sGXsfl_40_idx;
         chkDocDicionarioPodeEliminar_Internalname = "DOCDICIONARIOPODEELIMINAR_"+sGXsfl_40_idx;
         chkDocDicionarioTransfInter_Internalname = "DOCDICIONARIOTRANSFINTER_"+sGXsfl_40_idx;
         edtDocDicionarioFinalidade_Internalname = "DOCDICIONARIOFINALIDADE_"+sGXsfl_40_idx;
         edtDocDicionarioDataInclusao_Internalname = "DOCDICIONARIODATAINCLUSAO_"+sGXsfl_40_idx;
         edtInformacaoNome_Internalname = "INFORMACAONOME_"+sGXsfl_40_idx;
         edtHipoteseTratamentoNome_Internalname = "HIPOTESETRATAMENTONOME_"+sGXsfl_40_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_40_idx;
         edtDocumentoNome_Internalname = "DOCUMENTONOME_"+sGXsfl_40_idx;
         edtDocDicionarioTipoTransfInterGa_Internalname = "DOCDICIONARIOTIPOTRANSFINTERGA_"+sGXsfl_40_idx;
      }

      protected void SubsflControlProps_fel_402( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_40_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_40_fel_idx;
         edtDocDicionarioId_Internalname = "DOCDICIONARIOID_"+sGXsfl_40_fel_idx;
         edtInformacaoId_Internalname = "INFORMACAOID_"+sGXsfl_40_fel_idx;
         edtHipoteseTratamentoId_Internalname = "HIPOTESETRATAMENTOID_"+sGXsfl_40_fel_idx;
         chkDocDicionarioSensivel_Internalname = "DOCDICIONARIOSENSIVEL_"+sGXsfl_40_fel_idx;
         chkDocDicionarioPodeEliminar_Internalname = "DOCDICIONARIOPODEELIMINAR_"+sGXsfl_40_fel_idx;
         chkDocDicionarioTransfInter_Internalname = "DOCDICIONARIOTRANSFINTER_"+sGXsfl_40_fel_idx;
         edtDocDicionarioFinalidade_Internalname = "DOCDICIONARIOFINALIDADE_"+sGXsfl_40_fel_idx;
         edtDocDicionarioDataInclusao_Internalname = "DOCDICIONARIODATAINCLUSAO_"+sGXsfl_40_fel_idx;
         edtInformacaoNome_Internalname = "INFORMACAONOME_"+sGXsfl_40_fel_idx;
         edtHipoteseTratamentoNome_Internalname = "HIPOTESETRATAMENTONOME_"+sGXsfl_40_fel_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_40_fel_idx;
         edtDocumentoNome_Internalname = "DOCUMENTONOME_"+sGXsfl_40_fel_idx;
         edtDocDicionarioTipoTransfInterGa_Internalname = "DOCDICIONARIOTIPOTRANSFINTERGA_"+sGXsfl_40_fel_idx;
      }

      protected void sendrow_402( )
      {
         SubsflControlProps_402( ) ;
         WB330( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_40_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_40_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_40_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV54Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV56Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocDicionarioId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocDicionarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocDicionarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocDicionarioId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtInformacaoId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInformacaoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69InformacaoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69InformacaoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInformacaoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtInformacaoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtHipoteseTratamentoId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHipoteseTratamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A72HipoteseTratamentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A72HipoteseTratamentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHipoteseTratamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHipoteseTratamentoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocDicionarioSensivel.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCDICIONARIOSENSIVEL_" + sGXsfl_40_idx;
            chkDocDicionarioSensivel.Name = GXCCtl;
            chkDocDicionarioSensivel.WebTags = "";
            chkDocDicionarioSensivel.Caption = "";
            AssignProp("", false, chkDocDicionarioSensivel_Internalname, "TitleCaption", chkDocDicionarioSensivel.Caption, !bGXsfl_40_Refreshing);
            chkDocDicionarioSensivel.CheckedValue = "false";
            A99DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( A99DocDicionarioSensivel));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocDicionarioSensivel_Internalname,StringUtil.BoolToStr( A99DocDicionarioSensivel),(string)"",(string)"",chkDocDicionarioSensivel.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocDicionarioPodeEliminar.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCDICIONARIOPODEELIMINAR_" + sGXsfl_40_idx;
            chkDocDicionarioPodeEliminar.Name = GXCCtl;
            chkDocDicionarioPodeEliminar.WebTags = "";
            chkDocDicionarioPodeEliminar.Caption = "";
            AssignProp("", false, chkDocDicionarioPodeEliminar_Internalname, "TitleCaption", chkDocDicionarioPodeEliminar.Caption, !bGXsfl_40_Refreshing);
            chkDocDicionarioPodeEliminar.CheckedValue = "false";
            A100DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( A100DocDicionarioPodeEliminar));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocDicionarioPodeEliminar_Internalname,StringUtil.BoolToStr( A100DocDicionarioPodeEliminar),(string)"",(string)"",chkDocDicionarioPodeEliminar.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocDicionarioTransfInter.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCDICIONARIOTRANSFINTER_" + sGXsfl_40_idx;
            chkDocDicionarioTransfInter.Name = GXCCtl;
            chkDocDicionarioTransfInter.WebTags = "";
            chkDocDicionarioTransfInter.Caption = "";
            AssignProp("", false, chkDocDicionarioTransfInter_Internalname, "TitleCaption", chkDocDicionarioTransfInter.Caption, !bGXsfl_40_Refreshing);
            chkDocDicionarioTransfInter.CheckedValue = "false";
            A101DocDicionarioTransfInter = StringUtil.StrToBool( StringUtil.BoolToStr( A101DocDicionarioTransfInter));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocDicionarioTransfInter_Internalname,StringUtil.BoolToStr( A101DocDicionarioTransfInter),(string)"",(string)"",chkDocDicionarioTransfInter.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtDocDicionarioFinalidade_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocDicionarioFinalidade_Internalname,(string)A102DocDicionarioFinalidade,(string)A102DocDicionarioFinalidade,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocDicionarioFinalidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocDicionarioFinalidade_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)10000,(short)0,(short)0,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocDicionarioDataInclusao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocDicionarioDataInclusao_Internalname,context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"),context.localUtil.Format( A103DocDicionarioDataInclusao, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocDicionarioDataInclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocDicionarioDataInclusao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtInformacaoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInformacaoNome_Internalname,(string)A70InformacaoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtInformacaoNome_Link,(string)"",(string)"",(string)"",(string)edtInformacaoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtInformacaoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtHipoteseTratamentoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHipoteseTratamentoNome_Internalname,(string)A73HipoteseTratamentoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHipoteseTratamentoNome_Link,(string)"",(string)"",(string)"",(string)edtHipoteseTratamentoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtHipoteseTratamentoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtDocumentoId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDocumentoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtDocumentoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoNome_Internalname,(string)A76DocumentoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDocumentoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtDocDicionarioTipoTransfInterGa_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocDicionarioTipoTransfInterGa_Internalname,(string)A119DocDicionarioTipoTransfInterGa,(string)A119DocDicionarioTipoTransfInterGa,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocDicionarioTipoTransfInterGa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDocDicionarioTipoTransfInterGa_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)10000,(short)0,(short)0,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            send_integrity_lvl_hashes332( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "DOCDICIONARIOSENSIVEL_" + sGXsfl_40_idx;
         chkDocDicionarioSensivel.Name = GXCCtl;
         chkDocDicionarioSensivel.WebTags = "";
         chkDocDicionarioSensivel.Caption = "";
         AssignProp("", false, chkDocDicionarioSensivel_Internalname, "TitleCaption", chkDocDicionarioSensivel.Caption, !bGXsfl_40_Refreshing);
         chkDocDicionarioSensivel.CheckedValue = "false";
         A99DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( A99DocDicionarioSensivel));
         GXCCtl = "DOCDICIONARIOPODEELIMINAR_" + sGXsfl_40_idx;
         chkDocDicionarioPodeEliminar.Name = GXCCtl;
         chkDocDicionarioPodeEliminar.WebTags = "";
         chkDocDicionarioPodeEliminar.Caption = "";
         AssignProp("", false, chkDocDicionarioPodeEliminar_Internalname, "TitleCaption", chkDocDicionarioPodeEliminar.Caption, !bGXsfl_40_Refreshing);
         chkDocDicionarioPodeEliminar.CheckedValue = "false";
         A100DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( A100DocDicionarioPodeEliminar));
         GXCCtl = "DOCDICIONARIOTRANSFINTER_" + sGXsfl_40_idx;
         chkDocDicionarioTransfInter.Name = GXCCtl;
         chkDocDicionarioTransfInter.WebTags = "";
         chkDocDicionarioTransfInter.Caption = "";
         AssignProp("", false, chkDocDicionarioTransfInter_Internalname, "TitleCaption", chkDocDicionarioTransfInter.Caption, !bGXsfl_40_Refreshing);
         chkDocDicionarioTransfInter.CheckedValue = "false";
         A101DocDicionarioTransfInter = StringUtil.StrToBool( StringUtil.BoolToStr( A101DocDicionarioTransfInter));
         /* End function init_web_controls */
      }

      protected void StartGridControl40( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"40\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocDicionarioId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Dicionario Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtInformacaoId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "da Informação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHipoteseTratamentoId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "de Tratamento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocDicionarioSensivel.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Sensível?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocDicionarioPodeEliminar.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Eliminar?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocDicionarioTransfInter.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Internacional") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocDicionarioFinalidade_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Finalidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocDicionarioDataInclusao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "de Inclusão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtInformacaoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHipoteseTratamentoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocumentoId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Id do Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocumentoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocDicionarioTipoTransfInterGa_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Transferência internacional") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV54Update));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV56Delete));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocDicionarioId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69InformacaoId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInformacaoId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72HipoteseTratamentoId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHipoteseTratamentoId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A99DocDicionarioSensivel));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocDicionarioSensivel.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A100DocDicionarioPodeEliminar));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocDicionarioPodeEliminar.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A101DocDicionarioTransfInter));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocDicionarioTransfInter.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A102DocDicionarioFinalidade);
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocDicionarioFinalidade_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocDicionarioDataInclusao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A70InformacaoNome);
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtInformacaoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInformacaoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A73HipoteseTratamentoNome);
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtHipoteseTratamentoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHipoteseTratamentoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocumentoId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A76DocumentoNome);
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocumentoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A119DocDicionarioTipoTransfInterGa);
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocDicionarioTipoTransfInterGa_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtDocDicionarioId_Internalname = "DOCDICIONARIOID";
         edtInformacaoId_Internalname = "INFORMACAOID";
         edtHipoteseTratamentoId_Internalname = "HIPOTESETRATAMENTOID";
         chkDocDicionarioSensivel_Internalname = "DOCDICIONARIOSENSIVEL";
         chkDocDicionarioPodeEliminar_Internalname = "DOCDICIONARIOPODEELIMINAR";
         chkDocDicionarioTransfInter_Internalname = "DOCDICIONARIOTRANSFINTER";
         edtDocDicionarioFinalidade_Internalname = "DOCDICIONARIOFINALIDADE";
         edtDocDicionarioDataInclusao_Internalname = "DOCDICIONARIODATAINCLUSAO";
         edtInformacaoNome_Internalname = "INFORMACAONOME";
         edtHipoteseTratamentoNome_Internalname = "HIPOTESETRATAMENTONOME";
         edtDocumentoId_Internalname = "DOCUMENTOID";
         edtDocumentoNome_Internalname = "DOCUMENTONOME";
         edtDocDicionarioTipoTransfInterGa_Internalname = "DOCDICIONARIOTIPOTRANSFINTERGA";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_docdicionariodatainclusaoauxdatetext_Internalname = "vDDO_DOCDICIONARIODATAINCLUSAOAUXDATETEXT";
         Tfdocdicionariodatainclusao_rangepicker_Internalname = "TFDOCDICIONARIODATAINCLUSAO_RANGEPICKER";
         divDdo_docdicionariodatainclusaoauxdates_Internalname = "DDO_DOCDICIONARIODATAINCLUSAOAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtDocDicionarioTipoTransfInterGa_Jsonclick = "";
         edtDocumentoNome_Jsonclick = "";
         edtDocumentoId_Jsonclick = "";
         edtHipoteseTratamentoNome_Jsonclick = "";
         edtHipoteseTratamentoNome_Link = "";
         edtInformacaoNome_Jsonclick = "";
         edtInformacaoNome_Link = "";
         edtDocDicionarioDataInclusao_Jsonclick = "";
         edtDocDicionarioFinalidade_Jsonclick = "";
         chkDocDicionarioTransfInter.Caption = "";
         chkDocDicionarioPodeEliminar.Caption = "";
         chkDocDicionarioSensivel.Caption = "";
         edtHipoteseTratamentoId_Jsonclick = "";
         edtInformacaoId_Jsonclick = "";
         edtDocDicionarioId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtDocDicionarioTipoTransfInterGa_Visible = -1;
         edtDocumentoNome_Visible = -1;
         edtDocumentoId_Visible = -1;
         edtHipoteseTratamentoNome_Visible = -1;
         edtInformacaoNome_Visible = -1;
         edtDocDicionarioDataInclusao_Visible = -1;
         edtDocDicionarioFinalidade_Visible = -1;
         chkDocDicionarioTransfInter.Visible = -1;
         chkDocDicionarioPodeEliminar.Visible = -1;
         chkDocDicionarioSensivel.Visible = -1;
         edtHipoteseTratamentoId_Visible = -1;
         edtInformacaoId_Visible = -1;
         edtDocDicionarioId_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_docdicionariodatainclusaoauxdatetext_Jsonclick = "";
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Infinitescrolling = "Grid";
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "8.0|8.0|8.0||||||||8.0||";
         Ddo_grid_Datalistproc = "DocDicionarioWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|||||||";
         Ddo_grid_Datalisttype = "|||FixedValues|FixedValues|FixedValues|Dynamic||Dynamic|Dynamic||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|||T|T|T|T||T|T||T|T";
         Ddo_grid_Filterisrange = "T|T|T|||||P|||T||";
         Ddo_grid_Filtertype = "Numeric|Numeric|Numeric||||Character|Date|Character|Character|Numeric|Character|Character";
         Ddo_grid_Includefilter = "T|T|T||||T|T|T|T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5|6|7|8|9|10|11|12|13";
         Ddo_grid_Columnids = "2:DocDicionarioId|3:InformacaoId|4:HipoteseTratamentoId|5:DocDicionarioSensivel|6:DocDicionarioPodeEliminar|7:DocDicionarioTransfInter|8:DocDicionarioFinalidade|9:DocDicionarioDataInclusao|10:InformacaoNome|11:HipoteseTratamentoNome|12:DocumentoId|13:DocumentoNome|14:DocDicionarioTipoTransfInterGarantia";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opções";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Doc Dicionario";
         subGrid_Rows = 50;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13332',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E18332',iparms:[{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV54Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV56Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtInformacaoNome_Link',ctrl:'INFORMACAONOME',prop:'Link'},{av:'edtHipoteseTratamentoNome_Link',ctrl:'HIPOTESETRATAMENTONOME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E14332',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11332',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E15332',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E12332',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV72IsAuthorized_InformacaoNome',fld:'vISAUTHORIZED_INFORMACAONOME',pic:'',hsh:true},{av:'AV73IsAuthorized_HipoteseTratamentoNome',fld:'vISAUTHORIZED_HIPOTESETRATAMENTONOME',pic:'',hsh:true},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFDocDicionarioId',fld:'vTFDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocDicionarioId_To',fld:'vTFDOCDICIONARIOID_TO',pic:'ZZZZZZZ9'},{av:'AV31TFInformacaoId',fld:'vTFINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV32TFInformacaoId_To',fld:'vTFINFORMACAOID_TO',pic:'ZZZZZZZ9'},{av:'AV62TFHipoteseTratamentoId',fld:'vTFHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV63TFHipoteseTratamentoId_To',fld:'vTFHIPOTESETRATAMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV36TFDocDicionarioSensivel_Sel',fld:'vTFDOCDICIONARIOSENSIVEL_SEL',pic:'9'},{av:'AV37TFDocDicionarioPodeEliminar_Sel',fld:'vTFDOCDICIONARIOPODEELIMINAR_SEL',pic:'9'},{av:'AV82TFDocDicionarioTransfInter_Sel',fld:'vTFDOCDICIONARIOTRANSFINTER_SEL',pic:'9'},{av:'AV40TFDocDicionarioFinalidade',fld:'vTFDOCDICIONARIOFINALIDADE',pic:''},{av:'AV41TFDocDicionarioFinalidade_Sel',fld:'vTFDOCDICIONARIOFINALIDADE_SEL',pic:''},{av:'AV42TFDocDicionarioDataInclusao',fld:'vTFDOCDICIONARIODATAINCLUSAO',pic:''},{av:'AV43TFDocDicionarioDataInclusao_To',fld:'vTFDOCDICIONARIODATAINCLUSAO_TO',pic:''},{av:'AV66TFInformacaoNome',fld:'vTFINFORMACAONOME',pic:''},{av:'AV67TFInformacaoNome_Sel',fld:'vTFINFORMACAONOME_SEL',pic:''},{av:'AV68TFHipoteseTratamentoNome',fld:'vTFHIPOTESETRATAMENTONOME',pic:''},{av:'AV69TFHipoteseTratamentoNome_Sel',fld:'vTFHIPOTESETRATAMENTONOME_SEL',pic:''},{av:'AV75TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV76TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV77TFDocumentoNome',fld:'vTFDOCUMENTONOME',pic:''},{av:'AV78TFDocumentoNome_Sel',fld:'vTFDOCUMENTONOME_SEL',pic:''},{av:'AV79TFDocDicionarioTipoTransfInterGarantia',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV80TFDocDicionarioTipoTransfInterGarantia_Sel',fld:'vTFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL',pic:''},{av:'AV109Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocDicionarioId_Visible',ctrl:'DOCDICIONARIOID',prop:'Visible'},{av:'edtInformacaoId_Visible',ctrl:'INFORMACAOID',prop:'Visible'},{av:'edtHipoteseTratamentoId_Visible',ctrl:'HIPOTESETRATAMENTOID',prop:'Visible'},{av:'chkDocDicionarioSensivel.Visible',ctrl:'DOCDICIONARIOSENSIVEL',prop:'Visible'},{av:'chkDocDicionarioPodeEliminar.Visible',ctrl:'DOCDICIONARIOPODEELIMINAR',prop:'Visible'},{av:'chkDocDicionarioTransfInter.Visible',ctrl:'DOCDICIONARIOTRANSFINTER',prop:'Visible'},{av:'edtDocDicionarioFinalidade_Visible',ctrl:'DOCDICIONARIOFINALIDADE',prop:'Visible'},{av:'edtDocDicionarioDataInclusao_Visible',ctrl:'DOCDICIONARIODATAINCLUSAO',prop:'Visible'},{av:'edtInformacaoNome_Visible',ctrl:'INFORMACAONOME',prop:'Visible'},{av:'edtHipoteseTratamentoNome_Visible',ctrl:'HIPOTESETRATAMENTONOME',prop:'Visible'},{av:'edtDocumentoId_Visible',ctrl:'DOCUMENTOID',prop:'Visible'},{av:'edtDocumentoNome_Visible',ctrl:'DOCUMENTONOME',prop:'Visible'},{av:'edtDocDicionarioTipoTransfInterGa_Visible',ctrl:'DOCDICIONARIOTIPOTRANSFINTERGA',prop:'Visible'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV57IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV61IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALID_INFORMACAOID","{handler:'Valid_Informacaoid',iparms:[]");
         setEventMetadata("VALID_INFORMACAOID",",oparms:[]}");
         setEventMetadata("VALID_HIPOTESETRATAMENTOID","{handler:'Valid_Hipotesetratamentoid',iparms:[]");
         setEventMetadata("VALID_HIPOTESETRATAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Docdicionariotipotransfinterga',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV40TFDocDicionarioFinalidade = "";
         AV41TFDocDicionarioFinalidade_Sel = "";
         AV42TFDocDicionarioDataInclusao = DateTime.MinValue;
         AV43TFDocDicionarioDataInclusao_To = DateTime.MinValue;
         AV66TFInformacaoNome = "";
         AV67TFInformacaoNome_Sel = "";
         AV68TFHipoteseTratamentoNome = "";
         AV69TFHipoteseTratamentoNome_Sel = "";
         AV77TFDocumentoNome = "";
         AV78TFDocumentoNome_Sel = "";
         AV79TFDocDicionarioTipoTransfInterGarantia = "";
         AV80TFDocDicionarioTipoTransfInterGarantia_Sel = "";
         AV109Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV45DDO_DocDicionarioDataInclusaoAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44DDO_DocDicionarioDataInclusaoAuxDate = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV46DDO_DocDicionarioDataInclusaoAuxDateText = "";
         ucTfdocdicionariodatainclusao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV85Docdicionariowwds_1_filterfulltext = "";
         AV95Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel = "";
         AV97Docdicionariowwds_13_tfdocdicionariodatainclusao = DateTime.MinValue;
         AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to = DateTime.MinValue;
         AV99Docdicionariowwds_15_tfinformacaonome = "";
         AV100Docdicionariowwds_16_tfinformacaonome_sel = "";
         AV101Docdicionariowwds_17_tfhipotesetratamentonome = "";
         AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel = "";
         AV105Docdicionariowwds_21_tfdocumentonome = "";
         AV106Docdicionariowwds_22_tfdocumentonome_sel = "";
         AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = "";
         AV54Update = "";
         AV56Delete = "";
         A102DocDicionarioFinalidade = "";
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A76DocumentoNome = "";
         A119DocDicionarioTipoTransfInterGa = "";
         GXCCtl = "";
         scmdbuf = "";
         lV85Docdicionariowwds_1_filterfulltext = "";
         lV95Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         lV99Docdicionariowwds_15_tfinformacaonome = "";
         lV101Docdicionariowwds_17_tfhipotesetratamentonome = "";
         lV105Docdicionariowwds_21_tfdocumentonome = "";
         lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         H00332_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         H00332_A76DocumentoNome = new string[] {""} ;
         H00332_n76DocumentoNome = new bool[] {false} ;
         H00332_A75DocumentoId = new int[1] ;
         H00332_A73HipoteseTratamentoNome = new string[] {""} ;
         H00332_A70InformacaoNome = new string[] {""} ;
         H00332_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H00332_A102DocDicionarioFinalidade = new string[] {""} ;
         H00332_A101DocDicionarioTransfInter = new bool[] {false} ;
         H00332_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         H00332_A99DocDicionarioSensivel = new bool[] {false} ;
         H00332_A72HipoteseTratamentoId = new int[1] ;
         H00332_A69InformacaoId = new int[1] ;
         H00332_A98DocDicionarioId = new int[1] ;
         H00333_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV60AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV48GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionarioww__default(),
            new Object[][] {
                new Object[] {
               H00332_A119DocDicionarioTipoTransfInterGa, H00332_A76DocumentoNome, H00332_n76DocumentoNome, H00332_A75DocumentoId, H00332_A73HipoteseTratamentoNome, H00332_A70InformacaoNome, H00332_A103DocDicionarioDataInclusao, H00332_A102DocDicionarioFinalidade, H00332_A101DocDicionarioTransfInter, H00332_A100DocDicionarioPodeEliminar,
               H00332_A99DocDicionarioSensivel, H00332_A72HipoteseTratamentoId, H00332_A69InformacaoId, H00332_A98DocDicionarioId
               }
               , new Object[] {
               H00333_AGRID_nRecordCount
               }
            }
         );
         AV109Pgmname = "DocDicionarioWW";
         /* GeneXus formulas. */
         AV109Pgmname = "DocDicionarioWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV36TFDocDicionarioSensivel_Sel ;
      private short AV37TFDocDicionarioPodeEliminar_Sel ;
      private short AV82TFDocDicionarioTransfInter_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel ;
      private short AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ;
      private short AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_40 ;
      private int subGrid_Rows ;
      private int nGXsfl_40_idx=1 ;
      private int AV27TFDocDicionarioId ;
      private int AV28TFDocDicionarioId_To ;
      private int AV31TFInformacaoId ;
      private int AV32TFInformacaoId_To ;
      private int AV62TFHipoteseTratamentoId ;
      private int AV63TFHipoteseTratamentoId_To ;
      private int AV75TFDocumentoId ;
      private int AV76TFDocumentoId_To ;
      private int bttBtninsert_Visible ;
      private int AV86Docdicionariowwds_2_tfdocdicionarioid ;
      private int AV87Docdicionariowwds_3_tfdocdicionarioid_to ;
      private int AV88Docdicionariowwds_4_tfinformacaoid ;
      private int AV89Docdicionariowwds_5_tfinformacaoid_to ;
      private int AV90Docdicionariowwds_6_tfhipotesetratamentoid ;
      private int AV91Docdicionariowwds_7_tfhipotesetratamentoid_to ;
      private int AV103Docdicionariowwds_19_tfdocumentoid ;
      private int AV104Docdicionariowwds_20_tfdocumentoid_to ;
      private int A98DocDicionarioId ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A75DocumentoId ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtDocDicionarioId_Visible ;
      private int edtInformacaoId_Visible ;
      private int edtHipoteseTratamentoId_Visible ;
      private int edtDocDicionarioFinalidade_Visible ;
      private int edtDocDicionarioDataInclusao_Visible ;
      private int edtInformacaoNome_Visible ;
      private int edtHipoteseTratamentoNome_Visible ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoNome_Visible ;
      private int edtDocDicionarioTipoTransfInterGa_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV110GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_40_idx="0001" ;
      private string AV109Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Infinitescrolling ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_docdicionariodatainclusaoauxdates_Internalname ;
      private string edtavDdo_docdicionariodatainclusaoauxdatetext_Internalname ;
      private string edtavDdo_docdicionariodatainclusaoauxdatetext_Jsonclick ;
      private string Tfdocdicionariodatainclusao_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV54Update ;
      private string edtavUpdate_Internalname ;
      private string AV56Delete ;
      private string edtavDelete_Internalname ;
      private string edtDocDicionarioId_Internalname ;
      private string edtInformacaoId_Internalname ;
      private string edtHipoteseTratamentoId_Internalname ;
      private string chkDocDicionarioSensivel_Internalname ;
      private string chkDocDicionarioPodeEliminar_Internalname ;
      private string chkDocDicionarioTransfInter_Internalname ;
      private string edtDocDicionarioFinalidade_Internalname ;
      private string edtDocDicionarioDataInclusao_Internalname ;
      private string edtInformacaoNome_Internalname ;
      private string edtHipoteseTratamentoNome_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoNome_Internalname ;
      private string edtDocDicionarioTipoTransfInterGa_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string GXCCtl ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtavDelete_Link ;
      private string edtInformacaoNome_Link ;
      private string edtHipoteseTratamentoNome_Link ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_40_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtDocDicionarioId_Jsonclick ;
      private string edtInformacaoId_Jsonclick ;
      private string edtHipoteseTratamentoId_Jsonclick ;
      private string edtDocDicionarioFinalidade_Jsonclick ;
      private string edtDocDicionarioDataInclusao_Jsonclick ;
      private string edtInformacaoNome_Jsonclick ;
      private string edtHipoteseTratamentoNome_Jsonclick ;
      private string edtDocumentoId_Jsonclick ;
      private string edtDocumentoNome_Jsonclick ;
      private string edtDocDicionarioTipoTransfInterGa_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV42TFDocDicionarioDataInclusao ;
      private DateTime AV43TFDocDicionarioDataInclusao_To ;
      private DateTime AV45DDO_DocDicionarioDataInclusaoAuxDateTo ;
      private DateTime AV44DDO_DocDicionarioDataInclusaoAuxDate ;
      private DateTime AV97Docdicionariowwds_13_tfdocdicionariodatainclusao ;
      private DateTime AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to ;
      private DateTime A103DocDicionarioDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV55IsAuthorized_Update ;
      private bool AV57IsAuthorized_Delete ;
      private bool AV72IsAuthorized_InformacaoNome ;
      private bool AV73IsAuthorized_HipoteseTratamentoNome ;
      private bool AV61IsAuthorized_Insert ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A99DocDicionarioSensivel ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A101DocDicionarioTransfInter ;
      private bool n76DocumentoNome ;
      private bool bGXsfl_40_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV95Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string lV95Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV40TFDocDicionarioFinalidade ;
      private string AV41TFDocDicionarioFinalidade_Sel ;
      private string AV66TFInformacaoNome ;
      private string AV67TFInformacaoNome_Sel ;
      private string AV68TFHipoteseTratamentoNome ;
      private string AV69TFHipoteseTratamentoNome_Sel ;
      private string AV77TFDocumentoNome ;
      private string AV78TFDocumentoNome_Sel ;
      private string AV79TFDocDicionarioTipoTransfInterGarantia ;
      private string AV80TFDocDicionarioTipoTransfInterGarantia_Sel ;
      private string AV46DDO_DocDicionarioDataInclusaoAuxDateText ;
      private string AV85Docdicionariowwds_1_filterfulltext ;
      private string AV99Docdicionariowwds_15_tfinformacaonome ;
      private string AV100Docdicionariowwds_16_tfinformacaonome_sel ;
      private string AV101Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel ;
      private string AV105Docdicionariowwds_21_tfdocumentonome ;
      private string AV106Docdicionariowwds_22_tfdocumentonome_sel ;
      private string AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string A76DocumentoNome ;
      private string lV85Docdicionariowwds_1_filterfulltext ;
      private string lV99Docdicionariowwds_15_tfinformacaonome ;
      private string lV101Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string lV105Docdicionariowwds_21_tfdocumentonome ;
      private string lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfdocdicionariodatainclusao_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkDocDicionarioSensivel ;
      private GXCheckbox chkDocDicionarioPodeEliminar ;
      private GXCheckbox chkDocDicionarioTransfInter ;
      private IDataStoreProvider pr_default ;
      private string[] H00332_A119DocDicionarioTipoTransfInterGa ;
      private string[] H00332_A76DocumentoNome ;
      private bool[] H00332_n76DocumentoNome ;
      private int[] H00332_A75DocumentoId ;
      private string[] H00332_A73HipoteseTratamentoNome ;
      private string[] H00332_A70InformacaoNome ;
      private DateTime[] H00332_A103DocDicionarioDataInclusao ;
      private string[] H00332_A102DocDicionarioFinalidade ;
      private bool[] H00332_A101DocDicionarioTransfInter ;
      private bool[] H00332_A100DocDicionarioPodeEliminar ;
      private bool[] H00332_A99DocDicionarioSensivel ;
      private int[] H00332_A72HipoteseTratamentoId ;
      private int[] H00332_A69InformacaoId ;
      private int[] H00332_A98DocDicionarioId ;
      private long[] H00333_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV59AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV49GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV60AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV47DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV48GAMSession ;
   }

   public class docdicionarioww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00332( IGxContext context ,
                                             string AV85Docdicionariowwds_1_filterfulltext ,
                                             int AV86Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV87Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV88Docdicionariowwds_4_tfinformacaoid ,
                                             int AV89Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV90Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV91Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV95Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV97Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV100Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV99Docdicionariowwds_15_tfinformacaonome ,
                                             string AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV101Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV103Docdicionariowwds_19_tfdocumentoid ,
                                             int AV104Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV106Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV105Docdicionariowwds_21_tfdocumentonome ,
                                             string AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[32];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[DocDicionarioTipoTransfInterGa], T2.[DocumentoNome], T1.[DocumentoId], T3.[HipoteseTratamentoNome], T4.[InformacaoNome], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioFinalidade], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[InformacaoId], T1.[DocDicionarioId]";
         sFromString = " FROM ((([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T2.[DocumentoNome] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV85Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV86Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV86Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (0==AV87Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV87Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (0==AV88Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV88Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (0==AV89Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV89Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (0==AV90Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV90Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV91Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV95Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV97Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV97Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV99Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV100Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV100Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV100Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV101Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV103Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV103Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (0==AV104Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV104Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV105Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV106Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV106Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV106Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( StringUtil.StrCmp(AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioSensivel]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioSensivel] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioId]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioId] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[InformacaoId]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[InformacaoId] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[HipoteseTratamentoId]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[HipoteseTratamentoId] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioPodeEliminar]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioPodeEliminar] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioTransfInter]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioTransfInter] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioFinalidade]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioFinalidade] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioDataInclusao]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioDataInclusao] DESC";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.[InformacaoNome]";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.[InformacaoNome] DESC";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.[HipoteseTratamentoNome]";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.[HipoteseTratamentoNome] DESC";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocumentoId]";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocumentoId] DESC";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[DocumentoNome]";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[DocumentoNome] DESC";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioTipoTransfInterGa]";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioTipoTransfInterGa] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[DocDicionarioId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00333( IGxContext context ,
                                             string AV85Docdicionariowwds_1_filterfulltext ,
                                             int AV86Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV87Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV88Docdicionariowwds_4_tfinformacaoid ,
                                             int AV89Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV90Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV91Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV95Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV97Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV100Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV99Docdicionariowwds_15_tfinformacaonome ,
                                             string AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV101Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV103Docdicionariowwds_19_tfdocumentoid ,
                                             int AV104Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV106Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV105Docdicionariowwds_21_tfdocumentonome ,
                                             string AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[29];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([DocDicionario] T1 INNER JOIN [Documento] T4 ON T4.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T2.[InformacaoNome] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T4.[DocumentoNome] like '%' + @lV85Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV85Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
         }
         if ( ! (0==AV86Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV86Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! (0==AV87Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV87Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! (0==AV88Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV88Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! (0==AV89Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV89Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! (0==AV90Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV90Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV91Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV92Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV93Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV94Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV95Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV97Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV97Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[InformacaoNome] like @lV99Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV100Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[InformacaoNome] = @AV100Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( StringUtil.StrCmp(AV100Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV101Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( StringUtil.StrCmp(AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV103Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV103Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( ! (0==AV104Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV104Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[DocumentoNome] like @lV105Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV106Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[DocumentoNome] = @AV106Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( StringUtil.StrCmp(AV106Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocumentoNome] IS NULL or (T4.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( StringUtil.StrCmp(AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00332(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
               case 1 :
                     return conditional_H00333(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00332;
          prmH00332 = new Object[] {
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV86Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV87Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV88Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV89Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV90Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV95Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV97Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV99Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV100Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV101Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV103Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV104Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV105Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV106Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00333;
          prmH00333 = new Object[] {
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV86Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV87Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV88Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV89Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV90Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV95Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV96Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV97Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV98Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV99Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV100Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV101Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV102Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV103Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV104Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV105Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV106Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV108Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00332", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00332,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00333", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00333,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.getBool(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
