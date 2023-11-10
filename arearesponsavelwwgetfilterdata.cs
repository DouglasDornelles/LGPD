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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class arearesponsavelwwgetfilterdata : GXProcedure
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "arearesponsavelww_Services_Execute" ;
         }

      }

      public arearesponsavelwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public arearesponsavelwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV22DDOName = aP0_DDOName;
         this.AV16SearchTxtParms = aP1_SearchTxtParms;
         this.AV21SearchTxtTo = aP2_SearchTxtTo;
         this.AV26OptionsJson = "" ;
         this.AV29OptionsDescJson = "" ;
         this.AV31OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV31OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         arearesponsavelwwgetfilterdata objarearesponsavelwwgetfilterdata;
         objarearesponsavelwwgetfilterdata = new arearesponsavelwwgetfilterdata();
         objarearesponsavelwwgetfilterdata.AV22DDOName = aP0_DDOName;
         objarearesponsavelwwgetfilterdata.AV16SearchTxtParms = aP1_SearchTxtParms;
         objarearesponsavelwwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objarearesponsavelwwgetfilterdata.AV26OptionsJson = "" ;
         objarearesponsavelwwgetfilterdata.AV29OptionsDescJson = "" ;
         objarearesponsavelwwgetfilterdata.AV31OptionIndexesJson = "" ;
         objarearesponsavelwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objarearesponsavelwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objarearesponsavelwwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((arearesponsavelwwgetfilterdata)stateInfo).executePrivate();
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
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV16SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV16SearchTxtParms, 1, 2), "."))));
         AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV16SearchTxtParms)) ? "" : StringUtil.Substring( AV16SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_AREARESPONSAVELNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADAREARESPONSAVELNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV26OptionsJson = AV25Options.ToJSonString(false);
         AV29OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV31OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("AreaResponsavelWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AreaResponsavelWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("AreaResponsavelWWGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAREARESPONSAVELNOME") == 0 )
            {
               AV13TFAreaResponsavelNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAREARESPONSAVELNOME_SEL") == 0 )
            {
               AV14TFAreaResponsavelNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAREARESPONSAVELATIVO_SEL") == 0 )
            {
               AV15TFAreaResponsavelAtivo_Sel = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAREARESPONSAVELNOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFAreaResponsavelNome = AV20SearchTxt;
         AV14TFAreaResponsavelNome_Sel = "";
         AV43Arearesponsavelwwds_1_filterfulltext = AV38FilterFullText;
         AV44Arearesponsavelwwds_2_tfarearesponsavelnome = AV13TFAreaResponsavelNome;
         AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel = AV14TFAreaResponsavelNome_Sel;
         AV46Arearesponsavelwwds_4_tfarearesponsavelativo_sel = AV15TFAreaResponsavelAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Arearesponsavelwwds_1_filterfulltext ,
                                              AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel ,
                                              AV44Arearesponsavelwwds_2_tfarearesponsavelnome ,
                                              AV46Arearesponsavelwwds_4_tfarearesponsavelativo_sel ,
                                              A25AreaResponsavelNome ,
                                              A26AreaResponsavelAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Arearesponsavelwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Arearesponsavelwwds_1_filterfulltext), "%", "");
         lV43Arearesponsavelwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Arearesponsavelwwds_1_filterfulltext), "%", "");
         lV43Arearesponsavelwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Arearesponsavelwwds_1_filterfulltext), "%", "");
         lV44Arearesponsavelwwds_2_tfarearesponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV44Arearesponsavelwwds_2_tfarearesponsavelnome), "%", "");
         /* Using cursor P00632 */
         pr_default.execute(0, new Object[] {lV43Arearesponsavelwwds_1_filterfulltext, lV43Arearesponsavelwwds_1_filterfulltext, lV43Arearesponsavelwwds_1_filterfulltext, lV44Arearesponsavelwwds_2_tfarearesponsavelnome, AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK632 = false;
            A25AreaResponsavelNome = P00632_A25AreaResponsavelNome[0];
            A26AreaResponsavelAtivo = P00632_A26AreaResponsavelAtivo[0];
            A24AreaResponsavelId = P00632_A24AreaResponsavelId[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00632_A25AreaResponsavelNome[0], A25AreaResponsavelNome) == 0 ) )
            {
               BRK632 = false;
               A24AreaResponsavelId = P00632_A24AreaResponsavelId[0];
               AV32count = (long)(AV32count+1);
               BRK632 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A25AreaResponsavelNome)) ? "<#Empty#>" : A25AreaResponsavelNome);
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK632 )
            {
               BRK632 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV26OptionsJson = "";
         AV29OptionsDescJson = "";
         AV31OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV13TFAreaResponsavelNome = "";
         AV14TFAreaResponsavelNome_Sel = "";
         AV43Arearesponsavelwwds_1_filterfulltext = "";
         AV44Arearesponsavelwwds_2_tfarearesponsavelnome = "";
         AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel = "";
         scmdbuf = "";
         lV43Arearesponsavelwwds_1_filterfulltext = "";
         lV44Arearesponsavelwwds_2_tfarearesponsavelnome = "";
         A25AreaResponsavelNome = "";
         P00632_A25AreaResponsavelNome = new string[] {""} ;
         P00632_A26AreaResponsavelAtivo = new bool[] {false} ;
         P00632_A24AreaResponsavelId = new int[1] ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arearesponsavelwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00632_A25AreaResponsavelNome, P00632_A26AreaResponsavelAtivo, P00632_A24AreaResponsavelId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV15TFAreaResponsavelAtivo_Sel ;
      private short AV46Arearesponsavelwwds_4_tfarearesponsavelativo_sel ;
      private int AV41GXV1 ;
      private int A24AreaResponsavelId ;
      private long AV32count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A26AreaResponsavelAtivo ;
      private bool BRK632 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV22DDOName ;
      private string AV16SearchTxtParms ;
      private string AV21SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV38FilterFullText ;
      private string AV13TFAreaResponsavelNome ;
      private string AV14TFAreaResponsavelNome_Sel ;
      private string AV43Arearesponsavelwwds_1_filterfulltext ;
      private string AV44Arearesponsavelwwds_2_tfarearesponsavelnome ;
      private string AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel ;
      private string lV43Arearesponsavelwwds_1_filterfulltext ;
      private string lV44Arearesponsavelwwds_2_tfarearesponsavelnome ;
      private string A25AreaResponsavelNome ;
      private string AV24Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00632_A25AreaResponsavelNome ;
      private bool[] P00632_A26AreaResponsavelAtivo ;
      private int[] P00632_A24AreaResponsavelId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class arearesponsavelwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00632( IGxContext context ,
                                             string AV43Arearesponsavelwwds_1_filterfulltext ,
                                             string AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel ,
                                             string AV44Arearesponsavelwwds_2_tfarearesponsavelnome ,
                                             short AV46Arearesponsavelwwds_4_tfarearesponsavelativo_sel ,
                                             string A25AreaResponsavelNome ,
                                             bool A26AreaResponsavelAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [AreaResponsavelNome], [AreaResponsavelAtivo], [AreaResponsavelId] FROM [AreaResponsavel]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Arearesponsavelwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [AreaResponsavelNome] like '%' + @lV43Arearesponsavelwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV43Arearesponsavelwwds_1_filterfulltext) and [AreaResponsavelAtivo] = 1) or ( 'não' like '%' + LOWER(@lV43Arearesponsavelwwds_1_filterfulltext) and [AreaResponsavelAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Arearesponsavelwwds_2_tfarearesponsavelnome)) ) )
         {
            AddWhere(sWhereString, "([AreaResponsavelNome] like @lV44Arearesponsavelwwds_2_tfarearesponsavelnome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([AreaResponsavelNome] = @AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([AreaResponsavelNome] = ''))");
         }
         if ( AV46Arearesponsavelwwds_4_tfarearesponsavelativo_sel == 1 )
         {
            AddWhere(sWhereString, "([AreaResponsavelAtivo] = 1)");
         }
         if ( AV46Arearesponsavelwwds_4_tfarearesponsavelativo_sel == 2 )
         {
            AddWhere(sWhereString, "([AreaResponsavelAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AreaResponsavelNome]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00632(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00632;
          prmP00632 = new Object[] {
          new ParDef("@lV43Arearesponsavelwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV43Arearesponsavelwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV43Arearesponsavelwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Arearesponsavelwwds_2_tfarearesponsavelnome",GXType.NVarChar,100,0) ,
          new ParDef("@AV45Arearesponsavelwwds_3_tfarearesponsavelnome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.arearesponsavelwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class arearesponsavelwwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "AreaResponsavelWWGetFilterData" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string DDOName ,
                         string SearchTxtParms ,
                         string SearchTxtTo ,
                         out string OptionsJson ,
                         out string OptionsDescJson ,
                         out string OptionIndexesJson )
    {
       OptionsJson = "" ;
       OptionsDescJson = "" ;
       OptionIndexesJson = "" ;
       try
       {
          permissionPrefix = "arearesponsavelww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("arearesponsavelwwgetfilterdata") )
          {
             return  ;
          }
          arearesponsavelwwgetfilterdata worker = new arearesponsavelwwgetfilterdata(context);
          worker.IsMain = RunAsMain ;
          worker.execute(DDOName,SearchTxtParms,SearchTxtTo,out OptionsJson,out OptionsDescJson,out OptionIndexesJson );
          worker.cleanup( );
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}
