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
   public class campowwgetfilterdata : GXProcedure
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
            return "campoww_Services_Execute" ;
         }

      }

      public campowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public campowwgetfilterdata( IGxContext context )
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
         this.AV23DDOName = aP0_DDOName;
         this.AV17SearchTxtParms = aP1_SearchTxtParms;
         this.AV22SearchTxtTo = aP2_SearchTxtTo;
         this.AV27OptionsJson = "" ;
         this.AV30OptionsDescJson = "" ;
         this.AV32OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV27OptionsJson;
         aP4_OptionsDescJson=this.AV30OptionsDescJson;
         aP5_OptionIndexesJson=this.AV32OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV32OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         campowwgetfilterdata objcampowwgetfilterdata;
         objcampowwgetfilterdata = new campowwgetfilterdata();
         objcampowwgetfilterdata.AV23DDOName = aP0_DDOName;
         objcampowwgetfilterdata.AV17SearchTxtParms = aP1_SearchTxtParms;
         objcampowwgetfilterdata.AV22SearchTxtTo = aP2_SearchTxtTo;
         objcampowwgetfilterdata.AV27OptionsJson = "" ;
         objcampowwgetfilterdata.AV30OptionsDescJson = "" ;
         objcampowwgetfilterdata.AV32OptionIndexesJson = "" ;
         objcampowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcampowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objcampowwgetfilterdata);
         aP3_OptionsJson=this.AV27OptionsJson;
         aP4_OptionsDescJson=this.AV30OptionsDescJson;
         aP5_OptionIndexesJson=this.AV32OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((campowwgetfilterdata)stateInfo).executePrivate();
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
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV17SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV17SearchTxtParms, 1, 2), "."))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV17SearchTxtParms)) ? "" : StringUtil.Substring( AV17SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV23DDOName), "DDO_CAMPONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCAMPONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV23DDOName), "DDO_TELANOME") == 0 )
         {
            /* Execute user subroutine: 'LOADTELANOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV27OptionsJson = AV26Options.ToJSonString(false);
         AV30OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV32OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("CampoWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CampoWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("CampoWWGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCAMPONOME") == 0 )
            {
               AV13TFCampoNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCAMPONOME_SEL") == 0 )
            {
               AV14TFCampoNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCAMPOATIVO_SEL") == 0 )
            {
               AV40TFCampoAtivo_Sel = (short)(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTELANOME") == 0 )
            {
               AV41TFTelaNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTELANOME_SEL") == 0 )
            {
               AV42TFTelaNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCAMPONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFCampoNome = AV21SearchTxt;
         AV14TFCampoNome_Sel = "";
         AV47Campowwds_1_filterfulltext = AV39FilterFullText;
         AV48Campowwds_2_tfcamponome = AV13TFCampoNome;
         AV49Campowwds_3_tfcamponome_sel = AV14TFCampoNome_Sel;
         AV50Campowwds_4_tfcampoativo_sel = AV40TFCampoAtivo_Sel;
         AV51Campowwds_5_tftelanome = AV41TFTelaNome;
         AV52Campowwds_6_tftelanome_sel = AV42TFTelaNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Campowwds_1_filterfulltext ,
                                              AV49Campowwds_3_tfcamponome_sel ,
                                              AV48Campowwds_2_tfcamponome ,
                                              AV50Campowwds_4_tfcampoativo_sel ,
                                              AV52Campowwds_6_tftelanome_sel ,
                                              AV51Campowwds_5_tftelanome ,
                                              A136CampoNome ,
                                              A138CampoAtivo ,
                                              A134TelaNome } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV48Campowwds_2_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV48Campowwds_2_tfcamponome), "%", "");
         lV51Campowwds_5_tftelanome = StringUtil.Concat( StringUtil.RTrim( AV51Campowwds_5_tftelanome), "%", "");
         /* Using cursor P006P2 */
         pr_default.execute(0, new Object[] {lV47Campowwds_1_filterfulltext, lV47Campowwds_1_filterfulltext, lV47Campowwds_1_filterfulltext, lV47Campowwds_1_filterfulltext, lV48Campowwds_2_tfcamponome, AV49Campowwds_3_tfcamponome_sel, lV51Campowwds_5_tftelanome, AV52Campowwds_6_tftelanome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6P2 = false;
            A133TelaId = P006P2_A133TelaId[0];
            A136CampoNome = P006P2_A136CampoNome[0];
            A134TelaNome = P006P2_A134TelaNome[0];
            A138CampoAtivo = P006P2_A138CampoAtivo[0];
            A135CampoId = P006P2_A135CampoId[0];
            A134TelaNome = P006P2_A134TelaNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006P2_A136CampoNome[0], A136CampoNome) == 0 ) )
            {
               BRK6P2 = false;
               A135CampoId = P006P2_A135CampoId[0];
               AV33count = (long)(AV33count+1);
               BRK6P2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A136CampoNome)) ? "<#Empty#>" : A136CampoNome);
               AV26Options.Add(AV25Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK6P2 )
            {
               BRK6P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTELANOMEOPTIONS' Routine */
         returnInSub = false;
         AV41TFTelaNome = AV21SearchTxt;
         AV42TFTelaNome_Sel = "";
         AV47Campowwds_1_filterfulltext = AV39FilterFullText;
         AV48Campowwds_2_tfcamponome = AV13TFCampoNome;
         AV49Campowwds_3_tfcamponome_sel = AV14TFCampoNome_Sel;
         AV50Campowwds_4_tfcampoativo_sel = AV40TFCampoAtivo_Sel;
         AV51Campowwds_5_tftelanome = AV41TFTelaNome;
         AV52Campowwds_6_tftelanome_sel = AV42TFTelaNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47Campowwds_1_filterfulltext ,
                                              AV49Campowwds_3_tfcamponome_sel ,
                                              AV48Campowwds_2_tfcamponome ,
                                              AV50Campowwds_4_tfcampoativo_sel ,
                                              AV52Campowwds_6_tftelanome_sel ,
                                              AV51Campowwds_5_tftelanome ,
                                              A136CampoNome ,
                                              A138CampoAtivo ,
                                              A134TelaNome } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV47Campowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Campowwds_1_filterfulltext), "%", "");
         lV48Campowwds_2_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV48Campowwds_2_tfcamponome), "%", "");
         lV51Campowwds_5_tftelanome = StringUtil.Concat( StringUtil.RTrim( AV51Campowwds_5_tftelanome), "%", "");
         /* Using cursor P006P3 */
         pr_default.execute(1, new Object[] {lV47Campowwds_1_filterfulltext, lV47Campowwds_1_filterfulltext, lV47Campowwds_1_filterfulltext, lV47Campowwds_1_filterfulltext, lV48Campowwds_2_tfcamponome, AV49Campowwds_3_tfcamponome_sel, lV51Campowwds_5_tftelanome, AV52Campowwds_6_tftelanome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6P4 = false;
            A133TelaId = P006P3_A133TelaId[0];
            A134TelaNome = P006P3_A134TelaNome[0];
            A138CampoAtivo = P006P3_A138CampoAtivo[0];
            A136CampoNome = P006P3_A136CampoNome[0];
            A135CampoId = P006P3_A135CampoId[0];
            A134TelaNome = P006P3_A134TelaNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006P3_A134TelaNome[0], A134TelaNome) == 0 ) )
            {
               BRK6P4 = false;
               A133TelaId = P006P3_A133TelaId[0];
               A135CampoId = P006P3_A135CampoId[0];
               AV33count = (long)(AV33count+1);
               BRK6P4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A134TelaNome)) ? "<#Empty#>" : A134TelaNome);
               AV26Options.Add(AV25Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK6P4 )
            {
               BRK6P4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV27OptionsJson = "";
         AV30OptionsDescJson = "";
         AV32OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV13TFCampoNome = "";
         AV14TFCampoNome_Sel = "";
         AV41TFTelaNome = "";
         AV42TFTelaNome_Sel = "";
         AV47Campowwds_1_filterfulltext = "";
         AV48Campowwds_2_tfcamponome = "";
         AV49Campowwds_3_tfcamponome_sel = "";
         AV51Campowwds_5_tftelanome = "";
         AV52Campowwds_6_tftelanome_sel = "";
         scmdbuf = "";
         lV47Campowwds_1_filterfulltext = "";
         lV48Campowwds_2_tfcamponome = "";
         lV51Campowwds_5_tftelanome = "";
         A136CampoNome = "";
         A134TelaNome = "";
         P006P2_A133TelaId = new int[1] ;
         P006P2_A136CampoNome = new string[] {""} ;
         P006P2_A134TelaNome = new string[] {""} ;
         P006P2_A138CampoAtivo = new bool[] {false} ;
         P006P2_A135CampoId = new int[1] ;
         AV25Option = "";
         P006P3_A133TelaId = new int[1] ;
         P006P3_A134TelaNome = new string[] {""} ;
         P006P3_A138CampoAtivo = new bool[] {false} ;
         P006P3_A136CampoNome = new string[] {""} ;
         P006P3_A135CampoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.campowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006P2_A133TelaId, P006P2_A136CampoNome, P006P2_A134TelaNome, P006P2_A138CampoAtivo, P006P2_A135CampoId
               }
               , new Object[] {
               P006P3_A133TelaId, P006P3_A134TelaNome, P006P3_A138CampoAtivo, P006P3_A136CampoNome, P006P3_A135CampoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV40TFCampoAtivo_Sel ;
      private short AV50Campowwds_4_tfcampoativo_sel ;
      private int AV45GXV1 ;
      private int A133TelaId ;
      private int A135CampoId ;
      private long AV33count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A138CampoAtivo ;
      private bool BRK6P2 ;
      private bool BRK6P4 ;
      private string AV27OptionsJson ;
      private string AV30OptionsDescJson ;
      private string AV32OptionIndexesJson ;
      private string AV23DDOName ;
      private string AV17SearchTxtParms ;
      private string AV22SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV39FilterFullText ;
      private string AV13TFCampoNome ;
      private string AV14TFCampoNome_Sel ;
      private string AV41TFTelaNome ;
      private string AV42TFTelaNome_Sel ;
      private string AV47Campowwds_1_filterfulltext ;
      private string AV48Campowwds_2_tfcamponome ;
      private string AV49Campowwds_3_tfcamponome_sel ;
      private string AV51Campowwds_5_tftelanome ;
      private string AV52Campowwds_6_tftelanome_sel ;
      private string lV47Campowwds_1_filterfulltext ;
      private string lV48Campowwds_2_tfcamponome ;
      private string lV51Campowwds_5_tftelanome ;
      private string A136CampoNome ;
      private string A134TelaNome ;
      private string AV25Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006P2_A133TelaId ;
      private string[] P006P2_A136CampoNome ;
      private string[] P006P2_A134TelaNome ;
      private bool[] P006P2_A138CampoAtivo ;
      private int[] P006P2_A135CampoId ;
      private int[] P006P3_A133TelaId ;
      private string[] P006P3_A134TelaNome ;
      private bool[] P006P3_A138CampoAtivo ;
      private string[] P006P3_A136CampoNome ;
      private int[] P006P3_A135CampoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
   }

   public class campowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006P2( IGxContext context ,
                                             string AV47Campowwds_1_filterfulltext ,
                                             string AV49Campowwds_3_tfcamponome_sel ,
                                             string AV48Campowwds_2_tfcamponome ,
                                             short AV50Campowwds_4_tfcampoativo_sel ,
                                             string AV52Campowwds_6_tftelanome_sel ,
                                             string AV51Campowwds_5_tftelanome ,
                                             string A136CampoNome ,
                                             bool A138CampoAtivo ,
                                             string A134TelaNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TelaId], T1.[CampoNome], T2.[TelaNome], T1.[CampoAtivo], T1.[CampoId] FROM ([Campo] T1 INNER JOIN [Tela] T2 ON T2.[TelaId] = T1.[TelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Campowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.[CampoNome] like '%' + @lV47Campowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV47Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV47Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 0) or ( T2.[TelaNome] like '%' + @lV47Campowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Campowwds_3_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Campowwds_2_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] like @lV48Campowwds_2_tfcamponome)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Campowwds_3_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV49Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] = @AV49Campowwds_3_tfcamponome_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV49Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CampoNome] = ''))");
         }
         if ( AV50Campowwds_4_tfcampoativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 1)");
         }
         if ( AV50Campowwds_4_tfcampoativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Campowwds_6_tftelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Campowwds_5_tftelanome)) ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] like @lV51Campowwds_5_tftelanome)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Campowwds_6_tftelanome_sel)) && ! ( StringUtil.StrCmp(AV52Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] = @AV52Campowwds_6_tftelanome_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TelaNome] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CampoNome]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006P3( IGxContext context ,
                                             string AV47Campowwds_1_filterfulltext ,
                                             string AV49Campowwds_3_tfcamponome_sel ,
                                             string AV48Campowwds_2_tfcamponome ,
                                             short AV50Campowwds_4_tfcampoativo_sel ,
                                             string AV52Campowwds_6_tftelanome_sel ,
                                             string AV51Campowwds_5_tftelanome ,
                                             string A136CampoNome ,
                                             bool A138CampoAtivo ,
                                             string A134TelaNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TelaId], T2.[TelaNome], T1.[CampoAtivo], T1.[CampoNome], T1.[CampoId] FROM ([Campo] T1 INNER JOIN [Tela] T2 ON T2.[TelaId] = T1.[TelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Campowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.[CampoNome] like '%' + @lV47Campowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV47Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 1) or ( 'não' like '%' + LOWER(@lV47Campowwds_1_filterfulltext) and T1.[CampoAtivo] = 0) or ( T2.[TelaNome] like '%' + @lV47Campowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Campowwds_3_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Campowwds_2_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] like @lV48Campowwds_2_tfcamponome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Campowwds_3_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV49Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CampoNome] = @AV49Campowwds_3_tfcamponome_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV49Campowwds_3_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CampoNome] = ''))");
         }
         if ( AV50Campowwds_4_tfcampoativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 1)");
         }
         if ( AV50Campowwds_4_tfcampoativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[CampoAtivo] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Campowwds_6_tftelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Campowwds_5_tftelanome)) ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] like @lV51Campowwds_5_tftelanome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Campowwds_6_tftelanome_sel)) && ! ( StringUtil.StrCmp(AV52Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] = @AV52Campowwds_6_tftelanome_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Campowwds_6_tftelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TelaNome] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[TelaNome]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006P2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] );
               case 1 :
                     return conditional_P006P3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP006P2;
          prmP006P2 = new Object[] {
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV48Campowwds_2_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV49Campowwds_3_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Campowwds_5_tftelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Campowwds_6_tftelanome_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP006P3;
          prmP006P3 = new Object[] {
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV47Campowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV48Campowwds_2_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV49Campowwds_3_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Campowwds_5_tftelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Campowwds_6_tftelanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.campowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class campowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "CampoWWGetFilterData" )]
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
          permissionPrefix = "campoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("campowwgetfilterdata") )
          {
             return  ;
          }
          campowwgetfilterdata worker = new campowwgetfilterdata(context);
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
