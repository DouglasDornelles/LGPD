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
   public class adoccompartinternoexclui : GXProcedure
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

      public adoccompartinternoexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public adoccompartinternoexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           int aP1_CompartInternoId )
      {
         this.A75DocumentoId = aP0_DocumentoId;
         this.A57CompartInternoId = aP1_CompartInternoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 int aP1_CompartInternoId )
      {
         adoccompartinternoexclui objadoccompartinternoexclui;
         objadoccompartinternoexclui = new adoccompartinternoexclui();
         objadoccompartinternoexclui.A75DocumentoId = aP0_DocumentoId;
         objadoccompartinternoexclui.A57CompartInternoId = aP1_CompartInternoId;
         objadoccompartinternoexclui.context.SetSubmitInitialConfig(context);
         objadoccompartinternoexclui.initialize();
         Submit( executePrivateCatch,objadoccompartinternoexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adoccompartinternoexclui)stateInfo).executePrivate();
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
         /* Using cursor P005L2 */
         pr_default.execute(0, new Object[] {A57CompartInternoId, A75DocumentoId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DocCompartInterno");
         /* End optimized DELETE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("doccompartinternoexclui",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adoccompartinternoexclui__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A75DocumentoId ;
      private int A57CompartInternoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class adoccompartinternoexclui__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005L2;
          prmP005L2 = new Object[] {
          new ParDef("@CompartInternoId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005L2", "DELETE FROM [DocCompartInterno]  WHERE [CompartInternoId] = @CompartInternoId and [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005L2)
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
