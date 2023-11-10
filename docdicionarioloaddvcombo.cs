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
   public class docdicionarioloaddvcombo : GXProcedure
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
            return "docdicionario_Services_Execute" ;
         }

      }

      public docdicionarioloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docdicionarioloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_DocDicionarioId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV20ComboName = aP0_ComboName;
         this.AV22TrnMode = aP1_TrnMode;
         this.AV25IsDynamicCall = aP2_IsDynamicCall;
         this.AV28DocDicionarioId = aP3_DocDicionarioId;
         this.AV14SearchTxtParms = aP4_SearchTxtParms;
         this.AV19SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV13Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV19SelectedValue;
         aP6_SelectedText=this.AV24SelectedText;
         aP7_Combo_DataJson=this.AV13Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_DocDicionarioId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_DocDicionarioId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_DocDicionarioId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         docdicionarioloaddvcombo objdocdicionarioloaddvcombo;
         objdocdicionarioloaddvcombo = new docdicionarioloaddvcombo();
         objdocdicionarioloaddvcombo.AV20ComboName = aP0_ComboName;
         objdocdicionarioloaddvcombo.AV22TrnMode = aP1_TrnMode;
         objdocdicionarioloaddvcombo.AV25IsDynamicCall = aP2_IsDynamicCall;
         objdocdicionarioloaddvcombo.AV28DocDicionarioId = aP3_DocDicionarioId;
         objdocdicionarioloaddvcombo.AV14SearchTxtParms = aP4_SearchTxtParms;
         objdocdicionarioloaddvcombo.AV19SelectedValue = "" ;
         objdocdicionarioloaddvcombo.AV24SelectedText = "" ;
         objdocdicionarioloaddvcombo.AV13Combo_DataJson = "" ;
         objdocdicionarioloaddvcombo.context.SetSubmitInitialConfig(context);
         objdocdicionarioloaddvcombo.initialize();
         Submit( executePrivateCatch,objdocdicionarioloaddvcombo);
         aP5_SelectedValue=this.AV19SelectedValue;
         aP6_SelectedText=this.AV24SelectedText;
         aP7_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docdicionarioloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV20ComboName, "HipoteseTratamentoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_HIPOTESETRATAMENTOID' */
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
         /* 'LOADCOMBOITEMS_HIPOTESETRATAMENTOID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom2 = AV15SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A73HipoteseTratamentoNome } ,
                                                 new int[]{
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P00322 */
            pr_default.execute(0, new Object[] {lV12SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A73HipoteseTratamentoNome = P00322_A73HipoteseTratamentoNome[0];
               A72HipoteseTratamentoId = P00322_A72HipoteseTratamentoId[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A72HipoteseTratamentoId), 8, 0));
               AV18Combo_DataItem.gxTpr_Title = A73HipoteseTratamentoNome;
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
               if ( StringUtil.StrCmp(AV22TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00323 */
                  pr_default.execute(1, new Object[] {AV28DocDicionarioId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A98DocDicionarioId = P00323_A98DocDicionarioId[0];
                     A72HipoteseTratamentoId = P00323_A72HipoteseTratamentoId[0];
                     A73HipoteseTratamentoNome = P00323_A73HipoteseTratamentoNome[0];
                     A73HipoteseTratamentoNome = P00323_A73HipoteseTratamentoNome[0];
                     AV19SelectedValue = ((0==A72HipoteseTratamentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A72HipoteseTratamentoId), 8, 0)));
                     AV24SelectedText = A73HipoteseTratamentoNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV30HipoteseTratamentoId = (int)(NumberUtil.Val( AV12SearchTxt, "."));
                  /* Using cursor P00324 */
                  pr_default.execute(2, new Object[] {AV30HipoteseTratamentoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A72HipoteseTratamentoId = P00324_A72HipoteseTratamentoId[0];
                     A73HipoteseTratamentoNome = P00324_A73HipoteseTratamentoNome[0];
                     AV24SelectedText = A73HipoteseTratamentoNome;
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
            /* Using cursor P00325 */
            pr_default.execute(3, new Object[] {lV12SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A76DocumentoNome = P00325_A76DocumentoNome[0];
               n76DocumentoNome = P00325_n76DocumentoNome[0];
               A75DocumentoId = P00325_A75DocumentoId[0];
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
               if ( StringUtil.StrCmp(AV22TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00326 */
                  pr_default.execute(4, new Object[] {AV28DocDicionarioId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A98DocDicionarioId = P00326_A98DocDicionarioId[0];
                     A75DocumentoId = P00326_A75DocumentoId[0];
                     A76DocumentoNome = P00326_A76DocumentoNome[0];
                     n76DocumentoNome = P00326_n76DocumentoNome[0];
                     A76DocumentoNome = P00326_A76DocumentoNome[0];
                     n76DocumentoNome = P00326_n76DocumentoNome[0];
                     AV19SelectedValue = ((0==A75DocumentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A75DocumentoId), 8, 0)));
                     AV24SelectedText = A76DocumentoNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV31DocumentoId = (int)(NumberUtil.Val( AV12SearchTxt, "."));
                  /* Using cursor P00327 */
                  pr_default.execute(5, new Object[] {AV31DocumentoId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A75DocumentoId = P00327_A75DocumentoId[0];
                     A76DocumentoNome = P00327_A76DocumentoNome[0];
                     n76DocumentoNome = P00327_n76DocumentoNome[0];
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
         A73HipoteseTratamentoNome = "";
         P00322_A73HipoteseTratamentoNome = new string[] {""} ;
         P00322_A72HipoteseTratamentoId = new int[1] ;
         AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV17Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00323_A98DocDicionarioId = new int[1] ;
         P00323_A72HipoteseTratamentoId = new int[1] ;
         P00323_A73HipoteseTratamentoNome = new string[] {""} ;
         P00324_A72HipoteseTratamentoId = new int[1] ;
         P00324_A73HipoteseTratamentoNome = new string[] {""} ;
         A76DocumentoNome = "";
         P00325_A76DocumentoNome = new string[] {""} ;
         P00325_n76DocumentoNome = new bool[] {false} ;
         P00325_A75DocumentoId = new int[1] ;
         P00326_A98DocDicionarioId = new int[1] ;
         P00326_A75DocumentoId = new int[1] ;
         P00326_A76DocumentoNome = new string[] {""} ;
         P00326_n76DocumentoNome = new bool[] {false} ;
         P00327_A75DocumentoId = new int[1] ;
         P00327_A76DocumentoNome = new string[] {""} ;
         P00327_n76DocumentoNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionarioloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00322_A73HipoteseTratamentoNome, P00322_A72HipoteseTratamentoId
               }
               , new Object[] {
               P00323_A98DocDicionarioId, P00323_A72HipoteseTratamentoId, P00323_A73HipoteseTratamentoNome
               }
               , new Object[] {
               P00324_A72HipoteseTratamentoId, P00324_A73HipoteseTratamentoNome
               }
               , new Object[] {
               P00325_A76DocumentoNome, P00325_n76DocumentoNome, P00325_A75DocumentoId
               }
               , new Object[] {
               P00326_A98DocDicionarioId, P00326_A75DocumentoId, P00326_A76DocumentoNome, P00326_n76DocumentoNome
               }
               , new Object[] {
               P00327_A75DocumentoId, P00327_A76DocumentoNome, P00327_n76DocumentoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV28DocDicionarioId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A72HipoteseTratamentoId ;
      private int A98DocDicionarioId ;
      private int AV30HipoteseTratamentoId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A75DocumentoId ;
      private int AV31DocumentoId ;
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
      private string A73HipoteseTratamentoNome ;
      private string A76DocumentoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00322_A73HipoteseTratamentoNome ;
      private int[] P00322_A72HipoteseTratamentoId ;
      private int[] P00323_A98DocDicionarioId ;
      private int[] P00323_A72HipoteseTratamentoId ;
      private string[] P00323_A73HipoteseTratamentoNome ;
      private int[] P00324_A72HipoteseTratamentoId ;
      private string[] P00324_A73HipoteseTratamentoNome ;
      private string[] P00325_A76DocumentoNome ;
      private bool[] P00325_n76DocumentoNome ;
      private int[] P00325_A75DocumentoId ;
      private int[] P00326_A98DocDicionarioId ;
      private int[] P00326_A75DocumentoId ;
      private string[] P00326_A76DocumentoNome ;
      private bool[] P00326_n76DocumentoNome ;
      private int[] P00327_A75DocumentoId ;
      private string[] P00327_A76DocumentoNome ;
      private bool[] P00327_n76DocumentoNome ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV18Combo_DataItem ;
   }

   public class docdicionarioloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00322( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A73HipoteseTratamentoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [HipoteseTratamentoNome], [HipoteseTratamentoId]";
         sFromString = " FROM [HipoteseTratamento]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([HipoteseTratamentoNome] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY [HipoteseTratamentoNome]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00325( IGxContext context ,
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
                     return conditional_P00322(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00325(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00323;
          prmP00323 = new Object[] {
          new ParDef("@AV28DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP00324;
          prmP00324 = new Object[] {
          new ParDef("@AV30HipoteseTratamentoId",GXType.Int32,8,0)
          };
          Object[] prmP00326;
          prmP00326 = new Object[] {
          new ParDef("@AV28DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP00327;
          prmP00327 = new Object[] {
          new ParDef("@AV31DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP00322;
          prmP00322 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00325;
          prmP00325 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00322", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00322,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00323", "SELECT T1.[DocDicionarioId], T1.[HipoteseTratamentoId], T2.[HipoteseTratamentoNome] FROM ([DocDicionario] T1 INNER JOIN [HipoteseTratamento] T2 ON T2.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) WHERE T1.[DocDicionarioId] = @AV28DocDicionarioId ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00323,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00324", "SELECT TOP 1 [HipoteseTratamentoId], [HipoteseTratamentoNome] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @AV30HipoteseTratamentoId ORDER BY [HipoteseTratamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00324,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00325", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00325,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00326", "SELECT T1.[DocDicionarioId], T1.[DocumentoId], T2.[DocumentoNome] FROM ([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) WHERE T1.[DocDicionarioId] = @AV28DocDicionarioId ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00326,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00327", "SELECT TOP 1 [DocumentoId], [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @AV31DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00327,1, GxCacheFrequency.OFF ,false,true )
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

 [ServiceContract(Namespace = "GeneXus.Programs.docdicionarioloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class docdicionarioloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "DocDicionarioLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string DocDicionarioId ,
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
          permissionPrefix = "docdicionario_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("docdicionarioloaddvcombo") )
          {
             return  ;
          }
          docdicionarioloaddvcombo worker = new docdicionarioloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          int gxrDocDicionarioId = 0;
          gxrDocDicionarioId = (int)(NumberUtil.Val( (string)(DocDicionarioId), "."));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrDocDicionarioId,SearchTxtParms,out SelectedValue,out SelectedText,out Combo_DataJson );
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
