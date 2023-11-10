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
   public class anexowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public anexowc( )
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

      public anexowc( IGxContext context )
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
         this.AV11DocumentoId = aP1_DocumentoId;
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
                  AV11DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "AV11DocumentoId", StringUtil.LTrimStr( (decimal)(AV11DocumentoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV11DocumentoId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridanexos") == 0 )
               {
                  gxnrGridanexos_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridanexos") == 0 )
               {
                  gxgrGridanexos_refresh_invoke( ) ;
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

      protected void gxnrGridanexos_newrow_invoke( )
      {
         nRC_GXsfl_60 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_60"), "."));
         nGXsfl_60_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_60_idx"), "."));
         sGXsfl_60_idx = GetPar( "sGXsfl_60_idx");
         sPrefix = GetPar( "sPrefix");
         edtavAtualizar_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_60_Refreshing);
         edtavExcluir_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_60_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridanexos_newrow( ) ;
         /* End function gxnrGridanexos_newrow_invoke */
      }

      protected void gxgrGridanexos_refresh_invoke( )
      {
         subGridanexos_Rows = (int)(NumberUtil.Val( GetPar( "subGridanexos_Rows"), "."));
         AV16FiltroAnexo = GetPar( "FiltroAnexo");
         AV11DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
         edtavAtualizar_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_60_Refreshing);
         edtavExcluir_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_60_Refreshing);
         AV38caminhoDiretorio = GetPar( "caminhoDiretorio");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridanexos_refresh_invoke */
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
            PA7O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavNomearquivo_Enabled = 0;
               AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Enabled), 5, 0), true);
               edtavVisualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_60_Refreshing);
               edtavAtualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_60_Refreshing);
               edtavExcluir_Enabled = 0;
               AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_60_Refreshing);
               /* Using cursor H007O3 */
               pr_default.execute(0);
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A40000ParametroValor = H007O3_A40000ParametroValor[0];
                  n40000ParametroValor = H007O3_n40000ParametroValor[0];
               }
               else
               {
                  A40000ParametroValor = "";
                  n40000ParametroValor = false;
                  AssignAttri(sPrefix, false, "A40000ParametroValor", A40000ParametroValor);
               }
               pr_default.close(0);
               WS7O2( ) ;
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
            context.SendWebValue( "Aba de Anexo para o cadastro de um Documento") ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
               GXEncryptionTmp = "anexowc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV11DocumentoId,8,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("anexowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCAMINHODIRETORIO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38caminhoDiretorio, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTROANEXO", AV16FiltroAnexo);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_60", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_60), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV22UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV22UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV13FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV13FailedFiles);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV11DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV41CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCAMINHOARQUIVO", AV26caminhoarquivo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOCANEXO", AV6DocAnexo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOCANEXO", AV6DocAnexo);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILEUPLOADDATA", AV24FileUploadData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILEUPLOADDATA", AV24FileUploadData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCAMINHODIRETORIO", AV38caminhoDiretorio);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCAMINHODIRETORIO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38caminhoDiretorio, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vARQUIVOANEXO", AV25ArquivoAnexo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTIPOARQUIVO", StringUtil.RTrim( AV39TipoArquivo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Class", StringUtil.RTrim( Arquivoupload_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Autoupload", StringUtil.BoolToStr( Arquivoupload_Autoupload));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Hideadditionalbuttons", StringUtil.BoolToStr( Arquivoupload_Hideadditionalbuttons));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Enableuploadedfilecanceling", StringUtil.BoolToStr( Arquivoupload_Enableuploadedfilecanceling));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Maxfilesize", StringUtil.LTrim( StringUtil.NToC( (decimal)(Arquivoupload_Maxfilesize), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Arquivoupload_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Autodisableaddingfiles", StringUtil.BoolToStr( Arquivoupload_Autodisableaddingfiles));
         GxWebStd.gx_hidden_field( context, sPrefix+"ARQUIVOUPLOAD_Acceptedfiletypes", StringUtil.RTrim( Arquivoupload_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridanexos_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Gridanexos_empowerer_Infinitescrolling));
         GxWebStd.gx_hidden_field( context, sPrefix+"SECTIONBTNADICIONAR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divSectionbtnadicionar_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEARQUIVO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(tblTablearquivo_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vATUALIZAR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEXCLUIR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SECTIONBTNADICIONAR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divSectionbtnadicionar_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEARQUIVO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(tblTablearquivo_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm7O2( )
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
         return "AnexoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aba de Anexo para o cadastro de um Documento" ;
      }

      protected void WB7O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "anexowc.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTabledados_Internalname, divTabledados_Visible, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNomearquivo_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNomearquivo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomearquivo_Internalname, edtavNomearquivo_Caption, "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_60_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomearquivo_Internalname, AV29NomeArquivo, StringUtil.RTrim( context.localUtil.Format( AV29NomeArquivo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNomearquivo_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavNomearquivo_Visible, edtavNomearquivo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_AnexoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblArquivotext_Internalname, "ARQUIVO", "", "", lblArquivotext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Attribute", 0, "", lblArquivotext_Visible, 1, 0, 0, "HLP_AnexoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_26_7O2( true) ;
         }
         else
         {
            wb_table1_26_7O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_26_7O2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDocanexodescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocanexodescricao_Internalname, "DESCRIÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_60_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocanexodescricao_Internalname, AV9DocAnexoDescricao, StringUtil.RTrim( context.localUtil.Format( AV9DocAnexoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocanexodescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocanexodescricao_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_AnexoWC.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtdocanexodescricao_Internalname, lblTxtdocanexodescricao_Caption, "", "", lblTxtdocanexodescricao_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AnexoWC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSectionbtnadicionar_Internalname, divSectionbtnadicionar_Visible, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadiciona_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(60), 2, 0)+","+"null"+");", "ADICIONAR", bttBtnadiciona_Jsonclick, 5, "ADICIONAR", "", StyleString, ClassString, bttBtnadiciona_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADICIONA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AnexoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltroanexo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltroanexo_Internalname, "FILTRAR POR DESCRIÇÃO...", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_60_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFiltroanexo_Internalname, AV16FiltroAnexo, StringUtil.RTrim( context.localUtil.Format( AV16FiltroAnexo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltroanexo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFiltroanexo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_AnexoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 GridWithBorderColor HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridanexosContainer.SetWrapped(nGXWrapped);
            StartGridControl60( ) ;
         }
         if ( wbEnd == 60 )
         {
            wbEnd = 0;
            nRC_GXsfl_60 = (int)(nGXsfl_60_idx-1);
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridanexosContainer.AddObjectProperty("GRIDANEXOS_nEOF", GRIDANEXOS_nEOF);
               GridanexosContainer.AddObjectProperty("GRIDANEXOS_nFirstRecordOnPage", GRIDANEXOS_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridanexosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridanexos", GridanexosContainer, subGridanexos_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridanexosContainerData", GridanexosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridanexosContainerData"+"V", GridanexosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridanexosContainerData"+"V"+"\" value='"+GridanexosContainer.GridValuesHidden()+"'/>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'" + sGXsfl_60_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocanexoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10DocAnexoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10DocAnexoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocanexoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocanexoid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_AnexoWC.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocumentoid_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_AnexoWC.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_60_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocanexoarquivo_Internalname, AV7DocAnexoArquivo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, edtavDocanexoarquivo_Visible, 1, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_AnexoWC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_60_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDocanexodatainclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDocanexodatainclusao_Internalname, context.localUtil.Format(AV8DocAnexoDataInclusao, "99/99/99"), context.localUtil.Format( AV8DocAnexoDataInclusao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocanexodatainclusao_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocanexodatainclusao_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_AnexoWC.htm");
            GxWebStd.gx_bitmap( context, edtavDocanexodatainclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavDocanexodatainclusao_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AnexoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* User Defined Control */
            ucGridanexos_empowerer.SetProperty("InfiniteScrolling", Gridanexos_empowerer_Infinitescrolling);
            ucGridanexos_empowerer.Render(context, "wwp.gridempowerer", Gridanexos_empowerer_Internalname, sPrefix+"GRIDANEXOS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 60 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridanexosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridanexosContainer.AddObjectProperty("GRIDANEXOS_nEOF", GRIDANEXOS_nEOF);
                  GridanexosContainer.AddObjectProperty("GRIDANEXOS_nFirstRecordOnPage", GRIDANEXOS_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridanexosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridanexos", GridanexosContainer, subGridanexos_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridanexosContainerData", GridanexosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridanexosContainerData"+"V", GridanexosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridanexosContainerData"+"V"+"\" value='"+GridanexosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7O2( )
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
               Form.Meta.addItem("description", "Aba de Anexo para o cadastro de um Documento", 0) ;
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
               STRUP7O0( ) ;
            }
         }
      }

      protected void WS7O2( )
      {
         START7O2( ) ;
         EVT7O2( ) ;
      }

      protected void EVT7O2( )
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
                                 STRUP7O0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONA'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdiciona' */
                                    E117O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavVisualizar_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDANEXOSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDANEXOSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridanexos_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridanexos_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridanexos_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridanexos_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "GRIDANEXOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VEXCLUIR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VATUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VEXCLUIR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7O0( ) ;
                              }
                              nGXsfl_60_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_60_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_60_idx), 4, 0), 4, "0");
                              SubsflControlProps_602( ) ;
                              A93DocAnexoId = (int)(context.localUtil.CToN( cgiGet( edtDocAnexoId_Internalname), ",", "."));
                              A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                              A95DocAnexoArquivo = cgiGet( edtDocAnexoArquivo_Internalname);
                              A94DocAnexoDescricao = cgiGet( edtDocAnexoDescricao_Internalname);
                              A96DocAnexoDataInclusao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDocAnexoDataInclusao_Internalname), 0));
                              AV23Visualizar = cgiGet( edtavVisualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV23Visualizar);
                              AV5Atualizar = cgiGet( edtavAtualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavAtualizar_Internalname, AV5Atualizar);
                              AV12Excluir = cgiGet( edtavExcluir_Internalname);
                              AssignAttri(sPrefix, false, edtavExcluir_Internalname, AV12Excluir);
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
                                          GX_FocusControl = edtavVisualizar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E127O2 ();
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
                                          GX_FocusControl = edtavVisualizar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E137O2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDANEXOS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVisualizar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E147O2 ();
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
                                          GX_FocusControl = edtavVisualizar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E157O2 ();
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
                                          GX_FocusControl = edtavVisualizar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E167O2 ();
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
                                          GX_FocusControl = edtavVisualizar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E177O2 ();
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
                                             /* Set Refresh If Filtroanexo Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTROANEXO"), AV16FiltroAnexo) != 0 )
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
                                       STRUP7O0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavVisualizar_Internalname;
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

      protected void WE7O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7O2( ) ;
            }
         }
      }

      protected void PA7O2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "anexowc.aspx")), "anexowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "anexowc.aspx")))) ;
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
               GX_FocusControl = edtavNomearquivo_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridanexos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_602( ) ;
         while ( nGXsfl_60_idx <= nRC_GXsfl_60 )
         {
            sendrow_602( ) ;
            nGXsfl_60_idx = ((subGridanexos_Islastpage==1)&&(nGXsfl_60_idx+1>subGridanexos_fnc_Recordsperpage( )) ? 1 : nGXsfl_60_idx+1);
            sGXsfl_60_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_60_idx), 4, 0), 4, "0");
            SubsflControlProps_602( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridanexosContainer)) ;
         /* End function gxnrGridanexos_newrow */
      }

      protected void gxgrGridanexos_refresh( int subGridanexos_Rows ,
                                             string AV16FiltroAnexo ,
                                             int AV11DocumentoId ,
                                             string AV38caminhoDiretorio ,
                                             string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E137O2 ();
         GRIDANEXOS_nCurrentRecord = 0;
         RF7O2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridanexos_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCANEXOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A93DocAnexoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCANEXOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A93DocAnexoId), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCANEXOARQUIVO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( A95DocAnexoArquivo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCANEXOARQUIVO", A95DocAnexoArquivo);
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
         GRIDANEXOS_nFirstRecordOnPage = 0;
         GRIDANEXOS_nCurrentRecord = 0;
         GXCCtl = "GRIDANEXOS_nFirstRecordOnPage_" + sGXsfl_60_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF7O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavNomearquivo_Enabled = 0;
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Enabled), 5, 0), true);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_60_Refreshing);
         edtavAtualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_60_Refreshing);
         edtavExcluir_Enabled = 0;
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_60_Refreshing);
      }

      protected void RF7O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridanexosContainer.ClearRows();
         }
         wbStart = 60;
         /* Execute user event: Refresh */
         E137O2 ();
         nGXsfl_60_idx = (int)(1+GRIDANEXOS_nFirstRecordOnPage);
         sGXsfl_60_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_60_idx), 4, 0), 4, "0");
         SubsflControlProps_602( ) ;
         bGXsfl_60_Refreshing = true;
         GridanexosContainer.AddObjectProperty("GridName", "Gridanexos");
         GridanexosContainer.AddObjectProperty("CmpContext", sPrefix);
         GridanexosContainer.AddObjectProperty("InMasterPage", "false");
         GridanexosContainer.AddObjectProperty("Class", "WorkWith");
         GridanexosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridanexosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridanexosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Backcolorstyle), 1, 0, ".", "")));
         GridanexosContainer.PageSize = subGridanexos_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_602( ) ;
            GXPagingFrom2 = (int)(((subGridanexos_Rows==0) ? 0 : GRIDANEXOS_nFirstRecordOnPage));
            GXPagingTo2 = ((subGridanexos_Rows==0) ? 10000 : subGridanexos_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV16FiltroAnexo ,
                                                 A75DocumentoId ,
                                                 AV11DocumentoId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor H007O5 */
            pr_default.execute(1, new Object[] {AV11DocumentoId, AV16FiltroAnexo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_60_idx = (int)(1+GRIDANEXOS_nFirstRecordOnPage);
            sGXsfl_60_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_60_idx), 4, 0), 4, "0");
            SubsflControlProps_602( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGridanexos_Rows == 0 ) || ( GRIDANEXOS_nCurrentRecord < subGridanexos_fnc_Recordsperpage( ) ) ) ) )
            {
               A96DocAnexoDataInclusao = H007O5_A96DocAnexoDataInclusao[0];
               A94DocAnexoDescricao = H007O5_A94DocAnexoDescricao[0];
               A95DocAnexoArquivo = H007O5_A95DocAnexoArquivo[0];
               A75DocumentoId = H007O5_A75DocumentoId[0];
               A93DocAnexoId = H007O5_A93DocAnexoId[0];
               A40000ParametroValor = H007O5_A40000ParametroValor[0];
               n40000ParametroValor = H007O5_n40000ParametroValor[0];
               A40000ParametroValor = H007O5_A40000ParametroValor[0];
               n40000ParametroValor = H007O5_n40000ParametroValor[0];
               E147O2 ();
               pr_default.readNext(1);
            }
            GRIDANEXOS_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 60;
            WB7O0( ) ;
         }
         bGXsfl_60_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7O2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCAMINHODIRETORIO", AV38caminhoDiretorio);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCAMINHODIRETORIO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38caminhoDiretorio, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCANEXOID"+"_"+sGXsfl_60_idx, GetSecureSignedToken( sPrefix+sGXsfl_60_idx, context.localUtil.Format( (decimal)(A93DocAnexoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCANEXOARQUIVO"+"_"+sGXsfl_60_idx, GetSecureSignedToken( sPrefix+sGXsfl_60_idx, StringUtil.RTrim( context.localUtil.Format( A95DocAnexoArquivo, "")), context));
      }

      protected int subGridanexos_fnc_Pagecount( )
      {
         GRIDANEXOS_nRecordCount = subGridanexos_fnc_Recordcount( );
         if ( ((int)((GRIDANEXOS_nRecordCount) % (subGridanexos_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDANEXOS_nRecordCount/ (decimal)(subGridanexos_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDANEXOS_nRecordCount/ (decimal)(subGridanexos_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridanexos_fnc_Recordcount( )
      {
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV16FiltroAnexo ,
                                              A75DocumentoId ,
                                              AV11DocumentoId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H007O7 */
         pr_default.execute(2, new Object[] {AV11DocumentoId, AV16FiltroAnexo});
         GRIDANEXOS_nRecordCount = H007O7_AGRIDANEXOS_nRecordCount[0];
         pr_default.close(2);
         return (int)(GRIDANEXOS_nRecordCount) ;
      }

      protected int subGridanexos_fnc_Recordsperpage( )
      {
         if ( subGridanexos_Rows > 0 )
         {
            return subGridanexos_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridanexos_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDANEXOS_nFirstRecordOnPage/ (decimal)(subGridanexos_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridanexos_firstpage( )
      {
         GRIDANEXOS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridanexos_nextpage( )
      {
         GRIDANEXOS_nRecordCount = subGridanexos_fnc_Recordcount( );
         if ( ( GRIDANEXOS_nRecordCount >= subGridanexos_fnc_Recordsperpage( ) ) && ( GRIDANEXOS_nEOF == 0 ) )
         {
            GRIDANEXOS_nFirstRecordOnPage = (long)(GRIDANEXOS_nFirstRecordOnPage+subGridanexos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRIDANEXOS_nEOF == 1 )
         {
            GRIDANEXOS_nFirstRecordOnPage = GRIDANEXOS_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridanexosContainer.AddObjectProperty("GRIDANEXOS_nFirstRecordOnPage", GRIDANEXOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDANEXOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridanexos_previouspage( )
      {
         if ( GRIDANEXOS_nFirstRecordOnPage >= subGridanexos_fnc_Recordsperpage( ) )
         {
            GRIDANEXOS_nFirstRecordOnPage = (long)(GRIDANEXOS_nFirstRecordOnPage-subGridanexos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridanexos_lastpage( )
      {
         GRIDANEXOS_nRecordCount = subGridanexos_fnc_Recordcount( );
         if ( GRIDANEXOS_nRecordCount > subGridanexos_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDANEXOS_nRecordCount) % (subGridanexos_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDANEXOS_nFirstRecordOnPage = (long)(GRIDANEXOS_nRecordCount-subGridanexos_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDANEXOS_nFirstRecordOnPage = (long)(GRIDANEXOS_nRecordCount-((int)((GRIDANEXOS_nRecordCount) % (subGridanexos_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDANEXOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridanexos_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDANEXOS_nFirstRecordOnPage = (long)(subGridanexos_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDANEXOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavNomearquivo_Enabled = 0;
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Enabled), 5, 0), true);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_60_Refreshing);
         edtavAtualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Enabled), 5, 0), !bGXsfl_60_Refreshing);
         edtavExcluir_Enabled = 0;
         AssignProp(sPrefix, false, edtavExcluir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExcluir_Enabled), 5, 0), !bGXsfl_60_Refreshing);
         /* Using cursor H007O9 */
         pr_default.execute(3);
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40000ParametroValor = H007O9_A40000ParametroValor[0];
            n40000ParametroValor = H007O9_n40000ParametroValor[0];
         }
         else
         {
            A40000ParametroValor = "";
            n40000ParametroValor = false;
            AssignAttri(sPrefix, false, "A40000ParametroValor", A40000ParametroValor);
         }
         pr_default.close(3);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV22UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV13FailedFiles);
            /* Read saved values. */
            nRC_GXsfl_60 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_60"), ",", "."));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV11DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11DocumentoId"), ",", "."));
            GRIDANEXOS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDANEXOS_nFirstRecordOnPage"), ",", "."));
            GRIDANEXOS_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDANEXOS_nEOF"), ",", "."));
            subGridanexos_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDANEXOS_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Rows), 6, 0, ".", "")));
            Arquivoupload_Class = cgiGet( sPrefix+"ARQUIVOUPLOAD_Class");
            Arquivoupload_Autoupload = StringUtil.StrToBool( cgiGet( sPrefix+"ARQUIVOUPLOAD_Autoupload"));
            Arquivoupload_Hideadditionalbuttons = StringUtil.StrToBool( cgiGet( sPrefix+"ARQUIVOUPLOAD_Hideadditionalbuttons"));
            Arquivoupload_Enableuploadedfilecanceling = StringUtil.StrToBool( cgiGet( sPrefix+"ARQUIVOUPLOAD_Enableuploadedfilecanceling"));
            Arquivoupload_Maxfilesize = (int)(context.localUtil.CToN( cgiGet( sPrefix+"ARQUIVOUPLOAD_Maxfilesize"), ",", "."));
            Arquivoupload_Maxnumberoffiles = (int)(context.localUtil.CToN( cgiGet( sPrefix+"ARQUIVOUPLOAD_Maxnumberoffiles"), ",", "."));
            Arquivoupload_Autodisableaddingfiles = StringUtil.StrToBool( cgiGet( sPrefix+"ARQUIVOUPLOAD_Autodisableaddingfiles"));
            Arquivoupload_Acceptedfiletypes = cgiGet( sPrefix+"ARQUIVOUPLOAD_Acceptedfiletypes");
            Gridanexos_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDANEXOS_EMPOWERER_Gridinternalname");
            Gridanexos_empowerer_Infinitescrolling = cgiGet( sPrefix+"GRIDANEXOS_EMPOWERER_Infinitescrolling");
            divSectionbtnadicionar_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"SECTIONBTNADICIONAR_Visible"), ",", "."));
            tblTablearquivo_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TABLEARQUIVO_Visible"), ",", "."));
            /* Read variables values. */
            AV29NomeArquivo = cgiGet( edtavNomearquivo_Internalname);
            AssignAttri(sPrefix, false, "AV29NomeArquivo", AV29NomeArquivo);
            AV9DocAnexoDescricao = cgiGet( edtavDocanexodescricao_Internalname);
            AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
            AV16FiltroAnexo = cgiGet( edtavFiltroanexo_Internalname);
            AssignAttri(sPrefix, false, "AV16FiltroAnexo", AV16FiltroAnexo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocanexoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocanexoid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCANEXOID");
               GX_FocusControl = edtavDocanexoid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10DocAnexoId = 0;
               AssignAttri(sPrefix, false, "AV10DocAnexoId", StringUtil.LTrimStr( (decimal)(AV10DocAnexoId), 8, 0));
            }
            else
            {
               AV10DocAnexoId = (int)(context.localUtil.CToN( cgiGet( edtavDocanexoid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV10DocAnexoId", StringUtil.LTrimStr( (decimal)(AV10DocAnexoId), 8, 0));
            }
            AV7DocAnexoArquivo = cgiGet( edtavDocanexoarquivo_Internalname);
            AssignAttri(sPrefix, false, "AV7DocAnexoArquivo", AV7DocAnexoArquivo);
            if ( context.localUtil.VCDate( cgiGet( edtavDocanexodatainclusao_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Doc Anexo Data Inclusao"}), 1, "vDOCANEXODATAINCLUSAO");
               GX_FocusControl = edtavDocanexodatainclusao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8DocAnexoDataInclusao = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV8DocAnexoDataInclusao", context.localUtil.Format(AV8DocAnexoDataInclusao, "99/99/99"));
            }
            else
            {
               AV8DocAnexoDataInclusao = context.localUtil.CToD( cgiGet( edtavDocanexodatainclusao_Internalname), 2);
               AssignAttri(sPrefix, false, "AV8DocAnexoDataInclusao", context.localUtil.Format(AV8DocAnexoDataInclusao, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTROANEXO"), AV16FiltroAnexo) != 0 )
            {
               GRIDANEXOS_nFirstRecordOnPage = 0;
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
         E127O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E127O2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV40Servidor = A40000ParametroValor;
         AV37Directory.Source = AV40Servidor+"ANEXOS\\";
         if ( ! AV37Directory.Exists() )
         {
            AV37Directory.Create();
         }
         AV38caminhoDiretorio = AV37Directory.GetAbsoluteName();
         AssignAttri(sPrefix, false, "AV38caminhoDiretorio", AV38caminhoDiretorio);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCAMINHODIRETORIO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38caminhoDiretorio, "")), context));
         edtavNomearquivo_Visible = 0;
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Visible), 5, 0), true);
         edtavDocanexoid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocanexoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocanexoid_Visible), 5, 0), true);
         edtavDocumentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Visible), 5, 0), true);
         edtavDocanexoarquivo_Visible = 0;
         AssignProp(sPrefix, false, edtavDocanexoarquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocanexoarquivo_Visible), 5, 0), true);
         edtavDocanexodatainclusao_Visible = 0;
         AssignProp(sPrefix, false, edtavDocanexodatainclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocanexodatainclusao_Visible), 5, 0), true);
         Gridanexos_empowerer_Gridinternalname = subGridanexos_Internalname;
         ucGridanexos_empowerer.SendProperty(context, sPrefix, false, Gridanexos_empowerer_Internalname, "GridInternalName", Gridanexos_empowerer_Gridinternalname);
         subGridanexos_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDANEXOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Rows), 6, 0, ".", "")));
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            divTabledados_Visible = 0;
            AssignProp(sPrefix, false, divTabledados_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabledados_Visible), 5, 0), true);
            edtavAtualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_60_Refreshing);
            edtavExcluir_Visible = 0;
            AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_60_Refreshing);
         }
      }

      protected void E137O2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E147O2( )
      {
         /* Gridanexos_Load Routine */
         returnInSub = false;
         AV23Visualizar = "<i class=\"fas fa-download\"></i>";
         AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV23Visualizar);
         AV5Atualizar = "<i class=\"fas fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavAtualizar_Internalname, AV5Atualizar);
         AV12Excluir = "<i class=\"fas fa-x\"></i>";
         AssignAttri(sPrefix, false, edtavExcluir_Internalname, AV12Excluir);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 60;
         }
         sendrow_602( ) ;
         GRIDANEXOS_nCurrentRecord = (long)(GRIDANEXOS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_60_Refreshing )
         {
            context.DoAjaxLoad(60, GridanexosRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E117O2( )
      {
         /* 'DoAdiciona' Routine */
         returnInSub = false;
         GXt_boolean1 = AV28descricaocadastrada;
         new validaanexo(context ).execute(  AV11DocumentoId,  AV9DocAnexoDescricao, out  GXt_boolean1) ;
         AV28descricaocadastrada = GXt_boolean1;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! AV41CheckRequiredFieldsResult || ( AV22UploadedFiles.Count == 0 ) && (0==AV10DocAnexoId) )
         {
            GX_msglist.addItem("Revise os campos obrigatórios");
         }
         else
         {
            if ( AV28descricaocadastrada )
            {
               GX_msglist.addItem("Há campos iguais para o mesmo documento. Revise seus dados!");
            }
            else
            {
               if ( (0==AV10DocAnexoId) )
               {
                  AV48GXV1 = 1;
                  while ( AV48GXV1 <= AV22UploadedFiles.Count )
                  {
                     AV24FileUploadData = ((SdtFileUploadData)AV22UploadedFiles.Item(AV48GXV1));
                     AV6DocAnexo = new SdtDocAnexo(context);
                     AV6DocAnexo.gxTpr_Documentoid = AV11DocumentoId;
                     AV6DocAnexo.gxTpr_Docanexodescricao = AV9DocAnexoDescricao;
                     /* Execute user subroutine: 'CRIANOVONOME' */
                     S132 ();
                     if ( returnInSub )
                     {
                        returnInSub = true;
                        if (true) return;
                     }
                     AV25ArquivoAnexo = AV24FileUploadData.gxTpr_File;
                     AssignAttri(sPrefix, false, "AV25ArquivoAnexo", AV25ArquivoAnexo);
                     AV6DocAnexo.gxTpr_Docanexodatainclusao = AV8DocAnexoDataInclusao;
                     AV6DocAnexo.Insert();
                     if ( AV6DocAnexo.Success() )
                     {
                        /* Execute user subroutine: 'ARMAZENAARQUIVO' */
                        S142 ();
                        if ( returnInSub )
                        {
                           returnInSub = true;
                           if (true) return;
                        }
                        AV14File.Source = AV26caminhoarquivo;
                        if ( AV14File.Exists() )
                        {
                           context.CommitDataStores("anexowc",pr_default);
                        }
                        else
                        {
                           context.RollbackDataStores("anexowc",pr_default);
                        }
                     }
                     else
                     {
                        AV50GXV3 = 1;
                        AV49GXV2 = AV6DocAnexo.GetMessages();
                        while ( AV50GXV3 <= AV49GXV2.Count )
                        {
                           AV19message = ((GeneXus.Utils.SdtMessages_Message)AV49GXV2.Item(AV50GXV3));
                           GX_msglist.addItem(AV19message.gxTpr_Description);
                           AV50GXV3 = (int)(AV50GXV3+1);
                        }
                     }
                     AV48GXV1 = (int)(AV48GXV1+1);
                  }
               }
               else
               {
                  AV51GXV4 = 1;
                  while ( AV51GXV4 <= AV22UploadedFiles.Count )
                  {
                     AV24FileUploadData = ((SdtFileUploadData)AV22UploadedFiles.Item(AV51GXV4));
                     AV31ArquivoAnexado = true;
                     AV51GXV4 = (int)(AV51GXV4+1);
                  }
                  if ( AV31ArquivoAnexado )
                  {
                     AV6DocAnexo.gxTpr_Docanexoid = AV10DocAnexoId;
                     AV6DocAnexo.gxTpr_Documentoid = AV11DocumentoId;
                     AV6DocAnexo.gxTpr_Docanexodescricao = AV9DocAnexoDescricao;
                     AV6DocAnexo.gxTpr_Docanexoarquivo = AV24FileUploadData.gxTpr_Fullname;
                     AV25ArquivoAnexo = AV24FileUploadData.gxTpr_File;
                     AssignAttri(sPrefix, false, "AV25ArquivoAnexo", AV25ArquivoAnexo);
                     AV6DocAnexo.gxTpr_Docanexodatainclusao = AV8DocAnexoDataInclusao;
                     AV6DocAnexo.Update();
                     if ( AV6DocAnexo.Success() )
                     {
                        context.CommitDataStores("anexowc",pr_default);
                        /* Execute user subroutine: 'ARMAZENAARQUIVO' */
                        S142 ();
                        if ( returnInSub )
                        {
                           returnInSub = true;
                           if (true) return;
                        }
                        edtavNomearquivo_Visible = 0;
                        AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Visible), 5, 0), true);
                     }
                     else
                     {
                        AV53GXV6 = 1;
                        AV52GXV5 = AV6DocAnexo.GetMessages();
                        while ( AV53GXV6 <= AV52GXV5.Count )
                        {
                           AV19message = ((GeneXus.Utils.SdtMessages_Message)AV52GXV5.Item(AV53GXV6));
                           GX_msglist.addItem(AV19message.gxTpr_Description);
                           AV53GXV6 = (int)(AV53GXV6+1);
                        }
                     }
                  }
                  else
                  {
                     AV6DocAnexo.gxTpr_Docanexoid = AV10DocAnexoId;
                     AV6DocAnexo.gxTpr_Documentoid = AV11DocumentoId;
                     AV6DocAnexo.gxTpr_Docanexodescricao = AV9DocAnexoDescricao;
                     AV6DocAnexo.gxTpr_Docanexoarquivo = AV29NomeArquivo;
                     AV6DocAnexo.Update();
                     if ( AV6DocAnexo.Success() )
                     {
                        context.CommitDataStores("anexowc",pr_default);
                        /* Execute user subroutine: 'ATUALIZOUGRID' */
                        S152 ();
                        if ( returnInSub )
                        {
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                     else
                     {
                        AV55GXV8 = 1;
                        AV54GXV7 = AV6DocAnexo.GetMessages();
                        while ( AV55GXV8 <= AV54GXV7.Count )
                        {
                           AV19message = ((GeneXus.Utils.SdtMessages_Message)AV54GXV7.Item(AV55GXV8));
                           GX_msglist.addItem(AV19message.gxTpr_Description);
                           AV55GXV8 = (int)(AV55GXV8+1);
                        }
                     }
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24FileUploadData", AV24FileUploadData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6DocAnexo", AV6DocAnexo);
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV33IsAuthorized_Visualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaAnexoDownload", out  GXt_boolean1) ;
         AV33IsAuthorized_Visualizar = GXt_boolean1;
         if ( ! ( AV33IsAuthorized_Visualizar ) )
         {
            edtavVisualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Visible), 5, 0), !bGXsfl_60_Refreshing);
         }
         GXt_boolean1 = AV34IsAuthorized_Atualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaAnexoAtualiza", out  GXt_boolean1) ;
         AV34IsAuthorized_Atualizar = GXt_boolean1;
         if ( ! ( AV34IsAuthorized_Atualizar ) )
         {
            edtavAtualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavAtualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAtualizar_Visible), 5, 0), !bGXsfl_60_Refreshing);
         }
         GXt_boolean1 = AV35IsAuthorized_Excluir;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaAnexoExclui", out  GXt_boolean1) ;
         AV35IsAuthorized_Excluir = GXt_boolean1;
         if ( ! ( AV35IsAuthorized_Excluir ) )
         {
            edtavExcluir_Visible = 0;
            AssignProp(sPrefix, false, edtavExcluir_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavExcluir_Visible), 5, 0), !bGXsfl_60_Refreshing);
         }
         GXt_boolean1 = AV42IsAuthorized_Adiciona;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaAnexoAdd", out  GXt_boolean1) ;
         AV42IsAuthorized_Adiciona = GXt_boolean1;
         if ( ! ( AV42IsAuthorized_Adiciona ) )
         {
            bttBtnadiciona_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadiciona_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadiciona_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV41CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV41CheckRequiredFieldsResult", AV41CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DocAnexoDescricao)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  edtavDocanexodescricao_Internalname,  "true",  ""));
            AV41CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV41CheckRequiredFieldsResult", AV41CheckRequiredFieldsResult);
         }
      }

      protected void E157O2( )
      {
         /* Excluir_Click Routine */
         returnInSub = false;
         AV6DocAnexo.Load(A93DocAnexoId);
         AV6DocAnexo.Delete();
         AV26caminhoarquivo = AV37Directory.GetAbsoluteName() + A95DocAnexoArquivo;
         AssignAttri(sPrefix, false, "AV26caminhoarquivo", AV26caminhoarquivo);
         if ( AV6DocAnexo.Success() )
         {
            context.CommitDataStores("anexowc",pr_default);
            /* Execute user subroutine: 'DELETEARQUIVO' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GRIDANEXOS_nFirstRecordOnPage = 0;
            GRIDANEXOS_nCurrentRecord = 0;
            GXCCtl = "GRIDANEXOS_nFirstRecordOnPage_" + sGXsfl_60_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDANEXOS_nFirstRecordOnPage), 15, 0, ".", "")));
            gxgrGridanexos_refresh( subGridanexos_Rows, AV16FiltroAnexo, AV11DocumentoId, AV38caminhoDiretorio, sPrefix) ;
         }
         else
         {
            AV57GXV10 = 1;
            AV56GXV9 = AV6DocAnexo.GetMessages();
            while ( AV57GXV10 <= AV56GXV9.Count )
            {
               AV19message = ((GeneXus.Utils.SdtMessages_Message)AV56GXV9.Item(AV57GXV10));
               GX_msglist.addItem(AV19message.gxTpr_Description);
               AV57GXV10 = (int)(AV57GXV10+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6DocAnexo", AV6DocAnexo);
      }

      protected void E167O2( )
      {
         /* Atualizar_Click Routine */
         returnInSub = false;
         AV6DocAnexo.Load(A93DocAnexoId);
         AV10DocAnexoId = AV6DocAnexo.gxTpr_Docanexoid;
         AssignAttri(sPrefix, false, "AV10DocAnexoId", StringUtil.LTrimStr( (decimal)(AV10DocAnexoId), 8, 0));
         AV11DocumentoId = AV6DocAnexo.gxTpr_Documentoid;
         AssignAttri(sPrefix, false, "AV11DocumentoId", StringUtil.LTrimStr( (decimal)(AV11DocumentoId), 8, 0));
         AV9DocAnexoDescricao = AV6DocAnexo.gxTpr_Docanexodescricao;
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV29NomeArquivo = AV6DocAnexo.gxTpr_Docanexoarquivo;
         AssignAttri(sPrefix, false, "AV29NomeArquivo", AV29NomeArquivo);
         this.executeUsercontrolMethod(sPrefix, false, "ARQUIVOUPLOADContainer", "Clear", "", new Object[] {});
         AV8DocAnexoDataInclusao = AV6DocAnexo.gxTpr_Docanexodatainclusao;
         AssignAttri(sPrefix, false, "AV8DocAnexoDataInclusao", context.localUtil.Format(AV8DocAnexoDataInclusao, "99/99/99"));
         if ( divSectionbtnadicionar_Visible == 0 )
         {
            divSectionbtnadicionar_Visible = 1;
            AssignProp(sPrefix, false, divSectionbtnadicionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSectionbtnadicionar_Visible), 5, 0), true);
         }
         if ( tblTablearquivo_Visible == 0 )
         {
            edtavNomearquivo_Visible = 0;
            AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Visible), 5, 0), true);
            lblArquivotext_Visible = 1;
            AssignProp(sPrefix, false, lblArquivotext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblArquivotext_Visible), 5, 0), true);
            tblTablearquivo_Visible = 1;
            AssignProp(sPrefix, false, tblTablearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablearquivo_Visible), 5, 0), true);
         }
         edtavDocanexodescricao_Enabled = 1;
         AssignProp(sPrefix, false, edtavDocanexodescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocanexodescricao_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6DocAnexo", AV6DocAnexo);
      }

      protected void E177O2( )
      {
         /* Visualizar_Click Routine */
         returnInSub = false;
         AV26caminhoarquivo = AV38caminhoDiretorio + A95DocAnexoArquivo;
         AssignAttri(sPrefix, false, "AV26caminhoarquivo", AV26caminhoarquivo);
         AV6DocAnexo.Load(A93DocAnexoId);
         if ( StringUtil.Contains( AV6DocAnexo.gxTpr_Docanexoarquivo, ".jpg") || StringUtil.Contains( AV6DocAnexo.gxTpr_Docanexoarquivo, ".jpeg") )
         {
            AV39TipoArquivo = "image/jpeg";
            AssignAttri(sPrefix, false, "AV39TipoArquivo", AV39TipoArquivo);
         }
         else if ( StringUtil.Contains( AV6DocAnexo.gxTpr_Docanexoarquivo, ".pdf") )
         {
            AV39TipoArquivo = "application/pdf";
            AssignAttri(sPrefix, false, "AV39TipoArquivo", AV39TipoArquivo);
         }
         else if ( StringUtil.Contains( AV6DocAnexo.gxTpr_Docanexoarquivo, ".doc") )
         {
            AV39TipoArquivo = "application/msword";
            AssignAttri(sPrefix, false, "AV39TipoArquivo", AV39TipoArquivo);
         }
         else if ( StringUtil.Contains( AV6DocAnexo.gxTpr_Docanexoarquivo, ".xls") || StringUtil.Contains( AV6DocAnexo.gxTpr_Docanexoarquivo, ".xlsx") )
         {
            AV39TipoArquivo = "application/vnd.ms-excel";
            AssignAttri(sPrefix, false, "AV39TipoArquivo", AV39TipoArquivo);
         }
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "adownloadarquivo.aspx"+UrlEncode(StringUtil.RTrim(AV39TipoArquivo)) + "," + UrlEncode(StringUtil.RTrim(AV38caminhoDiretorio+AV6DocAnexo.gxTpr_Docanexoarquivo)) + "," + UrlEncode(StringUtil.RTrim(AV6DocAnexo.gxTpr_Docanexoarquivo));
         CallWebObject(formatLink("adownloadarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 2;
         AV10DocAnexoId = AV6DocAnexo.gxTpr_Docanexoid;
         AssignAttri(sPrefix, false, "AV10DocAnexoId", StringUtil.LTrimStr( (decimal)(AV10DocAnexoId), 8, 0));
         AV9DocAnexoDescricao = AV6DocAnexo.gxTpr_Docanexodescricao;
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV29NomeArquivo = AV6DocAnexo.gxTpr_Docanexoarquivo;
         AssignAttri(sPrefix, false, "AV29NomeArquivo", AV29NomeArquivo);
         edtavDocanexodescricao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDocanexodescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocanexodescricao_Enabled), 5, 0), true);
         divSectionbtnadicionar_Visible = 0;
         AssignProp(sPrefix, false, divSectionbtnadicionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSectionbtnadicionar_Visible), 5, 0), true);
         edtavNomearquivo_Visible = 1;
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Visible), 5, 0), true);
         edtavNomearquivo_Caption = "ARQUIVO";
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Caption", edtavNomearquivo_Caption, true);
         lblArquivotext_Visible = 0;
         AssignProp(sPrefix, false, lblArquivotext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblArquivotext_Visible), 5, 0), true);
         tblTablearquivo_Visible = 0;
         AssignProp(sPrefix, false, tblTablearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablearquivo_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6DocAnexo", AV6DocAnexo);
      }

      protected void S172( )
      {
         /* 'LIMPADADOS' Routine */
         returnInSub = false;
         AV10DocAnexoId = 0;
         AssignAttri(sPrefix, false, "AV10DocAnexoId", StringUtil.LTrimStr( (decimal)(AV10DocAnexoId), 8, 0));
         AV9DocAnexoDescricao = "";
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV29NomeArquivo = "";
         AssignAttri(sPrefix, false, "AV29NomeArquivo", AV29NomeArquivo);
         this.executeUsercontrolMethod(sPrefix, false, "ARQUIVOUPLOADContainer", "Clear", "", new Object[] {});
         edtavNomearquivo_Visible = 0;
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Visible), 5, 0), true);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S152( )
      {
         /* 'ATUALIZOUGRID' Routine */
         returnInSub = false;
         AV10DocAnexoId = 0;
         AssignAttri(sPrefix, false, "AV10DocAnexoId", StringUtil.LTrimStr( (decimal)(AV10DocAnexoId), 8, 0));
         AV9DocAnexoDescricao = "";
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV7DocAnexoArquivo = "";
         AssignAttri(sPrefix, false, "AV7DocAnexoArquivo", AV7DocAnexoArquivo);
         AV29NomeArquivo = "";
         AssignAttri(sPrefix, false, "AV29NomeArquivo", AV29NomeArquivo);
         AV25ArquivoAnexo = "";
         AssignAttri(sPrefix, false, "AV25ArquivoAnexo", AV25ArquivoAnexo);
         edtavNomearquivo_Visible = 0;
         AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Visible), 5, 0), true);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S142( )
      {
         /* 'ARMAZENAARQUIVO' Routine */
         returnInSub = false;
         AV14File.Source = AV25ArquivoAnexo;
         AV26caminhoarquivo = AV38caminhoDiretorio + AV6DocAnexo.gxTpr_Docanexoarquivo;
         AssignAttri(sPrefix, false, "AV26caminhoarquivo", AV26caminhoarquivo);
         AV14File.Copy(AV26caminhoarquivo);
         /* Execute user subroutine: 'LIMPADADOS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S162( )
      {
         /* 'DELETEARQUIVO' Routine */
         returnInSub = false;
         AV26caminhoarquivo = AV38caminhoDiretorio + A95DocAnexoArquivo;
         AssignAttri(sPrefix, false, "AV26caminhoarquivo", AV26caminhoarquivo);
         AV14File.Source = AV26caminhoarquivo;
         AV14File.Delete();
      }

      protected void S132( )
      {
         /* 'CRIANOVONOME' Routine */
         returnInSub = false;
         AV43NumeroArquivo = 2;
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, " ", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "*", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "/", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "\\", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, ":", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "?", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, ">", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "<", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "\"\"", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV9DocAnexoDescricao = StringUtil.StringReplace( AV9DocAnexoDescricao, "|", "");
         AssignAttri(sPrefix, false, "AV9DocAnexoDescricao", AV9DocAnexoDescricao);
         AV6DocAnexo.gxTpr_Docanexoarquivo = AV9DocAnexoDescricao+"."+AV24FileUploadData.gxTpr_Extension;
         AV14File.Source = AV38caminhoDiretorio+AV9DocAnexoDescricao+"."+AV24FileUploadData.gxTpr_Extension;
         while ( AV14File.Exists() )
         {
            AV14File.Source = AV38caminhoDiretorio+AV9DocAnexoDescricao+"("+StringUtil.StringReplace( StringUtil.Str( (decimal)(AV43NumeroArquivo), 10, 0), " ", "")+")"+"."+AV24FileUploadData.gxTpr_Extension;
            AV6DocAnexo.gxTpr_Docanexoarquivo = AV9DocAnexoDescricao+"("+StringUtil.StringReplace( StringUtil.Str( (decimal)(AV43NumeroArquivo), 10, 0), " ", "")+")"+"."+AV24FileUploadData.gxTpr_Extension;
            AV43NumeroArquivo = (long)(AV43NumeroArquivo+1);
         }
      }

      protected void wb_table1_26_7O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablearquivo_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablearquivo_Internalname, tblTablearquivo_Internalname, "", "", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucArquivoupload.SetProperty("Class", Arquivoupload_Class);
            ucArquivoupload.SetProperty("AutoUpload", Arquivoupload_Autoupload);
            ucArquivoupload.SetProperty("HideAdditionalButtons", Arquivoupload_Hideadditionalbuttons);
            ucArquivoupload.SetProperty("TooltipText", Arquivoupload_Tooltiptext);
            ucArquivoupload.SetProperty("EnableUploadedFileCanceling", Arquivoupload_Enableuploadedfilecanceling);
            ucArquivoupload.SetProperty("MaxFileSize", Arquivoupload_Maxfilesize);
            ucArquivoupload.SetProperty("MaxNumberOfFiles", Arquivoupload_Maxnumberoffiles);
            ucArquivoupload.SetProperty("AutoDisableAddingFiles", Arquivoupload_Autodisableaddingfiles);
            ucArquivoupload.SetProperty("AcceptedFileTypes", Arquivoupload_Acceptedfiletypes);
            ucArquivoupload.SetProperty("UploadedFiles", AV22UploadedFiles);
            ucArquivoupload.SetProperty("FailedFiles", AV13FailedFiles);
            ucArquivoupload.Render(context, "fileupload", Arquivoupload_Internalname, sPrefix+"ARQUIVOUPLOADContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_26_7O2e( true) ;
         }
         else
         {
            wb_table1_26_7O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV11DocumentoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV11DocumentoId", StringUtil.LTrimStr( (decimal)(AV11DocumentoId), 8, 0));
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
         PA7O2( ) ;
         WS7O2( ) ;
         WE7O2( ) ;
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
         sCtrlAV11DocumentoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "anexowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV11DocumentoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV11DocumentoId", StringUtil.LTrimStr( (decimal)(AV11DocumentoId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV11DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11DocumentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV11DocumentoId != wcpOAV11DocumentoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV11DocumentoId = AV11DocumentoId;
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
         sCtrlAV11DocumentoId = cgiGet( sPrefix+"AV11DocumentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV11DocumentoId) > 0 )
         {
            AV11DocumentoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV11DocumentoId), ",", "."));
            AssignAttri(sPrefix, false, "AV11DocumentoId", StringUtil.LTrimStr( (decimal)(AV11DocumentoId), 8, 0));
         }
         else
         {
            AV11DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV11DocumentoId_PARM"), ",", "."));
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
         PA7O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7O2( ) ;
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
         WS7O2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11DocumentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11DocumentoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11DocumentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11DocumentoId_CTRL", StringUtil.RTrim( sCtrlAV11DocumentoId));
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
         WE7O2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910445218", true, true);
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
            context.AddJavascriptSource("anexowc.js", "?202311910445219", false, true);
            context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_602( )
      {
         edtDocAnexoId_Internalname = sPrefix+"DOCANEXOID_"+sGXsfl_60_idx;
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID_"+sGXsfl_60_idx;
         edtDocAnexoArquivo_Internalname = sPrefix+"DOCANEXOARQUIVO_"+sGXsfl_60_idx;
         edtDocAnexoDescricao_Internalname = sPrefix+"DOCANEXODESCRICAO_"+sGXsfl_60_idx;
         edtDocAnexoDataInclusao_Internalname = sPrefix+"DOCANEXODATAINCLUSAO_"+sGXsfl_60_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_60_idx;
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR_"+sGXsfl_60_idx;
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR_"+sGXsfl_60_idx;
      }

      protected void SubsflControlProps_fel_602( )
      {
         edtDocAnexoId_Internalname = sPrefix+"DOCANEXOID_"+sGXsfl_60_fel_idx;
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID_"+sGXsfl_60_fel_idx;
         edtDocAnexoArquivo_Internalname = sPrefix+"DOCANEXOARQUIVO_"+sGXsfl_60_fel_idx;
         edtDocAnexoDescricao_Internalname = sPrefix+"DOCANEXODESCRICAO_"+sGXsfl_60_fel_idx;
         edtDocAnexoDataInclusao_Internalname = sPrefix+"DOCANEXODATAINCLUSAO_"+sGXsfl_60_fel_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_60_fel_idx;
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR_"+sGXsfl_60_fel_idx;
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR_"+sGXsfl_60_fel_idx;
      }

      protected void sendrow_602( )
      {
         SubsflControlProps_602( ) ;
         WB7O0( ) ;
         if ( ( subGridanexos_Rows * 1 == 0 ) || ( nGXsfl_60_idx - GRIDANEXOS_nFirstRecordOnPage <= subGridanexos_fnc_Recordsperpage( ) * 1 ) )
         {
            GridanexosRow = GXWebRow.GetNew(context,GridanexosContainer);
            if ( subGridanexos_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridanexos_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridanexos_Class, "") != 0 )
               {
                  subGridanexos_Linesclass = subGridanexos_Class+"Odd";
               }
            }
            else if ( subGridanexos_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridanexos_Backstyle = 0;
               subGridanexos_Backcolor = subGridanexos_Allbackcolor;
               if ( StringUtil.StrCmp(subGridanexos_Class, "") != 0 )
               {
                  subGridanexos_Linesclass = subGridanexos_Class+"Uniform";
               }
            }
            else if ( subGridanexos_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridanexos_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridanexos_Class, "") != 0 )
               {
                  subGridanexos_Linesclass = subGridanexos_Class+"Odd";
               }
               subGridanexos_Backcolor = (int)(0x0);
            }
            else if ( subGridanexos_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridanexos_Backstyle = 1;
               if ( ((int)((nGXsfl_60_idx) % (2))) == 0 )
               {
                  subGridanexos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridanexos_Class, "") != 0 )
                  {
                     subGridanexos_Linesclass = subGridanexos_Class+"Even";
                  }
               }
               else
               {
                  subGridanexos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridanexos_Class, "") != 0 )
                  {
                     subGridanexos_Linesclass = subGridanexos_Class+"Odd";
                  }
               }
            }
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_60_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocAnexoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A93DocAnexoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A93DocAnexoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocAnexoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)60,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)60,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocAnexoArquivo_Internalname,(string)A95DocAnexoArquivo,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocAnexoArquivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)60,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocAnexoDescricao_Internalname,(string)A94DocAnexoDescricao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocAnexoDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)60,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocAnexoDataInclusao_Internalname,context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"),context.localUtil.Format( A96DocAnexoDataInclusao, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocAnexoDataInclusao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)60,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVisualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'"+sPrefix+"',false,'"+sGXsfl_60_idx+"',60)\"" : " ");
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavVisualizar_Internalname,StringUtil.RTrim( AV23Visualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,66);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVVISUALIZAR.CLICK."+sGXsfl_60_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavVisualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavVisualizar_Visible,(int)edtavVisualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)60,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavAtualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAtualizar_Enabled!=0)&&(edtavAtualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 67,'"+sPrefix+"',false,'"+sGXsfl_60_idx+"',60)\"" : " ");
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAtualizar_Internalname,StringUtil.RTrim( AV5Atualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAtualizar_Enabled!=0)&&(edtavAtualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,67);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVATUALIZAR.CLICK."+sGXsfl_60_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAtualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(int)edtavAtualizar_Visible,(int)edtavAtualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)60,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridanexosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavExcluir_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavExcluir_Enabled!=0)&&(edtavExcluir_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'"+sPrefix+"',false,'"+sGXsfl_60_idx+"',60)\"" : " ");
            ROClassString = "Attribute";
            GridanexosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExcluir_Internalname,StringUtil.RTrim( AV12Excluir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavExcluir_Enabled!=0)&&(edtavExcluir_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,68);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVEXCLUIR.CLICK."+sGXsfl_60_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExcluir_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavExcluir_Visible,(int)edtavExcluir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)60,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes7O2( ) ;
            GridanexosContainer.AddRow(GridanexosRow);
            nGXsfl_60_idx = ((subGridanexos_Islastpage==1)&&(nGXsfl_60_idx+1>subGridanexos_fnc_Recordsperpage( )) ? 1 : nGXsfl_60_idx+1);
            sGXsfl_60_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_60_idx), 4, 0), 4, "0");
            SubsflControlProps_602( ) ;
         }
         /* End function sendrow_602 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl60( )
      {
         if ( GridanexosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridanexosContainer"+"DivS\" data-gxgridid=\"60\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridanexos_Internalname, subGridanexos_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridanexos_Backcolorstyle == 0 )
            {
               subGridanexos_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridanexos_Class) > 0 )
               {
                  subGridanexos_Linesclass = subGridanexos_Class+"Title";
               }
            }
            else
            {
               subGridanexos_Titlebackstyle = 1;
               if ( subGridanexos_Backcolorstyle == 1 )
               {
                  subGridanexos_Titlebackcolor = subGridanexos_Allbackcolor;
                  if ( StringUtil.Len( subGridanexos_Class) > 0 )
                  {
                     subGridanexos_Linesclass = subGridanexos_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridanexos_Class) > 0 )
                  {
                     subGridanexos_Linesclass = subGridanexos_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id do Documento Anexo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id do Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "ARQUIVO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "DESCRIÇÃO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Data de Inclusão") ;
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
            GridanexosContainer.AddObjectProperty("GridName", "Gridanexos");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridanexosContainer = new GXWebGrid( context);
            }
            else
            {
               GridanexosContainer.Clear();
            }
            GridanexosContainer.SetWrapped(nGXWrapped);
            GridanexosContainer.AddObjectProperty("GridName", "Gridanexos");
            GridanexosContainer.AddObjectProperty("Header", subGridanexos_Header);
            GridanexosContainer.AddObjectProperty("Class", "WorkWith");
            GridanexosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Backcolorstyle), 1, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("CmpContext", sPrefix);
            GridanexosContainer.AddObjectProperty("InMasterPage", "false");
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A93DocAnexoId), 8, 0, ".", "")));
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ".", "")));
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", A95DocAnexoArquivo);
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", A94DocAnexoDescricao);
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", context.localUtil.Format(A96DocAnexoDataInclusao, "99/99/99"));
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", StringUtil.RTrim( AV23Visualizar));
            GridanexosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Enabled), 5, 0, ".", "")));
            GridanexosColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Visible), 5, 0, ".", "")));
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", StringUtil.RTrim( AV5Atualizar));
            GridanexosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Enabled), 5, 0, ".", "")));
            GridanexosColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtualizar_Visible), 5, 0, ".", "")));
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridanexosColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12Excluir));
            GridanexosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Enabled), 5, 0, ".", "")));
            GridanexosColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Visible), 5, 0, ".", "")));
            GridanexosContainer.AddColumnProperties(GridanexosColumn);
            GridanexosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Selectedindex), 4, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Allowselection), 1, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Selectioncolor), 9, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Allowhovering), 1, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Hoveringcolor), 9, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Allowcollapsing), 1, 0, ".", "")));
            GridanexosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridanexos_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO";
         lblArquivotext_Internalname = sPrefix+"ARQUIVOTEXT";
         Arquivoupload_Internalname = sPrefix+"ARQUIVOUPLOAD";
         tblTablearquivo_Internalname = sPrefix+"TABLEARQUIVO";
         edtavDocanexodescricao_Internalname = sPrefix+"vDOCANEXODESCRICAO";
         lblTxtdocanexodescricao_Internalname = sPrefix+"TXTDOCANEXODESCRICAO";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         bttBtnadiciona_Internalname = sPrefix+"BTNADICIONA";
         divSectionbtnadicionar_Internalname = sPrefix+"SECTIONBTNADICIONAR";
         divTabledados_Internalname = sPrefix+"TABLEDADOS";
         edtavFiltroanexo_Internalname = sPrefix+"vFILTROANEXO";
         edtDocAnexoId_Internalname = sPrefix+"DOCANEXOID";
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID";
         edtDocAnexoArquivo_Internalname = sPrefix+"DOCANEXOARQUIVO";
         edtDocAnexoDescricao_Internalname = sPrefix+"DOCANEXODESCRICAO";
         edtDocAnexoDataInclusao_Internalname = sPrefix+"DOCANEXODATAINCLUSAO";
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR";
         edtavAtualizar_Internalname = sPrefix+"vATUALIZAR";
         edtavExcluir_Internalname = sPrefix+"vEXCLUIR";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavDocanexoid_Internalname = sPrefix+"vDOCANEXOID";
         edtavDocumentoid_Internalname = sPrefix+"vDOCUMENTOID";
         edtavDocanexoarquivo_Internalname = sPrefix+"vDOCANEXOARQUIVO";
         edtavDocanexodatainclusao_Internalname = sPrefix+"vDOCANEXODATAINCLUSAO";
         Gridanexos_empowerer_Internalname = sPrefix+"GRIDANEXOS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridanexos_Internalname = sPrefix+"GRIDANEXOS";
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
         subGridanexos_Allowcollapsing = 0;
         subGridanexos_Allowselection = 0;
         subGridanexos_Header = "";
         edtavExcluir_Jsonclick = "";
         edtavExcluir_Enabled = 1;
         edtavAtualizar_Jsonclick = "";
         edtavAtualizar_Enabled = 1;
         edtavVisualizar_Jsonclick = "";
         edtavVisualizar_Enabled = 1;
         edtDocAnexoDataInclusao_Jsonclick = "";
         edtDocAnexoDescricao_Jsonclick = "";
         edtDocAnexoArquivo_Jsonclick = "";
         edtDocumentoId_Jsonclick = "";
         edtDocAnexoId_Jsonclick = "";
         subGridanexos_Class = "WorkWith";
         subGridanexos_Backcolorstyle = 0;
         Arquivoupload_Tooltiptext = "";
         edtavVisualizar_Visible = -1;
         edtavDocanexodatainclusao_Jsonclick = "";
         edtavDocanexodatainclusao_Visible = 1;
         edtavDocanexoarquivo_Visible = 1;
         edtavDocumentoid_Jsonclick = "";
         edtavDocumentoid_Visible = 1;
         edtavDocanexoid_Jsonclick = "";
         edtavDocanexoid_Visible = 1;
         edtavFiltroanexo_Jsonclick = "";
         edtavFiltroanexo_Enabled = 1;
         bttBtnadiciona_Visible = 1;
         divSectionbtnadicionar_Visible = 1;
         lblTxtdocanexodescricao_Caption = "0/100";
         edtavDocanexodescricao_Jsonclick = "";
         edtavDocanexodescricao_Enabled = 1;
         lblArquivotext_Visible = 1;
         edtavNomearquivo_Jsonclick = "";
         edtavNomearquivo_Enabled = 1;
         edtavNomearquivo_Caption = "ARQUIVO";
         edtavNomearquivo_Visible = 1;
         divTabledados_Visible = 1;
         tblTablearquivo_Visible = 1;
         Gridanexos_empowerer_Infinitescrolling = "Grid";
         Arquivoupload_Acceptedfiletypes = "any";
         Arquivoupload_Autodisableaddingfiles = Convert.ToBoolean( 0);
         Arquivoupload_Maxnumberoffiles = 1;
         Arquivoupload_Maxfilesize = 134217728;
         Arquivoupload_Enableuploadedfilecanceling = Convert.ToBoolean( 0);
         Arquivoupload_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Arquivoupload_Autoupload = Convert.ToBoolean( -1);
         Arquivoupload_Class = "FileUpload";
         edtavExcluir_Visible = -1;
         edtavAtualizar_Visible = -1;
         subGridanexos_Rows = 50;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'sPrefix'},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("GRIDANEXOS.LOAD","{handler:'E147O2',iparms:[]");
         setEventMetadata("GRIDANEXOS.LOAD",",oparms:[{av:'AV23Visualizar',fld:'vVISUALIZAR',pic:''},{av:'AV5Atualizar',fld:'vATUALIZAR',pic:''},{av:'AV12Excluir',fld:'vEXCLUIR',pic:''}]}");
         setEventMetadata("'DOADICIONA'","{handler:'E117O2',iparms:[{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV9DocAnexoDescricao',fld:'vDOCANEXODESCRICAO',pic:''},{av:'AV41CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV22UploadedFiles',fld:'vUPLOADEDFILES',pic:''},{av:'AV10DocAnexoId',fld:'vDOCANEXOID',pic:'ZZZZZZZ9'},{av:'AV8DocAnexoDataInclusao',fld:'vDOCANEXODATAINCLUSAO',pic:''},{av:'AV26caminhoarquivo',fld:'vCAMINHOARQUIVO',pic:''},{av:'AV6DocAnexo',fld:'vDOCANEXO',pic:''},{av:'AV29NomeArquivo',fld:'vNOMEARQUIVO',pic:''},{av:'AV24FileUploadData',fld:'vFILEUPLOADDATA',pic:''},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'AV25ArquivoAnexo',fld:'vARQUIVOANEXO',pic:''},{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'sPrefix'}]");
         setEventMetadata("'DOADICIONA'",",oparms:[{av:'AV25ArquivoAnexo',fld:'vARQUIVOANEXO',pic:''},{av:'edtavNomearquivo_Visible',ctrl:'vNOMEARQUIVO',prop:'Visible'},{av:'AV24FileUploadData',fld:'vFILEUPLOADDATA',pic:''},{av:'AV6DocAnexo',fld:'vDOCANEXO',pic:''},{av:'AV41CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV9DocAnexoDescricao',fld:'vDOCANEXODESCRICAO',pic:''},{av:'AV26caminhoarquivo',fld:'vCAMINHOARQUIVO',pic:''},{av:'AV10DocAnexoId',fld:'vDOCANEXOID',pic:'ZZZZZZZ9'},{av:'AV7DocAnexoArquivo',fld:'vDOCANEXOARQUIVO',pic:''},{av:'AV29NomeArquivo',fld:'vNOMEARQUIVO',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("VEXCLUIR.CLICK","{handler:'E157O2',iparms:[{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'sPrefix'},{av:'A93DocAnexoId',fld:'DOCANEXOID',pic:'ZZZZZZZ9',hsh:true},{av:'A95DocAnexoArquivo',fld:'DOCANEXOARQUIVO',pic:'',hsh:true}]");
         setEventMetadata("VEXCLUIR.CLICK",",oparms:[{av:'AV6DocAnexo',fld:'vDOCANEXO',pic:''},{av:'AV26caminhoarquivo',fld:'vCAMINHOARQUIVO',pic:''},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("VATUALIZAR.CLICK","{handler:'E167O2',iparms:[{av:'A93DocAnexoId',fld:'DOCANEXOID',pic:'ZZZZZZZ9',hsh:true},{av:'divSectionbtnadicionar_Visible',ctrl:'SECTIONBTNADICIONAR',prop:'Visible'},{av:'tblTablearquivo_Visible',ctrl:'TABLEARQUIVO',prop:'Visible'}]");
         setEventMetadata("VATUALIZAR.CLICK",",oparms:[{av:'AV6DocAnexo',fld:'vDOCANEXO',pic:''},{av:'AV10DocAnexoId',fld:'vDOCANEXOID',pic:'ZZZZZZZ9'},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV9DocAnexoDescricao',fld:'vDOCANEXODESCRICAO',pic:''},{av:'AV29NomeArquivo',fld:'vNOMEARQUIVO',pic:''},{av:'AV8DocAnexoDataInclusao',fld:'vDOCANEXODATAINCLUSAO',pic:''},{av:'divSectionbtnadicionar_Visible',ctrl:'SECTIONBTNADICIONAR',prop:'Visible'},{av:'edtavNomearquivo_Visible',ctrl:'vNOMEARQUIVO',prop:'Visible'},{av:'lblArquivotext_Visible',ctrl:'ARQUIVOTEXT',prop:'Visible'},{av:'tblTablearquivo_Visible',ctrl:'TABLEARQUIVO',prop:'Visible'},{av:'edtavDocanexodescricao_Enabled',ctrl:'vDOCANEXODESCRICAO',prop:'Enabled'}]}");
         setEventMetadata("VVISUALIZAR.CLICK","{handler:'E177O2',iparms:[{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'A95DocAnexoArquivo',fld:'DOCANEXOARQUIVO',pic:'',hsh:true},{av:'A93DocAnexoId',fld:'DOCANEXOID',pic:'ZZZZZZZ9',hsh:true},{av:'AV39TipoArquivo',fld:'vTIPOARQUIVO',pic:''}]");
         setEventMetadata("VVISUALIZAR.CLICK",",oparms:[{av:'AV26caminhoarquivo',fld:'vCAMINHOARQUIVO',pic:''},{av:'AV6DocAnexo',fld:'vDOCANEXO',pic:''},{av:'AV39TipoArquivo',fld:'vTIPOARQUIVO',pic:''},{av:'AV10DocAnexoId',fld:'vDOCANEXOID',pic:'ZZZZZZZ9'},{av:'AV9DocAnexoDescricao',fld:'vDOCANEXODESCRICAO',pic:''},{av:'AV29NomeArquivo',fld:'vNOMEARQUIVO',pic:''},{av:'edtavDocanexodescricao_Enabled',ctrl:'vDOCANEXODESCRICAO',prop:'Enabled'},{av:'divSectionbtnadicionar_Visible',ctrl:'SECTIONBTNADICIONAR',prop:'Visible'},{av:'edtavNomearquivo_Visible',ctrl:'vNOMEARQUIVO',prop:'Visible'},{av:'edtavNomearquivo_Caption',ctrl:'vNOMEARQUIVO',prop:'Caption'},{av:'lblArquivotext_Visible',ctrl:'ARQUIVOTEXT',prop:'Visible'},{av:'tblTablearquivo_Visible',ctrl:'TABLEARQUIVO',prop:'Visible'}]}");
         setEventMetadata("GRIDANEXOS_FIRSTPAGE","{handler:'subgridanexos_firstpage',iparms:[{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRIDANEXOS_FIRSTPAGE",",oparms:[{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("GRIDANEXOS_PREVPAGE","{handler:'subgridanexos_previouspage',iparms:[{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRIDANEXOS_PREVPAGE",",oparms:[{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("GRIDANEXOS_NEXTPAGE","{handler:'subgridanexos_nextpage',iparms:[{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRIDANEXOS_NEXTPAGE",",oparms:[{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("GRIDANEXOS_LASTPAGE","{handler:'subgridanexos_lastpage',iparms:[{av:'GRIDANEXOS_nFirstRecordOnPage'},{av:'GRIDANEXOS_nEOF'},{av:'subGridanexos_Rows',ctrl:'GRIDANEXOS',prop:'Rows'},{av:'AV16FiltroAnexo',fld:'vFILTROANEXO',pic:''},{av:'AV11DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{av:'AV38caminhoDiretorio',fld:'vCAMINHODIRETORIO',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRIDANEXOS_LASTPAGE",",oparms:[{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'},{av:'edtavAtualizar_Visible',ctrl:'vATUALIZAR',prop:'Visible'},{av:'edtavExcluir_Visible',ctrl:'vEXCLUIR',prop:'Visible'},{ctrl:'BTNADICIONA',prop:'Visible'}]}");
         setEventMetadata("VALIDV_DOCANEXODATAINCLUSAO","{handler:'Validv_Docanexodatainclusao',iparms:[]");
         setEventMetadata("VALIDV_DOCANEXODATAINCLUSAO",",oparms:[]}");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FiltroAnexo = "";
         AV38caminhoDiretorio = "";
         scmdbuf = "";
         H007O3_A40000ParametroValor = new string[] {""} ;
         H007O3_n40000ParametroValor = new bool[] {false} ;
         A40000ParametroValor = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV22UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "LGPD_Novo");
         AV13FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "LGPD_Novo");
         AV26caminhoarquivo = "";
         AV6DocAnexo = new SdtDocAnexo(context);
         AV24FileUploadData = new SdtFileUploadData(context);
         AV25ArquivoAnexo = "";
         AV39TipoArquivo = "";
         Gridanexos_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV29NomeArquivo = "";
         lblArquivotext_Jsonclick = "";
         AV9DocAnexoDescricao = "";
         lblTxtdocanexodescricao_Jsonclick = "";
         bttBtnadiciona_Jsonclick = "";
         GridanexosContainer = new GXWebGrid( context);
         sStyleString = "";
         AV7DocAnexoArquivo = "";
         AV8DocAnexoDataInclusao = DateTime.MinValue;
         ucGridanexos_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A95DocAnexoArquivo = "";
         A94DocAnexoDescricao = "";
         A96DocAnexoDataInclusao = DateTime.MinValue;
         AV23Visualizar = "";
         AV5Atualizar = "";
         AV12Excluir = "";
         GXDecQS = "";
         GXCCtl = "";
         H007O5_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H007O5_A94DocAnexoDescricao = new string[] {""} ;
         H007O5_A95DocAnexoArquivo = new string[] {""} ;
         H007O5_A75DocumentoId = new int[1] ;
         H007O5_A93DocAnexoId = new int[1] ;
         H007O5_A40000ParametroValor = new string[] {""} ;
         H007O5_n40000ParametroValor = new bool[] {false} ;
         H007O7_AGRIDANEXOS_nRecordCount = new long[1] ;
         H007O9_A40000ParametroValor = new string[] {""} ;
         H007O9_n40000ParametroValor = new bool[] {false} ;
         AV40Servidor = "";
         AV37Directory = new GxDirectory(context.GetPhysicalPath());
         GridanexosRow = new GXWebRow();
         AV14File = new GxFile(context.GetPhysicalPath());
         AV49GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19message = new GeneXus.Utils.SdtMessages_Message(context);
         AV52GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV54GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV56GXV9 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         ucArquivoupload = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV11DocumentoId = "";
         subGridanexos_Linesclass = "";
         ROClassString = "";
         GridanexosColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.anexowc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anexowc__default(),
            new Object[][] {
                new Object[] {
               H007O3_A40000ParametroValor, H007O3_n40000ParametroValor
               }
               , new Object[] {
               H007O5_A96DocAnexoDataInclusao, H007O5_A94DocAnexoDescricao, H007O5_A95DocAnexoArquivo, H007O5_A75DocumentoId, H007O5_A93DocAnexoId, H007O5_A40000ParametroValor, H007O5_n40000ParametroValor
               }
               , new Object[] {
               H007O7_AGRIDANEXOS_nRecordCount
               }
               , new Object[] {
               H007O9_A40000ParametroValor, H007O9_n40000ParametroValor
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavNomearquivo_Enabled = 0;
         edtavVisualizar_Enabled = 0;
         edtavAtualizar_Enabled = 0;
         edtavExcluir_Enabled = 0;
      }

      private short GRIDANEXOS_nEOF ;
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
      private short subGridanexos_Backcolorstyle ;
      private short subGridanexos_Backstyle ;
      private short subGridanexos_Titlebackstyle ;
      private short subGridanexos_Allowselection ;
      private short subGridanexos_Allowhovering ;
      private short subGridanexos_Allowcollapsing ;
      private short subGridanexos_Collapsed ;
      private int AV11DocumentoId ;
      private int wcpOAV11DocumentoId ;
      private int edtavAtualizar_Visible ;
      private int edtavExcluir_Visible ;
      private int divSectionbtnadicionar_Visible ;
      private int tblTablearquivo_Visible ;
      private int nRC_GXsfl_60 ;
      private int subGridanexos_Rows ;
      private int nGXsfl_60_idx=1 ;
      private int edtavNomearquivo_Enabled ;
      private int edtavVisualizar_Enabled ;
      private int edtavAtualizar_Enabled ;
      private int edtavExcluir_Enabled ;
      private int Arquivoupload_Maxfilesize ;
      private int Arquivoupload_Maxnumberoffiles ;
      private int divTabledados_Visible ;
      private int edtavNomearquivo_Visible ;
      private int lblArquivotext_Visible ;
      private int edtavDocanexodescricao_Enabled ;
      private int bttBtnadiciona_Visible ;
      private int edtavFiltroanexo_Enabled ;
      private int AV10DocAnexoId ;
      private int edtavDocanexoid_Visible ;
      private int edtavDocumentoid_Visible ;
      private int edtavDocanexoarquivo_Visible ;
      private int edtavDocanexodatainclusao_Visible ;
      private int A93DocAnexoId ;
      private int A75DocumentoId ;
      private int subGridanexos_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV48GXV1 ;
      private int AV50GXV3 ;
      private int AV51GXV4 ;
      private int AV53GXV6 ;
      private int AV55GXV8 ;
      private int edtavVisualizar_Visible ;
      private int AV57GXV10 ;
      private int idxLst ;
      private int subGridanexos_Backcolor ;
      private int subGridanexos_Allbackcolor ;
      private int subGridanexos_Titlebackcolor ;
      private int subGridanexos_Selectedindex ;
      private int subGridanexos_Selectioncolor ;
      private int subGridanexos_Hoveringcolor ;
      private long GRIDANEXOS_nFirstRecordOnPage ;
      private long GRIDANEXOS_nCurrentRecord ;
      private long GRIDANEXOS_nRecordCount ;
      private long AV43NumeroArquivo ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_60_idx="0001" ;
      private string edtavAtualizar_Internalname ;
      private string edtavExcluir_Internalname ;
      private string edtavNomearquivo_Internalname ;
      private string edtavVisualizar_Internalname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV39TipoArquivo ;
      private string Arquivoupload_Class ;
      private string Arquivoupload_Acceptedfiletypes ;
      private string Gridanexos_empowerer_Gridinternalname ;
      private string Gridanexos_empowerer_Infinitescrolling ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTabledados_Internalname ;
      private string edtavNomearquivo_Caption ;
      private string TempTags ;
      private string edtavNomearquivo_Jsonclick ;
      private string lblArquivotext_Internalname ;
      private string lblArquivotext_Jsonclick ;
      private string edtavDocanexodescricao_Internalname ;
      private string edtavDocanexodescricao_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTxtdocanexodescricao_Internalname ;
      private string lblTxtdocanexodescricao_Caption ;
      private string lblTxtdocanexodescricao_Jsonclick ;
      private string divSectionbtnadicionar_Internalname ;
      private string bttBtnadiciona_Internalname ;
      private string bttBtnadiciona_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string edtavFiltroanexo_Internalname ;
      private string edtavFiltroanexo_Jsonclick ;
      private string sStyleString ;
      private string subGridanexos_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavDocanexoid_Internalname ;
      private string edtavDocanexoid_Jsonclick ;
      private string edtavDocumentoid_Internalname ;
      private string edtavDocumentoid_Jsonclick ;
      private string edtavDocanexoarquivo_Internalname ;
      private string edtavDocanexodatainclusao_Internalname ;
      private string edtavDocanexodatainclusao_Jsonclick ;
      private string Gridanexos_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtDocAnexoId_Internalname ;
      private string edtDocumentoId_Internalname ;
      private string edtDocAnexoArquivo_Internalname ;
      private string edtDocAnexoDescricao_Internalname ;
      private string edtDocAnexoDataInclusao_Internalname ;
      private string AV23Visualizar ;
      private string AV5Atualizar ;
      private string AV12Excluir ;
      private string GXDecQS ;
      private string GXCCtl ;
      private string tblTablearquivo_Internalname ;
      private string Arquivoupload_Tooltiptext ;
      private string Arquivoupload_Internalname ;
      private string sCtrlGx_mode ;
      private string sCtrlAV11DocumentoId ;
      private string sGXsfl_60_fel_idx="0001" ;
      private string subGridanexos_Class ;
      private string subGridanexos_Linesclass ;
      private string ROClassString ;
      private string edtDocAnexoId_Jsonclick ;
      private string edtDocumentoId_Jsonclick ;
      private string edtDocAnexoArquivo_Jsonclick ;
      private string edtDocAnexoDescricao_Jsonclick ;
      private string edtDocAnexoDataInclusao_Jsonclick ;
      private string edtavVisualizar_Jsonclick ;
      private string edtavAtualizar_Jsonclick ;
      private string edtavExcluir_Jsonclick ;
      private string subGridanexos_Header ;
      private DateTime AV8DocAnexoDataInclusao ;
      private DateTime A96DocAnexoDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_60_Refreshing=false ;
      private bool n40000ParametroValor ;
      private bool AV41CheckRequiredFieldsResult ;
      private bool Arquivoupload_Autoupload ;
      private bool Arquivoupload_Hideadditionalbuttons ;
      private bool Arquivoupload_Enableuploadedfilecanceling ;
      private bool Arquivoupload_Autodisableaddingfiles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV28descricaocadastrada ;
      private bool AV31ArquivoAnexado ;
      private bool AV33IsAuthorized_Visualizar ;
      private bool AV34IsAuthorized_Atualizar ;
      private bool AV35IsAuthorized_Excluir ;
      private bool AV42IsAuthorized_Adiciona ;
      private bool GXt_boolean1 ;
      private string AV16FiltroAnexo ;
      private string AV38caminhoDiretorio ;
      private string A40000ParametroValor ;
      private string AV26caminhoarquivo ;
      private string AV29NomeArquivo ;
      private string AV9DocAnexoDescricao ;
      private string AV7DocAnexoArquivo ;
      private string A95DocAnexoArquivo ;
      private string A94DocAnexoDescricao ;
      private string AV40Servidor ;
      private string AV25ArquivoAnexo ;
      private GXWebGrid GridanexosContainer ;
      private GXWebRow GridanexosRow ;
      private GXWebColumn GridanexosColumn ;
      private GXUserControl ucGridanexos_empowerer ;
      private GXUserControl ucArquivoupload ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H007O3_A40000ParametroValor ;
      private bool[] H007O3_n40000ParametroValor ;
      private DateTime[] H007O5_A96DocAnexoDataInclusao ;
      private string[] H007O5_A94DocAnexoDescricao ;
      private string[] H007O5_A95DocAnexoArquivo ;
      private int[] H007O5_A75DocumentoId ;
      private int[] H007O5_A93DocAnexoId ;
      private string[] H007O5_A40000ParametroValor ;
      private bool[] H007O5_n40000ParametroValor ;
      private long[] H007O7_AGRIDANEXOS_nRecordCount ;
      private string[] H007O9_A40000ParametroValor ;
      private bool[] H007O9_n40000ParametroValor ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV49GXV2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV52GXV5 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV54GXV7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV56GXV9 ;
      private GXBaseCollection<SdtFileUploadData> AV22UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV13FailedFiles ;
      private GxFile AV14File ;
      private GxDirectory AV37Directory ;
      private SdtDocAnexo AV6DocAnexo ;
      private GeneXus.Utils.SdtMessages_Message AV19message ;
      private SdtFileUploadData AV24FileUploadData ;
   }

   public class anexowc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class anexowc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H007O5( IGxContext context ,
                                           string AV16FiltroAnexo ,
                                           int A75DocumentoId ,
                                           int AV11DocumentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[5];
       Object[] GXv_Object3 = new Object[2];
       string sSelectString;
       string sFromString;
       string sOrderString;
       sSelectString = " T1.[DocAnexoDataInclusao], T1.[DocAnexoDescricao], T1.[DocAnexoArquivo], T1.[DocumentoId], T1.[DocAnexoId], COALESCE( T2.[ParametroValor], '') AS ParametroValor";
       sFromString = " FROM [DocAnexo] T1,  (SELECT [ParametroValor] AS ParametroValor, [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = 'SERVIDOR' ) T2";
       sOrderString = "";
       AddWhere(sWhereString, "(T1.[DocumentoId] = @AV11DocumentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FiltroAnexo)) )
       {
          AddWhere(sWhereString, "((CHARINDEX(RTRIM(RTRIM(LTRIM(@AV16FiltroAnexo))), T1.[DocAnexoDescricao])) >= 1)");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       sOrderString += " ORDER BY T1.[DocAnexoId]";
       scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    protected Object[] conditional_H007O7( IGxContext context ,
                                           string AV16FiltroAnexo ,
                                           int A75DocumentoId ,
                                           int AV11DocumentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int4 = new short[2];
       Object[] GXv_Object5 = new Object[2];
       scmdbuf = "SELECT COUNT(*) FROM [DocAnexo] T1,  (SELECT [ParametroValor] AS ParametroValor, [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = 'SERVIDOR' ) T2";
       AddWhere(sWhereString, "(T1.[DocumentoId] = @AV11DocumentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FiltroAnexo)) )
       {
          AddWhere(sWhereString, "((CHARINDEX(RTRIM(RTRIM(LTRIM(@AV16FiltroAnexo))), T1.[DocAnexoDescricao])) >= 1)");
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
             case 1 :
                   return conditional_H007O5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] );
             case 2 :
                   return conditional_H007O7(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] );
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
        Object[] prmH007O3;
        prmH007O3 = new Object[] {
        };
        Object[] prmH007O9;
        prmH007O9 = new Object[] {
        };
        Object[] prmH007O5;
        prmH007O5 = new Object[] {
        new ParDef("@AV11DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@AV16FiltroAnexo",GXType.VarChar,100,0) ,
        new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH007O7;
        prmH007O7 = new Object[] {
        new ParDef("@AV11DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@AV16FiltroAnexo",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("H007O3", "SELECT COALESCE( T1.[ParametroValor], '') AS ParametroValor FROM (SELECT [ParametroValor] AS ParametroValor, [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = 'SERVIDOR' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007O5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O5,51, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007O7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007O9", "SELECT COALESCE( T1.[ParametroValor], '') AS ParametroValor FROM (SELECT [ParametroValor] AS ParametroValor, [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = 'SERVIDOR' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O9,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 1 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
