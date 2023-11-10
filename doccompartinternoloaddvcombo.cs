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
   public class doccompartinternoloaddvcombo : GXProcedure
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
            return "doccompartinterno_Services_Execute" ;
         }

      }

      public doccompartinternoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public doccompartinternoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_CompartInternoId ,
                           int aP4_DocumentoId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV20ComboName = aP0_ComboName;
         this.AV22TrnMode = aP1_TrnMode;
         this.AV25IsDynamicCall = aP2_IsDynamicCall;
         this.AV27CompartInternoId = aP3_CompartInternoId;
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
                                int aP3_CompartInternoId ,
                                int aP4_DocumentoId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CompartInternoId, aP4_DocumentoId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_CompartInternoId ,
                                 int aP4_DocumentoId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         doccompartinternoloaddvcombo objdoccompartinternoloaddvcombo;
         objdoccompartinternoloaddvcombo = new doccompartinternoloaddvcombo();
         objdoccompartinternoloaddvcombo.AV20ComboName = aP0_ComboName;
         objdoccompartinternoloaddvcombo.AV22TrnMode = aP1_TrnMode;
         objdoccompartinternoloaddvcombo.AV25IsDynamicCall = aP2_IsDynamicCall;
         objdoccompartinternoloaddvcombo.AV27CompartInternoId = aP3_CompartInternoId;
         objdoccompartinternoloaddvcombo.AV28DocumentoId = aP4_DocumentoId;
         objdoccompartinternoloaddvcombo.AV14SearchTxtParms = aP5_SearchTxtParms;
         objdoccompartinternoloaddvcombo.AV19SelectedValue = "" ;
         objdoccompartinternoloaddvcombo.AV24SelectedText = "" ;
         objdoccompartinternoloaddvcombo.AV13Combo_DataJson = "" ;
         objdoccompartinternoloaddvcombo.context.SetSubmitInitialConfig(context);
         objdoccompartinternoloaddvcombo.initialize();
         Submit( executePrivateCatch,objdoccompartinternoloaddvcombo);
         aP6_SelectedValue=this.AV19SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((doccompartinternoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV20ComboName, "CompartInternoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_COMPARTINTERNOID' */
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
         /* 'LOADCOMBOITEMS_COMPARTINTERNOID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom2 = AV15SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A58CompartInternoNome } ,
                                                 new int[]{
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P004R2 */
            pr_default.execute(0, new Object[] {lV12SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A58CompartInternoNome = P004R2_A58CompartInternoNome[0];
               A57CompartInternoId = P004R2_A57CompartInternoId[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A57CompartInternoId), 8, 0));
               AV18Combo_DataItem.gxTpr_Title = A58CompartInternoNome;
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
               /* Using cursor P004R3 */
               pr_default.execute(1, new Object[] {AV27CompartInternoId, AV28DocumentoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A75DocumentoId = P004R3_A75DocumentoId[0];
                  A57CompartInternoId = P004R3_A57CompartInternoId[0];
                  A58CompartInternoNome = P004R3_A58CompartInternoNome[0];
                  A58CompartInternoNome = P004R3_A58CompartInternoNome[0];
                  AV19SelectedValue = ((0==A57CompartInternoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A57CompartInternoId), 8, 0)));
                  AV24SelectedText = A58CompartInternoNome;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV27CompartInternoId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27CompartInternoId), 8, 0));
                  /* Using cursor P004R4 */
                  pr_default.execute(2, new Object[] {AV27CompartInternoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A57CompartInternoId = P004R4_A57CompartInternoId[0];
                     A58CompartInternoNome = P004R4_A58CompartInternoNome[0];
                     AV24SelectedText = A58CompartInternoNome;
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
            /* Using cursor P004R5 */
            pr_default.execute(3, new Object[] {lV12SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A76DocumentoNome = P004R5_A76DocumentoNome[0];
               n76DocumentoNome = P004R5_n76DocumentoNome[0];
               A75DocumentoId = P004R5_A75DocumentoId[0];
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
               /* Using cursor P004R6 */
               pr_default.execute(4, new Object[] {AV27CompartInternoId, AV28DocumentoId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A75DocumentoId = P004R6_A75DocumentoId[0];
                  A57CompartInternoId = P004R6_A57CompartInternoId[0];
                  A76DocumentoNome = P004R6_A76DocumentoNome[0];
                  n76DocumentoNome = P004R6_n76DocumentoNome[0];
                  A76DocumentoNome = P004R6_A76DocumentoNome[0];
                  n76DocumentoNome = P004R6_n76DocumentoNome[0];
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
                  /* Using cursor P004R7 */
                  pr_default.execute(5, new Object[] {AV28DocumentoId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A75DocumentoId = P004R7_A75DocumentoId[0];
                     A76DocumentoNome = P004R7_A76DocumentoNome[0];
                     n76DocumentoNome = P004R7_n76DocumentoNome[0];
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
         A58CompartInternoNome = "";
         P004R2_A58CompartInternoNome = new string[] {""} ;
         P004R2_A57CompartInternoId = new int[1] ;
         AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV17Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P004R3_A75DocumentoId = new int[1] ;
         P004R3_A57CompartInternoId = new int[1] ;
         P004R3_A58CompartInternoNome = new string[] {""} ;
         P004R4_A57CompartInternoId = new int[1] ;
         P004R4_A58CompartInternoNome = new string[] {""} ;
         A76DocumentoNome = "";
         P004R5_A76DocumentoNome = new string[] {""} ;
         P004R5_n76DocumentoNome = new bool[] {false} ;
         P004R5_A75DocumentoId = new int[1] ;
         P004R6_A75DocumentoId = new int[1] ;
         P004R6_A57CompartInternoId = new int[1] ;
         P004R6_A76DocumentoNome = new string[] {""} ;
         P004R6_n76DocumentoNome = new bool[] {false} ;
         P004R7_A75DocumentoId = new int[1] ;
         P004R7_A76DocumentoNome = new string[] {""} ;
         P004R7_n76DocumentoNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.doccompartinternoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004R2_A58CompartInternoNome, P004R2_A57CompartInternoId
               }
               , new Object[] {
               P004R3_A75DocumentoId, P004R3_A57CompartInternoId, P004R3_A58CompartInternoNome
               }
               , new Object[] {
               P004R4_A57CompartInternoId, P004R4_A58CompartInternoNome
               }
               , new Object[] {
               P004R5_A76DocumentoNome, P004R5_n76DocumentoNome, P004R5_A75DocumentoId
               }
               , new Object[] {
               P004R6_A75DocumentoId, P004R6_A57CompartInternoId, P004R6_A76DocumentoNome, P004R6_n76DocumentoNome
               }
               , new Object[] {
               P004R7_A75DocumentoId, P004R7_A76DocumentoNome, P004R7_n76DocumentoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV27CompartInternoId ;
      private int AV28DocumentoId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A57CompartInternoId ;
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
      private string A58CompartInternoNome ;
      private string A76DocumentoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004R2_A58CompartInternoNome ;
      private int[] P004R2_A57CompartInternoId ;
      private int[] P004R3_A75DocumentoId ;
      private int[] P004R3_A57CompartInternoId ;
      private string[] P004R3_A58CompartInternoNome ;
      private int[] P004R4_A57CompartInternoId ;
      private string[] P004R4_A58CompartInternoNome ;
      private string[] P004R5_A76DocumentoNome ;
      private bool[] P004R5_n76DocumentoNome ;
      private int[] P004R5_A75DocumentoId ;
      private int[] P004R6_A75DocumentoId ;
      private int[] P004R6_A57CompartInternoId ;
      private string[] P004R6_A76DocumentoNome ;
      private bool[] P004R6_n76DocumentoNome ;
      private int[] P004R7_A75DocumentoId ;
      private string[] P004R7_A76DocumentoNome ;
      private bool[] P004R7_n76DocumentoNome ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV18Combo_DataItem ;
   }

   public class doccompartinternoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004R2( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A58CompartInternoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CompartInternoNome], [CompartInternoId]";
         sFromString = " FROM [CompartInterno]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([CompartInternoNome] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY [CompartInternoNome]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004R5( IGxContext context ,
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
                     return conditional_P004R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P004R5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP004R3;
          prmP004R3 = new Object[] {
          new ParDef("@AV27CompartInternoId",GXType.Int32,8,0) ,
          new ParDef("@AV28DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP004R4;
          prmP004R4 = new Object[] {
          new ParDef("@AV27CompartInternoId",GXType.Int32,8,0)
          };
          Object[] prmP004R6;
          prmP004R6 = new Object[] {
          new ParDef("@AV27CompartInternoId",GXType.Int32,8,0) ,
          new ParDef("@AV28DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP004R7;
          prmP004R7 = new Object[] {
          new ParDef("@AV28DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP004R2;
          prmP004R2 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP004R5;
          prmP004R5 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004R3", "SELECT T1.[DocumentoId], T1.[CompartInternoId], T2.[CompartInternoNome] FROM ([DocCompartInterno] T1 INNER JOIN [CompartInterno] T2 ON T2.[CompartInternoId] = T1.[CompartInternoId]) WHERE T1.[CompartInternoId] = @AV27CompartInternoId and T1.[DocumentoId] = @AV28DocumentoId ORDER BY T1.[CompartInternoId], T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004R4", "SELECT TOP 1 [CompartInternoId], [CompartInternoNome] FROM [CompartInterno] WHERE [CompartInternoId] = @AV27CompartInternoId ORDER BY [CompartInternoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004R5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004R6", "SELECT T1.[DocumentoId], T1.[CompartInternoId], T2.[DocumentoNome] FROM ([DocCompartInterno] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) WHERE T1.[CompartInternoId] = @AV27CompartInternoId and T1.[DocumentoId] = @AV28DocumentoId ORDER BY T1.[CompartInternoId], T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004R7", "SELECT TOP 1 [DocumentoId], [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @AV28DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R7,1, GxCacheFrequency.OFF ,false,true )
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

 [ServiceContract(Namespace = "GeneXus.Programs.doccompartinternoloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class doccompartinternoloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "DocCompartInternoLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string CompartInternoId ,
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
          permissionPrefix = "doccompartinterno_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("doccompartinternoloaddvcombo") )
          {
             return  ;
          }
          doccompartinternoloaddvcombo worker = new doccompartinternoloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          int gxrCompartInternoId = 0;
          gxrCompartInternoId = (int)(NumberUtil.Val( (string)(CompartInternoId), "."));
          int gxrDocumentoId = 0;
          gxrDocumentoId = (int)(NumberUtil.Val( (string)(DocumentoId), "."));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrCompartInternoId,gxrDocumentoId,SearchTxtParms,out SelectedValue,out SelectedText,out Combo_DataJson );
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
