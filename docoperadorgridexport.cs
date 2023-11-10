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
   public class docoperadorgridexport : GXProcedure
   {
      public docoperadorgridexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docoperadorgridexport( IGxContext context )
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
         docoperadorgridexport objdocoperadorgridexport;
         objdocoperadorgridexport = new docoperadorgridexport();
         objdocoperadorgridexport.AV12Filename = "" ;
         objdocoperadorgridexport.AV13ErrorMessage = "" ;
         objdocoperadorgridexport.context.SetSubmitInitialConfig(context);
         objdocoperadorgridexport.initialize();
         Submit( executePrivateCatch,objdocoperadorgridexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docoperadorgridexport)stateInfo).executePrivate();
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
         AV12Filename = "DocOperadorGridExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFDocOperadorId) && (0==AV36TFDocOperadorId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Operador Id") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFDocOperadorId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFDocOperadorId_To;
         }
         if ( ! ( (0==AV37TFDocumentoId) && (0==AV38TFDocumentoId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "do Documento") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV37TFDocumentoId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV38TFDocumentoId_To;
         }
         if ( ! ( (0==AV39TFOperadorId) && (0==AV40TFOperadorId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "do Operador") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV39TFOperadorId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV40TFOperadorId_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("DocOperadorGridColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("DocOperadorGridColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV44GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV46Docoperadorgridds_1_filterfulltext = AV19FilterFullText;
         AV47Docoperadorgridds_2_tfdocoperadorid = AV35TFDocOperadorId;
         AV48Docoperadorgridds_3_tfdocoperadorid_to = AV36TFDocOperadorId_To;
         AV49Docoperadorgridds_4_tfdocumentoid = AV37TFDocumentoId;
         AV50Docoperadorgridds_5_tfdocumentoid_to = AV38TFDocumentoId_To;
         AV51Docoperadorgridds_6_tfoperadorid = AV39TFOperadorId;
         AV52Docoperadorgridds_7_tfoperadorid_to = AV40TFOperadorId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Docoperadorgridds_1_filterfulltext ,
                                              AV47Docoperadorgridds_2_tfdocoperadorid ,
                                              AV48Docoperadorgridds_3_tfdocoperadorid_to ,
                                              AV49Docoperadorgridds_4_tfdocumentoid ,
                                              AV50Docoperadorgridds_5_tfdocumentoid_to ,
                                              AV51Docoperadorgridds_6_tfoperadorid ,
                                              AV52Docoperadorgridds_7_tfoperadorid_to ,
                                              A86DocOperadorId ,
                                              A75DocumentoId ,
                                              A42OperadorId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV46Docoperadorgridds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Docoperadorgridds_1_filterfulltext), "%", "");
         lV46Docoperadorgridds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Docoperadorgridds_1_filterfulltext), "%", "");
         lV46Docoperadorgridds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Docoperadorgridds_1_filterfulltext), "%", "");
         /* Using cursor P005F2 */
         pr_default.execute(0, new Object[] {lV46Docoperadorgridds_1_filterfulltext, lV46Docoperadorgridds_1_filterfulltext, lV46Docoperadorgridds_1_filterfulltext, AV47Docoperadorgridds_2_tfdocoperadorid, AV48Docoperadorgridds_3_tfdocoperadorid_to, AV49Docoperadorgridds_4_tfdocumentoid, AV50Docoperadorgridds_5_tfdocumentoid_to, AV51Docoperadorgridds_6_tfoperadorid, AV52Docoperadorgridds_7_tfoperadorid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A42OperadorId = P005F2_A42OperadorId[0];
            A75DocumentoId = P005F2_A75DocumentoId[0];
            A86DocOperadorId = P005F2_A86DocOperadorId[0];
            A87DocOperadorColeta = P005F2_A87DocOperadorColeta[0];
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
            AV53GXV2 = 1;
            while ( AV53GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV53GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A86DocOperadorId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocumentoId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A75DocumentoId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "OperadorId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A42OperadorId;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV53GXV2 = (int)(AV53GXV2+1);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorId",  "",  "Operador Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocumentoId",  "",  "do Documento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "OperadorId",  "",  "do Operador",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocOperadorGridColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("DocOperadorGridGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocOperadorGridGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("DocOperadorGridGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV54GXV3 = 1;
         while ( AV54GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV54GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORID") == 0 )
            {
               AV35TFDocOperadorId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV36TFDocOperadorId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV37TFDocumentoId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV38TFDocumentoId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFOPERADORID") == 0 )
            {
               AV39TFOperadorId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV40TFOperadorId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV54GXV3 = (int)(AV54GXV3+1);
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
         AV46Docoperadorgridds_1_filterfulltext = "";
         scmdbuf = "";
         lV46Docoperadorgridds_1_filterfulltext = "";
         P005F2_A42OperadorId = new int[1] ;
         P005F2_A75DocumentoId = new int[1] ;
         P005F2_A86DocOperadorId = new int[1] ;
         P005F2_A87DocOperadorColeta = new bool[] {false} ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperadorgridexport__default(),
            new Object[][] {
                new Object[] {
               P005F2_A42OperadorId, P005F2_A75DocumentoId, P005F2_A86DocOperadorId, P005F2_A87DocOperadorColeta
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
      private int AV35TFDocOperadorId ;
      private int AV36TFDocOperadorId_To ;
      private int AV37TFDocumentoId ;
      private int AV38TFDocumentoId_To ;
      private int AV39TFOperadorId ;
      private int AV40TFOperadorId_To ;
      private int AV44GXV1 ;
      private int AV47Docoperadorgridds_2_tfdocoperadorid ;
      private int AV48Docoperadorgridds_3_tfdocoperadorid_to ;
      private int AV49Docoperadorgridds_4_tfdocumentoid ;
      private int AV50Docoperadorgridds_5_tfdocumentoid_to ;
      private int AV51Docoperadorgridds_6_tfoperadorid ;
      private int AV52Docoperadorgridds_7_tfoperadorid_to ;
      private int A86DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int AV53GXV2 ;
      private int AV54GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool A87DocOperadorColeta ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV46Docoperadorgridds_1_filterfulltext ;
      private string lV46Docoperadorgridds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005F2_A42OperadorId ;
      private int[] P005F2_A75DocumentoId ;
      private int[] P005F2_A86DocOperadorId ;
      private bool[] P005F2_A87DocOperadorColeta ;
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

   public class docoperadorgridexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005F2( IGxContext context ,
                                             string AV46Docoperadorgridds_1_filterfulltext ,
                                             int AV47Docoperadorgridds_2_tfdocoperadorid ,
                                             int AV48Docoperadorgridds_3_tfdocoperadorid_to ,
                                             int AV49Docoperadorgridds_4_tfdocumentoid ,
                                             int AV50Docoperadorgridds_5_tfdocumentoid_to ,
                                             int AV51Docoperadorgridds_6_tfoperadorid ,
                                             int AV52Docoperadorgridds_7_tfoperadorid_to ,
                                             int A86DocOperadorId ,
                                             int A75DocumentoId ,
                                             int A42OperadorId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [OperadorId], [DocumentoId], [DocOperadorId], [DocOperadorColeta] FROM [DocOperador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Docoperadorgridds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([DocOperadorId] AS decimal(8,0))) like '%' + @lV46Docoperadorgridds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV46Docoperadorgridds_1_filterfulltext) or ( CONVERT( char(8), CAST([OperadorId] AS decimal(8,0))) like '%' + @lV46Docoperadorgridds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV47Docoperadorgridds_2_tfdocoperadorid) )
         {
            AddWhere(sWhereString, "([DocOperadorId] >= @AV47Docoperadorgridds_2_tfdocoperadorid)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV48Docoperadorgridds_3_tfdocoperadorid_to) )
         {
            AddWhere(sWhereString, "([DocOperadorId] <= @AV48Docoperadorgridds_3_tfdocoperadorid_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV49Docoperadorgridds_4_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV49Docoperadorgridds_4_tfdocumentoid)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV50Docoperadorgridds_5_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV50Docoperadorgridds_5_tfdocumentoid_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV51Docoperadorgridds_6_tfoperadorid) )
         {
            AddWhere(sWhereString, "([OperadorId] >= @AV51Docoperadorgridds_6_tfoperadorid)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV52Docoperadorgridds_7_tfoperadorid_to) )
         {
            AddWhere(sWhereString, "([OperadorId] <= @AV52Docoperadorgridds_7_tfoperadorid_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [DocOperadorColeta]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentoId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocumentoId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperadorId]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperadorId] DESC";
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
                     return conditional_P005F2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] );
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
          Object[] prmP005F2;
          prmP005F2 = new Object[] {
          new ParDef("@lV46Docoperadorgridds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Docoperadorgridds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Docoperadorgridds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV47Docoperadorgridds_2_tfdocoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV48Docoperadorgridds_3_tfdocoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV49Docoperadorgridds_4_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV50Docoperadorgridds_5_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV51Docoperadorgridds_6_tfoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV52Docoperadorgridds_7_tfoperadorid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                return;
       }
    }

 }

}
