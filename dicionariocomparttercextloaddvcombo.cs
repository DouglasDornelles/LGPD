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
   public class dicionariocomparttercextloaddvcombo : GXProcedure
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
            return "dicionariocomparttercext_Services_Execute" ;
         }

      }

      public dicionariocomparttercextloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariocomparttercextloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_CompartTercExternoId ,
                           int aP4_DocDicionarioId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV20ComboName = aP0_ComboName;
         this.AV22TrnMode = aP1_TrnMode;
         this.AV25IsDynamicCall = aP2_IsDynamicCall;
         this.AV28CompartTercExternoId = aP3_CompartTercExternoId;
         this.AV29DocDicionarioId = aP4_DocDicionarioId;
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
                                int aP3_CompartTercExternoId ,
                                int aP4_DocDicionarioId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CompartTercExternoId, aP4_DocDicionarioId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_CompartTercExternoId ,
                                 int aP4_DocDicionarioId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         dicionariocomparttercextloaddvcombo objdicionariocomparttercextloaddvcombo;
         objdicionariocomparttercextloaddvcombo = new dicionariocomparttercextloaddvcombo();
         objdicionariocomparttercextloaddvcombo.AV20ComboName = aP0_ComboName;
         objdicionariocomparttercextloaddvcombo.AV22TrnMode = aP1_TrnMode;
         objdicionariocomparttercextloaddvcombo.AV25IsDynamicCall = aP2_IsDynamicCall;
         objdicionariocomparttercextloaddvcombo.AV28CompartTercExternoId = aP3_CompartTercExternoId;
         objdicionariocomparttercextloaddvcombo.AV29DocDicionarioId = aP4_DocDicionarioId;
         objdicionariocomparttercextloaddvcombo.AV14SearchTxtParms = aP5_SearchTxtParms;
         objdicionariocomparttercextloaddvcombo.AV19SelectedValue = "" ;
         objdicionariocomparttercextloaddvcombo.AV24SelectedText = "" ;
         objdicionariocomparttercextloaddvcombo.AV13Combo_DataJson = "" ;
         objdicionariocomparttercextloaddvcombo.context.SetSubmitInitialConfig(context);
         objdicionariocomparttercextloaddvcombo.initialize();
         Submit( executePrivateCatch,objdicionariocomparttercextloaddvcombo);
         aP6_SelectedValue=this.AV19SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariocomparttercextloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV20ComboName, "CompartTercExternoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_COMPARTTERCEXTERNOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV20ComboName, "DocDicionarioId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DOCDICIONARIOID' */
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
         /* 'LOADCOMBOITEMS_COMPARTTERCEXTERNOID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom2 = AV15SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A67CompartTercExternoNome } ,
                                                 new int[]{
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P002X2 */
            pr_default.execute(0, new Object[] {lV12SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A67CompartTercExternoNome = P002X2_A67CompartTercExternoNome[0];
               A66CompartTercExternoId = P002X2_A66CompartTercExternoId[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A66CompartTercExternoId), 8, 0));
               AV18Combo_DataItem.gxTpr_Title = A67CompartTercExternoNome;
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
               /* Using cursor P002X3 */
               pr_default.execute(1, new Object[] {AV28CompartTercExternoId, AV29DocDicionarioId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A98DocDicionarioId = P002X3_A98DocDicionarioId[0];
                  A66CompartTercExternoId = P002X3_A66CompartTercExternoId[0];
                  A67CompartTercExternoNome = P002X3_A67CompartTercExternoNome[0];
                  A67CompartTercExternoNome = P002X3_A67CompartTercExternoNome[0];
                  AV19SelectedValue = ((0==A66CompartTercExternoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A66CompartTercExternoId), 8, 0)));
                  AV24SelectedText = A67CompartTercExternoNome;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV28CompartTercExternoId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28CompartTercExternoId), 8, 0));
                  /* Using cursor P002X4 */
                  pr_default.execute(2, new Object[] {AV28CompartTercExternoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A66CompartTercExternoId = P002X4_A66CompartTercExternoId[0];
                     A67CompartTercExternoNome = P002X4_A67CompartTercExternoNome[0];
                     AV24SelectedText = A67CompartTercExternoNome;
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
         /* 'LOADCOMBOITEMS_DOCDICIONARIOID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom5 = AV15SkipItems;
            GXPagingTo5 = AV11MaxItems;
            /* Using cursor P002X5 */
            pr_default.execute(3, new Object[] {GXPagingFrom5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A98DocDicionarioId = P002X5_A98DocDicionarioId[0];
               A99DocDicionarioSensivel = P002X5_A99DocDicionarioSensivel[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A98DocDicionarioId), 8, 0));
               if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A99DocDicionarioSensivel)), "true") == 0 )
               {
                  AV18Combo_DataItem.gxTpr_Title = "true";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A99DocDicionarioSensivel)), "false") == 0 )
               {
                  AV18Combo_DataItem.gxTpr_Title = "false";
               }
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
               /* Using cursor P002X6 */
               pr_default.execute(4, new Object[] {AV28CompartTercExternoId, AV29DocDicionarioId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A98DocDicionarioId = P002X6_A98DocDicionarioId[0];
                  A66CompartTercExternoId = P002X6_A66CompartTercExternoId[0];
                  A99DocDicionarioSensivel = P002X6_A99DocDicionarioSensivel[0];
                  A99DocDicionarioSensivel = P002X6_A99DocDicionarioSensivel[0];
                  AV19SelectedValue = ((0==A98DocDicionarioId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A98DocDicionarioId), 8, 0)));
                  if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A99DocDicionarioSensivel)), "true") == 0 )
                  {
                     AV24SelectedText = "true";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A99DocDicionarioSensivel)), "false") == 0 )
                  {
                     AV24SelectedText = "false";
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
            }
            else
            {
               if ( ! (0==AV29DocDicionarioId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DocDicionarioId), 8, 0));
                  /* Using cursor P002X7 */
                  pr_default.execute(5, new Object[] {AV29DocDicionarioId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A98DocDicionarioId = P002X7_A98DocDicionarioId[0];
                     A99DocDicionarioSensivel = P002X7_A99DocDicionarioSensivel[0];
                     if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A99DocDicionarioSensivel)), "true") == 0 )
                     {
                        AV24SelectedText = "true";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A99DocDicionarioSensivel)), "false") == 0 )
                     {
                        AV24SelectedText = "false";
                     }
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
         A67CompartTercExternoNome = "";
         P002X2_A67CompartTercExternoNome = new string[] {""} ;
         P002X2_A66CompartTercExternoId = new int[1] ;
         AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV17Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P002X3_A98DocDicionarioId = new int[1] ;
         P002X3_A66CompartTercExternoId = new int[1] ;
         P002X3_A67CompartTercExternoNome = new string[] {""} ;
         P002X4_A66CompartTercExternoId = new int[1] ;
         P002X4_A67CompartTercExternoNome = new string[] {""} ;
         P002X5_A98DocDicionarioId = new int[1] ;
         P002X5_A99DocDicionarioSensivel = new bool[] {false} ;
         P002X6_A98DocDicionarioId = new int[1] ;
         P002X6_A66CompartTercExternoId = new int[1] ;
         P002X6_A99DocDicionarioSensivel = new bool[] {false} ;
         P002X7_A98DocDicionarioId = new int[1] ;
         P002X7_A99DocDicionarioSensivel = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariocomparttercextloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002X2_A67CompartTercExternoNome, P002X2_A66CompartTercExternoId
               }
               , new Object[] {
               P002X3_A98DocDicionarioId, P002X3_A66CompartTercExternoId, P002X3_A67CompartTercExternoNome
               }
               , new Object[] {
               P002X4_A66CompartTercExternoId, P002X4_A67CompartTercExternoNome
               }
               , new Object[] {
               P002X5_A98DocDicionarioId, P002X5_A99DocDicionarioSensivel
               }
               , new Object[] {
               P002X6_A98DocDicionarioId, P002X6_A66CompartTercExternoId, P002X6_A99DocDicionarioSensivel
               }
               , new Object[] {
               P002X7_A98DocDicionarioId, P002X7_A99DocDicionarioSensivel
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV28CompartTercExternoId ;
      private int AV29DocDicionarioId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A66CompartTercExternoId ;
      private int A98DocDicionarioId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private string AV22TrnMode ;
      private string scmdbuf ;
      private bool AV25IsDynamicCall ;
      private bool returnInSub ;
      private bool A99DocDicionarioSensivel ;
      private string AV13Combo_DataJson ;
      private string AV20ComboName ;
      private string AV14SearchTxtParms ;
      private string AV19SelectedValue ;
      private string AV24SelectedText ;
      private string AV12SearchTxt ;
      private string lV12SearchTxt ;
      private string A67CompartTercExternoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002X2_A67CompartTercExternoNome ;
      private int[] P002X2_A66CompartTercExternoId ;
      private int[] P002X3_A98DocDicionarioId ;
      private int[] P002X3_A66CompartTercExternoId ;
      private string[] P002X3_A67CompartTercExternoNome ;
      private int[] P002X4_A66CompartTercExternoId ;
      private string[] P002X4_A67CompartTercExternoNome ;
      private int[] P002X5_A98DocDicionarioId ;
      private bool[] P002X5_A99DocDicionarioSensivel ;
      private int[] P002X6_A98DocDicionarioId ;
      private int[] P002X6_A66CompartTercExternoId ;
      private bool[] P002X6_A99DocDicionarioSensivel ;
      private int[] P002X7_A98DocDicionarioId ;
      private bool[] P002X7_A99DocDicionarioSensivel ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV18Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class dicionariocomparttercextloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002X2( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A67CompartTercExternoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CompartTercExternoNome], [CompartTercExternoId]";
         sFromString = " FROM [CompartTercExterno]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([CompartTercExternoNome] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY [CompartTercExternoNome]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP002X3;
          prmP002X3 = new Object[] {
          new ParDef("@AV28CompartTercExternoId",GXType.Int32,8,0) ,
          new ParDef("@AV29DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP002X4;
          prmP002X4 = new Object[] {
          new ParDef("@AV28CompartTercExternoId",GXType.Int32,8,0)
          };
          Object[] prmP002X5;
          prmP002X5 = new Object[] {
          new ParDef("@GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP002X6;
          prmP002X6 = new Object[] {
          new ParDef("@AV28CompartTercExternoId",GXType.Int32,8,0) ,
          new ParDef("@AV29DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP002X7;
          prmP002X7 = new Object[] {
          new ParDef("@AV29DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP002X2;
          prmP002X2 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002X3", "SELECT T1.[DocDicionarioId], T1.[CompartTercExternoId], T2.[CompartTercExternoNome] FROM ([DicionarioCompartTercExt] T1 INNER JOIN [CompartTercExterno] T2 ON T2.[CompartTercExternoId] = T1.[CompartTercExternoId]) WHERE T1.[CompartTercExternoId] = @AV28CompartTercExternoId and T1.[DocDicionarioId] = @AV29DocDicionarioId ORDER BY T1.[CompartTercExternoId], T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002X4", "SELECT TOP 1 [CompartTercExternoId], [CompartTercExternoNome] FROM [CompartTercExterno] WHERE [CompartTercExternoId] = @AV28CompartTercExternoId ORDER BY [CompartTercExternoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002X5", "SELECT [DocDicionarioId], [DocDicionarioSensivel] FROM [DocDicionario] ORDER BY [DocDicionarioSensivel]  OFFSET @GXPagingFrom5 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo5 > 0 THEN @GXPagingTo5 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002X6", "SELECT T1.[DocDicionarioId], T1.[CompartTercExternoId], T2.[DocDicionarioSensivel] FROM ([DicionarioCompartTercExt] T1 INNER JOIN [DocDicionario] T2 ON T2.[DocDicionarioId] = T1.[DocDicionarioId]) WHERE T1.[CompartTercExternoId] = @AV28CompartTercExternoId and T1.[DocDicionarioId] = @AV29DocDicionarioId ORDER BY T1.[CompartTercExternoId], T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002X7", "SELECT TOP 1 [DocDicionarioId], [DocDicionarioSensivel] FROM [DocDicionario] WHERE [DocDicionarioId] = @AV29DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X7,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.dicionariocomparttercextloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class dicionariocomparttercextloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "DicionarioCompartTercExtLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string CompartTercExternoId ,
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
          permissionPrefix = "dicionariocomparttercext_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("dicionariocomparttercextloaddvcombo") )
          {
             return  ;
          }
          dicionariocomparttercextloaddvcombo worker = new dicionariocomparttercextloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          int gxrCompartTercExternoId = 0;
          gxrCompartTercExternoId = (int)(NumberUtil.Val( (string)(CompartTercExternoId), "."));
          int gxrDocDicionarioId = 0;
          gxrDocDicionarioId = (int)(NumberUtil.Val( (string)(DocDicionarioId), "."));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrCompartTercExternoId,gxrDocDicionarioId,SearchTxtParms,out SelectedValue,out SelectedText,out Combo_DataJson );
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
