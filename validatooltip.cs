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
   public class validatooltip : GXProcedure
   {
      public validatooltip( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public validatooltip( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_TooltipId ,
                           int aP1_TelaId ,
                           int aP2_CampoId ,
                           out short aP3_tooltipexiste )
      {
         this.AV13TooltipId = aP0_TooltipId;
         this.AV15TelaId = aP1_TelaId;
         this.AV16CampoId = aP2_CampoId;
         this.AV11tooltipexiste = 0 ;
         initialize();
         executePrivate();
         aP3_tooltipexiste=this.AV11tooltipexiste;
      }

      public short executeUdp( int aP0_TooltipId ,
                               int aP1_TelaId ,
                               int aP2_CampoId )
      {
         execute(aP0_TooltipId, aP1_TelaId, aP2_CampoId, out aP3_tooltipexiste);
         return AV11tooltipexiste ;
      }

      public void executeSubmit( int aP0_TooltipId ,
                                 int aP1_TelaId ,
                                 int aP2_CampoId ,
                                 out short aP3_tooltipexiste )
      {
         validatooltip objvalidatooltip;
         objvalidatooltip = new validatooltip();
         objvalidatooltip.AV13TooltipId = aP0_TooltipId;
         objvalidatooltip.AV15TelaId = aP1_TelaId;
         objvalidatooltip.AV16CampoId = aP2_CampoId;
         objvalidatooltip.AV11tooltipexiste = 0 ;
         objvalidatooltip.context.SetSubmitInitialConfig(context);
         objvalidatooltip.initialize();
         Submit( executePrivateCatch,objvalidatooltip);
         aP3_tooltipexiste=this.AV11tooltipexiste;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((validatooltip)stateInfo).executePrivate();
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
         AV19GXLvl1 = 0;
         /* Using cursor P005K2 */
         pr_default.execute(0, new Object[] {AV16CampoId, AV15TelaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135CampoId = P005K2_A135CampoId[0];
            A139TooltipTelaId = P005K2_A139TooltipTelaId[0];
            A112TooltipId = P005K2_A112TooltipId[0];
            AV19GXLvl1 = 1;
            if ( A112TooltipId == AV13TooltipId )
            {
               AV11tooltipexiste = (short)(Convert.ToInt16(false));
            }
            else
            {
               AV11tooltipexiste = (short)(Convert.ToInt16(true));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV19GXLvl1 == 0 )
         {
            AV11tooltipexiste = (short)(Convert.ToInt16(false));
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
         P005K2_A135CampoId = new int[1] ;
         P005K2_A139TooltipTelaId = new int[1] ;
         P005K2_A112TooltipId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.validatooltip__default(),
            new Object[][] {
                new Object[] {
               P005K2_A135CampoId, P005K2_A139TooltipTelaId, P005K2_A112TooltipId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11tooltipexiste ;
      private short AV19GXLvl1 ;
      private int AV13TooltipId ;
      private int AV15TelaId ;
      private int AV16CampoId ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int A112TooltipId ;
      private string scmdbuf ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005K2_A135CampoId ;
      private int[] P005K2_A139TooltipTelaId ;
      private int[] P005K2_A112TooltipId ;
      private short aP3_tooltipexiste ;
   }

   public class validatooltip__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005K2;
          prmP005K2 = new Object[] {
          new ParDef("@AV16CampoId",GXType.Int32,8,0) ,
          new ParDef("@AV15TelaId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005K2", "SELECT [CampoId], [TooltipTelaId], [TooltipId] FROM [Tooltip] WHERE ([CampoId] = @AV16CampoId) AND ([TooltipTelaId] = @AV15TelaId) ORDER BY [CampoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
