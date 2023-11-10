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
   public class docdicionariowwgetfilterdata : GXProcedure
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
            return "docdicionarioww_Services_Execute" ;
         }

      }

      public docdicionariowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docdicionariowwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV28SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         docdicionariowwgetfilterdata objdocdicionariowwgetfilterdata;
         objdocdicionariowwgetfilterdata = new docdicionariowwgetfilterdata();
         objdocdicionariowwgetfilterdata.AV34DDOName = aP0_DDOName;
         objdocdicionariowwgetfilterdata.AV28SearchTxtParms = aP1_SearchTxtParms;
         objdocdicionariowwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objdocdicionariowwgetfilterdata.AV38OptionsJson = "" ;
         objdocdicionariowwgetfilterdata.AV41OptionsDescJson = "" ;
         objdocdicionariowwgetfilterdata.AV43OptionIndexesJson = "" ;
         objdocdicionariowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdocdicionariowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objdocdicionariowwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docdicionariowwgetfilterdata)stateInfo).executePrivate();
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
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31MaxItems = 10;
         AV30PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV28SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV28SearchTxtParms, 1, 2), "."))));
         AV32SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV28SearchTxtParms)) ? "" : StringUtil.Substring( AV28SearchTxtParms, 3, -1));
         AV29SkipItems = (short)(AV30PageIndex*AV31MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_DOCDICIONARIOFINALIDADE") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCDICIONARIOFINALIDADEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_INFORMACAONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADINFORMACAONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_HIPOTESETRATAMENTONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADHIPOTESETRATAMENTONOMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_DOCUMENTONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCUMENTONOMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_DOCDICIONARIOTIPOTRANSFINTERGARANTIA") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCDICIONARIOTIPOTRANSFINTERGARANTIAOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV37Options.ToJSonString(false);
         AV41OptionsDescJson = AV40OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV45Session.Get("DocDicionarioWWGridState"), "") == 0 )
         {
            AV47GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocDicionarioWWGridState"), null, "", "");
         }
         else
         {
            AV47GridState.FromXml(AV45Session.Get("DocDicionarioWWGridState"), null, "", "");
         }
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV47GridState.gxTpr_Filtervalues.Count )
         {
            AV48GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV47GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOID") == 0 )
            {
               AV11TFDocDicionarioId = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
               AV12TFDocDicionarioId_To = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFINFORMACAOID") == 0 )
            {
               AV15TFInformacaoId = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
               AV16TFInformacaoId_To = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTOID") == 0 )
            {
               AV51TFHipoteseTratamentoId = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
               AV52TFHipoteseTratamentoId_To = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOSENSIVEL_SEL") == 0 )
            {
               AV20TFDocDicionarioSensivel_Sel = (short)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOPODEELIMINAR_SEL") == 0 )
            {
               AV21TFDocDicionarioPodeEliminar_Sel = (short)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTRANSFINTER_SEL") == 0 )
            {
               AV67TFDocDicionarioTransfInter_Sel = (short)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE") == 0 )
            {
               AV24TFDocDicionarioFinalidade = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE_SEL") == 0 )
            {
               AV25TFDocDicionarioFinalidade_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIODATAINCLUSAO") == 0 )
            {
               AV26TFDocDicionarioDataInclusao = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Value, 2);
               AV27TFDocDicionarioDataInclusao_To = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME") == 0 )
            {
               AV55TFInformacaoNome = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME_SEL") == 0 )
            {
               AV56TFInformacaoNome_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME") == 0 )
            {
               AV57TFHipoteseTratamentoNome = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME_SEL") == 0 )
            {
               AV58TFHipoteseTratamentoNome_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV61TFDocumentoId = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
               AV62TFDocumentoId_To = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV63TFDocumentoNome = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV64TFDocumentoNome_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA") == 0 )
            {
               AV65TFDocDicionarioTipoTransfInterGarantia = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL") == 0 )
            {
               AV66TFDocDicionarioTipoTransfInterGarantia_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCDICIONARIOFINALIDADEOPTIONS' Routine */
         returnInSub = false;
         AV24TFDocDicionarioFinalidade = AV32SearchTxt;
         AV25TFDocDicionarioFinalidade_Sel = "";
         AV72Docdicionariowwds_1_filterfulltext = AV50FilterFullText;
         AV73Docdicionariowwds_2_tfdocdicionarioid = AV11TFDocDicionarioId;
         AV74Docdicionariowwds_3_tfdocdicionarioid_to = AV12TFDocDicionarioId_To;
         AV75Docdicionariowwds_4_tfinformacaoid = AV15TFInformacaoId;
         AV76Docdicionariowwds_5_tfinformacaoid_to = AV16TFInformacaoId_To;
         AV77Docdicionariowwds_6_tfhipotesetratamentoid = AV51TFHipoteseTratamentoId;
         AV78Docdicionariowwds_7_tfhipotesetratamentoid_to = AV52TFHipoteseTratamentoId_To;
         AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV20TFDocDicionarioSensivel_Sel;
         AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV21TFDocDicionarioPodeEliminar_Sel;
         AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV67TFDocDicionarioTransfInter_Sel;
         AV82Docdicionariowwds_11_tfdocdicionariofinalidade = AV24TFDocDicionarioFinalidade;
         AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV25TFDocDicionarioFinalidade_Sel;
         AV84Docdicionariowwds_13_tfdocdicionariodatainclusao = AV26TFDocDicionarioDataInclusao;
         AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV27TFDocDicionarioDataInclusao_To;
         AV86Docdicionariowwds_15_tfinformacaonome = AV55TFInformacaoNome;
         AV87Docdicionariowwds_16_tfinformacaonome_sel = AV56TFInformacaoNome_Sel;
         AV88Docdicionariowwds_17_tfhipotesetratamentonome = AV57TFHipoteseTratamentoNome;
         AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV58TFHipoteseTratamentoNome_Sel;
         AV90Docdicionariowwds_19_tfdocumentoid = AV61TFDocumentoId;
         AV91Docdicionariowwds_20_tfdocumentoid_to = AV62TFDocumentoId_To;
         AV92Docdicionariowwds_21_tfdocumentonome = AV63TFDocumentoNome;
         AV93Docdicionariowwds_22_tfdocumentonome_sel = AV64TFDocumentoNome_Sel;
         AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV65TFDocDicionarioTipoTransfInterGarantia;
         AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV66TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV72Docdicionariowwds_1_filterfulltext ,
                                              AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV75Docdicionariowwds_4_tfinformacaoid ,
                                              AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV86Docdicionariowwds_15_tfinformacaonome ,
                                              AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV90Docdicionariowwds_19_tfdocumentoid ,
                                              AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV92Docdicionariowwds_21_tfdocumentonome ,
                                              AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV82Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV86Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV88Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV92Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P002Y2 */
         pr_default.execute(0, new Object[] {lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, AV73Docdicionariowwds_2_tfdocdicionarioid, AV74Docdicionariowwds_3_tfdocdicionarioid_to, AV75Docdicionariowwds_4_tfinformacaoid, AV76Docdicionariowwds_5_tfinformacaoid_to, AV77Docdicionariowwds_6_tfhipotesetratamentoid, AV78Docdicionariowwds_7_tfhipotesetratamentoid_to, lV82Docdicionariowwds_11_tfdocdicionariofinalidade, AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV84Docdicionariowwds_13_tfdocdicionariodatainclusao, AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV86Docdicionariowwds_15_tfinformacaonome, AV87Docdicionariowwds_16_tfinformacaonome_sel, lV88Docdicionariowwds_17_tfhipotesetratamentonome, AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV90Docdicionariowwds_19_tfdocumentoid, AV91Docdicionariowwds_20_tfdocumentoid_to, lV92Docdicionariowwds_21_tfdocumentonome, AV93Docdicionariowwds_22_tfdocumentonome_sel, lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2Y2 = false;
            A102DocDicionarioFinalidade = P002Y2_A102DocDicionarioFinalidade[0];
            A75DocumentoId = P002Y2_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P002Y2_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P002Y2_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P002Y2_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P002Y2_A99DocDicionarioSensivel[0];
            A72HipoteseTratamentoId = P002Y2_A72HipoteseTratamentoId[0];
            A69InformacaoId = P002Y2_A69InformacaoId[0];
            A98DocDicionarioId = P002Y2_A98DocDicionarioId[0];
            A119DocDicionarioTipoTransfInterGa = P002Y2_A119DocDicionarioTipoTransfInterGa[0];
            A76DocumentoNome = P002Y2_A76DocumentoNome[0];
            n76DocumentoNome = P002Y2_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y2_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y2_A70InformacaoNome[0];
            A76DocumentoNome = P002Y2_A76DocumentoNome[0];
            n76DocumentoNome = P002Y2_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y2_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y2_A70InformacaoNome[0];
            AV44count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002Y2_A102DocDicionarioFinalidade[0], A102DocDicionarioFinalidade) == 0 ) )
            {
               BRK2Y2 = false;
               A98DocDicionarioId = P002Y2_A98DocDicionarioId[0];
               AV44count = (long)(AV44count+1);
               BRK2Y2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV29SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A102DocDicionarioFinalidade)) ? "<#Empty#>" : A102DocDicionarioFinalidade);
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRK2Y2 )
            {
               BRK2Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADINFORMACAONOMEOPTIONS' Routine */
         returnInSub = false;
         AV55TFInformacaoNome = AV32SearchTxt;
         AV56TFInformacaoNome_Sel = "";
         AV72Docdicionariowwds_1_filterfulltext = AV50FilterFullText;
         AV73Docdicionariowwds_2_tfdocdicionarioid = AV11TFDocDicionarioId;
         AV74Docdicionariowwds_3_tfdocdicionarioid_to = AV12TFDocDicionarioId_To;
         AV75Docdicionariowwds_4_tfinformacaoid = AV15TFInformacaoId;
         AV76Docdicionariowwds_5_tfinformacaoid_to = AV16TFInformacaoId_To;
         AV77Docdicionariowwds_6_tfhipotesetratamentoid = AV51TFHipoteseTratamentoId;
         AV78Docdicionariowwds_7_tfhipotesetratamentoid_to = AV52TFHipoteseTratamentoId_To;
         AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV20TFDocDicionarioSensivel_Sel;
         AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV21TFDocDicionarioPodeEliminar_Sel;
         AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV67TFDocDicionarioTransfInter_Sel;
         AV82Docdicionariowwds_11_tfdocdicionariofinalidade = AV24TFDocDicionarioFinalidade;
         AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV25TFDocDicionarioFinalidade_Sel;
         AV84Docdicionariowwds_13_tfdocdicionariodatainclusao = AV26TFDocDicionarioDataInclusao;
         AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV27TFDocDicionarioDataInclusao_To;
         AV86Docdicionariowwds_15_tfinformacaonome = AV55TFInformacaoNome;
         AV87Docdicionariowwds_16_tfinformacaonome_sel = AV56TFInformacaoNome_Sel;
         AV88Docdicionariowwds_17_tfhipotesetratamentonome = AV57TFHipoteseTratamentoNome;
         AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV58TFHipoteseTratamentoNome_Sel;
         AV90Docdicionariowwds_19_tfdocumentoid = AV61TFDocumentoId;
         AV91Docdicionariowwds_20_tfdocumentoid_to = AV62TFDocumentoId_To;
         AV92Docdicionariowwds_21_tfdocumentonome = AV63TFDocumentoNome;
         AV93Docdicionariowwds_22_tfdocumentonome_sel = AV64TFDocumentoNome_Sel;
         AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV65TFDocDicionarioTipoTransfInterGarantia;
         AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV66TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV72Docdicionariowwds_1_filterfulltext ,
                                              AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV75Docdicionariowwds_4_tfinformacaoid ,
                                              AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV86Docdicionariowwds_15_tfinformacaonome ,
                                              AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV90Docdicionariowwds_19_tfdocumentoid ,
                                              AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV92Docdicionariowwds_21_tfdocumentonome ,
                                              AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV82Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV86Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV88Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV92Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P002Y3 */
         pr_default.execute(1, new Object[] {lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, AV73Docdicionariowwds_2_tfdocdicionarioid, AV74Docdicionariowwds_3_tfdocdicionarioid_to, AV75Docdicionariowwds_4_tfinformacaoid, AV76Docdicionariowwds_5_tfinformacaoid_to, AV77Docdicionariowwds_6_tfhipotesetratamentoid, AV78Docdicionariowwds_7_tfhipotesetratamentoid_to, lV82Docdicionariowwds_11_tfdocdicionariofinalidade, AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV84Docdicionariowwds_13_tfdocdicionariodatainclusao, AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV86Docdicionariowwds_15_tfinformacaonome, AV87Docdicionariowwds_16_tfinformacaonome_sel, lV88Docdicionariowwds_17_tfhipotesetratamentonome, AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV90Docdicionariowwds_19_tfdocumentoid, AV91Docdicionariowwds_20_tfdocumentoid_to, lV92Docdicionariowwds_21_tfdocumentonome, AV93Docdicionariowwds_22_tfdocumentonome_sel, lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2Y4 = false;
            A69InformacaoId = P002Y3_A69InformacaoId[0];
            A75DocumentoId = P002Y3_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P002Y3_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P002Y3_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P002Y3_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P002Y3_A99DocDicionarioSensivel[0];
            A72HipoteseTratamentoId = P002Y3_A72HipoteseTratamentoId[0];
            A98DocDicionarioId = P002Y3_A98DocDicionarioId[0];
            A119DocDicionarioTipoTransfInterGa = P002Y3_A119DocDicionarioTipoTransfInterGa[0];
            A76DocumentoNome = P002Y3_A76DocumentoNome[0];
            n76DocumentoNome = P002Y3_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y3_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y3_A70InformacaoNome[0];
            A102DocDicionarioFinalidade = P002Y3_A102DocDicionarioFinalidade[0];
            A70InformacaoNome = P002Y3_A70InformacaoNome[0];
            A76DocumentoNome = P002Y3_A76DocumentoNome[0];
            n76DocumentoNome = P002Y3_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y3_A73HipoteseTratamentoNome[0];
            AV44count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P002Y3_A69InformacaoId[0] == A69InformacaoId ) )
            {
               BRK2Y4 = false;
               A98DocDicionarioId = P002Y3_A98DocDicionarioId[0];
               AV44count = (long)(AV44count+1);
               BRK2Y4 = true;
               pr_default.readNext(1);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70InformacaoNome)) ? "<#Empty#>" : A70InformacaoNome);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV29SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
            }
            if ( ! BRK2Y4 )
            {
               BRK2Y4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV29SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV29SkipItems = (short)(AV29SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADHIPOTESETRATAMENTONOMEOPTIONS' Routine */
         returnInSub = false;
         AV57TFHipoteseTratamentoNome = AV32SearchTxt;
         AV58TFHipoteseTratamentoNome_Sel = "";
         AV72Docdicionariowwds_1_filterfulltext = AV50FilterFullText;
         AV73Docdicionariowwds_2_tfdocdicionarioid = AV11TFDocDicionarioId;
         AV74Docdicionariowwds_3_tfdocdicionarioid_to = AV12TFDocDicionarioId_To;
         AV75Docdicionariowwds_4_tfinformacaoid = AV15TFInformacaoId;
         AV76Docdicionariowwds_5_tfinformacaoid_to = AV16TFInformacaoId_To;
         AV77Docdicionariowwds_6_tfhipotesetratamentoid = AV51TFHipoteseTratamentoId;
         AV78Docdicionariowwds_7_tfhipotesetratamentoid_to = AV52TFHipoteseTratamentoId_To;
         AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV20TFDocDicionarioSensivel_Sel;
         AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV21TFDocDicionarioPodeEliminar_Sel;
         AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV67TFDocDicionarioTransfInter_Sel;
         AV82Docdicionariowwds_11_tfdocdicionariofinalidade = AV24TFDocDicionarioFinalidade;
         AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV25TFDocDicionarioFinalidade_Sel;
         AV84Docdicionariowwds_13_tfdocdicionariodatainclusao = AV26TFDocDicionarioDataInclusao;
         AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV27TFDocDicionarioDataInclusao_To;
         AV86Docdicionariowwds_15_tfinformacaonome = AV55TFInformacaoNome;
         AV87Docdicionariowwds_16_tfinformacaonome_sel = AV56TFInformacaoNome_Sel;
         AV88Docdicionariowwds_17_tfhipotesetratamentonome = AV57TFHipoteseTratamentoNome;
         AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV58TFHipoteseTratamentoNome_Sel;
         AV90Docdicionariowwds_19_tfdocumentoid = AV61TFDocumentoId;
         AV91Docdicionariowwds_20_tfdocumentoid_to = AV62TFDocumentoId_To;
         AV92Docdicionariowwds_21_tfdocumentonome = AV63TFDocumentoNome;
         AV93Docdicionariowwds_22_tfdocumentonome_sel = AV64TFDocumentoNome_Sel;
         AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV65TFDocDicionarioTipoTransfInterGarantia;
         AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV66TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV72Docdicionariowwds_1_filterfulltext ,
                                              AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV75Docdicionariowwds_4_tfinformacaoid ,
                                              AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV86Docdicionariowwds_15_tfinformacaonome ,
                                              AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV90Docdicionariowwds_19_tfdocumentoid ,
                                              AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV92Docdicionariowwds_21_tfdocumentonome ,
                                              AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV82Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV86Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV88Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV92Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P002Y4 */
         pr_default.execute(2, new Object[] {lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, AV73Docdicionariowwds_2_tfdocdicionarioid, AV74Docdicionariowwds_3_tfdocdicionarioid_to, AV75Docdicionariowwds_4_tfinformacaoid, AV76Docdicionariowwds_5_tfinformacaoid_to, AV77Docdicionariowwds_6_tfhipotesetratamentoid, AV78Docdicionariowwds_7_tfhipotesetratamentoid_to, lV82Docdicionariowwds_11_tfdocdicionariofinalidade, AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV84Docdicionariowwds_13_tfdocdicionariodatainclusao, AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV86Docdicionariowwds_15_tfinformacaonome, AV87Docdicionariowwds_16_tfinformacaonome_sel, lV88Docdicionariowwds_17_tfhipotesetratamentonome, AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV90Docdicionariowwds_19_tfdocumentoid, AV91Docdicionariowwds_20_tfdocumentoid_to, lV92Docdicionariowwds_21_tfdocumentonome, AV93Docdicionariowwds_22_tfdocumentonome_sel, lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2Y6 = false;
            A72HipoteseTratamentoId = P002Y4_A72HipoteseTratamentoId[0];
            A75DocumentoId = P002Y4_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P002Y4_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P002Y4_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P002Y4_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P002Y4_A99DocDicionarioSensivel[0];
            A69InformacaoId = P002Y4_A69InformacaoId[0];
            A98DocDicionarioId = P002Y4_A98DocDicionarioId[0];
            A119DocDicionarioTipoTransfInterGa = P002Y4_A119DocDicionarioTipoTransfInterGa[0];
            A76DocumentoNome = P002Y4_A76DocumentoNome[0];
            n76DocumentoNome = P002Y4_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y4_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y4_A70InformacaoNome[0];
            A102DocDicionarioFinalidade = P002Y4_A102DocDicionarioFinalidade[0];
            A73HipoteseTratamentoNome = P002Y4_A73HipoteseTratamentoNome[0];
            A76DocumentoNome = P002Y4_A76DocumentoNome[0];
            n76DocumentoNome = P002Y4_n76DocumentoNome[0];
            A70InformacaoNome = P002Y4_A70InformacaoNome[0];
            AV44count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P002Y4_A72HipoteseTratamentoId[0] == A72HipoteseTratamentoId ) )
            {
               BRK2Y6 = false;
               A98DocDicionarioId = P002Y4_A98DocDicionarioId[0];
               AV44count = (long)(AV44count+1);
               BRK2Y6 = true;
               pr_default.readNext(2);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A73HipoteseTratamentoNome)) ? "<#Empty#>" : A73HipoteseTratamentoNome);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV29SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
            }
            if ( ! BRK2Y6 )
            {
               BRK2Y6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV29SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV29SkipItems = (short)(AV29SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADDOCUMENTONOMEOPTIONS' Routine */
         returnInSub = false;
         AV63TFDocumentoNome = AV32SearchTxt;
         AV64TFDocumentoNome_Sel = "";
         AV72Docdicionariowwds_1_filterfulltext = AV50FilterFullText;
         AV73Docdicionariowwds_2_tfdocdicionarioid = AV11TFDocDicionarioId;
         AV74Docdicionariowwds_3_tfdocdicionarioid_to = AV12TFDocDicionarioId_To;
         AV75Docdicionariowwds_4_tfinformacaoid = AV15TFInformacaoId;
         AV76Docdicionariowwds_5_tfinformacaoid_to = AV16TFInformacaoId_To;
         AV77Docdicionariowwds_6_tfhipotesetratamentoid = AV51TFHipoteseTratamentoId;
         AV78Docdicionariowwds_7_tfhipotesetratamentoid_to = AV52TFHipoteseTratamentoId_To;
         AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV20TFDocDicionarioSensivel_Sel;
         AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV21TFDocDicionarioPodeEliminar_Sel;
         AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV67TFDocDicionarioTransfInter_Sel;
         AV82Docdicionariowwds_11_tfdocdicionariofinalidade = AV24TFDocDicionarioFinalidade;
         AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV25TFDocDicionarioFinalidade_Sel;
         AV84Docdicionariowwds_13_tfdocdicionariodatainclusao = AV26TFDocDicionarioDataInclusao;
         AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV27TFDocDicionarioDataInclusao_To;
         AV86Docdicionariowwds_15_tfinformacaonome = AV55TFInformacaoNome;
         AV87Docdicionariowwds_16_tfinformacaonome_sel = AV56TFInformacaoNome_Sel;
         AV88Docdicionariowwds_17_tfhipotesetratamentonome = AV57TFHipoteseTratamentoNome;
         AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV58TFHipoteseTratamentoNome_Sel;
         AV90Docdicionariowwds_19_tfdocumentoid = AV61TFDocumentoId;
         AV91Docdicionariowwds_20_tfdocumentoid_to = AV62TFDocumentoId_To;
         AV92Docdicionariowwds_21_tfdocumentonome = AV63TFDocumentoNome;
         AV93Docdicionariowwds_22_tfdocumentonome_sel = AV64TFDocumentoNome_Sel;
         AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV65TFDocDicionarioTipoTransfInterGarantia;
         AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV66TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV72Docdicionariowwds_1_filterfulltext ,
                                              AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV75Docdicionariowwds_4_tfinformacaoid ,
                                              AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV86Docdicionariowwds_15_tfinformacaonome ,
                                              AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV90Docdicionariowwds_19_tfdocumentoid ,
                                              AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV92Docdicionariowwds_21_tfdocumentonome ,
                                              AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV82Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV86Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV88Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV92Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P002Y5 */
         pr_default.execute(3, new Object[] {lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, AV73Docdicionariowwds_2_tfdocdicionarioid, AV74Docdicionariowwds_3_tfdocdicionarioid_to, AV75Docdicionariowwds_4_tfinformacaoid, AV76Docdicionariowwds_5_tfinformacaoid_to, AV77Docdicionariowwds_6_tfhipotesetratamentoid, AV78Docdicionariowwds_7_tfhipotesetratamentoid_to, lV82Docdicionariowwds_11_tfdocdicionariofinalidade, AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV84Docdicionariowwds_13_tfdocdicionariodatainclusao, AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV86Docdicionariowwds_15_tfinformacaonome, AV87Docdicionariowwds_16_tfinformacaonome_sel, lV88Docdicionariowwds_17_tfhipotesetratamentonome, AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV90Docdicionariowwds_19_tfdocumentoid, AV91Docdicionariowwds_20_tfdocumentoid_to, lV92Docdicionariowwds_21_tfdocumentonome, AV93Docdicionariowwds_22_tfdocumentonome_sel, lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2Y8 = false;
            A75DocumentoId = P002Y5_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P002Y5_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P002Y5_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P002Y5_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P002Y5_A99DocDicionarioSensivel[0];
            A72HipoteseTratamentoId = P002Y5_A72HipoteseTratamentoId[0];
            A69InformacaoId = P002Y5_A69InformacaoId[0];
            A98DocDicionarioId = P002Y5_A98DocDicionarioId[0];
            A119DocDicionarioTipoTransfInterGa = P002Y5_A119DocDicionarioTipoTransfInterGa[0];
            A76DocumentoNome = P002Y5_A76DocumentoNome[0];
            n76DocumentoNome = P002Y5_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y5_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y5_A70InformacaoNome[0];
            A102DocDicionarioFinalidade = P002Y5_A102DocDicionarioFinalidade[0];
            A76DocumentoNome = P002Y5_A76DocumentoNome[0];
            n76DocumentoNome = P002Y5_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y5_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y5_A70InformacaoNome[0];
            AV44count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P002Y5_A75DocumentoId[0] == A75DocumentoId ) )
            {
               BRK2Y8 = false;
               A98DocDicionarioId = P002Y5_A98DocDicionarioId[0];
               AV44count = (long)(AV44count+1);
               BRK2Y8 = true;
               pr_default.readNext(3);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A76DocumentoNome)) ? "<#Empty#>" : A76DocumentoNome);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV29SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
            }
            if ( ! BRK2Y8 )
            {
               BRK2Y8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV29SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV29SkipItems = (short)(AV29SkipItems-1);
         }
      }

      protected void S161( )
      {
         /* 'LOADDOCDICIONARIOTIPOTRANSFINTERGARANTIAOPTIONS' Routine */
         returnInSub = false;
         AV65TFDocDicionarioTipoTransfInterGarantia = AV32SearchTxt;
         AV66TFDocDicionarioTipoTransfInterGarantia_Sel = "";
         AV72Docdicionariowwds_1_filterfulltext = AV50FilterFullText;
         AV73Docdicionariowwds_2_tfdocdicionarioid = AV11TFDocDicionarioId;
         AV74Docdicionariowwds_3_tfdocdicionarioid_to = AV12TFDocDicionarioId_To;
         AV75Docdicionariowwds_4_tfinformacaoid = AV15TFInformacaoId;
         AV76Docdicionariowwds_5_tfinformacaoid_to = AV16TFInformacaoId_To;
         AV77Docdicionariowwds_6_tfhipotesetratamentoid = AV51TFHipoteseTratamentoId;
         AV78Docdicionariowwds_7_tfhipotesetratamentoid_to = AV52TFHipoteseTratamentoId_To;
         AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV20TFDocDicionarioSensivel_Sel;
         AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV21TFDocDicionarioPodeEliminar_Sel;
         AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV67TFDocDicionarioTransfInter_Sel;
         AV82Docdicionariowwds_11_tfdocdicionariofinalidade = AV24TFDocDicionarioFinalidade;
         AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV25TFDocDicionarioFinalidade_Sel;
         AV84Docdicionariowwds_13_tfdocdicionariodatainclusao = AV26TFDocDicionarioDataInclusao;
         AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV27TFDocDicionarioDataInclusao_To;
         AV86Docdicionariowwds_15_tfinformacaonome = AV55TFInformacaoNome;
         AV87Docdicionariowwds_16_tfinformacaonome_sel = AV56TFInformacaoNome_Sel;
         AV88Docdicionariowwds_17_tfhipotesetratamentonome = AV57TFHipoteseTratamentoNome;
         AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV58TFHipoteseTratamentoNome_Sel;
         AV90Docdicionariowwds_19_tfdocumentoid = AV61TFDocumentoId;
         AV91Docdicionariowwds_20_tfdocumentoid_to = AV62TFDocumentoId_To;
         AV92Docdicionariowwds_21_tfdocumentonome = AV63TFDocumentoNome;
         AV93Docdicionariowwds_22_tfdocumentonome_sel = AV64TFDocumentoNome_Sel;
         AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV65TFDocDicionarioTipoTransfInterGarantia;
         AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV66TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV72Docdicionariowwds_1_filterfulltext ,
                                              AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV75Docdicionariowwds_4_tfinformacaoid ,
                                              AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV86Docdicionariowwds_15_tfinformacaonome ,
                                              AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV90Docdicionariowwds_19_tfdocumentoid ,
                                              AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV92Docdicionariowwds_21_tfdocumentonome ,
                                              AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV72Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext), "%", "");
         lV82Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV86Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV88Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV92Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P002Y6 */
         pr_default.execute(4, new Object[] {lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, lV72Docdicionariowwds_1_filterfulltext, AV73Docdicionariowwds_2_tfdocdicionarioid, AV74Docdicionariowwds_3_tfdocdicionarioid_to, AV75Docdicionariowwds_4_tfinformacaoid, AV76Docdicionariowwds_5_tfinformacaoid_to, AV77Docdicionariowwds_6_tfhipotesetratamentoid, AV78Docdicionariowwds_7_tfhipotesetratamentoid_to, lV82Docdicionariowwds_11_tfdocdicionariofinalidade, AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV84Docdicionariowwds_13_tfdocdicionariodatainclusao, AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV86Docdicionariowwds_15_tfinformacaonome, AV87Docdicionariowwds_16_tfinformacaonome_sel, lV88Docdicionariowwds_17_tfhipotesetratamentonome, AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV90Docdicionariowwds_19_tfdocumentoid, AV91Docdicionariowwds_20_tfdocumentoid_to, lV92Docdicionariowwds_21_tfdocumentonome, AV93Docdicionariowwds_22_tfdocumentonome_sel, lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2Y10 = false;
            A119DocDicionarioTipoTransfInterGa = P002Y6_A119DocDicionarioTipoTransfInterGa[0];
            A75DocumentoId = P002Y6_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P002Y6_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P002Y6_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P002Y6_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P002Y6_A99DocDicionarioSensivel[0];
            A72HipoteseTratamentoId = P002Y6_A72HipoteseTratamentoId[0];
            A69InformacaoId = P002Y6_A69InformacaoId[0];
            A98DocDicionarioId = P002Y6_A98DocDicionarioId[0];
            A76DocumentoNome = P002Y6_A76DocumentoNome[0];
            n76DocumentoNome = P002Y6_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y6_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y6_A70InformacaoNome[0];
            A102DocDicionarioFinalidade = P002Y6_A102DocDicionarioFinalidade[0];
            A76DocumentoNome = P002Y6_A76DocumentoNome[0];
            n76DocumentoNome = P002Y6_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Y6_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Y6_A70InformacaoNome[0];
            AV44count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002Y6_A119DocDicionarioTipoTransfInterGa[0], A119DocDicionarioTipoTransfInterGa) == 0 ) )
            {
               BRK2Y10 = false;
               A98DocDicionarioId = P002Y6_A98DocDicionarioId[0];
               AV44count = (long)(AV44count+1);
               BRK2Y10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV29SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A119DocDicionarioTipoTransfInterGa)) ? "<#Empty#>" : A119DocDicionarioTipoTransfInterGa);
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRK2Y10 )
            {
               BRK2Y10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV38OptionsJson = "";
         AV41OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV40OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV32SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV45Session = context.GetSession();
         AV47GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV48GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50FilterFullText = "";
         AV24TFDocDicionarioFinalidade = "";
         AV25TFDocDicionarioFinalidade_Sel = "";
         AV26TFDocDicionarioDataInclusao = DateTime.MinValue;
         AV27TFDocDicionarioDataInclusao_To = DateTime.MinValue;
         AV55TFInformacaoNome = "";
         AV56TFInformacaoNome_Sel = "";
         AV57TFHipoteseTratamentoNome = "";
         AV58TFHipoteseTratamentoNome_Sel = "";
         AV63TFDocumentoNome = "";
         AV64TFDocumentoNome_Sel = "";
         AV65TFDocDicionarioTipoTransfInterGarantia = "";
         AV66TFDocDicionarioTipoTransfInterGarantia_Sel = "";
         AV72Docdicionariowwds_1_filterfulltext = "";
         AV82Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel = "";
         AV84Docdicionariowwds_13_tfdocdicionariodatainclusao = DateTime.MinValue;
         AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to = DateTime.MinValue;
         AV86Docdicionariowwds_15_tfinformacaonome = "";
         AV87Docdicionariowwds_16_tfinformacaonome_sel = "";
         AV88Docdicionariowwds_17_tfhipotesetratamentonome = "";
         AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel = "";
         AV92Docdicionariowwds_21_tfdocumentonome = "";
         AV93Docdicionariowwds_22_tfdocumentonome_sel = "";
         AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = "";
         scmdbuf = "";
         lV72Docdicionariowwds_1_filterfulltext = "";
         lV82Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         lV86Docdicionariowwds_15_tfinformacaonome = "";
         lV88Docdicionariowwds_17_tfhipotesetratamentonome = "";
         lV92Docdicionariowwds_21_tfdocumentonome = "";
         lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         A102DocDicionarioFinalidade = "";
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A76DocumentoNome = "";
         A119DocDicionarioTipoTransfInterGa = "";
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         P002Y2_A102DocDicionarioFinalidade = new string[] {""} ;
         P002Y2_A75DocumentoId = new int[1] ;
         P002Y2_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P002Y2_A101DocDicionarioTransfInter = new bool[] {false} ;
         P002Y2_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P002Y2_A99DocDicionarioSensivel = new bool[] {false} ;
         P002Y2_A72HipoteseTratamentoId = new int[1] ;
         P002Y2_A69InformacaoId = new int[1] ;
         P002Y2_A98DocDicionarioId = new int[1] ;
         P002Y2_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P002Y2_A76DocumentoNome = new string[] {""} ;
         P002Y2_n76DocumentoNome = new bool[] {false} ;
         P002Y2_A73HipoteseTratamentoNome = new string[] {""} ;
         P002Y2_A70InformacaoNome = new string[] {""} ;
         AV36Option = "";
         P002Y3_A69InformacaoId = new int[1] ;
         P002Y3_A75DocumentoId = new int[1] ;
         P002Y3_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P002Y3_A101DocDicionarioTransfInter = new bool[] {false} ;
         P002Y3_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P002Y3_A99DocDicionarioSensivel = new bool[] {false} ;
         P002Y3_A72HipoteseTratamentoId = new int[1] ;
         P002Y3_A98DocDicionarioId = new int[1] ;
         P002Y3_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P002Y3_A76DocumentoNome = new string[] {""} ;
         P002Y3_n76DocumentoNome = new bool[] {false} ;
         P002Y3_A73HipoteseTratamentoNome = new string[] {""} ;
         P002Y3_A70InformacaoNome = new string[] {""} ;
         P002Y3_A102DocDicionarioFinalidade = new string[] {""} ;
         P002Y4_A72HipoteseTratamentoId = new int[1] ;
         P002Y4_A75DocumentoId = new int[1] ;
         P002Y4_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P002Y4_A101DocDicionarioTransfInter = new bool[] {false} ;
         P002Y4_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P002Y4_A99DocDicionarioSensivel = new bool[] {false} ;
         P002Y4_A69InformacaoId = new int[1] ;
         P002Y4_A98DocDicionarioId = new int[1] ;
         P002Y4_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P002Y4_A76DocumentoNome = new string[] {""} ;
         P002Y4_n76DocumentoNome = new bool[] {false} ;
         P002Y4_A73HipoteseTratamentoNome = new string[] {""} ;
         P002Y4_A70InformacaoNome = new string[] {""} ;
         P002Y4_A102DocDicionarioFinalidade = new string[] {""} ;
         P002Y5_A75DocumentoId = new int[1] ;
         P002Y5_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P002Y5_A101DocDicionarioTransfInter = new bool[] {false} ;
         P002Y5_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P002Y5_A99DocDicionarioSensivel = new bool[] {false} ;
         P002Y5_A72HipoteseTratamentoId = new int[1] ;
         P002Y5_A69InformacaoId = new int[1] ;
         P002Y5_A98DocDicionarioId = new int[1] ;
         P002Y5_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P002Y5_A76DocumentoNome = new string[] {""} ;
         P002Y5_n76DocumentoNome = new bool[] {false} ;
         P002Y5_A73HipoteseTratamentoNome = new string[] {""} ;
         P002Y5_A70InformacaoNome = new string[] {""} ;
         P002Y5_A102DocDicionarioFinalidade = new string[] {""} ;
         P002Y6_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P002Y6_A75DocumentoId = new int[1] ;
         P002Y6_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P002Y6_A101DocDicionarioTransfInter = new bool[] {false} ;
         P002Y6_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P002Y6_A99DocDicionarioSensivel = new bool[] {false} ;
         P002Y6_A72HipoteseTratamentoId = new int[1] ;
         P002Y6_A69InformacaoId = new int[1] ;
         P002Y6_A98DocDicionarioId = new int[1] ;
         P002Y6_A76DocumentoNome = new string[] {""} ;
         P002Y6_n76DocumentoNome = new bool[] {false} ;
         P002Y6_A73HipoteseTratamentoNome = new string[] {""} ;
         P002Y6_A70InformacaoNome = new string[] {""} ;
         P002Y6_A102DocDicionarioFinalidade = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionariowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002Y2_A102DocDicionarioFinalidade, P002Y2_A75DocumentoId, P002Y2_A103DocDicionarioDataInclusao, P002Y2_A101DocDicionarioTransfInter, P002Y2_A100DocDicionarioPodeEliminar, P002Y2_A99DocDicionarioSensivel, P002Y2_A72HipoteseTratamentoId, P002Y2_A69InformacaoId, P002Y2_A98DocDicionarioId, P002Y2_A119DocDicionarioTipoTransfInterGa,
               P002Y2_A76DocumentoNome, P002Y2_n76DocumentoNome, P002Y2_A73HipoteseTratamentoNome, P002Y2_A70InformacaoNome
               }
               , new Object[] {
               P002Y3_A69InformacaoId, P002Y3_A75DocumentoId, P002Y3_A103DocDicionarioDataInclusao, P002Y3_A101DocDicionarioTransfInter, P002Y3_A100DocDicionarioPodeEliminar, P002Y3_A99DocDicionarioSensivel, P002Y3_A72HipoteseTratamentoId, P002Y3_A98DocDicionarioId, P002Y3_A119DocDicionarioTipoTransfInterGa, P002Y3_A76DocumentoNome,
               P002Y3_n76DocumentoNome, P002Y3_A73HipoteseTratamentoNome, P002Y3_A70InformacaoNome, P002Y3_A102DocDicionarioFinalidade
               }
               , new Object[] {
               P002Y4_A72HipoteseTratamentoId, P002Y4_A75DocumentoId, P002Y4_A103DocDicionarioDataInclusao, P002Y4_A101DocDicionarioTransfInter, P002Y4_A100DocDicionarioPodeEliminar, P002Y4_A99DocDicionarioSensivel, P002Y4_A69InformacaoId, P002Y4_A98DocDicionarioId, P002Y4_A119DocDicionarioTipoTransfInterGa, P002Y4_A76DocumentoNome,
               P002Y4_n76DocumentoNome, P002Y4_A73HipoteseTratamentoNome, P002Y4_A70InformacaoNome, P002Y4_A102DocDicionarioFinalidade
               }
               , new Object[] {
               P002Y5_A75DocumentoId, P002Y5_A103DocDicionarioDataInclusao, P002Y5_A101DocDicionarioTransfInter, P002Y5_A100DocDicionarioPodeEliminar, P002Y5_A99DocDicionarioSensivel, P002Y5_A72HipoteseTratamentoId, P002Y5_A69InformacaoId, P002Y5_A98DocDicionarioId, P002Y5_A119DocDicionarioTipoTransfInterGa, P002Y5_A76DocumentoNome,
               P002Y5_n76DocumentoNome, P002Y5_A73HipoteseTratamentoNome, P002Y5_A70InformacaoNome, P002Y5_A102DocDicionarioFinalidade
               }
               , new Object[] {
               P002Y6_A119DocDicionarioTipoTransfInterGa, P002Y6_A75DocumentoId, P002Y6_A103DocDicionarioDataInclusao, P002Y6_A101DocDicionarioTransfInter, P002Y6_A100DocDicionarioPodeEliminar, P002Y6_A99DocDicionarioSensivel, P002Y6_A72HipoteseTratamentoId, P002Y6_A69InformacaoId, P002Y6_A98DocDicionarioId, P002Y6_A76DocumentoNome,
               P002Y6_n76DocumentoNome, P002Y6_A73HipoteseTratamentoNome, P002Y6_A70InformacaoNome, P002Y6_A102DocDicionarioFinalidade
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private short AV20TFDocDicionarioSensivel_Sel ;
      private short AV21TFDocDicionarioPodeEliminar_Sel ;
      private short AV67TFDocDicionarioTransfInter_Sel ;
      private short AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ;
      private short AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ;
      private short AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ;
      private int AV70GXV1 ;
      private int AV11TFDocDicionarioId ;
      private int AV12TFDocDicionarioId_To ;
      private int AV15TFInformacaoId ;
      private int AV16TFInformacaoId_To ;
      private int AV51TFHipoteseTratamentoId ;
      private int AV52TFHipoteseTratamentoId_To ;
      private int AV61TFDocumentoId ;
      private int AV62TFDocumentoId_To ;
      private int AV73Docdicionariowwds_2_tfdocdicionarioid ;
      private int AV74Docdicionariowwds_3_tfdocdicionarioid_to ;
      private int AV75Docdicionariowwds_4_tfinformacaoid ;
      private int AV76Docdicionariowwds_5_tfinformacaoid_to ;
      private int AV77Docdicionariowwds_6_tfhipotesetratamentoid ;
      private int AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ;
      private int AV90Docdicionariowwds_19_tfdocumentoid ;
      private int AV91Docdicionariowwds_20_tfdocumentoid_to ;
      private int A98DocDicionarioId ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A75DocumentoId ;
      private int AV35InsertIndex ;
      private long AV44count ;
      private string scmdbuf ;
      private DateTime AV26TFDocDicionarioDataInclusao ;
      private DateTime AV27TFDocDicionarioDataInclusao_To ;
      private DateTime AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ;
      private DateTime AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ;
      private DateTime A103DocDicionarioDataInclusao ;
      private bool returnInSub ;
      private bool A99DocDicionarioSensivel ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A101DocDicionarioTransfInter ;
      private bool BRK2Y2 ;
      private bool n76DocumentoNome ;
      private bool BRK2Y4 ;
      private bool BRK2Y6 ;
      private bool BRK2Y8 ;
      private bool BRK2Y10 ;
      private string AV38OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV82Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ;
      private string lV82Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string AV34DDOName ;
      private string AV28SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV32SearchTxt ;
      private string AV50FilterFullText ;
      private string AV24TFDocDicionarioFinalidade ;
      private string AV25TFDocDicionarioFinalidade_Sel ;
      private string AV55TFInformacaoNome ;
      private string AV56TFInformacaoNome_Sel ;
      private string AV57TFHipoteseTratamentoNome ;
      private string AV58TFHipoteseTratamentoNome_Sel ;
      private string AV63TFDocumentoNome ;
      private string AV64TFDocumentoNome_Sel ;
      private string AV65TFDocDicionarioTipoTransfInterGarantia ;
      private string AV66TFDocDicionarioTipoTransfInterGarantia_Sel ;
      private string AV72Docdicionariowwds_1_filterfulltext ;
      private string AV86Docdicionariowwds_15_tfinformacaonome ;
      private string AV87Docdicionariowwds_16_tfinformacaonome_sel ;
      private string AV88Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ;
      private string AV92Docdicionariowwds_21_tfdocumentonome ;
      private string AV93Docdicionariowwds_22_tfdocumentonome_sel ;
      private string AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ;
      private string lV72Docdicionariowwds_1_filterfulltext ;
      private string lV86Docdicionariowwds_15_tfinformacaonome ;
      private string lV88Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string lV92Docdicionariowwds_21_tfdocumentonome ;
      private string lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string A76DocumentoNome ;
      private string AV36Option ;
      private IGxSession AV45Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002Y2_A102DocDicionarioFinalidade ;
      private int[] P002Y2_A75DocumentoId ;
      private DateTime[] P002Y2_A103DocDicionarioDataInclusao ;
      private bool[] P002Y2_A101DocDicionarioTransfInter ;
      private bool[] P002Y2_A100DocDicionarioPodeEliminar ;
      private bool[] P002Y2_A99DocDicionarioSensivel ;
      private int[] P002Y2_A72HipoteseTratamentoId ;
      private int[] P002Y2_A69InformacaoId ;
      private int[] P002Y2_A98DocDicionarioId ;
      private string[] P002Y2_A119DocDicionarioTipoTransfInterGa ;
      private string[] P002Y2_A76DocumentoNome ;
      private bool[] P002Y2_n76DocumentoNome ;
      private string[] P002Y2_A73HipoteseTratamentoNome ;
      private string[] P002Y2_A70InformacaoNome ;
      private int[] P002Y3_A69InformacaoId ;
      private int[] P002Y3_A75DocumentoId ;
      private DateTime[] P002Y3_A103DocDicionarioDataInclusao ;
      private bool[] P002Y3_A101DocDicionarioTransfInter ;
      private bool[] P002Y3_A100DocDicionarioPodeEliminar ;
      private bool[] P002Y3_A99DocDicionarioSensivel ;
      private int[] P002Y3_A72HipoteseTratamentoId ;
      private int[] P002Y3_A98DocDicionarioId ;
      private string[] P002Y3_A119DocDicionarioTipoTransfInterGa ;
      private string[] P002Y3_A76DocumentoNome ;
      private bool[] P002Y3_n76DocumentoNome ;
      private string[] P002Y3_A73HipoteseTratamentoNome ;
      private string[] P002Y3_A70InformacaoNome ;
      private string[] P002Y3_A102DocDicionarioFinalidade ;
      private int[] P002Y4_A72HipoteseTratamentoId ;
      private int[] P002Y4_A75DocumentoId ;
      private DateTime[] P002Y4_A103DocDicionarioDataInclusao ;
      private bool[] P002Y4_A101DocDicionarioTransfInter ;
      private bool[] P002Y4_A100DocDicionarioPodeEliminar ;
      private bool[] P002Y4_A99DocDicionarioSensivel ;
      private int[] P002Y4_A69InformacaoId ;
      private int[] P002Y4_A98DocDicionarioId ;
      private string[] P002Y4_A119DocDicionarioTipoTransfInterGa ;
      private string[] P002Y4_A76DocumentoNome ;
      private bool[] P002Y4_n76DocumentoNome ;
      private string[] P002Y4_A73HipoteseTratamentoNome ;
      private string[] P002Y4_A70InformacaoNome ;
      private string[] P002Y4_A102DocDicionarioFinalidade ;
      private int[] P002Y5_A75DocumentoId ;
      private DateTime[] P002Y5_A103DocDicionarioDataInclusao ;
      private bool[] P002Y5_A101DocDicionarioTransfInter ;
      private bool[] P002Y5_A100DocDicionarioPodeEliminar ;
      private bool[] P002Y5_A99DocDicionarioSensivel ;
      private int[] P002Y5_A72HipoteseTratamentoId ;
      private int[] P002Y5_A69InformacaoId ;
      private int[] P002Y5_A98DocDicionarioId ;
      private string[] P002Y5_A119DocDicionarioTipoTransfInterGa ;
      private string[] P002Y5_A76DocumentoNome ;
      private bool[] P002Y5_n76DocumentoNome ;
      private string[] P002Y5_A73HipoteseTratamentoNome ;
      private string[] P002Y5_A70InformacaoNome ;
      private string[] P002Y5_A102DocDicionarioFinalidade ;
      private string[] P002Y6_A119DocDicionarioTipoTransfInterGa ;
      private int[] P002Y6_A75DocumentoId ;
      private DateTime[] P002Y6_A103DocDicionarioDataInclusao ;
      private bool[] P002Y6_A101DocDicionarioTransfInter ;
      private bool[] P002Y6_A100DocDicionarioPodeEliminar ;
      private bool[] P002Y6_A99DocDicionarioSensivel ;
      private int[] P002Y6_A72HipoteseTratamentoId ;
      private int[] P002Y6_A69InformacaoId ;
      private int[] P002Y6_A98DocDicionarioId ;
      private string[] P002Y6_A76DocumentoNome ;
      private bool[] P002Y6_n76DocumentoNome ;
      private string[] P002Y6_A73HipoteseTratamentoNome ;
      private string[] P002Y6_A70InformacaoNome ;
      private string[] P002Y6_A102DocDicionarioFinalidade ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV40OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV47GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV48GridStateFilterValue ;
   }

   public class docdicionariowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Y2( IGxContext context ,
                                             string AV72Docdicionariowwds_1_filterfulltext ,
                                             int AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV75Docdicionariowwds_4_tfinformacaoid ,
                                             int AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV86Docdicionariowwds_15_tfinformacaonome ,
                                             string AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV90Docdicionariowwds_19_tfdocumentoid ,
                                             int AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV92Docdicionariowwds_21_tfdocumentonome ,
                                             string AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[29];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[DocDicionarioFinalidade], T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[InformacaoId], T1.[DocDicionarioId], T1.[DocDicionarioTipoTransfInterGa], T2.[DocumentoNome], T3.[HipoteseTratamentoNome], T4.[InformacaoNome] FROM ((([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T2.[DocumentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV72Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV73Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV73Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV74Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV74Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV75Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV75Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV76Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV76Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV77Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV77Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV78Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV78Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV82Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV84Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV84Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV86Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV87Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV88Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV90Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV90Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV91Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV92Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV93Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocDicionarioFinalidade]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002Y3( IGxContext context ,
                                             string AV72Docdicionariowwds_1_filterfulltext ,
                                             int AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV75Docdicionariowwds_4_tfinformacaoid ,
                                             int AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV86Docdicionariowwds_15_tfinformacaonome ,
                                             string AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV90Docdicionariowwds_19_tfdocumentoid ,
                                             int AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV92Docdicionariowwds_21_tfdocumentonome ,
                                             string AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[29];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[InformacaoId], T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[DocDicionarioId], T1.[DocDicionarioTipoTransfInterGa], T3.[DocumentoNome], T4.[HipoteseTratamentoNome], T2.[InformacaoNome], T1.[DocDicionarioFinalidade] FROM ((([DocDicionario] T1 INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = T1.[InformacaoId]) INNER JOIN [Documento] T3 ON T3.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T4 ON T4.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T2.[InformacaoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T4.[HipoteseTratamentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T3.[DocumentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV72Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV73Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV73Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV74Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV74Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV75Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV75Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV76Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV76Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV77Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV77Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV78Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV78Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV82Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV84Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV84Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[InformacaoNome] like @lV86Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[InformacaoNome] = @AV87Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[HipoteseTratamentoNome] like @lV88Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[HipoteseTratamentoNome] = @AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV90Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV90Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV91Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[DocumentoNome] like @lV92Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DocumentoNome] = @AV93Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[DocumentoNome] IS NULL or (T3.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[InformacaoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002Y4( IGxContext context ,
                                             string AV72Docdicionariowwds_1_filterfulltext ,
                                             int AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV75Docdicionariowwds_4_tfinformacaoid ,
                                             int AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV86Docdicionariowwds_15_tfinformacaonome ,
                                             string AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV90Docdicionariowwds_19_tfdocumentoid ,
                                             int AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV92Docdicionariowwds_21_tfdocumentonome ,
                                             string AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[29];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[HipoteseTratamentoId], T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[InformacaoId], T1.[DocDicionarioId], T1.[DocDicionarioTipoTransfInterGa], T3.[DocumentoNome], T2.[HipoteseTratamentoNome], T4.[InformacaoNome], T1.[DocDicionarioFinalidade] FROM ((([DocDicionario] T1 INNER JOIN [HipoteseTratamento] T2 ON T2.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Documento] T3 ON T3.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T2.[HipoteseTratamentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T3.[DocumentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV72Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV73Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV73Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV74Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV74Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (0==AV75Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV75Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV76Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV76Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV77Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV77Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV78Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV78Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV82Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV84Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV84Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV86Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV87Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[HipoteseTratamentoNome] like @lV88Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[HipoteseTratamentoNome] = @AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV90Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV90Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV91Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[DocumentoNome] like @lV92Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DocumentoNome] = @AV93Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[DocumentoNome] IS NULL or (T3.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HipoteseTratamentoId]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002Y5( IGxContext context ,
                                             string AV72Docdicionariowwds_1_filterfulltext ,
                                             int AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV75Docdicionariowwds_4_tfinformacaoid ,
                                             int AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV86Docdicionariowwds_15_tfinformacaonome ,
                                             string AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV90Docdicionariowwds_19_tfdocumentoid ,
                                             int AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV92Docdicionariowwds_21_tfdocumentonome ,
                                             string AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[29];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[InformacaoId], T1.[DocDicionarioId], T1.[DocDicionarioTipoTransfInterGa], T2.[DocumentoNome], T3.[HipoteseTratamentoNome], T4.[InformacaoNome], T1.[DocDicionarioFinalidade] FROM ((([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T2.[DocumentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV72Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV73Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV73Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (0==AV74Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV74Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (0==AV75Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV75Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (0==AV76Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV76Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (0==AV77Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV77Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (0==AV78Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV78Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV82Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV84Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV84Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV86Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV87Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV88Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV90Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV90Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV91Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV92Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV93Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentoId]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002Y6( IGxContext context ,
                                             string AV72Docdicionariowwds_1_filterfulltext ,
                                             int AV73Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV74Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV75Docdicionariowwds_4_tfinformacaoid ,
                                             int AV76Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV77Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV78Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV82Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV84Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV87Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV86Docdicionariowwds_15_tfinformacaonome ,
                                             string AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV88Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV90Docdicionariowwds_19_tfdocumentoid ,
                                             int AV91Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV93Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV92Docdicionariowwds_21_tfdocumentonome ,
                                             string AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[29];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[DocDicionarioTipoTransfInterGa], T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[InformacaoId], T1.[DocDicionarioId], T2.[DocumentoNome], T3.[HipoteseTratamentoNome], T4.[InformacaoNome], T1.[DocDicionarioFinalidade] FROM ((([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T2.[DocumentoNome] like '%' + @lV72Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV72Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV73Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV73Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (0==AV74Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV74Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (0==AV75Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV75Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (0==AV76Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV76Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (0==AV77Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV77Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (0==AV78Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV78Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV79Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV80Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV81Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV82Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV84Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV84Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV86Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV87Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV87Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV88Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV90Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV90Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (0==AV91Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV91Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV92Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV93Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV93Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( StringUtil.StrCmp(AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocDicionarioTipoTransfInterGa]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002Y2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] );
               case 1 :
                     return conditional_P002Y3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] );
               case 2 :
                     return conditional_P002Y4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] );
               case 3 :
                     return conditional_P002Y5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] );
               case 4 :
                     return conditional_P002Y6(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002Y2;
          prmP002Y2 = new Object[] {
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV74Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV75Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV76Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV77Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV78Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV82Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV84Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV86Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV87Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV88Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV90Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV92Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV93Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP002Y3;
          prmP002Y3 = new Object[] {
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV74Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV75Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV76Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV77Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV78Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV82Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV84Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV86Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV87Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV88Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV90Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV92Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV93Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP002Y4;
          prmP002Y4 = new Object[] {
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV74Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV75Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV76Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV77Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV78Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV82Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV84Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV86Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV87Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV88Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV90Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV92Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV93Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP002Y5;
          prmP002Y5 = new Object[] {
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV74Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV75Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV76Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV77Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV78Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV82Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV84Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV86Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV87Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV88Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV90Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV92Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV93Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP002Y6;
          prmP002Y6 = new Object[] {
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV72Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV74Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV75Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV76Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV77Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV78Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV82Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV83Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV84Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV85Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV86Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV87Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV88Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV89Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV90Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV91Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV92Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV93Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV94Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV95Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Y4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Y5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Y6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.docdicionariowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class docdicionariowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "DocDicionarioWWGetFilterData" )]
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
          permissionPrefix = "docdicionarioww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("docdicionariowwgetfilterdata") )
          {
             return  ;
          }
          docdicionariowwgetfilterdata worker = new docdicionariowwgetfilterdata(context);
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
