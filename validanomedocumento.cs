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
   public class validanomedocumento : GXProcedure
   {
      public validanomedocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public validanomedocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocumentoNome ,
                           int aP1_DocumentoId ,
                           string aP2_Gx_mode ,
                           out bool aP3_IsRepetido )
      {
         this.AV8DocumentoNome = aP0_DocumentoNome;
         this.AV10DocumentoId = aP1_DocumentoId;
         this.Gx_mode = aP2_Gx_mode;
         this.AV9IsRepetido = false ;
         initialize();
         executePrivate();
         aP3_IsRepetido=this.AV9IsRepetido;
      }

      public bool executeUdp( string aP0_DocumentoNome ,
                              int aP1_DocumentoId ,
                              string aP2_Gx_mode )
      {
         execute(aP0_DocumentoNome, aP1_DocumentoId, aP2_Gx_mode, out aP3_IsRepetido);
         return AV9IsRepetido ;
      }

      public void executeSubmit( string aP0_DocumentoNome ,
                                 int aP1_DocumentoId ,
                                 string aP2_Gx_mode ,
                                 out bool aP3_IsRepetido )
      {
         validanomedocumento objvalidanomedocumento;
         objvalidanomedocumento = new validanomedocumento();
         objvalidanomedocumento.AV8DocumentoNome = aP0_DocumentoNome;
         objvalidanomedocumento.AV10DocumentoId = aP1_DocumentoId;
         objvalidanomedocumento.Gx_mode = aP2_Gx_mode;
         objvalidanomedocumento.AV9IsRepetido = false ;
         objvalidanomedocumento.context.SetSubmitInitialConfig(context);
         objvalidanomedocumento.initialize();
         Submit( executePrivateCatch,objvalidanomedocumento);
         aP3_IsRepetido=this.AV9IsRepetido;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((validanomedocumento)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            /* Using cursor P006Z2 */
            pr_default.execute(0, new Object[] {AV8DocumentoNome});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A76DocumentoNome = P006Z2_A76DocumentoNome[0];
               n76DocumentoNome = P006Z2_n76DocumentoNome[0];
               A75DocumentoId = P006Z2_A75DocumentoId[0];
               AV9IsRepetido = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P006Z3 */
            pr_default.execute(1, new Object[] {AV8DocumentoNome, AV10DocumentoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A76DocumentoNome = P006Z3_A76DocumentoNome[0];
               n76DocumentoNome = P006Z3_n76DocumentoNome[0];
               A75DocumentoId = P006Z3_A75DocumentoId[0];
               AV9IsRepetido = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
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
         P006Z2_A76DocumentoNome = new string[] {""} ;
         P006Z2_n76DocumentoNome = new bool[] {false} ;
         P006Z2_A75DocumentoId = new int[1] ;
         A76DocumentoNome = "";
         P006Z3_A76DocumentoNome = new string[] {""} ;
         P006Z3_n76DocumentoNome = new bool[] {false} ;
         P006Z3_A75DocumentoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.validanomedocumento__default(),
            new Object[][] {
                new Object[] {
               P006Z2_A76DocumentoNome, P006Z2_n76DocumentoNome, P006Z2_A75DocumentoId
               }
               , new Object[] {
               P006Z3_A76DocumentoNome, P006Z3_n76DocumentoNome, P006Z3_A75DocumentoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10DocumentoId ;
      private int A75DocumentoId ;
      private string Gx_mode ;
      private string scmdbuf ;
      private bool AV9IsRepetido ;
      private bool n76DocumentoNome ;
      private string AV8DocumentoNome ;
      private string A76DocumentoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006Z2_A76DocumentoNome ;
      private bool[] P006Z2_n76DocumentoNome ;
      private int[] P006Z2_A75DocumentoId ;
      private string[] P006Z3_A76DocumentoNome ;
      private bool[] P006Z3_n76DocumentoNome ;
      private int[] P006Z3_A75DocumentoId ;
      private bool aP3_IsRepetido ;
   }

   public class validanomedocumento__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006Z2;
          prmP006Z2 = new Object[] {
          new ParDef("@AV8DocumentoNome",GXType.NVarChar,100,0)
          };
          Object[] prmP006Z3;
          prmP006Z3 = new Object[] {
          new ParDef("@AV8DocumentoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV10DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Z2", "SELECT TOP 1 [DocumentoNome], [DocumentoId] FROM [Documento] WHERE [DocumentoNome] = @AV8DocumentoNome ORDER BY [DocumentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Z3", "SELECT TOP 1 [DocumentoNome], [DocumentoId] FROM [Documento] WHERE ([DocumentoNome] = @AV8DocumentoNome) AND ([DocumentoId] <> @AV10DocumentoId) ORDER BY [DocumentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
