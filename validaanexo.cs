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
   public class validaanexo : GXProcedure
   {
      public validaanexo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public validaanexo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           string aP1_DocAnexoDescricao ,
                           out bool aP2_descricaocadastrada )
      {
         this.AV8DocumentoId = aP0_DocumentoId;
         this.AV9DocAnexoDescricao = aP1_DocAnexoDescricao;
         this.AV11descricaocadastrada = false ;
         initialize();
         executePrivate();
         aP2_descricaocadastrada=this.AV11descricaocadastrada;
      }

      public bool executeUdp( int aP0_DocumentoId ,
                              string aP1_DocAnexoDescricao )
      {
         execute(aP0_DocumentoId, aP1_DocAnexoDescricao, out aP2_descricaocadastrada);
         return AV11descricaocadastrada ;
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 string aP1_DocAnexoDescricao ,
                                 out bool aP2_descricaocadastrada )
      {
         validaanexo objvalidaanexo;
         objvalidaanexo = new validaanexo();
         objvalidaanexo.AV8DocumentoId = aP0_DocumentoId;
         objvalidaanexo.AV9DocAnexoDescricao = aP1_DocAnexoDescricao;
         objvalidaanexo.AV11descricaocadastrada = false ;
         objvalidaanexo.context.SetSubmitInitialConfig(context);
         objvalidaanexo.initialize();
         Submit( executePrivateCatch,objvalidaanexo);
         aP2_descricaocadastrada=this.AV11descricaocadastrada;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((validaanexo)stateInfo).executePrivate();
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
         /* Using cursor P005X2 */
         pr_default.execute(0, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P005X2_A75DocumentoId[0];
            A94DocAnexoDescricao = P005X2_A94DocAnexoDescricao[0];
            A93DocAnexoId = P005X2_A93DocAnexoId[0];
            if ( StringUtil.StrCmp(A94DocAnexoDescricao, AV9DocAnexoDescricao) == 0 )
            {
               AV11descricaocadastrada = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            else
            {
               AV11descricaocadastrada = false;
            }
            pr_default.readNext(0);
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
         scmdbuf = "";
         P005X2_A75DocumentoId = new int[1] ;
         P005X2_A94DocAnexoDescricao = new string[] {""} ;
         P005X2_A93DocAnexoId = new int[1] ;
         A94DocAnexoDescricao = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.validaanexo__default(),
            new Object[][] {
                new Object[] {
               P005X2_A75DocumentoId, P005X2_A94DocAnexoDescricao, P005X2_A93DocAnexoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8DocumentoId ;
      private int A75DocumentoId ;
      private int A93DocAnexoId ;
      private string scmdbuf ;
      private bool AV11descricaocadastrada ;
      private string AV9DocAnexoDescricao ;
      private string A94DocAnexoDescricao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005X2_A75DocumentoId ;
      private string[] P005X2_A94DocAnexoDescricao ;
      private int[] P005X2_A93DocAnexoId ;
      private bool aP2_descricaocadastrada ;
   }

   public class validaanexo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "SELECT [DocumentoId], [DocAnexoDescricao], [DocAnexoId] FROM [DocAnexo] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
