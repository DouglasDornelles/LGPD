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
   public class dicionariopaisinsere : GXProcedure
   {
      public dicionariopaisinsere( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariopaisinsere( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocDicionarioId ,
                           int aP1_PaisId_Item )
      {
         this.AV8DocDicionarioId = aP0_DocDicionarioId;
         this.AV9PaisId_Item = aP1_PaisId_Item;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocDicionarioId ,
                                 int aP1_PaisId_Item )
      {
         dicionariopaisinsere objdicionariopaisinsere;
         objdicionariopaisinsere = new dicionariopaisinsere();
         objdicionariopaisinsere.AV8DocDicionarioId = aP0_DocDicionarioId;
         objdicionariopaisinsere.AV9PaisId_Item = aP1_PaisId_Item;
         objdicionariopaisinsere.context.SetSubmitInitialConfig(context);
         objdicionariopaisinsere.initialize();
         Submit( executePrivateCatch,objdicionariopaisinsere);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariopaisinsere)stateInfo).executePrivate();
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
         /*
            INSERT RECORD ON TABLE DicionarioPais

         */
         A98DocDicionarioId = AV8DocDicionarioId;
         A4PaisId = AV9PaisId_Item;
         /* Using cursor P007E2 */
         pr_default.execute(0, new Object[] {A4PaisId, A98DocDicionarioId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DicionarioPais");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("dicionariopaisinsere",pr_default);
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
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariopaisinsere__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8DocDicionarioId ;
      private int AV9PaisId_Item ;
      private int GX_INS60 ;
      private int A98DocDicionarioId ;
      private int A4PaisId ;
      private string Gx_emsg ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class dicionariopaisinsere__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007E2;
          prmP007E2 = new Object[] {
          new ParDef("@PaisId",GXType.Int32,8,0) ,
          new ParDef("@DocDicionarioId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007E2", "INSERT INTO [DicionarioPais]([PaisId], [DocDicionarioId]) VALUES(@PaisId, @DocDicionarioId)", GxErrorMask.GX_NOMASK,prmP007E2)
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
