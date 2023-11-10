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
   public class recuperadocumentonome : GXProcedure
   {
      public recuperadocumentonome( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public recuperadocumentonome( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           out string aP1_DocumentoNome )
      {
         this.A75DocumentoId = aP0_DocumentoId;
         this.AV9DocumentoNome = "" ;
         initialize();
         executePrivate();
         aP1_DocumentoNome=this.AV9DocumentoNome;
      }

      public string executeUdp( int aP0_DocumentoId )
      {
         execute(aP0_DocumentoId, out aP1_DocumentoNome);
         return AV9DocumentoNome ;
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 out string aP1_DocumentoNome )
      {
         recuperadocumentonome objrecuperadocumentonome;
         objrecuperadocumentonome = new recuperadocumentonome();
         objrecuperadocumentonome.A75DocumentoId = aP0_DocumentoId;
         objrecuperadocumentonome.AV9DocumentoNome = "" ;
         objrecuperadocumentonome.context.SetSubmitInitialConfig(context);
         objrecuperadocumentonome.initialize();
         Submit( executePrivateCatch,objrecuperadocumentonome);
         aP1_DocumentoNome=this.AV9DocumentoNome;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((recuperadocumentonome)stateInfo).executePrivate();
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
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {A75DocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A76DocumentoNome = P00752_A76DocumentoNome[0];
            n76DocumentoNome = P00752_n76DocumentoNome[0];
            AV9DocumentoNome = A76DocumentoNome;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
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
         AV9DocumentoNome = "";
         scmdbuf = "";
         P00752_A75DocumentoId = new int[1] ;
         P00752_A76DocumentoNome = new string[] {""} ;
         P00752_n76DocumentoNome = new bool[] {false} ;
         A76DocumentoNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.recuperadocumentonome__default(),
            new Object[][] {
                new Object[] {
               P00752_A75DocumentoId, P00752_A76DocumentoNome, P00752_n76DocumentoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A75DocumentoId ;
      private string scmdbuf ;
      private bool n76DocumentoNome ;
      private string AV9DocumentoNome ;
      private string A76DocumentoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00752_A75DocumentoId ;
      private string[] P00752_A76DocumentoNome ;
      private bool[] P00752_n76DocumentoNome ;
      private string aP1_DocumentoNome ;
   }

   public class recuperadocumentonome__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("@DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "SELECT [DocumentoId], [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
