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
   public class documentorelatorioexcel : GXProcedure
   {
      public documentorelatorioexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentorelatorioexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           out string aP1_Filename ,
                           out string aP2_Caminho )
      {
         this.AV8DocumentoId = aP0_DocumentoId;
         this.AV11Filename = "" ;
         this.AV17Caminho = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV11Filename;
         aP2_Caminho=this.AV17Caminho;
      }

      public string executeUdp( int aP0_DocumentoId ,
                                out string aP1_Filename )
      {
         execute(aP0_DocumentoId, out aP1_Filename, out aP2_Caminho);
         return AV17Caminho ;
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 out string aP1_Filename ,
                                 out string aP2_Caminho )
      {
         documentorelatorioexcel objdocumentorelatorioexcel;
         objdocumentorelatorioexcel = new documentorelatorioexcel();
         objdocumentorelatorioexcel.AV8DocumentoId = aP0_DocumentoId;
         objdocumentorelatorioexcel.AV11Filename = "" ;
         objdocumentorelatorioexcel.AV17Caminho = "" ;
         objdocumentorelatorioexcel.context.SetSubmitInitialConfig(context);
         objdocumentorelatorioexcel.initialize();
         Submit( executePrivateCatch,objdocumentorelatorioexcel);
         aP1_Filename=this.AV11Filename;
         aP2_Caminho=this.AV17Caminho;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentorelatorioexcel)stateInfo).executePrivate();
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
         AV9Linha = 1;
         AV14Coluna = 1;
         /* Execute user subroutine: 'ABREDOCUMENTO' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'ESCREVECABECALHO' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'ESCREVEDADOS' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'FECHADOCUMENTO' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ABREDOCUMENTO' Routine */
         returnInSub = false;
         /* Using cursor P006B3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000ParametroValor = P006B3_A40000ParametroValor[0];
            n40000ParametroValor = P006B3_n40000ParametroValor[0];
         }
         else
         {
            A40000ParametroValor = "";
            n40000ParametroValor = false;
         }
         pr_default.close(0);
         AV11Filename = "Documento_" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8DocumentoId), 8, 0)) + ".xlsx";
         AV16Directory.Source = "C:\\Excel\\";
         if ( ! AV16Directory.Exists() )
         {
            AV16Directory.Create();
         }
         AV17Caminho = AV16Directory.GetAbsoluteName() + StringUtil.Trim( AV11Filename);
         AV23ParametroValor = A40000ParametroValor;
         AV22DirectoryServidor.Source = AV23ParametroValor+"Template\\";
         if ( ! AV22DirectoryServidor.Exists() )
         {
            AV22DirectoryServidor.Create();
         }
         AV21CaminhoServidor = AV22DirectoryServidor.GetAbsoluteName();
         AV13ExcelDocument.Template = AV21CaminhoServidor+"ModeloExcel.xlsx";
         AV13ExcelDocument.Open(AV17Caminho);
         /* Execute user subroutine: 'VERIFICASTATUS' */
         S121 ();
         if (returnInSub) return;
      }

      protected void S131( )
      {
         /* 'FECHADOCUMENTO' Routine */
         returnInSub = false;
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'VERIFICASTATUS' */
         S121 ();
         if (returnInSub) return;
         AV13ExcelDocument.Close();
      }

      protected void S121( )
      {
         /* 'VERIFICASTATUS' Routine */
         returnInSub = false;
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV15ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV13ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S141( )
      {
         /* 'ESCREVECABECALHO' Routine */
         returnInSub = false;
         AV13ExcelDocument.SelectSheet("DOCUMENTO");
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+9, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+10, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+11, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = "NOME DO DOCUMENTO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = "PROCESSO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = "SUBPROCESSO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = "ÁREA RESPONSÁVEL";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = "CONTROLADOR";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = "PERSONA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Text = "ENCARREGADO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Text = "USUÁRIO DE INCLUSÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Text = "DATA DE INCLUSÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+9, 1, 1).Text = "USUÁRIO DE ALTERAÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+10, 1, 1).Text = "DATA DE ALTERAÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+11, 1, 1).Text = "CÓDIGO";
         AV13ExcelDocument.SelectSheet("TRATAMENTO");
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+9, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+10, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+11, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+12, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+13, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+14, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+15, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+16, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+17, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+18, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+19, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = "FINALIDADE DO TRATAMENTO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = "CATEGORIA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = "TIPO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = "FERRAMENTA DE COLETA DE DADOS";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = "ABRANGÊNCIA/ÁREA GEOGRÁFICA DO TRATAMENTO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = "FREQUÊNCIA DE TRATAMENTO DOS DADOS";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Text = "FONTE(S) DE RETENÇÃO/ARMAZENAMENTO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Text = "TIPO DESCARTE";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Text = "TEMPO DE GUARDA/RETENÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+9, 1, 1).Text = "PREVISÃO PARA COLETA DE DADOS";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+10, 1, 1).Text = "PREVISÃO LEGAL";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+11, 1, 1).Text = "PREVISÃO REGULAMENTATÓRIA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+12, 1, 1).Text = "POSSUI DADOS DE GRUPOS VULNERÁVEIS";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+13, 1, 1).Text = "POSSUI DADOS DE CRIANÇA/ADOLESCENTE";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+14, 1, 1).Text = "SETOR(ES) INTERNO(S) ENVOLVIDO(S)";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+15, 1, 1).Text = "FORMA(S) DE COMPARTILHAMENTO INTERNO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+16, 1, 1).Text = "ENVOLVIDOS NA COLETA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+17, 1, 1).Text = "MEDIDA(S) DE SEGURANÇA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+18, 1, 1).Text = "DESCRIÇÃO DA MEDIDA DE SEGURANÇA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+19, 1, 1).Text = "DESCRIÇÃO DO FLUXO DE TRATAMENTO DE DADOS";
         AV13ExcelDocument.SelectSheet("DICIONÁRIO");
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = "INFORMAÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = "PODE ELIMINAR";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = "POSSUI DADOS SENSÍVEIS";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = "HIPÓTESE DE TRATAMENTO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = "TRANSFERÊNCIA INTERNACIONAL";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = "PAÍS(ES)";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Text = "TIPO GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Text = "COMPARTILHAMENTO COM TERCEIROS/EXTERNOS";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Text = "FINALIDADE DO COMPARTILHAMENTO COM EXTERNOS";
         AV13ExcelDocument.SelectSheet("OPERADOR(ES)");
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = "NOME";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = "COLETA";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = "RETENÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = "COMPARTILHAMENTO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = "ELIMINAÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = "PROCESSAMENTO";
         AV13ExcelDocument.SelectSheet("REVISÕES");
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = "USUÁRIO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = "DATA ALTERAÇÃO";
         AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = "OBSERVAÇÃO";
      }

      protected void S151( )
      {
         /* 'ESCREVEDADOS' Routine */
         returnInSub = false;
         AV9Linha = (short)(AV9Linha+1);
         AV13ExcelDocument.SelectSheet("DOCUMENTO");
         /* Using cursor P006B4 */
         pr_default.execute(1, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A20SubprocessoId = P006B4_A20SubprocessoId[0];
            n20SubprocessoId = P006B4_n20SubprocessoId[0];
            A16ProcessoId = P006B4_A16ProcessoId[0];
            n16ProcessoId = P006B4_n16ProcessoId[0];
            A7EncarregadoId = P006B4_A7EncarregadoId[0];
            n7EncarregadoId = P006B4_n7EncarregadoId[0];
            A13PersonaId = P006B4_A13PersonaId[0];
            n13PersonaId = P006B4_n13PersonaId[0];
            A24AreaResponsavelId = P006B4_A24AreaResponsavelId[0];
            n24AreaResponsavelId = P006B4_n24AreaResponsavelId[0];
            A110DocumentoControladorId = P006B4_A110DocumentoControladorId[0];
            n110DocumentoControladorId = P006B4_n110DocumentoControladorId[0];
            A75DocumentoId = P006B4_A75DocumentoId[0];
            A76DocumentoNome = P006B4_A76DocumentoNome[0];
            n76DocumentoNome = P006B4_n76DocumentoNome[0];
            A17ProcessoNome = P006B4_A17ProcessoNome[0];
            A21SubprocessoNome = P006B4_A21SubprocessoNome[0];
            A25AreaResponsavelNome = P006B4_A25AreaResponsavelNome[0];
            A11ControladorNome = P006B4_A11ControladorNome[0];
            n11ControladorNome = P006B4_n11ControladorNome[0];
            A14PersonaNome = P006B4_A14PersonaNome[0];
            A8EncarregadoNome = P006B4_A8EncarregadoNome[0];
            A141DocumentoUsuarioInclusao = P006B4_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = P006B4_n141DocumentoUsuarioInclusao[0];
            A108DocumentoDataInclusao = P006B4_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = P006B4_n108DocumentoDataInclusao[0];
            A142DocumentoUsuarioAlteracao = P006B4_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = P006B4_n142DocumentoUsuarioAlteracao[0];
            A109DocumentoDataAlteracao = P006B4_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = P006B4_n109DocumentoDataAlteracao[0];
            A16ProcessoId = P006B4_A16ProcessoId[0];
            n16ProcessoId = P006B4_n16ProcessoId[0];
            A21SubprocessoNome = P006B4_A21SubprocessoNome[0];
            A17ProcessoNome = P006B4_A17ProcessoNome[0];
            A8EncarregadoNome = P006B4_A8EncarregadoNome[0];
            A14PersonaNome = P006B4_A14PersonaNome[0];
            A25AreaResponsavelNome = P006B4_A25AreaResponsavelNome[0];
            A11ControladorNome = P006B4_A11ControladorNome[0];
            n11ControladorNome = P006B4_n11ControladorNome[0];
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = StringUtil.Upper( A76DocumentoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = StringUtil.Upper( A17ProcessoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = StringUtil.Upper( A21SubprocessoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = StringUtil.Upper( A25AreaResponsavelNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = StringUtil.Upper( A11ControladorNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = StringUtil.Upper( A14PersonaNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Text = StringUtil.Upper( A8EncarregadoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Text = StringUtil.Upper( A141DocumentoUsuarioInclusao);
            AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Date = A108DocumentoDataInclusao;
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+9, 1, 1).Text = StringUtil.Upper( A142DocumentoUsuarioAlteracao);
            AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+10, 1, 1).Date = A109DocumentoDataAlteracao;
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+11, 1, 1).Number = A75DocumentoId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV13ExcelDocument.SelectSheet("TRATAMENTO");
         /* Using cursor P006B5 */
         pr_default.execute(2, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A27CategoriaId = P006B5_A27CategoriaId[0];
            n27CategoriaId = P006B5_n27CategoriaId[0];
            A30TipoDadoId = P006B5_A30TipoDadoId[0];
            n30TipoDadoId = P006B5_n30TipoDadoId[0];
            A33FerramentaColetaId = P006B5_A33FerramentaColetaId[0];
            n33FerramentaColetaId = P006B5_n33FerramentaColetaId[0];
            A36AbrangenciaGeograficaId = P006B5_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = P006B5_n36AbrangenciaGeograficaId[0];
            A39FrequenciaTratamentoId = P006B5_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = P006B5_n39FrequenciaTratamentoId[0];
            A45TipoDescarteId = P006B5_A45TipoDescarteId[0];
            n45TipoDescarteId = P006B5_n45TipoDescarteId[0];
            A48TempoRetencaoId = P006B5_A48TempoRetencaoId[0];
            n48TempoRetencaoId = P006B5_n48TempoRetencaoId[0];
            A75DocumentoId = P006B5_A75DocumentoId[0];
            A77DocumentoFinalidadeTratamento = P006B5_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = P006B5_n77DocumentoFinalidadeTratamento[0];
            A28CategoriaNome = P006B5_A28CategoriaNome[0];
            A31TipoDadoNome = P006B5_A31TipoDadoNome[0];
            A34FerramentaColetaNome = P006B5_A34FerramentaColetaNome[0];
            A37AbrangenciaGeograficaNome = P006B5_A37AbrangenciaGeograficaNome[0];
            A40FrequenciaTratamentoNome = P006B5_A40FrequenciaTratamentoNome[0];
            A46TipoDescarteNome = P006B5_A46TipoDescarteNome[0];
            A49TempoRetencaoNome = P006B5_A49TempoRetencaoNome[0];
            A78DocumentoPrevColetaDados = P006B5_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = P006B5_n78DocumentoPrevColetaDados[0];
            A79DocumentoBaseLegalNorm = P006B5_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = P006B5_n79DocumentoBaseLegalNorm[0];
            A80DocumentoBaseLegalNormIntExt = P006B5_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = P006B5_n80DocumentoBaseLegalNormIntExt[0];
            A82DocumentoDadosGrupoVul = P006B5_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = P006B5_n82DocumentoDadosGrupoVul[0];
            A81DocumentoDadosCriancaAdolesc = P006B5_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = P006B5_n81DocumentoDadosCriancaAdolesc[0];
            A83DocumentoMedidaSegurancaDesc = P006B5_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = P006B5_n83DocumentoMedidaSegurancaDesc[0];
            A84DocumentoFluxoTratDadosDesc = P006B5_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = P006B5_n84DocumentoFluxoTratDadosDesc[0];
            A28CategoriaNome = P006B5_A28CategoriaNome[0];
            A31TipoDadoNome = P006B5_A31TipoDadoNome[0];
            A34FerramentaColetaNome = P006B5_A34FerramentaColetaNome[0];
            A37AbrangenciaGeograficaNome = P006B5_A37AbrangenciaGeograficaNome[0];
            A40FrequenciaTratamentoNome = P006B5_A40FrequenciaTratamentoNome[0];
            A46TipoDescarteNome = P006B5_A46TipoDescarteNome[0];
            A49TempoRetencaoNome = P006B5_A49TempoRetencaoNome[0];
            /* Using cursor P006B6 */
            pr_default.execute(3, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A63FonteRetencaoId = P006B6_A63FonteRetencaoId[0];
               A75DocumentoId = P006B6_A75DocumentoId[0];
               A64FonteRetencaoNome = P006B6_A64FonteRetencaoNome[0];
               A64FonteRetencaoNome = P006B6_A64FonteRetencaoNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FonteRetencao)) )
               {
                  AV19FonteRetencao += StringUtil.Upper( A64FonteRetencaoNome);
               }
               else
               {
                  AV19FonteRetencao += ", " + StringUtil.Upper( A64FonteRetencaoNome);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FonteRetencao)) )
            {
               AV19FonteRetencao += ".";
            }
            /* Using cursor P006B7 */
            pr_default.execute(4, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A60SetorInternoId = P006B7_A60SetorInternoId[0];
               A75DocumentoId = P006B7_A75DocumentoId[0];
               A61SetorInternoNome = P006B7_A61SetorInternoNome[0];
               A61SetorInternoNome = P006B7_A61SetorInternoNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24SetorInterno)) )
               {
                  AV24SetorInterno += StringUtil.Upper( A61SetorInternoNome);
               }
               else
               {
                  AV24SetorInterno += ", " + StringUtil.Upper( A61SetorInternoNome);
               }
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SetorInterno)) )
            {
               AV24SetorInterno += ".";
            }
            /* Using cursor P006B8 */
            pr_default.execute(5, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A57CompartInternoId = P006B8_A57CompartInternoId[0];
               A75DocumentoId = P006B8_A75DocumentoId[0];
               A58CompartInternoNome = P006B8_A58CompartInternoNome[0];
               A58CompartInternoNome = P006B8_A58CompartInternoNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25CompartInterno)) )
               {
                  AV25CompartInterno += StringUtil.Upper( A58CompartInternoNome);
               }
               else
               {
                  AV25CompartInterno += ", " + StringUtil.Upper( A58CompartInternoNome);
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CompartInterno)) )
            {
               AV25CompartInterno += ".";
            }
            /* Using cursor P006B9 */
            pr_default.execute(6, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A54EnvolvidosColetaId = P006B9_A54EnvolvidosColetaId[0];
               A75DocumentoId = P006B9_A75DocumentoId[0];
               A55EnvolvidosColetaNome = P006B9_A55EnvolvidosColetaNome[0];
               A55EnvolvidosColetaNome = P006B9_A55EnvolvidosColetaNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26EnvolvidosColeta)) )
               {
                  AV26EnvolvidosColeta += StringUtil.Upper( A55EnvolvidosColetaNome);
               }
               else
               {
                  AV26EnvolvidosColeta += ", " + StringUtil.Upper( A55EnvolvidosColetaNome);
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EnvolvidosColeta)) )
            {
               AV26EnvolvidosColeta += ".";
            }
            /* Using cursor P006B10 */
            pr_default.execute(7, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A51MedidaSegurancaId = P006B10_A51MedidaSegurancaId[0];
               A75DocumentoId = P006B10_A75DocumentoId[0];
               A52MedidaSegurancaNome = P006B10_A52MedidaSegurancaNome[0];
               A52MedidaSegurancaNome = P006B10_A52MedidaSegurancaNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27MedidaSeguranca)) )
               {
                  AV27MedidaSeguranca += StringUtil.Upper( A52MedidaSegurancaNome);
               }
               else
               {
                  AV27MedidaSeguranca += ", " + StringUtil.Upper( A52MedidaSegurancaNome);
               }
               pr_default.readNext(7);
            }
            pr_default.close(7);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27MedidaSeguranca)) )
            {
               AV27MedidaSeguranca += ".";
            }
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = StringUtil.Upper( A77DocumentoFinalidadeTratamento);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = StringUtil.Upper( A28CategoriaNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = StringUtil.Upper( A31TipoDadoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = StringUtil.Upper( A34FerramentaColetaNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = StringUtil.Upper( A37AbrangenciaGeograficaNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = StringUtil.Upper( A40FrequenciaTratamentoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Text = StringUtil.Upper( AV19FonteRetencao);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Text = StringUtil.Upper( A46TipoDescarteNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Text = StringUtil.Upper( A49TempoRetencaoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+9, 1, 1).Text = ((A78DocumentoPrevColetaDados) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+10, 1, 1).Text = StringUtil.Upper( A79DocumentoBaseLegalNorm);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+11, 1, 1).Text = StringUtil.Upper( A80DocumentoBaseLegalNormIntExt);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+12, 1, 1).Text = ((A82DocumentoDadosGrupoVul) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+13, 1, 1).Text = ((A81DocumentoDadosCriancaAdolesc) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+14, 1, 1).Text = StringUtil.Upper( AV24SetorInterno);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+15, 1, 1).Text = StringUtil.Upper( AV25CompartInterno);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+16, 1, 1).Text = StringUtil.Upper( AV26EnvolvidosColeta);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+17, 1, 1).Text = StringUtil.Upper( AV27MedidaSeguranca);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+18, 1, 1).Text = StringUtil.Upper( A83DocumentoMedidaSegurancaDesc);
            AV31DocumentoFluxoTratDadosDesc = StringUtil.StringReplace( A84DocumentoFluxoTratDadosDesc, "<p>&nbsp;</p>", "");
            AV29TagHtmlColl = (GxSimpleCollection<string>)(GxRegex.Split(AV31DocumentoFluxoTratDadosDesc,"</p>"));
            AV41GXV1 = 1;
            while ( AV41GXV1 <= AV29TagHtmlColl.Count )
            {
               AV30TagHtmlItem = ((string)AV29TagHtmlColl.Item(AV41GXV1));
               if ( StringUtil.StringSearch( StringUtil.Trim( AV30TagHtmlItem), "img", 1) == 0 )
               {
                  AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+19, 1, 1).Text = AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+19, 1, 1).Text+StringUtil.StringReplace( AV30TagHtmlItem, "<p>", "")+StringUtil.NewLine( );
               }
               AV41GXV1 = (int)(AV41GXV1+1);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         AV13ExcelDocument.SelectSheet("DICIONÁRIO");
         /* Using cursor P006B11 */
         pr_default.execute(8, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A69InformacaoId = P006B11_A69InformacaoId[0];
            A72HipoteseTratamentoId = P006B11_A72HipoteseTratamentoId[0];
            A98DocDicionarioId = P006B11_A98DocDicionarioId[0];
            A75DocumentoId = P006B11_A75DocumentoId[0];
            A70InformacaoNome = P006B11_A70InformacaoNome[0];
            A100DocDicionarioPodeEliminar = P006B11_A100DocDicionarioPodeEliminar[0];
            A99DocDicionarioSensivel = P006B11_A99DocDicionarioSensivel[0];
            A73HipoteseTratamentoNome = P006B11_A73HipoteseTratamentoNome[0];
            A101DocDicionarioTransfInter = P006B11_A101DocDicionarioTransfInter[0];
            A119DocDicionarioTipoTransfInterGa = P006B11_A119DocDicionarioTipoTransfInterGa[0];
            A102DocDicionarioFinalidade = P006B11_A102DocDicionarioFinalidade[0];
            A70InformacaoNome = P006B11_A70InformacaoNome[0];
            A73HipoteseTratamentoNome = P006B11_A73HipoteseTratamentoNome[0];
            AV28Pais = "";
            /* Using cursor P006B12 */
            pr_default.execute(9, new Object[] {A98DocDicionarioId, A75DocumentoId, AV8DocumentoId});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A4PaisId = P006B12_A4PaisId[0];
               A5PaisNome = P006B12_A5PaisNome[0];
               A5PaisNome = P006B12_A5PaisNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28Pais)) )
               {
                  AV28Pais += StringUtil.Upper( A5PaisNome);
               }
               else
               {
                  AV28Pais += ", " + StringUtil.Upper( A5PaisNome);
               }
               pr_default.readNext(9);
            }
            pr_default.close(9);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Pais)) )
            {
               AV28Pais += ".";
            }
            AV18CompartTercExt = "";
            /* Using cursor P006B13 */
            pr_default.execute(10, new Object[] {A98DocDicionarioId});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A66CompartTercExternoId = P006B13_A66CompartTercExternoId[0];
               A67CompartTercExternoNome = P006B13_A67CompartTercExternoNome[0];
               A67CompartTercExternoNome = P006B13_A67CompartTercExternoNome[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18CompartTercExt)) )
               {
                  AV18CompartTercExt += StringUtil.Upper( A67CompartTercExternoNome);
               }
               else
               {
                  AV18CompartTercExt += ", " + StringUtil.Upper( A67CompartTercExternoNome);
               }
               pr_default.readNext(10);
            }
            pr_default.close(10);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CompartTercExt)) )
            {
               AV18CompartTercExt += ".";
            }
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = StringUtil.Upper( A70InformacaoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = ((A100DocDicionarioPodeEliminar) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = ((A99DocDicionarioSensivel) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = StringUtil.Upper( A73HipoteseTratamentoNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = ((A101DocDicionarioTransfInter) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = StringUtil.Upper( AV28Pais);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+6, 1, 1).Text = StringUtil.Trim( StringUtil.Upper( A119DocDicionarioTipoTransfInterGa));
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+7, 1, 1).Text = StringUtil.Upper( AV18CompartTercExt);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+8, 1, 1).Text = StringUtil.Upper( A102DocDicionarioFinalidade);
            AV9Linha = (short)(AV9Linha+1);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         AV9Linha = 2;
         AV13ExcelDocument.SelectSheet("OPERADOR(ES)");
         /* Using cursor P006B14 */
         pr_default.execute(11, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A42OperadorId = P006B14_A42OperadorId[0];
            A75DocumentoId = P006B14_A75DocumentoId[0];
            A43OperadorNome = P006B14_A43OperadorNome[0];
            A87DocOperadorColeta = P006B14_A87DocOperadorColeta[0];
            A88DocOperadorRetencao = P006B14_A88DocOperadorRetencao[0];
            A89DocOperadorCompartilhamento = P006B14_A89DocOperadorCompartilhamento[0];
            A90DocOperadorEliminacao = P006B14_A90DocOperadorEliminacao[0];
            A91DocOperadorProcessamento = P006B14_A91DocOperadorProcessamento[0];
            A86DocOperadorId = P006B14_A86DocOperadorId[0];
            A43OperadorNome = P006B14_A43OperadorNome[0];
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = StringUtil.Upper( A43OperadorNome);
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Text = ((A87DocOperadorColeta) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = ((A88DocOperadorRetencao) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+3, 1, 1).Text = ((A89DocOperadorCompartilhamento) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+4, 1, 1).Text = ((A90DocOperadorEliminacao) ? "SIM" : "NÃO");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+5, 1, 1).Text = ((A91DocOperadorProcessamento) ? "SIM" : "NÃO");
            AV9Linha = (short)(AV9Linha+1);
            pr_default.readNext(11);
         }
         pr_default.close(11);
         AV9Linha = 2;
         AV13ExcelDocument.SelectSheet("REVISÕES");
         /* Using cursor P006B15 */
         pr_default.execute(12, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A75DocumentoId = P006B15_A75DocumentoId[0];
            A121RevisaoLogUsuarioAlteracao = P006B15_A121RevisaoLogUsuarioAlteracao[0];
            A123RevisaoLogDataAlteracao = P006B15_A123RevisaoLogDataAlteracao[0];
            A122RevisaoLogObservacao = P006B15_A122RevisaoLogObservacao[0];
            A120RevisaoLogId = P006B15_A120RevisaoLogId[0];
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+0, 1, 1).Text = StringUtil.Upper( A121RevisaoLogUsuarioAlteracao);
            AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+1, 1, 1).Date = A123RevisaoLogDataAlteracao;
            AV13ExcelDocument.get_Cells(AV9Linha, AV14Coluna+2, 1, 1).Text = StringUtil.Upper( A122RevisaoLogObservacao);
            AV9Linha = (short)(AV9Linha+1);
            pr_default.readNext(12);
         }
         pr_default.close(12);
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
         AV11Filename = "";
         AV17Caminho = "";
         scmdbuf = "";
         P006B3_A40000ParametroValor = new string[] {""} ;
         P006B3_n40000ParametroValor = new bool[] {false} ;
         A40000ParametroValor = "";
         AV16Directory = new GxDirectory(context.GetPhysicalPath());
         AV23ParametroValor = "";
         AV22DirectoryServidor = new GxDirectory(context.GetPhysicalPath());
         AV21CaminhoServidor = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV15ErrorMessage = "";
         P006B4_A20SubprocessoId = new int[1] ;
         P006B4_n20SubprocessoId = new bool[] {false} ;
         P006B4_A16ProcessoId = new int[1] ;
         P006B4_n16ProcessoId = new bool[] {false} ;
         P006B4_A7EncarregadoId = new int[1] ;
         P006B4_n7EncarregadoId = new bool[] {false} ;
         P006B4_A13PersonaId = new int[1] ;
         P006B4_n13PersonaId = new bool[] {false} ;
         P006B4_A24AreaResponsavelId = new int[1] ;
         P006B4_n24AreaResponsavelId = new bool[] {false} ;
         P006B4_A110DocumentoControladorId = new int[1] ;
         P006B4_n110DocumentoControladorId = new bool[] {false} ;
         P006B4_A75DocumentoId = new int[1] ;
         P006B4_A76DocumentoNome = new string[] {""} ;
         P006B4_n76DocumentoNome = new bool[] {false} ;
         P006B4_A17ProcessoNome = new string[] {""} ;
         P006B4_A21SubprocessoNome = new string[] {""} ;
         P006B4_A25AreaResponsavelNome = new string[] {""} ;
         P006B4_A11ControladorNome = new string[] {""} ;
         P006B4_n11ControladorNome = new bool[] {false} ;
         P006B4_A14PersonaNome = new string[] {""} ;
         P006B4_A8EncarregadoNome = new string[] {""} ;
         P006B4_A141DocumentoUsuarioInclusao = new string[] {""} ;
         P006B4_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         P006B4_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P006B4_n108DocumentoDataInclusao = new bool[] {false} ;
         P006B4_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         P006B4_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         P006B4_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P006B4_n109DocumentoDataAlteracao = new bool[] {false} ;
         A76DocumentoNome = "";
         A17ProcessoNome = "";
         A21SubprocessoNome = "";
         A25AreaResponsavelNome = "";
         A11ControladorNome = "";
         A14PersonaNome = "";
         A8EncarregadoNome = "";
         A141DocumentoUsuarioInclusao = "";
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         A142DocumentoUsuarioAlteracao = "";
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         P006B5_A27CategoriaId = new int[1] ;
         P006B5_n27CategoriaId = new bool[] {false} ;
         P006B5_A30TipoDadoId = new int[1] ;
         P006B5_n30TipoDadoId = new bool[] {false} ;
         P006B5_A33FerramentaColetaId = new int[1] ;
         P006B5_n33FerramentaColetaId = new bool[] {false} ;
         P006B5_A36AbrangenciaGeograficaId = new int[1] ;
         P006B5_n36AbrangenciaGeograficaId = new bool[] {false} ;
         P006B5_A39FrequenciaTratamentoId = new int[1] ;
         P006B5_n39FrequenciaTratamentoId = new bool[] {false} ;
         P006B5_A45TipoDescarteId = new int[1] ;
         P006B5_n45TipoDescarteId = new bool[] {false} ;
         P006B5_A48TempoRetencaoId = new int[1] ;
         P006B5_n48TempoRetencaoId = new bool[] {false} ;
         P006B5_A75DocumentoId = new int[1] ;
         P006B5_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         P006B5_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         P006B5_A28CategoriaNome = new string[] {""} ;
         P006B5_A31TipoDadoNome = new string[] {""} ;
         P006B5_A34FerramentaColetaNome = new string[] {""} ;
         P006B5_A37AbrangenciaGeograficaNome = new string[] {""} ;
         P006B5_A40FrequenciaTratamentoNome = new string[] {""} ;
         P006B5_A46TipoDescarteNome = new string[] {""} ;
         P006B5_A49TempoRetencaoNome = new string[] {""} ;
         P006B5_A78DocumentoPrevColetaDados = new bool[] {false} ;
         P006B5_n78DocumentoPrevColetaDados = new bool[] {false} ;
         P006B5_A79DocumentoBaseLegalNorm = new string[] {""} ;
         P006B5_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         P006B5_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         P006B5_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         P006B5_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         P006B5_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         P006B5_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P006B5_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P006B5_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         P006B5_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         P006B5_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         P006B5_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         A77DocumentoFinalidadeTratamento = "";
         A28CategoriaNome = "";
         A31TipoDadoNome = "";
         A34FerramentaColetaNome = "";
         A37AbrangenciaGeograficaNome = "";
         A40FrequenciaTratamentoNome = "";
         A46TipoDescarteNome = "";
         A49TempoRetencaoNome = "";
         A79DocumentoBaseLegalNorm = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A83DocumentoMedidaSegurancaDesc = "";
         A84DocumentoFluxoTratDadosDesc = "";
         P006B6_A63FonteRetencaoId = new int[1] ;
         P006B6_A75DocumentoId = new int[1] ;
         P006B6_A64FonteRetencaoNome = new string[] {""} ;
         A64FonteRetencaoNome = "";
         AV19FonteRetencao = "";
         P006B7_A60SetorInternoId = new int[1] ;
         P006B7_A75DocumentoId = new int[1] ;
         P006B7_A61SetorInternoNome = new string[] {""} ;
         A61SetorInternoNome = "";
         AV24SetorInterno = "";
         P006B8_A57CompartInternoId = new int[1] ;
         P006B8_A75DocumentoId = new int[1] ;
         P006B8_A58CompartInternoNome = new string[] {""} ;
         A58CompartInternoNome = "";
         AV25CompartInterno = "";
         P006B9_A54EnvolvidosColetaId = new int[1] ;
         P006B9_A75DocumentoId = new int[1] ;
         P006B9_A55EnvolvidosColetaNome = new string[] {""} ;
         A55EnvolvidosColetaNome = "";
         AV26EnvolvidosColeta = "";
         P006B10_A51MedidaSegurancaId = new int[1] ;
         P006B10_A75DocumentoId = new int[1] ;
         P006B10_A52MedidaSegurancaNome = new string[] {""} ;
         A52MedidaSegurancaNome = "";
         AV27MedidaSeguranca = "";
         AV31DocumentoFluxoTratDadosDesc = "";
         AV29TagHtmlColl = new GxSimpleCollection<string>();
         AV30TagHtmlItem = "";
         P006B11_A69InformacaoId = new int[1] ;
         P006B11_A72HipoteseTratamentoId = new int[1] ;
         P006B11_A98DocDicionarioId = new int[1] ;
         P006B11_A75DocumentoId = new int[1] ;
         P006B11_A70InformacaoNome = new string[] {""} ;
         P006B11_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P006B11_A99DocDicionarioSensivel = new bool[] {false} ;
         P006B11_A73HipoteseTratamentoNome = new string[] {""} ;
         P006B11_A101DocDicionarioTransfInter = new bool[] {false} ;
         P006B11_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P006B11_A102DocDicionarioFinalidade = new string[] {""} ;
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A119DocDicionarioTipoTransfInterGa = "";
         A102DocDicionarioFinalidade = "";
         AV28Pais = "";
         P006B12_A4PaisId = new int[1] ;
         P006B12_A98DocDicionarioId = new int[1] ;
         P006B12_A5PaisNome = new string[] {""} ;
         A5PaisNome = "";
         AV18CompartTercExt = "";
         P006B13_A66CompartTercExternoId = new int[1] ;
         P006B13_A98DocDicionarioId = new int[1] ;
         P006B13_A67CompartTercExternoNome = new string[] {""} ;
         A67CompartTercExternoNome = "";
         P006B14_A42OperadorId = new int[1] ;
         P006B14_A75DocumentoId = new int[1] ;
         P006B14_A43OperadorNome = new string[] {""} ;
         P006B14_A87DocOperadorColeta = new bool[] {false} ;
         P006B14_A88DocOperadorRetencao = new bool[] {false} ;
         P006B14_A89DocOperadorCompartilhamento = new bool[] {false} ;
         P006B14_A90DocOperadorEliminacao = new bool[] {false} ;
         P006B14_A91DocOperadorProcessamento = new bool[] {false} ;
         P006B14_A86DocOperadorId = new int[1] ;
         A43OperadorNome = "";
         P006B15_A75DocumentoId = new int[1] ;
         P006B15_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         P006B15_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P006B15_A122RevisaoLogObservacao = new string[] {""} ;
         P006B15_A120RevisaoLogId = new int[1] ;
         A121RevisaoLogUsuarioAlteracao = "";
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         A122RevisaoLogObservacao = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentorelatorioexcel__default(),
            new Object[][] {
                new Object[] {
               P006B3_A40000ParametroValor, P006B3_n40000ParametroValor
               }
               , new Object[] {
               P006B4_A20SubprocessoId, P006B4_n20SubprocessoId, P006B4_A16ProcessoId, P006B4_n16ProcessoId, P006B4_A7EncarregadoId, P006B4_n7EncarregadoId, P006B4_A13PersonaId, P006B4_n13PersonaId, P006B4_A24AreaResponsavelId, P006B4_n24AreaResponsavelId,
               P006B4_A110DocumentoControladorId, P006B4_n110DocumentoControladorId, P006B4_A75DocumentoId, P006B4_A76DocumentoNome, P006B4_n76DocumentoNome, P006B4_A17ProcessoNome, P006B4_A21SubprocessoNome, P006B4_A25AreaResponsavelNome, P006B4_A11ControladorNome, P006B4_n11ControladorNome,
               P006B4_A14PersonaNome, P006B4_A8EncarregadoNome, P006B4_A141DocumentoUsuarioInclusao, P006B4_n141DocumentoUsuarioInclusao, P006B4_A108DocumentoDataInclusao, P006B4_n108DocumentoDataInclusao, P006B4_A142DocumentoUsuarioAlteracao, P006B4_n142DocumentoUsuarioAlteracao, P006B4_A109DocumentoDataAlteracao, P006B4_n109DocumentoDataAlteracao
               }
               , new Object[] {
               P006B5_A27CategoriaId, P006B5_n27CategoriaId, P006B5_A30TipoDadoId, P006B5_n30TipoDadoId, P006B5_A33FerramentaColetaId, P006B5_n33FerramentaColetaId, P006B5_A36AbrangenciaGeograficaId, P006B5_n36AbrangenciaGeograficaId, P006B5_A39FrequenciaTratamentoId, P006B5_n39FrequenciaTratamentoId,
               P006B5_A45TipoDescarteId, P006B5_n45TipoDescarteId, P006B5_A48TempoRetencaoId, P006B5_n48TempoRetencaoId, P006B5_A75DocumentoId, P006B5_A77DocumentoFinalidadeTratamento, P006B5_n77DocumentoFinalidadeTratamento, P006B5_A28CategoriaNome, P006B5_A31TipoDadoNome, P006B5_A34FerramentaColetaNome,
               P006B5_A37AbrangenciaGeograficaNome, P006B5_A40FrequenciaTratamentoNome, P006B5_A46TipoDescarteNome, P006B5_A49TempoRetencaoNome, P006B5_A78DocumentoPrevColetaDados, P006B5_n78DocumentoPrevColetaDados, P006B5_A79DocumentoBaseLegalNorm, P006B5_n79DocumentoBaseLegalNorm, P006B5_A80DocumentoBaseLegalNormIntExt, P006B5_n80DocumentoBaseLegalNormIntExt,
               P006B5_A82DocumentoDadosGrupoVul, P006B5_n82DocumentoDadosGrupoVul, P006B5_A81DocumentoDadosCriancaAdolesc, P006B5_n81DocumentoDadosCriancaAdolesc, P006B5_A83DocumentoMedidaSegurancaDesc, P006B5_n83DocumentoMedidaSegurancaDesc, P006B5_A84DocumentoFluxoTratDadosDesc, P006B5_n84DocumentoFluxoTratDadosDesc
               }
               , new Object[] {
               P006B6_A63FonteRetencaoId, P006B6_A75DocumentoId, P006B6_A64FonteRetencaoNome
               }
               , new Object[] {
               P006B7_A60SetorInternoId, P006B7_A75DocumentoId, P006B7_A61SetorInternoNome
               }
               , new Object[] {
               P006B8_A57CompartInternoId, P006B8_A75DocumentoId, P006B8_A58CompartInternoNome
               }
               , new Object[] {
               P006B9_A54EnvolvidosColetaId, P006B9_A75DocumentoId, P006B9_A55EnvolvidosColetaNome
               }
               , new Object[] {
               P006B10_A51MedidaSegurancaId, P006B10_A75DocumentoId, P006B10_A52MedidaSegurancaNome
               }
               , new Object[] {
               P006B11_A69InformacaoId, P006B11_A72HipoteseTratamentoId, P006B11_A98DocDicionarioId, P006B11_A75DocumentoId, P006B11_A70InformacaoNome, P006B11_A100DocDicionarioPodeEliminar, P006B11_A99DocDicionarioSensivel, P006B11_A73HipoteseTratamentoNome, P006B11_A101DocDicionarioTransfInter, P006B11_A119DocDicionarioTipoTransfInterGa,
               P006B11_A102DocDicionarioFinalidade
               }
               , new Object[] {
               P006B12_A4PaisId, P006B12_A98DocDicionarioId, P006B12_A5PaisNome
               }
               , new Object[] {
               P006B13_A66CompartTercExternoId, P006B13_A98DocDicionarioId, P006B13_A67CompartTercExternoNome
               }
               , new Object[] {
               P006B14_A42OperadorId, P006B14_A75DocumentoId, P006B14_A43OperadorNome, P006B14_A87DocOperadorColeta, P006B14_A88DocOperadorRetencao, P006B14_A89DocOperadorCompartilhamento, P006B14_A90DocOperadorEliminacao, P006B14_A91DocOperadorProcessamento, P006B14_A86DocOperadorId
               }
               , new Object[] {
               P006B15_A75DocumentoId, P006B15_A121RevisaoLogUsuarioAlteracao, P006B15_A123RevisaoLogDataAlteracao, P006B15_A122RevisaoLogObservacao, P006B15_A120RevisaoLogId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Linha ;
      private short AV14Coluna ;
      private int AV8DocumentoId ;
      private int A20SubprocessoId ;
      private int A16ProcessoId ;
      private int A7EncarregadoId ;
      private int A13PersonaId ;
      private int A24AreaResponsavelId ;
      private int A110DocumentoControladorId ;
      private int A75DocumentoId ;
      private int A27CategoriaId ;
      private int A30TipoDadoId ;
      private int A33FerramentaColetaId ;
      private int A36AbrangenciaGeograficaId ;
      private int A39FrequenciaTratamentoId ;
      private int A45TipoDescarteId ;
      private int A48TempoRetencaoId ;
      private int A63FonteRetencaoId ;
      private int A60SetorInternoId ;
      private int A57CompartInternoId ;
      private int A54EnvolvidosColetaId ;
      private int A51MedidaSegurancaId ;
      private int AV41GXV1 ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A98DocDicionarioId ;
      private int A4PaisId ;
      private int A66CompartTercExternoId ;
      private int A42OperadorId ;
      private int A86DocOperadorId ;
      private int A120RevisaoLogId ;
      private string scmdbuf ;
      private DateTime A108DocumentoDataInclusao ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private bool returnInSub ;
      private bool n40000ParametroValor ;
      private bool n20SubprocessoId ;
      private bool n16ProcessoId ;
      private bool n7EncarregadoId ;
      private bool n13PersonaId ;
      private bool n24AreaResponsavelId ;
      private bool n110DocumentoControladorId ;
      private bool n76DocumentoNome ;
      private bool n11ControladorNome ;
      private bool n141DocumentoUsuarioInclusao ;
      private bool n108DocumentoDataInclusao ;
      private bool n142DocumentoUsuarioAlteracao ;
      private bool n109DocumentoDataAlteracao ;
      private bool n27CategoriaId ;
      private bool n30TipoDadoId ;
      private bool n33FerramentaColetaId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n45TipoDescarteId ;
      private bool n48TempoRetencaoId ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A99DocDicionarioSensivel ;
      private bool A101DocDicionarioTransfInter ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string AV31DocumentoFluxoTratDadosDesc ;
      private string AV30TagHtmlItem ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string A102DocDicionarioFinalidade ;
      private string A122RevisaoLogObservacao ;
      private string AV11Filename ;
      private string AV17Caminho ;
      private string A40000ParametroValor ;
      private string AV23ParametroValor ;
      private string AV21CaminhoServidor ;
      private string AV15ErrorMessage ;
      private string A76DocumentoNome ;
      private string A17ProcessoNome ;
      private string A21SubprocessoNome ;
      private string A25AreaResponsavelNome ;
      private string A11ControladorNome ;
      private string A14PersonaNome ;
      private string A8EncarregadoNome ;
      private string A141DocumentoUsuarioInclusao ;
      private string A142DocumentoUsuarioAlteracao ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A28CategoriaNome ;
      private string A31TipoDadoNome ;
      private string A34FerramentaColetaNome ;
      private string A37AbrangenciaGeograficaNome ;
      private string A40FrequenciaTratamentoNome ;
      private string A46TipoDescarteNome ;
      private string A49TempoRetencaoNome ;
      private string A79DocumentoBaseLegalNorm ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A64FonteRetencaoNome ;
      private string AV19FonteRetencao ;
      private string A61SetorInternoNome ;
      private string AV24SetorInterno ;
      private string A58CompartInternoNome ;
      private string AV25CompartInterno ;
      private string A55EnvolvidosColetaNome ;
      private string AV26EnvolvidosColeta ;
      private string A52MedidaSegurancaNome ;
      private string AV27MedidaSeguranca ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string AV28Pais ;
      private string A5PaisNome ;
      private string AV18CompartTercExt ;
      private string A67CompartTercExternoNome ;
      private string A43OperadorNome ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006B3_A40000ParametroValor ;
      private bool[] P006B3_n40000ParametroValor ;
      private int[] P006B4_A20SubprocessoId ;
      private bool[] P006B4_n20SubprocessoId ;
      private int[] P006B4_A16ProcessoId ;
      private bool[] P006B4_n16ProcessoId ;
      private int[] P006B4_A7EncarregadoId ;
      private bool[] P006B4_n7EncarregadoId ;
      private int[] P006B4_A13PersonaId ;
      private bool[] P006B4_n13PersonaId ;
      private int[] P006B4_A24AreaResponsavelId ;
      private bool[] P006B4_n24AreaResponsavelId ;
      private int[] P006B4_A110DocumentoControladorId ;
      private bool[] P006B4_n110DocumentoControladorId ;
      private int[] P006B4_A75DocumentoId ;
      private string[] P006B4_A76DocumentoNome ;
      private bool[] P006B4_n76DocumentoNome ;
      private string[] P006B4_A17ProcessoNome ;
      private string[] P006B4_A21SubprocessoNome ;
      private string[] P006B4_A25AreaResponsavelNome ;
      private string[] P006B4_A11ControladorNome ;
      private bool[] P006B4_n11ControladorNome ;
      private string[] P006B4_A14PersonaNome ;
      private string[] P006B4_A8EncarregadoNome ;
      private string[] P006B4_A141DocumentoUsuarioInclusao ;
      private bool[] P006B4_n141DocumentoUsuarioInclusao ;
      private DateTime[] P006B4_A108DocumentoDataInclusao ;
      private bool[] P006B4_n108DocumentoDataInclusao ;
      private string[] P006B4_A142DocumentoUsuarioAlteracao ;
      private bool[] P006B4_n142DocumentoUsuarioAlteracao ;
      private DateTime[] P006B4_A109DocumentoDataAlteracao ;
      private bool[] P006B4_n109DocumentoDataAlteracao ;
      private int[] P006B5_A27CategoriaId ;
      private bool[] P006B5_n27CategoriaId ;
      private int[] P006B5_A30TipoDadoId ;
      private bool[] P006B5_n30TipoDadoId ;
      private int[] P006B5_A33FerramentaColetaId ;
      private bool[] P006B5_n33FerramentaColetaId ;
      private int[] P006B5_A36AbrangenciaGeograficaId ;
      private bool[] P006B5_n36AbrangenciaGeograficaId ;
      private int[] P006B5_A39FrequenciaTratamentoId ;
      private bool[] P006B5_n39FrequenciaTratamentoId ;
      private int[] P006B5_A45TipoDescarteId ;
      private bool[] P006B5_n45TipoDescarteId ;
      private int[] P006B5_A48TempoRetencaoId ;
      private bool[] P006B5_n48TempoRetencaoId ;
      private int[] P006B5_A75DocumentoId ;
      private string[] P006B5_A77DocumentoFinalidadeTratamento ;
      private bool[] P006B5_n77DocumentoFinalidadeTratamento ;
      private string[] P006B5_A28CategoriaNome ;
      private string[] P006B5_A31TipoDadoNome ;
      private string[] P006B5_A34FerramentaColetaNome ;
      private string[] P006B5_A37AbrangenciaGeograficaNome ;
      private string[] P006B5_A40FrequenciaTratamentoNome ;
      private string[] P006B5_A46TipoDescarteNome ;
      private string[] P006B5_A49TempoRetencaoNome ;
      private bool[] P006B5_A78DocumentoPrevColetaDados ;
      private bool[] P006B5_n78DocumentoPrevColetaDados ;
      private string[] P006B5_A79DocumentoBaseLegalNorm ;
      private bool[] P006B5_n79DocumentoBaseLegalNorm ;
      private string[] P006B5_A80DocumentoBaseLegalNormIntExt ;
      private bool[] P006B5_n80DocumentoBaseLegalNormIntExt ;
      private bool[] P006B5_A82DocumentoDadosGrupoVul ;
      private bool[] P006B5_n82DocumentoDadosGrupoVul ;
      private bool[] P006B5_A81DocumentoDadosCriancaAdolesc ;
      private bool[] P006B5_n81DocumentoDadosCriancaAdolesc ;
      private string[] P006B5_A83DocumentoMedidaSegurancaDesc ;
      private bool[] P006B5_n83DocumentoMedidaSegurancaDesc ;
      private string[] P006B5_A84DocumentoFluxoTratDadosDesc ;
      private bool[] P006B5_n84DocumentoFluxoTratDadosDesc ;
      private int[] P006B6_A63FonteRetencaoId ;
      private int[] P006B6_A75DocumentoId ;
      private string[] P006B6_A64FonteRetencaoNome ;
      private int[] P006B7_A60SetorInternoId ;
      private int[] P006B7_A75DocumentoId ;
      private string[] P006B7_A61SetorInternoNome ;
      private int[] P006B8_A57CompartInternoId ;
      private int[] P006B8_A75DocumentoId ;
      private string[] P006B8_A58CompartInternoNome ;
      private int[] P006B9_A54EnvolvidosColetaId ;
      private int[] P006B9_A75DocumentoId ;
      private string[] P006B9_A55EnvolvidosColetaNome ;
      private int[] P006B10_A51MedidaSegurancaId ;
      private int[] P006B10_A75DocumentoId ;
      private string[] P006B10_A52MedidaSegurancaNome ;
      private int[] P006B11_A69InformacaoId ;
      private int[] P006B11_A72HipoteseTratamentoId ;
      private int[] P006B11_A98DocDicionarioId ;
      private int[] P006B11_A75DocumentoId ;
      private string[] P006B11_A70InformacaoNome ;
      private bool[] P006B11_A100DocDicionarioPodeEliminar ;
      private bool[] P006B11_A99DocDicionarioSensivel ;
      private string[] P006B11_A73HipoteseTratamentoNome ;
      private bool[] P006B11_A101DocDicionarioTransfInter ;
      private string[] P006B11_A119DocDicionarioTipoTransfInterGa ;
      private string[] P006B11_A102DocDicionarioFinalidade ;
      private int[] P006B12_A4PaisId ;
      private int[] P006B12_A98DocDicionarioId ;
      private string[] P006B12_A5PaisNome ;
      private int[] P006B13_A66CompartTercExternoId ;
      private int[] P006B13_A98DocDicionarioId ;
      private string[] P006B13_A67CompartTercExternoNome ;
      private int[] P006B14_A42OperadorId ;
      private int[] P006B14_A75DocumentoId ;
      private string[] P006B14_A43OperadorNome ;
      private bool[] P006B14_A87DocOperadorColeta ;
      private bool[] P006B14_A88DocOperadorRetencao ;
      private bool[] P006B14_A89DocOperadorCompartilhamento ;
      private bool[] P006B14_A90DocOperadorEliminacao ;
      private bool[] P006B14_A91DocOperadorProcessamento ;
      private int[] P006B14_A86DocOperadorId ;
      private int[] P006B15_A75DocumentoId ;
      private string[] P006B15_A121RevisaoLogUsuarioAlteracao ;
      private DateTime[] P006B15_A123RevisaoLogDataAlteracao ;
      private string[] P006B15_A122RevisaoLogObservacao ;
      private int[] P006B15_A120RevisaoLogId ;
      private string aP1_Filename ;
      private string aP2_Caminho ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxSimpleCollection<string> AV29TagHtmlColl ;
      private GxDirectory AV16Directory ;
      private GxDirectory AV22DirectoryServidor ;
   }

   public class documentorelatorioexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006B3;
          prmP006B3 = new Object[] {
          };
          Object[] prmP006B4;
          prmP006B4 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B5;
          prmP006B5 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B6;
          prmP006B6 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B7;
          prmP006B7 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B8;
          prmP006B8 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B9;
          prmP006B9 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B10;
          prmP006B10 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B11;
          prmP006B11 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B12;
          prmP006B12 = new Object[] {
          new ParDef("@DocDicionarioId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B13;
          prmP006B13 = new Object[] {
          new ParDef("@DocDicionarioId",GXType.Int32,8,0)
          };
          Object[] prmP006B14;
          prmP006B14 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006B15;
          prmP006B15 = new Object[] {
          new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006B3", "SELECT COALESCE( T1.[ParametroValor], '') AS ParametroValor FROM (SELECT [ParametroValor] AS ParametroValor, [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = 'Servidor' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P006B4", "SELECT T1.[SubprocessoId], T2.[ProcessoId], T1.[EncarregadoId], T1.[PersonaId], T1.[AreaResponsavelId], T1.[DocumentoControladorId] AS DocumentoControladorId, T1.[DocumentoId], T1.[DocumentoNome], T3.[ProcessoNome], T2.[SubprocessoNome], T6.[AreaResponsavelNome], T7.[ControladorNome], T5.[PersonaNome], T4.[EncarregadoNome], T1.[DocumentoUsuarioInclusao], T1.[DocumentoDataInclusao], T1.[DocumentoUsuarioAlteracao], T1.[DocumentoDataAlteracao] FROM (((((([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId]) LEFT JOIN [Encarregado] T4 ON T4.[EncarregadoId] = T1.[EncarregadoId]) LEFT JOIN [Persona] T5 ON T5.[PersonaId] = T1.[PersonaId]) LEFT JOIN [AreaResponsavel] T6 ON T6.[AreaResponsavelId] = T1.[AreaResponsavelId]) LEFT JOIN [Controlador] T7 ON T7.[ControladorId] = T1.[DocumentoControladorId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006B5", "SELECT T1.[CategoriaId], T1.[TipoDadoId], T1.[FerramentaColetaId], T1.[AbrangenciaGeograficaId], T1.[FrequenciaTratamentoId], T1.[TipoDescarteId], T1.[TempoRetencaoId], T1.[DocumentoId], T1.[DocumentoFinalidadeTratamento], T2.[CategoriaNome], T3.[TipoDadoNome], T4.[FerramentaColetaNome], T5.[AbrangenciaGeograficaNome], T6.[FrequenciaTratamentoNome], T7.[TipoDescarteNome], T8.[TempoRetencaoNome], T1.[DocumentoPrevColetaDados], T1.[DocumentoBaseLegalNorm], T1.[DocumentoBaseLegalNormIntExt], T1.[DocumentoDadosGrupoVul], T1.[DocumentoDadosCriancaAdolesc], T1.[DocumentoMedidaSegurancaDesc], T1.[DocumentoFluxoTratDadosDesc] FROM ((((((([Documento] T1 LEFT JOIN [Categoria] T2 ON T2.[CategoriaId] = T1.[CategoriaId]) LEFT JOIN [TipoDado] T3 ON T3.[TipoDadoId] = T1.[TipoDadoId]) LEFT JOIN [FerramentaColeta] T4 ON T4.[FerramentaColetaId] = T1.[FerramentaColetaId]) LEFT JOIN [AbrangenciaGeografica] T5 ON T5.[AbrangenciaGeograficaId] = T1.[AbrangenciaGeograficaId]) LEFT JOIN [FrequenciaTratamento] T6 ON T6.[FrequenciaTratamentoId] = T1.[FrequenciaTratamentoId]) LEFT JOIN [TipoDescarte] T7 ON T7.[TipoDescarteId] = T1.[TipoDescarteId]) LEFT JOIN [TempoRetencao] T8 ON T8.[TempoRetencaoId] = T1.[TempoRetencaoId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P006B6", "SELECT T1.[FonteRetencaoId], T1.[DocumentoId], T2.[FonteRetencaoNome] FROM ([DocFonteRetencao] T1 INNER JOIN [FonteRetencao] T2 ON T2.[FonteRetencaoId] = T1.[FonteRetencaoId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B7", "SELECT T1.[SetorInternoId], T1.[DocumentoId], T2.[SetorInternoNome] FROM ([DocSetorInterno] T1 INNER JOIN [SetorInterno] T2 ON T2.[SetorInternoId] = T1.[SetorInternoId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B8", "SELECT T1.[CompartInternoId], T1.[DocumentoId], T2.[CompartInternoNome] FROM ([DocCompartInterno] T1 INNER JOIN [CompartInterno] T2 ON T2.[CompartInternoId] = T1.[CompartInternoId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B9", "SELECT T1.[EnvolvidosColetaId], T1.[DocumentoId], T2.[EnvolvidosColetaNome] FROM ([DocEnvolvidosColeta] T1 INNER JOIN [EnvolvidosColeta] T2 ON T2.[EnvolvidosColetaId] = T1.[EnvolvidosColetaId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B10", "SELECT T1.[MedidaSegurancaId], T1.[DocumentoId], T2.[MedidaSegurancaNome] FROM ([DocMedidaSeguranca] T1 INNER JOIN [MedidaSeguranca] T2 ON T2.[MedidaSegurancaId] = T1.[MedidaSegurancaId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B11", "SELECT T1.[InformacaoId], T1.[HipoteseTratamentoId], T1.[DocDicionarioId], T1.[DocumentoId], T2.[InformacaoNome], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T3.[HipoteseTratamentoNome], T1.[DocDicionarioTransfInter], T1.[DocDicionarioTipoTransfInterGa], T1.[DocDicionarioFinalidade] FROM (([DocDicionario] T1 INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = T1.[InformacaoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006B12", "SELECT T1.[PaisId], T1.[DocDicionarioId], T2.[PaisNome] FROM ([DicionarioPais] T1 INNER JOIN [Pais] T2 ON T2.[PaisId] = T1.[PaisId]) WHERE (T1.[DocDicionarioId] = @DocDicionarioId) AND (@DocumentoId = @AV8DocumentoId) ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B13", "SELECT T1.[CompartTercExternoId], T1.[DocDicionarioId], T2.[CompartTercExternoNome] FROM ([DicionarioCompartTercExt] T1 INNER JOIN [CompartTercExterno] T2 ON T2.[CompartTercExternoId] = T1.[CompartTercExternoId]) WHERE T1.[DocDicionarioId] = @DocDicionarioId ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B14", "SELECT T1.[OperadorId], T1.[DocumentoId], T2.[OperadorNome], T1.[DocOperadorColeta], T1.[DocOperadorRetencao], T1.[DocOperadorCompartilhamento], T1.[DocOperadorEliminacao], T1.[DocOperadorProcessamento], T1.[DocOperadorId] FROM ([DocOperador] T1 INNER JOIN [Operador] T2 ON T2.[OperadorId] = T1.[OperadorId]) WHERE T1.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B14,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B15", "SELECT [DocumentoId], [RevisaoLogUsuarioAlteracao], [RevisaoLogDataAlteracao], [RevisaoLogObservacao], [RevisaoLogId] FROM [RevisaoLog] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B15,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((string[]) buf[20])[0] = rslt.getVarchar(13);
                ((string[]) buf[21])[0] = rslt.getVarchar(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((string[]) buf[26])[0] = rslt.getVarchar(17);
                ((bool[]) buf[27])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[29])[0] = rslt.wasNull(18);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((string[]) buf[18])[0] = rslt.getVarchar(11);
                ((string[]) buf[19])[0] = rslt.getVarchar(12);
                ((string[]) buf[20])[0] = rslt.getVarchar(13);
                ((string[]) buf[21])[0] = rslt.getVarchar(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((string[]) buf[23])[0] = rslt.getVarchar(16);
                ((bool[]) buf[24])[0] = rslt.getBool(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((string[]) buf[26])[0] = rslt.getVarchar(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((string[]) buf[28])[0] = rslt.getVarchar(19);
                ((bool[]) buf[29])[0] = rslt.wasNull(19);
                ((bool[]) buf[30])[0] = rslt.getBool(20);
                ((bool[]) buf[31])[0] = rslt.wasNull(20);
                ((bool[]) buf[32])[0] = rslt.getBool(21);
                ((bool[]) buf[33])[0] = rslt.wasNull(21);
                ((string[]) buf[34])[0] = rslt.getLongVarchar(22);
                ((bool[]) buf[35])[0] = rslt.wasNull(22);
                ((string[]) buf[36])[0] = rslt.getLongVarchar(23);
                ((bool[]) buf[37])[0] = rslt.wasNull(23);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
