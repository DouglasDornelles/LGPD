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
   public class dicionariocomparttercextinsere : GXProcedure
   {
      public dicionariocomparttercextinsere( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariocomparttercextinsere( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocDicionarioId ,
                           short aP1_CompartTercExternoId_Item )
      {
         this.AV8DocDicionarioId = aP0_DocDicionarioId;
         this.AV9CompartTercExternoId_Item = aP1_CompartTercExternoId_Item;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocDicionarioId ,
                                 short aP1_CompartTercExternoId_Item )
      {
         dicionariocomparttercextinsere objdicionariocomparttercextinsere;
         objdicionariocomparttercextinsere = new dicionariocomparttercextinsere();
         objdicionariocomparttercextinsere.AV8DocDicionarioId = aP0_DocDicionarioId;
         objdicionariocomparttercextinsere.AV9CompartTercExternoId_Item = aP1_CompartTercExternoId_Item;
         objdicionariocomparttercextinsere.context.SetSubmitInitialConfig(context);
         objdicionariocomparttercextinsere.initialize();
         Submit( executePrivateCatch,objdicionariocomparttercextinsere);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariocomparttercextinsere)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE DicionarioCompartTercExt

         */
         A98DocDicionarioId = AV8DocDicionarioId;
         A66CompartTercExternoId = AV9CompartTercExternoId_Item;
         /* Using cursor P005T2 */
         pr_default.execute(0, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DicionarioCompartTercExt");
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
         context.CommitDataStores("dicionariocomparttercextinsere",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariocomparttercextinsere__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9CompartTercExternoId_Item ;
      private int AV8DocDicionarioId ;
      private int GX_INS54 ;
      private int A98DocDicionarioId ;
      private int A66CompartTercExternoId ;
      private string Gx_emsg ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class dicionariocomparttercextinsere__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005T2;
          prmP005T2 = new Object[] {
          new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
          new ParDef("@DocDicionarioId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005T2", "INSERT INTO [DicionarioCompartTercExt]([CompartTercExternoId], [DocDicionarioId]) VALUES(@CompartTercExternoId, @DocDicionarioId)", GxErrorMask.GX_NOMASK,prmP005T2)
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
