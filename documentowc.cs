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
   public class documentowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public documentowc( )
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

      public documentowc( IGxContext context )
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
         cmbavDocumentoprocessoid = new GXCombobox();
         cmbavSubprocessoid = new GXCombobox();
         cmbavArearesponsavelid = new GXCombobox();
         cmbavDocumentocontroladorid = new GXCombobox();
         cmbavPersonaid = new GXCombobox();
         cmbavEncarregadoid = new GXCombobox();
         cmbavDocumentoativo = new GXCombobox();
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
            PA782( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavDocumentoid_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Enabled), 5, 0), true);
               edtavDocumentousuarioinclusao_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentousuarioinclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioinclusao_Enabled), 5, 0), true);
               edtavDocumentodatainclusao_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentodatainclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodatainclusao_Enabled), 5, 0), true);
               edtavDocumentousuarioalteracao_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentousuarioalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioalteracao_Enabled), 5, 0), true);
               edtavDocumentodataalteracao_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentodataalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodataalteracao_Enabled), 5, 0), true);
               WS782( ) ;
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
            context.SendWebValue( "Aba inicial para o cadastro de um Documento") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "documentowc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documentowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOID_COPIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51DocumentoId_Copia), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTONOME_COPIA", AV53DocumentoNome_Copia);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPROCESSO", AV29IsProcesso);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROCESSOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ProcessoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSUBPROCESSO", AV31IsSubProcesso);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSUBPROCESSOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32SubProcessoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPERSONA", AV37IsPersona);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERSONAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38PersonaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISENCARREGADO", AV39IsEncarregado);
         GxWebStd.gx_hidden_field( context, sPrefix+"vENCARREGADOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40EncarregadoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAREARESPONSAVEL", AV57IsAreaResponsavel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAREARESPONSAVELID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43AreaResponsavelId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISCONTROLADOR", AV34IsControlador);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCONTROLADORID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ControladorId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROCESSONOME", A17ProcessoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"PROCESSOATIVO", A19ProcessoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROCESSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ProcessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUBPROCESSONOME", A21SubprocessoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"SUBPROCESSOATIVO", A23SubprocessoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"SUBPROCESSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PERSONANOME", A14PersonaNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"PERSONAATIVO", A15PersonaAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"PERSONAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PersonaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ENCARREGADONOME", A8EncarregadoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"ENCARREGADOATIVO", A9EncarregadoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENCARREGADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7EncarregadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"AREARESPONSAVELNOME", A25AreaResponsavelNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"AREARESPONSAVELATIVO", A26AreaResponsavelAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"AREARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AreaResponsavelId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTROLADORNOME", A11ControladorNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"CONTROLADORATIVO", A12ControladorAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTROLADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ControladorId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV27CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCUMENTO", AV20Documento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCUMENTO", AV20Documento);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vORIGEM", AV60Origem);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROCESSOID_COL", AV63ProcessoId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROCESSOID_COL", AV63ProcessoId_Col);
         }
      }

      protected void RenderHtmlCloseForm782( )
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
         return "DocumentoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aba inicial para o cadastro de um Documento" ;
      }

      protected void WB780( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "documentowc.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledocumento_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocumentoprocessoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocumentoprocessoid_Internalname, "PROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentoprocessoid, cmbavDocumentoprocessoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0)), 1, cmbavDocumentoprocessoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDocumentoprocessoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0));
            AssignProp(sPrefix, false, cmbavDocumentoprocessoid_Internalname, "Values", (string)(cmbavDocumentoprocessoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table1_22_782( true) ;
         }
         else
         {
            wb_table1_22_782( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_782e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentoid_Internalname, "CÓDIGO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavDocumentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8DocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentoid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavSubprocessoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSubprocessoid_Internalname, "SUBPROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSubprocessoid, cmbavSubprocessoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0)), 1, cmbavSubprocessoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSubprocessoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0));
            AssignProp(sPrefix, false, cmbavSubprocessoid_Internalname, "Values", (string)(cmbavSubprocessoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table2_38_782( true) ;
         }
         else
         {
            wb_table2_38_782( false) ;
         }
         return  ;
      }

      protected void wb_table2_38_782e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentousuarioinclusao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentousuarioinclusao_Internalname, "USUÁRIO INCLUSÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentousuarioinclusao_Internalname, AV61DocumentoUsuarioInclusao, StringUtil.RTrim( context.localUtil.Format( AV61DocumentoUsuarioInclusao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentousuarioinclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentousuarioinclusao_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavArearesponsavelid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavArearesponsavelid_Internalname, "ÁREA RESPONSÁVEL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavArearesponsavelid, cmbavArearesponsavelid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18AreaResponsavelId), 8, 0)), 1, cmbavArearesponsavelid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavArearesponsavelid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavArearesponsavelid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18AreaResponsavelId), 8, 0));
            AssignProp(sPrefix, false, cmbavArearesponsavelid_Internalname, "Values", (string)(cmbavArearesponsavelid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table3_54_782( true) ;
         }
         else
         {
            wb_table3_54_782( false) ;
         }
         return  ;
      }

      protected void wb_table3_54_782e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentodatainclusao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentodatainclusao_Internalname, "DATA INCLUSÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDocumentodatainclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDocumentodatainclusao_Internalname, context.localUtil.TToC( AV10DocumentoDataInclusao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV10DocumentoDataInclusao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentodatainclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentodatainclusao_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoWC.htm");
            GxWebStd.gx_bitmap( context, edtavDocumentodatainclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDocumentodatainclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocumentoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocumentocontroladorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocumentocontroladorid_Internalname, "CONTROLADOR", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentocontroladorid, cmbavDocumentocontroladorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV13DocumentoControladorId), 8, 0)), 1, cmbavDocumentocontroladorid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDocumentocontroladorid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavDocumentocontroladorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13DocumentoControladorId), 8, 0));
            AssignProp(sPrefix, false, cmbavDocumentocontroladorid_Internalname, "Values", (string)(cmbavDocumentocontroladorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table4_70_782( true) ;
         }
         else
         {
            wb_table4_70_782( false) ;
         }
         return  ;
      }

      protected void wb_table4_70_782e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentousuarioalteracao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentousuarioalteracao_Internalname, "USUÁRIO ALTERAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentousuarioalteracao_Internalname, AV62DocumentoUsuarioAlteracao, StringUtil.RTrim( context.localUtil.Format( AV62DocumentoUsuarioAlteracao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentousuarioalteracao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentousuarioalteracao_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavPersonaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPersonaid_Internalname, "PERSONA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPersonaid, cmbavPersonaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14PersonaId), 8, 0)), 1, cmbavPersonaid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavPersonaid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavPersonaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14PersonaId), 8, 0));
            AssignProp(sPrefix, false, cmbavPersonaid_Internalname, "Values", (string)(cmbavPersonaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table5_86_782( true) ;
         }
         else
         {
            wb_table5_86_782( false) ;
         }
         return  ;
      }

      protected void wb_table5_86_782e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentodataalteracao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentodataalteracao_Internalname, "DATA ALTERAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDocumentodataalteracao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDocumentodataalteracao_Internalname, context.localUtil.TToC( AV12DocumentoDataAlteracao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV12DocumentoDataAlteracao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentodataalteracao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentodataalteracao_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoWC.htm");
            GxWebStd.gx_bitmap( context, edtavDocumentodataalteracao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDocumentodataalteracao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocumentoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavEncarregadoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEncarregadoid_Internalname, "ENCARREGADO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEncarregadoid, cmbavEncarregadoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15EncarregadoId), 8, 0)), 1, cmbavEncarregadoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavEncarregadoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavEncarregadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15EncarregadoId), 8, 0));
            AssignProp(sPrefix, false, cmbavEncarregadoid_Internalname, "Values", (string)(cmbavEncarregadoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table6_102_782( true) ;
         }
         else
         {
            wb_table6_102_782( false) ;
         }
         return  ;
      }

      protected void wb_table6_102_782e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentonome_Internalname, "NOME DO DOCUMENTO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentonome_Internalname, AV16DocumentoNome, StringUtil.RTrim( context.localUtil.Format( AV16DocumentoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentonome_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtdocumentonome_Internalname, lblTxtdocumentonome_Caption, "", "", lblTxtdocumentonome_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocumentoativo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocumentoativo_Internalname, "ATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentoativo, cmbavDocumentoativo_Internalname, StringUtil.BoolToStr( AV17DocumentoAtivo), 1, cmbavDocumentoativo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocumentoativo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "", true, 0, "HLP_DocumentoWC.htm");
            cmbavDocumentoativo.CurrentValue = StringUtil.BoolToStr( AV17DocumentoAtivo);
            AssignProp(sPrefix, false, cmbavDocumentoativo_Internalname, "Values", (string)(cmbavDocumentoativo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncopiardocumento_Internalname, "", "COPIAR DOCUMENTO", bttBtncopiardocumento_Jsonclick, 5, "COPIAR DOCUMENTO", "", StyleString, ClassString, bttBtncopiardocumento_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCOPIARDOCUMENTO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsalvar_Internalname, "", "SALVAR", bttBtnsalvar_Jsonclick, 5, "SALVAR", "", StyleString, ClassString, bttBtnsalvar_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSALVAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoWC.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
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
         }
         wbLoad = true;
      }

      protected void START782( )
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
               Form.Meta.addItem("description", "Aba inicial para o cadastro de um Documento", 0) ;
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
               STRUP780( ) ;
            }
         }
      }

      protected void WS782( )
      {
         START782( ) ;
         EVT782( ) ;
      }

      protected void EVT782( )
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
                                 STRUP780( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPROCESSOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoProcessoAdd' */
                                    E13782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSUBPROCESSOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSubprocessoAdd' */
                                    E14782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOAREARESPONSAVELADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAreaResponsavelAdd' */
                                    E15782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONTROLADORADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoControladorAdd' */
                                    E16782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPERSONAADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPersonaAdd' */
                                    E17782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENCARREGADOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoEncarregadoAdd' */
                                    E18782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCOPIARDOCUMENTO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCopiarDocumento' */
                                    E19782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSALVAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSalvar' */
                                    E20782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDOCUMENTOPROCESSOID.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSUBPROCESSOID.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E22782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E23782 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                                 STRUP780( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavDocumentoprocessoid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE782( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm782( ) ;
            }
         }
      }

      protected void PA782( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documentowc.aspx")), "documentowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documentowc.aspx")))) ;
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
               GX_FocusControl = cmbavDocumentoprocessoid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         if ( cmbavDocumentoprocessoid.ItemCount > 0 )
         {
            AV7DocumentoProcessoId = (int)(NumberUtil.Val( cmbavDocumentoprocessoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0));
            AssignProp(sPrefix, false, cmbavDocumentoprocessoid_Internalname, "Values", cmbavDocumentoprocessoid.ToJavascriptSource(), true);
         }
         if ( cmbavSubprocessoid.ItemCount > 0 )
         {
            AV9SubprocessoId = (int)(NumberUtil.Val( cmbavSubprocessoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0));
            AssignProp(sPrefix, false, cmbavSubprocessoid_Internalname, "Values", cmbavSubprocessoid.ToJavascriptSource(), true);
         }
         if ( cmbavArearesponsavelid.ItemCount > 0 )
         {
            AV18AreaResponsavelId = (int)(NumberUtil.Val( cmbavArearesponsavelid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18AreaResponsavelId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavArearesponsavelid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18AreaResponsavelId), 8, 0));
            AssignProp(sPrefix, false, cmbavArearesponsavelid_Internalname, "Values", cmbavArearesponsavelid.ToJavascriptSource(), true);
         }
         if ( cmbavDocumentocontroladorid.ItemCount > 0 )
         {
            AV13DocumentoControladorId = (int)(NumberUtil.Val( cmbavDocumentocontroladorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13DocumentoControladorId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentocontroladorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13DocumentoControladorId), 8, 0));
            AssignProp(sPrefix, false, cmbavDocumentocontroladorid_Internalname, "Values", cmbavDocumentocontroladorid.ToJavascriptSource(), true);
         }
         if ( cmbavPersonaid.ItemCount > 0 )
         {
            AV14PersonaId = (int)(NumberUtil.Val( cmbavPersonaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14PersonaId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPersonaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14PersonaId), 8, 0));
            AssignProp(sPrefix, false, cmbavPersonaid_Internalname, "Values", cmbavPersonaid.ToJavascriptSource(), true);
         }
         if ( cmbavEncarregadoid.ItemCount > 0 )
         {
            AV15EncarregadoId = (int)(NumberUtil.Val( cmbavEncarregadoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15EncarregadoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEncarregadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15EncarregadoId), 8, 0));
            AssignProp(sPrefix, false, cmbavEncarregadoid_Internalname, "Values", cmbavEncarregadoid.ToJavascriptSource(), true);
         }
         if ( cmbavDocumentoativo.ItemCount > 0 )
         {
            AV17DocumentoAtivo = StringUtil.StrToBool( cmbavDocumentoativo.getValidValue(StringUtil.BoolToStr( AV17DocumentoAtivo)));
            AssignAttri(sPrefix, false, "AV17DocumentoAtivo", AV17DocumentoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentoativo.CurrentValue = StringUtil.BoolToStr( AV17DocumentoAtivo);
            AssignProp(sPrefix, false, cmbavDocumentoativo_Internalname, "Values", cmbavDocumentoativo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF782( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDocumentoid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Enabled), 5, 0), true);
         edtavDocumentousuarioinclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentousuarioinclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioinclusao_Enabled), 5, 0), true);
         edtavDocumentodatainclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentodatainclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodatainclusao_Enabled), 5, 0), true);
         edtavDocumentousuarioalteracao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentousuarioalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioalteracao_Enabled), 5, 0), true);
         edtavDocumentodataalteracao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentodataalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodataalteracao_Enabled), 5, 0), true);
      }

      protected void RF782( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12782 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E23782 ();
            WB780( ) ;
         }
      }

      protected void send_integrity_lvl_hashes782( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavDocumentoid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Enabled), 5, 0), true);
         edtavDocumentousuarioinclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentousuarioinclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioinclusao_Enabled), 5, 0), true);
         edtavDocumentodatainclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentodatainclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodatainclusao_Enabled), 5, 0), true);
         edtavDocumentousuarioalteracao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentousuarioalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioalteracao_Enabled), 5, 0), true);
         edtavDocumentodataalteracao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocumentodataalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodataalteracao_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP780( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11782 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV8DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8DocumentoId"), ",", "."));
            /* Read variables values. */
            cmbavDocumentoprocessoid.CurrentValue = cgiGet( cmbavDocumentoprocessoid_Internalname);
            AV7DocumentoProcessoId = (int)(NumberUtil.Val( cgiGet( cmbavDocumentoprocessoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
            cmbavSubprocessoid.CurrentValue = cgiGet( cmbavSubprocessoid_Internalname);
            AV9SubprocessoId = (int)(NumberUtil.Val( cgiGet( cmbavSubprocessoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
            AV61DocumentoUsuarioInclusao = cgiGet( edtavDocumentousuarioinclusao_Internalname);
            AssignAttri(sPrefix, false, "AV61DocumentoUsuarioInclusao", AV61DocumentoUsuarioInclusao);
            cmbavArearesponsavelid.CurrentValue = cgiGet( cmbavArearesponsavelid_Internalname);
            AV18AreaResponsavelId = (int)(NumberUtil.Val( cgiGet( cmbavArearesponsavelid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtavDocumentodatainclusao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Documento Data Inclusao"}), 1, "vDOCUMENTODATAINCLUSAO");
               GX_FocusControl = edtavDocumentodatainclusao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV10DocumentoDataInclusao", context.localUtil.TToC( AV10DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV10DocumentoDataInclusao = context.localUtil.CToT( cgiGet( edtavDocumentodatainclusao_Internalname));
               AssignAttri(sPrefix, false, "AV10DocumentoDataInclusao", context.localUtil.TToC( AV10DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            }
            cmbavDocumentocontroladorid.CurrentValue = cgiGet( cmbavDocumentocontroladorid_Internalname);
            AV13DocumentoControladorId = (int)(NumberUtil.Val( cgiGet( cmbavDocumentocontroladorid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
            AV62DocumentoUsuarioAlteracao = cgiGet( edtavDocumentousuarioalteracao_Internalname);
            AssignAttri(sPrefix, false, "AV62DocumentoUsuarioAlteracao", AV62DocumentoUsuarioAlteracao);
            cmbavPersonaid.CurrentValue = cgiGet( cmbavPersonaid_Internalname);
            AV14PersonaId = (int)(NumberUtil.Val( cgiGet( cmbavPersonaid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtavDocumentodataalteracao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Documento Data Alteracao"}), 1, "vDOCUMENTODATAALTERACAO");
               GX_FocusControl = edtavDocumentodataalteracao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV12DocumentoDataAlteracao", context.localUtil.TToC( AV12DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV12DocumentoDataAlteracao = context.localUtil.CToT( cgiGet( edtavDocumentodataalteracao_Internalname));
               AssignAttri(sPrefix, false, "AV12DocumentoDataAlteracao", context.localUtil.TToC( AV12DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            }
            cmbavEncarregadoid.CurrentValue = cgiGet( cmbavEncarregadoid_Internalname);
            AV15EncarregadoId = (int)(NumberUtil.Val( cgiGet( cmbavEncarregadoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
            AV16DocumentoNome = cgiGet( edtavDocumentonome_Internalname);
            AssignAttri(sPrefix, false, "AV16DocumentoNome", AV16DocumentoNome);
            cmbavDocumentoativo.CurrentValue = cgiGet( cmbavDocumentoativo_Internalname);
            AV17DocumentoAtivo = StringUtil.StrToBool( cgiGet( cmbavDocumentoativo_Internalname));
            AssignAttri(sPrefix, false, "AV17DocumentoAtivo", AV17DocumentoAtivo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11782 ();
         if (returnInSub) return;
      }

      protected void E11782( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSOCOMBOCARREGA' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SUBPROCESSOCOMBOCARREGA' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ENCARREGADOCOMBOCARREGA' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CONTROLADORCOMBOCARREGA' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'PERSONACOMBOCARREGA' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'AREARESPONSAVELCOMBOCARREGA' */
         S162 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV20Documento.Load(AV8DocumentoId);
            AV7DocumentoProcessoId = AV20Documento.gxTpr_Documentoprocessoid;
            AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
            /* Execute user subroutine: 'SUBPROCESSOCOMBOCARREGA' */
            S122 ();
            if (returnInSub) return;
            AV9SubprocessoId = AV20Documento.gxTpr_Subprocessoid;
            AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
            AV61DocumentoUsuarioInclusao = AV20Documento.gxTpr_Documentousuarioinclusao;
            AssignAttri(sPrefix, false, "AV61DocumentoUsuarioInclusao", AV61DocumentoUsuarioInclusao);
            AV10DocumentoDataInclusao = AV20Documento.gxTpr_Documentodatainclusao;
            AssignAttri(sPrefix, false, "AV10DocumentoDataInclusao", context.localUtil.TToC( AV10DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            AV62DocumentoUsuarioAlteracao = AV20Documento.gxTpr_Documentousuarioalteracao;
            AssignAttri(sPrefix, false, "AV62DocumentoUsuarioAlteracao", AV62DocumentoUsuarioAlteracao);
            AV12DocumentoDataAlteracao = AV20Documento.gxTpr_Documentodataalteracao;
            AssignAttri(sPrefix, false, "AV12DocumentoDataAlteracao", context.localUtil.TToC( AV12DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            AV14PersonaId = AV20Documento.gxTpr_Personaid;
            AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
            AV15EncarregadoId = AV20Documento.gxTpr_Encarregadoid;
            AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
            AV16DocumentoNome = AV20Documento.gxTpr_Documentonome;
            AssignAttri(sPrefix, false, "AV16DocumentoNome", AV16DocumentoNome);
            AV17DocumentoAtivo = AV20Documento.gxTpr_Documentoativo;
            AssignAttri(sPrefix, false, "AV17DocumentoAtivo", AV17DocumentoAtivo);
            AV13DocumentoControladorId = AV20Documento.gxTpr_Documentocontroladorid;
            AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
            AV18AreaResponsavelId = AV20Documento.gxTpr_Arearesponsavelid;
            AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
            cmbavDocumentoprocessoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavDocumentoprocessoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocumentoprocessoid.Enabled), 5, 0), true);
            cmbavSubprocessoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavSubprocessoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSubprocessoid.Enabled), 5, 0), true);
            edtavDocumentousuarioinclusao_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentousuarioinclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioinclusao_Enabled), 5, 0), true);
            edtavDocumentodatainclusao_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentodatainclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodatainclusao_Enabled), 5, 0), true);
            edtavDocumentousuarioalteracao_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentousuarioalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentousuarioalteracao_Enabled), 5, 0), true);
            edtavDocumentodataalteracao_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentodataalteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentodataalteracao_Enabled), 5, 0), true);
            cmbavPersonaid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavPersonaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPersonaid.Enabled), 5, 0), true);
            cmbavEncarregadoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavEncarregadoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavEncarregadoid.Enabled), 5, 0), true);
            edtavDocumentonome_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentonome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentonome_Enabled), 5, 0), true);
            cmbavDocumentoativo.Enabled = 0;
            AssignProp(sPrefix, false, cmbavDocumentoativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocumentoativo.Enabled), 5, 0), true);
            cmbavDocumentocontroladorid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavDocumentocontroladorid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocumentocontroladorid.Enabled), 5, 0), true);
            cmbavArearesponsavelid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavArearesponsavelid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavArearesponsavelid.Enabled), 5, 0), true);
            bttBtnsalvar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsalvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsalvar_Visible), 5, 0), true);
            bttBtncopiardocumento_Visible = 0;
            AssignProp(sPrefix, false, bttBtncopiardocumento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncopiardocumento_Visible), 5, 0), true);
            lblProcessoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblProcessoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblProcessoinfo_Visible), 5, 0), true);
            lblProcessoadd_Visible = 0;
            AssignProp(sPrefix, false, lblProcessoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblProcessoadd_Visible), 5, 0), true);
            lblSubprocessoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblSubprocessoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSubprocessoinfo_Visible), 5, 0), true);
            lblSubprocessoadd_Visible = 0;
            AssignProp(sPrefix, false, lblSubprocessoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSubprocessoadd_Visible), 5, 0), true);
            lblControladorinfo_Visible = 0;
            AssignProp(sPrefix, false, lblControladorinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblControladorinfo_Visible), 5, 0), true);
            lblControladoradd_Visible = 0;
            AssignProp(sPrefix, false, lblControladoradd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblControladoradd_Visible), 5, 0), true);
            lblPersonainfo_Visible = 0;
            AssignProp(sPrefix, false, lblPersonainfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPersonainfo_Visible), 5, 0), true);
            lblPersonaadd_Visible = 0;
            AssignProp(sPrefix, false, lblPersonaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPersonaadd_Visible), 5, 0), true);
            lblEncarregadoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblEncarregadoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblEncarregadoinfo_Visible), 5, 0), true);
            lblEncarregadoadd_Visible = 0;
            AssignProp(sPrefix, false, lblEncarregadoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblEncarregadoadd_Visible), 5, 0), true);
            lblArearesponsaveladd_Visible = 0;
            AssignProp(sPrefix, false, lblArearesponsaveladd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblArearesponsaveladd_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV20Documento.Load(AV8DocumentoId);
            AV7DocumentoProcessoId = AV20Documento.gxTpr_Documentoprocessoid;
            AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
            /* Execute user subroutine: 'SUBPROCESSOCOMBOCARREGA' */
            S122 ();
            if (returnInSub) return;
            AV9SubprocessoId = AV20Documento.gxTpr_Subprocessoid;
            AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
            AV61DocumentoUsuarioInclusao = AV20Documento.gxTpr_Documentousuarioinclusao;
            AssignAttri(sPrefix, false, "AV61DocumentoUsuarioInclusao", AV61DocumentoUsuarioInclusao);
            AV10DocumentoDataInclusao = AV20Documento.gxTpr_Documentodatainclusao;
            AssignAttri(sPrefix, false, "AV10DocumentoDataInclusao", context.localUtil.TToC( AV10DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            AV62DocumentoUsuarioAlteracao = AV20Documento.gxTpr_Documentousuarioalteracao;
            AssignAttri(sPrefix, false, "AV62DocumentoUsuarioAlteracao", AV62DocumentoUsuarioAlteracao);
            AV12DocumentoDataAlteracao = AV20Documento.gxTpr_Documentodataalteracao;
            AssignAttri(sPrefix, false, "AV12DocumentoDataAlteracao", context.localUtil.TToC( AV12DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            AV14PersonaId = AV20Documento.gxTpr_Personaid;
            AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
            AV15EncarregadoId = AV20Documento.gxTpr_Encarregadoid;
            AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
            AV16DocumentoNome = AV20Documento.gxTpr_Documentonome;
            AssignAttri(sPrefix, false, "AV16DocumentoNome", AV16DocumentoNome);
            AV17DocumentoAtivo = AV20Documento.gxTpr_Documentoativo;
            AssignAttri(sPrefix, false, "AV17DocumentoAtivo", AV17DocumentoAtivo);
            AV13DocumentoControladorId = AV20Documento.gxTpr_Documentocontroladorid;
            AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
            AV18AreaResponsavelId = AV20Documento.gxTpr_Arearesponsavelid;
            AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
            bttBtncopiardocumento_Visible = 0;
            AssignProp(sPrefix, false, bttBtncopiardocumento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncopiardocumento_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV17DocumentoAtivo = true;
            AssignAttri(sPrefix, false, "AV17DocumentoAtivo", AV17DocumentoAtivo);
            bttBtncopiardocumento_Visible = 1;
            AssignProp(sPrefix, false, bttBtncopiardocumento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncopiardocumento_Visible), 5, 0), true);
         }
         /* Using cursor H00782 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135CampoId = H00782_A135CampoId[0];
            A139TooltipTelaId = H00782_A139TooltipTelaId[0];
            A140TooltipTelaNome = H00782_A140TooltipTelaNome[0];
            A118TooltipAtivo = H00782_A118TooltipAtivo[0];
            A136CampoNome = H00782_A136CampoNome[0];
            A115TooltipDescricao = H00782_A115TooltipDescricao[0];
            A136CampoNome = H00782_A136CampoNome[0];
            A140TooltipTelaNome = H00782_A140TooltipTelaNome[0];
            if ( StringUtil.StrCmp(A136CampoNome, "PROCESSO") == 0 )
            {
               lblProcessoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblProcessoinfo_Internalname, "Tooltiptext", lblProcessoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "SUB-PROCESSO") == 0 )
            {
               lblSubprocessoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblSubprocessoinfo_Internalname, "Tooltiptext", lblSubprocessoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "CONTROLADOR") == 0 )
            {
               lblControladorinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblControladorinfo_Internalname, "Tooltiptext", lblControladorinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "PERSONA") == 0 )
            {
               lblPersonainfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblPersonainfo_Internalname, "Tooltiptext", lblPersonainfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "ENCARREGADO") == 0 )
            {
               lblEncarregadoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblEncarregadoinfo_Internalname, "Tooltiptext", lblEncarregadoinfo_Tooltiptext, true);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         lblTxtdocumentonome_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV16DocumentoNome)), 10, 0))+"/100";
         AssignProp(sPrefix, false, lblTxtdocumentonome_Internalname, "Caption", lblTxtdocumentonome_Caption, true);
      }

      protected void E12782( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! (0==AV51DocumentoId_Copia) || ! ( AV51DocumentoId_Copia == 0 ) )
         {
            new documentocopiaregistros(context ).execute(  AV51DocumentoId_Copia,  AV53DocumentoNome_Copia, out  AV52DocumentoId_Copiado) ;
         }
         if ( AV29IsProcesso )
         {
            /* Execute user subroutine: 'PROCESSOCOMBOCARREGA' */
            S112 ();
            if (returnInSub) return;
            AV7DocumentoProcessoId = AV30ProcessoId_Out;
            AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
            AV29IsProcesso = false;
            AssignAttri(sPrefix, false, "AV29IsProcesso", AV29IsProcesso);
         }
         if ( AV31IsSubProcesso )
         {
            /* Execute user subroutine: 'SUBPROCESSOCOMBOCARREGA' */
            S122 ();
            if (returnInSub) return;
            AV9SubprocessoId = AV32SubProcessoId_Out;
            AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
            AV31IsSubProcesso = false;
            AssignAttri(sPrefix, false, "AV31IsSubProcesso", AV31IsSubProcesso);
         }
         if ( AV37IsPersona )
         {
            /* Execute user subroutine: 'PERSONACOMBOCARREGA' */
            S152 ();
            if (returnInSub) return;
            AV14PersonaId = AV38PersonaId_Out;
            AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
            AV37IsPersona = false;
            AssignAttri(sPrefix, false, "AV37IsPersona", AV37IsPersona);
         }
         if ( AV39IsEncarregado )
         {
            /* Execute user subroutine: 'ENCARREGADOCOMBOCARREGA' */
            S132 ();
            if (returnInSub) return;
            AV15EncarregadoId = AV40EncarregadoId_Out;
            AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
            AV39IsEncarregado = false;
            AssignAttri(sPrefix, false, "AV39IsEncarregado", AV39IsEncarregado);
         }
         if ( AV57IsAreaResponsavel )
         {
            /* Execute user subroutine: 'AREARESPONSAVELCOMBOCARREGA' */
            S162 ();
            if (returnInSub) return;
            AV18AreaResponsavelId = AV43AreaResponsavelId_Out;
            AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
            AV57IsAreaResponsavel = false;
            AssignAttri(sPrefix, false, "AV57IsAreaResponsavel", AV57IsAreaResponsavel);
         }
         if ( AV34IsControlador )
         {
            /* Execute user subroutine: 'CONTROLADORCOMBOCARREGA' */
            S142 ();
            if (returnInSub) return;
            AV13DocumentoControladorId = AV35ControladorId_Out;
            AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
            AV34IsControlador = false;
            AssignAttri(sPrefix, false, "AV34IsControlador", AV34IsControlador);
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0));
         AssignProp(sPrefix, false, cmbavDocumentoprocessoid_Internalname, "Values", cmbavDocumentoprocessoid.ToJavascriptSource(), true);
         cmbavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0));
         AssignProp(sPrefix, false, cmbavSubprocessoid_Internalname, "Values", cmbavSubprocessoid.ToJavascriptSource(), true);
         cmbavPersonaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14PersonaId), 8, 0));
         AssignProp(sPrefix, false, cmbavPersonaid_Internalname, "Values", cmbavPersonaid.ToJavascriptSource(), true);
         cmbavEncarregadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15EncarregadoId), 8, 0));
         AssignProp(sPrefix, false, cmbavEncarregadoid_Internalname, "Values", cmbavEncarregadoid.ToJavascriptSource(), true);
         cmbavArearesponsavelid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18AreaResponsavelId), 8, 0));
         AssignProp(sPrefix, false, cmbavArearesponsavelid_Internalname, "Values", cmbavArearesponsavelid.ToJavascriptSource(), true);
         cmbavDocumentocontroladorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13DocumentoControladorId), 8, 0));
         AssignProp(sPrefix, false, cmbavDocumentocontroladorid_Internalname, "Values", cmbavDocumentocontroladorid.ToJavascriptSource(), true);
      }

      protected void E13782( )
      {
         /* 'DoProcessoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "processo.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("processo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV29IsProcesso","AV30ProcessoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E14782( )
      {
         /* 'DoSubprocessoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "subprocesso.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("subprocesso.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV31IsSubProcesso","AV32SubProcessoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E15782( )
      {
         /* 'DoAreaResponsavelAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "arearesponsavel.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("arearesponsavel.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV57IsAreaResponsavel","AV43AreaResponsavelId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E16782( )
      {
         /* 'DoControladorAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "controlador.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("controlador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV34IsControlador","AV35ControladorId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E17782( )
      {
         /* 'DoPersonaAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "persona.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("persona.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV37IsPersona","AV38PersonaId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E18782( )
      {
         /* 'DoEncarregadoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "encarregado.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("encarregado.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV39IsEncarregado","AV40EncarregadoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E19782( )
      {
         /* 'DoCopiarDocumento' Routine */
         returnInSub = false;
         context.PopUp(formatLink("documentoprompt.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"InOutDocumentoId","OutDocumentoId","DocumentoNome"}) , new Object[] {"","AV51DocumentoId_Copia","AV53DocumentoNome_Copia"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E20782( )
      {
         /* 'DoSalvar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S182 ();
         if (returnInSub) return;
         if ( AV27CheckRequiredFieldsResult )
         {
            new validanomedocumento(context ).execute(  AV16DocumentoNome,  AV8DocumentoId,  Gx_mode, out  AV54Existe) ;
            if ( AV54Existe )
            {
               GX_msglist.addItem("Já existe um documento com esse nome registrado!");
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV20Documento = new SdtDocumento(context);
                  AV20Documento.gxTpr_Documentoprocessoid = AV7DocumentoProcessoId;
                  AV20Documento.gxTpr_Subprocessoid = AV9SubprocessoId;
                  AV20Documento.gxTpr_Documentodatainclusao = AV10DocumentoDataInclusao;
                  AV20Documento.gxTpr_Documentodataalteracao = AV12DocumentoDataAlteracao;
                  AV20Documento.gxTpr_Personaid = AV14PersonaId;
                  AV20Documento.gxTpr_Encarregadoid = AV15EncarregadoId;
                  AV20Documento.gxTpr_Documentonome = StringUtil.Trim( StringUtil.Upper( AV16DocumentoNome));
                  AV20Documento.gxTpr_Documentoativo = AV17DocumentoAtivo;
                  AV20Documento.gxTpr_Documentocontroladorid = AV13DocumentoControladorId;
                  AV20Documento.gxTpr_Arearesponsavelid = AV18AreaResponsavelId;
                  AV20Documento.gxTv_SdtDocumento_Abrangenciageograficaid_SetNull();
                  AV20Documento.gxTv_SdtDocumento_Categoriaid_SetNull();
                  AV20Documento.gxTv_SdtDocumento_Ferramentacoletaid_SetNull();
                  AV20Documento.gxTv_SdtDocumento_Frequenciatratamentoid_SetNull();
                  AV20Documento.gxTv_SdtDocumento_Temporetencaoid_SetNull();
                  AV20Documento.gxTv_SdtDocumento_Tipodadoid_SetNull();
                  AV20Documento.gxTv_SdtDocumento_Tipodescarteid_SetNull();
                  AV20Documento.Insert();
                  AV8DocumentoId = AV20Documento.gxTpr_Documentoid;
                  AssignAttri(sPrefix, false, "AV8DocumentoId", StringUtil.LTrimStr( (decimal)(AV8DocumentoId), 8, 0));
                  if ( AV20Documento.Success() )
                  {
                     context.CommitDataStores("documentowc",pr_default);
                     GXKey = Crypto.GetSiteKey( );
                     GXEncryptionTmp = "documentocadastrowp.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(AV8DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(true));
                     CallWebObject(formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     AV69GXV2 = 1;
                     AV68GXV1 = AV20Documento.GetMessages();
                     while ( AV69GXV2 <= AV68GXV1.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV68GXV1.Item(AV69GXV2));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV69GXV2 = (int)(AV69GXV2+1);
                     }
                  }
               }
               else
               {
                  AV20Documento.gxTpr_Documentoprocessoid = AV7DocumentoProcessoId;
                  AV20Documento.gxTpr_Subprocessoid = AV9SubprocessoId;
                  AV20Documento.gxTpr_Documentodatainclusao = AV10DocumentoDataInclusao;
                  AV20Documento.gxTpr_Documentodataalteracao = AV12DocumentoDataAlteracao;
                  AV20Documento.gxTpr_Personaid = AV14PersonaId;
                  AV20Documento.gxTpr_Encarregadoid = AV15EncarregadoId;
                  AV20Documento.gxTpr_Documentonome = StringUtil.Trim( StringUtil.Upper( AV16DocumentoNome));
                  AV20Documento.gxTpr_Documentoativo = AV17DocumentoAtivo;
                  AV20Documento.gxTpr_Documentocontroladorid = AV13DocumentoControladorId;
                  AV20Documento.gxTpr_Arearesponsavelid = AV18AreaResponsavelId;
                  AV20Documento.Update();
                  AV62DocumentoUsuarioAlteracao = AV20Documento.gxTpr_Documentousuarioalteracao;
                  AssignAttri(sPrefix, false, "AV62DocumentoUsuarioAlteracao", AV62DocumentoUsuarioAlteracao);
                  AV12DocumentoDataAlteracao = AV20Documento.gxTpr_Documentodataalteracao;
                  AssignAttri(sPrefix, false, "AV12DocumentoDataAlteracao", context.localUtil.TToC( AV12DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
                  if ( AV20Documento.Success() )
                  {
                     context.CommitDataStores("documentowc",pr_default);
                     GX_msglist.addItem("Alterado com Sucesso!");
                  }
                  else
                  {
                     AV71GXV4 = 1;
                     AV70GXV3 = AV20Documento.GetMessages();
                     while ( AV71GXV4 <= AV70GXV3.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV70GXV3.Item(AV71GXV4));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV71GXV4 = (int)(AV71GXV4+1);
                     }
                  }
               }
            }
         }
         else
         {
            GX_msglist.addItem("Revise os campos obrigatórios");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20Documento", AV20Documento);
      }

      protected void S172( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV44IsAuthorized_ProcessoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoProcessoAdd", out  GXt_boolean1) ;
         AV44IsAuthorized_ProcessoAdd = GXt_boolean1;
         if ( ! ( AV44IsAuthorized_ProcessoAdd ) )
         {
            lblProcessoadd_Visible = 0;
            AssignProp(sPrefix, false, lblProcessoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblProcessoadd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV45IsAuthorized_SubprocessoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoSubProcessoAdd", out  GXt_boolean1) ;
         AV45IsAuthorized_SubprocessoAdd = GXt_boolean1;
         if ( ! ( AV45IsAuthorized_SubprocessoAdd ) )
         {
            lblSubprocessoadd_Visible = 0;
            AssignProp(sPrefix, false, lblSubprocessoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSubprocessoadd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV56IsAuthorized_AreaResponsavelAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoAreaResponsavelAdd", out  GXt_boolean1) ;
         AV56IsAuthorized_AreaResponsavelAdd = GXt_boolean1;
         if ( ! ( AV56IsAuthorized_AreaResponsavelAdd ) )
         {
            lblArearesponsaveladd_Visible = 0;
            AssignProp(sPrefix, false, lblArearesponsaveladd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblArearesponsaveladd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV46IsAuthorized_ControladorAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoControladorAdd", out  GXt_boolean1) ;
         AV46IsAuthorized_ControladorAdd = GXt_boolean1;
         if ( ! ( AV46IsAuthorized_ControladorAdd ) )
         {
            lblControladoradd_Visible = 0;
            AssignProp(sPrefix, false, lblControladoradd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblControladoradd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV47IsAuthorized_PersonaAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoPersonaAdd", out  GXt_boolean1) ;
         AV47IsAuthorized_PersonaAdd = GXt_boolean1;
         if ( ! ( AV47IsAuthorized_PersonaAdd ) )
         {
            lblPersonaadd_Visible = 0;
            AssignProp(sPrefix, false, lblPersonaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPersonaadd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV48IsAuthorized_EncarregadoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoEncarregadoAdd", out  GXt_boolean1) ;
         AV48IsAuthorized_EncarregadoAdd = GXt_boolean1;
         if ( ! ( AV48IsAuthorized_EncarregadoAdd ) )
         {
            lblEncarregadoadd_Visible = 0;
            AssignProp(sPrefix, false, lblEncarregadoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblEncarregadoadd_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV49IsAuthorized_Salvar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDocumentoSalva", out  GXt_boolean1) ;
         AV49IsAuthorized_Salvar = GXt_boolean1;
         if ( ! ( AV49IsAuthorized_Salvar ) )
         {
            bttBtnsalvar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsalvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsalvar_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV27CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         if ( (0==AV7DocumentoProcessoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavDocumentoprocessoid_Internalname,  "true",  ""));
            AV27CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         }
         if ( (0==AV9SubprocessoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavSubprocessoid_Internalname,  "true",  ""));
            AV27CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         }
         if ( (0==AV13DocumentoControladorId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavDocumentocontroladorid_Internalname,  "true",  ""));
            AV27CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         }
         if ( (0==AV14PersonaId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavPersonaid_Internalname,  "true",  ""));
            AV27CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         }
         if ( (0==AV15EncarregadoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavEncarregadoid_Internalname,  "true",  ""));
            AV27CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16DocumentoNome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  edtavDocumentonome_Internalname,  "true",  ""));
            AV27CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV27CheckRequiredFieldsResult", AV27CheckRequiredFieldsResult);
         }
      }

      protected void E21782( )
      {
         /* Documentoprocessoid_Controlvaluechanged Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Origem)) )
         {
            AV60Origem = "Processo";
            AssignAttri(sPrefix, false, "AV60Origem", AV60Origem);
         }
         if ( StringUtil.StrCmp(AV60Origem, "Processo") == 0 )
         {
            if ( (0==AV7DocumentoProcessoId) || ( AV7DocumentoProcessoId == 0 ) )
            {
               AV60Origem = "";
               AssignAttri(sPrefix, false, "AV60Origem", AV60Origem);
               /* Execute user subroutine: 'PROCESSOCOMBOCARREGA' */
               S112 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'SUBPROCESSOCOMBOCARREGA' */
               S122 ();
               if (returnInSub) return;
            }
            else
            {
               cmbavSubprocessoid.removeAllItems();
               AV55Count = 0;
               /* Using cursor H00783 */
               pr_default.execute(1, new Object[] {AV7DocumentoProcessoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A16ProcessoId = H00783_A16ProcessoId[0];
                  n16ProcessoId = H00783_n16ProcessoId[0];
                  A23SubprocessoAtivo = H00783_A23SubprocessoAtivo[0];
                  A21SubprocessoNome = H00783_A21SubprocessoNome[0];
                  AV55Count = (short)(AV55Count+1);
                  if ( AV55Count > 2 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( AV55Count >= 2 )
               {
                  cmbavSubprocessoid.addItem("0", "(SELECIONE)", 0);
               }
               /* Using cursor H00784 */
               pr_default.execute(2, new Object[] {AV7DocumentoProcessoId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A16ProcessoId = H00784_A16ProcessoId[0];
                  n16ProcessoId = H00784_n16ProcessoId[0];
                  A23SubprocessoAtivo = H00784_A23SubprocessoAtivo[0];
                  A20SubprocessoId = H00784_A20SubprocessoId[0];
                  A21SubprocessoNome = H00784_A21SubprocessoNome[0];
                  cmbavSubprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0)), A21SubprocessoNome, 0);
                  if ( AV55Count == 1 )
                  {
                     AV9SubprocessoId = A20SubprocessoId;
                     AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( AV55Count >= 2 )
               {
                  AV9SubprocessoId = 0;
                  AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0));
         AssignProp(sPrefix, false, cmbavSubprocessoid_Internalname, "Values", cmbavSubprocessoid.ToJavascriptSource(), true);
         cmbavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0));
         AssignProp(sPrefix, false, cmbavDocumentoprocessoid_Internalname, "Values", cmbavDocumentoprocessoid.ToJavascriptSource(), true);
      }

      protected void E22782( )
      {
         /* Subprocessoid_Controlvaluechanged Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Origem)) )
         {
            AV60Origem = "SubProcesso";
            AssignAttri(sPrefix, false, "AV60Origem", AV60Origem);
         }
         if ( StringUtil.StrCmp(AV60Origem, "SubProcesso") == 0 )
         {
            if ( (0==AV9SubprocessoId) || ( AV9SubprocessoId == 0 ) )
            {
               AV60Origem = "";
               AssignAttri(sPrefix, false, "AV60Origem", AV60Origem);
               /* Execute user subroutine: 'PROCESSOCOMBOCARREGA' */
               S112 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'SUBPROCESSOCOMBOCARREGA' */
               S122 ();
               if (returnInSub) return;
            }
            else
            {
               cmbavDocumentoprocessoid.removeAllItems();
               AV55Count = 0;
               /* Using cursor H00785 */
               pr_default.execute(3, new Object[] {AV9SubprocessoId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A20SubprocessoId = H00785_A20SubprocessoId[0];
                  A23SubprocessoAtivo = H00785_A23SubprocessoAtivo[0];
                  A16ProcessoId = H00785_A16ProcessoId[0];
                  n16ProcessoId = H00785_n16ProcessoId[0];
                  A17ProcessoNome = H00785_A17ProcessoNome[0];
                  A17ProcessoNome = H00785_A17ProcessoNome[0];
                  AV58ProcessoId = A16ProcessoId;
                  if ( H00785_n16ProcessoId[0] )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  else
                  {
                     cmbavDocumentoprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0)), A17ProcessoNome, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(3);
               if ( (0==AV58ProcessoId) )
               {
                  /* Using cursor H00786 */
                  pr_default.execute(4);
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A16ProcessoId = H00786_A16ProcessoId[0];
                     n16ProcessoId = H00786_n16ProcessoId[0];
                     A23SubprocessoAtivo = H00786_A23SubprocessoAtivo[0];
                     AV63ProcessoId_Col.Add(A16ProcessoId, 0);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  pr_default.dynParam(5, new Object[]{ new Object[]{
                                                       A16ProcessoId ,
                                                       AV63ProcessoId_Col ,
                                                       A19ProcessoAtivo } ,
                                                       new int[]{
                                                       TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                       }
                  });
                  /* Using cursor H00787 */
                  pr_default.execute(5);
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A16ProcessoId = H00787_A16ProcessoId[0];
                     n16ProcessoId = H00787_n16ProcessoId[0];
                     A19ProcessoAtivo = H00787_A19ProcessoAtivo[0];
                     A17ProcessoNome = H00787_A17ProcessoNome[0];
                     AV55Count = (short)(AV55Count+1);
                     if ( AV55Count > 2 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
                  if ( AV55Count >= 2 )
                  {
                     cmbavDocumentoprocessoid.addItem("0", "(SELECIONE)", 0);
                  }
                  pr_default.dynParam(6, new Object[]{ new Object[]{
                                                       A16ProcessoId ,
                                                       AV63ProcessoId_Col ,
                                                       A19ProcessoAtivo } ,
                                                       new int[]{
                                                       TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                       }
                  });
                  /* Using cursor H00788 */
                  pr_default.execute(6);
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A16ProcessoId = H00788_A16ProcessoId[0];
                     n16ProcessoId = H00788_n16ProcessoId[0];
                     A19ProcessoAtivo = H00788_A19ProcessoAtivo[0];
                     A17ProcessoNome = H00788_A17ProcessoNome[0];
                     cmbavDocumentoprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0)), A17ProcessoNome, 0);
                     if ( AV55Count == 1 )
                     {
                        AV7DocumentoProcessoId = A16ProcessoId;
                        AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
                     }
                     pr_default.readNext(6);
                  }
                  pr_default.close(6);
                  if ( AV55Count >= 2 )
                  {
                     AV7DocumentoProcessoId = 0;
                     AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7DocumentoProcessoId), 8, 0));
         AssignProp(sPrefix, false, cmbavDocumentoprocessoid_Internalname, "Values", cmbavDocumentoprocessoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV63ProcessoId_Col", AV63ProcessoId_Col);
         cmbavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9SubprocessoId), 8, 0));
         AssignProp(sPrefix, false, cmbavSubprocessoid_Internalname, "Values", cmbavSubprocessoid.ToJavascriptSource(), true);
      }

      protected void S142( )
      {
         /* 'CONTROLADORCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavDocumentocontroladorid.removeAllItems();
         AV55Count = 0;
         /* Using cursor H00789 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            A12ControladorAtivo = H00789_A12ControladorAtivo[0];
            A11ControladorNome = H00789_A11ControladorNome[0];
            AV55Count = (short)(AV55Count+1);
            if ( AV55Count > 2 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
         if ( AV55Count >= 2 )
         {
            cmbavDocumentocontroladorid.addItem("0", "(SELECIONE)", 0);
         }
         /* Using cursor H007810 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A12ControladorAtivo = H007810_A12ControladorAtivo[0];
            A10ControladorId = H007810_A10ControladorId[0];
            A11ControladorNome = H007810_A11ControladorNome[0];
            cmbavDocumentocontroladorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A10ControladorId), 8, 0)), A11ControladorNome, 0);
            if ( AV55Count == 1 )
            {
               AV13DocumentoControladorId = A10ControladorId;
               AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
            }
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( AV55Count >= 2 )
         {
            AV13DocumentoControladorId = 0;
            AssignAttri(sPrefix, false, "AV13DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV13DocumentoControladorId), 8, 0));
         }
      }

      protected void S112( )
      {
         /* 'PROCESSOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavDocumentoprocessoid.removeAllItems();
         AV55Count = 0;
         /* Using cursor H007811 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A19ProcessoAtivo = H007811_A19ProcessoAtivo[0];
            A17ProcessoNome = H007811_A17ProcessoNome[0];
            AV55Count = (short)(AV55Count+1);
            if ( AV55Count > 2 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
         if ( AV55Count >= 2 )
         {
            cmbavDocumentoprocessoid.addItem("0", "(SELECIONE)", 0);
         }
         /* Using cursor H007812 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            A19ProcessoAtivo = H007812_A19ProcessoAtivo[0];
            A16ProcessoId = H007812_A16ProcessoId[0];
            n16ProcessoId = H007812_n16ProcessoId[0];
            A17ProcessoNome = H007812_A17ProcessoNome[0];
            cmbavDocumentoprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A16ProcessoId), 8, 0)), A17ProcessoNome, 0);
            if ( AV55Count == 1 )
            {
               AV7DocumentoProcessoId = A16ProcessoId;
               AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
         if ( AV55Count >= 2 )
         {
            AV7DocumentoProcessoId = 0;
            AssignAttri(sPrefix, false, "AV7DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoProcessoId), 8, 0));
         }
      }

      protected void S122( )
      {
         /* 'SUBPROCESSOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavSubprocessoid.removeAllItems();
         AV55Count = 0;
         /* Using cursor H007813 */
         pr_default.execute(11);
         while ( (pr_default.getStatus(11) != 101) )
         {
            A23SubprocessoAtivo = H007813_A23SubprocessoAtivo[0];
            A21SubprocessoNome = H007813_A21SubprocessoNome[0];
            AV55Count = (short)(AV55Count+1);
            if ( AV55Count > 2 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(11);
         }
         pr_default.close(11);
         if ( AV55Count >= 2 )
         {
            cmbavSubprocessoid.addItem("0", "(SELECIONE)", 0);
         }
         /* Using cursor H007814 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            A23SubprocessoAtivo = H007814_A23SubprocessoAtivo[0];
            A20SubprocessoId = H007814_A20SubprocessoId[0];
            A21SubprocessoNome = H007814_A21SubprocessoNome[0];
            cmbavSubprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0)), A21SubprocessoNome, 0);
            if ( AV55Count == 1 )
            {
               AV9SubprocessoId = A20SubprocessoId;
               AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
            }
            pr_default.readNext(12);
         }
         pr_default.close(12);
         if ( AV55Count >= 2 )
         {
            AV9SubprocessoId = 0;
            AssignAttri(sPrefix, false, "AV9SubprocessoId", StringUtil.LTrimStr( (decimal)(AV9SubprocessoId), 8, 0));
         }
      }

      protected void S152( )
      {
         /* 'PERSONACOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavPersonaid.removeAllItems();
         AV55Count = 0;
         /* Using cursor H007815 */
         pr_default.execute(13);
         while ( (pr_default.getStatus(13) != 101) )
         {
            A15PersonaAtivo = H007815_A15PersonaAtivo[0];
            A14PersonaNome = H007815_A14PersonaNome[0];
            AV55Count = (short)(AV55Count+1);
            if ( AV55Count > 2 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(13);
         }
         pr_default.close(13);
         if ( AV55Count >= 2 )
         {
            cmbavPersonaid.addItem("0", "(SELECIONE)", 0);
         }
         /* Using cursor H007816 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            A15PersonaAtivo = H007816_A15PersonaAtivo[0];
            A13PersonaId = H007816_A13PersonaId[0];
            A14PersonaNome = H007816_A14PersonaNome[0];
            cmbavPersonaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0)), A14PersonaNome, 0);
            if ( AV55Count == 1 )
            {
               AV14PersonaId = A13PersonaId;
               AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
            }
            pr_default.readNext(14);
         }
         pr_default.close(14);
         if ( AV55Count >= 2 )
         {
            AV14PersonaId = 0;
            AssignAttri(sPrefix, false, "AV14PersonaId", StringUtil.LTrimStr( (decimal)(AV14PersonaId), 8, 0));
         }
      }

      protected void S132( )
      {
         /* 'ENCARREGADOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavEncarregadoid.removeAllItems();
         AV55Count = 0;
         /* Using cursor H007817 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            A9EncarregadoAtivo = H007817_A9EncarregadoAtivo[0];
            A8EncarregadoNome = H007817_A8EncarregadoNome[0];
            AV55Count = (short)(AV55Count+1);
            if ( AV55Count > 2 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(15);
         }
         pr_default.close(15);
         if ( AV55Count >= 2 )
         {
            cmbavEncarregadoid.addItem("0", "(SELECIONE)", 0);
         }
         /* Using cursor H007818 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            A9EncarregadoAtivo = H007818_A9EncarregadoAtivo[0];
            A7EncarregadoId = H007818_A7EncarregadoId[0];
            A8EncarregadoNome = H007818_A8EncarregadoNome[0];
            cmbavEncarregadoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0)), A8EncarregadoNome, 0);
            if ( AV55Count == 1 )
            {
               AV15EncarregadoId = A7EncarregadoId;
               AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
            }
            pr_default.readNext(16);
         }
         pr_default.close(16);
         if ( AV55Count >= 2 )
         {
            AV15EncarregadoId = 0;
            AssignAttri(sPrefix, false, "AV15EncarregadoId", StringUtil.LTrimStr( (decimal)(AV15EncarregadoId), 8, 0));
         }
      }

      protected void S162( )
      {
         /* 'AREARESPONSAVELCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavArearesponsavelid.removeAllItems();
         AV55Count = 0;
         /* Using cursor H007819 */
         pr_default.execute(17);
         while ( (pr_default.getStatus(17) != 101) )
         {
            A26AreaResponsavelAtivo = H007819_A26AreaResponsavelAtivo[0];
            A25AreaResponsavelNome = H007819_A25AreaResponsavelNome[0];
            AV55Count = (short)(AV55Count+1);
            if ( AV55Count > 2 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(17);
         }
         pr_default.close(17);
         if ( AV55Count >= 2 )
         {
            cmbavArearesponsavelid.addItem("0", "(SELECIONE)", 0);
         }
         /* Using cursor H007820 */
         pr_default.execute(18);
         while ( (pr_default.getStatus(18) != 101) )
         {
            A26AreaResponsavelAtivo = H007820_A26AreaResponsavelAtivo[0];
            A24AreaResponsavelId = H007820_A24AreaResponsavelId[0];
            A25AreaResponsavelNome = H007820_A25AreaResponsavelNome[0];
            cmbavArearesponsavelid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A24AreaResponsavelId), 8, 0)), A25AreaResponsavelNome, 0);
            if ( AV55Count == 1 )
            {
               AV18AreaResponsavelId = A24AreaResponsavelId;
               AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
            }
            pr_default.readNext(18);
         }
         pr_default.close(18);
         if ( AV55Count >= 2 )
         {
            AV18AreaResponsavelId = 0;
            AssignAttri(sPrefix, false, "AV18AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV18AreaResponsavelId), 8, 0));
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E23782( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table6_102_782( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedencarregadoinfo_Internalname, tblTablemergedencarregadoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEncarregadoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblEncarregadoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e24781_client"+"'", "", "TextBlock", 7, lblEncarregadoinfo_Tooltiptext, lblEncarregadoinfo_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEncarregadoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblEncarregadoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOENCARREGADOADD\\'."+"'", "", "TextBlock", 5, "", lblEncarregadoadd_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_102_782e( true) ;
         }
         else
         {
            wb_table6_102_782e( false) ;
         }
      }

      protected void wb_table5_86_782( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedpersonainfo_Internalname, tblTablemergedpersonainfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPersonainfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblPersonainfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e25781_client"+"'", "", "TextBlock", 7, lblPersonainfo_Tooltiptext, lblPersonainfo_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPersonaadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblPersonaadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPERSONAADD\\'."+"'", "", "TextBlock", 5, "", lblPersonaadd_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_86_782e( true) ;
         }
         else
         {
            wb_table5_86_782e( false) ;
         }
      }

      protected void wb_table4_70_782( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcontroladorinfo_Internalname, tblTablemergedcontroladorinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblControladorinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblControladorinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e26781_client"+"'", "", "TextBlock", 7, lblControladorinfo_Tooltiptext, lblControladorinfo_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblControladoradd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblControladoradd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCONTROLADORADD\\'."+"'", "", "TextBlock", 5, "", lblControladoradd_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_70_782e( true) ;
         }
         else
         {
            wb_table4_70_782e( false) ;
         }
      }

      protected void wb_table3_54_782( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedarearesponsavelinfo_Internalname, tblTablemergedarearesponsavelinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblArearesponsavelinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblArearesponsavelinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e27781_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblArearesponsaveladd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblArearesponsaveladd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOAREARESPONSAVELADD\\'."+"'", "", "TextBlock", 5, "", lblArearesponsaveladd_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_54_782e( true) ;
         }
         else
         {
            wb_table3_54_782e( false) ;
         }
      }

      protected void wb_table2_38_782( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsubprocessoinfo_Internalname, tblTablemergedsubprocessoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSubprocessoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblSubprocessoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e28781_client"+"'", "", "TextBlock", 7, lblSubprocessoinfo_Tooltiptext, lblSubprocessoinfo_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSubprocessoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblSubprocessoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSUBPROCESSOADD\\'."+"'", "", "TextBlock", 5, "", lblSubprocessoadd_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_38_782e( true) ;
         }
         else
         {
            wb_table2_38_782e( false) ;
         }
      }

      protected void wb_table1_22_782( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedprocessoinfo_Internalname, tblTablemergedprocessoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProcessoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblProcessoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e29781_client"+"'", "", "TextBlock", 7, lblProcessoinfo_Tooltiptext, lblProcessoinfo_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProcessoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblProcessoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPROCESSOADD\\'."+"'", "", "TextBlock", 5, "", lblProcessoadd_Visible, 1, 0, 1, "HLP_DocumentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_782e( true) ;
         }
         else
         {
            wb_table1_22_782e( false) ;
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
         PA782( ) ;
         WS782( ) ;
         WE782( ) ;
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
         PA782( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "documentowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA782( ) ;
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
         PA782( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS782( ) ;
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
         WS782( ) ;
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
         WE782( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417265949", true, true);
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
         context.AddJavascriptSource("documentowc.js", "?202312417265949", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDocumentoprocessoid.Name = "vDOCUMENTOPROCESSOID";
         cmbavDocumentoprocessoid.WebTags = "";
         if ( cmbavDocumentoprocessoid.ItemCount > 0 )
         {
         }
         cmbavSubprocessoid.Name = "vSUBPROCESSOID";
         cmbavSubprocessoid.WebTags = "";
         if ( cmbavSubprocessoid.ItemCount > 0 )
         {
         }
         cmbavArearesponsavelid.Name = "vAREARESPONSAVELID";
         cmbavArearesponsavelid.WebTags = "";
         if ( cmbavArearesponsavelid.ItemCount > 0 )
         {
         }
         cmbavDocumentocontroladorid.Name = "vDOCUMENTOCONTROLADORID";
         cmbavDocumentocontroladorid.WebTags = "";
         if ( cmbavDocumentocontroladorid.ItemCount > 0 )
         {
         }
         cmbavPersonaid.Name = "vPERSONAID";
         cmbavPersonaid.WebTags = "";
         if ( cmbavPersonaid.ItemCount > 0 )
         {
         }
         cmbavEncarregadoid.Name = "vENCARREGADOID";
         cmbavEncarregadoid.WebTags = "";
         if ( cmbavEncarregadoid.ItemCount > 0 )
         {
         }
         cmbavDocumentoativo.Name = "vDOCUMENTOATIVO";
         cmbavDocumentoativo.WebTags = "";
         cmbavDocumentoativo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbavDocumentoativo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbavDocumentoativo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavDocumentoprocessoid_Internalname = sPrefix+"vDOCUMENTOPROCESSOID";
         lblProcessoinfo_Internalname = sPrefix+"PROCESSOINFO";
         lblProcessoadd_Internalname = sPrefix+"PROCESSOADD";
         tblTablemergedprocessoinfo_Internalname = sPrefix+"TABLEMERGEDPROCESSOINFO";
         edtavDocumentoid_Internalname = sPrefix+"vDOCUMENTOID";
         cmbavSubprocessoid_Internalname = sPrefix+"vSUBPROCESSOID";
         lblSubprocessoinfo_Internalname = sPrefix+"SUBPROCESSOINFO";
         lblSubprocessoadd_Internalname = sPrefix+"SUBPROCESSOADD";
         tblTablemergedsubprocessoinfo_Internalname = sPrefix+"TABLEMERGEDSUBPROCESSOINFO";
         edtavDocumentousuarioinclusao_Internalname = sPrefix+"vDOCUMENTOUSUARIOINCLUSAO";
         cmbavArearesponsavelid_Internalname = sPrefix+"vAREARESPONSAVELID";
         lblArearesponsavelinfo_Internalname = sPrefix+"AREARESPONSAVELINFO";
         lblArearesponsaveladd_Internalname = sPrefix+"AREARESPONSAVELADD";
         tblTablemergedarearesponsavelinfo_Internalname = sPrefix+"TABLEMERGEDAREARESPONSAVELINFO";
         edtavDocumentodatainclusao_Internalname = sPrefix+"vDOCUMENTODATAINCLUSAO";
         cmbavDocumentocontroladorid_Internalname = sPrefix+"vDOCUMENTOCONTROLADORID";
         lblControladorinfo_Internalname = sPrefix+"CONTROLADORINFO";
         lblControladoradd_Internalname = sPrefix+"CONTROLADORADD";
         tblTablemergedcontroladorinfo_Internalname = sPrefix+"TABLEMERGEDCONTROLADORINFO";
         edtavDocumentousuarioalteracao_Internalname = sPrefix+"vDOCUMENTOUSUARIOALTERACAO";
         cmbavPersonaid_Internalname = sPrefix+"vPERSONAID";
         lblPersonainfo_Internalname = sPrefix+"PERSONAINFO";
         lblPersonaadd_Internalname = sPrefix+"PERSONAADD";
         tblTablemergedpersonainfo_Internalname = sPrefix+"TABLEMERGEDPERSONAINFO";
         edtavDocumentodataalteracao_Internalname = sPrefix+"vDOCUMENTODATAALTERACAO";
         cmbavEncarregadoid_Internalname = sPrefix+"vENCARREGADOID";
         lblEncarregadoinfo_Internalname = sPrefix+"ENCARREGADOINFO";
         lblEncarregadoadd_Internalname = sPrefix+"ENCARREGADOADD";
         tblTablemergedencarregadoinfo_Internalname = sPrefix+"TABLEMERGEDENCARREGADOINFO";
         edtavDocumentonome_Internalname = sPrefix+"vDOCUMENTONOME";
         lblTxtdocumentonome_Internalname = sPrefix+"TXTDOCUMENTONOME";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         cmbavDocumentoativo_Internalname = sPrefix+"vDOCUMENTOATIVO";
         bttBtncopiardocumento_Internalname = sPrefix+"BTNCOPIARDOCUMENTO";
         bttBtnsalvar_Internalname = sPrefix+"BTNSALVAR";
         divTabledocumento_Internalname = sPrefix+"TABLEDOCUMENTO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         lblProcessoadd_Visible = 1;
         lblProcessoinfo_Visible = 1;
         lblSubprocessoadd_Visible = 1;
         lblSubprocessoinfo_Visible = 1;
         lblArearesponsaveladd_Visible = 1;
         lblControladoradd_Visible = 1;
         lblControladorinfo_Visible = 1;
         lblPersonaadd_Visible = 1;
         lblPersonainfo_Visible = 1;
         lblEncarregadoadd_Visible = 1;
         lblEncarregadoinfo_Visible = 1;
         lblEncarregadoinfo_Tooltiptext = "";
         lblPersonainfo_Tooltiptext = "";
         lblControladorinfo_Tooltiptext = "";
         lblSubprocessoinfo_Tooltiptext = "";
         lblProcessoinfo_Tooltiptext = "";
         bttBtnsalvar_Visible = 1;
         bttBtncopiardocumento_Visible = 1;
         cmbavDocumentoativo_Jsonclick = "";
         cmbavDocumentoativo.Enabled = 1;
         lblTxtdocumentonome_Caption = "0/100";
         edtavDocumentonome_Jsonclick = "";
         edtavDocumentonome_Enabled = 1;
         cmbavEncarregadoid_Jsonclick = "";
         cmbavEncarregadoid.Enabled = 1;
         edtavDocumentodataalteracao_Jsonclick = "";
         edtavDocumentodataalteracao_Enabled = 1;
         cmbavPersonaid_Jsonclick = "";
         cmbavPersonaid.Enabled = 1;
         edtavDocumentousuarioalteracao_Jsonclick = "";
         edtavDocumentousuarioalteracao_Enabled = 1;
         cmbavDocumentocontroladorid_Jsonclick = "";
         cmbavDocumentocontroladorid.Enabled = 1;
         edtavDocumentodatainclusao_Jsonclick = "";
         edtavDocumentodatainclusao_Enabled = 1;
         cmbavArearesponsavelid_Jsonclick = "";
         cmbavArearesponsavelid.Enabled = 1;
         edtavDocumentousuarioinclusao_Jsonclick = "";
         edtavDocumentousuarioinclusao_Enabled = 1;
         cmbavSubprocessoid_Jsonclick = "";
         cmbavSubprocessoid.Enabled = 1;
         edtavDocumentoid_Jsonclick = "";
         edtavDocumentoid_Enabled = 0;
         cmbavDocumentoprocessoid_Jsonclick = "";
         cmbavDocumentoprocessoid.Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV51DocumentoId_Copia',fld:'vDOCUMENTOID_COPIA',pic:'ZZZZZZZ9'},{av:'AV53DocumentoNome_Copia',fld:'vDOCUMENTONOME_COPIA',pic:''},{av:'AV29IsProcesso',fld:'vISPROCESSO',pic:''},{av:'AV30ProcessoId_Out',fld:'vPROCESSOID_OUT',pic:'ZZZZZZZ9'},{av:'AV31IsSubProcesso',fld:'vISSUBPROCESSO',pic:''},{av:'AV32SubProcessoId_Out',fld:'vSUBPROCESSOID_OUT',pic:'ZZZZZZZ9'},{av:'AV37IsPersona',fld:'vISPERSONA',pic:''},{av:'AV38PersonaId_Out',fld:'vPERSONAID_OUT',pic:'ZZZZZZZ9'},{av:'AV39IsEncarregado',fld:'vISENCARREGADO',pic:''},{av:'AV40EncarregadoId_Out',fld:'vENCARREGADOID_OUT',pic:'ZZZZZZZ9'},{av:'AV57IsAreaResponsavel',fld:'vISAREARESPONSAVEL',pic:''},{av:'AV43AreaResponsavelId_Out',fld:'vAREARESPONSAVELID_OUT',pic:'ZZZZZZZ9'},{av:'AV34IsControlador',fld:'vISCONTROLADOR',pic:''},{av:'AV35ControladorId_Out',fld:'vCONTROLADORID_OUT',pic:'ZZZZZZZ9'},{av:'A17ProcessoNome',fld:'PROCESSONOME',pic:''},{av:'A19ProcessoAtivo',fld:'PROCESSOATIVO',pic:''},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'},{av:'A21SubprocessoNome',fld:'SUBPROCESSONOME',pic:''},{av:'A23SubprocessoAtivo',fld:'SUBPROCESSOATIVO',pic:''},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'A14PersonaNome',fld:'PERSONANOME',pic:''},{av:'A15PersonaAtivo',fld:'PERSONAATIVO',pic:''},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'A8EncarregadoNome',fld:'ENCARREGADONOME',pic:''},{av:'A9EncarregadoAtivo',fld:'ENCARREGADOATIVO',pic:''},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'A25AreaResponsavelNome',fld:'AREARESPONSAVELNOME',pic:''},{av:'A26AreaResponsavelAtivo',fld:'AREARESPONSAVELATIVO',pic:''},{av:'A24AreaResponsavelId',fld:'AREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'A11ControladorNome',fld:'CONTROLADORNOME',pic:''},{av:'A12ControladorAtivo',fld:'CONTROLADORATIVO',pic:''},{av:'A10ControladorId',fld:'CONTROLADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDocumentoprocessoid'},{av:'AV7DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'AV29IsProcesso',fld:'vISPROCESSO',pic:''},{av:'cmbavSubprocessoid'},{av:'AV9SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'AV31IsSubProcesso',fld:'vISSUBPROCESSO',pic:''},{av:'cmbavPersonaid'},{av:'AV14PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'AV37IsPersona',fld:'vISPERSONA',pic:''},{av:'cmbavEncarregadoid'},{av:'AV15EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'AV39IsEncarregado',fld:'vISENCARREGADO',pic:''},{av:'cmbavArearesponsavelid'},{av:'AV18AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'AV57IsAreaResponsavel',fld:'vISAREARESPONSAVEL',pic:''},{av:'cmbavDocumentocontroladorid'},{av:'AV13DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'AV34IsControlador',fld:'vISCONTROLADOR',pic:''},{av:'lblProcessoadd_Visible',ctrl:'PROCESSOADD',prop:'Visible'},{av:'lblSubprocessoadd_Visible',ctrl:'SUBPROCESSOADD',prop:'Visible'},{av:'lblArearesponsaveladd_Visible',ctrl:'AREARESPONSAVELADD',prop:'Visible'},{av:'lblControladoradd_Visible',ctrl:'CONTROLADORADD',prop:'Visible'},{av:'lblPersonaadd_Visible',ctrl:'PERSONAADD',prop:'Visible'},{av:'lblEncarregadoadd_Visible',ctrl:'ENCARREGADOADD',prop:'Visible'},{ctrl:'BTNSALVAR',prop:'Visible'}]}");
         setEventMetadata("'DOPROCESSOINFO'","{handler:'E29781',iparms:[]");
         setEventMetadata("'DOPROCESSOINFO'",",oparms:[]}");
         setEventMetadata("'DOPROCESSOADD'","{handler:'E13782',iparms:[]");
         setEventMetadata("'DOPROCESSOADD'",",oparms:[{av:'AV30ProcessoId_Out',fld:'vPROCESSOID_OUT',pic:'ZZZZZZZ9'},{av:'AV29IsProcesso',fld:'vISPROCESSO',pic:''}]}");
         setEventMetadata("'DOSUBPROCESSOINFO'","{handler:'E28781',iparms:[]");
         setEventMetadata("'DOSUBPROCESSOINFO'",",oparms:[]}");
         setEventMetadata("'DOSUBPROCESSOADD'","{handler:'E14782',iparms:[]");
         setEventMetadata("'DOSUBPROCESSOADD'",",oparms:[{av:'AV32SubProcessoId_Out',fld:'vSUBPROCESSOID_OUT',pic:'ZZZZZZZ9'},{av:'AV31IsSubProcesso',fld:'vISSUBPROCESSO',pic:''}]}");
         setEventMetadata("'DOAREARESPONSAVELINFO'","{handler:'E27781',iparms:[]");
         setEventMetadata("'DOAREARESPONSAVELINFO'",",oparms:[]}");
         setEventMetadata("'DOAREARESPONSAVELADD'","{handler:'E15782',iparms:[]");
         setEventMetadata("'DOAREARESPONSAVELADD'",",oparms:[{av:'AV43AreaResponsavelId_Out',fld:'vAREARESPONSAVELID_OUT',pic:'ZZZZZZZ9'},{av:'AV57IsAreaResponsavel',fld:'vISAREARESPONSAVEL',pic:''}]}");
         setEventMetadata("'DOCONTROLADORINFO'","{handler:'E26781',iparms:[]");
         setEventMetadata("'DOCONTROLADORINFO'",",oparms:[]}");
         setEventMetadata("'DOCONTROLADORADD'","{handler:'E16782',iparms:[]");
         setEventMetadata("'DOCONTROLADORADD'",",oparms:[{av:'AV35ControladorId_Out',fld:'vCONTROLADORID_OUT',pic:'ZZZZZZZ9'},{av:'AV34IsControlador',fld:'vISCONTROLADOR',pic:''}]}");
         setEventMetadata("'DOPERSONAINFO'","{handler:'E25781',iparms:[]");
         setEventMetadata("'DOPERSONAINFO'",",oparms:[]}");
         setEventMetadata("'DOPERSONAADD'","{handler:'E17782',iparms:[]");
         setEventMetadata("'DOPERSONAADD'",",oparms:[{av:'AV38PersonaId_Out',fld:'vPERSONAID_OUT',pic:'ZZZZZZZ9'},{av:'AV37IsPersona',fld:'vISPERSONA',pic:''}]}");
         setEventMetadata("'DOENCARREGADOINFO'","{handler:'E24781',iparms:[]");
         setEventMetadata("'DOENCARREGADOINFO'",",oparms:[]}");
         setEventMetadata("'DOENCARREGADOADD'","{handler:'E18782',iparms:[]");
         setEventMetadata("'DOENCARREGADOADD'",",oparms:[{av:'AV40EncarregadoId_Out',fld:'vENCARREGADOID_OUT',pic:'ZZZZZZZ9'},{av:'AV39IsEncarregado',fld:'vISENCARREGADO',pic:''}]}");
         setEventMetadata("'DOCOPIARDOCUMENTO'","{handler:'E19782',iparms:[]");
         setEventMetadata("'DOCOPIARDOCUMENTO'",",oparms:[{av:'AV53DocumentoNome_Copia',fld:'vDOCUMENTONOME_COPIA',pic:''},{av:'AV51DocumentoId_Copia',fld:'vDOCUMENTOID_COPIA',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("'DOSALVAR'","{handler:'E20782',iparms:[{av:'AV27CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV16DocumentoNome',fld:'vDOCUMENTONOME',pic:''},{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbavDocumentoprocessoid'},{av:'AV7DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'cmbavSubprocessoid'},{av:'AV9SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'AV10DocumentoDataInclusao',fld:'vDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV12DocumentoDataAlteracao',fld:'vDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'cmbavPersonaid'},{av:'AV14PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'cmbavEncarregadoid'},{av:'AV15EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'cmbavDocumentoativo'},{av:'AV17DocumentoAtivo',fld:'vDOCUMENTOATIVO',pic:''},{av:'cmbavDocumentocontroladorid'},{av:'AV13DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'cmbavArearesponsavelid'},{av:'AV18AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'AV20Documento',fld:'vDOCUMENTO',pic:''}]");
         setEventMetadata("'DOSALVAR'",",oparms:[{av:'AV8DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV62DocumentoUsuarioAlteracao',fld:'vDOCUMENTOUSUARIOALTERACAO',pic:''},{av:'AV12DocumentoDataAlteracao',fld:'vDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV20Documento',fld:'vDOCUMENTO',pic:''},{av:'AV27CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
         setEventMetadata("VDOCUMENTOPROCESSOID.CONTROLVALUECHANGED","{handler:'E21782',iparms:[{av:'AV60Origem',fld:'vORIGEM',pic:''},{av:'cmbavDocumentoprocessoid'},{av:'AV7DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'A21SubprocessoNome',fld:'SUBPROCESSONOME',pic:''},{av:'A23SubprocessoAtivo',fld:'SUBPROCESSOATIVO',pic:''},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'A17ProcessoNome',fld:'PROCESSONOME',pic:''},{av:'A19ProcessoAtivo',fld:'PROCESSOATIVO',pic:''}]");
         setEventMetadata("VDOCUMENTOPROCESSOID.CONTROLVALUECHANGED",",oparms:[{av:'AV60Origem',fld:'vORIGEM',pic:''},{av:'cmbavSubprocessoid'},{av:'AV9SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'cmbavDocumentoprocessoid'},{av:'AV7DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VSUBPROCESSOID.CONTROLVALUECHANGED","{handler:'E22782',iparms:[{av:'AV60Origem',fld:'vORIGEM',pic:''},{av:'cmbavSubprocessoid'},{av:'AV9SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'A23SubprocessoAtivo',fld:'SUBPROCESSOATIVO',pic:''},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'A16ProcessoId',fld:'PROCESSOID',pic:'ZZZZZZZ9'},{av:'A17ProcessoNome',fld:'PROCESSONOME',pic:''},{av:'AV63ProcessoId_Col',fld:'vPROCESSOID_COL',pic:''},{av:'A19ProcessoAtivo',fld:'PROCESSOATIVO',pic:''},{av:'A21SubprocessoNome',fld:'SUBPROCESSONOME',pic:''}]");
         setEventMetadata("VSUBPROCESSOID.CONTROLVALUECHANGED",",oparms:[{av:'AV60Origem',fld:'vORIGEM',pic:''},{av:'cmbavDocumentoprocessoid'},{av:'AV7DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'AV63ProcessoId_Col',fld:'vPROCESSOID_COL',pic:''},{av:'cmbavSubprocessoid'},{av:'AV9SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_SUBPROCESSOID","{handler:'Validv_Subprocessoid',iparms:[]");
         setEventMetadata("VALIDV_SUBPROCESSOID",",oparms:[]}");
         setEventMetadata("VALIDV_DOCUMENTODATAINCLUSAO","{handler:'Validv_Documentodatainclusao',iparms:[]");
         setEventMetadata("VALIDV_DOCUMENTODATAINCLUSAO",",oparms:[]}");
         setEventMetadata("VALIDV_DOCUMENTODATAALTERACAO","{handler:'Validv_Documentodataalteracao',iparms:[]");
         setEventMetadata("VALIDV_DOCUMENTODATAALTERACAO",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV53DocumentoNome_Copia = "";
         A17ProcessoNome = "";
         A21SubprocessoNome = "";
         A14PersonaNome = "";
         A8EncarregadoNome = "";
         A25AreaResponsavelNome = "";
         A11ControladorNome = "";
         AV20Documento = new SdtDocumento(context);
         AV60Origem = "";
         AV63ProcessoId_Col = new GxSimpleCollection<int>();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV61DocumentoUsuarioInclusao = "";
         AV10DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         AV62DocumentoUsuarioAlteracao = "";
         AV12DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         AV16DocumentoNome = "";
         lblTxtdocumentonome_Jsonclick = "";
         bttBtncopiardocumento_Jsonclick = "";
         bttBtnsalvar_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H00782_A112TooltipId = new int[1] ;
         H00782_A135CampoId = new int[1] ;
         H00782_A139TooltipTelaId = new int[1] ;
         H00782_A140TooltipTelaNome = new string[] {""} ;
         H00782_A118TooltipAtivo = new bool[] {false} ;
         H00782_A136CampoNome = new string[] {""} ;
         H00782_A115TooltipDescricao = new string[] {""} ;
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         AV68GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV70GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H00783_A20SubprocessoId = new int[1] ;
         H00783_A16ProcessoId = new int[1] ;
         H00783_n16ProcessoId = new bool[] {false} ;
         H00783_A23SubprocessoAtivo = new bool[] {false} ;
         H00783_A21SubprocessoNome = new string[] {""} ;
         H00784_A16ProcessoId = new int[1] ;
         H00784_n16ProcessoId = new bool[] {false} ;
         H00784_A23SubprocessoAtivo = new bool[] {false} ;
         H00784_A20SubprocessoId = new int[1] ;
         H00784_A21SubprocessoNome = new string[] {""} ;
         H00785_A20SubprocessoId = new int[1] ;
         H00785_A23SubprocessoAtivo = new bool[] {false} ;
         H00785_A16ProcessoId = new int[1] ;
         H00785_n16ProcessoId = new bool[] {false} ;
         H00785_A17ProcessoNome = new string[] {""} ;
         H00786_A20SubprocessoId = new int[1] ;
         H00786_A16ProcessoId = new int[1] ;
         H00786_n16ProcessoId = new bool[] {false} ;
         H00786_A23SubprocessoAtivo = new bool[] {false} ;
         H00787_A16ProcessoId = new int[1] ;
         H00787_n16ProcessoId = new bool[] {false} ;
         H00787_A19ProcessoAtivo = new bool[] {false} ;
         H00787_A17ProcessoNome = new string[] {""} ;
         H00788_A16ProcessoId = new int[1] ;
         H00788_n16ProcessoId = new bool[] {false} ;
         H00788_A19ProcessoAtivo = new bool[] {false} ;
         H00788_A17ProcessoNome = new string[] {""} ;
         H00789_A10ControladorId = new int[1] ;
         H00789_A12ControladorAtivo = new bool[] {false} ;
         H00789_A11ControladorNome = new string[] {""} ;
         H007810_A12ControladorAtivo = new bool[] {false} ;
         H007810_A10ControladorId = new int[1] ;
         H007810_A11ControladorNome = new string[] {""} ;
         H007811_A16ProcessoId = new int[1] ;
         H007811_n16ProcessoId = new bool[] {false} ;
         H007811_A19ProcessoAtivo = new bool[] {false} ;
         H007811_A17ProcessoNome = new string[] {""} ;
         H007812_A19ProcessoAtivo = new bool[] {false} ;
         H007812_A16ProcessoId = new int[1] ;
         H007812_n16ProcessoId = new bool[] {false} ;
         H007812_A17ProcessoNome = new string[] {""} ;
         H007813_A20SubprocessoId = new int[1] ;
         H007813_A23SubprocessoAtivo = new bool[] {false} ;
         H007813_A21SubprocessoNome = new string[] {""} ;
         H007814_A23SubprocessoAtivo = new bool[] {false} ;
         H007814_A20SubprocessoId = new int[1] ;
         H007814_A21SubprocessoNome = new string[] {""} ;
         H007815_A13PersonaId = new int[1] ;
         H007815_A15PersonaAtivo = new bool[] {false} ;
         H007815_A14PersonaNome = new string[] {""} ;
         H007816_A15PersonaAtivo = new bool[] {false} ;
         H007816_A13PersonaId = new int[1] ;
         H007816_A14PersonaNome = new string[] {""} ;
         H007817_A7EncarregadoId = new int[1] ;
         H007817_A9EncarregadoAtivo = new bool[] {false} ;
         H007817_A8EncarregadoNome = new string[] {""} ;
         H007818_A9EncarregadoAtivo = new bool[] {false} ;
         H007818_A7EncarregadoId = new int[1] ;
         H007818_A8EncarregadoNome = new string[] {""} ;
         H007819_A24AreaResponsavelId = new int[1] ;
         H007819_A26AreaResponsavelAtivo = new bool[] {false} ;
         H007819_A25AreaResponsavelNome = new string[] {""} ;
         H007820_A26AreaResponsavelAtivo = new bool[] {false} ;
         H007820_A24AreaResponsavelId = new int[1] ;
         H007820_A25AreaResponsavelNome = new string[] {""} ;
         sStyleString = "";
         lblEncarregadoinfo_Jsonclick = "";
         lblEncarregadoadd_Jsonclick = "";
         lblPersonainfo_Jsonclick = "";
         lblPersonaadd_Jsonclick = "";
         lblControladorinfo_Jsonclick = "";
         lblControladoradd_Jsonclick = "";
         lblArearesponsavelinfo_Jsonclick = "";
         lblArearesponsaveladd_Jsonclick = "";
         lblSubprocessoinfo_Jsonclick = "";
         lblSubprocessoadd_Jsonclick = "";
         lblProcessoinfo_Jsonclick = "";
         lblProcessoadd_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV8DocumentoId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.documentowc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentowc__default(),
            new Object[][] {
                new Object[] {
               H00782_A112TooltipId, H00782_A135CampoId, H00782_A139TooltipTelaId, H00782_A140TooltipTelaNome, H00782_A118TooltipAtivo, H00782_A136CampoNome, H00782_A115TooltipDescricao
               }
               , new Object[] {
               H00783_A20SubprocessoId, H00783_A16ProcessoId, H00783_n16ProcessoId, H00783_A23SubprocessoAtivo, H00783_A21SubprocessoNome
               }
               , new Object[] {
               H00784_A16ProcessoId, H00784_n16ProcessoId, H00784_A23SubprocessoAtivo, H00784_A20SubprocessoId, H00784_A21SubprocessoNome
               }
               , new Object[] {
               H00785_A20SubprocessoId, H00785_A23SubprocessoAtivo, H00785_A16ProcessoId, H00785_n16ProcessoId, H00785_A17ProcessoNome
               }
               , new Object[] {
               H00786_A20SubprocessoId, H00786_A16ProcessoId, H00786_n16ProcessoId, H00786_A23SubprocessoAtivo
               }
               , new Object[] {
               H00787_A16ProcessoId, H00787_A19ProcessoAtivo, H00787_A17ProcessoNome
               }
               , new Object[] {
               H00788_A16ProcessoId, H00788_A19ProcessoAtivo, H00788_A17ProcessoNome
               }
               , new Object[] {
               H00789_A10ControladorId, H00789_A12ControladorAtivo, H00789_A11ControladorNome
               }
               , new Object[] {
               H007810_A12ControladorAtivo, H007810_A10ControladorId, H007810_A11ControladorNome
               }
               , new Object[] {
               H007811_A16ProcessoId, H007811_A19ProcessoAtivo, H007811_A17ProcessoNome
               }
               , new Object[] {
               H007812_A19ProcessoAtivo, H007812_A16ProcessoId, H007812_A17ProcessoNome
               }
               , new Object[] {
               H007813_A20SubprocessoId, H007813_A23SubprocessoAtivo, H007813_A21SubprocessoNome
               }
               , new Object[] {
               H007814_A23SubprocessoAtivo, H007814_A20SubprocessoId, H007814_A21SubprocessoNome
               }
               , new Object[] {
               H007815_A13PersonaId, H007815_A15PersonaAtivo, H007815_A14PersonaNome
               }
               , new Object[] {
               H007816_A15PersonaAtivo, H007816_A13PersonaId, H007816_A14PersonaNome
               }
               , new Object[] {
               H007817_A7EncarregadoId, H007817_A9EncarregadoAtivo, H007817_A8EncarregadoNome
               }
               , new Object[] {
               H007818_A9EncarregadoAtivo, H007818_A7EncarregadoId, H007818_A8EncarregadoNome
               }
               , new Object[] {
               H007819_A24AreaResponsavelId, H007819_A26AreaResponsavelAtivo, H007819_A25AreaResponsavelNome
               }
               , new Object[] {
               H007820_A26AreaResponsavelAtivo, H007820_A24AreaResponsavelId, H007820_A25AreaResponsavelNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDocumentoid_Enabled = 0;
         edtavDocumentousuarioinclusao_Enabled = 0;
         edtavDocumentodatainclusao_Enabled = 0;
         edtavDocumentousuarioalteracao_Enabled = 0;
         edtavDocumentodataalteracao_Enabled = 0;
      }

      private short nRcdExists_21 ;
      private short nIsMod_21 ;
      private short nRcdExists_20 ;
      private short nIsMod_20 ;
      private short nRcdExists_19 ;
      private short nIsMod_19 ;
      private short nRcdExists_18 ;
      private short nIsMod_18 ;
      private short nRcdExists_17 ;
      private short nIsMod_17 ;
      private short nRcdExists_16 ;
      private short nIsMod_16 ;
      private short nRcdExists_15 ;
      private short nIsMod_15 ;
      private short nRcdExists_14 ;
      private short nIsMod_14 ;
      private short nRcdExists_13 ;
      private short nIsMod_13 ;
      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV55Count ;
      private short nGXWrapped ;
      private int AV8DocumentoId ;
      private int wcpOAV8DocumentoId ;
      private int edtavDocumentoid_Enabled ;
      private int edtavDocumentousuarioinclusao_Enabled ;
      private int edtavDocumentodatainclusao_Enabled ;
      private int edtavDocumentousuarioalteracao_Enabled ;
      private int edtavDocumentodataalteracao_Enabled ;
      private int AV51DocumentoId_Copia ;
      private int AV30ProcessoId_Out ;
      private int AV32SubProcessoId_Out ;
      private int AV38PersonaId_Out ;
      private int AV40EncarregadoId_Out ;
      private int AV43AreaResponsavelId_Out ;
      private int AV35ControladorId_Out ;
      private int A16ProcessoId ;
      private int A20SubprocessoId ;
      private int A13PersonaId ;
      private int A7EncarregadoId ;
      private int A24AreaResponsavelId ;
      private int A10ControladorId ;
      private int AV7DocumentoProcessoId ;
      private int AV9SubprocessoId ;
      private int AV18AreaResponsavelId ;
      private int AV13DocumentoControladorId ;
      private int AV14PersonaId ;
      private int AV15EncarregadoId ;
      private int edtavDocumentonome_Enabled ;
      private int bttBtncopiardocumento_Visible ;
      private int bttBtnsalvar_Visible ;
      private int lblProcessoinfo_Visible ;
      private int lblProcessoadd_Visible ;
      private int lblSubprocessoinfo_Visible ;
      private int lblSubprocessoadd_Visible ;
      private int lblControladorinfo_Visible ;
      private int lblControladoradd_Visible ;
      private int lblPersonainfo_Visible ;
      private int lblPersonaadd_Visible ;
      private int lblEncarregadoinfo_Visible ;
      private int lblEncarregadoadd_Visible ;
      private int lblArearesponsaveladd_Visible ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int AV52DocumentoId_Copiado ;
      private int AV69GXV2 ;
      private int AV71GXV4 ;
      private int AV58ProcessoId ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavDocumentoid_Internalname ;
      private string edtavDocumentousuarioinclusao_Internalname ;
      private string edtavDocumentodatainclusao_Internalname ;
      private string edtavDocumentousuarioalteracao_Internalname ;
      private string edtavDocumentodataalteracao_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTabledocumento_Internalname ;
      private string cmbavDocumentoprocessoid_Internalname ;
      private string TempTags ;
      private string cmbavDocumentoprocessoid_Jsonclick ;
      private string edtavDocumentoid_Jsonclick ;
      private string cmbavSubprocessoid_Internalname ;
      private string cmbavSubprocessoid_Jsonclick ;
      private string edtavDocumentousuarioinclusao_Jsonclick ;
      private string cmbavArearesponsavelid_Internalname ;
      private string cmbavArearesponsavelid_Jsonclick ;
      private string edtavDocumentodatainclusao_Jsonclick ;
      private string cmbavDocumentocontroladorid_Internalname ;
      private string cmbavDocumentocontroladorid_Jsonclick ;
      private string edtavDocumentousuarioalteracao_Jsonclick ;
      private string cmbavPersonaid_Internalname ;
      private string cmbavPersonaid_Jsonclick ;
      private string edtavDocumentodataalteracao_Jsonclick ;
      private string cmbavEncarregadoid_Internalname ;
      private string cmbavEncarregadoid_Jsonclick ;
      private string edtavDocumentonome_Internalname ;
      private string edtavDocumentonome_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTxtdocumentonome_Internalname ;
      private string lblTxtdocumentonome_Caption ;
      private string lblTxtdocumentonome_Jsonclick ;
      private string cmbavDocumentoativo_Internalname ;
      private string cmbavDocumentoativo_Jsonclick ;
      private string bttBtncopiardocumento_Internalname ;
      private string bttBtncopiardocumento_Jsonclick ;
      private string bttBtnsalvar_Internalname ;
      private string bttBtnsalvar_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string lblProcessoinfo_Internalname ;
      private string lblProcessoadd_Internalname ;
      private string lblSubprocessoinfo_Internalname ;
      private string lblSubprocessoadd_Internalname ;
      private string lblControladorinfo_Internalname ;
      private string lblControladoradd_Internalname ;
      private string lblPersonainfo_Internalname ;
      private string lblPersonaadd_Internalname ;
      private string lblEncarregadoinfo_Internalname ;
      private string lblEncarregadoadd_Internalname ;
      private string lblArearesponsaveladd_Internalname ;
      private string scmdbuf ;
      private string lblProcessoinfo_Tooltiptext ;
      private string lblSubprocessoinfo_Tooltiptext ;
      private string lblControladorinfo_Tooltiptext ;
      private string lblPersonainfo_Tooltiptext ;
      private string lblEncarregadoinfo_Tooltiptext ;
      private string sStyleString ;
      private string tblTablemergedencarregadoinfo_Internalname ;
      private string lblEncarregadoinfo_Jsonclick ;
      private string lblEncarregadoadd_Jsonclick ;
      private string tblTablemergedpersonainfo_Internalname ;
      private string lblPersonainfo_Jsonclick ;
      private string lblPersonaadd_Jsonclick ;
      private string tblTablemergedcontroladorinfo_Internalname ;
      private string lblControladorinfo_Jsonclick ;
      private string lblControladoradd_Jsonclick ;
      private string tblTablemergedarearesponsavelinfo_Internalname ;
      private string lblArearesponsavelinfo_Internalname ;
      private string lblArearesponsavelinfo_Jsonclick ;
      private string lblArearesponsaveladd_Jsonclick ;
      private string tblTablemergedsubprocessoinfo_Internalname ;
      private string lblSubprocessoinfo_Jsonclick ;
      private string lblSubprocessoadd_Jsonclick ;
      private string tblTablemergedprocessoinfo_Internalname ;
      private string lblProcessoinfo_Jsonclick ;
      private string lblProcessoadd_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV8DocumentoId ;
      private DateTime AV10DocumentoDataInclusao ;
      private DateTime AV12DocumentoDataAlteracao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29IsProcesso ;
      private bool AV31IsSubProcesso ;
      private bool AV37IsPersona ;
      private bool AV39IsEncarregado ;
      private bool AV57IsAreaResponsavel ;
      private bool AV34IsControlador ;
      private bool A19ProcessoAtivo ;
      private bool A23SubprocessoAtivo ;
      private bool A15PersonaAtivo ;
      private bool A9EncarregadoAtivo ;
      private bool A26AreaResponsavelAtivo ;
      private bool A12ControladorAtivo ;
      private bool AV27CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool AV17DocumentoAtivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A118TooltipAtivo ;
      private bool AV54Existe ;
      private bool AV44IsAuthorized_ProcessoAdd ;
      private bool AV45IsAuthorized_SubprocessoAdd ;
      private bool AV56IsAuthorized_AreaResponsavelAdd ;
      private bool AV46IsAuthorized_ControladorAdd ;
      private bool AV47IsAuthorized_PersonaAdd ;
      private bool AV48IsAuthorized_EncarregadoAdd ;
      private bool AV49IsAuthorized_Salvar ;
      private bool GXt_boolean1 ;
      private bool n16ProcessoId ;
      private string A115TooltipDescricao ;
      private string AV53DocumentoNome_Copia ;
      private string A17ProcessoNome ;
      private string A21SubprocessoNome ;
      private string A14PersonaNome ;
      private string A8EncarregadoNome ;
      private string A25AreaResponsavelNome ;
      private string A11ControladorNome ;
      private string AV60Origem ;
      private string AV61DocumentoUsuarioInclusao ;
      private string AV62DocumentoUsuarioAlteracao ;
      private string AV16DocumentoNome ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private GxSimpleCollection<int> AV63ProcessoId_Col ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDocumentoprocessoid ;
      private GXCombobox cmbavSubprocessoid ;
      private GXCombobox cmbavArearesponsavelid ;
      private GXCombobox cmbavDocumentocontroladorid ;
      private GXCombobox cmbavPersonaid ;
      private GXCombobox cmbavEncarregadoid ;
      private GXCombobox cmbavDocumentoativo ;
      private IDataStoreProvider pr_default ;
      private int[] H00782_A112TooltipId ;
      private int[] H00782_A135CampoId ;
      private int[] H00782_A139TooltipTelaId ;
      private string[] H00782_A140TooltipTelaNome ;
      private bool[] H00782_A118TooltipAtivo ;
      private string[] H00782_A136CampoNome ;
      private string[] H00782_A115TooltipDescricao ;
      private int[] H00783_A20SubprocessoId ;
      private int[] H00783_A16ProcessoId ;
      private bool[] H00783_n16ProcessoId ;
      private bool[] H00783_A23SubprocessoAtivo ;
      private string[] H00783_A21SubprocessoNome ;
      private int[] H00784_A16ProcessoId ;
      private bool[] H00784_n16ProcessoId ;
      private bool[] H00784_A23SubprocessoAtivo ;
      private int[] H00784_A20SubprocessoId ;
      private string[] H00784_A21SubprocessoNome ;
      private int[] H00785_A20SubprocessoId ;
      private bool[] H00785_A23SubprocessoAtivo ;
      private int[] H00785_A16ProcessoId ;
      private bool[] H00785_n16ProcessoId ;
      private string[] H00785_A17ProcessoNome ;
      private int[] H00786_A20SubprocessoId ;
      private int[] H00786_A16ProcessoId ;
      private bool[] H00786_n16ProcessoId ;
      private bool[] H00786_A23SubprocessoAtivo ;
      private int[] H00787_A16ProcessoId ;
      private bool[] H00787_n16ProcessoId ;
      private bool[] H00787_A19ProcessoAtivo ;
      private string[] H00787_A17ProcessoNome ;
      private int[] H00788_A16ProcessoId ;
      private bool[] H00788_n16ProcessoId ;
      private bool[] H00788_A19ProcessoAtivo ;
      private string[] H00788_A17ProcessoNome ;
      private int[] H00789_A10ControladorId ;
      private bool[] H00789_A12ControladorAtivo ;
      private string[] H00789_A11ControladorNome ;
      private bool[] H007810_A12ControladorAtivo ;
      private int[] H007810_A10ControladorId ;
      private string[] H007810_A11ControladorNome ;
      private int[] H007811_A16ProcessoId ;
      private bool[] H007811_n16ProcessoId ;
      private bool[] H007811_A19ProcessoAtivo ;
      private string[] H007811_A17ProcessoNome ;
      private bool[] H007812_A19ProcessoAtivo ;
      private int[] H007812_A16ProcessoId ;
      private bool[] H007812_n16ProcessoId ;
      private string[] H007812_A17ProcessoNome ;
      private int[] H007813_A20SubprocessoId ;
      private bool[] H007813_A23SubprocessoAtivo ;
      private string[] H007813_A21SubprocessoNome ;
      private bool[] H007814_A23SubprocessoAtivo ;
      private int[] H007814_A20SubprocessoId ;
      private string[] H007814_A21SubprocessoNome ;
      private int[] H007815_A13PersonaId ;
      private bool[] H007815_A15PersonaAtivo ;
      private string[] H007815_A14PersonaNome ;
      private bool[] H007816_A15PersonaAtivo ;
      private int[] H007816_A13PersonaId ;
      private string[] H007816_A14PersonaNome ;
      private int[] H007817_A7EncarregadoId ;
      private bool[] H007817_A9EncarregadoAtivo ;
      private string[] H007817_A8EncarregadoNome ;
      private bool[] H007818_A9EncarregadoAtivo ;
      private int[] H007818_A7EncarregadoId ;
      private string[] H007818_A8EncarregadoNome ;
      private int[] H007819_A24AreaResponsavelId ;
      private bool[] H007819_A26AreaResponsavelAtivo ;
      private string[] H007819_A25AreaResponsavelNome ;
      private bool[] H007820_A26AreaResponsavelAtivo ;
      private int[] H007820_A24AreaResponsavelId ;
      private string[] H007820_A25AreaResponsavelNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV68GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV70GXV3 ;
      private SdtDocumento AV20Documento ;
      private GeneXus.Utils.SdtMessages_Message AV23Message ;
   }

   public class documentowc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentowc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H00787( IGxContext context ,
                                           int A16ProcessoId ,
                                           GxSimpleCollection<int> AV63ProcessoId_Col ,
                                           bool A19ProcessoAtivo )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT [ProcessoId], [ProcessoAtivo], [ProcessoNome] FROM [Processo]";
       AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63ProcessoId_Col, "[ProcessoId] IN (", ")")+")");
       AddWhere(sWhereString, "([ProcessoAtivo] = 1)");
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [ProcessoNome]";
       GXv_Object2[0] = scmdbuf;
       return GXv_Object2 ;
    }

    protected Object[] conditional_H00788( IGxContext context ,
                                           int A16ProcessoId ,
                                           GxSimpleCollection<int> AV63ProcessoId_Col ,
                                           bool A19ProcessoAtivo )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT [ProcessoId], [ProcessoAtivo], [ProcessoNome] FROM [Processo]";
       AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63ProcessoId_Col, "[ProcessoId] IN (", ")")+")");
       AddWhere(sWhereString, "([ProcessoAtivo] = 1)");
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [ProcessoNome]";
       GXv_Object4[0] = scmdbuf;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 5 :
                   return conditional_H00787(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (bool)dynConstraints[2] );
             case 6 :
                   return conditional_H00788(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (bool)dynConstraints[2] );
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
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH00782;
        prmH00782 = new Object[] {
        };
        Object[] prmH00783;
        prmH00783 = new Object[] {
        new ParDef("@AV7DocumentoProcessoId",GXType.Int32,8,0)
        };
        Object[] prmH00784;
        prmH00784 = new Object[] {
        new ParDef("@AV7DocumentoProcessoId",GXType.Int32,8,0)
        };
        Object[] prmH00785;
        prmH00785 = new Object[] {
        new ParDef("@AV9SubprocessoId",GXType.Int32,8,0)
        };
        Object[] prmH00786;
        prmH00786 = new Object[] {
        };
        Object[] prmH00789;
        prmH00789 = new Object[] {
        };
        Object[] prmH007810;
        prmH007810 = new Object[] {
        };
        Object[] prmH007811;
        prmH007811 = new Object[] {
        };
        Object[] prmH007812;
        prmH007812 = new Object[] {
        };
        Object[] prmH007813;
        prmH007813 = new Object[] {
        };
        Object[] prmH007814;
        prmH007814 = new Object[] {
        };
        Object[] prmH007815;
        prmH007815 = new Object[] {
        };
        Object[] prmH007816;
        prmH007816 = new Object[] {
        };
        Object[] prmH007817;
        prmH007817 = new Object[] {
        };
        Object[] prmH007818;
        prmH007818 = new Object[] {
        };
        Object[] prmH007819;
        prmH007819 = new Object[] {
        };
        Object[] prmH007820;
        prmH007820 = new Object[] {
        };
        Object[] prmH00787;
        prmH00787 = new Object[] {
        };
        Object[] prmH00788;
        prmH00788 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H00782", "SELECT T1.[TooltipId], T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipAtivo], T2.[CampoNome], T1.[TooltipDescricao] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId]) WHERE (T1.[TooltipAtivo] = 1) AND (T3.[TelaNome] = 'DOCUMENTO') ORDER BY T1.[TooltipId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00782,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00783", "SELECT [SubprocessoId], [ProcessoId], [SubprocessoAtivo], [SubprocessoNome] FROM [SubProcesso] WHERE ([ProcessoId] = @AV7DocumentoProcessoId or [ProcessoId] IS NULL) AND ([SubprocessoAtivo] = 1) ORDER BY [SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00783,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00784", "SELECT [ProcessoId], [SubprocessoAtivo], [SubprocessoId], [SubprocessoNome] FROM [SubProcesso] WHERE ([ProcessoId] = @AV7DocumentoProcessoId or [ProcessoId] IS NULL) AND ([SubprocessoAtivo] = 1) ORDER BY [SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00784,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00785", "SELECT T1.[SubprocessoId], T1.[SubprocessoAtivo], T1.[ProcessoId], T2.[ProcessoNome] FROM ([SubProcesso] T1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = T1.[ProcessoId]) WHERE (T1.[SubprocessoId] = @AV9SubprocessoId) AND (T1.[SubprocessoAtivo] = 1) ORDER BY T1.[SubprocessoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00785,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H00786", "SELECT [SubprocessoId], [ProcessoId], [SubprocessoAtivo] FROM [SubProcesso] WHERE (Not [ProcessoId] IS NULL) AND ([SubprocessoAtivo] = 1) ORDER BY [SubprocessoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00786,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00787", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00787,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00788", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00788,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00789", "SELECT [ControladorId], [ControladorAtivo], [ControladorNome] FROM [Controlador] WHERE [ControladorAtivo] = 1 ORDER BY [ControladorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00789,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007810", "SELECT [ControladorAtivo], [ControladorId], [ControladorNome] FROM [Controlador] WHERE [ControladorAtivo] = 1 ORDER BY [ControladorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007810,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007811", "SELECT [ProcessoId], [ProcessoAtivo], [ProcessoNome] FROM [Processo] WHERE [ProcessoAtivo] = 1 ORDER BY [ProcessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007811,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007812", "SELECT [ProcessoAtivo], [ProcessoId], [ProcessoNome] FROM [Processo] WHERE [ProcessoAtivo] = 1 ORDER BY [ProcessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007812,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007813", "SELECT [SubprocessoId], [SubprocessoAtivo], [SubprocessoNome] FROM [SubProcesso] WHERE [SubprocessoAtivo] = 1 ORDER BY [SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007813,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007814", "SELECT [SubprocessoAtivo], [SubprocessoId], [SubprocessoNome] FROM [SubProcesso] WHERE [SubprocessoAtivo] = 1 ORDER BY [SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007814,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007815", "SELECT [PersonaId], [PersonaAtivo], [PersonaNome] FROM [Persona] WHERE [PersonaAtivo] = 1 ORDER BY [PersonaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007815,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007816", "SELECT [PersonaAtivo], [PersonaId], [PersonaNome] FROM [Persona] WHERE [PersonaAtivo] = 1 ORDER BY [PersonaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007816,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007817", "SELECT [EncarregadoId], [EncarregadoAtivo], [EncarregadoNome] FROM [Encarregado] WHERE [EncarregadoAtivo] = 1 ORDER BY [EncarregadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007817,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007818", "SELECT [EncarregadoAtivo], [EncarregadoId], [EncarregadoNome] FROM [Encarregado] WHERE [EncarregadoAtivo] = 1 ORDER BY [EncarregadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007818,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007819", "SELECT [AreaResponsavelId], [AreaResponsavelAtivo], [AreaResponsavelNome] FROM [AreaResponsavel] WHERE [AreaResponsavelAtivo] = 1 ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007819,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007820", "SELECT [AreaResponsavelAtivo], [AreaResponsavelId], [AreaResponsavelNome] FROM [AreaResponsavel] WHERE [AreaResponsavelAtivo] = 1 ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007820,100, GxCacheFrequency.OFF ,false,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((bool[]) buf[3])[0] = rslt.getBool(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((bool[]) buf[2])[0] = rslt.getBool(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((bool[]) buf[3])[0] = rslt.getBool(3);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 8 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 10 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 12 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 14 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 16 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 18 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
  }

}

}
