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
   public class encarregadowwgetfilterdata : GXProcedure
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
            return "encarregadoww_Services_Execute" ;
         }

      }

      public encarregadowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public encarregadowwgetfilterdata( IGxContext context )
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
         encarregadowwgetfilterdata objencarregadowwgetfilterdata;
         objencarregadowwgetfilterdata = new encarregadowwgetfilterdata();
         objencarregadowwgetfilterdata.AV22DDOName = aP0_DDOName;
         objencarregadowwgetfilterdata.AV16SearchTxtParms = aP1_SearchTxtParms;
         objencarregadowwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objencarregadowwgetfilterdata.AV26OptionsJson = "" ;
         objencarregadowwgetfilterdata.AV29OptionsDescJson = "" ;
         objencarregadowwgetfilterdata.AV31OptionIndexesJson = "" ;
         objencarregadowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objencarregadowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objencarregadowwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((encarregadowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_ENCARREGADONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADENCARREGADONOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("EncarregadoWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EncarregadoWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("EncarregadoWWGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENCARREGADONOME") == 0 )
            {
               AV13TFEncarregadoNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENCARREGADONOME_SEL") == 0 )
            {
               AV14TFEncarregadoNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENCARREGADOATIVO_SEL") == 0 )
            {
               AV15TFEncarregadoAtivo_Sel = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADENCARREGADONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFEncarregadoNome = AV20SearchTxt;
         AV14TFEncarregadoNome_Sel = "";
         AV43Encarregadowwds_1_filterfulltext = AV38FilterFullText;
         AV44Encarregadowwds_2_tfencarregadonome = AV13TFEncarregadoNome;
         AV45Encarregadowwds_3_tfencarregadonome_sel = AV14TFEncarregadoNome_Sel;
         AV46Encarregadowwds_4_tfencarregadoativo_sel = AV15TFEncarregadoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Encarregadowwds_1_filterfulltext ,
                                              AV45Encarregadowwds_3_tfencarregadonome_sel ,
                                              AV44Encarregadowwds_2_tfencarregadonome ,
                                              AV46Encarregadowwds_4_tfencarregadoativo_sel ,
                                              A8EncarregadoNome ,
                                              A9EncarregadoAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Encarregadowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Encarregadowwds_1_filterfulltext), "%", "");
         lV43Encarregadowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Encarregadowwds_1_filterfulltext), "%", "");
         lV43Encarregadowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Encarregadowwds_1_filterfulltext), "%", "");
         lV44Encarregadowwds_2_tfencarregadonome = StringUtil.Concat( StringUtil.RTrim( AV44Encarregadowwds_2_tfencarregadonome), "%", "");
         /* Using cursor P003A2 */
         pr_default.execute(0, new Object[] {lV43Encarregadowwds_1_filterfulltext, lV43Encarregadowwds_1_filterfulltext, lV43Encarregadowwds_1_filterfulltext, lV44Encarregadowwds_2_tfencarregadonome, AV45Encarregadowwds_3_tfencarregadonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3A2 = false;
            A8EncarregadoNome = P003A2_A8EncarregadoNome[0];
            A9EncarregadoAtivo = P003A2_A9EncarregadoAtivo[0];
            A7EncarregadoId = P003A2_A7EncarregadoId[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003A2_A8EncarregadoNome[0], A8EncarregadoNome) == 0 ) )
            {
               BRK3A2 = false;
               A7EncarregadoId = P003A2_A7EncarregadoId[0];
               AV32count = (long)(AV32count+1);
               BRK3A2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A8EncarregadoNome)) ? "<#Empty#>" : A8EncarregadoNome);
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
            if ( ! BRK3A2 )
            {
               BRK3A2 = true;
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
         AV13TFEncarregadoNome = "";
         AV14TFEncarregadoNome_Sel = "";
         AV43Encarregadowwds_1_filterfulltext = "";
         AV44Encarregadowwds_2_tfencarregadonome = "";
         AV45Encarregadowwds_3_tfencarregadonome_sel = "";
         scmdbuf = "";
         lV43Encarregadowwds_1_filterfulltext = "";
         lV44Encarregadowwds_2_tfencarregadonome = "";
         A8EncarregadoNome = "";
         P003A2_A8EncarregadoNome = new string[] {""} ;
         P003A2_A9EncarregadoAtivo = new bool[] {false} ;
         P003A2_A7EncarregadoId = new int[1] ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.encarregadowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003A2_A8EncarregadoNome, P003A2_A9EncarregadoAtivo, P003A2_A7EncarregadoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV15TFEncarregadoAtivo_Sel ;
      private short AV46Encarregadowwds_4_tfencarregadoativo_sel ;
      private int AV41GXV1 ;
      private int A7EncarregadoId ;
      private long AV32count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A9EncarregadoAtivo ;
      private bool BRK3A2 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV22DDOName ;
      private string AV16SearchTxtParms ;
      private string AV21SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV38FilterFullText ;
      private string AV13TFEncarregadoNome ;
      private string AV14TFEncarregadoNome_Sel ;
      private string AV43Encarregadowwds_1_filterfulltext ;
      private string AV44Encarregadowwds_2_tfencarregadonome ;
      private string AV45Encarregadowwds_3_tfencarregadonome_sel ;
      private string lV43Encarregadowwds_1_filterfulltext ;
      private string lV44Encarregadowwds_2_tfencarregadonome ;
      private string A8EncarregadoNome ;
      private string AV24Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003A2_A8EncarregadoNome ;
      private bool[] P003A2_A9EncarregadoAtivo ;
      private int[] P003A2_A7EncarregadoId ;
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

   public class encarregadowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003A2( IGxContext context ,
                                             string AV43Encarregadowwds_1_filterfulltext ,
                                             string AV45Encarregadowwds_3_tfencarregadonome_sel ,
                                             string AV44Encarregadowwds_2_tfencarregadonome ,
                                             short AV46Encarregadowwds_4_tfencarregadoativo_sel ,
                                             string A8EncarregadoNome ,
                                             bool A9EncarregadoAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [EncarregadoNome], [EncarregadoAtivo], [EncarregadoId] FROM [Encarregado]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Encarregadowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [EncarregadoNome] like '%' + @lV43Encarregadowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV43Encarregadowwds_1_filterfulltext) and [EncarregadoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV43Encarregadowwds_1_filterfulltext) and [EncarregadoAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Encarregadowwds_3_tfencarregadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Encarregadowwds_2_tfencarregadonome)) ) )
         {
            AddWhere(sWhereString, "([EncarregadoNome] like @lV44Encarregadowwds_2_tfencarregadonome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Encarregadowwds_3_tfencarregadonome_sel)) && ! ( StringUtil.StrCmp(AV45Encarregadowwds_3_tfencarregadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EncarregadoNome] = @AV45Encarregadowwds_3_tfencarregadonome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV45Encarregadowwds_3_tfencarregadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EncarregadoNome] = ''))");
         }
         if ( AV46Encarregadowwds_4_tfencarregadoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([EncarregadoAtivo] = 1)");
         }
         if ( AV46Encarregadowwds_4_tfencarregadoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([EncarregadoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EncarregadoNome]";
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
                     return conditional_P003A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP003A2;
          prmP003A2 = new Object[] {
          new ParDef("@lV43Encarregadowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV43Encarregadowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV43Encarregadowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Encarregadowwds_2_tfencarregadonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV45Encarregadowwds_3_tfencarregadonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003A2,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.encarregadowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class encarregadowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "EncarregadoWWGetFilterData" )]
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
          permissionPrefix = "encarregadoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("encarregadowwgetfilterdata") )
          {
             return  ;
          }
          encarregadowwgetfilterdata worker = new encarregadowwgetfilterdata(context);
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
