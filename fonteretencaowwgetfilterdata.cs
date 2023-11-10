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
   public class fonteretencaowwgetfilterdata : GXProcedure
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
            return "fonteretencaoww_Services_Execute" ;
         }

      }

      public fonteretencaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public fonteretencaowwgetfilterdata( IGxContext context )
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
         this.AV20DDOName = aP0_DDOName;
         this.AV14SearchTxtParms = aP1_SearchTxtParms;
         this.AV19SearchTxtTo = aP2_SearchTxtTo;
         this.AV24OptionsJson = "" ;
         this.AV27OptionsDescJson = "" ;
         this.AV29OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV29OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         fonteretencaowwgetfilterdata objfonteretencaowwgetfilterdata;
         objfonteretencaowwgetfilterdata = new fonteretencaowwgetfilterdata();
         objfonteretencaowwgetfilterdata.AV20DDOName = aP0_DDOName;
         objfonteretencaowwgetfilterdata.AV14SearchTxtParms = aP1_SearchTxtParms;
         objfonteretencaowwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objfonteretencaowwgetfilterdata.AV24OptionsJson = "" ;
         objfonteretencaowwgetfilterdata.AV27OptionsDescJson = "" ;
         objfonteretencaowwgetfilterdata.AV29OptionIndexesJson = "" ;
         objfonteretencaowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objfonteretencaowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objfonteretencaowwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((fonteretencaowwgetfilterdata)stateInfo).executePrivate();
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
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV14SearchTxtParms, 1, 2), "."))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxtParms)) ? "" : StringUtil.Substring( AV14SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_FONTERETENCAONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADFONTERETENCAONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV24OptionsJson = AV23Options.ToJSonString(false);
         AV27OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV29OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("FonteRetencaoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "FonteRetencaoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("FonteRetencaoWWGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFONTERETENCAONOME") == 0 )
            {
               AV11TFFonteRetencaoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFONTERETENCAONOME_SEL") == 0 )
            {
               AV12TFFonteRetencaoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFONTERETENCAOATIVO_SEL") == 0 )
            {
               AV13TFFonteRetencaoAtivo_Sel = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADFONTERETENCAONOMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFFonteRetencaoNome = AV18SearchTxt;
         AV12TFFonteRetencaoNome_Sel = "";
         AV41Fonteretencaowwds_1_filterfulltext = AV36FilterFullText;
         AV42Fonteretencaowwds_2_tffonteretencaonome = AV11TFFonteRetencaoNome;
         AV43Fonteretencaowwds_3_tffonteretencaonome_sel = AV12TFFonteRetencaoNome_Sel;
         AV44Fonteretencaowwds_4_tffonteretencaoativo_sel = AV13TFFonteRetencaoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Fonteretencaowwds_1_filterfulltext ,
                                              AV43Fonteretencaowwds_3_tffonteretencaonome_sel ,
                                              AV42Fonteretencaowwds_2_tffonteretencaonome ,
                                              AV44Fonteretencaowwds_4_tffonteretencaoativo_sel ,
                                              A64FonteRetencaoNome ,
                                              A65FonteRetencaoAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Fonteretencaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Fonteretencaowwds_1_filterfulltext), "%", "");
         lV41Fonteretencaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Fonteretencaowwds_1_filterfulltext), "%", "");
         lV41Fonteretencaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Fonteretencaowwds_1_filterfulltext), "%", "");
         lV42Fonteretencaowwds_2_tffonteretencaonome = StringUtil.Concat( StringUtil.RTrim( AV42Fonteretencaowwds_2_tffonteretencaonome), "%", "");
         /* Using cursor P004K2 */
         pr_default.execute(0, new Object[] {lV41Fonteretencaowwds_1_filterfulltext, lV41Fonteretencaowwds_1_filterfulltext, lV41Fonteretencaowwds_1_filterfulltext, lV42Fonteretencaowwds_2_tffonteretencaonome, AV43Fonteretencaowwds_3_tffonteretencaonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4K2 = false;
            A64FonteRetencaoNome = P004K2_A64FonteRetencaoNome[0];
            A65FonteRetencaoAtivo = P004K2_A65FonteRetencaoAtivo[0];
            A63FonteRetencaoId = P004K2_A63FonteRetencaoId[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004K2_A64FonteRetencaoNome[0], A64FonteRetencaoNome) == 0 ) )
            {
               BRK4K2 = false;
               A63FonteRetencaoId = P004K2_A63FonteRetencaoId[0];
               AV30count = (long)(AV30count+1);
               BRK4K2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A64FonteRetencaoNome)) ? "<#Empty#>" : A64FonteRetencaoNome);
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK4K2 )
            {
               BRK4K2 = true;
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
         AV24OptionsJson = "";
         AV27OptionsDescJson = "";
         AV29OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV11TFFonteRetencaoNome = "";
         AV12TFFonteRetencaoNome_Sel = "";
         AV41Fonteretencaowwds_1_filterfulltext = "";
         AV42Fonteretencaowwds_2_tffonteretencaonome = "";
         AV43Fonteretencaowwds_3_tffonteretencaonome_sel = "";
         scmdbuf = "";
         lV41Fonteretencaowwds_1_filterfulltext = "";
         lV42Fonteretencaowwds_2_tffonteretencaonome = "";
         A64FonteRetencaoNome = "";
         P004K2_A64FonteRetencaoNome = new string[] {""} ;
         P004K2_A65FonteRetencaoAtivo = new bool[] {false} ;
         P004K2_A63FonteRetencaoId = new int[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.fonteretencaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004K2_A64FonteRetencaoNome, P004K2_A65FonteRetencaoAtivo, P004K2_A63FonteRetencaoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV13TFFonteRetencaoAtivo_Sel ;
      private short AV44Fonteretencaowwds_4_tffonteretencaoativo_sel ;
      private int AV39GXV1 ;
      private int A63FonteRetencaoId ;
      private long AV30count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A65FonteRetencaoAtivo ;
      private bool BRK4K2 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV20DDOName ;
      private string AV14SearchTxtParms ;
      private string AV19SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV36FilterFullText ;
      private string AV11TFFonteRetencaoNome ;
      private string AV12TFFonteRetencaoNome_Sel ;
      private string AV41Fonteretencaowwds_1_filterfulltext ;
      private string AV42Fonteretencaowwds_2_tffonteretencaonome ;
      private string AV43Fonteretencaowwds_3_tffonteretencaonome_sel ;
      private string lV41Fonteretencaowwds_1_filterfulltext ;
      private string lV42Fonteretencaowwds_2_tffonteretencaonome ;
      private string A64FonteRetencaoNome ;
      private string AV22Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004K2_A64FonteRetencaoNome ;
      private bool[] P004K2_A65FonteRetencaoAtivo ;
      private int[] P004K2_A63FonteRetencaoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
   }

   public class fonteretencaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004K2( IGxContext context ,
                                             string AV41Fonteretencaowwds_1_filterfulltext ,
                                             string AV43Fonteretencaowwds_3_tffonteretencaonome_sel ,
                                             string AV42Fonteretencaowwds_2_tffonteretencaonome ,
                                             short AV44Fonteretencaowwds_4_tffonteretencaoativo_sel ,
                                             string A64FonteRetencaoNome ,
                                             bool A65FonteRetencaoAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [FonteRetencaoNome], [FonteRetencaoAtivo], [FonteRetencaoId] FROM [FonteRetencao]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Fonteretencaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [FonteRetencaoNome] like '%' + @lV41Fonteretencaowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV41Fonteretencaowwds_1_filterfulltext) and [FonteRetencaoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV41Fonteretencaowwds_1_filterfulltext) and [FonteRetencaoAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Fonteretencaowwds_3_tffonteretencaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Fonteretencaowwds_2_tffonteretencaonome)) ) )
         {
            AddWhere(sWhereString, "([FonteRetencaoNome] like @lV42Fonteretencaowwds_2_tffonteretencaonome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Fonteretencaowwds_3_tffonteretencaonome_sel)) && ! ( StringUtil.StrCmp(AV43Fonteretencaowwds_3_tffonteretencaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([FonteRetencaoNome] = @AV43Fonteretencaowwds_3_tffonteretencaonome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV43Fonteretencaowwds_3_tffonteretencaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([FonteRetencaoNome] = ''))");
         }
         if ( AV44Fonteretencaowwds_4_tffonteretencaoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([FonteRetencaoAtivo] = 1)");
         }
         if ( AV44Fonteretencaowwds_4_tffonteretencaoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([FonteRetencaoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [FonteRetencaoNome]";
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
                     return conditional_P004K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP004K2;
          prmP004K2 = new Object[] {
          new ParDef("@lV41Fonteretencaowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV41Fonteretencaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV41Fonteretencaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV42Fonteretencaowwds_2_tffonteretencaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV43Fonteretencaowwds_3_tffonteretencaonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004K2,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.fonteretencaowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class fonteretencaowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "FonteRetencaoWWGetFilterData" )]
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
          permissionPrefix = "fonteretencaoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("fonteretencaowwgetfilterdata") )
          {
             return  ;
          }
          fonteretencaowwgetfilterdata worker = new fonteretencaowwgetfilterdata(context);
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
