using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class adownloadarquivo : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
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
            return "downloadarquivo_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "adownloadarquivo.aspx")), "adownloadarquivo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "adownloadarquivo.aspx")))) ;
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
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ContentType");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9ContentType = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13FilePath = GetPar( "FilePath");
                  AV8Nome = GetPar( "Nome");
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public adownloadarquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public adownloadarquivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ContentType ,
                           string aP1_FilePath ,
                           string aP2_Nome )
      {
         this.AV9ContentType = aP0_ContentType;
         this.AV13FilePath = aP1_FilePath;
         this.AV8Nome = aP2_Nome;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ContentType ,
                                 string aP1_FilePath ,
                                 string aP2_Nome )
      {
         adownloadarquivo objadownloadarquivo;
         objadownloadarquivo = new adownloadarquivo();
         objadownloadarquivo.AV9ContentType = aP0_ContentType;
         objadownloadarquivo.AV13FilePath = aP1_FilePath;
         objadownloadarquivo.AV8Nome = aP2_Nome;
         objadownloadarquivo.context.SetSubmitInitialConfig(context);
         objadownloadarquivo.initialize();
         Submit( executePrivateCatch,objadownloadarquivo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adownloadarquivo)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV11HttpResponse.AppendHeader("Content-Type", AV9ContentType);
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV11HttpResponse.AppendHeader("Content-Disposition", "attachment;filename="+AV8Nome);
         }
         AV11HttpResponse.AddFile(AV13FilePath);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV11HttpResponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV9ContentType ;
      private string AV13FilePath ;
      private string AV8Nome ;
      private GxHttpResponse AV11HttpResponse ;
   }

}
