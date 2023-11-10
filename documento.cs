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
   public class documento : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DOCUMENTOPROCESSOID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLADOCUMENTOPROCESSOID1346( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SUBPROCESSOID") == 0 )
         {
            A106DocumentoProcessoId = (int)(NumberUtil.Val( GetPar( "DocumentoProcessoId"), "."));
            n106DocumentoProcessoId = false;
            AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLASUBPROCESSOID1346( A106DocumentoProcessoId) ;
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
            GXDLAPERSONAID1346( ) ;
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
            GXDLAENCARREGADOID1346( ) ;
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
            GXDLACATEGORIAID1346( ) ;
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
            GXDLATIPODADOID1346( ) ;
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
            GXDLAFERRAMENTACOLETAID1346( ) ;
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
            GXDLAABRANGENCIAGEOGRAFICAID1346( ) ;
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
            GXDLAFREQUENCIATRATAMENTOID1346( ) ;
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
            GXDLATIPODESCARTEID1346( ) ;
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
            GXDLATEMPORETENCAOID1346( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_67") == 0 )
         {
            A20SubprocessoId = (int)(NumberUtil.Val( GetPar( "SubprocessoId"), "."));
            n20SubprocessoId = false;
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_67( A20SubprocessoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_68") == 0 )
         {
            A7EncarregadoId = (int)(NumberUtil.Val( GetPar( "EncarregadoId"), "."));
            n7EncarregadoId = false;
            AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_68( A7EncarregadoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_69") == 0 )
         {
            A13PersonaId = (int)(NumberUtil.Val( GetPar( "PersonaId"), "."));
            n13PersonaId = false;
            AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_69( A13PersonaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_70") == 0 )
         {
            A27CategoriaId = (int)(NumberUtil.Val( GetPar( "CategoriaId"), "."));
            n27CategoriaId = false;
            AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_70( A27CategoriaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_71") == 0 )
         {
            A30TipoDadoId = (int)(NumberUtil.Val( GetPar( "TipoDadoId"), "."));
            n30TipoDadoId = false;
            AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_71( A30TipoDadoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_72") == 0 )
         {
            A33FerramentaColetaId = (int)(NumberUtil.Val( GetPar( "FerramentaColetaId"), "."));
            n33FerramentaColetaId = false;
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_72( A33FerramentaColetaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_73") == 0 )
         {
            A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( GetPar( "AbrangenciaGeograficaId"), "."));
            n36AbrangenciaGeograficaId = false;
            AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_73( A36AbrangenciaGeograficaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_74") == 0 )
         {
            A39FrequenciaTratamentoId = (int)(NumberUtil.Val( GetPar( "FrequenciaTratamentoId"), "."));
            n39FrequenciaTratamentoId = false;
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_74( A39FrequenciaTratamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_75") == 0 )
         {
            A45TipoDescarteId = (int)(NumberUtil.Val( GetPar( "TipoDescarteId"), "."));
            n45TipoDescarteId = false;
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_75( A45TipoDescarteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_76") == 0 )
         {
            A48TempoRetencaoId = (int)(NumberUtil.Val( GetPar( "TempoRetencaoId"), "."));
            n48TempoRetencaoId = false;
            AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_76( A48TempoRetencaoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_78") == 0 )
         {
            A106DocumentoProcessoId = (int)(NumberUtil.Val( GetPar( "DocumentoProcessoId"), "."));
            n106DocumentoProcessoId = false;
            AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_78( A106DocumentoProcessoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_77") == 0 )
         {
            A24AreaResponsavelId = (int)(NumberUtil.Val( GetPar( "AreaResponsavelId"), "."));
            n24AreaResponsavelId = false;
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_77( A24AreaResponsavelId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_79") == 0 )
         {
            A110DocumentoControladorId = (int)(NumberUtil.Val( GetPar( "DocumentoControladorId"), "."));
            n110DocumentoControladorId = false;
            AssignAttri("", false, "A110DocumentoControladorId", StringUtil.LTrimStr( (decimal)(A110DocumentoControladorId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_79( A110DocumentoControladorId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documento.aspx")), "documento.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documento.aspx")))) ;
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
                  AV7DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri("", false, "AV7DocumentoId", StringUtil.LTrimStr( (decimal)(AV7DocumentoId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocumentoId), "ZZZZZZZ9"), context));
                  AV56Aba = GetPar( "Aba");
                  AssignAttri("", false, "AV56Aba", AV56Aba);
                  GxWebStd.gx_hidden_field( context, "gxhash_vABA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Aba, "")), context));
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
            Form.Meta.addItem("description", "Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynDocumentoProcessoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public documento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocumentoId ,
                           string aP2_Aba )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocumentoId = aP1_DocumentoId;
         this.AV56Aba = aP2_Aba;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
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
            return "documento_Execute" ;
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
         if ( dynDocumentoProcessoId.ItemCount > 0 )
         {
            A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0))), "."));
            n106DocumentoProcessoId = false;
            AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDocumentoProcessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0));
            AssignProp("", false, dynDocumentoProcessoId_Internalname, "Values", dynDocumentoProcessoId.ToJavascriptSource(), true);
         }
         if ( dynSubprocessoId.ItemCount > 0 )
         {
            A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0))), "."));
            n20SubprocessoId = false;
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
            AssignProp("", false, dynSubprocessoId_Internalname, "Values", dynSubprocessoId.ToJavascriptSource(), true);
         }
         if ( dynPersonaId.ItemCount > 0 )
         {
            A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0))), "."));
            n13PersonaId = false;
            AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynPersonaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0));
            AssignProp("", false, dynPersonaId_Internalname, "Values", dynPersonaId.ToJavascriptSource(), true);
         }
         if ( dynEncarregadoId.ItemCount > 0 )
         {
            A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0))), "."));
            n7EncarregadoId = false;
            AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEncarregadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0));
            AssignProp("", false, dynEncarregadoId_Internalname, "Values", dynEncarregadoId.ToJavascriptSource(), true);
         }
         if ( cmbDocumentoAtivo.ItemCount > 0 )
         {
            A85DocumentoAtivo = StringUtil.StrToBool( cmbDocumentoAtivo.getValidValue(StringUtil.BoolToStr( A85DocumentoAtivo)));
            n85DocumentoAtivo = false;
            AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentoAtivo.CurrentValue = StringUtil.BoolToStr( A85DocumentoAtivo);
            AssignProp("", false, cmbDocumentoAtivo_Internalname, "Values", cmbDocumentoAtivo.ToJavascriptSource(), true);
         }
         if ( dynCategoriaId.ItemCount > 0 )
         {
            A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0))), "."));
            n27CategoriaId = false;
            AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCategoriaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0));
            AssignProp("", false, dynCategoriaId_Internalname, "Values", dynCategoriaId.ToJavascriptSource(), true);
         }
         if ( dynTipoDadoId.ItemCount > 0 )
         {
            A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0))), "."));
            n30TipoDadoId = false;
            AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoDadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0));
            AssignProp("", false, dynTipoDadoId_Internalname, "Values", dynTipoDadoId.ToJavascriptSource(), true);
         }
         if ( dynFerramentaColetaId.ItemCount > 0 )
         {
            A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0))), "."));
            n33FerramentaColetaId = false;
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynFerramentaColetaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0));
            AssignProp("", false, dynFerramentaColetaId_Internalname, "Values", dynFerramentaColetaId.ToJavascriptSource(), true);
         }
         if ( dynAbrangenciaGeograficaId.ItemCount > 0 )
         {
            A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0))), "."));
            n36AbrangenciaGeograficaId = false;
            AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynAbrangenciaGeograficaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            AssignProp("", false, dynAbrangenciaGeograficaId_Internalname, "Values", dynAbrangenciaGeograficaId.ToJavascriptSource(), true);
         }
         if ( dynFrequenciaTratamentoId.ItemCount > 0 )
         {
            A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0))), "."));
            n39FrequenciaTratamentoId = false;
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynFrequenciaTratamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            AssignProp("", false, dynFrequenciaTratamentoId_Internalname, "Values", dynFrequenciaTratamentoId.ToJavascriptSource(), true);
         }
         if ( dynTipoDescarteId.ItemCount > 0 )
         {
            A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0))), "."));
            n45TipoDescarteId = false;
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoDescarteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0));
            AssignProp("", false, dynTipoDescarteId_Internalname, "Values", dynTipoDescarteId.ToJavascriptSource(), true);
         }
         if ( dynTempoRetencaoId.ItemCount > 0 )
         {
            A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0))), "."));
            n48TempoRetencaoId = false;
            AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTempoRetencaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0));
            AssignProp("", false, dynTempoRetencaoId_Internalname, "Values", dynTempoRetencaoId.ToJavascriptSource(), true);
         }
         A78DocumentoPrevColetaDados = StringUtil.StrToBool( StringUtil.BoolToStr( A78DocumentoPrevColetaDados));
         n78DocumentoPrevColetaDados = false;
         AssignAttri("", false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
         A82DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( A82DocumentoDadosGrupoVul));
         n82DocumentoDadosGrupoVul = false;
         AssignAttri("", false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
         A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc));
         n81DocumentoDadosCriancaAdolesc = false;
         AssignAttri("", false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabledocumento_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynDocumentoProcessoId, dynDocumentoProcessoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0)), 1, dynDocumentoProcessoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDocumentoProcessoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_Documento.htm");
         dynDocumentoProcessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106DocumentoProcessoId), 8, 0));
         AssignProp("", false, dynDocumentoProcessoId_Internalname, "Values", (string)(dynDocumentoProcessoId.ToJavascriptSource()), true);
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
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtDocumentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynSubprocessoId, dynSubprocessoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0)), 1, dynSubprocessoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSubprocessoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_Documento.htm");
         dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
         AssignProp("", false, dynSubprocessoId_Internalname, "Values", (string)(dynSubprocessoId.ToJavascriptSource()), true);
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
         GxWebStd.gx_single_line_edit( context, edtDocumentoDataInclusao_Internalname, context.localUtil.TToC( A108DocumentoDataInclusao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A108DocumentoDataInclusao, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoDataInclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoDataInclusao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Documento.htm");
         GxWebStd.gx_bitmap( context, edtDocumentoDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocumentoDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Documento.htm");
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
         GxWebStd.gx_single_line_edit( context, edtavArearesponsavelnome_Internalname, AV54AreaResponsavelNome, StringUtil.RTrim( context.localUtil.Format( AV54AreaResponsavelNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavArearesponsavelnome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavArearesponsavelnome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Documento.htm");
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
         GxWebStd.gx_single_line_edit( context, edtDocumentoDataAlteracao_Internalname, context.localUtil.TToC( A109DocumentoDataAlteracao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A109DocumentoDataAlteracao, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoDataAlteracao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoDataAlteracao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Documento.htm");
         GxWebStd.gx_bitmap( context, edtDocumentoDataAlteracao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocumentoDataAlteracao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynPersonaId, dynPersonaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0)), 1, dynPersonaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynPersonaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_Documento.htm");
         dynPersonaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A13PersonaId), 8, 0));
         AssignProp("", false, dynPersonaId_Internalname, "Values", (string)(dynPersonaId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEncarregadoId, dynEncarregadoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0)), 1, dynEncarregadoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEncarregadoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_Documento.htm");
         dynEncarregadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7EncarregadoId), 8, 0));
         AssignProp("", false, dynEncarregadoId_Internalname, "Values", (string)(dynEncarregadoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoNome_Internalname, A76DocumentoNome, StringUtil.RTrim( context.localUtil.Format( A76DocumentoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDocumentoAtivo, cmbDocumentoAtivo_Internalname, StringUtil.BoolToStr( A85DocumentoAtivo), 1, cmbDocumentoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbDocumentoAtivo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_Documento.htm");
         cmbDocumentoAtivo.CurrentValue = StringUtil.BoolToStr( A85DocumentoAtivo);
         AssignProp("", false, cmbDocumentoAtivo_Internalname, "Values", (string)(cmbDocumentoAtivo.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTabletratamento_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoFinalidadeTratamento_Internalname, A77DocumentoFinalidadeTratamento, StringUtil.RTrim( context.localUtil.Format( A77DocumentoFinalidadeTratamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoFinalidadeTratamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoFinalidadeTratamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynCategoriaId, dynCategoriaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0)), 1, dynCategoriaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCategoriaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_Documento.htm");
         dynCategoriaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A27CategoriaId), 8, 0));
         AssignProp("", false, dynCategoriaId_Internalname, "Values", (string)(dynCategoriaId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTipoDadoId, dynTipoDadoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0)), 1, dynTipoDadoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoDadoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "", true, 0, "HLP_Documento.htm");
         dynTipoDadoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30TipoDadoId), 8, 0));
         AssignProp("", false, dynTipoDadoId_Internalname, "Values", (string)(dynTipoDadoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynFerramentaColetaId, dynFerramentaColetaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0)), 1, dynFerramentaColetaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynFerramentaColetaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_Documento.htm");
         dynFerramentaColetaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33FerramentaColetaId), 8, 0));
         AssignProp("", false, dynFerramentaColetaId_Internalname, "Values", (string)(dynFerramentaColetaId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynAbrangenciaGeograficaId, dynAbrangenciaGeograficaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0)), 1, dynAbrangenciaGeograficaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynAbrangenciaGeograficaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "", true, 0, "HLP_Documento.htm");
         dynAbrangenciaGeograficaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         AssignProp("", false, dynAbrangenciaGeograficaId_Internalname, "Values", (string)(dynAbrangenciaGeograficaId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynFrequenciaTratamentoId, dynFrequenciaTratamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0)), 1, dynFrequenciaTratamentoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynFrequenciaTratamentoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_Documento.htm");
         dynFrequenciaTratamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         AssignProp("", false, dynFrequenciaTratamentoId_Internalname, "Values", (string)(dynFrequenciaTratamentoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTipoDescarteId, dynTipoDescarteId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0)), 1, dynTipoDescarteId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoDescarteId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_Documento.htm");
         dynTipoDescarteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TipoDescarteId), 8, 0));
         AssignProp("", false, dynTipoDescarteId_Internalname, "Values", (string)(dynTipoDescarteId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTempoRetencaoId, dynTempoRetencaoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0)), 1, dynTempoRetencaoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTempoRetencaoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 0, "HLP_Documento.htm");
         dynTempoRetencaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48TempoRetencaoId), 8, 0));
         AssignProp("", false, dynTempoRetencaoId_Internalname, "Values", (string)(dynTempoRetencaoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_radio_ctrl( context, radDocumentoPrevColetaDados, radDocumentoPrevColetaDados_Internalname, StringUtil.BoolToStr( A78DocumentoPrevColetaDados), "", 1, radDocumentoPrevColetaDados.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radDocumentoPrevColetaDados_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoBaseLegalNorm_Internalname, A79DocumentoBaseLegalNorm, StringUtil.RTrim( context.localUtil.Format( A79DocumentoBaseLegalNorm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoBaseLegalNorm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoBaseLegalNorm_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoBaseLegalNormIntExt_Internalname, A80DocumentoBaseLegalNormIntExt, StringUtil.RTrim( context.localUtil.Format( A80DocumentoBaseLegalNormIntExt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoBaseLegalNormIntExt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentoBaseLegalNormIntExt_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocumentoDadosGrupoVul_Internalname, StringUtil.BoolToStr( A82DocumentoDadosGrupoVul), "", "POSSUI DADOS DE GRUPOS VULNERÁVEIS", 1, chkDocumentoDadosGrupoVul.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(126, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,126);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocumentoDadosCriancaAdolesc_Internalname, StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc), "", "POSSUI DADOS DE CRIANÇA/ADOLESCENTE", 1, chkDocumentoDadosCriancaAdolesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(130, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,130);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocumentoMedidaSegurancaDesc_Internalname, A83DocumentoMedidaSegurancaDesc, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", 0, 1, edtDocumentoMedidaSegurancaDesc_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocumentoFluxoTratDadosDesc_Internalname, A84DocumentoFluxoTratDadosDesc, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", 0, 1, edtDocumentoFluxoTratDadosDesc_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Documento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documento.htm");
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
         GxWebStd.gx_single_line_edit( context, edtavArearesponsavelid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55AreaResponsavelId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavArearesponsavelid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV55AreaResponsavelId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV55AreaResponsavelId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavArearesponsavelid_Jsonclick, 0, "Attribute", "", "", "", "", edtavArearesponsavelid_Visible, edtavArearesponsavelid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Documento.htm");
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
         E11132 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( "Z75DocumentoId"), ",", "."));
               Z109DocumentoDataAlteracao = context.localUtil.CToT( cgiGet( "Z109DocumentoDataAlteracao"), 0);
               n109DocumentoDataAlteracao = ((DateTime.MinValue==A109DocumentoDataAlteracao) ? true : false);
               Z142DocumentoUsuarioAlteracao = cgiGet( "Z142DocumentoUsuarioAlteracao");
               n142DocumentoUsuarioAlteracao = (String.IsNullOrEmpty(StringUtil.RTrim( A142DocumentoUsuarioAlteracao)) ? true : false);
               Z76DocumentoNome = cgiGet( "Z76DocumentoNome");
               n76DocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A76DocumentoNome)) ? true : false);
               Z77DocumentoFinalidadeTratamento = cgiGet( "Z77DocumentoFinalidadeTratamento");
               n77DocumentoFinalidadeTratamento = (String.IsNullOrEmpty(StringUtil.RTrim( A77DocumentoFinalidadeTratamento)) ? true : false);
               Z79DocumentoBaseLegalNorm = cgiGet( "Z79DocumentoBaseLegalNorm");
               n79DocumentoBaseLegalNorm = (String.IsNullOrEmpty(StringUtil.RTrim( A79DocumentoBaseLegalNorm)) ? true : false);
               Z80DocumentoBaseLegalNormIntExt = cgiGet( "Z80DocumentoBaseLegalNormIntExt");
               n80DocumentoBaseLegalNormIntExt = (String.IsNullOrEmpty(StringUtil.RTrim( A80DocumentoBaseLegalNormIntExt)) ? true : false);
               Z78DocumentoPrevColetaDados = StringUtil.StrToBool( cgiGet( "Z78DocumentoPrevColetaDados"));
               n78DocumentoPrevColetaDados = ((false==A78DocumentoPrevColetaDados) ? true : false);
               Z81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( cgiGet( "Z81DocumentoDadosCriancaAdolesc"));
               n81DocumentoDadosCriancaAdolesc = ((false==A81DocumentoDadosCriancaAdolesc) ? true : false);
               Z82DocumentoDadosGrupoVul = StringUtil.StrToBool( cgiGet( "Z82DocumentoDadosGrupoVul"));
               n82DocumentoDadosGrupoVul = ((false==A82DocumentoDadosGrupoVul) ? true : false);
               Z85DocumentoAtivo = StringUtil.StrToBool( cgiGet( "Z85DocumentoAtivo"));
               n85DocumentoAtivo = ((false==A85DocumentoAtivo) ? true : false);
               Z105DocumentoOperador = StringUtil.StrToBool( cgiGet( "Z105DocumentoOperador"));
               n105DocumentoOperador = ((false==A105DocumentoOperador) ? true : false);
               Z108DocumentoDataInclusao = context.localUtil.CToT( cgiGet( "Z108DocumentoDataInclusao"), 0);
               n108DocumentoDataInclusao = ((DateTime.MinValue==A108DocumentoDataInclusao) ? true : false);
               Z141DocumentoUsuarioInclusao = cgiGet( "Z141DocumentoUsuarioInclusao");
               n141DocumentoUsuarioInclusao = (String.IsNullOrEmpty(StringUtil.RTrim( A141DocumentoUsuarioInclusao)) ? true : false);
               Z143DocumentoIsOperador = StringUtil.StrToBool( cgiGet( "Z143DocumentoIsOperador"));
               n143DocumentoIsOperador = ((false==A143DocumentoIsOperador) ? true : false);
               Z20SubprocessoId = (int)(context.localUtil.CToN( cgiGet( "Z20SubprocessoId"), ",", "."));
               n20SubprocessoId = ((0==A20SubprocessoId) ? true : false);
               Z7EncarregadoId = (int)(context.localUtil.CToN( cgiGet( "Z7EncarregadoId"), ",", "."));
               n7EncarregadoId = ((0==A7EncarregadoId) ? true : false);
               Z13PersonaId = (int)(context.localUtil.CToN( cgiGet( "Z13PersonaId"), ",", "."));
               n13PersonaId = ((0==A13PersonaId) ? true : false);
               Z27CategoriaId = (int)(context.localUtil.CToN( cgiGet( "Z27CategoriaId"), ",", "."));
               n27CategoriaId = ((0==A27CategoriaId) ? true : false);
               Z30TipoDadoId = (int)(context.localUtil.CToN( cgiGet( "Z30TipoDadoId"), ",", "."));
               n30TipoDadoId = ((0==A30TipoDadoId) ? true : false);
               Z33FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( "Z33FerramentaColetaId"), ",", "."));
               n33FerramentaColetaId = ((0==A33FerramentaColetaId) ? true : false);
               Z36AbrangenciaGeograficaId = (int)(context.localUtil.CToN( cgiGet( "Z36AbrangenciaGeograficaId"), ",", "."));
               n36AbrangenciaGeograficaId = ((0==A36AbrangenciaGeograficaId) ? true : false);
               Z39FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( "Z39FrequenciaTratamentoId"), ",", "."));
               n39FrequenciaTratamentoId = ((0==A39FrequenciaTratamentoId) ? true : false);
               Z45TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( "Z45TipoDescarteId"), ",", "."));
               n45TipoDescarteId = ((0==A45TipoDescarteId) ? true : false);
               Z48TempoRetencaoId = (int)(context.localUtil.CToN( cgiGet( "Z48TempoRetencaoId"), ",", "."));
               n48TempoRetencaoId = ((0==A48TempoRetencaoId) ? true : false);
               Z24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "Z24AreaResponsavelId"), ",", "."));
               n24AreaResponsavelId = ((0==A24AreaResponsavelId) ? true : false);
               Z106DocumentoProcessoId = (int)(context.localUtil.CToN( cgiGet( "Z106DocumentoProcessoId"), ",", "."));
               n106DocumentoProcessoId = ((0==A106DocumentoProcessoId) ? true : false);
               Z110DocumentoControladorId = (int)(context.localUtil.CToN( cgiGet( "Z110DocumentoControladorId"), ",", "."));
               n110DocumentoControladorId = ((0==A110DocumentoControladorId) ? true : false);
               A142DocumentoUsuarioAlteracao = cgiGet( "Z142DocumentoUsuarioAlteracao");
               n142DocumentoUsuarioAlteracao = false;
               n142DocumentoUsuarioAlteracao = (String.IsNullOrEmpty(StringUtil.RTrim( A142DocumentoUsuarioAlteracao)) ? true : false);
               A105DocumentoOperador = StringUtil.StrToBool( cgiGet( "Z105DocumentoOperador"));
               n105DocumentoOperador = false;
               n105DocumentoOperador = ((false==A105DocumentoOperador) ? true : false);
               A141DocumentoUsuarioInclusao = cgiGet( "Z141DocumentoUsuarioInclusao");
               n141DocumentoUsuarioInclusao = false;
               n141DocumentoUsuarioInclusao = (String.IsNullOrEmpty(StringUtil.RTrim( A141DocumentoUsuarioInclusao)) ? true : false);
               A143DocumentoIsOperador = StringUtil.StrToBool( cgiGet( "Z143DocumentoIsOperador"));
               n143DocumentoIsOperador = false;
               n143DocumentoIsOperador = ((false==A143DocumentoIsOperador) ? true : false);
               A24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "Z24AreaResponsavelId"), ",", "."));
               n24AreaResponsavelId = false;
               n24AreaResponsavelId = ((0==A24AreaResponsavelId) ? true : false);
               A110DocumentoControladorId = (int)(context.localUtil.CToN( cgiGet( "Z110DocumentoControladorId"), ",", "."));
               n110DocumentoControladorId = false;
               n110DocumentoControladorId = ((0==A110DocumentoControladorId) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N20SubprocessoId = (int)(context.localUtil.CToN( cgiGet( "N20SubprocessoId"), ",", "."));
               n20SubprocessoId = ((0==A20SubprocessoId) ? true : false);
               N7EncarregadoId = (int)(context.localUtil.CToN( cgiGet( "N7EncarregadoId"), ",", "."));
               n7EncarregadoId = ((0==A7EncarregadoId) ? true : false);
               N13PersonaId = (int)(context.localUtil.CToN( cgiGet( "N13PersonaId"), ",", "."));
               n13PersonaId = ((0==A13PersonaId) ? true : false);
               N27CategoriaId = (int)(context.localUtil.CToN( cgiGet( "N27CategoriaId"), ",", "."));
               n27CategoriaId = ((0==A27CategoriaId) ? true : false);
               N30TipoDadoId = (int)(context.localUtil.CToN( cgiGet( "N30TipoDadoId"), ",", "."));
               n30TipoDadoId = ((0==A30TipoDadoId) ? true : false);
               N33FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( "N33FerramentaColetaId"), ",", "."));
               n33FerramentaColetaId = ((0==A33FerramentaColetaId) ? true : false);
               N36AbrangenciaGeograficaId = (int)(context.localUtil.CToN( cgiGet( "N36AbrangenciaGeograficaId"), ",", "."));
               n36AbrangenciaGeograficaId = ((0==A36AbrangenciaGeograficaId) ? true : false);
               N39FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( "N39FrequenciaTratamentoId"), ",", "."));
               n39FrequenciaTratamentoId = ((0==A39FrequenciaTratamentoId) ? true : false);
               N45TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( "N45TipoDescarteId"), ",", "."));
               n45TipoDescarteId = ((0==A45TipoDescarteId) ? true : false);
               N48TempoRetencaoId = (int)(context.localUtil.CToN( cgiGet( "N48TempoRetencaoId"), ",", "."));
               n48TempoRetencaoId = ((0==A48TempoRetencaoId) ? true : false);
               N106DocumentoProcessoId = (int)(context.localUtil.CToN( cgiGet( "N106DocumentoProcessoId"), ",", "."));
               n106DocumentoProcessoId = ((0==A106DocumentoProcessoId) ? true : false);
               N110DocumentoControladorId = (int)(context.localUtil.CToN( cgiGet( "N110DocumentoControladorId"), ",", "."));
               n110DocumentoControladorId = ((0==A110DocumentoControladorId) ? true : false);
               N24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "N24AreaResponsavelId"), ",", "."));
               n24AreaResponsavelId = ((0==A24AreaResponsavelId) ? true : false);
               AV7DocumentoId = (int)(context.localUtil.CToN( cgiGet( "vDOCUMENTOID"), ",", "."));
               AV13Insert_SubprocessoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_SUBPROCESSOID"), ",", "."));
               AV14Insert_EncarregadoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_ENCARREGADOID"), ",", "."));
               AV15Insert_PersonaId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_PERSONAID"), ",", "."));
               AV16Insert_CategoriaId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORIAID"), ",", "."));
               AV17Insert_TipoDadoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TIPODADOID"), ",", "."));
               AV18Insert_FerramentaColetaId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_FERRAMENTACOLETAID"), ",", "."));
               AV19Insert_AbrangenciaGeograficaId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_ABRANGENCIAGEOGRAFICAID"), ",", "."));
               AV20Insert_FrequenciaTratamentoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_FREQUENCIATRATAMENTOID"), ",", "."));
               AV21Insert_TipoDescarteId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TIPODESCARTEID"), ",", "."));
               AV22Insert_TempoRetencaoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TEMPORETENCAOID"), ",", "."));
               AV53Insert_DocumentoProcessoId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_DOCUMENTOPROCESSOID"), ",", "."));
               AV58Insert_DocumentoControladorId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_DOCUMENTOCONTROLADORID"), ",", "."));
               A110DocumentoControladorId = (int)(context.localUtil.CToN( cgiGet( "DOCUMENTOCONTROLADORID"), ",", "."));
               n110DocumentoControladorId = ((0==A110DocumentoControladorId) ? true : false);
               AV59Insert_AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_AREARESPONSAVELID"), ",", "."));
               A24AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( "AREARESPONSAVELID"), ",", "."));
               n24AreaResponsavelId = ((0==A24AreaResponsavelId) ? true : false);
               A142DocumentoUsuarioAlteracao = cgiGet( "DOCUMENTOUSUARIOALTERACAO");
               n142DocumentoUsuarioAlteracao = (String.IsNullOrEmpty(StringUtil.RTrim( A142DocumentoUsuarioAlteracao)) ? true : false);
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               A141DocumentoUsuarioInclusao = cgiGet( "DOCUMENTOUSUARIOINCLUSAO");
               n141DocumentoUsuarioInclusao = (String.IsNullOrEmpty(StringUtil.RTrim( A141DocumentoUsuarioInclusao)) ? true : false);
               A143DocumentoIsOperador = StringUtil.StrToBool( cgiGet( "DOCUMENTOISOPERADOR"));
               n143DocumentoIsOperador = ((false==A143DocumentoIsOperador) ? true : false);
               A105DocumentoOperador = StringUtil.StrToBool( cgiGet( "DOCUMENTOOPERADOR"));
               n105DocumentoOperador = ((false==A105DocumentoOperador) ? true : false);
               A107DocumentoProcessoNome = cgiGet( "DOCUMENTOPROCESSONOME");
               AV61Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               dynDocumentoProcessoId.CurrentValue = cgiGet( dynDocumentoProcessoId_Internalname);
               A106DocumentoProcessoId = (int)(NumberUtil.Val( cgiGet( dynDocumentoProcessoId_Internalname), "."));
               n106DocumentoProcessoId = false;
               AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
               n106DocumentoProcessoId = ((0==A106DocumentoProcessoId) ? true : false);
               A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               dynSubprocessoId.CurrentValue = cgiGet( dynSubprocessoId_Internalname);
               A20SubprocessoId = (int)(NumberUtil.Val( cgiGet( dynSubprocessoId_Internalname), "."));
               n20SubprocessoId = false;
               AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
               n20SubprocessoId = ((0==A20SubprocessoId) ? true : false);
               A108DocumentoDataInclusao = context.localUtil.CToT( cgiGet( edtDocumentoDataInclusao_Internalname));
               n108DocumentoDataInclusao = false;
               AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
               AV54AreaResponsavelNome = cgiGet( edtavArearesponsavelnome_Internalname);
               A109DocumentoDataAlteracao = context.localUtil.CToT( cgiGet( edtDocumentoDataAlteracao_Internalname));
               n109DocumentoDataAlteracao = false;
               AssignAttri("", false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
               dynPersonaId.CurrentValue = cgiGet( dynPersonaId_Internalname);
               A13PersonaId = (int)(NumberUtil.Val( cgiGet( dynPersonaId_Internalname), "."));
               n13PersonaId = false;
               AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
               n13PersonaId = ((0==A13PersonaId) ? true : false);
               dynEncarregadoId.CurrentValue = cgiGet( dynEncarregadoId_Internalname);
               A7EncarregadoId = (int)(NumberUtil.Val( cgiGet( dynEncarregadoId_Internalname), "."));
               n7EncarregadoId = false;
               AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
               n7EncarregadoId = ((0==A7EncarregadoId) ? true : false);
               A76DocumentoNome = cgiGet( edtDocumentoNome_Internalname);
               n76DocumentoNome = false;
               AssignAttri("", false, "A76DocumentoNome", A76DocumentoNome);
               n76DocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A76DocumentoNome)) ? true : false);
               cmbDocumentoAtivo.CurrentValue = cgiGet( cmbDocumentoAtivo_Internalname);
               A85DocumentoAtivo = StringUtil.StrToBool( cgiGet( cmbDocumentoAtivo_Internalname));
               n85DocumentoAtivo = false;
               AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
               n85DocumentoAtivo = ((false==A85DocumentoAtivo) ? true : false);
               A77DocumentoFinalidadeTratamento = cgiGet( edtDocumentoFinalidadeTratamento_Internalname);
               n77DocumentoFinalidadeTratamento = false;
               AssignAttri("", false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
               n77DocumentoFinalidadeTratamento = (String.IsNullOrEmpty(StringUtil.RTrim( A77DocumentoFinalidadeTratamento)) ? true : false);
               dynCategoriaId.CurrentValue = cgiGet( dynCategoriaId_Internalname);
               A27CategoriaId = (int)(NumberUtil.Val( cgiGet( dynCategoriaId_Internalname), "."));
               n27CategoriaId = false;
               AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
               n27CategoriaId = ((0==A27CategoriaId) ? true : false);
               dynTipoDadoId.CurrentValue = cgiGet( dynTipoDadoId_Internalname);
               A30TipoDadoId = (int)(NumberUtil.Val( cgiGet( dynTipoDadoId_Internalname), "."));
               n30TipoDadoId = false;
               AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
               n30TipoDadoId = ((0==A30TipoDadoId) ? true : false);
               dynFerramentaColetaId.CurrentValue = cgiGet( dynFerramentaColetaId_Internalname);
               A33FerramentaColetaId = (int)(NumberUtil.Val( cgiGet( dynFerramentaColetaId_Internalname), "."));
               n33FerramentaColetaId = false;
               AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
               n33FerramentaColetaId = ((0==A33FerramentaColetaId) ? true : false);
               dynAbrangenciaGeograficaId.CurrentValue = cgiGet( dynAbrangenciaGeograficaId_Internalname);
               A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( cgiGet( dynAbrangenciaGeograficaId_Internalname), "."));
               n36AbrangenciaGeograficaId = false;
               AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
               n36AbrangenciaGeograficaId = ((0==A36AbrangenciaGeograficaId) ? true : false);
               dynFrequenciaTratamentoId.CurrentValue = cgiGet( dynFrequenciaTratamentoId_Internalname);
               A39FrequenciaTratamentoId = (int)(NumberUtil.Val( cgiGet( dynFrequenciaTratamentoId_Internalname), "."));
               n39FrequenciaTratamentoId = false;
               AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
               n39FrequenciaTratamentoId = ((0==A39FrequenciaTratamentoId) ? true : false);
               dynTipoDescarteId.CurrentValue = cgiGet( dynTipoDescarteId_Internalname);
               A45TipoDescarteId = (int)(NumberUtil.Val( cgiGet( dynTipoDescarteId_Internalname), "."));
               n45TipoDescarteId = false;
               AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
               n45TipoDescarteId = ((0==A45TipoDescarteId) ? true : false);
               dynTempoRetencaoId.CurrentValue = cgiGet( dynTempoRetencaoId_Internalname);
               A48TempoRetencaoId = (int)(NumberUtil.Val( cgiGet( dynTempoRetencaoId_Internalname), "."));
               n48TempoRetencaoId = false;
               AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
               n48TempoRetencaoId = ((0==A48TempoRetencaoId) ? true : false);
               A78DocumentoPrevColetaDados = StringUtil.StrToBool( cgiGet( radDocumentoPrevColetaDados_Internalname));
               n78DocumentoPrevColetaDados = false;
               AssignAttri("", false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
               n78DocumentoPrevColetaDados = ((false==A78DocumentoPrevColetaDados) ? true : false);
               A79DocumentoBaseLegalNorm = cgiGet( edtDocumentoBaseLegalNorm_Internalname);
               n79DocumentoBaseLegalNorm = false;
               AssignAttri("", false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
               n79DocumentoBaseLegalNorm = (String.IsNullOrEmpty(StringUtil.RTrim( A79DocumentoBaseLegalNorm)) ? true : false);
               A80DocumentoBaseLegalNormIntExt = cgiGet( edtDocumentoBaseLegalNormIntExt_Internalname);
               n80DocumentoBaseLegalNormIntExt = false;
               AssignAttri("", false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
               n80DocumentoBaseLegalNormIntExt = (String.IsNullOrEmpty(StringUtil.RTrim( A80DocumentoBaseLegalNormIntExt)) ? true : false);
               A82DocumentoDadosGrupoVul = StringUtil.StrToBool( cgiGet( chkDocumentoDadosGrupoVul_Internalname));
               n82DocumentoDadosGrupoVul = false;
               AssignAttri("", false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
               n82DocumentoDadosGrupoVul = ((false==A82DocumentoDadosGrupoVul) ? true : false);
               A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( cgiGet( chkDocumentoDadosCriancaAdolesc_Internalname));
               n81DocumentoDadosCriancaAdolesc = false;
               AssignAttri("", false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
               n81DocumentoDadosCriancaAdolesc = ((false==A81DocumentoDadosCriancaAdolesc) ? true : false);
               A83DocumentoMedidaSegurancaDesc = cgiGet( edtDocumentoMedidaSegurancaDesc_Internalname);
               n83DocumentoMedidaSegurancaDesc = false;
               AssignAttri("", false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
               n83DocumentoMedidaSegurancaDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A83DocumentoMedidaSegurancaDesc)) ? true : false);
               A84DocumentoFluxoTratDadosDesc = cgiGet( edtDocumentoFluxoTratDadosDesc_Internalname);
               n84DocumentoFluxoTratDadosDesc = false;
               AssignAttri("", false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
               n84DocumentoFluxoTratDadosDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A84DocumentoFluxoTratDadosDesc)) ? true : false);
               AV55AreaResponsavelId = (int)(context.localUtil.CToN( cgiGet( edtavArearesponsavelid_Internalname), ",", "."));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Documento");
               A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               forbiddenHiddens.Add("DocumentoId", context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("DocumentoOperador", StringUtil.BoolToStr( A105DocumentoOperador));
               A108DocumentoDataInclusao = context.localUtil.CToT( cgiGet( edtDocumentoDataInclusao_Internalname));
               n108DocumentoDataInclusao = false;
               AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("DocumentoDataInclusao", context.localUtil.Format( A108DocumentoDataInclusao, "99/99/99 99:99"));
               forbiddenHiddens.Add("DocumentoUsuarioInclusao", StringUtil.RTrim( context.localUtil.Format( A141DocumentoUsuarioInclusao, "")));
               forbiddenHiddens.Add("DocumentoIsOperador", StringUtil.BoolToStr( A143DocumentoIsOperador));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A75DocumentoId != Z75DocumentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("documento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
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
                     sMode46 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode46;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound46 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_130( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCUMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtDocumentoId_Internalname;
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
                           E11132 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12132 ();
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
            E12132 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1346( ) ;
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
            DisableAttributes1346( ) ;
         }
         AssignProp("", false, edtavArearesponsavelnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelnome_Enabled), 5, 0), true);
         AssignProp("", false, edtavArearesponsavelid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelid_Enabled), 5, 0), true);
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1346( ) ;
            }
            else
            {
               CheckExtendedTable1346( ) ;
               CloseExtendedTableCursors1346( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption130( )
      {
      }

      protected void E11132( )
      {
         /* Start Routine */
         returnInSub = false;
         AV57count = 0;
         AssignAttri("", false, "AV57count", StringUtil.LTrimStr( (decimal)(AV57count), 4, 0));
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV61Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV62GXV1 = 1;
            AssignAttri("", false, "AV62GXV1", StringUtil.LTrimStr( (decimal)(AV62GXV1), 8, 0));
            while ( AV62GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV24TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV62GXV1));
               if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "SubprocessoId") == 0 )
               {
                  AV13Insert_SubprocessoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_SubprocessoId", StringUtil.LTrimStr( (decimal)(AV13Insert_SubprocessoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "EncarregadoId") == 0 )
               {
                  AV14Insert_EncarregadoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_EncarregadoId", StringUtil.LTrimStr( (decimal)(AV14Insert_EncarregadoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "PersonaId") == 0 )
               {
                  AV15Insert_PersonaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV15Insert_PersonaId", StringUtil.LTrimStr( (decimal)(AV15Insert_PersonaId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "CategoriaId") == 0 )
               {
                  AV16Insert_CategoriaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV16Insert_CategoriaId", StringUtil.LTrimStr( (decimal)(AV16Insert_CategoriaId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "TipoDadoId") == 0 )
               {
                  AV17Insert_TipoDadoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV17Insert_TipoDadoId", StringUtil.LTrimStr( (decimal)(AV17Insert_TipoDadoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "FerramentaColetaId") == 0 )
               {
                  AV18Insert_FerramentaColetaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV18Insert_FerramentaColetaId", StringUtil.LTrimStr( (decimal)(AV18Insert_FerramentaColetaId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "AbrangenciaGeograficaId") == 0 )
               {
                  AV19Insert_AbrangenciaGeograficaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV19Insert_AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(AV19Insert_AbrangenciaGeograficaId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "FrequenciaTratamentoId") == 0 )
               {
                  AV20Insert_FrequenciaTratamentoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV20Insert_FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(AV20Insert_FrequenciaTratamentoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "TipoDescarteId") == 0 )
               {
                  AV21Insert_TipoDescarteId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV21Insert_TipoDescarteId", StringUtil.LTrimStr( (decimal)(AV21Insert_TipoDescarteId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "TempoRetencaoId") == 0 )
               {
                  AV22Insert_TempoRetencaoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV22Insert_TempoRetencaoId", StringUtil.LTrimStr( (decimal)(AV22Insert_TempoRetencaoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "DocumentoProcessoId") == 0 )
               {
                  AV53Insert_DocumentoProcessoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV53Insert_DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(AV53Insert_DocumentoProcessoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "DocumentoControladorId") == 0 )
               {
                  AV58Insert_DocumentoControladorId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV58Insert_DocumentoControladorId", StringUtil.LTrimStr( (decimal)(AV58Insert_DocumentoControladorId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "AreaResponsavelId") == 0 )
               {
                  AV59Insert_AreaResponsavelId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV59Insert_AreaResponsavelId", StringUtil.LTrimStr( (decimal)(AV59Insert_AreaResponsavelId), 8, 0));
               }
               AV62GXV1 = (int)(AV62GXV1+1);
               AssignAttri("", false, "AV62GXV1", StringUtil.LTrimStr( (decimal)(AV62GXV1), 8, 0));
            }
         }
         edtavArearesponsavelid_Visible = 0;
         AssignProp("", false, edtavArearesponsavelid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavArearesponsavelid_Visible), 5, 0), true);
      }

      protected void E12132( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("documentoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1346( short GX_JID )
      {
         if ( ( GX_JID == 66 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z109DocumentoDataAlteracao = T00133_A109DocumentoDataAlteracao[0];
               Z142DocumentoUsuarioAlteracao = T00133_A142DocumentoUsuarioAlteracao[0];
               Z76DocumentoNome = T00133_A76DocumentoNome[0];
               Z77DocumentoFinalidadeTratamento = T00133_A77DocumentoFinalidadeTratamento[0];
               Z79DocumentoBaseLegalNorm = T00133_A79DocumentoBaseLegalNorm[0];
               Z80DocumentoBaseLegalNormIntExt = T00133_A80DocumentoBaseLegalNormIntExt[0];
               Z78DocumentoPrevColetaDados = T00133_A78DocumentoPrevColetaDados[0];
               Z81DocumentoDadosCriancaAdolesc = T00133_A81DocumentoDadosCriancaAdolesc[0];
               Z82DocumentoDadosGrupoVul = T00133_A82DocumentoDadosGrupoVul[0];
               Z85DocumentoAtivo = T00133_A85DocumentoAtivo[0];
               Z105DocumentoOperador = T00133_A105DocumentoOperador[0];
               Z108DocumentoDataInclusao = T00133_A108DocumentoDataInclusao[0];
               Z141DocumentoUsuarioInclusao = T00133_A141DocumentoUsuarioInclusao[0];
               Z143DocumentoIsOperador = T00133_A143DocumentoIsOperador[0];
               Z20SubprocessoId = T00133_A20SubprocessoId[0];
               Z7EncarregadoId = T00133_A7EncarregadoId[0];
               Z13PersonaId = T00133_A13PersonaId[0];
               Z27CategoriaId = T00133_A27CategoriaId[0];
               Z30TipoDadoId = T00133_A30TipoDadoId[0];
               Z33FerramentaColetaId = T00133_A33FerramentaColetaId[0];
               Z36AbrangenciaGeograficaId = T00133_A36AbrangenciaGeograficaId[0];
               Z39FrequenciaTratamentoId = T00133_A39FrequenciaTratamentoId[0];
               Z45TipoDescarteId = T00133_A45TipoDescarteId[0];
               Z48TempoRetencaoId = T00133_A48TempoRetencaoId[0];
               Z24AreaResponsavelId = T00133_A24AreaResponsavelId[0];
               Z106DocumentoProcessoId = T00133_A106DocumentoProcessoId[0];
               Z110DocumentoControladorId = T00133_A110DocumentoControladorId[0];
            }
            else
            {
               Z109DocumentoDataAlteracao = A109DocumentoDataAlteracao;
               Z142DocumentoUsuarioAlteracao = A142DocumentoUsuarioAlteracao;
               Z76DocumentoNome = A76DocumentoNome;
               Z77DocumentoFinalidadeTratamento = A77DocumentoFinalidadeTratamento;
               Z79DocumentoBaseLegalNorm = A79DocumentoBaseLegalNorm;
               Z80DocumentoBaseLegalNormIntExt = A80DocumentoBaseLegalNormIntExt;
               Z78DocumentoPrevColetaDados = A78DocumentoPrevColetaDados;
               Z81DocumentoDadosCriancaAdolesc = A81DocumentoDadosCriancaAdolesc;
               Z82DocumentoDadosGrupoVul = A82DocumentoDadosGrupoVul;
               Z85DocumentoAtivo = A85DocumentoAtivo;
               Z105DocumentoOperador = A105DocumentoOperador;
               Z108DocumentoDataInclusao = A108DocumentoDataInclusao;
               Z141DocumentoUsuarioInclusao = A141DocumentoUsuarioInclusao;
               Z143DocumentoIsOperador = A143DocumentoIsOperador;
               Z20SubprocessoId = A20SubprocessoId;
               Z7EncarregadoId = A7EncarregadoId;
               Z13PersonaId = A13PersonaId;
               Z27CategoriaId = A27CategoriaId;
               Z30TipoDadoId = A30TipoDadoId;
               Z33FerramentaColetaId = A33FerramentaColetaId;
               Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
               Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
               Z45TipoDescarteId = A45TipoDescarteId;
               Z48TempoRetencaoId = A48TempoRetencaoId;
               Z24AreaResponsavelId = A24AreaResponsavelId;
               Z106DocumentoProcessoId = A106DocumentoProcessoId;
               Z110DocumentoControladorId = A110DocumentoControladorId;
            }
         }
         if ( GX_JID == -66 )
         {
            Z75DocumentoId = A75DocumentoId;
            Z109DocumentoDataAlteracao = A109DocumentoDataAlteracao;
            Z142DocumentoUsuarioAlteracao = A142DocumentoUsuarioAlteracao;
            Z76DocumentoNome = A76DocumentoNome;
            Z77DocumentoFinalidadeTratamento = A77DocumentoFinalidadeTratamento;
            Z79DocumentoBaseLegalNorm = A79DocumentoBaseLegalNorm;
            Z80DocumentoBaseLegalNormIntExt = A80DocumentoBaseLegalNormIntExt;
            Z83DocumentoMedidaSegurancaDesc = A83DocumentoMedidaSegurancaDesc;
            Z78DocumentoPrevColetaDados = A78DocumentoPrevColetaDados;
            Z81DocumentoDadosCriancaAdolesc = A81DocumentoDadosCriancaAdolesc;
            Z82DocumentoDadosGrupoVul = A82DocumentoDadosGrupoVul;
            Z84DocumentoFluxoTratDadosDesc = A84DocumentoFluxoTratDadosDesc;
            Z85DocumentoAtivo = A85DocumentoAtivo;
            Z105DocumentoOperador = A105DocumentoOperador;
            Z108DocumentoDataInclusao = A108DocumentoDataInclusao;
            Z141DocumentoUsuarioInclusao = A141DocumentoUsuarioInclusao;
            Z143DocumentoIsOperador = A143DocumentoIsOperador;
            Z20SubprocessoId = A20SubprocessoId;
            Z7EncarregadoId = A7EncarregadoId;
            Z13PersonaId = A13PersonaId;
            Z27CategoriaId = A27CategoriaId;
            Z30TipoDadoId = A30TipoDadoId;
            Z33FerramentaColetaId = A33FerramentaColetaId;
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            Z45TipoDescarteId = A45TipoDescarteId;
            Z48TempoRetencaoId = A48TempoRetencaoId;
            Z24AreaResponsavelId = A24AreaResponsavelId;
            Z106DocumentoProcessoId = A106DocumentoProcessoId;
            Z110DocumentoControladorId = A110DocumentoControladorId;
            Z107DocumentoProcessoNome = A107DocumentoProcessoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         GXADOCUMENTOPROCESSOID_html1346( ) ;
         GXAPERSONAID_html1346( ) ;
         GXAENCARREGADOID_html1346( ) ;
         GXACATEGORIAID_html1346( ) ;
         GXATIPODADOID_html1346( ) ;
         GXAFERRAMENTACOLETAID_html1346( ) ;
         GXAABRANGENCIAGEOGRAFICAID_html1346( ) ;
         GXAFREQUENCIATRATAMENTOID_html1346( ) ;
         GXATIPODESCARTEID_html1346( ) ;
         GXATEMPORETENCAOID_html1346( ) ;
         edtDocumentoId_Enabled = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtDocumentoDataInclusao_Enabled = 0;
         AssignProp("", false, edtDocumentoDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoDataInclusao_Enabled), 5, 0), true);
         edtDocumentoDataAlteracao_Enabled = 0;
         AssignProp("", false, edtDocumentoDataAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoDataAlteracao_Enabled), 5, 0), true);
         AV61Pgmname = "Documento";
         AssignAttri("", false, "AV61Pgmname", AV61Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtDocumentoId_Enabled = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtDocumentoDataInclusao_Enabled = 0;
         AssignProp("", false, edtDocumentoDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoDataInclusao_Enabled), 5, 0), true);
         edtDocumentoDataAlteracao_Enabled = 0;
         AssignProp("", false, edtDocumentoDataAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoDataAlteracao_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7DocumentoId) )
         {
            A75DocumentoId = AV7DocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SubprocessoId) )
         {
            dynSubprocessoId.Enabled = 0;
            AssignProp("", false, dynSubprocessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSubprocessoId.Enabled), 5, 0), true);
         }
         else
         {
            dynSubprocessoId.Enabled = 1;
            AssignProp("", false, dynSubprocessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSubprocessoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_EncarregadoId) )
         {
            dynEncarregadoId.Enabled = 0;
            AssignProp("", false, dynEncarregadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEncarregadoId.Enabled), 5, 0), true);
         }
         else
         {
            dynEncarregadoId.Enabled = 1;
            AssignProp("", false, dynEncarregadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEncarregadoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_PersonaId) )
         {
            dynPersonaId.Enabled = 0;
            AssignProp("", false, dynPersonaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPersonaId.Enabled), 5, 0), true);
         }
         else
         {
            dynPersonaId.Enabled = 1;
            AssignProp("", false, dynPersonaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPersonaId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_CategoriaId) )
         {
            dynCategoriaId.Enabled = 0;
            AssignProp("", false, dynCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCategoriaId.Enabled), 5, 0), true);
         }
         else
         {
            dynCategoriaId.Enabled = 1;
            AssignProp("", false, dynCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCategoriaId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV17Insert_TipoDadoId) )
         {
            dynTipoDadoId.Enabled = 0;
            AssignProp("", false, dynTipoDadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoDadoId.Enabled), 5, 0), true);
         }
         else
         {
            dynTipoDadoId.Enabled = 1;
            AssignProp("", false, dynTipoDadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoDadoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_FerramentaColetaId) )
         {
            dynFerramentaColetaId.Enabled = 0;
            AssignProp("", false, dynFerramentaColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynFerramentaColetaId.Enabled), 5, 0), true);
         }
         else
         {
            dynFerramentaColetaId.Enabled = 1;
            AssignProp("", false, dynFerramentaColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynFerramentaColetaId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_AbrangenciaGeograficaId) )
         {
            dynAbrangenciaGeograficaId.Enabled = 0;
            AssignProp("", false, dynAbrangenciaGeograficaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynAbrangenciaGeograficaId.Enabled), 5, 0), true);
         }
         else
         {
            dynAbrangenciaGeograficaId.Enabled = 1;
            AssignProp("", false, dynAbrangenciaGeograficaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynAbrangenciaGeograficaId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_FrequenciaTratamentoId) )
         {
            dynFrequenciaTratamentoId.Enabled = 0;
            AssignProp("", false, dynFrequenciaTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynFrequenciaTratamentoId.Enabled), 5, 0), true);
         }
         else
         {
            dynFrequenciaTratamentoId.Enabled = 1;
            AssignProp("", false, dynFrequenciaTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynFrequenciaTratamentoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_TipoDescarteId) )
         {
            dynTipoDescarteId.Enabled = 0;
            AssignProp("", false, dynTipoDescarteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoDescarteId.Enabled), 5, 0), true);
         }
         else
         {
            dynTipoDescarteId.Enabled = 1;
            AssignProp("", false, dynTipoDescarteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoDescarteId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_TempoRetencaoId) )
         {
            dynTempoRetencaoId.Enabled = 0;
            AssignProp("", false, dynTempoRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTempoRetencaoId.Enabled), 5, 0), true);
         }
         else
         {
            dynTempoRetencaoId.Enabled = 1;
            AssignProp("", false, dynTempoRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTempoRetencaoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV53Insert_DocumentoProcessoId) )
         {
            dynDocumentoProcessoId.Enabled = 0;
            AssignProp("", false, dynDocumentoProcessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDocumentoProcessoId.Enabled), 5, 0), true);
         }
         else
         {
            dynDocumentoProcessoId.Enabled = 1;
            AssignProp("", false, dynDocumentoProcessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDocumentoProcessoId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV59Insert_AreaResponsavelId) )
         {
            A24AreaResponsavelId = AV59Insert_AreaResponsavelId;
            n24AreaResponsavelId = false;
            AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV58Insert_DocumentoControladorId) )
         {
            A110DocumentoControladorId = AV58Insert_DocumentoControladorId;
            n110DocumentoControladorId = false;
            AssignAttri("", false, "A110DocumentoControladorId", StringUtil.LTrimStr( (decimal)(A110DocumentoControladorId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV53Insert_DocumentoProcessoId) )
         {
            A106DocumentoProcessoId = AV53Insert_DocumentoProcessoId;
            n106DocumentoProcessoId = false;
            AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_TempoRetencaoId) )
         {
            A48TempoRetencaoId = AV22Insert_TempoRetencaoId;
            n48TempoRetencaoId = false;
            AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_TipoDescarteId) )
         {
            A45TipoDescarteId = AV21Insert_TipoDescarteId;
            n45TipoDescarteId = false;
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_FrequenciaTratamentoId) )
         {
            A39FrequenciaTratamentoId = AV20Insert_FrequenciaTratamentoId;
            n39FrequenciaTratamentoId = false;
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_AbrangenciaGeograficaId) )
         {
            A36AbrangenciaGeograficaId = AV19Insert_AbrangenciaGeograficaId;
            n36AbrangenciaGeograficaId = false;
            AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_FerramentaColetaId) )
         {
            A33FerramentaColetaId = AV18Insert_FerramentaColetaId;
            n33FerramentaColetaId = false;
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV17Insert_TipoDadoId) )
         {
            A30TipoDadoId = AV17Insert_TipoDadoId;
            n30TipoDadoId = false;
            AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_CategoriaId) )
         {
            A27CategoriaId = AV16Insert_CategoriaId;
            n27CategoriaId = false;
            AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_PersonaId) )
         {
            A13PersonaId = AV15Insert_PersonaId;
            n13PersonaId = false;
            AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_EncarregadoId) )
         {
            A7EncarregadoId = AV14Insert_EncarregadoId;
            n7EncarregadoId = false;
            AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SubprocessoId) )
         {
            A20SubprocessoId = AV13Insert_SubprocessoId;
            n20SubprocessoId = false;
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
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
         if ( IsIns( )  && (false==A85DocumentoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A85DocumentoAtivo = true;
            n85DocumentoAtivo = false;
            AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
         }
         if ( IsIns( )  && (DateTime.MinValue==A108DocumentoDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
            n108DocumentoDataInclusao = false;
            AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A141DocumentoUsuarioInclusao)) && ( Gx_BScreen == 0 ) )
         {
            A141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n141DocumentoUsuarioInclusao = false;
            AssignAttri("", false, "A141DocumentoUsuarioInclusao", A141DocumentoUsuarioInclusao);
         }
         if ( IsIns( )  && (false==A143DocumentoIsOperador) && ( Gx_BScreen == 0 ) )
         {
            A143DocumentoIsOperador = false;
            n143DocumentoIsOperador = false;
            AssignAttri("", false, "A143DocumentoIsOperador", A143DocumentoIsOperador);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001315 */
            pr_default.execute(13, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
            A107DocumentoProcessoNome = T001315_A107DocumentoProcessoNome[0];
            pr_default.close(13);
            GXASUBPROCESSOID_html1346( A106DocumentoProcessoId) ;
         }
      }

      protected void Load1346( )
      {
         /* Using cursor T001317 */
         pr_default.execute(15, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound46 = 1;
            A109DocumentoDataAlteracao = T001317_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = T001317_n109DocumentoDataAlteracao[0];
            AssignAttri("", false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            A142DocumentoUsuarioAlteracao = T001317_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = T001317_n142DocumentoUsuarioAlteracao[0];
            A76DocumentoNome = T001317_A76DocumentoNome[0];
            n76DocumentoNome = T001317_n76DocumentoNome[0];
            AssignAttri("", false, "A76DocumentoNome", A76DocumentoNome);
            A77DocumentoFinalidadeTratamento = T001317_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = T001317_n77DocumentoFinalidadeTratamento[0];
            AssignAttri("", false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
            A79DocumentoBaseLegalNorm = T001317_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = T001317_n79DocumentoBaseLegalNorm[0];
            AssignAttri("", false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
            A80DocumentoBaseLegalNormIntExt = T001317_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = T001317_n80DocumentoBaseLegalNormIntExt[0];
            AssignAttri("", false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
            A83DocumentoMedidaSegurancaDesc = T001317_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = T001317_n83DocumentoMedidaSegurancaDesc[0];
            AssignAttri("", false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
            A78DocumentoPrevColetaDados = T001317_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = T001317_n78DocumentoPrevColetaDados[0];
            AssignAttri("", false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
            A81DocumentoDadosCriancaAdolesc = T001317_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = T001317_n81DocumentoDadosCriancaAdolesc[0];
            AssignAttri("", false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
            A82DocumentoDadosGrupoVul = T001317_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = T001317_n82DocumentoDadosGrupoVul[0];
            AssignAttri("", false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
            A84DocumentoFluxoTratDadosDesc = T001317_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = T001317_n84DocumentoFluxoTratDadosDesc[0];
            AssignAttri("", false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
            A85DocumentoAtivo = T001317_A85DocumentoAtivo[0];
            n85DocumentoAtivo = T001317_n85DocumentoAtivo[0];
            AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
            A105DocumentoOperador = T001317_A105DocumentoOperador[0];
            n105DocumentoOperador = T001317_n105DocumentoOperador[0];
            A107DocumentoProcessoNome = T001317_A107DocumentoProcessoNome[0];
            A108DocumentoDataInclusao = T001317_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = T001317_n108DocumentoDataInclusao[0];
            AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            A141DocumentoUsuarioInclusao = T001317_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = T001317_n141DocumentoUsuarioInclusao[0];
            A143DocumentoIsOperador = T001317_A143DocumentoIsOperador[0];
            n143DocumentoIsOperador = T001317_n143DocumentoIsOperador[0];
            A20SubprocessoId = T001317_A20SubprocessoId[0];
            n20SubprocessoId = T001317_n20SubprocessoId[0];
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            A7EncarregadoId = T001317_A7EncarregadoId[0];
            n7EncarregadoId = T001317_n7EncarregadoId[0];
            AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
            A13PersonaId = T001317_A13PersonaId[0];
            n13PersonaId = T001317_n13PersonaId[0];
            AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
            A27CategoriaId = T001317_A27CategoriaId[0];
            n27CategoriaId = T001317_n27CategoriaId[0];
            AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
            A30TipoDadoId = T001317_A30TipoDadoId[0];
            n30TipoDadoId = T001317_n30TipoDadoId[0];
            AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
            A33FerramentaColetaId = T001317_A33FerramentaColetaId[0];
            n33FerramentaColetaId = T001317_n33FerramentaColetaId[0];
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            A36AbrangenciaGeograficaId = T001317_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = T001317_n36AbrangenciaGeograficaId[0];
            AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            A39FrequenciaTratamentoId = T001317_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = T001317_n39FrequenciaTratamentoId[0];
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            A45TipoDescarteId = T001317_A45TipoDescarteId[0];
            n45TipoDescarteId = T001317_n45TipoDescarteId[0];
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            A48TempoRetencaoId = T001317_A48TempoRetencaoId[0];
            n48TempoRetencaoId = T001317_n48TempoRetencaoId[0];
            AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
            A24AreaResponsavelId = T001317_A24AreaResponsavelId[0];
            n24AreaResponsavelId = T001317_n24AreaResponsavelId[0];
            A106DocumentoProcessoId = T001317_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = T001317_n106DocumentoProcessoId[0];
            AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
            A110DocumentoControladorId = T001317_A110DocumentoControladorId[0];
            n110DocumentoControladorId = T001317_n110DocumentoControladorId[0];
            ZM1346( -66) ;
         }
         pr_default.close(15);
         OnLoadActions1346( ) ;
      }

      protected void OnLoadActions1346( )
      {
         A76DocumentoNome = StringUtil.Upper( A76DocumentoNome);
         n76DocumentoNome = false;
         AssignAttri("", false, "A76DocumentoNome", A76DocumentoNome);
         A77DocumentoFinalidadeTratamento = StringUtil.Upper( A77DocumentoFinalidadeTratamento);
         n77DocumentoFinalidadeTratamento = false;
         AssignAttri("", false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
         A79DocumentoBaseLegalNorm = StringUtil.Upper( A79DocumentoBaseLegalNorm);
         n79DocumentoBaseLegalNorm = false;
         AssignAttri("", false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
         A80DocumentoBaseLegalNormIntExt = StringUtil.Upper( A80DocumentoBaseLegalNormIntExt);
         n80DocumentoBaseLegalNormIntExt = false;
         AssignAttri("", false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
         A83DocumentoMedidaSegurancaDesc = StringUtil.Upper( A83DocumentoMedidaSegurancaDesc);
         n83DocumentoMedidaSegurancaDesc = false;
         AssignAttri("", false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
         GXASUBPROCESSOID_html1346( A106DocumentoProcessoId) ;
      }

      protected void CheckExtendedTable1346( )
      {
         nIsDirty_46 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_46 = 1;
         A76DocumentoNome = StringUtil.Upper( A76DocumentoNome);
         n76DocumentoNome = false;
         AssignAttri("", false, "A76DocumentoNome", A76DocumentoNome);
         /* Using cursor T00134 */
         pr_default.execute(2, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A20SubprocessoId) ) )
            {
               GX_msglist.addItem("Não existe 'SubProcesso.'.", "ForeignKeyNotFound", 1, "SUBPROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynSubprocessoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T00135 */
         pr_default.execute(3, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A7EncarregadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Encarregado'.", "ForeignKeyNotFound", 1, "ENCARREGADOID");
               AnyError = 1;
               GX_FocusControl = dynEncarregadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T00136 */
         pr_default.execute(4, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A13PersonaId) ) )
            {
               GX_msglist.addItem("Não existe 'Persona'.", "ForeignKeyNotFound", 1, "PERSONAID");
               AnyError = 1;
               GX_FocusControl = dynPersonaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         nIsDirty_46 = 1;
         A77DocumentoFinalidadeTratamento = StringUtil.Upper( A77DocumentoFinalidadeTratamento);
         n77DocumentoFinalidadeTratamento = false;
         AssignAttri("", false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
         /* Using cursor T00137 */
         pr_default.execute(5, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A27CategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = dynCategoriaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T00138 */
         pr_default.execute(6, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A30TipoDadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Dado'.", "ForeignKeyNotFound", 1, "TIPODADOID");
               AnyError = 1;
               GX_FocusControl = dynTipoDadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T00139 */
         pr_default.execute(7, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A33FerramentaColetaId) ) )
            {
               GX_msglist.addItem("Não existe 'Ferramenta Coleta'.", "ForeignKeyNotFound", 1, "FERRAMENTACOLETAID");
               AnyError = 1;
               GX_FocusControl = dynFerramentaColetaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
         /* Using cursor T001310 */
         pr_default.execute(8, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A36AbrangenciaGeograficaId) ) )
            {
               GX_msglist.addItem("Não existe 'Abrangencia Geografica'.", "ForeignKeyNotFound", 1, "ABRANGENCIAGEOGRAFICAID");
               AnyError = 1;
               GX_FocusControl = dynAbrangenciaGeograficaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(8);
         /* Using cursor T001311 */
         pr_default.execute(9, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A39FrequenciaTratamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'Frequencia Tratamento'.", "ForeignKeyNotFound", 1, "FREQUENCIATRATAMENTOID");
               AnyError = 1;
               GX_FocusControl = dynFrequenciaTratamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(9);
         /* Using cursor T001312 */
         pr_default.execute(10, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A45TipoDescarteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Descarte'.", "ForeignKeyNotFound", 1, "TIPODESCARTEID");
               AnyError = 1;
               GX_FocusControl = dynTipoDescarteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(10);
         /* Using cursor T001313 */
         pr_default.execute(11, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A48TempoRetencaoId) ) )
            {
               GX_msglist.addItem("Não existe 'TempoRetencao'.", "ForeignKeyNotFound", 1, "TEMPORETENCAOID");
               AnyError = 1;
               GX_FocusControl = dynTempoRetencaoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(11);
         nIsDirty_46 = 1;
         A79DocumentoBaseLegalNorm = StringUtil.Upper( A79DocumentoBaseLegalNorm);
         n79DocumentoBaseLegalNorm = false;
         AssignAttri("", false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
         nIsDirty_46 = 1;
         A80DocumentoBaseLegalNormIntExt = StringUtil.Upper( A80DocumentoBaseLegalNormIntExt);
         n80DocumentoBaseLegalNormIntExt = false;
         AssignAttri("", false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
         nIsDirty_46 = 1;
         A83DocumentoMedidaSegurancaDesc = StringUtil.Upper( A83DocumentoMedidaSegurancaDesc);
         n83DocumentoMedidaSegurancaDesc = false;
         AssignAttri("", false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
         /* Using cursor T001315 */
         pr_default.execute(13, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A106DocumentoProcessoId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Processo'.", "ForeignKeyNotFound", 1, "DOCUMENTOPROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynDocumentoProcessoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A107DocumentoProcessoNome = T001315_A107DocumentoProcessoNome[0];
         pr_default.close(13);
         GXASUBPROCESSOID_html1346( A106DocumentoProcessoId) ;
         /* Using cursor T001314 */
         pr_default.execute(12, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A24AreaResponsavelId) ) )
            {
               GX_msglist.addItem("Não existe 'Area Responsavel.'.", "ForeignKeyNotFound", 1, "AREARESPONSAVELID");
               AnyError = 1;
            }
         }
         pr_default.close(12);
         /* Using cursor T001316 */
         pr_default.execute(14, new Object[] {n110DocumentoControladorId, A110DocumentoControladorId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A110DocumentoControladorId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Controlador'.", "ForeignKeyNotFound", 1, "DOCUMENTOCONTROLADORID");
               AnyError = 1;
            }
         }
         pr_default.close(14);
      }

      protected void CloseExtendedTableCursors1346( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(12);
         pr_default.close(14);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_67( int A20SubprocessoId )
      {
         /* Using cursor T001318 */
         pr_default.execute(16, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A20SubprocessoId) ) )
            {
               GX_msglist.addItem("Não existe 'SubProcesso.'.", "ForeignKeyNotFound", 1, "SUBPROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynSubprocessoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_68( int A7EncarregadoId )
      {
         /* Using cursor T001319 */
         pr_default.execute(17, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A7EncarregadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Encarregado'.", "ForeignKeyNotFound", 1, "ENCARREGADOID");
               AnyError = 1;
               GX_FocusControl = dynEncarregadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_69( int A13PersonaId )
      {
         /* Using cursor T001320 */
         pr_default.execute(18, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A13PersonaId) ) )
            {
               GX_msglist.addItem("Não existe 'Persona'.", "ForeignKeyNotFound", 1, "PERSONAID");
               AnyError = 1;
               GX_FocusControl = dynPersonaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_70( int A27CategoriaId )
      {
         /* Using cursor T001321 */
         pr_default.execute(19, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A27CategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = dynCategoriaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_71( int A30TipoDadoId )
      {
         /* Using cursor T001322 */
         pr_default.execute(20, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A30TipoDadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Dado'.", "ForeignKeyNotFound", 1, "TIPODADOID");
               AnyError = 1;
               GX_FocusControl = dynTipoDadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_72( int A33FerramentaColetaId )
      {
         /* Using cursor T001323 */
         pr_default.execute(21, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A33FerramentaColetaId) ) )
            {
               GX_msglist.addItem("Não existe 'Ferramenta Coleta'.", "ForeignKeyNotFound", 1, "FERRAMENTACOLETAID");
               AnyError = 1;
               GX_FocusControl = dynFerramentaColetaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_73( int A36AbrangenciaGeograficaId )
      {
         /* Using cursor T001324 */
         pr_default.execute(22, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A36AbrangenciaGeograficaId) ) )
            {
               GX_msglist.addItem("Não existe 'Abrangencia Geografica'.", "ForeignKeyNotFound", 1, "ABRANGENCIAGEOGRAFICAID");
               AnyError = 1;
               GX_FocusControl = dynAbrangenciaGeograficaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_74( int A39FrequenciaTratamentoId )
      {
         /* Using cursor T001325 */
         pr_default.execute(23, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A39FrequenciaTratamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'Frequencia Tratamento'.", "ForeignKeyNotFound", 1, "FREQUENCIATRATAMENTOID");
               AnyError = 1;
               GX_FocusControl = dynFrequenciaTratamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_75( int A45TipoDescarteId )
      {
         /* Using cursor T001326 */
         pr_default.execute(24, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A45TipoDescarteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Descarte'.", "ForeignKeyNotFound", 1, "TIPODESCARTEID");
               AnyError = 1;
               GX_FocusControl = dynTipoDescarteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_76( int A48TempoRetencaoId )
      {
         /* Using cursor T001327 */
         pr_default.execute(25, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A48TempoRetencaoId) ) )
            {
               GX_msglist.addItem("Não existe 'TempoRetencao'.", "ForeignKeyNotFound", 1, "TEMPORETENCAOID");
               AnyError = 1;
               GX_FocusControl = dynTempoRetencaoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void gxLoad_78( int A106DocumentoProcessoId )
      {
         /* Using cursor T001328 */
         pr_default.execute(26, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A106DocumentoProcessoId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Processo'.", "ForeignKeyNotFound", 1, "DOCUMENTOPROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynDocumentoProcessoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A107DocumentoProcessoNome = T001328_A107DocumentoProcessoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A107DocumentoProcessoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_77( int A24AreaResponsavelId )
      {
         /* Using cursor T001329 */
         pr_default.execute(27, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A24AreaResponsavelId) ) )
            {
               GX_msglist.addItem("Não existe 'Area Responsavel.'.", "ForeignKeyNotFound", 1, "AREARESPONSAVELID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_79( int A110DocumentoControladorId )
      {
         /* Using cursor T001330 */
         pr_default.execute(28, new Object[] {n110DocumentoControladorId, A110DocumentoControladorId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A110DocumentoControladorId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Controlador'.", "ForeignKeyNotFound", 1, "DOCUMENTOCONTROLADORID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey1346( )
      {
         /* Using cursor T001331 */
         pr_default.execute(29, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00133 */
         pr_default.execute(1, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1346( 66) ;
            RcdFound46 = 1;
            A75DocumentoId = T00133_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            A109DocumentoDataAlteracao = T00133_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = T00133_n109DocumentoDataAlteracao[0];
            AssignAttri("", false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            A142DocumentoUsuarioAlteracao = T00133_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = T00133_n142DocumentoUsuarioAlteracao[0];
            A76DocumentoNome = T00133_A76DocumentoNome[0];
            n76DocumentoNome = T00133_n76DocumentoNome[0];
            AssignAttri("", false, "A76DocumentoNome", A76DocumentoNome);
            A77DocumentoFinalidadeTratamento = T00133_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = T00133_n77DocumentoFinalidadeTratamento[0];
            AssignAttri("", false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
            A79DocumentoBaseLegalNorm = T00133_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = T00133_n79DocumentoBaseLegalNorm[0];
            AssignAttri("", false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
            A80DocumentoBaseLegalNormIntExt = T00133_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = T00133_n80DocumentoBaseLegalNormIntExt[0];
            AssignAttri("", false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
            A83DocumentoMedidaSegurancaDesc = T00133_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = T00133_n83DocumentoMedidaSegurancaDesc[0];
            AssignAttri("", false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
            A78DocumentoPrevColetaDados = T00133_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = T00133_n78DocumentoPrevColetaDados[0];
            AssignAttri("", false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
            A81DocumentoDadosCriancaAdolesc = T00133_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = T00133_n81DocumentoDadosCriancaAdolesc[0];
            AssignAttri("", false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
            A82DocumentoDadosGrupoVul = T00133_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = T00133_n82DocumentoDadosGrupoVul[0];
            AssignAttri("", false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
            A84DocumentoFluxoTratDadosDesc = T00133_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = T00133_n84DocumentoFluxoTratDadosDesc[0];
            AssignAttri("", false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
            A85DocumentoAtivo = T00133_A85DocumentoAtivo[0];
            n85DocumentoAtivo = T00133_n85DocumentoAtivo[0];
            AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
            A105DocumentoOperador = T00133_A105DocumentoOperador[0];
            n105DocumentoOperador = T00133_n105DocumentoOperador[0];
            A108DocumentoDataInclusao = T00133_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = T00133_n108DocumentoDataInclusao[0];
            AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
            A141DocumentoUsuarioInclusao = T00133_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = T00133_n141DocumentoUsuarioInclusao[0];
            A143DocumentoIsOperador = T00133_A143DocumentoIsOperador[0];
            n143DocumentoIsOperador = T00133_n143DocumentoIsOperador[0];
            A20SubprocessoId = T00133_A20SubprocessoId[0];
            n20SubprocessoId = T00133_n20SubprocessoId[0];
            AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
            A7EncarregadoId = T00133_A7EncarregadoId[0];
            n7EncarregadoId = T00133_n7EncarregadoId[0];
            AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
            A13PersonaId = T00133_A13PersonaId[0];
            n13PersonaId = T00133_n13PersonaId[0];
            AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
            A27CategoriaId = T00133_A27CategoriaId[0];
            n27CategoriaId = T00133_n27CategoriaId[0];
            AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
            A30TipoDadoId = T00133_A30TipoDadoId[0];
            n30TipoDadoId = T00133_n30TipoDadoId[0];
            AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
            A33FerramentaColetaId = T00133_A33FerramentaColetaId[0];
            n33FerramentaColetaId = T00133_n33FerramentaColetaId[0];
            AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
            A36AbrangenciaGeograficaId = T00133_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = T00133_n36AbrangenciaGeograficaId[0];
            AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
            A39FrequenciaTratamentoId = T00133_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = T00133_n39FrequenciaTratamentoId[0];
            AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
            A45TipoDescarteId = T00133_A45TipoDescarteId[0];
            n45TipoDescarteId = T00133_n45TipoDescarteId[0];
            AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
            A48TempoRetencaoId = T00133_A48TempoRetencaoId[0];
            n48TempoRetencaoId = T00133_n48TempoRetencaoId[0];
            AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
            A24AreaResponsavelId = T00133_A24AreaResponsavelId[0];
            n24AreaResponsavelId = T00133_n24AreaResponsavelId[0];
            A106DocumentoProcessoId = T00133_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = T00133_n106DocumentoProcessoId[0];
            AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
            A110DocumentoControladorId = T00133_A110DocumentoControladorId[0];
            n110DocumentoControladorId = T00133_n110DocumentoControladorId[0];
            Z75DocumentoId = A75DocumentoId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1346( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey1346( ) ;
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1346( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1346( ) ;
         if ( RcdFound46 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound46 = 0;
         /* Using cursor T001332 */
         pr_default.execute(30, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            while ( (pr_default.getStatus(30) != 101) && ( ( T001332_A75DocumentoId[0] < A75DocumentoId ) ) )
            {
               pr_default.readNext(30);
            }
            if ( (pr_default.getStatus(30) != 101) && ( ( T001332_A75DocumentoId[0] > A75DocumentoId ) ) )
            {
               A75DocumentoId = T001332_A75DocumentoId[0];
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               RcdFound46 = 1;
            }
         }
         pr_default.close(30);
      }

      protected void move_previous( )
      {
         RcdFound46 = 0;
         /* Using cursor T001333 */
         pr_default.execute(31, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            while ( (pr_default.getStatus(31) != 101) && ( ( T001333_A75DocumentoId[0] > A75DocumentoId ) ) )
            {
               pr_default.readNext(31);
            }
            if ( (pr_default.getStatus(31) != 101) && ( ( T001333_A75DocumentoId[0] < A75DocumentoId ) ) )
            {
               A75DocumentoId = T001333_A75DocumentoId[0];
               AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               RcdFound46 = 1;
            }
         }
         pr_default.close(31);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1346( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynDocumentoProcessoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1346( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A75DocumentoId != Z75DocumentoId )
               {
                  A75DocumentoId = Z75DocumentoId;
                  AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCUMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynDocumentoProcessoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1346( ) ;
                  GX_FocusControl = dynDocumentoProcessoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A75DocumentoId != Z75DocumentoId )
               {
                  /* Insert record */
                  GX_FocusControl = dynDocumentoProcessoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1346( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCUMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtDocumentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynDocumentoProcessoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1346( ) ;
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
         if ( A75DocumentoId != Z75DocumentoId )
         {
            A75DocumentoId = Z75DocumentoId;
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynDocumentoProcessoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1346( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00132 */
            pr_default.execute(0, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z109DocumentoDataAlteracao != T00132_A109DocumentoDataAlteracao[0] ) || ( StringUtil.StrCmp(Z142DocumentoUsuarioAlteracao, T00132_A142DocumentoUsuarioAlteracao[0]) != 0 ) || ( StringUtil.StrCmp(Z76DocumentoNome, T00132_A76DocumentoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z77DocumentoFinalidadeTratamento, T00132_A77DocumentoFinalidadeTratamento[0]) != 0 ) || ( StringUtil.StrCmp(Z79DocumentoBaseLegalNorm, T00132_A79DocumentoBaseLegalNorm[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z80DocumentoBaseLegalNormIntExt, T00132_A80DocumentoBaseLegalNormIntExt[0]) != 0 ) || ( Z78DocumentoPrevColetaDados != T00132_A78DocumentoPrevColetaDados[0] ) || ( Z81DocumentoDadosCriancaAdolesc != T00132_A81DocumentoDadosCriancaAdolesc[0] ) || ( Z82DocumentoDadosGrupoVul != T00132_A82DocumentoDadosGrupoVul[0] ) || ( Z85DocumentoAtivo != T00132_A85DocumentoAtivo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z105DocumentoOperador != T00132_A105DocumentoOperador[0] ) || ( Z108DocumentoDataInclusao != T00132_A108DocumentoDataInclusao[0] ) || ( StringUtil.StrCmp(Z141DocumentoUsuarioInclusao, T00132_A141DocumentoUsuarioInclusao[0]) != 0 ) || ( Z143DocumentoIsOperador != T00132_A143DocumentoIsOperador[0] ) || ( Z20SubprocessoId != T00132_A20SubprocessoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z7EncarregadoId != T00132_A7EncarregadoId[0] ) || ( Z13PersonaId != T00132_A13PersonaId[0] ) || ( Z27CategoriaId != T00132_A27CategoriaId[0] ) || ( Z30TipoDadoId != T00132_A30TipoDadoId[0] ) || ( Z33FerramentaColetaId != T00132_A33FerramentaColetaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z36AbrangenciaGeograficaId != T00132_A36AbrangenciaGeograficaId[0] ) || ( Z39FrequenciaTratamentoId != T00132_A39FrequenciaTratamentoId[0] ) || ( Z45TipoDescarteId != T00132_A45TipoDescarteId[0] ) || ( Z48TempoRetencaoId != T00132_A48TempoRetencaoId[0] ) || ( Z24AreaResponsavelId != T00132_A24AreaResponsavelId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z106DocumentoProcessoId != T00132_A106DocumentoProcessoId[0] ) || ( Z110DocumentoControladorId != T00132_A110DocumentoControladorId[0] ) )
            {
               if ( Z109DocumentoDataAlteracao != T00132_A109DocumentoDataAlteracao[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoDataAlteracao");
                  GXUtil.WriteLogRaw("Old: ",Z109DocumentoDataAlteracao);
                  GXUtil.WriteLogRaw("Current: ",T00132_A109DocumentoDataAlteracao[0]);
               }
               if ( StringUtil.StrCmp(Z142DocumentoUsuarioAlteracao, T00132_A142DocumentoUsuarioAlteracao[0]) != 0 )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoUsuarioAlteracao");
                  GXUtil.WriteLogRaw("Old: ",Z142DocumentoUsuarioAlteracao);
                  GXUtil.WriteLogRaw("Current: ",T00132_A142DocumentoUsuarioAlteracao[0]);
               }
               if ( StringUtil.StrCmp(Z76DocumentoNome, T00132_A76DocumentoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoNome");
                  GXUtil.WriteLogRaw("Old: ",Z76DocumentoNome);
                  GXUtil.WriteLogRaw("Current: ",T00132_A76DocumentoNome[0]);
               }
               if ( StringUtil.StrCmp(Z77DocumentoFinalidadeTratamento, T00132_A77DocumentoFinalidadeTratamento[0]) != 0 )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoFinalidadeTratamento");
                  GXUtil.WriteLogRaw("Old: ",Z77DocumentoFinalidadeTratamento);
                  GXUtil.WriteLogRaw("Current: ",T00132_A77DocumentoFinalidadeTratamento[0]);
               }
               if ( StringUtil.StrCmp(Z79DocumentoBaseLegalNorm, T00132_A79DocumentoBaseLegalNorm[0]) != 0 )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoBaseLegalNorm");
                  GXUtil.WriteLogRaw("Old: ",Z79DocumentoBaseLegalNorm);
                  GXUtil.WriteLogRaw("Current: ",T00132_A79DocumentoBaseLegalNorm[0]);
               }
               if ( StringUtil.StrCmp(Z80DocumentoBaseLegalNormIntExt, T00132_A80DocumentoBaseLegalNormIntExt[0]) != 0 )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoBaseLegalNormIntExt");
                  GXUtil.WriteLogRaw("Old: ",Z80DocumentoBaseLegalNormIntExt);
                  GXUtil.WriteLogRaw("Current: ",T00132_A80DocumentoBaseLegalNormIntExt[0]);
               }
               if ( Z78DocumentoPrevColetaDados != T00132_A78DocumentoPrevColetaDados[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoPrevColetaDados");
                  GXUtil.WriteLogRaw("Old: ",Z78DocumentoPrevColetaDados);
                  GXUtil.WriteLogRaw("Current: ",T00132_A78DocumentoPrevColetaDados[0]);
               }
               if ( Z81DocumentoDadosCriancaAdolesc != T00132_A81DocumentoDadosCriancaAdolesc[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoDadosCriancaAdolesc");
                  GXUtil.WriteLogRaw("Old: ",Z81DocumentoDadosCriancaAdolesc);
                  GXUtil.WriteLogRaw("Current: ",T00132_A81DocumentoDadosCriancaAdolesc[0]);
               }
               if ( Z82DocumentoDadosGrupoVul != T00132_A82DocumentoDadosGrupoVul[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoDadosGrupoVul");
                  GXUtil.WriteLogRaw("Old: ",Z82DocumentoDadosGrupoVul);
                  GXUtil.WriteLogRaw("Current: ",T00132_A82DocumentoDadosGrupoVul[0]);
               }
               if ( Z85DocumentoAtivo != T00132_A85DocumentoAtivo[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z85DocumentoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T00132_A85DocumentoAtivo[0]);
               }
               if ( Z105DocumentoOperador != T00132_A105DocumentoOperador[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoOperador");
                  GXUtil.WriteLogRaw("Old: ",Z105DocumentoOperador);
                  GXUtil.WriteLogRaw("Current: ",T00132_A105DocumentoOperador[0]);
               }
               if ( Z108DocumentoDataInclusao != T00132_A108DocumentoDataInclusao[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoDataInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z108DocumentoDataInclusao);
                  GXUtil.WriteLogRaw("Current: ",T00132_A108DocumentoDataInclusao[0]);
               }
               if ( StringUtil.StrCmp(Z141DocumentoUsuarioInclusao, T00132_A141DocumentoUsuarioInclusao[0]) != 0 )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoUsuarioInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z141DocumentoUsuarioInclusao);
                  GXUtil.WriteLogRaw("Current: ",T00132_A141DocumentoUsuarioInclusao[0]);
               }
               if ( Z143DocumentoIsOperador != T00132_A143DocumentoIsOperador[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoIsOperador");
                  GXUtil.WriteLogRaw("Old: ",Z143DocumentoIsOperador);
                  GXUtil.WriteLogRaw("Current: ",T00132_A143DocumentoIsOperador[0]);
               }
               if ( Z20SubprocessoId != T00132_A20SubprocessoId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"SubprocessoId");
                  GXUtil.WriteLogRaw("Old: ",Z20SubprocessoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A20SubprocessoId[0]);
               }
               if ( Z7EncarregadoId != T00132_A7EncarregadoId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"EncarregadoId");
                  GXUtil.WriteLogRaw("Old: ",Z7EncarregadoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A7EncarregadoId[0]);
               }
               if ( Z13PersonaId != T00132_A13PersonaId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"PersonaId");
                  GXUtil.WriteLogRaw("Old: ",Z13PersonaId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A13PersonaId[0]);
               }
               if ( Z27CategoriaId != T00132_A27CategoriaId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"CategoriaId");
                  GXUtil.WriteLogRaw("Old: ",Z27CategoriaId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A27CategoriaId[0]);
               }
               if ( Z30TipoDadoId != T00132_A30TipoDadoId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"TipoDadoId");
                  GXUtil.WriteLogRaw("Old: ",Z30TipoDadoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A30TipoDadoId[0]);
               }
               if ( Z33FerramentaColetaId != T00132_A33FerramentaColetaId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"FerramentaColetaId");
                  GXUtil.WriteLogRaw("Old: ",Z33FerramentaColetaId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A33FerramentaColetaId[0]);
               }
               if ( Z36AbrangenciaGeograficaId != T00132_A36AbrangenciaGeograficaId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"AbrangenciaGeograficaId");
                  GXUtil.WriteLogRaw("Old: ",Z36AbrangenciaGeograficaId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A36AbrangenciaGeograficaId[0]);
               }
               if ( Z39FrequenciaTratamentoId != T00132_A39FrequenciaTratamentoId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"FrequenciaTratamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z39FrequenciaTratamentoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A39FrequenciaTratamentoId[0]);
               }
               if ( Z45TipoDescarteId != T00132_A45TipoDescarteId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"TipoDescarteId");
                  GXUtil.WriteLogRaw("Old: ",Z45TipoDescarteId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A45TipoDescarteId[0]);
               }
               if ( Z48TempoRetencaoId != T00132_A48TempoRetencaoId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"TempoRetencaoId");
                  GXUtil.WriteLogRaw("Old: ",Z48TempoRetencaoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A48TempoRetencaoId[0]);
               }
               if ( Z24AreaResponsavelId != T00132_A24AreaResponsavelId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"AreaResponsavelId");
                  GXUtil.WriteLogRaw("Old: ",Z24AreaResponsavelId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A24AreaResponsavelId[0]);
               }
               if ( Z106DocumentoProcessoId != T00132_A106DocumentoProcessoId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoProcessoId");
                  GXUtil.WriteLogRaw("Old: ",Z106DocumentoProcessoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A106DocumentoProcessoId[0]);
               }
               if ( Z110DocumentoControladorId != T00132_A110DocumentoControladorId[0] )
               {
                  GXUtil.WriteLog("documento:[seudo value changed for attri]"+"DocumentoControladorId");
                  GXUtil.WriteLogRaw("Old: ",Z110DocumentoControladorId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A110DocumentoControladorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1346( )
      {
         if ( ! IsAuthorized("documento_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1346( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1346( 0) ;
            CheckOptimisticConcurrency1346( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1346( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1346( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001334 */
                     pr_default.execute(32, new Object[] {n109DocumentoDataAlteracao, A109DocumentoDataAlteracao, n142DocumentoUsuarioAlteracao, A142DocumentoUsuarioAlteracao, n76DocumentoNome, A76DocumentoNome, n77DocumentoFinalidadeTratamento, A77DocumentoFinalidadeTratamento, n79DocumentoBaseLegalNorm, A79DocumentoBaseLegalNorm, n80DocumentoBaseLegalNormIntExt, A80DocumentoBaseLegalNormIntExt, n83DocumentoMedidaSegurancaDesc, A83DocumentoMedidaSegurancaDesc, n78DocumentoPrevColetaDados, A78DocumentoPrevColetaDados, n81DocumentoDadosCriancaAdolesc, A81DocumentoDadosCriancaAdolesc, n82DocumentoDadosGrupoVul, A82DocumentoDadosGrupoVul, n84DocumentoFluxoTratDadosDesc, A84DocumentoFluxoTratDadosDesc, n85DocumentoAtivo, A85DocumentoAtivo, n105DocumentoOperador, A105DocumentoOperador, n108DocumentoDataInclusao, A108DocumentoDataInclusao, n141DocumentoUsuarioInclusao, A141DocumentoUsuarioInclusao, n143DocumentoIsOperador, A143DocumentoIsOperador, n20SubprocessoId, A20SubprocessoId, n7EncarregadoId, A7EncarregadoId, n13PersonaId, A13PersonaId, n27CategoriaId, A27CategoriaId, n30TipoDadoId, A30TipoDadoId, n33FerramentaColetaId, A33FerramentaColetaId, n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId, n39FrequenciaTratamentoId, A39FrequenciaTratamentoId, n45TipoDescarteId, A45TipoDescarteId, n48TempoRetencaoId, A48TempoRetencaoId, n24AreaResponsavelId, A24AreaResponsavelId, n106DocumentoProcessoId, A106DocumentoProcessoId, n110DocumentoControladorId, A110DocumentoControladorId});
                     A75DocumentoId = T001334_A75DocumentoId[0];
                     AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
                     pr_default.close(32);
                     dsDefault.SmartCacheProvider.SetUpdated("Documento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption130( ) ;
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
               Load1346( ) ;
            }
            EndLevel1346( ) ;
         }
         CloseExtendedTableCursors1346( ) ;
      }

      protected void Update1346( )
      {
         if ( ! IsAuthorized("documento_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1346( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1346( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1346( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1346( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001335 */
                     pr_default.execute(33, new Object[] {n109DocumentoDataAlteracao, A109DocumentoDataAlteracao, n142DocumentoUsuarioAlteracao, A142DocumentoUsuarioAlteracao, n76DocumentoNome, A76DocumentoNome, n77DocumentoFinalidadeTratamento, A77DocumentoFinalidadeTratamento, n79DocumentoBaseLegalNorm, A79DocumentoBaseLegalNorm, n80DocumentoBaseLegalNormIntExt, A80DocumentoBaseLegalNormIntExt, n83DocumentoMedidaSegurancaDesc, A83DocumentoMedidaSegurancaDesc, n78DocumentoPrevColetaDados, A78DocumentoPrevColetaDados, n81DocumentoDadosCriancaAdolesc, A81DocumentoDadosCriancaAdolesc, n82DocumentoDadosGrupoVul, A82DocumentoDadosGrupoVul, n84DocumentoFluxoTratDadosDesc, A84DocumentoFluxoTratDadosDesc, n85DocumentoAtivo, A85DocumentoAtivo, n105DocumentoOperador, A105DocumentoOperador, n108DocumentoDataInclusao, A108DocumentoDataInclusao, n141DocumentoUsuarioInclusao, A141DocumentoUsuarioInclusao, n143DocumentoIsOperador, A143DocumentoIsOperador, n20SubprocessoId, A20SubprocessoId, n7EncarregadoId, A7EncarregadoId, n13PersonaId, A13PersonaId, n27CategoriaId, A27CategoriaId, n30TipoDadoId, A30TipoDadoId, n33FerramentaColetaId, A33FerramentaColetaId, n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId, n39FrequenciaTratamentoId, A39FrequenciaTratamentoId, n45TipoDescarteId, A45TipoDescarteId, n48TempoRetencaoId, A48TempoRetencaoId, n24AreaResponsavelId, A24AreaResponsavelId, n106DocumentoProcessoId, A106DocumentoProcessoId, n110DocumentoControladorId, A110DocumentoControladorId, A75DocumentoId});
                     pr_default.close(33);
                     dsDefault.SmartCacheProvider.SetUpdated("Documento");
                     if ( (pr_default.getStatus(33) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1346( ) ;
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
            EndLevel1346( ) ;
         }
         CloseExtendedTableCursors1346( ) ;
      }

      protected void DeferredUpdate1346( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("documento_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1346( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1346( ) ;
            AfterConfirm1346( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1346( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001336 */
                  pr_default.execute(34, new Object[] {A75DocumentoId});
                  pr_default.close(34);
                  dsDefault.SmartCacheProvider.SetUpdated("Documento");
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
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1346( ) ;
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1346( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001337 */
            pr_default.execute(35, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
            A107DocumentoProcessoNome = T001337_A107DocumentoProcessoNome[0];
            pr_default.close(35);
            GXASUBPROCESSOID_html1346( A106DocumentoProcessoId) ;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001338 */
            pr_default.execute(36, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DocImagem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T001339 */
            pr_default.execute(37, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"RevisaoLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T001340 */
            pr_default.execute(38, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T001341 */
            pr_default.execute(39, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T001342 */
            pr_default.execute(40, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T001343 */
            pr_default.execute(41, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DocMedidaSeguranca"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T001344 */
            pr_default.execute(42, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Fonte Retencao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T001345 */
            pr_default.execute(43, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Setor Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T001346 */
            pr_default.execute(44, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Compart Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T001347 */
            pr_default.execute(45, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Envolvidos Coleta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
         }
      }

      protected void EndLevel1346( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1346( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(35);
            context.CommitDataStores("documento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues130( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(35);
            context.RollbackDataStores("documento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1346( )
      {
         /* Scan By routine */
         /* Using cursor T001348 */
         pr_default.execute(46);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound46 = 1;
            A75DocumentoId = T001348_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1346( )
      {
         /* Scan next routine */
         pr_default.readNext(46);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound46 = 1;
            A75DocumentoId = T001348_A75DocumentoId[0];
            AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
      }

      protected void ScanEnd1346( )
      {
         pr_default.close(46);
      }

      protected void AfterConfirm1346( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1346( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1346( )
      {
         /* Before Update Rules */
         A109DocumentoDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         n109DocumentoDataAlteracao = false;
         AssignAttri("", false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
         A142DocumentoUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n142DocumentoUsuarioAlteracao = false;
         AssignAttri("", false, "A142DocumentoUsuarioAlteracao", A142DocumentoUsuarioAlteracao);
      }

      protected void BeforeDelete1346( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1346( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1346( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1346( )
      {
         dynDocumentoProcessoId.Enabled = 0;
         AssignProp("", false, dynDocumentoProcessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDocumentoProcessoId.Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp("", false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         dynSubprocessoId.Enabled = 0;
         AssignProp("", false, dynSubprocessoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSubprocessoId.Enabled), 5, 0), true);
         edtDocumentoDataInclusao_Enabled = 0;
         AssignProp("", false, edtDocumentoDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoDataInclusao_Enabled), 5, 0), true);
         edtDocumentoDataAlteracao_Enabled = 0;
         AssignProp("", false, edtDocumentoDataAlteracao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoDataAlteracao_Enabled), 5, 0), true);
         dynPersonaId.Enabled = 0;
         AssignProp("", false, dynPersonaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPersonaId.Enabled), 5, 0), true);
         dynEncarregadoId.Enabled = 0;
         AssignProp("", false, dynEncarregadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEncarregadoId.Enabled), 5, 0), true);
         edtDocumentoNome_Enabled = 0;
         AssignProp("", false, edtDocumentoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoNome_Enabled), 5, 0), true);
         cmbDocumentoAtivo.Enabled = 0;
         AssignProp("", false, cmbDocumentoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentoAtivo.Enabled), 5, 0), true);
         edtDocumentoFinalidadeTratamento_Enabled = 0;
         AssignProp("", false, edtDocumentoFinalidadeTratamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoFinalidadeTratamento_Enabled), 5, 0), true);
         dynCategoriaId.Enabled = 0;
         AssignProp("", false, dynCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCategoriaId.Enabled), 5, 0), true);
         dynTipoDadoId.Enabled = 0;
         AssignProp("", false, dynTipoDadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoDadoId.Enabled), 5, 0), true);
         dynFerramentaColetaId.Enabled = 0;
         AssignProp("", false, dynFerramentaColetaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynFerramentaColetaId.Enabled), 5, 0), true);
         dynAbrangenciaGeograficaId.Enabled = 0;
         AssignProp("", false, dynAbrangenciaGeograficaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynAbrangenciaGeograficaId.Enabled), 5, 0), true);
         dynFrequenciaTratamentoId.Enabled = 0;
         AssignProp("", false, dynFrequenciaTratamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynFrequenciaTratamentoId.Enabled), 5, 0), true);
         dynTipoDescarteId.Enabled = 0;
         AssignProp("", false, dynTipoDescarteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoDescarteId.Enabled), 5, 0), true);
         dynTempoRetencaoId.Enabled = 0;
         AssignProp("", false, dynTempoRetencaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTempoRetencaoId.Enabled), 5, 0), true);
         radDocumentoPrevColetaDados.Enabled = 0;
         AssignProp("", false, radDocumentoPrevColetaDados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radDocumentoPrevColetaDados.Enabled), 5, 0), true);
         edtDocumentoBaseLegalNorm_Enabled = 0;
         AssignProp("", false, edtDocumentoBaseLegalNorm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoBaseLegalNorm_Enabled), 5, 0), true);
         edtDocumentoBaseLegalNormIntExt_Enabled = 0;
         AssignProp("", false, edtDocumentoBaseLegalNormIntExt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoBaseLegalNormIntExt_Enabled), 5, 0), true);
         chkDocumentoDadosGrupoVul.Enabled = 0;
         AssignProp("", false, chkDocumentoDadosGrupoVul_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocumentoDadosGrupoVul.Enabled), 5, 0), true);
         chkDocumentoDadosCriancaAdolesc.Enabled = 0;
         AssignProp("", false, chkDocumentoDadosCriancaAdolesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocumentoDadosCriancaAdolesc.Enabled), 5, 0), true);
         edtDocumentoMedidaSegurancaDesc_Enabled = 0;
         AssignProp("", false, edtDocumentoMedidaSegurancaDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoMedidaSegurancaDesc_Enabled), 5, 0), true);
         edtDocumentoFluxoTratDadosDesc_Enabled = 0;
         AssignProp("", false, edtDocumentoFluxoTratDadosDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoFluxoTratDadosDesc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1346( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues130( )
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
         GXEncryptionTmp = "documento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocumentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV56Aba));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Documento");
         forbiddenHiddens.Add("DocumentoId", context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("DocumentoOperador", StringUtil.BoolToStr( A105DocumentoOperador));
         forbiddenHiddens.Add("DocumentoDataInclusao", context.localUtil.Format( A108DocumentoDataInclusao, "99/99/99 99:99"));
         forbiddenHiddens.Add("DocumentoUsuarioInclusao", StringUtil.RTrim( context.localUtil.Format( A141DocumentoUsuarioInclusao, "")));
         forbiddenHiddens.Add("DocumentoIsOperador", StringUtil.BoolToStr( A143DocumentoIsOperador));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("documento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z109DocumentoDataAlteracao", context.localUtil.TToC( Z109DocumentoDataAlteracao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z142DocumentoUsuarioAlteracao", Z142DocumentoUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "Z76DocumentoNome", Z76DocumentoNome);
         GxWebStd.gx_hidden_field( context, "Z77DocumentoFinalidadeTratamento", Z77DocumentoFinalidadeTratamento);
         GxWebStd.gx_hidden_field( context, "Z79DocumentoBaseLegalNorm", Z79DocumentoBaseLegalNorm);
         GxWebStd.gx_hidden_field( context, "Z80DocumentoBaseLegalNormIntExt", Z80DocumentoBaseLegalNormIntExt);
         GxWebStd.gx_boolean_hidden_field( context, "Z78DocumentoPrevColetaDados", Z78DocumentoPrevColetaDados);
         GxWebStd.gx_boolean_hidden_field( context, "Z81DocumentoDadosCriancaAdolesc", Z81DocumentoDadosCriancaAdolesc);
         GxWebStd.gx_boolean_hidden_field( context, "Z82DocumentoDadosGrupoVul", Z82DocumentoDadosGrupoVul);
         GxWebStd.gx_boolean_hidden_field( context, "Z85DocumentoAtivo", Z85DocumentoAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z105DocumentoOperador", Z105DocumentoOperador);
         GxWebStd.gx_hidden_field( context, "Z108DocumentoDataInclusao", context.localUtil.TToC( Z108DocumentoDataInclusao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z141DocumentoUsuarioInclusao", Z141DocumentoUsuarioInclusao);
         GxWebStd.gx_boolean_hidden_field( context, "Z143DocumentoIsOperador", Z143DocumentoIsOperador);
         GxWebStd.gx_hidden_field( context, "Z20SubprocessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20SubprocessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7EncarregadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7EncarregadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13PersonaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13PersonaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z27CategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27CategoriaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z30TipoDadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30TipoDadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z33FerramentaColetaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33FerramentaColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z36AbrangenciaGeograficaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36AbrangenciaGeograficaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z39FrequenciaTratamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39FrequenciaTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z45TipoDescarteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45TipoDescarteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z48TempoRetencaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48TempoRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z24AreaResponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24AreaResponsavelId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z106DocumentoProcessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106DocumentoProcessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z110DocumentoControladorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110DocumentoControladorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N20SubprocessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N7EncarregadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7EncarregadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N13PersonaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PersonaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N27CategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27CategoriaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N30TipoDadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30TipoDadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N33FerramentaColetaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FerramentaColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N36AbrangenciaGeograficaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AbrangenciaGeograficaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N39FrequenciaTratamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39FrequenciaTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N45TipoDescarteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TipoDescarteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N48TempoRetencaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48TempoRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N106DocumentoProcessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106DocumentoProcessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N110DocumentoControladorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110DocumentoControladorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N24AreaResponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AreaResponsavelId), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vABA", AV56Aba);
         GxWebStd.gx_hidden_field( context, "gxhash_vABA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Aba, "")), context));
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocumentoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUBPROCESSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_SubprocessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ENCARREGADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_EncarregadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PERSONAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_PersonaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Insert_CategoriaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPODADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Insert_TipoDadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_FERRAMENTACOLETAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Insert_FerramentaColetaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ABRANGENCIAGEOGRAFICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Insert_AbrangenciaGeograficaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_FREQUENCIATRATAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_FrequenciaTratamentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPODESCARTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21Insert_TipoDescarteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TEMPORETENCAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_TempoRetencaoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTOPROCESSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53Insert_DocumentoProcessoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTOCONTROLADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58Insert_DocumentoControladorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCUMENTOCONTROLADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110DocumentoControladorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_AREARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59Insert_AreaResponsavelId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AREARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AreaResponsavelId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCUMENTOUSUARIOALTERACAO", A142DocumentoUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCUMENTOUSUARIOINCLUSAO", A141DocumentoUsuarioInclusao);
         GxWebStd.gx_boolean_hidden_field( context, "DOCUMENTOISOPERADOR", A143DocumentoIsOperador);
         GxWebStd.gx_boolean_hidden_field( context, "DOCUMENTOOPERADOR", A105DocumentoOperador);
         GxWebStd.gx_hidden_field( context, "DOCUMENTOPROCESSONOME", A107DocumentoProcessoNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
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
         GXEncryptionTmp = "documento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocumentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV56Aba));
         return formatLink("documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Documento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documento" ;
      }

      protected void InitializeNonKey1346( )
      {
         A20SubprocessoId = 0;
         n20SubprocessoId = false;
         AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrimStr( (decimal)(A20SubprocessoId), 8, 0));
         n20SubprocessoId = ((0==A20SubprocessoId) ? true : false);
         A7EncarregadoId = 0;
         n7EncarregadoId = false;
         AssignAttri("", false, "A7EncarregadoId", StringUtil.LTrimStr( (decimal)(A7EncarregadoId), 8, 0));
         n7EncarregadoId = ((0==A7EncarregadoId) ? true : false);
         A13PersonaId = 0;
         n13PersonaId = false;
         AssignAttri("", false, "A13PersonaId", StringUtil.LTrimStr( (decimal)(A13PersonaId), 8, 0));
         n13PersonaId = ((0==A13PersonaId) ? true : false);
         A27CategoriaId = 0;
         n27CategoriaId = false;
         AssignAttri("", false, "A27CategoriaId", StringUtil.LTrimStr( (decimal)(A27CategoriaId), 8, 0));
         n27CategoriaId = ((0==A27CategoriaId) ? true : false);
         A30TipoDadoId = 0;
         n30TipoDadoId = false;
         AssignAttri("", false, "A30TipoDadoId", StringUtil.LTrimStr( (decimal)(A30TipoDadoId), 8, 0));
         n30TipoDadoId = ((0==A30TipoDadoId) ? true : false);
         A33FerramentaColetaId = 0;
         n33FerramentaColetaId = false;
         AssignAttri("", false, "A33FerramentaColetaId", StringUtil.LTrimStr( (decimal)(A33FerramentaColetaId), 8, 0));
         n33FerramentaColetaId = ((0==A33FerramentaColetaId) ? true : false);
         A36AbrangenciaGeograficaId = 0;
         n36AbrangenciaGeograficaId = false;
         AssignAttri("", false, "A36AbrangenciaGeograficaId", StringUtil.LTrimStr( (decimal)(A36AbrangenciaGeograficaId), 8, 0));
         n36AbrangenciaGeograficaId = ((0==A36AbrangenciaGeograficaId) ? true : false);
         A39FrequenciaTratamentoId = 0;
         n39FrequenciaTratamentoId = false;
         AssignAttri("", false, "A39FrequenciaTratamentoId", StringUtil.LTrimStr( (decimal)(A39FrequenciaTratamentoId), 8, 0));
         n39FrequenciaTratamentoId = ((0==A39FrequenciaTratamentoId) ? true : false);
         A45TipoDescarteId = 0;
         n45TipoDescarteId = false;
         AssignAttri("", false, "A45TipoDescarteId", StringUtil.LTrimStr( (decimal)(A45TipoDescarteId), 8, 0));
         n45TipoDescarteId = ((0==A45TipoDescarteId) ? true : false);
         A48TempoRetencaoId = 0;
         n48TempoRetencaoId = false;
         AssignAttri("", false, "A48TempoRetencaoId", StringUtil.LTrimStr( (decimal)(A48TempoRetencaoId), 8, 0));
         n48TempoRetencaoId = ((0==A48TempoRetencaoId) ? true : false);
         A106DocumentoProcessoId = 0;
         n106DocumentoProcessoId = false;
         AssignAttri("", false, "A106DocumentoProcessoId", StringUtil.LTrimStr( (decimal)(A106DocumentoProcessoId), 8, 0));
         n106DocumentoProcessoId = ((0==A106DocumentoProcessoId) ? true : false);
         A110DocumentoControladorId = 0;
         n110DocumentoControladorId = false;
         AssignAttri("", false, "A110DocumentoControladorId", StringUtil.LTrimStr( (decimal)(A110DocumentoControladorId), 8, 0));
         A24AreaResponsavelId = 0;
         n24AreaResponsavelId = false;
         AssignAttri("", false, "A24AreaResponsavelId", StringUtil.LTrimStr( (decimal)(A24AreaResponsavelId), 8, 0));
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         n109DocumentoDataAlteracao = false;
         AssignAttri("", false, "A109DocumentoDataAlteracao", context.localUtil.TToC( A109DocumentoDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
         n109DocumentoDataAlteracao = ((DateTime.MinValue==A109DocumentoDataAlteracao) ? true : false);
         A142DocumentoUsuarioAlteracao = "";
         n142DocumentoUsuarioAlteracao = false;
         AssignAttri("", false, "A142DocumentoUsuarioAlteracao", A142DocumentoUsuarioAlteracao);
         A76DocumentoNome = "";
         n76DocumentoNome = false;
         AssignAttri("", false, "A76DocumentoNome", A76DocumentoNome);
         n76DocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A76DocumentoNome)) ? true : false);
         A77DocumentoFinalidadeTratamento = "";
         n77DocumentoFinalidadeTratamento = false;
         AssignAttri("", false, "A77DocumentoFinalidadeTratamento", A77DocumentoFinalidadeTratamento);
         n77DocumentoFinalidadeTratamento = (String.IsNullOrEmpty(StringUtil.RTrim( A77DocumentoFinalidadeTratamento)) ? true : false);
         A79DocumentoBaseLegalNorm = "";
         n79DocumentoBaseLegalNorm = false;
         AssignAttri("", false, "A79DocumentoBaseLegalNorm", A79DocumentoBaseLegalNorm);
         n79DocumentoBaseLegalNorm = (String.IsNullOrEmpty(StringUtil.RTrim( A79DocumentoBaseLegalNorm)) ? true : false);
         A80DocumentoBaseLegalNormIntExt = "";
         n80DocumentoBaseLegalNormIntExt = false;
         AssignAttri("", false, "A80DocumentoBaseLegalNormIntExt", A80DocumentoBaseLegalNormIntExt);
         n80DocumentoBaseLegalNormIntExt = (String.IsNullOrEmpty(StringUtil.RTrim( A80DocumentoBaseLegalNormIntExt)) ? true : false);
         A83DocumentoMedidaSegurancaDesc = "";
         n83DocumentoMedidaSegurancaDesc = false;
         AssignAttri("", false, "A83DocumentoMedidaSegurancaDesc", A83DocumentoMedidaSegurancaDesc);
         n83DocumentoMedidaSegurancaDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A83DocumentoMedidaSegurancaDesc)) ? true : false);
         A78DocumentoPrevColetaDados = false;
         n78DocumentoPrevColetaDados = false;
         AssignAttri("", false, "A78DocumentoPrevColetaDados", A78DocumentoPrevColetaDados);
         n78DocumentoPrevColetaDados = ((false==A78DocumentoPrevColetaDados) ? true : false);
         A81DocumentoDadosCriancaAdolesc = false;
         n81DocumentoDadosCriancaAdolesc = false;
         AssignAttri("", false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
         n81DocumentoDadosCriancaAdolesc = ((false==A81DocumentoDadosCriancaAdolesc) ? true : false);
         A82DocumentoDadosGrupoVul = false;
         n82DocumentoDadosGrupoVul = false;
         AssignAttri("", false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
         n82DocumentoDadosGrupoVul = ((false==A82DocumentoDadosGrupoVul) ? true : false);
         A84DocumentoFluxoTratDadosDesc = "";
         n84DocumentoFluxoTratDadosDesc = false;
         AssignAttri("", false, "A84DocumentoFluxoTratDadosDesc", A84DocumentoFluxoTratDadosDesc);
         n84DocumentoFluxoTratDadosDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A84DocumentoFluxoTratDadosDesc)) ? true : false);
         A105DocumentoOperador = false;
         n105DocumentoOperador = false;
         AssignAttri("", false, "A105DocumentoOperador", A105DocumentoOperador);
         A107DocumentoProcessoNome = "";
         AssignAttri("", false, "A107DocumentoProcessoNome", A107DocumentoProcessoNome);
         A85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
         A108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
         A141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         AssignAttri("", false, "A141DocumentoUsuarioInclusao", A141DocumentoUsuarioInclusao);
         A143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         AssignAttri("", false, "A143DocumentoIsOperador", A143DocumentoIsOperador);
         Z109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         Z142DocumentoUsuarioAlteracao = "";
         Z76DocumentoNome = "";
         Z77DocumentoFinalidadeTratamento = "";
         Z79DocumentoBaseLegalNorm = "";
         Z80DocumentoBaseLegalNormIntExt = "";
         Z78DocumentoPrevColetaDados = false;
         Z81DocumentoDadosCriancaAdolesc = false;
         Z82DocumentoDadosGrupoVul = false;
         Z85DocumentoAtivo = false;
         Z105DocumentoOperador = false;
         Z108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         Z141DocumentoUsuarioInclusao = "";
         Z143DocumentoIsOperador = false;
         Z20SubprocessoId = 0;
         Z7EncarregadoId = 0;
         Z13PersonaId = 0;
         Z27CategoriaId = 0;
         Z30TipoDadoId = 0;
         Z33FerramentaColetaId = 0;
         Z36AbrangenciaGeograficaId = 0;
         Z39FrequenciaTratamentoId = 0;
         Z45TipoDescarteId = 0;
         Z48TempoRetencaoId = 0;
         Z24AreaResponsavelId = 0;
         Z106DocumentoProcessoId = 0;
         Z110DocumentoControladorId = 0;
      }

      protected void InitAll1346( )
      {
         A75DocumentoId = 0;
         AssignAttri("", false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         InitializeNonKey1346( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A85DocumentoAtivo = i85DocumentoAtivo;
         n85DocumentoAtivo = false;
         AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
         A108DocumentoDataInclusao = i108DocumentoDataInclusao;
         n108DocumentoDataInclusao = false;
         AssignAttri("", false, "A108DocumentoDataInclusao", context.localUtil.TToC( A108DocumentoDataInclusao, 8, 5, 0, 3, "/", ":", " "));
         A141DocumentoUsuarioInclusao = i141DocumentoUsuarioInclusao;
         n141DocumentoUsuarioInclusao = false;
         AssignAttri("", false, "A141DocumentoUsuarioInclusao", A141DocumentoUsuarioInclusao);
         A143DocumentoIsOperador = i143DocumentoIsOperador;
         n143DocumentoIsOperador = false;
         AssignAttri("", false, "A143DocumentoIsOperador", A143DocumentoIsOperador);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231241744382", true, true);
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
         context.AddJavascriptSource("documento.js", "?20231241744383", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         dynDocumentoProcessoId_Internalname = "DOCUMENTOPROCESSOID";
         edtDocumentoId_Internalname = "DOCUMENTOID";
         dynSubprocessoId_Internalname = "SUBPROCESSOID";
         edtDocumentoDataInclusao_Internalname = "DOCUMENTODATAINCLUSAO";
         edtavArearesponsavelnome_Internalname = "vAREARESPONSAVELNOME";
         edtDocumentoDataAlteracao_Internalname = "DOCUMENTODATAALTERACAO";
         dynPersonaId_Internalname = "PERSONAID";
         dynEncarregadoId_Internalname = "ENCARREGADOID";
         edtDocumentoNome_Internalname = "DOCUMENTONOME";
         cmbDocumentoAtivo_Internalname = "DOCUMENTOATIVO";
         divTabledocumento_Internalname = "TABLEDOCUMENTO";
         edtDocumentoFinalidadeTratamento_Internalname = "DOCUMENTOFINALIDADETRATAMENTO";
         dynCategoriaId_Internalname = "CATEGORIAID";
         dynTipoDadoId_Internalname = "TIPODADOID";
         dynFerramentaColetaId_Internalname = "FERRAMENTACOLETAID";
         dynAbrangenciaGeograficaId_Internalname = "ABRANGENCIAGEOGRAFICAID";
         dynFrequenciaTratamentoId_Internalname = "FREQUENCIATRATAMENTOID";
         dynTipoDescarteId_Internalname = "TIPODESCARTEID";
         dynTempoRetencaoId_Internalname = "TEMPORETENCAOID";
         radDocumentoPrevColetaDados_Internalname = "DOCUMENTOPREVCOLETADADOS";
         edtDocumentoBaseLegalNorm_Internalname = "DOCUMENTOBASELEGALNORM";
         edtDocumentoBaseLegalNormIntExt_Internalname = "DOCUMENTOBASELEGALNORMINTEXT";
         chkDocumentoDadosGrupoVul_Internalname = "DOCUMENTODADOSGRUPOVUL";
         chkDocumentoDadosCriancaAdolesc_Internalname = "DOCUMENTODADOSCRIANCAADOLESC";
         edtDocumentoMedidaSegurancaDesc_Internalname = "DOCUMENTOMEDIDASEGURANCADESC";
         edtDocumentoFluxoTratDadosDesc_Internalname = "DOCUMENTOFLUXOTRATDADOSDESC";
         divTabletratamento_Internalname = "TABLETRATAMENTO";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavArearesponsavelid_Internalname = "vAREARESPONSAVELID";
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
         Form.Caption = "Documento";
         edtavArearesponsavelid_Jsonclick = "";
         edtavArearesponsavelid_Enabled = 0;
         edtavArearesponsavelid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocumentoFluxoTratDadosDesc_Enabled = 1;
         edtDocumentoMedidaSegurancaDesc_Enabled = 1;
         chkDocumentoDadosCriancaAdolesc.Enabled = 1;
         chkDocumentoDadosGrupoVul.Enabled = 1;
         edtDocumentoBaseLegalNormIntExt_Jsonclick = "";
         edtDocumentoBaseLegalNormIntExt_Enabled = 1;
         edtDocumentoBaseLegalNorm_Jsonclick = "";
         edtDocumentoBaseLegalNorm_Enabled = 1;
         radDocumentoPrevColetaDados_Jsonclick = "";
         radDocumentoPrevColetaDados.Enabled = 1;
         dynTempoRetencaoId_Jsonclick = "";
         dynTempoRetencaoId.Enabled = 1;
         dynTipoDescarteId_Jsonclick = "";
         dynTipoDescarteId.Enabled = 1;
         dynFrequenciaTratamentoId_Jsonclick = "";
         dynFrequenciaTratamentoId.Enabled = 1;
         dynAbrangenciaGeograficaId_Jsonclick = "";
         dynAbrangenciaGeograficaId.Enabled = 1;
         dynFerramentaColetaId_Jsonclick = "";
         dynFerramentaColetaId.Enabled = 1;
         dynTipoDadoId_Jsonclick = "";
         dynTipoDadoId.Enabled = 1;
         dynCategoriaId_Jsonclick = "";
         dynCategoriaId.Enabled = 1;
         edtDocumentoFinalidadeTratamento_Jsonclick = "";
         edtDocumentoFinalidadeTratamento_Enabled = 1;
         cmbDocumentoAtivo_Jsonclick = "";
         cmbDocumentoAtivo.Enabled = 1;
         edtDocumentoNome_Jsonclick = "";
         edtDocumentoNome_Enabled = 1;
         dynEncarregadoId_Jsonclick = "";
         dynEncarregadoId.Enabled = 1;
         dynPersonaId_Jsonclick = "";
         dynPersonaId.Enabled = 1;
         edtDocumentoDataAlteracao_Jsonclick = "";
         edtDocumentoDataAlteracao_Enabled = 0;
         edtavArearesponsavelnome_Jsonclick = "";
         edtavArearesponsavelnome_Enabled = 0;
         edtDocumentoDataInclusao_Jsonclick = "";
         edtDocumentoDataInclusao_Enabled = 0;
         dynSubprocessoId_Jsonclick = "";
         dynSubprocessoId.Enabled = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 0;
         dynDocumentoProcessoId_Jsonclick = "";
         dynDocumentoProcessoId.Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXASUBPROCESSOID_html1346( A106DocumentoProcessoId) ;
         /* End function dynload_actions */
      }

      protected void GXDLADOCUMENTOPROCESSOID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADOCUMENTOPROCESSOID_data1346( ) ;
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

      protected void GXADOCUMENTOPROCESSOID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLADOCUMENTOPROCESSOID_data1346( ) ;
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
      }

      protected void GXDLADOCUMENTOPROCESSOID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001349 */
         pr_default.execute(47);
         while ( (pr_default.getStatus(47) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001349_A106DocumentoProcessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001349_A107DocumentoProcessoNome[0]);
            pr_default.readNext(47);
         }
         pr_default.close(47);
      }

      protected void GXDLASUBPROCESSOID1346( int A106DocumentoProcessoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUBPROCESSOID_data1346( A106DocumentoProcessoId) ;
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

      protected void GXASUBPROCESSOID_html1346( int A106DocumentoProcessoId )
      {
         int gxdynajaxvalue;
         GXDLASUBPROCESSOID_data1346( A106DocumentoProcessoId) ;
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
      }

      protected void GXDLASUBPROCESSOID_data1346( int A106DocumentoProcessoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001350 */
         pr_default.execute(48, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
         while ( (pr_default.getStatus(48) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001350_A20SubprocessoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001350_A21SubprocessoNome[0]);
            pr_default.readNext(48);
         }
         pr_default.close(48);
      }

      protected void GXDLAPERSONAID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPERSONAID_data1346( ) ;
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

      protected void GXAPERSONAID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLAPERSONAID_data1346( ) ;
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
      }

      protected void GXDLAPERSONAID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001351 */
         pr_default.execute(49);
         while ( (pr_default.getStatus(49) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001351_A13PersonaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001351_A14PersonaNome[0]);
            pr_default.readNext(49);
         }
         pr_default.close(49);
      }

      protected void GXDLAENCARREGADOID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAENCARREGADOID_data1346( ) ;
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

      protected void GXAENCARREGADOID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLAENCARREGADOID_data1346( ) ;
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
      }

      protected void GXDLAENCARREGADOID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001352 */
         pr_default.execute(50);
         while ( (pr_default.getStatus(50) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001352_A7EncarregadoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001352_A8EncarregadoNome[0]);
            pr_default.readNext(50);
         }
         pr_default.close(50);
      }

      protected void GXDLACATEGORIAID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACATEGORIAID_data1346( ) ;
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

      protected void GXACATEGORIAID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLACATEGORIAID_data1346( ) ;
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
      }

      protected void GXDLACATEGORIAID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001353 */
         pr_default.execute(51);
         while ( (pr_default.getStatus(51) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001353_A10ControladorId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001353_A11ControladorNome[0]);
            pr_default.readNext(51);
         }
         pr_default.close(51);
      }

      protected void GXDLATIPODADOID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPODADOID_data1346( ) ;
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

      protected void GXATIPODADOID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLATIPODADOID_data1346( ) ;
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
      }

      protected void GXDLATIPODADOID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001354 */
         pr_default.execute(52);
         while ( (pr_default.getStatus(52) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001354_A30TipoDadoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001354_A31TipoDadoNome[0]);
            pr_default.readNext(52);
         }
         pr_default.close(52);
      }

      protected void GXDLAFERRAMENTACOLETAID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAFERRAMENTACOLETAID_data1346( ) ;
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

      protected void GXAFERRAMENTACOLETAID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLAFERRAMENTACOLETAID_data1346( ) ;
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
      }

      protected void GXDLAFERRAMENTACOLETAID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001355 */
         pr_default.execute(53);
         while ( (pr_default.getStatus(53) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001355_A33FerramentaColetaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001355_A34FerramentaColetaNome[0]);
            pr_default.readNext(53);
         }
         pr_default.close(53);
      }

      protected void GXDLAABRANGENCIAGEOGRAFICAID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAABRANGENCIAGEOGRAFICAID_data1346( ) ;
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

      protected void GXAABRANGENCIAGEOGRAFICAID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLAABRANGENCIAGEOGRAFICAID_data1346( ) ;
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
      }

      protected void GXDLAABRANGENCIAGEOGRAFICAID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001356 */
         pr_default.execute(54);
         while ( (pr_default.getStatus(54) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001356_A36AbrangenciaGeograficaId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001356_A37AbrangenciaGeograficaNome[0]);
            pr_default.readNext(54);
         }
         pr_default.close(54);
      }

      protected void GXDLAFREQUENCIATRATAMENTOID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAFREQUENCIATRATAMENTOID_data1346( ) ;
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

      protected void GXAFREQUENCIATRATAMENTOID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLAFREQUENCIATRATAMENTOID_data1346( ) ;
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
      }

      protected void GXDLAFREQUENCIATRATAMENTOID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001357 */
         pr_default.execute(55);
         while ( (pr_default.getStatus(55) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001357_A39FrequenciaTratamentoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001357_A40FrequenciaTratamentoNome[0]);
            pr_default.readNext(55);
         }
         pr_default.close(55);
      }

      protected void GXDLATIPODESCARTEID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPODESCARTEID_data1346( ) ;
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

      protected void GXATIPODESCARTEID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLATIPODESCARTEID_data1346( ) ;
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
      }

      protected void GXDLATIPODESCARTEID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001358 */
         pr_default.execute(56);
         while ( (pr_default.getStatus(56) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001358_A45TipoDescarteId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001358_A46TipoDescarteNome[0]);
            pr_default.readNext(56);
         }
         pr_default.close(56);
      }

      protected void GXDLATEMPORETENCAOID1346( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATEMPORETENCAOID_data1346( ) ;
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

      protected void GXATEMPORETENCAOID_html1346( )
      {
         int gxdynajaxvalue;
         GXDLATEMPORETENCAOID_data1346( ) ;
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
      }

      protected void GXDLATEMPORETENCAOID_data1346( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001359 */
         pr_default.execute(57);
         while ( (pr_default.getStatus(57) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001359_A48TempoRetencaoId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001359_A49TempoRetencaoNome[0]);
            pr_default.readNext(57);
         }
         pr_default.close(57);
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
            if ( IsIns( ) && (false==A85DocumentoAtivo) )
            {
               A85DocumentoAtivo = true;
               n85DocumentoAtivo = false;
               AssignAttri("", false, "A85DocumentoAtivo", A85DocumentoAtivo);
            }
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
         AssignProp("", false, chkDocumentoDadosGrupoVul_Internalname, "TitleCaption", chkDocumentoDadosGrupoVul.Caption, true);
         chkDocumentoDadosGrupoVul.CheckedValue = "false";
         A82DocumentoDadosGrupoVul = StringUtil.StrToBool( StringUtil.BoolToStr( A82DocumentoDadosGrupoVul));
         n82DocumentoDadosGrupoVul = false;
         AssignAttri("", false, "A82DocumentoDadosGrupoVul", A82DocumentoDadosGrupoVul);
         chkDocumentoDadosCriancaAdolesc.Name = "DOCUMENTODADOSCRIANCAADOLESC";
         chkDocumentoDadosCriancaAdolesc.WebTags = "";
         chkDocumentoDadosCriancaAdolesc.Caption = "";
         AssignProp("", false, chkDocumentoDadosCriancaAdolesc_Internalname, "TitleCaption", chkDocumentoDadosCriancaAdolesc.Caption, true);
         chkDocumentoDadosCriancaAdolesc.CheckedValue = "false";
         A81DocumentoDadosCriancaAdolesc = StringUtil.StrToBool( StringUtil.BoolToStr( A81DocumentoDadosCriancaAdolesc));
         n81DocumentoDadosCriancaAdolesc = false;
         AssignAttri("", false, "A81DocumentoDadosCriancaAdolesc", A81DocumentoDadosCriancaAdolesc);
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

      public void Valid_Documentoprocessoid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001360 */
         pr_default.execute(58, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
         if ( (pr_default.getStatus(58) == 101) )
         {
            if ( ! ( (0==A106DocumentoProcessoId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Processo'.", "ForeignKeyNotFound", 1, "DOCUMENTOPROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynDocumentoProcessoId_Internalname;
            }
         }
         A107DocumentoProcessoNome = T001360_A107DocumentoProcessoNome[0];
         pr_default.close(58);
         GXASUBPROCESSOID_html1346( A106DocumentoProcessoId) ;
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
         AssignAttri("", false, "A107DocumentoProcessoNome", A107DocumentoProcessoNome);
         AssignAttri("", false, "A20SubprocessoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SubprocessoId), 8, 0, ".", "")));
         dynSubprocessoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A20SubprocessoId), 8, 0));
         AssignProp("", false, dynSubprocessoId_Internalname, "Values", dynSubprocessoId.ToJavascriptSource(), true);
      }

      public void Valid_Subprocessoid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001361 */
         pr_default.execute(59, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(59) == 101) )
         {
            if ( ! ( (0==A20SubprocessoId) ) )
            {
               GX_msglist.addItem("Não existe 'SubProcesso.'.", "ForeignKeyNotFound", 1, "SUBPROCESSOID");
               AnyError = 1;
               GX_FocusControl = dynSubprocessoId_Internalname;
            }
         }
         pr_default.close(59);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Personaid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001362 */
         pr_default.execute(60, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(60) == 101) )
         {
            if ( ! ( (0==A13PersonaId) ) )
            {
               GX_msglist.addItem("Não existe 'Persona'.", "ForeignKeyNotFound", 1, "PERSONAID");
               AnyError = 1;
               GX_FocusControl = dynPersonaId_Internalname;
            }
         }
         pr_default.close(60);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Encarregadoid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001363 */
         pr_default.execute(61, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(61) == 101) )
         {
            if ( ! ( (0==A7EncarregadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Encarregado'.", "ForeignKeyNotFound", 1, "ENCARREGADOID");
               AnyError = 1;
               GX_FocusControl = dynEncarregadoId_Internalname;
            }
         }
         pr_default.close(61);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Categoriaid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001364 */
         pr_default.execute(62, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(62) == 101) )
         {
            if ( ! ( (0==A27CategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = dynCategoriaId_Internalname;
            }
         }
         pr_default.close(62);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipodadoid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001365 */
         pr_default.execute(63, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(63) == 101) )
         {
            if ( ! ( (0==A30TipoDadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Dado'.", "ForeignKeyNotFound", 1, "TIPODADOID");
               AnyError = 1;
               GX_FocusControl = dynTipoDadoId_Internalname;
            }
         }
         pr_default.close(63);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ferramentacoletaid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001366 */
         pr_default.execute(64, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(64) == 101) )
         {
            if ( ! ( (0==A33FerramentaColetaId) ) )
            {
               GX_msglist.addItem("Não existe 'Ferramenta Coleta'.", "ForeignKeyNotFound", 1, "FERRAMENTACOLETAID");
               AnyError = 1;
               GX_FocusControl = dynFerramentaColetaId_Internalname;
            }
         }
         pr_default.close(64);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Abrangenciageograficaid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001367 */
         pr_default.execute(65, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(65) == 101) )
         {
            if ( ! ( (0==A36AbrangenciaGeograficaId) ) )
            {
               GX_msglist.addItem("Não existe 'Abrangencia Geografica'.", "ForeignKeyNotFound", 1, "ABRANGENCIAGEOGRAFICAID");
               AnyError = 1;
               GX_FocusControl = dynAbrangenciaGeograficaId_Internalname;
            }
         }
         pr_default.close(65);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Frequenciatratamentoid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001368 */
         pr_default.execute(66, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(66) == 101) )
         {
            if ( ! ( (0==A39FrequenciaTratamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'Frequencia Tratamento'.", "ForeignKeyNotFound", 1, "FREQUENCIATRATAMENTOID");
               AnyError = 1;
               GX_FocusControl = dynFrequenciaTratamentoId_Internalname;
            }
         }
         pr_default.close(66);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipodescarteid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001369 */
         pr_default.execute(67, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(67) == 101) )
         {
            if ( ! ( (0==A45TipoDescarteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Descarte'.", "ForeignKeyNotFound", 1, "TIPODESCARTEID");
               AnyError = 1;
               GX_FocusControl = dynTipoDescarteId_Internalname;
            }
         }
         pr_default.close(67);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Temporetencaoid( )
      {
         n106DocumentoProcessoId = false;
         A106DocumentoProcessoId = (int)(NumberUtil.Val( dynDocumentoProcessoId.CurrentValue, "."));
         n106DocumentoProcessoId = false;
         n20SubprocessoId = false;
         A20SubprocessoId = (int)(NumberUtil.Val( dynSubprocessoId.CurrentValue, "."));
         n20SubprocessoId = false;
         n13PersonaId = false;
         A13PersonaId = (int)(NumberUtil.Val( dynPersonaId.CurrentValue, "."));
         n13PersonaId = false;
         n7EncarregadoId = false;
         A7EncarregadoId = (int)(NumberUtil.Val( dynEncarregadoId.CurrentValue, "."));
         n7EncarregadoId = false;
         n27CategoriaId = false;
         A27CategoriaId = (int)(NumberUtil.Val( dynCategoriaId.CurrentValue, "."));
         n27CategoriaId = false;
         n30TipoDadoId = false;
         A30TipoDadoId = (int)(NumberUtil.Val( dynTipoDadoId.CurrentValue, "."));
         n30TipoDadoId = false;
         n33FerramentaColetaId = false;
         A33FerramentaColetaId = (int)(NumberUtil.Val( dynFerramentaColetaId.CurrentValue, "."));
         n33FerramentaColetaId = false;
         n36AbrangenciaGeograficaId = false;
         A36AbrangenciaGeograficaId = (int)(NumberUtil.Val( dynAbrangenciaGeograficaId.CurrentValue, "."));
         n36AbrangenciaGeograficaId = false;
         n39FrequenciaTratamentoId = false;
         A39FrequenciaTratamentoId = (int)(NumberUtil.Val( dynFrequenciaTratamentoId.CurrentValue, "."));
         n39FrequenciaTratamentoId = false;
         n45TipoDescarteId = false;
         A45TipoDescarteId = (int)(NumberUtil.Val( dynTipoDescarteId.CurrentValue, "."));
         n45TipoDescarteId = false;
         n48TempoRetencaoId = false;
         A48TempoRetencaoId = (int)(NumberUtil.Val( dynTempoRetencaoId.CurrentValue, "."));
         n48TempoRetencaoId = false;
         /* Using cursor T001370 */
         pr_default.execute(68, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(68) == 101) )
         {
            if ( ! ( (0==A48TempoRetencaoId) ) )
            {
               GX_msglist.addItem("Não existe 'TempoRetencao'.", "ForeignKeyNotFound", 1, "TEMPORETENCAOID");
               AnyError = 1;
               GX_FocusControl = dynTempoRetencaoId_Internalname;
            }
         }
         pr_default.close(68);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV56Aba',fld:'vABA',pic:'',hsh:true},{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV56Aba',fld:'vABA',pic:'',hsh:true},{av:'AV7DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9',hsh:true},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A105DocumentoOperador',fld:'DOCUMENTOOPERADOR',pic:''},{av:'A108DocumentoDataInclusao',fld:'DOCUMENTODATAINCLUSAO',pic:'99/99/99 99:99'},{av:'A141DocumentoUsuarioInclusao',fld:'DOCUMENTOUSUARIOINCLUSAO',pic:''},{av:'A143DocumentoIsOperador',fld:'DOCUMENTOISOPERADOR',pic:''},{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12132',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOPROCESSOID","{handler:'Valid_Documentoprocessoid',iparms:[{av:'A107DocumentoProcessoNome',fld:'DOCUMENTOPROCESSONOME',pic:''},{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOPROCESSOID",",oparms:[{av:'A107DocumentoProcessoNome',fld:'DOCUMENTOPROCESSONOME',pic:''},{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_SUBPROCESSOID","{handler:'Valid_Subprocessoid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_SUBPROCESSOID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_PERSONAID","{handler:'Valid_Personaid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_PERSONAID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_ENCARREGADOID","{handler:'Valid_Encarregadoid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_ENCARREGADOID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTONOME","{handler:'Valid_Documentonome',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTONOME",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOFINALIDADETRATAMENTO","{handler:'Valid_Documentofinalidadetratamento',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOFINALIDADETRATAMENTO",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_CATEGORIAID","{handler:'Valid_Categoriaid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_CATEGORIAID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_TIPODADOID","{handler:'Valid_Tipodadoid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_TIPODADOID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_FERRAMENTACOLETAID","{handler:'Valid_Ferramentacoletaid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_FERRAMENTACOLETAID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_ABRANGENCIAGEOGRAFICAID","{handler:'Valid_Abrangenciageograficaid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_ABRANGENCIAGEOGRAFICAID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_FREQUENCIATRATAMENTOID","{handler:'Valid_Frequenciatratamentoid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_FREQUENCIATRATAMENTOID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_TIPODESCARTEID","{handler:'Valid_Tipodescarteid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_TIPODESCARTEID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_TEMPORETENCAOID","{handler:'Valid_Temporetencaoid',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_TEMPORETENCAOID",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOBASELEGALNORM","{handler:'Valid_Documentobaselegalnorm',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOBASELEGALNORM",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOBASELEGALNORMINTEXT","{handler:'Valid_Documentobaselegalnormintext',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOBASELEGALNORMINTEXT",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOMEDIDASEGURANCADESC","{handler:'Valid_Documentomedidasegurancadesc',iparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOMEDIDASEGURANCADESC",",oparms:[{av:'dynDocumentoProcessoId'},{av:'A106DocumentoProcessoId',fld:'DOCUMENTOPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynSubprocessoId'},{av:'A20SubprocessoId',fld:'SUBPROCESSOID',pic:'ZZZZZZZ9'},{av:'dynPersonaId'},{av:'A13PersonaId',fld:'PERSONAID',pic:'ZZZZZZZ9'},{av:'dynEncarregadoId'},{av:'A7EncarregadoId',fld:'ENCARREGADOID',pic:'ZZZZZZZ9'},{av:'dynCategoriaId'},{av:'A27CategoriaId',fld:'CATEGORIAID',pic:'ZZZZZZZ9'},{av:'dynTipoDadoId'},{av:'A30TipoDadoId',fld:'TIPODADOID',pic:'ZZZZZZZ9'},{av:'dynFerramentaColetaId'},{av:'A33FerramentaColetaId',fld:'FERRAMENTACOLETAID',pic:'ZZZZZZZ9'},{av:'dynAbrangenciaGeograficaId'},{av:'A36AbrangenciaGeograficaId',fld:'ABRANGENCIAGEOGRAFICAID',pic:'ZZZZZZZ9'},{av:'dynFrequenciaTratamentoId'},{av:'A39FrequenciaTratamentoId',fld:'FREQUENCIATRATAMENTOID',pic:'ZZZZZZZ9'},{av:'dynTipoDescarteId'},{av:'A45TipoDescarteId',fld:'TIPODESCARTEID',pic:'ZZZZZZZ9'},{av:'dynTempoRetencaoId'},{av:'A48TempoRetencaoId',fld:'TEMPORETENCAOID',pic:'ZZZZZZZ9'},{av:'radDocumentoPrevColetaDados'},{av:'A78DocumentoPrevColetaDados',fld:'DOCUMENTOPREVCOLETADADOS',pic:''},{av:'A82DocumentoDadosGrupoVul',fld:'DOCUMENTODADOSGRUPOVUL',pic:''},{av:'A81DocumentoDadosCriancaAdolesc',fld:'DOCUMENTODADOSCRIANCAADOLESC',pic:''}]}");
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
         pr_default.close(59);
         pr_default.close(61);
         pr_default.close(60);
         pr_default.close(62);
         pr_default.close(63);
         pr_default.close(64);
         pr_default.close(65);
         pr_default.close(66);
         pr_default.close(67);
         pr_default.close(68);
         pr_default.close(58);
         pr_default.close(35);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV56Aba = "";
         Z109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         Z142DocumentoUsuarioAlteracao = "";
         Z76DocumentoNome = "";
         Z77DocumentoFinalidadeTratamento = "";
         Z79DocumentoBaseLegalNorm = "";
         Z80DocumentoBaseLegalNormIntExt = "";
         Z108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         Z141DocumentoUsuarioInclusao = "";
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
         TempTags = "";
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         AV54AreaResponsavelNome = "";
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         A76DocumentoNome = "";
         A77DocumentoFinalidadeTratamento = "";
         A79DocumentoBaseLegalNorm = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A83DocumentoMedidaSegurancaDesc = "";
         A84DocumentoFluxoTratDadosDesc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A142DocumentoUsuarioAlteracao = "";
         A141DocumentoUsuarioInclusao = "";
         A107DocumentoProcessoNome = "";
         AV61Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode46 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV24TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z83DocumentoMedidaSegurancaDesc = "";
         Z84DocumentoFluxoTratDadosDesc = "";
         Z107DocumentoProcessoNome = "";
         T001315_A107DocumentoProcessoNome = new string[] {""} ;
         T001317_A75DocumentoId = new int[1] ;
         T001317_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T001317_n109DocumentoDataAlteracao = new bool[] {false} ;
         T001317_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         T001317_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         T001317_A76DocumentoNome = new string[] {""} ;
         T001317_n76DocumentoNome = new bool[] {false} ;
         T001317_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         T001317_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         T001317_A79DocumentoBaseLegalNorm = new string[] {""} ;
         T001317_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         T001317_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         T001317_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         T001317_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         T001317_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         T001317_A78DocumentoPrevColetaDados = new bool[] {false} ;
         T001317_n78DocumentoPrevColetaDados = new bool[] {false} ;
         T001317_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         T001317_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         T001317_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         T001317_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         T001317_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         T001317_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         T001317_A85DocumentoAtivo = new bool[] {false} ;
         T001317_n85DocumentoAtivo = new bool[] {false} ;
         T001317_A105DocumentoOperador = new bool[] {false} ;
         T001317_n105DocumentoOperador = new bool[] {false} ;
         T001317_A107DocumentoProcessoNome = new string[] {""} ;
         T001317_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T001317_n108DocumentoDataInclusao = new bool[] {false} ;
         T001317_A141DocumentoUsuarioInclusao = new string[] {""} ;
         T001317_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         T001317_A143DocumentoIsOperador = new bool[] {false} ;
         T001317_n143DocumentoIsOperador = new bool[] {false} ;
         T001317_A20SubprocessoId = new int[1] ;
         T001317_n20SubprocessoId = new bool[] {false} ;
         T001317_A7EncarregadoId = new int[1] ;
         T001317_n7EncarregadoId = new bool[] {false} ;
         T001317_A13PersonaId = new int[1] ;
         T001317_n13PersonaId = new bool[] {false} ;
         T001317_A27CategoriaId = new int[1] ;
         T001317_n27CategoriaId = new bool[] {false} ;
         T001317_A30TipoDadoId = new int[1] ;
         T001317_n30TipoDadoId = new bool[] {false} ;
         T001317_A33FerramentaColetaId = new int[1] ;
         T001317_n33FerramentaColetaId = new bool[] {false} ;
         T001317_A36AbrangenciaGeograficaId = new int[1] ;
         T001317_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T001317_A39FrequenciaTratamentoId = new int[1] ;
         T001317_n39FrequenciaTratamentoId = new bool[] {false} ;
         T001317_A45TipoDescarteId = new int[1] ;
         T001317_n45TipoDescarteId = new bool[] {false} ;
         T001317_A48TempoRetencaoId = new int[1] ;
         T001317_n48TempoRetencaoId = new bool[] {false} ;
         T001317_A24AreaResponsavelId = new int[1] ;
         T001317_n24AreaResponsavelId = new bool[] {false} ;
         T001317_A106DocumentoProcessoId = new int[1] ;
         T001317_n106DocumentoProcessoId = new bool[] {false} ;
         T001317_A110DocumentoControladorId = new int[1] ;
         T001317_n110DocumentoControladorId = new bool[] {false} ;
         T00134_A20SubprocessoId = new int[1] ;
         T00134_n20SubprocessoId = new bool[] {false} ;
         T00135_A7EncarregadoId = new int[1] ;
         T00135_n7EncarregadoId = new bool[] {false} ;
         T00136_A13PersonaId = new int[1] ;
         T00136_n13PersonaId = new bool[] {false} ;
         T00137_A27CategoriaId = new int[1] ;
         T00137_n27CategoriaId = new bool[] {false} ;
         T00138_A30TipoDadoId = new int[1] ;
         T00138_n30TipoDadoId = new bool[] {false} ;
         T00139_A33FerramentaColetaId = new int[1] ;
         T00139_n33FerramentaColetaId = new bool[] {false} ;
         T001310_A36AbrangenciaGeograficaId = new int[1] ;
         T001310_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T001311_A39FrequenciaTratamentoId = new int[1] ;
         T001311_n39FrequenciaTratamentoId = new bool[] {false} ;
         T001312_A45TipoDescarteId = new int[1] ;
         T001312_n45TipoDescarteId = new bool[] {false} ;
         T001313_A48TempoRetencaoId = new int[1] ;
         T001313_n48TempoRetencaoId = new bool[] {false} ;
         T001314_A24AreaResponsavelId = new int[1] ;
         T001314_n24AreaResponsavelId = new bool[] {false} ;
         T001316_A110DocumentoControladorId = new int[1] ;
         T001316_n110DocumentoControladorId = new bool[] {false} ;
         T001318_A20SubprocessoId = new int[1] ;
         T001318_n20SubprocessoId = new bool[] {false} ;
         T001319_A7EncarregadoId = new int[1] ;
         T001319_n7EncarregadoId = new bool[] {false} ;
         T001320_A13PersonaId = new int[1] ;
         T001320_n13PersonaId = new bool[] {false} ;
         T001321_A27CategoriaId = new int[1] ;
         T001321_n27CategoriaId = new bool[] {false} ;
         T001322_A30TipoDadoId = new int[1] ;
         T001322_n30TipoDadoId = new bool[] {false} ;
         T001323_A33FerramentaColetaId = new int[1] ;
         T001323_n33FerramentaColetaId = new bool[] {false} ;
         T001324_A36AbrangenciaGeograficaId = new int[1] ;
         T001324_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T001325_A39FrequenciaTratamentoId = new int[1] ;
         T001325_n39FrequenciaTratamentoId = new bool[] {false} ;
         T001326_A45TipoDescarteId = new int[1] ;
         T001326_n45TipoDescarteId = new bool[] {false} ;
         T001327_A48TempoRetencaoId = new int[1] ;
         T001327_n48TempoRetencaoId = new bool[] {false} ;
         T001328_A107DocumentoProcessoNome = new string[] {""} ;
         T001329_A24AreaResponsavelId = new int[1] ;
         T001329_n24AreaResponsavelId = new bool[] {false} ;
         T001330_A110DocumentoControladorId = new int[1] ;
         T001330_n110DocumentoControladorId = new bool[] {false} ;
         T001331_A75DocumentoId = new int[1] ;
         T00133_A75DocumentoId = new int[1] ;
         T00133_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T00133_n109DocumentoDataAlteracao = new bool[] {false} ;
         T00133_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         T00133_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         T00133_A76DocumentoNome = new string[] {""} ;
         T00133_n76DocumentoNome = new bool[] {false} ;
         T00133_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         T00133_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         T00133_A79DocumentoBaseLegalNorm = new string[] {""} ;
         T00133_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         T00133_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         T00133_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         T00133_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         T00133_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         T00133_A78DocumentoPrevColetaDados = new bool[] {false} ;
         T00133_n78DocumentoPrevColetaDados = new bool[] {false} ;
         T00133_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         T00133_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         T00133_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         T00133_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         T00133_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         T00133_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         T00133_A85DocumentoAtivo = new bool[] {false} ;
         T00133_n85DocumentoAtivo = new bool[] {false} ;
         T00133_A105DocumentoOperador = new bool[] {false} ;
         T00133_n105DocumentoOperador = new bool[] {false} ;
         T00133_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00133_n108DocumentoDataInclusao = new bool[] {false} ;
         T00133_A141DocumentoUsuarioInclusao = new string[] {""} ;
         T00133_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         T00133_A143DocumentoIsOperador = new bool[] {false} ;
         T00133_n143DocumentoIsOperador = new bool[] {false} ;
         T00133_A20SubprocessoId = new int[1] ;
         T00133_n20SubprocessoId = new bool[] {false} ;
         T00133_A7EncarregadoId = new int[1] ;
         T00133_n7EncarregadoId = new bool[] {false} ;
         T00133_A13PersonaId = new int[1] ;
         T00133_n13PersonaId = new bool[] {false} ;
         T00133_A27CategoriaId = new int[1] ;
         T00133_n27CategoriaId = new bool[] {false} ;
         T00133_A30TipoDadoId = new int[1] ;
         T00133_n30TipoDadoId = new bool[] {false} ;
         T00133_A33FerramentaColetaId = new int[1] ;
         T00133_n33FerramentaColetaId = new bool[] {false} ;
         T00133_A36AbrangenciaGeograficaId = new int[1] ;
         T00133_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T00133_A39FrequenciaTratamentoId = new int[1] ;
         T00133_n39FrequenciaTratamentoId = new bool[] {false} ;
         T00133_A45TipoDescarteId = new int[1] ;
         T00133_n45TipoDescarteId = new bool[] {false} ;
         T00133_A48TempoRetencaoId = new int[1] ;
         T00133_n48TempoRetencaoId = new bool[] {false} ;
         T00133_A24AreaResponsavelId = new int[1] ;
         T00133_n24AreaResponsavelId = new bool[] {false} ;
         T00133_A106DocumentoProcessoId = new int[1] ;
         T00133_n106DocumentoProcessoId = new bool[] {false} ;
         T00133_A110DocumentoControladorId = new int[1] ;
         T00133_n110DocumentoControladorId = new bool[] {false} ;
         T001332_A75DocumentoId = new int[1] ;
         T001333_A75DocumentoId = new int[1] ;
         T00132_A75DocumentoId = new int[1] ;
         T00132_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         T00132_n109DocumentoDataAlteracao = new bool[] {false} ;
         T00132_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         T00132_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         T00132_A76DocumentoNome = new string[] {""} ;
         T00132_n76DocumentoNome = new bool[] {false} ;
         T00132_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         T00132_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         T00132_A79DocumentoBaseLegalNorm = new string[] {""} ;
         T00132_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         T00132_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         T00132_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         T00132_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         T00132_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         T00132_A78DocumentoPrevColetaDados = new bool[] {false} ;
         T00132_n78DocumentoPrevColetaDados = new bool[] {false} ;
         T00132_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         T00132_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         T00132_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         T00132_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         T00132_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         T00132_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         T00132_A85DocumentoAtivo = new bool[] {false} ;
         T00132_n85DocumentoAtivo = new bool[] {false} ;
         T00132_A105DocumentoOperador = new bool[] {false} ;
         T00132_n105DocumentoOperador = new bool[] {false} ;
         T00132_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00132_n108DocumentoDataInclusao = new bool[] {false} ;
         T00132_A141DocumentoUsuarioInclusao = new string[] {""} ;
         T00132_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         T00132_A143DocumentoIsOperador = new bool[] {false} ;
         T00132_n143DocumentoIsOperador = new bool[] {false} ;
         T00132_A20SubprocessoId = new int[1] ;
         T00132_n20SubprocessoId = new bool[] {false} ;
         T00132_A7EncarregadoId = new int[1] ;
         T00132_n7EncarregadoId = new bool[] {false} ;
         T00132_A13PersonaId = new int[1] ;
         T00132_n13PersonaId = new bool[] {false} ;
         T00132_A27CategoriaId = new int[1] ;
         T00132_n27CategoriaId = new bool[] {false} ;
         T00132_A30TipoDadoId = new int[1] ;
         T00132_n30TipoDadoId = new bool[] {false} ;
         T00132_A33FerramentaColetaId = new int[1] ;
         T00132_n33FerramentaColetaId = new bool[] {false} ;
         T00132_A36AbrangenciaGeograficaId = new int[1] ;
         T00132_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T00132_A39FrequenciaTratamentoId = new int[1] ;
         T00132_n39FrequenciaTratamentoId = new bool[] {false} ;
         T00132_A45TipoDescarteId = new int[1] ;
         T00132_n45TipoDescarteId = new bool[] {false} ;
         T00132_A48TempoRetencaoId = new int[1] ;
         T00132_n48TempoRetencaoId = new bool[] {false} ;
         T00132_A24AreaResponsavelId = new int[1] ;
         T00132_n24AreaResponsavelId = new bool[] {false} ;
         T00132_A106DocumentoProcessoId = new int[1] ;
         T00132_n106DocumentoProcessoId = new bool[] {false} ;
         T00132_A110DocumentoControladorId = new int[1] ;
         T00132_n110DocumentoControladorId = new bool[] {false} ;
         T001334_A75DocumentoId = new int[1] ;
         T001337_A107DocumentoProcessoNome = new string[] {""} ;
         T001338_A144DocImagemId = new int[1] ;
         T001339_A120RevisaoLogId = new int[1] ;
         T001340_A93DocAnexoId = new int[1] ;
         T001341_A86DocOperadorId = new int[1] ;
         T001342_A98DocDicionarioId = new int[1] ;
         T001343_A51MedidaSegurancaId = new int[1] ;
         T001343_A75DocumentoId = new int[1] ;
         T001344_A63FonteRetencaoId = new int[1] ;
         T001344_A75DocumentoId = new int[1] ;
         T001345_A60SetorInternoId = new int[1] ;
         T001345_A75DocumentoId = new int[1] ;
         T001346_A57CompartInternoId = new int[1] ;
         T001346_A75DocumentoId = new int[1] ;
         T001347_A54EnvolvidosColetaId = new int[1] ;
         T001347_A75DocumentoId = new int[1] ;
         T001348_A75DocumentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         i141DocumentoUsuarioInclusao = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001349_A106DocumentoProcessoId = new int[1] ;
         T001349_n106DocumentoProcessoId = new bool[] {false} ;
         T001349_A107DocumentoProcessoNome = new string[] {""} ;
         T001349_A19ProcessoAtivo = new bool[] {false} ;
         T001349_n19ProcessoAtivo = new bool[] {false} ;
         T001350_A20SubprocessoId = new int[1] ;
         T001350_n20SubprocessoId = new bool[] {false} ;
         T001350_A21SubprocessoNome = new string[] {""} ;
         T001350_A23SubprocessoAtivo = new bool[] {false} ;
         T001350_A16ProcessoId = new int[1] ;
         T001350_n16ProcessoId = new bool[] {false} ;
         T001351_A13PersonaId = new int[1] ;
         T001351_n13PersonaId = new bool[] {false} ;
         T001351_A14PersonaNome = new string[] {""} ;
         T001351_A15PersonaAtivo = new bool[] {false} ;
         T001352_A7EncarregadoId = new int[1] ;
         T001352_n7EncarregadoId = new bool[] {false} ;
         T001352_A8EncarregadoNome = new string[] {""} ;
         T001352_A9EncarregadoAtivo = new bool[] {false} ;
         T001353_A10ControladorId = new int[1] ;
         T001353_A11ControladorNome = new string[] {""} ;
         T001353_A12ControladorAtivo = new bool[] {false} ;
         T001354_A30TipoDadoId = new int[1] ;
         T001354_n30TipoDadoId = new bool[] {false} ;
         T001354_A31TipoDadoNome = new string[] {""} ;
         T001354_A32TipoDadoAtivo = new bool[] {false} ;
         T001355_A33FerramentaColetaId = new int[1] ;
         T001355_n33FerramentaColetaId = new bool[] {false} ;
         T001355_A34FerramentaColetaNome = new string[] {""} ;
         T001355_A35FerramentaColetaAtivo = new bool[] {false} ;
         T001356_A36AbrangenciaGeograficaId = new int[1] ;
         T001356_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T001356_A37AbrangenciaGeograficaNome = new string[] {""} ;
         T001356_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         T001357_A39FrequenciaTratamentoId = new int[1] ;
         T001357_n39FrequenciaTratamentoId = new bool[] {false} ;
         T001357_A40FrequenciaTratamentoNome = new string[] {""} ;
         T001357_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         T001358_A45TipoDescarteId = new int[1] ;
         T001358_n45TipoDescarteId = new bool[] {false} ;
         T001358_A46TipoDescarteNome = new string[] {""} ;
         T001358_A47TipoDescarteAtivo = new bool[] {false} ;
         T001359_A48TempoRetencaoId = new int[1] ;
         T001359_n48TempoRetencaoId = new bool[] {false} ;
         T001359_A49TempoRetencaoNome = new string[] {""} ;
         T001359_A50TempoRetencaoAtivo = new bool[] {false} ;
         T001360_A107DocumentoProcessoNome = new string[] {""} ;
         T001361_A20SubprocessoId = new int[1] ;
         T001361_n20SubprocessoId = new bool[] {false} ;
         T001362_A13PersonaId = new int[1] ;
         T001362_n13PersonaId = new bool[] {false} ;
         T001363_A7EncarregadoId = new int[1] ;
         T001363_n7EncarregadoId = new bool[] {false} ;
         T001364_A27CategoriaId = new int[1] ;
         T001364_n27CategoriaId = new bool[] {false} ;
         T001365_A30TipoDadoId = new int[1] ;
         T001365_n30TipoDadoId = new bool[] {false} ;
         T001366_A33FerramentaColetaId = new int[1] ;
         T001366_n33FerramentaColetaId = new bool[] {false} ;
         T001367_A36AbrangenciaGeograficaId = new int[1] ;
         T001367_n36AbrangenciaGeograficaId = new bool[] {false} ;
         T001368_A39FrequenciaTratamentoId = new int[1] ;
         T001368_n39FrequenciaTratamentoId = new bool[] {false} ;
         T001369_A45TipoDescarteId = new int[1] ;
         T001369_n45TipoDescarteId = new bool[] {false} ;
         T001370_A48TempoRetencaoId = new int[1] ;
         T001370_n48TempoRetencaoId = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.documento__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documento__default(),
            new Object[][] {
                new Object[] {
               T00132_A75DocumentoId, T00132_A109DocumentoDataAlteracao, T00132_n109DocumentoDataAlteracao, T00132_A142DocumentoUsuarioAlteracao, T00132_n142DocumentoUsuarioAlteracao, T00132_A76DocumentoNome, T00132_n76DocumentoNome, T00132_A77DocumentoFinalidadeTratamento, T00132_n77DocumentoFinalidadeTratamento, T00132_A79DocumentoBaseLegalNorm,
               T00132_n79DocumentoBaseLegalNorm, T00132_A80DocumentoBaseLegalNormIntExt, T00132_n80DocumentoBaseLegalNormIntExt, T00132_A83DocumentoMedidaSegurancaDesc, T00132_n83DocumentoMedidaSegurancaDesc, T00132_A78DocumentoPrevColetaDados, T00132_n78DocumentoPrevColetaDados, T00132_A81DocumentoDadosCriancaAdolesc, T00132_n81DocumentoDadosCriancaAdolesc, T00132_A82DocumentoDadosGrupoVul,
               T00132_n82DocumentoDadosGrupoVul, T00132_A84DocumentoFluxoTratDadosDesc, T00132_n84DocumentoFluxoTratDadosDesc, T00132_A85DocumentoAtivo, T00132_n85DocumentoAtivo, T00132_A105DocumentoOperador, T00132_n105DocumentoOperador, T00132_A108DocumentoDataInclusao, T00132_n108DocumentoDataInclusao, T00132_A141DocumentoUsuarioInclusao,
               T00132_n141DocumentoUsuarioInclusao, T00132_A143DocumentoIsOperador, T00132_n143DocumentoIsOperador, T00132_A20SubprocessoId, T00132_n20SubprocessoId, T00132_A7EncarregadoId, T00132_n7EncarregadoId, T00132_A13PersonaId, T00132_n13PersonaId, T00132_A27CategoriaId,
               T00132_n27CategoriaId, T00132_A30TipoDadoId, T00132_n30TipoDadoId, T00132_A33FerramentaColetaId, T00132_n33FerramentaColetaId, T00132_A36AbrangenciaGeograficaId, T00132_n36AbrangenciaGeograficaId, T00132_A39FrequenciaTratamentoId, T00132_n39FrequenciaTratamentoId, T00132_A45TipoDescarteId,
               T00132_n45TipoDescarteId, T00132_A48TempoRetencaoId, T00132_n48TempoRetencaoId, T00132_A24AreaResponsavelId, T00132_n24AreaResponsavelId, T00132_A106DocumentoProcessoId, T00132_n106DocumentoProcessoId, T00132_A110DocumentoControladorId, T00132_n110DocumentoControladorId
               }
               , new Object[] {
               T00133_A75DocumentoId, T00133_A109DocumentoDataAlteracao, T00133_n109DocumentoDataAlteracao, T00133_A142DocumentoUsuarioAlteracao, T00133_n142DocumentoUsuarioAlteracao, T00133_A76DocumentoNome, T00133_n76DocumentoNome, T00133_A77DocumentoFinalidadeTratamento, T00133_n77DocumentoFinalidadeTratamento, T00133_A79DocumentoBaseLegalNorm,
               T00133_n79DocumentoBaseLegalNorm, T00133_A80DocumentoBaseLegalNormIntExt, T00133_n80DocumentoBaseLegalNormIntExt, T00133_A83DocumentoMedidaSegurancaDesc, T00133_n83DocumentoMedidaSegurancaDesc, T00133_A78DocumentoPrevColetaDados, T00133_n78DocumentoPrevColetaDados, T00133_A81DocumentoDadosCriancaAdolesc, T00133_n81DocumentoDadosCriancaAdolesc, T00133_A82DocumentoDadosGrupoVul,
               T00133_n82DocumentoDadosGrupoVul, T00133_A84DocumentoFluxoTratDadosDesc, T00133_n84DocumentoFluxoTratDadosDesc, T00133_A85DocumentoAtivo, T00133_n85DocumentoAtivo, T00133_A105DocumentoOperador, T00133_n105DocumentoOperador, T00133_A108DocumentoDataInclusao, T00133_n108DocumentoDataInclusao, T00133_A141DocumentoUsuarioInclusao,
               T00133_n141DocumentoUsuarioInclusao, T00133_A143DocumentoIsOperador, T00133_n143DocumentoIsOperador, T00133_A20SubprocessoId, T00133_n20SubprocessoId, T00133_A7EncarregadoId, T00133_n7EncarregadoId, T00133_A13PersonaId, T00133_n13PersonaId, T00133_A27CategoriaId,
               T00133_n27CategoriaId, T00133_A30TipoDadoId, T00133_n30TipoDadoId, T00133_A33FerramentaColetaId, T00133_n33FerramentaColetaId, T00133_A36AbrangenciaGeograficaId, T00133_n36AbrangenciaGeograficaId, T00133_A39FrequenciaTratamentoId, T00133_n39FrequenciaTratamentoId, T00133_A45TipoDescarteId,
               T00133_n45TipoDescarteId, T00133_A48TempoRetencaoId, T00133_n48TempoRetencaoId, T00133_A24AreaResponsavelId, T00133_n24AreaResponsavelId, T00133_A106DocumentoProcessoId, T00133_n106DocumentoProcessoId, T00133_A110DocumentoControladorId, T00133_n110DocumentoControladorId
               }
               , new Object[] {
               T00134_A20SubprocessoId
               }
               , new Object[] {
               T00135_A7EncarregadoId
               }
               , new Object[] {
               T00136_A13PersonaId
               }
               , new Object[] {
               T00137_A27CategoriaId
               }
               , new Object[] {
               T00138_A30TipoDadoId
               }
               , new Object[] {
               T00139_A33FerramentaColetaId
               }
               , new Object[] {
               T001310_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               T001311_A39FrequenciaTratamentoId
               }
               , new Object[] {
               T001312_A45TipoDescarteId
               }
               , new Object[] {
               T001313_A48TempoRetencaoId
               }
               , new Object[] {
               T001314_A24AreaResponsavelId
               }
               , new Object[] {
               T001315_A107DocumentoProcessoNome
               }
               , new Object[] {
               T001316_A110DocumentoControladorId
               }
               , new Object[] {
               T001317_A75DocumentoId, T001317_A109DocumentoDataAlteracao, T001317_n109DocumentoDataAlteracao, T001317_A142DocumentoUsuarioAlteracao, T001317_n142DocumentoUsuarioAlteracao, T001317_A76DocumentoNome, T001317_n76DocumentoNome, T001317_A77DocumentoFinalidadeTratamento, T001317_n77DocumentoFinalidadeTratamento, T001317_A79DocumentoBaseLegalNorm,
               T001317_n79DocumentoBaseLegalNorm, T001317_A80DocumentoBaseLegalNormIntExt, T001317_n80DocumentoBaseLegalNormIntExt, T001317_A83DocumentoMedidaSegurancaDesc, T001317_n83DocumentoMedidaSegurancaDesc, T001317_A78DocumentoPrevColetaDados, T001317_n78DocumentoPrevColetaDados, T001317_A81DocumentoDadosCriancaAdolesc, T001317_n81DocumentoDadosCriancaAdolesc, T001317_A82DocumentoDadosGrupoVul,
               T001317_n82DocumentoDadosGrupoVul, T001317_A84DocumentoFluxoTratDadosDesc, T001317_n84DocumentoFluxoTratDadosDesc, T001317_A85DocumentoAtivo, T001317_n85DocumentoAtivo, T001317_A105DocumentoOperador, T001317_n105DocumentoOperador, T001317_A107DocumentoProcessoNome, T001317_A108DocumentoDataInclusao, T001317_n108DocumentoDataInclusao,
               T001317_A141DocumentoUsuarioInclusao, T001317_n141DocumentoUsuarioInclusao, T001317_A143DocumentoIsOperador, T001317_n143DocumentoIsOperador, T001317_A20SubprocessoId, T001317_n20SubprocessoId, T001317_A7EncarregadoId, T001317_n7EncarregadoId, T001317_A13PersonaId, T001317_n13PersonaId,
               T001317_A27CategoriaId, T001317_n27CategoriaId, T001317_A30TipoDadoId, T001317_n30TipoDadoId, T001317_A33FerramentaColetaId, T001317_n33FerramentaColetaId, T001317_A36AbrangenciaGeograficaId, T001317_n36AbrangenciaGeograficaId, T001317_A39FrequenciaTratamentoId, T001317_n39FrequenciaTratamentoId,
               T001317_A45TipoDescarteId, T001317_n45TipoDescarteId, T001317_A48TempoRetencaoId, T001317_n48TempoRetencaoId, T001317_A24AreaResponsavelId, T001317_n24AreaResponsavelId, T001317_A106DocumentoProcessoId, T001317_n106DocumentoProcessoId, T001317_A110DocumentoControladorId, T001317_n110DocumentoControladorId
               }
               , new Object[] {
               T001318_A20SubprocessoId
               }
               , new Object[] {
               T001319_A7EncarregadoId
               }
               , new Object[] {
               T001320_A13PersonaId
               }
               , new Object[] {
               T001321_A27CategoriaId
               }
               , new Object[] {
               T001322_A30TipoDadoId
               }
               , new Object[] {
               T001323_A33FerramentaColetaId
               }
               , new Object[] {
               T001324_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               T001325_A39FrequenciaTratamentoId
               }
               , new Object[] {
               T001326_A45TipoDescarteId
               }
               , new Object[] {
               T001327_A48TempoRetencaoId
               }
               , new Object[] {
               T001328_A107DocumentoProcessoNome
               }
               , new Object[] {
               T001329_A24AreaResponsavelId
               }
               , new Object[] {
               T001330_A110DocumentoControladorId
               }
               , new Object[] {
               T001331_A75DocumentoId
               }
               , new Object[] {
               T001332_A75DocumentoId
               }
               , new Object[] {
               T001333_A75DocumentoId
               }
               , new Object[] {
               T001334_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001337_A107DocumentoProcessoNome
               }
               , new Object[] {
               T001338_A144DocImagemId
               }
               , new Object[] {
               T001339_A120RevisaoLogId
               }
               , new Object[] {
               T001340_A93DocAnexoId
               }
               , new Object[] {
               T001341_A86DocOperadorId
               }
               , new Object[] {
               T001342_A98DocDicionarioId
               }
               , new Object[] {
               T001343_A51MedidaSegurancaId, T001343_A75DocumentoId
               }
               , new Object[] {
               T001344_A63FonteRetencaoId, T001344_A75DocumentoId
               }
               , new Object[] {
               T001345_A60SetorInternoId, T001345_A75DocumentoId
               }
               , new Object[] {
               T001346_A57CompartInternoId, T001346_A75DocumentoId
               }
               , new Object[] {
               T001347_A54EnvolvidosColetaId, T001347_A75DocumentoId
               }
               , new Object[] {
               T001348_A75DocumentoId
               }
               , new Object[] {
               T001349_A106DocumentoProcessoId, T001349_A107DocumentoProcessoNome, T001349_A19ProcessoAtivo, T001349_n19ProcessoAtivo
               }
               , new Object[] {
               T001350_A20SubprocessoId, T001350_A21SubprocessoNome, T001350_A23SubprocessoAtivo, T001350_A16ProcessoId, T001350_n16ProcessoId
               }
               , new Object[] {
               T001351_A13PersonaId, T001351_A14PersonaNome, T001351_A15PersonaAtivo
               }
               , new Object[] {
               T001352_A7EncarregadoId, T001352_A8EncarregadoNome, T001352_A9EncarregadoAtivo
               }
               , new Object[] {
               T001353_A10ControladorId, T001353_A11ControladorNome, T001353_A12ControladorAtivo
               }
               , new Object[] {
               T001354_A30TipoDadoId, T001354_A31TipoDadoNome, T001354_A32TipoDadoAtivo
               }
               , new Object[] {
               T001355_A33FerramentaColetaId, T001355_A34FerramentaColetaNome, T001355_A35FerramentaColetaAtivo
               }
               , new Object[] {
               T001356_A36AbrangenciaGeograficaId, T001356_A37AbrangenciaGeograficaNome, T001356_A38AbrangenciaGeograficaAtivo
               }
               , new Object[] {
               T001357_A39FrequenciaTratamentoId, T001357_A40FrequenciaTratamentoNome, T001357_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               T001358_A45TipoDescarteId, T001358_A46TipoDescarteNome, T001358_A47TipoDescarteAtivo
               }
               , new Object[] {
               T001359_A48TempoRetencaoId, T001359_A49TempoRetencaoNome, T001359_A50TempoRetencaoAtivo
               }
               , new Object[] {
               T001360_A107DocumentoProcessoNome
               }
               , new Object[] {
               T001361_A20SubprocessoId
               }
               , new Object[] {
               T001362_A13PersonaId
               }
               , new Object[] {
               T001363_A7EncarregadoId
               }
               , new Object[] {
               T001364_A27CategoriaId
               }
               , new Object[] {
               T001365_A30TipoDadoId
               }
               , new Object[] {
               T001366_A33FerramentaColetaId
               }
               , new Object[] {
               T001367_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               T001368_A39FrequenciaTratamentoId
               }
               , new Object[] {
               T001369_A45TipoDescarteId
               }
               , new Object[] {
               T001370_A48TempoRetencaoId
               }
            }
         );
         AV61Pgmname = "Documento";
         Z143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         A143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         i143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         Z141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         A141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         i141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         Z108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         A108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         i108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         Z85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         A85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         i85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound46 ;
      private short AV57count ;
      private short GX_JID ;
      private short nIsDirty_46 ;
      private short gxajaxcallmode ;
      private int wcpOAV7DocumentoId ;
      private int Z75DocumentoId ;
      private int Z20SubprocessoId ;
      private int Z7EncarregadoId ;
      private int Z13PersonaId ;
      private int Z27CategoriaId ;
      private int Z30TipoDadoId ;
      private int Z33FerramentaColetaId ;
      private int Z36AbrangenciaGeograficaId ;
      private int Z39FrequenciaTratamentoId ;
      private int Z45TipoDescarteId ;
      private int Z48TempoRetencaoId ;
      private int Z24AreaResponsavelId ;
      private int Z106DocumentoProcessoId ;
      private int Z110DocumentoControladorId ;
      private int N20SubprocessoId ;
      private int N7EncarregadoId ;
      private int N13PersonaId ;
      private int N27CategoriaId ;
      private int N30TipoDadoId ;
      private int N33FerramentaColetaId ;
      private int N36AbrangenciaGeograficaId ;
      private int N39FrequenciaTratamentoId ;
      private int N45TipoDescarteId ;
      private int N48TempoRetencaoId ;
      private int N106DocumentoProcessoId ;
      private int N110DocumentoControladorId ;
      private int N24AreaResponsavelId ;
      private int A106DocumentoProcessoId ;
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
      private int A24AreaResponsavelId ;
      private int A110DocumentoControladorId ;
      private int AV7DocumentoId ;
      private int trnEnded ;
      private int A75DocumentoId ;
      private int edtDocumentoId_Enabled ;
      private int edtDocumentoDataInclusao_Enabled ;
      private int edtavArearesponsavelnome_Enabled ;
      private int edtDocumentoDataAlteracao_Enabled ;
      private int edtDocumentoNome_Enabled ;
      private int edtDocumentoFinalidadeTratamento_Enabled ;
      private int edtDocumentoBaseLegalNorm_Enabled ;
      private int edtDocumentoBaseLegalNormIntExt_Enabled ;
      private int edtDocumentoMedidaSegurancaDesc_Enabled ;
      private int edtDocumentoFluxoTratDadosDesc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV55AreaResponsavelId ;
      private int edtavArearesponsavelid_Enabled ;
      private int edtavArearesponsavelid_Visible ;
      private int AV13Insert_SubprocessoId ;
      private int AV14Insert_EncarregadoId ;
      private int AV15Insert_PersonaId ;
      private int AV16Insert_CategoriaId ;
      private int AV17Insert_TipoDadoId ;
      private int AV18Insert_FerramentaColetaId ;
      private int AV19Insert_AbrangenciaGeograficaId ;
      private int AV20Insert_FrequenciaTratamentoId ;
      private int AV21Insert_TipoDescarteId ;
      private int AV22Insert_TempoRetencaoId ;
      private int AV53Insert_DocumentoProcessoId ;
      private int AV58Insert_DocumentoControladorId ;
      private int AV59Insert_AreaResponsavelId ;
      private int AV62GXV1 ;
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
      private string dynDocumentoProcessoId_Internalname ;
      private string dynSubprocessoId_Internalname ;
      private string dynPersonaId_Internalname ;
      private string dynEncarregadoId_Internalname ;
      private string cmbDocumentoAtivo_Internalname ;
      private string dynCategoriaId_Internalname ;
      private string dynTipoDadoId_Internalname ;
      private string dynFerramentaColetaId_Internalname ;
      private string dynAbrangenciaGeograficaId_Internalname ;
      private string dynFrequenciaTratamentoId_Internalname ;
      private string dynTipoDescarteId_Internalname ;
      private string dynTempoRetencaoId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTabledocumento_Internalname ;
      private string TempTags ;
      private string dynDocumentoProcessoId_Jsonclick ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoId_Jsonclick ;
      private string dynSubprocessoId_Jsonclick ;
      private string edtDocumentoDataInclusao_Internalname ;
      private string edtDocumentoDataInclusao_Jsonclick ;
      private string edtavArearesponsavelnome_Internalname ;
      private string edtavArearesponsavelnome_Jsonclick ;
      private string edtDocumentoDataAlteracao_Internalname ;
      private string edtDocumentoDataAlteracao_Jsonclick ;
      private string dynPersonaId_Jsonclick ;
      private string dynEncarregadoId_Jsonclick ;
      private string edtDocumentoNome_Internalname ;
      private string edtDocumentoNome_Jsonclick ;
      private string cmbDocumentoAtivo_Jsonclick ;
      private string divTabletratamento_Internalname ;
      private string edtDocumentoFinalidadeTratamento_Internalname ;
      private string edtDocumentoFinalidadeTratamento_Jsonclick ;
      private string dynCategoriaId_Jsonclick ;
      private string dynTipoDadoId_Jsonclick ;
      private string dynFerramentaColetaId_Jsonclick ;
      private string dynAbrangenciaGeograficaId_Jsonclick ;
      private string dynFrequenciaTratamentoId_Jsonclick ;
      private string dynTipoDescarteId_Jsonclick ;
      private string dynTempoRetencaoId_Jsonclick ;
      private string radDocumentoPrevColetaDados_Internalname ;
      private string radDocumentoPrevColetaDados_Jsonclick ;
      private string edtDocumentoBaseLegalNorm_Internalname ;
      private string edtDocumentoBaseLegalNorm_Jsonclick ;
      private string edtDocumentoBaseLegalNormIntExt_Internalname ;
      private string edtDocumentoBaseLegalNormIntExt_Jsonclick ;
      private string chkDocumentoDadosGrupoVul_Internalname ;
      private string chkDocumentoDadosCriancaAdolesc_Internalname ;
      private string edtDocumentoMedidaSegurancaDesc_Internalname ;
      private string edtDocumentoFluxoTratDadosDesc_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavArearesponsavelid_Internalname ;
      private string edtavArearesponsavelid_Jsonclick ;
      private string AV61Pgmname ;
      private string hsh ;
      private string sMode46 ;
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
      private DateTime Z109DocumentoDataAlteracao ;
      private DateTime Z108DocumentoDataInclusao ;
      private DateTime A108DocumentoDataInclusao ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime i108DocumentoDataInclusao ;
      private bool Z78DocumentoPrevColetaDados ;
      private bool Z81DocumentoDadosCriancaAdolesc ;
      private bool Z82DocumentoDadosGrupoVul ;
      private bool Z85DocumentoAtivo ;
      private bool Z105DocumentoOperador ;
      private bool Z143DocumentoIsOperador ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n106DocumentoProcessoId ;
      private bool n20SubprocessoId ;
      private bool n7EncarregadoId ;
      private bool n13PersonaId ;
      private bool n27CategoriaId ;
      private bool n30TipoDadoId ;
      private bool n33FerramentaColetaId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n45TipoDescarteId ;
      private bool n48TempoRetencaoId ;
      private bool n24AreaResponsavelId ;
      private bool n110DocumentoControladorId ;
      private bool wbErr ;
      private bool A85DocumentoAtivo ;
      private bool n85DocumentoAtivo ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool n109DocumentoDataAlteracao ;
      private bool n142DocumentoUsuarioAlteracao ;
      private bool n76DocumentoNome ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool n105DocumentoOperador ;
      private bool A105DocumentoOperador ;
      private bool n108DocumentoDataInclusao ;
      private bool n141DocumentoUsuarioInclusao ;
      private bool n143DocumentoIsOperador ;
      private bool A143DocumentoIsOperador ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i85DocumentoAtivo ;
      private bool i143DocumentoIsOperador ;
      private bool gxdyncontrolsrefreshing ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string Z83DocumentoMedidaSegurancaDesc ;
      private string Z84DocumentoFluxoTratDadosDesc ;
      private string wcpOAV56Aba ;
      private string Z142DocumentoUsuarioAlteracao ;
      private string Z76DocumentoNome ;
      private string Z77DocumentoFinalidadeTratamento ;
      private string Z79DocumentoBaseLegalNorm ;
      private string Z80DocumentoBaseLegalNormIntExt ;
      private string Z141DocumentoUsuarioInclusao ;
      private string AV56Aba ;
      private string AV54AreaResponsavelNome ;
      private string A76DocumentoNome ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A79DocumentoBaseLegalNorm ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A142DocumentoUsuarioAlteracao ;
      private string A141DocumentoUsuarioInclusao ;
      private string A107DocumentoProcessoNome ;
      private string Z107DocumentoProcessoNome ;
      private string i141DocumentoUsuarioInclusao ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
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
      private IDataStoreProvider pr_default ;
      private string[] T001315_A107DocumentoProcessoNome ;
      private int[] T001317_A75DocumentoId ;
      private DateTime[] T001317_A109DocumentoDataAlteracao ;
      private bool[] T001317_n109DocumentoDataAlteracao ;
      private string[] T001317_A142DocumentoUsuarioAlteracao ;
      private bool[] T001317_n142DocumentoUsuarioAlteracao ;
      private string[] T001317_A76DocumentoNome ;
      private bool[] T001317_n76DocumentoNome ;
      private string[] T001317_A77DocumentoFinalidadeTratamento ;
      private bool[] T001317_n77DocumentoFinalidadeTratamento ;
      private string[] T001317_A79DocumentoBaseLegalNorm ;
      private bool[] T001317_n79DocumentoBaseLegalNorm ;
      private string[] T001317_A80DocumentoBaseLegalNormIntExt ;
      private bool[] T001317_n80DocumentoBaseLegalNormIntExt ;
      private string[] T001317_A83DocumentoMedidaSegurancaDesc ;
      private bool[] T001317_n83DocumentoMedidaSegurancaDesc ;
      private bool[] T001317_A78DocumentoPrevColetaDados ;
      private bool[] T001317_n78DocumentoPrevColetaDados ;
      private bool[] T001317_A81DocumentoDadosCriancaAdolesc ;
      private bool[] T001317_n81DocumentoDadosCriancaAdolesc ;
      private bool[] T001317_A82DocumentoDadosGrupoVul ;
      private bool[] T001317_n82DocumentoDadosGrupoVul ;
      private string[] T001317_A84DocumentoFluxoTratDadosDesc ;
      private bool[] T001317_n84DocumentoFluxoTratDadosDesc ;
      private bool[] T001317_A85DocumentoAtivo ;
      private bool[] T001317_n85DocumentoAtivo ;
      private bool[] T001317_A105DocumentoOperador ;
      private bool[] T001317_n105DocumentoOperador ;
      private string[] T001317_A107DocumentoProcessoNome ;
      private DateTime[] T001317_A108DocumentoDataInclusao ;
      private bool[] T001317_n108DocumentoDataInclusao ;
      private string[] T001317_A141DocumentoUsuarioInclusao ;
      private bool[] T001317_n141DocumentoUsuarioInclusao ;
      private bool[] T001317_A143DocumentoIsOperador ;
      private bool[] T001317_n143DocumentoIsOperador ;
      private int[] T001317_A20SubprocessoId ;
      private bool[] T001317_n20SubprocessoId ;
      private int[] T001317_A7EncarregadoId ;
      private bool[] T001317_n7EncarregadoId ;
      private int[] T001317_A13PersonaId ;
      private bool[] T001317_n13PersonaId ;
      private int[] T001317_A27CategoriaId ;
      private bool[] T001317_n27CategoriaId ;
      private int[] T001317_A30TipoDadoId ;
      private bool[] T001317_n30TipoDadoId ;
      private int[] T001317_A33FerramentaColetaId ;
      private bool[] T001317_n33FerramentaColetaId ;
      private int[] T001317_A36AbrangenciaGeograficaId ;
      private bool[] T001317_n36AbrangenciaGeograficaId ;
      private int[] T001317_A39FrequenciaTratamentoId ;
      private bool[] T001317_n39FrequenciaTratamentoId ;
      private int[] T001317_A45TipoDescarteId ;
      private bool[] T001317_n45TipoDescarteId ;
      private int[] T001317_A48TempoRetencaoId ;
      private bool[] T001317_n48TempoRetencaoId ;
      private int[] T001317_A24AreaResponsavelId ;
      private bool[] T001317_n24AreaResponsavelId ;
      private int[] T001317_A106DocumentoProcessoId ;
      private bool[] T001317_n106DocumentoProcessoId ;
      private int[] T001317_A110DocumentoControladorId ;
      private bool[] T001317_n110DocumentoControladorId ;
      private int[] T00134_A20SubprocessoId ;
      private bool[] T00134_n20SubprocessoId ;
      private int[] T00135_A7EncarregadoId ;
      private bool[] T00135_n7EncarregadoId ;
      private int[] T00136_A13PersonaId ;
      private bool[] T00136_n13PersonaId ;
      private int[] T00137_A27CategoriaId ;
      private bool[] T00137_n27CategoriaId ;
      private int[] T00138_A30TipoDadoId ;
      private bool[] T00138_n30TipoDadoId ;
      private int[] T00139_A33FerramentaColetaId ;
      private bool[] T00139_n33FerramentaColetaId ;
      private int[] T001310_A36AbrangenciaGeograficaId ;
      private bool[] T001310_n36AbrangenciaGeograficaId ;
      private int[] T001311_A39FrequenciaTratamentoId ;
      private bool[] T001311_n39FrequenciaTratamentoId ;
      private int[] T001312_A45TipoDescarteId ;
      private bool[] T001312_n45TipoDescarteId ;
      private int[] T001313_A48TempoRetencaoId ;
      private bool[] T001313_n48TempoRetencaoId ;
      private int[] T001314_A24AreaResponsavelId ;
      private bool[] T001314_n24AreaResponsavelId ;
      private int[] T001316_A110DocumentoControladorId ;
      private bool[] T001316_n110DocumentoControladorId ;
      private int[] T001318_A20SubprocessoId ;
      private bool[] T001318_n20SubprocessoId ;
      private int[] T001319_A7EncarregadoId ;
      private bool[] T001319_n7EncarregadoId ;
      private int[] T001320_A13PersonaId ;
      private bool[] T001320_n13PersonaId ;
      private int[] T001321_A27CategoriaId ;
      private bool[] T001321_n27CategoriaId ;
      private int[] T001322_A30TipoDadoId ;
      private bool[] T001322_n30TipoDadoId ;
      private int[] T001323_A33FerramentaColetaId ;
      private bool[] T001323_n33FerramentaColetaId ;
      private int[] T001324_A36AbrangenciaGeograficaId ;
      private bool[] T001324_n36AbrangenciaGeograficaId ;
      private int[] T001325_A39FrequenciaTratamentoId ;
      private bool[] T001325_n39FrequenciaTratamentoId ;
      private int[] T001326_A45TipoDescarteId ;
      private bool[] T001326_n45TipoDescarteId ;
      private int[] T001327_A48TempoRetencaoId ;
      private bool[] T001327_n48TempoRetencaoId ;
      private string[] T001328_A107DocumentoProcessoNome ;
      private int[] T001329_A24AreaResponsavelId ;
      private bool[] T001329_n24AreaResponsavelId ;
      private int[] T001330_A110DocumentoControladorId ;
      private bool[] T001330_n110DocumentoControladorId ;
      private int[] T001331_A75DocumentoId ;
      private int[] T00133_A75DocumentoId ;
      private DateTime[] T00133_A109DocumentoDataAlteracao ;
      private bool[] T00133_n109DocumentoDataAlteracao ;
      private string[] T00133_A142DocumentoUsuarioAlteracao ;
      private bool[] T00133_n142DocumentoUsuarioAlteracao ;
      private string[] T00133_A76DocumentoNome ;
      private bool[] T00133_n76DocumentoNome ;
      private string[] T00133_A77DocumentoFinalidadeTratamento ;
      private bool[] T00133_n77DocumentoFinalidadeTratamento ;
      private string[] T00133_A79DocumentoBaseLegalNorm ;
      private bool[] T00133_n79DocumentoBaseLegalNorm ;
      private string[] T00133_A80DocumentoBaseLegalNormIntExt ;
      private bool[] T00133_n80DocumentoBaseLegalNormIntExt ;
      private string[] T00133_A83DocumentoMedidaSegurancaDesc ;
      private bool[] T00133_n83DocumentoMedidaSegurancaDesc ;
      private bool[] T00133_A78DocumentoPrevColetaDados ;
      private bool[] T00133_n78DocumentoPrevColetaDados ;
      private bool[] T00133_A81DocumentoDadosCriancaAdolesc ;
      private bool[] T00133_n81DocumentoDadosCriancaAdolesc ;
      private bool[] T00133_A82DocumentoDadosGrupoVul ;
      private bool[] T00133_n82DocumentoDadosGrupoVul ;
      private string[] T00133_A84DocumentoFluxoTratDadosDesc ;
      private bool[] T00133_n84DocumentoFluxoTratDadosDesc ;
      private bool[] T00133_A85DocumentoAtivo ;
      private bool[] T00133_n85DocumentoAtivo ;
      private bool[] T00133_A105DocumentoOperador ;
      private bool[] T00133_n105DocumentoOperador ;
      private DateTime[] T00133_A108DocumentoDataInclusao ;
      private bool[] T00133_n108DocumentoDataInclusao ;
      private string[] T00133_A141DocumentoUsuarioInclusao ;
      private bool[] T00133_n141DocumentoUsuarioInclusao ;
      private bool[] T00133_A143DocumentoIsOperador ;
      private bool[] T00133_n143DocumentoIsOperador ;
      private int[] T00133_A20SubprocessoId ;
      private bool[] T00133_n20SubprocessoId ;
      private int[] T00133_A7EncarregadoId ;
      private bool[] T00133_n7EncarregadoId ;
      private int[] T00133_A13PersonaId ;
      private bool[] T00133_n13PersonaId ;
      private int[] T00133_A27CategoriaId ;
      private bool[] T00133_n27CategoriaId ;
      private int[] T00133_A30TipoDadoId ;
      private bool[] T00133_n30TipoDadoId ;
      private int[] T00133_A33FerramentaColetaId ;
      private bool[] T00133_n33FerramentaColetaId ;
      private int[] T00133_A36AbrangenciaGeograficaId ;
      private bool[] T00133_n36AbrangenciaGeograficaId ;
      private int[] T00133_A39FrequenciaTratamentoId ;
      private bool[] T00133_n39FrequenciaTratamentoId ;
      private int[] T00133_A45TipoDescarteId ;
      private bool[] T00133_n45TipoDescarteId ;
      private int[] T00133_A48TempoRetencaoId ;
      private bool[] T00133_n48TempoRetencaoId ;
      private int[] T00133_A24AreaResponsavelId ;
      private bool[] T00133_n24AreaResponsavelId ;
      private int[] T00133_A106DocumentoProcessoId ;
      private bool[] T00133_n106DocumentoProcessoId ;
      private int[] T00133_A110DocumentoControladorId ;
      private bool[] T00133_n110DocumentoControladorId ;
      private int[] T001332_A75DocumentoId ;
      private int[] T001333_A75DocumentoId ;
      private int[] T00132_A75DocumentoId ;
      private DateTime[] T00132_A109DocumentoDataAlteracao ;
      private bool[] T00132_n109DocumentoDataAlteracao ;
      private string[] T00132_A142DocumentoUsuarioAlteracao ;
      private bool[] T00132_n142DocumentoUsuarioAlteracao ;
      private string[] T00132_A76DocumentoNome ;
      private bool[] T00132_n76DocumentoNome ;
      private string[] T00132_A77DocumentoFinalidadeTratamento ;
      private bool[] T00132_n77DocumentoFinalidadeTratamento ;
      private string[] T00132_A79DocumentoBaseLegalNorm ;
      private bool[] T00132_n79DocumentoBaseLegalNorm ;
      private string[] T00132_A80DocumentoBaseLegalNormIntExt ;
      private bool[] T00132_n80DocumentoBaseLegalNormIntExt ;
      private string[] T00132_A83DocumentoMedidaSegurancaDesc ;
      private bool[] T00132_n83DocumentoMedidaSegurancaDesc ;
      private bool[] T00132_A78DocumentoPrevColetaDados ;
      private bool[] T00132_n78DocumentoPrevColetaDados ;
      private bool[] T00132_A81DocumentoDadosCriancaAdolesc ;
      private bool[] T00132_n81DocumentoDadosCriancaAdolesc ;
      private bool[] T00132_A82DocumentoDadosGrupoVul ;
      private bool[] T00132_n82DocumentoDadosGrupoVul ;
      private string[] T00132_A84DocumentoFluxoTratDadosDesc ;
      private bool[] T00132_n84DocumentoFluxoTratDadosDesc ;
      private bool[] T00132_A85DocumentoAtivo ;
      private bool[] T00132_n85DocumentoAtivo ;
      private bool[] T00132_A105DocumentoOperador ;
      private bool[] T00132_n105DocumentoOperador ;
      private DateTime[] T00132_A108DocumentoDataInclusao ;
      private bool[] T00132_n108DocumentoDataInclusao ;
      private string[] T00132_A141DocumentoUsuarioInclusao ;
      private bool[] T00132_n141DocumentoUsuarioInclusao ;
      private bool[] T00132_A143DocumentoIsOperador ;
      private bool[] T00132_n143DocumentoIsOperador ;
      private int[] T00132_A20SubprocessoId ;
      private bool[] T00132_n20SubprocessoId ;
      private int[] T00132_A7EncarregadoId ;
      private bool[] T00132_n7EncarregadoId ;
      private int[] T00132_A13PersonaId ;
      private bool[] T00132_n13PersonaId ;
      private int[] T00132_A27CategoriaId ;
      private bool[] T00132_n27CategoriaId ;
      private int[] T00132_A30TipoDadoId ;
      private bool[] T00132_n30TipoDadoId ;
      private int[] T00132_A33FerramentaColetaId ;
      private bool[] T00132_n33FerramentaColetaId ;
      private int[] T00132_A36AbrangenciaGeograficaId ;
      private bool[] T00132_n36AbrangenciaGeograficaId ;
      private int[] T00132_A39FrequenciaTratamentoId ;
      private bool[] T00132_n39FrequenciaTratamentoId ;
      private int[] T00132_A45TipoDescarteId ;
      private bool[] T00132_n45TipoDescarteId ;
      private int[] T00132_A48TempoRetencaoId ;
      private bool[] T00132_n48TempoRetencaoId ;
      private int[] T00132_A24AreaResponsavelId ;
      private bool[] T00132_n24AreaResponsavelId ;
      private int[] T00132_A106DocumentoProcessoId ;
      private bool[] T00132_n106DocumentoProcessoId ;
      private int[] T00132_A110DocumentoControladorId ;
      private bool[] T00132_n110DocumentoControladorId ;
      private int[] T001334_A75DocumentoId ;
      private string[] T001337_A107DocumentoProcessoNome ;
      private int[] T001338_A144DocImagemId ;
      private int[] T001339_A120RevisaoLogId ;
      private int[] T001340_A93DocAnexoId ;
      private int[] T001341_A86DocOperadorId ;
      private int[] T001342_A98DocDicionarioId ;
      private int[] T001343_A51MedidaSegurancaId ;
      private int[] T001343_A75DocumentoId ;
      private int[] T001344_A63FonteRetencaoId ;
      private int[] T001344_A75DocumentoId ;
      private int[] T001345_A60SetorInternoId ;
      private int[] T001345_A75DocumentoId ;
      private int[] T001346_A57CompartInternoId ;
      private int[] T001346_A75DocumentoId ;
      private int[] T001347_A54EnvolvidosColetaId ;
      private int[] T001347_A75DocumentoId ;
      private int[] T001348_A75DocumentoId ;
      private int[] T001349_A106DocumentoProcessoId ;
      private bool[] T001349_n106DocumentoProcessoId ;
      private string[] T001349_A107DocumentoProcessoNome ;
      private bool[] T001349_A19ProcessoAtivo ;
      private bool[] T001349_n19ProcessoAtivo ;
      private int[] T001350_A20SubprocessoId ;
      private bool[] T001350_n20SubprocessoId ;
      private string[] T001350_A21SubprocessoNome ;
      private bool[] T001350_A23SubprocessoAtivo ;
      private int[] T001350_A16ProcessoId ;
      private bool[] T001350_n16ProcessoId ;
      private int[] T001351_A13PersonaId ;
      private bool[] T001351_n13PersonaId ;
      private string[] T001351_A14PersonaNome ;
      private bool[] T001351_A15PersonaAtivo ;
      private int[] T001352_A7EncarregadoId ;
      private bool[] T001352_n7EncarregadoId ;
      private string[] T001352_A8EncarregadoNome ;
      private bool[] T001352_A9EncarregadoAtivo ;
      private int[] T001353_A10ControladorId ;
      private string[] T001353_A11ControladorNome ;
      private bool[] T001353_A12ControladorAtivo ;
      private int[] T001354_A30TipoDadoId ;
      private bool[] T001354_n30TipoDadoId ;
      private string[] T001354_A31TipoDadoNome ;
      private bool[] T001354_A32TipoDadoAtivo ;
      private int[] T001355_A33FerramentaColetaId ;
      private bool[] T001355_n33FerramentaColetaId ;
      private string[] T001355_A34FerramentaColetaNome ;
      private bool[] T001355_A35FerramentaColetaAtivo ;
      private int[] T001356_A36AbrangenciaGeograficaId ;
      private bool[] T001356_n36AbrangenciaGeograficaId ;
      private string[] T001356_A37AbrangenciaGeograficaNome ;
      private bool[] T001356_A38AbrangenciaGeograficaAtivo ;
      private int[] T001357_A39FrequenciaTratamentoId ;
      private bool[] T001357_n39FrequenciaTratamentoId ;
      private string[] T001357_A40FrequenciaTratamentoNome ;
      private bool[] T001357_A41FrequenciaTratamentoAtivo ;
      private int[] T001358_A45TipoDescarteId ;
      private bool[] T001358_n45TipoDescarteId ;
      private string[] T001358_A46TipoDescarteNome ;
      private bool[] T001358_A47TipoDescarteAtivo ;
      private int[] T001359_A48TempoRetencaoId ;
      private bool[] T001359_n48TempoRetencaoId ;
      private string[] T001359_A49TempoRetencaoNome ;
      private bool[] T001359_A50TempoRetencaoAtivo ;
      private string[] T001360_A107DocumentoProcessoNome ;
      private int[] T001361_A20SubprocessoId ;
      private bool[] T001361_n20SubprocessoId ;
      private int[] T001362_A13PersonaId ;
      private bool[] T001362_n13PersonaId ;
      private int[] T001363_A7EncarregadoId ;
      private bool[] T001363_n7EncarregadoId ;
      private int[] T001364_A27CategoriaId ;
      private bool[] T001364_n27CategoriaId ;
      private int[] T001365_A30TipoDadoId ;
      private bool[] T001365_n30TipoDadoId ;
      private int[] T001366_A33FerramentaColetaId ;
      private bool[] T001366_n33FerramentaColetaId ;
      private int[] T001367_A36AbrangenciaGeograficaId ;
      private bool[] T001367_n36AbrangenciaGeograficaId ;
      private int[] T001368_A39FrequenciaTratamentoId ;
      private bool[] T001368_n39FrequenciaTratamentoId ;
      private int[] T001369_A45TipoDescarteId ;
      private bool[] T001369_n45TipoDescarteId ;
      private int[] T001370_A48TempoRetencaoId ;
      private bool[] T001370_n48TempoRetencaoId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV24TrnContextAtt ;
   }

   public class documento__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documento__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new ForEachCursor(def[59])
       ,new ForEachCursor(def[60])
       ,new ForEachCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new ForEachCursor(def[65])
       ,new ForEachCursor(def[66])
       ,new ForEachCursor(def[67])
       ,new ForEachCursor(def[68])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001317;
        prmT001317 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00134;
        prmT00134 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00135;
        prmT00135 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00136;
        prmT00136 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00137;
        prmT00137 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00138;
        prmT00138 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00139;
        prmT00139 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001310;
        prmT001310 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001311;
        prmT001311 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001312;
        prmT001312 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001313;
        prmT001313 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001315;
        prmT001315 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001314;
        prmT001314 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001316;
        prmT001316 = new Object[] {
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001318;
        prmT001318 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001319;
        prmT001319 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001320;
        prmT001320 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001321;
        prmT001321 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001322;
        prmT001322 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001323;
        prmT001323 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001324;
        prmT001324 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001325;
        prmT001325 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001326;
        prmT001326 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001327;
        prmT001327 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001328;
        prmT001328 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001329;
        prmT001329 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001330;
        prmT001330 = new Object[] {
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001331;
        prmT001331 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00133;
        prmT00133 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001332;
        prmT001332 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001333;
        prmT001333 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00132;
        prmT00132 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001334;
        prmT001334 = new Object[] {
        new ParDef("@DocumentoDataAlteracao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioAlteracao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoNome",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoFinalidadeTratamento",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNorm",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNormIntExt",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoMedidaSegurancaDesc",GXType.NVarChar,10000,0){Nullable=true} ,
        new ParDef("@DocumentoPrevColetaDados",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosCriancaAdolesc",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosGrupoVul",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoFluxoTratDadosDesc",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@DocumentoAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDataInclusao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioInclusao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoIsOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001335;
        prmT001335 = new Object[] {
        new ParDef("@DocumentoDataAlteracao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioAlteracao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoNome",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoFinalidadeTratamento",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNorm",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNormIntExt",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoMedidaSegurancaDesc",GXType.NVarChar,10000,0){Nullable=true} ,
        new ParDef("@DocumentoPrevColetaDados",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosCriancaAdolesc",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosGrupoVul",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoFluxoTratDadosDesc",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@DocumentoAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDataInclusao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioInclusao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoIsOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001336;
        prmT001336 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001337;
        prmT001337 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001338;
        prmT001338 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001339;
        prmT001339 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001340;
        prmT001340 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001341;
        prmT001341 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001342;
        prmT001342 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001343;
        prmT001343 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001344;
        prmT001344 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001345;
        prmT001345 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001346;
        prmT001346 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001347;
        prmT001347 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT001348;
        prmT001348 = new Object[] {
        };
        Object[] prmT001349;
        prmT001349 = new Object[] {
        };
        Object[] prmT001350;
        prmT001350 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001351;
        prmT001351 = new Object[] {
        };
        Object[] prmT001352;
        prmT001352 = new Object[] {
        };
        Object[] prmT001353;
        prmT001353 = new Object[] {
        };
        Object[] prmT001354;
        prmT001354 = new Object[] {
        };
        Object[] prmT001355;
        prmT001355 = new Object[] {
        };
        Object[] prmT001356;
        prmT001356 = new Object[] {
        };
        Object[] prmT001357;
        prmT001357 = new Object[] {
        };
        Object[] prmT001358;
        prmT001358 = new Object[] {
        };
        Object[] prmT001359;
        prmT001359 = new Object[] {
        };
        Object[] prmT001360;
        prmT001360 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001361;
        prmT001361 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001362;
        prmT001362 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001363;
        prmT001363 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001364;
        prmT001364 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001365;
        prmT001365 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001366;
        prmT001366 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001367;
        prmT001367 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001368;
        prmT001368 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001369;
        prmT001369 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001370;
        prmT001370 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00132", "SELECT [DocumentoId], [DocumentoDataAlteracao], [DocumentoUsuarioAlteracao], [DocumentoNome], [DocumentoFinalidadeTratamento], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoMedidaSegurancaDesc], [DocumentoPrevColetaDados], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoDataInclusao], [DocumentoUsuarioInclusao], [DocumentoIsOperador], [SubprocessoId], [EncarregadoId], [PersonaId], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [AreaResponsavelId], [DocumentoProcessoId] AS DocumentoProcessoId, [DocumentoControladorId] AS DocumentoControladorId FROM [Documento] WITH (UPDLOCK) WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00132,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00133", "SELECT [DocumentoId], [DocumentoDataAlteracao], [DocumentoUsuarioAlteracao], [DocumentoNome], [DocumentoFinalidadeTratamento], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoMedidaSegurancaDesc], [DocumentoPrevColetaDados], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoDataInclusao], [DocumentoUsuarioInclusao], [DocumentoIsOperador], [SubprocessoId], [EncarregadoId], [PersonaId], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [AreaResponsavelId], [DocumentoProcessoId] AS DocumentoProcessoId, [DocumentoControladorId] AS DocumentoControladorId FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00133,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00134", "SELECT [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00134,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00135", "SELECT [EncarregadoId] FROM [Encarregado] WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00135,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00136", "SELECT [PersonaId] FROM [Persona] WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00136,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00137", "SELECT [CategoriaId] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00137,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00138", "SELECT [TipoDadoId] FROM [TipoDado] WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00138,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00139", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00139,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001310", "SELECT [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001311", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001312", "SELECT [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001313", "SELECT [TempoRetencaoId] FROM [TempoRetencao] WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001314", "SELECT [AreaResponsavelId] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001314,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001315", "SELECT [ProcessoNome] AS DocumentoProcessoNome FROM [Processo] WHERE [ProcessoId] = @DocumentoProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001315,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001316", "SELECT [ControladorId] AS DocumentoControladorId FROM [Controlador] WHERE [ControladorId] = @DocumentoControladorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001316,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001317", "SELECT TM1.[DocumentoId], TM1.[DocumentoDataAlteracao], TM1.[DocumentoUsuarioAlteracao], TM1.[DocumentoNome], TM1.[DocumentoFinalidadeTratamento], TM1.[DocumentoBaseLegalNorm], TM1.[DocumentoBaseLegalNormIntExt], TM1.[DocumentoMedidaSegurancaDesc], TM1.[DocumentoPrevColetaDados], TM1.[DocumentoDadosCriancaAdolesc], TM1.[DocumentoDadosGrupoVul], TM1.[DocumentoFluxoTratDadosDesc], TM1.[DocumentoAtivo], TM1.[DocumentoOperador], T2.[ProcessoNome] AS DocumentoProcessoNome, TM1.[DocumentoDataInclusao], TM1.[DocumentoUsuarioInclusao], TM1.[DocumentoIsOperador], TM1.[SubprocessoId], TM1.[EncarregadoId], TM1.[PersonaId], TM1.[CategoriaId], TM1.[TipoDadoId], TM1.[FerramentaColetaId], TM1.[AbrangenciaGeograficaId], TM1.[FrequenciaTratamentoId], TM1.[TipoDescarteId], TM1.[TempoRetencaoId], TM1.[AreaResponsavelId], TM1.[DocumentoProcessoId] AS DocumentoProcessoId, TM1.[DocumentoControladorId] AS DocumentoControladorId FROM ([Documento] TM1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = TM1.[DocumentoProcessoId]) WHERE TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001317,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001318", "SELECT [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001318,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001319", "SELECT [EncarregadoId] FROM [Encarregado] WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001319,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001320", "SELECT [PersonaId] FROM [Persona] WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001320,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001321", "SELECT [CategoriaId] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001321,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001322", "SELECT [TipoDadoId] FROM [TipoDado] WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001322,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001323", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001323,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001324", "SELECT [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001324,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001325", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001325,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001326", "SELECT [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001326,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001327", "SELECT [TempoRetencaoId] FROM [TempoRetencao] WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001327,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001328", "SELECT [ProcessoNome] AS DocumentoProcessoNome FROM [Processo] WHERE [ProcessoId] = @DocumentoProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001328,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001329", "SELECT [AreaResponsavelId] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001329,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001330", "SELECT [ControladorId] AS DocumentoControladorId FROM [Controlador] WHERE [ControladorId] = @DocumentoControladorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001330,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001331", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001331,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001332", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE ( [DocumentoId] > @DocumentoId) ORDER BY [DocumentoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001332,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001333", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE ( [DocumentoId] < @DocumentoId) ORDER BY [DocumentoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001333,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001334", "INSERT INTO [Documento]([DocumentoDataAlteracao], [DocumentoUsuarioAlteracao], [DocumentoNome], [DocumentoFinalidadeTratamento], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoMedidaSegurancaDesc], [DocumentoPrevColetaDados], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoDataInclusao], [DocumentoUsuarioInclusao], [DocumentoIsOperador], [SubprocessoId], [EncarregadoId], [PersonaId], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [AreaResponsavelId], [DocumentoProcessoId], [DocumentoControladorId]) VALUES(@DocumentoDataAlteracao, @DocumentoUsuarioAlteracao, @DocumentoNome, @DocumentoFinalidadeTratamento, @DocumentoBaseLegalNorm, @DocumentoBaseLegalNormIntExt, @DocumentoMedidaSegurancaDesc, @DocumentoPrevColetaDados, @DocumentoDadosCriancaAdolesc, @DocumentoDadosGrupoVul, @DocumentoFluxoTratDadosDesc, @DocumentoAtivo, @DocumentoOperador, @DocumentoDataInclusao, @DocumentoUsuarioInclusao, @DocumentoIsOperador, @SubprocessoId, @EncarregadoId, @PersonaId, @CategoriaId, @TipoDadoId, @FerramentaColetaId, @AbrangenciaGeograficaId, @FrequenciaTratamentoId, @TipoDescarteId, @TempoRetencaoId, @AreaResponsavelId, @DocumentoProcessoId, @DocumentoControladorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001334,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001335", "UPDATE [Documento] SET [DocumentoDataAlteracao]=@DocumentoDataAlteracao, [DocumentoUsuarioAlteracao]=@DocumentoUsuarioAlteracao, [DocumentoNome]=@DocumentoNome, [DocumentoFinalidadeTratamento]=@DocumentoFinalidadeTratamento, [DocumentoBaseLegalNorm]=@DocumentoBaseLegalNorm, [DocumentoBaseLegalNormIntExt]=@DocumentoBaseLegalNormIntExt, [DocumentoMedidaSegurancaDesc]=@DocumentoMedidaSegurancaDesc, [DocumentoPrevColetaDados]=@DocumentoPrevColetaDados, [DocumentoDadosCriancaAdolesc]=@DocumentoDadosCriancaAdolesc, [DocumentoDadosGrupoVul]=@DocumentoDadosGrupoVul, [DocumentoFluxoTratDadosDesc]=@DocumentoFluxoTratDadosDesc, [DocumentoAtivo]=@DocumentoAtivo, [DocumentoOperador]=@DocumentoOperador, [DocumentoDataInclusao]=@DocumentoDataInclusao, [DocumentoUsuarioInclusao]=@DocumentoUsuarioInclusao, [DocumentoIsOperador]=@DocumentoIsOperador, [SubprocessoId]=@SubprocessoId, [EncarregadoId]=@EncarregadoId, [PersonaId]=@PersonaId, [CategoriaId]=@CategoriaId, [TipoDadoId]=@TipoDadoId, [FerramentaColetaId]=@FerramentaColetaId, [AbrangenciaGeograficaId]=@AbrangenciaGeograficaId, [FrequenciaTratamentoId]=@FrequenciaTratamentoId, [TipoDescarteId]=@TipoDescarteId, [TempoRetencaoId]=@TempoRetencaoId, [AreaResponsavelId]=@AreaResponsavelId, [DocumentoProcessoId]=@DocumentoProcessoId, [DocumentoControladorId]=@DocumentoControladorId  WHERE [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmT001335)
           ,new CursorDef("T001336", "DELETE FROM [Documento]  WHERE [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmT001336)
           ,new CursorDef("T001337", "SELECT [ProcessoNome] AS DocumentoProcessoNome FROM [Processo] WHERE [ProcessoId] = @DocumentoProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001337,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001338", "SELECT TOP 1 [DocImagemId] FROM [DocImagem] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001338,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001339", "SELECT TOP 1 [RevisaoLogId] FROM [RevisaoLog] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001339,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001340", "SELECT TOP 1 [DocAnexoId] FROM [DocAnexo] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001340,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001341", "SELECT TOP 1 [DocOperadorId] FROM [DocOperador] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001341,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001342", "SELECT TOP 1 [DocDicionarioId] FROM [DocDicionario] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001342,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001343", "SELECT TOP 1 [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001343,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001344", "SELECT TOP 1 [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001344,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001345", "SELECT TOP 1 [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001345,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001346", "SELECT TOP 1 [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001346,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001347", "SELECT TOP 1 [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001347,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001348", "SELECT [DocumentoId] FROM [Documento] ORDER BY [DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001348,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001349", "SELECT [ProcessoId] AS DocumentoProcessoId, [ProcessoNome] AS DocumentoProcessoNome, [ProcessoAtivo] FROM [Processo] WHERE [ProcessoAtivo] = 1 ORDER BY [ProcessoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001349,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001350", "SELECT [SubprocessoId], [SubprocessoNome], [SubprocessoAtivo], [ProcessoId] FROM [SubProcesso] WHERE ([SubprocessoAtivo] = 1) AND ([ProcessoId] = @DocumentoProcessoId) ORDER BY [SubprocessoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001350,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001351", "SELECT [PersonaId], [PersonaNome], [PersonaAtivo] FROM [Persona] WHERE [PersonaAtivo] = 1 ORDER BY [PersonaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001351,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001352", "SELECT [EncarregadoId], [EncarregadoNome], [EncarregadoAtivo] FROM [Encarregado] WHERE [EncarregadoAtivo] = 1 ORDER BY [EncarregadoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001352,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001353", "SELECT [ControladorId], [ControladorNome], [ControladorAtivo] FROM [Controlador] WHERE [ControladorAtivo] = 1 ORDER BY [ControladorNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001353,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001354", "SELECT [TipoDadoId], [TipoDadoNome], [TipoDadoAtivo] FROM [TipoDado] WHERE [TipoDadoAtivo] = 1 ORDER BY [TipoDadoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001354,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001355", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WHERE [FerramentaColetaAtivo] = 1 ORDER BY [FerramentaColetaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001355,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001356", "SELECT [AbrangenciaGeograficaId], [AbrangenciaGeograficaNome], [AbrangenciaGeograficaAtivo] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaAtivo] = 1 ORDER BY [AbrangenciaGeograficaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001356,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001357", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoAtivo] = 1 ORDER BY [FrequenciaTratamentoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001357,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001358", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WHERE [TipoDescarteAtivo] = 1 ORDER BY [TipoDescarteNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001358,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001359", "SELECT [TempoRetencaoId], [TempoRetencaoNome], [TempoRetencaoAtivo] FROM [TempoRetencao] WHERE [TempoRetencaoAtivo] = 1 ORDER BY [TempoRetencaoNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001359,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001360", "SELECT [ProcessoNome] AS DocumentoProcessoNome FROM [Processo] WHERE [ProcessoId] = @DocumentoProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001360,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001361", "SELECT [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001361,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001362", "SELECT [PersonaId] FROM [Persona] WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001362,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001363", "SELECT [EncarregadoId] FROM [Encarregado] WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001363,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001364", "SELECT [CategoriaId] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001364,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001365", "SELECT [TipoDadoId] FROM [TipoDado] WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001365,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001366", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001366,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001367", "SELECT [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001367,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001368", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001368,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001369", "SELECT [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001369,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001370", "SELECT [TempoRetencaoId] FROM [TempoRetencao] WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001370,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((bool[]) buf[31])[0] = rslt.getBool(17);
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
              ((int[]) buf[43])[0] = rslt.getInt(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((int[]) buf[45])[0] = rslt.getInt(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((int[]) buf[47])[0] = rslt.getInt(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((int[]) buf[49])[0] = rslt.getInt(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((int[]) buf[51])[0] = rslt.getInt(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((int[]) buf[53])[0] = rslt.getInt(28);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((int[]) buf[55])[0] = rslt.getInt(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((int[]) buf[57])[0] = rslt.getInt(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((bool[]) buf[31])[0] = rslt.getBool(17);
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
              ((int[]) buf[43])[0] = rslt.getInt(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((int[]) buf[45])[0] = rslt.getInt(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((int[]) buf[47])[0] = rslt.getInt(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((int[]) buf[49])[0] = rslt.getInt(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((int[]) buf[51])[0] = rslt.getInt(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((int[]) buf[53])[0] = rslt.getInt(28);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((int[]) buf[55])[0] = rslt.getInt(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((int[]) buf[57])[0] = rslt.getInt(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[29])[0] = rslt.wasNull(16);
              ((string[]) buf[30])[0] = rslt.getVarchar(17);
              ((bool[]) buf[31])[0] = rslt.wasNull(17);
              ((bool[]) buf[32])[0] = rslt.getBool(18);
              ((bool[]) buf[33])[0] = rslt.wasNull(18);
              ((int[]) buf[34])[0] = rslt.getInt(19);
              ((bool[]) buf[35])[0] = rslt.wasNull(19);
              ((int[]) buf[36])[0] = rslt.getInt(20);
              ((bool[]) buf[37])[0] = rslt.wasNull(20);
              ((int[]) buf[38])[0] = rslt.getInt(21);
              ((bool[]) buf[39])[0] = rslt.wasNull(21);
              ((int[]) buf[40])[0] = rslt.getInt(22);
              ((bool[]) buf[41])[0] = rslt.wasNull(22);
              ((int[]) buf[42])[0] = rslt.getInt(23);
              ((bool[]) buf[43])[0] = rslt.wasNull(23);
              ((int[]) buf[44])[0] = rslt.getInt(24);
              ((bool[]) buf[45])[0] = rslt.wasNull(24);
              ((int[]) buf[46])[0] = rslt.getInt(25);
              ((bool[]) buf[47])[0] = rslt.wasNull(25);
              ((int[]) buf[48])[0] = rslt.getInt(26);
              ((bool[]) buf[49])[0] = rslt.wasNull(26);
              ((int[]) buf[50])[0] = rslt.getInt(27);
              ((bool[]) buf[51])[0] = rslt.wasNull(27);
              ((int[]) buf[52])[0] = rslt.getInt(28);
              ((bool[]) buf[53])[0] = rslt.wasNull(28);
              ((int[]) buf[54])[0] = rslt.getInt(29);
              ((bool[]) buf[55])[0] = rslt.wasNull(29);
              ((int[]) buf[56])[0] = rslt.getInt(30);
              ((bool[]) buf[57])[0] = rslt.wasNull(30);
              ((int[]) buf[58])[0] = rslt.getInt(31);
              ((bool[]) buf[59])[0] = rslt.wasNull(31);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 31 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 32 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 36 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 37 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 38 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 39 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 40 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 41 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 42 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 43 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 44 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 45 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 46 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 47 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 48 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 49 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 50 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 51 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 52 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 53 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 54 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 55 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 56 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 57 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 58 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 59 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
     getresults60( cursor, rslt, buf) ;
  }

  public void getresults60( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 60 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 61 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 62 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 63 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 64 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 65 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 66 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 67 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 68 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
