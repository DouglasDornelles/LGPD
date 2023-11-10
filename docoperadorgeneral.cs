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
   public class docoperadorgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public docoperadorgeneral( )
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

      public docoperadorgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocOperadorId )
      {
         this.A86DocOperadorId = aP0_DocOperadorId;
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
         chkavDocoperadorchecky = new GXCheckbox();
         chkavDocoperadorcheckn = new GXCheckbox();
         dynOperadorId = new GXCombobox();
         chkDocOperadorColeta = new GXCheckbox();
         chkDocOperadorRetencao = new GXCheckbox();
         chkDocOperadorCompartilhamento = new GXCheckbox();
         chkDocOperadorEliminacao = new GXCheckbox();
         chkDocOperadorProcessamento = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "DocOperadorId");
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
                  A86DocOperadorId = (int)(NumberUtil.Val( GetPar( "DocOperadorId"), "."));
                  AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A86DocOperadorId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"OPERADORID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAOPERADORID6Q2( ) ;
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
                  gxfirstwebparm = GetFirstPar( "DocOperadorId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "DocOperadorId");
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
            PA6Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV27Pgmname = "DocOperadorGeneral";
               context.Gx_err = 0;
               chkavDocoperadorchecky.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadorchecky_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorchecky.Enabled), 5, 0), true);
               chkavDocoperadorcheckn.Enabled = 0;
               AssignProp(sPrefix, false, chkavDocoperadorcheckn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcheckn.Enabled), 5, 0), true);
               GXAOPERADORID_html6Q2( ) ;
               WS6Q2( ) ;
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
            context.SendWebValue( "Doc Operador General") ;
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
            GXEncryptionTmp = "docoperadorgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A86DocOperadorId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docoperadorgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA86DocOperadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA86DocOperadorId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm6Q2( )
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
         return "DocOperadorGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Operador General" ;
      }

      protected void WB6Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "docoperadorgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_6Q2( true) ;
         }
         else
         {
            wb_table1_15_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynOperadorId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynOperadorId_Internalname, "NOME", "col-sm-1 AttributeStepBulletLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-11 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynOperadorId, dynOperadorId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A42OperadorId), 8, 0)), 1, dynOperadorId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynOperadorId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeStepBullet", "", "", "", "", true, 0, "HLP_DocOperadorGeneral.htm");
            dynOperadorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A42OperadorId), 8, 0));
            AssignProp(sPrefix, false, dynOperadorId_Internalname, "Values", (string)(dynOperadorId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tabledadoscheck_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            wb_table2_49_6Q2( true) ;
         }
         else
         {
            wb_table2_49_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:2;", "div");
            wb_table3_57_6Q2( true) ;
         }
         else
         {
            wb_table3_57_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table3_57_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:3;", "div");
            wb_table4_65_6Q2( true) ;
         }
         else
         {
            wb_table4_65_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table4_65_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:4;", "div");
            wb_table5_73_6Q2( true) ;
         }
         else
         {
            wb_table5_73_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table5_73_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:5;", "div");
            wb_table6_81_6Q2( true) ;
         }
         else
         {
            wb_table6_81_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table6_81_6Q2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modifica", bttBtnupdate_Jsonclick, 5, "Modifica", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocOperadorGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocOperadorGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtDocOperadorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocOperadorId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocOperadorId_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocOperadorGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocOperadorGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtDocOperadorDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDocOperadorDataInclusao_Internalname, context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"), context.localUtil.Format( A92DocOperadorDataInclusao, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocOperadorDataInclusao_Jsonclick, 0, "Attribute", "", "", "", "", edtDocOperadorDataInclusao_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocOperadorGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDocOperadorDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtDocOperadorDataInclusao_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6Q2( )
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
               Form.Meta.addItem("description", "Doc Operador General", 0) ;
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
               STRUP6Q0( ) ;
            }
         }
      }

      protected void WS6Q2( )
      {
         START6Q2( ) ;
         EVT6Q2( ) ;
      }

      protected void EVT6Q2( )
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
                                 STRUP6Q0( ) ;
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
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E116Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E126Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E136Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E146Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
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
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavDocoperadorchecky_Internalname;
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

      protected void WE6Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6Q2( ) ;
            }
         }
      }

      protected void PA6Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docoperadorgeneral.aspx")), "docoperadorgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docoperadorgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "DocOperadorId");
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
               GX_FocusControl = chkavDocoperadorchecky_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLAOPERADORID6Q2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAOPERADORID_data6Q2( ) ;
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

      protected void GXAOPERADORID_html6Q2( )
      {
         int gxdynajaxvalue;
         GXDLAOPERADORID_data6Q2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynOperadorId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynOperadorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAOPERADORID_data6Q2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("SELECIONE...");
         /* Using cursor H006Q2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006Q2_A42OperadorId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H006Q2_A43OperadorNome[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXAOPERADORID_html6Q2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV22DocOperadorCheckY = StringUtil.StrToBool( StringUtil.BoolToStr( AV22DocOperadorCheckY));
         AssignAttri(sPrefix, false, "AV22DocOperadorCheckY", AV22DocOperadorCheckY);
         AV23DocOperadorCheckN = StringUtil.StrToBool( StringUtil.BoolToStr( AV23DocOperadorCheckN));
         AssignAttri(sPrefix, false, "AV23DocOperadorCheckN", AV23DocOperadorCheckN);
         if ( dynOperadorId.ItemCount > 0 )
         {
            A42OperadorId = (int)(NumberUtil.Val( dynOperadorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A42OperadorId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynOperadorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A42OperadorId), 8, 0));
            AssignProp(sPrefix, false, dynOperadorId_Internalname, "Values", dynOperadorId.ToJavascriptSource(), true);
         }
         A87DocOperadorColeta = StringUtil.StrToBool( StringUtil.BoolToStr( A87DocOperadorColeta));
         AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
         A88DocOperadorRetencao = StringUtil.StrToBool( StringUtil.BoolToStr( A88DocOperadorRetencao));
         AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
         A89DocOperadorCompartilhamento = StringUtil.StrToBool( StringUtil.BoolToStr( A89DocOperadorCompartilhamento));
         AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
         A90DocOperadorEliminacao = StringUtil.StrToBool( StringUtil.BoolToStr( A90DocOperadorEliminacao));
         AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
         A91DocOperadorProcessamento = StringUtil.StrToBool( StringUtil.BoolToStr( A91DocOperadorProcessamento));
         AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV27Pgmname = "DocOperadorGeneral";
         context.Gx_err = 0;
         chkavDocoperadorchecky.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorchecky_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorchecky.Enabled), 5, 0), true);
         chkavDocoperadorcheckn.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorcheckn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcheckn.Enabled), 5, 0), true);
      }

      protected void RF6Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H006Q3 */
            pr_default.execute(1, new Object[] {A86DocOperadorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A92DocOperadorDataInclusao = H006Q3_A92DocOperadorDataInclusao[0];
               AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
               A75DocumentoId = H006Q3_A75DocumentoId[0];
               AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               A91DocOperadorProcessamento = H006Q3_A91DocOperadorProcessamento[0];
               AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
               A90DocOperadorEliminacao = H006Q3_A90DocOperadorEliminacao[0];
               AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
               A89DocOperadorCompartilhamento = H006Q3_A89DocOperadorCompartilhamento[0];
               AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
               A88DocOperadorRetencao = H006Q3_A88DocOperadorRetencao[0];
               AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
               A87DocOperadorColeta = H006Q3_A87DocOperadorColeta[0];
               AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
               A42OperadorId = H006Q3_A42OperadorId[0];
               AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
               GXAOPERADORID_html6Q2( ) ;
               /* Execute user event: Load */
               E126Q2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB6Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6Q2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV27Pgmname = "DocOperadorGeneral";
         context.Gx_err = 0;
         chkavDocoperadorchecky.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorchecky_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorchecky.Enabled), 5, 0), true);
         chkavDocoperadorcheckn.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorcheckn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcheckn.Enabled), 5, 0), true);
         GXAOPERADORID_html6Q2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA86DocOperadorId"), ",", "."));
            /* Read variables values. */
            AV22DocOperadorCheckY = StringUtil.StrToBool( cgiGet( chkavDocoperadorchecky_Internalname));
            AssignAttri(sPrefix, false, "AV22DocOperadorCheckY", AV22DocOperadorCheckY);
            AV23DocOperadorCheckN = StringUtil.StrToBool( cgiGet( chkavDocoperadorcheckn_Internalname));
            AssignAttri(sPrefix, false, "AV23DocOperadorCheckN", AV23DocOperadorCheckN);
            dynOperadorId.CurrentValue = cgiGet( dynOperadorId_Internalname);
            A42OperadorId = (int)(NumberUtil.Val( cgiGet( dynOperadorId_Internalname), "."));
            AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
            A87DocOperadorColeta = StringUtil.StrToBool( cgiGet( chkDocOperadorColeta_Internalname));
            AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
            A88DocOperadorRetencao = StringUtil.StrToBool( cgiGet( chkDocOperadorRetencao_Internalname));
            AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
            A89DocOperadorCompartilhamento = StringUtil.StrToBool( cgiGet( chkDocOperadorCompartilhamento_Internalname));
            AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
            A90DocOperadorEliminacao = StringUtil.StrToBool( cgiGet( chkDocOperadorEliminacao_Internalname));
            AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
            A91DocOperadorProcessamento = StringUtil.StrToBool( cgiGet( chkDocOperadorProcessamento_Internalname));
            AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
            A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            A92DocOperadorDataInclusao = context.localUtil.CToD( cgiGet( edtDocOperadorDataInclusao_Internalname), 2);
            AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXAOPERADORID_html6Q2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E116Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E116Q2( )
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

      protected void E126Q2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtDocOperadorId_Visible = 0;
         AssignProp(sPrefix, false, edtDocOperadorId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocOperadorId_Visible), 5, 0), true);
         edtDocumentoId_Visible = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), true);
         edtDocOperadorDataInclusao_Visible = 0;
         AssignProp(sPrefix, false, edtDocOperadorDataInclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocOperadorDataInclusao_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperador_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docoperador_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E136Q2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docoperador.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A86DocOperadorId,8,0));
            CallWebObject(formatLink("docoperador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E146Q2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docoperador.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A86DocOperadorId,8,0));
            CallWebObject(formatLink("docoperador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Callerobject = AV27Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "DocOperador";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table6_81_6Q2( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkDocOperadorProcessamento_Internalname, "Processamento?", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorProcessamento_Internalname, StringUtil.BoolToStr( A91DocOperadorProcessamento), "", "Processamento?", 1, chkDocOperadorProcessamento.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorprocessamento_righttext_Internalname, "PROCESSAMENTO", "", "", lblDocoperadorprocessamento_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_81_6Q2e( true) ;
         }
         else
         {
            wb_table6_81_6Q2e( false) ;
         }
      }

      protected void wb_table5_73_6Q2( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkDocOperadorEliminacao_Internalname, "Eliminição?", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorEliminacao_Internalname, StringUtil.BoolToStr( A90DocOperadorEliminacao), "", "Eliminição?", 1, chkDocOperadorEliminacao.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadoreliminacao_righttext_Internalname, "ELIMINAÇÃO", "", "", lblDocoperadoreliminacao_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_73_6Q2e( true) ;
         }
         else
         {
            wb_table5_73_6Q2e( false) ;
         }
      }

      protected void wb_table4_65_6Q2( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkDocOperadorCompartilhamento_Internalname, "Compartilhamento?", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorCompartilhamento_Internalname, StringUtil.BoolToStr( A89DocOperadorCompartilhamento), "", "Compartilhamento?", 1, chkDocOperadorCompartilhamento.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcompartilhamento_righttext_Internalname, "COMPARTILHAMENTO", "", "", lblDocoperadorcompartilhamento_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_65_6Q2e( true) ;
         }
         else
         {
            wb_table4_65_6Q2e( false) ;
         }
      }

      protected void wb_table3_57_6Q2( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkDocOperadorRetencao_Internalname, "Retenção?", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorRetencao_Internalname, StringUtil.BoolToStr( A88DocOperadorRetencao), "", "Retenção?", 1, chkDocOperadorRetencao.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorretencao_righttext_Internalname, "RETENÇÃO", "", "", lblDocoperadorretencao_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_57_6Q2e( true) ;
         }
         else
         {
            wb_table3_57_6Q2e( false) ;
         }
      }

      protected void wb_table2_49_6Q2( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkDocOperadorColeta_Internalname, "Coleta?", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorColeta_Internalname, StringUtil.BoolToStr( A87DocOperadorColeta), "", "Coleta?", 1, chkDocOperadorColeta.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcoleta_righttext_Internalname, "COLETA", "", "", lblDocoperadorcoleta_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_6Q2e( true) ;
         }
         else
         {
            wb_table2_49_6Q2e( false) ;
         }
      }

      protected void wb_table1_15_6Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_operadortextblock_Internalname, "OPERADOR", "", "", lblTransactiondetail_operadortextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableoperadoroptions_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;", "div");
            wb_table7_22_6Q2( true) ;
         }
         else
         {
            wb_table7_22_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table7_22_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;", "div");
            wb_table8_30_6Q2( true) ;
         }
         else
         {
            wb_table8_30_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table8_30_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_6Q2e( true) ;
         }
         else
         {
            wb_table1_15_6Q2e( false) ;
         }
      }

      protected void wb_table8_30_6Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadorcheckn_Internalname, tblTablemergeddocoperadorcheckn_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadorcheckn_Internalname, "Doc Operador Check N", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorcheckn_Internalname, StringUtil.BoolToStr( AV23DocOperadorCheckN), "", "Doc Operador Check N", 1, chkavDocoperadorcheckn.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(34, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,34);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorcheckn_righttext_Internalname, "NÃO", "", "", lblDocoperadorcheckn_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_30_6Q2e( true) ;
         }
         else
         {
            wb_table8_30_6Q2e( false) ;
         }
      }

      protected void wb_table7_22_6Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddocoperadorchecky_Internalname, tblTablemergeddocoperadorchecky_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDocoperadorchecky_Internalname, "Doc Operador Check Y", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorchecky_Internalname, StringUtil.BoolToStr( AV22DocOperadorCheckY), "", "Doc Operador Check Y", 1, chkavDocoperadorchecky.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(26, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,26);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDocoperadorchecky_righttext_Internalname, "SIM", "", "", lblDocoperadorchecky_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperadorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_22_6Q2e( true) ;
         }
         else
         {
            wb_table7_22_6Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A86DocOperadorId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
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
         PA6Q2( ) ;
         WS6Q2( ) ;
         WE6Q2( ) ;
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
         sCtrlA86DocOperadorId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "docoperadorgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A86DocOperadorId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         }
         wcpOA86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA86DocOperadorId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A86DocOperadorId != wcpOA86DocOperadorId ) ) )
         {
            setjustcreated();
         }
         wcpOA86DocOperadorId = A86DocOperadorId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA86DocOperadorId = cgiGet( sPrefix+"A86DocOperadorId_CTRL");
         if ( StringUtil.Len( sCtrlA86DocOperadorId) > 0 )
         {
            A86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sCtrlA86DocOperadorId), ",", "."));
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         }
         else
         {
            A86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A86DocOperadorId_PARM"), ",", "."));
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
         PA6Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6Q2( ) ;
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
         WS6Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A86DocOperadorId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA86DocOperadorId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A86DocOperadorId_CTRL", StringUtil.RTrim( sCtrlA86DocOperadorId));
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
         WE6Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910445254", true, true);
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
         context.AddJavascriptSource("docoperadorgeneral.js", "?202311910445254", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavDocoperadorchecky.Name = "vDOCOPERADORCHECKY";
         chkavDocoperadorchecky.WebTags = "";
         chkavDocoperadorchecky.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadorchecky_Internalname, "TitleCaption", chkavDocoperadorchecky.Caption, true);
         chkavDocoperadorchecky.CheckedValue = "false";
         chkavDocoperadorcheckn.Name = "vDOCOPERADORCHECKN";
         chkavDocoperadorcheckn.WebTags = "";
         chkavDocoperadorcheckn.Caption = "";
         AssignProp(sPrefix, false, chkavDocoperadorcheckn_Internalname, "TitleCaption", chkavDocoperadorcheckn.Caption, true);
         chkavDocoperadorcheckn.CheckedValue = "false";
         dynOperadorId.Name = "OPERADORID";
         dynOperadorId.WebTags = "";
         chkDocOperadorColeta.Name = "DOCOPERADORCOLETA";
         chkDocOperadorColeta.WebTags = "";
         chkDocOperadorColeta.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorColeta_Internalname, "TitleCaption", chkDocOperadorColeta.Caption, true);
         chkDocOperadorColeta.CheckedValue = "false";
         chkDocOperadorRetencao.Name = "DOCOPERADORRETENCAO";
         chkDocOperadorRetencao.WebTags = "";
         chkDocOperadorRetencao.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorRetencao_Internalname, "TitleCaption", chkDocOperadorRetencao.Caption, true);
         chkDocOperadorRetencao.CheckedValue = "false";
         chkDocOperadorCompartilhamento.Name = "DOCOPERADORCOMPARTILHAMENTO";
         chkDocOperadorCompartilhamento.WebTags = "";
         chkDocOperadorCompartilhamento.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorCompartilhamento_Internalname, "TitleCaption", chkDocOperadorCompartilhamento.Caption, true);
         chkDocOperadorCompartilhamento.CheckedValue = "false";
         chkDocOperadorEliminacao.Name = "DOCOPERADORELIMINACAO";
         chkDocOperadorEliminacao.WebTags = "";
         chkDocOperadorEliminacao.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorEliminacao_Internalname, "TitleCaption", chkDocOperadorEliminacao.Caption, true);
         chkDocOperadorEliminacao.CheckedValue = "false";
         chkDocOperadorProcessamento.Name = "DOCOPERADORPROCESSAMENTO";
         chkDocOperadorProcessamento.WebTags = "";
         chkDocOperadorProcessamento.Caption = "";
         AssignProp(sPrefix, false, chkDocOperadorProcessamento_Internalname, "TitleCaption", chkDocOperadorProcessamento.Caption, true);
         chkDocOperadorProcessamento.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTransactiondetail_operadortextblock_Internalname = sPrefix+"TRANSACTIONDETAIL_OPERADORTEXTBLOCK";
         chkavDocoperadorchecky_Internalname = sPrefix+"vDOCOPERADORCHECKY";
         lblDocoperadorchecky_righttext_Internalname = sPrefix+"DOCOPERADORCHECKY_RIGHTTEXT";
         tblTablemergeddocoperadorchecky_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCHECKY";
         chkavDocoperadorcheckn_Internalname = sPrefix+"vDOCOPERADORCHECKN";
         lblDocoperadorcheckn_righttext_Internalname = sPrefix+"DOCOPERADORCHECKN_RIGHTTEXT";
         tblTablemergeddocoperadorcheckn_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCHECKN";
         divTransactiondetail_tableoperadoroptions_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEOPERADOROPTIONS";
         tblUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         dynOperadorId_Internalname = sPrefix+"OPERADORID";
         chkDocOperadorColeta_Internalname = sPrefix+"DOCOPERADORCOLETA";
         lblDocoperadorcoleta_righttext_Internalname = sPrefix+"DOCOPERADORCOLETA_RIGHTTEXT";
         tblTablemergeddocoperadorcoleta_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCOLETA";
         chkDocOperadorRetencao_Internalname = sPrefix+"DOCOPERADORRETENCAO";
         lblDocoperadorretencao_righttext_Internalname = sPrefix+"DOCOPERADORRETENCAO_RIGHTTEXT";
         tblTablemergeddocoperadorretencao_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORRETENCAO";
         chkDocOperadorCompartilhamento_Internalname = sPrefix+"DOCOPERADORCOMPARTILHAMENTO";
         lblDocoperadorcompartilhamento_righttext_Internalname = sPrefix+"DOCOPERADORCOMPARTILHAMENTO_RIGHTTEXT";
         tblTablemergeddocoperadorcompartilhamento_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCOMPARTILHAMENTO";
         chkDocOperadorEliminacao_Internalname = sPrefix+"DOCOPERADORELIMINACAO";
         lblDocoperadoreliminacao_righttext_Internalname = sPrefix+"DOCOPERADORELIMINACAO_RIGHTTEXT";
         tblTablemergeddocoperadoreliminacao_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORELIMINACAO";
         chkDocOperadorProcessamento_Internalname = sPrefix+"DOCOPERADORPROCESSAMENTO";
         lblDocoperadorprocessamento_righttext_Internalname = sPrefix+"DOCOPERADORPROCESSAMENTO_RIGHTTEXT";
         tblTablemergeddocoperadorprocessamento_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORPROCESSAMENTO";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTransactiondetail_tabledadoscheck_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEDADOSCHECK";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTransactiondetail_tablecontent_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLECONTENT";
         divTransactiondetail_tablemain_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEMAIN";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtDocOperadorId_Internalname = sPrefix+"DOCOPERADORID";
         edtDocumentoId_Internalname = sPrefix+"DOCUMENTOID";
         edtDocOperadorDataInclusao_Internalname = sPrefix+"DOCOPERADORDATAINCLUSAO";
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
         chkDocOperadorProcessamento.Caption = "Processamento?";
         chkDocOperadorEliminacao.Caption = "Eliminição?";
         chkDocOperadorCompartilhamento.Caption = "Compartilhamento?";
         chkDocOperadorRetencao.Caption = "Retenção?";
         chkDocOperadorColeta.Caption = "Coleta?";
         chkavDocoperadorcheckn.Caption = "Doc Operador Check N";
         chkavDocoperadorchecky.Caption = "Doc Operador Check Y";
         chkavDocoperadorchecky.Enabled = 1;
         chkavDocoperadorcheckn.Enabled = 1;
         chkDocOperadorColeta.Enabled = 0;
         chkDocOperadorRetencao.Enabled = 0;
         chkDocOperadorCompartilhamento.Enabled = 0;
         chkDocOperadorEliminacao.Enabled = 0;
         chkDocOperadorProcessamento.Enabled = 0;
         edtDocOperadorDataInclusao_Jsonclick = "";
         edtDocOperadorDataInclusao_Visible = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Visible = 1;
         edtDocOperadorId_Jsonclick = "";
         edtDocOperadorId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         dynOperadorId_Jsonclick = "";
         dynOperadorId.Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9'},{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV22DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV23DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E136Q2',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E146Q2',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A86DocOperadorId',fld:'DOCOPERADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_DOCOPERADORID","{handler:'Valid_Docoperadorid',iparms:[]");
         setEventMetadata("VALID_DOCOPERADORID",",oparms:[]}");
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
         AV27Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A92DocOperadorDataInclusao = DateTime.MinValue;
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
         scmdbuf = "";
         H006Q2_A42OperadorId = new int[1] ;
         H006Q2_A43OperadorNome = new string[] {""} ;
         H006Q2_A44OperadorAtivo = new bool[] {false} ;
         H006Q3_A86DocOperadorId = new int[1] ;
         H006Q3_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H006Q3_A75DocumentoId = new int[1] ;
         H006Q3_A91DocOperadorProcessamento = new bool[] {false} ;
         H006Q3_A90DocOperadorEliminacao = new bool[] {false} ;
         H006Q3_A89DocOperadorCompartilhamento = new bool[] {false} ;
         H006Q3_A88DocOperadorRetencao = new bool[] {false} ;
         H006Q3_A87DocOperadorColeta = new bool[] {false} ;
         H006Q3_A42OperadorId = new int[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         sStyleString = "";
         lblDocoperadorprocessamento_righttext_Jsonclick = "";
         lblDocoperadoreliminacao_righttext_Jsonclick = "";
         lblDocoperadorcompartilhamento_righttext_Jsonclick = "";
         lblDocoperadorretencao_righttext_Jsonclick = "";
         lblDocoperadorcoleta_righttext_Jsonclick = "";
         lblTransactiondetail_operadortextblock_Jsonclick = "";
         lblDocoperadorcheckn_righttext_Jsonclick = "";
         lblDocoperadorchecky_righttext_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA86DocOperadorId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperadorgeneral__default(),
            new Object[][] {
                new Object[] {
               H006Q2_A42OperadorId, H006Q2_A43OperadorNome, H006Q2_A44OperadorAtivo
               }
               , new Object[] {
               H006Q3_A86DocOperadorId, H006Q3_A92DocOperadorDataInclusao, H006Q3_A75DocumentoId, H006Q3_A91DocOperadorProcessamento, H006Q3_A90DocOperadorEliminacao, H006Q3_A89DocOperadorCompartilhamento, H006Q3_A88DocOperadorRetencao, H006Q3_A87DocOperadorColeta, H006Q3_A42OperadorId
               }
            }
         );
         AV27Pgmname = "DocOperadorGeneral";
         /* GeneXus formulas. */
         AV27Pgmname = "DocOperadorGeneral";
         context.Gx_err = 0;
         chkavDocoperadorchecky.Enabled = 0;
         chkavDocoperadorcheckn.Enabled = 0;
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
      private int A86DocOperadorId ;
      private int wcpOA86DocOperadorId ;
      private int A42OperadorId ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtDocOperadorId_Visible ;
      private int A75DocumentoId ;
      private int edtDocumentoId_Visible ;
      private int edtDocOperadorDataInclusao_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV27Pgmname ;
      private string chkavDocoperadorchecky_Internalname ;
      private string chkavDocoperadorcheckn_Internalname ;
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
      private string dynOperadorId_Internalname ;
      private string dynOperadorId_Jsonclick ;
      private string divTransactiondetail_tabledadoscheck_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDocOperadorId_Internalname ;
      private string edtDocOperadorId_Jsonclick ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoId_Jsonclick ;
      private string edtDocOperadorDataInclusao_Internalname ;
      private string edtDocOperadorDataInclusao_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string chkDocOperadorColeta_Internalname ;
      private string chkDocOperadorRetencao_Internalname ;
      private string chkDocOperadorCompartilhamento_Internalname ;
      private string chkDocOperadorEliminacao_Internalname ;
      private string chkDocOperadorProcessamento_Internalname ;
      private string sStyleString ;
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
      private string tblUnnamedtable1_Internalname ;
      private string lblTransactiondetail_operadortextblock_Internalname ;
      private string lblTransactiondetail_operadortextblock_Jsonclick ;
      private string divTransactiondetail_tableoperadoroptions_Internalname ;
      private string tblTablemergeddocoperadorcheckn_Internalname ;
      private string lblDocoperadorcheckn_righttext_Internalname ;
      private string lblDocoperadorcheckn_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorchecky_Internalname ;
      private string lblDocoperadorchecky_righttext_Internalname ;
      private string lblDocoperadorchecky_righttext_Jsonclick ;
      private string sCtrlA86DocOperadorId ;
      private DateTime A92DocOperadorDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV22DocOperadorCheckY ;
      private bool AV23DocOperadorCheckN ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavDocoperadorchecky ;
      private GXCheckbox chkavDocoperadorcheckn ;
      private GXCombobox dynOperadorId ;
      private GXCheckbox chkDocOperadorColeta ;
      private GXCheckbox chkDocOperadorRetencao ;
      private GXCheckbox chkDocOperadorCompartilhamento ;
      private GXCheckbox chkDocOperadorEliminacao ;
      private GXCheckbox chkDocOperadorProcessamento ;
      private IDataStoreProvider pr_default ;
      private int[] H006Q2_A42OperadorId ;
      private string[] H006Q2_A43OperadorNome ;
      private bool[] H006Q2_A44OperadorAtivo ;
      private int[] H006Q3_A86DocOperadorId ;
      private DateTime[] H006Q3_A92DocOperadorDataInclusao ;
      private int[] H006Q3_A75DocumentoId ;
      private bool[] H006Q3_A91DocOperadorProcessamento ;
      private bool[] H006Q3_A90DocOperadorEliminacao ;
      private bool[] H006Q3_A89DocOperadorCompartilhamento ;
      private bool[] H006Q3_A88DocOperadorRetencao ;
      private bool[] H006Q3_A87DocOperadorColeta ;
      private int[] H006Q3_A42OperadorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class docoperadorgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH006Q2;
          prmH006Q2 = new Object[] {
          };
          Object[] prmH006Q3;
          prmH006Q3 = new Object[] {
          new ParDef("@DocOperadorId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006Q2", "SELECT [OperadorId], [OperadorNome], [OperadorAtivo] FROM [Operador] WHERE [OperadorAtivo] = 1 ORDER BY [OperadorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q3", "SELECT [DocOperadorId], [DocOperadorDataInclusao], [DocumentoId], [DocOperadorProcessamento], [DocOperadorEliminacao], [DocOperadorCompartilhamento], [DocOperadorRetencao], [DocOperadorColeta], [OperadorId] FROM [DocOperador] WHERE [DocOperadorId] = @DocOperadorId ORDER BY [DocOperadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q3,1, GxCacheFrequency.OFF ,true,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
