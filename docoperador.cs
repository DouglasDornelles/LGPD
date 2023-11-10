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
   public class docoperador : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
         if ( StringUtil.Len( sPrefix) == 0 )
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
               AV7DocOperadorId = (int)(NumberUtil.Val( GetPar( "DocOperadorId"), "."));
               AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV7DocOperadorId});
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
               GXDLAOPERADORID1447( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
            {
               A75DocumentoId = (int)(NumberUtil.Val( GetPar( "DocumentoId"), "."));
               AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_15( A75DocumentoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
            {
               A42OperadorId = (int)(NumberUtil.Val( GetPar( "OperadorId"), "."));
               AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_16( A42OperadorId) ;
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
         GXKey = Crypto.GetSiteKey( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "docoperador.aspx")), "docoperador.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "docoperador.aspx")))) ;
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
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                  {
                     AV7DocOperadorId = (int)(NumberUtil.Val( GetPar( "DocOperadorId"), "."));
                     AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_11-163677", 0) ;
               }
               Form.Meta.addItem("description", "Doc Operador", 0) ;
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
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynOperadorId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public docoperador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS");
         }
      }

      public docoperador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocOperadorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocOperadorId = aP1_DocOperadorId;
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
            return "docoperador_Execute" ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
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

      protected void fix_multi_value_controls( )
      {
         AV33DocOperadorCheckY = StringUtil.StrToBool( StringUtil.BoolToStr( AV33DocOperadorCheckY));
         AssignAttri(sPrefix, false, "AV33DocOperadorCheckY", AV33DocOperadorCheckY);
         AV34DocOperadorCheckN = StringUtil.StrToBool( StringUtil.BoolToStr( AV34DocOperadorCheckN));
         AssignAttri(sPrefix, false, "AV34DocOperadorCheckN", AV34DocOperadorCheckN);
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
            RenderHtmlCloseForm1447( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "docoperador.aspx");
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblOperadortextblock_Internalname, "OPERADOR", "", "", lblOperadortextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableoperadoroptions_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;", "div");
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
         AssignAttri(sPrefix, false, "AV33DocOperadorCheckY", AV33DocOperadorCheckY);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorchecky_Internalname, StringUtil.BoolToStr( AV33DocOperadorCheckY), "", "Doc Operador Check Y", 1, chkavDocoperadorchecky.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(26, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,26);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadorchecky_righttext_Internalname, "SIM", "", "", lblDocoperadorchecky_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;", "div");
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
         AssignAttri(sPrefix, false, "AV34DocOperadorCheckN", AV34DocOperadorCheckN);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavDocoperadorcheckn_Internalname, StringUtil.BoolToStr( AV34DocOperadorCheckN), "", "Doc Operador Check N", 1, chkavDocoperadorcheckn.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(34, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,34);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadorcheckn_righttext_Internalname, "NÃO", "", "", lblDocoperadorcheckn_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynOperadorId, dynOperadorId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A42OperadorId), 8, 0)), 1, dynOperadorId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynOperadorId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeStepBullet", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_DocOperador.htm");
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
         GxWebStd.gx_div_start( context, divTabledadoscheck_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:1;align-self:flex-start;", "div");
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
         AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorColeta_Internalname, StringUtil.BoolToStr( A87DocOperadorColeta), "", "Coleta?", 1, chkDocOperadorColeta.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadorcoleta_righttext_Internalname, "COLETA", "", "", lblDocoperadorcoleta_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:2;", "div");
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
         AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorRetencao_Internalname, StringUtil.BoolToStr( A88DocOperadorRetencao), "", "Retenção?", 1, chkDocOperadorRetencao.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,61);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadorretencao_righttext_Internalname, "RETENÇÃO", "", "", lblDocoperadorretencao_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:3;", "div");
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
         AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorCompartilhamento_Internalname, StringUtil.BoolToStr( A89DocOperadorCompartilhamento), "", "Compartilhamento?", 1, chkDocOperadorCompartilhamento.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadorcompartilhamento_righttext_Internalname, "COMPARTILHAMENTO", "", "", lblDocoperadorcompartilhamento_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:4;", "div");
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
         AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorEliminacao_Internalname, StringUtil.BoolToStr( A90DocOperadorEliminacao), "", "Eliminição?", 1, chkDocOperadorEliminacao.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(77, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,77);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadoreliminacao_righttext_Internalname, "ELIMINAÇÃO", "", "", lblDocoperadoreliminacao_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "left", "top", "", "flex-grow:5;", "div");
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
         AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocOperadorProcessamento_Internalname, StringUtil.BoolToStr( A91DocOperadorProcessamento), "", "Processamento?", 1, chkDocOperadorProcessamento.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(85, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDocoperadorprocessamento_righttext_Internalname, "PROCESSAMENTO", "", "", lblDocoperadorprocessamento_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_DocOperador.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, sPrefix+"W0093"+"", StringUtil.RTrim( WebComp_Wcdocoperadorgrid_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0093"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcdocoperadorgrid_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcdocoperadorgrid), StringUtil.Lower( WebComp_Wcdocoperadorgrid_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0093"+"");
               }
               WebComp_Wcdocoperadorgrid.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcdocoperadorgrid), StringUtil.Lower( WebComp_Wcdocoperadorgrid_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Adicionar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DocOperador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         GxWebStd.gx_single_line_edit( context, edtDocOperadorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A86DocOperadorId), 8, 0, ",", "")), StringUtil.LTrim( ((edtDocOperadorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A86DocOperadorId), "ZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocOperadorId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocOperadorId_Visible, edtDocOperadorId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocOperador.htm");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A75DocumentoId), "ZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentoId_Visible, edtDocumentoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_DocOperador.htm");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocOperadorDataInclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocOperadorDataInclusao_Internalname, context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"), context.localUtil.Format( A92DocOperadorDataInclusao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocOperadorDataInclusao_Jsonclick, 0, "Attribute", "", "", "", "", edtDocOperadorDataInclusao_Visible, edtDocOperadorDataInclusao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_DocOperador.htm");
         GxWebStd.gx_bitmap( context, edtDocOperadorDataInclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtDocOperadorDataInclusao_Visible==0)||(edtDocOperadorDataInclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DocOperador.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcdocoperadorgrid_Component) != 0 )
               {
                  WebComp_Wcdocoperadorgrid.componentstart();
               }
            }
         }
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
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11142 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z86DocOperadorId"), ",", "."));
               Z87DocOperadorColeta = StringUtil.StrToBool( cgiGet( sPrefix+"Z87DocOperadorColeta"));
               Z88DocOperadorRetencao = StringUtil.StrToBool( cgiGet( sPrefix+"Z88DocOperadorRetencao"));
               Z89DocOperadorCompartilhamento = StringUtil.StrToBool( cgiGet( sPrefix+"Z89DocOperadorCompartilhamento"));
               Z90DocOperadorEliminacao = StringUtil.StrToBool( cgiGet( sPrefix+"Z90DocOperadorEliminacao"));
               Z91DocOperadorProcessamento = StringUtil.StrToBool( cgiGet( sPrefix+"Z91DocOperadorProcessamento"));
               Z92DocOperadorDataInclusao = context.localUtil.CToD( cgiGet( sPrefix+"Z92DocOperadorDataInclusao"), 0);
               Z75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z75DocumentoId"), ",", "."));
               Z42OperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z42OperadorId"), ",", "."));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DocOperadorId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N75DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N75DocumentoId"), ",", "."));
               N42OperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N42OperadorId"), ",", "."));
               AV7DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vDOCOPERADORID"), ",", "."));
               AV13Insert_DocumentoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_DOCUMENTOID"), ",", "."));
               AV14Insert_OperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_OPERADORID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."));
               AV37Pgmname = cgiGet( sPrefix+"vPGMNAME");
               /* Read variables values. */
               AV33DocOperadorCheckY = StringUtil.StrToBool( cgiGet( chkavDocoperadorchecky_Internalname));
               AssignAttri(sPrefix, false, "AV33DocOperadorCheckY", AV33DocOperadorCheckY);
               AV34DocOperadorCheckN = StringUtil.StrToBool( cgiGet( chkavDocoperadorcheckn_Internalname));
               AssignAttri(sPrefix, false, "AV34DocOperadorCheckN", AV34DocOperadorCheckN);
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
               A86DocOperadorId = (int)(context.localUtil.CToN( cgiGet( edtDocOperadorId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCUMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A75DocumentoId = 0;
                  AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               }
               else
               {
                  A75DocumentoId = (int)(context.localUtil.CToN( cgiGet( edtDocumentoId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtDocOperadorDataInclusao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Doc Operador Data Inclusao"}), 1, "DOCOPERADORDATAINCLUSAO");
                  AnyError = 1;
                  GX_FocusControl = edtDocOperadorDataInclusao_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A92DocOperadorDataInclusao = DateTime.MinValue;
                  AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
               }
               else
               {
                  A92DocOperadorDataInclusao = context.localUtil.CToD( cgiGet( edtDocOperadorDataInclusao_Internalname), 2);
                  AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"DocOperador");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A86DocOperadorId != Z86DocOperadorId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("docoperador:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A86DocOperadorId = (int)(NumberUtil.Val( GetPar( "DocOperadorId"), "."));
                  AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode47 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode47;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound47 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_140( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCOPERADORID");
                        AnyError = 1;
                        GX_FocusControl = edtDocOperadorId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E11142 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E12142 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                     if ( nCmpId == 93 )
                     {
                        OldWcdocoperadorgrid = cgiGet( sPrefix+"W0093");
                        if ( ( StringUtil.Len( OldWcdocoperadorgrid) == 0 ) || ( StringUtil.StrCmp(OldWcdocoperadorgrid, WebComp_Wcdocoperadorgrid_Component) != 0 ) )
                        {
                           WebComp_Wcdocoperadorgrid = getWebComponent(GetType(), "GeneXus.Programs", OldWcdocoperadorgrid, new Object[] {context} );
                           WebComp_Wcdocoperadorgrid.ComponentInit();
                           WebComp_Wcdocoperadorgrid.Name = "OldWcdocoperadorgrid";
                           WebComp_Wcdocoperadorgrid_Component = OldWcdocoperadorgrid;
                        }
                        if ( StringUtil.Len( WebComp_Wcdocoperadorgrid_Component) != 0 )
                        {
                           WebComp_Wcdocoperadorgrid.componentprocess(sPrefix+"W0093", "", sEvt);
                        }
                        WebComp_Wcdocoperadorgrid_Component = OldWcdocoperadorgrid;
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
            E12142 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1447( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1447( ) ;
         }
         AssignProp(sPrefix, false, chkavDocoperadorchecky_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorchecky.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkavDocoperadorcheckn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcheckn.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocOperadorColeta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorColeta.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocOperadorRetencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorRetencao.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocOperadorCompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorCompartilhamento.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocOperadorEliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorEliminacao.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkDocOperadorProcessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorProcessamento.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDocOperadorDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocOperadorDataInclusao_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1447( ) ;
            }
            else
            {
               CheckExtendedTable1447( ) ;
               CloseExtendedTableCursors1447( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption140( )
      {
      }

      protected void E11142( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV37Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV38GXV1 = 1;
            AssignAttri(sPrefix, false, "AV38GXV1", StringUtil.LTrimStr( (decimal)(AV38GXV1), 8, 0));
            while ( AV38GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV38GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV13Insert_DocumentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DocumentoId), 8, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OperadorId") == 0 )
               {
                  AV14Insert_OperadorId = (int)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV14Insert_OperadorId", StringUtil.LTrimStr( (decimal)(AV14Insert_OperadorId), 8, 0));
               }
               AV38GXV1 = (int)(AV38GXV1+1);
               AssignAttri(sPrefix, false, "AV38GXV1", StringUtil.LTrimStr( (decimal)(AV38GXV1), 8, 0));
            }
         }
         edtDocOperadorId_Visible = 0;
         AssignProp(sPrefix, false, edtDocOperadorId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocOperadorId_Visible), 5, 0), true);
         edtDocumentoId_Visible = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Visible), 5, 0), true);
         edtDocOperadorDataInclusao_Visible = 0;
         AssignProp(sPrefix, false, edtDocOperadorDataInclusao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocOperadorDataInclusao_Visible), 5, 0), true);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wcdocoperadorgrid = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcdocoperadorgrid_Component), StringUtil.Lower( "DocOperadorGrid")) != 0 )
         {
            WebComp_Wcdocoperadorgrid = getWebComponent(GetType(), "GeneXus.Programs", "docoperadorgrid", new Object[] {context} );
            WebComp_Wcdocoperadorgrid.ComponentInit();
            WebComp_Wcdocoperadorgrid.Name = "DocOperadorGrid";
            WebComp_Wcdocoperadorgrid_Component = "DocOperadorGrid";
         }
         if ( StringUtil.Len( WebComp_Wcdocoperadorgrid_Component) != 0 )
         {
            WebComp_Wcdocoperadorgrid.setjustcreated();
            WebComp_Wcdocoperadorgrid.componentprepare(new Object[] {(string)sPrefix+"W0093",(string)""});
            WebComp_Wcdocoperadorgrid.componentbind(new Object[] {});
         }
      }

      protected void E12142( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("docoperadorww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1447( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z87DocOperadorColeta = T00143_A87DocOperadorColeta[0];
               Z88DocOperadorRetencao = T00143_A88DocOperadorRetencao[0];
               Z89DocOperadorCompartilhamento = T00143_A89DocOperadorCompartilhamento[0];
               Z90DocOperadorEliminacao = T00143_A90DocOperadorEliminacao[0];
               Z91DocOperadorProcessamento = T00143_A91DocOperadorProcessamento[0];
               Z92DocOperadorDataInclusao = T00143_A92DocOperadorDataInclusao[0];
               Z75DocumentoId = T00143_A75DocumentoId[0];
               Z42OperadorId = T00143_A42OperadorId[0];
            }
            else
            {
               Z87DocOperadorColeta = A87DocOperadorColeta;
               Z88DocOperadorRetencao = A88DocOperadorRetencao;
               Z89DocOperadorCompartilhamento = A89DocOperadorCompartilhamento;
               Z90DocOperadorEliminacao = A90DocOperadorEliminacao;
               Z91DocOperadorProcessamento = A91DocOperadorProcessamento;
               Z92DocOperadorDataInclusao = A92DocOperadorDataInclusao;
               Z75DocumentoId = A75DocumentoId;
               Z42OperadorId = A42OperadorId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z86DocOperadorId = A86DocOperadorId;
            Z87DocOperadorColeta = A87DocOperadorColeta;
            Z88DocOperadorRetencao = A88DocOperadorRetencao;
            Z89DocOperadorCompartilhamento = A89DocOperadorCompartilhamento;
            Z90DocOperadorEliminacao = A90DocOperadorEliminacao;
            Z91DocOperadorProcessamento = A91DocOperadorProcessamento;
            Z92DocOperadorDataInclusao = A92DocOperadorDataInclusao;
            Z75DocumentoId = A75DocumentoId;
            Z42OperadorId = A42OperadorId;
         }
      }

      protected void standaloneNotModal( )
      {
         GXAOPERADORID_html1447( ) ;
         edtDocOperadorId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocOperadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocOperadorId_Enabled), 5, 0), true);
         AV37Pgmname = "DocOperador";
         AssignAttri(sPrefix, false, "AV37Pgmname", AV37Pgmname);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtDocOperadorId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocOperadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocOperadorId_Enabled), 5, 0), true);
         if ( ! (0==AV7DocOperadorId) )
         {
            A86DocOperadorId = AV7DocOperadorId;
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            edtDocumentoId_Enabled = 0;
            AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocumentoId_Enabled = 1;
            AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_OperadorId) )
         {
            dynOperadorId.Enabled = 0;
            AssignProp(sPrefix, false, dynOperadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynOperadorId.Enabled), 5, 0), true);
         }
         else
         {
            dynOperadorId.Enabled = 1;
            AssignProp(sPrefix, false, dynOperadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynOperadorId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_OperadorId) )
         {
            A42OperadorId = AV14Insert_OperadorId;
            AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DocumentoId) )
         {
            A75DocumentoId = AV13Insert_DocumentoId;
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A92DocOperadorDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A92DocOperadorDataInclusao = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1447( )
      {
         /* Using cursor T00146 */
         pr_default.execute(4, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound47 = 1;
            A87DocOperadorColeta = T00146_A87DocOperadorColeta[0];
            AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
            A88DocOperadorRetencao = T00146_A88DocOperadorRetencao[0];
            AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
            A89DocOperadorCompartilhamento = T00146_A89DocOperadorCompartilhamento[0];
            AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
            A90DocOperadorEliminacao = T00146_A90DocOperadorEliminacao[0];
            AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
            A91DocOperadorProcessamento = T00146_A91DocOperadorProcessamento[0];
            AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
            A92DocOperadorDataInclusao = T00146_A92DocOperadorDataInclusao[0];
            AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
            A75DocumentoId = T00146_A75DocumentoId[0];
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            A42OperadorId = T00146_A42OperadorId[0];
            AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
            ZM1447( -14) ;
         }
         pr_default.close(4);
         OnLoadActions1447( ) ;
      }

      protected void OnLoadActions1447( )
      {
      }

      protected void CheckExtendedTable1447( )
      {
         nIsDirty_47 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00144 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00145 */
         pr_default.execute(3, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Operador'.", "ForeignKeyNotFound", 1, "OPERADORID");
            AnyError = 1;
            GX_FocusControl = dynOperadorId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A92DocOperadorDataInclusao) || ( DateTimeUtil.ResetTime ( A92DocOperadorDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Doc Operador Data Inclusao fora do intervalo", "OutOfRange", 1, "DOCOPERADORDATAINCLUSAO");
            AnyError = 1;
            GX_FocusControl = edtDocOperadorDataInclusao_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1447( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A75DocumentoId )
      {
         /* Using cursor T00147 */
         pr_default.execute(5, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_16( int A42OperadorId )
      {
         /* Using cursor T00148 */
         pr_default.execute(6, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Operador'.", "ForeignKeyNotFound", 1, "OPERADORID");
            AnyError = 1;
            GX_FocusControl = dynOperadorId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1447( )
      {
         /* Using cursor T00149 */
         pr_default.execute(7, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00143 */
         pr_default.execute(1, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1447( 14) ;
            RcdFound47 = 1;
            A86DocOperadorId = T00143_A86DocOperadorId[0];
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
            A87DocOperadorColeta = T00143_A87DocOperadorColeta[0];
            AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
            A88DocOperadorRetencao = T00143_A88DocOperadorRetencao[0];
            AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
            A89DocOperadorCompartilhamento = T00143_A89DocOperadorCompartilhamento[0];
            AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
            A90DocOperadorEliminacao = T00143_A90DocOperadorEliminacao[0];
            AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
            A91DocOperadorProcessamento = T00143_A91DocOperadorProcessamento[0];
            AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
            A92DocOperadorDataInclusao = T00143_A92DocOperadorDataInclusao[0];
            AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
            A75DocumentoId = T00143_A75DocumentoId[0];
            AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
            A42OperadorId = T00143_A42OperadorId[0];
            AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
            Z86DocOperadorId = A86DocOperadorId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load1447( ) ;
            if ( AnyError == 1 )
            {
               RcdFound47 = 0;
               InitializeNonKey1447( ) ;
            }
            Gx_mode = sMode47;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey1447( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode47;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1447( ) ;
         if ( RcdFound47 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound47 = 0;
         /* Using cursor T001410 */
         pr_default.execute(8, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001410_A86DocOperadorId[0] < A86DocOperadorId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001410_A86DocOperadorId[0] > A86DocOperadorId ) ) )
            {
               A86DocOperadorId = T001410_A86DocOperadorId[0];
               AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
               RcdFound47 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound47 = 0;
         /* Using cursor T001411 */
         pr_default.execute(9, new Object[] {A86DocOperadorId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001411_A86DocOperadorId[0] > A86DocOperadorId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001411_A86DocOperadorId[0] < A86DocOperadorId ) ) )
            {
               A86DocOperadorId = T001411_A86DocOperadorId[0];
               AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
               RcdFound47 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1447( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynOperadorId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert1447( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound47 == 1 )
            {
               if ( A86DocOperadorId != Z86DocOperadorId )
               {
                  A86DocOperadorId = Z86DocOperadorId;
                  AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCOPERADORID");
                  AnyError = 1;
                  GX_FocusControl = edtDocOperadorId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynOperadorId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1447( ) ;
                  GX_FocusControl = dynOperadorId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A86DocOperadorId != Z86DocOperadorId )
               {
                  /* Insert record */
                  GX_FocusControl = dynOperadorId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert1447( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCOPERADORID");
                     AnyError = 1;
                     GX_FocusControl = edtDocOperadorId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynOperadorId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert1447( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A86DocOperadorId != Z86DocOperadorId )
         {
            A86DocOperadorId = Z86DocOperadorId;
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCOPERADORID");
            AnyError = 1;
            GX_FocusControl = edtDocOperadorId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynOperadorId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1447( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00142 */
            pr_default.execute(0, new Object[] {A86DocOperadorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocOperador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z87DocOperadorColeta != T00142_A87DocOperadorColeta[0] ) || ( Z88DocOperadorRetencao != T00142_A88DocOperadorRetencao[0] ) || ( Z89DocOperadorCompartilhamento != T00142_A89DocOperadorCompartilhamento[0] ) || ( Z90DocOperadorEliminacao != T00142_A90DocOperadorEliminacao[0] ) || ( Z91DocOperadorProcessamento != T00142_A91DocOperadorProcessamento[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z92DocOperadorDataInclusao ) != DateTimeUtil.ResetTime ( T00142_A92DocOperadorDataInclusao[0] ) ) || ( Z75DocumentoId != T00142_A75DocumentoId[0] ) || ( Z42OperadorId != T00142_A42OperadorId[0] ) )
            {
               if ( Z87DocOperadorColeta != T00142_A87DocOperadorColeta[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocOperadorColeta");
                  GXUtil.WriteLogRaw("Old: ",Z87DocOperadorColeta);
                  GXUtil.WriteLogRaw("Current: ",T00142_A87DocOperadorColeta[0]);
               }
               if ( Z88DocOperadorRetencao != T00142_A88DocOperadorRetencao[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocOperadorRetencao");
                  GXUtil.WriteLogRaw("Old: ",Z88DocOperadorRetencao);
                  GXUtil.WriteLogRaw("Current: ",T00142_A88DocOperadorRetencao[0]);
               }
               if ( Z89DocOperadorCompartilhamento != T00142_A89DocOperadorCompartilhamento[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocOperadorCompartilhamento");
                  GXUtil.WriteLogRaw("Old: ",Z89DocOperadorCompartilhamento);
                  GXUtil.WriteLogRaw("Current: ",T00142_A89DocOperadorCompartilhamento[0]);
               }
               if ( Z90DocOperadorEliminacao != T00142_A90DocOperadorEliminacao[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocOperadorEliminacao");
                  GXUtil.WriteLogRaw("Old: ",Z90DocOperadorEliminacao);
                  GXUtil.WriteLogRaw("Current: ",T00142_A90DocOperadorEliminacao[0]);
               }
               if ( Z91DocOperadorProcessamento != T00142_A91DocOperadorProcessamento[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocOperadorProcessamento");
                  GXUtil.WriteLogRaw("Old: ",Z91DocOperadorProcessamento);
                  GXUtil.WriteLogRaw("Current: ",T00142_A91DocOperadorProcessamento[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z92DocOperadorDataInclusao ) != DateTimeUtil.ResetTime ( T00142_A92DocOperadorDataInclusao[0] ) )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocOperadorDataInclusao");
                  GXUtil.WriteLogRaw("Old: ",Z92DocOperadorDataInclusao);
                  GXUtil.WriteLogRaw("Current: ",T00142_A92DocOperadorDataInclusao[0]);
               }
               if ( Z75DocumentoId != T00142_A75DocumentoId[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"DocumentoId");
                  GXUtil.WriteLogRaw("Old: ",Z75DocumentoId);
                  GXUtil.WriteLogRaw("Current: ",T00142_A75DocumentoId[0]);
               }
               if ( Z42OperadorId != T00142_A42OperadorId[0] )
               {
                  GXUtil.WriteLog("docoperador:[seudo value changed for attri]"+"OperadorId");
                  GXUtil.WriteLogRaw("Old: ",Z42OperadorId);
                  GXUtil.WriteLogRaw("Current: ",T00142_A42OperadorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocOperador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1447( )
      {
         if ( ! IsAuthorized("docoperador_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1447( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1447( 0) ;
            CheckOptimisticConcurrency1447( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1447( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1447( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001412 */
                     pr_default.execute(10, new Object[] {A87DocOperadorColeta, A88DocOperadorRetencao, A89DocOperadorCompartilhamento, A90DocOperadorEliminacao, A91DocOperadorProcessamento, A92DocOperadorDataInclusao, A75DocumentoId, A42OperadorId});
                     A86DocOperadorId = T001412_A86DocOperadorId[0];
                     AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("DocOperador");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption140( ) ;
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
               Load1447( ) ;
            }
            EndLevel1447( ) ;
         }
         CloseExtendedTableCursors1447( ) ;
      }

      protected void Update1447( )
      {
         if ( ! IsAuthorized("docoperador_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1447( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1447( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1447( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1447( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001413 */
                     pr_default.execute(11, new Object[] {A87DocOperadorColeta, A88DocOperadorRetencao, A89DocOperadorCompartilhamento, A90DocOperadorEliminacao, A91DocOperadorProcessamento, A92DocOperadorDataInclusao, A75DocumentoId, A42OperadorId, A86DocOperadorId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("DocOperador");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocOperador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1447( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
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
            EndLevel1447( ) ;
         }
         CloseExtendedTableCursors1447( ) ;
      }

      protected void DeferredUpdate1447( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("docoperador_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1447( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1447( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1447( ) ;
            AfterConfirm1447( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1447( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001414 */
                  pr_default.execute(12, new Object[] {A86DocOperadorId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("DocOperador");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel1447( ) ;
         Gx_mode = sMode47;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1447( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1447( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1447( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("docoperador",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues140( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("docoperador",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1447( )
      {
         /* Scan By routine */
         /* Using cursor T001415 */
         pr_default.execute(13);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound47 = 1;
            A86DocOperadorId = T001415_A86DocOperadorId[0];
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1447( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound47 = 1;
            A86DocOperadorId = T001415_A86DocOperadorId[0];
            AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         }
      }

      protected void ScanEnd1447( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1447( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1447( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1447( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1447( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1447( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1447( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1447( )
      {
         chkavDocoperadorchecky.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorchecky_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorchecky.Enabled), 5, 0), true);
         chkavDocoperadorcheckn.Enabled = 0;
         AssignProp(sPrefix, false, chkavDocoperadorcheckn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDocoperadorcheckn.Enabled), 5, 0), true);
         dynOperadorId.Enabled = 0;
         AssignProp(sPrefix, false, dynOperadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynOperadorId.Enabled), 5, 0), true);
         chkDocOperadorColeta.Enabled = 0;
         AssignProp(sPrefix, false, chkDocOperadorColeta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorColeta.Enabled), 5, 0), true);
         chkDocOperadorRetencao.Enabled = 0;
         AssignProp(sPrefix, false, chkDocOperadorRetencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorRetencao.Enabled), 5, 0), true);
         chkDocOperadorCompartilhamento.Enabled = 0;
         AssignProp(sPrefix, false, chkDocOperadorCompartilhamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorCompartilhamento.Enabled), 5, 0), true);
         chkDocOperadorEliminacao.Enabled = 0;
         AssignProp(sPrefix, false, chkDocOperadorEliminacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorEliminacao.Enabled), 5, 0), true);
         chkDocOperadorProcessamento.Enabled = 0;
         AssignProp(sPrefix, false, chkDocOperadorProcessamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocOperadorProcessamento.Enabled), 5, 0), true);
         edtDocOperadorId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocOperadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocOperadorId_Enabled), 5, 0), true);
         edtDocumentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentoId_Enabled), 5, 0), true);
         edtDocOperadorDataInclusao_Enabled = 0;
         AssignProp(sPrefix, false, edtDocOperadorDataInclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocOperadorDataInclusao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1447( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues140( )
      {
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
            context.SendWebValue( "Doc Operador") ;
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
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "docoperador.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocOperadorId,8,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("docoperador.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"DocOperador");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("docoperador:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z86DocOperadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z86DocOperadorId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z87DocOperadorColeta", Z87DocOperadorColeta);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z88DocOperadorRetencao", Z88DocOperadorRetencao);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z89DocOperadorCompartilhamento", Z89DocOperadorCompartilhamento);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z90DocOperadorEliminacao", Z90DocOperadorEliminacao);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z91DocOperadorProcessamento", Z91DocOperadorProcessamento);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z92DocOperadorDataInclusao", context.localUtil.DToC( Z92DocOperadorDataInclusao, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z42OperadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42OperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7DocOperadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7DocOperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N75DocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N42OperadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A42OperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCOPERADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocOperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_DOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_DocumentoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_OPERADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_OperadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV37Pgmname));
      }

      protected void RenderHtmlCloseForm1447( )
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
            if ( ! ( WebComp_Wcdocoperadorgrid == null ) )
            {
               WebComp_Wcdocoperadorgrid.componentjscripts();
            }
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
         return "DocOperador" ;
      }

      public override string GetPgmdesc( )
      {
         return "Doc Operador" ;
      }

      protected void InitializeNonKey1447( )
      {
         A75DocumentoId = 0;
         AssignAttri(sPrefix, false, "A75DocumentoId", StringUtil.LTrimStr( (decimal)(A75DocumentoId), 8, 0));
         A42OperadorId = 0;
         AssignAttri(sPrefix, false, "A42OperadorId", StringUtil.LTrimStr( (decimal)(A42OperadorId), 8, 0));
         AV33DocOperadorCheckY = false;
         AssignAttri(sPrefix, false, "AV33DocOperadorCheckY", AV33DocOperadorCheckY);
         AV34DocOperadorCheckN = false;
         AssignAttri(sPrefix, false, "AV34DocOperadorCheckN", AV34DocOperadorCheckN);
         A87DocOperadorColeta = false;
         AssignAttri(sPrefix, false, "A87DocOperadorColeta", A87DocOperadorColeta);
         A88DocOperadorRetencao = false;
         AssignAttri(sPrefix, false, "A88DocOperadorRetencao", A88DocOperadorRetencao);
         A89DocOperadorCompartilhamento = false;
         AssignAttri(sPrefix, false, "A89DocOperadorCompartilhamento", A89DocOperadorCompartilhamento);
         A90DocOperadorEliminacao = false;
         AssignAttri(sPrefix, false, "A90DocOperadorEliminacao", A90DocOperadorEliminacao);
         A91DocOperadorProcessamento = false;
         AssignAttri(sPrefix, false, "A91DocOperadorProcessamento", A91DocOperadorProcessamento);
         A92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
         Z87DocOperadorColeta = false;
         Z88DocOperadorRetencao = false;
         Z89DocOperadorCompartilhamento = false;
         Z90DocOperadorEliminacao = false;
         Z91DocOperadorProcessamento = false;
         Z92DocOperadorDataInclusao = DateTime.MinValue;
         Z75DocumentoId = 0;
         Z42OperadorId = 0;
      }

      protected void InitAll1447( )
      {
         A86DocOperadorId = 0;
         AssignAttri(sPrefix, false, "A86DocOperadorId", StringUtil.LTrimStr( (decimal)(A86DocOperadorId), 8, 0));
         InitializeNonKey1447( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A92DocOperadorDataInclusao = i92DocOperadorDataInclusao;
         AssignAttri(sPrefix, false, "A92DocOperadorDataInclusao", context.localUtil.Format(A92DocOperadorDataInclusao, "99/99/99"));
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7DocOperadorId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "docoperador", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV7DocOperadorId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DocOperadorId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7DocOperadorId != wcpOAV7DocOperadorId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7DocOperadorId = AV7DocOperadorId;
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
         sCtrlAV7DocOperadorId = cgiGet( sPrefix+"AV7DocOperadorId_CTRL");
         if ( StringUtil.Len( sCtrlAV7DocOperadorId) > 0 )
         {
            AV7DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV7DocOperadorId), ",", "."));
            AssignAttri(sPrefix, false, "AV7DocOperadorId", StringUtil.LTrimStr( (decimal)(AV7DocOperadorId), 8, 0));
         }
         else
         {
            AV7DocOperadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV7DocOperadorId_PARM"), ",", "."));
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
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
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
         UserMain( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7DocOperadorId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocOperadorId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7DocOperadorId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7DocOperadorId_CTRL", StringUtil.RTrim( sCtrlAV7DocOperadorId));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            Draw( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
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
         if ( ! ( WebComp_Wcdocoperadorgrid == null ) )
         {
            WebComp_Wcdocoperadorgrid.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcdocoperadorgrid == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcdocoperadorgrid_Component) != 0 )
            {
               WebComp_Wcdocoperadorgrid.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312417263162", true, true);
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
         context.AddJavascriptSource("docoperador.js", "?202312417263163", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblOperadortextblock_Internalname = sPrefix+"OPERADORTEXTBLOCK";
         chkavDocoperadorchecky_Internalname = sPrefix+"vDOCOPERADORCHECKY";
         lblDocoperadorchecky_righttext_Internalname = sPrefix+"DOCOPERADORCHECKY_RIGHTTEXT";
         tblTablemergeddocoperadorchecky_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCHECKY";
         chkavDocoperadorcheckn_Internalname = sPrefix+"vDOCOPERADORCHECKN";
         lblDocoperadorcheckn_righttext_Internalname = sPrefix+"DOCOPERADORCHECKN_RIGHTTEXT";
         tblTablemergeddocoperadorcheckn_Internalname = sPrefix+"TABLEMERGEDDOCOPERADORCHECKN";
         divTableoperadoroptions_Internalname = sPrefix+"TABLEOPERADOROPTIONS";
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
         divTabledadoscheck_Internalname = sPrefix+"TABLEDADOSCHECK";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtDocOperadorDataInclusao_Jsonclick = "";
         edtDocOperadorDataInclusao_Enabled = 1;
         edtDocOperadorDataInclusao_Visible = 1;
         edtDocumentoId_Jsonclick = "";
         edtDocumentoId_Enabled = 1;
         edtDocumentoId_Visible = 1;
         edtDocOperadorId_Jsonclick = "";
         edtDocOperadorId_Enabled = 0;
         edtDocOperadorId_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkDocOperadorProcessamento.Enabled = 1;
         chkDocOperadorEliminacao.Enabled = 1;
         chkDocOperadorCompartilhamento.Enabled = 1;
         chkDocOperadorRetencao.Enabled = 1;
         chkDocOperadorColeta.Enabled = 1;
         dynOperadorId_Jsonclick = "";
         dynOperadorId.Enabled = 1;
         chkavDocoperadorcheckn.Enabled = 1;
         chkavDocoperadorchecky.Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLAOPERADORID1447( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAOPERADORID_data1447( ) ;
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

      protected void GXAOPERADORID_html1447( )
      {
         int gxdynajaxvalue;
         GXDLAOPERADORID_data1447( ) ;
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

      protected void GXDLAOPERADORID_data1447( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("SELECIONE...");
         /* Using cursor T001416 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001416_A42OperadorId[0]), 8, 0, ".", "")));
            gxdynajaxctrldescr.Add(T001416_A43OperadorNome[0]);
            pr_default.readNext(14);
         }
         pr_default.close(14);
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

      public void Valid_Operadorid( )
      {
         A42OperadorId = (int)(NumberUtil.Val( dynOperadorId.CurrentValue, "."));
         /* Using cursor T001417 */
         pr_default.execute(15, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'Operador'.", "ForeignKeyNotFound", 1, "OPERADORID");
            AnyError = 1;
            GX_FocusControl = dynOperadorId_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Documentoid( )
      {
         A42OperadorId = (int)(NumberUtil.Val( dynOperadorId.CurrentValue, "."));
         /* Using cursor T001418 */
         pr_default.execute(16, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDocumentoId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7DocOperadorId',fld:'vDOCOPERADORID',pic:'ZZZZZZZ9'},{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12142',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
         setEventMetadata("VALID_OPERADORID","{handler:'Valid_Operadorid',iparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("VALID_OPERADORID",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
         setEventMetadata("VALID_DOCOPERADORID","{handler:'Valid_Docoperadorid',iparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("VALID_DOCOPERADORID",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
         setEventMetadata("VALID_DOCUMENTOID","{handler:'Valid_Documentoid',iparms:[{av:'A75DocumentoId',fld:'DOCUMENTOID',pic:'ZZZZZZZ9'},{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("VALID_DOCUMENTOID",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
         setEventMetadata("VALID_DOCOPERADORDATAINCLUSAO","{handler:'Valid_Docoperadordatainclusao',iparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]");
         setEventMetadata("VALID_DOCOPERADORDATAINCLUSAO",",oparms:[{av:'dynOperadorId'},{av:'A42OperadorId',fld:'OPERADORID',pic:'ZZZZZZZ9'},{av:'AV33DocOperadorCheckY',fld:'vDOCOPERADORCHECKY',pic:''},{av:'AV34DocOperadorCheckN',fld:'vDOCOPERADORCHECKN',pic:''},{av:'A87DocOperadorColeta',fld:'DOCOPERADORCOLETA',pic:''},{av:'A88DocOperadorRetencao',fld:'DOCOPERADORRETENCAO',pic:''},{av:'A89DocOperadorCompartilhamento',fld:'DOCOPERADORCOMPARTILHAMENTO',pic:''},{av:'A90DocOperadorEliminacao',fld:'DOCOPERADORELIMINACAO',pic:''},{av:'A91DocOperadorProcessamento',fld:'DOCOPERADORPROCESSAMENTO',pic:''}]}");
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
         pr_default.close(16);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z92DocOperadorDataInclusao = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         sStyleString = "";
         lblOperadortextblock_Jsonclick = "";
         TempTags = "";
         lblDocoperadorchecky_righttext_Jsonclick = "";
         lblDocoperadorcheckn_righttext_Jsonclick = "";
         lblDocoperadorcoleta_righttext_Jsonclick = "";
         lblDocoperadorretencao_righttext_Jsonclick = "";
         lblDocoperadorcompartilhamento_righttext_Jsonclick = "";
         lblDocoperadoreliminacao_righttext_Jsonclick = "";
         lblDocoperadorprocessamento_righttext_Jsonclick = "";
         WebComp_Wcdocoperadorgrid_Component = "";
         OldWcdocoperadorgrid = "";
         bttBtntrn_enter_Jsonclick = "";
         A92DocOperadorDataInclusao = DateTime.MinValue;
         AV37Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode47 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         T00146_A86DocOperadorId = new int[1] ;
         T00146_A87DocOperadorColeta = new bool[] {false} ;
         T00146_A88DocOperadorRetencao = new bool[] {false} ;
         T00146_A89DocOperadorCompartilhamento = new bool[] {false} ;
         T00146_A90DocOperadorEliminacao = new bool[] {false} ;
         T00146_A91DocOperadorProcessamento = new bool[] {false} ;
         T00146_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00146_A75DocumentoId = new int[1] ;
         T00146_A42OperadorId = new int[1] ;
         T00144_A75DocumentoId = new int[1] ;
         T00145_A42OperadorId = new int[1] ;
         T00147_A75DocumentoId = new int[1] ;
         T00148_A42OperadorId = new int[1] ;
         T00149_A86DocOperadorId = new int[1] ;
         T00143_A86DocOperadorId = new int[1] ;
         T00143_A87DocOperadorColeta = new bool[] {false} ;
         T00143_A88DocOperadorRetencao = new bool[] {false} ;
         T00143_A89DocOperadorCompartilhamento = new bool[] {false} ;
         T00143_A90DocOperadorEliminacao = new bool[] {false} ;
         T00143_A91DocOperadorProcessamento = new bool[] {false} ;
         T00143_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00143_A75DocumentoId = new int[1] ;
         T00143_A42OperadorId = new int[1] ;
         T001410_A86DocOperadorId = new int[1] ;
         T001411_A86DocOperadorId = new int[1] ;
         T00142_A86DocOperadorId = new int[1] ;
         T00142_A87DocOperadorColeta = new bool[] {false} ;
         T00142_A88DocOperadorRetencao = new bool[] {false} ;
         T00142_A89DocOperadorCompartilhamento = new bool[] {false} ;
         T00142_A90DocOperadorEliminacao = new bool[] {false} ;
         T00142_A91DocOperadorProcessamento = new bool[] {false} ;
         T00142_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         T00142_A75DocumentoId = new int[1] ;
         T00142_A42OperadorId = new int[1] ;
         T001412_A86DocOperadorId = new int[1] ;
         T001415_A86DocOperadorId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i92DocOperadorDataInclusao = DateTime.MinValue;
         sCtrlGx_mode = "";
         sCtrlAV7DocOperadorId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001416_A42OperadorId = new int[1] ;
         T001416_A43OperadorNome = new string[] {""} ;
         T001416_A44OperadorAtivo = new bool[] {false} ;
         T001417_A42OperadorId = new int[1] ;
         T001418_A75DocumentoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docoperador__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperador__default(),
            new Object[][] {
                new Object[] {
               T00142_A86DocOperadorId, T00142_A87DocOperadorColeta, T00142_A88DocOperadorRetencao, T00142_A89DocOperadorCompartilhamento, T00142_A90DocOperadorEliminacao, T00142_A91DocOperadorProcessamento, T00142_A92DocOperadorDataInclusao, T00142_A75DocumentoId, T00142_A42OperadorId
               }
               , new Object[] {
               T00143_A86DocOperadorId, T00143_A87DocOperadorColeta, T00143_A88DocOperadorRetencao, T00143_A89DocOperadorCompartilhamento, T00143_A90DocOperadorEliminacao, T00143_A91DocOperadorProcessamento, T00143_A92DocOperadorDataInclusao, T00143_A75DocumentoId, T00143_A42OperadorId
               }
               , new Object[] {
               T00144_A75DocumentoId
               }
               , new Object[] {
               T00145_A42OperadorId
               }
               , new Object[] {
               T00146_A86DocOperadorId, T00146_A87DocOperadorColeta, T00146_A88DocOperadorRetencao, T00146_A89DocOperadorCompartilhamento, T00146_A90DocOperadorEliminacao, T00146_A91DocOperadorProcessamento, T00146_A92DocOperadorDataInclusao, T00146_A75DocumentoId, T00146_A42OperadorId
               }
               , new Object[] {
               T00147_A75DocumentoId
               }
               , new Object[] {
               T00148_A42OperadorId
               }
               , new Object[] {
               T00149_A86DocOperadorId
               }
               , new Object[] {
               T001410_A86DocOperadorId
               }
               , new Object[] {
               T001411_A86DocOperadorId
               }
               , new Object[] {
               T001412_A86DocOperadorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001415_A86DocOperadorId
               }
               , new Object[] {
               T001416_A42OperadorId, T001416_A43OperadorNome, T001416_A44OperadorAtivo
               }
               , new Object[] {
               T001417_A42OperadorId
               }
               , new Object[] {
               T001418_A75DocumentoId
               }
            }
         );
         WebComp_Wcdocoperadorgrid = new GeneXus.Http.GXNullWebComponent();
         AV37Pgmname = "DocOperador";
         Z92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         A92DocOperadorDataInclusao = DateTimeUtil.Today( context);
         i92DocOperadorDataInclusao = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short nDynComponent ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short Gx_BScreen ;
      private short RcdFound47 ;
      private short nCmpId ;
      private short GX_JID ;
      private short nIsDirty_47 ;
      private int wcpOAV7DocOperadorId ;
      private int Z86DocOperadorId ;
      private int Z75DocumentoId ;
      private int Z42OperadorId ;
      private int N75DocumentoId ;
      private int N42OperadorId ;
      private int AV7DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int trnEnded ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int A86DocOperadorId ;
      private int edtDocOperadorId_Enabled ;
      private int edtDocOperadorId_Visible ;
      private int edtDocumentoId_Visible ;
      private int edtDocumentoId_Enabled ;
      private int edtDocOperadorDataInclusao_Visible ;
      private int edtDocOperadorDataInclusao_Enabled ;
      private int AV13Insert_DocumentoId ;
      private int AV14Insert_OperadorId ;
      private int AV38GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string dynOperadorId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string tblUnnamedtable1_Internalname ;
      private string lblOperadortextblock_Internalname ;
      private string lblOperadortextblock_Jsonclick ;
      private string divTableoperadoroptions_Internalname ;
      private string tblTablemergeddocoperadorchecky_Internalname ;
      private string chkavDocoperadorchecky_Internalname ;
      private string TempTags ;
      private string lblDocoperadorchecky_righttext_Internalname ;
      private string lblDocoperadorchecky_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorcheckn_Internalname ;
      private string chkavDocoperadorcheckn_Internalname ;
      private string lblDocoperadorcheckn_righttext_Internalname ;
      private string lblDocoperadorcheckn_righttext_Jsonclick ;
      private string dynOperadorId_Jsonclick ;
      private string divTabledadoscheck_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string tblTablemergeddocoperadorcoleta_Internalname ;
      private string chkDocOperadorColeta_Internalname ;
      private string lblDocoperadorcoleta_righttext_Internalname ;
      private string lblDocoperadorcoleta_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorretencao_Internalname ;
      private string chkDocOperadorRetencao_Internalname ;
      private string lblDocoperadorretencao_righttext_Internalname ;
      private string lblDocoperadorretencao_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorcompartilhamento_Internalname ;
      private string chkDocOperadorCompartilhamento_Internalname ;
      private string lblDocoperadorcompartilhamento_righttext_Internalname ;
      private string lblDocoperadorcompartilhamento_righttext_Jsonclick ;
      private string tblTablemergeddocoperadoreliminacao_Internalname ;
      private string chkDocOperadorEliminacao_Internalname ;
      private string lblDocoperadoreliminacao_righttext_Internalname ;
      private string lblDocoperadoreliminacao_righttext_Jsonclick ;
      private string tblTablemergeddocoperadorprocessamento_Internalname ;
      private string chkDocOperadorProcessamento_Internalname ;
      private string lblDocoperadorprocessamento_righttext_Internalname ;
      private string lblDocoperadorprocessamento_righttext_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string WebComp_Wcdocoperadorgrid_Component ;
      private string OldWcdocoperadorgrid ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDocOperadorId_Internalname ;
      private string edtDocOperadorId_Jsonclick ;
      private string edtDocumentoId_Internalname ;
      private string edtDocumentoId_Jsonclick ;
      private string edtDocOperadorDataInclusao_Internalname ;
      private string edtDocOperadorDataInclusao_Jsonclick ;
      private string AV37Pgmname ;
      private string hsh ;
      private string sMode47 ;
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
      private string sCtrlGx_mode ;
      private string sCtrlAV7DocOperadorId ;
      private string gxwrpcisep ;
      private DateTime Z92DocOperadorDataInclusao ;
      private DateTime A92DocOperadorDataInclusao ;
      private DateTime i92DocOperadorDataInclusao ;
      private bool Z87DocOperadorColeta ;
      private bool Z88DocOperadorRetencao ;
      private bool Z89DocOperadorCompartilhamento ;
      private bool Z90DocOperadorEliminacao ;
      private bool Z91DocOperadorProcessamento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool AV33DocOperadorCheckY ;
      private bool AV34DocOperadorCheckN ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool returnInSub ;
      private bool bDynCreated_Wcdocoperadorgrid ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private IGxSession AV12WebSession ;
      private GXWebComponent WebComp_Wcdocoperadorgrid ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
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
      private int[] T00146_A86DocOperadorId ;
      private bool[] T00146_A87DocOperadorColeta ;
      private bool[] T00146_A88DocOperadorRetencao ;
      private bool[] T00146_A89DocOperadorCompartilhamento ;
      private bool[] T00146_A90DocOperadorEliminacao ;
      private bool[] T00146_A91DocOperadorProcessamento ;
      private DateTime[] T00146_A92DocOperadorDataInclusao ;
      private int[] T00146_A75DocumentoId ;
      private int[] T00146_A42OperadorId ;
      private int[] T00144_A75DocumentoId ;
      private int[] T00145_A42OperadorId ;
      private int[] T00147_A75DocumentoId ;
      private int[] T00148_A42OperadorId ;
      private int[] T00149_A86DocOperadorId ;
      private int[] T00143_A86DocOperadorId ;
      private bool[] T00143_A87DocOperadorColeta ;
      private bool[] T00143_A88DocOperadorRetencao ;
      private bool[] T00143_A89DocOperadorCompartilhamento ;
      private bool[] T00143_A90DocOperadorEliminacao ;
      private bool[] T00143_A91DocOperadorProcessamento ;
      private DateTime[] T00143_A92DocOperadorDataInclusao ;
      private int[] T00143_A75DocumentoId ;
      private int[] T00143_A42OperadorId ;
      private int[] T001410_A86DocOperadorId ;
      private int[] T001411_A86DocOperadorId ;
      private int[] T00142_A86DocOperadorId ;
      private bool[] T00142_A87DocOperadorColeta ;
      private bool[] T00142_A88DocOperadorRetencao ;
      private bool[] T00142_A89DocOperadorCompartilhamento ;
      private bool[] T00142_A90DocOperadorEliminacao ;
      private bool[] T00142_A91DocOperadorProcessamento ;
      private DateTime[] T00142_A92DocOperadorDataInclusao ;
      private int[] T00142_A75DocumentoId ;
      private int[] T00142_A42OperadorId ;
      private int[] T001412_A86DocOperadorId ;
      private int[] T001415_A86DocOperadorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] T001416_A42OperadorId ;
      private string[] T001416_A43OperadorNome ;
      private bool[] T001416_A44OperadorAtivo ;
      private int[] T001417_A42OperadorId ;
      private int[] T001418_A75DocumentoId ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
   }

   public class docoperador__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docoperador__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00146;
        prmT00146 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT00144;
        prmT00144 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00145;
        prmT00145 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmT00147;
        prmT00147 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmT00148;
        prmT00148 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmT00149;
        prmT00149 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT00143;
        prmT00143 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001410;
        prmT001410 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001411;
        prmT001411 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT00142;
        prmT00142 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001412;
        prmT001412 = new Object[] {
        new ParDef("@DocOperadorColeta",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorRetencao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorCompartilhamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorEliminacao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorProcessamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001413;
        prmT001413 = new Object[] {
        new ParDef("@DocOperadorColeta",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorRetencao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorCompartilhamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorEliminacao",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorProcessamento",GXType.Boolean,4,0) ,
        new ParDef("@DocOperadorDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@OperadorId",GXType.Int32,8,0) ,
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001414;
        prmT001414 = new Object[] {
        new ParDef("@DocOperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001415;
        prmT001415 = new Object[] {
        };
        Object[] prmT001416;
        prmT001416 = new Object[] {
        };
        Object[] prmT001417;
        prmT001417 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmT001418;
        prmT001418 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00142", "SELECT [DocOperadorId], [DocOperadorColeta], [DocOperadorRetencao], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorDataInclusao], [DocumentoId], [OperadorId] FROM [DocOperador] WITH (UPDLOCK) WHERE [DocOperadorId] = @DocOperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00143", "SELECT [DocOperadorId], [DocOperadorColeta], [DocOperadorRetencao], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorDataInclusao], [DocumentoId], [OperadorId] FROM [DocOperador] WHERE [DocOperadorId] = @DocOperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00144", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00145", "SELECT [OperadorId] FROM [Operador] WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00146", "SELECT TM1.[DocOperadorId], TM1.[DocOperadorColeta], TM1.[DocOperadorRetencao], TM1.[DocOperadorCompartilhamento], TM1.[DocOperadorEliminacao], TM1.[DocOperadorProcessamento], TM1.[DocOperadorDataInclusao], TM1.[DocumentoId], TM1.[OperadorId] FROM [DocOperador] TM1 WHERE TM1.[DocOperadorId] = @DocOperadorId ORDER BY TM1.[DocOperadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00146,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00147", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00147,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00148", "SELECT [OperadorId] FROM [Operador] WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00148,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00149", "SELECT [DocOperadorId] FROM [DocOperador] WHERE [DocOperadorId] = @DocOperadorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00149,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001410", "SELECT TOP 1 [DocOperadorId] FROM [DocOperador] WHERE ( [DocOperadorId] > @DocOperadorId) ORDER BY [DocOperadorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001410,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001411", "SELECT TOP 1 [DocOperadorId] FROM [DocOperador] WHERE ( [DocOperadorId] < @DocOperadorId) ORDER BY [DocOperadorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001411,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001412", "INSERT INTO [DocOperador]([DocOperadorColeta], [DocOperadorRetencao], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorDataInclusao], [DocumentoId], [OperadorId]) VALUES(@DocOperadorColeta, @DocOperadorRetencao, @DocOperadorCompartilhamento, @DocOperadorEliminacao, @DocOperadorProcessamento, @DocOperadorDataInclusao, @DocumentoId, @OperadorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001412,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001413", "UPDATE [DocOperador] SET [DocOperadorColeta]=@DocOperadorColeta, [DocOperadorRetencao]=@DocOperadorRetencao, [DocOperadorCompartilhamento]=@DocOperadorCompartilhamento, [DocOperadorEliminacao]=@DocOperadorEliminacao, [DocOperadorProcessamento]=@DocOperadorProcessamento, [DocOperadorDataInclusao]=@DocOperadorDataInclusao, [DocumentoId]=@DocumentoId, [OperadorId]=@OperadorId  WHERE [DocOperadorId] = @DocOperadorId", GxErrorMask.GX_NOMASK,prmT001413)
           ,new CursorDef("T001414", "DELETE FROM [DocOperador]  WHERE [DocOperadorId] = @DocOperadorId", GxErrorMask.GX_NOMASK,prmT001414)
           ,new CursorDef("T001415", "SELECT [DocOperadorId] FROM [DocOperador] ORDER BY [DocOperadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001415,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001416", "SELECT [OperadorId], [OperadorNome], [OperadorAtivo] FROM [Operador] WHERE [OperadorAtivo] = 1 ORDER BY [OperadorNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001416,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001417", "SELECT [OperadorId] FROM [Operador] WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001418", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001418,1, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
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
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
