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
   public class docsetorinternoexclui : GXProcedure
   {
      public docsetorinternoexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docsetorinternoexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           int aP1_SetorInternoId )
      {
         this.A75DocumentoId = aP0_DocumentoId;
         this.A60SetorInternoId = aP1_SetorInternoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 int aP1_SetorInternoId )
      {
         docsetorinternoexclui objdocsetorinternoexclui;
         objdocsetorinternoexclui = new docsetorinternoexclui();
         objdocsetorinternoexclui.A75DocumentoId = aP0_DocumentoId;
         objdocsetorinternoexclui.A60SetorInternoId = aP1_SetorInternoId;
         objdocsetorinternoexclui.context.SetSubmitInitialConfig(context);
         objdocsetorinternoexclui.initialize();
         Submit( executePrivateCatch,objdocsetorinternoexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docsetorinternoexclui)stateInfo).executePrivate();
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
         /* Using cursor P005S2 */
         pr_default.execute(0, new Object[] {A60SetorInternoId, A75DocumentoId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DocSetorInterno");
         /* End optimized DELETE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("docsetorinternoexclui",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docsetorinternoexclui__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A75DocumentoId ;
      private int A60SetorInternoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class docsetorinternoexclui__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005S2;
          prmP005S2 = new Object[] {
          new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005S2", "DELETE FROM [DocSetorInterno]  WHERE [SetorInternoId] = @SetorInternoId and [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005S2)
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
