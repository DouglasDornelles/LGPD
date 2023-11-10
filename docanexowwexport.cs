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
   public class docanexowwexport : GXProcedure
   {
      public docanexowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docanexowwexport( IGxContext context )
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
         docanexowwexport objdocanexowwexport;
         objdocanexowwexport = new docanexowwexport();
         objdocanexowwexport.AV12Filename = "" ;
         objdocanexowwexport.AV13ErrorMessage = "" ;
         objdocanexowwexport.context.SetSubmitInitialConfig(context);
         objdocanexowwexport.initialize();
         Submit( executePrivateCatch,objdocanexowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((docanexowwexport)stateInfo).executePrivate();
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
         AV12Filename = "DocAnexoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocumentoNome_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Documento") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocumentoNome_Sel)) ? "(Vazio)" : AV45TFDocumentoNome_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocumentoNome)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Documento") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFDocumentoNome, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFDocAnexoDescricao_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFDocAnexoDescricao_Sel)) ? "(Vazio)" : AV40TFDocAnexoDescricao_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFDocAnexoDescricao)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFDocAnexoDescricao, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocAnexoArquivo_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Arquivo") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocAnexoArquivo_Sel)) ? "(Vazio)" : AV47TFDocAnexoArquivo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFDocAnexoArquivo)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Arquivo") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFDocAnexoArquivo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV41TFDocAnexoDataInclusao) && (DateTime.MinValue==AV42TFDocAnexoDataInclusao_To) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Data de Inclusão") ;
            AV14CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV41TFDocAnexoDataInclusao ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int1,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV42TFDocAnexoDataInclusao_To ) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("DocAnexoWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("DocAnexoWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV50GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Docanexowwds_1_filterfulltext = AV19FilterFullText;
         AV53Docanexowwds_2_tfdocumentonome = AV44TFDocumentoNome;
         AV54Docanexowwds_3_tfdocumentonome_sel = AV45TFDocumentoNome_Sel;
         AV55Docanexowwds_4_tfdocanexodescricao = AV39TFDocAnexoDescricao;
         AV56Docanexowwds_5_tfdocanexodescricao_sel = AV40TFDocAnexoDescricao_Sel;
         AV57Docanexowwds_6_tfdocanexoarquivo = AV46TFDocAnexoArquivo;
         AV58Docanexowwds_7_tfdocanexoarquivo_sel = AV47TFDocAnexoArquivo_Sel;
         AV59Docanexowwds_8_tfdocanexodatainclusao = AV41TFDocAnexoDataInclusao;
         AV60Docanexowwds_9_tfdocanexodatainclusao_to = AV42TFDocAnexoDataInclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Docanexowwds_1_filterfulltext ,
                                              AV54Docanexowwds_3_tfdocumentonome_sel ,
                                              AV53Docanexowwds_2_tfdocumentonome ,
                                              AV56Docanexowwds_5_tfdocanexodescricao_sel ,
                                              AV55Docanexowwds_4_tfdocanexodescricao ,
                                              AV58Docanexowwds_7_tfdocanexoarquivo_sel ,
                                              AV57Docanexowwds_6_tfdocanexoarquivo ,
                                              AV59Docanexowwds_8_tfdocanexodatainclusao ,
                                              AV60Docanexowwds_9_tfdocanexodatainclusao_to ,
                                              A76DocumentoNome ,
                                              A94DocAnexoDescricao ,
                                              A95DocAnexoArquivo ,
                                              A96DocAnexoDataInclusao ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Docanexowwds_1_filterfulltext), "%", "");
         lV52Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Docanexowwds_1_filterfulltext), "%", "");
         lV52Docanexowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Docanexowwds_1_filterfulltext), "%", "");
         lV53Docanexowwds_2_tfdocumentonome = StringUtil.Concat( StringUtil.RTrim( AV53Docanexowwds_2_tfdocumentonome), "%", "");
         lV55Docanexowwds_4_tfdocanexodescricao = StringUtil.Concat( StringUtil.RTrim( AV55Docanexowwds_4_tfdocanexodescricao), "%", "");
         lV57Docanexowwds_6_tfdocanexoarquivo = StringUtil.Concat( StringUtil.RTrim( AV57Docanexowwds_6_tfdocanexoarquivo), "%", "");
         /* Using cursor P004Y2 */
         pr_default.execute(0, new Object[] {lV52Docanexowwds_1_filterfulltext, lV52Docanexowwds_1_filterfulltext, lV52Docanexowwds_1_filterfulltext, lV53Docanexowwds_2_tfdocumentonome, AV54Docanexowwds_3_tfdocumentonome_sel, lV55Docanexowwds_4_tfdocanexodescricao, AV56Docanexowwds_5_tfdocanexodescricao_sel, lV57Docanexowwds_6_tfdocanexoarquivo, AV58Docanexowwds_7_tfdocanexoarquivo_sel, AV59Docanexowwds_8_tfdocanexodatainclusao, AV60Docanexowwds_9_tfdocanexodatainclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P004Y2_A75DocumentoId[0];
            A96DocAnexoDataInclusao = P004Y2_A96DocAnexoDataInclusao[0];
            A95DocAnexoArquivo = P004Y2_A95DocAnexoArquivo[0];
            A94DocAnexoDescricao = P004Y2_A94DocAnexoDescricao[0];
            A76DocumentoNome = P004Y2_A76DocumentoNome[0];
            n76DocumentoNome = P004Y2_n76DocumentoNome[0];
            A93DocAnexoId = P004Y2_A93DocAnexoId[0];
            A76DocumentoNome = P004Y2_A76DocumentoNome[0];
            n76DocumentoNome = P004Y2_n76DocumentoNome[0];
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
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocumentoNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A76DocumentoNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocAnexoDescricao") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A94DocAnexoDescricao, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocAnexoArquivo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A95DocAnexoArquivo, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "DocAnexoDataInclusao") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A96DocAnexoDataInclusao ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocumentoNome",  "",  "Documento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocAnexoDescricao",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocAnexoArquivo",  "",  "Arquivo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "DocAnexoDataInclusao",  "",  "Data de Inclusão",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocAnexoWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("DocAnexoWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocAnexoWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("DocAnexoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME") == 0 )
            {
               AV44TFDocumentoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCUMENTONOME_SEL") == 0 )
            {
               AV45TFDocumentoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCANEXODESCRICAO") == 0 )
            {
               AV39TFDocAnexoDescricao = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCANEXODESCRICAO_SEL") == 0 )
            {
               AV40TFDocAnexoDescricao_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCANEXOARQUIVO") == 0 )
            {
               AV46TFDocAnexoArquivo = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCANEXOARQUIVO_SEL") == 0 )
            {
               AV47TFDocAnexoArquivo_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFDOCANEXODATAINCLUSAO") == 0 )
            {
               AV41TFDocAnexoDataInclusao = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV42TFDocAnexoDataInclusao_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
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
         AV45TFDocumentoNome_Sel = "";
         AV44TFDocumentoNome = "";
         AV40TFDocAnexoDescricao_Sel = "";
         AV39TFDocAnexoDescricao = "";
         AV47TFDocAnexoArquivo_Sel = "";
         AV46TFDocAnexoArquivo = "";
         AV41TFDocAnexoDataInclusao = DateTime.MinValue;
         AV42TFDocAnexoDataInclusao_To = DateTime.MinValue;
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV52Docanexowwds_1_filterfulltext = "";
         AV53Docanexowwds_2_tfdocumentonome = "";
         AV54Docanexowwds_3_tfdocumentonome_sel = "";
         AV55Docanexowwds_4_tfdocanexodescricao = "";
         AV56Docanexowwds_5_tfdocanexodescricao_sel = "";
         AV57Docanexowwds_6_tfdocanexoarquivo = "";
         AV58Docanexowwds_7_tfdocanexoarquivo_sel = "";
         AV59Docanexowwds_8_tfdocanexodatainclusao = DateTime.MinValue;
         AV60Docanexowwds_9_tfdocanexodatainclusao_to = DateTime.MinValue;
         scmdbuf = "";
         lV52Docanexowwds_1_filterfulltext = "";
         lV53Docanexowwds_2_tfdocumentonome = "";
         lV55Docanexowwds_4_tfdocanexodescricao = "";
         lV57Docanexowwds_6_tfdocanexoarquivo = "";
         A76DocumentoNome = "";
         A94DocAnexoDescricao = "";
         A95DocAnexoArquivo = "";
         A96DocAnexoDataInclusao = DateTime.MinValue;
         P004Y2_A75DocumentoId = new int[1] ;
         P004Y2_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P004Y2_A95DocAnexoArquivo = new string[] {""} ;
         P004Y2_A94DocAnexoDescricao = new string[] {""} ;
         P004Y2_A76DocumentoNome = new string[] {""} ;
         P004Y2_n76DocumentoNome = new bool[] {false} ;
         P004Y2_A93DocAnexoId = new int[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docanexowwexport__default(),
            new Object[][] {
                new Object[] {
               P004Y2_A75DocumentoId, P004Y2_A96DocAnexoDataInclusao, P004Y2_A95DocAnexoArquivo, P004Y2_A94DocAnexoDescricao, P004Y2_A76DocumentoNome, P004Y2_n76DocumentoNome, P004Y2_A93DocAnexoId
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
      private int AV50GXV1 ;
      private int A75DocumentoId ;
      private int A93DocAnexoId ;
      private int AV61GXV2 ;
      private int AV62GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV41TFDocAnexoDataInclusao ;
      private DateTime AV42TFDocAnexoDataInclusao_To ;
      private DateTime AV59Docanexowwds_8_tfdocanexodatainclusao ;
      private DateTime AV60Docanexowwds_9_tfdocanexodatainclusao_to ;
      private DateTime A96DocAnexoDataInclusao ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n76DocumentoNome ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV45TFDocumentoNome_Sel ;
      private string AV44TFDocumentoNome ;
      private string AV40TFDocAnexoDescricao_Sel ;
      private string AV39TFDocAnexoDescricao ;
      private string AV47TFDocAnexoArquivo_Sel ;
      private string AV46TFDocAnexoArquivo ;
      private string AV52Docanexowwds_1_filterfulltext ;
      private string AV53Docanexowwds_2_tfdocumentonome ;
      private string AV54Docanexowwds_3_tfdocumentonome_sel ;
      private string AV55Docanexowwds_4_tfdocanexodescricao ;
      private string AV56Docanexowwds_5_tfdocanexodescricao_sel ;
      private string AV57Docanexowwds_6_tfdocanexoarquivo ;
      private string AV58Docanexowwds_7_tfdocanexoarquivo_sel ;
      private string lV52Docanexowwds_1_filterfulltext ;
      private string lV53Docanexowwds_2_tfdocumentonome ;
      private string lV55Docanexowwds_4_tfdocanexodescricao ;
      private string lV57Docanexowwds_6_tfdocanexoarquivo ;
      private string A76DocumentoNome ;
      private string A94DocAnexoDescricao ;
      private string A95DocAnexoArquivo ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004Y2_A75DocumentoId ;
      private DateTime[] P004Y2_A96DocAnexoDataInclusao ;
      private string[] P004Y2_A95DocAnexoArquivo ;
      private string[] P004Y2_A94DocAnexoDescricao ;
      private string[] P004Y2_A76DocumentoNome ;
      private bool[] P004Y2_n76DocumentoNome ;
      private int[] P004Y2_A93DocAnexoId ;
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

   public class docanexowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Y2( IGxContext context ,
                                             string AV52Docanexowwds_1_filterfulltext ,
                                             string AV54Docanexowwds_3_tfdocumentonome_sel ,
                                             string AV53Docanexowwds_2_tfdocumentonome ,
                                             string AV56Docanexowwds_5_tfdocanexodescricao_sel ,
                                             string AV55Docanexowwds_4_tfdocanexodescricao ,
                                             string AV58Docanexowwds_7_tfdocanexoarquivo_sel ,
                                             string AV57Docanexowwds_6_tfdocanexoarquivo ,
                                             DateTime AV59Docanexowwds_8_tfdocanexodatainclusao ,
                                             DateTime AV60Docanexowwds_9_tfdocanexodatainclusao_to ,
                                             string A76DocumentoNome ,
                                             string A94DocAnexoDescricao ,
                                             string A95DocAnexoArquivo ,
                                             DateTime A96DocAnexoDataInclusao ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentoId], T1.[DocAnexoDataInclusao], T1.[DocAnexoArquivo], T1.[DocAnexoDescricao], T2.[DocumentoNome], T1.[DocAnexoId] FROM ([DocAnexo] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Docanexowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.[DocumentoNome] like '%' + @lV52Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoDescricao] like '%' + @lV52Docanexowwds_1_filterfulltext) or ( T1.[DocAnexoArquivo] like '%' + @lV52Docanexowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_3_tfdocumentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Docanexowwds_2_tfdocumentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] like @lV53Docanexowwds_2_tfdocumentonome)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Docanexowwds_3_tfdocumentonome_sel)) && ! ( StringUtil.StrCmp(AV54Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] = @AV54Docanexowwds_3_tfdocumentonome_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV54Docanexowwds_3_tfdocumentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocumentoNome] IS NULL or (T2.[DocumentoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_5_tfdocanexodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Docanexowwds_4_tfdocanexodescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] like @lV55Docanexowwds_4_tfdocanexodescricao)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Docanexowwds_5_tfdocanexodescricao_sel)) && ! ( StringUtil.StrCmp(AV56Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDescricao] = @AV56Docanexowwds_5_tfdocanexodescricao_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV56Docanexowwds_5_tfdocanexodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Docanexowwds_7_tfdocanexoarquivo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Docanexowwds_6_tfdocanexoarquivo)) ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] like @lV57Docanexowwds_6_tfdocanexoarquivo)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Docanexowwds_7_tfdocanexoarquivo_sel)) && ! ( StringUtil.StrCmp(AV58Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoArquivo] = @AV58Docanexowwds_7_tfdocanexoarquivo_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Docanexowwds_7_tfdocanexoarquivo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[DocAnexoArquivo] = ''))");
         }
         if ( ! (DateTime.MinValue==AV59Docanexowwds_8_tfdocanexodatainclusao) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] >= @AV59Docanexowwds_8_tfdocanexodatainclusao)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Docanexowwds_9_tfdocanexodatainclusao_to) )
         {
            AddWhere(sWhereString, "(T1.[DocAnexoDataInclusao] <= @AV60Docanexowwds_9_tfdocanexodatainclusao_to)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDescricao]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDescricao] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DocumentoNome] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoArquivo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoArquivo] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDataInclusao]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DocAnexoDataInclusao] DESC";
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
                     return conditional_P004Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP004Y2;
          prmP004Y2 = new Object[] {
          new ParDef("@lV52Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV52Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV52Docanexowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Docanexowwds_2_tfdocumentonome",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Docanexowwds_3_tfdocumentonome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Docanexowwds_4_tfdocanexodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV56Docanexowwds_5_tfdocanexodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Docanexowwds_6_tfdocanexoarquivo",GXType.NVarChar,200,0) ,
          new ParDef("@AV58Docanexowwds_7_tfdocanexoarquivo_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV59Docanexowwds_8_tfdocanexodatainclusao",GXType.Date,8,0) ,
          new ParDef("@AV60Docanexowwds_9_tfdocanexodatainclusao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
