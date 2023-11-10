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
   public class downloadarquivo : GXProcedure
   {
      public downloadarquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public downloadarquivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ContentType ,
                           string aP1_FilePath ,
                           string aP2_Nome )
      {
         this.AV2ContentType = aP0_ContentType;
         this.AV3FilePath = aP1_FilePath;
         this.AV4Nome = aP2_Nome;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ContentType ,
                                 string aP1_FilePath ,
                                 string aP2_Nome )
      {
         downloadarquivo objdownloadarquivo;
         objdownloadarquivo = new downloadarquivo();
         objdownloadarquivo.AV2ContentType = aP0_ContentType;
         objdownloadarquivo.AV3FilePath = aP1_FilePath;
         objdownloadarquivo.AV4Nome = aP2_Nome;
         objdownloadarquivo.context.SetSubmitInitialConfig(context);
         objdownloadarquivo.initialize();
         Submit( executePrivateCatch,objdownloadarquivo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((downloadarquivo)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2ContentType,(string)AV3FilePath,(string)AV4Nome} ;
         ClassLoader.Execute("adownloadarquivo","GeneXus.Programs","adownloadarquivo", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
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

      private string AV2ContentType ;
      private string AV3FilePath ;
      private string AV4Nome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
