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
   public class docsetorinternoinsere : GXProcedure
   {
      public docsetorinternoinsere( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docsetorinternoinsere( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           short aP1_SetorInternoId_Item )
      {
         this.AV8DocumentoId = aP0_DocumentoId;
         this.AV9SetorInternoId_Item = aP1_SetorInternoId_Item;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 short aP1_SetorInternoId_Item )
      {
         docsetorinternoinsere objdocsetorinternoinsere;
         objdocsetorinternoinsere = new docsetorinternoinsere();
         objdocsetorinternoinsere.AV8DocumentoId = aP0_DocumentoId;
         objdocsetorinternoinsere.AV9SetorInternoId_Item = aP1_SetorInternoId_Item;
         objdocsetorinternoinsere.context.SetSubmitInitialConfig(context);
         objdocsetorinternoinsere.initialize();
         Submit( executePrivateCatch,objdocsetorinternoinsere);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docsetorinternoinsere)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE DocSetorInterno

         */
         A75DocumentoId = AV8DocumentoId;
         A60SetorInternoId = AV9SetorInternoId_Item;
         /* Using cursor P005R2 */
         pr_default.execute(0, new Object[] {A60SetorInternoId, A75DocumentoId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("DocSetorInterno");
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
         context.CommitDataStores("docsetorinternoinsere",pr_default);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docsetorinternoinsere__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9SetorInternoId_Item ;
      private int AV8DocumentoId ;
      private int GX_INS50 ;
      private int A75DocumentoId ;
      private int A60SetorInternoId ;
      private string Gx_emsg ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class docsetorinternoinsere__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005R2;
          prmP005R2 = new Object[] {
          new ParDef("@SetorInternoId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005R2", "INSERT INTO [DocSetorInterno]([SetorInternoId], [DocumentoId]) VALUES(@SetorInternoId, @DocumentoId)", GxErrorMask.GX_NOMASK,prmP005R2)
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
