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
   public class documentorelatoriopdf : GXProcedure
   {
      public documentorelatoriopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public documentorelatoriopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId )
      {
         this.AV2DocumentoId = aP0_DocumentoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId )
      {
         documentorelatoriopdf objdocumentorelatoriopdf;
         objdocumentorelatoriopdf = new documentorelatoriopdf();
         objdocumentorelatoriopdf.AV2DocumentoId = aP0_DocumentoId;
         objdocumentorelatoriopdf.context.SetSubmitInitialConfig(context);
         objdocumentorelatoriopdf.initialize();
         Submit( executePrivateCatch,objdocumentorelatoriopdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentorelatoriopdf)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2DocumentoId} ;
         ClassLoader.Execute("adocumentorelatoriopdf","GeneXus.Programs","adocumentorelatoriopdf", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
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
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
