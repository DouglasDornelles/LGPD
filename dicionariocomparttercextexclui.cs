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
   public class dicionariocomparttercextexclui : GXProcedure
   {
      public dicionariocomparttercextexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public dicionariocomparttercextexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocDicionarioId ,
                           int aP1_CompartTercExternoId )
      {
         this.AV2DocDicionarioId = aP0_DocDicionarioId;
         this.AV3CompartTercExternoId = aP1_CompartTercExternoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocDicionarioId ,
                                 int aP1_CompartTercExternoId )
      {
         dicionariocomparttercextexclui objdicionariocomparttercextexclui;
         objdicionariocomparttercextexclui = new dicionariocomparttercextexclui();
         objdicionariocomparttercextexclui.AV2DocDicionarioId = aP0_DocDicionarioId;
         objdicionariocomparttercextexclui.AV3CompartTercExternoId = aP1_CompartTercExternoId;
         objdicionariocomparttercextexclui.context.SetSubmitInitialConfig(context);
         objdicionariocomparttercextexclui.initialize();
         Submit( executePrivateCatch,objdicionariocomparttercextexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariocomparttercextexclui)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2DocDicionarioId,(int)AV3CompartTercExternoId} ;
         ClassLoader.Execute("adicionariocomparttercextexclui","GeneXus.Programs","adicionariocomparttercextexclui", new Object[] {context }, "execute", args);
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

      private int AV2DocDicionarioId ;
      private int AV3CompartTercExternoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
