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
   public class gamupdateregisteruser : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamupdateregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public gamupdateregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV11IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV11IDP_State;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGender = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA0B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0B2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "gamupdateregisteruser.aspx"+UrlEncode(StringUtil.RTrim(AV11IDP_State));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamupdateregisteruser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV18CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV11IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
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
            WE0B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0B2( ) ;
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
         GXEncryptionTmp = "gamupdateregisteruser.aspx"+UrlEncode(StringUtil.RTrim(AV11IDP_State));
         return formatLink("gamupdateregisteruser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMUpdateRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Update register user" ;
      }

      protected void WB0B0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table100x100", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLogin", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgHeaderoriginal_gximage, "")==0) ? "GX_Image_LogoLogin_Class" : "GX_Image_"+imgHeaderoriginal_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeaderoriginal_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLogin2Cols", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "Atualizar o registro", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Login", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV14Name, StringUtil.RTrim( context.localUtil.Format( AV14Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmail_cell_Internalname, 1, 0, "px", 0, "px", divEmail_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV6EMail, StringUtil.RTrim( context.localUtil.Format( AV6EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Email", edtavEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFirstname_cell_Internalname, 1, 0, "px", 0, "px", divFirstname_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV9FirstName), StringUtil.RTrim( context.localUtil.Format( AV9FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "First Name", edtavFirstname_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFirstname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLastname_cell_Internalname, 1, 0, "px", 0, "px", divLastname_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, "Sobrenome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV13LastName), StringUtil.RTrim( context.localUtil.Format( AV13LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Last Name", edtavLastname_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavLastname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBirthday_cell_Internalname, 1, 0, "px", 0, "px", divBirthday_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, "Data de nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV5Birthday, "99/99/9999"), context.localUtil.Format( AV5Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavBirthday_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "right", false, "", "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUpdateRegisterUser.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGender_cell_Internalname, 1, 0, "px", 0, "px", divGender_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, "Sexo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV10Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_GAMUpdateRegisterUser.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV10Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Voltar para o Login", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableerror_Internalname, divTableerror_Visible, 0, "px", 0, "px", "TableLoginError2Cols", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0B2( )
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
            Form.Meta.addItem("description", "Update register user", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0B0( ) ;
      }

      protected void WS0B2( )
      {
         START0B2( ) ;
         EVT0B2( ) ;
      }

      protected void EVT0B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E120B2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130B2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0B2( )
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

      protected void PA0B2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamupdateregisteruser.aspx")), "gamupdateregisteruser.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamupdateregisteruser.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "IDP_State");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV11IDP_State = gxfirstwebparm;
                     AssignAttri("", false, "AV11IDP_State", AV11IDP_State);
                     GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
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
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavGender.ItemCount > 0 )
         {
            AV10Gender = cmbavGender.getValidValue(AV10Gender);
            AssignAttri("", false, "AV10Gender", AV10Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV10Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0B2( ) ;
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

      protected void RF0B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130B2 ();
            WB0B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0B2( )
      {
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV11IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV14Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV14Name", AV14Name);
            AV6EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV6EMail", AV6EMail);
            AV9FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV9FirstName", AV9FirstName);
            AV13LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV13LastName", AV13LastName);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Birthday"}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            }
            else
            {
               AV5Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), 2);
               AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV10Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV10Gender", AV10Gender);
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
         E110B2 ();
         if (returnInSub) return;
      }

      protected void E110B2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Backcolor = GXUtil.RGB( 238, 238, 238);
         AssignProp("", false, "FORM", "Backcolor", StringUtil.LTrimStr( (decimal)(Form.Backcolor), 9, 0), true);
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         divTableerror_Visible = 0;
         AssignProp("", false, divTableerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableerror_Visible), 5, 0), true);
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV8Errors);
         if ( AV8Errors.Count > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            AV8Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S112 ();
            if (returnInSub) return;
            AV14Name = AV17User.gxTpr_Name;
            AssignAttri("", false, "AV14Name", AV14Name);
            AV6EMail = AV17User.gxTpr_Email;
            AssignAttri("", false, "AV6EMail", AV6EMail);
            AV9FirstName = AV17User.gxTpr_Firstname;
            AssignAttri("", false, "AV9FirstName", AV9FirstName);
            AV13LastName = AV17User.gxTpr_Lastname;
            AssignAttri("", false, "AV13LastName", AV13LastName);
            AV5Birthday = AV17User.gxTpr_Birthday;
            AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            AV10Gender = AV17User.gxTpr_Gender;
            AssignAttri("", false, "AV10Gender", AV10Gender);
         }
         AV15Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV18CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14Name)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Login", "", "", "", "", "", "", "", ""),  "error",  edtavName_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ( AV15Repository.gxTpr_Requiredemail ) && String.IsNullOrEmpty(StringUtil.RTrim( AV6EMail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ( AV15Repository.gxTpr_Requiredfirstname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV9FirstName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavFirstname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ( AV15Repository.gxTpr_Requiredlastname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV13LastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Sobrenome", "", "", "", "", "", "", "", ""),  "error",  edtavLastname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ( AV15Repository.gxTpr_Requiredbirthday ) && (DateTime.MinValue==AV5Birthday) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Data de nascimento", "", "", "", "", "", "", "", ""),  "error",  edtavBirthday_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ( AV15Repository.gxTpr_Requiredgender ) && String.IsNullOrEmpty(StringUtil.RTrim( AV10Gender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Sexo", "", "", "", "", "", "", "", ""),  "error",  cmbavGender_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV15Repository.gxTpr_Requiredemail )
         {
            divEmail_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         else
         {
            divEmail_cell_Class = "col-xs-12 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         if ( AV15Repository.gxTpr_Requiredfirstname )
         {
            divFirstname_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         else
         {
            divFirstname_cell_Class = "col-xs-12 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         if ( AV15Repository.gxTpr_Requiredlastname )
         {
            divLastname_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         else
         {
            divLastname_cell_Class = "col-xs-12 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         if ( AV15Repository.gxTpr_Requiredbirthday )
         {
            divBirthday_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divBirthday_cell_Internalname, "Class", divBirthday_cell_Class, true);
         }
         else
         {
            divBirthday_cell_Class = "col-xs-12 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divBirthday_cell_Internalname, "Class", divBirthday_cell_Class, true);
         }
         if ( AV15Repository.gxTpr_Requiredgender )
         {
            divGender_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divGender_cell_Internalname, "Class", divGender_cell_Class, true);
         }
         else
         {
            divGender_cell_Class = "col-xs-12 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divGender_cell_Internalname, "Class", divGender_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120B2 ();
         if (returnInSub) return;
      }

      protected void E120B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV18CheckRequiredFieldsResult )
         {
            AV17User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV8Errors);
            AV17User.load( AV17User.gxTpr_Guid);
            AV17User.gxTpr_Name = AV14Name;
            AV17User.gxTpr_Email = AV6EMail;
            AV17User.gxTpr_Firstname = AV9FirstName;
            AV17User.gxTpr_Lastname = AV13LastName;
            AV17User.gxTpr_Birthday = AV5Birthday;
            AV17User.gxTpr_Gender = AV10Gender;
            AV12isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateuserbykeytocompleteuserdata(AV17User, out  AV8Errors);
            if ( AV12isOK )
            {
               if ( AV8Errors.Count > 0 )
               {
                  GX_msglist.addItem("Seus dados foram atualizados com sucesso!.");
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               else
               {
                  if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV11IDP_State) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV11IDP_State) ;
                  }
                  else
                  {
                     AV16URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16URL)) )
                     {
                        new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome("8d9934db-05db-4d64-adba-5e0466c3appU") ;
                     }
                     else
                     {
                        CallWebObject(formatLink(AV16URL) );
                        context.wjLocDisableFrm = 0;
                     }
                  }
               }
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         divTableerror_Visible = 1;
         AssignProp("", false, divTableerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableerror_Visible), 5, 0), true);
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV8Errors.Count )
         {
            AV7Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV8Errors.Item(AV26GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV7Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV7Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV26GXV1 = (int)(AV26GXV1+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E130B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV11IDP_State", AV11IDP_State);
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
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
         PA0B2( ) ;
         WS0B2( ) ;
         WE0B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311910472634", true, true);
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
         context.AddJavascriptSource("gamupdateregisteruser.js", "?202311910472636", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", "N�o especificado", 0);
         cmbavGender.addItem("F", "Feminino", 0);
         cmbavGender.addItem("M", "Masculino", 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV10Gender = cmbavGender.getValidValue(AV10Gender);
            AssignAttri("", false, "AV10Gender", AV10Gender);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeaderoriginal_Internalname = "HEADERORIGINAL";
         lblSignin_Internalname = "SIGNIN";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         divEmail_cell_Internalname = "EMAIL_CELL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divFirstname_cell_Internalname = "FIRSTNAME_CELL";
         edtavLastname_Internalname = "vLASTNAME";
         divLastname_cell_Internalname = "LASTNAME_CELL";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divBirthday_cell_Internalname = "BIRTHDAY_CELL";
         cmbavGender_Internalname = "vGENDER";
         divGender_cell_Internalname = "GENDER_CELL";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablelogin_Internalname = "TABLELOGIN";
         divTableerror_Internalname = "TABLEERROR";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
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
         divTableerror_Visible = 1;
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         divGender_cell_Class = "col-xs-12";
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         divBirthday_cell_Class = "col-xs-12";
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         divLastname_cell_Class = "col-xs-12";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         divFirstname_cell_Class = "col-xs-12";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         divEmail_cell_Class = "col-xs-12";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Update register user";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11IDP_State',fld:'vIDP_STATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E120B2',iparms:[{av:'AV18CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV6EMail',fld:'vEMAIL',pic:''},{av:'AV9FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV13LastName',fld:'vLASTNAME',pic:''},{av:'AV5Birthday',fld:'vBIRTHDAY',pic:''},{av:'cmbavGender'},{av:'AV10Gender',fld:'vGENDER',pic:''},{av:'AV11IDP_State',fld:'vIDP_STATE',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV18CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'divTableerror_Visible',ctrl:'TABLEERROR',prop:'Visible'}]}");
         setEventMetadata("VALIDV_BIRTHDAY","{handler:'Validv_Birthday',iparms:[]");
         setEventMetadata("VALIDV_BIRTHDAY",",oparms:[]}");
         setEventMetadata("VALIDV_GENDER","{handler:'Validv_Gender',iparms:[]");
         setEventMetadata("VALIDV_GENDER",",oparms:[]}");
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
         wcpOAV11IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         imgHeaderoriginal_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblSignin_Jsonclick = "";
         TempTags = "";
         AV14Name = "";
         AV6EMail = "";
         AV9FirstName = "";
         AV13LastName = "";
         AV5Birthday = DateTime.MinValue;
         AV10Gender = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV15Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV16URL = "";
         AV7Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavBirthday_Enabled ;
      private int divTableerror_Visible ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string AV11IDP_State ;
      private string wcpOAV11IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string imgHeaderoriginal_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeaderoriginal_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string divEmail_cell_Internalname ;
      private string divEmail_cell_Class ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divFirstname_cell_Internalname ;
      private string divFirstname_cell_Class ;
      private string edtavFirstname_Internalname ;
      private string AV9FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divLastname_cell_Internalname ;
      private string divLastname_cell_Class ;
      private string edtavLastname_Internalname ;
      private string AV13LastName ;
      private string edtavLastname_Jsonclick ;
      private string divBirthday_cell_Internalname ;
      private string divBirthday_cell_Class ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Jsonclick ;
      private string divGender_cell_Internalname ;
      private string divGender_cell_Class ;
      private string cmbavGender_Internalname ;
      private string AV10Gender ;
      private string cmbavGender_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divTableerror_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private DateTime AV5Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12isOK ;
      private string AV14Name ;
      private string AV6EMail ;
      private string AV16URL ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private GXCombobox cmbavGender ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV7Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17User ;
   }

}
