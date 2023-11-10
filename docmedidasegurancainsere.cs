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
   public class docmedidasegurancainsere : GXProcedure
   {
      public docmedidasegurancainsere( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docmedidasegurancainsere( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           int aP1_MedidaSegurancaId_Item )
      {
         this.AV8DocumentoId = aP0_DocumentoId;
         this.AV9MedidaSegurancaId_Item = aP1_MedidaSegurancaId_Item;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 int aP1_MedidaSegurancaId_Item )
      {
         docmedidasegurancainsere objdocmedidasegurancainsere;
         objdocmedidasegurancainsere = new docmedidasegurancainsere();
         objdocmedidasegurancainsere.AV8DocumentoId = aP0_DocumentoId;
         objdocmedidasegurancainsere.AV9MedidaSegurancaId_Item = aP1_MedidaSegurancaId_Item;
         objdocmedidasegurancainsere.context.SetSubmitInitialConfig(context);
         objdocmedidasegurancainsere.initialize();
         Submit( executePrivateCatch,objdocmedidasegurancainsere);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docmedidasegurancainsere)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE DocMedidaSeguranca

         */
         A75DocumentoId = AV8DocumentoId;
         A51MedidaSegurancaId = AV9MedidaSegurancaId_Item;
         /* Using cursor P007A2 */
         pr_default.execute(0, new Object[] {A51MedidaSegurancaId, A75DocumentoId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DocMedidaSeguranca");
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
         context.CommitDataStores("docmedidasegurancainsere",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docmedidasegurancainsere__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8DocumentoId ;
      private int AV9MedidaSegurancaId_Item ;
      private int GX_INS59 ;
      private int A75DocumentoId ;
      private int A51MedidaSegurancaId ;
      private string Gx_emsg ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class docmedidasegurancainsere__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("@MedidaSegurancaId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "INSERT INTO [DocMedidaSeguranca]([MedidaSegurancaId], [DocumentoId]) VALUES(@MedidaSegurancaId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmP007A2)
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
