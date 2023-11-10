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
   public class docenvolvidoscoletaexclui : GXProcedure
   {
      public docenvolvidoscoletaexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docenvolvidoscoletaexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           int aP1_EnvolvidosColetaId )
      {
         this.A75DocumentoId = aP0_DocumentoId;
         this.A54EnvolvidosColetaId = aP1_EnvolvidosColetaId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 int aP1_EnvolvidosColetaId )
      {
         docenvolvidoscoletaexclui objdocenvolvidoscoletaexclui;
         objdocenvolvidoscoletaexclui = new docenvolvidoscoletaexclui();
         objdocenvolvidoscoletaexclui.A75DocumentoId = aP0_DocumentoId;
         objdocenvolvidoscoletaexclui.A54EnvolvidosColetaId = aP1_EnvolvidosColetaId;
         objdocenvolvidoscoletaexclui.context.SetSubmitInitialConfig(context);
         objdocenvolvidoscoletaexclui.initialize();
         Submit( executePrivateCatch,objdocenvolvidoscoletaexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docenvolvidoscoletaexclui)stateInfo).executePrivate();
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
         /* Optimized DELETE. */
         /* Using cursor P005O2 */
         pr_default.execute(0, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DocEnvolvidosColeta");
         /* End optimized DELETE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("docenvolvidoscoletaexclui",pr_default);
         CloseOpenCursors();
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docenvolvidoscoletaexclui__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A75DocumentoId ;
      private int A54EnvolvidosColetaId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class docenvolvidoscoletaexclui__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005O2;
          prmP005O2 = new Object[] {
          new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005O2", "DELETE FROM [DocEnvolvidosColeta]  WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId and [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005O2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
