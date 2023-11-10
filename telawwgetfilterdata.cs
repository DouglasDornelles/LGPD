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
   public class telawwgetfilterdata : GXProcedure
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
            return "telaww_Services_Execute" ;
         }

      }

      public telawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public telawwgetfilterdata( IGxContext context )
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
         this.AV21DDOName = aP0_DDOName;
         this.AV15SearchTxtParms = aP1_SearchTxtParms;
         this.AV20SearchTxtTo = aP2_SearchTxtTo;
         this.AV25OptionsJson = "" ;
         this.AV28OptionsDescJson = "" ;
         this.AV30OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV25OptionsJson;
         aP4_OptionsDescJson=this.AV28OptionsDescJson;
         aP5_OptionIndexesJson=this.AV30OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV30OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         telawwgetfilterdata objtelawwgetfilterdata;
         objtelawwgetfilterdata = new telawwgetfilterdata();
         objtelawwgetfilterdata.AV21DDOName = aP0_DDOName;
         objtelawwgetfilterdata.AV15SearchTxtParms = aP1_SearchTxtParms;
         objtelawwgetfilterdata.AV20SearchTxtTo = aP2_SearchTxtTo;
         objtelawwgetfilterdata.AV25OptionsJson = "" ;
         objtelawwgetfilterdata.AV28OptionsDescJson = "" ;
         objtelawwgetfilterdata.AV30OptionIndexesJson = "" ;
         objtelawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtelawwgetfilterdata.initialize();
         Submit( executePrivateCatch,objtelawwgetfilterdata);
         aP3_OptionsJson=this.AV25OptionsJson;
         aP4_OptionsDescJson=this.AV28OptionsDescJson;
         aP5_OptionIndexesJson=this.AV30OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((telawwgetfilterdata)stateInfo).executePrivate();
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
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV15SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV15SearchTxtParms, 1, 2), "."))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV15SearchTxtParms)) ? "" : StringUtil.Substring( AV15SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV21DDOName), "DDO_TELANOME") == 0 )
         {
            /* Execute user subroutine: 'LOADTELANOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV25OptionsJson = AV24Options.ToJSonString(false);
         AV28OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV30OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("TelaWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TelaWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("TelaWWGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTELANOME") == 0 )
            {
               AV13TFTelaNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTELANOME_SEL") == 0 )
            {
               AV14TFTelaNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTELAATIVO_SEL") == 0 )
            {
               AV38TFTelaAtivo_Sel = (short)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTELANOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFTelaNome = AV19SearchTxt;
         AV14TFTelaNome_Sel = "";
         AV43Telawwds_1_filterfulltext = AV37FilterFullText;
         AV44Telawwds_2_tftelanome = AV13TFTelaNome;
         AV45Telawwds_3_tftelanome_sel = AV14TFTelaNome_Sel;
         AV46Telawwds_4_tftelaativo_sel = AV38TFTelaAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Telawwds_1_filterfulltext ,
                                              AV45Telawwds_3_tftelanome_sel ,
                                              AV44Telawwds_2_tftelanome ,
                                              AV46Telawwds_4_tftelaativo_sel ,
                                              A134TelaNome ,
                                              A137TelaAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Telawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Telawwds_1_filterfulltext), "%", "");
         lV43Telawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Telawwds_1_filterfulltext), "%", "");
         lV43Telawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Telawwds_1_filterfulltext), "%", "");
         lV44Telawwds_2_tftelanome = StringUtil.Concat( StringUtil.RTrim( AV44Telawwds_2_tftelanome), "%", "");
         /* Using cursor P006O2 */
         pr_default.execute(0, new Object[] {lV43Telawwds_1_filterfulltext, lV43Telawwds_1_filterfulltext, lV43Telawwds_1_filterfulltext, lV44Telawwds_2_tftelanome, AV45Telawwds_3_tftelanome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6O2 = false;
            A134TelaNome = P006O2_A134TelaNome[0];
            A137TelaAtivo = P006O2_A137TelaAtivo[0];
            A133TelaId = P006O2_A133TelaId[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006O2_A134TelaNome[0], A134TelaNome) == 0 ) )
            {
               BRK6O2 = false;
               A133TelaId = P006O2_A133TelaId[0];
               AV31count = (long)(AV31count+1);
               BRK6O2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A134TelaNome)) ? "<#Empty#>" : A134TelaNome);
               AV24Options.Add(AV23Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6O2 )
            {
               BRK6O2 = true;
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
         AV25OptionsJson = "";
         AV28OptionsDescJson = "";
         AV30OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV13TFTelaNome = "";
         AV14TFTelaNome_Sel = "";
         AV43Telawwds_1_filterfulltext = "";
         AV44Telawwds_2_tftelanome = "";
         AV45Telawwds_3_tftelanome_sel = "";
         scmdbuf = "";
         lV43Telawwds_1_filterfulltext = "";
         lV44Telawwds_2_tftelanome = "";
         A134TelaNome = "";
         P006O2_A134TelaNome = new string[] {""} ;
         P006O2_A137TelaAtivo = new bool[] {false} ;
         P006O2_A133TelaId = new int[1] ;
         AV23Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.telawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006O2_A134TelaNome, P006O2_A137TelaAtivo, P006O2_A133TelaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV38TFTelaAtivo_Sel ;
      private short AV46Telawwds_4_tftelaativo_sel ;
      private int AV41GXV1 ;
      private int A133TelaId ;
      private long AV31count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A137TelaAtivo ;
      private bool BRK6O2 ;
      private string AV25OptionsJson ;
      private string AV28OptionsDescJson ;
      private string AV30OptionIndexesJson ;
      private string AV21DDOName ;
      private string AV15SearchTxtParms ;
      private string AV20SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV37FilterFullText ;
      private string AV13TFTelaNome ;
      private string AV14TFTelaNome_Sel ;
      private string AV43Telawwds_1_filterfulltext ;
      private string AV44Telawwds_2_tftelanome ;
      private string AV45Telawwds_3_tftelanome_sel ;
      private string lV43Telawwds_1_filterfulltext ;
      private string lV44Telawwds_2_tftelanome ;
      private string A134TelaNome ;
      private string AV23Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006O2_A134TelaNome ;
      private bool[] P006O2_A137TelaAtivo ;
      private int[] P006O2_A133TelaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
   }

   public class telawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006O2( IGxContext context ,
                                             string AV43Telawwds_1_filterfulltext ,
                                             string AV45Telawwds_3_tftelanome_sel ,
                                             string AV44Telawwds_2_tftelanome ,
                                             short AV46Telawwds_4_tftelaativo_sel ,
                                             string A134TelaNome ,
                                             bool A137TelaAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TelaNome], [TelaAtivo], [TelaId] FROM [Tela]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Telawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [TelaNome] like '%' + @lV43Telawwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV43Telawwds_1_filterfulltext) and [TelaAtivo] = 1) or ( 'não' like '%' + LOWER(@lV43Telawwds_1_filterfulltext) and [TelaAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Telawwds_3_tftelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Telawwds_2_tftelanome)) ) )
         {
            AddWhere(sWhereString, "([TelaNome] like @lV44Telawwds_2_tftelanome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Telawwds_3_tftelanome_sel)) && ! ( StringUtil.StrCmp(AV45Telawwds_3_tftelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TelaNome] = @AV45Telawwds_3_tftelanome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV45Telawwds_3_tftelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TelaNome] = ''))");
         }
         if ( AV46Telawwds_4_tftelaativo_sel == 1 )
         {
            AddWhere(sWhereString, "([TelaAtivo] = 1)");
         }
         if ( AV46Telawwds_4_tftelaativo_sel == 2 )
         {
            AddWhere(sWhereString, "([TelaAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TelaNome]";
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
                     return conditional_P006O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP006O2;
          prmP006O2 = new Object[] {
          new ParDef("@lV43Telawwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV43Telawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV43Telawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Telawwds_2_tftelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV45Telawwds_3_tftelanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006O2,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.telawwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class telawwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "TelaWWGetFilterData" )]
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
          permissionPrefix = "telaww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("telawwgetfilterdata") )
          {
             return  ;
          }
          telawwgetfilterdata worker = new telawwgetfilterdata(context);
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
