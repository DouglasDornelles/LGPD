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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class dicionariocomparttercextwwexport : GXProcedure
   {
      public dicionariocomparttercextwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public dicionariocomparttercextwwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         dicionariocomparttercextwwexport objdicionariocomparttercextwwexport;
         objdicionariocomparttercextwwexport = new dicionariocomparttercextwwexport();
         objdicionariocomparttercextwwexport.AV12Filename = "" ;
         objdicionariocomparttercextwwexport.AV13ErrorMessage = "" ;
         objdicionariocomparttercextwwexport.context.SetSubmitInitialConfig(context);
         objdicionariocomparttercextwwexport.initialize();
         Submit( executePrivateCatch,objdicionariocomparttercextwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dicionariocomparttercextwwexport)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV16Random = (int)(NumberUtil.Random( )*10000);
         AV12Filename = "DicionarioCompartTercExtWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Filtro principal") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( ! ( (0==AV35TFCompartTercExternoId) && (0==AV36TFCompartTercExternoId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Terceiros Externos") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFCompartTercExternoId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFCompartTercExternoId_To;
         }
         if ( ! ( (0==AV37TFDocDicionarioId) && (0==AV38TFDocDicionarioId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Dicionario Id") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV37TFDocDicionarioId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV38TFDocDicionarioId_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("DicionarioCompartTercExtWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("DicionarioCompartTercExtWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV42GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV44Dicionariocomparttercextwwds_1_filterfulltext = AV19FilterFullText;
         AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid = AV35TFCompartTercExternoId;
         AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to = AV36TFCompartTercExternoId_To;
         AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid = AV37TFDocDicionarioId;
         AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to = AV38TFDocDicionarioId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Dicionariocomparttercextwwds_1_filterfulltext ,
                                              AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid ,
                                              AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to ,
                                              AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid ,
                                              AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to ,
                                              A66CompartTercExternoId ,
                                              A98DocDicionarioId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV44Dicionariocomparttercextwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Dicionariocomparttercextwwds_1_filterfulltext), "%", "");
         lV44Dicionariocomparttercextwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Dicionariocomparttercextwwds_1_filterfulltext), "%", "");
         /* Using cursor P005V2 */
         pr_default.execute(0, new Object[] {lV44Dicionariocomparttercextwwds_1_filterfulltext, lV44Dicionariocomparttercextwwds_1_filterfulltext, AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid, AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to, AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid, AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A98DocDicionarioId = P005V2_A98DocDicionarioId[0];
            A66CompartTercExternoId = P005V2_A66CompartTercExternoId[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV32VisibleColumnCount = 0;
            AV49GXV2 = 1;
            while ( AV49GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV49GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "CompartTercExternoId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A66CompartTercExternoId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A98DocDicionarioId;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV49GXV2 = (int)(AV49GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "CompartTercExternoId",  "",  "Terceiros Externos",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioId",  "",  "Dicionario Id",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DicionarioCompartTercExtWWColumnsSelector", out  GXt_char2) ;
         AV28UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("DicionarioCompartTercExtWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DicionarioCompartTercExtWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("DicionarioCompartTercExtWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV50GXV3 = 1;
         while ( AV50GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV50GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCOMPARTTERCEXTERNOID") == 0 )
            {
               AV35TFCompartTercExternoId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV36TFCompartTercExternoId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOID") == 0 )
            {
               AV37TFDocDicionarioId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV38TFDocDicionarioId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV50GXV3 = (int)(AV50GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV44Dicionariocomparttercextwwds_1_filterfulltext = "";
         scmdbuf = "";
         lV44Dicionariocomparttercextwwds_1_filterfulltext = "";
         P005V2_A98DocDicionarioId = new int[1] ;
         P005V2_A66CompartTercExternoId = new int[1] ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dicionariocomparttercextwwexport__default(),
            new Object[][] {
                new Object[] {
               P005V2_A98DocDicionarioId, P005V2_A66CompartTercExternoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXt_int1 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV35TFCompartTercExternoId ;
      private int AV36TFCompartTercExternoId_To ;
      private int AV37TFDocDicionarioId ;
      private int AV38TFDocDicionarioId_To ;
      private int AV42GXV1 ;
      private int AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid ;
      private int AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to ;
      private int AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid ;
      private int AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to ;
      private int A66CompartTercExternoId ;
      private int A98DocDicionarioId ;
      private int AV49GXV2 ;
      private int AV50GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV44Dicionariocomparttercextwwds_1_filterfulltext ;
      private string lV44Dicionariocomparttercextwwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005V2_A98DocDicionarioId ;
      private int[] P005V2_A66CompartTercExternoId ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
   }

   public class dicionariocomparttercextwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005V2( IGxContext context ,
                                             string AV44Dicionariocomparttercextwwds_1_filterfulltext ,
                                             int AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid ,
                                             int AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to ,
                                             int AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid ,
                                             int AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to ,
                                             int A66CompartTercExternoId ,
                                             int A98DocDicionarioId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [DocDicionarioId], [CompartTercExternoId] FROM [DicionarioCompartTercExt]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Dicionariocomparttercextwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([CompartTercExternoId] AS decimal(8,0))) like '%' + @lV44Dicionariocomparttercextwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocDicionarioId] AS decimal(8,0))) like '%' + @lV44Dicionariocomparttercextwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid) )
         {
            AddWhere(sWhereString, "([CompartTercExternoId] >= @AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to) )
         {
            AddWhere(sWhereString, "([CompartTercExternoId] <= @AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "([DocDicionarioId] >= @AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "([DocDicionarioId] <= @AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CompartTercExternoId]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CompartTercExternoId] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocDicionarioId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocDicionarioId] DESC";
         }
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
                     return conditional_P005V2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005V2;
          prmP005V2 = new Object[] {
          new ParDef("@lV44Dicionariocomparttercextwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Dicionariocomparttercextwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV45Dicionariocomparttercextwwds_2_tfcomparttercexternoid",GXType.Int32,8,0) ,
          new ParDef("@AV46Dicionariocomparttercextwwds_3_tfcomparttercexternoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV47Dicionariocomparttercextwwds_4_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV48Dicionariocomparttercextwwds_5_tfdocdicionarioid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
