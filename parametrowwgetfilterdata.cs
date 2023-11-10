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
   public class parametrowwgetfilterdata : GXProcedure
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
            return "parametroww_Services_Execute" ;
         }

      }

      public parametrowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public parametrowwgetfilterdata( IGxContext context )
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
         parametrowwgetfilterdata objparametrowwgetfilterdata;
         objparametrowwgetfilterdata = new parametrowwgetfilterdata();
         objparametrowwgetfilterdata.AV34DDOName = aP0_DDOName;
         objparametrowwgetfilterdata.AV28SearchTxtParms = aP1_SearchTxtParms;
         objparametrowwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objparametrowwgetfilterdata.AV38OptionsJson = "" ;
         objparametrowwgetfilterdata.AV41OptionsDescJson = "" ;
         objparametrowwgetfilterdata.AV43OptionIndexesJson = "" ;
         objparametrowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objparametrowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objparametrowwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parametrowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PARAMETROCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETROCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PARAMETRODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETRODESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PARAMETROVALOR") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETROVALOROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PARAMETROCOMENTARIO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETROCOMENTARIOOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV45Session.Get("ParametroWWGridState"), "") == 0 )
         {
            AV47GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametroWWGridState"), null, "", "");
         }
         else
         {
            AV47GridState.FromXml(AV45Session.Get("ParametroWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV47GridState.gxTpr_Filtervalues.Count )
         {
            AV48GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV47GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD") == 0 )
            {
               AV11TFParametroCod = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD_SEL") == 0 )
            {
               AV12TFParametroCod_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV13TFParametroDescricao = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV14TFParametroDescricao_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV15TFParametroValor = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV16TFParametroValor_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO") == 0 )
            {
               AV17TFParametroComentario = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO_SEL") == 0 )
            {
               AV18TFParametroComentario_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPARAMETROCODOPTIONS' Routine */
         returnInSub = false;
         AV11TFParametroCod = AV32SearchTxt;
         AV12TFParametroCod_Sel = "";
         AV55Parametrowwds_1_filterfulltext = AV50FilterFullText;
         AV56Parametrowwds_2_tfparametrocod = AV11TFParametroCod;
         AV57Parametrowwds_3_tfparametrocod_sel = AV12TFParametroCod_Sel;
         AV58Parametrowwds_4_tfparametrodescricao = AV13TFParametroDescricao;
         AV59Parametrowwds_5_tfparametrodescricao_sel = AV14TFParametroDescricao_Sel;
         AV60Parametrowwds_6_tfparametrovalor = AV15TFParametroValor;
         AV61Parametrowwds_7_tfparametrovalor_sel = AV16TFParametroValor_Sel;
         AV62Parametrowwds_8_tfparametrocomentario = AV17TFParametroComentario;
         AV63Parametrowwds_9_tfparametrocomentario_sel = AV18TFParametroComentario_Sel;
         GXPagingFrom2 = AV29SkipItems;
         GXPagingTo2 = AV31MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Parametrowwds_1_filterfulltext ,
                                              AV57Parametrowwds_3_tfparametrocod_sel ,
                                              AV56Parametrowwds_2_tfparametrocod ,
                                              AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV58Parametrowwds_4_tfparametrodescricao ,
                                              AV61Parametrowwds_7_tfparametrovalor_sel ,
                                              AV60Parametrowwds_6_tfparametrovalor ,
                                              AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV62Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario } ,
                                              new int[]{
                                              }
         });
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV56Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod), 10, "%");
         lV58Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao), "%", "");
         lV60Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor), "%", "");
         lV62Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor P006G2 */
         pr_default.execute(0, new Object[] {lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV56Parametrowwds_2_tfparametrocod, AV57Parametrowwds_3_tfparametrocod_sel, lV58Parametrowwds_4_tfparametrodescricao, AV59Parametrowwds_5_tfparametrodescricao_sel, lV60Parametrowwds_6_tfparametrovalor, AV61Parametrowwds_7_tfparametrovalor_sel, lV62Parametrowwds_8_tfparametrocomentario, AV63Parametrowwds_9_tfparametrocomentario_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127ParametroComentario = P006G2_A127ParametroComentario[0];
            A126ParametroValor = P006G2_A126ParametroValor[0];
            A125ParametroDescricao = P006G2_A125ParametroDescricao[0];
            A124ParametroCod = P006G2_A124ParametroCod[0];
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A124ParametroCod)) ? "<#Empty#>" : A124ParametroCod);
            AV37Options.Add(AV36Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARAMETRODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV13TFParametroDescricao = AV32SearchTxt;
         AV14TFParametroDescricao_Sel = "";
         AV55Parametrowwds_1_filterfulltext = AV50FilterFullText;
         AV56Parametrowwds_2_tfparametrocod = AV11TFParametroCod;
         AV57Parametrowwds_3_tfparametrocod_sel = AV12TFParametroCod_Sel;
         AV58Parametrowwds_4_tfparametrodescricao = AV13TFParametroDescricao;
         AV59Parametrowwds_5_tfparametrodescricao_sel = AV14TFParametroDescricao_Sel;
         AV60Parametrowwds_6_tfparametrovalor = AV15TFParametroValor;
         AV61Parametrowwds_7_tfparametrovalor_sel = AV16TFParametroValor_Sel;
         AV62Parametrowwds_8_tfparametrocomentario = AV17TFParametroComentario;
         AV63Parametrowwds_9_tfparametrocomentario_sel = AV18TFParametroComentario_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV55Parametrowwds_1_filterfulltext ,
                                              AV57Parametrowwds_3_tfparametrocod_sel ,
                                              AV56Parametrowwds_2_tfparametrocod ,
                                              AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV58Parametrowwds_4_tfparametrodescricao ,
                                              AV61Parametrowwds_7_tfparametrovalor_sel ,
                                              AV60Parametrowwds_6_tfparametrovalor ,
                                              AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV62Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario } ,
                                              new int[]{
                                              }
         });
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV56Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod), 10, "%");
         lV58Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao), "%", "");
         lV60Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor), "%", "");
         lV62Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor P006G3 */
         pr_default.execute(1, new Object[] {lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV56Parametrowwds_2_tfparametrocod, AV57Parametrowwds_3_tfparametrocod_sel, lV58Parametrowwds_4_tfparametrodescricao, AV59Parametrowwds_5_tfparametrodescricao_sel, lV60Parametrowwds_6_tfparametrovalor, AV61Parametrowwds_7_tfparametrovalor_sel, lV62Parametrowwds_8_tfparametrocomentario, AV63Parametrowwds_9_tfparametrocomentario_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6G3 = false;
            A125ParametroDescricao = P006G3_A125ParametroDescricao[0];
            A127ParametroComentario = P006G3_A127ParametroComentario[0];
            A126ParametroValor = P006G3_A126ParametroValor[0];
            A124ParametroCod = P006G3_A124ParametroCod[0];
            AV44count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006G3_A125ParametroDescricao[0], A125ParametroDescricao) == 0 ) )
            {
               BRK6G3 = false;
               A124ParametroCod = P006G3_A124ParametroCod[0];
               AV44count = (long)(AV44count+1);
               BRK6G3 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV29SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125ParametroDescricao)) ? "<#Empty#>" : A125ParametroDescricao);
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
            if ( ! BRK6G3 )
            {
               BRK6G3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPARAMETROVALOROPTIONS' Routine */
         returnInSub = false;
         AV15TFParametroValor = AV32SearchTxt;
         AV16TFParametroValor_Sel = "";
         AV55Parametrowwds_1_filterfulltext = AV50FilterFullText;
         AV56Parametrowwds_2_tfparametrocod = AV11TFParametroCod;
         AV57Parametrowwds_3_tfparametrocod_sel = AV12TFParametroCod_Sel;
         AV58Parametrowwds_4_tfparametrodescricao = AV13TFParametroDescricao;
         AV59Parametrowwds_5_tfparametrodescricao_sel = AV14TFParametroDescricao_Sel;
         AV60Parametrowwds_6_tfparametrovalor = AV15TFParametroValor;
         AV61Parametrowwds_7_tfparametrovalor_sel = AV16TFParametroValor_Sel;
         AV62Parametrowwds_8_tfparametrocomentario = AV17TFParametroComentario;
         AV63Parametrowwds_9_tfparametrocomentario_sel = AV18TFParametroComentario_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV55Parametrowwds_1_filterfulltext ,
                                              AV57Parametrowwds_3_tfparametrocod_sel ,
                                              AV56Parametrowwds_2_tfparametrocod ,
                                              AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV58Parametrowwds_4_tfparametrodescricao ,
                                              AV61Parametrowwds_7_tfparametrovalor_sel ,
                                              AV60Parametrowwds_6_tfparametrovalor ,
                                              AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV62Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario } ,
                                              new int[]{
                                              }
         });
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV56Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod), 10, "%");
         lV58Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao), "%", "");
         lV60Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor), "%", "");
         lV62Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor P006G4 */
         pr_default.execute(2, new Object[] {lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV56Parametrowwds_2_tfparametrocod, AV57Parametrowwds_3_tfparametrocod_sel, lV58Parametrowwds_4_tfparametrodescricao, AV59Parametrowwds_5_tfparametrodescricao_sel, lV60Parametrowwds_6_tfparametrovalor, AV61Parametrowwds_7_tfparametrovalor_sel, lV62Parametrowwds_8_tfparametrocomentario, AV63Parametrowwds_9_tfparametrocomentario_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6G5 = false;
            A126ParametroValor = P006G4_A126ParametroValor[0];
            A127ParametroComentario = P006G4_A127ParametroComentario[0];
            A125ParametroDescricao = P006G4_A125ParametroDescricao[0];
            A124ParametroCod = P006G4_A124ParametroCod[0];
            AV44count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006G4_A126ParametroValor[0], A126ParametroValor) == 0 ) )
            {
               BRK6G5 = false;
               A124ParametroCod = P006G4_A124ParametroCod[0];
               AV44count = (long)(AV44count+1);
               BRK6G5 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV29SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A126ParametroValor)) ? "<#Empty#>" : A126ParametroValor);
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
            if ( ! BRK6G5 )
            {
               BRK6G5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPARAMETROCOMENTARIOOPTIONS' Routine */
         returnInSub = false;
         AV17TFParametroComentario = AV32SearchTxt;
         AV18TFParametroComentario_Sel = "";
         AV55Parametrowwds_1_filterfulltext = AV50FilterFullText;
         AV56Parametrowwds_2_tfparametrocod = AV11TFParametroCod;
         AV57Parametrowwds_3_tfparametrocod_sel = AV12TFParametroCod_Sel;
         AV58Parametrowwds_4_tfparametrodescricao = AV13TFParametroDescricao;
         AV59Parametrowwds_5_tfparametrodescricao_sel = AV14TFParametroDescricao_Sel;
         AV60Parametrowwds_6_tfparametrovalor = AV15TFParametroValor;
         AV61Parametrowwds_7_tfparametrovalor_sel = AV16TFParametroValor_Sel;
         AV62Parametrowwds_8_tfparametrocomentario = AV17TFParametroComentario;
         AV63Parametrowwds_9_tfparametrocomentario_sel = AV18TFParametroComentario_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV55Parametrowwds_1_filterfulltext ,
                                              AV57Parametrowwds_3_tfparametrocod_sel ,
                                              AV56Parametrowwds_2_tfparametrocod ,
                                              AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV58Parametrowwds_4_tfparametrodescricao ,
                                              AV61Parametrowwds_7_tfparametrovalor_sel ,
                                              AV60Parametrowwds_6_tfparametrovalor ,
                                              AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV62Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario } ,
                                              new int[]{
                                              }
         });
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV55Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext), "%", "");
         lV56Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod), 10, "%");
         lV58Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao), "%", "");
         lV60Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor), "%", "");
         lV62Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor P006G5 */
         pr_default.execute(3, new Object[] {lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV55Parametrowwds_1_filterfulltext, lV56Parametrowwds_2_tfparametrocod, AV57Parametrowwds_3_tfparametrocod_sel, lV58Parametrowwds_4_tfparametrodescricao, AV59Parametrowwds_5_tfparametrodescricao_sel, lV60Parametrowwds_6_tfparametrovalor, AV61Parametrowwds_7_tfparametrovalor_sel, lV62Parametrowwds_8_tfparametrocomentario, AV63Parametrowwds_9_tfparametrocomentario_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6G7 = false;
            A127ParametroComentario = P006G5_A127ParametroComentario[0];
            A126ParametroValor = P006G5_A126ParametroValor[0];
            A125ParametroDescricao = P006G5_A125ParametroDescricao[0];
            A124ParametroCod = P006G5_A124ParametroCod[0];
            AV44count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006G5_A127ParametroComentario[0], A127ParametroComentario) == 0 ) )
            {
               BRK6G7 = false;
               A124ParametroCod = P006G5_A124ParametroCod[0];
               AV44count = (long)(AV44count+1);
               BRK6G7 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV29SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A127ParametroComentario)) ? "<#Empty#>" : A127ParametroComentario);
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
            if ( ! BRK6G7 )
            {
               BRK6G7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV11TFParametroCod = "";
         AV12TFParametroCod_Sel = "";
         AV13TFParametroDescricao = "";
         AV14TFParametroDescricao_Sel = "";
         AV15TFParametroValor = "";
         AV16TFParametroValor_Sel = "";
         AV17TFParametroComentario = "";
         AV18TFParametroComentario_Sel = "";
         AV55Parametrowwds_1_filterfulltext = "";
         AV56Parametrowwds_2_tfparametrocod = "";
         AV57Parametrowwds_3_tfparametrocod_sel = "";
         AV58Parametrowwds_4_tfparametrodescricao = "";
         AV59Parametrowwds_5_tfparametrodescricao_sel = "";
         AV60Parametrowwds_6_tfparametrovalor = "";
         AV61Parametrowwds_7_tfparametrovalor_sel = "";
         AV62Parametrowwds_8_tfparametrocomentario = "";
         AV63Parametrowwds_9_tfparametrocomentario_sel = "";
         scmdbuf = "";
         lV55Parametrowwds_1_filterfulltext = "";
         lV56Parametrowwds_2_tfparametrocod = "";
         lV58Parametrowwds_4_tfparametrodescricao = "";
         lV60Parametrowwds_6_tfparametrovalor = "";
         lV62Parametrowwds_8_tfparametrocomentario = "";
         A124ParametroCod = "";
         A125ParametroDescricao = "";
         A126ParametroValor = "";
         A127ParametroComentario = "";
         P006G2_A127ParametroComentario = new string[] {""} ;
         P006G2_A126ParametroValor = new string[] {""} ;
         P006G2_A125ParametroDescricao = new string[] {""} ;
         P006G2_A124ParametroCod = new string[] {""} ;
         AV36Option = "";
         P006G3_A125ParametroDescricao = new string[] {""} ;
         P006G3_A127ParametroComentario = new string[] {""} ;
         P006G3_A126ParametroValor = new string[] {""} ;
         P006G3_A124ParametroCod = new string[] {""} ;
         P006G4_A126ParametroValor = new string[] {""} ;
         P006G4_A127ParametroComentario = new string[] {""} ;
         P006G4_A125ParametroDescricao = new string[] {""} ;
         P006G4_A124ParametroCod = new string[] {""} ;
         P006G5_A127ParametroComentario = new string[] {""} ;
         P006G5_A126ParametroValor = new string[] {""} ;
         P006G5_A125ParametroDescricao = new string[] {""} ;
         P006G5_A124ParametroCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametrowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006G2_A127ParametroComentario, P006G2_A126ParametroValor, P006G2_A125ParametroDescricao, P006G2_A124ParametroCod
               }
               , new Object[] {
               P006G3_A125ParametroDescricao, P006G3_A127ParametroComentario, P006G3_A126ParametroValor, P006G3_A124ParametroCod
               }
               , new Object[] {
               P006G4_A126ParametroValor, P006G4_A127ParametroComentario, P006G4_A125ParametroDescricao, P006G4_A124ParametroCod
               }
               , new Object[] {
               P006G5_A127ParametroComentario, P006G5_A126ParametroValor, P006G5_A125ParametroDescricao, P006G5_A124ParametroCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private int AV53GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV44count ;
      private string AV11TFParametroCod ;
      private string AV12TFParametroCod_Sel ;
      private string AV56Parametrowwds_2_tfparametrocod ;
      private string AV57Parametrowwds_3_tfparametrocod_sel ;
      private string scmdbuf ;
      private string lV56Parametrowwds_2_tfparametrocod ;
      private string A124ParametroCod ;
      private bool returnInSub ;
      private bool BRK6G3 ;
      private bool BRK6G5 ;
      private bool BRK6G7 ;
      private string AV38OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV28SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV32SearchTxt ;
      private string AV50FilterFullText ;
      private string AV13TFParametroDescricao ;
      private string AV14TFParametroDescricao_Sel ;
      private string AV15TFParametroValor ;
      private string AV16TFParametroValor_Sel ;
      private string AV17TFParametroComentario ;
      private string AV18TFParametroComentario_Sel ;
      private string AV55Parametrowwds_1_filterfulltext ;
      private string AV58Parametrowwds_4_tfparametrodescricao ;
      private string AV59Parametrowwds_5_tfparametrodescricao_sel ;
      private string AV60Parametrowwds_6_tfparametrovalor ;
      private string AV61Parametrowwds_7_tfparametrovalor_sel ;
      private string AV62Parametrowwds_8_tfparametrocomentario ;
      private string AV63Parametrowwds_9_tfparametrocomentario_sel ;
      private string lV55Parametrowwds_1_filterfulltext ;
      private string lV58Parametrowwds_4_tfparametrodescricao ;
      private string lV60Parametrowwds_6_tfparametrovalor ;
      private string lV62Parametrowwds_8_tfparametrocomentario ;
      private string A125ParametroDescricao ;
      private string A126ParametroValor ;
      private string A127ParametroComentario ;
      private string AV36Option ;
      private IGxSession AV45Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006G2_A127ParametroComentario ;
      private string[] P006G2_A126ParametroValor ;
      private string[] P006G2_A125ParametroDescricao ;
      private string[] P006G2_A124ParametroCod ;
      private string[] P006G3_A125ParametroDescricao ;
      private string[] P006G3_A127ParametroComentario ;
      private string[] P006G3_A126ParametroValor ;
      private string[] P006G3_A124ParametroCod ;
      private string[] P006G4_A126ParametroValor ;
      private string[] P006G4_A127ParametroComentario ;
      private string[] P006G4_A125ParametroDescricao ;
      private string[] P006G4_A124ParametroCod ;
      private string[] P006G5_A127ParametroComentario ;
      private string[] P006G5_A126ParametroValor ;
      private string[] P006G5_A125ParametroDescricao ;
      private string[] P006G5_A124ParametroCod ;
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

   public class parametrowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006G2( IGxContext context ,
                                             string AV55Parametrowwds_1_filterfulltext ,
                                             string AV57Parametrowwds_3_tfparametrocod_sel ,
                                             string AV56Parametrowwds_2_tfparametrocod ,
                                             string AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                             string AV58Parametrowwds_4_tfparametrodescricao ,
                                             string AV61Parametrowwds_7_tfparametrovalor_sel ,
                                             string AV60Parametrowwds_6_tfparametrovalor ,
                                             string AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                             string AV62Parametrowwds_8_tfparametrocomentario ,
                                             string A124ParametroCod ,
                                             string A125ParametroDescricao ,
                                             string A126ParametroValor ,
                                             string A127ParametroComentario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS [ParametroComentario], NULL AS [ParametroValor], NULL AS [ParametroDescricao], [ParametroCod] FROM ( SELECT TOP(100) PERCENT [ParametroComentario], [ParametroValor], [ParametroDescricao], [ParametroCod]";
         sFromString = " FROM [Parametro]";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY [ParametroCod]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV55Parametrowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod)) ) )
         {
            AddWhere(sWhereString, "([ParametroCod] like @lV56Parametrowwds_2_tfparametrocod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroCod] = @AV57Parametrowwds_3_tfparametrocod_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroCod] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] like @lV58Parametrowwds_4_tfparametrodescricao)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] = @AV59Parametrowwds_5_tfparametrodescricao_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "([ParametroValor] like @lV60Parametrowwds_6_tfparametrovalor)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroValor] = @AV61Parametrowwds_7_tfparametrovalor_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroValor] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario)) ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] like @lV62Parametrowwds_8_tfparametrocomentario)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] = @AV63Parametrowwds_9_tfparametrocomentario_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroComentario] = ''))");
         }
         sOrderString += " ORDER BY [ParametroCod]";
         sOrderStringT = " ORDER BY [ParametroCod]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006G3( IGxContext context ,
                                             string AV55Parametrowwds_1_filterfulltext ,
                                             string AV57Parametrowwds_3_tfparametrocod_sel ,
                                             string AV56Parametrowwds_2_tfparametrocod ,
                                             string AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                             string AV58Parametrowwds_4_tfparametrodescricao ,
                                             string AV61Parametrowwds_7_tfparametrovalor_sel ,
                                             string AV60Parametrowwds_6_tfparametrovalor ,
                                             string AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                             string AV62Parametrowwds_8_tfparametrocomentario ,
                                             string A124ParametroCod ,
                                             string A125ParametroDescricao ,
                                             string A126ParametroValor ,
                                             string A127ParametroComentario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ParametroDescricao], [ParametroComentario], [ParametroValor], [ParametroCod] FROM [Parametro]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV55Parametrowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod)) ) )
         {
            AddWhere(sWhereString, "([ParametroCod] like @lV56Parametrowwds_2_tfparametrocod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroCod] = @AV57Parametrowwds_3_tfparametrocod_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroCod] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] like @lV58Parametrowwds_4_tfparametrodescricao)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] = @AV59Parametrowwds_5_tfparametrodescricao_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "([ParametroValor] like @lV60Parametrowwds_6_tfparametrovalor)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroValor] = @AV61Parametrowwds_7_tfparametrovalor_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroValor] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario)) ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] like @lV62Parametrowwds_8_tfparametrocomentario)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] = @AV63Parametrowwds_9_tfparametrocomentario_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroComentario] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametroDescricao]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006G4( IGxContext context ,
                                             string AV55Parametrowwds_1_filterfulltext ,
                                             string AV57Parametrowwds_3_tfparametrocod_sel ,
                                             string AV56Parametrowwds_2_tfparametrocod ,
                                             string AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                             string AV58Parametrowwds_4_tfparametrodescricao ,
                                             string AV61Parametrowwds_7_tfparametrovalor_sel ,
                                             string AV60Parametrowwds_6_tfparametrovalor ,
                                             string AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                             string AV62Parametrowwds_8_tfparametrocomentario ,
                                             string A124ParametroCod ,
                                             string A125ParametroDescricao ,
                                             string A126ParametroValor ,
                                             string A127ParametroComentario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ParametroValor], [ParametroComentario], [ParametroDescricao], [ParametroCod] FROM [Parametro]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV55Parametrowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod)) ) )
         {
            AddWhere(sWhereString, "([ParametroCod] like @lV56Parametrowwds_2_tfparametrocod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroCod] = @AV57Parametrowwds_3_tfparametrocod_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroCod] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] like @lV58Parametrowwds_4_tfparametrodescricao)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] = @AV59Parametrowwds_5_tfparametrodescricao_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "([ParametroValor] like @lV60Parametrowwds_6_tfparametrovalor)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroValor] = @AV61Parametrowwds_7_tfparametrovalor_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroValor] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario)) ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] like @lV62Parametrowwds_8_tfparametrocomentario)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] = @AV63Parametrowwds_9_tfparametrocomentario_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroComentario] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametroValor]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006G5( IGxContext context ,
                                             string AV55Parametrowwds_1_filterfulltext ,
                                             string AV57Parametrowwds_3_tfparametrocod_sel ,
                                             string AV56Parametrowwds_2_tfparametrocod ,
                                             string AV59Parametrowwds_5_tfparametrodescricao_sel ,
                                             string AV58Parametrowwds_4_tfparametrodescricao ,
                                             string AV61Parametrowwds_7_tfparametrovalor_sel ,
                                             string AV60Parametrowwds_6_tfparametrovalor ,
                                             string AV63Parametrowwds_9_tfparametrocomentario_sel ,
                                             string AV62Parametrowwds_8_tfparametrocomentario ,
                                             string A124ParametroCod ,
                                             string A125ParametroDescricao ,
                                             string A126ParametroValor ,
                                             string A127ParametroComentario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [ParametroComentario], [ParametroValor], [ParametroDescricao], [ParametroCod] FROM [Parametro]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametrowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV55Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV55Parametrowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametrowwds_2_tfparametrocod)) ) )
         {
            AddWhere(sWhereString, "([ParametroCod] like @lV56Parametrowwds_2_tfparametrocod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroCod] = @AV57Parametrowwds_3_tfparametrocod_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroCod] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Parametrowwds_4_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] like @lV58Parametrowwds_4_tfparametrodescricao)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] = @AV59Parametrowwds_5_tfparametrodescricao_sel)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Parametrowwds_6_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "([ParametroValor] like @lV60Parametrowwds_6_tfparametrovalor)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroValor] = @AV61Parametrowwds_7_tfparametrovalor_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroValor] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Parametrowwds_8_tfparametrocomentario)) ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] like @lV62Parametrowwds_8_tfparametrocomentario)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] = @AV63Parametrowwds_9_tfparametrocomentario_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV63Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroComentario] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametroComentario]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P006G3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P006G4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 3 :
                     return conditional_P006G5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006G2;
          prmP006G2 = new Object[] {
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
          new ParDef("@AV57Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV58Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
          new ParDef("@AV63Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP006G3;
          prmP006G3 = new Object[] {
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
          new ParDef("@AV57Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV58Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
          new ParDef("@AV63Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0)
          };
          Object[] prmP006G4;
          prmP006G4 = new Object[] {
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
          new ParDef("@AV57Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV58Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
          new ParDef("@AV63Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0)
          };
          Object[] prmP006G5;
          prmP006G5 = new Object[] {
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
          new ParDef("@AV57Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV58Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
          new ParDef("@AV63Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.parametrowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class parametrowwgetfilterdata_services : GxRestService
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

    [OperationContract(Name = "ParametroWWGetFilterData" )]
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
          permissionPrefix = "parametroww_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("parametrowwgetfilterdata") )
          {
             return  ;
          }
          parametrowwgetfilterdata worker = new parametrowwgetfilterdata(context);
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
