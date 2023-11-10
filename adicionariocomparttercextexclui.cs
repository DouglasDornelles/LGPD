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
   public class adicionariocomparttercextexclui : GXProcedure
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

      public adicionariocomparttercextexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public adicionariocomparttercextexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocDicionarioId ,
                           int aP1_CompartTercExternoId )
      {
         this.A98DocDicionarioId = aP0_DocDicionarioId;
         this.A66CompartTercExternoId = aP1_CompartTercExternoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocDicionarioId ,
                                 int aP1_CompartTercExternoId )
      {
         adicionariocomparttercextexclui objadicionariocomparttercextexclui;
         objadicionariocomparttercextexclui = new adicionariocomparttercextexclui();
         objadicionariocomparttercextexclui.A98DocDicionarioId = aP0_DocDicionarioId;
         objadicionariocomparttercextexclui.A66CompartTercExternoId = aP1_CompartTercExternoId;
         objadicionariocomparttercextexclui.context.SetSubmitInitialConfig(context);
         objadicionariocomparttercextexclui.initialize();
         Submit( executePrivateCatch,objadicionariocomparttercextexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adicionariocomparttercextexclui)stateInfo).executePrivate();
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
         /* Using cursor P005U2 */
         pr_default.execute(0, new Object[] {A66CompartTercExternoId, A98DocDicionarioId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DicionarioCompartTercExt");
         /* End optimized DELETE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("dicionariocomparttercextexclui",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adicionariocomparttercextexclui__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A98DocDicionarioId ;
      private int A66CompartTercExternoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class adicionariocomparttercextexclui__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005U2;
          prmP005U2 = new Object[] {
          new ParDef("@CompartTercExternoId",GXType.Int32,8,0) ,
          new ParDef("@DocDicionarioId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005U2", "DELETE FROM [DicionarioCompartTercExt]  WHERE [CompartTercExternoId] = @CompartTercExternoId and [DocDicionarioId] = @DocDicionarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005U2)
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
