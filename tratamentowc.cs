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
   public class tratamentowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public tratamentowc( )
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

      public tratamentowc( IGxContext context )
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
         this.AV36DocumentoId = aP1_DocumentoId;
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
         cmbavCategoriaid = new GXCombobox();
         cmbavTipodadoid = new GXCombobox();
         cmbavFerramentacoletaid = new GXCombobox();
         cmbavAbrangenciageograficaid = new GXCombobox();
         cmbavFrequenciatratamentoid = new GXCombobox();
         cmbavTipodescarteid = new GXCombobox();
         cmbavTemporetencaoid = new GXCombobox();
         cmbavDocumentoprevcoletadados = new GXCombobox();
         chkavDocumentodadosgrupovul = new GXCheckbox();
         chkavDocumentodadoscriancaadolesc = new GXCheckbox();
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
                  AV36DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "AV36DocumentoId", StringUtil.LTrimStr( (decimal)(AV36DocumentoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV36DocumentoId});
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
            PA792( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS792( ) ;
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
            context.SendWebValue( "Aba de Tratamento para o cadastro de um Documento") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GXEncryptionTmp = "tratamentowc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV36DocumentoId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tratamentowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV26DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV26DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFONTERETENCAOID_DATA", AV25FonteRetencaoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFONTERETENCAOID_DATA", AV25FonteRetencaoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSETORINTERNOID_DATA", AV31SetorInternoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSETORINTERNOID_DATA", AV31SetorInternoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPARTINTERNOID_DATA", AV32CompartInternoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPARTINTERNOID_DATA", AV32CompartInternoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENVOLVIDOSCOLETAID_DATA", AV33EnvolvidosColetaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENVOLVIDOSCOLETAID_DATA", AV33EnvolvidosColetaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMEDIDASEGURANCAID_DATA", AV88MedidaSegurancaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMEDIDASEGURANCAID_DATA", AV88MedidaSegurancaId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOFLUXOTRATDADOSDESC", AV22DocumentoFluxoTratDadosDesc);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV36DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV36DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISCATEGORIA", AV52IsCategoria);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCATEGORIAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51CategoriaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISTIPODADO", AV53IsTipoDado);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTIPODADOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54TipoDadoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFERRAMENTACOLETA", AV55IsFerramentaColeta);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFERRAMENTACOLETAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56FerramentaColetaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISABRANGENCIAGEOGRAFICA", AV57IsAbrangenciaGeografica);
         GxWebStd.gx_hidden_field( context, sPrefix+"vABRANGENCIAGEOGRAFICAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58AbrangenciaGeograficaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFONTERETENCAO", AV60IsFonteRetencao);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFONTERETENCAOID_COL", AV46FonteRetencaoId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFONTERETENCAOID_COL", AV46FonteRetencaoId_Col);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vFONTERETENCAOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59FonteRetencaoId_Out), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFREQUENCIATRATAMENTO", AV61IsFrequenciaTratamento);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFREQUENCIATRATAMENTOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62FrequenciaTratamentoId_Out), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISTIPODESCARTE", AV63IsTipoDescarte);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTIPODESCARTEID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64TipoDescarteId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISTEMPORETENCAO", AV65IsTempoRetencao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTEMPORETENCAOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66TempoRetencaoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSETORINTERNO", AV67IsSetorInterno);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSETORINTERNOID_COL", AV48SetorInternoId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSETORINTERNOID_COL", AV48SetorInternoId_Col);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vSETORINTERNOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68SetorInternoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISCOMPARTINTERNO", AV69IsCompartInterno);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPARTINTERNOID_COL", AV47CompartInternoId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPARTINTERNOID_COL", AV47CompartInternoId_Col);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMPARTINTERNOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70CompartInternoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISENVOLVIDOSCOLETA", AV71IsEnvolvidosColeta);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENVOLVIDOSCOLETAID_COL", AV49EnvolvidosColetaId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENVOLVIDOSCOLETAID_COL", AV49EnvolvidosColetaId_Col);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vENVOLVIDOSCOLETAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72EnvolvidosColetaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISMEDIDASEGURANCA", AV73IsMedidaSeguranca);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMEDIDASEGURANCAID_COL", AV89MedidaSegurancaId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMEDIDASEGURANCAID_COL", AV89MedidaSegurancaId_Col);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMEDIDASEGURANCAID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV74MedidaSegurancaId_Out), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CATEGORIANOME", A28CategoriaNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"CATEGORIAATIVO", A29CategoriaAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"CATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27CategoriaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPODADONOME", A31TipoDadoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TIPODADOATIVO", A32TipoDadoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPODADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30TipoDadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FERRAMENTACOLETANOME", A34FerramentaColetaNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"FERRAMENTACOLETAATIVO", A35FerramentaColetaAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"FERRAMENTACOLETAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FerramentaColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ABRANGENCIAGEOGRAFICANOME", A37AbrangenciaGeograficaNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"ABRANGENCIAGEOGRAFICAATIVO", A38AbrangenciaGeograficaAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"ABRANGENCIAGEOGRAFICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AbrangenciaGeograficaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FONTERETENCAONOME", A64FonteRetencaoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"FONTERETENCAOATIVO", A65FonteRetencaoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"FONTERETENCAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A63FonteRetencaoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFONTERETENCAOID", AV24FonteRetencaoId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFONTERETENCAOID", AV24FonteRetencaoId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FREQUENCIATRATAMENTONOME", A40FrequenciaTratamentoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"FREQUENCIATRATAMENTOATIVO", A41FrequenciaTratamentoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"FREQUENCIATRATAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39FrequenciaTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPODESCARTENOME", A46TipoDescarteNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TIPODESCARTEATIVO", A47TipoDescarteAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPODESCARTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TipoDescarteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TEMPORETENCAONOME", A49TempoRetencaoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TEMPORETENCAOATIVO", A50TempoRetencaoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"TEMPORETENCAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48TempoRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETORINTERNONOME", A61SetorInternoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"SETORINTERNOATIVO", A62SetorInternoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"SETORINTERNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A60SetorInternoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSETORINTERNOID", AV28SetorInternoId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSETORINTERNOID", AV28SetorInternoId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"COMPARTINTERNONOME", A58CompartInternoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"COMPARTINTERNOATIVO", A59CompartInternoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMPARTINTERNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A57CompartInternoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPARTINTERNOID", AV29CompartInternoId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPARTINTERNOID", AV29CompartInternoId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"ENVOLVIDOSCOLETANOME", A55EnvolvidosColetaNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"ENVOLVIDOSCOLETAATIVO", A56EnvolvidosColetaAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENVOLVIDOSCOLETAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54EnvolvidosColetaId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENVOLVIDOSCOLETAID", AV30EnvolvidosColetaId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENVOLVIDOSCOLETAID", AV30EnvolvidosColetaId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDIDASEGURANCANOME", A52MedidaSegurancaNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"MEDIDASEGURANCAATIVO", A53MedidaSegurancaAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDIDASEGURANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51MedidaSegurancaId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMEDIDASEGURANCAID", AV20MedidaSegurancaId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMEDIDASEGURANCAID", AV20MedidaSegurancaId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCUMENTO", AV34Documento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCUMENTO", AV34Documento);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Cls", StringUtil.RTrim( Combo_fonteretencaoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_set", StringUtil.RTrim( Combo_fonteretencaoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Enabled", StringUtil.BoolToStr( Combo_fonteretencaoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Allowmultipleselection", StringUtil.BoolToStr( Combo_fonteretencaoid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_fonteretencaoid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Multiplevaluestype", StringUtil.RTrim( Combo_fonteretencaoid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Emptyitemtext", StringUtil.RTrim( Combo_fonteretencaoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Cls", StringUtil.RTrim( Combo_setorinternoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_set", StringUtil.RTrim( Combo_setorinternoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Enabled", StringUtil.BoolToStr( Combo_setorinternoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Allowmultipleselection", StringUtil.BoolToStr( Combo_setorinternoid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_setorinternoid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Multiplevaluestype", StringUtil.RTrim( Combo_setorinternoid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Emptyitemtext", StringUtil.RTrim( Combo_setorinternoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Cls", StringUtil.RTrim( Combo_compartinternoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_set", StringUtil.RTrim( Combo_compartinternoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Enabled", StringUtil.BoolToStr( Combo_compartinternoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Allowmultipleselection", StringUtil.BoolToStr( Combo_compartinternoid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_compartinternoid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Multiplevaluestype", StringUtil.RTrim( Combo_compartinternoid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Emptyitemtext", StringUtil.RTrim( Combo_compartinternoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Cls", StringUtil.RTrim( Combo_envolvidoscoletaid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_set", StringUtil.RTrim( Combo_envolvidoscoletaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Enabled", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Allowmultipleselection", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Multiplevaluestype", StringUtil.RTrim( Combo_envolvidoscoletaid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Emptyitemtext", StringUtil.RTrim( Combo_envolvidoscoletaid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Cls", StringUtil.RTrim( Combo_medidasegurancaid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_set", StringUtil.RTrim( Combo_medidasegurancaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Enabled", StringUtil.BoolToStr( Combo_medidasegurancaid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Allowmultipleselection", StringUtil.BoolToStr( Combo_medidasegurancaid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_medidasegurancaid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Emptyitem", StringUtil.BoolToStr( Combo_medidasegurancaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Multiplevaluestype", StringUtil.RTrim( Combo_medidasegurancaid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Enabled", StringUtil.BoolToStr( Documentofluxotratdadosdesc_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Width", StringUtil.RTrim( Documentofluxotratdadosdesc_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Height", StringUtil.RTrim( Documentofluxotratdadosdesc_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Captionclass", StringUtil.RTrim( Documentofluxotratdadosdesc_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Captionstyle", StringUtil.RTrim( Documentofluxotratdadosdesc_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Captionposition", StringUtil.RTrim( Documentofluxotratdadosdesc_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_get", StringUtil.RTrim( Combo_fonteretencaoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_setorinternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_compartinternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_get", StringUtil.RTrim( Combo_envolvidoscoletaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_get", StringUtil.RTrim( Combo_medidasegurancaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_get", StringUtil.RTrim( Combo_fonteretencaoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_setorinternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_compartinternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_get", StringUtil.RTrim( Combo_envolvidoscoletaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_get", StringUtil.RTrim( Combo_medidasegurancaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_compartinternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_get", StringUtil.RTrim( Combo_envolvidoscoletaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_get", StringUtil.RTrim( Combo_medidasegurancaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_get", StringUtil.RTrim( Combo_fonteretencaoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_setorinternoid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm792( )
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
         return "TratamentoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aba de Tratamento para o cadastro de um Documento" ;
      }

      protected void WB790( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "tratamentowc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletratamento_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentofinalidadetratamento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentofinalidadetratamento_Internalname, "FINALIDADE DO TRATAMENTO DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentofinalidadetratamento_Internalname, AV7DocumentoFinalidadeTratamento, StringUtil.RTrim( context.localUtil.Format( AV7DocumentoFinalidadeTratamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentofinalidadetratamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentofinalidadetratamento_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFinalidadetratamentoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblFinalidadetratamentoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e11791_client"+"'", "", "TextBlock", 7, lblFinalidadetratamentoinfo_Tooltiptext, lblFinalidadetratamentoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtfinalidadetratamento_Internalname, lblTxtfinalidadetratamento_Caption, "", "", lblTxtfinalidadetratamento_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavCategoriaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCategoriaid_Internalname, "CATEGORIA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCategoriaid, cmbavCategoriaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8CategoriaId), 8, 0)), 1, cmbavCategoriaid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavCategoriaid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavCategoriaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8CategoriaId), 8, 0));
            AssignProp(sPrefix, false, cmbavCategoriaid_Internalname, "Values", (string)(cmbavCategoriaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table1_40_792( true) ;
         }
         else
         {
            wb_table1_40_792( false) ;
         }
         return  ;
      }

      protected void wb_table1_40_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavTipodadoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipodadoid_Internalname, "TIPO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipodadoid, cmbavTipodadoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9TipoDadoId), 8, 0)), 1, cmbavTipodadoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTipodadoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavTipodadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9TipoDadoId), 8, 0));
            AssignProp(sPrefix, false, cmbavTipodadoid_Internalname, "Values", (string)(cmbavTipodadoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table2_51_792( true) ;
         }
         else
         {
            wb_table2_51_792( false) ;
         }
         return  ;
      }

      protected void wb_table2_51_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFerramentacoletaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFerramentacoletaid_Internalname, "FERRAMENTA DE COLETA DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFerramentacoletaid, cmbavFerramentacoletaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10FerramentaColetaId), 8, 0)), 1, cmbavFerramentacoletaid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFerramentacoletaid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavFerramentacoletaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10FerramentaColetaId), 8, 0));
            AssignProp(sPrefix, false, cmbavFerramentacoletaid_Internalname, "Values", (string)(cmbavFerramentacoletaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table3_63_792( true) ;
         }
         else
         {
            wb_table3_63_792( false) ;
         }
         return  ;
      }

      protected void wb_table3_63_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavAbrangenciageograficaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAbrangenciageograficaid_Internalname, "ABRANGÊNCIA/ÁREA GEOGRÁFICA DO TRATAMENTO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAbrangenciageograficaid, cmbavAbrangenciageograficaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11AbrangenciaGeograficaId), 8, 0)), 1, cmbavAbrangenciageograficaid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavAbrangenciageograficaid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavAbrangenciageograficaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
            AssignProp(sPrefix, false, cmbavAbrangenciageograficaid_Internalname, "Values", (string)(cmbavAbrangenciageograficaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table4_75_792( true) ;
         }
         else
         {
            wb_table4_75_792( false) ;
         }
         return  ;
      }

      protected void wb_table4_75_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFrequenciatratamentoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFrequenciatratamentoid_Internalname, "FREQUÊNCIA DE TRATAMENTO DOS DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFrequenciatratamentoid, cmbavFrequenciatratamentoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12FrequenciaTratamentoId), 8, 0)), 1, cmbavFrequenciatratamentoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFrequenciatratamentoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavFrequenciatratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
            AssignProp(sPrefix, false, cmbavFrequenciatratamentoid_Internalname, "Values", (string)(cmbavFrequenciatratamentoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table5_87_792( true) ;
         }
         else
         {
            wb_table5_87_792( false) ;
         }
         return  ;
      }

      protected void wb_table5_87_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfonteretencaoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_fonteretencaoid_Internalname, "FONTE(S) DE RETENÇÃO / ARMAZENAMENTO", "", "", lblTextblockcombo_fonteretencaoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_fonteretencaoid.SetProperty("Caption", Combo_fonteretencaoid_Caption);
            ucCombo_fonteretencaoid.SetProperty("Cls", Combo_fonteretencaoid_Cls);
            ucCombo_fonteretencaoid.SetProperty("AllowMultipleSelection", Combo_fonteretencaoid_Allowmultipleselection);
            ucCombo_fonteretencaoid.SetProperty("IncludeOnlySelectedOption", Combo_fonteretencaoid_Includeonlyselectedoption);
            ucCombo_fonteretencaoid.SetProperty("MultipleValuesType", Combo_fonteretencaoid_Multiplevaluestype);
            ucCombo_fonteretencaoid.SetProperty("EmptyItemText", Combo_fonteretencaoid_Emptyitemtext);
            ucCombo_fonteretencaoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_fonteretencaoid.SetProperty("DropDownOptionsData", AV25FonteRetencaoId_Data);
            ucCombo_fonteretencaoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_fonteretencaoid_Internalname, sPrefix+"COMBO_FONTERETENCAOIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table6_102_792( true) ;
         }
         else
         {
            wb_table6_102_792( false) ;
         }
         return  ;
      }

      protected void wb_table6_102_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavTipodescarteid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipodescarteid_Internalname, "TIPO DESCARTE", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipodescarteid, cmbavTipodescarteid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV13TipoDescarteId), 8, 0)), 1, cmbavTipodescarteid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTipodescarteid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavTipodescarteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13TipoDescarteId), 8, 0));
            AssignProp(sPrefix, false, cmbavTipodescarteid_Internalname, "Values", (string)(cmbavTipodescarteid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table7_117_792( true) ;
         }
         else
         {
            wb_table7_117_792( false) ;
         }
         return  ;
      }

      protected void wb_table7_117_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavTemporetencaoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTemporetencaoid_Internalname, "TEMPO DE GUARDA / RETENÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTemporetencaoid, cmbavTemporetencaoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14TempoRetencaoId), 8, 0)), 1, cmbavTemporetencaoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTemporetencaoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavTemporetencaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14TempoRetencaoId), 8, 0));
            AssignProp(sPrefix, false, cmbavTemporetencaoid_Internalname, "Values", (string)(cmbavTemporetencaoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table8_128_792( true) ;
         }
         else
         {
            wb_table8_128_792( false) ;
         }
         return  ;
      }

      protected void wb_table8_128_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocumentoprevcoletadados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocumentoprevcoletadados_Internalname, "PREVISÃO PARA COLETA DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentoprevcoletadados, cmbavDocumentoprevcoletadados_Internalname, StringUtil.BoolToStr( AV15DocumentoPrevColetaDados), 1, cmbavDocumentoprevcoletadados_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocumentoprevcoletadados.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "", true, 0, "HLP_TratamentoWC.htm");
            cmbavDocumentoprevcoletadados.CurrentValue = StringUtil.BoolToStr( AV15DocumentoPrevColetaDados);
            AssignProp(sPrefix, false, cmbavDocumentoprevcoletadados_Internalname, "Values", (string)(cmbavDocumentoprevcoletadados.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPrevcoletadadosinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblPrevcoletadadosinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e12791_client"+"'", "", "TextBlock", 7, lblPrevcoletadadosinfo_Tooltiptext, lblPrevcoletadadosinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentobaselegalnorm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentobaselegalnorm_Internalname, "PREVISÃO LEGAL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentobaselegalnorm_Internalname, AV16DocumentoBaseLegalNorm, StringUtil.RTrim( context.localUtil.Format( AV16DocumentoBaseLegalNorm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentobaselegalnorm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentobaselegalnorm_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBaselegalnorminfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblBaselegalnorminfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e13791_client"+"'", "", "TextBlock", 7, lblBaselegalnorminfo_Tooltiptext, lblBaselegalnorminfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtbaselegalnorm_Internalname, lblTxtbaselegalnorm_Caption, "", "", lblTxtbaselegalnorm_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentobaselegalnormintext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentobaselegalnormintext_Internalname, "PREVISÃO REGULAMENTATÓRIA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentobaselegalnormintext_Internalname, AV17DocumentoBaseLegalNormIntExt, StringUtil.RTrim( context.localUtil.Format( AV17DocumentoBaseLegalNormIntExt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentobaselegalnormintext_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentobaselegalnormintext_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBaselegalnormintextinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblBaselegalnormintextinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e14791_client"+"'", "", "TextBlock", 7, lblBaselegalnormintextinfo_Tooltiptext, lblBaselegalnormintextinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtbaselegalnormext_Internalname, lblTxtbaselegalnormext_Caption, "", "", lblTxtbaselegalnormext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocumentodadosgrupovul_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocumentodadosgrupovul_Internalname, "POSSUI DADOS DE GRUPOS VULNERÁVEIS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocumentodadosgrupovul_Internalname, StringUtil.BoolToStr( AV18DocumentoDadosGrupoVul), "", "POSSUI DADOS DE GRUPOS VULNERÁVEIS", 1, chkavDocumentodadosgrupovul.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(178, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,178);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDadosgrupovulinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblDadosgrupovulinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e15791_client"+"'", "", "TextBlock", 7, lblDadosgrupovulinfo_Tooltiptext, lblDadosgrupovulinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocumentodadoscriancaadolesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocumentodadoscriancaadolesc_Internalname, "POSSUI DADOS DE CRIANÇA/ADOLESCENTE", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocumentodadoscriancaadolesc_Internalname, StringUtil.BoolToStr( AV19DocumentoDadosCriancaAdolesc), "", "POSSUI DADOS DE CRIANÇA/ADOLESCENTE", 1, chkavDocumentodadoscriancaadolesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(184, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,184);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDadoscriancaadolescinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblDadoscriancaadolescinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e16791_client"+"'", "", "TextBlock", 7, lblDadoscriancaadolescinfo_Tooltiptext, lblDadoscriancaadolescinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsetorinternoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_setorinternoid_Internalname, "SETOR(ES) INTERNO(S) ENVOLVIDO(S)", "", "", lblTextblockcombo_setorinternoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_setorinternoid.SetProperty("Caption", Combo_setorinternoid_Caption);
            ucCombo_setorinternoid.SetProperty("Cls", Combo_setorinternoid_Cls);
            ucCombo_setorinternoid.SetProperty("AllowMultipleSelection", Combo_setorinternoid_Allowmultipleselection);
            ucCombo_setorinternoid.SetProperty("IncludeOnlySelectedOption", Combo_setorinternoid_Includeonlyselectedoption);
            ucCombo_setorinternoid.SetProperty("MultipleValuesType", Combo_setorinternoid_Multiplevaluestype);
            ucCombo_setorinternoid.SetProperty("EmptyItemText", Combo_setorinternoid_Emptyitemtext);
            ucCombo_setorinternoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_setorinternoid.SetProperty("DropDownOptionsData", AV31SetorInternoId_Data);
            ucCombo_setorinternoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_setorinternoid_Internalname, sPrefix+"COMBO_SETORINTERNOIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table9_196_792( true) ;
         }
         else
         {
            wb_table9_196_792( false) ;
         }
         return  ;
      }

      protected void wb_table9_196_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcompartinternoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_compartinternoid_Internalname, "FORMA(S) DE COMPARTILHAMENTO INTERNO", "", "", lblTextblockcombo_compartinternoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_compartinternoid.SetProperty("Caption", Combo_compartinternoid_Caption);
            ucCombo_compartinternoid.SetProperty("Cls", Combo_compartinternoid_Cls);
            ucCombo_compartinternoid.SetProperty("AllowMultipleSelection", Combo_compartinternoid_Allowmultipleselection);
            ucCombo_compartinternoid.SetProperty("IncludeOnlySelectedOption", Combo_compartinternoid_Includeonlyselectedoption);
            ucCombo_compartinternoid.SetProperty("MultipleValuesType", Combo_compartinternoid_Multiplevaluestype);
            ucCombo_compartinternoid.SetProperty("EmptyItemText", Combo_compartinternoid_Emptyitemtext);
            ucCombo_compartinternoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_compartinternoid.SetProperty("DropDownOptionsData", AV32CompartInternoId_Data);
            ucCombo_compartinternoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_compartinternoid_Internalname, sPrefix+"COMBO_COMPARTINTERNOIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table10_211_792( true) ;
         }
         else
         {
            wb_table10_211_792( false) ;
         }
         return  ;
      }

      protected void wb_table10_211_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedenvolvidoscoletaid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_envolvidoscoletaid_Internalname, "ENVOLVIDO(S) NA COLETA", "", "", lblTextblockcombo_envolvidoscoletaid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_envolvidoscoletaid.SetProperty("Caption", Combo_envolvidoscoletaid_Caption);
            ucCombo_envolvidoscoletaid.SetProperty("Cls", Combo_envolvidoscoletaid_Cls);
            ucCombo_envolvidoscoletaid.SetProperty("AllowMultipleSelection", Combo_envolvidoscoletaid_Allowmultipleselection);
            ucCombo_envolvidoscoletaid.SetProperty("IncludeOnlySelectedOption", Combo_envolvidoscoletaid_Includeonlyselectedoption);
            ucCombo_envolvidoscoletaid.SetProperty("MultipleValuesType", Combo_envolvidoscoletaid_Multiplevaluestype);
            ucCombo_envolvidoscoletaid.SetProperty("EmptyItemText", Combo_envolvidoscoletaid_Emptyitemtext);
            ucCombo_envolvidoscoletaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_envolvidoscoletaid.SetProperty("DropDownOptionsData", AV33EnvolvidosColetaId_Data);
            ucCombo_envolvidoscoletaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_envolvidoscoletaid_Internalname, sPrefix+"COMBO_ENVOLVIDOSCOLETAIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table11_226_792( true) ;
         }
         else
         {
            wb_table11_226_792( false) ;
         }
         return  ;
      }

      protected void wb_table11_226_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmedidasegurancaid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_medidasegurancaid_Internalname, "MEDIDA(S) DE SEGURANÇA", "", "", lblTextblockcombo_medidasegurancaid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_medidasegurancaid.SetProperty("Caption", Combo_medidasegurancaid_Caption);
            ucCombo_medidasegurancaid.SetProperty("Cls", Combo_medidasegurancaid_Cls);
            ucCombo_medidasegurancaid.SetProperty("AllowMultipleSelection", Combo_medidasegurancaid_Allowmultipleselection);
            ucCombo_medidasegurancaid.SetProperty("IncludeOnlySelectedOption", Combo_medidasegurancaid_Includeonlyselectedoption);
            ucCombo_medidasegurancaid.SetProperty("EmptyItem", Combo_medidasegurancaid_Emptyitem);
            ucCombo_medidasegurancaid.SetProperty("MultipleValuesType", Combo_medidasegurancaid_Multiplevaluestype);
            ucCombo_medidasegurancaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_medidasegurancaid.SetProperty("DropDownOptionsData", AV88MedidaSegurancaId_Data);
            ucCombo_medidasegurancaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_medidasegurancaid_Internalname, sPrefix+"COMBO_MEDIDASEGURANCAIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table12_241_792( true) ;
         }
         else
         {
            wb_table12_241_792( false) ;
         }
         return  ;
      }

      protected void wb_table12_241_792e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentomedidasegurancadesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentomedidasegurancadesc_Internalname, "DESCRIÇÃO DA MEDIDA DE SEGURANÇA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocumentomedidasegurancadesc_Internalname, AV21DocumentoMedidaSegurancaDesc, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", 0, 1, edtavDocumentomedidasegurancadesc_Enabled, 1, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMedidasegurancadescinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblMedidasegurancadescinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e17791_client"+"'", "", "TextBlock", 7, lblMedidasegurancadescinfo_Tooltiptext, lblMedidasegurancadescinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtmedidasegurancadesc_Internalname, lblTxtmedidasegurancadesc_Caption, "", "", lblTxtmedidasegurancadesc_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS", "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "AttributeFL", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDocumentofluxotratdadosdesc.SetProperty("Width", Documentofluxotratdadosdesc_Width);
            ucDocumentofluxotratdadosdesc.SetProperty("Height", Documentofluxotratdadosdesc_Height);
            ucDocumentofluxotratdadosdesc.SetProperty("Attribute", AV22DocumentoFluxoTratDadosDesc);
            ucDocumentofluxotratdadosdesc.SetProperty("CaptionClass", Documentofluxotratdadosdesc_Captionclass);
            ucDocumentofluxotratdadosdesc.SetProperty("CaptionStyle", Documentofluxotratdadosdesc_Captionstyle);
            ucDocumentofluxotratdadosdesc.SetProperty("CaptionPosition", Documentofluxotratdadosdesc_Captionposition);
            ucDocumentofluxotratdadosdesc.Render(context, "fckeditor", Documentofluxotratdadosdesc_Internalname, sPrefix+"DOCUMENTOFLUXOTRATDADOSDESCContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFluxotratdadosdescinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblFluxotratdadosdescinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e18791_client"+"'", "", "TextBlock", 7, lblFluxotratdadosdescinfo_Tooltiptext, lblFluxotratdadosdescinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 hidden-sm hidden-md hidden-lg", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtfluxotratdados_Internalname, "0/10000", "", "", lblTxtfluxotratdados_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TratamentoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 282,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsalvar_Internalname, "", "SALVAR", bttBtnsalvar_Jsonclick, 5, "SALVAR", "", StyleString, ClassString, bttBtnsalvar_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSALVAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TratamentoWC.htm");
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

      protected void START792( )
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
               Form.Meta.addItem("description", "Aba de Tratamento para o cadastro de um Documento", 0) ;
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
               STRUP790( ) ;
            }
         }
      }

      protected void WS792( )
      {
         START792( ) ;
         EVT792( ) ;
      }

      protected void EVT792( )
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
                                 STRUP790( ) ;
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
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E20792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFERRAMENTACOLETAADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFerramentaColetaAdd' */
                                    E21792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOABRANGENCIAGEOGRAFICAADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAbrangenciaGeograficaAdd' */
                                    E22792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFREQUENCIATRATAMENTOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFrequenciaTratamentoAdd' */
                                    E23792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFONTERETENCAOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFonteRetencaoAdd' */
                                    E24792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSETORINTERNOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSetorInternoAdd' */
                                    E25792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCOMPARTINTERNOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCompartInternoAdd' */
                                    E26792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENVOLVIDOSCOLETAADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoEnvolvidosColetaAdd' */
                                    E27792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMEDIDASEGURANCAADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMedidaSegurancaAdd' */
                                    E28792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSALVAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSalvar' */
                                    E29792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOTIPODESCARTEADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoTipoDescarteAdd' */
                                    E30792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOTEMPORETENCAOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoTempoRetencaoAdd' */
                                    E31792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCATEGORIAADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCategoriaAdd' */
                                    E32792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOTIPODADOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoTipoDadoAdd' */
                                    E33792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E34792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
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
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDocumentofinalidadetratamento_Internalname;
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

      protected void WE792( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm792( ) ;
            }
         }
      }

      protected void PA792( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "tratamentowc.aspx")), "tratamentowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "tratamentowc.aspx")))) ;
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
               GX_FocusControl = edtavDocumentofinalidadetratamento_Internalname;
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
         if ( cmbavCategoriaid.ItemCount > 0 )
         {
            AV8CategoriaId = (int)(NumberUtil.Val( cmbavCategoriaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8CategoriaId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV8CategoriaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCategoriaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8CategoriaId), 8, 0));
            AssignProp(sPrefix, false, cmbavCategoriaid_Internalname, "Values", cmbavCategoriaid.ToJavascriptSource(), true);
         }
         if ( cmbavTipodadoid.ItemCount > 0 )
         {
            AV9TipoDadoId = (int)(NumberUtil.Val( cmbavTipodadoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9TipoDadoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV9TipoDadoId", StringUtil.LTrimStr( (decimal)(AV9TipoDadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipodadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9TipoDadoId), 8, 0));
            AssignProp(sPrefix, false, cmbavTipodadoid_Internalname, "Values", cmbavTipodadoid.ToJavascriptSource(), true);
         }
         if ( cmbavFerramentacoletaid.ItemCount > 0 )
         {
            AV10FerramentaColetaId = (int)(NumberUtil.Val( cmbavFerramentacoletaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10FerramentaColetaId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV10FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV10FerramentaColetaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFerramentacoletaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10FerramentaColetaId), 8, 0));
            AssignProp(sPrefix, false, cmbavFerramentacoletaid_Internalname, "Values", cmbavFerramentacoletaid.ToJavascriptSource(), true);
         }
         if ( cmbavAbrangenciageograficaid.ItemCount > 0 )
         {
            AV11AbrangenciaGeograficaId = (int)(NumberUtil.Val( cmbavAbrangenciageograficaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11AbrangenciaGeograficaId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV11AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAbrangenciageograficaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
            AssignProp(sPrefix, false, cmbavAbrangenciageograficaid_Internalname, "Values", cmbavAbrangenciageograficaid.ToJavascriptSource(), true);
         }
         if ( cmbavFrequenciatratamentoid.ItemCount > 0 )
         {
            AV12FrequenciaTratamentoId = (int)(NumberUtil.Val( cmbavFrequenciatratamentoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12FrequenciaTratamentoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV12FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFrequenciatratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
            AssignProp(sPrefix, false, cmbavFrequenciatratamentoid_Internalname, "Values", cmbavFrequenciatratamentoid.ToJavascriptSource(), true);
         }
         if ( cmbavTipodescarteid.ItemCount > 0 )
         {
            AV13TipoDescarteId = (int)(NumberUtil.Val( cmbavTipodescarteid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13TipoDescarteId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV13TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV13TipoDescarteId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipodescarteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13TipoDescarteId), 8, 0));
            AssignProp(sPrefix, false, cmbavTipodescarteid_Internalname, "Values", cmbavTipodescarteid.ToJavascriptSource(), true);
         }
         if ( cmbavTemporetencaoid.ItemCount > 0 )
         {
            AV14TempoRetencaoId = (int)(NumberUtil.Val( cmbavTemporetencaoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14TempoRetencaoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV14TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV14TempoRetencaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTemporetencaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14TempoRetencaoId), 8, 0));
            AssignProp(sPrefix, false, cmbavTemporetencaoid_Internalname, "Values", cmbavTemporetencaoid.ToJavascriptSource(), true);
         }
         if ( cmbavDocumentoprevcoletadados.ItemCount > 0 )
         {
            AV15DocumentoPrevColetaDados = StringUtil.StrToBool( cmbavDocumentoprevcoletadados.getValidValue(StringUtil.BoolToStr( AV15DocumentoPrevColetaDados)));
            AssignAttri(sPrefix, false, "AV15DocumentoPrevColetaDados", AV15DocumentoPrevColetaDados);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentoprevcoletadados.CurrentValue = StringUtil.BoolToStr( AV15DocumentoPrevColetaDados);
            AssignProp(sPrefix, false, cmbavDocumentoprevcoletadados_Internalname, "Values", cmbavDocumentoprevcoletadados.ToJavascriptSource(), true);
         }
         AV18DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( AV18DocumentoDadosGrupoVul));
         AssignAttri(sPrefix, false, "AV18DocumentoDadosGrupoVul", AV18DocumentoDadosGrupoVul);
         AV19DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV19DocumentoDadosCriancaAdolesc));
         AssignAttri(sPrefix, false, "AV19DocumentoDadosCriancaAdolesc", AV19DocumentoDadosCriancaAdolesc);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF792( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF792( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E20792 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E34792 ();
            WB790( ) ;
         }
      }

      protected void send_integrity_lvl_hashes792( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP790( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19792 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV26DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFONTERETENCAOID_DATA"), AV25FonteRetencaoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSETORINTERNOID_DATA"), AV31SetorInternoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOMPARTINTERNOID_DATA"), AV32CompartInternoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vENVOLVIDOSCOLETAID_DATA"), AV33EnvolvidosColetaId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMEDIDASEGURANCAID_DATA"), AV88MedidaSegurancaId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFONTERETENCAOID"), AV24FonteRetencaoId);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSETORINTERNOID"), AV28SetorInternoId);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOMPARTINTERNOID"), AV29CompartInternoId);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vENVOLVIDOSCOLETAID"), AV30EnvolvidosColetaId);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMEDIDASEGURANCAID"), AV20MedidaSegurancaId);
            /* Read saved values. */
            AV22DocumentoFluxoTratDadosDesc = cgiGet( sPrefix+"vDOCUMENTOFLUXOTRATDADOSDESC");
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV36DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV36DocumentoId"), ",", "."));
            Combo_fonteretencaoid_Cls = cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Cls");
            Combo_fonteretencaoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_set");
            Combo_fonteretencaoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Enabled"));
            Combo_fonteretencaoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Allowmultipleselection"));
            Combo_fonteretencaoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Includeonlyselectedoption"));
            Combo_fonteretencaoid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Multiplevaluestype");
            Combo_fonteretencaoid_Emptyitemtext = cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Emptyitemtext");
            Combo_setorinternoid_Cls = cgiGet( sPrefix+"COMBO_SETORINTERNOID_Cls");
            Combo_setorinternoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_set");
            Combo_setorinternoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_SETORINTERNOID_Enabled"));
            Combo_setorinternoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_SETORINTERNOID_Allowmultipleselection"));
            Combo_setorinternoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_SETORINTERNOID_Includeonlyselectedoption"));
            Combo_setorinternoid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_SETORINTERNOID_Multiplevaluestype");
            Combo_setorinternoid_Emptyitemtext = cgiGet( sPrefix+"COMBO_SETORINTERNOID_Emptyitemtext");
            Combo_compartinternoid_Cls = cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Cls");
            Combo_compartinternoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_set");
            Combo_compartinternoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Enabled"));
            Combo_compartinternoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Allowmultipleselection"));
            Combo_compartinternoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Includeonlyselectedoption"));
            Combo_compartinternoid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Multiplevaluestype");
            Combo_compartinternoid_Emptyitemtext = cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Emptyitemtext");
            Combo_envolvidoscoletaid_Cls = cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Cls");
            Combo_envolvidoscoletaid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_set");
            Combo_envolvidoscoletaid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Enabled"));
            Combo_envolvidoscoletaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Allowmultipleselection"));
            Combo_envolvidoscoletaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Includeonlyselectedoption"));
            Combo_envolvidoscoletaid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Multiplevaluestype");
            Combo_envolvidoscoletaid_Emptyitemtext = cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Emptyitemtext");
            Combo_medidasegurancaid_Cls = cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Cls");
            Combo_medidasegurancaid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_set");
            Combo_medidasegurancaid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Enabled"));
            Combo_medidasegurancaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Allowmultipleselection"));
            Combo_medidasegurancaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Includeonlyselectedoption"));
            Combo_medidasegurancaid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Emptyitem"));
            Combo_medidasegurancaid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Multiplevaluestype");
            Documentofluxotratdadosdesc_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Enabled"));
            Documentofluxotratdadosdesc_Width = cgiGet( sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Width");
            Documentofluxotratdadosdesc_Height = cgiGet( sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Height");
            Documentofluxotratdadosdesc_Captionclass = cgiGet( sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Captionclass");
            Documentofluxotratdadosdesc_Captionstyle = cgiGet( sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Captionstyle");
            Documentofluxotratdadosdesc_Captionposition = cgiGet( sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC_Captionposition");
            Combo_fonteretencaoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_get");
            Combo_setorinternoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_get");
            Combo_compartinternoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_get");
            Combo_envolvidoscoletaid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_get");
            Combo_medidasegurancaid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_get");
            Combo_compartinternoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_COMPARTINTERNOID_Selectedvalue_get");
            Combo_envolvidoscoletaid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_ENVOLVIDOSCOLETAID_Selectedvalue_get");
            Combo_medidasegurancaid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_MEDIDASEGURANCAID_Selectedvalue_get");
            Combo_fonteretencaoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_FONTERETENCAOID_Selectedvalue_get");
            Combo_setorinternoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SETORINTERNOID_Selectedvalue_get");
            /* Read variables values. */
            AV7DocumentoFinalidadeTratamento = cgiGet( edtavDocumentofinalidadetratamento_Internalname);
            AssignAttri(sPrefix, false, "AV7DocumentoFinalidadeTratamento", AV7DocumentoFinalidadeTratamento);
            cmbavCategoriaid.CurrentValue = cgiGet( cmbavCategoriaid_Internalname);
            AV8CategoriaId = (int)(NumberUtil.Val( cgiGet( cmbavCategoriaid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV8CategoriaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaId), 8, 0));
            cmbavTipodadoid.CurrentValue = cgiGet( cmbavTipodadoid_Internalname);
            AV9TipoDadoId = (int)(NumberUtil.Val( cgiGet( cmbavTipodadoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV9TipoDadoId", StringUtil.LTrimStr( (decimal)(AV9TipoDadoId), 8, 0));
            cmbavFerramentacoletaid.CurrentValue = cgiGet( cmbavFerramentacoletaid_Internalname);
            AV10FerramentaColetaId = (int)(NumberUtil.Val( cgiGet( cmbavFerramentacoletaid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV10FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV10FerramentaColetaId), 8, 0));
            cmbavAbrangenciageograficaid.CurrentValue = cgiGet( cmbavAbrangenciageograficaid_Internalname);
            AV11AbrangenciaGeograficaId = (int)(NumberUtil.Val( cgiGet( cmbavAbrangenciageograficaid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV11AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
            cmbavFrequenciatratamentoid.CurrentValue = cgiGet( cmbavFrequenciatratamentoid_Internalname);
            AV12FrequenciaTratamentoId = (int)(NumberUtil.Val( cgiGet( cmbavFrequenciatratamentoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV12FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
            cmbavTipodescarteid.CurrentValue = cgiGet( cmbavTipodescarteid_Internalname);
            AV13TipoDescarteId = (int)(NumberUtil.Val( cgiGet( cmbavTipodescarteid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV13TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV13TipoDescarteId), 8, 0));
            cmbavTemporetencaoid.CurrentValue = cgiGet( cmbavTemporetencaoid_Internalname);
            AV14TempoRetencaoId = (int)(NumberUtil.Val( cgiGet( cmbavTemporetencaoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV14TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV14TempoRetencaoId), 8, 0));
            cmbavDocumentoprevcoletadados.CurrentValue = cgiGet( cmbavDocumentoprevcoletadados_Internalname);
            AV15DocumentoPrevColetaDados = StringUtil.StrToBool( cgiGet( cmbavDocumentoprevcoletadados_Internalname));
            AssignAttri(sPrefix, false, "AV15DocumentoPrevColetaDados", AV15DocumentoPrevColetaDados);
            AV16DocumentoBaseLegalNorm = cgiGet( edtavDocumentobaselegalnorm_Internalname);
            AssignAttri(sPrefix, false, "AV16DocumentoBaseLegalNorm", AV16DocumentoBaseLegalNorm);
            AV17DocumentoBaseLegalNormIntExt = cgiGet( edtavDocumentobaselegalnormintext_Internalname);
            AssignAttri(sPrefix, false, "AV17DocumentoBaseLegalNormIntExt", AV17DocumentoBaseLegalNormIntExt);
            AV18DocumentoDadosGrupoVul = StringUtil.StrToBool( cgiGet( chkavDocumentodadosgrupovul_Internalname));
            AssignAttri(sPrefix, false, "AV18DocumentoDadosGrupoVul", AV18DocumentoDadosGrupoVul);
            AV19DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( cgiGet( chkavDocumentodadoscriancaadolesc_Internalname));
            AssignAttri(sPrefix, false, "AV19DocumentoDadosCriancaAdolesc", AV19DocumentoDadosCriancaAdolesc);
            AV21DocumentoMedidaSegurancaDesc = cgiGet( edtavDocumentomedidasegurancadesc_Internalname);
            AssignAttri(sPrefix, false, "AV21DocumentoMedidaSegurancaDesc", AV21DocumentoMedidaSegurancaDesc);
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
         E19792 ();
         if (returnInSub) return;
      }

      protected void E19792( )
      {
         /* Start Routine */
         returnInSub = false;
         AV92FCKEditorMenuItem.gxTpr_Id = "upload";
         AV92FCKEditorMenuItem.gxTpr_Description = "Upload";
         AV92FCKEditorMenuItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "7c63c2b9-483e-4035-b512-febf9186a274", "", context.GetTheme( ))));
         AV92FCKEditorMenuItem.gxTpr_Objectinterface = 1;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "fileuploader.aspx"+UrlEncode(StringUtil.RTrim(""));
         AV92FCKEditorMenuItem.gxTpr_Link = formatLink("fileuploader.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV91FCKEditorMenu.Add(AV92FCKEditorMenuItem, 0);
         this.executeUsercontrolMethod(sPrefix, false, "DOCUMENTOFLUXOTRATDADOSDESCContainer", "SetMenu", "", new Object[] {(GXBaseCollection<SdtFckEditorMenu_FckEditorMenuItem>)AV91FCKEditorMenu});
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV26DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV26DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         /* Execute user subroutine: 'LOADCOMBOFONTERETENCAOID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSETORINTERNOID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOMPARTINTERNOID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOENVOLVIDOSCOLETAID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMEDIDASEGURANCAID' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CATEGORIACOMBOCARREGA' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'TIPODADOCOMBOCARREGA' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'FERRAMENTACOLETACOMBOCARREGA' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ABRANGENCIAGEOGRAFICACOMBOCARREGA' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'FREQUENCIATRATAMENTOCOMBOCARREGA' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'TIPODESCARTECOMBOCARREGA' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'TEMPORETENCAOCOMBOCARREGA' */
         S222 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV34Documento.Load(AV36DocumentoId);
            AV11AbrangenciaGeograficaId = AV34Documento.gxTpr_Abrangenciageograficaid;
            AssignAttri(sPrefix, false, "AV11AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
            AV8CategoriaId = AV34Documento.gxTpr_Categoriaid;
            AssignAttri(sPrefix, false, "AV8CategoriaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaId), 8, 0));
            AV16DocumentoBaseLegalNorm = AV34Documento.gxTpr_Documentobaselegalnorm;
            AssignAttri(sPrefix, false, "AV16DocumentoBaseLegalNorm", AV16DocumentoBaseLegalNorm);
            AV17DocumentoBaseLegalNormIntExt = AV34Documento.gxTpr_Documentobaselegalnormintext;
            AssignAttri(sPrefix, false, "AV17DocumentoBaseLegalNormIntExt", AV17DocumentoBaseLegalNormIntExt);
            AV19DocumentoDadosCriancaAdolesc = AV34Documento.gxTpr_Documentodadoscriancaadolesc;
            AssignAttri(sPrefix, false, "AV19DocumentoDadosCriancaAdolesc", AV19DocumentoDadosCriancaAdolesc);
            AV18DocumentoDadosGrupoVul = AV34Documento.gxTpr_Documentodadosgrupovul;
            AssignAttri(sPrefix, false, "AV18DocumentoDadosGrupoVul", AV18DocumentoDadosGrupoVul);
            AV7DocumentoFinalidadeTratamento = AV34Documento.gxTpr_Documentofinalidadetratamento;
            AssignAttri(sPrefix, false, "AV7DocumentoFinalidadeTratamento", AV7DocumentoFinalidadeTratamento);
            AV22DocumentoFluxoTratDadosDesc = AV34Documento.gxTpr_Documentofluxotratdadosdesc;
            AssignAttri(sPrefix, false, "AV22DocumentoFluxoTratDadosDesc", AV22DocumentoFluxoTratDadosDesc);
            AV21DocumentoMedidaSegurancaDesc = AV34Documento.gxTpr_Documentomedidasegurancadesc;
            AssignAttri(sPrefix, false, "AV21DocumentoMedidaSegurancaDesc", AV21DocumentoMedidaSegurancaDesc);
            AV15DocumentoPrevColetaDados = AV34Documento.gxTpr_Documentoprevcoletadados;
            AssignAttri(sPrefix, false, "AV15DocumentoPrevColetaDados", AV15DocumentoPrevColetaDados);
            AV10FerramentaColetaId = AV34Documento.gxTpr_Ferramentacoletaid;
            AssignAttri(sPrefix, false, "AV10FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV10FerramentaColetaId), 8, 0));
            AV12FrequenciaTratamentoId = AV34Documento.gxTpr_Frequenciatratamentoid;
            AssignAttri(sPrefix, false, "AV12FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
            AV14TempoRetencaoId = AV34Documento.gxTpr_Temporetencaoid;
            AssignAttri(sPrefix, false, "AV14TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV14TempoRetencaoId), 8, 0));
            AV9TipoDadoId = AV34Documento.gxTpr_Tipodadoid;
            AssignAttri(sPrefix, false, "AV9TipoDadoId", StringUtil.LTrimStr( (decimal)(AV9TipoDadoId), 8, 0));
            AV13TipoDescarteId = AV34Documento.gxTpr_Tipodescarteid;
            AssignAttri(sPrefix, false, "AV13TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV13TipoDescarteId), 8, 0));
            /* Using cursor H00792 */
            pr_default.execute(0, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A75DocumentoId = H00792_A75DocumentoId[0];
               A63FonteRetencaoId = H00792_A63FonteRetencaoId[0];
               AV46FonteRetencaoId_Col.Add(A63FonteRetencaoId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            Combo_fonteretencaoid_Selectedvalue_set = AV46FonteRetencaoId_Col.ToJSonString(false);
            ucCombo_fonteretencaoid.SendProperty(context, sPrefix, false, Combo_fonteretencaoid_Internalname, "SelectedValue_set", Combo_fonteretencaoid_Selectedvalue_set);
            AV46FonteRetencaoId_Col.Clear();
            /* Using cursor H00793 */
            pr_default.execute(1, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A75DocumentoId = H00793_A75DocumentoId[0];
               A60SetorInternoId = H00793_A60SetorInternoId[0];
               AV48SetorInternoId_Col.Add(A60SetorInternoId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            Combo_setorinternoid_Selectedvalue_set = AV48SetorInternoId_Col.ToJSonString(false);
            ucCombo_setorinternoid.SendProperty(context, sPrefix, false, Combo_setorinternoid_Internalname, "SelectedValue_set", Combo_setorinternoid_Selectedvalue_set);
            AV48SetorInternoId_Col.Clear();
            /* Using cursor H00794 */
            pr_default.execute(2, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A75DocumentoId = H00794_A75DocumentoId[0];
               A57CompartInternoId = H00794_A57CompartInternoId[0];
               AV47CompartInternoId_Col.Add(A57CompartInternoId, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            Combo_compartinternoid_Selectedvalue_set = AV47CompartInternoId_Col.ToJSonString(false);
            ucCombo_compartinternoid.SendProperty(context, sPrefix, false, Combo_compartinternoid_Internalname, "SelectedValue_set", Combo_compartinternoid_Selectedvalue_set);
            AV47CompartInternoId_Col.Clear();
            /* Using cursor H00795 */
            pr_default.execute(3, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A75DocumentoId = H00795_A75DocumentoId[0];
               A54EnvolvidosColetaId = H00795_A54EnvolvidosColetaId[0];
               AV49EnvolvidosColetaId_Col.Add(A54EnvolvidosColetaId, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            Combo_envolvidoscoletaid_Selectedvalue_set = AV49EnvolvidosColetaId_Col.ToJSonString(false);
            ucCombo_envolvidoscoletaid.SendProperty(context, sPrefix, false, Combo_envolvidoscoletaid_Internalname, "SelectedValue_set", Combo_envolvidoscoletaid_Selectedvalue_set);
            AV49EnvolvidosColetaId_Col.Clear();
            /* Using cursor H00796 */
            pr_default.execute(4, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A75DocumentoId = H00796_A75DocumentoId[0];
               A51MedidaSegurancaId = H00796_A51MedidaSegurancaId[0];
               AV89MedidaSegurancaId_Col.Add(A51MedidaSegurancaId, 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            Combo_medidasegurancaid_Selectedvalue_set = AV89MedidaSegurancaId_Col.ToJSonString(false);
            ucCombo_medidasegurancaid.SendProperty(context, sPrefix, false, Combo_medidasegurancaid_Internalname, "SelectedValue_set", Combo_medidasegurancaid_Selectedvalue_set);
            AV89MedidaSegurancaId_Col.Clear();
            cmbavAbrangenciageograficaid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavAbrangenciageograficaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAbrangenciageograficaid.Enabled), 5, 0), true);
            cmbavCategoriaid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavCategoriaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCategoriaid.Enabled), 5, 0), true);
            edtavDocumentobaselegalnorm_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentobaselegalnorm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentobaselegalnorm_Enabled), 5, 0), true);
            edtavDocumentobaselegalnormintext_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentobaselegalnormintext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentobaselegalnormintext_Enabled), 5, 0), true);
            chkavDocumentodadoscriancaadolesc.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocumentodadoscriancaadolesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocumentodadoscriancaadolesc.Enabled), 5, 0), true);
            chkavDocumentodadosgrupovul.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocumentodadosgrupovul_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocumentodadosgrupovul.Enabled), 5, 0), true);
            edtavDocumentofinalidadetratamento_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentofinalidadetratamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentofinalidadetratamento_Enabled), 5, 0), true);
            edtavDocumentomedidasegurancadesc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentomedidasegurancadesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentomedidasegurancadesc_Enabled), 5, 0), true);
            cmbavDocumentoprevcoletadados.Enabled = 0;
            AssignProp(sPrefix, false, cmbavDocumentoprevcoletadados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocumentoprevcoletadados.Enabled), 5, 0), true);
            cmbavFerramentacoletaid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFerramentacoletaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFerramentacoletaid.Enabled), 5, 0), true);
            cmbavFrequenciatratamentoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFrequenciatratamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFrequenciatratamentoid.Enabled), 5, 0), true);
            cmbavTemporetencaoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTemporetencaoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTemporetencaoid.Enabled), 5, 0), true);
            cmbavTipodadoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTipodadoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTipodadoid.Enabled), 5, 0), true);
            cmbavTipodescarteid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTipodescarteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTipodescarteid.Enabled), 5, 0), true);
            Combo_fonteretencaoid_Enabled = false;
            ucCombo_fonteretencaoid.SendProperty(context, sPrefix, false, Combo_fonteretencaoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_fonteretencaoid_Enabled));
            Combo_setorinternoid_Enabled = false;
            ucCombo_setorinternoid.SendProperty(context, sPrefix, false, Combo_setorinternoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_setorinternoid_Enabled));
            Combo_compartinternoid_Enabled = false;
            ucCombo_compartinternoid.SendProperty(context, sPrefix, false, Combo_compartinternoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_compartinternoid_Enabled));
            Combo_envolvidoscoletaid_Enabled = false;
            ucCombo_envolvidoscoletaid.SendProperty(context, sPrefix, false, Combo_envolvidoscoletaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_envolvidoscoletaid_Enabled));
            Combo_medidasegurancaid_Enabled = false;
            ucCombo_medidasegurancaid.SendProperty(context, sPrefix, false, Combo_medidasegurancaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_medidasegurancaid_Enabled));
            bttBtnsalvar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsalvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsalvar_Visible), 5, 0), true);
            lblFinalidadetratamentoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblFinalidadetratamentoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFinalidadetratamentoinfo_Visible), 5, 0), true);
            lblCategoriainfo_Visible = 0;
            AssignProp(sPrefix, false, lblCategoriainfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCategoriainfo_Visible), 5, 0), true);
            lblCategoriaadd_Visible = 0;
            AssignProp(sPrefix, false, lblCategoriaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCategoriaadd_Visible), 5, 0), true);
            lblTipodadoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblTipodadoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipodadoinfo_Visible), 5, 0), true);
            lblTipodadoadd_Visible = 0;
            AssignProp(sPrefix, false, lblTipodadoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipodadoadd_Visible), 5, 0), true);
            lblFerramentacoletainfo_Visible = 0;
            AssignProp(sPrefix, false, lblFerramentacoletainfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFerramentacoletainfo_Visible), 5, 0), true);
            lblFerramentacoletaadd_Visible = 0;
            AssignProp(sPrefix, false, lblFerramentacoletaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFerramentacoletaadd_Visible), 5, 0), true);
            lblAbrangenciageograficainfo_Visible = 0;
            AssignProp(sPrefix, false, lblAbrangenciageograficainfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblAbrangenciageograficainfo_Visible), 5, 0), true);
            lblAbrangenciageograficaadd_Visible = 0;
            AssignProp(sPrefix, false, lblAbrangenciageograficaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblAbrangenciageograficaadd_Visible), 5, 0), true);
            lblFrequenciatratamentoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblFrequenciatratamentoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFrequenciatratamentoinfo_Visible), 5, 0), true);
            lblFrequenciatratamentoadd_Visible = 0;
            AssignProp(sPrefix, false, lblFrequenciatratamentoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFrequenciatratamentoadd_Visible), 5, 0), true);
            lblFonteretencaoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblFonteretencaoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFonteretencaoinfo_Visible), 5, 0), true);
            lblFonteretencaoadd_Visible = 0;
            AssignProp(sPrefix, false, lblFonteretencaoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFonteretencaoadd_Visible), 5, 0), true);
            lblTipodescarteinfo_Visible = 0;
            AssignProp(sPrefix, false, lblTipodescarteinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipodescarteinfo_Visible), 5, 0), true);
            lblTipodescarteadd_Visible = 0;
            AssignProp(sPrefix, false, lblTipodescarteadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipodescarteadd_Visible), 5, 0), true);
            lblTemporetencaoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblTemporetencaoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTemporetencaoinfo_Visible), 5, 0), true);
            lblTemporetencaoadd_Visible = 0;
            AssignProp(sPrefix, false, lblTemporetencaoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTemporetencaoadd_Visible), 5, 0), true);
            lblPrevcoletadadosinfo_Visible = 0;
            AssignProp(sPrefix, false, lblPrevcoletadadosinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPrevcoletadadosinfo_Visible), 5, 0), true);
            lblBaselegalnorminfo_Visible = 0;
            AssignProp(sPrefix, false, lblBaselegalnorminfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblBaselegalnorminfo_Visible), 5, 0), true);
            lblBaselegalnormintextinfo_Visible = 0;
            AssignProp(sPrefix, false, lblBaselegalnormintextinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblBaselegalnormintextinfo_Visible), 5, 0), true);
            lblDadosgrupovulinfo_Visible = 0;
            AssignProp(sPrefix, false, lblDadosgrupovulinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblDadosgrupovulinfo_Visible), 5, 0), true);
            lblDadoscriancaadolescinfo_Visible = 0;
            AssignProp(sPrefix, false, lblDadoscriancaadolescinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblDadoscriancaadolescinfo_Visible), 5, 0), true);
            lblSetorinternoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblSetorinternoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSetorinternoinfo_Visible), 5, 0), true);
            lblSetorinternoadd_Visible = 0;
            AssignProp(sPrefix, false, lblSetorinternoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSetorinternoadd_Visible), 5, 0), true);
            lblCompartinternoinfo_Visible = 0;
            AssignProp(sPrefix, false, lblCompartinternoinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCompartinternoinfo_Visible), 5, 0), true);
            lblCompartinternoadd_Visible = 0;
            AssignProp(sPrefix, false, lblCompartinternoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCompartinternoadd_Visible), 5, 0), true);
            lblEnvolvidoscoletainfo_Visible = 0;
            AssignProp(sPrefix, false, lblEnvolvidoscoletainfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblEnvolvidoscoletainfo_Visible), 5, 0), true);
            lblEnvolvidoscoletaadd_Visible = 0;
            AssignProp(sPrefix, false, lblEnvolvidoscoletaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblEnvolvidoscoletaadd_Visible), 5, 0), true);
            lblMedidasegurancainfo_Visible = 0;
            AssignProp(sPrefix, false, lblMedidasegurancainfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblMedidasegurancainfo_Visible), 5, 0), true);
            lblMedidasegurancaadd_Visible = 0;
            AssignProp(sPrefix, false, lblMedidasegurancaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblMedidasegurancaadd_Visible), 5, 0), true);
            lblMedidasegurancadescinfo_Visible = 0;
            AssignProp(sPrefix, false, lblMedidasegurancadescinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblMedidasegurancadescinfo_Visible), 5, 0), true);
            lblFluxotratdadosdescinfo_Visible = 0;
            AssignProp(sPrefix, false, lblFluxotratdadosdescinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFluxotratdadosdescinfo_Visible), 5, 0), true);
         }
         AV34Documento.Load(AV36DocumentoId);
         AV11AbrangenciaGeograficaId = AV34Documento.gxTpr_Abrangenciageograficaid;
         AssignAttri(sPrefix, false, "AV11AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
         AV8CategoriaId = AV34Documento.gxTpr_Categoriaid;
         AssignAttri(sPrefix, false, "AV8CategoriaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaId), 8, 0));
         AV16DocumentoBaseLegalNorm = AV34Documento.gxTpr_Documentobaselegalnorm;
         AssignAttri(sPrefix, false, "AV16DocumentoBaseLegalNorm", AV16DocumentoBaseLegalNorm);
         AV17DocumentoBaseLegalNormIntExt = AV34Documento.gxTpr_Documentobaselegalnormintext;
         AssignAttri(sPrefix, false, "AV17DocumentoBaseLegalNormIntExt", AV17DocumentoBaseLegalNormIntExt);
         AV19DocumentoDadosCriancaAdolesc = AV34Documento.gxTpr_Documentodadoscriancaadolesc;
         AssignAttri(sPrefix, false, "AV19DocumentoDadosCriancaAdolesc", AV19DocumentoDadosCriancaAdolesc);
         AV18DocumentoDadosGrupoVul = AV34Documento.gxTpr_Documentodadosgrupovul;
         AssignAttri(sPrefix, false, "AV18DocumentoDadosGrupoVul", AV18DocumentoDadosGrupoVul);
         AV7DocumentoFinalidadeTratamento = AV34Documento.gxTpr_Documentofinalidadetratamento;
         AssignAttri(sPrefix, false, "AV7DocumentoFinalidadeTratamento", AV7DocumentoFinalidadeTratamento);
         AV22DocumentoFluxoTratDadosDesc = AV34Documento.gxTpr_Documentofluxotratdadosdesc;
         AssignAttri(sPrefix, false, "AV22DocumentoFluxoTratDadosDesc", AV22DocumentoFluxoTratDadosDesc);
         AV21DocumentoMedidaSegurancaDesc = AV34Documento.gxTpr_Documentomedidasegurancadesc;
         AssignAttri(sPrefix, false, "AV21DocumentoMedidaSegurancaDesc", AV21DocumentoMedidaSegurancaDesc);
         AV15DocumentoPrevColetaDados = AV34Documento.gxTpr_Documentoprevcoletadados;
         AssignAttri(sPrefix, false, "AV15DocumentoPrevColetaDados", AV15DocumentoPrevColetaDados);
         AV10FerramentaColetaId = AV34Documento.gxTpr_Ferramentacoletaid;
         AssignAttri(sPrefix, false, "AV10FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV10FerramentaColetaId), 8, 0));
         AV12FrequenciaTratamentoId = AV34Documento.gxTpr_Frequenciatratamentoid;
         AssignAttri(sPrefix, false, "AV12FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
         AV14TempoRetencaoId = AV34Documento.gxTpr_Temporetencaoid;
         AssignAttri(sPrefix, false, "AV14TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV14TempoRetencaoId), 8, 0));
         AV9TipoDadoId = AV34Documento.gxTpr_Tipodadoid;
         AssignAttri(sPrefix, false, "AV9TipoDadoId", StringUtil.LTrimStr( (decimal)(AV9TipoDadoId), 8, 0));
         AV13TipoDescarteId = AV34Documento.gxTpr_Tipodescarteid;
         AssignAttri(sPrefix, false, "AV13TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV13TipoDescarteId), 8, 0));
         if ( AV15DocumentoPrevColetaDados )
         {
            edtavDocumentobaselegalnorm_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocumentobaselegalnorm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentobaselegalnorm_Enabled), 5, 0), true);
            edtavDocumentobaselegalnormintext_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocumentobaselegalnormintext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentobaselegalnormintext_Enabled), 5, 0), true);
         }
         else
         {
            AV16DocumentoBaseLegalNorm = "";
            AssignAttri(sPrefix, false, "AV16DocumentoBaseLegalNorm", AV16DocumentoBaseLegalNorm);
            AV17DocumentoBaseLegalNormIntExt = "";
            AssignAttri(sPrefix, false, "AV17DocumentoBaseLegalNormIntExt", AV17DocumentoBaseLegalNormIntExt);
            edtavDocumentobaselegalnorm_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentobaselegalnorm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentobaselegalnorm_Enabled), 5, 0), true);
            edtavDocumentobaselegalnormintext_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocumentobaselegalnormintext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentobaselegalnormintext_Enabled), 5, 0), true);
         }
         /* Using cursor H00797 */
         pr_default.execute(5, new Object[] {AV36DocumentoId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A75DocumentoId = H00797_A75DocumentoId[0];
            A63FonteRetencaoId = H00797_A63FonteRetencaoId[0];
            AV46FonteRetencaoId_Col.Add(A63FonteRetencaoId, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_fonteretencaoid_Selectedvalue_set = AV46FonteRetencaoId_Col.ToJSonString(false);
         ucCombo_fonteretencaoid.SendProperty(context, sPrefix, false, Combo_fonteretencaoid_Internalname, "SelectedValue_set", Combo_fonteretencaoid_Selectedvalue_set);
         AV46FonteRetencaoId_Col.Clear();
         /* Using cursor H00798 */
         pr_default.execute(6, new Object[] {AV36DocumentoId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A75DocumentoId = H00798_A75DocumentoId[0];
            A60SetorInternoId = H00798_A60SetorInternoId[0];
            AV48SetorInternoId_Col.Add(A60SetorInternoId, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         Combo_setorinternoid_Selectedvalue_set = AV48SetorInternoId_Col.ToJSonString(false);
         ucCombo_setorinternoid.SendProperty(context, sPrefix, false, Combo_setorinternoid_Internalname, "SelectedValue_set", Combo_setorinternoid_Selectedvalue_set);
         AV48SetorInternoId_Col.Clear();
         /* Using cursor H00799 */
         pr_default.execute(7, new Object[] {AV36DocumentoId});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A75DocumentoId = H00799_A75DocumentoId[0];
            A57CompartInternoId = H00799_A57CompartInternoId[0];
            AV47CompartInternoId_Col.Add(A57CompartInternoId, 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         Combo_compartinternoid_Selectedvalue_set = AV47CompartInternoId_Col.ToJSonString(false);
         ucCombo_compartinternoid.SendProperty(context, sPrefix, false, Combo_compartinternoid_Internalname, "SelectedValue_set", Combo_compartinternoid_Selectedvalue_set);
         AV47CompartInternoId_Col.Clear();
         /* Using cursor H007910 */
         pr_default.execute(8, new Object[] {AV36DocumentoId});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A75DocumentoId = H007910_A75DocumentoId[0];
            A54EnvolvidosColetaId = H007910_A54EnvolvidosColetaId[0];
            AV49EnvolvidosColetaId_Col.Add(A54EnvolvidosColetaId, 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         Combo_envolvidoscoletaid_Selectedvalue_set = AV49EnvolvidosColetaId_Col.ToJSonString(false);
         ucCombo_envolvidoscoletaid.SendProperty(context, sPrefix, false, Combo_envolvidoscoletaid_Internalname, "SelectedValue_set", Combo_envolvidoscoletaid_Selectedvalue_set);
         AV49EnvolvidosColetaId_Col.Clear();
         /* Using cursor H007911 */
         pr_default.execute(9, new Object[] {AV36DocumentoId});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A75DocumentoId = H007911_A75DocumentoId[0];
            A51MedidaSegurancaId = H007911_A51MedidaSegurancaId[0];
            AV89MedidaSegurancaId_Col.Add(A51MedidaSegurancaId, 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         Combo_medidasegurancaid_Selectedvalue_set = AV89MedidaSegurancaId_Col.ToJSonString(false);
         ucCombo_medidasegurancaid.SendProperty(context, sPrefix, false, Combo_medidasegurancaid_Internalname, "SelectedValue_set", Combo_medidasegurancaid_Selectedvalue_set);
         AV89MedidaSegurancaId_Col.Clear();
         /* Using cursor H007912 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            A135CampoId = H007912_A135CampoId[0];
            A139TooltipTelaId = H007912_A139TooltipTelaId[0];
            A140TooltipTelaNome = H007912_A140TooltipTelaNome[0];
            A136CampoNome = H007912_A136CampoNome[0];
            A115TooltipDescricao = H007912_A115TooltipDescricao[0];
            A136CampoNome = H007912_A136CampoNome[0];
            A140TooltipTelaNome = H007912_A140TooltipTelaNome[0];
            if ( StringUtil.StrCmp(A136CampoNome, "FINALIDADE DO TRATAMENTO DE DADOS") == 0 )
            {
               lblFinalidadetratamentoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblFinalidadetratamentoinfo_Internalname, "Tooltiptext", lblFinalidadetratamentoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "CATEGORIA") == 0 )
            {
               lblCategoriainfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblCategoriainfo_Internalname, "Tooltiptext", lblCategoriainfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "TIPO DO DADO") == 0 )
            {
               lblTipodadoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblTipodadoinfo_Internalname, "Tooltiptext", lblTipodadoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "FERRAMENTA DE COLETA DE DADOS") == 0 )
            {
               lblFerramentacoletainfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblFerramentacoletainfo_Internalname, "Tooltiptext", lblFerramentacoletainfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "ABRANGÊNCIA GEOGRÁFICA") == 0 )
            {
               lblAbrangenciageograficainfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblAbrangenciageograficainfo_Internalname, "Tooltiptext", lblAbrangenciageograficainfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "FREQUÊNCIA DE TRATAMENTO DE DADOS") == 0 )
            {
               lblFrequenciatratamentoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblFrequenciatratamentoinfo_Internalname, "Tooltiptext", lblFrequenciatratamentoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "FONTE DE RETENÇÃO/ARMAZENAMENTO") == 0 )
            {
               lblFonteretencaoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblFonteretencaoinfo_Internalname, "Tooltiptext", lblFonteretencaoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "TIPO DE DESCARTE") == 0 )
            {
               lblTipodescarteinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblTipodescarteinfo_Internalname, "Tooltiptext", lblTipodescarteinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "TEMPO DE GUARDA/RETENÇÃO") == 0 )
            {
               lblTemporetencaoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblTemporetencaoinfo_Internalname, "Tooltiptext", lblTemporetencaoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "PREVISÃO PARA COLETA DE DADOS") == 0 )
            {
               lblPrevcoletadadosinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblPrevcoletadadosinfo_Internalname, "Tooltiptext", lblPrevcoletadadosinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "BASE LEGAL - NORMATIVO") == 0 )
            {
               lblBaselegalnorminfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblBaselegalnorminfo_Internalname, "Tooltiptext", lblBaselegalnorminfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "BASE LEGAL - NORMATIVO (INTERO E EXTERNO)") == 0 )
            {
               lblBaselegalnormintextinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblBaselegalnormintextinfo_Internalname, "Tooltiptext", lblBaselegalnormintextinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "DADOS DE GRUPOS VULNERÁVEIS") == 0 )
            {
               lblDadosgrupovulinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblDadosgrupovulinfo_Internalname, "Tooltiptext", lblDadosgrupovulinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "DADOS DE CRIANÇA/ADOLESCENTE") == 0 )
            {
               lblDadoscriancaadolescinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblDadoscriancaadolescinfo_Internalname, "Tooltiptext", lblDadoscriancaadolescinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "SETORES INTERNOS ENVOLVIDOS") == 0 )
            {
               lblSetorinternoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblSetorinternoinfo_Internalname, "Tooltiptext", lblSetorinternoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "FORMA DE COMPARTILHAMENTO INTERNO") == 0 )
            {
               lblCompartinternoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblCompartinternoinfo_Internalname, "Tooltiptext", lblCompartinternoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "ENVOLVIDOS NA COLETA") == 0 )
            {
               lblEnvolvidoscoletainfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblEnvolvidoscoletainfo_Internalname, "Tooltiptext", lblEnvolvidoscoletainfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "MEDIDA DE SEGURANÇA") == 0 )
            {
               lblMedidasegurancainfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblMedidasegurancainfo_Internalname, "Tooltiptext", lblMedidasegurancainfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "DESCRIÇÃO DA MEDIDA DE SEGURANÇA") == 0 )
            {
               lblMedidasegurancadescinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblMedidasegurancadescinfo_Internalname, "Tooltiptext", lblMedidasegurancadescinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "DESCRIÇÃO DO FLUXO DE TRATAMENTO DE DADOS") == 0 )
            {
               lblFluxotratdadosdescinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblFluxotratdadosdescinfo_Internalname, "Tooltiptext", lblFluxotratdadosdescinfo_Tooltiptext, true);
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
         lblTxtmedidasegurancadesc_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV21DocumentoMedidaSegurancaDesc)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTxtmedidasegurancadesc_Internalname, "Caption", lblTxtmedidasegurancadesc_Caption, true);
         lblTxtfinalidadetratamento_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV7DocumentoFinalidadeTratamento)), 10, 0))+"/100";
         AssignProp(sPrefix, false, lblTxtfinalidadetratamento_Internalname, "Caption", lblTxtfinalidadetratamento_Caption, true);
         lblTxtbaselegalnorm_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV16DocumentoBaseLegalNorm)), 10, 0))+"/100";
         AssignProp(sPrefix, false, lblTxtbaselegalnorm_Internalname, "Caption", lblTxtbaselegalnorm_Caption, true);
         lblTxtbaselegalnormext_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV17DocumentoBaseLegalNormIntExt)), 10, 0))+"/100";
         AssignProp(sPrefix, false, lblTxtbaselegalnormext_Internalname, "Caption", lblTxtbaselegalnormext_Caption, true);
      }

      protected void E20792( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( AV52IsCategoria )
         {
            /* Execute user subroutine: 'CATEGORIACOMBOCARREGA' */
            S162 ();
            if (returnInSub) return;
            AV8CategoriaId = AV51CategoriaId_Out;
            AssignAttri(sPrefix, false, "AV8CategoriaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaId), 8, 0));
            AV52IsCategoria = false;
            AssignAttri(sPrefix, false, "AV52IsCategoria", AV52IsCategoria);
            AV51CategoriaId_Out = 0;
            AssignAttri(sPrefix, false, "AV51CategoriaId_Out", StringUtil.LTrimStr( (decimal)(AV51CategoriaId_Out), 8, 0));
         }
         if ( AV53IsTipoDado )
         {
            /* Execute user subroutine: 'TIPODADOCOMBOCARREGA' */
            S172 ();
            if (returnInSub) return;
            AV9TipoDadoId = AV54TipoDadoId_Out;
            AssignAttri(sPrefix, false, "AV9TipoDadoId", StringUtil.LTrimStr( (decimal)(AV9TipoDadoId), 8, 0));
            AV53IsTipoDado = false;
            AssignAttri(sPrefix, false, "AV53IsTipoDado", AV53IsTipoDado);
            AV54TipoDadoId_Out = 0;
            AssignAttri(sPrefix, false, "AV54TipoDadoId_Out", StringUtil.LTrimStr( (decimal)(AV54TipoDadoId_Out), 8, 0));
         }
         if ( AV55IsFerramentaColeta )
         {
            /* Execute user subroutine: 'FERRAMENTACOLETACOMBOCARREGA' */
            S182 ();
            if (returnInSub) return;
            AV10FerramentaColetaId = AV56FerramentaColetaId_Out;
            AssignAttri(sPrefix, false, "AV10FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV10FerramentaColetaId), 8, 0));
            AV55IsFerramentaColeta = false;
            AssignAttri(sPrefix, false, "AV55IsFerramentaColeta", AV55IsFerramentaColeta);
            AV56FerramentaColetaId_Out = 0;
            AssignAttri(sPrefix, false, "AV56FerramentaColetaId_Out", StringUtil.LTrimStr( (decimal)(AV56FerramentaColetaId_Out), 8, 0));
         }
         if ( AV57IsAbrangenciaGeografica )
         {
            /* Execute user subroutine: 'ABRANGENCIAGEOGRAFICACOMBOCARREGA' */
            S192 ();
            if (returnInSub) return;
            AV11AbrangenciaGeograficaId = AV58AbrangenciaGeograficaId_Out;
            AssignAttri(sPrefix, false, "AV11AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
            AV57IsAbrangenciaGeografica = false;
            AssignAttri(sPrefix, false, "AV57IsAbrangenciaGeografica", AV57IsAbrangenciaGeografica);
            AV58AbrangenciaGeograficaId_Out = 0;
            AssignAttri(sPrefix, false, "AV58AbrangenciaGeograficaId_Out", StringUtil.LTrimStr( (decimal)(AV58AbrangenciaGeograficaId_Out), 8, 0));
         }
         if ( AV60IsFonteRetencao )
         {
            AV24FonteRetencaoId.FromJSonString(Combo_fonteretencaoid_Selectedvalue_get, null);
            AV107GXV1 = 1;
            while ( AV107GXV1 <= AV24FonteRetencaoId.Count )
            {
               AV42FonteRetencaoId_Item = (int)(AV24FonteRetencaoId.GetNumeric(AV107GXV1));
               AssignAttri(sPrefix, false, "AV42FonteRetencaoId_Item", StringUtil.LTrimStr( (decimal)(AV42FonteRetencaoId_Item), 8, 0));
               AV46FonteRetencaoId_Col.Add(AV42FonteRetencaoId_Item, 0);
               AV107GXV1 = (int)(AV107GXV1+1);
            }
            AV46FonteRetencaoId_Col.Add(AV59FonteRetencaoId_Out, 0);
            /* Execute user subroutine: 'LOADCOMBOFONTERETENCAOID' */
            S112 ();
            if (returnInSub) return;
            Combo_fonteretencaoid_Selectedvalue_set = AV46FonteRetencaoId_Col.ToJSonString(false);
            ucCombo_fonteretencaoid.SendProperty(context, sPrefix, false, Combo_fonteretencaoid_Internalname, "SelectedValue_set", Combo_fonteretencaoid_Selectedvalue_set);
            AV59FonteRetencaoId_Out = 0;
            AssignAttri(sPrefix, false, "AV59FonteRetencaoId_Out", StringUtil.LTrimStr( (decimal)(AV59FonteRetencaoId_Out), 4, 0));
            AV60IsFonteRetencao = false;
            AssignAttri(sPrefix, false, "AV60IsFonteRetencao", AV60IsFonteRetencao);
            AV46FonteRetencaoId_Col.Clear();
         }
         if ( AV61IsFrequenciaTratamento )
         {
            /* Execute user subroutine: 'FREQUENCIATRATAMENTOCOMBOCARREGA' */
            S202 ();
            if (returnInSub) return;
            AV12FrequenciaTratamentoId = AV62FrequenciaTratamentoId_Out;
            AssignAttri(sPrefix, false, "AV12FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
            AV61IsFrequenciaTratamento = false;
            AssignAttri(sPrefix, false, "AV61IsFrequenciaTratamento", AV61IsFrequenciaTratamento);
            AV62FrequenciaTratamentoId_Out = 0;
            AssignAttri(sPrefix, false, "AV62FrequenciaTratamentoId_Out", StringUtil.LTrimStr( (decimal)(AV62FrequenciaTratamentoId_Out), 4, 0));
         }
         if ( AV63IsTipoDescarte )
         {
            /* Execute user subroutine: 'TIPODESCARTECOMBOCARREGA' */
            S212 ();
            if (returnInSub) return;
            AV13TipoDescarteId = AV64TipoDescarteId_Out;
            AssignAttri(sPrefix, false, "AV13TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV13TipoDescarteId), 8, 0));
            AV61IsFrequenciaTratamento = false;
            AssignAttri(sPrefix, false, "AV61IsFrequenciaTratamento", AV61IsFrequenciaTratamento);
            AV64TipoDescarteId_Out = 0;
            AssignAttri(sPrefix, false, "AV64TipoDescarteId_Out", StringUtil.LTrimStr( (decimal)(AV64TipoDescarteId_Out), 8, 0));
         }
         if ( AV65IsTempoRetencao )
         {
            /* Execute user subroutine: 'TEMPORETENCAOCOMBOCARREGA' */
            S222 ();
            if (returnInSub) return;
            AV14TempoRetencaoId = AV66TempoRetencaoId_Out;
            AssignAttri(sPrefix, false, "AV14TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV14TempoRetencaoId), 8, 0));
            AV65IsTempoRetencao = false;
            AssignAttri(sPrefix, false, "AV65IsTempoRetencao", AV65IsTempoRetencao);
            AV66TempoRetencaoId_Out = 0;
            AssignAttri(sPrefix, false, "AV66TempoRetencaoId_Out", StringUtil.LTrimStr( (decimal)(AV66TempoRetencaoId_Out), 8, 0));
         }
         if ( AV67IsSetorInterno )
         {
            AV28SetorInternoId.FromJSonString(Combo_setorinternoid_Selectedvalue_get, null);
            AV108GXV2 = 1;
            while ( AV108GXV2 <= AV28SetorInternoId.Count )
            {
               AV43SetorInternoId_Item = (short)(AV28SetorInternoId.GetNumeric(AV108GXV2));
               AssignAttri(sPrefix, false, "AV43SetorInternoId_Item", StringUtil.LTrimStr( (decimal)(AV43SetorInternoId_Item), 4, 0));
               AV48SetorInternoId_Col.Add(AV43SetorInternoId_Item, 0);
               AV108GXV2 = (int)(AV108GXV2+1);
            }
            AV48SetorInternoId_Col.Add(AV68SetorInternoId_Out, 0);
            /* Execute user subroutine: 'LOADCOMBOSETORINTERNOID' */
            S122 ();
            if (returnInSub) return;
            Combo_setorinternoid_Selectedvalue_set = AV48SetorInternoId_Col.ToJSonString(false);
            ucCombo_setorinternoid.SendProperty(context, sPrefix, false, Combo_setorinternoid_Internalname, "SelectedValue_set", Combo_setorinternoid_Selectedvalue_set);
            AV68SetorInternoId_Out = 0;
            AssignAttri(sPrefix, false, "AV68SetorInternoId_Out", StringUtil.LTrimStr( (decimal)(AV68SetorInternoId_Out), 8, 0));
            AV67IsSetorInterno = false;
            AssignAttri(sPrefix, false, "AV67IsSetorInterno", AV67IsSetorInterno);
            AV48SetorInternoId_Col.Clear();
         }
         if ( AV69IsCompartInterno )
         {
            AV29CompartInternoId.FromJSonString(Combo_compartinternoid_Selectedvalue_get, null);
            AV109GXV3 = 1;
            while ( AV109GXV3 <= AV29CompartInternoId.Count )
            {
               AV38CompartInternoId_Item = (int)(AV29CompartInternoId.GetNumeric(AV109GXV3));
               AssignAttri(sPrefix, false, "AV38CompartInternoId_Item", StringUtil.LTrimStr( (decimal)(AV38CompartInternoId_Item), 8, 0));
               AV47CompartInternoId_Col.Add(AV38CompartInternoId_Item, 0);
               AV109GXV3 = (int)(AV109GXV3+1);
            }
            AV47CompartInternoId_Col.Add(AV70CompartInternoId_Out, 0);
            /* Execute user subroutine: 'LOADCOMBOCOMPARTINTERNOID' */
            S132 ();
            if (returnInSub) return;
            Combo_compartinternoid_Selectedvalue_set = AV47CompartInternoId_Col.ToJSonString(false);
            ucCombo_compartinternoid.SendProperty(context, sPrefix, false, Combo_compartinternoid_Internalname, "SelectedValue_set", Combo_compartinternoid_Selectedvalue_set);
            AV70CompartInternoId_Out = 0;
            AssignAttri(sPrefix, false, "AV70CompartInternoId_Out", StringUtil.LTrimStr( (decimal)(AV70CompartInternoId_Out), 8, 0));
            AV69IsCompartInterno = false;
            AssignAttri(sPrefix, false, "AV69IsCompartInterno", AV69IsCompartInterno);
            AV47CompartInternoId_Col.Clear();
         }
         if ( AV71IsEnvolvidosColeta )
         {
            AV30EnvolvidosColetaId.FromJSonString(Combo_envolvidoscoletaid_Selectedvalue_get, null);
            AV110GXV4 = 1;
            while ( AV110GXV4 <= AV30EnvolvidosColetaId.Count )
            {
               AV41EnvolvidosColetaId_Item = (int)(AV30EnvolvidosColetaId.GetNumeric(AV110GXV4));
               AssignAttri(sPrefix, false, "AV41EnvolvidosColetaId_Item", StringUtil.LTrimStr( (decimal)(AV41EnvolvidosColetaId_Item), 8, 0));
               AV49EnvolvidosColetaId_Col.Add(AV41EnvolvidosColetaId_Item, 0);
               AV110GXV4 = (int)(AV110GXV4+1);
            }
            AV49EnvolvidosColetaId_Col.Add(AV72EnvolvidosColetaId_Out, 0);
            /* Execute user subroutine: 'LOADCOMBOENVOLVIDOSCOLETAID' */
            S142 ();
            if (returnInSub) return;
            Combo_envolvidoscoletaid_Selectedvalue_set = AV49EnvolvidosColetaId_Col.ToJSonString(false);
            ucCombo_envolvidoscoletaid.SendProperty(context, sPrefix, false, Combo_envolvidoscoletaid_Internalname, "SelectedValue_set", Combo_envolvidoscoletaid_Selectedvalue_set);
            AV72EnvolvidosColetaId_Out = 0;
            AssignAttri(sPrefix, false, "AV72EnvolvidosColetaId_Out", StringUtil.LTrimStr( (decimal)(AV72EnvolvidosColetaId_Out), 8, 0));
            AV71IsEnvolvidosColeta = false;
            AssignAttri(sPrefix, false, "AV71IsEnvolvidosColeta", AV71IsEnvolvidosColeta);
            AV49EnvolvidosColetaId_Col.Clear();
         }
         if ( AV73IsMedidaSeguranca )
         {
            AV20MedidaSegurancaId.FromJSonString(Combo_medidasegurancaid_Selectedvalue_get, null);
            AV111GXV5 = 1;
            while ( AV111GXV5 <= AV20MedidaSegurancaId.Count )
            {
               AV90MedidaSegurancaId_Item = (int)(AV20MedidaSegurancaId.GetNumeric(AV111GXV5));
               AssignAttri(sPrefix, false, "AV90MedidaSegurancaId_Item", StringUtil.LTrimStr( (decimal)(AV90MedidaSegurancaId_Item), 8, 0));
               AV89MedidaSegurancaId_Col.Add(AV90MedidaSegurancaId_Item, 0);
               AV111GXV5 = (int)(AV111GXV5+1);
            }
            AV89MedidaSegurancaId_Col.Add(AV74MedidaSegurancaId_Out, 0);
            /* Execute user subroutine: 'LOADCOMBOMEDIDASEGURANCAID' */
            S152 ();
            if (returnInSub) return;
            Combo_medidasegurancaid_Selectedvalue_set = AV89MedidaSegurancaId_Col.ToJSonString(false);
            ucCombo_medidasegurancaid.SendProperty(context, sPrefix, false, Combo_medidasegurancaid_Internalname, "SelectedValue_set", Combo_medidasegurancaid_Selectedvalue_set);
            AV74MedidaSegurancaId_Out = 0;
            AssignAttri(sPrefix, false, "AV74MedidaSegurancaId_Out", StringUtil.LTrimStr( (decimal)(AV74MedidaSegurancaId_Out), 8, 0));
            AV73IsMedidaSeguranca = false;
            AssignAttri(sPrefix, false, "AV73IsMedidaSeguranca", AV73IsMedidaSeguranca);
            AV89MedidaSegurancaId_Col.Clear();
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavCategoriaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8CategoriaId), 8, 0));
         AssignProp(sPrefix, false, cmbavCategoriaid_Internalname, "Values", cmbavCategoriaid.ToJavascriptSource(), true);
         cmbavTipodadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9TipoDadoId), 8, 0));
         AssignProp(sPrefix, false, cmbavTipodadoid_Internalname, "Values", cmbavTipodadoid.ToJavascriptSource(), true);
         cmbavFerramentacoletaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10FerramentaColetaId), 8, 0));
         AssignProp(sPrefix, false, cmbavFerramentacoletaid_Internalname, "Values", cmbavFerramentacoletaid.ToJavascriptSource(), true);
         cmbavAbrangenciageograficaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11AbrangenciaGeograficaId), 8, 0));
         AssignProp(sPrefix, false, cmbavAbrangenciageograficaid_Internalname, "Values", cmbavAbrangenciageograficaid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24FonteRetencaoId", AV24FonteRetencaoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46FonteRetencaoId_Col", AV46FonteRetencaoId_Col);
         cmbavFrequenciatratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12FrequenciaTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavFrequenciatratamentoid_Internalname, "Values", cmbavFrequenciatratamentoid.ToJavascriptSource(), true);
         cmbavTipodescarteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13TipoDescarteId), 8, 0));
         AssignProp(sPrefix, false, cmbavTipodescarteid_Internalname, "Values", cmbavTipodescarteid.ToJavascriptSource(), true);
         cmbavTemporetencaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14TempoRetencaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavTemporetencaoid_Internalname, "Values", cmbavTemporetencaoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28SetorInternoId", AV28SetorInternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48SetorInternoId_Col", AV48SetorInternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29CompartInternoId", AV29CompartInternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47CompartInternoId_Col", AV47CompartInternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30EnvolvidosColetaId", AV30EnvolvidosColetaId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49EnvolvidosColetaId_Col", AV49EnvolvidosColetaId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20MedidaSegurancaId", AV20MedidaSegurancaId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV89MedidaSegurancaId_Col", AV89MedidaSegurancaId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV25FonteRetencaoId_Data", AV25FonteRetencaoId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31SetorInternoId_Data", AV31SetorInternoId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32CompartInternoId_Data", AV32CompartInternoId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33EnvolvidosColetaId_Data", AV33EnvolvidosColetaId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV88MedidaSegurancaId_Data", AV88MedidaSegurancaId_Data);
      }

      protected void E21792( )
      {
         /* 'DoFerramentaColetaAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "ferramentacoleta.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("ferramentacoleta.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV55IsFerramentaColeta","AV56FerramentaColetaId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E22792( )
      {
         /* 'DoAbrangenciaGeograficaAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "abrangenciageografica.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("abrangenciageografica.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV57IsAbrangenciaGeografica","AV58AbrangenciaGeograficaId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E23792( )
      {
         /* 'DoFrequenciaTratamentoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "frequenciatratamento.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("frequenciatratamento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV61IsFrequenciaTratamento","AV62FrequenciaTratamentoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E24792( )
      {
         /* 'DoFonteRetencaoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "fonteretencao.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("fonteretencao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV60IsFonteRetencao","AV59FonteRetencaoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E25792( )
      {
         /* 'DoSetorInternoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "setorinterno.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("setorinterno.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV67IsSetorInterno","AV68SetorInternoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E26792( )
      {
         /* 'DoCompartInternoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "compartinterno.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("compartinterno.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV69IsCompartInterno","AV70CompartInternoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E27792( )
      {
         /* 'DoEnvolvidosColetaAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "envolvidoscoleta.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("envolvidoscoleta.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV71IsEnvolvidosColeta","AV72EnvolvidosColetaId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E28792( )
      {
         /* 'DoMedidaSegurancaAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "medidaseguranca.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("medidaseguranca.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV73IsMedidaSeguranca","AV74MedidaSegurancaId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E29792( )
      {
         /* 'DoSalvar' Routine */
         returnInSub = false;
         if ( (0==AV11AbrangenciaGeograficaId) )
         {
            AV34Documento.gxTv_SdtDocumento_Abrangenciageograficaid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Abrangenciageograficaid = AV11AbrangenciaGeograficaId;
         }
         if ( (0==AV8CategoriaId) )
         {
            AV34Documento.gxTv_SdtDocumento_Categoriaid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Categoriaid = AV8CategoriaId;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16DocumentoBaseLegalNorm)) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentobaselegalnorm_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentobaselegalnorm = AV16DocumentoBaseLegalNorm;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17DocumentoBaseLegalNormIntExt)) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentobaselegalnormintext_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentobaselegalnormintext = AV17DocumentoBaseLegalNormIntExt;
         }
         if ( (false==AV19DocumentoDadosCriancaAdolesc) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentodadoscriancaadolesc_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentodadoscriancaadolesc = AV19DocumentoDadosCriancaAdolesc;
         }
         if ( (false==AV18DocumentoDadosGrupoVul) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentodadosgrupovul_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentodadosgrupovul = AV18DocumentoDadosGrupoVul;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7DocumentoFinalidadeTratamento)) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentofinalidadetratamento_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentofinalidadetratamento = AV7DocumentoFinalidadeTratamento;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22DocumentoFluxoTratDadosDesc)) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentofluxotratdadosdesc_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentofluxotratdadosdesc = AV22DocumentoFluxoTratDadosDesc;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21DocumentoMedidaSegurancaDesc)) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentomedidasegurancadesc_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentomedidasegurancadesc = AV21DocumentoMedidaSegurancaDesc;
         }
         if ( (false==AV15DocumentoPrevColetaDados) )
         {
            AV34Documento.gxTv_SdtDocumento_Documentoprevcoletadados_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Documentoprevcoletadados = AV15DocumentoPrevColetaDados;
         }
         if ( (0==AV10FerramentaColetaId) )
         {
            AV34Documento.gxTv_SdtDocumento_Ferramentacoletaid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Ferramentacoletaid = AV10FerramentaColetaId;
         }
         if ( (0==AV12FrequenciaTratamentoId) )
         {
            AV34Documento.gxTv_SdtDocumento_Frequenciatratamentoid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Frequenciatratamentoid = AV12FrequenciaTratamentoId;
         }
         if ( (0==AV14TempoRetencaoId) )
         {
            AV34Documento.gxTv_SdtDocumento_Temporetencaoid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Temporetencaoid = AV14TempoRetencaoId;
         }
         if ( (0==AV9TipoDadoId) )
         {
            AV34Documento.gxTv_SdtDocumento_Tipodadoid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Tipodadoid = AV9TipoDadoId;
         }
         if ( (0==AV13TipoDescarteId) )
         {
            AV34Documento.gxTv_SdtDocumento_Tipodescarteid_SetNull();
         }
         else
         {
            AV34Documento.gxTpr_Tipodescarteid = AV13TipoDescarteId;
         }
         AV34Documento.Update();
         if ( AV34Documento.Success() )
         {
            context.CommitDataStores("tratamentowc",pr_default);
            AV47CompartInternoId_Col.FromJSonString(Combo_compartinternoid_Selectedvalue_get, null);
            AV112GXV6 = 1;
            while ( AV112GXV6 <= AV47CompartInternoId_Col.Count )
            {
               AV38CompartInternoId_Item = (int)(AV47CompartInternoId_Col.GetNumeric(AV112GXV6));
               AssignAttri(sPrefix, false, "AV38CompartInternoId_Item", StringUtil.LTrimStr( (decimal)(AV38CompartInternoId_Item), 8, 0));
               AV113GXLvl854 = 0;
               /* Using cursor H007913 */
               pr_default.execute(11, new Object[] {AV38CompartInternoId_Item, AV36DocumentoId});
               while ( (pr_default.getStatus(11) != 101) )
               {
                  A57CompartInternoId = H007913_A57CompartInternoId[0];
                  A75DocumentoId = H007913_A75DocumentoId[0];
                  AV113GXLvl854 = 1;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(11);
               if ( AV113GXLvl854 == 0 )
               {
                  new doccompartinternoinsere(context ).execute(  AV36DocumentoId,  AV38CompartInternoId_Item) ;
               }
               AV112GXV6 = (int)(AV112GXV6+1);
            }
            /* Using cursor H007914 */
            pr_default.execute(12, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(12) != 101) )
            {
               A75DocumentoId = H007914_A75DocumentoId[0];
               A57CompartInternoId = H007914_A57CompartInternoId[0];
               if ( ! (AV47CompartInternoId_Col.IndexOf(A57CompartInternoId)>0) )
               {
                  new doccompartinternoexclui(context ).execute(  A75DocumentoId,  A57CompartInternoId) ;
               }
               pr_default.readNext(12);
            }
            pr_default.close(12);
            AV49EnvolvidosColetaId_Col.FromJSonString(Combo_envolvidoscoletaid_Selectedvalue_get, null);
            AV115GXV7 = 1;
            while ( AV115GXV7 <= AV49EnvolvidosColetaId_Col.Count )
            {
               AV41EnvolvidosColetaId_Item = (int)(AV49EnvolvidosColetaId_Col.GetNumeric(AV115GXV7));
               AssignAttri(sPrefix, false, "AV41EnvolvidosColetaId_Item", StringUtil.LTrimStr( (decimal)(AV41EnvolvidosColetaId_Item), 8, 0));
               AV116GXLvl877 = 0;
               /* Using cursor H007915 */
               pr_default.execute(13, new Object[] {AV41EnvolvidosColetaId_Item, AV36DocumentoId});
               while ( (pr_default.getStatus(13) != 101) )
               {
                  A54EnvolvidosColetaId = H007915_A54EnvolvidosColetaId[0];
                  A75DocumentoId = H007915_A75DocumentoId[0];
                  AV116GXLvl877 = 1;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(13);
               if ( AV116GXLvl877 == 0 )
               {
                  new docenvolvidoscoletainsere(context ).execute(  AV36DocumentoId,  AV41EnvolvidosColetaId_Item) ;
               }
               AV115GXV7 = (int)(AV115GXV7+1);
            }
            /* Using cursor H007916 */
            pr_default.execute(14, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(14) != 101) )
            {
               A75DocumentoId = H007916_A75DocumentoId[0];
               A54EnvolvidosColetaId = H007916_A54EnvolvidosColetaId[0];
               if ( ! (AV49EnvolvidosColetaId_Col.IndexOf(A54EnvolvidosColetaId)>0) )
               {
                  new docenvolvidoscoletaexclui(context ).execute(  A75DocumentoId,  A54EnvolvidosColetaId) ;
               }
               pr_default.readNext(14);
            }
            pr_default.close(14);
            AV89MedidaSegurancaId_Col.FromJSonString(Combo_medidasegurancaid_Selectedvalue_get, null);
            AV118GXV8 = 1;
            while ( AV118GXV8 <= AV89MedidaSegurancaId_Col.Count )
            {
               AV90MedidaSegurancaId_Item = (int)(AV89MedidaSegurancaId_Col.GetNumeric(AV118GXV8));
               AssignAttri(sPrefix, false, "AV90MedidaSegurancaId_Item", StringUtil.LTrimStr( (decimal)(AV90MedidaSegurancaId_Item), 8, 0));
               AV119GXLvl900 = 0;
               /* Using cursor H007917 */
               pr_default.execute(15, new Object[] {AV90MedidaSegurancaId_Item, AV36DocumentoId});
               while ( (pr_default.getStatus(15) != 101) )
               {
                  A51MedidaSegurancaId = H007917_A51MedidaSegurancaId[0];
                  A75DocumentoId = H007917_A75DocumentoId[0];
                  AV119GXLvl900 = 1;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(15);
               if ( AV119GXLvl900 == 0 )
               {
                  new docmedidasegurancainsere(context ).execute(  AV36DocumentoId,  AV90MedidaSegurancaId_Item) ;
               }
               /* Using cursor H007918 */
               pr_default.execute(16, new Object[] {AV36DocumentoId});
               while ( (pr_default.getStatus(16) != 101) )
               {
                  A75DocumentoId = H007918_A75DocumentoId[0];
                  A51MedidaSegurancaId = H007918_A51MedidaSegurancaId[0];
                  if ( ! (AV89MedidaSegurancaId_Col.IndexOf(A51MedidaSegurancaId)>0) )
                  {
                     new docmedidasegurancaexclui(context ).execute(  A75DocumentoId,  A51MedidaSegurancaId) ;
                  }
                  pr_default.readNext(16);
               }
               pr_default.close(16);
               AV118GXV8 = (int)(AV118GXV8+1);
            }
            AV46FonteRetencaoId_Col.FromJSonString(Combo_fonteretencaoid_Selectedvalue_get, null);
            AV121GXV9 = 1;
            while ( AV121GXV9 <= AV46FonteRetencaoId_Col.Count )
            {
               AV42FonteRetencaoId_Item = (int)(AV46FonteRetencaoId_Col.GetNumeric(AV121GXV9));
               AssignAttri(sPrefix, false, "AV42FonteRetencaoId_Item", StringUtil.LTrimStr( (decimal)(AV42FonteRetencaoId_Item), 8, 0));
               AV122GXLvl923 = 0;
               /* Using cursor H007919 */
               pr_default.execute(17, new Object[] {AV42FonteRetencaoId_Item, AV36DocumentoId});
               while ( (pr_default.getStatus(17) != 101) )
               {
                  A63FonteRetencaoId = H007919_A63FonteRetencaoId[0];
                  A75DocumentoId = H007919_A75DocumentoId[0];
                  AV122GXLvl923 = 1;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(17);
               if ( AV122GXLvl923 == 0 )
               {
                  new docfonteretencaoinsere(context ).execute(  AV36DocumentoId,  AV42FonteRetencaoId_Item) ;
               }
               AV121GXV9 = (int)(AV121GXV9+1);
            }
            /* Using cursor H007920 */
            pr_default.execute(18, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(18) != 101) )
            {
               A75DocumentoId = H007920_A75DocumentoId[0];
               A63FonteRetencaoId = H007920_A63FonteRetencaoId[0];
               if ( ! (AV46FonteRetencaoId_Col.IndexOf(A63FonteRetencaoId)>0) )
               {
                  new docfonteretencaoexclui(context ).execute(  A75DocumentoId,  A63FonteRetencaoId) ;
               }
               pr_default.readNext(18);
            }
            pr_default.close(18);
            AV48SetorInternoId_Col.FromJSonString(Combo_setorinternoid_Selectedvalue_get, null);
            AV124GXV10 = 1;
            while ( AV124GXV10 <= AV48SetorInternoId_Col.Count )
            {
               AV43SetorInternoId_Item = (short)(AV48SetorInternoId_Col.GetNumeric(AV124GXV10));
               AssignAttri(sPrefix, false, "AV43SetorInternoId_Item", StringUtil.LTrimStr( (decimal)(AV43SetorInternoId_Item), 4, 0));
               AV125GXLvl946 = 0;
               /* Using cursor H007921 */
               pr_default.execute(19, new Object[] {AV43SetorInternoId_Item, AV36DocumentoId});
               while ( (pr_default.getStatus(19) != 101) )
               {
                  A60SetorInternoId = H007921_A60SetorInternoId[0];
                  A75DocumentoId = H007921_A75DocumentoId[0];
                  AV125GXLvl946 = 1;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(19);
               if ( AV125GXLvl946 == 0 )
               {
                  new docsetorinternoinsere(context ).execute(  AV36DocumentoId,  AV43SetorInternoId_Item) ;
               }
               AV124GXV10 = (int)(AV124GXV10+1);
            }
            /* Using cursor H007922 */
            pr_default.execute(20, new Object[] {AV36DocumentoId});
            while ( (pr_default.getStatus(20) != 101) )
            {
               A75DocumentoId = H007922_A75DocumentoId[0];
               A60SetorInternoId = H007922_A60SetorInternoId[0];
               if ( ! (AV48SetorInternoId_Col.IndexOf(A60SetorInternoId)>0) )
               {
                  new docsetorinternoexclui(context ).execute(  A75DocumentoId,  A60SetorInternoId) ;
               }
               pr_default.readNext(20);
            }
            pr_default.close(20);
            GX_msglist.addItem("Inserido com Sucesso!");
         }
         else
         {
            AV128GXV12 = 1;
            AV127GXV11 = AV34Documento.GetMessages();
            while ( AV128GXV12 <= AV127GXV11.Count )
            {
               AV37Message = ((GeneXus.Utils.SdtMessages_Message)AV127GXV11.Item(AV128GXV12));
               GX_msglist.addItem(AV37Message.gxTpr_Description);
               AV128GXV12 = (int)(AV128GXV12+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34Documento", AV34Documento);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47CompartInternoId_Col", AV47CompartInternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49EnvolvidosColetaId_Col", AV49EnvolvidosColetaId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV89MedidaSegurancaId_Col", AV89MedidaSegurancaId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46FonteRetencaoId_Col", AV46FonteRetencaoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48SetorInternoId_Col", AV48SetorInternoId_Col);
      }

      protected void E30792( )
      {
         /* 'DoTipoDescarteAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "tipodescarte.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("tipodescarte.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV63IsTipoDescarte","AV64TipoDescarteId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E31792( )
      {
         /* 'DoTempoRetencaoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "temporetencao.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("temporetencao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV65IsTempoRetencao","AV66TempoRetencaoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E32792( )
      {
         /* 'DoCategoriaAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "categoria.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("categoria.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV52IsCategoria","AV51CategoriaId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E33792( )
      {
         /* 'DoTipoDadoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "tipodado.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("tipodado.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV53IsTipoDado","AV54TipoDadoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void S232( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV75IsAuthorized_FerramentaColetaAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoFerramentaColetaAdd", out  GXt_boolean2) ;
         AV75IsAuthorized_FerramentaColetaAdd = GXt_boolean2;
         if ( ! ( AV75IsAuthorized_FerramentaColetaAdd ) )
         {
            lblFerramentacoletaadd_Visible = 0;
            AssignProp(sPrefix, false, lblFerramentacoletaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFerramentacoletaadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV76IsAuthorized_AbrangenciaGeograficaAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoAbrangenciaGeograficaAdd", out  GXt_boolean2) ;
         AV76IsAuthorized_AbrangenciaGeograficaAdd = GXt_boolean2;
         if ( ! ( AV76IsAuthorized_AbrangenciaGeograficaAdd ) )
         {
            lblAbrangenciageograficaadd_Visible = 0;
            AssignProp(sPrefix, false, lblAbrangenciageograficaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblAbrangenciageograficaadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV77IsAuthorized_FrequenciaTratamentoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoFrequenciaTratamentoAdd", out  GXt_boolean2) ;
         AV77IsAuthorized_FrequenciaTratamentoAdd = GXt_boolean2;
         if ( ! ( AV77IsAuthorized_FrequenciaTratamentoAdd ) )
         {
            lblFrequenciatratamentoadd_Visible = 0;
            AssignProp(sPrefix, false, lblFrequenciatratamentoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFrequenciatratamentoadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV78IsAuthorized_FonteRetencaoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoFonteRetencaoAdd", out  GXt_boolean2) ;
         AV78IsAuthorized_FonteRetencaoAdd = GXt_boolean2;
         if ( ! ( AV78IsAuthorized_FonteRetencaoAdd ) )
         {
            lblFonteretencaoadd_Visible = 0;
            AssignProp(sPrefix, false, lblFonteretencaoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFonteretencaoadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV79IsAuthorized_SetorInternoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoSetorInternoAdd", out  GXt_boolean2) ;
         AV79IsAuthorized_SetorInternoAdd = GXt_boolean2;
         if ( ! ( AV79IsAuthorized_SetorInternoAdd ) )
         {
            lblSetorinternoadd_Visible = 0;
            AssignProp(sPrefix, false, lblSetorinternoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSetorinternoadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV80IsAuthorized_CompartInternoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoCompartInternoAdd", out  GXt_boolean2) ;
         AV80IsAuthorized_CompartInternoAdd = GXt_boolean2;
         if ( ! ( AV80IsAuthorized_CompartInternoAdd ) )
         {
            lblCompartinternoadd_Visible = 0;
            AssignProp(sPrefix, false, lblCompartinternoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCompartinternoadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV81IsAuthorized_EnvolvidosColetaAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoEnvolvidosColetaAdd", out  GXt_boolean2) ;
         AV81IsAuthorized_EnvolvidosColetaAdd = GXt_boolean2;
         if ( ! ( AV81IsAuthorized_EnvolvidosColetaAdd ) )
         {
            lblEnvolvidoscoletaadd_Visible = 0;
            AssignProp(sPrefix, false, lblEnvolvidoscoletaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblEnvolvidoscoletaadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV82IsAuthorized_MedidaSegurancaAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoMedidaSegurancaAdd", out  GXt_boolean2) ;
         AV82IsAuthorized_MedidaSegurancaAdd = GXt_boolean2;
         if ( ! ( AV82IsAuthorized_MedidaSegurancaAdd ) )
         {
            lblMedidasegurancaadd_Visible = 0;
            AssignProp(sPrefix, false, lblMedidasegurancaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblMedidasegurancaadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV87IsAuthorized_Salvar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoSalva", out  GXt_boolean2) ;
         AV87IsAuthorized_Salvar = GXt_boolean2;
         if ( ! ( AV87IsAuthorized_Salvar ) )
         {
            bttBtnsalvar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsalvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsalvar_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV83IsAuthorized_TipoDescarteAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoTipoDescarteAdd", out  GXt_boolean2) ;
         AV83IsAuthorized_TipoDescarteAdd = GXt_boolean2;
         if ( ! ( AV83IsAuthorized_TipoDescarteAdd ) )
         {
            lblTipodescarteadd_Visible = 0;
            AssignProp(sPrefix, false, lblTipodescarteadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipodescarteadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV84IsAuthorized_TempoRetencaoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoTempoRetencaoAdd", out  GXt_boolean2) ;
         AV84IsAuthorized_TempoRetencaoAdd = GXt_boolean2;
         if ( ! ( AV84IsAuthorized_TempoRetencaoAdd ) )
         {
            lblTemporetencaoadd_Visible = 0;
            AssignProp(sPrefix, false, lblTemporetencaoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTemporetencaoadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV85IsAuthorized_CategoriaAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoCategoriaAdd", out  GXt_boolean2) ;
         AV85IsAuthorized_CategoriaAdd = GXt_boolean2;
         if ( ! ( AV85IsAuthorized_CategoriaAdd ) )
         {
            lblCategoriaadd_Visible = 0;
            AssignProp(sPrefix, false, lblCategoriaadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCategoriaadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV86IsAuthorized_TipoDadoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaTratamentoTipoAdd", out  GXt_boolean2) ;
         AV86IsAuthorized_TipoDadoAdd = GXt_boolean2;
         if ( ! ( AV86IsAuthorized_TipoDadoAdd ) )
         {
            lblTipodadoadd_Visible = 0;
            AssignProp(sPrefix, false, lblTipodadoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipodadoadd_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'LOADCOMBOMEDIDASEGURANCAID' Routine */
         returnInSub = false;
         /* Using cursor H007923 */
         pr_default.execute(21);
         while ( (pr_default.getStatus(21) != 101) )
         {
            A53MedidaSegurancaAtivo = H007923_A53MedidaSegurancaAtivo[0];
            A51MedidaSegurancaId = H007923_A51MedidaSegurancaId[0];
            A52MedidaSegurancaNome = H007923_A52MedidaSegurancaNome[0];
            AV27Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV27Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A51MedidaSegurancaId), 8, 0));
            AV27Combo_DataItem.gxTpr_Title = A52MedidaSegurancaNome;
            AV88MedidaSegurancaId_Data.Add(AV27Combo_DataItem, 0);
            pr_default.readNext(21);
         }
         pr_default.close(21);
         Combo_medidasegurancaid_Selectedvalue_set = AV20MedidaSegurancaId.ToJSonString(false);
         ucCombo_medidasegurancaid.SendProperty(context, sPrefix, false, Combo_medidasegurancaid_Internalname, "SelectedValue_set", Combo_medidasegurancaid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOENVOLVIDOSCOLETAID' Routine */
         returnInSub = false;
         /* Using cursor H007924 */
         pr_default.execute(22);
         while ( (pr_default.getStatus(22) != 101) )
         {
            A56EnvolvidosColetaAtivo = H007924_A56EnvolvidosColetaAtivo[0];
            A54EnvolvidosColetaId = H007924_A54EnvolvidosColetaId[0];
            A55EnvolvidosColetaNome = H007924_A55EnvolvidosColetaNome[0];
            AV27Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV27Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A54EnvolvidosColetaId), 8, 0));
            AV27Combo_DataItem.gxTpr_Title = A55EnvolvidosColetaNome;
            AV33EnvolvidosColetaId_Data.Add(AV27Combo_DataItem, 0);
            pr_default.readNext(22);
         }
         pr_default.close(22);
         Combo_envolvidoscoletaid_Selectedvalue_set = AV30EnvolvidosColetaId.ToJSonString(false);
         ucCombo_envolvidoscoletaid.SendProperty(context, sPrefix, false, Combo_envolvidoscoletaid_Internalname, "SelectedValue_set", Combo_envolvidoscoletaid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCOMPARTINTERNOID' Routine */
         returnInSub = false;
         /* Using cursor H007925 */
         pr_default.execute(23);
         while ( (pr_default.getStatus(23) != 101) )
         {
            A59CompartInternoAtivo = H007925_A59CompartInternoAtivo[0];
            A57CompartInternoId = H007925_A57CompartInternoId[0];
            A58CompartInternoNome = H007925_A58CompartInternoNome[0];
            AV27Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV27Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A57CompartInternoId), 8, 0));
            AV27Combo_DataItem.gxTpr_Title = A58CompartInternoNome;
            AV32CompartInternoId_Data.Add(AV27Combo_DataItem, 0);
            pr_default.readNext(23);
         }
         pr_default.close(23);
         Combo_compartinternoid_Selectedvalue_set = AV29CompartInternoId.ToJSonString(false);
         ucCombo_compartinternoid.SendProperty(context, sPrefix, false, Combo_compartinternoid_Internalname, "SelectedValue_set", Combo_compartinternoid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSETORINTERNOID' Routine */
         returnInSub = false;
         AV31SetorInternoId_Data.Clear();
         /* Using cursor H007926 */
         pr_default.execute(24);
         while ( (pr_default.getStatus(24) != 101) )
         {
            A62SetorInternoAtivo = H007926_A62SetorInternoAtivo[0];
            A60SetorInternoId = H007926_A60SetorInternoId[0];
            A61SetorInternoNome = H007926_A61SetorInternoNome[0];
            AV27Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV27Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A60SetorInternoId), 8, 0));
            AV27Combo_DataItem.gxTpr_Title = A61SetorInternoNome;
            AV31SetorInternoId_Data.Add(AV27Combo_DataItem, 0);
            pr_default.readNext(24);
         }
         pr_default.close(24);
         Combo_setorinternoid_Selectedvalue_set = AV28SetorInternoId.ToJSonString(false);
         ucCombo_setorinternoid.SendProperty(context, sPrefix, false, Combo_setorinternoid_Internalname, "SelectedValue_set", Combo_setorinternoid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOFONTERETENCAOID' Routine */
         returnInSub = false;
         AV25FonteRetencaoId_Data.Clear();
         /* Using cursor H007927 */
         pr_default.execute(25);
         while ( (pr_default.getStatus(25) != 101) )
         {
            A65FonteRetencaoAtivo = H007927_A65FonteRetencaoAtivo[0];
            A63FonteRetencaoId = H007927_A63FonteRetencaoId[0];
            A64FonteRetencaoNome = H007927_A64FonteRetencaoNome[0];
            AV27Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV27Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A63FonteRetencaoId), 8, 0));
            AV27Combo_DataItem.gxTpr_Title = A64FonteRetencaoNome;
            AV25FonteRetencaoId_Data.Add(AV27Combo_DataItem, 0);
            pr_default.readNext(25);
         }
         pr_default.close(25);
         Combo_fonteretencaoid_Selectedvalue_set = AV24FonteRetencaoId.ToJSonString(false);
         ucCombo_fonteretencaoid.SendProperty(context, sPrefix, false, Combo_fonteretencaoid_Internalname, "SelectedValue_set", Combo_fonteretencaoid_Selectedvalue_set);
      }

      protected void S162( )
      {
         /* 'CATEGORIACOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavCategoriaid.removeAllItems();
         cmbavCategoriaid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007928 */
         pr_default.execute(26);
         while ( (pr_default.getStatus(26) != 101) )
         {
            A29CategoriaAtivo = H007928_A29CategoriaAtivo[0];
            A27CategoriaId = H007928_A27CategoriaId[0];
            A28CategoriaNome = H007928_A28CategoriaNome[0];
            cmbavCategoriaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0)), A28CategoriaNome, 0);
            pr_default.readNext(26);
         }
         pr_default.close(26);
      }

      protected void S172( )
      {
         /* 'TIPODADOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavTipodadoid.removeAllItems();
         cmbavTipodadoid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007929 */
         pr_default.execute(27);
         while ( (pr_default.getStatus(27) != 101) )
         {
            A32TipoDadoAtivo = H007929_A32TipoDadoAtivo[0];
            A30TipoDadoId = H007929_A30TipoDadoId[0];
            A31TipoDadoNome = H007929_A31TipoDadoNome[0];
            cmbavTipodadoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0)), A31TipoDadoNome, 0);
            pr_default.readNext(27);
         }
         pr_default.close(27);
      }

      protected void S182( )
      {
         /* 'FERRAMENTACOLETACOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavFerramentacoletaid.removeAllItems();
         cmbavFerramentacoletaid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007930 */
         pr_default.execute(28);
         while ( (pr_default.getStatus(28) != 101) )
         {
            A35FerramentaColetaAtivo = H007930_A35FerramentaColetaAtivo[0];
            A33FerramentaColetaId = H007930_A33FerramentaColetaId[0];
            A34FerramentaColetaNome = H007930_A34FerramentaColetaNome[0];
            cmbavFerramentacoletaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0)), A34FerramentaColetaNome, 0);
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void S192( )
      {
         /* 'ABRANGENCIAGEOGRAFICACOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavAbrangenciageograficaid.removeAllItems();
         cmbavAbrangenciageograficaid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007931 */
         pr_default.execute(29);
         while ( (pr_default.getStatus(29) != 101) )
         {
            A38AbrangenciaGeograficaAtivo = H007931_A38AbrangenciaGeograficaAtivo[0];
            A36AbrangenciaGeograficaId = H007931_A36AbrangenciaGeograficaId[0];
            A37AbrangenciaGeograficaNome = H007931_A37AbrangenciaGeograficaNome[0];
            cmbavAbrangenciageograficaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0)), A37AbrangenciaGeograficaNome, 0);
            pr_default.readNext(29);
         }
         pr_default.close(29);
      }

      protected void S202( )
      {
         /* 'FREQUENCIATRATAMENTOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavFrequenciatratamentoid.removeAllItems();
         cmbavFrequenciatratamentoid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007932 */
         pr_default.execute(30);
         while ( (pr_default.getStatus(30) != 101) )
         {
            A41FrequenciaTratamentoAtivo = H007932_A41FrequenciaTratamentoAtivo[0];
            A39FrequenciaTratamentoId = H007932_A39FrequenciaTratamentoId[0];
            A40FrequenciaTratamentoNome = H007932_A40FrequenciaTratamentoNome[0];
            cmbavFrequenciatratamentoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0)), A40FrequenciaTratamentoNome, 0);
            pr_default.readNext(30);
         }
         pr_default.close(30);
      }

      protected void S212( )
      {
         /* 'TIPODESCARTECOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavTipodescarteid.removeAllItems();
         cmbavTipodescarteid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007933 */
         pr_default.execute(31);
         while ( (pr_default.getStatus(31) != 101) )
         {
            A47TipoDescarteAtivo = H007933_A47TipoDescarteAtivo[0];
            A45TipoDescarteId = H007933_A45TipoDescarteId[0];
            A46TipoDescarteNome = H007933_A46TipoDescarteNome[0];
            cmbavTipodescarteid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0)), A46TipoDescarteNome, 0);
            pr_default.readNext(31);
         }
         pr_default.close(31);
      }

      protected void S222( )
      {
         /* 'TEMPORETENCAOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavTemporetencaoid.removeAllItems();
         cmbavTemporetencaoid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007934 */
         pr_default.execute(32);
         while ( (pr_default.getStatus(32) != 101) )
         {
            A50TempoRetencaoAtivo = H007934_A50TempoRetencaoAtivo[0];
            A48TempoRetencaoId = H007934_A48TempoRetencaoId[0];
            A49TempoRetencaoNome = H007934_A49TempoRetencaoNome[0];
            cmbavTemporetencaoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0)), A49TempoRetencaoNome, 0);
            pr_default.readNext(32);
         }
         pr_default.close(32);
      }

      protected void S242( )
      {
         /* 'MEDIDASEGURANCACOMBOCARREGA' Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E34792( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table12_241_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmedidasegurancainfo_Internalname, tblTablemergedmedidasegurancainfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMedidasegurancainfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblMedidasegurancainfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e35791_client"+"'", "", "TextBlock", 7, lblMedidasegurancainfo_Tooltiptext, lblMedidasegurancainfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMedidasegurancaadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblMedidasegurancaadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOMEDIDASEGURANCAADD\\'."+"'", "", "TextBlock", 5, "", lblMedidasegurancaadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table12_241_792e( true) ;
         }
         else
         {
            wb_table12_241_792e( false) ;
         }
      }

      protected void wb_table11_226_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedenvolvidoscoletainfo_Internalname, tblTablemergedenvolvidoscoletainfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnvolvidoscoletainfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblEnvolvidoscoletainfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e36791_client"+"'", "", "TextBlock", 7, lblEnvolvidoscoletainfo_Tooltiptext, lblEnvolvidoscoletainfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnvolvidoscoletaadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblEnvolvidoscoletaadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOENVOLVIDOSCOLETAADD\\'."+"'", "", "TextBlock", 5, "", lblEnvolvidoscoletaadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table11_226_792e( true) ;
         }
         else
         {
            wb_table11_226_792e( false) ;
         }
      }

      protected void wb_table10_211_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcompartinternoinfo_Internalname, tblTablemergedcompartinternoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCompartinternoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblCompartinternoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e37791_client"+"'", "", "TextBlock", 7, lblCompartinternoinfo_Tooltiptext, lblCompartinternoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCompartinternoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblCompartinternoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCOMPARTINTERNOADD\\'."+"'", "", "TextBlock", 5, "", lblCompartinternoadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_211_792e( true) ;
         }
         else
         {
            wb_table10_211_792e( false) ;
         }
      }

      protected void wb_table9_196_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsetorinternoinfo_Internalname, tblTablemergedsetorinternoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSetorinternoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblSetorinternoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e38791_client"+"'", "", "TextBlock", 7, lblSetorinternoinfo_Tooltiptext, lblSetorinternoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSetorinternoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblSetorinternoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSETORINTERNOADD\\'."+"'", "", "TextBlock", 5, "", lblSetorinternoadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_196_792e( true) ;
         }
         else
         {
            wb_table9_196_792e( false) ;
         }
      }

      protected void wb_table8_128_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtemporetencaoinfo_Internalname, tblTablemergedtemporetencaoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTemporetencaoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblTemporetencaoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e39791_client"+"'", "", "TextBlock", 7, lblTemporetencaoinfo_Tooltiptext, lblTemporetencaoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTemporetencaoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblTemporetencaoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOTEMPORETENCAOADD\\'."+"'", "", "TextBlock", 5, "", lblTemporetencaoadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_128_792e( true) ;
         }
         else
         {
            wb_table8_128_792e( false) ;
         }
      }

      protected void wb_table7_117_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtipodescarteinfo_Internalname, tblTablemergedtipodescarteinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTipodescarteinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblTipodescarteinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e40791_client"+"'", "", "TextBlock", 7, lblTipodescarteinfo_Tooltiptext, lblTipodescarteinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTipodescarteadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblTipodescarteadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOTIPODESCARTEADD\\'."+"'", "", "TextBlock", 5, "", lblTipodescarteadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_117_792e( true) ;
         }
         else
         {
            wb_table7_117_792e( false) ;
         }
      }

      protected void wb_table6_102_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedfonteretencaoinfo_Internalname, tblTablemergedfonteretencaoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFonteretencaoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblFonteretencaoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e41791_client"+"'", "", "TextBlock", 7, lblFonteretencaoinfo_Tooltiptext, lblFonteretencaoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFonteretencaoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblFonteretencaoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFONTERETENCAOADD\\'."+"'", "", "TextBlock", 5, "", lblFonteretencaoadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_102_792e( true) ;
         }
         else
         {
            wb_table6_102_792e( false) ;
         }
      }

      protected void wb_table5_87_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedfrequenciatratamentoinfo_Internalname, tblTablemergedfrequenciatratamentoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFrequenciatratamentoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblFrequenciatratamentoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e42791_client"+"'", "", "TextBlock", 7, lblFrequenciatratamentoinfo_Tooltiptext, lblFrequenciatratamentoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFrequenciatratamentoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblFrequenciatratamentoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFREQUENCIATRATAMENTOADD\\'."+"'", "", "TextBlock", 5, "", lblFrequenciatratamentoadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_87_792e( true) ;
         }
         else
         {
            wb_table5_87_792e( false) ;
         }
      }

      protected void wb_table4_75_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedabrangenciageograficainfo_Internalname, tblTablemergedabrangenciageograficainfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAbrangenciageograficainfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblAbrangenciageograficainfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e43791_client"+"'", "", "TextBlock", 7, lblAbrangenciageograficainfo_Tooltiptext, lblAbrangenciageograficainfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAbrangenciageograficaadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblAbrangenciageograficaadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOABRANGENCIAGEOGRAFICAADD\\'."+"'", "", "TextBlock", 5, "", lblAbrangenciageograficaadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_75_792e( true) ;
         }
         else
         {
            wb_table4_75_792e( false) ;
         }
      }

      protected void wb_table3_63_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedferramentacoletainfo_Internalname, tblTablemergedferramentacoletainfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFerramentacoletainfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblFerramentacoletainfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e44791_client"+"'", "", "TextBlock", 7, lblFerramentacoletainfo_Tooltiptext, lblFerramentacoletainfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFerramentacoletaadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblFerramentacoletaadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFERRAMENTACOLETAADD\\'."+"'", "", "TextBlock", 5, "", lblFerramentacoletaadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_63_792e( true) ;
         }
         else
         {
            wb_table3_63_792e( false) ;
         }
      }

      protected void wb_table2_51_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtipodadoinfo_Internalname, tblTablemergedtipodadoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTipodadoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblTipodadoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e45791_client"+"'", "", "TextBlock", 7, lblTipodadoinfo_Tooltiptext, lblTipodadoinfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTipodadoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblTipodadoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOTIPODADOADD\\'."+"'", "", "TextBlock", 5, "", lblTipodadoadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_51_792e( true) ;
         }
         else
         {
            wb_table2_51_792e( false) ;
         }
      }

      protected void wb_table1_40_792( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcategoriainfo_Internalname, tblTablemergedcategoriainfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCategoriainfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblCategoriainfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e46791_client"+"'", "", "TextBlock", 7, lblCategoriainfo_Tooltiptext, lblCategoriainfo_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCategoriaadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblCategoriaadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCATEGORIAADD\\'."+"'", "", "TextBlock", 5, "", lblCategoriaadd_Visible, 1, 0, 1, "HLP_TratamentoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_40_792e( true) ;
         }
         else
         {
            wb_table1_40_792e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV36DocumentoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV36DocumentoId", StringUtil.LTrimStr( (decimal)(AV36DocumentoId), 8, 0));
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
         PA792( ) ;
         WS792( ) ;
         WE792( ) ;
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
         sCtrlAV36DocumentoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA792( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "tratamentowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA792( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV36DocumentoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV36DocumentoId", StringUtil.LTrimStr( (decimal)(AV36DocumentoId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV36DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV36DocumentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV36DocumentoId != wcpOAV36DocumentoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV36DocumentoId = AV36DocumentoId;
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
         sCtrlAV36DocumentoId = cgiGet( sPrefix+"AV36DocumentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV36DocumentoId) > 0 )
         {
            AV36DocumentoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV36DocumentoId), ",", "."));
            AssignAttri(sPrefix, false, "AV36DocumentoId", StringUtil.LTrimStr( (decimal)(AV36DocumentoId), 8, 0));
         }
         else
         {
            AV36DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV36DocumentoId_PARM"), ",", "."));
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
         PA792( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS792( ) ;
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
         WS792( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV36DocumentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36DocumentoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV36DocumentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV36DocumentoId_CTRL", StringUtil.RTrim( sCtrlAV36DocumentoId));
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
         WE792( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231308391475", true, true);
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
         context.AddJavascriptSource("tratamentowc.js", "?20231308391475", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavCategoriaid.Name = "vCATEGORIAID";
         cmbavCategoriaid.WebTags = "";
         if ( cmbavCategoriaid.ItemCount > 0 )
         {
         }
         cmbavTipodadoid.Name = "vTIPODADOID";
         cmbavTipodadoid.WebTags = "";
         if ( cmbavTipodadoid.ItemCount > 0 )
         {
         }
         cmbavFerramentacoletaid.Name = "vFERRAMENTACOLETAID";
         cmbavFerramentacoletaid.WebTags = "";
         if ( cmbavFerramentacoletaid.ItemCount > 0 )
         {
         }
         cmbavAbrangenciageograficaid.Name = "vABRANGENCIAGEOGRAFICAID";
         cmbavAbrangenciageograficaid.WebTags = "";
         if ( cmbavAbrangenciageograficaid.ItemCount > 0 )
         {
         }
         cmbavFrequenciatratamentoid.Name = "vFREQUENCIATRATAMENTOID";
         cmbavFrequenciatratamentoid.WebTags = "";
         if ( cmbavFrequenciatratamentoid.ItemCount > 0 )
         {
         }
         cmbavTipodescarteid.Name = "vTIPODESCARTEID";
         cmbavTipodescarteid.WebTags = "";
         if ( cmbavTipodescarteid.ItemCount > 0 )
         {
         }
         cmbavTemporetencaoid.Name = "vTEMPORETENCAOID";
         cmbavTemporetencaoid.WebTags = "";
         if ( cmbavTemporetencaoid.ItemCount > 0 )
         {
         }
         cmbavDocumentoprevcoletadados.Name = "vDOCUMENTOPREVCOLETADADOS";
         cmbavDocumentoprevcoletadados.WebTags = "";
         cmbavDocumentoprevcoletadados.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbavDocumentoprevcoletadados.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbavDocumentoprevcoletadados.ItemCount > 0 )
         {
         }
         chkavDocumentodadosgrupovul.Name = "vDOCUMENTODADOSGRUPOVUL";
         chkavDocumentodadosgrupovul.WebTags = "";
         chkavDocumentodadosgrupovul.Caption = "";
         AssignProp(sPrefix, false, chkavDocumentodadosgrupovul_Internalname, "TitleCaption", chkavDocumentodadosgrupovul.Caption, true);
         chkavDocumentodadosgrupovul.CheckedValue = "false";
         chkavDocumentodadoscriancaadolesc.Name = "vDOCUMENTODADOSCRIANCAADOLESC";
         chkavDocumentodadoscriancaadolesc.WebTags = "";
         chkavDocumentodadoscriancaadolesc.Caption = "";
         AssignProp(sPrefix, false, chkavDocumentodadoscriancaadolesc_Internalname, "TitleCaption", chkavDocumentodadoscriancaadolesc.Caption, true);
         chkavDocumentodadoscriancaadolesc.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavDocumentofinalidadetratamento_Internalname = sPrefix+"vDOCUMENTOFINALIDADETRATAMENTO";
         lblFinalidadetratamentoinfo_Internalname = sPrefix+"FINALIDADETRATAMENTOINFO";
         lblTxtfinalidadetratamento_Internalname = sPrefix+"TXTFINALIDADETRATAMENTO";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         cmbavCategoriaid_Internalname = sPrefix+"vCATEGORIAID";
         lblCategoriainfo_Internalname = sPrefix+"CATEGORIAINFO";
         lblCategoriaadd_Internalname = sPrefix+"CATEGORIAADD";
         tblTablemergedcategoriainfo_Internalname = sPrefix+"TABLEMERGEDCATEGORIAINFO";
         cmbavTipodadoid_Internalname = sPrefix+"vTIPODADOID";
         lblTipodadoinfo_Internalname = sPrefix+"TIPODADOINFO";
         lblTipodadoadd_Internalname = sPrefix+"TIPODADOADD";
         tblTablemergedtipodadoinfo_Internalname = sPrefix+"TABLEMERGEDTIPODADOINFO";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         cmbavFerramentacoletaid_Internalname = sPrefix+"vFERRAMENTACOLETAID";
         lblFerramentacoletainfo_Internalname = sPrefix+"FERRAMENTACOLETAINFO";
         lblFerramentacoletaadd_Internalname = sPrefix+"FERRAMENTACOLETAADD";
         tblTablemergedferramentacoletainfo_Internalname = sPrefix+"TABLEMERGEDFERRAMENTACOLETAINFO";
         cmbavAbrangenciageograficaid_Internalname = sPrefix+"vABRANGENCIAGEOGRAFICAID";
         lblAbrangenciageograficainfo_Internalname = sPrefix+"ABRANGENCIAGEOGRAFICAINFO";
         lblAbrangenciageograficaadd_Internalname = sPrefix+"ABRANGENCIAGEOGRAFICAADD";
         tblTablemergedabrangenciageograficainfo_Internalname = sPrefix+"TABLEMERGEDABRANGENCIAGEOGRAFICAINFO";
         cmbavFrequenciatratamentoid_Internalname = sPrefix+"vFREQUENCIATRATAMENTOID";
         lblFrequenciatratamentoinfo_Internalname = sPrefix+"FREQUENCIATRATAMENTOINFO";
         lblFrequenciatratamentoadd_Internalname = sPrefix+"FREQUENCIATRATAMENTOADD";
         tblTablemergedfrequenciatratamentoinfo_Internalname = sPrefix+"TABLEMERGEDFREQUENCIATRATAMENTOINFO";
         lblTextblockcombo_fonteretencaoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_FONTERETENCAOID";
         Combo_fonteretencaoid_Internalname = sPrefix+"COMBO_FONTERETENCAOID";
         divTablesplittedfonteretencaoid_Internalname = sPrefix+"TABLESPLITTEDFONTERETENCAOID";
         lblFonteretencaoinfo_Internalname = sPrefix+"FONTERETENCAOINFO";
         lblFonteretencaoadd_Internalname = sPrefix+"FONTERETENCAOADD";
         tblTablemergedfonteretencaoinfo_Internalname = sPrefix+"TABLEMERGEDFONTERETENCAOINFO";
         cmbavTipodescarteid_Internalname = sPrefix+"vTIPODESCARTEID";
         lblTipodescarteinfo_Internalname = sPrefix+"TIPODESCARTEINFO";
         lblTipodescarteadd_Internalname = sPrefix+"TIPODESCARTEADD";
         tblTablemergedtipodescarteinfo_Internalname = sPrefix+"TABLEMERGEDTIPODESCARTEINFO";
         cmbavTemporetencaoid_Internalname = sPrefix+"vTEMPORETENCAOID";
         lblTemporetencaoinfo_Internalname = sPrefix+"TEMPORETENCAOINFO";
         lblTemporetencaoadd_Internalname = sPrefix+"TEMPORETENCAOADD";
         tblTablemergedtemporetencaoinfo_Internalname = sPrefix+"TABLEMERGEDTEMPORETENCAOINFO";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         cmbavDocumentoprevcoletadados_Internalname = sPrefix+"vDOCUMENTOPREVCOLETADADOS";
         lblPrevcoletadadosinfo_Internalname = sPrefix+"PREVCOLETADADOSINFO";
         edtavDocumentobaselegalnorm_Internalname = sPrefix+"vDOCUMENTOBASELEGALNORM";
         lblBaselegalnorminfo_Internalname = sPrefix+"BASELEGALNORMINFO";
         lblTxtbaselegalnorm_Internalname = sPrefix+"TXTBASELEGALNORM";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         edtavDocumentobaselegalnormintext_Internalname = sPrefix+"vDOCUMENTOBASELEGALNORMINTEXT";
         lblBaselegalnormintextinfo_Internalname = sPrefix+"BASELEGALNORMINTEXTINFO";
         lblTxtbaselegalnormext_Internalname = sPrefix+"TXTBASELEGALNORMEXT";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         chkavDocumentodadosgrupovul_Internalname = sPrefix+"vDOCUMENTODADOSGRUPOVUL";
         lblDadosgrupovulinfo_Internalname = sPrefix+"DADOSGRUPOVULINFO";
         chkavDocumentodadoscriancaadolesc_Internalname = sPrefix+"vDOCUMENTODADOSCRIANCAADOLESC";
         lblDadoscriancaadolescinfo_Internalname = sPrefix+"DADOSCRIANCAADOLESCINFO";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         lblTextblockcombo_setorinternoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SETORINTERNOID";
         Combo_setorinternoid_Internalname = sPrefix+"COMBO_SETORINTERNOID";
         divTablesplittedsetorinternoid_Internalname = sPrefix+"TABLESPLITTEDSETORINTERNOID";
         lblSetorinternoinfo_Internalname = sPrefix+"SETORINTERNOINFO";
         lblSetorinternoadd_Internalname = sPrefix+"SETORINTERNOADD";
         tblTablemergedsetorinternoinfo_Internalname = sPrefix+"TABLEMERGEDSETORINTERNOINFO";
         lblTextblockcombo_compartinternoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_COMPARTINTERNOID";
         Combo_compartinternoid_Internalname = sPrefix+"COMBO_COMPARTINTERNOID";
         divTablesplittedcompartinternoid_Internalname = sPrefix+"TABLESPLITTEDCOMPARTINTERNOID";
         lblCompartinternoinfo_Internalname = sPrefix+"COMPARTINTERNOINFO";
         lblCompartinternoadd_Internalname = sPrefix+"COMPARTINTERNOADD";
         tblTablemergedcompartinternoinfo_Internalname = sPrefix+"TABLEMERGEDCOMPARTINTERNOINFO";
         lblTextblockcombo_envolvidoscoletaid_Internalname = sPrefix+"TEXTBLOCKCOMBO_ENVOLVIDOSCOLETAID";
         Combo_envolvidoscoletaid_Internalname = sPrefix+"COMBO_ENVOLVIDOSCOLETAID";
         divTablesplittedenvolvidoscoletaid_Internalname = sPrefix+"TABLESPLITTEDENVOLVIDOSCOLETAID";
         lblEnvolvidoscoletainfo_Internalname = sPrefix+"ENVOLVIDOSCOLETAINFO";
         lblEnvolvidoscoletaadd_Internalname = sPrefix+"ENVOLVIDOSCOLETAADD";
         tblTablemergedenvolvidoscoletainfo_Internalname = sPrefix+"TABLEMERGEDENVOLVIDOSCOLETAINFO";
         lblTextblockcombo_medidasegurancaid_Internalname = sPrefix+"TEXTBLOCKCOMBO_MEDIDASEGURANCAID";
         Combo_medidasegurancaid_Internalname = sPrefix+"COMBO_MEDIDASEGURANCAID";
         divTablesplittedmedidasegurancaid_Internalname = sPrefix+"TABLESPLITTEDMEDIDASEGURANCAID";
         lblMedidasegurancainfo_Internalname = sPrefix+"MEDIDASEGURANCAINFO";
         lblMedidasegurancaadd_Internalname = sPrefix+"MEDIDASEGURANCAADD";
         tblTablemergedmedidasegurancainfo_Internalname = sPrefix+"TABLEMERGEDMEDIDASEGURANCAINFO";
         edtavDocumentomedidasegurancadesc_Internalname = sPrefix+"vDOCUMENTOMEDIDASEGURANCADESC";
         lblMedidasegurancadescinfo_Internalname = sPrefix+"MEDIDASEGURANCADESCINFO";
         lblTxtmedidasegurancadesc_Internalname = sPrefix+"TXTMEDIDASEGURANCADESC";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         Documentofluxotratdadosdesc_Internalname = sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC";
         lblFluxotratdadosdescinfo_Internalname = sPrefix+"FLUXOTRATDADOSDESCINFO";
         lblTxtfluxotratdados_Internalname = sPrefix+"TXTFLUXOTRATDADOS";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         bttBtnsalvar_Internalname = sPrefix+"BTNSALVAR";
         divTabletratamento_Internalname = sPrefix+"TABLETRATAMENTO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain1_Internalname = sPrefix+"TABLEMAIN1";
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
         chkavDocumentodadoscriancaadolesc.Caption = "POSSUI DADOS DE CRIANÇA/ADOLESCENTE";
         chkavDocumentodadosgrupovul.Caption = "POSSUI DADOS DE GRUPOS VULNERÁVEIS";
         lblCategoriaadd_Visible = 1;
         lblCategoriainfo_Visible = 1;
         lblTipodadoadd_Visible = 1;
         lblTipodadoinfo_Visible = 1;
         lblFerramentacoletaadd_Visible = 1;
         lblFerramentacoletainfo_Visible = 1;
         lblAbrangenciageograficaadd_Visible = 1;
         lblAbrangenciageograficainfo_Visible = 1;
         lblFrequenciatratamentoadd_Visible = 1;
         lblFrequenciatratamentoinfo_Visible = 1;
         lblFonteretencaoadd_Visible = 1;
         lblFonteretencaoinfo_Visible = 1;
         lblTipodescarteadd_Visible = 1;
         lblTipodescarteinfo_Visible = 1;
         lblTemporetencaoadd_Visible = 1;
         lblTemporetencaoinfo_Visible = 1;
         lblSetorinternoadd_Visible = 1;
         lblSetorinternoinfo_Visible = 1;
         lblCompartinternoadd_Visible = 1;
         lblCompartinternoinfo_Visible = 1;
         lblEnvolvidoscoletaadd_Visible = 1;
         lblEnvolvidoscoletainfo_Visible = 1;
         lblMedidasegurancaadd_Visible = 1;
         lblMedidasegurancainfo_Visible = 1;
         lblMedidasegurancainfo_Tooltiptext = "";
         lblEnvolvidoscoletainfo_Tooltiptext = "";
         lblCompartinternoinfo_Tooltiptext = "";
         lblSetorinternoinfo_Tooltiptext = "";
         lblTemporetencaoinfo_Tooltiptext = "";
         lblTipodescarteinfo_Tooltiptext = "";
         lblFonteretencaoinfo_Tooltiptext = "";
         lblFrequenciatratamentoinfo_Tooltiptext = "";
         lblAbrangenciageograficainfo_Tooltiptext = "";
         lblFerramentacoletainfo_Tooltiptext = "";
         lblTipodadoinfo_Tooltiptext = "";
         lblCategoriainfo_Tooltiptext = "";
         bttBtnsalvar_Visible = 1;
         lblFluxotratdadosdescinfo_Tooltiptext = "";
         lblFluxotratdadosdescinfo_Visible = 1;
         Documentofluxotratdadosdesc_Enabled = Convert.ToBoolean( 1);
         lblTxtmedidasegurancadesc_Caption = "0/10000";
         lblMedidasegurancadescinfo_Tooltiptext = "";
         lblMedidasegurancadescinfo_Visible = 1;
         edtavDocumentomedidasegurancadesc_Enabled = 1;
         Combo_medidasegurancaid_Caption = "";
         Combo_envolvidoscoletaid_Caption = "";
         Combo_compartinternoid_Caption = "";
         Combo_setorinternoid_Caption = "";
         lblDadoscriancaadolescinfo_Tooltiptext = "";
         lblDadoscriancaadolescinfo_Visible = 1;
         chkavDocumentodadoscriancaadolesc.Enabled = 1;
         lblDadosgrupovulinfo_Tooltiptext = "";
         lblDadosgrupovulinfo_Visible = 1;
         chkavDocumentodadosgrupovul.Enabled = 1;
         lblTxtbaselegalnormext_Caption = "0/100";
         lblBaselegalnormintextinfo_Tooltiptext = "";
         lblBaselegalnormintextinfo_Visible = 1;
         edtavDocumentobaselegalnormintext_Jsonclick = "";
         edtavDocumentobaselegalnormintext_Enabled = 1;
         lblTxtbaselegalnorm_Caption = "0/100";
         lblBaselegalnorminfo_Tooltiptext = "";
         lblBaselegalnorminfo_Visible = 1;
         edtavDocumentobaselegalnorm_Jsonclick = "";
         edtavDocumentobaselegalnorm_Enabled = 1;
         lblPrevcoletadadosinfo_Tooltiptext = "";
         lblPrevcoletadadosinfo_Visible = 1;
         cmbavDocumentoprevcoletadados_Jsonclick = "";
         cmbavDocumentoprevcoletadados.Enabled = 1;
         cmbavTemporetencaoid_Jsonclick = "";
         cmbavTemporetencaoid.Enabled = 1;
         cmbavTipodescarteid_Jsonclick = "";
         cmbavTipodescarteid.Enabled = 1;
         Combo_fonteretencaoid_Caption = "";
         cmbavFrequenciatratamentoid_Jsonclick = "";
         cmbavFrequenciatratamentoid.Enabled = 1;
         cmbavAbrangenciageograficaid_Jsonclick = "";
         cmbavAbrangenciageograficaid.Enabled = 1;
         cmbavFerramentacoletaid_Jsonclick = "";
         cmbavFerramentacoletaid.Enabled = 1;
         cmbavTipodadoid_Jsonclick = "";
         cmbavTipodadoid.Enabled = 1;
         cmbavCategoriaid_Jsonclick = "";
         cmbavCategoriaid.Enabled = 1;
         lblTxtfinalidadetratamento_Caption = "0/100";
         lblFinalidadetratamentoinfo_Tooltiptext = "";
         lblFinalidadetratamentoinfo_Visible = 1;
         edtavDocumentofinalidadetratamento_Jsonclick = "";
         edtavDocumentofinalidadetratamento_Enabled = 1;
         Documentofluxotratdadosdesc_Captionposition = "None";
         Documentofluxotratdadosdesc_Captionstyle = "";
         Documentofluxotratdadosdesc_Captionclass = "col-sm-3 FCKEditorClassLabel";
         Documentofluxotratdadosdesc_Height = "350";
         Documentofluxotratdadosdesc_Width = "67vw";
         Combo_medidasegurancaid_Multiplevaluestype = "Tags";
         Combo_medidasegurancaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_medidasegurancaid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_medidasegurancaid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_medidasegurancaid_Enabled = Convert.ToBoolean( -1);
         Combo_medidasegurancaid_Cls = "ExtendedCombo AttributeFL";
         Combo_envolvidoscoletaid_Emptyitemtext = "(SELECIONE)";
         Combo_envolvidoscoletaid_Multiplevaluestype = "Tags";
         Combo_envolvidoscoletaid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_envolvidoscoletaid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_envolvidoscoletaid_Enabled = Convert.ToBoolean( -1);
         Combo_envolvidoscoletaid_Cls = "ExtendedCombo AttributeFL";
         Combo_compartinternoid_Emptyitemtext = "(SELECIONE)";
         Combo_compartinternoid_Multiplevaluestype = "Tags";
         Combo_compartinternoid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_compartinternoid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_compartinternoid_Enabled = Convert.ToBoolean( -1);
         Combo_compartinternoid_Cls = "ExtendedCombo AttributeFL";
         Combo_setorinternoid_Emptyitemtext = "(SELECIONE)";
         Combo_setorinternoid_Multiplevaluestype = "Tags";
         Combo_setorinternoid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_setorinternoid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_setorinternoid_Enabled = Convert.ToBoolean( -1);
         Combo_setorinternoid_Cls = "ExtendedCombo AttributeFL";
         Combo_fonteretencaoid_Emptyitemtext = "(SELECIONE)";
         Combo_fonteretencaoid_Multiplevaluestype = "Tags";
         Combo_fonteretencaoid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_fonteretencaoid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_fonteretencaoid_Enabled = Convert.ToBoolean( -1);
         Combo_fonteretencaoid_Cls = "ExtendedCombo AttributeFL";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV52IsCategoria',fld:'vISCATEGORIA',pic:''},{av:'AV51CategoriaId_Out',fld:'vCATEGORIAID_OUT',pic:'ZZZZZZZ9'},{av:'AV53IsTipoDado',fld:'vISTIPODADO',pic:''},{av:'AV54TipoDadoId_Out',fld:'vTIPODADOID_OUT',pic:'ZZZZZZZ9'},{av:'AV55IsFerramentaColeta',fld:'vISFERRAMENTACOLETA',pic:''},{av:'AV56FerramentaColetaId_Out',fld:'vFERRAMENTACOLETAID_OUT',pic:'ZZZZZZZ9'},{av:'AV57IsAbrangenciaGeografica',fld:'vISABRANGENCIAGEOGRAFICA',pic:''},{av:'AV58AbrangenciaGeograficaId_Out',fld:'vABRANGENCIAGEOGRAFICAID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsFonteRetencao',fld:'vISFONTERETENCAO',pic:''},{av:'Combo_fonteretencaoid_Selectedvalue_get',ctrl:'COMBO_FONTERETENCAOID',prop:'SelectedValue_get'},{av:'AV46FonteRetencaoId_Col',fld:'vFONTERETENCAOID_COL',pic:''},{av:'AV59FonteRetencaoId_Out',fld:'vFONTERETENCAOID_OUT',pic:'ZZZ9'},{av:'AV61IsFrequenciaTratamento',fld:'vISFREQUENCIATRATAMENTO',pic:''},{av:'AV62FrequenciaTratamentoId_Out',fld:'vFREQUENCIATRATAMENTOID_OUT',pic:'ZZZ9'},{av:'AV63IsTipoDescarte',fld:'vISTIPODESCARTE',pic:''},{av:'AV64TipoDescarteId_Out',fld:'vTIPODESCARTEID_OUT',pic:'ZZZZZZZ9'},{av:'AV65IsTempoRetencao',fld:'vISTEMPORETENCAO',pic:''},{av:'AV66TempoRetencaoId_Out',fld:'vTEMPORETENCAOID_OUT',pic:'ZZZZZZZ9'},{av:'AV67IsSetorInterno',fld:'vISSETORINTERNO',pic:''},{av:'Combo_setorinternoid_Selectedvalue_get',ctrl:'COMBO_SETORINTERNOID',prop:'SelectedValue_get'},{av:'AV48SetorInternoId_Col',fld:'vSETORINTERNOID_COL',pic:''},{av:'AV68SetorInternoId_Out',fld:'vSETORINTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV69IsCompartInterno',fld:'vISCOMPARTINTERNO',pic:''},{av:'Combo_compartinternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTINTERNOID',prop:'SelectedValue_get'},{av:'AV47CompartInternoId_Col',fld:'vCOMPARTINTERNOID_COL',pic:''},{av:'AV70CompartInternoId_Out',fld:'vCOMPARTINTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV71IsEnvolvidosColeta',fld:'vISENVOLVIDOSCOLETA',pic:''},{av:'Combo_envolvidoscoletaid_Selectedvalue_get',ctrl:'COMBO_ENVOLVIDOSCOLETAID',prop:'SelectedValue_get'},{av:'AV49EnvolvidosColetaId_Col',fld:'vENVOLVIDOSCOLETAID_COL',pic:''},{av:'AV72EnvolvidosColetaId_Out',fld:'vENVOLVIDOSCOLETAID_OUT',pic:'ZZZZZZZ9'},{av:'AV73IsMedidaSeguranca',fld:'vISMEDIDASEGURANCA',pic:''},{av:'Combo_medidasegurancaid_Selectedvalue_get',ctrl:'COMBO_MEDIDASEGURANCAID',prop:'SelectedValue_get'},{av:'AV89MedidaSegurancaId_Col',fld:'vMEDIDASEGURANCAID_COL',pic:''},{av:'AV74MedidaSegurancaId_Out',fld:'vMEDIDASEGURANCAID_OUT',pic:'ZZZZZZZ9'},{av:'A28CategoriaNome',fld:'CATEGORIANOME',pic:''},{av:'A29CategoriaAtivo',fld:'CATEGORIAATIVO',pic:''},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'A31TipoDadoNome',fld:'TIPODADONOME',pic:''},{av:'A32TipoDadoAtivo',fld:'TIPODADOATIVO',pic:''},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'A34FerramentaColetaNome',fld:'FERRAMENTACOLETANOME',pic:''},{av:'A35FerramentaColetaAtivo',fld:'FERRAMENTACOLETAATIVO',pic:''},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'A37AbrangenciaGeograficaNome',fld:'ABRANGENCIAGEOGRAFICANOME',pic:''},{av:'A38AbrangenciaGeograficaAtivo',fld:'ABRANGENCIAGEOGRAFICAATIVO',pic:''},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'A64FonteRetencaoNome',fld:'FONTERETENCAONOME',pic:''},{av:'A65FonteRetencaoAtivo',fld:'FONTERETENCAOATIVO',pic:''},{av:'A63FonteRetencaoId',fld:'FONTERETENCAOID',pic:'ZZZZZZZ9'},{av:'AV24FonteRetencaoId',fld:'vFONTERETENCAOID',pic:''},{av:'A40FrequenciaTratamentoNome',fld:'FREQUENCIATRATAMENTONOME',pic:''},{av:'A41FrequenciaTratamentoAtivo',fld:'FREQUENCIATRATAMENTOATIVO',pic:''},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'A46TipoDescarteNome',fld:'TIPODESCARTENOME',pic:''},{av:'A47TipoDescarteAtivo',fld:'TIPODESCARTEATIVO',pic:''},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'A49TempoRetencaoNome',fld:'TEMPORETENCAONOME',pic:''},{av:'A50TempoRetencaoAtivo',fld:'TEMPORETENCAOATIVO',pic:''},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'A61SetorInternoNome',fld:'SETORINTERNONOME',pic:''},{av:'A62SetorInternoAtivo',fld:'SETORINTERNOATIVO',pic:''},{av:'A60SetorInternoId',fld:'SETORINTERNOID',pic:'ZZZZZZZ9'},{av:'AV28SetorInternoId',fld:'vSETORINTERNOID',pic:''},{av:'A58CompartInternoNome',fld:'COMPARTINTERNONOME',pic:''},{av:'A59CompartInternoAtivo',fld:'COMPARTINTERNOATIVO',pic:''},{av:'A57CompartInternoId',fld:'COMPARTINTERNOID',pic:'ZZZZZZZ9'},{av:'AV32CompartInternoId_Data',fld:'vCOMPARTINTERNOID_DATA',pic:''},{av:'AV29CompartInternoId',fld:'vCOMPARTINTERNOID',pic:''},{av:'A55EnvolvidosColetaNome',fld:'ENVOLVIDOSCOLETANOME',pic:''},{av:'A56EnvolvidosColetaAtivo',fld:'ENVOLVIDOSCOLETAATIVO',pic:''},{av:'A54EnvolvidosColetaId',fld:'ENVOLVIDOSCOLETAID',pic:'ZZZZZZZ9'},{av:'AV33EnvolvidosColetaId_Data',fld:'vENVOLVIDOSCOLETAID_DATA',pic:''},{av:'AV30EnvolvidosColetaId',fld:'vENVOLVIDOSCOLETAID',pic:''},{av:'A52MedidaSegurancaNome',fld:'MEDIDASEGURANCANOME',pic:''},{av:'A53MedidaSegurancaAtivo',fld:'MEDIDASEGURANCAATIVO',pic:''},{av:'A51MedidaSegurancaId',fld:'MEDIDASEGURANCAID',pic:'ZZZZZZZ9'},{av:'AV88MedidaSegurancaId_Data',fld:'vMEDIDASEGURANCAID_DATA',pic:''},{av:'AV20MedidaSegurancaId',fld:'vMEDIDASEGURANCAID',pic:''},{av:'AV18DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV19DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavCategoriaid'},{av:'AV8CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'AV52IsCategoria',fld:'vISCATEGORIA',pic:''},{av:'AV51CategoriaId_Out',fld:'vCATEGORIAID_OUT',pic:'ZZZZZZZ9'},{av:'cmbavTipodadoid'},{av:'AV9TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'AV53IsTipoDado',fld:'vISTIPODADO',pic:''},{av:'AV54TipoDadoId_Out',fld:'vTIPODADOID_OUT',pic:'ZZZZZZZ9'},{av:'cmbavFerramentacoletaid'},{av:'AV10FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'AV55IsFerramentaColeta',fld:'vISFERRAMENTACOLETA',pic:''},{av:'AV56FerramentaColetaId_Out',fld:'vFERRAMENTACOLETAID_OUT',pic:'ZZZZZZZ9'},{av:'cmbavAbrangenciageograficaid'},{av:'AV11AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'AV57IsAbrangenciaGeografica',fld:'vISABRANGENCIAGEOGRAFICA',pic:''},{av:'AV58AbrangenciaGeograficaId_Out',fld:'vABRANGENCIAGEOGRAFICAID_OUT',pic:'ZZZZZZZ9'},{av:'AV24FonteRetencaoId',fld:'vFONTERETENCAOID',pic:''},{av:'AV42FonteRetencaoId_Item',fld:'vFONTERETENCAOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV46FonteRetencaoId_Col',fld:'vFONTERETENCAOID_COL',pic:''},{av:'Combo_fonteretencaoid_Selectedvalue_set',ctrl:'COMBO_FONTERETENCAOID',prop:'SelectedValue_set'},{av:'AV59FonteRetencaoId_Out',fld:'vFONTERETENCAOID_OUT',pic:'ZZZ9'},{av:'AV60IsFonteRetencao',fld:'vISFONTERETENCAO',pic:''},{av:'cmbavFrequenciatratamentoid'},{av:'AV12FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV61IsFrequenciaTratamento',fld:'vISFREQUENCIATRATAMENTO',pic:''},{av:'AV62FrequenciaTratamentoId_Out',fld:'vFREQUENCIATRATAMENTOID_OUT',pic:'ZZZ9'},{av:'cmbavTipodescarteid'},{av:'AV13TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'AV64TipoDescarteId_Out',fld:'vTIPODESCARTEID_OUT',pic:'ZZZZZZZ9'},{av:'cmbavTemporetencaoid'},{av:'AV14TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'AV65IsTempoRetencao',fld:'vISTEMPORETENCAO',pic:''},{av:'AV66TempoRetencaoId_Out',fld:'vTEMPORETENCAOID_OUT',pic:'ZZZZZZZ9'},{av:'AV28SetorInternoId',fld:'vSETORINTERNOID',pic:''},{av:'AV43SetorInternoId_Item',fld:'vSETORINTERNOID_ITEM',pic:'ZZZ9'},{av:'AV48SetorInternoId_Col',fld:'vSETORINTERNOID_COL',pic:''},{av:'Combo_setorinternoid_Selectedvalue_set',ctrl:'COMBO_SETORINTERNOID',prop:'SelectedValue_set'},{av:'AV68SetorInternoId_Out',fld:'vSETORINTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV67IsSetorInterno',fld:'vISSETORINTERNO',pic:''},{av:'AV29CompartInternoId',fld:'vCOMPARTINTERNOID',pic:''},{av:'AV38CompartInternoId_Item',fld:'vCOMPARTINTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV47CompartInternoId_Col',fld:'vCOMPARTINTERNOID_COL',pic:''},{av:'Combo_compartinternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTINTERNOID',prop:'SelectedValue_set'},{av:'AV70CompartInternoId_Out',fld:'vCOMPARTINTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV69IsCompartInterno',fld:'vISCOMPARTINTERNO',pic:''},{av:'AV30EnvolvidosColetaId',fld:'vENVOLVIDOSCOLETAID',pic:''},{av:'AV41EnvolvidosColetaId_Item',fld:'vENVOLVIDOSCOLETAID_ITEM',pic:'ZZZZZZZ9'},{av:'AV49EnvolvidosColetaId_Col',fld:'vENVOLVIDOSCOLETAID_COL',pic:''},{av:'Combo_envolvidoscoletaid_Selectedvalue_set',ctrl:'COMBO_ENVOLVIDOSCOLETAID',prop:'SelectedValue_set'},{av:'AV72EnvolvidosColetaId_Out',fld:'vENVOLVIDOSCOLETAID_OUT',pic:'ZZZZZZZ9'},{av:'AV71IsEnvolvidosColeta',fld:'vISENVOLVIDOSCOLETA',pic:''},{av:'AV20MedidaSegurancaId',fld:'vMEDIDASEGURANCAID',pic:''},{av:'AV90MedidaSegurancaId_Item',fld:'vMEDIDASEGURANCAID_ITEM',pic:'ZZZZZZZ9'},{av:'AV89MedidaSegurancaId_Col',fld:'vMEDIDASEGURANCAID_COL',pic:''},{av:'Combo_medidasegurancaid_Selectedvalue_set',ctrl:'COMBO_MEDIDASEGURANCAID',prop:'SelectedValue_set'},{av:'AV74MedidaSegurancaId_Out',fld:'vMEDIDASEGURANCAID_OUT',pic:'ZZZZZZZ9'},{av:'AV73IsMedidaSeguranca',fld:'vISMEDIDASEGURANCA',pic:''},{av:'AV25FonteRetencaoId_Data',fld:'vFONTERETENCAOID_DATA',pic:''},{av:'AV31SetorInternoId_Data',fld:'vSETORINTERNOID_DATA',pic:''},{av:'AV32CompartInternoId_Data',fld:'vCOMPARTINTERNOID_DATA',pic:''},{av:'AV33EnvolvidosColetaId_Data',fld:'vENVOLVIDOSCOLETAID_DATA',pic:''},{av:'AV88MedidaSegurancaId_Data',fld:'vMEDIDASEGURANCAID_DATA',pic:''},{av:'lblFerramentacoletaadd_Visible',ctrl:'FERRAMENTACOLETAADD',prop:'Visible'},{av:'lblAbrangenciageograficaadd_Visible',ctrl:'ABRANGENCIAGEOGRAFICAADD',prop:'Visible'},{av:'lblFrequenciatratamentoadd_Visible',ctrl:'FREQUENCIATRATAMENTOADD',prop:'Visible'},{av:'lblFonteretencaoadd_Visible',ctrl:'FONTERETENCAOADD',prop:'Visible'},{av:'lblSetorinternoadd_Visible',ctrl:'SETORINTERNOADD',prop:'Visible'},{av:'lblCompartinternoadd_Visible',ctrl:'COMPARTINTERNOADD',prop:'Visible'},{av:'lblEnvolvidoscoletaadd_Visible',ctrl:'ENVOLVIDOSCOLETAADD',prop:'Visible'},{av:'lblMedidasegurancaadd_Visible',ctrl:'MEDIDASEGURANCAADD',prop:'Visible'},{ctrl:'BTNSALVAR',prop:'Visible'},{av:'lblTipodescarteadd_Visible',ctrl:'TIPODESCARTEADD',prop:'Visible'},{av:'lblTemporetencaoadd_Visible',ctrl:'TEMPORETENCAOADD',prop:'Visible'},{av:'lblCategoriaadd_Visible',ctrl:'CATEGORIAADD',prop:'Visible'},{av:'lblTipodadoadd_Visible',ctrl:'TIPODADOADD',prop:'Visible'}]}");
         setEventMetadata("'DOFINALIDADETRATAMENTOINFO'","{handler:'E11791',iparms:[]");
         setEventMetadata("'DOFINALIDADETRATAMENTOINFO'",",oparms:[]}");
         setEventMetadata("'DOFERRAMENTACOLETAINFO'","{handler:'E44791',iparms:[]");
         setEventMetadata("'DOFERRAMENTACOLETAINFO'",",oparms:[]}");
         setEventMetadata("'DOFERRAMENTACOLETAADD'","{handler:'E21792',iparms:[]");
         setEventMetadata("'DOFERRAMENTACOLETAADD'",",oparms:[{av:'AV56FerramentaColetaId_Out',fld:'vFERRAMENTACOLETAID_OUT',pic:'ZZZZZZZ9'},{av:'AV55IsFerramentaColeta',fld:'vISFERRAMENTACOLETA',pic:''}]}");
         setEventMetadata("'DOABRANGENCIAGEOGRAFICAINFO'","{handler:'E43791',iparms:[]");
         setEventMetadata("'DOABRANGENCIAGEOGRAFICAINFO'",",oparms:[]}");
         setEventMetadata("'DOABRANGENCIAGEOGRAFICAADD'","{handler:'E22792',iparms:[]");
         setEventMetadata("'DOABRANGENCIAGEOGRAFICAADD'",",oparms:[{av:'AV58AbrangenciaGeograficaId_Out',fld:'vABRANGENCIAGEOGRAFICAID_OUT',pic:'ZZZZZZZ9'},{av:'AV57IsAbrangenciaGeografica',fld:'vISABRANGENCIAGEOGRAFICA',pic:''}]}");
         setEventMetadata("'DOFREQUENCIATRATAMENTOINFO'","{handler:'E42791',iparms:[]");
         setEventMetadata("'DOFREQUENCIATRATAMENTOINFO'",",oparms:[]}");
         setEventMetadata("'DOFREQUENCIATRATAMENTOADD'","{handler:'E23792',iparms:[]");
         setEventMetadata("'DOFREQUENCIATRATAMENTOADD'",",oparms:[{av:'AV62FrequenciaTratamentoId_Out',fld:'vFREQUENCIATRATAMENTOID_OUT',pic:'ZZZ9'},{av:'AV61IsFrequenciaTratamento',fld:'vISFREQUENCIATRATAMENTO',pic:''}]}");
         setEventMetadata("'DOFONTERETENCAOINFO'","{handler:'E41791',iparms:[]");
         setEventMetadata("'DOFONTERETENCAOINFO'",",oparms:[]}");
         setEventMetadata("'DOFONTERETENCAOADD'","{handler:'E24792',iparms:[]");
         setEventMetadata("'DOFONTERETENCAOADD'",",oparms:[{av:'AV59FonteRetencaoId_Out',fld:'vFONTERETENCAOID_OUT',pic:'ZZZ9'},{av:'AV60IsFonteRetencao',fld:'vISFONTERETENCAO',pic:''}]}");
         setEventMetadata("'DOPREVCOLETADADOSINFO'","{handler:'E12791',iparms:[]");
         setEventMetadata("'DOPREVCOLETADADOSINFO'",",oparms:[]}");
         setEventMetadata("'DOBASELEGALNORMINFO'","{handler:'E13791',iparms:[]");
         setEventMetadata("'DOBASELEGALNORMINFO'",",oparms:[]}");
         setEventMetadata("'DOBASELEGALNORMINTEXTINFO'","{handler:'E14791',iparms:[]");
         setEventMetadata("'DOBASELEGALNORMINTEXTINFO'",",oparms:[]}");
         setEventMetadata("'DOSETORINTERNOINFO'","{handler:'E38791',iparms:[]");
         setEventMetadata("'DOSETORINTERNOINFO'",",oparms:[]}");
         setEventMetadata("'DOSETORINTERNOADD'","{handler:'E25792',iparms:[]");
         setEventMetadata("'DOSETORINTERNOADD'",",oparms:[{av:'AV68SetorInternoId_Out',fld:'vSETORINTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV67IsSetorInterno',fld:'vISSETORINTERNO',pic:''}]}");
         setEventMetadata("'DOCOMPARTINTERNOINFO'","{handler:'E37791',iparms:[]");
         setEventMetadata("'DOCOMPARTINTERNOINFO'",",oparms:[]}");
         setEventMetadata("'DOCOMPARTINTERNOADD'","{handler:'E26792',iparms:[]");
         setEventMetadata("'DOCOMPARTINTERNOADD'",",oparms:[{av:'AV70CompartInternoId_Out',fld:'vCOMPARTINTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV69IsCompartInterno',fld:'vISCOMPARTINTERNO',pic:''}]}");
         setEventMetadata("'DOENVOLVIDOSCOLETAINFO'","{handler:'E36791',iparms:[]");
         setEventMetadata("'DOENVOLVIDOSCOLETAINFO'",",oparms:[]}");
         setEventMetadata("'DOENVOLVIDOSCOLETAADD'","{handler:'E27792',iparms:[]");
         setEventMetadata("'DOENVOLVIDOSCOLETAADD'",",oparms:[{av:'AV72EnvolvidosColetaId_Out',fld:'vENVOLVIDOSCOLETAID_OUT',pic:'ZZZZZZZ9'},{av:'AV71IsEnvolvidosColeta',fld:'vISENVOLVIDOSCOLETA',pic:''}]}");
         setEventMetadata("'DOMEDIDASEGURANCAINFO'","{handler:'E35791',iparms:[]");
         setEventMetadata("'DOMEDIDASEGURANCAINFO'",",oparms:[]}");
         setEventMetadata("'DOMEDIDASEGURANCAADD'","{handler:'E28792',iparms:[]");
         setEventMetadata("'DOMEDIDASEGURANCAADD'",",oparms:[{av:'AV74MedidaSegurancaId_Out',fld:'vMEDIDASEGURANCAID_OUT',pic:'ZZZZZZZ9'},{av:'AV73IsMedidaSeguranca',fld:'vISMEDIDASEGURANCA',pic:''}]}");
         setEventMetadata("'DOMEDIDASEGURANCADESCINFO'","{handler:'E17791',iparms:[]");
         setEventMetadata("'DOMEDIDASEGURANCADESCINFO'",",oparms:[]}");
         setEventMetadata("'DOFLUXOTRATDADOSDESCINFO'","{handler:'E18791',iparms:[]");
         setEventMetadata("'DOFLUXOTRATDADOSDESCINFO'",",oparms:[]}");
         setEventMetadata("'DOSALVAR'","{handler:'E29792',iparms:[{av:'cmbavAbrangenciageograficaid'},{av:'AV11AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'AV34Documento',fld:'vDOCUMENTO',pic:''},{av:'cmbavCategoriaid'},{av:'AV8CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'AV16DocumentoBaseLegalNorm',fld:'vDOCUMENTOBASELEGALNORM',pic:''},{av:'AV17DocumentoBaseLegalNormIntExt',fld:'vDOCUMENTOBASELEGALNORMINTEXT',pic:''},{av:'AV19DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV18DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV7DocumentoFinalidadeTratamento',fld:'vDOCUMENTOFINALIDADETRATAMENTO',pic:''},{av:'AV22DocumentoFluxoTratDadosDesc',fld:'vDOCUMENTOFLUXOTRATDADOSDESC',pic:''},{av:'AV21DocumentoMedidaSegurancaDesc',fld:'vDOCUMENTOMEDIDASEGURANCADESC',pic:''},{av:'cmbavDocumentoprevcoletadados'},{av:'AV15DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'cmbavFerramentacoletaid'},{av:'AV10FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'cmbavFrequenciatratamentoid'},{av:'AV12FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'cmbavTemporetencaoid'},{av:'AV14TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'cmbavTipodadoid'},{av:'AV9TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'cmbavTipodescarteid'},{av:'AV13TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'Combo_compartinternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTINTERNOID',prop:'SelectedValue_get'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV36DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A57CompartInternoId',fld:'COMPARTINTERNOID',pic:'ZZZZZZZ9'},{av:'Combo_envolvidoscoletaid_Selectedvalue_get',ctrl:'COMBO_ENVOLVIDOSCOLETAID',prop:'SelectedValue_get'},{av:'A54EnvolvidosColetaId',fld:'ENVOLVIDOSCOLETAID',pic:'ZZZZZZZ9'},{av:'Combo_medidasegurancaid_Selectedvalue_get',ctrl:'COMBO_MEDIDASEGURANCAID',prop:'SelectedValue_get'},{av:'A51MedidaSegurancaId',fld:'MEDIDASEGURANCAID',pic:'ZZZZZZZ9'},{av:'Combo_fonteretencaoid_Selectedvalue_get',ctrl:'COMBO_FONTERETENCAOID',prop:'SelectedValue_get'},{av:'A63FonteRetencaoId',fld:'FONTERETENCAOID',pic:'ZZZZZZZ9'},{av:'Combo_setorinternoid_Selectedvalue_get',ctrl:'COMBO_SETORINTERNOID',prop:'SelectedValue_get'},{av:'A60SetorInternoId',fld:'SETORINTERNOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOSALVAR'",",oparms:[{av:'AV34Documento',fld:'vDOCUMENTO',pic:''},{av:'AV47CompartInternoId_Col',fld:'vCOMPARTINTERNOID_COL',pic:''},{av:'AV38CompartInternoId_Item',fld:'vCOMPARTINTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV49EnvolvidosColetaId_Col',fld:'vENVOLVIDOSCOLETAID_COL',pic:''},{av:'AV41EnvolvidosColetaId_Item',fld:'vENVOLVIDOSCOLETAID_ITEM',pic:'ZZZZZZZ9'},{av:'AV89MedidaSegurancaId_Col',fld:'vMEDIDASEGURANCAID_COL',pic:''},{av:'AV90MedidaSegurancaId_Item',fld:'vMEDIDASEGURANCAID_ITEM',pic:'ZZZZZZZ9'},{av:'AV46FonteRetencaoId_Col',fld:'vFONTERETENCAOID_COL',pic:''},{av:'AV42FonteRetencaoId_Item',fld:'vFONTERETENCAOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV48SetorInternoId_Col',fld:'vSETORINTERNOID_COL',pic:''},{av:'AV43SetorInternoId_Item',fld:'vSETORINTERNOID_ITEM',pic:'ZZZ9'}]}");
         setEventMetadata("'DODADOSGRUPOVULINFO'","{handler:'E15791',iparms:[]");
         setEventMetadata("'DODADOSGRUPOVULINFO'",",oparms:[]}");
         setEventMetadata("'DODADOSCRIANCAADOLESCINFO'","{handler:'E16791',iparms:[]");
         setEventMetadata("'DODADOSCRIANCAADOLESCINFO'",",oparms:[]}");
         setEventMetadata("'DOTIPODESCARTEINFO'","{handler:'E40791',iparms:[]");
         setEventMetadata("'DOTIPODESCARTEINFO'",",oparms:[]}");
         setEventMetadata("'DOTIPODESCARTEADD'","{handler:'E30792',iparms:[]");
         setEventMetadata("'DOTIPODESCARTEADD'",",oparms:[{av:'AV64TipoDescarteId_Out',fld:'vTIPODESCARTEID_OUT',pic:'ZZZZZZZ9'},{av:'AV63IsTipoDescarte',fld:'vISTIPODESCARTE',pic:''}]}");
         setEventMetadata("'DOTEMPORETENCAOINFO'","{handler:'E39791',iparms:[]");
         setEventMetadata("'DOTEMPORETENCAOINFO'",",oparms:[]}");
         setEventMetadata("'DOTEMPORETENCAOADD'","{handler:'E31792',iparms:[]");
         setEventMetadata("'DOTEMPORETENCAOADD'",",oparms:[{av:'AV66TempoRetencaoId_Out',fld:'vTEMPORETENCAOID_OUT',pic:'ZZZZZZZ9'},{av:'AV65IsTempoRetencao',fld:'vISTEMPORETENCAO',pic:''}]}");
         setEventMetadata("'DOCATEGORIAINFO'","{handler:'E46791',iparms:[]");
         setEventMetadata("'DOCATEGORIAINFO'",",oparms:[]}");
         setEventMetadata("'DOCATEGORIAADD'","{handler:'E32792',iparms:[]");
         setEventMetadata("'DOCATEGORIAADD'",",oparms:[{av:'AV51CategoriaId_Out',fld:'vCATEGORIAID_OUT',pic:'ZZZZZZZ9'},{av:'AV52IsCategoria',fld:'vISCATEGORIA',pic:''}]}");
         setEventMetadata("'DOTIPODADOINFO'","{handler:'E45791',iparms:[]");
         setEventMetadata("'DOTIPODADOINFO'",",oparms:[]}");
         setEventMetadata("'DOTIPODADOADD'","{handler:'E33792',iparms:[]");
         setEventMetadata("'DOTIPODADOADD'",",oparms:[{av:'AV54TipoDadoId_Out',fld:'vTIPODADOID_OUT',pic:'ZZZZZZZ9'},{av:'AV53IsTipoDado',fld:'vISTIPODADO',pic:''}]}");
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
         Combo_fonteretencaoid_Selectedvalue_get = "";
         Combo_setorinternoid_Selectedvalue_get = "";
         Combo_compartinternoid_Selectedvalue_get = "";
         Combo_envolvidoscoletaid_Selectedvalue_get = "";
         Combo_medidasegurancaid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV25FonteRetencaoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV31SetorInternoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV32CompartInternoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33EnvolvidosColetaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV88MedidaSegurancaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22DocumentoFluxoTratDadosDesc = "";
         AV46FonteRetencaoId_Col = new GxSimpleCollection<int>();
         AV48SetorInternoId_Col = new GxSimpleCollection<int>();
         AV47CompartInternoId_Col = new GxSimpleCollection<int>();
         AV49EnvolvidosColetaId_Col = new GxSimpleCollection<int>();
         AV89MedidaSegurancaId_Col = new GxSimpleCollection<int>();
         A28CategoriaNome = "";
         A31TipoDadoNome = "";
         A34FerramentaColetaNome = "";
         A37AbrangenciaGeograficaNome = "";
         A64FonteRetencaoNome = "";
         AV24FonteRetencaoId = new GxSimpleCollection<int>();
         A40FrequenciaTratamentoNome = "";
         A46TipoDescarteNome = "";
         A49TempoRetencaoNome = "";
         A61SetorInternoNome = "";
         AV28SetorInternoId = new GxSimpleCollection<int>();
         A58CompartInternoNome = "";
         AV29CompartInternoId = new GxSimpleCollection<int>();
         A55EnvolvidosColetaNome = "";
         AV30EnvolvidosColetaId = new GxSimpleCollection<int>();
         A52MedidaSegurancaNome = "";
         AV20MedidaSegurancaId = new GxSimpleCollection<int>();
         AV34Documento = new SdtDocumento(context);
         Combo_fonteretencaoid_Selectedvalue_set = "";
         Combo_setorinternoid_Selectedvalue_set = "";
         Combo_compartinternoid_Selectedvalue_set = "";
         Combo_envolvidoscoletaid_Selectedvalue_set = "";
         Combo_medidasegurancaid_Selectedvalue_set = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV7DocumentoFinalidadeTratamento = "";
         lblFinalidadetratamentoinfo_Jsonclick = "";
         lblTxtfinalidadetratamento_Jsonclick = "";
         lblTextblockcombo_fonteretencaoid_Jsonclick = "";
         ucCombo_fonteretencaoid = new GXUserControl();
         lblPrevcoletadadosinfo_Jsonclick = "";
         AV16DocumentoBaseLegalNorm = "";
         lblBaselegalnorminfo_Jsonclick = "";
         lblTxtbaselegalnorm_Jsonclick = "";
         AV17DocumentoBaseLegalNormIntExt = "";
         lblBaselegalnormintextinfo_Jsonclick = "";
         lblTxtbaselegalnormext_Jsonclick = "";
         lblDadosgrupovulinfo_Jsonclick = "";
         lblDadoscriancaadolescinfo_Jsonclick = "";
         lblTextblockcombo_setorinternoid_Jsonclick = "";
         ucCombo_setorinternoid = new GXUserControl();
         lblTextblockcombo_compartinternoid_Jsonclick = "";
         ucCombo_compartinternoid = new GXUserControl();
         lblTextblockcombo_envolvidoscoletaid_Jsonclick = "";
         ucCombo_envolvidoscoletaid = new GXUserControl();
         lblTextblockcombo_medidasegurancaid_Jsonclick = "";
         ucCombo_medidasegurancaid = new GXUserControl();
         AV21DocumentoMedidaSegurancaDesc = "";
         lblMedidasegurancadescinfo_Jsonclick = "";
         lblTxtmedidasegurancadesc_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         ucDocumentofluxotratdadosdesc = new GXUserControl();
         lblFluxotratdadosdescinfo_Jsonclick = "";
         lblTxtfluxotratdados_Jsonclick = "";
         bttBtnsalvar_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV92FCKEditorMenuItem = new SdtFckEditorMenu_FckEditorMenuItem(context);
         AV91FCKEditorMenu = new GXBaseCollection<SdtFckEditorMenu_FckEditorMenuItem>( context, "FckEditorMenuItem", "LGPD_Novo");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         scmdbuf = "";
         H00792_A75DocumentoId = new int[1] ;
         H00792_A63FonteRetencaoId = new int[1] ;
         H00793_A75DocumentoId = new int[1] ;
         H00793_A60SetorInternoId = new int[1] ;
         H00794_A75DocumentoId = new int[1] ;
         H00794_A57CompartInternoId = new int[1] ;
         H00795_A75DocumentoId = new int[1] ;
         H00795_A54EnvolvidosColetaId = new int[1] ;
         H00796_A75DocumentoId = new int[1] ;
         H00796_A51MedidaSegurancaId = new int[1] ;
         H00797_A75DocumentoId = new int[1] ;
         H00797_A63FonteRetencaoId = new int[1] ;
         H00798_A75DocumentoId = new int[1] ;
         H00798_A60SetorInternoId = new int[1] ;
         H00799_A75DocumentoId = new int[1] ;
         H00799_A57CompartInternoId = new int[1] ;
         H007910_A75DocumentoId = new int[1] ;
         H007910_A54EnvolvidosColetaId = new int[1] ;
         H007911_A75DocumentoId = new int[1] ;
         H007911_A51MedidaSegurancaId = new int[1] ;
         H007912_A112TooltipId = new int[1] ;
         H007912_A135CampoId = new int[1] ;
         H007912_A139TooltipTelaId = new int[1] ;
         H007912_A140TooltipTelaNome = new string[] {""} ;
         H007912_A136CampoNome = new string[] {""} ;
         H007912_A115TooltipDescricao = new string[] {""} ;
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         H007913_A57CompartInternoId = new int[1] ;
         H007913_A75DocumentoId = new int[1] ;
         H007914_A75DocumentoId = new int[1] ;
         H007914_A57CompartInternoId = new int[1] ;
         H007915_A54EnvolvidosColetaId = new int[1] ;
         H007915_A75DocumentoId = new int[1] ;
         H007916_A75DocumentoId = new int[1] ;
         H007916_A54EnvolvidosColetaId = new int[1] ;
         H007917_A51MedidaSegurancaId = new int[1] ;
         H007917_A75DocumentoId = new int[1] ;
         H007918_A75DocumentoId = new int[1] ;
         H007918_A51MedidaSegurancaId = new int[1] ;
         H007919_A63FonteRetencaoId = new int[1] ;
         H007919_A75DocumentoId = new int[1] ;
         H007920_A75DocumentoId = new int[1] ;
         H007920_A63FonteRetencaoId = new int[1] ;
         H007921_A60SetorInternoId = new int[1] ;
         H007921_A75DocumentoId = new int[1] ;
         H007922_A75DocumentoId = new int[1] ;
         H007922_A60SetorInternoId = new int[1] ;
         AV127GXV11 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV37Message = new GeneXus.Utils.SdtMessages_Message(context);
         H007923_A53MedidaSegurancaAtivo = new bool[] {false} ;
         H007923_A51MedidaSegurancaId = new int[1] ;
         H007923_A52MedidaSegurancaNome = new string[] {""} ;
         AV27Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H007924_A56EnvolvidosColetaAtivo = new bool[] {false} ;
         H007924_A54EnvolvidosColetaId = new int[1] ;
         H007924_A55EnvolvidosColetaNome = new string[] {""} ;
         H007925_A59CompartInternoAtivo = new bool[] {false} ;
         H007925_A57CompartInternoId = new int[1] ;
         H007925_A58CompartInternoNome = new string[] {""} ;
         H007926_A62SetorInternoAtivo = new bool[] {false} ;
         H007926_A60SetorInternoId = new int[1] ;
         H007926_A61SetorInternoNome = new string[] {""} ;
         H007927_A65FonteRetencaoAtivo = new bool[] {false} ;
         H007927_A63FonteRetencaoId = new int[1] ;
         H007927_A64FonteRetencaoNome = new string[] {""} ;
         H007928_A29CategoriaAtivo = new bool[] {false} ;
         H007928_A27CategoriaId = new int[1] ;
         H007928_A28CategoriaNome = new string[] {""} ;
         H007929_A32TipoDadoAtivo = new bool[] {false} ;
         H007929_A30TipoDadoId = new int[1] ;
         H007929_A31TipoDadoNome = new string[] {""} ;
         H007930_A35FerramentaColetaAtivo = new bool[] {false} ;
         H007930_A33FerramentaColetaId = new int[1] ;
         H007930_A34FerramentaColetaNome = new string[] {""} ;
         H007931_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         H007931_A36AbrangenciaGeograficaId = new int[1] ;
         H007931_A37AbrangenciaGeograficaNome = new string[] {""} ;
         H007932_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         H007932_A39FrequenciaTratamentoId = new int[1] ;
         H007932_A40FrequenciaTratamentoNome = new string[] {""} ;
         H007933_A47TipoDescarteAtivo = new bool[] {false} ;
         H007933_A45TipoDescarteId = new int[1] ;
         H007933_A46TipoDescarteNome = new string[] {""} ;
         H007934_A50TempoRetencaoAtivo = new bool[] {false} ;
         H007934_A48TempoRetencaoId = new int[1] ;
         H007934_A49TempoRetencaoNome = new string[] {""} ;
         sStyleString = "";
         lblMedidasegurancainfo_Jsonclick = "";
         lblMedidasegurancaadd_Jsonclick = "";
         lblEnvolvidoscoletainfo_Jsonclick = "";
         lblEnvolvidoscoletaadd_Jsonclick = "";
         lblCompartinternoinfo_Jsonclick = "";
         lblCompartinternoadd_Jsonclick = "";
         lblSetorinternoinfo_Jsonclick = "";
         lblSetorinternoadd_Jsonclick = "";
         lblTemporetencaoinfo_Jsonclick = "";
         lblTemporetencaoadd_Jsonclick = "";
         lblTipodescarteinfo_Jsonclick = "";
         lblTipodescarteadd_Jsonclick = "";
         lblFonteretencaoinfo_Jsonclick = "";
         lblFonteretencaoadd_Jsonclick = "";
         lblFrequenciatratamentoinfo_Jsonclick = "";
         lblFrequenciatratamentoadd_Jsonclick = "";
         lblAbrangenciageograficainfo_Jsonclick = "";
         lblAbrangenciageograficaadd_Jsonclick = "";
         lblFerramentacoletainfo_Jsonclick = "";
         lblFerramentacoletaadd_Jsonclick = "";
         lblTipodadoinfo_Jsonclick = "";
         lblTipodadoadd_Jsonclick = "";
         lblCategoriainfo_Jsonclick = "";
         lblCategoriaadd_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV36DocumentoId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tratamentowc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tratamentowc__default(),
            new Object[][] {
                new Object[] {
               H00792_A75DocumentoId, H00792_A63FonteRetencaoId
               }
               , new Object[] {
               H00793_A75DocumentoId, H00793_A60SetorInternoId
               }
               , new Object[] {
               H00794_A75DocumentoId, H00794_A57CompartInternoId
               }
               , new Object[] {
               H00795_A75DocumentoId, H00795_A54EnvolvidosColetaId
               }
               , new Object[] {
               H00796_A75DocumentoId, H00796_A51MedidaSegurancaId
               }
               , new Object[] {
               H00797_A75DocumentoId, H00797_A63FonteRetencaoId
               }
               , new Object[] {
               H00798_A75DocumentoId, H00798_A60SetorInternoId
               }
               , new Object[] {
               H00799_A75DocumentoId, H00799_A57CompartInternoId
               }
               , new Object[] {
               H007910_A75DocumentoId, H007910_A54EnvolvidosColetaId
               }
               , new Object[] {
               H007911_A75DocumentoId, H007911_A51MedidaSegurancaId
               }
               , new Object[] {
               H007912_A112TooltipId, H007912_A135CampoId, H007912_A139TooltipTelaId, H007912_A140TooltipTelaNome, H007912_A136CampoNome, H007912_A115TooltipDescricao
               }
               , new Object[] {
               H007913_A57CompartInternoId, H007913_A75DocumentoId
               }
               , new Object[] {
               H007914_A75DocumentoId, H007914_A57CompartInternoId
               }
               , new Object[] {
               H007915_A54EnvolvidosColetaId, H007915_A75DocumentoId
               }
               , new Object[] {
               H007916_A75DocumentoId, H007916_A54EnvolvidosColetaId
               }
               , new Object[] {
               H007917_A51MedidaSegurancaId, H007917_A75DocumentoId
               }
               , new Object[] {
               H007918_A75DocumentoId, H007918_A51MedidaSegurancaId
               }
               , new Object[] {
               H007919_A63FonteRetencaoId, H007919_A75DocumentoId
               }
               , new Object[] {
               H007920_A75DocumentoId, H007920_A63FonteRetencaoId
               }
               , new Object[] {
               H007921_A60SetorInternoId, H007921_A75DocumentoId
               }
               , new Object[] {
               H007922_A75DocumentoId, H007922_A60SetorInternoId
               }
               , new Object[] {
               H007923_A53MedidaSegurancaAtivo, H007923_A51MedidaSegurancaId, H007923_A52MedidaSegurancaNome
               }
               , new Object[] {
               H007924_A56EnvolvidosColetaAtivo, H007924_A54EnvolvidosColetaId, H007924_A55EnvolvidosColetaNome
               }
               , new Object[] {
               H007925_A59CompartInternoAtivo, H007925_A57CompartInternoId, H007925_A58CompartInternoNome
               }
               , new Object[] {
               H007926_A62SetorInternoAtivo, H007926_A60SetorInternoId, H007926_A61SetorInternoNome
               }
               , new Object[] {
               H007927_A65FonteRetencaoAtivo, H007927_A63FonteRetencaoId, H007927_A64FonteRetencaoNome
               }
               , new Object[] {
               H007928_A29CategoriaAtivo, H007928_A27CategoriaId, H007928_A28CategoriaNome
               }
               , new Object[] {
               H007929_A32TipoDadoAtivo, H007929_A30TipoDadoId, H007929_A31TipoDadoNome
               }
               , new Object[] {
               H007930_A35FerramentaColetaAtivo, H007930_A33FerramentaColetaId, H007930_A34FerramentaColetaNome
               }
               , new Object[] {
               H007931_A38AbrangenciaGeograficaAtivo, H007931_A36AbrangenciaGeograficaId, H007931_A37AbrangenciaGeograficaNome
               }
               , new Object[] {
               H007932_A41FrequenciaTratamentoAtivo, H007932_A39FrequenciaTratamentoId, H007932_A40FrequenciaTratamentoNome
               }
               , new Object[] {
               H007933_A47TipoDescarteAtivo, H007933_A45TipoDescarteId, H007933_A46TipoDescarteNome
               }
               , new Object[] {
               H007934_A50TempoRetencaoAtivo, H007934_A48TempoRetencaoId, H007934_A49TempoRetencaoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_35 ;
      private short nIsMod_35 ;
      private short nRcdExists_34 ;
      private short nIsMod_34 ;
      private short nRcdExists_33 ;
      private short nIsMod_33 ;
      private short nRcdExists_32 ;
      private short nIsMod_32 ;
      private short nRcdExists_31 ;
      private short nIsMod_31 ;
      private short nRcdExists_30 ;
      private short nIsMod_30 ;
      private short nRcdExists_29 ;
      private short nIsMod_29 ;
      private short nRcdExists_28 ;
      private short nIsMod_28 ;
      private short nRcdExists_27 ;
      private short nIsMod_27 ;
      private short nRcdExists_26 ;
      private short nIsMod_26 ;
      private short nRcdExists_25 ;
      private short nIsMod_25 ;
      private short nRcdExists_24 ;
      private short nIsMod_24 ;
      private short nRcdExists_23 ;
      private short nIsMod_23 ;
      private short nRcdExists_22 ;
      private short nIsMod_22 ;
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
      private short AV59FonteRetencaoId_Out ;
      private short AV62FrequenciaTratamentoId_Out ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV43SetorInternoId_Item ;
      private short AV113GXLvl854 ;
      private short AV116GXLvl877 ;
      private short AV119GXLvl900 ;
      private short AV122GXLvl923 ;
      private short AV125GXLvl946 ;
      private short nGXWrapped ;
      private int AV36DocumentoId ;
      private int wcpOAV36DocumentoId ;
      private int AV51CategoriaId_Out ;
      private int AV54TipoDadoId_Out ;
      private int AV56FerramentaColetaId_Out ;
      private int AV58AbrangenciaGeograficaId_Out ;
      private int AV64TipoDescarteId_Out ;
      private int AV66TempoRetencaoId_Out ;
      private int AV68SetorInternoId_Out ;
      private int AV70CompartInternoId_Out ;
      private int AV72EnvolvidosColetaId_Out ;
      private int AV74MedidaSegurancaId_Out ;
      private int A27CategoriaId ;
      private int A30TipoDadoId ;
      private int A33FerramentaColetaId ;
      private int A36AbrangenciaGeograficaId ;
      private int A63FonteRetencaoId ;
      private int A39FrequenciaTratamentoId ;
      private int A45TipoDescarteId ;
      private int A48TempoRetencaoId ;
      private int A60SetorInternoId ;
      private int A57CompartInternoId ;
      private int A54EnvolvidosColetaId ;
      private int A51MedidaSegurancaId ;
      private int A75DocumentoId ;
      private int edtavDocumentofinalidadetratamento_Enabled ;
      private int lblFinalidadetratamentoinfo_Visible ;
      private int AV8CategoriaId ;
      private int AV9TipoDadoId ;
      private int AV10FerramentaColetaId ;
      private int AV11AbrangenciaGeograficaId ;
      private int AV12FrequenciaTratamentoId ;
      private int AV13TipoDescarteId ;
      private int AV14TempoRetencaoId ;
      private int lblPrevcoletadadosinfo_Visible ;
      private int edtavDocumentobaselegalnorm_Enabled ;
      private int lblBaselegalnorminfo_Visible ;
      private int edtavDocumentobaselegalnormintext_Enabled ;
      private int lblBaselegalnormintextinfo_Visible ;
      private int lblDadosgrupovulinfo_Visible ;
      private int lblDadoscriancaadolescinfo_Visible ;
      private int edtavDocumentomedidasegurancadesc_Enabled ;
      private int lblMedidasegurancadescinfo_Visible ;
      private int lblFluxotratdadosdescinfo_Visible ;
      private int bttBtnsalvar_Visible ;
      private int lblCategoriainfo_Visible ;
      private int lblCategoriaadd_Visible ;
      private int lblTipodadoinfo_Visible ;
      private int lblTipodadoadd_Visible ;
      private int lblFerramentacoletainfo_Visible ;
      private int lblFerramentacoletaadd_Visible ;
      private int lblAbrangenciageograficainfo_Visible ;
      private int lblAbrangenciageograficaadd_Visible ;
      private int lblFrequenciatratamentoinfo_Visible ;
      private int lblFrequenciatratamentoadd_Visible ;
      private int lblFonteretencaoinfo_Visible ;
      private int lblFonteretencaoadd_Visible ;
      private int lblTipodescarteinfo_Visible ;
      private int lblTipodescarteadd_Visible ;
      private int lblTemporetencaoinfo_Visible ;
      private int lblTemporetencaoadd_Visible ;
      private int lblSetorinternoinfo_Visible ;
      private int lblSetorinternoadd_Visible ;
      private int lblCompartinternoinfo_Visible ;
      private int lblCompartinternoadd_Visible ;
      private int lblEnvolvidoscoletainfo_Visible ;
      private int lblEnvolvidoscoletaadd_Visible ;
      private int lblMedidasegurancainfo_Visible ;
      private int lblMedidasegurancaadd_Visible ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int AV107GXV1 ;
      private int AV42FonteRetencaoId_Item ;
      private int AV108GXV2 ;
      private int AV109GXV3 ;
      private int AV38CompartInternoId_Item ;
      private int AV110GXV4 ;
      private int AV41EnvolvidosColetaId_Item ;
      private int AV111GXV5 ;
      private int AV90MedidaSegurancaId_Item ;
      private int AV112GXV6 ;
      private int AV115GXV7 ;
      private int AV118GXV8 ;
      private int AV121GXV9 ;
      private int AV124GXV10 ;
      private int AV128GXV12 ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Combo_fonteretencaoid_Selectedvalue_get ;
      private string Combo_setorinternoid_Selectedvalue_get ;
      private string Combo_compartinternoid_Selectedvalue_get ;
      private string Combo_envolvidoscoletaid_Selectedvalue_get ;
      private string Combo_medidasegurancaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_fonteretencaoid_Cls ;
      private string Combo_fonteretencaoid_Selectedvalue_set ;
      private string Combo_fonteretencaoid_Multiplevaluestype ;
      private string Combo_fonteretencaoid_Emptyitemtext ;
      private string Combo_setorinternoid_Cls ;
      private string Combo_setorinternoid_Selectedvalue_set ;
      private string Combo_setorinternoid_Multiplevaluestype ;
      private string Combo_setorinternoid_Emptyitemtext ;
      private string Combo_compartinternoid_Cls ;
      private string Combo_compartinternoid_Selectedvalue_set ;
      private string Combo_compartinternoid_Multiplevaluestype ;
      private string Combo_compartinternoid_Emptyitemtext ;
      private string Combo_envolvidoscoletaid_Cls ;
      private string Combo_envolvidoscoletaid_Selectedvalue_set ;
      private string Combo_envolvidoscoletaid_Multiplevaluestype ;
      private string Combo_envolvidoscoletaid_Emptyitemtext ;
      private string Combo_medidasegurancaid_Cls ;
      private string Combo_medidasegurancaid_Selectedvalue_set ;
      private string Combo_medidasegurancaid_Multiplevaluestype ;
      private string Documentofluxotratdadosdesc_Width ;
      private string Documentofluxotratdadosdesc_Height ;
      private string Documentofluxotratdadosdesc_Captionclass ;
      private string Documentofluxotratdadosdesc_Captionstyle ;
      private string Documentofluxotratdadosdesc_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTabletratamento_Internalname ;
      private string edtavDocumentofinalidadetratamento_Internalname ;
      private string TempTags ;
      private string edtavDocumentofinalidadetratamento_Jsonclick ;
      private string lblFinalidadetratamentoinfo_Internalname ;
      private string lblFinalidadetratamentoinfo_Jsonclick ;
      private string lblFinalidadetratamentoinfo_Tooltiptext ;
      private string divUnnamedtable1_Internalname ;
      private string lblTxtfinalidadetratamento_Internalname ;
      private string lblTxtfinalidadetratamento_Caption ;
      private string lblTxtfinalidadetratamento_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string cmbavCategoriaid_Internalname ;
      private string cmbavCategoriaid_Jsonclick ;
      private string cmbavTipodadoid_Internalname ;
      private string cmbavTipodadoid_Jsonclick ;
      private string cmbavFerramentacoletaid_Internalname ;
      private string cmbavFerramentacoletaid_Jsonclick ;
      private string cmbavAbrangenciageograficaid_Internalname ;
      private string cmbavAbrangenciageograficaid_Jsonclick ;
      private string cmbavFrequenciatratamentoid_Internalname ;
      private string cmbavFrequenciatratamentoid_Jsonclick ;
      private string divTablesplittedfonteretencaoid_Internalname ;
      private string lblTextblockcombo_fonteretencaoid_Internalname ;
      private string lblTextblockcombo_fonteretencaoid_Jsonclick ;
      private string Combo_fonteretencaoid_Caption ;
      private string Combo_fonteretencaoid_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string cmbavTipodescarteid_Internalname ;
      private string cmbavTipodescarteid_Jsonclick ;
      private string cmbavTemporetencaoid_Internalname ;
      private string cmbavTemporetencaoid_Jsonclick ;
      private string cmbavDocumentoprevcoletadados_Internalname ;
      private string cmbavDocumentoprevcoletadados_Jsonclick ;
      private string lblPrevcoletadadosinfo_Internalname ;
      private string lblPrevcoletadadosinfo_Jsonclick ;
      private string lblPrevcoletadadosinfo_Tooltiptext ;
      private string edtavDocumentobaselegalnorm_Internalname ;
      private string edtavDocumentobaselegalnorm_Jsonclick ;
      private string lblBaselegalnorminfo_Internalname ;
      private string lblBaselegalnorminfo_Jsonclick ;
      private string lblBaselegalnorminfo_Tooltiptext ;
      private string divUnnamedtable4_Internalname ;
      private string lblTxtbaselegalnorm_Internalname ;
      private string lblTxtbaselegalnorm_Caption ;
      private string lblTxtbaselegalnorm_Jsonclick ;
      private string edtavDocumentobaselegalnormintext_Internalname ;
      private string edtavDocumentobaselegalnormintext_Jsonclick ;
      private string lblBaselegalnormintextinfo_Internalname ;
      private string lblBaselegalnormintextinfo_Jsonclick ;
      private string lblBaselegalnormintextinfo_Tooltiptext ;
      private string divUnnamedtable5_Internalname ;
      private string lblTxtbaselegalnormext_Internalname ;
      private string lblTxtbaselegalnormext_Caption ;
      private string lblTxtbaselegalnormext_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string chkavDocumentodadosgrupovul_Internalname ;
      private string lblDadosgrupovulinfo_Internalname ;
      private string lblDadosgrupovulinfo_Jsonclick ;
      private string lblDadosgrupovulinfo_Tooltiptext ;
      private string chkavDocumentodadoscriancaadolesc_Internalname ;
      private string lblDadoscriancaadolescinfo_Internalname ;
      private string lblDadoscriancaadolescinfo_Jsonclick ;
      private string lblDadoscriancaadolescinfo_Tooltiptext ;
      private string divTablesplittedsetorinternoid_Internalname ;
      private string lblTextblockcombo_setorinternoid_Internalname ;
      private string lblTextblockcombo_setorinternoid_Jsonclick ;
      private string Combo_setorinternoid_Caption ;
      private string Combo_setorinternoid_Internalname ;
      private string divTablesplittedcompartinternoid_Internalname ;
      private string lblTextblockcombo_compartinternoid_Internalname ;
      private string lblTextblockcombo_compartinternoid_Jsonclick ;
      private string Combo_compartinternoid_Caption ;
      private string Combo_compartinternoid_Internalname ;
      private string divTablesplittedenvolvidoscoletaid_Internalname ;
      private string lblTextblockcombo_envolvidoscoletaid_Internalname ;
      private string lblTextblockcombo_envolvidoscoletaid_Jsonclick ;
      private string Combo_envolvidoscoletaid_Caption ;
      private string Combo_envolvidoscoletaid_Internalname ;
      private string divTablesplittedmedidasegurancaid_Internalname ;
      private string lblTextblockcombo_medidasegurancaid_Internalname ;
      private string lblTextblockcombo_medidasegurancaid_Jsonclick ;
      private string Combo_medidasegurancaid_Caption ;
      private string Combo_medidasegurancaid_Internalname ;
      private string edtavDocumentomedidasegurancadesc_Internalname ;
      private string lblMedidasegurancadescinfo_Internalname ;
      private string lblMedidasegurancadescinfo_Jsonclick ;
      private string lblMedidasegurancadescinfo_Tooltiptext ;
      private string divUnnamedtable7_Internalname ;
      private string lblTxtmedidasegurancadesc_Internalname ;
      private string lblTxtmedidasegurancadesc_Caption ;
      private string lblTxtmedidasegurancadesc_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string Documentofluxotratdadosdesc_Internalname ;
      private string lblFluxotratdadosdescinfo_Internalname ;
      private string lblFluxotratdadosdescinfo_Jsonclick ;
      private string lblFluxotratdadosdescinfo_Tooltiptext ;
      private string divUnnamedtable8_Internalname ;
      private string lblTxtfluxotratdados_Internalname ;
      private string lblTxtfluxotratdados_Jsonclick ;
      private string bttBtnsalvar_Internalname ;
      private string bttBtnsalvar_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string lblCategoriainfo_Internalname ;
      private string lblCategoriaadd_Internalname ;
      private string lblTipodadoinfo_Internalname ;
      private string lblTipodadoadd_Internalname ;
      private string lblFerramentacoletainfo_Internalname ;
      private string lblFerramentacoletaadd_Internalname ;
      private string lblAbrangenciageograficainfo_Internalname ;
      private string lblAbrangenciageograficaadd_Internalname ;
      private string lblFrequenciatratamentoinfo_Internalname ;
      private string lblFrequenciatratamentoadd_Internalname ;
      private string lblFonteretencaoinfo_Internalname ;
      private string lblFonteretencaoadd_Internalname ;
      private string lblTipodescarteinfo_Internalname ;
      private string lblTipodescarteadd_Internalname ;
      private string lblTemporetencaoinfo_Internalname ;
      private string lblTemporetencaoadd_Internalname ;
      private string lblSetorinternoinfo_Internalname ;
      private string lblSetorinternoadd_Internalname ;
      private string lblCompartinternoinfo_Internalname ;
      private string lblCompartinternoadd_Internalname ;
      private string lblEnvolvidoscoletainfo_Internalname ;
      private string lblEnvolvidoscoletaadd_Internalname ;
      private string lblMedidasegurancainfo_Internalname ;
      private string lblMedidasegurancaadd_Internalname ;
      private string lblCategoriainfo_Tooltiptext ;
      private string lblTipodadoinfo_Tooltiptext ;
      private string lblFerramentacoletainfo_Tooltiptext ;
      private string lblAbrangenciageograficainfo_Tooltiptext ;
      private string lblFrequenciatratamentoinfo_Tooltiptext ;
      private string lblFonteretencaoinfo_Tooltiptext ;
      private string lblTipodescarteinfo_Tooltiptext ;
      private string lblTemporetencaoinfo_Tooltiptext ;
      private string lblSetorinternoinfo_Tooltiptext ;
      private string lblCompartinternoinfo_Tooltiptext ;
      private string lblEnvolvidoscoletainfo_Tooltiptext ;
      private string lblMedidasegurancainfo_Tooltiptext ;
      private string sStyleString ;
      private string tblTablemergedmedidasegurancainfo_Internalname ;
      private string lblMedidasegurancainfo_Jsonclick ;
      private string lblMedidasegurancaadd_Jsonclick ;
      private string tblTablemergedenvolvidoscoletainfo_Internalname ;
      private string lblEnvolvidoscoletainfo_Jsonclick ;
      private string lblEnvolvidoscoletaadd_Jsonclick ;
      private string tblTablemergedcompartinternoinfo_Internalname ;
      private string lblCompartinternoinfo_Jsonclick ;
      private string lblCompartinternoadd_Jsonclick ;
      private string tblTablemergedsetorinternoinfo_Internalname ;
      private string lblSetorinternoinfo_Jsonclick ;
      private string lblSetorinternoadd_Jsonclick ;
      private string tblTablemergedtemporetencaoinfo_Internalname ;
      private string lblTemporetencaoinfo_Jsonclick ;
      private string lblTemporetencaoadd_Jsonclick ;
      private string tblTablemergedtipodescarteinfo_Internalname ;
      private string lblTipodescarteinfo_Jsonclick ;
      private string lblTipodescarteadd_Jsonclick ;
      private string tblTablemergedfonteretencaoinfo_Internalname ;
      private string lblFonteretencaoinfo_Jsonclick ;
      private string lblFonteretencaoadd_Jsonclick ;
      private string tblTablemergedfrequenciatratamentoinfo_Internalname ;
      private string lblFrequenciatratamentoinfo_Jsonclick ;
      private string lblFrequenciatratamentoadd_Jsonclick ;
      private string tblTablemergedabrangenciageograficainfo_Internalname ;
      private string lblAbrangenciageograficainfo_Jsonclick ;
      private string lblAbrangenciageograficaadd_Jsonclick ;
      private string tblTablemergedferramentacoletainfo_Internalname ;
      private string lblFerramentacoletainfo_Jsonclick ;
      private string lblFerramentacoletaadd_Jsonclick ;
      private string tblTablemergedtipodadoinfo_Internalname ;
      private string lblTipodadoinfo_Jsonclick ;
      private string lblTipodadoadd_Jsonclick ;
      private string tblTablemergedcategoriainfo_Internalname ;
      private string lblCategoriainfo_Jsonclick ;
      private string lblCategoriaadd_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV36DocumentoId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV52IsCategoria ;
      private bool AV53IsTipoDado ;
      private bool AV55IsFerramentaColeta ;
      private bool AV57IsAbrangenciaGeografica ;
      private bool AV60IsFonteRetencao ;
      private bool AV61IsFrequenciaTratamento ;
      private bool AV63IsTipoDescarte ;
      private bool AV65IsTempoRetencao ;
      private bool AV67IsSetorInterno ;
      private bool AV69IsCompartInterno ;
      private bool AV71IsEnvolvidosColeta ;
      private bool AV73IsMedidaSeguranca ;
      private bool A29CategoriaAtivo ;
      private bool A32TipoDadoAtivo ;
      private bool A35FerramentaColetaAtivo ;
      private bool A38AbrangenciaGeograficaAtivo ;
      private bool A65FonteRetencaoAtivo ;
      private bool A41FrequenciaTratamentoAtivo ;
      private bool A47TipoDescarteAtivo ;
      private bool A50TempoRetencaoAtivo ;
      private bool A62SetorInternoAtivo ;
      private bool A59CompartInternoAtivo ;
      private bool A56EnvolvidosColetaAtivo ;
      private bool A53MedidaSegurancaAtivo ;
      private bool Combo_fonteretencaoid_Enabled ;
      private bool Combo_fonteretencaoid_Allowmultipleselection ;
      private bool Combo_fonteretencaoid_Includeonlyselectedoption ;
      private bool Combo_setorinternoid_Enabled ;
      private bool Combo_setorinternoid_Allowmultipleselection ;
      private bool Combo_setorinternoid_Includeonlyselectedoption ;
      private bool Combo_compartinternoid_Enabled ;
      private bool Combo_compartinternoid_Allowmultipleselection ;
      private bool Combo_compartinternoid_Includeonlyselectedoption ;
      private bool Combo_envolvidoscoletaid_Enabled ;
      private bool Combo_envolvidoscoletaid_Allowmultipleselection ;
      private bool Combo_envolvidoscoletaid_Includeonlyselectedoption ;
      private bool Combo_medidasegurancaid_Enabled ;
      private bool Combo_medidasegurancaid_Allowmultipleselection ;
      private bool Combo_medidasegurancaid_Includeonlyselectedoption ;
      private bool Combo_medidasegurancaid_Emptyitem ;
      private bool Documentofluxotratdadosdesc_Enabled ;
      private bool wbLoad ;
      private bool AV15DocumentoPrevColetaDados ;
      private bool AV18DocumentoDadosGrupoVul ;
      private bool AV19DocumentoDadosCriancaAdolesc ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV75IsAuthorized_FerramentaColetaAdd ;
      private bool AV76IsAuthorized_AbrangenciaGeograficaAdd ;
      private bool AV77IsAuthorized_FrequenciaTratamentoAdd ;
      private bool AV78IsAuthorized_FonteRetencaoAdd ;
      private bool AV79IsAuthorized_SetorInternoAdd ;
      private bool AV80IsAuthorized_CompartInternoAdd ;
      private bool AV81IsAuthorized_EnvolvidosColetaAdd ;
      private bool AV82IsAuthorized_MedidaSegurancaAdd ;
      private bool AV87IsAuthorized_Salvar ;
      private bool AV83IsAuthorized_TipoDescarteAdd ;
      private bool AV84IsAuthorized_TempoRetencaoAdd ;
      private bool AV85IsAuthorized_CategoriaAdd ;
      private bool AV86IsAuthorized_TipoDadoAdd ;
      private bool GXt_boolean2 ;
      private string AV22DocumentoFluxoTratDadosDesc ;
      private string AV21DocumentoMedidaSegurancaDesc ;
      private string A115TooltipDescricao ;
      private string A28CategoriaNome ;
      private string A31TipoDadoNome ;
      private string A34FerramentaColetaNome ;
      private string A37AbrangenciaGeograficaNome ;
      private string A64FonteRetencaoNome ;
      private string A40FrequenciaTratamentoNome ;
      private string A46TipoDescarteNome ;
      private string A49TempoRetencaoNome ;
      private string A61SetorInternoNome ;
      private string A58CompartInternoNome ;
      private string A55EnvolvidosColetaNome ;
      private string A52MedidaSegurancaNome ;
      private string AV7DocumentoFinalidadeTratamento ;
      private string AV16DocumentoBaseLegalNorm ;
      private string AV17DocumentoBaseLegalNormIntExt ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private GxSimpleCollection<int> AV46FonteRetencaoId_Col ;
      private GxSimpleCollection<int> AV48SetorInternoId_Col ;
      private GxSimpleCollection<int> AV47CompartInternoId_Col ;
      private GxSimpleCollection<int> AV49EnvolvidosColetaId_Col ;
      private GxSimpleCollection<int> AV89MedidaSegurancaId_Col ;
      private GxSimpleCollection<int> AV24FonteRetencaoId ;
      private GxSimpleCollection<int> AV28SetorInternoId ;
      private GxSimpleCollection<int> AV29CompartInternoId ;
      private GxSimpleCollection<int> AV30EnvolvidosColetaId ;
      private GxSimpleCollection<int> AV20MedidaSegurancaId ;
      private GXUserControl ucCombo_fonteretencaoid ;
      private GXUserControl ucCombo_setorinternoid ;
      private GXUserControl ucCombo_compartinternoid ;
      private GXUserControl ucCombo_envolvidoscoletaid ;
      private GXUserControl ucCombo_medidasegurancaid ;
      private GXUserControl ucDocumentofluxotratdadosdesc ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCategoriaid ;
      private GXCombobox cmbavTipodadoid ;
      private GXCombobox cmbavFerramentacoletaid ;
      private GXCombobox cmbavAbrangenciageograficaid ;
      private GXCombobox cmbavFrequenciatratamentoid ;
      private GXCombobox cmbavTipodescarteid ;
      private GXCombobox cmbavTemporetencaoid ;
      private GXCombobox cmbavDocumentoprevcoletadados ;
      private GXCheckbox chkavDocumentodadosgrupovul ;
      private GXCheckbox chkavDocumentodadoscriancaadolesc ;
      private IDataStoreProvider pr_default ;
      private int[] H00792_A75DocumentoId ;
      private int[] H00792_A63FonteRetencaoId ;
      private int[] H00793_A75DocumentoId ;
      private int[] H00793_A60SetorInternoId ;
      private int[] H00794_A75DocumentoId ;
      private int[] H00794_A57CompartInternoId ;
      private int[] H00795_A75DocumentoId ;
      private int[] H00795_A54EnvolvidosColetaId ;
      private int[] H00796_A75DocumentoId ;
      private int[] H00796_A51MedidaSegurancaId ;
      private int[] H00797_A75DocumentoId ;
      private int[] H00797_A63FonteRetencaoId ;
      private int[] H00798_A75DocumentoId ;
      private int[] H00798_A60SetorInternoId ;
      private int[] H00799_A75DocumentoId ;
      private int[] H00799_A57CompartInternoId ;
      private int[] H007910_A75DocumentoId ;
      private int[] H007910_A54EnvolvidosColetaId ;
      private int[] H007911_A75DocumentoId ;
      private int[] H007911_A51MedidaSegurancaId ;
      private int[] H007912_A112TooltipId ;
      private int[] H007912_A135CampoId ;
      private int[] H007912_A139TooltipTelaId ;
      private string[] H007912_A140TooltipTelaNome ;
      private string[] H007912_A136CampoNome ;
      private string[] H007912_A115TooltipDescricao ;
      private int[] H007913_A57CompartInternoId ;
      private int[] H007913_A75DocumentoId ;
      private int[] H007914_A75DocumentoId ;
      private int[] H007914_A57CompartInternoId ;
      private int[] H007915_A54EnvolvidosColetaId ;
      private int[] H007915_A75DocumentoId ;
      private int[] H007916_A75DocumentoId ;
      private int[] H007916_A54EnvolvidosColetaId ;
      private int[] H007917_A51MedidaSegurancaId ;
      private int[] H007917_A75DocumentoId ;
      private int[] H007918_A75DocumentoId ;
      private int[] H007918_A51MedidaSegurancaId ;
      private int[] H007919_A63FonteRetencaoId ;
      private int[] H007919_A75DocumentoId ;
      private int[] H007920_A75DocumentoId ;
      private int[] H007920_A63FonteRetencaoId ;
      private int[] H007921_A60SetorInternoId ;
      private int[] H007921_A75DocumentoId ;
      private int[] H007922_A75DocumentoId ;
      private int[] H007922_A60SetorInternoId ;
      private bool[] H007923_A53MedidaSegurancaAtivo ;
      private int[] H007923_A51MedidaSegurancaId ;
      private string[] H007923_A52MedidaSegurancaNome ;
      private bool[] H007924_A56EnvolvidosColetaAtivo ;
      private int[] H007924_A54EnvolvidosColetaId ;
      private string[] H007924_A55EnvolvidosColetaNome ;
      private bool[] H007925_A59CompartInternoAtivo ;
      private int[] H007925_A57CompartInternoId ;
      private string[] H007925_A58CompartInternoNome ;
      private bool[] H007926_A62SetorInternoAtivo ;
      private int[] H007926_A60SetorInternoId ;
      private string[] H007926_A61SetorInternoNome ;
      private bool[] H007927_A65FonteRetencaoAtivo ;
      private int[] H007927_A63FonteRetencaoId ;
      private string[] H007927_A64FonteRetencaoNome ;
      private bool[] H007928_A29CategoriaAtivo ;
      private int[] H007928_A27CategoriaId ;
      private string[] H007928_A28CategoriaNome ;
      private bool[] H007929_A32TipoDadoAtivo ;
      private int[] H007929_A30TipoDadoId ;
      private string[] H007929_A31TipoDadoNome ;
      private bool[] H007930_A35FerramentaColetaAtivo ;
      private int[] H007930_A33FerramentaColetaId ;
      private string[] H007930_A34FerramentaColetaNome ;
      private bool[] H007931_A38AbrangenciaGeograficaAtivo ;
      private int[] H007931_A36AbrangenciaGeograficaId ;
      private string[] H007931_A37AbrangenciaGeograficaNome ;
      private bool[] H007932_A41FrequenciaTratamentoAtivo ;
      private int[] H007932_A39FrequenciaTratamentoId ;
      private string[] H007932_A40FrequenciaTratamentoNome ;
      private bool[] H007933_A47TipoDescarteAtivo ;
      private int[] H007933_A45TipoDescarteId ;
      private string[] H007933_A46TipoDescarteNome ;
      private bool[] H007934_A50TempoRetencaoAtivo ;
      private int[] H007934_A48TempoRetencaoId ;
      private string[] H007934_A49TempoRetencaoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV127GXV11 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25FonteRetencaoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31SetorInternoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32CompartInternoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33EnvolvidosColetaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV88MedidaSegurancaId_Data ;
      private GXBaseCollection<SdtFckEditorMenu_FckEditorMenuItem> AV91FCKEditorMenu ;
      private SdtDocumento AV34Documento ;
      private GeneXus.Utils.SdtMessages_Message AV37Message ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV27Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV26DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtFckEditorMenu_FckEditorMenuItem AV92FCKEditorMenuItem ;
   }

   public class tratamentowc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tratamentowc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH00792;
        prmH00792 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00793;
        prmH00793 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00794;
        prmH00794 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00795;
        prmH00795 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00796;
        prmH00796 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00797;
        prmH00797 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00798;
        prmH00798 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH00799;
        prmH00799 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007910;
        prmH007910 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007911;
        prmH007911 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007912;
        prmH007912 = new Object[] {
        };
        Object[] prmH007913;
        prmH007913 = new Object[] {
        new ParDef("@AV38CompartInternoId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007914;
        prmH007914 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007915;
        prmH007915 = new Object[] {
        new ParDef("@AV41EnvolvidosColetaId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007916;
        prmH007916 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007917;
        prmH007917 = new Object[] {
        new ParDef("@AV90MedidaSegurancaId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007918;
        prmH007918 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007919;
        prmH007919 = new Object[] {
        new ParDef("@AV42FonteRetencaoId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007920;
        prmH007920 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007921;
        prmH007921 = new Object[] {
        new ParDef("@AV43SetorInternoId_Item",GXType.Int16,4,0) ,
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007922;
        prmH007922 = new Object[] {
        new ParDef("@AV36DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007923;
        prmH007923 = new Object[] {
        };
        Object[] prmH007924;
        prmH007924 = new Object[] {
        };
        Object[] prmH007925;
        prmH007925 = new Object[] {
        };
        Object[] prmH007926;
        prmH007926 = new Object[] {
        };
        Object[] prmH007927;
        prmH007927 = new Object[] {
        };
        Object[] prmH007928;
        prmH007928 = new Object[] {
        };
        Object[] prmH007929;
        prmH007929 = new Object[] {
        };
        Object[] prmH007930;
        prmH007930 = new Object[] {
        };
        Object[] prmH007931;
        prmH007931 = new Object[] {
        };
        Object[] prmH007932;
        prmH007932 = new Object[] {
        };
        Object[] prmH007933;
        prmH007933 = new Object[] {
        };
        Object[] prmH007934;
        prmH007934 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H00792", "SELECT [DocumentoId], [FonteRetencaoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00792,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00793", "SELECT [DocumentoId], [SetorInternoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00793,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00794", "SELECT [DocumentoId], [CompartInternoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00794,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00795", "SELECT [DocumentoId], [EnvolvidosColetaId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00795,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00796", "SELECT [DocumentoId], [MedidaSegurancaId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00796,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00797", "SELECT [DocumentoId], [FonteRetencaoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00797,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00798", "SELECT [DocumentoId], [SetorInternoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00798,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H00799", "SELECT [DocumentoId], [CompartInternoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00799,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007910", "SELECT [DocumentoId], [EnvolvidosColetaId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007910,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007911", "SELECT [DocumentoId], [MedidaSegurancaId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007911,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007912", "SELECT T1.[TooltipId], T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T3.[TelaNome] AS TooltipTelaNome, T2.[CampoNome], T1.[TooltipDescricao] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId]) WHERE T3.[TelaNome] = 'TRATAMENTO' ORDER BY T1.[TooltipId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007912,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007913", "SELECT [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [CompartInternoId] = @AV38CompartInternoId_Item and [DocumentoId] = @AV36DocumentoId ORDER BY [CompartInternoId], [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007913,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007914", "SELECT [DocumentoId], [CompartInternoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007914,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007915", "SELECT [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [EnvolvidosColetaId] = @AV41EnvolvidosColetaId_Item and [DocumentoId] = @AV36DocumentoId ORDER BY [EnvolvidosColetaId], [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007915,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007916", "SELECT [DocumentoId], [EnvolvidosColetaId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007916,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007917", "SELECT [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [MedidaSegurancaId] = @AV90MedidaSegurancaId_Item and [DocumentoId] = @AV36DocumentoId ORDER BY [MedidaSegurancaId], [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007917,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007918", "SELECT [DocumentoId], [MedidaSegurancaId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007918,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007919", "SELECT [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @AV42FonteRetencaoId_Item and [DocumentoId] = @AV36DocumentoId ORDER BY [FonteRetencaoId], [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007919,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007920", "SELECT [DocumentoId], [FonteRetencaoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007920,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007921", "SELECT [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WHERE [SetorInternoId] = @AV43SetorInternoId_Item and [DocumentoId] = @AV36DocumentoId ORDER BY [SetorInternoId], [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007921,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007922", "SELECT [DocumentoId], [SetorInternoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @AV36DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007922,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007923", "SELECT [MedidaSegurancaAtivo], [MedidaSegurancaId], [MedidaSegurancaNome] FROM [MedidaSeguranca] WHERE [MedidaSegurancaAtivo] = 1 ORDER BY [MedidaSegurancaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007923,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007924", "SELECT [EnvolvidosColetaAtivo], [EnvolvidosColetaId], [EnvolvidosColetaNome] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaAtivo] = 1 ORDER BY [EnvolvidosColetaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007924,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007925", "SELECT [CompartInternoAtivo], [CompartInternoId], [CompartInternoNome] FROM [CompartInterno] WHERE [CompartInternoAtivo] = 1 ORDER BY [CompartInternoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007925,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007926", "SELECT [SetorInternoAtivo], [SetorInternoId], [SetorInternoNome] FROM [SetorInterno] WHERE [SetorInternoAtivo] = 1 ORDER BY [SetorInternoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007926,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007927", "SELECT [FonteRetencaoAtivo], [FonteRetencaoId], [FonteRetencaoNome] FROM [FonteRetencao] WHERE [FonteRetencaoAtivo] = 1 ORDER BY [FonteRetencaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007927,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007928", "SELECT [CategoriaAtivo], [CategoriaId], [CategoriaNome] FROM [Categoria] WHERE [CategoriaAtivo] = 1 ORDER BY [CategoriaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007928,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007929", "SELECT [TipoDadoAtivo], [TipoDadoId], [TipoDadoNome] FROM [TipoDado] WHERE [TipoDadoAtivo] = 1 ORDER BY [TipoDadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007929,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007930", "SELECT [FerramentaColetaAtivo], [FerramentaColetaId], [FerramentaColetaNome] FROM [FerramentaColeta] WHERE [FerramentaColetaAtivo] = 1 ORDER BY [FerramentaColetaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007930,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007931", "SELECT [AbrangenciaGeograficaAtivo], [AbrangenciaGeograficaId], [AbrangenciaGeograficaNome] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaAtivo] = 1 ORDER BY [AbrangenciaGeograficaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007931,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007932", "SELECT [FrequenciaTratamentoAtivo], [FrequenciaTratamentoId], [FrequenciaTratamentoNome] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoAtivo] = 1 ORDER BY [FrequenciaTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007932,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007933", "SELECT [TipoDescarteAtivo], [TipoDescarteId], [TipoDescarteNome] FROM [TipoDescarte] WHERE [TipoDescarteAtivo] = 1 ORDER BY [TipoDescarteNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007933,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007934", "SELECT [TempoRetencaoAtivo], [TempoRetencaoId], [TempoRetencaoNome] FROM [TempoRetencao] WHERE [TempoRetencaoAtivo] = 1 ORDER BY [TempoRetencaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007934,100, GxCacheFrequency.OFF ,false,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 22 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 23 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 24 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 25 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 26 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 27 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 28 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 29 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 31 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 32 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
  }

}

}
