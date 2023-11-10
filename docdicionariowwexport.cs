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
   public class docdicionariowwexport : GXProcedure
   {
      public docdicionariowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docdicionariowwexport( IGxContext context )
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
         docdicionariowwexport objdocdicionariowwexport;
         objdocdicionariowwexport = new docdicionariowwexport();
         objdocdicionariowwexport.AV12Filename = "" ;
         objdocdicionariowwexport.AV13ErrorMessage = "" ;
         objdocdicionariowwexport.context.SetSubmitInitialConfig(context);
         objdocdicionariowwexport.initialize();
         Submit( executePrivateCatch,objdocdicionariowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docdicionariowwexport)stateInfo).executePrivate();
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
         AV12Filename = "DocDicionarioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFDocDicionarioId) && (0==AV36TFDocDicionarioId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Dicionario Id") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFDocDicionarioId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFDocDicionarioId_To;
         }
         if ( ! ( (0==AV39TFInformacaoId) && (0==AV40TFInformacaoId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "da Informação") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV39TFInformacaoId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV40TFInformacaoId_To;
         }
         if ( ! ( (0==AV53TFHipoteseTratamentoId) && (0==AV54TFHipoteseTratamentoId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "de Tratamento") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV53TFHipoteseTratamentoId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV54TFHipoteseTratamentoId_To;
         }
         if ( ! ( (0==AV44TFDocDicionarioSensivel_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Sensível?") ;
            AV14CellRow = GXt_int1;
            if ( AV44TFDocDicionarioSensivel_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV44TFDocDicionarioSensivel_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV45TFDocDicionarioPodeEliminar_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Eliminar?") ;
            AV14CellRow = GXt_int1;
            if ( AV45TFDocDicionarioPodeEliminar_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV45TFDocDicionarioPodeEliminar_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV69TFDocDicionarioTransfInter_Sel) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Internacional") ;
            AV14CellRow = GXt_int1;
            if ( AV69TFDocDicionarioTransfInter_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV69TFDocDicionarioTransfInter_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFDocDicionarioFinalidade_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Finalidade") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV49TFDocDicionarioFinalidade_Sel)) ? "(Vazio)" : StringUtil.Substring( AV49TFDocDicionarioFinalidade_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFDocDicionarioFinalidade)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Finalidade") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV48TFDocDicionarioFinalidade, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV50TFDocDicionarioDataInclusao) && (DateTime.MinValue==AV51TFDocDicionarioDataInclusao_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "de Inclusão") ;
            AV14CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV50TFDocDicionarioDataInclusao ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TFDocDicionarioDataInclusao_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFInformacaoNome_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFInformacaoNome_Sel)) ? "(Vazio)" : AV58TFInformacaoNome_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFInformacaoNome)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFInformacaoNome, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFHipoteseTratamentoNome_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFHipoteseTratamentoNome_Sel)) ? "(Vazio)" : AV60TFHipoteseTratamentoNome_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFHipoteseTratamentoNome)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFHipoteseTratamentoNome, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV63TFDocumentoId) && (0==AV64TFDocumentoId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Id do Documento") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV63TFDocumentoId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV64TFDocumentoId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFDocumentoNome_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV66TFDocumentoNome_Sel)) ? "(Vazio)" : AV66TFDocumentoNome_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFDocumentoNome)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV65TFDocumentoNome, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFDocDicionarioTipoTransfInterGarantia_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Transferência internacional") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV68TFDocDicionarioTipoTransfInterGarantia_Sel)) ? "(Vazio)" : StringUtil.Substring( AV68TFDocDicionarioTipoTransfInterGarantia_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFDocDicionarioTipoTransfInterGarantia)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Transferência internacional") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV67TFDocDicionarioTipoTransfInterGarantia, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("DocDicionarioWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("DocDicionarioWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV72GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV72GXV1 = (int)(AV72GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV74Docdicionariowwds_1_filterfulltext = AV19FilterFullText;
         AV75Docdicionariowwds_2_tfdocdicionarioid = AV35TFDocDicionarioId;
         AV76Docdicionariowwds_3_tfdocdicionarioid_to = AV36TFDocDicionarioId_To;
         AV77Docdicionariowwds_4_tfinformacaoid = AV39TFInformacaoId;
         AV78Docdicionariowwds_5_tfinformacaoid_to = AV40TFInformacaoId_To;
         AV79Docdicionariowwds_6_tfhipotesetratamentoid = AV53TFHipoteseTratamentoId;
         AV80Docdicionariowwds_7_tfhipotesetratamentoid_to = AV54TFHipoteseTratamentoId_To;
         AV81Docdicionariowwds_8_tfdocdicionariosensivel_sel = AV44TFDocDicionarioSensivel_Sel;
         AV82Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel = AV45TFDocDicionarioPodeEliminar_Sel;
         AV83Docdicionariowwds_10_tfdocdicionariotransfinter_sel = AV69TFDocDicionarioTransfInter_Sel;
         AV84Docdicionariowwds_11_tfdocdicionariofinalidade = AV48TFDocDicionarioFinalidade;
         AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel = AV49TFDocDicionarioFinalidade_Sel;
         AV86Docdicionariowwds_13_tfdocdicionariodatainclusao = AV50TFDocDicionarioDataInclusao;
         AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to = AV51TFDocDicionarioDataInclusao_To;
         AV88Docdicionariowwds_15_tfinformacaonome = AV57TFInformacaoNome;
         AV89Docdicionariowwds_16_tfinformacaonome_sel = AV58TFInformacaoNome_Sel;
         AV90Docdicionariowwds_17_tfhipotesetratamentonome = AV59TFHipoteseTratamentoNome;
         AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel = AV60TFHipoteseTratamentoNome_Sel;
         AV92Docdicionariowwds_19_tfdocumentoid = AV63TFDocumentoId;
         AV93Docdicionariowwds_20_tfdocumentoid_to = AV64TFDocumentoId_To;
         AV94Docdicionariowwds_21_tfdocumentonome = AV65TFDocumentoNome;
         AV95Docdicionariowwds_22_tfdocumentonome_sel = AV66TFDocumentoNome_Sel;
         AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = AV67TFDocDicionarioTipoTransfInterGarantia;
         AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = AV68TFDocDicionarioTipoTransfInterGarantia_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV74Docdicionariowwds_1_filterfulltext ,
                                              AV75Docdicionariowwds_2_tfdocdicionarioid ,
                                              AV76Docdicionariowwds_3_tfdocdicionarioid_to ,
                                              AV77Docdicionariowwds_4_tfinformacaoid ,
                                              AV78Docdicionariowwds_5_tfinformacaoid_to ,
                                              AV79Docdicionariowwds_6_tfhipotesetratamentoid ,
                                              AV80Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                              AV81Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                              AV82Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                              AV83Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                              AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                              AV84Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                              AV86Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                              AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                              AV89Docdicionariowwds_16_tfinformacaonome_sel ,
                                              AV88Docdicionariowwds_15_tfinformacaonome ,
                                              AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                              AV90Docdicionariowwds_17_tfhipotesetratamentonome ,
                                              AV92Docdicionariowwds_19_tfdocumentoid ,
                                              AV93Docdicionariowwds_20_tfdocumentoid_to ,
                                              AV95Docdicionariowwds_22_tfdocumentonome_sel ,
                                              AV94Docdicionariowwds_21_tfdocumentonome ,
                                              AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                              AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                              A98DocDicionarioId ,
                                              A69InformacaoId ,
                                              A72HipoteseTratamentoId ,
                                              A102DocDicionarioFinalidade ,
                                              A70InformacaoNome ,
                                              A73HipoteseTratamentoNome ,
                                              A75DocumentoId ,
                                              A76DocumentoNome ,
                                              A119DocDicionarioTipoTransfInterGa ,
                                              A99DocDicionarioSensivel ,
                                              A100DocDicionarioPodeEliminar ,
                                              A101DocDicionarioTransfInter ,
                                              A103DocDicionarioDataInclusao ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV74Docdicionariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext), "%", "");
         lV84Docdicionariowwds_11_tfdocdicionariofinalidade = StringUtil.Concat( StringUtil.RTrim( AV84Docdicionariowwds_11_tfdocdicionariofinalidade), "%", "");
         lV88Docdicionariowwds_15_tfinformacaonome = StringUtil.Concat( StringUtil.RTrim( AV88Docdicionariowwds_15_tfinformacaonome), "%", "");
         lV90Docdicionariowwds_17_tfhipotesetratamentonome = StringUtil.Concat( StringUtil.RTrim( AV90Docdicionariowwds_17_tfhipotesetratamentonome), "%", "");
         lV94Docdicionariowwds_21_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV94Docdicionariowwds_21_tfdocumentonome), "%", "");
         lV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = StringUtil.Concat( StringUtil.RTrim( AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia), "%", "");
         /* Using cursor P002Z2 */
         pr_default.execute(0, new Object[] {lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, lV74Docdicionariowwds_1_filterfulltext, AV75Docdicionariowwds_2_tfdocdicionarioid, AV76Docdicionariowwds_3_tfdocdicionarioid_to, AV77Docdicionariowwds_4_tfinformacaoid, AV78Docdicionariowwds_5_tfinformacaoid_to, AV79Docdicionariowwds_6_tfhipotesetratamentoid, AV80Docdicionariowwds_7_tfhipotesetratamentoid_to, lV84Docdicionariowwds_11_tfdocdicionariofinalidade, AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel, AV86Docdicionariowwds_13_tfdocdicionariodatainclusao, AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to, lV88Docdicionariowwds_15_tfinformacaonome, AV89Docdicionariowwds_16_tfinformacaonome_sel, lV90Docdicionariowwds_17_tfhipotesetratamentonome, AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel, AV92Docdicionariowwds_19_tfdocumentoid, AV93Docdicionariowwds_20_tfdocumentoid_to, lV94Docdicionariowwds_21_tfdocumentonome, AV95Docdicionariowwds_22_tfdocumentonome_sel, lV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia, AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P002Z2_A75DocumentoId[0];
            A103DocDicionarioDataInclusao = P002Z2_A103DocDicionarioDataInclusao[0];
            A101DocDicionarioTransfInter = P002Z2_A101DocDicionarioTransfInter[0];
            A100DocDicionarioPodeEliminar = P002Z2_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P002Z2_A99DocDicionarioSensivel[0];
            A72HipoteseTratamentoId = P002Z2_A72HipoteseTratamentoId[0];
            A69InformacaoId = P002Z2_A69InformacaoId[0];
            A98DocDicionarioId = P002Z2_A98DocDicionarioId[0];
            A119DocDicionarioTipoTransfInterGa = P002Z2_A119DocDicionarioTipoTransfInterGa[0];
            A76DocumentoNome = P002Z2_A76DocumentoNome[0];
            n76DocumentoNome = P002Z2_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Z2_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Z2_A70InformacaoNome[0];
            A102DocDicionarioFinalidade = P002Z2_A102DocDicionarioFinalidade[0];
            A76DocumentoNome = P002Z2_A76DocumentoNome[0];
            n76DocumentoNome = P002Z2_n76DocumentoNome[0];
            A73HipoteseTratamentoNome = P002Z2_A73HipoteseTratamentoNome[0];
            A70InformacaoNome = P002Z2_A70InformacaoNome[0];
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
            AV98GXV2 = 1;
            while ( AV98GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV98GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A98DocDicionarioId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "InformacaoId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A69InformacaoId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "HipoteseTratamentoId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A72HipoteseTratamentoId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioSensivel") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A99DocDicionarioSensivel);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioPodeEliminar") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A100DocDicionarioPodeEliminar);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioTransfInter") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A101DocDicionarioTransfInter);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioFinalidade") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A102DocDicionarioFinalidade, 1, 1000), out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioDataInclusao") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A103DocDicionarioDataInclusao ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "InformacaoNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A70InformacaoNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "HipoteseTratamentoNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A73HipoteseTratamentoNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocumentoId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A75DocumentoId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocumentoNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A76DocumentoNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocDicionarioTipoTransfInterGarantia") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A119DocDicionarioTipoTransfInterGa, 1, 1000), out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV98GXV2 = (int)(AV98GXV2+1);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioId",  "",  "Dicionario Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "InformacaoId",  "",  "da Informação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "HipoteseTratamentoId",  "",  "de Tratamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioSensivel",  "",  "Sensível?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioPodeEliminar",  "",  "Eliminar?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioTransfInter",  "",  "Internacional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioFinalidade",  "",  "Finalidade",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioDataInclusao",  "",  "de Inclusão",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "InformacaoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "HipoteseTratamentoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocumentoId",  "",  "Id do Documento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocumentoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocDicionarioTipoTransfInterGarantia",  "",  "Transferência internacional",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocDicionarioWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("DocDicionarioWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocDicionarioWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("DocDicionarioWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV99GXV3 = 1;
         while ( AV99GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV99GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOID") == 0 )
            {
               AV35TFDocDicionarioId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV36TFDocDicionarioId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFINFORMACAOID") == 0 )
            {
               AV39TFInformacaoId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV40TFInformacaoId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTOID") == 0 )
            {
               AV53TFHipoteseTratamentoId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV54TFHipoteseTratamentoId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOSENSIVEL_SEL") == 0 )
            {
               AV44TFDocDicionarioSensivel_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOPODEELIMINAR_SEL") == 0 )
            {
               AV45TFDocDicionarioPodeEliminar_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTRANSFINTER_SEL") == 0 )
            {
               AV69TFDocDicionarioTransfInter_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE") == 0 )
            {
               AV48TFDocDicionarioFinalidade = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOFINALIDADE_SEL") == 0 )
            {
               AV49TFDocDicionarioFinalidade_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIODATAINCLUSAO") == 0 )
            {
               AV50TFDocDicionarioDataInclusao = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV51TFDocDicionarioDataInclusao_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME") == 0 )
            {
               AV57TFInformacaoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFINFORMACAONOME_SEL") == 0 )
            {
               AV58TFInformacaoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME") == 0 )
            {
               AV59TFHipoteseTratamentoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHIPOTESETRATAMENTONOME_SEL") == 0 )
            {
               AV60TFHipoteseTratamentoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV63TFDocumentoId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV64TFDocumentoId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV65TFDocumentoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV66TFDocumentoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA") == 0 )
            {
               AV67TFDocDicionarioTipoTransfInterGarantia = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCDICIONARIOTIPOTRANSFINTERGARANTIA_SEL") == 0 )
            {
               AV68TFDocDicionarioTipoTransfInterGarantia_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV99GXV3 = (int)(AV99GXV3+1);
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
         AV49TFDocDicionarioFinalidade_Sel = "";
         AV48TFDocDicionarioFinalidade = "";
         AV50TFDocDicionarioDataInclusao = DateTime.MinValue;
         AV51TFDocDicionarioDataInclusao_To = DateTime.MinValue;
         AV58TFInformacaoNome_Sel = "";
         AV57TFInformacaoNome = "";
         AV60TFHipoteseTratamentoNome_Sel = "";
         AV59TFHipoteseTratamentoNome = "";
         AV66TFDocumentoNome_Sel = "";
         AV65TFDocumentoNome = "";
         AV68TFDocDicionarioTipoTransfInterGarantia_Sel = "";
         AV67TFDocDicionarioTipoTransfInterGarantia = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV74Docdicionariowwds_1_filterfulltext = "";
         AV84Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel = "";
         AV86Docdicionariowwds_13_tfdocdicionariodatainclusao = DateTime.MinValue;
         AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to = DateTime.MinValue;
         AV88Docdicionariowwds_15_tfinformacaonome = "";
         AV89Docdicionariowwds_16_tfinformacaonome_sel = "";
         AV90Docdicionariowwds_17_tfhipotesetratamentonome = "";
         AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel = "";
         AV94Docdicionariowwds_21_tfdocumentonome = "";
         AV95Docdicionariowwds_22_tfdocumentonome_sel = "";
         AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel = "";
         scmdbuf = "";
         lV74Docdicionariowwds_1_filterfulltext = "";
         lV84Docdicionariowwds_11_tfdocdicionariofinalidade = "";
         lV88Docdicionariowwds_15_tfinformacaonome = "";
         lV90Docdicionariowwds_17_tfhipotesetratamentonome = "";
         lV94Docdicionariowwds_21_tfdocumentonome = "";
         lV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia = "";
         A102DocDicionarioFinalidade = "";
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A76DocumentoNome = "";
         A119DocDicionarioTipoTransfInterGa = "";
         A103DocDicionarioDataInclusao = DateTime.MinValue;
         P002Z2_A75DocumentoId = new int[1] ;
         P002Z2_A103DocDicionarioDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P002Z2_A101DocDicionarioTransfInter = new bool[] {false} ;
         P002Z2_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P002Z2_A99DocDicionarioSensivel = new bool[] {false} ;
         P002Z2_A72HipoteseTratamentoId = new int[1] ;
         P002Z2_A69InformacaoId = new int[1] ;
         P002Z2_A98DocDicionarioId = new int[1] ;
         P002Z2_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P002Z2_A76DocumentoNome = new string[] {""} ;
         P002Z2_n76DocumentoNome = new bool[] {false} ;
         P002Z2_A73HipoteseTratamentoNome = new string[] {""} ;
         P002Z2_A70InformacaoNome = new string[] {""} ;
         P002Z2_A102DocDicionarioFinalidade = new string[] {""} ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docdicionariowwexport__default(),
            new Object[][] {
                new Object[] {
               P002Z2_A75DocumentoId, P002Z2_A103DocDicionarioDataInclusao, P002Z2_A101DocDicionarioTransfInter, P002Z2_A100DocDicionarioPodeEliminar, P002Z2_A99DocDicionarioSensivel, P002Z2_A72HipoteseTratamentoId, P002Z2_A69InformacaoId, P002Z2_A98DocDicionarioId, P002Z2_A119DocDicionarioTipoTransfInterGa, P002Z2_A76DocumentoNome,
               P002Z2_n76DocumentoNome, P002Z2_A73HipoteseTratamentoNome, P002Z2_A70InformacaoNome, P002Z2_A102DocDicionarioFinalidade
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV44TFDocDicionarioSensivel_Sel ;
      private short AV45TFDocDicionarioPodeEliminar_Sel ;
      private short AV69TFDocDicionarioTransfInter_Sel ;
      private short GXt_int1 ;
      private short AV81Docdicionariowwds_8_tfdocdicionariosensivel_sel ;
      private short AV82Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ;
      private short AV83Docdicionariowwds_10_tfdocdicionariotransfinter_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV35TFDocDicionarioId ;
      private int AV36TFDocDicionarioId_To ;
      private int AV39TFInformacaoId ;
      private int AV40TFInformacaoId_To ;
      private int AV53TFHipoteseTratamentoId ;
      private int AV54TFHipoteseTratamentoId_To ;
      private int AV63TFDocumentoId ;
      private int AV64TFDocumentoId_To ;
      private int AV72GXV1 ;
      private int AV75Docdicionariowwds_2_tfdocdicionarioid ;
      private int AV76Docdicionariowwds_3_tfdocdicionarioid_to ;
      private int AV77Docdicionariowwds_4_tfinformacaoid ;
      private int AV78Docdicionariowwds_5_tfinformacaoid_to ;
      private int AV79Docdicionariowwds_6_tfhipotesetratamentoid ;
      private int AV80Docdicionariowwds_7_tfhipotesetratamentoid_to ;
      private int AV92Docdicionariowwds_19_tfdocumentoid ;
      private int AV93Docdicionariowwds_20_tfdocumentoid_to ;
      private int A98DocDicionarioId ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A75DocumentoId ;
      private int AV98GXV2 ;
      private int AV99GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV50TFDocDicionarioDataInclusao ;
      private DateTime AV51TFDocDicionarioDataInclusao_To ;
      private DateTime AV86Docdicionariowwds_13_tfdocdicionariodatainclusao ;
      private DateTime AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to ;
      private DateTime A103DocDicionarioDataInclusao ;
      private bool returnInSub ;
      private bool A99DocDicionarioSensivel ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A101DocDicionarioTransfInter ;
      private bool AV18OrderedDsc ;
      private bool n76DocumentoNome ;
      private string AV27ColumnsSelectorXML ;
      private string AV84Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel ;
      private string lV84Docdicionariowwds_11_tfdocdicionariofinalidade ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV49TFDocDicionarioFinalidade_Sel ;
      private string AV48TFDocDicionarioFinalidade ;
      private string AV58TFInformacaoNome_Sel ;
      private string AV57TFInformacaoNome ;
      private string AV60TFHipoteseTratamentoNome_Sel ;
      private string AV59TFHipoteseTratamentoNome ;
      private string AV66TFDocumentoNome_Sel ;
      private string AV65TFDocumentoNome ;
      private string AV68TFDocDicionarioTipoTransfInterGarantia_Sel ;
      private string AV67TFDocDicionarioTipoTransfInterGarantia ;
      private string AV74Docdicionariowwds_1_filterfulltext ;
      private string AV88Docdicionariowwds_15_tfinformacaonome ;
      private string AV89Docdicionariowwds_16_tfinformacaonome_sel ;
      private string AV90Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel ;
      private string AV94Docdicionariowwds_21_tfdocumentonome ;
      private string AV95Docdicionariowwds_22_tfdocumentonome_sel ;
      private string AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ;
      private string lV74Docdicionariowwds_1_filterfulltext ;
      private string lV88Docdicionariowwds_15_tfinformacaonome ;
      private string lV90Docdicionariowwds_17_tfhipotesetratamentonome ;
      private string lV94Docdicionariowwds_21_tfdocumentonome ;
      private string lV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string A76DocumentoNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002Z2_A75DocumentoId ;
      private DateTime[] P002Z2_A103DocDicionarioDataInclusao ;
      private bool[] P002Z2_A101DocDicionarioTransfInter ;
      private bool[] P002Z2_A100DocDicionarioPodeEliminar ;
      private bool[] P002Z2_A99DocDicionarioSensivel ;
      private int[] P002Z2_A72HipoteseTratamentoId ;
      private int[] P002Z2_A69InformacaoId ;
      private int[] P002Z2_A98DocDicionarioId ;
      private string[] P002Z2_A119DocDicionarioTipoTransfInterGa ;
      private string[] P002Z2_A76DocumentoNome ;
      private bool[] P002Z2_n76DocumentoNome ;
      private string[] P002Z2_A73HipoteseTratamentoNome ;
      private string[] P002Z2_A70InformacaoNome ;
      private string[] P002Z2_A102DocDicionarioFinalidade ;
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

   public class docdicionariowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Z2( IGxContext context ,
                                             string AV74Docdicionariowwds_1_filterfulltext ,
                                             int AV75Docdicionariowwds_2_tfdocdicionarioid ,
                                             int AV76Docdicionariowwds_3_tfdocdicionarioid_to ,
                                             int AV77Docdicionariowwds_4_tfinformacaoid ,
                                             int AV78Docdicionariowwds_5_tfinformacaoid_to ,
                                             int AV79Docdicionariowwds_6_tfhipotesetratamentoid ,
                                             int AV80Docdicionariowwds_7_tfhipotesetratamentoid_to ,
                                             short AV81Docdicionariowwds_8_tfdocdicionariosensivel_sel ,
                                             short AV82Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel ,
                                             short AV83Docdicionariowwds_10_tfdocdicionariotransfinter_sel ,
                                             string AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel ,
                                             string AV84Docdicionariowwds_11_tfdocdicionariofinalidade ,
                                             DateTime AV86Docdicionariowwds_13_tfdocdicionariodatainclusao ,
                                             DateTime AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to ,
                                             string AV89Docdicionariowwds_16_tfinformacaonome_sel ,
                                             string AV88Docdicionariowwds_15_tfinformacaonome ,
                                             string AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel ,
                                             string AV90Docdicionariowwds_17_tfhipotesetratamentonome ,
                                             int AV92Docdicionariowwds_19_tfdocumentoid ,
                                             int AV93Docdicionariowwds_20_tfdocumentoid_to ,
                                             string AV95Docdicionariowwds_22_tfdocumentonome_sel ,
                                             string AV94Docdicionariowwds_21_tfdocumentonome ,
                                             string AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel ,
                                             string AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia ,
                                             int A98DocDicionarioId ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             string A102DocDicionarioFinalidade ,
                                             string A70InformacaoNome ,
                                             string A73HipoteseTratamentoNome ,
                                             int A75DocumentoId ,
                                             string A76DocumentoNome ,
                                             string A119DocDicionarioTipoTransfInterGa ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar ,
                                             bool A101DocDicionarioTransfInter ,
                                             DateTime A103DocDicionarioDataInclusao ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[29];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocDicionarioDataInclusao], T1.[DocDicionarioTransfInter], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T1.[HipoteseTratamentoId], T1.[InformacaoId], T1.[DocDicionarioId], T1.[DocDicionarioTipoTransfInterGa], T2.[DocumentoNome], T3.[HipoteseTratamentoNome], T4.[InformacaoNome], T1.[DocDicionarioFinalidade] FROM ((([DocDicionario] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) INNER JOIN [Informacao] T4 ON T4.[InformacaoId] = T1.[InformacaoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Docdicionariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST(T1.[DocDicionarioId] AS decimal(8,0))) like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[InformacaoId] AS decimal(8,0))) like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[HipoteseTratamentoId] AS decimal(8,0))) like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioFinalidade] like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( T4.[InformacaoNome] like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( T3.[HipoteseTratamentoNome] like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( CONVERT( char(8), CAST(T1.[DocumentoId] AS decimal(8,0))) like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( T2.[DocumentoNome] like '%' + @lV74Docdicionariowwds_1_filterfulltext) or ( T1.[DocDicionarioTipoTransfInterGa] like '%' + @lV74Docdicionariowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV75Docdicionariowwds_2_tfdocdicionarioid) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] >= @AV75Docdicionariowwds_2_tfdocdicionarioid)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV76Docdicionariowwds_3_tfdocdicionarioid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioId] <= @AV76Docdicionariowwds_3_tfdocdicionarioid_to)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV77Docdicionariowwds_4_tfinformacaoid) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] >= @AV77Docdicionariowwds_4_tfinformacaoid)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV78Docdicionariowwds_5_tfinformacaoid_to) )
         {
            AddWhere(sWhereString, "(T1.[InformacaoId] <= @AV78Docdicionariowwds_5_tfinformacaoid_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV79Docdicionariowwds_6_tfhipotesetratamentoid) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] >= @AV79Docdicionariowwds_6_tfhipotesetratamentoid)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV80Docdicionariowwds_7_tfhipotesetratamentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[HipoteseTratamentoId] <= @AV80Docdicionariowwds_7_tfhipotesetratamentoid_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV81Docdicionariowwds_8_tfdocdicionariosensivel_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 1)");
         }
         if ( AV81Docdicionariowwds_8_tfdocdicionariosensivel_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioSensivel] = 0)");
         }
         if ( AV82Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 1)");
         }
         if ( AV82Docdicionariowwds_9_tfdocdicionariopodeeliminar_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioPodeEliminar] = 0)");
         }
         if ( AV83Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 1)");
         }
         if ( AV83Docdicionariowwds_10_tfdocdicionariotransfinter_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTransfInter] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Docdicionariowwds_11_tfdocdicionariofinalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] like @lV84Docdicionariowwds_11_tfdocdicionariofinalidade)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel)) && ! ( StringUtil.StrCmp(AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioFinalidade] = @AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioFinalidade])=0))");
         }
         if ( ! (DateTime.MinValue==AV86Docdicionariowwds_13_tfdocdicionariodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] >= @AV86Docdicionariowwds_13_tfdocdicionariodatainclusao)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioDataInclusao] <= @AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_16_tfinformacaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Docdicionariowwds_15_tfinformacaonome)) ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] like @lV88Docdicionariowwds_15_tfinformacaonome)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Docdicionariowwds_16_tfinformacaonome_sel)) && ! ( StringUtil.StrCmp(AV89Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[InformacaoNome] = @AV89Docdicionariowwds_16_tfinformacaonome_sel)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV89Docdicionariowwds_16_tfinformacaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[InformacaoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Docdicionariowwds_17_tfhipotesetratamentonome)) ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] like @lV90Docdicionariowwds_17_tfhipotesetratamentonome)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel)) && ! ( StringUtil.StrCmp(AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[HipoteseTratamentoNome] = @AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[HipoteseTratamentoNome] = ''))");
         }
         if ( ! (0==AV92Docdicionariowwds_19_tfdocumentoid) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] >= @AV92Docdicionariowwds_19_tfdocumentoid)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (0==AV93Docdicionariowwds_20_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "(T1.[DocumentoId] <= @AV93Docdicionariowwds_20_tfdocumentoid_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_22_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Docdicionariowwds_21_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV94Docdicionariowwds_21_tfdocumentonome)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Docdicionariowwds_22_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV95Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV95Docdicionariowwds_22_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV95Docdicionariowwds_22_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] like @lV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)) && ! ( StringUtil.StrCmp(AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocDicionarioTipoTransfInterGa] = @AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[DocDicionarioTipoTransfInterGa])=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioSensivel]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioSensivel] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[InformacaoId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[InformacaoId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HipoteseTratamentoId]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HipoteseTratamentoId] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioPodeEliminar]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioPodeEliminar] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTransfInter]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTransfInter] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioFinalidade]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioFinalidade] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioDataInclusao]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioDataInclusao] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[InformacaoNome]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[InformacaoNome] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[HipoteseTratamentoNome]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[HipoteseTratamentoNome] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocumentoId]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocumentoId] DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome]";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome] DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTipoTransfInterGa]";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocDicionarioTipoTransfInterGa] DESC";
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
                     return conditional_P002Z2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (int)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] , (DateTime)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
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
          Object[] prmP002Z2;
          prmP002Z2 = new Object[] {
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Docdicionariowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Docdicionariowwds_2_tfdocdicionarioid",GXType.Int32,8,0) ,
          new ParDef("@AV76Docdicionariowwds_3_tfdocdicionarioid_to",GXType.Int32,8,0) ,
          new ParDef("@AV77Docdicionariowwds_4_tfinformacaoid",GXType.Int32,8,0) ,
          new ParDef("@AV78Docdicionariowwds_5_tfinformacaoid_to",GXType.Int32,8,0) ,
          new ParDef("@AV79Docdicionariowwds_6_tfhipotesetratamentoid",GXType.Int32,8,0) ,
          new ParDef("@AV80Docdicionariowwds_7_tfhipotesetratamentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV84Docdicionariowwds_11_tfdocdicionariofinalidade",GXType.NVarChar,10000,0) ,
          new ParDef("@AV85Docdicionariowwds_12_tfdocdicionariofinalidade_sel",GXType.NVarChar,10000,0) ,
          new ParDef("@AV86Docdicionariowwds_13_tfdocdicionariodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV87Docdicionariowwds_14_tfdocdicionariodatainclusao_to",GXType.Date,8,0) ,
          new ParDef("@lV88Docdicionariowwds_15_tfinformacaonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV89Docdicionariowwds_16_tfinformacaonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV90Docdicionariowwds_17_tfhipotesetratamentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV91Docdicionariowwds_18_tfhipotesetratamentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV92Docdicionariowwds_19_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV93Docdicionariowwds_20_tfdocumentoid_to",GXType.Int32,8,0) ,
          new ParDef("@lV94Docdicionariowwds_21_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV95Docdicionariowwds_22_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV96Docdicionariowwds_23_tfdocdicionariotipotransfintergarantia",GXType.NVarChar,200,0) ,
          new ParDef("@AV97Docdicionariowwds_24_tfdocdicionariotipotransfintergarantia_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                return;
       }
    }

 }

}
