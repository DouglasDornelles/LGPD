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
   public class docdicionariogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public docdicionariogeneral( )
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

      public docdicionariogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocDicionarioId )
      {
         this.A98DocDicionarioId = aP0_DocDicionarioId;
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
         dynInformacaoId = new GXCombobox();
         chkDocDicionarioPodeEliminar = new GXCheckbox();
         chkDocDicionarioSensivel = new GXCheckbox();
         chkDocDicionarioTransfInter = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "DocDicionarioId");
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
                  A98DocDicionarioId = (int)(NumberUtil.Val( GetPar( "DocDicionarioId"), "."));
                  AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A98DocDicionarioId});
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
                  gxfirstwebparm = GetFirstPar( "DocDicionarioId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "DocDicionarioId");
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
            PA352( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "DocDicionarioGeneral";
               context.Gx_err = 0;
               WS352( ) ;
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
            context.SendWebValue( "Doc Dicionario General") ;
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
            GXEncryptionTmp = "docdicionariogeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A98DocDicionarioId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docdicionariogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA98DocDicionarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA98DocDicionarioId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm352( )
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
         return "DocDicionarioGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Dicionario General" ;
      }

      protected void WB350( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "docdicionariogeneral.aspx");
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
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynInformacaoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynInformacaoId_Internalname, "Informacao", "col-sm-2 AttributeStepBulletLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynInformacaoId, dynInformacaoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0)), 1, dynInformacaoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynInformacaoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeStepBullet", "", "", "", "", true, 0, "HLP_DocDicionarioGeneral.htm");
            dynInformacaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0));
            AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Values", (string)(dynInformacaoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocDicionarioPodeEliminar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkDocDicionarioPodeEliminar_Internalname, "Eliminar?", "col-sm-2 AttributeStepBulletLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "AttributeStepBullet";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocDicionarioPodeEliminar_Internalname, StringUtil.BoolToStr( A100DocDicionarioPodeEliminar), "", "Eliminar?", 1, chkDocDicionarioPodeEliminar.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocDicionarioSensivel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkDocDicionarioSensivel_Internalname, "Sensível?", "col-sm-2 AttributeStepBulletLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-10 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "AttributeStepBullet";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocDicionarioSensivel_Internalname, StringUtil.BoolToStr( A99DocDicionarioSensivel), "", "Sensível?", 1, chkDocDicionarioSensivel.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkDocDicionarioTransfInter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkDocDicionarioTransfInter_Internalname, "Internacional", "col-sm-3 AttributeStepBulletLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "AttributeStepBullet";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkDocDicionarioTransfInter_Internalname, StringUtil.BoolToStr( A101DocDicionarioTransfInter), "", "Internacional", 1, chkDocDicionarioTransfInter.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocDicionarioFinalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocDicionarioFinalidade_Internalname, "Finalidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDocDicionarioFinalidade_Internalname, A102DocDicionarioFinalidade, "", "", 0, 1, edtDocDicionarioFinalidade_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DocDicionarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocDicionarioDataInclusao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDocDicionarioDataInclusao_Internalname, "de Inclusão", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtDocDicionarioDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDocDicionarioDataInclusao_Internalname, context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"), context.localUtil.Format( A103DocDicionarioDataInclusao, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDicionarioDataInclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocDicionarioDataInclusao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocDicionarioGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDocDicionarioDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocDicionarioDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocDicionarioGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisNome_Internalname, "Pais", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisNome_Internalname, A5PaisNome, StringUtil.RTrim( context.localUtil.Format( A5PaisNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtPaisNome_Link, "", "", "", edtPaisNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_DocDicionarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHipoteseTratamentoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHipoteseTratamentoNome_Internalname, "Hipotese Tratamento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtHipoteseTratamentoNome_Internalname, A73HipoteseTratamentoNome, StringUtil.RTrim( context.localUtil.Format( A73HipoteseTratamentoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtHipoteseTratamentoNome_Link, "", "", "", edtHipoteseTratamentoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHipoteseTratamentoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_DocDicionarioGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modifica", bttBtnupdate_Jsonclick, 5, "Modifica", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocDicionarioGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtDocDicionarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A98DocDicionarioId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDicionarioId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocDicionarioId_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocDicionarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START352( )
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
               Form.Meta.addItem("description", "Doc Dicionario General", 0) ;
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
               STRUP350( ) ;
            }
         }
      }

      protected void WS352( )
      {
         START352( ) ;
         EVT352( ) ;
      }

      protected void EVT352( )
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
                                 STRUP350( ) ;
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
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
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
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE352( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm352( ) ;
            }
         }
      }

      protected void PA352( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docdicionariogeneral.aspx")), "docdicionariogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docdicionariogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "DocDicionarioId");
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLAINFORMACAOID351( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINFORMACAOID_data351( ) ;
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

      protected void GXAINFORMACAOID_html351( )
      {
         int gxdynajaxvalue;
         GXDLAINFORMACAOID_data351( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynInformacaoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynInformacaoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 8, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynInformacaoId.ItemCount > 0 )
         {
            A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
         }
      }

      protected void GXDLAINFORMACAOID_data351( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00352 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00352_A24AreaResponsavelId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00352_A25AreaResponsavelNome[0]);
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
            dynInformacaoId.Name = "INFORMACAOID";
            dynInformacaoId.WebTags = "";
            dynInformacaoId.removeAllItems();
            /* Using cursor H00353 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynInformacaoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00353_A24AreaResponsavelId[0]), 8, 0)), H00353_A25AreaResponsavelNome[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynInformacaoId.ItemCount > 0 )
            {
               A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0))), "."));
               AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynInformacaoId.ItemCount > 0 )
         {
            A69InformacaoId = (int)(NumberUtil.Val( dynInformacaoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0))), "."));
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInformacaoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A69InformacaoId), 8, 0));
            AssignProp(sPrefix, false, dynInformacaoId_Internalname, "Values", dynInformacaoId.ToJavascriptSource(), true);
         }
         A100DocDicionarioPodeEliminar = StringUtil.StrToBool( StringUtil.BoolToStr( A100DocDicionarioPodeEliminar));
         AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
         A99DocDicionarioSensivel = StringUtil.StrToBool( StringUtil.BoolToStr( A99DocDicionarioSensivel));
         AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
         A101DocDicionarioTransfInter = StringUtil.StrToBool( StringUtil.BoolToStr( A101DocDicionarioTransfInter));
         AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF352( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "DocDicionarioGeneral";
         context.Gx_err = 0;
      }

      protected void RF352( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00354 */
            pr_default.execute(2, new Object[] {A98DocDicionarioId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A4PaisId = H00354_A4PaisId[0];
               n4PaisId = H00354_n4PaisId[0];
               A72HipoteseTratamentoId = H00354_A72HipoteseTratamentoId[0];
               A73HipoteseTratamentoNome = H00354_A73HipoteseTratamentoNome[0];
               AssignAttri(sPrefix, false, "A73HipoteseTratamentoNome", A73HipoteseTratamentoNome);
               A5PaisNome = H00354_A5PaisNome[0];
               AssignAttri(sPrefix, false, "A5PaisNome", A5PaisNome);
               A103DocDicionarioDataInclusao = H00354_A103DocDicionarioDataInclusao[0];
               AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
               A102DocDicionarioFinalidade = H00354_A102DocDicionarioFinalidade[0];
               AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
               A101DocDicionarioTransfInter = H00354_A101DocDicionarioTransfInter[0];
               AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
               A99DocDicionarioSensivel = H00354_A99DocDicionarioSensivel[0];
               AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
               A100DocDicionarioPodeEliminar = H00354_A100DocDicionarioPodeEliminar[0];
               AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
               A69InformacaoId = H00354_A69InformacaoId[0];
               AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
               A5PaisNome = H00354_A5PaisNome[0];
               AssignAttri(sPrefix, false, "A5PaisNome", A5PaisNome);
               A73HipoteseTratamentoNome = H00354_A73HipoteseTratamentoNome[0];
               AssignAttri(sPrefix, false, "A73HipoteseTratamentoNome", A73HipoteseTratamentoNome);
               /* Execute user event: Load */
               E12352 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            WB350( ) ;
         }
      }

      protected void send_integrity_lvl_hashes352( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "DocDicionarioGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP350( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11352 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA98DocDicionarioId"), ",", "."));
            /* Read variables values. */
            dynInformacaoId.CurrentValue = cgiGet( dynInformacaoId_Internalname);
            A69InformacaoId = (int)(NumberUtil.Val( cgiGet( dynInformacaoId_Internalname), "."));
            AssignAttri(sPrefix, false, "A69InformacaoId", StringUtil.LTrimStr( (decimal)(A69InformacaoId), 8, 0));
            A100DocDicionarioPodeEliminar = StringUtil.StrToBool( cgiGet( chkDocDicionarioPodeEliminar_Internalname));
            AssignAttri(sPrefix, false, "A100DocDicionarioPodeEliminar", A100DocDicionarioPodeEliminar);
            A99DocDicionarioSensivel = StringUtil.StrToBool( cgiGet( chkDocDicionarioSensivel_Internalname));
            AssignAttri(sPrefix, false, "A99DocDicionarioSensivel", A99DocDicionarioSensivel);
            A101DocDicionarioTransfInter = StringUtil.StrToBool( cgiGet( chkDocDicionarioTransfInter_Internalname));
            AssignAttri(sPrefix, false, "A101DocDicionarioTransfInter", A101DocDicionarioTransfInter);
            A102DocDicionarioFinalidade = cgiGet( edtDocDicionarioFinalidade_Internalname);
            AssignAttri(sPrefix, false, "A102DocDicionarioFinalidade", A102DocDicionarioFinalidade);
            A103DocDicionarioDataInclusao = context.localUtil.CToD( cgiGet( edtDocDicionarioDataInclusao_Internalname), 2);
            AssignAttri(sPrefix, false, "A103DocDicionarioDataInclusao", context.localUtil.Format(A103DocDicionarioDataInclusao, "99/99/99"));
            A5PaisNome = cgiGet( edtPaisNome_Internalname);
            AssignAttri(sPrefix, false, "A5PaisNome", A5PaisNome);
            A73HipoteseTratamentoNome = cgiGet( edtHipoteseTratamentoNome_Internalname);
            AssignAttri(sPrefix, false, "A73HipoteseTratamentoNome", A73HipoteseTratamentoNome);
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
         E11352 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11352( )
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

      protected void E12352( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV14TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "paisview_Execute", out  GXt_boolean1) ;
         AV14TempBoolean = GXt_boolean1;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "paisview.aspx"+UrlEncode(StringUtil.LTrimStr(A4PaisId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtPaisNome_Link = formatLink("paisview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtPaisNome_Internalname, "Link", edtPaisNome_Link, true);
         }
         GXt_boolean1 = AV14TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "hipotesetratamentoview_Execute", out  GXt_boolean1) ;
         AV14TempBoolean = GXt_boolean1;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "hipotesetratamentoview.aspx"+UrlEncode(StringUtil.LTrimStr(A72HipoteseTratamentoId,8,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtHipoteseTratamentoNome_Link = formatLink("hipotesetratamentoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtHipoteseTratamentoNome_Internalname, "Link", edtHipoteseTratamentoNome_Link, true);
         }
         edtDocDicionarioId_Visible = 0;
         AssignProp(sPrefix, false, edtDocDicionarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocDicionarioId_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docdicionario_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "docdicionario_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13352( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docdicionario.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A98DocDicionarioId,8,0));
            CallWebObject(formatLink("docdicionario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E14352( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docdicionario.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A98DocDicionarioId,8,0));
            CallWebObject(formatLink("docdicionario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "DocDicionario";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A98DocDicionarioId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
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
         PA352( ) ;
         WS352( ) ;
         WE352( ) ;
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
         sCtrlA98DocDicionarioId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA352( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "docdicionariogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA352( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A98DocDicionarioId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         wcpOA98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA98DocDicionarioId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A98DocDicionarioId != wcpOA98DocDicionarioId ) ) )
         {
            setjustcreated();
         }
         wcpOA98DocDicionarioId = A98DocDicionarioId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA98DocDicionarioId = cgiGet( sPrefix+"A98DocDicionarioId_CTRL");
         if ( StringUtil.Len( sCtrlA98DocDicionarioId) > 0 )
         {
            A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sCtrlA98DocDicionarioId), ",", "."));
            AssignAttri(sPrefix, false, "A98DocDicionarioId", StringUtil.LTrimStr( (decimal)(A98DocDicionarioId), 8, 0));
         }
         else
         {
            A98DocDicionarioId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"A98DocDicionarioId_PARM"), ",", "."));
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
         PA352( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS352( ) ;
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
         WS352( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A98DocDicionarioId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98DocDicionarioId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA98DocDicionarioId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A98DocDicionarioId_CTRL", StringUtil.RTrim( sCtrlA98DocDicionarioId));
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
         WE352( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202212151055939", true, true);
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
         context.AddJavascriptSource("docdicionariogeneral.js", "?202212151055939", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynInformacaoId.Name = "INFORMACAOID";
         dynInformacaoId.WebTags = "";
         dynInformacaoId.removeAllItems();
         /* Using cursor H00355 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynInformacaoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00355_A24AreaResponsavelId[0]), 8, 0)), H00355_A25AreaResponsavelNome[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynInformacaoId.ItemCount > 0 )
         {
         }
         chkDocDicionarioPodeEliminar.Name = "DOCDICIONARIOPODEELIMINAR";
         chkDocDicionarioPodeEliminar.WebTags = "";
         chkDocDicionarioPodeEliminar.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioPodeEliminar_Internalname, "TitleCaption", chkDocDicionarioPodeEliminar.Caption, true);
         chkDocDicionarioPodeEliminar.CheckedValue = "false";
         chkDocDicionarioSensivel.Name = "DOCDICIONARIOSENSIVEL";
         chkDocDicionarioSensivel.WebTags = "";
         chkDocDicionarioSensivel.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioSensivel_Internalname, "TitleCaption", chkDocDicionarioSensivel.Caption, true);
         chkDocDicionarioSensivel.CheckedValue = "false";
         chkDocDicionarioTransfInter.Name = "DOCDICIONARIOTRANSFINTER";
         chkDocDicionarioTransfInter.WebTags = "";
         chkDocDicionarioTransfInter.Caption = "";
         AssignProp(sPrefix, false, chkDocDicionarioTransfInter_Internalname, "TitleCaption", chkDocDicionarioTransfInter.Caption, true);
         chkDocDicionarioTransfInter.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynInformacaoId_Internalname = sPrefix+"INFORMACAOID";
         chkDocDicionarioPodeEliminar_Internalname = sPrefix+"DOCDICIONARIOPODEELIMINAR";
         chkDocDicionarioSensivel_Internalname = sPrefix+"DOCDICIONARIOSENSIVEL";
         chkDocDicionarioTransfInter_Internalname = sPrefix+"DOCDICIONARIOTRANSFINTER";
         edtDocDicionarioFinalidade_Internalname = sPrefix+"DOCDICIONARIOFINALIDADE";
         edtDocDicionarioDataInclusao_Internalname = sPrefix+"DOCDICIONARIODATAINCLUSAO";
         edtPaisNome_Internalname = sPrefix+"PAISNOME";
         edtHipoteseTratamentoNome_Internalname = sPrefix+"HIPOTESETRATAMENTONOME";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtDocDicionarioId_Internalname = sPrefix+"DOCDICIONARIOID";
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
         chkDocDicionarioTransfInter.Caption = "Internacional";
         chkDocDicionarioSensivel.Caption = "Sensível?";
         chkDocDicionarioPodeEliminar.Caption = "Eliminar?";
         edtDocDicionarioId_Jsonclick = "";
         edtDocDicionarioId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtHipoteseTratamentoNome_Jsonclick = "";
         edtHipoteseTratamentoNome_Link = "";
         edtHipoteseTratamentoNome_Enabled = 0;
         edtPaisNome_Jsonclick = "";
         edtPaisNome_Link = "";
         edtPaisNome_Enabled = 0;
         edtDocDicionarioDataInclusao_Jsonclick = "";
         edtDocDicionarioDataInclusao_Enabled = 0;
         edtDocDicionarioFinalidade_Enabled = 0;
         chkDocDicionarioTransfInter.Enabled = 0;
         chkDocDicionarioSensivel.Enabled = 0;
         chkDocDicionarioPodeEliminar.Enabled = 0;
         dynInformacaoId_Jsonclick = "";
         dynInformacaoId.Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'},{av:'dynInformacaoId'},{av:'A69InformacaoId',fld:'INFORMACAOID',pic:'ZZZZZZZ9'},{av:'A100DocDicionarioPodeEliminar',fld:'DOCDICIONARIOPODEELIMINAR',pic:''},{av:'A99DocDicionarioSensivel',fld:'DOCDICIONARIOSENSIVEL',pic:''},{av:'A101DocDicionarioTransfInter',fld:'DOCDICIONARIOTRANSFINTER',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13352',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E14352',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A98DocDicionarioId',fld:'DOCDICIONARIOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_DOCDICIONARIOID","{handler:'Valid_Docdicionarioid',iparms:[]");
         setEventMetadata("VALID_DOCDICIONARIOID",",oparms:[]}");
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
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         A102DocDicionarioFinalidade = "";
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         A5PaisNome = "";
         A73HipoteseTratamentoNome = "";
         TempTags = "";
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
         scmdbuf = "";
         H00352_A24AreaResponsavelId = new int[1] ;
         H00352_A25AreaResponsavelNome = new string[] {""} ;
         H00353_A24AreaResponsavelId = new int[1] ;
         H00353_A25AreaResponsavelNome = new string[] {""} ;
         H00354_A98DocDicionarioId = new int[1] ;
         H00354_A4PaisId = new int[1] ;
         H00354_n4PaisId = new bool[] {false} ;
         H00354_A72HipoteseTratamentoId = new int[1] ;
         H00354_A73HipoteseTratamentoNome = new string[] {""} ;
         H00354_A5PaisNome = new string[] {""} ;
         H00354_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         H00354_A102DocDicionarioFinalidade = new string[] {""} ;
         H00354_A101DocDicionarioTransfInter = new bool[] {false} ;
         H00354_A99DocDicionarioSensivel = new bool[] {false} ;
         H00354_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         H00354_A69InformacaoId = new int[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA98DocDicionarioId = "";
         H00355_A24AreaResponsavelId = new int[1] ;
         H00355_A25AreaResponsavelNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionariogeneral__default(),
            new Object[][] {
                new Object[] {
               H00352_A24AreaResponsavelId, H00352_A25AreaResponsavelNome
               }
               , new Object[] {
               H00353_A24AreaResponsavelId, H00353_A25AreaResponsavelNome
               }
               , new Object[] {
               H00354_A98DocDicionarioId, H00354_A4PaisId, H00354_n4PaisId, H00354_A72HipoteseTratamentoId, H00354_A73HipoteseTratamentoNome, H00354_A5PaisNome, H00354_A103DocDicionarioDataInclusao, H00354_A102DocDicionarioFinalidade, H00354_A101DocDicionarioTransfInter, H00354_A99DocDicionarioSensivel,
               H00354_A100DocDicionarioPodeEliminar, H00354_A69InformacaoId
               }
               , new Object[] {
               H00355_A24AreaResponsavelId, H00355_A25AreaResponsavelNome
               }
            }
         );
         AV17Pgmname = "DocDicionarioGeneral";
         /* GeneXus formulas. */
         AV17Pgmname = "DocDicionarioGeneral";
         context.Gx_err = 0;
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
      private int A98DocDicionarioId ;
      private int wcpOA98DocDicionarioId ;
      private int A69InformacaoId ;
      private int edtDocDicionarioFinalidade_Enabled ;
      private int edtDocDicionarioDataInclusao_Enabled ;
      private int edtPaisNome_Enabled ;
      private int edtHipoteseTratamentoNome_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtDocDicionarioId_Visible ;
      private int gxdynajaxindex ;
      private int A4PaisId ;
      private int A72HipoteseTratamentoId ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV17Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string dynInformacaoId_Internalname ;
      private string dynInformacaoId_Jsonclick ;
      private string chkDocDicionarioPodeEliminar_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string chkDocDicionarioSensivel_Internalname ;
      private string chkDocDicionarioTransfInter_Internalname ;
      private string edtDocDicionarioFinalidade_Internalname ;
      private string edtDocDicionarioDataInclusao_Internalname ;
      private string edtDocDicionarioDataInclusao_Jsonclick ;
      private string edtPaisNome_Internalname ;
      private string edtPaisNome_Link ;
      private string edtPaisNome_Jsonclick ;
      private string edtHipoteseTratamentoNome_Internalname ;
      private string edtHipoteseTratamentoNome_Link ;
      private string edtHipoteseTratamentoNome_Jsonclick ;
      private string TempTags ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDocDicionarioId_Internalname ;
      private string edtDocDicionarioId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string sCtrlA98DocDicionarioId ;
      private DateTime A103DocDicionarioDataInclusao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A99DocDicionarioSensivel ;
      private bool A101DocDicionarioTransfInter ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n4PaisId ;
      private bool returnInSub ;
      private bool AV14TempBoolean ;
      private bool GXt_boolean1 ;
      private string A102DocDicionarioFinalidade ;
      private string A5PaisNome ;
      private string A73HipoteseTratamentoNome ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynInformacaoId ;
      private GXCheckbox chkDocDicionarioPodeEliminar ;
      private GXCheckbox chkDocDicionarioSensivel ;
      private GXCheckbox chkDocDicionarioTransfInter ;
      private IDataStoreProvider pr_default ;
      private int[] H00352_A24AreaResponsavelId ;
      private string[] H00352_A25AreaResponsavelNome ;
      private int[] H00353_A24AreaResponsavelId ;
      private string[] H00353_A25AreaResponsavelNome ;
      private int[] H00354_A98DocDicionarioId ;
      private int[] H00354_A4PaisId ;
      private bool[] H00354_n4PaisId ;
      private int[] H00354_A72HipoteseTratamentoId ;
      private string[] H00354_A73HipoteseTratamentoNome ;
      private string[] H00354_A5PaisNome ;
      private DateTime[] H00354_A103DocDicionarioDataInclusao ;
      private string[] H00354_A102DocDicionarioFinalidade ;
      private bool[] H00354_A101DocDicionarioTransfInter ;
      private bool[] H00354_A99DocDicionarioSensivel ;
      private bool[] H00354_A100DocDicionarioPodeEliminar ;
      private int[] H00354_A69InformacaoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00355_A24AreaResponsavelId ;
      private string[] H00355_A25AreaResponsavelNome ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class docdicionariogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00352;
          prmH00352 = new Object[] {
          };
          Object[] prmH00353;
          prmH00353 = new Object[] {
          };
          Object[] prmH00354;
          prmH00354 = new Object[] {
          new ParDef("@DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmH00355;
          prmH00355 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00352", "SELECT [AreaResponsavelId], [AreaResponsavelNome] FROM [AreaResponsavel] ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00352,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00353", "SELECT [AreaResponsavelId], [AreaResponsavelNome] FROM [AreaResponsavel] ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00353,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00354", "SELECT T1.[DocDicionarioId], T1.[PaisId], T1.[HipoteseTratamentoId], T3.[HipoteseTratamentoNome], T2.[PaisNome], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioFinalidade], T1.[DocDicionarioTransfInter], T1.[DocDicionarioSensivel], T1.[DocDicionarioPodeEliminar], T1.[InformacaoId] FROM (([DocDicionario] T1 LEFT JOIN [Pais] T2 ON T2.[PaisId] = T1.[PaisId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) WHERE T1.[DocDicionarioId] = @DocDicionarioId ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00354,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00355", "SELECT [AreaResponsavelId], [AreaResponsavelNome] FROM [AreaResponsavel] ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00355,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.getBool(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
