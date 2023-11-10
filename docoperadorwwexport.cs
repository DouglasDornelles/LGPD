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
   public class docoperadorwwexport : GXProcedure
   {
      public docoperadorwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docoperadorwwexport( IGxContext context )
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
         docoperadorwwexport objdocoperadorwwexport;
         objdocoperadorwwexport = new docoperadorwwexport();
         objdocoperadorwwexport.AV12Filename = "" ;
         objdocoperadorwwexport.AV13ErrorMessage = "" ;
         objdocoperadorwwexport.context.SetSubmitInitialConfig(context);
         objdocoperadorwwexport.initialize();
         Submit( executePrivateCatch,objdocoperadorwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docoperadorwwexport)stateInfo).executePrivate();
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
         AV12Filename = "DocOperadorWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV41TFDocOperadorColeta_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Coleta?") ;
            AV14CellRow = GXt_int1;
            if ( AV41TFDocOperadorColeta_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV41TFDocOperadorColeta_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV42TFDocOperadorRetencao_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Retenção?") ;
            AV14CellRow = GXt_int1;
            if ( AV42TFDocOperadorRetencao_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV42TFDocOperadorRetencao_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV43TFDocOperadorCompartilhamento_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Compartilhamento?") ;
            AV14CellRow = GXt_int1;
            if ( AV43TFDocOperadorCompartilhamento_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV43TFDocOperadorCompartilhamento_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV44TFDocOperadorEliminacao_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Eliminição?") ;
            AV14CellRow = GXt_int1;
            if ( AV44TFDocOperadorEliminacao_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV44TFDocOperadorEliminacao_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV45TFDocOperadorProcessamento_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Processamento?") ;
            AV14CellRow = GXt_int1;
            if ( AV45TFDocOperadorProcessamento_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV45TFDocOperadorProcessamento_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (DateTime.MinValue==AV46TFDocOperadorDataInclusao) && (DateTime.MinValue==AV47TFDocOperadorDataInclusao_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Data Inclusao") ;
            AV14CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV46TFDocOperadorDataInclusao ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV47TFDocOperadorDataInclusao_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("DocOperadorWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("DocOperadorWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV51GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV53Docoperadorwwds_1_filterfulltext = AV19FilterFullText;
         AV54Docoperadorwwds_2_tfdocoperadorid = AV35TFDocOperadorId;
         AV55Docoperadorwwds_3_tfdocoperadorid_to = AV36TFDocOperadorId_To;
         AV56Docoperadorwwds_4_tfdocumentoid = AV37TFDocumentoId;
         AV57Docoperadorwwds_5_tfdocumentoid_to = AV38TFDocumentoId_To;
         AV58Docoperadorwwds_6_tfoperadorid = AV39TFOperadorId;
         AV59Docoperadorwwds_7_tfoperadorid_to = AV40TFOperadorId_To;
         AV60Docoperadorwwds_8_tfdocoperadorcoleta_sel = AV41TFDocOperadorColeta_Sel;
         AV61Docoperadorwwds_9_tfdocoperadorretencao_sel = AV42TFDocOperadorRetencao_Sel;
         AV62Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel = AV43TFDocOperadorCompartilhamento_Sel;
         AV63Docoperadorwwds_11_tfdocoperadoreliminacao_sel = AV44TFDocOperadorEliminacao_Sel;
         AV64Docoperadorwwds_12_tfdocoperadorprocessamento_sel = AV45TFDocOperadorProcessamento_Sel;
         AV65Docoperadorwwds_13_tfdocoperadordatainclusao = AV46TFDocOperadorDataInclusao;
         AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to = AV47TFDocOperadorDataInclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Docoperadorwwds_1_filterfulltext ,
                                              AV54Docoperadorwwds_2_tfdocoperadorid ,
                                              AV55Docoperadorwwds_3_tfdocoperadorid_to ,
                                              AV56Docoperadorwwds_4_tfdocumentoid ,
                                              AV57Docoperadorwwds_5_tfdocumentoid_to ,
                                              AV58Docoperadorwwds_6_tfoperadorid ,
                                              AV59Docoperadorwwds_7_tfoperadorid_to ,
                                              AV60Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                              AV61Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                              AV62Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                              AV63Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                              AV64Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                              AV65Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                              AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                              A86DocOperadorId ,
                                              A75DocumentoId ,
                                              A42OperadorId ,
                                              A87DocOperadorColeta ,
                                              A88DocOperadorRetencao ,
                                              A89DocOperadorCompartilhamento ,
                                              A90DocOperadorEliminacao ,
                                              A91DocOperadorProcessamento ,
                                              A92DocOperadorDataInclusao ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Docoperadorwwds_1_filterfulltext), "%", "");
         lV53Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Docoperadorwwds_1_filterfulltext), "%", "");
         lV53Docoperadorwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Docoperadorwwds_1_filterfulltext), "%", "");
         /* Using cursor P00562 */
         pr_default.execute(0, new Object[] {lV53Docoperadorwwds_1_filterfulltext, lV53Docoperadorwwds_1_filterfulltext, lV53Docoperadorwwds_1_filterfulltext, AV54Docoperadorwwds_2_tfdocoperadorid, AV55Docoperadorwwds_3_tfdocoperadorid_to, AV56Docoperadorwwds_4_tfdocumentoid, AV57Docoperadorwwds_5_tfdocumentoid_to, AV58Docoperadorwwds_6_tfoperadorid, AV59Docoperadorwwds_7_tfoperadorid_to, AV65Docoperadorwwds_13_tfdocoperadordatainclusao, AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A92DocOperadorDataInclusao = P00562_A92DocOperadorDataInclusao[0];
            A91DocOperadorProcessamento = P00562_A91DocOperadorProcessamento[0];
            A90DocOperadorEliminacao = P00562_A90DocOperadorEliminacao[0];
            A89DocOperadorCompartilhamento = P00562_A89DocOperadorCompartilhamento[0];
            A88DocOperadorRetencao = P00562_A88DocOperadorRetencao[0];
            A87DocOperadorColeta = P00562_A87DocOperadorColeta[0];
            A42OperadorId = P00562_A42OperadorId[0];
            A75DocumentoId = P00562_A75DocumentoId[0];
            A86DocOperadorId = P00562_A86DocOperadorId[0];
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
            AV67GXV2 = 1;
            while ( AV67GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV67GXV2));
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
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorColeta") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A87DocOperadorColeta);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorRetencao") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A88DocOperadorRetencao);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorCompartilhamento") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A89DocOperadorCompartilhamento);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorEliminacao") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A90DocOperadorEliminacao);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorProcessamento") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A91DocOperadorProcessamento);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocOperadorDataInclusao") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A92DocOperadorDataInclusao ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV67GXV2 = (int)(AV67GXV2+1);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorColeta",  "",  "Coleta?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorRetencao",  "",  "Retenção?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorCompartilhamento",  "",  "Compartilhamento?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorEliminacao",  "",  "Eliminição?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorProcessamento",  "",  "Processamento?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocOperadorDataInclusao",  "",  "Data Inclusao",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocOperadorWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("DocOperadorWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocOperadorWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("DocOperadorWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV68GXV3 = 1;
         while ( AV68GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV68GXV3));
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORCOLETA_SEL") == 0 )
            {
               AV41TFDocOperadorColeta_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORRETENCAO_SEL") == 0 )
            {
               AV42TFDocOperadorRetencao_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORCOMPARTILHAMENTO_SEL") == 0 )
            {
               AV43TFDocOperadorCompartilhamento_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORELIMINACAO_SEL") == 0 )
            {
               AV44TFDocOperadorEliminacao_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORPROCESSAMENTO_SEL") == 0 )
            {
               AV45TFDocOperadorProcessamento_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCOPERADORDATAINCLUSAO") == 0 )
            {
               AV46TFDocOperadorDataInclusao = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV47TFDocOperadorDataInclusao_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV68GXV3 = (int)(AV68GXV3+1);
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
         AV46TFDocOperadorDataInclusao = DateTime.MinValue;
         AV47TFDocOperadorDataInclusao_To = DateTime.MinValue;
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV53Docoperadorwwds_1_filterfulltext = "";
         AV65Docoperadorwwds_13_tfdocoperadordatainclusao = DateTime.MinValue;
         AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to = DateTime.MinValue;
         scmdbuf = "";
         lV53Docoperadorwwds_1_filterfulltext = "";
         A92DocOperadorDataInclusao = DateTime.MinValue;
         P00562_A92DocOperadorDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P00562_A91DocOperadorProcessamento = new bool[] {false} ;
         P00562_A90DocOperadorEliminacao = new bool[] {false} ;
         P00562_A89DocOperadorCompartilhamento = new bool[] {false} ;
         P00562_A88DocOperadorRetencao = new bool[] {false} ;
         P00562_A87DocOperadorColeta = new bool[] {false} ;
         P00562_A42OperadorId = new int[1] ;
         P00562_A75DocumentoId = new int[1] ;
         P00562_A86DocOperadorId = new int[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docoperadorwwexport__default(),
            new Object[][] {
                new Object[] {
               P00562_A92DocOperadorDataInclusao, P00562_A91DocOperadorProcessamento, P00562_A90DocOperadorEliminacao, P00562_A89DocOperadorCompartilhamento, P00562_A88DocOperadorRetencao, P00562_A87DocOperadorColeta, P00562_A42OperadorId, P00562_A75DocumentoId, P00562_A86DocOperadorId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41TFDocOperadorColeta_Sel ;
      private short AV42TFDocOperadorRetencao_Sel ;
      private short AV43TFDocOperadorCompartilhamento_Sel ;
      private short AV44TFDocOperadorEliminacao_Sel ;
      private short AV45TFDocOperadorProcessamento_Sel ;
      private short GXt_int1 ;
      private short AV60Docoperadorwwds_8_tfdocoperadorcoleta_sel ;
      private short AV61Docoperadorwwds_9_tfdocoperadorretencao_sel ;
      private short AV62Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ;
      private short AV63Docoperadorwwds_11_tfdocoperadoreliminacao_sel ;
      private short AV64Docoperadorwwds_12_tfdocoperadorprocessamento_sel ;
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
      private int AV51GXV1 ;
      private int AV54Docoperadorwwds_2_tfdocoperadorid ;
      private int AV55Docoperadorwwds_3_tfdocoperadorid_to ;
      private int AV56Docoperadorwwds_4_tfdocumentoid ;
      private int AV57Docoperadorwwds_5_tfdocumentoid_to ;
      private int AV58Docoperadorwwds_6_tfoperadorid ;
      private int AV59Docoperadorwwds_7_tfoperadorid_to ;
      private int A86DocOperadorId ;
      private int A75DocumentoId ;
      private int A42OperadorId ;
      private int AV67GXV2 ;
      private int AV68GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV46TFDocOperadorDataInclusao ;
      private DateTime AV47TFDocOperadorDataInclusao_To ;
      private DateTime AV65Docoperadorwwds_13_tfdocoperadordatainclusao ;
      private DateTime AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to ;
      private DateTime A92DocOperadorDataInclusao ;
      private bool returnInSub ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV53Docoperadorwwds_1_filterfulltext ;
      private string lV53Docoperadorwwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00562_A92DocOperadorDataInclusao ;
      private bool[] P00562_A91DocOperadorProcessamento ;
      private bool[] P00562_A90DocOperadorEliminacao ;
      private bool[] P00562_A89DocOperadorCompartilhamento ;
      private bool[] P00562_A88DocOperadorRetencao ;
      private bool[] P00562_A87DocOperadorColeta ;
      private int[] P00562_A42OperadorId ;
      private int[] P00562_A75DocumentoId ;
      private int[] P00562_A86DocOperadorId ;
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

   public class docoperadorwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00562( IGxContext context ,
                                             string AV53Docoperadorwwds_1_filterfulltext ,
                                             int AV54Docoperadorwwds_2_tfdocoperadorid ,
                                             int AV55Docoperadorwwds_3_tfdocoperadorid_to ,
                                             int AV56Docoperadorwwds_4_tfdocumentoid ,
                                             int AV57Docoperadorwwds_5_tfdocumentoid_to ,
                                             int AV58Docoperadorwwds_6_tfoperadorid ,
                                             int AV59Docoperadorwwds_7_tfoperadorid_to ,
                                             short AV60Docoperadorwwds_8_tfdocoperadorcoleta_sel ,
                                             short AV61Docoperadorwwds_9_tfdocoperadorretencao_sel ,
                                             short AV62Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel ,
                                             short AV63Docoperadorwwds_11_tfdocoperadoreliminacao_sel ,
                                             short AV64Docoperadorwwds_12_tfdocoperadorprocessamento_sel ,
                                             DateTime AV65Docoperadorwwds_13_tfdocoperadordatainclusao ,
                                             DateTime AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to ,
                                             int A86DocOperadorId ,
                                             int A75DocumentoId ,
                                             int A42OperadorId ,
                                             bool A87DocOperadorColeta ,
                                             bool A88DocOperadorRetencao ,
                                             bool A89DocOperadorCompartilhamento ,
                                             bool A90DocOperadorEliminacao ,
                                             bool A91DocOperadorProcessamento ,
                                             DateTime A92DocOperadorDataInclusao ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [DocOperadorDataInclusao], [DocOperadorProcessamento], [DocOperadorEliminacao], [DocOperadorCompartilhamento], [DocOperadorRetencao], [DocOperadorColeta], [OperadorId], [DocumentoId], [DocOperadorId] FROM [DocOperador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Docoperadorwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([DocOperadorId] AS decimal(8,0))) like '%' + @lV53Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV53Docoperadorwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([OperadorId] AS decimal(8,0))) like '%' + @lV53Docoperadorwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV54Docoperadorwwds_2_tfdocoperadorid) )
         {
            AddWhere(sWhereString, "([DocOperadorId] >= @AV54Docoperadorwwds_2_tfdocoperadorid)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV55Docoperadorwwds_3_tfdocoperadorid_to) )
         {
            AddWhere(sWhereString, "([DocOperadorId] <= @AV55Docoperadorwwds_3_tfdocoperadorid_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV56Docoperadorwwds_4_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV56Docoperadorwwds_4_tfdocumentoid)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV57Docoperadorwwds_5_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV57Docoperadorwwds_5_tfdocumentoid_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV58Docoperadorwwds_6_tfoperadorid) )
         {
            AddWhere(sWhereString, "([OperadorId] >= @AV58Docoperadorwwds_6_tfoperadorid)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV59Docoperadorwwds_7_tfoperadorid_to) )
         {
            AddWhere(sWhereString, "([OperadorId] <= @AV59Docoperadorwwds_7_tfoperadorid_to)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV60Docoperadorwwds_8_tfdocoperadorcoleta_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 1)");
         }
         if ( AV60Docoperadorwwds_8_tfdocoperadorcoleta_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorColeta] = 0)");
         }
         if ( AV61Docoperadorwwds_9_tfdocoperadorretencao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 1)");
         }
         if ( AV61Docoperadorwwds_9_tfdocoperadorretencao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorRetencao] = 0)");
         }
         if ( AV62Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 1)");
         }
         if ( AV62Docoperadorwwds_10_tfdocoperadorcompartilhamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorCompartilhamento] = 0)");
         }
         if ( AV63Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 1)");
         }
         if ( AV63Docoperadorwwds_11_tfdocoperadoreliminacao_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorEliminacao] = 0)");
         }
         if ( AV64Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 1 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 1)");
         }
         if ( AV64Docoperadorwwds_12_tfdocoperadorprocessamento_sel == 2 )
         {
            AddWhere(sWhereString, "([DocOperadorProcessamento] = 0)");
         }
         if ( ! (DateTime.MinValue==AV65Docoperadorwwds_13_tfdocoperadordatainclusao) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] >= @AV65Docoperadorwwds_13_tfdocoperadordatainclusao)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to) )
         {
            AddWhere(sWhereString, "([DocOperadorDataInclusao] <= @AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorColeta]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorColeta] DESC";
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
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorRetencao]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorRetencao] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorCompartilhamento]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorCompartilhamento] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorEliminacao]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorEliminacao] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorProcessamento]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorProcessamento] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocOperadorDataInclusao]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocOperadorDataInclusao] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00562(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00562;
          prmP00562 = new Object[] {
          new ParDef("@lV53Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV53Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV53Docoperadorwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV54Docoperadorwwds_2_tfdocoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV55Docoperadorwwds_3_tfdocoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV56Docoperadorwwds_4_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV57Docoperadorwwds_5_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV58Docoperadorwwds_6_tfoperadorid",GXType.Int32,8,0) ,
          new ParDef("@AV59Docoperadorwwds_7_tfoperadorid_to",GXType.Int32,8,0) ,
          new ParDef("@AV65Docoperadorwwds_13_tfdocoperadordatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV66Docoperadorwwds_14_tfdocoperadordatainclusao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00562", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00562,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
