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
   public class tipodadowwexport : GXProcedure
   {
      public tipodadowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tipodadowwexport( IGxContext context )
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
         tipodadowwexport objtipodadowwexport;
         objtipodadowwexport = new tipodadowwexport();
         objtipodadowwexport.AV12Filename = "" ;
         objtipodadowwexport.AV13ErrorMessage = "" ;
         objtipodadowwexport.context.SetSubmitInitialConfig(context);
         objtipodadowwexport.initialize();
         Submit( executePrivateCatch,objtipodadowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipodadowwexport)stateInfo).executePrivate();
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
         AV12Filename = "TipoDadoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( 1 == 2 )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Filtro principal") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoDadoNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoDadoNome_Sel)) ? "(Vazio)" : AV38TFTipoDadoNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipoDadoNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipoDadoNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( ! ( (0==AV39TFTipoDadoAtivo_Sel) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Ativo?") ;
               AV14CellRow = GXt_int1;
               if ( AV39TFTipoDadoAtivo_Sel == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
               }
               else if ( AV39TFTipoDadoAtivo_Sel == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
               }
            }
            AV14CellRow = (int)(AV14CellRow+2);
         }
         else
         {
            AV41IsOk = false;
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Filtro principal") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV41IsOk = true;
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoDadoNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoDadoNome_Sel)) ? "(Vazio)" : AV38TFTipoDadoNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV41IsOk = true;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipoDadoNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipoDadoNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  AV41IsOk = true;
               }
            }
            if ( ! ( (0==AV39TFTipoDadoAtivo_Sel) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Ativo?") ;
               AV14CellRow = GXt_int1;
               if ( AV39TFTipoDadoAtivo_Sel == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
               }
               else if ( AV39TFTipoDadoAtivo_Sel == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
               }
               AV41IsOk = true;
            }
            if ( AV41IsOk )
            {
               AV14CellRow = (int)(AV14CellRow+2);
            }
         }
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("TipoDadoWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("TipoDadoWWColumnsSelector");
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
         AV46Tipodadowwds_1_filterfulltext = AV19FilterFullText;
         AV47Tipodadowwds_2_tftipodadonome = AV37TFTipoDadoNome;
         AV48Tipodadowwds_3_tftipodadonome_sel = AV38TFTipoDadoNome_Sel;
         AV49Tipodadowwds_4_tftipodadoativo_sel = AV39TFTipoDadoAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Tipodadowwds_1_filterfulltext ,
                                              AV48Tipodadowwds_3_tftipodadonome_sel ,
                                              AV47Tipodadowwds_2_tftipodadonome ,
                                              AV49Tipodadowwds_4_tftipodadoativo_sel ,
                                              A31TipoDadoNome ,
                                              A32TipoDadoAtivo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV46Tipodadowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Tipodadowwds_1_filterfulltext), "%", "");
         lV46Tipodadowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Tipodadowwds_1_filterfulltext), "%", "");
         lV46Tipodadowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Tipodadowwds_1_filterfulltext), "%", "");
         lV47Tipodadowwds_2_tftipodadonome = StringUtil.Concat( StringUtil.RTrim( AV47Tipodadowwds_2_tftipodadonome), "%", "");
         /* Using cursor P003O2 */
         pr_default.execute(0, new Object[] {lV46Tipodadowwds_1_filterfulltext, lV46Tipodadowwds_1_filterfulltext, lV46Tipodadowwds_1_filterfulltext, lV47Tipodadowwds_2_tftipodadonome, AV48Tipodadowwds_3_tftipodadonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A32TipoDadoAtivo = P003O2_A32TipoDadoAtivo[0];
            A31TipoDadoNome = P003O2_A31TipoDadoNome[0];
            A30TipoDadoId = P003O2_A30TipoDadoId[0];
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
            AV50GXV2 = 1;
            while ( AV50GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV50GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TipoDadoNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A31TipoDadoNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TipoDadoAtivo") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A32TipoDadoAtivo)), "true") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "SIM";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A32TipoDadoAtivo)), "false") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "N�O";
                     }
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV50GXV2 = (int)(AV50GXV2+1);
            }
            if ( A32TipoDadoAtivo )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV32VisibleColumnCount)).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( ! A32TipoDadoAtivo )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV32VisibleColumnCount)).Color = GXUtil.RGB( 221, 75, 57);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TipoDadoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TipoDadoAtivo",  "",  "Ativo?",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "TipoDadoWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("TipoDadoWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoDadoWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("TipoDadoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV51GXV3 = 1;
         while ( AV51GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV51GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPODADONOME") == 0 )
            {
               AV37TFTipoDadoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPODADONOME_SEL") == 0 )
            {
               AV38TFTipoDadoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPODADOATIVO_SEL") == 0 )
            {
               AV39TFTipoDadoAtivo_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            AV51GXV3 = (int)(AV51GXV3+1);
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
         AV38TFTipoDadoNome_Sel = "";
         AV37TFTipoDadoNome = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV46Tipodadowwds_1_filterfulltext = "";
         AV47Tipodadowwds_2_tftipodadonome = "";
         AV48Tipodadowwds_3_tftipodadonome_sel = "";
         scmdbuf = "";
         lV46Tipodadowwds_1_filterfulltext = "";
         lV47Tipodadowwds_2_tftipodadonome = "";
         A31TipoDadoNome = "";
         P003O2_A32TipoDadoAtivo = new bool[] {false} ;
         P003O2_A31TipoDadoNome = new string[] {""} ;
         P003O2_A30TipoDadoId = new int[1] ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipodadowwexport__default(),
            new Object[][] {
                new Object[] {
               P003O2_A32TipoDadoAtivo, P003O2_A31TipoDadoNome, P003O2_A30TipoDadoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39TFTipoDadoAtivo_Sel ;
      private short GXt_int1 ;
      private short AV49Tipodadowwds_4_tftipodadoativo_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV44GXV1 ;
      private int A30TipoDadoId ;
      private int AV50GXV2 ;
      private int AV51GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV41IsOk ;
      private bool A32TipoDadoAtivo ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFTipoDadoNome_Sel ;
      private string AV37TFTipoDadoNome ;
      private string AV46Tipodadowwds_1_filterfulltext ;
      private string AV47Tipodadowwds_2_tftipodadonome ;
      private string AV48Tipodadowwds_3_tftipodadonome_sel ;
      private string lV46Tipodadowwds_1_filterfulltext ;
      private string lV47Tipodadowwds_2_tftipodadonome ;
      private string A31TipoDadoNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P003O2_A32TipoDadoAtivo ;
      private string[] P003O2_A31TipoDadoNome ;
      private int[] P003O2_A30TipoDadoId ;
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

   public class tipodadowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003O2( IGxContext context ,
                                             string AV46Tipodadowwds_1_filterfulltext ,
                                             string AV48Tipodadowwds_3_tftipodadonome_sel ,
                                             string AV47Tipodadowwds_2_tftipodadonome ,
                                             short AV49Tipodadowwds_4_tftipodadoativo_sel ,
                                             string A31TipoDadoNome ,
                                             bool A32TipoDadoAtivo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipoDadoAtivo], [TipoDadoNome], [TipoDadoId] FROM [TipoDado]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Tipodadowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [TipoDadoNome] like '%' + @lV46Tipodadowwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV46Tipodadowwds_1_filterfulltext) and [TipoDadoAtivo] = 1) or ( 'n�o' like '%' + LOWER(@lV46Tipodadowwds_1_filterfulltext) and [TipoDadoAtivo] = 0))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Tipodadowwds_3_tftipodadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Tipodadowwds_2_tftipodadonome)) ) )
         {
            AddWhere(sWhereString, "([TipoDadoNome] like @lV47Tipodadowwds_2_tftipodadonome)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Tipodadowwds_3_tftipodadonome_sel)) && ! ( StringUtil.StrCmp(AV48Tipodadowwds_3_tftipodadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TipoDadoNome] = @AV48Tipodadowwds_3_tftipodadonome_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48Tipodadowwds_3_tftipodadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TipoDadoNome] = ''))");
         }
         if ( AV49Tipodadowwds_4_tftipodadoativo_sel == 1 )
         {
            AddWhere(sWhereString, "([TipoDadoAtivo] = 1)");
         }
         if ( AV49Tipodadowwds_4_tftipodadoativo_sel == 2 )
         {
            AddWhere(sWhereString, "([TipoDadoAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoDadoNome]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoDadoNome] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoDadoAtivo]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoDadoAtivo] DESC";
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
                     return conditional_P003O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP003O2;
          prmP003O2 = new Object[] {
          new ParDef("@lV46Tipodadowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV46Tipodadowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Tipodadowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV47Tipodadowwds_2_tftipodadonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV48Tipodadowwds_3_tftipodadonome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
