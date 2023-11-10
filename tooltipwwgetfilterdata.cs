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
   public class tooltipwwgetfilterdata : GXProcedure
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
            return "tooltipww_Services_Execute" ;
         }

      }

      public tooltipwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tooltipwwgetfilterdata( IGxContext context )
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
         tooltipwwgetfilterdata objtooltipwwgetfilterdata;
         objtooltipwwgetfilterdata = new tooltipwwgetfilterdata();
         objtooltipwwgetfilterdata.AV28DDOName = aP0_DDOName;
         objtooltipwwgetfilterdata.AV22SearchTxtParms = aP1_SearchTxtParms;
         objtooltipwwgetfilterdata.AV27SearchTxtTo = aP2_SearchTxtTo;
         objtooltipwwgetfilterdata.AV32OptionsJson = "" ;
         objtooltipwwgetfilterdata.AV35OptionsDescJson = "" ;
         objtooltipwwgetfilterdata.AV37OptionIndexesJson = "" ;
         objtooltipwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtooltipwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objtooltipwwgetfilterdata);
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tooltipwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_TOOLTIPTELANOME") == 0 )
         {
            /* Execute user subroutine: 'LOADTOOLTIPTELANOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_CAMPONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCAMPONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_TOOLTIPDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTOOLTIPDESCRICAOOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV39Session.Get("TooltipWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TooltipWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("TooltipWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOOLTIPTELANOME") == 0 )
            {
               AV45TFTooltipTelaNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOOLTIPTELANOME_SEL") == 0 )
            {
               AV46TFTooltipTelaNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCAMPONOME") == 0 )
            {
               AV20TFCampoNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCAMPONOME_SEL") == 0 )
            {
               AV21TFCampoNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOOLTIPDESCRICAO") == 0 )
            {
               AV15TFTooltipDescricao = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOOLTIPDESCRICAO_SEL") == 0 )
            {
               AV16TFTooltipDescricao_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOOLTIPATIVO_SEL") == 0 )
            {
               AV17TFTooltipAtivo_Sel = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTOOLTIPTELANOMEOPTIONS' Routine */
         returnInSub = false;
         AV45TFTooltipTelaNome = AV26SearchTxt;
         AV46TFTooltipTelaNome_Sel = "";
         AV51Tooltipwwds_1_filterfulltext = AV44FilterFullText;
         AV52Tooltipwwds_2_tftooltiptelanome = AV45TFTooltipTelaNome;
         AV53Tooltipwwds_3_tftooltiptelanome_sel = AV46TFTooltipTelaNome_Sel;
         AV54Tooltipwwds_4_tfcamponome = AV20TFCampoNome;
         AV55Tooltipwwds_5_tfcamponome_sel = AV21TFCampoNome_Sel;
         AV56Tooltipwwds_6_tftooltipdescricao = AV15TFTooltipDescricao;
         AV57Tooltipwwds_7_tftooltipdescricao_sel = AV16TFTooltipDescricao_Sel;
         AV58Tooltipwwds_8_tftooltipativo_sel = AV17TFTooltipAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Tooltipwwds_1_filterfulltext ,
                                              AV53Tooltipwwds_3_tftooltiptelanome_sel ,
                                              AV52Tooltipwwds_2_tftooltiptelanome ,
                                              AV55Tooltipwwds_5_tfcamponome_sel ,
                                              AV54Tooltipwwds_4_tfcamponome ,
                                              AV57Tooltipwwds_7_tftooltipdescricao_sel ,
                                              AV56Tooltipwwds_6_tftooltipdescricao ,
                                              AV58Tooltipwwds_8_tftooltipativo_sel ,
                                              A140TooltipTelaNome ,
                                              A136CampoNome ,
                                              A115TooltipDescricao ,
                                              A118TooltipAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV52Tooltipwwds_2_tftooltiptelanome = StringUtil.Concat( StringUtil.RTrim( AV52Tooltipwwds_2_tftooltiptelanome), "%", "");
         lV54Tooltipwwds_4_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_4_tfcamponome), "%", "");
         lV56Tooltipwwds_6_tftooltipdescricao = StringUtil.Concat( StringUtil.RTrim( AV56Tooltipwwds_6_tftooltipdescricao), "%", "");
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV52Tooltipwwds_2_tftooltiptelanome, AV53Tooltipwwds_3_tftooltiptelanome_sel, lV54Tooltipwwds_4_tfcamponome, AV55Tooltipwwds_5_tfcamponome_sel, lV56Tooltipwwds_6_tftooltipdescricao, AV57Tooltipwwds_7_tftooltipdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6N2 = false;
            A135CampoId = P006N2_A135CampoId[0];
            A139TooltipTelaId = P006N2_A139TooltipTelaId[0];
            A118TooltipAtivo = P006N2_A118TooltipAtivo[0];
            A115TooltipDescricao = P006N2_A115TooltipDescricao[0];
            A136CampoNome = P006N2_A136CampoNome[0];
            A140TooltipTelaNome = P006N2_A140TooltipTelaNome[0];
            A112TooltipId = P006N2_A112TooltipId[0];
            A136CampoNome = P006N2_A136CampoNome[0];
            A140TooltipTelaNome = P006N2_A140TooltipTelaNome[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P006N2_A139TooltipTelaId[0] == A139TooltipTelaId ) )
            {
               BRK6N2 = false;
               A112TooltipId = P006N2_A112TooltipId[0];
               AV38count = (long)(AV38count+1);
               BRK6N2 = true;
               pr_default.readNext(0);
            }
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A140TooltipTelaNome)) ? "<#Empty#>" : A140TooltipTelaNome);
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            AV31Options.Add(AV30Option, AV29InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            if ( AV31Options.Count == AV23SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRK6N2 )
            {
               BRK6N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV23SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADCAMPONOMEOPTIONS' Routine */
         returnInSub = false;
         AV20TFCampoNome = AV26SearchTxt;
         AV21TFCampoNome_Sel = "";
         AV51Tooltipwwds_1_filterfulltext = AV44FilterFullText;
         AV52Tooltipwwds_2_tftooltiptelanome = AV45TFTooltipTelaNome;
         AV53Tooltipwwds_3_tftooltiptelanome_sel = AV46TFTooltipTelaNome_Sel;
         AV54Tooltipwwds_4_tfcamponome = AV20TFCampoNome;
         AV55Tooltipwwds_5_tfcamponome_sel = AV21TFCampoNome_Sel;
         AV56Tooltipwwds_6_tftooltipdescricao = AV15TFTooltipDescricao;
         AV57Tooltipwwds_7_tftooltipdescricao_sel = AV16TFTooltipDescricao_Sel;
         AV58Tooltipwwds_8_tftooltipativo_sel = AV17TFTooltipAtivo_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV51Tooltipwwds_1_filterfulltext ,
                                              AV53Tooltipwwds_3_tftooltiptelanome_sel ,
                                              AV52Tooltipwwds_2_tftooltiptelanome ,
                                              AV55Tooltipwwds_5_tfcamponome_sel ,
                                              AV54Tooltipwwds_4_tfcamponome ,
                                              AV57Tooltipwwds_7_tftooltipdescricao_sel ,
                                              AV56Tooltipwwds_6_tftooltipdescricao ,
                                              AV58Tooltipwwds_8_tftooltipativo_sel ,
                                              A140TooltipTelaNome ,
                                              A136CampoNome ,
                                              A115TooltipDescricao ,
                                              A118TooltipAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV52Tooltipwwds_2_tftooltiptelanome = StringUtil.Concat( StringUtil.RTrim( AV52Tooltipwwds_2_tftooltiptelanome), "%", "");
         lV54Tooltipwwds_4_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_4_tfcamponome), "%", "");
         lV56Tooltipwwds_6_tftooltipdescricao = StringUtil.Concat( StringUtil.RTrim( AV56Tooltipwwds_6_tftooltipdescricao), "%", "");
         /* Using cursor P006N3 */
         pr_default.execute(1, new Object[] {lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV52Tooltipwwds_2_tftooltiptelanome, AV53Tooltipwwds_3_tftooltiptelanome_sel, lV54Tooltipwwds_4_tfcamponome, AV55Tooltipwwds_5_tfcamponome_sel, lV56Tooltipwwds_6_tftooltipdescricao, AV57Tooltipwwds_7_tftooltipdescricao_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6N4 = false;
            A139TooltipTelaId = P006N3_A139TooltipTelaId[0];
            A135CampoId = P006N3_A135CampoId[0];
            A118TooltipAtivo = P006N3_A118TooltipAtivo[0];
            A115TooltipDescricao = P006N3_A115TooltipDescricao[0];
            A136CampoNome = P006N3_A136CampoNome[0];
            A140TooltipTelaNome = P006N3_A140TooltipTelaNome[0];
            A112TooltipId = P006N3_A112TooltipId[0];
            A140TooltipTelaNome = P006N3_A140TooltipTelaNome[0];
            A136CampoNome = P006N3_A136CampoNome[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006N3_A135CampoId[0] == A135CampoId ) )
            {
               BRK6N4 = false;
               A112TooltipId = P006N3_A112TooltipId[0];
               AV38count = (long)(AV38count+1);
               BRK6N4 = true;
               pr_default.readNext(1);
            }
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A136CampoNome)) ? "<#Empty#>" : A136CampoNome);
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            AV31Options.Add(AV30Option, AV29InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            if ( AV31Options.Count == AV23SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRK6N4 )
            {
               BRK6N4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV23SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADTOOLTIPDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV15TFTooltipDescricao = AV26SearchTxt;
         AV16TFTooltipDescricao_Sel = "";
         AV51Tooltipwwds_1_filterfulltext = AV44FilterFullText;
         AV52Tooltipwwds_2_tftooltiptelanome = AV45TFTooltipTelaNome;
         AV53Tooltipwwds_3_tftooltiptelanome_sel = AV46TFTooltipTelaNome_Sel;
         AV54Tooltipwwds_4_tfcamponome = AV20TFCampoNome;
         AV55Tooltipwwds_5_tfcamponome_sel = AV21TFCampoNome_Sel;
         AV56Tooltipwwds_6_tftooltipdescricao = AV15TFTooltipDescricao;
         AV57Tooltipwwds_7_tftooltipdescricao_sel = AV16TFTooltipDescricao_Sel;
         AV58Tooltipwwds_8_tftooltipativo_sel = AV17TFTooltipAtivo_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV51Tooltipwwds_1_filterfulltext ,
                                              AV53Tooltipwwds_3_tftooltiptelanome_sel ,
                                              AV52Tooltipwwds_2_tftooltiptelanome ,
                                              AV55Tooltipwwds_5_tfcamponome_sel ,
                                              AV54Tooltipwwds_4_tfcamponome ,
                                              AV57Tooltipwwds_7_tftooltipdescricao_sel ,
                                              AV56Tooltipwwds_6_tftooltipdescricao ,
                                              AV58Tooltipwwds_8_tftooltipativo_sel ,
                                              A140TooltipTelaNome ,
                                              A136CampoNome ,
                                              A115TooltipDescricao ,
                                              A118TooltipAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV51Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext), "%", "");
         lV52Tooltipwwds_2_tftooltiptelanome = StringUtil.Concat( StringUtil.RTrim( AV52Tooltipwwds_2_tftooltiptelanome), "%", "");
         lV54Tooltipwwds_4_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_4_tfcamponome), "%", "");
         lV56Tooltipwwds_6_tftooltipdescricao = StringUtil.Concat( StringUtil.RTrim( AV56Tooltipwwds_6_tftooltipdescricao), "%", "");
         /* Using cursor P006N4 */
         pr_default.execute(2, new Object[] {lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV51Tooltipwwds_1_filterfulltext, lV52Tooltipwwds_2_tftooltiptelanome, AV53Tooltipwwds_3_tftooltiptelanome_sel, lV54Tooltipwwds_4_tfcamponome, AV55Tooltipwwds_5_tfcamponome_sel, lV56Tooltipwwds_6_tftooltipdescricao, AV57Tooltipwwds_7_tftooltipdescricao_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6N6 = false;
            A135CampoId = P006N4_A135CampoId[0];
            A139TooltipTelaId = P006N4_A139TooltipTelaId[0];
            A115TooltipDescricao = P006N4_A115TooltipDescricao[0];
            A118TooltipAtivo = P006N4_A118TooltipAtivo[0];
            A136CampoNome = P006N4_A136CampoNome[0];
            A140TooltipTelaNome = P006N4_A140TooltipTelaNome[0];
            A112TooltipId = P006N4_A112TooltipId[0];
            A136CampoNome = P006N4_A136CampoNome[0];
            A140TooltipTelaNome = P006N4_A140TooltipTelaNome[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006N4_A115TooltipDescricao[0], A115TooltipDescricao) == 0 ) )
            {
               BRK6N6 = false;
               A112TooltipId = P006N4_A112TooltipId[0];
               AV38count = (long)(AV38count+1);
               BRK6N6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV23SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A115TooltipDescricao)) ? "<#Empty#>" : A115TooltipDescricao);
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
            if ( ! BRK6N6 )
            {
               BRK6N6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV45TFTooltipTelaNome = "";
         AV46TFTooltipTelaNome_Sel = "";
         AV20TFCampoNome = "";
         AV21TFCampoNome_Sel = "";
         AV15TFTooltipDescricao = "";
         AV16TFTooltipDescricao_Sel = "";
         AV51Tooltipwwds_1_filterfulltext = "";
         AV52Tooltipwwds_2_tftooltiptelanome = "";
         AV53Tooltipwwds_3_tftooltiptelanome_sel = "";
         AV54Tooltipwwds_4_tfcamponome = "";
         AV55Tooltipwwds_5_tfcamponome_sel = "";
         AV56Tooltipwwds_6_tftooltipdescricao = "";
         AV57Tooltipwwds_7_tftooltipdescricao_sel = "";
         scmdbuf = "";
         lV51Tooltipwwds_1_filterfulltext = "";
         lV52Tooltipwwds_2_tftooltiptelanome = "";
         lV54Tooltipwwds_4_tfcamponome = "";
         lV56Tooltipwwds_6_tftooltipdescricao = "";
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         P006N2_A135CampoId = new int[1] ;
         P006N2_A139TooltipTelaId = new int[1] ;
         P006N2_A118TooltipAtivo = new bool[] {false} ;
         P006N2_A115TooltipDescricao = new string[] {""} ;
         P006N2_A136CampoNome = new string[] {""} ;
         P006N2_A140TooltipTelaNome = new string[] {""} ;
         P006N2_A112TooltipId = new int[1] ;
         AV30Option = "";
         P006N3_A139TooltipTelaId = new int[1] ;
         P006N3_A135CampoId = new int[1] ;
         P006N3_A118TooltipAtivo = new bool[] {false} ;
         P006N3_A115TooltipDescricao = new string[] {""} ;
         P006N3_A136CampoNome = new string[] {""} ;
         P006N3_A140TooltipTelaNome = new string[] {""} ;
         P006N3_A112TooltipId = new int[1] ;
         P006N4_A135CampoId = new int[1] ;
         P006N4_A139TooltipTelaId = new int[1] ;
         P006N4_A115TooltipDescricao = new string[] {""} ;
         P006N4_A118TooltipAtivo = new bool[] {false} ;
         P006N4_A136CampoNome = new string[] {""} ;
         P006N4_A140TooltipTelaNome = new string[] {""} ;
         P006N4_A112TooltipId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tooltipwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006N2_A135CampoId, P006N2_A139TooltipTelaId, P006N2_A118TooltipAtivo, P006N2_A115TooltipDescricao, P006N2_A136CampoNome, P006N2_A140TooltipTelaNome, P006N2_A112TooltipId
               }
               , new Object[] {
               P006N3_A139TooltipTelaId, P006N3_A135CampoId, P006N3_A118TooltipAtivo, P006N3_A115TooltipDescricao, P006N3_A136CampoNome, P006N3_A140TooltipTelaNome, P006N3_A112TooltipId
               }
               , new Object[] {
               P006N4_A135CampoId, P006N4_A139TooltipTelaId, P006N4_A115TooltipDescricao, P006N4_A118TooltipAtivo, P006N4_A136CampoNome, P006N4_A140TooltipTelaNome, P006N4_A112TooltipId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV17TFTooltipAtivo_Sel ;
      private short AV58Tooltipwwds_8_tftooltipativo_sel ;
      private int AV49GXV1 ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int A112TooltipId ;
      private int AV29InsertIndex ;
      private long AV38count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool A118TooltipAtivo ;
      private bool BRK6N2 ;
      private bool BRK6N4 ;
      private bool BRK6N6 ;
      private string AV32OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string A115TooltipDescricao ;
      private string AV28DDOName ;
      private string AV22SearchTxtParms ;
      private string AV27SearchTxtTo ;
      private string AV26SearchTxt ;
      private string AV44FilterFullText ;
      private string AV45TFTooltipTelaNome ;
      private string AV46TFTooltipTelaNome_Sel ;
      private string AV20TFCampoNome ;
      private string AV21TFCampoNome_Sel ;
      private string AV15TFTooltipDescricao ;
      private string AV16TFTooltipDescricao_Sel ;
      private string AV51Tooltipwwds_1_filterfulltext ;
      private string AV52Tooltipwwds_2_tftooltiptelanome ;
      private string AV53Tooltipwwds_3_tftooltiptelanome_sel ;
      private string AV54Tooltipwwds_4_tfcamponome ;
      private string AV55Tooltipwwds_5_tfcamponome_sel ;
      private string AV56Tooltipwwds_6_tftooltipdescricao ;
      private string AV57Tooltipwwds_7_tftooltipdescricao_sel ;
      private string lV51Tooltipwwds_1_filterfulltext ;
      private string lV52Tooltipwwds_2_tftooltiptelanome ;
      private string lV54Tooltipwwds_4_tfcamponome ;
      private string lV56Tooltipwwds_6_tftooltipdescricao ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private string AV30Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006N2_A135CampoId ;
      private int[] P006N2_A139TooltipTelaId ;
      private bool[] P006N2_A118TooltipAtivo ;
      private string[] P006N2_A115TooltipDescricao ;
      private string[] P006N2_A136CampoNome ;
      private string[] P006N2_A140TooltipTelaNome ;
      private int[] P006N2_A112TooltipId ;
      private int[] P006N3_A139TooltipTelaId ;
      private int[] P006N3_A135CampoId ;
      private bool[] P006N3_A118TooltipAtivo ;
      private string[] P006N3_A115TooltipDescricao ;
      private string[] P006N3_A136CampoNome ;
      private string[] P006N3_A140TooltipTelaNome ;
      private int[] P006N3_A112TooltipId ;
      private int[] P006N4_A135CampoId ;
      private int[] P006N4_A139TooltipTelaId ;
      private string[] P006N4_A115TooltipDescricao ;
      private bool[] P006N4_A118TooltipAtivo ;
      private string[] P006N4_A136CampoNome ;
      private string[] P006N4_A140TooltipTelaNome ;
      private int[] P006N4_A112TooltipId ;
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

   public class tooltipwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006N2( IGxContext context ,
                                             string AV51Tooltipwwds_1_filterfulltext ,
                                             string AV53Tooltipwwds_3_tftooltiptelanome_sel ,
                                             string AV52Tooltipwwds_2_tftooltiptelanome ,
                                             string AV55Tooltipwwds_5_tfcamponome_sel ,
                                             string AV54Tooltipwwds_4_tfcamponome ,
                                             string AV57Tooltipwwds_7_tftooltipdescricao_sel ,
                                             string AV56Tooltipwwds_6_tftooltipdescricao ,
                                             short AV58Tooltipwwds_8_tftooltipativo_sel ,
                                             string A140TooltipTelaNome ,
                                             string A136CampoNome ,
                                             string A115TooltipDescricao ,
                                             bool A118TooltipAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T1.[TooltipAtivo], T1.[TooltipDescricao], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipId] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.[TelaNome] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( T2.[CampoNome] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( T1.[TooltipDescricao] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV51Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 1) or ( 'não' like '%' + LOWER(@lV51Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 0))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Tooltipwwds_3_tftooltiptelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Tooltipwwds_2_tftooltiptelanome)) ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] like @lV52Tooltipwwds_2_tftooltiptelanome)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tooltipwwds_3_tftooltiptelanome_sel)) && ! ( StringUtil.StrCmp(AV53Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] = @AV53Tooltipwwds_3_tftooltiptelanome_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[TelaNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_5_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Tooltipwwds_4_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] like @lV54Tooltipwwds_4_tfcamponome)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_5_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV55Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] = @AV55Tooltipwwds_5_tfcamponome_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CampoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_7_tftooltipdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tooltipwwds_6_tftooltipdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] like @lV56Tooltipwwds_6_tftooltipdescricao)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_7_tftooltipdescricao_sel)) && ! ( StringUtil.StrCmp(AV57Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] = @AV57Tooltipwwds_7_tftooltipdescricao_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV57Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[TooltipDescricao])=0))");
         }
         if ( AV58Tooltipwwds_8_tftooltipativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 1)");
         }
         if ( AV58Tooltipwwds_8_tftooltipativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TooltipTelaId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006N3( IGxContext context ,
                                             string AV51Tooltipwwds_1_filterfulltext ,
                                             string AV53Tooltipwwds_3_tftooltiptelanome_sel ,
                                             string AV52Tooltipwwds_2_tftooltiptelanome ,
                                             string AV55Tooltipwwds_5_tfcamponome_sel ,
                                             string AV54Tooltipwwds_4_tfcamponome ,
                                             string AV57Tooltipwwds_7_tftooltipdescricao_sel ,
                                             string AV56Tooltipwwds_6_tftooltipdescricao ,
                                             short AV58Tooltipwwds_8_tftooltipativo_sel ,
                                             string A140TooltipTelaNome ,
                                             string A136CampoNome ,
                                             string A115TooltipDescricao ,
                                             bool A118TooltipAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TooltipTelaId] AS TooltipTelaId, T1.[CampoId], T1.[TooltipAtivo], T1.[TooltipDescricao], T3.[CampoNome], T2.[TelaNome] AS TooltipTelaNome, T1.[TooltipId] FROM (([Tooltip] T1 INNER JOIN [Tela] T2 ON T2.[TelaId] = T1.[TooltipTelaId]) INNER JOIN [Campo] T3 ON T3.[CampoId] = T1.[CampoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.[TelaNome] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( T3.[CampoNome] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( T1.[TooltipDescricao] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV51Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 1) or ( 'não' like '%' + LOWER(@lV51Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 0))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Tooltipwwds_3_tftooltiptelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Tooltipwwds_2_tftooltiptelanome)) ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] like @lV52Tooltipwwds_2_tftooltiptelanome)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tooltipwwds_3_tftooltiptelanome_sel)) && ! ( StringUtil.StrCmp(AV53Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TelaNome] = @AV53Tooltipwwds_3_tftooltiptelanome_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TelaNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_5_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Tooltipwwds_4_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T3.[CampoNome] like @lV54Tooltipwwds_4_tfcamponome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_5_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV55Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[CampoNome] = @AV55Tooltipwwds_5_tfcamponome_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[CampoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_7_tftooltipdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tooltipwwds_6_tftooltipdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] like @lV56Tooltipwwds_6_tftooltipdescricao)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_7_tftooltipdescricao_sel)) && ! ( StringUtil.StrCmp(AV57Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] = @AV57Tooltipwwds_7_tftooltipdescricao_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV57Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[TooltipDescricao])=0))");
         }
         if ( AV58Tooltipwwds_8_tftooltipativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 1)");
         }
         if ( AV58Tooltipwwds_8_tftooltipativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CampoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006N4( IGxContext context ,
                                             string AV51Tooltipwwds_1_filterfulltext ,
                                             string AV53Tooltipwwds_3_tftooltiptelanome_sel ,
                                             string AV52Tooltipwwds_2_tftooltiptelanome ,
                                             string AV55Tooltipwwds_5_tfcamponome_sel ,
                                             string AV54Tooltipwwds_4_tfcamponome ,
                                             string AV57Tooltipwwds_7_tftooltipdescricao_sel ,
                                             string AV56Tooltipwwds_6_tftooltipdescricao ,
                                             short AV58Tooltipwwds_8_tftooltipativo_sel ,
                                             string A140TooltipTelaNome ,
                                             string A136CampoNome ,
                                             string A115TooltipDescricao ,
                                             bool A118TooltipAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T1.[TooltipDescricao], T1.[TooltipAtivo], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipId] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Tooltipwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.[TelaNome] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( T2.[CampoNome] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( T1.[TooltipDescricao] like '%' + @lV51Tooltipwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV51Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 1) or ( 'não' like '%' + LOWER(@lV51Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 0))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Tooltipwwds_3_tftooltiptelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Tooltipwwds_2_tftooltiptelanome)) ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] like @lV52Tooltipwwds_2_tftooltiptelanome)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tooltipwwds_3_tftooltiptelanome_sel)) && ! ( StringUtil.StrCmp(AV53Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] = @AV53Tooltipwwds_3_tftooltiptelanome_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[TelaNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_5_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Tooltipwwds_4_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] like @lV54Tooltipwwds_4_tfcamponome)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_5_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV55Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] = @AV55Tooltipwwds_5_tfcamponome_sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CampoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_7_tftooltipdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tooltipwwds_6_tftooltipdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] like @lV56Tooltipwwds_6_tftooltipdescricao)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_7_tftooltipdescricao_sel)) && ! ( StringUtil.StrCmp(AV57Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] = @AV57Tooltipwwds_7_tftooltipdescricao_sel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV57Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[TooltipDescricao])=0))");
         }
         if ( AV58Tooltipwwds_8_tftooltipativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 1)");
         }
         if ( AV58Tooltipwwds_8_tftooltipativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TooltipDescricao]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] );
               case 1 :
                     return conditional_P006N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] );
               case 2 :
                     return conditional_P006N4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV52Tooltipwwds_2_tftooltiptelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV53Tooltipwwds_3_tftooltiptelanome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_4_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV55Tooltipwwds_5_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Tooltipwwds_6_tftooltipdescricao",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Tooltipwwds_7_tftooltipdescricao_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP006N3;
          prmP006N3 = new Object[] {
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV52Tooltipwwds_2_tftooltiptelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV53Tooltipwwds_3_tftooltiptelanome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_4_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV55Tooltipwwds_5_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Tooltipwwds_6_tftooltipdescricao",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Tooltipwwds_7_tftooltipdescricao_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP006N4;
          prmP006N4 = new Object[] {
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV51Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV52Tooltipwwds_2_tftooltiptelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV53Tooltipwwds_3_tftooltiptelanome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_4_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV55Tooltipwwds_5_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Tooltipwwds_6_tftooltipdescricao",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Tooltipwwds_7_tftooltipdescricao_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.tooltipwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class tooltipwwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "TooltipWWGetFilterData" )]
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
          permissionPrefix = "tooltipww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("tooltipwwgetfilterdata") )
          {
             return  ;
          }
          tooltipwwgetfilterdata worker = new tooltipwwgetfilterdata(context);
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
