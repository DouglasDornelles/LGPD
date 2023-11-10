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
   public class revisaologwwgetfilterdata : GXProcedure
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
            return "revisaologww_Services_Execute" ;
         }

      }

      public revisaologwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaologwwgetfilterdata( IGxContext context )
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
         this.AV27DDOName = aP0_DDOName;
         this.AV21SearchTxtParms = aP1_SearchTxtParms;
         this.AV26SearchTxtTo = aP2_SearchTxtTo;
         this.AV31OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV31OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         revisaologwwgetfilterdata objrevisaologwwgetfilterdata;
         objrevisaologwwgetfilterdata = new revisaologwwgetfilterdata();
         objrevisaologwwgetfilterdata.AV27DDOName = aP0_DDOName;
         objrevisaologwwgetfilterdata.AV21SearchTxtParms = aP1_SearchTxtParms;
         objrevisaologwwgetfilterdata.AV26SearchTxtTo = aP2_SearchTxtTo;
         objrevisaologwwgetfilterdata.AV31OptionsJson = "" ;
         objrevisaologwwgetfilterdata.AV34OptionsDescJson = "" ;
         objrevisaologwwgetfilterdata.AV36OptionIndexesJson = "" ;
         objrevisaologwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objrevisaologwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objrevisaologwwgetfilterdata);
         aP3_OptionsJson=this.AV31OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((revisaologwwgetfilterdata)stateInfo).executePrivate();
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
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms)) ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms)) ? "" : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV27DDOName), "DDO_REVISAOLOGUSUARIOALTERACAO") == 0 )
         {
            /* Execute user subroutine: 'LOADREVISAOLOGUSUARIOALTERACAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV27DDOName), "DDO_REVISAOLOGOBSERVACAO") == 0 )
         {
            /* Execute user subroutine: 'LOADREVISAOLOGOBSERVACAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV31OptionsJson = AV30Options.ToJSonString(false);
         AV34OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV35OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("RevisaoLogWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RevisaoLogWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("RevisaoLogWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGID") == 0 )
            {
               AV11TFRevisaoLogId = (int)(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."));
               AV12TFRevisaoLogId_To = (int)(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO") == 0 )
            {
               AV13TFRevisaoLogUsuarioAlteracao = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO_SEL") == 0 )
            {
               AV14TFRevisaoLogUsuarioAlteracao_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO") == 0 )
            {
               AV15TFRevisaoLogObservacao = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO_SEL") == 0 )
            {
               AV16TFRevisaoLogObservacao_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGDATAALTERACAO") == 0 )
            {
               AV17TFRevisaoLogDataAlteracao = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV18TFRevisaoLogDataAlteracao_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV19TFDocumentoId = (int)(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."));
               AV20TFDocumentoId_To = (int)(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADREVISAOLOGUSUARIOALTERACAOOPTIONS' Routine */
         returnInSub = false;
         AV13TFRevisaoLogUsuarioAlteracao = AV25SearchTxt;
         AV14TFRevisaoLogUsuarioAlteracao_Sel = "";
         AV48Revisaologwwds_1_filterfulltext = AV43FilterFullText;
         AV49Revisaologwwds_2_tfrevisaologid = AV11TFRevisaoLogId;
         AV50Revisaologwwds_3_tfrevisaologid_to = AV12TFRevisaoLogId_To;
         AV51Revisaologwwds_4_tfrevisaologusuarioalteracao = AV13TFRevisaoLogUsuarioAlteracao;
         AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV14TFRevisaoLogUsuarioAlteracao_Sel;
         AV53Revisaologwwds_6_tfrevisaologobservacao = AV15TFRevisaoLogObservacao;
         AV54Revisaologwwds_7_tfrevisaologobservacao_sel = AV16TFRevisaoLogObservacao_Sel;
         AV55Revisaologwwds_8_tfrevisaologdataalteracao = AV17TFRevisaoLogDataAlteracao;
         AV56Revisaologwwds_9_tfrevisaologdataalteracao_to = AV18TFRevisaoLogDataAlteracao_To;
         AV57Revisaologwwds_10_tfdocumentoid = AV19TFDocumentoId;
         AV58Revisaologwwds_11_tfdocumentoid_to = AV20TFDocumentoId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Revisaologwwds_1_filterfulltext ,
                                              AV49Revisaologwwds_2_tfrevisaologid ,
                                              AV50Revisaologwwds_3_tfrevisaologid_to ,
                                              AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                              AV51Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                              AV54Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                              AV53Revisaologwwds_6_tfrevisaologobservacao ,
                                              AV55Revisaologwwds_8_tfrevisaologdataalteracao ,
                                              AV56Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                              AV57Revisaologwwds_10_tfdocumentoid ,
                                              AV58Revisaologwwds_11_tfdocumentoid_to ,
                                              A120RevisaoLogId ,
                                              A121RevisaoLogUsuarioAlteracao ,
                                              A122RevisaoLogObservacao ,
                                              A75DocumentoId ,
                                              A123RevisaoLogDataAlteracao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV51Revisaologwwds_4_tfrevisaologusuarioalteracao = StringUtil.Concat( StringUtil.RTrim( AV51Revisaologwwds_4_tfrevisaologusuarioalteracao), "%", "");
         lV53Revisaologwwds_6_tfrevisaologobservacao = StringUtil.Concat( StringUtil.RTrim( AV53Revisaologwwds_6_tfrevisaologobservacao), "%", "");
         /* Using cursor P00702 */
         pr_default.execute(0, new Object[] {lV48Revisaologwwds_1_filterfulltext, lV48Revisaologwwds_1_filterfulltext, lV48Revisaologwwds_1_filterfulltext, lV48Revisaologwwds_1_filterfulltext, AV49Revisaologwwds_2_tfrevisaologid, AV50Revisaologwwds_3_tfrevisaologid_to, lV51Revisaologwwds_4_tfrevisaologusuarioalteracao, AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, lV53Revisaologwwds_6_tfrevisaologobservacao, AV54Revisaologwwds_7_tfrevisaologobservacao_sel, AV55Revisaologwwds_8_tfrevisaologdataalteracao, AV56Revisaologwwds_9_tfrevisaologdataalteracao_to, AV57Revisaologwwds_10_tfdocumentoid, AV58Revisaologwwds_11_tfdocumentoid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK702 = false;
            A121RevisaoLogUsuarioAlteracao = P00702_A121RevisaoLogUsuarioAlteracao[0];
            A75DocumentoId = P00702_A75DocumentoId[0];
            A123RevisaoLogDataAlteracao = P00702_A123RevisaoLogDataAlteracao[0];
            A120RevisaoLogId = P00702_A120RevisaoLogId[0];
            A122RevisaoLogObservacao = P00702_A122RevisaoLogObservacao[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00702_A121RevisaoLogUsuarioAlteracao[0], A121RevisaoLogUsuarioAlteracao) == 0 ) )
            {
               BRK702 = false;
               A120RevisaoLogId = P00702_A120RevisaoLogId[0];
               AV37count = (long)(AV37count+1);
               BRK702 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A121RevisaoLogUsuarioAlteracao)) ? "<#Empty#>" : A121RevisaoLogUsuarioAlteracao);
               AV30Options.Add(AV29Option, 0);
               AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK702 )
            {
               BRK702 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADREVISAOLOGOBSERVACAOOPTIONS' Routine */
         returnInSub = false;
         AV15TFRevisaoLogObservacao = AV25SearchTxt;
         AV16TFRevisaoLogObservacao_Sel = "";
         AV48Revisaologwwds_1_filterfulltext = AV43FilterFullText;
         AV49Revisaologwwds_2_tfrevisaologid = AV11TFRevisaoLogId;
         AV50Revisaologwwds_3_tfrevisaologid_to = AV12TFRevisaoLogId_To;
         AV51Revisaologwwds_4_tfrevisaologusuarioalteracao = AV13TFRevisaoLogUsuarioAlteracao;
         AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV14TFRevisaoLogUsuarioAlteracao_Sel;
         AV53Revisaologwwds_6_tfrevisaologobservacao = AV15TFRevisaoLogObservacao;
         AV54Revisaologwwds_7_tfrevisaologobservacao_sel = AV16TFRevisaoLogObservacao_Sel;
         AV55Revisaologwwds_8_tfrevisaologdataalteracao = AV17TFRevisaoLogDataAlteracao;
         AV56Revisaologwwds_9_tfrevisaologdataalteracao_to = AV18TFRevisaoLogDataAlteracao_To;
         AV57Revisaologwwds_10_tfdocumentoid = AV19TFDocumentoId;
         AV58Revisaologwwds_11_tfdocumentoid_to = AV20TFDocumentoId_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Revisaologwwds_1_filterfulltext ,
                                              AV49Revisaologwwds_2_tfrevisaologid ,
                                              AV50Revisaologwwds_3_tfrevisaologid_to ,
                                              AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                              AV51Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                              AV54Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                              AV53Revisaologwwds_6_tfrevisaologobservacao ,
                                              AV55Revisaologwwds_8_tfrevisaologdataalteracao ,
                                              AV56Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                              AV57Revisaologwwds_10_tfdocumentoid ,
                                              AV58Revisaologwwds_11_tfdocumentoid_to ,
                                              A120RevisaoLogId ,
                                              A121RevisaoLogUsuarioAlteracao ,
                                              A122RevisaoLogObservacao ,
                                              A75DocumentoId ,
                                              A123RevisaoLogDataAlteracao } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV48Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext), "%", "");
         lV51Revisaologwwds_4_tfrevisaologusuarioalteracao = StringUtil.Concat( StringUtil.RTrim( AV51Revisaologwwds_4_tfrevisaologusuarioalteracao), "%", "");
         lV53Revisaologwwds_6_tfrevisaologobservacao = StringUtil.Concat( StringUtil.RTrim( AV53Revisaologwwds_6_tfrevisaologobservacao), "%", "");
         /* Using cursor P00703 */
         pr_default.execute(1, new Object[] {lV48Revisaologwwds_1_filterfulltext, lV48Revisaologwwds_1_filterfulltext, lV48Revisaologwwds_1_filterfulltext, lV48Revisaologwwds_1_filterfulltext, AV49Revisaologwwds_2_tfrevisaologid, AV50Revisaologwwds_3_tfrevisaologid_to, lV51Revisaologwwds_4_tfrevisaologusuarioalteracao, AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, lV53Revisaologwwds_6_tfrevisaologobservacao, AV54Revisaologwwds_7_tfrevisaologobservacao_sel, AV55Revisaologwwds_8_tfrevisaologdataalteracao, AV56Revisaologwwds_9_tfrevisaologdataalteracao_to, AV57Revisaologwwds_10_tfdocumentoid, AV58Revisaologwwds_11_tfdocumentoid_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK704 = false;
            A122RevisaoLogObservacao = P00703_A122RevisaoLogObservacao[0];
            A75DocumentoId = P00703_A75DocumentoId[0];
            A123RevisaoLogDataAlteracao = P00703_A123RevisaoLogDataAlteracao[0];
            A120RevisaoLogId = P00703_A120RevisaoLogId[0];
            A121RevisaoLogUsuarioAlteracao = P00703_A121RevisaoLogUsuarioAlteracao[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00703_A122RevisaoLogObservacao[0], A122RevisaoLogObservacao) == 0 ) )
            {
               BRK704 = false;
               A120RevisaoLogId = P00703_A120RevisaoLogId[0];
               AV37count = (long)(AV37count+1);
               BRK704 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV22SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RevisaoLogObservacao)) ? "<#Empty#>" : A122RevisaoLogObservacao);
               AV30Options.Add(AV29Option, 0);
               AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK704 )
            {
               BRK704 = true;
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
         AV31OptionsJson = "";
         AV34OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV35OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV13TFRevisaoLogUsuarioAlteracao = "";
         AV14TFRevisaoLogUsuarioAlteracao_Sel = "";
         AV15TFRevisaoLogObservacao = "";
         AV16TFRevisaoLogObservacao_Sel = "";
         AV17TFRevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         AV18TFRevisaoLogDataAlteracao_To = (DateTime)(DateTime.MinValue);
         AV48Revisaologwwds_1_filterfulltext = "";
         AV51Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = "";
         AV53Revisaologwwds_6_tfrevisaologobservacao = "";
         AV54Revisaologwwds_7_tfrevisaologobservacao_sel = "";
         AV55Revisaologwwds_8_tfrevisaologdataalteracao = (DateTime)(DateTime.MinValue);
         AV56Revisaologwwds_9_tfrevisaologdataalteracao_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV48Revisaologwwds_1_filterfulltext = "";
         lV51Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         lV53Revisaologwwds_6_tfrevisaologobservacao = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A122RevisaoLogObservacao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         P00702_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         P00702_A75DocumentoId = new int[1] ;
         P00702_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P00702_A120RevisaoLogId = new int[1] ;
         P00702_A122RevisaoLogObservacao = new string[] {""} ;
         AV29Option = "";
         P00703_A122RevisaoLogObservacao = new string[] {""} ;
         P00703_A75DocumentoId = new int[1] ;
         P00703_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P00703_A120RevisaoLogId = new int[1] ;
         P00703_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaologwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00702_A121RevisaoLogUsuarioAlteracao, P00702_A75DocumentoId, P00702_A123RevisaoLogDataAlteracao, P00702_A120RevisaoLogId, P00702_A122RevisaoLogObservacao
               }
               , new Object[] {
               P00703_A122RevisaoLogObservacao, P00703_A75DocumentoId, P00703_A123RevisaoLogDataAlteracao, P00703_A120RevisaoLogId, P00703_A121RevisaoLogUsuarioAlteracao
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV46GXV1 ;
      private int AV11TFRevisaoLogId ;
      private int AV12TFRevisaoLogId_To ;
      private int AV19TFDocumentoId ;
      private int AV20TFDocumentoId_To ;
      private int AV49Revisaologwwds_2_tfrevisaologid ;
      private int AV50Revisaologwwds_3_tfrevisaologid_to ;
      private int AV57Revisaologwwds_10_tfdocumentoid ;
      private int AV58Revisaologwwds_11_tfdocumentoid_to ;
      private int A120RevisaoLogId ;
      private int A75DocumentoId ;
      private long AV37count ;
      private string scmdbuf ;
      private DateTime AV17TFRevisaoLogDataAlteracao ;
      private DateTime AV18TFRevisaoLogDataAlteracao_To ;
      private DateTime AV55Revisaologwwds_8_tfrevisaologdataalteracao ;
      private DateTime AV56Revisaologwwds_9_tfrevisaologdataalteracao_to ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private bool returnInSub ;
      private bool BRK702 ;
      private bool BRK704 ;
      private string AV31OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string A122RevisaoLogObservacao ;
      private string AV27DDOName ;
      private string AV21SearchTxtParms ;
      private string AV26SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV43FilterFullText ;
      private string AV13TFRevisaoLogUsuarioAlteracao ;
      private string AV14TFRevisaoLogUsuarioAlteracao_Sel ;
      private string AV15TFRevisaoLogObservacao ;
      private string AV16TFRevisaoLogObservacao_Sel ;
      private string AV48Revisaologwwds_1_filterfulltext ;
      private string AV51Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ;
      private string AV53Revisaologwwds_6_tfrevisaologobservacao ;
      private string AV54Revisaologwwds_7_tfrevisaologobservacao_sel ;
      private string lV48Revisaologwwds_1_filterfulltext ;
      private string lV51Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string lV53Revisaologwwds_6_tfrevisaologobservacao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string AV29Option ;
      private IGxSession AV38Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00702_A121RevisaoLogUsuarioAlteracao ;
      private int[] P00702_A75DocumentoId ;
      private DateTime[] P00702_A123RevisaoLogDataAlteracao ;
      private int[] P00702_A120RevisaoLogId ;
      private string[] P00702_A122RevisaoLogObservacao ;
      private string[] P00703_A122RevisaoLogObservacao ;
      private int[] P00703_A75DocumentoId ;
      private DateTime[] P00703_A123RevisaoLogDataAlteracao ;
      private int[] P00703_A120RevisaoLogId ;
      private string[] P00703_A121RevisaoLogUsuarioAlteracao ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV35OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class revisaologwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00702( IGxContext context ,
                                             string AV48Revisaologwwds_1_filterfulltext ,
                                             int AV49Revisaologwwds_2_tfrevisaologid ,
                                             int AV50Revisaologwwds_3_tfrevisaologid_to ,
                                             string AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                             string AV51Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                             string AV54Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                             string AV53Revisaologwwds_6_tfrevisaologobservacao ,
                                             DateTime AV55Revisaologwwds_8_tfrevisaologdataalteracao ,
                                             DateTime AV56Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                             int AV57Revisaologwwds_10_tfdocumentoid ,
                                             int AV58Revisaologwwds_11_tfdocumentoid_to ,
                                             int A120RevisaoLogId ,
                                             string A121RevisaoLogUsuarioAlteracao ,
                                             string A122RevisaoLogObservacao ,
                                             int A75DocumentoId ,
                                             DateTime A123RevisaoLogDataAlteracao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [RevisaoLogUsuarioAlteracao], [DocumentoId], [RevisaoLogDataAlteracao], [RevisaoLogId], [RevisaoLogObservacao] FROM [RevisaoLog]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([RevisaoLogId] AS decimal(8,0))) like '%' + @lV48Revisaologwwds_1_filterfulltext) or ( [RevisaoLogUsuarioAlteracao] like '%' + @lV48Revisaologwwds_1_filterfulltext) or ( [RevisaoLogObservacao] like '%' + @lV48Revisaologwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV48Revisaologwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV49Revisaologwwds_2_tfrevisaologid) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] >= @AV49Revisaologwwds_2_tfrevisaologid)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV50Revisaologwwds_3_tfrevisaologid_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] <= @AV50Revisaologwwds_3_tfrevisaologid_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Revisaologwwds_4_tfrevisaologusuarioalteracao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] like @lV51Revisaologwwds_4_tfrevisaologusuarioalteracao)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ! ( StringUtil.StrCmp(AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] = @AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RevisaoLogUsuarioAlteracao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_7_tfrevisaologobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Revisaologwwds_6_tfrevisaologobservacao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] like @lV53Revisaologwwds_6_tfrevisaologobservacao)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_7_tfrevisaologobservacao_sel)) && ! ( StringUtil.StrCmp(AV54Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] = @AV54Revisaologwwds_7_tfrevisaologobservacao_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH([RevisaoLogObservacao])=0))");
         }
         if ( ! (DateTime.MinValue==AV55Revisaologwwds_8_tfrevisaologdataalteracao) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] >= @AV55Revisaologwwds_8_tfrevisaologdataalteracao)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Revisaologwwds_9_tfrevisaologdataalteracao_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] <= @AV56Revisaologwwds_9_tfrevisaologdataalteracao_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV57Revisaologwwds_10_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV57Revisaologwwds_10_tfdocumentoid)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV58Revisaologwwds_11_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV58Revisaologwwds_11_tfdocumentoid_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RevisaoLogUsuarioAlteracao]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00703( IGxContext context ,
                                             string AV48Revisaologwwds_1_filterfulltext ,
                                             int AV49Revisaologwwds_2_tfrevisaologid ,
                                             int AV50Revisaologwwds_3_tfrevisaologid_to ,
                                             string AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                             string AV51Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                             string AV54Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                             string AV53Revisaologwwds_6_tfrevisaologobservacao ,
                                             DateTime AV55Revisaologwwds_8_tfrevisaologdataalteracao ,
                                             DateTime AV56Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                             int AV57Revisaologwwds_10_tfdocumentoid ,
                                             int AV58Revisaologwwds_11_tfdocumentoid_to ,
                                             int A120RevisaoLogId ,
                                             string A121RevisaoLogUsuarioAlteracao ,
                                             string A122RevisaoLogObservacao ,
                                             int A75DocumentoId ,
                                             DateTime A123RevisaoLogDataAlteracao )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [RevisaoLogObservacao], [DocumentoId], [RevisaoLogDataAlteracao], [RevisaoLogId], [RevisaoLogUsuarioAlteracao] FROM [RevisaoLog]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Revisaologwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([RevisaoLogId] AS decimal(8,0))) like '%' + @lV48Revisaologwwds_1_filterfulltext) or ( [RevisaoLogUsuarioAlteracao] like '%' + @lV48Revisaologwwds_1_filterfulltext) or ( [RevisaoLogObservacao] like '%' + @lV48Revisaologwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV48Revisaologwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV49Revisaologwwds_2_tfrevisaologid) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] >= @AV49Revisaologwwds_2_tfrevisaologid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV50Revisaologwwds_3_tfrevisaologid_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] <= @AV50Revisaologwwds_3_tfrevisaologid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Revisaologwwds_4_tfrevisaologusuarioalteracao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] like @lV51Revisaologwwds_4_tfrevisaologusuarioalteracao)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ! ( StringUtil.StrCmp(AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] = @AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RevisaoLogUsuarioAlteracao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_7_tfrevisaologobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Revisaologwwds_6_tfrevisaologobservacao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] like @lV53Revisaologwwds_6_tfrevisaologobservacao)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_7_tfrevisaologobservacao_sel)) && ! ( StringUtil.StrCmp(AV54Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] = @AV54Revisaologwwds_7_tfrevisaologobservacao_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH([RevisaoLogObservacao])=0))");
         }
         if ( ! (DateTime.MinValue==AV55Revisaologwwds_8_tfrevisaologdataalteracao) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] >= @AV55Revisaologwwds_8_tfrevisaologdataalteracao)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Revisaologwwds_9_tfrevisaologdataalteracao_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] <= @AV56Revisaologwwds_9_tfrevisaologdataalteracao_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV57Revisaologwwds_10_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV57Revisaologwwds_10_tfdocumentoid)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV58Revisaologwwds_11_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV58Revisaologwwds_11_tfdocumentoid_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RevisaoLogObservacao]";
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
                     return conditional_P00702(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] );
               case 1 :
                     return conditional_P00703(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] );
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
          Object[] prmP00702;
          prmP00702 = new Object[] {
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV49Revisaologwwds_2_tfrevisaologid",GXType.Int32,8,0) ,
          new ParDef("@AV50Revisaologwwds_3_tfrevisaologid_to",GXType.Int32,8,0) ,
          new ParDef("@lV51Revisaologwwds_4_tfrevisaologusuarioalteracao",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Revisaologwwds_6_tfrevisaologobservacao",GXType.NVarChar,200,0) ,
          new ParDef("@AV54Revisaologwwds_7_tfrevisaologobservacao_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV55Revisaologwwds_8_tfrevisaologdataalteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV56Revisaologwwds_9_tfrevisaologdataalteracao_to",GXType.DateTime,8,5) ,
          new ParDef("@AV57Revisaologwwds_10_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV58Revisaologwwds_11_tfdocumentoid_to",GXType.Int32,8,0)
          };
          Object[] prmP00703;
          prmP00703 = new Object[] {
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV48Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV49Revisaologwwds_2_tfrevisaologid",GXType.Int32,8,0) ,
          new ParDef("@AV50Revisaologwwds_3_tfrevisaologid_to",GXType.Int32,8,0) ,
          new ParDef("@lV51Revisaologwwds_4_tfrevisaologusuarioalteracao",GXType.NVarChar,100,0) ,
          new ParDef("@AV52Revisaologwwds_5_tfrevisaologusuarioalteracao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Revisaologwwds_6_tfrevisaologobservacao",GXType.NVarChar,200,0) ,
          new ParDef("@AV54Revisaologwwds_7_tfrevisaologobservacao_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV55Revisaologwwds_8_tfrevisaologdataalteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV56Revisaologwwds_9_tfrevisaologdataalteracao_to",GXType.DateTime,8,5) ,
          new ParDef("@AV57Revisaologwwds_10_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV58Revisaologwwds_11_tfdocumentoid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00702", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00702,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00703", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00703,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.revisaologwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class revisaologwwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "RevisaoLogWWGetFilterData" )]
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
          permissionPrefix = "revisaologww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("revisaologwwgetfilterdata") )
          {
             return  ;
          }
          revisaologwwgetfilterdata worker = new revisaologwwgetfilterdata(context);
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
