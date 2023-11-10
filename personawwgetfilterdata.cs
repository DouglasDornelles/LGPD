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
   public class personawwgetfilterdata : GXProcedure
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
            return "personaww_Services_Execute" ;
         }

      }

      public personawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public personawwgetfilterdata( IGxContext context )
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
         this.AV24DDOName = aP0_DDOName;
         this.AV18SearchTxtParms = aP1_SearchTxtParms;
         this.AV23SearchTxtTo = aP2_SearchTxtTo;
         this.AV28OptionsJson = "" ;
         this.AV31OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         personawwgetfilterdata objpersonawwgetfilterdata;
         objpersonawwgetfilterdata = new personawwgetfilterdata();
         objpersonawwgetfilterdata.AV24DDOName = aP0_DDOName;
         objpersonawwgetfilterdata.AV18SearchTxtParms = aP1_SearchTxtParms;
         objpersonawwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objpersonawwgetfilterdata.AV28OptionsJson = "" ;
         objpersonawwgetfilterdata.AV31OptionsDescJson = "" ;
         objpersonawwgetfilterdata.AV33OptionIndexesJson = "" ;
         objpersonawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objpersonawwgetfilterdata.initialize();
         Submit( executePrivateCatch,objpersonawwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((personawwgetfilterdata)stateInfo).executePrivate();
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
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV18SearchTxtParms, 1, 2), "."))));
         AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? "" : StringUtil.Substring( AV18SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PERSONANOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPERSONANOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV28OptionsJson = AV27Options.ToJSonString(false);
         AV31OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("PersonaWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PersonaWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("PersonaWWGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPERSONANOME") == 0 )
            {
               AV15TFPersonaNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPERSONANOME_SEL") == 0 )
            {
               AV16TFPersonaNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPERSONAATIVO_SEL") == 0 )
            {
               AV17TFPersonaAtivo_Sel = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPERSONANOMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFPersonaNome = AV22SearchTxt;
         AV16TFPersonaNome_Sel = "";
         AV45Personawwds_1_filterfulltext = AV40FilterFullText;
         AV46Personawwds_2_tfpersonanome = AV15TFPersonaNome;
         AV47Personawwds_3_tfpersonanome_sel = AV16TFPersonaNome_Sel;
         AV48Personawwds_4_tfpersonaativo_sel = AV17TFPersonaAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Personawwds_1_filterfulltext ,
                                              AV47Personawwds_3_tfpersonanome_sel ,
                                              AV46Personawwds_2_tfpersonanome ,
                                              AV48Personawwds_4_tfpersonaativo_sel ,
                                              A14PersonaNome ,
                                              A15PersonaAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV45Personawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Personawwds_1_filterfulltext), "%", "");
         lV45Personawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Personawwds_1_filterfulltext), "%", "");
         lV45Personawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Personawwds_1_filterfulltext), "%", "");
         lV46Personawwds_2_tfpersonanome = StringUtil.Concat( StringUtil.RTrim( AV46Personawwds_2_tfpersonanome), "%", "");
         /* Using cursor P00332 */
         pr_default.execute(0, new Object[] {lV45Personawwds_1_filterfulltext, lV45Personawwds_1_filterfulltext, lV45Personawwds_1_filterfulltext, lV46Personawwds_2_tfpersonanome, AV47Personawwds_3_tfpersonanome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK332 = false;
            A14PersonaNome = P00332_A14PersonaNome[0];
            A15PersonaAtivo = P00332_A15PersonaAtivo[0];
            A13PersonaId = P00332_A13PersonaId[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00332_A14PersonaNome[0], A14PersonaNome) == 0 ) )
            {
               BRK332 = false;
               A13PersonaId = P00332_A13PersonaId[0];
               AV34count = (long)(AV34count+1);
               BRK332 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A14PersonaNome)) ? "<#Empty#>" : A14PersonaNome);
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRK332 )
            {
               BRK332 = true;
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
         AV28OptionsJson = "";
         AV31OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV15TFPersonaNome = "";
         AV16TFPersonaNome_Sel = "";
         AV45Personawwds_1_filterfulltext = "";
         AV46Personawwds_2_tfpersonanome = "";
         AV47Personawwds_3_tfpersonanome_sel = "";
         scmdbuf = "";
         lV45Personawwds_1_filterfulltext = "";
         lV46Personawwds_2_tfpersonanome = "";
         A14PersonaNome = "";
         P00332_A14PersonaNome = new string[] {""} ;
         P00332_A15PersonaAtivo = new bool[] {false} ;
         P00332_A13PersonaId = new int[1] ;
         AV26Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.personawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00332_A14PersonaNome, P00332_A15PersonaAtivo, P00332_A13PersonaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV17TFPersonaAtivo_Sel ;
      private short AV48Personawwds_4_tfpersonaativo_sel ;
      private int AV43GXV1 ;
      private int A13PersonaId ;
      private long AV34count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A15PersonaAtivo ;
      private bool BRK332 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV24DDOName ;
      private string AV18SearchTxtParms ;
      private string AV23SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV40FilterFullText ;
      private string AV15TFPersonaNome ;
      private string AV16TFPersonaNome_Sel ;
      private string AV45Personawwds_1_filterfulltext ;
      private string AV46Personawwds_2_tfpersonanome ;
      private string AV47Personawwds_3_tfpersonanome_sel ;
      private string lV45Personawwds_1_filterfulltext ;
      private string lV46Personawwds_2_tfpersonanome ;
      private string A14PersonaNome ;
      private string AV26Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00332_A14PersonaNome ;
      private bool[] P00332_A15PersonaAtivo ;
      private int[] P00332_A13PersonaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
   }

   public class personawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00332( IGxContext context ,
                                             string AV45Personawwds_1_filterfulltext ,
                                             string AV47Personawwds_3_tfpersonanome_sel ,
                                             string AV46Personawwds_2_tfpersonanome ,
                                             short AV48Personawwds_4_tfpersonaativo_sel ,
                                             string A14PersonaNome ,
                                             bool A15PersonaAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PersonaNome], [PersonaAtivo], [PersonaId] FROM [Persona]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Personawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [PersonaNome] like '%' + @lV45Personawwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV45Personawwds_1_filterfulltext) and [PersonaAtivo] = 1) or ( 'não' like '%' + LOWER(@lV45Personawwds_1_filterfulltext) and [PersonaAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Personawwds_3_tfpersonanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Personawwds_2_tfpersonanome)) ) )
         {
            AddWhere(sWhereString, "([PersonaNome] like @lV46Personawwds_2_tfpersonanome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Personawwds_3_tfpersonanome_sel)) && ! ( StringUtil.StrCmp(AV47Personawwds_3_tfpersonanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PersonaNome] = @AV47Personawwds_3_tfpersonanome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV47Personawwds_3_tfpersonanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PersonaNome] = ''))");
         }
         if ( AV48Personawwds_4_tfpersonaativo_sel == 1 )
         {
            AddWhere(sWhereString, "([PersonaAtivo] = 1)");
         }
         if ( AV48Personawwds_4_tfpersonaativo_sel == 2 )
         {
            AddWhere(sWhereString, "([PersonaAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PersonaNome]";
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
                     return conditional_P00332(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP00332;
          prmP00332 = new Object[] {
          new ParDef("@lV45Personawwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV45Personawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Personawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Personawwds_2_tfpersonanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV47Personawwds_3_tfpersonanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00332", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00332,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.personawwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class personawwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "PersonaWWGetFilterData" )]
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
          permissionPrefix = "personaww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("personawwgetfilterdata") )
          {
             return  ;
          }
          personawwgetfilterdata worker = new personawwgetfilterdata(context);
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
