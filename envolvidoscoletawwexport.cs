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
   public class envolvidoscoletawwexport : GXProcedure
   {
      public envolvidoscoletawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public envolvidoscoletawwexport( IGxContext context )
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
         envolvidoscoletawwexport objenvolvidoscoletawwexport;
         objenvolvidoscoletawwexport = new envolvidoscoletawwexport();
         objenvolvidoscoletawwexport.AV12Filename = "" ;
         objenvolvidoscoletawwexport.AV13ErrorMessage = "" ;
         objenvolvidoscoletawwexport.context.SetSubmitInitialConfig(context);
         objenvolvidoscoletawwexport.initialize();
         Submit( executePrivateCatch,objenvolvidoscoletawwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((envolvidoscoletawwexport)stateInfo).executePrivate();
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
         AV12Filename = "EnvolvidosColetaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEnvolvidosColetaNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEnvolvidosColetaNome_Sel)) ? "(Vazio)" : AV38TFEnvolvidosColetaNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEnvolvidosColetaNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFEnvolvidosColetaNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( ! ( (0==AV39TFEnvolvidosColetaAtivo_Sel) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Ativo?") ;
               AV14CellRow = GXt_int1;
               if ( AV39TFEnvolvidosColetaAtivo_Sel == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
               }
               else if ( AV39TFEnvolvidosColetaAtivo_Sel == 2 )
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
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEnvolvidosColetaNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEnvolvidosColetaNome_Sel)) ? "(Vazio)" : AV38TFEnvolvidosColetaNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV41IsOk = true;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEnvolvidosColetaNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFEnvolvidosColetaNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  AV41IsOk = true;
               }
            }
            if ( ! ( (0==AV39TFEnvolvidosColetaAtivo_Sel) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Ativo?") ;
               AV14CellRow = GXt_int1;
               AV41IsOk = true;
               if ( AV39TFEnvolvidosColetaAtivo_Sel == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
               }
               else if ( AV39TFEnvolvidosColetaAtivo_Sel == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
               }
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
         if ( StringUtil.StrCmp(AV20Session.Get("EnvolvidosColetaWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("EnvolvidosColetaWWColumnsSelector");
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
         AV46Envolvidoscoletawwds_1_filterfulltext = AV19FilterFullText;
         AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome = AV37TFEnvolvidosColetaNome;
         AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel = AV38TFEnvolvidosColetaNome_Sel;
         AV49Envolvidoscoletawwds_4_tfenvolvidoscoletaativo_sel = AV39TFEnvolvidosColetaAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Envolvidoscoletawwds_1_filterfulltext ,
                                              AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel ,
                                              AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome ,
                                              AV49Envolvidoscoletawwds_4_tfenvolvidoscoletaativo_sel ,
                                              A55EnvolvidosColetaNome ,
                                              A56EnvolvidosColetaAtivo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV46Envolvidoscoletawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Envolvidoscoletawwds_1_filterfulltext), "%", "");
         lV46Envolvidoscoletawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Envolvidoscoletawwds_1_filterfulltext), "%", "");
         lV46Envolvidoscoletawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Envolvidoscoletawwds_1_filterfulltext), "%", "");
         lV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome = StringUtil.Concat( StringUtil.RTrim( AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome), "%", "");
         /* Using cursor P004C2 */
         pr_default.execute(0, new Object[] {lV46Envolvidoscoletawwds_1_filterfulltext, lV46Envolvidoscoletawwds_1_filterfulltext, lV46Envolvidoscoletawwds_1_filterfulltext, lV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome, AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A56EnvolvidosColetaAtivo = P004C2_A56EnvolvidosColetaAtivo[0];
            A55EnvolvidosColetaNome = P004C2_A55EnvolvidosColetaNome[0];
            A54EnvolvidosColetaId = P004C2_A54EnvolvidosColetaId[0];
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
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EnvolvidosColetaNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A55EnvolvidosColetaNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EnvolvidosColetaAtivo") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A56EnvolvidosColetaAtivo)), "true") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "SIM";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A56EnvolvidosColetaAtivo)), "false") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "N�O";
                     }
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV50GXV2 = (int)(AV50GXV2+1);
            }
            if ( A56EnvolvidosColetaAtivo )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV32VisibleColumnCount)).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( ! A56EnvolvidosColetaAtivo )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EnvolvidosColetaNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EnvolvidosColetaAtivo",  "",  "Ativo?",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "EnvolvidosColetaWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("EnvolvidosColetaWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EnvolvidosColetaWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("EnvolvidosColetaWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFENVOLVIDOSCOLETANOME") == 0 )
            {
               AV37TFEnvolvidosColetaNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFENVOLVIDOSCOLETANOME_SEL") == 0 )
            {
               AV38TFEnvolvidosColetaNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFENVOLVIDOSCOLETAATIVO_SEL") == 0 )
            {
               AV39TFEnvolvidosColetaAtivo_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
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
         AV38TFEnvolvidosColetaNome_Sel = "";
         AV37TFEnvolvidosColetaNome = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV46Envolvidoscoletawwds_1_filterfulltext = "";
         AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome = "";
         AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel = "";
         scmdbuf = "";
         lV46Envolvidoscoletawwds_1_filterfulltext = "";
         lV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome = "";
         A55EnvolvidosColetaNome = "";
         P004C2_A56EnvolvidosColetaAtivo = new bool[] {false} ;
         P004C2_A55EnvolvidosColetaNome = new string[] {""} ;
         P004C2_A54EnvolvidosColetaId = new int[1] ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.envolvidoscoletawwexport__default(),
            new Object[][] {
                new Object[] {
               P004C2_A56EnvolvidosColetaAtivo, P004C2_A55EnvolvidosColetaNome, P004C2_A54EnvolvidosColetaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39TFEnvolvidosColetaAtivo_Sel ;
      private short GXt_int1 ;
      private short AV49Envolvidoscoletawwds_4_tfenvolvidoscoletaativo_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV44GXV1 ;
      private int A54EnvolvidosColetaId ;
      private int AV50GXV2 ;
      private int AV51GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV41IsOk ;
      private bool A56EnvolvidosColetaAtivo ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFEnvolvidosColetaNome_Sel ;
      private string AV37TFEnvolvidosColetaNome ;
      private string AV46Envolvidoscoletawwds_1_filterfulltext ;
      private string AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome ;
      private string AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel ;
      private string lV46Envolvidoscoletawwds_1_filterfulltext ;
      private string lV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome ;
      private string A55EnvolvidosColetaNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P004C2_A56EnvolvidosColetaAtivo ;
      private string[] P004C2_A55EnvolvidosColetaNome ;
      private int[] P004C2_A54EnvolvidosColetaId ;
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

   public class envolvidoscoletawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004C2( IGxContext context ,
                                             string AV46Envolvidoscoletawwds_1_filterfulltext ,
                                             string AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel ,
                                             string AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome ,
                                             short AV49Envolvidoscoletawwds_4_tfenvolvidoscoletaativo_sel ,
                                             string A55EnvolvidosColetaNome ,
                                             bool A56EnvolvidosColetaAtivo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [EnvolvidosColetaAtivo], [EnvolvidosColetaNome], [EnvolvidosColetaId] FROM [EnvolvidosColeta]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Envolvidoscoletawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [EnvolvidosColetaNome] like '%' + @lV46Envolvidoscoletawwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV46Envolvidoscoletawwds_1_filterfulltext) and [EnvolvidosColetaAtivo] = 1) or ( 'n�o' like '%' + LOWER(@lV46Envolvidoscoletawwds_1_filterfulltext) and [EnvolvidosColetaAtivo] = 0))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome)) ) )
         {
            AddWhere(sWhereString, "([EnvolvidosColetaNome] like @lV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel)) && ! ( StringUtil.StrCmp(AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EnvolvidosColetaNome] = @AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EnvolvidosColetaNome] = ''))");
         }
         if ( AV49Envolvidoscoletawwds_4_tfenvolvidoscoletaativo_sel == 1 )
         {
            AddWhere(sWhereString, "([EnvolvidosColetaAtivo] = 1)");
         }
         if ( AV49Envolvidoscoletawwds_4_tfenvolvidoscoletaativo_sel == 2 )
         {
            AddWhere(sWhereString, "([EnvolvidosColetaAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EnvolvidosColetaNome]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EnvolvidosColetaNome] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EnvolvidosColetaAtivo]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EnvolvidosColetaAtivo] DESC";
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
                     return conditional_P004C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP004C2;
          prmP004C2 = new Object[] {
          new ParDef("@lV46Envolvidoscoletawwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV46Envolvidoscoletawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Envolvidoscoletawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV47Envolvidoscoletawwds_2_tfenvolvidoscoletanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV48Envolvidoscoletawwds_3_tfenvolvidoscoletanome_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C2,100, GxCacheFrequency.OFF ,true,false )
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
