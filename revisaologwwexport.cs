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
   public class revisaologwwexport : GXProcedure
   {
      public revisaologwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public revisaologwwexport( IGxContext context )
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
         revisaologwwexport objrevisaologwwexport;
         objrevisaologwwexport = new revisaologwwexport();
         objrevisaologwwexport.AV12Filename = "" ;
         objrevisaologwwexport.AV13ErrorMessage = "" ;
         objrevisaologwwexport.context.SetSubmitInitialConfig(context);
         objrevisaologwwexport.initialize();
         Submit( executePrivateCatch,objrevisaologwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((revisaologwwexport)stateInfo).executePrivate();
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
         AV12Filename = "RevisaoLogWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFRevisaoLogId) && (0==AV36TFRevisaoLogId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Log Id") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFRevisaoLogId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFRevisaoLogId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFRevisaoLogUsuarioAlteracao_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Usuario Alteracao") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFRevisaoLogUsuarioAlteracao_Sel)) ? "(Vazio)" : AV38TFRevisaoLogUsuarioAlteracao_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFRevisaoLogUsuarioAlteracao)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Usuario Alteracao") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFRevisaoLogUsuarioAlteracao, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRevisaoLogObservacao_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Log Observacao") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRevisaoLogObservacao_Sel)) ? "(Vazio)" : StringUtil.Substring( AV40TFRevisaoLogObservacao_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRevisaoLogObservacao)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Log Observacao") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV39TFRevisaoLogObservacao, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV41TFRevisaoLogDataAlteracao) && (DateTime.MinValue==AV42TFRevisaoLogDataAlteracao_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Data Alteracao") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV41TFRevisaoLogDataAlteracao;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV42TFRevisaoLogDataAlteracao_To;
         }
         if ( ! ( (0==AV43TFDocumentoId) && (0==AV44TFDocumentoId_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "do Documento") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV43TFDocumentoId;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV44TFDocumentoId_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("RevisaoLogWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("RevisaoLogWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV48GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV50Revisaologwwds_1_filterfulltext = AV19FilterFullText;
         AV51Revisaologwwds_2_tfrevisaologid = AV35TFRevisaoLogId;
         AV52Revisaologwwds_3_tfrevisaologid_to = AV36TFRevisaoLogId_To;
         AV53Revisaologwwds_4_tfrevisaologusuarioalteracao = AV37TFRevisaoLogUsuarioAlteracao;
         AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = AV38TFRevisaoLogUsuarioAlteracao_Sel;
         AV55Revisaologwwds_6_tfrevisaologobservacao = AV39TFRevisaoLogObservacao;
         AV56Revisaologwwds_7_tfrevisaologobservacao_sel = AV40TFRevisaoLogObservacao_Sel;
         AV57Revisaologwwds_8_tfrevisaologdataalteracao = AV41TFRevisaoLogDataAlteracao;
         AV58Revisaologwwds_9_tfrevisaologdataalteracao_to = AV42TFRevisaoLogDataAlteracao_To;
         AV59Revisaologwwds_10_tfdocumentoid = AV43TFDocumentoId;
         AV60Revisaologwwds_11_tfdocumentoid_to = AV44TFDocumentoId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Revisaologwwds_1_filterfulltext ,
                                              AV51Revisaologwwds_2_tfrevisaologid ,
                                              AV52Revisaologwwds_3_tfrevisaologid_to ,
                                              AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                              AV53Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                              AV56Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                              AV55Revisaologwwds_6_tfrevisaologobservacao ,
                                              AV57Revisaologwwds_8_tfrevisaologdataalteracao ,
                                              AV58Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                              AV59Revisaologwwds_10_tfdocumentoid ,
                                              AV60Revisaologwwds_11_tfdocumentoid_to ,
                                              A120RevisaoLogId ,
                                              A121RevisaoLogUsuarioAlteracao ,
                                              A122RevisaoLogObservacao ,
                                              A75DocumentoId ,
                                              A123RevisaoLogDataAlteracao ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV50Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Revisaologwwds_1_filterfulltext), "%", "");
         lV50Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Revisaologwwds_1_filterfulltext), "%", "");
         lV50Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Revisaologwwds_1_filterfulltext), "%", "");
         lV50Revisaologwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Revisaologwwds_1_filterfulltext), "%", "");
         lV53Revisaologwwds_4_tfrevisaologusuarioalteracao = StringUtil.Concat( StringUtil.RTrim( AV53Revisaologwwds_4_tfrevisaologusuarioalteracao), "%", "");
         lV55Revisaologwwds_6_tfrevisaologobservacao = StringUtil.Concat( StringUtil.RTrim( AV55Revisaologwwds_6_tfrevisaologobservacao), "%", "");
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {lV50Revisaologwwds_1_filterfulltext, lV50Revisaologwwds_1_filterfulltext, lV50Revisaologwwds_1_filterfulltext, lV50Revisaologwwds_1_filterfulltext, AV51Revisaologwwds_2_tfrevisaologid, AV52Revisaologwwds_3_tfrevisaologid_to, lV53Revisaologwwds_4_tfrevisaologusuarioalteracao, AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, lV55Revisaologwwds_6_tfrevisaologobservacao, AV56Revisaologwwds_7_tfrevisaologobservacao_sel, AV57Revisaologwwds_8_tfrevisaologdataalteracao, AV58Revisaologwwds_9_tfrevisaologdataalteracao_to, AV59Revisaologwwds_10_tfdocumentoid, AV60Revisaologwwds_11_tfdocumentoid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P00712_A75DocumentoId[0];
            A123RevisaoLogDataAlteracao = P00712_A123RevisaoLogDataAlteracao[0];
            A120RevisaoLogId = P00712_A120RevisaoLogId[0];
            A122RevisaoLogObservacao = P00712_A122RevisaoLogObservacao[0];
            A121RevisaoLogUsuarioAlteracao = P00712_A121RevisaoLogUsuarioAlteracao[0];
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
            AV61GXV2 = 1;
            while ( AV61GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV61GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "RevisaoLogId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A120RevisaoLogId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "RevisaoLogUsuarioAlteracao") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A121RevisaoLogUsuarioAlteracao, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "RevisaoLogObservacao") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A122RevisaoLogObservacao, 1, 1000), out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "RevisaoLogDataAlteracao") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = A123RevisaoLogDataAlteracao;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocumentoId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A75DocumentoId;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV61GXV2 = (int)(AV61GXV2+1);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "RevisaoLogId",  "",  "Log Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "RevisaoLogUsuarioAlteracao",  "",  "Usuario Alteracao",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "RevisaoLogObservacao",  "",  "Log Observacao",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "RevisaoLogDataAlteracao",  "",  "Data Alteracao",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocumentoId",  "",  "do Documento",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "RevisaoLogWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("RevisaoLogWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RevisaoLogWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("RevisaoLogWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV62GXV3 = 1;
         while ( AV62GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV62GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGID") == 0 )
            {
               AV35TFRevisaoLogId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV36TFRevisaoLogId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO") == 0 )
            {
               AV37TFRevisaoLogUsuarioAlteracao = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGUSUARIOALTERACAO_SEL") == 0 )
            {
               AV38TFRevisaoLogUsuarioAlteracao_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO") == 0 )
            {
               AV39TFRevisaoLogObservacao = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGOBSERVACAO_SEL") == 0 )
            {
               AV40TFRevisaoLogObservacao_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFREVISAOLOGDATAALTERACAO") == 0 )
            {
               AV41TFRevisaoLogDataAlteracao = context.localUtil.CToT( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV42TFRevisaoLogDataAlteracao_To = context.localUtil.CToT( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOID") == 0 )
            {
               AV43TFDocumentoId = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
               AV44TFDocumentoId_To = (int)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV62GXV3 = (int)(AV62GXV3+1);
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
         AV38TFRevisaoLogUsuarioAlteracao_Sel = "";
         AV37TFRevisaoLogUsuarioAlteracao = "";
         AV40TFRevisaoLogObservacao_Sel = "";
         AV39TFRevisaoLogObservacao = "";
         AV41TFRevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         AV42TFRevisaoLogDataAlteracao_To = (DateTime)(DateTime.MinValue);
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV50Revisaologwwds_1_filterfulltext = "";
         AV53Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel = "";
         AV55Revisaologwwds_6_tfrevisaologobservacao = "";
         AV56Revisaologwwds_7_tfrevisaologobservacao_sel = "";
         AV57Revisaologwwds_8_tfrevisaologdataalteracao = (DateTime)(DateTime.MinValue);
         AV58Revisaologwwds_9_tfrevisaologdataalteracao_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV50Revisaologwwds_1_filterfulltext = "";
         lV53Revisaologwwds_4_tfrevisaologusuarioalteracao = "";
         lV55Revisaologwwds_6_tfrevisaologobservacao = "";
         A121RevisaoLogUsuarioAlteracao = "";
         A122RevisaoLogObservacao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         P00712_A75DocumentoId = new int[1] ;
         P00712_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P00712_A120RevisaoLogId = new int[1] ;
         P00712_A122RevisaoLogObservacao = new string[] {""} ;
         P00712_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.revisaologwwexport__default(),
            new Object[][] {
                new Object[] {
               P00712_A75DocumentoId, P00712_A123RevisaoLogDataAlteracao, P00712_A120RevisaoLogId, P00712_A122RevisaoLogObservacao, P00712_A121RevisaoLogUsuarioAlteracao
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
      private int AV35TFRevisaoLogId ;
      private int AV36TFRevisaoLogId_To ;
      private int AV43TFDocumentoId ;
      private int AV44TFDocumentoId_To ;
      private int AV48GXV1 ;
      private int AV51Revisaologwwds_2_tfrevisaologid ;
      private int AV52Revisaologwwds_3_tfrevisaologid_to ;
      private int AV59Revisaologwwds_10_tfdocumentoid ;
      private int AV60Revisaologwwds_11_tfdocumentoid_to ;
      private int A120RevisaoLogId ;
      private int A75DocumentoId ;
      private int AV61GXV2 ;
      private int AV62GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private DateTime AV41TFRevisaoLogDataAlteracao ;
      private DateTime AV42TFRevisaoLogDataAlteracao_To ;
      private DateTime AV57Revisaologwwds_8_tfrevisaologdataalteracao ;
      private DateTime AV58Revisaologwwds_9_tfrevisaologdataalteracao_to ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string A122RevisaoLogObservacao ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFRevisaoLogUsuarioAlteracao_Sel ;
      private string AV37TFRevisaoLogUsuarioAlteracao ;
      private string AV40TFRevisaoLogObservacao_Sel ;
      private string AV39TFRevisaoLogObservacao ;
      private string AV50Revisaologwwds_1_filterfulltext ;
      private string AV53Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ;
      private string AV55Revisaologwwds_6_tfrevisaologobservacao ;
      private string AV56Revisaologwwds_7_tfrevisaologobservacao_sel ;
      private string lV50Revisaologwwds_1_filterfulltext ;
      private string lV53Revisaologwwds_4_tfrevisaologusuarioalteracao ;
      private string lV55Revisaologwwds_6_tfrevisaologobservacao ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00712_A75DocumentoId ;
      private DateTime[] P00712_A123RevisaoLogDataAlteracao ;
      private int[] P00712_A120RevisaoLogId ;
      private string[] P00712_A122RevisaoLogObservacao ;
      private string[] P00712_A121RevisaoLogUsuarioAlteracao ;
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

   public class revisaologwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00712( IGxContext context ,
                                             string AV50Revisaologwwds_1_filterfulltext ,
                                             int AV51Revisaologwwds_2_tfrevisaologid ,
                                             int AV52Revisaologwwds_3_tfrevisaologid_to ,
                                             string AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel ,
                                             string AV53Revisaologwwds_4_tfrevisaologusuarioalteracao ,
                                             string AV56Revisaologwwds_7_tfrevisaologobservacao_sel ,
                                             string AV55Revisaologwwds_6_tfrevisaologobservacao ,
                                             DateTime AV57Revisaologwwds_8_tfrevisaologdataalteracao ,
                                             DateTime AV58Revisaologwwds_9_tfrevisaologdataalteracao_to ,
                                             int AV59Revisaologwwds_10_tfdocumentoid ,
                                             int AV60Revisaologwwds_11_tfdocumentoid_to ,
                                             int A120RevisaoLogId ,
                                             string A121RevisaoLogUsuarioAlteracao ,
                                             string A122RevisaoLogObservacao ,
                                             int A75DocumentoId ,
                                             DateTime A123RevisaoLogDataAlteracao ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [DocumentoId], [RevisaoLogDataAlteracao], [RevisaoLogId], [RevisaoLogObservacao], [RevisaoLogUsuarioAlteracao] FROM [RevisaoLog]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Revisaologwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(8), CAST([RevisaoLogId] AS decimal(8,0))) like '%' + @lV50Revisaologwwds_1_filterfulltext) or ( [RevisaoLogUsuarioAlteracao] like '%' + @lV50Revisaologwwds_1_filterfulltext) or ( [RevisaoLogObservacao] like '%' + @lV50Revisaologwwds_1_filterfulltext) or ( CONVERT( char(8), CAST([DocumentoId] AS decimal(8,0))) like '%' + @lV50Revisaologwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV51Revisaologwwds_2_tfrevisaologid) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] >= @AV51Revisaologwwds_2_tfrevisaologid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV52Revisaologwwds_3_tfrevisaologid_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogId] <= @AV52Revisaologwwds_3_tfrevisaologid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Revisaologwwds_4_tfrevisaologusuarioalteracao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] like @lV53Revisaologwwds_4_tfrevisaologusuarioalteracao)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)) && ! ( StringUtil.StrCmp(AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogUsuarioAlteracao] = @AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RevisaoLogUsuarioAlteracao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Revisaologwwds_7_tfrevisaologobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Revisaologwwds_6_tfrevisaologobservacao)) ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] like @lV55Revisaologwwds_6_tfrevisaologobservacao)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Revisaologwwds_7_tfrevisaologobservacao_sel)) && ! ( StringUtil.StrCmp(AV56Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RevisaoLogObservacao] = @AV56Revisaologwwds_7_tfrevisaologobservacao_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV56Revisaologwwds_7_tfrevisaologobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH([RevisaoLogObservacao])=0))");
         }
         if ( ! (DateTime.MinValue==AV57Revisaologwwds_8_tfrevisaologdataalteracao) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] >= @AV57Revisaologwwds_8_tfrevisaologdataalteracao)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Revisaologwwds_9_tfrevisaologdataalteracao_to) )
         {
            AddWhere(sWhereString, "([RevisaoLogDataAlteracao] <= @AV58Revisaologwwds_9_tfrevisaologdataalteracao_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV59Revisaologwwds_10_tfdocumentoid) )
         {
            AddWhere(sWhereString, "([DocumentoId] >= @AV59Revisaologwwds_10_tfdocumentoid)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV60Revisaologwwds_11_tfdocumentoid_to) )
         {
            AddWhere(sWhereString, "([DocumentoId] <= @AV60Revisaologwwds_11_tfdocumentoid_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogUsuarioAlteracao]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogUsuarioAlteracao] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogObservacao]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogObservacao] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RevisaoLogDataAlteracao]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RevisaoLogDataAlteracao] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentoId]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DocumentoId] DESC";
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
                     return conditional_P00712(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("@lV50Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV50Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Revisaologwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Revisaologwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV51Revisaologwwds_2_tfrevisaologid",GXType.Int32,8,0) ,
          new ParDef("@AV52Revisaologwwds_3_tfrevisaologid_to",GXType.Int32,8,0) ,
          new ParDef("@lV53Revisaologwwds_4_tfrevisaologusuarioalteracao",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Revisaologwwds_5_tfrevisaologusuarioalteracao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Revisaologwwds_6_tfrevisaologobservacao",GXType.NVarChar,200,0) ,
          new ParDef("@AV56Revisaologwwds_7_tfrevisaologobservacao_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV57Revisaologwwds_8_tfrevisaologdataalteracao",GXType.DateTime,8,5) ,
          new ParDef("@AV58Revisaologwwds_9_tfrevisaologdataalteracao_to",GXType.DateTime,8,5) ,
          new ParDef("@AV59Revisaologwwds_10_tfdocumentoid",GXType.Int32,8,0) ,
          new ParDef("@AV60Revisaologwwds_11_tfdocumentoid_to",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
