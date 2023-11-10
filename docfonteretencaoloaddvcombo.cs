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
   public class docfonteretencaoloaddvcombo : GXProcedure
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
            return "docfonteretencao_Services_Execute" ;
         }

      }

      public docfonteretencaoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docfonteretencaoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_FonteRetencaoId ,
                           int aP4_DocumentoId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV20ComboName = aP0_ComboName;
         this.AV22TrnMode = aP1_TrnMode;
         this.AV25IsDynamicCall = aP2_IsDynamicCall;
         this.AV27FonteRetencaoId = aP3_FonteRetencaoId;
         this.AV28DocumentoId = aP4_DocumentoId;
         this.AV14SearchTxtParms = aP5_SearchTxtParms;
         this.AV19SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV13Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP6_SelectedValue=this.AV19SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV13Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_FonteRetencaoId ,
                                int aP4_DocumentoId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_FonteRetencaoId, aP4_DocumentoId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_FonteRetencaoId ,
                                 int aP4_DocumentoId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         docfonteretencaoloaddvcombo objdocfonteretencaoloaddvcombo;
         objdocfonteretencaoloaddvcombo = new docfonteretencaoloaddvcombo();
         objdocfonteretencaoloaddvcombo.AV20ComboName = aP0_ComboName;
         objdocfonteretencaoloaddvcombo.AV22TrnMode = aP1_TrnMode;
         objdocfonteretencaoloaddvcombo.AV25IsDynamicCall = aP2_IsDynamicCall;
         objdocfonteretencaoloaddvcombo.AV27FonteRetencaoId = aP3_FonteRetencaoId;
         objdocfonteretencaoloaddvcombo.AV28DocumentoId = aP4_DocumentoId;
         objdocfonteretencaoloaddvcombo.AV14SearchTxtParms = aP5_SearchTxtParms;
         objdocfonteretencaoloaddvcombo.AV19SelectedValue = "" ;
         objdocfonteretencaoloaddvcombo.AV24SelectedText = "" ;
         objdocfonteretencaoloaddvcombo.AV13Combo_DataJson = "" ;
         objdocfonteretencaoloaddvcombo.context.SetSubmitInitialConfig(context);
         objdocfonteretencaoloaddvcombo.initialize();
         Submit( executePrivateCatch,objdocfonteretencaoloaddvcombo);
         aP6_SelectedValue=this.AV19SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docfonteretencaoloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxtParms))||StringUtil.StartsWith( AV22TrnMode, "GET") ? 0 : (long)(NumberUtil.Val( StringUtil.Substring( AV14SearchTxtParms, 1, 2), "."))));
         AV12SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxtParms))||StringUtil.StartsWith( AV22TrnMode, "GET") ? AV14SearchTxtParms : StringUtil.Substring( AV14SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV20ComboName, "FonteRetencaoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_FONTERETENCAOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV20ComboName, "DocumentoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DOCUMENTOID' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_FONTERETENCAOID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom2 = AV15SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A64FonteRetencaoNome } ,
                                                 new int[]{
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P004T2 */
            pr_default.execute(0, new Object[] {lV12SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A64FonteRetencaoNome = P004T2_A64FonteRetencaoNome[0];
               A63FonteRetencaoId = P004T2_A63FonteRetencaoId[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A63FonteRetencaoId), 8, 0));
               AV18Combo_DataItem.gxTpr_Title = A64FonteRetencaoNome;
               AV17Combo_Data.Add(AV18Combo_DataItem, 0);
               if ( AV17Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV13Combo_DataJson = AV17Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV22TrnMode, "INS") != 0 )
            {
               /* Using cursor P004T3 */
               pr_default.execute(1, new Object[] {AV27FonteRetencaoId, AV28DocumentoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A75DocumentoId = P004T3_A75DocumentoId[0];
                  A63FonteRetencaoId = P004T3_A63FonteRetencaoId[0];
                  A64FonteRetencaoNome = P004T3_A64FonteRetencaoNome[0];
                  A64FonteRetencaoNome = P004T3_A64FonteRetencaoNome[0];
                  AV19SelectedValue = ((0==A63FonteRetencaoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A63FonteRetencaoId), 8, 0)));
                  AV24SelectedText = A64FonteRetencaoNome;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV27FonteRetencaoId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27FonteRetencaoId), 8, 0));
                  /* Using cursor P004T4 */
                  pr_default.execute(2, new Object[] {AV27FonteRetencaoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A63FonteRetencaoId = P004T4_A63FonteRetencaoId[0];
                     A64FonteRetencaoNome = P004T4_A64FonteRetencaoNome[0];
                     AV24SelectedText = A64FonteRetencaoNome;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_DOCUMENTOID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom5 = AV15SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A76DocumentoNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P004T5 */
            pr_default.execute(3, new Object[] {lV12SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A76DocumentoNome = P004T5_A76DocumentoNome[0];
               n76DocumentoNome = P004T5_n76DocumentoNome[0];
               A75DocumentoId = P004T5_A75DocumentoId[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A75DocumentoId), 8, 0));
               AV18Combo_DataItem.gxTpr_Title = A76DocumentoNome;
               AV17Combo_Data.Add(AV18Combo_DataItem, 0);
               if ( AV17Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV13Combo_DataJson = AV17Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV22TrnMode, "INS") != 0 )
            {
               /* Using cursor P004T6 */
               pr_default.execute(4, new Object[] {AV27FonteRetencaoId, AV28DocumentoId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A75DocumentoId = P004T6_A75DocumentoId[0];
                  A63FonteRetencaoId = P004T6_A63FonteRetencaoId[0];
                  A76DocumentoNome = P004T6_A76DocumentoNome[0];
                  n76DocumentoNome = P004T6_n76DocumentoNome[0];
                  A76DocumentoNome = P004T6_A76DocumentoNome[0];
                  n76DocumentoNome = P004T6_n76DocumentoNome[0];
                  AV19SelectedValue = ((0==A75DocumentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A75DocumentoId), 8, 0)));
                  AV24SelectedText = A76DocumentoNome;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
            }
            else
            {
               if ( ! (0==AV28DocumentoId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DocumentoId), 8, 0));
                  /* Using cursor P004T7 */
                  pr_default.execute(5, new Object[] {AV28DocumentoId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A75DocumentoId = P004T7_A75DocumentoId[0];
                     A76DocumentoNome = P004T7_A76DocumentoNome[0];
                     n76DocumentoNome = P004T7_n76DocumentoNome[0];
                     AV24SelectedText = A76DocumentoNome;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
            }
         }
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
         AV19SelectedValue = "";
         AV24SelectedText = "";
         AV13Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12SearchTxt = "";
         scmdbuf = "";
         lV12SearchTxt = "";
         A64FonteRetencaoNome = "";
         P004T2_A64FonteRetencaoNome = new string[] {""} ;
         P004T2_A63FonteRetencaoId = new int[1] ;
         AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV17Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P004T3_A75DocumentoId = new int[1] ;
         P004T3_A63FonteRetencaoId = new int[1] ;
         P004T3_A64FonteRetencaoNome = new string[] {""} ;
         P004T4_A63FonteRetencaoId = new int[1] ;
         P004T4_A64FonteRetencaoNome = new string[] {""} ;
         A76DocumentoNome = "";
         P004T5_A76DocumentoNome = new string[] {""} ;
         P004T5_n76DocumentoNome = new bool[] {false} ;
         P004T5_A75DocumentoId = new int[1] ;
         P004T6_A75DocumentoId = new int[1] ;
         P004T6_A63FonteRetencaoId = new int[1] ;
         P004T6_A76DocumentoNome = new string[] {""} ;
         P004T6_n76DocumentoNome = new bool[] {false} ;
         P004T7_A75DocumentoId = new int[1] ;
         P004T7_A76DocumentoNome = new string[] {""} ;
         P004T7_n76DocumentoNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docfonteretencaoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004T2_A64FonteRetencaoNome, P004T2_A63FonteRetencaoId
               }
               , new Object[] {
               P004T3_A75DocumentoId, P004T3_A63FonteRetencaoId, P004T3_A64FonteRetencaoNome
               }
               , new Object[] {
               P004T4_A63FonteRetencaoId, P004T4_A64FonteRetencaoNome
               }
               , new Object[] {
               P004T5_A76DocumentoNome, P004T5_n76DocumentoNome, P004T5_A75DocumentoId
               }
               , new Object[] {
               P004T6_A75DocumentoId, P004T6_A63FonteRetencaoId, P004T6_A76DocumentoNome, P004T6_n76DocumentoNome
               }
               , new Object[] {
               P004T7_A75DocumentoId, P004T7_A76DocumentoNome, P004T7_n76DocumentoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV27FonteRetencaoId ;
      private int AV28DocumentoId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A63FonteRetencaoId ;
      private int A75DocumentoId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private string AV22TrnMode ;
      private string scmdbuf ;
      private bool AV25IsDynamicCall ;
      private bool returnInSub ;
      private bool n76DocumentoNome ;
      private string AV13Combo_DataJson ;
      private string AV20ComboName ;
      private string AV14SearchTxtParms ;
      private string AV19SelectedValue ;
      private string AV24SelectedText ;
      private string AV12SearchTxt ;
      private string lV12SearchTxt ;
      private string A64FonteRetencaoNome ;
      private string A76DocumentoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004T2_A64FonteRetencaoNome ;
      private int[] P004T2_A63FonteRetencaoId ;
      private int[] P004T3_A75DocumentoId ;
      private int[] P004T3_A63FonteRetencaoId ;
      private string[] P004T3_A64FonteRetencaoNome ;
      private int[] P004T4_A63FonteRetencaoId ;
      private string[] P004T4_A64FonteRetencaoNome ;
      private string[] P004T5_A76DocumentoNome ;
      private bool[] P004T5_n76DocumentoNome ;
      private int[] P004T5_A75DocumentoId ;
      private int[] P004T6_A75DocumentoId ;
      private int[] P004T6_A63FonteRetencaoId ;
      private string[] P004T6_A76DocumentoNome ;
      private bool[] P004T6_n76DocumentoNome ;
      private int[] P004T7_A75DocumentoId ;
      private string[] P004T7_A76DocumentoNome ;
      private bool[] P004T7_n76DocumentoNome ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV18Combo_DataItem ;
   }

   public class docfonteretencaoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004T2( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A64FonteRetencaoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [FonteRetencaoNome], [FonteRetencaoId]";
         sFromString = " FROM [FonteRetencao]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([FonteRetencaoNome] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY [FonteRetencaoNome]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004T5( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A76DocumentoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DocumentoNome], [DocumentoId]";
         sFromString = " FROM [Documento]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([DocumentoNome] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY [DocumentoNome]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom5" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo5" + " > 0 THEN " + "@GXPagingTo5" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
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
                     return conditional_P004T2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P004T5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004T3;
          prmP004T3 = new Object[] {
          new ParDef("@AV27FonteRetencaoId",GXType.Int32,8,0) ,
          new ParDef("@AV28DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP004T4;
          prmP004T4 = new Object[] {
          new ParDef("@AV27FonteRetencaoId",GXType.Int32,8,0)
          };
          Object[] prmP004T6;
          prmP004T6 = new Object[] {
          new ParDef("@AV27FonteRetencaoId",GXType.Int32,8,0) ,
          new ParDef("@AV28DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP004T7;
          prmP004T7 = new Object[] {
          new ParDef("@AV28DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP004T2;
          prmP004T2 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP004T5;
          prmP004T5 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004T3", "SELECT T1.[DocumentoId], T1.[FonteRetencaoId], T2.[FonteRetencaoNome] FROM ([DocFonteRetencao] T1 INNER JOIN [FonteRetencao] T2 ON T2.[FonteRetencaoId] = T1.[FonteRetencaoId]) WHERE T1.[FonteRetencaoId] = @AV27FonteRetencaoId and T1.[DocumentoId] = @AV28DocumentoId ORDER BY T1.[FonteRetencaoId], T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004T4", "SELECT TOP 1 [FonteRetencaoId], [FonteRetencaoNome] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @AV27FonteRetencaoId ORDER BY [FonteRetencaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004T5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004T6", "SELECT T1.[DocumentoId], T1.[FonteRetencaoId], T2.[DocumentoNome] FROM ([DocFonteRetencao] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) WHERE T1.[FonteRetencaoId] = @AV27FonteRetencaoId and T1.[DocumentoId] = @AV28DocumentoId ORDER BY T1.[FonteRetencaoId], T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004T7", "SELECT TOP 1 [DocumentoId], [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @AV28DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T7,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.docfonteretencaoloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class docfonteretencaoloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "DocFonteRetencaoLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string FonteRetencaoId ,
                         string DocumentoId ,
                         string SearchTxtParms ,
                         out string SelectedValue ,
                         out string SelectedText ,
                         out string Combo_DataJson )
    {
       SelectedValue = "" ;
       SelectedText = "" ;
       Combo_DataJson = "" ;
       try
       {
          permissionPrefix = "docfonteretencao_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("docfonteretencaoloaddvcombo") )
          {
             return  ;
          }
          docfonteretencaoloaddvcombo worker = new docfonteretencaoloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          int gxrFonteRetencaoId = 0;
          gxrFonteRetencaoId = (int)(NumberUtil.Val( (string)(FonteRetencaoId), "."));
          int gxrDocumentoId = 0;
          gxrDocumentoId = (int)(NumberUtil.Val( (string)(DocumentoId), "."));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrFonteRetencaoId,gxrDocumentoId,SearchTxtParms,out SelectedValue,out SelectedText,out Combo_DataJson );
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
