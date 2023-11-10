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
   public class tooltipwwexport : GXProcedure
   {
      public tooltipwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tooltipwwexport( IGxContext context )
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
         tooltipwwexport objtooltipwwexport;
         objtooltipwwexport = new tooltipwwexport();
         objtooltipwwexport.AV12Filename = "" ;
         objtooltipwwexport.AV13ErrorMessage = "" ;
         objtooltipwwexport.context.SetSubmitInitialConfig(context);
         objtooltipwwexport.initialize();
         Submit( executePrivateCatch,objtooltipwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tooltipwwexport)stateInfo).executePrivate();
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
         AV12Filename = "TooltipWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTooltipTelaNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "TELA") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTooltipTelaNome_Sel)) ? "(Vazio)" : AV48TFTooltipTelaNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFTooltipTelaNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "TELA") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFTooltipTelaNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCampoNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "CAMPO") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCampoNome_Sel)) ? "(Vazio)" : AV45TFCampoNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCampoNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "CAMPO") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFCampoNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTooltipDescricao_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "DESCRIÇÃO") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTooltipDescricao_Sel)) ? "(Vazio)" : StringUtil.Substring( AV40TFTooltipDescricao_Sel, 1, 1000)), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTooltipDescricao)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "DESCRIÇÃO") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV39TFTooltipDescricao, 1, 1000), out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( ! ( (0==AV41TFTooltipAtivo_Sel) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "ATIVO") ;
               AV14CellRow = GXt_int1;
               if ( AV41TFTooltipAtivo_Sel == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
               }
               else if ( AV41TFTooltipAtivo_Sel == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
               }
            }
            AV14CellRow = (int)(AV14CellRow+2);
         }
         else
         {
            AV49IsOk = false;
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Filtro principal") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV49IsOk = true;
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTooltipTelaNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "TELA") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTooltipTelaNome_Sel)) ? "(Vazio)" : AV48TFTooltipTelaNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV49IsOk = true;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFTooltipTelaNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "TELA") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFTooltipTelaNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  AV49IsOk = true;
               }
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCampoNome_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "CAMPO") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCampoNome_Sel)) ? "(Vazio)" : AV45TFCampoNome_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV49IsOk = true;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCampoNome)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "CAMPO") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFCampoNome, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  AV49IsOk = true;
               }
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTooltipDescricao_Sel)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "DESCRIÇÃO") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTooltipDescricao_Sel)) ? "(Vazio)" : StringUtil.Substring( AV40TFTooltipDescricao_Sel, 1, 1000)), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV49IsOk = true;
            }
            else
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTooltipDescricao)) ) )
               {
                  GXt_int1 = (short)(AV14CellRow);
                  new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "DESCRIÇÃO") ;
                  AV14CellRow = GXt_int1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV39TFTooltipDescricao, 1, 1000), out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  AV49IsOk = true;
               }
            }
            if ( ! ( (0==AV41TFTooltipAtivo_Sel) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "ATIVO") ;
               AV14CellRow = GXt_int1;
               if ( AV41TFTooltipAtivo_Sel == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
               }
               else if ( AV41TFTooltipAtivo_Sel == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
               }
               AV49IsOk = true;
            }
            if ( AV49IsOk )
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
         if ( StringUtil.StrCmp(AV20Session.Get("TooltipWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("TooltipWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV52GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Tooltipwwds_1_filterfulltext = AV19FilterFullText;
         AV55Tooltipwwds_2_tftooltiptelanome = AV47TFTooltipTelaNome;
         AV56Tooltipwwds_3_tftooltiptelanome_sel = AV48TFTooltipTelaNome_Sel;
         AV57Tooltipwwds_4_tfcamponome = AV44TFCampoNome;
         AV58Tooltipwwds_5_tfcamponome_sel = AV45TFCampoNome_Sel;
         AV59Tooltipwwds_6_tftooltipdescricao = AV39TFTooltipDescricao;
         AV60Tooltipwwds_7_tftooltipdescricao_sel = AV40TFTooltipDescricao_Sel;
         AV61Tooltipwwds_8_tftooltipativo_sel = AV41TFTooltipAtivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Tooltipwwds_1_filterfulltext ,
                                              AV56Tooltipwwds_3_tftooltiptelanome_sel ,
                                              AV55Tooltipwwds_2_tftooltiptelanome ,
                                              AV58Tooltipwwds_5_tfcamponome_sel ,
                                              AV57Tooltipwwds_4_tfcamponome ,
                                              AV60Tooltipwwds_7_tftooltipdescricao_sel ,
                                              AV59Tooltipwwds_6_tftooltipdescricao ,
                                              AV61Tooltipwwds_8_tftooltipativo_sel ,
                                              A140TooltipTelaNome ,
                                              A136CampoNome ,
                                              A115TooltipDescricao ,
                                              A118TooltipAtivo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_1_filterfulltext), "%", "");
         lV54Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_1_filterfulltext), "%", "");
         lV54Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_1_filterfulltext), "%", "");
         lV54Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_1_filterfulltext), "%", "");
         lV54Tooltipwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Tooltipwwds_1_filterfulltext), "%", "");
         lV55Tooltipwwds_2_tftooltiptelanome = StringUtil.Concat( StringUtil.RTrim( AV55Tooltipwwds_2_tftooltiptelanome), "%", "");
         lV57Tooltipwwds_4_tfcamponome = StringUtil.Concat( StringUtil.RTrim( AV57Tooltipwwds_4_tfcamponome), "%", "");
         lV59Tooltipwwds_6_tftooltipdescricao = StringUtil.Concat( StringUtil.RTrim( AV59Tooltipwwds_6_tftooltipdescricao), "%", "");
         /* Using cursor P006U2 */
         pr_default.execute(0, new Object[] {lV54Tooltipwwds_1_filterfulltext, lV54Tooltipwwds_1_filterfulltext, lV54Tooltipwwds_1_filterfulltext, lV54Tooltipwwds_1_filterfulltext, lV54Tooltipwwds_1_filterfulltext, lV55Tooltipwwds_2_tftooltiptelanome, AV56Tooltipwwds_3_tftooltiptelanome_sel, lV57Tooltipwwds_4_tfcamponome, AV58Tooltipwwds_5_tfcamponome_sel, lV59Tooltipwwds_6_tftooltipdescricao, AV60Tooltipwwds_7_tftooltipdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135CampoId = P006U2_A135CampoId[0];
            A139TooltipTelaId = P006U2_A139TooltipTelaId[0];
            A118TooltipAtivo = P006U2_A118TooltipAtivo[0];
            A115TooltipDescricao = P006U2_A115TooltipDescricao[0];
            A136CampoNome = P006U2_A136CampoNome[0];
            A140TooltipTelaNome = P006U2_A140TooltipTelaNome[0];
            A112TooltipId = P006U2_A112TooltipId[0];
            A136CampoNome = P006U2_A136CampoNome[0];
            A140TooltipTelaNome = P006U2_A140TooltipTelaNome[0];
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
            AV62GXV2 = 1;
            while ( AV62GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV62GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TooltipTelaNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A140TooltipTelaNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "CampoNome") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A136CampoNome, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TooltipDescricao") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A115TooltipDescricao, 1, 1000), out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TooltipAtivo") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A118TooltipAtivo)), "true") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "SIM";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A118TooltipAtivo)), "false") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "NÃO";
                     }
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV62GXV2 = (int)(AV62GXV2+1);
            }
            if ( A118TooltipAtivo )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV32VisibleColumnCount)).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( ! A118TooltipAtivo )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TooltipTelaNome",  "",  "TELA",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "CampoNome",  "",  "CAMPO",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TooltipDescricao",  "",  "DESCRIÇÃO",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TooltipAtivo",  "",  "ATIVO",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "TooltipWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("TooltipWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TooltipWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("TooltipWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV63GXV3 = 1;
         while ( AV63GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV63GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTOOLTIPTELANOME") == 0 )
            {
               AV47TFTooltipTelaNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTOOLTIPTELANOME_SEL") == 0 )
            {
               AV48TFTooltipTelaNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCAMPONOME") == 0 )
            {
               AV44TFCampoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCAMPONOME_SEL") == 0 )
            {
               AV45TFCampoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTOOLTIPDESCRICAO") == 0 )
            {
               AV39TFTooltipDescricao = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTOOLTIPDESCRICAO_SEL") == 0 )
            {
               AV40TFTooltipDescricao_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTOOLTIPATIVO_SEL") == 0 )
            {
               AV41TFTooltipAtivo_Sel = (short)(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."));
            }
            AV63GXV3 = (int)(AV63GXV3+1);
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
         AV48TFTooltipTelaNome_Sel = "";
         AV47TFTooltipTelaNome = "";
         AV45TFCampoNome_Sel = "";
         AV44TFCampoNome = "";
         AV40TFTooltipDescricao_Sel = "";
         AV39TFTooltipDescricao = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV54Tooltipwwds_1_filterfulltext = "";
         AV55Tooltipwwds_2_tftooltiptelanome = "";
         AV56Tooltipwwds_3_tftooltiptelanome_sel = "";
         AV57Tooltipwwds_4_tfcamponome = "";
         AV58Tooltipwwds_5_tfcamponome_sel = "";
         AV59Tooltipwwds_6_tftooltipdescricao = "";
         AV60Tooltipwwds_7_tftooltipdescricao_sel = "";
         scmdbuf = "";
         lV54Tooltipwwds_1_filterfulltext = "";
         lV55Tooltipwwds_2_tftooltiptelanome = "";
         lV57Tooltipwwds_4_tfcamponome = "";
         lV59Tooltipwwds_6_tftooltipdescricao = "";
         A140TooltipTelaNome = "";
         A136CampoNome = "";
         A115TooltipDescricao = "";
         P006U2_A135CampoId = new int[1] ;
         P006U2_A139TooltipTelaId = new int[1] ;
         P006U2_A118TooltipAtivo = new bool[] {false} ;
         P006U2_A115TooltipDescricao = new string[] {""} ;
         P006U2_A136CampoNome = new string[] {""} ;
         P006U2_A140TooltipTelaNome = new string[] {""} ;
         P006U2_A112TooltipId = new int[1] ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tooltipwwexport__default(),
            new Object[][] {
                new Object[] {
               P006U2_A135CampoId, P006U2_A139TooltipTelaId, P006U2_A118TooltipAtivo, P006U2_A115TooltipDescricao, P006U2_A136CampoNome, P006U2_A140TooltipTelaNome, P006U2_A112TooltipId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41TFTooltipAtivo_Sel ;
      private short GXt_int1 ;
      private short AV61Tooltipwwds_8_tftooltipativo_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV52GXV1 ;
      private int A135CampoId ;
      private int A139TooltipTelaId ;
      private int A112TooltipId ;
      private int AV62GXV2 ;
      private int AV63GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV49IsOk ;
      private bool A118TooltipAtivo ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string A115TooltipDescricao ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV48TFTooltipTelaNome_Sel ;
      private string AV47TFTooltipTelaNome ;
      private string AV45TFCampoNome_Sel ;
      private string AV44TFCampoNome ;
      private string AV40TFTooltipDescricao_Sel ;
      private string AV39TFTooltipDescricao ;
      private string AV54Tooltipwwds_1_filterfulltext ;
      private string AV55Tooltipwwds_2_tftooltiptelanome ;
      private string AV56Tooltipwwds_3_tftooltiptelanome_sel ;
      private string AV57Tooltipwwds_4_tfcamponome ;
      private string AV58Tooltipwwds_5_tfcamponome_sel ;
      private string AV59Tooltipwwds_6_tftooltipdescricao ;
      private string AV60Tooltipwwds_7_tftooltipdescricao_sel ;
      private string lV54Tooltipwwds_1_filterfulltext ;
      private string lV55Tooltipwwds_2_tftooltiptelanome ;
      private string lV57Tooltipwwds_4_tfcamponome ;
      private string lV59Tooltipwwds_6_tftooltipdescricao ;
      private string A140TooltipTelaNome ;
      private string A136CampoNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006U2_A135CampoId ;
      private int[] P006U2_A139TooltipTelaId ;
      private bool[] P006U2_A118TooltipAtivo ;
      private string[] P006U2_A115TooltipDescricao ;
      private string[] P006U2_A136CampoNome ;
      private string[] P006U2_A140TooltipTelaNome ;
      private int[] P006U2_A112TooltipId ;
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

   public class tooltipwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006U2( IGxContext context ,
                                             string AV54Tooltipwwds_1_filterfulltext ,
                                             string AV56Tooltipwwds_3_tftooltiptelanome_sel ,
                                             string AV55Tooltipwwds_2_tftooltiptelanome ,
                                             string AV58Tooltipwwds_5_tfcamponome_sel ,
                                             string AV57Tooltipwwds_4_tfcamponome ,
                                             string AV60Tooltipwwds_7_tftooltipdescricao_sel ,
                                             string AV59Tooltipwwds_6_tftooltipdescricao ,
                                             short AV61Tooltipwwds_8_tftooltipativo_sel ,
                                             string A140TooltipTelaNome ,
                                             string A136CampoNome ,
                                             string A115TooltipDescricao ,
                                             bool A118TooltipAtivo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CampoId], T1.[TooltipTelaId] AS TooltipTelaId, T1.[TooltipAtivo], T1.[TooltipDescricao], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, T1.[TooltipId] FROM (([Tooltip] T1 INNER JOIN [Campo] T2 ON T2.[CampoId] = T1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = T1.[TooltipTelaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Tooltipwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.[TelaNome] like '%' + @lV54Tooltipwwds_1_filterfulltext) or ( T2.[CampoNome] like '%' + @lV54Tooltipwwds_1_filterfulltext) or ( T1.[TooltipDescricao] like '%' + @lV54Tooltipwwds_1_filterfulltext) or ( 'sim' like '%' + LOWER(@lV54Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 1) or ( 'não' like '%' + LOWER(@lV54Tooltipwwds_1_filterfulltext) and T1.[TooltipAtivo] = 0))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Tooltipwwds_3_tftooltiptelanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Tooltipwwds_2_tftooltiptelanome)) ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] like @lV55Tooltipwwds_2_tftooltiptelanome)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tooltipwwds_3_tftooltiptelanome_sel)) && ! ( StringUtil.StrCmp(AV56Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TelaNome] = @AV56Tooltipwwds_3_tftooltiptelanome_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV56Tooltipwwds_3_tftooltiptelanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[TelaNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Tooltipwwds_5_tfcamponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tooltipwwds_4_tfcamponome)) ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] like @lV57Tooltipwwds_4_tfcamponome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Tooltipwwds_5_tfcamponome_sel)) && ! ( StringUtil.StrCmp(AV58Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CampoNome] = @AV58Tooltipwwds_5_tfcamponome_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Tooltipwwds_5_tfcamponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CampoNome] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Tooltipwwds_7_tftooltipdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Tooltipwwds_6_tftooltipdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] like @lV59Tooltipwwds_6_tftooltipdescricao)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tooltipwwds_7_tftooltipdescricao_sel)) && ! ( StringUtil.StrCmp(AV60Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[TooltipDescricao] = @AV60Tooltipwwds_7_tftooltipdescricao_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV60Tooltipwwds_7_tftooltipdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[TooltipDescricao])=0))");
         }
         if ( AV61Tooltipwwds_8_tftooltipativo_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 1)");
         }
         if ( AV61Tooltipwwds_8_tftooltipativo_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[TooltipAtivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TooltipAtivo]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TooltipAtivo] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[TelaNome]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[TelaNome] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[CampoNome]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[CampoNome] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TooltipDescricao]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TooltipDescricao] DESC";
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
                     return conditional_P006U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] );
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
          Object[] prmP006U2;
          prmP006U2 = new Object[] {
          new ParDef("@lV54Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Tooltipwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Tooltipwwds_2_tftooltiptelanome",GXType.NVarChar,100,0) ,
          new ParDef("@AV56Tooltipwwds_3_tftooltiptelanome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Tooltipwwds_4_tfcamponome",GXType.NVarChar,100,0) ,
          new ParDef("@AV58Tooltipwwds_5_tfcamponome_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Tooltipwwds_6_tftooltipdescricao",GXType.NVarChar,200,0) ,
          new ParDef("@AV60Tooltipwwds_7_tftooltipdescricao_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
