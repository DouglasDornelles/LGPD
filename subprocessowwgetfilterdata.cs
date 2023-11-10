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
   public class subprocessowwgetfilterdata : GXProcedure
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
            return "subprocessoww_Services_Execute" ;
         }

      }

      public subprocessowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public subprocessowwgetfilterdata( IGxContext context )
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
         this.AV26DDOName = aP0_DDOName;
         this.AV20SearchTxtParms = aP1_SearchTxtParms;
         this.AV25SearchTxtTo = aP2_SearchTxtTo;
         this.AV30OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV30OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         subprocessowwgetfilterdata objsubprocessowwgetfilterdata;
         objsubprocessowwgetfilterdata = new subprocessowwgetfilterdata();
         objsubprocessowwgetfilterdata.AV26DDOName = aP0_DDOName;
         objsubprocessowwgetfilterdata.AV20SearchTxtParms = aP1_SearchTxtParms;
         objsubprocessowwgetfilterdata.AV25SearchTxtTo = aP2_SearchTxtTo;
         objsubprocessowwgetfilterdata.AV30OptionsJson = "" ;
         objsubprocessowwgetfilterdata.AV33OptionsDescJson = "" ;
         objsubprocessowwgetfilterdata.AV35OptionIndexesJson = "" ;
         objsubprocessowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objsubprocessowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objsubprocessowwgetfilterdata);
         aP3_OptionsJson=this.AV30OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((subprocessowwgetfilterdata)stateInfo).executePrivate();
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
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23MaxItems = 10;
         AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV20SearchTxtParms, 1, 2), "."))));
         AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms)) ? "" : StringUtil.Substring( AV20SearchTxtParms, 3, -1));
         AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_SUBPROCESSONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUBPROCESSONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV30OptionsJson = AV29Options.ToJSonString(false);
         AV33OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("SubProcessoWWGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SubProcessoWWGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("SubProcessoWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFSUBPROCESSONOME") == 0 )
            {
               AV15TFSubprocessoNome = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFSUBPROCESSONOME_SEL") == 0 )
            {
               AV16TFSubprocessoNome_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFSUBPROCESSOATIVO_SEL") == 0 )
            {
               AV17TFSubprocessoAtivo_Sel = (short)(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, "."));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUBPROCESSONOMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSubprocessoNome = AV24SearchTxt;
         AV16TFSubprocessoNome_Sel = "";
         AV49Subprocessowwds_1_filterfulltext = AV42FilterFullText;
         AV50Subprocessowwds_2_tfsubprocessonome = AV15TFSubprocessoNome;
         AV51Subprocessowwds_3_tfsubprocessonome_sel = AV16TFSubprocessoNome_Sel;
         AV52Subprocessowwds_4_tfsubprocessoativo_sel = AV17TFSubprocessoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Subprocessowwds_1_filterfulltext ,
                                              AV51Subprocessowwds_3_tfsubprocessonome_sel ,
                                              AV50Subprocessowwds_2_tfsubprocessonome ,
                                              AV52Subprocessowwds_4_tfsubprocessoativo_sel ,
                                              A21SubprocessoNome ,
                                              A23SubprocessoAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV49Subprocessowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Subprocessowwds_1_filterfulltext), "%", "");
         lV49Subprocessowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Subprocessowwds_1_filterfulltext), "%", "");
         lV49Subprocessowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Subprocessowwds_1_filterfulltext), "%", "");
         lV50Subprocessowwds_2_tfsubprocessonome = StringUtil.Concat( StringUtil.RTrim( AV50Subprocessowwds_2_tfsubprocessonome), "%", "");
         /* Using cursor P005A2 */
         pr_default.execute(0, new Object[] {lV49Subprocessowwds_1_filterfulltext, lV49Subprocessowwds_1_filterfulltext, lV49Subprocessowwds_1_filterfulltext, lV50Subprocessowwds_2_tfsubprocessonome, AV51Subprocessowwds_3_tfsubprocessonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5A2 = false;
            A21SubprocessoNome = P005A2_A21SubprocessoNome[0];
            A23SubprocessoAtivo = P005A2_A23SubprocessoAtivo[0];
            A20SubprocessoId = P005A2_A20SubprocessoId[0];
            AV36count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005A2_A21SubprocessoNome[0], A21SubprocessoNome) == 0 ) )
            {
               BRK5A2 = false;
               A20SubprocessoId = P005A2_A20SubprocessoId[0];
               AV36count = (long)(AV36count+1);
               BRK5A2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV21SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A21SubprocessoNome)) ? "<#Empty#>" : A21SubprocessoNome);
               AV29Options.Add(AV28Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRK5A2 )
            {
               BRK5A2 = true;
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
         AV30OptionsJson = "";
         AV33OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42FilterFullText = "";
         AV15TFSubprocessoNome = "";
         AV16TFSubprocessoNome_Sel = "";
         AV49Subprocessowwds_1_filterfulltext = "";
         AV50Subprocessowwds_2_tfsubprocessonome = "";
         AV51Subprocessowwds_3_tfsubprocessonome_sel = "";
         scmdbuf = "";
         lV49Subprocessowwds_1_filterfulltext = "";
         lV50Subprocessowwds_2_tfsubprocessonome = "";
         A21SubprocessoNome = "";
         P005A2_A21SubprocessoNome = new string[] {""} ;
         P005A2_A23SubprocessoAtivo = new bool[] {false} ;
         P005A2_A20SubprocessoId = new int[1] ;
         AV28Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.subprocessowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005A2_A21SubprocessoNome, P005A2_A23SubprocessoAtivo, P005A2_A20SubprocessoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private short AV17TFSubprocessoAtivo_Sel ;
      private short AV52Subprocessowwds_4_tfsubprocessoativo_sel ;
      private int AV47GXV1 ;
      private int A20SubprocessoId ;
      private long AV36count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A23SubprocessoAtivo ;
      private bool BRK5A2 ;
      private string AV30OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV26DDOName ;
      private string AV20SearchTxtParms ;
      private string AV25SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV42FilterFullText ;
      private string AV15TFSubprocessoNome ;
      private string AV16TFSubprocessoNome_Sel ;
      private string AV49Subprocessowwds_1_filterfulltext ;
      private string AV50Subprocessowwds_2_tfsubprocessonome ;
      private string AV51Subprocessowwds_3_tfsubprocessonome_sel ;
      private string lV49Subprocessowwds_1_filterfulltext ;
      private string lV50Subprocessowwds_2_tfsubprocessonome ;
      private string A21SubprocessoNome ;
      private string AV28Option ;
      private IGxSession AV37Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005A2_A21SubprocessoNome ;
      private bool[] P005A2_A23SubprocessoAtivo ;
      private int[] P005A2_A20SubprocessoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
   }

   public class subprocessowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005A2( IGxContext context ,
                                             string AV49Subprocessowwds_1_filterfulltext ,
                                             string AV51Subprocessowwds_3_tfsubprocessonome_sel ,
                                             string AV50Subprocessowwds_2_tfsubprocessonome ,
                                             short AV52Subprocessowwds_4_tfsubprocessoativo_sel ,
                                             string A21SubprocessoNome ,
                                             bool A23SubprocessoAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [SubprocessoNome], [SubprocessoAtivo], [SubprocessoId] FROM [SubProcesso]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Subprocessowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [SubprocessoNome] like '%' + @lV49Subprocessowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV49Subprocessowwds_1_filterfulltext) and [SubprocessoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV49Subprocessowwds_1_filterfulltext) and [SubprocessoAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Subprocessowwds_3_tfsubprocessonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Subprocessowwds_2_tfsubprocessonome)) ) )
         {
            AddWhere(sWhereString, "([SubprocessoNome] like @lV50Subprocessowwds_2_tfsubprocessonome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Subprocessowwds_3_tfsubprocessonome_sel)) && ! ( StringUtil.StrCmp(AV51Subprocessowwds_3_tfsubprocessonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SubprocessoNome] = @AV51Subprocessowwds_3_tfsubprocessonome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Subprocessowwds_3_tfsubprocessonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SubprocessoNome] = ''))");
         }
         if ( AV52Subprocessowwds_4_tfsubprocessoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([SubprocessoAtivo] = 1)");
         }
         if ( AV52Subprocessowwds_4_tfsubprocessoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([SubprocessoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SubprocessoNome]";
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
                     return conditional_P005A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP005A2;
          prmP005A2 = new Object[] {
          new ParDef("@lV49Subprocessowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV49Subprocessowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Subprocessowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV50Subprocessowwds_2_tfsubprocessonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV51Subprocessowwds_3_tfsubprocessonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A2,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.subprocessowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class subprocessowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "SubProcessoWWGetFilterData" )]
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
          permissionPrefix = "subprocessoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("subprocessowwgetfilterdata") )
          {
             return  ;
          }
          subprocessowwgetfilterdata worker = new subprocessowwgetfilterdata(context);
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
