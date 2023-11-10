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
   public class revisaowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public revisaowc( )
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

      public revisaowc( IGxContext context )
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
         this.AV6DocumentoId = aP1_DocumentoId;
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
                  AV6DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
                  AssignAttri(sPrefix, false, "AV6DocumentoId", StringUtil.LTrimStr( (decimal)(AV6DocumentoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV6DocumentoId});
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
         nRC_GXsfl_23 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_23"), "."));
         nGXsfl_23_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_23_idx"), "."));
         sGXsfl_23_idx = GetPar( "sGXsfl_23_idx");
         sPrefix = GetPar( "sPrefix");
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
         A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
         AV6DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
         A120RevisaoLogId = (int)(NumberUtil.Val( GetPar( "RevisaoLogId"), "."));
         A121RevisaoLogUsuarioAlteracao = GetPar( "RevisaoLogUsuarioAlteracao");
         A123RevisaoLogDataAlteracao = context.localUtil.ParseDTimeParm( GetPar( "RevisaoLogDataAlteracao"));
         A122RevisaoLogObservacao = GetPar( "RevisaoLogObservacao");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
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
            PA7N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavRevisaologidgrid_Enabled = 0;
               AssignProp(sPrefix, false, edtavRevisaologidgrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologidgrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
               edtavRevisaologusuarioalteracaogrid_Enabled = 0;
               AssignProp(sPrefix, false, edtavRevisaologusuarioalteracaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologusuarioalteracaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
               edtavRevisaologdataalteracaogrid_Enabled = 0;
               AssignProp(sPrefix, false, edtavRevisaologdataalteracaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologdataalteracaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
               edtavRevisaologobservacaogrid_Enabled = 0;
               AssignProp(sPrefix, false, edtavRevisaologobservacaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologobservacaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
               edtavVisualizar_Enabled = 0;
               AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_23_Refreshing);
               WS7N2( ) ;
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
            context.SendWebValue( "Aba de Revisão para o cadastro de um Documento") ;
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
               GXEncryptionTmp = "revisaowc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV6DocumentoId,8,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("revisaowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_23", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_23), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REVISAOLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A120RevisaoLogId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REVISAOLOGUSUARIOALTERACAO", A121RevisaoLogUsuarioAlteracao);
         GxWebStd.gx_hidden_field( context, sPrefix+"REVISAOLOGDATAALTERACAO", context.localUtil.TToC( A123RevisaoLogDataAlteracao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"REVISAOLOGOBSERVACAO", A122RevisaoLogObservacao);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vREVISAOLOG", AV8RevisaoLog);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vREVISAOLOG", AV8RevisaoLog);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Grid1_empowerer_Infinitescrolling));
      }

      protected void RenderHtmlCloseForm7N2( )
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
         return "RevisaoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aba de Revisão para o cadastro de um Documento" ;
      }

      protected void WB7N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "revisaowc.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavRevisaologobservacao_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRevisaologobservacao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRevisaologobservacao_Internalname, "OBSERVAÇÃO", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_23_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavRevisaologobservacao_Internalname, AV11RevisaoLogObservacao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", 0, edtavRevisaologobservacao_Visible, edtavRevisaologobservacao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "10000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_RevisaoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsalvar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(23), 2, 0)+","+"null"+");", "SALVAR", bttBtnsalvar_Jsonclick, 5, "SALVAR", "", StyleString, ClassString, bttBtnsalvar_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSALVAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RevisaoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl23( ) ;
         }
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            nRC_GXsfl_23 = (int)(nGXsfl_23_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_23_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRevisaologid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10RevisaoLogId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10RevisaoLogId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRevisaologid_Jsonclick, 0, "Attribute", "", "", "", "", edtavRevisaologid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RevisaoWC.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocumentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocumentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocumentoid_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RevisaoWC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_23_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRevisaologusuarioalteracao_Internalname, AV12RevisaoLogUsuarioAlteracao, StringUtil.RTrim( context.localUtil.Format( AV12RevisaoLogUsuarioAlteracao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRevisaologusuarioalteracao_Jsonclick, 0, "Attribute", "", "", "", "", edtavRevisaologusuarioalteracao_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RevisaoWC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_23_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavRevisaologdataalteracao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavRevisaologdataalteracao_Internalname, context.localUtil.TToC( AV9RevisaoLogDataAlteracao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV9RevisaoLogDataAlteracao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRevisaologdataalteracao_Jsonclick, 0, "Attribute", "", "", "", "", edtavRevisaologdataalteracao_Visible, 1, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RevisaoWC.htm");
            GxWebStd.gx_bitmap( context, edtavRevisaologdataalteracao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavRevisaologdataalteracao_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RevisaoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* User Defined Control */
            ucGrid1_empowerer.SetProperty("InfiniteScrolling", Grid1_empowerer_Infinitescrolling);
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, sPrefix+"GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 23 )
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

      protected void START7N2( )
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
               Form.Meta.addItem("description", "Aba de Revisão para o cadastro de um Documento", 0) ;
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
               STRUP7N0( ) ;
            }
         }
      }

      protected void WS7N2( )
      {
         START7N2( ) ;
         EVT7N2( ) ;
      }

      protected void EVT7N2( )
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
                                 STRUP7N0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOSALVAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSalvar' */
                                    E117N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavRevisaologidgrid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7N0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVISUALIZAR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7N0( ) ;
                              }
                              nGXsfl_23_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
                              SubsflControlProps_232( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavRevisaologidgrid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRevisaologidgrid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREVISAOLOGIDGRID");
                                 GX_FocusControl = edtavRevisaologidgrid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV23RevisaoLogIdGrid = 0;
                                 AssignAttri(sPrefix, false, edtavRevisaologidgrid_Internalname, StringUtil.LTrimStr( (decimal)(AV23RevisaoLogIdGrid), 8, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREVISAOLOGIDGRID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sPrefix+sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV23RevisaoLogIdGrid = (int)(context.localUtil.CToN( cgiGet( edtavRevisaologidgrid_Internalname), ",", "."));
                                 AssignAttri(sPrefix, false, edtavRevisaologidgrid_Internalname, StringUtil.LTrimStr( (decimal)(AV23RevisaoLogIdGrid), 8, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREVISAOLOGIDGRID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sPrefix+sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9"), context));
                              }
                              AV24RevisaoLogUsuarioAlteracaoGrid = cgiGet( edtavRevisaologusuarioalteracaogrid_Internalname);
                              AssignAttri(sPrefix, false, edtavRevisaologusuarioalteracaogrid_Internalname, AV24RevisaoLogUsuarioAlteracaoGrid);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavRevisaologdataalteracaogrid_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Revisao Log Data Alteracao Grid"}), 1, "vREVISAOLOGDATAALTERACAOGRID");
                                 GX_FocusControl = edtavRevisaologdataalteracaogrid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV25RevisaoLogDataAlteracaoGrid = (DateTime)(DateTime.MinValue);
                                 AssignAttri(sPrefix, false, edtavRevisaologdataalteracaogrid_Internalname, context.localUtil.TToC( AV25RevisaoLogDataAlteracaoGrid, 8, 5, 0, 3, "/", ":", " "));
                              }
                              else
                              {
                                 AV25RevisaoLogDataAlteracaoGrid = context.localUtil.CToT( cgiGet( edtavRevisaologdataalteracaogrid_Internalname), 0);
                                 AssignAttri(sPrefix, false, edtavRevisaologdataalteracaogrid_Internalname, context.localUtil.TToC( AV25RevisaoLogDataAlteracaoGrid, 8, 5, 0, 3, "/", ":", " "));
                              }
                              AV26RevisaoLogObservacaoGrid = cgiGet( edtavRevisaologobservacaogrid_Internalname);
                              AssignAttri(sPrefix, false, edtavRevisaologobservacaogrid_Internalname, AV26RevisaoLogObservacaoGrid);
                              AV17Visualizar = cgiGet( edtavVisualizar_Internalname);
                              AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV17Visualizar);
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
                                          GX_FocusControl = edtavRevisaologidgrid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E127N2 ();
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
                                          GX_FocusControl = edtavRevisaologidgrid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E137N2 ();
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
                                          GX_FocusControl = edtavRevisaologidgrid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E147N2 ();
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
                                          GX_FocusControl = edtavRevisaologidgrid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E157N2 ();
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
                                       STRUP7N0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavRevisaologidgrid_Internalname;
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

      protected void WE7N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7N2( ) ;
            }
         }
      }

      protected void PA7N2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "revisaowc.aspx")), "revisaowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "revisaowc.aspx")))) ;
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
               GX_FocusControl = edtavRevisaologobservacao_Internalname;
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
         SubsflControlProps_232( ) ;
         while ( nGXsfl_23_idx <= nRC_GXsfl_23 )
         {
            sendrow_232( ) ;
            nGXsfl_23_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int A75DocumentoId ,
                                        int AV6DocumentoId ,
                                        int A120RevisaoLogId ,
                                        string A121RevisaoLogUsuarioAlteracao ,
                                        DateTime A123RevisaoLogDataAlteracao ,
                                        string A122RevisaoLogObservacao ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E137N2 ();
         GRID1_nCurrentRecord = 0;
         RF7N2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREVISAOLOGIDGRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREVISAOLOGIDGRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23RevisaoLogIdGrid), 8, 0, ".", "")));
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
         GRID1_nFirstRecordOnPage = 0;
         GRID1_nCurrentRecord = 0;
         GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_23_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF7N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavRevisaologidgrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologidgrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologidgrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavRevisaologusuarioalteracaogrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologusuarioalteracaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologusuarioalteracaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavRevisaologdataalteracaogrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologdataalteracaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologdataalteracaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavRevisaologobservacaogrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologobservacaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologobservacaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_23_Refreshing);
      }

      protected void RF7N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 23;
         /* Execute user event: Refresh */
         E137N2 ();
         nGXsfl_23_idx = (int)(1+GRID1_nFirstRecordOnPage);
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         bGXsfl_23_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", sPrefix);
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_232( ) ;
            E147N2 ();
            if ( ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_23_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               E147N2 ();
            }
            wbEnd = 23;
            WB7N0( ) ;
         }
         bGXsfl_23_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7N2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREVISAOLOGIDGRID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sPrefix+sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(((subGrid1_Recordcount==0) ? GRID1_nFirstRecordOnPage+1 : subGrid1_Recordcount)) ;
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
         return (int)(((subGrid1_Islastpage==1) ? subGrid1_fnc_Recordcount( )/ (decimal)(subGrid1_fnc_Recordsperpage( ))+((((int)((subGrid1_fnc_Recordcount( )) % (subGrid1_fnc_Recordsperpage( ))))==0) ? 0 : 1) : (decimal)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1))) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         if ( GRID1_nEOF == 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         if ( GRID1_nEOF == 1 )
         {
            GRID1_nFirstRecordOnPage = GRID1_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavRevisaologidgrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologidgrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologidgrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavRevisaologusuarioalteracaogrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologusuarioalteracaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologusuarioalteracaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavRevisaologdataalteracaogrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologdataalteracaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologdataalteracaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavRevisaologobservacaogrid_Enabled = 0;
         AssignProp(sPrefix, false, edtavRevisaologobservacaogrid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRevisaologobservacaogrid_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         edtavVisualizar_Enabled = 0;
         AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Enabled), 5, 0), !bGXsfl_23_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_23 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_23"), ",", "."));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV6DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6DocumentoId"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nEOF"), ",", "."));
            subGrid1_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Grid1_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID1_EMPOWERER_Gridinternalname");
            Grid1_empowerer_Infinitescrolling = cgiGet( sPrefix+"GRID1_EMPOWERER_Infinitescrolling");
            /* Read variables values. */
            AV11RevisaoLogObservacao = cgiGet( edtavRevisaologobservacao_Internalname);
            AssignAttri(sPrefix, false, "AV11RevisaoLogObservacao", AV11RevisaoLogObservacao);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRevisaologid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRevisaologid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREVISAOLOGID");
               GX_FocusControl = edtavRevisaologid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10RevisaoLogId = 0;
               AssignAttri(sPrefix, false, "AV10RevisaoLogId", StringUtil.LTrimStr( (decimal)(AV10RevisaoLogId), 8, 0));
            }
            else
            {
               AV10RevisaoLogId = (int)(context.localUtil.CToN( cgiGet( edtavRevisaologid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV10RevisaoLogId", StringUtil.LTrimStr( (decimal)(AV10RevisaoLogId), 8, 0));
            }
            AV12RevisaoLogUsuarioAlteracao = cgiGet( edtavRevisaologusuarioalteracao_Internalname);
            AssignAttri(sPrefix, false, "AV12RevisaoLogUsuarioAlteracao", AV12RevisaoLogUsuarioAlteracao);
            if ( context.localUtil.VCDateTime( cgiGet( edtavRevisaologdataalteracao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Revisao Log Data Alteracao"}), 1, "vREVISAOLOGDATAALTERACAO");
               GX_FocusControl = edtavRevisaologdataalteracao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV9RevisaoLogDataAlteracao", context.localUtil.TToC( AV9RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV9RevisaoLogDataAlteracao = context.localUtil.CToT( cgiGet( edtavRevisaologdataalteracao_Internalname));
               AssignAttri(sPrefix, false, "AV9RevisaoLogDataAlteracao", context.localUtil.TToC( AV9RevisaoLogDataAlteracao, 8, 5, 0, 3, "/", ":", " "));
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
         E127N2 ();
         if (returnInSub) return;
      }

      protected void E127N2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavRevisaologid_Visible = 0;
         AssignProp(sPrefix, false, edtavRevisaologid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRevisaologid_Visible), 5, 0), true);
         edtavDocumentoid_Visible = 0;
         AssignProp(sPrefix, false, edtavDocumentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocumentoid_Visible), 5, 0), true);
         edtavRevisaologusuarioalteracao_Visible = 0;
         AssignProp(sPrefix, false, edtavRevisaologusuarioalteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRevisaologusuarioalteracao_Visible), 5, 0), true);
         edtavRevisaologdataalteracao_Visible = 0;
         AssignProp(sPrefix, false, edtavRevisaologdataalteracao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRevisaologdataalteracao_Visible), 5, 0), true);
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, sPrefix, false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            edtavRevisaologobservacao_Visible = 0;
            AssignProp(sPrefix, false, edtavRevisaologobservacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRevisaologobservacao_Visible), 5, 0), true);
            bttBtnsalvar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsalvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsalvar_Visible), 5, 0), true);
         }
      }

      protected void E137N2( )
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
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E147N2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV17Visualizar = "<i class=\"fas fa-magnifying-glass\"></i>";
         AssignAttri(sPrefix, false, edtavVisualizar_Internalname, AV17Visualizar);
         /* Using cursor H007N2 */
         pr_default.execute(0, new Object[] {AV6DocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = H007N2_A75DocumentoId[0];
            A120RevisaoLogId = H007N2_A120RevisaoLogId[0];
            A121RevisaoLogUsuarioAlteracao = H007N2_A121RevisaoLogUsuarioAlteracao[0];
            A123RevisaoLogDataAlteracao = H007N2_A123RevisaoLogDataAlteracao[0];
            A122RevisaoLogObservacao = H007N2_A122RevisaoLogObservacao[0];
            AV23RevisaoLogIdGrid = A120RevisaoLogId;
            AssignAttri(sPrefix, false, edtavRevisaologidgrid_Internalname, StringUtil.LTrimStr( (decimal)(AV23RevisaoLogIdGrid), 8, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREVISAOLOGIDGRID"+"_"+sGXsfl_23_idx, GetSecureSignedToken( sPrefix+sGXsfl_23_idx, context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9"), context));
            AV24RevisaoLogUsuarioAlteracaoGrid = A121RevisaoLogUsuarioAlteracao;
            AssignAttri(sPrefix, false, edtavRevisaologusuarioalteracaogrid_Internalname, AV24RevisaoLogUsuarioAlteracaoGrid);
            AV25RevisaoLogDataAlteracaoGrid = A123RevisaoLogDataAlteracao;
            AssignAttri(sPrefix, false, edtavRevisaologdataalteracaogrid_Internalname, context.localUtil.TToC( AV25RevisaoLogDataAlteracaoGrid, 8, 5, 0, 3, "/", ":", " "));
            AV26RevisaoLogObservacaoGrid = StringUtil.Substring( A122RevisaoLogObservacao, 1, 80);
            AssignAttri(sPrefix, false, edtavRevisaologobservacaogrid_Internalname, AV26RevisaoLogObservacaoGrid);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 23;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_232( ) ;
               GRID1_nEOF = 1;
               GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
               if ( ( subGrid1_Islastpage == 1 ) && ( ((int)((GRID1_nCurrentRecord) % (subGrid1_fnc_Recordsperpage( )))) == 0 ) )
               {
                  GRID1_nFirstRecordOnPage = GRID1_nCurrentRecord;
               }
            }
            if ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) )
            {
               GRID1_nEOF = 0;
               GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            }
            GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_23_Refreshing )
            {
               context.DoAjaxLoad(23, Grid1Row);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /*  Sending Event outputs  */
      }

      protected void E117N2( )
      {
         /* 'DoSalvar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult )
         {
            AV8RevisaoLog.gxTpr_Documentoid = AV6DocumentoId;
            AV8RevisaoLog.gxTpr_Revisaologusuarioalteracao = AV12RevisaoLogUsuarioAlteracao;
            AV8RevisaoLog.gxTpr_Revisaologobservacao = AV11RevisaoLogObservacao;
            AV8RevisaoLog.gxTpr_Revisaologdataalteracao = AV9RevisaoLogDataAlteracao;
            AV8RevisaoLog.Insert();
            if ( AV8RevisaoLog.Success() )
            {
               context.CommitDataStores("revisaowc",pr_default);
               AV11RevisaoLogObservacao = "";
               AssignAttri(sPrefix, false, "AV11RevisaoLogObservacao", AV11RevisaoLogObservacao);
            }
            else
            {
               AV34GXV2 = 1;
               AV33GXV1 = AV8RevisaoLog.GetMessages();
               while ( AV34GXV2 <= AV33GXV1.Count )
               {
                  AV7Message = ((GeneXus.Utils.SdtMessages_Message)AV33GXV1.Item(AV34GXV2));
                  GX_msglist.addItem(AV7Message.gxTpr_Description);
                  AV34GXV2 = (int)(AV34GXV2+1);
               }
            }
            GRID1_nFirstRecordOnPage = 0;
            GRID1_nCurrentRecord = 0;
            GXCCtl = "GRID1_nFirstRecordOnPage_" + sGXsfl_23_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            gxgrGrid1_refresh( subGrid1_Rows, A75DocumentoId, AV6DocumentoId, A120RevisaoLogId, A121RevisaoLogUsuarioAlteracao, A123RevisaoLogDataAlteracao, A122RevisaoLogObservacao, sPrefix) ;
         }
         else
         {
            GX_msglist.addItem("Revise os campos obrigatórios");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8RevisaoLog", AV8RevisaoLog);
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV27IsAuthorized_Salvar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaRevisaoSalva", out  GXt_boolean1) ;
         AV27IsAuthorized_Salvar = GXt_boolean1;
         if ( ! ( AV27IsAuthorized_Salvar ) )
         {
            bttBtnsalvar_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsalvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsalvar_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV28IsAuthorized_Visualizar;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "AbaRevisaoVisualiza", out  GXt_boolean1) ;
         AV28IsAuthorized_Visualizar = GXt_boolean1;
         if ( ! ( AV28IsAuthorized_Visualizar ) )
         {
            edtavVisualizar_Visible = 0;
            AssignProp(sPrefix, false, edtavVisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisualizar_Visible), 5, 0), !bGXsfl_23_Refreshing);
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11RevisaoLogObservacao)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "(*)",  "error",  edtavRevisaologobservacao_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
      }

      protected void E157N2( )
      {
         /* Visualizar_Click Routine */
         returnInSub = false;
         AV18Window.Autoresize = 0;
         AV18Window.Height = 500;
         AV18Window.Width = 700;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "revisaovisualizar.aspx"+UrlEncode(StringUtil.LTrimStr(AV23RevisaoLogIdGrid,8,0));
         AV18Window.Url = formatLink("revisaovisualizar.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV18Window.SetReturnParms(new Object[] {});
         context.NewWindow(AV18Window);
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV6DocumentoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV6DocumentoId", StringUtil.LTrimStr( (decimal)(AV6DocumentoId), 8, 0));
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
         PA7N2( ) ;
         WS7N2( ) ;
         WE7N2( ) ;
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
         sCtrlAV6DocumentoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "revisaowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV6DocumentoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV6DocumentoId", StringUtil.LTrimStr( (decimal)(AV6DocumentoId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV6DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6DocumentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV6DocumentoId != wcpOAV6DocumentoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV6DocumentoId = AV6DocumentoId;
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
         sCtrlAV6DocumentoId = cgiGet( sPrefix+"AV6DocumentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV6DocumentoId) > 0 )
         {
            AV6DocumentoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV6DocumentoId), ",", "."));
            AssignAttri(sPrefix, false, "AV6DocumentoId", StringUtil.LTrimStr( (decimal)(AV6DocumentoId), 8, 0));
         }
         else
         {
            AV6DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV6DocumentoId_PARM"), ",", "."));
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
         PA7N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7N2( ) ;
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
         WS7N2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6DocumentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DocumentoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6DocumentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6DocumentoId_CTRL", StringUtil.RTrim( sCtrlAV6DocumentoId));
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
         WE7N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910464062", true, true);
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
            context.AddJavascriptSource("revisaowc.js", "?202311910464062", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_232( )
      {
         edtavRevisaologidgrid_Internalname = sPrefix+"vREVISAOLOGIDGRID_"+sGXsfl_23_idx;
         edtavRevisaologusuarioalteracaogrid_Internalname = sPrefix+"vREVISAOLOGUSUARIOALTERACAOGRID_"+sGXsfl_23_idx;
         edtavRevisaologdataalteracaogrid_Internalname = sPrefix+"vREVISAOLOGDATAALTERACAOGRID_"+sGXsfl_23_idx;
         edtavRevisaologobservacaogrid_Internalname = sPrefix+"vREVISAOLOGOBSERVACAOGRID_"+sGXsfl_23_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_23_idx;
      }

      protected void SubsflControlProps_fel_232( )
      {
         edtavRevisaologidgrid_Internalname = sPrefix+"vREVISAOLOGIDGRID_"+sGXsfl_23_fel_idx;
         edtavRevisaologusuarioalteracaogrid_Internalname = sPrefix+"vREVISAOLOGUSUARIOALTERACAOGRID_"+sGXsfl_23_fel_idx;
         edtavRevisaologdataalteracaogrid_Internalname = sPrefix+"vREVISAOLOGDATAALTERACAOGRID_"+sGXsfl_23_fel_idx;
         edtavRevisaologobservacaogrid_Internalname = sPrefix+"vREVISAOLOGOBSERVACAOGRID_"+sGXsfl_23_fel_idx;
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR_"+sGXsfl_23_fel_idx;
      }

      protected void sendrow_232( )
      {
         SubsflControlProps_232( ) ;
         WB7N0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_23_idx - GRID1_nFirstRecordOnPage <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_23_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_23_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavRevisaologidgrid_Enabled!=0)&&(edtavRevisaologidgrid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 24,'"+sPrefix+"',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRevisaologidgrid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23RevisaoLogIdGrid), 8, 0, ",", "")),StringUtil.LTrim( ((edtavRevisaologidgrid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23RevisaoLogIdGrid), "ZZZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavRevisaologidgrid_Enabled!=0)&&(edtavRevisaologidgrid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRevisaologidgrid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavRevisaologidgrid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavRevisaologusuarioalteracaogrid_Enabled!=0)&&(edtavRevisaologusuarioalteracaogrid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 25,'"+sPrefix+"',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRevisaologusuarioalteracaogrid_Internalname,(string)AV24RevisaoLogUsuarioAlteracaoGrid,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavRevisaologusuarioalteracaogrid_Enabled!=0)&&(edtavRevisaologusuarioalteracaogrid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,25);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRevisaologusuarioalteracaogrid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavRevisaologusuarioalteracaogrid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavRevisaologdataalteracaogrid_Enabled!=0)&&(edtavRevisaologdataalteracaogrid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRevisaologdataalteracaogrid_Internalname,context.localUtil.TToC( AV25RevisaoLogDataAlteracaoGrid, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( AV25RevisaoLogDataAlteracaoGrid, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavRevisaologdataalteracaogrid_Enabled!=0)&&(edtavRevisaologdataalteracaogrid_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,26);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRevisaologdataalteracaogrid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavRevisaologdataalteracaogrid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavRevisaologobservacaogrid_Enabled!=0)&&(edtavRevisaologobservacaogrid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'"+sPrefix+"',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRevisaologobservacaogrid_Internalname,StringUtil.RTrim( AV26RevisaoLogObservacaoGrid),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavRevisaologobservacaogrid_Enabled!=0)&&(edtavRevisaologobservacaogrid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,27);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRevisaologobservacaogrid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavRevisaologobservacaogrid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVisualizar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'"+sPrefix+"',false,'"+sGXsfl_23_idx+"',23)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavVisualizar_Internalname,StringUtil.RTrim( AV17Visualizar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavVisualizar_Enabled!=0)&&(edtavVisualizar_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,28);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVVISUALIZAR.CLICK."+sGXsfl_23_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavVisualizar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavVisualizar_Visible,(int)edtavVisualizar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes7N2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_23_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         /* End function sendrow_232 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl23( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"DivS\" data-gxgridid=\"23\">") ;
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
            context.SendWebValue( "Revisao Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "USUÁRIO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "DATA ALTERAÇÃO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "OBSERVAÇÃO") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavVisualizar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", sPrefix);
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23RevisaoLogIdGrid), 8, 0, ".", "")));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRevisaologidgrid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", AV24RevisaoLogUsuarioAlteracaoGrid);
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRevisaologusuarioalteracaogrid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( AV25RevisaoLogDataAlteracaoGrid, 10, 8, 0, 3, "/", ":", " "));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRevisaologdataalteracaogrid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV26RevisaoLogObservacaoGrid));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRevisaologobservacaogrid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV17Visualizar));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisualizar_Visible), 5, 0, ".", "")));
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
         edtavRevisaologobservacao_Internalname = sPrefix+"vREVISAOLOGOBSERVACAO";
         bttBtnsalvar_Internalname = sPrefix+"BTNSALVAR";
         edtavRevisaologidgrid_Internalname = sPrefix+"vREVISAOLOGIDGRID";
         edtavRevisaologusuarioalteracaogrid_Internalname = sPrefix+"vREVISAOLOGUSUARIOALTERACAOGRID";
         edtavRevisaologdataalteracaogrid_Internalname = sPrefix+"vREVISAOLOGDATAALTERACAOGRID";
         edtavRevisaologobservacaogrid_Internalname = sPrefix+"vREVISAOLOGOBSERVACAOGRID";
         edtavVisualizar_Internalname = sPrefix+"vVISUALIZAR";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavRevisaologid_Internalname = sPrefix+"vREVISAOLOGID";
         edtavDocumentoid_Internalname = sPrefix+"vDOCUMENTOID";
         edtavRevisaologusuarioalteracao_Internalname = sPrefix+"vREVISAOLOGUSUARIOALTERACAO";
         edtavRevisaologdataalteracao_Internalname = sPrefix+"vREVISAOLOGDATAALTERACAO";
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
         edtavVisualizar_Jsonclick = "";
         edtavVisualizar_Enabled = 1;
         edtavRevisaologobservacaogrid_Jsonclick = "";
         edtavRevisaologobservacaogrid_Visible = -1;
         edtavRevisaologobservacaogrid_Enabled = 1;
         edtavRevisaologdataalteracaogrid_Jsonclick = "";
         edtavRevisaologdataalteracaogrid_Visible = -1;
         edtavRevisaologdataalteracaogrid_Enabled = 1;
         edtavRevisaologusuarioalteracaogrid_Jsonclick = "";
         edtavRevisaologusuarioalteracaogrid_Visible = -1;
         edtavRevisaologusuarioalteracaogrid_Enabled = 1;
         edtavRevisaologidgrid_Jsonclick = "";
         edtavRevisaologidgrid_Visible = 0;
         edtavRevisaologidgrid_Enabled = 1;
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavVisualizar_Visible = -1;
         edtavRevisaologdataalteracao_Jsonclick = "";
         edtavRevisaologdataalteracao_Visible = 1;
         edtavRevisaologusuarioalteracao_Jsonclick = "";
         edtavRevisaologusuarioalteracao_Visible = 1;
         edtavDocumentoid_Jsonclick = "";
         edtavDocumentoid_Visible = 1;
         edtavRevisaologid_Jsonclick = "";
         edtavRevisaologid_Visible = 1;
         bttBtnsalvar_Visible = 1;
         edtavRevisaologobservacao_Enabled = 1;
         edtavRevisaologobservacao_Visible = 1;
         Grid1_empowerer_Infinitescrolling = "Form";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'BTNSALVAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E147N2',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV17Visualizar',fld:'vVISUALIZAR',pic:''},{av:'AV23RevisaoLogIdGrid',fld:'vREVISAOLOGIDGRID',pic:'ZZZZZZZ9',hsh:true},{av:'AV24RevisaoLogUsuarioAlteracaoGrid',fld:'vREVISAOLOGUSUARIOALTERACAOGRID',pic:''},{av:'AV25RevisaoLogDataAlteracaoGrid',fld:'vREVISAOLOGDATAALTERACAOGRID',pic:'99/99/99 99:99'},{av:'AV26RevisaoLogObservacaoGrid',fld:'vREVISAOLOGOBSERVACAOGRID',pic:''}]}");
         setEventMetadata("'DOSALVAR'","{handler:'E117N2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''},{av:'sPrefix'},{av:'AV5CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV8RevisaoLog',fld:'vREVISAOLOG',pic:''},{av:'AV12RevisaoLogUsuarioAlteracao',fld:'vREVISAOLOGUSUARIOALTERACAO',pic:''},{av:'AV11RevisaoLogObservacao',fld:'vREVISAOLOGOBSERVACAO',pic:''},{av:'AV9RevisaoLogDataAlteracao',fld:'vREVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'}]");
         setEventMetadata("'DOSALVAR'",",oparms:[{av:'AV8RevisaoLog',fld:'vREVISAOLOG',pic:''},{av:'AV11RevisaoLogObservacao',fld:'vREVISAOLOGOBSERVACAO',pic:''},{av:'AV5CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{ctrl:'BTNSALVAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'}]}");
         setEventMetadata("VVISUALIZAR.CLICK","{handler:'E157N2',iparms:[{av:'AV23RevisaoLogIdGrid',fld:'vREVISAOLOGIDGRID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("VVISUALIZAR.CLICK",",oparms:[]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{ctrl:'BTNSALVAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{ctrl:'BTNSALVAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{ctrl:'BTNSALVAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'AV6DocumentoId',fld:'vDOCUMENTOID',pic:'ZZZZZZZ9'},{av:'A120RevisaoLogId',fld:'REVISAOLOGID',pic:'ZZZZZZZ9'},{av:'A121RevisaoLogUsuarioAlteracao',fld:'REVISAOLOGUSUARIOALTERACAO',pic:''},{av:'A123RevisaoLogDataAlteracao',fld:'REVISAOLOGDATAALTERACAO',pic:'99/99/99 99:99'},{av:'A122RevisaoLogObservacao',fld:'REVISAOLOGOBSERVACAO',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{ctrl:'BTNSALVAR',prop:'Visible'},{av:'edtavVisualizar_Visible',ctrl:'vVISUALIZAR',prop:'Visible'}]}");
         setEventMetadata("VALIDV_DOCUMENTOID","{handler:'Validv_Documentoid',iparms:[]");
         setEventMetadata("VALIDV_DOCUMENTOID",",oparms:[]}");
         setEventMetadata("VALIDV_REVISAOLOGDATAALTERACAO","{handler:'Validv_Revisaologdataalteracao',iparms:[]");
         setEventMetadata("VALIDV_REVISAOLOGDATAALTERACAO",",oparms:[]}");
         setEventMetadata("VALIDV_REVISAOLOGDATAALTERACAOGRID","{handler:'Validv_Revisaologdataalteracaogrid',iparms:[]");
         setEventMetadata("VALIDV_REVISAOLOGDATAALTERACAOGRID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Visualizar',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         A122RevisaoLogObservacao = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV8RevisaoLog = new SdtRevisaoLog(context);
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV11RevisaoLogObservacao = "";
         bttBtnsalvar_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         AV12RevisaoLogUsuarioAlteracao = "";
         AV9RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         ucGrid1_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV24RevisaoLogUsuarioAlteracaoGrid = "";
         AV25RevisaoLogDataAlteracaoGrid = (DateTime)(DateTime.MinValue);
         AV26RevisaoLogObservacaoGrid = "";
         AV17Visualizar = "";
         GXDecQS = "";
         GXCCtl = "";
         scmdbuf = "";
         H007N2_A75DocumentoId = new int[1] ;
         H007N2_A120RevisaoLogId = new int[1] ;
         H007N2_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         H007N2_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         H007N2_A122RevisaoLogObservacao = new string[] {""} ;
         Grid1Row = new GXWebRow();
         AV33GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV7Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV18Window = new GXWindow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV6DocumentoId = "";
         subGrid1_Linesclass = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.revisaowc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaowc__default(),
            new Object[][] {
                new Object[] {
               H007N2_A75DocumentoId, H007N2_A120RevisaoLogId, H007N2_A121RevisaoLogUsuarioAlteracao, H007N2_A123RevisaoLogDataAlteracao, H007N2_A122RevisaoLogObservacao
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavRevisaologidgrid_Enabled = 0;
         edtavRevisaologusuarioalteracaogrid_Enabled = 0;
         edtavRevisaologdataalteracaogrid_Enabled = 0;
         edtavRevisaologobservacaogrid_Enabled = 0;
         edtavVisualizar_Enabled = 0;
      }

      private short GRID1_nEOF ;
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
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV6DocumentoId ;
      private int wcpOAV6DocumentoId ;
      private int nRC_GXsfl_23 ;
      private int subGrid1_Rows ;
      private int nGXsfl_23_idx=1 ;
      private int A75DocumentoId ;
      private int A120RevisaoLogId ;
      private int edtavRevisaologidgrid_Enabled ;
      private int edtavRevisaologusuarioalteracaogrid_Enabled ;
      private int edtavRevisaologdataalteracaogrid_Enabled ;
      private int edtavRevisaologobservacaogrid_Enabled ;
      private int edtavVisualizar_Enabled ;
      private int edtavRevisaologobservacao_Visible ;
      private int edtavRevisaologobservacao_Enabled ;
      private int bttBtnsalvar_Visible ;
      private int AV10RevisaoLogId ;
      private int edtavRevisaologid_Visible ;
      private int edtavDocumentoid_Visible ;
      private int edtavRevisaologusuarioalteracao_Visible ;
      private int edtavRevisaologdataalteracao_Visible ;
      private int AV23RevisaoLogIdGrid ;
      private int subGrid1_Islastpage ;
      private int GRID1_nGridOutOfScope ;
      private int subGrid1_Recordcount ;
      private int AV34GXV2 ;
      private int edtavVisualizar_Visible ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavRevisaologidgrid_Visible ;
      private int edtavRevisaologusuarioalteracaogrid_Visible ;
      private int edtavRevisaologdataalteracaogrid_Visible ;
      private int edtavRevisaologobservacaogrid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_23_idx="0001" ;
      private string edtavRevisaologidgrid_Internalname ;
      private string edtavRevisaologusuarioalteracaogrid_Internalname ;
      private string edtavRevisaologdataalteracaogrid_Internalname ;
      private string edtavRevisaologobservacaogrid_Internalname ;
      private string edtavVisualizar_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Grid1_empowerer_Gridinternalname ;
      private string Grid1_empowerer_Infinitescrolling ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string edtavRevisaologobservacao_Internalname ;
      private string TempTags ;
      private string bttBtnsalvar_Internalname ;
      private string bttBtnsalvar_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavRevisaologid_Internalname ;
      private string edtavRevisaologid_Jsonclick ;
      private string edtavDocumentoid_Internalname ;
      private string edtavDocumentoid_Jsonclick ;
      private string edtavRevisaologusuarioalteracao_Internalname ;
      private string edtavRevisaologusuarioalteracao_Jsonclick ;
      private string edtavRevisaologdataalteracao_Internalname ;
      private string edtavRevisaologdataalteracao_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV26RevisaoLogObservacaoGrid ;
      private string AV17Visualizar ;
      private string GXDecQS ;
      private string GXCCtl ;
      private string scmdbuf ;
      private string sCtrlGx_mode ;
      private string sCtrlAV6DocumentoId ;
      private string sGXsfl_23_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavRevisaologidgrid_Jsonclick ;
      private string edtavRevisaologusuarioalteracaogrid_Jsonclick ;
      private string edtavRevisaologdataalteracaogrid_Jsonclick ;
      private string edtavRevisaologobservacaogrid_Jsonclick ;
      private string edtavVisualizar_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private DateTime AV9RevisaoLogDataAlteracao ;
      private DateTime AV25RevisaoLogDataAlteracaoGrid ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_23_Refreshing=false ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV27IsAuthorized_Salvar ;
      private bool AV28IsAuthorized_Visualizar ;
      private bool GXt_boolean1 ;
      private string A122RevisaoLogObservacao ;
      private string AV11RevisaoLogObservacao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string AV12RevisaoLogUsuarioAlteracao ;
      private string AV24RevisaoLogUsuarioAlteracaoGrid ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucGrid1_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H007N2_A75DocumentoId ;
      private int[] H007N2_A120RevisaoLogId ;
      private string[] H007N2_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] H007N2_A123RevisaoLogDataAlteracao ;
      private string[] H007N2_A122RevisaoLogObservacao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV33GXV1 ;
      private GXWindow AV18Window ;
      private GeneXus.Utils.SdtMessages_Message AV7Message ;
      private SdtRevisaoLog AV8RevisaoLog ;
   }

   public class revisaowc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class revisaowc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH007N2;
        prmH007N2 = new Object[] {
        new ParDef("@AV6DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("H007N2", "SELECT [DocumentoId], [RevisaoLogId], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [RevisaoLogObservacao] FROM [RevisaoLog] WHERE [DocumentoId] = @AV6DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007N2,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              return;
     }
  }

}

}
