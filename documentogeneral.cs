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
   public class documentogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public documentogeneral( )
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

      public documentogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId )
      {
         this.A75DocumentoId = aP0_DocumentoId;
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
         dynDocumentoProcessoId = new GXCombobox();
         dynSubprocessoId = new GXCombobox();
         dynPersonaId = new GXCombobox();
         dynEncarregadoId = new GXCombobox();
         cmbDocumentoAtivo = new GXCombobox();
         dynCategoriaId = new GXCombobox();
         dynTipoDadoId = new GXCombobox();
         dynFerramentaColetaId = new GXCombobox();
         dynAbrangenciaGeograficaId = new GXCombobox();
         dynFrequenciaTratamentoId = new GXCombobox();
         dynTipoDescarteId = new GXCombobox();
         dynTempoRetencaoId = new GXCombobox();
         radDocumentoPrevColetaDados = new GXRadio();
         chkDocumentoDadosGrupoVul = new GXCheckbox();
         chkDocumentoDadosCriancaAdolesc = new GXCheckbox();
         dynMedidaSegurancaId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "DocumentoId");
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
                  A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A75DocumentoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DOCUMENTOPROCESSOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLADOCUMENTOPROCESSOID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SUBPROCESSOID") == 0 )
               {
                  A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLASUBPROCESSOID642( A75DocumentoId) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"PERSONAID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAPERSONAID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ENCARREGADOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAENCARREGADOID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"CATEGORIAID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLACATEGORIAID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TIPODADOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLATIPODADOID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"FERRAMENTACOLETAID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAFERRAMENTACOLETAID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ABRANGENCIAGEOGRAFICAID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAABRANGENCIAGEOGRAFICAID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"FREQUENCIATRATAMENTOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAFREQUENCIATRATAMENTOID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TIPODESCARTEID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLATIPODESCARTEID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TEMPORETENCAOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLATEMPORETENCAOID642( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MEDIDASEGURANCAID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAMEDIDASEGURANCAID642( ) ;
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
                  gxfirstwebparm = GetFirstPar( "DocumentoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "DocumentoId");
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
            PA642( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV20Pgmname = "DocumentoGeneral";
               context.Gx_err = 0;
               edtavArearesponsavelnome_Enabled = 0;
               AssignProp(sPrefix, false, edtavArearesponsavelnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelnome_Enabled), 5, 0), true);
               GXADOCUMENTOPROCESSOID_html642( ) ;
               GXAPERSONAID_html642( ) ;
               GXAENCARREGADOID_html642( ) ;
               GXACATEGORIAID_html642( ) ;
               GXATIPODADOID_html642( ) ;
               GXAFERRAMENTACOLETAID_html642( ) ;
               GXAABRANGENCIAGEOGRAFICAID_html642( ) ;
               GXAFREQUENCIATRATAMENTOID_html642( ) ;
               GXATIPODESCARTEID_html642( ) ;
               GXATEMPORETENCAOID_html642( ) ;
               GXAMEDIDASEGURANCAID_html642( ) ;
               /* Using cursor H00642 */
               pr_default.execute(0, new Object[] {A75DocumentoId});
               A84DocumentoFluxoTratDadosDesc = H00642_A84DocumentoFluxoTratDadosDesc[0];
               n84DocumentoFluxoTratDadosDesc = H00642_n84DocumentoFluxoTratDadosDesc[0];
               AssignAttri(sPrefix, false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
               A83DocumentoMedidaSegurancaDesc = H00642_A83DocumentoMedidaSegurancaDesc[0];
               n83DocumentoMedidaSegurancaDesc = H00642_n83DocumentoMedidaSegurancaDesc[0];
               AssignAttri(sPrefix, false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
               A81DocumentoDadosCriancaAdolesc = H00642_A81DocumentoDadosCriancaAdolesc[0];
               n81DocumentoDadosCriancaAdolesc = H00642_n81DocumentoDadosCriancaAdolesc[0];
               AssignAttri(sPrefix, false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
               A82DocumentoDadosGrupoVul = H00642_A82DocumentoDadosGrupoVul[0];
               n82DocumentoDadosGrupoVul = H00642_n82DocumentoDadosGrupoVul[0];
               AssignAttri(sPrefix, false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
               A80DocumentoBaseLegalNormIntExt = H00642_A80DocumentoBaseLegalNormIntExt[0];
               n80DocumentoBaseLegalNormIntExt = H00642_n80DocumentoBaseLegalNormIntExt[0];
               AssignAttri(sPrefix, false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
               A79DocumentoBaseLegalNorm = H00642_A79DocumentoBaseLegalNorm[0];
               n79DocumentoBaseLegalNorm = H00642_n79DocumentoBaseLegalNorm[0];
               AssignAttri(sPrefix, false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
               A78DocumentoPrevColetaDados = H00642_A78DocumentoPrevColetaDados[0];
               n78DocumentoPrevColetaDados = H00642_n78DocumentoPrevColetaDados[0];
               AssignAttri(sPrefix, false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
               A48TempoRetencaoId = H00642_A48TempoRetencaoId[0];
               n48TempoRetencaoId = H00642_n48TempoRetencaoId[0];
               AssignAttri(sPrefix, false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
               A45TipoDescarteId = H00642_A45TipoDescarteId[0];
               n45TipoDescarteId = H00642_n45TipoDescarteId[0];
               AssignAttri(sPrefix, false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
               A39FrequenciaTratamentoId = H00642_A39FrequenciaTratamentoId[0];
               n39FrequenciaTratamentoId = H00642_n39FrequenciaTratamentoId[0];
               AssignAttri(sPrefix, false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
               A36AbrangenciaGeograficaId = H00642_A36AbrangenciaGeograficaId[0];
               n36AbrangenciaGeograficaId = H00642_n36AbrangenciaGeograficaId[0];
               AssignAttri(sPrefix, false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
               A33FerramentaColetaId = H00642_A33FerramentaColetaId[0];
               n33FerramentaColetaId = H00642_n33FerramentaColetaId[0];
               AssignAttri(sPrefix, false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
               A30TipoDadoId = H00642_A30TipoDadoId[0];
               n30TipoDadoId = H00642_n30TipoDadoId[0];
               AssignAttri(sPrefix, false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
               A27CategoriaId = H00642_A27CategoriaId[0];
               n27CategoriaId = H00642_n27CategoriaId[0];
               AssignAttri(sPrefix, false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
               A77DocumentoFinalidadeTratamento = H00642_A77DocumentoFinalidadeTratamento[0];
               n77DocumentoFinalidadeTratamento = H00642_n77DocumentoFinalidadeTratamento[0];
               AssignAttri(sPrefix, false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
               A85DocumentoAtivo = H00642_A85DocumentoAtivo[0];
               n85DocumentoAtivo = H00642_n85DocumentoAtivo[0];
               AssignAttri(sPrefix, false, "A85DocumentoAtivo", A85DocumentoAtivo);
               A76DocumentoNome = H00642_A76DocumentoNome[0];
               n76DocumentoNome = H00642_n76DocumentoNome[0];
               AssignAttri(sPrefix, false, "A76DocumentoNome", A76DocumentoNome);
               A7EncarregadoId = H00642_A7EncarregadoId[0];
               n7EncarregadoId = H00642_n7EncarregadoId[0];
               AssignAttri(sPrefix, false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
               A13PersonaId = H00642_A13PersonaId[0];
               n13PersonaId = H00642_n13PersonaId[0];
               AssignAttri(sPrefix, false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
               A109DocumentoDataAlteracao = H00642_A109DocumentoDataAlteracao[0];
               n109DocumentoDataAlteracao = H00642_n109DocumentoDataAlteracao[0];
               AssignAttri(sPrefix, false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
               A108DocumentoDataInclusao = H00642_A108DocumentoDataInclusao[0];
               n108DocumentoDataInclusao = H00642_n108DocumentoDataInclusao[0];
               AssignAttri(sPrefix, false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
               A20SubprocessoId = H00642_A20SubprocessoId[0];
               n20SubprocessoId = H00642_n20SubprocessoId[0];
               AssignAttri(sPrefix, false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
               A106DocumentoProcessoId = H00642_A106DocumentoProcessoId[0];
               n106DocumentoProcessoId = H00642_n106DocumentoProcessoId[0];
               AssignAttri(sPrefix, false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
               pr_default.close(0);
               GXASUBPROCESSOID_html642( A75DocumentoId) ;
               WS642( ) ;
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
            context.SendWebValue( "Documento General") ;
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
            GXEncryptionTmp = "documentogeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A75DocumentoId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documentogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vABA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV17Aba, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vABA", AV17Aba);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vABA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV17Aba, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm642( )
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
         return "DocumentoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documento General" ;
      }

      protected void WB640( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "documentogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tabledocumento_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynDocumentoProcessoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDocumentoProcessoId_Internalname, "PROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDocumentoProcessoId, dynDocumentoProcessoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0)), 1, dynDocumentoProcessoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDocumentoProcessoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynDocumentoProcessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0));
            AssignProp(sPrefix, false, dynDocumentoProcessoId_Internalname, "Values", (string)(dynDocumentoProcessoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoId_Internalname, "CÓDIGO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtDocumentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynSubprocessoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynSubprocessoId_Internalname, "SUB PROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynSubprocessoId, dynSubprocessoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0)), 1, dynSubprocessoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSubprocessoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
            AssignProp(sPrefix, false, dynSubprocessoId_Internalname, "Values", (string)(dynSubprocessoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoDataInclusao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoDataInclusao_Internalname, "DATA INCLUSÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtDocumentoDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDocumentoDataInclusao_Internalname, context.localUtil.TToC( A108DocumentoDataInclusao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A108DocumentoDataInclusao, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoDataInclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoDataInclusao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDocumentoDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocumentoDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocumentoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavArearesponsavelnome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavArearesponsavelnome_Internalname, "ÁREA RESPONSÁVEL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavArearesponsavelnome_Internalname, AV15AreaResponsavelNome, StringUtil.RTrim( context.localUtil.Format( AV15AreaResponsavelNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavArearesponsavelnome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavArearesponsavelnome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoDataAlteracao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoDataAlteracao_Internalname, "DATA ÚLTIMA ALTERAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtDocumentoDataAlteracao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDocumentoDataAlteracao_Internalname, context.localUtil.TToC( A109DocumentoDataAlteracao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A109DocumentoDataAlteracao, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoDataAlteracao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoDataAlteracao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDocumentoDataAlteracao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocumentoDataAlteracao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocumentoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynPersonaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynPersonaId_Internalname, "PERSONA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynPersonaId, dynPersonaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0)), 1, dynPersonaId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynPersonaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynPersonaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0));
            AssignProp(sPrefix, false, dynPersonaId_Internalname, "Values", (string)(dynPersonaId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynEncarregadoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynEncarregadoId_Internalname, "ENCARREGADO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynEncarregadoId, dynEncarregadoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0)), 1, dynEncarregadoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEncarregadoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynEncarregadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0));
            AssignProp(sPrefix, false, dynEncarregadoId_Internalname, "Values", (string)(dynEncarregadoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoNome_Internalname, "Nome do Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentoNome_Internalname, A76DocumentoNome, StringUtil.RTrim( context.localUtil.Format( A76DocumentoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbDocumentoAtivo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbDocumentoAtivo_Internalname, "Ativo?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbDocumentoAtivo, cmbDocumentoAtivo_Internalname, StringUtil.BoolToStr( A85DocumentoAtivo), 1, cmbDocumentoAtivo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbDocumentoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            cmbDocumentoAtivo.CurrentValue = StringUtil.BoolToStr( A85DocumentoAtivo);
            AssignProp(sPrefix, false, cmbDocumentoAtivo_Internalname, "Values", (string)(cmbDocumentoAtivo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTransactiondetail_tabletratamento_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoFinalidadeTratamento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoFinalidadeTratamento_Internalname, "FINALIDADE DO TRATAMENTO DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentoFinalidadeTratamento_Internalname, A77DocumentoFinalidadeTratamento, StringUtil.RTrim( context.localUtil.Format( A77DocumentoFinalidadeTratamento, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoFinalidadeTratamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoFinalidadeTratamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynCategoriaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynCategoriaId_Internalname, "CATEGORIA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynCategoriaId, dynCategoriaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0)), 1, dynCategoriaId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCategoriaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynCategoriaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0));
            AssignProp(sPrefix, false, dynCategoriaId_Internalname, "Values", (string)(dynCategoriaId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynTipoDadoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynTipoDadoId_Internalname, "TIPO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTipoDadoId, dynTipoDadoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0)), 1, dynTipoDadoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoDadoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynTipoDadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0));
            AssignProp(sPrefix, false, dynTipoDadoId_Internalname, "Values", (string)(dynTipoDadoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynFerramentaColetaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynFerramentaColetaId_Internalname, "FERRAMENTA DE COLETA DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynFerramentaColetaId, dynFerramentaColetaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0)), 1, dynFerramentaColetaId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynFerramentaColetaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynFerramentaColetaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0));
            AssignProp(sPrefix, false, dynFerramentaColetaId_Internalname, "Values", (string)(dynFerramentaColetaId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynAbrangenciaGeograficaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynAbrangenciaGeograficaId_Internalname, "ABRANGÊNCIA/ÁREA GEOGRÁFICA DO TRATAMENTO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynAbrangenciaGeograficaId, dynAbrangenciaGeograficaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0)), 1, dynAbrangenciaGeograficaId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynAbrangenciaGeograficaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynAbrangenciaGeograficaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            AssignProp(sPrefix, false, dynAbrangenciaGeograficaId_Internalname, "Values", (string)(dynAbrangenciaGeograficaId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynFrequenciaTratamentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynFrequenciaTratamentoId_Internalname, "FREQUÊNCIA DE TRATAMENTO DOS DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynFrequenciaTratamentoId, dynFrequenciaTratamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0)), 1, dynFrequenciaTratamentoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynFrequenciaTratamentoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynFrequenciaTratamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            AssignProp(sPrefix, false, dynFrequenciaTratamentoId_Internalname, "Values", (string)(dynFrequenciaTratamentoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynTipoDescarteId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynTipoDescarteId_Internalname, "TIPO DESCARTE", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTipoDescarteId, dynTipoDescarteId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0)), 1, dynTipoDescarteId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoDescarteId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynTipoDescarteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0));
            AssignProp(sPrefix, false, dynTipoDescarteId_Internalname, "Values", (string)(dynTipoDescarteId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynTempoRetencaoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynTempoRetencaoId_Internalname, "TEMPO DE GUARDA / RETENÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTempoRetencaoId, dynTempoRetencaoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0)), 1, dynTempoRetencaoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTempoRetencaoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynTempoRetencaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0));
            AssignProp(sPrefix, false, dynTempoRetencaoId_Internalname, "Values", (string)(dynTempoRetencaoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+radDocumentoPrevColetaDados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "PREVISÃO PARA COLETA DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Radio button */
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_radio_ctrl( context, radDocumentoPrevColetaDados, radDocumentoPrevColetaDados_Internalname, StringUtil.BoolToStr( A78DocumentoPrevColetaDados), "", 1, 0, 0, 0, StyleString, ClassString, "", "", 0, radDocumentoPrevColetaDados_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoBaseLegalNorm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoBaseLegalNorm_Internalname, "BASE LEGAL - NORMATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentoBaseLegalNorm_Internalname, A79DocumentoBaseLegalNorm, StringUtil.RTrim( context.localUtil.Format( A79DocumentoBaseLegalNorm, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoBaseLegalNorm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoBaseLegalNorm_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoBaseLegalNormIntExt_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoBaseLegalNormIntExt_Internalname, "BASE LEGAL - NORMATIVO (INTERNO E EXTERNO)", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentoBaseLegalNormIntExt_Internalname, A80DocumentoBaseLegalNormIntExt, StringUtil.RTrim( context.localUtil.Format( A80DocumentoBaseLegalNormIntExt, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoBaseLegalNormIntExt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoBaseLegalNormIntExt_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocumentoDadosGrupoVul_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkDocumentoDadosGrupoVul_Internalname, "POSSUI DADOS DE GRUPOS VULNERÁVEIS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocumentoDadosGrupoVul_Internalname, StringUtil.BoolToStr( A82DocumentoDadosGrupoVul), "", "POSSUI DADOS DE GRUPOS VULNERÁVEIS", 1, chkDocumentoDadosGrupoVul.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocumentoDadosCriancaAdolesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkDocumentoDadosCriancaAdolesc_Internalname, "POSSUI DADOS DE CRIANÇA/ADOLESCENTE", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocumentoDadosCriancaAdolesc_Internalname, StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc), "", "POSSUI DADOS DE CRIANÇA/ADOLESCENTE", 1, chkDocumentoDadosCriancaAdolesc.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynMedidaSegurancaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynMedidaSegurancaId_Internalname, "MEDIDA DE SEGURANÇA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynMedidaSegurancaId, dynMedidaSegurancaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A51MedidaSegurancaId), 8, 0)), 1, dynMedidaSegurancaId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMedidaSegurancaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_DocumentoGeneral.htm");
            dynMedidaSegurancaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A51MedidaSegurancaId), 8, 0));
            AssignProp(sPrefix, false, dynMedidaSegurancaId_Internalname, "Values", (string)(dynMedidaSegurancaId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoMedidaSegurancaDesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoMedidaSegurancaDesc_Internalname, "DESCRIÇÃO DA MEDIDA DE SEGURANÇA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDocumentoMedidaSegurancaDesc_Internalname, A83DocumentoMedidaSegurancaDesc, "", "", 0, 1, edtDocumentoMedidaSegurancaDesc_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocumentoFluxoTratDadosDesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocumentoFluxoTratDadosDesc_Internalname, "DESCRIÇÃO DO FLUXO DO TRATAMENTO DOS DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDocumentoFluxoTratDadosDesc_Internalname, A84DocumentoFluxoTratDadosDesc, "", "", 0, 1, edtDocumentoFluxoTratDadosDesc_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DocumentoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modifica", bttBtnupdate_Jsonclick, 5, "Modifica", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavArearesponsavelid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16AreaResponsavelId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16AreaResponsavelId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,156);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavArearesponsavelid_Jsonclick, 0, "Attribute", "", "", "", "", edtavArearesponsavelid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START642( )
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
               Form.Meta.addItem("description", "Documento General", 0) ;
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
               STRUP640( ) ;
            }
         }
      }

      protected void WS642( )
      {
         START642( ) ;
         EVT642( ) ;
      }

      protected void EVT642( )
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
                                 STRUP640( ) ;
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
                                 STRUP640( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11642 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP640( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12642 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP640( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13642 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP640( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14642 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP640( ) ;
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
                                 STRUP640( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavArearesponsavelnome_Internalname;
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

      protected void WE642( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm642( ) ;
            }
         }
      }

      protected void PA642( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documentogeneral.aspx")), "documentogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documentogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "DocumentoId");
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
               GX_FocusControl = edtavArearesponsavelnome_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLADOCUMENTOPROCESSOID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADOCUMENTOPROCESSOID_data642( ) ;
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

      protected void GXADOCUMENTOPROCESSOID_html642( )
      {
         int gxdynajaxvalue;
         GXDLADOCUMENTOPROCESSOID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDocumentoProcessoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynDocumentoProcessoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynDocumentoProcessoId.ItemCount > 0 )
         {
            A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0))), "."));
            n106DocumentoProcessoId = false;
            AssignAttri(sPrefix, false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
         }
      }

      protected void GXDLADOCUMENTOPROCESSOID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00643 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00643_A106DocumentoProcessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00643_A107DocumentoProcessoNome[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLASUBPROCESSOID642( int A75DocumentoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUBPROCESSOID_data642( A75DocumentoId) ;
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

      protected void GXASUBPROCESSOID_html642( int A75DocumentoId )
      {
         int gxdynajaxvalue;
         GXDLASUBPROCESSOID_data642( A75DocumentoId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSubprocessoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynSubprocessoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynSubprocessoId.ItemCount > 0 )
         {
            A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0))), "."));
            n20SubprocessoId = false;
            AssignAttri(sPrefix, false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         }
      }

      protected void GXDLASUBPROCESSOID_data642( int A75DocumentoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00644 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00644_A20SubprocessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00644_A21SubprocessoNome[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLAPERSONAID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPERSONAID_data642( ) ;
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

      protected void GXAPERSONAID_html642( )
      {
         int gxdynajaxvalue;
         GXDLAPERSONAID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynPersonaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynPersonaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynPersonaId.ItemCount > 0 )
         {
            A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0))), "."));
            n13PersonaId = false;
            AssignAttri(sPrefix, false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
         }
      }

      protected void GXDLAPERSONAID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00645 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00645_A13PersonaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00645_A14PersonaNome[0]);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void GXDLAENCARREGADOID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAENCARREGADOID_data642( ) ;
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

      protected void GXAENCARREGADOID_html642( )
      {
         int gxdynajaxvalue;
         GXDLAENCARREGADOID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEncarregadoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynEncarregadoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynEncarregadoId.ItemCount > 0 )
         {
            A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0))), "."));
            n7EncarregadoId = false;
            AssignAttri(sPrefix, false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
         }
      }

      protected void GXDLAENCARREGADOID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00646 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00646_A7EncarregadoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00646_A8EncarregadoNome[0]);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void GXDLACATEGORIAID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACATEGORIAID_data642( ) ;
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

      protected void GXACATEGORIAID_html642( )
      {
         int gxdynajaxvalue;
         GXDLACATEGORIAID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynCategoriaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynCategoriaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynCategoriaId.ItemCount > 0 )
         {
            A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0))), "."));
            n27CategoriaId = false;
            AssignAttri(sPrefix, false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
         }
      }

      protected void GXDLACATEGORIAID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00647 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00647_A10ControladorId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00647_A11ControladorNome[0]);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void GXDLATIPODADOID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPODADOID_data642( ) ;
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

      protected void GXATIPODADOID_html642( )
      {
         int gxdynajaxvalue;
         GXDLATIPODADOID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTipoDadoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTipoDadoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynTipoDadoId.ItemCount > 0 )
         {
            A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0))), "."));
            n30TipoDadoId = false;
            AssignAttri(sPrefix, false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
         }
      }

      protected void GXDLATIPODADOID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00648 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00648_A30TipoDadoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00648_A31TipoDadoNome[0]);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void GXDLAFERRAMENTACOLETAID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAFERRAMENTACOLETAID_data642( ) ;
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

      protected void GXAFERRAMENTACOLETAID_html642( )
      {
         int gxdynajaxvalue;
         GXDLAFERRAMENTACOLETAID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynFerramentaColetaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynFerramentaColetaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynFerramentaColetaId.ItemCount > 0 )
         {
            A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0))), "."));
            n33FerramentaColetaId = false;
            AssignAttri(sPrefix, false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         }
      }

      protected void GXDLAFERRAMENTACOLETAID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00649 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00649_A33FerramentaColetaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00649_A34FerramentaColetaNome[0]);
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void GXDLAABRANGENCIAGEOGRAFICAID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAABRANGENCIAGEOGRAFICAID_data642( ) ;
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

      protected void GXAABRANGENCIAGEOGRAFICAID_html642( )
      {
         int gxdynajaxvalue;
         GXDLAABRANGENCIAGEOGRAFICAID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynAbrangenciaGeograficaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynAbrangenciaGeograficaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynAbrangenciaGeograficaId.ItemCount > 0 )
         {
            A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0))), "."));
            n36AbrangenciaGeograficaId = false;
            AssignAttri(sPrefix, false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         }
      }

      protected void GXDLAABRANGENCIAGEOGRAFICAID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006410 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006410_A36AbrangenciaGeograficaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H006410_A37AbrangenciaGeograficaNome[0]);
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      protected void GXDLAFREQUENCIATRATAMENTOID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAFREQUENCIATRATAMENTOID_data642( ) ;
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

      protected void GXAFREQUENCIATRATAMENTOID_html642( )
      {
         int gxdynajaxvalue;
         GXDLAFREQUENCIATRATAMENTOID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynFrequenciaTratamentoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynFrequenciaTratamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynFrequenciaTratamentoId.ItemCount > 0 )
         {
            A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0))), "."));
            n39FrequenciaTratamentoId = false;
            AssignAttri(sPrefix, false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         }
      }

      protected void GXDLAFREQUENCIATRATAMENTOID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006411 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006411_A39FrequenciaTratamentoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H006411_A40FrequenciaTratamentoNome[0]);
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void GXDLATIPODESCARTEID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPODESCARTEID_data642( ) ;
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

      protected void GXATIPODESCARTEID_html642( )
      {
         int gxdynajaxvalue;
         GXDLATIPODESCARTEID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTipoDescarteId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTipoDescarteId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynTipoDescarteId.ItemCount > 0 )
         {
            A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0))), "."));
            n45TipoDescarteId = false;
            AssignAttri(sPrefix, false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         }
      }

      protected void GXDLATIPODESCARTEID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006412 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006412_A45TipoDescarteId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H006412_A46TipoDescarteNome[0]);
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void GXDLATEMPORETENCAOID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATEMPORETENCAOID_data642( ) ;
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

      protected void GXATEMPORETENCAOID_html642( )
      {
         int gxdynajaxvalue;
         GXDLATEMPORETENCAOID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTempoRetencaoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTempoRetencaoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynTempoRetencaoId.ItemCount > 0 )
         {
            A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0))), "."));
            n48TempoRetencaoId = false;
            AssignAttri(sPrefix, false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
         }
      }

      protected void GXDLATEMPORETENCAOID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006413 */
         pr_default.execute(11);
         while ( (pr_default.getStatus(11) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006413_A48TempoRetencaoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H006413_A49TempoRetencaoNome[0]);
            pr_default.readNext(11);
         }
         pr_default.close(11);
      }

      protected void GXDLAMEDIDASEGURANCAID642( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASEGURANCAID_data642( ) ;
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

      protected void GXAMEDIDASEGURANCAID_html642( )
      {
         int gxdynajaxvalue;
         GXDLAMEDIDASEGURANCAID_data642( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMedidaSegurancaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynMedidaSegurancaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynMedidaSegurancaId.ItemCount > 0 )
         {
            A51MedidaSegurancaId = (int)(NumberUtil.Val( dynMedidaSegurancaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A51MedidaSegurancaId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
         }
      }

      protected void GXDLAMEDIDASEGURANCAID_data642( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006414 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006414_A51MedidaSegurancaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H006414_A52MedidaSegurancaNome[0]);
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXADOCUMENTOPROCESSOID_html642( ) ;
            GXAPERSONAID_html642( ) ;
            GXAENCARREGADOID_html642( ) ;
            GXACATEGORIAID_html642( ) ;
            GXATIPODADOID_html642( ) ;
            GXAFERRAMENTACOLETAID_html642( ) ;
            GXAABRANGENCIAGEOGRAFICAID_html642( ) ;
            GXAFREQUENCIATRATAMENTOID_html642( ) ;
            GXATIPODESCARTEID_html642( ) ;
            GXATEMPORETENCAOID_html642( ) ;
            GXAMEDIDASEGURANCAID_html642( ) ;
            GXASUBPROCESSOID_html642( A75DocumentoId) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynDocumentoProcessoId.ItemCount > 0 )
         {
            A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0))), "."));
            n106DocumentoProcessoId = false;
            AssignAttri(sPrefix, false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDocumentoProcessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0));
            AssignProp(sPrefix, false, dynDocumentoProcessoId_Internalname, "Values", dynDocumentoProcessoId.ToJavascriptSource(), true);
         }
         if ( dynSubprocessoId.ItemCount > 0 )
         {
            A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0))), "."));
            n20SubprocessoId = false;
            AssignAttri(sPrefix, false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
            AssignProp(sPrefix, false, dynSubprocessoId_Internalname, "Values", dynSubprocessoId.ToJavascriptSource(), true);
         }
         if ( dynPersonaId.ItemCount > 0 )
         {
            A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0))), "."));
            n13PersonaId = false;
            AssignAttri(sPrefix, false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynPersonaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0));
            AssignProp(sPrefix, false, dynPersonaId_Internalname, "Values", dynPersonaId.ToJavascriptSource(), true);
         }
         if ( dynEncarregadoId.ItemCount > 0 )
         {
            A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0))), "."));
            n7EncarregadoId = false;
            AssignAttri(sPrefix, false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEncarregadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0));
            AssignProp(sPrefix, false, dynEncarregadoId_Internalname, "Values", dynEncarregadoId.ToJavascriptSource(), true);
         }
         if ( cmbDocumentoAtivo.ItemCount > 0 )
         {
            A85DocumentoAtivo = StringUtil.StrToBool( cmbDocumentoAtivo.getValidValue(StringUtil.BoolToStr( A85DocumentoAtivo)));
            n85DocumentoAtivo = false;
            AssignAttri(sPrefix, false, "A85DocumentoAtivo", A85DocumentoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentoAtivo.CurrentValue = StringUtil.BoolToStr( A85DocumentoAtivo);
            AssignProp(sPrefix, false, cmbDocumentoAtivo_Internalname, "Values", cmbDocumentoAtivo.ToJavascriptSource(), true);
         }
         if ( dynCategoriaId.ItemCount > 0 )
         {
            A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0))), "."));
            n27CategoriaId = false;
            AssignAttri(sPrefix, false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCategoriaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0));
            AssignProp(sPrefix, false, dynCategoriaId_Internalname, "Values", dynCategoriaId.ToJavascriptSource(), true);
         }
         if ( dynTipoDadoId.ItemCount > 0 )
         {
            A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0))), "."));
            n30TipoDadoId = false;
            AssignAttri(sPrefix, false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoDadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0));
            AssignProp(sPrefix, false, dynTipoDadoId_Internalname, "Values", dynTipoDadoId.ToJavascriptSource(), true);
         }
         if ( dynFerramentaColetaId.ItemCount > 0 )
         {
            A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0))), "."));
            n33FerramentaColetaId = false;
            AssignAttri(sPrefix, false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynFerramentaColetaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0));
            AssignProp(sPrefix, false, dynFerramentaColetaId_Internalname, "Values", dynFerramentaColetaId.ToJavascriptSource(), true);
         }
         if ( dynAbrangenciaGeograficaId.ItemCount > 0 )
         {
            A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0))), "."));
            n36AbrangenciaGeograficaId = false;
            AssignAttri(sPrefix, false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynAbrangenciaGeograficaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            AssignProp(sPrefix, false, dynAbrangenciaGeograficaId_Internalname, "Values", dynAbrangenciaGeograficaId.ToJavascriptSource(), true);
         }
         if ( dynFrequenciaTratamentoId.ItemCount > 0 )
         {
            A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0))), "."));
            n39FrequenciaTratamentoId = false;
            AssignAttri(sPrefix, false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynFrequenciaTratamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            AssignProp(sPrefix, false, dynFrequenciaTratamentoId_Internalname, "Values", dynFrequenciaTratamentoId.ToJavascriptSource(), true);
         }
         if ( dynTipoDescarteId.ItemCount > 0 )
         {
            A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0))), "."));
            n45TipoDescarteId = false;
            AssignAttri(sPrefix, false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoDescarteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0));
            AssignProp(sPrefix, false, dynTipoDescarteId_Internalname, "Values", dynTipoDescarteId.ToJavascriptSource(), true);
         }
         if ( dynTempoRetencaoId.ItemCount > 0 )
         {
            A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0))), "."));
            n48TempoRetencaoId = false;
            AssignAttri(sPrefix, false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTempoRetencaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0));
            AssignProp(sPrefix, false, dynTempoRetencaoId_Internalname, "Values", dynTempoRetencaoId.ToJavascriptSource(), true);
         }
         A78DocumentoPrevColetaDados = StringUtil.StrToBool( StringUtil.BoolToStr( A78DocumentoPrevColetaDados));
         n78DocumentoPrevColetaDados = false;
         AssignAttri(sPrefix, false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
         A82DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( A82DocumentoDadosGrupoVul));
         n82DocumentoDadosGrupoVul = false;
         AssignAttri(sPrefix, false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
         A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc));
         n81DocumentoDadosCriancaAdolesc = false;
         AssignAttri(sPrefix, false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
         if ( dynMedidaSegurancaId.ItemCount > 0 )
         {
            A51MedidaSegurancaId = (int)(NumberUtil.Val( dynMedidaSegurancaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A51MedidaSegurancaId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidaSegurancaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A51MedidaSegurancaId), 8, 0));
            AssignProp(sPrefix, false, dynMedidaSegurancaId_Internalname, "Values", dynMedidaSegurancaId.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF642( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV20Pgmname = "DocumentoGeneral";
         context.Gx_err = 0;
         edtavArearesponsavelnome_Enabled = 0;
         AssignProp(sPrefix, false, edtavArearesponsavelnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelnome_Enabled), 5, 0), true);
      }

      protected void RF642( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H006415 */
            pr_default.execute(13, new Object[] {A75DocumentoId});
            while ( (pr_default.getStatus(13) != 101) )
            {
               A51MedidaSegurancaId = H006415_A51MedidaSegurancaId[0];
               AssignAttri(sPrefix, false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
               GXADOCUMENTOPROCESSOID_html642( ) ;
               GXAPERSONAID_html642( ) ;
               GXAENCARREGADOID_html642( ) ;
               GXACATEGORIAID_html642( ) ;
               GXATIPODADOID_html642( ) ;
               GXAFERRAMENTACOLETAID_html642( ) ;
               GXAABRANGENCIAGEOGRAFICAID_html642( ) ;
               GXAFREQUENCIATRATAMENTOID_html642( ) ;
               GXATIPODESCARTEID_html642( ) ;
               GXATEMPORETENCAOID_html642( ) ;
               GXAMEDIDASEGURANCAID_html642( ) ;
               GXASUBPROCESSOID_html642( A75DocumentoId) ;
               /* Execute user event: Load */
               E12642 ();
               pr_default.readNext(13);
            }
            pr_default.close(13);
            WB640( ) ;
         }
      }

      protected void send_integrity_lvl_hashes642( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vABA", AV17Aba);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vABA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV17Aba, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV20Pgmname = "DocumentoGeneral";
         context.Gx_err = 0;
         edtavArearesponsavelnome_Enabled = 0;
         AssignProp(sPrefix, false, edtavArearesponsavelnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelnome_Enabled), 5, 0), true);
         GXADOCUMENTOPROCESSOID_html642( ) ;
         GXAPERSONAID_html642( ) ;
         GXAENCARREGADOID_html642( ) ;
         GXACATEGORIAID_html642( ) ;
         GXATIPODADOID_html642( ) ;
         GXAFERRAMENTACOLETAID_html642( ) ;
         GXAABRANGENCIAGEOGRAFICAID_html642( ) ;
         GXAFREQUENCIATRATAMENTOID_html642( ) ;
         GXATIPODESCARTEID_html642( ) ;
         GXATEMPORETENCAOID_html642( ) ;
         GXAMEDIDASEGURANCAID_html642( ) ;
         /* Using cursor H006416 */
         pr_default.execute(14, new Object[] {A75DocumentoId});
         A84DocumentoFluxoTratDadosDesc = H006416_A84DocumentoFluxoTratDadosDesc[0];
         n84DocumentoFluxoTratDadosDesc = H006416_n84DocumentoFluxoTratDadosDesc[0];
         AssignAttri(sPrefix, false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
         A83DocumentoMedidaSegurancaDesc = H006416_A83DocumentoMedidaSegurancaDesc[0];
         n83DocumentoMedidaSegurancaDesc = H006416_n83DocumentoMedidaSegurancaDesc[0];
         AssignAttri(sPrefix, false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
         A81DocumentoDadosCriancaAdolesc = H006416_A81DocumentoDadosCriancaAdolesc[0];
         n81DocumentoDadosCriancaAdolesc = H006416_n81DocumentoDadosCriancaAdolesc[0];
         AssignAttri(sPrefix, false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
         A82DocumentoDadosGrupoVul = H006416_A82DocumentoDadosGrupoVul[0];
         n82DocumentoDadosGrupoVul = H006416_n82DocumentoDadosGrupoVul[0];
         AssignAttri(sPrefix, false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
         A80DocumentoBaseLegalNormIntExt = H006416_A80DocumentoBaseLegalNormIntExt[0];
         n80DocumentoBaseLegalNormIntExt = H006416_n80DocumentoBaseLegalNormIntExt[0];
         AssignAttri(sPrefix, false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
         A79DocumentoBaseLegalNorm = H006416_A79DocumentoBaseLegalNorm[0];
         n79DocumentoBaseLegalNorm = H006416_n79DocumentoBaseLegalNorm[0];
         AssignAttri(sPrefix, false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
         A78DocumentoPrevColetaDados = H006416_A78DocumentoPrevColetaDados[0];
         n78DocumentoPrevColetaDados = H006416_n78DocumentoPrevColetaDados[0];
         AssignAttri(sPrefix, false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
         A48TempoRetencaoId = H006416_A48TempoRetencaoId[0];
         n48TempoRetencaoId = H006416_n48TempoRetencaoId[0];
         AssignAttri(sPrefix, false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
         A45TipoDescarteId = H006416_A45TipoDescarteId[0];
         n45TipoDescarteId = H006416_n45TipoDescarteId[0];
         AssignAttri(sPrefix, false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         A39FrequenciaTratamentoId = H006416_A39FrequenciaTratamentoId[0];
         n39FrequenciaTratamentoId = H006416_n39FrequenciaTratamentoId[0];
         AssignAttri(sPrefix, false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         A36AbrangenciaGeograficaId = H006416_A36AbrangenciaGeograficaId[0];
         n36AbrangenciaGeograficaId = H006416_n36AbrangenciaGeograficaId[0];
         AssignAttri(sPrefix, false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         A33FerramentaColetaId = H006416_A33FerramentaColetaId[0];
         n33FerramentaColetaId = H006416_n33FerramentaColetaId[0];
         AssignAttri(sPrefix, false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         A30TipoDadoId = H006416_A30TipoDadoId[0];
         n30TipoDadoId = H006416_n30TipoDadoId[0];
         AssignAttri(sPrefix, false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
         A27CategoriaId = H006416_A27CategoriaId[0];
         n27CategoriaId = H006416_n27CategoriaId[0];
         AssignAttri(sPrefix, false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
         A77DocumentoFinalidadeTratamento = H006416_A77DocumentoFinalidadeTratamento[0];
         n77DocumentoFinalidadeTratamento = H006416_n77DocumentoFinalidadeTratamento[0];
         AssignAttri(sPrefix, false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
         A85DocumentoAtivo = H006416_A85DocumentoAtivo[0];
         n85DocumentoAtivo = H006416_n85DocumentoAtivo[0];
         AssignAttri(sPrefix, false, "A85DocumentoAtivo", A85DocumentoAtivo);
         A76DocumentoNome = H006416_A76DocumentoNome[0];
         n76DocumentoNome = H006416_n76DocumentoNome[0];
         AssignAttri(sPrefix, false, "A76DocumentoNome", A76DocumentoNome);
         A7EncarregadoId = H006416_A7EncarregadoId[0];
         n7EncarregadoId = H006416_n7EncarregadoId[0];
         AssignAttri(sPrefix, false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
         A13PersonaId = H006416_A13PersonaId[0];
         n13PersonaId = H006416_n13PersonaId[0];
         AssignAttri(sPrefix, false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
         A109DocumentoDataAlteracao = H006416_A109DocumentoDataAlteracao[0];
         n109DocumentoDataAlteracao = H006416_n109DocumentoDataAlteracao[0];
         AssignAttri(sPrefix, false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
         A108DocumentoDataInclusao = H006416_A108DocumentoDataInclusao[0];
         n108DocumentoDataInclusao = H006416_n108DocumentoDataInclusao[0];
         AssignAttri(sPrefix, false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
         A20SubprocessoId = H006416_A20SubprocessoId[0];
         n20SubprocessoId = H006416_n20SubprocessoId[0];
         AssignAttri(sPrefix, false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         A106DocumentoProcessoId = H006416_A106DocumentoProcessoId[0];
         n106DocumentoProcessoId = H006416_n106DocumentoProcessoId[0];
         AssignAttri(sPrefix, false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
         pr_default.close(14);
         GXASUBPROCESSOID_html642( A75DocumentoId) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP640( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11642 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA75DocumentoId"), ",", "."));
            /* Read variables values. */
            dynDocumentoProcessoId.CurrentValue = cgiGet( dynDocumentoProcessoId_Internalname);
            A106DocumentoProcessoId = (int)(NumberUtil.Val( cgiGet( dynDocumentoProcessoId_Internalname), "."));
            n106DocumentoProcessoId = false;
            AssignAttri(sPrefix, false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
            dynSubprocessoId.CurrentValue = cgiGet( dynSubprocessoId_Internalname);
            A20SubprocessoId = (int)(NumberUtil.Val( cgiGet( dynSubprocessoId_Internalname), "."));
            n20SubprocessoId = false;
            AssignAttri(sPrefix, false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            A108DocumentoDataInclusao = context.localUtil.CToT( cgiGet( edtDocumentoDataInclusao_Internalname));
            n108DocumentoDataInclusao = false;
            AssignAttri(sPrefix, false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            AV15AreaResponsavelNome = cgiGet( edtavArearesponsavelnome_Internalname);
            AssignAttri(sPrefix, false, "AV15AreaResponsavelNome", AV15AreaResponsavelNome);
            A109DocumentoDataAlteracao = context.localUtil.CToT( cgiGet( edtDocumentoDataAlteracao_Internalname));
            n109DocumentoDataAlteracao = false;
            AssignAttri(sPrefix, false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            dynPersonaId.CurrentValue = cgiGet( dynPersonaId_Internalname);
            A13PersonaId = (int)(NumberUtil.Val( cgiGet( dynPersonaId_Internalname), "."));
            n13PersonaId = false;
            AssignAttri(sPrefix, false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
            dynEncarregadoId.CurrentValue = cgiGet( dynEncarregadoId_Internalname);
            A7EncarregadoId = (int)(NumberUtil.Val( cgiGet( dynEncarregadoId_Internalname), "."));
            n7EncarregadoId = false;
            AssignAttri(sPrefix, false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
            A76DocumentoNome = cgiGet( edtDocumentoNome_Internalname);
            n76DocumentoNome = false;
            AssignAttri(sPrefix, false, "A76DocumentoNome", A76DocumentoNome);
            cmbDocumentoAtivo.CurrentValue = cgiGet( cmbDocumentoAtivo_Internalname);
            A85DocumentoAtivo = StringUtil.StrToBool( cgiGet( cmbDocumentoAtivo_Internalname));
            n85DocumentoAtivo = false;
            AssignAttri(sPrefix, false, "A85DocumentoAtivo", A85DocumentoAtivo);
            A77DocumentoFinalidadeTratamento = cgiGet( edtDocumentoFinalidadeTratamento_Internalname);
            n77DocumentoFinalidadeTratamento = false;
            AssignAttri(sPrefix, false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
            dynCategoriaId.CurrentValue = cgiGet( dynCategoriaId_Internalname);
            A27CategoriaId = (int)(NumberUtil.Val( cgiGet( dynCategoriaId_Internalname), "."));
            n27CategoriaId = false;
            AssignAttri(sPrefix, false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
            dynTipoDadoId.CurrentValue = cgiGet( dynTipoDadoId_Internalname);
            A30TipoDadoId = (int)(NumberUtil.Val( cgiGet( dynTipoDadoId_Internalname), "."));
            n30TipoDadoId = false;
            AssignAttri(sPrefix, false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
            dynFerramentaColetaId.CurrentValue = cgiGet( dynFerramentaColetaId_Internalname);
            A33FerramentaColetaId = (int)(NumberUtil.Val( cgiGet( dynFerramentaColetaId_Internalname), "."));
            n33FerramentaColetaId = false;
            AssignAttri(sPrefix, false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            dynAbrangenciaGeograficaId.CurrentValue = cgiGet( dynAbrangenciaGeograficaId_Internalname);
            A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( cgiGet( dynAbrangenciaGeograficaId_Internalname), "."));
            n36AbrangenciaGeograficaId = false;
            AssignAttri(sPrefix, false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            dynFrequenciaTratamentoId.CurrentValue = cgiGet( dynFrequenciaTratamentoId_Internalname);
            A39FrequenciaTratamentoId = (int)(NumberUtil.Val( cgiGet( dynFrequenciaTratamentoId_Internalname), "."));
            n39FrequenciaTratamentoId = false;
            AssignAttri(sPrefix, false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            dynTipoDescarteId.CurrentValue = cgiGet( dynTipoDescarteId_Internalname);
            A45TipoDescarteId = (int)(NumberUtil.Val( cgiGet( dynTipoDescarteId_Internalname), "."));
            n45TipoDescarteId = false;
            AssignAttri(sPrefix, false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            dynTempoRetencaoId.CurrentValue = cgiGet( dynTempoRetencaoId_Internalname);
            A48TempoRetencaoId = (int)(NumberUtil.Val( cgiGet( dynTempoRetencaoId_Internalname), "."));
            n48TempoRetencaoId = false;
            AssignAttri(sPrefix, false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
            A78DocumentoPrevColetaDados = StringUtil.StrToBool( cgiGet( radDocumentoPrevColetaDados_Internalname));
            n78DocumentoPrevColetaDados = false;
            AssignAttri(sPrefix, false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
            A79DocumentoBaseLegalNorm = cgiGet( edtDocumentoBaseLegalNorm_Internalname);
            n79DocumentoBaseLegalNorm = false;
            AssignAttri(sPrefix, false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
            A80DocumentoBaseLegalNormIntExt = cgiGet( edtDocumentoBaseLegalNormIntExt_Internalname);
            n80DocumentoBaseLegalNormIntExt = false;
            AssignAttri(sPrefix, false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
            A82DocumentoDadosGrupoVul = StringUtil.StrToBool( cgiGet( chkDocumentoDadosGrupoVul_Internalname));
            n82DocumentoDadosGrupoVul = false;
            AssignAttri(sPrefix, false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
            A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( cgiGet( chkDocumentoDadosCriancaAdolesc_Internalname));
            n81DocumentoDadosCriancaAdolesc = false;
            AssignAttri(sPrefix, false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
            dynMedidaSegurancaId.CurrentValue = cgiGet( dynMedidaSegurancaId_Internalname);
            A51MedidaSegurancaId = (int)(NumberUtil.Val( cgiGet( dynMedidaSegurancaId_Internalname), "."));
            AssignAttri(sPrefix, false, "A51MedidaSegurancaId", StringUtil.LTrimStr( (decimal)(A51MedidaSegurancaId), 8, 0));
            A83DocumentoMedidaSegurancaDesc = cgiGet( edtDocumentoMedidaSegurancaDesc_Internalname);
            n83DocumentoMedidaSegurancaDesc = false;
            AssignAttri(sPrefix, false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
            A84DocumentoFluxoTratDadosDesc = cgiGet( edtDocumentoFluxoTratDadosDesc_Internalname);
            n84DocumentoFluxoTratDadosDesc = false;
            AssignAttri(sPrefix, false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavArearesponsavelid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavArearesponsavelid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAREARESPONSAVELID");
               GX_FocusControl = edtavArearesponsavelid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16AreaResponsavelId = 0;
               AssignAttri(sPrefix, false, "AV16AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV16AreaResponsavelId), 8, 0));
            }
            else
            {
               AV16AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( edtavArearesponsavelid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV16AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV16AreaResponsavelId), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXADOCUMENTOPROCESSOID_html642( ) ;
            GXAPERSONAID_html642( ) ;
            GXAENCARREGADOID_html642( ) ;
            GXACATEGORIAID_html642( ) ;
            GXATIPODADOID_html642( ) ;
            GXAFERRAMENTACOLETAID_html642( ) ;
            GXAABRANGENCIAGEOGRAFICAID_html642( ) ;
            GXAFREQUENCIATRATAMENTOID_html642( ) ;
            GXATIPODESCARTEID_html642( ) ;
            GXATEMPORETENCAOID_html642( ) ;
            GXAMEDIDASEGURANCAID_html642( ) ;
            GXASUBPROCESSOID_html642( A75DocumentoId) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11642 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11642( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12642( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavArearesponsavelid_Visible = 0;
         AssignProp(sPrefix, false, edtavArearesponsavelid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelid_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13642( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "documento.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A75DocumentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV17Aba));
            CallWebObject(formatLink("documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E14642( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "documento.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A75DocumentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV17Aba));
            CallWebObject(formatLink("documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV20Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Documento";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A75DocumentoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
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
         PA642( ) ;
         WS642( ) ;
         WE642( ) ;
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
         sCtrlA75DocumentoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA642( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "documentogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA642( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A75DocumentoId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         wcpOA75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA75DocumentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A75DocumentoId != wcpOA75DocumentoId ) ) )
         {
            setjustcreated();
         }
         wcpOA75DocumentoId = A75DocumentoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA75DocumentoId = cgiGet( sPrefix+"A75DocumentoId_CTRL");
         if ( StringUtil.Len( sCtrlA75DocumentoId) > 0 )
         {
            A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sCtrlA75DocumentoId), ",", "."));
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         else
         {
            A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A75DocumentoId_PARM"), ",", "."));
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
         PA642( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS642( ) ;
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
         WS642( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A75DocumentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA75DocumentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A75DocumentoId_CTRL", StringUtil.RTrim( sCtrlA75DocumentoId));
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
         WE642( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417261088", true, true);
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
         context.AddJavascriptSource("documentogeneral.js", "?202312417261089", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynDocumentoProcessoId.Name = "DOCUMENTOPROCESSOID";
         dynDocumentoProcessoId.WebTags = "";
         dynSubprocessoId.Name = "SUBPROCESSOID";
         dynSubprocessoId.WebTags = "";
         dynPersonaId.Name = "PERSONAID";
         dynPersonaId.WebTags = "";
         dynEncarregadoId.Name = "ENCARREGADOID";
         dynEncarregadoId.WebTags = "";
         cmbDocumentoAtivo.Name = "DOCUMENTOATIVO";
         cmbDocumentoAtivo.WebTags = "";
         cmbDocumentoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbDocumentoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbDocumentoAtivo.ItemCount > 0 )
         {
         }
         dynCategoriaId.Name = "CATEGORIAID";
         dynCategoriaId.WebTags = "";
         dynTipoDadoId.Name = "TIPODADOID";
         dynTipoDadoId.WebTags = "";
         dynFerramentaColetaId.Name = "FERRAMENTACOLETAID";
         dynFerramentaColetaId.WebTags = "";
         dynAbrangenciaGeograficaId.Name = "ABRANGENCIAGEOGRAFICAID";
         dynAbrangenciaGeograficaId.WebTags = "";
         dynFrequenciaTratamentoId.Name = "FREQUENCIATRATAMENTOID";
         dynFrequenciaTratamentoId.WebTags = "";
         dynTipoDescarteId.Name = "TIPODESCARTEID";
         dynTipoDescarteId.WebTags = "";
         dynTempoRetencaoId.Name = "TEMPORETENCAOID";
         dynTempoRetencaoId.WebTags = "";
         radDocumentoPrevColetaDados.Name = "DOCUMENTOPREVCOLETADADOS";
         radDocumentoPrevColetaDados.WebTags = "";
         radDocumentoPrevColetaDados.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         radDocumentoPrevColetaDados.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         chkDocumentoDadosGrupoVul.Name = "DOCUMENTODADOSGRUPOVUL";
         chkDocumentoDadosGrupoVul.WebTags = "";
         chkDocumentoDadosGrupoVul.Caption = "";
         AssignProp(sPrefix, false, chkDocumentoDadosGrupoVul_Internalname, "TitleCaption", chkDocumentoDadosGrupoVul.Caption, true);
         chkDocumentoDadosGrupoVul.CheckedValue = "false";
         chkDocumentoDadosCriancaAdolesc.Name = "DOCUMENTODADOSCRIANCAADOLESC";
         chkDocumentoDadosCriancaAdolesc.WebTags = "";
         chkDocumentoDadosCriancaAdolesc.Caption = "";
         AssignProp(sPrefix, false, chkDocumentoDadosCriancaAdolesc_Internalname, "TitleCaption", chkDocumentoDadosCriancaAdolesc.Caption, true);
         chkDocumentoDadosCriancaAdolesc.CheckedValue = "false";
         dynMedidaSegurancaId.Name = "MEDIDASEGURANCAID";
         dynMedidaSegurancaId.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynDocumentoProcessoId_Internalname = sPrefix+"DOCUMENTOPROCESSOID";
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID";
         dynSubprocessoId_Internalname = sPrefix+"SUBPROCESSOID";
         edtDocumentoDataInclusao_Internalname = sPrefix+"DOCUMENTODATAINCLUSAO";
         edtavArearesponsavelnome_Internalname = sPrefix+"vAREARESPONSAVELNOME";
         edtDocumentoDataAlteracao_Internalname = sPrefix+"DOCUMENTODATAALTERACAO";
         dynPersonaId_Internalname = sPrefix+"PERSONAID";
         dynEncarregadoId_Internalname = sPrefix+"ENCARREGADOID";
         edtDocumentoNome_Internalname = sPrefix+"DOCUMENTONOME";
         cmbDocumentoAtivo_Internalname = sPrefix+"DOCUMENTOATIVO";
         divTransactiondetail_tabledocumento_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEDOCUMENTO";
         edtDocumentoFinalidadeTratamento_Internalname = sPrefix+"DOCUMENTOFINALIDADETRATAMENTO";
         dynCategoriaId_Internalname = sPrefix+"CATEGORIAID";
         dynTipoDadoId_Internalname = sPrefix+"TIPODADOID";
         dynFerramentaColetaId_Internalname = sPrefix+"FERRAMENTACOLETAID";
         dynAbrangenciaGeograficaId_Internalname = sPrefix+"ABRANGENCIAGEOGRAFICAID";
         dynFrequenciaTratamentoId_Internalname = sPrefix+"FREQUENCIATRATAMENTOID";
         dynTipoDescarteId_Internalname = sPrefix+"TIPODESCARTEID";
         dynTempoRetencaoId_Internalname = sPrefix+"TEMPORETENCAOID";
         radDocumentoPrevColetaDados_Internalname = sPrefix+"DOCUMENTOPREVCOLETADADOS";
         edtDocumentoBaseLegalNorm_Internalname = sPrefix+"DOCUMENTOBASELEGALNORM";
         edtDocumentoBaseLegalNormIntExt_Internalname = sPrefix+"DOCUMENTOBASELEGALNORMINTEXT";
         chkDocumentoDadosGrupoVul_Internalname = sPrefix+"DOCUMENTODADOSGRUPOVUL";
         chkDocumentoDadosCriancaAdolesc_Internalname = sPrefix+"DOCUMENTODADOSCRIANCAADOLESC";
         dynMedidaSegurancaId_Internalname = sPrefix+"MEDIDASEGURANCAID";
         edtDocumentoMedidaSegurancaDesc_Internalname = sPrefix+"DOCUMENTOMEDIDASEGURANCADESC";
         edtDocumentoFluxoTratDadosDesc_Internalname = sPrefix+"DOCUMENTOFLUXOTRATDADOSDESC";
         divTransactiondetail_tabletratamento_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLETRATAMENTO";
         divTransactiondetail_tablecontent_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLECONTENT";
         divTransactiondetail_tablemain_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEMAIN";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtavArearesponsavelid_Internalname = sPrefix+"vAREARESPONSAVELID";
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
         chkDocumentoDadosCriancaAdolesc.Caption = "POSSUI DADOS DE CRIANÇA/ADOLESCENTE";
         chkDocumentoDadosGrupoVul.Caption = "POSSUI DADOS DE GRUPOS VULNERÁVEIS";
         edtavArearesponsavelid_Jsonclick = "";
         edtavArearesponsavelid_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtDocumentoFluxoTratDadosDesc_Enabled = 0;
         edtDocumentoMedidaSegurancaDesc_Enabled = 0;
         dynMedidaSegurancaId_Jsonclick = "";
         dynMedidaSegurancaId.Enabled = 0;
         chkDocumentoDadosCriancaAdolesc.Enabled = 0;
         chkDocumentoDadosGrupoVul.Enabled = 0;
         edtDocumentoBaseLegalNormIntExt_Jsonclick = "";
         edtDocumentoBaseLegalNormIntExt_Enabled = 0;
         edtDocumentoBaseLegalNorm_Jsonclick = "";
         edtDocumentoBaseLegalNorm_Enabled = 0;
         radDocumentoPrevColetaDados_Jsonclick = "";
         dynTempoRetencaoId_Jsonclick = "";
         dynTempoRetencaoId.Enabled = 0;
         dynTipoDescarteId_Jsonclick = "";
         dynTipoDescarteId.Enabled = 0;
         dynFrequenciaTratamentoId_Jsonclick = "";
         dynFrequenciaTratamentoId.Enabled = 0;
         dynAbrangenciaGeograficaId_Jsonclick = "";
         dynAbrangenciaGeograficaId.Enabled = 0;
         dynFerramentaColetaId_Jsonclick = "";
         dynFerramentaColetaId.Enabled = 0;
         dynTipoDadoId_Jsonclick = "";
         dynTipoDadoId.Enabled = 0;
         dynCategoriaId_Jsonclick = "";
         dynCategoriaId.Enabled = 0;
         edtDocumentoFinalidadeTratamento_Jsonclick = "";
         edtDocumentoFinalidadeTratamento_Enabled = 0;
         cmbDocumentoAtivo_Jsonclick = "";
         cmbDocumentoAtivo.Enabled = 0;
         edtDocumentoNome_Jsonclick = "";
         edtDocumentoNome_Enabled = 0;
         dynEncarregadoId_Jsonclick = "";
         dynEncarregadoId.Enabled = 0;
         dynPersonaId_Jsonclick = "";
         dynPersonaId.Enabled = 0;
         edtDocumentoDataAlteracao_Jsonclick = "";
         edtDocumentoDataAlteracao_Enabled = 0;
         edtavArearesponsavelnome_Jsonclick = "";
         edtavArearesponsavelnome_Enabled = 1;
         edtDocumentoDataInclusao_Jsonclick = "";
         edtDocumentoDataInclusao_Enabled = 0;
         dynSubprocessoId_Jsonclick = "";
         dynSubprocessoId.Enabled = 0;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 0;
         dynDocumentoProcessoId_Jsonclick = "";
         dynDocumentoProcessoId.Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public void Valid_Documentoid( )
      {
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         GXASUBPROCESSOID_html642( A75DocumentoId) ;
         dynload_actions( ) ;
         if ( dynSubprocessoId.ItemCount > 0 )
         {
            A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0))), "."));
            n20SubprocessoId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A20SubprocessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ".", "")));
         dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
         AssignProp(sPrefix, false, dynSubprocessoId_Internalname, "Values", dynSubprocessoId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynMedidaSegurancaId'},{av:'A51MedidaSegurancaId',fld:'MEDIDASEGURANCAID',pic:'ZZZZZZZ9'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV17Aba',fld:'vABA',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13642',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV17Aba',fld:'vABA',pic:'',hsh:true}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E14642',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV17Aba',fld:'vABA',pic:'',hsh:true}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV20Pgmname = "";
         scmdbuf = "";
         H00642_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         H00642_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         H00642_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         H00642_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         H00642_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H00642_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H00642_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         H00642_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         H00642_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         H00642_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         H00642_A79DocumentoBaseLegalNorm = new string[] {""} ;
         H00642_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         H00642_A78DocumentoPrevColetaDados = new bool[] {false} ;
         H00642_n78DocumentoPrevColetaDados = new bool[] {false} ;
         H00642_A48TempoRetencaoId = new int[1] ;
         H00642_n48TempoRetencaoId = new bool[] {false} ;
         H00642_A45TipoDescarteId = new int[1] ;
         H00642_n45TipoDescarteId = new bool[] {false} ;
         H00642_A39FrequenciaTratamentoId = new int[1] ;
         H00642_n39FrequenciaTratamentoId = new bool[] {false} ;
         H00642_A36AbrangenciaGeograficaId = new int[1] ;
         H00642_n36AbrangenciaGeograficaId = new bool[] {false} ;
         H00642_A33FerramentaColetaId = new int[1] ;
         H00642_n33FerramentaColetaId = new bool[] {false} ;
         H00642_A30TipoDadoId = new int[1] ;
         H00642_n30TipoDadoId = new bool[] {false} ;
         H00642_A27CategoriaId = new int[1] ;
         H00642_n27CategoriaId = new bool[] {false} ;
         H00642_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         H00642_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         H00642_A85DocumentoAtivo = new bool[] {false} ;
         H00642_n85DocumentoAtivo = new bool[] {false} ;
         H00642_A76DocumentoNome = new string[] {""} ;
         H00642_n76DocumentoNome = new bool[] {false} ;
         H00642_A7EncarregadoId = new int[1] ;
         H00642_n7EncarregadoId = new bool[] {false} ;
         H00642_A13PersonaId = new int[1] ;
         H00642_n13PersonaId = new bool[] {false} ;
         H00642_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H00642_n109DocumentoDataAlteracao = new bool[] {false} ;
         H00642_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H00642_n108DocumentoDataInclusao = new bool[] {false} ;
         H00642_A20SubprocessoId = new int[1] ;
         H00642_n20SubprocessoId = new bool[] {false} ;
         H00642_A106DocumentoProcessoId = new int[1] ;
         H00642_n106DocumentoProcessoId = new bool[] {false} ;
         A84DocumentoFluxoTratDadosDesc = "";
         A83DocumentoMedidaSegurancaDesc = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A79DocumentoBaseLegalNorm = "";
         A77DocumentoFinalidadeTratamento = "";
         A76DocumentoNome = "";
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17Aba = "";
         GX_FocusControl = "";
         TempTags = "";
         AV15AreaResponsavelNome = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00643_A106DocumentoProcessoId = new int[1] ;
         H00643_n106DocumentoProcessoId = new bool[] {false} ;
         H00643_A107DocumentoProcessoNome = new string[] {""} ;
         H00643_A19ProcessoAtivo = new bool[] {false} ;
         H00643_n19ProcessoAtivo = new bool[] {false} ;
         H00644_A75DocumentoId = new int[1] ;
         H00644_A20SubprocessoId = new int[1] ;
         H00644_n20SubprocessoId = new bool[] {false} ;
         H00644_A21SubprocessoNome = new string[] {""} ;
         H00644_A23SubprocessoAtivo = new bool[] {false} ;
         H00644_A16ProcessoId = new int[1] ;
         H00644_n16ProcessoId = new bool[] {false} ;
         H00644_A106DocumentoProcessoId = new int[1] ;
         H00644_n106DocumentoProcessoId = new bool[] {false} ;
         H00645_A13PersonaId = new int[1] ;
         H00645_n13PersonaId = new bool[] {false} ;
         H00645_A14PersonaNome = new string[] {""} ;
         H00645_A15PersonaAtivo = new bool[] {false} ;
         H00646_A7EncarregadoId = new int[1] ;
         H00646_n7EncarregadoId = new bool[] {false} ;
         H00646_A8EncarregadoNome = new string[] {""} ;
         H00646_A9EncarregadoAtivo = new bool[] {false} ;
         H00647_A10ControladorId = new int[1] ;
         H00647_A11ControladorNome = new string[] {""} ;
         H00647_A12ControladorAtivo = new bool[] {false} ;
         H00648_A30TipoDadoId = new int[1] ;
         H00648_n30TipoDadoId = new bool[] {false} ;
         H00648_A31TipoDadoNome = new string[] {""} ;
         H00648_A32TipoDadoAtivo = new bool[] {false} ;
         H00649_A33FerramentaColetaId = new int[1] ;
         H00649_n33FerramentaColetaId = new bool[] {false} ;
         H00649_A34FerramentaColetaNome = new string[] {""} ;
         H00649_A35FerramentaColetaAtivo = new bool[] {false} ;
         H006410_A36AbrangenciaGeograficaId = new int[1] ;
         H006410_n36AbrangenciaGeograficaId = new bool[] {false} ;
         H006410_A37AbrangenciaGeograficaNome = new string[] {""} ;
         H006410_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         H006411_A39FrequenciaTratamentoId = new int[1] ;
         H006411_n39FrequenciaTratamentoId = new bool[] {false} ;
         H006411_A40FrequenciaTratamentoNome = new string[] {""} ;
         H006411_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         H006412_A45TipoDescarteId = new int[1] ;
         H006412_n45TipoDescarteId = new bool[] {false} ;
         H006412_A46TipoDescarteNome = new string[] {""} ;
         H006412_A47TipoDescarteAtivo = new bool[] {false} ;
         H006413_A48TempoRetencaoId = new int[1] ;
         H006413_n48TempoRetencaoId = new bool[] {false} ;
         H006413_A49TempoRetencaoNome = new string[] {""} ;
         H006413_A50TempoRetencaoAtivo = new bool[] {false} ;
         H006414_A51MedidaSegurancaId = new int[1] ;
         H006414_A52MedidaSegurancaNome = new string[] {""} ;
         H006414_A53MedidaSegurancaAtivo = new bool[] {false} ;
         H006415_A75DocumentoId = new int[1] ;
         H006415_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         H006415_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         H006415_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         H006415_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         H006415_A51MedidaSegurancaId = new int[1] ;
         H006415_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H006415_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H006415_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         H006415_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         H006415_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         H006415_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         H006415_A79DocumentoBaseLegalNorm = new string[] {""} ;
         H006415_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         H006415_A78DocumentoPrevColetaDados = new bool[] {false} ;
         H006415_n78DocumentoPrevColetaDados = new bool[] {false} ;
         H006415_A48TempoRetencaoId = new int[1] ;
         H006415_n48TempoRetencaoId = new bool[] {false} ;
         H006415_A45TipoDescarteId = new int[1] ;
         H006415_n45TipoDescarteId = new bool[] {false} ;
         H006415_A39FrequenciaTratamentoId = new int[1] ;
         H006415_n39FrequenciaTratamentoId = new bool[] {false} ;
         H006415_A36AbrangenciaGeograficaId = new int[1] ;
         H006415_n36AbrangenciaGeograficaId = new bool[] {false} ;
         H006415_A33FerramentaColetaId = new int[1] ;
         H006415_n33FerramentaColetaId = new bool[] {false} ;
         H006415_A30TipoDadoId = new int[1] ;
         H006415_n30TipoDadoId = new bool[] {false} ;
         H006415_A27CategoriaId = new int[1] ;
         H006415_n27CategoriaId = new bool[] {false} ;
         H006415_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         H006415_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         H006415_A85DocumentoAtivo = new bool[] {false} ;
         H006415_n85DocumentoAtivo = new bool[] {false} ;
         H006415_A76DocumentoNome = new string[] {""} ;
         H006415_n76DocumentoNome = new bool[] {false} ;
         H006415_A7EncarregadoId = new int[1] ;
         H006415_n7EncarregadoId = new bool[] {false} ;
         H006415_A13PersonaId = new int[1] ;
         H006415_n13PersonaId = new bool[] {false} ;
         H006415_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H006415_n109DocumentoDataAlteracao = new bool[] {false} ;
         H006415_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H006415_n108DocumentoDataInclusao = new bool[] {false} ;
         H006415_A20SubprocessoId = new int[1] ;
         H006415_n20SubprocessoId = new bool[] {false} ;
         H006415_A106DocumentoProcessoId = new int[1] ;
         H006415_n106DocumentoProcessoId = new bool[] {false} ;
         H006416_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         H006416_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         H006416_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         H006416_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         H006416_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H006416_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H006416_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         H006416_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         H006416_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         H006416_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         H006416_A79DocumentoBaseLegalNorm = new string[] {""} ;
         H006416_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         H006416_A78DocumentoPrevColetaDados = new bool[] {false} ;
         H006416_n78DocumentoPrevColetaDados = new bool[] {false} ;
         H006416_A48TempoRetencaoId = new int[1] ;
         H006416_n48TempoRetencaoId = new bool[] {false} ;
         H006416_A45TipoDescarteId = new int[1] ;
         H006416_n45TipoDescarteId = new bool[] {false} ;
         H006416_A39FrequenciaTratamentoId = new int[1] ;
         H006416_n39FrequenciaTratamentoId = new bool[] {false} ;
         H006416_A36AbrangenciaGeograficaId = new int[1] ;
         H006416_n36AbrangenciaGeograficaId = new bool[] {false} ;
         H006416_A33FerramentaColetaId = new int[1] ;
         H006416_n33FerramentaColetaId = new bool[] {false} ;
         H006416_A30TipoDadoId = new int[1] ;
         H006416_n30TipoDadoId = new bool[] {false} ;
         H006416_A27CategoriaId = new int[1] ;
         H006416_n27CategoriaId = new bool[] {false} ;
         H006416_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         H006416_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         H006416_A85DocumentoAtivo = new bool[] {false} ;
         H006416_n85DocumentoAtivo = new bool[] {false} ;
         H006416_A76DocumentoNome = new string[] {""} ;
         H006416_n76DocumentoNome = new bool[] {false} ;
         H006416_A7EncarregadoId = new int[1] ;
         H006416_n7EncarregadoId = new bool[] {false} ;
         H006416_A13PersonaId = new int[1] ;
         H006416_n13PersonaId = new bool[] {false} ;
         H006416_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H006416_n109DocumentoDataAlteracao = new bool[] {false} ;
         H006416_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H006416_n108DocumentoDataInclusao = new bool[] {false} ;
         H006416_A20SubprocessoId = new int[1] ;
         H006416_n20SubprocessoId = new bool[] {false} ;
         H006416_A106DocumentoProcessoId = new int[1] ;
         H006416_n106DocumentoProcessoId = new bool[] {false} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA75DocumentoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentogeneral__default(),
            new Object[][] {
                new Object[] {
               H00642_A84DocumentoFluxoTratDadosDesc, H00642_n84DocumentoFluxoTratDadosDesc, H00642_A83DocumentoMedidaSegurancaDesc, H00642_n83DocumentoMedidaSegurancaDesc, H00642_A81DocumentoDadosCriancaAdolesc, H00642_n81DocumentoDadosCriancaAdolesc, H00642_A82DocumentoDadosGrupoVul, H00642_n82DocumentoDadosGrupoVul, H00642_A80DocumentoBaseLegalNormIntExt, H00642_n80DocumentoBaseLegalNormIntExt,
               H00642_A79DocumentoBaseLegalNorm, H00642_n79DocumentoBaseLegalNorm, H00642_A78DocumentoPrevColetaDados, H00642_n78DocumentoPrevColetaDados, H00642_A48TempoRetencaoId, H00642_n48TempoRetencaoId, H00642_A45TipoDescarteId, H00642_n45TipoDescarteId, H00642_A39FrequenciaTratamentoId, H00642_n39FrequenciaTratamentoId,
               H00642_A36AbrangenciaGeograficaId, H00642_n36AbrangenciaGeograficaId, H00642_A33FerramentaColetaId, H00642_n33FerramentaColetaId, H00642_A30TipoDadoId, H00642_n30TipoDadoId, H00642_A27CategoriaId, H00642_n27CategoriaId, H00642_A77DocumentoFinalidadeTratamento, H00642_n77DocumentoFinalidadeTratamento,
               H00642_A85DocumentoAtivo, H00642_n85DocumentoAtivo, H00642_A76DocumentoNome, H00642_n76DocumentoNome, H00642_A7EncarregadoId, H00642_n7EncarregadoId, H00642_A13PersonaId, H00642_n13PersonaId, H00642_A109DocumentoDataAlteracao, H00642_n109DocumentoDataAlteracao,
               H00642_A108DocumentoDataInclusao, H00642_n108DocumentoDataInclusao, H00642_A20SubprocessoId, H00642_n20SubprocessoId, H00642_A106DocumentoProcessoId, H00642_n106DocumentoProcessoId
               }
               , new Object[] {
               H00643_A106DocumentoProcessoId, H00643_A107DocumentoProcessoNome, H00643_A19ProcessoAtivo, H00643_n19ProcessoAtivo
               }
               , new Object[] {
               H00644_A75DocumentoId, H00644_A20SubprocessoId, H00644_n20SubprocessoId, H00644_A21SubprocessoNome, H00644_A23SubprocessoAtivo, H00644_A16ProcessoId, H00644_n16ProcessoId, H00644_A106DocumentoProcessoId, H00644_n106DocumentoProcessoId
               }
               , new Object[] {
               H00645_A13PersonaId, H00645_A14PersonaNome, H00645_A15PersonaAtivo
               }
               , new Object[] {
               H00646_A7EncarregadoId, H00646_A8EncarregadoNome, H00646_A9EncarregadoAtivo
               }
               , new Object[] {
               H00647_A10ControladorId, H00647_A11ControladorNome, H00647_A12ControladorAtivo
               }
               , new Object[] {
               H00648_A30TipoDadoId, H00648_A31TipoDadoNome, H00648_A32TipoDadoAtivo
               }
               , new Object[] {
               H00649_A33FerramentaColetaId, H00649_A34FerramentaColetaNome, H00649_A35FerramentaColetaAtivo
               }
               , new Object[] {
               H006410_A36AbrangenciaGeograficaId, H006410_A37AbrangenciaGeograficaNome, H006410_A38AbrangenciaGeograficaAtivo
               }
               , new Object[] {
               H006411_A39FrequenciaTratamentoId, H006411_A40FrequenciaTratamentoNome, H006411_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               H006412_A45TipoDescarteId, H006412_A46TipoDescarteNome, H006412_A47TipoDescarteAtivo
               }
               , new Object[] {
               H006413_A48TempoRetencaoId, H006413_A49TempoRetencaoNome, H006413_A50TempoRetencaoAtivo
               }
               , new Object[] {
               H006414_A51MedidaSegurancaId, H006414_A52MedidaSegurancaNome, H006414_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               H006415_A75DocumentoId, H006415_A84DocumentoFluxoTratDadosDesc, H006415_n84DocumentoFluxoTratDadosDesc, H006415_A83DocumentoMedidaSegurancaDesc, H006415_n83DocumentoMedidaSegurancaDesc, H006415_A51MedidaSegurancaId, H006415_A81DocumentoDadosCriancaAdolesc, H006415_n81DocumentoDadosCriancaAdolesc, H006415_A82DocumentoDadosGrupoVul, H006415_n82DocumentoDadosGrupoVul,
               H006415_A80DocumentoBaseLegalNormIntExt, H006415_n80DocumentoBaseLegalNormIntExt, H006415_A79DocumentoBaseLegalNorm, H006415_n79DocumentoBaseLegalNorm, H006415_A78DocumentoPrevColetaDados, H006415_n78DocumentoPrevColetaDados, H006415_A48TempoRetencaoId, H006415_n48TempoRetencaoId, H006415_A45TipoDescarteId, H006415_n45TipoDescarteId,
               H006415_A39FrequenciaTratamentoId, H006415_n39FrequenciaTratamentoId, H006415_A36AbrangenciaGeograficaId, H006415_n36AbrangenciaGeograficaId, H006415_A33FerramentaColetaId, H006415_n33FerramentaColetaId, H006415_A30TipoDadoId, H006415_n30TipoDadoId, H006415_A27CategoriaId, H006415_n27CategoriaId,
               H006415_A77DocumentoFinalidadeTratamento, H006415_n77DocumentoFinalidadeTratamento, H006415_A85DocumentoAtivo, H006415_n85DocumentoAtivo, H006415_A76DocumentoNome, H006415_n76DocumentoNome, H006415_A7EncarregadoId, H006415_n7EncarregadoId, H006415_A13PersonaId, H006415_n13PersonaId,
               H006415_A109DocumentoDataAlteracao, H006415_n109DocumentoDataAlteracao, H006415_A108DocumentoDataInclusao, H006415_n108DocumentoDataInclusao, H006415_A20SubprocessoId, H006415_n20SubprocessoId, H006415_A106DocumentoProcessoId, H006415_n106DocumentoProcessoId
               }
               , new Object[] {
               H006416_A84DocumentoFluxoTratDadosDesc, H006416_n84DocumentoFluxoTratDadosDesc, H006416_A83DocumentoMedidaSegurancaDesc, H006416_n83DocumentoMedidaSegurancaDesc, H006416_A81DocumentoDadosCriancaAdolesc, H006416_n81DocumentoDadosCriancaAdolesc, H006416_A82DocumentoDadosGrupoVul, H006416_n82DocumentoDadosGrupoVul, H006416_A80DocumentoBaseLegalNormIntExt, H006416_n80DocumentoBaseLegalNormIntExt,
               H006416_A79DocumentoBaseLegalNorm, H006416_n79DocumentoBaseLegalNorm, H006416_A78DocumentoPrevColetaDados, H006416_n78DocumentoPrevColetaDados, H006416_A48TempoRetencaoId, H006416_n48TempoRetencaoId, H006416_A45TipoDescarteId, H006416_n45TipoDescarteId, H006416_A39FrequenciaTratamentoId, H006416_n39FrequenciaTratamentoId,
               H006416_A36AbrangenciaGeograficaId, H006416_n36AbrangenciaGeograficaId, H006416_A33FerramentaColetaId, H006416_n33FerramentaColetaId, H006416_A30TipoDadoId, H006416_n30TipoDadoId, H006416_A27CategoriaId, H006416_n27CategoriaId, H006416_A77DocumentoFinalidadeTratamento, H006416_n77DocumentoFinalidadeTratamento,
               H006416_A85DocumentoAtivo, H006416_n85DocumentoAtivo, H006416_A76DocumentoNome, H006416_n76DocumentoNome, H006416_A7EncarregadoId, H006416_n7EncarregadoId, H006416_A13PersonaId, H006416_n13PersonaId, H006416_A109DocumentoDataAlteracao, H006416_n109DocumentoDataAlteracao,
               H006416_A108DocumentoDataInclusao, H006416_n108DocumentoDataInclusao, H006416_A20SubprocessoId, H006416_n20SubprocessoId, H006416_A106DocumentoProcessoId, H006416_n106DocumentoProcessoId
               }
            }
         );
         AV20Pgmname = "DocumentoGeneral";
         /* GeneXus formulas. */
         AV20Pgmname = "DocumentoGeneral";
         context.Gx_err = 0;
         edtavArearesponsavelnome_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int A75DocumentoId ;
      private int wcpOA75DocumentoId ;
      private int edtavArearesponsavelnome_Enabled ;
      private int A48TempoRetencaoId ;
      private int A45TipoDescarteId ;
      private int A39FrequenciaTratamentoId ;
      private int A36AbrangenciaGeograficaId ;
      private int A33FerramentaColetaId ;
      private int A30TipoDadoId ;
      private int A27CategoriaId ;
      private int A7EncarregadoId ;
      private int A13PersonaId ;
      private int A20SubprocessoId ;
      private int A106DocumentoProcessoId ;
      private int edtDocumentoId_Enabled ;
      private int edtDocumentoDataInclusao_Enabled ;
      private int edtDocumentoDataAlteracao_Enabled ;
      private int edtDocumentoNome_Enabled ;
      private int edtDocumentoFinalidadeTratamento_Enabled ;
      private int edtDocumentoBaseLegalNorm_Enabled ;
      private int edtDocumentoBaseLegalNormIntExt_Enabled ;
      private int A51MedidaSegurancaId ;
      private int edtDocumentoMedidaSegurancaDesc_Enabled ;
      private int edtDocumentoFluxoTratDadosDesc_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int AV16AreaResponsavelId ;
      private int edtavArearesponsavelid_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private int Z20SubprocessoId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV20Pgmname ;
      private string edtavArearesponsavelnome_Internalname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tablemain_Internalname ;
      private string divTransactiondetail_tablecontent_Internalname ;
      private string divTransactiondetail_tabledocumento_Internalname ;
      private string dynDocumentoProcessoId_Internalname ;
      private string dynDocumentoProcessoId_Jsonclick ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoId_Jsonclick ;
      private string dynSubprocessoId_Internalname ;
      private string dynSubprocessoId_Jsonclick ;
      private string edtDocumentoDataInclusao_Internalname ;
      private string edtDocumentoDataInclusao_Jsonclick ;
      private string TempTags ;
      private string edtavArearesponsavelnome_Jsonclick ;
      private string edtDocumentoDataAlteracao_Internalname ;
      private string edtDocumentoDataAlteracao_Jsonclick ;
      private string dynPersonaId_Internalname ;
      private string dynPersonaId_Jsonclick ;
      private string dynEncarregadoId_Internalname ;
      private string dynEncarregadoId_Jsonclick ;
      private string edtDocumentoNome_Internalname ;
      private string edtDocumentoNome_Jsonclick ;
      private string cmbDocumentoAtivo_Internalname ;
      private string cmbDocumentoAtivo_Jsonclick ;
      private string divTransactiondetail_tabletratamento_Internalname ;
      private string edtDocumentoFinalidadeTratamento_Internalname ;
      private string edtDocumentoFinalidadeTratamento_Jsonclick ;
      private string dynCategoriaId_Internalname ;
      private string dynCategoriaId_Jsonclick ;
      private string dynTipoDadoId_Internalname ;
      private string dynTipoDadoId_Jsonclick ;
      private string dynFerramentaColetaId_Internalname ;
      private string dynFerramentaColetaId_Jsonclick ;
      private string dynAbrangenciaGeograficaId_Internalname ;
      private string dynAbrangenciaGeograficaId_Jsonclick ;
      private string dynFrequenciaTratamentoId_Internalname ;
      private string dynFrequenciaTratamentoId_Jsonclick ;
      private string dynTipoDescarteId_Internalname ;
      private string dynTipoDescarteId_Jsonclick ;
      private string dynTempoRetencaoId_Internalname ;
      private string dynTempoRetencaoId_Jsonclick ;
      private string radDocumentoPrevColetaDados_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string radDocumentoPrevColetaDados_Jsonclick ;
      private string edtDocumentoBaseLegalNorm_Internalname ;
      private string edtDocumentoBaseLegalNorm_Jsonclick ;
      private string edtDocumentoBaseLegalNormIntExt_Internalname ;
      private string edtDocumentoBaseLegalNormIntExt_Jsonclick ;
      private string chkDocumentoDadosGrupoVul_Internalname ;
      private string chkDocumentoDadosCriancaAdolesc_Internalname ;
      private string dynMedidaSegurancaId_Internalname ;
      private string dynMedidaSegurancaId_Jsonclick ;
      private string edtDocumentoMedidaSegurancaDesc_Internalname ;
      private string edtDocumentoFluxoTratDadosDesc_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavArearesponsavelid_Internalname ;
      private string edtavArearesponsavelid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string sCtrlA75DocumentoId ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime A108DocumentoDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool n48TempoRetencaoId ;
      private bool n45TipoDescarteId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n33FerramentaColetaId ;
      private bool n30TipoDadoId ;
      private bool n27CategoriaId ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool A85DocumentoAtivo ;
      private bool n85DocumentoAtivo ;
      private bool n76DocumentoNome ;
      private bool n7EncarregadoId ;
      private bool n13PersonaId ;
      private bool n109DocumentoDataAlteracao ;
      private bool n108DocumentoDataInclusao ;
      private bool n20SubprocessoId ;
      private bool n106DocumentoProcessoId ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A79DocumentoBaseLegalNorm ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A76DocumentoNome ;
      private string AV17Aba ;
      private string AV15AreaResponsavelNome ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynDocumentoProcessoId ;
      private GXCombobox dynSubprocessoId ;
      private GXCombobox dynPersonaId ;
      private GXCombobox dynEncarregadoId ;
      private GXCombobox cmbDocumentoAtivo ;
      private GXCombobox dynCategoriaId ;
      private GXCombobox dynTipoDadoId ;
      private GXCombobox dynFerramentaColetaId ;
      private GXCombobox dynAbrangenciaGeograficaId ;
      private GXCombobox dynFrequenciaTratamentoId ;
      private GXCombobox dynTipoDescarteId ;
      private GXCombobox dynTempoRetencaoId ;
      private GXRadio radDocumentoPrevColetaDados ;
      private GXCheckbox chkDocumentoDadosGrupoVul ;
      private GXCheckbox chkDocumentoDadosCriancaAdolesc ;
      private GXCombobox dynMedidaSegurancaId ;
      private IDataStoreProvider pr_default ;
      private string[] H00642_A84DocumentoFluxoTratDadosDesc ;
      private bool[] H00642_n84DocumentoFluxoTratDadosDesc ;
      private string[] H00642_A83DocumentoMedidaSegurancaDesc ;
      private bool[] H00642_n83DocumentoMedidaSegurancaDesc ;
      private bool[] H00642_A81DocumentoDadosCriancaAdolesc ;
      private bool[] H00642_n81DocumentoDadosCriancaAdolesc ;
      private bool[] H00642_A82DocumentoDadosGrupoVul ;
      private bool[] H00642_n82DocumentoDadosGrupoVul ;
      private string[] H00642_A80DocumentoBaseLegalNormIntExt ;
      private bool[] H00642_n80DocumentoBaseLegalNormIntExt ;
      private string[] H00642_A79DocumentoBaseLegalNorm ;
      private bool[] H00642_n79DocumentoBaseLegalNorm ;
      private bool[] H00642_A78DocumentoPrevColetaDados ;
      private bool[] H00642_n78DocumentoPrevColetaDados ;
      private int[] H00642_A48TempoRetencaoId ;
      private bool[] H00642_n48TempoRetencaoId ;
      private int[] H00642_A45TipoDescarteId ;
      private bool[] H00642_n45TipoDescarteId ;
      private int[] H00642_A39FrequenciaTratamentoId ;
      private bool[] H00642_n39FrequenciaTratamentoId ;
      private int[] H00642_A36AbrangenciaGeograficaId ;
      private bool[] H00642_n36AbrangenciaGeograficaId ;
      private int[] H00642_A33FerramentaColetaId ;
      private bool[] H00642_n33FerramentaColetaId ;
      private int[] H00642_A30TipoDadoId ;
      private bool[] H00642_n30TipoDadoId ;
      private int[] H00642_A27CategoriaId ;
      private bool[] H00642_n27CategoriaId ;
      private string[] H00642_A77DocumentoFinalidadeTratamento ;
      private bool[] H00642_n77DocumentoFinalidadeTratamento ;
      private bool[] H00642_A85DocumentoAtivo ;
      private bool[] H00642_n85DocumentoAtivo ;
      private string[] H00642_A76DocumentoNome ;
      private bool[] H00642_n76DocumentoNome ;
      private int[] H00642_A7EncarregadoId ;
      private bool[] H00642_n7EncarregadoId ;
      private int[] H00642_A13PersonaId ;
      private bool[] H00642_n13PersonaId ;
      private DateTime[] H00642_A109DocumentoDataAlteracao ;
      private bool[] H00642_n109DocumentoDataAlteracao ;
      private DateTime[] H00642_A108DocumentoDataInclusao ;
      private bool[] H00642_n108DocumentoDataInclusao ;
      private int[] H00642_A20SubprocessoId ;
      private bool[] H00642_n20SubprocessoId ;
      private int[] H00642_A106DocumentoProcessoId ;
      private bool[] H00642_n106DocumentoProcessoId ;
      private int[] H00643_A106DocumentoProcessoId ;
      private bool[] H00643_n106DocumentoProcessoId ;
      private string[] H00643_A107DocumentoProcessoNome ;
      private bool[] H00643_A19ProcessoAtivo ;
      private bool[] H00643_n19ProcessoAtivo ;
      private int[] H00644_A75DocumentoId ;
      private int[] H00644_A20SubprocessoId ;
      private bool[] H00644_n20SubprocessoId ;
      private string[] H00644_A21SubprocessoNome ;
      private bool[] H00644_A23SubprocessoAtivo ;
      private int[] H00644_A16ProcessoId ;
      private bool[] H00644_n16ProcessoId ;
      private int[] H00644_A106DocumentoProcessoId ;
      private bool[] H00644_n106DocumentoProcessoId ;
      private int[] H00645_A13PersonaId ;
      private bool[] H00645_n13PersonaId ;
      private string[] H00645_A14PersonaNome ;
      private bool[] H00645_A15PersonaAtivo ;
      private int[] H00646_A7EncarregadoId ;
      private bool[] H00646_n7EncarregadoId ;
      private string[] H00646_A8EncarregadoNome ;
      private bool[] H00646_A9EncarregadoAtivo ;
      private int[] H00647_A10ControladorId ;
      private string[] H00647_A11ControladorNome ;
      private bool[] H00647_A12ControladorAtivo ;
      private int[] H00648_A30TipoDadoId ;
      private bool[] H00648_n30TipoDadoId ;
      private string[] H00648_A31TipoDadoNome ;
      private bool[] H00648_A32TipoDadoAtivo ;
      private int[] H00649_A33FerramentaColetaId ;
      private bool[] H00649_n33FerramentaColetaId ;
      private string[] H00649_A34FerramentaColetaNome ;
      private bool[] H00649_A35FerramentaColetaAtivo ;
      private int[] H006410_A36AbrangenciaGeograficaId ;
      private bool[] H006410_n36AbrangenciaGeograficaId ;
      private string[] H006410_A37AbrangenciaGeograficaNome ;
      private bool[] H006410_A38AbrangenciaGeograficaAtivo ;
      private int[] H006411_A39FrequenciaTratamentoId ;
      private bool[] H006411_n39FrequenciaTratamentoId ;
      private string[] H006411_A40FrequenciaTratamentoNome ;
      private bool[] H006411_A41FrequenciaTratamentoAtivo ;
      private int[] H006412_A45TipoDescarteId ;
      private bool[] H006412_n45TipoDescarteId ;
      private string[] H006412_A46TipoDescarteNome ;
      private bool[] H006412_A47TipoDescarteAtivo ;
      private int[] H006413_A48TempoRetencaoId ;
      private bool[] H006413_n48TempoRetencaoId ;
      private string[] H006413_A49TempoRetencaoNome ;
      private bool[] H006413_A50TempoRetencaoAtivo ;
      private int[] H006414_A51MedidaSegurancaId ;
      private string[] H006414_A52MedidaSegurancaNome ;
      private bool[] H006414_A53MedidaSegurancaAtivo ;
      private int[] H006415_A75DocumentoId ;
      private string[] H006415_A84DocumentoFluxoTratDadosDesc ;
      private bool[] H006415_n84DocumentoFluxoTratDadosDesc ;
      private string[] H006415_A83DocumentoMedidaSegurancaDesc ;
      private bool[] H006415_n83DocumentoMedidaSegurancaDesc ;
      private int[] H006415_A51MedidaSegurancaId ;
      private bool[] H006415_A81DocumentoDadosCriancaAdolesc ;
      private bool[] H006415_n81DocumentoDadosCriancaAdolesc ;
      private bool[] H006415_A82DocumentoDadosGrupoVul ;
      private bool[] H006415_n82DocumentoDadosGrupoVul ;
      private string[] H006415_A80DocumentoBaseLegalNormIntExt ;
      private bool[] H006415_n80DocumentoBaseLegalNormIntExt ;
      private string[] H006415_A79DocumentoBaseLegalNorm ;
      private bool[] H006415_n79DocumentoBaseLegalNorm ;
      private bool[] H006415_A78DocumentoPrevColetaDados ;
      private bool[] H006415_n78DocumentoPrevColetaDados ;
      private int[] H006415_A48TempoRetencaoId ;
      private bool[] H006415_n48TempoRetencaoId ;
      private int[] H006415_A45TipoDescarteId ;
      private bool[] H006415_n45TipoDescarteId ;
      private int[] H006415_A39FrequenciaTratamentoId ;
      private bool[] H006415_n39FrequenciaTratamentoId ;
      private int[] H006415_A36AbrangenciaGeograficaId ;
      private bool[] H006415_n36AbrangenciaGeograficaId ;
      private int[] H006415_A33FerramentaColetaId ;
      private bool[] H006415_n33FerramentaColetaId ;
      private int[] H006415_A30TipoDadoId ;
      private bool[] H006415_n30TipoDadoId ;
      private int[] H006415_A27CategoriaId ;
      private bool[] H006415_n27CategoriaId ;
      private string[] H006415_A77DocumentoFinalidadeTratamento ;
      private bool[] H006415_n77DocumentoFinalidadeTratamento ;
      private bool[] H006415_A85DocumentoAtivo ;
      private bool[] H006415_n85DocumentoAtivo ;
      private string[] H006415_A76DocumentoNome ;
      private bool[] H006415_n76DocumentoNome ;
      private int[] H006415_A7EncarregadoId ;
      private bool[] H006415_n7EncarregadoId ;
      private int[] H006415_A13PersonaId ;
      private bool[] H006415_n13PersonaId ;
      private DateTime[] H006415_A109DocumentoDataAlteracao ;
      private bool[] H006415_n109DocumentoDataAlteracao ;
      private DateTime[] H006415_A108DocumentoDataInclusao ;
      private bool[] H006415_n108DocumentoDataInclusao ;
      private int[] H006415_A20SubprocessoId ;
      private bool[] H006415_n20SubprocessoId ;
      private int[] H006415_A106DocumentoProcessoId ;
      private bool[] H006415_n106DocumentoProcessoId ;
      private string[] H006416_A84DocumentoFluxoTratDadosDesc ;
      private bool[] H006416_n84DocumentoFluxoTratDadosDesc ;
      private string[] H006416_A83DocumentoMedidaSegurancaDesc ;
      private bool[] H006416_n83DocumentoMedidaSegurancaDesc ;
      private bool[] H006416_A81DocumentoDadosCriancaAdolesc ;
      private bool[] H006416_n81DocumentoDadosCriancaAdolesc ;
      private bool[] H006416_A82DocumentoDadosGrupoVul ;
      private bool[] H006416_n82DocumentoDadosGrupoVul ;
      private string[] H006416_A80DocumentoBaseLegalNormIntExt ;
      private bool[] H006416_n80DocumentoBaseLegalNormIntExt ;
      private string[] H006416_A79DocumentoBaseLegalNorm ;
      private bool[] H006416_n79DocumentoBaseLegalNorm ;
      private bool[] H006416_A78DocumentoPrevColetaDados ;
      private bool[] H006416_n78DocumentoPrevColetaDados ;
      private int[] H006416_A48TempoRetencaoId ;
      private bool[] H006416_n48TempoRetencaoId ;
      private int[] H006416_A45TipoDescarteId ;
      private bool[] H006416_n45TipoDescarteId ;
      private int[] H006416_A39FrequenciaTratamentoId ;
      private bool[] H006416_n39FrequenciaTratamentoId ;
      private int[] H006416_A36AbrangenciaGeograficaId ;
      private bool[] H006416_n36AbrangenciaGeograficaId ;
      private int[] H006416_A33FerramentaColetaId ;
      private bool[] H006416_n33FerramentaColetaId ;
      private int[] H006416_A30TipoDadoId ;
      private bool[] H006416_n30TipoDadoId ;
      private int[] H006416_A27CategoriaId ;
      private bool[] H006416_n27CategoriaId ;
      private string[] H006416_A77DocumentoFinalidadeTratamento ;
      private bool[] H006416_n77DocumentoFinalidadeTratamento ;
      private bool[] H006416_A85DocumentoAtivo ;
      private bool[] H006416_n85DocumentoAtivo ;
      private string[] H006416_A76DocumentoNome ;
      private bool[] H006416_n76DocumentoNome ;
      private int[] H006416_A7EncarregadoId ;
      private bool[] H006416_n7EncarregadoId ;
      private int[] H006416_A13PersonaId ;
      private bool[] H006416_n13PersonaId ;
      private DateTime[] H006416_A109DocumentoDataAlteracao ;
      private bool[] H006416_n109DocumentoDataAlteracao ;
      private DateTime[] H006416_A108DocumentoDataInclusao ;
      private bool[] H006416_n108DocumentoDataInclusao ;
      private int[] H006416_A20SubprocessoId ;
      private bool[] H006416_n20SubprocessoId ;
      private int[] H006416_A106DocumentoProcessoId ;
      private bool[] H006416_n106DocumentoProcessoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class documentogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00642;
          prmH00642 = new Object[] {
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmH00643;
          prmH00643 = new Object[] {
          };
          Object[] prmH00644;
          prmH00644 = new Object[] {
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmH00645;
          prmH00645 = new Object[] {
          };
          Object[] prmH00646;
          prmH00646 = new Object[] {
          };
          Object[] prmH00647;
          prmH00647 = new Object[] {
          };
          Object[] prmH00648;
          prmH00648 = new Object[] {
          };
          Object[] prmH00649;
          prmH00649 = new Object[] {
          };
          Object[] prmH006410;
          prmH006410 = new Object[] {
          };
          Object[] prmH006411;
          prmH006411 = new Object[] {
          };
          Object[] prmH006412;
          prmH006412 = new Object[] {
          };
          Object[] prmH006413;
          prmH006413 = new Object[] {
          };
          Object[] prmH006414;
          prmH006414 = new Object[] {
          };
          Object[] prmH006415;
          prmH006415 = new Object[] {
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmH006416;
          prmH006416 = new Object[] {
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00642", "SELECT [DocumentoFluxoTratDadosDesc], [DocumentoMedidaSegurancaDesc], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoBaseLegalNormIntExt], [DocumentoBaseLegalNorm], [DocumentoPrevColetaDados], [TempoRetencaoId], [TipoDescarteId], [FrequenciaTratamentoId], [AbrangenciaGeograficaId], [FerramentaColetaId], [TipoDadoId], [CategoriaId], [DocumentoFinalidadeTratamento], [DocumentoAtivo], [DocumentoNome], [EncarregadoId], [PersonaId], [DocumentoDataAlteracao], [DocumentoDataInclusao], [SubprocessoId], [DocumentoProcessoId] AS DocumentoProcessoId FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00642,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00643", "SELECT [ProcessoId] AS DocumentoProcessoId, [ProcessoNome] AS DocumentoProcessoNome, [ProcessoAtivo] FROM [Processo] WHERE [ProcessoAtivo] = 1 ORDER BY [ProcessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00643,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00644", "SELECT T1.[DocumentoId], T1.[SubprocessoId], T2.[SubprocessoNome], T2.[SubprocessoAtivo], T2.[ProcessoId], T1.[DocumentoProcessoId] AS DocumentoProcessoId FROM ([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) WHERE (T1.[DocumentoId] = @DocumentoId) AND (T2.[ProcessoId] = T1.[DocumentoProcessoId]) AND (T2.[SubprocessoAtivo] = 1) ORDER BY T2.[SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00644,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00645", "SELECT [PersonaId], [PersonaNome], [PersonaAtivo] FROM [Persona] WHERE [PersonaAtivo] = 1 ORDER BY [PersonaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00645,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00646", "SELECT [EncarregadoId], [EncarregadoNome], [EncarregadoAtivo] FROM [Encarregado] WHERE [EncarregadoAtivo] = 1 ORDER BY [EncarregadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00646,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00647", "SELECT [ControladorId], [ControladorNome], [ControladorAtivo] FROM [Controlador] WHERE [ControladorAtivo] = 1 ORDER BY [ControladorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00647,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00648", "SELECT [TipoDadoId], [TipoDadoNome], [TipoDadoAtivo] FROM [TipoDado] WHERE [TipoDadoAtivo] = 1 ORDER BY [TipoDadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00648,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00649", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WHERE [FerramentaColetaAtivo] = 1 ORDER BY [FerramentaColetaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00649,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006410", "SELECT [AbrangenciaGeograficaId], [AbrangenciaGeograficaNome], [AbrangenciaGeograficaAtivo] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaAtivo] = 1 ORDER BY [AbrangenciaGeograficaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006410,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006411", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoAtivo] = 1 ORDER BY [FrequenciaTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006411,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006412", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WHERE [TipoDescarteAtivo] = 1 ORDER BY [TipoDescarteNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006412,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006413", "SELECT [TempoRetencaoId], [TempoRetencaoNome], [TempoRetencaoAtivo] FROM [TempoRetencao] WHERE [TempoRetencaoAtivo] = 1 ORDER BY [TempoRetencaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006413,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006414", "SELECT [MedidaSegurancaId], [MedidaSegurancaNome], [MedidaSegurancaAtivo] FROM [MedidaSeguranca] WHERE [MedidaSegurancaAtivo] = 1 ORDER BY [MedidaSegurancaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006414,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006415", "SELECT T1.[DocumentoId], T2.[DocumentoFluxoTratDadosDesc], T2.[DocumentoMedidaSegurancaDesc], T1.[MedidaSegurancaId], T2.[DocumentoDadosCriancaAdolesc], T2.[DocumentoDadosGrupoVul], T2.[DocumentoBaseLegalNormIntExt], T2.[DocumentoBaseLegalNorm], T2.[DocumentoPrevColetaDados], T2.[TempoRetencaoId], T2.[TipoDescarteId], T2.[FrequenciaTratamentoId], T2.[AbrangenciaGeograficaId], T2.[FerramentaColetaId], T2.[TipoDadoId], T2.[CategoriaId], T2.[DocumentoFinalidadeTratamento], T2.[DocumentoAtivo], T2.[DocumentoNome], T2.[EncarregadoId], T2.[PersonaId], T2.[DocumentoDataAlteracao], T2.[DocumentoDataInclusao], T2.[SubprocessoId], T2.[DocumentoProcessoId] AS DocumentoProcessoId FROM ([DocMedidaSeguranca] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) WHERE T1.[DocumentoId] = @DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006415,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006416", "SELECT [DocumentoFluxoTratDadosDesc], [DocumentoMedidaSegurancaDesc], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoBaseLegalNormIntExt], [DocumentoBaseLegalNorm], [DocumentoPrevColetaDados], [TempoRetencaoId], [TipoDescarteId], [FrequenciaTratamentoId], [AbrangenciaGeograficaId], [FerramentaColetaId], [TipoDadoId], [CategoriaId], [DocumentoFinalidadeTratamento], [DocumentoAtivo], [DocumentoNome], [EncarregadoId], [PersonaId], [DocumentoDataAlteracao], [DocumentoDataInclusao], [SubprocessoId], [DocumentoProcessoId] AS DocumentoProcessoId FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006416,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((bool[]) buf[30])[0] = rslt.getBool(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((int[]) buf[34])[0] = rslt.getInt(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((int[]) buf[42])[0] = rslt.getInt(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((bool[]) buf[14])[0] = rslt.getBool(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((int[]) buf[20])[0] = rslt.getInt(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((int[]) buf[22])[0] = rslt.getInt(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((int[]) buf[24])[0] = rslt.getInt(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((int[]) buf[26])[0] = rslt.getInt(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((int[]) buf[28])[0] = rslt.getInt(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((string[]) buf[30])[0] = rslt.getVarchar(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((bool[]) buf[32])[0] = rslt.getBool(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((string[]) buf[34])[0] = rslt.getVarchar(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((int[]) buf[38])[0] = rslt.getInt(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((DateTime[]) buf[42])[0] = rslt.getGXDateTime(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((int[]) buf[44])[0] = rslt.getInt(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                ((int[]) buf[46])[0] = rslt.getInt(25);
                ((bool[]) buf[47])[0] = rslt.wasNull(25);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((bool[]) buf[30])[0] = rslt.getBool(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((int[]) buf[34])[0] = rslt.getInt(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((int[]) buf[42])[0] = rslt.getInt(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                return;
       }
    }

 }

}
