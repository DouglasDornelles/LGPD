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
   public class dicionariowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public dicionariowc( )
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

      public dicionariowc( IGxContext context )
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
         this.AV16DocumentoId = aP1_DocumentoId;
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
         cmbavInformacaoid = new GXCombobox();
         chkavDocdicionariopodeeliminar = new GXCheckbox();
         chkavDocdicionariosensivel = new GXCheckbox();
         cmbavHipotesetratamentoid = new GXCombobox();
         cmbavDocdicionariotransfinter = new GXCombobox();
         chkDocDicionarioSensivel = new GXCheckbox();
         chkDocDicionarioPodeEliminar = new GXCheckbox();
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
                  AV16DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "AV16DocumentoId", StringUtil.LTrimStr( (decimal)(AV16DocumentoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV16DocumentoId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
               {
                  gxnrGrid1_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
               {
                  gxgrGrid1_refresh_invoke( ) ;
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_126 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_126"), "."));
         nGXsfl_126_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_126_idx"), "."));
         sGXsfl_126_idx = GetPar( "sGXsfl_126_idx");
         sPrefix = GetPar( "sPrefix");
         edtavAtualizar_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_126_Refreshing);
         edtavExcluir_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_126_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
         AV16DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
         AV56IsInformacao = StringUtil.StrToBool( GetPar( "IsInformacao"));
         AV57InformacaoId_Out = (short)(NumberUtil.Val( GetPar( "InformacaoId_Out"), "."));
         AV59IsHipotese = StringUtil.StrToBool( GetPar( "IsHipotese"));
         AV58HipoteseTratamentoId_Out = (int)(NumberUtil.Val( GetPar( "HipoteseTratamentoId_Out"), "."));
         AV60IsPais = StringUtil.StrToBool( GetPar( "IsPais"));
         AV61PaisId_Out = (int)(NumberUtil.Val( GetPar( "PaisId_Out"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV79PaisId_Col);
         AV62IsCompartTercExterno = StringUtil.StrToBool( GetPar( "IsCompartTercExterno"));
         AV63CompartTercExternoId_Out = (int)(NumberUtil.Val( GetPar( "CompartTercExternoId_Out"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV64CompartTercExternoId_Col);
         A71InformacaoAtivo = StringUtil.StrToBool( GetPar( "InformacaoAtivo"));
         A74HipoteseTratamentoAtivo = StringUtil.StrToBool( GetPar( "HipoteseTratamentoAtivo"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21PaisId);
         A5PaisNome = GetPar( "PaisNome");
         A6PaisAtivo = StringUtil.StrToBool( GetPar( "PaisAtivo"));
         A4PaisId = (int)(NumberUtil.Val( GetPar( "PaisId"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6CompartTercExternoId);
         A67CompartTercExternoNome = GetPar( "CompartTercExternoNome");
         A68CompartTercExternoAtivo = StringUtil.StrToBool( GetPar( "CompartTercExternoAtivo"));
         A66CompartTercExternoId = (int)(NumberUtil.Val( GetPar( "CompartTercExternoId"), "."));
         edtavAtualizar_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_126_Refreshing);
         edtavExcluir_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_126_Refreshing);
         AV68TotalDadosSensiveis = (short)(NumberUtil.Val( GetPar( "TotalDadosSensiveis"), "."));
         AV67TotalDados = (short)(NumberUtil.Val( GetPar( "TotalDados"), "."));
         AV11DocDicionarioPodeEliminar = StringUtil.StrToBool( GetPar( "DocDicionarioPodeEliminar"));
         AV12DocDicionarioSensivel = StringUtil.StrToBool( GetPar( "DocDicionarioSensivel"));
         AV8DocDicionarioDataInclusao = context.localUtil.ParseDateParm( GetPar( "DocDicionarioDataInclusao"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            PA7I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavDocdicionariosensivel_grid_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocdicionariosensivel_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariosensivel_grid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
               edtavDocdicionariopodeeliminar_grid_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocdicionariopodeeliminar_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariopodeeliminar_grid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
               edtavDocdicionariotransfintergrid_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotransfintergrid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
               edtavVisualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_126_Refreshing);
               edtavAtualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_126_Refreshing);
               edtavExcluir_Enabled = 0;
               AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_126_Refreshing);
               edtavTotaldados_Enabled = 0;
               AssignProp(sPrefix, false, edtavTotaldados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaldados_Enabled), 5, 0), true);
               edtavTotaldadossensiveis_Enabled = 0;
               AssignProp(sPrefix, false, edtavTotaldadossensiveis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaldadossensiveis_Enabled), 5, 0), true);
               WS7I2( ) ;
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
            context.SendWebValue( "Aba de Dicionário para o cadastro de um Documento") ;
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
               GXEncryptionTmp = "dicionariowc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV16DocumentoId,8,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("dicionariowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCDICIONARIODATAINCLUSAO", GetSecureSignedToken( sPrefix, AV8DocDicionarioDataInclusao, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_126", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_126), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPAISID_DATA", AV80PaisId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPAISID_DATA", AV80PaisId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPARTTERCEXTERNOID_DATA", AV38CompartTercExternoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPARTTERCEXTERNOID_DATA", AV38CompartTercExternoId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV16DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISINFORMACAO", AV56IsInformacao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINFORMACAOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57InformacaoId_Out), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISHIPOTESE", AV59IsHipotese);
         GxWebStd.gx_hidden_field( context, sPrefix+"vHIPOTESETRATAMENTOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58HipoteseTratamentoId_Out), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPAIS", AV60IsPais);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPAISID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61PaisId_Out), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPAISID_COL", AV79PaisId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPAISID_COL", AV79PaisId_Col);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISCOMPARTTERCEXTERNO", AV62IsCompartTercExterno);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMPARTTERCEXTERNOID_OUT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63CompartTercExternoId_Out), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPARTTERCEXTERNOID_COL", AV64CompartTercExternoId_Col);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPARTTERCEXTERNOID_COL", AV64CompartTercExternoId_Col);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"INFORMACAOATIVO", A71InformacaoAtivo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"HIPOTESETRATAMENTOATIVO", A74HipoteseTratamentoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"HIPOTESETRATAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72HipoteseTratamentoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPAISID", AV21PaisId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPAISID", AV21PaisId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"PAISNOME", A5PaisNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"PAISATIVO", A6PaisAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4PaisId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPARTTERCEXTERNOID", AV6CompartTercExternoId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPARTTERCEXTERNOID", AV6CompartTercExternoId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"COMPARTTERCEXTERNONOME", A67CompartTercExternoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"COMPARTTERCEXTERNOATIVO", A68CompartTercExternoAtivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMPARTTERCEXTERNOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A66CompartTercExternoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISDISPLAY", AV78isDisplay);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV54CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vINFORMACAOEXISTE", AV77InformacaoExiste);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCDICIONARIODATAINCLUSAO", context.localUtil.DToC( AV8DocDicionarioDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCDICIONARIODATAINCLUSAO", GetSecureSignedToken( sPrefix, AV8DocDicionarioDataInclusao, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCDICIONARIO", AV7DocDicionario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCDICIONARIO", AV7DocDicionario);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMPARTTERCEXTERNOID_ITEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39CompartTercExternoId_Item), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPAISID_ITEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81PaisId_Item), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Cls", StringUtil.RTrim( Combo_paisid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Selectedvalue_set", StringUtil.RTrim( Combo_paisid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Allowmultipleselection", StringUtil.BoolToStr( Combo_paisid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_paisid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Emptyitem", StringUtil.BoolToStr( Combo_paisid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Multiplevaluestype", StringUtil.RTrim( Combo_paisid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Cls", StringUtil.RTrim( Combo_comparttercexternoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_set", StringUtil.RTrim( Combo_comparttercexternoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Enabled", StringUtil.BoolToStr( Combo_comparttercexternoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Allowmultipleselection", StringUtil.BoolToStr( Combo_comparttercexternoid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_comparttercexternoid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Multiplevaluestype", StringUtil.RTrim( Combo_comparttercexternoid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Emptyitemtext", StringUtil.RTrim( Combo_comparttercexternoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Grid1_empowerer_Infinitescrolling));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_comparttercexternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Ddointernalname", StringUtil.RTrim( Combo_paisid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Ddointernalname", StringUtil.RTrim( Combo_comparttercexternoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"vATUALIZAR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEXCLUIR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_comparttercexternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_get", StringUtil.RTrim( Combo_comparttercexternoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PAISID_Ddointernalname", StringUtil.RTrim( Combo_paisid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMPARTTERCEXTERNOID_Ddointernalname", StringUtil.RTrim( Combo_comparttercexternoid_Ddointernalname));
      }

      protected void RenderHtmlCloseForm7I2( )
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
         return "DicionarioWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aba de Dicionário para o cadastro de um Documento" ;
      }

      protected void WB7I0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "dicionariowc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-11 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavInformacaoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavInformacaoid_Internalname, "INFORMAÇÃO", "col-sm-2 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavInformacaoid, cmbavInformacaoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0)), 1, cmbavInformacaoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavInformacaoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_DicionarioWC.htm");
            cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
            AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", (string)(cmbavInformacaoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table1_22_7I2( true) ;
         }
         else
         {
            wb_table1_22_7I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_7I2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocdicionariopodeeliminar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocdicionariopodeeliminar_Internalname, "PODE ELIMINAR", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocdicionariopodeeliminar_Internalname, StringUtil.BoolToStr( AV11DocDicionarioPodeEliminar), "", "PODE ELIMINAR", 1, chkavDocdicionariopodeeliminar.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(32, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,32);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPodeeliminarinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblPodeeliminarinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e117i1_client"+"'", "", "TextBlock", 7, lblPodeeliminarinfo_Tooltiptext, 1, 1, 0, 1, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDocdicionariosensivel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocdicionariosensivel_Internalname, "POSSUÍ DADOS SENSÍVEIS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocdicionariosensivel_Internalname, StringUtil.BoolToStr( AV12DocDicionarioSensivel), "", "POSSUÍ DADOS SENSÍVEIS", 1, chkavDocdicionariosensivel.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(38, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSensivelinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblSensivelinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e127i1_client"+"'", "", "TextBlock", 7, lblSensivelinfo_Tooltiptext, lblSensivelinfo_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-11 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavHipotesetratamentoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavHipotesetratamentoid_Internalname, "HIPÓTESE TRATAMENTO", "col-sm-2 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavHipotesetratamentoid, cmbavHipotesetratamentoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0)), 1, cmbavHipotesetratamentoid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavHipotesetratamentoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_DicionarioWC.htm");
            cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
            AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", (string)(cmbavHipotesetratamentoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table2_47_7I2( true) ;
         }
         else
         {
            wb_table2_47_7I2( false) ;
         }
         return  ;
      }

      protected void wb_table2_47_7I2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-5 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavDocdicionariotransfinter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocdicionariotransfinter_Internalname, "TRANSFERÊNCIA INTERNACIONAL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocdicionariotransfinter, cmbavDocdicionariotransfinter_Internalname, StringUtil.BoolToStr( AV13DocDicionarioTransfInter), 1, cmbavDocdicionariotransfinter_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocdicionariotransfinter.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_DicionarioWC.htm");
            cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV13DocDicionarioTransfInter);
            AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Values", (string)(cmbavDocdicionariotransfinter.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransfinterinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblTransfinterinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e137i1_client"+"'", "", "TextBlock", 7, lblTransfinterinfo_Tooltiptext, lblTransfinterinfo_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_paisid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_paisid_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpaisid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_paisid_Internalname, "PAÍS", "", "", lblTextblockcombo_paisid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_paisid.SetProperty("Caption", Combo_paisid_Caption);
            ucCombo_paisid.SetProperty("Cls", Combo_paisid_Cls);
            ucCombo_paisid.SetProperty("AllowMultipleSelection", Combo_paisid_Allowmultipleselection);
            ucCombo_paisid.SetProperty("IncludeOnlySelectedOption", Combo_paisid_Includeonlyselectedoption);
            ucCombo_paisid.SetProperty("EmptyItem", Combo_paisid_Emptyitem);
            ucCombo_paisid.SetProperty("MultipleValuesType", Combo_paisid_Multiplevaluestype);
            ucCombo_paisid.SetProperty("DropDownOptionsTitleSettingsIcons", AV41DDO_TitleSettingsIcons);
            ucCombo_paisid.SetProperty("DropDownOptionsData", AV80PaisId_Data);
            ucCombo_paisid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paisid_Internalname, sPrefix+"COMBO_PAISIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table3_68_7I2( true) ;
         }
         else
         {
            wb_table3_68_7I2( false) ;
         }
         return  ;
      }

      protected void wb_table3_68_7I2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDocdicionariotipotransfintergarantia_cell_Internalname, 1, 0, "px", 0, "px", divDocdicionariotipotransfintergarantia_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocdicionariotipotransfintergarantia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocdicionariotipotransfintergarantia_Internalname, "TIPO GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocdicionariotipotransfintergarantia_Internalname, AV51DocDicionarioTipoTransfInterGarantia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", 0, 1, edtavDocdicionariotipotransfintergarantia_Enabled, 1, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTipotransfintergarantia_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblTipotransfintergarantia_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e147i1_client"+"'", "", "TextBlock", 7, lblTipotransfintergarantia_Tooltiptext, lblTipotransfintergarantia_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxttipotransfinter_Internalname, lblTxttipotransfinter_Caption, "", "", lblTxttipotransfinter_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTxttipotransfinter_Visible, 1, 0, 0, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-11 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcomparttercexternoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_comparttercexternoid_Internalname, "COMPARTILHAMENTO COM TERCEIROS/EXTERNOS", "", "", lblTextblockcombo_comparttercexternoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_comparttercexternoid.SetProperty("Caption", Combo_comparttercexternoid_Caption);
            ucCombo_comparttercexternoid.SetProperty("Cls", Combo_comparttercexternoid_Cls);
            ucCombo_comparttercexternoid.SetProperty("AllowMultipleSelection", Combo_comparttercexternoid_Allowmultipleselection);
            ucCombo_comparttercexternoid.SetProperty("IncludeOnlySelectedOption", Combo_comparttercexternoid_Includeonlyselectedoption);
            ucCombo_comparttercexternoid.SetProperty("MultipleValuesType", Combo_comparttercexternoid_Multiplevaluestype);
            ucCombo_comparttercexternoid.SetProperty("EmptyItemText", Combo_comparttercexternoid_Emptyitemtext);
            ucCombo_comparttercexternoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV41DDO_TitleSettingsIcons);
            ucCombo_comparttercexternoid.SetProperty("DropDownOptionsData", AV38CompartTercExternoId_Data);
            ucCombo_comparttercexternoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_comparttercexternoid_Internalname, sPrefix+"COMBO_COMPARTTERCEXTERNOIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            wb_table4_98_7I2( true) ;
         }
         else
         {
            wb_table4_98_7I2( false) ;
         }
         return  ;
      }

      protected void wb_table4_98_7I2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-11 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocdicionariofinalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocdicionariofinalidade_Internalname, "FINALIDADE DO COMPARTILHAMENTO COM EXTERNOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocdicionariofinalidade_Internalname, AV9DocDicionarioFinalidade, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", 0, 1, edtavDocdicionariofinalidade_Enabled, 1, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFinalidadeinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblFinalidadeinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e157i1_client"+"'", "", "TextBlock", 7, lblFinalidadeinfo_Tooltiptext, lblFinalidadeinfo_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadicionar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(126), 3, 0)+","+"null"+");", bttBtnadicionar_Caption, bttBtnadicionar_Jsonclick, 5, "ADICIONAR", "", StyleString, ClassString, bttBtnadicionar_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADICIONAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
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
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl126( ) ;
         }
         if ( wbEnd == 126 )
         {
            wbEnd = 0;
            nRC_GXsfl_126 = (int)(nGXsfl_126_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DashboardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotaldados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotaldados_Internalname, "TOTAL DE DADOS", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotaldados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67TotalDados), 4, 0, ",", "")), StringUtil.LTrim( ((edtavTotaldados_Enabled!=0) ? context.localUtil.Format( (decimal)(AV67TotalDados), "ZZZ9") : context.localUtil.Format( (decimal)(AV67TotalDados), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,144);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotaldados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTotaldados_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DicionarioWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CardTitle", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotaldadossensiveis_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotaldadossensiveis_Internalname, "TOTAL DE DADOS SENSÍVEIS", "col-sm-6 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotaldadossensiveis_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68TotalDadosSensiveis), 4, 0, ",", "")), StringUtil.LTrim( ((edtavTotaldadossensiveis_Enabled!=0) ? context.localUtil.Format( (decimal)(AV68TotalDadosSensiveis), "ZZZ9") : context.localUtil.Format( (decimal)(AV68TotalDadosSensiveis), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,149);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotaldadossensiveis_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTotaldadossensiveis_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DicionarioWC.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavDocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocumentoid_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DicionarioWC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocdicionarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10DocDicionarioId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10DocDicionarioId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,154);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocdicionarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocdicionarioid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DicionarioWC.htm");
            /* User Defined Control */
            ucGrid1_empowerer.SetProperty("InfiniteScrolling", Grid1_empowerer_Infinitescrolling);
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, sPrefix+"GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 126 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7I2( )
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
               Form.Meta.addItem("description", "Aba de Dicionário para o cadastro de um Documento", 0) ;
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
               STRUP7I0( ) ;
            }
         }
      }

      protected void WS7I2( )
      {
         START7I2( ) ;
         EVT7I2( ) ;
      }

      protected void EVT7I2( )
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
                                 STRUP7I0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOHIPOTESEADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoHipoteseAdd' */
                                    E167I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPAISADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPaisAdd' */
                                    E177I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCOMPARTTERCEXTERADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCompartTercExterAdd' */
                                    E187I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdicionar' */
                                    E197I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINFORMACAOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInformacaoAdd' */
                                    E207I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDOCDICIONARIOTRANSFINTER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E217I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VEXCLUIR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID1.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VEXCLUIR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7I0( ) ;
                              }
                              nGXsfl_126_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
                              SubsflControlProps_1262( ) ;
                              A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", "."));
                              A69InformacaoId = (int)(context.localUtil.CToN( cgiGet( edtInformacaoId_Internalname), ",", "."));
                              A70InformacaoNome = cgiGet( edtInformacaoNome_Internalname);
                              AV65DocDicionarioSensivel_Grid = cgiGet( edtavDocdicionariosensivel_grid_Internalname);
                              AssignAttri(sPrefix, false, edtavDocdicionariosensivel_grid_Internalname, AV65DocDicionarioSensivel_Grid);
                              A99DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkDocDicionarioSensivel_Internalname));
                              AV66DocDicionarioPodeEliminar_Grid = cgiGet( edtavDocdicionariopodeeliminar_grid_Internalname);
                              AssignAttri(sPrefix, false, edtavDocdicionariopodeeliminar_grid_Internalname, AV66DocDicionarioPodeEliminar_Grid);
                              A100DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkDocDicionarioPodeEliminar_Internalname));
                              A73HipoteseTratamentoNome = cgiGet( edtHipoteseTratamentoNome_Internalname);
                              A101DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( edtDocDicionarioTransfInter_Internalname));
                              AV43DocDicionarioTransfInterGrid = cgiGet( edtavDocdicionariotransfintergrid_Internalname);
                              AssignAttri(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, AV43DocDicionarioTransfInterGrid);
                              AV50Visualizar = cgiGet( edtavVisualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV50Visualizar);
                              AV35Atualizar = cgiGet( edtavAtualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavAtualizar_Internalname, AV35Atualizar);
                              AV44Excluir = cgiGet( edtavExcluir_Internalname);
                              AssignAttri(sPrefix, false, edtavExcluir_Internalname, AV44Excluir);
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
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E227I2 ();
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
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E237I2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E247I2 ();
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
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E257I2 ();
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
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E267I2 ();
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
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E277I2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E287I2 ();
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
                                       STRUP7I0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDocdicionariosensivel_grid_Internalname;
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

      protected void WE7I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7I2( ) ;
            }
         }
      }

      protected void PA7I2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "dicionariowc.aspx")), "dicionariowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "dicionariowc.aspx")))) ;
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
               GX_FocusControl = cmbavInformacaoid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1262( ) ;
         while ( nGXsfl_126_idx <= nRC_GXsfl_126 )
         {
            sendrow_1262( ) ;
            nGXsfl_126_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_126_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_idx+1);
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV16DocumentoId ,
                                        bool AV56IsInformacao ,
                                        short AV57InformacaoId_Out ,
                                        bool AV59IsHipotese ,
                                        int AV58HipoteseTratamentoId_Out ,
                                        bool AV60IsPais ,
                                        int AV61PaisId_Out ,
                                        GxSimpleCollection<int> AV79PaisId_Col ,
                                        bool AV62IsCompartTercExterno ,
                                        int AV63CompartTercExternoId_Out ,
                                        GxSimpleCollection<int> AV64CompartTercExternoId_Col ,
                                        bool A71InformacaoAtivo ,
                                        bool A74HipoteseTratamentoAtivo ,
                                        GxSimpleCollection<int> AV21PaisId ,
                                        string A5PaisNome ,
                                        bool A6PaisAtivo ,
                                        int A4PaisId ,
                                        GxSimpleCollection<int> AV6CompartTercExternoId ,
                                        string A67CompartTercExternoNome ,
                                        bool A68CompartTercExternoAtivo ,
                                        int A66CompartTercExternoId ,
                                        short AV68TotalDadosSensiveis ,
                                        short AV67TotalDados ,
                                        bool AV11DocDicionarioPodeEliminar ,
                                        bool AV12DocDicionarioSensivel ,
                                        DateTime AV8DocDicionarioDataInclusao ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E237I2 ();
         GRID1_nCurrentRecord = 0;
         RF7I2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid1_refresh */
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
         if ( cmbavInformacaoid.ItemCount > 0 )
         {
            AV18InformacaoId = (int)(NumberUtil.Val( cmbavInformacaoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV18InformacaoId", StringUtil.LTrimStr( (decimal)(AV18InformacaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
            AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         }
         AV11DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( AV11DocDicionarioPodeEliminar));
         AssignAttri(sPrefix, false, "AV11DocDicionarioPodeEliminar", AV11DocDicionarioPodeEliminar);
         AV12DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( AV12DocDicionarioSensivel));
         AssignAttri(sPrefix, false, "AV12DocDicionarioSensivel", AV12DocDicionarioSensivel);
         if ( cmbavHipotesetratamentoid.ItemCount > 0 )
         {
            AV17HipoteseTratamentoId = (int)(NumberUtil.Val( cmbavHipotesetratamentoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV17HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
            AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         }
         if ( cmbavDocdicionariotransfinter.ItemCount > 0 )
         {
            AV13DocDicionarioTransfInter = StringUtil.StrToBool( cmbavDocdicionariotransfinter.getValidValue(StringUtil.BoolToStr( AV13DocDicionarioTransfInter)));
            AssignAttri(sPrefix, false, "AV13DocDicionarioTransfInter", AV13DocDicionarioTransfInter);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV13DocDicionarioTransfInter);
            AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Values", cmbavDocdicionariotransfinter.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GRID1_nCurrentRecord = 0;
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_126_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E237I2 ();
         RF7I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDocdicionariosensivel_grid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariosensivel_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariosensivel_grid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavDocdicionariopodeeliminar_grid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariopodeeliminar_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariopodeeliminar_grid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavDocdicionariotransfintergrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotransfintergrid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavAtualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavExcluir_Enabled = 0;
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavTotaldados_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotaldados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaldados_Enabled), 5, 0), true);
         edtavTotaldadossensiveis_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotaldadossensiveis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaldadossensiveis_Enabled), 5, 0), true);
      }

      protected void RF7I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 126;
         E287I2 ();
         nGXsfl_126_idx = (int)(1+GRID1_nFirstRecordOnPage);
         sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
         SubsflControlProps_1262( ) ;
         bGXsfl_126_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", sPrefix);
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1262( ) ;
            GXPagingFrom2 = (int)(((subGrid1_Rows==0) ? 0 : GRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid1_Rows==0) ? 10000 : subGrid1_fnc_Recordsperpage( )+1);
            /* Using cursor H007I2 */
            pr_default.execute(0, new Object[] {AV16DocumentoId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_126_idx = (int)(1+GRID1_nFirstRecordOnPage);
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A72HipoteseTratamentoId = H007I2_A72HipoteseTratamentoId[0];
               A75DocumentoId = H007I2_A75DocumentoId[0];
               A101DocDicionarioTransfInter = H007I2_A101DocDicionarioTransfInter[0];
               A73HipoteseTratamentoNome = H007I2_A73HipoteseTratamentoNome[0];
               A100DocDicionarioPodeEliminar = H007I2_A100DocDicionarioPodeEliminar[0];
               A99DocDicionarioSensivel = H007I2_A99DocDicionarioSensivel[0];
               A70InformacaoNome = H007I2_A70InformacaoNome[0];
               A69InformacaoId = H007I2_A69InformacaoId[0];
               A98DocDicionarioId = H007I2_A98DocDicionarioId[0];
               A73HipoteseTratamentoNome = H007I2_A73HipoteseTratamentoNome[0];
               A70InformacaoNome = H007I2_A70InformacaoNome[0];
               E247I2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 126;
            WB7I0( ) ;
         }
         bGXsfl_126_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7I2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCDICIONARIODATAINCLUSAO", context.localUtil.DToC( AV8DocDicionarioDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCDICIONARIODATAINCLUSAO", GetSecureSignedToken( sPrefix, AV8DocDicionarioDataInclusao, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         /* Using cursor H007I3 */
         pr_default.execute(1, new Object[] {AV16DocumentoId});
         GRID1_nRecordCount = H007I3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRID1_nEOF == 1 )
         {
            GRID1_nFirstRecordOnPage = GRID1_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavDocdicionariosensivel_grid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariosensivel_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariosensivel_grid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavDocdicionariopodeeliminar_grid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariopodeeliminar_grid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariopodeeliminar_grid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavDocdicionariotransfintergrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotransfintergrid_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavAtualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavExcluir_Enabled = 0;
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavTotaldados_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotaldados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaldados_Enabled), 5, 0), true);
         edtavTotaldadossensiveis_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotaldadossensiveis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaldadossensiveis_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E227I2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV41DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPAISID_DATA"), AV80PaisId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOMPARTTERCEXTERNOID_DATA"), AV38CompartTercExternoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPAISID"), AV21PaisId);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOMPARTTERCEXTERNOID"), AV6CompartTercExternoId);
            /* Read saved values. */
            nRC_GXsfl_126 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_126"), ",", "."));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV16DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16DocumentoId"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nEOF"), ",", "."));
            subGrid1_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Combo_paisid_Cls = cgiGet( sPrefix+"COMBO_PAISID_Cls");
            Combo_paisid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_PAISID_Selectedvalue_set");
            Combo_paisid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_PAISID_Enabled"));
            Combo_paisid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_PAISID_Allowmultipleselection"));
            Combo_paisid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_PAISID_Includeonlyselectedoption"));
            Combo_paisid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_PAISID_Emptyitem"));
            Combo_paisid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_PAISID_Multiplevaluestype");
            Combo_comparttercexternoid_Cls = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Cls");
            Combo_comparttercexternoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_set");
            Combo_comparttercexternoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Enabled"));
            Combo_comparttercexternoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Allowmultipleselection"));
            Combo_comparttercexternoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Includeonlyselectedoption"));
            Combo_comparttercexternoid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Multiplevaluestype");
            Combo_comparttercexternoid_Emptyitemtext = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Emptyitemtext");
            Grid1_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID1_EMPOWERER_Gridinternalname");
            Grid1_empowerer_Infinitescrolling = cgiGet( sPrefix+"GRID1_EMPOWERER_Infinitescrolling");
            Combo_paisid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_PAISID_Selectedvalue_get");
            Combo_comparttercexternoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_get");
            Combo_comparttercexternoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Selectedvalue_get");
            Combo_paisid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_PAISID_Selectedvalue_get");
            Combo_paisid_Ddointernalname = cgiGet( sPrefix+"COMBO_PAISID_Ddointernalname");
            Combo_comparttercexternoid_Ddointernalname = cgiGet( sPrefix+"COMBO_COMPARTTERCEXTERNOID_Ddointernalname");
            /* Read variables values. */
            cmbavInformacaoid.Name = cmbavInformacaoid_Internalname;
            cmbavInformacaoid.CurrentValue = cgiGet( cmbavInformacaoid_Internalname);
            AV18InformacaoId = (int)(NumberUtil.Val( cgiGet( cmbavInformacaoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV18InformacaoId", StringUtil.LTrimStr( (decimal)(AV18InformacaoId), 8, 0));
            AV11DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkavDocdicionariopodeeliminar_Internalname));
            AssignAttri(sPrefix, false, "AV11DocDicionarioPodeEliminar", AV11DocDicionarioPodeEliminar);
            AV12DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkavDocdicionariosensivel_Internalname));
            AssignAttri(sPrefix, false, "AV12DocDicionarioSensivel", AV12DocDicionarioSensivel);
            cmbavHipotesetratamentoid.Name = cmbavHipotesetratamentoid_Internalname;
            cmbavHipotesetratamentoid.CurrentValue = cgiGet( cmbavHipotesetratamentoid_Internalname);
            AV17HipoteseTratamentoId = (int)(NumberUtil.Val( cgiGet( cmbavHipotesetratamentoid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV17HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV17HipoteseTratamentoId), 8, 0));
            cmbavDocdicionariotransfinter.Name = cmbavDocdicionariotransfinter_Internalname;
            cmbavDocdicionariotransfinter.CurrentValue = cgiGet( cmbavDocdicionariotransfinter_Internalname);
            AV13DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( cmbavDocdicionariotransfinter_Internalname));
            AssignAttri(sPrefix, false, "AV13DocDicionarioTransfInter", AV13DocDicionarioTransfInter);
            AV51DocDicionarioTipoTransfInterGarantia = cgiGet( edtavDocdicionariotipotransfintergarantia_Internalname);
            AssignAttri(sPrefix, false, "AV51DocDicionarioTipoTransfInterGarantia", AV51DocDicionarioTipoTransfInterGarantia);
            AV9DocDicionarioFinalidade = cgiGet( edtavDocdicionariofinalidade_Internalname);
            AssignAttri(sPrefix, false, "AV9DocDicionarioFinalidade", AV9DocDicionarioFinalidade);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotaldados_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotaldados_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALDADOS");
               GX_FocusControl = edtavTotaldados_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV67TotalDados = 0;
               AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
            }
            else
            {
               AV67TotalDados = (short)(context.localUtil.CToN( cgiGet( edtavTotaldados_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotaldadossensiveis_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotaldadossensiveis_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALDADOSSENSIVEIS");
               GX_FocusControl = edtavTotaldadossensiveis_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV68TotalDadosSensiveis = 0;
               AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
            }
            else
            {
               AV68TotalDadosSensiveis = (short)(context.localUtil.CToN( cgiGet( edtavTotaldadossensiveis_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocdicionarioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocdicionarioid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCDICIONARIOID");
               GX_FocusControl = edtavDocdicionarioid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10DocDicionarioId = 0;
               AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
            }
            else
            {
               AV10DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtavDocdicionarioid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
            }
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
         E227I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E227I2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV41DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV41DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         /* Execute user subroutine: 'LOADCOMBOPAISID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCOMPARTTERCEXTERNOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavDocumentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Visible), 5, 0), true);
         edtavDocdicionarioid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocdicionarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocdicionarioid_Visible), 5, 0), true);
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, sPrefix, false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV67TotalDados = 0;
         AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
         AV68TotalDadosSensiveis = 0;
         AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            cmbavInformacaoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavInformacaoid.Enabled), 5, 0), true);
            chkavDocdicionariopodeeliminar.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocdicionariopodeeliminar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocdicionariopodeeliminar.Enabled), 5, 0), true);
            chkavDocdicionariosensivel.Enabled = 0;
            AssignProp(sPrefix, false, chkavDocdicionariosensivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocdicionariosensivel.Enabled), 5, 0), true);
            cmbavHipotesetratamentoid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHipotesetratamentoid.Enabled), 5, 0), true);
            cmbavDocdicionariotransfinter.Enabled = 0;
            AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocdicionariotransfinter.Enabled), 5, 0), true);
            edtavDocdicionariotipotransfintergarantia_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            edtavDocdicionariofinalidade_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocdicionariofinalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariofinalidade_Enabled), 5, 0), true);
            Combo_comparttercexternoid_Enabled = false;
            ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_comparttercexternoid_Enabled));
            Combo_paisid_Enabled = false;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            bttBtnadicionar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Visible), 5, 0), true);
            lblInformacaoadd_Visible = 0;
            AssignProp(sPrefix, false, lblInformacaoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblInformacaoadd_Visible), 5, 0), true);
            lblSensivelinfo_Visible = 0;
            AssignProp(sPrefix, false, lblSensivelinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSensivelinfo_Visible), 5, 0), true);
            lblHipoteseadd_Visible = 0;
            AssignProp(sPrefix, false, lblHipoteseadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblHipoteseadd_Visible), 5, 0), true);
            lblTransfinterinfo_Visible = 0;
            AssignProp(sPrefix, false, lblTransfinterinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTransfinterinfo_Visible), 5, 0), true);
            lblPaisadd_Visible = 0;
            AssignProp(sPrefix, false, lblPaisadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaisadd_Visible), 5, 0), true);
            lblTipotransfintergarantia_Visible = 0;
            AssignProp(sPrefix, false, lblTipotransfintergarantia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTipotransfintergarantia_Visible), 5, 0), true);
            lblComparttercexteradd_Visible = 0;
            AssignProp(sPrefix, false, lblComparttercexteradd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblComparttercexteradd_Visible), 5, 0), true);
            lblFinalidadeinfo_Visible = 0;
            AssignProp(sPrefix, false, lblFinalidadeinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFinalidadeinfo_Visible), 5, 0), true);
            edtavAtualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_126_Refreshing);
            edtavExcluir_Visible = 0;
            AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_126_Refreshing);
         }
         lblTxttipotransfinter_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV51DocDicionarioTipoTransfInterGarantia)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Caption", lblTxttipotransfinter_Caption, true);
         lblTextblock1_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV9DocDicionarioFinalidade)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         /* Execute user subroutine: 'INFORMACAOCOMBOCARREGA' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIPOTESETRATAMENTOCOMBOCARREGA' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Using cursor H007I4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A135CampoId = H007I4_A135CampoId[0];
            A139TooltipTelaId = H007I4_A139TooltipTelaId[0];
            A140TooltipTelaNome = H007I4_A140TooltipTelaNome[0];
            A118TooltipAtivo = H007I4_A118TooltipAtivo[0];
            A136CampoNome = H007I4_A136CampoNome[0];
            A115TooltipDescricao = H007I4_A115TooltipDescricao[0];
            A136CampoNome = H007I4_A136CampoNome[0];
            A140TooltipTelaNome = H007I4_A140TooltipTelaNome[0];
            if ( StringUtil.StrCmp(A136CampoNome, "INFORMAÇÃO") == 0 )
            {
               lblInformacaoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblInformacaoinfo_Internalname, "Tooltiptext", lblInformacaoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "PODE ELIMINAR") == 0 )
            {
               lblPodeeliminarinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblPodeeliminarinfo_Internalname, "Tooltiptext", lblPodeeliminarinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "POSSUI DADOS SENSÍVEIS") == 0 )
            {
               lblSensivelinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblSensivelinfo_Internalname, "Tooltiptext", lblSensivelinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "HIPÓTESE DE TRATAMENTO") == 0 )
            {
               lblHipoteseinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblHipoteseinfo_Internalname, "Tooltiptext", lblHipoteseinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "TRANSFERÊNCIA INTERNACIONAL") == 0 )
            {
               lblTransfinterinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblTransfinterinfo_Internalname, "Tooltiptext", lblTransfinterinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "PAÍS") == 0 )
            {
               lblPaisinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblPaisinfo_Internalname, "Tooltiptext", lblPaisinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "TIPO DE GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL") == 0 )
            {
               lblTipotransfintergarantia_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblTipotransfintergarantia_Internalname, "Tooltiptext", lblTipotransfintergarantia_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "COMPARTILHAMENTO TERCEIROS/EXTERNOS") == 0 )
            {
               lblComparttercexternoinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblComparttercexternoinfo_Internalname, "Tooltiptext", lblComparttercexternoinfo_Tooltiptext, true);
            }
            else if ( StringUtil.StrCmp(A136CampoNome, "FINALIDADE") == 0 )
            {
               lblFinalidadeinfo_Tooltiptext = A115TooltipDescricao;
               AssignProp(sPrefix, false, lblFinalidadeinfo_Internalname, "Tooltiptext", lblFinalidadeinfo_Tooltiptext, true);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV13DocDicionarioTransfInter )
         {
            Combo_paisid_Enabled = true;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            edtavDocdicionariotipotransfintergarantia_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            lblTxttipotransfinter_Visible = 1;
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxttipotransfinter_Visible), 5, 0), true);
         }
         else
         {
            edtavDocdicionariotipotransfintergarantia_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            AV51DocDicionarioTipoTransfInterGarantia = "";
            AssignAttri(sPrefix, false, "AV51DocDicionarioTipoTransfInterGarantia", AV51DocDicionarioTipoTransfInterGarantia);
            Combo_paisid_Enabled = false;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            AV79PaisId_Col.Clear();
            Combo_paisid_Selectedvalue_set = AV79PaisId_Col.ToJSonString(false);
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
            lblTxttipotransfinter_Visible = 0;
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxttipotransfinter_Visible), 5, 0), true);
         }
      }

      protected void E237I2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         if ( AV56IsInformacao )
         {
            /* Execute user subroutine: 'INFORMACAOCOMBOCARREGA' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV18InformacaoId = AV57InformacaoId_Out;
            AssignAttri(sPrefix, false, "AV18InformacaoId", StringUtil.LTrimStr( (decimal)(AV18InformacaoId), 8, 0));
            AV56IsInformacao = false;
            AssignAttri(sPrefix, false, "AV56IsInformacao", AV56IsInformacao);
            AV57InformacaoId_Out = 0;
            AssignAttri(sPrefix, false, "AV57InformacaoId_Out", StringUtil.LTrimStr( (decimal)(AV57InformacaoId_Out), 4, 0));
         }
         if ( AV59IsHipotese )
         {
            /* Execute user subroutine: 'HIPOTESETRATAMENTOCOMBOCARREGA' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV17HipoteseTratamentoId = AV58HipoteseTratamentoId_Out;
            AssignAttri(sPrefix, false, "AV17HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV17HipoteseTratamentoId), 8, 0));
            AV59IsHipotese = false;
            AssignAttri(sPrefix, false, "AV59IsHipotese", AV59IsHipotese);
            AV58HipoteseTratamentoId_Out = 0;
            AssignAttri(sPrefix, false, "AV58HipoteseTratamentoId_Out", StringUtil.LTrimStr( (decimal)(AV58HipoteseTratamentoId_Out), 8, 0));
         }
         if ( AV60IsPais )
         {
            AV21PaisId.FromJSonString(Combo_paisid_Selectedvalue_get, null);
            /* Execute user subroutine: 'LOADCOMBOPAISID' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV79PaisId_Col.Add(AV61PaisId_Out, 0);
            Combo_paisid_Selectedvalue_set = AV79PaisId_Col.ToJSonString(false);
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
            AV60IsPais = false;
            AssignAttri(sPrefix, false, "AV60IsPais", AV60IsPais);
            AV61PaisId_Out = 0;
            AssignAttri(sPrefix, false, "AV61PaisId_Out", StringUtil.LTrimStr( (decimal)(AV61PaisId_Out), 8, 0));
            AV79PaisId_Col.Clear();
         }
         if ( AV62IsCompartTercExterno )
         {
            AV6CompartTercExternoId.FromJSonString(Combo_comparttercexternoid_Selectedvalue_get, null);
            /* Execute user subroutine: 'LOADCOMBOCOMPARTTERCEXTERNOID' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV64CompartTercExternoId_Col.Add(AV63CompartTercExternoId_Out, 0);
            Combo_comparttercexternoid_Selectedvalue_set = AV64CompartTercExternoId_Col.ToJSonString(false);
            ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "SelectedValue_set", Combo_comparttercexternoid_Selectedvalue_set);
            AV62IsCompartTercExterno = false;
            AssignAttri(sPrefix, false, "AV62IsCompartTercExterno", AV62IsCompartTercExterno);
            AV63CompartTercExternoId_Out = 0;
            AssignAttri(sPrefix, false, "AV63CompartTercExternoId_Out", StringUtil.LTrimStr( (decimal)(AV63CompartTercExternoId_Out), 8, 0));
            AV64CompartTercExternoId_Col.Clear();
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      private void E247I2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV43DocDicionarioTransfInterGrid = "";
         AssignAttri(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, AV43DocDicionarioTransfInterGrid);
         if ( A101DocDicionarioTransfInter )
         {
            AV43DocDicionarioTransfInterGrid = "SIM";
            AssignAttri(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, AV43DocDicionarioTransfInterGrid);
         }
         else
         {
            AV43DocDicionarioTransfInterGrid = "NÃO";
            AssignAttri(sPrefix, false, edtavDocdicionariotransfintergrid_Internalname, AV43DocDicionarioTransfInterGrid);
         }
         AV50Visualizar = "<i class=\"fas fa-magnifying-glass\"></i>";
         AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV50Visualizar);
         AV35Atualizar = "<i class=\"fas fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavAtualizar_Internalname, AV35Atualizar);
         AV44Excluir = "<i class=\"fas fa-x\"></i>";
         AssignAttri(sPrefix, false, edtavExcluir_Internalname, AV44Excluir);
         if ( A99DocDicionarioSensivel )
         {
            AV65DocDicionarioSensivel_Grid = "SIM";
            AssignAttri(sPrefix, false, edtavDocdicionariosensivel_grid_Internalname, AV65DocDicionarioSensivel_Grid);
            AV68TotalDadosSensiveis = (short)(AV68TotalDadosSensiveis+1);
            AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
         }
         else
         {
            AV65DocDicionarioSensivel_Grid = "NÃO";
            AssignAttri(sPrefix, false, edtavDocdicionariosensivel_grid_Internalname, AV65DocDicionarioSensivel_Grid);
         }
         if ( A100DocDicionarioPodeEliminar )
         {
            AV66DocDicionarioPodeEliminar_Grid = "SIM";
            AssignAttri(sPrefix, false, edtavDocdicionariopodeeliminar_grid_Internalname, AV66DocDicionarioPodeEliminar_Grid);
         }
         else
         {
            AV66DocDicionarioPodeEliminar_Grid = "NÃO";
            AssignAttri(sPrefix, false, edtavDocdicionariopodeeliminar_grid_Internalname, AV66DocDicionarioPodeEliminar_Grid);
         }
         AV67TotalDados = (short)(AV67TotalDados+1);
         AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 126;
         }
         sendrow_1262( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_126_Refreshing )
         {
            context.DoAjaxLoad(126, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E167I2( )
      {
         /* 'DoHipoteseAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "hipotesetratamento.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("hipotesetratamento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV59IsHipotese","AV58HipoteseTratamentoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      protected void E177I2( )
      {
         /* 'DoPaisAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "pais.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("pais.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV60IsPais","AV61PaisId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      protected void E187I2( )
      {
         /* 'DoCompartTercExterAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comparttercexterno.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("comparttercexterno.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV62IsCompartTercExterno","AV63CompartTercExternoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      protected void E197I2( )
      {
         /* 'DoAdicionar' Routine */
         returnInSub = false;
         if ( AV78isDisplay )
         {
            cmbavInformacaoid.Enabled = 1;
            AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavInformacaoid.Enabled), 5, 0), true);
            chkavDocdicionariopodeeliminar.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocdicionariopodeeliminar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocdicionariopodeeliminar.Enabled), 5, 0), true);
            chkavDocdicionariosensivel.Enabled = 1;
            AssignProp(sPrefix, false, chkavDocdicionariosensivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocdicionariosensivel.Enabled), 5, 0), true);
            cmbavHipotesetratamentoid.Enabled = 1;
            AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHipotesetratamentoid.Enabled), 5, 0), true);
            cmbavDocdicionariotransfinter.Enabled = 1;
            AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocdicionariotransfinter.Enabled), 5, 0), true);
            edtavDocdicionariotipotransfintergarantia_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            edtavDocdicionariofinalidade_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocdicionariofinalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariofinalidade_Enabled), 5, 0), true);
            Combo_comparttercexternoid_Enabled = true;
            ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_comparttercexternoid_Enabled));
            Combo_paisid_Enabled = true;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            bttBtnadicionar_Caption = "ADICIONAR";
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
            AV78isDisplay = false;
            AssignAttri(sPrefix, false, "AV78isDisplay", AV78isDisplay);
            /* Execute user subroutine: 'LIMPACAMPOS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV54CheckRequiredFieldsResult )
            {
               if ( (0==AV10DocDicionarioId) )
               {
                  /* Execute user subroutine: 'VALIDAINFORMACAO' */
                  S192 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
                  if ( AV77InformacaoExiste )
                  {
                     GX_msglist.addItem("Essa informação já foi registrada para esse documento.");
                  }
                  else
                  {
                     AV7DocDicionario = new SdtDocDicionario(context);
                     AV7DocDicionario.gxTpr_Informacaoid = AV18InformacaoId;
                     AV7DocDicionario.gxTpr_Docdicionariopodeeliminar = AV11DocDicionarioPodeEliminar;
                     AV7DocDicionario.gxTpr_Docdicionariosensivel = AV12DocDicionarioSensivel;
                     AV7DocDicionario.gxTpr_Hipotesetratamentoid = AV17HipoteseTratamentoId;
                     AV7DocDicionario.gxTpr_Docdicionariotransfinter = AV13DocDicionarioTransfInter;
                     AV7DocDicionario.gxTpr_Docdicionariotipotransfintergarantia = AV51DocDicionarioTipoTransfInterGarantia;
                     AV7DocDicionario.gxTpr_Docdicionariodatainclusao = AV8DocDicionarioDataInclusao;
                     AV7DocDicionario.gxTpr_Docdicionariofinalidade = AV9DocDicionarioFinalidade;
                     AV7DocDicionario.gxTpr_Documentoid = AV16DocumentoId;
                     AV7DocDicionario.Insert();
                     AV10DocDicionarioId = AV7DocDicionario.gxTpr_Docdicionarioid;
                     AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
                     if ( AV7DocDicionario.Success() )
                     {
                        context.CommitDataStores("dicionariowc",pr_default);
                        AV64CompartTercExternoId_Col.FromJSonString(Combo_comparttercexternoid_Selectedvalue_get, null);
                        AV86GXV1 = 1;
                        while ( AV86GXV1 <= AV64CompartTercExternoId_Col.Count )
                        {
                           AV39CompartTercExternoId_Item = (int)(AV64CompartTercExternoId_Col.GetNumeric(AV86GXV1));
                           AssignAttri(sPrefix, false, "AV39CompartTercExternoId_Item", StringUtil.LTrimStr( (decimal)(AV39CompartTercExternoId_Item), 8, 0));
                           AV87GXLvl376 = 0;
                           /* Using cursor H007I5 */
                           pr_default.execute(3, new Object[] {AV39CompartTercExternoId_Item, AV10DocDicionarioId});
                           while ( (pr_default.getStatus(3) != 101) )
                           {
                              A66CompartTercExternoId = H007I5_A66CompartTercExternoId[0];
                              A98DocDicionarioId = H007I5_A98DocDicionarioId[0];
                              AV87GXLvl376 = 1;
                              /* Exiting from a For First loop. */
                              if (true) break;
                           }
                           pr_default.close(3);
                           if ( AV87GXLvl376 == 0 )
                           {
                              new dicionariocomparttercextinsere(context ).execute(  AV10DocDicionarioId,  (short)(AV39CompartTercExternoId_Item)) ;
                           }
                           AV86GXV1 = (int)(AV86GXV1+1);
                        }
                        /* Using cursor H007I6 */
                        pr_default.execute(4, new Object[] {AV10DocDicionarioId});
                        while ( (pr_default.getStatus(4) != 101) )
                        {
                           A98DocDicionarioId = H007I6_A98DocDicionarioId[0];
                           A66CompartTercExternoId = H007I6_A66CompartTercExternoId[0];
                           if ( ! (AV64CompartTercExternoId_Col.IndexOf(A66CompartTercExternoId)>0) )
                           {
                              new dicionariocomparttercextexclui(context ).execute(  A98DocDicionarioId,  A66CompartTercExternoId) ;
                           }
                           pr_default.readNext(4);
                        }
                        pr_default.close(4);
                        AV79PaisId_Col.FromJSonString(Combo_paisid_Selectedvalue_get, null);
                        AV89GXV2 = 1;
                        while ( AV89GXV2 <= AV79PaisId_Col.Count )
                        {
                           AV81PaisId_Item = (int)(AV79PaisId_Col.GetNumeric(AV89GXV2));
                           AssignAttri(sPrefix, false, "AV81PaisId_Item", StringUtil.LTrimStr( (decimal)(AV81PaisId_Item), 8, 0));
                           AV90GXLvl398 = 0;
                           /* Using cursor H007I7 */
                           pr_default.execute(5, new Object[] {AV81PaisId_Item, AV10DocDicionarioId});
                           while ( (pr_default.getStatus(5) != 101) )
                           {
                              A4PaisId = H007I7_A4PaisId[0];
                              A98DocDicionarioId = H007I7_A98DocDicionarioId[0];
                              AV90GXLvl398 = 1;
                              /* Exiting from a For First loop. */
                              if (true) break;
                           }
                           pr_default.close(5);
                           if ( AV90GXLvl398 == 0 )
                           {
                              new dicionariopaisinsere(context ).execute(  AV10DocDicionarioId,  AV81PaisId_Item) ;
                           }
                           AV89GXV2 = (int)(AV89GXV2+1);
                        }
                        /* Using cursor H007I8 */
                        pr_default.execute(6, new Object[] {AV10DocDicionarioId});
                        while ( (pr_default.getStatus(6) != 101) )
                        {
                           A98DocDicionarioId = H007I8_A98DocDicionarioId[0];
                           A4PaisId = H007I8_A4PaisId[0];
                           if ( ! (AV79PaisId_Col.IndexOf(A4PaisId)>0) )
                           {
                              new dicionariopaisexclui(context ).execute(  A98DocDicionarioId,  A4PaisId) ;
                           }
                           pr_default.readNext(6);
                        }
                        pr_default.close(6);
                        /* Execute user subroutine: 'LIMPACAMPOS' */
                        S172 ();
                        if ( returnInSub )
                        {
                           returnInSub = true;
                           if (true) return;
                        }
                        bttBtnadicionar_Caption = "ADICIONAR";
                        AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
                     }
                     else
                     {
                        AV93GXV4 = 1;
                        AV92GXV3 = AV7DocDicionario.GetMessages();
                        while ( AV93GXV4 <= AV92GXV3.Count )
                        {
                           AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV92GXV3.Item(AV93GXV4));
                           GX_msglist.addItem(AV20Message.gxTpr_Description);
                           AV93GXV4 = (int)(AV93GXV4+1);
                        }
                     }
                  }
                  AV67TotalDados = 0;
                  AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
                  AV68TotalDadosSensiveis = 0;
                  AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
                  GRID1_nFirstRecordOnPage = 0;
                  GRID1_nCurrentRecord = 0;
                  GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_126_idx;
                  GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
                  gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
               }
               else
               {
                  AV7DocDicionario.gxTpr_Informacaoid = AV18InformacaoId;
                  AV7DocDicionario.gxTpr_Docdicionariopodeeliminar = AV11DocDicionarioPodeEliminar;
                  AV7DocDicionario.gxTpr_Docdicionariosensivel = AV12DocDicionarioSensivel;
                  AV7DocDicionario.gxTpr_Hipotesetratamentoid = AV17HipoteseTratamentoId;
                  AV7DocDicionario.gxTpr_Docdicionariotransfinter = AV13DocDicionarioTransfInter;
                  AV7DocDicionario.gxTpr_Docdicionariotipotransfintergarantia = AV51DocDicionarioTipoTransfInterGarantia;
                  AV7DocDicionario.gxTpr_Docdicionariofinalidade = AV9DocDicionarioFinalidade;
                  AV10DocDicionarioId = AV7DocDicionario.gxTpr_Docdicionarioid;
                  AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
                  AV7DocDicionario.Update();
                  if ( AV7DocDicionario.Success() )
                  {
                     context.CommitDataStores("dicionariowc",pr_default);
                     AV64CompartTercExternoId_Col.FromJSonString(Combo_comparttercexternoid_Selectedvalue_get, null);
                     AV94GXV5 = 1;
                     while ( AV94GXV5 <= AV64CompartTercExternoId_Col.Count )
                     {
                        AV39CompartTercExternoId_Item = (int)(AV64CompartTercExternoId_Col.GetNumeric(AV94GXV5));
                        AssignAttri(sPrefix, false, "AV39CompartTercExternoId_Item", StringUtil.LTrimStr( (decimal)(AV39CompartTercExternoId_Item), 8, 0));
                        AV95GXLvl450 = 0;
                        /* Using cursor H007I9 */
                        pr_default.execute(7, new Object[] {AV39CompartTercExternoId_Item, AV10DocDicionarioId});
                        while ( (pr_default.getStatus(7) != 101) )
                        {
                           A66CompartTercExternoId = H007I9_A66CompartTercExternoId[0];
                           A98DocDicionarioId = H007I9_A98DocDicionarioId[0];
                           AV95GXLvl450 = 1;
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(7);
                        if ( AV95GXLvl450 == 0 )
                        {
                           new dicionariocomparttercextinsere(context ).execute(  AV10DocDicionarioId,  (short)(AV39CompartTercExternoId_Item)) ;
                        }
                        AV94GXV5 = (int)(AV94GXV5+1);
                     }
                     /* Using cursor H007I10 */
                     pr_default.execute(8, new Object[] {AV10DocDicionarioId});
                     while ( (pr_default.getStatus(8) != 101) )
                     {
                        A98DocDicionarioId = H007I10_A98DocDicionarioId[0];
                        A66CompartTercExternoId = H007I10_A66CompartTercExternoId[0];
                        if ( ! (AV64CompartTercExternoId_Col.IndexOf(A66CompartTercExternoId)>0) )
                        {
                           new dicionariocomparttercextexclui(context ).execute(  A98DocDicionarioId,  A66CompartTercExternoId) ;
                        }
                        pr_default.readNext(8);
                     }
                     pr_default.close(8);
                     AV79PaisId_Col.FromJSonString(Combo_paisid_Selectedvalue_get, null);
                     AV97GXV6 = 1;
                     while ( AV97GXV6 <= AV79PaisId_Col.Count )
                     {
                        AV81PaisId_Item = (int)(AV79PaisId_Col.GetNumeric(AV97GXV6));
                        AssignAttri(sPrefix, false, "AV81PaisId_Item", StringUtil.LTrimStr( (decimal)(AV81PaisId_Item), 8, 0));
                        AV98GXLvl472 = 0;
                        /* Using cursor H007I11 */
                        pr_default.execute(9, new Object[] {AV81PaisId_Item, AV10DocDicionarioId});
                        while ( (pr_default.getStatus(9) != 101) )
                        {
                           A4PaisId = H007I11_A4PaisId[0];
                           A98DocDicionarioId = H007I11_A98DocDicionarioId[0];
                           AV98GXLvl472 = 1;
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(9);
                        if ( AV98GXLvl472 == 0 )
                        {
                           new dicionariopaisinsere(context ).execute(  AV10DocDicionarioId,  AV81PaisId_Item) ;
                        }
                        AV97GXV6 = (int)(AV97GXV6+1);
                     }
                     /* Using cursor H007I12 */
                     pr_default.execute(10, new Object[] {AV10DocDicionarioId});
                     while ( (pr_default.getStatus(10) != 101) )
                     {
                        A98DocDicionarioId = H007I12_A98DocDicionarioId[0];
                        A4PaisId = H007I12_A4PaisId[0];
                        if ( ! (AV79PaisId_Col.IndexOf(A4PaisId)>0) )
                        {
                           new dicionariopaisexclui(context ).execute(  A98DocDicionarioId,  A4PaisId) ;
                        }
                        pr_default.readNext(10);
                     }
                     pr_default.close(10);
                     /* Execute user subroutine: 'LIMPACAMPOS' */
                     S172 ();
                     if ( returnInSub )
                     {
                        returnInSub = true;
                        if (true) return;
                     }
                     bttBtnadicionar_Caption = "ADICIONAR";
                     AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
                  }
                  else
                  {
                     AV101GXV8 = 1;
                     AV100GXV7 = AV7DocDicionario.GetMessages();
                     while ( AV101GXV8 <= AV100GXV7.Count )
                     {
                        AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV100GXV7.Item(AV101GXV8));
                        GX_msglist.addItem(AV20Message.gxTpr_Description);
                        AV101GXV8 = (int)(AV101GXV8+1);
                     }
                  }
                  AV67TotalDados = 0;
                  AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
                  AV68TotalDadosSensiveis = 0;
                  AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
                  GRID1_nFirstRecordOnPage = 0;
                  GRID1_nCurrentRecord = 0;
                  GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_126_idx;
                  GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
                  gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
               }
            }
            else
            {
               GX_msglist.addItem("Revise os campos obrigatórios");
            }
         }
         lblTxttipotransfinter_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV51DocDicionarioTipoTransfInterGarantia)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Caption", lblTxttipotransfinter_Caption, true);
         lblTextblock1_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV9DocDicionarioFinalidade)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7DocDicionario", AV7DocDicionario);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      protected void E207I2( )
      {
         /* 'DoInformacaoAdd' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "informacao.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("informacao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV56IsInformacao","AV57InformacaoId_Out"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV69IsAuthorized_Visualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioVisualiza", out  GXt_boolean2) ;
         AV69IsAuthorized_Visualizar = GXt_boolean2;
         if ( ! ( AV69IsAuthorized_Visualizar ) )
         {
            edtavVisualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Visible), 5, 0), !bGXsfl_126_Refreshing);
         }
         GXt_boolean2 = AV70IsAuthorized_Atualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioAtualiza", out  GXt_boolean2) ;
         AV70IsAuthorized_Atualizar = GXt_boolean2;
         if ( ! ( AV70IsAuthorized_Atualizar ) )
         {
            edtavAtualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_126_Refreshing);
         }
         GXt_boolean2 = AV71IsAuthorized_Excluir;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioExclui", out  GXt_boolean2) ;
         AV71IsAuthorized_Excluir = GXt_boolean2;
         if ( ! ( AV71IsAuthorized_Excluir ) )
         {
            edtavExcluir_Visible = 0;
            AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_126_Refreshing);
         }
         GXt_boolean2 = AV72IsAuthorized_HipoteseAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioHipoteseAdd", out  GXt_boolean2) ;
         AV72IsAuthorized_HipoteseAdd = GXt_boolean2;
         if ( ! ( AV72IsAuthorized_HipoteseAdd ) )
         {
            lblHipoteseadd_Visible = 0;
            AssignProp(sPrefix, false, lblHipoteseadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblHipoteseadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV73IsAuthorized_PaisAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioPaisAdd", out  GXt_boolean2) ;
         AV73IsAuthorized_PaisAdd = GXt_boolean2;
         if ( ! ( AV73IsAuthorized_PaisAdd ) )
         {
            lblPaisadd_Visible = 0;
            AssignProp(sPrefix, false, lblPaisadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaisadd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV74IsAuthorized_CompartTercExterAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioCompartilhamentoTercAdd", out  GXt_boolean2) ;
         AV74IsAuthorized_CompartTercExterAdd = GXt_boolean2;
         if ( ! ( AV74IsAuthorized_CompartTercExterAdd ) )
         {
            lblComparttercexteradd_Visible = 0;
            AssignProp(sPrefix, false, lblComparttercexteradd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblComparttercexteradd_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV75IsAuthorized_Adicionar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioAdd", out  GXt_boolean2) ;
         AV75IsAuthorized_Adicionar = GXt_boolean2;
         if ( ! ( AV75IsAuthorized_Adicionar ) )
         {
            bttBtnadicionar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadicionar_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV76IsAuthorized_InformacaoAdd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaDicioInformacaoAdd", out  GXt_boolean2) ;
         AV76IsAuthorized_InformacaoAdd = GXt_boolean2;
         if ( ! ( AV76IsAuthorized_InformacaoAdd ) )
         {
            lblInformacaoadd_Visible = 0;
            AssignProp(sPrefix, false, lblInformacaoadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblInformacaoadd_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV54CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         if ( (0==AV18InformacaoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavInformacaoid_Internalname,  "true",  ""));
            AV54CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         }
         if ( (0==AV17HipoteseTratamentoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  cmbavHipotesetratamentoid_Internalname,  "true",  ""));
            AV54CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         }
         if ( ( ( AV13DocDicionarioTransfInter ) ) && ( AV21PaisId.Count == 0 ) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  Combo_paisid_Ddointernalname,  "true",  ""));
            AV54CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         }
         if ( ( ( AV13DocDicionarioTransfInter ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV51DocDicionarioTipoTransfInterGarantia)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  edtavDocdicionariotipotransfintergarantia_Internalname,  "true",  ""));
            AV54CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         }
         if ( AV6CompartTercExternoId.Count == 0 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  Combo_comparttercexternoid_Ddointernalname,  "true",  ""));
            AV54CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DocDicionarioFinalidade)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  edtavDocdicionariofinalidade_Internalname,  "true",  ""));
            AV54CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV54CheckRequiredFieldsResult", AV54CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV13DocDicionarioTransfInter )
         {
            divCombo_paisid_cell_Class = "col-xs-5 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
            AssignProp(sPrefix, false, divCombo_paisid_cell_Internalname, "Class", divCombo_paisid_cell_Class, true);
         }
         else
         {
            divCombo_paisid_cell_Class = "col-xs-5 DataContentCellFL ExtendedComboCell";
            AssignProp(sPrefix, false, divCombo_paisid_cell_Internalname, "Class", divCombo_paisid_cell_Class, true);
         }
         if ( AV13DocDicionarioTransfInter )
         {
            divDocdicionariotipotransfintergarantia_cell_Class = "col-xs-11 DataContentCellFL RequiredDataContentCellFL";
            AssignProp(sPrefix, false, divDocdicionariotipotransfintergarantia_cell_Internalname, "Class", divDocdicionariotipotransfintergarantia_cell_Class, true);
         }
         else
         {
            divDocdicionariotipotransfintergarantia_cell_Class = "col-xs-11";
            AssignProp(sPrefix, false, divDocdicionariotipotransfintergarantia_cell_Internalname, "Class", divDocdicionariotipotransfintergarantia_cell_Class, true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCOMPARTTERCEXTERNOID' Routine */
         returnInSub = false;
         AV64CompartTercExternoId_Col.Clear();
         AV102GXV9 = 1;
         while ( AV102GXV9 <= AV6CompartTercExternoId.Count )
         {
            AV39CompartTercExternoId_Item = (int)(AV6CompartTercExternoId.GetNumeric(AV102GXV9));
            AssignAttri(sPrefix, false, "AV39CompartTercExternoId_Item", StringUtil.LTrimStr( (decimal)(AV39CompartTercExternoId_Item), 8, 0));
            AV64CompartTercExternoId_Col.Add(AV39CompartTercExternoId_Item, 0);
            AV102GXV9 = (int)(AV102GXV9+1);
         }
         AV38CompartTercExternoId_Data.Clear();
         /* Using cursor H007I13 */
         pr_default.execute(11);
         while ( (pr_default.getStatus(11) != 101) )
         {
            A68CompartTercExternoAtivo = H007I13_A68CompartTercExternoAtivo[0];
            A66CompartTercExternoId = H007I13_A66CompartTercExternoId[0];
            A67CompartTercExternoNome = H007I13_A67CompartTercExternoNome[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A66CompartTercExternoId), 8, 0));
            AV36Combo_DataItem.gxTpr_Title = A67CompartTercExternoNome;
            AV38CompartTercExternoId_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(11);
         }
         pr_default.close(11);
         Combo_comparttercexternoid_Selectedvalue_set = AV6CompartTercExternoId.ToJSonString(false);
         ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "SelectedValue_set", Combo_comparttercexternoid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPAISID' Routine */
         returnInSub = false;
         AV79PaisId_Col.Clear();
         AV104GXV10 = 1;
         while ( AV104GXV10 <= AV21PaisId.Count )
         {
            AV81PaisId_Item = (int)(AV21PaisId.GetNumeric(AV104GXV10));
            AssignAttri(sPrefix, false, "AV81PaisId_Item", StringUtil.LTrimStr( (decimal)(AV81PaisId_Item), 8, 0));
            AV79PaisId_Col.Add(AV81PaisId_Item, 0);
            AV104GXV10 = (int)(AV104GXV10+1);
         }
         AV80PaisId_Data.Clear();
         /* Using cursor H007I14 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            A6PaisAtivo = H007I14_A6PaisAtivo[0];
            A4PaisId = H007I14_A4PaisId[0];
            A5PaisNome = H007I14_A5PaisNome[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A4PaisId), 8, 0));
            AV36Combo_DataItem.gxTpr_Title = A5PaisNome;
            AV80PaisId_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(12);
         }
         pr_default.close(12);
         Combo_paisid_Selectedvalue_set = AV21PaisId.ToJSonString(false);
         ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
      }

      protected void E217I2( )
      {
         /* Docdicionariotransfinter_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV13DocDicionarioTransfInter )
         {
            Combo_paisid_Enabled = true;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            edtavDocdicionariotipotransfintergarantia_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            lblTxttipotransfinter_Visible = 1;
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxttipotransfinter_Visible), 5, 0), true);
         }
         else
         {
            edtavDocdicionariotipotransfintergarantia_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            AV51DocDicionarioTipoTransfInterGarantia = "";
            AssignAttri(sPrefix, false, "AV51DocDicionarioTipoTransfInterGarantia", AV51DocDicionarioTipoTransfInterGarantia);
            lblTxttipotransfinter_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV51DocDicionarioTipoTransfInterGarantia)), 10, 0))+"/10000";
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Caption", lblTxttipotransfinter_Caption, true);
            Combo_paisid_Enabled = false;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            AV79PaisId_Col.Clear();
            Combo_paisid_Selectedvalue_set = AV79PaisId_Col.ToJSonString(false);
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
            lblTxttipotransfinter_Visible = 0;
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxttipotransfinter_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
      }

      protected void E257I2( )
      {
         /* Atualizar_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CARREGADADOS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         bttBtnadicionar_Caption = "ATUALIZAR";
         AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
         lblTextblock1_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV9DocDicionarioFinalidade)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         lblTxttipotransfinter_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV51DocDicionarioTipoTransfInterGarantia)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Caption", lblTxttipotransfinter_Caption, true);
         lblTxttipotransfinter_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV51DocDicionarioTipoTransfInterGarantia)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Caption", lblTxttipotransfinter_Caption, true);
         lblTextblock1_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV9DocDicionarioFinalidade)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7DocDicionario", AV7DocDicionario);
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV13DocDicionarioTransfInter);
         AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Values", cmbavDocdicionariotransfinter.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
      }

      protected void E267I2( )
      {
         /* Excluir_Click Routine */
         returnInSub = false;
         AV10DocDicionarioId = A98DocDicionarioId;
         AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
         /* Using cursor H007I15 */
         pr_default.execute(13, new Object[] {AV10DocDicionarioId});
         while ( (pr_default.getStatus(13) != 101) )
         {
            A98DocDicionarioId = H007I15_A98DocDicionarioId[0];
            A66CompartTercExternoId = H007I15_A66CompartTercExternoId[0];
            new dicionariocomparttercextexclui(context ).execute(  A98DocDicionarioId,  A66CompartTercExternoId) ;
            pr_default.readNext(13);
         }
         pr_default.close(13);
         /* Using cursor H007I16 */
         pr_default.execute(14, new Object[] {AV10DocDicionarioId});
         while ( (pr_default.getStatus(14) != 101) )
         {
            A98DocDicionarioId = H007I16_A98DocDicionarioId[0];
            A4PaisId = H007I16_A4PaisId[0];
            new dicionariopaisexclui(context ).execute(  A98DocDicionarioId,  A4PaisId) ;
            pr_default.readNext(14);
         }
         pr_default.close(14);
         AV7DocDicionario.Load(A98DocDicionarioId);
         AV7DocDicionario.Delete();
         if ( AV7DocDicionario.Success() )
         {
            context.CommitDataStores("dicionariowc",pr_default);
            GRID1_nFirstRecordOnPage = 0;
            GRID1_nCurrentRecord = 0;
            GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_126_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            gxgrGrid1_refresh( subGrid1_Rows, AV16DocumentoId, AV56IsInformacao, AV57InformacaoId_Out, AV59IsHipotese, AV58HipoteseTratamentoId_Out, AV60IsPais, AV61PaisId_Out, AV79PaisId_Col, AV62IsCompartTercExterno, AV63CompartTercExternoId_Out, AV64CompartTercExternoId_Col, A71InformacaoAtivo, A74HipoteseTratamentoAtivo, AV21PaisId, A5PaisNome, A6PaisAtivo, A4PaisId, AV6CompartTercExternoId, A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId, AV68TotalDadosSensiveis, AV67TotalDados, AV11DocDicionarioPodeEliminar, AV12DocDicionarioSensivel, AV8DocDicionarioDataInclusao, sPrefix) ;
         }
         else
         {
            AV109GXV12 = 1;
            AV108GXV11 = AV7DocDicionario.GetMessages();
            while ( AV109GXV12 <= AV108GXV11.Count )
            {
               AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV108GXV11.Item(AV109GXV12));
               GX_msglist.addItem(AV20Message.gxTpr_Description);
               AV109GXV12 = (int)(AV109GXV12+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7DocDicionario", AV7DocDicionario);
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80PaisId_Data", AV80PaisId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38CompartTercExternoId_Data", AV38CompartTercExternoId_Data);
      }

      protected void E277I2( )
      {
         /* Visualizar_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CARREGADADOS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         cmbavInformacaoid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavInformacaoid.Enabled), 5, 0), true);
         chkavDocdicionariopodeeliminar.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocdicionariopodeeliminar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocdicionariopodeeliminar.Enabled), 5, 0), true);
         chkavDocdicionariosensivel.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocdicionariosensivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocdicionariosensivel.Enabled), 5, 0), true);
         cmbavHipotesetratamentoid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHipotesetratamentoid.Enabled), 5, 0), true);
         cmbavDocdicionariotransfinter.Enabled = 0;
         AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocdicionariotransfinter.Enabled), 5, 0), true);
         edtavDocdicionariotipotransfintergarantia_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
         edtavDocdicionariofinalidade_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocdicionariofinalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariofinalidade_Enabled), 5, 0), true);
         Combo_comparttercexternoid_Enabled = false;
         ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_comparttercexternoid_Enabled));
         bttBtnadicionar_Caption = "CONFIRMAR";
         AssignProp(sPrefix, false, bttBtnadicionar_Internalname, "Caption", bttBtnadicionar_Caption, true);
         AV78isDisplay = true;
         AssignAttri(sPrefix, false, "AV78isDisplay", AV78isDisplay);
         lblTxttipotransfinter_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(StringUtil.Len( AV51DocDicionarioTipoTransfInterGarantia)), 10, 0))+"/10000";
         AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Caption", lblTxttipotransfinter_Caption, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7DocDicionario", AV7DocDicionario);
         cmbavInformacaoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18InformacaoId), 8, 0));
         AssignProp(sPrefix, false, cmbavInformacaoid_Internalname, "Values", cmbavInformacaoid.ToJavascriptSource(), true);
         cmbavHipotesetratamentoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AssignProp(sPrefix, false, cmbavHipotesetratamentoid_Internalname, "Values", cmbavHipotesetratamentoid.ToJavascriptSource(), true);
         cmbavDocdicionariotransfinter.CurrentValue = StringUtil.BoolToStr( AV13DocDicionarioTransfInter);
         AssignProp(sPrefix, false, cmbavDocdicionariotransfinter_Internalname, "Values", cmbavDocdicionariotransfinter.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV64CompartTercExternoId_Col", AV64CompartTercExternoId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6CompartTercExternoId", AV6CompartTercExternoId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV79PaisId_Col", AV79PaisId_Col);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21PaisId", AV21PaisId);
      }

      protected void E287I2( )
      {
         /* Grid1_Refresh Routine */
         returnInSub = false;
         AV67TotalDados = 0;
         AssignAttri(sPrefix, false, "AV67TotalDados", StringUtil.LTrimStr( (decimal)(AV67TotalDados), 4, 0));
         AV68TotalDadosSensiveis = 0;
         AssignAttri(sPrefix, false, "AV68TotalDadosSensiveis", StringUtil.LTrimStr( (decimal)(AV68TotalDadosSensiveis), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'CARREGADADOS' Routine */
         returnInSub = false;
         AV7DocDicionario.Load(A98DocDicionarioId);
         AV10DocDicionarioId = A98DocDicionarioId;
         AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
         AV18InformacaoId = AV7DocDicionario.gxTpr_Informacaoid;
         AssignAttri(sPrefix, false, "AV18InformacaoId", StringUtil.LTrimStr( (decimal)(AV18InformacaoId), 8, 0));
         AV11DocDicionarioPodeEliminar = AV7DocDicionario.gxTpr_Docdicionariopodeeliminar;
         AssignAttri(sPrefix, false, "AV11DocDicionarioPodeEliminar", AV11DocDicionarioPodeEliminar);
         AV12DocDicionarioSensivel = AV7DocDicionario.gxTpr_Docdicionariosensivel;
         AssignAttri(sPrefix, false, "AV12DocDicionarioSensivel", AV12DocDicionarioSensivel);
         AV17HipoteseTratamentoId = AV7DocDicionario.gxTpr_Hipotesetratamentoid;
         AssignAttri(sPrefix, false, "AV17HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AV13DocDicionarioTransfInter = AV7DocDicionario.gxTpr_Docdicionariotransfinter;
         AssignAttri(sPrefix, false, "AV13DocDicionarioTransfInter", AV13DocDicionarioTransfInter);
         AV51DocDicionarioTipoTransfInterGarantia = AV7DocDicionario.gxTpr_Docdicionariotipotransfintergarantia;
         AssignAttri(sPrefix, false, "AV51DocDicionarioTipoTransfInterGarantia", AV51DocDicionarioTipoTransfInterGarantia);
         AV9DocDicionarioFinalidade = AV7DocDicionario.gxTpr_Docdicionariofinalidade;
         AssignAttri(sPrefix, false, "AV9DocDicionarioFinalidade", AV9DocDicionarioFinalidade);
         AV64CompartTercExternoId_Col.Clear();
         /* Using cursor H007I17 */
         pr_default.execute(15, new Object[] {AV7DocDicionario.gxTpr_Docdicionarioid});
         while ( (pr_default.getStatus(15) != 101) )
         {
            A98DocDicionarioId = H007I17_A98DocDicionarioId[0];
            A66CompartTercExternoId = H007I17_A66CompartTercExternoId[0];
            AV64CompartTercExternoId_Col.Add(A66CompartTercExternoId, 0);
            AV6CompartTercExternoId.Add(A66CompartTercExternoId, 0);
            pr_default.readNext(15);
         }
         pr_default.close(15);
         Combo_comparttercexternoid_Selectedvalue_set = AV64CompartTercExternoId_Col.ToJSonString(false);
         ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "SelectedValue_set", Combo_comparttercexternoid_Selectedvalue_set);
         AV79PaisId_Col.Clear();
         /* Using cursor H007I18 */
         pr_default.execute(16, new Object[] {AV7DocDicionario.gxTpr_Docdicionarioid});
         while ( (pr_default.getStatus(16) != 101) )
         {
            A98DocDicionarioId = H007I18_A98DocDicionarioId[0];
            A4PaisId = H007I18_A4PaisId[0];
            AV79PaisId_Col.Add(A4PaisId, 0);
            AV21PaisId.Add(A4PaisId, 0);
            pr_default.readNext(16);
         }
         pr_default.close(16);
         Combo_paisid_Selectedvalue_set = AV79PaisId_Col.ToJSonString(false);
         ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
         if ( AV13DocDicionarioTransfInter )
         {
            Combo_paisid_Enabled = true;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            edtavDocdicionariotipotransfintergarantia_Enabled = 1;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            lblTxttipotransfinter_Visible = 1;
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxttipotransfinter_Visible), 5, 0), true);
         }
         else
         {
            edtavDocdicionariotipotransfintergarantia_Enabled = 0;
            AssignProp(sPrefix, false, edtavDocdicionariotipotransfintergarantia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocdicionariotipotransfintergarantia_Enabled), 5, 0), true);
            AV51DocDicionarioTipoTransfInterGarantia = "";
            AssignAttri(sPrefix, false, "AV51DocDicionarioTipoTransfInterGarantia", AV51DocDicionarioTipoTransfInterGarantia);
            Combo_paisid_Enabled = false;
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
            AV79PaisId_Col.Clear();
            Combo_paisid_Selectedvalue_set = AV79PaisId_Col.ToJSonString(false);
            ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
            lblTxttipotransfinter_Visible = 0;
            AssignProp(sPrefix, false, lblTxttipotransfinter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxttipotransfinter_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'LIMPACAMPOS' Routine */
         returnInSub = false;
         AV18InformacaoId = 0;
         AssignAttri(sPrefix, false, "AV18InformacaoId", StringUtil.LTrimStr( (decimal)(AV18InformacaoId), 8, 0));
         AV11DocDicionarioPodeEliminar = false;
         AssignAttri(sPrefix, false, "AV11DocDicionarioPodeEliminar", AV11DocDicionarioPodeEliminar);
         AV12DocDicionarioSensivel = false;
         AssignAttri(sPrefix, false, "AV12DocDicionarioSensivel", AV12DocDicionarioSensivel);
         AV17HipoteseTratamentoId = 0;
         AssignAttri(sPrefix, false, "AV17HipoteseTratamentoId", StringUtil.LTrimStr( (decimal)(AV17HipoteseTratamentoId), 8, 0));
         AV51DocDicionarioTipoTransfInterGarantia = "";
         AssignAttri(sPrefix, false, "AV51DocDicionarioTipoTransfInterGarantia", AV51DocDicionarioTipoTransfInterGarantia);
         AV9DocDicionarioFinalidade = "";
         AssignAttri(sPrefix, false, "AV9DocDicionarioFinalidade", AV9DocDicionarioFinalidade);
         AV10DocDicionarioId = 0;
         AssignAttri(sPrefix, false, "AV10DocDicionarioId", StringUtil.LTrimStr( (decimal)(AV10DocDicionarioId), 8, 0));
         AV64CompartTercExternoId_Col.Clear();
         Combo_comparttercexternoid_Selectedvalue_set = AV64CompartTercExternoId_Col.ToJSonString(false);
         ucCombo_comparttercexternoid.SendProperty(context, sPrefix, false, Combo_comparttercexternoid_Internalname, "SelectedValue_set", Combo_comparttercexternoid_Selectedvalue_set);
         AV79PaisId_Col.Clear();
         Combo_paisid_Selectedvalue_set = AV79PaisId_Col.ToJSonString(false);
         ucCombo_paisid.SendProperty(context, sPrefix, false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'INFORMACAOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavInformacaoid.removeAllItems();
         cmbavInformacaoid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007I19 */
         pr_default.execute(17);
         while ( (pr_default.getStatus(17) != 101) )
         {
            A71InformacaoAtivo = H007I19_A71InformacaoAtivo[0];
            A69InformacaoId = H007I19_A69InformacaoId[0];
            A70InformacaoNome = H007I19_A70InformacaoNome[0];
            cmbavInformacaoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0)), A70InformacaoNome, 0);
            pr_default.readNext(17);
         }
         pr_default.close(17);
      }

      protected void S152( )
      {
         /* 'HIPOTESETRATAMENTOCOMBOCARREGA' Routine */
         returnInSub = false;
         cmbavHipotesetratamentoid.removeAllItems();
         cmbavHipotesetratamentoid.addItem("0", "(SELECIONE)", 0);
         /* Using cursor H007I20 */
         pr_default.execute(18);
         while ( (pr_default.getStatus(18) != 101) )
         {
            A74HipoteseTratamentoAtivo = H007I20_A74HipoteseTratamentoAtivo[0];
            A72HipoteseTratamentoId = H007I20_A72HipoteseTratamentoId[0];
            A73HipoteseTratamentoNome = H007I20_A73HipoteseTratamentoNome[0];
            cmbavHipotesetratamentoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A72HipoteseTratamentoId), 8, 0)), A73HipoteseTratamentoNome, 0);
            pr_default.readNext(18);
         }
         pr_default.close(18);
      }

      protected void S192( )
      {
         /* 'VALIDAINFORMACAO' Routine */
         returnInSub = false;
         AV77InformacaoExiste = false;
         AssignAttri(sPrefix, false, "AV77InformacaoExiste", AV77InformacaoExiste);
         /* Start For Each Line in Grid1 */
         nRC_GXsfl_126 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_126"), ",", "."));
         nGXsfl_126_fel_idx = 0;
         while ( nGXsfl_126_fel_idx < nRC_GXsfl_126 )
         {
            nGXsfl_126_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_126_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_fel_idx+1);
            sGXsfl_126_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1262( ) ;
            A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( edtDocDicionarioId_Internalname), ",", "."));
            A69InformacaoId = (int)(context.localUtil.CToN( cgiGet( edtInformacaoId_Internalname), ",", "."));
            A70InformacaoNome = cgiGet( edtInformacaoNome_Internalname);
            AV65DocDicionarioSensivel_Grid = cgiGet( edtavDocdicionariosensivel_grid_Internalname);
            A99DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkDocDicionarioSensivel_Internalname));
            AV66DocDicionarioPodeEliminar_Grid = cgiGet( edtavDocdicionariopodeeliminar_grid_Internalname);
            A100DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkDocDicionarioPodeEliminar_Internalname));
            A73HipoteseTratamentoNome = cgiGet( edtHipoteseTratamentoNome_Internalname);
            A101DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( edtDocDicionarioTransfInter_Internalname));
            AV43DocDicionarioTransfInterGrid = cgiGet( edtavDocdicionariotransfintergrid_Internalname);
            AV50Visualizar = cgiGet( edtavVisualizar_Internalname);
            AV35Atualizar = cgiGet( edtavAtualizar_Internalname);
            AV44Excluir = cgiGet( edtavExcluir_Internalname);
            if ( A69InformacaoId == AV18InformacaoId )
            {
               AV77InformacaoExiste = true;
               AssignAttri(sPrefix, false, "AV77InformacaoExiste", AV77InformacaoExiste);
            }
            /* End For Each Line */
         }
         if ( nGXsfl_126_fel_idx == 0 )
         {
            nGXsfl_126_idx = 1;
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
         }
         nGXsfl_126_fel_idx = 1;
      }

      protected void wb_table4_98_7I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcomparttercexternoinfo_Internalname, tblTablemergedcomparttercexternoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblComparttercexternoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblComparttercexternoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e297i1_client"+"'", "", "TextBlock", 7, lblComparttercexternoinfo_Tooltiptext, 1, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblComparttercexteradd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblComparttercexteradd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCOMPARTTERCEXTERADD\\'."+"'", "", "TextBlock", 5, "", lblComparttercexteradd_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_98_7I2e( true) ;
         }
         else
         {
            wb_table4_98_7I2e( false) ;
         }
      }

      protected void wb_table3_68_7I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedpaisinfo_Internalname, tblTablemergedpaisinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaisinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblPaisinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e307i1_client"+"'", "", "TextBlock", 7, lblPaisinfo_Tooltiptext, 1, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaisadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblPaisadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPAISADD\\'."+"'", "", "TextBlock", 5, "", lblPaisadd_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_68_7I2e( true) ;
         }
         else
         {
            wb_table3_68_7I2e( false) ;
         }
      }

      protected void wb_table2_47_7I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedhipoteseinfo_Internalname, tblTablemergedhipoteseinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHipoteseinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblHipoteseinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e317i1_client"+"'", "", "TextBlock", 7, lblHipoteseinfo_Tooltiptext, 1, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHipoteseadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblHipoteseadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOHIPOTESEADD\\'."+"'", "", "TextBlock", 5, "", lblHipoteseadd_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_47_7I2e( true) ;
         }
         else
         {
            wb_table2_47_7I2e( false) ;
         }
      }

      protected void wb_table1_22_7I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedinformacaoinfo_Internalname, tblTablemergedinformacaoinfo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInformacaoinfo_Internalname, "<i class=\"FontColorIcon fas fa-circle-info\"></i>", "", "", lblInformacaoinfo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e327i1_client"+"'", "", "TextBlock", 7, lblInformacaoinfo_Tooltiptext, 1, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInformacaoadd_Internalname, "<i class=\"FontColorIcon fas fa-circle-plus\"></i>", "", "", lblInformacaoadd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINFORMACAOADD\\'."+"'", "", "TextBlock", 5, "", lblInformacaoadd_Visible, 1, 0, 1, "HLP_DicionarioWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_7I2e( true) ;
         }
         else
         {
            wb_table1_22_7I2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV16DocumentoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV16DocumentoId", StringUtil.LTrimStr( (decimal)(AV16DocumentoId), 8, 0));
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
         PA7I2( ) ;
         WS7I2( ) ;
         WE7I2( ) ;
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
         sCtrlAV16DocumentoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "dicionariowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7I2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV16DocumentoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV16DocumentoId", StringUtil.LTrimStr( (decimal)(AV16DocumentoId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV16DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16DocumentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV16DocumentoId != wcpOAV16DocumentoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV16DocumentoId = AV16DocumentoId;
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
         sCtrlAV16DocumentoId = cgiGet( sPrefix+"AV16DocumentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV16DocumentoId) > 0 )
         {
            AV16DocumentoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV16DocumentoId), ",", "."));
            AssignAttri(sPrefix, false, "AV16DocumentoId", StringUtil.LTrimStr( (decimal)(AV16DocumentoId), 8, 0));
         }
         else
         {
            AV16DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV16DocumentoId_PARM"), ",", "."));
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
         PA7I2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7I2( ) ;
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
         WS7I2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16DocumentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DocumentoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16DocumentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16DocumentoId_CTRL", StringUtil.RTrim( sCtrlAV16DocumentoId));
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
         WE7I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910455837", true, true);
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
            context.AddJavascriptSource("dicionariowc.js", "?202311910455837", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1262( )
      {
         edtDocDicionarioId_Internalname = sPrefix+"DOCDICIONARIOID_"+sGXsfl_126_idx;
         edtInformacaoId_Internalname = sPrefix+"INFORMACAOID_"+sGXsfl_126_idx;
         edtInformacaoNome_Internalname = sPrefix+"INFORMACAONOME_"+sGXsfl_126_idx;
         edtavDocdicionariosensivel_grid_Internalname = sPrefix+"vDOCDICIONARIOSENSIVEL_GRID_"+sGXsfl_126_idx;
         chkDocDicionarioSensivel_Internalname = sPrefix+"DOCDICIONARIOSENSIVEL_"+sGXsfl_126_idx;
         edtavDocdicionariopodeeliminar_grid_Internalname = sPrefix+"vDOCDICIONARIOPODEELIMINAR_GRID_"+sGXsfl_126_idx;
         chkDocDicionarioPodeEliminar_Internalname = sPrefix+"DOCDICIONARIOPODEELIMINAR_"+sGXsfl_126_idx;
         edtHipoteseTratamentoNome_Internalname = sPrefix+"HIPOTESETRATAMENTONOME_"+sGXsfl_126_idx;
         edtDocDicionarioTransfInter_Internalname = sPrefix+"DOCDICIONARIOTRANSFINTER_"+sGXsfl_126_idx;
         edtavDocdicionariotransfintergrid_Internalname = sPrefix+"vDOCDICIONARIOTRANSFINTERGRID_"+sGXsfl_126_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_126_idx;
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR_"+sGXsfl_126_idx;
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR_"+sGXsfl_126_idx;
      }

      protected void SubsflControlProps_fel_1262( )
      {
         edtDocDicionarioId_Internalname = sPrefix+"DOCDICIONARIOID_"+sGXsfl_126_fel_idx;
         edtInformacaoId_Internalname = sPrefix+"INFORMACAOID_"+sGXsfl_126_fel_idx;
         edtInformacaoNome_Internalname = sPrefix+"INFORMACAONOME_"+sGXsfl_126_fel_idx;
         edtavDocdicionariosensivel_grid_Internalname = sPrefix+"vDOCDICIONARIOSENSIVEL_GRID_"+sGXsfl_126_fel_idx;
         chkDocDicionarioSensivel_Internalname = sPrefix+"DOCDICIONARIOSENSIVEL_"+sGXsfl_126_fel_idx;
         edtavDocdicionariopodeeliminar_grid_Internalname = sPrefix+"vDOCDICIONARIOPODEELIMINAR_GRID_"+sGXsfl_126_fel_idx;
         chkDocDicionarioPodeEliminar_Internalname = sPrefix+"DOCDICIONARIOPODEELIMINAR_"+sGXsfl_126_fel_idx;
         edtHipoteseTratamentoNome_Internalname = sPrefix+"HIPOTESETRATAMENTONOME_"+sGXsfl_126_fel_idx;
         edtDocDicionarioTransfInter_Internalname = sPrefix+"DOCDICIONARIOTRANSFINTER_"+sGXsfl_126_fel_idx;
         edtavDocdicionariotransfintergrid_Internalname = sPrefix+"vDOCDICIONARIOTRANSFINTERGRID_"+sGXsfl_126_fel_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_126_fel_idx;
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR_"+sGXsfl_126_fel_idx;
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR_"+sGXsfl_126_fel_idx;
      }

      protected void sendrow_1262( )
      {
         SubsflControlProps_1262( ) ;
         WB7I0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_126_idx - GRID1_nFirstRecordOnPage <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_126_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_126_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocDicionarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocDicionarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInformacaoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69InformacaoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69InformacaoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInformacaoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInformacaoNome_Internalname,(string)A70InformacaoNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInformacaoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDocdicionariosensivel_grid_Enabled!=0)&&(edtavDocdicionariosensivel_grid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 130,'"+sPrefix+"',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocdicionariosensivel_grid_Internalname,StringUtil.RTrim( AV65DocDicionarioSensivel_Grid),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDocdicionariosensivel_grid_Enabled!=0)&&(edtavDocdicionariosensivel_grid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,130);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocdicionariosensivel_grid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDocdicionariosensivel_grid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCDICIONARIOSENSIVEL_" + sGXsfl_126_idx;
            chkDocDicionarioSensivel.Name = GXCCtl;
            chkDocDicionarioSensivel.WebTags = "";
            chkDocDicionarioSensivel.Caption = "";
            AssignProp(sPrefix, false, chkDocDicionarioSensivel_Internalname, "TitleCaption", chkDocDicionarioSensivel.Caption, !bGXsfl_126_Refreshing);
            chkDocDicionarioSensivel.CheckedValue = "false";
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocDicionarioSensivel_Internalname,StringUtil.BoolToStr( A99DocDicionarioSensivel),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDocdicionariopodeeliminar_grid_Enabled!=0)&&(edtavDocdicionariopodeeliminar_grid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 132,'"+sPrefix+"',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocdicionariopodeeliminar_grid_Internalname,StringUtil.RTrim( AV66DocDicionarioPodeEliminar_Grid),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDocdicionariopodeeliminar_grid_Enabled!=0)&&(edtavDocdicionariopodeeliminar_grid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,132);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocdicionariopodeeliminar_grid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDocdicionariopodeeliminar_grid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCDICIONARIOPODEELIMINAR_" + sGXsfl_126_idx;
            chkDocDicionarioPodeEliminar.Name = GXCCtl;
            chkDocDicionarioPodeEliminar.WebTags = "";
            chkDocDicionarioPodeEliminar.Caption = "";
            AssignProp(sPrefix, false, chkDocDicionarioPodeEliminar_Internalname, "TitleCaption", chkDocDicionarioPodeEliminar.Caption, !bGXsfl_126_Refreshing);
            chkDocDicionarioPodeEliminar.CheckedValue = "false";
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocDicionarioPodeEliminar_Internalname,StringUtil.BoolToStr( A100DocDicionarioPodeEliminar),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHipoteseTratamentoNome_Internalname,(string)A73HipoteseTratamentoNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHipoteseTratamentoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocDicionarioTransfInter_Internalname,StringUtil.BoolToStr( A101DocDicionarioTransfInter),StringUtil.BoolToStr( A101DocDicionarioTransfInter),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocDicionarioTransfInter_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)126,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDocdicionariotransfintergrid_Enabled!=0)&&(edtavDocdicionariotransfintergrid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 136,'"+sPrefix+"',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocdicionariotransfintergrid_Internalname,(string)AV43DocDicionarioTransfInterGrid,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDocdicionariotransfintergrid_Enabled!=0)&&(edtavDocdicionariotransfintergrid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,136);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocdicionariotransfintergrid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDocdicionariotransfintergrid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVisualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 137,'"+sPrefix+"',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavVisualizar_Internalname,StringUtil.RTrim( AV50Visualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,137);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVVISUALIZAR.CLICK."+sGXsfl_126_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavVisualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavVisualizar_Visible,(int)edtavVisualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavAtualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAtualizar_Enabled!=0)&&(edtavAtualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 138,'"+sPrefix+"',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAtualizar_Internalname,StringUtil.RTrim( AV35Atualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAtualizar_Enabled!=0)&&(edtavAtualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,138);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVATUALIZAR.CLICK."+sGXsfl_126_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAtualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavAtualizar_Visible,(int)edtavAtualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavExcluir_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavExcluir_Enabled!=0)&&(edtavExcluir_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 139,'"+sPrefix+"',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExcluir_Internalname,StringUtil.RTrim( AV44Excluir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavExcluir_Enabled!=0)&&(edtavExcluir_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,139);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVEXCLUIR.CLICK."+sGXsfl_126_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExcluir_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavExcluir_Visible,(int)edtavExcluir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes7I2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_126_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_126_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_idx+1);
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
         }
         /* End function sendrow_1262 */
      }

      protected void init_web_controls( )
      {
         cmbavInformacaoid.Name = "vINFORMACAOID";
         cmbavInformacaoid.WebTags = "";
         cmbavInformacaoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 8, 0)), "(Selecione)", 0);
         if ( cmbavInformacaoid.ItemCount > 0 )
         {
         }
         chkavDocdicionariopodeeliminar.Name = "vDOCDICIONARIOPODEELIMINAR";
         chkavDocdicionariopodeeliminar.WebTags = "";
         chkavDocdicionariopodeeliminar.Caption = "";
         AssignProp(sPrefix, false, chkavDocdicionariopodeeliminar_Internalname, "TitleCaption", chkavDocdicionariopodeeliminar.Caption, true);
         chkavDocdicionariopodeeliminar.CheckedValue = "false";
         chkavDocdicionariosensivel.Name = "vDOCDICIONARIOSENSIVEL";
         chkavDocdicionariosensivel.WebTags = "";
         chkavDocdicionariosensivel.Caption = "";
         AssignProp(sPrefix, false, chkavDocdicionariosensivel_Internalname, "TitleCaption", chkavDocdicionariosensivel.Caption, true);
         chkavDocdicionariosensivel.CheckedValue = "false";
         cmbavHipotesetratamentoid.Name = "vHIPOTESETRATAMENTOID";
         cmbavHipotesetratamentoid.WebTags = "";
         cmbavHipotesetratamentoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 8, 0)), "(Selecione)", 0);
         if ( cmbavHipotesetratamentoid.ItemCount > 0 )
         {
         }
         cmbavDocdicionariotransfinter.Name = "vDOCDICIONARIOTRANSFINTER";
         cmbavDocdicionariotransfinter.WebTags = "";
         cmbavDocdicionariotransfinter.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocdicionariotransfinter.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocdicionariotransfinter.ItemCount > 0 )
         {
         }
         GXCCtl = "DOCDICIONARIOSENSIVEL_" + sGXsfl_126_idx;
         chkDocDicionarioSensivel.Name = GXCCtl;
         chkDocDicionarioSensivel.WebTags = "";
         chkDocDicionarioSensivel.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioSensivel_Internalname, "TitleCaption", chkDocDicionarioSensivel.Caption, !bGXsfl_126_Refreshing);
         chkDocDicionarioSensivel.CheckedValue = "false";
         GXCCtl = "DOCDICIONARIOPODEELIMINAR_" + sGXsfl_126_idx;
         chkDocDicionarioPodeEliminar.Name = GXCCtl;
         chkDocDicionarioPodeEliminar.WebTags = "";
         chkDocDicionarioPodeEliminar.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioPodeEliminar_Internalname, "TitleCaption", chkDocDicionarioPodeEliminar.Caption, !bGXsfl_126_Refreshing);
         chkDocDicionarioPodeEliminar.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl126( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"DivS\" data-gxgridid=\"126\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Doc Dicionario Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id da Informação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "INFORMAÇÃO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "SENSÍVEL") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "SENSÍVEL") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "PODE ELIMINAR") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "PODE ELIMINAR") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "HIPÓTESE TRATAMENTO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "TRANSFERÊNCIA INTERNACIONAL") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "TRANSFERÊNCIA INTERNACIONAL") ;
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
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", sPrefix);
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69InformacaoId), 8, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A70InformacaoNome);
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV65DocDicionarioSensivel_Grid));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocdicionariosensivel_grid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A99DocDicionarioSensivel));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV66DocDicionarioPodeEliminar_Grid));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocdicionariopodeeliminar_grid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A100DocDicionarioPodeEliminar));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A73HipoteseTratamentoNome);
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A101DocDicionarioTransfInter));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV43DocDicionarioTransfInterGrid);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocdicionariotransfintergrid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV50Visualizar));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV35Atualizar));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV44Excluir));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         cmbavInformacaoid_Internalname = sPrefix+"vINFORMACAOID";
         lblInformacaoinfo_Internalname = sPrefix+"INFORMACAOINFO";
         lblInformacaoadd_Internalname = sPrefix+"INFORMACAOADD";
         tblTablemergedinformacaoinfo_Internalname = sPrefix+"TABLEMERGEDINFORMACAOINFO";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         chkavDocdicionariopodeeliminar_Internalname = sPrefix+"vDOCDICIONARIOPODEELIMINAR";
         lblPodeeliminarinfo_Internalname = sPrefix+"PODEELIMINARINFO";
         chkavDocdicionariosensivel_Internalname = sPrefix+"vDOCDICIONARIOSENSIVEL";
         lblSensivelinfo_Internalname = sPrefix+"SENSIVELINFO";
         cmbavHipotesetratamentoid_Internalname = sPrefix+"vHIPOTESETRATAMENTOID";
         lblHipoteseinfo_Internalname = sPrefix+"HIPOTESEINFO";
         lblHipoteseadd_Internalname = sPrefix+"HIPOTESEADD";
         tblTablemergedhipoteseinfo_Internalname = sPrefix+"TABLEMERGEDHIPOTESEINFO";
         cmbavDocdicionariotransfinter_Internalname = sPrefix+"vDOCDICIONARIOTRANSFINTER";
         lblTransfinterinfo_Internalname = sPrefix+"TRANSFINTERINFO";
         lblTextblockcombo_paisid_Internalname = sPrefix+"TEXTBLOCKCOMBO_PAISID";
         Combo_paisid_Internalname = sPrefix+"COMBO_PAISID";
         divTablesplittedpaisid_Internalname = sPrefix+"TABLESPLITTEDPAISID";
         divCombo_paisid_cell_Internalname = sPrefix+"COMBO_PAISID_CELL";
         lblPaisinfo_Internalname = sPrefix+"PAISINFO";
         lblPaisadd_Internalname = sPrefix+"PAISADD";
         tblTablemergedpaisinfo_Internalname = sPrefix+"TABLEMERGEDPAISINFO";
         edtavDocdicionariotipotransfintergarantia_Internalname = sPrefix+"vDOCDICIONARIOTIPOTRANSFINTERGARANTIA";
         divDocdicionariotipotransfintergarantia_cell_Internalname = sPrefix+"DOCDICIONARIOTIPOTRANSFINTERGARANTIA_CELL";
         lblTipotransfintergarantia_Internalname = sPrefix+"TIPOTRANSFINTERGARANTIA";
         lblTxttipotransfinter_Internalname = sPrefix+"TXTTIPOTRANSFINTER";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         lblTextblockcombo_comparttercexternoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_COMPARTTERCEXTERNOID";
         Combo_comparttercexternoid_Internalname = sPrefix+"COMBO_COMPARTTERCEXTERNOID";
         divTablesplittedcomparttercexternoid_Internalname = sPrefix+"TABLESPLITTEDCOMPARTTERCEXTERNOID";
         lblComparttercexternoinfo_Internalname = sPrefix+"COMPARTTERCEXTERNOINFO";
         lblComparttercexteradd_Internalname = sPrefix+"COMPARTTERCEXTERADD";
         tblTablemergedcomparttercexternoinfo_Internalname = sPrefix+"TABLEMERGEDCOMPARTTERCEXTERNOINFO";
         edtavDocdicionariofinalidade_Internalname = sPrefix+"vDOCDICIONARIOFINALIDADE";
         lblFinalidadeinfo_Internalname = sPrefix+"FINALIDADEINFO";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         bttBtnadicionar_Internalname = sPrefix+"BTNADICIONAR";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         edtDocDicionarioId_Internalname = sPrefix+"DOCDICIONARIOID";
         edtInformacaoId_Internalname = sPrefix+"INFORMACAOID";
         edtInformacaoNome_Internalname = sPrefix+"INFORMACAONOME";
         edtavDocdicionariosensivel_grid_Internalname = sPrefix+"vDOCDICIONARIOSENSIVEL_GRID";
         chkDocDicionarioSensivel_Internalname = sPrefix+"DOCDICIONARIOSENSIVEL";
         edtavDocdicionariopodeeliminar_grid_Internalname = sPrefix+"vDOCDICIONARIOPODEELIMINAR_GRID";
         chkDocDicionarioPodeEliminar_Internalname = sPrefix+"DOCDICIONARIOPODEELIMINAR";
         edtHipoteseTratamentoNome_Internalname = sPrefix+"HIPOTESETRATAMENTONOME";
         edtDocDicionarioTransfInter_Internalname = sPrefix+"DOCDICIONARIOTRANSFINTER";
         edtavDocdicionariotransfintergrid_Internalname = sPrefix+"vDOCDICIONARIOTRANSFINTERGRID";
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR";
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR";
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR";
         edtavTotaldados_Internalname = sPrefix+"vTOTALDADOS";
         edtavTotaldadossensiveis_Internalname = sPrefix+"vTOTALDADOSSENSIVEIS";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         divTablemain1_Internalname = sPrefix+"TABLEMAIN1";
         edtavDocumentoid_Internalname = sPrefix+"vDOCUMENTOID";
         edtavDocdicionarioid_Internalname = sPrefix+"vDOCDICIONARIOID";
         Grid1_empowerer_Internalname = sPrefix+"GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid1_Internalname = sPrefix+"GRID1";
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
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         chkavDocdicionariosensivel.Caption = "POSSUÍ DADOS SENSÍVEIS";
         chkavDocdicionariopodeeliminar.Caption = "PODE ELIMINAR";
         edtavExcluir_Jsonclick = "";
         edtavExcluir_Enabled = 1;
         edtavAtualizar_Jsonclick = "";
         edtavAtualizar_Enabled = 1;
         edtavVisualizar_Jsonclick = "";
         edtavVisualizar_Enabled = 1;
         edtavDocdicionariotransfintergrid_Jsonclick = "";
         edtavDocdicionariotransfintergrid_Visible = -1;
         edtavDocdicionariotransfintergrid_Enabled = 1;
         edtDocDicionarioTransfInter_Jsonclick = "";
         edtHipoteseTratamentoNome_Jsonclick = "";
         chkDocDicionarioPodeEliminar.Caption = "";
         edtavDocdicionariopodeeliminar_grid_Jsonclick = "";
         edtavDocdicionariopodeeliminar_grid_Visible = -1;
         edtavDocdicionariopodeeliminar_grid_Enabled = 1;
         chkDocDicionarioSensivel.Caption = "";
         edtavDocdicionariosensivel_grid_Jsonclick = "";
         edtavDocdicionariosensivel_grid_Visible = -1;
         edtavDocdicionariosensivel_grid_Enabled = 1;
         edtInformacaoNome_Jsonclick = "";
         edtInformacaoId_Jsonclick = "";
         edtDocDicionarioId_Jsonclick = "";
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         lblInformacaoadd_Visible = 1;
         lblHipoteseadd_Visible = 1;
         lblPaisadd_Visible = 1;
         lblComparttercexteradd_Visible = 1;
         edtavVisualizar_Visible = -1;
         lblComparttercexternoinfo_Tooltiptext = "";
         lblPaisinfo_Tooltiptext = "";
         lblHipoteseinfo_Tooltiptext = "";
         lblInformacaoinfo_Tooltiptext = "";
         edtavDocdicionarioid_Jsonclick = "";
         edtavDocdicionarioid_Visible = 1;
         edtavDocumentoid_Jsonclick = "";
         edtavDocumentoid_Visible = 1;
         edtavTotaldadossensiveis_Jsonclick = "";
         edtavTotaldadossensiveis_Enabled = 1;
         edtavTotaldados_Jsonclick = "";
         edtavTotaldados_Enabled = 1;
         bttBtnadicionar_Caption = "ADICIONAR";
         bttBtnadicionar_Visible = 1;
         lblTextblock1_Caption = "0/10000";
         lblFinalidadeinfo_Tooltiptext = "";
         lblFinalidadeinfo_Visible = 1;
         edtavDocdicionariofinalidade_Enabled = 1;
         Combo_comparttercexternoid_Caption = "";
         lblTxttipotransfinter_Caption = "0/10000";
         lblTxttipotransfinter_Visible = 1;
         lblTipotransfintergarantia_Tooltiptext = "";
         lblTipotransfintergarantia_Visible = 1;
         edtavDocdicionariotipotransfintergarantia_Enabled = 1;
         divDocdicionariotipotransfintergarantia_cell_Class = "col-xs-11";
         Combo_paisid_Caption = "";
         divCombo_paisid_cell_Class = "col-xs-5";
         lblTransfinterinfo_Tooltiptext = "";
         lblTransfinterinfo_Visible = 1;
         cmbavDocdicionariotransfinter_Jsonclick = "";
         cmbavDocdicionariotransfinter.Enabled = 1;
         cmbavHipotesetratamentoid_Jsonclick = "";
         cmbavHipotesetratamentoid.Enabled = 1;
         lblSensivelinfo_Tooltiptext = "";
         lblSensivelinfo_Visible = 1;
         chkavDocdicionariosensivel.Enabled = 1;
         lblPodeeliminarinfo_Tooltiptext = "";
         chkavDocdicionariopodeeliminar.Enabled = 1;
         cmbavInformacaoid_Jsonclick = "";
         cmbavInformacaoid.Enabled = 1;
         Grid1_empowerer_Infinitescrolling = "Grid";
         Combo_comparttercexternoid_Emptyitemtext = "(SELECIONE)";
         Combo_comparttercexternoid_Multiplevaluestype = "Tags";
         Combo_comparttercexternoid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_comparttercexternoid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_comparttercexternoid_Enabled = Convert.ToBoolean( -1);
         Combo_comparttercexternoid_Cls = "ExtendedCombo AttributeFL";
         Combo_paisid_Multiplevaluestype = "Tags";
         Combo_paisid_Emptyitem = Convert.ToBoolean( 0);
         Combo_paisid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_paisid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_paisid_Enabled = Convert.ToBoolean( -1);
         Combo_paisid_Cls = "ExtendedCombo AttributeFL";
         edtavExcluir_Visible = -1;
         edtavAtualizar_Visible = -1;
         subGrid1_Rows = 50;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'sPrefix'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E247I2',iparms:[{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV43DocDicionarioTransfInterGrid',fld:'vDOCDICIONARIOTRANSFINTERGRID',pic:''},{av:'AV50Visualizar',fld:'vVISUALIZAR',pic:''},{av:'AV35Atualizar',fld:'vATUALIZAR',pic:''},{av:'AV44Excluir',fld:'vEXCLUIR',pic:''},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV65DocDicionarioSensivel_Grid',fld:'vDOCDICIONARIOSENSIVEL_GRID',pic:''},{av:'AV66DocDicionarioPodeEliminar_Grid',fld:'vDOCDICIONARIOPODEELIMINAR_GRID',pic:''},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOPODEELIMINARINFO'","{handler:'E117I1',iparms:[]");
         setEventMetadata("'DOPODEELIMINARINFO'",",oparms:[]}");
         setEventMetadata("'DOSENSIVELINFO'","{handler:'E127I1',iparms:[]");
         setEventMetadata("'DOSENSIVELINFO'",",oparms:[]}");
         setEventMetadata("'DOHIPOTESEINFO'","{handler:'E317I1',iparms:[]");
         setEventMetadata("'DOHIPOTESEINFO'",",oparms:[]}");
         setEventMetadata("'DOHIPOTESEADD'","{handler:'E167I2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOHIPOTESEADD'",",oparms:[{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("'DOTRANSFINTERINFO'","{handler:'E137I1',iparms:[]");
         setEventMetadata("'DOTRANSFINTERINFO'",",oparms:[]}");
         setEventMetadata("'DOPAISINFO'","{handler:'E307I1',iparms:[]");
         setEventMetadata("'DOPAISINFO'",",oparms:[]}");
         setEventMetadata("'DOPAISADD'","{handler:'E177I2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOPAISADD'",",oparms:[{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("'DOTIPOTRANSFINTERGARANTIA'","{handler:'E147I1',iparms:[]");
         setEventMetadata("'DOTIPOTRANSFINTERGARANTIA'",",oparms:[]}");
         setEventMetadata("'DOCOMPARTTERCEXTERNOINFO'","{handler:'E297I1',iparms:[]");
         setEventMetadata("'DOCOMPARTTERCEXTERNOINFO'",",oparms:[]}");
         setEventMetadata("'DOCOMPARTTERCEXTERADD'","{handler:'E187I2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOCOMPARTTERCEXTERADD'",",oparms:[{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("'DOFINALIDADEINFO'","{handler:'E157I1',iparms:[]");
         setEventMetadata("'DOFINALIDADEINFO'",",oparms:[]}");
         setEventMetadata("'DOADICIONAR'","{handler:'E197I2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'AV78isDisplay',fld:'vISDISPLAY',pic:''},{av:'AV54CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV10DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV77InformacaoExiste',fld:'vINFORMACAOEXISTE',pic:''},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'cmbavDocdicionariotransfinter'},{av:'AV13DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''},{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV9DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',grid:126,pic:'ZZZZZZZ9'},{av:'nRC_GXsfl_126',ctrl:'GRID1',grid:126,prop:'GridRC',grid:126},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'AV7DocDicionario',fld:'vDOCDICIONARIO',pic:''},{av:'Combo_paisid_Ddointernalname',ctrl:'COMBO_PAISID',prop:'DDOInternalName'},{av:'Combo_comparttercexternoid_Ddointernalname',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'DDOInternalName'},{av:'A69InformacaoId',fld:'INFORMACAOID',grid:126,pic:'ZZZZZZZ9'},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'A70InformacaoNome',fld:'INFORMACAONOME',grid:126,pic:''},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',grid:126,pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOADICIONAR'",",oparms:[{av:'cmbavInformacaoid'},{av:'chkavDocdicionariopodeeliminar.Enabled',ctrl:'vDOCDICIONARIOPODEELIMINAR',prop:'Enabled'},{av:'chkavDocdicionariosensivel.Enabled',ctrl:'vDOCDICIONARIOSENSIVEL',prop:'Enabled'},{av:'cmbavHipotesetratamentoid'},{av:'cmbavDocdicionariotransfinter'},{av:'edtavDocdicionariotipotransfintergarantia_Enabled',ctrl:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',prop:'Enabled'},{av:'edtavDocdicionariofinalidade_Enabled',ctrl:'vDOCDICIONARIOFINALIDADE',prop:'Enabled'},{av:'Combo_comparttercexternoid_Enabled',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'Enabled'},{av:'Combo_paisid_Enabled',ctrl:'COMBO_PAISID',prop:'Enabled'},{ctrl:'BTNADICIONAR',prop:'Caption'},{av:'AV78isDisplay',fld:'vISDISPLAY',pic:''},{av:'AV7DocDicionario',fld:'vDOCDICIONARIO',pic:''},{av:'AV10DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'lblTxttipotransfinter_Caption',ctrl:'TXTTIPOTRANSFINTER',prop:'Caption'},{av:'lblTextblock1_Caption',ctrl:'TEXTBLOCK1',prop:'Caption'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV9DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV54CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV77InformacaoExiste',fld:'vINFORMACAOEXISTE',pic:''},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("'DOINFORMACAOINFO'","{handler:'E327I1',iparms:[]");
         setEventMetadata("'DOINFORMACAOINFO'",",oparms:[]}");
         setEventMetadata("'DOINFORMACAOADD'","{handler:'E207I2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOINFORMACAOADD'",",oparms:[{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("VDOCDICIONARIOTRANSFINTER.CONTROLVALUECHANGED","{handler:'E217I2',iparms:[{av:'cmbavDocdicionariotransfinter'},{av:'AV13DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''}]");
         setEventMetadata("VDOCDICIONARIOTRANSFINTER.CONTROLVALUECHANGED",",oparms:[{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'lblTxttipotransfinter_Caption',ctrl:'TXTTIPOTRANSFINTER',prop:'Caption'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'Combo_paisid_Enabled',ctrl:'COMBO_PAISID',prop:'Enabled'},{av:'edtavDocdicionariotipotransfintergarantia_Enabled',ctrl:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',prop:'Enabled'},{av:'lblTxttipotransfinter_Visible',ctrl:'TXTTIPOTRANSFINTER',prop:'Visible'}]}");
         setEventMetadata("VATUALIZAR.CLICK","{handler:'E257I2',iparms:[{av:'AV9DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''},{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''}]");
         setEventMetadata("VATUALIZAR.CLICK",",oparms:[{ctrl:'BTNADICIONAR',prop:'Caption'},{av:'lblTextblock1_Caption',ctrl:'TEXTBLOCK1',prop:'Caption'},{av:'lblTxttipotransfinter_Caption',ctrl:'TXTTIPOTRANSFINTER',prop:'Caption'},{av:'AV7DocDicionario',fld:'vDOCDICIONARIO',pic:''},{av:'AV10DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'cmbavDocdicionariotransfinter'},{av:'AV13DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''},{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV9DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'Combo_paisid_Enabled',ctrl:'COMBO_PAISID',prop:'Enabled'},{av:'edtavDocdicionariotipotransfintergarantia_Enabled',ctrl:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',prop:'Enabled'},{av:'lblTxttipotransfinter_Visible',ctrl:'TXTTIPOTRANSFINTER',prop:'Visible'}]}");
         setEventMetadata("VEXCLUIR.CLICK","{handler:'E267I2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV10DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VEXCLUIR.CLICK",",oparms:[{av:'AV10DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV7DocDicionario',fld:'vDOCDICIONARIO',pic:''},{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("VVISUALIZAR.CLICK","{handler:'E277I2',iparms:[{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''}]");
         setEventMetadata("VVISUALIZAR.CLICK",",oparms:[{av:'cmbavInformacaoid'},{av:'chkavDocdicionariopodeeliminar.Enabled',ctrl:'vDOCDICIONARIOPODEELIMINAR',prop:'Enabled'},{av:'chkavDocdicionariosensivel.Enabled',ctrl:'vDOCDICIONARIOSENSIVEL',prop:'Enabled'},{av:'cmbavHipotesetratamentoid'},{av:'cmbavDocdicionariotransfinter'},{av:'edtavDocdicionariotipotransfintergarantia_Enabled',ctrl:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',prop:'Enabled'},{av:'edtavDocdicionariofinalidade_Enabled',ctrl:'vDOCDICIONARIOFINALIDADE',prop:'Enabled'},{av:'Combo_comparttercexternoid_Enabled',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'Enabled'},{ctrl:'BTNADICIONAR',prop:'Caption'},{av:'AV78isDisplay',fld:'vISDISPLAY',pic:''},{av:'lblTxttipotransfinter_Caption',ctrl:'TXTTIPOTRANSFINTER',prop:'Caption'},{av:'AV7DocDicionario',fld:'vDOCDICIONARIO',pic:''},{av:'AV10DocDicionarioId',fld:'vDOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV13DocDicionarioTransfInter',fld:'vDOCDICIONARIOTRANSFINTER',pic:''},{av:'AV51DocDicionarioTipoTransfInterGarantia',fld:'vDOCDICIONARIOTIPOTRANSFINTERGARANTIA',pic:''},{av:'AV9DocDicionarioFinalidade',fld:'vDOCDICIONARIOFINALIDADE',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'Combo_paisid_Enabled',ctrl:'COMBO_PAISID',prop:'Enabled'},{av:'lblTxttipotransfinter_Visible',ctrl:'TXTTIPOTRANSFINTER',prop:'Visible'}]}");
         setEventMetadata("GRID1.REFRESH","{handler:'E287I2',iparms:[]");
         setEventMetadata("GRID1.REFRESH",",oparms:[{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV16DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV68TotalDadosSensiveis',fld:'vTOTALDADOSSENSIVEIS',pic:'ZZZ9'},{av:'AV67TotalDados',fld:'vTOTALDADOS',pic:'ZZZ9'},{av:'AV8DocDicionarioDataInclusao',fld:'vDOCDICIONARIODATAINCLUSAO',pic:'',hsh:true},{av:'sPrefix'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'Combo_paisid_Selectedvalue_get',ctrl:'COMBO_PAISID',prop:'SelectedValue_get'},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_get',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_get'},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'A70InformacaoNome',fld:'INFORMACAONOME',pic:''},{av:'A71InformacaoAtivo',fld:'INFORMACAOATIVO',pic:''},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A73HipoteseTratamentoNome',fld:'HIPOTESETRATAMENTONOME',pic:''},{av:'A74HipoteseTratamentoAtivo',fld:'HIPOTESETRATAMENTOATIVO',pic:''},{av:'A72HipoteseTratamentoId',fld:'HIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'A5PaisNome',fld:'PAISNOME',pic:''},{av:'A6PaisAtivo',fld:'PAISATIVO',pic:''},{av:'A4PaisId',fld:'PAISID',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'A67CompartTercExternoNome',fld:'COMPARTTERCEXTERNONOME',pic:''},{av:'A68CompartTercExternoAtivo',fld:'COMPARTTERCEXTERNOATIVO',pic:''},{av:'A66CompartTercExternoId',fld:'COMPARTTERCEXTERNOID',pic:'ZZZZZZZ9'},{av:'AV11DocDicionarioPodeEliminar',fld:'vDOCDICIONARIOPODEELIMINAR',pic:''},{av:'AV12DocDicionarioSensivel',fld:'vDOCDICIONARIOSENSIVEL',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'cmbavInformacaoid'},{av:'AV18InformacaoId',fld:'vINFORMACAOID',pic:'ZZZZZZZ9'},{av:'AV56IsInformacao',fld:'vISINFORMACAO',pic:''},{av:'AV57InformacaoId_Out',fld:'vINFORMACAOID_OUT',pic:'ZZZ9'},{av:'cmbavHipotesetratamentoid'},{av:'AV17HipoteseTratamentoId',fld:'vHIPOTESETRATAMENTOID',pic:'ZZZZZZZ9'},{av:'AV59IsHipotese',fld:'vISHIPOTESE',pic:''},{av:'AV58HipoteseTratamentoId_Out',fld:'vHIPOTESETRATAMENTOID_OUT',pic:'ZZZZZZZ9'},{av:'AV21PaisId',fld:'vPAISID',pic:''},{av:'AV79PaisId_Col',fld:'vPAISID_COL',pic:''},{av:'Combo_paisid_Selectedvalue_set',ctrl:'COMBO_PAISID',prop:'SelectedValue_set'},{av:'AV60IsPais',fld:'vISPAIS',pic:''},{av:'AV61PaisId_Out',fld:'vPAISID_OUT',pic:'ZZZZZZZ9'},{av:'AV6CompartTercExternoId',fld:'vCOMPARTTERCEXTERNOID',pic:''},{av:'AV64CompartTercExternoId_Col',fld:'vCOMPARTTERCEXTERNOID_COL',pic:''},{av:'Combo_comparttercexternoid_Selectedvalue_set',ctrl:'COMBO_COMPARTTERCEXTERNOID',prop:'SelectedValue_set'},{av:'AV62IsCompartTercExterno',fld:'vISCOMPARTTERCEXTERNO',pic:''},{av:'AV63CompartTercExternoId_Out',fld:'vCOMPARTTERCEXTERNOID_OUT',pic:'ZZZZZZZ9'},{av:'AV81PaisId_Item',fld:'vPAISID_ITEM',pic:'ZZZZZZZ9'},{av:'AV80PaisId_Data',fld:'vPAISID_DATA',pic:''},{av:'AV39CompartTercExternoId_Item',fld:'vCOMPARTTERCEXTERNOID_ITEM',pic:'ZZZZZZZ9'},{av:'AV38CompartTercExternoId_Data',fld:'vCOMPARTTERCEXTERNOID_DATA',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'lblHipoteseadd_Visible',ctrl:'HIPOTESEADD',prop:'Visible'},{av:'lblPaisadd_Visible',ctrl:'PAISADD',prop:'Visible'},{av:'lblComparttercexteradd_Visible',ctrl:'COMPARTTERCEXTERADD',prop:'Visible'},{ctrl:'BTNADICIONAR',prop:'Visible'},{av:'lblInformacaoadd_Visible',ctrl:'INFORMACAOADD',prop:'Visible'}]}");
         setEventMetadata("VALIDV_DOCUMENTOID","{handler:'Validv_Documentoid',iparms:[]");
         setEventMetadata("VALIDV_DOCUMENTOID",",oparms:[]}");
         setEventMetadata("VALIDV_DOCDICIONARIOID","{handler:'Validv_Docdicionarioid',iparms:[]");
         setEventMetadata("VALIDV_DOCDICIONARIOID",",oparms:[]}");
         setEventMetadata("VALID_INFORMACAOID","{handler:'Valid_Informacaoid',iparms:[]");
         setEventMetadata("VALID_INFORMACAOID",",oparms:[]}");
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
         Combo_paisid_Selectedvalue_get = "";
         Combo_comparttercexternoid_Selectedvalue_get = "";
         Combo_paisid_Ddointernalname = "";
         Combo_comparttercexternoid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV79PaisId_Col = new GxSimpleCollection<int>();
         AV64CompartTercExternoId_Col = new GxSimpleCollection<int>();
         AV21PaisId = new GxSimpleCollection<int>();
         A5PaisNome = "";
         AV6CompartTercExternoId = new GxSimpleCollection<int>();
         A67CompartTercExternoNome = "";
         AV8DocDicionarioDataInclusao = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV41DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV80PaisId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV38CompartTercExternoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV7DocDicionario = new SdtDocDicionario(context);
         Combo_paisid_Selectedvalue_set = "";
         Combo_comparttercexternoid_Selectedvalue_set = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblPodeeliminarinfo_Jsonclick = "";
         lblSensivelinfo_Jsonclick = "";
         lblTransfinterinfo_Jsonclick = "";
         lblTextblockcombo_paisid_Jsonclick = "";
         ucCombo_paisid = new GXUserControl();
         AV51DocDicionarioTipoTransfInterGarantia = "";
         lblTipotransfintergarantia_Jsonclick = "";
         lblTxttipotransfinter_Jsonclick = "";
         lblTextblockcombo_comparttercexternoid_Jsonclick = "";
         ucCombo_comparttercexternoid = new GXUserControl();
         AV9DocDicionarioFinalidade = "";
         lblFinalidadeinfo_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         bttBtnadicionar_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucGrid1_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A70InformacaoNome = "";
         AV65DocDicionarioSensivel_Grid = "";
         AV66DocDicionarioPodeEliminar_Grid = "";
         A73HipoteseTratamentoNome = "";
         AV43DocDicionarioTransfInterGrid = "";
         AV50Visualizar = "";
         AV35Atualizar = "";
         AV44Excluir = "";
         GXDecQS = "";
         GXCCtl = "";
         scmdbuf = "";
         H007I2_A72HipoteseTratamentoId = new int[1] ;
         H007I2_A75DocumentoId = new int[1] ;
         H007I2_A101DocDicionarioTransfInter = new bool[] {false} ;
         H007I2_A73HipoteseTratamentoNome = new string[] {""} ;
         H007I2_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         H007I2_A99DocDicionarioSensivel = new bool[] {false} ;
         H007I2_A70InformacaoNome = new string[] {""} ;
         H007I2_A69InformacaoId = new int[1] ;
         H007I2_A98DocDicionarioId = new int[1] ;
         H007I3_AGRID1_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H007I4_A112TooltipId = new int[1] ;
         H007I4_A135CampoId = new int[1] ;
         H007I4_A139TooltipTelaId = new int[1] ;
         H007I4_A140TooltipTelaNome = new string[] {""} ;
         H007I4_A118TooltipAtivo = new bool[] {false} ;
         H007I4_A136CampoNome = new string[] {""} ;
         H007I4_A115TooltipDescricao = new string[] {""} ;
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         Grid1Row = new GXWebRow();
         H007I5_A66CompartTercExternoId = new int[1] ;
         H007I5_A98DocDicionarioId = new int[1] ;
         H007I6_A98DocDicionarioId = new int[1] ;
         H007I6_A66CompartTercExternoId = new int[1] ;
         H007I7_A4PaisId = new int[1] ;
         H007I7_A98DocDicionarioId = new int[1] ;
         H007I8_A98DocDicionarioId = new int[1] ;
         H007I8_A4PaisId = new int[1] ;
         AV92GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         H007I9_A66CompartTercExternoId = new int[1] ;
         H007I9_A98DocDicionarioId = new int[1] ;
         H007I10_A98DocDicionarioId = new int[1] ;
         H007I10_A66CompartTercExternoId = new int[1] ;
         H007I11_A4PaisId = new int[1] ;
         H007I11_A98DocDicionarioId = new int[1] ;
         H007I12_A98DocDicionarioId = new int[1] ;
         H007I12_A4PaisId = new int[1] ;
         AV100GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H007I13_A68CompartTercExternoAtivo = new bool[] {false} ;
         H007I13_A66CompartTercExternoId = new int[1] ;
         H007I13_A67CompartTercExternoNome = new string[] {""} ;
         AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H007I14_A6PaisAtivo = new bool[] {false} ;
         H007I14_A4PaisId = new int[1] ;
         H007I14_A5PaisNome = new string[] {""} ;
         H007I15_A98DocDicionarioId = new int[1] ;
         H007I15_A66CompartTercExternoId = new int[1] ;
         H007I16_A98DocDicionarioId = new int[1] ;
         H007I16_A4PaisId = new int[1] ;
         AV108GXV11 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H007I17_A98DocDicionarioId = new int[1] ;
         H007I17_A66CompartTercExternoId = new int[1] ;
         H007I18_A98DocDicionarioId = new int[1] ;
         H007I18_A4PaisId = new int[1] ;
         H007I19_A71InformacaoAtivo = new bool[] {false} ;
         H007I19_A69InformacaoId = new int[1] ;
         H007I19_A70InformacaoNome = new string[] {""} ;
         H007I20_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         H007I20_A72HipoteseTratamentoId = new int[1] ;
         H007I20_A73HipoteseTratamentoNome = new string[] {""} ;
         lblComparttercexternoinfo_Jsonclick = "";
         lblComparttercexteradd_Jsonclick = "";
         lblPaisinfo_Jsonclick = "";
         lblPaisadd_Jsonclick = "";
         lblHipoteseinfo_Jsonclick = "";
         lblHipoteseadd_Jsonclick = "";
         lblInformacaoinfo_Jsonclick = "";
         lblInformacaoadd_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV16DocumentoId = "";
         subGrid1_Linesclass = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.dicionariowc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariowc__default(),
            new Object[][] {
                new Object[] {
               H007I2_A72HipoteseTratamentoId, H007I2_A75DocumentoId, H007I2_A101DocDicionarioTransfInter, H007I2_A73HipoteseTratamentoNome, H007I2_A100DocDicionarioPodeEliminar, H007I2_A99DocDicionarioSensivel, H007I2_A70InformacaoNome, H007I2_A69InformacaoId, H007I2_A98DocDicionarioId
               }
               , new Object[] {
               H007I3_AGRID1_nRecordCount
               }
               , new Object[] {
               H007I4_A112TooltipId, H007I4_A135CampoId, H007I4_A139TooltipTelaId, H007I4_A140TooltipTelaNome, H007I4_A118TooltipAtivo, H007I4_A136CampoNome, H007I4_A115TooltipDescricao
               }
               , new Object[] {
               H007I5_A66CompartTercExternoId, H007I5_A98DocDicionarioId
               }
               , new Object[] {
               H007I6_A98DocDicionarioId, H007I6_A66CompartTercExternoId
               }
               , new Object[] {
               H007I7_A4PaisId, H007I7_A98DocDicionarioId
               }
               , new Object[] {
               H007I8_A98DocDicionarioId, H007I8_A4PaisId
               }
               , new Object[] {
               H007I9_A66CompartTercExternoId, H007I9_A98DocDicionarioId
               }
               , new Object[] {
               H007I10_A98DocDicionarioId, H007I10_A66CompartTercExternoId
               }
               , new Object[] {
               H007I11_A4PaisId, H007I11_A98DocDicionarioId
               }
               , new Object[] {
               H007I12_A98DocDicionarioId, H007I12_A4PaisId
               }
               , new Object[] {
               H007I13_A68CompartTercExternoAtivo, H007I13_A66CompartTercExternoId, H007I13_A67CompartTercExternoNome
               }
               , new Object[] {
               H007I14_A6PaisAtivo, H007I14_A4PaisId, H007I14_A5PaisNome
               }
               , new Object[] {
               H007I15_A98DocDicionarioId, H007I15_A66CompartTercExternoId
               }
               , new Object[] {
               H007I16_A98DocDicionarioId, H007I16_A4PaisId
               }
               , new Object[] {
               H007I17_A98DocDicionarioId, H007I17_A66CompartTercExternoId
               }
               , new Object[] {
               H007I18_A98DocDicionarioId, H007I18_A4PaisId
               }
               , new Object[] {
               H007I19_A71InformacaoAtivo, H007I19_A69InformacaoId, H007I19_A70InformacaoNome
               }
               , new Object[] {
               H007I20_A74HipoteseTratamentoAtivo, H007I20_A72HipoteseTratamentoId, H007I20_A73HipoteseTratamentoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDocdicionariosensivel_grid_Enabled = 0;
         edtavDocdicionariopodeeliminar_grid_Enabled = 0;
         edtavDocdicionariotransfintergrid_Enabled = 0;
         edtavVisualizar_Enabled = 0;
         edtavAtualizar_Enabled = 0;
         edtavExcluir_Enabled = 0;
         edtavTotaldados_Enabled = 0;
         edtavTotaldadossensiveis_Enabled = 0;
      }

      private short GRID1_nEOF ;
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
      private short AV57InformacaoId_Out ;
      private short AV68TotalDadosSensiveis ;
      private short AV67TotalDados ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid1_Backcolorstyle ;
      private short AV87GXLvl376 ;
      private short AV90GXLvl398 ;
      private short AV95GXLvl450 ;
      private short AV98GXLvl472 ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV16DocumentoId ;
      private int wcpOAV16DocumentoId ;
      private int edtavAtualizar_Visible ;
      private int edtavExcluir_Visible ;
      private int nRC_GXsfl_126 ;
      private int subGrid1_Rows ;
      private int nGXsfl_126_idx=1 ;
      private int AV58HipoteseTratamentoId_Out ;
      private int AV61PaisId_Out ;
      private int AV63CompartTercExternoId_Out ;
      private int A4PaisId ;
      private int A66CompartTercExternoId ;
      private int edtavDocdicionariosensivel_grid_Enabled ;
      private int edtavDocdicionariopodeeliminar_grid_Enabled ;
      private int edtavDocdicionariotransfintergrid_Enabled ;
      private int edtavVisualizar_Enabled ;
      private int edtavAtualizar_Enabled ;
      private int edtavExcluir_Enabled ;
      private int edtavTotaldados_Enabled ;
      private int edtavTotaldadossensiveis_Enabled ;
      private int A72HipoteseTratamentoId ;
      private int AV39CompartTercExternoId_Item ;
      private int AV81PaisId_Item ;
      private int AV18InformacaoId ;
      private int lblSensivelinfo_Visible ;
      private int AV17HipoteseTratamentoId ;
      private int lblTransfinterinfo_Visible ;
      private int edtavDocdicionariotipotransfintergarantia_Enabled ;
      private int lblTipotransfintergarantia_Visible ;
      private int lblTxttipotransfinter_Visible ;
      private int edtavDocdicionariofinalidade_Enabled ;
      private int lblFinalidadeinfo_Visible ;
      private int bttBtnadicionar_Visible ;
      private int edtavDocumentoid_Visible ;
      private int AV10DocDicionarioId ;
      private int edtavDocdicionarioid_Visible ;
      private int A98DocDicionarioId ;
      private int A69InformacaoId ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A75DocumentoId ;
      private int lblInformacaoadd_Visible ;
      private int lblHipoteseadd_Visible ;
      private int lblPaisadd_Visible ;
      private int lblComparttercexteradd_Visible ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int AV86GXV1 ;
      private int AV89GXV2 ;
      private int AV93GXV4 ;
      private int AV94GXV5 ;
      private int AV97GXV6 ;
      private int AV101GXV8 ;
      private int edtavVisualizar_Visible ;
      private int AV102GXV9 ;
      private int AV104GXV10 ;
      private int AV109GXV12 ;
      private int nGXsfl_126_fel_idx=1 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavDocdicionariosensivel_grid_Visible ;
      private int edtavDocdicionariopodeeliminar_grid_Visible ;
      private int edtavDocdicionariotransfintergrid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Combo_paisid_Selectedvalue_get ;
      private string Combo_comparttercexternoid_Selectedvalue_get ;
      private string Combo_paisid_Ddointernalname ;
      private string Combo_comparttercexternoid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_126_idx="0001" ;
      private string edtavAtualizar_Internalname ;
      private string edtavExcluir_Internalname ;
      private string edtavDocdicionariosensivel_grid_Internalname ;
      private string edtavDocdicionariopodeeliminar_grid_Internalname ;
      private string edtavDocdicionariotransfintergrid_Internalname ;
      private string edtavVisualizar_Internalname ;
      private string edtavTotaldados_Internalname ;
      private string edtavTotaldadossensiveis_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_paisid_Cls ;
      private string Combo_paisid_Selectedvalue_set ;
      private string Combo_paisid_Multiplevaluestype ;
      private string Combo_comparttercexternoid_Cls ;
      private string Combo_comparttercexternoid_Selectedvalue_set ;
      private string Combo_comparttercexternoid_Multiplevaluestype ;
      private string Combo_comparttercexternoid_Emptyitemtext ;
      private string Grid1_empowerer_Gridinternalname ;
      private string Grid1_empowerer_Infinitescrolling ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavInformacaoid_Internalname ;
      private string TempTags ;
      private string cmbavInformacaoid_Jsonclick ;
      private string chkavDocdicionariopodeeliminar_Internalname ;
      private string lblPodeeliminarinfo_Internalname ;
      private string lblPodeeliminarinfo_Jsonclick ;
      private string lblPodeeliminarinfo_Tooltiptext ;
      private string chkavDocdicionariosensivel_Internalname ;
      private string lblSensivelinfo_Internalname ;
      private string lblSensivelinfo_Jsonclick ;
      private string lblSensivelinfo_Tooltiptext ;
      private string cmbavHipotesetratamentoid_Internalname ;
      private string cmbavHipotesetratamentoid_Jsonclick ;
      private string cmbavDocdicionariotransfinter_Internalname ;
      private string cmbavDocdicionariotransfinter_Jsonclick ;
      private string lblTransfinterinfo_Internalname ;
      private string lblTransfinterinfo_Jsonclick ;
      private string lblTransfinterinfo_Tooltiptext ;
      private string divCombo_paisid_cell_Internalname ;
      private string divCombo_paisid_cell_Class ;
      private string divTablesplittedpaisid_Internalname ;
      private string lblTextblockcombo_paisid_Internalname ;
      private string lblTextblockcombo_paisid_Jsonclick ;
      private string Combo_paisid_Caption ;
      private string Combo_paisid_Internalname ;
      private string divDocdicionariotipotransfintergarantia_cell_Internalname ;
      private string divDocdicionariotipotransfintergarantia_cell_Class ;
      private string edtavDocdicionariotipotransfintergarantia_Internalname ;
      private string lblTipotransfintergarantia_Internalname ;
      private string lblTipotransfintergarantia_Jsonclick ;
      private string lblTipotransfintergarantia_Tooltiptext ;
      private string divUnnamedtable2_Internalname ;
      private string lblTxttipotransfinter_Internalname ;
      private string lblTxttipotransfinter_Caption ;
      private string lblTxttipotransfinter_Jsonclick ;
      private string divTablesplittedcomparttercexternoid_Internalname ;
      private string lblTextblockcombo_comparttercexternoid_Internalname ;
      private string lblTextblockcombo_comparttercexternoid_Jsonclick ;
      private string Combo_comparttercexternoid_Caption ;
      private string Combo_comparttercexternoid_Internalname ;
      private string edtavDocdicionariofinalidade_Internalname ;
      private string lblFinalidadeinfo_Internalname ;
      private string lblFinalidadeinfo_Jsonclick ;
      private string lblFinalidadeinfo_Tooltiptext ;
      private string divUnnamedtable3_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string bttBtnadicionar_Internalname ;
      private string bttBtnadicionar_Caption ;
      private string bttBtnadicionar_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string edtavTotaldados_Jsonclick ;
      private string edtavTotaldadossensiveis_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavDocumentoid_Internalname ;
      private string edtavDocumentoid_Jsonclick ;
      private string edtavDocdicionarioid_Internalname ;
      private string edtavDocdicionarioid_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtDocDicionarioId_Internalname ;
      private string edtInformacaoId_Internalname ;
      private string edtInformacaoNome_Internalname ;
      private string AV65DocDicionarioSensivel_Grid ;
      private string chkDocDicionarioSensivel_Internalname ;
      private string AV66DocDicionarioPodeEliminar_Grid ;
      private string chkDocDicionarioPodeEliminar_Internalname ;
      private string edtHipoteseTratamentoNome_Internalname ;
      private string edtDocDicionarioTransfInter_Internalname ;
      private string AV50Visualizar ;
      private string AV35Atualizar ;
      private string AV44Excluir ;
      private string GXDecQS ;
      private string GXCCtl ;
      private string scmdbuf ;
      private string lblInformacaoadd_Internalname ;
      private string lblHipoteseadd_Internalname ;
      private string lblPaisadd_Internalname ;
      private string lblComparttercexteradd_Internalname ;
      private string lblInformacaoinfo_Tooltiptext ;
      private string lblInformacaoinfo_Internalname ;
      private string lblHipoteseinfo_Tooltiptext ;
      private string lblHipoteseinfo_Internalname ;
      private string lblPaisinfo_Tooltiptext ;
      private string lblPaisinfo_Internalname ;
      private string lblComparttercexternoinfo_Tooltiptext ;
      private string lblComparttercexternoinfo_Internalname ;
      private string sGXsfl_126_fel_idx="0001" ;
      private string tblTablemergedcomparttercexternoinfo_Internalname ;
      private string lblComparttercexternoinfo_Jsonclick ;
      private string lblComparttercexteradd_Jsonclick ;
      private string tblTablemergedpaisinfo_Internalname ;
      private string lblPaisinfo_Jsonclick ;
      private string lblPaisadd_Jsonclick ;
      private string tblTablemergedhipoteseinfo_Internalname ;
      private string lblHipoteseinfo_Jsonclick ;
      private string lblHipoteseadd_Jsonclick ;
      private string tblTablemergedinformacaoinfo_Internalname ;
      private string lblInformacaoinfo_Jsonclick ;
      private string lblInformacaoadd_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV16DocumentoId ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtDocDicionarioId_Jsonclick ;
      private string edtInformacaoId_Jsonclick ;
      private string edtInformacaoNome_Jsonclick ;
      private string edtavDocdicionariosensivel_grid_Jsonclick ;
      private string edtavDocdicionariopodeeliminar_grid_Jsonclick ;
      private string edtHipoteseTratamentoNome_Jsonclick ;
      private string edtDocDicionarioTransfInter_Jsonclick ;
      private string edtavDocdicionariotransfintergrid_Jsonclick ;
      private string edtavVisualizar_Jsonclick ;
      private string edtavAtualizar_Jsonclick ;
      private string edtavExcluir_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8DocDicionarioDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_126_Refreshing=false ;
      private bool AV56IsInformacao ;
      private bool AV59IsHipotese ;
      private bool AV60IsPais ;
      private bool AV62IsCompartTercExterno ;
      private bool A71InformacaoAtivo ;
      private bool A74HipoteseTratamentoAtivo ;
      private bool A6PaisAtivo ;
      private bool A68CompartTercExternoAtivo ;
      private bool AV11DocDicionarioPodeEliminar ;
      private bool AV12DocDicionarioSensivel ;
      private bool AV78isDisplay ;
      private bool AV54CheckRequiredFieldsResult ;
      private bool AV77InformacaoExiste ;
      private bool Combo_paisid_Enabled ;
      private bool Combo_paisid_Allowmultipleselection ;
      private bool Combo_paisid_Includeonlyselectedoption ;
      private bool Combo_paisid_Emptyitem ;
      private bool Combo_comparttercexternoid_Enabled ;
      private bool Combo_comparttercexternoid_Allowmultipleselection ;
      private bool Combo_comparttercexternoid_Includeonlyselectedoption ;
      private bool wbLoad ;
      private bool AV13DocDicionarioTransfInter ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A99DocDicionarioSensivel ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A101DocDicionarioTransfInter ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A118TooltipAtivo ;
      private bool gx_refresh_fired ;
      private bool AV69IsAuthorized_Visualizar ;
      private bool AV70IsAuthorized_Atualizar ;
      private bool AV71IsAuthorized_Excluir ;
      private bool AV72IsAuthorized_HipoteseAdd ;
      private bool AV73IsAuthorized_PaisAdd ;
      private bool AV74IsAuthorized_CompartTercExterAdd ;
      private bool AV75IsAuthorized_Adicionar ;
      private bool AV76IsAuthorized_InformacaoAdd ;
      private bool GXt_boolean2 ;
      private string AV51DocDicionarioTipoTransfInterGarantia ;
      private string AV9DocDicionarioFinalidade ;
      private string A115TooltipDescricao ;
      private string A5PaisNome ;
      private string A67CompartTercExternoNome ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string AV43DocDicionarioTransfInterGrid ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private GxSimpleCollection<int> AV79PaisId_Col ;
      private GxSimpleCollection<int> AV64CompartTercExternoId_Col ;
      private GxSimpleCollection<int> AV21PaisId ;
      private GxSimpleCollection<int> AV6CompartTercExternoId ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucCombo_paisid ;
      private GXUserControl ucCombo_comparttercexternoid ;
      private GXUserControl ucGrid1_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavInformacaoid ;
      private GXCheckbox chkavDocdicionariopodeeliminar ;
      private GXCheckbox chkavDocdicionariosensivel ;
      private GXCombobox cmbavHipotesetratamentoid ;
      private GXCombobox cmbavDocdicionariotransfinter ;
      private GXCheckbox chkDocDicionarioSensivel ;
      private GXCheckbox chkDocDicionarioPodeEliminar ;
      private IDataStoreProvider pr_default ;
      private int[] H007I2_A72HipoteseTratamentoId ;
      private int[] H007I2_A75DocumentoId ;
      private bool[] H007I2_A101DocDicionarioTransfInter ;
      private string[] H007I2_A73HipoteseTratamentoNome ;
      private bool[] H007I2_A100DocDicionarioPodeEliminar ;
      private bool[] H007I2_A99DocDicionarioSensivel ;
      private string[] H007I2_A70InformacaoNome ;
      private int[] H007I2_A69InformacaoId ;
      private int[] H007I2_A98DocDicionarioId ;
      private long[] H007I3_AGRID1_nRecordCount ;
      private int[] H007I4_A112TooltipId ;
      private int[] H007I4_A135CampoId ;
      private int[] H007I4_A139TooltipTelaId ;
      private string[] H007I4_A140TooltipTelaNome ;
      private bool[] H007I4_A118TooltipAtivo ;
      private string[] H007I4_A136CampoNome ;
      private string[] H007I4_A115TooltipDescricao ;
      private int[] H007I5_A66CompartTercExternoId ;
      private int[] H007I5_A98DocDicionarioId ;
      private int[] H007I6_A98DocDicionarioId ;
      private int[] H007I6_A66CompartTercExternoId ;
      private int[] H007I7_A4PaisId ;
      private int[] H007I7_A98DocDicionarioId ;
      private int[] H007I8_A98DocDicionarioId ;
      private int[] H007I8_A4PaisId ;
      private int[] H007I9_A66CompartTercExternoId ;
      private int[] H007I9_A98DocDicionarioId ;
      private int[] H007I10_A98DocDicionarioId ;
      private int[] H007I10_A66CompartTercExternoId ;
      private int[] H007I11_A4PaisId ;
      private int[] H007I11_A98DocDicionarioId ;
      private int[] H007I12_A98DocDicionarioId ;
      private int[] H007I12_A4PaisId ;
      private bool[] H007I13_A68CompartTercExternoAtivo ;
      private int[] H007I13_A66CompartTercExternoId ;
      private string[] H007I13_A67CompartTercExternoNome ;
      private bool[] H007I14_A6PaisAtivo ;
      private int[] H007I14_A4PaisId ;
      private string[] H007I14_A5PaisNome ;
      private int[] H007I15_A98DocDicionarioId ;
      private int[] H007I15_A66CompartTercExternoId ;
      private int[] H007I16_A98DocDicionarioId ;
      private int[] H007I16_A4PaisId ;
      private int[] H007I17_A98DocDicionarioId ;
      private int[] H007I17_A66CompartTercExternoId ;
      private int[] H007I18_A98DocDicionarioId ;
      private int[] H007I18_A4PaisId ;
      private bool[] H007I19_A71InformacaoAtivo ;
      private int[] H007I19_A69InformacaoId ;
      private string[] H007I19_A70InformacaoNome ;
      private bool[] H007I20_A74HipoteseTratamentoAtivo ;
      private int[] H007I20_A72HipoteseTratamentoId ;
      private string[] H007I20_A73HipoteseTratamentoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV80PaisId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV38CompartTercExternoId_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV92GXV3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV100GXV7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV108GXV11 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV36Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV41DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtDocDicionario AV7DocDicionario ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
   }

   public class dicionariowc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class dicionariowc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH007I2;
        prmH007I2 = new Object[] {
        new ParDef("@AV16DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH007I3;
        prmH007I3 = new Object[] {
        new ParDef("@AV16DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmH007I4;
        prmH007I4 = new Object[] {
        };
        Object[] prmH007I5;
        prmH007I5 = new Object[] {
        new ParDef("@AV39CompartTercExternoId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I6;
        prmH007I6 = new Object[] {
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I7;
        prmH007I7 = new Object[] {
        new ParDef("@AV81PaisId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I8;
        prmH007I8 = new Object[] {
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I9;
        prmH007I9 = new Object[] {
        new ParDef("@AV39CompartTercExternoId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I10;
        prmH007I10 = new Object[] {
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I11;
        prmH007I11 = new Object[] {
        new ParDef("@AV81PaisId_Item",GXType.Int32,8,0) ,
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I12;
        prmH007I12 = new Object[] {
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I13;
        prmH007I13 = new Object[] {
        };
        Object[] prmH007I14;
        prmH007I14 = new Object[] {
        };
        Object[] prmH007I15;
        prmH007I15 = new Object[] {
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I16;
        prmH007I16 = new Object[] {
        new ParDef("@AV10DocDicionarioId",GXType.Int32,8,0)
        };
        Object[] prmH007I17;
        prmH007I17 = new Object[] {
        new ParDef("@AV7DocDi_1Docdicionarioid",GXType.Int32,8,0)
        };
        Object[] prmH007I18;
        prmH007I18 = new Object[] {
        new ParDef("@AV7DocDi_1Docdicionarioid",GXType.Int32,8,0)
        };
        Object[] prmH007I19;
        prmH007I19 = new Object[] {
        };
        Object[] prmH007I20;
        prmH007I20 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H007I2", "SELECT T1.[HipoteseTratamentoId], T1.[DocumentoId], T1.[DocDicionarioTransfInter], T2.[HipoteseTratamentoNome], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T3.[InformacaoNome], T1.[InformacaoId], T1.[DocDicionarioId] FROM (([DocDicionario] T1 INNER JOIN [HipoteseTratamento] T2 ON T2.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T3 ON T3.[InformacaoId] = T1.[InformacaoId]) WHERE T1.[DocumentoId] = @AV16DocumentoId ORDER BY T1.[DocumentoId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I2,51, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I3", "SELECT COUNT(*) FROM (([DocDicionario] T1 INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = T1.[InformacaoId]) WHERE T1.[DocumentoId] = @AV16DocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I4", "SELECT T1.[TooltipId], T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipAtivo], T2.[CampoNome], T1.[TooltipDescricao] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId]) WHERE (T1.[TooltipAtivo] = 1) AND (T3.[TelaNome] = 'DICIONÁRIO') ORDER BY T1.[TooltipId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I4,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007I5", "SELECT [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [CompartTercExternoId] = @AV39CompartTercExternoId_Item and [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [CompartTercExternoId], [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I5,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007I6", "SELECT [DocDicionarioId], [CompartTercExternoId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I7", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [PaisId] = @AV81PaisId_Item and [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [PaisId], [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I7,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007I8", "SELECT [DocDicionarioId], [PaisId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I9", "SELECT [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [CompartTercExternoId] = @AV39CompartTercExternoId_Item and [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [CompartTercExternoId], [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I9,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007I10", "SELECT [DocDicionarioId], [CompartTercExternoId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I11", "SELECT [PaisId], [DocDicionarioId] FROM [DicionarioPais] WHERE [PaisId] = @AV81PaisId_Item and [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [PaisId], [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I11,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H007I12", "SELECT [DocDicionarioId], [PaisId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I12,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I13", "SELECT [CompartTercExternoAtivo], [CompartTercExternoId], [CompartTercExternoNome] FROM [CompartTercExterno] WHERE [CompartTercExternoAtivo] = 1 ORDER BY [CompartTercExternoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I13,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007I14", "SELECT [PaisAtivo], [PaisId], [PaisNome] FROM [Pais] WHERE [PaisAtivo] = 1 ORDER BY [PaisNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I14,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007I15", "SELECT [DocDicionarioId], [CompartTercExternoId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I16", "SELECT [DocDicionarioId], [PaisId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @AV10DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007I17", "SELECT [DocDicionarioId], [CompartTercExternoId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @AV7DocDi_1Docdicionarioid ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I17,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007I18", "SELECT [DocDicionarioId], [PaisId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @AV7DocDi_1Docdicionarioid ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I18,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007I19", "SELECT [InformacaoAtivo], [InformacaoId], [InformacaoNome] FROM [Informacao] WHERE [InformacaoAtivo] = 1 ORDER BY [InformacaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I19,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H007I20", "SELECT [HipoteseTratamentoAtivo], [HipoteseTratamentoId], [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoAtivo] = 1 ORDER BY [HipoteseTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007I20,100, GxCacheFrequency.OFF ,false,false )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
              return;
           case 11 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 12 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
