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
   public class operadorwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public operadorwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS");
         }
      }

      public operadorwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocumentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8DocumentoId = aP1_DocumentoId;
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
         cmbavDocumentoisoperador = new GXCombobox();
         cmbavOperadorid_col = new GXCombobox();
         chkavDocoperadorcoleta = new GXCheckbox();
         chkavDocoperadorretencao = new GXCheckbox();
         chkavDocoperadorcompartilhamento = new GXCheckbox();
         chkavDocoperadoreliminacao = new GXCheckbox();
         chkavDocoperadorprocessamento = new GXCheckbox();
         chkDocOperadorColeta = new GXCheckbox();
         chkDocOperadorCompartilhamento = new GXCheckbox();
         chkDocOperadorEliminacao = new GXCheckbox();
         chkDocOperadorProcessamento = new GXCheckbox();
         chkDocOperadorRetencao = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
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
                  AV8DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV8DocumentoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_91 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_91"), "."));
         nGXsfl_91_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_91_idx"), "."));
         sGXsfl_91_idx = GetPar( "sGXsfl_91_idx");
         sPrefix = GetPar( "sPrefix");
         edtavAtualizar_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_91_Refreshing);
         edtavExcluir_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_91_Refreshing);
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
         AV32FiltroOperador = GetPar( "FiltroOperador");
         AV8DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
         AV43IsOperador = StringUtil.StrToBool( GetPar( "IsOperador"));
         AV44OperadorId_Out = (int)(NumberUtil.Val( GetPar( "OperadorId_Out"), "."));
         A44OperadorAtivo = StringUtil.StrToBool( GetPar( "OperadorAtivo"));
         edtavAtualizar_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_91_Refreshing);
         edtavExcluir_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_91_Refreshing);
         AV31IsAuthorized_OperadorNome = StringUtil.StrToBool( GetPar( "IsAuthorized_OperadorNome"));
         AV17DocOperadorColeta = StringUtil.StrToBool( GetPar( "DocOperadorColeta"));
         AV18DocOperadorRetencao = StringUtil.StrToBool( GetPar( "DocOperadorRetencao"));
         AV19DocOperadorCompartilhamento = StringUtil.StrToBool( GetPar( "DocOperadorCompartilhamento"));
         AV20DocOperadorEliminacao = StringUtil.StrToBool( GetPar( "DocOperadorEliminacao"));
         AV21DocOperadorProcessamento = StringUtil.StrToBool( GetPar( "DocOperadorProcessamento"));
         AV39IsAuthorized_Excluir = StringUtil.StrToBool( GetPar( "IsAuthorized_Excluir"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA7B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavOperadordados_Enabled = 0;
               AssignProp(sPrefix, false, edtavOperadordados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperadordados_Enabled), 5, 0), !bGXsfl_91_Refreshing);
               edtavVisualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_91_Refreshing);
               edtavAtualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_91_Refreshing);
               edtavExcluir_Enabled = 0;
               AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_91_Refreshing);
               WS7B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
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
            context.SendWebValue( "Aba de Operador para o cadastro de um Documento") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "operadorwc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operadorwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_OPERADORNOME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_OperadorNome, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_EXCLUIR", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Excluir, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTROOPERADOR", AV32FiltroOperador);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_91", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_91), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISOPERADOR", AV43IsOperador);
         GxWebStd.gx_hidden_field( context, sPrefix+"vOPERADORID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44OperadorId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"OPERADORATIVO", A44OperadorAtivo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_OPERADORNOME", AV31IsAuthorized_OperadorNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_OPERADORNOME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_OperadorNome, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISDISPLAY", AV49IsDisplay);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV35CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCOPERADOR", AV28DocOperador);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCOPERADOR", AV28DocOperador);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_EXCLUIR", AV39IsAuthorized_Excluir);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_EXCLUIR", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Excluir, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Title", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Grid_empowerer_Infinitescrolling));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"vATUALIZAR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEXCLUIR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Result));
      }

      protected void RenderHtmlCloseForm7B2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "OperadorWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aba de Operador para o cadastro de um Documento" ;
      }

      protected void WB7B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "operadorwc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain1_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocumentoisoperador_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocumentoisoperador_Internalname, "Operador", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentoisoperador, cmbavDocumentoisoperador_Internalname, StringUtil.BoolToStr( AV50DocumentoIsOperador), 1, cmbavDocumentoisoperador_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocumentoisoperador.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", true, 0, "HLP_OperadorWC.htm");
            cmbavDocumentoisoperador.CurrentValue = StringUtil.BoolToStr( AV50DocumentoIsOperador);
            AssignProp(sPrefix, false, cmbavDocumentoisoperador_Internalname, "Values", (string)(cmbavDocumentoisoperador.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableoperadordados_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOperadorid_col_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperadorid_col_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperadorid_col, cmbavOperadorid_col_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0)), 1, cmbavOperadorid_col_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOperadorid_col.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_OperadorWC.htm");
            cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
            AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", (string)(cmbavOperadorid_col.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table1_27_7B2( true) ;
         }
         else
         {
            wb_table1_27_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_27_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledadoscheck_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            wb_table2_40_7B2( true) ;
         }
         else
         {
            wb_table2_40_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_40_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:2;", "div");
            wb_table3_48_7B2( true) ;
         }
         else
         {
            wb_table3_48_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table3_48_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:3;", "div");
            wb_table4_56_7B2( true) ;
         }
         else
         {
            wb_table4_56_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table4_56_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:4;", "div");
            wb_table5_64_7B2( true) ;
         }
         else
         {
            wb_table5_64_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table5_64_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:5;", "div");
            wb_table6_72_7B2( true) ;
         }
         else
         {
            wb_table6_72_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table6_72_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadicionar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(91), 2, 0)+","+"null"+");", bttBtnadicionar_Caption, bttBtnadicionar_Jsonclick, 5, "ADICIONAR", "", StyleString, ClassString, bttBtnadicionar_Visible, bttBtnadicionar_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADICIONAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperadorWC.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltrooperador_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltrooperador_Internalname, "PESQUISAR", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFiltrooperador_Internalname, AV32FiltroOperador, StringUtil.RTrim( context.localUtil.Format( AV32FiltroOperador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltrooperador_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFiltrooperador_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_OperadorWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm GridWithBorderColor HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl91( ) ;
         }
         if ( wbEnd == 91 )
         {
            wbEnd = 0;
            nRC_GXsfl_91 = (int)(nGXsfl_91_idx-1);
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocoperadorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocOperadorId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7DocOperadorId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,108);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocoperadorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocoperadorid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OperadorWC.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocumentoid_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OperadorWC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperadorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9OperadorId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9OperadorId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,110);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperadorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavOperadorid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OperadorWC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDocoperadordatainclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDocoperadordatainclusao_Internalname, context.localUtil.Format(AV11DocOperadorDataInclusao, "99/99/99"), context.localUtil.Format( AV11DocOperadorDataInclusao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,111);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocoperadordatainclusao_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocoperadordatainclusao_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OperadorWC.htm");
            GxWebStd.gx_bitmap( context, edtavDocoperadordatainclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavDocoperadordatainclusao_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OperadorWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            wb_table7_112_7B2( true) ;
         }
         else
         {
            wb_table7_112_7B2( false) ;
         }
         return  ;
      }

      protected void wb_table7_112_7B2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("InfiniteScrolling", Grid_empowerer_Infinitescrolling);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 91 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
               }
               Form.Meta.addItem("description", "Aba de Operador para o cadastro de um Documento", 0) ;
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
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP7B0( ) ;
            }
         }
      }

      protected void WS7B2( )
      {
         START7B2( ) ;
         EVT7B2( ) ;
      }

      protected void EVT7B2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_EXCLUIR.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E117B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOOPERADORADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoOperadorAdd' */
                                    E127B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdicionar' */
                                    E137B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDOCUMENTOISOPERADOR.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E147B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavOperadordados_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VEXCLUIR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VEXCLUIR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7B0( ) ;
                              }
                              nGXsfl_91_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
                              SubsflControlProps_912( ) ;
                              A86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( edtDocOperadorId_Internalname), ",", "."));
                              A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                              A42OperadorId = (int)(context.localUtil.CToN( cgiGet( edtOperadorId_Internalname), ",", "."));
                              A43OperadorNome = cgiGet( edtOperadorNome_Internalname);
                              A87DocOperadorColeta = StringUtil.StrToBool( cgiGet( chkDocOperadorColeta_Internalname));
                              A89DocOperadorCompartilhamento = StringUtil.StrToBool( cgiGet( chkDocOperadorCompartilhamento_Internalname));
                              A90DocOperadorEliminacao = StringUtil.StrToBool( cgiGet( chkDocOperadorEliminacao_Internalname));
                              A91DocOperadorProcessamento = StringUtil.StrToBool( cgiGet( chkDocOperadorProcessamento_Internalname));
                              A88DocOperadorRetencao = StringUtil.StrToBool( cgiGet( chkDocOperadorRetencao_Internalname));
                              AV16OperadorDados = cgiGet( edtavOperadordados_Internalname);
                              AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
                              AV24Visualizar = cgiGet( edtavVisualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV24Visualizar);
                              AV25Atualizar = cgiGet( edtavAtualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavAtualizar_Internalname, AV25Atualizar);
                              AV26Excluir = cgiGet( edtavExcluir_Internalname);
                              AssignAttri(sPrefix, false, edtavExcluir_Internalname, AV26Excluir);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E157B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E167B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E177B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEXCLUIR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E187B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VATUALIZAR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E197B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VVISUALIZAR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E207B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Filtrooperador Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTROOPERADOR"), AV32FiltroOperador) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP7B0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavOperadordados_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE7B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7B2( ) ;
            }
         }
      }

      protected void PA7B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operadorwc.aspx")), "operadorwc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operadorwc.aspx")))) ;
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
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "Mode");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavDocumentoisoperador_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_912( ) ;
         while ( nGXsfl_91_idx <= nRC_GXsfl_91 )
         {
            sendrow_912( ) ;
            nGXsfl_91_idx = ((subGrid_Islastpage==1)&&(nGXsfl_91_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_91_idx+1);
            sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
            SubsflControlProps_912( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV32FiltroOperador ,
                                       int AV8DocumentoId ,
                                       bool AV43IsOperador ,
                                       int AV44OperadorId_Out ,
                                       bool A44OperadorAtivo ,
                                       bool AV31IsAuthorized_OperadorNome ,
                                       bool AV17DocOperadorColeta ,
                                       bool AV18DocOperadorRetencao ,
                                       bool AV19DocOperadorCompartilhamento ,
                                       bool AV20DocOperadorEliminacao ,
                                       bool AV21DocOperadorProcessamento ,
                                       bool AV39IsAuthorized_Excluir ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E167B2 ();
         GRID_nCurrentRecord = 0;
         RF7B2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCOPERADORID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCOPERADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ".", "")));
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
         if ( cmbavDocumentoisoperador.ItemCount > 0 )
         {
            AV50DocumentoIsOperador = StringUtil.StrToBool( cmbavDocumentoisoperador.getValidValue(StringUtil.BoolToStr( AV50DocumentoIsOperador)));
            AssignAttri(sPrefix, false, "AV50DocumentoIsOperador", AV50DocumentoIsOperador);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentoisoperador.CurrentValue = StringUtil.BoolToStr( AV50DocumentoIsOperador);
            AssignProp(sPrefix, false, cmbavDocumentoisoperador_Internalname, "Values", cmbavDocumentoisoperador.ToJavascriptSource(), true);
         }
         if ( cmbavOperadorid_col.ItemCount > 0 )
         {
            AV42OperadorId_Col = (int)(NumberUtil.Val( cmbavOperadorid_col.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
            AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
         }
         AV17DocOperadorColeta = StringUtil.StrToBool( StringUtil.BoolToStr( AV17DocOperadorColeta));
         AssignAttri(sPrefix, false, "AV17DocOperadorColeta", AV17DocOperadorColeta);
         AV18DocOperadorRetencao = StringUtil.StrToBool( StringUtil.BoolToStr( AV18DocOperadorRetencao));
         AssignAttri(sPrefix, false, "AV18DocOperadorRetencao", AV18DocOperadorRetencao);
         AV19DocOperadorCompartilhamento = StringUtil.StrToBool( StringUtil.BoolToStr( AV19DocOperadorCompartilhamento));
         AssignAttri(sPrefix, false, "AV19DocOperadorCompartilhamento", AV19DocOperadorCompartilhamento);
         AV20DocOperadorEliminacao = StringUtil.StrToBool( StringUtil.BoolToStr( AV20DocOperadorEliminacao));
         AssignAttri(sPrefix, false, "AV20DocOperadorEliminacao", AV20DocOperadorEliminacao);
         AV21DocOperadorProcessamento = StringUtil.StrToBool( StringUtil.BoolToStr( AV21DocOperadorProcessamento));
         AssignAttri(sPrefix, false, "AV21DocOperadorProcessamento", AV21DocOperadorProcessamento);
      }

      public void Refresh( )
      {
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_91_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF7B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavOperadordados_Enabled = 0;
         AssignProp(sPrefix, false, edtavOperadordados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperadordados_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavAtualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavExcluir_Enabled = 0;
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_91_Refreshing);
      }

      protected void RF7B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 91;
         /* Execute user event: Refresh */
         E167B2 ();
         nGXsfl_91_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
         SubsflControlProps_912( ) ;
         bGXsfl_91_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_912( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV32FiltroOperador ,
                                                 AV8DocumentoId ,
                                                 A75DocumentoId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor H007B2 */
            pr_default.execute(0, new Object[] {AV8DocumentoId, AV32FiltroOperador, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_91_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
            SubsflControlProps_912( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A88DocOperadorRetencao = H007B2_A88DocOperadorRetencao[0];
               A91DocOperadorProcessamento = H007B2_A91DocOperadorProcessamento[0];
               A90DocOperadorEliminacao = H007B2_A90DocOperadorEliminacao[0];
               A89DocOperadorCompartilhamento = H007B2_A89DocOperadorCompartilhamento[0];
               A87DocOperadorColeta = H007B2_A87DocOperadorColeta[0];
               A43OperadorNome = H007B2_A43OperadorNome[0];
               A42OperadorId = H007B2_A42OperadorId[0];
               A75DocumentoId = H007B2_A75DocumentoId[0];
               A86DocOperadorId = H007B2_A86DocOperadorId[0];
               A43OperadorNome = H007B2_A43OperadorNome[0];
               E177B2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 91;
            WB7B0( ) ;
         }
         bGXsfl_91_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7B2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_OPERADORNOME", AV31IsAuthorized_OperadorNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_OPERADORNOME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_OperadorNome, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_EXCLUIR", AV39IsAuthorized_Excluir);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_EXCLUIR", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Excluir, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCOPERADORID"+"_"+sGXsfl_91_idx, GetSecureSignedToken( sPrefix+sGXsfl_91_idx, context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV32FiltroOperador ,
                                              AV8DocumentoId ,
                                              A75DocumentoId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H007B3 */
         pr_default.execute(1, new Object[] {AV8DocumentoId, AV32FiltroOperador});
         GRID_nRecordCount = H007B3_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavOperadordados_Enabled = 0;
         AssignProp(sPrefix, false, edtavOperadordados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperadordados_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavAtualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavExcluir_Enabled = 0;
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E157B2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_91 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_91"), ",", "."));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8DocumentoId"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_excluir_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Title");
            Dvelop_confirmpanel_excluir_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Confirmationtext");
            Dvelop_confirmpanel_excluir_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttoncaption");
            Dvelop_confirmpanel_excluir_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Nobuttoncaption");
            Dvelop_confirmpanel_excluir_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Cancelbuttoncaption");
            Dvelop_confirmpanel_excluir_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttonposition");
            Dvelop_confirmpanel_excluir_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Infinitescrolling = cgiGet( sPrefix+"GRID_EMPOWERER_Infinitescrolling");
            Dvelop_confirmpanel_excluir_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR_Result");
            /* Read variables values. */
            cmbavDocumentoisoperador.Name = cmbavDocumentoisoperador_Internalname;
            cmbavDocumentoisoperador.CurrentValue = cgiGet( cmbavDocumentoisoperador_Internalname);
            AV50DocumentoIsOperador = StringUtil.StrToBool( cgiGet( cmbavDocumentoisoperador_Internalname));
            AssignAttri(sPrefix, false, "AV50DocumentoIsOperador", AV50DocumentoIsOperador);
            cmbavOperadorid_col.Name = cmbavOperadorid_col_Internalname;
            cmbavOperadorid_col.CurrentValue = cgiGet( cmbavOperadorid_col_Internalname);
            AV42OperadorId_Col = (int)(NumberUtil.Val( cgiGet( cmbavOperadorid_col_Internalname), "."));
            AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
            AV17DocOperadorColeta = StringUtil.StrToBool( cgiGet( chkavDocoperadorcoleta_Internalname));
            AssignAttri(sPrefix, false, "AV17DocOperadorColeta", AV17DocOperadorColeta);
            AV18DocOperadorRetencao = StringUtil.StrToBool( cgiGet( chkavDocoperadorretencao_Internalname));
            AssignAttri(sPrefix, false, "AV18DocOperadorRetencao", AV18DocOperadorRetencao);
            AV19DocOperadorCompartilhamento = StringUtil.StrToBool( cgiGet( chkavDocoperadorcompartilhamento_Internalname));
            AssignAttri(sPrefix, false, "AV19DocOperadorCompartilhamento", AV19DocOperadorCompartilhamento);
            AV20DocOperadorEliminacao = StringUtil.StrToBool( cgiGet( chkavDocoperadoreliminacao_Internalname));
            AssignAttri(sPrefix, false, "AV20DocOperadorEliminacao", AV20DocOperadorEliminacao);
            AV21DocOperadorProcessamento = StringUtil.StrToBool( cgiGet( chkavDocoperadorprocessamento_Internalname));
            AssignAttri(sPrefix, false, "AV21DocOperadorProcessamento", AV21DocOperadorProcessamento);
            AV32FiltroOperador = cgiGet( edtavFiltrooperador_Internalname);
            AssignAttri(sPrefix, false, "AV32FiltroOperador", AV32FiltroOperador);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocoperadorid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocoperadorid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCOPERADORID");
               GX_FocusControl = edtavDocoperadorid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7DocOperadorId = 0;
               AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
            }
            else
            {
               AV7DocOperadorId = (int)(context.localUtil.CToN( cgiGet( edtavDocoperadorid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperadorid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperadorid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERADORID");
               GX_FocusControl = edtavOperadorid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9OperadorId = 0;
               AssignAttri(sPrefix, false, "AV9OperadorId", StringUtil.LTrimStr( (decimal)(AV9OperadorId), 8, 0));
            }
            else
            {
               AV9OperadorId = (int)(context.localUtil.CToN( cgiGet( edtavOperadorid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV9OperadorId", StringUtil.LTrimStr( (decimal)(AV9OperadorId), 8, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDocoperadordatainclusao_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Doc Operador Data Inclusao"}), 1, "vDOCOPERADORDATAINCLUSAO");
               GX_FocusControl = edtavDocoperadordatainclusao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11DocOperadorDataInclusao = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV11DocOperadorDataInclusao", context.localUtil.Format(AV11DocOperadorDataInclusao, "99/99/99"));
            }
            else
            {
               AV11DocOperadorDataInclusao = context.localUtil.CToD( cgiGet( edtavDocoperadordatainclusao_Internalname), 2);
               AssignAttri(sPrefix, false, "AV11DocOperadorDataInclusao", context.localUtil.Format(AV11DocOperadorDataInclusao, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTROOPERADOR"), AV32FiltroOperador) != 0 )
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
         E157B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E157B2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavDocoperadorid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocoperadorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocoperadorid_Visible), 5, 0), true);
         edtavDocumentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Visible), 5, 0), true);
         edtavOperadorid_Visible = 0;
         AssignProp(sPrefix, false, edtavOperadorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperadorid_Visible), 5, 0), true);
         edtavDocoperadordatainclusao_Visible = 0;
         AssignProp(sPrefix, false, edtavDocoperadordatainclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocoperadordatainclusao_Visible), 5, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GXt_boolean1 = AV31IsAuthorized_OperadorNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "operadorview_Execute", out  GXt_boolean1) ;
         AV31IsAuthorized_OperadorNome = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV31IsAuthorized_OperadorNome", AV31IsAuthorized_OperadorNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_OPERADORNOME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_OperadorNome, context));
         AV46Documento.Load(AV8DocumentoId);
         AV50DocumentoIsOperador = AV46Documento.gxTpr_Documentoisoperador;
         AssignAttri(sPrefix, false, "AV50DocumentoIsOperador", AV50DocumentoIsOperador);
         if ( AV50DocumentoIsOperador )
         {
            cmbavOperadorid_col.Enabled = 1;
            AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
            chkavDocoperadorcoleta.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
            chkavDocoperadorretencao.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
            chkavDocoperadorcompartilhamento.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
            chkavDocoperadoreliminacao.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
            chkavDocoperadorprocessamento.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
            bttBtnadicionar_Enabled = 1;
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Enabled), 5, 0), true);
            lblOperadoradd_Enabled = 1;
            AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Enabled), 5, 0), true);
         }
         else
         {
            AV42OperadorId_Col = 0;
            AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
            cmbavOperadorid_col.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
            chkavDocoperadorcoleta.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
            chkavDocoperadorretencao.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
            chkavDocoperadorcompartilhamento.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
            chkavDocoperadoreliminacao.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
            chkavDocoperadorprocessamento.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
            bttBtnadicionar_Enabled = 0;
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Enabled), 5, 0), true);
            lblOperadoradd_Enabled = 0;
            AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            cmbavOperadorid_col.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
            chkavDocoperadorcoleta.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
            chkavDocoperadorretencao.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
            chkavDocoperadorcompartilhamento.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
            chkavDocoperadoreliminacao.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
            chkavDocoperadorprocessamento.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
            bttBtnadicionar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Visible), 5, 0), true);
            edtavAtualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_91_Refreshing);
            edtavExcluir_Visible = 0;
            AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_91_Refreshing);
            lblOperadorinfo_Visible = 0;
            AssignProp(sPrefix, false, lblOperadorinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblOperadorinfo_Visible), 5, 0), true);
            lblOperadoradd_Visible = 0;
            AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'OPERADORCOMBOCARREGA' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Using cursor H007B4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A135CampoId = H007B4_A135CampoId[0];
            A139TooltipTelaId = H007B4_A139TooltipTelaId[0];
            A140TooltipTelaNome = H007B4_A140TooltipTelaNome[0];
            A118TooltipAtivo = H007B4_A118TooltipAtivo[0];
            A136CampoNome = H007B4_A136CampoNome[0];
            A115TooltipDescricao = H007B4_A115TooltipDescricao[0];
            A136CampoNome = H007B4_A136CampoNome[0];
            A140TooltipTelaNome = H007B4_A140TooltipTelaNome[0];
            if ( StringUtil.StrCmp(A136CampoNome, "NOME DO OPERADOR") == 0 )
            {
               lblOperadorinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblOperadorinfo_Internalname, "Tooltiptext", lblOperadorinfo_Tooltiptext, true);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void E167B2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         if ( AV43IsOperador )
         {
            /* Execute user subroutine: 'OPERADORCOMBOCARREGA' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV42OperadorId_Col = AV44OperadorId_Out;
            AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
            AV43IsOperador = false;
            AssignAttri(sPrefix, false, "AV43IsOperador", AV43IsOperador);
            AV44OperadorId_Out = 0;
            AssignAttri(sPrefix, false, "AV44OperadorId_Out", StringUtil.LTrimStr( (decimal)(AV44OperadorId_Out), 8, 0));
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      private void E177B2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV16OperadorDados = "";
         AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
         AV24Visualizar = "<i class=\"fas fa-magnifying-glass\"></i>";
         AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV24Visualizar);
         AV25Atualizar = "<i class=\"fas fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavAtualizar_Internalname, AV25Atualizar);
         AV26Excluir = "<i class=\"fas fa-x\"></i>";
         AssignAttri(sPrefix, false, edtavExcluir_Internalname, AV26Excluir);
         if ( AV31IsAuthorized_OperadorNome )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "operadorview.aspx"+UrlEncode(StringUtil.LTrimStr(A42OperadorId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtOperadorNome_Link = formatLink("operadorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( A87DocOperadorColeta )
         {
            AV16OperadorDados += "COLETA";
            AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
         }
         if ( A88DocOperadorRetencao )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16OperadorDados)) )
            {
               AV16OperadorDados += "RETENÇÃO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
            else
            {
               AV16OperadorDados += ", RETENÇÃO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
         }
         if ( A89DocOperadorCompartilhamento )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16OperadorDados)) )
            {
               AV16OperadorDados += "COMPARTILHAMENTO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
            else
            {
               AV16OperadorDados += ", COMPARTILHAMENTO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
         }
         if ( A90DocOperadorEliminacao )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16OperadorDados)) )
            {
               AV16OperadorDados += "ELIMINAÇÃO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
            else
            {
               AV16OperadorDados += ", ELIMINAÇÃO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
         }
         if ( A91DocOperadorProcessamento )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16OperadorDados)) )
            {
               AV16OperadorDados += "PROCESSAMENTO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
            else
            {
               AV16OperadorDados += ", PROCESSAMENTO";
               AssignAttri(sPrefix, false, edtavOperadordados_Internalname, AV16OperadorDados);
            }
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 91;
         }
         sendrow_912( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_91_Refreshing )
         {
            context.DoAjaxLoad(91, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E127B2( )
      {
         /* 'DoOperadorAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operador.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("operador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV43IsOperador","AV44OperadorId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void E137B2( )
      {
         /* 'DoAdicionar' Routine */
         returnInSub = false;
         if ( AV49IsDisplay )
         {
            cmbavOperadorid_col.Enabled = 1;
            AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
            chkavDocoperadorcoleta.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
            chkavDocoperadorprocessamento.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
            chkavDocoperadorcompartilhamento.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
            chkavDocoperadorretencao.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
            chkavDocoperadoreliminacao.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
            lblOperadoradd_Enabled = 1;
            AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Enabled), 5, 0), true);
            bttBtnadicionar_Caption = "ADICIONAR";
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
            AV49IsDisplay = false;
            AssignAttri(sPrefix, false, "AV49IsDisplay", AV49IsDisplay);
            /* Execute user subroutine: 'LIMPADADOS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV35CheckRequiredFieldsResult )
            {
               if ( ! AV17DocOperadorColeta && ! AV19DocOperadorCompartilhamento && ! AV20DocOperadorEliminacao && ! AV21DocOperadorProcessamento && ! AV18DocOperadorRetencao )
               {
                  GX_msglist.addItem("Marque pelo menos uma das opções.");
               }
               else
               {
                  if ( (0==AV7DocOperadorId) )
                  {
                     AV28DocOperador = new SdtDocOperador(context);
                     AV28DocOperador.gxTpr_Docoperadorcoleta = AV17DocOperadorColeta;
                     AV28DocOperador.gxTpr_Docoperadorcompartilhamento = AV19DocOperadorCompartilhamento;
                     AV28DocOperador.gxTpr_Docoperadoreliminacao = AV20DocOperadorEliminacao;
                     AV28DocOperador.gxTpr_Docoperadorprocessamento = AV21DocOperadorProcessamento;
                     AV28DocOperador.gxTpr_Docoperadordatainclusao = AV11DocOperadorDataInclusao;
                     AV28DocOperador.gxTpr_Docoperadorretencao = AV18DocOperadorRetencao;
                     AV28DocOperador.gxTpr_Documentoid = AV8DocumentoId;
                     AV28DocOperador.gxTpr_Operadorid = AV42OperadorId_Col;
                     AV28DocOperador.Insert();
                     if ( AV28DocOperador.Success() )
                     {
                        context.CommitDataStores("operadorwc",pr_default);
                        GRID_nFirstRecordOnPage = 0;
                        GRID_nCurrentRecord = 0;
                        GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_91_idx;
                        GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
                        gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
                        /* Execute user subroutine: 'LIMPADADOS' */
                        S132 ();
                        if ( returnInSub )
                        {
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                     else
                     {
                        AV56GXV2 = 1;
                        AV55GXV1 = AV28DocOperador.GetMessages();
                        while ( AV56GXV2 <= AV55GXV1.Count )
                        {
                           AV30Message = ((GeneXus.Utils.SdtMessages_Message)AV55GXV1.Item(AV56GXV2));
                           GX_msglist.addItem(AV30Message.gxTpr_Description);
                           AV56GXV2 = (int)(AV56GXV2+1);
                        }
                     }
                  }
                  else
                  {
                     AV28DocOperador.gxTpr_Docoperadorcoleta = AV17DocOperadorColeta;
                     AV28DocOperador.gxTpr_Docoperadorcompartilhamento = AV19DocOperadorCompartilhamento;
                     AV28DocOperador.gxTpr_Docoperadoreliminacao = AV20DocOperadorEliminacao;
                     AV28DocOperador.gxTpr_Docoperadorprocessamento = AV21DocOperadorProcessamento;
                     AV28DocOperador.gxTpr_Docoperadordatainclusao = AV11DocOperadorDataInclusao;
                     AV28DocOperador.gxTpr_Docoperadorretencao = AV18DocOperadorRetencao;
                     AV28DocOperador.gxTpr_Documentoid = AV8DocumentoId;
                     AV28DocOperador.gxTpr_Operadorid = AV42OperadorId_Col;
                     AV28DocOperador.Update();
                     if ( AV28DocOperador.Success() )
                     {
                        context.CommitDataStores("operadorwc",pr_default);
                        GRID_nFirstRecordOnPage = 0;
                        GRID_nCurrentRecord = 0;
                        GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_91_idx;
                        GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
                        gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
                        /* Execute user subroutine: 'LIMPADADOS' */
                        S132 ();
                        if ( returnInSub )
                        {
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                     else
                     {
                        AV58GXV4 = 1;
                        AV57GXV3 = AV28DocOperador.GetMessages();
                        while ( AV58GXV4 <= AV57GXV3.Count )
                        {
                           AV30Message = ((GeneXus.Utils.SdtMessages_Message)AV57GXV3.Item(AV58GXV4));
                           GX_msglist.addItem(AV30Message.gxTpr_Description);
                           AV58GXV4 = (int)(AV58GXV4+1);
                        }
                     }
                  }
               }
            }
            else
            {
               GX_msglist.addItem("Revise os campos obrigatórios.");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28DocOperador", AV28DocOperador);
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void E187B2( )
      {
         /* Excluir_Click Routine */
         returnInSub = false;
         if ( AV39IsAuthorized_Excluir )
         {
            this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_EXCLUIRContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void E117B2( )
      {
         /* Dvelop_confirmpanel_excluir_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_excluir_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO EXCLUIR' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28DocOperador", AV28DocOperador);
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV41IsAuthorized_OperadorAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaOperadorNomeAdd", out  GXt_boolean1) ;
         AV41IsAuthorized_OperadorAdd = GXt_boolean1;
         if ( ! ( AV41IsAuthorized_OperadorAdd ) )
         {
            lblOperadoradd_Visible = 0;
            AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV40IsAuthorized_Adicionar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaOperadorAdd", out  GXt_boolean1) ;
         AV40IsAuthorized_Adicionar = GXt_boolean1;
         if ( ! ( AV40IsAuthorized_Adicionar ) )
         {
            bttBtnadicionar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV38IsAuthorized_Visualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaOperadorVisualiza", out  GXt_boolean1) ;
         AV38IsAuthorized_Visualizar = GXt_boolean1;
         if ( ! ( AV38IsAuthorized_Visualizar ) )
         {
            edtavVisualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Visible), 5, 0), !bGXsfl_91_Refreshing);
         }
         GXt_boolean1 = AV37IsAuthorized_Atualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaOperadorAtualiza", out  GXt_boolean1) ;
         AV37IsAuthorized_Atualizar = GXt_boolean1;
         if ( ! ( AV37IsAuthorized_Atualizar ) )
         {
            edtavAtualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_91_Refreshing);
         }
         GXt_boolean1 = AV39IsAuthorized_Excluir;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaOperadorExclui", out  GXt_boolean1) ;
         AV39IsAuthorized_Excluir = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV39IsAuthorized_Excluir", AV39IsAuthorized_Excluir);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_EXCLUIR", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Excluir, context));
         if ( ! ( AV39IsAuthorized_Excluir ) )
         {
            edtavExcluir_Visible = 0;
            AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_91_Refreshing);
         }
      }

      protected void S152( )
      {
         /* 'DO EXCLUIR' Routine */
         returnInSub = false;
         AV28DocOperador.Load(A86DocOperadorId);
         AV28DocOperador.Delete();
         if ( AV28DocOperador.Success() )
         {
            context.CommitDataStores("operadorwc",pr_default);
            GRID_nFirstRecordOnPage = 0;
            GRID_nCurrentRecord = 0;
            GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_91_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            gxgrGrid_refresh( subGrid_Rows, AV32FiltroOperador, AV8DocumentoId, AV43IsOperador, AV44OperadorId_Out, A44OperadorAtivo, AV31IsAuthorized_OperadorNome, AV17DocOperadorColeta, AV18DocOperadorRetencao, AV19DocOperadorCompartilhamento, AV20DocOperadorEliminacao, AV21DocOperadorProcessamento, AV39IsAuthorized_Excluir, sPrefix) ;
         }
         else
         {
            AV60GXV6 = 1;
            AV59GXV5 = AV28DocOperador.GetMessages();
            while ( AV60GXV6 <= AV59GXV5.Count )
            {
               AV30Message = ((GeneXus.Utils.SdtMessages_Message)AV59GXV5.Item(AV60GXV6));
               GX_msglist.addItem(AV30Message.gxTpr_Description);
               AV60GXV6 = (int)(AV60GXV6+1);
            }
         }
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV35CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV35CheckRequiredFieldsResult", AV35CheckRequiredFieldsResult);
         if ( (0==AV42OperadorId_Col) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavOperadorid_col_Internalname,  "true",  ""));
            AV35CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV35CheckRequiredFieldsResult", AV35CheckRequiredFieldsResult);
         }
      }

      protected void E147B2( )
      {
         /* Documentoisoperador_Controlvaluechanged Routine */
         returnInSub = false;
         AV46Documento.Load(AV8DocumentoId);
         AV46Documento.gxTpr_Documentoisoperador = AV50DocumentoIsOperador;
         AV46Documento.Update();
         if ( AV46Documento.Success() )
         {
            context.CommitDataStores("operadorwc",pr_default);
            if ( AV50DocumentoIsOperador )
            {
               cmbavOperadorid_col.Enabled = 1;
               AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
               chkavDocoperadorcoleta.Enabled = 1;
               AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
               chkavDocoperadorretencao.Enabled = 1;
               AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
               chkavDocoperadorcompartilhamento.Enabled = 1;
               AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
               chkavDocoperadoreliminacao.Enabled = 1;
               AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
               chkavDocoperadorprocessamento.Enabled = 1;
               AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
               bttBtnadicionar_Enabled = 1;
               AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Enabled), 5, 0), true);
               lblOperadoradd_Enabled = 1;
               AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Enabled), 5, 0), true);
            }
            else
            {
               AV42OperadorId_Col = 0;
               AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
               cmbavOperadorid_col.Enabled = 0;
               AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
               chkavDocoperadorcoleta.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
               chkavDocoperadorretencao.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
               chkavDocoperadorcompartilhamento.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
               chkavDocoperadoreliminacao.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
               chkavDocoperadorprocessamento.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
               bttBtnadicionar_Enabled = 0;
               AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Enabled), 5, 0), true);
               lblOperadoradd_Enabled = 0;
               AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Enabled), 5, 0), true);
            }
         }
         else
         {
            AV62GXV8 = 1;
            AV61GXV7 = AV46Documento.GetMessages();
            while ( AV62GXV8 <= AV61GXV7.Count )
            {
               AV30Message = ((GeneXus.Utils.SdtMessages_Message)AV61GXV7.Item(AV62GXV8));
               GX_msglist.addItem(AV30Message.gxTpr_Description);
               AV62GXV8 = (int)(AV62GXV8+1);
            }
         }
         /*  Sending Event outputs  */
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void E197B2( )
      {
         /* Atualizar_Click Routine */
         returnInSub = false;
         AV28DocOperador.Load(A86DocOperadorId);
         AV7DocOperadorId = AV28DocOperador.gxTpr_Docoperadorid;
         AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
         AV17DocOperadorColeta = AV28DocOperador.gxTpr_Docoperadorcoleta;
         AssignAttri(sPrefix, false, "AV17DocOperadorColeta", AV17DocOperadorColeta);
         AV21DocOperadorProcessamento = AV28DocOperador.gxTpr_Docoperadorprocessamento;
         AssignAttri(sPrefix, false, "AV21DocOperadorProcessamento", AV21DocOperadorProcessamento);
         AV19DocOperadorCompartilhamento = AV28DocOperador.gxTpr_Docoperadorcompartilhamento;
         AssignAttri(sPrefix, false, "AV19DocOperadorCompartilhamento", AV19DocOperadorCompartilhamento);
         AV18DocOperadorRetencao = AV28DocOperador.gxTpr_Docoperadorretencao;
         AssignAttri(sPrefix, false, "AV18DocOperadorRetencao", AV18DocOperadorRetencao);
         AV20DocOperadorEliminacao = AV28DocOperador.gxTpr_Docoperadoreliminacao;
         AssignAttri(sPrefix, false, "AV20DocOperadorEliminacao", AV20DocOperadorEliminacao);
         AV42OperadorId_Col = AV28DocOperador.gxTpr_Operadorid;
         AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
         bttBtnadicionar_Caption = "ATUALIZAR";
         AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28DocOperador", AV28DocOperador);
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void E207B2( )
      {
         /* Visualizar_Click Routine */
         returnInSub = false;
         AV28DocOperador.Load(A86DocOperadorId);
         AV7DocOperadorId = AV28DocOperador.gxTpr_Docoperadorid;
         AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
         AV17DocOperadorColeta = AV28DocOperador.gxTpr_Docoperadorcoleta;
         AssignAttri(sPrefix, false, "AV17DocOperadorColeta", AV17DocOperadorColeta);
         AV21DocOperadorProcessamento = AV28DocOperador.gxTpr_Docoperadorprocessamento;
         AssignAttri(sPrefix, false, "AV21DocOperadorProcessamento", AV21DocOperadorProcessamento);
         AV19DocOperadorCompartilhamento = AV28DocOperador.gxTpr_Docoperadorcompartilhamento;
         AssignAttri(sPrefix, false, "AV19DocOperadorCompartilhamento", AV19DocOperadorCompartilhamento);
         AV18DocOperadorRetencao = AV28DocOperador.gxTpr_Docoperadorretencao;
         AssignAttri(sPrefix, false, "AV18DocOperadorRetencao", AV18DocOperadorRetencao);
         AV20DocOperadorEliminacao = AV28DocOperador.gxTpr_Docoperadoreliminacao;
         AssignAttri(sPrefix, false, "AV20DocOperadorEliminacao", AV20DocOperadorEliminacao);
         AV42OperadorId_Col = AV28DocOperador.gxTpr_Operadorid;
         AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
         cmbavOperadorid_col.Enabled = 0;
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperadorid_col.Enabled), 5, 0), true);
         chkavDocoperadorcoleta.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcoleta.Enabled), 5, 0), true);
         chkavDocoperadorprocessamento.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorprocessamento.Enabled), 5, 0), true);
         chkavDocoperadorcompartilhamento.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcompartilhamento.Enabled), 5, 0), true);
         chkavDocoperadorretencao.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorretencao.Enabled), 5, 0), true);
         chkavDocoperadoreliminacao.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadoreliminacao.Enabled), 5, 0), true);
         lblOperadoradd_Enabled = 0;
         AssignProp(sPrefix, false, lblOperadoradd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblOperadoradd_Enabled), 5, 0), true);
         bttBtnadicionar_Caption = "CONFIRMAR";
         AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
         AV49IsDisplay = true;
         AssignAttri(sPrefix, false, "AV49IsDisplay", AV49IsDisplay);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28DocOperador", AV28DocOperador);
         cmbavOperadorid_col.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42OperadorId_Col), 8, 0));
         AssignProp(sPrefix, false, cmbavOperadorid_col_Internalname, "Values", cmbavOperadorid_col.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'LIMPADADOS' Routine */
         returnInSub = false;
         AV42OperadorId_Col = 0;
         AssignAttri(sPrefix, false, "AV42OperadorId_Col", StringUtil.LTrimStr( (decimal)(AV42OperadorId_Col), 8, 0));
         AV7DocOperadorId = 0;
         AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
         AV17DocOperadorColeta = false;
         AssignAttri(sPrefix, false, "AV17DocOperadorColeta", AV17DocOperadorColeta);
         AV19DocOperadorCompartilhamento = false;
         AssignAttri(sPrefix, false, "AV19DocOperadorCompartilhamento", AV19DocOperadorCompartilhamento);
         AV20DocOperadorEliminacao = false;
         AssignAttri(sPrefix, false, "AV20DocOperadorEliminacao", AV20DocOperadorEliminacao);
         AV21DocOperadorProcessamento = false;
         AssignAttri(sPrefix, false, "AV21DocOperadorProcessamento", AV21DocOperadorProcessamento);
         AV18DocOperadorRetencao = false;
         AssignAttri(sPrefix, false, "AV18DocOperadorRetencao", AV18DocOperadorRetencao);
      }

      protected void S112( )
      {
         /* 'OPERADORCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavOperadorid_col.removeAllItems();
         cmbavOperadorid_col.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007B5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A44OperadorAtivo = H007B5_A44OperadorAtivo[0];
            A42OperadorId = H007B5_A42OperadorId[0];
            A43OperadorNome = H007B5_A43OperadorNome[0];
            cmbavOperadorid_col.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A42OperadorId), 8, 0)), A43OperadorNome, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void wb_table7_112_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_excluir_Internalname, tblTabledvelop_confirmpanel_excluir_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_excluir.SetProperty("Title", Dvelop_confirmpanel_excluir_Title);
            ucDvelop_confirmpanel_excluir.SetProperty("ConfirmationText", Dvelop_confirmpanel_excluir_Confirmationtext);
            ucDvelop_confirmpanel_excluir.SetProperty("YesButtonCaption", Dvelop_confirmpanel_excluir_Yesbuttoncaption);
            ucDvelop_confirmpanel_excluir.SetProperty("NoButtonCaption", Dvelop_confirmpanel_excluir_Nobuttoncaption);
            ucDvelop_confirmpanel_excluir.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_excluir_Cancelbuttoncaption);
            ucDvelop_confirmpanel_excluir.SetProperty("YesButtonPosition", Dvelop_confirmpanel_excluir_Yesbuttonposition);
            ucDvelop_confirmpanel_excluir.SetProperty("ConfirmType", Dvelop_confirmpanel_excluir_Confirmtype);
            ucDvelop_confirmpanel_excluir.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_excluir_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIRContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIRContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_112_7B2e( true) ;
         }
         else
         {
            wb_table7_112_7B2e( false) ;
         }
      }

      protected void wb_table6_72_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadorprocessamento_Internalname, tblTablemergeddocoperadorprocessamento_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadorprocessamento_Internalname, "Doc Operador Processamento", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorprocessamento_Internalname, StringUtil.BoolToStr( AV21DocOperadorProcessamento), "", "Doc Operador Processamento", 1, chkavDocoperadorprocessamento.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorprocessamento_righttext_Internalname, "PROCESSAMENTO", "", "", lblDocoperadorprocessamento_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_72_7B2e( true) ;
         }
         else
         {
            wb_table6_72_7B2e( false) ;
         }
      }

      protected void wb_table5_64_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadoreliminacao_Internalname, tblTablemergeddocoperadoreliminacao_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadoreliminacao_Internalname, "Doc Operador Eliminacao", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadoreliminacao_Internalname, StringUtil.BoolToStr( AV20DocOperadorEliminacao), "", "Doc Operador Eliminacao", 1, chkavDocoperadoreliminacao.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadoreliminacao_righttext_Internalname, "ELIMINAÇÃO", "", "", lblDocoperadoreliminacao_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_64_7B2e( true) ;
         }
         else
         {
            wb_table5_64_7B2e( false) ;
         }
      }

      protected void wb_table4_56_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadorcompartilhamento_Internalname, tblTablemergeddocoperadorcompartilhamento_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadorcompartilhamento_Internalname, "Doc Operador Compartilhamento", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorcompartilhamento_Internalname, StringUtil.BoolToStr( AV19DocOperadorCompartilhamento), "", "Doc Operador Compartilhamento", 1, chkavDocoperadorcompartilhamento.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcompartilhamento_righttext_Internalname, "COMPARTILHAMENTO", "", "", lblDocoperadorcompartilhamento_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_56_7B2e( true) ;
         }
         else
         {
            wb_table4_56_7B2e( false) ;
         }
      }

      protected void wb_table3_48_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadorretencao_Internalname, tblTablemergeddocoperadorretencao_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadorretencao_Internalname, "Doc Operador Retencao", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorretencao_Internalname, StringUtil.BoolToStr( AV18DocOperadorRetencao), "", "Doc Operador Retencao", 1, chkavDocoperadorretencao.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(52, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,52);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorretencao_righttext_Internalname, "RETENÇÃO", "", "", lblDocoperadorretencao_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_48_7B2e( true) ;
         }
         else
         {
            wb_table3_48_7B2e( false) ;
         }
      }

      protected void wb_table2_40_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadorcoleta_Internalname, tblTablemergeddocoperadorcoleta_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadorcoleta_Internalname, "Doc Operador Coleta", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_91_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorcoleta_Internalname, StringUtil.BoolToStr( AV17DocOperadorColeta), "", "Doc Operador Coleta", 1, chkavDocoperadorcoleta.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcoleta_righttext_Internalname, "COLETA", "", "", lblDocoperadorcoleta_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_40_7B2e( true) ;
         }
         else
         {
            wb_table2_40_7B2e( false) ;
         }
      }

      protected void wb_table1_27_7B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedoperadorinfo_Internalname, tblTablemergedoperadorinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOperadorinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblOperadorinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e217b1_client"+"'", "", "TextBlock", 7, lblOperadorinfo_Tooltiptext, lblOperadorinfo_Visible, 1, 0, 1, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOperadoradd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblOperadoradd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOOPERADORADD\\'."+"'", "", "TextBlock", 5, "", lblOperadoradd_Visible, lblOperadoradd_Enabled, 1, 1, "HLP_OperadorWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_27_7B2e( true) ;
         }
         else
         {
            wb_table1_27_7B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV8DocumentoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
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
         PA7B2( ) ;
         WS7B2( ) ;
         WE7B2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV8DocumentoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7B2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "operadorwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7B2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV8DocumentoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8DocumentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8DocumentoId != wcpOAV8DocumentoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8DocumentoId = AV8DocumentoId;
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
         sCtrlAV8DocumentoId = cgiGet( sPrefix+"AV8DocumentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV8DocumentoId) > 0 )
         {
            AV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8DocumentoId), ",", "."));
            AssignAttri(sPrefix, false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
         }
         else
         {
            AV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8DocumentoId_PARM"), ",", "."));
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
         INITWEB( ) ;
         nDraw = 0;
         PA7B2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7B2( ) ;
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
         WS7B2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8DocumentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8DocumentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8DocumentoId_CTRL", StringUtil.RTrim( sCtrlAV8DocumentoId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE7B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417261886", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("operadorwc.js", "?202312417261886", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_912( )
      {
         edtDocOperadorId_Internalname = sPrefix+"DOCOPERADORID_"+sGXsfl_91_idx;
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID_"+sGXsfl_91_idx;
         edtOperadorId_Internalname = sPrefix+"OPERADORID_"+sGXsfl_91_idx;
         edtOperadorNome_Internalname = sPrefix+"OPERADORNOME_"+sGXsfl_91_idx;
         chkDocOperadorColeta_Internalname = sPrefix+"DOCOPERADORCOLETA_"+sGXsfl_91_idx;
         chkDocOperadorCompartilhamento_Internalname = sPrefix+"DOCOPERADORCOMPARTILHAMENTO_"+sGXsfl_91_idx;
         chkDocOperadorEliminacao_Internalname = sPrefix+"DOCOPERADORELIMINACAO_"+sGXsfl_91_idx;
         chkDocOperadorProcessamento_Internalname = sPrefix+"DOCOPERADORPROCESSAMENTO_"+sGXsfl_91_idx;
         chkDocOperadorRetencao_Internalname = sPrefix+"DOCOPERADORRETENCAO_"+sGXsfl_91_idx;
         edtavOperadordados_Internalname = sPrefix+"vOPERADORDADOS_"+sGXsfl_91_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_91_idx;
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR_"+sGXsfl_91_idx;
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR_"+sGXsfl_91_idx;
      }

      protected void SubsflControlProps_fel_912( )
      {
         edtDocOperadorId_Internalname = sPrefix+"DOCOPERADORID_"+sGXsfl_91_fel_idx;
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID_"+sGXsfl_91_fel_idx;
         edtOperadorId_Internalname = sPrefix+"OPERADORID_"+sGXsfl_91_fel_idx;
         edtOperadorNome_Internalname = sPrefix+"OPERADORNOME_"+sGXsfl_91_fel_idx;
         chkDocOperadorColeta_Internalname = sPrefix+"DOCOPERADORCOLETA_"+sGXsfl_91_fel_idx;
         chkDocOperadorCompartilhamento_Internalname = sPrefix+"DOCOPERADORCOMPARTILHAMENTO_"+sGXsfl_91_fel_idx;
         chkDocOperadorEliminacao_Internalname = sPrefix+"DOCOPERADORELIMINACAO_"+sGXsfl_91_fel_idx;
         chkDocOperadorProcessamento_Internalname = sPrefix+"DOCOPERADORPROCESSAMENTO_"+sGXsfl_91_fel_idx;
         chkDocOperadorRetencao_Internalname = sPrefix+"DOCOPERADORRETENCAO_"+sGXsfl_91_fel_idx;
         edtavOperadordados_Internalname = sPrefix+"vOPERADORDADOS_"+sGXsfl_91_fel_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_91_fel_idx;
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR_"+sGXsfl_91_fel_idx;
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR_"+sGXsfl_91_fel_idx;
      }

      protected void sendrow_912( )
      {
         SubsflControlProps_912( ) ;
         WB7B0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_91_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_91_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_91_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocOperadorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocOperadorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperadorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A42OperadorId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A42OperadorId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperadorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperadorNome_Internalname,(string)A43OperadorNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtOperadorNome_Link,(string)"",(string)"",(string)"",(string)edtOperadorNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORCOLETA_" + sGXsfl_91_idx;
            chkDocOperadorColeta.Name = GXCCtl;
            chkDocOperadorColeta.WebTags = "";
            chkDocOperadorColeta.Caption = "";
            AssignProp(sPrefix, false, chkDocOperadorColeta_Internalname, "TitleCaption", chkDocOperadorColeta.Caption, !bGXsfl_91_Refreshing);
            chkDocOperadorColeta.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorColeta_Internalname,StringUtil.BoolToStr( A87DocOperadorColeta),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORCOMPARTILHAMENTO_" + sGXsfl_91_idx;
            chkDocOperadorCompartilhamento.Name = GXCCtl;
            chkDocOperadorCompartilhamento.WebTags = "";
            chkDocOperadorCompartilhamento.Caption = "";
            AssignProp(sPrefix, false, chkDocOperadorCompartilhamento_Internalname, "TitleCaption", chkDocOperadorCompartilhamento.Caption, !bGXsfl_91_Refreshing);
            chkDocOperadorCompartilhamento.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorCompartilhamento_Internalname,StringUtil.BoolToStr( A89DocOperadorCompartilhamento),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORELIMINACAO_" + sGXsfl_91_idx;
            chkDocOperadorEliminacao.Name = GXCCtl;
            chkDocOperadorEliminacao.WebTags = "";
            chkDocOperadorEliminacao.Caption = "";
            AssignProp(sPrefix, false, chkDocOperadorEliminacao_Internalname, "TitleCaption", chkDocOperadorEliminacao.Caption, !bGXsfl_91_Refreshing);
            chkDocOperadorEliminacao.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorEliminacao_Internalname,StringUtil.BoolToStr( A90DocOperadorEliminacao),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORPROCESSAMENTO_" + sGXsfl_91_idx;
            chkDocOperadorProcessamento.Name = GXCCtl;
            chkDocOperadorProcessamento.WebTags = "";
            chkDocOperadorProcessamento.Caption = "";
            AssignProp(sPrefix, false, chkDocOperadorProcessamento_Internalname, "TitleCaption", chkDocOperadorProcessamento.Caption, !bGXsfl_91_Refreshing);
            chkDocOperadorProcessamento.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorProcessamento_Internalname,StringUtil.BoolToStr( A91DocOperadorProcessamento),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCOPERADORRETENCAO_" + sGXsfl_91_idx;
            chkDocOperadorRetencao.Name = GXCCtl;
            chkDocOperadorRetencao.WebTags = "";
            chkDocOperadorRetencao.Caption = "";
            AssignProp(sPrefix, false, chkDocOperadorRetencao_Internalname, "TitleCaption", chkDocOperadorRetencao.Caption, !bGXsfl_91_Refreshing);
            chkDocOperadorRetencao.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocOperadorRetencao_Internalname,StringUtil.BoolToStr( A88DocOperadorRetencao),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavOperadordados_Enabled!=0)&&(edtavOperadordados_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 101,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOperadordados_Internalname,(string)AV16OperadorDados,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOperadordados_Enabled!=0)&&(edtavOperadordados_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,101);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOperadordados_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavOperadordados_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVisualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 102,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavVisualizar_Internalname,StringUtil.RTrim( AV24Visualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,102);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVVISUALIZAR.CLICK."+sGXsfl_91_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavVisualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavVisualizar_Visible,(int)edtavVisualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)91,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavAtualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAtualizar_Enabled!=0)&&(edtavAtualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 103,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAtualizar_Internalname,StringUtil.RTrim( AV25Atualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAtualizar_Enabled!=0)&&(edtavAtualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,103);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVATUALIZAR.CLICK."+sGXsfl_91_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAtualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavAtualizar_Visible,(int)edtavAtualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)91,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavExcluir_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavExcluir_Enabled!=0)&&(edtavExcluir_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 104,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExcluir_Internalname,StringUtil.RTrim( AV26Excluir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavExcluir_Enabled!=0)&&(edtavExcluir_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,104);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVEXCLUIR.CLICK."+sGXsfl_91_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExcluir_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavExcluir_Visible,(int)edtavExcluir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)91,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes7B2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_91_idx = ((subGrid_Islastpage==1)&&(nGXsfl_91_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_91_idx+1);
            sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
            SubsflControlProps_912( ) ;
         }
         /* End function sendrow_912 */
      }

      protected void init_web_controls( )
      {
         cmbavDocumentoisoperador.Name = "vDOCUMENTOISOPERADOR";
         cmbavDocumentoisoperador.WebTags = "";
         cmbavDocumentoisoperador.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbavDocumentoisoperador.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbavDocumentoisoperador.ItemCount > 0 )
         {
         }
         cmbavOperadorid_col.Name = "vOPERADORID_COL";
         cmbavOperadorid_col.WebTags = "";
         if ( cmbavOperadorid_col.ItemCount > 0 )
         {
         }
         chkavDocoperadorcoleta.Name = "vDOCOPERADORCOLETA";
         chkavDocoperadorcoleta.WebTags = "";
         chkavDocoperadorcoleta.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadorcoleta_Internalname, "TitleCaption", chkavDocoperadorcoleta.Caption, true);
         chkavDocoperadorcoleta.CheckedValue = "false";
         chkavDocoperadorretencao.Name = "vDOCOPERADORRETENCAO";
         chkavDocoperadorretencao.WebTags = "";
         chkavDocoperadorretencao.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadorretencao_Internalname, "TitleCaption", chkavDocoperadorretencao.Caption, true);
         chkavDocoperadorretencao.CheckedValue = "false";
         chkavDocoperadorcompartilhamento.Name = "vDOCOPERADORCOMPARTILHAMENTO";
         chkavDocoperadorcompartilhamento.WebTags = "";
         chkavDocoperadorcompartilhamento.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadorcompartilhamento_Internalname, "TitleCaption", chkavDocoperadorcompartilhamento.Caption, true);
         chkavDocoperadorcompartilhamento.CheckedValue = "false";
         chkavDocoperadoreliminacao.Name = "vDOCOPERADORELIMINACAO";
         chkavDocoperadoreliminacao.WebTags = "";
         chkavDocoperadoreliminacao.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadoreliminacao_Internalname, "TitleCaption", chkavDocoperadoreliminacao.Caption, true);
         chkavDocoperadoreliminacao.CheckedValue = "false";
         chkavDocoperadorprocessamento.Name = "vDOCOPERADORPROCESSAMENTO";
         chkavDocoperadorprocessamento.WebTags = "";
         chkavDocoperadorprocessamento.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadorprocessamento_Internalname, "TitleCaption", chkavDocoperadorprocessamento.Caption, true);
         chkavDocoperadorprocessamento.CheckedValue = "false";
         GXCCtl = "DOCOPERADORCOLETA_" + sGXsfl_91_idx;
         chkDocOperadorColeta.Name = GXCCtl;
         chkDocOperadorColeta.WebTags = "";
         chkDocOperadorColeta.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorColeta_Internalname, "TitleCaption", chkDocOperadorColeta.Caption, !bGXsfl_91_Refreshing);
         chkDocOperadorColeta.CheckedValue = "false";
         GXCCtl = "DOCOPERADORCOMPARTILHAMENTO_" + sGXsfl_91_idx;
         chkDocOperadorCompartilhamento.Name = GXCCtl;
         chkDocOperadorCompartilhamento.WebTags = "";
         chkDocOperadorCompartilhamento.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorCompartilhamento_Internalname, "TitleCaption", chkDocOperadorCompartilhamento.Caption, !bGXsfl_91_Refreshing);
         chkDocOperadorCompartilhamento.CheckedValue = "false";
         GXCCtl = "DOCOPERADORELIMINACAO_" + sGXsfl_91_idx;
         chkDocOperadorEliminacao.Name = GXCCtl;
         chkDocOperadorEliminacao.WebTags = "";
         chkDocOperadorEliminacao.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorEliminacao_Internalname, "TitleCaption", chkDocOperadorEliminacao.Caption, !bGXsfl_91_Refreshing);
         chkDocOperadorEliminacao.CheckedValue = "false";
         GXCCtl = "DOCOPERADORPROCESSAMENTO_" + sGXsfl_91_idx;
         chkDocOperadorProcessamento.Name = GXCCtl;
         chkDocOperadorProcessamento.WebTags = "";
         chkDocOperadorProcessamento.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorProcessamento_Internalname, "TitleCaption", chkDocOperadorProcessamento.Caption, !bGXsfl_91_Refreshing);
         chkDocOperadorProcessamento.CheckedValue = "false";
         GXCCtl = "DOCOPERADORRETENCAO_" + sGXsfl_91_idx;
         chkDocOperadorRetencao.Name = GXCCtl;
         chkDocOperadorRetencao.WebTags = "";
         chkDocOperadorRetencao.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorRetencao_Internalname, "TitleCaption", chkDocOperadorRetencao.Caption, !bGXsfl_91_Refreshing);
         chkDocOperadorRetencao.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl91( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"91\">") ;
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Doc Operador Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id do Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id do Operador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "NOME") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Coleta?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Compartilhamento?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Eliminição?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Processamento?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Retenção?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "DADOS") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVisualizar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavAtualizar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavExcluir_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A42OperadorId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A43OperadorNome);
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtOperadorNome_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A87DocOperadorColeta));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A89DocOperadorCompartilhamento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A90DocOperadorEliminacao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A91DocOperadorProcessamento));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A88DocOperadorRetencao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", AV16OperadorDados);
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOperadordados_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV24Visualizar));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV25Atualizar));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV26Excluir));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Visible), 5, 0, ".", "")));
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
         cmbavDocumentoisoperador_Internalname = sPrefix+"vDOCUMENTOISOPERADOR";
         cmbavOperadorid_col_Internalname = sPrefix+"vOPERADORID_COL";
         lblOperadorinfo_Internalname = sPrefix+"OPERADORINFO";
         lblOperadoradd_Internalname = sPrefix+"OPERADORADD";
         tblTablemergedoperadorinfo_Internalname = sPrefix+"TABLEMERGEDOPERADORINFO";
         chkavDocoperadorcoleta_Internalname = sPrefix+"vDOCOPERADORCOLETA";
         lblDocoperadorcoleta_righttext_Internalname = sPrefix+"DOCOPERADORCOLETA_RIGHTTEXT";
         tblTablemergeddocoperadorcoleta_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCOLETA";
         chkavDocoperadorretencao_Internalname = sPrefix+"vDOCOPERADORRETENCAO";
         lblDocoperadorretencao_righttext_Internalname = sPrefix+"DOCOPERADORRETENCAO_RIGHTTEXT";
         tblTablemergeddocoperadorretencao_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORRETENCAO";
         chkavDocoperadorcompartilhamento_Internalname = sPrefix+"vDOCOPERADORCOMPARTILHAMENTO";
         lblDocoperadorcompartilhamento_righttext_Internalname = sPrefix+"DOCOPERADORCOMPARTILHAMENTO_RIGHTTEXT";
         tblTablemergeddocoperadorcompartilhamento_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCOMPARTILHAMENTO";
         chkavDocoperadoreliminacao_Internalname = sPrefix+"vDOCOPERADORELIMINACAO";
         lblDocoperadoreliminacao_righttext_Internalname = sPrefix+"DOCOPERADORELIMINACAO_RIGHTTEXT";
         tblTablemergeddocoperadoreliminacao_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORELIMINACAO";
         chkavDocoperadorprocessamento_Internalname = sPrefix+"vDOCOPERADORPROCESSAMENTO";
         lblDocoperadorprocessamento_righttext_Internalname = sPrefix+"DOCOPERADORPROCESSAMENTO_RIGHTTEXT";
         tblTablemergeddocoperadorprocessamento_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORPROCESSAMENTO";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTabledadoscheck_Internalname = sPrefix+"TABLEDADOSCHECK";
         bttBtnadicionar_Internalname = sPrefix+"BTNADICIONAR";
         edtavFiltrooperador_Internalname = sPrefix+"vFILTROOPERADOR";
         edtDocOperadorId_Internalname = sPrefix+"DOCOPERADORID";
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID";
         edtOperadorId_Internalname = sPrefix+"OPERADORID";
         edtOperadorNome_Internalname = sPrefix+"OPERADORNOME";
         chkDocOperadorColeta_Internalname = sPrefix+"DOCOPERADORCOLETA";
         chkDocOperadorCompartilhamento_Internalname = sPrefix+"DOCOPERADORCOMPARTILHAMENTO";
         chkDocOperadorEliminacao_Internalname = sPrefix+"DOCOPERADORELIMINACAO";
         chkDocOperadorProcessamento_Internalname = sPrefix+"DOCOPERADORPROCESSAMENTO";
         chkDocOperadorRetencao_Internalname = sPrefix+"DOCOPERADORRETENCAO";
         edtavOperadordados_Internalname = sPrefix+"vOPERADORDADOS";
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR";
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR";
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         divTableoperadordados_Internalname = sPrefix+"TABLEOPERADORDADOS";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain1_Internalname = sPrefix+"TABLEMAIN1";
         edtavDocoperadorid_Internalname = sPrefix+"vDOCOPERADORID";
         edtavDocumentoid_Internalname = sPrefix+"vDOCUMENTOID";
         edtavOperadorid_Internalname = sPrefix+"vOPERADORID";
         edtavDocoperadordatainclusao_Internalname = sPrefix+"vDOCOPERADORDATAINCLUSAO";
         Dvelop_confirmpanel_excluir_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_EXCLUIR";
         tblTabledvelop_confirmpanel_excluir_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_EXCLUIR";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavDocoperadorprocessamento.Caption = "Doc Operador Processamento";
         chkavDocoperadoreliminacao.Caption = "Doc Operador Eliminacao";
         chkavDocoperadorcompartilhamento.Caption = "Doc Operador Compartilhamento";
         chkavDocoperadorretencao.Caption = "Doc Operador Retencao";
         chkavDocoperadorcoleta.Caption = "Doc Operador Coleta";
         edtavExcluir_Jsonclick = "";
         edtavExcluir_Enabled = 1;
         edtavAtualizar_Jsonclick = "";
         edtavAtualizar_Enabled = 1;
         edtavVisualizar_Jsonclick = "";
         edtavVisualizar_Enabled = 1;
         edtavOperadordados_Jsonclick = "";
         edtavOperadordados_Visible = -1;
         edtavOperadordados_Enabled = 1;
         chkDocOperadorRetencao.Caption = "";
         chkDocOperadorProcessamento.Caption = "";
         chkDocOperadorEliminacao.Caption = "";
         chkDocOperadorCompartilhamento.Caption = "";
         chkDocOperadorColeta.Caption = "";
         edtOperadorNome_Jsonclick = "";
         edtOperadorNome_Link = "";
         edtOperadorId_Jsonclick = "";
         edtDocumentoId_Jsonclick = "";
         edtDocOperadorId_Jsonclick = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         lblOperadoradd_Enabled = 1;
         lblOperadoradd_Visible = 1;
         lblOperadorinfo_Visible = 1;
         edtavVisualizar_Visible = -1;
         lblOperadorinfo_Tooltiptext = "";
         chkavDocoperadorprocessamento.Enabled = 1;
         chkavDocoperadoreliminacao.Enabled = 1;
         chkavDocoperadorcompartilhamento.Enabled = 1;
         chkavDocoperadorretencao.Enabled = 1;
         chkavDocoperadorcoleta.Enabled = 1;
         edtavDocoperadordatainclusao_Jsonclick = "";
         edtavDocoperadordatainclusao_Visible = 1;
         edtavOperadorid_Jsonclick = "";
         edtavOperadorid_Visible = 1;
         edtavDocumentoid_Jsonclick = "";
         edtavDocumentoid_Visible = 1;
         edtavDocoperadorid_Jsonclick = "";
         edtavDocoperadorid_Visible = 1;
         edtavFiltrooperador_Jsonclick = "";
         edtavFiltrooperador_Enabled = 1;
         bttBtnadicionar_Caption = "ADICIONAR";
         bttBtnadicionar_Enabled = 1;
         bttBtnadicionar_Visible = 1;
         cmbavOperadorid_col_Jsonclick = "";
         cmbavOperadorid_col.Enabled = 1;
         cmbavDocumentoisoperador_Jsonclick = "";
         cmbavDocumentoisoperador.Enabled = 1;
         Grid_empowerer_Infinitescrolling = "Grid";
         Dvelop_confirmpanel_excluir_Confirmtype = "1";
         Dvelop_confirmpanel_excluir_Yesbuttonposition = "left";
         Dvelop_confirmpanel_excluir_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_excluir_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_excluir_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_excluir_Confirmationtext = "Confirma a exclusão desse operador?";
         Dvelop_confirmpanel_excluir_Title = "Atenção!";
         edtavExcluir_Visible = -1;
         edtavAtualizar_Visible = -1;
         subGrid_Rows = 50;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'sPrefix'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E177B2',iparms:[{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV16OperadorDados',fld:'vOPERADORDADOS',pic:''},{av:'AV24Visualizar',fld:'vVISUALIZAR',pic:''},{av:'AV25Atualizar',fld:'vATUALIZAR',pic:''},{av:'AV26Excluir',fld:'vEXCLUIR',pic:''},{av:'edtOperadorNome_Link',ctrl:'OPERADORNOME',prop:'Link'}]}");
         setEventMetadata("'DOOPERADORINFO'","{handler:'E217B1',iparms:[]");
         setEventMetadata("'DOOPERADORINFO'",",oparms:[]}");
         setEventMetadata("'DOOPERADORADD'","{handler:'E127B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOOPERADORADD'",",oparms:[{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("'DOADICIONAR'","{handler:'E137B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'AV49IsDisplay',fld:'vISDISPLAY',pic:''},{av:'AV35CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV7DocOperadorId',fld:'vDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV11DocOperadorDataInclusao',fld:'vDOCOPERADORDATAINCLUSAO',pic:''},{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV28DocOperador',fld:'vDOCOPERADOR',pic:''},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOADICIONAR'",",oparms:[{av:'cmbavOperadorid_col'},{av:'chkavDocoperadorcoleta.Enabled',ctrl:'vDOCOPERADORCOLETA',prop:'Enabled'},{av:'chkavDocoperadorprocessamento.Enabled',ctrl:'vDOCOPERADORPROCESSAMENTO',prop:'Enabled'},{av:'chkavDocoperadorcompartilhamento.Enabled',ctrl:'vDOCOPERADORCOMPARTILHAMENTO',prop:'Enabled'},{av:'chkavDocoperadorretencao.Enabled',ctrl:'vDOCOPERADORRETENCAO',prop:'Enabled'},{av:'chkavDocoperadoreliminacao.Enabled',ctrl:'vDOCOPERADORELIMINACAO',prop:'Enabled'},{av:'lblOperadoradd_Enabled',ctrl:'OPERADORADD',prop:'Enabled'},{ctrl:'BTNADICIONAR',prop:'Caption'},{av:'AV49IsDisplay',fld:'vISDISPLAY',pic:''},{av:'AV28DocOperador',fld:'vDOCOPERADOR',pic:''},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV7DocOperadorId',fld:'vDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV35CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("VEXCLUIR.CLICK","{handler:'E187B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VEXCLUIR.CLICK",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_EXCLUIR.CLOSE","{handler:'E117B2',iparms:[{av:'Dvelop_confirmpanel_excluir_Result',ctrl:'DVELOP_CONFIRMPANEL_EXCLUIR',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9',hsh:true},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_EXCLUIR.CLOSE",",oparms:[{av:'AV28DocOperador',fld:'vDOCOPERADOR',pic:''},{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("VDOCUMENTOISOPERADOR.CONTROLVALUECHANGED","{handler:'E147B2',iparms:[{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'cmbavDocumentoisoperador'},{av:'AV50DocumentoIsOperador',fld:'vDOCUMENTOISOPERADOR',pic:''}]");
         setEventMetadata("VDOCUMENTOISOPERADOR.CONTROLVALUECHANGED",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'chkavDocoperadorcoleta.Enabled',ctrl:'vDOCOPERADORCOLETA',prop:'Enabled'},{av:'chkavDocoperadorretencao.Enabled',ctrl:'vDOCOPERADORRETENCAO',prop:'Enabled'},{av:'chkavDocoperadorcompartilhamento.Enabled',ctrl:'vDOCOPERADORCOMPARTILHAMENTO',prop:'Enabled'},{av:'chkavDocoperadoreliminacao.Enabled',ctrl:'vDOCOPERADORELIMINACAO',prop:'Enabled'},{av:'chkavDocoperadorprocessamento.Enabled',ctrl:'vDOCOPERADORPROCESSAMENTO',prop:'Enabled'},{ctrl:'BTNADICIONAR',prop:'Enabled'},{av:'lblOperadoradd_Enabled',ctrl:'OPERADORADD',prop:'Enabled'}]}");
         setEventMetadata("VATUALIZAR.CLICK","{handler:'E197B2',iparms:[{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VATUALIZAR.CLICK",",oparms:[{av:'AV28DocOperador',fld:'vDOCOPERADOR',pic:''},{av:'AV7DocOperadorId',fld:'vDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{ctrl:'BTNADICIONAR',prop:'Caption'}]}");
         setEventMetadata("VVISUALIZAR.CLICK","{handler:'E207B2',iparms:[{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VVISUALIZAR.CLICK",",oparms:[{av:'AV28DocOperador',fld:'vDOCOPERADOR',pic:''},{av:'AV7DocOperadorId',fld:'vDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'chkavDocoperadorcoleta.Enabled',ctrl:'vDOCOPERADORCOLETA',prop:'Enabled'},{av:'chkavDocoperadorprocessamento.Enabled',ctrl:'vDOCOPERADORPROCESSAMENTO',prop:'Enabled'},{av:'chkavDocoperadorcompartilhamento.Enabled',ctrl:'vDOCOPERADORCOMPARTILHAMENTO',prop:'Enabled'},{av:'chkavDocoperadorretencao.Enabled',ctrl:'vDOCOPERADORRETENCAO',prop:'Enabled'},{av:'chkavDocoperadoreliminacao.Enabled',ctrl:'vDOCOPERADORELIMINACAO',prop:'Enabled'},{av:'lblOperadoradd_Enabled',ctrl:'OPERADORADD',prop:'Enabled'},{ctrl:'BTNADICIONAR',prop:'Caption'},{av:'AV49IsDisplay',fld:'vISDISPLAY',pic:''}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV32FiltroOperador',fld:'vFILTROOPERADOR',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV31IsAuthorized_OperadorNome',fld:'vISAUTHORIZED_OPERADORNOME',pic:'',hsh:true},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'sPrefix'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'A43OperadorNome',fld:'OPERADORNOME',pic:''},{av:'A44OperadorAtivo',fld:'OPERADORATIVO',pic:''},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV17DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV18DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV19DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV20DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV21DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'cmbavOperadorid_col'},{av:'AV42OperadorId_Col',fld:'vOPERADORID_COL',pic:'ZZZZZZZ9'},{av:'AV43IsOperador',fld:'vISOPERADOR',pic:''},{av:'AV44OperadorId_Out',fld:'vOPERADORID_OUT',pic:'ZZZZZZZ9'},{av:'lblOperadoradd_Visible',ctrl:'OPERADORADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'AV39IsAuthorized_Excluir',fld:'vISAUTHORIZED_EXCLUIR',pic:'',hsh:true},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("VALIDV_DOCUMENTOID","{handler:'Validv_Documentoid',iparms:[]");
         setEventMetadata("VALIDV_DOCUMENTOID",",oparms:[]}");
         setEventMetadata("VALIDV_DOCOPERADORDATAINCLUSAO","{handler:'Validv_Docoperadordatainclusao',iparms:[]");
         setEventMetadata("VALIDV_DOCOPERADORDATAINCLUSAO",",oparms:[]}");
         setEventMetadata("VALID_OPERADORID","{handler:'Valid_Operadorid',iparms:[]");
         setEventMetadata("VALID_OPERADORID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Excluir',iparms:[]");
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
         wcpOGx_mode = "";
         Dvelop_confirmpanel_excluir_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV32FiltroOperador = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV28DocOperador = new SdtDocOperador(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnadicionar_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         AV11DocOperadorDataInclusao = DateTime.MinValue;
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A43OperadorNome = "";
         AV16OperadorDados = "";
         AV24Visualizar = "";
         AV25Atualizar = "";
         AV26Excluir = "";
         GXDecQS = "";
         GXCCtl = "";
         scmdbuf = "";
         H007B2_A88DocOperadorRetencao = new bool[] {false} ;
         H007B2_A91DocOperadorProcessamento = new bool[] {false} ;
         H007B2_A90DocOperadorEliminacao = new bool[] {false} ;
         H007B2_A89DocOperadorCompartilhamento = new bool[] {false} ;
         H007B2_A87DocOperadorColeta = new bool[] {false} ;
         H007B2_A43OperadorNome = new string[] {""} ;
         H007B2_A42OperadorId = new int[1] ;
         H007B2_A75DocumentoId = new int[1] ;
         H007B2_A86DocOperadorId = new int[1] ;
         H007B3_AGRID_nRecordCount = new long[1] ;
         AV46Documento = new SdtDocumento(context);
         H007B4_A112TooltipId = new int[1] ;
         H007B4_A135CampoId = new int[1] ;
         H007B4_A139TooltipTelaId = new int[1] ;
         H007B4_A140TooltipTelaNome = new string[] {""} ;
         H007B4_A118TooltipAtivo = new bool[] {false} ;
         H007B4_A136CampoNome = new string[] {""} ;
         H007B4_A115TooltipDescricao = new string[] {""} ;
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         GridRow = new GXWebRow();
         AV55GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV30Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV57GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV59GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV61GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H007B5_A44OperadorAtivo = new bool[] {false} ;
         H007B5_A42OperadorId = new int[1] ;
         H007B5_A43OperadorNome = new string[] {""} ;
         ucDvelop_confirmpanel_excluir = new GXUserControl();
         lblDocoperadorprocessamento_righttext_Jsonclick = "";
         lblDocoperadoreliminacao_righttext_Jsonclick = "";
         lblDocoperadorcompartilhamento_righttext_Jsonclick = "";
         lblDocoperadorretencao_righttext_Jsonclick = "";
         lblDocoperadorcoleta_righttext_Jsonclick = "";
         lblOperadorinfo_Jsonclick = "";
         lblOperadoradd_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV8DocumentoId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.operadorwc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operadorwc__default(),
            new Object[][] {
                new Object[] {
               H007B2_A88DocOperadorRetencao, H007B2_A91DocOperadorProcessamento, H007B2_A90DocOperadorEliminacao, H007B2_A89DocOperadorCompartilhamento, H007B2_A87DocOperadorColeta, H007B2_A43OperadorNome, H007B2_A42OperadorId, H007B2_A75DocumentoId, H007B2_A86DocOperadorId
               }
               , new Object[] {
               H007B3_AGRID_nRecordCount
               }
               , new Object[] {
               H007B4_A112TooltipId, H007B4_A135CampoId, H007B4_A139TooltipTelaId, H007B4_A140TooltipTelaNome, H007B4_A118TooltipAtivo, H007B4_A136CampoNome, H007B4_A115TooltipDescricao
               }
               , new Object[] {
               H007B5_A44OperadorAtivo, H007B5_A42OperadorId, H007B5_A43OperadorNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavOperadordados_Enabled = 0;
         edtavVisualizar_Enabled = 0;
         edtavAtualizar_Enabled = 0;
         edtavExcluir_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV8DocumentoId ;
      private int wcpOAV8DocumentoId ;
      private int edtavAtualizar_Visible ;
      private int edtavExcluir_Visible ;
      private int nRC_GXsfl_91 ;
      private int subGrid_Rows ;
      private int nGXsfl_91_idx=1 ;
      private int AV44OperadorId_Out ;
      private int edtavOperadordados_Enabled ;
      private int edtavVisualizar_Enabled ;
      private int edtavAtualizar_Enabled ;
      private int edtavExcluir_Enabled ;
      private int AV42OperadorId_Col ;
      private int bttBtnadicionar_Visible ;
      private int bttBtnadicionar_Enabled ;
      private int edtavFiltrooperador_Enabled ;
      private int AV7DocOperadorId ;
      private int edtavDocoperadorid_Visible ;
      private int edtavDocumentoid_Visible ;
      private int AV9OperadorId ;
      private int edtavOperadorid_Visible ;
      private int edtavDocoperadordatainclusao_Visible ;
      private int A86DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int lblOperadoradd_Enabled ;
      private int lblOperadorinfo_Visible ;
      private int lblOperadoradd_Visible ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int AV56GXV2 ;
      private int AV58GXV4 ;
      private int edtavVisualizar_Visible ;
      private int AV60GXV6 ;
      private int AV62GXV8 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavOperadordados_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Dvelop_confirmpanel_excluir_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_91_idx="0001" ;
      private string edtavAtualizar_Internalname ;
      private string edtavExcluir_Internalname ;
      private string edtavOperadordados_Internalname ;
      private string edtavVisualizar_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvelop_confirmpanel_excluir_Title ;
      private string Dvelop_confirmpanel_excluir_Confirmationtext ;
      private string Dvelop_confirmpanel_excluir_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_excluir_Nobuttoncaption ;
      private string Dvelop_confirmpanel_excluir_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_excluir_Yesbuttonposition ;
      private string Dvelop_confirmpanel_excluir_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Infinitescrolling ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string cmbavDocumentoisoperador_Internalname ;
      private string TempTags ;
      private string cmbavDocumentoisoperador_Jsonclick ;
      private string divTableoperadordados_Internalname ;
      private string cmbavOperadorid_col_Internalname ;
      private string cmbavOperadorid_col_Jsonclick ;
      private string divTabledadoscheck_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtnadicionar_Internalname ;
      private string bttBtnadicionar_Caption ;
      private string bttBtnadicionar_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string edtavFiltrooperador_Internalname ;
      private string edtavFiltrooperador_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavDocoperadorid_Internalname ;
      private string edtavDocoperadorid_Jsonclick ;
      private string edtavDocumentoid_Internalname ;
      private string edtavDocumentoid_Jsonclick ;
      private string edtavOperadorid_Internalname ;
      private string edtavOperadorid_Jsonclick ;
      private string edtavDocoperadordatainclusao_Internalname ;
      private string edtavDocoperadordatainclusao_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtDocOperadorId_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtOperadorId_Internalname ;
      private string edtOperadorNome_Internalname ;
      private string chkDocOperadorColeta_Internalname ;
      private string chkDocOperadorCompartilhamento_Internalname ;
      private string chkDocOperadorEliminacao_Internalname ;
      private string chkDocOperadorProcessamento_Internalname ;
      private string chkDocOperadorRetencao_Internalname ;
      private string AV24Visualizar ;
      private string AV25Atualizar ;
      private string AV26Excluir ;
      private string GXDecQS ;
      private string GXCCtl ;
      private string scmdbuf ;
      private string chkavDocoperadorcoleta_Internalname ;
      private string chkavDocoperadorretencao_Internalname ;
      private string chkavDocoperadorcompartilhamento_Internalname ;
      private string chkavDocoperadoreliminacao_Internalname ;
      private string chkavDocoperadorprocessamento_Internalname ;
      private string lblOperadoradd_Internalname ;
      private string lblOperadorinfo_Internalname ;
      private string lblOperadorinfo_Tooltiptext ;
      private string edtOperadorNome_Link ;
      private string tblTabledvelop_confirmpanel_excluir_Internalname ;
      private string Dvelop_confirmpanel_excluir_Internalname ;
      private string tblTablemergeddocoperadorprocessamento_Internalname ;
      private string lblDocoperadorprocessamento_righttext_Internalname ;
      private string lblDocoperadorprocessamento_righttext_Jsonclick ;
      private string tblTablemergeddocoperadoreliminacao_Internalname ;
      private string lblDocoperadoreliminacao_righttext_Internalname ;
      private string lblDocoperadoreliminacao_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorcompartilhamento_Internalname ;
      private string lblDocoperadorcompartilhamento_righttext_Internalname ;
      private string lblDocoperadorcompartilhamento_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorretencao_Internalname ;
      private string lblDocoperadorretencao_righttext_Internalname ;
      private string lblDocoperadorretencao_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorcoleta_Internalname ;
      private string lblDocoperadorcoleta_righttext_Internalname ;
      private string lblDocoperadorcoleta_righttext_Jsonclick ;
      private string tblTablemergedoperadorinfo_Internalname ;
      private string lblOperadorinfo_Jsonclick ;
      private string lblOperadoradd_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV8DocumentoId ;
      private string sGXsfl_91_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtDocOperadorId_Jsonclick ;
      private string edtDocumentoId_Jsonclick ;
      private string edtOperadorId_Jsonclick ;
      private string edtOperadorNome_Jsonclick ;
      private string edtavOperadordados_Jsonclick ;
      private string edtavVisualizar_Jsonclick ;
      private string edtavAtualizar_Jsonclick ;
      private string edtavExcluir_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV11DocOperadorDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_91_Refreshing=false ;
      private bool AV43IsOperador ;
      private bool A44OperadorAtivo ;
      private bool AV31IsAuthorized_OperadorNome ;
      private bool AV17DocOperadorColeta ;
      private bool AV18DocOperadorRetencao ;
      private bool AV19DocOperadorCompartilhamento ;
      private bool AV20DocOperadorEliminacao ;
      private bool AV21DocOperadorProcessamento ;
      private bool AV39IsAuthorized_Excluir ;
      private bool AV49IsDisplay ;
      private bool AV35CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool AV50DocumentoIsOperador ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A87DocOperadorColeta ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool A88DocOperadorRetencao ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A118TooltipAtivo ;
      private bool gx_refresh_fired ;
      private bool AV41IsAuthorized_OperadorAdd ;
      private bool AV40IsAuthorized_Adicionar ;
      private bool AV38IsAuthorized_Visualizar ;
      private bool AV37IsAuthorized_Atualizar ;
      private bool GXt_boolean1 ;
      private string A115TooltipDescricao ;
      private string AV32FiltroOperador ;
      private string A43OperadorNome ;
      private string AV16OperadorDados ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_excluir ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDocumentoisoperador ;
      private GXCombobox cmbavOperadorid_col ;
      private GXCheckbox chkavDocoperadorcoleta ;
      private GXCheckbox chkavDocoperadorretencao ;
      private GXCheckbox chkavDocoperadorcompartilhamento ;
      private GXCheckbox chkavDocoperadoreliminacao ;
      private GXCheckbox chkavDocoperadorprocessamento ;
      private GXCheckbox chkDocOperadorColeta ;
      private GXCheckbox chkDocOperadorCompartilhamento ;
      private GXCheckbox chkDocOperadorEliminacao ;
      private GXCheckbox chkDocOperadorProcessamento ;
      private GXCheckbox chkDocOperadorRetencao ;
      private IDataStoreProvider pr_default ;
      private bool[] H007B2_A88DocOperadorRetencao ;
      private bool[] H007B2_A91DocOperadorProcessamento ;
      private bool[] H007B2_A90DocOperadorEliminacao ;
      private bool[] H007B2_A89DocOperadorCompartilhamento ;
      private bool[] H007B2_A87DocOperadorColeta ;
      private string[] H007B2_A43OperadorNome ;
      private int[] H007B2_A42OperadorId ;
      private int[] H007B2_A75DocumentoId ;
      private int[] H007B2_A86DocOperadorId ;
      private long[] H007B3_AGRID_nRecordCount ;
      private int[] H007B4_A112TooltipId ;
      private int[] H007B4_A135CampoId ;
      private int[] H007B4_A139TooltipTelaId ;
      private string[] H007B4_A140TooltipTelaNome ;
      private bool[] H007B4_A118TooltipAtivo ;
      private string[] H007B4_A136CampoNome ;
      private string[] H007B4_A115TooltipDescricao ;
      private bool[] H007B5_A44OperadorAtivo ;
      private int[] H007B5_A42OperadorId ;
      private string[] H007B5_A43OperadorNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV57GXV3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV59GXV5 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV61GXV7 ;
      private SdtDocOperador AV28DocOperador ;
      private GeneXus.Utils.SdtMessages_Message AV30Message ;
      private SdtDocumento AV46Documento ;
   }

   public class operadorwc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class operadorwc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H007B2( IGxContext context ,
                                           string AV32FiltroOperador ,
                                           int AV8DocumentoId ,
                                           int A75DocumentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[5];
       Object[] GXv_Object3 = new Object[2];
       string sSelectString;
       string sFromString;
       string sOrderString;
       sSelectString = " T1.[DocOperadorRetencao], T1.[DocOperadorProcessamento], T1.[DocOperadorEliminacao], T1.[DocOperadorCompartilhamento], T1.[DocOperadorColeta], T2.[OperadorNome], T1.[OperadorId], T1.[DocumentoId], T1.[DocOperadorId]";
       sFromString = " FROM ([DocOperador] T1 INNER JOIN [Operador] T2 ON T2.[OperadorId] = T1.[OperadorId])";
       sOrderString = "";
       AddWhere(sWhereString, "(T1.[DocumentoId] = @AV8DocumentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32FiltroOperador)) )
       {
          AddWhere(sWhereString, "((CHARINDEX(RTRIM(RTRIM(LTRIM(@AV32FiltroOperador))), T2.[OperadorNome])) >= 1)");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       sOrderString += " ORDER BY T1.[DocumentoId]";
       scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    protected Object[] conditional_H007B3( IGxContext context ,
                                           string AV32FiltroOperador ,
                                           int AV8DocumentoId ,
                                           int A75DocumentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int4 = new short[2];
       Object[] GXv_Object5 = new Object[2];
       scmdbuf = "SELECT COUNT(*) FROM ([DocOperador] T1 INNER JOIN [Operador] T2 ON T2.[OperadorId] = T1.[OperadorId])";
       AddWhere(sWhereString, "(T1.[DocumentoId] = @AV8DocumentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32FiltroOperador)) )
       {
          AddWhere(sWhereString, "((CHARINDEX(RTRIM(RTRIM(LTRIM(@AV32FiltroOperador))), T2.[OperadorNome])) >= 1)");
       }
       else
       {
          GXv_int4[1] = 1;
       }
       scmdbuf += sWhereString;
       GXv_Object5[0] = scmdbuf;
       GXv_Object5[1] = GXv_int4;
       return GXv_Object5 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H007B2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] );
             case 1 :
                   return conditional_H007B3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH007B4;
        prmH007B4 = new Object[] {
        };
        Object[] prmH007B5;
        prmH007B5 = new Object[] {
        };
        Object[] prmH007B2;
        prmH007B2 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@AV32FiltroOperador",GXType.VarChar,100,0) ,
        new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH007B3;
        prmH007B3 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@AV32FiltroOperador",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("H007B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007B2,51, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007B4", "SELECT T1.[TooltipId], T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipAtivo], T2.[CampoNome], T1.[TooltipDescricao] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId]) WHERE (T1.[TooltipAtivo] = 1) AND (T3.[TelaNome] = 'OPERADOR') ORDER BY T1.[TooltipId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007B4,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007B5", "SELECT [OperadorAtivo], [OperadorId], [OperadorNome] FROM [Operador] WHERE [OperadorAtivo] = 1 ORDER BY [OperadorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007B5,100, GxCacheFrequency.OFF ,false,false )
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
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              return;
           case 3 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
  }

}

}
