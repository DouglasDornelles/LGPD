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
   public class documentoww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public documentoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentoww( IGxContext context )
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
         dynavDocumentoprocessoid = new GXCombobox();
         dynavSubprocessoid = new GXCombobox();
         dynavArearesponsavelid = new GXCombobox();
         dynavDocumentocontroladorid = new GXCombobox();
         dynavEncarregadoid = new GXCombobox();
         dynavPersonaid = new GXCombobox();
         cmbavDocumentosituacao = new GXCombobox();
         dynavCategoriaid = new GXCombobox();
         dynavTipodadoid = new GXCombobox();
         dynavFerramentacoletaid = new GXCombobox();
         dynavAbrangenciageograficaid = new GXCombobox();
         dynavFrequenciatratamentoid = new GXCombobox();
         dynavTipodescarteid = new GXCombobox();
         dynavTemporetencaoid = new GXCombobox();
         chkavDocumentoprevcoletadados = new GXCheckbox();
         chkavDocumentodadosgrupovul = new GXCheckbox();
         chkavDocumentodadoscriancaadolesc = new GXCheckbox();
         dynavInformacaoid = new GXCombobox();
         chkavDocdicionariosensivel = new GXCheckbox();
         chkavDocdicionariopodeeliminar = new GXCheckbox();
         dynavHipotesetratamentoid = new GXCombobox();
         cmbavDocdicionariotransfinter = new GXCombobox();
         dynavPaisid = new GXCombobox();
         dynavOperadores = new GXCombobox();
         chkavDocoperadorcoleta = new GXCheckbox();
         chkavDocoperadorretencao = new GXCheckbox();
         chkavDocoperadorcompartilhamento = new GXCheckbox();
         chkavDocoperadoreliminacao = new GXCheckbox();
         chkavDocoperadorprocessamento = new GXCheckbox();
         cmbavGridactiongroup1 = new GXCombobox();
         chkDocumentoPrevColetaDados = new GXCheckbox();
         chkDocumentoDadosCriancaAdolesc = new GXCheckbox();
         chkDocumentoDadosGrupoVul = new GXCheckbox();
         cmbDocumentoAtivo = new GXCombobox();
         chkDocumentoOperador = new GXCheckbox();
         cmbavDocumentoativo = new GXCombobox();
         chkavDocumentobuscaavancada = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vDOCUMENTOPROCESSOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvDOCUMENTOPROCESSOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUBPROCESSOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSUBPROCESSOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vAREARESPONSAVELID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvAREARESPONSAVELID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vDOCUMENTOCONTROLADORID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvDOCUMENTOCONTROLADORID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vENCARREGADOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvENCARREGADOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPERSONAID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPERSONAID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCATEGORIAID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCATEGORIAID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vTIPODADOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvTIPODADOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vFERRAMENTACOLETAID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvFERRAMENTACOLETAID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vABRANGENCIAGEOGRAFICAID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvABRANGENCIAGEOGRAFICAID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vFREQUENCIATRATAMENTOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvFREQUENCIATRATAMENTOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vTIPODESCARTEID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvTIPODESCARTEID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vTEMPORETENCAOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvTEMPORETENCAOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vINFORMACAOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvINFORMACAOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vHIPOTESETRATAMENTOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvHIPOTESETRATAMENTOID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPAISID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPAISID5R2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vOPERADORES") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvOPERADORES5R2( ) ;
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
         nRC_GXsfl_257 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_257"), "."));
         nGXsfl_257_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_257_idx"), "."));
         sGXsfl_257_idx = GetPar( "sGXsfl_257_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV166FiltrosDocumento);
         AV109DocumentoBuscaAvancada = StringUtil.StrToBool( GetPar( "DocumentoBuscaAvancada"));
         AV210Pgmname = GetPar( "Pgmname");
         AV188IsAuthorized_Excel = StringUtil.StrToBool( GetPar( "IsAuthorized_Excel"));
         AV189IsAuthorized_PDF = StringUtil.StrToBool( GetPar( "IsAuthorized_PDF"));
         AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV27TFDocumentoId = (int)(NumberUtil.Val( GetPar( "TFDocumentoId"), "."));
         AV28TFDocumentoId_To = (int)(NumberUtil.Val( GetPar( "TFDocumentoId_To"), "."));
         AV150TFDocumentoDataInclusao = context.localUtil.ParseDTimeParm( GetPar( "TFDocumentoDataInclusao"));
         AV151TFDocumentoDataInclusao_To = context.localUtil.ParseDTimeParm( GetPar( "TFDocumentoDataInclusao_To"));
         AV100TFDocumentoDataAlteracao = context.localUtil.ParseDTimeParm( GetPar( "TFDocumentoDataAlteracao"));
         AV101TFDocumentoDataAlteracao_To = context.localUtil.ParseDTimeParm( GetPar( "TFDocumentoDataAlteracao_To"));
         dynavDocumentoprocessoid.FromJSonString( GetNextPar( ));
         AV89DocumentoProcessoId = (int)(NumberUtil.Val( GetPar( "DocumentoProcessoId"), "."));
         dynavSubprocessoid.FromJSonString( GetNextPar( ));
         AV90SubprocessoId = (int)(NumberUtil.Val( GetPar( "SubprocessoId"), "."));
         dynavArearesponsavelid.FromJSonString( GetNextPar( ));
         AV178AreaResponsavelId = (int)(NumberUtil.Val( GetPar( "AreaResponsavelId"), "."));
         dynavDocumentocontroladorid.FromJSonString( GetNextPar( ));
         AV91DocumentoControladorId = (int)(NumberUtil.Val( GetPar( "DocumentoControladorId"), "."));
         dynavEncarregadoid.FromJSonString( GetNextPar( ));
         AV92EncarregadoId = (int)(NumberUtil.Val( GetPar( "EncarregadoId"), "."));
         dynavPersonaid.FromJSonString( GetNextPar( ));
         AV144PersonaId = (int)(NumberUtil.Val( GetPar( "PersonaId"), "."));
         dynavCategoriaid.FromJSonString( GetNextPar( ));
         AV129CategoriaId = (int)(NumberUtil.Val( GetPar( "CategoriaId"), "."));
         dynavTipodadoid.FromJSonString( GetNextPar( ));
         AV130TipoDadoId = (int)(NumberUtil.Val( GetPar( "TipoDadoId"), "."));
         dynavFerramentacoletaid.FromJSonString( GetNextPar( ));
         AV127FerramentaColetaId = (int)(NumberUtil.Val( GetPar( "FerramentaColetaId"), "."));
         dynavAbrangenciageograficaid.FromJSonString( GetNextPar( ));
         AV128AbrangenciaGeograficaId = (int)(NumberUtil.Val( GetPar( "AbrangenciaGeograficaId"), "."));
         dynavFrequenciatratamentoid.FromJSonString( GetNextPar( ));
         AV131FrequenciaTratamentoId = (int)(NumberUtil.Val( GetPar( "FrequenciaTratamentoId"), "."));
         dynavTipodescarteid.FromJSonString( GetNextPar( ));
         AV133TipoDescarteId = (int)(NumberUtil.Val( GetPar( "TipoDescarteId"), "."));
         dynavTemporetencaoid.FromJSonString( GetNextPar( ));
         AV134TempoRetencaoId = (int)(NumberUtil.Val( GetPar( "TempoRetencaoId"), "."));
         dynavInformacaoid.FromJSonString( GetNextPar( ));
         AV110InformacaoId = (int)(NumberUtil.Val( GetPar( "InformacaoId"), "."));
         dynavHipotesetratamentoid.FromJSonString( GetNextPar( ));
         AV111HipoteseTratamentoId = (int)(NumberUtil.Val( GetPar( "HipoteseTratamentoId"), "."));
         dynavPaisid.FromJSonString( GetNextPar( ));
         AV113PaisId = (int)(NumberUtil.Val( GetPar( "PaisId"), "."));
         dynavOperadores.FromJSonString( GetNextPar( ));
         AV118Operadores = (int)(NumberUtil.Val( GetPar( "Operadores"), "."));
         AV132DocumentoPrevColetaDados = StringUtil.StrToBool( GetPar( "DocumentoPrevColetaDados"));
         AV138DocumentoDadosGrupoVul = StringUtil.StrToBool( GetPar( "DocumentoDadosGrupoVul"));
         AV139DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( GetPar( "DocumentoDadosCriancaAdolesc"));
         AV116DocDicionarioSensivel = StringUtil.StrToBool( GetPar( "DocDicionarioSensivel"));
         AV117DocDicionarioPodeEliminar = StringUtil.StrToBool( GetPar( "DocDicionarioPodeEliminar"));
         AV121DocOperadorColeta = StringUtil.StrToBool( GetPar( "DocOperadorColeta"));
         AV122DocOperadorRetencao = StringUtil.StrToBool( GetPar( "DocOperadorRetencao"));
         AV123DocOperadorCompartilhamento = StringUtil.StrToBool( GetPar( "DocOperadorCompartilhamento"));
         AV124DocOperadorEliminacao = StringUtil.StrToBool( GetPar( "DocOperadorEliminacao"));
         AV125DocOperadorProcessamento = StringUtil.StrToBool( GetPar( "DocOperadorProcessamento"));
         AV192IsAuthorized_BtnExcluir = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnExcluir"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
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
            return "documentoww_Execute" ;
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
         PA5R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5R2( ) ;
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
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documentoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV210Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXCEL", GetSecureSignedToken( "", AV188IsAuthorized_Excel, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PDF", GetSecureSignedToken( "", AV189IsAuthorized_PDF, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNEXCLUIR", GetSecureSignedToken( "", AV192IsAuthorized_BtnExcluir, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_257", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_257), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV74GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV76GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV70DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV70DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_DOCUMENTODATAINCLUSAOAUXDATETO", context.localUtil.DToC( AV153DDO_DocumentoDataInclusaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCUMENTODATAALTERACAOAUXDATETO", context.localUtil.DToC( AV103DDO_DocumentoDataAlteracaoAuxDateTo, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTROSDOCUMENTO", AV166FiltrosDocumento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTROSDOCUMENTO", AV166FiltrosDocumento);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV210Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV210Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_EXCEL", AV188IsAuthorized_Excel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXCEL", GetSecureSignedToken( "", AV188IsAuthorized_Excel, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PDF", AV189IsAuthorized_PDF);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PDF", GetSecureSignedToken( "", AV189IsAuthorized_PDF, context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFDocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFDocumentoId_To), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTODATAINCLUSAO", context.localUtil.TToC( AV150TFDocumentoDataInclusao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTODATAINCLUSAO_TO", context.localUtil.TToC( AV151TFDocumentoDataInclusao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTODATAALTERACAO", context.localUtil.TToC( AV100TFDocumentoDataAlteracao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTODATAALTERACAO_TO", context.localUtil.TToC( AV101TFDocumentoDataAlteracao_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNEXCLUIR", AV192IsAuthorized_BtnExcluir);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNEXCLUIR", GetSecureSignedToken( "", AV192IsAuthorized_BtnExcluir, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCUMENTODATAINCLUSAOAUXDATE", context.localUtil.DToC( AV152DDO_DocumentoDataInclusaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCUMENTODATAALTERACAOAUXDATE", context.localUtil.DToC( AV102DDO_DocumentoDataAlteracaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnexcluir_Result));
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
            WE5R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5R2( ) ;
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
         return formatLink("documentoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "DocumentoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Documento" ;
      }

      protected void WB5R0( )
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
            GxWebStd.gx_div_start( context, divTablemain1_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledados_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentonome_Internalname, "NOME DO DOCUMENTO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentonome_Internalname, AV88DocumentoNome, StringUtil.RTrim( context.localUtil.Format( AV88DocumentoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentonome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavDocumentoprocessoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavDocumentoprocessoid_Internalname, "PROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavDocumentoprocessoid, dynavDocumentoprocessoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV89DocumentoProcessoId), 8, 0)), 1, dynavDocumentoprocessoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavDocumentoprocessoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89DocumentoProcessoId), 8, 0));
            AssignProp("", false, dynavDocumentoprocessoid_Internalname, "Values", (string)(dynavDocumentoprocessoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSubprocessoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSubprocessoid_Internalname, "SUBPROCESSO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSubprocessoid, dynavSubprocessoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV90SubprocessoId), 8, 0)), 1, dynavSubprocessoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSubprocessoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV90SubprocessoId), 8, 0));
            AssignProp("", false, dynavSubprocessoid_Internalname, "Values", (string)(dynavSubprocessoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavArearesponsavelid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavArearesponsavelid_Internalname, "ÁREA RESPONSÁVEL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavArearesponsavelid, dynavArearesponsavelid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV178AreaResponsavelId), 8, 0)), 1, dynavArearesponsavelid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavArearesponsavelid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavArearesponsavelid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV178AreaResponsavelId), 8, 0));
            AssignProp("", false, dynavArearesponsavelid_Internalname, "Values", (string)(dynavArearesponsavelid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavDocumentocontroladorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavDocumentocontroladorid_Internalname, "CONTROLADOR", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavDocumentocontroladorid, dynavDocumentocontroladorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV91DocumentoControladorId), 8, 0)), 1, dynavDocumentocontroladorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavDocumentocontroladorid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavDocumentocontroladorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV91DocumentoControladorId), 8, 0));
            AssignProp("", false, dynavDocumentocontroladorid_Internalname, "Values", (string)(dynavDocumentocontroladorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavEncarregadoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEncarregadoid_Internalname, "ENCARREGADO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEncarregadoid, dynavEncarregadoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV92EncarregadoId), 8, 0)), 1, dynavEncarregadoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEncarregadoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavEncarregadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92EncarregadoId), 8, 0));
            AssignProp("", false, dynavEncarregadoid_Internalname, "Values", (string)(dynavEncarregadoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavPersonaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavPersonaid_Internalname, "PERSONA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavPersonaid, dynavPersonaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV144PersonaId), 8, 0)), 1, dynavPersonaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavPersonaid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavPersonaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV144PersonaId), 8, 0));
            AssignProp("", false, dynavPersonaid_Internalname, "Values", (string)(dynavPersonaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocumentosituacao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocumentosituacao_Internalname, "SITUAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentosituacao, cmbavDocumentosituacao_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV93DocumentoSituacao), 4, 0)), 1, cmbavDocumentosituacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDocumentosituacao.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_DocumentoWW.htm");
            cmbavDocumentosituacao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93DocumentoSituacao), 4, 0));
            AssignProp("", false, cmbavDocumentosituacao_Internalname, "Values", (string)(cmbavDocumentosituacao.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "left", "top", "", "", "div");
            wb_table1_55_5R2( true) ;
         }
         else
         {
            wb_table1_55_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_55_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuscaavancada_Internalname, divTablebuscaavancada_Visible, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabdados_title_Internalname, "DADOS", "", "", lblTabdados_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabDados") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletratamentocontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentofinalidadetratamento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentofinalidadetratamento_Internalname, "FINALIDADE DO TRATAMENTO DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentofinalidadetratamento_Internalname, AV126DocumentoFinalidadeTratamento, StringUtil.RTrim( context.localUtil.Format( AV126DocumentoFinalidadeTratamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentofinalidadetratamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentofinalidadetratamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavCategoriaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCategoriaid_Internalname, "CATEGORIA", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoriaid, dynavCategoriaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV129CategoriaId), 8, 0)), 1, dynavCategoriaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCategoriaid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavCategoriaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV129CategoriaId), 8, 0));
            AssignProp("", false, dynavCategoriaid_Internalname, "Values", (string)(dynavCategoriaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavTipodadoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavTipodadoid_Internalname, "TIPO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTipodadoid, dynavTipodadoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV130TipoDadoId), 8, 0)), 1, dynavTipodadoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavTipodadoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavTipodadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV130TipoDadoId), 8, 0));
            AssignProp("", false, dynavTipodadoid_Internalname, "Values", (string)(dynavTipodadoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavFerramentacoletaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavFerramentacoletaid_Internalname, "FERRAMENTA DE COLETA DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavFerramentacoletaid, dynavFerramentacoletaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV127FerramentaColetaId), 8, 0)), 1, dynavFerramentacoletaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavFerramentacoletaid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavFerramentacoletaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV127FerramentaColetaId), 8, 0));
            AssignProp("", false, dynavFerramentacoletaid_Internalname, "Values", (string)(dynavFerramentacoletaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavAbrangenciageograficaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavAbrangenciageograficaid_Internalname, "ABRANGÊNCIA / ÁREA GEOGRÁFICA DO TRATAMENTO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavAbrangenciageograficaid, dynavAbrangenciageograficaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV128AbrangenciaGeograficaId), 8, 0)), 1, dynavAbrangenciageograficaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavAbrangenciageograficaid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavAbrangenciageograficaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV128AbrangenciaGeograficaId), 8, 0));
            AssignProp("", false, dynavAbrangenciageograficaid_Internalname, "Values", (string)(dynavAbrangenciageograficaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavFrequenciatratamentoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavFrequenciatratamentoid_Internalname, "FREQUÊNCIA DE TRATAMENTO DOS DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavFrequenciatratamentoid, dynavFrequenciatratamentoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV131FrequenciaTratamentoId), 8, 0)), 1, dynavFrequenciatratamentoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavFrequenciatratamentoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavFrequenciatratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV131FrequenciaTratamentoId), 8, 0));
            AssignProp("", false, dynavFrequenciatratamentoid_Internalname, "Values", (string)(dynavFrequenciatratamentoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavTipodescarteid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavTipodescarteid_Internalname, "TIPO DESCARTE", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTipodescarteid, dynavTipodescarteid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV133TipoDescarteId), 8, 0)), 1, dynavTipodescarteid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavTipodescarteid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavTipodescarteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV133TipoDescarteId), 8, 0));
            AssignProp("", false, dynavTipodescarteid_Internalname, "Values", (string)(dynavTipodescarteid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavTemporetencaoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavTemporetencaoid_Internalname, "TEMPO DE GUARDA / RETENÇÃO", "col-sm-6 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTemporetencaoid, dynavTemporetencaoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV134TempoRetencaoId), 8, 0)), 1, dynavTemporetencaoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavTemporetencaoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavTemporetencaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV134TempoRetencaoId), 8, 0));
            AssignProp("", false, dynavTemporetencaoid_Internalname, "Values", (string)(dynavTemporetencaoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocumentoprevcoletadados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocumentoprevcoletadados_Internalname, "PREVISÃO PARA COLETA DE DADOS", "col-sm-6 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocumentoprevcoletadados_Internalname, StringUtil.BoolToStr( AV132DocumentoPrevColetaDados), "", "PREVISÃO PARA COLETA DE DADOS", 1, chkavDocumentoprevcoletadados.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentobaselegalnorm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentobaselegalnorm_Internalname, "BASE LEGAL - NORMATIVO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentobaselegalnorm_Internalname, AV135DocumentoBaseLegalNorm, StringUtil.RTrim( context.localUtil.Format( AV135DocumentoBaseLegalNorm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentobaselegalnorm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentobaselegalnorm_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocumentobaselegalnormintext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocumentobaselegalnormintext_Internalname, "BASE LEGAL - NORMATIVO (INTERNO E EXTERNO)", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentobaselegalnormintext_Internalname, AV136DocumentoBaseLegalNormIntExt, StringUtil.RTrim( context.localUtil.Format( AV136DocumentoBaseLegalNormIntExt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentobaselegalnormintext_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocumentobaselegalnormintext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocumentodadosgrupovul_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocumentodadosgrupovul_Internalname, "POSSUI DADOS DE GRUPOS VULNERÁVEIS", "col-sm-6 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocumentodadosgrupovul_Internalname, StringUtil.BoolToStr( AV138DocumentoDadosGrupoVul), "", "POSSUI DADOS DE GRUPOS VULNERÁVEIS", 1, chkavDocumentodadosgrupovul.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(127, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,127);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocumentodadoscriancaadolesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocumentodadoscriancaadolesc_Internalname, "POSSUI DADOS DE CRIANÇA / ADOLESCENTE", "col-sm-6 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocumentodadoscriancaadolesc_Internalname, StringUtil.BoolToStr( AV139DocumentoDadosCriancaAdolesc), "", "POSSUI DADOS DE CRIANÇA / ADOLESCENTE", 1, chkavDocumentodadoscriancaadolesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(131, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,131);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabdicionario_title_Internalname, "DICIONÁRIO", "", "", lblTabdicionario_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabDicionario") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablediciocontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavInformacaoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavInformacaoid_Internalname, "INFORMAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavInformacaoid, dynavInformacaoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV110InformacaoId), 8, 0)), 1, dynavInformacaoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavInformacaoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV110InformacaoId), 8, 0));
            AssignProp("", false, dynavInformacaoid_Internalname, "Values", (string)(dynavInformacaoid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocdicionariosensivel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocdicionariosensivel_Internalname, "SENSÍVEL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocdicionariosensivel_Internalname, StringUtil.BoolToStr( AV116DocDicionarioSensivel), "", "SENSÍVEL", 1, chkavDocdicionariosensivel.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(149, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,149);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocdicionariopodeeliminar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocdicionariopodeeliminar_Internalname, "PODE ELIMINAR", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocdicionariopodeeliminar_Internalname, StringUtil.BoolToStr( AV117DocDicionarioPodeEliminar), "", "PODE ELIMINAR", 1, chkavDocdicionariopodeeliminar.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(153, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,153);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavHipotesetratamentoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavHipotesetratamentoid_Internalname, "HIPÓTESE TRATAMENTO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavHipotesetratamentoid, dynavHipotesetratamentoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV111HipoteseTratamentoId), 8, 0)), 1, dynavHipotesetratamentoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavHipotesetratamentoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV111HipoteseTratamentoId), 8, 0));
            AssignProp("", false, dynavHipotesetratamentoid_Internalname, "Values", (string)(dynavHipotesetratamentoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletransfint_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocdicionariotransfinter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocdicionariotransfinter_Internalname, "TRANSFERÊNCIA INTERNACIONAL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocdicionariotransfinter, cmbavDocdicionariotransfinter_Internalname, StringUtil.BoolToStr( AV168DocDicionarioTransfInter), 1, cmbavDocdicionariotransfinter_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocdicionariotransfinter.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "", true, 0, "HLP_DocumentoWW.htm");
            cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV168DocDicionarioTransfInter);
            AssignProp("", false, cmbavDocdicionariotransfinter_Internalname, "Values", (string)(cmbavDocdicionariotransfinter.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavPaisid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavPaisid_Internalname, "PAÍS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavPaisid, dynavPaisid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV113PaisId), 8, 0)), 1, dynavPaisid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavPaisid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV113PaisId), 8, 0));
            AssignProp("", false, dynavPaisid_Internalname, "Values", (string)(dynavPaisid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocdicionariotipotransfintergarantia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocdicionariotipotransfintergarantia_Internalname, "TIPO GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocdicionariotipotransfintergarantia_Internalname, AV155DocDicionarioTipoTransfInterGarantia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"", 0, 1, edtavDocdicionariotipotransfintergarantia_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocdicionariofinalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocdicionariofinalidade_Internalname, "FINALIDADE", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocdicionariofinalidade_Internalname, AV156DocDicionarioFinalidade, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", 0, 1, edtavDocdicionariofinalidade_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTaboperador_title_Internalname, "OPERADOR(ES)", "", "", lblTaboperador_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabOperador") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableoperadorcontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableoperadordados_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavOperadores_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavOperadores_Internalname, "NOME", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavOperadores, dynavOperadores_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV118Operadores), 8, 0)), 1, dynavOperadores_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavOperadores.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,193);\"", "", true, 0, "HLP_DocumentoWW.htm");
            dynavOperadores.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV118Operadores), 8, 0));
            AssignProp("", false, dynavOperadores_Internalname, "Values", (string)(dynavOperadores.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledadoscheck_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            wb_table2_201_5R2( true) ;
         }
         else
         {
            wb_table2_201_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_201_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:2;", "div");
            wb_table3_209_5R2( true) ;
         }
         else
         {
            wb_table3_209_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_209_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:3;", "div");
            wb_table4_217_5R2( true) ;
         }
         else
         {
            wb_table4_217_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_217_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:4;", "div");
            wb_table5_225_5R2( true) ;
         }
         else
         {
            wb_table5_225_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table5_225_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:5;", "div");
            wb_table6_233_5R2( true) ;
         }
         else
         {
            wb_table6_233_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table6_233_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnbuscar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(257), 3, 0)+","+"null"+");", "BUSCAR", bttBtnbtnbuscar_Jsonclick, 5, "BUSCAR", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNBUSCAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnlimpar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(257), 3, 0)+","+"null"+");", "LIMPAR", bttBtnbtnlimpar_Jsonclick, 5, "LIMPAR", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNLIMPAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 248,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtninserir_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(257), 3, 0)+","+"null"+");", "INSERIR", bttBtnbtninserir_Jsonclick, 5, "INSERIR", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNINSERIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl257( ) ;
         }
         if ( wbEnd == 257 )
         {
            wbEnd = 0;
            nRC_GXsfl_257 = (int)(nGXsfl_257_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV74GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV75GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV76GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV70DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 300,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV95DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV95DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,300);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocumentoid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocumentoWW.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 301,'',false,'" + sGXsfl_257_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocumentoativo, cmbavDocumentoativo_Internalname, StringUtil.BoolToStr( AV94DocumentoAtivo), 1, cmbavDocumentoativo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavDocumentoativo.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,301);\"", "", true, 0, "HLP_DocumentoWW.htm");
            cmbavDocumentoativo.CurrentValue = StringUtil.BoolToStr( AV94DocumentoAtivo);
            AssignProp("", false, cmbavDocumentoativo_Internalname, "Values", (string)(cmbavDocumentoativo.ToJavascriptSource()), true);
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocumentobuscaavancada_Internalname, StringUtil.BoolToStr( AV109DocumentoBuscaAvancada), "", "", chkavDocumentobuscaavancada.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(302, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,302);\"");
            wb_table7_303_5R2( true) ;
         }
         else
         {
            wb_table7_303_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table7_303_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_documentodatainclusaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 310,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_documentodatainclusaoauxdatetext_Internalname, AV154DDO_DocumentoDataInclusaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV154DDO_DocumentoDataInclusaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,310);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_documentodatainclusaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWW.htm");
            /* User Defined Control */
            ucTfdocumentodatainclusao_rangepicker.SetProperty("Start Date", AV152DDO_DocumentoDataInclusaoAuxDate);
            ucTfdocumentodatainclusao_rangepicker.SetProperty("End Date", AV153DDO_DocumentoDataInclusaoAuxDateTo);
            ucTfdocumentodatainclusao_rangepicker.Render(context, "wwp.daterangepicker", Tfdocumentodatainclusao_rangepicker_Internalname, "TFDOCUMENTODATAINCLUSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_documentodataalteracaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 313,'',false,'" + sGXsfl_257_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_documentodataalteracaoauxdatetext_Internalname, AV104DDO_DocumentoDataAlteracaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV104DDO_DocumentoDataAlteracaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,313);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_documentodataalteracaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_DocumentoWW.htm");
            /* User Defined Control */
            ucTfdocumentodataalteracao_rangepicker.SetProperty("Start Date", AV102DDO_DocumentoDataAlteracaoAuxDate);
            ucTfdocumentodataalteracao_rangepicker.SetProperty("End Date", AV103DDO_DocumentoDataAlteracaoAuxDateTo);
            ucTfdocumentodataalteracao_rangepicker.Render(context, "wwp.daterangepicker", Tfdocumentodataalteracao_rangepicker_Internalname, "TFDOCUMENTODATAALTERACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 257 )
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

      protected void START5R2( )
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
            Form.Meta.addItem("description", " Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5R0( ) ;
      }

      protected void WS5R2( )
      {
         START5R2( ) ;
         EVT5R2( ) ;
      }

      protected void EVT5R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNEXCLUIR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E145R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNBUSCAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnBuscar' */
                              E155R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNLIMPAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnLimpar' */
                              E165R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNINSERIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnInserir' */
                              E175R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VBTNEXCLUIR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VBTNATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VBTNVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VBTNATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VBTNVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VBTNEXCLUIR.CLICK") == 0 ) )
                           {
                              nGXsfl_257_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_257_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_257_idx), 4, 0), 4, "0");
                              SubsflControlProps_2572( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV179GridActionGroup1 = (short)(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV179GridActionGroup1), 4, 0));
                              AV149BtnAtualizar = cgiGet( edtavBtnatualizar_Internalname);
                              AssignAttri("", false, edtavBtnatualizar_Internalname, AV149BtnAtualizar);
                              AV148BtnVisualizar = cgiGet( edtavBtnvisualizar_Internalname);
                              AssignAttri("", false, edtavBtnvisualizar_Internalname, AV148BtnVisualizar);
                              AV180BtnExcluir = cgiGet( edtavBtnexcluir_Internalname);
                              AssignAttri("", false, edtavBtnexcluir_Internalname, AV180BtnExcluir);
                              A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                              AV205DocumentoNome_Grid = cgiGet( edtavDocumentonome_grid_Internalname);
                              AssignAttri("", false, edtavDocumentonome_grid_Internalname, AV205DocumentoNome_Grid);
                              A76DocumentoNome = cgiGet( edtDocumentoNome_Internalname);
                              n76DocumentoNome = false;
                              AV206ProcessoNome_Grid = cgiGet( edtavProcessonome_grid_Internalname);
                              AssignAttri("", false, edtavProcessonome_grid_Internalname, AV206ProcessoNome_Grid);
                              A17ProcessoNome = cgiGet( edtProcessoNome_Internalname);
                              A21SubprocessoNome = cgiGet( edtSubprocessoNome_Internalname);
                              AV207SubprocessoNome_Grid = cgiGet( edtavSubprocessonome_grid_Internalname);
                              AssignAttri("", false, edtavSubprocessonome_grid_Internalname, AV207SubprocessoNome_Grid);
                              A108DocumentoDataInclusao = context.localUtil.CToT( cgiGet( edtDocumentoDataInclusao_Internalname), 0);
                              n108DocumentoDataInclusao = false;
                              A109DocumentoDataAlteracao = context.localUtil.CToT( cgiGet( edtDocumentoDataAlteracao_Internalname), 0);
                              n109DocumentoDataAlteracao = false;
                              A106DocumentoProcessoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoProcessoId_Internalname), ",", "."));
                              n106DocumentoProcessoId = false;
                              A16ProcessoId = (int)(context.localUtil.CToN( cgiGet( edtProcessoId_Internalname), ",", "."));
                              n16ProcessoId = false;
                              A20SubprocessoId = (int)(context.localUtil.CToN( cgiGet( edtSubprocessoId_Internalname), ",", "."));
                              n20SubprocessoId = false;
                              A7EncarregadoId = (int)(context.localUtil.CToN( cgiGet( edtEncarregadoId_Internalname), ",", "."));
                              n7EncarregadoId = false;
                              A13PersonaId = (int)(context.localUtil.CToN( cgiGet( edtPersonaId_Internalname), ",", "."));
                              n13PersonaId = false;
                              A77DocumentoFinalidadeTratamento = cgiGet( edtDocumentoFinalidadeTratamento_Internalname);
                              n77DocumentoFinalidadeTratamento = false;
                              A27CategoriaId = (int)(context.localUtil.CToN( cgiGet( edtCategoriaId_Internalname), ",", "."));
                              n27CategoriaId = false;
                              A30TipoDadoId = (int)(context.localUtil.CToN( cgiGet( edtTipoDadoId_Internalname), ",", "."));
                              n30TipoDadoId = false;
                              A33FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( edtFerramentaColetaId_Internalname), ",", "."));
                              n33FerramentaColetaId = false;
                              A36AbrangenciaGeograficaId = (int)(context.localUtil.CToN( cgiGet( edtAbrangenciaGeograficaId_Internalname), ",", "."));
                              n36AbrangenciaGeograficaId = false;
                              A39FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( edtFrequenciaTratamentoId_Internalname), ",", "."));
                              n39FrequenciaTratamentoId = false;
                              A45TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( edtTipoDescarteId_Internalname), ",", "."));
                              n45TipoDescarteId = false;
                              A48TempoRetencaoId = (int)(context.localUtil.CToN( cgiGet( edtTempoRetencaoId_Internalname), ",", "."));
                              n48TempoRetencaoId = false;
                              A78DocumentoPrevColetaDados = StringUtil.StrToBool( cgiGet( chkDocumentoPrevColetaDados_Internalname));
                              n78DocumentoPrevColetaDados = false;
                              A79DocumentoBaseLegalNorm = cgiGet( edtDocumentoBaseLegalNorm_Internalname);
                              n79DocumentoBaseLegalNorm = false;
                              A80DocumentoBaseLegalNormIntExt = cgiGet( edtDocumentoBaseLegalNormIntExt_Internalname);
                              n80DocumentoBaseLegalNormIntExt = false;
                              A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( cgiGet( chkDocumentoDadosCriancaAdolesc_Internalname));
                              n81DocumentoDadosCriancaAdolesc = false;
                              A82DocumentoDadosGrupoVul = StringUtil.StrToBool( cgiGet( chkDocumentoDadosGrupoVul_Internalname));
                              n82DocumentoDadosGrupoVul = false;
                              A83DocumentoMedidaSegurancaDesc = cgiGet( edtDocumentoMedidaSegurancaDesc_Internalname);
                              n83DocumentoMedidaSegurancaDesc = false;
                              cmbDocumentoAtivo.Name = cmbDocumentoAtivo_Internalname;
                              cmbDocumentoAtivo.CurrentValue = cgiGet( cmbDocumentoAtivo_Internalname);
                              A85DocumentoAtivo = StringUtil.StrToBool( cgiGet( cmbDocumentoAtivo_Internalname));
                              n85DocumentoAtivo = false;
                              A105DocumentoOperador = StringUtil.StrToBool( cgiGet( chkDocumentoOperador_Internalname));
                              n105DocumentoOperador = false;
                              A107DocumentoProcessoNome = cgiGet( edtDocumentoProcessoNome_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E185R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E195R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E205R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E215R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNEXCLUIR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E225R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNATUALIZAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E235R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNVISUALIZAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E245R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE5R2( )
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

      protected void PA5R2( )
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
               GX_FocusControl = edtavDocumentonome_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvDOCUMENTOPROCESSOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvDOCUMENTOPROCESSOID_data5R2( ) ;
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

      protected void GXVvDOCUMENTOPROCESSOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvDOCUMENTOPROCESSOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavDocumentoprocessoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavDocumentoprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvDOCUMENTOPROCESSOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R2_A16ProcessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R2_A17ProcessoNome[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSUBPROCESSOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUBPROCESSOID_data5R2( ) ;
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

      protected void GXVvSUBPROCESSOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUBPROCESSOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSubprocessoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSubprocessoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUBPROCESSOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R3_A20SubprocessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R3_A21SubprocessoNome[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvAREARESPONSAVELID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvAREARESPONSAVELID_data5R2( ) ;
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

      protected void GXVvAREARESPONSAVELID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvAREARESPONSAVELID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavArearesponsavelid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavArearesponsavelid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvAREARESPONSAVELID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R4_A24AreaResponsavelId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R4_A25AreaResponsavelNome[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLVvDOCUMENTOCONTROLADORID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvDOCUMENTOCONTROLADORID_data5R2( ) ;
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

      protected void GXVvDOCUMENTOCONTROLADORID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvDOCUMENTOCONTROLADORID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavDocumentocontroladorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavDocumentocontroladorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvDOCUMENTOCONTROLADORID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R5_A10ControladorId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R5_A11ControladorNome[0]);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void GXDLVvENCARREGADOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvENCARREGADOID_data5R2( ) ;
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

      protected void GXVvENCARREGADOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvENCARREGADOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEncarregadoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavEncarregadoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvENCARREGADOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R6_A7EncarregadoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R6_A8EncarregadoNome[0]);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void GXDLVvPERSONAID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPERSONAID_data5R2( ) ;
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

      protected void GXVvPERSONAID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvPERSONAID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavPersonaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavPersonaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPERSONAID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R7_A13PersonaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R7_A14PersonaNome[0]);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void GXDLVvCATEGORIAID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIAID_data5R2( ) ;
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

      protected void GXVvCATEGORIAID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvCATEGORIAID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCategoriaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavCategoriaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCATEGORIAID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R8_A27CategoriaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R8_A28CategoriaNome[0]);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void GXDLVvTIPODADOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvTIPODADOID_data5R2( ) ;
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

      protected void GXVvTIPODADOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvTIPODADOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavTipodadoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavTipodadoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvTIPODADOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R9_A30TipoDadoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R9_A31TipoDadoNome[0]);
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void GXDLVvFERRAMENTACOLETAID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvFERRAMENTACOLETAID_data5R2( ) ;
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

      protected void GXVvFERRAMENTACOLETAID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvFERRAMENTACOLETAID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavFerramentacoletaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavFerramentacoletaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvFERRAMENTACOLETAID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R10_A33FerramentaColetaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R10_A34FerramentaColetaNome[0]);
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      protected void GXDLVvABRANGENCIAGEOGRAFICAID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvABRANGENCIAGEOGRAFICAID_data5R2( ) ;
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

      protected void GXVvABRANGENCIAGEOGRAFICAID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvABRANGENCIAGEOGRAFICAID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavAbrangenciageograficaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavAbrangenciageograficaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvABRANGENCIAGEOGRAFICAID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R11 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R11_A36AbrangenciaGeograficaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R11_A37AbrangenciaGeograficaNome[0]);
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void GXDLVvFREQUENCIATRATAMENTOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvFREQUENCIATRATAMENTOID_data5R2( ) ;
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

      protected void GXVvFREQUENCIATRATAMENTOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvFREQUENCIATRATAMENTOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavFrequenciatratamentoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavFrequenciatratamentoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvFREQUENCIATRATAMENTOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R12_A39FrequenciaTratamentoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R12_A40FrequenciaTratamentoNome[0]);
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void GXDLVvTIPODESCARTEID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvTIPODESCARTEID_data5R2( ) ;
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

      protected void GXVvTIPODESCARTEID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvTIPODESCARTEID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavTipodescarteid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavTipodescarteid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvTIPODESCARTEID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R13 */
         pr_default.execute(11);
         while ( (pr_default.getStatus(11) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R13_A45TipoDescarteId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R13_A46TipoDescarteNome[0]);
            pr_default.readNext(11);
         }
         pr_default.close(11);
      }

      protected void GXDLVvTEMPORETENCAOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvTEMPORETENCAOID_data5R2( ) ;
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

      protected void GXVvTEMPORETENCAOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvTEMPORETENCAOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavTemporetencaoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavTemporetencaoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvTEMPORETENCAOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R14 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R14_A48TempoRetencaoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R14_A49TempoRetencaoNome[0]);
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void GXDLVvINFORMACAOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvINFORMACAOID_data5R2( ) ;
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

      protected void GXVvINFORMACAOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvINFORMACAOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavInformacaoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavInformacaoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvINFORMACAOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R15 */
         pr_default.execute(13);
         while ( (pr_default.getStatus(13) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R15_A69InformacaoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R15_A70InformacaoNome[0]);
            pr_default.readNext(13);
         }
         pr_default.close(13);
      }

      protected void GXDLVvHIPOTESETRATAMENTOID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvHIPOTESETRATAMENTOID_data5R2( ) ;
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

      protected void GXVvHIPOTESETRATAMENTOID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvHIPOTESETRATAMENTOID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavHipotesetratamentoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavHipotesetratamentoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvHIPOTESETRATAMENTOID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R16 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R16_A72HipoteseTratamentoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R16_A73HipoteseTratamentoNome[0]);
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void GXDLVvPAISID5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPAISID_data5R2( ) ;
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

      protected void GXVvPAISID_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvPAISID_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavPaisid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavPaisid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPAISID_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Selecione)");
         /* Using cursor H005R17 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R17_A4PaisId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R17_A5PaisNome[0]);
            pr_default.readNext(15);
         }
         pr_default.close(15);
      }

      protected void GXDLVvOPERADORES5R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvOPERADORES_data5R2( ) ;
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

      protected void GXVvOPERADORES_html5R2( )
      {
         int gxdynajaxvalue;
         GXDLVvOPERADORES_data5R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavOperadores.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavOperadores.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvOPERADORES_data5R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(SELECIONE)");
         /* Using cursor H005R18 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005R18_A42OperadorId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005R18_A43OperadorNome[0]);
            pr_default.readNext(16);
         }
         pr_default.close(16);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2572( ) ;
         while ( nGXsfl_257_idx <= nRC_GXsfl_257 )
         {
            sendrow_2572( ) ;
            nGXsfl_257_idx = ((subGrid_Islastpage==1)&&(nGXsfl_257_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_257_idx+1);
            sGXsfl_257_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_257_idx), 4, 0), 4, "0");
            SubsflControlProps_2572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       SdtFiltrosDocumento AV166FiltrosDocumento ,
                                       bool AV109DocumentoBuscaAvancada ,
                                       string AV210Pgmname ,
                                       bool AV188IsAuthorized_Excel ,
                                       bool AV189IsAuthorized_PDF ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       int AV27TFDocumentoId ,
                                       int AV28TFDocumentoId_To ,
                                       DateTime AV150TFDocumentoDataInclusao ,
                                       DateTime AV151TFDocumentoDataInclusao_To ,
                                       DateTime AV100TFDocumentoDataAlteracao ,
                                       DateTime AV101TFDocumentoDataAlteracao_To ,
                                       int AV89DocumentoProcessoId ,
                                       int AV90SubprocessoId ,
                                       int AV178AreaResponsavelId ,
                                       int AV91DocumentoControladorId ,
                                       int AV92EncarregadoId ,
                                       int AV144PersonaId ,
                                       int AV129CategoriaId ,
                                       int AV130TipoDadoId ,
                                       int AV127FerramentaColetaId ,
                                       int AV128AbrangenciaGeograficaId ,
                                       int AV131FrequenciaTratamentoId ,
                                       int AV133TipoDescarteId ,
                                       int AV134TempoRetencaoId ,
                                       int AV110InformacaoId ,
                                       int AV111HipoteseTratamentoId ,
                                       int AV113PaisId ,
                                       int AV118Operadores ,
                                       bool AV132DocumentoPrevColetaDados ,
                                       bool AV138DocumentoDadosGrupoVul ,
                                       bool AV139DocumentoDadosCriancaAdolesc ,
                                       bool AV116DocDicionarioSensivel ,
                                       bool AV117DocDicionarioPodeEliminar ,
                                       bool AV121DocOperadorColeta ,
                                       bool AV122DocOperadorRetencao ,
                                       bool AV123DocOperadorCompartilhamento ,
                                       bool AV124DocOperadorEliminacao ,
                                       bool AV125DocOperadorProcessamento ,
                                       bool AV192IsAuthorized_BtnExcluir )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E195R2 ();
         GRID_nCurrentRecord = 0;
         RF5R2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvDOCUMENTOPROCESSOID_html5R2( ) ;
            GXVvSUBPROCESSOID_html5R2( ) ;
            GXVvAREARESPONSAVELID_html5R2( ) ;
            GXVvDOCUMENTOCONTROLADORID_html5R2( ) ;
            GXVvENCARREGADOID_html5R2( ) ;
            GXVvPERSONAID_html5R2( ) ;
            GXVvCATEGORIAID_html5R2( ) ;
            GXVvTIPODADOID_html5R2( ) ;
            GXVvFERRAMENTACOLETAID_html5R2( ) ;
            GXVvABRANGENCIAGEOGRAFICAID_html5R2( ) ;
            GXVvFREQUENCIATRATAMENTOID_html5R2( ) ;
            GXVvTIPODESCARTEID_html5R2( ) ;
            GXVvTEMPORETENCAOID_html5R2( ) ;
            GXVvINFORMACAOID_html5R2( ) ;
            GXVvHIPOTESETRATAMENTOID_html5R2( ) ;
            GXVvPAISID_html5R2( ) ;
            GXVvOPERADORES_html5R2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavDocumentoprocessoid.ItemCount > 0 )
         {
            AV89DocumentoProcessoId = (int)(NumberUtil.Val( dynavDocumentoprocessoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV89DocumentoProcessoId), 8, 0))), "."));
            AssignAttri("", false, "AV89DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV89DocumentoProcessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89DocumentoProcessoId), 8, 0));
            AssignProp("", false, dynavDocumentoprocessoid_Internalname, "Values", dynavDocumentoprocessoid.ToJavascriptSource(), true);
         }
         if ( dynavSubprocessoid.ItemCount > 0 )
         {
            AV90SubprocessoId = (int)(NumberUtil.Val( dynavSubprocessoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV90SubprocessoId), 8, 0))), "."));
            AssignAttri("", false, "AV90SubprocessoId", StringUtil.LTrimStr( (decimal)(AV90SubprocessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV90SubprocessoId), 8, 0));
            AssignProp("", false, dynavSubprocessoid_Internalname, "Values", dynavSubprocessoid.ToJavascriptSource(), true);
         }
         if ( dynavArearesponsavelid.ItemCount > 0 )
         {
            AV178AreaResponsavelId = (int)(NumberUtil.Val( dynavArearesponsavelid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV178AreaResponsavelId), 8, 0))), "."));
            AssignAttri("", false, "AV178AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV178AreaResponsavelId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavArearesponsavelid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV178AreaResponsavelId), 8, 0));
            AssignProp("", false, dynavArearesponsavelid_Internalname, "Values", dynavArearesponsavelid.ToJavascriptSource(), true);
         }
         if ( dynavDocumentocontroladorid.ItemCount > 0 )
         {
            AV91DocumentoControladorId = (int)(NumberUtil.Val( dynavDocumentocontroladorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV91DocumentoControladorId), 8, 0))), "."));
            AssignAttri("", false, "AV91DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV91DocumentoControladorId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDocumentocontroladorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV91DocumentoControladorId), 8, 0));
            AssignProp("", false, dynavDocumentocontroladorid_Internalname, "Values", dynavDocumentocontroladorid.ToJavascriptSource(), true);
         }
         if ( dynavEncarregadoid.ItemCount > 0 )
         {
            AV92EncarregadoId = (int)(NumberUtil.Val( dynavEncarregadoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV92EncarregadoId), 8, 0))), "."));
            AssignAttri("", false, "AV92EncarregadoId", StringUtil.LTrimStr( (decimal)(AV92EncarregadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEncarregadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92EncarregadoId), 8, 0));
            AssignProp("", false, dynavEncarregadoid_Internalname, "Values", dynavEncarregadoid.ToJavascriptSource(), true);
         }
         if ( dynavPersonaid.ItemCount > 0 )
         {
            AV144PersonaId = (int)(NumberUtil.Val( dynavPersonaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV144PersonaId), 8, 0))), "."));
            AssignAttri("", false, "AV144PersonaId", StringUtil.LTrimStr( (decimal)(AV144PersonaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavPersonaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV144PersonaId), 8, 0));
            AssignProp("", false, dynavPersonaid_Internalname, "Values", dynavPersonaid.ToJavascriptSource(), true);
         }
         if ( cmbavDocumentosituacao.ItemCount > 0 )
         {
            AV93DocumentoSituacao = (short)(NumberUtil.Val( cmbavDocumentosituacao.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV93DocumentoSituacao), 4, 0))), "."));
            AssignAttri("", false, "AV93DocumentoSituacao", StringUtil.LTrimStr( (decimal)(AV93DocumentoSituacao), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentosituacao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93DocumentoSituacao), 4, 0));
            AssignProp("", false, cmbavDocumentosituacao_Internalname, "Values", cmbavDocumentosituacao.ToJavascriptSource(), true);
         }
         if ( dynavCategoriaid.ItemCount > 0 )
         {
            AV129CategoriaId = (int)(NumberUtil.Val( dynavCategoriaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV129CategoriaId), 8, 0))), "."));
            AssignAttri("", false, "AV129CategoriaId", StringUtil.LTrimStr( (decimal)(AV129CategoriaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoriaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV129CategoriaId), 8, 0));
            AssignProp("", false, dynavCategoriaid_Internalname, "Values", dynavCategoriaid.ToJavascriptSource(), true);
         }
         if ( dynavTipodadoid.ItemCount > 0 )
         {
            AV130TipoDadoId = (int)(NumberUtil.Val( dynavTipodadoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV130TipoDadoId), 8, 0))), "."));
            AssignAttri("", false, "AV130TipoDadoId", StringUtil.LTrimStr( (decimal)(AV130TipoDadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavTipodadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV130TipoDadoId), 8, 0));
            AssignProp("", false, dynavTipodadoid_Internalname, "Values", dynavTipodadoid.ToJavascriptSource(), true);
         }
         if ( dynavFerramentacoletaid.ItemCount > 0 )
         {
            AV127FerramentaColetaId = (int)(NumberUtil.Val( dynavFerramentacoletaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV127FerramentaColetaId), 8, 0))), "."));
            AssignAttri("", false, "AV127FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV127FerramentaColetaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavFerramentacoletaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV127FerramentaColetaId), 8, 0));
            AssignProp("", false, dynavFerramentacoletaid_Internalname, "Values", dynavFerramentacoletaid.ToJavascriptSource(), true);
         }
         if ( dynavAbrangenciageograficaid.ItemCount > 0 )
         {
            AV128AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynavAbrangenciageograficaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV128AbrangenciaGeograficaId), 8, 0))), "."));
            AssignAttri("", false, "AV128AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV128AbrangenciaGeograficaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavAbrangenciageograficaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV128AbrangenciaGeograficaId), 8, 0));
            AssignProp("", false, dynavAbrangenciageograficaid_Internalname, "Values", dynavAbrangenciageograficaid.ToJavascriptSource(), true);
         }
         if ( dynavFrequenciatratamentoid.ItemCount > 0 )
         {
            AV131FrequenciaTratamentoId = (int)(NumberUtil.Val( dynavFrequenciatratamentoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV131FrequenciaTratamentoId), 8, 0))), "."));
            AssignAttri("", false, "AV131FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV131FrequenciaTratamentoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavFrequenciatratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV131FrequenciaTratamentoId), 8, 0));
            AssignProp("", false, dynavFrequenciatratamentoid_Internalname, "Values", dynavFrequenciatratamentoid.ToJavascriptSource(), true);
         }
         if ( dynavTipodescarteid.ItemCount > 0 )
         {
            AV133TipoDescarteId = (int)(NumberUtil.Val( dynavTipodescarteid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV133TipoDescarteId), 8, 0))), "."));
            AssignAttri("", false, "AV133TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV133TipoDescarteId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavTipodescarteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV133TipoDescarteId), 8, 0));
            AssignProp("", false, dynavTipodescarteid_Internalname, "Values", dynavTipodescarteid.ToJavascriptSource(), true);
         }
         if ( dynavTemporetencaoid.ItemCount > 0 )
         {
            AV134TempoRetencaoId = (int)(NumberUtil.Val( dynavTemporetencaoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV134TempoRetencaoId), 8, 0))), "."));
            AssignAttri("", false, "AV134TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV134TempoRetencaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavTemporetencaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV134TempoRetencaoId), 8, 0));
            AssignProp("", false, dynavTemporetencaoid_Internalname, "Values", dynavTemporetencaoid.ToJavascriptSource(), true);
         }
         AV132DocumentoPrevColetaDados = StringUtil.StrToBool( StringUtil.BoolToStr( AV132DocumentoPrevColetaDados));
         AssignAttri("", false, "AV132DocumentoPrevColetaDados", AV132DocumentoPrevColetaDados);
         AV138DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( AV138DocumentoDadosGrupoVul));
         AssignAttri("", false, "AV138DocumentoDadosGrupoVul", AV138DocumentoDadosGrupoVul);
         AV139DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV139DocumentoDadosCriancaAdolesc));
         AssignAttri("", false, "AV139DocumentoDadosCriancaAdolesc", AV139DocumentoDadosCriancaAdolesc);
         if ( dynavInformacaoid.ItemCount > 0 )
         {
            AV110InformacaoId = (int)(NumberUtil.Val( dynavInformacaoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV110InformacaoId), 8, 0))), "."));
            AssignAttri("", false, "AV110InformacaoId", StringUtil.LTrimStr( (decimal)(AV110InformacaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV110InformacaoId), 8, 0));
            AssignProp("", false, dynavInformacaoid_Internalname, "Values", dynavInformacaoid.ToJavascriptSource(), true);
         }
         AV116DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( AV116DocDicionarioSensivel));
         AssignAttri("", false, "AV116DocDicionarioSensivel", AV116DocDicionarioSensivel);
         AV117DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( AV117DocDicionarioPodeEliminar));
         AssignAttri("", false, "AV117DocDicionarioPodeEliminar", AV117DocDicionarioPodeEliminar);
         if ( dynavHipotesetratamentoid.ItemCount > 0 )
         {
            AV111HipoteseTratamentoId = (int)(NumberUtil.Val( dynavHipotesetratamentoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV111HipoteseTratamentoId), 8, 0))), "."));
            AssignAttri("", false, "AV111HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV111HipoteseTratamentoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV111HipoteseTratamentoId), 8, 0));
            AssignProp("", false, dynavHipotesetratamentoid_Internalname, "Values", dynavHipotesetratamentoid.ToJavascriptSource(), true);
         }
         if ( cmbavDocdicionariotransfinter.ItemCount > 0 )
         {
            AV168DocDicionarioTransfInter = StringUtil.StrToBool( cmbavDocdicionariotransfinter.getValidValue(StringUtil.BoolToStr( AV168DocDicionarioTransfInter)));
            AssignAttri("", false, "AV168DocDicionarioTransfInter", AV168DocDicionarioTransfInter);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV168DocDicionarioTransfInter);
            AssignProp("", false, cmbavDocdicionariotransfinter_Internalname, "Values", cmbavDocdicionariotransfinter.ToJavascriptSource(), true);
         }
         if ( dynavPaisid.ItemCount > 0 )
         {
            AV113PaisId = (int)(NumberUtil.Val( dynavPaisid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV113PaisId), 8, 0))), "."));
            AssignAttri("", false, "AV113PaisId", StringUtil.LTrimStr( (decimal)(AV113PaisId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV113PaisId), 8, 0));
            AssignProp("", false, dynavPaisid_Internalname, "Values", dynavPaisid.ToJavascriptSource(), true);
         }
         if ( dynavOperadores.ItemCount > 0 )
         {
            AV118Operadores = (int)(NumberUtil.Val( dynavOperadores.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV118Operadores), 8, 0))), "."));
            AssignAttri("", false, "AV118Operadores", StringUtil.LTrimStr( (decimal)(AV118Operadores), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavOperadores.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV118Operadores), 8, 0));
            AssignProp("", false, dynavOperadores_Internalname, "Values", dynavOperadores.ToJavascriptSource(), true);
         }
         AV121DocOperadorColeta = StringUtil.StrToBool( StringUtil.BoolToStr( AV121DocOperadorColeta));
         AssignAttri("", false, "AV121DocOperadorColeta", AV121DocOperadorColeta);
         AV122DocOperadorRetencao = StringUtil.StrToBool( StringUtil.BoolToStr( AV122DocOperadorRetencao));
         AssignAttri("", false, "AV122DocOperadorRetencao", AV122DocOperadorRetencao);
         AV123DocOperadorCompartilhamento = StringUtil.StrToBool( StringUtil.BoolToStr( AV123DocOperadorCompartilhamento));
         AssignAttri("", false, "AV123DocOperadorCompartilhamento", AV123DocOperadorCompartilhamento);
         AV124DocOperadorEliminacao = StringUtil.StrToBool( StringUtil.BoolToStr( AV124DocOperadorEliminacao));
         AssignAttri("", false, "AV124DocOperadorEliminacao", AV124DocOperadorEliminacao);
         AV125DocOperadorProcessamento = StringUtil.StrToBool( StringUtil.BoolToStr( AV125DocOperadorProcessamento));
         AssignAttri("", false, "AV125DocOperadorProcessamento", AV125DocOperadorProcessamento);
         if ( cmbavDocumentoativo.ItemCount > 0 )
         {
            AV94DocumentoAtivo = StringUtil.StrToBool( cmbavDocumentoativo.getValidValue(StringUtil.BoolToStr( AV94DocumentoAtivo)));
            AssignAttri("", false, "AV94DocumentoAtivo", AV94DocumentoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocumentoativo.CurrentValue = StringUtil.BoolToStr( AV94DocumentoAtivo);
            AssignProp("", false, cmbavDocumentoativo_Internalname, "Values", cmbavDocumentoativo.ToJavascriptSource(), true);
         }
         AV109DocumentoBuscaAvancada = StringUtil.StrToBool( StringUtil.BoolToStr( AV109DocumentoBuscaAvancada));
         AssignAttri("", false, "AV109DocumentoBuscaAvancada", AV109DocumentoBuscaAvancada);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV210Pgmname = "DocumentoWW";
         context.Gx_err = 0;
         edtavBtnatualizar_Enabled = 0;
         AssignProp("", false, edtavBtnatualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnatualizar_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavBtnvisualizar_Enabled = 0;
         AssignProp("", false, edtavBtnvisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnvisualizar_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavBtnexcluir_Enabled = 0;
         AssignProp("", false, edtavBtnexcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnexcluir_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavDocumentonome_grid_Enabled = 0;
         AssignProp("", false, edtavDocumentonome_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentonome_grid_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavProcessonome_grid_Enabled = 0;
         AssignProp("", false, edtavProcessonome_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcessonome_grid_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavSubprocessonome_grid_Enabled = 0;
         AssignProp("", false, edtavSubprocessonome_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubprocessonome_grid_Enabled), 5, 0), !bGXsfl_257_Refreshing);
      }

      protected void RF5R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 257;
         /* Execute user event: Refresh */
         E195R2 ();
         nGXsfl_257_idx = 1;
         sGXsfl_257_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_257_idx), 4, 0), 4, "0");
         SubsflControlProps_2572( ) ;
         bGXsfl_257_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
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
            SubsflControlProps_2572( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(17, new Object[]{ new Object[]{
                                                 A75DocumentoId ,
                                                 AV167Documentos ,
                                                 AV27TFDocumentoId ,
                                                 AV28TFDocumentoId_To ,
                                                 AV150TFDocumentoDataInclusao ,
                                                 AV151TFDocumentoDataInclusao_To ,
                                                 AV100TFDocumentoDataAlteracao ,
                                                 AV101TFDocumentoDataAlteracao_To ,
                                                 A108DocumentoDataInclusao ,
                                                 A109DocumentoDataAlteracao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H005R19 */
            pr_default.execute(17, new Object[] {AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_257_idx = 1;
            sGXsfl_257_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_257_idx), 4, 0), 4, "0");
            SubsflControlProps_2572( ) ;
            while ( ( (pr_default.getStatus(17) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A107DocumentoProcessoNome = H005R19_A107DocumentoProcessoNome[0];
               A105DocumentoOperador = H005R19_A105DocumentoOperador[0];
               n105DocumentoOperador = H005R19_n105DocumentoOperador[0];
               A85DocumentoAtivo = H005R19_A85DocumentoAtivo[0];
               n85DocumentoAtivo = H005R19_n85DocumentoAtivo[0];
               A83DocumentoMedidaSegurancaDesc = H005R19_A83DocumentoMedidaSegurancaDesc[0];
               n83DocumentoMedidaSegurancaDesc = H005R19_n83DocumentoMedidaSegurancaDesc[0];
               A82DocumentoDadosGrupoVul = H005R19_A82DocumentoDadosGrupoVul[0];
               n82DocumentoDadosGrupoVul = H005R19_n82DocumentoDadosGrupoVul[0];
               A81DocumentoDadosCriancaAdolesc = H005R19_A81DocumentoDadosCriancaAdolesc[0];
               n81DocumentoDadosCriancaAdolesc = H005R19_n81DocumentoDadosCriancaAdolesc[0];
               A80DocumentoBaseLegalNormIntExt = H005R19_A80DocumentoBaseLegalNormIntExt[0];
               n80DocumentoBaseLegalNormIntExt = H005R19_n80DocumentoBaseLegalNormIntExt[0];
               A79DocumentoBaseLegalNorm = H005R19_A79DocumentoBaseLegalNorm[0];
               n79DocumentoBaseLegalNorm = H005R19_n79DocumentoBaseLegalNorm[0];
               A78DocumentoPrevColetaDados = H005R19_A78DocumentoPrevColetaDados[0];
               n78DocumentoPrevColetaDados = H005R19_n78DocumentoPrevColetaDados[0];
               A48TempoRetencaoId = H005R19_A48TempoRetencaoId[0];
               n48TempoRetencaoId = H005R19_n48TempoRetencaoId[0];
               A45TipoDescarteId = H005R19_A45TipoDescarteId[0];
               n45TipoDescarteId = H005R19_n45TipoDescarteId[0];
               A39FrequenciaTratamentoId = H005R19_A39FrequenciaTratamentoId[0];
               n39FrequenciaTratamentoId = H005R19_n39FrequenciaTratamentoId[0];
               A36AbrangenciaGeograficaId = H005R19_A36AbrangenciaGeograficaId[0];
               n36AbrangenciaGeograficaId = H005R19_n36AbrangenciaGeograficaId[0];
               A33FerramentaColetaId = H005R19_A33FerramentaColetaId[0];
               n33FerramentaColetaId = H005R19_n33FerramentaColetaId[0];
               A30TipoDadoId = H005R19_A30TipoDadoId[0];
               n30TipoDadoId = H005R19_n30TipoDadoId[0];
               A27CategoriaId = H005R19_A27CategoriaId[0];
               n27CategoriaId = H005R19_n27CategoriaId[0];
               A77DocumentoFinalidadeTratamento = H005R19_A77DocumentoFinalidadeTratamento[0];
               n77DocumentoFinalidadeTratamento = H005R19_n77DocumentoFinalidadeTratamento[0];
               A13PersonaId = H005R19_A13PersonaId[0];
               n13PersonaId = H005R19_n13PersonaId[0];
               A7EncarregadoId = H005R19_A7EncarregadoId[0];
               n7EncarregadoId = H005R19_n7EncarregadoId[0];
               A20SubprocessoId = H005R19_A20SubprocessoId[0];
               n20SubprocessoId = H005R19_n20SubprocessoId[0];
               A16ProcessoId = H005R19_A16ProcessoId[0];
               n16ProcessoId = H005R19_n16ProcessoId[0];
               A106DocumentoProcessoId = H005R19_A106DocumentoProcessoId[0];
               n106DocumentoProcessoId = H005R19_n106DocumentoProcessoId[0];
               A109DocumentoDataAlteracao = H005R19_A109DocumentoDataAlteracao[0];
               n109DocumentoDataAlteracao = H005R19_n109DocumentoDataAlteracao[0];
               A108DocumentoDataInclusao = H005R19_A108DocumentoDataInclusao[0];
               n108DocumentoDataInclusao = H005R19_n108DocumentoDataInclusao[0];
               A21SubprocessoNome = H005R19_A21SubprocessoNome[0];
               A17ProcessoNome = H005R19_A17ProcessoNome[0];
               A76DocumentoNome = H005R19_A76DocumentoNome[0];
               n76DocumentoNome = H005R19_n76DocumentoNome[0];
               A75DocumentoId = H005R19_A75DocumentoId[0];
               A16ProcessoId = H005R19_A16ProcessoId[0];
               n16ProcessoId = H005R19_n16ProcessoId[0];
               A21SubprocessoNome = H005R19_A21SubprocessoNome[0];
               A17ProcessoNome = H005R19_A17ProcessoNome[0];
               A107DocumentoProcessoNome = H005R19_A107DocumentoProcessoNome[0];
               E205R2 ();
               pr_default.readNext(17);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(17) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(17);
            wbEnd = 257;
            WB5R0( ) ;
         }
         bGXsfl_257_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV210Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV210Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_EXCEL", AV188IsAuthorized_Excel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXCEL", GetSecureSignedToken( "", AV188IsAuthorized_Excel, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PDF", AV189IsAuthorized_PDF);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PDF", GetSecureSignedToken( "", AV189IsAuthorized_PDF, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCUMENTOID"+"_"+sGXsfl_257_idx, GetSecureSignedToken( sGXsfl_257_idx, context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNEXCLUIR", AV192IsAuthorized_BtnExcluir);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNEXCLUIR", GetSecureSignedToken( "", AV192IsAuthorized_BtnExcluir, context));
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
         pr_default.dynParam(18, new Object[]{ new Object[]{
                                              A75DocumentoId ,
                                              AV167Documentos ,
                                              AV27TFDocumentoId ,
                                              AV28TFDocumentoId_To ,
                                              AV150TFDocumentoDataInclusao ,
                                              AV151TFDocumentoDataInclusao_To ,
                                              AV100TFDocumentoDataAlteracao ,
                                              AV101TFDocumentoDataAlteracao_To ,
                                              A108DocumentoDataInclusao ,
                                              A109DocumentoDataAlteracao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H005R20 */
         pr_default.execute(18, new Object[] {AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To});
         GRID_nRecordCount = H005R20_AGRID_nRecordCount[0];
         pr_default.close(18);
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV210Pgmname = "DocumentoWW";
         context.Gx_err = 0;
         edtavBtnatualizar_Enabled = 0;
         AssignProp("", false, edtavBtnatualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnatualizar_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavBtnvisualizar_Enabled = 0;
         AssignProp("", false, edtavBtnvisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnvisualizar_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavBtnexcluir_Enabled = 0;
         AssignProp("", false, edtavBtnexcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnexcluir_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavDocumentonome_grid_Enabled = 0;
         AssignProp("", false, edtavDocumentonome_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentonome_grid_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavProcessonome_grid_Enabled = 0;
         AssignProp("", false, edtavProcessonome_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcessonome_grid_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         edtavSubprocessonome_grid_Enabled = 0;
         AssignProp("", false, edtavSubprocessonome_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubprocessonome_grid_Enabled), 5, 0), !bGXsfl_257_Refreshing);
         GXVvDOCUMENTOPROCESSOID_html5R2( ) ;
         GXVvSUBPROCESSOID_html5R2( ) ;
         GXVvAREARESPONSAVELID_html5R2( ) ;
         GXVvDOCUMENTOCONTROLADORID_html5R2( ) ;
         GXVvENCARREGADOID_html5R2( ) ;
         GXVvPERSONAID_html5R2( ) ;
         GXVvCATEGORIAID_html5R2( ) ;
         GXVvTIPODADOID_html5R2( ) ;
         GXVvFERRAMENTACOLETAID_html5R2( ) ;
         GXVvABRANGENCIAGEOGRAFICAID_html5R2( ) ;
         GXVvFREQUENCIATRATAMENTOID_html5R2( ) ;
         GXVvTIPODESCARTEID_html5R2( ) ;
         GXVvTEMPORETENCAOID_html5R2( ) ;
         GXVvINFORMACAOID_html5R2( ) ;
         GXVvHIPOTESETRATAMENTOID_html5R2( ) ;
         GXVvPAISID_html5R2( ) ;
         GXVvOPERADORES_html5R2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E185R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV70DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_257 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_257"), ",", "."));
            AV74GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV75GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV76GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV152DDO_DocumentoDataInclusaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_DOCUMENTODATAINCLUSAOAUXDATE"), 0);
            AV153DDO_DocumentoDataInclusaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_DOCUMENTODATAINCLUSAOAUXDATETO"), 0);
            AV102DDO_DocumentoDataAlteracaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_DOCUMENTODATAALTERACAOAUXDATE"), 0);
            AV103DDO_DocumentoDataAlteracaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_DOCUMENTODATAALTERACAOAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gxuitabspanel_tabs1_Pagecount = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Dvelop_confirmpanel_btnexcluir_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Title");
            Dvelop_confirmpanel_btnexcluir_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmationtext");
            Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnexcluir_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Nobuttoncaption");
            Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnexcluir_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Yesbuttonposition");
            Dvelop_confirmpanel_btnexcluir_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Dvelop_confirmpanel_btnexcluir_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNEXCLUIR_Result");
            /* Read variables values. */
            AV88DocumentoNome = cgiGet( edtavDocumentonome_Internalname);
            AssignAttri("", false, "AV88DocumentoNome", AV88DocumentoNome);
            dynavDocumentoprocessoid.Name = dynavDocumentoprocessoid_Internalname;
            dynavDocumentoprocessoid.CurrentValue = cgiGet( dynavDocumentoprocessoid_Internalname);
            AV89DocumentoProcessoId = (int)(NumberUtil.Val( cgiGet( dynavDocumentoprocessoid_Internalname), "."));
            AssignAttri("", false, "AV89DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV89DocumentoProcessoId), 8, 0));
            dynavSubprocessoid.Name = dynavSubprocessoid_Internalname;
            dynavSubprocessoid.CurrentValue = cgiGet( dynavSubprocessoid_Internalname);
            AV90SubprocessoId = (int)(NumberUtil.Val( cgiGet( dynavSubprocessoid_Internalname), "."));
            AssignAttri("", false, "AV90SubprocessoId", StringUtil.LTrimStr( (decimal)(AV90SubprocessoId), 8, 0));
            dynavArearesponsavelid.Name = dynavArearesponsavelid_Internalname;
            dynavArearesponsavelid.CurrentValue = cgiGet( dynavArearesponsavelid_Internalname);
            AV178AreaResponsavelId = (int)(NumberUtil.Val( cgiGet( dynavArearesponsavelid_Internalname), "."));
            AssignAttri("", false, "AV178AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV178AreaResponsavelId), 8, 0));
            dynavDocumentocontroladorid.Name = dynavDocumentocontroladorid_Internalname;
            dynavDocumentocontroladorid.CurrentValue = cgiGet( dynavDocumentocontroladorid_Internalname);
            AV91DocumentoControladorId = (int)(NumberUtil.Val( cgiGet( dynavDocumentocontroladorid_Internalname), "."));
            AssignAttri("", false, "AV91DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV91DocumentoControladorId), 8, 0));
            dynavEncarregadoid.Name = dynavEncarregadoid_Internalname;
            dynavEncarregadoid.CurrentValue = cgiGet( dynavEncarregadoid_Internalname);
            AV92EncarregadoId = (int)(NumberUtil.Val( cgiGet( dynavEncarregadoid_Internalname), "."));
            AssignAttri("", false, "AV92EncarregadoId", StringUtil.LTrimStr( (decimal)(AV92EncarregadoId), 8, 0));
            dynavPersonaid.Name = dynavPersonaid_Internalname;
            dynavPersonaid.CurrentValue = cgiGet( dynavPersonaid_Internalname);
            AV144PersonaId = (int)(NumberUtil.Val( cgiGet( dynavPersonaid_Internalname), "."));
            AssignAttri("", false, "AV144PersonaId", StringUtil.LTrimStr( (decimal)(AV144PersonaId), 8, 0));
            cmbavDocumentosituacao.Name = cmbavDocumentosituacao_Internalname;
            cmbavDocumentosituacao.CurrentValue = cgiGet( cmbavDocumentosituacao_Internalname);
            AV93DocumentoSituacao = (short)(NumberUtil.Val( cgiGet( cmbavDocumentosituacao_Internalname), "."));
            AssignAttri("", false, "AV93DocumentoSituacao", StringUtil.LTrimStr( (decimal)(AV93DocumentoSituacao), 4, 0));
            AV126DocumentoFinalidadeTratamento = cgiGet( edtavDocumentofinalidadetratamento_Internalname);
            AssignAttri("", false, "AV126DocumentoFinalidadeTratamento", AV126DocumentoFinalidadeTratamento);
            dynavCategoriaid.Name = dynavCategoriaid_Internalname;
            dynavCategoriaid.CurrentValue = cgiGet( dynavCategoriaid_Internalname);
            AV129CategoriaId = (int)(NumberUtil.Val( cgiGet( dynavCategoriaid_Internalname), "."));
            AssignAttri("", false, "AV129CategoriaId", StringUtil.LTrimStr( (decimal)(AV129CategoriaId), 8, 0));
            dynavTipodadoid.Name = dynavTipodadoid_Internalname;
            dynavTipodadoid.CurrentValue = cgiGet( dynavTipodadoid_Internalname);
            AV130TipoDadoId = (int)(NumberUtil.Val( cgiGet( dynavTipodadoid_Internalname), "."));
            AssignAttri("", false, "AV130TipoDadoId", StringUtil.LTrimStr( (decimal)(AV130TipoDadoId), 8, 0));
            dynavFerramentacoletaid.Name = dynavFerramentacoletaid_Internalname;
            dynavFerramentacoletaid.CurrentValue = cgiGet( dynavFerramentacoletaid_Internalname);
            AV127FerramentaColetaId = (int)(NumberUtil.Val( cgiGet( dynavFerramentacoletaid_Internalname), "."));
            AssignAttri("", false, "AV127FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV127FerramentaColetaId), 8, 0));
            dynavAbrangenciageograficaid.Name = dynavAbrangenciageograficaid_Internalname;
            dynavAbrangenciageograficaid.CurrentValue = cgiGet( dynavAbrangenciageograficaid_Internalname);
            AV128AbrangenciaGeograficaId = (int)(NumberUtil.Val( cgiGet( dynavAbrangenciageograficaid_Internalname), "."));
            AssignAttri("", false, "AV128AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV128AbrangenciaGeograficaId), 8, 0));
            dynavFrequenciatratamentoid.Name = dynavFrequenciatratamentoid_Internalname;
            dynavFrequenciatratamentoid.CurrentValue = cgiGet( dynavFrequenciatratamentoid_Internalname);
            AV131FrequenciaTratamentoId = (int)(NumberUtil.Val( cgiGet( dynavFrequenciatratamentoid_Internalname), "."));
            AssignAttri("", false, "AV131FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV131FrequenciaTratamentoId), 8, 0));
            dynavTipodescarteid.Name = dynavTipodescarteid_Internalname;
            dynavTipodescarteid.CurrentValue = cgiGet( dynavTipodescarteid_Internalname);
            AV133TipoDescarteId = (int)(NumberUtil.Val( cgiGet( dynavTipodescarteid_Internalname), "."));
            AssignAttri("", false, "AV133TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV133TipoDescarteId), 8, 0));
            dynavTemporetencaoid.Name = dynavTemporetencaoid_Internalname;
            dynavTemporetencaoid.CurrentValue = cgiGet( dynavTemporetencaoid_Internalname);
            AV134TempoRetencaoId = (int)(NumberUtil.Val( cgiGet( dynavTemporetencaoid_Internalname), "."));
            AssignAttri("", false, "AV134TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV134TempoRetencaoId), 8, 0));
            AV132DocumentoPrevColetaDados = StringUtil.StrToBool( cgiGet( chkavDocumentoprevcoletadados_Internalname));
            AssignAttri("", false, "AV132DocumentoPrevColetaDados", AV132DocumentoPrevColetaDados);
            AV135DocumentoBaseLegalNorm = cgiGet( edtavDocumentobaselegalnorm_Internalname);
            AssignAttri("", false, "AV135DocumentoBaseLegalNorm", AV135DocumentoBaseLegalNorm);
            AV136DocumentoBaseLegalNormIntExt = cgiGet( edtavDocumentobaselegalnormintext_Internalname);
            AssignAttri("", false, "AV136DocumentoBaseLegalNormIntExt", AV136DocumentoBaseLegalNormIntExt);
            AV138DocumentoDadosGrupoVul = StringUtil.StrToBool( cgiGet( chkavDocumentodadosgrupovul_Internalname));
            AssignAttri("", false, "AV138DocumentoDadosGrupoVul", AV138DocumentoDadosGrupoVul);
            AV139DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( cgiGet( chkavDocumentodadoscriancaadolesc_Internalname));
            AssignAttri("", false, "AV139DocumentoDadosCriancaAdolesc", AV139DocumentoDadosCriancaAdolesc);
            dynavInformacaoid.Name = dynavInformacaoid_Internalname;
            dynavInformacaoid.CurrentValue = cgiGet( dynavInformacaoid_Internalname);
            AV110InformacaoId = (int)(NumberUtil.Val( cgiGet( dynavInformacaoid_Internalname), "."));
            AssignAttri("", false, "AV110InformacaoId", StringUtil.LTrimStr( (decimal)(AV110InformacaoId), 8, 0));
            AV116DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkavDocdicionariosensivel_Internalname));
            AssignAttri("", false, "AV116DocDicionarioSensivel", AV116DocDicionarioSensivel);
            AV117DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkavDocdicionariopodeeliminar_Internalname));
            AssignAttri("", false, "AV117DocDicionarioPodeEliminar", AV117DocDicionarioPodeEliminar);
            dynavHipotesetratamentoid.Name = dynavHipotesetratamentoid_Internalname;
            dynavHipotesetratamentoid.CurrentValue = cgiGet( dynavHipotesetratamentoid_Internalname);
            AV111HipoteseTratamentoId = (int)(NumberUtil.Val( cgiGet( dynavHipotesetratamentoid_Internalname), "."));
            AssignAttri("", false, "AV111HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV111HipoteseTratamentoId), 8, 0));
            cmbavDocdicionariotransfinter.Name = cmbavDocdicionariotransfinter_Internalname;
            cmbavDocdicionariotransfinter.CurrentValue = cgiGet( cmbavDocdicionariotransfinter_Internalname);
            AV168DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( cmbavDocdicionariotransfinter_Internalname));
            AssignAttri("", false, "AV168DocDicionarioTransfInter", AV168DocDicionarioTransfInter);
            dynavPaisid.Name = dynavPaisid_Internalname;
            dynavPaisid.CurrentValue = cgiGet( dynavPaisid_Internalname);
            AV113PaisId = (int)(NumberUtil.Val( cgiGet( dynavPaisid_Internalname), "."));
            AssignAttri("", false, "AV113PaisId", StringUtil.LTrimStr( (decimal)(AV113PaisId), 8, 0));
            AV155DocDicionarioTipoTransfInterGarantia = cgiGet( edtavDocdicionariotipotransfintergarantia_Internalname);
            AssignAttri("", false, "AV155DocDicionarioTipoTransfInterGarantia", AV155DocDicionarioTipoTransfInterGarantia);
            AV156DocDicionarioFinalidade = cgiGet( edtavDocdicionariofinalidade_Internalname);
            AssignAttri("", false, "AV156DocDicionarioFinalidade", AV156DocDicionarioFinalidade);
            dynavOperadores.Name = dynavOperadores_Internalname;
            dynavOperadores.CurrentValue = cgiGet( dynavOperadores_Internalname);
            AV118Operadores = (int)(NumberUtil.Val( cgiGet( dynavOperadores_Internalname), "."));
            AssignAttri("", false, "AV118Operadores", StringUtil.LTrimStr( (decimal)(AV118Operadores), 8, 0));
            AV121DocOperadorColeta = StringUtil.StrToBool( cgiGet( chkavDocoperadorcoleta_Internalname));
            AssignAttri("", false, "AV121DocOperadorColeta", AV121DocOperadorColeta);
            AV122DocOperadorRetencao = StringUtil.StrToBool( cgiGet( chkavDocoperadorretencao_Internalname));
            AssignAttri("", false, "AV122DocOperadorRetencao", AV122DocOperadorRetencao);
            AV123DocOperadorCompartilhamento = StringUtil.StrToBool( cgiGet( chkavDocoperadorcompartilhamento_Internalname));
            AssignAttri("", false, "AV123DocOperadorCompartilhamento", AV123DocOperadorCompartilhamento);
            AV124DocOperadorEliminacao = StringUtil.StrToBool( cgiGet( chkavDocoperadoreliminacao_Internalname));
            AssignAttri("", false, "AV124DocOperadorEliminacao", AV124DocOperadorEliminacao);
            AV125DocOperadorProcessamento = StringUtil.StrToBool( cgiGet( chkavDocoperadorprocessamento_Internalname));
            AssignAttri("", false, "AV125DocOperadorProcessamento", AV125DocOperadorProcessamento);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentoid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOID");
               GX_FocusControl = edtavDocumentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV95DocumentoId = 0;
               AssignAttri("", false, "AV95DocumentoId", StringUtil.LTrimStr( (decimal)(AV95DocumentoId), 8, 0));
            }
            else
            {
               AV95DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtavDocumentoid_Internalname), ",", "."));
               AssignAttri("", false, "AV95DocumentoId", StringUtil.LTrimStr( (decimal)(AV95DocumentoId), 8, 0));
            }
            cmbavDocumentoativo.Name = cmbavDocumentoativo_Internalname;
            cmbavDocumentoativo.CurrentValue = cgiGet( cmbavDocumentoativo_Internalname);
            AV94DocumentoAtivo = StringUtil.StrToBool( cgiGet( cmbavDocumentoativo_Internalname));
            AssignAttri("", false, "AV94DocumentoAtivo", AV94DocumentoAtivo);
            AV109DocumentoBuscaAvancada = StringUtil.StrToBool( cgiGet( chkavDocumentobuscaavancada_Internalname));
            AssignAttri("", false, "AV109DocumentoBuscaAvancada", AV109DocumentoBuscaAvancada);
            AV154DDO_DocumentoDataInclusaoAuxDateText = cgiGet( edtavDdo_documentodatainclusaoauxdatetext_Internalname);
            AssignAttri("", false, "AV154DDO_DocumentoDataInclusaoAuxDateText", AV154DDO_DocumentoDataInclusaoAuxDateText);
            AV104DDO_DocumentoDataAlteracaoAuxDateText = cgiGet( edtavDdo_documentodataalteracaoauxdatetext_Internalname);
            AssignAttri("", false, "AV104DDO_DocumentoDataAlteracaoAuxDateText", AV104DDO_DocumentoDataAlteracaoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E185R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E185R2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFDOCUMENTODATAALTERACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_documentodataalteracaoauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFDOCUMENTODATAINCLUSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_documentodatainclusaoauxdatetext_Internalname});
         edtavDocumentoid_Visible = 0;
         AssignProp("", false, edtavDocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Visible), 5, 0), true);
         cmbavDocumentoativo.Visible = 0;
         AssignProp("", false, cmbavDocumentoativo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDocumentoativo.Visible), 5, 0), true);
         chkavDocumentobuscaavancada.Visible = 0;
         AssignProp("", false, chkavDocumentobuscaavancada_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavDocumentobuscaavancada.Visible), 5, 0), true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Documento";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV70DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV70DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV13OrderedBy = 1;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = true;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblBtnbuscaavancada_Caption = "<i class=\"FontColorIcon fas fa-toggle-off\"></i>";
         AssignProp("", false, lblBtnbuscaavancada_Internalname, "Caption", lblBtnbuscaavancada_Caption, true);
         AV109DocumentoBuscaAvancada = false;
         AssignAttri("", false, "AV109DocumentoBuscaAvancada", AV109DocumentoBuscaAvancada);
         divTablebuscaavancada_Visible = 0;
         AssignProp("", false, divTablebuscaavancada_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablebuscaavancada_Visible), 5, 0), true);
      }

      protected void E195R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new filtrarconsultadoc(context ).execute(  AV166FiltrosDocumento,  AV109DocumentoBuscaAvancada, out  AV167Documentos) ;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV74GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV74GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV74GridCurrentPage), 10, 0));
         AV75GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV75GridPageCount", StringUtil.LTrimStr( (decimal)(AV75GridPageCount), 10, 0));
         GXt_char2 = AV76GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV210Pgmname, out  GXt_char2) ;
         AV76GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV76GridAppliedFilters", AV76GridAppliedFilters);
         cmbavGridactiongroup1_Columnheaderclass = "WWActionGroupColumn";
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Columnheaderclass", cmbavGridactiongroup1_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtavBtnatualizar_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavBtnatualizar_Internalname, "Columnheaderclass", edtavBtnatualizar_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtavBtnvisualizar_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavBtnvisualizar_Internalname, "Columnheaderclass", edtavBtnvisualizar_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtavBtnexcluir_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavBtnexcluir_Internalname, "Columnheaderclass", edtavBtnexcluir_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtDocumentoId_Columnheaderclass = "WWColumn CellMarginLeft";
         AssignProp("", false, edtDocumentoId_Internalname, "Columnheaderclass", edtDocumentoId_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtavDocumentonome_grid_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavDocumentonome_grid_Internalname, "Columnheaderclass", edtavDocumentonome_grid_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtavProcessonome_grid_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavProcessonome_grid_Internalname, "Columnheaderclass", edtavProcessonome_grid_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtavSubprocessonome_grid_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavSubprocessonome_grid_Internalname, "Columnheaderclass", edtavSubprocessonome_grid_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtDocumentoDataInclusao_Columnheaderclass = "WWColumn CellMarginLeft hidden-xs";
         AssignProp("", false, edtDocumentoDataInclusao_Internalname, "Columnheaderclass", edtDocumentoDataInclusao_Columnheaderclass, !bGXsfl_257_Refreshing);
         edtDocumentoDataAlteracao_Columnheaderclass = "WWColumn CellMarginLeft hidden-xs";
         AssignProp("", false, edtDocumentoDataAlteracao_Internalname, "Columnheaderclass", edtDocumentoDataAlteracao_Columnheaderclass, !bGXsfl_257_Refreshing);
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-list", 0);
         if ( AV188IsAuthorized_Excel )
         {
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Relatório Excel", "FontColorIcon3 far fa-file-excel", "", "", "", "", "", "", ""), 0);
         }
         if ( AV189IsAuthorized_PDF )
         {
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Relatório PDF", "FontColorIcon3 far fa-file-pdf", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavGridactiongroup1.ItemCount == 1 )
         {
            cmbavGridactiongroup1_Class = "Invisible";
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Class", cmbavGridactiongroup1_Class, !bGXsfl_257_Refreshing);
         }
         else
         {
            cmbavGridactiongroup1_Class = "ConvertToDDO";
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Class", cmbavGridactiongroup1_Class, !bGXsfl_257_Refreshing);
         }
         AV149BtnAtualizar = "<i class=\"fas fa-pen\"></i>";
         AssignAttri("", false, edtavBtnatualizar_Internalname, AV149BtnAtualizar);
         AV148BtnVisualizar = "<i class=\"fas fa-magnifying-glass\"></i>";
         AssignAttri("", false, edtavBtnvisualizar_Internalname, AV148BtnVisualizar);
         AV180BtnExcluir = "<i class=\"fas fa-xmark\"></i>";
         AssignAttri("", false, edtavBtnexcluir_Internalname, AV180BtnExcluir);
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E115R2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV73PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV73PageToGo) ;
         }
      }

      protected void E125R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E135R2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
            {
               AV13OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoId") == 0 )
               {
                  AV27TFDocumentoId = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
                  AssignAttri("", false, "AV27TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV27TFDocumentoId), 8, 0));
                  AV28TFDocumentoId_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
                  AssignAttri("", false, "AV28TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocumentoId_To), 8, 0));
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoDataInclusao") == 0 )
               {
                  AV150TFDocumentoDataInclusao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
                  AssignAttri("", false, "AV150TFDocumentoDataInclusao", context.localUtil.TToC( AV150TFDocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
                  AV151TFDocumentoDataInclusao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
                  AssignAttri("", false, "AV151TFDocumentoDataInclusao_To", context.localUtil.TToC( AV151TFDocumentoDataInclusao_To, 8, 5, 0, 3, "/", ":", " "));
                  if ( ! (DateTime.MinValue==AV151TFDocumentoDataInclusao_To) )
                  {
                     AV151TFDocumentoDataInclusao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV151TFDocumentoDataInclusao_To)), (short)(DateTimeUtil.Month( AV151TFDocumentoDataInclusao_To)), (short)(DateTimeUtil.Day( AV151TFDocumentoDataInclusao_To)), 23, 59, 59);
                     AssignAttri("", false, "AV151TFDocumentoDataInclusao_To", context.localUtil.TToC( AV151TFDocumentoDataInclusao_To, 8, 5, 0, 3, "/", ":", " "));
                  }
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentoDataAlteracao") == 0 )
               {
                  AV100TFDocumentoDataAlteracao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
                  AssignAttri("", false, "AV100TFDocumentoDataAlteracao", context.localUtil.TToC( AV100TFDocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
                  AV101TFDocumentoDataAlteracao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
                  AssignAttri("", false, "AV101TFDocumentoDataAlteracao_To", context.localUtil.TToC( AV101TFDocumentoDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
                  if ( ! (DateTime.MinValue==AV101TFDocumentoDataAlteracao_To) )
                  {
                     AV101TFDocumentoDataAlteracao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV101TFDocumentoDataAlteracao_To)), (short)(DateTimeUtil.Month( AV101TFDocumentoDataAlteracao_To)), (short)(DateTimeUtil.Day( AV101TFDocumentoDataAlteracao_To)), 23, 59, 59);
                     AssignAttri("", false, "AV101TFDocumentoDataAlteracao_To", context.localUtil.TToC( AV101TFDocumentoDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
                  }
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
      }

      private void E205R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV205DocumentoNome_Grid = StringUtil.Substring( A76DocumentoNome, 1, 20);
         AssignAttri("", false, edtavDocumentonome_grid_Internalname, AV205DocumentoNome_Grid);
         if ( StringUtil.Len( A76DocumentoNome) > 20 )
         {
            AV205DocumentoNome_Grid += "...";
            AssignAttri("", false, edtavDocumentonome_grid_Internalname, AV205DocumentoNome_Grid);
         }
         AV206ProcessoNome_Grid = StringUtil.Substring( A107DocumentoProcessoNome, 1, 20);
         AssignAttri("", false, edtavProcessonome_grid_Internalname, AV206ProcessoNome_Grid);
         if ( StringUtil.Len( A107DocumentoProcessoNome) > 20 )
         {
            AV206ProcessoNome_Grid += "...";
            AssignAttri("", false, edtavProcessonome_grid_Internalname, AV206ProcessoNome_Grid);
         }
         AV207SubprocessoNome_Grid = StringUtil.Substring( A21SubprocessoNome, 1, 20);
         AssignAttri("", false, edtavSubprocessonome_grid_Internalname, AV207SubprocessoNome_Grid);
         if ( StringUtil.Len( A21SubprocessoNome) > 20 )
         {
            AV207SubprocessoNome_Grid += "...";
            AssignAttri("", false, edtavSubprocessonome_grid_Internalname, AV207SubprocessoNome_Grid);
         }
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-list", 0);
         if ( AV188IsAuthorized_Excel )
         {
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Relatório Excel", "FontColorIcon3 far fa-file-excel", "", "", "", "", "", "", ""), 0);
         }
         if ( AV189IsAuthorized_PDF )
         {
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Relatório PDF", "FontColorIcon3 far fa-file-pdf", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavGridactiongroup1.ItemCount == 1 )
         {
            cmbavGridactiongroup1_Class = "Invisible";
         }
         else
         {
            cmbavGridactiongroup1_Class = "ConvertToDDO";
         }
         AV149BtnAtualizar = "<i class=\"fas fa-pen\"></i>";
         AssignAttri("", false, edtavBtnatualizar_Internalname, AV149BtnAtualizar);
         AV148BtnVisualizar = "<i class=\"fas fa-magnifying-glass\"></i>";
         AssignAttri("", false, edtavBtnvisualizar_Internalname, AV148BtnVisualizar);
         AV180BtnExcluir = "<i class=\"fas fa-xmark\"></i>";
         AssignAttri("", false, edtavBtnexcluir_Internalname, AV180BtnExcluir);
         if ( A85DocumentoAtivo )
         {
            cmbavGridactiongroup1_Columnclass = "WWActionGroupColumn WWColumnSuccess WWColumnSuccessFirstColumn";
            edtavBtnatualizar_Columnclass = "WWIconActionColumn WWColumnSuccess";
            edtavBtnvisualizar_Columnclass = "WWIconActionColumn WWColumnSuccess";
            edtavBtnexcluir_Columnclass = "WWIconActionColumn WWColumnSuccess";
            edtDocumentoId_Columnclass = "WWColumn WWColumnSuccess CellMarginLeft";
            edtavDocumentonome_grid_Columnclass = "WWColumn WWColumnSuccess";
            edtavProcessonome_grid_Columnclass = "WWColumn WWColumnSuccess";
            edtavSubprocessonome_grid_Columnclass = "WWColumn WWColumnSuccess";
            edtDocumentoDataInclusao_Columnclass = "WWColumn WWColumnSuccess CellMarginLeft hidden-xs";
            edtDocumentoDataAlteracao_Columnclass = "WWColumn WWColumnSuccess CellMarginLeft hidden-xs";
         }
         else if ( ! A85DocumentoAtivo )
         {
            cmbavGridactiongroup1_Columnclass = "WWActionGroupColumn WWColumnDanger WWColumnDangerFirstColumn";
            edtavBtnatualizar_Columnclass = "WWIconActionColumn WWColumnDanger";
            edtavBtnvisualizar_Columnclass = "WWIconActionColumn WWColumnDanger";
            edtavBtnexcluir_Columnclass = "WWIconActionColumn WWColumnDanger";
            edtDocumentoId_Columnclass = "WWColumn WWColumnDanger CellMarginLeft";
            edtavDocumentonome_grid_Columnclass = "WWColumn WWColumnDanger";
            edtavProcessonome_grid_Columnclass = "WWColumn WWColumnDanger";
            edtavSubprocessonome_grid_Columnclass = "WWColumn WWColumnDanger";
            edtDocumentoDataInclusao_Columnclass = "WWColumn WWColumnDanger CellMarginLeft hidden-xs";
            edtDocumentoDataAlteracao_Columnclass = "WWColumn WWColumnDanger CellMarginLeft hidden-xs";
         }
         else
         {
            cmbavGridactiongroup1_Columnclass = "WWActionGroupColumn";
            edtavBtnatualizar_Columnclass = "WWIconActionColumn";
            edtavBtnvisualizar_Columnclass = "WWIconActionColumn";
            edtavBtnexcluir_Columnclass = "WWIconActionColumn";
            edtDocumentoId_Columnclass = "WWColumn CellMarginLeft";
            edtavDocumentonome_grid_Columnclass = "WWColumn";
            edtavProcessonome_grid_Columnclass = "WWColumn";
            edtavSubprocessonome_grid_Columnclass = "WWColumn";
            edtDocumentoDataInclusao_Columnclass = "WWColumn CellMarginLeft hidden-xs";
            edtDocumentoDataAlteracao_Columnclass = "WWColumn CellMarginLeft hidden-xs";
         }
         edtavDocumentonome_grid_Tooltiptext = A76DocumentoNome;
         edtavProcessonome_grid_Tooltiptext = A107DocumentoProcessoNome;
         edtavSubprocessonome_grid_Tooltiptext = A21SubprocessoNome;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 257;
         }
         sendrow_2572( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_257_Refreshing )
         {
            context.DoAjaxLoad(257, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
      }

      protected void E215R2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV179GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO EXCEL' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV179GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO PDF' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV179GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV179GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E225R2( )
      {
         /* Btnexcluir_Click Routine */
         returnInSub = false;
         if ( AV192IsAuthorized_BtnExcluir )
         {
            AV181DocumentoId_Selected = A75DocumentoId;
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_BTNEXCLUIRContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E145R2( )
      {
         /* Dvelop_confirmpanel_btnexcluir_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnexcluir_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO BTNEXCLUIR' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E155R2( )
      {
         /* 'DoBtnBuscar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'FILTRA' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV166FiltrosDocumento", AV166FiltrosDocumento);
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E165R2( )
      {
         /* 'DoBtnLimpar' Routine */
         returnInSub = false;
         AV88DocumentoNome = "";
         AssignAttri("", false, "AV88DocumentoNome", AV88DocumentoNome);
         AV89DocumentoProcessoId = 0;
         AssignAttri("", false, "AV89DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV89DocumentoProcessoId), 8, 0));
         AV90SubprocessoId = 0;
         AssignAttri("", false, "AV90SubprocessoId", StringUtil.LTrimStr( (decimal)(AV90SubprocessoId), 8, 0));
         AV92EncarregadoId = 0;
         AssignAttri("", false, "AV92EncarregadoId", StringUtil.LTrimStr( (decimal)(AV92EncarregadoId), 8, 0));
         AV178AreaResponsavelId = 0;
         AssignAttri("", false, "AV178AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV178AreaResponsavelId), 8, 0));
         AV91DocumentoControladorId = 0;
         AssignAttri("", false, "AV91DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV91DocumentoControladorId), 8, 0));
         AV144PersonaId = 0;
         AssignAttri("", false, "AV144PersonaId", StringUtil.LTrimStr( (decimal)(AV144PersonaId), 8, 0));
         AV93DocumentoSituacao = 0;
         AssignAttri("", false, "AV93DocumentoSituacao", StringUtil.LTrimStr( (decimal)(AV93DocumentoSituacao), 4, 0));
         AV126DocumentoFinalidadeTratamento = "";
         AssignAttri("", false, "AV126DocumentoFinalidadeTratamento", AV126DocumentoFinalidadeTratamento);
         AV129CategoriaId = 0;
         AssignAttri("", false, "AV129CategoriaId", StringUtil.LTrimStr( (decimal)(AV129CategoriaId), 8, 0));
         AV130TipoDadoId = 0;
         AssignAttri("", false, "AV130TipoDadoId", StringUtil.LTrimStr( (decimal)(AV130TipoDadoId), 8, 0));
         AV127FerramentaColetaId = 0;
         AssignAttri("", false, "AV127FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV127FerramentaColetaId), 8, 0));
         AV128AbrangenciaGeograficaId = 0;
         AssignAttri("", false, "AV128AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV128AbrangenciaGeograficaId), 8, 0));
         AV131FrequenciaTratamentoId = 0;
         AssignAttri("", false, "AV131FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV131FrequenciaTratamentoId), 8, 0));
         AV133TipoDescarteId = 0;
         AssignAttri("", false, "AV133TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV133TipoDescarteId), 8, 0));
         AV134TempoRetencaoId = 0;
         AssignAttri("", false, "AV134TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV134TempoRetencaoId), 8, 0));
         AV132DocumentoPrevColetaDados = false;
         AssignAttri("", false, "AV132DocumentoPrevColetaDados", AV132DocumentoPrevColetaDados);
         AV135DocumentoBaseLegalNorm = "";
         AssignAttri("", false, "AV135DocumentoBaseLegalNorm", AV135DocumentoBaseLegalNorm);
         AV136DocumentoBaseLegalNormIntExt = "";
         AssignAttri("", false, "AV136DocumentoBaseLegalNormIntExt", AV136DocumentoBaseLegalNormIntExt);
         AV138DocumentoDadosGrupoVul = false;
         AssignAttri("", false, "AV138DocumentoDadosGrupoVul", AV138DocumentoDadosGrupoVul);
         AV139DocumentoDadosCriancaAdolesc = false;
         AssignAttri("", false, "AV139DocumentoDadosCriancaAdolesc", AV139DocumentoDadosCriancaAdolesc);
         AV110InformacaoId = 0;
         AssignAttri("", false, "AV110InformacaoId", StringUtil.LTrimStr( (decimal)(AV110InformacaoId), 8, 0));
         AV116DocDicionarioSensivel = false;
         AssignAttri("", false, "AV116DocDicionarioSensivel", AV116DocDicionarioSensivel);
         AV117DocDicionarioPodeEliminar = false;
         AssignAttri("", false, "AV117DocDicionarioPodeEliminar", AV117DocDicionarioPodeEliminar);
         AV111HipoteseTratamentoId = 0;
         AssignAttri("", false, "AV111HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV111HipoteseTratamentoId), 8, 0));
         AV168DocDicionarioTransfInter = false;
         AssignAttri("", false, "AV168DocDicionarioTransfInter", AV168DocDicionarioTransfInter);
         AV113PaisId = 0;
         AssignAttri("", false, "AV113PaisId", StringUtil.LTrimStr( (decimal)(AV113PaisId), 8, 0));
         AV112CompartTercExternoId = 0;
         AV169DocumentoOperador = false;
         AV118Operadores = 0;
         AssignAttri("", false, "AV118Operadores", StringUtil.LTrimStr( (decimal)(AV118Operadores), 8, 0));
         AV121DocOperadorColeta = false;
         AssignAttri("", false, "AV121DocOperadorColeta", AV121DocOperadorColeta);
         AV122DocOperadorRetencao = false;
         AssignAttri("", false, "AV122DocOperadorRetencao", AV122DocOperadorRetencao);
         AV123DocOperadorCompartilhamento = false;
         AssignAttri("", false, "AV123DocOperadorCompartilhamento", AV123DocOperadorCompartilhamento);
         AV124DocOperadorEliminacao = false;
         AssignAttri("", false, "AV124DocOperadorEliminacao", AV124DocOperadorEliminacao);
         AV125DocOperadorProcessamento = false;
         AssignAttri("", false, "AV125DocOperadorProcessamento", AV125DocOperadorProcessamento);
         /* Execute user subroutine: 'FILTRA' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new filtrarconsultadoc(context ).execute(  AV166FiltrosDocumento,  false, out  AV167Documentos) ;
         /*  Sending Event outputs  */
         dynavDocumentoprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89DocumentoProcessoId), 8, 0));
         AssignProp("", false, dynavDocumentoprocessoid_Internalname, "Values", dynavDocumentoprocessoid.ToJavascriptSource(), true);
         dynavSubprocessoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV90SubprocessoId), 8, 0));
         AssignProp("", false, dynavSubprocessoid_Internalname, "Values", dynavSubprocessoid.ToJavascriptSource(), true);
         dynavEncarregadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92EncarregadoId), 8, 0));
         AssignProp("", false, dynavEncarregadoid_Internalname, "Values", dynavEncarregadoid.ToJavascriptSource(), true);
         dynavArearesponsavelid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV178AreaResponsavelId), 8, 0));
         AssignProp("", false, dynavArearesponsavelid_Internalname, "Values", dynavArearesponsavelid.ToJavascriptSource(), true);
         dynavDocumentocontroladorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV91DocumentoControladorId), 8, 0));
         AssignProp("", false, dynavDocumentocontroladorid_Internalname, "Values", dynavDocumentocontroladorid.ToJavascriptSource(), true);
         dynavPersonaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV144PersonaId), 8, 0));
         AssignProp("", false, dynavPersonaid_Internalname, "Values", dynavPersonaid.ToJavascriptSource(), true);
         cmbavDocumentosituacao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93DocumentoSituacao), 4, 0));
         AssignProp("", false, cmbavDocumentosituacao_Internalname, "Values", cmbavDocumentosituacao.ToJavascriptSource(), true);
         dynavCategoriaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV129CategoriaId), 8, 0));
         AssignProp("", false, dynavCategoriaid_Internalname, "Values", dynavCategoriaid.ToJavascriptSource(), true);
         dynavTipodadoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV130TipoDadoId), 8, 0));
         AssignProp("", false, dynavTipodadoid_Internalname, "Values", dynavTipodadoid.ToJavascriptSource(), true);
         dynavFerramentacoletaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV127FerramentaColetaId), 8, 0));
         AssignProp("", false, dynavFerramentacoletaid_Internalname, "Values", dynavFerramentacoletaid.ToJavascriptSource(), true);
         dynavAbrangenciageograficaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV128AbrangenciaGeograficaId), 8, 0));
         AssignProp("", false, dynavAbrangenciageograficaid_Internalname, "Values", dynavAbrangenciageograficaid.ToJavascriptSource(), true);
         dynavFrequenciatratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV131FrequenciaTratamentoId), 8, 0));
         AssignProp("", false, dynavFrequenciatratamentoid_Internalname, "Values", dynavFrequenciatratamentoid.ToJavascriptSource(), true);
         dynavTipodescarteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV133TipoDescarteId), 8, 0));
         AssignProp("", false, dynavTipodescarteid_Internalname, "Values", dynavTipodescarteid.ToJavascriptSource(), true);
         dynavTemporetencaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV134TempoRetencaoId), 8, 0));
         AssignProp("", false, dynavTemporetencaoid_Internalname, "Values", dynavTemporetencaoid.ToJavascriptSource(), true);
         dynavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV110InformacaoId), 8, 0));
         AssignProp("", false, dynavInformacaoid_Internalname, "Values", dynavInformacaoid.ToJavascriptSource(), true);
         dynavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV111HipoteseTratamentoId), 8, 0));
         AssignProp("", false, dynavHipotesetratamentoid_Internalname, "Values", dynavHipotesetratamentoid.ToJavascriptSource(), true);
         cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV168DocDicionarioTransfInter);
         AssignProp("", false, cmbavDocdicionariotransfinter_Internalname, "Values", cmbavDocdicionariotransfinter.ToJavascriptSource(), true);
         dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV113PaisId), 8, 0));
         AssignProp("", false, dynavPaisid_Internalname, "Values", dynavPaisid.ToJavascriptSource(), true);
         dynavOperadores.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV118Operadores), 8, 0));
         AssignProp("", false, dynavOperadores_Internalname, "Values", dynavOperadores.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV166FiltrosDocumento", AV166FiltrosDocumento);
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E175R2( )
      {
         /* 'DoBtnInserir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "documentocadastrowp.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV188IsAuthorized_Excel;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "DocumentoGeraExcel", out  GXt_boolean3) ;
         AV188IsAuthorized_Excel = GXt_boolean3;
         AssignAttri("", false, "AV188IsAuthorized_Excel", AV188IsAuthorized_Excel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXCEL", GetSecureSignedToken( "", AV188IsAuthorized_Excel, context));
         GXt_boolean3 = AV189IsAuthorized_PDF;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "DocumentoGeraPDF", out  GXt_boolean3) ;
         AV189IsAuthorized_PDF = GXt_boolean3;
         AssignAttri("", false, "AV189IsAuthorized_PDF", AV189IsAuthorized_PDF);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PDF", GetSecureSignedToken( "", AV189IsAuthorized_PDF, context));
         GXt_boolean3 = AV190IsAuthorized_BtnAtualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "DocumentoAtualiza", out  GXt_boolean3) ;
         AV190IsAuthorized_BtnAtualizar = GXt_boolean3;
         if ( ! ( AV190IsAuthorized_BtnAtualizar ) )
         {
            edtavBtnatualizar_Visible = 0;
            AssignProp("", false, edtavBtnatualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnatualizar_Visible), 5, 0), !bGXsfl_257_Refreshing);
         }
         GXt_boolean3 = AV191IsAuthorized_BtnVisualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "DocumentoVisualiza", out  GXt_boolean3) ;
         AV191IsAuthorized_BtnVisualizar = GXt_boolean3;
         if ( ! ( AV191IsAuthorized_BtnVisualizar ) )
         {
            edtavBtnvisualizar_Visible = 0;
            AssignProp("", false, edtavBtnvisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnvisualizar_Visible), 5, 0), !bGXsfl_257_Refreshing);
         }
         GXt_boolean3 = AV192IsAuthorized_BtnExcluir;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "DocumentoExclui", out  GXt_boolean3) ;
         AV192IsAuthorized_BtnExcluir = GXt_boolean3;
         AssignAttri("", false, "AV192IsAuthorized_BtnExcluir", AV192IsAuthorized_BtnExcluir);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNEXCLUIR", GetSecureSignedToken( "", AV192IsAuthorized_BtnExcluir, context));
         if ( ! ( AV192IsAuthorized_BtnExcluir ) )
         {
            edtavBtnexcluir_Visible = 0;
            AssignProp("", false, edtavBtnexcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnexcluir_Visible), 5, 0), !bGXsfl_257_Refreshing);
         }
      }

      protected void S162( )
      {
         /* 'DO EXCEL' Routine */
         returnInSub = false;
         new documentorelatorioexcel(context ).execute(  A75DocumentoId, out  AV171FileName, out  AV177Caminho) ;
         AV175ContentType = "application/excel";
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "adownloadarquivo.aspx"+UrlEncode(StringUtil.RTrim(AV175ContentType)) + "," + UrlEncode(StringUtil.RTrim(AV177Caminho)) + "," + UrlEncode(StringUtil.RTrim(AV171FileName));
         CallWebObject(formatLink("adownloadarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 2;
         context.DoAjaxRefresh();
      }

      protected void S172( )
      {
         /* 'DO PDF' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "adocumentorelatoriopdf.aspx"+UrlEncode(StringUtil.LTrimStr(A75DocumentoId,8,0));
         this.executeExternalObjectMethod("", false, "gx.extensions.web.window", "open", new Object[] {formatLink("adocumentorelatoriopdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)}, false);
         context.DoAjaxRefresh();
      }

      protected void S182( )
      {
         /* 'DO BTNEXCLUIR' Routine */
         returnInSub = false;
         GXt_boolean3 = AV183IsOk;
         new documentoexclui(context ).execute(  A75DocumentoId, out  GXt_boolean3) ;
         AV183IsOk = GXt_boolean3;
         if ( AV183IsOk )
         {
            new filtrarconsultadoc(context ).execute(  AV166FiltrosDocumento,  AV109DocumentoBuscaAvancada, out  AV167Documentos) ;
            gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            if ( StringUtil.StrCmp(AV23Session.Get(AV210Pgmname+"GridState"), "") == 0 )
            {
               AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV210Pgmname+"GridState"), null, "", "");
            }
            else
            {
               AV11GridState.FromXml(AV23Session.Get(AV210Pgmname+"GridState"), null, "", "");
            }
            AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV211GXV1 = 1;
            while ( AV211GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
            {
               AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV211GXV1));
               if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
               {
                  AV27TFDocumentoId = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."));
                  AssignAttri("", false, "AV27TFDocumentoId", StringUtil.LTrimStr( (decimal)(AV27TFDocumentoId), 8, 0));
                  AV28TFDocumentoId_To = (int)(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."));
                  AssignAttri("", false, "AV28TFDocumentoId_To", StringUtil.LTrimStr( (decimal)(AV28TFDocumentoId_To), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTODATAINCLUSAO") == 0 )
               {
                  AV150TFDocumentoDataInclusao = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
                  AssignAttri("", false, "AV150TFDocumentoDataInclusao", context.localUtil.TToC( AV150TFDocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
                  AV151TFDocumentoDataInclusao_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
                  AssignAttri("", false, "AV151TFDocumentoDataInclusao_To", context.localUtil.TToC( AV151TFDocumentoDataInclusao_To, 8, 5, 0, 3, "/", ":", " "));
                  AV152DDO_DocumentoDataInclusaoAuxDate = DateTimeUtil.ResetTime(AV150TFDocumentoDataInclusao);
                  AssignAttri("", false, "AV152DDO_DocumentoDataInclusaoAuxDate", context.localUtil.Format(AV152DDO_DocumentoDataInclusaoAuxDate, "99/99/99"));
                  AV153DDO_DocumentoDataInclusaoAuxDateTo = DateTimeUtil.ResetTime(AV151TFDocumentoDataInclusao_To);
                  AssignAttri("", false, "AV153DDO_DocumentoDataInclusaoAuxDateTo", context.localUtil.Format(AV153DDO_DocumentoDataInclusaoAuxDateTo, "99/99/99"));
               }
               else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTODATAALTERACAO") == 0 )
               {
                  AV100TFDocumentoDataAlteracao = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
                  AssignAttri("", false, "AV100TFDocumentoDataAlteracao", context.localUtil.TToC( AV100TFDocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
                  AV101TFDocumentoDataAlteracao_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
                  AssignAttri("", false, "AV101TFDocumentoDataAlteracao_To", context.localUtil.TToC( AV101TFDocumentoDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "));
                  AV102DDO_DocumentoDataAlteracaoAuxDate = DateTimeUtil.ResetTime(AV100TFDocumentoDataAlteracao);
                  AssignAttri("", false, "AV102DDO_DocumentoDataAlteracaoAuxDate", context.localUtil.Format(AV102DDO_DocumentoDataAlteracaoAuxDate, "99/99/99"));
                  AV103DDO_DocumentoDataAlteracaoAuxDateTo = DateTimeUtil.ResetTime(AV101TFDocumentoDataAlteracao_To);
                  AssignAttri("", false, "AV103DDO_DocumentoDataAlteracaoAuxDateTo", context.localUtil.Format(AV103DDO_DocumentoDataAlteracaoAuxDateTo, "99/99/99"));
               }
               AV211GXV1 = (int)(AV211GXV1+1);
            }
            Ddo_grid_Filteredtext_set = ((0==AV27TFDocumentoId) ? "" : StringUtil.Str( (decimal)(AV27TFDocumentoId), 8, 0))+"|"+((DateTime.MinValue==AV150TFDocumentoDataInclusao) ? "" : context.localUtil.DToC( AV152DDO_DocumentoDataInclusaoAuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV100TFDocumentoDataAlteracao) ? "" : context.localUtil.DToC( AV102DDO_DocumentoDataAlteracaoAuxDate, 2, "/"));
            ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
            Ddo_grid_Filteredtextto_set = ((0==AV28TFDocumentoId_To) ? "" : StringUtil.Str( (decimal)(AV28TFDocumentoId_To), 8, 0))+"|"+((DateTime.MinValue==AV151TFDocumentoDataInclusao_To) ? "" : context.localUtil.DToC( AV153DDO_DocumentoDataInclusaoAuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV101TFDocumentoDataAlteracao_To) ? "" : context.localUtil.DToC( AV103DDO_DocumentoDataAlteracaoAuxDateTo, 2, "/"));
            ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
            {
               subGrid_Rows = (int)(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."));
               GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            }
            subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
         }
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            AV11GridState.FromXml(AV23Session.Get(AV210Pgmname+"GridState"), null, "", "");
            AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
            AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
            AV11GridState.gxTpr_Filtervalues.Clear();
            new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTOID",  "Código",  !((0==AV27TFDocumentoId)&&(0==AV28TFDocumentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFDocumentoId), 8, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFDocumentoId_To), 8, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTODATAINCLUSAO",  "Inclusão",  !((DateTime.MinValue==AV150TFDocumentoDataInclusao)&&(DateTime.MinValue==AV151TFDocumentoDataInclusao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV150TFDocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV151TFDocumentoDataInclusao_To, 8, 5, 0, 3, "/", ":", " "))) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTODATAALTERACAO",  "Alteração",  !((DateTime.MinValue==AV100TFDocumentoDataAlteracao)&&(DateTime.MinValue==AV101TFDocumentoDataAlteracao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV100TFDocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV101TFDocumentoDataAlteracao_To, 8, 5, 0, 3, "/", ":", " "))) ;
            AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
            AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
            new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV210Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV210Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Documento";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void E235R2( )
      {
         /* Btnatualizar_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "documentocadastrowp.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A75DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E245R2( )
      {
         /* Btnvisualizar_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "documentocadastrowp.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A75DocumentoId,8,0)) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S192( )
      {
         /* 'FILTRA' Routine */
         returnInSub = false;
         AV166FiltrosDocumento = new SdtFiltrosDocumento(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88DocumentoNome)) || ! (0==AV89DocumentoProcessoId) || ! (false==(0==AV90SubprocessoId)) || ! (0==AV91DocumentoControladorId) || ! (0==AV92EncarregadoId) || ! (0==AV144PersonaId) || ! (0==AV93DocumentoSituacao) || ! (0==AV178AreaResponsavelId) )
         {
            AV166FiltrosDocumento.gxTpr_Isdocumento = true;
            AV166FiltrosDocumento.gxTpr_Nome = AV88DocumentoNome;
            AV166FiltrosDocumento.gxTpr_Processo = AV89DocumentoProcessoId;
            AV166FiltrosDocumento.gxTpr_Subprocesso = AV90SubprocessoId;
            AV166FiltrosDocumento.gxTpr_Arearesponsavel = AV178AreaResponsavelId;
            AV166FiltrosDocumento.gxTpr_Controlador = AV91DocumentoControladorId;
            AV166FiltrosDocumento.gxTpr_Encarregado = AV92EncarregadoId;
            AV166FiltrosDocumento.gxTpr_Persona = AV144PersonaId;
            AV166FiltrosDocumento.gxTpr_Situacao = AV93DocumentoSituacao;
         }
         else
         {
            AV166FiltrosDocumento.gxTpr_Isdocumento = false;
         }
         if ( AV109DocumentoBuscaAvancada )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126DocumentoFinalidadeTratamento)) || ! (0==AV129CategoriaId) || ! (0==AV130TipoDadoId) || ! (0==AV127FerramentaColetaId) || ! (0==AV128AbrangenciaGeograficaId) || ! (0==AV131FrequenciaTratamentoId) || ! (0==AV133TipoDescarteId) || ! (0==AV134TempoRetencaoId) || ! (false==AV132DocumentoPrevColetaDados) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV135DocumentoBaseLegalNorm)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV136DocumentoBaseLegalNormIntExt)) || ! (false==AV138DocumentoDadosGrupoVul) || ! (false==AV139DocumentoDadosCriancaAdolesc) )
            {
               AV166FiltrosDocumento.gxTpr_Istratamento = true;
               AV166FiltrosDocumento.gxTpr_Finalidadetratamento = AV126DocumentoFinalidadeTratamento;
               AV166FiltrosDocumento.gxTpr_Categoria = AV129CategoriaId;
               AV166FiltrosDocumento.gxTpr_Tipodado = AV130TipoDadoId;
               AV166FiltrosDocumento.gxTpr_Ferramentacoleta = AV127FerramentaColetaId;
               AV166FiltrosDocumento.gxTpr_Abrangenciageografica = AV128AbrangenciaGeograficaId;
               AV166FiltrosDocumento.gxTpr_Frequenciatratamento = AV131FrequenciaTratamentoId;
               AV166FiltrosDocumento.gxTpr_Tipodescarte = AV133TipoDescarteId;
               AV166FiltrosDocumento.gxTpr_Temporetencao = AV134TempoRetencaoId;
               AV166FiltrosDocumento.gxTpr_Prevcoletadados = AV132DocumentoPrevColetaDados;
               AV166FiltrosDocumento.gxTpr_Baselegal = AV135DocumentoBaseLegalNorm;
               AV166FiltrosDocumento.gxTpr_Baselegalextint = AV136DocumentoBaseLegalNormIntExt;
               AV166FiltrosDocumento.gxTpr_Dadosgrupovulneravel = AV138DocumentoDadosGrupoVul;
               AV166FiltrosDocumento.gxTpr_Dadoscriancaadolescente = AV139DocumentoDadosCriancaAdolesc;
            }
            else
            {
               AV166FiltrosDocumento.gxTpr_Istratamento = false;
            }
            if ( ! (0==AV110InformacaoId) || ! (0==AV111HipoteseTratamentoId) || ! (false==AV116DocDicionarioSensivel) || ! (false==AV117DocDicionarioPodeEliminar) || ! (false==AV168DocDicionarioTransfInter) || ! (0==AV113PaisId) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV155DocDicionarioTipoTransfInterGarantia)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV156DocDicionarioFinalidade)) )
            {
               AV166FiltrosDocumento.gxTpr_Isdicionario = true;
               AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Informacao = AV110InformacaoId;
               AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Hipotesetratamento = AV111HipoteseTratamentoId;
               AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Dadosensivel = AV116DocDicionarioSensivel;
               AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Eliminardado = AV117DocDicionarioPodeEliminar;
               if ( AV168DocDicionarioTransfInter )
               {
                  AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Transfint = true;
                  AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Pais = AV113PaisId;
                  AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Tipotransfint = AV155DocDicionarioTipoTransfInterGarantia;
               }
               else
               {
                  AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Transfint = false;
               }
               AV166FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Finalidadedicio = AV156DocDicionarioFinalidade;
            }
            else
            {
               AV166FiltrosDocumento.gxTpr_Isdicionario = false;
            }
            if ( ! (0==AV118Operadores) || ! (false==AV121DocOperadorColeta) || ! (false==AV123DocOperadorCompartilhamento) || ! (false==AV124DocOperadorEliminacao) || ! (false==AV125DocOperadorProcessamento) || ! (false==AV122DocOperadorRetencao) )
            {
               AV166FiltrosDocumento.gxTpr_Isoperador = true;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operador = true;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcadastrado = AV118Operadores;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcoleta = AV121DocOperadorColeta;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcompartilhamento = AV123DocOperadorCompartilhamento;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadoreliminacao = AV124DocOperadorEliminacao;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorprocessamento = AV125DocOperadorProcessamento;
               AV166FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorretencao = AV122DocOperadorRetencao;
            }
            else
            {
               AV166FiltrosDocumento.gxTpr_Isoperador = false;
            }
         }
         new filtrarconsultadoc(context ).execute(  AV166FiltrosDocumento,  AV109DocumentoBuscaAvancada, out  AV167Documentos) ;
         gxgrGrid_refresh( subGrid_Rows, AV166FiltrosDocumento, AV109DocumentoBuscaAvancada, AV210Pgmname, AV188IsAuthorized_Excel, AV189IsAuthorized_PDF, AV13OrderedBy, AV14OrderedDsc, AV27TFDocumentoId, AV28TFDocumentoId_To, AV150TFDocumentoDataInclusao, AV151TFDocumentoDataInclusao_To, AV100TFDocumentoDataAlteracao, AV101TFDocumentoDataAlteracao_To, AV89DocumentoProcessoId, AV90SubprocessoId, AV178AreaResponsavelId, AV91DocumentoControladorId, AV92EncarregadoId, AV144PersonaId, AV129CategoriaId, AV130TipoDadoId, AV127FerramentaColetaId, AV128AbrangenciaGeograficaId, AV131FrequenciaTratamentoId, AV133TipoDescarteId, AV134TempoRetencaoId, AV110InformacaoId, AV111HipoteseTratamentoId, AV113PaisId, AV118Operadores, AV132DocumentoPrevColetaDados, AV138DocumentoDadosGrupoVul, AV139DocumentoDadosCriancaAdolesc, AV116DocDicionarioSensivel, AV117DocDicionarioPodeEliminar, AV121DocOperadorColeta, AV122DocOperadorRetencao, AV123DocOperadorCompartilhamento, AV124DocOperadorEliminacao, AV125DocOperadorProcessamento, AV192IsAuthorized_BtnExcluir) ;
      }

      protected void wb_table7_303_5R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnexcluir_Internalname, tblTabledvelop_confirmpanel_btnexcluir_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnexcluir.SetProperty("Title", Dvelop_confirmpanel_btnexcluir_Title);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnexcluir_Confirmationtext);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnexcluir_Nobuttoncaption);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnexcluir_Yesbuttonposition);
            ucDvelop_confirmpanel_btnexcluir.SetProperty("ConfirmType", Dvelop_confirmpanel_btnexcluir_Confirmtype);
            ucDvelop_confirmpanel_btnexcluir.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnexcluir_Internalname, "DVELOP_CONFIRMPANEL_BTNEXCLUIRContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNEXCLUIRContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_303_5R2e( true) ;
         }
         else
         {
            wb_table7_303_5R2e( false) ;
         }
      }

      protected void wb_table6_233_5R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 237,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorprocessamento_Internalname, StringUtil.BoolToStr( AV125DocOperadorProcessamento), "", "Doc Operador Processamento", 1, chkavDocoperadorprocessamento.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(237, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,237);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorprocessamento_righttext_Internalname, "PROCESSAMENTO", "", "", lblDocoperadorprocessamento_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_233_5R2e( true) ;
         }
         else
         {
            wb_table6_233_5R2e( false) ;
         }
      }

      protected void wb_table5_225_5R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadoreliminacao_Internalname, StringUtil.BoolToStr( AV124DocOperadorEliminacao), "", "Doc Operador Eliminacao", 1, chkavDocoperadoreliminacao.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(229, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,229);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadoreliminacao_righttext_Internalname, "ELIMINAÇÃO", "", "", lblDocoperadoreliminacao_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_225_5R2e( true) ;
         }
         else
         {
            wb_table5_225_5R2e( false) ;
         }
      }

      protected void wb_table4_217_5R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorcompartilhamento_Internalname, StringUtil.BoolToStr( AV123DocOperadorCompartilhamento), "", "Doc Operador Compartilhamento", 1, chkavDocoperadorcompartilhamento.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(221, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,221);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcompartilhamento_righttext_Internalname, "COMPARTILHAMENTO", "", "", lblDocoperadorcompartilhamento_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_217_5R2e( true) ;
         }
         else
         {
            wb_table4_217_5R2e( false) ;
         }
      }

      protected void wb_table3_209_5R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 213,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorretencao_Internalname, StringUtil.BoolToStr( AV122DocOperadorRetencao), "", "Doc Operador Retencao", 1, chkavDocoperadorretencao.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(213, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,213);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorretencao_righttext_Internalname, "RETENÇÃO", "", "", lblDocoperadorretencao_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_209_5R2e( true) ;
         }
         else
         {
            wb_table3_209_5R2e( false) ;
         }
      }

      protected void wb_table2_201_5R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'" + sGXsfl_257_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorcoleta_Internalname, StringUtil.BoolToStr( AV121DocOperadorColeta), "", "Doc Operador Coleta", 1, chkavDocoperadorcoleta.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(205, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,205);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcoleta_righttext_Internalname, "COLETA", "", "", lblDocoperadorcoleta_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_201_5R2e( true) ;
         }
         else
         {
            wb_table2_201_5R2e( false) ;
         }
      }

      protected void wb_table1_55_5R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtextblock1_Internalname, tblTablemergedtextblock1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "BUSCA AVANÇADA", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Attribute", 0, "", 1, 1, 0, 0, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBtnbuscaavancada_Internalname, lblBtnbuscaavancada_Caption, "", "", lblBtnbuscaavancada_Jsonclick, "'"+""+"'"+",false,"+"'"+"e255r1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_55_5R2e( true) ;
         }
         else
         {
            wb_table1_55_5R2e( false) ;
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
         PA5R2( ) ;
         WS5R2( ) ;
         WE5R2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231241762832", true, true);
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
         context.AddJavascriptSource("documentoww.js", "?20231241762834", false, true);
         context.AddJavascriptSource("web-extension/gx-web-extensions.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_2572( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_257_idx;
         edtavBtnatualizar_Internalname = "vBTNATUALIZAR_"+sGXsfl_257_idx;
         edtavBtnvisualizar_Internalname = "vBTNVISUALIZAR_"+sGXsfl_257_idx;
         edtavBtnexcluir_Internalname = "vBTNEXCLUIR_"+sGXsfl_257_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_257_idx;
         edtavDocumentonome_grid_Internalname = "vDOCUMENTONOME_GRID_"+sGXsfl_257_idx;
         edtDocumentoNome_Internalname = "DOCUMENTONOME_"+sGXsfl_257_idx;
         edtavProcessonome_grid_Internalname = "vPROCESSONOME_GRID_"+sGXsfl_257_idx;
         edtProcessoNome_Internalname = "PROCESSONOME_"+sGXsfl_257_idx;
         edtSubprocessoNome_Internalname = "SUBPROCESSONOME_"+sGXsfl_257_idx;
         edtavSubprocessonome_grid_Internalname = "vSUBPROCESSONOME_GRID_"+sGXsfl_257_idx;
         edtDocumentoDataInclusao_Internalname = "DOCUMENTODATAINCLUSAO_"+sGXsfl_257_idx;
         edtDocumentoDataAlteracao_Internalname = "DOCUMENTODATAALTERACAO_"+sGXsfl_257_idx;
         edtDocumentoProcessoId_Internalname = "DOCUMENTOPROCESSOID_"+sGXsfl_257_idx;
         edtProcessoId_Internalname = "PROCESSOID_"+sGXsfl_257_idx;
         edtSubprocessoId_Internalname = "SUBPROCESSOID_"+sGXsfl_257_idx;
         edtEncarregadoId_Internalname = "ENCARREGADOID_"+sGXsfl_257_idx;
         edtPersonaId_Internalname = "PERSONAID_"+sGXsfl_257_idx;
         edtDocumentoFinalidadeTratamento_Internalname = "DOCUMENTOFINALIDADETRATAMENTO_"+sGXsfl_257_idx;
         edtCategoriaId_Internalname = "CATEGORIAID_"+sGXsfl_257_idx;
         edtTipoDadoId_Internalname = "TIPODADOID_"+sGXsfl_257_idx;
         edtFerramentaColetaId_Internalname = "FERRAMENTACOLETAID_"+sGXsfl_257_idx;
         edtAbrangenciaGeograficaId_Internalname = "ABRANGENCIAGEOGRAFICAID_"+sGXsfl_257_idx;
         edtFrequenciaTratamentoId_Internalname = "FREQUENCIATRATAMENTOID_"+sGXsfl_257_idx;
         edtTipoDescarteId_Internalname = "TIPODESCARTEID_"+sGXsfl_257_idx;
         edtTempoRetencaoId_Internalname = "TEMPORETENCAOID_"+sGXsfl_257_idx;
         chkDocumentoPrevColetaDados_Internalname = "DOCUMENTOPREVCOLETADADOS_"+sGXsfl_257_idx;
         edtDocumentoBaseLegalNorm_Internalname = "DOCUMENTOBASELEGALNORM_"+sGXsfl_257_idx;
         edtDocumentoBaseLegalNormIntExt_Internalname = "DOCUMENTOBASELEGALNORMINTEXT_"+sGXsfl_257_idx;
         chkDocumentoDadosCriancaAdolesc_Internalname = "DOCUMENTODADOSCRIANCAADOLESC_"+sGXsfl_257_idx;
         chkDocumentoDadosGrupoVul_Internalname = "DOCUMENTODADOSGRUPOVUL_"+sGXsfl_257_idx;
         edtDocumentoMedidaSegurancaDesc_Internalname = "DOCUMENTOMEDIDASEGURANCADESC_"+sGXsfl_257_idx;
         cmbDocumentoAtivo_Internalname = "DOCUMENTOATIVO_"+sGXsfl_257_idx;
         chkDocumentoOperador_Internalname = "DOCUMENTOOPERADOR_"+sGXsfl_257_idx;
         edtDocumentoProcessoNome_Internalname = "DOCUMENTOPROCESSONOME_"+sGXsfl_257_idx;
      }

      protected void SubsflControlProps_fel_2572( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_257_fel_idx;
         edtavBtnatualizar_Internalname = "vBTNATUALIZAR_"+sGXsfl_257_fel_idx;
         edtavBtnvisualizar_Internalname = "vBTNVISUALIZAR_"+sGXsfl_257_fel_idx;
         edtavBtnexcluir_Internalname = "vBTNEXCLUIR_"+sGXsfl_257_fel_idx;
         edtDocumentoId_Internalname = "DOCUMENTOID_"+sGXsfl_257_fel_idx;
         edtavDocumentonome_grid_Internalname = "vDOCUMENTONOME_GRID_"+sGXsfl_257_fel_idx;
         edtDocumentoNome_Internalname = "DOCUMENTONOME_"+sGXsfl_257_fel_idx;
         edtavProcessonome_grid_Internalname = "vPROCESSONOME_GRID_"+sGXsfl_257_fel_idx;
         edtProcessoNome_Internalname = "PROCESSONOME_"+sGXsfl_257_fel_idx;
         edtSubprocessoNome_Internalname = "SUBPROCESSONOME_"+sGXsfl_257_fel_idx;
         edtavSubprocessonome_grid_Internalname = "vSUBPROCESSONOME_GRID_"+sGXsfl_257_fel_idx;
         edtDocumentoDataInclusao_Internalname = "DOCUMENTODATAINCLUSAO_"+sGXsfl_257_fel_idx;
         edtDocumentoDataAlteracao_Internalname = "DOCUMENTODATAALTERACAO_"+sGXsfl_257_fel_idx;
         edtDocumentoProcessoId_Internalname = "DOCUMENTOPROCESSOID_"+sGXsfl_257_fel_idx;
         edtProcessoId_Internalname = "PROCESSOID_"+sGXsfl_257_fel_idx;
         edtSubprocessoId_Internalname = "SUBPROCESSOID_"+sGXsfl_257_fel_idx;
         edtEncarregadoId_Internalname = "ENCARREGADOID_"+sGXsfl_257_fel_idx;
         edtPersonaId_Internalname = "PERSONAID_"+sGXsfl_257_fel_idx;
         edtDocumentoFinalidadeTratamento_Internalname = "DOCUMENTOFINALIDADETRATAMENTO_"+sGXsfl_257_fel_idx;
         edtCategoriaId_Internalname = "CATEGORIAID_"+sGXsfl_257_fel_idx;
         edtTipoDadoId_Internalname = "TIPODADOID_"+sGXsfl_257_fel_idx;
         edtFerramentaColetaId_Internalname = "FERRAMENTACOLETAID_"+sGXsfl_257_fel_idx;
         edtAbrangenciaGeograficaId_Internalname = "ABRANGENCIAGEOGRAFICAID_"+sGXsfl_257_fel_idx;
         edtFrequenciaTratamentoId_Internalname = "FREQUENCIATRATAMENTOID_"+sGXsfl_257_fel_idx;
         edtTipoDescarteId_Internalname = "TIPODESCARTEID_"+sGXsfl_257_fel_idx;
         edtTempoRetencaoId_Internalname = "TEMPORETENCAOID_"+sGXsfl_257_fel_idx;
         chkDocumentoPrevColetaDados_Internalname = "DOCUMENTOPREVCOLETADADOS_"+sGXsfl_257_fel_idx;
         edtDocumentoBaseLegalNorm_Internalname = "DOCUMENTOBASELEGALNORM_"+sGXsfl_257_fel_idx;
         edtDocumentoBaseLegalNormIntExt_Internalname = "DOCUMENTOBASELEGALNORMINTEXT_"+sGXsfl_257_fel_idx;
         chkDocumentoDadosCriancaAdolesc_Internalname = "DOCUMENTODADOSCRIANCAADOLESC_"+sGXsfl_257_fel_idx;
         chkDocumentoDadosGrupoVul_Internalname = "DOCUMENTODADOSGRUPOVUL_"+sGXsfl_257_fel_idx;
         edtDocumentoMedidaSegurancaDesc_Internalname = "DOCUMENTOMEDIDASEGURANCADESC_"+sGXsfl_257_fel_idx;
         cmbDocumentoAtivo_Internalname = "DOCUMENTOATIVO_"+sGXsfl_257_fel_idx;
         chkDocumentoOperador_Internalname = "DOCUMENTOOPERADOR_"+sGXsfl_257_fel_idx;
         edtDocumentoProcessoNome_Internalname = "DOCUMENTOPROCESSONOME_"+sGXsfl_257_fel_idx;
      }

      protected void sendrow_2572( )
      {
         SubsflControlProps_2572( ) ;
         WB5R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_257_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_257_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_257_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactiongroup1.Enabled!=0)&&(cmbavGridactiongroup1.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 258,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_257_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV179GridActionGroup1 = (short)(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV179GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_257_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactiongroup1_Class,(string)cmbavGridactiongroup1_Columnclass,(string)cmbavGridactiongroup1_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactiongroup1.Enabled!=0)&&(cmbavGridactiongroup1.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,258);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_257_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnatualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnatualizar_Enabled!=0)&&(edtavBtnatualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 259,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnatualizar_Internalname,StringUtil.RTrim( AV149BtnAtualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnatualizar_Enabled!=0)&&(edtavBtnatualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,259);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVBTNATUALIZAR.CLICK."+sGXsfl_257_idx+"'",(string)"",(string)"",(string)"Editar o Documento",(string)"",(string)edtavBtnatualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavBtnatualizar_Columnclass,(string)edtavBtnatualizar_Columnheaderclass,(int)edtavBtnatualizar_Visible,(int)edtavBtnatualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnvisualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnvisualizar_Enabled!=0)&&(edtavBtnvisualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 260,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnvisualizar_Internalname,StringUtil.RTrim( AV148BtnVisualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnvisualizar_Enabled!=0)&&(edtavBtnvisualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,260);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVBTNVISUALIZAR.CLICK."+sGXsfl_257_idx+"'",(string)"",(string)"",(string)"Visualizar o Documento",(string)"",(string)edtavBtnvisualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavBtnvisualizar_Columnclass,(string)edtavBtnvisualizar_Columnheaderclass,(int)edtavBtnvisualizar_Visible,(int)edtavBtnvisualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnexcluir_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnexcluir_Enabled!=0)&&(edtavBtnexcluir_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 261,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnexcluir_Internalname,StringUtil.RTrim( AV180BtnExcluir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnexcluir_Enabled!=0)&&(edtavBtnexcluir_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,261);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVBTNEXCLUIR.CLICK."+sGXsfl_257_idx+"'",(string)"",(string)"",(string)"Excluir o documento",(string)"",(string)edtavBtnexcluir_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavBtnexcluir_Columnclass,(string)edtavBtnexcluir_Columnheaderclass,(int)edtavBtnexcluir_Visible,(int)edtavBtnexcluir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtDocumentoId_Columnclass,(string)edtDocumentoId_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDocumentonome_grid_Enabled!=0)&&(edtavDocumentonome_grid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 263,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentonome_grid_Internalname,(string)AV205DocumentoNome_Grid,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDocumentonome_grid_Enabled!=0)&&(edtavDocumentonome_grid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,263);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)edtavDocumentonome_grid_Tooltiptext,(string)"",(string)edtavDocumentonome_grid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavDocumentonome_grid_Columnclass,(string)edtavDocumentonome_grid_Columnheaderclass,(short)-1,(int)edtavDocumentonome_grid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoNome_Internalname,(string)A76DocumentoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn CellMarginLeft",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavProcessonome_grid_Enabled!=0)&&(edtavProcessonome_grid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 265,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProcessonome_grid_Internalname,(string)AV206ProcessoNome_Grid,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavProcessonome_grid_Enabled!=0)&&(edtavProcessonome_grid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,265);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)edtavProcessonome_grid_Tooltiptext,(string)"",(string)edtavProcessonome_grid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavProcessonome_grid_Columnclass,(string)edtavProcessonome_grid_Columnheaderclass,(short)-1,(int)edtavProcessonome_grid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcessoNome_Internalname,(string)A17ProcessoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcessoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn CellMarginLeft",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSubprocessoNome_Internalname,(string)A21SubprocessoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSubprocessoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn CellMarginLeft",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavSubprocessonome_grid_Enabled!=0)&&(edtavSubprocessonome_grid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 268,'',false,'"+sGXsfl_257_idx+"',257)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSubprocessonome_grid_Internalname,(string)AV207SubprocessoNome_Grid,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSubprocessonome_grid_Enabled!=0)&&(edtavSubprocessonome_grid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,268);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)edtavSubprocessonome_grid_Tooltiptext,(string)"",(string)edtavSubprocessonome_grid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSubprocessonome_grid_Columnclass,(string)edtavSubprocessonome_grid_Columnheaderclass,(short)-1,(int)edtavSubprocessonome_grid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoDataInclusao_Internalname,context.localUtil.TToC( A108DocumentoDataInclusao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A108DocumentoDataInclusao, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoDataInclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtDocumentoDataInclusao_Columnclass,(string)edtDocumentoDataInclusao_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoDataAlteracao_Internalname,context.localUtil.TToC( A109DocumentoDataAlteracao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A109DocumentoDataAlteracao, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoDataAlteracao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtDocumentoDataAlteracao_Columnclass,(string)edtDocumentoDataAlteracao_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoProcessoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106DocumentoProcessoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106DocumentoProcessoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoProcessoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcessoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ProcessoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16ProcessoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcessoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSubprocessoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20SubprocessoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSubprocessoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEncarregadoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7EncarregadoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7EncarregadoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEncarregadoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPersonaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PersonaId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13PersonaId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPersonaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoFinalidadeTratamento_Internalname,(string)A77DocumentoFinalidadeTratamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoFinalidadeTratamento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A27CategoriaId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A27CategoriaId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoDadoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30TipoDadoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A30TipoDadoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoDadoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFerramentaColetaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FerramentaColetaId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A33FerramentaColetaId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFerramentaColetaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAbrangenciaGeograficaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AbrangenciaGeograficaId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A36AbrangenciaGeograficaId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAbrangenciaGeograficaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFrequenciaTratamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A39FrequenciaTratamentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A39FrequenciaTratamentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFrequenciaTratamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoDescarteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TipoDescarteId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A45TipoDescarteId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoDescarteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTempoRetencaoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A48TempoRetencaoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A48TempoRetencaoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTempoRetencaoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCUMENTOPREVCOLETADADOS_" + sGXsfl_257_idx;
            chkDocumentoPrevColetaDados.Name = GXCCtl;
            chkDocumentoPrevColetaDados.WebTags = "";
            chkDocumentoPrevColetaDados.Caption = "";
            AssignProp("", false, chkDocumentoPrevColetaDados_Internalname, "TitleCaption", chkDocumentoPrevColetaDados.Caption, !bGXsfl_257_Refreshing);
            chkDocumentoPrevColetaDados.CheckedValue = "false";
            A78DocumentoPrevColetaDados = StringUtil.StrToBool( StringUtil.BoolToStr( A78DocumentoPrevColetaDados));
            n78DocumentoPrevColetaDados = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocumentoPrevColetaDados_Internalname,StringUtil.BoolToStr( A78DocumentoPrevColetaDados),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoBaseLegalNorm_Internalname,(string)A79DocumentoBaseLegalNorm,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoBaseLegalNorm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoBaseLegalNormIntExt_Internalname,(string)A80DocumentoBaseLegalNormIntExt,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoBaseLegalNormIntExt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCUMENTODADOSCRIANCAADOLESC_" + sGXsfl_257_idx;
            chkDocumentoDadosCriancaAdolesc.Name = GXCCtl;
            chkDocumentoDadosCriancaAdolesc.WebTags = "";
            chkDocumentoDadosCriancaAdolesc.Caption = "";
            AssignProp("", false, chkDocumentoDadosCriancaAdolesc_Internalname, "TitleCaption", chkDocumentoDadosCriancaAdolesc.Caption, !bGXsfl_257_Refreshing);
            chkDocumentoDadosCriancaAdolesc.CheckedValue = "false";
            A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc));
            n81DocumentoDadosCriancaAdolesc = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocumentoDadosCriancaAdolesc_Internalname,StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCUMENTODADOSGRUPOVUL_" + sGXsfl_257_idx;
            chkDocumentoDadosGrupoVul.Name = GXCCtl;
            chkDocumentoDadosGrupoVul.WebTags = "";
            chkDocumentoDadosGrupoVul.Caption = "";
            AssignProp("", false, chkDocumentoDadosGrupoVul_Internalname, "TitleCaption", chkDocumentoDadosGrupoVul.Caption, !bGXsfl_257_Refreshing);
            chkDocumentoDadosGrupoVul.CheckedValue = "false";
            A82DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( A82DocumentoDadosGrupoVul));
            n82DocumentoDadosGrupoVul = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocumentoDadosGrupoVul_Internalname,StringUtil.BoolToStr( A82DocumentoDadosGrupoVul),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoMedidaSegurancaDesc_Internalname,(string)A83DocumentoMedidaSegurancaDesc,(string)A83DocumentoMedidaSegurancaDesc,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoMedidaSegurancaDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)10000,(short)0,(short)0,(short)257,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbDocumentoAtivo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "DOCUMENTOATIVO_" + sGXsfl_257_idx;
               cmbDocumentoAtivo.Name = GXCCtl;
               cmbDocumentoAtivo.WebTags = "";
               cmbDocumentoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
               cmbDocumentoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
               if ( cmbDocumentoAtivo.ItemCount > 0 )
               {
                  A85DocumentoAtivo = StringUtil.StrToBool( cmbDocumentoAtivo.getValidValue(StringUtil.BoolToStr( A85DocumentoAtivo)));
                  n85DocumentoAtivo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbDocumentoAtivo,(string)cmbDocumentoAtivo_Internalname,StringUtil.BoolToStr( A85DocumentoAtivo),(short)1,(string)cmbDocumentoAtivo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbDocumentoAtivo.CurrentValue = StringUtil.BoolToStr( A85DocumentoAtivo);
            AssignProp("", false, cmbDocumentoAtivo_Internalname, "Values", (string)(cmbDocumentoAtivo.ToJavascriptSource()), !bGXsfl_257_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCUMENTOOPERADOR_" + sGXsfl_257_idx;
            chkDocumentoOperador.Name = GXCCtl;
            chkDocumentoOperador.WebTags = "";
            chkDocumentoOperador.Caption = "";
            AssignProp("", false, chkDocumentoOperador_Internalname, "TitleCaption", chkDocumentoOperador.Caption, !bGXsfl_257_Refreshing);
            chkDocumentoOperador.CheckedValue = "false";
            A105DocumentoOperador = StringUtil.StrToBool( StringUtil.BoolToStr( A105DocumentoOperador));
            n105DocumentoOperador = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocumentoOperador_Internalname,StringUtil.BoolToStr( A105DocumentoOperador),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoProcessoNome_Internalname,(string)A107DocumentoProcessoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoProcessoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)257,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes5R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_257_idx = ((subGrid_Islastpage==1)&&(nGXsfl_257_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_257_idx+1);
            sGXsfl_257_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_257_idx), 4, 0), 4, "0");
            SubsflControlProps_2572( ) ;
         }
         /* End function sendrow_2572 */
      }

      protected void init_web_controls( )
      {
         dynavDocumentoprocessoid.Name = "vDOCUMENTOPROCESSOID";
         dynavDocumentoprocessoid.WebTags = "";
         dynavSubprocessoid.Name = "vSUBPROCESSOID";
         dynavSubprocessoid.WebTags = "";
         dynavArearesponsavelid.Name = "vAREARESPONSAVELID";
         dynavArearesponsavelid.WebTags = "";
         dynavDocumentocontroladorid.Name = "vDOCUMENTOCONTROLADORID";
         dynavDocumentocontroladorid.WebTags = "";
         dynavEncarregadoid.Name = "vENCARREGADOID";
         dynavEncarregadoid.WebTags = "";
         dynavPersonaid.Name = "vPERSONAID";
         dynavPersonaid.WebTags = "";
         cmbavDocumentosituacao.Name = "vDOCUMENTOSITUACAO";
         cmbavDocumentosituacao.WebTags = "";
         cmbavDocumentosituacao.addItem("0", "TODOS", 0);
         cmbavDocumentosituacao.addItem("1", "INATIVO", 0);
         cmbavDocumentosituacao.addItem("2", "ATIVO", 0);
         if ( cmbavDocumentosituacao.ItemCount > 0 )
         {
            AV93DocumentoSituacao = (short)(NumberUtil.Val( cmbavDocumentosituacao.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV93DocumentoSituacao), 4, 0))), "."));
            AssignAttri("", false, "AV93DocumentoSituacao", StringUtil.LTrimStr( (decimal)(AV93DocumentoSituacao), 4, 0));
         }
         dynavCategoriaid.Name = "vCATEGORIAID";
         dynavCategoriaid.WebTags = "";
         dynavTipodadoid.Name = "vTIPODADOID";
         dynavTipodadoid.WebTags = "";
         dynavFerramentacoletaid.Name = "vFERRAMENTACOLETAID";
         dynavFerramentacoletaid.WebTags = "";
         dynavAbrangenciageograficaid.Name = "vABRANGENCIAGEOGRAFICAID";
         dynavAbrangenciageograficaid.WebTags = "";
         dynavFrequenciatratamentoid.Name = "vFREQUENCIATRATAMENTOID";
         dynavFrequenciatratamentoid.WebTags = "";
         dynavTipodescarteid.Name = "vTIPODESCARTEID";
         dynavTipodescarteid.WebTags = "";
         dynavTemporetencaoid.Name = "vTEMPORETENCAOID";
         dynavTemporetencaoid.WebTags = "";
         chkavDocumentoprevcoletadados.Name = "vDOCUMENTOPREVCOLETADADOS";
         chkavDocumentoprevcoletadados.WebTags = "";
         chkavDocumentoprevcoletadados.Caption = "";
         AssignProp("", false, chkavDocumentoprevcoletadados_Internalname, "TitleCaption", chkavDocumentoprevcoletadados.Caption, true);
         chkavDocumentoprevcoletadados.CheckedValue = "false";
         AV132DocumentoPrevColetaDados = StringUtil.StrToBool( StringUtil.BoolToStr( AV132DocumentoPrevColetaDados));
         AssignAttri("", false, "AV132DocumentoPrevColetaDados", AV132DocumentoPrevColetaDados);
         chkavDocumentodadosgrupovul.Name = "vDOCUMENTODADOSGRUPOVUL";
         chkavDocumentodadosgrupovul.WebTags = "";
         chkavDocumentodadosgrupovul.Caption = "";
         AssignProp("", false, chkavDocumentodadosgrupovul_Internalname, "TitleCaption", chkavDocumentodadosgrupovul.Caption, true);
         chkavDocumentodadosgrupovul.CheckedValue = "false";
         AV138DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( AV138DocumentoDadosGrupoVul));
         AssignAttri("", false, "AV138DocumentoDadosGrupoVul", AV138DocumentoDadosGrupoVul);
         chkavDocumentodadoscriancaadolesc.Name = "vDOCUMENTODADOSCRIANCAADOLESC";
         chkavDocumentodadoscriancaadolesc.WebTags = "";
         chkavDocumentodadoscriancaadolesc.Caption = "";
         AssignProp("", false, chkavDocumentodadoscriancaadolesc_Internalname, "TitleCaption", chkavDocumentodadoscriancaadolesc.Caption, true);
         chkavDocumentodadoscriancaadolesc.CheckedValue = "false";
         AV139DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV139DocumentoDadosCriancaAdolesc));
         AssignAttri("", false, "AV139DocumentoDadosCriancaAdolesc", AV139DocumentoDadosCriancaAdolesc);
         dynavInformacaoid.Name = "vINFORMACAOID";
         dynavInformacaoid.WebTags = "";
         chkavDocdicionariosensivel.Name = "vDOCDICIONARIOSENSIVEL";
         chkavDocdicionariosensivel.WebTags = "";
         chkavDocdicionariosensivel.Caption = "";
         AssignProp("", false, chkavDocdicionariosensivel_Internalname, "TitleCaption", chkavDocdicionariosensivel.Caption, true);
         chkavDocdicionariosensivel.CheckedValue = "false";
         AV116DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( AV116DocDicionarioSensivel));
         AssignAttri("", false, "AV116DocDicionarioSensivel", AV116DocDicionarioSensivel);
         chkavDocdicionariopodeeliminar.Name = "vDOCDICIONARIOPODEELIMINAR";
         chkavDocdicionariopodeeliminar.WebTags = "";
         chkavDocdicionariopodeeliminar.Caption = "";
         AssignProp("", false, chkavDocdicionariopodeeliminar_Internalname, "TitleCaption", chkavDocdicionariopodeeliminar.Caption, true);
         chkavDocdicionariopodeeliminar.CheckedValue = "false";
         AV117DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( AV117DocDicionarioPodeEliminar));
         AssignAttri("", false, "AV117DocDicionarioPodeEliminar", AV117DocDicionarioPodeEliminar);
         dynavHipotesetratamentoid.Name = "vHIPOTESETRATAMENTOID";
         dynavHipotesetratamentoid.WebTags = "";
         cmbavDocdicionariotransfinter.Name = "vDOCDICIONARIOTRANSFINTER";
         cmbavDocdicionariotransfinter.WebTags = "";
         cmbavDocdicionariotransfinter.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbavDocdicionariotransfinter.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbavDocdicionariotransfinter.ItemCount > 0 )
         {
            AV168DocDicionarioTransfInter = StringUtil.StrToBool( cmbavDocdicionariotransfinter.getValidValue(StringUtil.BoolToStr( AV168DocDicionarioTransfInter)));
            AssignAttri("", false, "AV168DocDicionarioTransfInter", AV168DocDicionarioTransfInter);
         }
         dynavPaisid.Name = "vPAISID";
         dynavPaisid.WebTags = "";
         dynavOperadores.Name = "vOPERADORES";
         dynavOperadores.WebTags = "";
         chkavDocoperadorcoleta.Name = "vDOCOPERADORCOLETA";
         chkavDocoperadorcoleta.WebTags = "";
         chkavDocoperadorcoleta.Caption = "";
         AssignProp("", false, chkavDocoperadorcoleta_Internalname, "TitleCaption", chkavDocoperadorcoleta.Caption, true);
         chkavDocoperadorcoleta.CheckedValue = "false";
         AV121DocOperadorColeta = StringUtil.StrToBool( StringUtil.BoolToStr( AV121DocOperadorColeta));
         AssignAttri("", false, "AV121DocOperadorColeta", AV121DocOperadorColeta);
         chkavDocoperadorretencao.Name = "vDOCOPERADORRETENCAO";
         chkavDocoperadorretencao.WebTags = "";
         chkavDocoperadorretencao.Caption = "";
         AssignProp("", false, chkavDocoperadorretencao_Internalname, "TitleCaption", chkavDocoperadorretencao.Caption, true);
         chkavDocoperadorretencao.CheckedValue = "false";
         AV122DocOperadorRetencao = StringUtil.StrToBool( StringUtil.BoolToStr( AV122DocOperadorRetencao));
         AssignAttri("", false, "AV122DocOperadorRetencao", AV122DocOperadorRetencao);
         chkavDocoperadorcompartilhamento.Name = "vDOCOPERADORCOMPARTILHAMENTO";
         chkavDocoperadorcompartilhamento.WebTags = "";
         chkavDocoperadorcompartilhamento.Caption = "";
         AssignProp("", false, chkavDocoperadorcompartilhamento_Internalname, "TitleCaption", chkavDocoperadorcompartilhamento.Caption, true);
         chkavDocoperadorcompartilhamento.CheckedValue = "false";
         AV123DocOperadorCompartilhamento = StringUtil.StrToBool( StringUtil.BoolToStr( AV123DocOperadorCompartilhamento));
         AssignAttri("", false, "AV123DocOperadorCompartilhamento", AV123DocOperadorCompartilhamento);
         chkavDocoperadoreliminacao.Name = "vDOCOPERADORELIMINACAO";
         chkavDocoperadoreliminacao.WebTags = "";
         chkavDocoperadoreliminacao.Caption = "";
         AssignProp("", false, chkavDocoperadoreliminacao_Internalname, "TitleCaption", chkavDocoperadoreliminacao.Caption, true);
         chkavDocoperadoreliminacao.CheckedValue = "false";
         AV124DocOperadorEliminacao = StringUtil.StrToBool( StringUtil.BoolToStr( AV124DocOperadorEliminacao));
         AssignAttri("", false, "AV124DocOperadorEliminacao", AV124DocOperadorEliminacao);
         chkavDocoperadorprocessamento.Name = "vDOCOPERADORPROCESSAMENTO";
         chkavDocoperadorprocessamento.WebTags = "";
         chkavDocoperadorprocessamento.Caption = "";
         AssignProp("", false, chkavDocoperadorprocessamento_Internalname, "TitleCaption", chkavDocoperadorprocessamento.Caption, true);
         chkavDocoperadorprocessamento.CheckedValue = "false";
         AV125DocOperadorProcessamento = StringUtil.StrToBool( StringUtil.BoolToStr( AV125DocOperadorProcessamento));
         AssignAttri("", false, "AV125DocOperadorProcessamento", AV125DocOperadorProcessamento);
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_257_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV179GridActionGroup1 = (short)(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV179GridActionGroup1), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV179GridActionGroup1), 4, 0));
         }
         GXCCtl = "DOCUMENTOPREVCOLETADADOS_" + sGXsfl_257_idx;
         chkDocumentoPrevColetaDados.Name = GXCCtl;
         chkDocumentoPrevColetaDados.WebTags = "";
         chkDocumentoPrevColetaDados.Caption = "";
         AssignProp("", false, chkDocumentoPrevColetaDados_Internalname, "TitleCaption", chkDocumentoPrevColetaDados.Caption, !bGXsfl_257_Refreshing);
         chkDocumentoPrevColetaDados.CheckedValue = "false";
         A78DocumentoPrevColetaDados = StringUtil.StrToBool( StringUtil.BoolToStr( A78DocumentoPrevColetaDados));
         n78DocumentoPrevColetaDados = false;
         GXCCtl = "DOCUMENTODADOSCRIANCAADOLESC_" + sGXsfl_257_idx;
         chkDocumentoDadosCriancaAdolesc.Name = GXCCtl;
         chkDocumentoDadosCriancaAdolesc.WebTags = "";
         chkDocumentoDadosCriancaAdolesc.Caption = "";
         AssignProp("", false, chkDocumentoDadosCriancaAdolesc_Internalname, "TitleCaption", chkDocumentoDadosCriancaAdolesc.Caption, !bGXsfl_257_Refreshing);
         chkDocumentoDadosCriancaAdolesc.CheckedValue = "false";
         A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc));
         n81DocumentoDadosCriancaAdolesc = false;
         GXCCtl = "DOCUMENTODADOSGRUPOVUL_" + sGXsfl_257_idx;
         chkDocumentoDadosGrupoVul.Name = GXCCtl;
         chkDocumentoDadosGrupoVul.WebTags = "";
         chkDocumentoDadosGrupoVul.Caption = "";
         AssignProp("", false, chkDocumentoDadosGrupoVul_Internalname, "TitleCaption", chkDocumentoDadosGrupoVul.Caption, !bGXsfl_257_Refreshing);
         chkDocumentoDadosGrupoVul.CheckedValue = "false";
         A82DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( A82DocumentoDadosGrupoVul));
         n82DocumentoDadosGrupoVul = false;
         GXCCtl = "DOCUMENTOATIVO_" + sGXsfl_257_idx;
         cmbDocumentoAtivo.Name = GXCCtl;
         cmbDocumentoAtivo.WebTags = "";
         cmbDocumentoAtivo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbDocumentoAtivo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbDocumentoAtivo.ItemCount > 0 )
         {
            A85DocumentoAtivo = StringUtil.StrToBool( cmbDocumentoAtivo.getValidValue(StringUtil.BoolToStr( A85DocumentoAtivo)));
            n85DocumentoAtivo = false;
         }
         GXCCtl = "DOCUMENTOOPERADOR_" + sGXsfl_257_idx;
         chkDocumentoOperador.Name = GXCCtl;
         chkDocumentoOperador.WebTags = "";
         chkDocumentoOperador.Caption = "";
         AssignProp("", false, chkDocumentoOperador_Internalname, "TitleCaption", chkDocumentoOperador.Caption, !bGXsfl_257_Refreshing);
         chkDocumentoOperador.CheckedValue = "false";
         A105DocumentoOperador = StringUtil.StrToBool( StringUtil.BoolToStr( A105DocumentoOperador));
         n105DocumentoOperador = false;
         cmbavDocumentoativo.Name = "vDOCUMENTOATIVO";
         cmbavDocumentoativo.WebTags = "";
         cmbavDocumentoativo.addItem(StringUtil.BoolToStr( true), "SIM", 0);
         cmbavDocumentoativo.addItem(StringUtil.BoolToStr( false), "NÃO", 0);
         if ( cmbavDocumentoativo.ItemCount > 0 )
         {
            AV94DocumentoAtivo = StringUtil.StrToBool( cmbavDocumentoativo.getValidValue(StringUtil.BoolToStr( AV94DocumentoAtivo)));
            AssignAttri("", false, "AV94DocumentoAtivo", AV94DocumentoAtivo);
         }
         chkavDocumentobuscaavancada.Name = "vDOCUMENTOBUSCAAVANCADA";
         chkavDocumentobuscaavancada.WebTags = "";
         chkavDocumentobuscaavancada.Caption = "";
         AssignProp("", false, chkavDocumentobuscaavancada_Internalname, "TitleCaption", chkavDocumentobuscaavancada.Caption, true);
         chkavDocumentobuscaavancada.CheckedValue = "false";
         AV109DocumentoBuscaAvancada = StringUtil.StrToBool( StringUtil.BoolToStr( AV109DocumentoBuscaAvancada));
         AssignAttri("", false, "AV109DocumentoBuscaAvancada", AV109DocumentoBuscaAvancada);
         /* End function init_web_controls */
      }

      protected void StartGridControl257( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"257\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactiongroup1_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnatualizar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnvisualizar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnexcluir_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Código") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome do Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Nome do Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Processo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Processo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Subprocesso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Subprocesso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Inclusão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Alteração") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Processo Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id do Processo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id do Subprocesso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "do Encarregado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "da Persona") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Finalidade Tratamento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "da Categoria") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "de Dado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "de Coleta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Abrangência Geográgica") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "de Tratamento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "de Descarte") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "da Retenção") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "de dados") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Legal Normativa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Int Ext") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Criança Adolescente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Grupo Vulneráveis") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "de Segurança") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ativo?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Operador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Processo Nome") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV179GridActionGroup1), 4, 0, ".", "")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavGridactiongroup1_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavGridactiongroup1_Columnheaderclass));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactiongroup1_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV149BtnAtualizar));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavBtnatualizar_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavBtnatualizar_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnatualizar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnatualizar_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV148BtnVisualizar));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavBtnvisualizar_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavBtnvisualizar_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnvisualizar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnvisualizar_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV180BtnExcluir));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavBtnexcluir_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavBtnexcluir_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnexcluir_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnexcluir_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtDocumentoId_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtDocumentoId_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", AV205DocumentoNome_Grid);
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavDocumentonome_grid_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavDocumentonome_grid_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentonome_grid_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDocumentonome_grid_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A76DocumentoNome);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", AV206ProcessoNome_Grid);
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavProcessonome_grid_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavProcessonome_grid_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProcessonome_grid_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavProcessonome_grid_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A17ProcessoNome);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A21SubprocessoNome);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", AV207SubprocessoNome_Grid);
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSubprocessonome_grid_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSubprocessonome_grid_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSubprocessonome_grid_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavSubprocessonome_grid_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A108DocumentoDataInclusao, 10, 8, 0, 3, "/", ":", " "));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtDocumentoDataInclusao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtDocumentoDataInclusao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A109DocumentoDataAlteracao, 10, 8, 0, 3, "/", ":", " "));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtDocumentoDataAlteracao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtDocumentoDataAlteracao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106DocumentoProcessoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ProcessoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7EncarregadoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PersonaId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A77DocumentoFinalidadeTratamento);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27CategoriaId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30TipoDadoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FerramentaColetaId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AbrangenciaGeograficaId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39FrequenciaTratamentoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TipoDescarteId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48TempoRetencaoId), 8, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A78DocumentoPrevColetaDados));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A79DocumentoBaseLegalNorm);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A80DocumentoBaseLegalNormIntExt);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A82DocumentoDadosGrupoVul));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A83DocumentoMedidaSegurancaDesc);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A85DocumentoAtivo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A105DocumentoOperador));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A107DocumentoProcessoNome);
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
         edtavDocumentonome_Internalname = "vDOCUMENTONOME";
         dynavDocumentoprocessoid_Internalname = "vDOCUMENTOPROCESSOID";
         dynavSubprocessoid_Internalname = "vSUBPROCESSOID";
         dynavArearesponsavelid_Internalname = "vAREARESPONSAVELID";
         dynavDocumentocontroladorid_Internalname = "vDOCUMENTOCONTROLADORID";
         dynavEncarregadoid_Internalname = "vENCARREGADOID";
         dynavPersonaid_Internalname = "vPERSONAID";
         cmbavDocumentosituacao_Internalname = "vDOCUMENTOSITUACAO";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblBtnbuscaavancada_Internalname = "BTNBUSCAAVANCADA";
         tblTablemergedtextblock1_Internalname = "TABLEMERGEDTEXTBLOCK1";
         lblTabdados_title_Internalname = "TABDADOS_TITLE";
         edtavDocumentofinalidadetratamento_Internalname = "vDOCUMENTOFINALIDADETRATAMENTO";
         dynavCategoriaid_Internalname = "vCATEGORIAID";
         dynavTipodadoid_Internalname = "vTIPODADOID";
         dynavFerramentacoletaid_Internalname = "vFERRAMENTACOLETAID";
         dynavAbrangenciageograficaid_Internalname = "vABRANGENCIAGEOGRAFICAID";
         dynavFrequenciatratamentoid_Internalname = "vFREQUENCIATRATAMENTOID";
         dynavTipodescarteid_Internalname = "vTIPODESCARTEID";
         dynavTemporetencaoid_Internalname = "vTEMPORETENCAOID";
         chkavDocumentoprevcoletadados_Internalname = "vDOCUMENTOPREVCOLETADADOS";
         edtavDocumentobaselegalnorm_Internalname = "vDOCUMENTOBASELEGALNORM";
         edtavDocumentobaselegalnormintext_Internalname = "vDOCUMENTOBASELEGALNORMINTEXT";
         chkavDocumentodadosgrupovul_Internalname = "vDOCUMENTODADOSGRUPOVUL";
         chkavDocumentodadoscriancaadolesc_Internalname = "vDOCUMENTODADOSCRIANCAADOLESC";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divTabletratamentocontent_Internalname = "TABLETRATAMENTOCONTENT";
         lblTabdicionario_title_Internalname = "TABDICIONARIO_TITLE";
         dynavInformacaoid_Internalname = "vINFORMACAOID";
         chkavDocdicionariosensivel_Internalname = "vDOCDICIONARIOSENSIVEL";
         chkavDocdicionariopodeeliminar_Internalname = "vDOCDICIONARIOPODEELIMINAR";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         dynavHipotesetratamentoid_Internalname = "vHIPOTESETRATAMENTOID";
         cmbavDocdicionariotransfinter_Internalname = "vDOCDICIONARIOTRANSFINTER";
         dynavPaisid_Internalname = "vPAISID";
         divTabletransfint_Internalname = "TABLETRANSFINT";
         edtavDocdicionariotipotransfintergarantia_Internalname = "vDOCDICIONARIOTIPOTRANSFINTERGARANTIA";
         edtavDocdicionariofinalidade_Internalname = "vDOCDICIONARIOFINALIDADE";
         divTablediciocontent_Internalname = "TABLEDICIOCONTENT";
         lblTaboperador_title_Internalname = "TABOPERADOR_TITLE";
         dynavOperadores_Internalname = "vOPERADORES";
         chkavDocoperadorcoleta_Internalname = "vDOCOPERADORCOLETA";
         lblDocoperadorcoleta_righttext_Internalname = "DOCOPERADORCOLETA_RIGHTTEXT";
         tblTablemergeddocoperadorcoleta_Internalname = "TABLEMERGEDDOCOPERADORCOLETA";
         chkavDocoperadorretencao_Internalname = "vDOCOPERADORRETENCAO";
         lblDocoperadorretencao_righttext_Internalname = "DOCOPERADORRETENCAO_RIGHTTEXT";
         tblTablemergeddocoperadorretencao_Internalname = "TABLEMERGEDDOCOPERADORRETENCAO";
         chkavDocoperadorcompartilhamento_Internalname = "vDOCOPERADORCOMPARTILHAMENTO";
         lblDocoperadorcompartilhamento_righttext_Internalname = "DOCOPERADORCOMPARTILHAMENTO_RIGHTTEXT";
         tblTablemergeddocoperadorcompartilhamento_Internalname = "TABLEMERGEDDOCOPERADORCOMPARTILHAMENTO";
         chkavDocoperadoreliminacao_Internalname = "vDOCOPERADORELIMINACAO";
         lblDocoperadoreliminacao_righttext_Internalname = "DOCOPERADORELIMINACAO_RIGHTTEXT";
         tblTablemergeddocoperadoreliminacao_Internalname = "TABLEMERGEDDOCOPERADORELIMINACAO";
         chkavDocoperadorprocessamento_Internalname = "vDOCOPERADORPROCESSAMENTO";
         lblDocoperadorprocessamento_righttext_Internalname = "DOCOPERADORPROCESSAMENTO_RIGHTTEXT";
         tblTablemergeddocoperadorprocessamento_Internalname = "TABLEMERGEDDOCOPERADORPROCESSAMENTO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTabledadoscheck_Internalname = "TABLEDADOSCHECK";
         divTableoperadordados_Internalname = "TABLEOPERADORDADOS";
         divTableoperadorcontent_Internalname = "TABLEOPERADORCONTENT";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divTablebuscaavancada_Internalname = "TABLEBUSCAAVANCADA";
         bttBtnbtnbuscar_Internalname = "BTNBTNBUSCAR";
         bttBtnbtnlimpar_Internalname = "BTNBTNLIMPAR";
         bttBtnbtninserir_Internalname = "BTNBTNINSERIR";
         divTabledados_Internalname = "TABLEDADOS";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtavBtnatualizar_Internalname = "vBTNATUALIZAR";
         edtavBtnvisualizar_Internalname = "vBTNVISUALIZAR";
         edtavBtnexcluir_Internalname = "vBTNEXCLUIR";
         edtDocumentoId_Internalname = "DOCUMENTOID";
         edtavDocumentonome_grid_Internalname = "vDOCUMENTONOME_GRID";
         edtDocumentoNome_Internalname = "DOCUMENTONOME";
         edtavProcessonome_grid_Internalname = "vPROCESSONOME_GRID";
         edtProcessoNome_Internalname = "PROCESSONOME";
         edtSubprocessoNome_Internalname = "SUBPROCESSONOME";
         edtavSubprocessonome_grid_Internalname = "vSUBPROCESSONOME_GRID";
         edtDocumentoDataInclusao_Internalname = "DOCUMENTODATAINCLUSAO";
         edtDocumentoDataAlteracao_Internalname = "DOCUMENTODATAALTERACAO";
         edtDocumentoProcessoId_Internalname = "DOCUMENTOPROCESSOID";
         edtProcessoId_Internalname = "PROCESSOID";
         edtSubprocessoId_Internalname = "SUBPROCESSOID";
         edtEncarregadoId_Internalname = "ENCARREGADOID";
         edtPersonaId_Internalname = "PERSONAID";
         edtDocumentoFinalidadeTratamento_Internalname = "DOCUMENTOFINALIDADETRATAMENTO";
         edtCategoriaId_Internalname = "CATEGORIAID";
         edtTipoDadoId_Internalname = "TIPODADOID";
         edtFerramentaColetaId_Internalname = "FERRAMENTACOLETAID";
         edtAbrangenciaGeograficaId_Internalname = "ABRANGENCIAGEOGRAFICAID";
         edtFrequenciaTratamentoId_Internalname = "FREQUENCIATRATAMENTOID";
         edtTipoDescarteId_Internalname = "TIPODESCARTEID";
         edtTempoRetencaoId_Internalname = "TEMPORETENCAOID";
         chkDocumentoPrevColetaDados_Internalname = "DOCUMENTOPREVCOLETADADOS";
         edtDocumentoBaseLegalNorm_Internalname = "DOCUMENTOBASELEGALNORM";
         edtDocumentoBaseLegalNormIntExt_Internalname = "DOCUMENTOBASELEGALNORMINTEXT";
         chkDocumentoDadosCriancaAdolesc_Internalname = "DOCUMENTODADOSCRIANCAADOLESC";
         chkDocumentoDadosGrupoVul_Internalname = "DOCUMENTODADOSGRUPOVUL";
         edtDocumentoMedidaSegurancaDesc_Internalname = "DOCUMENTOMEDIDASEGURANCADESC";
         cmbDocumentoAtivo_Internalname = "DOCUMENTOATIVO";
         chkDocumentoOperador_Internalname = "DOCUMENTOOPERADOR";
         edtDocumentoProcessoNome_Internalname = "DOCUMENTOPROCESSONOME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablegrid_Internalname = "TABLEGRID";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain1_Internalname = "TABLEMAIN1";
         Ddo_grid_Internalname = "DDO_GRID";
         edtavDocumentoid_Internalname = "vDOCUMENTOID";
         cmbavDocumentoativo_Internalname = "vDOCUMENTOATIVO";
         chkavDocumentobuscaavancada_Internalname = "vDOCUMENTOBUSCAAVANCADA";
         Dvelop_confirmpanel_btnexcluir_Internalname = "DVELOP_CONFIRMPANEL_BTNEXCLUIR";
         tblTabledvelop_confirmpanel_btnexcluir_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNEXCLUIR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_documentodatainclusaoauxdatetext_Internalname = "vDDO_DOCUMENTODATAINCLUSAOAUXDATETEXT";
         Tfdocumentodatainclusao_rangepicker_Internalname = "TFDOCUMENTODATAINCLUSAO_RANGEPICKER";
         divDdo_documentodatainclusaoauxdates_Internalname = "DDO_DOCUMENTODATAINCLUSAOAUXDATES";
         edtavDdo_documentodataalteracaoauxdatetext_Internalname = "vDDO_DOCUMENTODATAALTERACAOAUXDATETEXT";
         Tfdocumentodataalteracao_rangepicker_Internalname = "TFDOCUMENTODATAALTERACAO_RANGEPICKER";
         divDdo_documentodataalteracaoauxdates_Internalname = "DDO_DOCUMENTODATAALTERACAOAUXDATES";
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
         chkavDocumentobuscaavancada.Caption = "";
         chkavDocoperadorprocessamento.Caption = "Doc Operador Processamento";
         chkavDocoperadoreliminacao.Caption = "Doc Operador Eliminacao";
         chkavDocoperadorcompartilhamento.Caption = "Doc Operador Compartilhamento";
         chkavDocoperadorretencao.Caption = "Doc Operador Retencao";
         chkavDocoperadorcoleta.Caption = "Doc Operador Coleta";
         chkavDocdicionariopodeeliminar.Caption = "PODE ELIMINAR";
         chkavDocdicionariosensivel.Caption = "SENSÍVEL";
         chkavDocumentodadoscriancaadolesc.Caption = "POSSUI DADOS DE CRIANÇA / ADOLESCENTE";
         chkavDocumentodadosgrupovul.Caption = "POSSUI DADOS DE GRUPOS VULNERÁVEIS";
         chkavDocumentoprevcoletadados.Caption = "PREVISÃO PARA COLETA DE DADOS";
         edtDocumentoProcessoNome_Jsonclick = "";
         chkDocumentoOperador.Caption = "";
         cmbDocumentoAtivo_Jsonclick = "";
         edtDocumentoMedidaSegurancaDesc_Jsonclick = "";
         chkDocumentoDadosGrupoVul.Caption = "";
         chkDocumentoDadosCriancaAdolesc.Caption = "";
         edtDocumentoBaseLegalNormIntExt_Jsonclick = "";
         edtDocumentoBaseLegalNorm_Jsonclick = "";
         chkDocumentoPrevColetaDados.Caption = "";
         edtTempoRetencaoId_Jsonclick = "";
         edtTipoDescarteId_Jsonclick = "";
         edtFrequenciaTratamentoId_Jsonclick = "";
         edtAbrangenciaGeograficaId_Jsonclick = "";
         edtFerramentaColetaId_Jsonclick = "";
         edtTipoDadoId_Jsonclick = "";
         edtCategoriaId_Jsonclick = "";
         edtDocumentoFinalidadeTratamento_Jsonclick = "";
         edtPersonaId_Jsonclick = "";
         edtEncarregadoId_Jsonclick = "";
         edtSubprocessoId_Jsonclick = "";
         edtProcessoId_Jsonclick = "";
         edtDocumentoProcessoId_Jsonclick = "";
         edtDocumentoDataAlteracao_Jsonclick = "";
         edtDocumentoDataAlteracao_Columnclass = "WWColumn CellMarginLeft hidden-xs";
         edtDocumentoDataInclusao_Jsonclick = "";
         edtDocumentoDataInclusao_Columnclass = "WWColumn CellMarginLeft hidden-xs";
         edtavSubprocessonome_grid_Jsonclick = "";
         edtavSubprocessonome_grid_Columnclass = "WWColumn";
         edtavSubprocessonome_grid_Visible = -1;
         edtavSubprocessonome_grid_Tooltiptext = "";
         edtavSubprocessonome_grid_Enabled = 1;
         edtSubprocessoNome_Jsonclick = "";
         edtProcessoNome_Jsonclick = "";
         edtavProcessonome_grid_Jsonclick = "";
         edtavProcessonome_grid_Columnclass = "WWColumn";
         edtavProcessonome_grid_Visible = -1;
         edtavProcessonome_grid_Tooltiptext = "";
         edtavProcessonome_grid_Enabled = 1;
         edtDocumentoNome_Jsonclick = "";
         edtavDocumentonome_grid_Jsonclick = "";
         edtavDocumentonome_grid_Columnclass = "WWColumn";
         edtavDocumentonome_grid_Visible = -1;
         edtavDocumentonome_grid_Tooltiptext = "";
         edtavDocumentonome_grid_Enabled = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Columnclass = "WWColumn CellMarginLeft";
         edtavBtnexcluir_Jsonclick = "";
         edtavBtnexcluir_Columnclass = "WWIconActionColumn";
         edtavBtnexcluir_Enabled = 1;
         edtavBtnvisualizar_Jsonclick = "";
         edtavBtnvisualizar_Columnclass = "WWIconActionColumn";
         edtavBtnvisualizar_Enabled = 1;
         edtavBtnatualizar_Jsonclick = "";
         edtavBtnatualizar_Columnclass = "WWIconActionColumn";
         edtavBtnatualizar_Enabled = 1;
         cmbavGridactiongroup1_Jsonclick = "";
         cmbavGridactiongroup1.Visible = -1;
         cmbavGridactiongroup1.Enabled = 1;
         cmbavGridactiongroup1_Columnclass = "WWActionGroupColumn";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         chkavDocoperadorcoleta.Enabled = 1;
         chkavDocoperadorretencao.Enabled = 1;
         chkavDocoperadorcompartilhamento.Enabled = 1;
         chkavDocoperadoreliminacao.Enabled = 1;
         chkavDocoperadorprocessamento.Enabled = 1;
         edtavBtnexcluir_Visible = -1;
         edtavBtnvisualizar_Visible = -1;
         edtavBtnatualizar_Visible = -1;
         cmbavGridactiongroup1_Class = "ConvertToDDO";
         edtDocumentoDataAlteracao_Columnheaderclass = "";
         edtDocumentoDataInclusao_Columnheaderclass = "";
         edtavSubprocessonome_grid_Columnheaderclass = "";
         edtavProcessonome_grid_Columnheaderclass = "";
         edtavDocumentonome_grid_Columnheaderclass = "";
         edtDocumentoId_Columnheaderclass = "";
         edtavBtnexcluir_Columnheaderclass = "";
         edtavBtnvisualizar_Columnheaderclass = "";
         edtavBtnatualizar_Columnheaderclass = "";
         cmbavGridactiongroup1_Columnheaderclass = "";
         lblBtnbuscaavancada_Caption = "<i class=\"FontColorIcon2 fas fa-toggle-on\"></i>";
         subGrid_Sortable = 0;
         edtavDdo_documentodataalteracaoauxdatetext_Jsonclick = "";
         edtavDdo_documentodatainclusaoauxdatetext_Jsonclick = "";
         chkavDocumentobuscaavancada.Visible = 1;
         cmbavDocumentoativo_Jsonclick = "";
         cmbavDocumentoativo.Visible = 1;
         edtavDocumentoid_Jsonclick = "";
         edtavDocumentoid_Visible = 1;
         dynavOperadores_Jsonclick = "";
         dynavOperadores.Enabled = 1;
         edtavDocdicionariofinalidade_Enabled = 1;
         edtavDocdicionariotipotransfintergarantia_Enabled = 1;
         dynavPaisid_Jsonclick = "";
         dynavPaisid.Enabled = 1;
         cmbavDocdicionariotransfinter_Jsonclick = "";
         cmbavDocdicionariotransfinter.Enabled = 1;
         dynavHipotesetratamentoid_Jsonclick = "";
         dynavHipotesetratamentoid.Enabled = 1;
         chkavDocdicionariopodeeliminar.Enabled = 1;
         chkavDocdicionariosensivel.Enabled = 1;
         dynavInformacaoid_Jsonclick = "";
         dynavInformacaoid.Enabled = 1;
         chkavDocumentodadoscriancaadolesc.Enabled = 1;
         chkavDocumentodadosgrupovul.Enabled = 1;
         edtavDocumentobaselegalnormintext_Jsonclick = "";
         edtavDocumentobaselegalnormintext_Enabled = 1;
         edtavDocumentobaselegalnorm_Jsonclick = "";
         edtavDocumentobaselegalnorm_Enabled = 1;
         chkavDocumentoprevcoletadados.Enabled = 1;
         dynavTemporetencaoid_Jsonclick = "";
         dynavTemporetencaoid.Enabled = 1;
         dynavTipodescarteid_Jsonclick = "";
         dynavTipodescarteid.Enabled = 1;
         dynavFrequenciatratamentoid_Jsonclick = "";
         dynavFrequenciatratamentoid.Enabled = 1;
         dynavAbrangenciageograficaid_Jsonclick = "";
         dynavAbrangenciageograficaid.Enabled = 1;
         dynavFerramentacoletaid_Jsonclick = "";
         dynavFerramentacoletaid.Enabled = 1;
         dynavTipodadoid_Jsonclick = "";
         dynavTipodadoid.Enabled = 1;
         dynavCategoriaid_Jsonclick = "";
         dynavCategoriaid.Enabled = 1;
         edtavDocumentofinalidadetratamento_Jsonclick = "";
         edtavDocumentofinalidadetratamento_Enabled = 1;
         divTablebuscaavancada_Visible = 1;
         cmbavDocumentosituacao_Jsonclick = "";
         cmbavDocumentosituacao.Enabled = 1;
         dynavPersonaid_Jsonclick = "";
         dynavPersonaid.Enabled = 1;
         dynavEncarregadoid_Jsonclick = "";
         dynavEncarregadoid.Enabled = 1;
         dynavDocumentocontroladorid_Jsonclick = "";
         dynavDocumentocontroladorid.Enabled = 1;
         dynavArearesponsavelid_Jsonclick = "";
         dynavArearesponsavelid.Enabled = 1;
         dynavSubprocessoid_Jsonclick = "";
         dynavSubprocessoid.Enabled = 1;
         dynavDocumentoprocessoid_Jsonclick = "";
         dynavDocumentoprocessoid.Enabled = 1;
         edtavDocumentonome_Jsonclick = "";
         edtavDocumentonome_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_btnexcluir_Confirmtype = "1";
         Dvelop_confirmpanel_btnexcluir_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnexcluir_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnexcluir_Confirmationtext = "Confirma a exclusão do documento?";
         Dvelop_confirmpanel_btnexcluir_Title = "Atenção!";
         Ddo_grid_Format = "8.0||";
         Ddo_grid_Filterisrange = "T|P|P";
         Ddo_grid_Filtertype = "Numeric|Date|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "4:DocumentoId|11:DocumentoDataInclusao|12:DocumentoDataAlteracao";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "";
         Gxuitabspanel_tabs1_Pagecount = 3;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Documento";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'cmbavGridactiongroup1'},{av:'edtavBtnatualizar_Columnheaderclass',ctrl:'vBTNATUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnvisualizar_Columnheaderclass',ctrl:'vBTNVISUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtDocumentoId_Columnheaderclass',ctrl:'DOCUMENTOID',prop:'Columnheaderclass'},{av:'edtavDocumentonome_grid_Columnheaderclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnheaderclass'},{av:'edtavProcessonome_grid_Columnheaderclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtavSubprocessonome_grid_Columnheaderclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtDocumentoDataInclusao_Columnheaderclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnheaderclass'},{av:'edtDocumentoDataAlteracao_Columnheaderclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnheaderclass'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'edtavBtnatualizar_Visible',ctrl:'vBTNATUALIZAR',prop:'Visible'},{av:'edtavBtnvisualizar_Visible',ctrl:'vBTNVISUALIZAR',prop:'Visible'},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'edtavBtnexcluir_Visible',ctrl:'vBTNEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E115R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E125R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E135R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E205R2',iparms:[{av:'A76DocumentoNome',fld:'DOCUMENTONOME',pic:''},{av:'A107DocumentoProcessoNome',fld:'DOCUMENTOPROCESSONOME',pic:''},{av:'A21SubprocessoNome',fld:'SUBPROCESSONOME',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'cmbDocumentoAtivo'},{av:'A85DocumentoAtivo',fld:'DOCUMENTOATIVO',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV205DocumentoNome_Grid',fld:'vDOCUMENTONOME_GRID',pic:''},{av:'AV206ProcessoNome_Grid',fld:'vPROCESSONOME_GRID',pic:''},{av:'AV207SubprocessoNome_Grid',fld:'vSUBPROCESSONOME_GRID',pic:''},{av:'cmbavGridactiongroup1'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'edtavBtnatualizar_Columnclass',ctrl:'vBTNATUALIZAR',prop:'Columnclass'},{av:'edtavBtnvisualizar_Columnclass',ctrl:'vBTNVISUALIZAR',prop:'Columnclass'},{av:'edtavBtnexcluir_Columnclass',ctrl:'vBTNEXCLUIR',prop:'Columnclass'},{av:'edtDocumentoId_Columnclass',ctrl:'DOCUMENTOID',prop:'Columnclass'},{av:'edtavDocumentonome_grid_Columnclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnclass'},{av:'edtavProcessonome_grid_Columnclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnclass'},{av:'edtavSubprocessonome_grid_Columnclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnclass'},{av:'edtDocumentoDataInclusao_Columnclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnclass'},{av:'edtDocumentoDataAlteracao_Columnclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnclass'},{av:'edtavDocumentonome_grid_Tooltiptext',ctrl:'vDOCUMENTONOME_GRID',prop:'Tooltiptext'},{av:'edtavProcessonome_grid_Tooltiptext',ctrl:'vPROCESSONOME_GRID',prop:'Tooltiptext'},{av:'edtavSubprocessonome_grid_Tooltiptext',ctrl:'vSUBPROCESSONOME_GRID',prop:'Tooltiptext'}]}");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","{handler:'E215R2',iparms:[{av:'cmbavGridactiongroup1'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",",oparms:[{av:'cmbavGridactiongroup1'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtavBtnatualizar_Columnheaderclass',ctrl:'vBTNATUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnvisualizar_Columnheaderclass',ctrl:'vBTNVISUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtDocumentoId_Columnheaderclass',ctrl:'DOCUMENTOID',prop:'Columnheaderclass'},{av:'edtavDocumentonome_grid_Columnheaderclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnheaderclass'},{av:'edtavProcessonome_grid_Columnheaderclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtavSubprocessonome_grid_Columnheaderclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtDocumentoDataInclusao_Columnheaderclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnheaderclass'},{av:'edtDocumentoDataAlteracao_Columnheaderclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnheaderclass'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'edtavBtnatualizar_Visible',ctrl:'vBTNATUALIZAR',prop:'Visible'},{av:'edtavBtnvisualizar_Visible',ctrl:'vBTNVISUALIZAR',prop:'Visible'},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'edtavBtnexcluir_Visible',ctrl:'vBTNEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("VBTNEXCLUIR.CLICK","{handler:'E225R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VBTNEXCLUIR.CLICK",",oparms:[{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'cmbavGridactiongroup1'},{av:'edtavBtnatualizar_Columnheaderclass',ctrl:'vBTNATUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnvisualizar_Columnheaderclass',ctrl:'vBTNVISUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtDocumentoId_Columnheaderclass',ctrl:'DOCUMENTOID',prop:'Columnheaderclass'},{av:'edtavDocumentonome_grid_Columnheaderclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnheaderclass'},{av:'edtavProcessonome_grid_Columnheaderclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtavSubprocessonome_grid_Columnheaderclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtDocumentoDataInclusao_Columnheaderclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnheaderclass'},{av:'edtDocumentoDataAlteracao_Columnheaderclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnheaderclass'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'edtavBtnatualizar_Visible',ctrl:'vBTNATUALIZAR',prop:'Visible'},{av:'edtavBtnvisualizar_Visible',ctrl:'vBTNVISUALIZAR',prop:'Visible'},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'edtavBtnexcluir_Visible',ctrl:'vBTNEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNEXCLUIR.CLOSE","{handler:'E145R2',iparms:[{av:'Dvelop_confirmpanel_btnexcluir_Result',ctrl:'DVELOP_CONFIRMPANEL_BTNEXCLUIR',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNEXCLUIR.CLOSE",",oparms:[{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'cmbavGridactiongroup1'},{av:'edtavBtnatualizar_Columnheaderclass',ctrl:'vBTNATUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnvisualizar_Columnheaderclass',ctrl:'vBTNVISUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtDocumentoId_Columnheaderclass',ctrl:'DOCUMENTOID',prop:'Columnheaderclass'},{av:'edtavDocumentonome_grid_Columnheaderclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnheaderclass'},{av:'edtavProcessonome_grid_Columnheaderclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtavSubprocessonome_grid_Columnheaderclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtDocumentoDataInclusao_Columnheaderclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnheaderclass'},{av:'edtDocumentoDataAlteracao_Columnheaderclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnheaderclass'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'edtavBtnatualizar_Visible',ctrl:'vBTNATUALIZAR',prop:'Visible'},{av:'edtavBtnvisualizar_Visible',ctrl:'vBTNVISUALIZAR',prop:'Visible'},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'edtavBtnexcluir_Visible',ctrl:'vBTNEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("'DOBTNBUSCAAVANCADA'","{handler:'E255R1',iparms:[{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''}]");
         setEventMetadata("'DOBTNBUSCAAVANCADA'",",oparms:[{av:'lblBtnbuscaavancada_Caption',ctrl:'BTNBUSCAAVANCADA',prop:'Caption'},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'divTablebuscaavancada_Visible',ctrl:'TABLEBUSCAAVANCADA',prop:'Visible'}]}");
         setEventMetadata("'DOBTNBUSCAR'","{handler:'E155R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'AV88DocumentoNome',fld:'vDOCUMENTONOME',pic:''},{av:'cmbavDocumentosituacao'},{av:'AV93DocumentoSituacao',fld:'vDOCUMENTOSITUACAO',pic:'ZZZ9'},{av:'AV126DocumentoFinalidadeTratamento',fld:'vDOCUMENTOFINALIDADETRATAMENTO',pic:''},{av:'AV135DocumentoBaseLegalNorm',fld:'vDOCUMENTOBASELEGALNORM',pic:''},{av:'AV136DocumentoBaseLegalNormIntExt',fld:'vDOCUMENTOBASELEGALNORMINTEXT',pic:''},{av:'cmbavDocdicionariotransfinter'},{av:'AV168DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''},{av:'AV155DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV156DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''}]");
         setEventMetadata("'DOBTNBUSCAR'",",oparms:[{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'cmbavGridactiongroup1'},{av:'edtavBtnatualizar_Columnheaderclass',ctrl:'vBTNATUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnvisualizar_Columnheaderclass',ctrl:'vBTNVISUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtDocumentoId_Columnheaderclass',ctrl:'DOCUMENTOID',prop:'Columnheaderclass'},{av:'edtavDocumentonome_grid_Columnheaderclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnheaderclass'},{av:'edtavProcessonome_grid_Columnheaderclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtavSubprocessonome_grid_Columnheaderclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtDocumentoDataInclusao_Columnheaderclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnheaderclass'},{av:'edtDocumentoDataAlteracao_Columnheaderclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnheaderclass'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'edtavBtnatualizar_Visible',ctrl:'vBTNATUALIZAR',prop:'Visible'},{av:'edtavBtnvisualizar_Visible',ctrl:'vBTNVISUALIZAR',prop:'Visible'},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'edtavBtnexcluir_Visible',ctrl:'vBTNEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("'DOBTNLIMPAR'","{handler:'E165R2',iparms:[{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV109DocumentoBuscaAvancada',fld:'vDOCUMENTOBUSCAAVANCADA',pic:''},{av:'AV210Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFDocumentoId',fld:'vTFDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV28TFDocumentoId_To',fld:'vTFDOCUMENTOID_TO',pic:'ZZZZZZZ9'},{av:'AV150TFDocumentoDataInclusao',fld:'vTFDOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'AV151TFDocumentoDataInclusao_To',fld:'vTFDOCUMENTODATAINCLUSAO_TO',pic:'99/99/99 99:99'},{av:'AV100TFDocumentoDataAlteracao',fld:'vTFDOCUMENTODATAALTERACAO',pic:'99/99/99 99:99'},{av:'AV101TFDocumentoDataAlteracao_To',fld:'vTFDOCUMENTODATAALTERACAO_TO',pic:'99/99/99 99:99'},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'AV88DocumentoNome',fld:'vDOCUMENTONOME',pic:''},{av:'cmbavDocumentosituacao'},{av:'AV93DocumentoSituacao',fld:'vDOCUMENTOSITUACAO',pic:'ZZZ9'},{av:'AV126DocumentoFinalidadeTratamento',fld:'vDOCUMENTOFINALIDADETRATAMENTO',pic:''},{av:'AV135DocumentoBaseLegalNorm',fld:'vDOCUMENTOBASELEGALNORM',pic:''},{av:'AV136DocumentoBaseLegalNormIntExt',fld:'vDOCUMENTOBASELEGALNORMINTEXT',pic:''},{av:'cmbavDocdicionariotransfinter'},{av:'AV168DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''},{av:'AV155DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV156DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''}]");
         setEventMetadata("'DOBTNLIMPAR'",",oparms:[{av:'AV88DocumentoNome',fld:'vDOCUMENTONOME',pic:''},{av:'dynavDocumentoprocessoid'},{av:'AV89DocumentoProcessoId',fld:'vDOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavSubprocessoid'},{av:'AV90SubprocessoId',fld:'vSUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynavEncarregadoid'},{av:'AV92EncarregadoId',fld:'vENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynavArearesponsavelid'},{av:'AV178AreaResponsavelId',fld:'vAREARESPONSAVELID',pic:'ZZZZZZZ9'},{av:'dynavDocumentocontroladorid'},{av:'AV91DocumentoControladorId',fld:'vDOCUMENTOCONTROLADORID',pic:'ZZZZZZZ9'},{av:'dynavPersonaid'},{av:'AV144PersonaId',fld:'vPERSONAID',pic:'ZZZZZZZ9'},{av:'cmbavDocumentosituacao'},{av:'AV93DocumentoSituacao',fld:'vDOCUMENTOSITUACAO',pic:'ZZZ9'},{av:'AV126DocumentoFinalidadeTratamento',fld:'vDOCUMENTOFINALIDADETRATAMENTO',pic:''},{av:'dynavCategoriaid'},{av:'AV129CategoriaId',fld:'vCATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynavTipodadoid'},{av:'AV130TipoDadoId',fld:'vTIPODADOID',pic:'ZZZZZZZ9'},{av:'dynavFerramentacoletaid'},{av:'AV127FerramentaColetaId',fld:'vFERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynavAbrangenciageograficaid'},{av:'AV128AbrangenciaGeograficaId',fld:'vABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynavFrequenciatratamentoid'},{av:'AV131FrequenciaTratamentoId',fld:'vFREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynavTipodescarteid'},{av:'AV133TipoDescarteId',fld:'vTIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynavTemporetencaoid'},{av:'AV134TempoRetencaoId',fld:'vTEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'AV132DocumentoPrevColetaDados',fld:'vDOCUMENTOPREVCOLETADADOS',pic:''},{av:'AV135DocumentoBaseLegalNorm',fld:'vDOCUMENTOBASELEGALNORM',pic:''},{av:'AV136DocumentoBaseLegalNormIntExt',fld:'vDOCUMENTOBASELEGALNORMINTEXT',pic:''},{av:'AV138DocumentoDadosGrupoVul',fld:'vDOCUMENTODADOSGRUPOVUL',pic:''},{av:'AV139DocumentoDadosCriancaAdolesc',fld:'vDOCUMENTODADOSCRIANCAADOLESC',pic:''},{av:'dynavInformacaoid'},{av:'AV110InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV116DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV117DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'dynavHipotesetratamentoid'},{av:'AV111HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'cmbavDocdicionariotransfinter'},{av:'AV168DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''},{av:'dynavPaisid'},{av:'AV113PaisId',fld:'vPAISID',pic:'ZZZZZZZ9'},{av:'dynavOperadores'},{av:'AV118Operadores',fld:'vOPERADORES',pic:'ZZZZZZZ9'},{av:'AV121DocOperadorColeta',fld:'vDOCOPERADORCOLETA',pic:''},{av:'AV122DocOperadorRetencao',fld:'vDOCOPERADORRETENCAO',pic:''},{av:'AV123DocOperadorCompartilhamento',fld:'vDOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'AV124DocOperadorEliminacao',fld:'vDOCOPERADORELIMINACAO',pic:''},{av:'AV125DocOperadorProcessamento',fld:'vDOCOPERADORPROCESSAMENTO',pic:''},{av:'AV166FiltrosDocumento',fld:'vFILTROSDOCUMENTO',pic:''},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'cmbavGridactiongroup1'},{av:'edtavBtnatualizar_Columnheaderclass',ctrl:'vBTNATUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnvisualizar_Columnheaderclass',ctrl:'vBTNVISUALIZAR',prop:'Columnheaderclass'},{av:'edtavBtnexcluir_Columnheaderclass',ctrl:'vBTNEXCLUIR',prop:'Columnheaderclass'},{av:'edtDocumentoId_Columnheaderclass',ctrl:'DOCUMENTOID',prop:'Columnheaderclass'},{av:'edtavDocumentonome_grid_Columnheaderclass',ctrl:'vDOCUMENTONOME_GRID',prop:'Columnheaderclass'},{av:'edtavProcessonome_grid_Columnheaderclass',ctrl:'vPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtavSubprocessonome_grid_Columnheaderclass',ctrl:'vSUBPROCESSONOME_GRID',prop:'Columnheaderclass'},{av:'edtDocumentoDataInclusao_Columnheaderclass',ctrl:'DOCUMENTODATAINCLUSAO',prop:'Columnheaderclass'},{av:'edtDocumentoDataAlteracao_Columnheaderclass',ctrl:'DOCUMENTODATAALTERACAO',prop:'Columnheaderclass'},{av:'AV179GridActionGroup1',fld:'vGRIDACTIONGROUP1',pic:'ZZZ9'},{av:'AV149BtnAtualizar',fld:'vBTNATUALIZAR',pic:''},{av:'AV148BtnVisualizar',fld:'vBTNVISUALIZAR',pic:''},{av:'AV180BtnExcluir',fld:'vBTNEXCLUIR',pic:''},{av:'AV188IsAuthorized_Excel',fld:'vISAUTHORIZED_EXCEL',pic:'',hsh:true},{av:'AV189IsAuthorized_PDF',fld:'vISAUTHORIZED_PDF',pic:'',hsh:true},{av:'edtavBtnatualizar_Visible',ctrl:'vBTNATUALIZAR',prop:'Visible'},{av:'edtavBtnvisualizar_Visible',ctrl:'vBTNVISUALIZAR',prop:'Visible'},{av:'AV192IsAuthorized_BtnExcluir',fld:'vISAUTHORIZED_BTNEXCLUIR',pic:'',hsh:true},{av:'edtavBtnexcluir_Visible',ctrl:'vBTNEXCLUIR',prop:'Visible'}]}");
         setEventMetadata("'DOBTNINSERIR'","{handler:'E175R2',iparms:[]");
         setEventMetadata("'DOBTNINSERIR'",",oparms:[]}");
         setEventMetadata("VBTNATUALIZAR.CLICK","{handler:'E235R2',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VBTNATUALIZAR.CLICK",",oparms:[]}");
         setEventMetadata("VBTNVISUALIZAR.CLICK","{handler:'E245R2',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VBTNVISUALIZAR.CLICK",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTOPROCESSOID","{handler:'Valid_Documentoprocessoid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTOPROCESSOID",",oparms:[]}");
         setEventMetadata("VALID_PROCESSOID","{handler:'Valid_Processoid',iparms:[]");
         setEventMetadata("VALID_PROCESSOID",",oparms:[]}");
         setEventMetadata("VALID_SUBPROCESSOID","{handler:'Valid_Subprocessoid',iparms:[]");
         setEventMetadata("VALID_SUBPROCESSOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Documentoprocessonome',iparms:[]");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Dvelop_confirmpanel_btnexcluir_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV166FiltrosDocumento = new SdtFiltrosDocumento(context);
         AV210Pgmname = "";
         AV150TFDocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         AV151TFDocumentoDataInclusao_To = (DateTime)(DateTime.MinValue);
         AV100TFDocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         AV101TFDocumentoDataAlteracao_To = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV76GridAppliedFilters = "";
         AV70DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV153DDO_DocumentoDataInclusaoAuxDateTo = DateTime.MinValue;
         AV103DDO_DocumentoDataAlteracaoAuxDateTo = DateTime.MinValue;
         AV152DDO_DocumentoDataInclusaoAuxDate = DateTime.MinValue;
         AV102DDO_DocumentoDataAlteracaoAuxDate = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV88DocumentoNome = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTabdados_title_Jsonclick = "";
         AV126DocumentoFinalidadeTratamento = "";
         AV135DocumentoBaseLegalNorm = "";
         AV136DocumentoBaseLegalNormIntExt = "";
         lblTabdicionario_title_Jsonclick = "";
         AV155DocDicionarioTipoTransfInterGarantia = "";
         AV156DocDicionarioFinalidade = "";
         lblTaboperador_title_Jsonclick = "";
         bttBtnbtnbuscar_Jsonclick = "";
         bttBtnbtnlimpar_Jsonclick = "";
         bttBtnbtninserir_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV154DDO_DocumentoDataInclusaoAuxDateText = "";
         ucTfdocumentodatainclusao_rangepicker = new GXUserControl();
         AV104DDO_DocumentoDataAlteracaoAuxDateText = "";
         ucTfdocumentodataalteracao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV149BtnAtualizar = "";
         AV148BtnVisualizar = "";
         AV180BtnExcluir = "";
         AV205DocumentoNome_Grid = "";
         A76DocumentoNome = "";
         AV206ProcessoNome_Grid = "";
         A17ProcessoNome = "";
         A21SubprocessoNome = "";
         AV207SubprocessoNome_Grid = "";
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         A77DocumentoFinalidadeTratamento = "";
         A79DocumentoBaseLegalNorm = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A83DocumentoMedidaSegurancaDesc = "";
         A107DocumentoProcessoNome = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H005R2_A16ProcessoId = new int[1] ;
         H005R2_n16ProcessoId = new bool[] {false} ;
         H005R2_A17ProcessoNome = new string[] {""} ;
         H005R2_A19ProcessoAtivo = new bool[] {false} ;
         H005R3_A20SubprocessoId = new int[1] ;
         H005R3_n20SubprocessoId = new bool[] {false} ;
         H005R3_A21SubprocessoNome = new string[] {""} ;
         H005R3_A23SubprocessoAtivo = new bool[] {false} ;
         H005R4_A24AreaResponsavelId = new int[1] ;
         H005R4_A25AreaResponsavelNome = new string[] {""} ;
         H005R4_A26AreaResponsavelAtivo = new bool[] {false} ;
         H005R5_A10ControladorId = new int[1] ;
         H005R5_A11ControladorNome = new string[] {""} ;
         H005R5_A12ControladorAtivo = new bool[] {false} ;
         H005R6_A7EncarregadoId = new int[1] ;
         H005R6_n7EncarregadoId = new bool[] {false} ;
         H005R6_A8EncarregadoNome = new string[] {""} ;
         H005R6_A9EncarregadoAtivo = new bool[] {false} ;
         H005R7_A13PersonaId = new int[1] ;
         H005R7_n13PersonaId = new bool[] {false} ;
         H005R7_A14PersonaNome = new string[] {""} ;
         H005R7_A15PersonaAtivo = new bool[] {false} ;
         H005R8_A27CategoriaId = new int[1] ;
         H005R8_n27CategoriaId = new bool[] {false} ;
         H005R8_A28CategoriaNome = new string[] {""} ;
         H005R8_A29CategoriaAtivo = new bool[] {false} ;
         H005R9_A30TipoDadoId = new int[1] ;
         H005R9_n30TipoDadoId = new bool[] {false} ;
         H005R9_A31TipoDadoNome = new string[] {""} ;
         H005R9_A32TipoDadoAtivo = new bool[] {false} ;
         H005R10_A33FerramentaColetaId = new int[1] ;
         H005R10_n33FerramentaColetaId = new bool[] {false} ;
         H005R10_A34FerramentaColetaNome = new string[] {""} ;
         H005R10_A35FerramentaColetaAtivo = new bool[] {false} ;
         H005R11_A36AbrangenciaGeograficaId = new int[1] ;
         H005R11_n36AbrangenciaGeograficaId = new bool[] {false} ;
         H005R11_A37AbrangenciaGeograficaNome = new string[] {""} ;
         H005R12_A39FrequenciaTratamentoId = new int[1] ;
         H005R12_n39FrequenciaTratamentoId = new bool[] {false} ;
         H005R12_A40FrequenciaTratamentoNome = new string[] {""} ;
         H005R12_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         H005R13_A45TipoDescarteId = new int[1] ;
         H005R13_n45TipoDescarteId = new bool[] {false} ;
         H005R13_A46TipoDescarteNome = new string[] {""} ;
         H005R13_A47TipoDescarteAtivo = new bool[] {false} ;
         H005R14_A48TempoRetencaoId = new int[1] ;
         H005R14_n48TempoRetencaoId = new bool[] {false} ;
         H005R14_A49TempoRetencaoNome = new string[] {""} ;
         H005R14_A50TempoRetencaoAtivo = new bool[] {false} ;
         H005R15_A69InformacaoId = new int[1] ;
         H005R15_A70InformacaoNome = new string[] {""} ;
         H005R15_A71InformacaoAtivo = new bool[] {false} ;
         H005R16_A72HipoteseTratamentoId = new int[1] ;
         H005R16_A73HipoteseTratamentoNome = new string[] {""} ;
         H005R16_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         H005R17_A4PaisId = new int[1] ;
         H005R17_A5PaisNome = new string[] {""} ;
         H005R17_A6PaisAtivo = new bool[] {false} ;
         H005R18_A42OperadorId = new int[1] ;
         H005R18_A43OperadorNome = new string[] {""} ;
         H005R18_A44OperadorAtivo = new bool[] {false} ;
         AV167Documentos = new GxSimpleCollection<int>();
         H005R19_A107DocumentoProcessoNome = new string[] {""} ;
         H005R19_A105DocumentoOperador = new bool[] {false} ;
         H005R19_n105DocumentoOperador = new bool[] {false} ;
         H005R19_A85DocumentoAtivo = new bool[] {false} ;
         H005R19_n85DocumentoAtivo = new bool[] {false} ;
         H005R19_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         H005R19_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         H005R19_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         H005R19_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         H005R19_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H005R19_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         H005R19_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         H005R19_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         H005R19_A79DocumentoBaseLegalNorm = new string[] {""} ;
         H005R19_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         H005R19_A78DocumentoPrevColetaDados = new bool[] {false} ;
         H005R19_n78DocumentoPrevColetaDados = new bool[] {false} ;
         H005R19_A48TempoRetencaoId = new int[1] ;
         H005R19_n48TempoRetencaoId = new bool[] {false} ;
         H005R19_A45TipoDescarteId = new int[1] ;
         H005R19_n45TipoDescarteId = new bool[] {false} ;
         H005R19_A39FrequenciaTratamentoId = new int[1] ;
         H005R19_n39FrequenciaTratamentoId = new bool[] {false} ;
         H005R19_A36AbrangenciaGeograficaId = new int[1] ;
         H005R19_n36AbrangenciaGeograficaId = new bool[] {false} ;
         H005R19_A33FerramentaColetaId = new int[1] ;
         H005R19_n33FerramentaColetaId = new bool[] {false} ;
         H005R19_A30TipoDadoId = new int[1] ;
         H005R19_n30TipoDadoId = new bool[] {false} ;
         H005R19_A27CategoriaId = new int[1] ;
         H005R19_n27CategoriaId = new bool[] {false} ;
         H005R19_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         H005R19_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         H005R19_A13PersonaId = new int[1] ;
         H005R19_n13PersonaId = new bool[] {false} ;
         H005R19_A7EncarregadoId = new int[1] ;
         H005R19_n7EncarregadoId = new bool[] {false} ;
         H005R19_A20SubprocessoId = new int[1] ;
         H005R19_n20SubprocessoId = new bool[] {false} ;
         H005R19_A16ProcessoId = new int[1] ;
         H005R19_n16ProcessoId = new bool[] {false} ;
         H005R19_A106DocumentoProcessoId = new int[1] ;
         H005R19_n106DocumentoProcessoId = new bool[] {false} ;
         H005R19_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H005R19_n109DocumentoDataAlteracao = new bool[] {false} ;
         H005R19_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H005R19_n108DocumentoDataInclusao = new bool[] {false} ;
         H005R19_A21SubprocessoNome = new string[] {""} ;
         H005R19_A17ProcessoNome = new string[] {""} ;
         H005R19_A76DocumentoNome = new string[] {""} ;
         H005R19_n76DocumentoNome = new bool[] {false} ;
         H005R19_A75DocumentoId = new int[1] ;
         H005R20_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV171FileName = "";
         AV177Caminho = "";
         AV175ContentType = "";
         AV23Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         ucDvelop_confirmpanel_btnexcluir = new GXUserControl();
         lblDocoperadorprocessamento_righttext_Jsonclick = "";
         lblDocoperadoreliminacao_righttext_Jsonclick = "";
         lblDocoperadorcompartilhamento_righttext_Jsonclick = "";
         lblDocoperadorretencao_righttext_Jsonclick = "";
         lblDocoperadorcoleta_righttext_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblBtnbuscaavancada_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoww__default(),
            new Object[][] {
                new Object[] {
               H005R2_A16ProcessoId, H005R2_A17ProcessoNome, H005R2_A19ProcessoAtivo
               }
               , new Object[] {
               H005R3_A20SubprocessoId, H005R3_A21SubprocessoNome, H005R3_A23SubprocessoAtivo
               }
               , new Object[] {
               H005R4_A24AreaResponsavelId, H005R4_A25AreaResponsavelNome, H005R4_A26AreaResponsavelAtivo
               }
               , new Object[] {
               H005R5_A10ControladorId, H005R5_A11ControladorNome, H005R5_A12ControladorAtivo
               }
               , new Object[] {
               H005R6_A7EncarregadoId, H005R6_A8EncarregadoNome, H005R6_A9EncarregadoAtivo
               }
               , new Object[] {
               H005R7_A13PersonaId, H005R7_A14PersonaNome, H005R7_A15PersonaAtivo
               }
               , new Object[] {
               H005R8_A27CategoriaId, H005R8_A28CategoriaNome, H005R8_A29CategoriaAtivo
               }
               , new Object[] {
               H005R9_A30TipoDadoId, H005R9_A31TipoDadoNome, H005R9_A32TipoDadoAtivo
               }
               , new Object[] {
               H005R10_A33FerramentaColetaId, H005R10_A34FerramentaColetaNome, H005R10_A35FerramentaColetaAtivo
               }
               , new Object[] {
               H005R11_A36AbrangenciaGeograficaId, H005R11_A37AbrangenciaGeograficaNome
               }
               , new Object[] {
               H005R12_A39FrequenciaTratamentoId, H005R12_A40FrequenciaTratamentoNome, H005R12_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               H005R13_A45TipoDescarteId, H005R13_A46TipoDescarteNome, H005R13_A47TipoDescarteAtivo
               }
               , new Object[] {
               H005R14_A48TempoRetencaoId, H005R14_A49TempoRetencaoNome, H005R14_A50TempoRetencaoAtivo
               }
               , new Object[] {
               H005R15_A69InformacaoId, H005R15_A70InformacaoNome, H005R15_A71InformacaoAtivo
               }
               , new Object[] {
               H005R16_A72HipoteseTratamentoId, H005R16_A73HipoteseTratamentoNome, H005R16_A74HipoteseTratamentoAtivo
               }
               , new Object[] {
               H005R17_A4PaisId, H005R17_A5PaisNome, H005R17_A6PaisAtivo
               }
               , new Object[] {
               H005R18_A42OperadorId, H005R18_A43OperadorNome, H005R18_A44OperadorAtivo
               }
               , new Object[] {
               H005R19_A107DocumentoProcessoNome, H005R19_A105DocumentoOperador, H005R19_n105DocumentoOperador, H005R19_A85DocumentoAtivo, H005R19_n85DocumentoAtivo, H005R19_A83DocumentoMedidaSegurancaDesc, H005R19_n83DocumentoMedidaSegurancaDesc, H005R19_A82DocumentoDadosGrupoVul, H005R19_n82DocumentoDadosGrupoVul, H005R19_A81DocumentoDadosCriancaAdolesc,
               H005R19_n81DocumentoDadosCriancaAdolesc, H005R19_A80DocumentoBaseLegalNormIntExt, H005R19_n80DocumentoBaseLegalNormIntExt, H005R19_A79DocumentoBaseLegalNorm, H005R19_n79DocumentoBaseLegalNorm, H005R19_A78DocumentoPrevColetaDados, H005R19_n78DocumentoPrevColetaDados, H005R19_A48TempoRetencaoId, H005R19_n48TempoRetencaoId, H005R19_A45TipoDescarteId,
               H005R19_n45TipoDescarteId, H005R19_A39FrequenciaTratamentoId, H005R19_n39FrequenciaTratamentoId, H005R19_A36AbrangenciaGeograficaId, H005R19_n36AbrangenciaGeograficaId, H005R19_A33FerramentaColetaId, H005R19_n33FerramentaColetaId, H005R19_A30TipoDadoId, H005R19_n30TipoDadoId, H005R19_A27CategoriaId,
               H005R19_n27CategoriaId, H005R19_A77DocumentoFinalidadeTratamento, H005R19_n77DocumentoFinalidadeTratamento, H005R19_A13PersonaId, H005R19_n13PersonaId, H005R19_A7EncarregadoId, H005R19_n7EncarregadoId, H005R19_A20SubprocessoId, H005R19_n20SubprocessoId, H005R19_A16ProcessoId,
               H005R19_n16ProcessoId, H005R19_A106DocumentoProcessoId, H005R19_n106DocumentoProcessoId, H005R19_A109DocumentoDataAlteracao, H005R19_n109DocumentoDataAlteracao, H005R19_A108DocumentoDataInclusao, H005R19_n108DocumentoDataInclusao, H005R19_A21SubprocessoNome, H005R19_A17ProcessoNome, H005R19_A76DocumentoNome,
               H005R19_n76DocumentoNome, H005R19_A75DocumentoId
               }
               , new Object[] {
               H005R20_AGRID_nRecordCount
               }
            }
         );
         AV210Pgmname = "DocumentoWW";
         /* GeneXus formulas. */
         AV210Pgmname = "DocumentoWW";
         context.Gx_err = 0;
         edtavBtnatualizar_Enabled = 0;
         edtavBtnvisualizar_Enabled = 0;
         edtavBtnexcluir_Enabled = 0;
         edtavDocumentonome_grid_Enabled = 0;
         edtavProcessonome_grid_Enabled = 0;
         edtavSubprocessonome_grid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV93DocumentoSituacao ;
      private short AV179GridActionGroup1 ;
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
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_257 ;
      private int nGXsfl_257_idx=1 ;
      private int AV27TFDocumentoId ;
      private int AV28TFDocumentoId_To ;
      private int AV89DocumentoProcessoId ;
      private int AV90SubprocessoId ;
      private int AV178AreaResponsavelId ;
      private int AV91DocumentoControladorId ;
      private int AV92EncarregadoId ;
      private int AV144PersonaId ;
      private int AV129CategoriaId ;
      private int AV130TipoDadoId ;
      private int AV127FerramentaColetaId ;
      private int AV128AbrangenciaGeograficaId ;
      private int AV131FrequenciaTratamentoId ;
      private int AV133TipoDescarteId ;
      private int AV134TempoRetencaoId ;
      private int AV110InformacaoId ;
      private int AV111HipoteseTratamentoId ;
      private int AV113PaisId ;
      private int AV118Operadores ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavDocumentonome_Enabled ;
      private int divTablebuscaavancada_Visible ;
      private int edtavDocumentofinalidadetratamento_Enabled ;
      private int edtavDocumentobaselegalnorm_Enabled ;
      private int edtavDocumentobaselegalnormintext_Enabled ;
      private int edtavDocdicionariotipotransfintergarantia_Enabled ;
      private int edtavDocdicionariofinalidade_Enabled ;
      private int AV95DocumentoId ;
      private int edtavDocumentoid_Visible ;
      private int A75DocumentoId ;
      private int A106DocumentoProcessoId ;
      private int A16ProcessoId ;
      private int A20SubprocessoId ;
      private int A7EncarregadoId ;
      private int A13PersonaId ;
      private int A27CategoriaId ;
      private int A30TipoDadoId ;
      private int A33FerramentaColetaId ;
      private int A36AbrangenciaGeograficaId ;
      private int A39FrequenciaTratamentoId ;
      private int A45TipoDescarteId ;
      private int A48TempoRetencaoId ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtavBtnatualizar_Enabled ;
      private int edtavBtnvisualizar_Enabled ;
      private int edtavBtnexcluir_Enabled ;
      private int edtavDocumentonome_grid_Enabled ;
      private int edtavProcessonome_grid_Enabled ;
      private int edtavSubprocessonome_grid_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV73PageToGo ;
      private int AV181DocumentoId_Selected ;
      private int AV112CompartTercExternoId ;
      private int edtavBtnatualizar_Visible ;
      private int edtavBtnvisualizar_Visible ;
      private int edtavBtnexcluir_Visible ;
      private int AV211GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavDocumentonome_grid_Visible ;
      private int edtavProcessonome_grid_Visible ;
      private int edtavSubprocessonome_grid_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV74GridCurrentPage ;
      private long AV75GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Dvelop_confirmpanel_btnexcluir_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_257_idx="0001" ;
      private string AV210Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Format ;
      private string Dvelop_confirmpanel_btnexcluir_Title ;
      private string Dvelop_confirmpanel_btnexcluir_Confirmationtext ;
      private string Dvelop_confirmpanel_btnexcluir_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnexcluir_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnexcluir_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnexcluir_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnexcluir_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTabledados_Internalname ;
      private string edtavDocumentonome_Internalname ;
      private string TempTags ;
      private string edtavDocumentonome_Jsonclick ;
      private string dynavDocumentoprocessoid_Internalname ;
      private string dynavDocumentoprocessoid_Jsonclick ;
      private string dynavSubprocessoid_Internalname ;
      private string dynavSubprocessoid_Jsonclick ;
      private string dynavArearesponsavelid_Internalname ;
      private string dynavArearesponsavelid_Jsonclick ;
      private string dynavDocumentocontroladorid_Internalname ;
      private string dynavDocumentocontroladorid_Jsonclick ;
      private string dynavEncarregadoid_Internalname ;
      private string dynavEncarregadoid_Jsonclick ;
      private string dynavPersonaid_Internalname ;
      private string dynavPersonaid_Jsonclick ;
      private string cmbavDocumentosituacao_Internalname ;
      private string cmbavDocumentosituacao_Jsonclick ;
      private string divTablebuscaavancada_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTabdados_title_Internalname ;
      private string lblTabdados_title_Jsonclick ;
      private string divTabletratamentocontent_Internalname ;
      private string edtavDocumentofinalidadetratamento_Internalname ;
      private string edtavDocumentofinalidadetratamento_Jsonclick ;
      private string dynavCategoriaid_Internalname ;
      private string dynavCategoriaid_Jsonclick ;
      private string dynavTipodadoid_Internalname ;
      private string dynavTipodadoid_Jsonclick ;
      private string dynavFerramentacoletaid_Internalname ;
      private string dynavFerramentacoletaid_Jsonclick ;
      private string dynavAbrangenciageograficaid_Internalname ;
      private string dynavAbrangenciageograficaid_Jsonclick ;
      private string dynavFrequenciatratamentoid_Internalname ;
      private string dynavFrequenciatratamentoid_Jsonclick ;
      private string dynavTipodescarteid_Internalname ;
      private string dynavTipodescarteid_Jsonclick ;
      private string dynavTemporetencaoid_Internalname ;
      private string dynavTemporetencaoid_Jsonclick ;
      private string chkavDocumentoprevcoletadados_Internalname ;
      private string edtavDocumentobaselegalnorm_Internalname ;
      private string edtavDocumentobaselegalnorm_Jsonclick ;
      private string edtavDocumentobaselegalnormintext_Internalname ;
      private string edtavDocumentobaselegalnormintext_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string chkavDocumentodadosgrupovul_Internalname ;
      private string chkavDocumentodadoscriancaadolesc_Internalname ;
      private string lblTabdicionario_title_Internalname ;
      private string lblTabdicionario_title_Jsonclick ;
      private string divTablediciocontent_Internalname ;
      private string dynavInformacaoid_Internalname ;
      private string dynavInformacaoid_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string chkavDocdicionariosensivel_Internalname ;
      private string chkavDocdicionariopodeeliminar_Internalname ;
      private string dynavHipotesetratamentoid_Internalname ;
      private string dynavHipotesetratamentoid_Jsonclick ;
      private string divTabletransfint_Internalname ;
      private string cmbavDocdicionariotransfinter_Internalname ;
      private string cmbavDocdicionariotransfinter_Jsonclick ;
      private string dynavPaisid_Internalname ;
      private string dynavPaisid_Jsonclick ;
      private string edtavDocdicionariotipotransfintergarantia_Internalname ;
      private string edtavDocdicionariofinalidade_Internalname ;
      private string lblTaboperador_title_Internalname ;
      private string lblTaboperador_title_Jsonclick ;
      private string divTableoperadorcontent_Internalname ;
      private string divTableoperadordados_Internalname ;
      private string dynavOperadores_Internalname ;
      private string dynavOperadores_Jsonclick ;
      private string divTabledadoscheck_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtnbtnbuscar_Internalname ;
      private string bttBtnbtnbuscar_Jsonclick ;
      private string bttBtnbtnlimpar_Internalname ;
      private string bttBtnbtnlimpar_Jsonclick ;
      private string bttBtnbtninserir_Internalname ;
      private string bttBtnbtninserir_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtavDocumentoid_Internalname ;
      private string edtavDocumentoid_Jsonclick ;
      private string cmbavDocumentoativo_Internalname ;
      private string cmbavDocumentoativo_Jsonclick ;
      private string chkavDocumentobuscaavancada_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_documentodatainclusaoauxdates_Internalname ;
      private string edtavDdo_documentodatainclusaoauxdatetext_Internalname ;
      private string edtavDdo_documentodatainclusaoauxdatetext_Jsonclick ;
      private string Tfdocumentodatainclusao_rangepicker_Internalname ;
      private string divDdo_documentodataalteracaoauxdates_Internalname ;
      private string edtavDdo_documentodataalteracaoauxdatetext_Internalname ;
      private string edtavDdo_documentodataalteracaoauxdatetext_Jsonclick ;
      private string Tfdocumentodataalteracao_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string AV149BtnAtualizar ;
      private string edtavBtnatualizar_Internalname ;
      private string AV148BtnVisualizar ;
      private string edtavBtnvisualizar_Internalname ;
      private string AV180BtnExcluir ;
      private string edtavBtnexcluir_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtavDocumentonome_grid_Internalname ;
      private string edtDocumentoNome_Internalname ;
      private string edtavProcessonome_grid_Internalname ;
      private string edtProcessoNome_Internalname ;
      private string edtSubprocessoNome_Internalname ;
      private string edtavSubprocessonome_grid_Internalname ;
      private string edtDocumentoDataInclusao_Internalname ;
      private string edtDocumentoDataAlteracao_Internalname ;
      private string edtDocumentoProcessoId_Internalname ;
      private string edtProcessoId_Internalname ;
      private string edtSubprocessoId_Internalname ;
      private string edtEncarregadoId_Internalname ;
      private string edtPersonaId_Internalname ;
      private string edtDocumentoFinalidadeTratamento_Internalname ;
      private string edtCategoriaId_Internalname ;
      private string edtTipoDadoId_Internalname ;
      private string edtFerramentaColetaId_Internalname ;
      private string edtAbrangenciaGeograficaId_Internalname ;
      private string edtFrequenciaTratamentoId_Internalname ;
      private string edtTipoDescarteId_Internalname ;
      private string edtTempoRetencaoId_Internalname ;
      private string chkDocumentoPrevColetaDados_Internalname ;
      private string edtDocumentoBaseLegalNorm_Internalname ;
      private string edtDocumentoBaseLegalNormIntExt_Internalname ;
      private string chkDocumentoDadosCriancaAdolesc_Internalname ;
      private string chkDocumentoDadosGrupoVul_Internalname ;
      private string edtDocumentoMedidaSegurancaDesc_Internalname ;
      private string cmbDocumentoAtivo_Internalname ;
      private string chkDocumentoOperador_Internalname ;
      private string edtDocumentoProcessoNome_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string chkavDocoperadorcoleta_Internalname ;
      private string chkavDocoperadorretencao_Internalname ;
      private string chkavDocoperadorcompartilhamento_Internalname ;
      private string chkavDocoperadoreliminacao_Internalname ;
      private string chkavDocoperadorprocessamento_Internalname ;
      private string lblBtnbuscaavancada_Caption ;
      private string lblBtnbuscaavancada_Internalname ;
      private string GXt_char2 ;
      private string cmbavGridactiongroup1_Columnheaderclass ;
      private string edtavBtnatualizar_Columnheaderclass ;
      private string edtavBtnvisualizar_Columnheaderclass ;
      private string edtavBtnexcluir_Columnheaderclass ;
      private string edtDocumentoId_Columnheaderclass ;
      private string edtavDocumentonome_grid_Columnheaderclass ;
      private string edtavProcessonome_grid_Columnheaderclass ;
      private string edtavSubprocessonome_grid_Columnheaderclass ;
      private string edtDocumentoDataInclusao_Columnheaderclass ;
      private string edtDocumentoDataAlteracao_Columnheaderclass ;
      private string cmbavGridactiongroup1_Class ;
      private string cmbavGridactiongroup1_Columnclass ;
      private string edtavBtnatualizar_Columnclass ;
      private string edtavBtnvisualizar_Columnclass ;
      private string edtavBtnexcluir_Columnclass ;
      private string edtDocumentoId_Columnclass ;
      private string edtavDocumentonome_grid_Columnclass ;
      private string edtavProcessonome_grid_Columnclass ;
      private string edtavSubprocessonome_grid_Columnclass ;
      private string edtDocumentoDataInclusao_Columnclass ;
      private string edtDocumentoDataAlteracao_Columnclass ;
      private string edtavDocumentonome_grid_Tooltiptext ;
      private string edtavProcessonome_grid_Tooltiptext ;
      private string edtavSubprocessonome_grid_Tooltiptext ;
      private string GXEncryptionTmp ;
      private string tblTabledvelop_confirmpanel_btnexcluir_Internalname ;
      private string Dvelop_confirmpanel_btnexcluir_Internalname ;
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
      private string tblTablemergedtextblock1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblBtnbuscaavancada_Jsonclick ;
      private string sGXsfl_257_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtavBtnatualizar_Jsonclick ;
      private string edtavBtnvisualizar_Jsonclick ;
      private string edtavBtnexcluir_Jsonclick ;
      private string edtDocumentoId_Jsonclick ;
      private string edtavDocumentonome_grid_Jsonclick ;
      private string edtDocumentoNome_Jsonclick ;
      private string edtavProcessonome_grid_Jsonclick ;
      private string edtProcessoNome_Jsonclick ;
      private string edtSubprocessoNome_Jsonclick ;
      private string edtavSubprocessonome_grid_Jsonclick ;
      private string edtDocumentoDataInclusao_Jsonclick ;
      private string edtDocumentoDataAlteracao_Jsonclick ;
      private string edtDocumentoProcessoId_Jsonclick ;
      private string edtProcessoId_Jsonclick ;
      private string edtSubprocessoId_Jsonclick ;
      private string edtEncarregadoId_Jsonclick ;
      private string edtPersonaId_Jsonclick ;
      private string edtDocumentoFinalidadeTratamento_Jsonclick ;
      private string edtCategoriaId_Jsonclick ;
      private string edtTipoDadoId_Jsonclick ;
      private string edtFerramentaColetaId_Jsonclick ;
      private string edtAbrangenciaGeograficaId_Jsonclick ;
      private string edtFrequenciaTratamentoId_Jsonclick ;
      private string edtTipoDescarteId_Jsonclick ;
      private string edtTempoRetencaoId_Jsonclick ;
      private string edtDocumentoBaseLegalNorm_Jsonclick ;
      private string edtDocumentoBaseLegalNormIntExt_Jsonclick ;
      private string edtDocumentoMedidaSegurancaDesc_Jsonclick ;
      private string cmbDocumentoAtivo_Jsonclick ;
      private string edtDocumentoProcessoNome_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV150TFDocumentoDataInclusao ;
      private DateTime AV151TFDocumentoDataInclusao_To ;
      private DateTime AV100TFDocumentoDataAlteracao ;
      private DateTime AV101TFDocumentoDataAlteracao_To ;
      private DateTime A108DocumentoDataInclusao ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime AV153DDO_DocumentoDataInclusaoAuxDateTo ;
      private DateTime AV103DDO_DocumentoDataAlteracaoAuxDateTo ;
      private DateTime AV152DDO_DocumentoDataInclusaoAuxDate ;
      private DateTime AV102DDO_DocumentoDataAlteracaoAuxDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV109DocumentoBuscaAvancada ;
      private bool AV188IsAuthorized_Excel ;
      private bool AV189IsAuthorized_PDF ;
      private bool AV14OrderedDsc ;
      private bool AV132DocumentoPrevColetaDados ;
      private bool AV138DocumentoDadosGrupoVul ;
      private bool AV139DocumentoDadosCriancaAdolesc ;
      private bool AV116DocDicionarioSensivel ;
      private bool AV117DocDicionarioPodeEliminar ;
      private bool AV121DocOperadorColeta ;
      private bool AV122DocOperadorRetencao ;
      private bool AV123DocOperadorCompartilhamento ;
      private bool AV124DocOperadorEliminacao ;
      private bool AV125DocOperadorProcessamento ;
      private bool AV192IsAuthorized_BtnExcluir ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool AV168DocDicionarioTransfInter ;
      private bool AV94DocumentoAtivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n76DocumentoNome ;
      private bool n108DocumentoDataInclusao ;
      private bool n109DocumentoDataAlteracao ;
      private bool n106DocumentoProcessoId ;
      private bool n16ProcessoId ;
      private bool n20SubprocessoId ;
      private bool n7EncarregadoId ;
      private bool n13PersonaId ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n27CategoriaId ;
      private bool n30TipoDadoId ;
      private bool n33FerramentaColetaId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n45TipoDescarteId ;
      private bool n48TempoRetencaoId ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool A85DocumentoAtivo ;
      private bool n85DocumentoAtivo ;
      private bool A105DocumentoOperador ;
      private bool n105DocumentoOperador ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_257_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV169DocumentoOperador ;
      private bool AV190IsAuthorized_BtnAtualizar ;
      private bool AV191IsAuthorized_BtnVisualizar ;
      private bool AV183IsOk ;
      private bool GXt_boolean3 ;
      private string AV155DocDicionarioTipoTransfInterGarantia ;
      private string AV156DocDicionarioFinalidade ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string AV76GridAppliedFilters ;
      private string AV88DocumentoNome ;
      private string AV126DocumentoFinalidadeTratamento ;
      private string AV135DocumentoBaseLegalNorm ;
      private string AV136DocumentoBaseLegalNormIntExt ;
      private string AV154DDO_DocumentoDataInclusaoAuxDateText ;
      private string AV104DDO_DocumentoDataAlteracaoAuxDateText ;
      private string AV205DocumentoNome_Grid ;
      private string A76DocumentoNome ;
      private string AV206ProcessoNome_Grid ;
      private string A17ProcessoNome ;
      private string A21SubprocessoNome ;
      private string AV207SubprocessoNome_Grid ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A79DocumentoBaseLegalNorm ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A107DocumentoProcessoNome ;
      private string AV171FileName ;
      private string AV177Caminho ;
      private string AV175ContentType ;
      private GxSimpleCollection<int> AV167Documentos ;
      private IGxSession AV23Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfdocumentodatainclusao_rangepicker ;
      private GXUserControl ucTfdocumentodataalteracao_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_btnexcluir ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavDocumentoprocessoid ;
      private GXCombobox dynavSubprocessoid ;
      private GXCombobox dynavArearesponsavelid ;
      private GXCombobox dynavDocumentocontroladorid ;
      private GXCombobox dynavEncarregadoid ;
      private GXCombobox dynavPersonaid ;
      private GXCombobox cmbavDocumentosituacao ;
      private GXCombobox dynavCategoriaid ;
      private GXCombobox dynavTipodadoid ;
      private GXCombobox dynavFerramentacoletaid ;
      private GXCombobox dynavAbrangenciageograficaid ;
      private GXCombobox dynavFrequenciatratamentoid ;
      private GXCombobox dynavTipodescarteid ;
      private GXCombobox dynavTemporetencaoid ;
      private GXCheckbox chkavDocumentoprevcoletadados ;
      private GXCheckbox chkavDocumentodadosgrupovul ;
      private GXCheckbox chkavDocumentodadoscriancaadolesc ;
      private GXCombobox dynavInformacaoid ;
      private GXCheckbox chkavDocdicionariosensivel ;
      private GXCheckbox chkavDocdicionariopodeeliminar ;
      private GXCombobox dynavHipotesetratamentoid ;
      private GXCombobox cmbavDocdicionariotransfinter ;
      private GXCombobox dynavPaisid ;
      private GXCombobox dynavOperadores ;
      private GXCheckbox chkavDocoperadorcoleta ;
      private GXCheckbox chkavDocoperadorretencao ;
      private GXCheckbox chkavDocoperadorcompartilhamento ;
      private GXCheckbox chkavDocoperadoreliminacao ;
      private GXCheckbox chkavDocoperadorprocessamento ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCheckbox chkDocumentoPrevColetaDados ;
      private GXCheckbox chkDocumentoDadosCriancaAdolesc ;
      private GXCheckbox chkDocumentoDadosGrupoVul ;
      private GXCombobox cmbDocumentoAtivo ;
      private GXCheckbox chkDocumentoOperador ;
      private GXCombobox cmbavDocumentoativo ;
      private GXCheckbox chkavDocumentobuscaavancada ;
      private IDataStoreProvider pr_default ;
      private int[] H005R2_A16ProcessoId ;
      private bool[] H005R2_n16ProcessoId ;
      private string[] H005R2_A17ProcessoNome ;
      private bool[] H005R2_A19ProcessoAtivo ;
      private int[] H005R3_A20SubprocessoId ;
      private bool[] H005R3_n20SubprocessoId ;
      private string[] H005R3_A21SubprocessoNome ;
      private bool[] H005R3_A23SubprocessoAtivo ;
      private int[] H005R4_A24AreaResponsavelId ;
      private string[] H005R4_A25AreaResponsavelNome ;
      private bool[] H005R4_A26AreaResponsavelAtivo ;
      private int[] H005R5_A10ControladorId ;
      private string[] H005R5_A11ControladorNome ;
      private bool[] H005R5_A12ControladorAtivo ;
      private int[] H005R6_A7EncarregadoId ;
      private bool[] H005R6_n7EncarregadoId ;
      private string[] H005R6_A8EncarregadoNome ;
      private bool[] H005R6_A9EncarregadoAtivo ;
      private int[] H005R7_A13PersonaId ;
      private bool[] H005R7_n13PersonaId ;
      private string[] H005R7_A14PersonaNome ;
      private bool[] H005R7_A15PersonaAtivo ;
      private int[] H005R8_A27CategoriaId ;
      private bool[] H005R8_n27CategoriaId ;
      private string[] H005R8_A28CategoriaNome ;
      private bool[] H005R8_A29CategoriaAtivo ;
      private int[] H005R9_A30TipoDadoId ;
      private bool[] H005R9_n30TipoDadoId ;
      private string[] H005R9_A31TipoDadoNome ;
      private bool[] H005R9_A32TipoDadoAtivo ;
      private int[] H005R10_A33FerramentaColetaId ;
      private bool[] H005R10_n33FerramentaColetaId ;
      private string[] H005R10_A34FerramentaColetaNome ;
      private bool[] H005R10_A35FerramentaColetaAtivo ;
      private int[] H005R11_A36AbrangenciaGeograficaId ;
      private bool[] H005R11_n36AbrangenciaGeograficaId ;
      private string[] H005R11_A37AbrangenciaGeograficaNome ;
      private int[] H005R12_A39FrequenciaTratamentoId ;
      private bool[] H005R12_n39FrequenciaTratamentoId ;
      private string[] H005R12_A40FrequenciaTratamentoNome ;
      private bool[] H005R12_A41FrequenciaTratamentoAtivo ;
      private int[] H005R13_A45TipoDescarteId ;
      private bool[] H005R13_n45TipoDescarteId ;
      private string[] H005R13_A46TipoDescarteNome ;
      private bool[] H005R13_A47TipoDescarteAtivo ;
      private int[] H005R14_A48TempoRetencaoId ;
      private bool[] H005R14_n48TempoRetencaoId ;
      private string[] H005R14_A49TempoRetencaoNome ;
      private bool[] H005R14_A50TempoRetencaoAtivo ;
      private int[] H005R15_A69InformacaoId ;
      private string[] H005R15_A70InformacaoNome ;
      private bool[] H005R15_A71InformacaoAtivo ;
      private int[] H005R16_A72HipoteseTratamentoId ;
      private string[] H005R16_A73HipoteseTratamentoNome ;
      private bool[] H005R16_A74HipoteseTratamentoAtivo ;
      private int[] H005R17_A4PaisId ;
      private string[] H005R17_A5PaisNome ;
      private bool[] H005R17_A6PaisAtivo ;
      private int[] H005R18_A42OperadorId ;
      private string[] H005R18_A43OperadorNome ;
      private bool[] H005R18_A44OperadorAtivo ;
      private string[] H005R19_A107DocumentoProcessoNome ;
      private bool[] H005R19_A105DocumentoOperador ;
      private bool[] H005R19_n105DocumentoOperador ;
      private bool[] H005R19_A85DocumentoAtivo ;
      private bool[] H005R19_n85DocumentoAtivo ;
      private string[] H005R19_A83DocumentoMedidaSegurancaDesc ;
      private bool[] H005R19_n83DocumentoMedidaSegurancaDesc ;
      private bool[] H005R19_A82DocumentoDadosGrupoVul ;
      private bool[] H005R19_n82DocumentoDadosGrupoVul ;
      private bool[] H005R19_A81DocumentoDadosCriancaAdolesc ;
      private bool[] H005R19_n81DocumentoDadosCriancaAdolesc ;
      private string[] H005R19_A80DocumentoBaseLegalNormIntExt ;
      private bool[] H005R19_n80DocumentoBaseLegalNormIntExt ;
      private string[] H005R19_A79DocumentoBaseLegalNorm ;
      private bool[] H005R19_n79DocumentoBaseLegalNorm ;
      private bool[] H005R19_A78DocumentoPrevColetaDados ;
      private bool[] H005R19_n78DocumentoPrevColetaDados ;
      private int[] H005R19_A48TempoRetencaoId ;
      private bool[] H005R19_n48TempoRetencaoId ;
      private int[] H005R19_A45TipoDescarteId ;
      private bool[] H005R19_n45TipoDescarteId ;
      private int[] H005R19_A39FrequenciaTratamentoId ;
      private bool[] H005R19_n39FrequenciaTratamentoId ;
      private int[] H005R19_A36AbrangenciaGeograficaId ;
      private bool[] H005R19_n36AbrangenciaGeograficaId ;
      private int[] H005R19_A33FerramentaColetaId ;
      private bool[] H005R19_n33FerramentaColetaId ;
      private int[] H005R19_A30TipoDadoId ;
      private bool[] H005R19_n30TipoDadoId ;
      private int[] H005R19_A27CategoriaId ;
      private bool[] H005R19_n27CategoriaId ;
      private string[] H005R19_A77DocumentoFinalidadeTratamento ;
      private bool[] H005R19_n77DocumentoFinalidadeTratamento ;
      private int[] H005R19_A13PersonaId ;
      private bool[] H005R19_n13PersonaId ;
      private int[] H005R19_A7EncarregadoId ;
      private bool[] H005R19_n7EncarregadoId ;
      private int[] H005R19_A20SubprocessoId ;
      private bool[] H005R19_n20SubprocessoId ;
      private int[] H005R19_A16ProcessoId ;
      private bool[] H005R19_n16ProcessoId ;
      private int[] H005R19_A106DocumentoProcessoId ;
      private bool[] H005R19_n106DocumentoProcessoId ;
      private DateTime[] H005R19_A109DocumentoDataAlteracao ;
      private bool[] H005R19_n109DocumentoDataAlteracao ;
      private DateTime[] H005R19_A108DocumentoDataInclusao ;
      private bool[] H005R19_n108DocumentoDataInclusao ;
      private string[] H005R19_A21SubprocessoNome ;
      private string[] H005R19_A17ProcessoNome ;
      private string[] H005R19_A76DocumentoNome ;
      private bool[] H005R19_n76DocumentoNome ;
      private int[] H005R19_A75DocumentoId ;
      private long[] H005R20_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV70DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtFiltrosDocumento AV166FiltrosDocumento ;
   }

   public class documentoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005R19( IGxContext context ,
                                              int A75DocumentoId ,
                                              GxSimpleCollection<int> AV167Documentos ,
                                              int AV27TFDocumentoId ,
                                              int AV28TFDocumentoId_To ,
                                              DateTime AV150TFDocumentoDataInclusao ,
                                              DateTime AV151TFDocumentoDataInclusao_To ,
                                              DateTime AV100TFDocumentoDataAlteracao ,
                                              DateTime AV101TFDocumentoDataAlteracao_To ,
                                              DateTime A108DocumentoDataInclusao ,
                                              DateTime A109DocumentoDataAlteracao ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T4.[ProcessoNome] AS DocumentoProcessoNome, T1.[DocumentoOperador], T1.[DocumentoAtivo], T1.[DocumentoMedidaSegurancaDesc], T1.[DocumentoDadosGrupoVul], T1.[DocumentoDadosCriancaAdolesc], T1.[DocumentoBaseLegalNormIntExt], T1.[DocumentoBaseLegalNorm], T1.[DocumentoPrevColetaDados], T1.[TempoRetencaoId], T1.[TipoDescarteId], T1.[FrequenciaTratamentoId], T1.[AbrangenciaGeograficaId], T1.[FerramentaColetaId], T1.[TipoDadoId], T1.[CategoriaId], T1.[DocumentoFinalidadeTratamento], T1.[PersonaId], T1.[EncarregadoId], T1.[SubprocessoId], T2.[ProcessoId], T1.[DocumentoProcessoId] AS DocumentoProcessoId, T1.[DocumentoDataAlteracao], T1.[DocumentoDataInclusao], T2.[SubprocessoNome], T3.[ProcessoNome], T1.[DocumentoNome], T1.[DocumentoId]";
         sFromString = " FROM ((([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId]) LEFT JOIN [Processo] T4 ON T4.[ProcessoId] = T1.[DocumentoProcessoId])";
         sOrderString = "";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV167Documentos, "T1.[DocumentoId] IN (", ")")+")");
         if ( ! (0==AV27TFDocumentoId) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV27TFDocumentoId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV28TFDocumentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV28TFDocumentoId_To)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV150TFDocumentoDataInclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] >= @AV150TFDocumentoDataInclusao)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV151TFDocumentoDataInclusao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] <= @AV151TFDocumentoDataInclusao_To)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV100TFDocumentoDataAlteracao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] >= @AV100TFDocumentoDataAlteracao)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV101TFDocumentoDataAlteracao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] <= @AV101TFDocumentoDataAlteracao_To)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocumentoId]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocumentoId] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocumentoDataInclusao]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocumentoDataInclusao] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[DocumentoDataAlteracao]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[DocumentoDataAlteracao] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[DocumentoId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H005R20( IGxContext context ,
                                              int A75DocumentoId ,
                                              GxSimpleCollection<int> AV167Documentos ,
                                              int AV27TFDocumentoId ,
                                              int AV28TFDocumentoId_To ,
                                              DateTime AV150TFDocumentoDataInclusao ,
                                              DateTime AV151TFDocumentoDataInclusao_To ,
                                              DateTime AV100TFDocumentoDataAlteracao ,
                                              DateTime AV101TFDocumentoDataAlteracao_To ,
                                              DateTime A108DocumentoDataInclusao ,
                                              DateTime A109DocumentoDataAlteracao ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId]) LEFT JOIN [Processo] T4 ON T4.[ProcessoId] = T1.[DocumentoProcessoId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV167Documentos, "T1.[DocumentoId] IN (", ")")+")");
         if ( ! (0==AV27TFDocumentoId) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV27TFDocumentoId)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV28TFDocumentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV28TFDocumentoId_To)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV150TFDocumentoDataInclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] >= @AV150TFDocumentoDataInclusao)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV151TFDocumentoDataInclusao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] <= @AV151TFDocumentoDataInclusao_To)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV100TFDocumentoDataAlteracao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] >= @AV100TFDocumentoDataAlteracao)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV101TFDocumentoDataAlteracao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] <= @AV101TFDocumentoDataAlteracao_To)");
         }
         else
         {
            GXv_int6[5] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 17 :
                     return conditional_H005R19(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] );
               case 18 :
                     return conditional_H005R20(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] );
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
          Object[] prmH005R2;
          prmH005R2 = new Object[] {
          };
          Object[] prmH005R3;
          prmH005R3 = new Object[] {
          };
          Object[] prmH005R4;
          prmH005R4 = new Object[] {
          };
          Object[] prmH005R5;
          prmH005R5 = new Object[] {
          };
          Object[] prmH005R6;
          prmH005R6 = new Object[] {
          };
          Object[] prmH005R7;
          prmH005R7 = new Object[] {
          };
          Object[] prmH005R8;
          prmH005R8 = new Object[] {
          };
          Object[] prmH005R9;
          prmH005R9 = new Object[] {
          };
          Object[] prmH005R10;
          prmH005R10 = new Object[] {
          };
          Object[] prmH005R11;
          prmH005R11 = new Object[] {
          };
          Object[] prmH005R12;
          prmH005R12 = new Object[] {
          };
          Object[] prmH005R13;
          prmH005R13 = new Object[] {
          };
          Object[] prmH005R14;
          prmH005R14 = new Object[] {
          };
          Object[] prmH005R15;
          prmH005R15 = new Object[] {
          };
          Object[] prmH005R16;
          prmH005R16 = new Object[] {
          };
          Object[] prmH005R17;
          prmH005R17 = new Object[] {
          };
          Object[] prmH005R18;
          prmH005R18 = new Object[] {
          };
          Object[] prmH005R19;
          prmH005R19 = new Object[] {
          new ParDef("@AV27TFDocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV28TFDocumentoId_To",GXType.Int32,8,0) ,
          new ParDef("@AV150TFDocumentoDataInclusao",GXType.DateTime,8,5) ,
          new ParDef("@AV151TFDocumentoDataInclusao_To",GXType.DateTime,8,5) ,
          new ParDef("@AV100TFDocumentoDataAlteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV101TFDocumentoDataAlteracao_To",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005R20;
          prmH005R20 = new Object[] {
          new ParDef("@AV27TFDocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV28TFDocumentoId_To",GXType.Int32,8,0) ,
          new ParDef("@AV150TFDocumentoDataInclusao",GXType.DateTime,8,5) ,
          new ParDef("@AV151TFDocumentoDataInclusao_To",GXType.DateTime,8,5) ,
          new ParDef("@AV100TFDocumentoDataAlteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV101TFDocumentoDataAlteracao_To",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H005R2", "SELECT [ProcessoId], [ProcessoNome], [ProcessoAtivo] FROM [Processo] WHERE [ProcessoAtivo] = 1 ORDER BY [ProcessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R3", "SELECT [SubprocessoId], [SubprocessoNome], [SubprocessoAtivo] FROM [SubProcesso] WHERE [SubprocessoAtivo] = 1 ORDER BY [SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R4", "SELECT [AreaResponsavelId], [AreaResponsavelNome], [AreaResponsavelAtivo] FROM [AreaResponsavel] WHERE [AreaResponsavelAtivo] = 1 ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R5", "SELECT [ControladorId], [ControladorNome], [ControladorAtivo] FROM [Controlador] WHERE [ControladorAtivo] = 1 ORDER BY [ControladorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R6", "SELECT [EncarregadoId], [EncarregadoNome], [EncarregadoAtivo] FROM [Encarregado] WHERE [EncarregadoAtivo] = 1 ORDER BY [EncarregadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R7", "SELECT [PersonaId], [PersonaNome], [PersonaAtivo] FROM [Persona] WHERE [PersonaAtivo] = 1 ORDER BY [PersonaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R8", "SELECT [CategoriaId], [CategoriaNome], [CategoriaAtivo] FROM [Categoria] WHERE [CategoriaAtivo] = 1 ORDER BY [CategoriaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R8,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R9", "SELECT [TipoDadoId], [TipoDadoNome], [TipoDadoAtivo] FROM [TipoDado] WHERE [TipoDadoAtivo] = 1 ORDER BY [TipoDadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R9,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R10", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WHERE [FerramentaColetaAtivo] = 1 ORDER BY [FerramentaColetaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R10,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R11", "SELECT [AbrangenciaGeograficaId], [AbrangenciaGeograficaNome] FROM [AbrangenciaGeografica] ORDER BY [AbrangenciaGeograficaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R11,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R12", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoAtivo] = 1 ORDER BY [FrequenciaTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R12,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R13", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WHERE [TipoDescarteAtivo] = 1 ORDER BY [TipoDescarteNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R13,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R14", "SELECT [TempoRetencaoId], [TempoRetencaoNome], [TempoRetencaoAtivo] FROM [TempoRetencao] WHERE [TempoRetencaoAtivo] = 1 ORDER BY [TempoRetencaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R14,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R15", "SELECT [InformacaoId], [InformacaoNome], [InformacaoAtivo] FROM [Informacao] WHERE [InformacaoAtivo] = 1 ORDER BY [InformacaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R15,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R16", "SELECT [HipoteseTratamentoId], [HipoteseTratamentoNome], [HipoteseTratamentoAtivo] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoAtivo] = 1 ORDER BY [HipoteseTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R16,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R17", "SELECT [PaisId], [PaisNome], [PaisAtivo] FROM [Pais] WHERE [PaisAtivo] = 1 ORDER BY [PaisNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R17,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R18", "SELECT [OperadorId], [OperadorNome], [OperadorAtivo] FROM [Operador] WHERE [OperadorAtivo] = 1 ORDER BY [OperadorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R18,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R19", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R19,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R20", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R20,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((DateTime[]) buf[43])[0] = rslt.getGXDateTime(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[45])[0] = rslt.getGXDateTime(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((string[]) buf[48])[0] = rslt.getVarchar(26);
                ((string[]) buf[49])[0] = rslt.getVarchar(27);
                ((bool[]) buf[50])[0] = rslt.wasNull(27);
                ((int[]) buf[51])[0] = rslt.getInt(28);
                return;
             case 18 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
