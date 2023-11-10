using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class revisaologconversion : GXProcedure
   {
      public revisaologconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaologconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         revisaologconversion objrevisaologconversion;
         objrevisaologconversion = new revisaologconversion();
         objrevisaologconversion.context.SetSubmitInitialConfig(context);
         objrevisaologconversion.initialize();
         Submit( executePrivateCatch,objrevisaologconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((revisaologconversion)stateInfo).executePrivate();
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
         cmdBuffer=" SET IDENTITY_INSERT [GXA0055] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor REVISAOLOG2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = REVISAOLOG2_A75DocumentoId[0];
            A122RevisaoLogObservacao = REVISAOLOG2_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = REVISAOLOG2_A121RevisaoLogUsuarioAlteracao[0];
            A120RevisaoLogId = REVISAOLOG2_A120RevisaoLogId[0];
            A123RevisaoLogDataAlteracao = REVISAOLOG2_A123RevisaoLogDataAlteracao[0];
            A40000GXC1 = ( A123RevisaoLogDataAlteracao);
            /*
               INSERT RECORD ON TABLE GXA0055

            */
            AV2RevisaoLogId = A120RevisaoLogId;
            AV3RevisaoLogUsuarioAlteracao = A121RevisaoLogUsuarioAlteracao;
            AV4RevisaoLogObservacao = A122RevisaoLogObservacao;
            AV5RevisaoLogDataAlteracao = A40000GXC1;
            AV6DocumentoId = A75DocumentoId;
            /* Using cursor REVISAOLOG3 */
            pr_default.execute(1, new Object[] {AV2RevisaoLogId, AV3RevisaoLogUsuarioAlteracao, AV4RevisaoLogObservacao, AV5RevisaoLogDataAlteracao, AV6DocumentoId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0055");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT [GXA0055] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
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
         cmdBuffer = "";
         scmdbuf = "";
         REVISAOLOG2_A75DocumentoId = new int[1] ;
         REVISAOLOG2_A122RevisaoLogObservacao = new string[] {""} ;
         REVISAOLOG2_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         REVISAOLOG2_A120RevisaoLogId = new int[1] ;
         REVISAOLOG2_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         A122RevisaoLogObservacao = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A123RevisaoLogDataAlteracao = DateTime.MinValue;
         A40000GXC1 = (DateTime)(DateTime.MinValue);
         AV3RevisaoLogUsuarioAlteracao = "";
         AV4RevisaoLogObservacao = "";
         AV5RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaologconversion__default(),
            new Object[][] {
                new Object[] {
               REVISAOLOG2_A75DocumentoId, REVISAOLOG2_A122RevisaoLogObservacao, REVISAOLOG2_A121RevisaoLogUsuarioAlteracao, REVISAOLOG2_A120RevisaoLogId, REVISAOLOG2_A123RevisaoLogDataAlteracao
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A75DocumentoId ;
      private int A120RevisaoLogId ;
      private int GIGXA0055 ;
      private int AV2RevisaoLogId ;
      private int AV6DocumentoId ;
      private string cmdBuffer ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A40000GXC1 ;
      private DateTime AV5RevisaoLogDataAlteracao ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private string A122RevisaoLogObservacao ;
      private string AV4RevisaoLogObservacao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string AV3RevisaoLogUsuarioAlteracao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private int[] REVISAOLOG2_A75DocumentoId ;
      private string[] REVISAOLOG2_A122RevisaoLogObservacao ;
      private string[] REVISAOLOG2_A121RevisaoLogUsuarioAlteracao ;
      private int[] REVISAOLOG2_A120RevisaoLogId ;
      private DateTime[] REVISAOLOG2_A123RevisaoLogDataAlteracao ;
   }

   public class revisaologconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmREVISAOLOG2;
          prmREVISAOLOG2 = new Object[] {
          };
          Object[] prmREVISAOLOG3;
          prmREVISAOLOG3 = new Object[] {
          new ParDef("@AV2RevisaoLogId",GXType.Int32,8,0) ,
          new ParDef("@AV3RevisaoLogUsuarioAlteracao",GXType.VarChar,100,0) ,
          new ParDef("@AV4RevisaoLogObservacao",GXType.VarChar,2097152,0) ,
          new ParDef("@AV5RevisaoLogDataAlteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV6DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("REVISAOLOG2", "SELECT [DocumentoId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao], [RevisaoLogId], [RevisaoLogDataAlteracao] FROM [RevisaoLog] ORDER BY [RevisaoLogId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmREVISAOLOG2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("REVISAOLOG3", "INSERT INTO [GXA0055]([RevisaoLogId], [RevisaoLogUsuarioAlteracao], [RevisaoLogObservacao], [RevisaoLogDataAlteracao], [DocumentoId]) VALUES(@AV2RevisaoLogId, @AV3RevisaoLogUsuarioAlteracao, @AV4RevisaoLogObservacao, @AV5RevisaoLogDataAlteracao, @AV6DocumentoId)", GxErrorMask.GX_NOMASK,prmREVISAOLOG3)
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
