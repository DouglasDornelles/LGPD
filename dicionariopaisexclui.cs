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
   public class dicionariopaisexclui : GXProcedure
   {
      public dicionariopaisexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariopaisexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocDicionarioId ,
                           int aP1_PaisId )
      {
         this.A98DocDicionarioId = aP0_DocDicionarioId;
         this.A4PaisId = aP1_PaisId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocDicionarioId ,
                                 int aP1_PaisId )
      {
         dicionariopaisexclui objdicionariopaisexclui;
         objdicionariopaisexclui = new dicionariopaisexclui();
         objdicionariopaisexclui.A98DocDicionarioId = aP0_DocDicionarioId;
         objdicionariopaisexclui.A4PaisId = aP1_PaisId;
         objdicionariopaisexclui.context.SetSubmitInitialConfig(context);
         objdicionariopaisexclui.initialize();
         Submit( executePrivateCatch,objdicionariopaisexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariopaisexclui)stateInfo).executePrivate();
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
         /* Using cursor P007F2 */
         pr_default.execute(0, new Object[] {A4PaisId, A98DocDicionarioId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DicionarioPais");
         /* End optimized DELETE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("dicionariopaisexclui",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariopaisexclui__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A98DocDicionarioId ;
      private int A4PaisId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class dicionariopaisexclui__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007F2;
          prmP007F2 = new Object[] {
          new ParDef("@PaisId",GXType.Int32,8,0) ,
          new ParDef("@DocDicionarioId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007F2", "DELETE FROM [DicionarioPais]  WHERE [PaisId] = @PaisId and [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007F2)
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
