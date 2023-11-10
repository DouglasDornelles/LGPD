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
   public class docenvolvidoscoletainsere : GXProcedure
   {
      public docenvolvidoscoletainsere( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docenvolvidoscoletainsere( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           int aP1_EnvolvidosColetaId_Item )
      {
         this.AV8DocumentoId = aP0_DocumentoId;
         this.AV9EnvolvidosColetaId_Item = aP1_EnvolvidosColetaId_Item;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 int aP1_EnvolvidosColetaId_Item )
      {
         docenvolvidoscoletainsere objdocenvolvidoscoletainsere;
         objdocenvolvidoscoletainsere = new docenvolvidoscoletainsere();
         objdocenvolvidoscoletainsere.AV8DocumentoId = aP0_DocumentoId;
         objdocenvolvidoscoletainsere.AV9EnvolvidosColetaId_Item = aP1_EnvolvidosColetaId_Item;
         objdocenvolvidoscoletainsere.context.SetSubmitInitialConfig(context);
         objdocenvolvidoscoletainsere.initialize();
         Submit( executePrivateCatch,objdocenvolvidoscoletainsere);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docenvolvidoscoletainsere)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE DocEnvolvidosColeta

         */
         A75DocumentoId = AV8DocumentoId;
         A54EnvolvidosColetaId = AV9EnvolvidosColetaId_Item;
         /* Using cursor P005N2 */
         pr_default.execute(0, new Object[] {A54EnvolvidosColetaId, A75DocumentoId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DocEnvolvidosColeta");
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
         context.CommitDataStores("docenvolvidoscoletainsere",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docenvolvidoscoletainsere__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8DocumentoId ;
      private int AV9EnvolvidosColetaId_Item ;
      private int GX_INS48 ;
      private int A75DocumentoId ;
      private int A54EnvolvidosColetaId ;
      private string Gx_emsg ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class docenvolvidoscoletainsere__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005N2;
          prmP005N2 = new Object[] {
          new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005N2", "INSERT INTO [DocEnvolvidosColeta]([EnvolvidosColetaId], [DocumentoId]) VALUES(@EnvolvidosColetaId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmP005N2)
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
