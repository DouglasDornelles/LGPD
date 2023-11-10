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
   public class dicionariopaisloaddvcombo : GXProcedure
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
            return "dicionariopais_Services_Execute" ;
         }

      }

      public dicionariopaisloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariopaisloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_PaisId ,
                           int aP4_DocDicionarioId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV20ComboName = aP0_ComboName;
         this.AV22TrnMode = aP1_TrnMode;
         this.AV25IsDynamicCall = aP2_IsDynamicCall;
         this.AV27PaisId = aP3_PaisId;
         this.AV28DocDicionarioId = aP4_DocDicionarioId;
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
                                int aP3_PaisId ,
                                int aP4_DocDicionarioId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_PaisId, aP4_DocDicionarioId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV13Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_PaisId ,
                                 int aP4_DocDicionarioId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         dicionariopaisloaddvcombo objdicionariopaisloaddvcombo;
         objdicionariopaisloaddvcombo = new dicionariopaisloaddvcombo();
         objdicionariopaisloaddvcombo.AV20ComboName = aP0_ComboName;
         objdicionariopaisloaddvcombo.AV22TrnMode = aP1_TrnMode;
         objdicionariopaisloaddvcombo.AV25IsDynamicCall = aP2_IsDynamicCall;
         objdicionariopaisloaddvcombo.AV27PaisId = aP3_PaisId;
         objdicionariopaisloaddvcombo.AV28DocDicionarioId = aP4_DocDicionarioId;
         objdicionariopaisloaddvcombo.AV14SearchTxtParms = aP5_SearchTxtParms;
         objdicionariopaisloaddvcombo.AV19SelectedValue = "" ;
         objdicionariopaisloaddvcombo.AV24SelectedText = "" ;
         objdicionariopaisloaddvcombo.AV13Combo_DataJson = "" ;
         objdicionariopaisloaddvcombo.context.SetSubmitInitialConfig(context);
         objdicionariopaisloaddvcombo.initialize();
         Submit( executePrivateCatch,objdicionariopaisloaddvcombo);
         aP6_SelectedValue=this.AV19SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV13Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariopaisloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV20ComboName, "PaisId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PAISID' */
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
         /* 'LOADCOMBOITEMS_PAISID' Routine */
         returnInSub = false;
         if ( AV25IsDynamicCall )
         {
            GXPagingFrom2 = AV15SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12SearchTxt ,
                                                 A5PaisNome } ,
                                                 new int[]{
                                                 }
            });
            lV12SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV12SearchTxt), "%", "");
            /* Using cursor P00772 */
            pr_default.execute(0, new Object[] {lV12SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A5PaisNome = P00772_A5PaisNome[0];
               A4PaisId = P00772_A4PaisId[0];
               AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV18Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A4PaisId), 8, 0));
               AV18Combo_DataItem.gxTpr_Title = A5PaisNome;
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
               /* Using cursor P00773 */
               pr_default.execute(1, new Object[] {AV27PaisId, AV28DocDicionarioId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A98DocDicionarioId = P00773_A98DocDicionarioId[0];
                  A4PaisId = P00773_A4PaisId[0];
                  A5PaisNome = P00773_A5PaisNome[0];
                  A5PaisNome = P00773_A5PaisNome[0];
                  AV19SelectedValue = ((0==A4PaisId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A4PaisId), 8, 0)));
                  AV24SelectedText = A5PaisNome;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV27PaisId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27PaisId), 8, 0));
                  /* Using cursor P00774 */
                  pr_default.execute(2, new Object[] {AV27PaisId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A4PaisId = P00774_A4PaisId[0];
                     A5PaisNome = P00774_A5PaisNome[0];
                     AV24SelectedText = A5PaisNome;
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
            /* Using cursor P00775 */
            pr_default.execute(3, new Object[] {GXPagingFrom5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A98DocDicionarioId = P00775_A98DocDicionarioId[0];
               A99DocDicionarioSensivel = P00775_A99DocDicionarioSensivel[0];
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
               /* Using cursor P00776 */
               pr_default.execute(4, new Object[] {AV27PaisId, AV28DocDicionarioId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A98DocDicionarioId = P00776_A98DocDicionarioId[0];
                  A4PaisId = P00776_A4PaisId[0];
                  A99DocDicionarioSensivel = P00776_A99DocDicionarioSensivel[0];
                  A99DocDicionarioSensivel = P00776_A99DocDicionarioSensivel[0];
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
               if ( ! (0==AV28DocDicionarioId) )
               {
                  AV19SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DocDicionarioId), 8, 0));
                  /* Using cursor P00777 */
                  pr_default.execute(5, new Object[] {AV28DocDicionarioId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A98DocDicionarioId = P00777_A98DocDicionarioId[0];
                     A99DocDicionarioSensivel = P00777_A99DocDicionarioSensivel[0];
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
         A5PaisNome = "";
         P00772_A5PaisNome = new string[] {""} ;
         P00772_A4PaisId = new int[1] ;
         AV18Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV17Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00773_A98DocDicionarioId = new int[1] ;
         P00773_A4PaisId = new int[1] ;
         P00773_A5PaisNome = new string[] {""} ;
         P00774_A4PaisId = new int[1] ;
         P00774_A5PaisNome = new string[] {""} ;
         P00775_A98DocDicionarioId = new int[1] ;
         P00775_A99DocDicionarioSensivel = new bool[] {false} ;
         P00776_A98DocDicionarioId = new int[1] ;
         P00776_A4PaisId = new int[1] ;
         P00776_A99DocDicionarioSensivel = new bool[] {false} ;
         P00777_A98DocDicionarioId = new int[1] ;
         P00777_A99DocDicionarioSensivel = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariopaisloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00772_A5PaisNome, P00772_A4PaisId
               }
               , new Object[] {
               P00773_A98DocDicionarioId, P00773_A4PaisId, P00773_A5PaisNome
               }
               , new Object[] {
               P00774_A4PaisId, P00774_A5PaisNome
               }
               , new Object[] {
               P00775_A98DocDicionarioId, P00775_A99DocDicionarioSensivel
               }
               , new Object[] {
               P00776_A98DocDicionarioId, P00776_A4PaisId, P00776_A99DocDicionarioSensivel
               }
               , new Object[] {
               P00777_A98DocDicionarioId, P00777_A99DocDicionarioSensivel
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV27PaisId ;
      private int AV28DocDicionarioId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4PaisId ;
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
      private string A5PaisNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00772_A5PaisNome ;
      private int[] P00772_A4PaisId ;
      private int[] P00773_A98DocDicionarioId ;
      private int[] P00773_A4PaisId ;
      private string[] P00773_A5PaisNome ;
      private int[] P00774_A4PaisId ;
      private string[] P00774_A5PaisNome ;
      private int[] P00775_A98DocDicionarioId ;
      private bool[] P00775_A99DocDicionarioSensivel ;
      private int[] P00776_A98DocDicionarioId ;
      private int[] P00776_A4PaisId ;
      private bool[] P00776_A99DocDicionarioSensivel ;
      private int[] P00777_A98DocDicionarioId ;
      private bool[] P00777_A99DocDicionarioSensivel ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV18Combo_DataItem ;
   }

   public class dicionariopaisloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00772( IGxContext context ,
                                             string AV12SearchTxt ,
                                             string A5PaisNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PaisNome], [PaisId]";
         sFromString = " FROM [Pais]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) )
         {
            AddWhere(sWhereString, "([PaisNome] like '%' + @lV12SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY [PaisNome]";
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
                     return conditional_P00772(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00773;
          prmP00773 = new Object[] {
          new ParDef("@AV27PaisId",GXType.Int32,8,0) ,
          new ParDef("@AV28DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP00774;
          prmP00774 = new Object[] {
          new ParDef("@AV27PaisId",GXType.Int32,8,0)
          };
          Object[] prmP00775;
          prmP00775 = new Object[] {
          new ParDef("@GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP00776;
          prmP00776 = new Object[] {
          new ParDef("@AV27PaisId",GXType.Int32,8,0) ,
          new ParDef("@AV28DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP00777;
          prmP00777 = new Object[] {
          new ParDef("@AV28DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP00772;
          prmP00772 = new Object[] {
          new ParDef("@lV12SearchTxt",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00772", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00772,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00773", "SELECT T1.[DocDicionarioId], T1.[PaisId], T2.[PaisNome] FROM ([DicionarioPais] T1 INNER JOIN [Pais] T2 ON T2.[PaisId] = T1.[PaisId]) WHERE T1.[PaisId] = @AV27PaisId and T1.[DocDicionarioId] = @AV28DocDicionarioId ORDER BY T1.[PaisId], T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00773,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00774", "SELECT TOP 1 [PaisId], [PaisNome] FROM [Pais] WHERE [PaisId] = @AV27PaisId ORDER BY [PaisId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00774,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00775", "SELECT [DocDicionarioId], [DocDicionarioSensivel] FROM [DocDicionario] ORDER BY [DocDicionarioSensivel]  OFFSET @GXPagingFrom5 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo5 > 0 THEN @GXPagingTo5 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00775,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00776", "SELECT T1.[DocDicionarioId], T1.[PaisId], T2.[DocDicionarioSensivel] FROM ([DicionarioPais] T1 INNER JOIN [DocDicionario] T2 ON T2.[DocDicionarioId] = T1.[DocDicionarioId]) WHERE T1.[PaisId] = @AV27PaisId and T1.[DocDicionarioId] = @AV28DocDicionarioId ORDER BY T1.[PaisId], T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00776,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00777", "SELECT TOP 1 [DocDicionarioId], [DocDicionarioSensivel] FROM [DocDicionario] WHERE [DocDicionarioId] = @AV28DocDicionarioId ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00777,1, GxCacheFrequency.OFF ,false,true )
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

 [ServiceContract(Namespace = "GeneXus.Programs.dicionariopaisloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class dicionariopaisloaddvcombo_services : GxRestService
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

    [OperationContract(Name = "DicionarioPaisLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string PaisId ,
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
          permissionPrefix = "dicionariopais_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("dicionariopaisloaddvcombo") )
          {
             return  ;
          }
          dicionariopaisloaddvcombo worker = new dicionariopaisloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          int gxrPaisId = 0;
          gxrPaisId = (int)(NumberUtil.Val( (string)(PaisId), "."));
          int gxrDocDicionarioId = 0;
          gxrDocDicionarioId = (int)(NumberUtil.Val( (string)(DocDicionarioId), "."));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrPaisId,gxrDocDicionarioId,SearchTxtParms,out SelectedValue,out SelectedText,out Combo_DataJson );
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
