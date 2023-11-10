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
   public class documentowwgetfilterdata : GXProcedure
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
            return "documentoww_Services_Execute" ;
         }

      }

      public documentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentowwgetfilterdata( IGxContext context )
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
         this.AV60DDOName = aP0_DDOName;
         this.AV54SearchTxtParms = aP1_SearchTxtParms;
         this.AV59SearchTxtTo = aP2_SearchTxtTo;
         this.AV64OptionsJson = "" ;
         this.AV67OptionsDescJson = "" ;
         this.AV69OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV64OptionsJson;
         aP4_OptionsDescJson=this.AV67OptionsDescJson;
         aP5_OptionIndexesJson=this.AV69OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV69OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         documentowwgetfilterdata objdocumentowwgetfilterdata;
         objdocumentowwgetfilterdata = new documentowwgetfilterdata();
         objdocumentowwgetfilterdata.AV60DDOName = aP0_DDOName;
         objdocumentowwgetfilterdata.AV54SearchTxtParms = aP1_SearchTxtParms;
         objdocumentowwgetfilterdata.AV59SearchTxtTo = aP2_SearchTxtTo;
         objdocumentowwgetfilterdata.AV64OptionsJson = "" ;
         objdocumentowwgetfilterdata.AV67OptionsDescJson = "" ;
         objdocumentowwgetfilterdata.AV69OptionIndexesJson = "" ;
         objdocumentowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdocumentowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objdocumentowwgetfilterdata);
         aP3_OptionsJson=this.AV64OptionsJson;
         aP4_OptionsDescJson=this.AV67OptionsDescJson;
         aP5_OptionIndexesJson=this.AV69OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentowwgetfilterdata)stateInfo).executePrivate();
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
         AV63Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV66OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV68OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV57MaxItems = 10;
         AV56PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV54SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV54SearchTxtParms, 1, 2), "."))));
         AV58SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV54SearchTxtParms)) ? "" : StringUtil.Substring( AV54SearchTxtParms, 3, -1));
         AV55SkipItems = (short)(AV56PageIndex*AV57MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_DOCUMENTONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCUMENTONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_PROCESSONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROCESSONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_SUBPROCESSONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUBPROCESSONOMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV64OptionsJson = AV63Options.ToJSonString(false);
         AV67OptionsDescJson = AV66OptionsDesc.ToJSonString(false);
         AV69OptionIndexesJson = AV68OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV71Session.Get("DocumentoWWGridState"), "") == 0 )
         {
            AV73GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV73GridState.FromXml(AV71Session.Get("DocumentoWWGridState"), null, "", "");
         }
         AV125GXV1 = 1;
         while ( AV125GXV1 <= AV73GridState.gxTpr_Filtervalues.Count )
         {
            AV74GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV73GridState.gxTpr_Filtervalues.Item(AV125GXV1));
            if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV11TFDocumentoId = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Value, "."));
               AV12TFDocumentoId_To = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV13TFDocumentoNome = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV14TFDocumentoNome_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFPROCESSONOME") == 0 )
            {
               AV79TFProcessoNome = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFPROCESSONOME_SEL") == 0 )
            {
               AV80TFProcessoNome_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFSUBPROCESSONOME") == 0 )
            {
               AV81TFSubprocessoNome = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFSUBPROCESSONOME_SEL") == 0 )
            {
               AV82TFSubprocessoNome_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFDOCUMENTODATAALTERACAO") == 0 )
            {
               AV83TFDocumentoDataAlteracao = context.localUtil.CToT( AV74GridStateFilterValue.gxTpr_Value, 2);
               AV84TFDocumentoDataAlteracao_To = context.localUtil.CToT( AV74GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFDOCUMENTODATAINCLUSAO") == 0 )
            {
               AV88TFDocumentoDataInclusao = context.localUtil.CToT( AV74GridStateFilterValue.gxTpr_Value, 2);
               AV89TFDocumentoDataInclusao_To = context.localUtil.CToT( AV74GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV125GXV1 = (int)(AV125GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCUMENTONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFDocumentoNome = AV58SearchTxt;
         AV14TFDocumentoNome_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A75DocumentoId ,
                                              AV122Documentos ,
                                              AV11TFDocumentoId ,
                                              AV12TFDocumentoId_To ,
                                              AV14TFDocumentoNome_Sel ,
                                              AV13TFDocumentoNome ,
                                              AV80TFProcessoNome_Sel ,
                                              AV79TFProcessoNome ,
                                              AV82TFSubprocessoNome_Sel ,
                                              AV81TFSubprocessoNome ,
                                              AV83TFDocumentoDataAlteracao ,
                                              AV84TFDocumentoDataAlteracao_To ,
                                              AV88TFDocumentoDataInclusao ,
                                              AV89TFDocumentoDataInclusao_To ,
                                              A76DocumentoNome ,
                                              A17ProcessoNome ,
                                              A21SubprocessoNome ,
                                              A109DocumentoDataAlteracao ,
                                              A108DocumentoDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFDocumentoNome = StringUtil.Concat( StringUtil.RTrim( AV13TFDocumentoNome), "%", "");
         lV79TFProcessoNome = StringUtil.Concat( StringUtil.RTrim( AV79TFProcessoNome), "%", "");
         lV81TFSubprocessoNome = StringUtil.Concat( StringUtil.RTrim( AV81TFSubprocessoNome), "%", "");
         /* Using cursor P004O2 */
         pr_default.execute(0, new Object[] {AV11TFDocumentoId, AV12TFDocumentoId_To, lV13TFDocumentoNome, AV14TFDocumentoNome_Sel, lV79TFProcessoNome, AV80TFProcessoNome_Sel, lV81TFSubprocessoNome, AV82TFSubprocessoNome_Sel, AV83TFDocumentoDataAlteracao, AV84TFDocumentoDataAlteracao_To, AV88TFDocumentoDataInclusao, AV89TFDocumentoDataInclusao_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4O2 = false;
            A20SubprocessoId = P004O2_A20SubprocessoId[0];
            n20SubprocessoId = P004O2_n20SubprocessoId[0];
            A16ProcessoId = P004O2_A16ProcessoId[0];
            n16ProcessoId = P004O2_n16ProcessoId[0];
            A76DocumentoNome = P004O2_A76DocumentoNome[0];
            n76DocumentoNome = P004O2_n76DocumentoNome[0];
            A108DocumentoDataInclusao = P004O2_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = P004O2_n108DocumentoDataInclusao[0];
            A109DocumentoDataAlteracao = P004O2_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = P004O2_n109DocumentoDataAlteracao[0];
            A21SubprocessoNome = P004O2_A21SubprocessoNome[0];
            A17ProcessoNome = P004O2_A17ProcessoNome[0];
            A75DocumentoId = P004O2_A75DocumentoId[0];
            A16ProcessoId = P004O2_A16ProcessoId[0];
            n16ProcessoId = P004O2_n16ProcessoId[0];
            A21SubprocessoNome = P004O2_A21SubprocessoNome[0];
            A17ProcessoNome = P004O2_A17ProcessoNome[0];
            AV70count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004O2_A76DocumentoNome[0], A76DocumentoNome) == 0 ) )
            {
               BRK4O2 = false;
               A75DocumentoId = P004O2_A75DocumentoId[0];
               if ( (AV122Documentos.IndexOf(A75DocumentoId)>0) )
               {
                  AV70count = (long)(AV70count+1);
               }
               BRK4O2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV55SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A76DocumentoNome)) ? "<#Empty#>" : A76DocumentoNome);
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV55SkipItems = (short)(AV55SkipItems-1);
            }
            if ( ! BRK4O2 )
            {
               BRK4O2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROCESSONOMEOPTIONS' Routine */
         returnInSub = false;
         AV79TFProcessoNome = AV58SearchTxt;
         AV80TFProcessoNome_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A75DocumentoId ,
                                              AV122Documentos ,
                                              AV11TFDocumentoId ,
                                              AV12TFDocumentoId_To ,
                                              AV14TFDocumentoNome_Sel ,
                                              AV13TFDocumentoNome ,
                                              AV80TFProcessoNome_Sel ,
                                              AV79TFProcessoNome ,
                                              AV82TFSubprocessoNome_Sel ,
                                              AV81TFSubprocessoNome ,
                                              AV83TFDocumentoDataAlteracao ,
                                              AV84TFDocumentoDataAlteracao_To ,
                                              AV88TFDocumentoDataInclusao ,
                                              AV89TFDocumentoDataInclusao_To ,
                                              A76DocumentoNome ,
                                              A17ProcessoNome ,
                                              A21SubprocessoNome ,
                                              A109DocumentoDataAlteracao ,
                                              A108DocumentoDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFDocumentoNome = StringUtil.Concat( StringUtil.RTrim( AV13TFDocumentoNome), "%", "");
         lV79TFProcessoNome = StringUtil.Concat( StringUtil.RTrim( AV79TFProcessoNome), "%", "");
         lV81TFSubprocessoNome = StringUtil.Concat( StringUtil.RTrim( AV81TFSubprocessoNome), "%", "");
         /* Using cursor P004O3 */
         pr_default.execute(1, new Object[] {AV11TFDocumentoId, AV12TFDocumentoId_To, lV13TFDocumentoNome, AV14TFDocumentoNome_Sel, lV79TFProcessoNome, AV80TFProcessoNome_Sel, lV81TFSubprocessoNome, AV82TFSubprocessoNome_Sel, AV83TFDocumentoDataAlteracao, AV84TFDocumentoDataAlteracao_To, AV88TFDocumentoDataInclusao, AV89TFDocumentoDataInclusao_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4O4 = false;
            A20SubprocessoId = P004O3_A20SubprocessoId[0];
            n20SubprocessoId = P004O3_n20SubprocessoId[0];
            A16ProcessoId = P004O3_A16ProcessoId[0];
            n16ProcessoId = P004O3_n16ProcessoId[0];
            A17ProcessoNome = P004O3_A17ProcessoNome[0];
            A108DocumentoDataInclusao = P004O3_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = P004O3_n108DocumentoDataInclusao[0];
            A109DocumentoDataAlteracao = P004O3_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = P004O3_n109DocumentoDataAlteracao[0];
            A21SubprocessoNome = P004O3_A21SubprocessoNome[0];
            A76DocumentoNome = P004O3_A76DocumentoNome[0];
            n76DocumentoNome = P004O3_n76DocumentoNome[0];
            A75DocumentoId = P004O3_A75DocumentoId[0];
            A16ProcessoId = P004O3_A16ProcessoId[0];
            n16ProcessoId = P004O3_n16ProcessoId[0];
            A21SubprocessoNome = P004O3_A21SubprocessoNome[0];
            A17ProcessoNome = P004O3_A17ProcessoNome[0];
            AV70count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004O3_A17ProcessoNome[0], A17ProcessoNome) == 0 ) )
            {
               BRK4O4 = false;
               A20SubprocessoId = P004O3_A20SubprocessoId[0];
               n20SubprocessoId = P004O3_n20SubprocessoId[0];
               A16ProcessoId = P004O3_A16ProcessoId[0];
               n16ProcessoId = P004O3_n16ProcessoId[0];
               A75DocumentoId = P004O3_A75DocumentoId[0];
               A16ProcessoId = P004O3_A16ProcessoId[0];
               n16ProcessoId = P004O3_n16ProcessoId[0];
               if ( (AV122Documentos.IndexOf(A75DocumentoId)>0) )
               {
                  AV70count = (long)(AV70count+1);
               }
               BRK4O4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV55SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A17ProcessoNome)) ? "<#Empty#>" : A17ProcessoNome);
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV55SkipItems = (short)(AV55SkipItems-1);
            }
            if ( ! BRK4O4 )
            {
               BRK4O4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSUBPROCESSONOMEOPTIONS' Routine */
         returnInSub = false;
         AV81TFSubprocessoNome = AV58SearchTxt;
         AV82TFSubprocessoNome_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A75DocumentoId ,
                                              AV122Documentos ,
                                              AV11TFDocumentoId ,
                                              AV12TFDocumentoId_To ,
                                              AV14TFDocumentoNome_Sel ,
                                              AV13TFDocumentoNome ,
                                              AV80TFProcessoNome_Sel ,
                                              AV79TFProcessoNome ,
                                              AV82TFSubprocessoNome_Sel ,
                                              AV81TFSubprocessoNome ,
                                              AV83TFDocumentoDataAlteracao ,
                                              AV84TFDocumentoDataAlteracao_To ,
                                              AV88TFDocumentoDataInclusao ,
                                              AV89TFDocumentoDataInclusao_To ,
                                              A76DocumentoNome ,
                                              A17ProcessoNome ,
                                              A21SubprocessoNome ,
                                              A109DocumentoDataAlteracao ,
                                              A108DocumentoDataInclusao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFDocumentoNome = StringUtil.Concat( StringUtil.RTrim( AV13TFDocumentoNome), "%", "");
         lV79TFProcessoNome = StringUtil.Concat( StringUtil.RTrim( AV79TFProcessoNome), "%", "");
         lV81TFSubprocessoNome = StringUtil.Concat( StringUtil.RTrim( AV81TFSubprocessoNome), "%", "");
         /* Using cursor P004O4 */
         pr_default.execute(2, new Object[] {AV11TFDocumentoId, AV12TFDocumentoId_To, lV13TFDocumentoNome, AV14TFDocumentoNome_Sel, lV79TFProcessoNome, AV80TFProcessoNome_Sel, lV81TFSubprocessoNome, AV82TFSubprocessoNome_Sel, AV83TFDocumentoDataAlteracao, AV84TFDocumentoDataAlteracao_To, AV88TFDocumentoDataInclusao, AV89TFDocumentoDataInclusao_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4O6 = false;
            A20SubprocessoId = P004O4_A20SubprocessoId[0];
            n20SubprocessoId = P004O4_n20SubprocessoId[0];
            A16ProcessoId = P004O4_A16ProcessoId[0];
            n16ProcessoId = P004O4_n16ProcessoId[0];
            A21SubprocessoNome = P004O4_A21SubprocessoNome[0];
            A108DocumentoDataInclusao = P004O4_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = P004O4_n108DocumentoDataInclusao[0];
            A109DocumentoDataAlteracao = P004O4_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = P004O4_n109DocumentoDataAlteracao[0];
            A17ProcessoNome = P004O4_A17ProcessoNome[0];
            A76DocumentoNome = P004O4_A76DocumentoNome[0];
            n76DocumentoNome = P004O4_n76DocumentoNome[0];
            A75DocumentoId = P004O4_A75DocumentoId[0];
            A16ProcessoId = P004O4_A16ProcessoId[0];
            n16ProcessoId = P004O4_n16ProcessoId[0];
            A21SubprocessoNome = P004O4_A21SubprocessoNome[0];
            A17ProcessoNome = P004O4_A17ProcessoNome[0];
            AV70count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004O4_A21SubprocessoNome[0], A21SubprocessoNome) == 0 ) )
            {
               BRK4O6 = false;
               A20SubprocessoId = P004O4_A20SubprocessoId[0];
               n20SubprocessoId = P004O4_n20SubprocessoId[0];
               A75DocumentoId = P004O4_A75DocumentoId[0];
               if ( (AV122Documentos.IndexOf(A75DocumentoId)>0) )
               {
                  AV70count = (long)(AV70count+1);
               }
               BRK4O6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV55SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A21SubprocessoNome)) ? "<#Empty#>" : A21SubprocessoNome);
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV55SkipItems = (short)(AV55SkipItems-1);
            }
            if ( ! BRK4O6 )
            {
               BRK4O6 = true;
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
         AV64OptionsJson = "";
         AV67OptionsDescJson = "";
         AV69OptionIndexesJson = "";
         AV63Options = new GxSimpleCollection<string>();
         AV66OptionsDesc = new GxSimpleCollection<string>();
         AV68OptionIndexes = new GxSimpleCollection<string>();
         AV58SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV71Session = context.GetSession();
         AV73GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV74GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV13TFDocumentoNome = "";
         AV14TFDocumentoNome_Sel = "";
         AV79TFProcessoNome = "";
         AV80TFProcessoNome_Sel = "";
         AV81TFSubprocessoNome = "";
         AV82TFSubprocessoNome_Sel = "";
         AV83TFDocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         AV84TFDocumentoDataAlteracao_To = (DateTime)(DateTime.MinValue);
         AV88TFDocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         AV89TFDocumentoDataInclusao_To = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV13TFDocumentoNome = "";
         lV79TFProcessoNome = "";
         lV81TFSubprocessoNome = "";
         AV122Documentos = new GxSimpleCollection<int>();
         A76DocumentoNome = "";
         A17ProcessoNome = "";
         A21SubprocessoNome = "";
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         P004O2_A20SubprocessoId = new int[1] ;
         P004O2_n20SubprocessoId = new bool[] {false} ;
         P004O2_A16ProcessoId = new int[1] ;
         P004O2_n16ProcessoId = new bool[] {false} ;
         P004O2_A76DocumentoNome = new string[] {""} ;
         P004O2_n76DocumentoNome = new bool[] {false} ;
         P004O2_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004O2_n108DocumentoDataInclusao = new bool[] {false} ;
         P004O2_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P004O2_n109DocumentoDataAlteracao = new bool[] {false} ;
         P004O2_A21SubprocessoNome = new string[] {""} ;
         P004O2_A17ProcessoNome = new string[] {""} ;
         P004O2_A75DocumentoId = new int[1] ;
         AV62Option = "";
         P004O3_A20SubprocessoId = new int[1] ;
         P004O3_n20SubprocessoId = new bool[] {false} ;
         P004O3_A16ProcessoId = new int[1] ;
         P004O3_n16ProcessoId = new bool[] {false} ;
         P004O3_A17ProcessoNome = new string[] {""} ;
         P004O3_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004O3_n108DocumentoDataInclusao = new bool[] {false} ;
         P004O3_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P004O3_n109DocumentoDataAlteracao = new bool[] {false} ;
         P004O3_A21SubprocessoNome = new string[] {""} ;
         P004O3_A76DocumentoNome = new string[] {""} ;
         P004O3_n76DocumentoNome = new bool[] {false} ;
         P004O3_A75DocumentoId = new int[1] ;
         P004O4_A20SubprocessoId = new int[1] ;
         P004O4_n20SubprocessoId = new bool[] {false} ;
         P004O4_A16ProcessoId = new int[1] ;
         P004O4_n16ProcessoId = new bool[] {false} ;
         P004O4_A21SubprocessoNome = new string[] {""} ;
         P004O4_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004O4_n108DocumentoDataInclusao = new bool[] {false} ;
         P004O4_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P004O4_n109DocumentoDataAlteracao = new bool[] {false} ;
         P004O4_A17ProcessoNome = new string[] {""} ;
         P004O4_A76DocumentoNome = new string[] {""} ;
         P004O4_n76DocumentoNome = new bool[] {false} ;
         P004O4_A75DocumentoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004O2_A20SubprocessoId, P004O2_n20SubprocessoId, P004O2_A16ProcessoId, P004O2_n16ProcessoId, P004O2_A76DocumentoNome, P004O2_n76DocumentoNome, P004O2_A108DocumentoDataInclusao, P004O2_n108DocumentoDataInclusao, P004O2_A109DocumentoDataAlteracao, P004O2_n109DocumentoDataAlteracao,
               P004O2_A21SubprocessoNome, P004O2_A17ProcessoNome, P004O2_A75DocumentoId
               }
               , new Object[] {
               P004O3_A20SubprocessoId, P004O3_n20SubprocessoId, P004O3_A16ProcessoId, P004O3_n16ProcessoId, P004O3_A17ProcessoNome, P004O3_A108DocumentoDataInclusao, P004O3_n108DocumentoDataInclusao, P004O3_A109DocumentoDataAlteracao, P004O3_n109DocumentoDataAlteracao, P004O3_A21SubprocessoNome,
               P004O3_A76DocumentoNome, P004O3_n76DocumentoNome, P004O3_A75DocumentoId
               }
               , new Object[] {
               P004O4_A20SubprocessoId, P004O4_n20SubprocessoId, P004O4_A16ProcessoId, P004O4_n16ProcessoId, P004O4_A21SubprocessoNome, P004O4_A108DocumentoDataInclusao, P004O4_n108DocumentoDataInclusao, P004O4_A109DocumentoDataAlteracao, P004O4_n109DocumentoDataAlteracao, P004O4_A17ProcessoNome,
               P004O4_A76DocumentoNome, P004O4_n76DocumentoNome, P004O4_A75DocumentoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV57MaxItems ;
      private short AV56PageIndex ;
      private short AV55SkipItems ;
      private int AV125GXV1 ;
      private int AV11TFDocumentoId ;
      private int AV12TFDocumentoId_To ;
      private int A75DocumentoId ;
      private int A20SubprocessoId ;
      private int A16ProcessoId ;
      private long AV70count ;
      private string scmdbuf ;
      private DateTime AV83TFDocumentoDataAlteracao ;
      private DateTime AV84TFDocumentoDataAlteracao_To ;
      private DateTime AV88TFDocumentoDataInclusao ;
      private DateTime AV89TFDocumentoDataInclusao_To ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime A108DocumentoDataInclusao ;
      private bool returnInSub ;
      private bool BRK4O2 ;
      private bool n20SubprocessoId ;
      private bool n16ProcessoId ;
      private bool n76DocumentoNome ;
      private bool n108DocumentoDataInclusao ;
      private bool n109DocumentoDataAlteracao ;
      private bool BRK4O4 ;
      private bool BRK4O6 ;
      private string AV64OptionsJson ;
      private string AV67OptionsDescJson ;
      private string AV69OptionIndexesJson ;
      private string AV60DDOName ;
      private string AV54SearchTxtParms ;
      private string AV59SearchTxtTo ;
      private string AV58SearchTxt ;
      private string AV13TFDocumentoNome ;
      private string AV14TFDocumentoNome_Sel ;
      private string AV79TFProcessoNome ;
      private string AV80TFProcessoNome_Sel ;
      private string AV81TFSubprocessoNome ;
      private string AV82TFSubprocessoNome_Sel ;
      private string lV13TFDocumentoNome ;
      private string lV79TFProcessoNome ;
      private string lV81TFSubprocessoNome ;
      private string A76DocumentoNome ;
      private string A17ProcessoNome ;
      private string A21SubprocessoNome ;
      private string AV62Option ;
      private GxSimpleCollection<int> AV122Documentos ;
      private IGxSession AV71Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004O2_A20SubprocessoId ;
      private bool[] P004O2_n20SubprocessoId ;
      private int[] P004O2_A16ProcessoId ;
      private bool[] P004O2_n16ProcessoId ;
      private string[] P004O2_A76DocumentoNome ;
      private bool[] P004O2_n76DocumentoNome ;
      private DateTime[] P004O2_A108DocumentoDataInclusao ;
      private bool[] P004O2_n108DocumentoDataInclusao ;
      private DateTime[] P004O2_A109DocumentoDataAlteracao ;
      private bool[] P004O2_n109DocumentoDataAlteracao ;
      private string[] P004O2_A21SubprocessoNome ;
      private string[] P004O2_A17ProcessoNome ;
      private int[] P004O2_A75DocumentoId ;
      private int[] P004O3_A20SubprocessoId ;
      private bool[] P004O3_n20SubprocessoId ;
      private int[] P004O3_A16ProcessoId ;
      private bool[] P004O3_n16ProcessoId ;
      private string[] P004O3_A17ProcessoNome ;
      private DateTime[] P004O3_A108DocumentoDataInclusao ;
      private bool[] P004O3_n108DocumentoDataInclusao ;
      private DateTime[] P004O3_A109DocumentoDataAlteracao ;
      private bool[] P004O3_n109DocumentoDataAlteracao ;
      private string[] P004O3_A21SubprocessoNome ;
      private string[] P004O3_A76DocumentoNome ;
      private bool[] P004O3_n76DocumentoNome ;
      private int[] P004O3_A75DocumentoId ;
      private int[] P004O4_A20SubprocessoId ;
      private bool[] P004O4_n20SubprocessoId ;
      private int[] P004O4_A16ProcessoId ;
      private bool[] P004O4_n16ProcessoId ;
      private string[] P004O4_A21SubprocessoNome ;
      private DateTime[] P004O4_A108DocumentoDataInclusao ;
      private bool[] P004O4_n108DocumentoDataInclusao ;
      private DateTime[] P004O4_A109DocumentoDataAlteracao ;
      private bool[] P004O4_n109DocumentoDataAlteracao ;
      private string[] P004O4_A17ProcessoNome ;
      private string[] P004O4_A76DocumentoNome ;
      private bool[] P004O4_n76DocumentoNome ;
      private int[] P004O4_A75DocumentoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV63Options ;
      private GxSimpleCollection<string> AV66OptionsDesc ;
      private GxSimpleCollection<string> AV68OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV73GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV74GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class documentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004O2( IGxContext context ,
                                             int A75DocumentoId ,
                                             GxSimpleCollection<int> AV122Documentos ,
                                             int AV11TFDocumentoId ,
                                             int AV12TFDocumentoId_To ,
                                             string AV14TFDocumentoNome_Sel ,
                                             string AV13TFDocumentoNome ,
                                             string AV80TFProcessoNome_Sel ,
                                             string AV79TFProcessoNome ,
                                             string AV82TFSubprocessoNome_Sel ,
                                             string AV81TFSubprocessoNome ,
                                             DateTime AV83TFDocumentoDataAlteracao ,
                                             DateTime AV84TFDocumentoDataAlteracao_To ,
                                             DateTime AV88TFDocumentoDataInclusao ,
                                             DateTime AV89TFDocumentoDataInclusao_To ,
                                             string A76DocumentoNome ,
                                             string A17ProcessoNome ,
                                             string A21SubprocessoNome ,
                                             DateTime A109DocumentoDataAlteracao ,
                                             DateTime A108DocumentoDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SubprocessoId], T2.[ProcessoId], T1.[DocumentoNome], T1.[DocumentoDataInclusao], T1.[DocumentoDataAlteracao], T2.[SubprocessoNome], T3.[ProcessoNome], T1.[DocumentoId] FROM (([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Documentos, "T1.[DocumentoId] IN (", ")")+")");
         if ( ! (0==AV11TFDocumentoId) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV11TFDocumentoId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV12TFDocumentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV12TFDocumentoId_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDocumentoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFDocumentoNome)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] like @lV13TFDocumentoNome)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDocumentoNome_Sel)) && ! ( StringUtil.StrCmp(AV14TFDocumentoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] = @AV14TFDocumentoNome_Sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFDocumentoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] IS NULL or (T1.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProcessoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProcessoNome)) ) )
         {
            AddWhere(sWhereString, "(T3.[ProcessoNome] like @lV79TFProcessoNome)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProcessoNome_Sel)) && ! ( StringUtil.StrCmp(AV80TFProcessoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProcessoNome] = @AV80TFProcessoNome_Sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV80TFProcessoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProcessoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFSubprocessoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFSubprocessoNome)) ) )
         {
            AddWhere(sWhereString, "(T2.[SubprocessoNome] like @lV81TFSubprocessoNome)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFSubprocessoNome_Sel)) && ! ( StringUtil.StrCmp(AV82TFSubprocessoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SubprocessoNome] = @AV82TFSubprocessoNome_Sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV82TFSubprocessoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[SubprocessoNome] = ''))");
         }
         if ( ! (DateTime.MinValue==AV83TFDocumentoDataAlteracao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] >= @AV83TFDocumentoDataAlteracao)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV84TFDocumentoDataAlteracao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] <= @AV84TFDocumentoDataAlteracao_To)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV88TFDocumentoDataInclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] >= @AV88TFDocumentoDataInclusao)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV89TFDocumentoDataInclusao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] <= @AV89TFDocumentoDataInclusao_To)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentoNome]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004O3( IGxContext context ,
                                             int A75DocumentoId ,
                                             GxSimpleCollection<int> AV122Documentos ,
                                             int AV11TFDocumentoId ,
                                             int AV12TFDocumentoId_To ,
                                             string AV14TFDocumentoNome_Sel ,
                                             string AV13TFDocumentoNome ,
                                             string AV80TFProcessoNome_Sel ,
                                             string AV79TFProcessoNome ,
                                             string AV82TFSubprocessoNome_Sel ,
                                             string AV81TFSubprocessoNome ,
                                             DateTime AV83TFDocumentoDataAlteracao ,
                                             DateTime AV84TFDocumentoDataAlteracao_To ,
                                             DateTime AV88TFDocumentoDataInclusao ,
                                             DateTime AV89TFDocumentoDataInclusao_To ,
                                             string A76DocumentoNome ,
                                             string A17ProcessoNome ,
                                             string A21SubprocessoNome ,
                                             DateTime A109DocumentoDataAlteracao ,
                                             DateTime A108DocumentoDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[SubprocessoId], T2.[ProcessoId], T3.[ProcessoNome], T1.[DocumentoDataInclusao], T1.[DocumentoDataAlteracao], T2.[SubprocessoNome], T1.[DocumentoNome], T1.[DocumentoId] FROM (([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Documentos, "T1.[DocumentoId] IN (", ")")+")");
         if ( ! (0==AV11TFDocumentoId) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV11TFDocumentoId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV12TFDocumentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV12TFDocumentoId_To)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDocumentoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFDocumentoNome)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] like @lV13TFDocumentoNome)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDocumentoNome_Sel)) && ! ( StringUtil.StrCmp(AV14TFDocumentoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] = @AV14TFDocumentoNome_Sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFDocumentoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] IS NULL or (T1.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProcessoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProcessoNome)) ) )
         {
            AddWhere(sWhereString, "(T3.[ProcessoNome] like @lV79TFProcessoNome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProcessoNome_Sel)) && ! ( StringUtil.StrCmp(AV80TFProcessoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProcessoNome] = @AV80TFProcessoNome_Sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV80TFProcessoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProcessoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFSubprocessoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFSubprocessoNome)) ) )
         {
            AddWhere(sWhereString, "(T2.[SubprocessoNome] like @lV81TFSubprocessoNome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFSubprocessoNome_Sel)) && ! ( StringUtil.StrCmp(AV82TFSubprocessoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SubprocessoNome] = @AV82TFSubprocessoNome_Sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV82TFSubprocessoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[SubprocessoNome] = ''))");
         }
         if ( ! (DateTime.MinValue==AV83TFDocumentoDataAlteracao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] >= @AV83TFDocumentoDataAlteracao)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV84TFDocumentoDataAlteracao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] <= @AV84TFDocumentoDataAlteracao_To)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV88TFDocumentoDataInclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] >= @AV88TFDocumentoDataInclusao)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV89TFDocumentoDataInclusao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] <= @AV89TFDocumentoDataInclusao_To)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[ProcessoNome]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004O4( IGxContext context ,
                                             int A75DocumentoId ,
                                             GxSimpleCollection<int> AV122Documentos ,
                                             int AV11TFDocumentoId ,
                                             int AV12TFDocumentoId_To ,
                                             string AV14TFDocumentoNome_Sel ,
                                             string AV13TFDocumentoNome ,
                                             string AV80TFProcessoNome_Sel ,
                                             string AV79TFProcessoNome ,
                                             string AV82TFSubprocessoNome_Sel ,
                                             string AV81TFSubprocessoNome ,
                                             DateTime AV83TFDocumentoDataAlteracao ,
                                             DateTime AV84TFDocumentoDataAlteracao_To ,
                                             DateTime AV88TFDocumentoDataInclusao ,
                                             DateTime AV89TFDocumentoDataInclusao_To ,
                                             string A76DocumentoNome ,
                                             string A17ProcessoNome ,
                                             string A21SubprocessoNome ,
                                             DateTime A109DocumentoDataAlteracao ,
                                             DateTime A108DocumentoDataInclusao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[SubprocessoId], T2.[ProcessoId], T2.[SubprocessoNome], T1.[DocumentoDataInclusao], T1.[DocumentoDataAlteracao], T3.[ProcessoNome], T1.[DocumentoNome], T1.[DocumentoId] FROM (([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Documentos, "T1.[DocumentoId] IN (", ")")+")");
         if ( ! (0==AV11TFDocumentoId) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV11TFDocumentoId)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV12TFDocumentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV12TFDocumentoId_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDocumentoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFDocumentoNome)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] like @lV13TFDocumentoNome)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDocumentoNome_Sel)) && ! ( StringUtil.StrCmp(AV14TFDocumentoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] = @AV14TFDocumentoNome_Sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFDocumentoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocumentoNome] IS NULL or (T1.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProcessoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProcessoNome)) ) )
         {
            AddWhere(sWhereString, "(T3.[ProcessoNome] like @lV79TFProcessoNome)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProcessoNome_Sel)) && ! ( StringUtil.StrCmp(AV80TFProcessoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProcessoNome] = @AV80TFProcessoNome_Sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV80TFProcessoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProcessoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFSubprocessoNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFSubprocessoNome)) ) )
         {
            AddWhere(sWhereString, "(T2.[SubprocessoNome] like @lV81TFSubprocessoNome)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFSubprocessoNome_Sel)) && ! ( StringUtil.StrCmp(AV82TFSubprocessoNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SubprocessoNome] = @AV82TFSubprocessoNome_Sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV82TFSubprocessoNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[SubprocessoNome] = ''))");
         }
         if ( ! (DateTime.MinValue==AV83TFDocumentoDataAlteracao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] >= @AV83TFDocumentoDataAlteracao)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV84TFDocumentoDataAlteracao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataAlteracao] <= @AV84TFDocumentoDataAlteracao_To)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV88TFDocumentoDataInclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] >= @AV88TFDocumentoDataInclusao)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV89TFDocumentoDataInclusao_To) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoDataInclusao] <= @AV89TFDocumentoDataInclusao_To)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[SubprocessoNome]";
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
                     return conditional_P004O2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] );
               case 1 :
                     return conditional_P004O3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] );
               case 2 :
                     return conditional_P004O4(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] );
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
          Object[] prmP004O2;
          prmP004O2 = new Object[] {
          new ParDef("@AV11TFDocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV12TFDocumentoId_To",GXType.Int32,8,0) ,
          new ParDef("@lV13TFDocumentoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV14TFDocumentoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV79TFProcessoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV80TFProcessoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV81TFSubprocessoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV82TFSubprocessoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV83TFDocumentoDataAlteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV84TFDocumentoDataAlteracao_To",GXType.DateTime,8,5) ,
          new ParDef("@AV88TFDocumentoDataInclusao",GXType.DateTime,8,5) ,
          new ParDef("@AV89TFDocumentoDataInclusao_To",GXType.DateTime,8,5)
          };
          Object[] prmP004O3;
          prmP004O3 = new Object[] {
          new ParDef("@AV11TFDocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV12TFDocumentoId_To",GXType.Int32,8,0) ,
          new ParDef("@lV13TFDocumentoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV14TFDocumentoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV79TFProcessoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV80TFProcessoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV81TFSubprocessoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV82TFSubprocessoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV83TFDocumentoDataAlteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV84TFDocumentoDataAlteracao_To",GXType.DateTime,8,5) ,
          new ParDef("@AV88TFDocumentoDataInclusao",GXType.DateTime,8,5) ,
          new ParDef("@AV89TFDocumentoDataInclusao_To",GXType.DateTime,8,5)
          };
          Object[] prmP004O4;
          prmP004O4 = new Object[] {
          new ParDef("@AV11TFDocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV12TFDocumentoId_To",GXType.Int32,8,0) ,
          new ParDef("@lV13TFDocumentoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV14TFDocumentoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV79TFProcessoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV80TFProcessoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV81TFSubprocessoNome",GXType.NVarChar,100,0) ,
          new ParDef("@AV82TFSubprocessoNome_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV83TFDocumentoDataAlteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV84TFDocumentoDataAlteracao_To",GXType.DateTime,8,5) ,
          new ParDef("@AV88TFDocumentoDataInclusao",GXType.DateTime,8,5) ,
          new ParDef("@AV89TFDocumentoDataInclusao_To",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P004O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004O4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((int[]) buf[12])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((int[]) buf[12])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((int[]) buf[12])[0] = rslt.getInt(8);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.documentowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class documentowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "DocumentoWWGetFilterData" )]
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
          permissionPrefix = "documentoww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("documentowwgetfilterdata") )
          {
             return  ;
          }
          documentowwgetfilterdata worker = new documentowwgetfilterdata(context);
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
