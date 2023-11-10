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
   public class parametrowwexport : GXProcedure
   {
      public parametrowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public parametrowwexport( IGxContext context )
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
         parametrowwexport objparametrowwexport;
         objparametrowwexport = new parametrowwexport();
         objparametrowwexport.AV12Filename = "" ;
         objparametrowwexport.AV13ErrorMessage = "" ;
         objparametrowwexport.context.SetSubmitInitialConfig(context);
         objparametrowwexport.initialize();
         Submit( executePrivateCatch,objparametrowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parametrowwexport)stateInfo).executePrivate();
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
         AV12Filename = "ParametroWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFParametroCod_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Código") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFParametroCod_Sel)) ? "(Vazio)" : AV36TFParametroCod_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFParametroCod)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Código") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFParametroCod, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFParametroDescricao_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFParametroDescricao_Sel)) ? "(Vazio)" : AV38TFParametroDescricao_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFParametroDescricao)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFParametroDescricao, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParametroValor_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Valor") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParametroValor_Sel)) ? "(Vazio)" : AV40TFParametroValor_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParametroValor)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Valor") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFParametroValor, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParametroComentario_Sel)) ) )
         {
            GXt_int1 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Comentário") ;
            AV14CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParametroComentario_Sel)) ? "(Vazio)" : AV42TFParametroComentario_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParametroComentario)) ) )
            {
               GXt_int1 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int1,  (short)(AV15FirstColumn),  "Comentário") ;
               AV14CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFParametroComentario, out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("ParametroWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("ParametroWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV55GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Parametrowwds_1_filterfulltext = AV19FilterFullText;
         AV58Parametrowwds_2_tfparametrocod = AV35TFParametroCod;
         AV59Parametrowwds_3_tfparametrocod_sel = AV36TFParametroCod_Sel;
         AV60Parametrowwds_4_tfparametrodescricao = AV37TFParametroDescricao;
         AV61Parametrowwds_5_tfparametrodescricao_sel = AV38TFParametroDescricao_Sel;
         AV62Parametrowwds_6_tfparametrovalor = AV39TFParametroValor;
         AV63Parametrowwds_7_tfparametrovalor_sel = AV40TFParametroValor_Sel;
         AV64Parametrowwds_8_tfparametrocomentario = AV41TFParametroComentario;
         AV65Parametrowwds_9_tfparametrocomentario_sel = AV42TFParametroComentario_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Parametrowwds_1_filterfulltext ,
                                              AV59Parametrowwds_3_tfparametrocod_sel ,
                                              AV58Parametrowwds_2_tfparametrocod ,
                                              AV61Parametrowwds_5_tfparametrodescricao_sel ,
                                              AV60Parametrowwds_4_tfparametrodescricao ,
                                              AV63Parametrowwds_7_tfparametrovalor_sel ,
                                              AV62Parametrowwds_6_tfparametrovalor ,
                                              AV65Parametrowwds_9_tfparametrocomentario_sel ,
                                              AV64Parametrowwds_8_tfparametrocomentario ,
                                              A124ParametroCod ,
                                              A125ParametroDescricao ,
                                              A126ParametroValor ,
                                              A127ParametroComentario ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV57Parametrowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext), "%", "");
         lV58Parametrowwds_2_tfparametrocod = StringUtil.PadR( StringUtil.RTrim( AV58Parametrowwds_2_tfparametrocod), 10, "%");
         lV60Parametrowwds_4_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV60Parametrowwds_4_tfparametrodescricao), "%", "");
         lV62Parametrowwds_6_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Parametrowwds_6_tfparametrovalor), "%", "");
         lV64Parametrowwds_8_tfparametrocomentario = StringUtil.Concat( StringUtil.RTrim( AV64Parametrowwds_8_tfparametrocomentario), "%", "");
         /* Using cursor P006H2 */
         pr_default.execute(0, new Object[] {lV57Parametrowwds_1_filterfulltext, lV57Parametrowwds_1_filterfulltext, lV57Parametrowwds_1_filterfulltext, lV57Parametrowwds_1_filterfulltext, lV58Parametrowwds_2_tfparametrocod, AV59Parametrowwds_3_tfparametrocod_sel, lV60Parametrowwds_4_tfparametrodescricao, AV61Parametrowwds_5_tfparametrodescricao_sel, lV62Parametrowwds_6_tfparametrovalor, AV63Parametrowwds_7_tfparametrovalor_sel, lV64Parametrowwds_8_tfparametrocomentario, AV65Parametrowwds_9_tfparametrocomentario_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127ParametroComentario = P006H2_A127ParametroComentario[0];
            A126ParametroValor = P006H2_A126ParametroValor[0];
            A125ParametroDescricao = P006H2_A125ParametroDescricao[0];
            A124ParametroCod = P006H2_A124ParametroCod[0];
            A132ParametroAtivo = P006H2_A132ParametroAtivo[0];
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
            AV66GXV2 = 1;
            while ( AV66GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV66GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ParametroCod") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A124ParametroCod, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ParametroDescricao") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A125ParametroDescricao, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ParametroValor") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A126ParametroValor, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ParametroComentario") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A127ParametroComentario, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV66GXV2 = (int)(AV66GXV2+1);
            }
            if ( A132ParametroAtivo )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV32VisibleColumnCount)).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( ! A132ParametroAtivo )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ParametroCod",  "",  "Código",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ParametroDescricao",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ParametroValor",  "",  "Valor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ParametroComentario",  "",  "Comentário",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ParametroWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("ParametroWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametroWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("ParametroWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV67GXV3 = 1;
         while ( AV67GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV67GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD") == 0 )
            {
               AV35TFParametroCod = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOD_SEL") == 0 )
            {
               AV36TFParametroCod_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV37TFParametroDescricao = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV38TFParametroDescricao_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV39TFParametroValor = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV40TFParametroValor_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO") == 0 )
            {
               AV41TFParametroComentario = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPARAMETROCOMENTARIO_SEL") == 0 )
            {
               AV42TFParametroComentario_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV67GXV3 = (int)(AV67GXV3+1);
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
         AV36TFParametroCod_Sel = "";
         AV35TFParametroCod = "";
         AV38TFParametroDescricao_Sel = "";
         AV37TFParametroDescricao = "";
         AV40TFParametroValor_Sel = "";
         AV39TFParametroValor = "";
         AV42TFParametroComentario_Sel = "";
         AV41TFParametroComentario = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV57Parametrowwds_1_filterfulltext = "";
         AV58Parametrowwds_2_tfparametrocod = "";
         AV59Parametrowwds_3_tfparametrocod_sel = "";
         AV60Parametrowwds_4_tfparametrodescricao = "";
         AV61Parametrowwds_5_tfparametrodescricao_sel = "";
         AV62Parametrowwds_6_tfparametrovalor = "";
         AV63Parametrowwds_7_tfparametrovalor_sel = "";
         AV64Parametrowwds_8_tfparametrocomentario = "";
         AV65Parametrowwds_9_tfparametrocomentario_sel = "";
         scmdbuf = "";
         lV57Parametrowwds_1_filterfulltext = "";
         lV58Parametrowwds_2_tfparametrocod = "";
         lV60Parametrowwds_4_tfparametrodescricao = "";
         lV62Parametrowwds_6_tfparametrovalor = "";
         lV64Parametrowwds_8_tfparametrocomentario = "";
         A124ParametroCod = "";
         A125ParametroDescricao = "";
         A126ParametroValor = "";
         A127ParametroComentario = "";
         P006H2_A127ParametroComentario = new string[] {""} ;
         P006H2_A126ParametroValor = new string[] {""} ;
         P006H2_A125ParametroDescricao = new string[] {""} ;
         P006H2_A124ParametroCod = new string[] {""} ;
         P006H2_A132ParametroAtivo = new bool[] {false} ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametrowwexport__default(),
            new Object[][] {
                new Object[] {
               P006H2_A127ParametroComentario, P006H2_A126ParametroValor, P006H2_A125ParametroDescricao, P006H2_A124ParametroCod, P006H2_A132ParametroAtivo
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
      private int AV55GXV1 ;
      private int AV66GXV2 ;
      private int AV67GXV3 ;
      private long AV32VisibleColumnCount ;
      private string AV36TFParametroCod_Sel ;
      private string AV35TFParametroCod ;
      private string AV58Parametrowwds_2_tfparametrocod ;
      private string AV59Parametrowwds_3_tfparametrocod_sel ;
      private string scmdbuf ;
      private string lV58Parametrowwds_2_tfparametrocod ;
      private string A124ParametroCod ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool A132ParametroAtivo ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFParametroDescricao_Sel ;
      private string AV37TFParametroDescricao ;
      private string AV40TFParametroValor_Sel ;
      private string AV39TFParametroValor ;
      private string AV42TFParametroComentario_Sel ;
      private string AV41TFParametroComentario ;
      private string AV57Parametrowwds_1_filterfulltext ;
      private string AV60Parametrowwds_4_tfparametrodescricao ;
      private string AV61Parametrowwds_5_tfparametrodescricao_sel ;
      private string AV62Parametrowwds_6_tfparametrovalor ;
      private string AV63Parametrowwds_7_tfparametrovalor_sel ;
      private string AV64Parametrowwds_8_tfparametrocomentario ;
      private string AV65Parametrowwds_9_tfparametrocomentario_sel ;
      private string lV57Parametrowwds_1_filterfulltext ;
      private string lV60Parametrowwds_4_tfparametrodescricao ;
      private string lV62Parametrowwds_6_tfparametrovalor ;
      private string lV64Parametrowwds_8_tfparametrocomentario ;
      private string A125ParametroDescricao ;
      private string A126ParametroValor ;
      private string A127ParametroComentario ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006H2_A127ParametroComentario ;
      private string[] P006H2_A126ParametroValor ;
      private string[] P006H2_A125ParametroDescricao ;
      private string[] P006H2_A124ParametroCod ;
      private bool[] P006H2_A132ParametroAtivo ;
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

   public class parametrowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006H2( IGxContext context ,
                                             string AV57Parametrowwds_1_filterfulltext ,
                                             string AV59Parametrowwds_3_tfparametrocod_sel ,
                                             string AV58Parametrowwds_2_tfparametrocod ,
                                             string AV61Parametrowwds_5_tfparametrodescricao_sel ,
                                             string AV60Parametrowwds_4_tfparametrodescricao ,
                                             string AV63Parametrowwds_7_tfparametrovalor_sel ,
                                             string AV62Parametrowwds_6_tfparametrovalor ,
                                             string AV65Parametrowwds_9_tfparametrocomentario_sel ,
                                             string AV64Parametrowwds_8_tfparametrocomentario ,
                                             string A124ParametroCod ,
                                             string A125ParametroDescricao ,
                                             string A126ParametroValor ,
                                             string A127ParametroComentario ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ParametroComentario], [ParametroValor], [ParametroDescricao], [ParametroCod], [ParametroAtivo] FROM [Parametro]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Parametrowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( [ParametroCod] like '%' + @lV57Parametrowwds_1_filterfulltext) or ( [ParametroDescricao] like '%' + @lV57Parametrowwds_1_filterfulltext) or ( [ParametroValor] like '%' + @lV57Parametrowwds_1_filterfulltext) or ( [ParametroComentario] like '%' + @lV57Parametrowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_3_tfparametrocod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Parametrowwds_2_tfparametrocod)) ) )
         {
            AddWhere(sWhereString, "([ParametroCod] like @lV58Parametrowwds_2_tfparametrocod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Parametrowwds_3_tfparametrocod_sel)) && ! ( StringUtil.StrCmp(AV59Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroCod] = @AV59Parametrowwds_3_tfparametrocod_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Parametrowwds_3_tfparametrocod_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroCod] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_5_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Parametrowwds_4_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] like @lV60Parametrowwds_4_tfparametrodescricao)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametrowwds_5_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV61Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroDescricao] = @AV61Parametrowwds_5_tfparametrodescricao_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Parametrowwds_5_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroDescricao] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_7_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Parametrowwds_6_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "([ParametroValor] like @lV62Parametrowwds_6_tfparametrovalor)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametrowwds_7_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV63Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroValor] = @AV63Parametrowwds_7_tfparametrovalor_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Parametrowwds_7_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroValor] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Parametrowwds_9_tfparametrocomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Parametrowwds_8_tfparametrocomentario)) ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] like @lV64Parametrowwds_8_tfparametrocomentario)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Parametrowwds_9_tfparametrocomentario_sel)) && ! ( StringUtil.StrCmp(AV65Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroComentario] = @AV65Parametrowwds_9_tfparametrocomentario_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Parametrowwds_9_tfparametrocomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroComentario] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroDescricao]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroDescricao] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroCod]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroCod] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroValor]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroValor] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroComentario]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroComentario] DESC";
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
                     return conditional_P006H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP006H2;
          prmP006H2 = new Object[] {
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Parametrowwds_1_filterfulltext",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Parametrowwds_2_tfparametrocod",GXType.NChar,10,0) ,
          new ParDef("@AV59Parametrowwds_3_tfparametrocod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV60Parametrowwds_4_tfparametrodescricao",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Parametrowwds_5_tfparametrodescricao_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Parametrowwds_6_tfparametrovalor",GXType.NVarChar,100,0) ,
          new ParDef("@AV63Parametrowwds_7_tfparametrovalor_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV64Parametrowwds_8_tfparametrocomentario",GXType.NVarChar,500,0) ,
          new ParDef("@AV65Parametrowwds_9_tfparametrocomentario_sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
       }
    }

 }

}
