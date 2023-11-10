using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class doccompartinternoexclui : GXProcedure
   {
      public doccompartinternoexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public doccompartinternoexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           int aP1_CompartInternoId )
      {
         this.AV2DocumentoId = aP0_DocumentoId;
         this.AV3CompartInternoId = aP1_CompartInternoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 int aP1_CompartInternoId )
      {
         doccompartinternoexclui objdoccompartinternoexclui;
         objdoccompartinternoexclui = new doccompartinternoexclui();
         objdoccompartinternoexclui.AV2DocumentoId = aP0_DocumentoId;
         objdoccompartinternoexclui.AV3CompartInternoId = aP1_CompartInternoId;
         objdoccompartinternoexclui.context.SetSubmitInitialConfig(context);
         objdoccompartinternoexclui.initialize();
         Submit( executePrivateCatch,objdoccompartinternoexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((doccompartinternoexclui)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2DocumentoId,(int)AV3CompartInternoId} ;
         ClassLoader.Execute("adoccompartinternoexclui","GeneXus.Programs","adoccompartinternoexclui", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV2DocumentoId ;
      private int AV3CompartInternoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
