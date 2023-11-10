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
   public class docanexowwgetfilterdata : GXProcedure
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
            return "docanexoww_Services_Execute" ;
         }

      }

      public docanexowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docanexowwgetfilterdata( IGxContext context )
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
         this.AV25DDOName = aP0_DDOName;
         this.AV19SearchTxtParms = aP1_SearchTxtParms;
         this.AV24SearchTxtTo = aP2_SearchTxtTo;
         this.AV29OptionsJson = "" ;
         this.AV32OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV29OptionsJson;
         aP4_OptionsDescJson=this.AV32OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         docanexowwgetfilterdata objdocanexowwgetfilterdata;
         objdocanexowwgetfilterdata = new docanexowwgetfilterdata();
         objdocanexowwgetfilterdata.AV25DDOName = aP0_DDOName;
         objdocanexowwgetfilterdata.AV19SearchTxtParms = aP1_SearchTxtParms;
         objdocanexowwgetfilterdata.AV24SearchTxtTo = aP2_SearchTxtTo;
         objdocanexowwgetfilterdata.AV29OptionsJson = "" ;
         objdocanexowwgetfilterdata.AV32OptionsDescJson = "" ;
         objdocanexowwgetfilterdata.AV34OptionIndexesJson = "" ;
         objdocanexowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdocanexowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objdocanexowwgetfilterdata);
         aP3_OptionsJson=this.AV29OptionsJson;
         aP4_OptionsDescJson=this.AV32OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docanexowwgetfilterdata)stateInfo).executePrivate();
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
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV19SearchTxtParms, 1, 2), "."))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxtParms)) ? "" : StringUtil.Substring( AV19SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV25DDOName), "DDO_DOCUMENTONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCUMENTONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV25DDOName), "DDO_DOCANEXODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCANEXODESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV25DDOName), "DDO_DOCANEXOARQUIVO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCANEXOARQUIVOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV29OptionsJson = AV28Options.ToJSonString(false);
         AV32OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("DocAnexoWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocAnexoWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("DocAnexoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV42TFDocumentoNome = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV43TFDocumentoNome_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCANEXODESCRICAO") == 0 )
            {
               AV15TFDocAnexoDescricao = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCANEXODESCRICAO_SEL") == 0 )
            {
               AV16TFDocAnexoDescricao_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCANEXOARQUIVO") == 0 )
            {
               AV44TFDocAnexoArquivo = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCANEXOARQUIVO_SEL") == 0 )
            {
               AV45TFDocAnexoArquivo_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCANEXODATAINCLUSAO") == 0 )
            {
               AV17TFDocAnexoDataInclusao = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV18TFDocAnexoDataInclusao_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCUMENTONOMEOPTIONS' Routine */
         returnInSub = false;
         AV42TFDocumentoNome = AV23SearchTxt;
         AV43TFDocumentoNome_Sel = "";
         AV50Docanexowwds_1_filterfulltext = AV41FilterFullText;
         AV51Docanexowwds_2_tfdocumentonome = AV42TFDocumentoNome;
         AV52Docanexowwds_3_tfdocumentonome_sel = AV43TFDocumentoNome_Sel;
         AV53Docanexowwds_4_tfdocanexodescricao = AV15TFDocAnexoDescricao;
         AV54Docanexowwds_5_tfdocanexodescricao_sel = AV16TFDocAnexoDescricao_Sel;
         AV55Docanexowwds_6_tfdocanexoarquivo = AV44TFDocAnexoArquivo;
         AV56Docanexowwds_7_tfdocanexoarquivo_sel = AV45TFDocAnexoArquivo_Sel;
         AV57Docanexowwds_8_tfdocanexodatainclusao = AV17TFDocAnexoDataInclusao;
         AV58Docanexowwds_9_tfdocanexodatainclusao_to = AV18TFDocAnexoDataInclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Docanexowwds_1_filterfulltext ,
                                              AV52Docanexowwds_3_tfdocumentonome_sel ,
                                              AV51Docanexowwds_2_tfdocumentonome ,
                                              AV54Docanexowwds_5_tfdocanexodescricao_sel ,
                                              AV53Docanexowwds_4_tfdocanexodescricao ,
                                              AV56Docanexowwds_7_tfdocanexoarquivo_sel ,
                                              AV55Docanexowwds_6_tfdocanexoarquivo ,
                                              AV57Docanexowwds_8_tfdocanexodatainclusao ,
                                              AV58Docanexowwds_9_tfdocanexodatainclusao_to ,
                                              A76DocumentoNome ,
                                              A94DocAnexoDescricao ,
                                              A95DocAnexoArquivo ,
                                              A96DocAnexoDataInclusao } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV51Docanexowwds_2_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV51Docanexowwds_2_tfdocumentonome), "%", "");
         lV53Docanexowwds_4_tfdocanexodescricao = StringUtil.Concat( StringUtil.RTrim( AV53Docanexowwds_4_tfdocanexodescricao), "%", "");
         lV55Docanexowwds_6_tfdocanexoarquivo = StringUtil.Concat( StringUtil.RTrim( AV55Docanexowwds_6_tfdocanexoarquivo), "%", "");
         /* Using cursor P004V2 */
         pr_default.execute(0, new Object[] {lV50Docanexowwds_1_filterfulltext, lV50Docanexowwds_1_filterfulltext, lV50Docanexowwds_1_filterfulltext, lV51Docanexowwds_2_tfdocumentonome, AV52Docanexowwds_3_tfdocumentonome_sel, lV53Docanexowwds_4_tfdocanexodescricao, AV54Docanexowwds_5_tfdocanexodescricao_sel, lV55Docanexowwds_6_tfdocanexoarquivo, AV56Docanexowwds_7_tfdocanexoarquivo_sel, AV57Docanexowwds_8_tfdocanexodatainclusao, AV58Docanexowwds_9_tfdocanexodatainclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4V2 = false;
            A75DocumentoId = P004V2_A75DocumentoId[0];
            A96DocAnexoDataInclusao = P004V2_A96DocAnexoDataInclusao[0];
            A95DocAnexoArquivo = P004V2_A95DocAnexoArquivo[0];
            A94DocAnexoDescricao = P004V2_A94DocAnexoDescricao[0];
            A76DocumentoNome = P004V2_A76DocumentoNome[0];
            n76DocumentoNome = P004V2_n76DocumentoNome[0];
            A93DocAnexoId = P004V2_A93DocAnexoId[0];
            A76DocumentoNome = P004V2_A76DocumentoNome[0];
            n76DocumentoNome = P004V2_n76DocumentoNome[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004V2_A75DocumentoId[0] == A75DocumentoId ) )
            {
               BRK4V2 = false;
               A93DocAnexoId = P004V2_A93DocAnexoId[0];
               AV35count = (long)(AV35count+1);
               BRK4V2 = true;
               pr_default.readNext(0);
            }
            AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A76DocumentoNome)) ? "<#Empty#>" : A76DocumentoNome);
            AV26InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV26InsertIndex = (int)(AV26InsertIndex+1);
            }
            AV28Options.Add(AV27Option, AV26InsertIndex);
            AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
            if ( AV28Options.Count == AV20SkipItems + 11 )
            {
               AV28Options.RemoveItem(AV28Options.Count);
               AV33OptionIndexes.RemoveItem(AV33OptionIndexes.Count);
            }
            if ( ! BRK4V2 )
            {
               BRK4V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV20SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV33OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADDOCANEXODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV15TFDocAnexoDescricao = AV23SearchTxt;
         AV16TFDocAnexoDescricao_Sel = "";
         AV50Docanexowwds_1_filterfulltext = AV41FilterFullText;
         AV51Docanexowwds_2_tfdocumentonome = AV42TFDocumentoNome;
         AV52Docanexowwds_3_tfdocumentonome_sel = AV43TFDocumentoNome_Sel;
         AV53Docanexowwds_4_tfdocanexodescricao = AV15TFDocAnexoDescricao;
         AV54Docanexowwds_5_tfdocanexodescricao_sel = AV16TFDocAnexoDescricao_Sel;
         AV55Docanexowwds_6_tfdocanexoarquivo = AV44TFDocAnexoArquivo;
         AV56Docanexowwds_7_tfdocanexoarquivo_sel = AV45TFDocAnexoArquivo_Sel;
         AV57Docanexowwds_8_tfdocanexodatainclusao = AV17TFDocAnexoDataInclusao;
         AV58Docanexowwds_9_tfdocanexodatainclusao_to = AV18TFDocAnexoDataInclusao_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Docanexowwds_1_filterfulltext ,
                                              AV52Docanexowwds_3_tfdocumentonome_sel ,
                                              AV51Docanexowwds_2_tfdocumentonome ,
                                              AV54Docanexowwds_5_tfdocanexodescricao_sel ,
                                              AV53Docanexowwds_4_tfdocanexodescricao ,
                                              AV56Docanexowwds_7_tfdocanexoarquivo_sel ,
                                              AV55Docanexowwds_6_tfdocanexoarquivo ,
                                              AV57Docanexowwds_8_tfdocanexodatainclusao ,
                                              AV58Docanexowwds_9_tfdocanexodatainclusao_to ,
                                              A76DocumentoNome ,
                                              A94DocAnexoDescricao ,
                                              A95DocAnexoArquivo ,
                                              A96DocAnexoDataInclusao } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV51Docanexowwds_2_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV51Docanexowwds_2_tfdocumentonome), "%", "");
         lV53Docanexowwds_4_tfdocanexodescricao = StringUtil.Concat( StringUtil.RTrim( AV53Docanexowwds_4_tfdocanexodescricao), "%", "");
         lV55Docanexowwds_6_tfdocanexoarquivo = StringUtil.Concat( StringUtil.RTrim( AV55Docanexowwds_6_tfdocanexoarquivo), "%", "");
         /* Using cursor P004V3 */
         pr_default.execute(1, new Object[] {lV50Docanexowwds_1_filterfulltext, lV50Docanexowwds_1_filterfulltext, lV50Docanexowwds_1_filterfulltext, lV51Docanexowwds_2_tfdocumentonome, AV52Docanexowwds_3_tfdocumentonome_sel, lV53Docanexowwds_4_tfdocanexodescricao, AV54Docanexowwds_5_tfdocanexodescricao_sel, lV55Docanexowwds_6_tfdocanexoarquivo, AV56Docanexowwds_7_tfdocanexoarquivo_sel, AV57Docanexowwds_8_tfdocanexodatainclusao, AV58Docanexowwds_9_tfdocanexodatainclusao_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4V4 = false;
            A75DocumentoId = P004V3_A75DocumentoId[0];
            A94DocAnexoDescricao = P004V3_A94DocAnexoDescricao[0];
            A96DocAnexoDataInclusao = P004V3_A96DocAnexoDataInclusao[0];
            A95DocAnexoArquivo = P004V3_A95DocAnexoArquivo[0];
            A76DocumentoNome = P004V3_A76DocumentoNome[0];
            n76DocumentoNome = P004V3_n76DocumentoNome[0];
            A93DocAnexoId = P004V3_A93DocAnexoId[0];
            A76DocumentoNome = P004V3_A76DocumentoNome[0];
            n76DocumentoNome = P004V3_n76DocumentoNome[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004V3_A94DocAnexoDescricao[0], A94DocAnexoDescricao) == 0 ) )
            {
               BRK4V4 = false;
               A93DocAnexoId = P004V3_A93DocAnexoId[0];
               AV35count = (long)(AV35count+1);
               BRK4V4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A94DocAnexoDescricao)) ? "<#Empty#>" : A94DocAnexoDescricao);
               AV28Options.Add(AV27Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK4V4 )
            {
               BRK4V4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADDOCANEXOARQUIVOOPTIONS' Routine */
         returnInSub = false;
         AV44TFDocAnexoArquivo = AV23SearchTxt;
         AV45TFDocAnexoArquivo_Sel = "";
         AV50Docanexowwds_1_filterfulltext = AV41FilterFullText;
         AV51Docanexowwds_2_tfdocumentonome = AV42TFDocumentoNome;
         AV52Docanexowwds_3_tfdocumentonome_sel = AV43TFDocumentoNome_Sel;
         AV53Docanexowwds_4_tfdocanexodescricao = AV15TFDocAnexoDescricao;
         AV54Docanexowwds_5_tfdocanexodescricao_sel = AV16TFDocAnexoDescricao_Sel;
         AV55Docanexowwds_6_tfdocanexoarquivo = AV44TFDocAnexoArquivo;
         AV56Docanexowwds_7_tfdocanexoarquivo_sel = AV45TFDocAnexoArquivo_Sel;
         AV57Docanexowwds_8_tfdocanexodatainclusao = AV17TFDocAnexoDataInclusao;
         AV58Docanexowwds_9_tfdocanexodatainclusao_to = AV18TFDocAnexoDataInclusao_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV50Docanexowwds_1_filterfulltext ,
                                              AV52Docanexowwds_3_tfdocumentonome_sel ,
                                              AV51Docanexowwds_2_tfdocumentonome ,
                                              AV54Docanexowwds_5_tfdocanexodescricao_sel ,
                                              AV53Docanexowwds_4_tfdocanexodescricao ,
                                              AV56Docanexowwds_7_tfdocanexoarquivo_sel ,
                                              AV55Docanexowwds_6_tfdocanexoarquivo ,
                                              AV57Docanexowwds_8_tfdocanexodatainclusao ,
                                              AV58Docanexowwds_9_tfdocanexodatainclusao_to ,
                                              A76DocumentoNome ,
                                              A94DocAnexoDescricao ,
                                              A95DocAnexoArquivo ,
                                              A96DocAnexoDataInclusao } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV50Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext), "%", "");
         lV51Docanexowwds_2_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV51Docanexowwds_2_tfdocumentonome), "%", "");
         lV53Docanexowwds_4_tfdocanexodescricao = StringUtil.Concat( StringUtil.RTrim( AV53Docanexowwds_4_tfdocanexodescricao), "%", "");
         lV55Docanexowwds_6_tfdocanexoarquivo = StringUtil.Concat( StringUtil.RTrim( AV55Docanexowwds_6_tfdocanexoarquivo), "%", "");
         /* Using cursor P004V4 */
         pr_default.execute(2, new Object[] {lV50Docanexowwds_1_filterfulltext, lV50Docanexowwds_1_filterfulltext, lV50Docanexowwds_1_filterfulltext, lV51Docanexowwds_2_tfdocumentonome, AV52Docanexowwds_3_tfdocumentonome_sel, lV53Docanexowwds_4_tfdocanexodescricao, AV54Docanexowwds_5_tfdocanexodescricao_sel, lV55Docanexowwds_6_tfdocanexoarquivo, AV56Docanexowwds_7_tfdocanexoarquivo_sel, AV57Docanexowwds_8_tfdocanexodatainclusao, AV58Docanexowwds_9_tfdocanexodatainclusao_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4V6 = false;
            A75DocumentoId = P004V4_A75DocumentoId[0];
            A95DocAnexoArquivo = P004V4_A95DocAnexoArquivo[0];
            A96DocAnexoDataInclusao = P004V4_A96DocAnexoDataInclusao[0];
            A94DocAnexoDescricao = P004V4_A94DocAnexoDescricao[0];
            A76DocumentoNome = P004V4_A76DocumentoNome[0];
            n76DocumentoNome = P004V4_n76DocumentoNome[0];
            A93DocAnexoId = P004V4_A93DocAnexoId[0];
            A76DocumentoNome = P004V4_A76DocumentoNome[0];
            n76DocumentoNome = P004V4_n76DocumentoNome[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004V4_A95DocAnexoArquivo[0], A95DocAnexoArquivo) == 0 ) )
            {
               BRK4V6 = false;
               A93DocAnexoId = P004V4_A93DocAnexoId[0];
               AV35count = (long)(AV35count+1);
               BRK4V6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A95DocAnexoArquivo)) ? "<#Empty#>" : A95DocAnexoArquivo);
               AV28Options.Add(AV27Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK4V6 )
            {
               BRK4V6 = true;
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
         AV29OptionsJson = "";
         AV32OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV42TFDocumentoNome = "";
         AV43TFDocumentoNome_Sel = "";
         AV15TFDocAnexoDescricao = "";
         AV16TFDocAnexoDescricao_Sel = "";
         AV44TFDocAnexoArquivo = "";
         AV45TFDocAnexoArquivo_Sel = "";
         AV17TFDocAnexoDataInclusao = DateTime.MinValue;
         AV18TFDocAnexoDataInclusao_To = DateTime.MinValue;
         AV50Docanexowwds_1_filterfulltext = "";
         AV51Docanexowwds_2_tfdocumentonome = "";
         AV52Docanexowwds_3_tfdocumentonome_sel = "";
         AV53Docanexowwds_4_tfdocanexodescricao = "";
         AV54Docanexowwds_5_tfdocanexodescricao_sel = "";
         AV55Docanexowwds_6_tfdocanexoarquivo = "";
         AV56Docanexowwds_7_tfdocanexoarquivo_sel = "";
         AV57Docanexowwds_8_tfdocanexodatainclusao = DateTime.MinValue;
         AV58Docanexowwds_9_tfdocanexodatainclusao_to = DateTime.MinValue;
         scmdbuf = "";
         lV50Docanexowwds_1_filterfulltext = "";
         lV51Docanexowwds_2_tfdocumentonome = "";
         lV53Docanexowwds_4_tfdocanexodescricao = "";
         lV55Docanexowwds_6_tfdocanexoarquivo = "";
         A76DocumentoNome = "";
         A94DocAnexoDescricao = "";
         A95DocAnexoArquivo = "";
         A96DocAnexoDataInclusao = DateTime.MinValue;
         P004V2_A75DocumentoId = new int[1] ;
         P004V2_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004V2_A95DocAnexoArquivo = new string[] {""} ;
         P004V2_A94DocAnexoDescricao = new string[] {""} ;
         P004V2_A76DocumentoNome = new string[] {""} ;
         P004V2_n76DocumentoNome = new bool[] {false} ;
         P004V2_A93DocAnexoId = new int[1] ;
         AV27Option = "";
         P004V3_A75DocumentoId = new int[1] ;
         P004V3_A94DocAnexoDescricao = new string[] {""} ;
         P004V3_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004V3_A95DocAnexoArquivo = new string[] {""} ;
         P004V3_A76DocumentoNome = new string[] {""} ;
         P004V3_n76DocumentoNome = new bool[] {false} ;
         P004V3_A93DocAnexoId = new int[1] ;
         P004V4_A75DocumentoId = new int[1] ;
         P004V4_A95DocAnexoArquivo = new string[] {""} ;
         P004V4_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004V4_A94DocAnexoDescricao = new string[] {""} ;
         P004V4_A76DocumentoNome = new string[] {""} ;
         P004V4_n76DocumentoNome = new bool[] {false} ;
         P004V4_A93DocAnexoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docanexowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004V2_A75DocumentoId, P004V2_A96DocAnexoDataInclusao, P004V2_A95DocAnexoArquivo, P004V2_A94DocAnexoDescricao, P004V2_A76DocumentoNome, P004V2_n76DocumentoNome, P004V2_A93DocAnexoId
               }
               , new Object[] {
               P004V3_A75DocumentoId, P004V3_A94DocAnexoDescricao, P004V3_A96DocAnexoDataInclusao, P004V3_A95DocAnexoArquivo, P004V3_A76DocumentoNome, P004V3_n76DocumentoNome, P004V3_A93DocAnexoId
               }
               , new Object[] {
               P004V4_A75DocumentoId, P004V4_A95DocAnexoArquivo, P004V4_A96DocAnexoDataInclusao, P004V4_A94DocAnexoDescricao, P004V4_A76DocumentoNome, P004V4_n76DocumentoNome, P004V4_A93DocAnexoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV48GXV1 ;
      private int A75DocumentoId ;
      private int A93DocAnexoId ;
      private int AV26InsertIndex ;
      private long AV35count ;
      private string scmdbuf ;
      private DateTime AV17TFDocAnexoDataInclusao ;
      private DateTime AV18TFDocAnexoDataInclusao_To ;
      private DateTime AV57Docanexowwds_8_tfdocanexodatainclusao ;
      private DateTime AV58Docanexowwds_9_tfdocanexodatainclusao_to ;
      private DateTime A96DocAnexoDataInclusao ;
      private bool returnInSub ;
      private bool BRK4V2 ;
      private bool n76DocumentoNome ;
      private bool BRK4V4 ;
      private bool BRK4V6 ;
      private string AV29OptionsJson ;
      private string AV32OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV25DDOName ;
      private string AV19SearchTxtParms ;
      private string AV24SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42TFDocumentoNome ;
      private string AV43TFDocumentoNome_Sel ;
      private string AV15TFDocAnexoDescricao ;
      private string AV16TFDocAnexoDescricao_Sel ;
      private string AV44TFDocAnexoArquivo ;
      private string AV45TFDocAnexoArquivo_Sel ;
      private string AV50Docanexowwds_1_filterfulltext ;
      private string AV51Docanexowwds_2_tfdocumentonome ;
      private string AV52Docanexowwds_3_tfdocumentonome_sel ;
      private string AV53Docanexowwds_4_tfdocanexodescricao ;
      private string AV54Docanexowwds_5_tfdocanexodescricao_sel ;
      private string AV55Docanexowwds_6_tfdocanexoarquivo ;
      private string AV56Docanexowwds_7_tfdocanexoarquivo_sel ;
      private string lV50Docanexowwds_1_filterfulltext ;
      private string lV51Docanexowwds_2_tfdocumentonome ;
      private string lV53Docanexowwds_4_tfdocanexodescricao ;
      private string lV55Docanexowwds_6_tfdocanexoarquivo ;
      private string A76DocumentoNome ;
      private string A94DocAnexoDescricao ;
      private string A95DocAnexoArquivo ;
      private string AV27Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004V2_A75DocumentoId ;
      private DateTime[] P004V2_A96DocAnexoDataInclusao ;
      private string[] P004V2_A95DocAnexoArquivo ;
      private string[] P004V2_A94DocAnexoDescricao ;
      private string[] P004V2_A76DocumentoNome ;
      private bool[] P004V2_n76DocumentoNome ;
      private int[] P004V2_A93DocAnexoId ;
      private int[] P004V3_A75DocumentoId ;
      private string[] P004V3_A94DocAnexoDescricao ;
      private DateTime[] P004V3_A96DocAnexoDataInclusao ;
      private string[] P004V3_A95DocAnexoArquivo ;
      private string[] P004V3_A76DocumentoNome ;
      private bool[] P004V3_n76DocumentoNome ;
      private int[] P004V3_A93DocAnexoId ;
      private int[] P004V4_A75DocumentoId ;
      private string[] P004V4_A95DocAnexoArquivo ;
      private DateTime[] P004V4_A96DocAnexoDataInclusao ;
      private string[] P004V4_A94DocAnexoDescricao ;
      private string[] P004V4_A76DocumentoNome ;
      private bool[] P004V4_n76DocumentoNome ;
      private int[] P004V4_A93DocAnexoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
   }

   public class docanexowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004V2( IGxContext context ,
                                             string AV50Docanexowwds_1_filterfulltext ,
                                             string AV52Docanexowwds_3_tfdocumentonome_sel ,
                                             string AV51Docanexowwds_2_tfdocumentonome ,
                                             string AV54Docanexowwds_5_tfdocanexodescricao_sel ,
                                             string AV53Docanexowwds_4_tfdocanexodescricao ,
                                             string AV56Docanexowwds_7_tfdocanexoarquivo_sel ,
                                             string AV55Docanexowwds_6_tfdocanexoarquivo ,
                                             DateTime AV57Docanexowwds_8_tfdocanexodatainclusao ,
                                             DateTime AV58Docanexowwds_9_tfdocanexodatainclusao_to ,
                                             string A76DocumentoNome ,
                                             string A94DocAnexoDescricao ,
                                             string A95DocAnexoArquivo ,
                                             DateTime A96DocAnexoDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocAnexoDataInclusao], T1.[DocAnexoArquivo], T1.[DocAnexoDescricao], T2.[DocumentoNome], T1.[DocAnexoId] FROM ([DocAnexo] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.[DocumentoNome] like '%' + @lV50Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoDescricao] like '%' + @lV50Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoArquivo] like '%' + @lV50Docanexowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_3_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Docanexowwds_2_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV51Docanexowwds_2_tfdocumentonome)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_3_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV52Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV52Docanexowwds_3_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV52Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_5_tfdocanexodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Docanexowwds_4_tfdocanexodescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] like @lV53Docanexowwds_4_tfdocanexodescricao)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_5_tfdocanexodescricao_sel)) && ! ( StringUtil.StrCmp(AV54Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] = @AV54Docanexowwds_5_tfdocanexodescricao_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV54Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_7_tfdocanexoarquivo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Docanexowwds_6_tfdocanexoarquivo)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] like @lV55Docanexowwds_6_tfdocanexoarquivo)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_7_tfdocanexoarquivo_sel)) && ! ( StringUtil.StrCmp(AV56Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] = @AV56Docanexowwds_7_tfdocanexoarquivo_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoArquivo] = ''))");
         }
         if ( ! (DateTime.MinValue==AV57Docanexowwds_8_tfdocanexodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] >= @AV57Docanexowwds_8_tfdocanexodatainclusao)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Docanexowwds_9_tfdocanexodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] <= @AV58Docanexowwds_9_tfdocanexodatainclusao_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004V3( IGxContext context ,
                                             string AV50Docanexowwds_1_filterfulltext ,
                                             string AV52Docanexowwds_3_tfdocumentonome_sel ,
                                             string AV51Docanexowwds_2_tfdocumentonome ,
                                             string AV54Docanexowwds_5_tfdocanexodescricao_sel ,
                                             string AV53Docanexowwds_4_tfdocanexodescricao ,
                                             string AV56Docanexowwds_7_tfdocanexoarquivo_sel ,
                                             string AV55Docanexowwds_6_tfdocanexoarquivo ,
                                             DateTime AV57Docanexowwds_8_tfdocanexodatainclusao ,
                                             DateTime AV58Docanexowwds_9_tfdocanexodatainclusao_to ,
                                             string A76DocumentoNome ,
                                             string A94DocAnexoDescricao ,
                                             string A95DocAnexoArquivo ,
                                             DateTime A96DocAnexoDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocAnexoDescricao], T1.[DocAnexoDataInclusao], T1.[DocAnexoArquivo], T2.[DocumentoNome], T1.[DocAnexoId] FROM ([DocAnexo] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.[DocumentoNome] like '%' + @lV50Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoDescricao] like '%' + @lV50Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoArquivo] like '%' + @lV50Docanexowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_3_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Docanexowwds_2_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV51Docanexowwds_2_tfdocumentonome)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_3_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV52Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV52Docanexowwds_3_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV52Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_5_tfdocanexodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Docanexowwds_4_tfdocanexodescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] like @lV53Docanexowwds_4_tfdocanexodescricao)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_5_tfdocanexodescricao_sel)) && ! ( StringUtil.StrCmp(AV54Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] = @AV54Docanexowwds_5_tfdocanexodescricao_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV54Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_7_tfdocanexoarquivo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Docanexowwds_6_tfdocanexoarquivo)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] like @lV55Docanexowwds_6_tfdocanexoarquivo)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_7_tfdocanexoarquivo_sel)) && ! ( StringUtil.StrCmp(AV56Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] = @AV56Docanexowwds_7_tfdocanexoarquivo_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoArquivo] = ''))");
         }
         if ( ! (DateTime.MinValue==AV57Docanexowwds_8_tfdocanexodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] >= @AV57Docanexowwds_8_tfdocanexodatainclusao)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Docanexowwds_9_tfdocanexodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] <= @AV58Docanexowwds_9_tfdocanexodatainclusao_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocAnexoDescricao]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004V4( IGxContext context ,
                                             string AV50Docanexowwds_1_filterfulltext ,
                                             string AV52Docanexowwds_3_tfdocumentonome_sel ,
                                             string AV51Docanexowwds_2_tfdocumentonome ,
                                             string AV54Docanexowwds_5_tfdocanexodescricao_sel ,
                                             string AV53Docanexowwds_4_tfdocanexodescricao ,
                                             string AV56Docanexowwds_7_tfdocanexoarquivo_sel ,
                                             string AV55Docanexowwds_6_tfdocanexoarquivo ,
                                             DateTime AV57Docanexowwds_8_tfdocanexodatainclusao ,
                                             DateTime AV58Docanexowwds_9_tfdocanexodatainclusao_to ,
                                             string A76DocumentoNome ,
                                             string A94DocAnexoDescricao ,
                                             string A95DocAnexoArquivo ,
                                             DateTime A96DocAnexoDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocAnexoArquivo], T1.[DocAnexoDataInclusao], T1.[DocAnexoDescricao], T2.[DocumentoNome], T1.[DocAnexoId] FROM ([DocAnexo] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Docanexowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.[DocumentoNome] like '%' + @lV50Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoDescricao] like '%' + @lV50Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoArquivo] like '%' + @lV50Docanexowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_3_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Docanexowwds_2_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV51Docanexowwds_2_tfdocumentonome)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_3_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV52Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV52Docanexowwds_3_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV52Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_5_tfdocanexodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Docanexowwds_4_tfdocanexodescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] like @lV53Docanexowwds_4_tfdocanexodescricao)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_5_tfdocanexodescricao_sel)) && ! ( StringUtil.StrCmp(AV54Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] = @AV54Docanexowwds_5_tfdocanexodescricao_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV54Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_7_tfdocanexoarquivo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Docanexowwds_6_tfdocanexoarquivo)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] like @lV55Docanexowwds_6_tfdocanexoarquivo)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_7_tfdocanexoarquivo_sel)) && ! ( StringUtil.StrCmp(AV56Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] = @AV56Docanexowwds_7_tfdocanexoarquivo_sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoArquivo] = ''))");
         }
         if ( ! (DateTime.MinValue==AV57Docanexowwds_8_tfdocanexodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] >= @AV57Docanexowwds_8_tfdocanexodatainclusao)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Docanexowwds_9_tfdocanexodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] <= @AV58Docanexowwds_9_tfdocanexodatainclusao_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocAnexoArquivo]";
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
                     return conditional_P004V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
               case 1 :
                     return conditional_P004V3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
               case 2 :
                     return conditional_P004V4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
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
          Object[] prmP004V2;
          prmP004V2 = new Object[] {
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Docanexowwds_2_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Docanexowwds_3_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Docanexowwds_4_tfdocanexodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Docanexowwds_5_tfdocanexodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Docanexowwds_6_tfdocanexoarquivo",GXType.NVarChar,200,0) ,
          new ParDef("@AV56Docanexowwds_7_tfdocanexoarquivo_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Docanexowwds_8_tfdocanexodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV58Docanexowwds_9_tfdocanexodatainclusao_to",GXType.Date,8,0)
          };
          Object[] prmP004V3;
          prmP004V3 = new Object[] {
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Docanexowwds_2_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Docanexowwds_3_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Docanexowwds_4_tfdocanexodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Docanexowwds_5_tfdocanexodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Docanexowwds_6_tfdocanexoarquivo",GXType.NVarChar,200,0) ,
          new ParDef("@AV56Docanexowwds_7_tfdocanexoarquivo_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Docanexowwds_8_tfdocanexodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV58Docanexowwds_9_tfdocanexodatainclusao_to",GXType.Date,8,0)
          };
          Object[] prmP004V4;
          prmP004V4 = new Object[] {
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Docanexowwds_2_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Docanexowwds_3_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Docanexowwds_4_tfdocanexodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Docanexowwds_5_tfdocanexodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Docanexowwds_6_tfdocanexoarquivo",GXType.NVarChar,200,0) ,
          new ParDef("@AV56Docanexowwds_7_tfdocanexoarquivo_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Docanexowwds_8_tfdocanexodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV58Docanexowwds_9_tfdocanexodatainclusao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004V3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004V4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004V4,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.docanexowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class docanexowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "DocAnexoWWGetFilterData" )]
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
          permissionPrefix = "docanexoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("docanexowwgetfilterdata") )
          {
             return  ;
          }
          docanexowwgetfilterdata worker = new docanexowwgetfilterdata(context);
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
