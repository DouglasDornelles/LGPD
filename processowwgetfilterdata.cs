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
   public class processowwgetfilterdata : GXProcedure
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
            return "processoww_Services_Execute" ;
         }

      }

      public processowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public processowwgetfilterdata( IGxContext context )
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
         this.AV28DDOName = aP0_DDOName;
         this.AV22SearchTxtParms = aP1_SearchTxtParms;
         this.AV27SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         processowwgetfilterdata objprocessowwgetfilterdata;
         objprocessowwgetfilterdata = new processowwgetfilterdata();
         objprocessowwgetfilterdata.AV28DDOName = aP0_DDOName;
         objprocessowwgetfilterdata.AV22SearchTxtParms = aP1_SearchTxtParms;
         objprocessowwgetfilterdata.AV27SearchTxtTo = aP2_SearchTxtTo;
         objprocessowwgetfilterdata.AV32OptionsJson = "" ;
         objprocessowwgetfilterdata.AV35OptionsDescJson = "" ;
         objprocessowwgetfilterdata.AV37OptionIndexesJson = "" ;
         objprocessowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objprocessowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objprocessowwgetfilterdata);
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((processowwgetfilterdata)stateInfo).executePrivate();
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
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25MaxItems = 10;
         AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV22SearchTxtParms, 1, 2), "."))));
         AV26SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms)) ? "" : StringUtil.Substring( AV22SearchTxtParms, 3, -1));
         AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_PROCESSONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROCESSONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV31Options.ToJSonString(false);
         AV35OptionsDescJson = AV34OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("ProcessoWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProcessoWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("ProcessoWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCESSONOME") == 0 )
            {
               AV13TFProcessoNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCESSONOME_SEL") == 0 )
            {
               AV14TFProcessoNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCESSOATIVO_SEL") == 0 )
            {
               AV21TFProcessoAtivo_Sel = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROCESSONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFProcessoNome = AV26SearchTxt;
         AV14TFProcessoNome_Sel = "";
         AV49Processowwds_1_filterfulltext = AV44FilterFullText;
         AV50Processowwds_2_tfprocessonome = AV13TFProcessoNome;
         AV51Processowwds_3_tfprocessonome_sel = AV14TFProcessoNome_Sel;
         AV52Processowwds_4_tfprocessoativo_sel = AV21TFProcessoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Processowwds_1_filterfulltext ,
                                              AV51Processowwds_3_tfprocessonome_sel ,
                                              AV50Processowwds_2_tfprocessonome ,
                                              AV52Processowwds_4_tfprocessoativo_sel ,
                                              A17ProcessoNome ,
                                              A19ProcessoAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV49Processowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Processowwds_1_filterfulltext), "%", "");
         lV49Processowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Processowwds_1_filterfulltext), "%", "");
         lV49Processowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Processowwds_1_filterfulltext), "%", "");
         lV50Processowwds_2_tfprocessonome = StringUtil.Concat( StringUtil.RTrim( AV50Processowwds_2_tfprocessonome), "%", "");
         /* Using cursor P003G2 */
         pr_default.execute(0, new Object[] {lV49Processowwds_1_filterfulltext, lV49Processowwds_1_filterfulltext, lV49Processowwds_1_filterfulltext, lV50Processowwds_2_tfprocessonome, AV51Processowwds_3_tfprocessonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3G2 = false;
            A17ProcessoNome = P003G2_A17ProcessoNome[0];
            A19ProcessoAtivo = P003G2_A19ProcessoAtivo[0];
            A16ProcessoId = P003G2_A16ProcessoId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003G2_A17ProcessoNome[0], A17ProcessoNome) == 0 ) )
            {
               BRK3G2 = false;
               A16ProcessoId = P003G2_A16ProcessoId[0];
               AV38count = (long)(AV38count+1);
               BRK3G2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV23SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A17ProcessoNome)) ? "<#Empty#>" : A17ProcessoNome);
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRK3G2 )
            {
               BRK3G2 = true;
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
         AV32OptionsJson = "";
         AV35OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV34OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV26SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44FilterFullText = "";
         AV13TFProcessoNome = "";
         AV14TFProcessoNome_Sel = "";
         AV49Processowwds_1_filterfulltext = "";
         AV50Processowwds_2_tfprocessonome = "";
         AV51Processowwds_3_tfprocessonome_sel = "";
         scmdbuf = "";
         lV49Processowwds_1_filterfulltext = "";
         lV50Processowwds_2_tfprocessonome = "";
         A17ProcessoNome = "";
         P003G2_A17ProcessoNome = new string[] {""} ;
         P003G2_A19ProcessoAtivo = new bool[] {false} ;
         P003G2_A16ProcessoId = new int[1] ;
         AV30Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.processowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003G2_A17ProcessoNome, P003G2_A19ProcessoAtivo, P003G2_A16ProcessoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV21TFProcessoAtivo_Sel ;
      private short AV52Processowwds_4_tfprocessoativo_sel ;
      private int AV47GXV1 ;
      private int A16ProcessoId ;
      private long AV38count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A19ProcessoAtivo ;
      private bool BRK3G2 ;
      private string AV32OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV28DDOName ;
      private string AV22SearchTxtParms ;
      private string AV27SearchTxtTo ;
      private string AV26SearchTxt ;
      private string AV44FilterFullText ;
      private string AV13TFProcessoNome ;
      private string AV14TFProcessoNome_Sel ;
      private string AV49Processowwds_1_filterfulltext ;
      private string AV50Processowwds_2_tfprocessonome ;
      private string AV51Processowwds_3_tfprocessonome_sel ;
      private string lV49Processowwds_1_filterfulltext ;
      private string lV50Processowwds_2_tfprocessonome ;
      private string A17ProcessoNome ;
      private string AV30Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003G2_A17ProcessoNome ;
      private bool[] P003G2_A19ProcessoAtivo ;
      private int[] P003G2_A16ProcessoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV34OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
   }

   public class processowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003G2( IGxContext context ,
                                             string AV49Processowwds_1_filterfulltext ,
                                             string AV51Processowwds_3_tfprocessonome_sel ,
                                             string AV50Processowwds_2_tfprocessonome ,
                                             short AV52Processowwds_4_tfprocessoativo_sel ,
                                             string A17ProcessoNome ,
                                             bool A19ProcessoAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ProcessoNome], [ProcessoAtivo], [ProcessoId] FROM [Processo]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Processowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ProcessoNome] like '%' + @lV49Processowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV49Processowwds_1_filterfulltext) and [ProcessoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV49Processowwds_1_filterfulltext) and [ProcessoAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Processowwds_3_tfprocessonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Processowwds_2_tfprocessonome)) ) )
         {
            AddWhere(sWhereString, "([ProcessoNome] like @lV50Processowwds_2_tfprocessonome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Processowwds_3_tfprocessonome_sel)) && ! ( StringUtil.StrCmp(AV51Processowwds_3_tfprocessonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProcessoNome] = @AV51Processowwds_3_tfprocessonome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Processowwds_3_tfprocessonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProcessoNome] = ''))");
         }
         if ( AV52Processowwds_4_tfprocessoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([ProcessoAtivo] = 1)");
         }
         if ( AV52Processowwds_4_tfprocessoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([ProcessoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProcessoNome]";
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
                     return conditional_P003G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP003G2;
          prmP003G2 = new Object[] {
          new ParDef("@lV49Processowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV49Processowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Processowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV50Processowwds_2_tfprocessonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV51Processowwds_3_tfprocessonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G2,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.processowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class processowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "ProcessoWWGetFilterData" )]
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
          permissionPrefix = "processoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("processowwgetfilterdata") )
          {
             return  ;
          }
          processowwgetfilterdata worker = new processowwgetfilterdata(context);
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
